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

---

## Rojmel row types: what is verified, and what is not

Eight of the sale's row types are implemented. The distinction between the first seven and the eighth
matters more than the count:

| Type      | Meaning                         | Evidence                                               |
| --------- | ------------------------------- | ------------------------------------------------------ |
| `01`+line | item lines                      | reproduces the reference sale byte for byte            |
| `02`      | party, conditional on `BILL_OS` | 47 sales at zero carry none; all 42 non-zero carry one |
| `04`      | tax                             | 91 real rows                                           |
| `11`      | cheque                          | 17/17 equal `CHQ_AMT`                                  |
| `13`      | kasar                           | 100/100 equal `KASAR_AMT`                              |
| `14`      | advance                         | 23/23 equal `ADV_AMT`                                  |
| `16`      | old metal                       | `SL_PR_DETL` lines, weight on a money row              |
| `22`      | round-off                       | **SOURCE ONLY — no real row exists to check**          |

**The boundary is worth stating plainly.** This company's database has `ROF_AMT`, `CARD_AMT`, `DISC_AMT`
and `TCS_AMT` non-zero on **zero** of 190 sales. For those families the only authority is
`Ac_Rojmel.cs`, and that file has already been shown to be a **later version** than the code which wrote
this data — its sale item rows are type `'02'` where the data's are `'01'`. So for round-off the amount,
account and direction are trustworthy while the type code is a best reading, and that is recorded in the
code rather than smoothed over.

Card, discount and TCS are **not** implemented. Implementing three more row types on unverifiable type
codes would add surface without adding confidence.

### Why sampling could not have found any of the settlement rows

Every settlement insert in `Sales_Rojmel` is guarded by `AND <column> <> 0`. A sale settled wholly in cash
emits none of them, so in the data those code paths never fired. **Absence in output is
indistinguishable from absence in code**, and only reading the source separates the two. Measurement
verifies rules already suspected; it cannot enumerate rules nobody knew to look for.

### Still available from the source

`Sales_Rojmel` can also emit TCS, hallmarking + its tax, TDS, cash-paid, card in two variants, discount,
points and UPI per line. Beyond the sale, `Ac_Rojmel.cs` holds about 25 more named routines — karigar
issue and receipt, dhrn issue/receipt/interest, loans, VP, tag weight difference, employee JV,
bill-to-bill and the repair paths — each a defined recipe rather than something to infer. Rate cut 064 and
the non-cash settlement pairs, both deferred earlier for want of a derivation, are among them.

---

## Rate cut resolved: the routine named after it is dead code here

Rate cut (book 064) was deferred twice for want of a derivation. The source resolves it, and not where I
expected — which turns out to be the more useful finding.

`Fine_CUT_Rojmel` is the obvious candidate and is **the wrong routine**. It reads `CUT_DETL` and
`CUT_DATA`, and both tables hold **0 rows** in the real database. This company never used them, so that
routine cannot be what produced book 064's 66 Rojmel rows.

Book 064 writes `RATE_CUT_DATA` (40 rows). In `Ac_Rojmel.cs` that table is read by exactly three routines:
**`Wh_Sales_Rojmel`**, `Wh_Sales_Rtn_Rojmel` and `VP_Rojmel`. Corroborated independently by `RP_ROJMEL`'s
own union query, which pulls `RATE_CUT_DATA` filtered to
`MAIN_BOOK IN ('WH SALES','RATE CUT','BUL WH SALE','TOUR SALES')`. **Rate cut and wholesale sales are one
family to the desktop**, because they share a table.

So the recipe is `Wh_Sales_Rojmel`, and the web already writes `ROJ_MEL_DATA` from the sibling
`wholesaleSaleReturn.ts`. `rateCut.ts` already lists `ROJ_MEL_DATA` in its cleanup set, so the delete side
is ready and only the write is missing.

### The correction to my own method

An hour earlier I concluded "read the source first" after finding that sampling could not enumerate code
paths which never fired. That lesson is right but incomplete, and following it alone would have led me
straight into transcribing `Fine_CUT_Rojmel` faithfully against tables that hold no data.

