# Implementation plan: the last two Rojmel families (56 rows)

**Status:** all three measured, shapes derived, ready to implement. **Written:** 2026-07-31.
**Prerequisite:** read `docs/ROJMEL-HANDBOOK.md` first — environment, invariants, traps, controls and the
verification sequence live there and are not repeated here.

This plan closes the queue: **Fine JV 28 rows · Karigar Receipt 28**. Fine JV first — it is the cheapest
and validates the pattern for the second.

Coverage goes from **3057/3179 (96%)** to **3113/3179 (97.9%)**.

**URD Purchase (book 043, 27 rows) has been dropped from the queue, not deferred** — see §3. It is a
retired book, so those rows are correctly never written rather than missing.

---

## 0. What is NOT in this plan, and why

**Wholesale sales (book 034, 32 rows) is deliberately excluded, and it is the bigger finding.**

The web has **no wholesale-sale path at all**. Only `sales/wholesaleSaleReturn.ts` exists, with a single
route `POST /sales/wholesale-sale-return`. There is no wholesale _sale_ module, function or route.

```bash
grep -oE "app\.(get|post)\('/[a-z/-]*wholesale[a-z/-]*'" apps/api/src/routes/txn.ts
# app.post('/sales/wholesale-sale-return')   ← the only one
```

So a day-book projection for book 034 would serve a voucher the web cannot create. **That is a missing
voucher family, not a missing projection**, and it belongs in the gap register at a different level than a
Rojmel row type. It is also related to the standing note that `TR_TOUR_SALE` and `TR_BUL_SALE` are builds
rather than wiring.

Book 034 also has **11 row types across 32 rows** — the most fragmented family in the file — so it is not
cheap even once the voucher exists. Sized for later:

| Type                               | Rows     | Notes                                                            |
| ---------------------------------- | -------- | ---------------------------------------------------------------- |
| `05`                               | 19       | per-line fine rows from `RATE_CUT_ISU`, money-free, 33-char keys |
| `06`                               | 2        | per-line, the receipt side                                       |
| `01` `02` `03` `04` `08` `13` `26` | 1–2 each | **already built** in `buildRateCutRojmel`                        |
| `25` `28`                          | 1 each   | sale kasar, purchase labour — not built                          |

Only `05`, `06`, `25` and `28` would be new. Record the voucher-family gap before touching the Rojmel.

---

## 1. Fine JV — book 078, 28 rows, 2 types. Do this one first.

### 1.1 Why first

Two row types, both money-free, source and data in exact agreement, and the table it reads
(`CONTRA_DATA`) is **already written by the web** from `finance/fineJv.ts`. Lowest risk, and it exercises
the "fine rows feed the report" path a second time.

### 1.2 The source

`Ac_Rojmel.cs` **lines 342 and 344**, inside `Contra_Rojmel`. That is why the earlier routine-to-table map
showed `Contra_Rojmel` reading `CONTRA_DATA`: one routine serves both `MAIN_BOOK = 'CONTRA'` (book 017,
already implemented) and `MAIN_BOOK = 'FINE JV'` (book 078, this work).

```
line 342  type '01'+Str(SR_NO)   AC_CODE=A.AC_CODE  LD_CODE=A.LD_CODE  CR=0 DR=0
          IT_TYPE=A.IT_TYPE  SIGN='+'  ITM_FINE=A.CR_FINE   guard: CR_FINE <> 0
line 344  type '02'+Str(SR_NO)   same accounts                CR=0 DR=0
          IT_TYPE=A.IT_TYPE  SIGN='-'  ITM_FINE=A.DR_FINE   guard: DR_FINE <> 0
```

Both filter `B.MAIN_BOOK = 'FINE JV'`.

### 1.3 The data confirms it exactly

