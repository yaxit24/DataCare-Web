# Rojmel work: engineering handbook

**Purpose.** This is the one document to read when starting work on the Rojmel with **no memory of any
previous session**. It carries the method, the environment, the invariants, the traps and the queue.
Per-piece plans live beside it and assume you have read this.

**Last verified against the tree:** 2026-07-31. Every number below has the command that produces it, so a
stale figure is detectable rather than misleading.

---

## 1. Orientation in sixty seconds

DataCareNext is an offline Windows Forms + Crystal Reports + SQL Server jewellery ERP being converted to a
web application with **behavioural parity**. The desktop is authoritative; the stack changes, the behaviour
must not.

The **Rojmel** is the jeweller's day book — table `ROJ_MEL_DATA`, bound to `F11`. It is a _second projection_
of every voucher that shows **metal movement beside money**, which the general ledger `AC_DATA` cannot,
because that table has no weight columns. The web wrote none of it until this workstream.

| Where                                              | What                                                          |
| -------------------------------------------------- | ------------------------------------------------------------- |
| `web/apps/api/src/modules/shared/rojmel.ts`        | all row builders, ~800 lines, every rule carries its evidence |
| `web/apps/api/src/modules/reports/rojmelReport.ts` | the report behind `F11` → `GET /reports/rojmel`               |
| `unified/src/csharp/DataCareNext/Ac_Rojmel.cs`     | the desktop's posting routine, 1115 lines, ~44 named routines |
| `unified/src/csharp/DataCareNext/RP_ROJMEL.cs`     | the desktop's report, 5856 lines                              |
| `unified/database/backups/Next24.mdf`              | the **real customer database**, restored locally as `Live24`  |
| `web/docs/GAP-ANALYSIS-AND-PLAN.md`                | running record of findings, coverage and corrections          |

### Current state

```bash
cd /Users/yakshitsavaliya/Desktop/imodule-extracted/web
(cd apps/api && npx vitest run 2>&1 | grep -E "Test Files|Tests ")   # 123 files / 1015 tests
```

Five builders written — `buildSaleRojmel`, `buildMoneyRojmel`, `buildCashRojmel`, `buildJournalRojmel`,
`buildRateCutRojmel` — called from seven modules: `sales/sales.ts`, `sales/salesReturn.ts`,
`sales/rateCut.ts`, `purchase/purchase.ts`, `finance/finance.ts`, `finance/journal.ts`,
`membership/scheme.ts`.

**Coverage: 3085 of the 3179 real Rojmel rows — 97%.** Counted by grouping the real rows by `MAIN_BOOK`,
which is the right granularity: several book codes share one family, so counting by book code
double-counts effort. Reproduce with:

```bash
SQL -d Live24 -Q "SET NOCOUNT ON;
SELECT '  '+RIGHT(CAST(count(*)+100000 AS varchar),5)+'  '+ISNULL(MAX(b.MAIN_BOOK),'(none)')
 FROM ROJ_MEL_DATA r LEFT JOIN BOOK_DATA b ON b.CO_BOOK=r.CO_BOOK AND b.CO_CODE=r.CO_CODE
 GROUP BY b.MAIN_BOOK ORDER BY count(*) DESC"
```

| `MAIN_BOOK`                             | Rows   | Web             |
| --------------------------------------- | ------ | --------------- |
| MEMB ENTRY                              | 1635   | written         |
| SALES                                   | 556    | written         |
| CASH PAY                                | 185    | written         |
| BANK PAY                                | 130    | written         |
| PURCHASE                                | 115    | written         |
| CASH REC                                | 106    | written         |
| BANK REC                                | 97     | written         |
| CONTRA                                  | 74     | written         |
| RATE CUT                                | 66     | written         |
| SALES ORDER                             | 55     | **written**     |
| MEMB ADJUST                             | 37     | **written**     |
| **WH SALES**                            | **32** | partly          |
| **KARIGAR RECEIPT**                     | **28** | **not written** |
| FINE JV                                 | 28     | **written**     |
| **(no `BOOK_DATA` row — book 043)**     | **27** | **not written** |
| OTH EXP / OTH INC                       | 2 + 2  | partly          |
| SALES RETURNE                           | 1      | written         |
| KARIGAR ISSUE / ORDER CANCEL / BILL REC | 1 each | not written     |

