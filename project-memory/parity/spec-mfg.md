# Implementation Spec — MANUFACTURING (MFG) module

_Session `spec_mfg`. Generated 2026-06-29. READ-ONLY research → build spec. Evidence = deep read of
decompiled C# WinForms in `extracted_code/DataCareNext/DataCareNext/` + live Postgres schema
(`web-postgres-1` / db `datacare`). All formulas / table names / column lists cited by file or by
`information_schema`. No app code modified._

Target deliverable this spec enables: `web/apps/api/src/modules/manufacturing/mfg.ts` + routes in
`txn.ts` + web forms under `web/apps/web/app/(app)/txn/mfg-*`.

---

## 0. TL;DR for the implementer

- **Manufacturing is NOT karigar.** The web currently *aliases* it: `app/(app)/txn/mfg-issue/page.tsx`
  is literally `return <KarigarForm mode="issue" label="Manufacturing" />;` and POSTs to
  `/txn/karigar/issue` (writes `KR_DATA/KR_DETL/MAIN_STOCK`). No web code writes any `MFG_*` table.
- Manufacturing is a **multi-stage process pipeline** (melting → ghat/casting → filing → pre-polish →
  mino → setting → assemble → nakshi → polish). Each stage is an **Issue** book and a **Receive**
  book. The "current stage" is encoded as a 1-char **`IR_TYPE`** (a.k.a. `ENTRY_TYPE`) code; each stage
  knows its **`LAST_TRAN`** (previous stage) and **`NEXT_TRAN`** (next stage) from `MFG_MAST`.
- Every stage writes the same 3 voucher tables: **`MFG_DATA`** (header), **`MFG_DETL`** (item lines),
  **`MFG_IDTL`** (sub-components / stones / fittings). On save it then projects rows into the central
  **`MFG_ISU_REC`** metal-flow ledger (signed `+`/`-`) and conditionally into **`MAIN_STOCK`**.
- Metal accountability per lot/karigar is reconciled by:
  **`RecWt = IR_WT + RTN_CHOL + RTN_GHIS + ITM_GHAT + ITM_LOSS`** vs issued `IR_WT`. When
  `IssuedWt − RecWt = 0` the lot/process is fully accounted (loss + chol + ghis + ghat absorb the
  difference). This exact expression appears verbatim in the desktop SQL (see §2.3).
- **DB reality (tenant `default`):** all MFG tables exist but are **empty** — nothing to migrate, this is
  greenfield on the web side:

  | table | columns | rows WHERE tenant_id='default' |
  |---|---:|---:|
  | `MFG_DATA` | 49 | **0** |
  | `MFG_DETL` | 91 | **0** |
  | `MFG_IDTL` | 42 | **0** |
  | `MFG_ISU_REC` | 61 | **0** |
  | `MFG_ASMBL_DETL` | 52 | **0** |
  | `MFG_MAST` | 16 | **0** |

  (`MFG_MAST` being empty means the stage/book registry must be seeded — see §1.3 / build checklist.)

---

## 1. How manufacturing differs from karigar + the process-stage model

### 1.1 Karigar (what the web has today) — for contrast
`web/apps/api/src/modules/manufacturing/karigar.ts`: issue raw fine OUT to a goldsmith, receive
finished ornaments IN; wastage folded into accountable fine on receipt
(`fineWithWastage = NWT × (touch + west)/100`); balance = Σ issued fine − Σ received fine. Writes
`KR_DATA / KR_DETL / MAIN_STOCK` (+ `AC_DATA` only when labour is paid). **One issue, one receive,
two tables, one party.** No process stages, no lot pipeline, no chol/ghis/ghat/loss split.

### 1.2 Manufacturing — the real model
A single physical lot of metal flows through **N sequential shop processes**. At each process the metal
is **issued** to the process (sign `-`) and later **received** back (sign `+`), with the received weight
differing from issued by recoverable scrap (`chol`, `ghis`), casting-gate waste (`ghat`) and
unrecoverable `loss`. The same `MFG_*` tables are reused for every stage; the stage is identified by
the book (`CO_BOOK`/`MAIN_BOOK`) and by `IR_TYPE`/`ENTRY_TYPE`.

Two desktop "shapes" of the same engine exist (controlled by company flags `DC_Main.MsMfgWithOrder`,
`MsMfgWithLot`, `MsMfgOneFormEntry`, `MsMfgWithLedger`):

| Variant | Driver | Forms | Distinct columns used |
|---|---|---|---|
| **Ghat / process** (default) | `Mfg_Module.Mfg_menu_set()` | `TR_MFG_ISU_REC` (simple), `TR_MFG_GHAT_REC` | chol/ghis/ghat reconciliation, no `ITM_LOT` |
| **Order + lot** | `Mfg_Module.Mfg_With_Order()` (`@25`) | `TR_MFG_KR_ISU_REC`, `TR_MFG_WITH_LOT`, `TR_MFG_ORD_ISU/REC`, `TR_MFG_ITEM` | `ITM_LOT`, `LAST_IR_TYPE`, `REC_YRCD/DBCD/NO/SRNO`, `SL_ORD_*` join |

