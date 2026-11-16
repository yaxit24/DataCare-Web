# WP-18 design: Report → HuId Report (`huid-report`)

Inputs: `study.md` (desktop `RP_HUID.cs`, cited by line there), `cases.md` (90 cases, 69 executable), and the eight decisions in
`orchestration/packets/WP-18.cases.md`. This document cites the study and the case list instead of re-deriving. Desktop line numbers below
point at the study's quotes. The report is read-only: it writes nothing, so none of the desktop's `BAR_DETL` updates, the shared
`TAG_STOCK_PRINT` table or the global drill-down state is ported (study "Desktop weaknesses" 1 to 4, 10).

## 1. Resolver

New file `web/apps/api/src/modules/reports/huidTagReport.ts` (about 280 lines). The old `huid.ts` (`huidReport`, tabs all/stock) stays untouched
so `p9Reports.db.test.ts` and `REPORT_BUILDERS.huid` keep compiling; it is no longer reached by the screen or the exports (Question 3).

**Input.** `huidTagReport(prisma, scope, q)` with `scope = {tenantId, coCode, lcCode, coYear}` from the session (never from the query) and
`q = { view: 'stock'|'in'|'out', from?: 'YYYY-MM-DD', to?: 'YYYY-MM-DD', itemType?: 'G'|'S', product?, group?, tagNo?, acCode?,
hallmark?: 'all'|'with'|'without', search?: string }`. All values are bound parameters (`$n`), never joined into the SQL (rule 8; study weakness 5).
Run inside `withTxBudget(prisma, tenantId, 'read', ...)` as `huid.ts` does, and also filter `tenant_id = $1` on every table (row-level
security is the first fence, the explicit filter the second).

**Common conditions** (study "Base query per view" table, `RP_HUID.cs:1761`, `:1795`, `:1838`): company, location, year equal the session's; `TAG_NO <> 'N'`;
`B.IT_TYPE = itemType` when given (first letter of the box, `RP_HUID.cs:1778`); `B.PR_CODE`, `B.GR_CODE` when given (`:1770-1781`, `:1813-1823`);
`TAG_NO = tagNo` exact (`:1782-1785`); `AC_CODE = acCode` (`:1786-1789`; on `C` for In and Stock, on `A` for Out); `ITEM_MAST B` is a LEFT JOIN on
`CO_CODE` and `IT_CODE`. No Counter, no Item-code filter (decision 7). No data-type condition (company type `C`; the other codes are blocked, Question 4).

| View | Driving rows | Date | Movement |
|---|---|---|---|
| `in` | `BAR_DETL c` (`:1761`) | `c.VCH_DATE` between `from` and `to`, both inclusive | none |
| `out` | `MAIN_STOCK a` joined to `BAR_DETL c` on company, location, `TAG_NO`, `VCH_SRNO` (`:1795/:1799`) | `a.VCH_DATE` between `from` and `to` | `a.ITM_SIGN = '-'` |
| `stock` | `BAR_DETL c` joined to the movement subquery below (`:1838`, join also on `IT_CODE`) | `c.STK_DATE <= to` only; `from` is ignored | `HAVING` sum `> 0` |

**Stock rule in PostgreSQL** (decision 2, `RP_HUID.cs:1873`): the HAVING is moved into a grouped subquery so `BAR_DETL` columns need no GROUP BY:

```sql
JOIN (SELECT m."CO_CODE", m."LC_CODE", m."TAG_NO", m."VCH_SRNO", m."IT_CODE"
        FROM "MAIN_STOCK" m
       WHERE m.tenant_id=$1 AND m."CO_CODE"::text=$2 AND m."LC_CODE"::text=$3 AND m."CO_YEAR"::text=$4 AND m."TAG_NO"::text <> 'N'
       GROUP BY m."CO_CODE", m."LC_CODE", m."TAG_NO", m."VCH_SRNO", m."IT_CODE"
      HAVING SUM(CASE WHEN m."ITM_SIGN"::text='+' THEN coalesce(m."VCH_SRNO",0) ELSE -coalesce(m."VCH_SRNO",0) END) > 0) s
  ON s."CO_CODE"=c."CO_CODE" AND s."LC_CODE"=c."LC_CODE" AND s."TAG_NO"=c."TAG_NO" AND s."VCH_SRNO"=c."VCH_SRNO" AND s."IT_CODE"=c."IT_CODE"
```

