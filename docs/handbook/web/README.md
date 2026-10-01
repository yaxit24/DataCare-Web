# Web handbook — DataCare Web

How the web application is built, how a request flows through it and how to run it. The 31 API modules and the
shared screen components are described in [modules.md](modules.md); coding rules are in
[engineering-standards.md](engineering-standards.md) and the test strategy in [testing.md](testing.md).

## 1. Scope and status

- **Target.** A multi-tenant web replacement for DataCareNext that keeps the desktop's composite business keys and
  write sets while changing the stack (`project-memory/decisions/ADR-0001-stack-and-scope.md`).
- **Proven end to end** (audit of 1 October): fresh company, login, daily rate, sale create–reopen–edit–print, cash
  receipt and purchase, with balanced ledger, day book, stock, tax and outstanding; trial balance, Rojmel, cash book,
  GSTR-1/2/3B and HSN agree; 239 of 239 routes render
  ([document 11 §1](../../master-parity-plan-2026-09-29/11-audit-implementation-plan-2026-10-01.md)).
- **Contained** (refused on purpose until safe): `logical-restore`, `production-cutover-load`,
  `tag-weight-difference` (`web/packages/core/containment.mjs`).
- **Not accepted:** 0/198 menus, 0/83 packages, 0/34 cards. Per-menu status: [menu catalog](../menu-catalog.md).

## 2. Technology stack

| Concern | Version in the repository | Support status (1 October 2026) |
|---|---|---|
| Package manager, monorepo | pnpm 9.15.4, Turbo 2.10.0 (`web/package.json`) | Current |
| Node.js | `engines: >=20`; CI and `web/Dockerfile.web` use Node 20 | **Node 20 reached end of life on 30 April 2026.** Node 24 is LTS until April 2028 (G72, N86) |
| Web | Next.js 15.1.6, React 19.0.0 (`web/apps/web/package.json:16-18`) | **Inside the range of the December 2025 React Server Components advisory** (CVE-2025-55182 / CVE-2025-66478; fixed in Next.js 15.1.9 and React 19.0.1). 2026 security releases patch only Next.js 15.5 and 16 (G72, N86) |
| API | Fastify 5.8.5, `@fastify/cookie` 11.0.2, `@fastify/rate-limit` 10.3.0 | Current |
| Database access | Prisma 6.19.3 (`web/packages/db/package.json`) | Security fixes until 19 November 2026; N86 moves to Prisma 7 before then (D26, accepted) |
| Database | PostgreSQL 16 (`postgres:16-alpine`) | Supported; 18 is current |
| Language | TypeScript 5.9.3 (web app 5.7.2) | Current |
| Calculations | decimal.js 10.6.0 | Current |
| Auth and crypto | jose 5.10.0 (HS256 JWT), `@node-rs/argon2` 2.0.2 | Current |
| Tests | Vitest 2.1.9 (web 2.1.8), Playwright 1.61.1 | Current |
| PDF rendering | Playwright Chromium inside the API image (`mcr.microsoft.com/playwright:v1.61.1-noble`) | Current |

## 3. Architecture

```text
Browser
  └─ Next.js App Router pages ('use client') + Shell navigation
       └─ same-origin /api/* rewrite (API_ORIGIN fixed at build time)
            └─ Fastify API: cookies + JWT → session context → business scope → route policy and form rights
                 └─ domain module (31 modules) → @datacare/core pure calculations
                      └─ Prisma transaction: set app.tenant_id (transaction-local) → parameterised SQL
                           └─ PostgreSQL 16, non-owner app_user, ENABLE + FORCE row-level security
Documents and reports: module dataset → document chrome or extracted Crystal layout → HTML → Chromium → PDF
Integrations: barcode/QR, scale (WebSerial), camera, live rates, GST IRN, WhatsApp/SMS → provider adapters
```

Fastify is used directly rather than NestJS (`project-memory/decisions/ADR-0003-http-fastify.md`).

## 4. Repository layout

| Path | Contents |
|---|---|
| `web/apps/web/` | Next.js UI: `app/(app)/` authenticated pages (`txn/`, `masters/`, `reports/`, `utilities/`, `admin/`), `components/`, `lib/`, browser tests in `test/` |
| `web/apps/api/` | Fastify API: `web/apps/api/src/app.ts` (auth, context, master and lookup routes), `web/apps/api/src/routes/txn.ts` (most business routes), `src/modules/` (31 modules), `test/`, `integration/` (parity and cutover tools), `form-specs/` (extracted desktop layouts), report specs |
| `web/packages/core/` | Pure calculation and state-transition kernel; no I/O |
| `web/packages/db/` | Prisma schema (174 models), 30+ migrations, `web/packages/db/prisma/rls.sql`, `web/packages/db/setup_roles.sql`, `web/packages/db/src/tenant.ts` (`withTenant`) |
| `web/packages/types/` | Shared Zod types (`TenantScope`, `UserRights`) |
| `web/packages/reports/`, `web/packages/parity/` | Report package marker; key-based row differ |
| `web/scripts/` | Gate scripts (`check-*.mjs`), parity measurement, release certification, test-environment wrapper |
| `.github/workflows/` | `ci.yml` (static gates, quality, G5) and `release-certification.yml` |

