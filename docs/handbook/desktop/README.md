# Desktop handbook — DataCareNext

What the original Windows product does, how it looks and is operated, and where its sources are. Business rules
and data conventions are in [business-rules.md](business-rules.md); a guide to each of the 13 ribbon tabs is in
[modules.md](modules.md); every menu individually is in the [menu catalog](../menu-catalog.md).

Facts below come from the decompiled source, the desktop databases (aggregate queries only) and the 30 official
tutorial videos. Statements marked *inferred* are reasoned from the code and still need a runtime check on Windows.

## 1. Product overview

- **What it is.** A jewellery and gold-trading ERP with integrated accounting: company and year setup, masters,
  retail and wholesale sales and purchases, tagged and loose stock, cash and bank, ledgers and the day book (Rojmel),
  artisan (karigar) and manufacturing work, pledge loans (Dhiran), savings schemes and loyalty points, GST and
  e-invoicing, around 255 printed reports, utilities and a small CRM
  (`.kiro/specs/datacare-web-rebuild/requirements.md:3-13`, `project-memory/video-research/INDEX.md`).
- **Who uses it.** Cashiers, purchasing staff, stock and manufacturing staff, accountants, managers and an
  administrator (`docs/master-parity-plan-2026-09-29/08-decisions-and-delivery.md:68-75`). A company is set up as
  retail or wholesale and as gold or silver (`project-memory/video-research/_kb/KB_master.md:52-62`).
- **Size.** 204 primary source units (forms, helpers and posting engines) and 255 Crystal report templates
  (`docs/master-parity-plan-2026-09-29/05-desktop-reference.md:11-24`); 198 named menu actions in 13 tabs
  (`web/docs/HANDOFF.md:306`); 146 tables with 5,254 columns in the audited desktop database
  (`docs/master-parity-plan-2026-09-29/05-desktop-reference.md:33`); 3,508 grid-column, 1,599 control and 5,838 event
  records in the [requirement index](../../master-parity-plan-2026-09-29/requirement-index.json).
- **Variants and companions.** `NextDm.exe` is a separate variant (199 units; 123 of the shared files differ).
  NextEmp is a bulk WhatsApp/SMS tool, NextImage stores per-tag images, AllImage holds image stores and an old
  ASP.NET site (`unified/README.md`, `project-memory/catalogs/nextemp-catalog.json`).

## 2. Runtime and deployment

- x86 .NET Framework 4.7.2 WinForms with DevExpress 19.1, DevComponents DotNetBar2, Qios controls and SAP Crystal
  Reports (`unified/docs/WINDOWS_BUILD_GUIDE.md:29-55`).
- SQL Server: one database per financial year (`Next23`, `Next24`, `Next25`), `NextMain` for users, menus and
  machine registration, and `NextImage` for images. Choosing a year switches the active database to
  `Next` + the year's two digits (`unified/src/csharp/DataCareNext/MS_OPNCOMP.cs:570-598`).
- Several workstations share one SQL Server on the LAN (*inferred* from the configurable server name, Windows or SQL
  authentication and per-user rights: `unified/src/csharp/DataCareNext/DC_Main.cs:967-1054`,
  `DataCareNext_Source/Setup/SETUP_README.md`).
- Each workstation is registered by baseboard and disk serial numbers (`unified/src/csharp/DataCareNext/MS_LOGIN.cs:467-502`).
- Backup writes native `.BAK` files of the yearly database and `NextMain` to a chosen drive
  (`project-memory/video-research/_kb/KB_master.md:225-245`).

## 3. How it looks and is operated

- **Login, then company, location and year.** The company picker shows company and location names in the
  "DataCare Help" list; opening a company loads its settings and the yearly database
  (`unified/src/csharp/DataCareNext/MS_OPNCOMP.cs:430-505`, `project-memory/video-research/_kb/KB_master.md:47-62`).
- **MDI shell.** The tutorials show an orange top menu, a left "Pro" rail, a title bar with company, year, user and
  mode, and a status strip (`project-memory/video-research/_kb/KB_master.md:14-26`). The menu actions are grouped
  in 13 tabs in `MENU_DATA` (`web/docs/HANDOFF.md:306`). Dispatched forms open as MDI child windows, for example
  `unified/src/csharp/DataCareNext/MDI_FORM.cs:9854`.
