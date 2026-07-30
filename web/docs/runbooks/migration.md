# Migration & Cutover Runbook (Task 33)

Repeatable, per-customer SQL Server (desktop DataCareNext) → PostgreSQL (cloud SaaS) migration with
parity sign-off and rollback. Each customer = one tenant (`tenant_id`).

## 0. Pre-flight (T-7 to T-1 days)

- Confirm the customer's desktop DB backups (`.mdf`/`.bak`) and the active CO_CODE/LC_CODE/CO_YEAR set.
- Provision the tenant: pick a `tenant_id`; ensure infra is up (`deploy/docker-compose.prod.yml`) with `.env` from `deploy/.env.example` (real `JWT_SECRET`, `APP_DB_PASSWORD`, `POSTGRES_PASSWORD`).
- Verify the app DB is migrated and hardened: Prisma schema applied, `rls.sql` applied, `app_user` created (`packages/db/setup_roles.sql`), `deploy/sql/perf-indexes.sql` applied.
- Freeze window agreed with the customer (desktop read-only during cutover).

## 1. Restore the customer golden-master (staging)

- Bring up a SQL Server container; restore the customer's `.bak`/`.mdf`.
- This is also the **parity golden-master** (Task 30 Layer-2).

## 2. ETL — SQL Server → Postgres (staging tenant)

- Run `unified/tools/etl_mssql_to_pg.py` (FLOAT→NUMERIC, money/weight precision coercion already unit-tested).
- Load into the app's Postgres under the customer's `tenant_id` (every row carries it; RLS enforced).
- Re-run schema migrate + `rls.sql` + perf-indexes if loading into a fresh DB.

## 3. Parity sign-off (HARD GATE — no go-live without it)

- **Layer 1 — deterministic:** `pnpm --filter @datacare/api test` (golden vectors 13/13) — must be green.
- **Layer 2 — cross-DB row parity:** diff persisted rows/computed columns (mssql golden-master vs Postgres) with `@datacare/parity` per table; **differing-field report must be empty** (within FLOAT-vs-NUMERIC precision).
- **Confirm the 2 parity knobs** against the golden-master and set if needed:
  - `INOUT_TYPE` characters for karigar issue/receipt (code default `'I'`/`'R'`).
  - `MsIntYearDays` for Dhrn interest (code default `360`) — read from `CO_SET`.
- **Spot-check totals:** trial balance (ΣDr=ΣCr), a known sales invoice total, a Dhrn outstanding, a karigar metal balance — must match the desktop figure.
- Record sign-off in `project-memory/parity/` (per-customer entry).

## 4. Go / No-Go checklist

- [ ] Parity Layer 1 + Layer 2 green; 2 knobs confirmed.
- [ ] Auth works: a desktop user logs in (plaintext `LOGIN_PWD` → Argon2 on first login, forced reset).
- [ ] RBAC rights match the desktop user's USER_UPDATE/DELETE/PRINT.
- [ ] Company/Year selection lists the customer's CO/YEAR.
- [ ] A test sale + reverse posts balanced and reverses cleanly in the tenant.
- [ ] Backups scheduled (`deploy/backup.sh` cron); restore tested once.
- [ ] Rollback owner + window confirmed.

## 5. Cutover (during the freeze window)

1. Final desktop backup; final incremental ETL of any rows since step 2.
2. Re-run the parity diff on the delta; confirm empty.
3. Flip the customer to the SaaS (DNS / app URL); desktop goes read-only/retired.
4. Smoke test in production tenant: login → open company/year → create + delete a test voucher → run sales register + trial balance → delete the test voucher.

## 6. Rollback (if any gate fails)

- Do NOT flip; keep the customer on the desktop.
- If already flipped and a blocker appears within the window: revert the app URL/DNS to the desktop path; the desktop DB is unchanged (we only ever READ it). No data loss because the SaaS tenant is additive and the desktop remained the source of truth until sign-off.
- File the differing-field report; fix; re-run from step 2.

## 7. Post-go-live (T+1 to T+7)

- Monitor `/ready` + error logs (Sentry DSN if configured).
- Daily backup verification.
- Confirm first real GST return / e-invoice (once GSP creds are provisioned — currently the documented external blocker).

## Tooling referenced (all built & verified)

- `unified/tools/etl_mssql_to_pg.py` (+ unit tests) — coercion ETL.
- `packages/db` Prisma schema + `rls.sql` + `setup_roles.sql`.
- `deploy/sql/perf-indexes.sql` (applied + verified live), `deploy/docker-compose.prod.yml`, `deploy/backup.sh`, `deploy/.env.example`.
- `apps/api/src/modules/parity/golden.ts` + `project-memory/parity/parity-report.md`.
- API domain modules (auth, masters, sales, purchase, finance, accounting, dhrn, karigar, gst, einvoice, reports) — 83 unit tests + 19 live integration scripts, web gate green.

## Known follow-ups (beyond the 34-task plan)

- **HTTP route exposure** for the transaction modules (services exist + are tested; REST endpoints + RBAC guards to be wired, following the `/masters/:name` pattern).
- **Next.js frontend** (`apps/web` is a scaffold) — the end-user UI.
- External blockers needing customer/vendor credentials: GSP e-invoice submission, WhatsApp/SMS providers, Playwright Chromium for server-side PDF.
