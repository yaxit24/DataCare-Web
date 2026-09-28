# HANDOFF

> Current implementation and safe test startup: [Round15 in-progress status and all remaining gaps](../../parity-plan-2026-09-10/42-implementation-progress-round15.md); [sealed Round14 progress](../../parity-plan-2026-09-10/40-implementation-progress-round14.md) and [latest sealed checkpoint41](../../parity-plan-2026-09-10/41-implementation-checkpoint-round14.json). Round 15 adds pure saved Other-amount replay, strict effect-storage context qualification, a seven-row financial effect planner and an ordered Save-guard evaluator, plus six shared composition cases. They preserve the prior Save map, exact header Float qualifier, N BAR matcher and internal Serializable coordinator. No new API route, UI Save flow or writer is enabled; numeric Return saves and known closing remain disabled. Implementation is paused for this status review. Round 15 is an in-progress snapshot: the recorded core run passed 26 files / 1,613 tests and strict compilation of the five new core test files passed; the remaining 16 checks in the 18-check recipe have not run. Checkpoint 43 is not sealed. Checkpoint 41 remains the latest sealed verification record and applies to the earlier Round 14 inputs. Run `pnpm test:parity:api` for the isolated API suite, or `node scripts/parity-test-env.mjs -- <command>` for another isolated command. Calling the wrapper without a command only provisions the test DB. Keep each actual run bound to its complete dependency snapshot. The older environment instructions below remain historical.

> Current status supersedes this dated narrative: read [the historical11 September completion-review baseline](../../parity-plan-2026-09-10/11-current-completion-review.md) and [implementation continuation](../../parity-plan-2026-09-10/12-execution-addendum.md). Menu mapping is complete; full implementation and parity acceptance remain open.

For an engineer who has never seen this project. Read this before touching anything.

The layout inventory was refreshed on 2026-09-11. Other test totals, commands and session claims below are a historical record; use the current checkpoint for verification.

Written 2026-08-02. Everything here is either measured (with the measurement stated) or flagged as uncertain.
Where I got something wrong during the session, the wrong version is kept alongside the correction, because the
method error is usually more useful than the corrected fact.

---

## 1. What this project is

**DataCareNext** is an offline Windows desktop ERP for Indian jewellery/gold businesses — Windows Forms +
Crystal Reports + SQL Server. The task is to convert it to a web application with **exact behavioural parity**:
same modules, features, workflows, calculations, keyboard behaviour, reports, and — critically — the same
**database write-sets**. The stack changes; behaviour must not.

The last point is what makes this unusual. This is not "build a modern equivalent." A voucher saved in the web
app must write the same rows, with the same column values, in the same tables, as the desktop would. Real
businesses have years of data in these tables and reports that read them.

### Layout

```
/Users/yakshitsavaliya/Desktop/imodule-extracted/          project root
  unified/src/csharp/DataCareNext/*.cs                     desktop source — AUTHORITATIVE (204 forms, 969,133 lines)
  web/                                                     the web workspace (pnpm monorepo)
    apps/api/src/modules/                                  31 business modules
    apps/api/test/                                         235 test files (132 DB files); current results in round-9 evidence
    apps/api/integration/                                  parity harness (extract / replay / compare)
    docs/                                                  plan + references + per-family comparison records
    scripts/                                               gate scripts (docs:refs, type:parity, register:check…)
  project-memory/parity/                                   bundles + diffs — GIT-IGNORED, contains real customer data
```

The desktop `.cs` files are **decompiled**, so they are verbose and contain designer boilerplate. Do not use
line counts as a measure of anything. `TR_PURC.cs` is 17,255 lines; perhaps 500 are business logic.

### GitHub

Branch `main`, pushed after every commit. Roughly 25 commits this session.

---

## 2. Environment — exact setup

```bash
export PATH=/opt/homebrew/opt/postgresql@16/bin:$PATH
export DATABASE_URL='postgresql://app_user:imgValidationSecret2026x@127.0.0.1:55433/datacare?schema=public'
export MIGRATE_DATABASE_URL='postgresql://postgres@127.0.0.1:55433/datacare?schema=public'
export RUN_DB_INTEGRITY_TESTS=1 RUN_DB_SECURITY_TESTS=1
export MSSQL_TYPES=/tmp/mssqltypes.txt   # only for `pnpm type:parity`
```

**Port 55433 only** — container `datacare-test-55433`. There is a _second_ Postgres on 5433
(`web-postgres-1`) which is NOT the test database. Using the wrong one produces confusing empty results.

