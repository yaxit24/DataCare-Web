# Implementation plan: sales-order Rojmel (book 020)

**Status:** ready to implement. Scope measured, shapes verified against real rows, one anomaly flagged.
**Written:** 2026-07-31. **Authority for every shape below:** the real desktop database `Live24`.

Self-contained by design. Assumes **no memory of prior sessions**. Every command copy-pasteable, every
number carries the query that produced it, every file reference verified against the tree on the date above.

---

## 0. Read this before anything else

### 0.1 The method, in the order that works

Four sessions of mistakes produced this order. Follow it exactly.

1. **Count the output.** `SELECT` the real `ROJ_MEL_DATA` rows for the book, grouped by `LEDR_KEY` type.
   That is the ground truth: it tells you which row types actually exist, with no inference.
2. **Count the source columns.** For each candidate type, check whether the column its insert is guarded on
   is non-zero in the source table. A type whose column is empty never fires.
3. **Read the source for STRUCTURE only** — which tables, which guards, which `BOOK_DETL` slot.
4. **Take DIRECTIONS and ACCOUNTS from the data**, never from the source, unless you have checked they agree
   for that specific type.

### 0.2 Why step 4 is stated so bluntly

On the rate-cut work (`docs/PLAN-RATECUT-ROJMEL.md`) the plan's rules were written from `Ac_Rojmel.cs` and
were **wrong on five of nine types** — the source had debit and credit reversed on four of them and the
plan wrongly claimed three row families were money-free. `Ac_Rojmel.cs` is a **later version** than the code
that wrote `Live24`, independently proven by sale item rows being type `'02'` in the source and `'01'` in
the data.

**But it is not uniformly wrong.** For `Order_Rojmel` the source and the data **agree on all four live
types** — verified below, type by type. So the rule is not "distrust the source", it is **"verify per type,
and let the data settle any disagreement"**.

### 0.3 Mistakes already made on this table, so they are not made again

- Sampling data cannot enumerate code paths that never fired — settlement rows are guarded by
  `AND <col> <> 0`, so a plain voucher emits none of them.
- Reading source cannot tell you which paths are live — `Fine_CUT_Rojmel` reads `CUT_DATA`/`CUT_DETL`, both
  **0 rows**, and is dead code for this customer.
- Counting rows in a routine's _tables_ is not enough — `SL_ORD_ADJ` has 110 rows but `PAID_AMT` is non-zero
  on **1**, so `Order_Adj_Rojmel` contributes about one row a year.

---

## 1. Environment bring-up

### 1.1 Postgres — the web's database

```bash
export PATH=/opt/homebrew/opt/postgresql@16/bin:$PATH
export DATABASE_URL='postgresql://app_user:imgValidationSecret2026x@127.0.0.1:55433/datacare?schema=public'
export MIGRATE_DATABASE_URL='postgresql://postgres@127.0.0.1:55433/datacare?schema=public'
export RUN_DB_INTEGRITY_TESTS=1 RUN_DB_SECURITY_TESTS=1
pg_isready -h 127.0.0.1 -p 55433          # expect: accepting connections
```

Port **55433** only, never 5432. Do not pass `?schema=public` to `psql`.

**The RLS trap, which has produced silent wrong answers three times.** `app_user` is subject to row-level
security. Reads outside a tenant context return **zero rows with no error**. For ad-hoc inspection connect
as `postgres`:

```bash
psql 'postgresql://postgres@127.0.0.1:55433/datacare' -tAc 'SELECT count(*) FROM "ROJ_MEL_DATA"'
```

In tests, wrap every statement in `withTenant`. See §9.2 — this bit twice in one hour on the rate-cut work.

### 1.2 SQL Server — the real desktop database

```bash
cd /Users/yakshitsavaliya/Desktop/imodule-extracted
docker ps --format '{{.Names}}' | grep -q dc-mssql || docker start dc-mssql
sleep 25   # slow: amd64 emulation on arm64

SQL() { docker exec dc-mssql /opt/mssql-tools18/bin/sqlcmd \
          -S localhost -U sa -P 'ParityProbe#2026x' -C -W -s'|' -h -1 "$@"; }
SQL -d Live24 -Q "SET NOCOUNT ON; SELECT 'rojmel='+CAST(count(*) AS varchar) FROM ROJ_MEL_DATA"
# expect: rojmel=3179
```

