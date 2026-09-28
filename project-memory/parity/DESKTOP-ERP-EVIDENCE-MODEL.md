# DataCareNext Desktop ERP — Evidence Model

**Audit baseline:** 2026-07-26  
**Canonical desktop source:** `unified/src/csharp/DataCareNext/`  
**Purpose:** define the behavior the web replacement must reproduce before any implementation or parity claim can be accepted.

## 1. Scope and evidence rules

This model describes the extracted DataCareNext Windows jewelry ERP, not the current web implementation. It is derived from:

1. **Highest-authority structural evidence:** restored SQL schema and decompiled canonical DataCareNext source.
2. **Highest-authority visual/runtime evidence:** 30 tutorial transcripts and 1,069 keyframes.
3. **Extracted specifications:** form behavior, logic, layout, menu, setting, resource, integration, and Crystal-layout catalogs.
4. **Secondary evidence:** older audits and implementation documents, used only where they agree with current artifacts.

When sources conflict, current canonical source and schema win. In particular:

- The canonical desktop contains **204**, not 206, C# form/class files.
- Fine weight is **not** universally `net × touch / 100`; formulas vary by workflow.
- Report geometry is no longer broadly missing: 253 layouts are complete and one is partial.
- The extracted configuration is present; older “configuration unrecovered” documents are historical.
- Claims in the tutorial KB about web parity are not accepted here; the web is audited independently.

Decompiled names and control indices are preserved where semantic labels cannot be proved. Unresolved behavior is labeled rather than guessed.

## 2. Quantitative baseline

| Surface | Verified quantity | Evidence |
|---|---:|---|
| Canonical DataCareNext C# files | 204 | `unified/src/csharp/DataCareNext/*.cs` |
| Older NextDm C# files | 199 | `unified/src/csharp_nextdm/DataCareNext/*.cs`; prior diff found no independent feature surface |
| RESX resources | 165 | canonical extraction inventory |
| Forms cataloged | 204 | `project-memory/catalogs/module-map.json` |
| Form categories | other 43; master 33; report 45; transaction 61; utility 22 | module map |
| Transaction forms with posting | 57 | module map |
| Form behavior specs | 204 | `project-memory/catalogs/form-behavior/` |
| Form logic specs | 172 | `project-memory/catalogs/form-logic/` |
| Form layout specs | 177 | `project-memory/catalogs/layouts/` |
| Extracted grid columns | 6,973 | behavior index |
| SQL occurrences in form behavior | 5,128 | behavior index |
| Key bindings/events | 795 | behavior index |
| Calculations | 3,309 | behavior index |
| Validations | 1,849 | behavior index |
| Menu captions/items | 136 / 106 | `menu-tree.json`; `menuGroups: 2` is a parser grouping metric, not the count of visible top menus |
| CO_SET setting keys | 57 | `settings-catalog.json` |
| SQL tables / columns | 146 / 5,254 | `realdb-schema-full.json` |
| Defaults / identity columns | 2,355 / 0 | real schema |
| Stored procedures/views/triggers/FKs/check constraints | 0 / 0 / 0 / 0 / 0 | restored database catalog |
| Crystal RPT binaries | 255 | `unified/reports/` |
| Report XML files | 254 | `extraction_output/rpt_xml/` |
| Report-layout specs | 254 | report-layout index |
| Complete / partial / unavailable exact layouts | 253 / 1 / 1 | partial: `SalesQuotation`; unavailable: `TagStkIdtlRpt` |
| Complete+partial report geometry | 2,893 sections; 14,278 objects; 5,991 formulas | report-layout index summary |
| Additional code-referenced but absent reports | 20 | `report-reconciliation.json` |
| Tutorial evidence | 30 transcripts; 1,069 keyframes | `project-memory/video-research/` |

The restored Next23/Next24 databases are seeded templates. They prove schema, defaults, and seed conventions, but not live transaction distributions, production volume, historical anomalies, or customer-specific configuration.

## 3. Product shell and interaction contract

### 3.1 Application shell

The application is a keyboard-first WinForms MDI ERP. The normal title identifies company, company name, financial year, user/branch, and mode. The visible top-menu family is:

`Company · Master · Tran 1 · Tran 2 · Other · Karigar · Reports · Scheme · Dhiran · Mfg · Exit`

