# Agent 15 — Company → Balance TrFr   (Lite package L5)

**Type:** BUILD (company utility, money-critical)  
**Suggested wave:** 4  
**Do not start building until:** Agent 14 (Year Create) has merged.  
**Prompt generated against:** `origin/main` @ `3fd1adc3` (1–2 Nov 2026). Re-fetch and re-read the catalog row before you start; if `main` moved, trust `main`.

> Read `00-GENERIC.md` first. This file is the menu-specific part.

## Mission

Make Company → Balance TrFr the desktop `BtmSchm` screen (`MS_BAL_TRFR`): carry the closing balances of every Lite-visible dataset into the next financial year.

## Identity and hand-offs

- **SLUG** `balance-transfer`  **BRANCH** `feat/lite-balance-transfer`  **worktree** `~/dc-wt/balance-transfer`  **feature module** `balanceTransfer`
- Isolated Compose project: `PARITY_TEST_PROJECT=dc-balance-transfer` (ports come from the stack slot you take, see 00-GENERIC §2.1).

## Catalog facts (copied from `docs/handbook/menu-catalog.jsonl`; re-read the live row)

- **Desktop form(s):** `BtmSchm` — mode: direct constructor
- **Menu dispatch:** `unified/src/csharp/DataCareNext/MDI_FORM.cs:7431-7440`
- **Tables:** `OP_DATA`, `AC_DATA`, `ITM_OPBL`, `BAR_DETL`, `SL_ORD_DATA`, `APR_DATA`, `DHRN_DATA`, `LOT_DETL`
- **Web routes:** `/company/balance-transfer`
- **API:** `POST /balance-transfer/preview`, `POST /balance-transfer/year-close`, `POST /balance-transfer/openings`
- **Desktop rights:** `C-----` (rights string order = Create, Read, Edit, Delete, Print, List ("-" = the desktop menu does not offer that right))
- **Status:** `PARTIAL`  **Phase:** `P1-core`  **Owners (slices/gaps):** X27, P11-01, X06
- **Purpose:** Carries account, party, stock, order, scheme, loan, approval, repair, lot and manufacturing balances into the next financial year.
- **Recorded gap:** Web carries account and party openings only; stock, order, scheme, loan, approval, repair, lot and manufacturing branches, Print and interruption recovery remain.
- **Sources:** `project-memory/catalogs/module-map.json:202-260`

## Desktop pointers (start your study here)

- `BtmSchm.cs` is 5,638 lines: Load `:1929`; one button per dataset — `BtnAcBalence :2724` (accounts), `BtnItmStk :2921` (item stock), `BtnTagStock :2169` (tags), `BtnOrder :3003` (sales orders), `BtnApr :4116` (approvals), `BtnDhrn :3602`, `BtnLoan :3859`, `BtnTimeLdr :4871`, …
- **First classify every button by edition**: Dhiran, loan, scheme, lot and manufacturing buttons belong to menus outside Lite. Record each as N/A *with the source citation that hides it in Lite* before running; carry only what Lite data can contain. Tables listed in the catalog: `OP_DATA`, `AC_DATA`, `ITM_OPBL`, `BAR_DETL`, `SL_ORD_DATA`, `APR_DATA`, `DHRN_DATA`, `LOT_DETL`.

## Current web state

- Page `company/balance-transfer/page.tsx` (326 lines); API `POST /balance-transfer/preview|year-close|openings`. Today only account and party openings are carried; stock, order, approval… are missing; no Print; no interruption recovery.

## Scope — what you must deliver

- Each Lite-relevant dataset: preview (what will be carried), execute, idempotency (second run refused or no-op as the source says), interruption recovery (fault after table k → complete rollback or resumable), and print.

## Case emphasis (on top of the T01–T18 expansion in 00-GENERIC §3 step 2)

- **Closing = Opening identity.** In year 1 create: sales, purchases, receipts/payments, contra, item and tag openings, tag sales/cancels, a pending sales order, an approval issue. Carry. In year 2 the party balances (money, gold fine, silver fine), item stock (pcs/gross/net/fine), tag stock, pending orders and approvals equal year 1's closing **by hand count**.
- Carry twice, carry with a locked year, carry into a year that already has vouchers.

## Risks and traps

- If it is wrong the shop starts the year with wrong balances. No case may be inferred; blocked is better than guessed.

## Shared files you are likely to touch (expect merge conflicts here; regenerate generated files, do not hand-merge)

- `ops/yearEnd.ts`
- `routes/txn.ts` or the balance-transfer route file

## Reminders

- Rebase on fresh `origin/main` and allocate `N###`/`G###` **last**, not first (00-GENERIC §3 step 6).
- Desktop match is 0%; say so. Do not mark the catalog row `FULL` unless every case passes and no gap is open.
- Finish with the final-report block from 00-GENERIC §5.
