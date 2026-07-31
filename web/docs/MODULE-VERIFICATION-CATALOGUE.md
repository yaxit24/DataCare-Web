# Module verification catalogue

**Purpose.** For each module, this gives the desktop authority, the tables involved, **the query that
measures whether it is faithful**, the tests that exist, and what remains unverified. Written to be usable
by a session with no prior context.

**Companion documents.** `ROJMEL-HANDBOOK.md` (method, environment, invariants, traps) ·
`STATE-OF-PARITY.md` (current position) · `GAP-ANALYSIS-AND-PLAN.md` (running findings and retractions).
Read the handbook's §1–§3 before using this catalogue; the environment set-up is not repeated here.

**Last measured:** 2026-08-01. Figures are from `Live24` — one company, one fiscal year 2024-2025.

---

## Part 1 — The five universal recipes

These answer "is this module faithful?" for **any** module. Learn them once; apply per module.

### R1 — What did the desktop actually produce?

```bash
SQL -d Live24 -Q "SET NOCOUNT ON;
SELECT '  '+RIGHT('      '+CAST(SUM(p.rows) AS varchar),6)+'  '+t.name
 FROM sys.tables t JOIN sys.partitions p ON p.object_id=t.object_id AND p.index_id IN (0,1)
 WHERE t.name IN (<the module's tables>) GROUP BY t.name HAVING SUM(p.rows)>0 ORDER BY SUM(p.rows) DESC"
```

**A table with zero rows is not a gap.** Roughly a third of the desktop's routines are dead for this
customer.

### R2 — Which columns are actually populated?

```bash
SQL -d Live24 -Q "SET NOCOUNT ON;
SELECT '  rows='+CAST(count(*) AS varchar)
 +'  <COL>='+CAST(SUM(CASE WHEN ISNULL(<COL>,0)<>0 THEN 1 ELSE 0 END) AS varchar)
 FROM <TABLE>"
```

**This is the step most often skipped, and it is the one that saves the most work.** `SL_ORD_ADJ` has 110
rows but `PAID_AMT` is non-zero on **1** — the routine reading it contributes ~1 row a year. Rate cut went
from 40 row types to 9 this way; sales order from 8 to 4.

### R3 — Does the web write the same tables?

```bash
python3 - <<'PY'
import re, pathlib
TARGET = '<TABLE>'
for p in pathlib.Path('apps/api/src').rglob('*.ts'):
    t = p.read_text()
    for pat in [rf"insertRowTx\(\s*tx\s*,\s*'{TARGET}'", rf"table:\s*'{TARGET}'", rf'INSERT INTO "{TARGET}"']:
        for m in re.finditer(pat, t):
            print(f"  {str(p).replace('apps/api/src/modules/','')}:{t[:m.start()].count(chr(10))+1}")
PY
```

**Must be multi-line aware.** A single-line grep requiring `{ table:` adjacent produced two false
findings that survived into four documents — the "15 unwritten tables" error and the retracted `KR_DETL`
gap. This codebase writes multi-line object literals.

Distinguish **write sites** from **delete lists**: a table name in a `WRITE_TABLES` array is reversal, not
writing.

### R4 — Who reads it? (settles whether it matters)

```bash
for f in $(grep -rl "<TABLE>" unified/src/csharp/DataCareNext/*.cs); do
  printf "  %-22s select=%-3s insert=%-3s delete=%s\n" "$(basename $f)" \
    "$(grep -c "FROM <TABLE>" $f)" "$(grep -c "INSERT INTO <TABLE>" $f)" "$(grep -c "DELETE FROM <TABLE>" $f)"
done
```

A table nothing reads is a lower priority than one a report depends on. This is how `OP_LDR` was correctly
reclassified (§3.9) and how the Rojmel's importance was established.

### R5 — Is the routine live or dead?

A routine named after a feature is **not** evidence it implements that feature. `Fine_CUT_Rojmel` looks
like the rate-cut routine; it reads `CUT_DATA`/`CUT_DETL`, both **0 rows**, and is dead here. Run R1 on the
tables a routine reads before implementing from it.

**The rule that survived all of this: source for what EXISTS, data for what RUNS.** Neither alone suffices —
sampling cannot enumerate code paths that never fired, and source cannot tell you which paths are live.

