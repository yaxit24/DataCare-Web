# Agent 19 — Other → Data Import   (Lite package L3)

**Type:** BUILD — scope DECIDED 2 Nov (owner-delegated): the "Lite Soft" import only; **lowest priority, do it last**  
**Suggested wave:** 5  
**Prompt generated against:** `origin/main` @ `3fd1adc3` (1–2 Nov 2026). Re-fetch and re-read the catalog row before you start; if `main` moved, trust `main`.

> Read `00-GENERIC.md` first. This file is the menu-specific part.

## Mission

Other → Data Import is the desktop `UT_IMPORT`, titled **"Old Software Import"**: a one-time migration from the vendor's *previous* products. Build the one path a Lite shop uses, **Lite Soft**, as a safe, atomic, previewed import. Do not build the other ~34 products' importers.

## Identity and hand-offs

- **SLUG** `data-import`  **BRANCH** `feat/lite-data-import`  **worktree** `~/dc-wt/data-import`  **feature module** `dataImport`
- Isolated Compose project: `PARITY_TEST_PROJECT=dc-data-import` (ports come from the stack slot you take, see 00-GENERIC §2.1).

## Catalog facts (copied from `docs/handbook/menu-catalog.jsonl`; re-read the live row)

- **Desktop form(s):** `UT_IMPORT` — mode: constructor caption 'Data Import'
- **Menu dispatch:** `unified/src/csharp/DataCareNext/MDI_FORM.cs:8606-8615`
- **Tables:** `AC_MAST`, `ITEM_MAST`, `BAR_DATA`, `BAR_DETL`, `SL_DATA`, `PR_DATA`
- **Web routes:** `/masters/accounts`
- **API:** `POST /masters/:name/import`
- **Desktop rights:** `C-----` (rights string order = Create, Read, Edit, Delete, Print, List ("-" = the desktop menu does not offer that right))
- **Status:** `PARTIAL`  **Phase:** `P1-core`  **Owners (slices/gaps):** N26, X27, P11-01, X10, P03-05
- **Purpose:** Imports an old company's masters, openings, vouchers, stock, schemes and loan datasets.
- **Recorded gap:** Only generic master-row import exists; historical vouchers, openings, tag/stock, scheme/loan and restartable conversion are absent.
- **Sources:** `unified/src/csharp/DataCareNext/UT_IMPORT.cs:3457-4363`

## Desktop pointers (start your study here)

- `UT_IMPORT.cs` is 14,466 lines with ~35 buttons, one per old product: `Wh Soft`, `Retail Soft`, `Retail Dhrn/Schm/Loan/Jadtar`, **`Lite Soft` (`BtnLite_Click :8413`)**, `Plus Soft/Dhrn/Approval/Schm/Loan/Ac Opening/Reparing`, `Chudi Sql`, `Rtl-Wh-HuId` … The form caption is "Old Softwar Import" (`:3187`). The same form with all import buttons hidden is the separate **Estimate Reset** menu (Standard; `:3300-3345`).
- **Lite Soft flow (`:8413-8445`):** question `Are You Sure To Import Old Software Data In Next Software ?` → Open dialog filtered `MDB (*.mdb)` → `TrfrConn()` → `ImpSoftType = "Lite"` → `Lite_AcMast()` (accounts, ≈90 lines) → `Wh_Item()` (items, ≈89) → `WH_AcOpbl()` (account openings, ≈33) → `Lite_BarData()` (tags, ≈247; **first deletes `BAR_DATA/BAR_DETL/BAR_IDTL` of the company**) → `WH_ItOpbl()` (item openings, ≈76) → sets `HDD_MAST.REF_NO = "S"`, `YEAR_MAST.OP_DATE = today`, `LOCT_MAST.TRY_DATE = today + 10 days` → `Process Are Complete....` → the application exits. The five import methods are about 535 lines in total: this is tractable.
- The input is a Microsoft Access `.mdb` from the old Lite product. **There is no sample `.mdb` and no Access reader in the repository** (`apps/api/package.json` has none).

## Current web state