**90 rows remain**: karigar receipt 28 (ready), wholesale 32 (blocked - no web form), URD 27 (not a gap - retired book), plus 3 stragglers. Note that an earlier figure of "88%" in
`GAP-ANALYSIS-AND-PLAN.md` was computed from a book-code list rather than measured this way; this table
supersedes it.

---

## 2. The method, in the order that works

Four sessions of mistakes produced this order. Each step exists because skipping it caused a specific,
documented error.

### Step 1 — Count the OUTPUT

```bash
SQL -d Live24 -Q "SET NOCOUNT ON;
SELECT '  type='+SUBSTRING(LEDR_KEY,22,2)+' n='+CAST(count(*) AS varchar)
 +'  it='+MAX(ISNULL(IT_TYPE,'-'))+' sign='+MAX(CASE WHEN ISNULL(SIGN,'')='' THEN '_' ELSE SIGN END)
 +'  withDr='+CAST(SUM(CASE WHEN ISNULL(DR_AMT,0)<>0 THEN 1 ELSE 0 END) AS varchar)
 +'  withCr='+CAST(SUM(CASE WHEN ISNULL(CR_AMT,0)<>0 THEN 1 ELSE 0 END) AS varchar)
 +'  withFine='+CAST(SUM(CASE WHEN ISNULL(ITM_FINE,0)<>0 THEN 1 ELSE 0 END) AS varchar)
 +'  keyLen='+CAST(MAX(LEN(LEDR_KEY)) AS varchar)
 FROM ROJ_MEL_DATA WHERE CO_BOOK='<BOOK>' GROUP BY SUBSTRING(LEDR_KEY,22,2) ORDER BY count(*) DESC"
```

This is ground truth with no inference in it. The type counts must sum to the book's total.

### Step 2 — Count the SOURCE COLUMNS

For each candidate row type, check whether the column its `INSERT` is guarded on is non-zero in the source
table. **A type whose guard column is empty never fires.**

### Step 3 — Read the source for STRUCTURE only

Which tables, which guards, which `BOOK_DETL` slot, whether a line number is in the key.

### Step 4 — Take DIRECTIONS and ACCOUNTS from the DATA

Never from the source, unless you have checked they agree for that specific type.

### Why each step exists

| Skipping | What happened                                                                                                                                                                          |
| -------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Step 1   | Ranked `Order_Adj_Rojmel` top because `SL_ORD_ADJ` has 110 rows. `PAID_AMT` is non-zero on **1**. It contributes ~1 row a year.                                                        |
| Step 2   | Planned 40 rate-cut row types. Only **9** ever fired.                                                                                                                                  |
| Step 3   | Nearly implemented `Fine_CUT_Rojmel` — it reads `CUT_DATA`/`CUT_DETL`, both **0 rows**, dead code for this customer. A routine named after a feature is not evidence it implements it. |
| Step 4   | Wrote a plan from the source: **wrong on 5 of 9 types** — debit/credit reversed on four, three families wrongly called money-free.                                                     |

### The two halves of the lesson

- **Sampling data cannot enumerate code paths that never fired.** Settlement rows are guarded by
  `AND <col> <> 0`, so a plain voucher emits none of them. Absence in output looks like absence in code.
- **Reading source cannot tell you which paths are live.** A third of `Ac_Rojmel.cs` is dead for this
  customer.

**Source for what EXISTS, data for what RUNS.** Neither alone is sufficient.

### On the version divergence

`Ac_Rojmel.cs` is a **later version** than the code that wrote `Live24` — proven independently by sale item
rows being type `'02'` in the source and `'01'` in the data.

**But it is not uniformly wrong.** For `Order_Rojmel` the source and data agree on all four live types; for
`Wh_Sales_Rojmel` they disagree on five of nine. So the rule is not "distrust the source" but **verify per
type, and let the data settle disagreements** — the data is what a migrated customer database will contain.

---

## 3. Environment

### 3.1 Postgres — the web's database

```bash
export PATH=/opt/homebrew/opt/postgresql@16/bin:$PATH
export DATABASE_URL='postgresql://app_user:imgValidationSecret2026x@127.0.0.1:55433/datacare?schema=public'
export MIGRATE_DATABASE_URL='postgresql://postgres@127.0.0.1:55433/datacare?schema=public'
export RUN_DB_INTEGRITY_TESTS=1 RUN_DB_SECURITY_TESTS=1
pg_isready -h 127.0.0.1 -p 55433
```

Port **55433** only, never 5432. Do not pass `?schema=public` to `psql`.

