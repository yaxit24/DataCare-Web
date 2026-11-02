# Agent 16 — Company → Company   (Lite package L5)

**Type:** BUILD (admin screen; tenancy-sensitive; has a destructive action)  
**Suggested wave:** 3  
**Prompt generated against:** `origin/main` @ `3fd1adc3` (1–2 Nov 2026). Re-fetch and re-read the catalog row before you start; if `main` moved, trust `main`.

> Read `00-GENERIC.md` first. This file is the menu-specific part.

## Mission

Make Company → Company the desktop `MS_COMPANY` screen: create the company identity (state, work type, metal type, GST, bank, e-invoice settings) and seed its year, masters and settings.

## Identity and hand-offs

- **SLUG** `company-master`  **BRANCH** `feat/lite-company-master`  **worktree** `~/dc-wt/company-master`  **feature module** `companyMaster`
- Isolated Compose project: `PARITY_TEST_PROJECT=dc-company-master` (ports come from the stack slot you take, see 00-GENERIC §2.1).

## Catalog facts (copied from `docs/handbook/menu-catalog.jsonl`; re-read the live row)

- **Desktop form(s):** `MS_COMPANY` — mode: direct constructor
- **Menu dispatch:** `unified/src/csharp/DataCareNext/MDI_FORM.cs:7411-7420`
- **Tables:** `CO_MAST`, `CO_SET`, `CO_SET_NEW`, `AC_GROUP`, `BOOK_DATA`, `LOCT_MAST`, `MENU_DATA`
- **Web routes:** `/masters/companies`, `/admin/provision`
- **API:** `GET /masters/:name`, `POST /masters/:name`, `PUT /masters/:name`, `DELETE /masters/:name`, `POST /admin/companies/:coCode/provision`
- **Desktop rights:** `CRED-L` (rights string order = Create, Read, Edit, Delete, Print, List ("-" = the desktop menu does not offer that right))
- **Status:** `PARTIAL`  **Phase:** `P1-core`  **Owners (slices/gaps):** G38, G39, N58, X10, N77
- **Purpose:** Creates the company identity and seeds its year, masters, settings and operating parameters.
- **Recorded gap:** Bare CRUD and provisioning do not reproduce the rich form or the desktop 17-table copy (NewCompParmCreat); Print and conditional fields remain.
- **Sources:** `project-memory/video-research/_kb/KB_master.md:45-75`, `unified/src/csharp/DataCareNext/MS_YEAR.cs:1504-1595`

## Desktop pointers (start your study here)

- `MS_COMPANY.cs` is 7,615 lines: Load `:5397`, Clear `:5756`, Display `:5882`, **Save `:6042`**, **Delete `:6254-6776` (≈500 lines)**, Print `:6776`; e-invoice/URL sub-forms `:7406-7555`. The 17-table seed copy is `NewCompParmCreat` (`MS_YEAR.cs:1504-1595`, shared with agent 14). UAE-specific parts (`BtnExitUae`) are out of Lite.
- Tables `CO_MAST`, `CO_SET`, `CO_SET_NEW`, `AC_GROUP`, `BOOK_DATA`, `LOCT_MAST`, `MENU_DATA`.

## Current web state

- Generic `/masters/companies` and `/admin/provision` (`ops/seedCompany.ts`, 850 lines; `POST /admin/companies/:coCode/provision`). The web has a tenant model the desktop does not (RLS, `tenant_id`).

## Scope — what you must deliver

- The detail form with every conditional field; Save validations and texts; the seeded set (compare with the desktop copy table by table); Print; the edit rights (admin-only: the Company menu grants admin — see G225 "not closed" list).
- **Delete:** the desktop deletes a company's data with a long cascade. In a hosted multi-tenant system an equivalent is unsafe (D25, G80). Do **not** port the cascade. Implement only a guarded behaviour the source plus an accepted decision supports; otherwise record it as a blocked case and ask the owner.

## Case emphasis (on top of the T01–T18 expansion in 00-GENERIC §3 step 2)

- Provision a fresh company through the UI end to end and compare the seeded rows to the desktop list; log in to it; create one voucher in it. Second tenant's data untouched (diff before/after). Edit the company; reopen; unchanged save.
- Duplicate code/name refused with the desktop text; GST/PAN formats.

## Risks and traps

- Tenant-provisioning code is the foundation of everything: keep the change small, test the whole-tenant diff, never run against a database with real data.

## Shared files you are likely to touch (expect merge conflicts here; regenerate generated files, do not hand-merge)

- `ops/seedCompany.ts` (shared with agent 14)
- `admin/provision` page
- `masters/configs.ts`

## Reminders

- Rebase on fresh `origin/main` and allocate `N###`/`G###` **last**, not first (00-GENERIC §3 step 6).
- Desktop match is 0%; say so. Do not mark the catalog row `FULL` unless every case passes and no gap is open.
- Finish with the final-report block from 00-GENERIC §5.
