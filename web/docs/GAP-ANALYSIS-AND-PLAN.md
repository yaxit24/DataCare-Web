# Gap analysis and implementation plan: making the web a replica of the desktop

Derived from the **real DataCareNext database** (`Next24.mdf`, backed up 2025-04-21 from
`DESKTOP-IIGOT35\SQLEXPRESS`), restored locally on SQL Server 2022. Not from the decompiled source.

That distinction is the point of this document. Reading the decompiled source tells you what the desktop _can_
do. Reading its data tells you what it _does_, how often, and therefore what matters. Several of the gaps below
were invisible for weeks of source analysis and obvious within minutes of the data.

---

## The usage profile: what this business actually does

Every book with ledger activity, by volume. This is the priority order, and it is not the order anyone would
have guessed:

| #   | Desktop form                  | Book | Writes          | Ledger rows | Web writes that table? |
| --- | ----------------------------- | ---- | --------------- | ----------- | ---------------------- |
| 1   | **Member Monthly Entry**      | 074  | `AD_DATA`       | **2622**    | **NO**                 |
| 2   | Estimate                      | 032  | `SL_DATA`       | 537         | yes                    |
| 3   | Cash Payment                  | 002  | `CASH_DATA`     | 360         | yes                    |
| 4   | Gold Tax Invoice (old)        | 026  | `SL_DATA`       | 303         | yes                    |
| 5   | Cash Received                 | 001  | `CASH_DATA`     | 162         | yes                    |
| 6   | Silver Tax Invoice (old)      | 027  | `SL_DATA`       | 145         | yes                    |
| 7   | Opening Stock                 | 000  | `BAR_DATA`      | 117         | yes                    |
| 8   | Rate Cut / Fine issue-receipt | 064  | `RATE_CUT_DATA` | 92          | yes                    |
| 9   | Sales Order                   | 020  | `SL_ORD_DATA`   | 81          | yes                    |
| 10  | Contra Entry                  | 017  | `CONTRA_DATA`   | 74          | yes                    |
| 11  | **Member Advance Adjust**     | 076  | `AD_ADJ`        | **72**      | **NO**                 |
| 12  | Gold Purchase                 | 035  | `PR_DATA`       | 67          | yes                    |

**The most-used form in the business, by a factor of five, writes a table the web cannot write.** So does #11.

Row counts reinforce it — the two largest tables in the entire database are the scheme's:

    AD_OS   8194      AD_DATA 8160      OP_LDR 7011      AC_DATA 5150
    ROJ_MEL_DATA 3179 MAIN_STOCK 1856   BAR_DETL 1329    AC_MAST 918   AD_MEMB 877

---

## CORRECTION (2026-07-31): Gap A was overstated — 3 tables, not 15

The first version of this document claimed 15 populated desktop tables had no write path in the web. **The
real number is 3.** The detection was wrong: it required `{ table: '…'` on a single line, and this codebase
writes multi-line object literals, so it missed every write of that form.

Re-run with a multi-line-aware scan, the tables with **no write path anywhere** are:

| Table          | Real rows | Status                        |
| -------------- | --------- | ----------------------------- |
| `COUNTRY_MAST` | 151       | referenced nowhere in the web |
| `REM_DATA`     | 15        | referenced nowhere            |
| `IMAGE_DATA`   | 4         | referenced nowhere            |

`AD_DATA`, `AD_OS`, `AD_ADJ`, `AD_MAST`, `BAL_GR`, `KR_DETL`, `KR_IDTL`, `COL_MAST` and `UPI_DATA` **all have
write paths**. The scheme module in particular already carried `OS_TYPE: 'A'` with a comment predicting `'D'`
for redemption — exactly what the real data shows.

So the scheme gap was never "no write path". It was **field-level fidelity**, which is a subtler problem and
would not have been found by counting tables at all. What was actually wrong, each verified against every real
row rather than a sample:

