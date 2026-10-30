# Standard edition first — delivery plan (30 October 2026)

The owner's instruction of 30 October 2026: build one edition of DataCareNext completely, to production, before any
other. Standard comes first; it contains Lite and Basic. Ultra, Pro, Advance and Enterprise wait until Standard runs
in production. This is decision D31 ([document 12 §4](12-lineage-verification-2026-10-01.md#4-decisions-d23d28)).

This document changes the **order and scope** of Phase 1 work. It does not replace the slice specifications of
documents 02, 06, 10, 11 and 12, the contracts of document 03, the acceptance rules of document 04 or the definition
of done of [document 13 §1](13-phase1-delivery-plan.md#1-definition-of-done). Status stays in
[`execution-backlog.json`](execution-backlog.json).

## 1. What Standard is, in the desktop

The desktop has seven editions, held in `DC_Main.MsSoftType`: `L` Lite, `B` Basic, `S` Standard, `U` Ultra, `P` Pro,
`A` Advance, `E` Enterprise. The code is the seventh character of the registration serial
(`unified/src/csharp/DataCareNext/MS_OPNCOMP.cs:648`); an unregistered copy runs as Lite
(`unified/src/csharp/DataCareNext/MS_OPNCOMP.cs:612`).

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
since then, so step E1 refreshes the grade of every Standard row from the code and the browser.

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
belong to deferred areas (Dhiran outstanding letter, membership, tour sales, card receipt, customer entry). Step E2
classifies each of the 81 against the desktop before the gate hides anything.

## 3. Setting the deferred code aside without deleting it

The deferred code is working, tested and merged, and the browser lane's suites exercise parts of it. Commenting it out
or deleting it would break the build and the test suites and throw away verified work. It is set aside the way the
desktop itself does it, by edition:

1. **Snapshot branch.** `archive/all-editions-2026-10-30` points at `main` before the gate (`54256eb`), so the full
   multi-edition state can always be recovered as it was.
2. **Edition gate.** One table, generated from `menu-editions.json`, gives each desktop menu and each web route its
   edition. The running edition comes from configuration (`APP_EDITION`, default `S`); per-company licences come
   later with the other editions.
   - Navigation lists only the menus of the running edition (as `MDI_FORM` filters `MENU_DATA`).
   - Opening a deferred route by URL shows "not available in this edition" instead of the screen.
   - The API refuses deferred route families with `403 {error:'edition-unavailable'}`, so a hidden screen cannot be
     reached by calling its API.
   - `/me` reports the edition, and Users & Rights lists only the edition's menus (`MS_USER` has 13 edition tests).
   - Edition branches inside shared screens follow the desktop's `MsSoftType` tests (§1).
3. **Tests stay.** The suites of deferred features keep running in CI with the edition switched on in their fixture,
   so nothing regresses while it waits.

Raising the edition later (Ultra, then Pro, Advance, Enterprise) is a configuration change plus that edition's
verification, not a re-implementation.

## 4. State of Standard on 30 October 2026

- Every web route renders for a signed-in user (UI surface crawl, 241 routes, slice N164 in the browser lane).
- Feature-level E2E coverage exists for one menu: Sales Invoice, 22 cases. On `main` 16 pass, 3 fail with recorded
  gaps and 3 are blocked with reasons; with N162 (the G169 fix, in review) 17 pass and the remaining failures are
  G170 (lost update) and G171 (no Alt+S save).
- Found in the 30 October browser run of Sales Invoice, to be registered as gaps once the browser lane's G172–G175
  are on `main` (gap numbers must stay contiguous):
  - Enter in the voucher-number box does not load the voucher; the desktop loads on Enter and steps to the last and
    first voucher on Up and Down (`unified/src/csharp/DataCareNext/TR_SALE.cs:17068-17096`).
  - The print popup shows `{"error":"unauthenticated"}` once the 15-minute access cookie has expired, because it is
    a plain navigation and cannot refresh the session the way API calls do.
  - The printed invoice's HSN summary rounds each half of the tax separately (1,021.64 + 1,021.64 = 2,043.28) while
    the bill's tax is 2,043.29 and the summary panel shows 1,021.65 twice.
  - The printed date has no year ("Fri Oct 30"); that is N56, waiting for decision D19.
  - Each page load prefetches the roughly 240 navigation routes, and the party lookup sends one balance request per
    keystroke.
- Owner decisions that block production quality on Standard screens, all recommended and not yet accepted (document
  11 §4): **D16** request schemas (N50), **D17** version tokens against lost updates (N51, G170), **D18**
  idempotency keys on financial creates (N52), **D19** date and number formats (N56).
- Desktop-match evidence needs an original-Windows run, which does not exist yet. It stays a separate measure and
  does not block "working in production".

## 5. Delivery plan

The time box the owner set is one to two days. Two lanes run in parallel: **lane A**, implementation, and **lane B**,
the browser and feature E2E lane. Every step follows document 13 §6 and the testing handbook: desktop authority
cited, unit and function tests, a write-set database test for each writer, the feature E2E module for each changed
screen, a browser run through the Chrome DevTools MCP, a pull request with green CI, then merge.

| Step | Lane | Work | Estimate |
|---|---|---|---|
| E0 | A | This plan, decision D31, `menu-editions.json` | 1 h |
| E1 | A | Land N162 (G169) and the Alt+S save (G171); refresh the catalog grade of the 114 Standard rows | 2 h |
| E2 | A | Snapshot branch; edition gate (§3) with its tests; classify the 81 unmapped routes | 3–4 h |
| E3 | A | Voucher-shell defects of §4: Enter/Up/Down on the voucher number, print after session expiry, printed HSN tax, prefetch and lookup request storms | 3 h |
| E4 | B, then A | Feature modules and fixes, sales and purchase family: Purchase, Purchase Rtn, Pr Quotation, Sales Return, Sl Quotation, Sales Order, Order Cancel | 6 h |
| E5 | B, then A | Cash and bank: Cash/Bank Received and Payment, Contra, Bill Wise Rec, Other Income, Other Expenses | 4 h |
| E6 | B, then A | Masters and openings: Party, Item, Group, Tax, Product, Counter, Employee, Item Touch, Labour, Address, AutoItem; Party, Item and Tag Opening | 4 h |
| E7 | B, then A | Tags and stock: Only Tag Entry, Tag Print, Tag Cancel, Tag Transfer, Counter Trfr, Stock Adjust, Physical Stock, Daily Rate | 4 h |
| E8 | B, then A | The 24 Standard reports: modes, filters and totals checked against the vouchers of E4–E7; prints | 6 h |
| E9 | B, then A | Company and admin: Company, Year Create, Year Select, Books, User Create, Account Group, Trade Master, Settings, Data Backup and Refresh, Import and Export, Vch ReNumber, Estimate Reset, Reminder Entry | 5 h |
| E10 | B, then A | The rest of Standard: Karigar and repair (9), Approval Isu and Rtn, Labour Work, Fine Jv, Old Item Sales, VP Parcel and Adjust, Mfg (4), wholesale and bullion (Wh Sales, Wh Quotation, Wh Sl Return, Rate Cut, Sale/Purc Booking, Bul Sales, Bul LcBook), E Invoice, E CrntNote, SMS and WhatsApp, Bank Reconcile, Labour Update | 10–12 h |
| E11 | A | Standard release candidate: full CI and feature E2E on one commit, release certifier dry run, Docker deployment, backup and restore drill, operator walkthrough script | 3 h |

**What fits in the time box.** E0–E3 and E4–E5 fit in the first day; with both lanes running, the second day covers
E6–E8. That gives **Standard RC-1**: the edition gate and the daily shop cycle (sales and purchase family, cash and
bank, masters, tags, the core reports), about 70 of the 114 menus, verified end to end. E9–E11, the remaining
menus and the fixes their suites will find need about three more working days at the measured pace (one full
feature module took about half a day to build with its framework; later modules reuse it). The estimate rests on
that one module and will be revised after E4.

**Order inside each step.** Fix what blocks a business result first (refused saves, wrong postings, lost data), then
lifecycle gaps (reopen, edit, delete, print), then keyboard and layout. A defect the suites find becomes a gap in
document 12 and a baseline entry, and is fixed in its own change.

## 6. Done for Standard

Standard is ready for production when:

1. Navigation, rights and the API expose exactly the 114 Standard menus; deferred routes are refused in the screen
   and in the API (§3).
2. Each Standard menu meets document 13 §1 items 1–4: every desktop mode opens the right screen; the lifecycle the
   desktop allows works; a write-set database test; a feature E2E module whose applicable T01–T18 cases pass or are
   baselined with a recorded gap and a reason; a browser run with evidence.
3. No open gap of severity High on a Standard menu; Medium gaps have an owner decision or a dated plan.
4. Decisions D16–D19 are accepted and their slices (N50 for Standard routes, N51, N52, N56) are done for the
   Standard screens.
5. One candidate commit passes CI, the full feature E2E run and the release certifier dry run; the Docker deployment
   starts from empty; a backup restores (N80 restore milestone); the runbook is written.

Not claimed by this: desktop match (document 04 side-by-side) and parent acceptance, which need the original-Windows
run. They are measured and reported separately, as document 13 §1 already requires.

## 7. Effect on the other plan documents

- **Document 13.** Its definition of done and slice method stay. Its §3 queue is re-ordered by §5 here: slices
  outside Standard (for example N65 Dhiran and loans, N66 schemes, N70 card receipt, tour sales and customer entry,
  N71/N72 manufacturing stages outside the Standard Mfg menus) wait. Platform slices that every edition needs (N48,
  N49, N50–N56, N58–N63, N80, N81, N86) continue, scoped to Standard screens first.
- **Decision D21** (screens outside the menu table) now applies inside the running edition: a book family whose
  menus are not in the edition is deferred even when its books are seeded.
- **Phase 2** is unchanged: it starts after Phase 1 is complete and certified (D28). "Phase 1 complete" now means
  complete for the editions released so far, starting with Standard.
- **The browser lane** builds its feature modules in the order of §5 and runs its surface crawl with the Standard
  edition, so findings land on in-scope menus first.
