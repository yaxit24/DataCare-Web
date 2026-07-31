# Implementation plan: rate cut / wholesale Rojmel (book 064, 034)

**Status:** ready to implement. Analysis complete, scope measured, nothing left to discover.
**Written:** 2026-07-31. **Owner of the facts below:** the real desktop database `Live24`, restored locally.

This document is deliberately self-contained. It assumes **no memory of previous sessions** and no context
beyond what is written here. Every command is copy-pasteable, every file path is absolute-from-repo-root,
every number has the query that produced it.

---

## 0. Why this document exists

Earlier sessions repeatedly re-derived facts that were already established, and twice started work on the
wrong target. Three specific mistakes are worth stating because this plan is shaped to avoid them:

1. **Deriving rules from sampled data alone.** Settlement rows are guarded by `AND <column> <> 0` in the
   desktop, so a cash-settled sale emits none of them. Absence in output looked like absence in code.
2. **Reading source alone.** `Fine_CUT_Rojmel` is named as if it implements rate cut. It reads `CUT_DATA`
   and `CUT_DETL`, both **0 rows** — dead code for this customer. Implementing from it would have produced
   a faithful transcription of something no shop runs.
3. **Counting rows in a routine's tables.** `SL_ORD_ADJ` has 110 rows, so `Order_Adj_Rojmel` looked like
   the top priority. But `PAID_AMT` is non-zero on **1** row and `KASAR_AMT` on **0** — the only columns it
   reads. It contributes ~1 row a year.

**The rule that survived all three:** count the **output** the desktop actually produced, then count the
**source columns** that are non-zero. Both are cheap. Do them before writing code.

---

## 1. Environment bring-up

### 1.1 Postgres (the web's database)

```bash
export PATH=/opt/homebrew/opt/postgresql@16/bin:$PATH
export DATABASE_URL='postgresql://app_user:imgValidationSecret2026x@127.0.0.1:55433/datacare?schema=public'
export MIGRATE_DATABASE_URL='postgresql://postgres@127.0.0.1:55433/datacare?schema=public'
export RUN_DB_INTEGRITY_TESTS=1 RUN_DB_SECURITY_TESTS=1
pg_isready -h 127.0.0.1 -p 55433          # expect: accepting connections
```

Port **55433** only. Never 5432. Do **not** pass `?schema=public` to `psql` — it is a Prisma-ism and psql
rejects it.

**Trap that has cost time twice:** `app_user` is subject to row-level security. Querying as `app_user`
outside a tenant context returns **zero rows silently** — not an error. For ad-hoc inspection always
connect as `postgres`:

```bash
psql 'postgresql://postgres@127.0.0.1:55433/datacare' -tAc 'SELECT count(*) FROM "ROJ_MEL_DATA"'
```

### 1.2 SQL Server (the real desktop database)

```bash
cd /Users/yakshitsavaliya/Desktop/imodule-extracted
docker ps --format '{{.Names}}' | grep -q dc-mssql || docker start dc-mssql
sleep 25   # it is slow: amd64 emulation on arm64

SQL() { docker exec dc-mssql /opt/mssql-tools18/bin/sqlcmd \
          -S localhost -U sa -P 'ParityProbe#2026x' -C -W -s'|' -h -1 "$@"; }
SQL -d Live24 -Q "SET NOCOUNT ON; SELECT 'rojmel rows='+CAST(count(*) AS varchar) FROM ROJ_MEL_DATA"
# expect: rojmel rows=3179
```

If the container is gone entirely, recreate it:

```bash
docker run -d --name dc-mssql --platform linux/amd64 \
  -e ACCEPT_EULA=Y -e 'MSSQL_SA_PASSWORD=ParityProbe#2026x' -e MSSQL_PID=Developer \
  -p 11433:1433 -v "$(pwd)/unified/database/backups:/backups:ro" \
  mcr.microsoft.com/mssql/server:2022-latest
```

`Live24` is attached from `unified/database/backups/Next24.mdf`. Attaching a loose `.mdf` requires
`docker cp` into the container, then **as root** `chmod 660 && chown mssql:mssql`, else `Msg 3415`
read-only upgrade failure. Then:
`CREATE DATABASE [Live24] ON (FILENAME='...mdf'),(FILENAME='...ldf') FOR ATTACH`.

**This database contains real customer data** — 918 accounts, real names. Never commit it, never echo
customer names into output or commit messages. Extract counts and structure only. `unified/` and
`project-memory/parity/bundles/` are already git-ignored; verify with `git check-ignore <path>` before
writing any new artifact there.

