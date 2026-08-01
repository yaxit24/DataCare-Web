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
               205,206 (22)   305,306 (11)    405,406 (4)
```

Lines above 1 occur **only** with legs 05/06 — the payment pair. So:

- a **receipt** voucher handles one party, optionally with a second pair for the discount (01/02 plus 03/04);
- a **payment** voucher handles up to **four** parties, each on its own line, all using 05/06.

The largest real voucher is book 002 / 00029 with **18 legs**.

---

## Next steps

1. Pick reference vouchers: 001/00001 (4 legs — party, cash, party, kasar) and 002/00029 (18 legs, multi-line).
2. Extract the desktop bundles, build `parity-replay-cash.mjs`, replay under `PARITY_STRICT=1`.
3. Compare, triage into the four categories, fix, prove a control per assertion.
4. Then the bank books, which have the same `MAIN_BOOK` shape and need their own leg-code measurement — the
   codes above are for CASH and must not be assumed to carry over.

**Prediction to test, not to assume:** the web's `finance.ts` uses `buildTransferLedger`, which emits debit-first
with no `LD_CODE` and no leg codes — the same three defects family 2 had. If so, the cash family will show them
too, and the fix is a per-family measured shape rather than a change to the shared helper.
