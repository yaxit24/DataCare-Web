# Verification reference

**What this is.** How to verify, measure and test the web against the desktop. For _how the system is
built_, see `TECHNICAL-REFERENCE.md`. For _per-module detail_, see `MODULE-VERIFICATION-CATALOGUE.md`.

**Last verified:** 2026-08-01. 1054 API tests in 124 files, 18 web tests, 9 gate scripts.

---

## 1. The method, in the order that works

Four sessions of mistakes produced this order. Each step exists because skipping it caused a specific,
documented error.

1. **Count the OUTPUT.** What rows did the desktop actually produce? No inference.
2. **Count the SOURCE COLUMNS.** A routine guarded on an empty column never fires.
3. **Read the source for STRUCTURE only** — tables, guards, which `BOOK_DETL` slot.
4. **Take DIRECTIONS and ACCOUNTS from the DATA**, unless verified to agree for that type.

| Skipping | What happened                                                                                   |
| -------- | ----------------------------------------------------------------------------------------------- |
| 1        | Ranked a routine top of a queue on a table's 110 rows; the column it reads is non-zero on **1** |
| 2        | Planned 40 rate-cut row types; only **9** ever fired                                            |
| 3        | Nearly implemented `Fine_CUT_Rojmel` — reads two tables with **0 rows**, dead code              |
| 4        | Wrote a plan from the source: **wrong on 5 of 9 types**, debit/credit reversed on four          |

**Source for what EXISTS, data for what RUNS.** Neither alone suffices: sampling cannot enumerate code paths
that never fired, and source cannot tell you which paths are live.

**The desktop source is a LATER version than the data.** Proven independently — sale item rows are type
`'02'` in the source and `'01'` in the data. But the divergence is **not uniform**: `Order_Rojmel` agrees on
all four live types while `Wh_Sales_Rojmel` disagrees on five of nine. **Verify per type; let data settle
disagreements.**

---

## 2. The five measurement recipes

### R1 — What did the desktop produce?

```bash
SQL -d Live24 -Q "SET NOCOUNT ON;
SELECT '  '+RIGHT('      '+CAST(SUM(p.rows) AS varchar),6)+'  '+t.name
 FROM sys.tables t JOIN sys.partitions p ON p.object_id=t.object_id AND p.index_id IN (0,1)
 WHERE t.name IN (<tables>) GROUP BY t.name HAVING SUM(p.rows)>0 ORDER BY SUM(p.rows) DESC"
```

A table with zero rows is **not a gap**. Roughly a third of the desktop's routines are dead for this
customer.

### R2 — Which columns are populated?

```bash
SQL -d Live24 -Q "SET NOCOUNT ON;
SELECT '  rows='+CAST(count(*) AS varchar)
 +'  <COL>='+CAST(SUM(CASE WHEN ISNULL(<COL>,0)<>0 THEN 1 ELSE 0 END) AS varchar) FROM <TABLE>"
```

**The most-skipped step and the one that saves most work.** Rate cut 40 types → 9. Sales order 8 → 4.

### R3 — Does the web write it?

```bash
python3 - <<'PY'
import re, pathlib
T = '<TABLE>'
for p in pathlib.Path('apps/api/src').rglob('*.ts'):
    t = p.read_text()
    for pat in [rf"insertRowTx\(\s*tx\s*,\s*'{T}'", rf"table:\s*'{T}'", rf'INSERT INTO "{T}"']:
        for m in re.finditer(pat, t):
            print(f"  {str(p).replace('apps/api/src/modules/','')}:{t[:m.start()].count(chr(10))+1}")
PY
```

**Must be multi-line aware.** A single-line grep requiring `{ table:` adjacent produced two false findings
that survived into four documents — the "15 unwritten tables" error and a retracted `KR_DETL` gap. Also
distinguish **write sites** from **delete lists**: a name in a `WRITE_TABLES` array is reversal, not writing.

### R4 — Who reads it?

```bash
for f in $(grep -rl "<TABLE>" unified/src/csharp/DataCareNext/*.cs); do
  printf "  %-22s select=%-3s insert=%-3s delete=%s\n" "$(basename $f)" \
    "$(grep -c "FROM <TABLE>" $f)" "$(grep -c "INSERT INTO <TABLE>" $f)" "$(grep -c "DELETE FROM <TABLE>" $f)"
done
```

