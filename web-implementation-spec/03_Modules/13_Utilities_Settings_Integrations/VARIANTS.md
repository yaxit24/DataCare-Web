# Variant stubs — operational & device utilities

> Compact specs for the remaining Module-13 forms. Each follows an abbreviated contract (purpose,
> desktop evidence, data model, web target, status, risks). The three heavy subsystems are in
> [SETTINGS.md](SETTINGS.md), [BACKUP_RESTORE.md](BACKUP_RESTORE.md), [INTEGRATIONS.md](INTEGRATIONS.md).

---

## A. `UT_VCH_RE_NUMBR` — Voucher Renumber  ·  🟩 BUILT

**Purpose.** Resequence one book+year's vouchers to a **gapless 1..N** ordered by `(VCH_DATE, VCH_NO)`,
rewriting the shared `VCH_NO` across **all** of the voucher's tables at once (header + detail + tax +
stock + ledger), so a book that developed holes (deleted/voided vouchers) becomes contiguous while
each voucher's rows stay joined.

**Desktop evidence.** `// src: UT_VCH_RE_NUMBR.cs` updates `SL_DATA/SL_DETL/SL_IDTL/SL_PR_DETL/
SL_ORD_ADJ/BILL_OS_DATA/UPI_DATA` (L1898-L1986), `PR_DATA/PR_DETL/PR_IDTL/BAR_*` (L2017-L2409),
`CASH_DATA` (L2695), `RATE_CUT_*` (L3983-L4035), `AD_ADJ` — i.e. every table carrying the book's
`VCH_NO`. Reads `BOOK_DATA` to pick the book.

**Web target.** `// src: web/apps/api/src/modules/utilities/voucherRenumber.ts`
- `previewRenumber` (READ-ONLY) builds the old→new map from `AC_DATA` (ordered by `VCH_DATE`,`VCH_NO`)
  and returns `{ rows, gaps }`.
- `applyRenumber` refuses unless `confirm===true` (`RenumberValidationError` → 400), runs in **one
  `withTenant` tx**, and is **collision-safe** via a two-phase park: move every changing voucher to
  `VCH_NO + 1,000,000`, then bring each parked row down to its final, **zero-pad-faithful** number, so
  no target slot collides. Scoped by `CO_CODE/CO_YEAR/CO_BOOK(/LC_CODE)`; tables intersected with the
  `RENUMBER_TABLE_ALLOWLIST` ∩ tables that actually have `VCH_NO`+`CO_BOOK` ∩ tables holding rows.

**Data model.** Writes (UPDATE `VCH_NO`): `AC_DATA, SL_DATA, SL_DETL, SL_IDTL, PR_DATA, PR_DETL,
TAX_DATA, BILL_OS_DATA, MAIN_STOCK, CASH_DATA` (allowlist). No inserts/deletes.

**API.** `GET /utilities/vch-renumber/preview?book=…` (auth, dry-run) · `POST /utilities/vch-renumber/apply`
(right: **delete** — admin-gate, mutates keys) `{ book, tables?, confirm:true }`. `// src: routes/txn.ts#324-335`.

**Status / risks.** Built. Highest-risk utility (rewrites the voucher key) — confirm-gated, dry-run
first, one transaction. Risk: tables outside the allowlist that also carry the book's `VCH_NO` would
be left un-renumbered — verify the allowlist against the full per-book table set in a golden-master pass.

---

## B. `UT_REMINDER` — Reminders (outstanding / birthday)  ·  🟩 BUILT

**Purpose.** Build worklists the shop acts on: parties with an unpaid balance (collection calls) and
parties whose birthday/anniversary is today (greetings) — then send via the messaging provider.

**Desktop evidence.** `// src: UT_REMINDER.cs` is read-centric: reads `AC_MAST`, `BILL_OS_DATA`,
`REM_DATA`, `TEMP_BOOK_DATA`, `EMP_MAST`; clears its scratch worklist (`DELETE REM_DATA`,
`TEMP_BOOK_DATA` L2107-L2229). No posting.

**Web target.** `// src: web/apps/api/src/modules/ops/reminders.ts`
- `overdueReminders` — `BILL_OS_DATA` grouped by party, `Σ(BILL_AMT − REC_AMT) > 0`, name+mobile from
  `AC_MAST`, `oldestBill` + `daysOverdue` (`CURRENT_DATE − min(VCH_DATE)`); scoped by `CO_CODE` only
  (outstanding accrues across years). `NN()` coalesces text-typed amount columns to numeric.
