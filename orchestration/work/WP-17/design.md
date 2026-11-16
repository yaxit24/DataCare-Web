# WP-17 design: Report → Cash Bank (cash-and-bank mode only)

Inputs: `study.md` (the desktop, cited), `cases.md` (61 executable cases, 19 blocked, 7 N/A). Citations below point at the
study's sections; they are not re-derived. Case ids drop the prefix `cash-bank-report.`. This machine cannot run database or
browser tests, so every packet that adds tests lists the tests it wrote but could not run; GitHub CI proves them.

## 0. Shape of the work

A new read-only report with its own files, beside the Account Ledger (`routes/accountLedger.ts`, `modules/reports/accountLedgerReport.ts`,
`reports/account-ledger/`), which is the model for everything below.

| Part | New files |
|---|---|
| Pure kernel (opening, balance, side, totals, paise arithmetic; no database) | `web/apps/api/src/modules/reports/cashBankKernel.ts` |
| Resolver, query parser, account help list | `web/apps/api/src/modules/reports/cashBankReport.ts` |
| Routes (screen, help list, print html, three exports) | `web/apps/api/src/routes/cashBankReport.ts` |
| Print layout `AcLedger` (html, then PDF) | `web/apps/api/src/modules/reports/cashBankPrint.ts` |
| Page | `web/apps/web/app/(app)/reports/cash-bank/{page.tsx,useCashBank.ts,CashBankGrid.tsx,types.ts}` |
| Tests | `web/apps/api/test/cashBankReport.db.test.ts`, `cashBankReport.print.db.test.ts`, `test/support/cashBankSeed.ts`, `web/apps/web/test/features/modules/cashBankReport{,Kit,Io}.mjs` |

New URL family `/reports/cash-bank` (the old slug `cash-book` is kept, section 7). The module id is `cash-bank-report`.

## 1. Resolver

**Input** (`parseCashBankQuery`, fail closed with a 400 `invalid-request`, as `parseAccountLedgerQuery` does):
`fromDate`, `toDate` (both required, `YYYY-MM-DD`, real calendar dates; the page sends the session date as the default,
study Screen: `mFromDt.Text = DC_Main.MsSysDate`), `acCode` (required, 1 to 8 characters of `[A-Za-z0-9]`; the
page proposes `00001`), `bookCode` (optional, same shape, empty means all books). `fromDate > toDate` is **not** an error
(case `filter.from-after-to`; the desktop has no check). **Scope** never comes from the query: `readScope(req)` gives
`tenantId`, `coCode`, `lcCode`, `coYear`. A request with no `lcCode` in the session is refused (400 `location-required`), because every
desktop query filters on the location (study Calculations, detail query).

**Tenant isolation.** Both queries run inside `withTxBudget(prisma, s.tenantId, 'read', …)` (forced row-level security applies to
`AC_DATA`, `BOOK_DATA`, `AC_MAST`, `SL_DATA`, `PR_DATA`); each also states `CO_CODE` and `LC_CODE` explicitly. All values are bound
parameters. The desktop's string-built SQL is not ported (study weakness 1). **Supervisor decision, 16 November 2026: the company year of the session is applied** to the opening query, the detail query and the print (`"CO_YEAR" = $n`), on the screen and on paper alike. The desktop keeps each financial year in its own database (see the Year Create study, `orchestration/work/WP-22/study.md` on its branch: a new year is a restored copy that is then purged of other years), so its grid can never see another year. In the web's single database the `CO_YEAR` column is that boundary. Without it the opening balance would add earlier years' movements to the opening that was already carried into this year. No data-type filter
on the screen (section 10, decision 3). Decision 4 of section 10 is replaced by this paragraph.

