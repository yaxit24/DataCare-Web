# DataCareNext Web Implementation — Current-State Audit

**Audit baseline:** 2026-07-26  
**Workspace:** `web/`  
**Desktop baseline:** `project-memory/parity/DESKTOP-ERP-EVIDENCE-MODEL.md`  
**Status:** broad working implementation, **not desktop-parity certified and not production-ready**.

## 1. Executive result

The current web product is not a placeholder. It has a working Next.js/Fastify/PostgreSQL architecture, substantial transaction code, rich implementations for several high-value screens, broad schema coverage, RLS policy generation, balanced-ledger primitives, a real tag-label path, and a production build that succeeds.

It is nevertheless unsafe to deploy for real jewelry businesses in its present form. Route, page, model, and green-unit-test counts materially overstate parity because:

- at least 81 of 160 unique navigation destinations are handled by only two generic renderers;
- database posting tests do not invoke the real posting/reversal/numbering/tenant transaction functions;
- several proven data-integrity defects can corrupt stock or voucher identity;
- per-form desktop rights are not enforced by API routes;
- active company/year/location scope can be overridden by request data inside a tenant;
- reporting is mostly generic datasets/HTML plus a geometry viewer, not a Crystal-equivalent engine;
- no report or form has a desktop image/PDF/print comparison;
- no frontend, browser E2E, visual, load, concurrency, automated RLS, migration, backup-restore, or device test suite exists;
- production observability, readiness, DR, and hardware bridging are incomplete.

Passing TypeScript, unit tests, Prisma validation, and compilation prove useful engineering hygiene. They do **not** prove the desktop invariants or production safety.

## 2. Evidence and freshness rules

This audit uses current source and executed commands. It does not inherit “matches” labels from the tutorial KB or older depth audits. Important documentation contradictions:

- Root `README.md` says NestJS; the API is Fastify.
- `apps/web/README.md` describes a placeholder/Tailwind/shadcn/AG Grid surface; at the baseline audit time the UI was a custom Next.js app with 86 pages.
- `docs/security/security-review.md` says there was no UI and transaction modules were not HTTP-exposed; both are stale.
- Historical audits predate the form/report geometry viewers, tag printing, richer karigar form, and current API routes.
- Current comments claiming “single source of truth,” “pixel-exact,” or “verified” were checked against implementation and are not accepted at face value.

## 3. Verified quantitative snapshot

| Surface | Current quantity | Interpretation |
|---|---:|---|
| Next `page.tsx` files | 86 | production build generated 87 static pages including framework routes |
| Page source LOC | 9,128 | source only, excludes `.next` |
| Transaction pages | 56 | includes thin re-export routes to shared forms |
| Navigation groups/entries | 10 / 162 | all 162 entries set `ready: true`; 160 unique hrefs |
| Unique master destinations | 38 | 5 bespoke, **33 generic** through `masters/[name]` |
| Unique report destinations | 52 | 4 bespoke, **48 generic** through `reports/[report]` |
| API TypeScript source files/LOC | 106 / 17,714 | actual current source |
| Declared Fastify routes | 247 | 16 in `app.ts`, 231 in `routes/txn.ts` |
| API test files/tests | 38 / 181 | all pass; almost all builder/pure/mock level |
| Other passing package tests | 25 | core 13, DB 3, parity 6, types 3 |
| Frontend tests | **0** | web test command passes through `--passWithNoTests` |
| `@datacare/reports` tests | **0** | package itself contains only a six-line marker export |
| Manual integration scripts | 27 `.mjs` | 22 named `*.live.mjs`; not part of default tests or CI |
| Prisma models / mapped tables | 163 / 162 | one unmapped model is `audit_log` |
| RLS ENABLE/FORCE/policies in `rls.sql` | 162 / 162 / 162 | covers the 162 Prisma-mapped tables, not `audit_log` or four raw-migration-only tables |
| Prisma migrations | 2 | initial + additive schema-parity SQL |
| Desktop tables shared with Prisma mappings | 142/146 | four tables exist only in raw migration DDL, not Prisma schema |
| Desktop business columns represented in Prisma | 5,141/5,254 (~97.8%) | physical migration adds some missing schema, but Prisma remains drifted |
| Report spec files in API | 254 | 253 indexed; web copy of `SalesQuotation` remains an error stub |
| Report layouts with current web index entry | 253/255 | no `TagStkIdtlRpt`; partial SalesQuotation not propagated |
| Web form-layout asset files / normalized desktop form IDs | 175 files / 163 of 204 (~79.9%) | 160 initcomp + 15 layout files; 12 namespaced layouts duplicate initcomp form IDs; static preview evidence, not functional forms |
| Report data bind families | 3 | sales, purchase, karigar; unknown reports default to sales |
| Desktop-compared forms/reports | **0 proven** | no visual or PDF comparison test exists |

