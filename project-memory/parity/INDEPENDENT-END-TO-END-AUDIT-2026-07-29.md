# Independent DataCareNext Desktop-to-Web Parity and Production-Readiness Audit

**Audit date:** 2026-07-29  
**Repository:** `/Users/yakshitsavaliya/Desktop/imodule-extracted`  
**Desktop oracle:** `unified/src/csharp/DataCareNext/`, restored SQL Server schema/catalogs, Crystal reports, and tutorial evidence  
**Web implementation:** `web/`  
**Decision:** **NO-GO for real financial, inventory, statutory, or customer cutover**  
**Implementation assessment:** **substantial and broad, but partial; exact desktop parity is not established**

## 1. Executive decision

The web rewrite is a real ERP implementation, not a UI prototype. It has a Next.js application, a Fastify API, PostgreSQL/Prisma persistence, row-level tenant isolation, per-form authorization, session rotation/revocation, substantial transaction services, accounting and stock invariants, migrations, report infrastructure, deployment files, and hundreds of tests.

It is not yet a safe replacement for the desktop ERP. The decisive reasons are:

1. **Fresh-database runtime failure in a core workflow.** A clean database built from all 10 committed migrations fails tag opening because `web/apps/api/src/modules/stock/stockVoucherLifecycle.ts` writes `BAR_DETL.DM_WT` (and prepares `DM_RATE`/`DM_AMT`), while the migrated `BAR_DETL` table and current Prisma `BAR_DETL` model do not define those columns. The UTC-aligned isolated integration run passed 688 of 690 tests but failed both tag-opening tests with PostgreSQL `42703 column "DM_WT" ... does not exist`.
2. **No same-fixture desktop-versus-web execution exists.** The G5 artifact is `DEGRADED`: 15 fixed web vectors pass, but desktop SQL sigma, footprint, voucher-column, and calculation-recomputation checks are skipped. No desktop forms have been compared at runtime.
3. **Reporting is not a Crystal-equivalent runtime.** The binder supports only a small set of report families and defaults unknown reports to `SL_DATA`; the formula evaluator explicitly supports only a minimal subset and silently returns blank on parse failure; layout, grouping, suppression, pagination, copy semantics, fonts, barcode/image and printer fidelity are not desktop-compared.
4. **Logical restore is unsafe.** The in-app restore can clear every company in a tenant, silently truncate exports at 100,000 rows per table, replace binaries with `[binary]`, swallow row errors, and report conflicted rows as restored.
5. **Static depth is incomplete and unstable as a release metric.** The 09:45 matrix reports 96.5% static written-column coverage and five never-written tables; the 11:24 deep audit reports 98.2%; the immutable 08:10 snapshot reported 89.4% and eleven never-written tables. These tools use different/freshness-sensitive analyses and none proves runtime values or lifecycle equivalence. The fresh migration failure demonstrates why static percentages cannot authorize cutover.
6. **Production certification is zero.** G6 is explicitly `0/720`: production load/soak, deployed security, live observability/on-call, production DR, physical devices, customer-site UAT, live integrations, and authorized business sign-off are blocked/not executed.

A live migration today could compile, pass default tests, and still fail tag opening or silently diverge in voucher rows, fine weight, tax, stock/tag state, report output, historical reprint, or restore behavior. The correct decision is **NO-GO** until the P0 gates in §12 are closed with retained evidence.

## 2. Audit method and evidence limits

### 2.1 Evidence hierarchy

| Tier | Meaning | Current state |
|---|---|---|
| E0 | Artifact inventory | Strong: desktop forms/schema/reports and web routes/modules are cataloged. |
| E1 | Static source mapping | Broad but heuristic; useful for gap discovery, not parity certification. |
| E2 | Deterministic unit/contract tests | Strong for many web-authored rules; does not prove the desktop behaves identically. |
| E3 | Controlled web runtime | Partial; browser smoke passes but mocks all `/api/**` traffic. |
| E4 | Real local PostgreSQL integration | Freshly executed in this audit; 688/690 passed under UTC, with a real migration/schema defect in tag opening. |
| E5 | Same fixture through desktop and web | Missing: zero forms/workflows compared. |
| E6 | Production/site certification | Missing/blocked: 0/720 units certified. |

### 2.2 What was directly checked

