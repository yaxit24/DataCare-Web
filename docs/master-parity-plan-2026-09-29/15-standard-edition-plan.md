# Standard edition first — delivery plan (30 October 2026)

The owner's instruction of 30 October 2026: build one edition of DataCareNext completely, to production, before any
other. Standard comes first; it contains Lite and Basic. Ultra, Pro, Advance and Enterprise wait until Standard runs
in production. This is decision D31 ([document 12 §4](12-lineage-verification-2026-10-01.md#4-decisions-d23d28)).

**Confirmed by the owner on 30 October 2026 (evening):** Standard first, and Standard complete: every one of its
114 menus working end to end like the desktop, each verified through the browser with every case a user can meet,
edge cases included. Pilot users wait until Standard is complete. §5 and §6 set out how that is done and measured.

This document changes the **order and scope** of Phase 1 work. It does not replace the slice specifications of
documents 02, 06, 10, 11 and 12, the contracts of document 03, the acceptance rules of document 04 or the definition
of done of [document 13 §1](13-phase1-delivery-plan.md#1-definition-of-done). Status stays in
[`execution-backlog.json`](execution-backlog.json).

## 1. What Standard is, in the desktop

The desktop has seven editions, held in `DC_Main.MsSoftType`: `L` Lite, `B` Basic, `S` Standard, `U` Ultra, `P` Pro,
`A` Advance, `E` Enterprise. The code is the seventh character of the registration serial
(`unified/src/csharp/DataCareNext/MS_OPNCOMP.cs:648`). The edition defaults to Lite, and stays Lite when the serial
carries no known edition code (`unified/src/csharp/DataCareNext/MS_OPNCOMP.cs:612`, `:650-652`); with no registration row
at all the desktop opens its registration screen `UT_HDD` instead (`unified/src/csharp/DataCareNext/MS_OPNCOMP.cs:616-620`).

Editions are cumulative. At start-up the MDI loads the menu table `MENU_DATA` (in the desktop's `NextMain` database)
filtered by the edition's set of `SM_TYPE` codes:

| Edition | `SM_TYPE` loaded | Desktop source | Visible menus |
|---|---|---|---:|
| Lite | `L` | `unified/src/csharp/DataCareNext/MDI_FORM.cs:11296-11299` | 49 |
| Basic | `B`, `L` | `unified/src/csharp/DataCareNext/MDI_FORM.cs:11287-11290` | 78 |
| **Standard** | **`S`, `B`, `L`** | `unified/src/csharp/DataCareNext/MDI_FORM.cs:11278-11281` | **114** |
| Ultra | `U`, `S`, `B`, `L` | `unified/src/csharp/DataCareNext/MDI_FORM.cs:11271-11274` | 114 |
| Pro | `P` and below | `unified/src/csharp/DataCareNext/MDI_FORM.cs:11265-11269` | 148 |
| Advance | `A` and below | `unified/src/csharp/DataCareNext/MDI_FORM.cs:11259-11263` | 158 |
| Enterprise | all | `unified/src/csharp/DataCareNext/MDI_FORM.cs:11249-11257` | 192 |

Counts come from the shipped `NextMain` backup: 192 named menus have `SM_VIEW = 'Y'`, plus 2 blank separators in the
Karigar tab. No row carries `U`, so Ultra shows the Standard menus and differs only in its toolbar. Standard also
hides the Scheme and Dhiran toolbar buttons (`unified/src/csharp/DataCareNext/MDI_FORM.cs:11282-11285`) and the Pro
side-menu section (`unified/src/csharp/DataCareNext/MDI_FORM.cs:11320-11322`).

The per-menu edition list is committed as [`menu-editions.json`](../handbook/menu-editions.json): tab, menu code,
caption, edition and the matching row of the [menu catalog](../handbook/menu-catalog.md). It holds menu
configuration only, no customer data, with the backup's SHA-256 and the query that produced it.

**Edition branches inside shared screens.** A Standard screen can still contain behaviour reserved for higher
editions. Counting `MsSoftType` tests per form: `TR_SALE` 36, `TR_PURC` 15, `TR_WH_SALE` 13, `MS_USER` 13,
`MS_OPNCOMP` 11, `TR_SALE_LBR` 10, `TR_TAG_OPBL` 9, `TR_SALE_RTN` 7, `TR_SALE_ORD` 7. Most switch on an Enterprise or
Advance feature, for example the bill-profit display (`unified/src/csharp/DataCareNext/TR_SALE.cs:14072`) and the
loyalty points of a sale (`unified/src/csharp/DataCareNext/TR_SALE.cs:19284`). In Standard those branches are off.
Each screen's slice lists and tests them.

## 2. Scope

**In scope: the 114 Standard menus.**

| Desktop tab | Menus | Lite | Basic | Standard | Web state (catalog grade, 1 October) |
|---|---:|---:|---:|---:|---|
| Company | 12 | 7 | 4 | 1 | CONTAINED 1, PARTIAL 11 |
| ExtraTran | 10 | 3 | 3 | 4 | PARTIAL 10 |
| Karigar | 9 | 0 | 4 | 5 | PARTIAL 7, REPORT 2 |
| Master | 14 | 11 | 2 | 1 | PARTIAL 14 |
| Mfg | 4 | 0 | 0 | 4 | PARTIAL 1, REPORT 3 |
| Other | 19 | 7 | 6 | 6 | CONTAINED 1, PARTIAL 18 |
| Report | 24 | 10 | 6 | 8 | REPORT 24 |
| Transaction | 22 | 11 | 4 | 7 | PARTIAL 22 |
| **Total** | **114** | **49** | **29** | **36** | |

Per menu, with its edition, catalog grade and web routes:

- **Company:** Company (L; PARTIAL; `/masters/companies`, `/admin/provision`); Year Create (L; PARTIAL; `/masters/year-create`); Balance TrFr (L; PARTIAL; `/company/balance-transfer`); Books (L; PARTIAL; `/masters/books`); User Create (L; PARTIAL; `/admin/users`); Account Group (B; PARTIAL; `/masters/ac-groups`); Trade Master (B; PARTIAL; `/masters/trade`); Setting (B; PARTIAL; `/settings`); Setting Main (S; PARTIAL; `/settings`); Data Refresh (L; PARTIAL; `/utilities/data-refresh`, `/utilities/data-repair`); Data Backup (L; CONTAINED; `/backup`); Year Select (B; PARTIAL; `/select`).
- **ExtraTran:** Approval Isu (L; PARTIAL; `/txn/tour`); Approval Rtn (L; PARTIAL; `/txn/tour-return`); Labour Work (B; PARTIAL; `/txn/labour-sale`); Fine Jv Entry (L; PARTIAL; `/txn/fine-jv`); Old Item Sales (S; PARTIAL; `/txn/old-item-sales`); Bill Wise Rec (S; PARTIAL; `/txn/bill-to-bill`); Other Expenses (B; PARTIAL; `/txn/other-purchase`); Other Income (B; PARTIAL; `/txn/other-income`); Vp Parcel (S; PARTIAL; `/txn/vp-parcel`); Vp Adjust (S; PARTIAL; `/txn/vp-adjustment`).
- **Karigar:** Kr Issue (B; PARTIAL; `/txn/karigar-issue`); Kr Received (B; PARTIAL; `/txn/karigar-receive`); Kr Design Isu (B; PARTIAL; `/txn/mfg-order-issue`); Cust Repar Rec (S; PARTIAL; `/txn/repair-receipt`); Kr Repar Isu (S; PARTIAL; `/txn/repair-karigar-issue`); Kr Repar Rec (S; PARTIAL; `/txn/repair-karigar-receipt`); Cust Repar Isu (S; PARTIAL; `/txn/repair-customer-issue`); Kr Report (B; REPORT; `/reports/karigar-report`); Reparing Rpt (S; REPORT; `/reports/repair-report`).
- **Master:** Party (L; PARTIAL; `/masters/party`, `/masters/accounts`); Address (L; PARTIAL; `/masters/addresses`); Product (L; PARTIAL; `/masters/products`); Group (L; PARTIAL; `/masters/groups`); Item (L; PARTIAL; `/masters/items`); AutoItem (L; PARTIAL; `/masters/auto-item`); Employee (L; PARTIAL; `/masters/employees`); Tax (L; PARTIAL; `/masters/taxes`); Party Opening (L; PARTIAL; `/txn/ac-opbl`); Item Opening (L; PARTIAL; `/txn/item-opening`); Tag Opening (L; PARTIAL; `/txn/tag-opening`); Counter (B; PARTIAL; `/masters/counters`); Labour (S; PARTIAL; `/masters/labour-update`); Item Touch (B; PARTIAL; `/masters/touch`).
- **Mfg:** Mfg Mast (S; PARTIAL; `/masters/mfg`); Lot IsuRec (S; REPORT; `/reports/mfg-lot-isurec`); Mfg Ledger (S; REPORT; `/reports/mfg-ledger`); Mfg InOut (S; REPORT; `/reports/mfg-inout`).
- **Other:** Daily Rate (L; PARTIAL; `/txn/daily-rate`); Only Tag Entry (L; PARTIAL; `/txn/tag-opening`); Tag Cancel (L; PARTIAL; `/txn/tag-cancel`); Tag Print (L; PARTIAL; `/txn/tag-print`); Stock Adjust (L; PARTIAL; `/txn/stock-adjust`); Order Cancel (L; PARTIAL; `/txn/order-cancel`); Reminder Entry (B; PARTIAL; `/utilities/reminder-entry`); Physical Stock (B; PARTIAL; `/txn/physical-stock`); Tag Transfer (B; PARTIAL; `/txn/tag-transfer`); Data Import (L; PARTIAL; `/masters/accounts`); Tag Wt Change (B; CONTAINED; `/txn/tag-weight-diff`); Whatsapp (B; PARTIAL; `/integrations`); Sms (S; PARTIAL; `/integrations`); Labour Update (S; PARTIAL; `/masters/labour-update`); Counter Trfr (B; PARTIAL; `/txn/counter-transfer`); Bank Reconcile (S; PARTIAL; `/txn/bank-recon`); Vch ReNumber (S; PARTIAL; `/utilities/voucher-renumber`); Data Export (S; PARTIAL; `/utilities/data-export`); Estimate Reset (S; PARTIAL; `/utilities/estimate-reset`).
- **Report:** Ledger Report (L; REPORT; `/reports/account-ledger`); Stock Report (L; REPORT; `/reports/tag-stock`); Tag Stock (L; REPORT; `/reports/tag-stock`); Sales Report (L; REPORT; `/reports/sales-register`); Purchase Rpt (L; REPORT; `/reports/purchase-register`); Approval Rpt (L; REPORT; `/reports/approval-report`); Order Report (L; REPORT; `/txn/sales-order`); Cash Bank (L; REPORT; `/reports/cash-book`); Gst Report (L; REPORT; `/reports/gst-report`); Party Os (B; REPORT; `/reports/outstanding`); Final Reports (S; REPORT; `/reports/final-reports`, `/reports/profit-loss`, `/reports/balance-sheet`, `/reports/trial-balance`); Tag Estmate (B; REPORT; `/reports/tag-estimate`); Tag Image (S; REPORT; `/reports/tag-stock`); Trading Report (B; REPORT; `/reports/trading-report`); HuId Report (L; REPORT; `/reports/huid`); Bul Report (S; REPORT; `/reports/bullion-report`); Rojmel (B; REPORT; `/reports/rojmel`); Sale Zoom (S; REPORT; `/reports/sales-register`); Purc Zoom (S; REPORT; `/reports/purchase-register`); Old Stock (S; REPORT; `/reports/old-stock`); Stock With Fine (S; REPORT; `/reports/stock-valuation`); Item InOut (B; REPORT; `/reports/item-stock-ledger`); Address Print (B; REPORT; `/reports/address-print`); Vp Report (S; REPORT; `/reports/vp-report`).
- **Transaction:** Purchase (L; PARTIAL; `/txn/purchase`); Purchase Rtn (L; PARTIAL; `/txn/purchase-return`); Sales Order (L; PARTIAL; `/txn/sales-order`); Sales (L; PARTIAL; `/txn/sales`, `/txn/hallmark-sale`); Sales Return (L; PARTIAL; `/txn/sale-return`); Wh Sales (L; PARTIAL; `/txn/wholesale-sale`); Cash Received (L; PARTIAL; `/txn/receipt`); Cash Payment (L; PARTIAL; `/txn/payment`); Bank Received (L; PARTIAL; `/txn/receipt?mode=BANK`); Bank Payment (L; PARTIAL; `/txn/payment?mode=BANK`); Contra Entry (L; PARTIAL; `/txn/contra`); Rate Cut (B; PARTIAL; `/txn/rate-cut`); Sale Booking (S; PARTIAL; `/txn/bullion`); Purc Booking (S; PARTIAL; `/txn/bullion`); Bul Sales (S; PARTIAL; `/txn/bullion-sale`); Bul LcBook (S; PARTIAL; `/txn/bullion`); E Invoice (B; PARTIAL; `/txn/e-invoice`); E CrntNote (B; PARTIAL; `/txn/e-crnt-note`); Sl Quotation (B; PARTIAL; `/txn/sales-quotation`); Pr Quotation (S; PARTIAL; `/txn/purchase-quotation`); Wh Quotation (S; PARTIAL; `/txn/wholesale-quotation`); Wh Sl Return (S; PARTIAL; `/txn/wholesale-sale-return`).

The catalog grades are those of 1 October. Slices N89–N162 added reopen, edit and delete to many of these screens
since then; each row is re-graded when its menu is done (§5).

**Deferred: 78 menus of Pro, Advance and Enterprise.** They stay in the code, hidden and refused (§3), until
Standard runs in production.

| Desktop tab | Deferred menus (edition) |
|---|---|
| Analysis (8) | Last Visit (P), Stock Ledger (P), Order Zoom (P), Tag Detail (P), Stock Move (P), Delete Data (P), Party InOut (P), Bill Os Day (A) |
| Company (3) | Location (E), Admin Setting (E), Menu Set (P) |
| Crm (2) | Cust Entry (A), Cust Report (A) |
| Dhiran (12) | Dhrn Issue (P), Intrest Rec (P), Dhrn Rec (P), Intrest All (P), Dhiran Report (P), Dhrn Os Letter (P), Dhrn Due (P), Loan Received (P), Loan Intrest (P), Loan Issue (P), Intrest Isu All (P), Loan Report (P) |
| ExtraTran (10) | Consi Rec (P), Consi Purc (P), Consi Isu (P), Card Rec (P), Amt Out (E), Amt In (E), Fine Purc (E), Employee Jv (A), Service Comm (E), Tag Wise Purc (E) |
| Karigar (6) | Stock Isu (E), Tour Order (E), Tour Sales (E), Stock Rec (E), Tour Report (E), Tour Tag (E) |
| Master (7) | Style (A), ItStk Limit (E), Point Mast (E), Labour Disc (A), Labour Type (E), Design Book (E), Diamond (E) |
| More (12) | Order Track (E), Graph Report (E), ItStk Level (E), Bill Wise Profit (E), User Report (E), Point Report (E), Deisgn Move (E), Movement (E), Entry Check (E), Lot Report (E), Emp Sale (E), Oth Itm Rpt (E) |
| Other (4) | Tag Adjust (A), Tag Split (A), Ledger Adjust (A), Stone/Dm-Cf (A) |
| Report (1) | Consi Report (P) |
| Scheme (11) | Scheme Mast (P), Member Mast (P), Memb Opening (P), Memb Entry (P), Memb Adjust (P), Gold Adjust (P), Scheme Report (P), Scheme Ledger (P), Monthly Report (P), Day Sales (E), Branch InOut (E) |
| Transaction (2) | Stock Out (E), Stock In (E) |

Consequences worth stating: the Location master is Enterprise, so a Standard company works in one location; Stock
In/Out between branches, schemes, Dhiran and loans, consignment, tour sales, design book, tag split and tag adjust
are all outside Standard.

**Web routes.** Of the 240 routes in the web navigation (`web/apps/web/lib/nav.ts`), 105 serve a Standard menu and
54 serve only deferred menus. The other 81 match no desktop menu in the catalog: most are report variants and
utilities that belong to a Standard menu's modes (for example the sales reports by party, item and month), and some
belong to deferred areas (Dhiran outstanding letter, membership, tour sales, card receipt, customer entry). Slice
N171 classifies each of the 81 against the desktop before the gate hides anything.

## 3. Standard only; the other editions as Beta

The Pro, Advance and Enterprise code stays in the repository, compiled and tested, and is taken out of the
Standard product the way the desktop does it, by edition (slice N171, gap G183):

1. **Snapshot branch.** `archive/all-editions-2026-10-30` points at `main` before the gate (`54256eb`), so the full
   multi-edition state can always be recovered as it was.
2. **Edition gate.** One generated table gives every desktop menu, web route, rights form and API route family its
   edition, from `menu-editions.json`. The running edition comes from configuration (`APP_EDITION`, default `S`).
   - Navigation and Users & Rights list only the menus of the running edition, as `MDI_FORM` filters `MENU_DATA`.
   - A deferred page opened by URL says it is not part of the Standard edition instead of showing the screen.
   - Its API answers `403 {error:'edition-unavailable'}`, so a hidden screen cannot be used by calling its API.
   - `/me` reports the edition. Edition branches inside shared screens follow the desktop's `MsSoftType` tests (§1).
3. **Beta.** For internal use the deferred editions can be switched on (`APP_EDITION_BETA=1`): their menus appear in
   a separate Beta group, each labelled Beta, and their APIs answer. A Standard deployment has Beta off.
4. **Not commented out.** Commenting the code out would break the build and the test suites that import it, and
   code that no longer compiles decays while the shared posting, tax and numbering code changes for Standard. Hiding
   it gives users the same Standard product.
5. **Tests stay.** The test harnesses build the application without the gate, so the deferred suites keep running
   and nothing regresses while it waits. The gate has its own tests.

Raising the edition later (Ultra, then Pro, Advance, Enterprise) is a configuration change plus that edition's
verification, not a re-implementation.

## 4. State of Standard on 30 October 2026 (evening)

Measured across the 114 Standard menus:

| Measure | Result | Source |
|---|---|---|
| Screen opens and its buttons respond | 113 of 114 (one report page was not in the crawl) | Browser crawl of 241 pages, N164/N170 |
| Voucher menus with create, reopen, edit and delete wired | about 35 of 50 | Scan of the current screen code |
| Menus with a full browser case list | 3: Sales Invoice (23 cases: 17 pass, 3 fail, 3 blocked), Purchase Invoice (21: 16, 3, 2), Company Settings (24, of which 13 apply: 10, 1, 2) | Feature E2E run on `main` (`8146111`), CI job "Real-stack browser journeys" |
| Menus where every case passes | 0 | Same run |
| Menus compared with the running desktop | 0 | No original-Windows run exists |

Open defects on Standard menus, all in document 12:
- **Found by the feature suites:** G169 and G176 (a sale or purchase with items from two groups cannot be saved),
  G170 (a stale second save overwrites the first), G171 (no Alt+S save), G177 (a settings amount limited to presets),
  G178 (the last administrator can remove their own admin role).
- **Found in the 30 October browser run:** G179 (Enter, Up and Down in the voucher number box), G180 (the print
  window after the access cookie expires), G181 (the printed HSN table differs from the bill tax by a paisa), G182
  (request storms).
- **Blocking test cases:** G173 and G174 (no fault injection or settings-variant company in the harness) and G175
  (the negative-weight rule needs the desktop).

Owner decisions still open that Standard needs (document 11 §4): **D16** request schemas (N50), **D17** version
tokens against lost updates (N51, G170), **D18** idempotency keys on financial creates (N52), **D19** date and number
formats (N56). Until they are accepted, the slices that depend on them wait and everything else continues.

## 5. Delivery plan

**One menu at a time, to 100%.** Two lanes work in parallel: lane A implements, lane B builds the browser case lists.
For each Standard menu:

1. **Desktop study.** Read the form's source: every control and key, every mode and book family, every validation
   and its message, every calculation with its rounding stage, every table written, every print and report it feeds.
   Cite the lines.
2. **Case list.** Freeze the feature module's cases (playbook T01–T18): every button and key, every mode, the whole
   lifecycle (create, reopen, unchanged save, edit, delete, print, list), every refusal with proof that nothing was
   written, and the edge cases a user can reach: zero, negative and maximum values, items from two groups,
   inter-state tax, every tender mix, stale edits, double submit, user rights, and the effect on downstream reports.
   Expected values are worked out from the desktop rules, never copied from the web.
3. **Browser run.** Run the module through the real screen on the zero-mock stack. Each failure becomes a gap in
   document 12 and a baseline entry.
4. **Fix.** Fix each defect with unit, function and write-set database tests until every case passes, and remove its
   baseline entry in the same change.
5. **Visual and keyboard check.** Walk the screen with the Chrome DevTools MCP: field order, Enter and F-key flow,
   lookups, print preview, console and network health.
6. **Done.** The menu's catalog row becomes FULL; pull request with green CI; merge.

**Order.** Shared defects first, because each one fixes many screens; then the menus in the order a shop uses them.

| Step | Work | Slices | Lane-hours |
|---|---|---|---:|
| E0 | This plan, D31, `menu-editions.json` | — | done |
| E1 | Sale and purchase with two item groups (G169, G176); Alt+S save (G171) | N162, N163 | 6 |
| E2 | Edition gate with Beta (G183) | N171 | 8 |
| E3 | Voucher number keys, print window, printed HSN table, request storms (G179–G182); last-administrator lockout (G178); editable settings amounts (G177); open-company conflict (G172) | N172–N175, N169, N168, N165 | 12 |
| E4 | Rollback and settings-variant cases in the harness (G173, G174) | N166 | 6 |
| E5 | D16–D19 on Standard routes: request schemas, version tokens (G170), idempotency, dates | N50, N51, N52, N56 | 30 |
| E6 | Sales and purchase family: Sales (with the hallmark mode), Purchase, Sales Return, Purchase Rtn, Sales Order, Order Cancel, Sl, Pr and Wh Quotation | — | 50 |
| E7 | Cash and bank: Cash and Bank Received and Payment, Contra, Bill Wise Rec, Other Income, Other Expenses, Bank Reconcile | — | 30 |
| E8 | Masters and openings: the 14 Master tab menus | — | 20 |
| E9 | Tags and stock: Only Tag Entry, Tag Print, Tag Cancel, Tag Transfer, Counter Trfr, Stock Adjust, Physical Stock, Daily Rate, Tag Wt Change | — | 35 |
| E10 | Reports: the 24 Report tab menus, Kr Report, Reparing Rpt and the three Mfg reports, checked against the vouchers of E6–E9 | — | 45 |
| E11 | Company and admin (12 menus) and utilities: Data Import and Export, Vch ReNumber, Estimate Reset, Reminder Entry, Labour Update, SMS, WhatsApp | — | 40 |
| E12 | The rest: Karigar and repair, Approval Isu and Rtn, Labour Work, Fine Jv, Old Item Sales, VP Parcel and Adjust, Mfg Mast, Wh Sales, Wh Sl Return, Rate Cut, Sale and Purc Booking, Bul Sales, Bul LcBook, E Invoice, E CrntNote | — | 90 |
| E13 | Release candidate: full CI and feature run on one commit, release certifier dry run, deployment from empty, backup and restore drill | N80, N82 (parts) | 10 |

**Estimate.** About 380 lane-hours. The basis is the pace measured on 30 October: lane B wrote three case lists
(68 cases) in about six hours, and fixing one defect class with all its tests and a browser run (G169) took about
two hours. Per menu that is about 5 hours for a voucher screen (case list and fixes), 1 for a master, 1.5 for a
report and 2 for a utility, plus about 70 hours of shared work (E1–E5, E13). With both lanes that is roughly 8 days
of round-the-clock work, or 2 to 3 weeks at a normal working pace. It is re-estimated every week from the number of
menus done; the 30 October estimate of a few days for Standard was too optimistic.

**Progress** is one number: Standard menus done, out of 114. A menu is done when its feature module has no failing
or blocked case and no baseline entry, its writers have write-set tests, and its catalog row is FULL. Every pull
request and the handoff report it.

## 6. Done for Standard

Standard is complete when:

1. Navigation, rights, pages and the API expose exactly the 114 Standard menus; the other editions appear only as
   Beta when switched on (§3).
2. All 114 menus are done (§5): every case passes in the browser, with no failing or blocked case. A case that can
   only be decided by the desktop (for example G175) gets an owner decision on the rule first.
3. No gap is open on a Standard menu.
4. D16–D19 are implemented on the Standard routes.
5. One candidate commit passes CI and the full feature run; the release certifier dry run passes; the deployment
   starts from empty; a backup restores.

Desktop match (the side-by-side comparison of document 04) is measured separately once an original-Windows run
exists; until then the desktop source is the authority for every expected value.

## 7. Effect on the other plan documents

- **Document 13.** Its definition of done and slice method stay. Its §3 queue is re-ordered by §5 here: slices
  outside Standard (for example N65 Dhiran and loans, N66 schemes, N70 card receipt, tour sales and customer entry,
  N71/N72 manufacturing stages outside the Standard Mfg menus) wait. Platform slices that every edition needs (N48,
  N49, N50–N56, N58–N63, N80, N81, N86) continue, scoped to Standard screens first.
- **Decision D21** (screens outside the menu table) now applies inside the running edition: a book family whose
  menus are not in the edition is deferred even when its books are seeded.
- **Phase 2** is unchanged: it starts after Phase 1 is complete and certified (D28). "Phase 1 complete" now means
  complete for the editions released so far, starting with Standard.
- **The browser lane** builds its feature modules in the order of §5, so findings land on Standard menus first.
