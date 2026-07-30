# PurcReport — Purchase register (field spec)

```
Report: PurcReport  ·  .rpt: unified/reports/PurcReport.rpt  ·  Domain: Purchase  ·  Type: read-only register
Web target: purchaseRegister()  // src apps/api/src/modules/reports/reports.ts
Route: GET /reports/purchase-register  // src apps/api/src/routes/txn.ts#L432
Renderer: renderRegisterHtml(title, register, { showGst:true })  // src render.ts
Status: 📋 SPEC · 🟩 BUILT  ·  Parity: 06_Parity/reports.md
```

## 1. Purpose
Period purchase register: one row per purchase bill for the scope and date range — net, input-tax
(CGST/SGST/IGST), gross and outstanding payable — footed to grand totals. Mirror of `SaleReport` on the
buy side; the source for monthly purchase MIS and supplier analysis.

## 2. Parameters / filters
Identical to the sales register: `coCode`(✓), optional `coYear`, `lcCode`, `fromDate`/`toDate`
(`readScope`/`range` // src txn.ts#L67,L430).

## 3. Dataset query (tables + scope)
**Table:** `PR_DATA` (purchase header). **Scope:** `CO_CODE`(+`CO_YEAR`,`LC_CODE`,date); **excludes**
purchase-return book `CO_BOOK <> 'PRT'`. Ordered by `VCH_DATE, VCH_NO`.
```sql
-- // src reports.ts registerFrom() + purchaseRegister()  (excludeBook='PRT')
SELECT "VCH_NO","VCH_DATE","BILL_NO","AC_CODE","AC_NAME" AS party,
       NN("NET_AMT")-NN("DISC_AMT") AS net, NN("TAX_AMT") AS tax,
       NN("CGST_TAX") AS cgst, NN("SGST_TAX") AS sgst, NN("IGST_TAX") AS igst,
       NN("TOT_AMT") AS tot, NN("BILL_OS") AS os
FROM "PR_DATA"
WHERE "CO_CODE"=$1 [AND "CO_YEAR"=…][AND "LC_CODE"=…][AND "VCH_DATE" BETWEEN …]
  AND "CO_BOOK" <> 'PRT'
ORDER BY "VCH_DATE","VCH_NO";
```
> **Note (live schema):** `PR_DATA` has **no `VCH_TYPE`** column; purchase returns are identified by
> **book** (`BOOK_DATA` name contains "return"), see `purchaseReturnRegister` // src reports6.ts. The
> register's `<> 'PRT'` exclusion mirrors the sales `SRT` exclusion; confirm the actual return book
> codes per deployment (035–043 are purchase, 048/049/103 are returns in CO_CODE='01').

## 4. Column / field list (from `all_rpt_fields.txt`)
| Web col | `.rpt` field | all_rpt_fields | Type |
|---|---|---|---|
| vchNo | `VCH_NO` | #L698 | string |
| vchDate | `VCH_DATE` | #L695 | date |
| billNo | `BILL_NO` | #L83 | string |
| acCode | `AC_CODE` (supplier) | #L8 | string |
| party | `AC_NAME` | #L29 | string |
| net | `NET_AMT` − `DISC_AMT` | #L428, #L181 | money |
| tax | `TAX_AMT` | #L646 | money |
| cgst/sgst/igst | `CGST_TAX`/`SGST_TAX`/`IGST_TAX` | #L103/#L558/#L246 | money |
| totAmt | `TOT_AMT` | #L665 | money |
| osAmt | `BILL_OS` | #L84 | money |
Source tokens: `PR_DATA`#L499 (header), `PR_DETL`#L500 (lines). Purchase-specific amounts also present
in the dictionary: `PR_NET_AMT`, `PR_TAX_AMT`, `PR_TOT_AMT`, `PR_ITM_AMT`, `PR_LBR_AMT`, `PR_TDS_AMT`
(used by purchase bill prints, not the register).

## 5. Grouping / totals
Flat register; footer Σ identical shape to sales (`shapeRegister`), 2 dp. Empty scope → "no records".

## 6. Web dataset-builder mapping + parity
- **Builder:** `purchaseRegister(prisma, scope, range)` → `Register`.
- **Siblings:** `monthlyPurchase`, `purchaseByParty`, `purchaseByItem`, `gstInputRegister`
  (// src reports3.ts/reports7.ts/reports10.ts) drill into the same `PR_DATA`/`PR_DETL`/`TAX_DATA`.
- **Parity:** rows = `PR_DATA` for scope minus return book; fields per table above; totals to paisa;
  empty → "no records". Input-GST ties: `gstInputRegister` 2024-07 = 34022.58 = `PR_DATA` July `TAX_AMT`
  (// src reports10.ts live sanity).

## 7. Open questions / risks
- Return-book identification is deployment-specific (no `VCH_TYPE` on `PR_DATA`). **Flagged:** verify the
  `CO_BOOK <> 'PRT'` exclusion against `BOOK_DATA` for each tenant, or switch to the `BOOK_DATA`
  name-based rule used by `purchaseReturnRegister`.
- If `PurcReport.rpt` is line-level, add the `PR_DETL` join (item/`ITM_NWT`/`ITM_FINE`/`PR_LBR_AMT`).
