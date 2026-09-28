# Functional parity: assessment and implementation plan

**Date:** 2026-08-02 · **Scope:** DataCareNext desktop → web (`imodule-extracted`)

## Why this document exists

Everything measured so far has been **structural**, and structural measures cannot tell a shop owner whether
they can run their business:

| Existing measure | Value | What it actually says | Reference |
| --- | --- | --- | --- |
| Schema parity | 145/145 tables, 5231/5231 columns | the shape can hold the data | `PARITY-AND-GAP-REPORT-2026-08-02.md` §1 |
| Control coverage | 73.2% of 4555 desktop UI controls | widgets exist on screens | `web/docs/VALIDATION-PLAN.md` |
| Field differences | 4349 across 66 replayed vouchers | cells disagree | `FIXES-AND-SCALED-COMPARISON-2026-08-02.md` §3 |
| Voucher families postable | 21 of 22 | a voucher can be saved | `web/docs/STATE-OF-PARITY.md` §3 |

A form can have every control and every column and still be unusable: you cannot reopen yesterday's invoice,
or deleting it leaves the day book wrong, or the evening day book does not balance. **This document measures
the operator lifecycle and the end-to-end business workflows instead**, and turns the gaps into a plan.

New measurement tool: `web/apps/api/integration/functional-parity-matrix.mjs`
→ `project-memory/parity/FUNCTIONAL-PARITY-MATRIX.json`

---

## 1. The headline functional finding

```
                       all 52 families    19 families in live use
CREATE  (post)              52/52                 19/19
OPEN    (retrieve saved)    22/52                  6/19
EDIT    (correct + repost)  22/52                  6/19
DELETE  (reverse + audit)   43/52                 15/19
DAYBOOK (Rojmel projection) 26/52                 15/19
```

**Every family can be created. Only 6 of the 19 families the business actually uses can be reopened.**

That is the difference between a data-entry screen and an ERP. In the desktop, an operator opens a saved
voucher constantly — to reprint it, to check what was entered, to correct it. On the web, for 13 of 19 live
families, a voucher becomes unreachable the moment it is saved.

## 2. A correction to my own priority ordering

My first instinct was that **EDIT** was the critical gap. The data says otherwise.

```sql
SELECT count(*) FROM USER_DATA;     -- 0        (the per-column edit audit)
SELECT count(*) FROM DELETE_DATA;   -- 72       across 17 voucher families
```

**This company never edited a voucher in the year. It deleted and re-entered 72 times.** Delete-and-re-enter
is the observed correction workflow, so DELETE parity is the priority and EDIT is secondary.

Deletions the business actually performed, against what the web can delete:

| Desktop family | Real deletions | Web DELETE | Route |
| --- | --- | --- | --- |
| SALES | 10 | yes | `DELETE /sales/:vchNo` |
| MEMB ADJUST | 8 | yes | `DELETE /scheme/maturity/:vchNo` |
| WH SALES | 6 | yes | `DELETE /rate-cut/:vchNo` |
| **CONTRA** | **6** | **NO** | `POST /contra` only |
| BANK PAY | 5 | partial | only `DELETE /payments/multi/:vchNo` |
| RATE CUT | 5 | yes | `DELETE /rate-cut/:vchNo` |
| PURCHASE | 4 | yes | `DELETE /purchases/:vchNo` |
| CASH REC | 4 | partial | only `DELETE /receipts/multi/:vchNo` |
| KARIGAR RECEIPT | 4 | yes | `DELETE /karigar/receive/:vchNo` |
| CASH PAY | 3 | partial | only `DELETE /payments/multi/:vchNo` |
| **MEMB ENTRY** | **3** | **NO** | `POST /scheme/enroll` only |
| SALES ORDER | 3 | yes | `DELETE /sales-orders/:vchNo` |
| **SL QUOT** | **2** | **NO** | `POST /estimate` only |
| OTH INC | 2 | yes | `DELETE /other-commission/:vchNo` |
| KARIGAR ISSUE | 2 | yes | `DELETE /karigar/issue/:vchNo` |
| BANK REC | 1 | partial | only via `/receipts/multi` |
| **BILL REC** | **1** | **NO** | `POST /bill-to-bill/settle` only |

Verified at `web/apps/api/src/routes/txn.ts` — 57 `app.delete` and 27 `app.put` registrations in total.

---

## 3. Workflow-level assessment

Each workflow is an end-to-end business process, not a form. "Broken" means an operator cannot complete the
cycle; "incomplete" means they can, but something downstream is wrong or unverified.

### W1 · Retail sale cycle — quote → order → invoice → receipt → day book → GST

| Step | State | Evidence |
| --- | --- | --- |
| Quotation (`SL QUOT`) | **cannot be deleted** | `POST /estimate` only; 2 real deletions |
| Sales order | postable, **cannot be opened** | `sales-orders` has POST/GET-list/DELETE, no `GET /:vchNo` |
| Sales invoice | complete lifecycle | contract `TR_SALE` **approved**, 0 unenforced, 0 blank vectors |
| Receipt against bill | **cannot be opened or deleted** singly | `POST /receipts` only |
| Day book projection | present | `shared/rojmel.ts`; desktop SALES 556 rows |
| GST output | **not desktop-equivalent** | desktop reads `TAX_DATA`; web reads `SL_DATA`/`SL_DETL` (`gst.ts:179,201`) |
| e-Invoice | **fixed this session** | production now fails closed (`einvoice.ts:489-528`) |

**Verdict: the core invoice is the strongest module in the system. The cycle around it is not.**

### W2 · Purchase cycle — purchase → tag creation → stock → payment

Contract `TR_PURC` **approved**. Full CRUD. Day book present (115 desktop rows).
Residual: `PR_DATA.PARTY_FINE` differs on 23 of 66 replayed vouchers, and `PR_IDTL` (stone sub-detail) is
missing on 20 — see `FIXES-AND-SCALED-COMPARISON` §"remaining 4349".

