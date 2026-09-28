# G6 Local Load Profile

**Status: measured local evidence only; not production certification.** This profile was run on 2026-07-28 IST (`2026-07-27T21:50:42.948Z`) against the compiled Fastify API over loopback HTTP and PostgreSQL at `127.0.0.1:55433`.

## Repeatable command

From `web/`, obtain the database and ephemeral load-user credentials from the approved local secret source, then run:

```sh
export DATABASE_URL='postgresql://app_user:<runtime-password>@127.0.0.1:55433/datacare?schema=public'
export MIGRATE_DATABASE_URL='postgresql://postgres@127.0.0.1:55433/datacare?schema=public'
export LOAD_PROFILE_PASSWORD='<ephemeral-load-user-password>'
export LOAD_PROFILE_JWT_SECRET='<ephemeral-load-signing-key-at-least-32-characters>'
pnpm load:profile
```

The npm script builds `@datacare/db` and `@datacare/api`, then `scripts/load-profile.mjs` imports `apps/api/dist/app.js`, listens on an ephemeral loopback port, seeds only tenant `g6-load-profile`, authenticates over HTTP, and sends real requests through Fastify, Prisma, the `app_user` role, RLS, posting logic, audit writes, and PostgreSQL. It clears that isolated tenant before each run; migrations are not changed.

## Shop-like profile and rationale

After one unmeasured warm-up sale, three pools run at the same time:

| Operation class  | Endpoint/work                                                         | Requests | Concurrency | Rationale                                                                 |
| ---------------- | --------------------------------------------------------------------- | -------: | ----------: | ------------------------------------------------------------------------- |
| `voucher_create` | `POST /sales`, one configured loose-gold line, tax and ledger posting |       24 |           4 | Four operators/counters saving vouchers concurrently.                     |
| `voucher_read`   | `GET /sales/:vchNo?coBook=SAL`                                        |       60 |          12 | More frequent open/re-open activity from counters and back-office users.  |
| `report_render`  | `GET /reports/sales-register` with the seeded financial-year range    |       30 |           6 | Concurrent sales-register dataset rendering while counter work continues. |

The summarizer uses nearest-rank percentiles over end-to-end client-observed milliseconds. Its pure logic is tested in `web/apps/api/test/metrics.test.ts`.

## Measured result

Overall: **114 measured requests**, **0 errors**, **665.264 ms** measured wall time, and **171.360 requests/second** aggregate throughput for this short local run.

| Operation                    | Requests | Concurrency | Errors | p50 ms |  p95 ms |  p99 ms |
| ---------------------------- | -------: | ----------: | -----: | -----: | ------: | ------: |
| Voucher create               |       24 |           4 |      0 | 75.485 | 268.469 | 297.274 |
| Voucher read                 |       60 |          12 |      0 | 40.952 |  93.659 |  97.982 |
| Sales-register report render |       30 |           6 |      0 | 30.549 |  67.742 |  67.796 |

### Observed database connection behavior

The runner sampled `pg_stat_activity` for `usename='app_user'` every 10 ms while traffic ran (67 samples):

- Baseline after warm-up: **1 connection**.
- Peak observed: **17 connections**, of which at most **8 were active** in a sample.
- Immediately after measured traffic: **17 connections** remained pooled.
- The API `/ops/metrics` probe, which itself opens/uses a connection and counts all connections to this database, observed **18 total / 1 active**.

This is observed pool behavior, not a configured production pool limit or proof that 17 connections are appropriate for a deployed database.

## What this does and does not prove

It proves that this exact short profile completed through the compiled API and restricted port-55433 database with the measurements above and no HTTP errors. It does **not** establish an SLO or production capacity. No SLO was supplied or invented.

It does not model network latency, TLS/reverse-proxy overhead, multiple API instances, a production-sized dataset, long soak behavior, browser rendering, PDF/Chromium rendering, lock contention across a full shop day, failover, noisy neighbors, backup activity, or real customer traffic. The host is one laptop and the seeded dataset is small. A production-like environment, representative sanitized data volume, approved traffic model, and business-approved targets remain required before any performance certification.