Do **not** pass `?schema=public` to `psql` — it is a Prisma-ism and psql treats it as part of the dbname.

`timeout` is unavailable on macOS.

### SQL Server (the real desktop data)

```bash
docker ps --format '{{.Names}}' | grep -q dc-mssql || { docker start dc-mssql; sleep 30; }
```

Credentials: `-S localhost -U sa -P 'ParityProbe#2026x' -C`. Host port 11433 for the parity harness.

**Always use a guarded helper.** Docker stopped mid-session twice, each time returning _empty output_ rather
than an error — and an empty result reads as "no rows match," i.e. a finding. My first guard tested for
emptiness and produced a false alarm within the hour (the real cause was a filter on a wrong `MAIN_BOOK`
name). Test **exit status and SQL Server's error markers**, not emptiness:

```bash
SQL() {
  local out; out=$(docker exec dc-mssql /opt/mssql-tools18/bin/sqlcmd \
    -S localhost -U sa -P 'ParityProbe#2026x' -C -W -s'|' -h -1 "$@" 2>&1); local rc=$?
  if [ $rc -ne 0 ] || printf '%s' "$out" | grep -qiE "Msg [0-9]+|Login failed|not running"; then
    echo "SQL_FAIL rc=$rc: $out" >&2; return 1; fi
  printf '%s\n' "$out"
}
```

**Quoting gotcha:** multi-value `IN ('035','036')` clauses passed inline to `sqlcmd -Q` intermittently
returned empty. Writing the SQL to a file and using `-i` fixed it reliably:

```bash
docker cp /tmp/q.sql dc-mssql:/tmp/q.sql
docker exec dc-mssql /opt/mssql-tools18/bin/sqlcmd -S localhost -U sa -P '…' -C -W -h -1 -d Live24 -i /tmp/q.sql
```

### The databases

| Database     | Business         | Contents                                                                                                 |
| ------------ | ---------------- | -------------------------------------------------------------------------------------------------------- |
| **`Live24`** | DHAKAN JEWELLERS | **Real customer data.** 5150 ledger rows, 190 sales, 3179 Rojmel, 918 accounts. One company, FY 2024-25. |
| `Next25`     | NJ GOLD          | **Two companies**, 569 accounts, FY 2024-25 **and** 2025-26. Few transactions.                           |
| `Next23`     | DEMO COMPANY     | 28 ledger rows. A demo, not a customer.                                                                  |
| `Next24`     | —                | Seed, no vouchers.                                                                                       |
| `NextMain`   | —                | Config registry. Source of `MENU_DATA` (see §4).                                                         |

**`Live24` is real customer data with real names.** Never commit it; never echo PII. Bundles under
`project-memory/parity/` are git-ignored — verify with `git check-ignore` before trusting that.

**This is the single largest caveat on the whole project:** essentially every rule established so far was
measured on `Live24` — one company, one fiscal year. See §9.

---

## 3. The mental model of the data

You cannot do this work without these. They are not obvious from the schema.

### 3.1 A voucher is a key, not a row

Every business document (`sale`, `purchase`, `cash receipt`…) is identified by a 5-part key:

```
CO_CODE (2) + LC_CODE (2) + CO_YEAR (9) + CO_BOOK (3) + VCH_NO (5)
```

`CO_BOOK` is the **book** — a numbered document series (026 = gold tax invoice, 035 = gold purchase, 001 =
cash receipt). `MAIN_BOOK` groups books by kind (`SALES`, `PURCHASE`, `CASH REC`). Many behaviours are
**per-book**, not per-kind, and this trips people constantly.

**Filtering on part of a voucher key silently matches the wrong rows.** This caused a test to fail only in
the full suite (it filtered on book + voucher number, so another test's voucher in a different `CO_YEAR`
matched too), and it caused the bundle differ to mis-pair rows in Phase 0.1. Always use the full 5-tuple.

### 3.2 `LEDR_KEY` — and there is no single layout

`AC_DATA` (the general ledger) rows are keyed by `LEDR_KEY`, which is the voucher key plus a tail. **Four
distinct tail layouts are confirmed, and no two agree:**

| Family          | Length | Tail                                                                                     |
| --------------- | ------ | ---------------------------------------------------------------------------------------- |
| Sale            | 23     | leg type at chars 22-23                                                                  |
| Scheme          | 33     | bare line number right-aligned in 10                                                     |
| Cash            | 33     | `<line><leg>` right-aligned in **12** — so `SUBSTRING(LEDR_KEY,22,2)` returns **spaces** |
| Cash's _Rojmel_ | 33     | leg at 22-23 **plus** bare line in 10 — a fourth shape, for the same voucher             |