- `AD_DATA.TOT_AMT` held the amount; it is **0 on all 8160 real rows**. Double-counted in any report summing it.
- `AD_OS.MEMB_AMT` held the amount; it is **0 on all 8194 real rows**. The value lives in `ADJ_AMT` alone, so
  every member balance reading `MEMB_AMT` would have doubled.
- `AD_OS.LD_CODE` held the scheme liability; the desktop stores **the account the money arrived in**
  (`00001` CASH ON HAND 7162 times, `000754` OLD AXIS BANK 714, `000418` OLD HDFC 163).
- The route forwarded **6 of 14** documented inputs, so `BANK_NAME`, `EMP_CODE`, `MONTH_CODE` and `WITH_UPI`
  could not be populated over the API at all.
- The desktop's member entry is a **grid** — 812 of 1428 real vouchers carry more than one member, one carries
  175 — and it posts a **ledger pair per line** (11 members → 22 legs). The web posted one member per voucher.

All six are fixed, each with a control proven failing first. `KR_DETL`/`KR_IDTL` and `BAL_GR` still need the
same field-level treatment; having a write path says nothing about whether it writes the right values.

**The lesson, recorded because it cost real work:** a table-level inventory answers "does anything write here",
which is almost never the question. The question is "does it write what the desktop writes", and only a
field-by-field comparison against real data answers it.

## Gap B — write path exists, but not on the paths that matter

| Table          | Real rows | Written by the web from                                                              | Missing from                                                          |
| -------------- | --------- | ------------------------------------------------------------------------------------ | --------------------------------------------------------------------- |
| `ROJ_MEL_DATA` | 3179      | VP parcel, wholesale return, other-commission, location-amount, gold book, VP adjust | **sale, purchase, cash, contra** — the desktop writes 4 rows per sale |
| `OP_LDR`       | 7011      | `configTables.ts` only (a config surface)                                            | every voucher path; the desktop writes 2 rows per sale                |

The Rojmel is not a ledger copy. `IT_TYPE` is the **metal** — `G` gold (335 real rows), `S` silver (130), `O`
other (3), `A` a money row (2711) — metal rows carry pieces and gross weight, and `SIGN` gives direction (`-`
out, `+` in). Confirmed by book: Gold Tax Invoice → `G`, Silver Tax Invoice → `S`, Gold Purchase → `G` `+`.
`LD_CODE` is the **contra** account, not a stock ledger. (An earlier version of this document read `IT_TYPE` as
Stock-vs-Amount and `LD_CODE 000888` as a stock ledger; both were wrong — `000888` is the party.)

A sale's three ledger legs become four Rojmel rows, the revenue leg splitting per line:

    AC_CODE 00004 sales   LD_CODE 000888 party  CR 1087.00  IT_TYPE S  SIGN -  PCS 1  GWT 10.360
    AC_CODE 000888 party  LD_CODE 00004 sales   DR 1560.00  IT_TYPE A

The web's `F11`, labelled "Rojmel", opens `/reports/day-book`, which reads `AC_DATA` — money only, no weights.
**Not the same report.**

## Gap C — the scheme module is a shell

`membership/scheme.ts` has the full API surface: `enrollScheme`, `schemeInstallment`, `schemeOpening`,
`getSchemeInstallment`, `editSchemeInstallment`, `deleteSchemeInstallment`, `deleteEnrollment`,
`schemeMaturity`, `getSchemeMaturity`, `editSchemeMaturity`. Its header comment documents the model correctly,
down to the primary keys and which book maps to `AD_ADJ`.

Its writes are `AC_DATA`, `TEMP_BOOK_DATA`, `DELETE_DATA`. Write sites by table:

    AD_MEMB  1  (enrollScheme)
    AD_MAST  0     AD_DATA  0     AD_OS  0     AD_ADJ  0

So an instalment posts money to the ledger and records nothing about the scheme. The passbook, the member
outstanding report and maturity redemption have no data to read. This is the largest functional gap in the
project and it sits on the business's most-used form.

---

# Implementation plan

Each item states its acceptance criterion as a test that must fail before it passes, and the evidence that
closes it. Ordered by real usage, not by size.