> **Parity note (schema-confirmed):** the live `MFG_ISU_REC` has `LOT_NO` **but NOT** `ITM_LOT`,
> `LAST_IR_TYPE`, `REC_YRCD/REC_DBCD/REC_NO/REC_SRNO`. Those extra columns are referenced only by the
> order+lot `Ac_Tax` projections (`Mfg_Mlt_With_Lot_Isu`, `Kr_Ord_Mfg_Isu`). **The web DB schema matches
> the ghat/process variant.** Build that variant first; treat order+lot as phase 2 (needs columns added).

### 1.3 Stage registry: `MFG_MAST` and `IR_TYPE` codes
Seeded by `Mfg_Module.Mfg_With_Order()` (file `Mfg_Module.cs` method `Mfg_With_Order@25`) and the
ghat-variant `Mfg_menu_set()`. Each row = one Issue or Receive book. Columns used:
`CO_CODE, SM_MAIN_CODE, SM_CODE, CO_BOOK, BOOK_SNAME, MENU_NAME, TRAN_NAME, CUR_IN_USE,
LAST_TRAN, ENTRY_TYPE, NEXT_TRAN, STK_ISU, STK_REC, MAIN_BOOK`.

- **`ENTRY_TYPE`** = this stage's `IR_TYPE` (the "current" process char).
- **`LAST_TRAN`** = previous stage `IR_TYPE` (used to pull the open balance from the prior process).
- **`NEXT_TRAN`** = next stage `IR_TYPE`.
- **`STK_ISU` / `STK_REC`** = `Y/N` flags: does this book post a `MAIN_STOCK` movement on issue / receive.
- **`MAIN_BOOK`** = canonical book name string used in all the `Ac_Tax.*` / `Ac_Stock.*` filters.

**IR_TYPE single-char codes** (decompiled `Mfg_With_Order@25`, `MFG_MAST` inserts):

| char | process | char | process |
|---|---|---|---|
| `L` | Melting (raw) | `M` | Mino / meena |
| `G` | Ghat (cast gate) | `S` | Setting (stones) |
| `D` | Design issue | `A` | Assemble |
| `W` | Wax receive | `N` | Nakshi |
| `C` | Casting | `P` | Polish |
| `F` | Filing | `I` | Filing-2 |
| `R` | Pre-polish | `X` | none / pipeline end |

**Order-variant chain** (`CO_BOOK` → MAIN_BOOK, `LAST→ENTRY→NEXT`):
`300 MLT PRO (L,L,G)` → `301 DESIGN ISU (X,D,W)` → `302 MFG WEX REC (D,W,C)` →
`303 MFG CAST ISU (W,C,C)` → `304 MFG CAST REC (C,C,F)` → `305 MFG FILE ISU (C,F,F)` →
`306 MFG FILE REC (F,F,R)` → `307 MFG PREP ISU (F,R,R)` → `308 MFG PREP REC (R,R,M)` →
`309 MFG MINO ISU (R,M,M)` → `310 MFG MINO REC (M,M,S)` → `311 MFG STNG ISU (M,S,S)` →
`312 MFG STNG REC (S,S,A)` → `313 MFG ASMBL ISU (S,A,A)` → `314 MFG ASMBL REC (A,A,N)` →
`315 MFG NAKSHI ISU (A,N,N)` → `316 MFG NAKSHI REC (N,N,P)` → `317 MFG POLISH ISU (N,P,P)` →
`318 MFG POLISH REC (P,P,X, STK_REC=Y)`.

> Only **`MFG POLISH REC`** (final stage) carries `STK_REC='Y'` → the finished piece enters
> `MAIN_STOCK` as sellable goods. `MFG STNG ISU` does a diamond/stone `STK_ISU` (DM stock less).

**Ghat-variant chain** (`Mfg_menu_set`): `MLT PRO (L)` → `GHAT ISU (L,G,G)` → `MFG GHAT REC (G,G,R)`
→ FILE/PREP/NAKSHI/MINO/STNG/FILE2/POLISH pairs. Per-book `BOOK_IDTL` rows seed the contra accounts:
`CASH ON HAND (00001)`, `PURCHASE GOLD A/C (00008)`, `LABOUR EXP A/C (00056)`, `KASAR AVAK A/C (00042)`.

### 1.4 Lot tracking (`ITM_LOT` / `LOT_NO`)
- `LOT_NO` (on `MFG_DETL`, `MFG_ISU_REC`) = the **working lot** the line belongs to as it travels the
  pipeline. The "pick previous process output" lookups in `TR_MFG_ISU_REC.cs` group by
  `A.LOT_NO, A.IT_CODE` and filter `A.LOT_NO <> ''` and `A.IR_TYPE IN (LastPorcess, CurProcess)`.
- `ITM_LOT` (order+lot variant) = a **stock lot** consumed from `MAIN_STOCK` (untagged lot inventory),
  resolved via `MAIN_STOCK ... WHERE ITM_LOT <> '' AND TAG_NO='N'` (see `TR_MFG_KR_ISU_REC.cs`
  `TEXT_IDTL_KeyDown`). On save the consumed lot is written to `LOT_DETL` via `Ac_Stock.Itm_Mfg_Lot`.
- `TAG_NO` on `MFG_DETL` doubles as the per-process tag/lot label for a tagged piece. New tag numbers
  are generated by `ItmTagGen()` (format: `year-digit + month(2) + lc + 4-digit serial`).

---

## 2. Weight reconciliation: ghat / loss / chol / ghis

