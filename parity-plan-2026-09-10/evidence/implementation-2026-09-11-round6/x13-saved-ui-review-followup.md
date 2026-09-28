# X13 round6 review follow-up: saved-name diagnostics and date containment

Root approved this bounded correction after the independent review. The earlier `x13-saved-ui-api-review.md` remains unchanged as the dated finding, SHA-256 `619ace198d4e1d2dabe1d2935822b79e7e7c7b337236f3246e1cfd0bd06a23bc`. This follow-up records the corrective implementation without rewriting that history.

## Corrected behavior

The API now returns required nullable `line.display.itemNameReason` and `header.display.employeeNameReason`. Exactly one matching master row resolves its name; multiple rows remain ambiguous even if their labels happen to match. Missing or ambiguous item lookup has an explicit reason, independently of whether the saved raw item description is nonempty. Empty saved employee identity has no missing-name warning; a nonempty missing or ambiguous identity does. The service preserves all raw business values and existing metadata capabilities.

The saved screen shows each item reason beside Receive Item and the employee reason beside Header employee. Item reasons are linked to their input through aria-describedby and wrap within the existing scrollable grid. Stable conditional IDs are `sale-return-saved-item-name-reason-{srNo}` and `sale-return-saved-employee-name-reason`. The UI observation validator requires both reason fields as string or null and rejects a malformed/missing reason before enabling editing.

These display reasons never become metadata changes or permission decisions. Unchanged missing/ambiguous display information emits no patch. A HUID-only edit still sends only that field with the six exact saved identity values; NULL description and existing employee values remain unchanged. A denied employee field stays denied even if a display reason is present.

The API owner also added a strict saved VCH_DATE calendar check before the shared period-lock helper's early return. A non-YYYY-MM-DD date (including PostgreSQL infinity) or invalid calendar date produces a read-only capability reason. The temporary Date is a validator only; saved raw dates/timestamps are not reconstructed or written. Independent source inspection confirms this guard now precedes assertPeriodOpen. API fixture execution and final whole-workspace acceptance are owned by the API/root agents, not claimed by this UI follow-up.

## Focused verification

- `pnpm --filter @datacare/web test -- test/salesReturnForm.test.ts`:1 file31 tests passed. Five new tests prove diagnostic/raw/patch preservation and rejection of missing/malformed item/employee reasons.
- Focused ESLint on the helper, panel and tests:exit0.
- `pnpm --filter @datacare/web typecheck`:exit0.

All three processes finished before root was told the UI source was frozen for a fresh build/browser run. No database or browser run was started by this owner. The earlier successful whole-browser run used the pre-diagnostic build and must not be presented as verification of these later visible reasons. Root's subsequent final browser/build evidence must be linked separately.

No new calculation, source import, tag admission, companion remapping, deletion, print or financial behavior is implemented by this fix. The full X13/33-field and desktop acceptance boundaries remain open.

## Follow-up snapshot

Captured UTC: 2026-09-11T08:15:45.812965+00:00

| Path relative to web | SHA-256 |
| --- | --- |
| `apps/api/src/modules/sales/savedSaleReturn.ts` | `b8f71641540d464de45b1a63b4c9fd584a9d31f7df444b1d155945caf944c622` |
| `apps/web/lib/salesReturnForm.ts` | `062386988f070b3a828238a594272407a8d3de49be24dc17de9703b0c244aeda` |
| `apps/web/components/SaleReturnSavedPanel.tsx` | `353b0e92f8859acc5f15e1a42b0c0216555fac0c987588d0cf8185cfc46ab99b` |
| `apps/web/test/salesReturnForm.test.ts` | `7c81ac061f99315bfec417dab5026df8d1f81905cb320ec68b67ec1c0b01b0e9` |

| Focused log in round6 | SHA-256 |
| --- | --- |
| `x13-saved-ui-tests-diagnostics.txt` | `6db1cb999fa88f6245f81257898cfc8a5d561a2966bec45ee9a742fea15fbc24` |
| `x13-saved-ui-lint-diagnostics.txt` | `e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855` |
| `x13-saved-ui-types-diagnostics.txt` | `c04e30f07ee75678ce89d0a71be3ce6157ac20636152fb2c42a55c48c6209b1b` |