The rule is **source for what EXISTS, data for what RUNS**. Neither is sufficient alone:

- sampling data cannot enumerate code paths that never fired — that is how the settlement rows hid;
- reading source cannot tell you which paths are live — that is how `Fine_CUT_Rojmel` nearly caught me.

The check that separated them cost one query: **count the rows in the tables a routine reads.** That is
now the first thing to do with any of the ~25 remaining routines, before writing a line of code against
one.

---

## All 44 Rojmel routines, classified live or dead

Produced by applying the rule from the previous section to every routine in `Ac_Rojmel.cs`: extract the
tables it reads, then count their rows in the real database. One query settles each.

### Live — the routine's primary table has data (26)

| Routine                                                     | Source rows        | Web status                                   |
| ----------------------------------------------------------- | ------------------ | -------------------------------------------- |
| `Schm_RojMel`                                               | `AD_DATA` 8160     | **written**                                  |
| `Cash_Rojmel` / `Bank_Rojmel`                               | `CASH_DATA` 335    | **written**                                  |
| `Bill_To_Bill_Rojmel`                                       | `CASH_DATA` 335    | not written                                  |
| `Sales_Rojmel`                                              | `SL_DATA` 190      | **written** (8 of ~20 row types)             |
| `SaleReturn_RojMel`                                         | `SL_DATA` 190      | **written**                                  |
| `EInvoice_Rojmel` · `Item_Sl_Rojmel`                        | `SL_DATA` 190      | not written                                  |
| `Order_Adj_Rojmel`                                          | `SL_ORD_ADJ` 110   | not written                                  |
| `Contra_Rojmel`                                             | `CONTRA_DATA` 102  | **written**                                  |
| `Order_Rojmel`                                              | `SL_ORD_DATA` 76   | not written                                  |
| `Purc_Rojmel`                                               | `PR_DATA` 74       | **written**                                  |
| `Purc_Rtn_Rojmel` · `Item_Pr_Rojmel`                        | `PR_DATA` 74       | not written                                  |
| `Wh_Sales_Rojmel` · `Wh_Sales_Rtn_Rojmel` · `VP_Rojmel`     | `RATE_CUT_DATA` 40 | partly — the wholesale-return path writes it |
| `Schm_Adj_RojMel`                                           | `AD_ADJ` 26        | not written                                  |
| `Kr_Isu_Rojmel` · `Kr_Rec_Rojmel` · `OldSale_RojMel`        | `KR_DATA` 17       | not written                                  |
| `Labour_RojMel` · `Tag_Wt_Diff_Rojmel` · `Tag_Split_Rojmel` | `LBR_DATA` 3       | not written                                  |
| `Oth_Purc_Rojmel` · `Oth_Comm_Rojmel`                       | `PAY_DATA` 3       | partly — other-commission writes it          |

### Dead for this customer — primary table empty (15)

`DhrnIsu_RojMel`, `DhrnRec_RojMel`, `DhrnIntRec_RojMel`, `Loan_Rec_RojMel`, `Loan_IntRec_RojMel`,
`Loan_Isu_RojMel` (all `DHRN_*` = 0) · `Rep_CustRec_KrIsu_Rojmel`, `Rep_KrRec_CustIsu_Rojmel`
(`REP_DATA` = 0) · `Emp_Jv_Rojmel` · `Card_Adj_RojMel` · `VpAdj_Rojmel` · `Jdt_Rec_Rojmel` ·
`Loct_Amt_Rojmel` · `Stk_InOut_Rojmel` · `Fine_CUT_Rojmel`.

### Tables absent from the schema entirely (3)

`Dg_Gold_Booking_Rojmel` (`DG_GOLD_DATA`), `Fan_Sale_Rojmel` and `Fan_Purc_Rojmel` (`FAN_DATA`,
`FAN_DETL`). These reference tables that do not exist in this database at all — features never installed.

### The uncomfortable observation

**The web already writes the Rojmel from six paths this customer has never used** — location amount, VP
adjustment and the four repair paths all sit in the dead list — while not writing it for order adjust
(110 rows), sales order (76), scheme adjust (26) or karigar (17), which the customer does use.