Ampersands in extracted captions (`M&fg`, `&Exit`) are mnemonic markers. A context-sensitive left rail exposes submenu actions. The footer/status area exposes theme, live-rate state, fine-gold/fine-silver rates, rate date, and service expiry/end information.

### 3.2 Keyboard semantics

Keyboard behavior is part of parity, not an accessibility enhancement to defer:

- **F1:** context lookup/help; commonly opens `DataCare Help`, and in selected flows opens a related master inline.
- **Enter:** commit the current editor and advance through the desktop field/grid order.
- **Esc:** leave the active grid or jump to totals/tender in transaction screens.
- **Ctrl+Enter:** save in transaction workflows where wired.
- **F2:** ledger report.
- **F3:** stock report.
- **F4:** order workflow/report.
- **F5:** sales workflow/report.
- **F7:** purchase workflow/report.
- **F8/F9:** cash received/payment shortcuts.
- **F11:** Rojmel/day-book.
- **F12:** tag-stock report.

Exact bindings remain form-specific; the 795 extracted key events are the traceable source. Web acceptance must test focus order, lookup invocation, row commit, escape behavior, and save behavior under real keyboard use.

### 3.3 Shared master and voucher chrome

Master screens generally use a left search/list grid and a right edit form, with generated codes and `Print · Save · Cancel · Delete · Exit` actions.

Voucher screens generally include:

- voucher/book number and date/time/day;
- reference number;
- party/account and live money/metal balances;
- book/print-template selection;
- employee, bank, description, credit days, and image where applicable;
- one or more editable MSFlexGrid-style line grids;
- totals and tender fields;
- previous/next navigation;
- save, delete, print, cancel, exit;
- Original/Duplicate/Triplicate print selection.

A generic CRUD page that merely exposes equivalent columns is not desktop parity.

## 4. Tenant, company, branch, year, and book context

The operational business key is not a single surrogate ID. Data is scoped through combinations of:

- `CO_CODE` — company;
- `LC_CODE` — location/branch (`00` commonly denotes company-level rows and `01` the normal location in seeded data);
- `CO_YEAR` — financial year;
- `CO_BOOK` — voucher book;
- `VCH_NO` — app-assigned voucher number.

Voucher uniqueness and reversal must use the complete applicable business key. Numbering is application-assigned per company/location/year/book; the real database has **zero identity columns**. Any web surrogate UUID is supplementary and must not replace desktop keys or sequencing semantics.

Company/year creation seeds masters, settings, books, users, and numbering state. Login selects the company/location/year context. Year transfer and balance transfer are explicit workflows, not just date filters.

## 5. Authorization, locks, and audit behavior

- `LOGIN_MAST` stores users and global update/delete/print flags in the desktop.
- `USER_SET` stores per-main-menu/per-submenu `View · Edit · Delete · Print` rights.
- The MDI shell controls visibility/open permission; transaction forms also enforce edit/delete/print rights.
- Company/year/date locks and book-specific restrictions are application logic because the database has no trigger/check enforcement.
- Period/year restrictions must be checked server-side before any write.
- Desktop delete is a **physical, coordinated reversal/deletion** of header, detail, stock, tax, outstanding, ledger, and other satellite rows, followed by a `DELETE_DATA` audit record. It is not equivalent to deleting only a header or setting `deleted=true`.

The web may improve password storage, session security, and audit immutability, but authorization outcomes and business locks must remain equivalent.

## 6. Accounting and inventory invariants

### 6.1 Money ledger

`AC_DATA` is the primary money ledger. Every posted financial voucher must balance:

`Σ DR_AMT = Σ CR_AMT`

Balance must be checked before commit and all voucher effects committed atomically. `ROJ_MEL_DATA` is a parallel day-book/rojmel representation in relevant flows; it is not safe to assume every report reads only `AC_DATA`.

### 6.2 Gold and silver fine ledger

Metal obligations are represented alongside account activity using `FINE_WT`, `IT_TYPE` (gold/silver), and sign/direction conventions. Reports expose independent debit/credit money, gold, and silver balances. A zero-money karigar issue can still create a material gold liability.

Direction is contextual. The replacement needs named posting primitives such as “karigar owes gold” and “karigar returns gold,” not scattered raw `+`/`-` literals.

### 6.3 Stock

`MAIN_STOCK` is a signed movement journal. On-hand is calculated, not stored:

`onHand = Σ signed ITM_PCS / ITM_GWT / ITM_NWT / ITM_FINE`

