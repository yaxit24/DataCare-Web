# Security & Quality Review (Task 31)

_Updated: 2026-06-28. Scope: backend API + data layer. (No UI yet → a11y deferred.)_

## 1. SQL injection — VERIFIED SAFE

- **27 raw-SQL call sites** audited (`$queryRawUnsafe`/`$executeRawUnsafe`). **All VALUES are parameterized** (`$1..$n`); no user value is string-concatenated into SQL.
- **Identifiers** (table/column names) are internal constants, quoted via the canonical sanitizer `quoteIdent()` (`apps/api/src/modules/security/sql.ts`): strips everything except `[A-Za-z0-9_]` then double-quotes. `assertSafeIdent()` (strict, rejects) is available for any input-derived name.
- Hardened `reports.ts` to route its table name through `quoteIdent` (was a safe internal constant; now defense-in-depth).
- **Tests:** 5 Tier-1 (`security.test.ts`) prove injection payloads are neutralized (`AC_DATA"; DROP TABLE x;--` → `"AC_DATADROPTABLEx"`).
- Type-agnostic key matching uses `::text` casts with params — never concatenation.

## 2. Tenant isolation (RLS) — VERIFIED LIVE

- Every table carries `tenant_id`; per-table RLS policies filter on `current_setting('app.tenant_id')`. The app connects as a **non-superuser** (`app_user`) so RLS is enforced (superusers bypass RLS).
- `withTenant()` sets `app.tenant_id` transaction-locally; all reads/writes are scoped.
- **Tests:** `security.live.mjs` 3/3 — tenant A's row is invisible to tenant B (isolation holds), visible to A. (Re-confirms Task 8/9 `rls_isolation.sql`.)

## 3. Authentication & authorization

- Passwords: Argon2 (`@node-rs/argon2`); desktop plaintext `LOGIN_PWD` is migrated on first login then force-reset.
- Sessions: JWT (jose HS256) — httpOnly cookie + refresh; login rate-limited (10/min).
- **RBAC:** `assertRight()` guards mutating routes (USER_UPDATE/DELETE/PRINT); dynamic nav filtered by rights. Proven in `http.live.mjs` (clerk delete → 403).
- **Secrets:** none hardcoded — JWT secret injected via `buildApp({secret})`, DB creds via `DATABASE_URL` env. (grep: no inline secrets.)

## 4. Network-exposed endpoints

- The Fastify app requires auth (cookie/JWT) for non-public routes; the RBAC guard runs before mutations. **Note:** the transaction modules are not yet exposed as HTTP routes — when they are, each route MUST be behind auth + `assertRight` (carry the `/masters/:name` pattern).

## 5. Performance sanity (recommendations)

Add indexes (migration) for the hot read paths:

- `AC_DATA (tenant_id, CO_CODE, AC_CODE, VCH_DATE)` — ledger / trial balance / day-book.
- `SL_DATA (tenant_id, CO_CODE, VCH_DATE)` and `PR_DATA (tenant_id, CO_CODE, VCH_DATE)` — registers / GST.
- `TAG_STOCK (tenant_id, CO_CODE, LC_CODE, TAG_NO)` — stock lookups / double-issue guard.
- `SRNO_MAST (tenant_id, CO_CODE, LC_CODE)` — voucher numbering (advisory-locked).
  NUMERIC money/weight columns avoid float drift (decimal.js in calc; NUMERIC in DB).

## 6. Deferred / open

- **a11y (axe):** deferred — no UI built yet.
- **Cross-DB parity knobs:** `INOUT_TYPE`, `MsIntYearDays` (see parity-report.md).
- **Load/perf testing:** right-sized; not load-tested (single-tenant scale assumed per ADR-0002).
