# Round5 generic, Design and Repair image concurrency verification

This bounded X05/X25 engineering slice tests image state and mutations under authenticated HTTP. It does not certify every desktop form, image-import path, report, or business workflow. Round4 evidence and checkpoint21 remain unchanged.

## Mutation contract under test

The three state endpoints are `GET /stock/tag-image/state`, `GET /masters/design-book/image/state` and `GET /repair-images/state`. Each supplies a non-cacheable state, opaque 64-hex version, own-form `canUpdate`/`canDelete`, and `image.state` of absent, unavailable or present. Present state carries decoded bytes as base64; malformed historical bytes retain an unavailable diagnostic and a version so authorized users can recover them.

Every HTTP upload requires the loaded body `version`; generic/Design deletion accepts query version (the API also accepts body version), and Repair deletion uses the body. Missing/malformed versions return400; a valid but outdated version returns409 `image-version-conflict`. Generic upload is an update action, matching replacement behavior and Design/Repair image rights. Existing trusted direct service calls retain optional-version compatibility; the tests do not treat that boundary as modern HTTP parity.

Tokens bind actual scoped image identity, persisted revision and relevant saved parent state. Revision survives deletion. A tag image's `imageType` is an attribute, not another primary-key dimension. Distinct entity types, tag instances, companies, branches and tenants must not overwrite one another. Design parents are company-wide and required; Repair photos use the source receipt's full year/book/voucher/serial, which can differ from the current Repair stage. Generic and form-owned Tour writes share the same underlying tag image revision lock.

The modern HTTP decoder must fully decode JPEG/PNG pixels; a valid magic header alone is insufficient. Legacy direct-service magic-byte tests remain a separate compatibility contract and do not establish complete image validity.

## Owned regression tests

`apps/api/test/entityImageConcurrency.routes.db.test.ts` contains 17 authenticated cases using complete PNG/JPEG fixtures:

- Absent-state token and missing-version refusal without writes.
- Stale replacement/deletion preserves exact winning bytes, index and revision.
- Two simultaneous generic uploads produce exactly one winner.
- Absent→save→delete→identical recreate cannot revive earlier tokens.
- Image type changes one physical image; entity/instance tokens are not interchangeable.
- Separate view/update/delete rights; Design/Tour/other rights do not grant Tag Print mutation.
- Company/branch scope mismatch and foreign-tenant token refusal; both tenants' bytes remain intact.
- Generic changes invalidate Tour tokens and Tour changes invalidate generic tokens.
- Separate Design own-form/company-wide saved-parent lifecycle and no tag-index pollution.
- Imported tag index with missing bytes is recoverable without duplicate index rows.
- Actual simultaneous generic/Tour writes compete on one shared image identity.
- Malformed versions, truncated PNGs and MIME mismatch leave current bytes and token intact.
- Malformed historical bytes return unavailable, then recover only under the current token.
- Nonfinite/negative instances fail before any write; historical finite fractional instance9.5 stays distinct.
- Removing and identically recreating a Design parent invalidates the old loaded token.
- Two separate generic and Design cases upload a complete 1024×1024 uncompressed PNG, greater than1 MB JSON and within4 MB binary, then compare exact returned bytes and state size/version.

`apps/api/test/repairImageConcurrency.routes.db.test.ts` contains 9 authenticated cases:

- Mandatory valid body versions, including absent images and malformed values.
- Actual simultaneous writers and stale deletion leave exactly the winner.
- Persistent deletion/recreation revision prevents old-token reuse.
- Source R52/2023-2024 differs from current R51/2024-2025; source row17, sibling23, current stage and other source year remain independent. Raw and list reads resolve the same saved source identity as state/write endpoints.
- Repair view/update/delete rights and cross-branch scope checks with no-write snapshots.
- Full modern pixel decode plus recovery of malformed historical bytes.
- Saved source parent update invalidates a previous token.
- Deletion and identical recreation of the saved source parent invalidates a previous token.
- A complete large PNG above the default1 MB JSON limit persists to the historical source identity and returns exact bytes.

Both files compare complete image/revision business snapshots after failures, not just HTTP status. Repair snapshots also include parent/header rows. Physical parent deletion/recreation is fixture setup used to prove stale identity rejection; no live business records are used. Tests use the isolated 55433 database, real authentication and no mocked API routes.