---

## 2. What is being built, and the evidence for its scope

### 2.1 The target

Book **064** "Rate Cut and Fine issue / Receipt" (66 real Rojmel rows) and book **034** "Wh Sales" (32).
They share one desktop routine and one table, so they are one piece of work.

### 2.2 The recipe's location

`unified/src/csharp/DataCareNext/Ac_Rojmel.cs`, routine `Wh_Sales_Rojmel`, **lines 221–311**.

Read it with:

```bash
sed -n '221,311p' unified/src/csharp/DataCareNext/Ac_Rojmel.cs
```

It is decompiled VB with heavy `Operators.ConcatenateObject` noise. To extract the SQL readably:

```bash
python3 - <<'PY'
import re
lines=open('unified/src/csharp/DataCareNext/Ac_Rojmel.cs',errors='replace').read().split('\n')
for i in range(220,312):
    l=lines[i]
    if 'INSERT INTO ROJ_MEL_DATA' not in l: continue
    ty=re.search(r"\+'(\d+)'(\+ ?[Ss]tr\(A\.SR_NO\))?",l)
    sel=re.search(r'MAIN_BOOK,\s+(.*?)\s+FROM',l,re.S)
    frm=re.search(r'FROM\s+\(*([A-Z_0-9]+)\s+AS',l)
    whr=re.search(r'"\s*(AND [^"]{0,110})"\)\);',l)
    print(f"line {i+1} type={ty.group(1) if ty else '?'}{'+sr' if ty and ty.group(2) else ''} from={frm.group(1) if frm else '?'}")
    if sel: print('   ',sel.group(1)[:240])
    if whr: print('    WHERE',whr.group(1)[:110])
PY
```

### 2.3 Scope: 9 row types, not 40

`Wh_Sales_Rojmel` contains **40+ row types**. Only **9** ever fired in a year of this shop's trading.

Reproduce the count:

```bash
SQL -d Live24 -Q "SET NOCOUNT ON;
SELECT '  type='+SUBSTRING(LEDR_KEY,22,2)+' n='+CAST(count(*) AS varchar)
  +' itType='+MAX(ISNULL(IT_TYPE,'-'))+' sign='+MAX(CASE WHEN ISNULL(SIGN,'')='' THEN '_' ELSE SIGN END)
  +' fineRows='+CAST(SUM(CASE WHEN ISNULL(ITM_FINE,0)<>0 THEN 1 ELSE 0 END) AS varchar)
  FROM ROJ_MEL_DATA WHERE CO_BOOK='064'
 GROUP BY SUBSTRING(LEDR_KEY,22,2) ORDER BY count(*) DESC"
```

| Type | Rows | `IT_TYPE` | `SIGN` | Fine? | Source column         | Source rows non-zero        |
| ---- | ---- | --------- | ------ | ----- | --------------------- | --------------------------- |
| `01` | 19   | `G`       | `-`    | yes   | `DR_FINE`             | 20                          |
| `02` | 19   | `A`       | blank  | no    | `CR_AMT + PR_ITM_AMT` | `CR_AMT` 20, `PR_ITM_AMT` 0 |
| `03` | 5    | `G`       | `+`    | yes   | `CR_FINE`             | 6                           |
| `04` | 5    | `A`       | blank  | no    | `DR_AMT + SL_ITM_AMT` | `DR_AMT` 6, `SL_ITM_AMT` 1  |
| `22` | 5    | `A`       | blank  | no    | `PR_CHQ_AMT`          | 5                           |
| `26` | 5    | `A`       | blank  | no    | `PR_KASAR_AMT`        | 5                           |
| `07` | 4    | `G`       | `-`    | yes   | `KSR_FINE_DR`         | 4                           |
| `08` | 2    | `G`       | `+`    | yes   | `KSR_FINE_CR`         | 3                           |
| `13` | 2    | `G`       | `-`    | no    | `PR_BILL_OS < 0`      | `PR_BILL_OS` 13             |

Total 66. ✅ matches the book's row count exactly.

### 2.4 What is dead, and must NOT be built

Verified zero across all 40 `RATE_CUT_DATA` rows:

`INT_FINE` 0 · `SL_CHQ_AMT` 0 · `SL_LBR_AMT` 0 · `SL_TAX_AMT` 0 · `SLV_FINE_CR` 0 · `SLV_FINE_DR` 0 ·
`PR_ITM_AMT` 0