It sums serial numbers, not counts (the desktop rule, not a defect). Copy the cast style (`::text`) from `huid.ts`. The column names above are from the
desktop SQL; the worker checks each against `web/apps/api/prisma/schema.prisma` (or the migration) before use and reports a mismatch as a finding.

**HUID filter** (decision 5, gap 10): `With` = `btrim(coalesce(c."HM_ID",'')) <> ''`; `Without` = the negation; slots 2 to 4 never count. A whitespace-only
`HM_ID` is therefore absent. The desktop writes `<> ''` and SQL Server ignores trailing spaces, so this matches it; the case is blocked (Question 2).

**Order** `c."TAG_NO"` then `c."VCH_SRNO"` (the desktop gives no order inside a tag; the web keeps its fixed one, gap 16).

**Search** (`search`, gaps 15 and 20): applied in TypeScript after the query by one exported pure function `applyHuidSearch(rows, text)`, so the screen and every
export agree. Desktop rule (`RP_HUID.cs:1669-1689`): try HuId, HuId2, HuId3, HuId4 in order and keep the rows matching the first column that has any match (case-insensitive,
substring, the text is literal, so an apostrophe or `%` is harmless); no match in any column gives zero rows.

**Row shape** (24 desktop columns in the SELECT order, `RP_HUID.cs:1761`): `coCode, vchTyp, vchNo, vchDate | stkDate, tagNo, itCode, counter, qty (literal 1),
pcs, grwt, netWt, huId, huWt, huId2, huWt2, huId3, huWt3, huId4, huWt4, krName, book, bookName, itRemark, tagId`. In and Out rows carry `vchDate` (Out: the movement's
date `a.VCH_DATE`, `ItCode`/`Pcs`/`Grwt`/`NetWt` from `a`, `krName` the empty string); Stock rows carry `stkDate` as the visible date column and also `vchDate`, marked hidden, because the print selection needs it (section 4). Every row also carries hidden `prCode` and `grCode` (`B.PR_CODE`, `B.GR_CODE`) for the print grouping. Weights are returned as decimal strings with the
database's own scale (no `r3` rounding: gap 29). Hidden columns are marked, not removed: `coCode`, `book`, `bookName` (`:2031-2046`). The registration-specific `StkDate` hiding is not ported.

**Totals**: `qty, pcs, grwt, netWt, huWt, huWt2, huWt3, huWt4`, each the sum of the rows after search (`:2068-2096`), summed as decimals (never floating point): use the
decimal type already in `web/packages/core` or convert with integer thousandths; the packet says which. Qty total equals the row count.

## 2. API

New plugin `web/apps/api/src/routes/huidReport.ts`, registered by `registerHuidReportRoutes(app, { prisma, auth, guard, readScope, sendReportPdf })` exactly like
`registerAccountLedgerRoutes` (`txn.ts` near line 4510). The one allowed edit of `txn.ts` replaces the three-line `app.get('/reports/huid', ...)` with that one registration call.

| Route | Right (menu caption `Reports/HuId Report`) | Output |
|---|---|---|
| `GET /reports/huid` | view (the route policy) | JSON `{view, from, to, columns:[{key,header,hidden,total}], rows, totals}` |
| `GET /reports/huid/export.csv`, `.xlsx`, `.pdf` | view and `guard(req, reply, 'print')` first | file; same query, same resolver |

