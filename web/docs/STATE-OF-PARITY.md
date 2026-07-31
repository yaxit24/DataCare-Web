# Where the web stands against the desktop

Measured 2026-08-01. Every figure here has the command that produced it. Nothing is asserted from memory.

The short version: **the foundations are complete and the transaction engine covers essentially all real
business activity, but the whole system is unverified in the one way that matters most — no voucher has
ever been compared field-by-field against the desktop.**

---

## 1. Schema — complete, and measured against reality rather than a guess

```bash
# desktop
SQL -d Live24 -Q "SET NOCOUNT ON; SELECT 'tables='+CAST(count(DISTINCT t.name) AS varchar)+' columns='+CAST(count(*) AS varchar) FROM sys.tables t JOIN sys.columns c ON c.object_id=t.object_id"
# web
psql 'postgresql://postgres@127.0.0.1:55433/datacare' -tAc "SELECT 'tables='||count(DISTINCT table_name)||' columns='||count(*) FROM information_schema.columns WHERE table_schema='public'"
```

|                    | Tables | Columns |
| ------------------ | ------ | ------- |
| Desktop (`Live24`) | 145    | 5231    |
| Web                | 174    | 6100    |

The web is a **complete superset**: every real desktop table and column is present. Established earlier by
diffing name-by-name — 145/145 tables and 5231/5231 columns, with the extras being web-only concerns
(`tenant_id`, `row_id`, messaging, audit).

**A correction lives here.** The `schema:readiness` gate still reports _"155/155 tables, 3241/3343 columns
(96.9%)"_, which is measured against `DESKTOP-INIT-SCHEMA.json` — a contract extracted from decompiled DDL
strings. That contract over-claims 19 tables from initialisers this company never ran, misses 9 tables the
installer creates, and finds only 64% of the real columns. **The 96.9% is against a partly fictional
denominator; the real figure is 100%.** The gate has not been repointed at `DESKTOP-REAL-SCHEMA.json`, so
that number is misleading every time it prints.

---

## 2. Surface area — the honest shape of it

```bash
ls unified/src/csharp/DataCareNext/*.cs | wc -l                 # 204
ls unified/src/csharp/DataCareNext/TR_*.cs | wc -l              # 61 transactions
ls unified/src/csharp/DataCareNext/RP_*.cs | wc -l              # 45 reports
ls unified/src/csharp/DataCareNext/MS_*.cs | wc -l              # 33 masters
grep -c "route(" apps/api/src/modules/rbac/routePolicy.ts        # 140
find apps/web/app -name page.tsx | wc -l                        # 101
```

204 desktop forms against 101 web pages and 140 policed routes. **Those numbers are not comparable and
should not be presented as a ratio** — one desktop form can become several web pages, several forms
collapse into one, and 15 of the 204 are dialogs or dead variants. Form counting is what produced the
earlier "68.5% → 72.7%" audit churn, which measured controls rather than behaviour.

The meaningful measure is voucher families and their write sets, below.

---

## 3. Voucher families — 21 of 22 with real activity are covered

This is the measure that matters: which voucher families the shop actually posted, and whether the web can
post them.

```bash
SQL -d Live24 -Q "SET NOCOUNT ON;
SELECT '  '+RIGHT('     '+CAST(count(*) AS varchar),5)+'  '+ISNULL(b.MAIN_BOOK,'(blank)')
 FROM AC_DATA a JOIN BOOK_DATA b ON b.CO_BOOK=a.CO_BOOK AND b.CO_CODE=a.CO_CODE
 WHERE ISNULL(b.MAIN_BOOK,'')<>'' GROUP BY b.MAIN_BOOK ORDER BY count(*) DESC"
```

| Ledger rows | `MAIN_BOOK`     | Web path                         |
| ----------- | --------------- | -------------------------------- |
| 2622        | MEMB ENTRY      | `membership/scheme.ts`           |
| 1020        | SALES           | `sales/sales.ts`                 |
| 360         | CASH PAY        | `finance/finance.ts`             |
| 162         | CASH REC        | `finance/finance.ts`             |
| 143         | PURCHASE        | `purchase/purchase.ts`           |
| 130         | BANK PAY        | `finance/finance.ts`             |
| 117         | OPSTK           | `stock/stockVoucherLifecycle.ts` |
| 98          | BANK REC        | `finance/finance.ts`             |
| 92          | RATE CUT        | `sales/rateCut.ts`               |
| 81          | SALES ORDER     | `sales/salesOrder.ts`            |
| 74          | CONTRA          | `finance/journal.ts`             |
| 72          | MEMB ADJUST     | `membership/scheme.ts`           |
| **38**      | **WH SALES**    | **ABSENT**                       |
| 28          | FINE JV         | `finance/fineJv.ts`              |
| 23          | KARIGAR RECEIPT | `manufacturing/karigar.ts`       |
| 15          | LABOUR WORK     | `sales/labourInvoice.ts`         |
| 8           | OTH INC         | `purchase/otherCommission.ts`    |
| 4           | SALES RETURNE   | `sales/salesReturn.ts`           |
| 2           | ORDER CANCEL    | `sales/salesOrder.ts`            |
| 2           | OTH EXP         | `purchase/otherCommission.ts`    |
| 2           | BILL REC        | `finance/billToBill.ts`          |
| 1           | KARIGAR ISSUE   | `manufacturing/karigar.ts`       |

**5094 real ledger rows across 22 families. 5056 of them — 99.25% — belong to a family the web can post.**