If the container is gone, recreate it and re-attach — full procedure in
`docs/PLAN-RATECUT-ROJMEL.md` §1.2.

**Real customer data.** 918 accounts, real names. Never commit it, never echo customer names into output,
commit messages or test fixtures. Extract counts and structure only. `unified/` is git-ignored; confirm any
new artifact path with `git check-ignore` before writing to it.

---

## 2. Scope, measured

### 2.1 Target

Book **020** "Sales Order" — **55** real Rojmel rows. Routine `Order_Rojmel`,
`unified/src/csharp/DataCareNext/Ac_Rojmel.cs` **lines 9–28**.

Extract the SQL readably:

```bash
python3 - <<'PY'
import re
lines=open('unified/src/csharp/DataCareNext/Ac_Rojmel.cs',errors='replace').read().split('\n')
for i in range(8,29):
    l=lines[i]
    if 'INSERT INTO ROJ_MEL_DATA' not in l: continue
    ty=re.search(r"\+'(\d+)'(\+ ?[Ss]tr\(A\.SR_NO\))?",l)
    sel=re.search(r'MAIN_BOOK,\s+(.*?)\s+FROM',l,re.S)
    frm=re.search(r'FROM\s+\(*([A-Z_0-9]+)\s+AS',l)
    whr=re.search(r'"\s*(AND [^"]{0,110})"\)\);',l)
    print(f"line {i+1} type={ty.group(1) if ty else '?'}{'+sr' if ty and ty.group(2) else ''} from={frm.group(1) if frm else '?'}")
    if sel: print('   ',sel.group(1)[:250])
    if whr: print('    WHERE',whr.group(1)[:110])
PY
```

**Column order in the INSERT matters for reading it:** `… AC_CODE, LD_CODE, CR_AMT, DR_AMT, AC_NAME,
IT_TYPE, SIGN, ITM_PCS, ITM_GWT, ITM_NWT, ITM_TOUCH, ITM_WEST, ITM_FINE, ITM_RATE, …`. So the third
selected value is the **credit** and the fourth the **debit**. Misreading that order is how the rate-cut
plan got four directions backwards.

### 2.2 Eight row types exist; four fire

```bash
SQL -d Live24 -Q "SET NOCOUNT ON;
SELECT '  type='+SUBSTRING(LEDR_KEY,22,2)+' n='+CAST(count(*) AS varchar)
 +'  it='+MAX(ISNULL(IT_TYPE,'-'))+' sign='+MAX(CASE WHEN ISNULL(SIGN,'')='' THEN '_' ELSE SIGN END)
 +'  withDr='+CAST(SUM(CASE WHEN ISNULL(DR_AMT,0)<>0 THEN 1 ELSE 0 END) AS varchar)
 +'  withCr='+CAST(SUM(CASE WHEN ISNULL(CR_AMT,0)<>0 THEN 1 ELSE 0 END) AS varchar)
 +'  withFine='+CAST(SUM(CASE WHEN ISNULL(ITM_FINE,0)<>0 THEN 1 ELSE 0 END) AS varchar)
 +'  keyLen='+CAST(MAX(LEN(LEDR_KEY)) AS varchar)
 FROM ROJ_MEL_DATA WHERE CO_BOOK='020' GROUP BY SUBSTRING(LEDR_KEY,22,2) ORDER BY count(*) DESC"
```

| Type | Rows | `IT_TYPE` | `SIGN` | Dr     | Cr     | Fine  | Key len | Source table  | Guard                           |
| ---- | ---- | --------- | ------ | ------ | ------ | ----- | ------- | ------------- | ------------------------------- |
| `01` | 41   | `A`       | blank  | 0      | **41** | 0     | 23      | `SL_ORD_DATA` | `ADV_AMT <> 0`                  |
| `02` | 11   | `A`       | blank  | **11** | 0      | 0     | 23      | `SL_ORD_DATA` | `CHQ_AMT <> 0`                  |
| `04` | 2    | `A`       | blank  | **2**  | 0      | **2** | **33**  | `SL_PR_DETL`  | `NET_AMT <> 0`                  |
| `06` | 1    | `G`       | `+`    | 0      | 0      | **1** | **33**  | `SL_PR_DETL`  | `ITM_FINE <> 0 AND NET_AMT = 0` |