### Exact schema reconciliation

Direct set comparison of `realdb-schema-full.json` with current `schema.prisma` found:

- shared mapped tables: 142;
- desktop tables absent from Prisma models: `COUNTRY_MAST`, `IMAGE_DATA`, `LBR_ISU_IDTL`, `OP_DETL`;
- those four are created by raw migration `20260714010000_schema_parity/migration.sql`, creating migration/schema drift;
- 22 authoritative desktop columns are absent from shared Prisma models (20 in `TAG_DATA`, two in `DM_DATA`), although the parity migration adds those columns physically;
- 37 additional business columns exist in shared Prisma models;
- 21 web-only mapped/model tables include `TAG_STOCK`, `USER_SET`, `MENU_DATA`, companion/franchise/image tables, and `audit_log`.

This is high breadth, but model count is not functional parity and raw-migration-only tables are at risk during future schema evolution.

## 4. Architecture as implemented

### 4.1 Frontend

- Next.js 15.1.6 App Router and React 19.
- Client-rendered application shell under `apps/web/app/(app)`.
- Same-origin `/api` rewrite to Fastify.
- Custom CSS and custom grids/forms; no AG Grid or design-system dependency despite stale docs.
- Cookie-based API session check in client layout.
- Shared `LookupPicker`, `KeyboardNav`, `VoucherChrome`, `VoucherList`, `TenderPanel`, `PartyBalance`, `RateTicker`, `PaymentForm`, and `KarigarForm`.

### 4.2 API

- Fastify 5 application.
- One large route registry (`routes/txn.ts`, 1,210 LOC) plus foundation/master/auth routes in `app.ts`.
- Domain modules for sales, purchase, finance, stock, manufacturing, schemes, Dhiran, GST, e-invoice, integrations, reports, forms, settings, backup, audit, year end, and parity.
- Raw parameterized SQL through Prisma transactions.

### 4.3 Data

- PostgreSQL with Prisma schema mapped to desktop-style table names.
- `tenant_id` added to mapped tables.
- RLS policies use transaction-local `app.tenant_id` set by `withTenant()`.
- Surrogate `row_id` added while many voucher tables retain composite desktop business keys.
- Manual RLS/role bootstrap remains outside Prisma migration history.

### 4.4 Reporting

There are three separate report paths:

1. bespoke invoice/voucher/statutory HTML templates;
2. generic JSON report endpoints displayed by one auto-table React page;
3. extracted Crystal geometry rendered as absolute-position HTML with a minimal formula evaluator.

The `@datacare/reports` package does not implement the report system; the working code is in the API.

## 5. Proven strengths

### 5.1 Buildable, typed foundation

- Workspace typecheck passes across seven packages.
- API tests execute successfully: 38 files, 181 tests.
- Production build succeeds; Next compiled and generated all 87 static pages.
- Prisma schema validates.
- Root install is lockfile-backed and Docker uses `--frozen-lockfile`.

### 5.2 Real functional breadth

Representative nontrivial implementations include:

- sales, purchase, sales return and purchase return;
- mixed tenders, hallmark/TCS/kasar/order advance and old-metal entry;
- rich current karigar issue/receive grid with ghat, wastage, labour, GST and optional tag generation;
- rate cut, bill-to-bill, batch receipt, journals and account opening;
- stock/tag opening, split, transfer, cancel, weight difference, physical comparison and label printing;
- manufacturing issue/receive and Dhiran/scheme workflows;
- company/year context selectors and an admin user/form-rights editor;
- e-invoice, WhatsApp/SMS abstractions and live-rate integrations.

This is materially deeper than older audits describe.

### 5.3 Useful shared UX primitives

