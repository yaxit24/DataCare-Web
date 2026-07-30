# TR_VP — VP Parcel (Value-Payable Parcel dispatch) (stub) ⚠️ semantics derived

```
Form: TR_VP ("Vp Parcel")  ·  Module: 11_Bullion_Tour_VP  ·  Type: transaction (posting)
Desktop source: unified/src/csharp/DataCareNext/TR_VP.cs (280 KB) → sale-like footprint + VP charge
Web target: NEW (not built)   ·   Status: 📋 SPEC · ⬛ UNBUILT
Evidence: form catalog project-memory/catalogs/forms/TR_VP.md
```

> ⚠️ **UNCERTAIN — derived from the decompiled source; confirm before building. Do NOT invent the
> exact accounting.** The labels and column usage strongly indicate **VP = Value-Payable Parcel
> (VPP)** — the India-Post *Value Payable Post* cash-on-delivery shipment of jewellery: goods are
> dispatched to a remote buyer, the post office collects the value on delivery and remits it to the
> jeweller. The settlement (money received / parcel returned) is handled by [`TR_VP_ADJ`](TR_VP_ADJ.md).

## Evidence for the interpretation
- Caption `lblBook.Text = "Vp Parcel"`; field labels **"Vp Charge"**, **"Vp Ins Amt"** (VP insurance
  amount), **"Vp Charg Type"**; `VP_AMT_TYPE` flag (`'P'` = percentage). `// src: TR_VP.cs#L2200, L2655-L2699, L5224, L5665`
- Sale-like table footprint (`SL_IDTL`, `SL_PR_DETL`, `SL_ORD_ADJ`, `MAIN_STOCK` out, `AC_DATA`,
  `RATE_CUT_*`, `DM_DATA`): goods leave stock and a receivable is booked against the parcel/customer.
  `// src: form catalog TR_VP.md (DELETE set)`

## Likely behaviour (to confirm)
A VP dispatch = a **sale shipped on VPP terms**: compute the goods like a sale, add a **VP charge**
(postage + insurance, `VP_AMT_TYPE` percentage or fixed), move stock out, and book the customer/parcel
as a receivable until the post office remits (settled in `TR_VP_ADJ`). GST likely applies on the goods.

## Tables (footprint, from catalog)
**Deletes/reverses:** `AC_DATA, DM_DATA, MAIN_STOCK, RATE_CUT_DATA/ISU/ISU_REC, ROJ_MEL_DATA, SL_IDTL,
SL_ORD_ADJ, SL_PR_DETL, TEMP_BOOK_DATA` + `DELETE_DATA`. Refs: [AC_DATA](../../02_Data_Model/tables/AC_DATA.md).

## Parity / DoD (once confirmed)
Goods + VP charge + GST post a balanced `AC_DATA`; stock out; receivable against the parcel; delete
reverses + `DELETE_DATA`. Crystal `VpIsuRpt.rpt`.

## Open questions (must resolve before build)
- Confirm **VP = Value-Payable Parcel** and the precise ledger: is the receivable booked to the
  *customer*, a *VP/parcel-in-transit* control account, or *India Post*? How is the **VP charge**
  (`VP_AMT_TYPE 'P'`/fixed) posted — income, recovered cost, or added to the bill?
- Confirm GST treatment of goods vs the VP/postage charge.
- Map the relationship to `TR_VP_ADJ` (settlement on delivery / return-to-sender).
- Requires a Docker golden-master pass on `TR_VP.cs` + `VpIsuRpt.rpt`/`VpAdjustBill.rpt`.
