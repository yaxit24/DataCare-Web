# FUNCTIONAL PARITY DELTA — MANUFACTURING + KARIGAR + MELTING

_Session `manufacturing`. 2026-06-30 (refresh of same-day baseline `audit-C-mfg-dhrn.md`, mfg portion,
2026-06-29 19:46). FIELD / BUTTON / FLOW depth — not surface coverage. Every claim cites real `file:line`
on BOTH sides. Desktop = `extracted_code/DataCareNext/DataCareNext/*.cs` (decompiled C# WinForms; this
session's task path — line numbers re-verified here, they differ slightly from the baseline's
`unified/src/csharp_nextdm/` path). Web = `web/apps/api/src` + `web/apps/web`. Live DB read-only:
`PGPASSWORD=app psql -h127.0.0.1 -p5433 -U app_user -d datacare`._

## 0. REFRESH DELTA vs baseline (what changed in CURRENT code)
Two baseline GAPS are now **FIXED** in current code and **verified against migrated real data**:

- **G1 Karigar INOUT direction — FIXED.** Baseline: `karigar.ts` declared `INOUT_ISSUE='I'`/`RECEIPT='O'`
  (inverted). Current: `karigar.ts:27 INOUT_ISSUE='O'`, `:28 INOUT_RECEIPT='I'`. Real KR_DETL proves the
  direction: `O`×1 (fine 14.960), `I`×21 (fine 216.839); MAIN_STOCK `KARIGAR ISSUE|O|-`×1,
  `KARIGAR RECEIPT|I|+`×21. `balanceTx` now sums issued@`'O'` − received@`'I'` ⇒ correct balance.
- **Karigar metal sub-ledger leg — FIXED (NEW).** Baseline: AC_DATA carried labour only. Current:
  `issueKarigar` posts an AC_DATA leg `IT_TYPE='G',SIGN='-',FINE_WT=fineIssued` (karigar.ts ~L135);
  `receiveKarigar` posts `IT_TYPE='G',SIGN='+',FINE_WT=fineReceived` (~L165) + the labour Dr/Cr pair.
  Real AC_DATA proves the desktop convention this now matches: `KISU|G|-`×1, `KREC|G|+`×21, `KREC|A`×2
  (labour). The metal leg keeps DR=CR=0 so `assertBalanced` (posting.ts) still passes (0=0).
- **MFG breadth — IMPROVED (NEW).** Baseline implied no real MFG write path. Current: `/mfg/issue`,
  `/mfg/receive`, `DELETE /mfg/:vchNo` routes exist (`txn.ts`) and the `mfg-issue`/`mfg-receive` pages
  POST to them (NOT karigar). `issueMfg`/`receiveMfg` write the real MFG_DATA/MFG_DETL/MFG_IDTL/
  MFG_ISU_REC(+MAIN_STOCK) trio (`mfg.ts`). Depth still partial (below).

Still-stale: the `karigar.ts:13-15` header doc-comment still says "we use 'I'(issue)/'R'(receipt)" — a
**stale comment** contradicting the now-correct `'O'/'I'` constants. Cosmetic, but misleading.

Data reality (this session): `KR_DATA=17`, `KR_DETL=22` (O1/I21), `MFG_DATA=MFG_DETL=MFG_ISU_REC=0`,
`MLT_DATA=1` (web-created). ⇒ **Karigar is the only real-data anchor; all MFG/jobwork runtime = CANNOT-VERIFY** (code-level only).

---

## 1. PER-FORM VERDICT (DEPTH / BREADTH / OK + real usage)

| # | Desktop form | Web target | Verdict | Real usage |
|---|---|---|---|---|
| 1 | `TR_MFG_ISU_REC` (mfg issue+receive, stage pipeline) | `mfg-issue`/`mfg-receive` → `/mfg/*` | **DEPTH** | greenfield (0 rows) — code-verified |
| 2 | `TR_MFG_ORD_ISU` (order-linked issue) | — none | **BREADTH** | 0 |
| 3 | `TR_MFG_ORD_REC` (order-linked receive) | — none | **BREADTH** | 0 |
| 4 | `TR_MFG_GHAT_REC` (ghat/cast receipt vs order) | folded into `mfg-receive` Ght Wt | **DEPTH/BREADTH** | 0 |
| 5 | `TR_MFG_WITH_LOT` (lot-merge `ITM_LOT`) | — none | **BREADTH** | 0 |
| 6 | `TR_MFG_ITEM` (mfg item / BOM master) | — none | **BREADTH** | 0 |
| 7 | `TR_MFG_KR_ISU_REC` (karigar-as-process in MFG, ORD_NO) | — none (karigar≠MFG) | **BREADTH** | 0 |
| 8 | `TR_KR_ISU` (karigar issue+receive) | `karigar-issue`/`receive` → `/karigar/*` | **DEPTH** | 17 vch / 22 lines — REAL |
| 9 | `TR_MLT_PRO` (melting/refining) | `melting` → `/melting` | **DEPTH** | 1 row (web) |
| 10 | `TR_JDT_REC` (jobwork receipt) | `jobwork-*` → `/karigar/*` | **BREADTH** (wrong tables) | 0 |