---

## Part 2 — Per-module catalogue

Modules ordered by real business volume. Each block: desktop authority · tables with real counts · what is
verified · what is not · the specific next measurement.

### 2.1 Membership / savings scheme — **the largest module by volume**

|         |                                                                                      |
| ------- | ------------------------------------------------------------------------------------ |
| Web     | `modules/membership/` 1245 lines · `modules/scheme/passbook.ts` 202                  |
| Desktop | `TR_MEMB_ENT.cs`, `TR_MEMB_ADJ.cs`, `Module_Schm.cs`, `MS_PRODUCT.cs`                |
| Tables  | `AD_OS` **8194** · `AD_DATA` **8160** · `AD_ADJ` 26 · `AD_MEMB` 877 · `AD_MAST` 4    |
| Books   | 074 Member Monthly Entry (2622 ledger rows) · 075 Opening · 076 Advance Adjust (72)  |
| Tests   | `scheme.test.ts` (8) · `salesFamilyLifecycle.db.test.ts` (scheme lifecycle + shapes) |

**Verified against real rows.** Six field-level defects found and fixed, each with a control:
`AD_DATA.TOT_AMT` and `AD_OS.MEMB_AMT` both held the amount where the desktop holds **0** — the second
would have **doubled every member balance** that read it; `AD_OS.LD_CODE` held the scheme liability where
the desktop holds the **receipt account**; the route forwarded 6 of 14 documented inputs; and the desktop's
entry is a **grid** (812 of 1428 vouchers carry more than one member, one carries 175) posting a **ledger
pair per line**.

`AD_OS` is a **signed movement ledger**, not an outstanding-with-consumption row: `MEMB_AMT` is 0 on all
8194 rows and the value lives in `ADJ_AMT`. Balance = `Σ(A+) − Σ(D−) − Σ(B−)`. `B−` is the **bonus**,
confirmed voucher-by-voucher against `AD_ADJ.MEMB_BONUS` (18000/18000, 42000/42000, …, summing to 222000
on both sides). `ADJ_AMT = MEMB_AMT + MEMB_BONUS − MEMB_LESS` holds on every row.

**Not verified.** No voucher compared field-by-field to the desktop. `SCHM_TYPE` is `'A'` on all four
schemes, so the gold-scheme paths (`ITM_RATE`, `GOLD_WT`, and five `Schm_Adj_RojMel` row types) are
**untested by data** — a gold-scheme customer would exercise code no evidence covers.

**Next measurement:** replay a real book-074 voucher and diff. Then check the passbook computes from
`AD_DATA`/`AD_OS` rather than from the ledger.

### 2.2 Sales

|         |                                                                                                         |
| ------- | ------------------------------------------------------------------------------------------------------- |
| Web     | `modules/sales/sales.ts` (largest single module) + 11 siblings, 9011 lines total                        |
| Desktop | `TR_SALE.cs`, `Ac_Ledr.Sales_Ledr`, `Ac_Rojmel.Sales_Rojmel`                                            |
| Tables  | `SL_DATA` 190 · `SL_DETL` 245 · `SL_IDTL` 103 · `TAX_DATA` 184 · `BILL_OS_DATA` 365 · `MAIN_STOCK` 1856 |
| Books   | 026/027/029/030 tax invoices, 032 estimate — 1020 ledger rows                                           |
| Tests   | `sales.lifecycle.db.test.ts` (18) · `sales.test.ts` · `desktopMessages.db.test.ts` · `goldenVectors`    |

**Verified.** Write set pinned as an **exact set** of 8 tables — a dropped write fails by name. Labour:
four defects fixed, `LBR_TYPE` is a weight **basis** not a pricing mode (`G` gross, `N` net, `K` per-1000,
`P` pieces), and `LBR_RATE` was never derived — a real **₹624.96** error on one line. `SL_AMT_TYPE`
matrixed over all five values. `TAX_ROF`/`ALL_ROF_REMOVE` matrixed, with unrounded intra-state halves
preserved in `CGST_TAX`/`SGST_TAX` (`double precision`, no scale).

Rojmel projection: 8 row types, 7 verified against real rows, round-off source-only and labelled.