- Canonical desktop evidence model, module map, form behavior/layout/logic catalogs, restored schema catalog, report reconciliation, integration scan, and tutorial knowledge base.
- Current web source trees for frontend pages/components, API routes/modules, Prisma schema/migrations/RLS, authentication/RBAC, reports, logical backup/restore, deployment, CI, and tests.
- Current generated matrix and depth summaries, while preserving their timestamps and conflicting freshness boundaries.
- Fresh lint, direct API/web unit tests, direct type checks, build/report/browser gates, compose syntax, and disposable-database migration/integration tests.

### 2.3 What could not be verified

- The Windows desktop executable was not run against a representative sanitized customer database.
- No reachable configured desktop SQL Server golden master or `G5_FORMS` paired-voucher fixture was available.
- No production-like dataset, customer deployment, physical scale/printer/scanner/camera, GSP, WhatsApp/SMS account, or live-rate provider was available.
- No authorized shop, finance, inventory/manufacturing, security, or deployment signers executed UAT.

Therefore this report can identify implementation evidence and blockers, but it cannot certify exact parity or production readiness.

## 3. Canonical desktop baseline

The canonical source is `unified/src/csharp/DataCareNext/`, not older duplicate source trees or design documents.

| Surface | Verified inventory | Evidence |
|---|---:|---|
| Canonical desktop classes/forms | 204 | `project-memory/catalogs/module-map.json` |
| Categories | 61 transaction, 33 master, 45 report, 22 utility, 43 other | module map |
| Posting workflows | 57 | module map/evidence model |
| Form behavior specifications | 204 | `project-memory/catalogs/form-behavior/` |
| Logic specifications | 172 | `project-memory/catalogs/form-logic/` |
| Layout specifications | 177 | `project-memory/catalogs/layouts/` |
| Grid entries | 6,973 | behavior index/evidence model |
| Keyboard events/bindings | 795 | behavior index/evidence model |
| Calculations | 3,309 | behavior index/evidence model |
| Validations | 1,849 | behavior index/evidence model |
| SQL Server tables/columns | 146 / 5,254 | `realdb-schema-full.json` |
| Defaults / identity columns | 2,355 / 0 | restored schema catalog |
| `CO_SET` keys | 57 | `settings-catalog.json` |
| Crystal `.rpt` binaries | 255 | `unified/reports/` |
| Extracted layouts | 254: 253 complete, 1 partial | report layout catalog |
| Unavailable supplied layout | `TagStkIdtlRpt` | report reconciliation |
| Additional code-referenced missing reports | 20 | `report-reconciliation.json` |
| Tutorial evidence | 30 transcripts / 1,069 keyframes | `project-memory/video-research/` |

The desktop is a keyboard-first WinForms MDI system. Its operational identity is a composite of company, location, year, book, and voucher number. The application assigns numbering, posts coordinated ledger/stock/tax/outstanding rows, performs physical coordinated reversals/deletes, and uses workflow-specific fine/tax/rounding rules. A web route, table, or CRUD form with similar names is not sufficient evidence of equivalent behavior.

## 4. Web architecture inventory

| Layer | Current implementation | Assessment |
|---|---|---|
| Frontend | Next.js 15.1.6, React 19, App Router, 101 generated pages in current build output | Broad route coverage; mixed dedicated and generic surfaces. |
| API | Direct Fastify 5.8.5, central app registration and route-policy classification | Substantial; root package description saying NestJS is stale. |
| Domain | Sales, purchase, finance, stock/tags, manufacturing/karigar/repair, Dhiran, scheme/membership, bullion/tour/VP, GST/e-invoice, utilities and reports | Real services exist; exact desktop outcomes remain unproved. |
| Database | PostgreSQL, Prisma 6.19.3, 10 migrations, raw SQL where needed | Substantial but migration/schema/source convergence is currently broken for tag opening. |
| Tenancy | `withTenant()` transaction-local `app.tenant_id`; forced RLS; restricted non-bypass role | Strong local control when correctly deployed. |
| Authentication | Argon2, access/refresh JWTs, persistent sessions, refresh rotation/reuse revocation | Stronger than desktop-era credential handling. |
| Authorization | Central route policy plus location/user/form `USER_SET` checks for view/create/edit/delete/print | Strong API control; frontend action-right behavior remains inconsistent. |
| Reports | 254 extracted specs, HTML/PDF renderer, binder and minimal formula evaluator | Useful reconstruction infrastructure, not Crystal parity. |
| Deployment | Root compose, production compose, Dockerfiles, migration/RLS/bootstrap docs, health/readiness | Compose syntax passes; production operations and exact deployment policy are not certified. |
| Tests | 99 API test files, web keyboard tests, browser smoke, CI database job, G5 harness | Broad web testing; default run skips DB suites and browser API is mocked. |