**Opening query** (study Calculations step 1: the SQL at `RP_CASH_BANK.cs:3160`). One row:
`SUM(CR_AMT - DR_AMT)` over `AC_DATA` where company, location, `AC_CODE = $acCode`, `VCH_DATE < $from`, and `CO_BOOK = $bookCode`
only when the book is set. Signed net `< 0` means Dr = abs(net); `> 0` means Cr = net (the `Case When SUM(...) < 0 Then abs(...)` rule). Reuse
`SIGNED_MONEY` from `accountLedgerShared.ts`, which is the same expression.

**Detail query** (study Calculations step 3, `RP_CASH_BANK.cs:3162`): `AC_DATA d` joined to `BOOK_DATA b` (company, location, book) and
`LEFT JOIN AC_MAST c ON c.CO_CODE = d.CO_CODE AND c.AC_CODE = d.LD_CODE` (the counter-party). Filters: company, location,
`d.AC_CODE = $acCode`, `VCH_DATE >= $from AND VCH_DATE <= $to`, optional `CO_BOOK`. `GROUP BY b.BOOK_NAME, d.CO_BOOK, d.VCH_NO, d.VCH_DATE,
d.LEDR_KEY, d.LD_CODE`; money is `SIGNED_MONEY` per group, split into Dr and Cr by the same sign rule. `ORDER BY d.VCH_DATE, b.BOOK_NAME`, then
`d.VCH_NO, d.LEDR_KEY` as a tie-break the desktop does not state (decision 8). Selected for the row: `c.AC_NAME`, `c.AC_AREA`, `b.MAIN_BOOK`.
**Grouping caveat:** the Account Ledger notes that a web `LEDR_KEY` is unique per line, so two lines merge into one row only when they share a `LEDR_KEY`.
Seed A's voucher 7 (two lines, one row) therefore must give both lines the same `LEDR_KEY` (decision 7).

**Party name** (study Lifecycle, row content): book `SALES` takes `SL_DATA.AC_NAME` by (`CO_BOOK`, `VCH_NO`); `PURCHASE` takes `PR_DATA.AC_NAME`;
every other book takes the counter-party's `AC_NAME`. `MEMB ENTRY` (member tables, `RP_CASH_BANK.cs:3280`) is `MISSING`: its query text was
not read, so the resolver uses the counter-party name and the api packet records the difference. These lookups are done in the same query by `LEFT JOIN`, never row by row.

**Kernel** (pure; tested through the route, because a unit test would import a file that does not exist yet). Amounts are converted to integer paise before any addition, so no float drift; output is
rupees with two decimals. Steps: (1) opening Dr/Cr from the signed net; (2) when `Dr + Cr != 0` emit the row `Op Balance` (`RP_CASH_BANK.cs:3222`, `:3226`);
(3) running Dr sum `num` and Cr sum `num2` start at the opening and add each row; (4) row balance = `abs(num2 - num)`, side `Cr` when `num2 - num > 0`,
`Dr` when `< 0`, empty when 0 (`:3296`, `:3297`, `:3301`); (5) totals = `num`, `num2`, `abs(num2 - num)` and the same side (`:3322` to `:3325`), so totals
include the opening; (6) a zero Dr or Cr cell is returned as `0` and the page shows blank (`:3360`); (7) the totals row is returned only when there is at least one row.

**Row shape** (`CashBankRow`): `kind: 'opening'|'detail'`, `sr`, `book` (name), `vchNo`, `vchDate` (`YYYY-MM-DD`), `party`, `area`, `drAmt`, `crAmt`, `balAmt`, `side`
(`'Cr'|'Dr'|''`), plus link keys that the page never shows: `coBook`, `mainBook`, `acCode`, `coYear`, `lcCode`. The opening row has no link keys, so no
drill-down (case `drilldown.opening-row-no-open` is blocked; the page ignores a double-click on it). Result: `{ rows, totals: {drAmt, crAmt, balAmt, side} | null,
account: {acCode, acName} | null, book: {code, name} | null, from, to }`. An unknown account is not an error: `account` is `null` and the rows are empty
(desktop: the grid just shows what the query returns).

## 2. API

