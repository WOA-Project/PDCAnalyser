# PDCAnalyser

PDCAnalyser, privately nicknamed, __Please Don't Consider Asking__ is a set of tools designed to make you understand instead of wondering how PDC interrupts work on select Qualcomm Compute Platforms ACPI Tables and Driver sets (both are bound together)

## PDCSolver

PDCSolver is confirmed to work with the following chipset firmware (ACPI and Driver):

- Snapdeagon 7c/7c Gen 2 (7180)
- Snapdragon 7cPlus Gen 3 (7280)
- Snapdragon 8c/8cx/8cx Gen 2 (8180)
- Snapdragon 8cx Gen 3 (8280)

MSM8998, SDM850, and SC8380 and newer are not supported because these SoCs feature end user configurable mappings in ACPI and/or their INFs. Only SoCs above do not.

### Explanation

On above SoCs, a PDC controller is present in order to support scenarios where an interrupt line wired to a gpio on the SoC should wake up the device from sleep.

Said PDC controller requires specific programming in order to be able to wake the device and fire an interrupt for the OS to handle and forward to a specific driver.

On Windows, for these given SoCs, the driver responsible for implementing the GPIO controller, (Input/Output and Interrupts) is qcgpio.sys, providing an easy method in ACPI to set GPIOs and Declare Interrupts using GpioIo and GpioInt ACPI directives.

The problem, is that you cannot make a GPIO IRQ be able to wake the system without waking up the SoC using the PDC by simply defining a GpioInt dependency with a specific number.

The solution adopted in Windows by qualcomm consists of the following:

- Qualcomm Assumes each tile of gpios on the SoC can have a very maximum of 64 gpios per tile
- As such, for a device with 175 GPIOs supported, the tile count would for example be 3.
- The GPIO driver on windows is responsible for deciding on its own what the value passed in acpi exactly means.
- It was therefore decided that for every value between 0 and 174, these would be normal GPIOs, and interrupts setup using those would not be wakable
- And for wakable GPIOs, instead, they would set up each IRQ of the PDC, under the GIO0 device, and bind each interrupt firing of the PDC; to virtual values, being a multiple of 64 starting from the total number of tiles times 64, to the last interrupt for pdc declared index, times 64
- The driver contains a hardcoded table, dictating what each PDC IRQ value (Interrupt) maps to which TLMM GPIO number.
- The driver, whenever it encouters a device using a wakable GPIO Interrupt, reads the value passed in (which is virtual)
- Using said value, finds for which PDC IRQ it corresponds to (divide the number by 64 to get the index of the interrupt resource under GIO0 in ACPI)
- and then fire an interrupt event whenever said PDC IRQ fires under GIO0, for the GpioInt declaration of the other device

Thus, there are two parts to this story:

- The GPIO Driver Qualcomm wrote implicitely defines virtual gpio number values, equalling to the index of the PDC IRQ under GIO0, times, 64.
- The GPIO Driver Qualcomm wrote, binds each PDC IRQ defined in ACPI, with a specific GPIO TLMM Number, to be programmed to the PDC

In order to know what a GpioInt with wake being set maps to (in terms of GPIO number), you thus first need to get which PDC IRQ this virtual gpio value is for (divide by 64), then obtain this interrupt number (under GPIO0), and then, read the table off qcgpio.sys, to know for which GPIO Number, this PDC IRQ value, is for.

Thats what, this tool, does in a nutshell, for you.

### Sample Usage