### 3.2 SQL Server — the real desktop database

```bash
cd /Users/yakshitsavaliya/Desktop/imodule-extracted
docker ps --format '{{.Names}}' | grep -q dc-mssql || docker start dc-mssql
sleep 25   # amd64 emulation on arm64 is slow

SQL() { docker exec dc-mssql /opt/mssql-tools18/bin/sqlcmd \
          -S localhost -U sa -P 'ParityProbe#2026x' -C -W -s'|' -h -1 "$@"; }
SQL -d Live24 -Q "SET NOCOUNT ON; SELECT 'rojmel='+CAST(count(*) AS varchar) FROM ROJ_MEL_DATA"
# expect: rojmel=3179
```

To recreate from scratch:

```bash
docker run -d --name dc-mssql --platform linux/amd64 \
  -e ACCEPT_EULA=Y -e 'MSSQL_SA_PASSWORD=ParityProbe#2026x' -e MSSQL_PID=Developer \
  -p 11433:1433 -v "$(pwd)/unified/database/backups:/backups:ro" \
  mcr.microsoft.com/mssql/server:2022-latest
```

Attaching a loose `.mdf` needs `docker cp` then, **as root**, `chmod 660 && chown mssql:mssql`, else
`Msg 3415`. Then `CREATE DATABASE [Live24] ON (FILENAME='…mdf'),(FILENAME='…ldf') FOR ATTACH`.

**The `.BAK` files restore to SEED databases with no vouchers.** Only the loose `.mdf` carries transactions.
Restoring a backup and stopping there produces an empty comparison that reads as agreement.

### 3.3 Handling the real data

918 accounts, real customer names. **Never** commit it, echo names into output, commit messages or fixtures.
Extract counts and structure only. `unified/` and `project-memory/parity/bundles/` are git-ignored — confirm
any new artifact path with `git check-ignore` before writing.

---

## 4. `ROJ_MEL_DATA` essentials

### 4.1 `LEDR_KEY` is the entire primary key

```
CO_CODE(2) LC_CODE(2) CO_YEAR(9) CO_BOOK(3) VCH_NO(5) TYPE(2) [lineNo right-aligned in 10]
```

Real 33-character example, reproduced byte-for-byte by an existing unit test:
`'01002024-20250270000101         1'` — nine spaces before the `1`.

```bash
psql 'postgresql://postgres@127.0.0.1:55433/datacare' -tAc "
SELECT i.relname||' ('||string_agg(a.attname,', ' ORDER BY k.ord)||')'
FROM pg_index x JOIN pg_class i ON i.oid=x.indexrelid JOIN pg_class t ON t.oid=x.indrelid
CROSS JOIN LATERAL unnest(x.indkey) WITH ORDINALITY k(attnum,ord)
JOIN pg_attribute a ON a.attrelid=t.oid AND a.attnum=k.attnum
WHERE t.relname='ROJ_MEL_DATA' AND x.indisprimary GROUP BY i.relname"
# ROJ_MEL_DATA_pkey (tenant_id, LEDR_KEY)
```

**Consequences.** A row type that can appear more than once per voucher **must** carry a line number, or two
rows collide with `23505`. Any table added to a write set must join **every** DB test cleanup list, or a
reused voucher number in a later test collides. **This has bitten four times**, until a sweep added
`ROJ_MEL_DATA` to 20 test files.

### 4.2 Column semantics, all measured

| Column     | Meaning                                                                                                     |
| ---------- | ----------------------------------------------------------------------------------------------------------- |
| `IT_TYPE`  | the **metal**: `G` gold, `S` silver, `O` other, `A` a money row — _not_ a stock/amount flag                 |
| `SIGN`     | `-` metal out, `+` metal in, blank on `A` rows                                                              |
| `LD_CODE`  | the **contra** account — the other side of this row's amount                                                |
| `AC_NAME`  | denormalised to the **party's** name on every row, including rows whose `AC_CODE` is a tax or sales account |
| `ITM_FINE` | fine weight. **`RP_ROJMEL`'s gold and silver summaries filter on this, not `ITM_GWT`**                      |

`RP_ROJMEL.cs` lines 3552, 3587, 4472, 4507 read
`ITM_FINE <> 0 AND SIGN = '+'/'-' AND IT_TYPE = 'G'/'S'`. Until `buildRateCutRojmel`, every family left
`ITM_FINE` at zero, so those summaries could only report nothing.

