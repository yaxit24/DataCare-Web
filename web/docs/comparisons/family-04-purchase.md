# Family 4 — Purchase (books 035, 036)

**Status: IN PROGRESS — not closed.** Five defects fixed. 99 field differences and three structural gaps
remain unexamined. Measured on `Live24` (DHAKAN JEWELLERS, FY 2024-25), 92 real ledger rows across the two
books.

Method per the plan: count real rows per book grouped by leg type → count source columns → read source for
structure only → take directions from data.

---

## 1. Measured leg codes

```
01 party      Cr   (17)   the bill — the sale's shape with directions inverted
03 purchase   Dr   (17)   00008 gold / 00009 silver
06 tax 00085  Dr    (2)
16 party Dr / 17 cash Cr        (5)   paying the supplier
18 party Dr / 19 kasar 00042 Cr (2)   book 036 only
21 fine legs       (42)   weight only — IT_TYPE 'G', SIGN '+', DR_AMT = CR_AMT = 0
```

Reference voucher **035/00001**, a cash purchase — four legs, all 23-character keys:

```
[01002024-20250350000101]  ac 000903  ld 00008   Cr 6780.00   party
[01002024-20250350000103]  ac 00008   ld 000903  Dr 6780.00   purchase
[01002024-20250350000116]  ac 000903  ld 00001   Dr 6780.00   settlement, party
[01002024-20250350000117]  ac 00001   ld 000903  Cr 6780.00   settlement, cash
```

Two self-balanced pairs — the bill and the payment — the same shape the cash books use.

Reference voucher **035/00004**, an unfixed purchase: three lines with rate 0 and amount 0, producing three
type-21 fine legs and **no money legs at all**. Metal received, price not yet agreed.

---

## 2. Finding: one table uses TWO key layouts, chosen by leg type

Money legs are 23 characters with the leg type at 22-23. The type-21 fine legs are **33** with `<line><leg>`
right-aligned in 12 — the **cash books' shape**, inside a purchase book:

```
[01002024-202503500004         121]  fine 12.712
[01002024-202503500004         221]  fine 11.950
[01002024-202503500004         321]  fine  3.950
```

Previously recorded: two layouts within one voucher across two _tables_ (cash ledger vs cash Rojmel). This is
two within **one table**. `legKeySuffix` absorbs it only because that mechanism is per-**row** rather than
per-family — a choice that was defensive when made and is load-bearing now.

Four distinct tail layouts are now confirmed across the project, and no two agree.

---

## 3. Finding: `VCH_TYPE` = `BOOK_DATA.BOOK_SNAME`

Confirmed both ways. **Source:** `TR_PURC.cs:13093` and five sibling rows assign
`dataRow["VCH_TYPE"] = FormBookSname`. **Data:** `VCH_TYPE` equals `BOOK_SNAME` on **39 of 40 books** — 035
`FGPR`, 036 `FSPR`, 026 `TGSL`, 027 `TSSL`, 032 `MIXSL`, 014 `BBPAY`. The one exception is book 000 opening
stock (`OPSTK` vs `ACOP`), which no transaction form writes.

`bookPolicy.ts:84` already did this correctly.

### An abandoned path

Time was spent inferring a **formula** from `BOOK_TYPE` + `ITM_TYPE` — 026 T+G→`TGSL`, 035 F+G→`FGPR`,
032 M+A→`MIXSL`. The fit was real but coincidental: those strings are simply what someone **named** the books.
Book 014's `BBPAY`, which breaks any formula while its `BANK PAY` siblings 010/012/013 are `BPAY`, was never
an anomaly.

Had the formula been implemented, books 000 and 014 would both be wrong, and so would every book the business
creates in future. `BOOK_VCH_TYPE` is **not** the source — it holds `NU` or blank.

### A false defect, caused by the fixture

The comparison first reported `VCH_TYPE` desktop `FGPR` vs web `PURC` across four tables, which looked like a
systematic web defect. It was **the replay's own seed** — it seeded `BOOK_SNAME='PURC'`. Likewise
`IT_NAME='FINE GOLD 999'` against the real `'FINE GOLD'`.

**A replay's seed must mirror the real master data, or the diff measures the fixture rather than the code.**

---

## 4. Finding: leg codes are per-book even for identical roles