**Not verified.** The comparison itself. Also `SL_DETL` has 245 rows across 190 sales — a mean of 1.3 lines
— so **multi-line and stone-heavy sales are thinly evidenced**.

**Next measurement:** book 027 voucher 00001 is the reference sale (2 lines, party 000888, `TOT_AMT`
1560.00). Replay and diff it — the bundle already exists.

### 2.3 Finance — cash, bank, contra, bill-to-bill, fine JV

|         |                                                                                                |
| ------- | ---------------------------------------------------------------------------------------------- |
| Web     | `modules/finance/` 18 files, 6042 lines                                                        |
| Desktop | `TR_CASH.cs`, `TR_CONTRA.cs`, `TR_BILL_TO.cs`, `TR_FN_INOUT.cs`                                |
| Tables  | `CASH_DATA` 335 · `CONTRA_DATA` 102 · `AC_DATA` 5150                                           |
| Books   | CASH PAY 360 · CASH REC 162 · BANK PAY 130 · BANK REC 98 · CONTRA 74 · FINE JV 28 · BILL REC 2 |
| Tests   | `financeLifecycle.db.test.ts` · `finance.test.ts` · `financeWriters.test.ts`                   |

**Verified.** The cash books use a **different Rojmel convention** from every other family: the row names
the cash account in `AC_CODE` but takes its debit/credit from the **party's** leg. Established only after
a row-type breakdown — the aggregate test gives 47.2% and 5.4%, which looked like an inconsistent desktop.
**Averaging across row types hid the rule and produced a confident wrong conclusion.**

Fine JV is the only wholly money-free family: `DR_AMT`, `CR_AMT` and `ITM_GWT` are zero on all 28 rows.

**Not verified.** Rojmel types `02`/`03` and `05`/`06` on the cash books (60 rows) — contra-style pairs for
a non-cash settlement leg inside a cash voucher, trigger not derived.

**Next measurement:** R2 on `CASH_DATA` for the columns those types read.

### 2.4 Purchase

|         |                                                                                      |
| ------- | ------------------------------------------------------------------------------------ |
| Web     | `modules/purchase/` 4 files, 3678 lines                                              |
| Desktop | `TR_PURC.cs`, `Ac_Rojmel.Purc_Rojmel` (line 115)                                     |
| Tables  | `PR_DATA` 74 · `PR_DETL` 103 · `BAR_DETL` 1329 · `BAR_IDTL` 943 · `LOT_DETL`         |
| Tests   | `purchase.lifecycle.db.test.ts` (15) · `purchase.test.ts` · `purchaseReturn.test.ts` |

**Verified.** Write set pinned as an exact set of 9 tables — richer than a sale because a purchase
**creates** stock. Rojmel is the inward mirror: `SIGN '+'`, confirmed by book (035/037 gold → `G` `+`,
036/038 silver → `S` `+`). `LBR_RATE` derivation fixed here too.

**Not verified.** `Purc_Rtn_Rojmel` and `Item_Pr_Rojmel` — same tables, different routines, not
implemented. `BAR_DETL.KR_NAME` is `varchar(5)`, a karigar **code** not a name.

### 2.5 Stock and tags

|         |                                                                                                                     |
| ------- | ------------------------------------------------------------------------------------------------------------------- |
| Web     | `modules/stock/` 8 files, 4399 lines                                                                                |
| Desktop | `TR_INOUT.cs`, `TR_TAG_SPLIT.cs`, `TR_TAG_WT_DIFF.cs`, opening stock                                                |
| Tables  | `MAIN_STOCK` 1856 · `BAR_DETL` 1329 · `SRNO_MAST` 2108                                                              |
| Books   | OPSTK 117 ledger rows                                                                                               |
| Tests   | `stockLifecycle.db.test.ts` · `physicalStock.db.test.ts` · `tagPrintStaging.db.test.ts` · `tagLabelSkip.db.test.ts` |

**Verified.** Tag issue serialised so concurrent sales cannot double-issue (`transaction.integrity.db`).
`MAIN_STOCK.ITM_NWT/ITM_PCS/ITM_MRP` are **numeric** while `AC_DATA.DR_AMT/CR_AMT` are the opposite
convention — a real schema trap. `SRNO_MAST` is unique on `(tenant_id, CO_CODE, LC_CODE)` — a counter, not
a per-tag registry.

