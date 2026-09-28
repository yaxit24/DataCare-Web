# Round5: generic image editor revision and context ownership

This bounded change adds client concurrency behavior to the existing shared image editors. It does not certify every desktop photo identity, hardware workflow or image migration. Frozen round4 artifacts are unchanged. Root owns API compare-and-swap, revision storage, authorization, Repair Receipt serial/scope fixes, combined verification and the global plan.

## Consumer boundary

The pre-change inventory is `X05-X25-generic-image-client-round5-inventory-2026-09-11.json`. It records21 EntityImagePanel mount sites and2 RepairImagePanel mount sites with exact JSX, source lines and hashes. Dynamic masters expand to6 routes and KarigarForm to5, giving32 routes that render these two shared components.

EntityImagePanel covers the own-authority Design Book endpoint, generic master photos, tag reports and transaction image panels. RepairImagePanel covers receipt and karigar issue and preserves original customer repair book/year/voucher/serial identity. The existing OrderImagePanel has its separate saved-parent contract from round4; the SalesOrderDesignPreview is read-only. They are not converted to generic keys by this change.

Inherited mappings remain visible follow-ups: several tag callers still supply rowindex+1 as instance; dynamic product/style masters use inherited SCHM/DESIGN mappings. The shared controller binds exactly the key the caller supplies; concurrency protection does not prove that every caller supplies the desktop-equivalent saved identity. Root separately fixes the demonstrated Repair Receipt noncontiguous-serial defect. The initial inventory hashes are a before-change observation, not the final source manifest.

## API agreement

- GET `/stock/tag-image/state`, `/masters/design-book/image/state`, `/repair-images/state` returns a no-cache JSON observation: `{version:64hex,canUpdate,canDelete,image}`. Image is `absent`, `unavailable` with a diagnostic, or `present` with decoded JPEG/PNG MIME/base64/optional size. Absent and unavailable observations both carry a token.
- POST includes the observed `version` in its body. Generic/Design DELETE sends it in the query; Repair DELETE sends it in the body.
- Missing/malformed versions fail400; stale versions fail409 with `image-version-conflict` and the reload diagnostic. The shared UI has no token-free mutation fallback.
- Every request explicitly includes current company/location/year. Repair additionally carries original `imageBook`/`imageYear`, with source book duplicated as coBook for authoritative request-scope validation. The current financial year is not overwritten with the original repair image year.
- State capability flags control Select/Camera/Retry/Delete. An unavailable image can be replaced/deleted when authorized. An absent image suppresses Delete even if the user has delete rights. Denied/failed/malformed state never enables token-free editing or claims a valid absent image.

## Shared client state and action rules

`apps/web/lib/imageEditorSession.ts` is a transport-injected asynchronous controller. It owns one current context, observed token, read/write generation, capability snapshot and optional selected File. `useImageEditor.ts` connects this controller to React with a synchronous current-identity ref and `useSyncExternalStore`.

1. The complete endpoint/scope/entity/source-row query identifies the session. Rendering another context immediately gates old callbacks and uses a separate empty snapshot; effects then dispose the old session. No late old response can populate the new context.
2. A file chooser or camera captures a lease containing the session owner, generation and observed token before asynchronous work. A lease from another session or before Reload is invalid even if server version text happens to be equal.
3. A read-only, unavailable observation or network failure is distinguished explicitly. A valid unavailable token supports authorized replacement; a failed state read does not.
4. Upload validates nonempty content, maximum4MB and an optional JPEG/PNG MIME declaration before reading bytes. Missing browser MIME is allowed because the server validates magic bytes and decodes the image. Binary-to-base64 encoding is chunked. Context and enabled-state checks run again after file.arrayBuffer and before dispatch.
5. Only one client operation runs per session. A second upload does not replace the first pending file or send a concurrent request.
6. A409 retains the chosen File, locks mutations and displays the conflict. It performs no automatic read or resend. Reload retrieves authoritative bytes/capabilities/token; it retains the local File but does not upload it. Only a separate Retry upload action sends that File with the new token.
7. Delete follows the same409→Reload→separate Delete sequence. Generic Delete preserves its existing no-confirm behavior; Repair preserves its existing confirmation. This CAS batch does not claim to close desktop delete-confirmation parity for every generic caller.
8. A successful mutation clears the pending File before readback. If the subsequent read fails, the UI reports that the mutation completed and requires Reload; it cannot resend the already committed upload.401/403 also requires a capability refresh before another mutation.
9. A native chooser invalidated by scope/disabled/revision changes retains an explicit cancelled marker. Its eventual change event cannot be rebound to a fresh lease. Programmatic file assignment can acquire a current lease only when there was no outstanding native chooser.