Query validation (400 with `{error:'validation', message}` on failure): `view` required, one of the three; `from`, `to` real ISO dates (blank or malformed is refused: the desktop behaviour
depends on `DC_Main.SetDate`, unread, Question 5); `in` and `out` need both, `stock` needs `to`; `from` after `to` is not an error and returns zero rows (case `invalid.from-after-to-empty`);
`hallmark` in the three values; `itemType` in `G`,`S`; `tagNo`, `acCode`, `product`, `group`, `search` strings of at most 40 characters (search at most 60), trimmed; `tagNo` and `acCode` upper-cased.
Unknown parameters (`counter`, `itCode`, `tab`) are ignored, so they cannot filter (cases `counter-absent`, `item-code-absent`).
Scope: tenant, company, location and year only from `readScope(req)`. `routePolicy.ts:984` gains the three export paths on the same `Reports/HuId Report` caption. The print refusal is the existing
guard (`txn.ts:921-929`, 403 `{"error":"forbidden","action":"print"}`); the on-screen text "You Have No Print Rights....." is the page's job (section 3).

## 3. Page

Directory `web/apps/web/app/(app)/reports/huid/` (static, so it wins over `[report]`): `page.tsx` (layout, keys, under 300 lines), `useHuidReport.ts` (state, fetch, search, lookups),
`HuidGrid.tsx` (grid, totals row), `types.ts`. Modelled on `reports/account-ledger/`. Nothing is added to the generic page; its dead HUID block (`page.tsx:203-206`, `:351-357`, `:1388-1433`, `:1577-1581`)
may be deleted in the screen packet because the static route shadows it, but need not be.

- **Title** `Tag Stock With HuId` (`RP_HUID.cs:1067`; owner may change, Question 6). **Controls in desktop tab order** (`study` Screen table): From date, To date (both open on today's system date,
  masked `dd/mm/yyyy`), Search box, Item Type (Gold, Silver; opens on Gold), Product, Group, Tag No, grid, then `&Stock Tag`, `&In Tag`, `&Out Tag`, HuId Type (All, With HuId, Without HuId), Ac Code.
  Bottom buttons: `&Print`, `&Excel`, `&Cancel` (clears filters, dates, search and grid), `E&xit`. No Delete button (its click does nothing on the desktop). Tab-order ties are blocked (Question 7); use the order above.
- **Mnemonics** Alt+S, Alt+I, Alt+O run Stock, In and Out; Alt+P, Alt+E, Alt+C, Alt+X as the desktop `&` captions. The grid is empty until a view button is clicked and stays empty with no message when a run returns nothing.
- **Keys**: Enter in From moves to To; Enter in To moves to the next field; date text is selected on focus; typed letters are upper-cased in Tag No and Ac Code; Enter in Tag No looks the tag up and opens the existing
  tag help when absent, Enter in Ac Code does the same with the account help (reuse the lookups the other screens use); Esc closes (back to the previous page); Up and Down arrows move focus to the grid; the From date has focus on open.
- **Grid columns per view**: the 24 columns of section 1 in order; `coCode`, `book`, `bookName` hidden; header text is the desktop alias (`VchTyp`, `HuId2`; case blocked, Question 6); Stock shows `StkDate` where In and Out show `VchDate`.
  Last row of totals for the eight summed columns. Double-click drill-down is blocked (Open question 4); the grid emits no handler.
- **Print right**: Print, Excel and PDF buttons call the export; a 403 `action: print` shows the message `You Have No Print Rights.....` in the page's existing message area and leaves the grid unchanged.

## 4. Print and export

