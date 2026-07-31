# First real desktop-vs-web comparison

**Status: the comparison exists.** For the first time in this project, a real customer voucher has been
replayed through the web and diffed field by field against what the desktop actually stored. Every parity
claim before this rested on derivation. This one rests on comparison.

**Artifact:** `project-memory/parity/g5/parity-diff-2026-07-31T21-47-29-187Z.json`
**Case:** `Live24` book `027` voucher `00001`, 2024-04-06 — a silver tax invoice, 2 lines, party `000888`.
**Result:** `G5_RED — 118 field differences over 271 compared fields`.

`g5:parity` was RED before this and is RED after it. The difference is that it was previously red for
**absence of evidence** and is now red for **evidence of difference**, which is the only kind of red worth
acting on.

---

## 1. Read the 118 correctly

Reporting "118 differences" would overstate the case. Broken down by what each actually is:

| Class                             | Count  | What it means                                                                     |
| --------------------------------- | ------ | --------------------------------------------------------------------------------- |
| **Differ artifact**               | **19** | Not differences. The two sides canonicalise the same number to different strings. |
| **Column unpopulated by the web** | **58** | Real, but a distinct class: the desktop writes a value, the web writes NULL.      |
| **Genuine value difference**      | **41** | Of which roughly half are the differ pairing the wrong rows — see §2.             |

So the honest headline is **≈20 substantive behavioural differences**, concentrated in three rules, plus 58
unpopulated columns, plus two defects in the comparison tool itself.

---

## 2. Two defects in the comparison tool, found by using it

Both inflate and obscure the result, and neither was visible while the harness had never run on real data.
The 24 existing unit tests pass because they use synthetic bundles where both sides share a schema.

### 2.1 Numeric scale is applied per side, not commonly

`canonicalise(value, type, scale)` in `parity/bundle.ts:188` formats with `fixed(n, scale)` using **each
side's own declared scale**. SQL Server `numeric(18,6)` against Postgres `numeric(_,2)` turns an identical
zero into `0.000000` versus `0.00` and reports a difference.

Confirmed instances: `SL_DATA.ADV_AMT`, `OLD_GL_AMT`, `OLD_SL_AMT` — all `0` on both sides, all reported.
**19 of the 118.**

### 2.2 Row pairing cannot tell two lines apart

`MAIN_STOCK` rows are matched on `TAG_NO` + `VCH_SRNO` + `ITM_SIGN`. On an untagged sale all three are
constant across lines, so the differ paired **line 1 against line 2**:

```
MAIN_STOCK.IT_CODE   desktop=ORS    web=MA925     <- desktop line 2 vs web line 1
MAIN_STOCK.IT_CODE   desktop=MA925  web=ORS       <- desktop line 1 vs web line 2
```

Every numeric column in those rows then differs for a reason that has nothing to do with the web's
behaviour. `SR_NO` is present and distinguishes them; the pairing key must include it.

**Until both are fixed the artifact cannot be used to certify anything** — which is why `g5:parity` staying
RED is correct even though the underlying agreement is much closer than 118 suggests.

---

## 3. The substantive differences

### 3.1 The desktop rounds amounts to whole rupees; the web keeps paise

The single largest source of real difference.

| Field                                                | Desktop     | Web     |
| ---------------------------------------------------- | ----------- | ------- |
| line 2 metal (4.600 × 77)                            | **354.00**  | 354.20  |
| line 2 labour (4.600 × 16.09)                        | **74.00**   | 74.01   |
| line 2 net                                           | **428.00**  | 428.21  |
| header `NET_AMT`                                     | **1515.00** | 1515.21 |
| header `TOT_AMT`, `BILL_OS`, `BILL_OS_DATA.BILL_AMT` | **1560.00** | 1560.67 |

Measured across the whole real dataset, not inferred from this voucher:

```
SL_DETL  245 rows: ITM_AMT non-integer 0   LBR_AMT non-integer 0   NET_AMT non-integer 0
SL_DATA  190 rows: NET_AMT non-integer 0   TOT_AMT non-integer 0
                   TAX_AMT non-integer 91  ROF_AMT non-zero 0
```

So the rule is precise and consistent: **amounts are rounded to whole rupees, tax is not, and the round-off
column is never used.** Rounding, not truncation — 354.20 → 354 and 7436.80 → 7437.

