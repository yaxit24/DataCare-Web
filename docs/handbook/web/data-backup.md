# Data Backup

## Milestone state

Company → Data Backup is a **CONTAINED/PARTIAL engineering milestone**. The operator-facing Backup path is implemented. This page does not establish desktop acceptance, disaster-recovery certification, or a production restore capability.

## Desktop authority

The desktop menu dispatches `UT_BKP` from `MDI_FORM.cs:7471-7480`. The visible form has the `Backup Data` header, a path field, Select, a progress bar, and Backup (`UT_BKP.cs:630-918`). Restore is hidden at line 859. `Dattach` is hidden in the ordinary operator path and is only exposed for a configured SQL Server data path (`:899-901`, `:1099-1102`). Select opens the folder browser (`:925-936`). Load reads `USER_SET` rights (`:942-965`), while Cancel and Exit are handled at `:1099-1135`.

Backup requires `FRM_PRINT`, refuses a blank path with `Please Select Path and Try`, writes `Next<YY>[_<type>]_ddMMyy_HH.BAK`, replaces an existing same-hour file, backs up the company database and `NextMain`, then reports `Backup Process Complete.` (`UT_BKP.cs:1198-1251`). The timer only animates progress (`:1275-1285`). The operator narrative and screenshots are summarized in `project-memory/video-research/_kb/KB_master.md:225-253`.

## Web milestone behavior

The `/backup` page shows `Backup Data`, a read-only Backup Path field, Select, an accessible indeterminate progress indicator, Backup, and Cancel. It has no Restore or Dattach control.

Select records only an in-memory acknowledgment that the browser Save dialog will choose the destination. The browser never sends or stores a path. Cancel and navigation clear that acknowledgment. Backup before Select performs no request and shows the exact message `Please Select Path and Try`. During a selected backup the page prevents duplicate dispatch, keeps progress visible through generation and browser handoff, uses the server filename, and shows `Backup Process Complete.` only after download initiation succeeds. A failed request shows its error and never shows success.

The authenticated `GET /backup` route keeps its current admin policy for this milestone. Exact delegated Data Backup `FRM_PRINT` authorization remains the G225 handoff because active work owns `routePolicy.ts` and `formCatalog.ts`.

## v2 archive content and scope

The download remains the current JSON company-backup v2 document. It contains an integrity manifest, schema fingerprint, per-table row counts and SHA-256 checksums, losslessly encoded rows, totals, and a document checksum. The current live schema classifies 175 tables:

- **160 company-scoped tables included.** A table is included only when it has both `tenant_id` and `CO_CODE`. Every row read is filtered by the authenticated tenant and selected company. No location or fiscal-year filter is added, so every location and year belonging to that selected company is included.
- **14 tenant-shared tables excluded:** `APP_USER_DATA`, `BOOK_IDTL`, `HDD_MAST`, `AuthSession`, `MENU_DATA`, `MessageAttemptLog`, `STATE_MAST`, `TILE_DATA`, `USER_MAST`, `WEIGHT_MAST`, `COUNTRY_MAST`, `CompanyBackupRun`, `DataRepairRun`, and `audit_log`.
- **One system table excluded:** `_prisma_migrations`.

No tenant-shared USER_MAST, APP_USER_DATA, or MENU_DATA content is added. No new credential source or credential-export envelope is added. The inherited v2 table rule does classify company-scoped `LOGIN_MAST` as included, including its existing columns; credential treatment therefore remains an explicit part of the D-BKP-3 allowlist/reconciliation decision rather than being silently changed in milestone 1.

Database tests verify that selected-company rows from multiple locations and years are present, same-tenant other-company and other-tenant sentinels are absent, and repeated snapshots have stable normalized schema and table checksums. The existing 100,001-row database case remains the large-row ceiling evidence and is not duplicated.

## Filename and same-hour adaptation

The response suggests `Next<YY>[_<type>]_ddMMyy_HH.json`. `YY` comes from the authenticated session fiscal year. The optional sanitized type comes from persisted `CO_MAST.CO_TYPE`; blank or ambiguous type omits the segment. Date and hour use the API process's configured local business clock, matching the desktop's `DateAndTime.Now` semantics while the v2 archive timestamp itself remains UTC. Tenant, user, company code, request input, and server paths are not included.

Two snapshots generated in the same hour receive the same suggested filename, matching the desktop replacement intent. The browser and operating system control the physical save, overwrite prompt, and duplicate-name behavior. The page cannot force the desktop `Kill`/replace semantics. File System Access physical-save confirmation remains open when that API is unavailable.

## Audit and restore boundary

After the v2 document is generated and before response handoff, `recordCompanyBackup` inserts an immutable `company_backup_run` row with tenant, company, checksum, document version, generation time, table/row counts, and operator. A replay of the identical checksum does not create a duplicate row. This proves generation and response admission, not completion of the browser's physical disk write.

`POST /backup/restore` remains behind the `logical-restore` containment and answers 503 after authentication/authorization. The milestone does not edit `web/packages/core/containment.mjs`, add a UI restore path, execute shell commands, start child processes, persist registry/path data, or accept server paths.

## Open work

- **D-BKP-3 / G64 / N80:** approve a source-reviewed, export-only NextMain-equivalent tenant configuration allowlist and credential handling. Do not infer tenant-shared ownership.
- **X31 / G64 / N80:** import an actual browser artifact into an isolated scratch target through an approved offline procedure, prove zero unexplained differences, and keep web restore contained.
- **G225:** hand off the exact non-admin Data Backup `FRM_PRINT` route policy after the shared policy owners finish their work.
- **Browser/desktop runtime:** confirm physical save and overwrite behavior, and run the frozen matrix against the original Windows desktop. Desktop-match coverage remains 0%.
- **Scale and recovery:** populate every included table in a representative full-Lite fixture, complete production-sized/timed recovery, encrypted off-site retention, RPO/RTO, upgrade, rollback, and outage evidence under N80/G64/X31/P12-05.