41 + 11 + 2 + 1 = **55**. ✅ Matches the book exactly.

### 2.3 Source and data AGREE here — checked per type

Unlike the rate-cut routine. Verified by mapping each source selection onto the observed row:

| Type | Source selects                                                                       | Observed                   | Agree? |
| ---- | ------------------------------------------------------------------------------------ | -------------------------- | ------ |
| `01` | `AC_CODE=party, LD_CODE=slot1, CR=ADV_AMT, DR=0`                                     | 41 credits                 | ✅     |
| `02` | `AC_CODE=BANK_AC, LD_CODE=party, CR=0, DR=CHQ_AMT`                                   | 11 debits                  | ✅     |
| `04` | `AC_CODE=PURC_AC, LD_CODE=party, CR=0, DR=NET_AMT`, `IT_TYPE 'A'`, carries weights   | 2 debits, `A`, fine+gwt    | ✅     |
| `06` | `AC_CODE=party, LD_CODE=PURC_AC, CR=0, DR=0`, `IT_TYPE=IT_TYPE`, `SIGN '+'`, weights | 1 row, `G` `+`, money-free | ✅     |

**Still verify these four assertions yourself before coding** (§4 Step 2). Agreement on a previous read is
not a substitute.

### 2.4 Dead types, and one anomaly that must NOT be implemented blind

```bash
SQL -d Live24 -Q "SET NOCOUNT ON;
SELECT '  rows='+CAST(count(*) AS varchar)
+'  ADV_AMT='+CAST(SUM(CASE WHEN ISNULL(ADV_AMT,0)<>0 THEN 1 ELSE 0 END) AS varchar)
+'  CHQ_AMT='+CAST(SUM(CASE WHEN ISNULL(CHQ_AMT,0)<>0 THEN 1 ELSE 0 END) AS varchar)
+'  CARD_AMT='+CAST(SUM(CASE WHEN ISNULL(CARD_AMT,0)<>0 THEN 1 ELSE 0 END) AS varchar)
+'  SCHM_AMT='+CAST(SUM(CASE WHEN ISNULL(SCHM_AMT,0)<>0 THEN 1 ELSE 0 END) AS varchar)
+'  RCUT_FINE='+CAST(SUM(CASE WHEN ISNULL(RCUT_FINE,0)<>0 THEN 1 ELSE 0 END) AS varchar) FROM SL_ORD_DATA"
# rows=76  ADV_AMT=74  CHQ_AMT=21  CARD_AMT=0  SCHM_AMT=7  RCUT_FINE=0
```

- **Type `03`** card — `CARD_AMT` is **0 of 76**. Dead. Do not build.
- **Type `07`** rate-cut fine — `RCUT_FINE` is **0 of 76**. Dead. Do not build.
- **Type `08`** UPI — reads `UPI_DATA`, which has **1** row company-wide. Effectively dead. Do not build.
- **Type `05`** scheme adjustment — ⚠️ **ANOMALY. `SCHM_AMT` is non-zero on 7 of 76 orders, yet there are
  ZERO type-05 Rojmel rows.** Seven populated source rows produced no output.

  **Do not implement type `05` until that is explained.** Possible causes, in order of likelihood: the
  routine version that wrote this data lacked the type-05 insert; the seven orders fall outside the date
  window the Rojmel was built over; or a guard not visible in the extracted `WHERE` tail suppressed them.
  Implementing it would add rows the desktop does not have, which is a parity failure in the opposite
  direction from a missing row and harder to notice.

  Investigate with:

  ```bash
  SQL -d Live24 -Q "SET NOCOUNT ON; SELECT '  vch='+VCH_NO+' schmAmt='+CAST(CAST(SCHM_AMT AS decimal(12,2)) AS varchar)+' date='+CONVERT(varchar,VCH_DATE,23)+' advAmt='+CAST(CAST(ISNULL(ADV_AMT,0) AS decimal(12,2)) AS varchar) FROM SL_ORD_DATA WHERE ISNULL(SCHM_AMT,0)<>0"
  ```

  then check whether those vouchers have any Rojmel rows at all.

