# Phase 2 — Close database parity: purchase columns

Scope from `DESKTOP-PARITY-EXECUTION-PLAN-2026-08-30.md` Phase 2.1.

```
                 start    2.1a     2.1b     2.1c     2.1d     2.1e
fieldDifferences  3,813   3,199    1,867    1,321      990      937
agreement        85.22%  87.60%   92.76%   94.88%   96.16%   96.41%
rowsMissing         207     207      207      207      207      198
rowsExtra           215     215      215      215      183      174
tablesWebOnly       108     108      108      108       76       76
MAIN_STOCK          635      21       21       21       21
PR_DETL           1,195   1,195      651      105       27
PR_DATA             853     853      345      294       92
```

**Cumulative: 3,813 -> 937, a 75% reduction, agreement 85.22% -> 96.41%.** Five increments, each measured.

## The diagnosis the oracle handed over

Ten columns each differed on 78 or 79 of the 79 purchase stock rows — every single one. A column wrong in every
case is not a calculation bug, it is a builder that never writes it. The purchase `MAIN_STOCK` builder emitted 20
named columns of the desktop's 49.

## Values derived from the desktop's own rows, not from the C#

Measured across all 77 purchase stock rows in the retained capture:

| Column | Rule | Confidence |
| --- | --- | --- |
| `ISR_NO` | the **line ordinal** within the voucher | 77/77 (1 row→1; 2→1,2; 3→1,2,3; 4→1,2,3,4) |
| `STK_DATE` | equals `VCH_DATE` | 77/77 |
| `KR_NWT` | equals `ITM_NWT` | 77/77 |
| `KR_FINE` | equals `ITM_FINE` | 77/77 |
| `KR_TOUCH` | equals `ITM_TOUCH` | 77/77 |
| `KR_WEST` | equals `ITM_WEST` | 77/77 |
| `EMP_CODE` | `''` | 77/77 |
| `ITM_SIZE` | `''` | 77/77 |
| `LBR_RATE`, `OTH_AMT` | the line's own values | 5 and 13 rows non-zero |

The `KR_*` group is not coincidence: on a purchase the karigar-valuation columns carry the same weights as the
item, because the metal came in at that purity.

`ISR_NO` is the counterpart to a finding already recorded in this file: the desktop holds `SR_NO` **constant at 1**
on a goods-received voucher and uses `ISR_NO` for the ordinal. The web had the two exactly the wrong way round —
`SR_NO` was already corrected to 1, and `ISR_NO` was simply absent.

## A migration I nearly wrote, and did not need

`STK_DATE` still differed on all 79 rows after the fix: desktop `2024-04-01`, web `2024-04-01 00:00:0…`. The web's
column is `character varying` where the desktop's is `date`.

Before proposing a type migration I audited every column both sides share: **1 divergence in 1,127 columns**, so
this is an isolated quirk rather than a systematic one. Then checking the readers showed the codebase already has
a convention — `vpParcel.ts:989`, `wholesaleSaleReturn.ts:979` and `:1036`, `meltingPro.ts:347`,
`stockVoucherLifecycle.ts:603` all write a 10-character date string into it. My fix had passed a `Date` and broken
that convention. One-line fix, no migration, no risk to existing rows.

Worth stating plainly: had I not checked, the "fix" would have been a medium-risk column-type change to satisfy a
difference the codebase already knew how to avoid.

## 2.1b — One line that removed 1,332 differences

`insertRowTx` merged `{...defaults, ...data}` and documented that "a supplied value always wins, including an
explicit null". That defeated the entire column-default mechanism, because the purchase builders use the idiom
`text(x).slice(0, n) || null`, which yields `null` for every absent field.

`desktopColumnDefaults` is not a convenience table: it was derived by counting NULLs per column over every row of
the real database, and a column appears in it **only when the desktop never stores NULL there**. So a caller
passing `null` for such a column is passing a value the desktop never writes. A measured default now wins over an
explicit null; columns absent from the spec are untouched, because the desktop does leave those NULL.

