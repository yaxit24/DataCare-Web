# REPORT ADDENDUM — read after 00-GENERIC.md when your menu is a Report-tab menu

A report writes nothing, so the voucher parts of the generic method (T07–T10, T12–T14) become **filters, totals,
drill-down and output**. The standard of proof is higher, not lower: a report is only right if its numbers equal the
numbers you get by adding up the vouchers *you created through the screens*.

## What replaces the voucher matrix

| Group | Report version |
|---|---|
| T01 entry | Open through the **navigation** (Report tab → the menu caption). Every selector the desktop form shows (dates, party, book, product, group, item, tab/mode radio, grouping, "all" boxes) with its default; hidden/shown by edition (Lite) and by setting. Rights are `----PL` (Print, List): a user without them is refused by the **API**, not only hidden. |
| T02 field route | Each filter changes the result the way the desktop's SQL does: change one filter, assert the exact row set (ids), not "some rows". |
| T03 formula | Every total, sub-total, grand total, weight/fine/amount column, rounding stage and sign convention, computed **by hand from the vouchers**, per mode. |
| T04 lookup | Party/item/book helps: F1, type-ahead, cancel, stale response. |
| T05 children | Grouping and drill-down: group headers, nested levels, zoom to the voucher (and to the ledger where the desktop has it), back. |
| T06 invalid | From > To date, a date outside the year, nothing selected, empty result: the desktop message or empty-grid behaviour, and no crash. |
| T11 scope/rights | A sentinel voucher in another company, location, year, book and tenant **never appears**, in the grid, the totals, the drill-down or the export. A user without Print cannot print; without List cannot list. |
| T15 history | Change a master (party name, item group) after the voucher; an older year; an edited and a deleted voucher; a cancelled tag: the report follows the desktop's rule (snapshot vs live master). |
| T16 output | On-screen grid, PDF, CSV/Excel, print window: same rows and totals as the grid, desktop column order and captions, named Crystal template (`*.rpt` in the repo root / `zip_contents/`, XML in `extraction_output/rpt_xml/`) reproduced semantically. Print windows must refresh the session (N173). |
| T17 keyboard | Run it with the keyboard only. |
| T18 journey | **The core of the report cases.** Create the source vouchers through their real screens in the same run (Sales, Purchase, Cash/Bank, Contra, Tag Opening, Approval, Order …, each already has a feature module you can copy setup from), run the report, reconcile to the hand-computed expectation; then **edit one voucher, delete one, cancel one tag, return one sale, and run it again**: the report must follow each step exactly. |

## Report implementation rules

- **Do not extend `app/(app)/reports/[report]/page.tsx`** (1,742 lines, at its size ceiling). Give the report its own
  route directory with a page ≤ 600 lines plus `types.ts`, a data hook and a grid component, exactly like
  `app/(app)/reports/account-ledger/` in PR #195 (`AccountLedgerGrid.tsx`, `useAccountLedger.ts`, `types.ts`). Register
  the API routes in a **new** file under `apps/api/src/routes/`, not in `routes/txn.ts` (8,360 lines, at its ceiling).
- If your report shares an engine with a sibling menu (several menus are the same desktop form with a different caption —
  `RP_ALL` serves Sales Report, Purchase Rpt and Approval Rpt), put the shared selector/filter/grouping code in a shared
  module and **say so in the PR**. If a sibling's PR already merged it, reuse it; do not copy it.
- Totals are computed once, server-side, with the same core kernels the voucher writers use. The grid never re-derives
  money client-side.
- Reports read through `withTenant`; every query is keyed by company, location, year (and book where the desktop does).
  Unscoped `SELECT` is a defect.
- A report's catalog row stays `REPORT` status in the catalog vocabulary until every case passes and no gap is open;
  then it becomes `FULL`. If the Crystal template is missing from the repository, the output case is **blocked with that
  reason** (and stays in the denominator), not N/A.
- Large results: the desktop loads everything; the web may page, but totals and the export must cover the **whole**
  result, and a test must prove it with more rows than a page.
