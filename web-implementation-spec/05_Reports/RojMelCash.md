# RojMelCash — Cash day-book / cash-book (field spec)

```
Report: RojMelCash  ·  .rpt: unified/reports/RojMelCash.rpt  ·  Domain: Rojmel / Day-book
Desktop form: RP_ROJMEL → builds LEDR_AC_DATA/ROJMEL_BAL scratch tables (reads CASH_DATA, CARD_DATA, UPI_DATA, AC_DATA, ROJ_MEL_DATA …)
Web target: cashBook() // src reports2.ts ; cashDaySummary() // src reports8.ts ; dayBook() // src reports.ts
Routes: GET /reports/cash-book · GET /reports/cash-day-summary · GET /reports/day-book  // src txn.ts#L446,L473,L433
Status: 📋 SPEC · 🟩 BUILT  ·  Parity: 06_Parity/reports.md
```

## 1. Purpose
The cash (rojmel) book: every cash/bank movement for the day/period with Dr (in) and Cr (out) and the
running/day balance. The shopkeeper's end-of-day reconciliation. `RojMel.rpt` is the full day-book (all
ledgers); `RojMelCash.rpt` is the cash/bank subset.

## 2. Parameters / filters
| Param | Source | Required | Notes |
|---|---|---|---|
| `coCode` | session/query | ✓ | tenant company |
| `coYear`/`lcCode` | query | — | scope |
| `fromDate`/`toDate` | query | — | `dayBook` range (`whereScopeDate`); `cashBook`/`cashDaySummary` are period-cumulative |

## 3. Dataset query (tables + scope)
**Source:** `AC_DATA`, filtered to **cash/bank accounts** (account code matches CASH/BANK, or its
`AC_MAST.AC_NAME` contains CASH/BANK). `cashBook` = per-entry; `cashDaySummary` = per-day in/out/net.
```sql
-- cashDaySummary  // src reports8.ts
SELECT d."VCH_DATE" AS date, sum(NN(d."DR_AMT")) AS "inAmt", sum(NN(d."CR_AMT")) AS "outAmt"
FROM "AC_DATA" d
WHERE d."CO_CODE"=$1
  AND ( d."AC_CODE" ILIKE '%CASH%' OR d."AC_CODE" ILIKE '%BANK%'
        OR EXISTS (SELECT 1 FROM "AC_MAST" m
                     WHERE m."AC_CODE"=d."AC_CODE" AND m."CO_CODE"=d."CO_CODE"
                       AND (m."AC_NAME" ILIKE '%CASH%' OR m."AC_NAME" ILIKE '%BANK%')))
GROUP BY d."VCH_DATE" ORDER BY d."VCH_DATE";
-- cashBook adds per-row particulars (resolved AC_MAST.AC_NAME) and CO_BOOK/VCH_NO voucher id.
-- dayBook (RojMel full) = all AC_DATA legs for the date range, Dr/Cr footed + balanced flag.
```
> The desktop `RP_ROJMEL.cs` aggregates tender tables (`CASH_DATA`, `CARD_DATA`, `UPI_DATA`,
> `RATE_CUT_DATA`, `ROJ_MEL_DATA`) into `ROJMEL_BAL` (// RP_ROJMEL.md L5840). The web reads the
> **posted ledger** `AC_DATA` (where tender already landed as Dr cash/bank legs at sale save) — the
> cash position is therefore reconstructed from the ledger, not a scratch balance table.

## 4. Column / field list (from `all_rpt_fields.txt`)
| Web col | `.rpt`/source field | all_rpt_fields | Type |
|---|---|---|---|
| date | `VCH_DATE` | #L695 | date |
| voucher | `CO_BOOK`/`VCH_NO` | #L134/#L698 | string |
| particulars | `AC_NAME` (from `AC_MAST`) | #L29 | string |
| dr / inAmt | `DR_AMT` | #L195 | money |
| cr / outAmt | `CR_AMT` | #L156 | money |
| net | `inAmt − outAmt` (derived) | — | money |
Tender fields the desktop rojmel also shows (in dictionary, used by `RojMelCrDr`/full rojmel):
`CASH_AMT`#L101, `CARD_AMT`#L99, `UPI_AMT`#L685, `CHQ_AMT`#L109, `OP_AMT`#L447 (opening).

## 5. Grouping / totals
`cashDaySummary`: per-day rows + `totals.inAmt`/`.outAmt` and day count. `dayBook`: flat legs +
`totals { dr, cr, balanced: dr===cr }`. Money 2 dp. Empty scope → "no records".

## 6. Web dataset-builder mapping + parity
- **Builders:** `cashBook` (cash/bank entries), `cashDaySummary` (day in/out/net), `dayBook` (full rojmel).
- **Parity:** (1) cash/bank movement set equals the desktop cash day-book for the scope; (2) per-day in/out
  match; (3) day-book Dr/Cr foot and the `balanced` flag holds for posted vouchers. Live (CO_CODE='01'):
  cashDaySummary 120 days, Σin 25,069,253.24 / Σout 17,364,838.72; first day 2024-03-31 in 9,669,228.10 /
  out 3,109,303.88 / net 6,559,924.22 (// src reports8.ts sanity).

## 7. Open questions / risks
- **Cash/bank detection is heuristic** (name/code ILIKE CASH/BANK). **Flagged:** key off the account-group
  master (`AC_GROUP`/`AC_GR`) instead of name-matching for robust classification.
- Opening cash balance (`OP_AMT`/`ROJMEL_BAL`) is not carried as a separate opening row — the web sums
  ledger movement only. Add an opening-balance row to match the desktop rojmel header. **Flag.**
- `RojMelCrDr`/`RojMelGr`/`RojMelItem` pivots map to `dayBook`/`groupSummary`/`salesByItem` but are not
  field-verified against their `.rpt` — confirm columns.
