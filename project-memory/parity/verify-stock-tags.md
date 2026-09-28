# Deep Write-Path Verification — STOCK / TAGS forms

Date: 2026-06-30  ·  Scope: tag-opening, tag-cancel, tag-weight-diff, tag-split
Method: read web modules + routes → create real web vouchers via API (scratch tag `ZZTEST*`) →
`parity_form compare` vs the matching **real imported desktop voucher** + direct SQL on the live DB →
triage → clean up → re-verify demo invariants. **No app code edited.**

Web modules: `apps/api/src/modules/stock/{stock,tagOps,tagSplit}.ts`, posting `modules/posting/posting.ts`,
routes `apps/api/src/routes/txn.ts`. DB: `web-postgres-1` (datacare, tenant `default`).

> NOTE on the VB source: `DataCareNext_Source/Forms/TR_TAG_*.vb` are decompiled **stubs** (only fragmentary
> `' SQL:` strings, no full write logic). The **authoritative desktop reference is the imported real data**,
> which is what every value below is cited from.

---

## 0. Real desktop tag vouchers (reference, tenant=default, CO_CODE=01)

MAIN_STOCK distinct tag types:
`000/TAGOP/TAG OPBL`, `015/TGEN/TAG GEN`, `016/TGCAN/TAG CANCEL`, `121/TAGTR/TAG TRFR`.
Global facts: **MAIN_STOCK.DATA_TYPE='A' on 1856/1856 (100%)**; **TBL_CODE='001' on all tag rows** (TAGOP 1169, TGCAN 2).
**BAR_DETL/BAR_IDTL/MAIN_STOCK have NO column defaults** for VCH_TYPE/BOOK_NAME/INOUT_TYPE/ENTRY_TYPE/DATA_TYPE/TBL_CODE → any column the web omits is stored **blank**.

| Form | Desktop key | MAIN_STOCK (VCH_TYPE/BOOK_NAME/TR_TYPE/ITM_SIGN/DATA_TYPE/TBL_CODE) | BAR_DETL & BAR_IDTL (VCH_TYPE/BOOK_NAME/INOUT_TYPE/ENTRY_TYPE/DATA_TYPE/TBL_CODE) |
|---|---|---|---|
| tag-opening | `000/00001` | `TAGOP / TAG OPBL / P / + / A / 001` | BAR_DETL `TGEN / TAG GEN / I / O / A / 001` ; BAR_IDTL `TGEN / TAG GEN / I / O` ; BAR_DATA present, `OP_STK=Y` |
| tag-cancel | `016/00001` | `TGCAN / TAG CANCEL / O / - / A / 001` | **BAR_CAN_DATA/DETL/IDTL = 0 rows** (cancel footprint is MAIN_STOCK-only in the demo) |
| tag-weight-change | `000/00037` SR_NO 23 | **no MAIN_STOCK row** (tag PSG00047 appears only as its TAGOP opening) | BAR_DETL `TGWTC / TAG WT CHANGE / I / O / A / 001` (+ desktop AC_DATA fine ledger, IT_TYPE='G') |
| tag-split | — | **no rows anywhere** with BOOK_NAME `TAG SPLIT` (demo never exercised split) | — (desktop source: MAIN_BOOK `TAG SPLIT`, detail in BAR_* + AC_DATA fine ledger) |

Important: **CO_BOOK `000` is a shared key** — `000/00037` holds 30 `TAGOP` MAIN_STOCK opening rows *plus* the
`TGWTC` row in BAR_DETL. `parity_form` keys only on (CO_CODE,CO_BOOK,VCH_NO) and diffs row[0], so its
weight-diff output below is partly noise; the weight-diff truth is taken from the direct SQL above.

---

## 1. Web vouchers created (API, scratch tag ZZTEST*, then deleted)

| Form | Route | Web key | MAIN_STOCK stamps written |
|---|---|---|---|
| tag-opening | `POST /stock/tag-opening` | `TOP/3` | `TAGOP / TAG OPENING / P / + / <blank> / <blank>` |
| tag-cancel | `POST /stock/tag-cancel` | `TGC/4` | `TGCAN / TAG CANCEL / O / - / <blank> / <blank>` |
| tag-weight-diff | `POST /stock/tag-weight-diff` | `TWD/5` | `TGWD / TAG WT CHANGE / I / + / <blank> / <blank>` (+ AC_DATA STKADJ/WTDIFF, correctly `DATA_TYPE=A`) |
| tag-split | `POST /stock/tag-split` | `TSP/6` | x3: `TGSPL / TAG SPLIT / parent O,- · children I,+ / <blank> / <blank>` |