- `LookupPicker` supports F1, arrow navigation, Enter selection, Escape close, type-ahead, and side-field filling.
- `KeyboardNav` implements Enter-to-next-input and Ctrl/Cmd+Enter submit.
- `VoucherChrome` supports date/ref/employee/bank/description, previous/next hooks, print copy selection, save/cancel/delete/exit.
- `VoucherList` exposes recent vouchers and reversible-delete endpoints.
- `RateTicker` and party money/metal balances support desktop-style operational context.

### 5.4 Accounting and transaction foundations

- Posting uses interactive transactions through `withTenant()`.
- `assertBalanced()` is called before ledger writes.
- Voucher tables generally carry company/location/year/book/voucher fields.
- Tax split and per-group sales/purchase account allocation exist.
- SQL values are parameterized; dynamic identifiers pass through internal allowlists/sanitizers.
- New user passwords are Argon2id hashed.

### 5.5 Tag output

- Tag print is no longer absent: it lists in-stock `BAR_DETL` tags and renders print-ready Code39 labels.
- Code39 encode/decode behavior and label contents are directly unit tested.
- HUID, gross/net weight, touch, MRP, item/design and selected-tag printing exist.

### 5.6 PDF renderer can work outside the container

A direct local smoke test of `PlaywrightPdfRenderer` succeeded and returned an 8,628-byte `%PDF-` buffer. The implementation is therefore viable when a compatible Chromium binary is actually available. The production images do not yet guarantee that condition.

## 6. Critical data-integrity blockers

### C1. Loose/bulk stock is not posted by core sale/purchase/return flows

**Evidence:**

- `sales.ts` builds `MAIN_STOCK` only after `.filter((c) => c.in.tagNo)`.
- `purchase.ts` does the same.
- `salesReturn.ts` and `purchaseReturn.ts` also build movement rows only for lines with tags.
- `onHandNet()` explicitly declares `MAIN_STOCK` the full signed stock truth.

**Impact:** a valid loose/bulk sale, purchase, or return writes commercial detail and ledger rows but no inventory movement. Stock reports and valuation diverge immediately.

**Required correction:** every inventory line must emit the module-correct signed movement. Tag identity is optional; stock movement is not. Add integration tests proving before/after bulk and tagged balances and reversal.

### C2. Sale/purchase deletion depends on tag data the UI never sends

**Evidence:**

- `deleteSale()` restores `TAG_STOCK` only from optional client body `tagRestores`.
- `deletePurchase()` removes created `TAG_STOCK` rows only from optional `tagRemovals`.
- `VoucherList.remove()` calls `DELETE /.../:vchNo` with no body.
- Sales/purchase pages use this `VoucherList` directly.

**Impact:**

- deleting a sale of a web-created tag leaves the tag absent from `TAG_STOCK`;
- deleting a purchase leaves its created tag available even though purchase/stock movement rows are gone;
- the UI confirmation “reverses ledger + stock” is false for this lifecycle.

**Required correction:** the API must derive all reversal artifacts from persisted voucher details inside the same transaction. A client must never be authoritative for reversal state.

### C3. Voucher numbering has a scope/concurrency mismatch

`nextVoucherNoTx()` acquires an advisory lock using tenant/company/location/year/book but reads and updates a single `SRNO_MAST` row keyed only by company/location. The model has no unique constraint on that key and no year/book fields.

Consequences:

- numbering is shared across books/years instead of reproducing book/year sequencing;
- different books acquire different locks but update the same counter row concurrently;
- first-row creation is not protected by one common row-scope lock or unique key;
- tests cover only `scopeKey()` string creation, not allocator behavior or concurrency.

A dedicated sequence table keyed by tenant/company/location/year/book, or a proved desktop-equivalent per-book max/lock algorithm, is required.

### C4. A universal fine helper is applied to contexts with different desktop formulas

`shared/fine.ts` claims one canonical formula:

`(NetWt + GhtWt) × (Touch + West%) / 100`

It is used by sales, purchase, sales order, tag opening, item opening, lots, transfers and other workflows. That contradicts the desktop evidence model:

- sales/manufacturing paths can use `(net+ght)×(touch+west)/100`;
- purchase/karigar-receipt paths observed use `net×(touch+west)/100`;
- opening/melting-input/karigar-issue paths often use `net×touch/100`;
- some purchase/karigar branches require unresolved adjustments.

`purchase.test.ts` explicitly locks in `(net+ght)×(touch+west)/100`, despite its neighboring comment saying `net×touch/100`. The client sale and purchase previews both hard-code `net×touch/100`, and the sales page does not submit ghat/wastage fields at all.