Existing `designBook.routes.db.test.ts` now loads image state before upload/delete, retains owning-rights and wrong-parent/company assertions, and uses a complete PNG fixture rather than the older inline image. Wrong-parent uploads receive a valid loaded token so they still exercise parent rejection. `entityImage.db.test.ts` fixture cleanup now also removes its persistent revision rows; its 18 existing compatibility cases remain intact.

## Focused run history

`image-cas-first.txt` is retained: generic12/13 passed and legacy entity18 passed. One new test incorrectly expected403 for scope mismatch, while existing `ScopeError` specifies409. The new complete-image fixture also initially used `new URL` in a file whose route constant was named URL. Tests were corrected to the existing409 scope contract and `globalThis.URL`; no product policy was weakened.

`image-cas-focused.txt` is retained: generic15, Design5 and legacy entity18 passed, but five of eight Repair cases failed at raw byte readback. New state/write/delete correctly used source `imageBook`, while legacy raw/list reads still selected current `coBook`, returning404 for a successfully saved source image. Root corrected both GET adapters to `imageBook ?? coBook` while keeping current scope validation. Assertions were retained and a source list-read assertion was added.

Earlier focused run `image-cas-verified.txt` passed **4 files / 46 tests, zero skips**, in 6.62 seconds: generic15, Repair8, existing Design5 and entity18. All four API test files were then frozen and the isolated DB slot released to root. A subsequent independent review found all three ordinary image POST endpoints still had the default1 MB JSON body limit, inconsistent with the advertised4 MB binary image limit. Root applied the existing order-image6 MB route body limit. The new large-image tests passed with all current CAS cases: `image-cas-large-verified.txt`, **2 files / 26 tests, zero skips**,7.13 seconds (generic/Design17 and Repair9). The earlier46-test result remains a separate run, not relabelled. Test files were frozen again and the DB slot released.

## Final API and strict test-type verification

Final coordinated API regression passed **221 files / 1,740 tests, zero skips**, in 113.16 seconds (`api-full-complete.txt`). The before-run snapshot `api-input-snapshot-complete.json` contains 1,001 inputs; `api-input-verification-complete.json` confirms all 1,001 remained identical after the run. This scoped manifest also independently rechecked that snapshot at finalization. Strict API test types completed successfully (`test-types.txt`; root confirmed exit0, since successful tsc itself is silent).

Earlier stages are retained without relabelling:

| Stage | Actual result | Evidence |
| --- | --- | --- |
| Initial full API, before route-count and large-body additions |220 files passed,1 failed;1,735 tests passed,1 failed. The sole failure expected540 declared routes instead of543 after the three state endpoints. | `api-full-initial.txt`, `api-input-snapshot-initial.json`, `api-input-verification-initial.json` |
| Full API after large-body cases and route registry correction, before strict tuple annotations |221 files /1,740 tests passed, zero skips;129.79 seconds. | `api-full-before-test-types.txt`, `api-input-snapshot-before-test-types.json`, `api-input-verification-before-test-types.json` |
| Initial strict test types | Failed on tuple inference in the two new URLSearchParams test helpers and the root route-policy test loop. Root added explicit `[string,string]` return annotations and `as const` tuples; no runtime product semantics changed. | `test-types-initial.txt` |
| Final full API and strict test types |221 files /1,740 tests passed, zero skips;1,001 final before-run input hashes matched after. Strict test types passed. | `api-full-complete.txt`, `api-input-snapshot-complete.json`, `api-input-verification-complete.json`, `test-types.txt` |

The 46-test and 26-test focused runs above precede these type-only test corrections. Their commands, counts, original logs and code stages remain distinct. Final API results cover the current annotated tests. Build and actual browser/UI verification are separate root/client evidence and are not asserted by this scoped API manifest.

## Remaining limits

This verifies concurrent behavior for the explicit image endpoints and selected saved identities. Client behavior across all generic mount sites, file/camera cancellation, scope changes, retries, source row selectors, actual Repair stage hydration, historical imports and executable desktop output require their own evidence. The legacy service compatibility boundary remains deliberate and is not an unconditional concurrency guarantee. No functionality percentage or complete desktop parity follows from these tests.