### 2.1 Glossary (Gujarati jeweller terms)
- **ITM_GWT / ITM_NWT** — gross / net weight of the piece (net = gross − other/stone wt).
- **ITM_TOUCH** — purity %; **ITM_WEST_PRC** — wastage %.
- **ITM_FINE** — fine (pure) gold = `NWT × touch/100` (+ wastage on the wastage path).
- **ITM_GHT_WT / ITM_GHT_PRC** — *ghat* weight / % — metal lost at the casting gate / sprue, recoverable
  as scrap and re-melted. Stored to `MFG_ISU_REC.ITM_GHAT` on receive.
- **RTN_CHOL** — *chол* = filings/clippings returned (recoverable scrap), with its own item code
  `CHOL_IT_CODE`.
- **RTN_GHIS** — *ghis* = polishing dust / abraded metal returned (recoverable).
- **ITM_LOSS** — genuine unrecoverable process loss.
- **MTRL_WT / MTRL_IT_CODE / RTN_MTRL** — auxiliary material (e.g. solder, kundan) issued/returned.
- **DM_PCS / DM_WT** — diamond/stone pcs & weight carried alongside the gold (not melted).
- **KDM_WT / RTN_KDM / MINO_WT** — kundan / meena auxiliary weights.

### 2.2 Per-row computations (grid → DB), from `CommPassTotal()` in `TR_MFG_ISU_REC.cs`
(grid col map: 10=GrWt, 11=OthWt, 12=NetWt, 13=Ght%, 14=GhtWt, 15=Chole, 16=Ghis, 27=Touch,
28=West%, 29=Fine, 20=LbrRate, 21=LbrAmt, 22=OthAmt, 23=NetAmt, 33=ItRate, 34=ItAmt):

- **NetWt**: `col12 = col10(gross) − col11(other)`.
- **GhtWt from %**: `col14 = col12 × col13 / 100`.
- **Fine**: if touch+west present → `col29 = (col12 + col14) × (col27 + col28)/100`; else `col29 = col12`.
- **Labour amount** by labour type `col19` (`P`=per-pc, `N`=per-net-gram, `K`=per-fine/1000, else %):
  - `P`: `lbrAmt = round(pcs × lbrRate)`
  - `N`: `lbrAmt = round((NetWt+GhtWt) × lbrRate)`
  - `K`: `lbrAmt = round((NetWt+GhtWt) × lbrRate/1000)`
  - default: `lbrAmt = round(gross × lbrRate)`; and reverse `lbrRate` derivations exist (col35×col33/100).
- **NetAmt**: `col23 = lbrAmt(col21) + othAmt(col22)`.
- **DifP/DifWt** (issue mode only): `col24 = isuPcs − pcs`, `col25 = isuGwt − (NetWt+GhtWt+Chole+Ghis+Mtrl)`.

`MFG_IDTL` (sub-components) total in `CommPassTotal_Idtl()`: `conWt = wt × con%/100`; `itAmt = rate×(pcs|wt)`;
`lbrAmt = lbrRate × pcs`; `netAmt = itAmt + lbrAmt`. Component gross sums roll up into the parent line's
`OthWt (col11)` and `OthAmt (col22)`.

### 2.3 The reconciliation formula (EXACT — copy this)
On **receive**, accountable received weight per line/lot is:

```
RecWt = IR_WT + RTN_CHOL + RTN_GHIS + ITM_GHAT + ITM_LOSS
```

and the open balance for a lot at a process is `IssuedWt − RecWt` (HAVING `> 0` ⇒ still outstanding).
Verbatim from the desktop lot-balance lookups (`TR_MFG_ISU_REC.cs` `KrData_Fill` / `AcData_Fill` /
`TEXT_ENTRY_KeyDown`, and `TR_MFG_KR_ISU_REC.cs`):

```sql
SUM(CASE WHEN ITM_SIGN = '-' THEN IR_WT ELSE 0 END)
- SUM(CASE WHEN ITM_SIGN = '+' THEN (IR_WT+RTN_CHOL+RTN_GHIS+ITM_GHAT+ITM_LOSS) ELSE 0 END) AS DifWt
```

On the metal-IN inout side (`BOOK_INOUT='I'`) issued weight is `IR_WT + (ITM_GWT − ITM_NWT)`
(adds back the stone/other weight) — see `KrData_Fill` `INOUT_TYPE='I'` branch.

Process-stage variant (`TranCode='02'`) reconciles **consecutive stages** instead of sign:
```sql
SUM(CASE WHEN IR_TYPE = LastPorcess THEN IR_WT+DM_WT END)
- SUM(CASE WHEN IR_TYPE = CurProcess THEN IR_WT END) AS DifWt
```

### 2.4 How those columns get populated in `MFG_ISU_REC` (from `Ac_Tax.*_Mfg`)
Each receive projection sets `ITM_GHAT = ITM_GHT_WT` (Ghat Rec adds `+ DM_GHT`), `RTN_CHOL = RTN_CHOL`,
`RTN_GHIS = RTN_GHIS`, `RTN_MTRL = MTRL_WT`, `IR_WT = ITM_NWT` (Polish uses `ITM_GWT`), `ITM_SIGN='+'`.
Issue projections set `ITM_SIGN='-'`, `IR_WT = ITM_NWT`, scrap columns `0`. `IR_TYPE = ENTRY_TYPE`.

---

## 3. MFG ISSUE and MFG RECEIVE — fields, computations, EXACT tables written