One test failed — `rate-cut settlement ... expects CONV_RATE to be null`. Investigating rather than adjusting:
the spec records `RATE_CUT_DATA.CONV_RATE` with default `0`, and all 15 captured rows hold `0`. **The test was
asserting the web's old behaviour, not the desktop's**, and passed only because the null override existed. It was
corrected with that evidence cited.

## 2.1c — Separating my measurement's gaps from the application's

The remaining `PR_DETL` columns split two ways, and getting the split wrong would have meant "fixing" the web to
invent values it was never given:

| Column | Desktop | Verdict |
| --- | --- | --- |
| `RATE_TYPE`, `WITH_STOCK`, `PR_CODE`, `IT_DESC` | `G`, `Y`, `FN`, `FINE GOLD` | **the replay's gap** — all four exist as `PurchaseLineInput` fields, so the mapper simply was not passing them. 312 differences that were mine, not the web's. |
| `DESIGN_IMG_ID`, `APR_ISU`, `EMP_ISU` | `N` on 78/78 | **the builder's gap** — no such inputs exist, so the form sets them. The spec's `''` is its GLOBAL default across every `PR_DETL` row and cannot express "a purchase line writes 'N'", so the value belongs in the builder. |
| `TAG_NO` | `''` on 78/78 | **the builder's defect** — it wrote `'N'`. |

### The sentinel is per table

`'N'` is a `MAIN_STOCK` convention. `Ac_Stock.cs:54` writes
`CASE WHEN A.TAG_NO = '' THEN 'N' ELSE A.TAG_NO END` — the SOURCE rows hold `''` and only the stock row is
converted. `PR_DETL` holds `''` on 78/78, and the derived spec agrees.

That puts the WP-08e change to `KR_DETL` in doubt. It was justified from `TR_KR_ISU.cs:5109`, the karigar form's
own save routine, so it is probably right — but it was reasoned from a different form's source and should be
confirmed against captured `KR_DETL` rows. Recorded in the code as well as here.

## 2.1d — Header columns, a dropped input, and a fabricated liability

Three more web-side gaps, each confirmed against the captured headers before changing anything:

| Fix | Evidence |
| --- | --- |
| `PR_DATA.SL_BILL_LC`, `SL_BILL_YRCD`, `USER_UPDATE`, `USER_DELETE` | `'00'`, `'2024-2025'`, `'N'`, `'N'` on 51/51. The DETAIL builder already wrote the first two; the header omitted all four. |
| `PR_DATA.BILL_NO` defaulted to the voucher number | `''` on 51/51. Defaulting invented a supplier's bill reference the supplier never issued — worse than blank, because `00001` looks like a real document number to any reconciliation that reads it. |
| `PR_DETL.RATE_TYPE` never written | `'G'` on 78/78. `rateType` did not exist on `PurchaseLineInput`, so it is now accepted (same union as `RateCutLine.rateType`) and defaults to `'G'`. |

One more replay artefact removed: `bankAc` was passed unconditionally, writing `PR_DATA.BANK_AC` on 49 cash
purchases where the desktop leaves it blank. Mine, not the application's.

### A fabricated liability

`BILL_OS_DATA` was written on **every** purchase, unconditionally. The desktop writes none for any of the 51
captured vouchers, because every one is settled in full at entry. A payable row for a bill that was paid on the
spot is not cosmetic: it is a liability the business does not owe, and it shows up in outstanding and ageing
reports as if it were real. Now gated on a non-zero outstanding.

This is precisely the defect class the suite already documents for the Rojmel party row — "it passed
`totals.total`, so `outstanding` was never zero and every purchase got a party row". The same mistake existed one
table over.

Result: `rowsExtra` 215 -> 183 and `tablesWebOnly` 108 -> 76.

### A fix written, then reverted

A matching guard for `LOT_DETL` ("only stage lots when a line names one") was written and reverted, because it
contradicts the desktop's own source: `Ac_Stock.cs`'s `LOT_DETL` insert filters on
`MAIN_BOOK IN ('PURCHASE','B2B PURC') AND BOOK_INOUT = 'I'` with **no** lot-number condition, so the desktop
stages every purchase line.