- **Book chooser.** Clicking a transaction menu calls `CurBookHelp`: it lists active books of that family
  (`MAIN_BOOK`) for the company and location; one match is chosen automatically, several open a picker, none shows
  "Please Create Book" (`unified/src/csharp/DataCareNext/DC_Main.cs:1489-1550`).
- **Transaction screens.** A header (voucher number, date, reference, party, book), one or more editable grids, the
  party's live money, gold and silver balance, a totals and tender panel on the right, and buttons at the bottom
  (Print, Save, Cancel, Delete, Exit, navigation). The sales screen adds item, charge, old-metal and order grids, an
  item image, GST/TCS/rounding and split tender (`project-memory/video-research/_kb/KB_transaction.md:10-20,43-88`).
- **Keyboard first.** Enter moves to the next field or cell; Enter or F1 on a code field opens the "DataCare Help"
  lookup grid. Shell shortcuts: F2 ledger, F3 stock, F4 sales order, F5 bullion sale, F6 wholesale sale, F7 purchase,
  F8 and F9 cash receipt and payment, F11 Rojmel, F12 tag stock; Ctrl chords open daily rate, cash-bank, order zoom
  and tag estimate (`project-memory/catalogs/menu-tree.json`).
- **Validation.** A modal message box, focus back on the offending field, and the save is refused
  (`unified/src/csharp/DataCareNext/MS_LOGIN.cs:598-634`). A source scan counted 631 distinct validation messages
  (`docs/master-parity-plan-2026-09-29/05-desktop-reference.md:26`).
- **Save and print.** Saving usually opens a small Print Menu: Original is ticked, Duplicate and Triplicate are
  optional, then View, Print or Exit (`unified/src/csharp/DataCareNext/MS_PRINT.cs:314-315,385-553`). The printed copy labels
  are "ORIGINAL FOR RECIPIENT", "DUPLICATE FOR SUPPLIER" and "TRIPLICATE FOR TRANSPORTER"
  (`unified/src/csharp/DataCareNext/TR_SALE.cs:16569-16588`). View opens the Crystal viewer.
- **Live context.** The shell shows the live gold and silver rate with its time; choosing a party shows its opening
  and closing money and metal balance (`unified/src/csharp/DataCareNext/DC_Main.cs:1463-1487`,
  `unified/src/csharp/DataCareNext/MDI_FORM.cs:13756-13889`).

The tutorial keyframes show these screens: `project-memory/video-research/<playlist>/<video>/keyframes/kf_NNN.jpg`,
indexed by screen in the knowledge base (`project-memory/video-research/_kb/README.md`).

## 4. Navigation map

| Tab | Menus | What it covers |
|---|---:|---|
| Company | 16 | Company, location, year create and select, books, users and rights, account groups, trade groups, settings, menu tiles, balance transfer, data refresh, backup |
| Master | 23 | Parties, addresses, products, groups, items and auto-items, employees, taxes, counters, design book, diamonds and sizes, styles, labour and touch, points, stock limits, openings |
| Transaction | 24 | Sales, purchase, returns, orders, quotations, cash, bank, contra, wholesale, stock in/out, rate cut, bullion booking and sale, e-invoice and e-credit-note |
| ExtraTran | 21 | Approval and consignment, bill-wise and card receipts, fine JV, fine sale and purchase, labour work, old-item and tag-wise purchase, other income and expenses, service commission, VP parcel, location amounts |
| Karigar | 15 | Karigar issue, receipt and design issue, the repair chain, employee stock issue and receipt, tour order, sales and reports |
| Dhiran | 12 | Pledge and loan issue and receipt, interest, dues, outstanding letters, Dhiran and loan reports |
| Scheme | 11 | Scheme and member masters, opening, instalments, member and gold adjustment, ledger, monthly, branch and day-sales reports |
| Mfg | 4 | Manufacturing process master, lot issue/receipt report, manufacturing in/out and ledger |
| Report | 26 | Ledgers, final accounts, Rojmel, cash-bank, outstanding, sales, purchase, stock, tag, HUID, GST, order, approval, bullion, VP, trading, address and image reports |
| More | 12 | Bill profit, employee sales, entry and user checks, graphs, movement, stock levels, order tracking, points, stone reports |
| Analysis | 8 | Bill ageing, deletion audit, last visit, order zoom, party and stock ledgers, movement, tag detail |
| Other | 24 | Daily rate, physical stock, tag cancel, transfer, split, weight change, print and adjust, bank reconciliation, order cancel, labour update, reminders, SMS, WhatsApp, import, export, estimate reset, voucher renumber |
| Crm | 2 | Customer entry and customer report |

