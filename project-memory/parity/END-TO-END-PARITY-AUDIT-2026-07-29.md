# DataCareNext Desktop-to-Web End-to-End Parity Audit

**Audit date:** 2026-07-29  
**Audit type:** evidence-backed replacement-readiness audit, not an implementation completion claim  
**Canonical desktop:** `unified/src/csharp/DataCareNext/`  
**Web rewrite:** `web/`  
**Decision:** **NO-GO for live financial or inventory migration**  
**Overall implementation status:** **PARTIAL — broad and substantial, not exact parity**

## 1. Executive decision

The web rewrite is a substantial ERP implementation, not a prototype. It has real transactional services, tenant-scoped PostgreSQL persistence, lifecycle operations, accounting assertions, stock handling, per-form API authorization, sessions, reporting infrastructure, and broad UI coverage. Those strengths are supported by source and web-only tests.

It is **not an exact replacement for the canonical desktop ERP**. The current evidence does not prove that the same operator actions against the same fixture produce the same persisted rows, balances, stock state, keyboard behavior, screenshots, invoices, statutory outputs, or printer output. The decisive evidence tiers—E5 desktop-vs-web comparison and E6 production certification—are both at zero/not started. The current G5 harness is **DEGRADED**: 15 fixed vectors pass, while all live desktop SQL comparison checks are skipped. G6 is **0/720**.

The rewrite is therefore **unsafe for a live financial/inventory cutover**. A live migration could silently alter voucher detail, fine-weight calculations, tax/report output, tag and stock state, historical reprints, or restore behavior while still passing current web-only tests. The release remains **NO-GO** until the critical correctness, report, persistence, restore/DR, E5, and E6 acceptance conditions in this report are closed.

This decision does **not** require reproducing known desktop defects. Security weaknesses, licence-serial customizations, brittle local integrations, and demonstrably defective device behavior must be corrected or explicitly waived while preserving approved business outcomes.

## 2. Scope, evidence model, and freshness

### 2.1 Scope

This audit compares the canonical desktop product with the current web rewrite across:

- architecture and runtime layers;
- all module/workflow families, with every canonical form delegated to an exhaustive appendix;
- forms, fields, grids, keyboard flow, printing, accessibility, and responsive behavior;
- API/domain calculations, validation, posting, update, reversal, numbering, locks, and audit behavior;
- PostgreSQL schema, migrations, RLS, tenant/company scope, and persistence depth;
- settings, security, RBAC, reports, statutory documents, devices, external integrations;
- backup, restore, DR, operations, test evidence, and production readiness.

The exhaustive 204-form ledger is [project-memory/parity/END-TO-END-PARITY-FORM-APPENDIX-2026-07-29.md](./END-TO-END-PARITY-FORM-APPENDIX-2026-07-29.md). Its rows come from the current official 204-form matrix generated from the immutable source snapshot and are current static evidence for that snapshot. Static percentages and gate labels remain E0/E1 evidence only; they do not establish parity, and every form remains E5/E6 not started.

### 2.2 Status vocabulary

| Status | Meaning in this report |
|---|---|
| **verified** | Direct source, deterministic test, or retained runtime artifact proves the narrow claim stated. |
| **partial** | Material implementation/evidence exists, but the desktop contract or full lifecycle is not proved. |
| **missing** | Required behavior or evidence is absent. |
| **unsafe** | Current behavior can cause loss, corruption, cross-company impact, false success, or an unreliable cutover. |
| **blocked** | Closure requires an unavailable external system, fixture, service, device, runtime, or approver. |
| **waived** | An identified obligation has an explicit, evidence-backed scope decision and revocation condition. |
| **unverified** | Presence is visible, but qualifying behavior evidence was not produced. |

### 2.3 Evidence tiers

| Tier | Required meaning | Current state |
|---|---|---|
| **E0 — inventory** | Count and identify desktop/web artifacts. | **verified** for major source/schema/form/report inventories. |
| **E1 — static** | Source-level mapping, parsers, write unions, field reach, and implementation inspection. | **partial**; broad and useful, but heuristic/static. |
| **E2 — deterministic unit/golden** | Pure calculations, guards, contracts, and fixed vectors. | **verified for many web behaviors**, not desktop runtime parity. |
| **E3 — controlled web runtime** | HTTP/browser behavior against a controlled web runtime. | **partial**; retained and source test evidence exists, but not every workflow in this audit was rerun end-to-end. |
| **E4 — real local integration** | Restricted-role PostgreSQL, real local services, or retained integration drill artifacts. | **partial**; narrow prior artifacts exist, while 148 database/integration tests were skipped in the fresh default test run. |
| **E5 — same-fixture desktop vs web** | Actual desktop and web execution over paired fixtures, comparing DB, calculations, keyboard, screenshots, and PDFs. | **missing/not started: zero desktop comparisons.** |
| **E6 — production certification** | Production-like load, security, DR, devices, integrations, UAT, and authorized sign-off. | **missing/blocked: 0/720.** |

### 2.4 Freshness and matrix handling

This report is anchored to the immutable source snapshot at UTC **20260729T081012Z**. Its aggregate was **`f9f80c1462be2df52aa454c9d71709f46f37cd3d226e2e3988a300eb04ced7be files=5277`**, verified identical before and after the copy and identical in the immutable snapshot. Evidence: `project-memory/parity/snapshots/immutable-snapshot-20260729T081012Z.txt`.

The official fail-closed `project-memory/parity/build_parity_matrix.py` completed successfully at **2026-07-29T08:12:14+00:00** against that immutable copy. Its **204-form audit-cutoff matrix** is preserved at `project-memory/parity/snapshots/immutable-20260729T081012Z/DESKTOP-WEB-PARITY-MATRIX.json`. Evidence: `project-memory/parity/snapshots/immutable-generator-20260729T081012Z.log`. The mutable root matrix/audit filenames continued to advance as external edits and generators ran; they are outside this evidence cutoff and are not used for the figures in this report.

An earlier moving-workspace run transiently asserted 24 uncapturable Sales Order fields while source files were changing. The immutable rerun supersedes that result: it is concurrency/freshness evidence, not a current product gap or release blocker.

Current immutable source-derived artifacts used here are:

- `project-memory/parity/snapshots/immutable-20260729T081012Z/VALIDATION-AUDIT.json`;
- `project-memory/parity/snapshots/immutable-20260729T081012Z/UI-FIELD-AUDIT.json`;
- `project-memory/parity/snapshots/immutable-20260729T081012Z/CALC-AUDIT.json`;
- `project-memory/parity/snapshots/immutable-20260729T081012Z/DEEP-COLUMN-AUDIT-SUMMARY.json`;
- `project-memory/parity/snapshots/immutable-20260729T081012Z/DESKTOP-WEB-PARITY-MATRIX.json`;
- `project-memory/parity/snapshots/immutable-snapshot-20260729T081012Z.txt`;
- `project-memory/parity/snapshots/immutable-generator-20260729T081012Z.log`.

Validation against the same immutable application snapshot completed as follows:

- `pnpm lint`: **passed**; 442 source files parsed, 8 manifests checked, 0 policy violations, followed by 10/10 successful typecheck/build tasks;
- explicit `pnpm typecheck`: **passed**, 10/10 tasks;
- `pnpm test`: **562 passed and 148 skipped** across the workspace; the API result was 528 passed/148 skipped, with 31 API database/integration files skipped because the opt-in flags were not enabled;
- `pnpm build`: **passed**, 7/7 tasks; Next generated 101/101 static pages;
- `pnpm report-baselines`: **passed**, 254 web layouts unchanged;
- `pnpm test:browser`: **passed** for the existing broad browser smoke.

The `@repo/reports` package had no test files and exited through `--passWithNoTests`. The browser smoke mocks API calls, and web report baselines prove deterministic web rendering only. None of these results is desktop parity or production certification. Opt-in DB suites were not rerun because the configured target was the generic `postgres/datacare` Docker database, not a verified isolated disposable test database; mutation-capable tests were therefore left skipped. Full logs are retained under `project-memory/parity/snapshots/validation-*-20260729T081012Z.log`.

## 3. Canonical desktop baseline

The audit oracle is `unified/src/csharp/DataCareNext/`, not older duplicate source trees, routes, filenames, or web design documents. `project-memory/parity/DESKTOP-ERP-EVIDENCE-MODEL.md` establishes the baseline and precedence rules.

