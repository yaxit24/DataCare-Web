# WP-02A company backup/restore implementation evidence

**Date:** 2026-08-29  
**Plan:** `EXACT-END-TO-END-PARITY-PLAN-2026-08-29.md`  
**Work package slice:** WP-02A — P0-01 logical company backup/restore repair  
**Status:** implemented and validated in the current working tree; independent final review passed; no commit created  
**Claim boundary:** this evidence closes the **P0-01 engineering defect and its focused exit criteria**. It does **not** close P0-02 through P0-04, all of WP-02, overall desktop parity, production DR/RPO/RTO, cutover, security certification, or production readiness.

## 1. Defect replaced

The previous implementation in `web/apps/api/src/modules/ops/backup.ts` was unsafe:

- a manual 53-table allowlist omitted most of the live schema;
- `LIMIT 100000` silently truncated large tables;
- every binary value became the literal string `"[binary]"`;
- restore deleted all tenant-visible rows in each table rather than one company;
- row failures were caught and ignored;
- `ON CONFLICT DO NOTHING` no-ops were counted as restored;
- verification reused the incomplete allowlist and omitted technical identities.

The live PostgreSQL 16 schema used for this work contains:

| Classification                            |                    Count | Restore treatment                                                            |
| ----------------------------------------- | -----------------------: | ---------------------------------------------------------------------------- |
| Public base tables                        |                      174 | Every table appears in the schema manifest                                   |
| Company-scoped (`tenant_id` + `CO_CODE`)  |                      160 | Included in company backup and replace restore                               |
| Tenant-shared (`tenant_id`, no `CO_CODE`) |                       13 | Explicitly excluded; never deleted or inserted                               |
| Global/system                             | 1 (`_prisma_migrations`) | Explicitly excluded; never deleted or inserted                               |
| Tables with primary keys                  |                      174 | Key metadata frozen in the manifest                                          |
| Current foreign keys                      |                        0 | Future FK metadata/order and preflight are implemented and separately tested |
| Current identity columns                  |                        0 | Identity ownership/override/advancement is implemented from catalog metadata |
| Live bytea columns                        |                        6 | Encoded losslessly as tagged base64                                          |

## 2. Versioned document and schema contract

The new format is:

- kind: `datacare.company-backup`;
- version: `2`;
- explicit source `tenantId` and `companyCode`;
- explicit database target setting;
- one manifest entry for every public ordinary/partitioned base table;
- table data only for entries classified `company`.

`backupManifest.ts` performs an authoritative `pg_class` census and reconciles the runtime-visible column count for every table. A visibility mismatch fails rather than silently omitting a table. The frozen structural manifest includes:

- ordered columns, PostgreSQL formatted type, UDT, collation, nullability, default, generated/identity flags;
- owned sequence name, type, start/min/max/increment/cycle/cache;
- primary-key columns and complete PostgreSQL constraint definitions;
- referenced schema/table dependencies;
- index definitions;
- ENABLE/FORCE RLS state and policy command/roles/expressions;
- user trigger definition and enabled/disabled/replica mode.

The schema fingerprint is SHA-256 over stable canonical serialization of this complete structure. Restore compares both the fingerprint and the complete live manifest before any company delete.

Deep runtime validation rejects malformed nested columns, sequences, constraints, indexes, policies, triggers, dependencies, duplicated table names, invalid scope classification, missing table data, wrong columns, wrong tenant/company row values, invalid totals, and invalid checksums as `CompanyBackupValidationError`; malformed members cannot escape as raw `TypeError`.

## 3. Lossless row encoding and integrity

Backup reads precision-sensitive values as PostgreSQL text under `SET LOCAL TIME ZONE 'UTC'`, avoiding JavaScript `Date` and JSON-number conversion.

| PostgreSQL value            | v2 representation                                                |
| --------------------------- | ---------------------------------------------------------------- |
| `bytea`                     | `{ $dcType: "bytea", value: <base64> }`                          |
| `bigint`                    | decimal string tag                                               |
| `numeric`/`decimal`/`money` | exact PostgreSQL text tag, including supported non-finite values |
| `double precision`/`real`   | exact PostgreSQL text tag                                        |
| date/time/timestamp         | exact PostgreSQL text tag; microseconds retained                 |
| `json`/`jsonb`              | exact PostgreSQL text tag; no JS numeric coercion                |
| NULL                        | JSON `null`                                                      |

