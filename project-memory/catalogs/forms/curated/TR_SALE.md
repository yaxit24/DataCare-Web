# TR_SALE — Curated behavioral spec (golden-master)

Source: `src/csharp/DataCareNext/TR_SALE.cs` (889 KB) + posting helper `Ac_Ledr.cs`.
Evidence: auto-extracted op sequence in `../TR_SALE.md`; AC_DATA/SL_DATA column lists from `data-model.json`.
Feeds **Task 19 (Sales)** and parity Req 10. Posting is centralized: ledger rows are inserted by
`Ac_Ledr.cs` (`INSERT INTO AC_DATA (...CR_AMT,DR_AMT,FINE_WT,FINE_RATE,LEDR_KEY...)`), not inline in TR_SALE.

## Save sequence (create/edit) — header → detail → ledger → stock → tax → ancillary
Edit is implemented as **delete-then-repost** (reverse the prior voucher, then write fresh). Order:
1. **Voucher no** — allocate from `SRNO_MAST` for (CO_CODE,LC_CODE,CO_YEAR,CO_BOOK). (Task 16)
2. **Header** — `SL_DATA` (NET_AMT, DISC_PRC/AMT, TAX_CODE/PRC/AMT, ROF_AMT, TOT_AMT, ADV_AMT,
   CASH/CARD/CHQ/SCHM_AMT, BILL_OS, AC_CODE, AC_NAME, BILL_NO, HD_VCH_NO, VCH_DATE/TIME).
3. **Lines** — `SL_DETL` (per item: IT_CODE, ITM_GWT/NWT, ITM_TOUCH, ITM_FINE, LBR_*, ITM_RATE,
   ITM_AMT, ITM_CGST_AMT/SGST_AMT/IGST_AMT, TAG_NO) → **sub-detail** `SL_IDTL`.
4. **Ledger (double-entry)** via `Ac_Ledr` → `AC_DATA`: debit customer (AC_CODE), credit sales +
   credit tax ledgers; metal (FINE_WT/FINE_RATE) posted alongside amount. Dr total == Cr total.
5. **Stock-out** — issue tags: `MAIN_STOCK` decrement + `TAG_STOCK` mark issued (tag unavailable).
6. **Tax** — `TAX_DATA` (CGST/SGST for intra-state; IGST for inter-state — see GST rule below).
7. **Ancillary** — `BILL_OS_DATA` (outstanding), `POINT_DATA`/`POINT_MEMB` (loyalty),
   `UPI_DATA`/`CARD_DATA` (split receipts), `ROJ_MEL_DATA` (day-book/rojmel), `CRNT_DATA`, `SL_ORD_ADJ`
   (order advance adjust), `SL_PR_DETL` (purchase-fixing link).

## GST split (Req 10.4/10.5, 18.2/18.3)
- Taxable = net amount after discount. Rate from `TAX_MAST` (item GST rate).
- **Intra-state** (customer state == company state): split equally → CGST = SGST = tax/2, IGST = 0.
- **Inter-state**: IGST = full tax; CGST = SGST = 0.
- Columns: `SL_DETL.ITM_CGST_AMT/ITM_SGST_AMT/ITM_IGST_AMT`, header `SL_DATA.TAX_AMT`, `TAX_DATA`.

## Validations before save (Req 10.6/10.7) — confirm exact strings when implementing
- Customer account required (no AC_CODE → reject).
- At least one line item required (empty grid → reject).
- Tag must exist & be in stock for active CO/LC (else "tag not found" / "not available"). (Req 10.2, 14.5)
- Cash receipt over cash-limit → require PAN (shared rule, see TR finance forms). (Req 17.2)

## Delete / reverse (Req 10.10) — evidence L16332–L16386
Within one transaction: delete `SL_DATA`,`SL_DETL`,`SL_IDTL`, `AC_DATA` (ledger), `TAX_DATA`,
`MAIN_STOCK` (and **restore** issued tags → `TAG_STOCK` available again), `BILL_OS_DATA`,
`POINT_DATA`, `UPI_DATA`, `CARD_DATA`, `ROJ_MEL_DATA`, `DM_DATA`, `CRNT_DATA`, `LOT_DETL`,
`SL_ORD_ADJ`, `AD_ADJ`, `REMARK_DATA`, `TEMP_BOOK_DATA`; then **write `DELETE_DATA`** (deletion log).
Requires `USER_DELETE` right.

## Web mapping notes (Task 19)
- Replace delete-then-repost with an explicit transactional "reverse + repost" in the posting engine
  (Task 17), all within one DB transaction (Req 5.4/5.5).
- Tag issue/restore via stock module (Task 18); voucher no via numbering (Task 16); calc via core (Task 15).