## P0 — Scheme transactions (the #1 and #11 forms)

**Why first:** 2622 + 72 ledger rows, 16,354 rows across `AD_DATA`/`AD_OS`, 877 members. Nothing else comes
close.

### P0.1 `AD_MAST` — scheme definition

Write path so a scheme can exist: code, name, instalment amount, duration, liability account, bonus rule.
Desktop source: `MS_PRODUCT` writes `AD_MAST` via an explicit `INSERT INTO` (already located at
`MS_PRODUCT.cs:2637` during the form-fields work).
**Accept:** a scheme created through the API appears in `AD_MAST` with the desktop's column set; the readiness
gate stops reporting `AD_MAST` as unwritten.

### P0.2 `AD_DATA` + `AD_OS` — instalment and outstanding

`schemeInstallment` must write the instalment detail **and** maintain the outstanding, inside the existing
transaction, alongside the ledger legs it already posts.
**Verified from the data before designing:** 8160 `AD_DATA` rows and 8194 `AD_OS` rows span only **600 distinct
member+scheme pairs** — about 13.7 rows each. So `AD_OS` is a **per-instalment** row, roughly one per `AD_DATA`
row, not a running balance per member. Building it as a single balance row per member would have been the
obvious guess and would have been wrong.
**Accept:** a write-set footprint test asserts `AD_DATA` and `AD_OS` are in the instalment footprint; dropping
either fails naming it. Ledger legs stay balanced.

### P0.3 `AD_ADJ` — advance adjustment (book 076)

**Accept:** book 076 produces `AD_ADJ` rows; the footprint test names it.

### P0.4 Passbook, outstanding and maturity read from real tables

`scheme/passbook.ts` exists — verify what it reads. Once `AD_DATA`/`AD_OS` are populated, the passbook and
maturity must compute from them rather than from the ledger.
**Accept:** a member with three instalments shows three passbook lines and the correct accrued balance; maturity
redeems that balance.

## P1 — Rojmel posting on the main voucher paths

**Why second:** 3179 real rows, and it is the report a jeweller opens every morning.

### P1.1 A shared Rojmel writer

