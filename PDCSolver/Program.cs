using System.Drawing;
using System.Globalization;

namespace PDCSolver
{
    internal static class Program
    {
        private static int ParseStringInput(string TotalGPIOsStr)
        {
            int TotalGPIOs = 0;

            if (TotalGPIOsStr.StartsWith("0x", StringComparison.CurrentCultureIgnoreCase) ||
                TotalGPIOsStr.StartsWith("&H", StringComparison.CurrentCultureIgnoreCase))
            {
                string hex = TotalGPIOsStr.Substring(2);

                TotalGPIOs = int.Parse(hex,
                        NumberStyles.HexNumber,
                        CultureInfo.CurrentCulture);
            }
            else
            {
                TotalGPIOs = int.Parse(TotalGPIOsStr);
            }

            return TotalGPIOs;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("PDCSolver");
            Console.WriteLine();

            Console.WriteLine("Please enter the total count of GPIOs defined under Device(GIO0). You can find such information under the OFNI Method.");
            Console.WriteLine();

            Console.Write("Total GPIOs supported: ");
            string TotalGPIOsStr = Console.ReadLine();
            Console.WriteLine();

            int TotalGPIOs = ParseStringInput(TotalGPIOsStr);

            int tileInterruptCount = (TotalGPIOs + (64 - (TotalGPIOs % 64))) / 64;

            Console.WriteLine("We determined that your GPIO controller supports " + tileInterruptCount + " tiles.");
            Console.WriteLine();

            Console.WriteLine($"Please now start entering each interrupt defined under the device resources dependencies (_CRS) skipping the very first {tileInterruptCount} interrupts as they are for the tile banks and not pdcs. This IRQs are defined as standard Interrupt resources. When done, just press enter with nothing specified. And we will continue with the next steps!");
            Console.WriteLine();

            List<int> DefinedPDCInterrupts = [];

            while (true)
            {
                Console.Write("Interrupt: ");
                string InterruptStr = Console.ReadLine();
                Console.WriteLine();

                if (string.IsNullOrEmpty(InterruptStr))
                {
                    break;
                }

                int Interrupt = ParseStringInput(InterruptStr);

                DefinedPDCInterrupts.Add(Interrupt);
            }

            Console.WriteLine("Thank you. Listing mapping for the virtual gpio interrupts first (GpioInts) to the PDC IRQs (what you enterred). All GpioInts using such values are directly linked to the PDC IRQs specified under GIO0 resources.");
            Console.WriteLine();

            for (int i = 0; i < DefinedPDCInterrupts.Count; i++)
            {
                Console.WriteLine($"PDC IRQ: {DefinedPDCInterrupts[i]} (0x{DefinedPDCInterrupts[i]:X8}) <-> GpioInt (Virtual) {(i + tileInterruptCount) * 64} (0x{(i + tileInterruptCount) * 64:X8})");
            }

            Console.WriteLine();
            Console.WriteLine("In order to know to which GPIOs these PDC IRQs map to, we need the path to the qcgpio.sys driver you are using alongside such acpi tables. Please enter it below.");

            Console.Write("qcgpio.sys driver location: ");
            string QCGPIOStr = Console.ReadLine();
            Console.WriteLine();

            List<PDCDriverMapping> PDCDriverMappings = [];

            // This seems to be a rather stable pattern, not my best work but does the job on 8180, 7280.
            byte[] LookUpPattern = [0xFF, 0xFF, 0x00, 0x00, 0xFF, 0xFF, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00];

            byte[] driverBin = File.ReadAllBytes(QCGPIOStr);
            int[] locs = driverBin.Locate(LookUpPattern);
            foreach (int loc in locs)
            {
                Console.WriteLine($"0x{loc + LookUpPattern.Length:X}");

                Console.WriteLine("Attempting to parse at this location above.");

                using BinaryReader br = new(new MemoryStream(driverBin));
                br.BaseStream.Seek(loc + LookUpPattern.Length, SeekOrigin.Begin);

                while (true)
                {
                    ushort pdcirq = br.ReadUInt16();
                    ushort gpionum = br.ReadUInt16();
                    uint gicvirtualinterrupt = br.ReadUInt32();
                    ushort pdcvirtualgpionum = br.ReadUInt16();
                    byte[] unknown0 = br.ReadBytes(6);
                    ulong pdcirqreg = br.ReadUInt64();
                    ulong pdccfgreg = br.ReadUInt64();
                    byte enabledandunmasked = br.ReadByte();
                    byte configured = br.ReadByte();
                    byte[] unknown1 = br.ReadBytes(6);

                    if (pdcirq == 0)
                    {
                        break;
                    }

                    Console.WriteLine();
                    Console.WriteLine($"PDC IRQ:              {pdcirq} (0x{pdcirq:X8})");
                    Console.WriteLine($"GPIO Pin:             {gpionum} (0x{gpionum:X8})");
                    Console.WriteLine($"GIC Virtual IRQ:      {gicvirtualinterrupt} (0x{gicvirtualinterrupt:X8})");
                    Console.WriteLine($"PDC Virtual GPIO:     {pdcvirtualgpionum} (0x{pdcvirtualgpionum:X8})");
                    Console.WriteLine($"PDC IRQ Register:     {pdcirqreg} (0x{pdcirqreg:X8})");
                    Console.WriteLine($"PDC CFG Register:     {pdccfgreg} (0x{pdccfgreg:X8})");
                    Console.WriteLine($"Enabled and Unmasked: {enabledandunmasked} (0x{enabledandunmasked:X8})");
                    Console.WriteLine($"Configured:           {configured} (0x{configured:X8})");
                    Console.WriteLine();

                    PDCDriverMappings.Add(new PDCDriverMapping()
                    {
                        EnabledAndUnmasked = enabledandunmasked,
                        Configured = configured,
                        GICVirtualInterrupt = gicvirtualinterrupt,
                        GPIONum = gpionum,
                        PDCCFGReg = pdccfgreg,
                        PDCIRQ = pdcirq,
                        PDCIRQReg = pdcirqreg,
                        PDCVirtualGPIONum = pdcvirtualgpionum
                    });
                }
            }

            Console.WriteLine("Determining PDC Mappings...");
            Console.WriteLine();

            for (int i = 0; i < PDCDriverMappings.Count; i++)
            {
                Console.WriteLine($"PDC IRQ: {PDCDriverMappings[i].GICVirtualInterrupt} (0x{PDCDriverMappings[i].GICVirtualInterrupt:X8}) <-> GPIO (Real) {PDCDriverMappings[i].GPIONum} (0x{PDCDriverMappings[i].GPIONum:X8}))");
            }

            Console.WriteLine();
            Console.WriteLine("FINAL RESULTs:");
            Console.WriteLine();

            for (int i = 0; i < DefinedPDCInterrupts.Count; i++)
            {
                int DefinedPDCIRQ = DefinedPDCInterrupts[i];
                int VirtualGPIOInterrupt = (i + tileInterruptCount) * 64;
                int RealGPIONum = PDCDriverMappings.First(x => x.GICVirtualInterrupt == DefinedPDCIRQ).GPIONum;

                Console.WriteLine($"PDC IRQ: {DefinedPDCIRQ} (0x{DefinedPDCIRQ:X8}) <-> GpioInt (Virtual) {VirtualGPIOInterrupt} (0x{VirtualGPIOInterrupt:X8}) <-> GPIO (Real) {RealGPIONum} (0x{RealGPIONum:X8})");
            }
        }

        // --------------------------------------------------

        //
        // https://stackoverflow.com/posts/283648/timeline
        //

        static readonly int[] Empty = new int[0];

        static bool IsMatch(byte[] array, int position, byte[] candidate)
        {
            if (candidate.Length > (array.Length - position))
                return false;

            for (int i = 0; i < candidate.Length; i++)
                if (array[position + i] != candidate[i])
                    return false;

            return true;
        }

        static bool IsEmptyLocate(byte[] array, byte[] candidate)
        {
            return array == null
                || candidate == null
                || array.Length == 0
                || candidate.Length == 0
                || candidate.Length > array.Length;
        }

        public static int[] Locate(this byte[] self, byte[] candidate)
        {
            if (IsEmptyLocate(self, candidate))
                return Empty;

            var list = new List<int>();

            for (int i = 0; i < self.Length; i++)
            {
                if (!IsMatch(self, i, candidate))
                    continue;

                list.Add(i);
            }

            return list.Count == 0 ? Empty : list.ToArray();
        }
    }
}
