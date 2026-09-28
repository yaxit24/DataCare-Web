# Deep Write-Path Verification — SALES + PURCHASE vs real desktop vouchers

**Date:** 2026-06-30 · **cwd:** `/Users/yakshitsavaliya/Desktop/imodule-extracted`
**Method:** Created real web vouchers via the running API (`http://localhost:4000`, admin/Secret#1, coCode 01, tenant `default`), then diffed every voucher-keyed table column-by-column against real desktop vouchers using `apps/api/integration/parity_form.mjs` (plus a throwaway non-truncating clone, since the shipped harness caps display at 8 diffs/table — clone deleted after use, `parity_form.mjs` untouched). **No app code edited.** Every value below is a real DB read, cited desk vs web.

## What was created / compared / cleaned
| Web voucher | Book/Vch | Desktop ref | Why |
|---|---|---|---|
| Sale (tagged line, tag `BBS00001`, local acct `000604`, 3% GST) | `SAL/52` | `026/00001` (TGSL, tagged, BOOK_SNAME=TGSL) | richest tagged sale footprint |
| Purchase (tagged `ZZTESTPUR1`, supplier `000903`, 3% GST) | `PUR/53` | `041/00001` (TGLPR, **taxed** → CGST/SGST split) | TAX_DATA comparison |
| Purchase (untagged fine, IT 999, 0% GST) | `PUR/54` | `035/00001` (FGPR, fine gold) | requested 035 book + MAIN_STOCK footprint |

**Cleanup (verified):** all 3 reversed via API; `DELETE_DATA` audit rows removed; `SRNO_MAST(01,01)` restored 54→51; `TAG_STOCK` ZZTESTPUR1 removed; `BBS00001` sale-flag cleared (available again). **Demo intact: `SL_DATA` = 190 / SUM(TOT_AMT) = 5478196.00 ; `AC_DATA` distinct AC_CODE = 300 ; 0 residual rows in SAL/PUR books.**

## Model confirmed from `BOOK_DATA` (co 01)
- **`BOOK_NAME` column = `BOOK_DATA.MAIN_BOOK`** = constant per class: **`SALES`** (books 026/027/029/030/032) / **`PURCHASE`** (books 035/036/037/038/041/043). Verified: every PR_DETL row in all purchase books has BOOK_NAME='PURCHASE'; every SL_DETL row has 'SALES'.
- **`VCH_TYPE` column = `BOOK_DATA.BOOK_SNAME`** = per-book: 026→`TGSL`, 027→`TSSL`, 032→`MIXSL`, 035→`FGPR`, 036→`FSPR`, 037→`FOGPR`, 041→`TGLPR`.
- **`INOUT_TYPE` = `BOOK_DATA.BOOK_INOUT`** = `O` (sales) / `I` (purchase).

## ✅ Prior fix confirmed live
Purchase `TAX_DATA.TRAN_TYPE` = **`P`** on the web row (PUR/53) — it does **not** appear in the diff vs desktop `041/00001` (also `P`). The recently-fixed `'PR'→'P'` is in place and correct (`purchase.ts:203`). Sales `TAX_DATA.TRAN_TYPE='S'` also matches.

---

# COL DIFF triage tables

Triage classes: **A** = concrete fixable bug (wrong constant / missing easy column / spurious row) · **B** = known structural diff (thin column footprint, LD_CODE contra/mirror layout, metal sub-ledger, tagged-only stock) — documented, not pursued here · **C** = data-value diff only (different test voucher amounts/parties/keys — ignore).

## SALE — desktop `026/00001` vs web `SAL/52`  (harness: 7 tables, 0 footprint-miss, 223 col diffs)

| Table | Column | desk | web | Class | Note / fix |
|---|---|---|---|---|---|
| SL_IDTL | INOUT_TYPE | `O` | *(blank)* | **A** | SL_DETL sets it; idtl omits → add `INOUT_TYPE:'O'` |
| SL_IDTL | ENTRY_TYPE | `S` | *(blank)* | **A** | add `ENTRY_TYPE:'S'` |
| SL_IDTL | VCH_TYPE | `TGSL` | `SALE` | **A** | hardcoded 'SALE'; should be BOOK_SNAME |
| SL_DETL | VCH_TYPE | `TGSL` | `SALE` | **A** | hardcoded 'SALE'; should be BOOK_SNAME |
| AC_DATA | VCH_TYPE | `TGSL` | `SALE` | **A** | hardcoded 'SALE'; should be BOOK_SNAME |
| BILL_OS_DATA | VCH_TYPE | `TGSL` | `SALE` | **A** | hardcoded 'SALE'; should be BOOK_SNAME |
| AC_DATA | SIGN | *(blank)* | `D` | **A**(low) | desktop reserves SIGN for metal +/-; web overloads Dr/Cr (pervasive) |
| TAX_DATA | TAX_TYPE (row0) | `SGST` | `CGST` | **A**(low) | desktop orders SGST(SR1)/CGST(SR2); web CGST-first — cosmetic ordering |
| AC_DATA | LD_CODE | `3`(=contra acct) | `1`(=ordinal) | **B** | contra/mirror-row layout (intentionally not pursued) |
| AC_DATA | LEDR_KEY | `01002024-2025…` | `01012024SAL…` | **B** | key derivation scheme differs |
| AC_DATA | rowcount | 3 | 4 | **B** | mirror-row layout vs net legs |
| TAX_DATA | TAX_CODE | `10` | *(blank)* | **B** | HSN/tax-master code (data-derived; could populate if single GST code) |
| TAX_DATA | R_CHARG, ISR_NO, TAX_FREE_AMT | set | *(blank)* | **B** | thin footprint |
| SL_DATA | *(42 cols)* TAX_CODE, DISC_PRC, EMP_CODE, MOBILE, AC_GST_TYPE, CASH_PAID, SCHM_AMT, TCS_*, TDS_*, HM_*, POINT_VAL, OZ/FX/MTL_RATE, RATE_UNFIX, RTN_*, … | set/0 | *(blank)* | **B** | thin column footprint (web sets ~14 of ~56) |
| SL_DETL | *(50 cols)* DESIGN_NO, ITM_WEST_PRC, ITM_GHT_*, KR_* (karigar), HM_ID*, TAG_GWT/NWT, RATE_TYPE, IT_TYPE, OTH_AMT, ITM_MRP, LBR_RATE/TYPE, … | set | *(blank)* | **B** | thin footprint + wastage/ghat/karigar/hallmark gaps (audit A) |
| SL_IDTL | IT_TYPE, IT_RATE_TYPE, KR_*, IT_DISC_* | set | *(blank)* | **B** | thin footprint |
| BILL_OS_DATA | BILL_GOLD/REC_GOLD/BILL_SILVER/… | 0 | *(blank)* | **B** | metal-OS columns unset (audit A) |
| BILL_OS_DATA | rowcount / AC_CODE | 3 / `221` | 1 / `604` | **C** | desktop voucher carries 3 historical bills |
| MAIN_STOCK | ISR_NO, TBL_CODE, ITM_WEST, KR_*, EMP_CODE, DESIGN_NO, … | set | *(blank)* | **B** | thin footprint (web sets ~16 of ~50) |
| MAIN_STOCK | **VCH_TYPE** | `TGSL` | `TGSL` | — | **MATCHES** (web hardcodes 'TGSL', = book 026 sname by luck) |
| SL_DATA/SL_DETL/AC_DATA/TAX_DATA/MAIN_STOCK | AC_CODE, AC_NAME, NET_AMT, TAX_AMT, TOT_AMT, ITM_*, CGST/SGST_TAX, ROF_AMT, IT_RATE/AMT, … | varies | varies | **C** | different test voucher (ignore) |

## PURCHASE (taxed) — desktop `041/00001` vs web `PUR/53`  (harness: 6 tables, 0 footprint-miss, 164 col diffs)

| Table | Column | desk | web | Class | Note / fix |
|---|---|---|---|---|---|
| TAX_DATA | BOOK_NAME | `PURCHASE` | `PURC` | **A** | wrong constant → `'PURCHASE'` |
| TAX_DATA | TAX_TYPE | `SGST`(+CGST row2) | `L` | **A** | single row; must split CGST/SGST (intra) like sales/purchaseReturn |
| TAX_DATA | TAX_PRC | `1.5` | `3` | **A** | consequence of missing split (per-half = 1.5) |
| TAX_DATA | rowcount | 2 | 1 | **A** | same split bug |
| MAIN_STOCK | BOOK_NAME | `PURCHASE` | `PURC` | **A** | wrong constant → `'PURCHASE'` |
| MAIN_STOCK | VCH_TYPE | `TGLPR` | `TGPR` | **A** | hardcoded 'TGPR' (0 desktop rows); should be BOOK_SNAME |
| AC_DATA | BOOK_NAME | `PURCHASE` | *(blank)* | **A** | createPurchase omits `bookName` to postVoucherTx → set `'PURCHASE'` |
| AC_DATA | VCH_TYPE | `TGLPR` | `PURC` | **A** | hardcoded 'PURC'; should be BOOK_SNAME |
| PR_DETL | BOOK_NAME | `PURCHASE` | *(blank)* | **A** | detl omits → add `'PURCHASE'` |
| PR_DETL | INOUT_TYPE | `I` | *(blank)* | **A** | detl omits → add `'I'` |
| PR_DETL | ENTRY_TYPE | `P` | *(blank)* | **A** | detl omits → add `'P'` |
| PR_DETL | AC_CODE | `530` | *(blank)* | **A** | detl omits supplier → add `input.acCode` |
| PR_DETL | VCH_TYPE | `TGLPR` | `PURC` | **A** | hardcoded 'PURC'; should be BOOK_SNAME |
| BILL_OS_DATA | *(whole row)* | **0 rows** | **1 row** | **A** | desktop never writes BILL_OS on purchase → remove web write |
| AC_DATA | SIGN | *(blank)* | `C` | **A**(low) | as sales (pervasive convention) |
| AC_DATA | LD_CODE / LEDR_KEY / rowcount | contra / `…041…` / 3 | ordinal / `…PUR…` / 5 | **B** | contra/mirror layout; web also adds metal FINE_WT leg |
| AC_DATA | FINE_WT, DATA_TYPE, PARTY_AC_CODE, LDR_NAME | set/0 | *(blank)* | **B** | thin footprint / fine sub-ledger |
| PR_DETL | *(63 cols)* ITM_WEST_PRC, ITM_GHT_*, SILVER_FINE, FINE_CUT_*, RATE_TYPE, IT_TYPE, WITH_STOCK, OTH_AMT, IT_DESC, KR/TAG_*, … | set | *(blank)* | **B** | thin footprint + wastage/ghat/silver/fine-cut (audit B) |
| MAIN_STOCK | ISR_NO, ITM_WEST, KR_*, OTH_AMT, … | set | *(blank)* | **B** | thin footprint |
| PR_DATA | *(30 cols)* DISC_PRC, TAX_CODE, AC_GST_TYPE, BILL_OS, CASH/CARD/CHQ_AMT, TCS/TDS/HM_*, OZ/FX/MTL_RATE, … | set/0 | *(blank)* | **B** | thin footprint |
| TAX_DATA | TAX_CODE / R_CHARG / ISR_NO | `10`/`N`/0 | *(blank)* | **B** | data-derived / thin footprint |
| all | AC_CODE, AC_NAME, NET/TAX/TOT_AMT, ITM_*, CGST/SGST_TAX, ROF_AMT, … | varies | varies | **C** | different test voucher |

## PURCHASE (fine/untaxed) — desktop `035/00001` vs web `PUR/54`  (harness: 6 tables, 1 footprint-miss, 117 col diffs)

| Table | Column | desk | web | Class | Note / fix |
|---|---|---|---|---|---|
| PR_DETL | BOOK_NAME / INOUT_TYPE / ENTRY_TYPE / AC_CODE | `PURCHASE`/`I`/`P`/`903` | *(blank)* | **A** | same purchase-detl omissions as above |
| PR_DETL | VCH_TYPE | `FGPR` | `PURC` | **A** | hardcoded; should be BOOK_SNAME |
| AC_DATA | BOOK_NAME | `PURCHASE` | *(blank)* | **A** | missing `bookName` to postVoucherTx |
| AC_DATA | VCH_TYPE | `FGPR` | `PURC` | **A** | hardcoded; should be BOOK_SNAME |
| AC_DATA | SIGN | *(blank)* | `C` | **A**(low) | pervasive convention |
| TAX_DATA | *(whole row)* | **0 rows** | **1 row** | **A** | web writes a zero-tax TAX_DATA row; desktop writes none → guard on tax>0 |
| BILL_OS_DATA | *(whole row)* | **0 rows** | **1 row** | **A** | desktop never writes BILL_OS on purchase → remove web write |
| MAIN_STOCK | *(whole row)* | **1 row** | **0 rows** | **B** | web writes MAIN_STOCK for tagged lines only; desktop writes for untagged fine metal too (TAG_NO='N') — audit B tagged-only gap |
| AC_DATA | LD_CODE / LEDR_KEY / rowcount | contra / `…035…` / 4 | ordinal / `…PUR…` / 3 | **B** | contra/mirror layout |
| PR_DATA / PR_DETL | thin-footprint cols (CASH_AMT, IT_DESC, RATE_TYPE, IT_TYPE, WITH_STOCK, …) | set | *(blank)* | **B** | thin footprint |
| all | AC_NAME, NET/TOT_AMT, ITM_* | varies | varies | **C** | different test voucher |

---

# 🎯 CONCRETE FIXABLE BUGS (actionable output)

Ordered by confidence/value. All file:line in `web/apps/api/src/modules/`. The PURCHASE path is the main offender — it omits header/detail stamps that the SALES path already sets correctly, so most fixes are "make purchase match the sales template."

### A1 — Purchase `BOOK_NAME` is `'PURC'`/blank; must be `'PURCHASE'` (HIGH)
Desktop column `BOOK_NAME` = `BOOK_DATA.MAIN_BOOK` = `PURCHASE` on every purchase row (MAIN_STOCK/TAX_DATA/AC_DATA/PR_DETL). Web uses `'PURC'` (MAIN_STOCK, TAX_DATA) or leaves it blank (AC_DATA, PR_DETL). Sales already correctly uses `'SALES'`.
- `purchase/purchase.ts:203` `TAX_DATA` taxRow `BOOK_NAME: 'PURC'` → `'PURCHASE'`
- `purchase/purchase.ts:208` `BILL_OS_DATA` osRow `BOOK_NAME: 'PURC'` → `'PURCHASE'` (or removed by A4)
- `purchase/purchase.ts:220` `MAIN_STOCK` mainStock `BOOK_NAME: 'PURC'` → `'PURCHASE'`
- `purchase/purchase.ts:238` `postVoucherTx(tx, tenantId, { ledger…, writes… })` → add `bookName: 'PURCHASE'` (stamps `AC_DATA.BOOK_NAME`, exactly as `sales.ts` does with `bookName:'SALES'`)
- `purchase/purchase.ts:143-159` `detl` rows → add `BOOK_NAME: 'PURCHASE'`
**Evidence:** desk all `PURCHASE`; web `PURC`/blank (PUR/53 & PUR/54 diffs above).

### A2 — Purchase `TAX_DATA` is a single `TAX_TYPE='L'/'I'` row; must split CGST/SGST (HIGH)
Desktop `041/00001`: 2 rows `SGST`+`CGST` @ `TAX_PRC=1.5` each, `TRAN_TYPE='P'`, `TAX_SIGN='-'`. Web: 1 row `TAX_TYPE='L'` @ `TAX_PRC=3`. `TRAN_TYPE='P'` and `TAX_SIGN='-'` are already correct; only the split is missing. Web's own `purchaseReturn.ts` already splits — purchase is the lone outlier.
- `purchase/purchase.ts:202-206` replace the single `taxRow` with the intra/inter split mirroring `sales/sales.ts:287-292`:
  `interState ? [{…TAX_TYPE:'IGST',TAX_PRC:pct,TAX_AMT:igst}] : [{…SR_NO:1,TAX_TYPE:'CGST',TAX_PRC:pct/2,TAX_AMT:cgst},{…SR_NO:2,TAX_TYPE:'SGST',TAX_PRC:pct/2,TAX_AMT:sgst}]` (keep `TRAN_TYPE:'P'`, `TAX_SIGN:'-'`, `BOOK_NAME:'PURCHASE'`).
**Evidence:** desk 2 rows SGST/CGST@1.5; web 1 row L@3 (PUR/53 diff).

### A3 — Purchase `PR_DETL` omits `INOUT_TYPE`, `ENTRY_TYPE`, `BOOK_NAME`, `AC_CODE` (HIGH)
Desktop PR_DETL: `INOUT_TYPE='I'`, `ENTRY_TYPE='P'`, `BOOK_NAME='PURCHASE'`, `AC_CODE=supplier`. Web detl sets none of these. Sales SL_DETL sets the analogues (`sales.ts:168-169` `INOUT_TYPE:'O'`, `ENTRY_TYPE:'S'`, plus `BOOK_NAME`/`AC_CODE`).
- `purchase/purchase.ts:143-159` `detl` map → add `INOUT_TYPE:'I'`, `ENTRY_TYPE:'P'`, `BOOK_NAME:'PURCHASE'`, `AC_CODE: input.acCode`.
**Evidence:** desk `I`/`P`/`PURCHASE`/`530`; web all blank (PUR/53 & PUR/54).

### A4 — Sales `SL_IDTL` omits `INOUT_TYPE` + `ENTRY_TYPE` (HIGH)
Desktop SL_IDTL: `INOUT_TYPE='O'`, `ENTRY_TYPE='S'`. Web idtl omits both (the sibling SL_DETL sets them at `sales.ts:168-169`).
- `sales/sales.ts:196-213` `idtl` map → add `INOUT_TYPE:'O'`, `ENTRY_TYPE:'S'`.
**Evidence:** desk `O`/`S`; web blank (SAL/52 diff).

### A5 — Purchase writes `BILL_OS_DATA`; desktop never does (MED)
Desktop writes **0** `BILL_OS_DATA` rows on purchase (verified: count=0 for books 035/036/037; `[WEB EXTRA]` for 041). `BILL_OS_DATA` is sales-receivables only. Web inserts an `INOUT_TYPE='I'` payable row, polluting the outstanding-bills domain (audit B HIGH #2).
- `purchase/purchase.ts:207-210` (osRow) + `:245` (the `{table:'BILL_OS_DATA', rows:[osRow]}` write) → remove; also drop `'BILL_OS_DATA'` from the `deletePurchase` reverse list at `:269`.
- **Caveat:** confirm `reports.ts billOutstanding`/`outstandingReport` are not relied upon to show purchase payables before removing (parity says remove; a payables view, if wanted, belongs in a different table).

### A6 — `VCH_TYPE` hardcoded; must equal `BOOK_DATA.BOOK_SNAME` (MED — needs a book lookup, not one line)
`VCH_TYPE` is per-book (`TGSL/TSSL/MIXSL/FGPR/FSPR/FOGPR/TGLPR`). Web hardcodes `'SALE'` (`sales.ts:100` ledger base, `:167` detl, `:199` idtl, `:294` osRow), `'PURC'` (`purchase.ts:82,145,196,203,208`), and `'TGSL'`/`'TGPR'` (`sales.ts:221` / `purchase.ts:219` MAIN_STOCK). Sales MAIN_STOCK `'TGSL'` only matches book 026 by coincidence; purchase `'TGPR'` matches **no** desktop book.
- Fix: at voucher start, read `BOOK_DATA.BOOK_SNAME` for `(CO_CODE, CO_BOOK)` and stamp it as `VCH_TYPE` on every row (replacing all hardcoded literals). ~3-5 lines (one lookup + thread the value), not a one-liner.
**Evidence:** desk TGSL/TGLPR/FGPR; web SALE/PURC/TGPR (all three comparisons).

### A7 — `AC_DATA.SIGN` = `'D'/'C'`; desktop leaves it blank for money legs (LOW — pervasive)
Desktop reserves `AC_DATA.SIGN` for metal direction (`+`/`-`); money legs have **blank** SIGN, with Dr/Cr encoded by `DR_AMT`/`CR_AMT`. Web stamps `'D'/'C'` on every money leg. This is a **system-wide** web convention (`sales.ts:108-114`, `purchase.ts:84-88`, salesReturn/purchaseReturn/finance/dhrn/bullion/mfg/karigar/batchReceipt/tagOps/salesOrder all do it). No report filters AC_DATA on `SIGN` (reports use DR_AMT/CR_AMT; `ITM_SIGN`/`TAX_SIGN` are unrelated), so it's cosmetic-but-real.
- Fix (if pursued for parity): stop setting `SIGN:'D'/'C'` on money legs (leave undefined; keep `'+'/'-'` on metal legs). Broad blast radius — treat as a convention decision, not a quick patch.
**Evidence:** desk blank; web `D`(sale)/`C`(purchase) on AC_DATA row0 (all comparisons).

### A8 — Minor: row ordering + zero-tax row
- **TAX_DATA ordering:** desktop emits `SGST`(SR1)/`CGST`(SR2); web emits CGST-first (`sales.ts:290-291`). Cosmetic; flip to SGST-first to match row-for-row. (LOW)
- **Zero-tax TAX_DATA row:** web writes a `TAX_DATA` row even when tax=0 (`purchase.ts:202` taxRow unconditional → PUR/54 `[WEB EXTRA]`); desktop writes none. Guard the write on `totals.tax>0`. (LOW)

---

## Class B (known structural — NOT pursued here, documented in audit-A/audit-B)
- **Thin column footprint** on every shared table — web persists ~14-22 of 50-113 desktop columns (wastage `ITM_WEST_PRC`, ghat `ITM_GHT_*`, karigar `KR_*`, hallmark `HM_ID*`, `SILVER_FINE`, `FINE_CUT_*`, `RATE_TYPE`, `IT_TYPE`, `TAG_GWT/NWT`, `DESIGN_NO`, `EMP_CODE`, `MOBILE`, `TCS/TDS/HM/SCHM/POINT`, `OZ/FX/MTL_RATE`, metal-OS `BILL_GOLD/SILVER`, `DATA_TYPE`, `PARTY_AC_CODE`, `LDR_NAME`, …).
- **`LD_CODE` = line ordinal (web) vs contra account code (desktop)** + the desktop **mirror-row** AC_DATA layout (each entry posted from both account perspectives) → AC_DATA rowcount diffs. Explicitly out of scope.
- **`LEDR_KEY`** derivation scheme differs (`01002024-2025…` desktop vs `01012024SAL…` web).
- **Metal fine-weight sub-ledger** — `AC_DATA.FINE_WT/FINE_RATE` not populated on money legs (web adds separate metal legs on purchase only; desktop's `'29'-'31'` fine legs were 0 on these specific demo vouchers).
- **MAIN_STOCK tagged-only** — web writes stock movement only for tagged lines; desktop also writes for untagged fine metal (`TAG_NO='N'`) → footprint-miss on PUR/54.
- **`TAX_CODE`** (=`10` in demo) data-derived from TAX_MAST — could be populated if a single GST code is assumed, else structural.

## Class C (data-value only — ignored)
All `AC_CODE`, `AC_NAME`, `PARTY_NAME`, `NET_AMT`, `TAX_AMT`, `TOT_AMT`, `BILL_AMT`, `ITM_*`, `CGST/SGST_TAX`, `ROF_AMT`, `IT_RATE/AMT`, and `BILL_OS_DATA` historical-bill rowcount differences — artifacts of the test voucher having different amounts/parties than the desktop reference.

## Honest limits
- Comparisons are **row[0]-representative** per table (the shipped harness's model); multi-row tables (AC_DATA mirror legs, TAX_DATA split) are corroborated via rowcount + the full-diff clone.
- `LC_CODE`/`CO_YEAR`/`VCH_NO`/timestamps are in the harness SKIP set (web LC=01 vs demo LC=00 does not affect any finding).
- Desktop recordset-written columns (SL_DATA/SL_DETL exact set) are observed from the loaded demo DB, consistent with audit-A's CANNOT-VERIFY note on static enumeration.
