# TR_VP_ADJ — VP Adjust (parcel settlement) (stub) ⚠️ semantics derived

```
Form: TR_VP_ADJ ("Vp Adjust Book")  ·  Module: 11_Bullion_Tour_VP  ·  Type: transaction (posting)
Desktop source: unified/src/csharp/DataCareNext/TR_VP_ADJ.cs (118 KB)
Web target: NEW (not built)   ·   Status: 📋 SPEC · ⬛ UNBUILT
```

> ⚠️ **UNCERTAIN — derived; confirm before building.** Settlement counterpart of [`TR_VP`](TR_VP.md).
> When a Value-Payable Parcel is **delivered** (the post office remits the collected value) or
> **returned to sender**, this form clears the open VP/parcel receivable. Caption
> `lblBook.Text = "Vp Adjust Book"`. `// src: TR_VP_ADJ.cs#L1122`

## Likely behaviour (to confirm)
- **Delivered & paid:** Dr cash/bank (remittance, net of post-office charges) · Cr the VP/parcel
  receivable opened by `TR_VP`; any deducted VP/postage charge → expense.
- **Returned (RTS):** reverse the dispatch — goods back into `MAIN_STOCK`, clear the receivable.

## Tables (to confirm)
A balanced `AC_DATA` settlement keyed to the original VP voucher; possibly `MAIN_STOCK` restore on
return. Ref: [AC_DATA](../../02_Data_Model/tables/AC_DATA.md).

## Parity / DoD (once confirmed)
The open VP receivable from `TR_VP` is cleared to zero on full settlement; partial / charge deductions
handled; delete reverses + `DELETE_DATA`. Crystal `VpAdjustBill.rpt`.

## Open questions (must resolve before build)
- Confirm the exact link key from the adjust voucher back to the dispatch (`TR_VP`) and the precise
  legs for **delivered-paid** vs **returned-to-sender**, including post-office charge handling.
- Confirm whether multiple parcels settle in one adjust voucher (batch remittance).
- Requires a Docker golden-master pass on `TR_VP_ADJ.cs`.