File `web/apps/api/src/routes/cashBankReport.ts`, plugin `registerCashBankReportRoutes(app, {prisma, auth, guard, readScope, sendReportPdf})`, same helpers type as the
Account Ledger plugin. Registration in `txn.ts`: the packet adds one `import` line and one call line next to `registerAccountLedgerRoutes(…)` (`txn.ts:4519`),
and runs `node scripts/check-size-budget.mjs`; nothing else in `txn.ts`.

| Route | Right (form `Reports/Cash / Bank Book`, desktop caption `Cash Bank`) | Returns |
|---|---|---|
| `GET /reports/cash-bank` | view | the result above |
| `GET /reports/cash-bank/accounts?q=` | view | the account help list (section 3) |
| `GET /reports/cash-bank/print` | print | the `AcLedger` print as html (section 5) |
| `GET /reports/cash-bank/export.pdf`, `export.xlsx`, `export.csv` | print | the same data as a file |

Rights: `routePolicy.ts` gets the new routes added to the existing `route('Reports/Cash / Bank Book', […])` list and the export and print routes added to `PRINT_ROUTES`
(next to the Account Ledger lines, `routePolicy.ts:936-941`, `:1048`). The handlers still call `guard(req, reply, 'print')` first, as the ledger exports do. Refusal text for a user without the
print right: 403 with message `You Have No Print Rights.....` (the desktop's Excel text, `RP_CASH_BANK.cs:2540`). For Print the desktop has no check, so this is a deliberate difference (case
`rights.print-no-right-no-desktop-check`, blocked on wording; the design uses the same text). Without the view right: 403 (the desktop text `You Have No Rights.....` is shown by the page).
`app.ts:403` (`enforceReportFilters`) refuses `acCode` and `bookCode` for every report not exempted, so the api packet adds `/reports/cash-bank` to the exemption next to
`/reports/account-ledger` (a one-line change, with a comment).

## 3. Account help list

`GET /reports/cash-bank/accounts?q=` returns `{acCode, acName, group, area, address, city}` rows from `AC_MAST` joined to the group table, for the session company. For a
location other than `00` it is the desktop union (study Rules: code below 100 in any group, `RP_CASH_BANK.cs:3661 {{AND CAST(C.AC_CODE AS INT) < 100}}`; or code 200 or more with `AC_GR IN ('02','03','19','21','22','23')`);
`q` narrows by code or name prefix, bound as a parameter, limit 50. For location `00` the desktop's group-only query was not read: the route returns an empty list and the packet writes `MISSING` (case `account.help-location-00` is blocked).
Exact code match on Enter is done by the page against `GET /reports/cash-bank?acCode=` (`account` non-null) so there is one lookup path.

## 4. The page

Directory `reports/cash-bank/` (own route; a static route outranks `[report]`). `page.tsx` composes `useCashBank.ts` (state, requests, keys) and `CashBankGrid.tsx`; `types.ts` mirrors the row shape.
Nothing is added to `reports/[report]/page.tsx`, and nothing is removed from it (it keeps serving the old slug; section 7).

**Controls, in the desktop's tab order** (study Screen table): From (0), To (1), Party Code (2), Print (3), Excel (4), Cancel (5), Exit (7), then the account name (1129, read-only), the grid (1133), Book (1162, with a read-only book-name box).
No Delete button (desktop handler is empty, study weakness 5). Defaults: dates = session date, Party Code `00001`, name `CASH ON HAND` once the account resolves (not hard-coded: the name comes from the response). Banner: `Cash Bank`.

**Grid columns:** `Sr`, `Book`, `VchNo`, `Date` (`dd/MM/yyyy`, formatted by the page from `vchDate`), `Party Name`, `Area`, `Dr Amt`, `Cr Amt`, `Bal Amt`, `CrDr`. Money: two decimals, thousands separator by the culture; a zero Dr, Cr or Bal shows blank.
The opening row shows `Op Balance` in Book. The last row, `Total :` in the Party Name column, carries the totals. No code column is shown.

