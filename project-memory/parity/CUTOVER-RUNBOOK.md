# SQL Server to PostgreSQL cutover runbook

## Tool and current evidence

Use `web/apps/api/integration/cutover.mjs`. The old `import_real.mjs` is retained only as a thin deprecated compatibility shim; it contains no credentials and delegates to `cutover.mjs`.

No real multi-year source database has been migrated with this tool in this environment yet. Unit tests cover dry-run report generation and an unreachable SQL Server, but they are not a substitute for a representative migration rehearsal.

## Required environment variables

All credentials come from environment variables; do not put secrets in source files, shell history, or reports.

- `CUTOVER_SOURCE_HOST`: SQL Server host.
- `CUTOVER_SOURCE_PORT`: SQL Server port; defaults to `1433`.
- `CUTOVER_SOURCE_USER`: read-only SQL Server login.
- `CUTOVER_SOURCE_PASSWORD`: SQL Server login password.
- `CUTOVER_SOURCE_DATABASE`: source database name.
- `DATABASE_URL`: target PostgreSQL runtime-role URL.
- `CUTOVER_TENANT_ID`: target tenant ID.

Optional variables:

- `CUTOVER_SOURCE_ENCRYPT`: defaults to `true`.
- `CUTOVER_SOURCE_TRUST_SERVER_CERTIFICATE`: defaults to `false`.
- `CUTOVER_CONNECT_TIMEOUT_MS`: defaults to `10000`.
- `CUTOVER_REQUEST_TIMEOUT_MS`: defaults to `240000`.
- `CUTOVER_TABLES`: comma-separated table list; otherwise the supported default list is used.
- `CUTOVER_YEAR_FROM` and `CUTOVER_YEAR_TO`: optional paired `CO_YEAR` remapping values.
- `CUTOVER_REPORT_PATH`: optional JSON report path.

## Dry-run first

From `web/apps/api/`, populate the environment from the approved secret source, then run:

```sh
node integration/cutover.mjs --dry-run --report=../../../project-memory/parity/cutover-dry-run.json
```

Dry-run connects read-only to the source, reads target metadata and target numeric sums, and performs no target delete or insert. Review every table before running a load. To rehearse selected tables:

```sh
node integration/cutover.mjs --dry-run --tables=CO_MAST,AC_MAST
```

If SQL Server is unavailable, the JSON report has `error.code: "SOURCE_UNREACHABLE"` and identifies the host/port, network, server availability, and login settings to verify. It does not include passwords.

## Load and resume

After approving the dry-run report:

```sh
node integration/cutover.mjs --report=../../../project-memory/parity/cutover-load.json
```

Each table is one PostgreSQL transaction. The tool deletes only that tenant's rows for the table and inserts the source snapshot. Re-running a completed table produces the same snapshot, so reruns are idempotent at table granularity. To resume at a table after correcting a failure:

```sh
node integration/cutover.mjs --resume-from=PR_DATA --report=../../../project-memory/parity/cutover-resume.json
```

`--resume-from` marks earlier configured tables as `resume-skipped`; it does not infer that they are valid. Preserve and review the earlier report before using it.

## Reading the JSON report

The report is machine-readable JSON on stdout and, when `--report` or `CUTOVER_REPORT_PATH` is set, in that file.

- Top-level `mode` is `dry-run` or `load`; `status` is `passed`, `partial`, or `failed`.
- `totals` contains table, failed-table, source-row, loaded-row, and skipped-row counts.
- Every `tables[]` entry contains `sourceRows`, `loadedRows`, `skippedRows`, status, and duration.
- `numericColumns` compares each common numeric column as `{ source, target, matches }`. In dry-run, target is the current target value; after load, it is the post-transaction target value.
- `failed` means the table transaction did not commit. `sum-mismatch` means the load committed but post-load numeric sums differ and requires investigation. Missing source/target tables and tables without common columns are explicitly reported.

Treat any top-level status other than `passed`, any failed table, any numeric `matches: false`, or unexplained skipped rows as a cutover blocker.

## Rollback story

A table load wraps tenant-scoped delete plus all inserts in one PostgreSQL transaction. An insert failure rolls back the whole table, retaining its pre-cutover target contents. Previously committed tables are not automatically rolled back when a later table fails.

For a full cutover rollback, take and verify a PostgreSQL backup before the load, stop application writes, and restore that backup according to the database recovery procedure. The cutover tool itself does not provide cross-table rollback. Use `--resume-from` only after the failed table's cause has been fixed and earlier committed tables have been reviewed.