**Verdict: functionally complete, with fine-metal arithmetic still to reconcile.**

### W3 · Karigar & job-work cycle — issue metal → receive ornament → settle labour

| Step | State | Evidence |
| --- | --- | --- |
| Karigar issue / receive | full CRUD | 17 live vouchers |
| **Day book projection** | **ABSENT** | desktop writes 28 rows for KARIGAR RECEIPT, 1 for KARIGAR ISSUE; `manufacturing/karigar.ts` has no Rojmel call |
| Job-work | **fixed this session** | was writing karigar vouchers; now `/mfg/jobwork-*` |
| Contract `TR_KR_ISU` | draft | 20 of 20 computed fields have **no golden vector** |

**Verdict: the metal moves but the evening day book does not show it.** This is the last implementable
Rojmel gap (`web/docs/ROJMEL-HANDBOOK.md`).

### W4 · Scheme cycle — enrol → instalments → maturity → redemption

**The highest-volume workflow in the business: 841 vouchers, 1635 day-book rows — more than sales.**

| Step | State |
| --- | --- |
| Enrol | postable; **no OPEN, no EDIT, no DELETE** (3 real deletions) |
| Instalment | postable; **no OPEN, no EDIT, no DELETE** |
| Maturity | postable, deletable |
| Contract `TR_MEMB_ENT` | draft — 3 unenforced rules, 4 of 4 blank vectors |

**Verdict: the busiest workflow has the weakest lifecycle.** An operator who takes a wrong instalment has no
way to reverse it.

### W5 · Wholesale / rate-cut cycle

Wholesale sale **fixed this session** — was silently posting retail sales; now routed to the rate-cut family,
which is what `BOOK_TBL_NAME=RATE_CUT_DATA` says it is. That also brings its 32 day-book rows into coverage.

**Still broken:** pure rate-cut is **header-only** in the desktop — 25 of 25 vouchers have zero detail rows —
and `sales/rateCut.ts:585` rejects a voucher without lines. **25 of 25 real vouchers unpostable.** Needs an
owner decision (§5, D-1).

### W6 · Period close — day book → trial balance → year-end

Day book covers 15 of 19 live families. Year-end close, preview and carry-forward exist
(`/year-end/close`, `/year-end/preview`, `/years/carry-forward`) with database-backed tests.
Balance sheet cannot be parameterised from the UI: the API requires closing date/gold/silver/fine inputs
(`txn.ts:4169-4181`) that the generic report page does not expose.

### W7 · Correction workflow (cross-cutting)

Covered in §2. The gap is DELETE on contra, scheme enrol/instalment, single receipt/payment, bill-to-bill and
estimate.

### W8 · Reporting

Report *filters* were broken by a stale closure until this session (`reports/[report]/page.tsx`). Of 45 desktop
report launchers, 1 is covered, 30 partial, 14 absent; 0 of 254 Crystal templates have proved data equality,
and 148 have no recognised binder family and silently default to `SL_DATA` (`reportBind.ts:52-55`).

### W9 · Loan / dhrn cycle

Postable, **no OPEN, no EDIT, no DELETE** on any of issue / receipt / interest. Zero live vouchers in this
company — but `STATE-OF-PARITY.md` §5.5 correctly warns that a pawnbroker would invert this ranking entirely.

---

## 4. Implementation plan

Ordered by business impact. Each item states **why** (evidence), **where** (file references), **how**, and
**acceptance** (the check that proves it, in the style of `web/docs/VERIFICATION-REFERENCE.md`).

Every item's acceptance criterion must be **demonstrated failing before it is trusted** — the discipline
recorded in `STATE-OF-PARITY.md` §6 and applied to the gates already in CI.

### Phase F1 — Restore the correction workflow (highest value, lowest risk) · **COMPLETE**

The business corrects by deleting and re-entering. Five families it demonstrably deletes cannot be deleted.

> **DISCOVERY THAT RESHAPED F1 AND F2.** Scanning for lifecycle functions against the routes that expose them
> found **34 of 120 `delete*`/`get*`/`edit*` functions are implemented but unrouted**. So most of F1 and nearly
> all of F2 is **route wiring, not new logic**. Unexposed and ready to use:
> `deleteContra`, `deleteReceipt`, `deleteEnrollment`, `deleteDhrn`, `deleteBatchReceipt`,
> `deleteSalesOrderAdjustment`, `getContra`/`editContra`, `getReceipt`/`editReceipt`,
> `getSalesOrder`/`editSalesOrder`, `getFineJv`/`editFineJv`, `getLabourInvoice`/`editLabourInvoice`,
> `getSaleReturn`/`editSaleReturn`, `getLedgerAdjust`/`editLedgerAdjust`, `getEmployeeJv`/`editEmployeeJv`,
> `getJournal`/`editJournal`, `getSchemeInstallment`/`editSchemeInstallment`,
> `getSchemeMaturity`/`editSchemeMaturity`.
> Reproduce with: compare `grep -rhoE "^export async function (delete|get|edit)[A-Za-z0-9_]+" apps/api/src/modules`
> against references in `apps/api/src/routes/txn.ts` and `app.ts`.

**F1.1 · `DELETE /contra/:vchNo`** — 6 real deletions · **DONE this session**
- *Why:* `DELETE_DATA` shows 6 CONTRA deletions; only `POST /contra` existed.
- *Implemented with* the purpose-built `deleteContra` (`finance.ts:1409`), which reads the full CONTRA_DATA
  detail set through `editIdentityTx` so the audit row carries the voucher's own amounts. An earlier revision
  used `deleteJournal`, which reverses the same three tables but does not read those columns.
- *Acceptance:* met. `apps/api/test/contraDelete.db.test.ts` — 4 tests.
- *It also surfaced F3.3:* the day-book assertion is vacuous because contra never reaches the day book.

