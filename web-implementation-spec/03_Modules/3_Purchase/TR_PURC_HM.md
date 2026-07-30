# TR_PURC_HM — Hallmark Purchase

```
Form: TR_PURC_HM  ·  Module: 3_Purchase  ·  Type: transaction (posting)  ·  Variant of TR_PURC
Desktop source: unified/src/csharp/DataCareNext/TR_PURC_HM.cs (10,635 lines)
Web target: (reuse purchase.ts engine + HM columns)  ·  Status: 🟦 variant
Evidence: module-map.json forms.TR_PURC_HM
```

> Read [`TR_PURC.md`](TR_PURC.md) first. This stub lists **only the deltas**.

## Variant

A purchase that captures **hallmarking** for the items being bought: the 6-char HUID / hallmark id plus
the hallmarking charge and its tax. It is used when in-stock or freshly-bought tags are sent for / come
back from hallmarking, so it **updates existing tags** rather than generating a brand-new lot.

**Deltas vs `TR_PURC`:**
- **Extra fields:** `PR_DATA.HM_AMT`, `HM_TAX_PRC`, `HM_TAX_AMT` (hallmark charge + its tax) and a
  per-line **HUID/HM id**. These flow into the totals and an extra tax line.
- **Stock footprint is lighter — it UPDATEs, not creates:** `module-map` shows `tablesUpdated = BAR_DETL,
  BAR_IDTL` (the existing tag rows get the hallmark stamp) and **no** `PR_IDTL`, **no** `ITM_LOT_DETL`.
  Inserts only `DELETE_DATA`, `SRNO_MAST`.
- **Reverse set:** `AC_DATA, BAR_DATA, BAR_DETL, BAR_IDTL, DM_DATA, LOT_DETL, MAIN_STOCK, REMARK_DATA,
  ROJ_MEL_DATA, SRNO_MAST, TAG_SET, TAX_DATA, TEMP_BOOK_DATA` + `DELETE_DATA` (`writeOps:29`).
- **Posting & calc unchanged:** same `lineFine`/`computeLine`/`billTotals`, same balanced supplier/
  purchase/input-GST ledger; just add the hallmark charge to taxable and the HM tax line.

**Web mapping:** reuse `createPurchase`; extend `PurchaseLineInput` with `huid?` and the header with
`hmAmount?/hmTaxPct?`, fold the HM charge into `otherAmount`/`taxable`, and write the HM columns onto
`PR_DATA`. Persist `huid` on `PR_DETL` (mirror of `SL_DETL.HM_ID` in the sales hallmark variant).

## Open questions / risks
- Confirm whether HM tax is a separate `TAX_DATA` row or folded into the line GST (golden-master pass).
- Confirm the exact `BAR_DETL`/`BAR_IDTL` columns updated with the HUID stamp.