And decisively: **`IT_TYPE` is `'G'` on all 40 rows.** This company never rate-cut silver. So every
silver row family in the routine — types `09`–`12`, `15`–`20`, `33`–`36` — is dead, as are interest fine
(`29`,`30`), tax (`31`,`32`), TDS (`37`,`38`), card (`23`,`24`), labour (`27`,`28`) and the
`IT_TYPE='A'` variants (`39`,`40`).

Reproduce:

```bash
SQL -d Live24 -Q "SET NOCOUNT ON; SELECT '  IT_TYPE='+ISNULL(IT_TYPE,'(null)')+' n='+CAST(count(*) AS varchar) FROM RATE_CUT_DATA GROUP BY IT_TYPE"
# expect exactly: IT_TYPE=G n=40
```

**Do not implement the dead families.** Rationale, in the project's own words from an earlier commit:
"Three more row types resting on unverifiable type codes would add surface without adding confidence."
If a future customer database shows silver rate-cutting, the recipe is in the source and this document
tells you where.

### 2.5 The structural fact that matters most

The **fine rows** (`01`, `03`, `07`, `08`, `13`) carry `DR_AMT = 0` **and** `CR_AMT = 0`. They are pure
metal movement with no money at all. Weight lives in `ITM_FINE`, rate in `ITM_RATE`, direction in `SIGN`.

These are exactly the rows `RP_ROJMEL` reads for its gold/silver fine summaries — it filters
`ITM_FINE <> 0 AND SIGN = '+'/'-' AND IT_TYPE = 'G'/'S'` (`RP_ROJMEL.cs` lines 3552, 3587, 4472, 4507).
That closes a loop which confused an earlier session: the summaries key on `ITM_FINE`, not `ITM_GWT`,
because fine settlement is what they are about.

Consequence for the report: these rows will populate `totals.gold.inFine` / `outFine` in
`apps/api/src/modules/reports/rojmelReport.ts`, which currently always read 0 because no implemented
family writes fine.

### 2.6 `BOOK_DETL` is an account slot table

Not one account per book — a numbered slot per purpose. Confirmed for book 026:

| `SR_NO` | Account | Purpose                 |
| ------- | ------- | ----------------------- |
| 1       | `00003` | sale control            |
| 2       | `00001` | cash / purchase control |
| 3       | `00057` | kasar                   |
| 4       | `00020` | order advance           |
| 5       | `00076` | discount                |
| 6       | `00041` | labour income           |
| 7       | `00050` | cash purchase           |
| 8       | `00079` | scheme bonus            |

**The slots are per-book, not global.** Book 064's map is different from book 026's, so the table above is
_not_ the one to use here. Verified for book 064:

| `SR_NO` | Account | Used by                                                                   |
| ------- | ------- | ------------------------------------------------------------------------- |
| 1       | `00003` | sale-side control                                                         |
| 2       | `00008` | **purchase-side control** — confirmed as `LD_CODE` on real type `13` rows |
| 3       | `00001` | cash                                                                      |
| 4       | `00057` | kasar                                                                     |
| 5       | `00042` | purchase kasar amount                                                     |
| 6       | `00041` | labour income                                                             |
| 7       | `00056` | (unused by the live types)                                                |
| 8       | `00004` | silver sale control — dead here                                           |
| 9       | `00009` | silver purchase control — dead here                                       |
| 10      | `00061` | interest — dead here                                                      |
| 11      | `00077` | (unused)                                                                  |
| 12      | `00098` | kasar fine                                                                |

`Wh_Sales_Rojmel` uses slot **2** for the purchase side (gold), slot **1** for the sale side, slot **12**
for kasar fine, slot **5** for purchase kasar amount. Resolve them with the existing helper — never
hardcode, because the numbers differ per book:

```ts
await resolveBookAccountTx(tx, scope, bookPolicy, 2); // apps/api/src/modules/shared/bookPolicy.ts:97
```

Verify slots for the rate-cut book before relying on them:

```bash
SQL -d Live24 -Q "SET NOCOUNT ON; SELECT '  sr='+CAST(CAST(SR_NO AS int) AS varchar)+' ac='+ISNULL(AC_CODE,'-') FROM BOOK_DETL WHERE CO_CODE='01' AND CO_BOOK='064' ORDER BY SR_NO"
```

---

## 3. Files to change