**Not verified.** `Stk_InOut_Rojmel` reads `INOUT_DETL`, **0 rows** — dead here. `BAL_GR` is **read** by
`closingStock.ts` and has only 5 real rows; whether the web populates it correctly is unmeasured, so the
balance sheet's non-metal leg is thinly evidenced.

### 2.6 Manufacturing / karigar

|         |                                                                                          |
| ------- | ---------------------------------------------------------------------------------------- |
| Web     | `modules/manufacturing/` 6 files, 4016 lines                                             |
| Desktop | `TR_KR_ISU.cs`, `TR_JDT_REC.cs`, `Ac_Rojmel.Kr_Isu_Rojmel` / `Kr_Rec_Rojmel` (348 / 364) |
| Tables  | `KR_DATA` 17 · `KR_DETL` 22 · `KR_IDTL` 8                                                |
| Books   | KARIGAR RECEIPT 23 ledger rows · KARIGAR ISSUE 1                                         |
| Tests   | `mfgLifecycle.db.test.ts` · `karigar.test.ts` · `melting*.test.ts`                       |

**Verified.** All three tables **are** written — six sites across three paths. ⚠️ **A previously recorded
"`KR_DETL` write gap" was a FALSE POSITIVE and is retracted**; see `GAP-ANALYSIS-AND-PLAN.md`. It came from
the defective single-line grep, and `mfgLifecycle.db.test.ts` already asserts the detail rows exist.

**Not verified.** The Rojmel — book 052 has 28 rows in 4 types (`11` 21 rows fine+gross, `01` 3 rows gross
only, `02`/`05` money headers). **The `11`/`01` split must be derived from the source before coding**: both
are `G` `+` per-line money-free rows differing only in whether fine is present.

**This is the last implementable Rojmel gap.** Plan: `PLAN-ROJMEL-FINAL-THREE.md` §2.

### 2.7 Rate cut / wholesale

|         |                                                                                  |
| ------- | -------------------------------------------------------------------------------- |
| Web     | `modules/sales/rateCut.ts` 738 lines · `wholesaleSaleReturn.ts` 1503             |
| Desktop | `TR_WH_SALE.cs` **18,007 lines** · `Ac_Rojmel.Wh_Sales_Rojmel` (221)             |
| Tables  | `RATE_CUT_DATA` 40 · `RATE_CUT_ISU` 20 · `RATE_CUT_REC` 2 · `RATE_CUT_ISU_REC` 7 |
| Books   | RATE CUT 92 ledger rows · WH SALES 38                                            |

**Verified.** Rate cut Rojmel: 9 live types of 40+, each matched to a non-zero source column. The source
had debit/credit **reversed on five of nine** — the data is authoritative. The desktop **double-counts
fine** on an overpaid purchase (`PR_BILL_OS < 0` writes it on both types `01` and `13`, verified on both
occurrences); reproduced deliberately for parity and pinned by a test. **Changing that needs an owner
decision.**

**Not verified — and this is a form-level gap.** The web has **no wholesale-sale path**. Only the return
exists, so it offers an operation that can act on migrated data only. Full record in
`GAP-ANALYSIS-AND-PLAN.md` under "The wholesale-sale voucher family".

### 2.8 Reports

|         |                                                                          |
| ------- | ------------------------------------------------------------------------ |
| Web     | `modules/reports/` 26 files, 5387 lines · **48** registered report slugs |
| Desktop | 45 `RP_*.cs` forms; `RP_ROJMEL.cs` alone is 5856 lines                   |
| Tests   | 11 report test files · 254 pinned layout baselines                       |

**Verified.** 254 layout baselines unchanged across every run. CSV export for every registered report with formula
injection neutralised. A CSV/row-level differ (`reportDiff.ts`, 19 tests) that publishes what it skipped and
**refuses a row-level verdict on an incomplete mapping**. Shared filter matrix refused (400) unless the
report's binding honours it. `rojmelReport.ts` reads the day book and its gold/silver fine buckets are
non-zero for the first time.

**Not verified.** **No Crystal output has ever been compared** — needs the Windows box. Report _data_ could
be compared locally against `Live24` and has not been. `RP_ROJMEL`'s per-voucher narration (which reaches
into `CASH_DATA`, `CARD_DATA`, `AD_DATA`+`AD_MEMB`, `KR_DATA`) is not reproduced — deliberately, since
inventing it would be inventing content.

