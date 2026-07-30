# TR_TOUR — Tour Issue / Issue-Receive (stub)

```
Form: TR_TOUR ("Tour Issue" / "Tour IsuRec")  ·  Module: 11_Bullion_Tour_VP  ·  Type: transaction (stock)
Desktop source: unified/src/csharp/DataCareNext/TR_TOUR.cs (258 KB) → APR_DATA / APR_DETL / MAIN_STOCK
Web target: apps/api/src/modules/tour/tour.ts → tourIssue / deleteTour · routes/txn.ts (/tour/issue)
Book: TUR / TOUR (desktop APR_DETL.BOOK_NAME 'EMP ISU')   ·   Status: 📋 SPEC · 🟩 BUILT
```

## Purpose
A salesman takes a tray of goods **out on tour** (approval). This issues the stock to him: a header
row in `APR_DATA`, one `APR_DETL` line per item/tag (`ISU_REC='N'` = not yet sold/returned), and a
**`MAIN_STOCK` out-movement** per line. **No money ledger** — it is a pure inventory movement
(`AC_DATA` posted empty, like a tag issue). The "IsuRec" mode receives the unsold goods back.
The later [`TR_TOUR_SALE`](TR_TOUR_SALE.md) draws these lines down. `// src: TR_TOUR.cs#L1566 (lblBook "Tour Issue"); #L1986 ("Tour IsuRec")`

## Posting / movement (web — `tourIssue`)
```ts
// no money: ledger:{ table:'AC_DATA', lines:[] }  (postVoucherTx still asserts 0=0)
writes: [ {table:'APR_DATA',rows:[header]}, {table:'APR_DETL',rows:detl /* ISU_REC 'N', INOUT 'O' */},
          {table:'MAIN_STOCK',rows: lines /* TR_TYPE 'O', ITM_SIGN '-', full wt/fine */} ]
```
`fine = fineWt ?? netWt × touch / 100` (3 dp). `// web: tour.ts → tourIssue, tourLineFine`

## Tables
**Writes:** `APR_DATA`, `APR_DETL`, `MAIN_STOCK`. **Reverses:** `APR_DATA, APR_DETL, APR_IDTL,
MAIN_STOCK` + `DELETE_DATA` (goods return to stock). `// web: tour.ts → deleteTour`
Refs: [APR_DATA](../../02_Data_Model/tables/APR_DATA.md) · [APR_DETL](../../02_Data_Model/tables/APR_DETL.md).

## API
```ts
// POST /tour/issue  (create) → 201 { vchNo, fine }   { salesmanAc|empCode, vchDate?, lines:[{itCode,tagNo?,pcs?,grossWt?,netWt?,touch?,fineWt?}] }
// DELETE /tour/:vchNo (delete) → { reversed:true }
```

## Parity / DoD
`APR_DATA`+`APR_DETL` rows + `MAIN_STOCK` out-movement match desktop; no `AC_DATA`; salesman on-tour
balance increases by the issued fine; delete restores stock + `DELETE_DATA`.

## Open questions
- **Book-name alignment (build blocker for tour sale):** web `tourIssue` stamps `BOOK_NAME='TOUR'`,
  but the desktop tour chain keys the salesman's stock on `BOOK_NAME='EMP ISU'` (and `'EMP REC'` for
  returns). [`TR_TOUR_SALE`](TR_TOUR_SALE.md) drawdown query filters on `'EMP ISU'` — reconcile the
  book name so issues and sales line up. `// src: TR_TOUR_SALE.cs#L9175`
- `APR_IDTL` (tag/stone sub-detail) is reversed but not written by the web issue — add for tagged tours.
- Confirm the `EMP_CODE` (varchar 3) vs salesman `AC_CODE` mapping; web stores both.
