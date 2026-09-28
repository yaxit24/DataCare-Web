# Tour Order calculation policy readiness regression

## Observed failure and bounded cause

The complete real-stack run recorded in `browser-real-stack-complete.txt` failed the existing rate-before-ghat assertion: persisted labour was 120 instead of 117. Previous successful runs do not erase this failure.

The Tour editor accepted input and Save while its selected book's asynchronous calculation policy request was pending. `commitLabour` returned without recording an edit when the policy was missing. A rate entered before a later ghat edit could therefore reach the server as only the final snapshot. Fresh snapshot calculation included the later ghat, producing 120. The intended source-trigger sequence commits the rate with ghat zero first, producing 117 and preserving that amount when ghat changes later. This is an operator timing defect; the browser expectation remains 117.

## Correction

- `apps/web/app/(app)/txn/tour-order/page.tsx`: the complete editor and Save require the exact company/location/year/book policy. Submission independently enforces readiness. Pending and failed requests show explicit states; failed requests offer Retry. Scope plus request generation prevents late configuration responses from overwriting another scope or a newer policy loaded with a saved document.
- All row updates run synchronously against the latest queued row reference before passing a concrete state value to React. A blur commit therefore includes preceding input changes. Validation exceptions remain inside the event handler's catch; no potentially throwing computation is deferred to a React updater.
- `apps/web/test/tour-order.journey.mjs`: actual Chrome network conditions force an offline configuration failure and a delayed online retry against the real application. The configured book is cleared first because the single active book may have been automatically selected. The journey checks that editing and Save remain disabled on failure and during retry. Network conditions are restored and the CDP session detached in `finally`.
- The same real journey asserts the visible committed amount before and after later ghat entry, the actual outgoing POST's one-event journal (`rate`, 37.32, ghat 0) and labour amount 117, and the existing persisted value 117. No response interception, substituted API response, relaxed financial assertion or server-data change was introduced.

## Focused verification

- Core order-labour tests: 1 file, 23 tests passed (`tour-policy-core-tests.txt`).
- Tour form and derived-value ratchet tests: 2 files, 12 tests passed (`tour-policy-web-tests.txt`).
- Web TypeScript check passed (`tour-policy-web-types.txt`).
- Targeted ESLint, Prettier and journey JavaScript syntax checks passed.
- Final production build passed: 7/7 tasks (6 cached), recorded in `build-tested.txt`.
- Final complete web test run passed: 18 files, 83 tests, recorded in `web-tests-tested.txt`.
- Final actual-browser run passed with exit 0, recorded in `browser-real-stack-tested.txt` and `web/test-results/parity-real-stack-round2-tested/result.json`. It ran from `2026-09-10T23:39:01.888Z` to `2026-09-10T23:39:10.249Z` against disposable localhost:55433 as `app_user`, with zero mocked requests. Its recorded Tour checks include offline configuration failure, delayed retry, edit/save readiness barriers, the actual POST journal and amount 117, and the full existing create/reopen/edit/stale-conflict/print/delete journey.

This is engineering verification of the bounded regression against the actual production web/API/database stack. It does not establish executable desktop comparison or complete desktop acceptance. The earlier `browser-real-stack-complete.txt` failure and its result remain preserved and separately hashed.

No API, report, fixture data, provider behavior or parity acceptance budget changed in this correction. This fixes the bounded readiness defect; full desktop parity remains governed by the open implementation cards and source gaps.
