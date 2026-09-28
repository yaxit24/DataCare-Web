# Phase 1 — Extend the oracle beyond two families

Scope from `DESKTOP-PARITY-EXECUTION-PLAN-2026-08-30.md`. Status: **all retained families replayed.** Family coverage in the
measured set went from **2 to 6** — every family the retained desktop captures contain.

## The constraint, and the way round it

Phase 1 as planned means capturing real vouchers for the remaining 59 transaction families, which needs the
desktop SQL Server. That is not reachable here, so on the face of it Phase 1 was blocked.

It was not. Nine desktop captures were retained on disk, and between them they hold four families the 66-case
bundle does not:

| Case | Family | Distinguishing tables |
| --- | --- | --- |
| `sale-027-00001` | retail sale (`TR_SALE`) | `SL_DATA`, `SL_DETL`, `BILL_OS_DATA`, `TAX_DATA` |
| `scheme-074-00001` | savings scheme | `AD_DATA`, `AD_OS` |
| `cashrec-001-00001` | cash receipt | `CASH_DATA` |
| `cashpay-002-00029` | cash payment | `CASH_DATA` |

`TR_SALE` matters most: 21,587 lines of desktop logic, classified critical, the most-used form in a jewellery
shop, and it had **no cases at all** in the measured set.

## New tool: `parity-bundle-merge.mjs`

Combines the retained captures into one desktop bundle. Rules that matter:

- a case is keyed by `caseId`, and the newest capture containing it wins
- **duplicate vouchers are dropped.** The same voucher appears under two naming schemes — the 08-02T08-19 capture
  named cases by BOOK (`035-00001`), the 08-02T17-09 one by FAMILY (`purc-035-00001`). The first merge kept both
  and reported "70 cases across 11 families", double-counting every difference those vouchers carry. Now the
  newest capture's naming wins and `real-` prefixed ids lose a tie, giving **70 cases across 6 families**.
- a capture whose desktop side is not `sqlserver` is refused, and provenance is preserved per case, so a merge
  cannot launder a synthetic capture into evidence

## Sharing one seeded world

Each family's replay previously wiped and seeded its own tenant, which forces a reduced case set — and the ratchet
rightly refuses that. All three replays now take `--no-wipe` and guard their shared masters with
`WHERE NOT EXISTS`, because the books overlap on accounts (`00001`, `00008`, `00057`), items (`ORS`), tax code
`10` and group `01`. One tenant, one extract, every family.

## Result

```
                     66-case ceiling      67 cases (sale added)
cases matched            0 / 66                0 / 67
fieldDifferences          3,662                 3,745
fieldsCompared           24,308                24,980
agreement                84.94%                85.01%
rows missing/extra       180 / 193             182 / 196
families                    2                     3
```

The ratchet's expanded-set path was exercised for the first time and behaved as designed:

```
case set        expanded
cases added     1
note            case set expanded by 1 (66 → 67); compared over the 66 shared case(s)
```

No regression on the shared 66, so the ceiling was re-recorded at 67 cases / 3,745 differences. The absolute count
rose because there is more being compared — which is exactly why comparing shared cases, rather than normalising
totals per case, is the right rule.

`desktop-latest.json` now points at the combined 70-case bundle, so the default `pnpm parity:measure` uses the
widest available evidence.

## Verification

- `pnpm parity:measure` from the newest bundles: 67 cases, identical set, `PARITY_RATCHET_OK`
- release certification `passed=11 failed=3 skipped=1 missing=1`, `parity-ratchet` PASS
- `prettier --check .` clean

## All six families measured

`parity-replay-cash.mjs` closes the remaining three:

| Case | Family | Module | Result |
| --- | --- | --- | --- |
| `cashrec-001-00001` | cash receipt | `postReceipt` | replayed |
| `cashpay-002-00029` | cash payment | `postPaymentLines` (nine `CASH_DATA` lines) | replayed |
| `scheme-074-00001` | savings scheme | `schemeInstallment` | replayed |

Both cash vouchers are the ones `finance.ts` was written against — its `ReceiptInput` documents "Real voucher
002/00029 has nine CASH_DATA lines and eighteen legs keyed 105/106 through 905/906". So they are the friendliest
possible cases, which makes a difference in them more significant than one elsewhere, not less.

Three refusals, each resolved from the desktop's own rows rather than by guessing:

- **kasar account not configured** — the receipt writes off 771, and the desktop DEBITS it to `00057`. Derived by
  finding the non-party leg whose debit equals the write-off.
- **scheme 03 not found** — `AD_MAST` seeded, with `SCHM_AC` taken from the case's own credit leg.
- **unique constraint on re-run** — the script did not wipe, so a second pass re-posted an existing voucher. It
  now clears only its OWN books (001, 002, 074), leaving the tenant the other replays seeded intact.

### A structural divergence this surfaced

The desktop credits the scheme installment to `000858`, an account named "03 - ALAUDIN MAKASUDBHAI KADARI" — one
account **per member**. The web credits `AD_MAST.SCHM_AC`, which is per **scheme**, and `AD_MEMB` has no account
column at all (verified against the live schema). Seeding `SCHM_AC = 000858` makes this single-member case
comparable, but it does not generalise: with two members on scheme 03 the web would credit both to one ledger.
Recorded rather than worked around.

## Result across six families

```
                   67 cases (3 families)   70 cases (6 families)
cases matched            0 / 67                  0 / 70
fieldDifferences          3,745                   3,813
fieldsCompared           24,980                  25,795
agreement                85.01%                  85.22%
rows missing/extra       182 / 196               207 / 215
desktop-only tables         54                      59
```

The ratchet reported `expanded by 3 (67 → 70)`, compared over the 67 shared cases, found no regression, and the
ceiling is re-recorded at **70 cases / 3,813 differences across 6 families**. Agreement rose to 85.22% while the
absolute count grew, which is what adding cases looks like.

## Next

1. **More cases per family.** Four of the six families have exactly one case, which proves the path but not the
   family. The desktop holds 190 sale headers in the real data.
2. **More `sale` cases.** One retail sale proves the path but not the family: the desktop has 190 sale headers in
   the real data, and the single retained case is untaxed-adjacent and small.
3. **Capture the remaining families** — this is where desktop access becomes unavoidable. Priority order is in the
   execution plan's Phase 1 table, led by `TR_SALE`, `TR_PURC`, `TR_SALE_RTN`, `TR_TAG_OPBL`, `TR_TAG_SPLIT`.