| Desktop surface | Verified baseline | Primary evidence |
|---|---:|---|
| Canonical forms/classes | **204** | `unified/src/csharp/DataCareNext/*.cs`; `project-memory/catalogs/module-map.json` |
| Form categories | **61 transaction, 33 master, 45 report, 22 utility, 43 other** | `project-memory/catalogs/module-map.json`; form appendix |
| Posting workflows | **57** | `project-memory/catalogs/module-map.json`; evidence model |
| Behavior specs | **204** | `project-memory/catalogs/form-behavior/` |
| Logic specs | **172** | `project-memory/catalogs/form-logic/` |
| Layout specs | **160 `initcomp` + 15 legacy** | `project-memory/catalogs/layouts/` |
| Grid entries | **6,973** | `project-memory/catalogs/form-behavior/_index.json` |
| SQL occurrences | **5,128** | same behavior index |
| Keyboard events/bindings | **795** | same behavior index |
| Calculation expressions | **3,309** | same behavior index |
| Validation occurrences | **1,849** | same behavior index |
| Restored SQL tables | **146** | `project-memory/catalogs/realdb-schema-full.json` |
| Restored SQL columns | **5,254** | same schema catalog |
| Defaults | **2,355** | same schema catalog |
| Identity columns | **0** | same schema catalog |
| `CO_SET` keys | **57** | `project-memory/catalogs/settings-catalog.json` |
| Supplied Crystal RPT binaries | **255** | `unified/reports/` |
| XML/spec report extractions | **254** | `project-memory/catalogs/report-layouts/` |
| Report layout disposition | **253 complete, 1 partial, 1 unavailable** | `report-reconciliation.json`; `WAIVERS.md` |
| Tutorial evidence | **30 transcripts / 1,069 keyframes** | `project-memory/video-research/` |
| Additional referenced-but-absent RPT obligations | **20** | `project-memory/catalogs/report-reconciliation.json` |

The restored Next23/Next24 databases are seeded templates, not representative shop transaction history. They prove schema/default/seed conventions; they do not prove production distributions, anomalies, volumes, or customer-specific setup. Evidence: `project-memory/parity/EXTRACTION-COMPLETENESS-REPORT.md`.

The desktop is a keyboard-first WinForms MDI application with company/location/year/book business keys, application-assigned numbering, physical coordinated delete/reversal, stock movement journals, account and metal balances, and form-specific calculations. A generic CRUD route or a table/model count cannot prove equivalent behavior.

### 3.1 Legacy behavior that must not be copied blindly

The desktop remains the business oracle, not a mandate to preserve every defect:

- **Security modernization is required.** The web's hashed/rotating sessions, RLS, and fail-closed API authorization improve on desktop-era controls; parity requires equivalent authorization outcomes, not legacy credential handling.
- **Database weaknesses are not acceptance targets.** The restored desktop schema has no identities, but also zero stored procedures, views, triggers, foreign keys, or check constraints. The web may add constraints and surrogate keys so long as desktop business keys/outcomes remain intact (`project-memory/parity/DESKTOP-ERP-EVIDENCE-MODEL.md`).
- **Licence-serial branches are tenant-specific, not universal rules.** `project-memory/parity/WAIVERS.md` records multiple `SSRegSrNo`-gated validations/calculation branches. They must be enabled only if the affected installation is migrated.
- **The scale's dropped minus sign is a known defect.** The desktop parser turns `-1.234` into `1.234`; the web protocol port flags this behavior rather than presenting it as safe (`project-memory/parity/DEVICE-BRIDGE.md`). Production policy must decide whether to preserve or reject it.
- **Brittle Selenium WhatsApp automation need not be restored.** The Cloud API replacement is an evidence-backed waiver, subject to live service certification (`project-memory/parity/WAIVERS.md`).
- **Documented reversal defects may be corrected.** For example, the web repair flow deliberately clears an additional stale adjustment flag (`web/apps/api/test/repairReceipt.db.test.ts`). Any divergence must be documented and business-approved, not hidden as “parity.”

## 4. Architecture and layers

### 4.1 Desktop architecture

**Status: verified baseline.** The canonical application is decompiled C#/WinForms code under `unified/src/csharp/DataCareNext/`, using SQL Server business tables and Crystal RPT binaries. Desktop form code often combines UI events, validation, calculation, SQL construction, and printing in the same class. The business identity is company + location + financial year + book + voucher number, with zero database identity columns.

### 4.2 Web architecture

**Status: verified implementation; parity partial.** The current stack is:

- **Next.js 15.1.6 + React 19.0.0** frontend (`web/apps/web/package.json`);
- **direct Fastify 5.8.5** API (`web/apps/api/package.json`);
- Prisma 6.19.3/PostgreSQL with tenant RLS (`web/packages/db/`);
- shared workspace packages for types, core calculations, DB access, reports, and parity tooling (`web/package.json`, `web/pnpm-workspace.yaml`).

Stale descriptions that call the current API NestJS are incorrect. `project-memory/decisions/ADR-0003-http-fastify.md` explicitly revises the HTTP layer to direct Fastify. The root `web/package.json` description still says “NestJS”; that string is stale documentation, not runtime architecture.

### 4.3 Layer assessment

| Layer | Status | Evidence-backed assessment |
|---|---|---|
| Frontend routes/pages | **partial** | Many dedicated transaction pages exist, but route presence is not parity; generic master/report pages and inconsistent primitives remain. |
| API route policy | **verified narrow strength** | Central startup classification and per-form authorization are implemented in `web/apps/api/src/app.ts`, `modules/rbac/routePolicy.ts`, and `authorization.ts`. |
| Domain services | **partial/substantial** | Real posting/lifecycle modules exist across core families. Exact branch, field, and desktop outcome equivalence is unverified without E5. |
| Persistence | **partial** | PostgreSQL schema/RLS is substantial; immutable-snapshot static write-union depth is 89.4%, with 11 desktop-written tables never written. |
| Reports | **partial/unsafe for exact output** | Real extracted specs and rendering exist, but binder, formula, pagination, copy, and baseline limitations prevent exact parity. |
| Operations | **unsafe** | Logical restore implementation can clear too broadly, truncate backup scope, lose binary data, swallow row errors, and over-report restoration. |
| Production controls | **blocked** | Local controls exist; E6 is 0/720 and customer/site/service/device sign-off is absent. |

## 5. Quantitative scorecard and caveats

| Metric | Current value | Status | What it does—and does not—prove |
|---|---:|---|---|
| Desktop forms | **204** | **verified E0** | Exhaustive inventory only. |
| Posting workflows | **57** | **verified E0** | Desktop obligation inventory only. |
| Validation-text heuristic | **435/655 = 66.4%** | **partial E1** | Finds desktop rule wording in web source. It does not prove reachability, condition equivalence, enforcement, or side effects. |
| Audited UI API-field capture | **492/492 = 100.0%** | **partial E1** | Narrow audit over selected pages/API fields, not all desktop controls or all 204 forms. |
| Sales audited UI gaps | **0** | **verified narrow E1 result** | No uncapturable API fields in the immutable-snapshot Sales page audit; not Sales workflow parity. |
| Sales Order audited UI gaps | **0** | **verified narrow E1 result; runtime unverified** | Static capture passes for all 102 audited API-accepted fields; keyboard, dependency, precision, validation, lifecycle, print, and E5 behavior remain unproved. |
| Calculation inventory | **1,327 computed fields** | **E1 inventory** | Inventory, not equivalence. |
| Calculated fields mapped to statically written columns | **1,041** | **partial E1** | Column reach only. **This must never be called calculation parity.** |
| Deep table-union column detection | **3,280/3,669 = 89.4%** | **partial E1** | Static detection of writes, not runtime values, atomic lifecycle, or report correctness. |
| Desktop-written tables written at all by web | **111/122** | **partial E1** | A detected writer may still omit columns/branches or write wrong values. |
| Desktop-written tables never written by web | **11** | **missing/waiver review** | Listed below; zero-column artifacts require separate treatment. |
| G5 | **DEGRADED; 15/15 fixed vectors** | **partial E2** | Desktop SQL sigma, footprint, voucher-column, and calculation-recomputation checks all skipped. |
| E5 desktop comparisons | **0/not started** | **missing** | No same-fixture runtime/DB/UI/PDF parity. |
| G6 production certification | **0/720** | **blocked** | No production-certified unit. |
| Fresh workspace tests | **562 passed, 148 skipped** | **verified web self-test result** | Not desktop parity; DB/integration suites were skipped in the default run. |

### 5.1 Sales Order static capture and runtime verification gap

The immutable-snapshot `project-memory/parity/snapshots/immutable-20260729T081012Z/UI-FIELD-AUDIT.json` reports **102/102 audited Sales Order API-accepted fields capturable, with 0 gaps**. The previous 24-field assertion was a transient result from an earlier moving-workspace run and is superseded concurrency evidence, not a current gap.

This static pass does not prove Sales Order parity. Its complex stone/diamond fields still require desktop-matched proof of keyboard reachability and order, dependencies, precision and rounding, validation timing/side effects, persistence, reopen, update, delete/reversal, print output, and E5 same-fixture outcomes.

