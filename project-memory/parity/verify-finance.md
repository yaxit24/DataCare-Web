# Deep Write-Path Verification — FINANCE / cash-bank forms vs real desktop vouchers

**Date:** 2026-06-30 · **cwd:** `/Users/yakshitsavaliya/Desktop/imodule-extracted`
**Scope:** receipt, payment, contra, journal. **Method:** created real web vouchers via the running API
(`http://localhost:4000`, admin/Secret#1, coCode 01, tenant `default`), then diffed every voucher-keyed
table column-by-column against real desktop vouchers using `apps/api/integration/parity_form.mjs` (plus a
throwaway non-truncating clone `_tmp_fin_diff.mjs`, since the shipped harness caps display at 8 diffs/table —
clone **deleted** after use, `parity_form.mjs` untouched: size 4648, original mtime intact). **No app code edited.**
Every value below is a real DB read, cited desk vs web.

## What was created / compared / cleaned
| Web voucher | Web book/Vch | Desktop ref | Why |
|---|---|---|---|
| Receipt (cash, party `000926`, ₹60000) | `RCT/53` (VCH_TYPE RCT) | `001/00002` (CREC) | CASH REC footprint |
| Payment (cash, party `00052`, ₹10600) | `PAY/54` (VCH_TYPE PAY) | `002/00001` (CPAY) | CASH PAY footprint |
| Journal (Dr `000661` / Cr `000760`, ₹11957) | `JV/55` (VCH_TYPE JV) | `017/00001` (JV) | CONTRA/JV book (AC_DATA-only) |
| Contra (`000760`→`000661`, ₹3478) | `CON/56` (VCH_TYPE CON) | `017/00001` (JV) | CONTRA book 017 |

**Cleanup (verified):** all 4 deleted directly across **every** voucher-keyed table (AC_DATA 8 rows, CASH_DATA 1,
PAY_DATA 1, CONTRA_DATA 1 = 11 rows) — deleted by SQL, so **no DELETE_DATA residue**; `SRNO_MAST(01,01)` restored 56→52.
**Demo intact (post-cleanup reads):** `SL_DATA` = **190 / SUM(TOT_AMT)=5478196.00** ; `AC_DATA` distinct AC_CODE = **300** ;
`AC_DATA` total back to **5150** ; `CASH_DATA|PAY_DATA|CONTRA_DATA` = **0|0|0** ; `DELETE_DATA` = **1** ; 0 residual rows in RCT/PAY/CON/JV.

## Model confirmed from `BOOK_DATA` (co 01)
| Book | MAIN_BOOK | BOOK_SNAME | BOOK_INOUT | (web equivalent) |
|---|---|---|---|---|
| `001` | `CASH REC` | `CREC` | `I` | `/receipts` → book `RCT`, type `RCT` |
| `002` | `CASH PAY` | `CPAY` | `O` | `/payments` → book `PAY`, type `PAY` |
| `017` | `CONTRA` | `JV` | `O` | `/contra` → book `CON`, type `CON` ; `/journal` → book `JV`, type `JV` |
| `214` | `CONTRA` | `JV1` | `I` | (none) |

- **`AC_DATA.BOOK_NAME` column = `BOOK_DATA.MAIN_BOOK`** (same rule the sales/purchase audit established: SALES/PURCHASE).
  For finance the constant per book is **`CASH REC` / `CASH PAY` / `CONTRA`** — verified on the real rows.
- **`AC_DATA.VCH_TYPE` column = `BOOK_DATA.BOOK_SNAME`** = **`CREC` / `CPAY` / `JV`**.
- **There is NO `JOURNAL` book** in `BOOK_DATA` — every JV-type voucher lives under `MAIN_BOOK='CONTRA'` (017/214).

## 🔑 KEY STRUCTURAL FINDING — desktop finance vouchers are **AC_DATA-only**
Enumerated all 100+ voucher-keyed tables for books `001`/`002`/`017`: **only `AC_DATA` has rows** (001=162, 002=360, 017=74).
The desktop header tables the web targets are **globally empty**: `CASH_DATA`=0, `PAY_DATA`=0, `CONTRA_DATA`=0, `ROJ_MEL_DATA`=0 rows.
Desktop source corroborates: `TR_CASH.vb` header — *"Cash payment and receipt voucher; writes to **AC_DATA + ROJ_MEL_DATA**"*;
`TR_CONTRA.vb` — *"**Writes dual AC_DATA entries.**"* So a desktop cash/bank/contra voucher is a pure **double-entry pair in AC_DATA**
(`LD_CODE` = the contra account; `SIGN` blank; `IT_TYPE='A'`; `DATA_TYPE='A'`). The web instead writes a header row to
`CASH_DATA`/`PAY_DATA`/`CONTRA_DATA` (which the desktop demo never populates).

**Answering the brief's two questions directly:**
1. *Does the desktop CASH REC set BOOK_NAME/VCH_TYPE the web omits?* **Yes.** Desktop AC_DATA carries `BOOK_NAME='CASH REC'`,
   `VCH_TYPE='CREC'`, `DATA_TYPE='A'`; the web leaves `BOOK_NAME` and `DATA_TYPE` blank and stamps `VCH_TYPE='RCT'`.
2. *Does receipt's CASH_DATA carry the right INOUT/ENTRY/sign?* **No — and the desktop has no CASH_DATA at all.** `CASH_DATA`
   has `INOUT_TYPE`/`ENTRY_TYPE`/`BOOK_NAME` columns, but the web's row (RCT/53) leaves all three **blank** (it sets only
   VCH_TYPE/AC_CODE/AC_NAME/REC_AMT/REC_AC_CODE). There is no SIGN column on CASH_DATA (sign is an AC_DATA concept).