Purchase tax is `06`; the sale's tax is `04`. Same role, different number. Third independent confirmation,
after the cash/bank split (`BANK REC` 05/06 is bank charges where `CASH PAY` 05/06 is party/cash) and the
receipt/payment split (01-04 vs 05-08).

**Consequence:** `payoutLegs` in `finance/tender.ts` now takes its leg codes from the **caller**. Four
different pairs are known for the same settlement role — purchase 16/17, sale cash 19/20, sale bank 09/10,
cash-book payment 05/06. Defaulting any one would have been a guess on three other callers' behalf. A caller
that has not measured its codes omits them and keeps the reserved `50 + srno` band, which is visibly not a
desktop code.

Passed for purchase: the cash settlement pair 16/17 only. The bank pair is **not** passed — no bank
settlement exists in this dataset — and book 036's kasar pair 18/19 is measured but not yet wired. Both stay
on the fallback rather than being assumed, following the `BANK PAY` lesson from family 3.

---

## 5. Defects fixed

| #   | Defect                                         | Evidence                                                                                                           | Control                                                                       |
| --- | ---------------------------------------------- | ------------------------------------------------------------------------------------------------------------------ | ----------------------------------------------------------------------------- |
| 1   | Fine legs aggregated by `metal\|account`       | Voucher 00004's three lines (12.712, 11.950, 3.950 — all gold, all account 00008) collapsed into one leg of 28.612 | `expected [...] to have a length of 3 but got 1`                              |
| 2   | No leg codes on money legs                     | Positional fallback instead of measured 01/03/06                                                                   | `expected undefined to be 1`                                                  |
| 3   | `payoutLegs` could not carry per-book codes    | Settlement pair fell to the fallback                                                                               | covered by #2                                                                 |
| 4   | `IT_CODE`/`IT_DESC` blank on metal Rojmel rows | 240 real metal rows carry both, 0 blank; 466 money rows blank, 0 set                                               | `expected '' to be '999'`                                                     |
| 5   | Rojmel party row written unconditionally       | Caller passed `totals.total` into an argument the builder treats as _outstanding_                                  | `expected [ { AC_CODE: 'SUPP', dr: '0', cr: '1030' } ] to have a length of 0` |

Defect 1 is the **third** occurrence of aggregate-instead-of-per-line, after the multi-line cash payment and
the multi-line cash receipt. The whole suite passed before and after the fix, so no test asserted the leg
count.

### Defect 5 needed a caller-level control

The shared builder's own guard was **always correct**. Four unit tests against `buildSaleRojmel` pass whether
or not the caller regresses — so they proved nothing about the actual fix. Only a test through
`createPurchase` catches it, and that test lives in `purchase.lifecycle.db.test.ts`.

**A control must exercise the layer that was changed.** This is the same class as a control that fails for
the wrong reason.

### Two defects in the test, not the product

The caller-level test failed three times, and all three were mine:

1. `taxRatePct: 0` against a fixture that seeds no zero-rate master → `tax rate is not configured: 0`. (The
   real database _does_ have one — `TAX_MAST` code `'00'`, "TAX FREE", `TAX_PRC` 0.00, used by **57 of 190
   sales** — but the fixture does not.) Settled at the fixture's 3% instead.
2. Comparing varchar `VCH_NO` to a numeric `created.vchNo` → Postgres `42883`. Fixed with
   `lpad($n::text,5,'0')`.
3. **The assertion itself was wrong.** After both fixes the test still returned two rows, and three rounds
   were spent treating that as harness plumbing. A diagnostic settled it:

   ```
   header: BILL_OS 0, TOT_AMT 1030, CASH_AMT 1030, KASAR 0
   rojmel: PURCAC  IT_CODE 'LOOSE'  dr 1000   ← metal line row
           GSTLED  IT_CODE ''       dr   30   ← TAX row, 3% of 1000
   ```

   The fix **works** — `BILL_OS` is 0 and no party row exists. The second row is the tax row, which is
   correct. Settling at 3% to dodge the absent zero-rate master necessarily produces a tax row, so a total
   count of 1 was never the right expectation.

   The assertion now states the rule — the party account appears on **no** row when nothing is outstanding —
   rather than a row count that holds only for one tender shape. **Lesson: the expectation deserved the same
   scrutiny as the code.** Assuming the product is right and the test is wrong is as much a bias as the
   reverse.