The captured data says the opposite — none of the 51 vouchers has a `LOT_DETL` row. The likely reconciliation is
that `PrKr_Lot` is a separate stock-posting pass rather than part of the voucher save, so the capture may predate
it. Two readings, opposite conclusions, no evidence here to settle it. The 78 extra rows are left in place and the
question recorded in the code, because guessing would either invent lot rows or suppress real ones.

## 2.1e — A ledger column stamped on the wrong legs, and a replay artefact in the keys

### `AC_DATA.PARTY_AC_CODE`

`posting.ts` echoed the row's own `AC_CODE` into `PARTY_AC_CODE`, documented as "the desktop statement does". That
is right on the party's own leg, where the two coincide, and wrong on every contra leg — it stamped the settlement
or expense account as though it were a party.

Measured across the captured ledgers: a **party leg carries the party on 120 of 120** rows, and a **contra leg is
blank on 79 of 88**. The nine exceptions are multi-party vouchers, where each leg pair carries its own line's
party.

The poster now takes an optional `partyAc` and applies the desktop's rule when given it. Optional deliberately:
callers that have not been audited keep the previous behaviour rather than silently losing the value on their
party legs. Purchase passes it; 66 differences resolved, 52 net after re-pairing.

The lifecycle test asserted `PARTY_AC_CODE == AC_CODE` on every row, which is what let the defect persist. It now
asserts the measured rule. The same file already models the right method in its `CLR_DATE` comment — "measured
over all 5150 real AC_DATA rows in Live24" — which is exactly how this question should have been settled.

### `LEDR_KEY` was partly my own doing

Forty `AC_DATA.LEDR_KEY` differences decomposed as
`01|00|2024-2025|002|00029|…105` versus `…|00001|…105`: the same key with a different **voucher number**, because
the replay posted `cashpay-002-00029` to web voucher 00001. `LEDR_KEY` embeds `VCH_NO`, so every ledger key in that
voucher differed for a reason that said nothing about the application.

Voucher numbers come from `max(VCH_NO) + 1` across the book's tables, so the replay now inserts a throwaway row one
below the desktop's number, posts, and removes it. Being at a different `VCH_NO` the placeholder is never
compared. `AC_DATA.LEDR_KEY` fell 40 → 22, and better row pairing also took `rowsMissing` 207 → 198 and
`rowsExtra` 183 → 174 while comparing 297 more fields.

## What remains

```
PR_DATA          294      ROJ_MEL_DATA     259      RATE_CUT_ISU   220
AC_DATA          186      RATE_CUT_DATA    124      PR_DETL        105
MAIN_STOCK        21      SL_DETL           21
```

Top remaining columns are now semantic rather than representational: `AC_DATA.PARTY_AC_CODE` (the web writes an
account where the desktop leaves it blank, 66), `PR_DATA.BILL_NO` (the web defaults it to the voucher number where
the desktop leaves it blank, 51), and `PR_DATA.SL_BILL_LC` / `SL_BILL_YRCD` (the desktop carries the company's
location and year, the web leaves them blank, 51 each).

`MAIN_STOCK`'s residual 21 are in the sale, wholesale and cash builders, which this increment did not touch —
the same omission pattern, different modules.

`PR_DETL` (1,195) and `PR_DATA` (853) are next and are the same shape again. Their top columns split into two
kinds, and the distinction decides who fixes them:

- **denormalised copies the web does not carry** — `PR_DETL.IT_DESC` (`FINE GOLD`), `PR_CODE` (`FN`),
  `RATE_TYPE` (`G`), `WITH_STOCK` (`Y`). Real gaps.
- **blank-representation, per table** — `PR_DETL.TAG_NO` is `''` on the desktop where the web writes `'N'`. Note
  this is the OPPOSITE of `MAIN_STOCK`, where `'N'` is correct and was verified from `Ac_Stock.cs:54`. The
  sentinel is per-table, so the karigar `KR_DETL` change made in WP-08e must be re-checked against `KR_DETL`'s own
  desktop rows rather than assumed from `MAIN_STOCK`.

