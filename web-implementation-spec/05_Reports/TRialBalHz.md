# TRialBalHz — Trial balance (horizontal) (field spec)

```
Report: TRialBalHz  ·  .rpt: unified/reports/TRialBalHz.rpt  ·  Domain: Accounting/Ledger
Web target: trialBalance() // src accounting.ts#L84 ; trialBalanceFull() // src reports8.ts (named, AC_MAST)
Routes: GET /reports/trial-balance · GET /reports/trial-balance-full  // src txn.ts#L434,L471
Status: 📋 SPEC · 🟩 BUILT  ·  Parity: 06_Parity/reports.md
Reference depth: 03_Modules/8_Accounting/ (Trial Balance deep-dive)
```

## 1. Purpose
The horizontal trial balance: every ledger account with its Σ debit and Σ credit (and net balance) for
the company/year, footed to grand Dr/Cr. The control report for the books and the entry point to final
accounts (`BalanceHz`, `ProfitLossHz`).

## 2. Parameters / filters
| Param | Source | Required | Notes |
|---|---|---|---|
| `coCode` | session/query | ✓ | tenant company |
| `coYear` | query | — | financial-year scope |
| `lcCode` | query | — | location scope (optional) |
(No date range — trial balance is year-cumulative.)

## 3. Dataset query (tables + scope)
**Table:** `AC_DATA`, grouped by `AC_CODE`. `trialBalanceFull` adds the account name from `AC_MAST`.
```sql
-- compact  // src accounting.ts trialBalance()
SELECT "AC_CODE", coalesce(sum("DR_AMT"),0) AS dr, coalesce(sum("CR_AMT"),0) AS cr
FROM "AC_DATA" WHERE <scope> GROUP BY "AC_CODE" ORDER BY "AC_CODE";

-- named, ordered by |balance|  // src reports8.ts trialBalanceFull()
SELECT d."AC_CODE",
       (SELECT m."AC_NAME" FROM "AC_MAST" m
          WHERE m."AC_CODE"=d."AC_CODE" AND m."CO_CODE"=d."CO_CODE" LIMIT 1) AS name,
       sum(NN(d."DR_AMT")) AS dr, sum(NN(d."CR_AMT")) AS cr
FROM "AC_DATA" d WHERE d."CO_CODE"=$1 [AND d."CO_YEAR"=$2]
GROUP BY d."AC_CODE", d."CO_CODE"
ORDER BY abs(sum(NN(d."DR_AMT")) - sum(NN(d."CR_AMT"))) DESC;
```

## 4. Column / field list (from `all_rpt_fields.txt`)
| Web col | `.rpt` field | all_rpt_fields | Type |
|---|---|---|---|
| acCode | `AC_CODE` | #L8 | string |
| name | `AC_NAME` (from `AC_MAST`#L24) | #L29 | string |
| dr | Σ `DR_AMT` | #L195 | money |
| cr | Σ `CR_AMT` | #L156 | money |
| balance | `dr − cr` (derived) | — | money |
Group/heading variants (`AcGroupRpt`) add `AC_GROUP`#? / `AC_GR`/`AC_GR_NAME` (the account-group master;
`groupSummary` joins `AC_DATA→AC_MAST.AC_GR→AC_GROUP.AC_GR_NAME` // src reports3.ts).

## 5. Grouping / totals
`trialBalance`: per-`AC_CODE`. `groupSummary`: per account-group. Footer = grand Σdr / Σcr +
account/group count. Money 2 dp. Empty scope → "no records".

## 6. Web dataset-builder mapping + parity
- **Builders:** `trialBalance` (compact, name-less), `trialBalanceFull` (named, |balance|-ordered),
  `groupSummary` (group-wise). All re-exported through `reports.ts`.
- **Parity (presentation, not Σdr=Σcr):** a jeweller holds **closing stock outside the ledger**, so
  `AC_DATA` does not tie; the residual `Σcr−Σdr` is the off-ledger stock/trading figure
  (// src reports8.ts docstring + reports.ts balanceSheet). Live (CO_CODE='01'): 300 accounts,
  Σdr 55,180,589.47, Σcr 56,302,194.65, gap 1,121,605.18 (= closing stock); top account 000858
  balance −8,781,900.00. **DoD = web reproduces the desktop per-account dr/cr and the same residual**,
  not a forced zero gap.

## 7. Open questions / risks
- `ProfitLossHz`/`BalanceHz` need the off-ledger closing-stock injection (`balanceSheet` derives it as
  the balancing figure // src reports.ts). Exact per-item stock valuation feeding the P&L is **flagged**
  as a later enhancement.
- Confirm desktop `TRialBalHz` row ordering (by code vs by group) and whether it nets to a single
  balance column or shows both Dr/Cr columns — the web exposes both `dr`,`cr`,`balance`.
