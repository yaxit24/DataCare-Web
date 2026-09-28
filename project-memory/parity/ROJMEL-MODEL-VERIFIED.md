# The desktop Rojmel (day book), verified against Live24

3179 real rows. Every statement measured.

## CORRECTION to my first reading
I recorded `IT_TYPE` as separating "Stock from Amount". **Wrong.** `IT_TYPE` is the **metal**:

| IT_TYPE | Meaning | Rows | With GWT>0 |
|---|---|---|---|
| `G` | gold | 335 | 270 |
| `S` | silver | 130 | 130 |
| `O` | other metal | 3 | 3 |
| `A` | amount (money row) | 2711 | 24 |

Confirmed by book: 026/029 Gold Tax Invoice → `G`; 027/030 Silver Tax Invoice → `S`; 035/037 Gold Purchase
→ `G`; 036/038 Silver Purchase → `S`; 032 Estimate → G, S and O together.

I also recorded `LD_CODE 000888` as a stock ledger. **Wrong** — it is the party
(VINUBHAI VALJIBHAI LUNAGARIYA). `LD_CODE` is the **contra account**: the account on the other side of
this row's amount.

My broader point survives — the Rojmel does carry metal weight beside money, which the web's `AC_DATA`-based
day book does not — but the specific letters meant something else.

## `SIGN`
`-` metal out, `+` metal in. Gold Purchase 035 → `G` `+`; Gold Tax Invoice 026 → `G` `-`. Blank on `A` rows.

## Row composition for a sale (book 027 voucher 00001, verified end to end)
The sale: party `000888`, TOT_AMT 1560.00, TAX_AMT 45.45, NET_AMT 1515.00, two lines
(MA925 1 pc 10.360 g net 1087.00; ORS 1 pc 4.600 g net 428.00).

Its three ledger legs: party `000888` Dr 1560.00 / sales `00004` Cr 1515.00 / tax `00085` Cr 45.45.

Its four Rojmel rows re-express those legs, splitting the revenue leg per line:

| AC_CODE | LD_CODE | Dr | Cr | IT_TYPE | SIGN | PCS | GWT | source |
|---|---|---|---|---|---|---|---|---|
| `00004` sales | `000888` party | 0 | 1087.00 | `S` | `-` | 1 | 10.360 | SL_DETL line 1 |
| `00004` sales | `000888` party | 0 | 428.00 | `S` | `-` | 1 | 4.600 | SL_DETL line 2 |
| `000888` party | `00004` sales | 1560.00 | 0 | `A` | | | | party leg |
| `00085` tax | `000888` party | 0 | 45.45 | `A` | | | | tax leg |

1087.00 + 428.00 = 1515.00 = the sales leg. The revenue leg becomes N metal rows carrying weight; the party
and tax legs become amount rows.

`AC_NAME` is denormalised to the **party's** name on every row, including rows whose `AC_CODE` is the sales
or tax account — it is the day book's display name, not the account's name.

## Web state
17 write sites (VP parcel, wholesale return, other commission, gold book, location amount, VP adjustment, four
repair paths) but **none on the main sale, sales return, sales order, estimate, labour invoice or rate cut**.
The source documents it: `rateCut.ts:576` — "PHASE-2 TODO: project SL_IDTL (stone/diamond sub-lines),
ROJ_MEL_DATA (day-book), MAIN…".

`OP_LDR` has exactly one write site, `masters/configTables.ts:361`, a config surface — not a voucher path.
The desktop writes 2 rows per sale and 7011 in total over 3801 vouchers in 35 books.

## Verification status (honest)

**Verified:** 13 unit vectors including byte-exact reproduction of the real `LEDR_KEY`s, and a
database-backed test that posts a real sale through `createSale` against the real Postgres schema and
asserts the Rojmel rows exist, carry weight on metal rows only, sign metal out, and that the party row's
amount equals the `AC_DATA` party debit. Four controls proven failing: dropped write, zeroed weight,
diverged party amount (`expected 1200 to be close to 1236`), inverted sign.

