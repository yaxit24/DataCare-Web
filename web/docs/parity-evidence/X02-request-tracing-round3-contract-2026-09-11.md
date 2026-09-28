# X02 extended-cell request tracing, round 3

Date: 2026-09-11. This is a correction and extension to a bounded static audit, not a claim of persisted-value equality, desktop workflow parity or full UI descriptor coverage. No dead-cell baseline, suppression or field allowlist was added.

## The four previous findings

The old `scripts/check-dead-cells.mjs` concatenated a configured writer module and its first-level relative imports, then searched raw source text for `.field`. It reported wholesale `issueYear`, `issueBook`, `issueNo`, and `issueSrno` because the request deliberately renames and nests them. Comments or unused reads could also satisfy that text check. The script promised to report unmapped pages but only iterated its configured map.

The real route and write path were inspected independently of the scanner:

| UI field    | Posted path           | Actual persisted column |
| ----------- | --------------------- | ----------------------- |
| `issueYear` | `lines[].isuRef.yrcd` | `RATE_CUT_ISU.ISU_YRCD` |
| `issueBook` | `lines[].isuRef.dbcd` | `RATE_CUT_ISU.ISU_DBCD` |
| `issueNo`   | `lines[].isuRef.no`   | `RATE_CUT_ISU.ISU_NO`   |
| `issueSrno` | `lines[].isuRef.srno` | `RATE_CUT_ISU.ISU_SRNO` |

`apps/web/app/(app)/txn/wholesale-sale/page.tsx:246–304` builds the conditional `sourceRef` object from each line, places it under `isuRef`, and posts the body to `/rate-cut`. This is not a direct-property contract.

`apps/api/src/routes/txn.ts:677` defines the body helper from `req.body`. Its `rateCutInput` helper at line 721 forwards `b.lines`; POST `/rate-cut` at line 6553 calls the imported `postRateCut` with that helper's result. The AST test resolves these local helpers rather than treating a function called `body` as automatically trustworthy.

`apps/api/src/modules/sales/rateCut.ts:765–829` maps `input.lines`, binds `ref = l.isuRef ?? {}`, and constructs the four `ISU_*` columns. `writeRateCut` preserves input lines in `normalizedInput` at line 1284. The `postVoucherTx` write-set at lines 1469–1489 inserts `buildLineRows(...)` into `RATE_CUT_ISU`. Exported `postRateCut` at line 1509 calls that writer. The analogous received-row projection does not substitute for issued-line evidence; matching the same leaf under `receivedLines[]` is insufficient.

The scanner's emitted evidence pins the exact current line numbers and selected exported writer. The source hashes are recorded separately in the run manifest, since unrelated work in the shared route file can move line numbers.

## Implemented scanner behavior

New `scripts/lib/request-field-trace.mjs` uses the TypeScript parser and lexical symbol resolution. It does not execute source code or access business data.

For existing directly named fields, it records used runtime property reads, including static string property keys. It excludes interfaces, type-only/import syntax, comments, unused variable/object initializers and uncalled local functions. It retains per-file lexical bindings instead of concatenating text into a shared scope. The original one-level relative module traversal remains bounded.

When direct consumption is absent, nested tracing requires all of the following:

1. A field value must occur in the actual body argument of a literal `post`, `put` or `patch` call. Unused mappings and condition-only mentions do not become sent values.
2. Local variable aliases, conditional values, object properties, array map callbacks, safe scalar conversions and local helper returns establish the posted object path. A later static property assignment replaces earlier provenance.
3. The matching HTTP method and literal endpoint must call a runtime import from the selected API module. Imported function aliases retain the actual exported function identity.
4. The route must forward the field path from the request body, including through a local input builder. Dropping `lines` or routing to another module breaks the proof.
5. An alias-expanded writer read must match the whole forwarded path, including the collection. The read must be reachable from the export actually called by that route. An unrelated exported reader is not sufficient.

Each successful nested trace contains field, endpoint, method, posted path, called writer, forwarded path, surrounding output column and file/line provenance. Unsupported computed keys, dynamic property access, opaque object transformations and dynamic endpoints are explicit diagnostics. An unresolved field remains a failing audit result; unsupported syntax never becomes presumed live.

The script now also enumerates transaction-page directories and checks for unmatched `extendedLineFields` registries. This exposed three existing omissions:

- `consi-purchase`: `/consignment-purchases` calls `createPurchase` from `purchase/purchase.ts`.
- `purchase-quotation`: `/purchase-quotations` calls `createPurchaseQuotation` from `purchase/purchase.ts`.
- `sales-quotation`: `/sales-quotations` calls `createSalesQuotation` from `sales/sales.ts`.

These factual page-to-module mappings add 106 already-existing columns to the audit. No product writer was changed to manufacture a pass. Final coverage is **712 columns on 21 pages with matching registries, within 23 configured page mappings**, with **0 dead and 0 unmapped findings**. The prior 606-column audit described 20 mappings, including two pages without this inline registry pattern. The new JSON reports actual audited pages and configured mappings separately.

## Verification

`node --test scripts/test/request-field-trace.test.mjs` passes 14 tests, covering:

- Conditional nested aliases through the real input helper to the output column.
- Type/interface/comment mentions, unused declarations and uncalled local functions remaining inert.
- Unused request objects and condition-only values not being posted.
- Static overwritten request values losing their old provenance.
- Dropped routes, wrong endpoints, wrong imported modules and non-forwarding request helpers failing.
- Imported writer aliases preserving exported identity.
- Same leaf under the wrong collection failing.
- Changed nested property or unrelated exported reader failing.
- Computed output keys, dynamic writer keys and dynamic endpoints remaining explicit unsupported cases.
- Lexical shadowing not borrowing another function's alias.
- All four real wholesale fields reaching the actual `/rate-cut` writer and the correct `ISU_*` column.

`node scripts/check-dead-cells.mjs --json` produces the new round 3 trace artifact. Focused ESLint passes for the scanner and its tests. The final manifest pins source, tests and captured output; this slice does not need database fixtures because it changes only the static scanner.

## Limits that remain open

Direct reads remain **consumption evidence**, not proof that a field reaches a database column. Validation, a calculator or another used runtime expression can consume a value. Even a nested trace establishes a possible source path; it does not prove every conditional branch persists, preserves precision, passes authorization or round-trips unchanged.

The audit still starts from the specific inline `extendedLineFields` registry pattern. It is not the full UI descriptor scanner, a complete route inventory, a proof of absence of dead cells in every form, or a substitute for the X02 descriptor/source/report acceptance matrix. Registry extraction is still bounded and is not expanded here to imported factories or all JSX.

Imported object-transform helpers, runtime computed keys, arbitrary mutation/assignment flow, object-spread overwrite combinations, reflection, runtime dispatch, aliases spanning unrelated modules and general JavaScript control flow are not fully modeled. Local function reachability is syntactic and condition-insensitive. One-level direct-read import traversal can include exported code not reached by a particular transaction route; only the nested fallback is anchored to the route's selected export. Therefore the CLI explicitly describes static writer-consumption evidence and never prints a runtime-parity claim.

Future scanner expansion should add executable counterexample fixtures before widening a supported branch. Do not replace unresolved cases with a baseline increase or field-name exception. Final desktop-to-web verification still requires actual scoped requests, persisted row assertions and browser workflow evidence.