## 5. Quantitative parity status and caveats

The current 09:45 generated matrix covers 720 units: 204 forms, 146 tables, 275 report obligations (255 supplied plus 20 missing references), 57 settings, 13 shortcut groups, and 25 invariants.

### 5.1 Matrix gate state

- **Forms:** extracted 204/204; understood only 3 passed; implementation 193 in progress and 11 waived; depth 1 passed, 105 in progress, 25 evidence gaps, 73 waived; tested 98 in progress and 106 not started; desktop-compared 0/204; production-certified 0/204.
- **Tables:** 84 depth-passed, 25 in progress, 37 not started; desktop-compared and production-certified 0/146.
- **Reports:** 253 extraction-passed, one partial/in progress, one waived/unavailable, and 20 evidence gaps/blocked; desktop-compared and production-certified 0/275.
- **Settings:** 47 implementation-in-progress, 10 waived; 45 test-in-progress and 12 not started; desktop-compared 0/57.
- **Overall exact desktop parity:** 0 certified units. **Production certification:** 0/720.

### 5.2 Static persistence metrics are not a release score

The 09:45 matrix reports 3,540/3,669 desktop-written columns detected in web writers (96.5%), writers for 117/122 desktop-written tables, and five tables never written: `MENU_DATA`, `TAG_SET`, `TAG_DATA`, `APP_CHATMESSAGES`, and `WEBHOOKINBOX`. Its worst material tables include `TAG_STOCK` 0%, `POINT_DATA` 63.2%, `DHRN_ISU_DETL` 77.5%, `POINT_MEMB` 80%, `SL_ORD_ADJ` 80.6%, and multiple Dhiran/approval/finance tables below 90%.

The separately generated 11:24 deep audit reports 98.2%, while the immutable 08:10 report recorded 89.4%. These differences are caused by source movement and parser/mapping differences. They prove engineering progress and audit sensitivity—not runtime parity. The clean-database `DM_WT` failure was not prevented by the high static percentage.

### 5.3 Current high-risk transaction depth from the 09:45 matrix

- `TR_PURC`: 83.3% persisted-column coverage; 10 missing; 14.5% grid coverage.
- `TR_SALE_RTN`: 89.9%; eight missing; 9.1% grid coverage.
- `TR_TAG_SPLIT`: 93.2%; eight missing; 5.1% grid coverage.
- `TR_TAG_OPBL`: 95.9%; ten missing; 11.1% grid coverage—and fresh migration runtime failure.
- `TR_PURC_HM`, `TR_SALE_RTN_UAE`, `TR_WH_SALE` retain high-risk depth/grid gaps.
- Several forms show 100% static persisted-column coverage but very low grid capture ratios; those rows still require runtime field/keyboard/lifecycle proof.

The UI API-field audit reports 492/492 audited API fields capturable. This is useful but narrow: it does not cover every desktop control, hidden state, focus order, conditional field, precision rule, reopen/update/delete/print behavior, or all 204 forms.

## 6. Module-by-module parity matrix