### 5.2 Eleven desktop-written tables never written by the web

The current deep union result is from `project-memory/parity/snapshots/immutable-20260729T081012Z/DEEP-COLUMN-AUDIT-SUMMARY.json`:

| Table | Desktop write-set columns | Status/interpretation |
|---|---:|---|
| `TAG_SUM_DATA` | 23 | **missing/unverified** aggregation persistence. |
| `OP_LDR` | 18 | **missing/unverified** opening-ledger persistence. |
| `MENU_DATA` | 9 | **waived for current architecture** in `WAIVERS.md`; revoke if runtime-editable menu behavior is required. |
| `TAG_SET` | 8 | **waiver review required**; currently no web writer. |
| `BOOK_IDTL` | 6 | **missing/unverified** book sub-detail behavior. |
| `ROJMEL_BAL` | 5 | **missing/unverified** rojmel balance persistence. |
| `WEIGHT_MAST` | 4 | **missing/unverified** weight master persistence. |
| `TAG_DATA` | 3 | **missing/unverified** tag data persistence. |
| `USER_MAST` | 2 | **missing/unverified** legacy user-master persistence; security replacement may justify an explicit equivalence waiver. |
| `APP_CHATMESSAGES` | 0 | **zero-column extraction artifact**; do not assign business impact without additional evidence. |
| `WEBHOOKINBOX` | 0 | **zero-column extraction artifact**; do not assign business impact without additional evidence. |

`TAG_STOCK` is a separate low-depth artifact: the static audit detects a web writer “at all” but zero intersecting desktop write-set columns. It is therefore not in the eleven, yet it still requires runtime/column-level review.

## 6. Detailed business-family/module matrix

This family matrix is decision-level coverage. It deliberately avoids claiming parity from route/file/model counts. See the linked 204-row appendix for every canonical unit.

| Family and desktop obligations | Web evidence | Status | Decision-relevant gaps / required proof |
|---|---|---|---|
| **Company, login, location, year, books, provisioning, settings, users** | Context/session switching, provisioning, settings, users/RBAC modules; `web/apps/api/src/modules/auth/`, `masters/companyClone.ts`, `shared/settingsBehavior.ts`, `rbac/` | **partial** | 57 `CO_SET` keys exist in desktop. Defaults, seeding, year transfer, per-setting effects, and same-fixture outcomes are not exhaustively proved. Generic UI and legacy user table equivalence remain. |
| **Masters: party/account, groups, item/product, tax, employee, labour, design, location, rates, stock limits** | Generic service/configs and generic page; dedicated party/auto-item/year pages (`modules/masters/`; `app/(app)/masters/[name]/page.tsx`) | **partial** | High field reach is not form behavior parity. Generic scaffolding does not prove desktop layouts, dependent defaults, side effects, validation conditions, search grid, print, or keyboard sequence. Design-book and other specialized behavior require per-form closure. |
| **Retail sales, sales return, sales order, order adjustment/cancel, hallmark/labour variants** | Dedicated pages and substantial `modules/sales/` services; balanced posting, tax, stock, lifecycle tests | **partial; critical** | Sales and Sales Order each have zero immutable-snapshot UI-audit gaps, but no E5. Sales Order's complex stone/diamond fields still require keyboard/dependency/precision/validation and persist/reopen/update/delete/print proof. Return/order satellites require the same-fixture proof. |
| **Wholesale, tour/approval, VP parcel/adjustment** | Dedicated services/pages including `sales/vpParcel.ts` and `finance/vpAdjustment.ts`; DB tests exist | **partial; substantial** | VP Parcel/Adjustment are real lifecycles, not placeholders. Approval classification, third-level detail, stock provenance, return/adjustment completeness, and desktop comparisons remain open. |
| **Purchase, purchase return, other purchase, other commission, fine/hedging** | `modules/purchase/`, dedicated pages, lifecycle logic; `purchase/otherCommission.ts` | **partial; critical** | Purchase formula branches differ from sales. Sub-details, tag behavior, tax/reversal/report output, and static residuals remain. Other Commission is real but E5 absent. |
| **Bullion, rate cut, fine sale/purchase, Gold Book** | Bullion/rate-cut services/pages and `finance/goldBook.ts`; deterministic tests | **partial** | Real implementation exists, but settlement, fine/money direction, report output, and configuration-dependent behavior need representative E5 vectors. |
| **Cash/bank, receipt/payment, contra/journal, bill-to-bill, UPI/card, bank reconciliation** | Finance services and pages; `assertBalanced`; bill allocation and bank-reconcile modules | **partial; critical** | Money ledger balance is a strength. Desktop `ROJ_MEL_DATA`/`ROJMEL_BAL`, clearing semantics, persisted reversal scope, print, and paired DB outcomes remain incompletely evidenced. |
| **Location amount and account/fine adjustments** | `finance/locationAmount.ts`, ledger/fine adjustment modules and pages | **partial; substantial** | Location Amount is a real lifecycle. Cross-location scope, money/fine direction, report and reversal parity need E5. |
| **Tagging, tag opening/print/cancel/split/transfer/weight difference, lot/item opening** | Stock voucher lifecycle, tag staging, barcode/device modules, multiple dedicated pages | **partial; critical** | Static low-depth tables and columns, third-level details, print queues, exact tag identity/reissue, label/printer behavior, and device paths remain. |
| **Physical Stock** | Persisted lifecycle in `stock/physicalStock.ts`, page, route policy, and opt-in DB tests | **partial; critical** | The web persists count snapshots and reconciles exact tag identities. It explicitly does not move stock. Desktop classification, approval, reconciliation, and tag re-issue behavior are not fully proved; `WAIVERS.md` records tag re-issue as open. |
| **Karigar, jobwork, repair issue/receive/customer issue** | `manufacturing/karigar.ts`, repair modules/pages, deterministic and opt-in DB tests | **partial; critical** | Named fine policies and real lifecycles exist. Stone/diamond sub-detail, metal liability direction, repair image/device flows, costing, tax, and desktop DB comparison remain. |
| **Manufacturing, order issue/receive, with-lot, item production, ghat** | `modules/manufacturing/`, pages, lifecycle suites | **partial; critical** | Static depth remains among the lowest families. Lot provenance, ghat/loss, sub-detail, material/result conservation, reversals, and report outcomes need E5. |
| **Melting** | `manufacturing/melting.ts`, `meltingPro.ts`, `meltingParity.ts`, dedicated page/tests | **partial; strong web implementation** | Real persisted workflow and formulas exist. Passing web tests do not prove all desktop branch selection, rounding, ledger/stock rows, or print output. |
| **Dhiran/pledge loans and interest** | `modules/dhrn/dhrn.ts`, issue/receipt/interest pages, deterministic tests | **partial; critical** | Interest configuration is complex and customer-sensitive. Collateral, outstanding, receipt detail, rounding, reporting, and same-fixture interest schedules remain unproved. |
| **Membership, savings schemes, loyalty/points** | `modules/membership/scheme.ts`, membership/scheme pages | **partial** | Enrollment/adjustment logic exists. Accrual triggers, redemption, sale linkage, points residual columns, statements, and desktop outcomes require proof. |
| **Reports, GST/statutory, ledgers, stock, manufacturing, schemes, loans** | Generic and dedicated report APIs/pages, 254 specs, HTML/PDF renderer, report contracts | **partial/unsafe for exact reporting** | Binder/formula/layout limitations, 20 absent RPT obligations, one partial and one unavailable layout, no full O/D/T workflow, no desktop PDF/print comparisons. |
| **Utilities: import/export, backup/restore, refresh, renumber, e-invoice, reminders** | Dedicated utility modules/pages | **partial; backup unsafe** | Backup/restore has critical correctness hazards. E-invoice/messaging require live sandbox proof. Import/export/renumber need production-data and rollback evidence. |
| **Devices and external services** | Protocol validation, WebSerial/WebUSB direction, camera capture, barcode wedge, messaging/e-invoice code | **partial/blocked** | Actual printer, scale, scanner, camera, Crystal runtime, GSP, WhatsApp, SMS, and rate provider behavior is externally blocked pending real devices/accounts/site UAT. |

No family is exact-parity certified. Every desktop comparison and every production certification remains zero/not started.

## 7. Frontend, forms, fields, grids, keyboard, and printing

### 7.1 Forms and fields

**Status: partial.** The rewrite has numerous dedicated transaction pages and a generic master page. The immutable-snapshot UI-field audit reports **492/492 (100.0%)** capturable API fields across its audited surfaces. This is a useful static transmission check, not a 204-form UI parity score.