And in family 4 (purchase) I found **two layouts inside one table of one book**, selected by leg type: money
legs are 23 characters, type-21 fine legs are 33 with the cash books' `<line><leg>` form.

```
[01002024-20250350000101]              money leg, 23 chars
[01002024-202503500004         121]    fine leg, 33 chars, line 1 leg 21
```

`VCH_NO` in the key is **five** characters, not six. Padding to six produced a 24-character key with an extra
zero, so every web ledger key differed from the desktop's in a column that is part of the primary key.

### 3.3 Leg type codes are per-`MAIN_BOOK`, not per-role

Each ledger row carries a 2-digit semantic code. **The same number means different things in different
books, and the same role gets different numbers.** Measured:

```
001 CASH REC   01 party Cr / 02 cash Dr    03 party Cr / 04 kasar (00057 JAVK) Dr
002 CASH PAY   05 party Dr / 06 cash Cr    07 party Dr / 08 kasar (00042 AVAK) Cr
BANK REC       01/02 (as cash)   03/04 (as cash)   05/06 = BANK CHARGES  ← not party/cash!
BANK PAY       07/08 (NOT cash's 05/06)             11/12 = bank charges
035/036 PURC   01 party Cr / 03 purchase Dr / 06 tax Dr / 16-17 settlement / 18-19 kasar / 21 fine
SALE           …04 for tax, where purchase uses 06
```

Three independent confirmations that codes are per-book: the cash/bank split, the receipt/payment split, and
purchase tax `06` vs sale tax `04`.

Also note the **kasar account differs by direction** — _javak_ (00057) outgoing, _avak_ (00042) incoming. One
account for both would post half the discounts to the wrong ledger.