| Path                                             | Change                                          |
| ------------------------------------------------ | ----------------------------------------------- |
| `web/apps/api/src/modules/shared/rojmel.ts`      | add `buildRateCutRojmel()` + row-type constants |
| `web/apps/api/src/modules/sales/rateCut.ts`      | call it; add `ROJ_MEL_DATA` to the write set    |
| `web/apps/api/test/rojmel.test.ts`               | unit vectors (currently 28 tests)               |
| `web/apps/api/test/rateCutSettlement.db.test.ts` | DB assertions + footprint                       |

### 3.1 What already exists and must be reused

`web/apps/api/src/modules/shared/rojmel.ts` holds the shared builders. Read it in full before adding —
it is ~380 lines and already documents every rule with its evidence. Key exports:

Exact locations (verified 2026-07-31): `ROJMEL_ROW_TYPE` line 42 · `RojmelRowType` 78 · `RojmelMetal` 81 ·
`rojmelMetalFor` 89 · `rojmelLedrKey` 113 · `RojmelRow` 131 · `RojmelContext` 161 · `RojmelSettlement` 185 ·
`RojmelLine` 201 · `buildMoneyRojmel` 274 · `buildSaleRojmel` 321 · `ROJMEL_CASH_ROW_TYPE` 482 ·
`buildCashRojmel` 484 · `buildJournalRojmel` 534. `resolveBookAccountTx` is `bookPolicy.ts:97`.
`rateCut.ts` already lists `ROJ_MEL_DATA` at line 665 and carries the phase-2 TODO at 576.
`rojmel.test.ts` currently has 28 `it()` blocks.

- `RojmelContext` — carries `scope`, `key`, `coBook`, `vchNo`, `vchDate`, `vchType`, `bookName`,
  `partyName`, `partyCode`. **`key` is mandatory and must be the voucher key object**: `postVoucherTx`
  does **not** add key columns, so omitting it writes orphan rows with NULL `CO_BOOK`/`VCH_NO` that no
  report can find.
- `RojmelRow` — the full row shape with every column defaulted the way a blank desktop row is.
- `rojmelLedrKey(scope, coBook, vchNo, rowType, lineNo?)` — builds `LEDR_KEY`.
- `rojmelMetalFor(itemType)` — maps to `G`/`S`/`O`, defaulting to `O` rather than guessing gold.
- `buildSaleRojmel`, `buildMoneyRojmel`, `buildCashRojmel`, `buildJournalRojmel` — the existing families.

### 3.2 `LEDR_KEY` layout — get this exactly right

```
CO_CODE(2) LC_CODE(2) CO_YEAR(9) CO_BOOK(3) VCH_NO(5) TYPE(2) [lineNo right-aligned in 10]
```

Real example, reproduced byte-for-byte by an existing unit test:
`'01002024-20250270000101         1'` (33 chars, 9 spaces before the `1`).

**Why this matters more than it looks:** the primary key of `ROJ_MEL_DATA` is **`LEDR_KEY` alone** — in
both the desktop and the web. Confirmed:

```bash
psql 'postgresql://postgres@127.0.0.1:55433/datacare' -tAc "
SELECT i.relname||' ('||string_agg(a.attname,', ' ORDER BY k.ord)||')'
FROM pg_index x JOIN pg_class i ON i.oid=x.indexrelid JOIN pg_class t ON t.oid=x.indrelid
CROSS JOIN LATERAL unnest(x.indkey) WITH ORDINALITY k(attnum,ord)
JOIN pg_attribute a ON a.attrelid=t.oid AND a.attnum=k.attnum
WHERE t.relname='ROJ_MEL_DATA' AND x.indisprimary GROUP BY i.relname"
# expect: ROJ_MEL_DATA_pkey (tenant_id, LEDR_KEY)
```

The layout is therefore the _only_ thing making a row unique. Two rows on one voucher that share a type
code and omit the line number will collide with **`23505` unique constraint failed**. This has bitten four
times. If a type can appear more than once per voucher, it **must** carry `lineNo`.

For rate cut: types `01`–`04` appear once per voucher in the real data (19 rows across 19 vouchers), so no
line suffix. Verify before implementing:

```bash
SQL -d Live24 -Q "SET NOCOUNT ON; SELECT '  key='''+LEDR_KEY+'''  len='+CAST(LEN(LEDR_KEY) AS varchar) FROM ROJ_MEL_DATA WHERE CO_BOOK='064' ORDER BY LEDR_KEY"
```