Web BAR side (tag-opening `TOP/3`): **BAR_DETL all stamps blank**; **BAR_IDTL `TAGOP / TAG OPENING / blank / blank`**; BAR_DATA present (`OP_STK=Y`).

---

## 2. COL DIFF / FOOTPRINT table (desk vs web, classified)

`[A]`=concrete fixable · `[B]`=known structural · `[C]`=amount/key (scratch-tag artifact, ignore)

| Form | Table.Column | Desk | Web | Class |
|---|---|---|---|---|
| tag-opening | MAIN_STOCK.BOOK_NAME | `TAG OPBL` | `TAG OPENING` | **A** |
| tag-opening | MAIN_STOCK.DATA_TYPE | `A` | `<blank>` | **A** |
| tag-opening | MAIN_STOCK.TBL_CODE | `001` | `<blank>` | **A** |
| tag-opening | MAIN_STOCK.VCH_TYPE / TR_TYPE / ITM_SIGN | `TAGOP/P/+` | `TAGOP/P/+` | OK |
| tag-opening | BAR_DETL.VCH_TYPE | `TGEN` | `<blank>` | **A** |
| tag-opening | BAR_DETL.BOOK_NAME | `TAG GEN` | `<blank>` | **A** |
| tag-opening | BAR_DETL.INOUT_TYPE | `I` | `<blank>` | **A** |
| tag-opening | BAR_DETL.ENTRY_TYPE | `O` | `<blank>` | **A** |
| tag-opening | BAR_DETL.DATA_TYPE | `A` | `<blank>` | **A** |
| tag-opening | BAR_DETL.TBL_CODE | `001` | `<blank>` | **A** |
| tag-opening | BAR_IDTL.VCH_TYPE | `TGEN` | `TAGOP` | **A** |
| tag-opening | BAR_IDTL.BOOK_NAME | `TAG GEN` | `TAG OPENING` | **A** |
| tag-opening | BAR_IDTL.INOUT_TYPE | `I` | `<blank>` | **A** |
| tag-opening | BAR_IDTL.ENTRY_TYPE | `O` | `<blank>` | **A** |
| tag-opening | BAR_DATA.USER_DELETE, KR_*, ISR_NO, OLD_SRNO | set | blank | B (thin footprint) |
| tag-opening | ITM_NWT/GWT/QTY/FINE, TAG_NO, IT_CODE | 39.69… | 10… | C |
| tag-cancel | MAIN_STOCK.BOOK_NAME / VCH_TYPE / TR_TYPE / ITM_SIGN | `TAG CANCEL/TGCAN/O/-` | same | **OK (match)** |
| tag-cancel | MAIN_STOCK.DATA_TYPE | `A` | `<blank>` | **A** |
| tag-cancel | MAIN_STOCK.TBL_CODE | `001` | `<blank>` | **A** |
| tag-cancel | BAR_CAN_DATA/DETL/IDTL | 0 rows | 0 rows | OK (no provable miss in demo) |
| tag-weight-diff | target table | BAR_DETL+BAR_IDTL (`TGWTC`), no MAIN_STOCK | MAIN_STOCK (`TGWD`)+AC_DATA | B (deliberate simplified model) |
| tag-weight-diff | MAIN_STOCK.DATA_TYPE / TBL_CODE (if model kept) | `A` / `001` | `<blank>` / `<blank>` | **A** |
| tag-split | target table | BAR_* + AC_DATA fine ledger (per source); **no demo data** | MAIN_STOCK (`TGSPL`) | B (+ no desktop reference) |
| tag-split | MAIN_STOCK.DATA_TYPE / TBL_CODE | `A` / `001` | `<blank>` / `<blank>` | **A** |

---

## 3. CONCRETE FIXABLE BUGS  (the actionable output)

All citations are real DB values (desk = imported desktop voucher; web = the voucher I created then deleted).