One function, called from sale, purchase, cash, contra and the rest, mirroring the six paths that already write
it. The full row spec is in `project-memory/parity/ROJMEL-MODEL-VERIFIED.md`: `AC_CODE` (this row's ledger
account), `AC_NAME` (denormalised to the **party's** name on every row), `LD_CODE` (the contra account),
`DR_AMT`/`CR_AMT`, `IT_TYPE` (G/S/O metal, or A for money), `SIGN` (`-` out, `+` in, blank on money rows),
`ITM_PCS`, `ITM_GWT`, `VCH_TYPE`, `BOOK_NAME`.
Establish the `LD_CODE` derivation from real rows before writing: `000888` and `00004` both appear, so it is an
account or ledger code, not a constant.
**Accept:** the sale footprint test includes `ROJ_MEL_DATA`; a real desktop sale and the replayed web sale
produce the same Rojmel rows under the parity differ.

### P1.2 A real Rojmel report

Weights and pieces beside amounts, not the current money-only day book. Re-point `F11`.
**Accept:** report data comparison against the desktop's Rojmel output matches on row count and control totals
for stock and amount rows separately.

## P2 — `BAL_GR`, so the balance sheet has a non-metal leg

`closingStock.ts` reads `BAL_GR.AVG_RATE`, `PCS_RATE`, `AVG_AMT` and friends. Nothing writes them, so the
non-metal valuation is silently zero.
**Accept:** a test seeds stock, runs whatever maintains `BAL_GR`, and asserts the balance sheet's non-metal
closing value is non-zero and matches the average-rate arithmetic already implemented and vector-tested.

## P3 — `OP_LDR` on the voucher paths

**Verified:** 7011 rows across **3801 distinct (book, voucher) pairs in 35 books** — about 1.8 rows per
voucher. So despite the name, `OP_LDR` is written **per voucher**, not once per opening. The name misleads and
the plan should not be built on it.
**Accept:** footprint tests include it where the desktop writes it.

## P4 — The small masters

`COL_MAST` (697), `COUNTRY_MAST` (151), `PRINT_MAST` (9), `CONV_MAST` (4), `TABLE_MAST` (1), `UPI_DATA` (1),
`REM_DATA` (15), `IMAGE_DATA` (4).

Several are referenced in web source but never written, which usually means a read path expects data that never
arrives. Treat each as: find the desktop form that maintains it, add a master surface, confirm the reader works.
**Accept:** each becomes either written, or waived in `WAIVERS.md` with a reason.

## P5 — Karigar detail: verify before building

**Verified — this is a missing write, not a divergence.** The web's karigar writes `KR_DATA`, `AC_DATA`,
`BAR_DETL` and `TEMP_BOOK_DATA`, but **not** `KR_DETL` or `KR_IDTL`. The desktop has all three: `KR_DATA` 23,
`KR_DETL` 22, `KR_IDTL` 8.

So a karigar voucher records its **header with no line detail**. Every karigar report that lists what was issued
or received reads the detail table and would find nothing.
**Accept:** the karigar footprint test includes `KR_DETL` (and `KR_IDTL` where sub-details exist); removing
either fails naming it.

---

## The verification loop, per item

Every item above closes the same way, and the order matters:

1. **Extract** the real desktop rows for the affected voucher from `Live24` using `parity-extract-mssql.mjs`.
2. **Replay** the same inputs through the web.
3. **Diff** with `parity-compare.mjs`. It reports `WEB NEVER WROTE THIS TABLE` for a missing write and names the
   field for a wrong value.
4. **Pin** the footprint in the relevant lifecycle test, and **prove the control fails** by removing the write.
5. Only then is the item done.

This is not optional ceremony. The `TAX_DATA` inversion earlier passed 26 tests including the GST suite, so a
green suite is not evidence that a write exists.

## What this plan does not cover

- **Report families** still absent (`RP_ALL`'s 72 buttons). Separate track, already registered.
- **Hardware, messaging, e-invoice credentials.** Still external.
- **Performance targets.** Needs agreement on numbers.
- **Operator acceptance.** Needs the shop.

## Decisions needed from the owner

1. **Is the Rojmel read daily?** If yes, P1 is a production blocker rather than a gap. If the business now reads
   the ledger instead, the current day book may be acceptable and P1.2 drops.
2. **Is the savings scheme still running?** The data says it dominated 2024-25. If it has been discontinued, P0
   changes from urgent to historical-migration-only — a very different amount of work.
3. **`TAG_IMAGE_BLOB`** — still an empty orphan on the dev database awaiting a decision to drop.

Both of the first two change the ordering materially, and neither can be inferred from the data alone.

---

## Status 2026-07-31: P0 scheme done, P1 Rojmel done for the sale

### Scheme (P0) — closed for the instalment path

Six defects fixed, each verified against every real row and each with a control proven failing:
`AD_DATA.TOT_AMT` and `AD_OS.MEMB_AMT` both held the amount where the desktop holds 0 (the second would
have **doubled every member balance**); `AD_OS.LD_CODE` held the scheme liability where the desktop holds
the receipt account; the route forwarded 6 of 14 documented inputs so four columns were unreachable; and
the desktop's member entry is a **grid** posting a **ledger pair per line** where the web posted one
member per voucher.

Still open on the scheme: `AD_ADJ` write path exists but its field fidelity is unverified, and the
passbook/maturity reads have not been checked against populated `AD_DATA`/`AD_OS`.

### Rojmel (P1) — written on every sale

`modules/shared/rojmel.ts`. `LEDR_KEY` is reproduced **byte-exactly** against real desktop keys, which
matters because the primary key is `LEDR_KEY` **alone** in both systems — the layout is the only thing
making a row unique.

**Verified:** 13 unit vectors, and a DB test that posts a real sale and asserts metal rows carry weight,
money rows do not, metal signs out, and the party row equals the `AC_DATA` party debit. Four controls
proven failing, including one that reproduces exactly the money-only day book the web had before.

**Not verified:** the HTTP hop — see below. The route only forwards input and does not touch Rojmel logic.

Still open: the same projection for sales return, sales order, estimate, labour invoice and rate cut
(their `SALE_WRITE_TABLES` already list `ROJ_MEL_DATA`, so the delete side is ready), the purchase side,
and a real Rojmel **report** to replace the money-only day book behind `F11`.

### New finding: the demo seed cannot post a sale

Attempting a sale over the API on `SEED_DEMO=1` fails with `BookPolicyValidationError: book SAL account
row 1 is missing`. Reaching even that point required inserting a customer into `AC_MAST` by hand. The
seed provisions a login, company and books, but not the book-account rows or any customer, so **the
primary transaction cannot be demonstrated**.

That is an obstacle for evaluation, onboarding and any manual UI check, and it is why the Rojmel's HTTP
path is untested. Worth fixing on its own: the seed should provision enough for one sale end to end.

### Verification hole: test files are never typechecked

`tsc -p tsconfig.json` covers `src` only. No test file in this repository has ever been typechecked, and
vitest transpiles without checking. Added `apps/api/tsconfig.test.json`, which surfaces **112 errors
across 121 files**. 64 are benign strictness (`Object is possibly undefined`); the six that looked
dangerous are `created.voucherNo ?? created.vchNo` fallbacks where `voucherNo` does not exist, so they
always take the second branch and assert correctly.

Not wired as a blocking gate — that needs the 112 cleared first — so **the suite is still not
typechecked**, and this document does not claim otherwise.

---

## Rojmel coverage as of 2026-07-31

Derived per family by measurement. The test that settled each: **does a Rojmel row carry the same DR/CR as
its own `AC_CODE`'s ledger leg?**

| Family                         | Rule                                            | Evidence                                    | Status          |
| ------------------------------ | ----------------------------------------------- | ------------------------------------------- | --------------- |
| Sale (and Estimate, same path) | metal row per line + party + tax                | reproduces the reference sale byte for byte | **written**     |
| Purchase                       | inward mirror, `SIGN` `+`                       | books 035/037 → `G` `+`, 036/038 → `S` `+`  | **written**     |
| Sales return                   | inward mirror                                   | same rule as purchase                       | **written**     |
| Scheme instalment 074          | liability row per line, plus a bank receipt row | **1635/1635 rows match (100%)**             | **written**     |
| Scheme opening 075             | no row — no money moves                         | real 175-member voucher has 0 ledger legs   | **written**     |
| Contra / journal 017           | one row per line                                | **74/74 rows match (100%)**                 | **written**     |
| Cash received 001              | not derived                                     | only **50/106 match (47.2%)**               | **not written** |
| Cash payment 002               | not derived                                     | only **10/185 match (5.4%)**                | **not written** |
| Rate cut 064                   | not derived                                     | 66 rows, `IT_TYPE` `G`, key type 26         | **not written** |

Already written before this work: VP parcel, wholesale sale return, other commission, gold book, location
amount, VP adjustment and four repair paths.

### Why cash is deliberately unfinished

Real book 002 voucher 00001 has the Rojmel **debiting** cash 730.00 where `AC_DATA` **credits** it. Book 001
is stranger still: its first row carries the _counter-party's_ direction while its second and third carry
their own. A plausible reading is that the cash books use day-book columns — receipts one side, payments
the other — rather than accounting Dr/Cr.

Plausible is not derived. Guessing a sign on a cash book would misstate the shop's cash position in both
directions at once, so these three families wait for the convention to be established rather than
approximated. The 47.2% and 5.4% figures are the measurement that justifies the refusal.

### The report still comes last

A Rojmel-backed day book would now cover most families but still not cash, which is the single most
frequent kind of voucher in this shop (546 ledger rows across books 001 and 002). Until cash is written,
switching `F11` would show fewer vouchers than the current `AC_DATA`-backed day book — more faithful per
row, less complete overall. That is a regression a shop would notice immediately.