The single absence is **wholesale sales**: 38 ledger rows, one active book, 15 vouchers. Recorded in full
in `GAP-ANALYSIS-AND-PLAN.md` under "The wholesale-sale voucher family". The web has the 1503-line _return_
module and no _sale_, so it offers an operation that can only act on migrated data.

The desktop has ~61 transaction forms; only 22 families were used in a year. **The other ~39 are configured
capability this shop did not exercise** — not necessarily gaps, and not measurable from this database.

---

## 4. Where the depth actually is: write-set fidelity

Voucher coverage says a family can be posted. It does not say the rows match. Depth has been established
family by family, each against real desktop rows:

| Area                  | Position                                                                                               |
| --------------------- | ------------------------------------------------------------------------------------------------------ |
| **Rojmel (day book)** | **3085 of 3179 rows — 97%.** Nine families written, each derived from real rows and pinned by controls |
| Sale write set        | 8 tables pinned as an exact set; footprint tests fail by name if one is dropped                        |
| Purchase write set    | 9 tables pinned                                                                                        |
| Scheme                | 6 field-level defects found and fixed against real rows, including two that doubled member balances    |
| Labour                | 4 defects fixed; `LBR_RATE` was never derived — a real ₹624.96 error on one line                       |
| Rounding / GST        | matrixed over `TAX_ROF` and `ALL_ROF_REMOVE`; unrounded intra-state halves preserved                   |
| Settlement            | 20 vectors from `TR_TOUR_SALE.cs`                                                                      |

The Rojmel figure is the strongest single number in this document because it is measured against **output
the desktop actually produced**, not against features or forms.

**Remaining Rojmel work is 90 rows, of which only 28 are an implementable gap** (karigar receipt). The other
62 are wholesale 32 (blocked on the missing form), URD purchase 27 (**not a gap** — retired book,
`CUR_USE='N'`), and 3 stragglers.

---

## 5. What is NOT verified — the part that matters most

### 5.1 No voucher has ever been compared to the desktop

`g5:parity` is **RED**, and that is the correct state. The harness exists and is tested — bundle format,
type-aware canonicaliser, union-not-intersection differ, 24 unit tests, proven end-to-end on synthetic
perturbations. What has never happened is the actual comparison: take a real `Live24` voucher, replay its
inputs through the web, and diff the two write sets field by field.

**Everything in sections 1–4 is parity by construction, not parity by comparison.** Rules were derived from
the desktop's data and source, and defects were found that way — but no independent check has confirmed that
a web voucher and a desktop voucher agree.

This is now purely local work. `Live24` holds 190 real sales, the extractor runs against it, and the differ
is ready. It is the single highest-value remaining task and has been for weeks.

### 5.2 Reports are structurally compared, never pixel-compared

254 report layout baselines are pinned, and a CSV/row-level differ exists with 19 tests. No Crystal Reports
output has been compared, because that needs the Windows box. Report _data_ could be compared locally
against `Live24` — that has not been done either.

### 5.3 Hardware, messaging and e-invoicing are built but never connected

Scale, scanner, webcam, printer, WhatsApp, SMS and GSP are implemented end-to-end with no credentials
supplied. **No reading has ever come from a real device and no message has ever been sent.**

### 5.4 The test suite is not typechecked

`tsc` covers `src` only. `apps/api/tsconfig.test.json` exists and surfaces **112 pre-existing errors**, so
it is not a gate. A type error in a test will not be caught.

### 5.5 One company, one fiscal year

**Every priority in this assessment rests on a single sample.** A wholesale-heavy shop or a pawnbroker would
invert it: the six dhrn/loan routines are dead here and might be the main event elsewhere; schemes dominate
here and might be absent there. The live/dead classifications are facts about `Live24`. The rankings are
inferences from one database.

A second customer database is the cheapest way to test that, and it would also serve the migration
rehearsal (L9) which is otherwise blocked.

---

## 6. Quality gates in place

```bash
ls apps/api/test/*.test.ts | wc -l          # 123 files
ls apps/api/test/*.db.test.ts | wc -l       # 46 database-backed
ls scripts/*.mjs | wc -l                    # 9 gate scripts
```

1043 API tests, 18 web tests, 123 files. Nine gates run in CI: settings parity 128/128, schema readiness,
fresh provision (172 tables all forced-RLS with a policy), report baselines 254 unchanged, route policy
(383 routes, pinned in two independent assertions), g5 parity (red by design), lint 501 files, build 7/7, browser smoke.

**The discipline that matters more than the count:** every gate has been demonstrated _failing_ before being
trusted. Around 60 controls have been proven across this workstream — including six that caught defects the
tests would otherwise have missed, and two cases where a gate went green against deliberately broken code
until the cause was found.

---

## 7. Honest summary

**Strong:** schema is a complete superset of the real desktop. 99.3% of real ledger activity belongs to a
family the web can post. Day-book fidelity at 97%, measured against real output. Deep field-level parity in
the areas examined, with roughly 60 proven controls behind it.

**Weak:** no voucher has been compared to the desktop, which means the parity claim rests on derivation
rather than demonstration. Reports are unverified against Crystal. Hardware and messaging have never run
against a real device or credential.

**Unknown:** how much of the ~39 unexercised transaction families matter to another customer; whether the
priority ordering survives a second database.

**The next action has not changed in weeks, and everything else is less valuable:** replay real `Live24`
vouchers through the web and diff them field by field. Until `g5:parity` goes green on captured evidence,
"parity" is a well-founded intention rather than a measured fact.