### BUG-1 — tag-opening MAIN_STOCK.BOOK_NAME wrong
- desk `000/00001` MAIN_STOCK.BOOK_NAME = **`TAG OPBL`** ; web `TOP/3` = **`TAG OPENING`**.
- `'TAG OPENING'` exists **nowhere** in desktop data; reports/stock queries key on `TAG OPBL`.
- File `modules/stock/stock.ts:242` → change `BOOK_NAME: 'TAG OPENING'` → **`BOOK_NAME: 'TAG OPBL'`**.

### BUG-2 — tag-opening BAR_IDTL.VCH_TYPE + BOOK_NAME wrong
- desk `000/00001` BAR_IDTL = **`TGEN` / `TAG GEN`** ; web = **`TAGOP` / `TAG OPENING`**.
- The same voucher uses `TAGOP` in MAIN_STOCK but **`TGEN`/`TAG GEN`** in the BAR tables; web wrongly reused `TAGOP/TAG OPENING`.
- File `modules/stock/stock.ts:238` → `VCH_TYPE: 'TAGOP', BOOK_NAME: 'TAG OPENING'` → **`VCH_TYPE: 'TGEN', BOOK_NAME: 'TAG GEN'`**.

### BUG-3 — tag-opening BAR_IDTL.INOUT_TYPE / ENTRY_TYPE blank
- desk BAR_IDTL INOUT_TYPE/ENTRY_TYPE = **`I` / `O`** ; web = blank/blank.
- File `modules/stock/stock.ts:237-239` (barIdtl builder) → add **`INOUT_TYPE: 'I', ENTRY_TYPE: 'O'`**.

### BUG-4 — tag-opening BAR_DETL has NO stamp columns at all
- desk `000/00001` BAR_DETL = **`TGEN / TAG GEN / I / O / A / 001`** (VCH_TYPE/BOOK_NAME/INOUT_TYPE/ENTRY_TYPE/DATA_TYPE/TBL_CODE).
- web `TOP/3` BAR_DETL = **all six blank** — the row is unidentifiable by type and invisible to any `MAIN_BOOK IN ('TAG GEN',…)` filter (e.g. karigar-issue stock-availability query in `TR_KR_ISU`).
- File `modules/stock/stock.ts:232-236` (barDetl builder) → add **`VCH_TYPE: 'TGEN', BOOK_NAME: 'TAG GEN', INOUT_TYPE: 'I', ENTRY_TYPE: 'O', TBL_CODE: '001'`** (DATA_TYPE handled by BUG-5).

### BUG-5 — DATA_TYPE='A' missing on ALL stock write rows (global)
- desk MAIN_STOCK.DATA_TYPE = **`A` on 1856/1856 (100%)**, BAR_DETL.DATA_TYPE = **`A` on 1328/1329**.
- web MAIN_STOCK rows for **every** tag op (opening, cancel, wt-diff, split) = **blank** (6/6 rows); web BAR_DETL/IDTL = blank.
- Root cause: `postVoucherTx` only enriches **AC_DATA** lines with `DATA_TYPE='A'` (`posting.ts:84 enrichLedgerLine`); the `writes[]` rows (MAIN_STOCK/BAR_*) are inserted as-is. (Confirmed: web AC_DATA for TWD/5 *did* get `DATA_TYPE='A'`, but its MAIN_STOCK row did not.)
- Fix (one of):
  - **Global (preferred, mirrors the AC_DATA fix):** in `postVoucherTx` (`posting.ts`), stamp `DATA_TYPE: 'A'` on each write row when unset, e.g. before `insertRowTx(tx, w.table, …, r)` do `if (r.DATA_TYPE == null) r.DATA_TYPE = 'A';`.
  - Or per-builder: add `DATA_TYPE: 'A'` to each MAIN_STOCK/BAR_* row in `stock.ts`, `tagOps.ts`, `tagSplit.ts`.

### BUG-6 — TBL_CODE='001' missing on tag MAIN_STOCK (+ BAR_DETL) rows
- desk tag rows TBL_CODE = **`001`** (TAGOP 1169/1169, TGCAN 2/2; BAR_DETL `001`). web = blank on all.
- Fix: add **`TBL_CODE: '001'`** to the MAIN_STOCK builders in `stock.ts:241` (opening), `tagOps.ts:88` (cancel) & `tagOps.ts` (wt-diff), `tagSplit.ts:106/132` (split parent/child), and the BAR_DETL builder (`stock.ts:232`).