**Verified: all 66 rows have `LEN(LEDR_KEY) = 23`.** No rate-cut type carries a line number, so pass no
`lineNo` for any of the nine. (Contrast the sale, where item rows are 33 characters because they do.)

---

## 4. Implementation steps

### Step 1 — confirm the environment and the baseline

```bash
cd /Users/yakshitsavaliya/Desktop/imodule-extracted/web
(cd apps/api && npx vitest run 2>&1 | grep -E "Test Files|Tests ")
# expect: 123 files, 1000 tests, all passing
```

If the baseline is not green, **stop and fix that first**. Never build on a red suite.

### Step 2 — verify the nine types and their key shape

Run the two queries in §2.3 and §3.2. Confirm 66 rows / 9 types and the key lengths. If the numbers differ
from this document, the database has changed and **this plan's scope must be re-derived** before coding.

### Step 3 — add `buildRateCutRojmel` to `rojmel.ts`

Signature to aim for, mirroring the existing builders' style:

```ts
export interface RateCutRojmelLegs {
  /** BOOK_DETL slot 2 — the purchase-side control account. */
  purchaseAc: string;
  /** BOOK_DETL slot 1 — the sale-side control account. */
  saleAc: string;
  /** BOOK_DETL slot 12 — kasar FINE. */
  kasarFineAc: string;
  /** BOOK_DETL slot 5 — purchase kasar AMOUNT. */
  purchaseKasarAc: string;
  metal: Exclude<RojmelMetal, 'A'>;
  fineRate: number;
  drFine: number; // type 01, SIGN '-'
  crFine: number; // type 03, SIGN '+'
  purchaseAmount: number; // type 02  (CR_AMT + PR_ITM_AMT)
  saleAmount: number; // type 04  (DR_AMT + SL_ITM_AMT)
  purchaseChequeAmount: number; // type 22
  purchaseKasarAmount: number; // type 26
  kasarFineDr: number; // type 07, SIGN '-'
  kasarFineCr: number; // type 08, SIGN '+'
  purchaseBillOs: number; // type 13 when negative
  bankAc: string;
  vchDesc?: string;
}
export function buildRateCutRojmel(ctx: RojmelContext, legs: RateCutRojmelLegs): RojmelRow[];
```

Rules, each traceable to §2.3:

- Every row is emitted **only when its amount is non-zero** — mirror the desktop's `AND <col> <> 0`.
- **Fine rows** (`01`,`03`,`07`,`08`): `DR_AMT = 0`, `CR_AMT = 0`, `ITM_FINE = <the fine>`,
  `ITM_RATE = fineRate` (types `01`/`03` only — `07`/`08` set rate 0 per the source), `IT_TYPE = metal`,
  `SIGN` `'-'` for `01`/`07`, `'+'` for `03`/`08`. `AC_CODE = party`, `LD_CODE = the slot account`.
- **Amount rows** (`02`,`04`): `IT_TYPE = 'A'`, `SIGN = ''`, no weight. Note the **reversed**
  `AC_CODE`/`LD_CODE` — the slot account is `AC_CODE` and the party is `LD_CODE`, which is the opposite of
  the fine rows. Type `02` is a **credit**, type `04` a **debit**.
- **Type 13** — RESOLVED, see §7. The two real rows are:

  ```
  AC_CODE 000286  LD_CODE 00008  IT_TYPE G  SIGN -  DR 850.00  CR 0  FINE 2.050  RATE 7300.00
  AC_CODE 000770  LD_CODE 00008  IT_TYPE G  SIGN -  DR 122.00  CR 0  FINE 3.814  RATE 7387.78
  ```

  So it is a **gold fine row that ALSO carries money** — `DR_AMT`, `ITM_FINE` and `ITM_RATE` all populated,
  `LD_CODE` = slot 2 (`00008`). That contradicts the source's line 247, which selects `IT_TYPE 'A'`, no
  sign, no fine, and the amount on the **credit** side. **Follow the data.** It is the only fine row that
  is not money-free, so do not fold it into the same branch as `01`/`03`.

- **Type 22** cheque: `AC_CODE = bankAc`, `LD_CODE = party`, **debit**.
- **Type 26** purchase kasar: `AC_CODE = purchaseKasarAc`, `LD_CODE = party`, **debit**.

### Step 4 — wire `rateCut.ts`

`web/apps/api/src/modules/sales/rateCut.ts` already has:

- `ROJ_MEL_DATA` in its delete/rewrite table list (so edit and delete already reverse it — confirm with
  `grep -n "ROJ_MEL_DATA" apps/api/src/modules/sales/rateCut.ts`);
- a note at **line 576**: `PHASE-2 TODO: project SL_IDTL (stone/diamond sub-lines), ROJ_MEL_DATA (day-book)`.
  Remove that TODO for the Rojmel part when done, leaving the `SL_IDTL` half.

Add to the `writes:` array of the `postVoucherTx` call:

```ts
...(rojmelRows.length ? [{ table: 'ROJ_MEL_DATA', rows: rojmelRows }] : []),
```

Resolve the four slot accounts via `resolveBookAccountTx`, and **only when the corresponding amount is
non-zero** — an unused lookup is a wasted round trip and, worse, throws if the slot is unconfigured.

### Step 5 — tests (see §5) and controls (see §6)

### Step 6 — full verification (see §8)

---

## 5. Tests required

### 5.1 Unit vectors in `apps/api/test/rojmel.test.ts`

Add a `describe('rate cut / wholesale', …)` block. The file already has a `ctx` fixture at the top — reuse
it with `coBook: '064'`. Required assertions:

1. **Fine rows carry no money.** For a voucher with `drFine: 12.5`:
   `expect(fine.DR_AMT).toBe(0)`, `expect(fine.CR_AMT).toBe(0)`, `expect(fine.ITM_FINE).toBe(12.5)`.
   _This is the assertion that matters most — it is what makes the report's fine summaries work._
2. **Direction.** `01` and `07` → `SIGN '-'`; `03` and `08` → `SIGN '+'`.
3. **Amount rows reverse the accounts.** On type `02`, `AC_CODE` is the slot account and `LD_CODE` is the
   party — the opposite of the fine rows. Assert both explicitly.
4. **`02` credits, `04` debits.**
5. **Zero guards.** A voucher with every amount 0 produces `[]`.
6. **Key types.** Assert `String(row.LEDR_KEY).slice(21,23)` equals `'01'`, `'02'`, `'03'`, `'04'`, `'07'`,
   `'08'`, `'13'`, `'22'`, `'26'` respectively.
7. **Metal letter comes from the item, not a default.** `rojmelMetalFor` must be used; an unknown type
   gives `'O'`.
8. **No silver families are emitted** even when silver-ish inputs are passed — there is no code path for
   them, and the test documents that as intentional.

### 5.2 Database assertions in `apps/api/test/rateCutSettlement.db.test.ts`

That file exists and already has a cleanup list including `ROJ_MEL_DATA` (added in an earlier sweep —
confirm with `grep -n ROJ_MEL_DATA apps/api/test/rateCutSettlement.db.test.ts`).

1. **The rows persist.** Post a rate cut, query `ROJ_MEL_DATA` for the voucher, assert row count > 0.
2. **Fine reaches the report.** Call `rojmel(runtime, scope)` from
   `apps/api/src/modules/reports/rojmelReport.ts` and assert `totals.gold.outFine` is non-zero and equals
   the sum of the `SIGN '-'` fine rows. **This is the end-to-end proof** — it is the first family to make
   the fine summaries non-zero.
3. **Footprint.** Add `ROJ_MEL_DATA` to the pinned exact-set footprint for the rate-cut voucher. Use
   `footprintOf` from `apps/api/test/support/footprint.ts`. The set must be asserted with `toEqual`, never
   `toContain` — a subset assertion cannot see an unexpected extra write, which is how a duplicate posting
   appears. (This exact weakness was found in the sales-return test and fixed.)
4. **Edit does not duplicate.** Create, then edit the voucher, then assert the Rojmel row count is
   unchanged and no `23505` occurred. This proves the delete side works.

---

## 6. Controls that must be proven failing

**A gate is not trusted until it has been demonstrated failing.** For each, break the code, run the named
test, confirm the expected message, then restore. Restore by `cp` from a backup taken first — do not
hand-edit back.

```bash
R=apps/api/src/modules/shared/rojmel.ts; cp $R /tmp/rc.bak
# ... break it ...
(cd apps/api && npx vitest run test/rojmel.test.ts 2>&1 | grep -E "→|Tests ")
cp /tmp/rc.bak $R
```

