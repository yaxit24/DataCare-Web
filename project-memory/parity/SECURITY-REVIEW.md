# G6 Security Review

**Status: local review evidence; not a security or production certification.** Reviewed 2026-07-28. Verdicts mean: **PROVEN-BY-TEST** (an automated test exercises the claim), **PROVEN-BY-INSPECTION** (the cited implementation was inspected but no complete behavioral test proves the whole area), and **GAP** (a material control is absent or incomplete).

## 1. Authentication and session model — PROVEN-BY-TEST

- Access and refresh JWTs have distinct token types, issuer/audience validation, and 15-minute/7-day lifetimes (`web/apps/api/src/modules/auth/jwt.ts:1-73`; `web/apps/api/src/app.ts:118-130`).
- Refresh JTIs are SHA-256 hashed, compared with `timingSafeEqual`, rotated under `FOR UPDATE`, and replay revokes the whole session as `refresh-reuse` (`web/apps/api/src/modules/auth/session.ts:1-35`, `:145-203`). Logout/password changes and admin resets persist revocation (`session.ts:228-268`; `passwordAccount.ts:59-77`, `:105-117`).
- Cookies are `HttpOnly`, `SameSite=Strict`, path `/`, and use the deployment-selected `secure` flag (`web/apps/api/src/app.ts:123-130`). Production config forces secure cookies and rejects weak/missing signing secrets (`web/apps/api/src/modules/ops/runtimeConfig.ts:35-78`).
- Tests: `auth.session.test.ts:102-143` proves immediate logout invalidation and refresh replay revocation; `app.security.db.test.ts:318-368` proves those behaviors against PostgreSQL/HTTP; `app.runtime.test.ts:11-68` proves both production cookies contain `HttpOnly`, `SameSite=Strict`, `Secure`, and `Path=/`.

## 2. Authorization — PROVEN-BY-TEST

- Every declared route is classified at registration; missing/ambiguous policy prevents startup (`web/apps/api/src/app.ts:137-157`) and a missing request policy fails closed (`app.ts:319-321`).
- Form routes centrally call `authorizeForm` before handlers (`app.ts:340-364`). Non-admin users need a matching current-location `USER_SET` row; View gates read/create, and Edit/Delete/Print are independent (`web/apps/api/src/modules/rbac/authorization.ts:89-146`). `adminOnly` rejects non-admins even if their row is permissive (`authorization.ts:102-109`).
- Tests: `routePolicy.test.ts:28-43` asserts **exactly 362 unique routes** and no unmapped policy; `rbac.authorization.test.ts:34-101` proves missing-row fail-closed, explicit admin bootstrap, action rights, and admin-only rejection; `app.security.db.test.ts:167-265` proves the HTTP/database boundary and location-specific rights.

## 3. Tenant isolation and runtime role — PROVEN-BY-TEST

- Every tenant transaction sets `app.tenant_id` transaction-locally before work (`web/packages/db/src/tenant.ts:8-32`).
- The generated RLS policy file enables and forces RLS for all tenant tables (for example `web/packages/db/prisma/rls.sql:24-29`; 170 FORCE statements are present). Runtime readiness counts tenant tables and requires ENABLE+FORCE coverage equality (`web/apps/api/src/modules/ops/health.ts:73-105`).
- The runtime role is explicitly `NOSUPERUSER ... NOBYPASSRLS` (`web/packages/db/setup_roles.sql:23`).
- Tests: `health.test.ts:36-89` proves readiness rejects bypass/superuser/incomplete coverage; `opsInvariants.db.test.ts:34-73` reads real database invariants; `app.security.db.test.ts:167-265` proves tenant/scope enforcement through HTTP.
- Live port-55433 observation during this review: role `app_user`, `rolsuper=false`, `rolbypassrls=false`; **170 tenant tables / 170 ENABLE+FORCE protected**.

## 4. Audit append-only guarantees — PROVEN-BY-TEST