```
PDCSolver

Please enter the total count of GPIOs defined under Device(GIO0). You can find such information under the OFNI Method.

Total GPIOs supported: 0xAF

We determined that your GPIO controller supports 3 tiles.

Please now start entering each interrupt defined under the device resources dependencies (_CRS) skipping the very first 3 interrupts as they are for the tile banks and not pdcs. This IRQs are defined as standard Interrupt resources. When done, just press enter with nothing specified. And we will continue with the next steps!

Interrupt[3]: 0x0000022E
Interrupt[4]: 0x00000228
Interrupt[5]: 0x0000023E
Interrupt[6]: 0x0000023F
Interrupt[7]: 0x00000296
Interrupt[8]: 0x00000237
Interrupt[9]: 0x00000252
Interrupt[10]: 0x00000234
Interrupt[11]: 0x00000235
Interrupt[12]: 0x00000283
Interrupt[13]: 0x00000256
Interrupt[14]:

In order to know to which GPIOs these PDC IRQs map to, we need the path to the qcgpio.sys driver you are using alongside such acpi tables. Please enter it below.

qcgpio.sys driver location: C:\Users\gus33\Documents\qcgpio.sys

Attempting to parse driver binary at this location 0x66A0.

Listing mapping for the virtual gpio interrupts first (GpioInts) to the PDC IRQs (what you enterred). All GpioInts using such values are directly linked to the PDC IRQs specified under GIO0 resources.

PDC IRQ: 558 (0x0000022E) <-> GpioInt (Virtual) 192 (0x000000C0)
PDC IRQ: 552 (0x00000228) <-> GpioInt (Virtual) 256 (0x00000100)
PDC IRQ: 574 (0x0000023E) <-> GpioInt (Virtual) 320 (0x00000140)
PDC IRQ: 575 (0x0000023F) <-> GpioInt (Virtual) 384 (0x00000180)
PDC IRQ: 662 (0x00000296) <-> GpioInt (Virtual) 448 (0x000001C0)
PDC IRQ: 567 (0x00000237) <-> GpioInt (Virtual) 512 (0x00000200)
PDC IRQ: 594 (0x00000252) <-> GpioInt (Virtual) 576 (0x00000240)
PDC IRQ: 564 (0x00000234) <-> GpioInt (Virtual) 640 (0x00000280)
PDC IRQ: 565 (0x00000235) <-> GpioInt (Virtual) 704 (0x000002C0)
PDC IRQ: 643 (0x00000283) <-> GpioInt (Virtual) 768 (0x00000300)
PDC IRQ: 598 (0x00000256) <-> GpioInt (Virtual) 832 (0x00000340)

Determining PDC Mappings from driver...

PDC IRQ: 759 (0x000002F7) <-> GPIO (Real) 174 (0x000000AE)
PDC IRQ: 758 (0x000002F6) <-> GPIO (Real) 172 (0x000000AC)
PDC IRQ: 757 (0x000002F5) <-> GPIO (Real) 128 (0x00000080)
PDC IRQ: 756 (0x000002F4) <-> GPIO (Real) 155 (0x0000009B)
PDC IRQ: 755 (0x000002F3) <-> GPIO (Real) 117 (0x00000075)
PDC IRQ: 754 (0x000002F2) <-> GPIO (Real) 82 (0x00000052)
PDC IRQ: 753 (0x000002F1) <-> GPIO (Real) 157 (0x0000009D)
PDC IRQ: 752 (0x000002F0) <-> GPIO (Real) 95 (0x0000005F)
PDC IRQ: 751 (0x000002EF) <-> GPIO (Real) 28 (0x0000001C)
PDC IRQ: 750 (0x000002EE) <-> GPIO (Real) 27 (0x0000001B)
PDC IRQ: 749 (0x000002ED) <-> GPIO (Real) 36 (0x00000024)
PDC IRQ: 748 (0x000002EC) <-> GPIO (Real) 52 (0x00000034)
PDC IRQ: 95 (0x0000005F) <-> GPIO (Real) 8 (0x00000008)
PDC IRQ: 671 (0x0000029F) <-> GPIO (Real) 88 (0x00000058)
PDC IRQ: 667 (0x0000029B) <-> GPIO (Real) 72 (0x00000048)
PDC IRQ: 666 (0x0000029A) <-> GPIO (Real) 90 (0x0000005A)
PDC IRQ: 665 (0x00000299) <-> GPIO (Real) 140 (0x0000008C)
PDC IRQ: 664 (0x00000298) <-> GPIO (Real) 136 (0x00000088)
PDC IRQ: 663 (0x00000297) <-> GPIO (Real) 133 (0x00000085)
PDC IRQ: 662 (0x00000296) <-> GPIO (Real) 131 (0x00000083)
PDC IRQ: 661 (0x00000295) <-> GPIO (Real) 32 (0x00000020)
PDC IRQ: 660 (0x00000294) <-> GPIO (Real) 129 (0x00000081)
PDC IRQ: 659 (0x00000293) <-> GPIO (Real) 163 (0x000000A3)
PDC IRQ: 658 (0x00000292) <-> GPIO (Real) 127 (0x0000007F)
PDC IRQ: 657 (0x00000291) <-> GPIO (Real) 125 (0x0000007D)
PDC IRQ: 656 (0x00000290) <-> GPIO (Real) 123 (0x0000007B)
PDC IRQ: 655 (0x0000028F) <-> GPIO (Real) 121 (0x00000079)
PDC IRQ: 654 (0x0000028E) <-> GPIO (Real) 119 (0x00000077)
PDC IRQ: 653 (0x0000028D) <-> GPIO (Real) 161 (0x000000A1)
PDC IRQ: 652 (0x0000028C) <-> GPIO (Real) 116 (0x00000074)
PDC IRQ: 651 (0x0000028B) <-> GPIO (Real) 0 (0x00000000)
PDC IRQ: 650 (0x0000028A) <-> GPIO (Real) 75 (0x0000004B)
PDC IRQ: 649 (0x00000289) <-> GPIO (Real) 148 (0x00000094)
PDC IRQ: 648 (0x00000288) <-> GPIO (Real) 3 (0x00000003)
PDC IRQ: 647 (0x00000287) <-> GPIO (Real) 65535 (0x0000FFFF)
PDC IRQ: 646 (0x00000286) <-> GPIO (Real) 156 (0x0000009C)
PDC IRQ: 645 (0x00000285) <-> GPIO (Real) 93 (0x0000005D)
PDC IRQ: 644 (0x00000284) <-> GPIO (Real) 68 (0x00000044)
PDC IRQ: 643 (0x00000283) <-> GPIO (Real) 101 (0x00000065)
PDC IRQ: 642 (0x00000282) <-> GPIO (Real) 77 (0x0000004D)
PDC IRQ: 641 (0x00000281) <-> GPIO (Real) 89 (0x00000059)
PDC IRQ: 605 (0x0000025D) <-> GPIO (Real) 61 (0x0000003D)
PDC IRQ: 604 (0x0000025C) <-> GPIO (Real) 83 (0x00000053)
PDC IRQ: 603 (0x0000025B) <-> GPIO (Real) 4 (0x00000004)
PDC IRQ: 602 (0x0000025A) <-> GPIO (Real) 158 (0x0000009E)
PDC IRQ: 601 (0x00000259) <-> GPIO (Real) 81 (0x00000051)
PDC IRQ: 600 (0x00000258) <-> GPIO (Real) 80 (0x00000050)
PDC IRQ: 599 (0x00000257) <-> GPIO (Real) 54 (0x00000036)
PDC IRQ: 598 (0x00000256) <-> GPIO (Real) 103 (0x00000067)
PDC IRQ: 597 (0x00000255) <-> GPIO (Real) 141 (0x0000008D)
PDC IRQ: 596 (0x00000254) <-> GPIO (Real) 104 (0x00000068)
PDC IRQ: 595 (0x00000253) <-> GPIO (Real) 142 (0x0000008E)
PDC IRQ: 594 (0x00000252) <-> GPIO (Real) 51 (0x00000033)
PDC IRQ: 593 (0x00000251) <-> GPIO (Real) 60 (0x0000003C)
PDC IRQ: 592 (0x00000250) <-> GPIO (Real) 59 (0x0000003B)
PDC IRQ: 590 (0x0000024E) <-> GPIO (Real) 56 (0x00000038)
PDC IRQ: 589 (0x0000024D) <-> GPIO (Real) 19 (0x00000013)
PDC IRQ: 588 (0x0000024C) <-> GPIO (Real) 79 (0x0000004F)
PDC IRQ: 587 (0x0000024B) <-> GPIO (Real) 78 (0x0000004E)
PDC IRQ: 586 (0x0000024A) <-> GPIO (Real) 63 (0x0000003F)
PDC IRQ: 585 (0x00000249) <-> GPIO (Real) 7 (0x00000007)
PDC IRQ: 584 (0x00000248) <-> GPIO (Real) 47 (0x0000002F)
PDC IRQ: 583 (0x00000247) <-> GPIO (Real) 45 (0x0000002D)
PDC IRQ: 582 (0x00000246) <-> GPIO (Real) 44 (0x0000002C)
PDC IRQ: 581 (0x00000245) <-> GPIO (Real) 23 (0x00000017)
PDC IRQ: 580 (0x00000244) <-> GPIO (Real) 41 (0x00000029)
PDC IRQ: 579 (0x00000243) <-> GPIO (Real) 40 (0x00000028)
PDC IRQ: 578 (0x00000242) <-> GPIO (Real) 102 (0x00000066)
PDC IRQ: 577 (0x00000241) <-> GPIO (Real) 25 (0x00000019)
PDC IRQ: 576 (0x00000240) <-> GPIO (Real) 130 (0x00000082)
PDC IRQ: 575 (0x0000023F) <-> GPIO (Real) 11 (0x0000000B)
PDC IRQ: 574 (0x0000023E) <-> GPIO (Real) 35 (0x00000023)
PDC IRQ: 572 (0x0000023C) <-> GPIO (Real) 31 (0x0000001F)
PDC IRQ: 571 (0x0000023B) <-> GPIO (Real) 153 (0x00000099)
PDC IRQ: 570 (0x0000023A) <-> GPIO (Real) 151 (0x00000097)
PDC IRQ: 569 (0x00000239) <-> GPIO (Real) 150 (0x00000096)
PDC IRQ: 568 (0x00000238) <-> GPIO (Real) 24 (0x00000018)
PDC IRQ: 567 (0x00000237) <-> GPIO (Real) 43 (0x0000002B)
PDC IRQ: 566 (0x00000236) <-> GPIO (Real) 55 (0x00000037)
PDC IRQ: 565 (0x00000235) <-> GPIO (Real) 21 (0x00000015)
PDC IRQ: 564 (0x00000234) <-> GPIO (Real) 20 (0x00000014)
PDC IRQ: 563 (0x00000233) <-> GPIO (Real) 18 (0x00000012)
PDC IRQ: 562 (0x00000232) <-> GPIO (Real) 16 (0x00000010)
PDC IRQ: 561 (0x00000231) <-> GPIO (Real) 15 (0x0000000F)
PDC IRQ: 560 (0x00000230) <-> GPIO (Real) 12 (0x0000000C)
PDC IRQ: 559 (0x0000022F) <-> GPIO (Real) 34 (0x00000022)
PDC IRQ: 558 (0x0000022E) <-> GPIO (Real) 91 (0x0000005B)
PDC IRQ: 557 (0x0000022D) <-> GPIO (Real) 86 (0x00000056)
PDC IRQ: 556 (0x0000022C) <-> GPIO (Real) 48 (0x00000030)
PDC IRQ: 555 (0x0000022B) <-> GPIO (Real) 39 (0x00000027)
PDC IRQ: 554 (0x0000022A) <-> GPIO (Real) 112 (0x00000070)
PDC IRQ: 552 (0x00000228) <-> GPIO (Real) 65535 (0x0000FFFF)

FINAL RESULTs:

PDC IRQ: 558 (0x0000022E) <-> GpioInt (Virtual) 192 (0x000000C0) <-> GPIO (Real) 91 (0x0000005B)
PDC IRQ: 552 (0x00000228) <-> GpioInt (Virtual) 256 (0x00000100) <-> GPIO (Real) 65535 (0x0000FFFF)
PDC IRQ: 574 (0x0000023E) <-> GpioInt (Virtual) 320 (0x00000140) <-> GPIO (Real) 35 (0x00000023)
PDC IRQ: 575 (0x0000023F) <-> GpioInt (Virtual) 384 (0x00000180) <-> GPIO (Real) 11 (0x0000000B)
PDC IRQ: 662 (0x00000296) <-> GpioInt (Virtual) 448 (0x000001C0) <-> GPIO (Real) 131 (0x00000083)
PDC IRQ: 567 (0x00000237) <-> GpioInt (Virtual) 512 (0x00000200) <-> GPIO (Real) 43 (0x0000002B)
PDC IRQ: 594 (0x00000252) <-> GpioInt (Virtual) 576 (0x00000240) <-> GPIO (Real) 51 (0x00000033)
PDC IRQ: 564 (0x00000234) <-> GpioInt (Virtual) 640 (0x00000280) <-> GPIO (Real) 20 (0x00000014)
PDC IRQ: 565 (0x00000235) <-> GpioInt (Virtual) 704 (0x000002C0) <-> GPIO (Real) 21 (0x00000015)
PDC IRQ: 643 (0x00000283) <-> GpioInt (Virtual) 768 (0x00000300) <-> GPIO (Real) 101 (0x00000065)
PDC IRQ: 598 (0x00000256) <-> GpioInt (Virtual) 832 (0x00000340) <-> GPIO (Real) 103 (0x00000067)
```