### 2.9 Year-end and opening balances — **a correction lives here**

|         |                                                                        |
| ------- | ---------------------------------------------------------------------- |
| Web     | `modules/ops/yearEnd.ts` 280 lines                                     |
| Desktop | `UT_IMPORT.cs`, `BtmSchm.cs` (write) · **`RP_LEDR.cs` (reads it 10×)** |
| Tables  | `OP_LDR` **7011**                                                      |

**A gap I recorded earlier was wrong.** I had `OP_LDR` as "written per voucher across 35 books, and the web
writes it from one config surface only". Measured properly:

- `OP_LDR.CO_YEAR` is **2024-2025** while its `VCH_DATE` spans **2023-03-31 to 2024-03-31** — the _prior_
  year. It is a **year-end carry-forward snapshot**, exactly as "OP" implies.
- Only **2 INSERT sites** exist in the whole desktop source, one of them the _import_ utility. It is not a
  posting target.
- Of its 3801 `(book, voucher)` pairs, only 1390 appear in this year's `AC_DATA` — the rest are last
  year's.

So the web is **not** wrong to skip it per voucher. `ops/yearEnd.ts` does carry balances forward,
idempotently, as `AC_DATA` legs with `VCH_TYPE 'ACOP'`.

**The genuine open question is narrower and testable:** `RP_LEDR.cs` reads `OP_LDR` **ten times** for the
account ledger's opening balance. The web's `accountLedger` must derive an equivalent opening from the
`ACOP` rows. **Whether the two agree has never been checked.**

**Next measurement:** pick an account with prior-year activity, compute its opening from `OP_LDR`, compute
the web's from `ACOP`, compare. This is a small, high-value check.

### 2.10 Settings and behaviour

|         |                                                                                      |
| ------- | ------------------------------------------------------------------------------------ |
| Web     | `modules/settings/` 3 files, 1933 lines · `shared/settingsBehavior.ts`               |
| Desktop | `CO_SET`, `CO_SET_NEW`                                                               |
| Tests   | `settings.db.test.ts` · `settingsBehavior.db.test.ts` · `companySettings.db.test.ts` |

**Verified.** `settings:parity` **128/128 (100%)** — every desktop setting is surfaced. `CO_SET_NEW` was
entirely unreachable at one point, hiding `PROFIT_RPT_TYPE` among others. Two settings have full behaviour
matrices (`SL_AMT_TYPE` over five values; `TAX_ROF` + `ALL_ROF_REMOVE`).

**Not verified.** **37 of 39 behaviour settings have no matrix** — they are surfaced and loaded, but no test
proves each changes the persisted result. Named next: `PR_AMT_TYPE`, the remaining `*_ROF` decimals,
`FINE_STK_TYPE`, `STK_RPT_TYPE`, `PURC_WITH_LBR`, `CO_STK_MERGE`.

**This is the largest well-defined block of unverified behaviour in the system.**

### 2.11 Dhrn / loans — dead here, do not build on spec

| Tables | `DHRN_ISU_DATA` **0** · `DHRN_REC_DATA` **0**                  |
| ------ | -------------------------------------------------------------- |
| Web    | `modules/dhrn/` 3 files, 1139 lines · `dhrnReceipt.db.test.ts` |

Six `Ac_Rojmel` routines — the largest single block in that file — and **all six are dead** for this
customer. The web has a module anyway. **Any further work here should wait for a customer database that
shows usage**; a pawnbroker would make this the main event.

### 2.12 Repair, VP, card adjust, employee JV — also dead here

`REP_DATA` **0** · `CARD_DATA` **0** · `VP_ADJ_DATA` **0** · `EMP_DATA` **0** · `MFG_DATA` **0**

The web writes the Rojmel from **six paths this customer never used** — location amount, VP adjustment and
the four repair paths — while four it does use were missing until this workstream. **Effort followed the
code rather than the business.** Three instances of that pattern are now recorded, which makes it a tendency.

### 2.13 Auth, RBAC, tenancy — infrastructure