- `birthdayReminders` — `AC_MAST` `BR_DATE`/`L_BR_DATE` (birthday) & `AN_DATE` (anniversary) matched
  by month+day of `onDate` (default today); degrades to an empty result + note if the columns are absent.
- `sendReminder` — one send via `senderFromEnv` + `notify` (best-effort, never throws; reports `mode`).

**Data model.** Reads `BILL_OS_DATA`, `AC_MAST`. Writes none (web). Returns the `ListReport`
`{ rows, totals }` shape (reports-engine parity).

**API.** `GET /reminders/overdue` · `GET /reminders/birthdays?onDate=` · `POST /reminders/send`
`{ mobile, message, channel? }`. `// src: routes/txn.ts#483-487`.

**Status / risks.** Built. Risk: few party masters currently carry `BR_DATE`/`AN_DATE`; per-tenant
messaging credentials are the prerequisite for real sends.

---

## C. `UT_IMPORT` / `UT_EXPORT` — Company/Year data transfer  ·  🟦 PARTIAL

**Purpose.** Move an entire company/year dataset between databases/machines (year rollover, branch
consolidation, support hand-off). `UT_EXPORT` writes the dataset to a transfer file; `UT_IMPORT` loads
it with a **delete-then-insert** across the full table set.

**Desktop evidence.** `// src: UT_IMPORT.cs` INSERTs/DELETEs ~45 masters + transaction tables
(`AC_MAST, ITEM_MAST, GROUP_MAST, PRODUCT_MAST, BAR_*, SL_ORD_*, ITM_OPBL, OP_DATA, TOUCH_MAST, …`)
and UPDATEs `CO_SET, YEAR_MAST, HDD_MAST, LOCT_MAST` (L3484-L6512); `UT_EXPORT.cs` mirrors it,
reading ~40 transaction tables (`SL_*, PR_*, KR_*, BAR_*, RATE_CUT_*, AD_*, REP_*, CONTRA_DATA, …`).
The pattern is **wipe-scope then bulk-insert** — powerful and destructive.

**Web target.** The safe port is the scoped, transactional **year carry-forward**
(`// src: web/apps/api/src/modules/ops/yearEnd.ts`) — opens the next `CO_YEAR`, carries opening
balances/stock forward inside one `withTenant` tx — plus the offline **ETL**
(`// src: unified/tools/etl_mssql_to_pg.py`) for the original SQL-Server→Postgres migration. A general
file-import/export round-trip is a **deferred lever** (ADR-0002).

**Data model.** (Desktop) effectively every masters + voucher table for the scope. (Web) `yearEnd.ts`
touches opening tables (`OP_DATA`/`OP_LDR`/`ITM_OPBL`) + `YEAR_MAST`.

**Status / risks.** Partial. Full delete-then-insert import is intentionally **not** exposed as a web
button (blast radius = the whole company); it must be transactional, confirm-gated, and tenant-scoped
before shipping. Per-year separate DBs collapse to `CO_YEAR` scoping on the web.

---

## D. `MS_UPDATE` — Data-maintenance / recompute toolbox  ·  🟦 PARTIAL

**Purpose.** An **admin repair console**: recompute and refresh denormalized balances and fix orphaned
rows after edits/imports. A dangerous power-tool, not a daily screen.

**Desktop evidence.** `// src: MS_UPDATE.cs` button set: *Field Update, Account Refresh, Stock Refresh,
Mfg Refresh, OpBal Update, SrNo Mast Update, All Tag Stock Delete, "Tag Sale But Not In BarDetl
Adjust", Party Opening, Approval Refresh, Kr Fine Update, Bar Idtl SrNo Update, Scheme Data, Image
Data, Crm Data, TagDiff Set, Sl Wt Diff Set, Problem Qry* — i.e. recompute/rebuild operations across
stock, ledger, manufacturing, scheme and tag data.

**Web target.** The web favors **always-correct posting** (balanced `AC_DATA`, tag state transitions)
so most recompute needs vanish; where a rebuild is still required it lives in
`// src: web/apps/api/src/modules/ops/yearEnd.ts` (opening recompute) and the parity recompute
(`// src: web/apps/api/src/modules/parity/golden.ts` + `packages/parity` `xdb_diff`). Remaining
operations (e.g. stock/ledger refresh) should be exposed as **named, admin-gated, audited jobs**, never
ad-hoc SQL.

