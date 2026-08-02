# Family 3 — Cash pay / receive

**Status: MEASURED, not yet replayed.** This file records step 1–2 of the method (count the output, count the
source columns) so the implementation that follows has a written target. It is not a comparison record yet.

**Books** 001 (`CASH REC`, 162 legs) · 002 (`CASH PAY`, 360 legs) — **522 legs total**
Bank equivalents exist (`BANK PAY` 7 books, `BANK REC` 7 books) and are measured separately.
**Desktop source** `TR_CASH_REC.cs`, `TR_CASH_PAY.cs`, `Ac_Ledr.cs`

---

## Correction to an earlier assumption

The plan and the gap register both referred to these as `CASH PAYMENT` / `CASH RECEIVED`. The real
`BOOK_DATA.MAIN_BOOK` values are **`CASH PAY`**, **`CASH REC`**, **`BANK PAY`**, **`BANK REC`**. A filter on the
long names returns **zero rows**, which is indistinguishable from "this family has no data" unless the query is
checked.

That is exactly how it presented: the first inventory query returned empty and was nearly read as a finding.
See `VERIFICATION-REFERENCE.md` §8 — the guard that caught it, and its own false-positive limitation.

---

## The key layout differs from every family so far

```
[01002024-202500100001         101]
 ^^^^                                CO_CODE(2) + LC_CODE(2)
     ^^^^^^^^^                       CO_YEAR(9)
              ^^^                     CO_BOOK(3)
                 ^^^^^                VCH_NO(5)
                      ^^^^^^^^^^^^   line + leg, right-aligned in 12
```

33 characters, like the scheme family — but the suffix is **12 wide, not 10**, and carries `<line><leg>` as a
single right-aligned field rather than a bare line number. So `SUBSTRING(LEDR_KEY, 22, 2)` — which reads the leg
type on every other family — returns **spaces** here. That is the signal that led to decoding it.

Three key layouts now confirmed across three families:

| Family           | Length | Suffix                                |
| ---------------- | ------ | ------------------------------------- |
| Sale (026/027/…) | 23     | none — leg type at chars 22-23        |
| Scheme (074)     | 33     | bare line number, right-aligned in 10 |
| Cash (001/002)   | 33     | `<line><leg>` right-aligned in 12     |

**Any assumption that one layout is global is already disproved.**

---

## Leg codes are DIRECTION-SPECIFIC

Measured across all 522 legs. Every code appears in an exact Dr/Cr pair.

**Book 001 — `CASH REC`, money in**

| Leg  | Role                   | Direction | Accounts | Count |
| ---- | ---------------------- | --------- | -------- | ----- |
| `01` | party                  | **Cr**    | 44       | 56    |
| `02` | cash `00001`           | **Dr**    | 1        | 56    |
| `03` | party                  | **Cr**    | 24       | 25    |
| `04` | kasar `00057` **JAVK** | **Dr**    | 1        | 25    |

**Book 002 — `CASH PAY`, money out**

| Leg  | Role                   | Direction | Accounts | Count |
| ---- | ---------------------- | --------- | -------- | ----- |
| `05` | party                  | **Dr**    | 34       | 175   |
| `06` | cash `00001`           | **Cr**    | 1        | 175   |
| `07` | party                  | **Dr**    | 2        | 5     |
| `08` | kasar `00042` **AVAK** | **Cr**    | 1        | 5     |

Two things follow that could not be guessed:

1. **Receipts and payments do not share codes.** A receipt uses 01–04, a payment 05–08. The same _role_ — party,
   cash, kasar — takes a different code depending on the direction of the money.
2. **The kasar account differs by direction too.** `00057 KASAR JAVK A/C` on a receipt, `00042 KASAR AVAK A/C.`
   on a payment. Gujarati _javak_ is outgoing and _avak_ incoming, so the account mirrors the money's direction
   rather than the voucher's. Using one kasar account for both would post half the discounts to the wrong
   ledger.

---

## The line prefix

```
101,102 (56)   103,104 (25)   105,106 (133)   107,108 (5)
               205,206 (22)   305,306 (11)    405,406 (4)   ... and beyond
```

**CORRECTION.** An earlier version of this file said the line prefix reaches 4, and that a payment voucher
handles "up to four parties". Both were wrong, and the error was mine rather than the data's: the aggregate
query's output was piped through `head -14` and the truncated list was read as complete.

