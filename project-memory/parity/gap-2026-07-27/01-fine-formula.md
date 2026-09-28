# Fine-Weight Formula & Rounding Parity — Desktop vs Web

**Date:** 2026-07-27
**Scope:** Does the web's single universal `fineWt()` helper reproduce the desktop's per-workflow
fine-weight formulas? Rounding policy comparison included.
**Method:** Extracted the assignment expressions that produce `FINE`/`ITM_FINE` from the desktop
decompiled grid cell-changed / compute handlers and the authoritative `MS_UPDATE.cs` backfill, then
compared to each web caller. Every claim is cited `file:line`.

---

## 0. The web helper under test

`web/apps/api/src/modules/shared/fine.ts:11`
```ts
export function fineWt(netWt, ghtWt, touch, westPct) {
  const base = num(netWt) + num(ghtWt);
  const pct  = num(touch) + num(westPct);
  return round3(pct === 0 ? base : (base * pct) / 100);   // (Net+Ght)×(Touch+West)/100 ; pct=0 ⇒ Net+Ght
}
```
`round3` (`fine.ts:8`) = `Math.round((n+EPSILON)*1000)/1000` → fixed 3 dp.

---

## 1. Desktop authoritative formula per workflow (grid col indices in brackets)

| Workflow | Desktop file:line | FINE assignment | Ght in fine? |
|---|---|---|---|
| **Sale** | `TR_SALE.cs:10693/10723/10749/11154` (col20) | `(NetWt[14]+GhtWt[17])×(Touch[18]+West%[19])/100`; touch+west=0 ⇒ `Net+Ght` (`:11215`) | **+Ght (added)** |
| **Purchase — std item (`val`)** | `TR_PURC.cs:9862/9888/9910` (col20), `:9748` (col26) | `(NetWt[15]+GhtWt[17])×(Touch[18]+West[19])/100`; =0 ⇒ `Net+Ght` (`:9921`) | **+Ght (added)** |
| **Purchase — old-gold/Kun (`mSG_PR`)** | `TR_PURC.cs:7312-7362`, `:12422` (col24/25) | `(NetWt[18]+GhtWt[20])×(Touch[21]+West[22]−LesTch[23])/100 + KunFine[17]` | +Ght **and −LesTch, +KunFine** |
| **Karigar Issue** | `TR_KR_ISU.cs:3940/3952/3964/3972` (col15) | `(NetWt[9]+GhtWt[10])×(Touch[11]+West[12])/100 − LesWt[14]` (LesWt=Net×LesTch[13]/100 `:3933`); =0 ⇒ `Net+Ght−LesWt` (`:3977`) | +Ght **and −LesWt** |
| **Karigar Receipt** | `MS_UPDATE.cs:2691` (BAR_DETL backfill, ITM_FINE≤0) | `ITM_NWT×(ITM_TOUCH+ITM_WEST_PRC)/100` | none (no ght) |
| **Melting** | `TR_MLT_PRO.cs:2832/2906/3297` (col6/col8) | `NetWt[4]×Touch[5]/100`; touch=0 ⇒ `Net` | none / no west |
| **Tag Opening** | `TR_TAG_OPBL.cs:6590/6631/6653/6675` (col29), `:6730-6826` (col23) | `(NetWt[16]+GhtWt[26])×(Touch[27]+West[28])/100` (GhtWt=Net×col25/100 `:6609`) | **+Ght (added)** |
| **Item Opening (ITM_OPBL)** | `TR_ITM_OPBL.cs:951` (col9) | `NetWt[6]×(Touch[7]+West[8])/100` | **none (no ght)** |
| **Item Lot (ITM_LOT)** | `TR_ITM_LOT.cs:2728/2750/2768/2790` (col13), `:2830-2892` (col18) | `NetWt[10]×(Touch[11]+West[12])/100` | **none (no ght)** |
| **Mfg Issue/Receipt** | `TR_MFG_ISU_REC.cs:4159/4196/4218` (col29) | `(NetWt[12]+GhtWt[14])×(Touch[27]+West[28])/100` (GhtWt=Net×col13/100 `:4174`) | **+Ght (added)** |

Column headers verified: karigar `TR_KR_ISU.cs:2955-3020` (7 GrWt, 8 OthWt, 9 NetWt, 10 GhtWt,
11 Touch, 12 West%, 13 LesTch, 14 LesWt, 15 Fine); old-gold purchase `TR_PURC.cs:6296-6367`
(17 KunFine, 18 NetWt, 19 Ght%, 20 GhtWt, 21 Touch, 22 West%, 23 LesTch%, 24 Fine, 25 NetFine).