---

## 6. A negative result

The purchase path does **not** have the placeholder-account defect. It already resolves `BOOK_DETL` slots 1, 2
and 3 through `resolveBookAccountTx`, unlike all five `finance.ts` entry points.

Recorded deliberately: five occurrences in one module made that defect look systemic across the codebase. It
was systemic _within that module_. **First time a pattern found in one family has not generalised**, which
corrects the inference drawn from families 1-3.

---

## 7. Retraction: the desktop is not inconsistent here

Vouchers 035/00001 and 035/00003 were recorded as evidence of desktop inconsistency — same book, same year,
both single-line cash purchases, 1 versus 3 Rojmel rows.

**Wrong.** The discriminator is `BILL_OS`, already measured during family 1 and written into `rojmel.ts`: of
47 sales with `BILL_OS = 0`, **zero** carry a party row; of 42 with `BILL_OS ≠ 0`, **all 42** do. Voucher
00001 pays 6780.00 against a 6780.00 bill — nothing outstanding, so no party row.

**Method error:** the two vouchers were compared on line count and tender without checking the column that
governs the behaviour — in a file that already contained the rule. "The desktop is inconsistent here" is the
most expensive wrong conclusion available, because it terminates investigation and invites an invented rule in
place of a measured one. Treat it as a claim needing _more_ evidence than any other, not less.

---

## 8. Also produced by this family: the `SIGN` defect

The purchase comparison surfaced `AC_DATA.SIGN` desktop blank vs web `C`/`D`. Measured across every table in
`Live24` with a `SIGN` column — **11,548 rows** — `C` and `D` appear **nowhere**. **122 web sites across 14
modules** were wrong. Fixed centrally in `enrichLedgerLine`. Full detail in `HANDOFF.md` §3.6.

Recorded here because it is the strongest argument for the comparison method: three prior families had
compared `AC_DATA` — family 1 compared 672 fields of it — and all three walked past this column.

---

## 9. Exit criteria — NOT met

| Criterion                                                             | State                                                    |
| --------------------------------------------------------------------- | -------------------------------------------------------- |
| Leg codes measured and applied                                        | ✅                                                       |
| Key layouts measured and reproduced                                   | ✅                                                       |
| `AC_DATA` matches (4 rows, 0 field diffs)                             | ✅                                                       |
| `MAIN_STOCK`, `PR_DATA`, `PR_DETL`, `TEMP_BOOK_DATA` row counts match | ✅                                                       |
| Controls proven for every fix                                         | ✅                                                       |
| `ROJ_MEL_DATA` matches                                                | ⚠️ one row after the fix, but not re-compared end to end |
| **99 field differences examined**                                     | ❌ **never looked at**                                   |
| `OP_LDR` — desktop 1, web 0                                           | ❌ **missing**                                           |
| `BILL_OS_DATA` — desktop 0, web 1                                     | ❌ **extra**                                             |
| `LOT_DETL` — desktop 0, web 1                                         | ❌ **extra**                                             |
| Kasar pair 18/19 wired                                                | ❌ measured, not wired                                   |
| Bank settlement codes                                                 | ⚠️ absent from dataset — deliberately not assumed        |
| Unfixed-purchase path replayed                                        | ❌ voucher 00004 covered by unit test only               |

**This family was repeatedly described as "one test run from a commit." That was wrong** and is corrected
here. Four structural items and 99 field differences remain.

---

## 10. Open for the owner

**The fine double-count when `PR_BILL_OS < 0`** — the desktop counts fine twice on leg types `01` and `13`.
The web reproduces this deliberately, pinned by a test, because parity means matching the desktop rather than
correcting it. Changing it makes the web disagree with the business's existing books. **Owner decision.**

---

## 11. Standing caveat

Every figure here comes from one company and one fiscal year. The leg codes, the key layouts and the
`BILL_OS` rule are facts about `Live24`. `Next25` (NJ GOLD — two companies, two fiscal years, a different
chart of accounts) is the cheapest available test of which are facts about the software instead — and being
sparse, it will confirm config-driven rules while staying silent on voucher-shape rules. Silence is not
support.