> tag-cancel needs **only** BUG-5 + BUG-6: its `VCH_TYPE 'TGCAN' / BOOK_NAME 'TAG CANCEL' / TR_TYPE 'O' / ITM_SIGN '-'` already **match desktop exactly** (verified — not in the diff set).

---

## 4. Answers to the targeted questions

- **Does tag-cancel write BAR_CAN_DATA/DETL/IDTL like desktop, or only MAIN_STOCK?**
  In the imported demo, **BAR_CAN_DATA/DETL/IDTL are empty (0 rows)** and the one desktop cancel voucher (`016/00001`) exists **only in MAIN_STOCK** — so the web (MAIN_STOCK-only) **matches the real data footprint; no provable footprint miss**. Caveat: desktop *configuration* (`TR_PHYSTK.vb`: `BOOK_TBL_NAME='BAR_CAN_DATA'` for `MAIN_BOOK IN ('TAG CANCEL',…)`) implies cancel detail is *meant* to live in BAR_CAN_*, but the demo never populated it, so this stays a config-level caveat, not a data-backed bug.
- **Do tag MAIN_STOCK rows carry correct TR_TYPE / ITM_SIGN / BOOK_NAME / DATA_TYPE?**
  - TR_TYPE ✅ (opening `P`, cancel `O`, split parent `O`/child `I`, wt-diff `I`) — all match the desktop convention.
  - ITM_SIGN ✅ (`+`/`-` correct).
  - BOOK_NAME — ✅ cancel (`TAG CANCEL`), split/wt-diff (`TAG SPLIT`/`TAG WT CHANGE` are consistent web labels); ❌ **tag-opening (`TAG OPENING` vs desk `TAG OPBL`) — BUG-1**.
  - DATA_TYPE — ❌ **blank on every tag MAIN_STOCK row; desktop is `A` (100%) — BUG-5**.

---

## 5. Known structural divergences (Category B — not column bugs)

- **tag-weight-diff**: desktop re-details the tag in **BAR_DETL/BAR_IDTL** (`TGWTC`, INOUT_TYPE `I`/ENTRY_TYPE `O`) with **no MAIN_STOCK movement** + an AC_DATA *fine* ledger (IT_TYPE `G`). The web books a single **MAIN_STOCK** net-difference movement (`TGWD`) + a Dr/Cr **value** ledger. This is the documented "simplified, equivalent net-of-difference" Phase-4 model (`tagOps.ts` header). Aligning the table footprint is a re-architecture, not a one-line fix — left as-is per triage rule B. (If the MAIN_STOCK model is kept, BUG-5/6 still apply to its row.)
- **tag-split**: web writes **MAIN_STOCK** (`TGSPL`, parent OUT + child IN). Desktop source models split like wt-change (BAR_* + AC_DATA fine ledger, MAIN_BOOK `TAG SPLIT`). **No desktop split voucher exists in the demo dataset**, so a data-to-data parity is impossible — reported honestly. (BUG-5/6 apply to the MAIN_STOCK rows.)
- Thin footprint generally: web omits KR_*, OLD_SRNO, ISR_NO, USER_DELETE etc. — structural thinness, out of scope.

## 6. Form creation status
All four web forms **were created successfully** via the API (HTTP 201): tag-opening `TOP/3`, tag-cancel `TGC/4`, tag-weight-diff `TWD/5`, tag-split `TSP/6`. tag-split has **no desktop counterpart in the demo** for data parity (noted).

## 7. Cleanup & demo-intact verification
Scratch rows existed only under web-only books `TOP/TGC/TWD/TSP`. Deleted: MAIN_STOCK 6, BAR_DATA 1, BAR_DETL 1, BAR_IDTL 1, AC_DATA 2 (= 11, exactly what was created). Post-cleanup reads:

| Invariant | Baseline | After |
|---|---|---|
| BAR_DETL count | 1329 | **1329** ✅ |
| SL_DATA count | 190 | **190** ✅ |
| SL_DATA SUM(TOT_AMT) | 5478196.00 | **5478196.00** ✅ |
| MAIN_STOCK count | 1856 | **1856** ✅ |
| residual scratch (TOP/TGC/TWD/TSP) | — | **0** ✅ |
| residual ZZTEST* tags anywhere | — | **0** ✅ |

Demo data fully intact; no app code modified.
