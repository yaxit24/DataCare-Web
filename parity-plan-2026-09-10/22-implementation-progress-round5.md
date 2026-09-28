# Implementation continuation — 11 September 2026, round 5

This continuation follows [round 4](20-implementation-progress-round4.md) and [immutable checkpoint 21](21-implementation-checkpoint-round4.json). It extends the saved-order image concurrency work to the shared Design, tag/master and repair editors. All 34 execution cards, 83 original packages and 198 complete menu acceptances remain open.

## Implemented scope

This slice implements the [image editing contract](evidence/implementation-2026-09-11-round5/image-editor-contract.md). Generic Design/tag/master and original repair image state now includes an opaque version, separate absent/unavailable/present states and current update/delete capabilities. HTTP upload and delete require that version. Atomic transactions lock the physical image revision and reject stale edits with409; identical-byte replacement, delete/recreate and recreated Design/repair parents cannot reuse an old observed version. Trusted internal legacy writes also advance revisions. Image operations preserve business parents and components. The three upload routes allow a4MB binary image after base64 expansion; modern uploads and previews decode all JPEG/PNG pixels rather than accepting only a signature.

The generic image key retains its existing physical company/location/entity/instance ownership. Required Design parents use the saved image identity. Repair state and raw reads preserve the original receipt year/book/voucher/serial independently of the current repair stage. The raw repair reader's source-book fallback was corrected after a failing route test. Permission enforcement uses the existing route owners; complete desktop rights mapping for every generic caller remains an open obligation.

The shared client binds reads, native file choices, uploads, deletes and camera work to the complete current record and scope generation. A stale upload preserves the selected file and requires an explicit read-only Reload followed by Retry. A record/scope change discards pending bytes, and A→B→A does not revive an old operation. Camera startup/capture/cleanup reject stale callbacks and release tracks. Repair Receipt now hydrates persisted serials before enabling images, records a successful save before its authoritative read, and ignores responses arriving after Cancel or a context change. Design Book advances its local image load generation after every authoritative hydrate, including an unchanged Save whose business hash stays equal while its stored parent generation changes.

These are partial X05/X25 and Repair lifecycle improvements. They do not close a whole card, package or menu. Earlier round-4 results remain attributable only to their frozen source.

The generic shared panel has 21 mount sites expanding to 30 routes, and the repair panel has two mount sites. Applying one shared controller reaches those consumers but does not prove every inherited image-key mapping or desktop workflow. The exact inventory is retained in [the client inventory](../web/docs/parity-evidence/X05-X25-generic-image-client-round5-inventory-2026-09-11.json).

## Verification on the recorded source

| Check | Actual result | Evidence |
| --- | --- | --- |
| Final complete isolated API regression |221 files,1740 tests passed;0 skips;1001 API inputs captured before execution and unchanged afterward | [final log](evidence/implementation-2026-09-11-round5/api-full-complete.txt), [input snapshot](evidence/implementation-2026-09-11-round5/api-input-snapshot-complete.json), [verification](evidence/implementation-2026-09-11-round5/api-input-verification-complete.json) |
| Web tests |23 files,137 tests passed; includes23 focused image editor/scope/camera tests | [log](evidence/implementation-2026-09-11-round5/web-tests.txt) |
| Core tests |8 files,106 tests passed | [log](evidence/implementation-2026-09-11-round5/core-tests.txt) |
| Production build / lint and application types / strict API test types |7 build targets and10 lint/type tasks passed; strict test compiler exit0 | [build](evidence/implementation-2026-09-11-round5/build.txt), [lint](evidence/implementation-2026-09-11-round5/lint.txt), [test types](evidence/implementation-2026-09-11-round5/test-types.txt) |
| Real browser/API/PostgreSQL |12 journeys passed using isolated non-owner tenant/RLS connection;0 mocked requests | [result](../web/test-results/parity-real-stack-round5-camera/result.json), [log](evidence/implementation-2026-09-11-round5/browser-camera.txt) |
| Legacy browser smoke |Passed with compatibility mocks; not credited as real-stack parity | [log](evidence/implementation-2026-09-11-round5/browser-smoke-complete.txt) |
| Static measurement tests |31 fixtures passed; no ceilings increased | [log](evidence/implementation-2026-09-11-round5/scanner-tests.txt) |
| Completion register |198 mapped/implemented-unverified menus;0 accepted | [log](evidence/implementation-2026-09-11-round5/register.txt) |