## Verification

- `156 test files / 1331 tests` pass; `tsc` and `prettier --check .` clean
- ceiling re-recorded at 70 cases / **3,199** differences; `parity-ratchet` PASS
- every number above reproduced by `pnpm parity:measure` from a clean replay

## 2.1f — The daybook: a measurement artefact fixed, and a real gap located

Field differences 898 → **863**, agreement **96.69%**.

### `ROJ_MEL_DATA.IT_DESC` was mine (54 differences)

The daybook's `IT_DESC` carries the ITEM's own name; `PR_DETL.IT_DESC` carries the description the operator typed
on that line. For item `ORG` those are "GOLD ORNAMENTS" and "NANO CHAIN" respectively. The replay seeded
`ITEM_MAST.IT_NAME` from the line description, so every replayed daybook row disagreed.

Now derived from the daybook rows themselves, by majority vote per item — the first attempt took the last name
seen and gave `OG` "COPPER KADALI" over its 7 rows of "OLD GOLD". Measured result: `ORG` GOLD ORNAMENTS (40),
`OR925` 925 SILVER ORNAMENTS (13), `OG` OLD GOLD (7), `OS` OLD SILVER (6), `999` FINE GOLD (5).

A second regression surfaced while doing it: the derived spec now covers all six families, so the purchase seeder
began creating book 027 — a SALE book — with `BOOK_TBL_NAME 'PR_DATA'`, and the sale replay failed with
"book 027 has conflicting BOOK_TBL_NAME values". Each replay now seeds only its own family's books.

### The real gap: purchases write no metal daybook row

The remaining daybook differences are **not** field values. The desktop's purchase daybook has row TYPES encoded
at offset 22 of `LEDR_KEY`, and their distribution across the captured purchases is:

| Type | Account | Item | Fine | Money | Rows | Reading |
| --- | --- | --- | --- | --- | --- | --- |
| `01` | contra | yes | no | yes | 43 | the item's MONEY row |
| `14` | **party** | yes | **yes** | no | 42 | the item's **METAL** row, carrying `ITM_FINE` |
| `08` | party | no | no | yes | 19 | the party money leg |
| `03` | contra | no | no | yes | 5 | settlement |
| `11`/`04`/`09` | contra | no | no | yes | 2 each | cheque / tax / other |

The web emits only type `01`. So **every purchase is missing its metal daybook row** — the row that carries fine
weight on the party. In a jewellery business the Rojmel metal columns are how gold movement is read, so this is a
business-visible omission, not a cosmetic one.

It also explains the row counts: many cases show equal desktop and web row totals with equal missing AND extra,
because the two sides' rows cannot pair on `LEDR_KEY` when the type segment differs.

**Not implemented here, deliberately.** Purchases reuse `buildSaleRojmel` with `outward = false`, so adding a
type-14 row means changing a builder that sales also use, and the existing `ROJMEL_ROW_TYPE` codes were derived
from SALE data — the file already warns that `Ac_Rojmel.Sales_Rojmel` is a later version than the code that wrote
this data, with sale item rows at `02` where the data has `01`. Purchase types must therefore be treated as their
own set, which the table above now establishes. That is the next increment, and it is worth doing properly rather
than by extending a sale-shaped builder late in a session.

## 2.1g — The purchase metal day-book row, implemented

```
                  before    after
fieldDifferences     863      814
agreement         96.69%   97.02%
rowsMissing          198      160
rowsExtra            174      143
fieldsCompared    26,092   27,346
```

### The rule, measured 51/51

A purchase line taken in at **no fixed rate** gets a metal day-book row. The correlation is exact across all 51
captured purchases: every voucher whose lines carry `ITM_RATE = 0` has one type-`14` row per line, and every
voucher with a rate has none. That is the business case — metal received before its price is fixed has a weight to
record against the party but no value to book yet.

The two item rows divide their columns cleanly, and this too is measured rather than reasoned:

| | type `01` money row | type `14` metal row |
| --- | --- | --- |
| account | contra | **the party** |
| gross / net / pieces | yes | yes |
| `ITM_FINE`, `ITM_TOUCH`, `ITM_WEST` | **always zero** | **carried** |
| `ITM_AMT`, `ITM_RATE`, `NET_AMT`, `LBR_AMT`, `OTH_AMT` | carried | **always zero** |

The money row is written only when the line has an amount, so the common unpriced purchase produces a metal row
alone. `ROJMEL_PURCHASE_ROW_TYPE` is a separate constant set from the sale codes, because `14` is the advance row
on a sale — the file already records that a type code only means something within the family it was measured in.

### The ratchet earned its keep twice

Adding the row made `fieldDifferences` **rise** 863 → 934 while rows improved (missing 198 → 160, extra 174 → 143)
and 1,254 more fields became comparable. The ratchet refused the run, and it was right to: the row now existed but
its values were wrong. Two rounds of fixing followed, each measured:

1. The purchase mapping passed only gross, net and rate, so the metal row booked **no fine at all** — the row's
   entire purpose. Adding touch, wastage and fine took it to 888. Still refused.
2. Those weights then appeared on BOTH rows, where the desktop keeps them off the money row. Writing purity twice
   would have made one purchase's fine weight readable twice. Scoping them to the metal row took it to **814**, and
   the ratchet passed with every tracked number improved.

Had the ratchet accepted the first attempt, the daybook would now carry a metal row with zero fine and duplicated
purity, and the field count would have been reported as progress.

### Three tests corrected, none weakened

- the inward unit test asserted `purchase[0]`, i.e. emission ORDER; day-book rows are identified by `LEDR_KEY`, so
  it now selects by row type and additionally asserts one metal row per line
- the lifecycle test required a debit on every metal row, which is true of the money row and false of the metal one
- the "paid in full" test's fixture omitted `rate` while citing real voucher 035/00001, which has `ITM_RATE 6780`;
  it described unpriced metal while claiming to model a priced voucher, so the fixture was given its rate

## 2.1h — Rate cut (wholesale), the least-correct family

```
                  before    after
fieldDifferences     814      688
agreement         97.02%   97.48%
```

`RATE_CUT_ISU` and `RATE_CUT_DATA` were the two largest remaining tables. Both were missing columns the desktop
writes on every row, derived here from the 20 captured lines and 15 headers:

| Column | Rule | Confidence |
| --- | --- | --- |
| `RATE_CUT_ISU.ENTRY_TYPE` | `'W'` — wholesale | 20/20 |
| `RATE_CUT_ISU.VCH_SRNO` | **0**, not the line ordinal | 20/20 |
| `RATE_CUT_ISU.ISU_LC_CODE` | the company's location | 20/20 |
| `RATE_CUT_ISU.TAG_GWT` / `TAG_NWT` | `ITM_GWT` / `ITM_NWT` | 20/20 |
| `RATE_CUT_ISU.KR_NET_WT` / `KR_FINE` | **`ITM_NWT`** | 19/20 |
| `RATE_CUT_DATA.USER_UPDATE` / `USER_DELETE` | `'N'` | 15/15 |
| `RATE_CUT_DATA.MOB_ENTRY_SAVE` | `'Y'` | 15/15 |

Two of these are worth stating plainly because they contradict a reasonable guess:

- **`VCH_SRNO` is 0, not a line number.** It is a TAG identity — `SR_NO` and `OLD_SRNO` carry the ordinal — and
  these lines are loose metal with no tag instance to name. The web wrote `i + 1`, inventing one.
- **`KR_FINE` equals NET WEIGHT, not fine weight.** On every line that carries weight. The single exception in each
  of the 19/20 pairs is a weightless line, not a counter-example to the rule.

The tag-weight columns were zero because the builder wrote only what the caller passed, and no caller passes a tag
weight for a loose line — so a column that is always populated in the real data was always empty in the web's.

## 2.1i — A metal liability that was not owed, and the cash-payment table set

```
                  before    after
fieldDifferences     688      662
agreement         97.48%   97.58%
```

