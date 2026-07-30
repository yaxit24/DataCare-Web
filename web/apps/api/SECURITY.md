# Security Posture — `@datacare/api`

_Phase 15 hardening pass. This document reflects what the API enforces today and what is
deliberately deferred to deployment/ops. File references point at the source of truth so the
doc can be re-verified rather than trusted._

---

## 1. Authentication model

**JWT carried in HttpOnly cookies.** Login (`POST /auth/login`) verifies credentials, then issues
two signed tokens and sets them as cookies (`src/app.ts`, `src/modules/auth/jwt.ts`):

| Token   | Cookie    | TTL   | Claims                                                                               |
| ------- | --------- | ----- | ------------------------------------------------------------------------------------ |
| Access  | `access`  | `15m` | `sub` (LOGIN_NAME), `tenantId`, `coCode`, `lcCode`/`coYear`, `rights`, `typ: access` |
| Refresh | `refresh` | `7d`  | `sub`, `tenantId`, `typ: refresh`                                                    |

- **Algorithm:** HS256 via [`jose`], signed with a single symmetric secret (`JWT_SECRET`).
- **Cookie flags** (`cookieOpts` in `src/app.ts`):
  - `httpOnly: true` — not readable by JavaScript (XSS token-theft mitigation).
  - `sameSite: 'strict'` — not sent on cross-site requests (CSRF mitigation).
  - `path: '/'`.
  - `secure: true` when the validated runtime configuration is production; development keeps it off
    only for the local HTTP harness.
- **Enforcement:** the `requireAuth` preHandler reads the `access` cookie, verifies it, and attaches
  the decoded session to `req.session`; missing token → `401 unauthenticated`, bad token →
  `401 invalid-token`. Every non-public route registers `{ preHandler: requireAuth }`.
- **Logout** (`POST /auth/logout`) clears both cookies.

### Tenant isolation (RLS)

Every data access runs through `withTenant()` (`packages/db/src/tenant.ts`), which opens an
interactive transaction and binds the tenant **transaction-locally**:

```sql
SELECT set_config('app.tenant_id', $1, true)
```

PostgreSQL Row-Level Security then scopes **every** statement in that transaction to the tenant.
The `tenantId` originates from the verified JWT session (not from raw client input on data paths).
The API connects as a dedicated **non-superuser** `app_user`; `/ready` returns 503 unless the role is
neither superuser nor `BYPASSRLS` and every public `tenant_id` table has both ENABLE and FORCE RLS.
Any thrown data-layer error rolls back the whole transaction (`atomic()` / `withTenant()`).

---

## 2. Authorization (RBAC)

Defined in `src/modules/rbac/policy.ts`, driven by the desktop user-right flags carried in the JWT
`rights` claim:

| Action            | Required right |
| ----------------- | -------------- |
| `create`,`update` | `userUpdate`   |
| `delete`          | `userDelete`   |
| `print`           | `userPrint`    |
| `read`            | always allowed |

- `assertRight(rights, action)` throws `ForbiddenError`; routes translate that to `403 forbidden`
  with the attempted `action` (e.g. master create/delete/import, `/secure/delete-demo`).
- `filterNav()` prunes the navigation tree to forms the user may access (dynamic menu), keeping a
  parent only if it or a descendant survives.

---

## 3. HTTP security headers (added this pass)

`@fastify/helmet` is **not** a dependency of this package, and the hardening brief forbids adding
one. Instead an `onSend` hook in `src/app.ts` sets a minimal safe header set on **every** response:

| Header                   | Value         | Purpose                                           |
| ------------------------ | ------------- | ------------------------------------------------- |
| `X-Content-Type-Options` | `nosniff`     | Block MIME-type sniffing.                         |
| `X-Frame-Options`        | `DENY`        | Disallow framing (clickjacking).                  |
| `Referrer-Policy`        | `no-referrer` | Never leak request URLs via the `Referer` header. |
| `X-XSS-Protection`       | `0`           | Disable the legacy (buggy) browser XSS auditor.   |

**Content-Security-Policy is intentionally omitted:** this service returns API JSON only (no HTML or
scripts it must protect), so a CSP adds no value while risking breakage for JSON clients. If helmet
is adopted later, register it with `contentSecurityPolicy: false` for the same reason.

---

## 4. Rate limiting

`@fastify/rate-limit` **is installed and registered** in `src/app.ts`:

```ts
await app.register(rateLimit, { global: false });
```

- `global: false` → limits are **opt-in per route**.
- Applied today: `POST /auth/login` → `{ max: 10, timeWindow: '1 minute' }` (brute-force throttle).
- All other routes are currently unthrottled — see the checklist (§6) for adding a sensible global
  default and limits on other expensive/mutating endpoints.

---

## 5. Secrets via environment

No credentials live in the repo. Integrations fall back to in-memory **Fakes** when env vars are
absent (feature stays wired, no external calls, nothing to leak):

