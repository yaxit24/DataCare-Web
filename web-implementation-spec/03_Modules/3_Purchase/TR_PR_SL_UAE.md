# TR_PR_SL_UAE — UAE Purchase + Sale (VAT)

```
Form: TR_PR_SL_UAE  ·  Module: 3_Purchase  ·  Type: transaction (posting)  ·  Variant of TR_PURC
Desktop source: unified/src/csharp/DataCareNext/TR_PR_SL_UAE.cs (11,066 lines)
Web target: (reuse purchase.ts + sales.ts engines under a VAT tax profile)  ·  Status: ⬛ variant (unbuilt)
Evidence: module-map.json forms.TR_PR_SL_UAE
```

> Read [`TR_PURC.md`](TR_PURC.md) first. This stub lists **only the deltas**.

## Variant

The UAE-entity combined **purchase + sale** screen (B2B). One form can post either the inward purchase
leg or the outward sale leg, under **VAT** instead of Indian GST. It keeps the full tagged-stock
footprint of `TR_PURC`.

**Deltas vs `TR_PURC`:**
- **Dual posting routine** — branch on direction:
  - Purchase: `Ac_Ledr.B2B_Purc_Ledr(book, vchNo)` + `Ac_Tax.Purc_GST(book, vchNo)`.
  - Sale: `Ac_Ledr.B2B_Sales_Ledr(book, vchNo)` + `Ac_Tax.Sales_GST(book, vchNo)`.
  - `src: TR_PR_SL_UAE.cs#L8436-L8450`.
- **VAT, not CGST/SGST/IGST:** a single tax line at the VAT rate (typically 5%) instead of the
  intra/inter split. The `TAX_DATA` row carries one `TAX_TYPE` (VAT) — **no `gstSplit`**.
- **Currency/locale** is the UAE entity (AED); rounding policy still HALF-UP, amount-2.
- **Stock footprint like `TR_PURC`:** reverse set `AC_DATA, BAR_DATA, BAR_DETL, BAR_IDTL, DM_DATA,
  LOT_DETL, MAIN_STOCK, REMARK_DATA, ROJ_MEL_DATA, TAG_SET, TAX_DATA, TEMP_BOOK_DATA` + `DELETE_DATA`;
  updates `APR_DETL` (`writeOps:24`).

**Web mapping:** drive `createPurchase`/`createSale` with a **VAT tax profile** (`interState`
irrelevant; emit a single VAT `TAX_DATA` line and one input/output-VAT `AC_DATA` leg). Select the
purchase vs sale ledger builder by the screen's direction flag.

## Open questions / risks
- VAT is reverse-charge / zero-rated in some UAE flows — confirm `R_CHARG`/`ZERO_RATED_AMT`/`TAX_FREE_AMT`
  handling on `TAX_DATA` from the golden master.
- Confirm header table: does the form write `PR_DATA` for purchase and `SL_DATA` for sale, or a shared
  header? (Decompiled pass.)