**Impact:** metal fine, valuation, stock and account balances can disagree with the desktop and with the UI preview.

**Required correction:** introduce named per-workflow policies with desktop vectors, remove the universal assertion, and test each caller.

### C5. Active company/location/year context is not authoritative

RLS isolates only `tenant_id`. Within a tenant:

- `scopeOf()` accepts body `coCode`, `lcCode`, and `coYear` over session values;
- `readScope()` accepts query overrides;
- `context/select` checks only whether a year exists anywhere, then mints a token for any requested company;
- it does not prove the user is authorized for that company/year;
- it drops location and `scopeOf()` then defaults location to `session.lcCode ?? session.coCode`, so company `02` can silently become location `02`;
- generic master list reads every row in the tenant with no active-company predicate;
- generic create/update/delete accept business keys supplied by the client;
- the exported `buildScopeWhere()` helper is not used by application modules.

**Impact:** users can read or mutate another company/year within the same tenant, and location keys can be wrong. This is both security and accounting isolation failure.

**Required correction:** issue server-validated company/location/year grants, derive scope only from the session/context, reject body/query overrides except explicit authorized context-switch endpoints, and enforce scope in all service queries.

## 7. High-severity authorization, schema, reporting, and runtime blockers

### H1. Desktop per-form rights are not enforced by API routes

`USER_SET` rows and the admin matrix exist. `resolveAllowedForms()` returns only viewable form names to `/me`, and the shell hides navigation links. API guards call only `assertRight()` against three global `LOGIN_MAST` flags.

Thus a user who knows an endpoint can bypass per-form View/Edit/Delete/Print restrictions. “No USER_SET rows means unrestricted” also fails open for unconfigured non-admin users.

Server policy must receive the form/action and enforce `USER_SET` on every route.

### H2. Delete bypasses lock-date enforcement

`postVoucherTx()` calls `assertPeriodOpen()`. `reverseVoucherTx()` does not. The lock helper also fails open for missing/unparseable dates and catches schema errors as no lock.

Locked periods must reject create, update, delete, renumber and any stock/ledger mutation unless an explicit privileged reopening workflow is recorded.

### H3. Real desktop-tag issue has a race

For `TAG_STOCK`, issue is an atomic delete. For imported desktop `BAR_DETL`, `issueTagTx()` separately counts the tag and counts prior minus movements without locking the tag row or using a uniqueness constraint. Concurrent sales can both pass before either writes `MAIN_STOCK`.

Use row/advisory locking or an availability/reservation table with a unique active-consumption constraint and concurrency tests.

### H4. RLS is complete in design but operationally fragile

Positive: all 162 Prisma-mapped tables have ENABLE, FORCE and a tenant policy in `rls.sql`; `withTenant()` uses transaction-local scope; root Compose uses non-superuser `app_user`.

Blockers:

- the initial migration contains no RLS; policy setup is a manual post-migration command;
- CI starts PostgreSQL but applies neither migrations nor RLS and runs no isolation test;
- the application performs no startup assertion that its role is non-superuser or that required policies are enabled/forced;
- `setup_roles.sql` seeds a known password and requires a manual password update;
- four raw parity-migration tables have ENABLE+policy but not FORCE and are absent from `rls.sql`;
- local project Compose is not running, so destructive manual isolation scripts were correctly not run against the unrelated PostgreSQL on port 5432.

Make RLS/role verification an idempotent migration/deploy gate and a startup readiness assertion; run cross-tenant tests in CI.

### H5. `audit_log` deployment is drifted and failures are silent

`audit_log` is in Prisma schema but not either Prisma migration and not `rls.sql`. Its DDL/policy exist only in `deploy/sql/audit_log.sql`, which the current `DEPLOY.md` bootstrap does not apply. `logAudit()` swallows all failures while `/audit` can fail.

Put DDL and FORCE RLS in a migration, restrict audit read access, make audit durability observable, and add retention/tamper-evidence policy.

### H6. Plaintext-password migration is not completed

`verifyWithMigration()` permits a matching desktop plaintext password and returns `forcedReset: true`. Login neither rehashes nor blocks the session. The frontend discards the response and always routes to `/select`; there is no reset endpoint/page.