| Concern             | Env vars                                                                                       | Source                                                  |
| ------------------- | ---------------------------------------------------------------------------------------------- | ------------------------------------------------------- |
| JWT signing         | `JWT_SECRET`; production requires a non-default value of at least 32 characters                | `modules/ops/runtimeConfig.ts`, `src/server.ts`         |
| Database/runtime    | `DATABASE_URL`, `PORT`, `NODE_ENV`, `APP_TENANT_ID`, `DEMO_TENANT`, `SEED_DEMO`, `APP_VERSION` | `modules/ops/runtimeConfig.ts`, `modules/ops/health.ts` |
| WhatsApp Cloud API  | `WA_PHONE_ID`, `WA_TOKEN`, `WA_API_VERSION` (opt.)                                             | `modules/integrations/messaging.ts` (`senderFromEnv`)   |
| HTTP SMS gateway    | `SMS_URL_TEMPLATE`, `SMS_KEY`, `SMS_SENDER` (opt.)                                             | `modules/integrations/messaging.ts` (`senderFromEnv`)   |
| GST e-invoice (GSP) | `GSP_ASPID`, `GSP_PASSWORD`, `GSP_GSTIN`, `GSP_USER`, `GSP_EINV_PWD`, `GSP_SANDBOX`            | `modules/einvoice/einvoice.ts` (`irnTransportFromEnv`)  |

Production startup fails before opening a port if the database URL or signing secret is missing,
the secret is short/default, the port is invalid, or demo seeding is enabled.

Secrets are read only at use-time and passed to the external transport; they are never logged or
persisted by the API.

---

## 6. SQL-injection posture

The data layer uses Prisma's `$queryRawUnsafe` / `$executeRawUnsafe`. The `Unsafe` suffix names the
Prisma API (raw SQL string vs. tagged template) — it does **not** describe how it is used here. The
usage is parameterized and identifier-safe:

- **Values are always bound parameters** (`$1, $2, …`), passed as separate arguments, never
  string-concatenated. Examples: `loadUser` in `src/app.ts`, the builders in
  `modules/masters/master.service.ts` (`buildInsert`, `buildKeyWhere`, `buildDuplicateCheck`,
  `buildDeleteGuards`), and the e-invoice sale lookups in `modules/einvoice/einvoice.ts`.
- **Identifiers are not free-form user input.** Master table/column names come from a static
  allowlist (`MASTERS` registry / `MasterConfig`); an unknown `:name` returns `404` before any SQL
  runs. Every identifier also passes through `q()`, which strips all but `[A-Za-z0-9_]` and quotes
  it — a hard sanitizer for table/column names.
- **Numeric interpolation is clamped.** `listMaster`'s `LIMIT ${n}` uses
  `Math.min(Number(limit) || 100, 500)`, so it cannot carry a payload.
- **Defense in depth:** even if a query were malformed, RLS (§1) keeps it inside the caller's tenant
  (given a non-superuser DB role).

---

## 7. Remaining hardening checklist (deploy / ops)

Verified foundations and remaining deployment/process controls:

- [ ] **HTTPS/TLS at the edge** — terminate TLS (reverse proxy / load balancer), redirect HTTP→HTTPS,
      and enable HSTS. Production cookies are already `Secure`; the edge must provide HTTPS.
- [x] **Runtime secret guard** — production rejects missing, short, known-default JWT secrets and
      rejects demo seeding before opening a port.
- [ ] **Secret rotation** — store all secrets (`JWT_SECRET`, `WA_*`, `SMS_*`, `GSP_*`, DB creds) in a
      managed secrets store with scheduled rotation; consider asymmetric signing keys.
- [ ] **Global + per-route rate limits** — add a sane global default and throttle other
      mutating/expensive endpoints (imports, reports, backup), not just login.
- [x] **Database audit persistence** — `audit_log` is migration-owned and FORCE-RLS protected;
      post-response write failures emit structured operational errors rather than disappearing.
- [ ] **Tamper-evident audit retention** — export/retain audit events and alert on persistence
      failures or suspicious mutation patterns.
- [ ] **Backups & DR** — schedule encrypted DB backups, test restores, and document RPO/RTO.
- [x] **DB role hardening** — parameterized bootstrap creates a non-superuser/non-`BYPASSRLS`
      runtime role; CI and `/ready` verify ENABLE+FORCE RLS on every tenant table.
- [ ] **CORS** — `@fastify/cors` is not installed; if browsers from other origins must call the API,
      add it with an explicit origin allowlist (do not use `*` with credentials).
- [x] **Exact dependency versions** — external manifest dependencies are pinned and frozen-lockfile
      installation plus manifest policy lint run in CI.
- [ ] **Dependency and secret scanning** — enable SCA (for example Dependabot) and repository secret
      scanning in CI.
- [ ] **Penetration test** — independent pen-test and threat model before go-live; re-test after
      material changes.
- [ ] **Security logging/monitoring** — centralize logs, alert on auth failures, RLS errors, and
      rate-limit triggers.

[`jose`]: https://github.com/panva/jose