Sales and Sales Order each have zero gaps in that audit. This means the audited API fields have a statically detected operator capture path; it does not prove desktop control defaults, conditional visibility, row state, dependency behavior, precision, validation order, reopen/update/delete behavior, keyboard path, persisted values, print output, or E5 outcomes.

Sales Order remains high risk because its complex stone/diamond fields have not received that runtime and same-fixture proof. The superseded 24-field moving-workspace assertion is not a current blocker.

### 7.2 Generic master/report scaffolds

**Status: partial.** `web/apps/web/app/(app)/masters/[name]/page.tsx` renders metadata-driven text/select/lookup controls, generic grouping, a nine-column list slice, and generic create/edit/delete/import/export actions. This provides broad reach but does not reproduce each desktop master's search grid, layout, defaults, side effects, toolbar rights, printing, or form-specific keyboard flow.

`web/apps/web/app/(app)/reports/[report]/page.tsx` maps a limited slug list to generic APIs, introspects returned arrays/scalars, and creates a generic branded PDF table. It is not a substitute for each desktop report's filter semantics, grouping, suppression, layout, formula, pagination, copy, and printer contract.

### 7.3 Grids and keyboard

**Status: partial/inconsistent.** Shared primitives are real:

- `components/KeyboardNav.tsx` implements Enter traversal and Ctrl/Cmd+Enter submit;
- `components/GridKeyboard.tsx` implements Enter/arrow/Escape/Ctrl+D decisions;
- `components/FormKeys.tsx` implements selected F-key shortcuts;
- `components/ExtendedGrid.tsx` exposes extended line columns.

But adoption is not uniform. Current source inspection finds `useGridKeyboard` on **14** pages, `FormKeyHints` on **13** pages, and bespoke `onKeyDown` handlers on **17** pages. These overlapping patterns show implementation breadth, not one consistent, form-specific keyboard contract. `web/apps/web/test/gridKeyboard.test.ts` proves the shared decision table only; it does not compare the 795 extracted desktop events form by form.

Acceptance requires actual focus order, F1 lookup behavior, Enter row commit, Esc transition, Ctrl+Enter save, row deletion, shortcuts, modal suppression, and reopen behavior against the desktop for representative forms and then all critical workflows.

### 7.4 Frontend rights and direct-route behavior

**Status: partial; API secure, frontend UX incomplete.** `components/Shell.tsx` filters navigation by `allowedForms`, and API routes fail closed through `authorizeForm`. However, the frontend does not consume Edit/Delete/Print action rights to consistently hide or disable buttons. Direct navigation to a route is not rejected by a client route guard in `app/(app)/layout.tsx`; the page can render and then receive API 403 responses. This is not an API authorization bypass, but it is inconsistent with desktop action rights and produces misleading UI.

### 7.5 Responsive behavior and accessibility

**Status: partial/unverified.** Some dedicated pages use semantic labels/`aria-label`, focus outlines, tables, and visible shortcut buttons. There is no comprehensive accessibility audit, screen-reader test, keyboard-only E3 run, or WCAG evidence. The application-owned TSX/CSS search found no responsive `@media`/`matchMedia` breakpoint implementation. The fixed 232px sidebar, dense tables, and wide transaction grids in `app/globals.css` are therefore desktop-oriented and not certified for small screens.

### 7.6 Printing and copy semantics

**Status: partial.** The sales invoice API has an isolated `copy` query mapping for O/D/T labels in `web/apps/api/src/routes/txn.ts`. That is narrower than the desktop's form-level Original/Duplicate/Triplicate selection and template/copy behavior. No complete frontend wiring, per-workflow copy policy, persisted print choice, multi-copy behavior, or desktop PDF/physical-print comparison is evidenced across purchase, return, karigar, tag, statutory, and other reports.

## 8. Backend: API, posting, reversal, calculation, and validation

### 8.1 Verified strengths

The following are verified as web implementation strengths, not desktop parity:

- **Tenant-scoped atomic posting:** `web/apps/api/src/modules/posting/posting.ts` writes voucher satellites and ledger rows inside `withTenant(...)` transactions.
- **Balanced-ledger assertion:** `assertBalanced` checks money legs before persistence; used across sales, purchase, finance, scheme, Dhiran, and other modules. `web/apps/api/test/posting.test.ts` covers the pure invariant.
- **Persisted-date locks on create/update/reversal:** posting reads `CO_SET.LOCK_DATE`; reversal derives the stored voucher date before deletion, preventing a caller from forging a new date. Evidence: `posting.ts`, voucher lifecycle modules, and lifecycle tests.
- **Full-scope advisory-lock numbering:** `modules/vouchers/numbering.ts` locks tenant/company/location/year/book and derives MAX(VCH_NO)+1 from persisted business rows. This is stronger evidence than a route or model count.
- **Named workflow fine policies:** `modules/shared/finePolicy.ts` selects explicit sale, order, purchase-old-gold, karigar, opening, melting, manufacturing, and wholesale-return policies with desktop source citations.
- **Configurable rounding:** `modules/shared/roundingPolicy.ts` and `roundingPolicyLoader.ts` resolve configured item/labour/tax/fine/money behavior.
- **Real lifecycle modules:** VP Parcel/Adjustment, Gold Book, Location Amount, Other Commission, Melting, and persisted Physical Stock have create/read/update/delete or equivalent domain behavior and dedicated tests/source modules.

### 8.2 Posting and reversal limits

**Status: partial.** Atomicity and balance are necessary but not sufficient. Exact parity requires the complete desktop write set, correct values, correct sign/direction, complete satellite reversal, persisted user/time identity, lock behavior, and report-visible state under the full business key. Static union detection cannot prove these properties.

The generic reversal helper is sound in principle, but each workflow must supply every affected table and restore external/tag availability state correctly. Same-fixture row/column/sum comparisons are absent.

### 8.3 Calculations

**Status: unverified for parity.** `project-memory/parity/snapshots/immutable-20260729T081012Z/CALC-AUDIT.json` inventories **1,327** computed fields and maps **1,041** to columns that static analysis sees the web write. This says nothing about formula equivalence, branch conditions, rounding order, zero/blank semantics, per-book configuration, or runtime values. The audit itself explicitly refuses to publish a calculation-parity percentage.

G5's 15 passing fixed vectors cover selected GST, totals, labour, Dhiran interest, fine, and ledger examples. They are E2 regression vectors. The live calculation recomputation check is skipped because no desktop source is configured (`project-memory/parity/snapshots/immutable-20260729T081012Z/g5/latest.json`).

### 8.4 Validations and settings

**Status: partial.** The validation heuristic finds desktop wording for **435/655 rules (66.4%)**. Exact text presence can be a useful trace, but it cannot prove the original condition, timing, severity, side effects, or that the page can reach the guard. Prompts/notices are separately inventoried and must not be turned into blocking rules by mistake.

The desktop has **57 `CO_SET` keys**. The web has a broad settings parser and behavior resolver, but each setting must be classified as business-effective, UI-only, obsolete, customer-specific, or waived. `project-memory/parity/WAIVERS.md` correctly avoids copying UI-only/theme/start-menu and licence-specific branches universally. Remaining business-effective settings need per-key E2/E5 acceptance.

## 9. Database, migrations, persistence, and RLS

### 9.1 Desktop schema baseline

**Status: verified E0.** The restored desktop schema contains **146 tables, 5,254 columns, 2,355 defaults, and zero identities** (`project-memory/catalogs/realdb-schema-full.json`). It contains no stored procedures, views, triggers, FKs, or check constraints per the evidence model. Application behavior therefore carries many invariants the web must enforce explicitly.

### 9.2 Web schema and migrations

**Status: partial/substantial.** The current repository contains exactly **10 Prisma migration files** under `web/packages/db/prisma/migrations/`: `20260627200423_init`, `20260714010000_schema_parity`, `20260715010000_runtime_schema_security`, `20260715020000_schema_model_convergence`, `20260715030000_authoritative_scope_rbac_sessions`, `20260715040000_transaction_integrity`, `20260727010000_repair_image`, `20260727020000_melting_detail_parity`, `20260727030000_melting_mfg_linkage`, and `20260728010000_message_attempt_log`. Presence or clean migration is not data parity; migration acceptance must include representative production-sized ETL, rejected-row accounting, reconciliation, rollback, and business totals.

Web surrogate `row_id` fields may coexist with the desktop business keys, but they must never replace company/location/year/book/voucher scope in posting, update, reversal, uniqueness, or reconciliation.

### 9.3 RLS and restricted role

**Status: verified narrow strength.** `web/packages/db/prisma/rls.sql` enables/forces tenant RLS and uses `WITH CHECK`; `web/packages/db/setup_roles.sql` configures `app_user` as `NOSUPERUSER ... NOBYPASSRLS`; `web/packages/db/src/tenant.ts` sets `app.tenant_id` transaction-locally. The retained security review records 170/170 tenant tables protected under a prior real local check (`project-memory/parity/SECURITY-REVIEW.md`). Health and restricted-role tests exist.