```bash
SQL -d Live24 -Q "SET NOCOUNT ON;
SELECT '  t'+SUBSTRING(LEDR_KEY,22,2)+' n='+CAST(count(*) AS varchar)
 +' it='+MAX(ISNULL(IT_TYPE,'-'))+MAX(CASE WHEN ISNULL(SIGN,'')='' THEN '_' ELSE SIGN END)
 +' dr='+CAST(SUM(CASE WHEN ISNULL(DR_AMT,0)<>0 THEN 1 ELSE 0 END) AS varchar)
 +' cr='+CAST(SUM(CASE WHEN ISNULL(CR_AMT,0)<>0 THEN 1 ELSE 0 END) AS varchar)
 +' fine='+CAST(SUM(CASE WHEN ISNULL(ITM_FINE,0)<>0 THEN 1 ELSE 0 END) AS varchar)
 +' gwt='+CAST(SUM(CASE WHEN ISNULL(ITM_GWT,0)<>0 THEN 1 ELSE 0 END) AS varchar)
 +' keyLen='+CAST(MAX(LEN(LEDR_KEY)) AS varchar)
 FROM ROJ_MEL_DATA WHERE CO_BOOK='078' GROUP BY SUBSTRING(LEDR_KEY,22,2)"
```

| Type | Rows | `IT_TYPE` | `SIGN` | Dr  | Cr  | Fine | Gross | Key |
| ---- | ---- | --------- | ------ | --- | --- | ---- | ----- | --- |
| `01` | 14   | `G`       | `+`    | 0   | 0   | 14   | **0** | 33  |
| `02` | 14   | `G`       | `-`    | 0   | 0   | 14   | **0** | 33  |

28 total. **Both types carry fine and NO gross weight** — a fine JV moves pure fine between accounts, so
there is no physical article and nothing to weigh. Do not populate `ITM_GWT`.

### 1.4 Implementation

Add to `apps/api/src/modules/shared/rojmel.ts`:

```ts
export const ROJMEL_FINEJV_ROW_TYPE = { CREDIT_FINE: '01', DEBIT_FINE: '02' } as const;
export type RojmelFineJvRowType =
  (typeof ROJMEL_FINEJV_ROW_TYPE)[keyof typeof ROJMEL_FINEJV_ROW_TYPE];

export interface FineJvRojmelLine {
  lineNo: number;
  acCode: string; // CONTRA_DATA.AC_CODE
  ldCode: string; // CONTRA_DATA.LD_CODE — the contra
  metal: Exclude<RojmelMetal, 'A'>;
  creditFine: number; // CR_FINE → type 01, SIGN '+'
  debitFine: number; // DR_FINE → type 02, SIGN '-'
  description?: string; // IT_DESC
}
export function buildFineJvRojmel(ctx: RojmelContext, lines: FineJvRojmelLine[]): RojmelRow[];
```

Rules:

- Both amounts stay **0**. `ITM_GWT`, `ITM_NWT`, `ITM_TOUCH`, `ITM_RATE` stay 0 too.
- Emit type `01` only when `creditFine` is non-zero; type `02` only when `debitFine` is non-zero.
- A line can legitimately produce **both** — one JV line can debit and credit different fine positions.
- Widen `rojmelLedrKey`'s `rowType` union with `RojmelFineJvRowType`.
- `lineNo` on both types: keys are 33 characters.

Wire into `apps/api/src/modules/finance/fineJv.ts`. **Verified 2026-07-31:** it has its own delete list at
line 38, `const T = ['CONTRA_DATA', 'AC_DATA']`, and `ROJ_MEL_DATA` is **not** in it. Add it, or an edit
leaves stale rows and the next post collides with `23505`. It writes `CONTRA_DATA` at lines 118, 162 and
185 — three paths, so check all three when adding the projection.

### 1.5 Tests

1. Type `01` is `SIGN '+'` with `ITM_FINE = creditFine`; type `02` is `'-'` with `debitFine`.
2. **Both amounts are zero on both types** — this is the defining property.
3. **`ITM_GWT` is zero on both** — a fine JV has no physical article.
4. A line with both fines set produces **two** rows.
5. A line with neither produces none.
6. Keys are 33 characters and two lines do not collide.
7. `IT_TYPE` comes from the caller's metal, not a default.
8. The report's `totals.gold.inFine` and `outFine` both move — this is the first family to populate
   **both** directions from one voucher.

### 1.6 Controls

| Break                             | Expected                                              |
| --------------------------------- | ----------------------------------------------------- |
| put the fine into `DR_AMT`        | the money-free assertion fails                        |
| populate `ITM_GWT` from the fine  | the no-gross assertion fails                          |
| swap `SIGN` between the two types | direction fails, and the report's in/out buckets swap |
| drop `lineNo`                     | key-length fails and two lines collide                |
| remove the `<> 0` guards          | the empty-line test fails                             |
| drop the `ROJ_MEL_DATA` write     | footprint fails naming the table                      |