---

# COL DIFF triage tables
Triage: **A** = concrete fixable bug (wrong/blank constant) · **B** = known structural (LD_CODE contra layout, LEDR_KEY scheme,
metal sub-ledger, header-table footprint) · **C** = data-value diff from the test voucher (ignore).

## RECEIPT — desktop `001/00002` (CREC) vs web `RCT/53`  (harness: AC_DATA 11 diffs + CASH_DATA WEB-EXTRA)
| Table | Column | desk | web | Class | Note / fix |
|---|---|---|---|---|---|
| AC_DATA | BOOK_NAME | `CASH REC` | *(blank)* | **A** | `postReceipt` omits `bookName` → set `'CASH REC'` |
| AC_DATA | VCH_TYPE | `CREC` | `RCT` | **A** | should be BOOK_SNAME `CREC` (web hardcodes `RCT`) |
| AC_DATA | DATA_TYPE | `A` | *(blank)* | **A** | desktop sets `'A'` on 100% of AC_DATA; web never sets it |
| AC_DATA | SIGN | *(blank)* | `D` | **A**(low) | desktop blank on money legs; web overloads Dr/Cr (pervasive) |
| CASH_DATA | *(whole row)* | **0 rows** | **1 row** | **B** | desktop writes no header (AC_DATA-only); see structural note |
| AC_DATA | AC_CODE (cash leg) | real cash ldgr (`00001`-type) | `CASH` | **B**(note) | web posts to literal `'CASH'` (no such AC_MAST acct; real cash = `00001` CASH ON HAND) |
| AC_DATA | LD_CODE | contra acct | ordinal `1/2` | **B** | contra layout (ignore per brief) |
| AC_DATA | LEDR_KEY | `01002024-20250010000201` | `0101RCT00005301` | **B** | key-derivation scheme differs |
| AC_DATA | FINE_WT / FINE_RATE / PARTY_AC_CODE | `0`/`0`/party | *(blank)* | **B** | metal sub-ledger / thin footprint |
| AC_DATA | AC_CODE(party), DR_AMT, CR_AMT | `878`,… | `000926`,… | **C** | different test voucher |

