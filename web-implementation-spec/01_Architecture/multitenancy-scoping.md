# Multi-Tenancy & Scoping

The desktop scopes data by **Company / Location / Year / Book** and isolates years into separate
SQL Server databases. The web collapses that into **one Postgres database** with two layers of
isolation: an outer `tenant_id` (enforced by Row-Level Security) and the original composite key
(enforced by query scoping). This doc is the authoritative model every module must follow.

## 1. The scoping keys

| Key | Desktop meaning | Web representation |
|---|---|---|
| `CO_CODE` | Company (top-level), e.g. `01` | column on every table; part of scope |
| `LC_CODE` | Location/branch/counter | column on transactional tables |
| `CO_YEAR` | Financial year (**was a separate DB**) | **column** — year DBs collapse into this |
| `CO_BOOK` | Voucher book/series | column on transactional tables |
| `VCH_NO`, `SR_NO` | Voucher number, line serial | complete the row identity |

**Composite key (transactions):** `(CO_CODE, LC_CODE, CO_YEAR, CO_BOOK, VCH_NO, SR_NO)`.
**Masters key:** `(CO_CODE, …natural key…)` (most masters are company-scoped, not year-scoped).

## 2. Two isolation layers

### Layer 1 — `tenant_id` + Postgres RLS (hard isolation)
Every table carries `tenant_id`. The app connects as a **non-superuser** role (`app_user`) for which
RLS policies are active. Each transaction binds the tenant first; RLS then scopes **every** statement.

```ts
// packages/db/src/tenant.ts
await tx.$executeRawUnsafe("SELECT set_config('app.tenant_id', $1, true)", tenantId); // tx-local
```

```sql
-- packages/db/prisma/rls.sql (pattern, applied to all tables)
ALTER TABLE "AC_DATA" ENABLE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "AC_DATA"
  USING (tenant_id = current_setting('app.tenant_id', true));
```

This guarantees one company's data can never leak to another even if a query forgets a filter.
(Proven in `packages/db/test/rls_isolation.sql`.)

### Layer 2 — composite-key scoping (business correctness)
Within a tenant, business queries are filtered to the active Company/Location/Year/Book:

```ts
// packages/db/src/scope.ts
export function buildScopeWhere(scope: Scope): Record<string, string> {
  const where = { CO_CODE: scope.coCode };
  if (scope.lcCode !== undefined) where.LC_CODE = scope.lcCode;
  if (scope.coYear !== undefined) where.CO_YEAR = scope.coYear;
  if (scope.coBook !== undefined) where.CO_BOOK = scope.coBook; // book-scoped ops only
  return where;
}
```

The active scope rides in the JWT (`coCode`, `coYear`) set at `/context/select`, plus `lcCode`/`coBook`
chosen per operation. **Rule:** transactional reads/writes always apply both layers.

## 3. Why year-databases collapse to a column

The desktop opened `Next24` vs `Next25` by switching the connection string. Cross-year operations
(opening balances, comparatives) were awkward. In the web DB:
- A row's year is just `CO_YEAR`.
- "Open FY2024" = set `coYear='2024'` in the session; all scoped queries filter on it.
- Year-end carry-forward / opening balances become ordinary scoped writes (`TR_AC_OPBL`, `TR_ITM_OPBL`, `TR_TAG_OPBL`) rather than a DB migration.

> **Parity note.** The set of rows visible "in a year" must equal what the desktop's `NextNN` DB held
> for that year. Migration ETL stamps `CO_YEAR` from the source DB name so this holds.

## 4. Tenancy model decision

- **`tenant_id` default = `'default'`** for a single-business deployment (header `x-tenant-id` selects it). The desktop is single-business per install; the web keeps the door open for multi-business SaaS without reworking the schema.
- `tenant_id` is **outermost** and independent of `CO_CODE`: one tenant can still hold multiple companies (the desktop supported multiple `CO_CODE`s), each company multiple locations.

## 5. Concurrency & numbering under scope

Voucher numbers are per-scope sequential. Concurrency safety uses a Postgres **transaction advisory
lock** keyed by the full scope, held until commit:

```ts
// modules/vouchers/numbering.ts
await tx.$executeRawUnsafe('SELECT pg_advisory_xact_lock(hashtext($1))', scopeKey(s));
// then read+increment SRNO_MAST within the same tx
```

So composing numbering + posting + stock in one transaction keeps allocation unique even when two
users save in the same book simultaneously (Req 9.2/9.3).

## 6. Checklist for any new query/module

- [ ] Runs inside `withTenant` (RLS bound) for writes and scoped reads.
- [ ] Applies `buildScopeWhere` for the active CO/LC/YEAR(/BOOK).
- [ ] Never trusts a client-supplied `tenant_id` beyond the authenticated session.
- [ ] Voucher allocation uses `nextVoucherNoTx` inside the same tx as the posting.
