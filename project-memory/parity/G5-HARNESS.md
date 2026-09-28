# G5 desktop comparison harness

## The old entry point is gone, deliberately

Earlier versions of this document told you to run `web/apps/api/integration/g5-compare.mjs`. **That file was
deleted and must not be reinstated.** It carried six defects, each of which on its own made the comparison unable
to fail:

1. every date canonicalised to the empty string, so 64 date columns across 42 tables always matched
2. numbers rounded to 3 decimals before comparison
3. `NULL` treated as equal to blank
4. numeric agreement judged by column **sums**, so offsetting errors cancelled
5. text upper-cased before comparison
6. the table set taken as the **intersection** of both schemas, so a table the web never wrote was discarded
   rather than reported

A green result from it meant nothing. The replacement separates **extraction** from **comparison** so the differ
can be unit-tested without a SQL Server, and so each capture is retained as re-examinable evidence.

## The three steps

```
parity-extract-mssql.mjs   (Windows, desktop)  ->  bundles/desktop-<timestamp>.json
parity-extract-pg.mjs      (web, PostgreSQL)   ->  bundles/web-<timestamp>.json
parity-compare.mjs         (anywhere)          ->  g5/parity-diff-<timestamp>.json
```

Bundles live in `project-memory/parity/bundles/`, diffs in `project-memory/parity/g5/`. The comparison needs only
the two JSON files — no database — which is why it can run in CI and on a laptop.

### 1. Desktop capture (Windows, needs the real installation)

```bash
PARITY_MSSQL_HOST=desktop-sql.internal PARITY_MSSQL_PORT=1433 \
PARITY_MSSQL_USER=parity_reader PARITY_MSSQL_PASSWORD='<secret>' \
PARITY_MSSQL_DATABASE=Live24 \
PARITY_CASES='[{"caseId":"purc-035-00001","book":"035","vchNo":"00001"}]' \
node apps/api/integration/parity-extract-mssql.mjs
```

See `docs/PARITY-WINDOWS-PROCEDURE.md`. A capture carries the SQL Server `@@VERSION` banner; the gate requires
it, so a synthesised bundle cannot be promoted to evidence by renaming a file.

### 2. Web capture (needs the cases posted into PostgreSQL first)

```bash
DATABASE_URL=postgresql://... PARITY_TENANT=default PARITY_COMPANY=01 \
PARITY_CASES='[{"caseId":"purc-035-00001","book":"035","vchNo":"00001"}]' \
node apps/api/integration/parity-extract-pg.mjs
```

**The extractor reads rows that already exist**; it does not post anything. The cases must be entered through the
web application first, or the bundle describes whatever happens to be in the database. This is the step that made
the 2026-08-30 measurement stale: the retained web bundle predated a month of fixes, so 1,354 of its 3,787
differences had already been repaired without anyone knowing.

### 3. Compare

```bash
node apps/api/integration/parity-compare.mjs \
  ../project-memory/parity/bundles/desktop-latest.json \
  ../project-memory/parity/bundles/web-latest.json
```

Neither side's table list is filtered by the other's, so a table the web never wrote is **reported**, not
discarded — defect 6 above.

## Measuring progress

```bash
pnpm --filter @datacare/api build     # the runner imports the compiled ratchet module
pnpm parity:measure                   # compare the newest bundles and check the ratchet
pnpm parity:measure --reuse           # evaluate the newest existing diff, no re-comparison
pnpm parity:measure --record          # ...and record the result as the new ceiling
```

`parity:measure` prints the D1 numbers — cases matched, field differences, missing and extra rows, desktop-only
and web-only tables — and compares them against `project-memory/parity/PARITY-RATCHET.json`. It exits non-zero if
any tracked number got worse.

Every route to a cheaper number is itself treated as a regression: comparing fewer fields or tables, excluding
more columns, un-matching a case, or deleting a case. When the case set **expands** (the plan's Phase 1 grows it
from 66 towards ~300) the comparison is made over the cases the two runs share, because per-case averages move
with the composition of the set.

`--record` refuses to write a ceiling from a run that regressed. A ceiling that follows the last result in both
directions is not a ratchet.

## The two gates, and why they are separate

| Gate | Command | Asks |
| --- | --- | --- |
| `g5-desktop-comparison` | `pnpm g5:parity` | Is the web **at parity**? Requires a real SQL Server capture and every case matched. RED today. |
| `parity-ratchet` | `pnpm parity:measure` | Did any measured number **get worse**? Answerable today. |

Passing the ratchet is not parity and never certifies a release on its own. Keeping them apart is what stops the
achievable gate from being mistaken for the controlling one.

## Current state — 2026-08-30

```
cases matched  0 / 66
fields         3,787 differing of 23,574 compared (83.94% agree, 1,625 excluded)
rows           210 missing, 210 extra
tables         368 compared, 53 desktop-only, 105 web-only
```

Both bundles date from 2026-08-02, so these are a baseline rather than today's state: re-post the 66 cases and
re-extract the web side to refresh it. Analysis in `PARITY-GAP-ANALYSIS-2026-08-30.md`; the work that closes it
is `DESKTOP-PARITY-EXECUTION-PLAN-2026-08-30.md`.