**Consequence for shared helpers:** `payoutLegs` in `finance/tender.ts` now takes leg codes **from the
caller** rather than defaulting. Four different pairs are known for the same settlement role (purchase 16/17,
sale cash 19/20, sale bank 09/10, cash-book payment 05/06). Defaulting any one is a guess on three other
callers' behalf. A caller that has not measured its codes omits them and falls to a **reserved band `50 +
srno`**, which can neither collide with nor masquerade as a measured code.

### 3.4 `ROJ_MEL_DATA` is a day book of _movements_, not a double-entry mirror

The Rojmel is the jeweller's day book — the report a shop opens each morning. It shows metal and money side
by side, which `AC_DATA` cannot.

It is **not** a copy of the ledger. Cash movement is **one** row; a kasar write-off is a **pair**. The web
originally mirrored the ledger and produced spurious rows. The composition rules that are measured:

- **One metal row per detail line**, carrying that line's pieces/weight and its `IT_CODE`/`IT_DESC`
- **A party row only when the bill is outstanding** — see §3.5
- **A tax row only when there is tax**
- Settlement rows per tender type (`11` cheque, `13` kasar, `14` advance, `16` old gold)

`IT_TYPE` is the **metal**, not a flag: `G` gold (335 rows), `S` silver (130), `O` other (3), `A` a money row
(2711). `LD_CODE` is the **contra** account. `AC_NAME` is denormalised to the **party's** name on every row,
even rows whose `AC_CODE` is the sales or tax account.

**A metal row carries `IT_CODE`; a money row never does.** Measured: 240 metal rows all have it, 466 money
rows all blank.

### 3.5 `BILL_OS` governs the party row

Measured on the sale books: of **47 sales with `BILL_OS = 0`, zero** carry a party Rojmel row; of **42 with
`BILL_OS ≠ 0`, all 42** do. A fully settled bill leaves no receivable for a day book to show.

`BILL_OS = grandTotal − paidNow − kasar`.

I got this wrong in a way worth recording. I found purchase vouchers 035/00001 and 035/00003 — same book,
same year, both single-line cash purchases — with 1 and 3 Rojmel rows respectively, and **recorded the
desktop as internally inconsistent**. It is not. Voucher 00001 pays 6780.00 against a 6780.00 bill, so
nothing is outstanding. The discriminator was `BILL_OS`, which I had **already measured and written into
`rojmel.ts`** during family 1. I compared the vouchers on line count and tender without checking the column
that governs the behaviour.

**"The desktop is inconsistent here" is the most expensive wrong conclusion available** — it terminates
investigation and invites an invented rule in place of a measured one. Treat it as a claim requiring more
evidence than any other, not less.

### 3.6 `SIGN` is a movement direction, not a debit/credit marker

Measured across **every** table in `Live24` with a `SIGN` column — 11,548 rows:

```
AC_DATA        blank 4975   + 105    - 70
ROJ_MEL_DATA   blank 2711   + 160    - 308
AD_OS                       + 8160   - 34
AD_ADJ                               - 26
```

`C` and `D` appear **nowhere**. The rule: blank on a money leg, `+`/`-` only where metal moves — 174 of the
175 signed `AC_DATA` rows carry a non-zero `FINE_WT` (the one exception is in book 034, wholesale sale, which
is not built). `+` is metal **in** (purchase 035, karigar receipt 052), `-` is metal **out** (karigar issue
050, labour work 088). Books with both (000 opening stock, 064 rate cut, 078 fine JV) are transfers.

**The web had 122 sites across 14 modules writing `C`/`D`.** Fixed centrally in `enrichLedgerLine`
(`modules/posting/posting.ts`) rather than at 122 call sites.

**The C/D alphabet is CORRECT for other columns** — `OP_DATA.OP_SIGN` (D 73 / C 35) and `OP_DATA.FINE_SIGN`
(D 97 / C 11) are genuine opening-balance debit/credit markers. `MAIN_STOCK.ITM_SIGN` is `+`/`-`. The
normalisation matches `SIGN` **alone**.

### Cross-company check — RUN, and it passed

The `SIGN` change was the widest in the project (122 sites, 14 modules) and rested on `Live24` alone, so it
was falsification-tested against **`Next25`** (NJ GOLD, a different business, two companies, different chart
of accounts):

```
AC_DATA      rows with SIGN outside {+,-,blank}:  0   (of 1310)
ROJ_MEL_DATA rows with SIGN outside {+,-,blank}:  0
```

**Not falsified.** `C`/`D` appears in neither company. This is the first cross-company evidence in the
project, and it upgrades "blank/+/- is DHAKAN's alphabet" to "blank/+/- is the software's alphabet."

**But note precisely what it does NOT establish.** `Next25`'s `AC_DATA` is entirely blank — 1247 rows for
company 01 and 63 for company 02, with **no signed rows at all**. So it confirms the negative (C/D never
occurs) and gives **no independent support** for the positive half of the rule (`+`/`-` where metal moves,
`+` in / `-` out). That half still rests on `Live24`'s 175 signed rows. `ROJ_MEL_DATA` has a handful
(4 minus, 3 plus) — consistent, but too few to be evidence.

This is the predicted sparseness limit in action: a thin second database confirms alphabets and stays silent
on shapes. **Silence is not support.**

Independent confirmation found afterward: **every reader in the web already used `+`/`-`** —
`partyBalance.ts:30`, `dataRepairOps.ts:334`, `vpParcel.ts:1093`, `wholesaleSaleReturn.ts:1168`. The readers
were right; the writers were wrong.

### 3.7 `VCH_TYPE` = `BOOK_DATA.BOOK_SNAME`

Confirmed both ways. Source: `TR_PURC.cs:13093` (and five sibling rows) assigns
`dataRow["VCH_TYPE"] = FormBookSname`. Data: `VCH_TYPE` equals `BOOK_SNAME` on **39 of 40 books** — 035
`FGPR`, 036 `FSPR`, 026 `TGSL`, 027 `TSSL`, 032 `MIXSL`, 014 `BBPAY`. The single exception is book 000
opening stock (`OPSTK` vs `ACOP`), which no transaction form writes.

`bookPolicy.ts:84` already does this correctly.

**An abandoned path worth knowing:** I spent time inferring a _formula_ from `BOOK_TYPE` + `ITM_TYPE`
(T+G→`TGSL`, F+G→`FGPR`, M+A→`MIXSL`). The fit was real but coincidental — those strings are simply what
someone **named** the books. Book 014's `BBPAY`, which breaks any formula while its `BANK PAY` siblings
010/012/013 are `BPAY`, was never an anomaly. Had I implemented the formula, books 000 and 014 would both be
wrong and so would every book the business creates in future. `BOOK_VCH_TYPE` is **not** the source — it holds
`NU` or blank.

### 3.8 Other measured facts

- `BOOK_DETL` is a per-book account **slot** table. `SR_NO` 1 sale, 2 cash, 3 kasar, 4 advance, 5 discount,
  6 labour income, 7 cash purchase, 8 scheme bonus. Account literals in `Ac_Rojmel.cs` are selecting these.
- Real `MAIN_BOOK` values are `CASH PAY` / `CASH REC` / `BANK PAY` / `BANK REC` — **not** `CASH PAYMENT`, which
  the original plan assumed.
- `TAX_MAST` code `'00'` is a **legitimately configured zero rate** — "TAX FREE", `TAX_PRC` 0.00, account
  00014 — used by **57 of 190 sales** and 7 of 74 purchases. Tax-free is mainstream, not an edge case. Blank
  tax codes also exist (41 sales, 62 purchases).
- All 918 `Live24` accounts are `AC_GST_TYPE='L'` (local). No inter-state data exists to test against.
- `tenant_id` is `varchar(24)`; `AC_MAST.AC_CODE` `varchar(8)`; `ITEM_MAST.IT_CODE` `varchar(5)`.

---

## 4. The authoritative denominator: `MENU_DATA`

`NextMain.MENU_DATA` holds the desktop's real menu: **198 named items across 13 tabs** (Report 27, Other 25,
Transaction 25, Master 24, ExtraTran 22, Karigar 18, Company 17, Dhiran 13, More 12, Scheme 12, Analysis 8,
Mfg 4, Crm 2), with a per-item visibility flag. Chained through `MDI_FORM.cs`'s dispatch: **186 of 198 resolve
to a form, 152 are referenced somewhere in web source, 34 never are, 12 are unresolved labels.**

This replaced the plan's own baseline. Counting `.cs` files answers "how much code exists"; `MENU_DATA`
answers "what can a user do" — which is the question that matters.

Tracked in `docs/COMPLETION-REGISTER.json`, gate `pnpm register:check`. **All 198 are currently
`unclassified`. Phase 2 has not started.**

**Two measurement methods for this already failed and are recorded so nobody repeats them:** label matching
(claimed 165/198 missing, including `Sales` and `Purchase` — obviously wrong), and table grepping (claimed
almost everything exists — equally wrong). The intended approach is that `formReferencedInWeb` **orders** the
work and a human classifies each item with an evidence path the gate verifies exists.

---

## 5. The method that works

This is the core process. It was arrived at by failure and it should not be shortcut.

```
measure → replay → compare → fix → prove a control → record
```

1. **Measure the output first.** Count real rows per book grouped by leg type. Count distinct values per
   column. Do this _before_ reading source, so the source cannot bias what you look for.
2. **Read source for structure only** — which tables, which order, which conditionals. Take **directions and
   values from data**, never from source.
3. **Replay** a real voucher through the web (`apps/api/integration/parity-replay-*.mjs`).
4. **Compare** desktop vs web bundles field by field.
5. **Fix**, then **prove a control**: break the fix deliberately and confirm the test fails _for the right
   reason_.
6. **Record** in `docs/comparisons/family-NN-*.md` in the **same commit** as the code.

### Running the harness

```bash
# 1. Desktop bundle
export PARITY_MSSQL_HOST=127.0.0.1 PARITY_MSSQL_PORT=11433 PARITY_MSSQL_USER=sa
export PARITY_MSSQL_PASSWORD='ParityProbe#2026x' PARITY_MSSQL_DATABASE=Live24
export PARITY_MSSQL_ENCRYPT=false PARITY_COMPANY=01
export PARITY_CASES='[{"caseId":"purc-035-00001","book":"035","vchNo":"00001"}]'
(cd apps/api && node integration/parity-extract-mssql.mjs)

