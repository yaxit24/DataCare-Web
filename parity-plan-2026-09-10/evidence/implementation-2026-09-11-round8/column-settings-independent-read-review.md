# Column settings — independent Round8 read review

This is a bounded ordinary correctness review of the new COL_MAST service, dedicated styles page, helper and master-route integration. No implementation/test file was edited and no database or browser process was run by this reviewer. The hashes below capture a staged read-review input, not a final execution snapshot. Root owns the subsequent coordinated regression and checkpoint.

## Source identity and write boundary

UT_SETTING.cs:4842–4858 reads company/family rows and separately retains original COL_NAME, displayed COL_NEW_NAME, flags and BOOK_NAME. Its update at4887 addresses company + original family + original column; the new caption is not an identity. The new service follows that three-part identity, blocks ambiguous physical duplicates, and leaves those key fields immutable during update. Only explicitly supplied COL_NEW_NAME/COL_RPT/YES_NO are SET. The web helper sends only touched values; displayed empty strings for untouched saved NULL do not cause an accidental NULL-to-empty rewrite. Explicit caption clearing sends empty text. Saved unusual flags remain readable and unchanged flags can remain untouched; new flag values follow the declared strict Y/N/blank/NULL web contract. This is not a claim that desktop arbitrary text/case conversion and the strict web validator accept the same universe.

Every generic create/import/update/delete passes through the specialized service. A complete-key transaction advisory lock serializes those generic writers; existing rows are locked before comparing the token and applying a physical-row mutation. Row tokens include company/tenant, complete key, values, row id, xmin and ctid. This prevents stale writes across the represented row updates/recreation within the supported writer boundary. Company cloning, restore and administrator SQL do not participate in that advisory protocol; the implementation and this review make no universal writer-lock or durable absent-row history claim.

## Paging and UI request handling

The list obtains collection revisions and the bounded page within one RepeatableRead transaction. Its exact-family filter and escaped literal search do not rename saved identities. Complete company-row membership/revisions and the filter are represented in the collection token. The client refuses to merge different tokens, totals, overlapping physical row ids or unexpected exhaustion. An empty first result is a usable empty list; an unexpected empty continuation requires reloading. Only loaded rows are exported, and the UI states that fact. CSV NULL-to-blank encoding is disclosed rather than claimed to preserve SQL NULL through a round trip.

The page remounts on the complete business scope key. Request epochs and effect cleanup invalidate old component/filter work, including an A-to-B-to-A scope sequence. Read application also checks the rendered filter before publishing results. Mutation payloads carry the captured complete identity and observed row version. Failed or uncertain mutations retain the editing draft; 403/404/409 and uncertain/server errors require explicit reload. Successful mutations close the editor before authoritative list refresh, so a failed refresh cannot leave an active create action that accidentally repeats a confirmed insertion. The final API still independently checks current rights. List and metadata adapters now emit no-store headers. These are code-path observations, not a substitute for the owner's actual browser delay/scope/permission vectors.

## Concrete finding and disposition

The CSV parser removed a UTF-8 BOM only after tokenization. Therefore a valid leading BOM followed by a quoted first header was rejected: the BOM was already accumulated as field text when the opening quote arrived. The exact reported input was `\uFEFF"CO_CODE","BOOK_NAME","COL_NAME"\r\n"01","SALES RETURNE","Fine"` (the escapes here represent actual characters in the test). The owner accepted the finding, strips one leading BOM before tokenization and added that vector to the web helper tests. At the initial read capture the focused test result was pending. The subsequent executed result is recorded below without retroactively awarding that earlier stage a pass.

No further confirmed wrong-family mutation, accidental untouched-NULL rewrite, stale page merge or old-scope callback publication was found in this bounded read review after the owner's changes. Known root findings about count alias, bounded paging, no-store and 403/404 recovery are not newly discovered here. This conclusion does not close desktop column-settings UI/batch-save parity or any of the X13 numeric persistence gates.