No form is fully **OK** (every existing form has missing fields/footprint); several *sub-formulas* are
verbatim parity (§4).

---

## 2. FIELD / BUTTON DELTA (frontend present vs desktop)

### 2A. MFG Issue (`mfg-issue/page.tsx`) → `/mfg/issue`
- **Fields present:** Book(CO_BOOK), Year, Location, Karigar AC + name, Party AC + name; line grid
  `Item, Pcs, Gross, Net Wt, Touch%` + live Fine = net×touch/100.
- **Buttons:** `+ Add line`, `× delete line`, `Save Issue`. (no Print, no Delete/Reverse, no New).
- **Missing fields vs desktop** (`MFG_DETL` columns the engine accepts but the form never sends):
  `irType`/process selector (⇒ stage defaults to `'G'`), `lotNo`, `designNo`/`designSrNo`, `tagNo`,
  `ghtPct`/`ghtWt`, `westPct`, `othWt`, sub-components/stones (`MFG_IDTL`), labour (type/rate),
  `empCode`, `billNo`/`billDate`, `vchDesc`, **`vchDate`** (route never forwards a date → today only).

### 2B. MFG Receive (`mfg-receive/page.tsx`) → `/mfg/receive`
- **Adds vs issue:** line `Ght Wt`, `Loss Wt`, header `Labour Amount`; live RecWt = net+ght+loss.
- **Missing:** `RTN_CHOL`, `RTN_GHIS` (engine supports them — `mfg.ts isuRecRows`/`detlRows` — but the
  grid has no column ⇒ chol/ghis reconciliation legs always 0), `MTRL_WT`, `westPct`, components,
  `cashAmt`/`kasarAmt`/`billOs` settlement, `irType`/stage, lot/design/tag, `vchDate`.

### 2C. Karigar Issue/Receive (`KarigarForm.tsx`) → `/karigar/*`
- **Fields present:** Karigar AC, Karigar Name, Labour Amount (receive only); line `Item, Net Wt,
  Touch%`, + `Wastage%` (receive only). **Button:** `Check balance` (calls `/karigar/:ac/balance`),
  `+ Add line`, `× delete`, `Save`.
- **Missing vs `TR_KR_ISU`:** `pcs`, `grossWt`, `designNo`, `lotNo`, `tagNo`/tagged-piece picker
  (desktop has full BAR_DETL/MAIN_STOCK tag lookup `TR_KR_ISU.cs:3318-3400`), stones/`DM_KR_DATA`,
  bill no/date, `vchDate`, narration/remark. No Print/Reverse button.

### 2D. Melting (`melting/page.tsx`) → `/melting`
- **Fields present:** Party(optional), Melting loss%, line `Item, Net Wt, Touch%, Recovered Fine(assay)`.
- **Buttons:** `+ Add line`, `× delete`, `Process Melt`. (no Print/Delete, no vchDate).
- **Missing vs `TR_MLT_PRO`:** per-line assay-touch vs input-touch differential (desktop derives LOSS
  from the two touches, not a flat %), separate loss component line, MAIN_STOCK/issue-rec linkage fields.

### 2E. Jobwork Issue/Receive (`jobwork-issue|receive/page.tsx`)
- **Both are literal karigar aliases:** `<KarigarForm mode=… label="Job-work"/>`. Identical fields to
  §2C. **No order/design/MFG fields at all.** Posts `/karigar/*` ⇒ wrong tables (see §3/G2).

---

## 3. CALC / FLOW / DB-FOOTPRINT DELTA (the deep gaps)

### G9 — MFG stage pipeline (IR_TYPE) is inert; single-row MFG_ISU_REC
- Desktop reconciles **consecutive stages** by `IR_TYPE` (LAST vs CURRENT process):
  `SUM(ITM_SIGN='-' AND IR_TYPE=LastPorcess …) − SUM(… IR_TYPE=CurProcess …)`
  (`TR_MFG_ISU_REC.cs:4565,4569,5287,5291`), and can emit **multiple `MFG_ISU_REC` rows per line**
  (gross/net/diamond via `ISR_NO`).
