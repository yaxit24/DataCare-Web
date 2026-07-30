# SaleReport — Sales register (field spec)

```
Report: SaleReport  ·  .rpt: unified/reports/SaleReport.rpt  ·  Domain: Sales  ·  Type: read-only register
Desktop form: RP_* (sales report) → Crystal SaleReport.rpt over SL_DATA
Web target: salesRegister()  // src apps/api/src/modules/reports/reports.ts
Route: GET /reports/sales-register  // src apps/api/src/routes/txn.ts#L431
Renderer: renderRegisterHtml(title, register, { showGst:true })  // src render.ts
Status: 📋 SPEC · 🟩 BUILT (dataset+route+PDF)  ·  Parity: 06_Parity/reports.md
```

## 1. Purpose
Period sales register: one row per sales invoice for the company/year/(location) and date range, with
net, tax (CGST/SGST/IGST split), gross and outstanding, footed to grand totals. The day-to-day "what
did we sell" report and the source grid behind the printed sales summary.

## 2. Parameters / filters
| Param | Source | Required | Notes |
|---|---|---|---|
| `coCode` | session/`?coCode` | ✓ | tenant company (`readScope` // src txn.ts#L67) |
| `coYear` | `?coYear` | — | financial-year scope when set |
| `lcCode` | `?lcCode` | — | location filter only when explicitly chosen (never defaulted) |
| `fromDate`/`toDate` | `?fromDate`,`?toDate` | — | `VCH_DATE` range (`range()` // src txn.ts#L430) |

## 3. Dataset query (tables + scope)
**Table:** `SL_DATA` (sales header). **Scope:** `CO_CODE`(+`CO_YEAR`,`LC_CODE`,`VCH_DATE` range);
**excludes** sales-return vouchers `CO_BOOK <> 'SRT'`. Ordered by `VCH_DATE, VCH_NO`.
```sql
-- // src reports.ts registerFrom() + salesRegister()
SELECT "VCH_NO", "VCH_DATE", "BILL_NO", "AC_CODE", "AC_NAME" AS party,
       NN("NET_AMT")-NN("DISC_AMT") AS net, NN("TAX_AMT") AS tax,
       NN("CGST_TAX") AS cgst, NN("SGST_TAX") AS sgst, NN("IGST_TAX") AS igst,
       NN("TOT_AMT") AS tot, NN("BILL_OS") AS os
FROM "SL_DATA"
WHERE "CO_CODE"=$1 [AND "CO_YEAR"=…][AND "LC_CODE"=…][AND "VCH_DATE" BETWEEN …]
  AND "CO_BOOK" <> 'SRT'
ORDER BY "VCH_DATE","VCH_NO";
-- NN(c) = coalesce(NULLIF(c::text,'')::numeric,0)
```

## 4. Column / field list (from `all_rpt_fields.txt`)
| Web col | `.rpt` field | all_rpt_fields | Type |
|---|---|---|---|
| vchNo | `VCH_NO` | #L698 | string |
| vchDate | `VCH_DATE` | #L695 | date |
| billNo | `BILL_NO` | #L83 | string |
| acCode | `AC_CODE` | #L8 | string |
| party | `AC_NAME` | #L29 | string |
| net | `NET_AMT` − `DISC_AMT` | #L428, #L181 | money |
| tax | `TAX_AMT` | #L646 | money |
| cgst | `CGST_TAX` | #L103 | money |
| sgst | `SGST_TAX` | #L558 | money |
| igst | `IGST_TAX` | #L246 | money |
| totAmt | `TOT_AMT` | #L665 | money |
| osAmt | `BILL_OS` | #L84 | money |
Source table tokens: `SL_DATA`#L580 (header), `SL_DETL`#L583 (lines, for item drill-downs).

## 5. Grouping / totals
No grouping (flat register). Footer = Σ over rows: `netAmt, taxAmt, cgst, sgst, igst, totAmt, osAmt`
(`shapeRegister()` // src reports.ts), money rounded 2 dp. Empty scope → "No records for the selected
period." (`renderRegisterHtml` empty branch).

## 6. Web dataset-builder mapping + parity
- **Builder:** `salesRegister(prisma, scope, range)` → `Register { rows, totals }`.
- **Print:** `renderRegisterHtml('Sales Register', register, {showGst:true})` → `/render/pdf` (right `print`).
- **Parity:** (1) rows = `SL_DATA` for scope **minus** `CO_BOOK='SRT'`; (2) per-row net/tax/GST/total/os
  equal the desktop fields above; (3) footer totals to the paisa; (4) empty scope → "no records".
  Cross-ref the A4 invoice print parity in `03_Modules/2_Sales/TR_SALE.md §9` (190/190 invoices matched).

## 7. Open questions / risks
- The desktop `SaleReport.rpt` may carry per-line columns (item, weight, fine) on a detail band; the
  web register is **header-level**. If the desktop report is line-level, add a `SL_DETL`-joined variant
  (item/`ITM_NWT`#L295/`ITM_FINE`#L281). **Flagged** — confirm band layout from the `.rpt`.
- `DISC_AMT` is subtracted into `net`; confirm desktop shows net-of-discount vs gross-then-discount column.