| Business family | Desktop contract | Current web evidence | Status | Material gaps and required proof |
|---|---|---|---|---|
| Company, login, location, year, books, settings, users | Company/year seed, business context, 57 settings, book/account mappings, per-form rights | Auth/session/RBAC, context selection, provisioning, settings resolver, user admin | Partial | Full company form/defaults, all setting effects, year/balance transfer, book mappings, same-fixture seed and permission outcomes. |
| Masters | Party/account/group/item/product/tax/employee/labour/design/location/rate/stock limits with search grids, defaults, validation and print | Generic master configuration/service and generic page; dedicated party/year/auto-item/labour-update pages | Partial | Generic CRUD does not prove desktop layout, generated codes, dependent defaults, inline opening, form-specific keyboard/search/print, or side effects. |
| Retail sales | Tagged/loose lines, fine, labour, taxes, old metal, order/scheme, mixed tender, outstanding, ledger, stock, print/reversal | Large dedicated page/service, posting and lifecycle tests, tax/fine/rounding policies | Substantial but critical/uncertified | No E5; exact branches/settings, O/D/T invoice, report, tag restoration, field precision and keyboard flow need paired proof. |
| Sales return/order/order adjustment/cancel | Source linkage, advance and locked rates, return tag choice, order fulfillment, coordinated reversal | Dedicated pages/services and DB lifecycle suites | Partial/critical | Static depth gaps, no desktop runtime/PDF comparison, complex stone/diamond dependency and return/reissue behavior unproved. |
| Wholesale/hallmark/labour/UAE variants | Variant-specific tax, HUID/hallmark, labour dual-tax and wholesale stock/ledger behavior | Dedicated/shared pages and services; wholesale-return DB lifecycle passes under UTC | Partial | Variant sharing can conceal branch gaps; UAE/statutory and print outcomes remain unproved. |
| Purchase/purchase return/other purchase/commission/hedging | Purchase-specific fine/ghat/less-touch/fine-cut, input tax, payable, stock/tags, return and print | Large purchase service/page, return/commission services, extensive DB tests | Partial/critical | `TR_PURC` depth remains low; formulas differ from sales; no same-fixture stock/fine/tax/report/reversal proof. |
| Cash/bank/receipt/payment/contra/journal/bill allocation/bank reconcile | Balanced money ledger, bill allocation, cheque/bank data, rojmel, locks, print and reversal | Finance services, `assertBalanced`, lifecycle modules, DB suites pass under UTC | Substantial but partial | Desktop `ROJ_MEL_DATA`/`ROJMEL_BAL`, clearing, print, multi-line semantics and E5 control totals remain open. |
| Bullion/rate cut/fine/gold book/location amount | Money/fine settlement, fixing direction, configured accounts and reports | Dedicated services/pages; gold/location DB suites pass under UTC | Partial | Direction/configuration and report outcomes require representative desktop vectors. |
| Tags, opening, print, cancel, split, transfer, weight difference, lot | Exact tag identity, duplicate/consumption prevention, rich attributes, labels/images/HUID, signed stock, reissue | Stock lifecycle, tag staging/printing, multiple pages and tests | **Blocked by fresh defect** | `BAR_DETL.DM_WT` migration/schema mismatch breaks tag opening; tag table/depth residuals, printer labels, reissue policy and E5 remain. |
| Physical stock | Scan/count snapshot, variance classification, approval/reconciliation, possible tag/adjustment flow | Persisted count lifecycle and reconciliation APIs/pages; DB tests pass | Partial/critical | No site workflow proof, approval/reissue/business policy, device scan, report and desktop comparison. |
| Karigar/jobwork/repair | Metal issue/receipt, money/fine balances, stones/diamonds, labour/tax, images, customer/karigar linkage and reversals | Manufacturing/karigar and four repair workflows with substantial DB tests | Partial/critical | Fine direction, costing, subdetails, image/device behavior, print and E5 remain. Alias pages do not add independent parity. |
| Manufacturing/melting/lot/order/ghat | Material conservation, lot provenance, issue/receipt/output/loss/ghat/fine, tags and reports | Manufacturing and melting modules/pages; many DB tests pass under UTC | Partial/critical | Low static depth in parts, no desktop branch/rounding/stock/report proof, no production volumes or operator UAT. |
| Dhiran pledge loans | Principal/collateral issue, receipts, interest modes/day counts, outstanding, khata and settlement | Dhiran services/pages, settings and receipt DB tests | Partial/critical | Customer-specific interest configuration, collateral lifecycle, rounding, reports and same-fixture schedules unproved. |
| Membership/schemes/loyalty | Enrollment, installments, adjustment/redemption, sale linkage, passbook/points | Membership/scheme services/pages and DB tests | Partial | `POINT_DATA`/`POINT_MEMB` are low depth; loyalty triggers/reversal and statement parity remain unresolved. |
| Tour/approval/VP | Approval issue/return/order/sale, third-level details, stock provenance and adjustment | Tour, VP parcel and VP adjustment services/pages; DB suites pass under UTC | Partial | Full approval classification, report documents, third-level/reversal and E5 proof remain open. |
| GST/e-invoice/statutory | GST/VAT/TCS, GSTR reports, IRN generation/cancel, statutory documents | GST/e-invoice modules and deterministic transport/payload tests | Partial/externally blocked | Fake mode exists; no authorized GSP sandbox, GSTIN reconciliation, statutory sign-off or desktop-vs-web output proof. |
| Reports | 255 Crystal binaries plus 20 missing references; filters, joins, formulas, bands, copies, images/barcodes, physical printing | 254 specs, binder, renderer, generic/dedicated pages, PDF generation | Partial/unsafe | Narrow binder, `SL_DATA` fallback, minimal formulas, silent blanks, incomplete Crystal semantics, no O/D/T breadth, no PDF/print comparison. |
| Utilities/import/export/renumber/year-end/reminders | Data movement, locks, coordinated renumber, year transfer, backup/restore and messages | Dedicated modules/pages, cutover command, utilities tests | Partial | Production-sized migration, rollback/reconciliation, year-end E5 and safe restore not proved. |
| Devices and integrations | Scale, barcode/QR, scanners, camera/images, printer, WhatsApp/SMS, rates, e-invoice | Protocol/adapters, browser camera/barcode paths, readiness/config screens | Partial/blocked | Real devices, drivers, permissions, calibration, delivery/retry/rate limits and site UAT absent. |