That is not a coincidence, it is a symptom: those six were implemented because a sibling feature needed
them, not because anything indicated they mattered. Effort went where the code led rather than where the
business was. This table is the correction, and it is worth consulting before the next Rojmel commit
rather than after.

### Priority, by rows rather than by convenience

1. `Order_Adj_Rojmel` — `SL_ORD_ADJ` 110 rows
2. `Order_Rojmel` — `SL_ORD_DATA` 76
3. `Wh_Sales_Rojmel` — `RATE_CUT_DATA` 40, and it is the rate-cut recipe
4. `Schm_Adj_RojMel` — `AD_ADJ` 26
5. `Kr_Isu_Rojmel` / `Kr_Rec_Rojmel` — `KR_DATA` 17, alongside the `KR_DETL` write gap already recorded

The dhrn and loan families — six routines, the largest single block — can wait until a customer database
shows them in use. Same for repair, card adjust and manufacturing JDT.

---

## Correction: the priority list above was wrong, and here is the counted one

The previous section ranked `Order_Adj_Rojmel` first because `SL_ORD_ADJ` has 110 rows. That was wrong.
`SL_ORD_ADJ` has 110 rows, but `PAID_AMT` is non-zero on **1** of them and `KASAR_AMT` on **0** — and
those are the only columns the routine reads. It contributes about one Rojmel row in the entire year.

**The live/dead test needs to be column-level, not table-level.** A table with rows tells you nothing if
the routine's inserts are guarded on columns that are empty, which most of them are. That refinement
arrived one step after I wrote the rule down.

The measure with no inference in it at all is simply: **count the real `ROJ_MEL_DATA` rows per book.**
3179 rows across 38 books.

| Book                                           | Rows           | Web                 |
| ---------------------------------------------- | -------------- | ------------------- |
| 074 Member Monthly Entry                       | 1635           | written             |
| 026 Gold Tax Invoice Old                       | 222            | written             |
| 032 Estimate                                   | 208            | written             |
| 002 Cash Payment                               | 185            | written             |
| 001 Cash Received                              | 106            | written             |
| 027 Silver Tax Invoice Old                     | 94             | written             |
| 017 Contra Entry                               | 74             | written             |
| **064 Rate Cut / Fine issue-receipt**          | **66**         | **not written**     |
| 035 Gold Purchase                              | 64             | written             |
| **020 Sales Order**                            | **55**         | **not written**     |
| 012 / 009 / 014 / 005 / 013 bank pay & receipt | 46+42+40+22+20 | written (cash path) |
| **076 Member Advance Adjust**                  | **37**         | **not written**     |
| **034 Wh Sales**                               | **32**         | partly              |
| 029 Gold Tax Invoice                           | 29             | written             |
| **052 Karigar Receipt**                        | **28**         | **not written**     |
| **078 Fine Jv**                                | **28**         | **not written**     |
| **043 Gold URD Purchase Old**                  | **27**         | **not written**     |

### Where that leaves coverage

Books the web now writes account for roughly **2800 of the 3179 real Rojmel rows — about 88%**. The
remaining ~380 sit in seven books: rate cut, sales order, member advance adjust, wholesale sales, karigar
receipt, fine JV and URD purchase.

That is a more honest figure than any of the earlier ones, because it counts rows the desktop actually
wrote rather than routines that exist or tables that have data.

### Corrected priority

1. **Rate Cut 064** — 66 rows, recipe is `Wh_Sales_Rojmel`
2. **Sales Order 020** — 55 rows, `Order_Rojmel`
3. **Member Advance Adjust 076** — 37 rows, `Schm_Adj_RojMel`
4. **Wh Sales 034** — 32 rows, same recipe as rate cut
5. **Karigar Receipt 052** — 28 rows, `Kr_Rec_Rojmel`, alongside the `KR_DETL` write gap
6. **Fine Jv 078** — 28 rows
7. **URD Purchase 043** — 27 rows

`Order_Adj_Rojmel` drops off the list entirely.

### The general lesson, third revision

- Sampling data cannot enumerate code paths that never fired.
- Reading source cannot tell you which paths are live.
- Counting rows in a routine's **tables** cannot tell you whether the **columns it reads** are populated.

