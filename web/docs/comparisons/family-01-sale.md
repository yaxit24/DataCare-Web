# Family 1 — Sale (tax invoice)

**Books** 026 / 027 / 029 / 030 / 032 · **556 real ledger rows** · **Desktop source** `TR_SALE.cs` (21,586 lines),
`Ac_Ledr.cs`, `Ac_Tax.cs`, `Ac_Rojmel.cs`

**Reference voucher** `Live24` book `027` voucher `00001`, 2024-04-06 — 2 lines, party `000888`, `TOT_AMT` 1560.00.
Line 1 is a **tagged, labour-only** line (`MAS00013`, no metal value); line 2 is untagged metal + labour.

**Artifact** `project-memory/parity/g5/parity-diff-*.json` (git-ignored — carries live customer names)
**Replay** `apps/api/integration/parity-replay-sale.mjs`, run under `PARITY_STRICT=1`

---

## Result

| Measure                                        | Value                               |
| ---------------------------------------------- | ----------------------------------- |
| Fields compared                                | **672**                             |
| Raw differences                                | 140                                 |
| Schema type mismatches                         | **0** (was 19, closed by Phase 0.4) |
| Columns the web leaves NULL                    | 112                                 |
| Replay-harness artifacts (placeholder masters) | 19                                  |
| **Substantive differences**                    | **10**                              |
| **Implementable defects remaining**            | **0**                               |

Fields compared rose 271 → 540 → 672 during this work, as Phase 0 fixed the differ's row pairing and then
`ROJ_MEL_DATA` gained a `ROW_KEYS` entry. The early "0 differences" in those tables meant _nothing paired_.

---

## Fixed — nine defects

| #   | Defect                                                      | Evidence                                                |
| --- | ----------------------------------------------------------- | ------------------------------------------------------- |
| 1   | No sale could post against **any** real GST tax master      | all five GST codes collide parent-vs-IGST on percentage |
| 2   | `AC_DATA.LEDR_KEY` one character too long                   | desktop key is 23 chars, `VCH_NO` in 5                  |
| 3   | Leg type codes were a **sequence**, not semantic            | 01 party / 03 revenue / 04 tax; `02` on no sale book    |
| 4   | No `LEDR_KEY` uniqueness — duplicate legs inserted silently | desktop has `PK_AC_DATA` on `LEDR_KEY`                  |
| 5   | `MAIN_STOCK.ITM_QTY` held the net weight                    | `1` on all 267 sale-book rows; integer on all 1856      |
| 6   | `SL_DATA.LBR_AMT` totalled line labour                      | `0.00` on all 190 headers, though 100 have line labour  |
| 7   | Line components not rounded                                 | all 245 rows whole rupees; composition holds on 244     |
| 8   | `TAX_DATA.TAX_TYPE` was the parent group `N`                | 184 rows are SGST at `SR_NO 1`, CGST at 2, never `N`    |
| 9   | `IT_TAX_AMT` rounded twice (`half × 2`)                     | equals `ROUND(net × rate, 2)` on all 132 taxed rows     |
| 10  | `ROJ_MEL_DATA.ITM_AMT` held the line net                    | mirrors `SL_DETL.ITM_AMT`; 0 on a labour-only line      |
| 11  | `TAG_GWT`/`TAG_NWT` written on untagged lines               | non-zero on 102/102 tagged, 1/143 untagged              |
| 12  | `KR_NET_WT` written as 0                                    | non-zero on all 245 rows, equals `ITM_NWT` on 235       |
| 13  | `KR_TOUCH`/`KR_FINE` written as 0                           | copied from `BAR_DETL` on **102 of 102** tagged lines   |

(Numbered 13 because three were found in pairs.)

### Three that were nearly got wrong

**`KR_FINE` looked derived.** The reference line satisfies `net × touch/100` **exactly** — 10.360 × 92.5% =
9.583. A sample of one said "formula". Measured across 92 rows it fits **7**. The rule is a copy from the tag.

**The `ITM_AMT` derivation looked reproducible.** `ROUND(nwt × rate, 0)` fits 134 of 220 rows, because the
desktop grid lets the operator overtype an amount. Only the _rounding_ was implemented, not the formula.

**A discount leg looked missing.** The discount account `00076` never appears in the ledger on any sale book —
the desktop nets a discount into the amount. Recorded, not acted on.

---

## Deliberate divergence — 4 differences

**`SL_DETL.ITM_CGST_AMT` / `ITM_SGST_AMT`.** Zero on all 245 real rows; the web populates them.
**Not "fixed", deliberately.** The web reads them in three places the desktop has no equivalent for —
`gst.ts:200` sums them for the GST return, `einvoice.ts:699` builds the e-invoice payload, `docChrome.ts:214`
prints the invoice. The desktop keeps only a per-line total in `IT_TAX_AMT` and splits at the header.

