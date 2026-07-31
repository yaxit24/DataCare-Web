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

| Class                             | Count  | What it means                                                                |
| --------------------------------- | ------ | ---------------------------------------------------------------------------- |
| **Schema type mismatch**          | **19** | _Was written up as a differ artifact. It is not — see the retraction below._ |
| **Column unpopulated by the web** | **58** | Real, but a distinct class: the desktop writes a value, the web writes NULL. |
| **Genuine value difference**      | **41** | Of which roughly half are the differ pairing the wrong rows — see §2.        |

So the honest headline is **≈20 substantive behavioural differences**, concentrated in three rules, plus 58
unpopulated columns, plus two defects in the comparison tool itself.

---

## 2. Two defects in the comparison tool, found by using it

Both inflate and obscure the result, and neither was visible while the harness had never run on real data.
The 24 existing unit tests pass because they use synthetic bundles where both sides share a schema.

### 2.1 RETRACTED — this was not a differ defect

**What I wrote first:** that `canonicalise` applies each side's own numeric scale, so an identical zero
renders `0.000000` against `0.00`.

**Why it was wrong:** `comparisonScale` already takes `Math.min` of the two declared scales, deliberately, so
neither side is held to precision it does not store. The differ was behaving correctly.

**What is actually happening:** the two columns are genuinely different types.

```
SL_DATA.ADV_AMT   desktop float   web character varying
```

The desktop value takes the numeric branch and renders `0.000000`; the web value takes the **text** branch and
renders `0`. The differ reported a real difference and I misattributed it to the tool.

Measured across the whole schema this is systematic: **226 of 5231 shared columns (4.3%) are numeric on the
desktop and text in Postgres — 226 in that direction, zero in the other.** Worst affected:
`RATE_CUT_DATA` 40, `SL_DATA` 22, `BAR_DETL` 16, `GROUP_MAST` 14, `SL_DETL` 14, `RATE_CUT_ISU` 14.

It matters because `SUM` needs a cast that can throw at query time, `ORDER BY` sorts `'9'` after `'10'`, and
the column carries no domain guarantee. `pnpm type:parity` now gates it: the 226 are baselined so a NEW one
fails, exit code 1, control proven by removing one from the baseline.

**The lesson is one already recorded twice:** the first explanation that fits is not evidence. I had a
plausible mechanism and did not check the column metadata until the numbers refused to add up.

### 2.2 Row pairing cannot tell two lines apart

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

## 3. The substantive differences, triaged

Every row below is measured against the real customer database, and each is placed in one of four
categories: **fixed**, **deliberate divergence**, **unresolved**, or **owner decision**. The distinction
matters more than the count — "93 differences" is not a to-do list.

### 3.1 Fixed

| What                 | Desktop                 | Web was                 | Evidence                                                          |
| -------------------- | ----------------------- | ----------------------- | ----------------------------------------------------------------- |
| `AC_DATA.LEDR_KEY`   | 23 chars, `VCH_NO` in 5 | 24 chars, `VCH_NO` in 6 | real key `01002024-20250270000101`; `ROJ_MEL_DATA` already used 5 |
| `MAIN_STOCK.ITM_QTY` | `1`                     | net weight (10.360)     | all 267 sale-book rows are `1`; integer on all 1856               |
| `SL_DATA.LBR_AMT`    | `0.00`                  | 1161.01 (sum of lines)  | `0.00` on all 190 headers, though 100 carry line labour           |
| tax resolution       | pins `SR_NO 0`          | rejected the code       | all five GST codes collide parent-against-IGST                    |

### 3.2 Deliberate divergence — keep, and know why

**`SL_DETL.ITM_CGST_AMT` / `ITM_SGST_AMT`.** Zero on all 245 real rows; the web populates them. **Not
"fixed", deliberately.** The web reads these columns in four places the desktop has no equivalent for —
`gst/gst.ts:200` sums them for the GST return, `einvoice/einvoice.ts:699` builds the e-invoice payload, and
`documents/docChrome.ts:214` prints the invoice. The desktop keeps only a per-line _total_ (`IT_TAX_AMT`,
non-zero on 132 rows) and splits at the header (`SL_DATA.CGST_TAX` / `SGST_TAX`).

Zeroing them for byte parity would break the GST return and e-invoicing. The cleaner long-term shape is to
derive the split from `IT_TAX_AMT` at read time and stop storing it, which is a four-site refactor and not
worth doing before more vouchers are compared. **Recorded as a divergence with a reason rather than logged as
a defect.**

