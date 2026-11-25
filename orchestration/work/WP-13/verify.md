# WP-13 verify: Report → Approval Rpt (desktop `RP_ALL`, caption "Approval Rpt")

Plan ids: **N254** (slice), **G266** (gap). Branch `agent/wp13-approval-report`. Nothing here is accepted; desktop
match is 0% (no original-Windows comparison was run).

## What was built

- **API** (earlier commits, reviewed and fixed in a7dad758): the three PanelApr modes on the shared RP_ALL engine —
  `rpAll/approvalLayouts.ts` (AprPartyWise party → voucher bands with "Party Total :" and no grand total; AprInOut
  party → product → date → tag; AprPan party → voucher → product → tag with the zero tag-footer suppression; both
  with "Grand Total :"), `rpAll/approvalQuery.ts` (parameterised SQL, live master names, exact ISU_REC N for
  Pending, server-only A/B data type), `GET /reports/approval-report` and CSV/XLSX/PDF from the same result.
- **This step:** `exportRows.ts` now follows the engine's effective band placement, so a suppressed AprPan tag footer
  prints no empty "Total" line in CSV/XLSX (the screen does the same).
- **Screen** `web/apps/web/app/(app)/reports/approval-report/` (takes the route from the generic `[report]` page):
  caption `Approval Rpt`; `&Approval Isu` / `&Approval InOut` / `&Approval Panding` with the A mnemonic underlined;
  From `01/01/2010`, To the system date, focus on From, SelectAll on focus; Enter runs `DC_Main.SetDate` through the
  shared `@datacare/core` rule (`Date Not Valid...`, `Month Not Valid...`, silent single digit) and refuses any
  calendar-impossible date the desktop would crash on (D7); lc Code locked outside 00; Book / Pr Code (PRODUCT_MAST,
  blank jumps to City) / Gr Code (help even on blank) / Party Code lookups with stale-answer protection; Cust Name
  Enter clears and jumps to City and is never sent; City/Area from distinct live AC_MAST values; Item Type list
  verbatim with blank selected; Cancel = CLEAR_DATA (combos kept, session location still enforced server-side);
  Save/Delete/Print inert; Esc and Exit close; "Report Preview - <template>" caption over the titled grid.
- **Browser module** `web/apps/web/test/features/modules/approvalReportRp.mjs` (feature `approval-report`),
  registered in `run-features.mjs` and `coverage-map.json`.

## Run evidence

Build: `pnpm --filter @datacare/db db:generate && pnpm --filter "@datacare/api..." run build &&
API_ORIGIN=http://127.0.0.1:4690 pnpm --filter "@datacare/web..." run build` — exit 0.

Browser module, under the shared stack lock, after merging origin/main (candidate `7faa8c16` plus the working
SetDate change):

```
PARITY_TEST_PORT=55690 PARITY_API_PORT=4690 PARITY_WEB_PORT=4691 FEATURE_E2E_MODULES=approval-report \
  node scripts/parity-test-env.mjs -- node apps/web/test/features/run-features.mjs
=== approval-report: Report → Approval Rpt (RP_ALL) (67 cases) ===
  -> applicable 35, passed 28, failed 0, blocked 7, untested 0; browser pass 80%
FEATURE_E2E_PASSED
```

run.json: startedAt 2026-11-23T14:19:11.925Z, finishedAt 2026-11-23T14:19:28.696Z. The same 28 also passed before the
merge (candidate `a7dad758`). No console errors (the harness fails a case on any).

API tests on the isolated database: `node scripts/parity-test-env.mjs -- pnpm --filter @datacare/api exec vitest run
test/rpAll test/reportScreens.routes.db.test.ts` → 6 files, 86 tests passed (includes `rpAllApproval.test.ts`,
`rpAllApproval.db.test.ts`, the Sales branch and the export change).

Gates: `pnpm typecheck` OK, `pnpm typecheck:tests` OK, `pnpm format:check` OK (prettier applied to
`rpAllApproval.test.ts` from a7dad758), eslint clean on the changed web files,
`node scripts/generate-edition-table.mjs --check` → `EDITION_TABLE_OK`, `check-completion-register.mjs` →
`REGISTER_OK`.

## Disposition of the 67 case headings (64 cases + 3 N/A groups)

| Group | Browser pass | Blocked | N/A (pointer) |
|---|---|---|---|
| T01 | 7 (menu caption/panel, three buttons, date defaults, location lock incl. 00 clear-all, selector set, selector lists incl. a new live city, view-right gate) | 0 | 0 |
| T02 | 1 (ignored selectors) | 1 data-type-setting-source (D3) | 7 (6 DB, data-type-selection unit) |
| T03 | 0 | 0 | 6 DB |
| T04 | 5 (book, product, group, location, cancel/stale) | 1 party branch setting | 0 |
| T05 | 0 | 1 null-tag footer (D2) | 5 DB |
| T06 | 3 (Date Not Valid, Month Not Valid, SetDate completion) | 0 | 3 DB |
| T07 | 1 (issue through the Approval Issue screen appears in all three modes) | 0 | 0 |
| T08/T09/T14 | 0 | 0 | 3 (no saved report document / no write set) |
| T10 | 2 (Cancel clear-data, Save/Delete/Print no-op + Exit) | 0 | 0 |
| T11 | 0 | 0 | 3 DB |
| T12/T13 | 0 | 0 | 3 DB |
| T15 | 0 | 1 setting-between-runs (MsAllBranchAcShow; live City half proved in T01) | 1 DB |
| T16 | 5 (three layouts/titles with seeded totals, grid = CSV line for line + XLSX + PDF over a >30-line run, preview caption) | 2 numeric display (D1), drill-down (D2) | 0 |
| T17 | 3 (tab order + Enter walk, Esc + uppercase/apostrophe, mnemonics) | 0 | 0 |
| T18 | 1 (issue → return → delete return through the screens; InOut/Pending follow ISU_REC) | 1 sale consume/reverse | 1 DB custody reconcile |

## Blocked, with the exact question

1. `filters.data-type-setting-source` — which approved company/session setting supplies the A/B MsDataType to the
   engine? (D3; the engine already accepts it from the server scope only.)
2. `lookup.party-enter-and-branch-setting`, `history.setting-between-runs` — which setting carries
   MsAllBranchAcShow, and should a non-00 branch with N see only codes < 100 plus its own codes ≥ 200? The web help
   lists every company account (the desktop Y branch).
3. `grouping.null-tag-footer`, `output.numeric-display-precision`, `output.drilldown` — need original-Windows runtime
   evidence (Crystal null grouping, printed decimals/ties, built-in drill-down).
4. `journey.sale-consume-reverse` — the Sales Invoice screen has no approval import and `POST /tour/:vchNo/bill`
   stays a fail-closed 409; unblocks with that work package.

## Deliberate differences (from cases.md decisions)

Session-year filter kept (D4); legacy `R` counts as resolved and the provisioned `APPROVAL ISSUE` book family is
accepted (D6, the current web return writes `Y`); malformed and calendar-impossible dates refused (D7); view/print
guards kept (D10); MsAlterYear/UAE SetDate variants not ported (no web setting); the Book help lists company books
(sorted by name) without the desktop's session-location restriction.
