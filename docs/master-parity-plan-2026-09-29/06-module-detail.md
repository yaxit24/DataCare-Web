# Current web implementation audit and module continuation appendix

Date: 29 September 2026. Baseline: commit `03148fef5899224b8c4c9805ca07161a920efeb1` in DataCare-Web. This is a static read-only inspection for planning. No application code was modified, no database was opened or mutated, no tests/builds were executed by this module sub-review. The parent planning review separately ran the core and frontend suites; see `evidence/verification-observations.json`. Existing test names below are inventory evidence, **not new passing results**. Proposed procedures are future acceptance obligations. Paths are repository-relative to avoid binding the plan to a temporary checkout.

## Conclusions that change planning

- The implementation is substantial: current static inventory has **31 API module directories, 248 API TypeScript source files, 126 Next page files and 174 Prisma models**. Test inventory is 266 top-level API TypeScript test files (151 `*.db.test.ts`), 36 web TypeScript test files and 26 core TypeScript test files. Inventory does not measure usable or certified breadth.
- Retained current status is Round15 in progress: 198/198 menu mappings, 0/198 complete menu acceptances, all 83 packages/all 34 continuation cards open. 72.1% is an older static field/control proxy, not functional completion. Round15 retained only core 26 files/1,613 tests and five-test-file strict compilation; 16 planned recipe checks were not run and checkpoint43 does not exist. The latest sealed checkpoint41 applies to earlier inputs. These are repository-recorded historical claims, not executions performed today.
- **Return terminology must be exact.** New saved-incoming row/bill/labour replay and pure Save prerequisites are diagnostic/non-committing. Bounded saved metadata does write. Legacy numeric Return creation remains routed: `web/apps/api/src/routes/txn.ts` registers POST `/sales-returns`, plus GET/DELETE; `editSaleReturn` exists as an exported internal service but is not imported or routed there; `web/apps/web/app/(app)/txn/sale-return/page.tsx` has an active `LegacySaleReturnForm`. Do not summarize this as all Return numeric writes globally disabled.
- **Lot manufacturing is currently read-only**, with existing document/source browsing and `writes:false`, not an end-to-end lot issue/receipt workflow. E Credit Note has saved browse/read plus IRN, not a complete credit-note authoring lifecycle.
- **Six operations remain explicitly contained:** logical restore, production migration load, tag transfer, tag cancellation, tag weight difference and tag split. Tag-opening update was separately released. Each blocked tag mutation needs its own independent release evidence.
- Report catalog/layout/endpoint existence is not report acceptance: unsupported bindings refuse, selected templates bind real data, and unbound layout previews retain placeholders. The static form-layout renderer renders disabled controls and is not an interactive implementation.
- Numerical policy is mixed. Core uses decimal.js, but many helpers return Number, older modules use Math.round and real schema retains Float columns. The newer exact saved Return pipeline deliberately qualifies raw/text/Float preservation. Neither blanket decimal conversion nor imported-row delete/reinsert is a proven universal parity solution.
- GST contains a fixed B2CL threshold and HSN fallback to item code. Those are concrete implementation facts requiring effective-dated rule review and proper master mapping; this audit does not provide legal advice or assert the current statutory threshold.
- A static carry-forward scope risk is visible in `masters/year.ts:114`: the helper accepts a branch but deletes/aggregates company-wide year openings, then stamps output with one branch. Establish the intended source ownership and prove branch preservation before release; this audit did not invoke the operation.
- A specific unproven concurrency risk is visible in loyalty redemption: balance is read before numbering without explicit member locking or Serializable isolation. Add a real race regression before calling redemption safe under concurrent use.

## Cross-cutting completion contract

Each module below inherits the complete old package requirements and the parent plan's form/menu/report/settings/source registers. A selected representative test is not exhaustive acceptance. Every discovered required leaf needs source and behavioral reference, current web mapping, exact implementation owner, positive/negative/boundary/concurrent/browser evidence and release identity. Required omissions must remain open; no generic "works" checkbox or field count closes a module.

For every financial/stock mutation, verify all owned and retained effects: header/detail/child, serial/hidden number, AC_DATA, ROJ_MEL_DATA, MAIN_STOCK, TAX_DATA, BILL_OS_DATA, tender/source/image/audit/reference families as applicable. Use full physical and business identity; preserve null/blank/zero, source timestamps, scale and Float semantics. Independently capture before/after desktop output. Verify create, reopen unchanged, permitted edit, reverse/delete, repeat/lost acknowledgement, concurrent conflict, dependency refusal, period/date/scope/rights refusal and rollback after each write-family boundary. Browser steps must use a real API and isolated non-owner database; no mocked browser response certifies persistence.

Business continuation order: scope/identity/numeric contracts and fresh-company setup → exact master/design/stock openings → purchasing/stock → sales/orders/returns/custody → finance/bullion/loans/schemes/manufacturing → every report/document/device/provider → migration/recovery/full-business-day release. Work can proceed in parallel only where contract ownership and dependencies are resolved; cross-module acceptance remains mandatory.

## Module-by-module continuation

The following sections cover every actual directory under `web/apps/api/src/modules`. “Observed” means code was inspected or its exports were inventoried; it does not mean runtime equivalence was established. Implementation steps are normative future work or verification of reusable code, not claims that all listed behavior is absent. Source anchors are one-based lines at the audited commit. Named tests are real files checked for presence.

### accounting

Prior obligations: P01-03, P06-06, P10-03; X06/X16/X26. Operator surfaces: `reports/[report], reports/voucher-register, txn/ac-opbl and company/balance-transfer`.

**Observed:** `accounting.ts` implements read-only trial balance and account ledger from AC_DATA, with SQL scope predicates and opening/running balance. It is not the complete desktop accounting engine: financial statement, metal, stock valuation and Rojmel implementations are in reports/shared; year close is in ops. The API edge converts exact database amounts to Number (`summarizeTrialBalance`, `applyRunningBalance`), so a balanced trial balance is an aggregate check, not proof of exact posting or historical mode fidelity.

**Current implementation anchors:**
- `web/apps/api/src/modules/accounting/accounting.ts` — `summarizeTrialBalance` line 33; `applyRunningBalance` line 56; `trialBalance` line 97; `accountLedger` line 118 (184 lines total).

**Existing test files to retain and extend:**
- `web/apps/api/test/accounting.test.ts`
- `web/apps/api/test/finalReports.db.test.ts`
- `web/apps/api/test/tradingReport.db.test.ts`
- `web/apps/api/test/closingStock.db.test.ts`
- `web/apps/api/test/desktopAccountBalance.db.test.ts`

**Implementation sequence:**

1. Reconcile desktop account/group hierarchy, opening, money/fine/gold/silver balances and ledger-mode selection with actual report APIs; record which book/data-type/year dimensions each includes.
2. Extend exact amount serialization through ledger datasets and summary exports; define source rounding at accumulation versus display instead of applying blanket two-decimal rounding.
3. Complete account ledger search, date-range opening and multi-book same-number drill-down with the full voucher identity and normal view/print rights.
4. Reconcile trial balance, trading, profit/loss, balance sheet, outstanding and Rojmel from the same committed candidate, explaining every legitimate source difference.
5. Bind year close and opening carry to accountant-approved exact balance snapshots, retained history and reopening rules; do not infer trusted desktop ledger mode from an unknown session state.

**Step-by-step verification cases and expected outcomes:**

1. Seed one account with an opening and dated debit/credit entries in two years; open a mid-period ledger, check opening=all permitted pre-period entries, ordered running balance and closing; compare the exact independent desktop rows.
2. Post, amend and reverse a sale with mixed tenders; read ledger, trial balance, outstanding and Rojmel after each step; expected account/stock/tax effects change together and unrelated books remain unchanged.
3. Create identical voucher numbers in two branches/books; drill down from each report; only the intended full identity opens, and switching scope cannot reuse a stale result.
4. Inject a failure during year-close carry; reopen all financial reports; no partial opening or closing flag persists, and a successful retry produces one carry set rather than duplicate balances.

### auth

Prior obligations: P01-01/P01-05, P02-06, P11-04; X05/X09/X29. Operator surfaces: `login, select, password-change; components/BusinessScope.tsx and lib/pageContext.ts`.

**Observed:** A substantial authentication/session layer exists: Argon2 passwords, JWT/session persistence, server-owned business scope, context epoch, selection/refresh and transaction-bound command/read snapshots. Dedicated Serializable coordination also exists. New Sales/Tour and Return preview work uses these bounded guards. This does not establish that every older writer and device/upload/report request has an equally strong stale-context contract. `sessionLedgerMode.ts` is a pure semantic model, and runtime context remains deliberately unable to invent trusted edition/known closing authority.

**Current implementation anchors:**
- `web/apps/api/src/modules/auth/session.ts` — `REFRESH_SESSION_TTL_MS` line 5; `createAuthSession` line 75; `validateAccessSession` line 124; `rotateRefreshSession` line 143 (274 lines total).
- `web/apps/api/src/modules/auth/businessScope.ts` — `validateStoredScopeTx` line 133; `resolveLoginScopeTx` line 157; `resolveLoginScope` line 164; `resolveSelectedScopeTx` line 172 (316 lines total).
- `web/apps/api/src/modules/auth/sessionContextCommand.ts` — `withSessionContextCommand` line 265 (377 lines total).
- `web/apps/api/src/modules/auth/sessionContextReadSnapshot.ts` — `SESSION_CONTEXT_READ_SNAPSHOT_VERSION` line 14; `withSessionContextReadSnapshot` line 264 (365 lines total).
- `web/apps/api/src/modules/auth/sessionContextSerializableCommand.ts` — `SESSION_CONTEXT_SERIALIZABLE_COMMAND_VERSION` line 14; `withSessionContextSerializableCommand` line 298 (405 lines total).
- `web/apps/api/src/modules/auth/sessionContextSelection.ts` — `parseContextSelectionRequest` line 137; `contextSelectionRequestSha256` line 161; `selectSessionContext` line 373 (505 lines total).
- `web/apps/api/src/modules/auth/sessionContextRefresh.ts` — `refreshSessionContext` line 142 (275 lines total).
- `web/apps/api/src/modules/auth/sessionContextValue.ts` — `SESSION_LEDGER_CONTEXT_VERSION` line 5; `MAX_CONTEXT_EPOCH` line 6; `parseContextEpoch` line 39; `nextContextEpoch` line 54 (123 lines total).

**Existing test files to retain and extend:**
- `web/apps/api/test/auth.service.test.ts`
- `web/apps/api/test/auth.session.test.ts`
- `web/apps/api/test/sessionContextHttp.db.test.ts`
- `web/apps/api/test/sessionContextCommand.db.test.ts`
- `web/apps/api/test/sessionContextSerializableCommand.db.test.ts`
- `web/apps/api/test/orderSessionCommands.db.test.ts`

**Implementation sequence:**

1. Inventory every authenticated request by scope source, context headers, read snapshot/writer coordinator and final freshness check; extend current guarded patterns to all financial, inventory, image and device operations.
2. Define account/company/branch/year/book selection and edition/ledger authority from trustworthy installation records; unknown or ambiguous provider facts must remain explicit unavailability.
3. Specify draft preservation and user recovery for expiry, logout, password change, privilege revocation, context switch and lost-response cases without silently adopting toolbar scope.
4. Finish multi-tab lifecycle: retire in-flight responses and captured device leases, invalidate selected books, and recover with explicit fresh context after a successful context command.
5. Validate transactions against real non-owner PostgreSQL isolation and genuine concurrent changes, including final clock/session checks; retain source qualifications rather than broadening a pure proof into runtime authority.

**Step-by-step verification cases and expected outcomes:**

1. Open a sale in tab A; change company/year in tab B; submit A. Expect a context conflict, unchanged financial tables and draft retained until explicit reload.
2. Start a protected mutation then revoke its right or expire its session before the final check; expect rollback of all document and audit writes, not a successful business commit with a denied response.
3. Expire access credentials and refresh concurrently in two tabs; one coherent session epoch and server-selected scope must remain, with obsolete responses unable to overwrite new context.
4. Simulate a lost response after context selection and after a financial save separately; context receipt recovery must not be assumed to deduplicate finance. Verify financial reload/receipt policy before allowing a retry.

### bullion

Prior obligations: P06-04/P06-05; X16. Operator surfaces: `txn/bullion, txn/fine-sale and txn/bullion-sale (rateCut.ts)`.

**Observed:** `bullion.ts` has a real booking writer and deletion, not a stub: BUL_DATA plus balanced AC_DATA are posted transactionally. It still supplies fallback accounts BULLION/CASH, hardcodes BOOK_NAME BULLION and initializes ADJ_WT. Its own exported surface lacks a full reopen/edit booking lifecycle. `fineSalePurchase.ts` has real create/delete functions; bullion sale/rate cuts are implemented separately in sales/rateCut.ts. Cross-family settlement and original desktop footprints remain acceptance work.

**Current implementation anchors:**
- `web/apps/api/src/modules/bullion/bullion.ts` — `buildBookingLedger` line 75; `bullionBooking` line 101; `deleteBullionBooking` line 189 (206 lines total).
- `web/apps/api/src/modules/bullion/fineSalePurchase.ts` — `fineLineCalc` line 83; `createFineSalePurchase` line 103; `deleteFineSalePurchase` line 355 (405 lines total).

**Existing test files to retain and extend:**
- `web/apps/api/test/bullionSale.db.test.ts`
- `web/apps/api/test/rateCutSettlement.db.test.ts`
- `web/apps/api/test/settlement.test.ts`
- `web/apps/api/test/workflows.test.ts`

**Implementation sequence:**

1. Extract both purchase/sale booking directions, fixed/unfixed rate, premium/discount, per-unit rate basis and cash/bank/fine settlement branches from TR_BUL_BOOKING/TR_BUL_SALE/TR_FINE_SL_PR.
2. Replace fallback ledger/book identities only through source-backed configured account resolution; preserve imported booking snapshots, dates, row serials and hidden identity on reopen.
3. Implement complete booking read/edit/cancel with downstream adjustment guards and an explicit source-row revision; a booked quantity already consumed must not disappear on edit.
4. Implement partial and multi-book booking allocation for bullion sale/rate cut, updating ADJ_WT and outstanding consistently with the sale posting under deterministic source locks.
5. Expose all branches and source allocation history in the operator forms, documents and booking/outstanding reports; complete two-sided rate-cut receiving separately.

**Step-by-step verification cases and expected outcomes:**

1. Create a gold booking with an advance; reopen and compare BUL_DATA, AC_DATA, hidden number and source-calculated amount; unchanged Save must preserve imported text/null/scale where unowned.
2. Allocate 40% and then the remaining booking to two sales; expected ADJ_WT and outstanding reduce exactly, and a third allocation is rejected without stock/ledger writes.
3. Race two allocations against the same remaining fine weight; at most the allowed quantity commits and the losing request retains its draft with a conflict.
4. Attempt booking deletion after an adjustment; expect a linked-document rejection. Reverse dependent sales in permitted order, then delete; all booking effects unwind and audit remains.

### dhrn