**Not verified:** the HTTP hop. A sale could not be posted over the API against the demo seed, which
lacks the `BOOK_DETL` book-account configuration a sale requires — `BookPolicyValidationError: book SAL
account row 1 is missing`. The route only forwards input and does not touch Rojmel logic, so this is a
gap in demo provisioning rather than in the feature.

**Separate finding worth acting on: the demo seed cannot post a sale.** Reaching the tax stage needed a
customer in `AC_MAST` and the book-account row, neither of which `SEED_DEMO=1` provides. A demo that
cannot demonstrate the primary transaction is a real obstacle for evaluation and onboarding.

## Money-only vouchers: the scheme rule, derived

Book 074 carries **1635** Rojmel rows against **1311** instalment lines. The mismatch is the rule:

* type `01`, **one per line**: the liability leg — `AC_CODE` the liability, `LD_CODE` the receipt account,
  amount on the **credit** side. 1311 rows, exactly one per line.
* type `02`, one per line **but only when the money lands in a bank**: the receipt leg — `AC_CODE` the
  bank, `LD_CODE` the liability, amount on the **debit** side. 324 rows over 216 vouchers, and all four
  accounts are banks (OLD AXIS CURRENT 288, AXIS CURRENT 33, AXIS OD 2, AXIS B K DHAKAN 1).

Decisive: of the bank-receipt vouchers, **216 have a type-02 row and 0 do not**. A cash receipt gets no
second row — the Rojmel *is* the cash book, so cash movement is implicit and a bank movement is a contra
that has to be stated.

Both keys carry the line number (`…07400022 01         1` and `…07400022 02         1`), which they must:
`LEDR_KEY` is the whole primary key, so two rows on one voucher would otherwise collide.

An opening (075) moves no money and writes no day-book row.

## NOT derived, deliberately left unimplemented: the cash-book sign convention

The cash books invert the cash leg relative to the ledger. Real book 002 voucher 00001:

    ROJ_MEL_DATA  AC_CODE 00001 (CASH)  LD_CODE 000294  DR 730.00
    AC_DATA       000294 DR 730.00   /   00001 CR 730.00

The Rojmel **debits** cash where the ledger **credits** it. That is the opposite of every other family
examined, where the Rojmel follows the ledger's direction (sale, purchase, return, scheme all match).

A plausible reading is that the cash books use day-book columns — receipts one side, payments the other —
rather than accounting Dr/Cr. **Plausible is not derived**, and guessing the sign on a cash book would
misstate the shop's cash position in both directions at once, so cash (001/002), contra (017) and rate cut
(064, IT_TYPE 'G', key type 26) are not implemented. Row counts available when they are:
001 → 106, 002 → 185, 017 → 74, 064 → 66.

## Reading `Ac_Rojmel.cs`: what measurement could not tell me

`Ac_Rojmel.cs` is 1115 lines with one named routine per family — `Sales_Rojmel`, `Purc_Rojmel`,
`Cash_Rojmel`, `Bank_Rojmel`, `Contra_Rojmel`, `Schm_RojMel`, `SaleReturn_RojMel`, `OldSale_RojMel` and
about 25 more. Each is a set of `INSERT … SELECT` statements straight off the source tables. It is the
authority, and I should have opened it before deriving rules from one sampled voucher.

### It confirmed the parts I had derived
Item row: `AC_CODE = GROUP_MAST.SALE_AC`, `LD_CODE` = the party, `CR_AMT` = the line net, `IT_TYPE` from
`SL_DETL.IT_TYPE`, `SIGN` `'-'`, and `ITM_TOUCH`/`ITM_WEST`/`ITM_FINE` hard-zero on a sale — all as
implemented.

### Three things it corrected