Bulk item stock, tagged stock, transferred stock, manufacturing stock, old metal, and approval stock all depend on movement type, sign, tag identity, and book/voucher provenance. A transaction that changes inventory must write a movement; directly updating a balance would violate the desktop model.

### 6.4 Tags and identity

Tagged jewelry carries more than a barcode: item, design, size, counter, pieces, gross/less/net weight, touch/wastage/fine, labour, other amount, MRP, karigar, HUID/hallmark, image, and movement lineage can all matter. Issue/sale must prevent double consumption. Return flows may restore the old tag or create a new tag according to operator choice.

### 6.5 Atomicity and reversal

For any voucher, the required boundary is:

1. validate context, rights, lock date, numbering, stock/tag availability, totals, and account mappings;
2. allocate/reserve voucher number according to the applicable book/year rules;
3. write header/details and all stock, ledger, tax, outstanding, scheme, manufacturing, or device artifacts;
4. verify money and metal invariants;
5. commit as one unit.

Delete/reversal must target the same complete voucher key and undo every satellite effect before recording audit evidence.

## 7. Calculation model

### 7.1 Fine-weight formulas are workflow-specific

The old KB assertion that fine is always `net × touch / 100` is incorrect.

| Context | Observed formula family | Direct evidence/example |
|---|---|---|
| Sales/manufacturing-style line | `(NetWt + GhtWt) × (Touch + West%) / 100` | `TR_SALE.cs` computes grid col 20 from cols 14+17 and 18+19 |
| Purchase/karigar receipt family | `NetWt × (Touch + West%) / 100` in relevant paths | karigar receipt evidence: `65 × (92+0)% = 59.800` |
| Opening/melting input/karigar issue family | `NetWt × Touch / 100` in relevant paths | karigar issue evidence: `100 × 100% = 100.000` |
| More complex karigar/purchase rows | may subtract fine-cut or incorporate less-touch/ghat branches | direct source contains branches; exact runtime selection remains unresolved per form/book |

A shared helper may accept `net`, `ght`, `touch`, `west`, and optional adjustments, but each workflow must explicitly choose the correct policy. One universal helper with defaulted semantics would silently corrupt fine balances.

### 7.2 Weight relationships

Common relationships include gross, less/other, net, ghat, conversion, stone/diamond, and fine weights. The relationship is form- and item-type-specific. For example, source paths compute net from gross minus less weight, but manufacturing and old-metal paths can include ghat, conversion, loss, and fine-cut adjustments.

### 7.3 Amount, labour, tax, and rounding

The desktop supports multiple labour modes (per gram, per piece, percent, fixed and form-specific codes), item/other charges, discounts, GST/VAT, TCS, hallmark tax, cash/card/cheque/UPI/scheme/order/old-metal tenders, kasar, outstanding, and round-off. Group/book/account mappings determine posting accounts.

Rounding is visible at field, line, tax, rate, fine, and voucher levels. Exact behavior may depend on `CO_SET` and `BOOK_DETL`. Do not normalize everything to a single decimal policy until each book's runtime behavior is verified.

### 7.4 Tax regimes

The extracted product contains:

- Indian GST, including CGST/SGST versus IGST;
- TCS and cash/PAN rules;
- hallmark-related amounts/tax;
- e-invoice/e-bill flows;
- UAE VAT variants (`TR_PR_SL_UAE`, `TR_SALE_RTN_UAE`).

Tax acceptance requires printed/report reconciliation, not only arithmetic unit tests.

## 8. Functional domain model

### 8.1 Foundation and administration

- Login, company/location/year selection.
- Company and financial-year creation/seeding.
- Balance/year transfer.
- Voucher books, numbering, account mappings, locks, configuration.
- User creation and per-form rights.
- Settings/main settings, refresh, backup/restore, import/export.

### 8.2 Masters

- Accounts/parties, account groups, addresses, family/photo/bank/GST details.
- Product, group, item, auto-item, item weight/conversion.
- Employee, tax, counter, labour, design, size, location and related lookup masters.
- Daily rates/touch/wastage and posting-account mappings.
- Party, item, and tag opening balances.

### 8.3 Retail, wholesale, purchase, and sales