No module family is exact-parity certified.

## 7. Frontend/forms/UI assessment

### Strengths

- Many transaction workflows have dedicated pages rather than only generic metadata screens.
- Shared components exist for voucher chrome, configured books, tender, lookup, extended grids, camera, Enter traversal, grid keyboard decisions, and form-key hints.
- Sales, purchase, tag opening, physical stock, melting, repair, VP, gold book and other high-value workflows have meaningful UI code.
- The build generates 101 pages and current frontend unit/browser gates pass.

### Gaps

1. **Generic scaffolds are not desktop forms.** `masters/[name]/page.tsx` and `reports/[report]/page.tsx` provide broad reach but not each form's desktop search grid, layout, defaults, side effects, filter semantics, printing or exact key flow.
2. **Keyboard parity is inconsistent.** `useGridKeyboard`, `FormKeyHints`, and bespoke `onKeyDown` handlers overlap across a subset of pages. Shared decision-table tests do not compare all 795 desktop events or exact per-form focus order.
3. **Rights UX is incomplete.** The shell filters navigation through `allowedForms`, while the API correctly enforces action rights. Pages do not consistently consume Edit/Delete/Print rights to hide/disable actions; direct routes can render before API 403 responses.
4. **Responsive/mobile behavior is unproved.** No comprehensive application breakpoint strategy was found; dense tables and a fixed desktop-oriented shell are not certified for small screens.
5. **Accessibility is unproved.** Labels and ARIA usage exist, but no axe/WCAG audit, screen-reader run, or full keyboard-only runtime certification exists.
6. **Browser smoke is mocked.** `apps/web/test/browser.smoke.mjs` intercepts `**/api/**`; it proves frontend regression paths, not real API/database posting.
7. **Print semantics are incomplete.** Original/Duplicate/Triplicate, template selection, printer behavior and historical reprints are not consistently wired and compared across workflows.

## 8. Backend/domain assessment

### Verified web strengths

- Tenant-scoped interactive transactions through `withTenant()`.
- Balanced-ledger checks before persistence in many financial workflows.
- Full-scope advisory-lock numbering by company/location/year/book.
- Persisted-date lock checks on create/update/reversal in lifecycle services.
- Named fine and tax policies rather than one universal formula.
- Configurable rounding/settings resolver.
- Central route classification and per-form authorization.
- Persistent session validation, refresh rotation and replay revocation.
- Real create/read/update/delete/reversal services for many core workflow families.

### Residual risks

- Atomicity does not prove a complete or correct desktop write set.
- Generic reversal helpers are only as complete as each workflow's supplied table/state list.
- Static formula and validation text mapping does not prove branch conditions, timing, severity, side effects or values.
- Audit writes occur after business completion; an audit failure is observable but does not roll back the mutation.
- Raw SQL is necessary for desktop-shaped schemas but creates schema-drift risk, now proven by `BAR_DETL.DM_WT`.
- Time/date behavior is environment-sensitive: the same DB suite produced 23 timestamp/date failures with Node in IST and PostgreSQL in UTC, then only two schema failures when both were UTC. Production must define an explicit timezone contract and test it under the deployed India timezone and UTC storage policy.

## 9. Database, migration and data-conversion assessment

### Strengths

