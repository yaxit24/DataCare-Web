# WP-02D posting account resolution implementation evidence

**Date:** 2026-08-30
**Plan:** `EXACT-END-TO-END-PARITY-PLAN-2026-08-29.md`
**Work package slice:** WP-02D — P0-04 literal posting-account fallbacks
**Status:** first slice implemented and validated in the current working tree; **P0-04 is NOT closed**; no commit created
**Claim boundary:** the finance, tender, batch-receipt and scheme paths no longer post to literal accounts, the enforcement machinery exists, and the remaining debt is measured and ratcheted. 68 account literals remain in 15 files. This closes neither P0-04 nor WP-02.

## 1. What the defect actually was

The gap text lists six literals across five module families. A site-by-site read of all 156 matches (26 files) produced a precise classification rather than a grep count:

| Category                                                       | Count |
| -------------------------------------------------------------- | ----: |
| Account-code literal reached through a fallback (`??`/`\|\|`/default) |    41 |
| Account-code literal used unconditionally                       |     1 |
| Comparison only, never written                                  |     1 |
| Unrelated (pay mode, book name, voucher type, label, type union) |   102 |
| Provisioning/seed path                                          |    11 |

So 42 sites were real and 114 were noise — which matters, because a static rule written against the noisy set would have been unusable.

The classification also showed the gap text was **incomplete**: the same fallback shape carries `BANK`, `BULLION`, `INTINC`, `TDS`, `PF`, `GST`, `GSTINPUT`, `SALES`, `PURCHASE`, `HMCHRG`, `TCS`, `OLDGOLD`, `FINEPURC` and `FINESALE`. Fixing only the named six would have left the identical defect under other names, so all of them are in scope of the rule.

Why these strings are wrong rather than merely ugly: no real dataset contains an account called `CASH` or `KASAR`. Book 001's real leg-02 rows all name `00001`, that book's `BOOK_DETL` slot 1; rate-cut books 034/064 name `00003`/`00042`/`00098`. The literals resolve only because provisioning seeds accounts with those codes — so on a seeded demo company a voucher looks right, and on a migrated company it posts silently to the wrong ledger after consuming a serial.

## 2. What now enforces the rule

`modules/shared/postingAccounts.ts` (new):

- `requirePostingAccount(role, value, context)` — accepts an account only if present; refuses with the voucher family and the amount that made it necessary.
- `resolveBookSlotAccountTx(tx, scope, role, srNo, explicit?)` — explicit caller value wins, else the book's `BOOK_DETL` slot, else refuse. Fails closed on missing, blank **and duplicated** slots. Deliberately separate from `bookPolicy.resolveBookAccountTx`, which additionally pairs `MAIN_BOOK`/`BOOK_INOUT` and therefore requires a `BookPolicy` that cash, payment, scheme and order books do not have.
- `PostingAccountValidationError` carries `role` and `detail`, and its name matches the route error mapper's `ValidationError` pattern so an unpostable request answers 400 rather than 500.

`PostingAccountRole` names a business position (`cash-settlement`, `kasar`, `labour-expense`, …) rather than an account, because the same role sits in different slots per family — cash settlement is slot 1 on a cash book and slot 2 on a sale book — so the slot stays with the caller that measured it.

## 3. Migrated in this slice

| Module                    | Sites | Now resolved from                                                    |
| ------------------------- | ----: | -------------------------------------------------------------------- |
| `finance/finance.ts`      |     9 | `BOOK_DETL` slot 1 for settlement (all four write paths); caller for kasar |
| `finance/tender.ts`       |     8 | caller, and only for the legs whose amount is non-zero               |
| `membership/scheme.ts`    |     2 | `BOOK_DETL` slot 1 for instalment receipt and maturity payout        |
| `finance/batchReceipt.ts` |     1 | slot 1 per book; caller for each line's write-off                    |

`settlementAc` no longer returns `'CASH'`/`'BANK'`. It now only chooses between accounts the caller resolved and refuses when the one the mode needs is absent.

Two behaviours were corrected as a consequence, not just relocated:

1. In `postReceiptLines` the settlement account is resolved **before** the cash-receipt ceiling check. The ceiling counts a party's prior cash against that account, so the placeholder was measuring the wrong ledger as well as posting to it.
2. `buildCashRojmel` receives a blank rather than `'KASAR'` when nothing is written off. It emits kasar rows only when both amount and account are present, so a zero write-off no longer names an account at all.

## 4. Exit evidence

The plan requires: _"Static rule rejects posting literals in production paths; database tests prove missing configuration rolls back with no serial consumption or rows."_

**Static rule** — `test/postingAccountLiterals.test.ts` (5 tests) is a ratchet, not a wish:

- a file absent from the register must contain **zero** account literals;
- a registered file may contain **at most** its recorded count;
- the four migrated files plus the resolver must stay at zero and may not re-enter the register;
- the total may only fall from 68;
- a register entry whose file is already clean fails as stale bookkeeping, so progress cannot be hidden.

**Database tests** — `test/postingAccountFailClosed.db.test.ts` (3 tests, real database):

