# PDCAnalyser

PDCAnalyser, privately nicknamed, __Please Don't Consider Asking__ is a set of tools designed to make you understand instead of wondering how PDC interrupts work on select Qualcomm Compute Platforms ACPI Tables and Driver sets (both are bound together)

## PDCSolver

PDCSolver is confirmed to work with the following chipset firmware (ACPI and Driver):

- Snapdeagon 7c/7c Gen 2 (7180)
- Snapdragon 7cPlus Gen 3 (7280)
- Snapdragon 8c/8cx/8cx Gen 2 (8180)
- Snapdragon 8cx Gen 3 (8280)

MSM8998, SDM850, and SC8380 and newer are not supported because these SoCs feature end user configurable mappings in ACPI and/or their INFs. Only SoCs above do not.

---

Sample Usage:

```
PDCSolver

Please enter the total count of GPIOs defined under Device(GIO0). You can find such information under the OFNI Method.

Total GPIOs supported: 0xAF

We determined that your GPIO controller supports 3 tiles.

Please now start entering each interrupt defined under the device resources dependencies (_CRS) skipping the very first 3 interrupts as they are for the tile banks and not pdcs. This IRQs are defined as standard Interrupt resources. When done, just press enter with nothing specified. And we will continue with the next steps!

Interrupt: 0x0000022E

Interrupt: 0x00000228

Interrupt: 0x0000023E

Interrupt: 0x0000023F

Interrupt: 0x00000296

Interrupt: 0x00000237

Interrupt: 0x00000252

Interrupt: 0x00000234

Interrupt: 0x00000235

Interrupt: 0x00000283

Interrupt: 0x00000256

Interrupt:

Thank you. Listing mapping for the virtual gpio interrupts first (GpioInts) to the PDC IRQs (what you enterred). All GpioInts using such values are directly linked to the PDC IRQs specified under GIO0 resources.

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

In order to know to which GPIOs these PDC IRQs map to, we need the path to the qcgpio.sys driver you are using alongside such acpi tables. Please enter it below.
qcgpio.sys driver location: C:\Users\gus33\Documents\qcgpio.sys

0x66A0
Attempting to parse at this location above.

PDC IRQ:              167 (0x000000A7)
GPIO Pin:             174 (0x000000AE)
GIC Virtual IRQ:      759 (0x000002F7)
PDC Virtual GPIO:     65535 (0x0000FFFF)
PDC IRQ Register:     0 (0x00000000)
PDC CFG Register:     0 (0x00000000)
Enabled and Unmasked: 0 (0x00000000)
Configured:           0 (0x00000000)


PDC IRQ:              166 (0x000000A6)
GPIO Pin:             172 (0x000000AC)
GIC Virtual IRQ:      758 (0x000002F6)
PDC Virtual GPIO:     65535 (0x0000FFFF)
PDC IRQ Register:     0 (0x00000000)
PDC CFG Register:     0 (0x00000000)
Enabled and Unmasked: 0 (0x00000000)
Configured:           0 (0x00000000)


PDC IRQ:              165 (0x000000A5)
GPIO Pin:             128 (0x00000080)
GIC Virtual IRQ:      757 (0x000002F5)
PDC Virtual GPIO:     65535 (0x0000FFFF)
PDC IRQ Register:     0 (0x00000000)
PDC CFG Register:     0 (0x00000000)
Enabled and Unmasked: 0 (0x00000000)
Configured:           0 (0x00000000)


PDC IRQ:              164 (0x000000A4)
GPIO Pin:             155 (0x0000009B)
GIC Virtual IRQ:      756 (0x000002F4)
PDC Virtual GPIO:     65535 (0x0000FFFF)
PDC IRQ Register:     0 (0x00000000)
PDC CFG Register:     0 (0x00000000)
Enabled and Unmasked: 0 (0x00000000)
Configured:           0 (0x00000000)


PDC IRQ:              163 (0x000000A3)
GPIO Pin:             117 (0x00000075)
GIC Virtual IRQ:      755 (0x000002F3)
PDC Virtual GPIO:     65535 (0x0000FFFF)
PDC IRQ Register:     0 (0x00000000)
PDC CFG Register:     0 (0x00000000)
Enabled and Unmasked: 0 (0x00000000)
Configured:           0 (0x00000000)


PDC IRQ:              162 (0x000000A2)
GPIO Pin:             82 (0x00000052)
GIC Virtual IRQ:      754 (0x000002F2)
PDC Virtual GPIO:     65535 (0x0000FFFF)
PDC IRQ Register:     0 (0x00000000)
PDC CFG Register:     0 (0x00000000)
Enabled and Unmasked: 0 (0x00000000)
Configured:           0 (0x00000000)


PDC IRQ:              161 (0x000000A1)
GPIO Pin:             157 (0x0000009D)
GIC Virtual IRQ:      753 (0x000002F1)
PDC Virtual GPIO:     65535 (0x0000FFFF)
PDC IRQ Register:     0 (0x00000000)
PDC CFG Register:     0 (0x00000000)
Enabled and Unmasked: 0 (0x00000000)
Configured:           0 (0x00000000)


PDC IRQ:              160 (0x000000A0)
GPIO Pin:             95 (0x0000005F)
GIC Virtual IRQ:      752 (0x000002F0)
PDC Virtual GPIO:     65535 (0x0000FFFF)
PDC IRQ Register:     0 (0x00000000)
PDC CFG Register:     0 (0x00000000)
Enabled and Unmasked: 0 (0x00000000)
Configured:           0 (0x00000000)


PDC IRQ:              159 (0x0000009F)
GPIO Pin:             28 (0x0000001C)
GIC Virtual IRQ:      751 (0x000002EF)
PDC Virtual GPIO:     65535 (0x0000FFFF)
PDC IRQ Register:     0 (0x00000000)
PDC CFG Register:     0 (0x00000000)
Enabled and Unmasked: 0 (0x00000000)
Configured:           0 (0x00000000)


PDC IRQ:              158 (0x0000009E)
GPIO Pin:             27 (0x0000001B)
GIC Virtual IRQ:      750 (0x000002EE)
PDC Virtual GPIO:     65535 (0x0000FFFF)
PDC IRQ Register:     0 (0x00000000)
PDC CFG Register:     0 (0x00000000)
Enabled and Unmasked: 0 (0x00000000)
Configured:           0 (0x00000000)


PDC IRQ:              157 (0x0000009D)
GPIO Pin:             36 (0x00000024)
GIC Virtual IRQ:      749 (0x000002ED)
PDC Virtual GPIO:     65535 (0x0000FFFF)
PDC IRQ Register:     0 (0x00000000)
PDC CFG Register:     0 (0x00000000)
Enabled and Unmasked: 0 (0x00000000)
Configured:           0 (0x00000000)


PDC IRQ:              156 (0x0000009C)
GPIO Pin:             52 (0x00000034)
GIC Virtual IRQ:      748 (0x000002EC)
PDC Virtual GPIO:     65535 (0x0000FFFF)
PDC IRQ Register:     0 (0x00000000)
PDC CFG Register:     0 (0x00000000)
Enabled and Unmasked: 0 (0x00000000)
Configured:           0 (0x00000000)


PDC IRQ:              155 (0x0000009B)
GPIO Pin:             8 (0x00000008)
GIC Virtual IRQ:      95 (0x0000005F)
PDC Virtual GPIO:     65535 (0x0000FFFF)
PDC IRQ Register:     0 (0x00000000)
PDC CFG Register:     0 (0x00000000)
Enabled and Unmasked: 0 (0x00000000)
Configured:           0 (0x00000000)


PDC IRQ:              154 (0x0000009A)
GPIO Pin:             88 (0x00000058)
GIC Virtual IRQ:      671 (0x0000029F)
PDC Virtual GPIO:     65535 (0x0000FFFF)
PDC IRQ Register:     0 (0x00000000)
PDC CFG Register:     0 (0x00000000)
Enabled and Unmasked: 0 (0x00000000)
Configured:           0 (0x00000000)


PDC IRQ:              150 (0x00000096)
GPIO Pin:             72 (0x00000048)
GIC Virtual IRQ:      667 (0x0000029B)
PDC Virtual GPIO:     65535 (0x0000FFFF)
PDC IRQ Register:     0 (0x00000000)
PDC CFG Register:     0 (0x00000000)
Enabled and Unmasked: 0 (0x00000000)
Configured:           0 (0x00000000)


PDC IRQ:              149 (0x00000095)
GPIO Pin:             90 (0x0000005A)
GIC Virtual IRQ:      666 (0x0000029A)
PDC Virtual GPIO:     65535 (0x0000FFFF)
PDC IRQ Register:     0 (0x00000000)
PDC CFG Register:     0 (0x00000000)
Enabled and Unmasked: 0 (0x00000000)
Configured:           0 (0x00000000)


PDC IRQ:              148 (0x00000094)
GPIO Pin:             140 (0x0000008C)
GIC Virtual IRQ:      665 (0x00000299)
PDC Virtual GPIO:     65535 (0x0000FFFF)
PDC IRQ Register:     0 (0x00000000)
PDC CFG Register:     0 (0x00000000)
Enabled and Unmasked: 0 (0x00000000)
Configured:           0 (0x00000000)


PDC IRQ:              147 (0x00000093)
GPIO Pin:             136 (0x00000088)
GIC Virtual IRQ:      664 (0x00000298)
PDC Virtual GPIO:     65535 (0x0000FFFF)
PDC IRQ Register:     0 (0x00000000)
PDC CFG Register:     0 (0x00000000)
Enabled and Unmasked: 0 (0x00000000)
Configured:           0 (0x00000000)


PDC IRQ:              146 (0x00000092)
GPIO Pin:             133 (0x00000085)
GIC Virtual IRQ:      663 (0x00000297)
PDC Virtual GPIO:     65535 (0x0000FFFF)
PDC IRQ Register:     0 (0x00000000)
PDC CFG Register:     0 (0x00000000)
Enabled and Unmasked: 0 (0x00000000)
Configured:           0 (0x00000000)


PDC IRQ:              145 (0x00000091)
GPIO Pin:             131 (0x00000083)
GIC Virtual IRQ:      662 (0x00000296)
PDC Virtual GPIO:     65535 (0x0000FFFF)
PDC IRQ Register:     0 (0x00000000)
PDC CFG Register:     0 (0x00000000)
Enabled and Unmasked: 0 (0x00000000)
Configured:           0 (0x00000000)


PDC IRQ:              144 (0x00000090)
GPIO Pin:             32 (0x00000020)
GIC Virtual IRQ:      661 (0x00000295)
PDC Virtual GPIO:     65535 (0x0000FFFF)
PDC IRQ Register:     0 (0x00000000)
PDC CFG Register:     0 (0x00000000)
Enabled and Unmasked: 0 (0x00000000)
Configured:           0 (0x00000000)


PDC IRQ:              143 (0x0000008F)
GPIO Pin:             129 (0x00000081)
GIC Virtual IRQ:      660 (0x00000294)
PDC Virtual GPIO:     65535 (0x0000FFFF)
PDC IRQ Register:     0 (0x00000000)
PDC CFG Register:     0 (0x00000000)
Enabled and Unmasked: 0 (0x00000000)
Configured:           0 (0x00000000)


PDC IRQ:              142 (0x0000008E)
GPIO Pin:             163 (0x000000A3)
GIC Virtual IRQ:      659 (0x00000293)
PDC Virtual GPIO:     65535 (0x0000FFFF)
PDC IRQ Register:     0 (0x00000000)
PDC CFG Register:     0 (0x00000000)
Enabled and Unmasked: 0 (0x00000000)
Configured:           0 (0x00000000)


PDC IRQ:              141 (0x0000008D)
GPIO Pin:             127 (0x0000007F)
GIC Virtual IRQ:      658 (0x00000292)
PDC Virtual GPIO:     65535 (0x0000FFFF)
PDC IRQ Register:     0 (0x00000000)
PDC CFG Register:     0 (0x00000000)
Enabled and Unmasked: 0 (0x00000000)
Configured:           0 (0x00000000)


PDC IRQ:              140 (0x0000008C)
GPIO Pin:             125 (0x0000007D)
GIC Virtual IRQ:      657 (0x00000291)
PDC Virtual GPIO:     65535 (0x0000FFFF)
PDC IRQ Register:     0 (0x00000000)
PDC CFG Register:     0 (0x00000000)
Enabled and Unmasked: 0 (0x00000000)
Configured:           0 (0x00000000)


PDC IRQ:              139 (0x0000008B)
GPIO Pin:             123 (0x0000007B)
GIC Virtual IRQ:      656 (0x00000290)
PDC Virtual GPIO:     65535 (0x0000FFFF)
PDC IRQ Register:     0 (0x00000000)
PDC CFG Register:     0 (0x00000000)
Enabled and Unmasked: 0 (0x00000000)
Configured:           0 (0x00000000)


PDC IRQ:              138 (0x0000008A)
GPIO Pin:             121 (0x00000079)
GIC Virtual IRQ:      655 (0x0000028F)
PDC Virtual GPIO:     65535 (0x0000FFFF)
PDC IRQ Register:     0 (0x00000000)
PDC CFG Register:     0 (0x00000000)
Enabled and Unmasked: 0 (0x00000000)
Configured:           0 (0x00000000)


PDC IRQ:              137 (0x00000089)
GPIO Pin:             119 (0x00000077)
GIC Virtual IRQ:      654 (0x0000028E)
PDC Virtual GPIO:     65535 (0x0000FFFF)
PDC IRQ Register:     0 (0x00000000)
PDC CFG Register:     0 (0x00000000)
Enabled and Unmasked: 0 (0x00000000)
Configured:           0 (0x00000000)


PDC IRQ:              136 (0x00000088)
GPIO Pin:             161 (0x000000A1)
GIC Virtual IRQ:      653 (0x0000028D)
PDC Virtual GPIO:     65535 (0x0000FFFF)
PDC IRQ Register:     0 (0x00000000)
PDC CFG Register:     0 (0x00000000)
Enabled and Unmasked: 0 (0x00000000)
Configured:           0 (0x00000000)


PDC IRQ:              135 (0x00000087)
GPIO Pin:             116 (0x00000074)
GIC Virtual IRQ:      652 (0x0000028C)
PDC Virtual GPIO:     65535 (0x0000FFFF)
PDC IRQ Register:     0 (0x00000000)
PDC CFG Register:     0 (0x00000000)
Enabled and Unmasked: 0 (0x00000000)
Configured:           0 (0x00000000)


PDC IRQ:              134 (0x00000086)
GPIO Pin:             0 (0x00000000)
GIC Virtual IRQ:      651 (0x0000028B)
PDC Virtual GPIO:     65535 (0x0000FFFF)
PDC IRQ Register:     0 (0x00000000)
PDC CFG Register:     0 (0x00000000)
Enabled and Unmasked: 0 (0x00000000)
Configured:           0 (0x00000000)


PDC IRQ:              133 (0x00000085)
GPIO Pin:             75 (0x0000004B)
GIC Virtual IRQ:      650 (0x0000028A)
PDC Virtual GPIO:     65535 (0x0000FFFF)
PDC IRQ Register:     0 (0x00000000)
PDC CFG Register:     0 (0x00000000)
Enabled and Unmasked: 0 (0x00000000)
Configured:           0 (0x00000000)


PDC IRQ:              132 (0x00000084)
GPIO Pin:             148 (0x00000094)
GIC Virtual IRQ:      649 (0x00000289)
PDC Virtual GPIO:     65535 (0x0000FFFF)
PDC IRQ Register:     0 (0x00000000)
PDC CFG Register:     0 (0x00000000)
Enabled and Unmasked: 0 (0x00000000)
Configured:           0 (0x00000000)


PDC IRQ:              131 (0x00000083)
GPIO Pin:             3 (0x00000003)
GIC Virtual IRQ:      648 (0x00000288)
PDC Virtual GPIO:     65535 (0x0000FFFF)
PDC IRQ Register:     0 (0x00000000)
PDC CFG Register:     0 (0x00000000)
Enabled and Unmasked: 0 (0x00000000)
Configured:           0 (0x00000000)


PDC IRQ:              130 (0x00000082)
GPIO Pin:             65535 (0x0000FFFF)
GIC Virtual IRQ:      647 (0x00000287)
PDC Virtual GPIO:     65535 (0x0000FFFF)
PDC IRQ Register:     0 (0x00000000)
PDC CFG Register:     0 (0x00000000)
Enabled and Unmasked: 0 (0x00000000)
Configured:           0 (0x00000000)


PDC IRQ:              129 (0x00000081)
GPIO Pin:             156 (0x0000009C)
GIC Virtual IRQ:      646 (0x00000286)
PDC Virtual GPIO:     65535 (0x0000FFFF)
PDC IRQ Register:     0 (0x00000000)
PDC CFG Register:     0 (0x00000000)
Enabled and Unmasked: 0 (0x00000000)
Configured:           0 (0x00000000)


PDC IRQ:              128 (0x00000080)
GPIO Pin:             93 (0x0000005D)
GIC Virtual IRQ:      645 (0x00000285)
PDC Virtual GPIO:     65535 (0x0000FFFF)
PDC IRQ Register:     0 (0x00000000)
PDC CFG Register:     0 (0x00000000)
Enabled and Unmasked: 0 (0x00000000)
Configured:           0 (0x00000000)


PDC IRQ:              127 (0x0000007F)
GPIO Pin:             68 (0x00000044)
GIC Virtual IRQ:      644 (0x00000284)
PDC Virtual GPIO:     65535 (0x0000FFFF)
PDC IRQ Register:     0 (0x00000000)
PDC CFG Register:     0 (0x00000000)
Enabled and Unmasked: 0 (0x00000000)
Configured:           0 (0x00000000)


PDC IRQ:              126 (0x0000007E)
GPIO Pin:             101 (0x00000065)
GIC Virtual IRQ:      643 (0x00000283)
PDC Virtual GPIO:     65535 (0x0000FFFF)
PDC IRQ Register:     0 (0x00000000)
PDC CFG Register:     0 (0x00000000)
Enabled and Unmasked: 0 (0x00000000)
Configured:           0 (0x00000000)


PDC IRQ:              125 (0x0000007D)
GPIO Pin:             77 (0x0000004D)
GIC Virtual IRQ:      642 (0x00000282)
PDC Virtual GPIO:     65535 (0x0000FFFF)
PDC IRQ Register:     0 (0x00000000)
PDC CFG Register:     0 (0x00000000)
Enabled and Unmasked: 0 (0x00000000)
Configured:           0 (0x00000000)


PDC IRQ:              124 (0x0000007C)
GPIO Pin:             89 (0x00000059)
GIC Virtual IRQ:      641 (0x00000281)
PDC Virtual GPIO:     65535 (0x0000FFFF)
PDC IRQ Register:     0 (0x00000000)
PDC CFG Register:     0 (0x00000000)
Enabled and Unmasked: 0 (0x00000000)
Configured:           0 (0x00000000)


PDC IRQ:              123 (0x0000007B)
GPIO Pin:             61 (0x0000003D)
GIC Virtual IRQ:      605 (0x0000025D)
PDC Virtual GPIO:     65535 (0x0000FFFF)
PDC IRQ Register:     0 (0x00000000)
PDC CFG Register:     0 (0x00000000)
Enabled and Unmasked: 0 (0x00000000)
Configured:           0 (0x00000000)


PDC IRQ:              122 (0x0000007A)
GPIO Pin:             83 (0x00000053)
GIC Virtual IRQ:      604 (0x0000025C)
PDC Virtual GPIO:     65535 (0x0000FFFF)
PDC IRQ Register:     0 (0x00000000)
PDC CFG Register:     0 (0x00000000)
Enabled and Unmasked: 0 (0x00000000)
Configured:           0 (0x00000000)


PDC IRQ:              121 (0x00000079)
GPIO Pin:             4 (0x00000004)
GIC Virtual IRQ:      603 (0x0000025B)
PDC Virtual GPIO:     65535 (0x0000FFFF)
PDC IRQ Register:     0 (0x00000000)
PDC CFG Register:     0 (0x00000000)
Enabled and Unmasked: 0 (0x00000000)
Configured:           0 (0x00000000)


PDC IRQ:              120 (0x00000078)
GPIO Pin:             158 (0x0000009E)
GIC Virtual IRQ:      602 (0x0000025A)
PDC Virtual GPIO:     65535 (0x0000FFFF)
PDC IRQ Register:     0 (0x00000000)
PDC CFG Register:     0 (0x00000000)
Enabled and Unmasked: 0 (0x00000000)
Configured:           0 (0x00000000)


PDC IRQ:              119 (0x00000077)
GPIO Pin:             81 (0x00000051)
GIC Virtual IRQ:      601 (0x00000259)
PDC Virtual GPIO:     65535 (0x0000FFFF)
PDC IRQ Register:     0 (0x00000000)
PDC CFG Register:     0 (0x00000000)
Enabled and Unmasked: 0 (0x00000000)
Configured:           0 (0x00000000)


PDC IRQ:              118 (0x00000076)
GPIO Pin:             80 (0x00000050)
GIC Virtual IRQ:      600 (0x00000258)
PDC Virtual GPIO:     65535 (0x0000FFFF)
PDC IRQ Register:     0 (0x00000000)
PDC CFG Register:     0 (0x00000000)
Enabled and Unmasked: 0 (0x00000000)
Configured:           0 (0x00000000)


PDC IRQ:              117 (0x00000075)
GPIO Pin:             54 (0x00000036)
GIC Virtual IRQ:      599 (0x00000257)
PDC Virtual GPIO:     65535 (0x0000FFFF)
PDC IRQ Register:     0 (0x00000000)
PDC CFG Register:     0 (0x00000000)
Enabled and Unmasked: 0 (0x00000000)
Configured:           0 (0x00000000)


PDC IRQ:              116 (0x00000074)
GPIO Pin:             103 (0x00000067)
GIC Virtual IRQ:      598 (0x00000256)
PDC Virtual GPIO:     65535 (0x0000FFFF)
PDC IRQ Register:     0 (0x00000000)
PDC CFG Register:     0 (0x00000000)
Enabled and Unmasked: 0 (0x00000000)
Configured:           0 (0x00000000)


PDC IRQ:              115 (0x00000073)
GPIO Pin:             141 (0x0000008D)
GIC Virtual IRQ:      597 (0x00000255)
PDC Virtual GPIO:     65535 (0x0000FFFF)
PDC IRQ Register:     0 (0x00000000)
PDC CFG Register:     0 (0x00000000)
Enabled and Unmasked: 0 (0x00000000)
Configured:           0 (0x00000000)


PDC IRQ:              114 (0x00000072)
GPIO Pin:             104 (0x00000068)
GIC Virtual IRQ:      596 (0x00000254)
PDC Virtual GPIO:     65535 (0x0000FFFF)
PDC IRQ Register:     0 (0x00000000)
PDC CFG Register:     0 (0x00000000)
Enabled and Unmasked: 0 (0x00000000)
Configured:           0 (0x00000000)


PDC IRQ:              113 (0x00000071)
GPIO Pin:             142 (0x0000008E)
GIC Virtual IRQ:      595 (0x00000253)
PDC Virtual GPIO:     65535 (0x0000FFFF)
PDC IRQ Register:     0 (0x00000000)
PDC CFG Register:     0 (0x00000000)
Enabled and Unmasked: 0 (0x00000000)
Configured:           0 (0x00000000)


PDC IRQ:              112 (0x00000070)
GPIO Pin:             51 (0x00000033)
GIC Virtual IRQ:      594 (0x00000252)
PDC Virtual GPIO:     65535 (0x0000FFFF)
PDC IRQ Register:     0 (0x00000000)
PDC CFG Register:     0 (0x00000000)
Enabled and Unmasked: 0 (0x00000000)
Configured:           0 (0x00000000)


PDC IRQ:              111 (0x0000006F)
GPIO Pin:             60 (0x0000003C)
GIC Virtual IRQ:      593 (0x00000251)
PDC Virtual GPIO:     65535 (0x0000FFFF)
PDC IRQ Register:     0 (0x00000000)
PDC CFG Register:     0 (0x00000000)
Enabled and Unmasked: 0 (0x00000000)
Configured:           0 (0x00000000)


PDC IRQ:              110 (0x0000006E)
GPIO Pin:             59 (0x0000003B)
GIC Virtual IRQ:      592 (0x00000250)
PDC Virtual GPIO:     65535 (0x0000FFFF)
PDC IRQ Register:     0 (0x00000000)
PDC CFG Register:     0 (0x00000000)
Enabled and Unmasked: 0 (0x00000000)
Configured:           0 (0x00000000)


PDC IRQ:              108 (0x0000006C)
GPIO Pin:             56 (0x00000038)
GIC Virtual IRQ:      590 (0x0000024E)
PDC Virtual GPIO:     65535 (0x0000FFFF)
PDC IRQ Register:     0 (0x00000000)
PDC CFG Register:     0 (0x00000000)
Enabled and Unmasked: 0 (0x00000000)
Configured:           0 (0x00000000)


PDC IRQ:              107 (0x0000006B)
GPIO Pin:             19 (0x00000013)
GIC Virtual IRQ:      589 (0x0000024D)
PDC Virtual GPIO:     65535 (0x0000FFFF)
PDC IRQ Register:     0 (0x00000000)
PDC CFG Register:     0 (0x00000000)
Enabled and Unmasked: 0 (0x00000000)
Configured:           0 (0x00000000)


PDC IRQ:              106 (0x0000006A)
GPIO Pin:             79 (0x0000004F)
GIC Virtual IRQ:      588 (0x0000024C)
PDC Virtual GPIO:     65535 (0x0000FFFF)
PDC IRQ Register:     0 (0x00000000)
PDC CFG Register:     0 (0x00000000)
Enabled and Unmasked: 0 (0x00000000)
Configured:           0 (0x00000000)


PDC IRQ:              105 (0x00000069)
GPIO Pin:             78 (0x0000004E)
GIC Virtual IRQ:      587 (0x0000024B)
PDC Virtual GPIO:     65535 (0x0000FFFF)
PDC IRQ Register:     0 (0x00000000)
PDC CFG Register:     0 (0x00000000)
Enabled and Unmasked: 0 (0x00000000)
Configured:           0 (0x00000000)


PDC IRQ:              104 (0x00000068)
GPIO Pin:             63 (0x0000003F)
GIC Virtual IRQ:      586 (0x0000024A)
PDC Virtual GPIO:     65535 (0x0000FFFF)
PDC IRQ Register:     0 (0x00000000)
PDC CFG Register:     0 (0x00000000)
Enabled and Unmasked: 0 (0x00000000)
Configured:           0 (0x00000000)


PDC IRQ:              103 (0x00000067)
GPIO Pin:             7 (0x00000007)
GIC Virtual IRQ:      585 (0x00000249)
PDC Virtual GPIO:     65535 (0x0000FFFF)
PDC IRQ Register:     0 (0x00000000)
PDC CFG Register:     0 (0x00000000)
Enabled and Unmasked: 0 (0x00000000)
Configured:           0 (0x00000000)


PDC IRQ:              102 (0x00000066)
GPIO Pin:             47 (0x0000002F)
GIC Virtual IRQ:      584 (0x00000248)
PDC Virtual GPIO:     65535 (0x0000FFFF)
PDC IRQ Register:     0 (0x00000000)
PDC CFG Register:     0 (0x00000000)
Enabled and Unmasked: 0 (0x00000000)
Configured:           0 (0x00000000)


PDC IRQ:              101 (0x00000065)
GPIO Pin:             45 (0x0000002D)
GIC Virtual IRQ:      583 (0x00000247)
PDC Virtual GPIO:     65535 (0x0000FFFF)
PDC IRQ Register:     0 (0x00000000)
PDC CFG Register:     0 (0x00000000)
Enabled and Unmasked: 0 (0x00000000)
Configured:           0 (0x00000000)


PDC IRQ:              100 (0x00000064)
GPIO Pin:             44 (0x0000002C)
GIC Virtual IRQ:      582 (0x00000246)
PDC Virtual GPIO:     65535 (0x0000FFFF)
PDC IRQ Register:     0 (0x00000000)
PDC CFG Register:     0 (0x00000000)
Enabled and Unmasked: 0 (0x00000000)
Configured:           0 (0x00000000)


PDC IRQ:              99 (0x00000063)
GPIO Pin:             23 (0x00000017)
GIC Virtual IRQ:      581 (0x00000245)
PDC Virtual GPIO:     65535 (0x0000FFFF)
PDC IRQ Register:     0 (0x00000000)
PDC CFG Register:     0 (0x00000000)
Enabled and Unmasked: 0 (0x00000000)
Configured:           0 (0x00000000)


PDC IRQ:              98 (0x00000062)
GPIO Pin:             41 (0x00000029)
GIC Virtual IRQ:      580 (0x00000244)
PDC Virtual GPIO:     65535 (0x0000FFFF)
PDC IRQ Register:     0 (0x00000000)
PDC CFG Register:     0 (0x00000000)
Enabled and Unmasked: 0 (0x00000000)
Configured:           0 (0x00000000)


PDC IRQ:              97 (0x00000061)
GPIO Pin:             40 (0x00000028)
GIC Virtual IRQ:      579 (0x00000243)
PDC Virtual GPIO:     65535 (0x0000FFFF)
PDC IRQ Register:     0 (0x00000000)
PDC CFG Register:     0 (0x00000000)
Enabled and Unmasked: 0 (0x00000000)
Configured:           0 (0x00000000)


PDC IRQ:              96 (0x00000060)
GPIO Pin:             102 (0x00000066)
GIC Virtual IRQ:      578 (0x00000242)
PDC Virtual GPIO:     65535 (0x0000FFFF)
PDC IRQ Register:     0 (0x00000000)
PDC CFG Register:     0 (0x00000000)
Enabled and Unmasked: 0 (0x00000000)
Configured:           0 (0x00000000)


PDC IRQ:              95 (0x0000005F)
GPIO Pin:             25 (0x00000019)
GIC Virtual IRQ:      577 (0x00000241)
PDC Virtual GPIO:     65535 (0x0000FFFF)
PDC IRQ Register:     0 (0x00000000)
PDC CFG Register:     0 (0x00000000)
Enabled and Unmasked: 0 (0x00000000)
Configured:           0 (0x00000000)


PDC IRQ:              94 (0x0000005E)
GPIO Pin:             130 (0x00000082)
GIC Virtual IRQ:      576 (0x00000240)
PDC Virtual GPIO:     65535 (0x0000FFFF)
PDC IRQ Register:     0 (0x00000000)
PDC CFG Register:     0 (0x00000000)
Enabled and Unmasked: 0 (0x00000000)
Configured:           0 (0x00000000)


PDC IRQ:              93 (0x0000005D)
GPIO Pin:             11 (0x0000000B)
GIC Virtual IRQ:      575 (0x0000023F)
PDC Virtual GPIO:     65535 (0x0000FFFF)
PDC IRQ Register:     0 (0x00000000)
PDC CFG Register:     0 (0x00000000)
Enabled and Unmasked: 0 (0x00000000)
Configured:           0 (0x00000000)


PDC IRQ:              92 (0x0000005C)
GPIO Pin:             35 (0x00000023)
GIC Virtual IRQ:      574 (0x0000023E)
PDC Virtual GPIO:     65535 (0x0000FFFF)
PDC IRQ Register:     0 (0x00000000)
PDC CFG Register:     0 (0x00000000)
Enabled and Unmasked: 0 (0x00000000)
Configured:           0 (0x00000000)


PDC IRQ:              90 (0x0000005A)
GPIO Pin:             31 (0x0000001F)
GIC Virtual IRQ:      572 (0x0000023C)
PDC Virtual GPIO:     65535 (0x0000FFFF)
PDC IRQ Register:     0 (0x00000000)
PDC CFG Register:     0 (0x00000000)
Enabled and Unmasked: 0 (0x00000000)
Configured:           0 (0x00000000)


PDC IRQ:              89 (0x00000059)
GPIO Pin:             153 (0x00000099)
GIC Virtual IRQ:      571 (0x0000023B)
PDC Virtual GPIO:     65535 (0x0000FFFF)
PDC IRQ Register:     0 (0x00000000)
PDC CFG Register:     0 (0x00000000)
Enabled and Unmasked: 0 (0x00000000)
Configured:           0 (0x00000000)


PDC IRQ:              88 (0x00000058)
GPIO Pin:             151 (0x00000097)
GIC Virtual IRQ:      570 (0x0000023A)
PDC Virtual GPIO:     65535 (0x0000FFFF)
PDC IRQ Register:     0 (0x00000000)
PDC CFG Register:     0 (0x00000000)
Enabled and Unmasked: 0 (0x00000000)
Configured:           0 (0x00000000)


PDC IRQ:              87 (0x00000057)
GPIO Pin:             150 (0x00000096)
GIC Virtual IRQ:      569 (0x00000239)
PDC Virtual GPIO:     65535 (0x0000FFFF)
PDC IRQ Register:     0 (0x00000000)
PDC CFG Register:     0 (0x00000000)
Enabled and Unmasked: 0 (0x00000000)
Configured:           0 (0x00000000)


PDC IRQ:              86 (0x00000056)
GPIO Pin:             24 (0x00000018)
GIC Virtual IRQ:      568 (0x00000238)
PDC Virtual GPIO:     65535 (0x0000FFFF)
PDC IRQ Register:     0 (0x00000000)
PDC CFG Register:     0 (0x00000000)
Enabled and Unmasked: 0 (0x00000000)
Configured:           0 (0x00000000)


PDC IRQ:              85 (0x00000055)
GPIO Pin:             43 (0x0000002B)
GIC Virtual IRQ:      567 (0x00000237)
PDC Virtual GPIO:     65535 (0x0000FFFF)
PDC IRQ Register:     0 (0x00000000)
PDC CFG Register:     0 (0x00000000)
Enabled and Unmasked: 0 (0x00000000)
Configured:           0 (0x00000000)


PDC IRQ:              84 (0x00000054)
GPIO Pin:             55 (0x00000037)
GIC Virtual IRQ:      566 (0x00000236)
PDC Virtual GPIO:     65535 (0x0000FFFF)
PDC IRQ Register:     0 (0x00000000)
PDC CFG Register:     0 (0x00000000)
Enabled and Unmasked: 0 (0x00000000)
Configured:           0 (0x00000000)


PDC IRQ:              83 (0x00000053)
GPIO Pin:             21 (0x00000015)
GIC Virtual IRQ:      565 (0x00000235)
PDC Virtual GPIO:     65535 (0x0000FFFF)
PDC IRQ Register:     0 (0x00000000)
PDC CFG Register:     0 (0x00000000)
Enabled and Unmasked: 0 (0x00000000)
Configured:           0 (0x00000000)


PDC IRQ:              82 (0x00000052)
GPIO Pin:             20 (0x00000014)
GIC Virtual IRQ:      564 (0x00000234)
PDC Virtual GPIO:     65535 (0x0000FFFF)
PDC IRQ Register:     0 (0x00000000)
PDC CFG Register:     0 (0x00000000)
Enabled and Unmasked: 0 (0x00000000)
Configured:           0 (0x00000000)


PDC IRQ:              81 (0x00000051)
GPIO Pin:             18 (0x00000012)
GIC Virtual IRQ:      563 (0x00000233)
PDC Virtual GPIO:     65535 (0x0000FFFF)
PDC IRQ Register:     0 (0x00000000)
PDC CFG Register:     0 (0x00000000)
Enabled and Unmasked: 0 (0x00000000)
Configured:           0 (0x00000000)


PDC IRQ:              80 (0x00000050)
GPIO Pin:             16 (0x00000010)
GIC Virtual IRQ:      562 (0x00000232)
PDC Virtual GPIO:     65535 (0x0000FFFF)
PDC IRQ Register:     0 (0x00000000)
PDC CFG Register:     0 (0x00000000)
Enabled and Unmasked: 0 (0x00000000)
Configured:           0 (0x00000000)


PDC IRQ:              79 (0x0000004F)
GPIO Pin:             15 (0x0000000F)
GIC Virtual IRQ:      561 (0x00000231)
PDC Virtual GPIO:     65535 (0x0000FFFF)
PDC IRQ Register:     0 (0x00000000)
PDC CFG Register:     0 (0x00000000)
Enabled and Unmasked: 0 (0x00000000)
Configured:           0 (0x00000000)


PDC IRQ:              78 (0x0000004E)
GPIO Pin:             12 (0x0000000C)
GIC Virtual IRQ:      560 (0x00000230)
PDC Virtual GPIO:     65535 (0x0000FFFF)
PDC IRQ Register:     0 (0x00000000)
PDC CFG Register:     0 (0x00000000)
Enabled and Unmasked: 0 (0x00000000)
Configured:           0 (0x00000000)


PDC IRQ:              77 (0x0000004D)
GPIO Pin:             34 (0x00000022)
GIC Virtual IRQ:      559 (0x0000022F)
PDC Virtual GPIO:     65535 (0x0000FFFF)
PDC IRQ Register:     0 (0x00000000)
PDC CFG Register:     0 (0x00000000)
Enabled and Unmasked: 0 (0x00000000)
Configured:           0 (0x00000000)


PDC IRQ:              76 (0x0000004C)
GPIO Pin:             91 (0x0000005B)
GIC Virtual IRQ:      558 (0x0000022E)
PDC Virtual GPIO:     65535 (0x0000FFFF)
PDC IRQ Register:     0 (0x00000000)
PDC CFG Register:     0 (0x00000000)
Enabled and Unmasked: 0 (0x00000000)
Configured:           0 (0x00000000)


PDC IRQ:              75 (0x0000004B)
GPIO Pin:             86 (0x00000056)
GIC Virtual IRQ:      557 (0x0000022D)
PDC Virtual GPIO:     65535 (0x0000FFFF)
PDC IRQ Register:     0 (0x00000000)
PDC CFG Register:     0 (0x00000000)
Enabled and Unmasked: 0 (0x00000000)
Configured:           0 (0x00000000)


PDC IRQ:              74 (0x0000004A)
GPIO Pin:             48 (0x00000030)
GIC Virtual IRQ:      556 (0x0000022C)
PDC Virtual GPIO:     65535 (0x0000FFFF)
PDC IRQ Register:     0 (0x00000000)
PDC CFG Register:     0 (0x00000000)
Enabled and Unmasked: 0 (0x00000000)
Configured:           0 (0x00000000)


PDC IRQ:              73 (0x00000049)
GPIO Pin:             39 (0x00000027)
GIC Virtual IRQ:      555 (0x0000022B)
PDC Virtual GPIO:     65535 (0x0000FFFF)
PDC IRQ Register:     0 (0x00000000)
PDC CFG Register:     0 (0x00000000)
Enabled and Unmasked: 0 (0x00000000)
Configured:           0 (0x00000000)


PDC IRQ:              72 (0x00000048)
GPIO Pin:             112 (0x00000070)
GIC Virtual IRQ:      554 (0x0000022A)
PDC Virtual GPIO:     65535 (0x0000FFFF)
PDC IRQ Register:     0 (0x00000000)
PDC CFG Register:     0 (0x00000000)
Enabled and Unmasked: 0 (0x00000000)
Configured:           0 (0x00000000)


PDC IRQ:              70 (0x00000046)
GPIO Pin:             65535 (0x0000FFFF)
GIC Virtual IRQ:      552 (0x00000228)
PDC Virtual GPIO:     65535 (0x0000FFFF)
PDC IRQ Register:     0 (0x00000000)
PDC CFG Register:     0 (0x00000000)
Enabled and Unmasked: 0 (0x00000000)
Configured:           0 (0x00000000)

Determining PDC Mappings...

PDC IRQ: 759 (0x000002F7) <-> GPIO (Real) 174 (0x000000AE))
PDC IRQ: 758 (0x000002F6) <-> GPIO (Real) 172 (0x000000AC))
PDC IRQ: 757 (0x000002F5) <-> GPIO (Real) 128 (0x00000080))
PDC IRQ: 756 (0x000002F4) <-> GPIO (Real) 155 (0x0000009B))
PDC IRQ: 755 (0x000002F3) <-> GPIO (Real) 117 (0x00000075))
PDC IRQ: 754 (0x000002F2) <-> GPIO (Real) 82 (0x00000052))
PDC IRQ: 753 (0x000002F1) <-> GPIO (Real) 157 (0x0000009D))
PDC IRQ: 752 (0x000002F0) <-> GPIO (Real) 95 (0x0000005F))
PDC IRQ: 751 (0x000002EF) <-> GPIO (Real) 28 (0x0000001C))
PDC IRQ: 750 (0x000002EE) <-> GPIO (Real) 27 (0x0000001B))
PDC IRQ: 749 (0x000002ED) <-> GPIO (Real) 36 (0x00000024))
PDC IRQ: 748 (0x000002EC) <-> GPIO (Real) 52 (0x00000034))
PDC IRQ: 95 (0x0000005F) <-> GPIO (Real) 8 (0x00000008))
PDC IRQ: 671 (0x0000029F) <-> GPIO (Real) 88 (0x00000058))
PDC IRQ: 667 (0x0000029B) <-> GPIO (Real) 72 (0x00000048))
PDC IRQ: 666 (0x0000029A) <-> GPIO (Real) 90 (0x0000005A))
PDC IRQ: 665 (0x00000299) <-> GPIO (Real) 140 (0x0000008C))
PDC IRQ: 664 (0x00000298) <-> GPIO (Real) 136 (0x00000088))
PDC IRQ: 663 (0x00000297) <-> GPIO (Real) 133 (0x00000085))
PDC IRQ: 662 (0x00000296) <-> GPIO (Real) 131 (0x00000083))
PDC IRQ: 661 (0x00000295) <-> GPIO (Real) 32 (0x00000020))
PDC IRQ: 660 (0x00000294) <-> GPIO (Real) 129 (0x00000081))
PDC IRQ: 659 (0x00000293) <-> GPIO (Real) 163 (0x000000A3))
PDC IRQ: 658 (0x00000292) <-> GPIO (Real) 127 (0x0000007F))
PDC IRQ: 657 (0x00000291) <-> GPIO (Real) 125 (0x0000007D))
PDC IRQ: 656 (0x00000290) <-> GPIO (Real) 123 (0x0000007B))
PDC IRQ: 655 (0x0000028F) <-> GPIO (Real) 121 (0x00000079))
PDC IRQ: 654 (0x0000028E) <-> GPIO (Real) 119 (0x00000077))
PDC IRQ: 653 (0x0000028D) <-> GPIO (Real) 161 (0x000000A1))
PDC IRQ: 652 (0x0000028C) <-> GPIO (Real) 116 (0x00000074))
PDC IRQ: 651 (0x0000028B) <-> GPIO (Real) 0 (0x00000000))
PDC IRQ: 650 (0x0000028A) <-> GPIO (Real) 75 (0x0000004B))
PDC IRQ: 649 (0x00000289) <-> GPIO (Real) 148 (0x00000094))
PDC IRQ: 648 (0x00000288) <-> GPIO (Real) 3 (0x00000003))
PDC IRQ: 647 (0x00000287) <-> GPIO (Real) 65535 (0x0000FFFF))
PDC IRQ: 646 (0x00000286) <-> GPIO (Real) 156 (0x0000009C))
PDC IRQ: 645 (0x00000285) <-> GPIO (Real) 93 (0x0000005D))
PDC IRQ: 644 (0x00000284) <-> GPIO (Real) 68 (0x00000044))
PDC IRQ: 643 (0x00000283) <-> GPIO (Real) 101 (0x00000065))
PDC IRQ: 642 (0x00000282) <-> GPIO (Real) 77 (0x0000004D))
PDC IRQ: 641 (0x00000281) <-> GPIO (Real) 89 (0x00000059))
PDC IRQ: 605 (0x0000025D) <-> GPIO (Real) 61 (0x0000003D))
PDC IRQ: 604 (0x0000025C) <-> GPIO (Real) 83 (0x00000053))
PDC IRQ: 603 (0x0000025B) <-> GPIO (Real) 4 (0x00000004))
PDC IRQ: 602 (0x0000025A) <-> GPIO (Real) 158 (0x0000009E))
PDC IRQ: 601 (0x00000259) <-> GPIO (Real) 81 (0x00000051))
PDC IRQ: 600 (0x00000258) <-> GPIO (Real) 80 (0x00000050))
PDC IRQ: 599 (0x00000257) <-> GPIO (Real) 54 (0x00000036))
PDC IRQ: 598 (0x00000256) <-> GPIO (Real) 103 (0x00000067))
PDC IRQ: 597 (0x00000255) <-> GPIO (Real) 141 (0x0000008D))
PDC IRQ: 596 (0x00000254) <-> GPIO (Real) 104 (0x00000068))
PDC IRQ: 595 (0x00000253) <-> GPIO (Real) 142 (0x0000008E))
PDC IRQ: 594 (0x00000252) <-> GPIO (Real) 51 (0x00000033))
PDC IRQ: 593 (0x00000251) <-> GPIO (Real) 60 (0x0000003C))
PDC IRQ: 592 (0x00000250) <-> GPIO (Real) 59 (0x0000003B))
PDC IRQ: 590 (0x0000024E) <-> GPIO (Real) 56 (0x00000038))
PDC IRQ: 589 (0x0000024D) <-> GPIO (Real) 19 (0x00000013))
PDC IRQ: 588 (0x0000024C) <-> GPIO (Real) 79 (0x0000004F))
PDC IRQ: 587 (0x0000024B) <-> GPIO (Real) 78 (0x0000004E))
PDC IRQ: 586 (0x0000024A) <-> GPIO (Real) 63 (0x0000003F))
PDC IRQ: 585 (0x00000249) <-> GPIO (Real) 7 (0x00000007))
PDC IRQ: 584 (0x00000248) <-> GPIO (Real) 47 (0x0000002F))
PDC IRQ: 583 (0x00000247) <-> GPIO (Real) 45 (0x0000002D))
PDC IRQ: 582 (0x00000246) <-> GPIO (Real) 44 (0x0000002C))
PDC IRQ: 581 (0x00000245) <-> GPIO (Real) 23 (0x00000017))
PDC IRQ: 580 (0x00000244) <-> GPIO (Real) 41 (0x00000029))
PDC IRQ: 579 (0x00000243) <-> GPIO (Real) 40 (0x00000028))
PDC IRQ: 578 (0x00000242) <-> GPIO (Real) 102 (0x00000066))
PDC IRQ: 577 (0x00000241) <-> GPIO (Real) 25 (0x00000019))
PDC IRQ: 576 (0x00000240) <-> GPIO (Real) 130 (0x00000082))
PDC IRQ: 575 (0x0000023F) <-> GPIO (Real) 11 (0x0000000B))
PDC IRQ: 574 (0x0000023E) <-> GPIO (Real) 35 (0x00000023))
PDC IRQ: 572 (0x0000023C) <-> GPIO (Real) 31 (0x0000001F))
PDC IRQ: 571 (0x0000023B) <-> GPIO (Real) 153 (0x00000099))
PDC IRQ: 570 (0x0000023A) <-> GPIO (Real) 151 (0x00000097))
PDC IRQ: 569 (0x00000239) <-> GPIO (Real) 150 (0x00000096))
PDC IRQ: 568 (0x00000238) <-> GPIO (Real) 24 (0x00000018))
PDC IRQ: 567 (0x00000237) <-> GPIO (Real) 43 (0x0000002B))
PDC IRQ: 566 (0x00000236) <-> GPIO (Real) 55 (0x00000037))
PDC IRQ: 565 (0x00000235) <-> GPIO (Real) 21 (0x00000015))
PDC IRQ: 564 (0x00000234) <-> GPIO (Real) 20 (0x00000014))
PDC IRQ: 563 (0x00000233) <-> GPIO (Real) 18 (0x00000012))
PDC IRQ: 562 (0x00000232) <-> GPIO (Real) 16 (0x00000010))
PDC IRQ: 561 (0x00000231) <-> GPIO (Real) 15 (0x0000000F))
PDC IRQ: 560 (0x00000230) <-> GPIO (Real) 12 (0x0000000C))
PDC IRQ: 559 (0x0000022F) <-> GPIO (Real) 34 (0x00000022))
PDC IRQ: 558 (0x0000022E) <-> GPIO (Real) 91 (0x0000005B))
PDC IRQ: 557 (0x0000022D) <-> GPIO (Real) 86 (0x00000056))
PDC IRQ: 556 (0x0000022C) <-> GPIO (Real) 48 (0x00000030))
PDC IRQ: 555 (0x0000022B) <-> GPIO (Real) 39 (0x00000027))
PDC IRQ: 554 (0x0000022A) <-> GPIO (Real) 112 (0x00000070))
PDC IRQ: 552 (0x00000228) <-> GPIO (Real) 65535 (0x0000FFFF))

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