# TR_PURC — Curated behavioral spec (golden-master)

Source: `src/csharp/DataCareNext/TR_PURC.cs` + `Ac_Ledr.cs`. Evidence: `../TR_PURC.md`.
Feeds **Task 20 (Purchase)** and parity Req 11. Ledger insert centralized in `Ac_Ledr` (`AC_DATA`).

## Save sequence — header → detail → ledger → stock-in → tax
1. **Voucher no** from `SRNO_MAST` (note: TR_PURC explicitly DELETE+INSERT `SRNO_MAST` at
   L13455/13457 to reserve the next number). (Task 16)
2. **Header** `PR_DATA` (PR_AMT, PR_LBR_AMT, PR_OTH_AMT, PR_TAX_AMT, PR_NET_AMT, PR_TOT_AMT,
   PR_KASAR_AMT, supplier AC_CODE, BILL_NO, VCH_DATE).
3. **Lines** `PR_DETL` (IT_CODE, ITM_GWT/NWT, ITM_TOUCH, **ITM_FINE = NWT×TOUCH/100**, ITM_RATE,
   LBR_*, ITM_AMT) → `PR_IDTL` sub-detail.
4. **Ledger** via `Ac_Ledr` → `AC_DATA`: credit supplier, debit purchase + input-tax; metal fine posted.
5. **Stock-in** — `MAIN_STOCK` increment; create tags/lots: `TAG_SET`, `BAR_DATA`/`BAR_DETL`/`BAR_IDTL`,
   `ITM_LOT_DETL`; new `TOUCH_MAST` entries as needed (L6672+).
6. **Tax** `TAX_DATA` (input tax; intra→CGST/SGST, inter→IGST).

## Line calculations (Req 11.1, 12)
- `ITM_FINE = ITM_NWT × ITM_TOUCH / 100` (fine weight).
- line amount = metal amount (fine × rate or gwt × rate per RATE_TYPE) + labour (`LBR_TYPE`:
  per-gram = nwt×rate; per-piece = pcs×rate; percentage = metal_amt×prc/100; fixed = amt) + other.

## Validations
- Supplier account required; ≥1 line item required (else reject). (Req 11.3)

## Delete / reverse (Req 11.5) — evidence L13880–L13896
One transaction: delete `PR_DATA`,`PR_DETL`,`PR_IDTL`, `AC_DATA`, `TAX_DATA`, **reverse stock-in**
(`MAIN_STOCK`, `BAR_DATA/DETL/IDTL`, `ITM_LOT_DETL`, `LOT_DETL`, `TAG_SET`, `TAG_IMAGE_DATA`),
`ROJ_MEL_DATA`, `DM_DATA`, `REMARK_DATA`, `TEMP_BOOK_DATA`, `SL_PR_DETL`; write `DELETE_DATA` log.
Requires `USER_DELETE`.

## Web mapping notes (Task 20)
- Stock-in + tag/lot creation via stock module (Task 18); reuse posting engine (Task 17) for the
  balanced supplier/purchase/tax ledger; all writes in one DB transaction (Req 5.4).
