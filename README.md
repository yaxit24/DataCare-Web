# DataCareNext — web application

Web replacement for the DataCareNext desktop ERP (jewellery / gold trade): Windows Forms + Crystal Reports +
SQL Server, re-implemented as Next.js + Fastify + PostgreSQL. The technology changes; the behaviour is not
supposed to.

## Layout

```
web/                        the application (pnpm workspace)
  apps/api                  Fastify API, 371 routes
  apps/web                  Next.js UI, 101 pages
  packages/db               Prisma schema, 170 tables, 15 migrations, forced RLS
  docs/                     procedures, including the parity harness
web-implementation-spec/    per-table and per-form specification
```

The decompiled desktop source, the installer and the Crystal `.rpt` files are **not** in this repository. See
`.gitignore` for what is excluded and why.

## Gates

| Command | Meaning |
|---|---|
| `pnpm lint` | workspace policy, 491 files |
| `pnpm build` | 7 packages |
| `pnpm settings:parity` | all 128 configuration keys are typed and reachable |
| `pnpm schema:readiness` | every table the desktop's initialiser declares exists |
| `pnpm g5:parity` | **the desktop comparison — currently red** |
| `node scripts/report-baselines.mjs` | 254 report layouts unchanged |

Run from `web/`. Tests: `cd apps/api && npx vitest run` (907 tests, 119 files).

## The one thing that is not yet verified

Nothing has ever been compared against the running desktop application. Every arithmetic claim is verified
against the **decompiled source** — a strong form of evidence, but not the same thing.

`pnpm g5:parity` is red until that comparison exists, and it refuses anything that did not come from a live SQL
Server. To turn it green:

- **`web/docs/WINDOWS-AGENT-PROMPT.md`** — paste into an agent on the Windows box with the desktop install
- **`web/docs/PARITY-WINDOWS-PROCEDURE.md`** — the procedure itself

Extraction is separate from comparison, so the Windows step is a read-only extract and the differ is unit
tested without needing SQL Server.

## Also honestly open

- **Hardware** — scale, scanner, webcam, printer: implemented to their interfaces, never exercised against a
  device.
- **WhatsApp / SMS / GSP** — no credentials, so no live send has ever succeeded.
- **Legacy data migration** — needs a real, sanitised customer database to rehearse against.
- **UAE variants** — `TR_PR_SL_UAE`, `TR_SALE_RTN_UAE` formally waived by the owner.

Crystal pixel parity is **not** claimed anywhere. The 254 layout baselines detect regressions in this
application's own renderer; they have never been compared to Crystal output.