**Data model.** Recomputes `MAIN_STOCK`/`TAG_STOCK`, `AC_DATA` aggregates, `SRNO_MAST`, opening tables.

**Status / risks.** Partial. **High-risk** (mutates derived data app-wide). Enumerate each operation,
gate behind the `USER_DELETE`/admin right, wrap in a transaction, and log to the audit trail. "All Tag
Stock Delete" and "Problem Qry" especially need confirmation guards. Flag for a golden-master pass to
catalog every operation's exact effect.

---

## E. `UT_WEB_CAM` — Webcam capture  ·  ⬛ device-bound

**Purpose.** Capture a customer/item photo from the local webcam and save it to the image store
(bill image or master image).

**Desktop evidence.** `// src: UT_WEB_CAM.cs` uses the DevExpress `CameraControl`; on Save:
`CameraControl1.TakeSnapshot().Save(DC_Main.MsBillImgPath | DC_Main.MsImagePath)`. **No database
writes** — it writes an image file to the `NextImage`/`AllImage` store.

**Web target.** Browser `navigator.mediaDevices.getUserMedia` → `<canvas>` capture → upload to an
object store, with the URL referenced by the relevant master/voucher. No server form needed.

**Status / risks.** Device-bound (camera + local file path). The desktop's machine-local image paths
(`MsBillImgPath`/`MsImagePath`) have no server equivalent; the web replaces them with uploaded blobs.
Flagged as a device feature; not part of the API parity surface.

---

## F. `UT_HDD` — "Pc Registrar No" (machine fingerprint)  ·  ⬛ device-bound

**Purpose.** Bind a licence/activation to a physical machine by recording hardware serials.

**Desktop evidence.** `// src: UT_HDD.cs` reads `Win32_BaseBoard.SerialNumber` (motherboard) and
`Win32_LogicalDisk.VolumeSerialNumber` (disk `C:`) via WMI, renders them as QR (`QRCoder`), and stores
a single-row `HDD_MAST(REF_NO)` (`DELETE FROM HDD_MAST` then `INSERT … (REF_NO)`, L762-L763).

**Web target.** **N/A** — a web app has no equivalent to a client motherboard/disk serial, and
device-locking is contrary to the hosted model. Licensing on the web is per-tenant/account (auth +
subscription), not hardware-bound.

**Status / risks.** Device-bound, intentionally **not** ported. Documented so its absence is a
deliberate decision, not a gap. (`HDD_MAST` survives in the schema but is unused on the web.)

---

## G. Audit log — `ops/audit.ts`  ·  🟩 BUILT

**Purpose.** Compliance/security trail: record **every authenticated mutation** (who, which company,
method, path, status). Replaces the desktop's `USER_DATA`/activity logging.

**Web target.** `// src: web/apps/api/src/modules/ops/audit.ts`
- `logAudit` — `INSERT INTO audit_log(login_name, co_code, action, path, status)`; **best-effort**,
  wrapped in try/catch so a logging failure never affects the request.
- `listAudit` — recent entries (limit 200, max 500), newest first.
- Wiring: `// src: app.ts#onResponse` hook logs `POST/DELETE/PUT/PATCH` for any session (skips
  `/audit` itself), capturing `loginName`,`coCode`,`method`,`path`,`status`.

**API.** `GET /audit` (auth) → recent mutations for the tenant. `// src: app.ts#138`.

**Status / risks.** Built (Req 6 audit). It is **best-effort by design** (never blocks the request),
so it must not be relied on as a transactional log; for tamper-evidence, ship audit rows off-host.

---

## Cross-reference

| Form | Home doc |
|---|---|
| `UT_SETTING`, `UT_SETTING_MAIN`, `CO_SET` (LOCK_DATE, CASH_LIMIT, GST) | [SETTINGS.md](SETTINGS.md) |
| `UT_BKP`, pg_dump/restore | [BACKUP_RESTORE.md](BACKUP_RESTORE.md) |
| `UT_WHATSAPP`, `UT_WAPP_WITH_API`, `UT_SMS`, barcode/QR, rates, UPI | [INTEGRATIONS.md](INTEGRATIONS.md) |
| `UT_E_INVOICE` (IRN/GSP) | Module 9 — GST & E-Invoice (+ SETTINGS §4.5) |
| `UT_PWD_UPDATE` | Module 0 — Auth / RBAC |