**`SL_DATA.ROF_AMT` and the fourth ledger leg.** The desktop stores `ROF_AMT 0.00` on all 190 headers and
posts three legs; the web computes `roundOff -0.45` and posts a fourth leg to kasar (`00057`). See §3.4.

### 3.3 Unresolved — measured, not derivable, deliberately not guessed

**`SL_DETL.TOT_AMT`.** The desktop is internally inconsistent and no rule fits.

```
untaxed lines (113):  TOT_AMT = NET_AMT on all 113          consistent
taxed lines   (132):  TOT = NET+tax on 36,  TOT = NET on 94  NOT consistent
  book 026:  3 as NET+tax,  74 as NET
  book 027: 32 as NET+tax,   8 as NET
```

The 8 exceptions in book 027 are whole vouchers (00009 all six lines, 00013, 00014), and their headers,
tax code, tax percentage, book and even operator match vouchers that follow the other convention. The
**headers are uniform** — `TOT_AMT = NET_AMT + tax` on every one of the five checked — so only the line
column varies. That is consistent with a grid display column that is not always recalculated before save.

**No rule is implementable from this evidence, so none was written.** The web currently writes `NET_AMT`,
which matches the 94-row majority and the untaxed 113.

**`MAIN_STOCK.SR_NO`.** The desktop writes `1` on **both** rows of a two-line sale and distinguishes them by
`TAG_NO`; the web numbers them 1 and 2. Across 63 multi-row sale vouchers, 41 have all serials identical and
20 increment — **mixed, so not a single rule.** Left alone; the differ's pairing key deliberately excludes
`SR_NO` so this stays visible rather than being papered over.

**`SL_DETL.KR_NET_WT` / `KR_TOUCH` / `KR_FINE`.** Populated on the desktop (`KR_FINE` non-zero on 102 of 245
rows), zero in the web. These are karigar attribution on the sold item. The replay supplied no karigar, so
part of this is an input difference — but 102 of 245 is too many to dismiss, and it needs a voucher whose
karigar is known before the write path can be judged.

**`SL_DETL.TAG_GWT` / `TAG_NWT`.** The reverse: zero on the desktop for this voucher, populated by the web.
`TAG_NWT` is non-zero on 103 of 245 real rows, so the column is used — the question is when, and that needs a
tagged replay.

### 3.4 Owner decision

**89 sale vouchers are out of balance on the desktop.** `TOT_AMT` is a whole rupee while `TAX_AMT` keeps
paise, and the residue is posted nowhere:

```
027/00001   Dr 1560.00   Cr 1560.45   diff -0.45
1567 vouchers: balanced 1468, UNBALANCED 99
  026: 55 (max 0.50)   027: 25 (0.47)   029: 8 (0.45)   041: 3   032: 2   035/036/030: 1 each
  052:  2 (max 250 - karigar, a different problem)   000: 1 (the opening carry, already known)
```

The web posts the residue to kasar (`BOOK_DETL` slot 3, `00057`) and balances. **The web is arguably more
correct and definitely more auditable.** Reproducing the desktop means deliberately writing an unbalanced
ledger. Same class of question as the reproduced fine double-count on overpaid purchases.

**The desktop does use that kasar account** — book 027's `AC_DATA` has 15 rows of leg type `26` naming
`00057` — just not for this residue.

### 3.5 Leg type codes — measured, mapping not yet written

A plain credit sale writes leg types **01 / 03 / 04** (party, sales account, tax). The web writes a bare
sequence **01 / 02 / 03**. Book 027 also uses `09/10`, `19/20` and `25/26` for other settlement shapes:

```
type 01  25 rows  party        type 09   5   type 19  15   type 25  15
type 03  25 rows  sales a/c    type 10   5   type 20  15   type 26  15  (00057 kasar)
type 04  25 rows  tax
```

So the codes are **semantic per leg role and per settlement shape**, not a sequence. Deriving a mapping from
one voucher would pin a wrong answer for the other six shapes. **Needs measuring per family first** — the
same discipline that cut rate cut from 40 row types to 9.

### 3.6 Harness artifacts, not findings

`AC_NAME`, `PARTY_NAME`, `LDR_NAME`, `BOOK_NAME` differ because the replay seeds placeholder masters — live
customer names are deliberately never copied into fixtures. `EMP_CODE` and the `TAG_NO` / `VCH_SRNO` pair
differ because the replay supplied no employee and sold untagged stock.

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