| #   | Break                                                              | Expected failure                                                      |
| --- | ------------------------------------------------------------------ | --------------------------------------------------------------------- |
| 1   | Put the amount into `DR_AMT` on a fine row                         | fine-rows-carry-no-money fails; report `outFine` assertion also fails |
| 2   | Invert `SIGN` on types `01`/`03`                                   | direction test fails; report's in/out buckets swap                    |
| 3   | Use the same `AC_CODE`/`LD_CODE` order on amount rows as fine rows | account-reversal test fails                                           |
| 4   | Remove the `if (!amount) continue` guards                          | zero-guard test fails with a row count mismatch                       |
| 5   | Drop the `ROJ_MEL_DATA` write from `rateCut.ts`                    | footprint test fails **naming the table**                             |
| 6   | Reuse one type code for two row kinds                              | either the type-code test fails or the DB raises `23505`              |

Control 6 is worth running even though it looks redundant: the schema's single-column primary key means
the database itself is a gate, and confirming that is cheap.

---

## 7. The source-vs-data divergence, resolved

**Type `13` disagrees between source and data, and the data wins.**

- `Ac_Rojmel.cs` line 247 selects `IT_TYPE 'A'`, no `SIGN`, no fine, amount on the **credit** side.
- The two real rows carry `IT_TYPE 'G'`, `SIGN '-'`, `DR_AMT` **and** `ITM_FINE` **and** `ITM_RATE`.

This is the same class of discrepancy already established elsewhere: **the decompiled source is a later
version than the code that wrote `Live24`** — proven independently by sale item rows being type `'02'` in
the source and `'01'` in the data.

**Resolution rule for this project: follow the DATA when the two disagree**, because the data is what a
migrated customer database will contain and what the report must read. Record the divergence in a comment
naming both, as `rojmel.ts` already does for the sale's type codes. Do **not** silently pick one.

Inspect the two rows before deciding:

```bash
SQL -d Live24 -Q "SET NOCOUNT ON; SELECT '  ac='+ISNULL(AC_CODE,'-')+' ld='+ISNULL(LD_CODE,'-')+' it='+ISNULL(IT_TYPE,'-')+ISNULL(SIGN,'')+' dr='+CAST(CAST(ISNULL(DR_AMT,0) AS decimal(14,2)) AS varchar)+' cr='+CAST(CAST(ISNULL(CR_AMT,0) AS decimal(14,2)) AS varchar)+' fine='+CAST(CAST(ISNULL(ITM_FINE,0) AS decimal(12,3)) AS varchar) FROM ROJ_MEL_DATA WHERE CO_BOOK='064' AND SUBSTRING(LEDR_KEY,22,2)='13'"
```

---

## 8. Verification sequence — run all of it before committing

```bash
cd /Users/yakshitsavaliya/Desktop/imodule-extracted/web
export PATH=/opt/homebrew/opt/postgresql@16/bin:$PATH
export DATABASE_URL='postgresql://app_user:imgValidationSecret2026x@127.0.0.1:55433/datacare?schema=public'
export MIGRATE_DATABASE_URL='postgresql://postgres@127.0.0.1:55433/datacare?schema=public'
export RUN_DB_INTEGRITY_TESTS=1 RUN_DB_SECURITY_TESTS=1

npx prettier --write .
(cd apps/api && npx tsc -p tsconfig.json --noEmit)      # must be silent
(cd apps/web && npx tsc -p tsconfig.json --noEmit)      # must be silent
(cd apps/api && npx vitest run)                         # 1000 + new tests
(cd apps/web && npx vitest run)                         # 18
pnpm lint                                               # 0 policy violations
npx prettier --check .
pkill -f "next-server"; pnpm build --force              # 7/7 tasks
pnpm settings:parity                                    # 128/128
pnpm schema:readiness
pnpm fresh:provision                                    # 172 tables, 1 allowed drift
node scripts/report-baselines.mjs                       # 254 unchanged — never pass --write
node scripts/check-g5-parity.mjs                        # G5_RED expected, that is correct
(cd apps/web && node test/browser.smoke.mjs)            # AFTER build, exit 0
```

Notes that have cost time before:

- `pkill -f "next-server"` before `build --force`. Stale Next servers hold the build directory.
- Piping to `head` makes `$?` report **head's** exit status. Check exit codes without a pipe.
- `timeout` does not exist on macOS.
- Test files are **not** typechecked by `tsc -p tsconfig.json` (it includes `src` only). There is a
  `apps/api/tsconfig.test.json` that does include them, but it surfaces 112 pre-existing errors and is
  **not** a gate. So a type error in a new test will not be caught — read new test code carefully.

---

## 9. Invariants that must not be broken

Each of these has caused a real failure in this project.