- Sales, purchase, returns, sales orders, order adjustment/cancel.
- Wholesale sale/return, labour sale, hallmark variants.
- Tour/approval issue, receive, order, and sale.
- Bullion booking/sale, fine sale/purchase, purchase-sale hedging.
- Other purchase/commission and card/bank/cash/contra flows.
- Multi-tender settlement, old-gold/old-silver exchange, scheme/order adjustment, outstanding and credit reminders.

### 8.4 Inventory, tagging, and physical control

- Bulk item and tag opening.
- Tag generation, print, cancel, split, transfer, weight difference and stock adjustment.
- Lot entry, only-tag entry, barcode/QR labels, images, counters and HUID/hallmark attributes.
- Physical stock scanning/reconciliation.
- Stock by group/product/item/design/safe/table/trading and in/out/stock/MRP/approval-pending tag views.

### 8.5 Manufacturing and karigar

- Metal issue and ornament receive with independent money and fine balances.
- Design issue, karigar repair issue/receive, customer repair.
- Manufacturing issue/receive, order issue/receive, with-lot, item production and ghat receipt.
- Melting processes, loss/ghat/fine adjustments and lot provenance.
- Received-product costing, labour, stones/diamonds, tax, barcoding, and karigar settlement.

### 8.6 Finance

- Cash/bank receipt/payment, contra, journal and account opening.
- Bill-to-bill allocation and outstanding.
- Rate cut, fine in/out, location amount transfer and card receipt.
- Bank reconciliation through clearing dates.
- Money, gold, and silver ledger views; rojmel/day book; lock and audit behavior.

### 8.7 Dhiran (pledge loans)

- Pledge/loan issue, receipt, interest receipt, collateral and account effects.
- Interest calculation/configuration semantics are not fully proved and require runtime/business-owner evidence.

### 8.8 Schemes and loyalty

- Membership/savings scheme enrollment and adjustment.
- Installments/redemption and sale linkage.
- Loyalty/points surfaces exist, but the exact accrual trigger and some adjustment semantics remain unresolved.

### 8.9 Reports and printing

The product includes report forms plus 255 Crystal binaries used for invoices, labels, vouchers, ledgers, stock, GST, manufacturing, schemes, loans, reminders, summaries, and operational analysis. Report parity includes:

- selection/filter semantics;
- data query and formula semantics;
- grouping, suppression, sections and pagination;
- fonts, coordinates, borders, images, barcodes/QR and printer behavior;
- Original/Duplicate/Triplicate and template selection;
- PDF and physical-print comparison against the desktop.

Current exact-layout evidence:

- **253 complete** report layouts;
- **`SalesQuotation` partial:** recovered valid prefix with 30 sections, 155 objects, and 34 formulas; XML truncates at line 2908;
- **`TagStkIdtlRpt` unavailable:** older Seagate Crystal OLE report requiring a compatible Windows Crystal reader/runtime;
- **20 referenced report files absent** from all supplied roots; names are listed in `report-reconciliation.json`.

### 8.10 Integrations and devices

Extracted evidence includes:

- barcode/QR printing and scanners;
- weighing scale/serial-device interaction;
- webcam/images;
- WhatsApp automation (ChromeDriver/Selenium/QR signals);
- SMS;
- Firebase/media operations;
- e-invoice/e-bill or external tax-service paths;
- backup/restore and file import/export;
- NextEmp companion surface.

Static code proves integration intent and payload/control paths, not production service behavior. Device protocols, driver compatibility, credentials, rate limits, retry behavior, and failure recovery require live hardware/service testing. A web deployment will likely need a signed local bridge/agent for printers, scales, scanners, cameras, and filesystem/backup operations.

## 9. Representative end-to-end posting contracts

### 9.1 Sale

A sale may consume tagged/bulk stock, calculate item/labour/other amounts, split tax, accept mixed tenders, receive old metal, apply order/scheme amounts, create outstanding, and post group/book-specific accounts. All affected sale detail, tag detail, stock, tax, bill-outstanding, and ledger rows must agree. Deleting the sale must restore consumable tag state and reverse every ledger/tax/outstanding effect.

### 9.2 Purchase

A purchase may receive bulk/tag stock, calculate purchase-side purity/fine and charges, post input tax and supplier liability/payment, and optionally create tags. Purchase fine calculation cannot be copied from sales because ghat/less-touch/fine-cut branches differ.

### 9.3 Karigar issue/receive

Issue example: 100g fine gold at 100 touch creates 100.000 fine stock-out and a 100.000 Dr Gold obligation for the karigar, with no money amount required.