- Ten committed Prisma migrations apply successfully to a clean PostgreSQL database.
- Forced RLS and a non-superuser/non-bypass runtime role are implemented and pass restricted-role tests.
- The UTC-aligned run validates concurrency, numbering, tag double-issue prevention, balanced lifecycles, lock behavior, restricted-role security, audit privileges and many create/edit/delete flows against real PostgreSQL.
- A cutover command exists and deterministic tests prove dry-run behavior, full shared-column copying, numeric totals and actionable source-unreachable errors.

### Critical current defect

`stockVoucherLifecycle.ts` writes these opening-line values to `BAR_DETL`:

- `DM_WT`
- `DM_RATE`
- `DM_AMT`

The current `model BAR_DETL` in `packages/db/prisma/schema.prisma` contains none of them, and the migrations do not add them to `BAR_DETL`. A fresh migration-built database therefore fails at the first missing field (`DM_WT`). This is not a hypothetical static gap: it failed both the tag-opening lifecycle and full desktop tag-grid persistence tests under a disposable restricted-role database.

### Migration/data risks still open

- No sanitized representative customer database was migrated and reconciled.
- The restored desktop databases are seeded templates, not real transaction distributions or anomaly history.
- No full-table row counts, rejected-row ledger, business-key duplicate analysis, money/fine/stock control totals, historical report comparison, rollback rehearsal, or delta/freeze-window test has passed for a customer.
- Prisma schema convergence and migration history must be checked from an empty database on every CI run; existing long-lived databases can hide missing migration columns.
- Timezone/date conversions must be specified for `date`, `timestamp without time zone`, business day, voucher time and display time.

## 10. Reports, security, operations and DR

### 10.1 Reports

`reportBind.ts` recognizes only `SL_DATA`, `PR_DATA`, `KR_DATA`, `CASH_DATA`, `TAG_STOCK_PRINT`, and `AC_DATA`, then defaults unknown reports to `SL_DATA`. Unknown or unsupported report families should fail closed, not bind to sales data.

`reportEngine.ts` places extracted objects in stacked HTML bands and repeats details. It does not establish full Crystal page/group transition, suppression, conditional formatting, subreport, image/barcode, printer margin, section and pagination semantics. The source's “pixel-exact” wording is not evidence.

`crystalFormula.ts` explicitly supports a minimal subset and catches failures by returning an empty string. That prevents crashes but can silently omit legally or financially significant text/amounts.

The report contract test classifies 2,398 distinct tokens across 254 specs: 1,214 database, 408 formula and 776 special tokens; 1,124 database tokens resolve and 90 are allowlisted gaps. This proves parser/schema classification, not data joins, totals, visual output or desktop parity. The reports package itself has no test files and exits via `--passWithNoTests`; report tests live mainly in the API package.

### 10.2 Security

Local strengths include Argon2 passwords, secure/strict HTTP-only production cookies, session rotation/reuse detection, fail-closed route policies, `USER_SET` action checks, forced RLS, restricted runtime role, append-only audit privileges for that role, source secret scanning, and parameterized runtime values in inspected SQL.

Open production controls include distributed rate limiting, refresh/reset/expensive-report limits, trusted proxy policy, CSP/HSTS/Permissions-Policy/CORS decisions, TLS/WAF configuration, dependency/SBOM review, independent penetration testing, log/alert retention and on-call exercise. API authorization is stronger than current frontend affordance control.

### 10.3 Backup and restore

`deploy/backup.sh` provides a normal `pg_dump -Fc` path with local retention, but off-host encrypted storage, immutable retention, monitored execution, production-scale restore, RPO/RTO and failover are not certified.

The in-app logical backup/restore in `modules/ops/backup.ts` is unsafe for production:

- only 53 named tables;
- `LIMIT 100000` without truncation error/pagination;
- buffers serialized as `[binary]`;
- restore clear executes `DELETE FROM table` under tenant RLS but without `CO_CODE`, deleting all companies in that tenant;
- row errors are swallowed through savepoints;
- `ON CONFLICT DO NOTHING` can still increment the `restored` count;
- no complete dependency/order/business-key reconciliation.

The retained restore drill passed only five rows across 52 checked tables. It does not address any of the hazards above.

### 10.4 Deployment and observability