**F1.2 · Scheme deletion** — 3 real deletions, 841 live vouchers · **DONE this session**
- *Why:* the highest-volume workflow in the business had no reversal at all.
- *Implemented:* `DELETE /scheme/installment/:vchNo` and `DELETE /scheme/enroll`.
- *The real gap was narrower than it looked:* `deleteSchemeInstallment` (`scheme.ts:673`) already existed and
  was already routed — but only for book **075** (MEMB OPENING, `MBOP`). The live instalment book is **074**
  (MEMB ENTRY, `MBENT`), which carries all 841 vouchers. Both have `BOOK_TBL_NAME='AD_DATA'`, so the same
  reversal is correct; only the book and the audit's VCH_TYPE differ.
- *Enrolment is member-keyed, not voucher-keyed:* `deleteEnrollment` (`scheme.ts:738`) takes
  `SCHM_CODE + MEMB_CODE` because `AD_MEMB` has no voucher number and no `AC_CODE`.
- *Acceptance:* met. `apps/api/test/correctionWorkflow.db.test.ts` asserts the **member position returns to its
  prior value** — a sum over `AD_DATA.MEMB_AMT` — not merely that rows disappeared, because two prior scheme
  defects doubled member balances.

**F1.3 · `DELETE /receipts/:vchNo` and `DELETE /payments/:vchNo`** — 13 real deletions · **DONE this session**
- *Why:* reversal existed only for the *multi* variants, and single is the common case.
- **The two sides use different header tables, and getting it wrong fails silently.** `postReceipt` writes
  `CASH_DATA` (`finance.ts:249`); `postPayment` writes `PAY_DATA` (`finance.ts:512`). My first implementation
  used `CASH_DATA` for both — it would have reversed **nothing** on a payment while still returning success.
  Caught by asserting the header table explicitly in the test.
- *Implemented:* receipts via the purpose-built `deleteReceipt` (`finance.ts:1286`); payments via the generic
  `deleteFinance` with `headerTable: 'PAY_DATA'`.
- *`mode` is required, not defaulted:* the audit's VCH_TYPE differs by tender (CREC/BREC, CPAY/BPAY) and
  BANK PAY has **more** real deletions than CASH PAY (5 against 3), so there is no safe majority to assume.
- *Acceptance:* met, in the same test file.

**F1.4 · Bill-to-bill reversal** · **DONE this session — D-4 resolved by measurement, not by a judgement call**

*Estimate: not applicable.* Book 099 (`SL QUOT`, `QTPRN`) has an **empty `BOOK_TBL_NAME`** and, for its
2 `DELETE_DATA` rows, **zero rows in `SL_DATA`, `AC_DATA`, `ROJ_MEL_DATA` and `TEMP_BOOK_DATA`**. The desktop
persists no quotation either, so the web's calculator-only `POST /estimate` loses nothing. Removed from scope.

*Bill-to-bill: the blocker dissolved on inspection.* This was recorded as needing an owner decision because
`settleBills` increments each targeted bill's `REC_AMT`/`KASAR_AMT` in place and records no per-bill
allocation, so subtracting the right amount back is impossible once two vouchers have touched one bill.

Reading the desktop removed the question: **`UPDATE BILL_OS_DATA` appears ZERO times in `TR_BILL_TO.cs`'s
delete path.** The desktop deletes rows keyed to the *settling* voucher's own `VCH_NO` (`:4746`) alongside
`CASH_DATA`, `AC_DATA`, `ROJ_MEL_DATA`, `REMARK_DATA`, `TEMP_BOOK_DATA` and `SL_PR_DETL`, writes a
`DELETE_DATA` audit row, and **leaves the increments it applied to the bills it paid exactly where they are.**

The two models already agreed, which is what made it dissolve: `BILL_OS_DATA` rows belong to the voucher that
*created* the outstanding. Measured — 363 of 365 rows on sales books, 1 on labour work, 1 on book 210
`BILL REC` itself (a settlement that leaves its own balance). `REC_AMT` non-zero on 222 of 365 and
`KASAR_AMT` on 121, so in-place accumulation is the desktop's convention too.

*Implemented:* `deleteBillSettlement` in `finance/billToBill.ts`, routed as `DELETE /bill-to-bill/:vchNo`.

**A desktop flaw is replicated on purpose.** Deleting a settlement does **not** restore the bills it paid —
they stay showing partly paid. That is arguably a defect in the desktop, and it is matched deliberately: the
point of the migration is that the web agrees with the system the business reconciles against, and a more
correct reversal here would make the web's outstanding balances *differ* from the desktop's. Changing it means
changing both systems and persisting the per-bill allocation first. `billToBillDelete.db.test.ts` pins the
behaviour with a test named for exactly that, so it cannot be altered by accident.

*Acceptance:* met. 4 tests, including one asserting the settlement really moved the bill before the reversal,
so the "not restored" assertion is not vacuous.

**F1.5 · Route policy and RBAC entries** · **DONE this session**
- Four routes added under their existing form rights: `Cash / Bank/Contra`, `Cash / Bank/Receipt`,
  `Cash / Bank/Payment`, `Membership/Saving Schemes`. Pinned count **383 → 388**;
  `routePolicy.test.ts` passes with both independent assertions.

### Phase F2 — Make saved vouchers reachable · **F2.1 COMPLETE; F2.2 not started**

**Measured outcome: OPEN for live families 6/19 → 17/19.** Every family that has a voucher to reopen now has a
reader. The two remaining are not vouchers.

**F2.1 · Reading a saved voucher** · **DONE this session**

Nine routes wired to functions that already existed and had simply never been routed — the same finding that
reshaped F1 — plus **two readers written** for the families that had none.