**Key desktop fact:** the desktop is NOT uniform. Sale / std-purchase / mfg / tag-opening **add** GhtWt.
Item-opening / item-lot / melting / karigar-receipt-backfill use **net-only** (no ght). Karigar-issue
and old-gold-purchase carry an extra **LesTch deduction** (and old-gold a KunFine additive) that the
web helper has no term for.

---

## 2. Web caller per workflow

| Web caller | file:line | Formula used |
|---|---|---|
| Sale | `sales/sales.ts:116` `lineFine` → `fineWt` | `(Net+Ght)×(Touch+West)/100` |
| Sales Order | `sales/salesOrder.ts:76` `fineWt(...)` | `(Net+Ght)×(Touch+West)/100` |
| Purchase | `purchase/purchase.ts:104` `lineFine` → `fineWt` | `(Net+Ght)×(Touch+West)/100` |
| Mfg | `manufacturing/mfg.ts:336` `lineFine` | override → `t+w=0 ? Net : fineWithGhat=(Net+Ght)×(Touch+West)/100` |
| Melting | `manufacturing/melting.ts` `meltLine.partyFine` (hdr `:7`) | `NWT×touch/100` |
| Karigar issue | `manufacturing/karigar.ts:42` `fineWeight` | `Net×touch/100` |
| Karigar receipt | `manufacturing/karigar.ts:47` `fineWithWastage`, `:170` | `Net×(touch+west)/100` |
| Tag opening | `stock/stock.ts:535` `fineWt(...)` | `(Net+Ght)×(Touch+West)/100` |
| Item opening | `stock/stock.ts:692` `itemOpening.fineOf` → `fineWt(...)` | `(Net+Ght)×(Touch+West)/100` |

---

## 3. Verdict per workflow

| # | Workflow | Verdict | Diverges under | Numeric impact |
|---|---|---|---|---|
| 1 | **Sale** | ✅ EQUAL | — | none |
| 2 | **Sales Order** | ✅ EQUAL | — | none |
| 3 | **Purchase (std item)** | ✅ EQUAL (code) | — | none. **Comment bug:** `purchase.ts:102` doc-comment says "netWt × touch / 100" but code (`:104-106`) calls `fineWt(net,ght,touch,west)`; the CODE matches desktop, the COMMENT is stale/wrong. Cosmetic. |
| 4 | **Purchase (old-gold / KunFine sub-grid)** | ❌ DIVERGENT | `LesTch%>0` or `KunFine>0` | web omits the `−(Net+Ght)×LesTch/100` deduction and `+KunFine` term. For net=10, touch=90, LesTch=5: desktop fine=8.500, web=9.000 → +0.500 fine over-stated. Web has no old-gold purchase path replicating this. |
| 5 | **Karigar Issue** | ❌ DIVERGENT | `Ght>0`, `West>0`, or `LesTch>0` | web `Net×touch/100` drops the +Ght add, the West term, and the `−LesWt` deduction. net=10, ght=1, touch=90, west=2, LesTch=3: desktop=(11)×92/100−0.3=9.820, web=9.000 → −0.820 understated. Equal only when ght=west=lesTch=0. |
| 6 | **Karigar Receipt** | ✅ EQUAL | — | matches `MS_UPDATE.cs:2691` `Net×(touch+west)/100`. |
| 7 | **Melting** | ✅ EQUAL | — | both `Net×touch/100` (no ght, no west). |
| 8 | **Tag Opening** | ✅ EQUAL | — | both `(Net+Ght)×(Touch+West)/100`. |
| 9 | **Item Opening (ITM_OPBL)** | ⚠️ DIVERGENT (conditional) | `ghtWt>0` | desktop `Net×(Touch+West)/100` (no ght); web `fineWt` ADDS ght. Equal when ghtWt=0 (default/unset). net=10, ght=2, touch=91.6: desktop=9.160, web=10.992 → +1.832 over-stated when a ght value is supplied. |
| 10 | **Item Lot (ITM_LOT)** | ⚠️ DIVERGENT (conditional) / web module not found | `ght>0` | desktop `Net×(Touch+West)/100` (no ght). No dedicated web item-lot fine path located; any route through `fineWt` with ght repeats the item-opening divergence. |
| 11 | **Mfg Issue/Receipt** | ✅ EQUAL | — | both `(Net+Ght)×(Touch+West)/100`. |