## Scope-change barrier

Some parent forms retain old row drafts while the application scope changes. A changed scope plus unchanged entityKey does not prove the old selected row belongs to the new company. Both shared panels therefore display current company/location/year and require an explicit Reload after a mounted scope change. The previous payload, token, pending File, conflict and retry action disappear immediately. The deliberate Reload acknowledges the current scope and fetches its image observation; ordinary new mounts initially load normally. `imageScopeBarrier.ts` tracks each transition generation: returning A→B→A still requires Reload, and a reload handler captured in the original A cannot acknowledge a later A generation.

This barrier prevents an automatic cross-scope rebind from a retained parent key. It does not replace the remaining caller-level requirement to supply a saved identity bound to its loaded scope. Root's Repair Receipt guard adds that stronger document-level boundary separately.

The Design Book caller also needs a new observation after saving its parent. The image token includes the saved parent's physical revision, while the Design Book business hash can remain equal after an unchanged save replaces that parent. Root therefore increments `savedImageGeneration` on every hydrate and includes it with the saved image ID in the panel's React key. A business-hash-only key did not cover an unchanged PUT. This caller integration belongs to root's combined browser evidence; the shared controller continues to reject genuinely stale observations.

## Camera behavior

`cameraRequestGuard.ts` and `CameraCapture.tsx` own permission-request generations and active streams. Stop/unmount/another request invalidates older requests; a late returned stream is stopped rather than attached. A pending frame capture is discarded after its stream is stopped or replaced. The panel's post-capture callback additionally checks its captured lease and current session before clearing state or stopping a camera, so an old callback cannot stop a newer stream.

The generic panel now renders an actual video and Start/Stop/Capture controls; its previous Camera button called capture without ever starting a stream. Both panels stop/invalidate camera ownership when another image write begins or the observed revision changes. A camera permission refusal or unsupported browser remains explicit. There is no synthetic camera success or automatic permission request.

Shared CameraCapture is also used by the existing saved-order image panel; its public start/stop/capture API is unchanged. Actual camera hardware, permission dialogs and platform behavior remain production verification requirements. Pure stream/frame ownership tests are not substituted for hardware observation. The planned Chromium synthetic-media journey exercises the real getUserMedia/video/canvas/capture/upload/database path without replacing HTTP responses; its generated browser media source is explicitly different from hardware acceptance.

## Verification

Focused tests in `imageEditorSession.test.ts` cover17 asynchronous session cases: initial absent token, explicit conflict/reload/retry, stale delete, absent delete suppression, unavailable replacement/delete, read-only state, revoked rights, failed/malformed reads, delayed file bytes after scope or disabled changes, foreign/stale chooser leases, disposal/reactivation with late reads, concurrent actions, committed upload with failed readback and invalid files. Three additional scope-barrier cases cover initial/unchanged scope, A→B→A and stale acknowledgment callbacks. `cameraRequestGuard.test.ts` adds3 late permission/stream/frame ownership cases.

The initial20 focused tests passed on their first run; the final expanded23-case run also passed. Full web typecheck and focused lint passed. Final focused logs are in round5 `generic-image-client-tests-ready.txt`, `generic-image-client-types-ready.txt` and `generic-image-client-lint-ready.txt`; the earlier first/scope iterations remain separate. No DB setup or parallel DB test run was started by this client task.

The scoped client manifest is `X05-X25-generic-image-client-round5-run-2026-09-11.json`. It pins the owned source, focused tests and contract. Its status describes those checks only. Root's final checkpoint separately owns the combined browser, screenshots and full workspace verification.

The independent real-browser owner provides generic Design and Repair conflict journeys against the production stack, with no mocked responses: another real client changes bytes, stale upload/delete is refused, the file remains pending, Reload shows the newer image, explicit Retry succeeds, and parent/source identity changes remove stale controls. Initial integration failures remain visible: the first run found the Design Book own-save stale observation; the next run reached a committed upload but its legacy tiny PNG was returned as unavailable, so the expected preview did not appear. That second screenshot shows the explicit unavailable message and authorized replacement/delete controls. Root is investigating the fixture/decoder boundary. Neither incomplete run certifies the new conflict or camera journeys, which had not yet run. Final combined browser evidence is recorded separately after the corrected stack passes.