Each refinement came from being caught by the previous one. The cheapest reliable measure turned out not
to be about routines or tables at all: count the output rows the desktop actually produced, grouped the way
the feature is organised.

---

## `Wh_Sales_Rojmel` analysed, not implemented — and why that is the right call

The corrected priority put rate cut first (book 064, 66 real rows). Its recipe is `Wh_Sales_Rojmel`, and
reading it changed the estimate: it is **40+ row types**, by far the largest routine in the file.

It is large because rate cut is a **two-sided settlement** — a purchase leg and a sale leg in one voucher —
and because gold and silver are handled through **separate row families** rather than one parameterised
path. Most rows therefore appear four times: purchase/sale × gold/silver.

It reads **nine `BOOK_DETL` slots**, and the slot is what distinguishes otherwise identical rows: 1 and 2
for gold sale/purchase control, 8 and 9 for silver, 4/5 kasar amounts, 6/7 labour, 12 kasar fine. Two
accounts are hardcoded — `'00061'` interest, `'00007'` the `IT_TYPE = 'A'` control.

The most interesting structural fact: its **fine rows carry no money at all** — `DR_AMT` and `CR_AMT` are
both zero, with the weight in `ITM_FINE` and direction in `SIGN`. Those are precisely the rows
`RP_ROJMEL`'s gold and silver fine summaries read, which closes the loop on why those summaries filter
`ITM_FINE <> 0`.

**Full analysis is in `project-memory/parity/ROJMEL-MODEL-VERIFIED.md`** — slot map, row families, guards.

### Why it is not implemented in this session

Starting a 40-row-type transcription with little context left would produce something half-finished and
unverified. That is the exact failure this project's gates exist to prevent, and it would be poor practice
to commit it on a Friday afternoon and call it progress.

### And the first step is not implementation anyway

Per the column-level lesson learned two commits ago: `RATE_CUT_DATA` has 40 rows, `RATE_CUT_ISU` 20 and
`RATE_CUT_REC` 2, yet only **66** Rojmel rows resulted. So **most of those 40 row types produced nothing
in a year of trading.** Counting non-zero source columns first will very likely reduce the work to a
handful of families — as it did for `Order_Adj_Rojmel`, which the same check removed from the list
entirely.

Doing that counting first is cheap, and it is the difference between implementing 40 row types and
implementing the four that fire.

---

## The next piece is fully planned: `docs/PLAN-RATECUT-ROJMEL.md`

Rate cut and wholesale sales (books 064 and 034, 98 real Rojmel rows between them) are analysed, scoped and
written up as a **self-contained implementation plan** that assumes no memory of any prior session.

The counting step did its job before a line was written:

- `Wh_Sales_Rojmel` contains **40+ row types**. Only **9** ever fired in a year of this shop's trading —
  a 78% reduction, established by grouping the 66 real rows by their `LEDR_KEY` type code and matching each
  against a non-zero source column.
- **All 40 `RATE_CUT_DATA` rows are `IT_TYPE='G'`.** This company never rate-cut silver, so every silver
  row family is dead, along with interest, tax, TDS, card and labour.

Three facts were corrected while verifying the plan's own references, which is the reason to verify them:

1. **`BOOK_DETL` slots are per-book, not global.** Book 064's map differs entirely from book 026's —
   slot 2 is `00008` on 064 and `00001` on 026. Any plan built on the 026 map would have written the wrong
   contra account on every row.
2. **Type `13` disagrees between source and data**, and it is the interesting kind of disagreement: the
   source says a money-only row with `IT_TYPE 'A'`, the data shows a gold fine row carrying `DR_AMT`,
   `ITM_FINE` _and_ `ITM_RATE` together. It is the only fine row that is not money-free.
3. **All 66 keys are 23 characters**, so no rate-cut type carries a line number — unlike the sale, whose
   item rows are 33.

The plan also states what it will _not_ build and why, lists six controls that must be demonstrated failing
before the work is trusted, and records that this family will be the first to make the report's
`totals.gold.outFine` non-zero — which is the end-to-end proof that the fine summaries work at all.