## Verification required at the initial read capture

Root/owners must execute the final source stage: column API pure and database/HTTP cases, web helper tests including BOM, actual-browser create/update/delete/import and stale/scope/filter/paging cases, then the normal build/type/full regression checks. Rights revocation must leave actions unavailable until an explicit fresh observation; a failed successful-write readback must not duplicate a create. Exact sibling-family/company preservation and current collection changes between pages require real database evidence. This read-only review does not award those results in advance.

## Staged input capture

Captured UTC: 2026-09-11T09:58:53.974591+00:00

| Path relative to web | SHA256 |
| --- | --- |
| `apps/api/src/modules/masters/columnSettings.ts` | `1750f378429fef09e22e1b85386811e9f6b6e9213de7403479d14b541a5be0a1` |
| `apps/api/src/modules/masters/master.service.ts` | `dc81d25fa3b53a17c6998007f8a14d96da57d238cac70a11023525341953156c` |
| `apps/api/src/modules/masters/configs.ts` | `e3b03858a98a629385e1c0dc3c1071e354a15a590656814f743533445b845a17` |
| `apps/api/src/app.ts` | `919f79ce65b1580b35f7a1bc5be7aeab8374a52c6c002bfa4b704b8c0b7c793a` |
| `apps/web/app/(app)/masters/styles/page.tsx` | `fd5fd55352e4c946db4750db5a1279f02cad9ac69d3259898291595138e811d2` |
| `apps/web/lib/columnSettings.ts` | `6b6d28365762a1819885f3e3516932810eba61a25c23cb8541042b61bc751771` |
| `apps/web/test/columnSettings.test.ts` | `740adbeecfaced0568ab2ec831e14585b394f4e4be5b457a8f79970096eea7e8` |
| `../unified/src/csharp/DataCareNext/UT_SETTING.cs` | `a47be9b0e2b7754511e8d0aeab135c8352c58f9f417101e550b23ccbc78c30ad` |

## Subsequent executed focused verification

The owner ran the final web helper file: **1 file / 27 tests passed**, including the exact leading-BOM/quoted-header vector (`column-web-tests-final.txt`). The owner also reported web runtime TypeScript and scoped ESLint success; their logs are pinned below. The lint-only cleanup explanation/suppression concerns invalidating the latest numerical request generation, with no behavior change reported.

Root's final focused API run passed **7 files / 253 tests / 0 skips** (`focused-complete.txt`,30.97s). Column-setting-specific coverage in that run was37 pure cases and21 real DB/authenticated HTTP cases. The other195 cases were the37 configuration pure,26 configuration DB,69 independent configuration review,9 configuration HTTP and54 route-policy cases. The real DB/HTTP column suite includes exact family/company/tenant preservation, stale versions/no-write refusals, capabilities, per-row import outcomes, shared create/import absent-key locking, raw NULL preservation and paging/filter validation. These are executed owner/root results, not tests run by this reviewer.

The prior read-stage source hashes above remain a historical capture. The final API-wide before/after input snapshot, complete API/strict test type checks and actual-browser create/update/delete/import/scope/paging regressions remain root-owned and were pending at this update. This focused pass does not assert complete desktop UI/batch-save parity or universal concurrency coverage outside the declared generic writer protocol.

| Executed evidence | SHA256 |
| --- | --- |
| `focused-complete.txt` | `098b62e2c8a9d856c7cf01cee26486d6e5394c2d235354127eff71c8b69be04f` |
| `column-web-tests-final.txt` | `6d9d9ede24a19c19f0b395dce8dcdf02d45f869f1f9a08b3c1c63109709a8d97` |
| `column-web-types-final.txt` | `c04e30f07ee75678ce89d0a71be3ce6157ac20636152fb2c42a55c48c6209b1b` |
| `column-web-lint-verified.txt` | `e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855` |