Receive example: 65g ornaments at 92 touch and 0 wastage creates 59.800 fine stock-in, credits 59.800 against the karigar's gold obligation, and can separately create labour plus tax payable. The remaining metal balance is 40.200 Dr Gold. Receipt may also create barcode tags and capture stone/diamond and costing details.

### 9.4 Cash/bank and bill allocation

Cash/bank receipts and payments post balanced `AC_DATA`, header tables, optional kasar, cheque/bank metadata, and bill allocations. A multi-line desktop voucher must remain one voucher. Bill-wise allocation must reconcile the party ledger and `BILL_OS_DATA` rather than independently editing outstanding.

### 9.5 Physical/tag utility

Tag cancel creates stock-out without a money ledger. Tag print is read-only. Tag weight difference can affect both signed stock and karigar metal accounting. Tag transfer must conserve total metal while changing tagged/bulk/item/counter classification.

## 10. Settings and mappings

There are 57 cataloged `CO_SET` keys. Only 15 are directly linked by the current catalog to a form reference; absence from that field does not prove a setting is unused because reads may occur through shared modules or dynamic SQL. `BOOK_DETL` and related tables hold account, print, tax, numbering, and workflow mappings.

The replacement should create a typed setting registry with, for every setting:

- original key and data type;
- company/location/year/book scope;
- default and seed source;
- desktop read/write call sites;
- affected calculation/validation/report;
- migration behavior;
- test vectors.

Unknown mappings must fail closed or require setup; silently substituting generic accounts is not acceptable for production posting.

## 11. Evidence gaps and explicit uncertainties

The following are not safe to infer from current artifacts alone:

1. Exact purchase fine fold-in involving ghat, less-touch, and fine-cut for every book/configuration.
2. Runtime branch selection among multiple karigar fine expressions.
3. Dhiran interest modes and configuration semantics.
4. Some `BOOK_DETL` account mappings and customer-specific seeded choices.
5. Loyalty accrual trigger and reversal details.
6. Average-touch rebuild timing/cadence.
7. VP/gold-book semantics and portions of the melting workflow.
8. Exact configured rounding behavior for each production book.
9. Live-shop data volume, dirty-data patterns, duplicate business keys, and historical corrections.
10. Device/runtime behavior for scale, webcam, label printers, scanners, and service expiry.
11. Live external-service contracts and credentials.
12. Exact layout of `TagStkIdtlRpt` and the 20 absent report binaries.

These gaps become evidence-acquisition work items. They are not permission to simplify the web behavior.

## 12. Desktop parity acceptance contract

A feature reaches desktop parity only when all applicable gates are evidenced:

1. **Extracted:** source/layout/report/schema evidence is available or the gap is documented.
2. **Understood:** fields, focus/key behavior, validation, calculations, mappings, writes, reads, deletion, and reports are specified.
3. **Implemented:** UI, API, database, reporting, security, integration, and operations paths exist.
4. **Tested:** unit, invariant, integration, authorization, concurrency, migration, and failure tests pass.
5. **Desktop-compared:** scripted workflow, screenshots, report PDFs/prints, posting rows, stock, and balances agree with desktop evidence.
6. **Production-certified:** load, backup/restore, observability, security, DR, device/site, and user-acceptance gates pass.

“Route exists,” “table exists,” or “service returns 200” is never sufficient evidence of parity.

## 13. Source index

- Canonical source: `unified/src/csharp/DataCareNext/`
- Schema: `project-memory/catalogs/realdb-schema-full.json`
- Module map: `project-memory/catalogs/module-map.json`
- Behavior: `project-memory/catalogs/form-behavior/`
- Logic: `project-memory/catalogs/form-logic/`
- Layouts: `project-memory/catalogs/layouts/`
- Menu: `project-memory/catalogs/menu-tree.json`
- Settings: `project-memory/catalogs/settings-catalog.json`
- Integrations: `project-memory/catalogs/integrations-scan.json`
- Reports: `unified/reports/`
- Report layouts: `project-memory/catalogs/report-layouts/`
- Report reconciliation: `project-memory/catalogs/report-reconciliation.json`
- Tutorial KB/evidence: `project-memory/video-research/_kb/` and sibling video folders

This baseline is the desktop side of the traceability model. Web status must be derived from current code and executable validation, not copied from older KB parity labels.