This reclassified `OP_LDR` from "major gap" to "year-end snapshot read by one report", and established the
Rojmel's importance.

### R5 — Rojmel row types for a book

```bash
SQL -d Live24 -Q "SET NOCOUNT ON;
SELECT '  t'+SUBSTRING(LEDR_KEY,22,2)+' n='+CAST(count(*) AS varchar)
 +' it='+MAX(ISNULL(IT_TYPE,'-'))+MAX(CASE WHEN ISNULL(SIGN,'')='' THEN '_' ELSE SIGN END)
 +' dr='+CAST(SUM(CASE WHEN ISNULL(DR_AMT,0)<>0 THEN 1 ELSE 0 END) AS varchar)
 +' cr='+CAST(SUM(CASE WHEN ISNULL(CR_AMT,0)<>0 THEN 1 ELSE 0 END) AS varchar)
 +' fine='+CAST(SUM(CASE WHEN ISNULL(ITM_FINE,0)<>0 THEN 1 ELSE 0 END) AS varchar)
 +' keyLen='+CAST(MAX(LEN(LEDR_KEY)) AS varchar)
 FROM ROJ_MEL_DATA WHERE CO_BOOK='<BOOK>' GROUP BY SUBSTRING(LEDR_KEY,22,2) ORDER BY count(*) DESC"
```

Type counts must **sum to the book's total** — that is the arithmetic check that the scope is complete.

---

## 3. Controls: the non-negotiable part

**A gate is not trusted until demonstrated failing.** ~65 controls proven across this workstream.

```bash
F=<file>; cp $F /tmp/ctl.bak
# ...break exactly one thing...
(cd apps/api && npx vitest run <test file> 2>&1 | grep -E "→|Tests ")
cp /tmp/ctl.bak $F      # restore by COPY, never by hand-editing back
```

**Verify the control actually landed.** One zero-balance control failed to apply its edit and so "passed"
against unmodified code. A control that does not land is not a control; assert the edit, then run.

Other invalidity conditions, each learned the hard way:

- A control failing for the **wrong reason** (a syntax error) is invalid — reject and redo minimally.
- A control that **passes** when inverted means the test does not cover that case.
- A backtick inside a shell `-c` string breaks bash and the control "passes" against unmodified code — use
  a heredoc.
- A control on `packages/core` needs `pnpm --filter @datacare/core build` first.

### Controls that have earned their place

| Broken                             | Message                                                               |
| ---------------------------------- | --------------------------------------------------------------------- |
| money on a money-free fine row     | `expected 0.11 to be +0`                                              |
| inverted `SIGN`                    | `expected '+' to be '-'` **and** the report's metal bucket empties    |
| no account-order flip              | `expected '000939' to be '00008'`                                     |
| removed `<> 0` guard               | `expected 4 to be 3`                                                  |
| dropped a write                    | footprint fails **naming the table**, and the report bucket goes to 0 |
| reused a `LEDR_KEY` type code      | **`23505`** — the schema itself is the gate                           |
| `Math.abs` on a negative round-off | `expected 0.35 to be -0.35`                                           |
| dropped the idempotent DELETE      | `to have a length of 1 but got 2`                                     |
| carried zero-balance accounts      | `expected [ 'CUST', 'SETTLED' ] to deeply equal [ 'CUST' ]`           |

---

## 4. Test conventions

**Footprints are asserted as an exact SET** — `toEqual`, never `toContain`. A subset assertion cannot see an
unexpected **extra** write, and an extra write is how a duplicate ledger posting appears. This weakness was
found in the sales-return test and fixed; adding a write there had failed nothing.

```ts
const touched = await withTenant(prisma, tenantId, (tx) =>
  footprintOf(tx, tables, tenantId, vchNo),
);
expect(touched).toEqual(['AC_DATA', 'ROJ_MEL_DATA', 'SL_ORD_DATA', 'SL_ORD_DETL']);
```

⚠️ **`footprintOf` reads directly and expects an owner client.** Its `.catch(() => [{ n: 0 }])`
(`test/support/footprint.ts:63`) turns a blocked read into a **count of zero**, so an RLS-bound client
reports an **empty footprint rather than failing**. Pass a tenant-scoped transaction, as above.

**Pass the runtime client to the code under test.** The owner bypasses RLS — see
`TECHNICAL-REFERENCE.md` §2 for the 637,842.82 incident.

