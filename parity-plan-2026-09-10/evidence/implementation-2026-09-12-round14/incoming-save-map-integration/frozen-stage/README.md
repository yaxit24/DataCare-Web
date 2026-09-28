# Round14 staged incoming save-map prerequisite

Ready for parent integration/review, with **no active workspace edits**. The new module maps58 source-owned incoming row fields and proposes only exact changed OTH_AMT/TOT_AMT/NET_AMT values. It retains the whole saved raw observation, reports unowned text/format differences, and refuses omission, renumbering, instance allocation, identity/type disagreement, unowned numeric changes and unsupported numeric/storage forms. Every outcome has `canCommit:false`.

Integrate only these three new files:

- `web/packages/core/src/saleReturnIncomingSaveProjection.ts`
- `web/packages/core/test/saleReturnIncomingSaveProjection.test.ts`
- `web/packages/core/test/fixtures/saleReturnIncomingSave.independent.json`

Root owns any index export and combined regressions. The staged package/config/node_modules links are local verification scaffolding and must not be copied. Proposed public exports are `projectSaleReturnIncomingSave`, `SALE_RETURN_INCOMING_SAVE_VERSION`, `SALE_RETURN_INCOMING_SAVE_PROFILE` and the named input/result/diagnostic/field/raw/patch/difference/branches types. The input is unknown at the runtime boundary; complete source maps and candidate patches are diagnostic data, never a complete database row.

`fixture-freeze.json` proves that the26 full literal cases were written before the new implementation existed. Every case carries complete raw and63 visible fields plus58 explicit expected target values. `author-fixture.py` copies independently entered literals and explicit overrides; it imports no TypeScript code and refuses rerun after source creation. Source citations and the mandatory stock erratum are pinned by `source-inputs.json`. These fixtures test mapping of supplied candidate poststates; they do not prove an event calculated that state, source Save accepted it, or a PostgreSQL effect row exists. In particular the large instance test preserves an exact supplied identity without asserting that Float stored that decimal, and the0.49 row case deliberately retains final whole-unit bill/save validation as unresolved.

Actual staged verification:

| Check | Result |
| --- | --- |
| First new pure suite |63/63 passed,27ms |
| First strict source/test compile |Failed only at result-base version literal widening; retained `types-first.txt` |
| Correction |Explicit `ResultBase` return annotation; no runtime behavior or fixture changes |
| Final new pure suite |63/63 passed,29ms;232ms complete run |
| Final strict source/test compile |Passed with strict, noUncheckedIndexedAccess, isolatedModules, ES2022, ESNext/Bundler; skipLibCheck retained |
| Final direct input proof |Five staged files unchanged across both final checks |

Exact commands, UTC intervals, log hashes and input manifest appear in `focused-final.run.json`. No API/globalSetup, database, browser, active production build, full core suite or shared helper was executed or modified by this task. `source-inputs.json` was also rehashed unchanged after these checks. The original fixture remains SHA256 `b6aae6e4add413b768f306703d16072999ac00a48ba779515b83346de4aeed50`.

The current profile intentionally refuses unowned numeric differences caused by saved display precision loss or row recalculation; wider ownership is future work. It reports and preserves unowned text differences such as NULL description→master display name and blank TAG_LBR_CODE→fallback display code. It does not interpret unchanged/empty row patch as an effect or physical no-op and never skips the required actual c27 replay.

Required next work remains explicit on every result: fresh session/Update/document/dependency/save guards; trusted c27-only replay and whole-document poststate validation; complete stock/ledger/Rojmel/tax/outstanding/remark/BAR effect ownership; header Float and effect storage qualification; one Serializable atomic writer and postconditions. Source TAG_NO=N is nonblank and may enter BAR save branches, so current preview's BAR absence restriction is an unresolved admission/effect gap, not proof of no effects. Stock identity is SR_NO2/ISR_NO=incoming SR_NO; no SR_REC_ISU field is introduced. VCH_TIME, user/employee and scope/header context stay raw and are not reconstructed. Known mode/closing remains unavailable; no inference or new authority is added.

This is a pure prerequisite for a finite saved numeric writer. It does not implement an endpoint, DML, effect builder or complete X13/desktop parity.