Zeroing them for byte parity would break GST returns and e-invoicing to match a column the desktop leaves
empty. The cleaner long-term shape is to derive the split from `IT_TAX_AMT` at read time — a four-site
refactor, not worth doing before more families are compared.

---

## Unresolved — measured, not derivable, deliberately not guessed

**`SL_DETL.TOT_AMT` (2 differences).** The desktop is internally inconsistent.

```
untaxed lines (113):  TOT_AMT = NET_AMT on all 113          consistent
taxed lines   (132):  TOT = NET+tax on 36,  TOT = NET on 94  NOT consistent
  book 026:  3 as NET+tax,  74 as NET       book 027: 32 as NET+tax,  8 as NET
```

The 8 exceptions in book 027 are whole vouchers (00009 all six lines, 00013, 00014) whose header, tax code,
percentage, book **and operator** match vouchers following the other convention. The headers are uniform at
`NET + tax`. That fits a grid display column not always recalculated before save. **No rule is implementable,
so none was written.** The web writes `NET_AMT`, matching the 94-row majority and all 113 untaxed.

**`MAIN_STOCK.SR_NO` (1).** The desktop writes `1` on **both** rows of a two-line sale; the web numbers them 1
and 2.

Two correlations were tested rather than leaving this at "mixed". The first is strong:

```
all rows tagged (15 vouchers):   identical 15,  incrementing 0
some rows tagged (13):           identical 13,  incrementing 0
no rows tagged  (35):            identical 13,  incrementing 20
```

**Whenever any row is tagged, the serial is identical — 28 of 28.** Incrementing occurs only on all-untagged
vouchers. That is not a date effect: the two patterns interleave through the year.

The residue is per-book, and only partly:

```
book 027, untagged multi-row:   5 vouchers, ALL identical
book 032, untagged multi-row:  30 vouchers, 8 identical and 20 incrementing
```

So for **book 027 — the reference book — the serial is always 1**, which fully explains the reference voucher's
difference. Book 032 splits 8/20 with no discriminator found in tagging, date or line count.

**Not implemented, deliberately.** A rule of "1 on book 027, incrementing on 032" has no mechanism behind it,
and book 032 contradicts itself anyway. Writing it would encode a coincidence as a specification — the same
error avoided with `ITM_AMT`'s derivation and `KR_FINE`'s formula. The differ's pairing key excludes `SR_NO` so
this stays visible when a later family or a second database supplies the missing discriminator.

---

## Owner decision — 1 difference

**`SL_DATA.ROF_AMT`: the desktop leaves 89 sale vouchers out of balance.** `TOT_AMT` is a whole rupee while
`TAX_AMT` keeps paise, and the residue is posted nowhere.

```
027/00001   Dr 1560.00   Cr 1560.45   diff -0.45
1567 vouchers: balanced 1468, UNBALANCED 99
  026: 55 (max 0.50)  027: 25 (0.47)  029: 8 (0.45)  041: 3  032: 2  035/036/030: 1 each
  052:  2 (max 250 — karigar, unrelated)   000: 1 (the opening carry, already known)
```

The web posts the residue to kasar (`BOOK_DETL` slot 3, `00057`) and balances — arguably more correct and
definitely more auditable. Reproducing the desktop means deliberately writing an unbalanced ledger. The
desktop **does** use that kasar account — book 027 has 15 ledger rows of leg type `26` naming it — just not for
this.

**Blocks:** family 1 closure as _byte_-identical, and the Phase 5 reconciliation set.

---

## Exit criteria

| #   | Criterion                                              | State                                                            |
| --- | ------------------------------------------------------ | ---------------------------------------------------------------- |
| 1   | 0 unexplained field differences                        | **met** — all 10 explained above                                 |
| 2   | Every difference in one of four categories, in writing | **met**                                                          |
| 3   | Every real row type produced, or its absence explained | **met** — 3 leg types + settlement pairs measured                |
| 4   | Write set asserted as an exact set                     | met (pre-existing)                                               |
| 5   | Edit and delete covered                                | met (pre-existing)                                               |
| 6   | A control demonstrated failing per assertion           | **met** — and two controls failed to fail first, then were fixed |
| 7   | `LEDR_KEY` byte-exact                                  | **met** — `01002024-20250270000101`                              |
| 8   | Docs updated in the same commit                        | **met** — this file                                              |

**Family 1 is complete** in the sense the plan defines: no implementable defect remains, and every residual
difference is categorised with its measurement.
