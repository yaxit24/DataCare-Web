# AUDIT C — INDEPENDENT PARITY AUDIT: Manufacturing + Loans/Dhrn

_Session `audit_C_mfg_dhrn`. 2026-06-30. Independent, evidence-only. Every claim cites real `file:line`
on BOTH the desktop (decompiled C# WinForms, `unified/src/csharp_nextdm/DataCareNext/`) and the web
(`web/apps/api`, `web/apps/web`) side. Runtime row-level behaviour is marked **CANNOT-VERIFY** where the
backing tables are empty. Methodology: read desktop save/ledger/stock builders, read web service+routes+
forms, diff against prior specs (`spec-mfg.md`, `spec-dhrn.md`), and verify against live Postgres
(`docker exec web-postgres-1 psql -U datacare -d datacare`)._

## 0. Data reality (decides what is runtime-verifiable)
`SELECT count(*)` on the audited tables (this session):

| table | rows | table | rows | table | rows |
|---|--:|---|--:|---|--:|
| MFG_DATA | 0 | MFG_DETL | 0 | MFG_IDTL | 0 |
| MFG_ISU_REC | 0 | MFG_MAST | 0 | MLT_DATA | **1** (web-created) |
| MLT_DETL | **1** | KR_DATA | **17** | KR_DETL | **22** |
| KR_IDTL | 0 | DHRN_ISU_DATA | 0 | DHRN_ISU_DETL | 0 |
| DHRN_REC_DATA | 0 | DHRN_REC_DETL | 0 | DHRN_DATA | 0 |
| APR_DATA | 0 | APR_DETL | 0 | APR_IDTL | 0 |
| REP_DATA | 0 | REP_DETL | 0 | | |

⇒ **Only Karigar (KR_*) carries migrated desktop rows** → real-data verifiable. The 1 MLT row is
web-created (`tenant_id='default'`, `VCH_TYPE='MELT'`). MFG / DHRN / APR / REP are greenfield-empty →
formula & footprint verified by **code on both sides**; runtime output is CANNOT-VERIFY.

Schema reality (`project-memory/parity/xdb-matrix.md`, 2026-06-29): all 141 common tables are
**100% column-complete** — so every gap below is a *write-path/population* gap, never a missing column.

---

## 1. VERDICT TABLE

| # | Area | Verdict | Desktop evidence (file:line) | Web evidence (file:line) |
|---|---|---|---|---|
| 1 | MFG issue/receive footprint + ghat/loss math | **PARTIAL** | RecWt formula verbatim `TR_MFG_ISU_REC.cs:4561,5372,5376`; footprint `:5753-6103`; INOUT=`FormBookInOut` `:5787`; MFG_ISU_REC re-projected via `Ac_Tax.*_Mfg` (multi-row ISR_NO) | `mfg.ts:114 recWt`, `:730 mfgLotBalance`, `:61-62 INOUT 'O'/'I'`; one ISU_REC row/line `isuRecRows`; footprint `issueMfg/receiveMfg` |
| 2 | MFG with-lot (`TR_MFG_WITH_LOT`) | **GAP** | full lot engine `TR_MFG_WITH_LOT.cs:5946-6337` (MFG_DATA/DETL/IDTL/MFG_ISU_REC/MAIN_STOCK + LOT_DETL, `ITM_LOT`) | no web module; `grep ITM_LOT` → only `mfg.ts:613` (passes lotNo, no lot-merge); schema lacks `ITM_LOT/LAST_IR_TYPE/REC_*` (spec-mfg §5) |
| 3 | Karigar issue/receive TR_TYPE sign + MAIN_STOCK | **PARTIAL** | INOUT=`FormBookInOut` `TR_KR_ISU.cs:5101`; fine grid `:5125`; footprint `:5179-5329`; real data: issue→`O`, receipt→`I` | MAIN_STOCK signs `karigar.ts stockRows` = **PARITY**; but `karigar.ts:27-28 INOUT_ISSUE='I'/RECEIPT='O'` **INVERTED**; fine `:36` PARITY |
| 4 | Melting (`TR_MLT_PRO`) purity/fine | **PARTIAL** | fine=wt×touch/100 `TR_MLT_PRO.cs:2695`; NET_FINE=PARTY_FINE, loss separate `:4065-4072,4131-4138`; footprint `:3985-4240` | `melting.ts:20 meltLine` partyFine=nwt×touch/100 PARITY; loss = flat `lossPct` (web-invented) |
| 5 | Jobwork (`TR_JDT_REC`) | **GAP** | writes MFG_DATA/DETL/IDTL `TR_JDT_REC.cs:6114-6116`; `Jdt_Rec_Ledr :6349`, `Jdt_Rec_Rojmel :6352`, `Jdt_Stk :6357` | `jobwork-issue/page.tsx`,`jobwork-receive/page.tsx` → `<KarigarForm label="Job-work"/>` → POST `/karigar/*` (KR_DATA/KR_DETL). **Wrong tables.** No JDT backend |
| 6 | Dhrn issue (`TR_DHRN_ISU`): principal, collateral, interest, DHRN_DATA | **PARTIAL** | interest `TR_DHRN_ISU.cs:6109`; footprint `:5155-5363`; ledger party-Dr + int/charge/metal legs `Ac_Ledr.cs:1064-1162` (legs 01-16) | principal+collateral+DHRN_DATA written `dhrn.ts:120-160`; interest `:26 accruedInterest`; ledger `:54-58` Dr `'DHRN'`/Cr `'CASH'` only |
| 7 | Dhrn receipt/repay (`TR_DHRN_REC` + `TR_REP_REC`) | **GAP** | auto-interest `TR_DHRN_REC.cs:6896-7070`; footprint `:6122-6386`; 17 ledger legs `Ac_Ledr.cs:1105`; `TR_REP_REC.cs:4657-4976` (REP_DATA) | `dhrn.ts:184 receiveDhrn` takes client `interest`; writes only DHRN_REC_DATA+AC_DATA(3 legs); no DHRN_DATA/DETL/MAIN_STOCK/ISU_REC; no REP_* module |
| 8 | Dhrn interest (`TR_DHRN_INTREC`) formula (monthly vs day-count, INT_YEAR_DAYS) | **PARTIAL** | monthly `TR_DHRN_INTREC.cs:5377,5524`; day-count `:5553`; whole-month snap `:5387`; compounding `:5412-5426`; denom `MsIntYearDays` | `dhrn.ts:26 accruedInterest` (day-count matches), `:41 monthlyTermInterest`; `:20 DEFAULT_YEAR_DAYS=360` hard-coded; interest endpoint computes **nothing** |
| 9 | Approval/tour (`TR_APR_ISU`) APR footprint + EMP_CODE | **PARTIAL** | footprint `TR_APR_ISU.cs:6101-6685` (APR_DATA/DETL/IDTL+IMAGE+MAIN_STOCK+DM_DATA+BAR_DETL/IDTL+TEMP+REMARK) | `tour.ts tourIssue` writes APR_DATA/APR_DETL/MAIN_STOCK; `EMP_CODE` sliced to 3 chars; no APR_IDTL-on-issue/IMAGE/DM/BAR/TEMP/REMARK |
| 10 | DB footprint desktop-vs-web column diff | **PARTIAL** | desktop save paths populate full derived set (ROJ_MEL_DATA, TEMP_BOOK_DATA, REMARK_DATA, TAX_DATA, DM_DATA, IMAGE_DATA, MFG_ISU_REC) | schema 100% (`xdb-matrix.md`); web writers populate strict **subset** of tables & columns (per rows 1-9) |
| 11 | Interest rounding + outstanding calc | **GAP** | round by type: cash `Round(..,0)` `TR_DHRN_ISU.cs:6118`, metal `Round(..,3)` `:6109`; OS sums `DHRN_DATA` + nets `UnchakRec` (spec-dhrn §4.1) | `dhrn.ts round2` always (2dp); outstanding sums `DHRN_REC_DATA.DHRN_REC_AMT` `reports.ts:138` + `dhrn.ts outstandingTx`; ignores UNCHAK |

---

## 2. GAPS FOUND (detailed, with both-side citations)

### G1 — Karigar `KR_DETL.INOUT_TYPE` is INVERTED in the web (real-data-proven bug)
Desktop-migrated data: `KR_DETL` has `INOUT_TYPE='O'` ×1 (raw issue, fine=NWT, touch=0) and `'I'` ×21
(finished receipts, fine = NWT×(touch+west)/100). Cross-checked against `MAIN_STOCK`:
`KARIGAR ISSUE | O | - | 1` and `KARIGAR RECEIPT | I | + | 21`. So desktop = **issue→`O`, receipt→`I`**
(`TR_KR_ISU.cs:5101` writes `INOUT_TYPE = FormBookInOut`).
Web declares the opposite: `karigar.ts:27 INOUT_ISSUE='I'`, `:28 INOUT_RECEIPT='O'`. `karigarMetalBalance`
(`karigar.ts balanceTx`) sums issued where `INOUT_TYPE='I'` and received where `='O'` → over the 22
migrated rows it treats the 21 receipts as issues and the 1 issue as a receipt ⇒ **inverted balance**.
NOTE: the MAIN_STOCK side (`stockRows`: issue `O`/`-`, receipt `I`/`+`) IS correct — only `KR_DETL.INOUT_TYPE`
is flipped, and it is also internally inconsistent with karigar's own MAIN_STOCK direction.

### G2 — Jobwork posts to the WRONG tables
Desktop `TR_JDT_REC` is a manufacturing-shaped voucher: `TR_JDT_REC.cs:6114-6116` writes
`MFG_DATA/MFG_DETL/MFG_IDTL`, with `Ac_Ledr.Jdt_Rec_Ledr` (`:6349`), `Ac_Rojmel.Jdt_Rec_Rojmel` (`:6352`),
`Ac_Stock.Jdt_Stk` (`:6357`), plus `SL_ORD_ADJ`/`REMARK_DATA`/`TAG_PRINT_DATA`. The web jobwork pages are
literal karigar aliases — `jobwork-issue/page.tsx` → `<KarigarForm mode="issue" label="Job-work"/>`,
`jobwork-receive/page.tsx` → `mode="receive"` — POSTing `/karigar/issue|receive` which write `KR_DATA/KR_DETL`.
No `MFG_*` rows, no `ROJ_MEL_DATA`, no jobwork ledger. `grep -i 'jobwork|JDT'` over `apps/api/src` → 0 hits.

### G3 — Dhrn GL postings use generic control accounts; borrower ledger never carries the loan
Desktop `Ac_Ledr.DhrnIsu_Ledr` (`Ac_Ledr.cs:1064`): **leg 01** = `AC_CODE = A.AC_CODE` (the borrower) DR
`DHRN_AMT`, contra `LD_CODE=A.LEDR_ACCD`; leg 02 = cash `LEDR_ACCD` CR; legs 03/04 = INT_AMT (party DR /
interest-income `BOOK_DETL.SR_NO=2`); 05/06 = INT_REC_AMT (`SR_NO=1`); 07/08 = OTH_AMT (`SR_NO=3`); 09/10 =
metal `IT_TYPE=LOAN_TYPE, SIGN '-'/'+', FINE_WT=DHRN_AMT` for G/S; 11-16 = `MsOpDhiran` opening.
Web `buildDhrnIssueLedger` (`dhrn.ts:54-58`): only `Dr 'DHRN' / Cr 'CASH'` (hard-coded literals,
`loanAc='DHRN'`, `cashAc='CASH'`). The **borrower (`borrowerAc`) appears only in the header, not in any
AC_DATA leg** → the customer's ledger/statement/trial-balance will not reflect the pledge loan. Interest
accrual / charges / metal-weight legs are entirely absent. Same defect on repay (`DhrnRec_Ledr` 17 legs incl.
KASAR `SR_NO=3`, rate-cut gold `00003`/silver `00004`, `RCUT_PAY`, metal SIGN/FINE — vs web `dhrn.ts:73-74`
Dr `CASH`/Cr `DHRN`/Cr `INTINC`) and interest-only (`DhrnIntRec_Ledr` `Ac_Ledr.cs:1150`, KASAR via `00057`).

### G4 — Dhrn derived tables not written by web (ROJ_MEL_DATA / MAIN_STOCK / TEMP_BOOK / IMAGE / REMARK)
Desktop issue footprint (`TR_DHRN_ISU.cs:5155-5363` deletes + helper re-inserts):
`DHRN_ISU_DATA, DHRN_ISU_DETL, TEMP_BOOK_DATA, AC_DATA, ROJ_MEL_DATA, DHRN_DATA, MAIN_STOCK (metal,
`Ac_Stock.Dhrn_Isu_Stk`), IMAGE_DATA, AC_IMAGE, REMARK_DATA`. Web `issueDhrn` (`dhrn.ts:120-160`) writes
only `DHRN_ISU_DATA, DHRN_ISU_DETL, DHRN_DATA, AC_DATA`. Missing: **ROJ_MEL_DATA (day-book)** — dhiran will
not appear in the rojmel/day-book; **MAIN_STOCK** custody for gold/silver loans (`LOAN_TYPE≠'A'`); plus
TEMP_BOOK_DATA, IMAGE_DATA/AC_IMAGE (collateral & party photos), REMARK_DATA.

### G5 — Dhrn repayment does not write the `DHRN_DATA` movement row, nor close the issue
Desktop `TR_DHRN_REC` posts `DHRN_DATA` via `Ac_Tax.DhrnRec_Data` and `UPDATE DHRN_ISU_DATA SET ISU_REC='Y'`
on full repay (`TR_DHRN_REC.cs:6122-6386` footprint). Web `receiveDhrn` (`dhrn.ts:184-240`) writes only
`DHRN_REC_DATA` + `AC_DATA`; it never inserts `DHRN_DATA`, never writes `DHRN_REC_DETL` (returned-items grid),
never releases `MAIN_STOCK`, and never flips `ISU_REC`. (Inconsistent even internally: `receiveDhrnInterest`
DOES write `DHRN_DATA` at `dhrn.ts:270`, but `receiveDhrn` does not.)

### G6 — Repayment/interest interest is operator-typed, not server-computed
Desktop computes interest server-side in the form: `TR_DHRN_REC.cs:6896-7070` and
`TR_DHRN_INTREC.cs:5343-5562` implement (a) day-count vs monthly (`CurIntTypeCalc='M'`), (b) whole-month
bucketing `num6=Round(|days|/365×360/30); nIntDays=num6×30` then snap `:5387`, (c) annual 360-day
compounding when `chkInt && nIntYear>1` `:5412-5426/:6914-6926`. The web `receiveDhrn`/`receiveDhrnInterest`
accept `interest` as a request field (`txn.ts` `/dhrn/receipt`,`/dhrn/interest`; forms `dhrn-receipt/page.tsx`,
`dhrn-interest/page.tsx` have a free-text Interest input). The engine `accruedInterest`/`monthlyTermInterest`
(`dhrn.ts:26,41`) exists and the **simple** day-count branch matches, but is unused by these endpoints and
omits bucketing + compounding.

### G7 — Interest rounding precision differs by loan type
Desktop rounds interest to **0 dp for cash** (`Round(..,0)` `TR_DHRN_ISU.cs:6118`, format `"0.00"`) and
**3 dp for metal** (`Round(..,3)` `:6109`, `"0.000"`); `TR_DHRN_INTREC.cs:5524` (3dp) / `:5540` (0dp). Web
uses `round2` everywhere (`dhrn.ts accruedInterest`/`monthlyTermInterest`) → fractional-rupee cash interest
and 3-dp metal interest both diverge.

### G8 — Outstanding methodology differs (source table + advance netting)
Desktop OS (`RP_DHRN_OS`, spec-dhrn §4.1) = `DHRN_AMT − (Σ DHRN_DATA.DHRN_REC_AMT + Σ DHRN_DATA.UNCHAK_DHRN_REC)`
grouped per issue. Web computes `DHRN_AMT − Σ DHRN_REC_DATA.DHRN_REC_AMT` — `reports.ts:138`
(`dhrnOutstandingList`) and `dhrn.ts outstandingTx` (the `/dhrn/:isuNo/outstanding` endpoint). It reads
`DHRN_REC_DATA` (not the `DHRN_DATA` movement) and **ignores `UNCHAK_DHRN_REC` advance**.

### G9 — MFG ledger-projection fidelity (single-row vs multi-row; multi-stage reconciliation)
Desktop re-projects `MFG_ISU_REC` through stage-specific `Ac_Tax.<Stage>_<Isu|Rec>_Mfg` that can emit
**multiple rows per detail line** (e.g. Ghat/Setting emit a `+` gross row, a `-` net row and a `-` diamond
row distinguished by `ISR_NO 1/2/3`; spec-mfg §3.4-6), and supports a **consecutive-stage** balance
(`SUM(IR_TYPE=LastProcess …) − SUM(IR_TYPE=CurProcess …)`, `TR_MFG_ISU_REC.cs:4565`). Web `isuRecRows`
(`mfg.ts`) emits exactly one `MFG_ISU_REC` row per line and only the **sign-based** balance
(`mfgLotBalance` `mfg.ts:730`). Because `MFG_MAST` is empty (0 rows) `getStageTx` returns null and the web
defaults `IR_TYPE='G'` — the stage pipeline (LAST/ENTRY/NEXT, STK flags) is inert.

### G10 — Melting loss model + footprint
Input fine PARITY (`partyFine = NWT×touch/100`, web `melting.ts:20` ↔ desktop `TR_MLT_PRO.cs:2695`; real
row 100×85/100=85 ✓). But desktop stores `NET_FINE = PARTY_FINE` and tracks loss as a **separate component
line** (`:4065-4072` main grid loss=0; `:4131-4138` idtl `LOSS_WT` from grid col-12 / assay-touch differential
`:2730`), whereas web reduces `NET_FINE` by a **flat `lossPct`** (`meltLine`) — different model (web's
`recoveredFine` override is the closer analogue). Footprint GAP: desktop also writes `MAIN_STOCK` +
`MFG_ISU_REC` + `TEMP_BOOK_DATA` + `REMARK_DATA` (`TR_MLT_PRO.cs:4152-4240`); web writes only `MLT_DATA/MLT_DETL`.

### G11 — Karigar footprint (beyond stock)
Desktop `TR_KR_ISU.cs:5179-5329` also writes `ROJ_MEL_DATA` (`Kr_Isu_Rojmel`), `MFG_ISU_REC`, `TAX_DATA`,
`DM_DATA`/`DM_KR_DATA` (stones), `BAR_DETL`/`BAR_IDTL` (tagged pieces), `TEMP_BOOK_DATA`, `REMARK_DATA`. Web
`karigar.ts` writes `KR_DATA`, `KR_DETL`, `AC_DATA` (labour only), `MAIN_STOCK`. Day-book / tag / stone /
tax footprint missing.

### G12 — APR/tour footprint + IDTL on issue
Desktop `TR_APR_ISU.cs:6101-6685` writes `APR_DATA/APR_DETL/APR_IDTL`, `IMAGE_DATA`, `MAIN_STOCK`
(`Apr_Isu_Stk`/`Apr_Rtn_Stk`), `DM_DATA`, `BAR_DETL/BAR_IDTL` (tag consumption), `TEMP_BOOK_DATA`,
`REMARK_DATA`. Web `tour.ts tourIssue` writes `APR_DATA/APR_DETL/MAIN_STOCK` only (`APR_IDTL` deleted on
reverse but never inserted on issue). `EMP_CODE` correctly truncated to varchar(3); no `AC_DATA` on issue =
PARITY (pure inventory, both empty). `TR_APR_ISU` also services the tour **return/sale** path which the web
`tourIssue` does not cover.

### G13 — `TR_REP_REC` has no web counterpart
`TR_REP_REC.cs:4657-4976` writes `REP_DATA/REP_DETL` + `AC_DATA` + `ROJ_MEL_DATA` + `TAX_DATA` (a
repairing/job-receipt voucher). No `REP_*` module or route exists in the web (`grep` over `apps/api/src` → 0).

### G14 — Config not honoured (hard-coded vs CO_SET)
Web hard-codes `DEFAULT_YEAR_DAYS=360` (`dhrn.ts:20`) and there is no runtime read of `MsIntYearDays`,
`MsDhrnIntType` (monthly/day toggle), `MsTradFine`, `MsOpDhiran`, or `BOOK_DETL` `SR_NO 1/2/3` sub-accounts.
Desktop drives all of these from `DC_Main`/`BOOK_DETL` (e.g. `TR_DHRN_ISU.cs:6090` branches on `MsDhrnIntType`).

---

## 3. PARITY CONFIRMED (the parts that DO match — with proof)
- **MFG ghat/loss reconciliation formula** — verbatim. Desktop
  `SUM(... '+' THEN (IR_WT+RTN_CHOL+RTN_GHIS+ITM_GHAT+ITM_LOSS))` (`TR_MFG_ISU_REC.cs:4561,5372,5376`) ≡ web
  `recWt` (`mfg.ts:114`) and `mfgLotBalance` SQL (`mfg.ts:730`). MFG `INOUT` convention issue=`O`/receipt=`I`
  (`mfg.ts:61-62`) matches desktop `FormBookInOut` semantics (spec-mfg §1.1; opposite of karigar's bug G1).
- **MFG manufacturing voucher posts no AC_DATA unless labour** — desktop `TR_MFG_ISU_REC` save has no
  AC_DATA write (`:5753-6103`); web posts empty ledger unless `labourAmt>0` (`receiveMfg`). PARITY.
- **Karigar MAIN_STOCK direction** — real data `KARIGAR ISSUE|O|-`, `KARIGAR RECEIPT|I|+` ≡ web `stockRows`. PARITY.
- **Karigar fine-with-wastage** — `NWT×(touch+west)/100`: real `KR_DETL` 19.720×97/100=19.128 ✓ ≡ web
  `fineWithWastage` (`karigar.ts:36`). PARITY.
- **Melting input fine** — `NWT×touch/100`: desktop `TR_MLT_PRO.cs:2695`, real MLT row 100×85/100=85 ≡ web
  `meltLine` (`melting.ts:20`). PARITY.
- **Dhrn ISSUE interest amount (simple/monthly)** — desktop `DHRN_AMT×INT_PRC/100×(30×months)/MsIntYearDays`
  (`TR_DHRN_ISU.cs:6109`) ≡ web `accruedInterest(principal,intPrc,months*30,360)` (`dhrn.ts:26`,used in
  `issueDhrn`) **when MsIntYearDays=360**. Formula structure PARITY; denominator config = GAP (G14).
- **Routes are auth + RBAC guarded** — every `/mfg/*`, `/dhrn/*`, `/melting`, `/karigar/*`, `/tour/*` uses
  `preHandler: requireAuth` + `guard(req,reply,'create'|'delete')` (`txn.ts`). No unauthenticated mutation.
- **Idempotent save** — web uses `postVoucherTx`/`reverseVoucherTx` (`posting.ts`) delete-by-key then
  re-insert in one `withTenant` tx, matching desktop DELETE-then-INSERT (e.g. `TR_DHRN_ISU.cs:5155`).

---

## 4. RUNTIME CANNOT-VERIFY (honest limits)
MFG_*, DHRN_*, APR_*, REP_* are 0-row in `datacare` ⇒ no end-to-end voucher exists to diff row-for-row
against a desktop golden voucher. All MFG/Dhrn/APR/REP verdicts above are **code-level** (both sides cited);
their **runtime output is CANNOT-VERIFY** until a voucher is posted or a desktop golden set is loaded. Karigar
and the single melt row are the only real-data anchors. `MFG_MAST` empty ⇒ the MFG stage pipeline cannot be
exercised at all.

---

## 5. AUDIT_C VERDICT: parity=0 partial=7 gap=4 cannot-verify=0
- **PARTIAL (7):** #1 MFG issue/receive, #3 Karigar sign/stock, #4 Melting, #6 Dhrn issue, #8 Dhrn interest
  formula, #9 APR/tour, #10 DB footprint.
- **GAP (4):** #2 MFG with-lot, #5 Jobwork (wrong tables), #7 Dhrn receipt/repay (+TR_REP_REC absent),
  #11 interest rounding + outstanding.
- **PARITY (0 full bundled):** no bundled area is gap-free, though several *sub-formulas* are verbatim parity
  (§3): MFG RecWt, karigar/melting fine, dhrn issue-interest, MAIN_STOCK signs.
- **CANNOT-VERIFY:** none of the 11 is purely unverifiable (code cited both sides); but ALL MFG/DHRN/APR/REP
  *runtime* behaviour is CANNOT-VERIFY (0 rows) — see §4.

Headline correctness risks (fix first): **G1** karigar INOUT inversion (wrong balances on migrated data),
**G3** dhrn loans never hit the borrower's ledger, **G5** repayment skips DHRN_DATA + ISU_REC close,
**G2** jobwork writes KR_* instead of MFG_*.