### 2.5 `BOOK_DETL` slot for book 020

**Slots are per-book.** Book 020's differ from 026's and 064's — this has already caused one plan error.

```bash
SQL -d Live24 -Q "SET NOCOUNT ON; SELECT '  slot'+CAST(CAST(SR_NO AS int) AS varchar)+'='+ISNULL(AC_CODE,'-') FROM BOOK_DETL WHERE CO_CODE='01' AND CO_BOOK='020' ORDER BY SR_NO"
# slot1=00001   slot2=00020
```

Type `01`'s `LD_CODE` on real rows is `00001` = **slot 1**. Confirmed:

```
t01 ac=000932 ld=00001 cr=25000.00
t01 ac=000888 ld=00001 cr=100000.00
```

Resolve with `resolveBookAccountTx(tx, scope, bookPolicy, 1)` — `apps/api/src/modules/shared/bookPolicy.ts:97`.
Never hardcode.

### 2.6 The two `SL_PR_DETL` types are the interesting pair

`SL_PR_DETL` is old metal taken in against an order. Only **3** of its 25 rows belong to book 020, which is
why types `04` and `06` have 2 and 1 rows.

They split on whether the metal was **valued**:

- **Type `04`** — `NET_AMT <> 0`: the metal has a price. `IT_TYPE 'A'` (a money row) **but it still carries
  `ITM_PCS`, `ITM_GWT`, `ITM_NWT`, `ITM_TOUCH` and `ITM_FINE`.** Deliberate: the day book shows metal taken
  in exchange without counting it as a metal _sale_. Same pattern as the sale's type `16`, already
  implemented in `buildSaleRojmel`'s `oldMetal` settlement.
- **Type `06`** — `ITM_FINE <> 0 AND NET_AMT = 0`: metal taken with **no** value assigned. `IT_TYPE` is the
  metal letter, `SIGN '+'`, and both amounts are zero. This is a true fine row and **will feed the report's
  gold/silver fine summaries**, which filter `ITM_FINE <> 0` split by `SIGN`.

The two are **mutually exclusive by construction** — one requires `NET_AMT <> 0`, the other `NET_AMT = 0`.
A test should pin that.

### 2.7 Key lengths: types 04 and 06 carry a line number

```bash
SQL -d Live24 -Q "SET NOCOUNT ON; SELECT '  type='+SUBSTRING(LEDR_KEY,22,2)+' len='+CAST(LEN(LEDR_KEY) AS varchar)+' n='+CAST(count(*) AS varchar) FROM ROJ_MEL_DATA WHERE CO_BOOK='020' GROUP BY SUBSTRING(LEDR_KEY,22,2),LEN(LEDR_KEY) ORDER BY SUBSTRING(LEDR_KEY,22,2)"
# 01 len=23 · 02 len=23 · 04 len=33 · 06 len=33
```

Types `01`/`02` are header rows — one per voucher, **no** line number. Types `04`/`06` are per detail line —
**33 characters, with the line number right-aligned in 10**.

**This is not cosmetic.** `ROJ_MEL_DATA`'s primary key is `LEDR_KEY` **alone**:

```bash
psql 'postgresql://postgres@127.0.0.1:55433/datacare' -tAc "
SELECT i.relname||' ('||string_agg(a.attname,', ' ORDER BY k.ord)||')'
FROM pg_index x JOIN pg_class i ON i.oid=x.indexrelid JOIN pg_class t ON t.oid=x.indrelid
CROSS JOIN LATERAL unnest(x.indkey) WITH ORDINALITY k(attnum,ord)
JOIN pg_attribute a ON a.attrelid=t.oid AND a.attnum=k.attnum
WHERE t.relname='ROJ_MEL_DATA' AND x.indisprimary GROUP BY i.relname"
# ROJ_MEL_DATA_pkey (tenant_id, LEDR_KEY)
```

Two detail lines without a line number collide with **`23505`**. That has happened four times in this
project.

---

## 3. Files to change