This proves tenant readiness controls, not company-level restore safety, full migration correctness, or production deployment policy.

### 9.4 Persistence depth

**Status: partial.** The immutable-snapshot deep table union detects **3,280/3,669 desktop-written columns (89.4%)** and writers for **111/122** desktop-written tables. Static detection can over-credit values that are wrong and under-credit dynamic patterns; it must be used as a remediation inventory, not a release score.

The eleven never-written tables are listed in §5.2. The worst detected depth among tables with a web writer is:

| Table | Static coverage | Missing desktop-write columns |
|---|---:|---:|
| `TAG_STOCK` | 0.0% | 25 |
| `POINT_DATA` | 63.2% | 7 |
| `TAG_STOCK_PRINT` | 68.9% | 14 |
| `PR_IDTL` | 71.1% | 13 |
| `APR_IDTL` | 71.7% | 13 |
| `RATE_CUT_ISU` | 75.0% | 19 |
| `SL_ORD_ADJ` | 75.0% | 9 |
| `AD_ADJ` | 75.7% | 9 |
| `CASH_DATA` | 75.8% | 8 |
| `DHRN_ISU_DATA` | 76.1% | 11 |
| `BAR_IDTL` | 77.4% | 12 |
| `DHRN_ISU_DETL` | 77.5% | 9 |
| `RATE_CUT_REC` | 78.0% | 13 |
| `POINT_MEMB` | 80.0% | 2 |
| `AD_DATA` | 81.2% | 6 |
| `APR_DATA` | 81.2% | 3 |
| `APR_DETL` | 81.6% | 14 |
| `AD_MAST` | 83.3% | 2 |
| `REP_DETL` | 83.8% | 12 |
| `POINT_MAST` | 84.6% | 2 |

Every unresolved column must be implemented, proved irrelevant, or explicitly waived with downstream/report/reopen impact analysis (`project-memory/parity/snapshots/immutable-20260729T081012Z/DEEP-COLUMN-AUDIT-SUMMARY.json`).

## 10. Reports, printing, and statutory output

### 10.1 Desktop obligation

**Status: verified E0.** The package supplies **255 Crystal RPT binaries**. Of those, **254 have XML/spec extractions: 253 complete and `SalesQuotation` partial**; `TagStkIdtlRpt` is the one unavailable extraction. There are **20 additional referenced-but-absent report obligations** in `project-memory/catalogs/report-reconciliation.json`:

`aprbillimg.rpt`, `balzoom.rpt`, `bankadj.rpt`, `billwiseos.rpt`, `empdaysumm.rpt`, `empsumm.rpt`, `franchisebill.rpt`, `jdterskt.rpt`, `jdtvch.rpt`, `krisureport.rpt`, `krrecreport.rpt`, `loctamtvch.rpt`, `mainacsumm.rpt`, `mltingisu.rpt`, `purcquot.rpt`, `reminderschm.rpt`, `remindervch.rpt`, `salesrtna4print.rpt`, `vpparcelbill.rpt`, `whquotation.rpt`.

Absent files cannot be declared equivalent; they must be recovered from a deployed desktop, proved unreachable for the target scope, or explicitly waived by an authorized owner.

### 10.2 Binder limitation

**Status: unsafe for broad report claims.** `web/apps/api/src/modules/reports/reportBind.ts` recognizes only a small family map (`SL_DATA`, `PR_DATA`, `KR_DATA`, `CASH_DATA`, `TAG_STOCK_PRINT`, `AC_DATA`) and defaults an undetected report to **`SL_DATA`**. That fallback can bind a non-sales report to the wrong table rather than fail closed.

Fresh tests emitted `REPORT_CONTRACT_TOTALS`: **254 specs, 2,398 distinct tokens, 1,214 database tokens, 408 formula tokens, 776 special tokens, and zero “unresolvable” tokens after 90 allowlisted database gaps**. This is parser/schema contract resolution only. It does not prove correct report-family selection, joins, filters, runtime values, grouping, visual output, or desktop parity.

### 10.3 Layout/formula engine limitation

**Status: partial.** `reportEngine.ts` converts twips to pixels, stacks extracted bands, repeats detail rows, and places text/field/line/box objects. It does not implement the full Crystal runtime contract for pagination, page/group transitions, suppression, conditional formatting, font fidelity, subreports, images/barcodes, section rules, printer margins, or all object types.

`crystalFormula.ts` explicitly describes itself as a **minimal** display-formula evaluator. It handles limited functions, single-level conditionals, concatenation, comparison, and basic arithmetic; parse failures return an empty string. Returning blank avoids crashes but can silently omit legally or financially significant output. It is not a full Crystal formula engine.

The source comment calling output “pixel-exact” is not accepted as evidence. Exactness requires desktop-rendered baselines and objective screenshot/PDF comparisons.

### 10.4 Statutory and print decision

**Status: NO-GO.** GST/e-invoice/statutory calculations and generic documents have tests, but there are no same-fixture desktop-vs-web PDF comparisons, no complete O/D/T workflow, no physical printer certification, and no reconciliation of every report's totals/formulas/pagination. Report correctness is a critical cutover gate because vouchers can post correctly yet print or aggregate incorrectly.

## 11. Security, RBAC, and audit

### 11.1 Verified strengths

- **Session rotation/reuse detection/revocation:** `modules/auth/session.ts` hashes refresh JTIs, rotates under `FOR UPDATE`, revokes on reuse, validates persistent sessions, and supports immediate logout/user revocation. `test/auth.session.test.ts` verifies the pure/session behavior; DB/HTTP evidence exists separately.
- **Per-form API RBAC:** `modules/rbac/authorization.ts` resolves `USER_SET` by location/user/form, uses View for read/create, independently gates Edit/Delete/Print, fails closed for missing rows, and limits bypass to admins. `test/rbac.authorization.test.ts` covers those rules.
- **Route classification:** `modules/rbac/routePolicy.ts` and startup checks prevent unmapped policies; route policy tests include Physical Stock lifecycle actions.
- **RLS and restricted runtime role:** discussed in §9.3.
- **Append-only runtime audit rights:** the restricted role can insert/select but not update/delete/truncate audit rows; owner/superuser remains outside that guarantee (`SECURITY-REVIEW.md`).

### 11.2 Residual security/UX gaps

**Status: partial.** API authorization is materially stronger than frontend affordance control. The UI does not consistently expose action-specific rights and direct routes are not client-guarded. Rate limiting is login-only and in-process; production proxy trust, distributed limits, CSP, HSTS, Permissions-Policy, CORS, TLS/WAF, dependency/SBOM review, and an independent penetration test remain unproved (`SECURITY-REVIEW.md`).

Audit writes occur in a response hook after business writes; an audit failure is observable but does not roll back an already completed business mutation. This limitation must be accepted or redesigned for regulated requirements.

## 12. Devices and integrations

| Surface | Current evidence | Status | Required closure |
|---|---|---|---|
| Weighing scale | Desktop serial protocol port and validation in `modules/integrations/deviceBridge.ts`; protocol tests; `DEVICE-BRIDGE.md` | **partial/blocked** | Test actual make/model/driver/firmware, framing, precision, stability, calibration, reconnect, and negative/tare policy. |
| Barcode scanner | Keyboard-wedge path; grid Enter behavior | **partial** | Site scanner model/mode and critical tag workflows under E5/E6. |
| Camera/images | Browser camera component and shared upload path | **partial/blocked** | Browser permission, actual camera, image quality/storage/reopen, failure recovery, and site UAT. |
| Label/invoice printer | Browser/Playwright PDF and report engine | **blocked** | Actual DPI/media/margins/fonts/barcode readability/copy behavior and Crystal/printer baseline. |
| E-invoice/GSP | Payload/transport modules and deterministic tests | **partial/blocked** | Authorized sandbox credentials, GSTIN, duplicate/cancel flows, reconciliation owner, and statutory approval. |
| WhatsApp/SMS | Cloud/API messaging code, idempotency/attempt logging | **partial/blocked** | Provider credentials, approved templates/recipients, retries, delivery/failure evidence, rate limits, and owner sign-off. |
| Live rates | Readiness/config paths | **unverified/blocked** | Provider account, data contract, stale-rate behavior, outage fallback, and reconciliation. |
| Olocker/Firebase/Selenium fallback | Explicit evidence-backed waivers in `WAIVERS.md` | **waived** | Revoke only if owner restores those integrations and supplies contracts/credentials/security acceptance. |

Device and exact Crystal/printer behavior are externally blocked. Static code and protocol tests must not be described as hardware certification.

## 13. Backup, DR, and operations