| Scenario                                                     | Asserted outcome                                                              |
| ------------------------------------------------------------ | ----------------------------------------------------------------------------- |
| Book has no configured settlement account                    | refused with `role: 'cash-settlement'`, `detail: 'book 001 slot 1 is missing'` |
| Settlement configured, write-off account absent              | refused — proving the requirement is per account, not one blanket check        |
| Both refusals                                                | `AC_DATA`/`CASH_DATA`/`ROJ_MEL_DATA`/`TEMP_BOOK_DATA` unchanged **and `SRNO_MAST` unchanged** — no serial burnt, so no permanent hole in a legally numbered sequence |
| Configuration present                                        | posts to the configured `00001` and the caller's `00057`, and the literals `CASH`/`KASAR` appear in no ledger column |

The serial assertion is the part a source reading cannot establish: the guarantee comes from the transaction boundary, since numbering happens inside the same transaction as the refusal.

**Commands:** full API suite `147 → 149 files, 1215 → 1223 tests, all passing` (`--no-file-parallelism`, `TZ=UTC`, UTC database session). `tsc` clean for api source, api tests and web. `prettier --check` clean on every changed file.

## 5. What the fail-closed change exposed in existing tests

Removing the defaults turned 35 previously green tests red, and every one was a case that had been posting to a placeholder:

- `purchase.lifecycle` settled 20 by card and 30 by cheque **without naming a bank account** — 14 tests. Fixture now names one.
- `salesFamilyLifecycle`, `correctionWorkflow`, `reopenVoucher`, `settingsBehavior` posted receipts, payments and scheme instalments on books with **no configured slot 1** — 19 tests. Fixtures now seed it, which is what a real company has and what `seedCompany` provisions.
- Two assertions encoded the defect itself: `finance.test.ts` expected `settlementAc('cash') === 'CASH'`, and `salesFamilyLifecycle` expected `AD_OS.LD_CODE === 'CASH'`. Both now assert the configured account, and the second is direct evidence the fix reaches the persisted row — the same column the desktop fills with `00001`.

## 6. Remaining debt (register)

68 account literals in 15 files, recorded in the static rule:

| File                                   | Count | Note                                                                 |
| -------------------------------------- | ----: | -------------------------------------------------------------------- |
| `modules/sales/sales.ts`               |    14 | mostly inert initialisers replaced by slot 2/3 when the amount is non-zero |
| `modules/purchase/purchase.ts`         |    10 | same shape, plus `createOtherPurchase` round-off which is a live fallback |
| `modules/dhrn/dhrn.ts`                 |     5 | funding, receipt and interest-income accounts; no configured source identified |
| `modules/finance/billToBill.ts`        |     5 | live fallbacks; module reads no account configuration at all         |
| `modules/purchase/purchaseReturn.ts`   |     5 | inert initialisers                                                   |
| `modules/sales/salesReturn.ts`         |     5 | inert initialisers                                                   |
| `modules/manufacturing/karigar.ts`     |     4 | labour expense and GST                                               |
| `modules/sales/labourInvoice.ts`       |     4 | labour income, GST, round-off                                        |
| `modules/finance/employeeJv.ts`        |     3 | net salary, TDS, PF                                                  |
| `modules/sales/salesOrder.ts`          |     3 | advance is documented as slot 1 but never resolved; refund is operator-chosen |
| `modules/bullion/bullion.ts`           |     2 | payable and settlement                                               |
| `modules/bullion/fineSalePurchase.ts`  |     2 | fine sale/purchase controls                                          |
| `modules/finance/ledgerAdjust.ts`      |     2 | one is comparison-only; one is written                               |
| `modules/manufacturing/mfg.ts`         |     2 | labour expense                                                       |
| `modules/stock/tagOps.ts`              |     2 | **unreachable today** — WP-01 contains Tag Weight Difference          |

For roughly 30 of these the correct configured source is **not determinable from the code**. Inventing a slot number is precisely the error this plan forbids: `rateCut.ts` carries the scar of a previous wrong guess about `BOOK_DETL` ("that statement was wrong"). Closing them needs either desktop evidence per family or the owner-approved mapping the plan's required action allows, which belongs to WP-00 rather than to a code change.

## 7. Files

- `web/apps/api/src/modules/shared/postingAccounts.ts` (new)
- `web/apps/api/src/modules/finance/finance.ts`
- `web/apps/api/src/modules/finance/tender.ts`
- `web/apps/api/src/modules/finance/batchReceipt.ts`
- `web/apps/api/src/modules/membership/scheme.ts`
- `web/apps/api/test/postingAccountLiterals.test.ts` (new)
- `web/apps/api/test/postingAccountFailClosed.db.test.ts` (new)
- `web/apps/api/test/finance.test.ts`
- `web/apps/api/test/purchase.lifecycle.db.test.ts`
- `web/apps/api/test/salesFamilyLifecycle.db.test.ts`
- `web/apps/api/test/correctionWorkflow.db.test.ts`
- `web/apps/api/test/reopenVoucher.db.test.ts`
- `web/apps/api/test/settingsBehavior.db.test.ts`
