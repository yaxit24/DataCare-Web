#!/usr/bin/env python3
"""Generate the per-menu agent prompts from the live menu catalog + hand-written guidance.

Facts (forms, dispatch lines, tables, routes, API, rights, gaps, owners) are read from
docs/handbook/menu-catalog.jsonl on origin/main so they cannot drift from the repo.
Run:  python3 docs/agent-prompts/lite/build.py   (needs a fetched origin/main)
"""
import json, subprocess, pathlib, textwrap

HERE = pathlib.Path(__file__).parent
REPO = HERE.parents[2]  # docs/agent-prompts/lite -> repository root


def git_show(path):
    return subprocess.run(['git', '-C', str(REPO), 'show', f'origin/main:{path}'], capture_output=True, text=True, check=True).stdout


CAT = {}
for line in git_show('docs/handbook/menu-catalog.jsonl').splitlines():
    r = json.loads(line)
    CAT[r['id']] = r
MAIN = subprocess.run(['git', '-C', str(REPO), 'rev-parse', '--short', 'origin/main'], capture_output=True, text=True).stdout.strip()

RIGHTS = 'rights string order = Create, Read, Edit, Delete, Print, List ("-" = the desktop menu does not offer that right)'

# ---------------------------------------------------------------------------------------------------------------
# Hand-written guidance. Keys: num, slug, branch, module, tab/menu (catalog id), pkg, kind, wave, report, mission,
# desk (desktop pointers), web (current web files), scope (must-do), cases (case emphasis), risks, shared, after
# ---------------------------------------------------------------------------------------------------------------
MENUS = [
 dict(num='01', slug='sales-report', branch='feat/lite-sales-report', module='salesReport', cat='Report/Sales Report', pkg='L6',
  kind='BUILD (report) — creates the shared RP_ALL report engine', wave=1, report=True,
  mission='Make Report → Sales Report the desktop `RP_ALL` form in its "Sales Report" caption: every sales variant, every filter, exact totals, drill-down and the SaleReport/SalesWithOrder outputs.',
  desk=['`RP_ALL.cs` is 12,662 lines and serves several menu captions. The **Sales Report** branch is `RP_ALL.cs:7572-7945`. Find how the constructor caption selects the branch, then read only the sales branch plus the shared selectors/filters it calls.',
        'Templates in the repo root / `zip_contents/`: `SaleReport.rpt`, `SalesWithOrder.rpt`, `SaleRtnReport.rpt`, `Gstr_1.rpt` (not yours). XML in `extraction_output/rpt_xml/`.',
        'MAIN_BOOK classification: the sales variants include sales, sales return, wholesale, hallmark, labour sale, old-item sale books. The catalog says "the MAIN_BOOK classification remainder" is open: enumerate which book families the desktop includes per variant from the source, then prove each with a voucher.'],
  web=['API: `GET /reports/sales-register` (`apps/api/src/routes/txn.ts:6277`), `sales-by-party`, `sales-by-item`, `sales-by-group`. Rendered by the generic `app/(app)/reports/[report]/page.tsx` (1,742 lines, **at its size ceiling — do not grow it**).',
       'Reuse: `apps/api/src/modules/reports/` (`reportFilters.ts`, `reportEngine.ts`, `reportPdf.ts`, `reportCsv.ts`, `reportAuthorization.ts`, `reportBind.ts`).'],
  scope=['Create a **shared RP_ALL engine** (selectors: dates, party, book, product/group/item, employee, order-linked toggle, grouping, tab/mode; filter semantics; grouping/zoom) in its own module/directory so that Purchase Rpt (agent 02) and Approval Rpt (agent 03) can reuse it. **Merge this foundation first**: tell the coordinator in your PR when it is reusable.',
         'A dedicated route directory (page ≤ 600 lines + grid + hook + types), as in PR #195\'s `reports/account-ledger/`.',
         'Every sales variant the desktop offers in this caption: register, by party, by item, by group, by employee, order-linked (`SalesWithOrder`), summary — as the source defines them, with the desktop column order and captions.',
         'Drill-down (zoom to the voucher) and print/PDF/CSV for each variant.'],
  cases=['Create the sales through the **Sales Invoice screen** (reuse the setup of `modules/salesInvoice.mjs`): two item groups on one bill, local vs inter-state GST, a sale with old-gold exchange, a hallmark sale, a sale with an order advance, then a **Sales Return** through its screen. Totals reconcile to the vouchers and to the ledger.',
         'Edit one sale, delete one, return one: the report follows each step.',
         'Filters one at a time and in combination; From/To around year boundaries; book filter with two sale books.',
         'Sentinels in another company/location/year/tenant never appear.'],
  risks=['Shared engine: the two sibling agents wait for yours. Keep its public surface small and documented.',
         'As of 2 Nov the Sales Invoice, Sales Return, Purchase Invoice and Purchase Return modules have **empty** baselines (#189 just merged); if a voucher screen misbehaves while you build fixtures, that is a regression to report, not something to code around in the report.'],
  shared=['`apps/api/src/routes/txn.ts` (one-line registration only)', '`rbac/routePolicy.ts`, `rbac/formCatalog.ts`', 'new files under `apps/api/src/modules/reports/` and `apps/web/app/(app)/reports/`']),

 dict(num='02', slug='purchase-report', branch='feat/lite-purchase-report', module='purchaseReport', cat='Report/Purchase Rpt', pkg='L6',
  kind='BUILD (report) — reuses the RP_ALL engine from agent 01', wave=2, report=True, after='Agent 01 (Sales Report) has merged the shared RP_ALL engine. Start the desktop study and case list earlier if you like, but do not write engine code that duplicates it.',
  mission='Make Report → Purchase Rpt the desktop `RP_ALL` form in its "Purchase Rpt" caption.',
  desk=['`RP_ALL.cs:7946-8140` is the purchase branch.', 'Templates: `PurcReport.rpt`, `PurcGroupWise.rpt`, `AcPurcSummRpt.rpt`.',
        'Variants named in the catalog: register, party, item, bill, group, summary. Confirm each from the source.'],
  web=['API: `GET /reports/purchase-register` (`routes/txn.ts:6280`), `purchase-by-party`, `purchase-by-item`; generic report page.'],
  scope=['Reuse agent 01\'s RP_ALL selector/filter/grouping engine. Add only what is purchase-specific (book families: purchase, purchase return, hallmark purchase, other purchase, old-gold purchase — verify from source).',
         'Dedicated route directory; do not grow the generic report page.'],
  cases=['Create purchases through the **Purchase Invoice screen** (setup from `modules/purchaseInvoice.mjs`): two item groups, fine-weight purchase with the fine rule, GST local/inter-state, a purchase return through its screen.',
         'Edit/delete/return and re-run. Group-wise and party-wise totals equal the sum of vouchers.'],
  risks=['Purchase Invoice and Purchase Return have empty baselines on `main` (2 Nov); treat a failing voucher screen as a regression to report, not to work around.'],
  shared=['`routes/txn.ts` (one line)', '`rbac/*`', 'the shared RP_ALL engine from agent 01 (read-only for you unless a bug blocks you)']),

 dict(num='03', slug='approval-report', branch='feat/lite-approval-report', module='approvalReport', cat='Report/Approval Rpt', pkg='L6',
  kind='BUILD (report) — reuses the RP_ALL engine; its data comes from agent 12 (Approval Isu/Rtn)', wave=2, report=True,
  after='Agent 01 has merged the RP_ALL engine, and agent 12 (Approval Isu/Rtn) has merged — the report is only verifiable against approval vouchers made through their real screens.',
  mission='Make Report → Approval Rpt the desktop `RP_ALL` form in its "Approval Rpt" caption: issue, in/out and pending custody by party and item.',
  desk=['`RP_ALL.cs:8141-8365`. Template `AprPan.rpt`.', 'Custody identity to prove: issued − returned − billed = pending, per party and per item, for pieces, gross, net and fine.'],
  web=['API: `GET /reports/approval-report` (`routes/txn.ts:6370`, three data modes); generic report page.', 'Approval write side: `apps/api/src/modules/tour/` (agent 12 is rewriting it — read the merged version).'],
  scope=['The three data modes the web has map to desktop selectors — confirm or correct from source. Add the RP_ALL selectors, grouping, custody reconciliation and the Crystal layout.'],
  cases=['Issue approval through the Approval Isu screen (two parties, tagged and untagged lines, stones), return part, bill part through Sales, then report: pending equals the hand count. Cancel/delete an issue where the desktop allows it and re-run.',
         'Reconcile with the Tag Stock report "approval pending" tab (agent 04) — assert both agree.'],
  risks=['If agent 12 has not merged, do the study and case list only and report "waiting on 12".'],
  shared=['`routes/txn.ts` (one line)', '`rbac/*`', 'shared RP_ALL engine']),

 dict(num='04', slug='tag-stock', branch='feat/lite-tag-stock', module='tagStock', cat='Report/Tag Stock', pkg='L6',
  kind='BUILD (report)', wave=1, report=True,
  mission='Make Report → Tag Stock the desktop `RP_TAG` form: inward, outward, in-stock, MRP, approval-pending and all-tags tabs with desktop filters, columns, totals, sub-details and outputs.',
  desk=['`RP_TAG.cs` is 10,813 lines; the catalog source range is `RP_TAG.cs:3977-4325`. Find the tab/mode radio handling and each query.', 'Templates: `TagStkRpt.rpt`, `CntrTagStkRpt.rpt`, `CntrTagSumRpt.rpt`. Tag image: `TAG_IMAGE_DATA`.',
        'F3 in the desktop opens the Stock Report from many screens (KB_master); not yours — but do not break the shortcut contract.'],
  web=['Page `app/(app)/reports/tag-stock/page.tsx` (209 lines) and API `GET /reports/tag-stock` + `.csv`.', '**The route `/reports/tag-stock` is also mapped to the Stock Report menu (agent 05).** The desktop has two different forms (`RP_STOCK` and `RP_TAG`); keep this page `RP_TAG` only and let agent 05 create a separate route.'],
  scope=['Tabs: inward, outward, in-stock, MRP, approval-pending, all. Filters: date, tag, product, group, plus any the source offers. Full column set and sub-details (stones/components). Excel/PDF/print, tag image.'],
  cases=['Build the tag universe through real screens: **Tag Opening**, a **Purchase** with tags, a **Sale** (tag goes outward), **Tag Cancel**, **Stock Adjust** (when #197 lands), an **Approval Isu** (pending) — then every tab reconciles to the hand count of pieces and weights.',
         'A cancelled tag leaves in-stock; a returned sale tag comes back; an approval-pending tag is not in-stock (verify against source).',
         'Pagination vs totals: totals cover all rows.'],
  risks=['Tag Cancel catalog row lists "the Tag Stock report check" as an open item — your cases close it; tell agent 22.'],
  shared=['`reports/tag-stock/*`', '`routes/txn.ts` (leave alone if the route already exists)']),

 dict(num='05', slug='stock-report', branch='feat/lite-stock-report', module='stockReport', cat='Report/Stock Report', pkg='L6',
  kind='BUILD (report) — new route', wave=3, report=True,
  mission='Make Report → Stock Report the desktop `RP_STOCK` form: stock summarised by group, product, item, design, safe, table or trading dimension, with gross-weight options and drill-down.',
  desk=['`RP_STOCK.cs` (6,407 lines); catalog range `RP_STOCK.cs:4277-5160`. Template `ItmStkBalance.rpt`.', 'Stock truth in this system is `MAIN_STOCK` signed movements (`ITM_SIGN`); on-hand = Σ signed movement; fine = net × touch / 100. Read `modules/stock/stock.ts` `onHandNet()` and the `_kb/KB_other.md` primitives.'],
  web=['Today the menu is mapped to `/reports/tag-stock` (the Tag Stock form). The catalog says: "Tag Stock is not RP_STOCK". Create a **new route** (e.g. `/reports/stock-report`) and change the catalog row\'s `ui` and the nav entry accordingly; classify it in `web-route-editions.json`.'],
  scope=['All summary dimensions the source offers, gross-weight options, drill-down to the movements/tags, print/PDF/CSV.'],
  cases=['Stock built through screens: Item Opening, Tag Opening, Purchase, Sale, Sales Return, Purchase Return, Stock Adjust (#197), Tag Cancel. After each, the summary equals Σ signed movements by hand.',
         'Fine and weight columns, loss/ghat weights where the source shows them, opening vs closing for a date range.'],
  risks=['Touches nav (`lib/nav.ts`) and the catalog `ui` of two menus: rebase carefully if agent 04 changes the same row.'],
  shared=['`lib/nav.ts`', '`docs/handbook/menu-catalog.jsonl` rows of Stock Report and Tag Stock', '`web-route-editions.json`']),

 dict(num='06', slug='cash-bank-report', branch='feat/lite-cash-bank-report', module='cashBankReport', cat='Report/Cash Bank', pkg='L6',
  kind='BUILD (report)', wave=2, report=True,
  mission='Make Report → Cash Bank the desktop `RP_CASH_BANK` form (cash/bank book, and the scheme/pending/member modes where the Lite edition shows them) with drill-down into the account movements.',
  desk=['`RP_CASH_BANK.cs` (4,813 lines); catalog range `RP_CASH_BANK.cs:2084-2357`. Templates `RojMelCash.rpt`, `AcLedger.rpt`, PassBook layouts.', 'Tables include `AD_DATA`/`AD_MEMB` (scheme members): **decide from the source whether the Lite edition shows those modes** (edition `MsSoftType`, `MDI_FORM.cs:11236-11330`); if not, record those cases N/A with that citation before running.'],
  web=['API `GET /reports/cash-book` (`routes/txn.ts:6696`) → `cashBook(...)`; generic report page.'],
  scope=['Cash vs bank selection, opening/closing, day-wise vs summarized, the pending mode, drill-down to the account ledger (agent 21 audits the Ledger Report; link, do not rebuild), print/PDF/CSV.'],
  cases=['Vouchers from the existing **cash-bank** module setup: Cash Received/Payment, Bank Received/Payment, Contra (note G37 open), a cheque with and without a bank, a sale with cash tender. Opening balance carried from a previous year.',
         'Edit/delete a voucher and re-run; closing balance equals opening + Σ receipts − Σ payments by hand.'],
  risks=['G229 (date outside the year) was just fixed on main; assert the report never shows an out-of-year voucher.',
         'The Contra module baseline holds `contra.report.contra-register` (G37): the Contra register report is known-broken. Your Cash Bank cases involving Contra will meet it. Record the overlap in your PR and do not fix the register unless it blocks you (then a separate commit).'],
  shared=['`routes/txn.ts` (one line)', '`rbac/*`']),

 dict(num='07', slug='gst-report', branch='feat/lite-gst-report', module='gstReport', cat='Report/Gst Report', pkg='L6',
  kind='BUILD (report)', wave=3, report=True,
  mission='Make Report → Gst Report the desktop `RP_GST` form (non-UAE): the GST registers, summaries, returns and CSV outputs, exact grids and exact CSV.',
  desk=['`RP_GST.cs` (3,944 lines). The UAE edition uses `RP_TAX.cs` (2,405 lines) — **out of scope for Lite**; the dispatch is `MDI_FORM.cs:8951-8971`. Templates `Gstr_1.rpt`, `Gstr_2.rpt`.', 'Tables: `TAX_DATA`, `TAX_MAST`, `BOOK_DATA`, `AC_MAST`, `LOCT_MAST`. The HSN table and printed HSN tax split were fixed in N174 — reuse it.'],
  web=['Today a **launcher** over reports: `GET /reports/gst-report` (`modules/reports/gstLauncherReport.ts`, 62 lines), `gstr1`, `gstr2`, `gstr3b`, `hsn-summary`.'],
  scope=['Replace the launcher with what `RP_GST` actually shows and exports. Prove every mode and the CSV byte layout (column order, number format, date format, empty-value convention).'],
  cases=['Sales and purchases through their screens covering: local (CGST/SGST), inter-state (IGST), exempt/zero-rated, a return/credit note, HSN split, B2B vs B2C, GST on labour/making, TCS where relevant, different tax rates in one bill. GSTR-1/2/3B totals tie to the vouchers and to `TAX_DATA`.',
         'Period filters, a voucher edited after the return period, deleted voucher.'],
  risks=['Money-critical: statutory output. Every number must be hand-computed. Anything the source does not settle is a blocked case, not an assumption.'],
  shared=['`routes/txn.ts` (one line)', '`modules/reports/gstLauncherReport.ts`']),

 dict(num='08', slug='huid-report', branch='feat/lite-huid-report', module='huidReport', cat='Report/HuId Report', pkg='L6',
  kind='BUILD (report)', wave=2, report=True,
  mission='Make Report → HuId Report the desktop `RP_HUID` form: tags by HUID status across stock, inward, outward and all views with the TagHuIdRpt layout.',
  desk=['`RP_HUID.cs` (2,731 lines); catalog range `RP_HUID.cs:1752-2189`. Tables `BAR_DETL`, `TAG_STOCK_PRINT`.', 'PR #23 already added the HUID filters (G13/N43); read what it did before changing anything.'],
  web=['`GET /reports/huid` → `modules/reports/huid.ts` (207 lines).'],
  scope=['Exact tabs, the remaining filters, the columns and the TagHuIdRpt layout.'],
  cases=['Tags with and without HUIDs through **Tag Opening** and a hallmark **Purchase**; sell one, cancel one, return one; tabs stock/inward/outward/all agree. HUID uniqueness behaviour if the source enforces it.'],
  risks=['The TagHuIdRpt template may not be in the repository: if so the layout case is **blocked with that reason**.'],
  shared=['`modules/reports/huid.ts`', '`routes/txn.ts` (leave alone)']),

 dict(num='09', slug='party-master', branch='feat/lite-party-master', module='partyMaster', cat='Master/Party', pkg='L2',
  kind='BUILD (master) — follow the Address master (#192) as the template', wave=1,
  mission='Make Master → Party the desktop `MS_ACCT` screen: one rich screen for customer, supplier, karigar and bank accounts, with contacts, tax and bank data, photo/family, inline opening balance, delete and print.',
  desk=['`MS_ACCT.cs` is 9,651 lines: Load `:5584`, Clear `:6134`, Display `:6356`, Print `:6689`, **Save `:7650`**, **Delete `:7963`**, image buttons `:8181-8394`, `BtnAdd :8501`, `BtnMemb :8538` (membership — verify if visible in Lite), `BtnAcimp :9024` (account import — belongs to **Data Import**, agent 19, not you).',
        'Account groups (`AC_GROUP`): 05 Vepari (supplier), 10 Karigar, 20 Customer, etc.; system accounts 00001–00010; `AC_CODE < 100` company-level (`LC_CODE=00`), `>= 200` location-level (`_kb/KB_master.md` §3).',
        'Opening balance lives in `OP_DATA` (amount, Cr/Dr, gold fine, silver fine) — the **Party Opening** menu is a separate screen that already has a green module (`partyOpening.mjs`); the inline opening box on Party must write the same rows.'],
  web=['`app/(app)/masters/party/page.tsx` (313 lines, "rich" page) and the generic `/masters/accounts` through `masters/[name]` + `AC_MAST_CONFIG`. API: `modules/masters/party.ts` (86 lines), `GET /party/:acCode/family`, photo `GET|POST /party/:acCode/photo`, `GET|POST /accounts/:acCode/opening`.',
       'Catalog gap: "the rich party page ignores duplicate-detail updates and lacks delete and print; capabilities are split across two routes." **Other menus also map to `/masters/accounts`** (Data Import): do not remove that route; make `/masters/party` the complete screen and say what `/masters/accounts` remains for.'],
  scope=['Everything the Address master (#192) did, for MS_ACCT: tabs, next code, combos/helps, name type-ahead, mobile check, duplicate/exists question, leave-checks, desktop keys, Save replaces the row with the signed-in user, Delete with its guards (account used in vouchers/opening → refused; the exact texts) and cascade, Print.',
         'Photo/family tabs, GSTIN/PAN/Aadhaar format checks the source performs, credit days, interest %, DPC %, bank block.',
         'Inline opening balance and its relation to the Party Opening menu.'],
  cases=['Create one party of each group (customer, supplier, karigar, bank); open each from the sale/purchase/karigar/cash screens\' party lookups and prove the new party is selectable and posts.',
         'Refuse delete of a party with vouchers; allow delete of an unused one with its opening rows.',
         'Rights by menu caption "Party" (G225 aliasing).'],
  risks=['Highest blast radius of the masters: every voucher references `AC_MAST`. Re-run the sales/purchase/cash-bank modules at the end to prove nothing regressed.'],
  shared=['`lookupEnter.ts`', '`rbac/formCatalog.ts`', '`masters/configs.ts`', '`routes/txn.ts` (one line)']),

 dict(num='10', slug='tag-print', branch='feat/lite-tag-print', module='tagPrint', cat='Other/Tag Print', pkg='L3',
  kind='BUILD (utility with print output)', wave=1,
  mission='Make Other → Tag Print the desktop `UT_TAG_PRINT` screen: select in-stock tags by tag, product or voucher and reprint barcode and QR labels with the shop\'s label layout.',
  desk=['`UT_TAG_PRINT.cs` is 6,267 lines (the class constructor is still named `TR_TAG_CAN_Load` at `:4735` — a copy artefact). Clear `:5014`, Save `:5073`, Delete `:5097`, **Print `:5122`**, Cancel `:5227`, **`BtnTagSet_Click :5636`** (layout/settings), `BtnRfid_Click :6008` (RFID — decide from source/edition if it is Lite).',
        'Tables `TAG_PRINT_DATA`, `PRINT_MAST` (label variants), `BAR_DETL`, `BAR_IDTL`, `MAIN_STOCK`. Rights `----PL`.'],
  web=['Page `txn/tag-print/page.tsx` (171 lines). API `GET /stock/tag-print`, `POST /stock/tag-print/stage`, `GET /stock/tag-print/label`. "Basic label sheets work".'],
  scope=['Selection by tag no., product, voucher (and any other mode in the source); `PRINT_MAST` variants; label skip; dimensions, fonts; barcode and QR content; count/copies; what the desktop writes to `TAG_PRINT_DATA`.',
         '**Printer reality:** device fakes are allowed for engineering tests (D29). Prove the generated label data/PDF/ZPL (or whatever the source emits) byte-for-byte for known tags; physical-printer acceptance stays **pending** — write it as a blocked case with that reason, never as passed.'],
  cases=['Tags from Tag Opening/Purchase; select by each mode; the label content equals the tag fields by hand (tag no., item, weights, rate/MRP, HUID, barcode text); skip/count behaviour; empty selection refusal text; cancelled/sold tags excluded or included as the source says.'],
  risks=['Printing is the one place the browser cannot fully verify; be exact about what is proven.'],
  shared=['`routes/txn.ts` (one line)', '`modules/stock/*` (shared with agents 11, 22)']),

 dict(num='11', slug='order-cancel', branch='feat/lite-order-cancel', module='orderCancel', cat='Other/Order Cancel', pkg='L3',
  kind='BUILD (voucher)', wave=1,
  mission='Make Other → Order Cancel the desktop `TR_SL_ORD_ADJ` voucher (book `ORDER CANCEL`): a multi-order adjustment voucher that cancels pending sales orders and refunds the advance through a chosen cash/bank account.',
  desk=['`TR_SL_ORD_ADJ.cs` is 4,169 lines: Load `:2852`, Clear `:3110`, Display `:3184`, **Save `:3410`**, **Delete `:3726`**, **Print `:3794`**, First/Last `:4015/:4044`. Grid columns (KB_other §5.3): `Sr | OrdNo | AcCode | Ac Name | It Desc | OrdAmt | AdjAmt | KsarAmt | PaidAmt | PaiidAc | Paid Ac Name`.',
        'Tables `SL_ORD_ADJ` (voucher), `SL_ORD_DATA/DETL`, `AC_DATA`, `ROJ_MEL_DATA`, `APR_DETL`, `MAIN_STOCK`. Slice N37 / gap G07 describe the mismatch.'],
  web=['Page `txn/order-cancel/page.tsx` (280 lines) calls `POST /sales-orders/:vchNo/cancel-refund` — a **per-order void**, not the desktop\'s voucher. Refund/kasar accounts already resolve from `BOOK_DETL` (N155).'],
  scope=['A real voucher: book chooser, voucher no., date/time, a **multi-row grid** of orders, AdjAmt/KsarAmt/PaidAmt bounds as the source checks them, paid account F1 help, ledger + Rojmel + stock/tag release postings exactly as the source writes them, reopen/edit/delete/print/First/Last/list, version tokens, rights.',
         'Keep the existing single-order endpoint working only if something still uses it (grep first); otherwise replace it.'],
  cases=['Create sales orders through the **Sales Order screen** with advances by cash, by bank, by cheque; cancel one, several in one voucher, a partially adjusted one; refund equals advance − kasar; ledger and day book balance; tags/stock reserved by the order are released.',
         'Refusals: already cancelled, already invoiced, AdjAmt > OrdAmt, missing paid account — exact texts, no write.',
         'Delete the cancel voucher: the order returns to pending and every posting is reversed.'],
  risks=['The Sales Order module still carries one baselined defect, `sales-order.create.tender-modes` (G206). Read it so you do not trip over it, but do not fix it in this PR unless it blocks you (then a separate commit).'],
  shared=['`modules/sales/salesOrder.ts` (2,372 lines, at ceiling — do not grow; new code goes in a new file)', '`routes/txn.ts` (one line)']),

 dict(num='12', slug='approval-land', branch='feat/lite-approval-land', module='approvalIssue / approvalReturn', cat='ExtraTran/Approval Isu', pkg='L4',
  kind='LAND EXISTING WORK — not a fresh build (covers BOTH Approval Isu and Approval Rtn: one form, one writer, one branch)', wave=1,
  mission='Approval Isu and Approval Rtn are the desktop `TR_APR_ISU` form on the `APR ISU` and `APR RTN` books. A previous session built most of it and **never pushed it**. Your job is to land it safely: recover, rebase, verify, fix what the rebase and a fresh run expose, and open the PR.',
  desk=['`TR_APR_ISU.cs` is 8,294 lines: Load `:5355`, Clear `:5697`, Display `:5788`, **Save `:6007`**, **Delete `:6608`**, Print `:6712`, First/Last `:7253/:7282`. Dispatch `MDI_FORM.cs:8300-8305` (issue) and `:8312-8317` (return).',
        'Tables `APR_DATA`, `APR_DETL`, `APR_IDTL`, `MAIN_STOCK`, `BAR_DETL`, `DM_DATA`. The business keeps ownership: issue moves tags to "approval", return restores availability, billing a part through Sales consumes it.'],
  web=['**Recovery source:** local worktree `~/dc-wt/lite-approval`, branch `feat/lite-approval` @ `a9f68b85`, **31 commits ahead of origin, not on the remote**, 13 behind main. It contains `modules/tour/approval*.ts`, `routes/approval.ts`, `sales/approvalSaleReferences.ts`, a DB migration, `approvalLifecycle.routes.db.test.ts` (2,229 lines) and three feature modules (`approvalIssue.mjs`, `approvalReturn.mjs`, `approvalHelpers.mjs`). Its records use **N211/G224, which `main` now uses for the Employee master** — renumber.',
       'Pages today: `txn/tour/page.tsx` (issue) and `txn/tour-return/page.tsx`. Main\'s catalog still says "Create-only shared Tour page … reopen/edit/delete/print and the partial sale/return custody chain remain".'],
  scope=['**Do not work inside `~/dc-wt/lite-approval`** (it is another session\'s tree; check `session_status.py` shows no live session on it). Treat it as a read-only source of commits.',
         '**Recovery recipe (tested on 2 Nov against `origin/main` @ `c6101aeb`).** That branch also carries older Item Opening and Tag Cancel commits that are already on `main` under other hashes, so do **not** rebase it. Exactly **24** commits carry `(N211, G224)`. Use a fresh branch from `origin/main` and cherry-pick only those: `git worktree add ~/dc-wt/approval-land -b feat/lite-approval-land origin/main`, then `for c in $(git log --reverse --format=%h --grep "(N211, G224)" a9f68b85 ^origin/main); do git cherry-pick $c || break; done`. The first commit (`8ece8aa8`) conflicts **only in record and registration files**, not in code: `menu-catalog.jsonl`, `menu-catalog.md`, `standard-progress.md` (regenerate), doc 12, `execution-backlog.json`, `routes/txn.ts` (registration lines), `routePolicy.test.ts`, `coverage-map.json`, `run-features.mjs`, `size-budget.json`. Resolve those by keeping both sides, then renumber ids and regenerate generated files. Later commits may conflict in `schema.prisma`, `kernel-conformance-baseline.json`, `depth-parity-baseline.json`.',
         'Check the migration: new timestamp ordering after the latest on main, checksum pin, idempotent on a database that already has approval rows.',
         'Then do the normal method on the result: re-read the desktop source against what was built (its own commit messages list "audited guarantees and gaps" — read them and verify, do not trust them), run `approvalIssue` and `approvalReturn` and `salesInvoice` (it was edited too), fix failures, renumber ids, regenerate generated files, gates, PR.',
         'Cover **both menus**: issue lifecycle (create/reopen/unchanged save/edit/delete/print/list/First-Last), return lifecycle, partial sale/return custody chain, the `APR ISU` / `APR RTN` book enforcement, dependency reversal (cannot delete an issue with a return or a bill).'],
  cases=['Keep the previous session\'s case list as the starting point and **extend** it with the T-groups it lacks (T11 rights by caption "Approval Isu"/"Approval Rtn" — G225 aliases were added on main; T12 two-session race on the same tag; T13 retry; T14 rollback per table).',
         'Downstream: Tag Stock approval-pending tab (agent 04) and Approval Rpt (agent 03) must agree with your vouchers — leave them a clear fixture recipe in the PR.'],
  risks=['Biggest merge in the batch (66 files, +12.6k lines). Land it **first**; agents 03, 04 and 22 wait for or consume it.',
         'It edits `salesInvoice.mjs` and `tagCancel.mjs`: expect conflicts with PR #197 (Stock Adjust) and the Wh Sales follow-up.'],
  shared=['`prisma/schema.prisma` + migrations', '`size-budget.json`', 'baseline JSONs under `web/parity/`', '`salesInvoice.mjs`, `tagCancel.mjs`', 'catalog rows of both menus']),

 dict(num='13', slug='books', branch='feat/lite-books', module='books', cat='Company/Books', pkg='L5',
  kind='BUILD (master with wide blast radius)', wave=3,
  mission='Make Company → Books the desktop `MS_BOOK` screen: voucher series definitions — 3-digit book code, `MAIN_BOOK` family, direction, and the posting-account slots in `BOOK_DETL`.',
  desk=['`MS_BOOK.cs` is 3,122 lines: Load `:1900`, Clear `:2434`, Display `:2468`, Print `:2570`, **Save `:2579`**, **Delete `:2687`**.', 'Tables `BOOK_DATA`, `BOOK_DETL`. Every posting kernel resolves accounts through the slots (the N106–N158 literal sweep moved them there), so slot semantics are the contract between this screen and every voucher.',
        'Catalog gaps: slot semantics, desktop 3-digit codes, branch cloning, reference guards, Print, family-filtered behaviour.'],
  web=['Generic `masters/:name` CRUD at `/masters/books` (`masters/configs.ts`). Provisioning seeds ~41 books (`ops/seedCompany.ts`: SL, SRT, SOR, PR, RCT, PAY, CON, JV, TSP, …).'],
  scope=['Per `MAIN_BOOK` family: which slots exist, what each slot means (cash/bank/income/expense/tax/labour/round-off/kasar/gold/silver DR/CR …), which are mandatory, the account lookup filters, the family-filtered book list, code format, next code, default/in-use flags.',
         'Reference guards: refuse changing a family or deleting a book that has vouchers; the exact texts. Branch cloning (`LC_CODE`). Print.',
         'A page ≤ 600 lines; slot grid as a component.'],
  cases=['Create a book of each Lite family through the screen, then **create a voucher on it through the voucher\'s own screen** and assert the posting went to the slot accounts you configured (this is the real test). Change a slot account, post again, assert the new account is used and the old voucher unchanged.',
         'Delete refused with vouchers; provisioned books still match after the page change.',
         'Rights by caption "Books".'],
  risks=['A wrong slot silently posts to the wrong ledger. At the end re-run `salesInvoice`, `purchaseInvoice`, `cashBank`, `contraEntry`, `salesOrder`, `tagCancel`.'],
  shared=['`masters/configs.ts`', '`ops/seedCompany.ts`', '`posting/*` (read, do not modify)']),

 dict(num='14', slug='year-create', branch='feat/lite-year-create', module='yearCreate', cat='Company/Year Create', pkg='L5',
  kind='BUILD (company utility)', wave=3,
  mission='Make Company → Year Create the desktop `MS_YEAR` screen: create a financial year by copying the baseline masters (the desktop\'s 17-table copy) and optionally carry balances.',
  desk=['`MS_YEAR.cs` is 1,596 lines: Load `:759`, Display `:899`, Print `:961`, **Delete `:970`**, Cancel `:993`, **Save `:1140`**; the 17-table copy is **`NewCompParmCreat :1504-1595`** (also the source for Company, agent 16).',
        'Tables `YEAR_MAST`, `AC_GROUP`, `AC_MAST`, `BAL_GR`, `BOOK_DATA`, `BOOK_DETL`, `CO_SET`, `TAX_MAST`. Rights `C----L`.',
        'N90 removed a web-only year close/reopen that rewrote `CL_DATE`: do not reintroduce it.'],
  web=['Page `masters/year-create/page.tsx` (238 lines); API `modules/masters/year.ts` (172 lines): `GET|POST /years`, `POST /years/carry-forward`. Year-end: `modules/ops/yearEnd.ts` (280 lines).'],
  scope=['The 17-table copy and the year identity convention, exactly; the delete (and what blocks it); Print; the messages. Branch-safe carry-forward.',
         'Hand the carry-forward **content** (stock, orders, approvals, …) to agent 15 (Balance TrFr); here prove only what `MS_YEAR` itself does.'],
  cases=['Create year 2 from year 1 with vouchers present; every copied table has exactly the desktop rows (compare with a hand list), nothing copied that the source does not copy; year selector offers both years; vouchers dated in year 2 post to year 2.',
         'Duplicate year refused; delete refused when vouchers exist; locks and `CL_DATE` unchanged; second tenant untouched.'],
  risks=['Company/Year identity keys appear in every table: a wrong copy corrupts the new year silently. Diff the **whole tenant** before and after.'],
  shared=['`ops/seedCompany.ts` (shared copy logic with agent 16 — whoever merges first extracts it)', '`ops/yearEnd.ts`']),

 dict(num='15', slug='balance-transfer', branch='feat/lite-balance-transfer', module='balanceTransfer', cat='Company/Balance TrFr', pkg='L5',
  kind='BUILD (company utility, money-critical)', wave=4, after='Agent 14 (Year Create) has merged.',
  mission='Make Company → Balance TrFr the desktop `BtmSchm` screen (`MS_BAL_TRFR`): carry the closing balances of every Lite-visible dataset into the next financial year.',
  desk=['`BtmSchm.cs` is 5,638 lines: Load `:1929`; one button per dataset — `BtnAcBalence :2724` (accounts), `BtnItmStk :2921` (item stock), `BtnTagStock :2169` (tags), `BtnOrder :3003` (sales orders), `BtnApr :4116` (approvals), `BtnDhrn :3602`, `BtnLoan :3859`, `BtnTimeLdr :4871`, …',
        '**First classify every button by edition**: Dhiran, loan, scheme, lot and manufacturing buttons belong to menus outside Lite. Record each as N/A *with the source citation that hides it in Lite* before running; carry only what Lite data can contain. Tables listed in the catalog: `OP_DATA`, `AC_DATA`, `ITM_OPBL`, `BAR_DETL`, `SL_ORD_DATA`, `APR_DATA`, `DHRN_DATA`, `LOT_DETL`.'],
  web=['Page `company/balance-transfer/page.tsx` (326 lines); API `POST /balance-transfer/preview|year-close|openings`. Today only account and party openings are carried; stock, order, approval… are missing; no Print; no interruption recovery.'],
  scope=['Each Lite-relevant dataset: preview (what will be carried), execute, idempotency (second run refused or no-op as the source says), interruption recovery (fault after table k → complete rollback or resumable), and print.'],
  cases=['**Closing = Opening identity.** In year 1 create: sales, purchases, receipts/payments, contra, item and tag openings, tag sales/cancels, a pending sales order, an approval issue. Carry. In year 2 the party balances (money, gold fine, silver fine), item stock (pcs/gross/net/fine), tag stock, pending orders and approvals equal year 1\'s closing **by hand count**.',
         'Carry twice, carry with a locked year, carry into a year that already has vouchers.'],
  risks=['If it is wrong the shop starts the year with wrong balances. No case may be inferred; blocked is better than guessed.'],
  shared=['`ops/yearEnd.ts`', '`routes/txn.ts` or the balance-transfer route file']),

 dict(num='16', slug='company-master', branch='feat/lite-company-master', module='companyMaster', cat='Company/Company', pkg='L5',
  kind='BUILD (admin screen; tenancy-sensitive; has a destructive action)', wave=3,
  mission='Make Company → Company the desktop `MS_COMPANY` screen: create the company identity (state, work type, metal type, GST, bank, e-invoice settings) and seed its year, masters and settings.',
  desk=['`MS_COMPANY.cs` is 7,615 lines: Load `:5397`, Clear `:5756`, Display `:5882`, **Save `:6042`**, **Delete `:6254-6776` (≈500 lines)**, Print `:6776`; e-invoice/URL sub-forms `:7406-7555`. The 17-table seed copy is `NewCompParmCreat` (`MS_YEAR.cs:1504-1595`, shared with agent 14). UAE-specific parts (`BtnExitUae`) are out of Lite.',
        'Tables `CO_MAST`, `CO_SET`, `CO_SET_NEW`, `AC_GROUP`, `BOOK_DATA`, `LOCT_MAST`, `MENU_DATA`.'],
  web=['Generic `/masters/companies` and `/admin/provision` (`ops/seedCompany.ts`, 850 lines; `POST /admin/companies/:coCode/provision`). The web has a tenant model the desktop does not (RLS, `tenant_id`).'],
  scope=['The detail form with every conditional field; Save validations and texts; the seeded set (compare with the desktop copy table by table); Print; the edit rights (admin-only: the Company menu grants admin — see G225 "not closed" list).',
         '**Delete:** the desktop deletes a company\'s data with a long cascade. In a hosted multi-tenant system an equivalent is unsafe (D25, G80). Do **not** port the cascade. Implement only a guarded behaviour the source plus an accepted decision supports; otherwise record it as a blocked case and ask the owner.'],
  cases=['Provision a fresh company through the UI end to end and compare the seeded rows to the desktop list; log in to it; create one voucher in it. Second tenant\'s data untouched (diff before/after). Edit the company; reopen; unchanged save.',
         'Duplicate code/name refused with the desktop text; GST/PAN formats.'],
  risks=['Tenant-provisioning code is the foundation of everything: keep the change small, test the whole-tenant diff, never run against a database with real data.'],
  shared=['`ops/seedCompany.ts` (shared with agent 14)', '`admin/provision` page', '`masters/configs.ts`']),

 dict(num='17', slug='data-refresh', branch='feat/lite-data-refresh', module='dataRefresh', cat='Company/Data Refresh', pkg='L5',
  kind='BUILD — scope DECIDED 2 Nov (owner-delegated): the 6 operator-visible buttons only', wave=3,
  mission='Make Company → Data Refresh the desktop `MS_UPDATE` screen **as an operator sees it**: six repair buttons, each running a preview-first, single-transaction, audited repair. The vendor-only tools the desktop hides behind a secret key are out of scope.',
  desk=['`MS_UPDATE.cs` is 33,074 lines but **an operator sees only six buttons**. All the others are `Visible = false` in the designer (`:1535-1986`) and are revealed only by the secret **Ctrl+O** (`MS_UPDATE_KeyDown :2275-2301`), or by company type (`Mfg Refresh` only when `MsMfgType = "M"`, `:2180-2183`; `Scheme Data` only with `MsAppSchem = "Y"`).',
        '**In scope (visible by default):** `Account` `btnAc_Click :2334` (67 lines: fills `BOOK_DATA/BOOK_DETL.DATA_TYPE`, `CASH_DATA.CLR_DATE`, rebuilds `BANK_RECONCILE` and restores `AC_DATA.CLR_DATE`, runs `AcRefresh()`, then `Ac_Tax.Vch_Remark` for every in-use book; ends "Account Refersh Process Complete."); `Stock` `btnStock_Click :2671` (181 lines: recomputes `ITM_FINE` where it is <= 0 on `BAR_DETL` / `SL_DETL_RTN` …); `Approval Adj` `btnAprUpdate_Click :8809` (16 lines); `Image Data` `BtnImgData_Click :8825` (232 lines); `Field Update` `btnFildUpdate_Click :3958` (**≈4,850 lines**); `Old Field` `btnFildUpdate2_Click :9412` (**≈22,900 lines**).',
        '**Out of scope, and why:** the 12 Ctrl+O tools (`Crm Data`, `Problem Qry`, `TagDiff Set`, `All Tag Stock Delete`, `SrNo Mast Update`, `Bar Idtl SrNo Update`, `Sl Wt Diff Set`, `Other Set`, `OpBal Update`, `Tag Sale But Not In BarDetl Adjust`, `A Stock Set`, and the date-ranged ones) are vendor support tools for repairing a customer\'s damaged database, not operator features. Do **not** build the Ctrl+O reveal. `Mfg Refresh`, `Scheme Data` belong to editions/settings outside Lite.',
        'Every button first requires the Print right: message `You Have No Print Rights.....` (`UserPrint = "Y"`; rights are read by the menu caption, `:2042`).'],
  web=['Pages `utilities/data-refresh/page.tsx` (100 lines) and `utilities/data-repair/page.tsx` (391); API `POST /utilities/data-refresh`, `GET /utilities/data-repair/operations`, `POST /utilities/data-repair/:id/preview|apply`. Catalog: "Refresh deliberately avoids write-back; the repair registry covers a subset; ownership graph, rollback and recovery are unproven." Slices X27 / P11-01.'],
  decision=['**D-REF-1 — operator-visible buttons only.** Six buttons (Account, Stock, Field Update, Approval Adj, Image Data, Old Field). The 12 `Ctrl+O` vendor tools, `Mfg Refresh` and `Scheme Data` are out of Lite scope; no hidden shortcut is built.',
            '**D-REF-2 — preview-first, one transaction, audited, idempotent.** A deliberate safety improvement; the business result of each repair is unchanged.',
            '**D-REF-3 — the two giant buttons are classified before they are built** (apply / provably-no-op on web data / migration-loader). Nothing from the 27k lines is ported blindly.'],
  scope=['**Screen:** the six desktop captions in the desktop order, a progress indicator, the desktop completion messages (keep the original spelling), the Print-right gate with its exact text. No hidden shortcut.',
         '**Every operation is preview-first:** counts and a sample of the rows it would change, then Apply in **one transaction** with an audit row, tenant-scoped, idempotent (a second run changes nothing). Never a blind write. This is a deliberate improvement over the desktop\'s unguarded loops and does not change the business result.',
         '**PR 1 (small, ship fast): Account, Stock, Approval Adj, Image Data** (about 500 desktop lines in total). Prove each with a controlled corruption of derived data through a fixture, preview, apply, and a **full-tenant diff** showing only the intended rows moved.',
         '**PR 2: classify `Field Update` and `Old Field` (≈27,700 lines) before building anything.** Table: every UPDATE statement → one of **(a)** the anomaly can occur in data the web writes → implement as a repair; **(b)** it only repairs shapes produced by older desktop versions → write an *anomaly query* and prove, on a tenant populated through every Lite screen, that it returns 0 rows; the button then truthfully reports "no records need adjustment" (this is the desktop\'s own outcome on a clean database); **(c)** only needed after loading desktop data → list it for the migration loader (slices X30/P12/N30), do not build it here. Implement class (a) only.'],
  cases=['Per operation: corrupt → preview shows exactly the rows → apply → derived data equals a clean recompute from the vouchers → run again (no-op) → a voucher saved concurrently during apply (conflict handled, nothing lost).',
         'Rights by caption "Data Refresh" (G225 lists it as not closed — settle it here), a restricted user is refused by the API.',
         'Second tenant untouched in every case.'],
  risks=['Repair tools can destroy data; preview-first is not optional. If you cannot reproduce a desktop effect exactly, ship preview-only for that operation and say so.',
         'Classification PR is analysis, not code: do not skip it to "get on with it" — 27k lines of legacy patches must not be ported blindly.'],
  shared=['`modules/ops/*`', 'the two utilities pages']),

 dict(num='18', slug='data-backup', branch='feat/lite-data-backup', module='dataBackup', cat='Company/Data Backup', pkg='L5',
  kind='BUILD — scope DECIDED 2 Nov (owner-delegated): Backup only, exactly like the desktop; **no restore, containment untouched**', wave=3,
  mission='Make Company → Data Backup the desktop `UT_BKP` screen **as an operator sees it**: pick where to save, press Backup, get "Backup Process Complete." The desktop never shows Restore to the operator; the web does not either.',
  desk=['`UT_BKP.cs` is 1,298 lines. **`BtnRestore.Visible = false` (`:859`) and no code ever sets it true**, so a Lite operator cannot restore from this screen. `btnAttach` ("Dattach", `:899-901`) is shown only when `DC_Main.MsSqlDataPath` is set (`:1099-1102`; read from a file, `DC_Main.cs:976`) and detaches both SQL Server databases and quits the app: a vendor/IT tool specific to SQL Server, meaningless on the web.',
        '`BtnBkp_Click :1198-1251`: Print right required (`You Have No Print Rights.....`); empty path → `Please Select Path and Try`; remembers the path (registry `NEXT SOFTWARE\\BACKUP_DATABASE\\BACKUP_PATH`); writes `<path>\\Next<YY>[_<company type>]_ddMMyy_HH.BAK` (company database; an existing file of the same name is deleted first) and `NextMain.BAK` (the master/config database); ends `Backup Process Complete.` with a progress bar and timer.',
        'The restore code (`BtnRestore_Click :1253`, `RESTORE DATABASE …`) exists but is unreachable from the UI.'],
  web=['Page `backup/page.tsx` (53 lines); `modules/ops/backup.ts` (507) + `backupManifest.ts`; `GET /backup` (per-company JSON export with an integrity manifest); `POST /backup/restore` is **disabled by `web/packages/core/containment.mjs`**; `web/deploy/backup.sh` (`pg_dump` cron). Docs: DR runbook in `project-memory/parity/DR-RUNBOOK.md`.'],
  decision=['**D-BKP-1 — parity = Backup only.** Matches what the desktop operator can do. Restore stays an operator/IT procedure (physical database recovery, DR runbook); `containment.mjs` is **not edited**. No owner decision is needed because the desktop does not offer the operator a restore either.',
            '**D-BKP-2 — "choose a path" becomes the browser\'s Save dialog.** A browser cannot write to a server path; the equivalent of the folder picker is the download location. Keep the caption, the progress indicator and the messages.',
            '**D-BKP-3 — file content = this company\'s data plus the equivalent of `NextMain`** (this tenant\'s company/user/rights/menu configuration), as one download named `Next<YY>[_<type>]_ddMMyy_HH` (+ archive extension), integrity manifest inside. No other tenant\'s data, ever.'],
  scope=['The desktop screen: path/download control, **Backup** button, progress, the three exact messages, the Print-right gate (rights by caption "Data Backup"), audit row for who backed up when.',
         'The backup **content** must be complete for every Lite dataset (masters, vouchers, tags, openings, settings, rights) and its manifest hash must verify. Prove completeness by restoring it **into a scratch database using the documented physical procedure** (not the web restore) and diffing the tenant to zero.',
         'Leave `POST /backup/restore` disabled and make sure no UI path reaches it; a test asserts the route still answers the containment refusal.',
         'No `Dattach`, no restore button, no registry/path persistence on the server.'],
  cases=['Backup of a company holding every Lite dataset; byte-stable manifest; a second tenant never in the file; restricted user refused by the API; two backups in the same hour (same name) behave as the desktop (replaced); large company completes and reports progress; restore route still refused.'],
  risks=['Do not "helpfully" enable restore. Anything that changes `containment.mjs` is out of scope and a reason to stop.'],
  shared=['`ops/backup*.ts`', '`backup/page.tsx`']),

 dict(num='19', slug='data-import', branch='feat/lite-data-import', module='dataImport', cat='Other/Data Import', pkg='L3',
  kind='BUILD — scope DECIDED 2 Nov (owner-delegated): the "Lite Soft" import only; **lowest priority, do it last**', wave=5,
  mission='Other → Data Import is the desktop `UT_IMPORT`, titled **"Old Software Import"**: a one-time migration from the vendor\'s *previous* products. Build the one path a Lite shop uses, **Lite Soft**, as a safe, atomic, previewed import. Do not build the other ~34 products\' importers.',
  desk=['`UT_IMPORT.cs` is 14,466 lines with ~35 buttons, one per old product: `Wh Soft`, `Retail Soft`, `Retail Dhrn/Schm/Loan/Jadtar`, **`Lite Soft` (`BtnLite_Click :8413`)**, `Plus Soft/Dhrn/Approval/Schm/Loan/Ac Opening/Reparing`, `Chudi Sql`, `Rtl-Wh-HuId` … The form caption is "Old Softwar Import" (`:3187`). The same form with all import buttons hidden is the separate **Estimate Reset** menu (Standard; `:3300-3345`).',
        '**Lite Soft flow (`:8413-8445`):** question `Are You Sure To Import Old Software Data In Next Software ?` → Open dialog filtered `MDB (*.mdb)` → `TrfrConn()` → `ImpSoftType = "Lite"` → `Lite_AcMast()` (accounts, ≈90 lines) → `Wh_Item()` (items, ≈89) → `WH_AcOpbl()` (account openings, ≈33) → `Lite_BarData()` (tags, ≈247; **first deletes `BAR_DATA/BAR_DETL/BAR_IDTL` of the company**) → `WH_ItOpbl()` (item openings, ≈76) → sets `HDD_MAST.REF_NO = "S"`, `YEAR_MAST.OP_DATE = today`, `LOCT_MAST.TRY_DATE = today + 10 days` → `Process Are Complete....` → the application exits. The five import methods are about 535 lines in total: this is tractable.',
        'The input is a Microsoft Access `.mdb` from the old Lite product. **There is no sample `.mdb` and no Access reader in the repository** (`apps/api/package.json` has none).'],
  web=['Only the generic `POST /masters/:name/import` (CSV rows) exists. The catalog maps this menu to `/masters/accounts`, which is wrong: it has no screen of its own. The Excel imports inside Item (`MS_ITEM.cs:3856-3909`) and Party (`MS_ACCT.cs:9024`) are claimed by this menu (doc 12 G231); treat them as phase 2 of this work only if time remains.'],
  decision=['**D-IMP-1 — Lite Soft only.** The other buttons are bespoke importers for other legacy products, run by the vendor at onboarding; they become a managed migration service in Phase 2 (G80/D25). If you have a customer coming from Retail, Wh or Plus Soft, say so and each becomes its own small slice.',
            '**D-IMP-2 — atomic and previewed, and it never silently wipes.** The desktop is not atomic and deletes the company\'s tag tables unconditionally. The web runs the five steps in **one transaction**, shows counts per step before the confirm question, and **refuses a company that already has vouchers, openings or tags** with a clear message (the import is meant for a freshly created company). This is a deliberate, documented deviation.',
            '**D-IMP-3 — memory-safe reader, never a shell.** Read the `.mdb` in-process with a pure-JavaScript reader (evaluate `mdb-reader`; it must handle the Jet version the old Lite product used) behind a small `SourceReader` interface, with a size cap, a table/column allow-list and a timeout. No child process, no `mdbtools`.',
            '**D-IMP-4 — do not port licence/trial manipulation.** `HDD_MAST.REF_NO` and `LOCT_MAST.TRY_DATE` are licensing state; record them as an intentional omission unless the web has an equivalent that the source proves is business behaviour. `OP_DATE` is business behaviour: port it.'],
  scope=['New route `/utilities/data-import` titled **Old Software Import**, classified in `docs/handbook/web-route-editions.json`, with the **Lite Soft** button, the desktop question and completion texts, per-step progress, the rights gate by caption "Data Import" (G225 lists it as not closed — settle it), correct the catalog row\'s `ui`.',
         'The five import steps mapped column by column with desktop citations (`Lite_AcMast`, `Wh_Item`, `WH_AcOpbl`, `Lite_BarData`, `WH_ItOpbl`): which source table/column fills which web column, defaults, code generation, account-group assignment, touch/fine arithmetic, tag numbering.',
         'Row-level error report (which source row, which reason); idempotency key so a double click or retry imports once; audit row; tenant scoping; after import, the Party, Item, Tag Stock, Stock and Ledger screens show the imported data correctly.'],
  cases=['**Because there is no real file:** test the mapping and the transaction at the `SourceReader` boundary with table fixtures built from the desktop\'s column list (cite lines). One case, "reads a real Lite Soft `.mdb`", is **BLOCKED with the reason "no sample file in the repository; the owner must supply one sanitized or synthetic file"**. It stays in the denominator. Do not fabricate a binary `.mdb`.',
         'Fresh company imports; company with data refused (nothing written); a failure in step 4 rolls back steps 1-3 (T14, per step); retry/double submit; oversized or malformed file refused with no write; a file with unknown tables ignored safely; rights; second tenant untouched.',
         'Downstream: the imported tag appears in Tag Stock and can be sold through the Sales screen; an imported party\'s opening balance shows in the ledger.'],
  risks=['Lowest value of the 23: only shops migrating from the old Lite product need it. Do not let it delay anything else (wave 5).',
         'Untrusted binary parsing: keep the reader isolated and capped.'],
  shared=['`masters/*import*`', '`web-route-editions.json`', 'menu catalog row `ui`', '`apps/api/package.json` (new dependency: justify it in the PR)']),

 dict(num='20', slug='audit-stock-adjust', branch='(none — read-only audit; do not push to feat/stock-adjust)', module='stockAdjust (audit)', cat='Other/Stock Adjust', pkg='L3',
  kind='INDEPENDENT AUDIT of open PR #197 — do NOT re-implement', wave='after #197 is ready',
  mission='Another session is building Stock Adjust (`feat/stock-adjust`, PR #197, N221/G234). You are the independent verifier. The aim is a second pair of eyes that did not write the code and does not trust its claims.',
  desk=['Desktop: `TR_TAG_CAN.cs` (5,987 lines) used on a `STOCK ADJUST` book (`CurBookHelp`), `MDI_FORM.cs:8616-8627`; same form as Tag Cancel. Tables `BAR_CAN_DATA`, `BAR_CAN_DETL`, `MAIN_STOCK`, `BAR_DETL`, `DM_DATA`. Signed piece/weight corrections, **no financial ledger entry**.'],
  web=['PR #197 changes: `txn/stock-adjust/page.tsx` (rewritten around the shared `components/TagCancelForm.tsx`), `lib/tagCancelVoucher.ts`, a migration `…_stock_adjust_book`, `stockAdjust.mjs` (968 lines), `stockAdjust` route DB test, and edits `tagCancel.mjs`.'],
  scope=['Create a **read-only** worktree of the PR head: `git worktree add ~/dc-wt/audit-stock-adjust --detach origin/feat/stock-adjust`. Never push to that branch; never edit the other session\'s files.',
         '1) Re-derive the desktop behaviour yourself from `TR_TAG_CAN.cs` for the STOCK ADJUST mode (signed +/−, counter, loss weight, karigar, component grid, configured book) and list every behaviour. 2) Compare against the PR\'s case list: which desktop behaviours have **no case**? 3) Run their module and the **Tag Cancel module** (the shared form changed) on a fresh stack. 4) Write **your own additional cases** for every uncovered behaviour and every T-group they skipped (rights by caption, two-session race, retry, per-table rollback, reopen/no-op footprint, Tag Stock report agreement) and run them against the PR head. 5) Check records: contiguous N/G ids against `origin/main`, catalog row, coverage map, progress page.'],
  cases=['Report each failure with: case, expected (with desktop citation), observed, evidence path. Check for **tag-cancel regressions** (the PR edits the shared form) and the book-migration safety on a database that already has Stock Adjust rows.'],
  risks=['Do not "help" by pushing fixes. Findings go to the owner and to the PR author in a report file `~/datacare-agent-reports/audit-stock-adjust.md` (and, only if the owner says so, as a PR comment).'],
  shared=['(read-only)']),

 dict(num='21', slug='audit-ledger-report', branch='(none — read-only audit; do not push to feat/lite-ledger-report)', module='accountLedger (audit)', cat='Report/Ledger Report', pkg='L6',
  kind='INDEPENDENT AUDIT of open PR #195 — do NOT re-implement', wave='now (PR open since 1 Nov)',
  mission='Another session built the Ledger Report as the desktop `RP_LEDR` screen (`feat/lite-ledger-report`, PR #195). Audit it independently. Known problem to confirm first: **it claims `N219/G232`, which `main` already uses for Auto Item**.',
  desk=['`RP_LEDR.cs` is 11,814 lines; catalog range `RP_LEDR.cs:4658-7694`. Dispatch `MDI_FORM.cs:8871-8880`. Money, gold and silver modes; time/ageing/purchase modes; zero/sign semantics; nested drill-down; many Crystal variants (`AcLedger.rpt`, `AcLedgerSelected.rpt`, `AcFineGold.rpt`, `AcSumm.rpt`, `AcGroupRpt.rpt`).'],
  web=['PR #195 adds `reports/account-ledger/{page,AccountLedgerGrid,useAccountLedger,types}`, API tests `accountLedgerReport(.db).test.ts`, `accountLedger.mjs` (424 lines), edits `txn.ts` and `routePolicy.test.ts`. API `GET /reports/account-ledger/:acCode` and `/export.pdf`.'],
  scope=['Same method as agent 20, read-only worktree: `git worktree add ~/dc-wt/audit-ledger --detach origin/feat/lite-ledger-report`.',
         'Specific checks: (1) **id collision and record hygiene** vs `origin/main`; (2) every desktop mode and option in `RP_LEDR` vs the 424-line module — list the modes with **no case**; (3) hand-compute ledgers for parties created through Sales/Purchase/Cash screens, including **gold/silver fine columns**, opening balances (Party Opening), Cr/Dr sign conventions, zero-balance rows; (4) drill-down to voucher; (5) PDF equals grid; (6) sentinels in other company/location/year/tenant; (7) rights `----PL`; (8) the catalog says the old web ledger lacked metal/time/ageing/purchase modes — confirm which exist now.'],
  cases=['Same reporting format as agent 20; file `~/datacare-agent-reports/audit-ledger-report.md`.'],
  risks=['The ledger is the number owners trust most. A wrong closing balance is a high-severity finding.'],
  shared=['(read-only)']),

 dict(num='22', slug='tag-cancel-close', branch='feat/lite-tag-cancel-close', module='tagCancel', cat='Other/Tag Cancel', pkg='L3',
  kind='FINISH A MOSTLY-DONE MENU (small) — start only after PR #197 (Stock Adjust) has merged', wave=4, after='PR #197 merged (it edits `TagCancelForm.tsx`, `tagCancelVoucher.ts` and `tagCancel.mjs`).',
  mission='Tag Cancel (`TR_TAG_CAN`, book `TAG CANCEL`) is built and its module passes 12 browser cases (N210, PR #185); it is "module green" on the progress page. The catalog still lists open items. Close the ones that can be closed in the browser.',
  desk=['`TR_TAG_CAN.cs` (5,987 lines), `MDI_FORM.cs:8585-8595`. Print template `TagCanBill`.'],
  web=['`components/TagCancelForm.tsx`, `modules/stock/tagCancel.ts`, `tagCancelBill.ts`; module `modules/tagCancel.mjs`. **The coverage-map/progress mapping was already fixed on `main` by #189** (the entry now lists `txn/tag-cancel/page.tsx`; the progress page shows Tag Cancel "module green"). Do not redo it; verify it is still true after your rebase.'],
  scope=['The catalog row\'s remaining open items. Close them by adding cases and any fixes they expose: **idempotency/retry (T13), per-table fault rollback (T14), the Tag Stock report agreement (T16/T18; use agent 04\'s report if merged, else the existing report), concurrent two-session cancel of the same tag (T12), rights by the caption "Tag Cancel" (T11)**. "No captured desktop BAR_CAN rows" and "desktop-runtime comparison" stay open honestly.'],
  cases=['Extend `tagCancel.mjs`; the existing 12 cases stay unchanged.'],
  risks=['Small, but it shares files with #197 and agent 04: rebase before you start.'],
  shared=['`tagCancel.mjs`', '`TagCancelForm.tsx` (shared with Stock Adjust)', 'catalog row of Tag Cancel']),
]


