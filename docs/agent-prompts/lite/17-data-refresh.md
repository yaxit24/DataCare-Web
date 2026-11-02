# Agent 17 — Company → Data Refresh   (Lite package L5)

**Type:** BUILD — scope DECIDED 2 Nov (owner-delegated): the 6 operator-visible buttons only  
**Suggested wave:** 3  
**Prompt generated against:** `origin/main` @ `3fd1adc3` (1–2 Nov 2026). Re-fetch and re-read the catalog row before you start; if `main` moved, trust `main`.

> Read `00-GENERIC.md` first. This file is the menu-specific part.

## Mission

Make Company → Data Refresh the desktop `MS_UPDATE` screen **as an operator sees it**: six repair buttons, each running a preview-first, single-transaction, audited repair. The vendor-only tools the desktop hides behind a secret key are out of scope.

## Identity and hand-offs

- **SLUG** `data-refresh`  **BRANCH** `feat/lite-data-refresh`  **worktree** `~/dc-wt/data-refresh`  **feature module** `dataRefresh`
- Isolated Compose project: `PARITY_TEST_PROJECT=dc-data-refresh` (ports come from the stack slot you take, see 00-GENERIC §2.1).

## Catalog facts (copied from `docs/handbook/menu-catalog.jsonl`; re-read the live row)

- **Desktop form(s):** `MS_UPDATE` — mode: direct constructor
- **Menu dispatch:** `unified/src/csharp/DataCareNext/MDI_FORM.cs:7461-7470`
- **Tables:** `AC_DATA`, `MAIN_STOCK`, `BAR_DETL`, `BOOK_DATA`, `TAX_DATA`, `OP_DATA`, `MFG_DATA`
- **Web routes:** `/utilities/data-refresh`, `/utilities/data-repair`
- **API:** `POST /utilities/data-refresh`, `GET /utilities/data-repair/operations`, `POST /utilities/data-repair/:id/preview`, `POST /utilities/data-repair/:id/apply`
- **Desktop rights:** `C----L` (rights string order = Create, Read, Edit, Delete, Print, List ("-" = the desktop menu does not offer that right))
- **Status:** `PARTIAL`  **Phase:** `P1-core`  **Owners (slices/gaps):** X27, P11-01, X06
- **Purpose:** Rebuilds or repairs derived ledger, stock, schema, image, scheme and manufacturing data.
- **Recorded gap:** Refresh deliberately avoids write-back; the repair registry covers a subset of desktop operations; ownership graph, rollback and recovery are unproven.
- **Sources:** `web-implementation-spec/03_Modules/13_Utilities_Settings_Integrations/VARIANTS.md:99-119`

## Desktop pointers (start your study here)

- `MS_UPDATE.cs` is 33,074 lines but **an operator sees only six buttons**. All the others are `Visible = false` in the designer (`:1535-1986`) and are revealed only by the secret **Ctrl+O** (`MS_UPDATE_KeyDown :2275-2301`), or by company type (`Mfg Refresh` only when `MsMfgType = "M"`, `:2180-2183`; `Scheme Data` only with `MsAppSchem = "Y"`).
- **In scope (visible by default):** `Account` `btnAc_Click :2334` (67 lines: fills `BOOK_DATA/BOOK_DETL.DATA_TYPE`, `CASH_DATA.CLR_DATE`, rebuilds `BANK_RECONCILE` and restores `AC_DATA.CLR_DATE`, runs `AcRefresh()`, then `Ac_Tax.Vch_Remark` for every in-use book; ends "Account Refersh Process Complete."); `Stock` `btnStock_Click :2671` (181 lines: recomputes `ITM_FINE` where it is <= 0 on `BAR_DETL` / `SL_DETL_RTN` …); `Approval Adj` `btnAprUpdate_Click :8809` (16 lines); `Image Data` `BtnImgData_Click :8825` (232 lines); `Field Update` `btnFildUpdate_Click :3958` (**≈4,850 lines**); `Old Field` `btnFildUpdate2_Click :9412` (**≈22,900 lines**).
- **Out of scope, and why:** the 12 Ctrl+O tools (`Crm Data`, `Problem Qry`, `TagDiff Set`, `All Tag Stock Delete`, `SrNo Mast Update`, `Bar Idtl SrNo Update`, `Sl Wt Diff Set`, `Other Set`, `OpBal Update`, `Tag Sale But Not In BarDetl Adjust`, `A Stock Set`, and the date-ranged ones) are vendor support tools for repairing a customer's damaged database, not operator features. Do **not** build the Ctrl+O reveal. `Mfg Refresh`, `Scheme Data` belong to editions/settings outside Lite.
- Every button first requires the Print right: message `You Have No Print Rights.....` (`UserPrint = "Y"`; rights are read by the menu caption, `:2042`).

