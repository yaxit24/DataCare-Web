# WP-02B generic report authorization implementation evidence

**Date:** 2026-08-29
**Plan:** `EXACT-END-TO-END-PARITY-PLAN-2026-08-29.md`
**Work package slice:** WP-02B — P0-02 generic report route authorization
**Status:** implemented and validated in the current working tree; independent final audit passed; no commit created
**Claim boundary:** this closes the **P0-02 authorization defect and its stated exit criteria**. It does **not** close P0-03, P0-04, the rest of WP-02, report DATA parity (P1-06/WP-13 remain at zero desktop comparisons), or production readiness.

## 1. Defect replaced

`routePolicy.ts` mapped the three generic report endpoints to fixed, unrelated forms:

| Route                              | Previous form right   | Correct form right       |
| ---------------------------------- | --------------------- | ------------------------ |
| `GET /reports/:report/export.xlsx` | Reports/Sales Register | the requested report's own |
| `GET /reports/:report/export.csv`  | Reports/Tag Estimate  | the requested report's own |
| `GET /reports/:report/filters`     | Reports/Tag Estimate  | the requested report's own |

Consequences: a user holding Tag Estimate print rights could export **any** of the 48 reports as CSV, and a user with legitimate rights on their own report was denied unless they also held the unrelated form. Authorization did not depend on the slug being requested.

A first review round also found filter validation running as its own earlier `preHandler`, so an unsupported filter produced `400 ReportFilterError` **before** authentication or authorization could answer 401/403 — leaking which filters a report supports to anonymous callers.

## 2. What the code now does

- `reportAuthorization.ts` (new) holds `REPORT_FORM_BY_SLUG`: 48 frozen slug → canonical `Reports/*` entries, with `hasOwnProperty`-guarded lookup so inherited properties (`__proto__`, `constructor`, `toString`) never resolve.
- `routePolicy.ts` returns a dynamic `form: '@report'` policy for the three routes — `filters` → `read`, `export.csv`/`export.xlsx` → `print`, all `businessScope: true` — and `resolvePolicyForm` resolves `@report` through `reportFormForSlug`.
- `app.ts` runs one authorization hook in fixed order: `requireAuth` (401) → password-reset → business scope → form resolution (403 `unresolved`) → `authorizeForm` (403) → `routeAuthorized` → `enforceReportFilters` (400). Filter validation is now a function called at the end of that hook, not a separate earlier hook.
- `authorizeForm` requires `FRM_VIEW` for `read` and `FRM_VIEW` + `FRM_PRINT` for `print`, so an export needs View as well as Print. The administrator bypass executes only after a form resolves.
- `txn.ts` `REPORT_BUILDERS` is declared `satisfies Record<ReportSlug, ReportBuilder>`, so the registry and the authorization map cannot drift without failing the build.

## 3. Exit evidence

Required by the plan: _"Matrix test for every report slug and view/print right; cross-report negative tests return 403."_

| Check                                                                | Result |
| -------------------------------------------------------------------- | ------ |
| 48 builders ↔ 48 mapped slugs, exact bijection, no orphans           | pass — key-extraction diff: `builders_not_in_map: []`, `map_not_in_builders: []`, same order; also compile-enforced |
| Every slug's filters route requires that report's View                | pass — 403 `{form, action:'read'}` for all 48 with print-only rights |
| Every slug's CSV and XLSX exports require Print **and** View         | pass — 403 `{form, action:'print'}` for all 48 with view-only, and again with print-without-view |
| Unauthenticated request carrying an unsupported filter                | 401 `unauthenticated`, never a filter 400 |
| Wrong-report rights carrying an unsupported filter                   | 403 naming the **requested** report, never a filter 400 |
| Authorized request carrying an unsupported filter                    | 400 `ReportFilterError`, and no builder query issued |
| Cross-report negatives, both directions                              | 403 |
| Unknown / malformed / case-shifted / encoded-traversal / inherited slugs | 403 `{form:'unresolved'}` |
| Administrator bypass                                                 | 200 on a recognized slug, 403 `unresolved` on unknown/inherited |
| Denied paths reaching report builders                                | 0 database hits across ~300 denied requests (fixture throws on any builder query) |
| Static PDF/HTML and Crystal classifications                          | all `*-doc` routes `print` on their own report form; `/reports/layouts` and `/reports/layout` `read`, `/reports/render` `print` on Reports/Report Layouts (Crystal); `tag-stock.csv` and `karigar-ledger.print` `print` |
| Route universe                                                       | 401 declared routes, 0 unclassified, 0 slug ↔ static-screen mismatches |

Commands: `vitest run test/reportAuthorization.test.ts test/reportFilterGuard.test.ts test/routePolicy.test.ts` → 36/36 pass. `tsc -p tsconfig.json --noEmit` and `tsc -p tsconfig.test.json --noEmit` → clean. The matrix and fail-closed rows above were additionally reproduced by an independent probe run against the compiled build, outside the repository and not using the repository's own test files.

## 4. Residual gaps, explicitly not closed

1. `GET /gst/gstr1?city=…&state=…` returns 200 with the shared filters silently dropped: the filter guard is scoped to the `/reports/` path prefix and GSTR-1 is served from `/gst/`. Pre-existing, outside P0-02's criteria, and `gstr1` is not one of the 48 generic slugs. Belongs with P1-05 (one canonical report request object).
2. `POST /render/pdf` is classified `system`: any authenticated user may drive the Chromium HTML→PDF renderer with no form right. Content is caller-supplied so no stored data is exposed, but it is the one Crystal-replacement print surface not behind a print right.
3. `GET /reports/:report/filters` relies on the central hook plus `auth` and does not re-assert the route-local authorization marker the export handlers use. Behaviour is correct today; the asymmetry is defence-in-depth only.
4. **No report DATA parity is claimed.** P0-02 was about who may call these routes. The plan's zero retained desktop-vs-web report comparisons (P1-06, WP-13) are untouched by this work.

## 5. Files

- `web/apps/api/src/modules/reports/reportAuthorization.ts` (new)
- `web/apps/api/src/modules/rbac/routePolicy.ts`
- `web/apps/api/src/app.ts`
- `web/apps/api/src/routes/txn.ts`
- `web/apps/api/test/reportAuthorization.test.ts` (new)
- `web/apps/api/test/reportFilterGuard.test.ts`
- `web/apps/api/test/routePolicy.test.ts`