CSV and Excel carry the visible (non-hidden) columns of the current result with the search applied, weights as numbers, codes and dates as text (copy `columnsFor` in `routes/accountLedger.ts`). The PDF is the
`TagHuIdRpt` layout: title `Tag Wise Huid Report As on Date dd/MM/yyyy` (the To date, `RP_HUID.cs:2192`); regions page header (title, company), group headers by product then group (`ITEM_MAST.PR_CODE`, `GR_CODE`;
`TagHuIdRpt.xml:312-313`), detail line (tag, item, counter, pcs, gross, net, the four HuId/weight pairs), group footer sums of the weights, report footer sums. Rows are the grid rows as shown (search applied) with the
print selection `VCH_DATE <= To` on top (`RP_HUID.cs:2219`, case `output.print-stock-date-to-filter`). The formula arithmetic of `@TagQty` and the others is unknown (blocked): plain sums are used.
The export builds a spec like `web/apps/api/report-specs/TagHuIdRpt.spec.json` through `sendReportPdf`. The rights check is `guard(req, reply, 'print')` before any query (decision 3, a deliberate difference from the desktop).

## 5. Case to layer and packet

Layers: **db** = `web/apps/api/test/huidReport.db.test.ts` through the real route (packet `tests-db`); **ui** = the browser module (`tests-ui-a`, `tests-ui-b`, `tests-ui`). Several browser cases are also pinned at db level
for speed; the "also db" mark means tests-db carries a copy. Blocked and N/A cases are recorded in the module as `applicable:false` or skipped-with-reason entries by `tests-ui`; they are not run.

| Group (all executable cases of the list) | Layer | Packet |
|---|---|---|
| huid-report.entry.menu-opens-three-views, huid-report.entry.default-dates-today, huid-report.entry.default-item-type-gold, huid-report.entry.default-hallmark-all, huid-report.entry.grid-empty-before-first-view, huid-report.entry.blank-product-group-tag-account | ui | tests-ui-a |
| huid-report.filter.in-date-window, huid-report.filter.out-date-window, huid-report.filter.stock-to-date-only, huid-report.filter.hallmark-with-first-slot, huid-report.filter.hallmark-without-first-slot, huid-report.filter.tag-no-exact, huid-report.filter.tag-n-excluded, huid-report.filter.item-type-silver, huid-report.filter.product-ring, huid-report.filter.group-link, huid-report.filter.counter-absent, huid-report.filter.item-code-absent, huid-report.filter.search-first-column-set, huid-report.filter.search-second-column-match, huid-report.order.tag-no-ascending | ui, also db | tests-ui-a, tests-db |
| huid-report.filter.hallmark-slot-two-to-four-counts-as-without | db | tests-db |
| huid-report.total.in-window-sums, huid-report.total.out-window-sums, huid-report.total.stock-rule-srno-zero, huid-report.total.stock-rule-sold-and-returned | ui, also db | tests-ui-a, tests-db |
| huid-report.total.stock-rule-sum | db | tests-db |
| huid-report.invalid.from-after-to-empty, huid-report.invalid.empty-result-no-message, huid-report.invalid.search-apostrophe-no-error | ui, also db | tests-ui-a, tests-db |
| huid-report.lookup.tag-no-found-focus-stays, huid-report.lookup.tag-no-missing-opens-help, huid-report.lookup.account-found-selects-text, huid-report.lookup.account-missing-opens-help, huid-report.lookup.account-filter-in-view | ui | tests-ui-b |
| huid-report.drill.double-click-opens-source-voucher | ui | tests-ui-b |
| huid-report.scope.other-company-never-appears, huid-report.scope.other-location-never-appears, huid-report.scope.prior-year-tag-never-appears | ui, also db | tests-ui-b, tests-db |
| huid-report.scope.other-tenant-never-appears, huid-report.rights.view-refused-without-view-right | db | tests-db |
| huid-report.rights.print-refused-without-print-right | ui, also db | tests-ui-b, tests-db |
| huid-report.rights.print-refusal-text, huid-report.concurrency.two-users-export-independent, huid-report.history.group-renamed-live-master | ui | tests-ui-b |
| huid-report.write.view-leaves-bar-detl-unchanged, huid-report.write.print-leaves-no-staging-rows | db | tests-db |
| huid-report.output.excel-follows-search, huid-report.output.csv-matches-grid-totals, huid-report.output.columns-desktop-order, huid-report.output.stock-date-column, huid-report.output.out-kr-name-blank, huid-report.output.coCode-book-hidden-when-merge-n | ui | tests-ui-b |
| huid-report.output.print-title-and-grouping, huid-report.output.print-rows-follow-grid-search, huid-report.output.print-stock-date-to-filter, huid-report.output.pdf-whole-result-beyond-page | ui | tests-ui-b |
| huid-report.keys.enter-from-date-moves-to-to-date, huid-report.keys.enter-to-date-moves-next, huid-report.keys.focus-from-date-on-open, huid-report.keys.date-text-selected-on-focus, huid-report.keys.alt-mnemonics-run-views, huid-report.keys.escape-closes, huid-report.keys.arrow-moves-to-grid, huid-report.keys.typed-upper-case, huid-report.keys.cancel-clears-screen | ui | tests-ui-b |
| huid-report.journey.stage-1-tags-and-purchase-in-view, huid-report.journey.stage-2-sale-out-and-stock, huid-report.journey.stage-3-return-views-agree | ui | tests-ui |