## Current web state

- Pages `utilities/data-refresh/page.tsx` (100 lines) and `utilities/data-repair/page.tsx` (391); API `POST /utilities/data-refresh`, `GET /utilities/data-repair/operations`, `POST /utilities/data-repair/:id/preview|apply`. Catalog: "Refresh deliberately avoids write-back; the repair registry covers a subset; ownership graph, rollback and recovery are unproven." Slices X27 / P11-01.

## Decisions already made (owner-delegated on 2 Nov 2026; do not re-open them, do not ask again)

- **D-REF-1 — operator-visible buttons only.** Six buttons (Account, Stock, Field Update, Approval Adj, Image Data, Old Field). The 12 `Ctrl+O` vendor tools, `Mfg Refresh` and `Scheme Data` are out of Lite scope; no hidden shortcut is built.
- **D-REF-2 — preview-first, one transaction, audited, idempotent.** A deliberate safety improvement; the business result of each repair is unchanged.
- **D-REF-3 — the two giant buttons are classified before they are built** (apply / provably-no-op on web data / migration-loader). Nothing from the 27k lines is ported blindly.

## Scope — what you must deliver

- **Screen:** the six desktop captions in the desktop order, a progress indicator, the desktop completion messages (keep the original spelling), the Print-right gate with its exact text. No hidden shortcut.
- **Every operation is preview-first:** counts and a sample of the rows it would change, then Apply in **one transaction** with an audit row, tenant-scoped, idempotent (a second run changes nothing). Never a blind write. This is a deliberate improvement over the desktop's unguarded loops and does not change the business result.
- **PR 1 (small, ship fast): Account, Stock, Approval Adj, Image Data** (about 500 desktop lines in total). Prove each with a controlled corruption of derived data through a fixture, preview, apply, and a **full-tenant diff** showing only the intended rows moved.
- **PR 2: classify `Field Update` and `Old Field` (≈27,700 lines) before building anything.** Table: every UPDATE statement → one of **(a)** the anomaly can occur in data the web writes → implement as a repair; **(b)** it only repairs shapes produced by older desktop versions → write an *anomaly query* and prove, on a tenant populated through every Lite screen, that it returns 0 rows; the button then truthfully reports "no records need adjustment" (this is the desktop's own outcome on a clean database); **(c)** only needed after loading desktop data → list it for the migration loader (slices X30/P12/N30), do not build it here. Implement class (a) only.

## Case emphasis (on top of the T01–T18 expansion in 00-GENERIC §3 step 2)

- Per operation: corrupt → preview shows exactly the rows → apply → derived data equals a clean recompute from the vouchers → run again (no-op) → a voucher saved concurrently during apply (conflict handled, nothing lost).
- Rights by caption "Data Refresh" (G225 lists it as not closed — settle it here), a restricted user is refused by the API.
- Second tenant untouched in every case.

## Risks and traps

- Repair tools can destroy data; preview-first is not optional. If you cannot reproduce a desktop effect exactly, ship preview-only for that operation and say so.
- Classification PR is analysis, not code: do not skip it to "get on with it" — 27k lines of legacy patches must not be ported blindly.

## Shared files you are likely to touch (expect merge conflicts here; regenerate generated files, do not hand-merge)

- `modules/ops/*`
- the two utilities pages

## Reminders

- Rebase on fresh `origin/main` and allocate `N###`/`G###` **last**, not first (00-GENERIC §3 step 6).
- Desktop match is 0%; say so. Do not mark the catalog row `FULL` unless every case passes and no gap is open.
- Finish with the final-report block from 00-GENERIC §5.