|       |                                                                                       |
| ----- | ------------------------------------------------------------------------------------- |
| Web   | `modules/auth/` 6 files · `modules/rbac/` 6 files, 1702 lines                         |
| Tests | `auth.*` (4 files) · `rbac.*` (2) · `app.security.db.test.ts` · `routePolicy.test.ts` |

**Verified.** Route policy is **static analysis** of literal route strings — 383 routes pinned in two
independent assertions; an unpoliced registered route hard-500s, forcing every route into the policy. Forced
RLS with a policy on all **172** tenant-scoped tables, asserted on a **freshly provisioned** database, not
just the working one. A real cross-tenant leak was found and fixed in `message_attempt_log`, where two
queries filtered on `idempotency_key` alone and relied on RLS.

**Not verified.** No penetration testing. No load testing beyond a `g6-load-profile` fixture.

---

## Part 3 — Cross-cutting verification assets

| Asset                                  | What it does                        | State                                                                                                                                                                                                                                               |
| -------------------------------------- | ----------------------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `scripts/check-settings-parity.mjs`    | every `CO_SET` field surfaced       | **128/128**                                                                                                                                                                                                                                         |
| `scripts/check-schema-readiness.mjs`   | schema against a contract           | **prints a misleading 96.9%** — measured against `DESKTOP-INIT-SCHEMA.json`, which over-claims 19 tables and finds 64% of real columns. Real figure is **100%** against `DESKTOP-REAL-SCHEMA.json`. **Repointing this is a small, high-value fix.** |
| `scripts/check-fresh-provision.mjs`    | RLS forced + policy on a scratch DB | 172 tables, 1 allowed drift                                                                                                                                                                                                                         |
| `scripts/report-baselines.mjs`         | 254 layout snapshots                | unchanged                                                                                                                                                                                                                                           |
| `scripts/check-g5-parity.mjs`          | desktop-vs-web voucher diff         | **RED — no comparison ever captured**                                                                                                                                                                                                               |
| `integration/parity-extract-mssql.mjs` | read-only desktop extract           | works against `Live24`                                                                                                                                                                                                                              |
| `integration/parity-extract-pg.mjs`    | same bundle from Postgres           | ready                                                                                                                                                                                                                                               |
| `integration/parity-compare.mjs`       | the differ                          | 24 unit tests, union-not-intersection                                                                                                                                                                                                               |
| `test/support/footprint.ts`            | write-set probe, schema-driven      | ⚠️ expects an **owner** client; its `.catch(() => [{n:0}])` turns a blocked read into a **zero**, so an RLS-bound client reports an **empty footprint rather than failing**                                                                         |

---

## Part 4 — What is unverified, ranked by value

1. **No voucher has ever been compared to the desktop.** Everything is parity by _construction_. The
   harness is ready, `Live24` has 190 real sales, and this has been the top item for weeks.
2. **37 of 39 behaviour settings have no matrix** — the largest well-defined block of unproven behaviour.
3. **The ledger's opening balance** (§2.9) — small, testable, and it is what `RP_LEDR` uses `OP_LDR` for.
4. **Report data never compared**, even locally, though `Live24` makes it possible without Crystal.
5. **`schema:readiness` prints a misleading number** every run.
6. **The test suite is not typechecked** — 112 pre-existing errors in `tsconfig.test.json`, so it is not a
   gate.
7. **Hardware and messaging never connected** to a real device or credential.
8. **One company, one year.** Every ranking here is an inference from a single sample; the live/dead
   classifications are facts about `Live24` only.

## Part 5 — Standing rules

1. A gate is not trusted until **demonstrated failing**. ~60 controls proven so far.
2. Footprints asserted as an **exact set** (`toEqual`), never `toContain` — a subset cannot see an extra
   write, which is how a duplicate posting appears.
3. **Never put `vitest run` and `git commit` in one shell block.** Three commits went out on a red suite
   because the commit had already run before the output could be read.
4. **Assert that string replacements landed.** Prettier reflows files; an exact-match `replace()` can
   silently no-op and report success. This produced a doc claiming an implemented feature was missing.
5. When a count is unexpectedly **zero, suspect the tenant context** before the code. RLS returns zero rows
   with no error.
6. A retracted **method** leaves behind conclusions drawn with it. Re-check them individually — the
   `KR_DETL` false positive survived a headline correction by exactly that route.
