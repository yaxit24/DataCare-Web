# TR_OTH_PURC — Other / Non-tagged Purchase

```
Form: TR_OTH_PURC  ·  Module: 3_Purchase  ·  Type: transaction (posting)  ·  Variant of TR_PURC
Desktop source: unified/src/csharp/DataCareNext/TR_OTH_PURC.cs (5,280 lines)
Web target: (reuse purchase.ts ledger/calc; no stock-in)  ·  Status: ⬛ variant (unbuilt)
Evidence: module-map.json forms.TR_OTH_PURC
```

> Read [`TR_PURC.md`](TR_PURC.md) first. This stub lists **only the deltas**.

## Variant

A purchase that does **not** create tagged inventory — e.g. sundry / on-account metal buying, bullion
or expense-style purchases booked through a **payment book**. It is the lightest purchase form: pure
ledger + tax + day-book, no `BAR_*`, no `MAIN_STOCK`, no `PR_*` tag lines.

**Deltas vs `TR_PURC`:**
- **Detail goes to `PAY_DATA`/`PAY_DETL`** (payment book), not `PR_DATA`/`PR_DETL`.
- **No stock/tag tables** at all: no `BAR_DATA/DETL/IDTL`, no `ITM_LOT_DETL`/`LOT_DETL`, no `TAG_SET`,
  no `MAIN_STOCK`, no `DM_DATA`.
- **Posting routine:** `Ac_Ledr.Oth_Purc_Ledr(book, vchNo)` + `Ac_Tax.Oth_Purc_GST(book, vchNo)` +
  `Ac_Tax.Vch_Remark`. `src: TR_OTH_PURC.cs#L3817-L3824`.
- **Reverse set:** `AC_DATA, PAY_DATA, PAY_DETL, REMARK_DATA, ROJ_MEL_DATA, TAX_DATA, TEMP_BOOK_DATA`
  + `DELETE_DATA` (`writeOps:15`). `FormMainBook = DC_Main.CurBookMain` (book chosen at open).
- **Calc unchanged** where weights apply, but typically amount-only (no fine/touch) — the ledger is still
  the balanced **Cr supplier / Dr purchase + input-GST + round-off** mirror.

**Web mapping:** a thin variant of `createPurchase` that skips `createTagTx`, drops the `MAIN_STOCK`/tag
writes, and posts the `AC_DATA` + `TAX_DATA` (+ `BILL_OS_DATA` payable) only. Book/`VCH_TYPE` per the
chosen "other purchase" book.

## Open questions / risks
- Confirm the `PAY_DATA`/`PAY_DETL` column mapping vs `PR_DATA`/`PR_DETL` (different detail shape).
- Confirm which books route here (the form is opened on `CurBookMain`).