Book 002 / 00029 settles it — **18 legs across 9 lines**, keyed `105/106` through `905/906`:

```
[01002024-202500200029         105]  ac 000760  Dr 5000.00
[01002024-202500200029         906]  ac 00001   Cr  160.00
```

So the line prefix is **unbounded in practice** (at least 9), and the correct statements are:

- a **receipt** voucher handles one party, optionally with a second pair for its discount (01/02 plus 03/04);
- a **payment** voucher handles **many** parties, each on its own line, all using 05/06.

The lesson is the pipe trap in a new costume: `head` on a measurement makes an incomplete answer look
complete. Read a total first, or ask for the count separately.

---

## Status after implementation

**Replay** `apps/api/integration/parity-replay-cash.mjs` (book 001 voucher 00001), under `PARITY_STRICT=1`.
163 fields compared, 47 raw differences, 26 unpopulated columns, **7 real** — of which 6 were the replay's own
date and are now corrected.

**All four ledger legs reproduce the desktop byte for byte:**

```
[01002024-202500100001         101]  ac 000926  ld 00001   Cr 60000.00
[01002024-202500100001         102]  ac 00001   ld 000926  Dr 60000.00
[01002024-202500100001         103]  ac 000926  ld 00057   Cr   771.00
[01002024-202500100001         104]  ac 00057   ld 000926  Dr   771.00
```

### Fixed

| #   | Defect                                                                     | Paths                        |
| --- | -------------------------------------------------------------------------- | ---------------------------- |
| 1   | Party leg **netted** — 3 legs where the desktop writes 4                   | `postReceipt`, `postPayment` |
| 2   | Multi-line wrote **aggregate** cash/kasar legs — 11 legs for 9 lines vs 18 | `postPaymentLines`           |
| 3   | No leg codes — positional fallback instead of 01–08                        | all three                    |
| 4   | Wrong order — the desktop's first leg is the party                         | all three                    |
| 5   | No `LD_CODE`                                                               | all three                    |
| 6   | Placeholder `'CASH'` instead of `BOOK_DETL` slot 1                         | all three                    |

Defect 6 is now at **four occurrences** across the finance paths (scheme, receipt, payment, payment-lines), so
it is systemic rather than local.

### Still open — the Rojmel

`ROJ_MEL_DATA` needs a row per movement too. The desktop writes **three** rows for this voucher; the web writes
one.

```
[01002024-20250010000101         1]  ac 00001   ld 000926  Cr 60000.00
[01002024-20250010000102         1]  ac 000926  ld 00057   Cr   771.00
[01002024-20250010000103         1]  ac 00057   ld 000926  Dr   771.00
```

**A FOURTH key layout.** This is `<leg>` at characters 22-23 plus a bare line right-aligned in 10 — the scheme's
`AC_DATA` shape — and _not_ the cash ledger's 12-wide combined field, even though both belong to the same
voucher. So one voucher uses two different key layouts across two tables.

And the amounts: `ROJ_MEL_DATA.CR_AMT` is **60000.00**, the cash tendered. The web wrote 60771.00, the party's
total including the write-off.

That figure **contradicts a comment in `finance.ts`** which states the cash books "take their DEBIT/CREDIT from
the PARTY's leg … the party's ledger figure, which includes any kasar written off, not the cash actually
tendered." The comment was written when the party leg was a single netted 60771; splitting the legs made the
party's _first_ leg 60000, and the desktop agrees with that. The comment needs correcting along with the code —
it is evidence about the old shape, not the desktop.

Note too that the Rojmel's type-01 row **credits** cash where the ledger **debits** it, so the Rojmel's
direction convention is not the ledger's and must be taken from data per row type.

---

## The BANK books — measured, and the assumption would have been wrong

Measured across all 228 legs of the 11 active bank books. **Not** a mirror of cash:

| `MAIN_BOOK` | Leg         | Role                            | Dir     | n   | Same as cash?                   |
| ----------- | ----------- | ------------------------------- | ------- | --- | ------------------------------- |
| `BANK REC`  | `01` / `02` | party / bank                    | Cr / Dr | 42  | **yes** — same as `CASH REC`    |
| `BANK REC`  | `03` / `04` | party / kasar `00057`           | Cr / Dr | 6   | **yes**                         |
| `BANK REC`  | `05` / `06` | bank / **bank charges `00048`** | Cr / Dr | 1   | **no — cash has no equivalent** |
| `BANK PAY`  | `07` / `08` | party / bank                    | Dr / Cr | 61  | **NO — cash pay uses 05/06**    |
| `BANK PAY`  | `11` / `12` | bank / **bank charges `00048`** | Cr / Dr | 4   | **no**                          |

