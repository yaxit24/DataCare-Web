# Agent 18 — Company → Data Backup   (Lite package L5)

**Type:** BUILD — scope DECIDED 2 Nov (owner-delegated): Backup only, exactly like the desktop; **no restore, containment untouched**  
**Suggested wave:** 3  
**Prompt generated against:** `origin/main` @ `3fd1adc3` (1–2 Nov 2026). Re-fetch and re-read the catalog row before you start; if `main` moved, trust `main`.

> Read `00-GENERIC.md` first. This file is the menu-specific part.

## Mission

Make Company → Data Backup the desktop `UT_BKP` screen **as an operator sees it**: pick where to save, press Backup, get "Backup Process Complete." The desktop never shows Restore to the operator; the web does not either.

## Identity and hand-offs

- **SLUG** `data-backup`  **BRANCH** `feat/lite-data-backup`  **worktree** `~/dc-wt/data-backup`  **feature module** `dataBackup`
- Isolated Compose project: `PARITY_TEST_PROJECT=dc-data-backup` (ports come from the stack slot you take, see 00-GENERIC §2.1).

## Catalog facts (copied from `docs/handbook/menu-catalog.jsonl`; re-read the live row)

- **Desktop form(s):** `UT_BKP` — mode: direct constructor
- **Menu dispatch:** `unified/src/csharp/DataCareNext/MDI_FORM.cs:7471-7480`
- **Tables:** —
- **Web routes:** `/backup`
- **API:** `GET /backup`, `POST /backup/restore`
- **Desktop rights:** `C-----` (rights string order = Create, Read, Edit, Delete, Print, List ("-" = the desktop menu does not offer that right))
- **Status:** `CONTAINED`  **Phase:** `P1-core`  **Owners (slices/gaps):** G64, N80, X31, P12-05
- **Purpose:** Creates full SQL Server backups (yearly database plus NextMain) on a chosen drive and restores them.
- **Recorded gap:** Web offers a logical JSON export; restore is contained; encrypted off-site backup, scheduled restore drill and rollback remain.
- **Sources:** `project-memory/video-research/_kb/KB_master.md:225-253`

## Desktop pointers (start your study here)

- `UT_BKP.cs` is 1,298 lines. **`BtnRestore.Visible = false` (`:859`) and no code ever sets it true**, so a Lite operator cannot restore from this screen. `btnAttach` ("Dattach", `:899-901`) is shown only when `DC_Main.MsSqlDataPath` is set (`:1099-1102`; read from a file, `DC_Main.cs:976`) and detaches both SQL Server databases and quits the app: a vendor/IT tool specific to SQL Server, meaningless on the web.
- `BtnBkp_Click :1198-1251`: Print right required (`You Have No Print Rights.....`); empty path → `Please Select Path and Try`; remembers the path (registry `NEXT SOFTWARE\BACKUP_DATABASE\BACKUP_PATH`); writes `<path>\Next<YY>[_<company type>]_ddMMyy_HH.BAK` (company database; an existing file of the same name is deleted first) and `NextMain.BAK` (the master/config database); ends `Backup Process Complete.` with a progress bar and timer.
- The restore code (`BtnRestore_Click :1253`, `RESTORE DATABASE …`) exists but is unreachable from the UI.

## Current web state

- Page `backup/page.tsx` (53 lines); `modules/ops/backup.ts` (507) + `backupManifest.ts`; `GET /backup` (per-company JSON export with an integrity manifest); `POST /backup/restore` is **disabled by `web/packages/core/containment.mjs`**; `web/deploy/backup.sh` (`pg_dump` cron). Docs: DR runbook in `project-memory/parity/DR-RUNBOOK.md`.

## Decisions already made (owner-delegated on 2 Nov 2026; do not re-open them, do not ask again)

- **D-BKP-1 — parity = Backup only.** Matches what the desktop operator can do. Restore stays an operator/IT procedure (physical database recovery, DR runbook); `containment.mjs` is **not edited**. No owner decision is needed because the desktop does not offer the operator a restore either.
- **D-BKP-2 — "choose a path" becomes the browser's Save dialog.** A browser cannot write to a server path; the equivalent of the folder picker is the download location. Keep the caption, the progress indicator and the messages.
- **D-BKP-3 — file content = this company's data plus the equivalent of `NextMain`** (this tenant's company/user/rights/menu configuration), as one download named `Next<YY>[_<type>]_ddMMyy_HH` (+ archive extension), integrity manifest inside. No other tenant's data, ever.

## Scope — what you must deliver

- The desktop screen: path/download control, **Backup** button, progress, the three exact messages, the Print-right gate (rights by caption "Data Backup"), audit row for who backed up when.
- The backup **content** must be complete for every Lite dataset (masters, vouchers, tags, openings, settings, rights) and its manifest hash must verify. Prove completeness by restoring it **into a scratch database using the documented physical procedure** (not the web restore) and diffing the tenant to zero.
- Leave `POST /backup/restore` disabled and make sure no UI path reaches it; a test asserts the route still answers the containment refusal.
- No `Dattach`, no restore button, no registry/path persistence on the server.

## Case emphasis (on top of the T01–T18 expansion in 00-GENERIC §3 step 2)

- Backup of a company holding every Lite dataset; byte-stable manifest; a second tenant never in the file; restricted user refused by the API; two backups in the same hour (same name) behave as the desktop (replaced); large company completes and reports progress; restore route still refused.

## Risks and traps

- Do not "helpfully" enable restore. Anything that changes `containment.mjs` is out of scope and a reason to stop.

## Shared files you are likely to touch (expect merge conflicts here; regenerate generated files, do not hand-merge)

- `ops/backup*.ts`
- `backup/page.tsx`

## Reminders

- Rebase on fresh `origin/main` and allocate `N###`/`G###` **last**, not first (00-GENERIC §3 step 6).
- Desktop match is 0%; say so. Do not mark the catalog row `FULL` unless every case passes and no gap is open.
- Finish with the final-report block from 00-GENERIC §5.
