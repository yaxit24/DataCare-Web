# Agent 10 — Other → Tag Print   (Lite package L3)

**Type:** BUILD (utility with print output)  
**Suggested wave:** 1  
**Prompt generated against:** `origin/main` @ `3fd1adc3` (1–2 Nov 2026). Re-fetch and re-read the catalog row before you start; if `main` moved, trust `main`.

> Read `00-GENERIC.md` first. This file is the menu-specific part.

## Mission

Make Other → Tag Print the desktop `UT_TAG_PRINT` screen: select in-stock tags by tag, product or voucher and reprint barcode and QR labels with the shop's label layout.

## Identity and hand-offs

- **SLUG** `tag-print`  **BRANCH** `feat/lite-tag-print`  **worktree** `~/dc-wt/tag-print`  **feature module** `tagPrint`
- Isolated Compose project: `PARITY_TEST_PROJECT=dc-tag-print` (ports come from the stack slot you take, see 00-GENERIC §2.1).

## Catalog facts (copied from `docs/handbook/menu-catalog.jsonl`; re-read the live row)

- **Desktop form(s):** `UT_TAG_PRINT` — mode: constructor mode 'Tag Print'
- **Menu dispatch:** `unified/src/csharp/DataCareNext/MDI_FORM.cs:8596-8605`
- **Tables:** `TAG_PRINT_DATA`, `BAR_DETL`, `BAR_IDTL`, `PRINT_MAST`, `MAIN_STOCK`
- **Web routes:** `/txn/tag-print`
- **API:** `GET /stock/tag-print`, `POST /stock/tag-print/stage`, `GET /stock/tag-print/label`
- **Desktop rights:** `----PL` (rights string order = Create, Read, Edit, Delete, Print, List ("-" = the desktop menu does not offer that right))
- **Status:** `PARTIAL`  **Phase:** `P1-core`  **Owners (slices/gaps):** N25, X28, G59, N73, G60, N75, X25
- **Purpose:** Selects in-stock tags by tag, product or voucher and reprints barcode and QR labels.
- **Recorded gap:** Basic label sheets work; PRINT_MAST variants, voucher/product selection, label skip, dimensions, fonts and physical-printer evidence remain.
- **Sources:** `project-memory/video-research/_kb/KB_other.md:117-139`

## Desktop pointers (start your study here)

- `UT_TAG_PRINT.cs` is 6,267 lines (the class constructor is still named `TR_TAG_CAN_Load` at `:4735` — a copy artefact). Clear `:5014`, Save `:5073`, Delete `:5097`, **Print `:5122`**, Cancel `:5227`, **`BtnTagSet_Click :5636`** (layout/settings), `BtnRfid_Click :6008` (RFID — decide from source/edition if it is Lite).
- Tables `TAG_PRINT_DATA`, `PRINT_MAST` (label variants), `BAR_DETL`, `BAR_IDTL`, `MAIN_STOCK`. Rights `----PL`.

## Current web state

- Page `txn/tag-print/page.tsx` (171 lines). API `GET /stock/tag-print`, `POST /stock/tag-print/stage`, `GET /stock/tag-print/label`. "Basic label sheets work".

## Scope — what you must deliver

- Selection by tag no., product, voucher (and any other mode in the source); `PRINT_MAST` variants; label skip; dimensions, fonts; barcode and QR content; count/copies; what the desktop writes to `TAG_PRINT_DATA`.
- **Printer reality:** device fakes are allowed for engineering tests (D29). Prove the generated label data/PDF/ZPL (or whatever the source emits) byte-for-byte for known tags; physical-printer acceptance stays **pending** — write it as a blocked case with that reason, never as passed.

## Case emphasis (on top of the T01–T18 expansion in 00-GENERIC §3 step 2)

- Tags from Tag Opening/Purchase; select by each mode; the label content equals the tag fields by hand (tag no., item, weights, rate/MRP, HUID, barcode text); skip/count behaviour; empty selection refusal text; cancelled/sold tags excluded or included as the source says.

## Risks and traps

- Printing is the one place the browser cannot fully verify; be exact about what is proven.

## Shared files you are likely to touch (expect merge conflicts here; regenerate generated files, do not hand-merge)

- `routes/txn.ts` (one line)
- `modules/stock/*` (shared with agents 11, 22)

## Reminders

- Rebase on fresh `origin/main` and allocate `N###`/`G###` **last**, not first (00-GENERIC §3 step 6).
- Desktop match is 0%; say so. Do not mark the catalog row `FULL` unless every case passes and no gap is open.
- Finish with the final-report block from 00-GENERIC §5.