| Path                                                | Change                                             |
| --------------------------------------------------- | -------------------------------------------------- |
| `web/apps/api/src/modules/shared/rojmel.ts`         | add `ROJMEL_ORDER_ROW_TYPE` + `buildOrderRojmel()` |
| `web/apps/api/src/modules/sales/salesOrder.ts`      | call it; add `ROJ_MEL_DATA` to the write set       |
| `web/apps/api/test/rojmel.test.ts`                  | unit vectors (38 tests at time of writing)         |
| `web/apps/api/test/salesFamilyLifecycle.db.test.ts` | DB assertions + footprint (22 tests)               |

### 3.1 What exists and must be reused

`apps/api/src/modules/shared/rojmel.ts`, verified line numbers **2026-07-31**:

| Export                    | Line |
| ------------------------- | ---- |
| `ROJMEL_ROW_TYPE`         | 42   |
| `RojmelRowType`           | 78   |
| `RojmelMetal`             | 81   |
| `rojmelMetalFor`          | 89   |
| `RojmelKeyScope`          | 98   |
| `rojmelLedrKey`           | 113  |
| `RojmelRow`               | 131  |
| `RojmelContext`           | 161  |
| `RojmelSettlement`        | 185  |
| `RojmelLine`              | 201  |
| `buildMoneyRojmel`        | 274  |
| `buildSaleRojmel`         | 321  |
| `ROJMEL_CASH_ROW_TYPE`    | 482  |
| `buildCashRojmel`         | 484  |
| `ROJMEL_RATECUT_ROW_TYPE` | 540  |
| `RojmelRateCutRowType`    | 552  |
| `RateCutRojmelLegs`       | 555  |
| `buildRateCutRojmel`      | 628  |
| `buildJournalRojmel`      | 754  |

Read the whole file before adding. It is ~800 lines and every rule already carries its evidence.

**`rojmelLedrKey`'s `rowType` parameter is a union** — `RojmelRowType | RojmelRateCutRowType`. Adding a new
family means widening it again, not casting. A cast was written once and removed for that reason.

**`RojmelContext.key` is mandatory** and must be the voucher key object. `postVoucherTx` does **not** add
key columns; omitting it writes orphan rows with NULL `CO_BOOK`/`VCH_NO` that no report can find.

### 3.2 `LEDR_KEY` layout

```
CO_CODE(2) LC_CODE(2) CO_YEAR(9) CO_BOOK(3) VCH_NO(5) TYPE(2) [lineNo right-aligned in 10]
```

Real 33-char example reproduced byte-for-byte by an existing test:
`'01002024-20250270000101         1'` — nine spaces before the `1`.

---

## 4. Implementation steps

### Step 1 — baseline must be green

```bash
cd /Users/yakshitsavaliya/Desktop/imodule-extracted/web
(cd apps/api && npx vitest run 2>&1 | grep -E "Test Files|Tests ")
# expect 123 files / 1015 tests at time of writing
```

If red, **stop and fix that first**. Never build on a red suite.

### Step 2 — re-verify the four shapes yourself

Run the queries in §2.2, §2.4, §2.5 and §2.7. Confirm:

- 55 rows across exactly 4 types with the counts in the table;
- `CARD_AMT` and `RCUT_FINE` are 0;
- `SCHM_AMT` is 7 with **zero** type-05 rows (the anomaly);
- slot 1 is `00001` and matches type 01's `LD_CODE`;
- key lengths 23 / 23 / 33 / 33.

If any number differs from this document the database has changed and **scope must be re-derived** before
coding.

### Step 3 — `buildOrderRojmel` in `rojmel.ts`

```ts
export const ROJMEL_ORDER_ROW_TYPE = {
  ADVANCE: '01', // 41 rows, CREDIT, contra = BOOK_DETL slot 1
  CHEQUE: '02', // 11 rows, DEBIT, AC_CODE = the bank
  OLD_METAL_VALUED: '04', // 2 rows, DEBIT, IT_TYPE 'A' but carries weight, per line
  OLD_METAL_UNVALUED: '06', // 1 row, money-free fine row, IT_TYPE = metal, SIGN '+', per line
} as const;

export interface OrderRojmelLegs {
  /** BOOK_DETL slot 1 — contra on the advance row. Book 020: `00001`. */
  advanceContraAc: string;
  bankAc: string;
  advanceAmount: number;
  chequeAmount: number;
  oldMetal: {
    lineNo: number;
    purchaseAc: string;
    netAmount: number; // >0 → type 04 ; =0 with fine → type 06
    metal: Exclude<RojmelMetal, 'A'>;
    pcs?: number;
    grossWt?: number;
    netWt?: number;
    touch?: number;
    fine?: number;
    itemCode?: string;
    itemName?: string;
  }[];
}
export function buildOrderRojmel(ctx: RojmelContext, legs: OrderRojmelLegs): RojmelRow[];
```