Prior obligations: P09-01/P09-02/P09-05; X24. Operator surfaces: `txn/dhrn-issue, dhrn-receipt, dhrn-interest, loan-issue and loan-received`.

**Observed:** `dhrn.ts` implements issue, receipt, separate interest receipt, outstanding and delete, plus distinct loan wrappers and multiple interest helpers. DHRN_DATA and issue/receipt detail, ledgers and documents exist. Source-specific date/term/loan-type semantics and all custody/default/redemption variants require independent acceptance; helper presence alone cannot certify a borrower lifecycle.

**Current implementation anchors:**
- `web/apps/api/src/modules/dhrn/dhrn.ts` — `DEFAULT_YEAR_DAYS` line 45; `accruedInterest` line 57; `monthlyInterest` line 68; `monthlyTermInterest` line 81 (1077 lines total).
- `web/apps/api/src/modules/dhrn/dhrnReceipt.ts` — `dhrnIssueData` line 25; `dhrnIssueHtml` line 68 (149 lines total).
- `web/apps/api/src/modules/dhrn/dhrnKhata.ts` — `dhrnKhataData` line 23; `dhrnKhataHtml` line 53 (119 lines total).

**Existing test files to retain and extend:**
- `web/apps/api/test/dhrn.test.ts`
- `web/apps/api/test/dhrnLoanLifecycle.db.test.ts`
- `web/apps/api/test/dhrnReceipt.db.test.ts`
- `web/apps/api/test/dhrnLoanReports.db.test.ts`

**Implementation sequence:**

1. Build a separate state machine for dhiran pledged-goods lending, monetary loan issue and loan received, including direction, principal account, interest basis and custody owner.
2. Extract inclusive/exclusive dates, calendar/month/term boundaries, leap years, minimum charges, loan-type rounding and setting precedence into independent fixtures.
3. Complete pledged parent/component/image identity, partial redemption, repledge/renewal, release and default/auction paths actually reachable in the desktop edition.
4. Implement source-aware edit/delete of issue, principal receipt and interest-only receipt, preventing alterations that invalidate later repayments or collateral movements.
5. Connect borrower search, outstanding selection, tender splitting, receipt/passbook/khata documents and ageing/due notices; retain exact historical rates and snapshots.

**Step-by-step verification cases and expected outcomes:**

1. Issue a pledge with two ornaments, then receive interest only; principal and custody stay unchanged while interest/tender ledgers change by the independent calculated amount.
2. Repay part of principal across month-end and leap-day fixtures; reopen and compare accrued/paid interest, outstanding principal and pledged quantities with desktop evidence.
3. Redeem the final principal and release collateral; the same collateral cannot be released again. Inject failure after cash posting and expect all principal/custody/ledger changes to roll back.
4. Try editing/deleting an issue that has a later receipt; expect the required block or explicit ordered reversal, preserving all other borrower histories and producing an audit record.

### documents

Prior obligations: P10-05/P10-06; X25. Operator surfaces: `print/document actions in transaction and report pages`.

**Observed:** This module is shared HTML print chrome, escaping and money/weight/amount-in-words formatting. Actual datasets and documents are distributed across sales, purchase, repair, finance, dhrn, scheme and reports. A generic A4 shell is not a certified replacement for all Crystal layouts; `rupeesInWords` explicitly ignores paise and uses a general Indian number formatter.

**Current implementation anchors:**
- `web/apps/api/src/modules/documents/docChrome.ts` — `esc` line 6; `num` line 11; `money` line 12; `wt` line 14 (283 lines total).

**Existing test files to retain and extend:**
- `web/apps/api/test/documents.test.ts`
- `web/apps/api/test/render.test.ts`
- `web/apps/api/test/reportRender.db.test.ts`
- `web/apps/api/test/orderImageReport.test.ts`

**Implementation sequence:**

1. Create a document variant manifest linking each desktop print selector, paper/copy/language/edition choice, data binding and template to an actual web print action.
2. Separate exact business values from display formatting; resolve paise, negative amounts, very large figures, locale and amount-in-words rules per source document.
3. Complete headers, registration/tax labels, customer snapshot, child rows, images, totals, bank/UPI, copies, terms and signatures for each required variant.
4. Implement pagination, repeated headings, group continuation, footer placement and actual printer settings for A4, half-page, receipt, tag and passbook media.
5. Make preview/PDF/print/export use the same authorized saved-document snapshot and log print actions when the desktop contract requires them.

**Step-by-step verification cases and expected outcomes:**

1. Render a multipage invoice with multiple children per parent; parent monetary amounts occur once, children stay with the correct parent, and PDF totals equal persisted totals.
2. Render long multilingual names, portrait/landscape images and blank optional fields; no clipping, overlapping text or invented placeholders appear in final customer output.
3. Generate original/duplicate and all configured paper variants from one saved voucher; verify the intended labels/layouts and physical printer output, retaining scanned output evidence.
4. Revoke print permission or switch company while a preview request is in flight; no unauthorized document is delivered and no stale company branding replaces the selected document.

### einvoice

Prior obligations: P05-03, P11-03, P13-01; X15/X28. Operator surfaces: `txn/e-crnt-note and utilities/e-invoice`.

**Observed:** `creditNote.ts` is a scoped, paginated saved E CRNT reader with child-parent checks; the page says browse/review then generate IRN. There is no complete credit-note create/edit/delete workflow in this module. `einvoice.ts` provides payload/IRN generation and cancellation with fake and CharteredInfo transports, configuration guards and E_DATA/SL_DATA storage. Existing IRN functionality must not be equated with full credit-note parity or successful live-provider acceptance.

**Current implementation anchors:**
- `web/apps/api/src/modules/einvoice/creditNote.ts` — `listCreditNotes` line 55; `getCreditNote` line 103 (175 lines total).
- `web/apps/api/src/modules/einvoice/einvoice.ts` — `fmtIrnDate` line 74; `buildIrnPayload` line 104; `validateIrnPayload` line 169; `FakeIrnTransport` line 203 (866 lines total).
- `web/apps/api/src/modules/einvoice/einvoiceExport.ts` — `EINVOICE_HEADER_COLUMNS` line 273; `EINVOICE_ITEM_COLUMNS` line 318; `eInvoiceExportSheets` line 352; `eInvoiceExportData` line 359 (455 lines total).

**Existing test files to retain and extend:**
- `web/apps/api/test/creditNoteRead.db.test.ts`
- `web/apps/api/test/ecreditNoteIrn.db.test.ts`
- `web/apps/api/test/einvoiceProductionGuard.test.ts`
- `web/apps/api/test/einvoice_gsp.test.ts`
- `web/apps/api/test/creditNoteIrnAmounts.test.ts`
- `web/apps/api/test/einvoiceExport.db.test.ts`

**Implementation sequence:**

1. Finish the E CRNT authoring lifecycle from TR_SL_EBILL: original invoice selection, exact parent/child amounts, book/numbering/date guards, effect ownership and saved hydration.
2. Implement source-qualified create/edit/delete and immutable/controlled behavior after registration; distinguish financial credit-note state from provider submission state.
3. Build a durable provider command/outcome state machine for submit, accepted, rejected, timeout/unknown, duplicate, status recovery and cancellation with exact request identity.
4. Resolve statutory schema/version/effective-date rules from current authoritative provider/government materials at implementation time; isolate any required legal evolution from preserved historical desktop behavior.
5. Expose actionable provider errors, submission/status/cancel actions, signed QR/acknowledgement, history and export; never label a fake success as a production registration.

**Step-by-step verification cases and expected outcomes:**

1. Create a credit note from a saved invoice with child components; reopen and compare source references, negative/credit financial effects, tax and stock according to its contract.
2. Submit once through sandbox, then lose the network response and retry recovery; one provider registration is associated with the document and no duplicate financial posting occurs.
3. Run missing/partial credentials and production-with-fake scenarios; submission is blocked and neither fabricated IRN nor ACK/QR is persisted on a production invoice.
4. Cancel a registered eligible note and test provider rejection/unknown response; local state reflects authoritative outcomes and never clears registration merely because an HTTP request was sent.

### finance

Prior obligations: P06-01..P06-06; X16. Operator surfaces: `txn/receipt, payment, batch-receipt, contra, journal, fine-jv, employee-jv, gold-book, location-amount, ledger-adjust, bill-to-bill, bank-recon and cheque-print`.

**Observed:** Eighteen source files implement substantial cash/bank posting, multiline receipts/payments, tender legs, journal/fine/employee entries, gold/location ledgers, bill allocation, VP adjustment, reconciliation and printing. Several lifecycle wrappers enforce persisted identities and replacement write sets. Coverage is broad but heterogeneous; every book/tender variant, rate-cut receiving and closing still need end-to-end evidence. Generic accounting balance is insufficient to certify source leg classifications and serial keys.

**Current implementation anchors:**
- `web/apps/api/src/modules/finance/finance.ts` — `assertCashLimit` line 60; `cashLimitTx` line 72; `partyCashReceivedTx` line 78; `assertCashReceiptCeiling` line 106 (1622 lines total).
- `web/apps/api/src/modules/finance/tender.ts` — `payoutLegs` line 73; `receiptLegs` line 148; `tenderThresholdDecision` line 225 (238 lines total).
- `web/apps/api/src/modules/finance/lifecycle.ts` — `text` line 27; `num` line 28; `completeFinanceScope` line 30; `voucherKey` line 39 (230 lines total).
- `web/apps/api/src/modules/finance/journal.ts` — `postJournal` line 149; `getJournal` line 162; `editJournal` line 191; `deleteJournal` line 211 (271 lines total).
- `web/apps/api/src/modules/finance/fineJv.ts` — `postFineJv` line 157; `getFineJv` line 164; `editFineJv` line 192; `deleteFineJv` line 206 (263 lines total).
- `web/apps/api/src/modules/finance/employeeJv.ts` — `assertEmployeeJvInput` line 51; `postEmployeeJv` line 142; `getEmployeeJv` line 150; `editEmployeeJv` line 182 (222 lines total).
- `web/apps/api/src/modules/finance/billToBill.ts` — `listOpenBills` line 116; `settleBills` line 162; `deleteBillSettlement` line 366 (462 lines total).
- `web/apps/api/src/modules/finance/bankRecon.ts` — `bankReconList` line 34; `bankReconClear` line 120 (143 lines total).
- `web/apps/api/src/modules/finance/goldBook.ts` — `saveGoldBook` line 529; `getGoldBook` line 535; `deleteGoldBook` line 605 (662 lines total).
- `web/apps/api/src/modules/finance/locationAmount.ts` — `saveLocationAmount` line 689; `getLocationAmount` line 699; `deleteLocationAmount` line 769 (849 lines total).
- `web/apps/api/src/modules/finance/ledgerAdjust.ts` — `assertLedgerAdjustInput` line 44; `postLedgerAdjust` line 129; `getLedgerAdjust` line 137; `editLedgerAdjust` line 169 (214 lines total).
- `web/apps/api/src/modules/finance/vpAdjustment.ts` — `saveVpAdjustment` line 595; `getVpAdjustment` line 605; `deleteVpAdjustment` line 657 (719 lines total).

**Existing test files to retain and extend:**
- `web/apps/api/test/financeLifecycle.db.test.ts`
- `web/apps/api/test/cashReceiptLegs.db.test.ts`
- `web/apps/api/test/billToBillDelete.db.test.ts`
- `web/apps/api/test/contraDelete.db.test.ts`
- `web/apps/api/test/rateCutSettlement.db.test.ts`
- `web/apps/api/test/goldBookLoctAmt.db.test.ts`
- `web/apps/api/test/financeWriters.test.ts`

**Implementation sequence:**

1. Enumerate every configured MAIN_BOOK/direction and preserve each cash/bank/journal/fine/location/employee/gold variant's row count, signs, account role and LEDR_KEY/LD_CODE semantics.
2. Finish tender metadata and split identity for cash, cheque, bank, card and UPI, including instrument dates/clearing, commission, bank accounts and partial settlement.
3. Port exact cash-limit and defaulter predicates with their true query domain; do not narrow cross-year source rules to the active year merely for convenience.
4. Complete persisted read/edit/delete and source references for every finance family; replace only owned rows and protect bills, cleared instruments, adjustments and dependent vouchers.
5. Finish bill-to-bill allocation, reopening, due dates and rate-cut receiving with locks and exact outstanding conservation; reconcile monetary and fine balances separately.
6. Connect all forms to lookup/tender/balance helpers, document print and reconciliation reports, then execute accountant closing with independent acceptance.

**Step-by-step verification cases and expected outcomes:**

1. Post one multiline receipt with cash, bank and two UPI splits against two invoices; reopen and compare CASH/PAY/UPI/CARD/AC/BILL_OS rows, instrument references and bill outstanding.
2. Amend tender allocation without changing total; expected settlement accounts and instruments change while party total stays fixed, and obsolete owned tender rows disappear exactly once.
3. Clear a bank instrument then attempt a prohibited edit/delete; expect explicit rejection and unchanged clearance state. Reverse through the approved lifecycle and reconcile bank ledger.
4. Race two bill settlements and force failure after updating outstanding but before posting ledger; over-settlement is prevented and transaction rollback restores the original bills and sequence state.
5. Submit a receipt exactly at, below and above the source cash ceiling with historical entries in other years/books; pass/fail must match the independently captured source predicate and rejected requests write nothing.

### forms

Prior obligations: P02-01..P02-04, P11-05; X07. Operator surfaces: `forms/form-layouts plus shared ExtendedGrid, SubDetailGrid, LookupPicker, KeyboardNav and VoucherChrome`.

**Observed:** `formLayoutEngine.ts` loads extracted layout catalogs and renders HTML previews; button and checkbox renderers are deliberately disabled. This module is evidence/preview infrastructure, not a working form implementation. Interactive business pages and generic master forms live in Next components/app. Pixel placement/control counts do not establish keyboard, event or workflow equivalence.

**Current implementation anchors:**
- `web/apps/api/src/modules/forms/formLayoutEngine.ts` — `loadFormLayout` line 24; `listFormLayouts` line 35; `renderFormLayout` line 68 (135 lines total).

**Existing test files to retain and extend:**
- `web/apps/api/test/formLayoutEngine.test.ts`
- `web/apps/api/test/masterFormFields.test.ts`
- `web/apps/api/test/pageEndpointFamily.test.ts`

**Implementation sequence:**

1. For each desktop form define regions, tabs, controls, child grids, lookup origins, calculated/read-only cells, action states and exact event order in a leaf contract.
2. Map each interactive requirement to a real Next page/component rather than treating generated disabled layout previews as implementation.
3. Extend shared grids for per-cell type, precision, lookup fill, ordered recalc, keyboard enter/escape/delete, focus restoration and conditional visibility without flattening domain variants.
4. Implement dirty navigation, save/conflict validation, accessible labels, screen-reader feedback, responsive dense layouts and persisted user column preferences.
5. Run actual operator tasks and compare keystrokes, focus order, throughput and visible data against desktop evidence at representative display sizes.

**Step-by-step verification cases and expected outcomes:**