Both directions use the **same form** (`TR_MFG_ISU_REC` simple / `TR_MFG_KR_ISU_REC` lot) — direction is
driven by the book's `BOOK_INOUT` (`O`=issue/metal-out, `I`=receive/metal-in) and `MFG_MAST`.

### 3.1 Header input fields (→ `MFG_DATA`)
`VchNo` (auto: `MAX(VCH_NO)+1` per CO_CODE/LC_CODE/CO_YEAR/CO_BOOK), `VchDate`, `Party Ac` (`tAcCode`),
`Kr Code` (`tKrCode` — the worker/process party), `Employee` (`tEmpCode`), `Ref/Bill No`, `Vch Desc`,
`Remark`, optional image. Plus a payment grid `MSG2_TOTAL` (NetAmt/Tax/Tot/Cash/Chq/Kasar/OS) for
labour settlement.

### 3.2 Detail grid input (→ `MFG_DETL`, one row per piece/lot)
`LotNo/TagNo`, `ItCode`, `Design`, `Size`, `Pcs`, `GrWt`, `OthWt`, `NetWt`, `Ght% / GhtWt`,
`Chole`, `Ghis`, `MtrlIt / MtrlWt`, `Touch`, `West%`, `Fine`, `LbrType/LbrRate/LbrAmt`, `OthAmt`,
`ItRate/ItAmt`, `NetAmt`, `DM_PCS/DM_WT`, `KrName`. On issue, picking a Lot pre-fills from the prior
process's open balance (the §2.3 query).

### 3.3 Sub-detail grid (→ `MFG_IDTL`, components/stones under a line)
`ItCode/ItName`, `Pcs/Weight`, `Con%`, (`RtnPcs/RtnWt/BrkPcs/BrkWt` for setting), `P/W`, `Rate`,
`ItAmt`, `LbrRate/LbrAmt`, `NetAmt`, `OldItm (Y/N)`, `ConWt`, `ItType`, `RowSrNo` (FK to parent
`MFG_DETL.OLD_SRNO`).

### 3.4 EXACT write order on Save — `BtnSave_Click` (`TR_MFG_ISU_REC.cs`)
1. **DELETE** existing rows for the voucher key from `MFG_DATA`, `MFG_DETL`, `MFG_IDTL` (re-save = replace).
2. **`TEMP_BOOK_DATA`** — header voucher-number reservation row (`CO_CODE,LC_CODE,CO_BOOK,VCH_NO,BOOK_NAME`).
3. **`MFG_DATA`** (header) — key cols set:
   `CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,VCH_DATE,VCH_TIME,AC_CODE,KR_CODE,BILL_NO,BILL_DATE,
   HD_VCH_NO,VCH_TYPE(=BOOK_SNAME),INOUT_TYPE(=BOOK_INOUT),ENTRY_TYPE(=MsPorcessType/IR_TYPE),
   BOOK_NAME(=MAIN_BOOK),NET_AMT,GR_WT(ΣITM_GWT),NET_WT(ΣITM_NWT),FINE_WT(ΣITM_FINE),LBR_AMT,OTH_AMT,
   TOT_AMT,CASH_AMT,CHQ_AMT,BANK_AC,CHQ_NO,KASAR_AMT,BILL_OS,EMP_CODE,VCH_DESC,MAIN_USER,
   DATA_TRFR='N',USER_UPDATE='N',USER_DELETE='N'`. (Tax cols all 0, `AC_GST_TYPE='L'`.)
4. **`MFG_DETL`** (one row per grid line where item/tag set or weights nonzero) — key cols:
   `…key…,SR_NO,OLD_SRNO,IT_CODE,ISU_IT_CODE,ITM_REMARK,TAG_NO,DESIGN_NO,DESIGN_SRNO,ITM_SIZE,
   ITM_PCS,ITM_GWT,ITM_OTH_WT,ITM_NWT,ITM_GHT_PRC,ITM_GHT_WT,RTN_GHIS,RTN_CHOL,MTRL_IT_CODE,MTRL_WT,
   ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,KR_GHAT_WT(0),KR_KUNDAN_WT(0),KR_WAX_WT(0),FTNG_*(0),LBR_TYPE,
   LBR_RATE,LBR_AMT,OTH_AMT,ITM_RATE,ITM_AMT,NET_AMT,DM_PCS,DM_WT,KR_NAME,IT_TYPE='G',
   REP_YRCD,REP_DBCD,REP_NO,REP_SRNO,REP_ADJ='N',MAIN_USER,VCH_TIME`. (`REP_*` = back-pointer to the
   prior-process `MFG_DETL` line this lot came from — the pipeline link.)
5. **`MFG_IDTL`** (components, where pcs+wt+netamt nonzero) — key cols:
   `…key…,SR_NO(=parent OLD_SRNO),TAG_NO,ISR_NO,IT_CODE,IT_PCS,IT_GWT,IT_CON_PRC,IT_CON_WT,
   RTN_PCS,RTN_GWT,BROK_PCS,BROK_WT,IT_RATE_TYPE,IT_RATE,IT_AMT,IT_LBR_RATE,IT_LBR_AMT,IT_NET_AMT,
   OLD_ITM_ISU,IT_TYPE,MAIN_USER`.
