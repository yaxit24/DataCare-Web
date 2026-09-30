# Implementation progress — X15 TR_SL_EBILL (E CRNT and E INVOICE), 29 September 2026

Implementation resumed on the user's direction after the Round 15 pause. This round takes queue item 5 of [the execution addendum](12-execution-addendum.md#execution-order-and-concrete-first-slices): **X15, the dedicated E CRNT create/edit/delete/read/document lifecycle**. The paused Round 15 Return work (document 42) is unchanged; checkpoint 43 is still unsealed and checkpoint 41 remains the latest sealed record. Nothing in this round closes X15, a package or a menu acceptance.

## What was implemented

| Layer | Change |
| --- | --- |
| Source contract | [ecrnt-lifecycle-contract.md](evidence/implementation-2026-09-29-x15/ecrnt-lifecycle-contract.md): TR_SL_EBILL save/delete/validation order, the E CRNT branches of `Ac_Ledr.EInvoice_Ledr`, `Ac_Rojmel.EInvoice_Rojmel`, `Ac_Stock.EInvoice_Stk`, `Ac_Tax.EInvoice_GST`, and six explicit web adaptations. Written before the writer. |
| Arithmetic | `web/packages/core/src/eBillCalc.ts` (first written as `eCreditNoteCalc.ts`): CommPassTotal line maths (weights, fine, rate types P/1/K/gram, labour G/N/K/P with LBR_WITH_GHT, MRP, GST split with TAX_ROF, half-even whole-rupee line net) and BILL_TOTAL (round-off, TDS, Bill OS). Hand-derived vectors in `test/fixtures/eBillCalc.vectors.json`; a deliberate half-up mutation was confirmed to fail. |
| Writer | `web/apps/api/src/modules/einvoice/eBillWriter.ts` (first written as `creditNoteWriter.ts`): one transaction per save/delete, book/slot/master/tax validation in desktop order, SL_DATA/SL_DETL/SL_IDTL/TEMP_BOOK_DATA/AC_DATA/ROJ_MEL_DATA/MAIN_STOCK/TAX_DATA write set, balanced-ledger assertion, identity-preserving edit (VCH_NO, HD_VCH_NO, VCH_TIME, MAIN_USER), component rows kept by OLD_SRNO, DELETE_DATA audit, IRN edit/delete lock, and a revision fingerprint that refuses a stale edit or delete with 409. Not routed through Sale Return. |
| Kernel | `shared/postingAccounts.resolveBookSlotRowsTx` returns fail-closed BOOK_DETL slot rows with the per-slot metadata the E-invoice helpers post; the writer uses core `round`. Kernel-conformance ceilings are unchanged. |
| HTTP | `GET /e-credit-notes/entry-config`, `GET /e-credit-notes/:vchNo/entry`, `POST /e-credit-notes`, `PUT/DELETE /e-credit-notes/:vchNo`, `GET /e-credit-notes/:vchNo/print` (SalesBillA4Gst-style, O/D copy captions), `POST /e-credit-notes/:vchNo/irn/cancel`, all under `Transaction/E CrntNote` rights. |
| UI | `/txn/e-crnt-note` (now through the shared `components/EBillEntry.tsx`) keeps the saved-document browser and IRN action and adds a full entry form: party lookup with GST type, line grid with keyboard navigation and live core-calculated amounts, tender fields, totals, save/update, delete, print original/duplicate, IRN cancel and "Edit in entry form" from the saved view. |

## Continuation: the E INVOICE mode of the same form

The desktop `E Invoice` menu opens the same `TR_SL_EBILL` on an outward `E INVOICE` book. Before this round the web mapped that menu only to the IRN utility; there was no e-invoice entry. The continuation completes both modes of the form:

| Layer | Change |
| --- | --- |
| Contract | [E INVOICE section](evidence/implementation-2026-09-29-x15/ecrnt-lifecycle-contract.md#e-invoice-mode-of-the-same-form-continuation-29-september-2026): mirrored ledger/rojmel orientation, round-off rows 15/09/10, stock `S`/`-`, `TAX_SIGN '+'`, DM_DATA, the 50 lakh TCS rule (AcTcsAmt), TDS and `Vch_Remark`; hand vectors EI-1..EI-3. |
| Arithmetic | `eBillCalc.ts` (renamed from `eCreditNoteCalc.ts`) adds TCS to the totals and `eInvoiceTcs`: new-voucher threshold with headroom, the source's literal `− CGST − SGST` probe, code `00` suppression, operator codes below the threshold and the saved-voucher full-base recomputation. |
| Writer | `eBillWriter.ts` replaces the credit-note-only writer and is parameterised by family. E INVOICE posts TCS row 04 and the TDS pair 05/06 on outward books, DM_DATA for preserved components whose item has `OTH_DETL_POSTING='Y'`, and both families now write REMARK_DATA from the narration. A second IRN is refused before any provider call. |
| HTTP / rights | `/e-invoices` browse, read, TCS basis, entry lifecycle, print, IRN and IRN cancel under a new `Transaction/E Invoice` form (desktop `USER_SET` sub-menu `E Invoice`). |
| UI | Shared `components/EBillEntry.tsx`; new `/txn/e-invoice` page with browse, TCS/TDS selection, live threshold preview from the party's year debits, Generate/Cancel IRN; `/txn/e-crnt-note` uses the same component. |

Additional adaptations 7 (row 15 debits `|ROF|`) and 8 (TCS/TDS only on outward books) are recorded in the contract.

## Verification actually run (disposable PostgreSQL 16, app_user with forced RLS)

- API: 275 files / 3,181 tests passed, including 9 E CRNT and 6 E INVOICE writer DB tests with independent expected rows (EI-1 write set, EI-2 TCS threshold and full-base edit, EI-3 negative round-off, DM_DATA, refusals), 4 HTTP lifecycle/rights/IRN tests, route policy (574 routes), release certification and kernel conformance. A deliberate stock-sign mutation was confirmed to fail.
- Core: 27 files / 1,638 tests. Web: 37 Vitest files / 528 tests plus 6 Node tests; route rendering 125/125.
- Strict test typecheck, workspace lint, `pnpm build` and Prettier passed.
- Real browser: `parity.real-stack.mjs` passed all **19** journeys with zero mocked requests ([result](evidence/implementation-2026-09-29-x15/real-stack-result.json)). `credit-note-entry` creates, prints, edits, reopens and deletes a credit note; `e-invoice-entry` creates an e-invoice with TDS, generates an IRN (fake-development transport), confirms edit/delete are locked, cancels the IRN, reopens after reload and deletes it; both check the stored rows after each step. The required real-browser journey set in `releaseCertification.ts` now contains 19 ids.

Environment note: the sandbox blocks TCP on port 55433 and has no compose provider, so the run used a local mirror of `scripts/parity-test-env.mjs` (same migrations, `rls.sql`, `setup_roles.sql` and verification query) with the connection URLs pointed at `127.0.0.1:55433` through the PostgreSQL unix socket. Repository scripts were not changed.

## Still open for X15

- Independent desktop capture of the same vouchers (write set and SalesBillA4Gst layout); these results are engineering evidence on synthetic fixtures.
- Business acceptance of the six documented adaptations, above all the balanced negative round-off and the IRN edit lock.
- Tagged-line stock return, TCS/TDS, amount overrides that back-compute rates, `Vch_Remark` REMARK_DATA, and the full cross-year LedrCash aggregate.
- Live GSP state: timeout-after-acceptance, retry and cancel against the real provider (X28).
- E INVOICE tagged-line sales (BAR_DETL tag lookup), the EInvoice.RPT e-print layout, and an independent desktop comparison of the TCS threshold on real party histories.