### 4.3 `BOOK_DETL` is a per-book account SLOT table

Not one account per book — a numbered slot per purpose. **The numbering differs per book**, which has
already caused one plan error.

| Slot | Book 026         | Book 064               | Book 020 |
| ---- | ---------------- | ---------------------- | -------- |
| 1    | `00003` sale     | `00003` sale           | `00001`  |
| 2    | `00001` cash     | `00008` purchase       | `00020`  |
| 3    | `00057` kasar    | `00001`                | —        |
| 5    | `00076` discount | `00042` purchase kasar | —        |
| 12   | —                | `00098` kasar fine     | —        |

Always resolve, never hardcode:

```ts
await resolveBookAccountTx(tx, scope, bookPolicy, slotNo); // shared/bookPolicy.ts:97
```

### 4.4 Two account-order conventions coexist

- **Fine / metal rows** name the **party** in `AC_CODE`, the slot account in `LD_CODE`.
- **Amount rows** are the reverse — slot account in `AC_CODE`, party in `LD_CODE`.

Getting this backwards misfiles every row. A control proves it: swapping them fails
`expected '000939' to be '00008'`.

### 4.5 Two known desktop oddities, reproduced deliberately

**Fine double-counted on an overpaid purchase.** When `PR_BILL_OS` is negative, rate cut writes the fine
twice — types `01` and `13`. Verified on both occurrences: voucher 00004 has `PR_BILL_OS` −850.00 with
`DR_FINE` 2.050 on both rows; 00020 has −122.00 and 3.814. This inflates the day book's fine total and is
very likely a desktop defect. **Reproduced on purpose** — parity with the desktop's report output is the
requirement, and correcting it would make the two systems disagree on a figure the shop reconciles against.
A test pins it. **Changing it needs an owner decision.**

**Round-off keeps its sign in `DR_AMT`.** The desktop writes the _negative_ value into `DR_AMT` rather than
its absolute value. Preserved rather than tidied, because a report summing `DR_AMT` depends on it.

### 4.6 Money rows that carry weight

Old metal taken in part-exchange has `IT_TYPE 'A'` **and** populated `ITM_PCS`/`ITM_GWT`/`ITM_NWT`/
`ITM_TOUCH`/`ITM_FINE`. That is deliberate: the day book shows metal taken in exchange **without counting it
as a metal sale**. Since the report's metal buckets key on `IT_TYPE`, giving such a row `'G'` would
double-count the shop's gold movement. A control proves it: `expected 'G' to be 'A'`.

---

## 5. Invariants

Every one has caused a real failure here.

1. **`ROJ_MEL_DATA`'s PK is `LEDR_KEY` alone.** See §4.1.
2. **`insertRowTx(tx, TABLE, tenantId, row)`** — tenant is a separate argument, not a row field.
3. **`postVoucherTx` does not add voucher key columns.** Spread `...key` yourself or write orphans.
4. **Every statement in a DB test runs inside `withTenant`.** Outside it, reads return 0 and `DELETE` is a
   silent no-op.
5. **`tenant_id` is `varchar(24)`** — short kebab tenants, never UUIDs.
6. **Slice text to real widths, fixtures included.** `ITEM_MAST.IT_CODE` is `varchar(5)`; `'SILVER'` fails
   `22001`. Read widths from `information_schema`.
7. **Never weaken a test to make it pass.** Fix the root cause.
8. **A control on `packages/core` needs `pnpm --filter @datacare/core build`.** Vitest transpiles
   `apps/api/src` on the fly but not that package. A control once "passed" twice against a broken build.
9. **Assert that string replacements landed.** Prettier reflows files, so an exact-match `replace()` can
   silently no-op and report success. This produced a stale doc claiming an implemented feature was missing.
10. **Route policy is static analysis of literal `app.<verb>('/path'` strings.** A new route needs a
    `route(...)` entry in `routePolicy.ts`, a form in `formCatalog.ts`'s `FORM_CATALOG` array, and the
    pinned count bumped in **both** assertions in `routePolicy.test.ts`. 140 `route()` entries currently.
11. **Footprints are asserted as an exact SET with `toEqual`, never `toContain`.** A subset assertion cannot
    see an unexpected **extra** write, and an extra write is how a duplicate ledger posting appears. This
    weakness was found in the sales-return test and fixed.

---

## 6. Traps that produce silent wrong answers