## 5. Request lifecycle

1. **Browser.** `web/apps/web/lib/api.ts` sends `/api` requests with cookies, attaches the captured session-context
   ticket, refreshes once on 401 and throws `ApiError` with the structured body otherwise.
2. **Authentication.** Login issues a 15-minute access JWT and a 7-day refresh JWT in HttpOnly, SameSite=Strict
   cookies (Secure in production). Claims carry tenant, company, location, year, rights, session ID and context
   epoch; refresh rotation detects reuse (`web/apps/api/src/modules/auth/jwt.ts`, `web/apps/api/src/modules/auth/session.ts`).
3. **Context freshness.** `x-session-context-id` and `x-session-context-epoch` must match the stored session or the
   API answers 409 `context-stale`; the page guard drops responses from an older context.
4. **Business scope.** The server session owns company, location and year; a body or query cannot replace them; a
   requested book must be an active `BOOK_DATA` row (`web/apps/api/src/modules/auth/businessScope.ts`).
5. **Route policy.** Every route is classified `public`, `system` or `form` at startup; an unmapped route stops the
   server. Form routes check the user's view, edit, delete or print right
   (`web/apps/api/src/modules/rbac/routePolicy.ts`).
6. **Body handling.** Today handlers cast the raw body; no mutation route has a JSON Schema yet, so malformed input
   can reach a writer and return 500 (G25, slice N50).
7. **Writer.** The module opens `withTenant`, resolves settings, book and accounts on the server, allocates visible and
   hidden numbers, checks the fiscal period and lock date, and writes the complete ledger, stock, tax and outstanding
   effects in one transaction (`web/packages/db/src/tenant.ts`, `web/apps/api/src/modules/posting/posting.ts`).
8. **Errors.** Route wrappers map known errors to 4xx by name pattern (`web/apps/api/src/routes/txn.ts:755-864`);
   unknown errors become 500. A typed taxonomy replaces this (N88).
9. **Audit.** Mutations are logged after the response in a separate transaction; a logging failure does not fail
   the business change (G35, N55).

## 6. Data layer

- **Tenancy.** Every business table has `tenant_id`; `web/packages/db/prisma/rls.sql` finds every table with that
  column, enables and forces RLS with a `tenant_isolation` policy, and fails if one is missed. `withTenant` sets
  `app.tenant_id` for the transaction only.
- **Roles.** The runtime `app_user` is not a superuser and cannot bypass RLS; it has CRUD on tables and only SELECT
  and INSERT on `audit_log` (`web/packages/db/setup_roles.sql`). Migrations run as the owner.
- **Tenant selection.** Outside production a trusted `x-tenant-id` header is accepted; in production the deployment's
  `APP_TENANT_ID` is used (`web/apps/api/src/app.ts:241-246`, `web/apps/api/src/server.ts:86-95`). One deployment
  therefore serves one tenant today (Phase 2, G75).
- **Raw SQL.** Values are bind parameters; dynamic identifiers come from allow-lists and are validated
  (`web/apps/api/src/modules/security/sql.ts`). A few bounded numeric interpolations remain, for example the audit
  list's `LIMIT` (`web/apps/api/src/modules/ops/audit.ts:37-48`); N88 adds a lint rule that allow-lists them.
- **Desktop column defaults.** `web/apps/api/src/modules/posting/desktopColumnDefaults.ts` records measured defaults
  for 1,894 columns over 49 voucher tables. Apply them on create only; an imported row's NULL must stay NULL.
- **Adding a migration:** create a new migration (never edit history) → add its checksum to
  `web/apps/api/src/modules/ops/migrationManifest.ts` → `prisma migrate deploy` as owner (never `db push`) → re-apply
  `rls.sql` and `setup_roles.sql` → run `pnpm fresh:provision` to replay from empty and compare schema and RLS
  ([`web/DEPLOY.md`](../../../web/DEPLOY.md)).

## 7. Calculation kernel (`web/packages/core`)