Rules, each traceable to §2.2/§2.3/§2.6:

- Emit each row **only when its amount is non-zero** — the desktop guards every insert with `<> 0`.
- Type `01`: `AC_CODE` = party, `LD_CODE` = `advanceContraAc`, **`CR_AMT`** = advance. No line number.
- Type `02`: `AC_CODE` = `bankAc`, `LD_CODE` = party, **`DR_AMT`** = cheque. No line number. Note the
  account order is **reversed** relative to type 01.
- Type `04`, per line where `netAmount !== 0`: `AC_CODE` = `purchaseAc`, `LD_CODE` = party,
  **`DR_AMT`** = `netAmount`, `IT_TYPE 'A'`, **weights populated**, `lineNo` passed.
- Type `06`, per line where `netAmount === 0 && fine`: `AC_CODE` = party, `LD_CODE` = `purchaseAc`,
  both amounts **0**, `IT_TYPE` = metal, `SIGN '+'`, weights populated, `lineNo` passed.
- Types `04` and `06` are **mutually exclusive per line** — the guards are `NET_AMT <> 0` and
  `NET_AMT = 0`.
- **Do not implement types `03`, `05`, `07`, `08`.** See §2.4; `05` in particular is an unresolved anomaly.

### Step 4 — wire `salesOrder.ts`

`ROJ_MEL_DATA` already appears at lines **406** and **852** — confirm they are delete/rewrite lists, not
writes:

```bash
grep -n "ROJ_MEL_DATA" -B 4 apps/api/src/modules/sales/salesOrder.ts
```

If they are delete lists, the reversal side is already correct and only the write is missing.

Add to the `writes:` array:

```ts
...(rojmelRows.length ? [{ table: 'ROJ_MEL_DATA', rows: rojmelRows }] : []),
```

Resolve slot 1 with `resolveBookAccountTx` **only when an advance applies** — an unused lookup costs a round
trip and throws if the slot is unconfigured.

**Existing behaviour to respect:** an order posts `AC_DATA` **only when it carries an advance**. That was
established earlier and is pinned by a conditional test asserting both directions. An order must **not**
write `TAX_DATA` — it is a commitment, not a taxable supply. Do not disturb either.

---

## 5. Tests required

### 5.1 Unit vectors — `apps/api/test/rojmel.test.ts`

Add a `describe('sales order (book 020) — 4 live types of 8', …)`. Reuse the file's `ctx` fixture with
`coBook: '020'`.

1. **Zero input produces `[]`.**
2. **Type 01 is a CREDIT**, `AC_CODE` = party, `LD_CODE` = slot 1.
3. **Type 02 is a DEBIT**, `AC_CODE` = bank, `LD_CODE` = party — assert the account order is the **reverse**
   of type 01, explicitly comparing both fields.
4. **Type 04 carries weight while `IT_TYPE` is `'A'`** — the pattern that lets the day book show metal taken
   in exchange without counting it as a metal sale. Assert `IT_TYPE === 'A'` **and** `ITM_GWT > 0`.
5. **Type 06 is money-free**: `DR_AMT === 0 && CR_AMT === 0`, `IT_TYPE` = metal, `SIGN '+'`, `ITM_FINE > 0`.
6. **04 and 06 are mutually exclusive per line** — a line with `netAmount > 0` yields `04` and never `06`;
   a line with `netAmount === 0` and fine yields `06` and never `04`.
7. **Key lengths**: `01`/`02` are 23 characters, `04`/`06` are 33 with the line number right-aligned in 10.
8. **Two detail lines produce distinct keys** — the direct guard against `23505`.
9. **Dead types never appear**: assert no row carries type `03`, `05`, `07` or `08`.