| Family | Live vouchers | Route | Function | New? |
| --- | --- | --- | --- | --- |
| Scheme instalment | 841 | `GET /scheme/installment/:vchNo` | `getSchemeInstallment` | wired |
| **Cash payment** | **133** | `GET /payments/:vchNo` | `getPayment` | **written** |
| Cash receipt | 56 | `GET /receipts/:vchNo` | `getReceipt` | wired |
| **Rate cut / wholesale** | **40** | `GET /rate-cut/:vchNo` | `getRateCut` | **written** |
| Sales order | 39 | `GET /sales-orders/:vchNo` | `getSalesOrder` | wired |
| Contra | 37 | `GET` + `PUT /contra/:vchNo` | `getContra`, `editContra` | wired |
| Scheme maturity | 17 | `GET /scheme/maturity/:vchNo` | `getSchemeMaturity` | wired |
| Fine JV | 14 | `GET /fine-jv/:vchNo` | `getFineJv` | wired |
| Labour invoice | 3 | `GET /labour-invoice/:vchNo` | `getLabourInvoice` | wired |
| Sales return | 1 | `GET /sales-returns/:vchNo` | `getSaleReturn` | wired |
| Order cancel | 1 | `GET /sales-orders/:vchNo/adjustment` | `getSalesOrderAdjustment` | wired |

Route policy 388 → 400, pinned in both independent assertions.

*Why `getPayment` could not reuse `getReceipt`.* A payment's header is **`PAY_DATA`**; a receipt's is
**`CASH_DATA`**. Pointing the receipt reader at a payment finds nothing and reports the voucher missing. The
columns differ too — a receipt carries `REC_AMT`/`REC_AC_CODE`, a payment `NET_AMT`/`TOT_AMT` and `BANK_AC`,
and its narration is `VCH_DESC` where the receipt's is `IT_DESC`. `mode` is **reconstructed** from which amount
column carries the value (`CASH_AMT`/`CHQ_AMT`/`CARD_AMT`), because that is how `postPayment` records it.

*One reader serves rate-cut and wholesale sale*, because `BOOK_DATA` for `MAIN_BOOK='WH SALES'` carries
`BOOK_TBL_NAME='RATE_CUT_DATA'`. It treats an **empty line set as legitimate, not an error** — all 25 real
rate-cut vouchers on book 064 carry zero detail rows, so a reader that took absent lines for a missing voucher
would make the commonest real shape unreadable.

*Two design notes.* The order-adjustment voucher is a separate desktop family (`TR_SL_ORD_ADJ`, book 081) so
it gets its own path rather than overloading `/sales-orders`. The scheme instalment read accepts a `?book`
override because one routine serves 074 `MBENT`, 075 `MBOP` and 076 `MBADJ`, all writing `AD_DATA`; maturity
does not, because the module types its book as the literal `'076'`.

*Acceptance:* met. `apps/api/test/reopenVoucher.db.test.ts` — 8 tests. These are **round trips, not smoke
tests**: post a voucher, read it back, assert the values return under the names they were submitted under. A
`GET` returning a correctly-shaped row carrying another voucher's amounts would pass an existence check and
fail here. The `get*` functions return normalised domain objects (`{ voucherNo, amount, … }`) keyed the way the
poster's input is keyed, which is what makes that symmetry possible, and they **throw** on a missing voucher
rather than returning a blank shape — an empty record reads as "this voucher has no lines".

**The two live families still without OPEN are not vouchers**

| Family | Live | Why |
| --- | --- | --- |
| Scheme enrol | 841 | keyed by member, not voucher — `AD_MEMB` has no `VCH_NO`. `GET /members` already reads it; the same matrix-shape artifact as its DELETE |
| Bill to bill | 1 | a settlement, not a voucher; blocked on D-4 regardless |

**F2.2 · Voucher print path** — not started. Its prerequisite, F2.1, is now in place.

**On EDIT, deliberately not pursued.** `editReceipt`, `editSalesOrder`, `editFineJv`, `editLabourInvoice`,
`editSaleReturn`, `editSchemeInstallment`, `editSchemeMaturity`, `editLedgerAdjust`, `editEmployeeJv` and
`editJournal` all exist and remain unrouted; only contra's was wired, alongside its GET. That is a priority
call, not an oversight: `USER_DATA` — the per-column edit audit — holds **zero** rows for the year, while
`DELETE_DATA` holds 72. This business corrects by deleting and re-entering, so EDIT has no observed usage and
Phase F1 addressed the workflow it actually uses. EDIT sits at 7/19.

**Measured outcome: OPEN for live families 6/19 → 15/19.**

### Phase F3 — Close the day book · **COMPLETE except 2 single-voucher families**

**Measured outcome: day-book coverage 3148 of 3150 rows — 99.9%**, up from the 97% recorded in
`ROJMEL-HANDBOOK.md`, verified by `apps/api/integration/daybook-family-audit.mjs` against live desktop counts.

**F3.1 · Karigar day-book projection** — 29 desktop rows · **DONE this session**
- *Why:* the last implementable Rojmel gap in `ROJMEL-HANDBOOK.md`. Metal moved and the ledger recorded it,
  but the evening day book showed nothing.
- *Measured shape*, all 29 real rows across books 050 and 052:

  | book | type | IT_TYPE | SIGN | key len | rows | meaning |
  | --- | --- | --- | --- | --- | --- | --- |
  | 052 | `11` | G | `+` | 33 | 21 | one per `KR_DETL` line, metal in |
  | 050 | `05` | G | `-` | 33 | 1 | one per `KR_DETL` line, metal out |
  | 052 | `01` | G | `+` | 33 | 3 | **not implemented** |
  | 052 | `02` | A | | 23 | 2 | **not implemented** |
  | 052 | `05` | A | | 23 | 2 | **not implemented** |

  `05` is a **metal** row on book 050 and a **money** row on book 052 — the type code alone does not identify
  a row shape; the book does.
- *Column sources, each verified:* `AC_CODE` = the karigar (`KR_DATA.AC_CODE`, **21 of 21** match);
  `LD_CODE` = the item group's `PURC_AC` (**25 of 25** match — derived through `GROUP_MAST`, the same route
  `purchase.ts` uses, rather than hardcoding account 00008); weights and fine **copied** from the `KR_DETL`
  line because the desktop copies them; `DR_AMT`/`CR_AMT`/`LBR_AMT` zero on all 29 rows.