### `PR_DATA.PARTY_FINE` — 26 differences

Non-zero exactly when every line carries `ITM_RATE = 0`, and zero whenever a rate was fixed: **51/51**. The same
selector as the metal day-book row, for the same reason — metal bought at an agreed price is settled in money, so
nothing is owed in metal.

The web summed the fine unconditionally, so **every priced purchase also credited the supplier a metal balance**.
That is a liability the shop does not owe, and it would appear in the party's gold position, not merely in a differ.

### The per-line narration — my replay's gap

`ReceiptPaymentLine.itDesc` exists and the mapper was not passing it, so `IT_DESC` compared blank on every cash
row. The desktop carries it per line: "AMDAVAD", "DIESEL ERTIGA", "VEGITABLES", "GIFT - CHANDALO LALO SHANGAR".

### Located, not fixed: cash payment writes the wrong tables

`cashpay-002-00029` compared table by table:

```
CASH_DATA        desktop 9   web 0
PAY_DATA         desktop 0   web 1
PAY_DETL         desktop 0   web 9
OP_LDR           desktop 2   web 0
TEMP_BOOK_DATA   desktop 1   web 0
```

The desktop writes **nine `CASH_DATA` rows** — one per payment, each with its own account, amount and narration,
carrying `REC_AMT` only (no `NET_AMT`, `TOT_AMT` or `CASH_AMT`; those columns are not in its `CASH_DATA` at all).
`postPaymentLines` instead writes one `PAY_DATA` header and nine `PAY_DETL` lines.

Book 002 declares `BOOK_TBL_NAME = 'CASH_DATA'`, so the module is writing a table set the book does not name. That
accounts for 9 of the run's missing rows and 10 of its extra ones, and it is not a column fix: it is a routing
decision that also governs edit and delete, so it belongs in its own increment with the delete path audited
alongside. `OP_LDR` and `TEMP_BOOK_DATA` are absent for the cash family too and likely share the cause.

An attempt to change it mid-session was reverted for that reason — the shape is clear but the reversal path is not,
and a voucher that cannot be correctly deleted is worse than one written to the wrong table.

### Why the cash-payment routing is not a one-line fix

Investigated further and deliberately left alone, because the two sides of the evidence disagree and the deciding
input is missing:

- **The desktop's data** puts this voucher's nine lines in `CASH_DATA` (book 002, `CPAY`, `CASH PAY`).
- **The web's model** is explicit and test-documented: `reopenVoucher.db.test.ts:315` records "a payment's header
  is `PAY_DATA`, not the `CASH_DATA`...", and its fixture seeds a book named "Cash Payment" with
  `BOOK_TBL_NAME 'PAY_DATA'`. `correctionWorkflow.db.test.ts:320` says the same and asserts against `PAY_DATA`.

The reconciliation is probably that the desktop writes `CASH_DATA` for a CASH payment and `PAY_DATA` for a BANK
one, and the web collapsed both onto `PAY_DATA` — which would make `mode` the selector. But the row that would
settle it is book 002's own `BOOK_TBL_NAME` in the desktop's `BOOK_DATA`, and `BOOK_DATA` is master data, so it is
not in any retained bundle. This replay SEEDS book 002 as `CASH_DATA`, so the parity result partly reflects that
choice rather than the desktop's configuration.

Changing it would also mean changing what both lines paths write (a summary row plus `PAY_DETL` today, N per-line
rows and no `PAY_DETL` in the desktop) and the two delete paths that reverse them. Guessing the selector and
rewriting a delete path on that guess is how a voucher becomes undeletable.

**What would settle it:** one `BOOK_DATA` extract for company 01 — book code, `BOOK_TBL_NAME`, `MAIN_BOOK`,
`BOOK_INOUT`. That single table would also fix the seeded slot ordering, which is currently derived by role.

## 2.1j — Rate-cut settlement inputs, and a valuation defect located

```
                  before    after
fieldDifferences     662      647
agreement         97.58%   97.64%
```