Canonical integrity rules:

1. stable object-key ordering;
2. canonical serialization of every encoded row;
3. sorted row canonical strings so query order cannot alter the digest;
4. per-table SHA-256 over all rows;
5. document SHA-256 over source identity, complete manifest, totals, table metadata, and rows.

Checksums detect corruption; they are not represented as signatures or authentication.

## 4. Backup behavior

`backupCompany` now:

- requires authenticated tenant and company values;
- runs through the non-bypass `app_user` RLS role in one repeatable-read transaction;
- sets a canonical UTC session timezone;
- dynamically loads and fingerprints all 174 tables;
- exports every row from all 160 company tables with explicit tenant and `CO_CODE` predicates;
- applies no row limit;
- preserves all columns and technical keys;
- seals and self-validates the document before returning it.

Physical database backup remains the full-tenant/full-database recovery mechanism.

## 5. Restore behavior

`restoreCompany` accepts an explicit authenticated target object; it never infers authorization from the uploaded document.

Before live deletes it requires:

- exact kind/version and complete document shape;
- valid per-table and document SHA-256;
- source tenant equal to authenticated tenant;
- source company equal to authenticated company;
- replace mode;
- exact live structural manifest/fingerprint;
- syntactically and semantically valid tagged cells;
- exact source scope values on every row;
- supported non-cycling positive owned sequences;
- no user triggers on included tables;
- database type/check/unique/FK preflight through temporary copies.

Concurrency and relational preflight:

1. A transaction advisory lock serializes restores for the authenticated tenant/company.
2. Every included table and every referenced public FK parent is locked in deterministic order with `SHARE ROW EXCLUSIVE`.
3. All company tables are copied structurally into `pg_temp`.
4. Excluded public FK parents are mirrored into `pg_temp` through the active RLS scope.
5. Public FK definitions are rewritten to temporary parents.
6. Candidate rows are inserted parent-first into temporary tables; type, width, NOT NULL, CHECK, PK/UNIQUE/EXCLUDE, internal-company FK, and external tenant-shared FK failures occur before live deletes.
7. Unsupported cross-schema FKs or dependency cycles fail closed.

Live replacement then runs in one serializable `withTenant` transaction:

- delete child-first and only where both authenticated `tenant_id` and `CO_CODE` match;
- insert parent-first with complete typed rows;
- no savepoints, swallowed errors, conflict suppression, or false success counts;
- re-read every restored table through RLS before commit;
- recompute exact row counts and SHA-256 from persisted database values;
- roll back if database coercion, trigger-like side effects, row count, or checksum differs;
- return measured per-table deleted/inserted counts and recomputed checksums.

## 6. Global sequence safety

Forced RLS prevents `app_user` from reading another tenant's maximum technical ID, while broad sequence `UPDATE` would permit unsafe arbitrary `setval` calls. Migration:

`packages/db/prisma/migrations/20260829010000_company_restore_sequence_guard/migration.sql`

adds `public.datacare_advance_owned_sequence(regclass,name)` with these constraints:

- `SECURITY DEFINER` with fixed `search_path = pg_catalog, public`;
- PUBLIC execution revoked;
- only `app_user` receives execute permission;
- target must be a public company-scoped table;
- column must own exactly one public serial/identity sequence;
- non-positive increments are rejected by the helper; cycling sequences are rejected before restore;
- the table is locked before the RLS-hidden global maximum is read;
- the helper only advances and never moves backward;
- `ALTER SEQUENCE ... RESTART` is used instead of non-transactional `setval`;
- overflow fails and rolls back.

The runtime role retains only sequence `USAGE, SELECT`; the database test proves it lacks direct sequence `UPDATE`. The migration is pinned in `migrationManifest.ts` with SHA-256:

`84afef22c62860d9227f6643e537aa5bd393ac93374f69a3b45d23374e609512`

`DEPLOY.md` now requires `prisma migrate deploy`; `prisma db push` is explicitly prohibited because it cannot install required raw-SQL security helpers. The runbook consistently requires the actual `/ready` role/RLS/database/renderer gate.

## 7. P0-01 exit-evidence mapping

