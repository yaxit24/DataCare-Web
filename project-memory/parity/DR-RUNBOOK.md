# Logical restore drill runbook

## Scope

This drill exercises the application-level, company-scoped JSON backup and restore path against the local PostgreSQL instance at `127.0.0.1:55433`. It does not exercise `pg_dump`, infrastructure provisioning, a remote backup store, or a production-sized database.

## Command

From `web/`, set the two database URLs from the approved secret source and run:

```sh
export DATABASE_URL='postgresql://app_user:<runtime-password>@127.0.0.1:55433/datacare?schema=public'
export MIGRATE_DATABASE_URL='postgresql://postgres@127.0.0.1:55433/datacare?schema=public'
pnpm restore-drill
```

The command builds `@datacare/db` and `@datacare/api`, seeds tenant `restore-drill-source`, backs up company `01`, restores it into tenant `restore-drill-scratch`, and compares normalized row counts and MD5 checksums. The JSON evidence is written to `project-memory/parity/restore-drill-result.json`.

## Measured run

The successful run completed at `2026-07-27T20:58:37.852Z` against database `datacare` on `127.0.0.1:55433`.

- Backup: 5 rows; 280.823 ms.
- Restore: 5 rows restored across 5 non-empty tables; 53 configured tables cleared; 373.368 ms.
- Verification: 52 company-owned tables checked; 5 source rows and 5 restored rows; 52 of 52 table checksum comparisons matched; 0 mismatches; 477.574 ms.
- End-to-end wall-clock time: 1292.916 ms.
- Recovery-point age when verification completed: 856 ms.
- Snapshot data-loss rows: 0.
- Final command status: `RESTORE_DRILL_OK`.

## Demonstrated RPO and RTO

For this one local, five-row logical company snapshot, the measured RPO was 0 snapshot rows lost with a recovery point 856 ms old at completion. The measured end-to-end RTO was 1292.916 ms, including seed, backup, restore, and verification.

These are measurements of this run only. They are not targets, production certification, or evidence for a full physical database, remote storage, disaster infrastructure, or production data volume.
