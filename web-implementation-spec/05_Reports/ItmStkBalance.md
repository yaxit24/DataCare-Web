# ItmStkBalance — Item stock balance (field spec)

```
Report: ItmStkBalance  ·  .rpt: unified/reports/ItmStkBalance.rpt  ·  Domain: Stock / Tag
Desktop form: RP_STOCK / RP_PHY_STOCK (reads BAR_DETL, MAIN_STOCK, ITEM_MAST)
Web target: stockValuation() // src reports.ts ; itemStockLedger() // src reports2.ts ; onHand() // src stock.ts
Routes: GET /reports/stock-valuation · GET /reports/item-stock-ledger · GET /stock/on-hand
Status: 📋 SPEC · 🟩 BUILT  ·  Parity: 06_Parity/reports.md
```

## 1. Purpose
Item-wise on-hand stock balance: per item code, the pieces / gross / net / fine in stock and its value,
with company totals. The headline "what metal do we hold" report; the closing-stock figure behind the
balance sheet. `ItmStkBalance` is the balance snapshot; `ItemLedger`/`ItemInOut` is its movement ledger.

## 2. Parameters / filters
`coCode`(✓), optional `lcCode`. Point-in-time (no date range) for the balance; `itemStockLedger` shows
cumulative in/out.

## 3. Dataset query (tables + scope)
**Balance** — `BAR_DETL` rolled up by `IT_CODE`, excluding issued tags (`stockValuation`, same query as
[TagStkRpt](./TagStkRpt.md) §3). **Movement ledger** — `MAIN_STOCK` summed by sign:
```sql
-- itemStockLedger (in vs out)  // src reports2.ts
SELECT "IT_CODE" AS item,
       sum(CASE WHEN "ITM_SIGN"='+' THEN NN("ITM_FINE") ELSE 0 END) AS "inFine",
       sum(CASE WHEN "ITM_SIGN"='-' THEN NN("ITM_FINE") ELSE 0 END) AS "outFine",
       sum(CASE WHEN "ITM_SIGN"='+' THEN NN("ITM_PCS")  ELSE 0 END) AS "inPcs",
       sum(CASE WHEN "ITM_SIGN"='-' THEN NN("ITM_PCS")  ELSE 0 END) AS "outPcs",
       count(*)::int AS moves
FROM "MAIN_STOCK" WHERE "CO_CODE"=$1 GROUP BY "IT_CODE" ORDER BY "IT_CODE";
-- netFine = inFine - outFine  (the on-hand fine by movement)
-- onHand (company totals)  // src stock.ts: Σ ITM_PCS/ITM_GWT/ITM_NWT over in-stock BAR_DETL
```

## 4. Column / field list (from `all_rpt_fields.txt`)
| Web col | `.rpt` field | all_rpt_fields | Type |
|---|---|---|---|
| item | `IT_CODE` / `IT_NAME` | #L— / #L324 | string |
| pcs | `ITM_PCS` / `STK_PCS` | #L299 / #L619 | number |
| gwt | `ITM_GWT` / `STK_GWT` | #L287 / #L613 | weight |
| nwt | `ITM_NWT` / `STK_NWT` | #L295 / #L618 | weight |
| fine | `ITM_FINE` / `STK_FINE` | #L281 / #L612 | fine wt |
| rate | `STK_ITM_RATE` | #L615 | money |
| amount | `STK_ITM_AMT` / `STK_NET_AMT` | #L614 / #L617 | money |
| in/out fine | `ITM_FINE` × `ITM_SIGN` | #L281 | derived (ledger) |
| mrp | `ITM_MRP` | #L294 | money |
Movement source: `MAIN_STOCK` (with `ITM_SIGN` +/−, `STK_IT_CODE`#L—, `STK_DATE`#L—). Opening:
`DAY_OP_PCS`/`DAY_OP_WT`, `DAY_CL_PCS`/`DAY_CL_WT` are in the dictionary for day open/close variants.

## 5. Grouping / totals
Grouped by `IT_CODE`. `stockValuation` footer Σ `tags, nwt, fine, mrp`; `itemStockLedger` footer Σ
`inFine, outFine, netFine`. Weight/fine 3 dp, money 2 dp. Empty scope → "no records".

## 6. Web dataset-builder mapping + parity
- **Builders:** `stockValuation` (balance by value), `itemStockLedger` (in/out/net by movement),
  `onHand` (company pcs/gwt/nwt), `stockByLocation`, `itemGroupStock`.
- **Parity:** (1) on-hand item set + pcs/gwt/nwt/fine match desktop; (2) `netFine` (in−out from
  `MAIN_STOCK`) reconciles with the `BAR_DETL` on-hand fine; (3) closing-stock total feeds `balanceSheet`
  as the off-ledger balancing asset (// src reports.ts balanceSheet).

## 7. Open questions / risks
- **Two on-hand methods** coexist: `BAR_DETL` minus issued (`stockValuation`) vs `MAIN_STOCK` signed
  sum (`itemStockLedger`). They should agree; **flag** a reconciliation fixture proving `netFine` ==
  `stockValuation.fine` per item.
- Valuation rate: `stockValuation` exposes `mrp` but not a metal-rate × fine valuation. **Flag:** add
  rate-based value (`STK_ITM_RATE`×fine) to match the desktop's valued column if present in the `.rpt`.
