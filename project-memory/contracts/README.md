# Per-form behavior contracts

A contract is the **approved translation of one desktop form into web-implementable rules**. It is the
G2 ("understood") gate evidence in `project-memory/parity/DESKTOP-WEB-PARITY-MATRIX.*`.

## Rules

1. File name must be exactly `<FORM_ID>.contract.md`, using the desktop form id (e.g. `TR_SALE.contract.md`).
2. Every rule must cite the desktop source with file and line (`TR_SALE.cs:14233`). No rule may be inferred
   from the web implementation, from a report, or from assumption.
3. The generator counts a contract toward G2 **only** when the file contains a line exactly:

   ```
   Status: approved
   ```

   A draft contract is listed as evidence but leaves the gate `in_progress`. This makes drafting safe and
   makes inflation impossible.
4. If desktop behavior is genuinely ambiguous, record it under **Open questions** and keep the file a draft.
   Ambiguity is never resolved by guessing.
5. If a desktop behavior is intentionally not reproduced, record it under **Accepted divergences** with the
   user-visible consequence. Silent divergence is a G5 failure.

## Required sections

```markdown
# <FORM_ID> — <desktop title>

Status: draft | approved
Desktop source: unified/src/csharp/DataCareNext/<FORM_ID>.cs (<LOC> lines)
Authoritative build: <which shipped binary/version this was read from>
Web surface: <pages> / <API routes> / <modules>

## 1. Book and scope
MAIN_BOOK / BOOK_TBL_NAME / VCH_TYPE / INOUT / DATA_TYPE, company/location/year/book resolution,
period-lock and fiscal-year rules.

## 2. Header fields
Field, desktop control, source line, type/length, required, default, read-only conditions.

## 3. Grid columns
Ordered column list with type, editability, and per-column validation.

## 4. Focus and keyboard
Tab order, Enter/Escape/Ctrl+D behavior, F-key actions with the desktop handler line.

## 5. Calculations
Each formula with its exact desktop expression, rounding, and order of evaluation.

## 6. Validations
Condition → exact desktop message text → whether it blocks save.

## 7. Write set (ordered)
Table → columns written → value source. Include TEMP_BOOK_DATA, REMARK_DATA, audit and stock/ledger legs.

## 8. Edit semantics
What is preserved on re-save (MAIN_USER, VCH_TIME, hidden number), what is deleted and rewritten,
whether editing writes DELETE_DATA.

## 9. Delete/reversal semantics
Audit rows produced, satellite cleanup, flags restored, lock checks.

## 10. Reports/documents
Which `.rpt` the form prints and with which parameters.

## 11. Settings that fork behavior
CO_SET / config flags read by this form and the branch each one takes.

## 12. Open questions
## 13. Accepted divergences
```

## Verification expectation

A contract is only useful if it is testable. Each numbered rule should be traceable to at least one test
(pure kernel vector, restricted-role database lifecycle test, route-policy assertion, or browser assertion)
once the form is implemented.