**Keys** (study Keyboard): Enter in From focuses To; Enter in To focuses Party Code (focus is set directly, no simulated keys); Enter in Party Code runs the lookup: found sets the name and refills, not found opens the help dialog
(Enter or double-click on a row picks it, refills); Enter in Book refills (empty book means all books, name cleared); Esc closes the report (history back) unless the help dialog is open; typed letters in the two code boxes are upper-cased (not elsewhere, study weakness 7);
Enter in the grid does nothing; a double-click on a detail row drills down. The grid refills on load, on Cancel, on Enter in Party Code and on Enter in Book. A date change does not refill (desktop rule, case `filter.date-change-no-refresh` is blocked; the design follows the desktop).
Cancel resets Book, dates and account and refills (`CLEAR_DATA`). Print, Excel need a successful grid first and show the 403 text in the page's message line.

**Drill-down** (study Lifecycle, DGV_DETL_DoubleClick): by `mainBook` → web screen: `SALES` → `/txn/sales/<vchNo>?coBook=&coYear=&lcCode=` (the sales page already opens that URL, `txn/sales/page.tsx:504`); `SALES ORDER` → `/txn/sales-order`;
`CASH REC`, `BANK REC` → `/txn/receipt` and `CASH PAY`, `BANK PAY` → `/txn/payment` (the `?mode=BANK` form used by `FormKeys.tsx`); `CONTRA` → `/txn/contra`. How each of these screens opens a saved voucher by number is **not known**: the screen packet reads each page first and
records, per book, the real URL or `BLOCKED: <reason>`; it does not guess a parameter. Other books do nothing (cases blocked).
Menu and keys: `lib/nav.ts:269` label becomes `Cash Bank` with href `/reports/cash-bank`; `FormKeys.tsx:230-233` Ctrl+F11 label and target change likewise.

## 5. Print and export

`GET /reports/cash-bank/print` returns html built by `cashBankPrint.ts` from the resolver result (same filters as the grid: this fixes study weakness 2 on purpose). Regions from `AcLedger.xml`: title
`Cash and Bank Report From dd/MM/yyyy To dd/MM/yyyy` (`RP_CASH_BANK.cs:3563`); page-header headings `Debit Rs`, `Credit Rs`, `Ac Name`, `Balance` (`AcLedger.xml:452,465,478,511`; further headings: the print packet reads lines 440 to 520 and cites each);
group header `Opening Balance :` with the signed opening (Cr positive, `-7500.00` for seed A: `AcLedger.xml:285`); group footer `Transaction Total :` (Dr and Cr totals include the opening) and `Closing Balance :` with its side (`AcLedger.xml:836`, `:917`, `:323`, `:307`, `:350`).
`export.pdf` renders that html through the existing renderer (`sendReportPdf` in `txn.ts:4490`; the print packet checks whether it can take html and stops as `PARTIAL` if a `txn.ts` change would be needed).
`export.xlsx` and `export.csv` carry the ten grid columns (hidden codes excluded), rows = opening + detail + the `Total :` row, money as numbers with format `0.00`, bold header row, widths set; built with `renderXlsx` / `toCsv`, as the ledger does. All four are print-right only.

## 6. Case map

Test files: **DB** = `cashBankReport.db.test.ts` (real route, seed A, isolated database), **PRN** = `cashBankReport.print.db.test.ts`, **UI** = `cashBankReport.mjs` (tests-ui), **IO** = `cashBankReportIo.mjs` (tests-ui-io). Built by: **api** = WP-17.api, **print** = WP-17.print, **screen** = WP-17.screen.