1. Enter a 20-line invoice using only keyboard and lookups; each cell-exit calculation, added/removed row and focus move must match the contract, with one correct final save.
2. Edit a parent with three child stones, cancel the child dialog then reopen; canceled changes do not affect parent totals or persisted children; confirmed changes do.
3. Toggle a setting that hides a grid column; reopen an imported document and save another field; hidden values must remain preserved, not rewritten to zero or blank.
4. Cause server validation and stale-version errors; the relevant field is identified, draft and focus survive, and no misleading success/navigation occurs.

### gst

Prior obligations: P10-03, P11-03; X26/X28. Operator surfaces: `reports/[report] GST families; GSTR document/export endpoints`.

**Observed:** `gst.ts` builds read-only GSTR-1 B2B/B2CL/B2CS/HSN datasets and `gstr1Doc.ts` renders a document. The source hardcodes B2CL_THRESHOLD=250000 and allows HSN fallback to item code; this audit makes no claim that that threshold is legally current. Statutory rules need effective-date review and real HSN mappings. Broader tax reports live in reports and posting tax behavior in shared/taxPolicy.ts.

**Current implementation anchors:**
- `web/apps/api/src/modules/gst/gst.ts` — `B2CL_THRESHOLD` line 12; `classifyInvoice` line 43; `summarizeB2CS` line 62; `summarizeHsn` line 87 (215 lines total).
- `web/apps/api/src/modules/gst/gstr1Doc.ts` — `gstr1DocHtml` line 22; `renderGstr1Doc` line 115 (125 lines total).

**Existing test files to retain and extend:**
- `web/apps/api/test/gst.test.ts`
- `web/apps/api/test/taxMasterGst.db.test.ts`
- `web/apps/api/test/taxPolicy.test.ts`
- `web/apps/api/test/reportFiltersApplied.db.test.ts`

**Implementation sequence:**

1. Build an effective-dated statutory rule register for supported jurisdictions with authoritative references and accountant approval, separating historical desktop reproduction from current filing requirements.
2. Replace placeholder HSN/item-code equivalence with validated item/group HSN/UQC mapping and explicit exceptions; verify customer GSTIN/state/registration snapshots.
3. Complete required return sections, credit/debit notes, amendments, exempt/nil/export cases and all existing desktop GST launcher variants supported by scope.
4. Reconcile tax datasets to TAX_DATA, invoice headers/details, returns and financial ledger without deriving statutory truth solely from current mutable masters.
5. Expose period filters, validation errors, drill-down and filing exports with exact schema/version and print/export permissions; refuse unsupported required sections clearly.

**Step-by-step verification cases and expected outcomes:**

1. Post registered/unregistered intra/interstate invoices around the applicable threshold and period boundary; compare classified rows to independently specified effective-date rules.
2. Post a sale and later credit note with different period dates; each return period includes the correct original/correction section, and ledger/tax totals reconcile.
3. Use two items sharing HSN and one missing HSN; the first aggregate correctly, while missing mandatory mapping is surfaced rather than silently filed as an item code.
4. Export the same period to JSON/CSV/document; common totals and filters match, a different company sentinel is absent and exporting makes no financial mutation.

### images

Prior obligations: P03-03, P05-04/P05-07, P10-05; X05/X11/X25. Operator surfaces: `EntityImagePanel, OrderImagePanel, SavedSalesOrderImages, RepairImagePanel and CameraCapture`.

**Observed:** Dedicated entity/order image modules support validation, scoped identity, version hashes and revision locking. Order images distinguish original snapshots from inherited design/tag images. Related repair image logic lives under repair and tag image transfer under stock. This is meaningful concurrency work; all historic print rights, inherited provenance, cross-scope leakage and migration formats remain per-family acceptance obligations.

**Current implementation anchors:**
- `web/apps/api/src/modules/images/entityImage.ts` — `ENTITY_TYPES` line 48; `DEFAULT_IMAGE_TYPE` line 59; `DESIGN_IMAGE_TYPE` line 60; `ENTITY_IMAGE_MAX_BYTES` line 63 (430 lines total).
- `web/apps/api/src/modules/images/orderImage.ts` — `customOrderImageKey` line 52; `validateOrderImageBytes` line 108; `resolveOrderImageTx` line 175; `getOrderImage` line 286 (416 lines total).
- `web/apps/api/src/modules/images/imageRevision.ts` — `lockImageRevisionTx` line 22; `readImageRevisionTx` line 34; `advanceImageRevisionTx` line 43 (49 lines total).
- `web/apps/api/src/modules/images/imageState.ts` — `requireImageVersion` line 17; `imageStateVersion` line 25; `compareImageVersion` line 29; `validateImagePixels` line 37 (86 lines total).

**Existing test files to retain and extend:**
- `web/apps/api/test/entityImage.db.test.ts`
- `web/apps/api/test/entityImageConcurrency.routes.db.test.ts`
- `web/apps/api/test/orderImageWrite.db.test.ts`
- `web/apps/api/test/orderImageReport.db.test.ts`
- `web/apps/api/test/repairImageConcurrency.routes.db.test.ts`

**Implementation sequence:**

1. Reconcile each desktop image identity and path convention with EntityImage/EntityImageRevision and original image tables, including data type, branch, year, voucher and line serial ownership.
2. Finish capture/upload/replace/delete and inherited-versus-custom rules for party, item, design, tag, member, order and repair with exact content validation and allowed sizes.
3. Require document/context/image revisions together where an image belongs to a mutable line; prevent stale uploads from attaching to a replaced or renumbered identity.
4. Complete image reference preservation in imports, tag splits/transfers, order fulfillment and saved documents; define source fallback and historical print access explicitly.
5. Verify binary integrity, thumbnail/render behavior, deletion/history/audit and backup/restore consistency without letting image reads bypass business rights.

**Step-by-step verification cases and expected outcomes:**

1. Open the same design image in two sessions; replace in A then save/delete from B; B conflicts and A's bytes and revision remain unchanged.
2. Capture an image then switch branch or remove its document line before upload completes; stale upload is rejected and cannot attach to a new line with reused display number.
3. Print an imported order that inherited a tag/design image, then change the current master image; the output uses the source-defined historical/custom behavior and records provenance.
4. Back up and restore an isolated test company including image bytes and revisions; compare content hashes and associations; a restore failure leaves the original company and unrelated images intact.

### inout

Prior obligations: P06-02, P07-02; X16/X18. Operator surfaces: `txn/fine-inout`.

**Observed:** `fineInout.ts` implements real fine-metal in/out posting and delete with line calculation and many desktop grid fields. It is a distinct finance/metal workflow, not an alias of cash movement. Full source identity, all sign/rate/ghat/stone branches and rich unchanged round-trip acceptance must still be established.

**Current implementation anchors:**
- `web/apps/api/src/modules/inout/fineInout.ts` — `lineFine` line 143; `fineInout` line 152; `deleteFineInout` line 313 (333 lines total).

**Existing test files to retain and extend:**
- `web/apps/api/test/fineInoutGrid.db.test.ts`
- `web/apps/api/test/finePolicy.test.ts`
- `web/apps/api/test/signAlphabet.test.ts`
- `web/apps/api/test/operatorDepth.roundtrip.db.test.ts`

**Implementation sequence:**

1. Extract fine in/out direction, material versus money semantics, fine/wastage/ghat equations, rate basis and required accounts from its desktop form and posting functions.
2. Complete every parent/component field, row serial, user/date and configured book value in API hydration and grid editing.
3. Implement or qualify full open/edit/delete lifecycle with linked document guards and explicit ownership of stock/fine/account/Rojmel effects.
4. Apply exact numeric and period/scope policies, with source locks and conflict handling where balances or prior issue quantities constrain entry.
5. Reconcile metal balances, source outstanding, statements and printed vouchers against these movements and independently captured data.

**Step-by-step verification cases and expected outcomes:**

1. Post an issue and receipt with nonzero ghat/wastage and mixed purity; fine and signs in stock/fine/ledger records match the contract and do not create unintended cash legs.
2. Reopen a rich imported voucher, change description only and save; hidden fields, components and physical identity remain exact outside the owned metadata change.
3. Delete or amend a source already consumed by a later movement; the defined dependency guard prevents inconsistent outstanding and writes no partial correction.
4. Inject a failure after the first movement insert; all header/detail/fine/ledger effects and allocated number state roll back, then one clean retry succeeds.

### integrations

Prior obligations: P11-02/P11-03; X28. Operator surfaces: `integrations, utilities/reminders; ScaleCapture, CameraCapture, RateTicker and DeviceCapabilityProbe`.

**Observed:** Six files implement barcode/QR, weighing-frame normalization/protocol, rates, messaging with attempt log and readiness diagnostics. Real transport interfaces and browser capability probes exist, with fake modes in related provider code. Readiness currently treats some configured credentials as ready; that is not independently verified delivery/provider/hardware acceptance. Real printers, scales, cameras, disconnects and provider status must be tested on supported target equipment.

**Current implementation anchors:**
- `web/apps/api/src/modules/integrations/barcode.ts` — `code39CheckChar` line 66; `code39Svg` line 84; `qrSvg` line 116 (129 lines total).
- `web/apps/api/src/modules/integrations/deviceBridge.ts` — `normalizeScaleReading` line 44 (96 lines total).
- `web/apps/api/src/modules/integrations/scaleProtocol.ts` — `SCALE_PORT_DISABLED` line 40; `SCALE_PORT_FRIENDLY_NAME` line 43; `SCALE_EXCLUDED_CHARACTERS` line 46; `SCALE_FRAME_SCAN_LIMIT` line 49 (145 lines total).
- `web/apps/api/src/modules/integrations/readiness.ts` — `REQUIRED_ENV` line 72; `OPTIONAL_ENV` line 79; `integrationReadiness` line 84; `readinessSummary` line 202 (296 lines total).
- `web/apps/api/src/modules/integrations/messaging.ts` — `renderTemplate` line 37; `FakeMessageSender` line 45; `HttpSmsSender` line 65; `WhatsAppCloudSender` line 83 (402 lines total).
- `web/apps/api/src/modules/integrations/rates.ts` — `OZ_TO_GRAM` line 10; `metalInrPerGram` line 28; `fetchLiveRates` line 37 (78 lines total).

**Existing test files to retain and extend:**
- `web/apps/api/test/barcode.test.ts`
- `web/apps/api/test/scaleProtocol.test.ts`
- `web/apps/api/test/integrationReadiness.test.ts`
- `web/apps/api/test/integrationReadiness.db.test.ts`
- `web/apps/api/test/integrationWireContract.test.ts`
- `web/apps/api/test/messaging.db.test.ts`
- `web/apps/api/test/whatsapp.test.ts`

**Implementation sequence:**

1. Inventory every actual deployed scale/scanner/printer/camera/provider and supported browser/OS, preserving desktop protocol/settings references and explicit web substitutions.
2. Complete device selection, permission denial, reconnect/disconnect, focus-target gating, stable/unstable weights, stale page leases and loopback-agent deployment where WebSerial is unavailable.
3. Define provider command identities, delivery/status/cancel/retry rules and persistent attempt/outcome records for SMS, WhatsApp, mail, rates and GSP integrations.
4. Separate configured, authenticated, sandbox-tested and production-verified readiness, presenting useful operator actions without treating environment variable presence as successful operation.
5. Perform real end-to-end output and readback with authorized test recipients/devices; document calibration, service availability, credentials rotation and incident recovery.

**Step-by-step verification cases and expected outcomes:**

1. Attach the target scale, focus the permitted weight cell, capture fragmented/noisy frames and disconnect mid-frame; only a complete valid reading updates the intended draft and no auto-post occurs.
2. Scan a real tag through keyboard emulation in rapid succession; exact tag identity and enter behavior hold without duplicate row creation or focus drift.
3. Send one authorized test message, simulate timeout then query/retry according to provider policy; attempt logs distinguish accepted, delivered, rejected and unknown, with no false success.
4. Use missing, invalid, sandbox and production credentials; readiness states and actual transport behavior agree, secrets never appear in UI/logs and fake responses cannot become production records.

### manufacturing

Prior obligations: P08-01..P08-06; X23. Operator surfaces: `txn/mfg-issue, mfg-receive, mfg-lot-issue, mfg-lot-receive, mfg-order-issue, karigar-issue/receive, jobwork-issue/receive, melting and old-item-sales`.

**Observed:** `mfg.ts`, `karigar.ts`, `melting.ts`/`meltingPro.ts` have real writers, reads, updates and reversals. Lot manufacturing is specifically browse/source-selection only: `mfgLot.ts` returns writes:false and unverified effectiveMode; `MfgLotForm` has saved/source views rather than an issue/receive writer. Existing stage/lot schema migrations and source selectors are reusable prerequisites, not completed lot production.

**Current implementation anchors:**
- `web/apps/api/src/modules/manufacturing/mfg.ts` — `IR_TYPE` line 65; `INOUT_ISSUE` line 84; `INOUT_RECEIPT` line 85; `SIGN_ISSUE` line 88 (1468 lines total).
- `web/apps/api/src/modules/manufacturing/mfgLot.ts` — `getMfgLotSettings` line 221; `listMfgLots` line 227; `getMfgLot` line 262; `listMfgLotSources` line 343 (502 lines total).
- `web/apps/api/src/modules/manufacturing/karigar.ts` — `INOUT_ISSUE` line 63; `INOUT_RECEIPT` line 64; `fineWeight` line 67; `fineWithWastage` line 72 (1946 lines total).
- `web/apps/api/src/modules/manufacturing/melting.ts` — `meltLine` line 32; `meltProcess` line 77 (133 lines total).
- `web/apps/api/src/modules/manufacturing/meltingPro.ts` — `saveMeltingPro` line 700; `getMeltingPro` line 717; `deleteMeltingPro` line 805 (826 lines total).
- `web/apps/api/src/modules/manufacturing/meltingParity.ts` — `meltingRound3` line 16; `meltingRound2` line 18; `calculateMeltingOutRow` line 36; `calculateMeltingOutTotals` line 66 (267 lines total).

**Existing test files to retain and extend:**
- `web/apps/api/test/mfgLifecycle.db.test.ts`
- `web/apps/api/test/mfgLotRead.db.test.ts`
- `web/apps/api/test/mfgLotRoutes.db.test.ts`
- `web/apps/api/test/karigar.test.ts`
- `web/apps/api/test/meltingPro.db.test.ts`
- `web/apps/api/test/meltingParity.test.ts`
- `web/apps/api/test/manufacturingReports.db.test.ts`

**Implementation sequence:**

1. Resolve the complete MFG_MAST stage graph and desktop ENTRY_TYPE/NEXT_TRAN/LAST_TRAN/STK_ISU/STK_REC/IN_OUT plus order/lot/one-form/ledger-mode branches; do not activate writes under an unverified mode.
2. For each manufacturing variant specify source selector, issue quantities, receipt/yield, ghat/wastage/loss, stones/components, karigar charges and downstream references.
3. Implement lot issue with exact source lot/material identity and stage-specific MFG_DATA/DETL/IDTL/ISU_REC/stock effects under deterministic locks and full scope.
4. Implement partial lot receipt, consumption/remainders, linked stock generation, serial/tag creation and source outstanding; handle multiple issues/lots/karigars according to source behavior.
5. Finish edit/delete/reversal across stage chains, preventing earlier changes from invalidating later accepted stages; preserve source/movement identity and financial history.
6. Complete melting input/output/test purity, fine loss/gain, settlement and resulting stock; expose every branch in dense operator grids with images, documents and stage/karigar reports.
7. Run independent full manufacturing-day comparisons, then release lot writers only after mode/ownership/rollback/conservation/browser acceptance succeeds.