The login form also ships with demo company/user/password values prefilled. Production must force one-time reset or atomically rehash at successful login, remove demo defaults, add secret-strength guards, and implement session/token revocation/refresh policy.

### H7. Report rendering is not Crystal parity

The layout engine currently supports positioned text, fields, and generic line/box divs. It lacks proven support for:

- pictures/images, embedded barcodes/QR and subreports;
- original font family/size/weight/color and border style;
- page breaks and repeated page/group headers/footers;
- conditional suppression/formatting;
- grouping, running totals and Crystal print-state variables;
- printer/page setup behavior.

The formula evaluator explicitly supports a small subset and returns an empty string on parse failure. Of 5,991 extracted formulas, no coverage metric proves semantic support.

`reportBind.ts` recognizes only `SL_DATA`, `PR_DATA`, and `KR_DATA`; an unrecognized report silently defaults to sales data. This can render plausible but wrong output.

Claims of “pixel-exact” must be removed until font, object, pagination, formula, dataset and image-diff gates pass.

### H8. Web report assets are stale relative to recovered extraction

- `web/apps/api/report-specs/SalesQuotation.spec.json` remains a one-error stub.
- The recovered 30-section/155-object/34-formula partial spec exists under `project-memory/catalogs/report-layouts/` but has not been propagated.
- The web index has 253 entries, not 254.
- `TagStkIdtlRpt` remains unavailable, as expected.

### H9. PDF fallback can return a content-free “success”

`FakePdfRenderer` produces a minimal PDF containing only a comment about HTML byte length. Every PDF endpoint catches any real-renderer failure and returns the fake with HTTP success.

Local direct Playwright rendering works, but neither Dockerfile installs/copies Chromium into the runtime stage. A container can therefore silently return fake documents.

Production must fail readiness or the request when real rendering is unavailable; the image must install a pinned browser and include a rendered-content smoke test.

### H10. No desktop comparison evidence

There are no screenshot/image-diff tools, golden browser tests, report PDF comparisons, or physical-printer comparisons. `packages/parity` compares rows only, and current tests use toy objects. The parity gate “desktop-compared” is zero for all forms/reports.

## 8. Medium-severity functional and UX gaps

### 8.1 Generic breadth is not desktop interaction parity

- 33/38 unique master routes are one generic metadata CRUD page.
- 48/52 unique report routes are one generic auto-table page with mostly only year and optional account filters.
- all 162 nav entries say ready, making the dormant “soon” mechanism meaningless.

Generic forms are valuable scaffolding but do not reproduce left-list/right-editor behavior, auto-code rules, field-level validation, module tabs, images/family grids, or exact focus order.

### 8.2 Keyboard parity is partial

Implemented: F1 lookup, arrows/Enter/Escape inside lookup, Enter-to-next input, Ctrl/Cmd+Enter save.

Missing as global, context-correct workflows: F2/F3/F4/F5/F7/F8/F9/F11/F12, Escape-to-tender, exact form/grid focus order, MSFlexGrid row behavior and shortcut conflict tests.

### 8.3 Complex forms remain simplified

Even improved pages omit parts of the desktop:

- sales has no ghat/wastage inputs and no separate charge sub-grid;
- purchase lacks purchase-specific ghat/less-touch/fine-cut controls and inline full tagging;
- karigar receive combines many fields into one grid but lacks the separate stone/diamond grid, rich tag grid, tender/outstanding settlement, full voucher chrome, images and copy-print flow;
- physical stock is primarily comparison rather than a certified posting workflow;
- many forms lack load/edit navigation and use ad hoc rather than shared voucher chrome.

### 8.4 Rounding is globalized

`billTotals()` rounds the final voucher to whole units without proving book/CO_SET policy. Desktop evidence says rounding is book/config dependent. This requires a typed policy registry and vectors per book.

### 8.5 Dhiran, scheme, loyalty, average touch and melting semantics remain uncertain

Code exists, but repository evidence itself acknowledges unresolved Dhiran modes. Scheme/loyalty guards, average-touch rebuild and melting/VP/gold-book semantics are not desktop-compared.

### 8.6 Tag printing is functional but not hardware-certified

Code39 label HTML is real and tested. Missing evidence includes printer DPI/media calibration, label skip/offset, all desktop template variants, QR format parity, scanner round-trip on shop hardware, browser kiosk behavior and failure recovery.

## 9. Production and operations findings

### 9.1 Two contradictory deployment stacks exist