## PAYMENT — desktop `002/00001` (CPAY) vs web `PAY/54`  (harness: PAY_DATA WEB-EXTRA + AC_DATA 11 diffs)
| Table | Column | desk | web | Class | Note / fix |
|---|---|---|---|---|---|
| AC_DATA | BOOK_NAME | `CASH PAY` | *(blank)* | **A** | `postPayment` omits `bookName` → set `'CASH PAY'` |
| AC_DATA | VCH_TYPE | `CPAY` | `PAY` | **A** | should be BOOK_SNAME `CPAY` |
| AC_DATA | DATA_TYPE | `A` | *(blank)* | **A** | constant `'A'` omitted |
| AC_DATA | SIGN | *(blank)* | `D` | **A**(low) | pervasive Dr/Cr convention |
| PAY_DATA | *(whole row)* | **0 rows** | **1 row** | **B** | desktop AC_DATA-only |
| AC_DATA | LD_CODE / LEDR_KEY / FINE_* / PARTY_AC_CODE | contra/…/0/party | ordinal/…/blank | **B** | contra layout + thin footprint |
| AC_DATA | IT_DESC | `JUNO HISAB CHUKTE` | *(blank)* | **C/B** | desktop per-line narration (payment route accepts none) |
| AC_DATA | AC_CODE, DR_AMT | `294`,`730` | `52`,`10600` | **C** | different test voucher |

## JOURNAL — desktop `017/00001` (JV) vs web `JV/55`  (AC_DATA-only — **footprint matches desktop**)
| Table | Column | desk | web | Class | Note / fix |
|---|---|---|---|---|---|
| AC_DATA | **VCH_TYPE** | `JV` | `JV` | — | **MATCHES** ✓ (web journal already stamps `JV` = BOOK_SNAME of 017) |
| AC_DATA | BOOK_NAME | `CONTRA` | `JOURNAL` | **A** | no `JOURNAL` book exists in desktop; 017 JV-book is `CONTRA` → set `'CONTRA'` |
| AC_DATA | DATA_TYPE | `A` | *(blank)* | **A** | constant `'A'` omitted |
| AC_DATA | SIGN | *(blank)* | `D` | **A**(low) | pervasive |
| AC_DATA | LD_CODE | contra acct | ordinal | **B** | contra layout (ignore) |
| AC_DATA | LEDR_KEY / FINE_* / PARTY_AC_CODE | …/0/party | …/blank | **B** | scheme / thin footprint |
| AC_DATA | IT_DESC | *(blank)* | `TEST JV` | **C** | my test narration (web maps narration→IT_DESC) |

## CONTRA — desktop `017/00001` (JV) vs web `CON/56`  (CONTRA_DATA WEB-EXTRA + AC_DATA 11 diffs)
| Table | Column | desk | web | Class | Note / fix |
|---|---|---|---|---|---|
| AC_DATA | VCH_TYPE | `JV` | `CON` | **A** | desktop 017 type is `JV`; web hardcodes `CON` → set `'JV'` |
| AC_DATA | BOOK_NAME | `CONTRA` | *(blank)* | **A** | `postContra` omits `bookName` → set `'CONTRA'` |
| AC_DATA | DATA_TYPE | `A` | *(blank)* | **A** | constant `'A'` omitted |
| AC_DATA | SIGN | *(blank)* | `D` | **A**(low) | pervasive |
| CONTRA_DATA | *(whole row)* | **0 rows** | **1 row** | **B** | desktop AC_DATA-only (though desktop schema retains CONTRA_DATA machinery — see note) |
| AC_DATA | LD_CODE / LEDR_KEY / FINE_* / PARTY_AC_CODE | contra/…/0/party | ordinal/…/blank | **B** | contra layout + thin footprint |
| AC_DATA | AC_CODE, DR_AMT | `760`,`11957` | `661`,`3478` | **C** | different test voucher |

---

# 🎯 CONCRETE FIXABLE BUGS (actionable output)
All file:line in `web/apps/api/src/modules/`. The finance path mirrors the purchase A1/A6 pattern: it omits the
`BOOK_NAME` constant and uses the wrong `VCH_TYPE` literal that the desktop sets consistently on every AC_DATA row.

### F1 — AC_DATA `BOOK_NAME` is blank on receipt/payment/contra; must be the book's MAIN_BOOK (HIGH)
Desktop stamps `BOOK_NAME` = `BOOK_DATA.MAIN_BOOK` on every AC_DATA leg: **`CASH REC` / `CASH PAY` / `CONTRA`**.
The web never passes `bookName` to `postVoucherTx`, so `enrichLedgerLine` leaves it blank (`posting.ts:68` only fills when a bookName is supplied — exactly how `sales.ts` passes `'SALES'` and `journal.ts:98` passes a bookName).
- `finance/finance.ts:75` (receipt `postVoucherTx` call) → add `bookName: 'CASH REC',`
- `finance/finance.ts:126` (payment) → add `bookName: 'CASH PAY',`
- `finance/finance.ts:174` (contra) → add `bookName: 'CONTRA',`
**Evidence:** desk `CASH REC`/`CASH PAY`/`CONTRA`; web `''` (RCT/53, PAY/54, CON/56 diffs).