Three things follow, and only the first was predictable:

1. **Bank receipt shares cash receipt's codes.** 01/02 and 03/04 carry over.
2. **Bank payment does NOT.** It uses 07/08 where cash payment uses 05/06. Assuming the mirror would have
   written the wrong code on all 61 legs.
3. **Both bank directions add a bank-charges pair** — `05/06` on a receipt, `11/12` on a payment — naming
   `00048 BANK CHARGES A/C`. The cash books have no such pair at all.

**The code space is per-`MAIN_BOOK`, not per-direction.** `BANK REC`'s `05/06` is a bank-charges pair while
`CASH PAY`'s `05/06` is a party/cash pair. The same two numbers mean different things in different books, so a
single global map keyed on code alone would silently conflate them.

That is the third distinct scheme in this family alone (cash receipt, cash payment, bank payment), which is why
the plan's per-family measurement step exists and why the bank codes were not assumed from cash.

---

## Next steps

1. Pick reference vouchers: 001/00001 (4 legs — party, cash, party, kasar) and 002/00029 (18 legs, multi-line).
2. Extract the desktop bundles, build `parity-replay-cash.mjs`, replay under `PARITY_STRICT=1`.
3. Compare, triage into the four categories, fix, prove a control per assertion.
4. Then the bank books, which have the same `MAIN_BOOK` shape and need their own leg-code measurement — the
   codes above are for CASH and must not be assumed to carry over.

## What the web actually does — prediction tested

The prediction was right on three counts and **missed a fourth, which is the largest**.

`postReceipt` in `finance.ts:203` builds three legs:

```
cash    Dr amount          LD_CODE = party
kasar   Dr kasar           (no LD_CODE)
party   Cr amount + kasar  LD_CODE = cash        <- ONE netted credit
```

The desktop writes **four**, as two self-balanced pairs:

```
01  party  Cr 60000.00   ld 00001      02  cash   Dr 60000.00   ld party
03  party  Cr   771.00   ld 00057      04  kasar  Dr   771.00   ld party
```

| #   | Difference                                                                      | Predicted? |
| --- | ------------------------------------------------------------------------------- | ---------- |
| 1   | No leg codes — positional fallback instead of 01–08                             | yes        |
| 2   | Wrong order — cash first, where the desktop's `01` is the party credit          | yes        |
| 3   | No line prefix in the key, and no `LD_CODE` on the kasar leg                    | yes        |
| 4   | **The party credit is NETTED into one leg — 3 legs where the desktop writes 4** | **no**     |

**Difference 4 is the structural one.** The desktop pairs each movement with its own party leg, so a receipt
with a discount credits the party twice — once against cash, once against kasar. The web credits it once for
the total. Both balance, so no balance assertion can see it, and the leg _count_ differs, which means a
per-account ledger report would show one line where the desktop shows two.

The sale family already gets this right — `buildSaleLedger` carries the comment _"Desktop emits a self-balanced
party/tender pair, not a netted party balance"_. So **the cash path has a defect the sale path had already
fixed**, and the two disagree with each other inside the same codebase.

`buildTransferLedger` is again not the place to fix it: it is a two-leg helper by construction, and a
self-balanced pair per movement is a different shape. Family 2 reached the same conclusion for the same reason.

---

## Next steps

1. Build `parity-replay-cash.mjs` for both reference vouchers, run under `PARITY_STRICT=1`.
2. Implement the measured shape: pair per movement, direction-specific codes, `<line><leg>` suffix.
3. Compare, triage, prove a control per assertion.
4. Then the bank books — same `MAIN_BOOK` shape, but their leg codes **must be measured, not assumed** from
   cash. The cash codes are already known to differ between receipt and payment, so assuming they carry across
   to bank would be the same error one level up.

**Superseded prediction, kept for the record:** the web's `finance.ts` uses `buildTransferLedger`, which emits debit-first
with no `LD_CODE` and no leg codes — the same three defects family 2 had. If so, the cash family will show them
too, and the fix is a per-family measured shape rather than a change to the shared helper.