These are the dangerous ones — they do not throw, they return something plausible.

### 6.1 RLS returns zero rows, not an error

`app_user` is subject to row-level security. Reads outside a tenant context return **zero rows with no
error**. Hit twice in one hour on the rate-cut work.

**Symptom that exposed it:** a helper reported 0 rows while the report — which scopes internally — correctly
saw a fine of 10. The contradiction is what gave it away.

**Rule: when a count is unexpectedly zero, suspect the tenant context before suspecting the code.**

### 6.2 `footprintOf` swallows the error

`apps/api/test/support/footprint.ts:49` reads directly and has `.catch(() => [{ n: 0 }])` at line 63. Handed
an RLS-bound client it turns every blocked read into a count of zero, so the footprint comes back **empty
rather than failing**. Pass a tenant-scoped transaction:

```ts
const touched = await withTenant(prisma, tenantId, (tx: any) =>
  footprintOf(tx, tables, tenantId, vchNo),
);
```

A helper that swallows an error into a plausible-looking zero is worse than one that throws.

### 6.3 Test files are not typechecked

`tsc -p apps/api/tsconfig.json` includes `src` only. `apps/api/tsconfig.test.json` exists and does include
tests, but surfaces **112 pre-existing errors** and is **not** a gate. A type error in a new test will not be
caught — read new test code carefully.

### 6.4 Shell and tooling

- `pkill -f "next-server"` before `pnpm build --force`; stale servers hold the build directory.
- Piping to `head` makes `$?` report **head's** status. Check exit codes without a pipe.
- `timeout` does not exist on macOS.
- A backtick inside a shell `-c` string breaks bash and the control "passes" against unmodified code. Use a
  heredoc.

---

## 7. Known flakiness — read before believing a failure

`apps/api/vitest.config.ts` bounds concurrency to `maxThreads: 4` **deliberately**. Its comment records the
reason: roughly half the ~123 test files construct their own `PrismaClient` against the same Postgres whose
`max_connections` is 100, and unbounded parallelism produced "intermittent failures that moved between files
run to run — `settingsBehavior.db` on one pass, `salesFamilyLifecycle.db` on the next — which is the
signature of resource contention rather than a logic error."

**This still occurs occasionally at 4 threads** when other processes hold connections. On 2026-07-31 a run
failed 9 tests across 5 files, then passed 1015/1015 on three consecutive re-runs.

**How to tell contention from a real defect:**

| Contention                            | Real defect               |
| ------------------------------------- | ------------------------- |
| failing files move between runs       | same test fails every run |
| several unrelated files fail at once  | one file, one assertion   |
| passes on re-run with nothing changed | fails on re-run           |

**Before concluding contention:** kill any running API server (`pkill -f "apps/api/dist/server.js"`), close
stray `psql` sessions, then re-run. Check pressure with
`psql … -tAc "SELECT count(*) FROM pg_stat_activity"`.

**Do not commit while the suite is red**, even if you believe it is contention. I did that once — the commit
was docs-only so nothing broken shipped, but the discipline matters more than the outcome. Re-run first,
and if it fails again, investigate. **Do not overwrite the failure log before reading it**, which is how the
identity of those nine tests was lost.

The real fix, noted in the config, is per-worker databases so DB tests stop sharing a serialisation point.

---

## 8. Verification sequence

Run all of it before committing.

```bash
cd /Users/yakshitsavaliya/Desktop/imodule-extracted/web
export PATH=/opt/homebrew/opt/postgresql@16/bin:$PATH
export DATABASE_URL='postgresql://app_user:imgValidationSecret2026x@127.0.0.1:55433/datacare?schema=public'
export MIGRATE_DATABASE_URL='postgresql://postgres@127.0.0.1:55433/datacare?schema=public'
export RUN_DB_INTEGRITY_TESTS=1 RUN_DB_SECURITY_TESTS=1
pkill -f "apps/api/dist/server.js"      # free connections first — see §7

npx prettier --write .
(cd apps/api && npx tsc -p tsconfig.json --noEmit)      # silent
(cd apps/web && npx tsc -p tsconfig.json --noEmit)      # silent
(cd apps/api && npx vitest run)                         # 1015 at time of writing
(cd apps/web && npx vitest run)                         # 18
pnpm lint                                               # 0 policy violations
npx prettier --check .
pkill -f "next-server"; pnpm build --force              # 7/7 tasks
pnpm settings:parity                                    # 128/128
pnpm schema:readiness
pnpm fresh:provision                                    # 172 tables, 1 allowed drift
node scripts/report-baselines.mjs                       # 254 unchanged — never --write
node scripts/check-g5-parity.mjs                        # G5_RED expected and CORRECT
(cd apps/web && node test/browser.smoke.mjs)            # AFTER build, exit 0
```