def fmt_list(items, indent=''):
    return '\n'.join(f'{indent}- {x}' for x in items)


def build(m):
    r = CAT[m['cat']]
    tab, menu = r['tab'], r['menu']
    slot_note = 'No browser stack needed for the audit setup until you run their module; the slot rules still apply.' if m['num'] in ('20', '21') else ''
    lines = []
    lines.append(f"# Agent {m['num']} — {tab} → {menu}   (Lite package {m['pkg']})\n")
    lines.append(f"**Type:** {m['kind']}  ")
    lines.append(f"**Suggested wave:** {m['wave']}  ")
    if m.get('after'):
        lines.append(f"**Do not start building until:** {m['after']}  ")
    lines.append(f"**Prompt generated against:** `origin/main` @ `{MAIN}` (1–2 Nov 2026). Re-fetch and re-read the catalog row before you start; if `main` moved, trust `main`.\n")
    lines.append('> Read `00-GENERIC.md` first' + (' and `00b-REPORT-ADDENDUM.md`' if m.get('report') else '') + '. This file is the menu-specific part.\n')
    if m['kind'].startswith('INDEPENDENT AUDIT'):
        lines.append('> **AUDIT OVERRIDE.** From 00-GENERIC keep §0-§1 (hard rules), §2.1 (machine limits) and the *reporting* style. '
                     'Skip §3 steps 1-6 as written: you do **not** create a feature module of your own for the menu, take N/G ids, edit '
                     'records, push a branch or open a PR. You work in a **read-only, detached worktree** of the other session\'s PR head, '
                     'put any extra cases in a scratch file outside the repo (or an untracked file in your worktree), and deliver one report file. '
                     'Report format: for each finding give severity, the case, the desktop citation, expected vs observed, and the evidence path; '
                     'end with the three coverage numbers for the PR\'s own matrix plus yours.\n')
    lines.append('## Mission\n\n' + m['mission'] + '\n')
    lines.append('## Identity and hand-offs\n')
    lines.append(f"- **SLUG** `{m['slug']}`  **BRANCH** `{m['branch']}`  **worktree** `~/dc-wt/{m['slug']}`  **feature module** `{m['module']}`")
    lines.append(f"- Isolated Compose project: `PARITY_TEST_PROJECT=dc-{m['slug']}` (ports come from the stack slot you take, see 00-GENERIC §2.1).")
    if slot_note:
        lines.append(f'- {slot_note}')
    lines.append('')
    lines.append('## Catalog facts (copied from `docs/handbook/menu-catalog.jsonl`; re-read the live row)\n')
    lines.append(f"- **Desktop form(s):** {', '.join('`'+f+'`' for f in r['forms'])} — mode: {r['mode']}")
    lines.append(f"- **Menu dispatch:** `{r['dispatch']}`")
    lines.append(f"- **Tables:** {', '.join('`'+t+'`' for t in r['tables']) or '—'}")
    lines.append(f"- **Web routes:** {', '.join('`'+u+'`' for u in r['ui'])}")
    lines.append(f"- **API:** {', '.join('`'+a+'`' for a in r['api'])}")
    lines.append(f"- **Desktop rights:** `{r['can']}` ({RIGHTS})")
    lines.append(f"- **Status:** `{r['status']}`  **Phase:** `{r['phase']}`  **Owners (slices/gaps):** {', '.join(r['owners'])}")
    lines.append(f"- **Purpose:** {r['purpose']}")
    lines.append(f"- **Recorded gap:** {r['gaps']}")
    lines.append(f"- **Sources:** {', '.join('`'+s+'`' for s in r['sources'])}\n")
    lines.append('## Desktop pointers (start your study here)\n\n' + fmt_list(m['desk']) + '\n')
    lines.append('## Current web state\n\n' + fmt_list(m['web']) + '\n')
    if m.get('decision'):
        lines.append('## Decisions already made (owner-delegated on 2 Nov 2026; do not re-open them, do not ask again)\n\n' + fmt_list(m['decision']) + '\n')
    lines.append('## Scope — what you must deliver\n\n' + fmt_list(m['scope']) + '\n')
    lines.append('## Case emphasis (on top of the T01–T18 expansion in 00-GENERIC §3 step 2)\n\n' + fmt_list(m['cases']) + '\n')
    lines.append('## Risks and traps\n\n' + fmt_list(m['risks']) + '\n')
    lines.append('## Shared files you are likely to touch (expect merge conflicts here; regenerate generated files, do not hand-merge)\n\n' + fmt_list(m['shared']) + '\n')
    lines.append('## Reminders\n\n'
                 '- Rebase on fresh `origin/main` and allocate `N###`/`G###` **last**, not first (00-GENERIC §3 step 6).\n'
                 '- Desktop match is 0%; say so. Do not mark the catalog row `FULL` unless every case passes and no gap is open.\n'
                 '- Finish with the final-report block from 00-GENERIC §5.\n')
    return '\n'.join(lines)


def main():
    out_menu = HERE
    full_dir = HERE / 'launch'
    full_dir.mkdir(exist_ok=True)
    generic = (HERE / '00-GENERIC.md').read_text()
    addendum = (HERE / '00b-REPORT-ADDENDUM.md').read_text()
    for m in MENUS:
        body = build(m)
        fname = f"{m['num']}-{m['slug']}.md"
        (out_menu / fname).write_text(body)
        parts = [generic, '\n\n' + '=' * 110 + '\n\n']
        if m.get('report'):
            parts += [addendum, '\n\n' + '=' * 110 + '\n\n']
        parts += [body]
        (full_dir / fname.replace('.md', '.FULL.md')).write_text(''.join(parts))
    print('wrote', len(MENUS), 'prompts + launch bundles')


if __name__ == '__main__':
    main()