**Step-by-step verification cases and expected outcomes:**

1. Create a lot issue from two source lots, partially receive against one and reopen; source balance, stage movement and remaining material must reconcile exactly by full lot identity.
2. Attempt an overreceipt and race two receipts for the same remainder; only admissible quantities commit, with no negative stock or duplicated MFG_ISU_REC links.
3. Process issue→setting→receipt→tag/sale, then attempt editing the original issue; reject or require the explicitly defined reverse-stage order, preserving downstream history.
4. Run melting with differing input/output touch, wastage and dust/scrap; weights, fine loss and settlement match independent source values; inject failure before final stock to prove full rollback.
5. Open the current lot pages before release; source/saved browsing works while create/edit/reverse remains unavailable. After implementation, repeat the same browser journey and verify real DB effects, not only preview data.

### masters

Prior obligations: P03-01..P03-05; X10/X11. Operator surfaces: `masters/[name], party, design-book, auto-item, styles, diamond-sizes, item-stock-limits, opening-balance, labour-update, year-create and admin/provision`.

**Observed:** Seventeen files implement generic scoped CRUD/import with required/conditional/delete guards, generated plus curated form fields, party data, rates, stock limits, labour slabs, years/openings, company cloning and rich design parent/components. The generated field merger explicitly addresses omitted operator columns. Presence of all declared fields does not prove conditional event order, every child table, help behavior or downstream effect. Design has newer calculation, identity/version and component tests.

**Current implementation anchors:**
- `web/apps/api/src/modules/masters/master.service.ts` — `groupForColumn` line 83; `withGroups` line 98; `desktopMessageFor` line 114; `assertColumnRules` line 162 (629 lines total).
- `web/apps/api/src/modules/masters/configs.ts` — `RATE_MAST_CONFIG` line 4; `TAX_MAST_CONFIG` line 10; `GROUP_MAST_CONFIG` line 17; `EMP_MAST_CONFIG` line 67 (476 lines total).
- `web/apps/api/src/modules/masters/designBook.ts` — `getDesignCalculationConfig` line 210; `getDesignComponentDefaults` line 239; `saveDesignBook` line 468; `listDesignBook` line 587 (622 lines total).
- `web/apps/api/src/modules/masters/companyClone.ts` — `COMPANY_CLONE_TABLES` line 23; `CLONE_TEMPLATE_CO_CODE` line 458; `cloneCompanyTx` line 475; `cloneCompany` line 522 (529 lines total).
- `web/apps/api/src/modules/masters/companySettings.ts` — `CO_SET_NEW_COLUMNS` line 20; `CO_SET_NEW_TEMPLATE_CO_CODE` line 91; `provisionCompanySettingsTx` line 104; `provisionCompanySettings` line 141 (150 lines total).
- `web/apps/api/src/modules/masters/columnSettings.ts` — `COLUMN_SETTING_KEYS` line 7; `COLUMN_SETTING_VALUES` line 8; `columnSettingInput` line 40; `columnSettingListOptions` line 115 (300 lines total).
- `web/apps/api/src/modules/masters/openingBalance.ts` — `openingFor` line 37; `getOpeningBalance` line 61; `setOpeningBalance` line 90 (134 lines total).
- `web/apps/api/src/modules/masters/stockLimit.ts` — `listDiamondSizeSummary` line 84; `getDiamondSizes` line 109; `saveDiamondSizes` line 145; `deleteDiamondSizes` line 184 (368 lines total).
- `web/apps/api/src/modules/masters/labourUpdate.ts` — `listLabourItems` line 27; `applyLabourUpdate` line 52; `getLabourSlabs` line 102; `setLabourSlabs` line 128 (164 lines total).
- `web/apps/api/src/modules/masters/autoItem.ts` — `bulkAutoItem` line 30 (74 lines total).
- `web/apps/api/src/modules/masters/year.ts` — `listYears` line 20; `createYear` line 39; `closeYear` line 77; `reopenYear` line 94 (179 lines total).

**Existing test files to retain and extend:**
- `web/apps/api/test/masters.test.ts`
- `web/apps/api/test/masterFormFields.test.ts`
- `web/apps/api/test/conditionalRules.test.ts`
- `web/apps/api/test/designComponents.db.test.ts`
- `web/apps/api/test/designBook.routes.db.test.ts`
- `web/apps/api/test/stockLimitMaster.db.test.ts`
- `web/apps/api/test/provisioning.db.test.ts`
- `web/apps/api/test/seedCompleteness.db.test.ts`

**Implementation sequence:**

1. Reconcile each of the desktop master forms independently, including account/party/firm, organization, item/group/product, tax/rate/touch/labour, design, employee/counter/book, scheme and printing/config masters.
2. Complete per-field type/width/null/default/conditional-required rules, duplicate checks, same-name variants, lookup fills, dependent delete guards and import error reporting from exact source branches.
3. Finish design parent/child stones/materials/styles/repeats, settings-driven calculations, image provenance and create/search/select/update flows shared by orders/tags/manufacturing.
4. Complete fresh-company/branch/year/book provisioning and cloning with full ownership manifest; inspect `year.ts:114` carry-forward deletion/aggregation that omits branch while output stamps a branch; distinguish company-wide versus branch/year-owned records and derive number/account defaults correctly.
5. Implement bulk import, automatic item creation, labour/rate/stock-limit updates as previewed atomic operations preserving linked history and explicit per-row outcomes.
6. Verify downstream behavior after master changes and preserve saved document snapshots: current labels/rates must not silently overwrite historical values on unrelated edits.

**Step-by-step verification cases and expected outcomes:**

1. Create a fresh company/branch/year through UI; verify required books, configured posting accounts, settings, user rights and first transaction succeed without manual database repair.
2. Create an item with labour slabs, sizes and limits and a design with multiple components; reopen unchanged and compare exact child IDs/ordering/amounts/image association.
3. Change a master used by a saved historical voucher; reopen that voucher and edit only description; retained rates/names/hidden values follow the approved snapshot rule and do not recalculate accidentally.
4. Import a batch containing one duplicate and one invalid conditional field; preview reports exact errors, apply obeys defined atomic/per-row policy and no silent partial defaulting occurs.
5. Attempt deletion of a referenced party/item/design/manufacturing stage; server blocks with the correct dependency, and a second-company record with the same code remains independent.
6. Carry forward openings for a company with two branches and matching account codes; compare source-defined ownership and each branch separately, ensuring one branch action cannot silently erase or consolidate the other branch’s opening data.

### membership

Prior obligations: P09-03/P09-04/P09-05; X24. Operator surfaces: `txn/membership, scheme and scheme-gold-adjust`.

**Observed:** Loyalty enrollment and POINT_DATA earn/redeem are real; MEMB_POINT is correctly treated as a flag, not a balance. `scheme.ts` implements enrollment, installment/opening, UPI splits, maturity and gold adjustment with several read/edit/delete paths. A static concurrency concern remains in `postPoints`: member lookup and balance check precede numbering and have no explicit member lock/default Serializable isolation, so concurrent redemption requires a real race test before release.

**Current implementation anchors:**
- `web/apps/api/src/modules/membership/membership.ts` — `enrollMember` line 40; `postPoints` line 77; `listMembers` line 165 (182 lines total).
- `web/apps/api/src/modules/membership/scheme.ts` — `MEMB_ENTRY` line 52; `MEMB_OPENING` line 53; `MEMB_ADJUST` line 54; `MEMB_GOLD_ADJUST` line 55 (2200 lines total).

**Existing test files to retain and extend:**
- `web/apps/api/test/scheme.test.ts`
- `web/apps/api/test/schemeLedgerLegs.db.test.ts`
- `web/apps/api/test/schemeGoldAdjust.db.test.ts`
- `web/apps/api/test/schemeMonthlyReport.db.test.ts`
- `web/apps/api/test/workflows.test.ts`

**Implementation sequence:**

1. Separate loyalty-point membership from monetary/gold schemes, preserving scheme/member key, enrollment, nominee/reference, opening, maturity and completion/cancellation states.
2. Port exact installment schedule, missed/advance month, bonus/less/commission, monetary/gold-rate conversion and scheme-specific settings with independent date fixtures.
3. Complete full enrollment and points correction/reversal lifecycle, linking earned/redeemed points to originating sales/refunds and applying locked balance admission for concurrent redemption.
4. Finish scheme receipt/opening/maturity/gold-adjustment variants, split tender identity and sale adjustment with full outstanding/financial/source references.
5. Connect passbook/monthly/bonus/commission/agent/member reports, QR/photos and user-visible validation; avoid treating loyalty balances as monetary AC_DATA entries unless source requires money conversion.

**Step-by-step verification cases and expected outcomes:**

1. Enroll a scheme member, pay regular and advance installments through split tender, reopen and compare AD_MEMB/AD_DATA/UPI/ledger records and passbook month ordering.
2. Mature a scheme with bonus/less then adjust into a sale; remaining scheme liability and sale outstanding reconcile, and a second maturity/adjustment cannot spend the same balance.
3. With 100 points, concurrently redeem 80 in two sessions; expected one success or equivalent serialized admission, balance never negative and rejected redemption leaves no POINT_DATA row.
4. Refund a points-earning sale after partial point redemption; enforce the source-backed reversal/negative-point rule and preserve linked original/reversal records and member statement.

### ops

Prior obligations: P00-04/P00-05, P12-01..P12-05, P14-01..P14-06; X03/X30/X31/X34. Operator surfaces: `dashboard, audit, backup, utilities/year-end, company/balance-transfer and admin/provision`.

**Observed:** Seventeen files provide readiness, metrics, request/audit logging, invariants, company seed, backup v2 schema/integrity, restore verification, year-end and release checks. Logical restore and production cutover loading remain explicitly contained. Existing certification/checkpoint machinery is significant but does not establish a current passing candidate, full environment readiness or production migration/recovery success.

**Current implementation anchors:**
- `web/apps/api/src/modules/ops/backup.ts` — `backupCompany` line 97; `recordCompanyBackup` line 168; `restoreCompany` line 300 (506 lines total).
- `web/apps/api/src/modules/ops/backupManifest.ts` — `COMPANY_BACKUP_KIND` line 3; `COMPANY_BACKUP_VERSION` line 4; `BACKUP_SCHEMA_KIND` line 5; `stableStringify` line 213 (921 lines total).
- `web/apps/api/src/modules/ops/restoreVerification.ts` — `verifyCompanyRestore` line 34 (76 lines total).
- `web/apps/api/src/modules/ops/yearEnd.ts` — `yearEndPreview` line 214; `yearEndClose` line 241 (280 lines total).
- `web/apps/api/src/modules/ops/seedCompany.ts` — `seedCompany` line 97 (276 lines total).
- `web/apps/api/src/modules/ops/invariants.ts` — `operationalInvariants` line 29 (121 lines total).
- `web/apps/api/src/modules/ops/releaseCertification.ts` — `contextProblems` line 191; `evaluateGate` line 369; `requirementSetProblems` line 524; `requirementSetFingerprint` line 562 (1647 lines total).
- `web/apps/api/src/modules/ops/migrationManifest.ts` — `EXPECTED_MIGRATIONS` line 1 (137 lines total).
- `web/apps/api/src/modules/ops/health.ts` — `healthPayload` line 14; `readiness` line 56 (119 lines total).
- `web/apps/api/src/modules/ops/runtimeConfig.ts` — `resolveRuntimeConfig` line 35 (83 lines total).

**Existing test files to retain and extend:**
- `web/apps/api/test/backupRestore.db.test.ts`
- `web/apps/api/test/migrationManifest.test.ts`
- `web/apps/api/test/cutover.test.ts`
- `web/apps/api/test/releaseCertification.test.ts`
- `web/apps/api/test/releaseCandidateIdentity.test.mjs`
- `web/apps/api/test/provisioning.db.test.ts`
- `web/apps/api/test/yearEndCarry.db.test.ts`
- `web/apps/api/test/opsInvariants.db.test.ts`

**Implementation sequence:**

1. Freeze a reproducible candidate with source/artifact/dependency/schema/config hashes and a protected non-owner database runtime; bind all evidence to that candidate.
2. Complete table ownership/type/conversion manifest for migration and backup, including images, hidden serials, temp/config/history tables and companion application data.
3. Implement scoped restartable shadow loading and reconciliation before lifting production-cutover containment; missing/skipped/ambiguous source data must fail completeness.
4. Rehearse physical recovery and v2 logical restore in an isolated production-like target with exact row/value/sequence/image verification and unrelated-scope sentinels.
5. Complete year-end close/carry/reopen and deployment rollback, monitoring, diagnostics, uptime/outage and operational access procedures with measurable shop requirements.
6. Make release certification require the exact current leaf/variant/scenario/report/device/migration/acceptance sets, preventing stale evidence, filtered test subsets and unknown dependencies from passing.

**Step-by-step verification cases and expected outcomes:**

1. Run two shadow migrations from the same source into clean isolated targets; table identities, row sets, null/text/decimal/image hashes and business reconciliations match and rerun produces no duplicates.
2. Back up company A with company B sentinels, then restore A through the isolated release drill; verify B unchanged, sequences advanced correctly and restored business continuations work.
3. Interrupt restore/load mid-operation and inject corrupt/missing backup cells; original target stays intact or controlled rollback restores it, and status reports failure instead of skipped success.
4. Modify one production input after generating a green certification record; release gate rejects the stale candidate. Omit one required scenario/report artifact and verify certification fails.
5. Perform a timed disaster recovery and fresh deploy; record actual RPO/RTO and shop workflow continuity, then verify login, first transaction, print/provider readiness and accountant reconciliations.

### parity

Prior obligations: P00-01..P00-05, P14-01/P14-02; X01/X02/X04/X34. Operator surfaces: `diagnostic comparison tools, not a substitute for operator workflows`.

**Observed:** Three modules provide golden vectors, bundle capture and bundle diffs. They support comparison infrastructure but a diff pass needs an independent source oracle, complete exact case identities and preserved row pairing. Historical status reports show no whole-menu acceptance closed and stale partial evidence cannot certify current behavior.

**Current implementation anchors:**
- `web/apps/api/src/modules/parity/bundle.ts` — `BUNDLE_KIND` line 65; `NULL_SENTINEL` line 68; `EXCLUDED_FIELDS` line 85; `RECLAIMED_FIELDS` line 110 (249 lines total).
- `web/apps/api/src/modules/parity/bundleDiff.ts` — `ROW_KEYS` line 38; `diffBundles` line 418; `formatDiff` line 472 (529 lines total).
- `web/apps/api/src/modules/parity/golden.ts` — `goldenVectors` line 22; `runParity` line 79 (83 lines total).