- Current `DEPLOY.md` points to root `docker-compose.yml`, `Dockerfile.api`, `/health`, port 4000 and no Redis. This is the coherent path.
- `deploy/docker-compose.prod.yml` points to `apps/api/Dockerfile`, port 3000, Redis and `/ready`.
- `apps/api/Dockerfile` runs nonexistent `prisma:generate` and suppresses failure with `|| true`.
- `/ready` is not registered.

Delete or quarantine the stale stack; one release path must be authoritative and tested.

### 9.2 Observability is absent

- Fastify is created with `logger: false`.
- no structured request/business/security logging pipeline;
- no metrics, tracing, exception aggregation, alert rules or dashboards;
- health route is liveness only; a DB-readiness helper exists but is not exposed.

A financial/inventory system cannot operate without voucher-correlated logs, invariant alerts and dependency readiness.

### 9.3 Rate limiting and session hardening are incomplete

- only login is rate limited;
- reports, imports, backup, render and mutations are unthrottled;
- cookies omit `Secure` in application code and depend on proxy rewriting;
- JWT has a development fallback even in production;
- a seven-day refresh cookie is issued but no refresh route consumes it;
- logout has no server-side revocation.

### 9.4 Backup/DR is only a starting point

`deploy/backup.sh` provides `pg_dump -Fc` and local retention. Off-host encrypted copies, automated restore drills, integrity checks, point-in-time recovery, RPO/RTO, tenant restore/reconciliation and incident runbooks are not implemented or evidenced.

### 9.5 CI is incomplete and currently fails its own formatting gate

- CI runs install, typecheck, unit tests, build and format check.
- Current `pnpm format:check` fails with **704 files**.
- `pnpm lint` runs zero tasks.
- CI does not apply migrations/RLS or run live tests.
- no SCA, secret scan, container scan, migration drift check, E2E, visual, accessibility, load, concurrency or restore test.

### 9.6 Dependency policy is inconsistent

The web package pins exact versions, but root/API/DB package manifests use open caret ranges. The lockfile makes current installs reproducible, but future dependency changes must be exact/pinned per project policy and validated through automated update review.

### 9.7 No hardware/local bridge

Project-source search found no WebSerial/WebUSB/HID, webcam media capture, scale protocol, printer bridge or signed local agent. Browser barcode rendering alone does not cover the desktop hardware surface.

### 9.8 External services are wired but not certified

WhatsApp/SMS, rates and e-invoice have environment-selected real/fake transports. Production credentials, provider certification, retries/idempotency, rate limits, reconciliation, alerting, legal retention and outage behavior require live sandbox/production evidence.

## 10. Validation executed

| Command/check | Result |
|---|---|
| `pnpm typecheck` | pass: 10/10 Turbo tasks |
| `pnpm --filter @datacare/api test` | pass, uncached: 38 files / 181 tests |
| root `pnpm test` | pass from valid Turbo cache; total passing assertions across tested packages = 206; web/reports have no tests |
| `pnpm build` | pass: API TypeScript build + Next production compile + 87 static pages |
| `pnpm --filter @datacare/db run db:validate` | pass: Prisma schema valid |
| `pnpm format:check` | **fail:** 704 files need formatting |
| `pnpm lint` | exits 0 but executes **0 tasks** |
| direct Playwright PDF smoke | pass locally: 8,628-byte `%PDF-` output |
| source test grep | no unit test invokes `createSale`, `createPurchase`, `postVoucherTx`, `nextVoucherNoTx`, `issueTagTx`, `reverseVoucherTx`, `deleteSale`, `receiveKarigar`, `postReceipt`, `issueDhrn`, `$transaction`, or `withTenant` |
| local project DB check | Compose stack not running; expected project port 5433 has no response |
| port 5432 check | accepts connections but is an unidentified local DB; mutating live scripts were not run against it |
| schema/RLS set comparison | 163 models, 162 mapped, 162 ENABLE+FORCE+policy entries, drift detailed above |
| visual/E2E/load/restore/device test | unavailable: no automated suites/environment |

## 11. Evidence-based readiness ratings

Scale: **0 absent; 1 prototype; 2 partial with material risk; 3 substantial but uncertified; 4 close with comparison evidence; 5 desktop-compared and production-certified.**