- Only the generic `POST /masters/:name/import` (CSV rows) exists. The catalog maps this menu to `/masters/accounts`, which is wrong: it has no screen of its own. The Excel imports inside Item (`MS_ITEM.cs:3856-3909`) and Party (`MS_ACCT.cs:9024`) are claimed by this menu (doc 12 G231); treat them as phase 2 of this work only if time remains.

## Decisions already made (owner-delegated on 2 Nov 2026; do not re-open them, do not ask again)

- **D-IMP-1 — Lite Soft only.** The other buttons are bespoke importers for other legacy products, run by the vendor at onboarding; they become a managed migration service in Phase 2 (G80/D25). If you have a customer coming from Retail, Wh or Plus Soft, say so and each becomes its own small slice.
- **D-IMP-2 — atomic and previewed, and it never silently wipes.** The desktop is not atomic and deletes the company's tag tables unconditionally. The web runs the five steps in **one transaction**, shows counts per step before the confirm question, and **refuses a company that already has vouchers, openings or tags** with a clear message (the import is meant for a freshly created company). This is a deliberate, documented deviation.
- **D-IMP-3 — memory-safe reader, never a shell.** Read the `.mdb` in-process with a pure-JavaScript reader (evaluate `mdb-reader`; it must handle the Jet version the old Lite product used) behind a small `SourceReader` interface, with a size cap, a table/column allow-list and a timeout. No child process, no `mdbtools`.
- **D-IMP-4 — do not port licence/trial manipulation.** `HDD_MAST.REF_NO` and `LOCT_MAST.TRY_DATE` are licensing state; record them as an intentional omission unless the web has an equivalent that the source proves is business behaviour. `OP_DATE` is business behaviour: port it.

## Scope — what you must deliver

- New route `/utilities/data-import` titled **Old Software Import**, classified in `docs/handbook/web-route-editions.json`, with the **Lite Soft** button, the desktop question and completion texts, per-step progress, the rights gate by caption "Data Import" (G225 lists it as not closed — settle it), correct the catalog row's `ui`.
- The five import steps mapped column by column with desktop citations (`Lite_AcMast`, `Wh_Item`, `WH_AcOpbl`, `Lite_BarData`, `WH_ItOpbl`): which source table/column fills which web column, defaults, code generation, account-group assignment, touch/fine arithmetic, tag numbering.
- Row-level error report (which source row, which reason); idempotency key so a double click or retry imports once; audit row; tenant scoping; after import, the Party, Item, Tag Stock, Stock and Ledger screens show the imported data correctly.

## Case emphasis (on top of the T01–T18 expansion in 00-GENERIC §3 step 2)

- **Because there is no real file:** test the mapping and the transaction at the `SourceReader` boundary with table fixtures built from the desktop's column list (cite lines). One case, "reads a real Lite Soft `.mdb`", is **BLOCKED with the reason "no sample file in the repository; the owner must supply one sanitized or synthetic file"**. It stays in the denominator. Do not fabricate a binary `.mdb`.
- Fresh company imports; company with data refused (nothing written); a failure in step 4 rolls back steps 1-3 (T14, per step); retry/double submit; oversized or malformed file refused with no write; a file with unknown tables ignored safely; rights; second tenant untouched.
- Downstream: the imported tag appears in Tag Stock and can be sold through the Sales screen; an imported party's opening balance shows in the ledger.

## Risks and traps

- Lowest value of the 23: only shops migrating from the old Lite product need it. Do not let it delay anything else (wave 5).
- Untrusted binary parsing: keep the reader isolated and capped.

## Shared files you are likely to touch (expect merge conflicts here; regenerate generated files, do not hand-merge)

- `masters/*import*`
- `web-route-editions.json`
- menu catalog row `ui`
- `apps/api/package.json` (new dependency: justify it in the PR)

## Reminders

- Rebase on fresh `origin/main` and allocate `N###`/`G###` **last**, not first (00-GENERIC §3 step 6).
- Desktop match is 0%; say so. Do not mark the catalog row `FULL` unless every case passes and no gap is open.
- Finish with the final-report block from 00-GENERIC §5.