### F2 — AC_DATA `VCH_TYPE` literal is wrong; must equal BOOK_SNAME (HIGH)
Desktop `VCH_TYPE` = `BOOK_DATA.BOOK_SNAME` = **`CREC`/`CPAY`/`JV`**. Web hardcodes `RCT`/`PAY`/`CON`.
(The web **journal already does this correctly** — it stamps `JV`, matching 017.) Stamp the same on the
ledger legs **and** the header row:
- `finance/finance.ts:73` `buildTransferLedger(key, 'RCT', …)` → `'CREC'` ; `:83` CASH_DATA `VCH_TYPE: 'RCT'` → `'CREC'`
- `finance/finance.ts:124` `'PAY'` → `'CPAY'` ; `:134` PAY_DATA `VCH_TYPE: 'PAY'` → `'CPAY'`
- `finance/finance.ts:172` `'CON'` → `'JV'` ; `:182` CONTRA_DATA `VCH_TYPE: 'CON'` → `'JV'`
- Also `finance/batchReceipt.ts:17` `RCT_TYPE='RCT'` → `'CREC'` (the batch-receipt path has the same gap).
(Leave the **CO_BOOK** book-code — `RCT`/`PAY`/`CON`/`JV` — as the web's own book identity; the harness skips CO_BOOK.)
**Evidence:** desk `CREC`/`CPAY`/`JV`; web `RCT`/`PAY`/`CON` (all three diffs); journal `JV`=`JV` ✓.

### F3 — AC_DATA `DATA_TYPE` is blank everywhere; desktop sets `'A'` on 100% of rows (HIGH, one line, global)
`DATA_TYPE='A'` on **all 5150** desktop AC_DATA rows (every book — finance, sales, purchase: 0 exceptions). The web's
`enrichLedgerLine` never sets it. One default fixes finance + sales + purchase + every other AC_DATA writer:
- `posting/posting.ts:68` (in `enrichLedgerLine`, beside the existing `IT_TYPE`/`LD_CODE` defaults) → add
  `if (e.DATA_TYPE == null) e.DATA_TYPE = 'A';`
**Evidence:** desk `A` on every finance diff row; web `''`. (Prior sales/purchase audit bucketed this under B "thin footprint" —
it is more precisely a blind constant and a trivial one-liner, so reclassified A here.)

### F4 — Journal `BOOK_NAME='JOURNAL'` has no desktop counterpart; the JV book is `CONTRA` (MED)
There is **no `JOURNAL` book** in `BOOK_DATA`; the only `BOOK_SNAME='JV'` books are `017`/`214`, both `MAIN_BOOK='CONTRA'`.
The web journal stamps `BOOK_NAME='JOURNAL'`.
- `finance/journal.ts:14` `const JV_BOOK_NAME = 'JOURNAL';` → `'CONTRA'`
**Honest caveat:** the web *intentionally* separates `/journal` from `/contra`; if a distinct "general journal" book is
desired it should be added to `BOOK_DATA` rather than stamped ad-hoc. For strict parity to the desktop's 017 JV book, use `'CONTRA'`.
**Evidence:** desk `CONTRA`; web `JOURNAL` (JV/55 diff); `BOOK_DATA` has no JOURNAL row.

### F5 — AC_DATA `SIGN='D'/'C'`; desktop leaves it blank on money legs (LOW — pervasive, same as sales/purchase A7)
Desktop reserves `AC_DATA.SIGN` for metal direction (`+`/`-`); money legs are **blank**, Dr/Cr encoded by `DR_AMT`/`CR_AMT`.
Web stamps `D`/`C` on every money leg (`finance.ts:34-35`, `journal.ts:90`). System-wide convention (also sales/purchase/dhrn/…);
no report filters AC_DATA on SIGN. Treat as a convention decision, not a quick patch.
**Evidence:** desk `''`; web `D`/`C` on all four forms.

---

## Secondary observations (real, but outside the clean-constant bucket)
- **`AC_CODE='CASH'`/`'BANK'` magic strings (receipt/payment cash leg).** `settlementAc()` returns the literal `'CASH'`
  (`finance.ts:48`), but `AC_MAST` has **no** `CASH` account — the real cash ledger is `00001` ("CASH ON HAND"). So the web's
  cash leg posts to a non-existent ledger code and will not reconcile against the desktop cash book. Fixable, but it needs the
  **configured** cash/bank ledger code (company setting), not a blind constant → flagged, not auto-fixed. Class B(note).
- **`CO_BOOK='RCT'` collision.** Cash receipts (`finance.ts`, VCH_TYPE `RCT`) and **rate-cut** vouchers (`rateCut.ts:39`,
  VCH_TYPE `RCUT`, BOOK_NAME `RATE CUT`) both write `CO_BOOK='RCT'`. VCH_NO stays unique (SRNO_MAST is global per CO/LC), but
  the two voucher classes intermingle in one book code; any `CO_BOOK='RCT'` report mixes them. Adopting F2 (distinct VCH_TYPE
  `CREC`) mitigates the ambiguity; a distinct receipt book code would fully resolve it.
- **Web header tables are themselves thin if kept.** `CASH_DATA`/`PAY_DATA`/`CONTRA_DATA` all define `INOUT_TYPE`/`ENTRY_TYPE`/
  `BOOK_NAME` columns, but the web rows leave them blank. If the header writes are retained (see Class B), they should at least
  stamp `INOUT_TYPE` (`I` receipt / `O` payment/contra, = BOOK_INOUT), `ENTRY_TYPE`, and `BOOK_NAME`.

## Class B (known structural — NOT pursued)
- **Header-table footprint divergence** — desktop books cash/bank/contra **purely in AC_DATA** (0 rows in CASH_DATA/PAY_DATA/
  CONTRA_DATA/ROJ_MEL_DATA across the whole demo); the web adds one header row per voucher. Analogous to the purchase
  `BILL_OS_DATA` extra-write, **but weaker**: removal is a design call, not a blind one-liner — the desktop *schema* retains
  `CONTRA_DATA` (its `TR_CONTRA` delete-logic joins AC_DATA↔CONTRA_DATA) and `TR_CASH` names `ROJ_MEL_DATA` as a co-target.
  The journal path already matches desktop (AC_DATA-only).
- **`LD_CODE` = contra account (desktop) vs line ordinal (web)** — the desktop double-entry stores the *other* account in LD_CODE;
  web stores `1,2,…`. Explicitly out of scope per brief.
- **`LEDR_KEY`** derivation differs (`01002024-2025…0010000201` desktop vs `0101RCT00005301` web).
- **Metal sub-ledger** — `FINE_WT`/`FINE_RATE` are `0` on desktop money legs, blank on web; `PARTY_AC_CODE` set on desktop
  party legs, blank on web (data-dependent which leg is the party).

## Class C (data-value only — ignored)
`AC_CODE` (party legs), `AC_NAME`, `DR_AMT`/`CR_AMT` amounts, `IT_DESC` narration text — all artifacts of the test voucher
having different parties/amounts than the desktop reference.

## Honest limits
- Comparisons are **row[0]-representative** per table (the shipped harness's model); the contra double-entry's two legs are
  corroborated via the full-diff clone + direct row dumps. `AC_DATA` has no `SR_NO`, so leg order is insertion-order — which leg
  lands at row[0] shifts only the per-leg value diffs (AC_CODE/LD_CODE/DR/CR), never the constant-column findings (BOOK_NAME/
  VCH_TYPE/DATA_TYPE/SIGN), which are identical on every leg of a voucher.
- `LC_CODE`/`CO_YEAR`/`VCH_NO`/`CO_BOOK`/timestamps are in the harness SKIP set (web LC=01 vs demo LC=00 affects nothing here).
- The desktop `TR_CASH.vb`/`TR_CONTRA.vb` are decompiled approximations; their write-target **comments** are corroborated by the
  hard DB fact that books 001/002/017 touch AC_DATA only (header tables empty).
