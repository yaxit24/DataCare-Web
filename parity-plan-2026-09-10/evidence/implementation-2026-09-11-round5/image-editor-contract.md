# X05/X25 — Generic and repair image editing contract

## Scope and implementation boundaries

Extend the existing web production concurrency protection from saved Sales/Tour orders to `EntityImagePanel` (generic tag/master images and Design Book) and `RepairImagePanel`. Preserve the inherited desktop identity mappings and original customer-repair identity. Concurrency protection is a web production improvement; it does not prove historical file provenance, every caller's mapping, physical camera behavior or full desktop parity.

The shared inventory has 23 mount sites / 32 expanded routes. Dynamic product/style mappings and tag callers using array-index-derived instances still need source and saved-identity reconciliation. This slice must not silently rewrite those mappings. Saved-order image endpoints retain their existing 422 conflict contract; modern generic/Design/repair mutations use the 409 contract below.

## State and mutation contract

* `GET /stock/tag-image/state`: existing generic identity (`entityType`, `entityKey`/`tagNo`, `instance`/`vchSrno`, requested `imageType`).
* `GET /masters/design-book/image/state`: company-wide saved `DESIGN_IMG_ID`, location empty in storage, instance 0, image type D; active branch rights still apply.
* `GET /repair-images/state`: original image year/book/voucher/serial. `imageYear`/`imageBook` identify the original repair independently of the current selected fiscal year/book.
* Each valid saved identity returns `{version,canUpdate,canDelete,image}` with `version` as opaque 64-character lowercase hex. Image state is `absent`, `unavailable` with a diagnostic, or `present` with base64 `data`, detected `mimeType` and `size`. No-store headers prevent stale token caching. Absent and invalid historical images retain a token for explicit replacement/removal; missing required saved parents do not.
* POST requires body `version`. Generic/Design DELETE requires query `version` (body also accepted); repair DELETE retains its structured body with `version`. Missing/malformed versions return 400; a stale version returns 409 `image-version-conflict` and requires reload. No caller flag can disable HTTP token enforcement.
* Existing raw GET endpoints remain compatible for image rendering. In-process import/fixture services may omit a token; they still acquire the shared identity lock and advance the persistent revision. Import/restore outside those services still requires its operational maintenance barrier.

## Persistence and transaction order

The physical generic image key is tenant/company/location/entity type/entity key/instance. Requested image type is metadata, not part of the primary key or lock identity. Tokens fingerprint full physical identity, persistent revision, actual raw bytes, MIME/type/size, exact database timestamp text and tag index. Design Book tokens additionally bind the saved parent identity/generation.

Repair keeps `REP_IMAGE`; it does not move photographs into `ENTITY_IMAGE`. Its revision namespace is `REPAIR`, with a collision-free JSON tuple of original year/book/voucher/serial and full outer tenant/company/location. Its token fingerprints raw REP_IMAGE metadata/bytes and the exact saved parent generation. No schema migration is needed beyond round 4's forced-RLS revision table, which already participates in company backup/restore.

Read states use one repeatable-read transaction. Modern writers keep the saved parent alive, lock the shared persistent revision, compare the token, atomically change bytes and (for tags) the index, then advance the revision. Failed comparison rolls back all work including any initial revision row. The revision survives deletion so identical-byte recreation does not revive old tokens. Generic and saved-order writers share the same lock/revision for one actual tag/Design image. Repair parent recreation invalidates old tokens even when the visible key is reused.

Modern uploads and state previews fully decode bounded JPEG/PNG pixels using Sharp (4 MB payload and 25 million input pixels). Each upload route allows 6 MB JSON to accommodate base64 encoding inside that binary ceiling; the global request limit is unchanged. Complete ~3 MB PNG route cases verify this adapter boundary. Signature-only, truncated, mismatched, oversized and unsupported files cannot become modern saved previews. Invalid imported bytes are reported as unavailable so operators can deliberately repair them.

## Rights, request scope and asynchronous clients

State reads require the owning route's View right; capabilities reflect its Update/Delete rights. Generic uploads are classified as Update in the central route policy; View is insufficient for replacement. Design uses Masters/Design Book, generic uses the existing Inventory/Tag Print binding, and repair uses the existing Manufacturing/Repair Receipt binding. These inherited generic/repair family assignments require separate full caller/source rights reconciliation.

Clients send explicit selected company/location/year so a stale tab cannot mutate the active session's new business scope. The UI session identity also includes endpoint, entity/repair key, instance and requested image type. Scope/key changes immediately invalidate pending reads, mutation completions, file chooser results and camera permission/capture results. Old media streams must stop when invalidated. Loading/error/absent/unavailable/conflict are distinct states; replacement must not silently follow a failed read.

An actual 409 retains the intended file/capture for the same identity, shows the newer image only after Reload, and requires explicit Retry upload. Reload is read-only. Switching identity discards pending content; returning to the first identity must not resurrect a pending upload. Every scope transition, including A → B → A, requires explicit reload acknowledgment. Native chooser invalidation retains an opened-dialog sentinel so its delayed result cannot obtain a fresh lease. Camera cleanup is bound to its original lease and observed revision so an old callback cannot stop a newer stream. No automatic rebase or retry may overwrite another user's photo.

## Demonstrated caller correction: Customer Repair Receipt

The existing receipt reader returns exact `srNo`, but the old web hydration dropped it and the photo panel supplied array position + 1. Imported saved serials such as17 therefore targeted the wrong image. Hydration now retains a separate saved image serial, unsaved rows use no image identity, and every successful save performs an authoritative saved-row read before enabling photos. The saved voucher number is retained even if that readback fails, so retry cannot create a second receipt. Full company/location/year/book context is sent on reads and print; a saved-scope anchor prevents update/delete/print/photo use after a scope change until the receipt is reloaded.

Receipt request leases invalidate on Cancel, newer requests, unmount and scope changes. Late load/save-read responses, errors and finalizers cannot restore a cancelled selection or overwrite a newer draft/busy state. The original receipt document writer still requires its own complete imported-column/serial preservation work; fixing image identity does not certify that writer's ordinary ordinal replacement behavior.

## Required verification

1. API/DB: absent create; replacement; stale upload and deletion preserve raw bytes/index/revision; two requests with equal tokens have one winner; delete/recreate identical bytes invalidate old tokens; unavailable index recovery; malformed/truncated files; same text key across entity/instance/company/branch/tenant; explicit stale scope; required/own rights; saved parent deletion/recreation; generic/order shared image invalidation in both directions; repair original-year/book preservation and original-row contention.
2. Shared client tests: competing loads, key/scope change during file reading and camera permission/capture, stale mutation completion, conflict retain/reload/explicit retry, denied permissions and media cleanup. Reversible styling alone needs no mirrored implementation test.
3. Real browser: production Next → actual API → isolated migrated PostgreSQL with non-owner forced-RLS role, no mocked HTTP; second independent authenticated client causes upload/delete conflict, reload is read-only, explicit retry changes exact bytes, parent/book switch discards pending selection, unrelated full Design DTO remains unchanged. Retain screenshots and inspect visible controls. Add an actual delayed receipt read using a short isolated database lock and prove Cancel is not undone by its late200 response. Exercise Chromium-generated camera video through actual getUserMedia/canvas/JPEG upload and track shutdown; label that synthetic camera evidence, never physical-device acceptance.
4. Run complete appropriate API/core/web regressions, production build, lint/types, strict API test types serially, legacy smoke compatibility, document/checkpoint validation and existing release gates. Preserve failures and source identities. Red whole-product gates and unobserved desktop/hardware/business acceptance remain open.