The two new real-browser journeys cover11 generic image checks and10 repair image checks. They exercise independent authenticated-client replacement, stale upload/delete refusal, explicit reload/retry, tombstones, record and book changes, unchanged full business DTOs, original receipt identity, imported serial17 rather than row position1, and Cancel during a genuinely database-delayed read. Synthetic camera video traverses the actual video/canvas/HTTP/database path and validates saved JPEG bytes. Chromium's simulated camera is not physical-device acceptance. The other10 previously established journeys also pass on this source. Fixtures and tests use the disposable Docker database on55433 and real API/web ports4410/4411; the normal application database was not used.

Scoped source and evidence manifests: [API](../web/docs/parity-evidence/X05-X25-image-cas-api-run-round5-2026-09-11.json) and [client](../web/docs/parity-evidence/X05-X25-generic-image-client-round5-run-2026-09-11.json). The broader [checkpoint23](23-implementation-checkpoint-round5.json) pins the combined final source and retained verification. Focused tests overlap the complete suite and are not added to its count.

## Failed iterations and limits retained

Earlier focused runs exposed an incorrect expected scope status, test query shadowing, and a real raw repair read using the current book instead of `imageBook`. Those were corrected before the final API run. New state routes changed the declared route count from540 to543; the registry assertion was corrected. Strict test typing exposed tuple inference errors; the types were fixed and the full API suite rerun from a new captured input snapshot. The artifacts retain these failures instead of replacing their outcomes.

The first browser run exposed a stale Design image version after an unchanged parent save. Tying image remounting only to the business hash did not solve it; a monotonically advancing hydrate generation did. A following run displayed an unavailable image once after upload. That specific observation remains unexplained: a direct full-decode/save/state diagnostic and both subsequent instrumented browser runs returned the same tiny PNG as present. No cause or separate repair is claimed for that historical observation. Keep it in image regression follow-up if it recurs. The instrumented run then exposed Chromium `getUserMedia` returning `NotSupportedError` with only the fake-device flag; a standalone local probe showed both fake-device and fake-UI flags produce a live synthetic track. The final browser run uses both and passes the unchanged capture assertions. Earlier failed run artifacts and screenshots remain pinned.

Full desktop camera/printer behavior, every caller's historical image provenance and rights, imported malformed-image recovery, complete Repair document writes, all remaining contained reports and genuine customer business workflows remain open. The current executable was not replayed in this slice.

## Release gates and next implementation

The kernel gate remains red at127 rounding helpers against108; depth remains red at102 unreachable fields against96; dead-cell analysis reports33 unresolved Sales Return controls among708 checked. These are retained implementation debt, not accepted exceptions. No threshold was raised. See [kernel](evidence/implementation-2026-09-11-round5/kernel-gate.txt), [depth](evidence/implementation-2026-09-11-round5/depth-gate.txt), and [dead cells](evidence/implementation-2026-09-11-round5/dead-cells.txt).

Next is X13 Sales Return: prove the incoming and outgoing grids separately, add exact scoped saved-document hydration and versioned metadata edits, preserve original-sale identity independently from the return, then implement the source calculation sequence and coordinated incoming tag admission/consumption/reversal. The current generic numeric writer, positional rows and outgoing-column return totals cannot be treated as desktop parity. Hidden source fields must be preserved, not exposed as arbitrary editable storage identities. This continuation follows the exact33-field classification already retained in round4; new source discoveries become descendants in the execution plan.

After this slice, continue every remaining descendant in [the execution addendum](12-execution-addendum.md), including the Sale Return two-grid contract, complete shared help, dedicated credit-note writes, Setting lot writes, order settlement/delivery, historical migration, devices, recovery and full business acceptance. No complete functional percentage is inferred from code or test counts.