| Area | Computes |
|---|---|
| `money`, `calc`, `finePolicy` | Decimal rounding including half-even, fine weight, labour, metal amount, line and bill totals, GST split |
| `saleAmount`, `settlement`, `wholesaleLine`, `eBillCalc` | Sale amount basis and rate, money and metal settlement, wholesale issue/receive lines, e-bill tax and TCS |
| `tagSplitLine`, `tagCancelLine` | Parent, child and stone effects with conservation checks |
| `orderLabour*`, `designCalc`, `salesOrderDesign` | Order labour, design parent and component calculations |
| `saleReturn*` | Saved-return reduction, projections and save guards |
| `sessionLedgerMode` | Ledger-mode (A/B/C) diagnostics |
| `containment.mjs` | Registry of contained operations |

The kernel uses decimal.js, but some modules still round locally with `Math.round` or floats; kernel conformance is
ratcheted (G22, N48).

## 8. Posting, books and numbering

- `postVoucherTx` asserts a balanced `AC_DATA`, checks the period and writes in one transaction; edit deletes and
  rebuilds the voucher's owned write set while keeping its hidden number and user and time stamps; delete removes it
  and appends `DELETE_DATA` (`web/apps/api/src/modules/posting/posting.ts`).
- Books and accounts come from `BOOK_DETL` slots through `web/apps/api/src/modules/shared/bookPolicy.ts` and
  `web/apps/api/src/modules/shared/postingAccounts.ts`; a missing or duplicate slot is an error, never a guess. Many
  older writers still fall back to literal accounts (G40, N59).
- Visible numbers: full-scope advisory lock and `MAX(VCH_NO)+1`; hidden numbers have their own lock
  (`web/apps/api/src/modules/vouchers/numbering.ts`).
- Lock date and fiscal year are checked inside the transaction (`web/apps/api/src/modules/vouchers/lifecycle.ts`).
- Still missing on most vouchers: version tokens for edit and delete (D17, N51) and idempotency keys for financial
  creates (D18, N52).

## 9. Frontend

