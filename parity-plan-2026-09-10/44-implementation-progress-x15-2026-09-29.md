# Implementation progress — X15 E CRNT lifecycle, 29 September 2026

Implementation resumed on the user's direction after the Round 15 pause. This round takes queue item 5 of [the execution addendum](12-execution-addendum.md#execution-order-and-concrete-first-slices): **X15, the dedicated E CRNT create/edit/delete/read/document lifecycle**. The paused Round 15 Return work (document 42) is unchanged; checkpoint 43 is still unsealed and checkpoint 41 remains the latest sealed record. Nothing in this round closes X15, a package or a menu acceptance.

## What was implemented

| Layer | Change |
| --- | --- |
| Source contract | [ecrnt-lifecycle-contract.md](evidence/implementation-2026-09-29-x15/ecrnt-lifecycle-contract.md): TR_SL_EBILL save/delete/validation order, the E CRNT branches of `Ac_Ledr.EInvoice_Ledr`, `Ac_Rojmel.EInvoice_Rojmel`, `Ac_Stock.EInvoice_Stk`, `Ac_Tax.EInvoice_GST`, and six explicit web adaptations. Written before the writer. |
| Arithmetic | `web/packages/core/src/eCreditNoteCalc.ts`: CommPassTotal line maths (weights, fine, rate types P/1/K/gram, labour G/N/K/P with LBR_WITH_GHT, MRP, GST split with TAX_ROF, half-even whole-rupee line net) and BILL_TOTAL (round-off, TDS, Bill OS). Hand-derived vectors in `test/fixtures/eCreditNoteCalc.vectors.json`; a deliberate half-up mutation was confirmed to fail. |
| Writer | `web/apps/api/src/modules/einvoice/creditNoteWriter.ts`: one transaction per save/delete, book/slot/master/tax validation in desktop order, SL_DATA/SL_DETL/SL_IDTL/TEMP_BOOK_DATA/AC_DATA/ROJ_MEL_DATA/MAIN_STOCK/TAX_DATA write set, balanced-ledger assertion, identity-preserving edit (VCH_NO, HD_VCH_NO, VCH_TIME, MAIN_USER), component rows kept by OLD_SRNO, DELETE_DATA audit, IRN edit/delete lock, and a revision fingerprint that refuses a stale edit or delete with 409. Not routed through Sale Return. |
| Kernel | `shared/postingAccounts.resolveBookSlotRowsTx` returns fail-closed BOOK_DETL slot rows with the per-slot metadata the E-invoice helpers post; the writer uses core `round`. Kernel-conformance ceilings are unchanged. |
| HTTP | `GET /e-credit-notes/entry-config`, `GET /e-credit-notes/:vchNo/entry`, `POST /e-credit-notes`, `PUT/DELETE /e-credit-notes/:vchNo`, `GET /e-credit-notes/:vchNo/print` (SalesBillA4Gst-style, O/D copy captions), `POST /e-credit-notes/:vchNo/irn/cancel`, all under `Transaction/E CrntNote` rights. |
| UI | `/txn/e-crnt-note` keeps the saved-document browser and IRN action and adds a full entry form: party lookup with GST type, line grid with keyboard navigation and live core-calculated amounts, tender fields, totals, save/update, delete, print original/duplicate, IRN cancel and "Edit in entry form" from the saved view. |

## Verification actually run (disposable PostgreSQL 16, app_user with forced RLS)

- API: 273 files / 3,171 tests passed, including 9 writer DB tests with independent expected rows, 2 HTTP lifecycle/rights tests, route policy (563 routes), release certification and kernel conformance.
- Core: 27 files / 1,629 tests. Web: 37 Vitest files / 526 tests plus 6 Node tests.
- Strict test typecheck, workspace lint, `pnpm build` and Prettier passed.
- Real browser: `parity.real-stack.mjs` passed all **18** journeys with zero mocked requests ([result](evidence/implementation-2026-09-29-x15/real-stack-result.json)); the new `credit-note-entry` journey creates, prints, edits, reopens after reload and deletes a credit note through the UI alone and checks the stored rows after each step. The required real-browser journey set in `releaseCertification.ts` now contains 18 ids.

Environment note: the sandbox blocks TCP on port 55433 and has no compose provider, so the run used a local mirror of `scripts/parity-test-env.mjs` (same migrations, `rls.sql`, `setup_roles.sql` and verification query) with the connection URLs pointed at `127.0.0.1:55433` through the PostgreSQL unix socket. Repository scripts were not changed.

## Still open for X15

- Independent desktop capture of the same vouchers (write set and SalesBillA4Gst layout); these results are engineering evidence on synthetic fixtures.
- Business acceptance of the six documented adaptations, above all the balanced negative round-off and the IRN edit lock.
- Tagged-line stock return, TCS/TDS, amount overrides that back-compute rates, `Vch_Remark` REMARK_DATA, and the full cross-year LedrCash aggregate.
- Live GSP state: timeout-after-acceptance, retry and cancel against the real provider (X28).
- The corresponding E INVOICE mode of the same form (mirrored signs, DM_DATA and round-off rows).