- Web `isuRecRows` (`mfg.ts`) emits exactly **one** row per line (`ISR_NO:1`) and only a **sign-based**
  lot balance (`mfgLotBalance`: `Σ '-' IR_WT − Σ '+' (IR_WT+RTN_CHOL+RTN_GHIS+ITM_GHAT+ITM_LOSS)`).
  `getStageTx` reads `MFG_MAST` which is **empty (0 rows)** ⇒ returns null ⇒ `ctxOf` defaults
  `irType='G'`, `STK_ISU/STK_REC` flags unused. **The LAST/NEXT/STK stage machine never runs.**
- ✅ The **RecWt reconciliation formula itself is verbatim parity**: desktop
  `IR_WT+RTN_CHOL+RTN_GHIS+ITM_GHAT+ITM_LOSS` (`TR_MFG_ISU_REC.cs:4561`) ≡ web `recWt`/`mfgLotBalance`.

### G2 — Jobwork posts to the WRONG tables (functionally absent)
- Desktop `TR_JDT_REC` is **MFG-shaped**: operates on `MFG_DETL` (`:4625,:4925`), writes
  `MFG_DATA/MFG_DETL/MFG_IDTL` + `Jdt_Rec_Ledr`/`Jdt_Rec_Rojmel`/`Jdt_Stk` + `SL_ORD_ADJ` (baseline
  `:6114-6357`). Web `jobwork-*` → `/karigar/*` ⇒ writes `KR_DATA/KR_DETL` only. **No `MFG_*`, no
  rojmel/day-book, no jobwork ledger, no order-adjust.** Backend grep `jobwork|JDT_` over `apps/api/src`
  = **0**. The feature exists as a label, not as function.

### G(new) — Order-linked MFG family entirely absent (BREADTH)
- `TR_MFG_ORD_ISU`/`ORD_REC`/`GHAT_REC`/`MFG_KR_ISU_REC` all drive MFG off a sales order: join
  `SL_ORD_DETL`, carry `ORD_NO/ORD_YRCD/ORD_DBCD/ORD_DESIGN` (`TR_MFG_GHAT_REC.cs:3540,3544`;
  `TR_MFG_KR_ISU_REC.cs:4370,6353`; `TR_MFG_ORD_ISU.cs:6180`). The web has **no order→manufacturing
  linkage** anywhere (no page, no route, no `ORD_*` columns populated in MFG writes).

### G(new) — With-lot (`ITM_LOT`) lot-merge engine absent (BREADTH)
- Desktop `TR_MFG_WITH_LOT.cs:3247,3251,3280` aggregates loose stock by `ITM_LOT` from `MAIN_STOCK`
  (`SUM(ITM_SIGN='+' THEN ITM_PCS ELSE -ITM_PCS)`, `ITM_LOT NOT IN (...)`, `TAG_NO='N'`) to merge lots
  into a manufacturing issue. Web writes `ITM_LOT` only as a passive `MAIN_STOCK`/`LOT_NO` passthrough
  (`mfg.ts stockRows ITM_LOT:l.lotNo`); **no lot-balance / lot-merge logic, no `LOT_DETL`** (grep
  `MFG_WITH_LOT|LOT_DETL` over `apps/api/src` = 0).

### G10 — Melting loss model + footprint
- Desktop stores `NET_FINE = PARTY_FINE` and tracks loss as a **separate component** (LOSS_WT col-16,
  derived from assay-vs-input touch): `TR_MLT_PRO.cs:4229 PARTY_FINE=col8; :4230 NET_FINE=col8`;
  `:3983 LOSS_WT`. Web `meltLine` (`melting.ts:20`) **reduces** NET_FINE by a flat `lossPct`
  (`netFine = partyFine×(1−loss/100)`) — different model (the `recoveredFine` override is the closer
  analogue). Footprint: desktop also writes `MAIN_STOCK`+`MFG_ISU_REC`+`TEMP_BOOK_DATA`+`REMARK_DATA`;
  web writes **only `MLT_DATA`+`MLT_DETL`**, empty AC_DATA.
- ✅ Input fine PARITY: `NWT×touch/100` (`TR_MLT_PRO.cs` col-8 ≡ `melting.ts:20`); real MLT row
  100×85/100 = 85 ✓.

### G11 — Karigar footprint (beyond the now-correct stock + metal leg)
- Desktop `TR_KR_ISU` also writes `ROJ_MEL_DATA` (Kr_Isu_Rojmel), `MFG_ISU_REC`, `TAX_DATA`,
  `DM_DATA/DM_KR_DATA` (stones), `BAR_DETL/BAR_IDTL` (tagged pieces — `TR_KR_ISU.cs:3318-3400`),
  `TEMP_BOOK_DATA`, `REMARK_DATA`. Web `karigar.ts` writes `KR_DATA, KR_DETL, AC_DATA(metal G + labour A),
  MAIN_STOCK`. **Missing: day-book (ROJ_MEL), MFG_ISU_REC projection, tax, stones, tag pieces, temp,
  remark.** (Stock direction, metal legs, and wastage fine are now all correct.)