**Note on the "single universal helper" premise:** the web actually uses THREE fine variants —
`fineWt` (Net+Ght)(Touch+West)/100 for sale/salesOrder/purchase/tag-opening/item-opening;
plain `Net×touch/100` for melting/karigar-issue/fine-inout/tour/tagOps; and
`Net×(touch+west)/100` for karigar-receipt. It is not literally one helper everywhere, but the
`fineWt` (ght+west) helper IS mis-applied to **item-opening/item-lot** (desktop uses net-only) and
does **not** cover the **LesTch/KunFine** deduction workflows (old-gold purchase, karigar-issue).

---

## 4. Rounding policy

**Weight / fine rounding — EQUAL.**
Desktop formats every fine/weight cell as `"0.000"` (fixed 3 dp) — e.g. all rows in §1, plus
`Math.Round(...,3)` (`TR_SALE.cs:7917`). Web: `shared/fine.ts:8 round3` = 3 dp, and
`packages/core/src/money.ts:7 PRECISION={amount:2,weight:3,fine:3}`. Fine weight is 3 dp on both. ✅

**Monetary rounding — DIVERGENT (MEDIUM, outside the fine-weight scope but a real parity gap).**
Desktop monetary/rate rounding is **configurable per company** from `CO_SET_NEW`, loaded in
`MS_OPNCOMP.cs:671-991` into `DC_Main` (`DC_Main.cs:303,351,359,435,479`):
- `MsTaxRof ← TAX_ROF`, `MsLbrRof ← LBR_ROF`, `MsItmRateRof ← ITM_RATE_ROF`,
  `MsTotAmtRof ← TOT_AMT_ROF`, `MsPrRateRof ← PR_RATE_ROF` (editable in `UT_SETTING.cs:4935-5025`,
  `UT_SETTING_MAIN.cs:9197-9199`).
- Labour amounts rounded to `MsLbrRof` (`TR_SALE.cs:11017/11021/11198/11245`), tax to `MsTaxRof`,
  bill total to `MsTotAmtRof`.
Web hardcodes amounts to 2 dp (`core/money.ts:7 PRECISION.amount=2`, half-up `round()`), and a grep
of `apps/api/src/modules` finds **no** reader for `TOT_AMT_ROF`/`LBR_ROF`/`TAX_ROF`. So a company
configured with e.g. `TOT_AMT_ROF=0` (whole-rupee bill totals) or `LBR_ROF=0` will see the web
produce 2-dp amounts and a different round-off than the desktop. `core/money.ts:5` even flags this
as "configurable per-column in the schema later" (not yet done).

**Rounding mode — LOW / theoretical / unverifiable.**
Web uses half-up (`Math.round`, `Decimal.ROUND_HALF_UP`); .NET `Strings.Format(x,"0.000")` uses the
runtime default (banker's / round-half-to-even). Sub-milligram differences are possible only at exact
`.0005` midpoints; not reproducible without runtime and immaterial for products/100.

---

## 5. Severity-ranked findings

- **HIGH** — Karigar-Issue fine divergence (`karigar.ts:42` vs `TR_KR_ISU.cs:3940`): web omits
  +GhtWt, West, and the −LesWt (less-touch) deduction. Wrong accountable metal owed by karigar
  whenever ght/west/lesTch ≠ 0.
- **HIGH/MEDIUM** — Old-gold / KunFine purchase (`TR_PURC.cs:7312`): web purchase has no
  `−LesTch` / `+KunFine` terms; either the workflow is unimplemented in web or fine is over-stated.
  (Confirm whether web scope includes old-gold purchase.)
- **MEDIUM** — Item-Opening / Item-Lot (`stock.ts:692` vs `TR_ITM_OPBL.cs:951`, `TR_ITM_LOT.cs:2728`):
  web adds ght, desktop does not. Harmless while ghtWt is unset; over-states fine if a ght value is
  entered. Recommend: don't pass ghtWt into `fineWt` for these two paths (or force ght=0).
- **MEDIUM** — Monetary rounding not company-configurable in web (`core/money.ts:7`); desktop reads
  `CO_SET_NEW.TOT_AMT_ROF/LBR_ROF/TAX_ROF/ITM_RATE_ROF`. Affects bill totals/labour/tax, not fine wt.
- **LOW** — `purchase.ts:102` doc-comment "netWt × touch / 100" contradicts its own code (which is
  correct). Fix the comment.
- **LOW** — half-up (web) vs half-even (.NET format) rounding mode; unverifiable, immaterial.

**Verified EQUAL:** Sale, Sales-Order, Purchase(std item), Mfg, Melting, Tag-Opening, Karigar-Receipt,
and fine/weight 3-dp rounding.
