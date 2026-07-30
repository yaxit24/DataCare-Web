# TagStkRpt — Tag-wise stock report (field spec)

```
Report: TagStkRpt (+ TagStkSummRpt / TagStkItemSumRpt / TagStkRptDmSum / TagStkIdtlRpt)  ·  .rpt: unified/reports/TagStkRpt.rpt
Domain: Stock / Tag
Desktop form: RP_TAG / RP_STOCK (reads BAR_DETL, BAR_IDTL, MAIN_STOCK, TAG_STOCK_PRINT, ITEM_MAST, GROUP_MAST)
Web target: stockValuation() // src reports.ts ; listTags()/onHand() // src stock.ts ; itemGroupStock() // src reports6.ts
Routes: GET /reports/stock-valuation · GET /reports/item-group-stock · GET /stock/tags · GET /stock/on-hand
Status: 📋 SPEC · 🟩 BUILT (valuation/group/on-hand) · 🟨 detail variants  ·  Parity: 06_Parity/reports.md
```

## 1. Purpose
The live tag inventory: every in-stock tagged piece (or item/group rollup) with pcs, gross/net weight,
fine and value. The physical-stock control report and the basis for stock valuation. A tag is **in
stock** until it is issued out (sold/transferred).

## 2. Parameters / filters
| Param | Source | Required | Notes |
|---|---|---|---|
| `coCode` | session/query | ✓ | tenant company |
| `lcCode` | query | — | location (when chosen) |
(No date range — it's a point-in-time on-hand snapshot.)

## 3. Dataset query (tables + scope)
**Table:** `BAR_DETL` (tag inventory). **In-stock rule:** `NOT EXISTS` a `MAIN_STOCK` outward
movement (`ITM_SIGN='-'`) for the same `TAG_NO` — i.e. not yet sold/issued. `stockValuation` rolls up
by item; `listTags` lists individual tags.
```sql
-- stockValuation (item rollup)  // src reports.ts
SELECT coalesce("IT_CODE",'(none)') AS item, count(*)::int AS tags,
       sum(NN("ITM_PCS")) AS pcs, sum(NN("ITM_GWT")) AS gwt, sum(NN("ITM_NWT")) AS nwt,
       sum(NN("ITM_FINE")) AS fine, sum(NN("ITM_MRP")) AS mrp
FROM "BAR_DETL"
WHERE "CO_CODE"=$1
  AND NOT EXISTS (SELECT 1 FROM "MAIN_STOCK" m
                    WHERE m."CO_CODE"="BAR_DETL"."CO_CODE" AND m."TAG_NO"="BAR_DETL"."TAG_NO"
                      AND m."ITM_SIGN"='-')
GROUP BY "IT_CODE" ORDER BY nwt DESC;
-- listTags (per-tag)  // src stock.ts: TAG_NO, IT_CODE, ITM_PCS, ITM_GWT, ITM_NWT, ITM_FINE, ITM_MRP
```

## 4. Column / field list (from `all_rpt_fields.txt`)
| Web col | `.rpt` field | all_rpt_fields | Type |
|---|---|---|---|
| tagNo | `TAG_NO` | #L634 | string |
| item | `IT_CODE` / `IT_NAME` | #L— / #L324 | string |
| pcs | `ITM_PCS` | #L299 | number |
| gwt | `ITM_GWT` | #L287 | weight |
| nwt | `ITM_NWT` | #L295 | weight |
| touch | `ITM_TOUCH` / `TAG_TOUCH` | #L307 / #L641 | % |
| fine | `ITM_FINE` / `TAG_FINE` | #L281 / #L624 | fine wt |
| rate | `TAG_IT_RATE` | #L628 | money |
| labour | `TAG_LBR_AMT` | #L629 | money |
| mrp | `ITM_MRP` / `TAG_MRP` | #L294 / #L633 | money |
| cost | `TAG_COST` | #L623 | money |
| gross wt (tag) | `TAG_GWT` / `TAG_NWT` | #L625 / #L635 | weight |
Source tokens: `BAR_DETL` (tag inventory), `BAR_IDTL`#L— (tag sub-detail / diamonds), `MAIN_STOCK`#L—
(movement, `ITM_SIGN`#L— in/out), `TAG_STOCK_PRINT`#L— (desktop scratch print table).

## 5. Grouping / totals
`stockValuation`/`itemGroupStock`: grouped by item / item-group, ordered by net weight desc; footer Σ
`tags, nwt, fine, mrp` (weight/fine 3 dp, money 2 dp). `listTags`: flat, capped 500. Empty → "no records".

## 6. Web dataset-builder mapping + parity
- **Builders:** `stockValuation` (item), `itemGroupStock` (group), `stockByLocation` (location),
  `onHand` (totals pcs/gwt/nwt), `listTags` (per-tag).
- **Parity:** (1) the **in-stock tag set** equals desktop (issued tags excluded via `MAIN_STOCK '-'`);
  (2) pcs/gwt/nwt/fine/mrp per item match; (3) footer Σ matches. Live (CO_CODE='01'): top group 925 ≈
  471 tags / nwt 7381.890 / fine 7280.320 (// src reports6.ts sanity).

## 7. Open questions / risks
- **Detail variants flagged:** `TagStkIdtlRpt` (tag sub-detail incl. diamonds from `BAR_IDTL`),
  `TagStkRptDmSum` (diamond summary), `ItmStkWithGrid`/`ItmStkWithOthWt` (grid + other-weight) need extra
  columns (`DM_*` diamond fields, `ITM_OTH_WT`#L—) not yet in the builders.
- The web treats `BAR_DETL` as the tag source (HANDOFF-verified) while `RP_TAG` also reads `TAG_STOCK_PRINT`
  /`TAG_SUM_DATA`; confirm the on-hand definition (BAR_DETL − MAIN_STOCK '-') matches the desktop's
  `TAG_STOCK` view for the same scope via a golden master.