| Plan requirement                  | Evidence produced                                                                                                                   |
| --------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------- |
| Schema-derived versioned manifest | v2 manifest classifies all 174 live tables; 160 included, 13 tenant-shared excluded, 1 system excluded                              |
| Complete table coverage           | Every public table is reconciled against `pg_class`; every company table has a data entry                                           |
| No silent truncation              | Real PostgreSQL test exported 100,002 `DESIGN_MAST` rows                                                                            |
| Binary preservation               | `TAG_IMAGE_BLOB.IMAGE_BYTES` round-tripped bytes `00 01 7f 80 fe ff 42` exactly                                                     |
| Explicit company key              | Service target is `{ tenantId, companyCode }`; document and every row must match                                                    |
| Version/checksum validation       | Kind/version, schema fingerprint, table SHA-256, totals, and document SHA-256 validated before mutation                             |
| Company 02 isolation              | Same-tenant company 02 complete table checksums unchanged                                                                           |
| Other-tenant isolation            | Tenant B/company 01 complete table checksums unchanged                                                                              |
| Excluded-table isolation          | Dynamic before/after digest covers all 13 tenant-shared tables and `_prisma_migrations`                                             |
| Count/key/hash reconciliation     | Exact per-table delete/insert counts; technical `row_id`; persisted SHA-256 recomputed before commit                                |
| Binary/key/business round trip    | Bytea, bigint row IDs, numeric(18,2), float, date, six-digit timestamp, strings, and company master rows restored exactly           |
| Corrupt document rollback         | Tampered checksum rejected before mutation                                                                                          |
| Invalid database value            | Validly resealed numeric overflow rejected in preflight with target unchanged                                                       |
| Database coercion                 | Validly sealed `1.230` normalizes to `1.23`; in-transaction SHA mismatch aborts and rolls back                                      |
| Conflict rollback                 | Cross-company PK collision occurs after live deletes and rolls the complete replace transaction back                                |
| FK preflight/order                | Isolated forced-RLS tables prove internal company FK rewrite/order and external tenant-shared parent validation before live delete  |
| Sequence safety                   | Explicit other-tenant ID above sequence state is invisible to target RLS; guarded helper advances next ID above the true global max |
| Wrong scope/schema                | Wrong authenticated tenant/company and self-consistent non-live schema both reject before company mutation                          |
| No false restored count           | Returned counts equal actual affected rows; checksums are re-read measurements, not copied upload values                            |

## 8. Real PostgreSQL test environment

- Docker container: `datacare-test-55433`;
- PostgreSQL: 16;
- host binding: `127.0.0.1:55433` only;
- runtime connection: documented `app_user` URL from `docs/HANDOFF.md`;
- fixture/migration connection: documented local PostgreSQL owner URL;
- test runtime confirmed the database was reachable and automatically enabled DB integrity/security flags.

The main Compose PostgreSQL on port 5433 was not used for this evidence.

## 9. Automated test evidence

### Final database run

Command scope:

```text
pnpm --filter @datacare/api test -- \
  test/backupRestore.db.test.ts test/opsInvariants.db.test.ts
```

with the documented 55433 runtime and migration URLs.

Result:

- 2 files passed;
- 15/15 tests passed;
- `backupRestore.db.test.ts`: 13/13;
- `opsInvariants.db.test.ts`: 2/2;
- measured test time: 39.91 seconds; total Vitest duration 41.57 seconds.

The 13 focused cases cover:

1. complete 174/160/13/1 schema classification and v2 sealing;
2. exact PostgreSQL JSON text without JS numeric coercion;
3. least-privilege sequence helper and tenant-shared rejection;
4. 100,002-row no-cap export;
5. exact binary/technical/business/microsecond round trip, complete other-company/other-tenant/all-excluded-table isolation, measured counts/checksums, and hidden-global-max sequence advancement;
6. checksum tamper rejection before deletion;
7. numeric overflow preflight with unchanged target;
8. persisted-value SHA mismatch rollback;
9. PK conflict rollback after delete phase;
10. malformed top-level and nested manifest rejection without `TypeError`;
11. wrong authenticated tenant/company rejection;
12. self-consistent schema mismatch rejection;
13. real internal-company and external tenant-shared FK preflight under forced RLS, with zero fixture-table residue afterward.

Operational invariants prove:

- 18 expected/applied migrations, no missing/unexpected/checksum/incomplete rows;
- every tenant table has ENABLE+FORCE RLS;
- `app_user` audit permissions remain append-only;
- health verdict is green.

### Containment regression