- *Deliberately left out:* the 7 money rows occur on exactly **two** vouchers (052/00005, 052/00007), the only
  two with a money settlement. Two vouchers cannot separate a rule from a coincidence, and `rojmel.ts` already
  records two readings that were wrong when taken from a handful of sampled rows.
- *Acceptance:* met. `apps/api/test/karigarDayBook.db.test.ts` — 4 tests, including one that **pins the gap**
  so a later partial implementation cannot read as complete, and one asserting a line whose item has no group
  account produces **no** row rather than a row naming a blank account.

**F3.3 · Contra day-book projection** — 74 desktop rows · **DONE this session**
- *Why:* a bank↔cash transfer was invisible in the day book.
- *The builder already existed.* `buildJournalRojmel` encodes exactly the measured rule and had already been
  verified against these same 74 rows (100% DR/CR agreement with each row's own ledger leg). It was simply
  never called from `postContra`, only from `postJournal`.
- *Measured shape:* exactly 2 rows per voucher — type `01` the Cr leg (37/37 carry only `CR_AMT`), type `02`
  the Dr leg (37/37 carry only `DR_AMT`), both `IT_TYPE 'A'`, SIGN blank, key 33 characters, each row naming
  the other side in `LD_CODE`.
- **The write forced a matching reversal.** Adding the projection made the contra-delete test fail: rows were
  left behind, and because `LEDR_KEY` is unique the next voucher reusing that number then failed to post.
  `CONTRA_WRITE_TABLES` now includes `ROJ_MEL_DATA`. The same coupling was applied to `karigarWriteSet`.
- *Acceptance:* met. `contraDelete.db.test.ts` — its previously **vacuous** day-book assertion is now
  load-bearing, guarded by a pre-delete check that rows existed.

**F3.4 · Family-level day-book audit** · **DONE this session**
- *Why:* the matrix's DAYBOOK column is a module-level grep, and `finance.ts` serves several families, so
  contra was reported as covered when it wrote nothing.
- *New tool:* `apps/api/integration/daybook-family-audit.mjs` — per posting function, desktop row count from a
  live query against whether that function's own call graph projects.
- **Two of my own false readings, caught before reporting.** The first version scanned only the exported
  entry point's body and reported SALES, PURCHASE, MEMB ENTRY and FINE JV as not projecting — a false
  *negative*, because the projection lives in private helpers (`writeSaleTx`, `writePurchaseTx`,
  `postMemberEntry`, fineJv's local `write`). It now follows module-local calls transitively. The mirror of
  the module-wide grep's false *positive*: both were wrong because the unit of analysis was not the call
  graph. It also had one wrong entry-point name (`postOtherCommission` for what is `saveOtherCommission`).

**F3.2 · Re-measured coverage** · **DONE this session**

| Family | Desktop rows | Projects |
| --- | --- | --- |
| MEMB ENTRY | 1635 | yes |
| SALES | 556 | yes |
| CASH PAY | 185 | yes |
| BANK PAY | 130 | yes |
| PURCHASE | 115 | yes |
| CASH REC | 106 | yes |
| BANK REC | 97 | yes |
| **CONTRA** | **74** | **yes — new this session** |
| RATE CUT | 66 | yes |
| SALES ORDER | 55 | yes |
| MEMB ADJUST | 37 | yes |
| **WH SALES** | **32** | **yes — via the wholesale routing fix** |
| FINE JV | 28 | yes |
| **KARIGAR RECEIPT** | **28** | **yes — new this session** |
| OTH INC | 2 | yes |
| **KARIGAR ISSUE** | **1** | **yes — new this session** |
| SALES RETURNE | 1 | yes |
| ORDER CANCEL | 1 | **no** |
| BILL REC | 1 | **no** (blocked on D-4) |

**Remaining: 2 rows.** `ORDER CANCEL` (1 row, `cancelSalesOrder`) and `BILL REC` (1 row, blocked on the
bill-to-bill model decision D-4). The desktop total across all books is 3152; the 2 unlisted rows belong to a
book with a blank `MAIN_BOOK` — the retired URD purchase book recorded as not-a-gap in `ROJMEL-HANDBOOK.md`.

### Phase F4 — Reconcile the values (from the 66-voucher diff) · **F4.1 largely DONE**

**F4.1 · Fine-metal quantities** · **DONE this session — 256 → 76 differences, a 70% reduction**

| Column | Before | After | |
| --- | --- | --- | --- |
| `MAIN_STOCK.ITM_QTY` | 69 | **0** | real defect, fixed |
| `AC_DATA.FINE_WT` | 48 | 17 | harness artifact removed |
| `MAIN_STOCK.ITM_FINE` | 45 | 12 | harness artifact removed |
| `PR_DETL.ITM_FINE` | 45 | 12 | harness artifact removed |
| `PR_DATA.PARTY_FINE` | 49 | 35 | harness artifact removed |
| **Total** | **256** | **76** | |

Overall field differences 4349 → **4106**.

#### The fine differences were mostly MY OWN HARNESS, not a web defect

Before changing any product code I checked the arithmetic, and the ratios gave it away: web/desktop sat at
**0.9293 on line after line**, which is exactly **92/99** — a touch of 92 with 7% wastage dropped.

`parity-replay-generic.mjs` was passing only `pcs/gross/net/touch/rate/amount` from each desktop line. But
`ITM_WEST_PRC` is non-zero on **43 of 103** real purchase lines, and the fine formula is
`(net + ght) × (touch + west) / 100` (`shared/finePolicy.ts`), so omitting wastage made the web compute a
*lower* fine on every one of those lines. The rate-cut builder had the same bug in a subtler form: it read
`l.ITM_WEST`, and the column is `ITM_WEST_PRC`, so `num(undefined)` made wastage silently zero.

**Had I not checked, I would have reported ~118 field differences as a systematic web fine-calculation defect.**
The lesson generalises: an input-side column omitted in the replay shows up as a derived-value defect in the
diff, and a wrong column name reads as a legitimate zero.

The desktop fine rule, measured over all 103 real purchase lines while chasing this:
* `touch = 0` → **fine = net weight** (39 of 39 — touch 0 means the metal is already fine)
* `touch > 0` → **fine = net × (touch + west) / 100** (60 of 64)
* the 4 residuals are operator-typed overrides, e.g. net 1.64 at touch 85 stored as `1.400` where the formula
  gives `1.394` — which is exactly one of the pairs still in the diff

#### `MAIN_STOCK.ITM_QTY` was a real defect, and it is now zero

`ITM_QTY` is a small signed stock-**movement count**, never a weight. Measured over all 1856 real
`MAIN_STOCK` rows: **it is an integer without exception — 0 fractional** — and every transaction book writes
exactly `1`:

```
PURCHASE 77/77 · SALES 267/267 · TAG GEN 190/190 · WH SALES 22/22 · KARIGAR RECEIPT 21/21
LABOUR WORK 4/4 · SALES ORDER 3/3 · TAG CANCEL 2/2 · TAG TRFR 2/2 · SALES RETURNE 1/1 · KARIGAR ISSUE 1/1
```

It coincides with `ITM_PCS` on 95% of rows only because most lines are one piece; where pieces is 2 the desktop
still writes 1. Only **OPSTK**, the opening-stock import, departs — and there quantity tracks pieces
(1231 of 1241).

The web wrote `netWt || pcs || 1`, so a 19.72 g line put **20** into the column. `sales.ts:1124` records this
same defect being found on the sale path by replaying a real voucher and fixed there — **and left in place in
eleven sibling modules**: purchase, purchaseReturn, salesReturn, tagSplit (×2), tagOps, fineInout, mfg,
karigar, tour (×2), stock (×3) and stockVoucherLifecycle (×3). All now corrected — literal `1` on transaction
vouchers, `pcs` on the opening-stock paths.

#### What remains in F4.1

The 76 residual differences are **±0.001 three-decimal rounding** (ratios 0.9995–1.0007), plus the handful of
operator-typed overrides above and `PARTY_FINE` cases where the desktop holds 0 and the web a value. Rounding
at the third decimal on a fine weight is real but of a different order from the 0.9293 error, and needs a
golden-vector test per formula rather than a code change guessed at.

Ordered by business meaning, not by count. Reference: `FIXES-AND-SCALED-COMPARISON-2026-08-02.md` §3.

**F4.2 · Key and classification columns** · **DONE this session — 386 → 66 in the targeted block; overall 4106 → 3787**

Ten of the fifteen targeted columns are now at zero. The single most serious finding was not on the list.

| Column | Before | After | |
|---|---|---|---|
| `PR_DETL.OLD_SRNO` | 78 | **0** | |
| `PR_DETL.ADD_USER` | 78 | **0** | |
| `MAIN_STOCK.SR_NO` | 27 | **0** | |
| `AC_DATA.VCH_TYPE` / `BOOK_NAME` | 16 + 16 | **0** | |
| `RATE_CUT_ISU.VCH_TYPE` / `BOOK_NAME` | 14 + 14 | **0** | |
| `RATE_CUT_ISU.OLD_SRNO` / `DATA_TRFR` | 14 + 14 | **0** | |
| `ROJ_MEL_DATA.VCH_TYPE` / `BOOK_NAME` | 12 + 12 | **0** | |
| `AC_DATA.LD_CODE` | 18 | 2 | |
| `ROJ_MEL_DATA.LD_CODE` | 23 | 12 | |
| `ROJ_MEL_DATA.LEDR_KEY` | 32 | 32 | deferred, see below |
| `AC_DATA.LEDR_KEY` | 18 | 20 | deferred, see below |

**The web wrote ledger contras pointing at accounts that do not exist.** `rateCut.ts` shipped the hardcoded
codes `'SALEGOLD'`, `'CASH'`, `'KASAR'`, `'LABOUR'`, `'OTHER'` as its account defaults, under a comment
stating *"BOOK_DETL is EMPTY for book 064 in this dataset, so the precise mapping cannot be reproduced."*
**That comment was false.** `BOOK_DETL` holds 24 rows for books 034/064 and 455 overall, mapping exactly the
SR positions the same file already documented — SR1 `00003` SALES GOLD, SR3 `00001` CASH, SR4 `00057` KASAR,
SR6 `00041` LABOUR, SR11 `00077` OTHER CHARGES.

`AC_MAST` contains **no row** with `AC_CODE` `'SALEGOLD'`, `'CASH'` or `'BANK'`, so every ledger and day-book
row written this way carried a contra that no join could resolve — the rows existed and were invisible.
Accounts are now resolved per book from `BOOK_DETL`, and posting **fails closed** if a slot is unconfigured,
because a rejected voucher is recoverable and a silently unjoinable one is not.

**Wholesale was classified as rate-cut.** Books 034 (`WSALE` / `WH SALES`) and 064 (`RCUT` / `RATE CUT`) both
carry `BOOK_TBL_NAME='RATE_CUT_DATA'`, and the module stamped its own constants, so wholesale vouchers
reported as rate-cut across `AC_DATA`, `RATE_CUT_ISU` and `ROJ_MEL_DATA` — 84 differences. `VCH_TYPE` and
`BOOK_NAME` are now read from the voucher's own `BOOK_DATA` row.

**Two provenance rules were wrong at the choke point, not in one module.** `applyProvenance` in `posting.ts`
applied both blanket:
- `ADD_USER` mirrored `MAIN_USER` on every table. Measured across all 19 tables carrying both columns, the
  desktop populates `ADD_USER` on **only two** — `BAR_DETL` 1169/1329 and `SL_ORD_DETL` 25/63 — and leaves it
  empty on the other seventeen (`PR_DETL` 0/103, `CASH_DATA` 0/335, `SL_DETL` 0/245, `CONTRA_DATA` 0/102).
  Where it *is* written it always equals `MAIN_USER`, so the form was right and only the scope was wrong.
- `DATA_TRFR` defaulted to `'N'` on every table. Five never populate it (`AD_OS` 0/8194, `SL_DETL` 0/245,
  `SL_PR_DETL` 0/25, `RATE_CUT_ISU` 0/20, `SL_DETL_RTN` 0/1) and two store `'Y'` (`OP_DATA` 108/108,
  `ITM_OPBL` 72/72).

Both are now decided per table from the measured sets. Two existing tests asserted the old blanket behaviour
and were corrected against the database rather than worked around.

**`MAIN_STOCK.SR_NO` is 1 on a goods-received voucher, not a line ordinal** — 77 of 77 purchase-book rows,
one distinct value, including 3- and 4-line vouchers writing `1,1,1`. Same shape as the F4.1 `ITM_QTY` defect.
Deliberately **not** generalised: the bulk books do use it as a sequence (OPSTK reaches 108, TAG GEN 35) and
no single rule fits them — TAG GEN matches rank-within-voucher on 0 of 190 rows while OPSTK matches on
1189 of 1241, so those paths were left alone.

**`OLD_SRNO` is the line's own serial on original entry** — measured equal to `SR_NO` on 103 of 103 `PR_DETL`
rows and 20 of 20 `RATE_CUT_ISU` rows, with zero nulls and zero zeros. The web wrote `0`.

**`LEDR_KEY` is deferred on purpose, and it is the largest single remaining item.** The differences are
confined to the final two characters — the whole prefix (`CO_CODE` `LC_CODE` `CO_YEAR` `CO_BOOK` `VCH_NO`) and
the 33-char line suffix already match. That segment is a **semantic leg code**, not a counter: on real
wholesale voucher 034-00001 the four legs are `01` (party debited for value), `02` (its sale-gold contra),
`43` (party credited for the cash settlement) and `44` (its cash contra), while 034-00002 uses `23`/`29` for a
metal-transfer pair. The web writes its own fixed `51`/`54`/`55`.

Deriving this means mapping every leg purpose to its code across **49 distinct codes on `AC_DATA` over 40
books** and **18 on `ROJ_MEL_DATA` over 38** — and some books pad to `' 1'` where others use `'01'`, so the
format is per-book too. `AC_DATA.LEDR_KEY` moved 18 → 20 as a side effect of the account fix changing which
legs exist. Guessing the taxonomy would silently mis-key or collide rows, which is worse than the current
internally-consistent scheme, so it is left for a dedicated item with the vocabulary measured above.
`ROJ_MEL_DATA.LEDR_KEY` (32), `MAIN_STOCK.SR_NO` (27), `ROJ_MEL_DATA.LD_CODE` (23),
`AC_DATA.LEDR_KEY`/`LD_CODE` (18 each), `AC_DATA.VCH_TYPE`/`BOOK_NAME` (16 each),
`RATE_CUT_ISU.VCH_TYPE`/`BOOK_NAME` (14 each), plus `DELETE_DATA.FINE_TYPE` (A/G/S — 72 of 72 desktop rows
valued, web writes `''` on the karigar path).
- *Why:* `LEDR_KEY` is how reports join a leg to its voucher. A wrong key is an invisible row.
- *Where:* `posting.ts` `enrichLedgerLine` builds `LEDR_KEY`; `bookPolicy.ts:84` reads `BOOK_SNAME` for
  `VCH_TYPE`.
- *Acceptance:* zero differences on these columns; a test that a report joining on `LEDR_KEY` finds the row.

**F4.3 · Structural row differences**
Missing: `ROJ_MEL_DATA` 68, `AC_DATA` 62, `MAIN_STOCK` 22, `PR_IDTL` 20 (stone sub-detail),
`TEMP_BOOK_DATA` 15, `RATE_CUT_ISU/REC` 9.
Over-written by the web: `LOT_DETL` 78, `BILL_OS_DATA` 51.
- *Why:* an extra `BILL_OS_DATA` row is a phantom outstanding bill; a missing `PR_IDTL` row loses the stones.
- *Acceptance:* `rowsMissing` and `rowsExtra` both zero for the 66 cases.

**F4.4 · Remaining 1508 zero-vs-NULL**
- *Why:* the measured default spec deliberately excludes columns whose table also holds NULLs
  (`posting.ts` `DESKTOP_COLUMN_DEFAULTS`, 249 such columns). Those need a per-column decision.
- *How:* extend `derive-column-defaults.mjs` to a per-book rather than per-table denominator; a column NULL in
  one family and 0 in another is not one rule.

### Phase F5 — Extend the harness to the remaining workflows

**F5.1 · Family builders for the untested workflows**
`MEMB ENTRY` (841 vouchers), `CASH PAY`/`CASH REC` (189), `CONTRA` (37), `SALES ORDER` (39), `FINE JV` (14),
`KARIGAR RECEIPT` (16).
- *Where:* the `FAMILIES` registry in `apps/api/integration/parity-replay-generic.mjs` — additive.
- *Acceptance:* replayed count rises from 66 toward the 1567 total; each family's cases appear in the diff.

**F5.2 · Dependency ordering so tagged sales can replay**
- *Why:* `sale-032-00001` fails with `tag not available for issue` because the tag must exist first. This is a
  harness ordering gap, not a web defect.
- *How:* order cases by voucher date, replaying the stock-creating families before the consuming ones.
- *Acceptance:* the 100 sales in book 032 replay.

**F5.3 · Report data comparison**
- *Why:* 0 of 254 templates have proved data equality, and unsupported templates default to `SL_DATA`.
- *How:* `report-compare.mjs` already exists. Point it at `Live24` and compare report *data* — Crystal
  rendering still needs the Windows box, but the data does not.
- *Acceptance:* per report, row counts and totals equal; unsupported templates **fail** rather than
  defaulting.

### Phase F6 — Statutory and close-out

**F6.1 · GST from `TAX_DATA`**
- *Why:* desktop `RP_GST.cs:1776,2015,2173` filters `TAX_DATA`; web reads `SL_DATA`/`SL_DETL`
  (`gst.ts:179,201`) and `PR_DATA` (`reports3.ts:125-138`). GSTR-1 also ignores the date range because
  `scopeSql` consumes only company/location/year (`gst.ts:131-151`). GSTR-2 is one aggregate row; GSTR-3B has
  no inward/ITC.
- *Acceptance:* GSTR-1/2/3B compared against desktop output for the same period; the date range demonstrably
  filters.

**F6.2 · Register classification**
- *Why:* `COMPLETION-REGISTER.json` holds 198 menu items, **198 unclassified**, so `register:check` passes
  vacuously in non-strict mode.
- *How:* classify against the functional matrix rather than by form name, then switch the gate to `--strict`.

**F6.3 · Wire the two skipped gates**
`schema:readiness` reports `SKIP no MIGRATE_DATABASE_URL`; `type:parity` reports `SKIP no MSSQL_TYPES dump`.
Both print a pass-shaped line while doing nothing.
- *Acceptance:* both run in CI, or fail with a reason. Never skip silently — the same trap the test suite had.

### Phase F7 — Owner decisions

**D-1 · Header-only rate-cut.** 25 of 25 real vouchers have zero detail rows; value carried in `FINE_RATE`,
`TOT_FINE_DR`, `CR_AMT`. `rateCut.ts:585` rejects them. Allowing it means deriving the ledger and Rojmel legs
from header settlement instead of from lines — a decision about your accounting, not a mechanical fix.

**D-2 · The fine double-count** carried forward unresolved in `reflection.md`: possibly a desktop defect rather
than behaviour to replicate. Needs a ruling before it is matched or waived.

**D-3 · A second customer database.** Every priority here rests on one company and one fiscal year. The six
dhrn/loan routines are dead in this data and would be the main event for a pawnbroker
(`STATE-OF-PARITY.md` §5.5). This is also the cheapest way to test the ranking and unblocks the migration
rehearsal.

**D-4 · Bill-to-bill reversal model — RESOLVED, no decision needed.** Reading `TR_BILL_TO.cs` showed
`UPDATE BILL_OS_DATA` appears **zero** times in the desktop's delete path: it deletes its own rows and leaves
the increments it applied to other bills in place. Matching that is what parity requires, so the reversal was
implemented in F1.4 without a judgement call. What DOES remain a question, but a smaller one: whether you want
the increments restored — which would be more correct than the desktop and therefore a divergence, and would
need the per-bill allocation persisted in both systems first.

---

## 5. Suggested sequence

| Phase | Content | Why here |
| --- | --- | --- |
| F1 | Correction workflow (5 deletes) | restores the workflow the business actually uses; small and independent |
| F3 | Close the day book (karigar) | the evening report is what the owner reads; last implementable gap |
| F2 | Reachable vouchers (13 OPEN, print) | unblocks reprint; prerequisite for print baselines |
| F4.1–F4.2 | Fine metal, then keys | money correctness |
| F5.1–F5.2 | Extend the harness | each new family multiplies what F4 can prove |
| F4.3–F4.4 | Structural rows, remaining NULLs | needs F5 breadth to be worth doing |
| F6 | Statutory, gates, register | legal exposure, but blocked on F4/F5 being trustworthy |
| F7 | Decisions | can start now, in parallel |

F1 and F3 together are the smallest change that makes the system usable for a day's trading and a correct
evening close.

## 6. How to verify anything in this plan

Follow `web/docs/VERIFICATION-REFERENCE.md`. The rules that matter most, all learned from documented errors:

1. **Count the output, then the source columns, then read the source, then take directions from the data.**
   Every step exists because skipping it produced a wrong conclusion.
2. **Treat an empty result as failure, not as "no rows".** The desktop container is amd64 under emulation and
   does stop; an empty answer read as a finding twice in one day.
3. **Prove a control fails before trusting it.** Around 60 controls have been proven this way; two went green
   against deliberately broken code until the cause was found.
4. **Never conflate a pinned layout with a working report,** or a registered route with a working feature.
   This document exists because those were conflated.
5. `Live24` is real customer data. Extract counts and structure only; the bundles are git-ignored and
   verified so with `git check-ignore`.

## 7. Reference index

| Document | Use |
| --- | --- |
| `PARITY-AND-GAP-REPORT-2026-08-02.md` | structural audit, 162 forms, gate status |
| `FIXES-AND-SCALED-COMPARISON-2026-08-02.md` | the four critical fixes, 66-voucher diff, 4349 residual |
| `project-memory/parity/FUNCTIONAL-PARITY-MATRIX.json` | this document's lifecycle measurement |
| `project-memory/parity/DESKTOP-FOOTPRINT-CENSUS.json` | per-book write-set specification, 40 books |
| `web/docs/VERIFICATION-REFERENCE.md` | method, recipes, SQL helper, process rules |
| `web/docs/VALIDATION-PLAN.md` | the 11 test layers and control-coverage measure |
| `web/docs/MODULE-VERIFICATION-CATALOGUE.md` | per-module authority, tables, next measurement |
| `web/docs/ROJMEL-HANDBOOK.md` | day-book coverage and routine classification |
| `web/docs/MIGRATION-COMPLETION-PLAN.md` | the nine pre-existing phases |
| `project-memory/contracts/*.contract.md` | per-form validations and golden-vector ids |
| `project-memory/parity/FEATURE-GAP-REGISTER.md` | control-level gap register |