| Dimension | Rating | Reason |
|---|---:|---|
| Breadth | 3.5/5 | many real pages/modules/routes; generic routing inflates destination count |
| Behavioral depth | 2/5 | several rich flows, but critical stock/delete/number/fine defects and unresolved branches |
| Visual/keyboard fidelity | 1.5/5 | useful shell/lookup/chrome; no screenshot comparison and many desktop shortcuts/grids absent |
| Data/schema fidelity | 2.5/5 | high table/column breadth and composite keys; schema drift and unsafe active-scope behavior |
| Accounting/inventory safety | 1.5/5 | balance assertion/transactions exist, but stock/reversal/numbering defects block use |
| Report/print fidelity | 1/5 | geometry extraction and HTML exist; data/formula/pagination/PDF comparison not certified |
| Security | 2/5 | Argon2, JWT cookies, parameterized SQL and RLS design; scope/RBAC/audit/session deployment gaps |
| Test evidence | 1.5/5 | 206 green unit assertions; no real posting, browser, tenant, concurrency, migration, load or visual proof |
| Operations/DR | 1.5/5 | coherent root Compose and backup script; no observability/readiness/offsite restore evidence |
| **Overall production readiness** | **~2/5 — blocked** | cannot safely run real business transactions until critical/high findings close |

The ratings are decision aids, not completion percentages. The six desktop-parity gates remain the authoritative acceptance model.

## 12. Immediate release decision

**No-go for production and no-go for live financial/inventory migration.**

A controlled demo with synthetic data is reasonable after clearly disabling fake PDF success and warning about non-certified workflows. Any real-shop pilot must wait for, at minimum:

1. bulk stock, reversal, numbering and formula policies corrected and integration-tested;
2. authoritative company/location/year scope and server-side per-form RBAC;
3. migration-owned RLS/audit schema plus automated tenant tests;
4. real PDF readiness and first desktop report comparisons;
5. structured logging/readiness/monitoring and tested backup restore;
6. browser E2E, concurrency, migration and reconciliation gates;
7. explicit exclusion or implementation of hardware/service workflows.

The next deliverable maps each desktop form/workflow/report/invariant to current web evidence and these gaps, then orders the remediation into production work packages.


## 2026-07-26 implementation status addendum

The original audit above remains the baseline snapshot. The first implementation waves have since
closed these specific foundation findings with executable evidence:

- H4/H5 schema deployment drift: five versioned migrations now replay to zero Prisma diff;
  `audit_log`, all 146 desktop tables, 168 Prisma models, RLS policies and role grants are
  migration-owned. Fresh install, four-to-five upgrade, compatible partial-session-table upgrade
  and incompatible-partial atomic rollback were exercised against isolated PostgreSQL 16.
- Tenant runtime safety: CI and `/ready` require a non-superuser/non-`BYPASSRLS` `app_user` and
  ENABLE+FORCE coverage for all 168 tenant tables. The rollback-only SQL probe verifies tenant A/B
  reads/writes, persistent session create/rotate/revoke, and append-only tenant-isolated audit
  behavior.
- C5/H1/H6 authoritative scope, form rights and sessions: all 252 routes have fail-closed policy
  metadata; current-location `USER_SET` View/Edit/Delete/Print is enforced at the API; company,
  location and year come from the persisted session; books must be active `BOOK_DATA`; password
  migration/reset, refresh rotation/replay revocation, logout invalidation and deployment tenant
  binding pass five real PostgreSQL-backed HTTP scenarios. Protected pages consume one `/me` scope
  context and configured-book selector instead of hard-coded scope defaults.
- H9 fake-PDF behavior: production routes no longer return content-free fake PDFs. Chromium launch
  is mandatory readiness, the API image uses Playwright 1.61.1, and renderer failure returns 503.
- W0 quality/deployment gaps: external package versions are exact, frozen install passes, lint runs
  real policy/AST plus 10 workspace type/build tasks, maintained-file format checks pass, and
  production runtime configuration fails closed.

Current engineering breadth is 87 frontend pages, 252 declared API routes, 168 Prisma models and 46
API test files (215 default API assertions plus 5 PostgreSQL-backed HTTP assertions; 240 assertions
in the default tested workspaces). These are not parity credit. Transactional findings C1-C4 and
H2/H3 remain open for the next implementation waves; C5, H1 and H6 are closed at G3/G4 only. No
unit has G5 desktop comparison or G6 production certification.