**Every statement inside `withTenant`.** Outside it, reads return 0 and `DELETE` is a silent no-op.

**Any table added to a write set** must join both the module's `WRITE_TABLES` and every DB test cleanup list.
`ROJ_MEL_DATA` bit four times before a sweep added it to 20 files.

**Never weaken a test to make it pass.** When one fails, the code is wrong until proven otherwise. One
exception was legitimate — an assertion asserted "count is zero" where the seed legitimately inserts a row —
and that was established by _reading the seed_, not by relaxing the assertion.

**Test files are NOT typechecked.** `tsc -p tsconfig.json` covers `src` only.
`apps/api/tsconfig.test.json` exists and surfaces **112 pre-existing errors**, so it is not a gate. A type
error in a new test will not be caught.

---

## 5. The gates

```bash
pnpm settings:parity        # 128/128 (100%)
pnpm schema:readiness       # 145/145 tables, 5231/5231 columns (100.0%)
pnpm fresh:provision        # 172 tenant tables, RLS forced + policy, 1 allowed drift
node scripts/report-baselines.mjs    # 254 layouts unchanged — never pass --write
node scripts/check-g5-parity.mjs     # G5_RED — correct, see §7
pnpm type:parity            # 226 numeric->text mismatches baselined; a NEW one fails
pnpm register:check         # 198 desktop menu items; --strict fails while any is unclassified
pnpm lint                   # 502 files, 0 policy violations
pnpm build --force          # 7/7
(cd apps/web && node test/browser.smoke.mjs)   # AFTER build, exit 0
```

`schema:readiness` measures against `DESKTOP-REAL-SCHEMA.json`, captured from the real customer database. It
previously used a contract extracted from decompiled DDL strings that over-claimed 19 tables, missed 9 the
installer creates and found only ~64% of real columns — printing a misleading **96.9%** every run. The old
contract is still reported second, informationally.

`report-baselines.mjs` with `--write` **regenerates** the baselines, which destroys the comparison. Never
pass it while verifying.

---

## 5b. Two measurement methods that failed, and why

Recorded because both produced a confident wrong number, and the second nearly reached a report.

**Matching desktop menu labels to web form names.** Reported 165 of 198 menu items missing — including
`Sales`, `Purchase`, `Rojmel` and `Rate Cut`, all of which the web demonstrably has. The desktop uses terse
labels (`Amt In`, `Kr Issue`, `Dhrn Rec`); the web uses expanded ones (`Accounts`, `Books / Series`, `Party
(rich)`). **Lexical matching between two naming conventions measures the conventions.**

**Grepping a feature's tables to decide whether it exists.** Reported a hit for nearly everything, because an
incidental mention of `LBR_TYPE` in an unrelated module is indistinguishable from an implementation of the
Labour Type master.

**The general lesson, now recorded three times in different forms:** a proxy that is cheap to compute is
usually cheap because it is not measuring the thing. `formReferencedInWeb` survives in the register only
because its _direction_ is honest — a weak positive and a strong negative — and because the register says so in
the file.

**What replaced them:** a human classification per item, with an evidence path the gate checks exists on disk.

## 5c. The authoritative surface: `NextMain.MENU_DATA`

```bash
SQL -d NextMain -Q "SET NOCOUNT ON;
SELECT ISNULL(BTN_NAME,'')+'|'+ISNULL(SM_NAME,'')+'|'+ISNULL(SM_VIEW,'')
  FROM MENU_DATA WHERE ISNULL(SM_NAME,'')<>'' ORDER BY BTN_NAME, SM_NAME"
# 198 named items, 13 tabs, per-item visibility flag
```

Use this, **not** the count of `.cs` files, whenever the question is _what can a user do_. Form files answer
_how much code exists_ — 204 files, 969,133 lines — and several back many menu entries while others are
infrastructure no user reaches.

Menu → form comes from the `MDI_FORM.cs` dispatch: find a quoted label, then the next
`new (TR|RP|MS|UT)_*(` within ~700 characters. 186 of 198 resolve that way.

## 5d. The databases available