`CONV_PRC` is 99.5 on all 15 captured headers — a company conversion purity, not something retyped per voucher —
and the fine-settlement columns are 0 on 14 of 15 while the web derived 54.483. `RateCutInput` documents that "the
engine derives whatever is left at zero", so leaving them out let the engine invent a metal settlement. The replay
now passes the persisted `CONV_PRC`, `CONV_RATE`, `DR_FINE`, `CR_FINE`, `DR_AMT` and `CR_AMT`.

### `wsale-034-00015` values at zero — the rate lives on the header

The one case-level defect the loop has surfaced. Its six lines carry weight and fine but **no `ITM_RATE` and no
`ITM_AMT`**; the value is fixed at the header:

```
CR_FINE 11.06  ×  FINE_RATE 8900  =  98,434  =  SL_NET_AMT  =  SL_TOT_AMT
```

That is what rate cutting IS — fixing a rate against a fine balance. `postRateCut` takes `FINE_RATE` from
`totals.rate`, documented as "representative FINE_RATE for the metal leg (first line; single-rate is the common
case)", so with no line rate it resolves to 0 and the voucher values at **zero**. A voucher worth ₹98,434 posts as
nothing.

Not implemented here: it needs a header-level fine rate in `RateCutInput` and a valuation path that prices the
fine when lines carry no rate — a change to the family's money model, days after its row types were first derived.
It affects 1 of 70 cases in this bundle, but it is the shape of the family's core operation, so it should be
scoped deliberately rather than appended to a column pass.

## 2.1k — Rate-cut line columns, and where the remaining work is blocked

```
                  before    after
fieldDifferences     647      608
agreement         97.64%   97.78%
```

Four more columns, each 20/20 on the captured lines:

| Column | Rule |
| --- | --- |
| `DESIGN_IMG_ID` | `'N'` |
| `EMP_CODE` | the header's employee, carried onto every line |
| `ITM_REMARK` | the item's own name — 'BACHA KADALI - 916', 'FINE GOLD', 'DHAL OG' |
| `FINE_CUT_GWT` / `FINE_CUT_NWT` | **0** |

`FINE_CUT_*` is the one worth explaining. The web copied the line's gross and net weight into it. Those columns
record a weight CUT against a fine balance, which is a different act from the metal being issued — and `ITM_GWT`,
`ITM_NWT` and the tag weights already carry the line's own weight. On a rate-cut voucher a duplicated weight is a
duplicated metal position.

### The remaining differences are blocked on two missing inputs

`ROJ_MEL_DATA` on wholesale, compared row by row for `wsale-034-00001`:

```
desktop   type=04  AC=00003  LD=000208(party)  all zero
web       type=03  AC=000208 LD=00098          FINE=54.483   <- row the desktop does not have
web       type=04  AC=00098  LD=000208         all zero      <- right row, wrong account
```

Both differences trace to inputs this environment does not have:

1. **The book's account slots.** The type-04 row names `00003`; the web names `00098`, which is what this replay
   assigned to slot 1 by role. Three of book 034's five slots (`kasarAc`, `lbrAc`, `othAc`) were filled from the
   leftovers and LOGGED as unverified at the time, precisely so a difference here would be attributable. It is.
2. **The metal settlement.** The web still derives `CR_FINE` 54.483 and writes an extra type-03 row for it, even
   with the desktop's `CR_FINE = 0` passed explicitly — so the derivation is not suppressed by the input alone.

One `BOOK_DATA` extract for company 01 — book code, `BOOK_TBL_NAME`, `MAIN_BOOK`, `BOOK_INOUT`, and the
`BOOK_DETL` slot rows — would settle the slot ordering, the cash-payment routing question above, and probably this
row's account in one go. It is the single highest-value missing artefact for continuing this work.

## Session summary

```
                 start     end     change
fieldDifferences  3,813     608     -84%
agreement        83.94%  97.78%   +13.8pt
rowsMissing         210     159
rowsExtra           210     143
families              2       6
cases                66      70
```

Eleven measured increments. Every number reproducible with `pnpm parity:measure`; the ceiling is recorded and
enforced in CI and in release certification.

