# AcLedger — Account ledger / statement (field spec)

```
Report: AcLedger (+ AcLedgerSelected)  ·  .rpt: unified/reports/AcLedger.rpt  ·  Domain: Accounting/Ledger
Desktop form: RP_LEDR → builds LEDR_AC_DATA/FINE_DATA scratch tables, Crystal AcLedger.rpt reads them
Web target: accountLedger()  // src apps/api/src/modules/accounting/accounting.ts#L105 (re-exported by reports.ts)
Route: GET /reports/account-ledger/:acCode  // src apps/api/src/routes/txn.ts#L435
Status: 📋 SPEC · 🟩 BUILT  ·  Parity: 06_Parity/reports.md
```

## 1. Purpose
The statement of one account (customer/supplier/cash/bank/expense): opening balance + every voucher
movement in the period with a **running balance**, closing balance at the end. The single most-used
accounting report (party khata).

## 2. Parameters / filters
| Param | Source | Required | Notes |
|---|---|---|---|
| `acCode` | path `:acCode` | ✓ | the account to print |
| `coCode` | session/query | ✓ | tenant company |
| `coYear`/`lcCode` | query | — | scope (`scopeSql` // src accounting.ts) |
| `fromDate`/`toDate` | `?fromDate`,`?toDate` | — | period; `fromDate` defines the opening cut |

## 3. Dataset query (tables + scope)
**Table:** `AC_DATA` (universal posting ledger). **Opening** = net of everything **before** `fromDate`;
**period rows** carry a SQL window running balance. Ordered by `VCH_DATE, VCH_NO`.
```sql
-- opening  // src accounting.ts accountLedger()
SELECT coalesce(sum("DR_AMT"-"CR_AMT"),0) AS ob
FROM "AC_DATA" WHERE "AC_CODE"=$1 AND <scope> AND "VCH_DATE" < :fromDate;
-- period rows with running balance
SELECT "VCH_NO","VCH_TYPE","VCH_DATE","DR_AMT" AS dr,"CR_AMT" AS cr,
       sum("DR_AMT"-"CR_AMT") OVER (ORDER BY "VCH_DATE","VCH_NO"
         ROWS BETWEEN UNBOUNDED PRECEDING AND CURRENT ROW) AS rb
FROM "AC_DATA" WHERE "AC_CODE"=$1 AND <scope> [AND "VCH_DATE">=:from][AND <=:to]
ORDER BY "VCH_DATE","VCH_NO";
-- folded with opening offset → { acCode, opening, rows, closing }
```
> The desktop's `RP_LEDR.cs` materialises `LEDR_AC_DATA`/`FINE_DATA` (// data, RP_LEDR.md ops L6128/L8255)
> by reading many sources (`AC_DATA, SL_DATA, PR_DATA, KR_DETL, MFG_DATA, RATE_CUT_DATA, CUT_STK_DETL,
> LDR_ADJ_DATA …`); the web reads the **already-posted** `AC_DATA` directly (the posting engine wrote
> those legs at save time), so no scratch table is needed.

## 4. Column / field list (from `all_rpt_fields.txt`)
| Web col | `.rpt` field | all_rpt_fields | Type |
|---|---|---|---|
| (account) | `AC_CODE` / `AC_NAME` | #L8 / #L29 | string |
| vchNo | `VCH_NO` | #L698 | string |
| vchType | `VCH_TYPE` | #L701 | string |
| vchDate | `VCH_DATE` | #L695 | date |
| dr | `DR_AMT` | #L195 | money |
| cr | `CR_AMT` | #L156 | money |
| running balance | derived (Σ `DR_AMT−CR_AMT`) | — | money |
| (ledger key) | `LEDR_KEY` | #L400 | string |
Metal-ledger variants (`AcWithWt`/`AcFineGold`/`AcFineSilver`) add `FINE_WT`#L219, `FINE_RATE`#L217,
`DR_FINE_WT`/`CR_FINE_WT`, `DR_GOLD`/`CR_GOLD`, `DR_SILVER`/`CR_SILVER` (in the dictionary) — **pending**.

## 5. Grouping / totals
One account, chronological. `opening` (pre-period), `closing` (final running balance), `totals.dr`/`.cr`
= Σ over period rows (// src accountLedger fold). Money 2 dp. Empty period → opening shown, no rows.

## 6. Web dataset-builder mapping + parity
- **Builder:** `accountLedger(prisma, scope, acCode, {fromDate,toDate})` → `{ acCode, opening, rows, closing }`.
- **Parity:** (1) opening = Σ(dr−cr) strictly before `fromDate`; (2) every period leg present with
  matching `VCH_TYPE`/dr/cr; (3) running balance and closing match desktop to the paisa; (4) account
  with no movement → opening only.
- **Selected-accounts variant** (`AcLedgerSelected.rpt`): loop the builder over an account list / range.

## 7. Open questions / risks
- **Metal columns flagged:** `AcWithWt*`/`AcFineGold`/`AcFineSilver` need `FINE_WT`/`FINE_RATE`/metal
  Dr/Cr from `AC_DATA` (or `FINE_DATA`); not yet in `accountLedger`. Add a fine-ledger variant.
- Confirm desktop opening-balance treatment of `OP_LDR`/`OP_AC` (// RP_LEDR reads `OP_LDR`) vs the
  web "sum before fromDate" — they should agree, but verify against a golden master.