| Database   | Business         | Use it for                                                                   |
| ---------- | ---------------- | ---------------------------------------------------------------------------- |
| `Live24`   | DHAKAN JEWELLERS | voucher behaviour — 5150 ledger rows, 3179 Rojmel, 918 accounts              |
| `Next25`   | NJ GOLD          | **a second business** — two companies, 569 accounts, 2024-25 **and** 2025-26 |
| `Next23`   | DEMO COMPANY     | 28 ledger rows; a demo, not a customer                                       |
| `Next24`   | —                | seed, no vouchers                                                            |
| `NextMain` | —                | `MENU_DATA`, `USER_SET`, the company registry                                |

`Next25` is how the standing single-sample caveat starts getting tested. It has few transactions, so it tests
**masters, multi-company and multi-year**, not voucher behaviour.

## 6. Process rules

**Never put ANYTHING that can fail in the same shell block as the commit that describes it.** Run the work,
read the result, _then_ commit as a separate step.

The rule began narrowly — `vitest run` and `git commit` — after three commits landed on red. That wording was
too narrow, and it recurred in a different form: a documentation edit failed on a prettier reflow, its
assertion fired and printed `AssertionError`, and the `git commit` in the same block ran anyway with a message
claiming the edit had landed. **A failing step does not stop a following command.**

The commit must be a separate step whose input is a result already read.

**Do not overwrite a failure log before reading it.** The identity of nine failing tests was lost that way.

**Known flakiness.** `vitest.config.ts` bounds concurrency to `maxThreads: 4` because ~half of 124 test
files each open a `PrismaClient` against one Postgres with `max_connections` 100. It still recurs when other
processes hold connections.

| Contention                           | Real defect               |
| ------------------------------------ | ------------------------- |
| failing files move between runs      | same test fails every run |
| several unrelated files fail at once | one file, one assertion   |
| passes on re-run, nothing changed    | fails on re-run           |

Before concluding contention: `pkill -f "apps/api/dist/server.js"`, close stray `psql` sessions, re-run.
Check with `psql … -tAc "SELECT count(*) FROM pg_stat_activity"`.

**Assert that string replacements landed.** Prettier reflows files, so an exact-match `replace()` can
silently no-op and report success. This produced a document claiming an implemented feature was missing, and
a commit message claiming an edit that never happened. Match on content, assert **before and after**, and
re-check on disk **after** prettier runs.

**A retracted method leaves behind conclusions drawn with it.** Re-check them individually. The `KR_DETL`
false positive survived a headline correction by exactly that route, staying in four documents for weeks.

---

## 7. What is unverified, ranked

1. **No voucher has ever been compared to the desktop field-by-field.** `g5:parity` is RED and correctly so.
   Everything else is parity by **construction**, not by comparison. The harness is ready — bundle format,
   type-aware canonicaliser, union-not-intersection differ, 24 unit tests — and `Live24` holds 190 real
   sales. **This is the highest-value remaining task and has been for weeks.**
2. **37 of 39 behaviour settings have no matrix.** Surfaced and loaded, but no test proves each changes the
   persisted result. The largest well-defined block of unproven behaviour.
3. **Report data never compared**, even locally, though `Live24` makes it possible without Crystal.
4. **No Crystal output compared** — needs the Windows box.
5. **Test suite not typechecked** (§4).
6. **Hardware and messaging never connected** to a real device or credential.
7. **One company, one fiscal year.** Every priority is an inference from a single sample; the live/dead
   classifications are facts about `Live24` alone. A pawnbroker would invert them — the six dhrn/loan
   routines are dead here and might be the main event elsewhere.

---

## 8. Desktop database access

```bash
cd /Users/yakshitsavaliya/Desktop/imodule-extracted
docker ps --format '{{.Names}}' | grep -q dc-mssql || docker start dc-mssql
sleep 25   # amd64 emulation on arm64

SQL() { docker exec dc-mssql /opt/mssql-tools18/bin/sqlcmd \
          -S localhost -U sa -P 'ParityProbe#2026x' -C -W -s'|' -h -1 "$@"; }
SQL -d Live24 -Q "SET NOCOUNT ON; SELECT 'rojmel='+CAST(count(*) AS varchar) FROM ROJ_MEL_DATA"
# expect: rojmel=3179
```

**The `.BAK` files restore to SEED databases with no vouchers.** Only the loose `.mdf` carries transactions —
restoring a backup and stopping there produces an empty comparison that reads as agreement.

**This is real customer data**: 918 accounts, real names. Never commit it, never echo names into output,
commit messages or fixtures. Extract counts and structure only. Confirm any new artifact path with
`git check-ignore` before writing.