### 5.2 Database assertions — `apps/api/test/salesFamilyLifecycle.db.test.ts`

That file already exercises `createSalesOrder` and has `ROJ_MEL_DATA` in its cleanup list. Confirm:

```bash
grep -n "ROJ_MEL_DATA\|createSalesOrder" apps/api/test/salesFamilyLifecycle.db.test.ts | head
```

1. **Rows persist** for an order with an advance — query inside `withTenant`.
2. **The advance row is a credit** and its amount equals the order's advance.
3. **An order with no advance writes no type-01 row**, mirroring the existing ledger-conditional rule.
4. **Footprint** pinned as an **exact set** with `toEqual`, never `toContain`. A subset assertion cannot see
   an unexpected extra write, and an extra write is how a duplicate posting appears — a weakness found and
   fixed in the sales-return test for precisely this reason.
5. **Edit does not duplicate** — create, edit, assert no `23505` and the row count is as expected.

---

## 6. Controls that must be proven failing

**A gate is not trusted until demonstrated failing.** Back up first, break, run the named test, confirm the
message, restore by copy — never by hand-editing back.

```bash
R=apps/api/src/modules/shared/rojmel.ts; cp $R /tmp/ord.bak
# ...break...
(cd apps/api && npx vitest run test/rojmel.test.ts 2>&1 | grep -E "→|Tests ")
cp /tmp/ord.bak $R
```

| #   | Break                                              | Expected failure                                                              |
| --- | -------------------------------------------------- | ----------------------------------------------------------------------------- |
| 1   | Make type 01 a debit                               | credit assertion fails                                                        |
| 2   | Stop reversing the accounts on type 02             | account-order assertion fails                                                 |
| 3   | Give type 04 a metal `IT_TYPE`                     | type-04 assertion fails — and the report's metal bucket would wrongly gain it |
| 4   | Put money on type 06                               | money-free assertion fails                                                    |
| 5   | Drop `lineNo` from types 04/06                     | key-length test fails, and the DB raises `23505` on two lines                 |
| 6   | Remove the `<> 0` guards                           | zero-input test fails                                                         |
| 7   | Drop the `ROJ_MEL_DATA` write from `salesOrder.ts` | footprint fails **naming the table**                                          |

Control 5 is the important one: it should fail **twice** — once in the unit test on key length and once in
the database on the primary key.

---

## 7. Verification sequence — all of it, before committing

```bash
cd /Users/yakshitsavaliya/Desktop/imodule-extracted/web
export PATH=/opt/homebrew/opt/postgresql@16/bin:$PATH
export DATABASE_URL='postgresql://app_user:imgValidationSecret2026x@127.0.0.1:55433/datacare?schema=public'
export MIGRATE_DATABASE_URL='postgresql://postgres@127.0.0.1:55433/datacare?schema=public'
export RUN_DB_INTEGRITY_TESTS=1 RUN_DB_SECURITY_TESTS=1

npx prettier --write .
(cd apps/api && npx tsc -p tsconfig.json --noEmit)      # silent
(cd apps/web && npx tsc -p tsconfig.json --noEmit)      # silent
(cd apps/api && npx vitest run)                         # 1015 + new
(cd apps/web && npx vitest run)                         # 18
pnpm lint                                               # 0 violations
npx prettier --check .
pkill -f "next-server"; pnpm build --force              # 7/7
pnpm settings:parity                                    # 128/128
pnpm schema:readiness
pnpm fresh:provision                                    # 172 tables, 1 allowed drift
node scripts/report-baselines.mjs                       # 254 unchanged — never --write
node scripts/check-g5-parity.mjs                        # G5_RED expected and correct
(cd apps/web && node test/browser.smoke.mjs)            # AFTER build, exit 0
```

Time-wasters already encountered:

- `pkill -f "next-server"` before `build --force` — stale servers hold the build directory.
- Piping to `head` makes `$?` report **head's** status. Check exit codes without a pipe.
- `timeout` does not exist on macOS.
- **Test files are not typechecked.** `tsc -p tsconfig.json` includes `src` only. `tsconfig.test.json`
  exists and does include them but surfaces 112 pre-existing errors and is **not** a gate. A type error in a
  new test will not be caught — read new test code carefully.

