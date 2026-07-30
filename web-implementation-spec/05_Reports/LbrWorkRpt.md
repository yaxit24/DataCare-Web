# LbrWorkRpt — Labour-work report (field spec)

```
Report: LbrWorkRpt  ·  .rpt: unified/reports/LbrWorkRpt.rpt  ·  Domain: Manufacturing / Karigar
Desktop form: labour-sale / job-work labour (TR_SALE_LBR variant uses book LBR; reads LBR_ISU_DETL, KR_DETL)
Web target: karigarStatement() // src reports4.ts (labour columns pending)
Route: GET /reports/karigar-statement  // src txn.ts#L454  (labour-work view)
Status: 📋 SPEC · 🟨 PARTIAL (metal/pcs built; labour-charge columns pending)  ·  Parity: 06_Parity/reports.md
```

## 1. Purpose
The labour-work report: per karigar/job, the work done and the **labour charges** earned — labour type,
rate, weight/pieces worked and the labour amount payable. The basis for karigar labour settlement and
the labour-only sale (`TR_SALE_LBR`, book `LBR`). Sits beside [MfgLedger](./MfgLedger.md) (which tracks
metal) — this tracks **labour money**.

## 2. Parameters / filters
| Param | Source | Required | Notes |
|---|---|---|---|
| `coCode` | session/query | ✓ | tenant company |
| `coYear`/`lcCode` | query | — | scope |
| date range | query | — | labour period (to add when the dataset is date-scoped) |

## 3. Dataset query (tables + scope)
**Built today** (metal/pcs side, via `karigarStatement` over `KR_DETL` — see
[MfgLedger §3](./MfgLedger.md)). **Target labour query** (to add — `LBR_ISU_DETL`/`KR_DETL` with labour
columns):
```sql
-- target labour-work dataset (SPEC)  // builds on reports4.ts karigarStatement
SELECT "AC_CODE" AS karigar, "LBR_TYPE" AS "labourType", "WORK_TYPE" AS "workType",
       sum(NN("ITM_PCS"))  AS pcs,
       sum(NN("ITM_NWT"))  AS "netWt",
       sum(NN("KR_LBR_RATE")) AS "lbrRate",   -- or LBR_RATE
       sum(NN("KR_LBR_AMT"))  AS "labourAmt"  -- or LBR_AMT
FROM "KR_DETL"   -- ∪ LBR_ISU_DETL for labour-issue lines
WHERE "CO_CODE"=$1 [AND scope]
GROUP BY "AC_CODE","LBR_TYPE","WORK_TYPE" ORDER BY "AC_CODE";
```
> **Flagged:** the labour-amount columns are **not** yet in `karigarStatement` (it returns
> issued/received fine + pcs only). The labour fields exist in the schema/dictionary (below) — this is a
> column-addition, not a new data source.

## 4. Column / field list (from `all_rpt_fields.txt`)
| Web col | `.rpt`/source field | all_rpt_fields | Type |
|---|---|---|---|
| karigar | `KR_AC_CODE` / `AC_CODE` | #L344 / #L8 | string |
| labour type | `LBR_TYPE` | #L383 | string |
| work type | `WORK_TYPE` | #L721 | string |
| labour code | `LBR_CODE` | #L379 | string |
| labour rate | `LBR_RATE` / `KR_LBR_RATE` | #L382 / #L356 | money |
| labour % | `LBR_PRC` | #L381 | % |
| labour amount | `LBR_AMT` / `KR_LBR_AMT` | #L378 / #L355 | money |
| pcs | `ITM_PCS` | #L299 | number |
| net wt | `ITM_NWT` / `KR_NET_WT` | #L295 / #L360 | weight |
| ghat/loss wt | `KR_GHT_WT` / `ITM_LOSS_WT` | #L353 / #L291 | weight |
| fine | `ITM_FINE` / `KR_FINE` | #L281 / #L351 | fine wt |
| net amount | `KR_NET_AMT` | (dict) | money |
Source tokens: `LBR_ISU_DETL`#L— (labour issue detail), `KR_DETL`/`KR_DATA`, plus the `LBR_*` family
(#L378-#L383) and `WORK_TYPE`#L721.

## 5. Grouping / totals
Group by karigar × labour/work type. Footer = Σ `labourAmt`, Σ `netWt`/`pcs`. Money 2 dp, weight 3 dp.
Empty scope → "no records".

## 6. Web dataset-builder mapping + parity
- **Builder (current):** `karigarStatement` — metal balance + pcs (labour columns **missing**).
- **Builder (target):** extend `karigarStatement` (or a new `labourWork`) to emit `LBR_TYPE`/`WORK_TYPE`/
  `LBR_RATE`/`LBR_AMT` from `KR_DETL`∪`LBR_ISU_DETL`.
- **Parity:** (1) per-karigar labour amount = Σ `LBR_AMT`/`KR_LBR_AMT` for the scope; (2) labour type/rate
  match; (3) pcs/net-wt worked match; (4) ties to the labour-sale book `LBR` ledger total. Until the
  labour columns ship, parity covers metal/pcs only — **flagged PARTIAL**.

## 7. Open questions / risks
- **Labour columns not built** — primary gap; add `LBR_AMT`/`LBR_RATE`/`LBR_TYPE`/`WORK_TYPE` to the
  dataset (schema + dictionary confirm the fields exist).
- Confirm the labour-work **source**: `LBR_ISU_DETL` (labour issue) vs `KR_DETL` (karigar detail) vs the
  `LBR` sales book (`TR_SALE_LBR`). The `.rpt` field set will disambiguate — **flag** until verified.
- Labour-vs-metal double counting: ensure labour-work rows are not also counted as metal issue/receive
  in `MfgLedger` (separate `INOUT_TYPE`/book) — reconcile in `06_Parity/reports.md`.