### 13.1 Logical backup/restore code audit

**Status: unsafe.** `web/apps/api/src/modules/ops/backup.ts` has the following critical hazards:

1. **Only 53 named tables:** `COMPANY_BACKUP_TABLES` does not cover the complete 146-table desktop baseline or all web tenant tables.
2. **100,000-row cap per table:** every export uses `LIMIT 100000` with no truncation error, page loop, or manifest count. A large table can be silently incomplete.
3. **Binary replacement:** `Buffer` values become the literal string `[binary]`, so images/documents cannot be faithfully restored.
4. **Tenant-wide clear, not company clear:** restore receives a company backup but executes `DELETE FROM <table>` without a `CO_CODE` predicate. RLS limits deletion to the tenant, not the selected company; all companies in that tenant can be cleared.
5. **Swallowed row failures:** each row uses a savepoint and catches errors without recording table/row/error in the response. Restore can commit partial data while appearing successful.
6. **Misleading restored counter:** `restored += 1` occurs after `INSERT ... ON CONFLICT DO NOTHING`; a conflicting row that inserts nothing can still be counted as restored.
7. **No dependency/ordering completeness proof:** restore order and conflict behavior are not reconciled against complete business keys, relationships, sequence state, or all satellites.

The comment claiming a “true restore” and saying it can never touch another tenant is too weak for the business scope: cross-tenant deletion may be blocked, but cross-company deletion inside the same tenant is possible.

### 13.2 Existing drill

`project-memory/parity/restore-drill-result.json` records a passing local drill of **5 rows**, **53 cleared table operations**, and 52 checked tables. This is useful E4 harness evidence, but it cannot validate production volume, binary data, >100k tables, multiple companies, partial-row failure, conflict counters, full table coverage, encryption, offsite retention, RPO/RTO, or failover.

### 13.3 Operations and DR decision

**Status: NO-GO.** No live cutover may rely on this logical restore until the unsafe behaviors above are fixed and a production-sized, multi-company, binary-bearing, encrypted restore drill passes with reconciled row counts/checksums/business totals and approved RPO/RTO. `deploy/backup.sh`/`pg_dump` is a separate physical backup path and does not make the in-app logical restore safe.

## 14. Test evidence by E-tier

### E0 — inventory: verified

- 204 forms and category counts: `project-memory/catalogs/module-map.json`, appendix.
- 146 tables/5,254 columns/2,355 defaults/zero identities: `project-memory/catalogs/realdb-schema-full.json`.
- 57 settings keys: `project-memory/catalogs/settings-catalog.json`.
- 255 RPT binaries and 20 absent references: `unified/reports/`, `report-reconciliation.json`.
- 6,973 grid entries, 795 keyboard events, 3,309 calculations, 1,849 validations: behavior index/evidence model.

### E1 — static: partial

- Validation wording heuristic: 435/655 (66.4%).
- UI API-field capture: 492/492 (100.0%), including zero Sales gaps and zero Sales Order gaps.
- Calculation inventory: 1,327 fields, 1,041 mapped to detected written columns—**not calculation parity**.
- Deep writes: 3,280/3,669 (89.4%), 111/122 tables written at all, 11 never written.
- Source inspection verifies current Fastify architecture, posting/RBAC/session/RLS implementation, report/backup limitations, and missing responsive breakpoints.

### E2 — deterministic unit/golden: verified for web behavior, not parity

The fresh workspace test run passed 562 tests. Relevant suites include `posting.test.ts`, `finePolicy.test.ts`, `roundingPolicy.test.ts`, `numbering.test.ts`, `auth.session.test.ts`, `rbac.authorization.test.ts`, `crystalFormula.test.ts`, `reportEngine.test.ts`, device/integration contracts, and workflow tests. G5's fixed golden set passed 15/15 (`project-memory/parity/snapshots/immutable-20260729T081012Z/g5/latest.json`). The reports package itself had no test files and used `--passWithNoTests`; API report tests are separate.

These tests prove selected web functions against authored expectations. A test name or pass does not prove the expectation equals live desktop behavior.

### E3 — controlled web runtime: partial

The immutable-snapshot browser smoke passed its existing broad path (authentication/scope, global F-key navigation, sales lifecycle, stock/tag grids, repair stages/images, melting, Physical Stock, dashboard, and logout). It mocks API calls, so it is controlled frontend regression evidence rather than real posting/database integration. Fastify injection/runtime and route/security tests also passed. The run does not cover all 204 forms, all keyboard paths, all reports, or any desktop execution.

### E4 — real local integration: partial

Retained artifacts document restricted-role PostgreSQL checks, local security observations, lifecycle suites, and the five-row restore drill. In the immutable-snapshot default `pnpm test` run, **148 API tests were skipped**, including sales/purchase/finance/stock/manufacturing/repair/Physical Stock/report staging/security DB suites. The configured target resolved to generic `postgres/datacare`, not a verified isolated disposable test database, so mutation-capable opt-in suites were not enabled. Existing prior successes remain valid narrow artifacts but are not represented as freshly rerun E4 evidence.

### E5 — actual desktop-vs-web comparison: missing

**Zero/not started.** There are no retained passing same-fixture desktop-vs-web executions comparing:

- runtime actions and validations;
- complete database footprints, columns, values, sums, and reversals;
- calculations/rounding under the same configuration;
- keyboard focus/events;
- screenshots;
- PDF/Crystal output;
- physical printer/device outcomes.

G5 is **DEGRADED** because desktop credentials/source and paired vouchers are absent. **No forms were compared.** Its sigma, footprint, voucher-column, and real calculation checks are all skipped.

### E6 — production certification: blocked

**0/720.** `project-memory/parity/G6-STATUS.md` shows production load/soak, deployed security, live observability/on-call, production DR, device UAT, site UAT, live integrations, and business sign-off blocked or not certified. Local evidence cannot override a blocked production row.

## 15. Severity-ranked gap register