**Existing test files to retain and extend:**
- `web/apps/api/test/parity.test.ts`
- `web/apps/api/test/parityBundleDiff.test.ts`
- `web/apps/api/test/bundleDiffPairing.test.ts`
- `web/apps/api/test/goldenVectors.test.ts`
- `web/apps/api/test/parityRatchet.test.ts`
- `web/apps/api/test/provenance.test.ts`

**Implementation sequence:**

1. Define the semantic requirement universe from form controls/events, menu variants, settings, posting branches, reports and editions; retain source-line and artifact provenance for every leaf.
2. Capture independent original-desktop input/action/output and complete before/after database snapshots using a controlled representative dataset.
3. Extend bundles to include exact identity, type/null/text/scale/Float, images, stock/ledger/tax/outstanding and hidden/audit dependencies needed by each workflow.
4. Compare by source physical/logical keys with explicit multiplicity/order semantics, never masking missing/extra rows through sums or many-to-one matching.
5. Bind case sets, fixtures, scanners, test selections and final evidence to exact candidate hashes; publish unknown/unverified/contained states distinctly from working or absent.

**Step-by-step verification cases and expected outcomes:**

1. Introduce a deliberate missing row, duplicate row and changed hidden serial into a copied comparison bundle; each must fail with precise identity/column diagnostics.
2. Use the same numeric value encoded as null/blank/zero and as different stored scale where relevant; comparator follows the requirement's exact storage policy rather than blanket normalization.
3. Remove a required test case while preserving aggregate totals; completeness gate fails even when all remaining cases pass.
4. Replay a complete desktop journey into the web then compare raw tables, reopened UI and printed report; retain failures and do not downgrade the expected footprint to match current output.

### posting

Prior obligations: P01-01..P01-05; X05/X06. Operator surfaces: `all mutation routes; no standalone operator form`.

**Observed:** The posting kernel provides balance assertion, measured per-column defaults, ledger enrichment/keys, period guards, post/reverse and audit-related helpers. `insertRowTx` defaults a supplied null on measured non-null columns, and `ledgerBalance` sums via Number then rounds. Those behaviors need profile-specific proof for imported updates; they cannot be used to reconstruct exact historical unknown/null rows indiscriminately. Other families may still bypass pieces of this kernel.

**Current implementation anchors:**
- `web/apps/api/src/modules/posting/posting.ts` — `ledgerBalance` line 44; `assertBalanced` line 50; `insertRowTx` line 91; `enrichLedgerLine` line 153 (738 lines total).
- `web/apps/api/src/modules/posting/desktopColumnDefaults.ts` — `DESKTOP_COLUMN_DEFAULTS` line 16 (2009 lines total).

**Existing test files to retain and extend:**
- `web/apps/api/test/posting.test.ts`
- `web/apps/api/test/postingAccountFailClosed.db.test.ts`
- `web/apps/api/test/ledgerKeyFormat.db.test.ts`
- `web/apps/api/test/ledgerTimestamp.db.test.ts`
- `web/apps/api/test/transaction.integrity.db.test.ts`
- `web/apps/api/test/kernelConformance.test.ts`

**Implementation sequence:**

1. Document the exact owned write set and identity for every voucher family across header/detail/child/AC/ROJMEL/MAIN_STOCK/TAX/BILL_OS/tender/hidden/audit tables.
2. Separate source-backed create defaults from raw-preserving imported updates, including true null, empty strings, numeric scale and physical Float qualification.
3. Complete exact money/fine conservation checks at source-required precision, line/leg ordering, LEDR_KEY/LD_CODE and source time semantics; a two-decimal aggregate is only one invariant.
4. Require fiscal/last-day/period checks and fresh authority/scope inside the posting transaction, plus deterministic document/source/effect locks and affected-count validation.
5. Standardize reversal/correction with dependent-document checks, ownership-limited deletion, truthful audit and lost-acknowledgement/idempotency policy.
6. Audit every writer for kernel bypass and prove rollback at each write-family boundary without automatic retry of ambiguous financial commits.

**Step-by-step verification cases and expected outcomes:**

1. For each family submit an independently frozen fixture and compare every owned table row/column/key to the desktop; equal debit/credit totals alone cannot pass.
2. Edit an imported document containing null, blank, zero and high-precision values without changing numerics; unowned raw values and physical rows remain exact.
3. Fault after each header/detail/ledger/stock/tax/tender stage; all writes and counter allocations roll back and unrelated scope sentinels are unchanged.
4. Race two consumers of one tag/source balance and simulate a commit response loss; conservation holds and recovery cannot double-post a financial document.

### purchase

Prior obligations: P04-01..P04-05; X12. Operator surfaces: `txn/purchase, purchase-hm, purchase-return, purchase-quotation, consi-purchase, other-purchase, other-income and other-commission`.

**Observed:** Purchase has real calculation/posting/lifecycle functions, quotations, consignment source selection, purchase returns and other-income/commission variants. Large writers persist rich detail, tax, stock and settlement effects. Actual purchasing breadth is more than a CRUD scaffold, but all source branches, full unchanged hydration and supplier settlement/report acceptance remain open.

**Current implementation anchors:**
- `web/apps/api/src/modules/purchase/purchase.ts` — `lineFine` line 239; `computeLine` line 247; `buildPurchaseLedger` line 314; `buildExpenseLegs` line 387 (3148 lines total).
- `web/apps/api/src/modules/purchase/purchaseReturn.ts` — `buildPurchaseReturnLedger` line 78; `createPurchaseReturn` line 214; `deletePurchaseReturn` line 541 (599 lines total).
- `web/apps/api/src/modules/purchase/purchaseBill.ts` — `purchaseBillData` line 15; `purchaseBillHtml` line 64 (103 lines total).
- `web/apps/api/src/modules/purchase/otherIncome.ts` — `saveOtherIncome` line 894; `getOtherIncome` line 904; `deleteOtherIncome` line 1006 (1067 lines total).
- `web/apps/api/src/modules/purchase/otherCommission.ts` — `saveOtherCommission` line 833; `getOtherCommission` line 843; `deleteOtherCommission` line 942 (1009 lines total).

**Existing test files to retain and extend:**
- `web/apps/api/test/purchase.test.ts`
- `web/apps/api/test/purchase.lifecycle.db.test.ts`
- `web/apps/api/test/purchaseQuotation.db.test.ts`
- `web/apps/api/test/purchaseReturn.test.ts`
- `web/apps/api/test/consignmentPurchase.db.test.ts`
- `web/apps/api/test/otherIncome.db.test.ts`
- `web/apps/api/test/otherCommission.db.test.ts`

**Implementation sequence:**

1. Complete retail/wholesale/hallmark/old-item/other/quotation/consignment form contracts separately, with per-book direction, GST, fine/rate, labour and source-selection behavior.
2. Close parent/stone/diamond/other-item grids, hallmark identifiers/weights, lot/design/image references and API-to-UI reachability for all writer-supported operator fields.
3. Implement exact supplier settlement: cash/bank/card/UPI, TDS/TCS/expenses, fine exchange, partial credit and BILL_OS allocation, preserving independent account roles.
4. Finish return selection and partial quantities against original year/book/voucher/row; lock available source quantities and reverse tax/stock/financial/source adjustments correctly.
5. Qualify saved read/edit/delete for rich imports and linked consignment/tag/manufacturing histories; preserve hidden/physical identity and reject unsafe earlier-stage edits.
6. Connect purchase quotations/conversions, documents, lot/tag generation, stock/inward/tax/supplier reports and daily workflow UAT with complete database differentials.

**Step-by-step verification cases and expected outcomes:**

1. Enter a taxed hallmark purchase with multiple HUIDs and component stones; reopen and compare PR header/detail/child, tax, lot/stock, tender and supplier ledger to desktop.
2. Receive consignment, invoice part, then return remaining goods; custody, invoiced amounts and available quantities reconcile by source year/book/row.
3. Return only one component/quantity from a prior-year purchase and race a second return; aggregate returns cannot exceed the permitted source, rejected request writes nothing.
4. Amend an imported purchase description while retaining null/zero/hidden fields; reader→draft→writer leaves unrelated values exact and generated tags retain lineage.
5. Force a failure during supplier settlement after stock insert; the whole purchase rolls back and retry cannot create a second inward or outstanding record.

### rbac

Prior obligations: P11-04, P02-06; X29. Operator surfaces: `admin/users; per-form navigation/actions and report/print controls`.

**Observed:** A form catalog, route policy registry, current-principal authorization, user management and form rights exist. `app.ts` fail-closes registered routes without policy and distinguishes not-found routing. This is meaningful enforcement but complete operator role journeys, freshly checked in-transaction rights and all export/print/device/image paths still need matrix acceptance.

**Current implementation anchors:**
- `web/apps/api/src/modules/rbac/formCatalog.ts` — `formKey` line 414; `FORM_CATALOG` line 416; `getFormCatalog` line 427; `getFormEntry` line 431 (447 lines total).
- `web/apps/api/src/modules/rbac/routePolicy.ts` — `MASTER_FORM_BY_NAME` line 49; `routePolicyFor` line 919; `resolvePolicyForm` line 963; `isRouteAuthorizedMarker` line 975 (977 lines total).
- `web/apps/api/src/modules/rbac/authorization.ts` — `loadPrincipal` line 60; `loadPrincipalTx` line 65; `authorizeForm` line 105; `authorizeFormTx` line 120 (173 lines total).
- `web/apps/api/src/modules/rbac/formRights.ts` — `getUserFormRights` line 21; `setUserFormRights` line 73; `resolveAllowedForms` line 128 (148 lines total).
- `web/apps/api/src/modules/rbac/users.ts` — `USER_ROLES` line 54; `isAdminRole` line 120; `resolveRole` line 137; `assertAdmin` line 154 (366 lines total).
- `web/apps/api/src/modules/rbac/policy.ts` — `can` line 14; `assertRight` line 28; `filterNav` line 44 (52 lines total).

**Existing test files to retain and extend:**
- `web/apps/api/test/rbac.authorization.test.ts`
- `web/apps/api/test/rbac.policy.test.ts`
- `web/apps/api/test/routePolicy.test.ts`
- `web/apps/api/test/app.security.db.test.ts`
- `web/apps/api/test/reportAuthorization.test.ts`

**Implementation sequence:**

1. Map all desktop role/user/menu/form action combinations to authoritative route policies and UI capabilities, including owner/admin exceptions explicitly supported by the source.
2. Complete create/view/update/delete/print/export/import/utility/provider rights for every page and callable endpoint, not only menu visibility.
3. Enforce scoped fresh rights for dependent operations, report staging, images, source selectors and final transaction admission; caller-supplied flags are never authority.
4. Implement operator-friendly denied-action behavior and rights editing with current-user/session invalidation or revision policy.
5. Execute real cashier, inventory, karigar, accountant, manager and administrator workflows to verify least-required access and audit discoverability.

**Step-by-step verification cases and expected outcomes:**

1. For each role open every allowed/denied page and directly call its API actions; denied routes return a consistent refusal with no data leak or writes.
2. Revoke Update after opening a document; Save fails under fresh rights and preserves draft, while View remains available if allowed.
3. Grant sales View without Print and call PDF/image/report exports directly; print/export rights remain enforced and no bypass through another report family exists.
4. Give a user access to company A only, spoof company/branch/year/book fields and source references from B; server rejects mismatches and B sentinels remain unchanged.

### repair

Prior obligations: P05-07/P05-08; X17. Operator surfaces: `txn/repair-receipt, repair-karigar-issue, repair-karigar-receipt and repair-customer-issue`.

**Observed:** Four distinct workflow stages have real save/get/list/delete functions, open-source selectors, configured book/account validation, receipt/bill calculations and print modules. Repair images have their own versioned identity. The remaining work is connected lifecycle depth, partial routing/settlement/cancellation and independently tested custody and financial conservation, rather than merely adding missing pages.

**Current implementation anchors:**
- `web/apps/api/src/modules/repair/repairReceipt.ts` — `CUSTOMER_REPAIR_RECEIPT` line 22; `repairLineTotals` line 201; `repairBillTotals` line 270; `saveCustomerRepairReceipt` line 772 (1161 lines total).
- `web/apps/api/src/modules/repair/repairKarigarIssue.ts` — `KARIGAR_REPAIR_ISSUE` line 30; `CUSTOMER_REPAIR_RECEIPT_STAGE` line 31; `saveKarigarRepairIssue` line 516; `listOpenCustomerRepairLines` line 742 (945 lines total).
- `web/apps/api/src/modules/repair/repairKarigarReceipt.ts` — `KARIGAR_REPAIR_RECEIPT` line 39; `KARIGAR_REPAIR_ISSUE_STAGE` line 40; `karigarReceiptLabourOtherLegs` line 455; `saveKarigarRepairReceipt` line 1081 (1581 lines total).
- `web/apps/api/src/modules/repair/repairCustomerIssue.ts` — `CUSTOMER_REPAIR_ISSUE` line 46; `CUSTOMER_REPAIR_RECEIPT_SOURCE` line 47; `KARIGAR_REPAIR_RECEIPT_SOURCE` line 48; `saveCustomerRepairIssue` line 1137 (1652 lines total).
- `web/apps/api/src/modules/repair/repairWorkflowCommon.ts` — `repairNumber` line 30; `repairNonNegative` line 33; `assertCompleteRepairScope` line 41; `resolveRepairWorkflowBookTx` line 51 (309 lines total).
- `web/apps/api/src/modules/repair/repairImage.ts` — `REPAIR_IMAGE_TYPE` line 33; `REPAIR_IMAGE_MAX_BYTES` line 40; `repairImageNo` line 67; `resolveRepairImageKey` line 80 (426 lines total).

**Existing test files to retain and extend:**
- `web/apps/api/test/repairReceipt.db.test.ts`
- `web/apps/api/test/repairKarigarReceipt.test.ts`
- `web/apps/api/test/repairImage.test.ts`
- `web/apps/api/test/repairImageConcurrency.routes.db.test.ts`
- `web/apps/api/test/documents.test.ts`

**Implementation sequence:**

1. Reconcile customer intake, karigar issue, karigar receipt and customer delivery as a connected graph with exact source year/book/voucher/line and custody state.
2. Complete every stage's parent/component measurements, required photos, repair descriptions, promised dates, charges/tax, tender/advances and status choices.
3. Implement partial issue/receipt/delivery, substitutions, rejected work, rework and alternate karigar paths that are reachable in the source.
4. Complete edit/cancel/reversal with deterministic source/custody locks and downstream guards, preserving prior stage and image identity.
5. Connect source selectors, receipts/labels/bills, pending/due/custody/karigar/customer reports and audited settlement, then prove a full repair business day.

**Step-by-step verification cases and expected outcomes:**

1. Receive two customer ornaments with photos; issue one to a karigar, receive it back with labour/tax and deliver it; each stage shows the correct custody and source balance.
2. Partially deliver and later deliver the remainder; a second delivery of the same quantity is blocked, with advances and final outstanding conserved.
3. Try deleting intake after downstream issue/receipt; prescribed dependency guard prevents broken source history. Reverse stages in permitted order and compare all custody/ledger rows.
4. Save a receipt concurrently with a photo replacement or source edit; one coherent document/image revision commits and failure leaves no partial financial or image effect.

### reports