Both compose definitions pass `docker compose config --quiet`. Build/runtime Dockerfiles exist. Readiness, metrics and structured failure signals exist locally. However, the repository has overlapping root and production compose/documentation paths, and deployment notes contain stale statements. No production HTTPS origin, dashboard, alerts, on-call drill, multi-instance behavior, production DB sizing/pool policy, long soak or failover has been certified.

The retained local load profile completed 114 loopback requests with zero errors, but used a small laptop dataset and short run; it is not a production SLO/capacity result.

## 11. Fresh validation results from this audit

| Check | Fresh result | Interpretation |
|---|---|---|
| Workspace lint/secret policy | Pass: 445 source files, 8 manifests, 0 policy violations | Current static quality gate passes. |
| Direct API unit/contract run, DB flags off | 536 passed, 154 skipped; 67 files passed, 32 skipped | Broad web behavior; all DB suites intentionally skipped. |
| Direct web unit run | 9/9 passed | Shared keyboard/form-key decisions only. |
| Other workspace package tests | Core 13, DB helper 3, parity 6, types 3 passed; reports has no tests | Total default workspace evidence: 570 passed, 154 skipped. |
| Direct API and web TypeScript checks | Pass | Current API/frontend type-safe. |
| Workspace build | Pass through current Turbo cache key; 7/7 tasks; Next output 101 pages | Buildable; not runtime parity. |
| Report baselines | Pass: 254 layouts unchanged | Deterministic web layout baseline only. |
| Browser smoke | Pass | API calls are mocked; no real DB posting. |
| Compose syntax | Root and production compose pass | Syntax only, not deploy/UAT. |
| Clean migrations | All 10 applied successfully to disposable DB | Migration chain executes. |
| DB suite with macOS IST Node + UTC PostgreSQL | 667 passed, 23 failed | Failures were date/time offsets, exposing timezone sensitivity. |
| DB suite with `TZ=UTC` and UTC PostgreSQL | **688 passed, 2 failed** | Real blocker remains: both tag-opening tests fail on missing `BAR_DETL.DM_WT`. |
| Cleanup | Pass: no disposable audit DB/role remains | Test isolation confirmed. |
| G5 desktop comparison | Degraded; 15/15 fixed vectors, all live desktop checks skipped | No desktop parity evidence. |
| G6 | 0/720 | No production certification. |

## 12. Severity-ranked gap register

### P0 — must close before any live financial/inventory cutover

1. **Fix migration/schema/writer convergence for tag opening.** Add and verify all desktop-required `BAR_DETL` columns, beginning with `DM_WT`, `DM_RATE`, and `DM_AMT`; regenerate Prisma; add a committed migration; run migration diff; run all 690 API tests from an empty DB under restricted role and both intended timezone configurations.
2. **Execute E5 desktop-vs-web comparison.** Obtain a sanitized representative SQL Server fixture and paired voucher definitions; run all 57 posting workflows through desktop and web; compare complete row footprints, values, sums, balances, stock/tag identity, reopen/edit/reversal, calculations, messages, keyboard, PDFs and printer outputs. Zero unexplained differences is required.
3. **Make reporting fail closed and complete in scope.** Explicit binder/query for every in-scope report; classify every formula/section/object; remove silent wrong-family fallback and legally significant blank-on-error behavior; support approved O/D/T semantics; compare desktop/web PDF text, totals and visual geometry; certify physical printers/labels.
4. **Replace or disable unsafe logical restore.** Company-scoped clearing, full table scope, streaming/pagination, lossless binary, fail-fast or exhaustive error ledger, accurate affected counts, manifest/checksums, encryption/offsite retention, production-sized multi-company restore and business reconciliation are required.
5. **Reconcile persistence residuals.** Every never-written/low-depth table and column must be implemented or explicitly waived with reader/report/reopen/reversal impact. Static percentages alone are insufficient; prove runtime create/read/edit/delete footprints.
6. **Run a real migration rehearsal.** Production-sized sanitized data, row/reject counts, business-key duplicate handling, money/fine/stock/control totals, historical reports, performance, delta load, freeze, rollback and authorized sign-off.
7. **Complete G6 mandatory gates.** Production load/soak/SLO, deployed security/pen test, observability/on-call, DR/RPO/RTO, device UAT, site UAT, live integrations and business signatures.

### P1 — required for operational equivalence and controlled rollout