# 2. Replay — ALWAYS build first; the .mjs files import from dist/
pnpm --filter @datacare/api build
(cd apps/api && PARITY_STRICT=1 node integration/parity-replay-purchase.mjs)

# 3. Web bundle
export PARITY_TENANT=parity-purchase PARITY_COMPANY=01 PARITY_LOCATION=00
(cd apps/api && node integration/parity-extract-pg.mjs)

# 4. Compare
B=/Users/yakshitsavaliya/Desktop/imodule-extracted/project-memory/parity/bundles
(cd apps/api && PARITY_OPERATOR=purchase-family node integration/parity-compare.mjs \
   $(ls -t $B/desktop-2*.json | head -1) $(ls -t $B/web-2*.json | head -1))
```

Replays exist for `sale`, `scheme`, `cash` (with `PARITY_REPLAY_CASE=payment`), and `purchase`.

**Seed replays with the REAL configuration values.** I seeded `BOOK_SNAME='PURC'` where the real book holds
`FGPR`, and the resulting `VCH_TYPE` difference looked like a web defect for several steps. It was my
fixture. Likewise `IT_NAME='FINE GOLD 999'` vs the real `'FINE GOLD'`. **A replay's seed must mirror the real
master data, or the diff measures the fixture rather than the code.**

---

## 6. Traps — every one of these cost real time

1. **Empty output is not zero rows.** See §2. This applies to SQL Server, to `footprintOf` (which used to
   `.catch(() => [{n:0}])`, turning an unreadable table into "the module wrote nothing" — a false accusation
   against working code), and to shell pipes.
2. **A key column must not be a column under test.** Phase 0.1: bundle row keys were built with each side's
   own numeric scale, so `SR_NO=1` never matched `SR_NO=1.000000`, and two multi-row tables were reported
   missing+extra instead of diffed. Fixing it took fields compared from **271 to 540**.
3. **The same trap in reverse — a test's selector can depend on a wrong value.**
   `sales.lifecycle.db.test.ts` selected the party leg with `AND a."SIGN"='D'`. When `SIGN` became correct the
   selector matched nothing and reported `ledger_total: null`. Select on amounts (`coalesce("DR_AMT",0)<>0`),
   not on flags you may be about to fix.
4. **Substring greps over-match column names.** `SIGN: 'C'` also matches `OP_SIGN:` and `ITM_SIGN:` — where
   `C`/`D` is _correct_. My first count said 125 sites and "C/D appears nowhere"; the truth was 122 sites and
   C/D is correct in two other columns. Acting on the first reading would have broken two working columns
   while fixing one. **Match field-exact, and reason per column, never per column-name-pattern.**
5. **Near-identical function bodies make anchored edits land in the wrong function.** `postPayment` and
   `postPaymentLines` are nearly identical, so an anchor like `assertBalanced(ledger);` matches the wrong one
   first. Four misplaced edits happened this way. Anchor by line index inside the intended function, and
   **assert that the replacement landed where you intended.**
6. **Restore controls from a `cp` backup, never `git checkout <file>`** — that reverts to HEAD and silently
   discards uncommitted work in the same file. And **never leave a control edit unrestored across a tool
   boundary**: put the sabotage and the restore in separate verified steps, because if one command block dies
   partway you lose the guarantee. Verify the restore explicitly (`grep -c`), do not assume it.
7. **Piping corrupts measurements.** `$?` reports the pipe's status, not the command's. `grep -c` on an empty
   stream returns 0, which reads as success. `head` on a measurement makes an incomplete answer look complete
   — this produced a wrong recorded bound (cash line prefix "max 4" when it reaches 9).
8. **`pnpm typecheck:tests` needs `NODE_OPTIONS=--max-old-space-size=6144`.** The default heap OOMs at exit
   134, which reads exactly like a type failure.
9. **RLS has two faces.** An RLS-bound client returns zero rows silently; the **owner bypasses RLS** and
   returns every tenant's rows (an account seeded with 1,000 once reported 637,842.82). Pass the runtime
   client to code under test; use the owner only for setup and inspection.
10. **`postVoucherTx` does not add voucher key columns** — spread `...key` yourself.
    `insertRowTx(tx, TABLE, tenantId, row)` takes tenant as a **separate argument**.
11. **Any table added to a write set must join every DB-test cleanup list**, or later tests inherit rows.
12. **New routes need three edits:** `route(...)` in `routePolicy.ts`, a form in `formCatalog.ts`'s
    `FORM_CATALOG`, and the pinned count bumped in **both** assertions.
13. **Historical migrations are immutable.** `EXPECTED_MIGRATIONS` in `ops/migrationManifest.ts` pins name +
    real SHA-256. A placeholder checksum was correctly rejected by `opsInvariants`.
14. **`docs:refs` pins the test-file count** via `HTML-comment verify marker` in `TECHNICAL-REFERENCE.md`. It has
    caught this going stale **four** times. Bump it whenever you add a test file.
15. **Assert both the count and the per-item values.** An aggregate can match a count while carrying wrong
    figures.
16. **Footprints are asserted as an exact set** (`toEqual`, never `toContain`).

### Process rules, each added after a violation

- **Never put anything that can fail in the same shell block as the commit that describes it.** A doc edit
  failed on a prettier reflow while the commit ran anyway and claimed the edit had landed.
- **Every gate must be demonstrated failing before it is trusted.** A control that fails for the _wrong
  reason_ is invalid — redo it minimally. Two controls this session failed to fail (a single-row fixture
  bypassed key construction; a test asserted `TAG_NWT` while `TAG_GWT` was broken) and two failed for the
  wrong reason (deleting a leg unbalanced the voucher instead of testing the count; an out-of-scope edit gave
  `lineSuffix is not defined`).
- **Do not overwrite a failure log before reading it.**
- **A retraction must state the method error, not just the corrected fact.**
- **A control must prove the layer you actually changed.** My four unit tests for the `partyAmount` fix
  exercised the shared builder's guard — which was always correct — so they passed whether or not the caller
  regressed. Only a caller-level test through `createPurchase` caught it.

---

## 7. Current state

### Verification sequence (run all of it before claiming anything)

```bash
cd /Users/yakshitsavaliya/Desktop/imodule-extracted/web
pkill -f "apps/api/dist/server.js"
npx prettier --write .
(cd apps/api && npx tsc -p tsconfig.json --noEmit)     # expect 0
pnpm typecheck:tests                                    # expect 0
(cd apps/api && npx vitest run)                         # expect 1103 / 134
pnpm lint                                               # 519 files, 0 violations
pnpm docs:refs                                          # DOC_REFS_OK
pnpm type:parity                                        # 0 mismatches, empty baseline
pnpm register:check                                     # 198 unclassified
pnpm settings:parity                                    # 128/128
pnpm schema:readiness                                   # 145/145, 5231/5231
pnpm fresh:provision                                    # 172 tables, 1 allowed drift
node scripts/report-baselines.mjs                       # 254 unchanged — NEVER --write
node scripts/check-g5-parity.mjs                        # G5_RED, which is correct
```

### Committed and pushed

- **Phase 0 complete, 7 of 7.** Each item found a real defect the moment it existed — that is the recorded
  argument for building instruments before using them.
- **Families 1-3 closed**: sale (13 defects), scheme (6), cash+bank (12). Records in
  `docs/comparisons/family-0{1,2,3}-*.md`.
- **The `SIGN` fix** — 122 sites, 14 modules, fixed centrally.
- **Family 4 partial**: per-line fine legs, measured leg codes, `payoutLegs` taking codes from callers.

### Uncommitted (verified compiling and green as of the last successful run)

- `IT_CODE`/`IT_DESC` on metal Rojmel rows (`purchase.ts` passes `itemCode`/`itemName`; item query loads
  `IT_NAME`). Note the builder's field is **`itemName`**, not `itemDesc` — the optional-field type made the
  typo a silent no-op.
- `partyAmount` → outstanding rather than total.
- `apps/api/test/purchaseRojmel.test.ts` (4 tests, controls proven).
- A caller-level test in `purchase.lifecycle.db.test.ts` — **this is the one that guards the fix.**
- `parity-replay-purchase.mjs` seed corrections.
- `TECHNICAL-REFERENCE.md` pin bumped to 134.

**Last verified full suite: 1103 tests / 134 files, all green.** `purchase.ts` verified clean
(`partyAmount: round2` present, `totals.total` absent).

### Family 4 is NOT close to done

I repeatedly described it as "one test run from a commit." That was wrong and I want it corrected here. The
purchase comparison still shows:

- **99 field differences never examined**
- `OP_LDR` — desktop 1 row, web 0 (**missing**)
- `BILL_OS_DATA` — desktop 0, web 1 (**extra**)
- `LOT_DETL` — desktop 0, web 1 (**extra**)
- Kasar pair 18/19 measured but not wired
- Bank settlement codes unmeasured (absent from this dataset — deliberately left on the reserved-band
  fallback rather than assumed, following the `BANK PAY` lesson)
- `docs/comparisons/family-04-purchase.md` **not written** (flagged in three self-audits; genuinely
  outstanding)

---

## 8. What to do next, in order

1. **Commit the uncommitted work** with the family-04 record in the same commit.
2. **The `Next25` falsification check — before any new family.** The `SIGN` change is shipped across 14
   modules on one company's data. Three queries, ordered by what they cost if wrong:
   - Any `SIGN` outside `{+,-,blank}` in `AC_DATA`/`ROJ_MEL_DATA`? Falsifies the widest change.
   - Any book where `BOOK_SNAME` ≠ its vouchers' `VCH_TYPE`? Falsifies §3.7.
   - Do shared books' leg codes agree? Raises "that shop's codes" to "the software's codes."

   `Next25` holds **two companies** — if they disagree with each other, that is decisive without a third
   database. **Caveat:** `Next25` is sparse, so it will likely confirm config-driven rules and stay _silent_
   on voucher-shape rules. **Silence is not support.**

3. **The column-value audit.** One pass: for every low-cardinality character column, get its real value
   distribution; then find every literal the web assigns to that column; the set difference is a defect list
   **by construction**. `SIGN` was 122 wrong sites found _by luck_ during a voucher comparison. This finds
   that class deliberately. Must match field-exact and reason per column (trap 4). It cannot find wrong
   _choices within_ a correct alphabet — direction errors still need voucher comparison.
4. **Finish family 4** — the 99 field diffs and 3 structural gaps.
5. **Then remaining families.** I would **not** order by row volume as the plan does. Volume did not predict
   defects: family 2 was largest (2622 legs) and yielded 6; family 3 (522 legs) yielded 12; family 4 (92
   legs) yielded 5 including the widest defect in the project. What predicted defects was **structural
   novelty**. Suggested order:
   - **Karigar receipt (052)** — `karigar.ts` has **zero** `ROJ_MEL_DATA` occurrences. A missing day-book
     entry, not a wrong value. Derive the `11`/`01` guard from `Ac_Rojmel.cs:364` **before** coding.
   - **Contra/journal (017)** — the only family where both sides are arbitrary accounts. If
     `buildTransferLedger` encodes an assumption anywhere, it is here.
   - **Scheme adjust (076)** — family 2 explicitly **deferred** its balance comparison here. A known hole in
     a closed family.
   - Then rate cut (064), sales order (020), fine JV (078) — all reusing established shapes.
6. **Phase 2** — classify the 198 register items. This is also the only way to get a real denominator for
   progress.
7. **Phase 3.2 report data parity** — never attempted, and it is possible locally against `Live24`. Build
   a report-parity checker under `scripts/` (declared via `HTML-comment planned marker` in the plan). Shares the
   `Live24`→Postgres loader with Phase 5.

---

## 9. Open decisions — these need the owner, not an engineer

1. **89 sale vouchers are out of balance** (`ROF_AMT`). Reproduce or correct?
2. **The fine double-count when `PR_BILL_OS < 0`** — the desktop counts fine twice on leg types `01` and
   `13`. The web reproduces it deliberately, pinned by a test. Correcting it makes the web disagree with the
   business's existing books.
3. **Wholesale sale** — build or exclude? 18,007 lines of source, 38 real rows.
4. **Prior-year ledger detail** (`OP_LDR`) — scope?
5. **`TR_SALE_RTN_UAE`** — in scope?
6. **Which reports the business actually runs** — **unmeasurable from the data**; report execution is not
   logged. Someone must ask them.

### Resource that will otherwise become the schedule

**A Windows box with the desktop app + Crystal runtime.** Phase 3.3 (report _layout_ parity) cannot start
without it, and no Mac-side work substitutes. **Never claim Crystal layout parity without a PDF pair
captured on Windows.** Investigate GitHub Actions `windows-latest` as an alternative.

---

## 10. Honest assessment of completion

I was asked for a percentage and declined to give one, then was asked again. Here is the position with the
numbers behind it, so you can form your own estimate.

**What is done:** Phase 0 complete (7/7). 3 of 16 voucher families closed with 31 defects fixed; a 4th
partially. 1103 tests / 134 files. All gates green.

**What is not started:** Phase 2 — **0 of 198** register items classified. Phase 3.2 report data parity —
never run. Phase 3.3 report layout — blocked on hardware. UI/keyboard parity — unmeasured.

**Why a single number is misleading:**

- **The denominator is unknown.** 4 families compared, 12 not. Volume does not predict defect count, so 4
  samples do not extrapolate.
- **Scope of discovery is still widening, not narrowing.** At family 4 I found a defect spanning 122 sites
  across 14 modules that three prior families' comparisons had walked past. If that is still possible this
  late, the remaining work is not bounded by what is currently visible.
- **Every part inspected closely was substantially wrong.** A small fraction has been inspected closely.

If you need a planning number, treat **feature surface** and **behavioural correctness** as separate axes.
Feature surface is plausibly well advanced — 31 modules exist, 152 of 198 menu items are referenced somewhere
in web source. Behavioural correctness is demonstrably early: 3 of 16 families verified, and every one of
those three required 6-13 fixes to reach parity.

**The single cheapest thing that would convert this guess into an estimate** is classifying the 198 register
items (§8.6). It is roughly an hour of work against data that already exists, and it gives a real
denominator.

---

## 11. Standing caveat, to repeat in any assessment

Every rule in §3 was measured on **`Live24` — one company, one fiscal year.** The leg codes, the `SIGN`
alphabet, the `BILL_OS` condition, the key layouts, the Rojmel composition. These are, strictly, facts about
DHAKAN JEWELLERS' 2024-25 books.

`Next25` (NJ GOLD — two companies, two fiscal years, a different chart of accounts) is the cheapest available
test of which are facts about the _software_. It will not settle the voucher-shape rules, because it has too
few transactions. The only real remedy for that is a second transacting business, which is a question for the
owner.

Do not let a green test suite obscure this. The tests pin what was measured. What was measured came from one
book.