ACPI Reference used for above sample usage:

```
        Device (GIO0)
        {
            Name (_HID, "QCOM0A0C")  // _HID: Hardware ID
            Name (_UID, Zero)  // _UID: Unique ID
            Alias (\_SB.PSUB, _SUB)
            OperationRegion (GPOR, GeneralPurposeIo, Zero, One)
            Field (\_SB.GIO0.GPOR, ByteAcc, NoLock, Preserve)
            {
                Connection (
                    GpioIo (Shared, PullNone, 0x0000, 0x0000, IoRestrictionNone,
                        "\\_SB.GIO0", 0x00, ResourceConsumer, ,
                        )
                        {   // Pin list
                            0x0023
                        }
                ), 
                LIDR,   1
            }

            Method (_CRS, 0, NotSerialized)  // _CRS: Current Resource Settings
            {
                Name (RBUF, ResourceTemplate ()
                {
                    Memory32Fixed (ReadWrite,
                        0x0F100000,         // Address Base
                        0x00300000,         // Address Length
                        )
                    Interrupt (ResourceConsumer, Level, ActiveHigh, Shared, ,, )
                    {
                        0x000000F0,
                    }
                    Interrupt (ResourceConsumer, Level, ActiveHigh, Shared, ,, )
                    {
                        0x000000F0,
                    }
                    Interrupt (ResourceConsumer, Level, ActiveHigh, Shared, ,, )
                    {
                        0x000000F0,
                    }
                    Interrupt (ResourceConsumer, Level, ActiveHigh, Shared, ,, )
                    {
                        0x0000022E,
                    }
                    Interrupt (ResourceConsumer, Level, ActiveHigh, Shared, ,, )
                    {
                        0x00000228,
                    }
                    Interrupt (ResourceConsumer, Level, ActiveHigh, Exclusive, ,, )
                    {
                        0x0000023E,
                    }
                    Interrupt (ResourceConsumer, Edge, ActiveHigh, Shared, ,, )
                    {
                        0x0000023F,
                    }
                    Interrupt (ResourceConsumer, Level, ActiveHigh, Shared, ,, )
                    {
                        0x00000296,
                    }
                    Interrupt (ResourceConsumer, Edge, ActiveHigh, Shared, ,, )
                    {
                        0x00000237,
                    }
                    Interrupt (ResourceConsumer, Level, ActiveHigh, Shared, ,, )
                    {
                        0x00000252,
                    }
                    Interrupt (ResourceConsumer, Edge, ActiveHigh, Exclusive, ,, )
                    {
                        0x00000234,
                    }
                    Interrupt (ResourceConsumer, Edge, ActiveHigh, Exclusive, ,, )
                    {
                        0x00000235,
                    }
                    Interrupt (ResourceConsumer, Level, ActiveHigh, Shared, ,, )
                    {
                        0x00000283,
                    }
                    Interrupt (ResourceConsumer, Level, ActiveHigh, Shared, ,, )
                    {
                        0x00000256,
                    }
                })
                Return (RBUF) /* \_SB_.GIO0._CRS.RBUF */
            }

            Method (OFNI, 0, NotSerialized)
            {
                Name (RBUF, Buffer (0x02)
                {
                     0xAF, 0x00                                       // ..
                })
                Return (RBUF) /* \_SB_.GIO0.OFNI.RBUF */
            }

            // ... (Cutting here)
```