---

## 8. Invariants that must not be broken

Each has caused a real failure here.

1. **`ROJ_MEL_DATA`'s primary key is `LEDR_KEY` alone.** Any table added to a write set must also be in
   every DB test cleanup list. This bit **four times** before a sweep added it to 20 files.
2. **`insertRowTx(tx, TABLE, tenantId, row)`** — tenant is a separate argument.
3. **`postVoucherTx` does not add voucher key columns.** Spread `...key` yourself.
4. **Every statement in a DB test runs inside `withTenant`.** Outside it, reads return 0 and `DELETE` is a
   silent no-op.
5. **`tenant_id` is `varchar(24)`** — short kebab tenants in tests, never UUIDs.
6. **Slice text to real widths**, fixtures included. `ITEM_MAST.IT_CODE` is `varchar(5)`; `'SILVER'` fails
   `22001`. Read widths from `information_schema` rather than guessing.
7. **Never weaken a test to make it pass.**
8. **A control on `packages/core` needs `pnpm --filter @datacare/core build`** — vitest transpiles
   `apps/api/src` on the fly but not that package. A control once "passed" twice against a broken build.
9. **Assert that string replacements landed.** Prettier reflows files, so an exact-match `replace()` can
   silently no-op and report success. This produced a stale doc claiming an implemented feature was
   missing. Match on content, assert before and after.

## 9. Two traps specific to this work

### 9.1 `footprintOf` expects an owner client

`apps/api/test/support/footprint.ts:49` reads directly and swallows errors:
`.catch(() => [{ n: 0 }])`. Handed an RLS-bound client it turns every blocked read into a count of zero, so
the footprint comes back **empty rather than failing**. Pass a tenant-scoped transaction:

```ts
const touched = await withTenant(prisma, tenantId, (tx: any) =>
  footprintOf(tx, tables, tenantId, vchNo),
);
```

### 9.2 A silent zero is worse than an error

On the rate-cut work a query helper read outside `withTenant` and reported **0 rows** while the report —
which scopes internally — correctly saw a fine of 10. The contradiction is what exposed it. When a count is
unexpectedly zero, **suspect the tenant context before suspecting the code**.

## 10. Definition of done

- [ ] `buildOrderRojmel` implemented for the **4 live types only**, each with a comment citing its row count
      and guard from §2.2.
- [ ] Types `03`, `05`, `07`, `08` **not** implemented; the type-`05` anomaly recorded in a code comment.
- [ ] `salesOrder.ts` writes `ROJ_MEL_DATA`; existing advance-conditional ledger behaviour undisturbed.
- [ ] 9 unit vectors from §5.1 and 5 DB assertions from §5.2.
- [ ] All 7 controls in §6 demonstrated failing, then restored — control 5 failing in **both** places.
- [ ] Full verification in §7 green, browser smoke included.
- [ ] Commit message states what was skipped and why, the control failure messages, and the row counts.
- [ ] `docs/GAP-ANALYSIS-AND-PLAN.md` coverage row for **020** changed to written — **and the change
      asserted**, per invariant 9. The 064 row silently failed to update once already.

## 11. Queue after this

| Book                      | Rows | Routine               | Line | First step                                                                |
| ------------------------- | ---- | --------------------- | ---- | ------------------------------------------------------------------------- |
| 076 Member Advance Adjust | 37   | `Schm_Adj_RojMel`     | 458  | count non-zero in `AD_ADJ` (26 rows)                                      |
| 052 Karigar Receipt       | 28   | `Kr_Rec_Rojmel`       | 364  | Rojmel only — the `KR_DETL` write gap was a false positive, now retracted |
| 078 Fine Jv               | 28   | —                     | —    | identify the routine first                                                |
| 043 Gold URD Purchase Old | 27   | `Purc_Rojmel` variant | 115  | check `MAIN_BOOK`                                                         |
| 034 Wh Sales              | 32   | `Wh_Sales_Rojmel`     | 221  | purchase-side types, already built in the shared builder                  |

**Always run the column-count step first.** It removed `Order_Adj_Rojmel` from the queue entirely, cut rate
cut from 40 row types to 9, and cut this piece from 8 to 4.