**Screens outside the menu table.** About 60 dispatch captions have no `MENU_DATA` row: the full manufacturing stage
chain, Jadtar, B2B, Hedging Fix, item purchase and sales, MRP update, item balance, day work, stock value, bill
interest, digital gold and franchise. Some have active books in the seed company, so they are in scope for a
customer when one of their books is in use or their edition setting is on (decision D21; slice N72;
`docs/master-parity-plan-2026-09-29/11-audit-implementation-plan-2026-10-01.md:840-861`).

## 5. Devices and integrations

- **Weighing scale** on a serial port: a CH340 USB-serial adapter is detected automatically, otherwise the port in
  `WEIGHT_PORT` is used (`unified/src/csharp/DataCareNext/TR_TAG_OPBL.cs:7499-7538`).
- **Labels** from `PRINT_MAST` tag and QR formats through Crystal, with Code39 and QR codes; selection by tag,
  product group or voucher and sheet-label skipping (`project-memory/video-research/_kb/KB_other.md:106-145`).
- **Camera** snapshots (`unified/src/csharp/DataCareNext/UT_WEB_CAM.cs:103-239`); images as files or
  `NextImage.TAG_IMAGE_DATA` rows keyed by company, location, tag and serial.
- **Messaging:** browser-automated WhatsApp, the Meta WhatsApp API and HTTP SMS gateways; NextEmp runs bulk
  campaigns.
- **E-invoice:** IRN payloads authenticated with a GST suvidha provider; credentials are configuration keys and must
  stay server-side.
- **Rate feed:** the shell fetches USD/INR and gold/silver prices, converts to local units and stores them in
  `CONV_MAST` (`unified/src/csharp/DataCareNext/MDI_FORM.cs:13756-13889`).

## 6. Utilities and administration

- **Backup and restore** to a chosen drive (`UT_BKP`).
- **Import and export** move many master and transaction tables between companies, years or machines with
  delete-then-insert (`web-implementation-spec/03_Modules/13_Utilities_Settings_Integrations/VARIANTS.md:72-96`).
