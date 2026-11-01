# Agent 09 — Master → Party   (Lite package L2)

**Type:** BUILD (master) — follow the Address master (#192) as the template  
**Suggested wave:** 1  
**Prompt generated against:** `origin/main` @ `3fd1adc3` (1–2 Nov 2026). Re-fetch and re-read the catalog row before you start; if `main` moved, trust `main`.

> Read `00-GENERIC.md` first. This file is the menu-specific part.

## Mission

Make Master → Party the desktop `MS_ACCT` screen: one rich screen for customer, supplier, karigar and bank accounts, with contacts, tax and bank data, photo/family, inline opening balance, delete and print.

## Identity and hand-offs

- **SLUG** `party-master`  **BRANCH** `feat/lite-party-master`  **worktree** `~/dc-wt/party-master`  **feature module** `partyMaster`
- Isolated Compose project: `PARITY_TEST_PROJECT=dc-party-master` (ports come from the stack slot you take, see 00-GENERIC §2.1).

## Catalog facts (copied from `docs/handbook/menu-catalog.jsonl`; re-read the live row)

- **Desktop form(s):** `MS_ACCT` — mode: direct constructor
- **Menu dispatch:** `unified/src/csharp/DataCareNext/MDI_FORM.cs:7600-7609`
- **Tables:** `AC_MAST`, `OP_DATA`, `AC_DATA`
- **Web routes:** `/masters/party`, `/masters/accounts`
- **API:** `GET /masters/:name`, `POST /masters/:name`, `PUT /masters/:name`, `DELETE /masters/:name`, `GET /party/:acCode/family`, `GET /party/:acCode/photo`, `POST /party/:acCode/photo`, `GET /accounts/:acCode/opening`, `POST /accounts/:acCode/opening`
- **Desktop rights:** `CRED-L` (rights string order = Create, Read, Edit, Delete, Print, List ("-" = the desktop menu does not offer that right))
- **Status:** `PARTIAL`  **Phase:** `P1-core`  **Owners (slices/gaps):** G53, N67, X10, G38, N58, N77, G225, N212
- **Purpose:** Creates customer, supplier, karigar and bank accounts with contacts, tax and bank data and openings.
- **Recorded gap:** The rich party page ignores duplicate-detail updates and lacks delete and print; capabilities are split across two routes.
- **Sources:** `project-memory/video-research/_kb/KB_master.md:113-145`

## Desktop pointers (start your study here)

- `MS_ACCT.cs` is 9,651 lines: Load `:5584`, Clear `:6134`, Display `:6356`, Print `:6689`, **Save `:7650`**, **Delete `:7963`**, image buttons `:8181-8394`, `BtnAdd :8501`, `BtnMemb :8538` (membership — verify if visible in Lite), `BtnAcimp :9024` (account import — belongs to **Data Import**, agent 19, not you).
- Account groups (`AC_GROUP`): 05 Vepari (supplier), 10 Karigar, 20 Customer, etc.; system accounts 00001–00010; `AC_CODE < 100` company-level (`LC_CODE=00`), `>= 200` location-level (`_kb/KB_master.md` §3).
- Opening balance lives in `OP_DATA` (amount, Cr/Dr, gold fine, silver fine) — the **Party Opening** menu is a separate screen that already has a green module (`partyOpening.mjs`); the inline opening box on Party must write the same rows.

## Current web state

- `app/(app)/masters/party/page.tsx` (313 lines, "rich" page) and the generic `/masters/accounts` through `masters/[name]` + `AC_MAST_CONFIG`. API: `modules/masters/party.ts` (86 lines), `GET /party/:acCode/family`, photo `GET|POST /party/:acCode/photo`, `GET|POST /accounts/:acCode/opening`.
- Catalog gap: "the rich party page ignores duplicate-detail updates and lacks delete and print; capabilities are split across two routes." **Other menus also map to `/masters/accounts`** (Data Import): do not remove that route; make `/masters/party` the complete screen and say what `/masters/accounts` remains for.

## Scope — what you must deliver

- Everything the Address master (#192) did, for MS_ACCT: tabs, next code, combos/helps, name type-ahead, mobile check, duplicate/exists question, leave-checks, desktop keys, Save replaces the row with the signed-in user, Delete with its guards (account used in vouchers/opening → refused; the exact texts) and cascade, Print.
- Photo/family tabs, GSTIN/PAN/Aadhaar format checks the source performs, credit days, interest %, DPC %, bank block.
- Inline opening balance and its relation to the Party Opening menu.

## Case emphasis (on top of the T01–T18 expansion in 00-GENERIC §3 step 2)

- Create one party of each group (customer, supplier, karigar, bank); open each from the sale/purchase/karigar/cash screens' party lookups and prove the new party is selectable and posts.
- Refuse delete of a party with vouchers; allow delete of an unused one with its opening rows.
- Rights by menu caption "Party" (G225 aliasing).

## Risks and traps

- Highest blast radius of the masters: every voucher references `AC_MAST`. Re-run the sales/purchase/cash-bank modules at the end to prove nothing regressed.

## Shared files you are likely to touch (expect merge conflicts here; regenerate generated files, do not hand-merge)

- `lookupEnter.ts`
- `rbac/formCatalog.ts`
- `masters/configs.ts`
- `routes/txn.ts` (one line)

## Reminders

- Rebase on fresh `origin/main` and allocate `N###`/`G###` **last**, not first (00-GENERIC §3 step 6).
- Desktop match is 0%; say so. Do not mark the catalog row `FULL` unless every case passes and no gap is open.
- Finish with the final-report block from 00-GENERIC §5.
