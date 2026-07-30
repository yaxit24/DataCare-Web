# MfgLedger — Manufacturing / Karigar ledger (field spec)

```
Report: MfgLedger  ·  .rpt: unified/reports/MfgLedger.rpt  ·  Domain: Manufacturing / Karigar
Desktop form: RP_MFG_LEDR.cs (reads MFG_ISU_REC, AC_MAST, BOOK_DATA)
Web target: karigarBalances() // src reports.ts ; karigarStatement() // src reports4.ts
Routes: GET /reports/karigar-balances · GET /reports/karigar-statement · GET /karigar/:ac/balance  // src txn.ts#L437,L454,L257
Status: 📋 SPEC · 🟩 BUILT (metal balance)  ·  Parity: 06_Parity/reports.md
Reference depth: 03_Modules/5_Manufacturing/README.md
```

## 1. Purpose
The karigar (goldsmith) metal ledger: per karigar/account, the fine metal **issued** to them for
manufacture vs the fine **received** back as finished/return, and the net metal **balance** still in
their hands (plus pcs). The core job-work control — how much gold is out with each smith.

## 2. Parameters / filters
| Param | Source | Required | Notes |
|---|---|---|---|
| `coCode` | session/query | ✓ | tenant company |
| `ac` | path (single-karigar) | — | `GET /karigar/:ac/balance` |
| `coYear`/`lcCode` | query | — | scope |

## 3. Dataset query (tables + scope)
**Table:** `KR_DETL` (karigar issue/receive detail), grouped by `AC_CODE`. Issue vs receive split by
`INOUT_TYPE` ('I' issued out to karigar / 'O' received back).
```sql
-- karigarStatement  // src reports4.ts
SELECT "AC_CODE",
       sum(CASE WHEN "INOUT_TYPE"='I' THEN NN("ITM_FINE") ELSE 0 END) AS issued,
       sum(CASE WHEN "INOUT_TYPE"='O' THEN NN("ITM_FINE") ELSE 0 END) AS received,
       sum(CASE WHEN "INOUT_TYPE"='I' THEN NN("ITM_PCS")
                WHEN "INOUT_TYPE"='O' THEN -NN("ITM_PCS") ELSE 0 END) AS pcs
FROM "KR_DETL" WHERE "CO_CODE"=$1 GROUP BY "AC_CODE" ORDER BY "AC_CODE";
-- balance = issued - received  (fine still with the karigar)
```
> The desktop `RP_MFG_LEDR.cs` reads `MFG_ISU_REC`; the web reads `KR_DETL` (the karigar issue/receive
> detail). These are the same issue/receive movement viewed from the karigar side. **Flagged**: confirm
> `MFG_ISU_REC` vs `KR_DETL` cover the identical movement set, or add an `MFG_ISU_REC`-based variant for
> the manufacturing-ledger (vs karigar-ledger) presentation.

## 4. Column / field list (from `all_rpt_fields.txt`)
| Web col | `.rpt`/source field | all_rpt_fields | Type |
|---|---|---|---|
| acCode (karigar) | `KR_AC_CODE` / `AC_CODE` | #L344 / #L8 | string |
| name | `KR_NAME` / `AC_NAME` | (dict KR_NAME) / #L29 | string |
| issued (fine) | `ITM_FINE` (INOUT 'I') / `KR_FINE` | #L281 / #L351 | fine wt |
| received (fine) | `ITM_FINE` (INOUT 'O') | #L281 | fine wt |
| balance (fine) | issued − received / `KR_TOT_FINE` | #L368 | fine wt (derived) |
| net wt | `KR_NET_WT` | #L360 | weight |
| pcs | `ITM_PCS` | #L299 | number |
| ghat (loss) wt | `KR_GHT_WT` / `ITM_GHT_WT` | #L353 | weight |
| labour | `KR_LBR_AMT` / `KR_LBR_RATE` | #L355 / #L356 | money |
| net amount | `KR_NET_AMT` | (dict KR_NET_AMT) | money |
Source tokens: `MFG_ISU_REC` (desktop ledger source), `KR_DETL`/`KR_DATA` (web source), `INOUT_TYPE`#L—
(I/O), plus the full `KR_*` family in the dictionary (#L344-#L368).

## 5. Grouping / totals
Grouped by karigar `AC_CODE`. Footer = `karigars` count + Σ `balanceFine` (3 dp). Single-karigar route
returns one balance number. Empty scope → "no records".

## 6. Web dataset-builder mapping + parity
- **Builders:** `karigarBalances` (issued/received/balance), `karigarStatement` (+ received col + net pcs),
  `karigarMetalBalance(ac)` (single).
- **Parity:** (1) per-karigar issued/received fine = Σ `KR_DETL.ITM_FINE` by `INOUT_TYPE`; (2) balance =
  issued−received matches the desktop "metal with karigar"; (3) company Σ balance ties. Weight to 3 dp.

## 7. Open questions / risks
- **Source-table parity flagged:** desktop `MfgLedger` reads `MFG_ISU_REC`; web reads `KR_DETL`. Verify
  equivalence (or build the `MFG_ISU_REC` variant) before certifying.
- Labour/ghat/net-amount columns (`KR_LBR_AMT`#L355, `KR_GHT_WT`#L353, `KR_NET_AMT`) are in the desktop
  ledger but **not** in the current builder (fine + pcs only). Add them for full field parity.
- Module 5 build is 🟦 PARTIAL (`MFG_MAST` unseeded, `MFG_ISU_REC` multi-row/lot schema gaps — see
  MASTER_INDEX progress log); this report inherits those gaps.
