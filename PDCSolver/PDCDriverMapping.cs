namespace PDCSolver
{
    public class PDCDriverMapping
    {
        public ushort PDCIRQ
        {
            get; set;
        }

        public ushort GPIONum
        {
            get; set;
        }

        public uint GICVirtualInterrupt
        {
            get; set;
        }

        public ushort PDCVirtualGPIONum
        {
            get; set;
        }

        public ulong PDCIRQReg
        {
            get; set;
        }

        public ulong PDCCFGReg
        {
            get; set;
        }

        public byte EnabledAndUnmasked
        {
            get; set;
        }

        public byte Configured
        {
            get; set;
        }
    }
}
