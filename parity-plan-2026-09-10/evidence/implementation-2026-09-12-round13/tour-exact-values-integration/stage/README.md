# Tour saved exact-value stage

Status: staged only. No active application files were changed by this stage, and no unit, compiler, database or browser process was run. Lightweight formatting and static schema/source comparisons were completed. The 16 literal cases were frozen before implementation and remain byte-identical in both test fixture copies.

## Integration

Apply `staged/tour-exact-runtime.patch` to the baseline pinned in `baseline-inputs.json`, or copy the three corresponding runtime files after checking those baselines. Copy the new API/web tests and their dedicated fixture files from `staged/web`. Apply the **separate** `historical-refusal-correction/order-family-exact-read.patch` only after the runtime change; its original 34-case file and original SHA remain preserved. There are no route or admission-policy edits in this stage.

The API diff enables the existing exact input-shaped projection for Tour. Everything outside that read block is byte-identical to the integrated five-adoption baseline; the inner projection body is identical after one indentation level is removed. The saved form retains a detached original document and binds exact scalar restoration to its version, parent SR and child ISR. Restoration copies only existing owned scalar fields. Changed ordinary decimal editor strings reach the existing writer without intermediate browser rounding. Four-argument calls, including new Tour creation and the Sales wrapper, retain the original serializer behavior.

## Verification to run after integration

From `/Users/yakshitsavaliya/Desktop/imodule-extracted/web`, under the root's exclusive execution lease:

```sh
pnpm --filter @datacare/web exec vitest run test/tourOrderExactValues.test.ts test/tourOrderForm.test.ts test/salesOrderForm.test.ts
node scripts/parity-test-env.mjs -- pnpm --filter @datacare/api exec vitest run test/tourOrderExactValues.db.test.ts test/orderSessionCommands.db.test.ts test/tourOrderHydration.db.test.ts
```

New declarations: **19 web cases + 8 DB cases**. The corrected historical family file still declares **34 cases**. All are unexecuted in this stage. The DB fixture uses only dedicated `tour-exact-values`/`tour-exact-foreign` tenants and configured E13/E14 books, requires the wrapper's isolated port 55433 and app_user, and cleans only those tenants. It seeds ordinary calculation values through the actual service, then imports huge auxiliary MRP/KR rates and nullable scalar distinctions through owner SQL. GET/refusal snapshots include raw SQL strings plus physical revisions/locators across 20 business/config/session tables; successful edits compare all 11 scoped business tables, excluding only replacement row IDs. Separate sibling-book, foreign-tenant and protected-table physical snapshots must remain unchanged.

The DB expectations distinguish unchanged exact MRP from a changed unrepresentable decimal (refused), a supported 25.50 replacement, and a legacy rounded-number request (still refused). Advance-only 25→40 expects exactly the existing balanced advance legs and Rojmel footprint while preserving raw parents/children/hidden fields and six-digit clock. No source financial formula or dirty-field policy is changed. The new DB test calls real internal services; it does not itself prove mounted HTTP session admission. The corrected existing guarded-entry case and the separately owned actual browser journey cover the participating paths after execution.

## Evidence limits

This fixes the saved input-shaped round trip for supported mapped values; it does not claim a universal lossless raw DTO, new-create decimal support, arbitrary fractional/unsafe SR identity support, exact display aggregates, or changed dirty-field semantics. Existing writer refusal remains authoritative for unsupported edits. Auxiliary NULL/zero preservation does not establish that a NULL calculation basis can be safely recalculated. The old historical refusal stage was truthful for its old rounded read path; this separate correction changes that one premise and keeps its financial/identity assertions. The new test independently retains rounded-input refusal coverage.

Peer Design owns `/tmp/datacare-tour-exact-browser`, including the actual Tour UI saved-load/unchanged-save/advance-save check and a separate ready manifest. No browser acceptance is credited here.
