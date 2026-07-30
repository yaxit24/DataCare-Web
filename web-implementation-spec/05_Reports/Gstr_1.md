# Gstr_1 — GSTR-1 outward supplies (field spec)

```
Report: Gstr_1  ·  .rpt: unified/reports/Gstr_1.rpt  ·  Domain: GST
Desktop form: RP_GST (reads AC_MAST, TAX_DATA, BOOK_DATA, LOCT_MAST) ; posting from Ac_Tax.Sales_GST
Web target: gstr1() // src apps/api/src/modules/gst/gst.ts#L133 (re-exported by reports.ts)
Status: 📋 SPEC · 🟩 BUILT (HANDOFF: gstr1 11/11)  ·  Parity: 06_Parity/reports.md
Reference depth: 03_Modules/9_GST_EInvoice/ (RP_GST deep-dive)
```

## 1. Purpose
The GSTR-1 outward-supply return: sales invoices classified into **B2B / B2CL / B2CS** and an **HSN**
summary, for the GST filing period. Drives the government return upload and the GST audit trail.

## 2. Parameters / filters
| Param | Source | Required | Notes |
|---|---|---|---|
| `coCode` | session/query | ✓ | tenant company (the supplier GSTIN) |
| `coYear`/`lcCode` | query | — | scope (`scopeSql` // src gst.ts) |
| `threshold` | opt (default `B2CL_THRESHOLD`) | — | B2CL inter-state invoice-value cut-off |
| `hsnMap` | opt | — | IT_CODE→HSN override map |

## 3. Dataset query (tables + scope)
**Tables:** `SL_DATA` ⋈ `AC_MAST` (buyer GSTIN/state) for invoices; `SL_DETL` grouped by `IT_CODE` for
HSN. Scope `CO_CODE`(+`CO_YEAR`,`LC_CODE`).
```sql
-- invoices  // src gst.ts gstr1()
SELECT S."VCH_NO", S."AC_CODE", M."AC_GSTNO" AS gstin, M."AC_STATE" AS state,
       NN(S."IGST_TAX") AS igst, NN(S."CGST_TAX") AS cgst, NN(S."SGST_TAX") AS sgst,
       NN(S."TOT_AMT") AS tot, NN(S."NET_AMT")-NN(S."DISC_AMT") AS taxable, NN(S."TAX_PRC") AS rate
FROM "SL_DATA" S LEFT JOIN "AC_MAST" M ON M."CO_CODE"=S."CO_CODE" AND M."AC_CODE"=S."AC_CODE"
WHERE S."CO_CODE"=$1 [AND S."LC_CODE"=…][AND S."CO_YEAR"=…];
-- HSN detail
SELECT D."IT_CODE", sum(NN(D."ITM_PCS")) AS qty, sum(NN(D."NET_AMT")) AS taxable,
       sum(NN(D."ITM_CGST_AMT")) AS cgst, sum(NN(D."ITM_SGST_AMT")) AS sgst, sum(NN(D."ITM_IGST_AMT")) AS igst
FROM "SL_DETL" D WHERE D."CO_CODE"=$1 GROUP BY D."IT_CODE";
```
**Classification** (`classifyInvoice`): has buyer GSTIN → **B2B**; else inter-state (`IGST>0`) and
invoice value > threshold → **B2CL**; else **B2CS** (summarised by rate/state).

## 4. Column / field list (from `all_rpt_fields.txt`)
| Web field | `.rpt`/source field | all_rpt_fields | Section |
|---|---|---|---|
| vchNo | `VCH_NO` | #L698 | all |
| acCode | `AC_CODE` | #L8 | all |
| gstin | `AC_GSTNO` | #L17 | B2B |
| stateCode | `AC_STATE` | #L38 | B2CL/B2CS |
| gstType | `AC_GST_TYPE` | #L18 | classification |
| taxable | `NET_AMT`−`DISC_AMT` | #L428,#L181 | all |
| ratePct | `TAX_PRC` | #L654 | all |
| cgst/sgst/igst | `CGST_TAX`/`SGST_TAX`/`IGST_TAX` | #L103/#L558/#L246 | all |
| invoiceValue | `TOT_AMT` | #L665 | all |
| hsn | `HSN_CODE` | #L244 | HSN |
| qty | `ITM_PCS` | #L299 | HSN |
| line tax | `ITM_CGST_AMT`/`ITM_SGST_AMT`/`ITM_IGST_AMT` | (#L… ITM_*) | HSN |
Posting source: `TAX_DATA`#L646-group (`Ac_Tax.Sales_GST` writes CGST+SGST intra / IGST inter, `TAX_SIGN`#L656, `TRAN_TYPE`#L678='S').

## 5. Grouping / totals
Four datasets: `b2b[]`, `b2cl[]`, `b2cs` (summarised by rate×state), `hsn[]` (by IT_CODE→HSN). Each
carries its own taxable/CGST/SGST/IGST totals. Empty period → empty sections.

## 6. Web dataset-builder mapping + parity
- **Builder:** `gstr1(prisma, scope, {threshold,hsnMap})` → `{ b2b, b2cl, b2cs, hsn }`.
- **Parity:** (1) every `SL_DATA` invoice lands in exactly one of B2B/B2CL/B2CS by the same rule
  (GSTIN → inter-state+threshold → else); (2) taxable/tax per invoice equal `SL_DATA` fields; (3) HSN
  taxable/tax = Σ `SL_DETL` per IT_CODE→HSN; (4) totals tie to the sales register taxable+tax for the
  scope. HANDOFF reports gstr1 11/11 on live data.

## 7. Open questions / risks
- `hsnMap` (IT_CODE→HSN): desktop reads HSN from `ITEM_MAST`/`HSN_CODE`; web takes an override map.
  **Flagged:** wire the default map from the item master so HSN summary is correct without a manual map.
- Returns: GSTR-1 should net credit notes; confirm whether `SL_DETL_RTN`/`CO_BOOK='SRT'` are included as
  CDNR. Current `gstr1` reads `SL_DATA` only — **flag** the credit-note section as pending.