| ID | Severity | Gap and impact | Evidence | Status | Testable acceptance criterion |
|---|---|---|---|---|---|
| **C-01** | Critical | No E5 same-fixture desktop/web proof; silent financial/stock divergence can survive all current tests. | G5 latest; appendix E5 columns; G5 harness | **missing/blocked** | Run all 57 posting workflows plus critical masters/reports on approved paired fixtures; retain zero-unexplained-diff DB/calculation/reversal artifacts and keyboard/screenshot/PDF comparisons. |
| **C-02** | Critical | Report binder defaults unknown families to sales and supports few families; formulas/layout/copies are incomplete. Wrong or blank invoices/statutory reports can be produced. | `reportBind.ts`, `reportEngine.ts`, `crystalFormula.ts`, generic report page | **unsafe/partial** | Unknown reports fail closed; every in-scope RPT has an explicit binder/query; all formulas/sections are classified; O/D/T is wired; desktop-vs-web PDF totals/text/layout comparisons pass. |
| **C-03** | Critical | Logical restore can truncate, lose binaries, clear all tenant companies, swallow errors, and overstate restored rows. | `modules/ops/backup.ts`; five-row drill | **unsafe** | Full-table paged/streamed backup with manifest counts/checksums; lossless binary; company-scoped clear; fail-fast/fully reported errors; accurate affected counts; production-sized multi-company restore and business reconciliation pass. |
| **C-04** | Critical | Calculation parity is unproved; 1,041 mapped columns are not formula equality. Fine/tax/rounding errors directly affect money and metal. | `project-memory/parity/snapshots/immutable-20260729T081012Z/CALC-AUDIT.json`; G5 skipped recomputation | **unverified** | Per-workflow golden vectors from approved desktop fixtures cover branches/settings/rounding; live E5 recomputation has zero unexplained differences within approved exact tolerances. |
| **C-05** | Critical | Persistence residuals: 11 tables never written and low-depth sub-detail/tag/manufacturing/Dhiran tables. Reopen, report, downstream, and reversal data may be incomplete. | `project-memory/parity/snapshots/immutable-20260729T081012Z/DEEP-COLUMN-AUDIT-SUMMARY.json` | **missing/partial** | Every table/column is implemented or has an approved evidence-backed waiver with reader/report impact; runtime create/reopen/update/delete comparisons cover complete footprints. |
| **C-06** | Critical | Physical Stock does not yet prove desktop classification, approval, reconciliation, and tag re-issue end to end. | `stock/physicalStock.ts`; page; DB test; `WAIVERS.md` | **partial** | Approved scenarios prove count classification, duplicates, shortage/extra, approval, reconciliation/adjustment, tag re-issue choice, audit, report, and reversal against desktop fixtures. |
| **C-07** | Critical | G6 is 0/720: no production load/security/DR/device/site/integration/business certification. | `G6-STATUS.md` | **blocked** | All mandatory G6 rows pass with retained artifacts and named authorized signers; unresolved waivers explicitly accepted. |
| **C-08** | Critical | No representative production desktop transaction data is supplied; migration and anomaly behavior are untested. | `EXTRACTION-COMPLETENESS-REPORT.md` | **blocked** | Obtain sanitized live backup; ETL to staging; reconcile per-table counts, business totals, money/fine/stock balances, rejected rows, reports, and rollback. |
| **C-09** | Critical | Posting/reversal completeness is not proved across all 57 workflows; a balanced journal can still omit stock, fine, tax, outstanding, tag, audit, or sub-detail rows. | `posting.ts`; behavior specs; deep-column audit | **partial/unverified** | For every posting workflow, paired create/edit/lock/reverse tests reconcile the full table/column/value footprint and prove exact restoration of financial, metal, stock, tag, tax, and outstanding state. |
| **H-01** | High | Sales Order static capture now passes, but its complex stone/diamond fields lack runtime proof; keyboard/dependency/precision/validation or lifecycle/print defects could still corrupt operator outcomes. | `project-memory/parity/snapshots/immutable-20260729T081012Z/UI-FIELD-AUDIT.json`; immutable generator log | **partial/high-risk runtime verification gap** | Representative multi-component rows are keyboard reachable with correct dependencies, precision and validations; create/persist/reopen/update/delete/print passes against desktop fixtures; E5 has zero unexplained differences; the official generator remains passing in release snapshots. |
| **H-02** | High | Generic master scaffolding hides per-form behavior, defaults, validation, search, print, and layout differences. | generic master page/service; form catalogs | **partial** | Each of 33 masters has a contract mapping fields/defaults/dependencies/validations/rights/keyboard/print; E3/E5 tests or explicit waiver close every row. |
| **H-03** | High | Keyboard/grid primitives are inconsistently adopted; 795 desktop events are not accounted for. Operator throughput and correctness can regress. | shared primitives; 14/13/17 adoption counts; behavior index | **partial** | One shared contract is used or deliberate exceptions documented; all critical forms pass keyboard traces and focus-order comparisons against desktop. |
| **H-04** | High | Frontend ignores action-specific rights and direct-route UX; buttons can be shown before API denial. | `Shell.tsx`, app layout, no frontend action-right consumers | **partial** | `/me` exposes effective actions; pages disable/hide Edit/Delete/Print; direct forbidden routes show a deterministic forbidden state; API remains fail closed; tests cover all actions. |
| **H-05** | High | No responsive breakpoints and incomplete accessibility evidence. | `app/globals.css`; source search; page inspection | **missing/partial** | Approved desktop/tablet viewport matrix, keyboard-only operation, automated accessibility scan, screen-reader spot checks, labels/errors/focus/modals/tables, and no critical violations. |
| **H-06** | High | 20 referenced reports are absent; one layout partial and one unavailable. Obligations may fail after cutover. | `report-reconciliation.json`; `WAIVERS.md` | **blocked/waived in part** | Recover reports, prove unreachable, or obtain owner waivers with affected workflows; partial/unavailable reports extracted on compatible Windows Crystal runtime and baselined. |
| **H-07** | High | Devices and live integrations have protocol/static evidence but no actual site certification. | `DEVICE-BRIDGE.md`, `UAT-PLAN.md`, G6 | **blocked** | Actual models/accounts pass happy/failure/retry/offline/calibration/readability/security scenarios at the target site. |
| **H-08** | High | Deployment security controls are incomplete: distributed limits, proxy/TLS/CSP/HSTS, penetration test, SBOM/dependency review. | `SECURITY-REVIEW.md` | **partial/blocked** | Approved production architecture and independent assessment pass; findings are closed/accepted; headers/rate limits tested end to end. |
| **H-09** | High | Existing DB lifecycle tests are opt-in and 148 were skipped in the fresh default run, reducing release-signal reliability. | fresh `pnpm test` output; `RUN_DB_INTEGRITY_TESTS` guards | **partial** | CI provisions PostgreSQL/restricted roles, runs all mandatory DB suites without skip, retains results, and fails release on any skipped mandatory test. |
| **H-10** | High | Settings and validation coverage is partly heuristic; 435/655 wording matches do not prove enforcement, and 57 `CO_SET` keys are not behavior-certified. | `project-memory/parity/snapshots/immutable-20260729T081012Z/VALIDATION-AUDIT.json`; settings catalog/behavior source | **partial/unverified** | Every business-effective setting and critical validation has branch/timing/severity/side-effect tests and paired desktop evidence; UI-only/customer-specific rules are explicitly classified or waived. |
| **H-11** | High | Original/Duplicate/Triplicate behavior is only an isolated Sales API label mapping, not a complete operator/template/print workflow. | `routes/txn.ts`; frontend/report inspection | **partial** | Every applicable document exposes authorized copy selection, applies the approved template/copy labels/counts, retains audit evidence, and matches desktop PDF/physical print behavior. |

## 16. Remediation acceptance specifications

These are release acceptance specifications, not implementation suggestions.

### A1 — correctness and E5 gate (closes C-01/C-04/C-05/C-09)

1. Restore an approved sanitized desktop fixture with representative books/settings and matching PostgreSQL tenant.
2. Execute create, reopen, edit, print, delete/reversal, and locked-date cases for every critical workflow; extend to all 57 posting workflows before parity sign-off.
3. Compare complete business-keyed rows across header/detail/sub-detail/ledger/tax/outstanding/stock/tag/rojmel/scheme/manufacturing/repair tables.
4. Require zero unexplained row, column, value, sign, sum, and satellite differences. Tolerances must be explicit per field and approved; “close enough” global rounding is prohibited.
5. Retain per-form artifacts and mark E5 only from actual paired execution.

### A2 — report/print gate (closes C-02/H-06/H-11)

1. Replace report-family inference/fallback with an explicit registry; unknown report/binder combinations fail closed.
2. Map every in-scope RPT and every referenced obligation to query, parameters, formulas, layout, copy semantics, and printer profile.
3. Implement or explicitly waive unsupported Crystal constructs only after impact analysis.
4. Run same-fixture desktop/web PDF extraction and compare text, totals, page count, grouping, suppression, barcode/QR/images, fonts, coordinates/margins, and O/D/T labels/copy counts.
5. Certify actual printers/media/DPI; statutory outputs require finance/tax owner sign-off.

### A3 — backup/restore/DR gate (closes C-03/C-07)

1. Generate a complete schema-driven manifest rather than a 53-table allowlist, or prove and version an exhaustive allowlist.
2. Remove silent row caps; record expected/exported/restored/skipped/conflicted/failed counts per table.
3. Encode binary losslessly and verify checksums.
4. Scope logical restore to tenant **and company** where the artifact is company-specific; protect other companies with a negative test.
5. Fail the transaction on any unapproved row error; never swallow exceptions or count no-op conflicts as restored.
6. Run encrypted offsite backup and production-sized restore/failover; reconcile DB counts/checksums and money/fine/stock/report control totals; meet approved RPO/RTO.

### A4 — Sales Order runtime/UI gate (closes H-01/H-03/H-04/H-05)

1. Preserve the complete static capture now detected for Sales Order and map its complex stone/diamond fields to desktop-equivalent dependencies, validation timing/side effects, precision/rounding, and keyboard order.
2. Prove keyboard entry plus create/persist/reopen/update/delete/print round-trip with representative multi-component rows and same-fixture E5 comparisons.
3. Implement effective frontend action rights and deterministic forbidden-route UX.
4. Standardize grid/form primitives and run keyboard traces, accessibility checks, and approved viewport tests.
5. Keep the official generator passing without bypass in every immutable release snapshot; any regression fails the gate.

### A5 — Physical Stock gate (closes C-06)

1. Define desktop-approved classification for matched/missing/extra/ambiguous tags and weight variance.
2. Implement/approve count lifecycle, review/approval, reconciliation/adjustment, tag re-issue, audit, and print behavior.
3. Prove stock is unchanged before authorized adjustment and changed exactly once afterward.
4. Compare complete desktop/web DB footprints and variance documents over duplicate tag numbers with distinct serial identities, sold/transferred tags, partial counts, locks, update, and reversal.

### A6 — production certification gate (closes C-07/H-07/H-08/H-09)

1. Make mandatory restricted-role DB suites non-skippable in release CI.
2. Complete production-like capacity/soak against approved SLOs.
3. Complete deployed security review/penetration test and close findings.
4. Complete observability alert delivery/on-call exercise.
5. Certify actual devices and external services at the target site.
6. Complete operator UAT with finance, inventory/manufacturing, tax/report, security/deployment owners.
7. Record dated, authorized GO signatures only after E5 and all mandatory G6 units pass.

### A7 — settings and validation gate (closes H-10)