Prior obligations: P10-01..P10-07; X25/X26. Operator surfaces: `reports/[report], voucher-register, tag-stock, karigar-ledger and report-layouts`.

**Observed:** Fifty modules implement many financial, stock, manufacturing, loan, customer, tour and specialist datasets plus filters, authorization, staging, binding, rendering and exports. Explicit REPORT_BINDING_CONTRACTS cover selected invoice/order/stock/ledger templates and reject unsupported bindings rather than falling back to sales. Unbound layout previews are explicitly labeled placeholders. Hundreds of catalog references or endpoint presence are not full semantic/visual report acceptance.

**Current implementation anchors:**
- `web/apps/api/src/modules/reports/reportBindingContract.ts` — `REPORT_BINDING_CONTRACTS` line 62; `resolveReportBinding` line 162 (251 lines total).
- `web/apps/api/src/modules/reports/reportBind.ts` — `bindReport` line 60 (331 lines total).
- `web/apps/api/src/modules/reports/reportEngine.ts` — `loadReportSpec` line 72; `listReportSpecs` line 76; `renderReportLayout` line 129 (210 lines total).
- `web/apps/api/src/modules/reports/crystalFormula.ts` — `evalCrystal` line 130 (145 lines total).
- `web/apps/api/src/modules/reports/reportFilters.ts` — `REPORT_FILTER_KEYS` line 63; `unsupportedFilters` line 143; `filterWhere` line 174; `supportedFilters` line 222 (356 lines total).
- `web/apps/api/src/modules/reports/reportAuthorization.ts` — `REPORT_FORM_BY_SLUG` line 10; `REPORT_SLUGS` line 98; `isReportSlug` line 102; `reportFormForSlug` line 108 (110 lines total).
- `web/apps/api/src/modules/reports/reportGridStaging.ts` — `REPORT_DATA_SLOT_COLUMNS` line 24; `REPORT_DATA_SLOTS` line 60; `stageReportGridTx` line 88; `stageReportGrid` line 127 (157 lines total).
- `web/apps/api/src/modules/reports/ledgerStaging.ts` — `FINE_DATA_COLUMNS` line 22; `LEDR_AC_DATA_COLUMNS` line 60; `stageFineDataTx` line 168; `stageLedgerAcDataTx` line 218 (408 lines total).
- `web/apps/api/src/modules/reports/reportCsv.ts` — `csvCell` line 31; `toCsv` line 49; `parseReportCsv` line 107 (158 lines total).
- `web/apps/api/src/modules/reports/xlsx.ts` — `safeSheetName` line 53; `safeFileName` line 71; `looksLikeFormula` line 79; `XLSX_CONTENT_TYPE` line 131 (189 lines total).
- `web/apps/api/src/modules/reports/render.ts` — `escapeHtml` line 12; `renderRegisterHtml` line 40; `renderInvoiceHtml` line 92; `playwrightRendererReadiness` line 148 (214 lines total).

**Existing test files to retain and extend:**
- `web/apps/api/test/reportContract.test.ts`
- `web/apps/api/test/reportBind.test.ts`
- `web/apps/api/test/reportChildren.db.test.ts`
- `web/apps/api/test/reportFiltersApplied.db.test.ts`
- `web/apps/api/test/reportRender.db.test.ts`
- `web/apps/api/test/reportXlsx.test.ts`
- `web/apps/api/test/reportFamilyReports.db.test.ts`
- `web/apps/api/test/orderReport.db.test.ts`

**Implementation sequence:**

1. For every desktop report launcher/mode/template enumerate parameters, query/table/temporary staging, group/order/aggregate/formula/subreport/image behavior and permissions.
2. Bind every required template to a verified family and exact saved/report snapshot; preserve explicit unsupported errors until dataset, child bands and formulas are qualified.
3. Complete financial, metal, stock, manufacturing, repair, loan, member, tax, tour/VP, audit and management datasets with source-correct historical and setting-dependent filters.
4. Implement drill-down using full identities and deterministic staging isolation; concurrent report runs must not overwrite another user's temporary rows.
5. Verify rendered layout, grouping, pagination, child totals, historical images, amount words and paper/device output independently from numerical dataset comparison.
6. Make CSV/XLSX/PDF and on-screen output share filter semantics, exact precision, ordering and access rights; add required reports to exact-set release evidence.

**Step-by-step verification cases and expected outcomes:**

1. Run every required report/mode on the same frozen desktop/web dataset with identical parameters; compare row identities, missing/extra rows, totals and formulas before visual sign-off.
2. Run a multi-child invoice/order report; parent amounts appear once, each child uses its correct source row and hidden OLD_SRNO mapping is handled explicitly.
3. Run two users' differently filtered staging reports concurrently; their report rows and exports stay isolated and committed business tables do not change.
4. Submit an unsupported filter/template; expect an explicit refusal, not silently ignored filters or a generic sales binding producing plausible but incorrect output.
5. Print maximum-length and multipage fixtures on the actual supported media; retained PDF/image scans prove no clipped totals, repeated images, orphan headings or missing footer details.

### sales

Prior obligations: P05-01..P05-08, P06-04/P06-05; X13/X14/X15/X17. Operator surfaces: `txn/sales, sale-return, wholesale-sale/return, hallmark-sale, labour-sale, fine-sale, sales-order, tour-order, sales-quotation, order-cancel, estimate, rate-cut, bullion-sale and vp-parcel`.

**Observed:** Twenty-one modules contain real sales/quotations, orders, wholesale/labour, returns, rate cuts, VP and exact saved incoming Return diagnostic work. Important distinction: new saved-incoming numeric replay APIs and pure effect planners remain non-committing, with only bounded metadata update, but legacy `/sales-returns` POST still calls the numeric create writer and the New return page actively submits it. Generic numeric `editSaleReturn` exists internally but no public PUT route calls it. Sales/Tour order updates have stronger exact-scalar/version/session handling than many older paths. Completing pure Return planners is not completing all Sales or safely releasing the new saved numeric editor.

**Current implementation anchors:**
- `web/apps/api/src/modules/sales/sales.ts` — `lineFine` line 239; `computeLine` line 245; `buildSaleLedger` line 361; `buildSaleFineLedger` line 490 (2763 lines total).
- `web/apps/api/src/modules/sales/salesReturn.ts` — `buildReturnLedger` line 73; `createSaleReturn` line 242; `saleForReturn` line 585; `getSaleReturn` line 668 (863 lines total).
- `web/apps/api/src/modules/sales/savedSaleReturn.ts` — `readSavedSaleReturnIncomingTx` line 419; `getSavedSaleReturnIncoming` line 428; `listSavedSaleReturnIncoming` line 441; `updateSavedSaleReturnMetadata` line 542 (657 lines total).
- `web/apps/api/src/modules/sales/salesOrder.ts` — `getSalesOrderConfiguration` line 372; `getTourOrderConfiguration` line 388; `createSalesOrder` line 756; `createSalesOrderTx` line 768 (2357 lines total).
- `web/apps/api/src/modules/sales/orderLifecyclePolicy.ts` — `ORDER_HEADER_FIELDS` line 6; `ORDER_PARENT_FIELDS` line 45; `ORDER_COMPONENT_FIELDS` line 94; `orderDirtyColumns` line 129 (314 lines total).
- `web/apps/api/src/modules/sales/orderDesignSelection.ts` — `listSalesOrderDesigns` line 131; `resolveSalesOrderDesignTx` line 200; `getSalesOrderDesignImage` line 240 (263 lines total).
- `web/apps/api/src/modules/sales/saleReturnSource.ts` — `listSaleReturnSourceVouchers` line 301; `getSaleReturnSourceItems` line 442 (628 lines total).
- `web/apps/api/src/modules/sales/saleReturnIncomingReplay.ts` — `SALE_RETURN_INCOMING_REPLAY_CONTRACT` line 28; `SALE_RETURN_INCOMING_REPLAY_PROFILE` line 29; `saleReturnIncomingReplayInput` line 128; `observeSaleReturnIncomingReplayTx` line 256 (561 lines total).
- `web/apps/api/src/modules/sales/saleReturnBillReplay.ts` — `SALE_RETURN_BILL_REPLAY_CONTRACT` line 46; `SALE_RETURN_BILL_REPLAY_PROFILE` line 47; `saleReturnBillReplayInput` line 156; `observeSaleReturnBillReplayTx` line 331 (628 lines total).
- `web/apps/api/src/modules/sales/saleReturnLabourReplay.ts` — `SALE_RETURN_LABOUR_REPLAY_CONTRACT` line 43; `SALE_RETURN_LABOUR_REPLAY_PROFILE` line 45; `saleReturnLabourObserveInput` line 308; `saleReturnLabourAppendInput` line 319 (877 lines total).
- `web/apps/api/src/modules/sales/rateCut.ts` — `resolveBookClassification` line 73; `resolveBookAccounts` line 145; `round3` line 205; `round0` line 207 (1812 lines total).
- `web/apps/api/src/modules/sales/wholesaleSaleReturn.ts` — `saveWholesaleSaleReturn` line 1343; `getWholesaleSaleReturn` line 1353; `deleteWholesaleSaleReturn` line 1443 (1506 lines total).
- `web/apps/api/src/modules/sales/labourInvoice.ts` — `createLabourInvoice` line 194; `getLabourInvoice` line 559; `editLabourInvoice` line 613; `deleteLabourInvoice` line 648 (724 lines total).
- `web/apps/api/src/modules/sales/vpParcel.ts` — `saveVpParcel` line 1214; `getVpParcel` line 1220; `deleteVpParcel` line 1303 (1384 lines total).

**Existing test files to retain and extend:**
- `web/apps/api/test/sales.lifecycle.db.test.ts`
- `web/apps/api/test/salesFamilyLifecycle.db.test.ts`
- `web/apps/api/test/savedSaleReturn.db.test.ts`
- `web/apps/api/test/salesOrderRound4.db.test.ts`
- `web/apps/api/test/salesOrderSessionCommand.db.test.ts`
- `web/apps/api/test/saleReturnIncomingReplay.routes.db.test.ts`
- `web/apps/api/test/saleReturnBillReplay.routes.db.test.ts`
- `web/apps/api/test/saleReturnLabourReplay.routes.db.test.ts`
- `web/apps/api/test/wholesaleSaleReturn.db.test.ts`

**Implementation sequence:**

1. Build a route-by-route capability matrix distinguishing routed legacy numeric creation, internal unrouted numeric edit, exact saved metadata, read-only row/bill/labour replay, source selectors and provider-controlled actions; do not publish a blanket claim that all numeric Return writes are blocked.
2. Finish retail/hallmark/wholesale/labour/fine/order/quotation variants at field, child, event, setting and print level, including exact tag/source identity, rate/fine/labour/discount/tax/tender/old-gold/scheme/loyalty behavior.
3. Resume saved incoming Return work in the retained Round15 order: complete independent full observation; enumerate all companion effects; trusted transaction hydration/admission; fresh guards/audit; ordered replay; Serializable affected-count commit; strict Update endpoint/UI; full readback/report differential.
4. Keep pure Return `canCommit:false` outputs separate from trusted authority and legacy delete/rebuild writers. Complete multirow/source/tag/children, outgoing and edition variants before closing P05-03.
5. Extend the stronger order lifecycle to quotation/conversion/reservation/delivery/fulfillment/cancel/refund, preserving parent/component/raw imported values, images and selected designs.
6. Complete retail and wholesale settlement, refunds, bill outstanding and cross-document old-gold/scheme/bullion/approval/VP effects with atomic source locks and exact current balances.
7. Standardize saved hydration, edit and reversal guards for old and new routes and reconcile stock, AC/Rojmel/tax, hidden/OS and linked audit rows after every permitted event.
8. Execute complete operator business journeys and full desktop differentials for all branches; rich fields or large unit-test counts cannot close full sales acceptance.

**Step-by-step verification cases and expected outcomes:**

1. Create a rich sale with tag/stone children, old-gold exchange and cash/card/UPI/credit; reopen unchanged, amend one allowed field, print and reverse; exact table footprints and source balances must match independent desktop output at every stage.
2. Open a saved incoming Return containing null/blank/zero and high-precision/Float fields; preview c27/bill/labour events. Current preview must leave all financial rows unchanged and return canCommit:false.
3. After implementing the qualified saved numeric writer, change one Other amount using a fresh trusted observation; compare the exact admitted line/header/financial/BAR/companion changes, all retained rows and report totals; fault each write boundary to prove rollback.
4. Run the legacy New return route and generic edit against the same source fixtures separately; document actual effects and close their own coverage, rather than assuming newer preview tests protect them.
5. Create an order with multiple design children and custom/inherited images, reserve/fulfill partially and cancel remaining quantity; linked stock, advance/refund and source outstanding reconcile, and stale-image/context attempts conflict.
6. Race two sales or returns consuming the same tag/source balance and simulate a lost acknowledgement; only valid effects commit and recovery cannot duplicate stock, tax, tender or outstanding postings.

### scheme

Prior obligations: P09-04/P09-05, P10-05; X24/X25. Operator surfaces: `scheme passbook/document actions; business writers are membership/scheme.ts`.

**Observed:** The separate scheme directory contains passbook data, staging and HTML rendering, not another full scheme business service. It uses TEMP_AD_DATA staging. Enrollment, installments/maturity and gold adjustment reside in membership/scheme.ts. Passbook acceptance must follow those actual persisted effects and maintain report-run isolation.

**Current implementation anchors:**
- `web/apps/api/src/modules/scheme/passbook.ts` — `TEMP_AD_DATA_COLUMNS` line 31; `stageSchemePassbookRowsTx` line 52; `schemePassbookData` line 81; `schemePassbookHtml` line 120 (202 lines total).

**Existing test files to retain and extend:**
- `web/apps/api/test/schemeMonthlyReport.db.test.ts`
- `web/apps/api/test/schemeLedgerLegs.db.test.ts`
- `web/apps/api/test/schemeGoldAdjust.db.test.ts`
- `web/apps/api/test/documents.test.ts`

**Implementation sequence:**

1. Reconcile original passbook layout, month/order/year scope, receipt/bonus/less/adjustment display and printer alignment with source AD and TEMP_AD fields.
2. Bind passbook data to exact scheme/member identity and historical installment snapshots, not only display member number.
3. Ensure staging is request/user isolated and repeat printing cannot duplicate or corrupt financial scheme rows.
4. Implement required physical passbook pagination/positioning, reprint/duplicate marks and image/QR details with proper print rights.
5. Close passbook acceptance together with enrollment/installment/maturity and report lifecycle evidence from membership.

**Step-by-step verification cases and expected outcomes:**

1. Pay installments out of date order and print passbook; source-defined ordering/month labels and totals match the desktop and no amount is counted twice.
2. Print two members concurrently using TEMP_AD_DATA; each output has only its member rows and business AD tables are unchanged.
3. Correct/reverse an installment then reprint; output reflects the approved historical/correction rule while retaining audit and original receipt identity.
4. Print on an actual partially used passbook; alignment, continuation page and duplicate behavior match the agreed operator workflow.

### security

Prior obligations: P01-01, P11-04, P12-05; X05/X29/X31. Operator surfaces: `no standalone business form`.