Built by: `api` (resolver, JSON route, views, scope), `print` (CSV, Excel, PDF, print right), `screen-data` and `screen` (page). Blocked (15) and N/A (6) entries: `tests-ui` records them with their reasons; no packet builds them.

## 6. Risks (what could silently corrupt a result) and the case that catches each

| Risk | Caught by |
|---|---|
| Another tenant's, company's or location's rows in a list (a missing `tenant_id` or `LC_CODE` condition, a scope taken from the query) | scope.other-tenant-never-appears (db), scope.other-company-never-appears, scope.other-location-never-appears |
| A prior year's tag listed (no `CO_YEAR` filter; the old web had none) | scope.prior-year-tag-never-appears |
| Stock built as a net count instead of the serial sum, or the HAVING moved into WHERE | total.stock-rule-sum, total.stock-rule-srno-zero, total.stock-rule-sold-and-returned |
| Stock bounded by `from`, or by voucher date instead of stock date; In/Out date window off by one (inclusive ends) | filter.stock-to-date-only, filter.in-date-window, filter.out-date-window (TG-014/TG-015 boundaries) |
| Tag `N` listed; a sold-and-returned tag listed as Out twice | filter.tag-n-excluded, filter.out-date-window |
| "With HUID" counting slots 2 to 4 | filter.hallmark-slot-two-to-four-counts-as-without |
| Weights summed as floating point or rounded, so totals drift from the grid | total.in-window-sums, total.out-window-sums, output.csv-matches-grid-totals |
| Export disagrees with the grid (search ignored, other date rule) | output.excel-follows-search, output.print-rows-follow-grid-search |
| A read action writing `BAR_DETL` or a staging table | write.view-leaves-bar-detl-unchanged, write.print-leaves-no-staging-rows |
| Export open to a user without the Print right | rights.print-refused-without-print-right |
| SQL built from typed text (tag, account, search) | invalid.search-apostrophe-no-error |

## 7. Packets, order and parallelism

`tests-db`, `tests-ui-a` start at once (different files, no shared writer). `tests-ui-b` waits for `tests-ui-a` (it imports its seed helper). `tests-ui` waits for `tests-ui-b` (it registers both). `api` waits for `tests-db` (the tests exist first).
`print` and `screen-data` wait for `api` and may run in parallel (print: API routes file and spec; screen-data: web hook and types). `screen` waits for `screen-data`, `print` and `tests-ui`. `review` runs last.
Shared files: `routePolicy.ts` and `txn.ts` are edited by `api` only (`print` adds only to its own route file and the policy list, so it runs after `api`, never beside it).
No database or browser test can run on this machine (no Docker): the test packets list what CI must run; implement packets are gated on `pnpm typecheck` only, and CI is the proof.

## 8. Decisions the owner might change

See the report's "Questions for the supervisor": new resolver beside the old `huid.ts`; whitespace HUID; company filter always on; Print and view refusal; header text; tab ties; search server-side; decimal strings for weights.