### DB FOOTPRINT — tables written, web vs desktop
| Voucher | Desktop writes | Web writes | Missing in web |
|---|---|---|---|
| Karigar isu/rec | KR_DATA, KR_DETL, AC_DATA(G+A), MAIN_STOCK, ROJ_MEL_DATA, MFG_ISU_REC, TAX_DATA, DM_*, BAR_DETL/IDTL, TEMP_BOOK, REMARK | KR_DATA, KR_DETL, AC_DATA(G+A), MAIN_STOCK | ROJ_MEL, MFG_ISU_REC, TAX, DM_*, BAR_*, TEMP_BOOK, REMARK |
| MFG isu/rec | MFG_DATA, MFG_DETL, MFG_IDTL, MFG_ISU_REC(multi-row), MAIN_STOCK, ROJ_MEL, TEMP_BOOK, REMARK, AC_DATA(if labour) | MFG_DATA, MFG_DETL, MFG_IDTL, MFG_ISU_REC(1-row), MAIN_STOCK, AC_DATA(if labour) | ROJ_MEL, TEMP_BOOK, REMARK; stage pipeline inert |
| Melting | MLT_DATA, MLT_DETL, MAIN_STOCK, MFG_ISU_REC, TEMP_BOOK, REMARK | MLT_DATA, MLT_DETL | MAIN_STOCK, MFG_ISU_REC, TEMP_BOOK, REMARK |
| Jobwork | MFG_DATA, MFG_DETL, MFG_IDTL, +ledger/rojmel/stk/ord-adj | KR_DATA, KR_DETL (**wrong**) | ALL MFG_* + ledger/rojmel/ord-adj |

So the schema is 100% column-complete (per `xdb-matrix.md`); every gap above is a **write-path /
population** gap, never a missing column. Web does NOT write `MFG_ISU_REC` for karigar/melting, does NOT
write the with-lot/order/ghat MFG family, and writes `KR_*` where desktop writes `MFG_*` (jobwork).

---

## 4. PARITY CONFIRMED (verbatim, both-side proof)
- **MFG RecWt / ghat-loss-chol-ghis reconciliation** — `TR_MFG_ISU_REC.cs:4561` ≡ `mfg.ts recWt` +
  `mfgLotBalance` SQL.
- **MFG INOUT convention** issue=`O`/receive=`I` (`mfg.ts:62-63`) matches desktop book direction
  (opposite of intuition; same as karigar).
- **Karigar INOUT direction + metal-leg sign + wastage fine** — `O`/`I`, `G`/`-`/`+`,
  `NWT×(touch+west)/100` (`karigar.ts:27,28,36` + metal legs) ≡ real KR_DETL/AC_DATA/MAIN_STOCK rows.
- **Melting input fine** `NWT×touch/100` (`melting.ts:20` ≡ `TR_MLT_PRO.cs` col-8; real 100×85/100=85).
- **Pure-metal vouchers post no AC_DATA money** unless labour — MFG/karigar/melting all empty-or-labour
  ledger; metal legs are 0-amount `G` legs (balanced).
- **Routes auth+RBAC guarded** — `/mfg/*`, `/karigar/*`, `/melting` all `preHandler:requireAuth` +
  `guard(...,'create'|'delete')` (`txn.ts`); idempotent delete-then-insert via `postVoucherTx`/
  `reverseVoucherTx` (`posting.ts`) mirrors desktop DELETE→INSERT save.

## 5. RUNTIME CANNOT-VERIFY (honest limits)
`MFG_DATA/MFG_DETL/MFG_IDTL/MFG_ISU_REC = 0`, `MFG_MAST = 0` ⇒ no MFG/jobwork/with-lot voucher exists to
diff row-for-row, and the stage pipeline cannot be exercised at all. Those verdicts are **code-level**
(both sides cited). **Karigar (22 real lines) and the 1 melt row are the only runtime anchors** — and the
karigar direction/metal-leg fixes ARE confirmed against those real rows (§0).

## 6. VERDICT TALLY: OK(full)=0 · DEPTH=4 (#1,#4,#8,#9) · BREADTH=5 (#2,#3,#5,#6,#7,#10 → jobwork wrong-table) · sub-formula parity verbatim (§4)
Fix-first risks: **(a)** jobwork → MFG_* tables (G2, breadth-critical); **(b)** MFG_ISU_REC not projected
for karigar/melting + stage pipeline inert (G9/G11); **(c)** melting loss model (G10); **(d)** day-book
(ROJ_MEL_DATA) absent across all three; **(e)** order-linked/with-lot MFG family entirely missing.
RESOLVED this session: karigar INOUT inversion + metal sub-ledger leg (verified vs real data).