1. **`ROJ_MEL_DATA`'s primary key is `LEDR_KEY` alone.** Any table added to a write set must also be in
   every DB test cleanup list, or a reused voucher number in a later test collides. This bit **four times**
   before a sweep added it to 20 test files.
2. **`insertRowTx(tx, TABLE, tenantId, row)`** — tenant is a separate argument, not a row field.
3. **`postVoucherTx` does not add voucher key columns.** Spread `...key` yourself.
4. **Every statement in a DB test must run inside `withTenant`.** Outside it, RLS makes reads return 0 and
   `DELETE` a silent no-op.
5. **`tenant_id` is `varchar(24)`.** DB tests use short kebab tenants, never UUIDs.
6. **Text columns must be sliced to real widths**, including in fixtures. `ITEM_MAST.IT_CODE` is
   `varchar(5)` — `'SILVER'` fails with `22001`. Check widths in `information_schema` rather than guessing.
7. **Route policy is static analysis of literal `app.<verb>('/path'` strings.** No new route is needed for
   this work, but if one is added it needs a `route(...)` entry in `routePolicy.ts`, a form in
   `formCatalog.ts`, and the pinned count in `routePolicy.test.ts` bumped in **both** assertions.
8. **Never weaken a test to make it pass.** If an assertion fails, the code is wrong until proven
   otherwise. One earlier fix was correct precisely because the _test's_ invariant was wrong — but that was
   established by reading the seed, not by relaxing the assertion.
9. **A control on a workspace package needs a rebuild.** `packages/core` is built separately; vitest
   transpiles `apps/api/src` on the fly but not that. Run `pnpm --filter @datacare/core build` if touching
   it. A control once "passed" twice against a deliberately broken build.

---

## 10. Definition of done

- [ ] `buildRateCutRojmel` implemented for the **9 live types only**, each with a comment citing its row
      count and source column from §2.3.
- [ ] `rateCut.ts` writes `ROJ_MEL_DATA`; the phase-2 TODO's Rojmel clause removed.
- [ ] Type `13`'s `IT_TYPE` divergence resolved per §7, with both readings named in a comment.
- [ ] Unit vectors added, all 8 assertions from §5.1.
- [ ] DB assertions added, all 4 from §5.2, including the footprint pinned as an **exact set**.
- [ ] All 6 controls in §6 demonstrated failing, then restored.
- [ ] `totals.gold.outFine` proven non-zero end to end — the first family to make it so.
- [ ] Full verification sequence in §8 green, including browser smoke.
- [ ] Commit message states: what was implemented, what was deliberately skipped and why (the dead
      families), the control failure messages, and the row counts backing each decision.
- [ ] `docs/GAP-ANALYSIS-AND-PLAN.md` coverage table updated — book 064 and 034 move to "written", and the
      ~88% figure recalculated.

## 11. After this: the remaining queue

Ranked by counted Rojmel rows, from `docs/GAP-ANALYSIS-AND-PLAN.md`:

| Book                      | Rows | Routine                      | First step                              |
| ------------------------- | ---- | ---------------------------- | --------------------------------------- |
| 020 Sales Order           | 55   | `Order_Rojmel` (line 9)      | count non-zero columns in `SL_ORD_DATA` |
| 076 Member Advance Adjust | 37   | `Schm_Adj_RojMel` (line 458) | count in `AD_ADJ` — 26 rows exist       |
| 052 Karigar Receipt       | 28   | `Kr_Rec_Rojmel` (line 364)   | also closes the `KR_DETL` write gap     |
| 078 Fine Jv               | 28   | in `finance/fineJv.ts`       | identify the routine first              |
| 043 Gold URD Purchase Old | 27   | `Purc_Rojmel` variant        | check `MAIN_BOOK`                       |

**Always run the column-count step first.** It removed `Order_Adj_Rojmel` from the list entirely and cut
this piece of work from 40 row types to 9.

Dead for this customer and not worth building until a database shows otherwise: all six dhrn/loan
routines, both repair routines, `Emp_Jv_Rojmel`, `Card_Adj_RojMel`, `VpAdj_Rojmel`, `Jdt_Rec_Rojmel`,
`Loct_Amt_Rojmel`, `Stk_InOut_Rojmel`, `Fine_CUT_Rojmel`. Three more reference tables absent from the
schema entirely: `Dg_Gold_Booking_Rojmel`, `Fan_Sale_Rojmel`, `Fan_Purc_Rojmel`.
