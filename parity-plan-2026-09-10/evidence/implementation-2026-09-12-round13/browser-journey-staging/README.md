# Additive session-context lifecycle checks — staged, unexecuted

This directory preserves the frozen original twelve-check journey and adds two real browser lifecycle cases. Nothing in the original `/tmp/datacare-session-context-next/browser-journey-staged` directory or shared main-repository parity harness was edited. The base journey is copied here byte-for-byte so the new optional runner can execute directly after product integration.

- `web/apps/web/test/session-context-lifecycle.journey.mjs`: two new lifecycle checks.
- `web/apps/web/test/session-context.journey.mjs`: byte-identical copy of the frozen original twelve-check journey, SHA3fbefbb8c61da36d202a77be04bad6c4e1689feed710b10f6880ecf40b3092e5.
- `web/apps/web/test/session-context.real-stack.additive.mjs`: new optional runner executes the unchanged twelve checks then both additions. It expects five explicitly declared real-response transport registrations, and writes to a new `test-results/session-context-real-stack-lifecycle` directory by default.
- `optional-runner-addendum.patch`: review-only difference between the frozen optional runner and the new runner. It is not a patch to the shared sixteen-journey harness.

From the actual web root, only after root's product integration/production build and scheduled disposable DB/browser lease:

```sh
SESSION_CONTEXT_WEB_ROOT="$PWD" node scripts/parity-test-env.mjs -- node /tmp/datacare-session-context-next/browser-journey-addendum-staged/web/apps/web/test/session-context.real-stack.additive.mjs
```

The original runner's disposable local DB, production build, app_user, port4410/4411 and secret-handling restrictions remain. No browser, DB, compiler or tests were executed in this staging task. Prettier only formatted the new staged JavaScript files.

Each addition uses the existing two-company fixture and actual UI. A full navigation to Design Book establishes the document; clicking the actual Products Next Link creates a client-side history entry. Shell selection fetches an actual upstream200 and holds it after commit. Browser Back returns to Design Book without replacing the document or Shell. The departed route's local busy lock must release while its exact pending selection remains. A new Book Name draft is entered in the destination before releasing the held selection response.

Case1 delivers the real upstream response unchanged. Case2 aborts that successful upstream response at the transport boundary. In both cases the shared document must become stale/paused, keep the destination draft and its DOM node, retain the same pending request ID/body, and stay on Design Book without a late full navigation. The test intentionally requires no earlier stale banner before release, so an unrelated observation cannot receive credit for the late-selection guard. Valid Book Name/Product inputs and the real Load button then prove the global pause refuses before dispatch; this is distinct from the base journey's real server409 test.

Both cases finish through explicit Check company change confirmation, fresh `/select` + `/me`, and Retry saved company change. The retry body still uses the original expected epoch E and original operation ID; the request header uses current epoch E+1. Replayed=true must leave the observed auth session row, epoch, xmin and ctid unchanged. The destination draft is intentionally left only after the operator confirms that navigation. We do not claim that a deliberately unmounted source route's local React draft is reconstructed by Back; the preservation assertion concerns the destination draft entered before the late completion.

The two additional holds fetch real responses and synthesize no business body/status/header. Their Set-Cookie may already have entered the shared BrowserContext; the recovery sequence relies on fresh authority after full navigation, not assumptions about cookie loss. Overall provenance is original3 + additive2 declared transport faults, fourteen fixed check groups, syntheticBusinessResponses=0. It must not be described as zero-interception acceptance.

The reviewed root correction is now in active helper/UI: successful response validation precedes shared-context observation even when the originating component lease is obsolete; a dispatched failure pauses only its still-identical original guard state; obsolete callbacks do not clear recovery or navigate. Shell leases use pathname and release local busy state on path change. No further confirmed product defect was found in the bounded review. Fresh builds and actual browser execution remain root-owned.