## 2.1l — FIXED: a ₹98,434 voucher that posted as zero

```
                  before    after
fieldDifferences     608      574
agreement         97.78%   97.90%
```

The defect located in 2.1j is now fixed rather than only recorded, because a voucher valuing at zero is the most
business-serious thing this comparison has found.

**The cause.** `rollup` takes `FINE_RATE` from the first line, documented as "single-rate is the common case". Real
voucher `wsale-034-00015` carries no `ITM_RATE` and no `ITM_AMT` on any of its six lines and fixes the price at the
header instead. Every line-summed total was therefore 0, and the voucher posted with no value at all.

**The desktop's arithmetic, which the fix follows exactly:**

```
CR_FINE 11.06  ×  FINE_RATE 8900  =  98,434  =  SL_NET_AMT  =  SL_TOT_AMT
```

Rate cutting IS fixing a rate against a fine balance, so the header form of it is not an edge case — it is the
operation's own shape.

**The change.** `RateCutInput.fineRate` supplies the voucher's rate; `rollup` uses it only when no line carries one;
and `SL_TOT_AMT` / `SL_NET_AMT` fall back to `settleCrFine × FINE_RATE` only when the line sum is zero. Both
fallbacks are strictly additive: a voucher whose lines carry rates or amounts cannot change, which two of the three
new unit tests pin directly.

**Verified against the real voucher**, not just in principle:

```
RATE_CUT_DATA  VCH_NO 00015   SL_NET_AMT 98434   FINE_RATE 8900     (desktop: 98434 / 8900)
```

**Still wrong on that header:** `CR_FINE` persists as 88.106 (the lines' total fine) where the desktop holds 11.06
(the fine being cut). The replay passes 11.06 explicitly and the module still derives its own, so the settlement
derivation ignores the supplied value. That is the next thread on this family.

**Also fixed:** the wholesale replay did not clear its own book when sharing a tenant, so a re-run appended a second
set of vouchers at 16–30 instead of replacing 1–15. Any measurement taken after two runs was comparing whichever
numbers the case list happened to name.

## 2.1m — The settlement fine legs: metal credited that was never settled

```
                  before    after
fieldDifferences     574      510
agreement         97.90%   98.17%
rowsMissing          159      153
rowsExtra            143      137
```

The header wrote the lines' total fine into the SETTLEMENT columns. Measured across the 15 captured headers:

| Column | Desktop | Web wrote | Correct on |
| --- | --- | --- | --- |
| `SL_FINE` | the lines' total fine | the lines' total fine | 14/15 already |
| `TOT_FINE_DR` | the lines' total fine | **0** | 13/15 after fix |
| `CR_FINE` | **0** | the lines' total fine | 14/15 after fix |
| `DR_FINE` | 0 | 0 | 14/15 already |
| `TOT_FINE_CR` | **0** | the lines' total fine | 13/15 after fix |

The distinction is the point: **`SL_FINE` is the metal the voucher HANDLES; `CR_FINE` is the metal it SETTLES.**
Writing the handled fine into the settlement column credited the party a metal balance for the whole consignment on
every voucher, when in 14 of 15 real ones nothing was settled in metal at all. On a wholesale metal desk that is a
gold liability appearing from nothing.

`CR_FINE` and `DR_FINE` now take the caller's settlement values, so `wsale-034-00015` — the one voucher that does
settle in metal — keeps its 11.06 and 5.92.

`FINE_CUT_FINE` was also copying the line's fine where the desktop holds **0 on all 20 lines**, the same mistake
already fixed for `FINE_CUT_GWT` and `FINE_CUT_NWT` and missed on the third sibling. The line's own fine is in
`ITM_FINE`; these columns record fine cut against a balance, which these vouchers settle at the header.

`PR_CODE` is now accepted per line ('BK', 'FN', 'DH' on the captured rows).

**Open and not guessed:** two non-zero `TOT_FINE_CR` values (21.064 and 50.19) have no derivable relation to any
available input, so that column defaults to 0 — right on 13 of 15, and those two stay recorded rather than fitted.