---

## 2. Karigar Receipt — book 052, 28 rows, 4 types

### 2.1 Measured

| Type | Rows | `IT_TYPE` | `SIGN` | Dr  | Cr  | Fine   | Gross  | Key |
| ---- | ---- | --------- | ------ | --- | --- | ------ | ------ | --- |
| `11` | 21   | `G`       | `+`    | 0   | 0   | **21** | **21** | 33  |
| `01` | 3    | `G`       | `+`    | 0   | 0   | **0**  | **3**  | 33  |
| `02` | 2    | `A`       | blank  | 2   | 0   | 0      | 0      | 23  |
| `05` | 2    | `A`       | blank  | 0   | 2   | 0      | 0      | 23  |

21 + 3 + 2 + 2 = 28.

`KR_DETL` has 22 rows, **21 of them in book 052** — matching type `11` exactly one-for-one. So type `11`
is the per-`KR_DETL`-line row.

### 2.2 The question to answer before coding

**Types `11` and `01` are both `G` `+` per-line metal rows, both money-free, both 33-char keys. They differ
only in that `11` carries fine and `01` does not.** Derive what separates them before writing anything:

```bash
# Read Kr_Rec_Rojmel — Ac_Rojmel.cs line 364 — and extract its guards.
python3 - <<'PY'
import re
lines=open('unified/src/csharp/DataCareNext/Ac_Rojmel.cs',errors='replace').read().split('\n')
for i in range(363,392):
    l=lines[i]
    if 'INSERT INTO ROJ_MEL_DATA' not in l: continue
    ty=re.search(r"\+'(\d+)'(\+ ?[Ss]tr\(A\.SR_NO\))?",l)
    sel=re.search(r'MAIN_BOOK,\s+(.*?)\s+FROM',l,re.S)
    frm=re.search(r'FROM\s+\(*([A-Z_0-9]+)\s+AS',l)
    whr=re.search(r'"\s*(AND [^"]{0,120})"\)\);',l)
    print(f"line {i+1} type={ty.group(1) if ty else '?'} from={frm.group(1) if frm else '?'}")
    if sel: print('   ',sel.group(1)[:250])
    if whr: print('    WHERE',whr.group(1)[:120])
PY
```

Then check the data for the distinguishing column:

```bash
SQL -d Live24 -Q "SET NOCOUNT ON;
SELECT '  t'+SUBSTRING(r.LEDR_KEY,22,2)+' n='+CAST(count(*) AS varchar)
 +'  KR_DETL fine<>0='+CAST(SUM(CASE WHEN ISNULL(d.ITM_FINE,0)<>0 THEN 1 ELSE 0 END) AS varchar)
 +'  amt<>0='+CAST(SUM(CASE WHEN ISNULL(d.ITM_AMT,0)<>0 THEN 1 ELSE 0 END) AS varchar)
 FROM ROJ_MEL_DATA r LEFT JOIN KR_DETL d
   ON d.CO_BOOK=r.CO_BOOK AND d.VCH_NO=r.VCH_NO AND CAST(d.SR_NO AS int)=CAST(LTRIM(SUBSTRING(r.LEDR_KEY,24,10)) AS int)
 WHERE r.CO_BOOK='052' AND SUBSTRING(r.LEDR_KEY,22,2) IN ('01','11')
 GROUP BY SUBSTRING(r.LEDR_KEY,22,2)"
```

**Likely — but verify — the same `ITM_FINE <> 0` / `ITM_AMT = 0` style split seen in the sales-order
old-metal pair and the rate-cut issue rows.** Do not assume it; the guards are in the source.

### 2.3 The web path

`manufacturing/karigar.ts:554` `receiveKarigar`, route `POST /karigar/receive`. It already writes
`KR_DATA`, `KR_DETL` and `KR_IDTL` — **the `KR_DETL` write gap recorded earlier was a false positive and
has been retracted**; see the retraction note in `GAP-ANALYSIS-AND-PLAN.md`. Only the Rojmel is missing.

**Verified 2026-07-31:** `karigar.ts` contains **zero** occurrences of `ROJ_MEL_DATA`, so both the write
**and** the delete-list entry are missing. Unlike `rateCut.ts` and `salesOrder.ts`, where the delete side
was already in place, here both halves need adding.

### 2.4 Tests and controls

Follow §1.5/§1.6, plus:

- **type `11` carries fine AND gross; type `01` carries gross but NOT fine.** Assert both, and assert they
  are distinguished by whatever guard §2.2 established — not by row order.
- the two header money rows (`02` debit, `05` credit) are 23-char keys with no line number.
- only type `11` should reach the report's fine bucket; type `01` must not.

---

## 3. URD Purchase — book 043 — DROPPED, and here is why

An earlier draft of this plan said book 043 "has no `BOOK_DATA` row" and concluded the book had been
deleted. **That was wrong.** It has a row, and reading it changes the decision entirely:

```bash
SQL -d Live24 -Q "SET NOCOUNT ON; SELECT '  name='''+ISNULL(BOOK_NAME,'')+'''  mainBook='''+ISNULL(MAIN_BOOK,'')+'''  curUse='''+ISNULL(CUR_USE,'')+'''  tbl='''+ISNULL(BOOK_TBL_NAME,'')+'''' FROM BOOK_DATA WHERE CO_CODE='01' AND CO_BOOK='043'"
# name='Gold URD Purchase Old'  mainBook=''  curUse='N'  tbl=''
```

**`CUR_USE = 'N'` — the book is disabled.** Its `MAIN_BOOK` and `BOOK_TBL_NAME` have been cleared, and only
**2 of 210 books** are in that state (the other, 069, has zero Rojmel rows). The name ends in "Old", which
is how this company marks a superseded book — the same convention as "Gold Tax Invoice Old" (026), which was
replaced by "Gold Tax Invoice" (029).

So its 27 Rojmel rows are **historical**: written while the book was active and had a proper `MAIN_BOOK`,
and unreachable now because an operator cannot select a disabled book.

**Therefore the web is correct not to write them.** A new voucher cannot be created in a retired book, so
there is no code path that should produce these rows. They matter only for _reading_ migrated history, which
the report already handles — `rojmelReport.ts` reads whatever `ROJ_MEL_DATA` contains and does not care
which book wrote it.

This is worth stating carefully because it is the first family in this workstream that is **not a gap**.
Coverage arithmetic should treat these 27 rows as out of scope rather than outstanding, which is why the
target above is 3113 of 3179 rather than 3140. The remaining 66 rows after this plan
(3179 − 3113) are: wholesale 32 (§0, missing voucher family), URD 27 (retired), and 7 stragglers across
`SALES RETURNE`, `KARIGAR ISSUE`, `ORDER CANCEL`, `BILL REC` and `OTH EXP`/`OTH INC`.

## 4. Order of work, and the stop condition

1. **Fine JV** — 2 types, source and data agree, table already written. Land it, run the full sequence,
   commit.
2. **Karigar Receipt** — 4 types, but §2.2 must be answered from the source first.

That is the whole queue. **URD Purchase is not step 3** — see §3.

**Stop and reconsider if:** the measured row counts differ from this document (the database has changed,
so re-derive), or §2.2 cannot be settled from the source (implement type `11` only and record why `01` was
left).

## 5. Definition of done, per family

- [ ] Live types only; the dead ones listed in code with the count that proves them dead.
- [ ] Whether source and data agree, stated explicitly either way.
- [ ] Builder added, `rojmelLedrKey` union widened, `ROJ_MEL_DATA` in both the write set and the module's
      delete list.
- [ ] Unit vectors per §1.5, database assertions with an **exact-set** footprint (`toEqual`, never
      `toContain`).
- [ ] Every control in §1.6 demonstrated failing, then restored by `cp`.
- [ ] Full verification sequence from the handbook §8, browser smoke included.
- [ ] Handbook coverage table and queue row updated, **and each edit asserted** — an unasserted `replace()`
      silently no-opped twice already.
- [ ] Commit message states the row counts, what was skipped and why, and the control failure messages.

## 6. After the queue closes

At 98.8% the remaining work is not Rojmel row types. It is:

1. **The wholesale-sale voucher family** — §0. A missing form, not a missing projection.
2. **`OP_LDR`** — 7011 real rows, written per voucher across 35 books, and the web writes it from one
   config surface only. Larger than everything in this plan combined.
3. **A second customer database** — every priority here rests on one company and one fiscal year. A
   wholesale-heavy shop or a pawnbroker would invert the ranking entirely; the six dhrn/loan routines are
   dead here and might be the main event elsewhere.