The desktop's own labour _rate_ is rounded to 2 dp by `CO_SET.LBR_ROF = 2`, applied as the decimal-place
argument to `Math.Round` (`TR_SALE.cs:11017`). `LBR_RATE = 16.09` is consistent with that. The amount
rounding is separate and this customer's `CO_SET` has **no `TOT_AMT_ROF` column at all**, though
`MS_OPNCOMP.cs:991` reads one — another instance of the source being a later version than the data.

**What this means for parity:** the web needs a whole-rupee amount mode. It cannot be hardcoded, because the
desktop plainly supports 2 dp elsewhere; it is configuration this customer sets. **The setting that drives it
has not been located in this database, so the mechanism is unresolved and is recorded as such rather than
guessed.**

### 3.2 The desktop leaves 89 sale vouchers out of balance, and the web will not

Because `TOT_AMT` is rounded to a whole rupee while `TAX_AMT` keeps paise, the residue goes nowhere:

```
027/00001   Dr 1560.00   Cr 1560.45   diff -0.45
```

Across the whole real ledger:

```
1567 vouchers: balanced 1468   UNBALANCED 99
  book 026  55 vouchers  max |diff| 0.50     book 041   3   0.37
  book 027  25 vouchers  max |diff| 0.47     book 032   2   0.17
  book 029   8 vouchers  max |diff| 0.45     books 035/036/030  1 each  <= 0.24
  book 052   2 vouchers  max |diff| 250      (karigar - a different problem, not rounding)
  book 000   1 voucher   max |diff| 1121150  (the opening carry, already known to be unbalanced)
```

**89 sale vouchers carry a sub-rupee imbalance with no round-off leg.** A kasar account exists — `BOOK_DETL`
slot 3 is `00057 KASAR A/C` — and is simply not used for this.

This is a **direct conflict with a web invariant**: the web balances every voucher. Reproducing the
desktop's arithmetic exactly means writing a knowingly unbalanced ledger. **This needs an owner decision**
and is the same class of question as the reproduced fine double-count: parity with a defect, or correctness.

### 3.3 `TAX_DATA` rows carry the wrong type and a rounded amount

```
TAX_DATA.TAX_TYPE  desktop=SGST   web=N       TAX_DATA.TAX_AMT  desktop=22.725  web=22.730
TAX_DATA.TAX_TYPE  desktop=CGST   web=N       TAX_DATA.TAX_AMT  desktop=22.725  web=22.730
```

Two distinct defects in one place:

**The type.** The desktop writes one row per component, typed `SGST` and `CGST`. The web writes the parent
group `N` on both. So a tax report grouping by `TAX_TYPE` cannot split the halves at all.

**The amount.** The desktop stores the half **unrounded** at `22.725`; the web rounds to `22.730`. This
confirms from the opposite direction a fact already recorded about the Postgres schema — `SL_DATA.CGST_TAX`
and `SGST_TAX` are `double precision` with no scale precisely so the unrounded half fits. The web's own
schema was built for the right value and the code puts a rounded one in it.

### 3.4 Columns the web leaves NULL — 58 of them

The largest count, the least individually severe, and worth working through because a NULL where the desktop
has a value can break a report filter. Examples, each verified present on the desktop row:

`SL_DATA.OS_ADJ_AMT` `CR_DAYS` `EMP_CODE` · `TAX_DATA.R_CHARG` `ISR_NO` `TAX_FREE_AMT` ·
`BILL_OS_DATA.USER_DELETE` · `MAIN_STOCK.ITM_WEST` `TBL_CODE` `ISR_NO`

Some are replay-harness omissions rather than web defects — `EMP_CODE` was never supplied as an input, for
instance. **These need separating one by one before any is called a defect.**

### 3.5 Stock tagging

```
MAIN_STOCK.TAG_NO    desktop=MAS00013            web=N
MAIN_STOCK.VCH_SRNO  desktop=100211101051.000000 web=0.000000
```

The desktop sold a **tagged** stock instance and recorded which one. The replay sold untagged, so this may be
an input difference rather than a behavioural one — but `VCH_SRNO` being a 12-digit composite is worth
understanding before assuming so.

### 3.6 Known and accepted

`OP_LDR: WEB NEVER WROTE THIS TABLE (2 desktop rows)` — the year-end carry model difference already recorded
in `TECHNICAL-REFERENCE.md` §7. Not a new finding, and the two rows appearing under this voucher's key are an
extractor filter artifact rather than a per-voucher write.