- Authenticated mutations write tenant-bound audit rows from the response hook, and failures increment a metric and emit a structured error (`web/apps/api/src/app.ts:168-232`; `web/apps/api/src/modules/ops/audit.ts:15-45`).
- The runtime role receives only SELECT/INSERT and is denied UPDATE/DELETE/TRUNCATE (`web/packages/db/setup_roles.sql:30-31`; immutable migration equivalent at `web/packages/db/prisma/migrations/20260715010000_runtime_schema_security/migration.sql:129-131`). Operational invariants derive `appendOnly` from those privileges (`web/apps/api/src/modules/ops/invariants.ts:43-75`).
- Tests: `audit.test.ts:17-55` proves tenant binding and observable write failure; `opsInvariants.db.test.ts:34-92` proves real append-only rights and an unhealthy negative case.
- Live port-55433 observation: audit privileges were SELECT=true, INSERT=true, UPDATE=false, DELETE=false, TRUNCATE=false.
- Boundary: audit is append-only to `app_user`, not to the PostgreSQL owner/superuser. Business writes complete before the `onResponse` audit; an audit failure is observable but does not roll back an already-completed request. That design limitation is explicit, not hidden.

## 5. Secret handling — PROVEN-BY-TEST

- `web/scripts/lint-workspace.mjs:5,56-64` now invokes the AST scanner in `web/scripts/secret-scanner.mjs:1-66` for production JS/TS source. It rejects plausible password/API-key/token/secret string assignments while allowing environment reads and explicit placeholders. Test fixtures/integration fixtures are excluded so test vectors do not masquerade as production secrets.
- `security.test.ts:31-49` proves positive detection plus environment/placeholder handling. A temporary `apps/api/src/__g6-secret-policy-probe.ts` containing a live-looking `apiKey` assignment was planted: lint exited 1 with `plausible secret literal assigned to apiKey ... at line 1`. The file was removed; the next scan passed **410 source files, 8 manifests, 0 policy violations**.
- A real fixed demo password and credential-bearing startup log were removed. Demo seeding is now opt-in and requires external `DEMO_PASSWORD` (`runtimeConfig.ts:35-78`; `server.ts:10-39`).
- Scope: this proves the scanner's defined source tree and patterns, not Git history (this workspace is not a Git repository), binary assets, dependencies, database contents, external secret stores, or exhaustive entropy-based secret discovery.

## 6. Raw SQL input handling — PROVEN-BY-INSPECTION

- Runtime values in inspected auth, tenant, posting, report, and CRUD SQL use PostgreSQL `$n` bindings (representative examples: `tenant.ts:16`, `session.ts:91-110`, `authorization.ts:121-136`, `audit.ts:24-34`).
- Dynamic identifiers use the canonical sanitizer/quoting boundary (`web/apps/api/src/modules/security/sql.ts:14-31`); reports call it before table interpolation (`reports.ts:124-132`). `security.test.ts:10-28` proves malicious identifier handling.
- Remaining interpolation observed is for internal constants or bounded numeric clauses (for example the audit limit is numerically clamped before interpolation). This inspection did not prove every future raw SQL call. There is no general static rule that parses all SQL templates and rejects unbound value interpolation; adding such a rule would require a broader SQL-aware migration, so this residual risk remains documented.

## 7. Rate limiting — GAP

- `@fastify/rate-limit` is registered with `global:false` (`web/apps/api/src/app.ts:133`). Only `POST /auth/login` has an explicit limit: 10 attempts per minute (`app.ts:395-398`). This is useful brute-force resistance for login.
- There is no test proving 429 behavior, no explicit refresh/password-reset limit, no general expensive-report or mutation limit, and the default in-process store is not a distributed multi-instance control. Production needs an approved per-origin/per-account policy, a shared or gateway enforcement layer, trusted-proxy configuration, and automated 429/recovery tests. This was not changed locally because arbitrary limits can block legitimate shop workflows and require deployment traffic policy.

## 8. Security headers — PROVEN-BY-INSPECTION (deployment GAP remains)

- Every response sets `X-Content-Type-Options: nosniff`, `X-Frame-Options: DENY`, `Referrer-Policy: no-referrer`, and `X-XSS-Protection: 0` (`web/apps/api/src/app.ts:162-167`). Cookie flags are covered separately above.
- The API itself does not set HSTS, Content-Security-Policy, Permissions-Policy, or a CORS policy. HSTS requires the real TLS hostname/proxy; CSP must be designed for the deployed web UI/assets. Before certification, provide the production origin and reverse-proxy/TLS configuration, define those policies, and verify headers end-to-end. No current automated header test covers the four always-set headers.

## Review conclusion

No area is marked certified. Authentication/session, authorization, tenant isolation, append-only runtime audit privileges, and source secret policy have strong test evidence. Raw SQL and currently emitted headers have inspection evidence. Rate limiting is incomplete, and production-origin header/TLS policy is external/deployment work. Independent penetration testing, dependency/SBOM review, live gateway configuration, and customer-site validation remain outside this local review.