- **Year and company creation.** `MS_YEAR` creates the yearly database and, for a new company, `NewCompParmCreat`
  copies 17 master and configuration tables from a chosen company or company 01
  (`unified/src/csharp/DataCareNext/MS_YEAR.cs:1357-1363,1504-1595`; details in [business-rules.md](business-rules.md#company-and-year-creation)).
- **Voucher renumber** rewrites numbers across every dependent table
  (`web-implementation-spec/03_Modules/13_Utilities_Settings_Integrations/VARIANTS.md:9-35`).
- **Data refresh and repair** rebuild ledger, stock, opening and serial data and repair orphans
  (`web-implementation-spec/03_Modules/13_Utilities_Settings_Integrations/VARIANTS.md:99-119`).
- **Users, menus and machines.** `MS_USER` stores per-form View/Edit/Delete/Print rights; `MS_WINDOW_SET` sets menu
  tiles; `UT_HDD` registers the machine.

## 7. Editions and variants

- **Work and metal mode** per company (retail or wholesale, gold or silver); books then specialise tax, free or URD
  purchase, item type, direction, printing and account slots.
- **Edition codes** Lite, Basic, Standard, Ultra, Pro, Advance and Enterprise decide which menus are visible: for
  example schemes are hidden up to Standard and Dhiran up to Ultra (`unified/src/csharp/DataCareNext/MDI_FORM.cs:11249-11338`).
- **India and UAE.** India uses GST, HSN, GSTR returns and e-invoice; UAE uses separate VAT sale, purchase and return
  forms (`TR_PR_SL_UAE`, `TR_SALE_RTN_UAE`).
- **Manufacturing routing** changes with one-form, order-linked and lot-based settings
  (`unified/src/csharp/DataCareNext/MS_OPNCOMP.cs:4989-5064`): the same caption can open a different form
  (`unified/src/csharp/DataCareNext/MDI_FORM.cs:9845-9894`).
- **Franchise** in/out (`TR_FN_INOUT`) moves tagged stock with money and GST.

## 8. Desktop weaknesses that must not be ported

Keep the business outcome, not the defect (document 08; [ADR-0004](../../../project-memory/decisions/ADR-0004-two-phase-delivery.md)).

| Weakness | Example | Web rule |
|---|---|---|
| SQL built by string concatenation | `unified/src/csharp/DataCareNext/MS_LOGIN.cs:559-605` | Parameterised queries only |
| Plaintext passwords in `LOGIN_MAST` | `unified/src/csharp/DataCareNext/UT_PWD_UPDATE.cs:706-732` | Argon2 hashes; migrated users reset |
| Process-wide mutable session state | `unified/src/csharp/DataCareNext/DC_Main.cs:37-177` | Server-owned session context per request |
| Deletes without company or user scope | `unified/src/csharp/DataCareNext/UT_HDD.cs:762` | Every delete scoped and audited |
| Partial writes after commit | Sale remarks and tax adjustments after the commit (document 05 §45) | One atomic write set |
| Online machine translation | `unified/src/csharp/DataCareNext/Translator.cs:31-98` | Reviewed language catalogues (D22) |

## 9. Sources and how to research desktop behaviour

| Need | Source |
|---|---|
| Menu → form dispatch | `unified/src/csharp/DataCareNext/MDI_FORM.cs` (search the caption) |
| What a form does | `unified/src/csharp/DataCareNext/<FORM>.cs`, its catalog page `project-memory/catalogs/forms/<FORM>.md` and behaviour file `project-memory/catalogs/form-behavior/<FORM>.behavior.json` |
| How a screen looks | Tutorial knowledge base `project-memory/video-research/_kb/KB_*.md` with keyframes; extracted layouts in `web/apps/api/form-specs/` |
| Shared posting engines | `Ac_Ledr.cs`, `Ac_Stock.cs`, `Ac_Rojmel.cs`, `Ac_Tax.cs`, `DC_Main.cs` in the same folder |
| Tables and columns | `project-memory/catalogs/realdb-schema-full.json`, `web-implementation-spec/02_Data_Model/tables/` |
| Settings | `project-memory/catalogs/settings-catalog.json`, [document 09](../../master-parity-plan-2026-09-29/09-surface-register.md) |
| Reports | 255 templates in `unified/reports/`, parsed layouts in `project-memory/catalogs/report-layouts/` |
| Line-level references | [`desktop-form-reference.json`](../../master-parity-plan-2026-09-29/desktop-form-reference.json): every source unit with method anchors, tables written, reports and grid columns |

**Safe method** ([document 05](../../master-parity-plan-2026-09-29/05-desktop-reference.md)):

1. Start from the dispatch line, then the form's save and delete routines and the posting helpers they call.
2. Confirm against a tutorial keyframe for layout and against the desktop database for conventions.
3. Query the desktop SQL Server only with **aggregate** queries (counts, distinct codes, column shapes). One of the
   databases holds real customer data: never select names, phone numbers or row dumps, and never copy them into the
   repository.
4. Record what is source-derived until a Windows run or a captured database row confirms it.

## 10. Glossary

| Term | Meaning |
|---|---|
| Rojmel | The jeweller's day book: money and metal movements together; not a copy of the ledger |
| Kasar | A settlement write-off that reduces the remaining bill; Avak (incoming) and Javak (outgoing) accounts |
| Touch | Metal purity percentage |
| Fine | Pure metal weight: net weight × touch / 100 |
| Wastage (West) | Extra purity allowance added to touch, used in karigar and manufacturing receipts |
| Ghat | Process loss or deduction weight in melting and manufacturing (*inferred* per form) |
| Labour (making charge) | Charged per piece, per gram of net or gross weight, per 1,000, as a percentage or fixed |
| Tag | Barcode identity of one physical piece with its weights, purity and labour |
| HUID | Hallmark unique identification number of a piece |
| URD | Purchase from an unregistered dealer (old metal from the public) |
| Karigar | Artisan or job worker who receives metal and returns ornaments |
| Dhiran | Pledge loan against customer ornaments, with packets, custody and interest |
| Jadtar | Stone-setting job work (*inferred*) |
| Approval | Goods issued to a party without a sale; returned goods re-enter stock, accepted goods are billed |
| Tour | Stock taken by a salesperson for visits, with return, order and sale flows |
| VP parcel | Value-payable (cash-on-delivery) parcel with charges and later collection (*inferred*) |
| Rate cut | Fixing an open metal position at a rate, drawing down its unfixed balance |
| Bullion booking | Agreement for fine metal at a locked rate, drawn down by later deliveries |
| Scheme / member | Monthly savings plan and the enrolled customer; distinct from loyalty points |
| Book | A voucher series: 3-digit code, family (`MAIN_BOOK`), direction and account slots |
