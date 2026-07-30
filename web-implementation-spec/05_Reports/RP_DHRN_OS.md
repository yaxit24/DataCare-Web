# RP_DHRN_OS — Pledge (Dhrn) outstanding (field spec)

```
Report: RP_DHRN_OS  ·  .rpt: unified/reports/DhrnOsLetter.rpt (+ DharnDue / DhrnReceivedSumm)  ·  Domain: Dhrn (pledge-loan)
Desktop form: RP_DHRN_OS.cs → builds REPORT_DATA scratch table (reads DHRN_ISU_DATA, DHRN_REC_DATA, DHRN_ISU_DETL, RATE_MAST, AC_MAST)
Web target: dhrnOutstandingList() // src reports.ts ; outstanding() // src dhrn.ts#L333
Routes: GET /reports/dhrn-outstanding · GET /dhrn/:isuNo/outstanding  // src txn.ts#L436,L230
Status: 📋 SPEC · 🟩 BUILT  ·  Parity: 06_Parity/reports.md
Reference depth: 03_Modules/6_... (Dhrn module)
```

## 1. Purpose
Open pledge-loans outstanding: per issued loan, the principal advanced minus receipts = the amount still
owed, with the borrower and interest rate. The recovery worklist and the basis for the customer
outstanding letter (`DhrnOsLetter`) and overdue list (`DharnDue`).

## 2. Parameters / filters
| Param | Source | Required | Notes |
|---|---|---|---|
| `coCode` | session/query | ✓ | tenant company |
| `coYear` | query | — | `coParams` scope (// src reports.ts) |
| `isuNo` | path (single-loan) | — | `GET /dhrn/:isuNo/outstanding` for one loan |

## 3. Dataset query (tables + scope)
**Tables:** `DHRN_ISU_DATA` (loan issue) with a correlated Σ from `DHRN_REC_DATA` (receipts). Open =
`principal − Σreceipts > 0`.
```sql
-- dhrnOutstandingList  // src reports.ts
SELECT i."VCH_NO", i."AC_CODE", i."AC_NAME" AS party,
       NN(i."DHRN_AMT") AS principal, NN(i."INT_PRC") AS "intPct",
       NN(i."DHRN_AMT")
         - coalesce((SELECT sum(NN(r."DHRN_REC_AMT")) FROM "DHRN_REC_DATA" r
                       WHERE r."ISU_NO"::text=i."VCH_NO"::text AND r."CO_CODE"=i."CO_CODE"),0) AS outstanding
FROM "DHRN_ISU_DATA" i WHERE i."CO_CODE"=$1 [AND i."CO_YEAR"=$2]
ORDER BY i."VCH_NO";
-- JS: keep rows where outstanding > 0.005
-- single loan  // src dhrn.ts outstanding(): principal − Σ DHRN_REC_AMT for ISU_NO
```
> The desktop `RP_DHRN_OS.cs` writes `REPORT_DATA` then Crystal reads it (// RP_DHRN_OS.md L3460/L3462);
> the web computes the same principal−receipts on the fly. **Outstanding parity is the explicit DoD**
> (// src dhrn.ts comment "desktop OS-report parity").

## 4. Column / field list (from `all_rpt_fields.txt`)
| Web col | `.rpt`/source field | all_rpt_fields | Type |
|---|---|---|---|
| vchNo / loan no | `VCH_NO` / `DHIRAN_NO` | #L698 / #L178 | string |
| acCode | `AC_CODE` | #L8 | string |
| party | `AC_NAME` | #L29 | string |
| principal | `DHRN_AMT` (loan amount) | (dict: DHRN_*) | money |
| intPct | `INT_PRC` | (dict: INT_PRC) | % |
| outstanding | principal − Σ`DHRN_REC_AMT` | — | money (derived) |
| interest fields | `INT_DAYS` / `INT_FINE` / `INT_PRC_FINE` | #L251 / #L252 / #L253 | for DhrnIntRec |
| address (letter) | `AC_AREA` / `AC_CITY` / `AC_MOBILE` | #L6 / #L7 / #L28 | string |
Source tokens: `DHIRAN_NO`#L178, plus loan tables `DHRN_ISU_DATA`/`DHRN_REC_DATA`/`DHRN_ISU_DETL` (read
by `RP_DHRN_OS`), `RATE_MAST` (metal value of pledged item), `REPORT_DATA` (desktop scratch).

## 5. Grouping / totals
Flat list of open loans, ordered by `VCH_NO`. Footer = `count` + Σ`outstanding` (2 dp). Loans fully
repaid are dropped (`outstanding > 0.005`). Empty scope → empty list.

## 6. Web dataset-builder mapping + parity
- **Builders:** `dhrnOutstandingList` (all open loans), `outstanding(isuNo)` (single).
- **Parity:** (1) the open-loan set + per-loan `outstanding` equal the desktop OS report; (2) principal
  and receipt sums match `DHRN_ISU_DATA`/`DHRN_REC_DATA`; (3) the `ISU_NO`↔`VCH_NO` linkage is text-cast
  on both sides (// src). This is the canonical pledge-recovery figure.

## 7. Open questions / risks
- **Interest accrual flagged:** `DhrnOsLetter`/`DharnDue` may show accrued interest (`INT_DAYS`×`INT_PRC`)
  to date; `dhrnOutstandingList` returns principal-outstanding only (no time-based interest). Add an
  interest-to-date column (`INT_PRC_FINE`#L253 etc.) for `DhrnIntRec`/overdue parity.
- `DharnDue` (overdue) needs a due-date/aging rule not yet present — **flag** an aging variant.
- Confirm `DHRN_AMT`/`INT_PRC` exact column names vs the live schema (dictionary shows the family but the
  builder reads `DHRN_AMT`/`INT_PRC`/`DHRN_REC_AMT`) — verify against `DHRN_ISU_DATA` table ref.
