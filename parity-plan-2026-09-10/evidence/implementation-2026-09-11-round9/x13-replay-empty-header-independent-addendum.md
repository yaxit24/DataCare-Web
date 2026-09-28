# X13 empty saved header: independent review addendum

Status: final independent read-only review of the narrow empty-header inspection correction, after its focused service/HTTP regression passed. This is separate from the frozen `x13-replay-independent-review.md` and its 33-input record; neither earlier file was changed. The reviewer ran no database, browser, compiler or product tests and changed no product/test file. The service owner ran the focused tests described below; this note attributes that result rather than presenting it as a reviewer-run test.

The original replay review remains an accurate description of its tested source stage. A later real browser run reached a legitimate saved header with no `SL_DETL_RTN` rows and exposed an API/UI contract mismatch: the existing raw reader threw 422 before the intended empty replay state could be returned. This addendum must not relabel the earlier focused pass as verification of the changed source.

## Boundary inspected

`savedSaleReturn.ts` now establishes an `emptyIncomingReason` after the same scoped header and companion-table observations. Only the unlocked read path is allowed to continue. The locked metadata path still throws `SavedSaleReturnError(422, 'unsupported-state', ...)` before obtaining any writable patch target or issuing an update. The correction does not call the destructive legacy Return writer, allocate a voucher, create a row, normalize a number, or broaden numeric admission.

The unlocked read carries the reason through `editReason`, the header employee capability and the document's domain capabilities. With no incoming rows, there are no line capabilities to permit an edit, and `employeeReason` is non-null; consequently domain `capabilities.canUpdate` is false. The route's separate top-level `canUpdate` still describes the operator's form right. A granted form right alone does not override the domain capability. The existing UI combines those authorities.

Existing full-scope configured-book validation, unique-header check, period observation, raw SQL text projection, companion observations and version inputs remain in place. A nonempty document sets `emptyIncomingReason=null`; the existing business restrictions and version construction are otherwise unchanged. The observation still includes the physical header and all scoped companion rows, so inserting a real incoming row changes the document and replay versions. No durable history of an entirely absent row is claimed.

`saleReturnIncomingReplay.ts` needs no new calculation branch: the empty reader yields no lines; SQL ordering and matching-master discovery return no incoming targets; projection is never called; the state map and returned `rows` are empty; `rows.some(...)` yields `canPreview=false`, and `canSaveNumeric` remains false. The embedded configured snapshot and scoped version remain available for inspection. A fabricated row identity cannot create a row: the POST's existing exact identity lookup returns 409. A changed document/configuration still fails the prior composite token comparison.

The scoped incoming GET and replay GET retain their view rights and `Cache-Control: no-store`. The metadata PUT retains update authorization in addition to the service's locked refusal; replay POST remains a view-authorized, nonpersisting operation. No route shape or permission mapping is widened by this helper change.

The web response validator explicitly allows `rows=[]` only when `canPreview=false`, requires the replay row count to match the selected saved document, and verifies document/scope/configuration identity. `SaleReturnReplayPanel` displays `sale-return-replay-empty` and does not render row numeric controls for an empty observation. Existing scope/generation/request guards remain unchanged. No successful numerical preview or save is inferred from seeing an empty state.

The existing `incoming-recent` list continues to require an incoming row. This patch adds explicit saved-header inspection; it does not claim a broader empty-header listing workflow. A missing header still returns not-found, and an ambiguous header remains unsupported. Retaining these distinctions avoids turning an absent document into an editable empty draft.

## Review outcome and verification attribution

No concrete mutation, token, capability or empty-state response defect was found in the landed narrow correction. This is a bounded static conclusion; the service owner's dedicated real service/HTTP tests and root's final regression are separate evidence. In particular, complete row numeric persistence, outgoing exchange admission, totals, tenders, stock and financial writes remain open.

The service owner’s coordinated disposable-database run passed **5 files / 96 tests / zero skips in 17.59s**, recorded in `replay-empty-header-focused-first.txt`: 6 new empty-header cases, 26 saved-reader service cases, 9 saved-reader HTTP cases, 43 replay service cases and 12 replay HTTP cases. The reviewer inspected the completed log. The owner reported no source/test changes during that run; the final hashes of the narrowed helper and dedicated test file match the owner’s pre-run notices. This is a scoped regression result, not the later full-suite/build/strict-compiler/browser result.

The six new tests were read independently and exercise exact large-decimal/NULL/microsecond header preservation; domain and employee capability refusal; fresh valid employee metadata patches at both service and authenticated HTTP boundaries; actual View/Edit GETs with no-store; guessed 64-character hex replay identity refusal; existing related component visibility; nonempty sibling version stability; real incoming-row insertion invalidating the earlier replay token before identity/projection; and missing-header 404. Their before/after comparisons include physical revisions and business rows for 24 tables in both isolated fixture tenants, so the no-write checks are more than assertions about the HTTP response. The other tenant and sibling fixtures do not substitute for the broader existing authorization suite; this change did not modify that authorization boundary.

The historical browser failure and earlier 192-test focused source stage remain preserved. No new successful browser or compiler result is credited in this addendum; root’s final integrated checks remain separately owned. The `first` suffix on the focused log is retained because it is the actual successful first run for this dedicated stage, not a renamed result.


## Pinned review inputs

Paths are relative to `Desktop/imodule-extracted`. These are the final inspected references, captured after the focused run; they are not a new before-run snapshot of all executed inputs. Frozen earlier review hashes remain byte-identical.

| Input | SHA256 |
| --- | --- |
| `web/apps/api/src/modules/sales/savedSaleReturn.ts` | `f23c529ea4ea7003e5d6f553e03d4f596beb3914be24076d6a16ea26eeafffec` |
| `web/apps/api/src/modules/sales/saleReturnIncomingReplay.ts` | `69a8e90c32258e756e8294dd3c8ebb5aeb185d64fb567e1fcf03b74f7e8f4190` |
| `web/apps/api/src/routes/txn.ts` | `a925b7fe7a43207e53deee7f34eaee179a3bf9341bea9b3f8b15874d7fda4669` |
| `web/apps/web/lib/salesReturnReplay.ts` | `60093c4f2a0ded2a675c68496c958b5c62dfd24b526dc346c4183e3d9dc6a1ef` |
| `web/apps/web/components/SaleReturnReplayPanel.tsx` | `dac7ad2c31fecba31eab712184c06db2f8c5fe35ffadd435728dee9edda930b7` |
| `web/apps/api/test/savedSaleReturnEmpty.db.test.ts` | `9804e6e7f406b040fd197dc31dd9cf4bfbe73fb5aa84e0aa1ef74e60c2b7eaff` |
| `parity-plan-2026-09-10/evidence/implementation-2026-09-11-round9/replay-empty-header-focused-first.txt` | `1413f721d348c9e67020508e10501c4ce023d9746efab8df77d7d41aee08f9a4` |
| `parity-plan-2026-09-10/evidence/implementation-2026-09-11-round9/x13-replay-independent-review.md` | `c1073a04da894695afe960446f4fbede71e78ff65ed411a54c7abbc4198de3c4` |
| `parity-plan-2026-09-10/evidence/implementation-2026-09-11-round9/x13-replay-independent-review-inputs.json` | `55274b22220ba192738a92ed54973e771d7d7ffff36e4a1bb41efe97352afd0e` |
