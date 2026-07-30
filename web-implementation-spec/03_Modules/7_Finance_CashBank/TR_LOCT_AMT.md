# TR_LOCT_AMT — Inter-Location Amount Transfer (variant stub)

```
Form: TR_LOCT_AMT  ·  Module: 7_Finance_CashBank  ·  Type: transaction (posting)
Desktop source: unified/src/csharp/DataCareNext/TR_LOCT_AMT.cs (3,988 lines) + Ac_Ledr.cs (Loct_Amt_Ledr #L1987)
Web target: (none yet) — model on apps/api/src/modules/finance/finance.ts (postContra/postJournal) · apps/web/app/(app)/txn/loct
Requirements: Req 17.1 (balanced), 17.3 (transfer Dr/Cr same amount), 13.4 (reverse)
Parity: 06_Parity/finance.md  ·  Status: 📋 SPEC · ⬛ UNBUILT
Evidence: form catalog project-memory/catalogs/forms/TR_LOCT_AMT.md ; reads LOCT_MAST (location master)
```

> **A contra-style transfer across locations/branches** (`LC_CODE`). Reuses the posting pattern of
> [`TR_CONTRA`](TR_CONTRA.md) but the counter side is another **location** (`LOCT_MAST`), and the
> header lands in `LOCT_AMT`. No web implementation exists yet — build from `postContra`.

## 1. Purpose & business context
Move money between **locations/branches** of the same company (e.g. head office ↔ branch float).
Posts a balanced transfer so each location's ledger reflects the in/out, and feeds the day-book.
Blocked for company type `B` ("You Cant Save This Voucher Becouse This Company Type is B……",
`src: TR_LOCT_AMT.cs#L3063`).

## 2. UI / UX specification
Header (Vch No, Date, Emp) + lines naming the **location** (`LOCT_MAST` lookup) and amount, Cr/Dr per
leg. Modes New/Edit/View/Delete(`USER_DELETE`)/Print. _(Confirm field/grid labels + F-keys from
`TR_LOCT_AMT.cs`.)_

## 3. Data model touched
- **Writes:** `LOCT_AMT` (header/detail), derived `AC_DATA` + `ROJ_MEL_DATA`, `REMARK_DATA`,
  `TEMP_BOOK_DATA`. Reads `LOCT_MAST`, `AC_MAST`, `EMP_MAST`.
- **Deletes/reverses:** `AC_DATA, LOCT_AMT, REMARK_DATA, ROJ_MEL_DATA, TEMP_BOOK_DATA` + `DELETE_DATA`.
  `src:` catalog `forms/TR_LOCT_AMT.md`; `TR_LOCT_AMT.cs#L3471-L3487`.
- ⚠ No `02_Data_Model/tables/LOCT_AMT.md` reference exists yet — generate it from the golden master.

## 4. Business logic & calculations (with code)
Posting is centralized in `Ac_Ledr.Loct_Amt_Ledr(book, vchNo)` (`src: Ac_Ledr.cs#L1987`), following
the same `INSERT INTO AC_DATA … SELECT … FROM LOCT_AMT … JOIN BOOK_DETL` pattern as `Contra_Ledr`:
balanced **Dr destination-location / Cr source-location** legs for the transfer amount, `IT_TYPE='A'`.
Web model (to build):
```ts
// model on finance.ts postContra — Dr toLoctAc · Cr fromLoctAc, header → LOCT_AMT, bookName 'LOCT'
const ledger = buildTransferLedger(key, 'JV', toLoctAc, fromLoctAc, amount); assertBalanced(ledger);
```
Money 2 dp HALF-UP.

## 5. Save sequence — as TR_CONTRA §5: guards → delete prior → write `LOCT_AMT` → `DELETE AC_DATA`+`Loct_Amt_Ledr` → `DELETE ROJ_MEL_DATA`+rojmel → remark. `src: TR_LOCT_AMT.cs#L3137-L3322`.
## 6. Delete / reverse — reverse `LOCT_AMT, AC_DATA, ROJ_MEL_DATA, REMARK_DATA, TEMP_BOOK_DATA` + `DELETE_DATA`; `USER_DELETE`; period-lock guarded.

## 7. API contract
(To define) `POST /txn/loct` `{ scope, fromLoct, toLoct, amount, vchDate? }` → `201 { vchNo }`;
`DELETE /txn/loct/:vchNo`. Errors as `postContra`.

## 8. Validation rules
Source ≠ destination location; amount > 0; balanced; period open; company type ≠ B; rights. `req: 17.1/17.3`.

## 9. Parity criteria
`LOCT_AMT` rows + `AC_DATA` legs (Dr dest-loc / Cr src-loc, ΣCr=ΣDr) + day-book match desktop;
delete reverses all + `DELETE_DATA`; trial balance per location nets to zero.

## 10. Variants & edge cases
Multi-location companies only (single-location tenants never use this); interacts with
multitenancy `LC_CODE` scoping (see [`01_Architecture/multitenancy-scoping.md`](../../01_Architecture/multitenancy-scoping.md)).

## 11. Open questions / risks
- **Read `Loct_Amt_Ledr` (`Ac_Ledr.cs#L1987`) in full** to capture the exact leg shape (which
  account each location maps to via `LOCT_MAST`/`BOOK_DETL`) before building.
- **Generate the `LOCT_AMT` table reference** (`02_Data_Model/tables/LOCT_AMT.md`) — not yet present.
- Confirm how location accounts are represented in `AC_MAST` vs `LOCT_MAST` for the web account map.
- Unbuilt in `web/` — no reference implementation to diff against; needs a golden-master fixture.