`g5:parity` is **red by design**. It goes green only when a genuine desktop-vs-web voucher comparison has
been captured and committed. Red is the honest state; do not "fix" it.

---

## 9. Controls: the non-negotiable part

**A gate is not trusted until it has been demonstrated failing.** For every assertion added, break the code,
run the test, confirm the message names the problem, then restore.

```bash
R=apps/api/src/modules/shared/rojmel.ts; cp $R /tmp/ctl.bak
# ...break one thing...
(cd apps/api && npx vitest run test/rojmel.test.ts 2>&1 | grep -E "→|Tests ")
cp /tmp/ctl.bak $R     # restore by copy, never by hand-editing back
```

Controls that have earned their place, with the message each produces:

| Broken                             | Message                                                               |
| ---------------------------------- | --------------------------------------------------------------------- |
| money on a money-free fine row     | `expected 0.11 to be +0`                                              |
| inverted `SIGN`                    | `expected '+' to be '-'` **and** the report's metal bucket empties    |
| no account-order flip              | `expected '000939' to be '00008'`                                     |
| removed `<> 0` guard               | `expected 4 to be 3`                                                  |
| dropped the write                  | footprint fails **naming the table**, and the report bucket goes to 0 |
| reused a type code                 | **`23505`** — the schema itself is the gate                           |
| `Math.abs` on a negative round-off | `expected 0.35 to be -0.35`                                           |

A control that fails for the **wrong reason** — a syntax error, say — is invalid. Reject and redo minimally.
A control that **passes** when inverted means the test does not cover that case.

---

## 10. The queue

Ranked by **counted real Rojmel rows**, which is the only ranking that has survived.

| Book                      | Rows | Routine           | `Ac_Rojmel.cs` line | Status                                                                    |
| ------------------------- | ---- | ----------------- | ------------------- | ------------------------------------------------------------------------- |
| 020 Sales Order           | 55   | `Order_Rojmel`    | 9                   | **written** — 4 live types of 8                                           |
| 076 Member Advance Adjust | 37   | `Schm_Adj_RojMel` | 458                 | **written** — 3 live types of 8                                           |
| 034 Wh Sales              | 32   | `Wh_Sales_Rojmel` | 221                 | **blocked** — the web has no wholesale-SALE path at all                   |
| 052 Karigar Receipt       | 28   | `Kr_Rec_Rojmel`   | 364                 | Rojmel only — the `KR_DETL` write gap was a false positive, now retracted |
| 078 Fine Jv               | 28   | —                 | —                   | identify the routine first                                                |
| 043 Gold URD Purchase Old | 27   | —                 | —                   | **not a gap** — retired book, `CUR_USE='N'`                               |

### Dead for this customer — do not build without evidence

All six dhrn/loan routines (`DHRN_*` tables at 0 rows), both repair routines (`REP_DATA` 0),
`Emp_Jv_Rojmel`, `Card_Adj_RojMel`, `VpAdj_Rojmel`, `Jdt_Rec_Rojmel`, `Loct_Amt_Rojmel`,
`Stk_InOut_Rojmel`, `Fine_CUT_Rojmel`. Three more reference tables absent from the schema entirely:
`Dg_Gold_Booking_Rojmel`, `Fan_Sale_Rojmel`, `Fan_Purc_Rojmel`.

**Standing caveat.** This ranking rests on **one company, one fiscal year**. A wholesale-heavy shop or a
pawnbroker would invert it — the dhrn block would be the priority and schemes near-dead. The live/dead
classification is a fact about this database; the priority is an inference from a single sample. A second
customer database is the cheapest way to test it.

### An uncomfortable pattern worth remembering

The web already writes the Rojmel from six paths this customer has **never used** — location amount, VP
adjustment and the four repair paths are all in the dead list — while it did not write it for order adjust,
sales order, scheme adjust or karigar, which the customer does use. Those six were implemented because a
sibling feature needed them, not because anything indicated they mattered. **Effort followed the code rather
than the business.** Consult §10 before the next commit, not after.

---