**1. The party row is conditional.** `Sales_Rojmel` writes it only for a non-zero `BILL_OS`, splitting the
sign across two row types: `'03'` when `BILL_OS > 0` (debit) and `'04'` when `BILL_OS < 0`
(`ABS(BILL_OS)`, credit). Verified: of 47 real sales with `BILL_OS = 0`, **zero** carry a party row; of 42
with `BILL_OS <> 0`, **all 42** do. Writing one unconditionally overstated the day's debtors on every
fully-paid sale.

**2. Item rows carry more columns than I wrote.** `IT_DESC` = `ITEM_MAST.IT_NAME`, plus `IT_CODE`,
`NET_AMT`, `LBR_RATE`, `LBR_AMT`, `OTH_AMT`. All 245 real sale metal rows carry `IT_DESC`, `IT_CODE` and
`NET_AMT`; 237 of 245 carry `LBR_AMT`. Mine left all of them blank.

**3. A sale has far more row types than three.** `Sales_Rojmel` alone can emit: item lines, party (two
sign variants), tax, TCS, hallmarking + its tax, TDS, cash paid, cheque, card (two variants), kasar +
points, advance adjust, discount, round-off, UPI per line, and old-gold purchase lines from `SL_PR_DETL`
(which carry weight despite `IT_TYPE 'A'`). The web writes items + party + tax. **Everything else is a
known gap**, and it is only visible from the source — a sale with no discount, no round-off and no card
produces no such rows, so no amount of sampling reveals them.

### An unresolved divergence, recorded rather than decided

Real data puts sale item rows at `LEDR_KEY` type **`01`**; the current `Sales_Rojmel` non-UAE branch emits
**`'02'`** (`'01'` is the UAE branch, which also blanks `AC_NAME` — and real rows *do* carry the party
name). So the data matches neither branch exactly, and the most likely explanation is that **the
decompiled source is a later version than the code that wrote `Live24`** (backup 2025-04-21).

The web currently emits `01`, matching the data. The type digits are internal — `RP_ROJMEL` filters on
`IT_TYPE`, `SIGN` and the amounts, never on the type code — so the impact is low, but it is a real
divergence from the current desktop and is not silently resolved here.

## Rate cut: the routine I was looking for is not the one named after it

I deferred rate cut (book 064) twice for want of a derivation. The source resolves it, and not where
expected.

`Fine_CUT_Rojmel` looks like the obvious candidate and is **the wrong routine**. It reads `CUT_DETL` and
`CUT_DATA`, and both tables have **0 rows** in the real database — this company never used them. So
`Fine_CUT_Rojmel` cannot be what produced book 064's 66 Rojmel rows.

Book 064 writes `RATE_CUT_DATA` (40 rows), and in `Ac_Rojmel.cs` that table is read by exactly three
routines: **`Wh_Sales_Rojmel`**, `Wh_Sales_Rtn_Rojmel` and `VP_Rojmel`. This is corroborated
independently by `RP_ROJMEL`'s own union query, which pulls `RATE_CUT_DATA` filtered to
`MAIN_BOOK IN ('WH SALES','RATE CUT','BUL WH SALE','TOUR SALES')` — rate cut and wholesale sales are the
same family to the desktop because they share the same table.

So the recipe for rate cut is `Wh_Sales_Rojmel` (lines 221-311), and the web already writes
`ROJ_MEL_DATA` from `wholesaleSaleReturn.ts` — the sibling path. `rateCut.ts` lists `ROJ_MEL_DATA` in its
cleanup set and carries the note at line 576 (`PHASE-2 TODO: project SL_IDTL, ROJ_MEL_DATA`), so the
delete side is ready and only the write is missing.

**Why this matters beyond rate cut:** a routine named after a feature is not evidence it implements that
feature. `Fine_CUT_Rojmel` exists, compiles, and is dead code for this customer. Had I implemented from it
— which is exactly what "read the source first" would have led me to — I would have written a faithful
transcription of a code path the business does not use, against tables that hold no data. The check that
caught it was cheap: **count the rows in the tables the routine reads.**