6. **DELETE `MFG_ISU_REC`** for the voucher, then **re-project** it via the stage-specific
   `Ac_Tax.<Stage>_<Isu|Rec>_Mfg(book, vchNo)` (gated by company flags `MsMfgWithLedger='Y'` AND
   `MsMfgOneFormEntry='Y'`). Dispatch by `FormMainBook`:
   `GHAT ISU→Ghat_Isu_Mfg`, `MFG GHAT REC→Ghat_Rec_Mfg`, `MFG FILE ISU→Filling_Isu_Mfg`,
   `MFG FILE REC→Filling_Rec_Mfg`, `MFG PREP *→PrePolish_*`, `MFG STNG *→Setting_*`,
   `MFG POLISH *→Polish_*`, `MFG NAKSHI *→Nakashi_*`, `MFG MINO *→Mino_*`. Each is an
   `INSERT INTO MFG_ISU_REC (…61 cols…) SELECT … FROM MFG_DETL A JOIN BOOK_DATA B JOIN ITEM_MAST C
   WHERE MAIN_BOOK=<book> AND ENTRY_TYPE=<IR_TYPE> AND ITM_GWT<>0`. Issue → `ITM_SIGN='-'`,
   receive → `ITM_SIGN='+'` and fills `RTN_CHOL,RTN_GHIS,ITM_GHAT(=ITM_GHT_WT[+DM_GHT]),RTN_MTRL(=MTRL_WT)`.
   Some stages emit **multiple** rows per detail line (e.g. Ghat/Setting emit a `+L` gross row plus a
   `-` net row plus a `-` diamond row; ISR_NO 1/2/3 distinguishes them).
