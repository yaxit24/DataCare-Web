# Gstr_2 — GSTR-2 inward supplies / ITC (field spec)

```
Report: Gstr_2  ·  .rpt: unified/reports/Gstr_2.rpt  ·  Domain: GST
Web target: gstr2Purchase() // src apps/api/src/modules/reports/reports3.ts ; gstInputRegister() // src reports10.ts
Routes: GET /reports/gstr2 · GET /reports/gst-input-register  // src txn.ts#L452,L477
Status: 📋 SPEC · 🟩 BUILT  ·  Parity: 06_Parity/reports.md
```

## 1. Purpose
The GSTR-2 inward-supply (input tax credit) summary: total taxable purchases and the CGST/SGST/IGST
input tax for the period, plus a month-wise ITC register. The buy-side mirror of GSTR-1; feeds the net
GST liability (GSTR-3B).

## 2. Parameters / filters
`coCode`(✓), optional `coYear`, `lcCode` (`coParams` // src reports3.ts). `gstInputRegister` buckets by
month over the scope.

## 3. Dataset query (tables + scope)
**`gstr2Purchase`** — single-row totals over `PR_DATA`:
```sql
-- // src reports3.ts gstr2Purchase()
SELECT sum(NN("NET_AMT")) AS taxable, sum(NN("TAX_AMT")) AS tax,
       sum(NN("CGST_TAX")) AS cgst, sum(NN("SGST_TAX")) AS sgst, sum(NN("IGST_TAX")) AS igst
FROM "PR_DATA" WHERE "CO_CODE"=$1 [AND "CO_YEAR"=$2];
```
**`gstInputRegister`** — month-wise from `TAX_DATA` purchase rows:
```sql
-- // src reports10.ts gstInputRegister()
SELECT to_char("VCH_DATE"::timestamp,'YYYY-MM') AS month,
       sum(NN("NET_AMT")) AS taxable, sum(NN("TAX_AMT")) AS "inputGst", count(*)::int AS entries
FROM "TAX_DATA" WHERE "CO_CODE"=$1 [AND "CO_YEAR"=$2]
  AND "TRAN_TYPE" IN ('P','PR') AND "VCH_DATE" IS NOT NULL
GROUP BY 1 ORDER BY 1;
```
> **Live-schema note (flagged in source):** the desktop spec documents `TRAN_TYPE='PR'` for input GST,
> but the live DB stores **`'P'`** (CO_BOOK='041' PURCHASE, `TAX_SIGN='-'`); `'S'` is output GST. The
> builder matches `IN ('P','PR')` so it is correct either way. `TAX_DATA` stores CGST/SGST as **two rows**
> per voucher, so `inputGst` is the combined CGST+SGST and ties to `PR_DATA.TAX_AMT`.

## 4. Column / field list (from `all_rpt_fields.txt`)
| Web field | source field | all_rpt_fields | Notes |
|---|---|---|---|
| taxable | `NET_AMT` | #L428 | `PR_DATA`#L499 / `TAX_DATA`#L646 |
| tax / inputGst | `TAX_AMT` | #L646 | CGST+SGST combined |
| cgst/sgst/igst | `CGST_TAX`/`SGST_TAX`/`IGST_TAX` | #L103/#L558/#L246 | split |
| tranType | `TRAN_TYPE` | #L678 | 'P'/'PR' = input |
| taxSign | `TAX_SIGN` | #L656 | '−' for input |
| taxCode/ratePct | `TAX_CODE`/`TAX_PRC` | #L647/#L654 | slab |
| reverse-charge | `TAX_RVRS` | #L655 | RCM flag |
| supplier gstin | `AC_GSTNO` | #L17 | from `AC_MAST` |
| month | `VCH_DATE`→YYYY-MM | #L695 | register bucket |

## 5. Grouping / totals
`gstr2Purchase`: one summary row (`rows:[summary]`, `totals=summary`). `gstInputRegister`: per-month
rows + `totals.inputGst`. Empty scope → empty.

## 6. Web dataset-builder mapping + parity
- **Builders:** `gstr2Purchase` (period total), `gstInputRegister` (month-wise ITC).
- **Parity:** (1) taxable/tax = Σ over `PR_DATA`/`TAX_DATA` input rows for scope; (2) CGST/SGST/IGST split
  matches; (3) `inputGst` ties to `monthlyPurchase` `taxValue` and to `PR_DATA.TAX_AMT`. Live (CO_CODE='01'):
  2024-07 inputGst 34,022.58 = monthlyPurchase 2024-07 taxValue 34,022.58 (// src reports10.ts sanity).

## 7. Open questions / risks
- `TRAN_TYPE` marker is deployment-variable ('P' vs 'PR') — **flagged**, handled by `IN ('P','PR')`.
- GSTR-2 invoice-level detail (per-supplier, per-invoice) is **not** built — only summary + month
  register. Add an invoice-level dataset (`PR_DATA` ⋈ `AC_MAST`) if the `.rpt` is invoice-level. **Flag.**
- The desktop `Gstr_2.rpt` field set should be confirmed against `RP_GST.cs` (reads `TAX_DATA`); the web
  reads `PR_DATA`+`TAX_DATA` — verify they agree on taxable base (two-row vs header).