### What Fine_CUT_Rojmel does contain, for whenever CUT_DATA is used
Types `01`+line (gold `999` and silver `FSL` item rows, amount direction split on
`MAIN_BOOK = 'FINE PURC'`), `02`/`03` party on `BILL_OS` and `ABS(BILL_OS)`, `04` tax, `06` TDS,
`07` cheque, `08` card, `09` kasar, `10`/`11` round-off as a **pair** with mirrored `CASE` expressions,
and `12`/`13`+line for the metal rows — which carry `ITM_TOUCH = 100` because fine metal is pure by
definition, with the weight taken from `DR_FINE`/`CR_FINE` and `SIGN` `'-'` on a fine purchase, `'+'`
otherwise.

## `Wh_Sales_Rojmel` — the rate cut recipe, analysed but NOT implemented

This is the routine behind book 064 (rate cut, 66 real rows), book 034 (wholesale sales, 32) and the VP
path. It is by far the largest in the file: **40+ row types**. Analysed here so implementation starts from
structure rather than rediscovery; deliberately not started with insufficient context to finish and verify.

### Why it is so large
Rate cut is a **two-sided settlement** — a purchase leg and a sale leg in one voucher — and it handles gold
and silver through **separate row families** rather than a shared parameterised path. So most rows appear
four times: purchase/sale × gold/silver.

### `BOOK_DETL` slots it reads
Nine of them, and the slot chosen is what distinguishes otherwise identical rows:

| Slot | Used for |
|---|---|
| 1 | sale side control (gold) |
| 2 | purchase side control (gold) |
| 4 / 5 | sale kasar / purchase kasar amount |
| 6 / 7 | sale labour / purchase labour |
| 8 / 9 | sale / purchase control (**silver**) |
| 12 | kasar **fine** (both metals) |

Hardcoded accounts appear too: `'00061'` for interest fine, `'00007'` as the control when
`IT_TYPE = 'A'`.

### Row families
* **Fine rows** (types 01, 03, 09, 11, 33, 35): `DR_AMT = 0` and `CR_AMT = 0` — *pure metal movement with
  no money at all*. Weight is in `ITM_FINE`, rate in `ITM_RATE`, `SIGN` `'-'` on the purchase side and
  `'+'` on the sale side. These are what feed `RP_ROJMEL`'s gold/silver fine summaries.
* **Amount rows** (02, 04, 10, 12): `CR_AMT`/`DR_AMT` = `CR_AMT + PR_ITM_AMT` or `DR_AMT + SL_ITM_AMT`.
* **Bill outstanding** (13, 14): `ABS(PR_BILL_OS)` / `ABS(SL_BILL_OS)`, the negative-side variants.
* **Issue/receipt detail** (05, 06, 15, 16, 17, 18) from `RATE_CUT_ISU` and `RATE_CUT_REC`, per line, all
  guarded by `ITM_FINE <> 0 AND ITM_AMT = 0`. Types 16/18 are silver-specific, taking weight from
  `SILVER_FINE` into gross, net **and** fine simultaneously.
* **Kasar fine** (07, 08, 19, 20) on slot 12; **kasar amount** (25, 26) on slots 4/5.
* **Settlement**: cheque (21, 22) on `BANK_AC`, card (23, 24) on `CARD_AC`, labour (27, 28), tax
  (31, 32), TDS (37, 38).
* **Interest fine** (29, 30) against `'00061'`.
* **`IT_TYPE = 'A'` variants** (39, 40 and a second 03/04 pair) against `'00007'`.

### What to verify first, before writing anything
Per the column-level lesson: of the 40 row types, check which have non-zero source columns in the real
data. `RATE_CUT_DATA` has 40 rows, `RATE_CUT_ISU` 20, `RATE_CUT_REC` 2 — and 66 Rojmel rows resulted, so
**most of these 40 types produced nothing.** Counting non-zero columns first will likely reduce this to a
handful of families worth implementing, exactly as it did for `Order_Adj_Rojmel`.