| Scope                                                   | Result                                                     |
| ------------------------------------------------------- | ---------------------------------------------------------- |
| Shared core containment                                 | 1 file, 4/4 passed                                         |
| API route and cutover containment                       | 2 files, 7/7 passed                                        |
| Web containment                                         | 1 file, 5/5 passed                                         |
| Direct built restore-drill smoke without `DATABASE_URL` | Exit 1 with `PARITY_CONTAINMENT`; no database-config error |

The HTTP restore route remains after authentication and admin RBAC but before service/Prisma access.

## 10. Type, build, migration, format, and bootstrap evidence

| Validation                                              | Result                                                     |
| ------------------------------------------------------- | ---------------------------------------------------------- |
| DB package source typecheck                             | Passed                                                     |
| API source typecheck                                    | Passed                                                     |
| Full API test/integration TypeScript check              | Passed                                                     |
| DB package build                                        | Passed                                                     |
| API production build                                    | Passed                                                     |
| Prisma schema validate                                  | Passed                                                     |
| Prisma migrate status                                   | 18 migrations; database schema up to date                  |
| `setup_roles.sql` rollback-only parse/rerun             | Passed through all grants/default grants, then rolled back |
| Scoped Prettier check                                   | Passed                                                     |
| Scoped `git diff --check`                               | Passed                                                     |
| LSP diagnostics for `backup.ts` and `backupManifest.ts` | None                                                       |

No dependency was added and no commit was created.

## 11. Independent review history

The first independent audit returned `NEEDS_CHANGES` and identified real gaps: timestamp/JSON precision, uploaded rather than measured restore checksums, incomplete structural fingerprinting, concurrency, identity sequences, malformed documents, catalog visibility, and the dormant drill.

The implementation was hardened with PostgreSQL-text codecs, in-transaction persisted SHA-256 verification, expanded catalog metadata, full table locks, identity/serial ownership, deep validation, authoritative census, and a same-scope v2 drill path.

Subsequent audits found and drove closure of:

- migration-manifest drift;
- invalid bootstrap grant placement;
- FK preflight coverage;
- trigger enabled-state fingerprinting;
- nested manifest shape validation;
- legacy MD5 verification;
- least-privilege global sequence advancement;
- the stale `db push` deployment path;
- contradictory `/ready` runbook text.

The final independent certification result was:

```text
FINAL_VERDICT: PASS
```

## 12. Containment decision

The P0-01 **engineering** exit evidence is green, but logical restore remains fail-closed in the shared WP-01 policy. Enabling a destructive HTTP/CLI operation is a separate operator release action and was not implicitly authorized by implementation work.

The updated operator message accurately states that v2 passed WP-02A engineering verification and names the remaining release controls:

1. deploy the pinned migration chain with `prisma migrate deploy`;
2. obtain a green production-equivalent `/ready` probe;
3. authorize and run the controlled same-scope post-deploy drill;
4. make an explicit reviewed containment-policy change.

Until then, use the verified physical database recovery procedure. There is no environment override.

## 13. Files in this work-package slice

Primary implementation and tests:

- `web/apps/api/src/modules/ops/backupManifest.ts` — new;
- `web/apps/api/src/modules/ops/backup.ts` — complete rewrite;
- `web/apps/api/src/modules/ops/restoreVerification.ts`;
- `web/apps/api/test/backupRestore.db.test.ts` — new;
- `web/apps/api/src/routes/txn.ts`;
- `web/packages/db/src/tenant.ts`;
- `web/packages/db/prisma/migrations/20260829010000_company_restore_sequence_guard/migration.sql` — new;
- `web/packages/db/setup_roles.sql`;
- `web/apps/api/src/modules/ops/migrationManifest.ts`;
- `web/scripts/restore-drill.mjs`;
- `web/DEPLOY.md`;
- `web/packages/core/containment.mjs` — message updated; guard retained.

Evidence artifact:

- `project-memory/parity/wp-02/WP-02A-BACKUP-RESTORE-EVIDENCE-2026-08-29.md`.

## 14. Final bounded conclusion

WP-02A replaces the known unsafe logical backup/restore implementation and satisfies the focused P0-01 exit evidence against real PostgreSQL with independent final review `PASS`.

Overall exact end-to-end parity remains **not certified and not production-ready**. P0-02 through P0-08, the remaining work packages, production-equivalent DR/RPO/RTO, authorization, migration rehearsals, accounting reconciliation, devices/integrations, security certification, pilot, and cutover remain open under the finalized parity plan.