1. Define and enforce one timezone/business-day contract across Node, PostgreSQL, migration, API serialization and UI; add IST/UTC tests.
2. Complete per-form keyboard/focus mapping for critical forms, then all 795 desktop events.
3. Consume action-level rights in the frontend and add direct-route UX guards while preserving API enforcement.
4. Complete responsive/accessibility testing or explicitly scope supported workstation viewport/browser.
5. Certify scale, scanners, cameras, label/A4 printers, barcode readability and fallback behavior on actual site hardware.
6. Certify GSP/e-invoice, WhatsApp, SMS and live rates with real sandbox/provider accounts, retries, idempotency, reconciliation and monitoring.
7. Increase production security controls: distributed/gateway limits, headers, proxy trust, dependency/SBOM review and independent assessment.
8. Remove stale/conflicting architecture/deployment documentation and define one authoritative production path.

### P2 — quality and maintainability

- Expand frontend component/page tests beyond shared keyboard decision tables.
- Give `@repo/reports` direct package tests or remove misleading `--passWithNoTests` as a release signal.
- Add schema-aware static checks that compare raw-SQL insert keys against the migration-built database/Prisma model.
- Store immutable audit snapshots with a repository revision/content hash so moving-workspace percentages cannot be mixed.
- Replace comments such as “pixel-exact” or “true restore” with test-backed, narrowly scoped claims.

## 13. Required acceptance program

### Phase A — make clean deployments trustworthy

- Repair the `BAR_DETL` migration/model mismatch and search every raw writer for undeclared columns.
- CI must create a database from zero, deploy migrations/RLS/restricted role, run all DB suites, run `prisma migrate diff --exit-code`, and drop the database.
- Run the DB suite under the actual deployment timezone plus UTC.
- No skipped DB tests on the protected release branch.

### Phase B — build the desktop golden-master harness

- Restore a sanitized real SQL Server backup.
- Define paired desktop/web fixtures for all 57 posting workflows and critical masters/reports.
- Capture before/after DB state, calculated fields, balances, stock/tag state, messages, focus sequence, screenshots and documents.
- Compare complete business keys and rows, not only totals.

### Phase C — close reports and devices

- Recover or waive each of the 20 missing report obligations and the unavailable/partial layouts with business authority.
- Implement explicit data binding/formula/section support and fail closed on unsupported reports.
- Compare PDFs and physical output; certify each printer/media/DPI and scanner/scale/camera model.

### Phase D — migrate and operate safely

- Perform at least one full-size rehearsal plus delta/freeze/rollback rehearsal.
- Establish monitored encrypted offsite backups, restore/failover drills and approved RPO/RTO.
- Deploy TLS/proxy/security headers/rate controls, dashboards, alerts and on-call procedures.
- Execute the UAT plan with named operations, finance, inventory/manufacturing and deployment/security signers.

## 14. Final business verdict

The web rewrite has a strong foundation and considerable implemented breadth. It is suitable for continued engineering, controlled demonstrations, and isolated UAT after the clean-database blocker is fixed. It is **not ready for production business use or retirement of the desktop application**.

The minimum defensible go-live condition is not “all tests green” or a high static column percentage. It is:

- clean migration-built database with all integration tests passing;
- zero unexplained differences across approved E5 desktop/web fixtures;
- report and device certification;
- production-sized migration and DR rehearsal;
- all mandatory G6 controls passing;
- signed acceptance by authorized business and technical owners.

Until those conditions are met, keep the desktop database as the operational source of truth and do not perform an irreversible cutover.

## 15. Detailed supporting artifacts

- Exhaustive 204-form appendix: `project-memory/parity/END-TO-END-PARITY-FORM-APPENDIX-2026-07-29.md`
- Current generated matrix: `project-memory/parity/DESKTOP-WEB-PARITY-MATRIX.json` and `.md`
- Current depth scoreboard: `project-memory/parity/DEPTH-SCOREBOARD.md`
- Canonical desktop model: `project-memory/parity/DESKTOP-ERP-EVIDENCE-MODEL.md`
- Report reconciliation: `project-memory/catalogs/report-reconciliation.json`
- G5 artifact: `project-memory/parity/g5/latest.json`
- G6 status: `project-memory/parity/G6-STATUS.md`
- UAT plan: `project-memory/parity/UAT-PLAN.md`
- Security review: `project-memory/parity/SECURITY-REVIEW.md`
- Desktop source: `unified/src/csharp/DataCareNext/`
- Web source: `web/apps/web/`, `web/apps/api/`, `web/packages/db/`