## 11. Writing the next per-piece plan

The two existing plans are the template. A good one contains:

1. **Scope, measured** — the output-count table, the source-column counts, and an explicit list of what is
   dead and will **not** be built.
2. **Whether source and data agree**, checked type by type and stated either way.
3. **Any anomaly, flagged and left alone.** Example: `SCHM_AMT` is non-zero on 7 of 76 sales orders yet
   there are **zero** type-05 rows. That is unexplained, so type 05 is not implemented — adding rows the
   desktop does not have is a parity failure in the opposite direction from a missing row, and much harder
   to notice.
4. **File references with line numbers, verified against the tree.** Both times this was checked it caught
   something: five wrong directions, then an export table stale by up to 220 lines.
5. **Tests enumerated as assertions**, not as prose.
6. **Controls enumerated with the message each should produce.**
7. **A definition-of-done checklist**, including updating the coverage table **and asserting the edit
   landed** — that silently no-opped once.

Then execute it, expecting the plan itself to be wrong somewhere. On the rate-cut work the plan's own rules
were wrong on five of nine types, and the plan caught that **because it instructed the implementer to verify
against data before coding**. A plan that cannot be falsified by its own procedure is not much of a plan.

---

## Queue closed down to two families — `docs/PLAN-ROJMEL-FINAL-THREE.md`

Measuring the last four families reduced them to **two implementable ones**, and the reductions are more
interesting than the implementations.

| Family                    | Rows | Verdict                                                |
| ------------------------- | ---- | ------------------------------------------------------ |
| Fine JV 078               | 28   | **ready** — 2 types, source and data agree exactly     |
| Karigar Receipt 052       | 28   | **ready** — 4 types, one guard still to derive         |
| Wh Sales 034              | 32   | **blocked** — no wholesale-sale path exists in the web |
| Gold URD Purchase Old 043 | 27   | **not a gap** — retired book                           |

### Wholesale is a missing FORM, not a missing projection

**Now recorded properly in `GAP-ANALYSIS-AND-PLAN.md` under "The wholesale-sale voucher family".** Summary:
the web can post a wholesale _return_ (1503 lines, complete) but not a wholesale _sale_. There is no
separate return book type — `TR_WH_SALE_RTN.cs` filters `MAIN_BOOK IN ('WH SALES','TOUR SALES')` — so the
return can only ever act on migrated desktop data. The desktop form is 18,007 lines with a 13-table write
set. Also established there: `TOUR SALES` is entirely retired (10 books, **0 active**), so the standing
"TR_TOUR_SALE is a build not wiring" note is downgraded; and `BUL WH SALE` has 2 active books with **0**
vouchers.

`sales/wholesaleSaleReturn.ts` exists; there is no wholesale _sale_ module, function or route — only
`POST /sales/wholesale-sale-return`. A day book for book 034 would serve a voucher the web cannot create.
That belongs in the register at a different level than a Rojmel row type, alongside the standing note that
`TR_TOUR_SALE` and `TR_BUL_SALE` are builds rather than wiring.

It is also the most fragmented family in the file — 11 row types across 32 rows — so it is not cheap even
once the form exists. Seven of those types are already built in `buildRateCutRojmel`; only `05`, `06`, `25`
and `28` would be new.

### Book 043 is not a gap at all

`CUR_USE = 'N'` — the book is **disabled**, with `MAIN_BOOK` and `BOOK_TBL_NAME` cleared. Only 2 of 210
books are in that state. Its name ends in "Old", this company's convention for a superseded book, the same
as "Gold Tax Invoice Old" (026) which was replaced by 029.

So its 27 rows are historical, and **the web is right not to write them**: an operator cannot select a
disabled book, so no code path should produce them. They matter only for reading migrated history, which
`rojmelReport.ts` already does — it reads whatever the table contains regardless of which book wrote it.

This is the first family in the workstream that is **not** a gap, and the coverage arithmetic should treat
it as out of scope rather than outstanding. Realistic target is therefore **3113 of 3179 (97.9%)**, not 3140.

### A draft error worth recording

The first draft of that plan said book 043 "has no `BOOK_DATA` row" and concluded the book had been deleted.
It has a row; reading its columns is what revealed `CUR_USE='N'` and changed the decision from "do it last"
to "drop it". **Fourth time verifying a plan against the data has changed something material** — the
earlier three were five reversed directions, a stale export table, and the retracted `KR_DETL` gap.