| Case | Test | Built by |
|---|---|---|
| cash-bank-report.balance.opening-row | DB + UI | api, screen |
| cash-bank-report.balance.opening-zero-no-row | DB + UI | api, screen |
| cash-bank-report.balance.opening-cr-side | DB + UI | api, screen |
| cash-bank-report.balance.running-side | DB + UI | api, screen |
| cash-bank-report.balance.zero-net-row-blank | DB + UI | api, screen |
| cash-bank-report.balance.totals-row | DB + UI | api, screen |
| cash-bank-report.balance.totals-include-opening | DB | api |
| cash-bank-report.balance.n2-display | UI | screen |
| cash-bank-report.balance.seed-a-hand-totals | DB | api |
| cash-bank-report.balance.date-boundary-from-inclusive | DB + UI | api, screen |
| cash-bank-report.filter.default-dates | UI | screen |
| cash-bank-report.filter.date-window-from | DB + UI | api, screen |
| cash-bank-report.filter.date-window-to | DB + UI | api, screen |
| cash-bank-report.filter.from-after-to | DB + UI | api, screen |
| cash-bank-report.filter.empty-period | DB + UI | api, screen |
| cash-bank-report.filter.one-account-only | DB + UI | api, screen |
| cash-bank-report.filter.book-filter | DB + UI | api, screen |
| cash-bank-report.filter.book-empty-all | DB + UI | api, screen |
| cash-bank-report.filter.book-unknown-code | DB + UI | api, screen |
| cash-bank-report.account.default-00001 | UI | screen |
| cash-bank-report.account.enter-found | DB + UI | api, screen |
| cash-bank-report.account.enter-not-found-help | UI | screen |
| cash-bank-report.account.help-choose-row | UI | screen |
| cash-bank-report.columns.order-and-captions | UI | screen |
| cash-bank-report.row.voucher-book-and-number | DB + UI | api, screen |
| cash-bank-report.row.date-format | UI | screen |
| cash-bank-report.row.party-name-counter-party | DB + UI | api, screen |
| cash-bank-report.row.party-name-sales | DB + UI | api, screen |
| cash-bank-report.row.grouping-one-row-per-voucher | DB | api |
| cash-bank-report.row.hidden-codes-not-shown | UI | screen |
| cash-bank-report.title.banner-caption | UI | screen |
| cash-bank-report.title.menu-label | UI | screen |
| cash-bank-report.drilldown.sales | IO | screen |
| cash-bank-report.drilldown.cash-rec | IO | screen |
| cash-bank-report.drilldown.cash-pay | IO | screen |
| cash-bank-report.drilldown.bank-rec | IO | screen |
| cash-bank-report.drilldown.bank-pay | IO | screen |
| cash-bank-report.drilldown.contra | IO | screen |
| cash-bank-report.drilldown.sales-order | IO | screen |
| cash-bank-report.reset.cancel-clears-all | IO | screen |
| cash-bank-report.scope.company-sentinel | DB | api |
| cash-bank-report.scope.location-sentinel | DB | api |
| cash-bank-report.rights.menu-no-right | DB + IO | api, screen |
| cash-bank-report.rights.ctrl-f11-no-right | IO | screen |
| cash-bank-report.rights.excel-no-print | DB + IO | api, screen |
| cash-bank-report.print.template-regions | PRN | print |
| cash-bank-report.print.title-parameter | PRN | print |
| cash-bank-report.print.opening-amount-unfiltered | PRN | print |
| cash-bank-report.print.totals-and-closing | PRN | print |
| cash-bank-report.print.excel-rows-and-totals | DB | api |
| cash-bank-report.print.excel-bold-and-autofit | DB | api |
| cash-bank-report.keyboard.tab-order | IO | screen |
| cash-bank-report.keyboard.enter-from-moves-on | IO | screen |
| cash-bank-report.keyboard.enter-to-moves-on | IO | screen |
| cash-bank-report.keyboard.enter-party-refills | IO | screen |
| cash-bank-report.keyboard.enter-book-refills | IO | screen |
| cash-bank-report.keyboard.esc-closes | IO | screen |
| cash-bank-report.keyboard.enter-in-grid-no-action | IO | screen |
| cash-bank-report.keyboard.upper-case-codes | IO | screen |
| cash-bank-report.keyboard.focus-direct | IO | screen |
| cash-bank-report.history.live-party-name | DB | api |

