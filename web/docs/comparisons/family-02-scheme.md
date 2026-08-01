# Family 2 — Scheme instalment

**Book** 074 (`MEMB ENTRY`) · **1311 vouchers, 2622 AC_DATA legs** — the largest family by volume, against 556
rows for the whole sale family · **Desktop source** `TR_MEMB_ENT.cs`, `Ac_Ledr.cs`, `Ac_Rojmel.cs`

**Reference voucher** `Live24` book `074` voucher `00001` — one member line, 2000.00, scheme 03, member 0029.
**Multi-line reference** voucher `00309` — 11 members, 22 legs, line numbers 1–11.

**Replay** `apps/api/integration/parity-replay-scheme.mjs`, run under `PARITY_STRICT=1`
**Test** `apps/api/test/schemeLedgerLegs.db.test.ts`

---

## Result

| Measure                                 | Value |
| --------------------------------------- | ----- |
| Fields compared                         | 136   |
| Raw differences                         | 26    |
| Columns the web leaves NULL             | 16    |
| Harness artifacts (placeholder masters) | 10    |
| **Substantive differences**             | **0** |

Both ledger legs reproduce the desktop byte for byte, including the 33-character keys:

```
[01002024-20250740000101         1]  ac 000858  ld 00001   Cr 2000.00
[01002024-20250740000102         1]  ac 00001   ld 000858  Dr 2000.00
```

---

## The measured shape

```
type 01   the scheme LIABILITY, credited     1311 rows, ONE account (000858)
type 02   the RECEIPT account, debited       1311 rows, five accounts (cash + four banks)
```

Legs come in **pairs per member line**, and the key carries that line number right-aligned in 10 — the same
33-character layout `ROJ_MEL_DATA` uses. Legs per voucher are always even:

```
2 legs: 570 vouchers   4: 172   6: 52   8: 13   10: 21   12: 11   14: 1   22: 1
```

Book 075 (`MEMB OPENING`) has **no `AC_DATA` rows at all** — an opening writes the `AD_OS` carry-forward and no
money ledger. The web already reproduced this.

---

## Six defects fixed

| #   | Defect                                       | Evidence                                                       |
| --- | -------------------------------------------- | -------------------------------------------------------------- |
| 1   | Key had **no line number** — 23 chars vs 33  | all 2620 legs are 33 chars, carrying the member line           |
| 2   | Leg types were the positional fallback 51/52 | measured 01 liability Cr, 02 receipt Dr                        |
| 3   | Leg **order reversed** — debit first         | type 01 is the credit, so the liability leads                  |
| 4   | `LD_CODE` never written                      | the desktop carries the contra on both legs                    |
| 5   | Receipt account was the literal `'CASH'`     | real rows name `00001` = book 074's `BOOK_DETL` slot 1         |
| 6   | `AD_OS.ENTRY_TYPE` was `'I'`                 | `E` 8070 / `O` 90 / `A` 34 across 8194 rows; `'I'` **nowhere** |

### How the first one announced itself

The differ's forced-pair report, built in Phase 0.1, printed
`KEY WARNING — multi-row tables compared without a key match: AC_DATA (2v2 rows)` on the very first run. Without
it the key defect would have surfaced as a pile of unexplained field differences with no obvious cause.

**A balance assertion could not have caught any of the six.** The voucher balanced throughout.

### Two that only became visible after another fix

**Three more literal-`'CASH'` sites.** Resolving the receipt account in the ledger legs left
`AD_DATA.REC_AC`, `AD_OS.LD_CODE` and `ROJ_MEL_DATA.LD_CODE` still holding it. Fixing the visible one made the
others visible — the third time in this phase a fix has uncovered a sibling.

**`ENTRY_TYPE: 'I'` was an invention.** Not a misreading of the desktop but a plausible-looking guess —
"instalment" — for a column whose real values are `E`, `O` and `A`. The adjust path in the same module already
wrote `'A'` correctly, so the two disagreed with each other.

### What was deliberately not changed

`buildTransferLedger` emits debit-first and sets no `LD_CODE`, and it is **shared** with modules whose leg order
has not been measured. Changing it would have guessed on their behalf, so the scheme builds its own measured
shape and the helper is untouched.

`legLine` is **per-family**, not global. The sale family's keys are 23 characters with no line number, so
applying it everywhere would have broken family 1.

---

## Controls

| Broken                         | Failure                                                                               |
| ------------------------------ | ------------------------------------------------------------------------------------- |
| line number removed            | `expected '01002024-20250740000101' to have a length of 33 but got 23`                |
| liability typed as the receipt | **`23505`** — the `LEDR_KEY` uniqueness index added in family 1 catches the collision |
| slot resolution removed        | `expected 'CASH' to be '00001'`                                                       |

The multi-line test is the one that matters: **with a single member line a missing line number is invisible**,
because there is nothing to distinguish. Three members is the smallest fixture that can fail.

---

## Exit criteria

| #   | Criterion                                           | State                                                    |
| --- | --------------------------------------------------- | -------------------------------------------------------- |
| 1   | 0 unexplained field differences                     | **met**                                                  |
| 2   | Every difference categorised                        | **met** — 16 unpopulated, 10 harness, 0 substantive      |
| 3   | Every real row type produced                        | **met** — both leg types, plus 075's zero-ledger opening |
| 4   | Write set asserted as an exact set                  | met (pre-existing)                                       |
| 5   | Edit and delete covered                             | met (pre-existing)                                       |
| 6   | A control demonstrated failing per assertion        | **met** — three proven                                   |
| 7   | `LEDR_KEY` byte-exact **including the line number** | **met**                                                  |
| 8   | Docs updated in the same commit                     | **met** — this file                                      |

**Family 2 is complete.** Six defects fixed, zero substantive differences remain.

---

## Still unverified in this family

The reference vouchers are a **1-member and a 3-member** case. The real book has vouchers up to **11 members**,
and `AD_OS` balance arithmetic (`Σ(A+) − Σ(D−) − Σ(B−)` across 8194 rows) is asserted by an existing test but
has never been compared against a desktop voucher. Family 8 (scheme adjust, book 076) is where the `A` and `B`
movements are produced, so that comparison belongs there.