1. Classify all 57 `CO_SET` keys as business-effective, UI-only, obsolete, customer-specific, or waived, with owner and source evidence.
2. For each business-effective key, test default, override, invalid/missing, and branch interactions through create/reopen/update/reversal/report flows.
3. Convert the 655 validation inventory from text matching into executable contracts that preserve condition, timing, blocking/warning level, message, and side effects.
4. Run representative same-fixture desktop/web cases; retain intentional hardening divergences and licence-specific exclusions as explicit approvals.

## 17. Blockers and waivers

### 17.1 Current blockers

- Reachable desktop SQL Server/runtime with sanitized representative shop transactions.
- Matching paired desktop/web vouchers and `G5_FORMS` configuration.
- Original/live deployed copies or authoritative disposition of 20 absent referenced reports.
- Compatible Windows Crystal runtime for partial/unavailable report extraction and desktop baselines.
- Actual printers, scales, scanners, cameras, drivers, firmware, media, and approved workstation/browser.
- GSP/e-invoice, WhatsApp, SMS, live-rate and other provider test accounts/credentials.
- Production-like deployment, traffic/SLO, monitoring/alerts/on-call, offsite backup/KMS/secondary recovery environment.
- Named operators and authorized finance, inventory/manufacturing, tax/report, security/deployment, and business signers.

### 17.2 Accepted/conditional waivers

`project-memory/parity/WAIVERS.md` is the authority for individual waivers and revocation conditions. Important examples include helper/DTO classes that are not independent forms, UAE VAT sale/return variants currently out of Indian deployment scope, UI-only theme/start-menu behaviors, licence-specific rules, Selenium WhatsApp fallback, Firebase without a callable contract, `MENU_DATA` architectural equivalence, and report extraction constraints.

A waiver is not a test pass. It must identify the lost user-visible behavior, reason, authority, impact, and revocation condition. Financial, inventory, tax, legal, or data-loss obligations cannot be waived implicitly because a parser reports zero columns or a route is absent.

## 18. Final go/no-go

### Decision

**NO-GO for live financial/inventory migration.**

The web rewrite should be described as **broad and substantial implementation with strong foundational controls**, not as exact parity. The strongest verified areas—atomic tenant-scoped posting, balanced-ledger checks, persisted-date locks, scoped numbering, named fine policies, configurable rounding, RLS/restricted roles, secure session lifecycle, API form RBAC, and real lifecycle modules—justify continued remediation and controlled testing. They do not offset missing E5/E6 evidence, report uncertainty, persistence residuals, the Sales Order runtime verification gap, Physical Stock proof gaps, and unsafe logical restore behavior.

A future GO requires, at minimum:

1. C-01 through C-08 closed or formally accepted where acceptance is legally/operationally permissible;
2. H-01 through H-09 closed or explicitly waived with authority and impact;
3. official parity generator remaining passing without bypass in immutable release snapshots;
4. actual same-fixture desktop-vs-web E5 evidence for all critical and then all posting workflows;
5. report/PDF/printer and restore/DR gates passing;
6. mandatory production certification no longer 0/720;
7. dated business, finance, inventory/manufacturing, tax/report, and security/deployment sign-off.

## 19. Appendices and evidence paths

### 19.1 Exhaustive form appendix

- [All 204 canonical desktop forms, current immutable-snapshot static metrics, and E5/E6 not-started status](./END-TO-END-PARITY-FORM-APPENDIX-2026-07-29.md) — repository path: `project-memory/parity/END-TO-END-PARITY-FORM-APPENDIX-2026-07-29.md`.

### 19.2 Primary desktop evidence

- `unified/src/csharp/DataCareNext/`
- `project-memory/parity/DESKTOP-ERP-EVIDENCE-MODEL.md`
- `project-memory/catalogs/module-map.json`
- `project-memory/catalogs/form-behavior/`
- `project-memory/catalogs/form-logic/`
- `project-memory/catalogs/layouts/`
- `project-memory/catalogs/realdb-schema-full.json`
- `project-memory/catalogs/settings-catalog.json`
- `project-memory/catalogs/report-reconciliation.json`
- `project-memory/catalogs/report-layouts/`
- `unified/reports/`

### 19.3 Fresh audit evidence

- `project-memory/parity/snapshots/immutable-20260729T081012Z/VALIDATION-AUDIT.json`
- `project-memory/parity/snapshots/immutable-20260729T081012Z/UI-FIELD-AUDIT.json`
- `project-memory/parity/snapshots/immutable-20260729T081012Z/CALC-AUDIT.json`
- `project-memory/parity/snapshots/immutable-20260729T081012Z/DEEP-COLUMN-AUDIT.json`
- `project-memory/parity/snapshots/immutable-20260729T081012Z/DEEP-COLUMN-AUDIT-SUMMARY.json`
- `project-memory/parity/snapshots/immutable-snapshot-20260729T081012Z.txt`
- `project-memory/parity/snapshots/immutable-generator-20260729T081012Z.log`
- `project-memory/parity/snapshots/immutable-20260729T081012Z/DESKTOP-WEB-PARITY-MATRIX.json` — current official 204-form matrix generated at 2026-07-29T08:12:14+00:00

### 19.4 Web architecture and critical source

- `web/apps/web/package.json`
- `web/apps/api/package.json`
- `project-memory/decisions/ADR-0003-http-fastify.md`
- `web/apps/api/src/modules/posting/posting.ts`
- `web/apps/api/src/modules/vouchers/numbering.ts`
- `web/apps/api/src/modules/shared/finePolicy.ts`
- `web/apps/api/src/modules/shared/roundingPolicy.ts`
- `web/apps/api/src/modules/rbac/authorization.ts`
- `web/apps/api/src/modules/rbac/routePolicy.ts`
- `web/apps/api/src/modules/auth/session.ts`
- `web/packages/db/prisma/rls.sql`
- `web/packages/db/setup_roles.sql`
- `web/packages/db/prisma/migrations/`
- `web/apps/api/src/modules/reports/reportBind.ts`
- `web/apps/api/src/modules/reports/reportEngine.ts`
- `web/apps/api/src/modules/reports/crystalFormula.ts`
- `web/apps/api/src/modules/ops/backup.ts`
- `web/apps/api/src/modules/stock/physicalStock.ts`
- `web/apps/web/app/(app)/txn/physical-stock/page.tsx`
- `web/apps/web/app/(app)/masters/[name]/page.tsx`
- `web/apps/web/app/(app)/reports/[report]/page.tsx`
- `web/apps/web/components/{Shell,KeyboardNav,GridKeyboard,FormKeys,ExtendedGrid}.tsx`
- `web/apps/web/app/globals.css`

### 19.5 Test, readiness, and operations evidence

- `project-memory/parity/snapshots/immutable-20260729T081012Z/g5/latest.json`
- `project-memory/parity/G5-HARNESS.md`
- `project-memory/parity/G6-STATUS.md`
- `project-memory/parity/SECURITY-REVIEW.md`
- `project-memory/parity/DEVICE-BRIDGE.md`
- `project-memory/parity/UAT-PLAN.md`
- `project-memory/parity/WAIVERS.md`
- `project-memory/parity/restore-drill-result.json`
- `project-memory/parity/DR-RUNBOOK.md`
- `web/apps/api/test/`
- `web/apps/web/test/`
- `project-memory/parity/snapshots/validation-lint-20260729T081012Z.log`
- `project-memory/parity/snapshots/validation-typecheck-20260729T081012Z.log`
- `project-memory/parity/snapshots/validation-test-20260729T081012Z.log`
- `project-memory/parity/snapshots/validation-build-20260729T081012Z.log`
- `project-memory/parity/snapshots/validation-report-baselines-20260729T081012Z.log`
- `project-memory/parity/snapshots/validation-browser-20260729T081012Z.log`

---

## Signed-off decision block

**Audit conclusion:** **NO-GO**  
**Parity status:** **PARTIAL — broad/substantial implementation; exact parity unverified**  
**Migration safety:** **UNSAFE for live financial/inventory cutover**  
**E5 actual desktop comparisons:** **0 / not started**  
**E6 production certification:** **0/720 / not started or blocked**  
**G5:** **DEGRADED; 15 fixed vectors passed; desktop SQL checks skipped**  
**Required next decision:** fund and execute the acceptance specifications above; do not relabel static coverage or web-only tests as parity.

**Audit sign-off:** Kiro parity audit, evidence cutoff 2026-07-29. This is a technical readiness decision, not business, tax, security, or production approval.

**Unresolved external dependencies:** sanitized representative desktop data/runtime and paired vouchers; absent/legacy Crystal reports and Windows runtime; actual devices/printers; external-service sandboxes/credentials; production-like infrastructure/monitoring/DR; customer-site operators; and named authorized signers.