**Observed:** This directory contains identifier-validation/quoting helpers. It is not a completed application security review: authentication, authorization, RLS, raw SQL, input handling, provider secrets and deployment controls live elsewhere. Many modules build bounded raw SQL with separately parameterized values; dynamic identifiers must remain sourced from allowlists/configuration.

**Current implementation anchors:**
- `web/apps/api/src/modules/security/sql.ts` — `isSafeIdent` line 16; `quoteIdent` line 21; `assertSafeIdent` line 28 (31 lines total).

**Existing test files to retain and extend:**
- `web/apps/api/test/security.test.ts`
- `web/apps/api/test/app.security.db.test.ts`
- `web/apps/api/test/reportAuthorization.test.ts`
- `web/apps/api/test/messageLogIsolation.db.test.ts`

**Implementation sequence:**

1. Inventory dynamic SQL identifier/table/order/filter sources and ensure user values remain parameterized with explicit allowlisted identifiers.
2. Qualify non-owner forced-RLS runtime and business-scope enforcement across query/write/staging/backup/export/image endpoints.
3. Complete deployment controls for session/cookies/origins/rate limits/upload decoding and secret storage according to actual topology and required workflows.
4. Audit sensitive data exposure through errors, logs, reports, attempts and backup/export artifacts without breaking required operational diagnostics.
5. Run scoped security verification alongside functional acceptance and remediate demonstrated findings without treating this helper module as product-level assurance.

**Step-by-step verification cases and expected outcomes:**

1. Submit quote/wildcard/SQL-like strings in search, report filters and master names; intended literal data remains searchable and no identifier syntax is executed.
2. Use two tenants and two companies with matching keys under the non-owner runtime; every direct endpoint and report/export remains isolated.
3. Upload invalid/mismatched/oversized image content; reject before persistence/render execution and retain no orphan metadata.
4. Cause database/provider errors containing sensitive inputs; user-facing and structured log output contains necessary codes/context but no secret tokens or unauthorized company data.

### settings

Prior obligations: P02-05/P03-04; X08. Operator surfaces: `settings; company/column configuration masters`.

**Observed:** Both CO_SET and CO_SET_NEW are exposed through a typed catalog with 130 inventoried columns, namespace-aware IDs and null-preserving reads. Save validates enums/types/widths and rejects unknown keys. Exposure is not behavioral fidelity: current retained heuristic says 47/130 honored and 80 inert, but scanner limitations mean each consumer needs manual verification rather than treating those counts as confirmed gaps.

**Current implementation anchors:**
- `web/apps/api/src/modules/settings/settings.ts` — `SETTING_FIELDS` line 39; `getSettings` line 54; `coerceSettingValue` line 90; `saveSettings` line 140 (220 lines total).
- `web/apps/api/src/modules/settings/settingsCatalog.ts` — `SETTING_CATALOG` line 49; `SETTING_CATALOG_BY_ID` line 1560; `SETTING_CATALOG_BY_KEY` line 1565 (1567 lines total).
- `web/apps/api/src/modules/settings/settingsInventory.ts` — `SETTING_IDENTITY_COLUMNS` line 31; `SETTING_COLUMNS` line 33; `SETTING_COLUMN_COUNTS` line 169; `CONFIGURABLE_SETTINGS` line 172 (174 lines total).

**Existing test files to retain and extend:**
- `web/apps/api/test/settings.db.test.ts`
- `web/apps/api/test/settingsEffect.db.test.ts`
- `web/apps/api/test/settingsBehavior.db.test.ts`
- `web/apps/api/test/settingsRealValues.test.ts`
- `web/apps/api/test/parityStrictSettings.test.ts`

**Implementation sequence:**

1. For every setting record source storage/type/default-on-open/default-on-save, precedence over book/user/master settings and every consuming form/calculation/report/integration.
2. Separate exposed-but-no-effect, partially honored, fully tested and unavailable settings using behavior evidence, not name matching or a static exposure ratio.
3. Complete missing consumers and remove contradictory local defaults while retaining required blank/null/zero distinctions and historical saved-document rules.
4. Implement setting change concurrency/revision and context invalidation where a draft's calculations, admission guards, columns or provider mode depend on it.
5. Verify valid/invalid values and every behavior branch through real operator actions, persisted outcomes and affected reports; document intentional web adaptations.

**Step-by-step verification cases and expected outcomes:**

1. Toggle labour-with-ghat, rounding and negative-stock policy independently; enter the same fixture before/after, compare precise recalculation and server admission to source expectations.
2. Load null, blank and zero settings and save one unrelated field; untouched values remain distinct and duplicated names in CO_SET/CO_SET_NEW do not overwrite each other.
3. Change a calculation/lock setting while another user has a document open; Save applies the defined fresh-policy conflict/recalculation rule and never commits a stale preview silently.
4. Submit an unknown key, invalid enum, impossible date and out-of-width value; expect per-field rejection and no partial update across the two settings tables.

### shared

Prior obligations: P01-02/P01-03, P02-05; X04/X06/X08. Operator surfaces: `consumed by all transaction and report modules`.

**Observed:** Sixteen files contain settings/book/rounding/tax/fine/labour/counter/stock/account balance/period policies, component utilities and extensive Rojmel generation. Source-cited behavior has improved, but its rate-cut section explicitly notes unimplemented silver/interest/tax/TDS/card/labour shapes. A later old comment claims CASH is unimplemented even though `buildCashRojmel` and finance callers now exist; treat comments as dated evidence and inspect active code. Core Decimal and exact-text work coexists with Number arithmetic, so shared helper reuse is not proof of universal desktop Double/Format/culture equivalence.

**Current implementation anchors:**
- `web/apps/api/src/modules/shared/rojmel.ts` — `ROJMEL_ROW_TYPE` line 42; `ROJMEL_PURCHASE_ROW_TYPE` line 97; `rojmelMetalFor` line 117; `rojmelLedrKey` line 141 (1432 lines total).
- `web/apps/api/src/modules/shared/settingsBehavior.ts` — `DEFAULT_CASH_LIMIT` line 3; `DEFAULT_PAN_CARD_VAL` line 4; `DEFAULT_INT_YEAR_DAYS` line 5; `DEFAULT_OUNCE_CONVERSION` line 7 (772 lines total).
- `web/apps/api/src/modules/shared/roundingPolicy.ts` — `resolveRoundingPolicy` line 86 (155 lines total).
- `web/apps/api/src/modules/shared/roundingPolicyLoader.ts` — `resolveRoundingPolicyTx` line 20 (67 lines total).
- `web/apps/api/src/modules/shared/bookPolicy.ts` — `workflowPolicy` line 37; `resolveBookPolicyTx` line 52; `resolveBookAccountTx` line 119 (148 lines total).
- `web/apps/api/src/modules/shared/taxPolicy.ts` — `resolveTaxPolicyTx` line 29 (199 lines total).
- `web/apps/api/src/modules/shared/finePolicy.ts` (1–18).
- `web/apps/api/src/modules/shared/labourDesktop.ts` — `DESKTOP_LABOUR_TYPES` line 47; `DESKTOP_LABOUR_LABELS` line 52; `isDesktopLabourType` line 59; `desktopLabourAmount` line 98 (242 lines total).
- `web/apps/api/src/modules/shared/desktopAccountBalance.ts` — `DESKTOP_ACCOUNT_BALANCE_VERSION` line 8; `DESKTOP_ACCOUNT_BALANCE_PROFILE` line 9; `observeDesktopAccountBalanceTx` line 231 (327 lines total).
- `web/apps/api/src/modules/shared/counterStockPolicy.ts` — `resolveCounterStockPolicy` line 26; `resolveCounterStockPolicyTx` line 35; `assertCounterCodes` line 55; `assertHallmarkWeights` line 83 (133 lines total).
- `web/apps/api/src/modules/shared/stoneSubDetail.ts` — `stoneSubDetailColumns` line 72; `STONE_SUB_DETAIL_COLUMNS` line 110; `readStoneSubDetail` line 126 (173 lines total).
- `web/apps/api/src/modules/shared/postingAccounts.ts` — `requirePostingAccount` line 75; `resolveBookSlotAccountTx` line 99 (133 lines total).

**Existing test files to retain and extend:**
- `web/apps/api/test/rojmel.test.ts`
- `web/apps/api/test/purchaseRojmel.test.ts`
- `web/apps/api/test/roundingPolicy.test.ts`
- `web/apps/api/test/settingsBehavior.test.ts`
- `web/apps/api/test/desktopAccountBalance.db.test.ts`
- `web/apps/api/test/finePolicy.test.ts`
- `web/apps/api/test/labourDesktop.test.ts`
- `web/apps/api/test/lineComponentRounding.db.test.ts`

**Implementation sequence:**

1. Build a numerical-policy map per source site: Val parsing/culture, Double versus decimal, Format, Math.Round midpoint, intermediate rounding, configured precision and storage type.
2. Complete source-specific Rojmel row families and account/stock/tax effects from independent fixtures, including rate-cut silver/interest/tax/TDS/card/labour shapes; independently qualify the existing cash builder rather than labeling it absent.
3. Resolve configured book/account/tax/master precedence and ambiguity behavior in one qualified loader per concern; reject unknown source facts instead of inventing fallback accounts.
4. Distinguish exact historical cell preservation from newly computed output, and retain Float binary64 qualification where schema/source actually use it.
5. Adopt shared helpers family by family with differential regression, not blanket replacement of formulas whose event order or rounding differs.

**Step-by-step verification cases and expected outcomes:**

1. Run independent positive/negative midpoint, high precision, large value, null/blank/zero and culture parsing vectors at each documented rounding site; compare exact cell text and stored bytes/value policy.
2. Generate a voucher with cash/card/TDS/labour and compare complete ROJ_MEL rows, serial keys and order against desktop; omitted families must fail instead of passing aggregate totals.
3. Configure conflicting or missing posting accounts/taxes/books; the writer fails before committing any document effect and reports the specific configuration issue.
4. Apply an ordered sequence of same-value edits, rate/touch changes and row removals; final values must follow desktop event order, not merely a commutative formula on final inputs.

### stock

Prior obligations: P07-01..P07-06; X18/X19/X20/X21/X22. Operator surfaces: `txn/tag-opening, tag-transfer, tag-cancel, tag-split, tag-weight-diff, tag-adjust, tag-print, counter-transfer, item-opening, item-lot, stock-in/out, stock-adjust, physical-stock and stone-dm-cf`.

**Observed:** Twelve modules implement stock/openings, in/out lifecycle, physical stock, tag adjustment/printing/images and invariants. Rich tag-opening update was separately released with round-trip evidence. Four distinct tag mutations remain HTTP/UI contained: transfer, cancel, weight difference and split. Their existing functions are incomplete legacy implementations and must not be presented as available because pages or exports exist; tagSplit currently writes MAIN_STOCK movements without full child barcode lineage.

**Current implementation anchors:**
- `web/apps/api/src/modules/stock/stock.ts` — `buildTagWhere` line 61; `TAG_STOCK_COLUMNS` line 133; `tagAvailable` line 194; `createTag` line 198 (1104 lines total).
- `web/apps/api/src/modules/stock/stockInout.ts` — `createStockOut` line 1189; `getStockOut` line 1191; `editStockOut` line 1193; `deleteStockOut` line 1195 (1209 lines total).
- `web/apps/api/src/modules/stock/tagOps.ts` — `tagCancel` line 168; `deleteTagCancel` line 400; `tagWeightDiff` line 523; `deleteTagWeightDiff` line 706 (717 lines total).
- `web/apps/api/src/modules/stock/tagSplit.ts` — `splitTag` line 93; `deleteTagSplit` line 187 (198 lines total).
- `web/apps/api/src/modules/stock/tagAdjust.ts` — `TAG_ADJUST_BOOK` line 6; `saveTagAdjust` line 379; `getTagAdjust` line 413; `deleteTagAdjust` line 466 (481 lines total).
- `web/apps/api/src/modules/stock/stockVoucherLifecycle.ts` — `tagOpening` line 953; `itemOpening` line 970; `itemLot` line 987; `getTagOpening` line 1043 (1428 lines total).
- `web/apps/api/src/modules/stock/physicalStock.ts` — `savePhysicalStock` line 434; `getPhysicalStock` line 444; `deletePhysicalStock` line 523 (550 lines total).
- `web/apps/api/src/modules/stock/tagInvariants.ts` — `checkTagInvariants` line 87; `TAG_INVARIANT_COVERAGE` line 272 (360 lines total).
- `web/apps/api/src/modules/stock/tagPrint.ts` — `TAG_PRINT_STAGING_COLUMNS` line 20; `TAG_STOCK_PRINT_ROJMEL_COLUMNS` line 148; `TAG_STOCK_PRINT_LITERALS` line 163; `TAG_STOCK_PRINT_COLUMNS` line 165 (540 lines total).
- `web/apps/api/src/modules/stock/lotRegister.ts` — `LOT_REGISTER_PURCHASE_MAIN_BOOKS` line 32; `stagePurchaseLotDetailTx` line 34 (84 lines total).
- `web/apps/api/src/modules/stock/tagImageTransfer.ts` — `TAG_DATA_COLUMNS` line 16; `queueTagImageTransfer` line 66 (99 lines total).

**Existing test files to retain and extend:**
- `web/apps/api/test/tagOpeningRoundTrip.db.test.ts`
- `web/apps/api/test/tagCancelIdentity.db.test.ts`
- `web/apps/api/test/tagInvariants.db.test.ts`
- `web/apps/api/test/stockLifecycle.db.test.ts`
- `web/apps/api/test/stockInout.db.test.ts`
- `web/apps/api/test/physicalStock.db.test.ts`
- `web/apps/api/test/tagAdjust.db.test.ts`
- `web/apps/api/test/tagPrintStaging.db.test.ts`
- `web/apps/api/test/parityContainmentRoutes.test.ts`

**Implementation sequence:**

1. Define exact live stock identity across tenant/company/location/year/book/voucher/row/tag/VCH_SRNO/lot/component and source lineage; historical presence is not current availability.
2. Complete transfer lifecycle with same physical serial where required, branch/counter movement, child/image links and deterministic source/destination locks before lifting its own containment.
3. Complete cancellation with exact live source serial, BAR_CAN parent/detail/child lineage, reversal and downstream use guards; release separately from transfer.
4. Implement split as atomic parent consume plus child serial allocation, BAR header/detail/component/image lineage, fine/weight/pieces/value conservation and whole lifecycle before lifting split containment.
5. Implement tag weight difference/replacement including barcode/image/karigar/Rojmel/serial branches and separate sale-driven SL_TAG_WT_DIFF ownership; do not equate simple net adjustment with replacement.
6. Complete stock openings/inout/lot/adjustment read-edit-delete and physical-count session finalize/discrepancy/reversal with source snapshots, ownership and audit.
7. Reconcile tag/lot/counter/physical stock, label staging/printing and downstream sale/manufacturing use; release each currently contained operation only with its independent complete evidence.

**Step-by-step verification cases and expected outcomes:**