`SL_DATA.BILL_NO` desktop blank, web `00001`; `AC_NAME` and `BOOK_NAME` differ because the replay seeds
placeholder masters — live customer names are deliberately not copied into fixtures.

---

## 4. Four defects found before the diff even ran

Getting the first voucher to post at all surfaced these. Each was a real blocker, none was visible from
reading code.

**1. No sale could be posted against any real GST tax master.** `resolveTaxPolicyTx` selects every
`TAX_MAST` row for a code and rejects the code if their identities differ — but a GST code's rows _are_
different, because they are its SGST/CGST/IGST breakdown. Measured on the real database, **all five GST codes
collide**: parent against IGST at 3/5/12/18/28%, and SGST against CGST at each half rate. First replay
attempt failed with `tax code has conflicting configuration: 10`.

_Fixed._ Selecting by code now pins `SR_NO = 0`, the parent — which is how the desktop's own tax queries do
it (`AND D.SR_NO = 0`). The conflict check is retained for the percentage-only path, where two different
codes sharing a rate is a genuine ambiguity.

**2. `labourFixed` is silently discarded without `labourType`.** `const labour = line.labourType ? … : 0`
(`sales.ts:267`). The replay's line 1 carried `labourFixed: 1087` and contributed **zero**, with no error.
The web reported a total of 441.06 against the desktop's 1560.00. It was only caught because a real figure
was sitting beside it to disagree with — no test would have noticed, and a caller in production would lose
the money silently. **Worth a guard: reject `labourFixed` without a `labourType`.**

**3. The PG extractor could never read an RLS-scoped tenant.** `parity-extract-pg.mjs` connected with
`DATABASE_URL` and never set `app.tenant_id`, so RLS filtered every table to nothing and it reported
`voucher 027/00001 wrote no rows` for a voucher that was present. Reads as a missing voucher, not as a
permissions problem — the documented trap, inside the harness built to find such things. _Fixed:_ reads are
wrapped in a transaction that sets the tenant context, which is required for the application role and
harmless for the owner.

**4. `BOOK_DETL` needs `BOOK_INOUT`, and `LC_CODE` is `'00'`.** `resolveBookAccountTx` filters on
`BOOK_INOUT`, which the replay set on `BOOK_DATA` only. And the real database uses `LC_CODE = '00'`, not
`'01'` — querying with `'01'` returned nothing, which briefly read as _"book 027 has no account slots"_ and
was written down as a finding before the count of books lacking `BOOK_DETL` contradicted it. Book 027 has
**eight** slots, slot 1 being `00004 SALES SILVER A/C` — exactly the contra the real ledger names, so the
web's slot-1 resolution is confirmed correct.

---

## 5. What was confirmed to agree

Worth stating, because a diff report only lists disagreements:

- **Ledger shape.** Three legs, same accounts, same directions: party `000888` debited, `00004` credited the
  net, `00085` credited the tax. `LD_CODE` correct on all three.
- **`BOOK_DETL` slot 1** resolves to the account the desktop used.
- **Tax split direction** — intra-state, IGST zero, halves on CGST/SGST.
- **Voucher numbering** `00001`, 5-char zero-padded.
- **Line count, item codes, weights, pieces** and the derived labour rate `16.09`.
- **271 fields were compared and 132 matched exactly**, including every date and key column.

---

## 6. Next, in order

1. **Fix the two differ defects** (§2) — canonicalise numerics to a common scale, and include `SR_NO` in the
   row-pairing key. Without this no comparison can be trusted, and both must be proven with a control.
2. **Re-run and re-triage.** The real count is expected near 20, not 118.
3. **Resolve the whole-rupee rounding mechanism** (§3.1) — find the setting, or establish that the version
   that wrote `Live24` hardcoded it. This is the largest single source of difference.
4. **Fix `TAX_DATA`** (§3.3) — one row per component with the correct `TAX_TYPE`, and stop rounding the
   halves. This one is unambiguous and needs no decision.
5. **Owner decision on the imbalance** (§3.2) — 89 vouchers. Reproducing it means writing an unbalanced
   ledger deliberately.
6. **Triage the 58 NULLs** (§3.4), separating replay omissions from web gaps.
7. **Then widen**: the same nine books, and the estimate/return/purchase families, before treating any of
   this as characteristic.

**Standing caveat.** This is **one voucher, one book, one company, one year**. It found four blockers and
three behavioural differences, which says more about how much unexamined surface remains than about how
close the two systems are.