7. **`MAIN_STOCK`** — only when `MFG_MAST.STK_REC='Y'` or `STK_ISU='Y'`:
   - `Ac_Stock.Mfg_Stk(book,vch)` → final goods IN (`TR_TYPE='I',ITM_SIGN='+'`, from `MFG_DETL` where
     `MFG_MAST.STK_REC='Y'`, i.e. Polish Rec).
   - `Ac_Stock.Mfg_DM_Stk_Less(book,vch)` → diamonds/components OUT for Setting Issue
     (`TR_TYPE='O',ITM_SIGN='-'`, from `MFG_DETL`+`MFG_IDTL`; lot/order branches differ).
   - `Ac_Stock.Mfg_Isu_Rec_Stk(book,vch)` (lot variant) → multi-row: material OUT, chol IN, finished
     lot IN/OUT keyed by `ITM_LOT`/`ITM_LOT_AC_CODE`.
   - `MAIN_STOCK` insert column list (47 cols, reuse the project's existing stock writer):
     `CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,STK_DATE,VCH_TYPE,BOOK_NAME,AC_CODE,
     IT_CODE,TAG_NO,VCH_SRNO,TBL_CODE,TR_TYPE,ITM_SIGN,ITM_QTY,ITM_PCS,ITM_GWT,ITM_NWT,ITM_TOUCH,
     ITM_WEST,ITM_FINE,ITM_RATE,ITM_AMT,LBR_RATE,LBR_AMT,OTH_AMT,ITM_MRP,NET_AMT,KR_NWT,KR_TOUCH,
     KR_WEST,KR_FINE,KR_LBR_AMT,KR_OTH_AMT,KR_COST,EMP_CODE,ENTRY_TIME,MAIN_USER,DATA_TYPE,DESIGN_NO,
     ITM_SIZE,ITM_DESC,GHT_PRC,ITM_LOT,ITM_DISC`.
8. **`AC_DATA`** (ledger): manufacturing voucher itself is a **pure metal/weight movement → does NOT post
   amount to `AC_DATA`** unless labour/cash is settled in `MSG2_TOTAL` (then a Dr LABOUR / Cr party pair,
   same shape as karigar receive). Remark side-table `REMARK_DATA` via `Ac_Tax.Vch_Remark`.
9. On Delete (`BtnDelete_Click`): insert `DELETE_DATA` audit row; reset `MFG_DETL.REP_ADJ='N'` on the
   parent line (frees the consumed prior lot); delete from `MAIN_STOCK` (if STK), `TEMP_BOOK_DATA`,
   `REMARK_DATA`, `MFG_ISU_REC`, `MFG_DATA`, `MFG_DETL`, `MFG_IDTL`.

### 3.5 Display / lookups (read path)
`DISPLAY_DATA()` loads `MFG_DATA` → header, `MFG_DETL ORDER BY SR_NO` → grid (join `ITEM_MAST` for name),
`MFG_IDTL ORDER BY SR_NO,ISR_NO` → component grid. Prior-process picker = the §2.3 balance query.
`F1` voucher list = `MFG_DATA` join `AC_MAST` (VchNo, date, party, ref, desc, user, GrWt, NetWt).

---

## 4. Order-based MFG (`TR_MFG_ORD_*`)

Used when `DC_Main.MsMfgWithOrder='Y'` (registry from `Mfg_With_Order@25`). The pipeline is driven by a
**sales order** (`SL_ORD_DATA/SL_ORD_DETL/SL_ORD_IDTL`) instead of an ad-hoc lot. Extra `MFG_DETL`
columns carry the order link: `ORD_NO, ORD_YRCD, ORD_DBCD, ORD_AC_CODE, ORD_DESIGN, ORD_SRNO`
(grid cols 70–77 in `TR_MFG_KR_ISU_REC`).

- **`TR_MFG_ORD_ISU`** (Design Issue against order): grid pulls open order lines
  `SL_ORD_DETL WHERE DESIGN_ISU='N' AND TAG_STK_LESS<>'Y'`; on save writes `MFG_DATA/MFG_DETL/MFG_IDTL`
  (with `ORD_*` set), then `UPDATE SL_ORD_DETL SET DESIGN_ISU='Y'` for the consumed order line, projects
  `MFG_ISU_REC` (issue), and `MAIN_STOCK` via `Ac_Stock.Mfg_DM_Stk_Less` for stones (`MsMfgWithOrder`
  branch keys SR_NO>100). Generates the working tag via `ItmTagGen`.
- **`TR_MFG_ORD_REC`** (final receive against order): writes the same trio + `MFG_ASMBL_DETL`
  (assembly breakdown: `REC_YRCD/REC_DBCD/REC_NO/REC_SRNO`, `ORD_*`, `ITM_*`, `LBR_AMT,OTH_AMT,NET_AMT`),
  projects receive rows, and posts finished goods to `MAIN_STOCK` (`Ac_Stock.Mfg_Stk_Rec_With_Ord` →
  OUT from the in-process karigar SR_NO 98, IN as finished SR_NO 99, for
  `MFG MINO/STNG/POLISH ISU` ↔ `MFG GHAT/MINO/STNG REC`).
- **`TR_MFG_ITEM`** (`MFG REC ITEM` / `MFG ISU ITEM` books): item-level (non-process) issue/receive that
  also writes `LOT_DETL` via `Ac_Stock.Itm_Mfg_Lot` and stock via `Ac_Stock.Mfg_Itm_Isu_Rec_Stk`
  (OUT from `MFG ISU ITEM`, IN to `MFG REC ITEM`).
- **`TR_MFG_WITH_LOT`** (`MsMfgWithLot`): lot-merge UI (`MSG_ADJ` grid, `Lot Merge` checkbox) that
  re-keys several working lots onto one; consumes untagged `MAIN_STOCK` lots (`ITM_LOT`, `TAG_NO='N'`)
  and writes `LOT_DETL`. Needs `MFG_ISU_REC.ITM_LOT/LAST_IR_TYPE/REC_*` (currently absent in web schema).

`ItemCreate()` (`Mfg_Module.cs` `@1787`) seeds the auxiliary item/product masters the pipeline needs
(`PRODUCT_MAST` + `ITEM_MAST` for `WX`=Wax, `MT`=Moti, `ZM`=Zumkhi, `MN`=Mino, `CP`=Copper, `RN`=Rani),
gated by `MsMfgType` (`J`=jewellery, `M`=mino). All are `IT_TYPE='O'` (non-gold) except `RN` (`G`).

---

## 5. Data model quick reference (live schema, tenant-scoped)

**`MFG_DATA`** (49): `VCH_TIME,VCH_DATE,BILL_DATE,NET_AMT,TAX_PRC,TAX_AMT,IGST_TAX,CGST_TAX,SGST_TAX,
GR_WT,NET_WT,FINE_WT,LBR_AMT,OTH_AMT,ROF_AMT,TOT_AMT,CASH_AMT,CHQ_AMT,CARD_AMT,KASAR_AMT,BILL_OS,
USER_UPDATE,CARD_AC,USER_DELETE,KR_CODE,HD_VCH_NO,OLD_VCH_NO,NEW_VCH_NO,CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,
VCH_NO,EMP_CODE,BILL_NO,VCH_DESC,VCH_TYPE,INOUT_TYPE,ENTRY_TYPE,tenant_id,BOOK_NAME,AC_CODE,DATA_TRFR,
TAX_CODE,MAIN_USER,BANK_AC,AC_GST_TYPE,CHQ_NO`. PK = `(tenant_id,CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO)`.

**`MFG_DETL`** (91): incl `SR_NO,OLD_SRNO,IT_CODE,ISU_IT_CODE,TAG_NO,LOT_NO,DESIGN_NO,DESIGN_SRNO,
ITM_SIZE,ITM_PCS,ITM_GWT,ITM_OTH_WT,ITM_NWT,ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,ITM_GHT_PRC,ITM_GHT_WT,
RTN_CHOL,RTN_GHIS,MTRL_IT_CODE,MTRL_WT,KR_GHAT_WT,KR_KUNDAN_WT,KR_WAX_WT,KR_MINO_WT,KR_MINO_AMT,
DM_GHT,TOT_GHT,DM_PCS,DM_WT,LBR_TYPE,LBR_RATE,LBR_AMT,OTH_AMT,ITM_RATE,ITM_AMT,NET_AMT,FTNG_GWT,
FTNG_NWT,FTNG_TOUCH,FTNG_FINE,KR_CODE,KR_NAME,IT_TYPE,REP_YRCD,REP_DBCD,REP_NO,REP_SRNO,REP_AC_CODE,
REP_ADJ,ORD_NO,ORD_YRCD,ORD_DBCD,ORD_AC_CODE,ORD_DESIGN,ORD_SRNO,DESIGN_IMG_ID,ITM_REMARK,MAIN_USER,
VCH_DATE,VCH_TIME,VCH_SRNO,…,tenant_id` + standard key cols.

**`MFG_IDTL`** (42): `BROK_WT,ISR_NO,VCH_DATE,VCH_SRNO,IT_PCS,IT_PCS_WT,IT_GWT,IT_CON_PRC,IT_CON_WT,
IT_RATE,IT_AMT,IT_LBR_RATE,IT_LBR_AMT,IT_NET_AMT,DM_PCS_GHT,DM_TOT_GHT,ORD_PCS,ORD_WT,RTN_PCS,RTN_GWT,
BROK_PCS,SR_NO,…key…,HD_VCH_NO,IT_RATE_TYPE,…,TAG_NO,IT_CODE,IT_TYPE,OLD_ITM_ISU,KR_CODE,DM_SIZE,tenant_id`.

**`MFG_ISU_REC`** (61, the ledger): `SR_NO,ISR_NO,IR_SRNO,VCH_DATE,VCH_TIME,IR_PCS,IR_WT,DM_PCS,DM_WT,
ITM_GWT,ITM_NWT,ITM_TOUCH,ITM_WEST,ITM_FINE,KDM_WT,ADD_WT,LESS_WT,RTN_CHOL,RTN_KDM,RTN_GHIS,ITM_GHAT,
MINO_WT,ITM_LOSS,RTN_MTRL,LBR_RATE,LBR_AMT,OTH_AMT,ITM_RATE,ITM_AMT,CR_AMT,DR_AMT,REC_IT_CODE,
CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,VCH_TYPE,INOUT_TYPE,BOOK_NAME,AC_CODE,KR_AC_CODE,IT_CODE,LOT_NO,
DESIGN_NO,ITM_SIZE,IT_TYPE,ITM_SIGN,IR_TYPE,IR_LC,IR_YRCD,IR_DBCD,IR_NO,IR_AC,EMP_CODE,MAIN_USER,
DESIGN_IMG_ID,DATA_TYPE,tenant_id`. **Missing vs order-variant desktop:** `ITM_LOT, LAST_IR_TYPE,
REC_YRCD, REC_DBCD, REC_NO, REC_SRNO, CON_PRC` → add in a migration before building the order+lot variant.

**`MFG_ASMBL_DETL`** (52): assembly breakdown for order-receive (`REC_*`, `ORD_*`, `ITM_*`, `DESIGN_SRNO`,
`LBR_AMT,OTH_AMT,NET_AMT,LOT_NO`).

**`MFG_MAST`** (16): stage/book registry (see §1.3). Must be **seeded** (currently 0 rows).

---

## 6. Step-by-step build checklist

**Phase A — schema + registry (no behaviour yet)**
1. Confirm/extend Prisma models for `MFG_DATA, MFG_DETL, MFG_IDTL, MFG_ISU_REC, MFG_ASMBL_DETL, MFG_MAST`
   (all already exist in PG — generate models if missing). Tenant-scope every query with `withTenant`.
2. Add a migration that adds `ITM_LOT, LAST_IR_TYPE, REC_YRCD, REC_DBCD, REC_NO, REC_SRNO, CON_PRC`
   to `MFG_ISU_REC` (needed only for the order+lot variant — gate behind a flag; safe to defer).
3. Seed `MFG_MAST` + `BOOK_DATA`/`BOOK_IDTL` for the chosen variant. Start with the **ghat/process**
   chain (matches current schema): `MLT PRO, GHAT ISU, MFG GHAT REC, MFG FILE ISU/REC, MFG PREP ISU/REC,
   MFG NAKSHI ISU/REC, MFG MINO ISU/REC, MFG STNG ISU/REC, MFG POLISH ISU/REC` with the
   `LAST_TRAN/ENTRY_TYPE/NEXT_TRAN/STK_ISU/STK_REC/MAIN_BOOK` values from §1.3. Add a `mfg` master config
   entry (one already exists: `MFG_MAST_CONFIG` in `masters/configs.ts`).

**Phase B — core engine `manufacturing/mfg.ts`**
4. Constants: `IR_TYPE` enum (L,G,D,W,C,F,R,M,S,A,N,P,I,X); `INOUT_ISSUE='O'`, `INOUT_RECEIPT='I'`
   (note: opposite of intuition — issue=metal OUT='O'). Rounding: wt `round3`, amount `round2`.
5. Pure functions (unit-test against §2 first):
   - `fineWeight(net,touch)`, `fineWithGhat(net,ghtWt,touch,west)` = `(net+ghtWt)×(touch+west)/100`.
   - `labourAmount(type, {pcs,net,ghtWt,fine,lbrRate})` per `P/N/K/default` (§2.2).
   - `recWt({irWt,rtnChol,rtnGhis,itmGhat,itmLoss})` = the §2.3 sum.
   - `lotBalance(issuedWt, recWtTotal)` = `issuedWt − recWtTotal`.
6. `getStage(coBook)` → reads `MFG_MAST` row (LAST/ENTRY/NEXT/STK flags/MAIN_BOOK).
7. `nextVoucherNo` via existing `nextVoucherNoTx` scoped to `(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK)`.
8. `issueMfg(scope, stageBook, {party, krAc, emp, lines[], components[]})`:
   reserve vchNo → write `MFG_DATA` (header totals) → `MFG_DETL` (sign-agnostic, `ENTRY_TYPE=stage.IR_TYPE`)
   → `MFG_IDTL` → project `MFG_ISU_REC` rows `ITM_SIGN='-'` (`IR_WT=NWT`, scrap=0, `IR_TYPE=stage`) →
   if `stage.STK_ISU='Y'` post `MAIN_STOCK` OUT for components → optional labour `AC_DATA` pair. All in one
   `withTenant` tx (mirror `postVoucherTx` usage in `karigar.ts`).
9. `receiveMfg(...)`: same, but `MFG_ISU_REC` rows `ITM_SIGN='+'` with
   `RTN_CHOL,RTN_GHIS,ITM_GHAT(=ghtWt),RTN_MTRL(=mtrlWt),ITM_LOSS`; set `MFG_DETL.REP_*` to the prior
   line; if `stage.STK_REC='Y'` post finished `MAIN_STOCK` IN.
10. `lotBalance(scope, lotNo|krAc, stageBook)`: run the §2.3 reconciliation SQL against `MFG_ISU_REC`
    (group by LOT_NO/IT_CODE; HAVING DifWt>0 ⇒ outstanding). Expose as the issue-side picker source.
11. `deleteMfg(scope, key)`: reverse exactly the tables in §3.4 step 9 (use `reverseVoucherTx`).

**Phase C — routes (`txn.ts`)**
12. Add real endpoints (replace the karigar alias for mfg):
    `POST /mfg/:stage/issue`, `POST /mfg/:stage/receive`, `GET /mfg/lot/:lot/balance`,
    `GET /mfg/:vchNo` (display), `DELETE /mfg/:stage/:vchNo`, `GET /mfg/stages` (MFG_MAST list).
    Guard with the same `auth`/`guard(req,reply,'create'|'update')` pattern. **Flag the security note:**
    these are authenticated; keep the existing RBAC guard.

**Phase D — web forms**
13. Replace `mfg-issue/page.tsx` + `mfg-receive/page.tsx` (currently `<KarigarForm/>`) with a real
    `MfgForm` (two-grid: detail `MFG_DETL` + component `MFG_IDTL`, header party/kr/emp, totals strip).
    Add a stage selector bound to `GET /mfg/stages`. Wire the prior-process lot picker to
    `GET /mfg/lot/:lot/balance`.
14. Nav already lists `MFG Issue` / `MFG Receive` (`web/apps/web/lib/nav.ts`) and points
    `Order Issue` to `/soon?f=TR_MFG_ORD_ISU` — unblock once Phase E lands.

**Phase E — order + lot variant (optional, after A–D)**
15. Apply the Phase A step-2 migration; seed the `Mfg_With_Order` book chain (300–318); implement
    `SL_ORD_*` consumption (`DESIGN_ISU='Y'` flip), `MFG_ASMBL_DETL`, `LOT_DETL` writes, and
    `Mfg_Stk_Rec_With_Ord`. Build `mfg-order-issue` / `mfg-order-receive` pages.

**Phase F — verification**
16. Unit tests for every §5 formula (golden values; mirror `apps/api/test/karigar.test.ts`).
17. Integration test: full pipeline melting→…→polish on one lot; assert `lotBalance≈0` after final
    receive and a finished `MAIN_STOCK` row exists; assert re-save replaces (no dup) and delete reverses.
18. Parity: load a desktop golden voucher set into `MFG_*` and diff `MFG_ISU_REC` sign/weight columns.

---

## 7. Evidence index (file → what it proves)
- `Mfg_Module.cs` — `Mfg_With_lot@10` (lot-menu seed), `Mfg_With_Order@25` (full stage chain + MFG_MAST +
  BOOK_DATA/BOOK_IDTL inserts → §1.3), `Mfg_menu_set` (ghat-variant chain), `ItemCreate@1787` (aux items).
- `TR_MFG_ISU_REC.cs` — simple issue/receive form: `CommPassTotal` (§2.2), `BtnSave_Click` (§3.4),
  `KrData_Fill`/`AcData_Fill`/`TEXT_ENTRY_KeyDown` (the verbatim `RecWt` SQL §2.3), `DISPLAY_DATA`.
- `TR_MFG_KR_ISU_REC.cs` — lot/order grid (82-col map: ITM_LOT, ORD_*, REC_*), per-stage pickers
  (Casting/Filing/Setting/Wex/CustOrd), `CommPassTotal` lot reconciliation.
- `TR_MFG_GHAT_REC.cs`, `TR_MFG_ORD_ISU.cs`, `TR_MFG_ORD_REC.cs`, `TR_MFG_WITH_LOT.cs`, `TR_MFG_ITEM.cs` —
  §4 order/lot/item variants + `Ac_Tax`/`Ac_Stock` dispatch on save.
- `Ac_Tax.cs` — `*_Isu_Mfg` / `*_Rec_Mfg` (the `INSERT INTO MFG_ISU_REC … SELECT FROM MFG_DETL` projections,
  61-col list, `ITM_SIGN`/`IR_TYPE`/scrap-col mapping §2.4/§3.4-6).
- `Ac_Stock.cs` — `Mfg_Stk`, `Mfg_DM_Stk_Less`, `Mfg_Isu_Rec_Stk`, `Mfg_Stk_Rec_With_Ord`,
  `Itm_Mfg_Lot`, `Mfg_Itm_Isu_Rec_Stk` (the `MAIN_STOCK`/`LOT_DETL` writes §3.4-7).
- `web/apps/api/src/modules/manufacturing/karigar.ts` + `routes/txn.ts` + `app/(app)/txn/mfg-issue/page.tsx`
  — proof the web currently aliases mfg→karigar (§0/§1.1).
- Live DB (`docker exec web-postgres-1 psql …`) — table column lists + 0-row counts (§0/§5).