1. Open/save a rich tag containing alphanumeric HUIDs, stones, design image and historical scalar values; all BAR detail/child/identity/image and stock rows remain exact outside explicit edits.
2. After implementing transfer/cancel, operate on two historical rows sharing TAG_NO but different VCH_SRNO; only the intended currently live serial moves/cancels and reversal restores exact lineage.
3. Split one tag into three children; validate exact source-qualified conservation, unique serials, children/images and parent unavailability. Inject failure during second child creation and expect no partial split.
4. Perform a physical count, resolve discrepancies, finalize and reverse under rights; counted/ledger stock reports reconcile and concurrent sales cannot silently invalidate the count snapshot.
5. Before individual release, call all contained endpoints and UI actions; expected explicit non-retryable containment with no DML. After release, run actual browser/concurrency/rollback cases for that operation, retaining other containments.

### tour

Prior obligations: P05-05/P05-08; X17. Operator surfaces: `txn/tour, tour-return; tour-order is in sales/salesOrder.ts`.

**Observed:** `tour.ts` implements approval/tour issue, return, source lines, billing marks and deletions with APR tables. It is separate from Tour Order's newer exact saved lifecycle. Custody, partial return/billing, source balances, multi-location routing and reversal dependencies still require connected acceptance.

**Current implementation anchors:**
- `web/apps/api/src/modules/tour/tour.ts` — `tourLineFine` line 141; `tourIssue` line 169; `deleteTour` line 387; `tourReturn` line 450 (671 lines total).

**Existing test files to retain and extend:**
- `web/apps/api/test/tourIdtl.db.test.ts`
- `web/apps/api/test/tourReports.db.test.ts`
- `web/apps/api/test/tourOrder.db.test.ts`
- `web/apps/api/test/tourOrderExactValues.db.test.ts`
- `web/apps/api/test/workflows.test.ts`

**Implementation sequence:**

1. Map approval issue/receipt, consignment/tour and Tour Order as distinct workflows and connect them only through source-defined references.
2. Complete issue selection with live tag/lot/component identity, receiver/agent/counter data, valuation and custody owner; preserve APR child detail and images.
3. Implement partial return and partial billing against the same issued rows with locked remaining quantity and exact billed/returned status.
4. Finish saved edit/delete and reversal guarding against later sale, return or transfer, and preserve historical scope/serial identity.
5. Connect issue/return/party/outstanding reports, delivery documents and role-based high-volume operator tasks across all relevant modules.

**Step-by-step verification cases and expected outcomes:**

1. Issue three tags on tour, return one and bill one; the remaining custody/outstanding report shows exactly the third with correct quantities and fine.
2. Race a return and sale of the same tour tag; only one permitted consumption commits, no duplicate available stock or inconsistent APR status appears.
3. Attempt to delete the original issue after a billed/returned child exists; expect a dependency refusal or approved ordered reversal with complete audit.
4. Reopen a Tour Order containing imported scalar strings/null/zero separately from APR tour issue; unchanged Save preserves its exact order data and cannot accidentally invoke tour movement effects.

### utilities

Prior obligations: P11-01/P11-05; X27. Operator surfaces: `utilities/data-repair, data-export, data-refresh, voucher-renumber, estimate-reset, hdd-registry, user-request, window-tiles and reminder-entry`.

**Observed:** Ten modules implement actual preview/apply operations for repair, export flags, refresh, renumber and estimate reset plus utility records/layouts/reminders. Data repair has authority/backup/reason checks and audit history. Full graph ownership, rollback and actual desktop utility scope are necessary before unrestricted business use; a function named refresh/reset is not a harmless read.

**Current implementation anchors:**
- `web/apps/api/src/modules/utilities/dataRepair.ts` — `registerRepair` line 131; `listRepairs` line 136; `getRepair` line 140; `confirmationFor` line 147 (460 lines total).
- `web/apps/api/src/modules/utilities/dataRepairOps.ts` (1–1397).
- `web/apps/api/src/modules/utilities/dataExport.ts` — `DATA_EXPORT_KIND` line 3; `DATA_EXPORT_TABLES` line 10; `dataExportPendingOnly` line 146; `dataExportPreview` line 284 (393 lines total).
- `web/apps/api/src/modules/utilities/dataRefresh.ts` — `dataRefresh` line 19 (152 lines total).
- `web/apps/api/src/modules/utilities/voucherRenumber.ts` — `RENUMBER_TABLE_ALLOWLIST` line 65; `previewRenumber` line 191; `applyRenumber` line 212 (272 lines total).
- `web/apps/api/src/modules/utilities/estimateReset.ts` — `ESTIMATE_RESET_KIND` line 3; `ESTIMATE_RESET_CONFIRMATION` line 4; `STOCK_ADJUST_BOOK` line 5; `estimateResetPreview` line 877 (1323 lines total).
- `web/apps/api/src/modules/utilities/hddRegistry.ts` — `listHddRegistry` line 29; `getHddRegistry` line 42; `saveHddRegistry` line 51; `deleteHddRegistry` line 71 (84 lines total).
- `web/apps/api/src/modules/utilities/userRequest.ts` — `listUserRequests` line 87; `getUserRequest` line 105; `saveUserRequest` line 127; `deleteUserRequest` line 209 (228 lines total).
- `web/apps/api/src/modules/utilities/windowTiles.ts` — `listWindowTiles` line 31; `getWindowTile` line 64; `saveWindowTile` line 125 (165 lines total).
- `web/apps/api/src/modules/utilities/reminderEntry.ts` — `createReminderEntry` line 27; `listReminderEntries` line 55; `deleteReminderEntry` line 78 (91 lines total).

**Existing test files to retain and extend:**
- `web/apps/api/test/dataRepair.db.test.ts`
- `web/apps/api/test/dataRepairAuthority.test.ts`
- `web/apps/api/test/dataRepairBatch2.db.test.ts`
- `web/apps/api/test/dataExport.db.test.ts`
- `web/apps/api/test/estimateReset.db.test.ts`
- `web/apps/api/test/correctionWorkflow.db.test.ts`
- `web/apps/api/test/utilities.db.test.ts`
- `web/apps/api/test/windowTiles.db.test.ts`

**Implementation sequence:**

1. Catalog each desktop utility's inputs, affected table/column/reference graph, allowed scope, prerequisites, exclusions and observable output including companion utility behavior.
2. Complete preview manifests with exact row identities, before/after hashes/counts and stale-preview detection; do not apply based only on aggregate counts.
3. Make renumber/reset/repair update all dependent voucher/hidden/stock/image/ledger/report references atomically, retaining source-defined keys and audit evidence.
4. Implement dry-run/export/import transfer contracts, marking/resetting DATA_TRFR only after the intended accepted operation and preserving unrelated company/year records.
5. Finish operator UI, rights/reason/backup prerequisites where required, cancellation/recovery and explicit post-operation business reconciliation.

**Step-by-step verification cases and expected outcomes:**

1. Preview renumber on a voucher with stock, tender, source and image children; apply then open every linked document/report, verifying the complete graph follows the new identity without orphan rows.
2. Modify a target after preview and before apply; stale plan is rejected and neither the new user change nor unrelated rows are overwritten.
3. Force a failure midway through repair/reset; all affected tables roll back and operation history reports failure rather than success, with original backup retained.
4. Export only pending records from one company/year, acknowledge transfer and reset flags through permitted UI; exported row set and flag changes match exactly and second-company sentinels remain unchanged.

### vouchers

Prior obligations: P01-01/P01-04/P01-05; X05/X06. Operator surfaces: `VoucherList, VoucherChrome and all transaction pages`.

**Observed:** Shared numbering, hidden numbering, fiscal/header identity, delete-write-set and field-audit helpers exist. `formatVoucherNo` and full scope support preserving desktop number shapes. Imported hidden-number and concatenated ledger identities have special cross-year collision domains, so applying the visible voucher key uniformly to every table is incorrect. Different families still have different lifecycle depth.

**Current implementation anchors:**
- `web/apps/api/src/modules/vouchers/numbering.ts` — `scopeKey` line 24; `formatVoucherNo` line 28; `nextVoucherNoTx` line 147; `nextVoucherNo` line 156 (216 lines total).
- `web/apps/api/src/modules/vouchers/lifecycle.ts` — `nextHiddenVoucherNoTx` line 38; `voucherTimestamp` line 59; `assertFiscalDateTx` line 80; `persistedVoucherHeaderTx` line 108 (175 lines total).
- `web/apps/api/src/modules/vouchers/list.ts` — `recentVouchers` line 31 (87 lines total).
- `web/apps/api/src/modules/vouchers/fieldAudit.ts` — `recordFieldChangesTx` line 89 (130 lines total).

**Existing test files to retain and extend:**
- `web/apps/api/test/numbering.test.ts`
- `web/apps/api/test/voucherLifecycle.test.ts`
- `web/apps/api/test/reopenVoucher.db.test.ts`
- `web/apps/api/test/ledgerKeyFormat.db.test.ts`
- `web/apps/api/test/transaction.integrity.db.test.ts`

**Implementation sequence:**

1. Record per-family visible/hidden number format, reset/sequence domain, physical key and cross-year/global collision behavior from source and actual schema.
2. Complete deterministic number allocation and exact imported key handling for new, copied, transferred, converted and corrected vouchers without renumbering historical rows accidentally.
3. Make saved document reads return full required parent/child/companion values plus revision and capability; unsupported historical profiles remain explicit, not silently truncated.
4. Standardize open/edit/delete with fiscal/period guards, full reference checks, ownership-limited mutations, audit and postcondition validation while preserving variant-specific semantics.
5. Implement list/search/navigation by complete identity, and define ambiguous commit recovery separately from a mere UI busy flag or context receipt.

**Step-by-step verification cases and expected outcomes:**

1. Allocate concurrently in two books/years and open imported alphanumeric/padded identifiers where supported; numbers are unique in their true domain and existing history is not rewritten.
2. Create matching visible voucher numbers in different scopes and cross-year hidden-key collisions; reads/mutations choose one intended identity or reject ambiguity before DML.
3. Reopen rich vouchers from every family and Save unchanged; header/detail/child/hidden values and physical ownership remain exactly as prescribed.
4. Delete a voucher with dependent settlement/tag/order/provider state; dependency guard or approved reversal path preserves consistency, and injected failure leaves no partially deleted write set.

## Specific evidence anchors for critical qualifications

- `web/packages/core/containment.mjs:24–111`: exact six blocked operations, reasons and separate exit gates. `web/apps/api/src/routes/txn.ts:679–685` builds non-retryable containment responses. Calls occur at logical restore around 4453, transfer 5004/5012, cancel 5039/5117, weight difference 5097/5124, split 7158/7171.
- `web/apps/api/src/modules/manufacturing/mfgLot.ts:20–28` declares unavailability/exact JSON numeric text; `:195–218` returns browse/source capabilities with `writes:false` and unverified effectiveMode. `web/apps/web/components/MfgLotForm.tsx:230–345` is saved/source display. This is stronger than a blank placeholder but lacks admitted mutation.
- `web/apps/api/src/modules/einvoice/creditNote.ts:55–103` list/get surface; `web/apps/web/app/(app)/txn/e-crnt-note/page.tsx:133–138` describes saved browse/review + IRN. Mutation of IRN state does not create a credit-note financial document.
- `web/apps/api/src/routes/txn.ts:1270–1308` explicitly read-only incoming and whole-bill Return POST previews; bounded metadata update around 1384; legacy numeric POST `/sales-returns` immediately follows at 1399. `salesReturn.ts:242` implements numeric create; the internal exported edit at `:743` deletes/rebuilds owned tables but is not registered as a public route. The only current Return PUT is metadata at `txn.ts:1386`. `sale-return/page.tsx:210–248` selects New/Saved workspace and `LegacySaleReturnForm`; its submit posts numeric values to `/sales-returns` around 349–390.
- `web/packages/core/src/money.ts:1–57`: Decimal half-up/half-even primitives plus explicit exact-text qualification; number-returning helpers remain. `web/apps/api/src/modules/posting/posting.ts:42–53` Number aggregate balance; `:88–135` measured create defaults override certain explicit null values. `schema.prisma:109–111` and many later columns retain Float; all values are not Decimal despite some older comments.
- `web/apps/api/src/modules/shared/rojmel.ts:714–716` states omitted rate-cut silver/interest/tax/TDS/card/labour families. The old comment at `:1396` about missing CASH is superseded by active `buildCashRojmel` at `:606` and finance callers at `finance.ts:400/642/833/991`; complete acceptance still requires all branch differentials.
- `web/apps/api/src/modules/gst/gst.ts:12` fixed B2CL_THRESHOLD and `:97` HSN fallback; independently establish required statutory behavior at implementation time.
- `web/apps/api/src/modules/membership/membership.ts:98–107`: member existence/balance read then number allocation; no member-row lock visible there. `web/packages/db/src/tenant.ts:21–30` delegates isolation options, with no default Serializable level. Race risk requires real DB verification.
- `web/apps/api/src/modules/reports/reportBindingContract.ts:34–45` explicit unsupported exception and `:70–154` bounded contracts; `reportEngine.ts:140–204` distinguishes unbound placeholders. `forms/formLayoutEngine.ts:89–92` renders disabled buttons/checkboxes in previews.
- `web/apps/api/src/modules/masters/year.ts:114–175` carries openings with company/year-only deletes and source aggregates, then writes a selected/default LC_CODE. Its route callers include `txn.ts:6299/7723`. Treat as a specific static scope risk and require branch-ownership proof, not an established runtime failure.
- `web/apps/api/test/globalSetup.ts` can enable database tests automatically when reachable. Do not run the full API test command against a user/customer database. Use an explicit isolated fixture database and record non-owner identity, migrations and full selected test set. This audit ran no tests.

## Fresh verification recipe for the eventual implementation candidate

1. Freeze source/dependency/artifact/configuration/schema manifests and required scenario/leaf/case sets. Confirm all referenced desktop source and report artifacts are real contents rather than LFS pointers, and record any unavailable oracle separately.
2. Prepare disposable non-owner Postgres fixture environments and an independently controlled original desktop environment. Restore anonymized representative history, not only empty synthetic companies, with two tenants, two companies, branches, years and colliding voucher/tag numbers.
3. Run static schema/type/route/settings/contract/coverage checks, unit/core/browser-unit tests and strict production/test compilation. Retain exact commands, exit statuses, logs, test counts and skip counts.
4. Run full isolated API/database suites, rollback/concurrency/RLS tests and exact table readbacks, followed by production build/lint. A filtered success is a bounded pass, never the full gate.
5. Run actual-browser user journeys by role and every required variant, including stale pages, same-value events, null/blank/zero, cross-year sources, imports, exceptional workflows and lost acknowledgement.
6. Replay independent desktop cases and compare complete business effects, reopen UI and documents/reports. Retain missing/extra rows and failed cases; never update expected outputs simply because the web differs.
7. Complete physical device/printing/provider sandbox and authorized production qualification, migration shadow runs, recovery/cutover rehearsals and full business-day UAT with accountant/store-owner sign-off.
8. Seal a single current candidate record only if every required descendant requirement and exact evidence set is complete. All existing bounded prerequisites remain credited, but outstanding or contained required workflows prevent the full-product parity claim.