Blocked cases stay blocked in all test files: each is registered with the `blocked(id, group, reason)` helper (`approvalIssue.mjs:47`), so it stays in the denominator (no skip). The 7 N/A cases are registered with `notApplicable(…)` as in `accountLedger.mjs`.

## 7. What happens to the old report

`cashBook` (`reports2.ts:23`), `GET /reports/cash-book`, its `REPORT_BUILDERS` entry and the generic page keep working unchanged: no menu or key points at them after the screen packet. Removing them touches
`txn.ts`, `routePolicy.ts`, `reportAuthorization.ts`, `desktopRightsCaptions.db.test.ts`, `browser.smoke.mjs`, so it is a later slice after the supervisor decides (decision 6). Until then `browser.smoke.mjs:1500` is changed by tests-ui to expect `/reports/cash-bank`.

## 8. Risks (money, tenant isolation) and the case that catches each

| Risk | Case |
|---|---|
| Another company's, location's or tenant's lines enter the opening or the total | scope.company-sentinel, scope.location-sentinel (DB); run also as a second tenant in the DB file |
| Opening uses `<=` or the detail `>` (a boundary day lost or counted twice) | balance.date-boundary-from-inclusive, filter.date-window-from |
| Totals leave out the opening | balance.totals-row, balance.totals-include-opening |
| Sign reversed (Dr shown as Cr) | balance.opening-row, opening-cr-side, running-side |
| Voucher with two lines shown twice, or two vouchers merged (grouping key wrong) | row.grouping-one-row-per-voucher, balance.zero-net-row-blank |
| Book filter applied to the detail but not the opening (or the reverse) | filter.book-filter |
| Other accounts leak in (`ILIKE` style match) | filter.one-account-only |
| Party name from the wrong table | row.party-name-counter-party, row.party-name-sales, history.live-party-name |
| Print and Excel open without the print right | rights.excel-no-print (DB, both Print and the three exports), PRN |
| Print differs from the screen (own opening query) | print.opening-amount-unfiltered, print.totals-and-closing |
| Float drift in sums | balance.totals-include-opening (0.10 + 0.20 vector); balance.seed-a-hand-totals |
| `enforceReportFilters` refuses `acCode` (page shows an error) | every UI case; DB `GET` with `acCode` returns 200 |

## 9. Packets, order, parallelism

`tests-db` and `tests-ui` can run at once (disjoint files). `tests-print` waits for `tests-db` (it imports `test/support/cashBankSeed.ts`); `tests-ui-io` waits for `tests-ui` (it imports its kit and adds one line to the module). `api` waits for `tests-db` (the route contract is fixed in section 2, so it may start from the contract; the supervisor decides).
`print` waits for `api` and `tests-print`. `screen` waits for `api`, `tests-ui` and `tests-ui-io`; it can run beside `print` (disjoint files). `review` waits for all. A `records` packet (catalog, backlog) is not part of this plan.
Serial reason: `api` and `print` share `routes/cashBankReport.ts` (print adds its two routes there); `tests-ui` and `tests-ui-io` share helpers.

## 10. Decisions made here that the owner may change (also in the report)

1. Date change does not refill the grid (desktop). 2. Name box read-only; no Delete button. 3. No year filter and no data-type filter on the screen or print (both blocked in `cases.md`). 4. Year: the print's year filter is not ported, so screen and print agree.
5. Print refusal uses the Excel text. 6. Old `cash-book` route and page stay for now. 7. Seed voucher 7 shares one `LEDR_KEY`. 8. Tie-break `VCH_NO, LEDR_KEY` after the desktop order. 9. API requires `acCode`, `fromDate`, `toDate`. 10. Print is html first, then PDF.