- 128 pages; most are `'use client'`. The authenticated layout loads `/me`, provides the business scope, renders
  `Shell` (13 navigation groups filtered by the user's form rights, `web/apps/web/lib/nav.ts`) and mounts Enter
  navigation and the desktop F-keys.
- Shared controls (`web/apps/web/components/`): `BookSelect`, `LookupPicker` (F1), `GridKeyboard`, `KeyboardNav`,
  `FormKeys`, `SubDetailGrid`, `VoucherChrome`, `VoucherList` and family forms (`PaymentForm`, `KarigarForm`,
  `WholesaleVoucherForm`, `EBillEntry`, `TagSplitForm`, `TagCancelForm`, `StockInoutForm`). Details:
  [modules.md](modules.md#frontend).
- Page pattern: session scope → book → lookups → editable draft → load (GET) or create (POST) → update (PUT) →
  delete with confirmation → print → reload. Several screens still lose fields on an unchanged save (G45, G46, N63).

## 10. Reports and documents

- 85 report slugs with per-report rights (`web/apps/api/src/modules/reports/reportAuthorization.ts`); one dynamic page
  renders most of them (`web/apps/web/app/(app)/reports/[report]/page.tsx`).
- 254 extracted Crystal layouts; 28 have binding contracts. An unbound or altered template is refused, never filled
  with plausible data (`web/apps/api/src/modules/reports/reportBindingContract.ts`).
- Generic A4 documents (company, party, tax) come from `web/apps/api/src/modules/documents/docChrome.ts`.
- Server CSV and XLSX exports neutralise formula-like cells (`web/apps/api/src/modules/reports/reportCsv.ts:30-41`,
  `web/apps/api/src/modules/reports/xlsx.ts`). The generic report page's client-side CSV download (`downloadCsv`,
  `web/apps/web/lib/api.ts:204-212`) only quotes values, so a cell beginning with `=` reaches the spreadsheet as a
  formula (G81, N57).
- PDFs are rendered by Chromium; the renderer accepts caller HTML today, which is an S1 risk (G32, N54).

## 11. Integrations and devices

Code39 and QR codes, the desktop scale frame protocol, live rates, WhatsApp Cloud and SMS adapters, GSP e-invoice
and readiness reporting live in `web/apps/api/src/modules/integrations/` and `web/apps/api/src/modules/einvoice/`. The
browser offers WebSerial scale capture, camera capture and a manual weight fallback. No physical device or live
provider has been accepted; unconfigured messaging can report a simulated send (G33, N54).

## 12. Security model

- **In place:** HS256 JWT in strict HttpOnly cookies; persisted, rotated refresh sessions; forced RLS with a
  non-owner role; server-owned business scope; fail-closed route policy and per-form rights; `nosniff`, frame deny
  and no-referrer headers; production configuration checks; login rate limit (`web/apps/api/SECURITY.md`).
- **Open:** account lockout and origin checks (G34), request schemas (G25), versions and idempotency (G27, G29),
  atomic audit (G35), PDF renderer isolation (G32), truthful messaging (G33), deployment hardening (G64), tracked
  credentials and secret scanning (G65), runtime advisories (G72).
- The repository intentionally tracks legacy credentials (`SECURITY-NOTICE.md`): never copy their values.

## 13. Running locally

```bash
cd web
pnpm install --frozen-lockfile
pnpm --filter @datacare/db db:generate
pnpm build

# Isolated database (port 55433, migrations, non-owner role, forced RLS) for the API database tests:
node scripts/parity-test-env.mjs -- pnpm --filter @datacare/api test

# Zero-mock browser suite (API_ORIGIN is fixed when the web app is built):
API_ORIGIN=http://127.0.0.1:4410 pnpm build
node scripts/parity-test-env.mjs -- node apps/web/test/parity.real-stack.mjs
```

For a manual stack: start PostgreSQL (`docker compose up -d postgres`), apply migrations, `rls.sql` and
`setup_roles.sql` as described in `web/DEPLOY.md`, start the API with `PORT`, `DATABASE_URL`, `JWT_SECRET`,
`APP_TENANT_ID` and, for demo data, `SEED_DEMO` and `DEMO_PASSWORD`, then start the web app with `API_ORIGIN`
pointing at the API. The isolated wrapper uses fixed ports (55433, 4410, 4411), so parallel worktrees collide
(G24, N49). Environment variable names are listed in `web/.env.example`; never copy values from tracked `.env`
files.

## 14. Deployment

The documented target is a single host: TLS edge → web only, private API and database, owner-only migrations,
scheduled encrypted off-host backups and tested restore (`web/DEPLOY.md`). The current Compose file publishes all
three ports, backups are local and unencrypted, and there is no current production database-restore or
upgrade/rollback runbook (G64, N80). Phase 2
replaces this with managed services ([document 14](../../master-parity-plan-2026-09-29/14-phase2-saas-plan.md)).

## 15. Desktop concepts and their web equivalents

| Desktop | Web |
|---|---|
| MDI ribbon and child windows | `Shell` with `NAV` groups and one page per screen |
| Company/location/year selection (`MS_OPNCOMP`) | `/select`, server session context with an epoch |
| `CurBookHelp` book chooser | `BookSelect` over `/context/books`, filtered by `MAIN_BOOK` |
| F1 "DataCare Help" lookup | `LookupPicker` |
| Shell F-keys and Ctrl chords | `FormKeys` and global form keys |
| Grids and `*_IDTL` pop-ups | Page grids with `GridKeyboard` and `SubDetailGrid` |
| Message-box validation | Structured 4xx responses shown next to the field |
| Print Menu (Original/Duplicate/Triplicate) | Document endpoints with copy selection; Crystal layouts through the report engine |
| `CO_SET` / `CO_SET_NEW` globals | Typed `/settings` API and server-side policy loaders |
| `Ac_Ledr`, `Ac_Stock`, `Ac_Rojmel`, `Ac_Tax` | `posting`, `shared/rojmel`, stock and tax policies inside one transaction |
| One SQL Server database per year | One PostgreSQL schema with `tenant_id`, company, location, year and book keys, and forced RLS |

## 16. Known debt and where it is planned

| Hotspot | Measurement | Plan |
|---|---|---|
| Route monolith | `web/apps/api/src/routes/txn.ts`: 8,400 lines, 586 of the 608 routes (the rest are in `web/apps/api/src/app.ts`), no body schemas | G25/N50, G79/N88, SP03 |
| Local rounding | 124 local rounding helpers against a ceiling of 108 | G22, N48 |
| Transaction budgets | About 525 `withTenant` calls, 6 with explicit timeouts; one sales-return create exceeded 5 s | G30, N53 |
| Large writers | `rateCut.ts` 2,981, `purchase.ts` 2,875, `sales.ts` 2,825, `salesOrder.ts` 2,357 lines | X05, X06, N59, N63 |
| Large pages | `web/apps/web/app/(app)/reports/[report]/page.tsx` 1,867 and `web/apps/web/app/(app)/txn/sales/page.tsx` 1,485 lines | G37/N57, N88 |
| Report bindings | 28 of 254 Crystal layouts bound | G59, G60, N73–N75 |
| Migration | Cutover covers 42 of 145 desktop tables | G63, N78, N79 |
