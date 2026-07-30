# Auth & RBAC Engine

Reproduces the desktop login + per-user rights model on the web: authenticate against `LOGIN_MAST`,
carry rights in a JWT, enforce the three rights on every mutation, and filter the nav by access.

Source: `modules/auth/{auth.service,jwt,password}.ts`, `modules/rbac/policy.ts`, `apps/api/src/app.ts`.
Desktop: `AuthClass.cs`, `LOGIN_MAST`, `MS_USER`, `MS_LOGIN`. Requirements: Req 6 (all), 7 (company/year).

## 1. Login flow — Req 6.1/6.2

```mermaid
sequenceDiagram
  participant U as Browser
  participant A as Fastify /auth/login
  participant DB as LOGIN_MAST
  U->>A: { coCode, lcCode?, loginName, password }
  A->>DB: SELECT ... FROM LOGIN_MAST WHERE CO_CODE=? AND LOGIN_NAME=?
  A->>A: verify password (Argon2; plaintext⇒forcedReset)
  A->>U: set httpOnly cookies (access+refresh); { user, rights, forcedReset }
```

- Credentials checked against the company's `LOGIN_MAST` row. Invalid → 401, no session (Req 6.2).
- **Password migration:** desktop stored `LOGIN_PWD` plaintext. On first login the value is verified
  as plaintext, then the user is flagged `forcedReset` to set an Argon2 hash. New hashes are Argon2.
- Tokens are **httpOnly, sameSite=strict** cookies; `access` (short) + `refresh`. Rate-limited (10/min).

## 2. Session & rights

`requireAuth` verifies the `access` cookie and sets `req.session`:
```ts
interface Session { sub: string; tenantId: string; coCode: string; coYear?: string; rights: UserRights; }
```
`UserRights` mirrors the desktop flags: `USER_UPDATE` (create/update), `USER_DELETE`, `USER_PRINT`.

## 3. Company/Year selection — Req 7 (desktop `MS_OPNCOMP`)

- `GET /context/companies`, `GET /context/years` list what the user may open.
- `POST /context/select` validates the year exists (`YEAR_MAST`) then **re-issues** the access token
  carrying `coCode`+`coYear` — that becomes the active scope for all subsequent queries. Invalid year → 409.

## 4. Enforcement — Req 6.4/6.5/6.6

```ts
// modules/rbac/policy.ts
assertRight(session.rights, 'create' | 'delete' | 'print'); // throws ForbiddenError → HTTP 403
```
- **Every** create/update calls `assertRight(...,'create')`; delete → `'delete'`; report/print → `'print'`.
- Routes catch `ForbiddenError` → `403 { error:'forbidden', action }`.

## 5. Nav filtering — Req 6.7

```ts
filterNav(allNav, session.rights) // omit menus/forms the user can't access
```
The desktop hid menu items a user lacked rights to. The web computes the visible nav server-side
(`/me` + `lib/nav.ts`) so unauthorized screens never render.

## 6. Audit

An `onResponse` hook logs every authenticated mutation (loginName, coCode, method, path, status) to
the audit log — best-effort, never blocks the request (desktop kept `USER_DATA`/activity logs).

## 7. Parity criteria (DoD)

- Real `LOGIN_MAST` users authenticate (HANDOFF: live auth PASS on DHAKAN data).
- A user lacking `USER_UPDATE`/`USER_DELETE`/`USER_PRINT` is blocked from the matching action (403).
- The nav for a restricted user omits exactly the forms they can't access.
- Selecting a non-existent year is rejected (409).
