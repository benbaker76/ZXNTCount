# ZXN TCount

## About
ZXN TCount is a tool that can count Z80 and ZXN extended instruction clock cycle counts.

## Features
- Paste in your Z80 asm and it will tell you the T count for each line and total T count
- Based on data hosted [here](http://ped.7gods.org/Z80N_table_ClrHome.html). Thank you ClrHome and Ped7g!
- Includes ZXN Extended OpCodes (core v2.00.22)
- SjASM multi-line instruction support

## Screenshot
![ZXN](/.github/img/ZXNTCount.png)

## Release Notes
| Date | Description |
|---|---|
| 24-08-2021 | v1.1.5 - Add indent and instruction separator options |
| 24-08-2021 | v1.1.4 - Sort bug fix |
| 19-08-2021 | v1.1.3 - Add Select All button, Min/Max TCount |
| 18-08-2021 | v1.1.2 - Load and save custom Instructions.ini |
| 17-08-2021 | v1.1.1 - Fix label parsing bug |
| 17-08-2021 | v1.1.0 - Add comments and multi-line copy and save support |
| 16-08-2021 | v1.0.9 - Changed to use RichTextBox and highlighting synch |
| 14-08-2021 | v1.0.8 - Improved regex (thanks Ped7g). Fixed opcodes |
| 13-08-2021 | v1.0.7 - Improved sorting and regex (thanks Ped7g). Added values to descriptions |
| 12-08-2021 | v1.0.6 - Add back color for undocumented and zxn instructions |
| 11-08-2021 | v1.0.5 - Now uses improved z80/zxn instruction set from here (thanks Ped7g) |
| 11-08-2021 | v1.0.4 - Fix for ld hl,(**) detection |
| 05-08-2021 | v1.0.3 - Change to ListView control, add toolbar, menubar and context menu |
| 04-08-2021 | v1.0.2 - Add Load and Save Settings, Flag and Description output |
| 04-08-2021 | v1.0.1 - Include Byte Count option |
| 03-08-2021 | v1.0.0 - First Release |
