# Independent transaction-admission proposal review

Source-only review; no database, compiler, browser or test was run. The implementation owner confirmed that the staging files were baseline copies and the new command helper was not yet ready. This note reviews the frozen proposal and the current call graph, not a completed implementation.

No confirmed source-level blocker was found in the bounded proposed lock order. Admission must own one transaction, take the exact auth_session SHARE lock before the order's advisory/header/business locks, sample database clock in a separate statement after waiting, and retain that lock through the financial callback and final live check. The defined winner/waiter semantics are ordering, not retroactive cancellation. ReadCommitted permits the document-version reader to observe the preceding committed replacement after waiting on the existing advisory lock.

The actual first financial path is suitable: salesOrder.ts:1596–1661 currently owns edit transaction/version/period/consumption/replacement; its createSalesOrder lifecycle path at750–1289 takes the supplied Tx, including TEMP_BOOK_DATA, balanced AC_DATA advance, Rojmel, child replacement, saved-NULL preservation and exact-clock restoration. The edit's persisted header lock and nine-table observation feed the existing version at1335–1393. Replacement row IDs invalidate even an unchanged old version. Extracting this callback must preserve these operations and error mappings; invoking the convenience posting/numbering wrappers would introduce a second transaction and would not satisfy the proposal. The inspected Tx-specific posting/lifecycle/numbering/design-resolution callees do not acquire auth_session or LOGIN_MAST locks.

The proposed plain authority reads are necessary for the current password reset order. passwordAccount.ts:66–94 and111–132 locks/updates LOGIN_MAST then updates matching auth sessions. A command that holds session SHARE and then attempts a credential row lock would form a direct inverse wait. Ordinary MVCC principal reads avoid that cycle and may intentionally observe the last committed credential while reset waits for the session. Successful selection/refresh/logout/revocation must wait when the participating command wins; they are not cancelled or silently retried. Self password change's excluded current session remains an explicit existing exception. This review does not establish universal deadlock freedom, database trigger behavior or atomic rights/configuration changes by unrelated sessions.

Two precise implementation requirements were sent to the owner before coding:

1. The new guarded editSalesOrderInSession entry should itself reject absent/malformed expectedVersion. Existing assertOrderVersionTx deliberately skips comparison when expectedVersion is undefined, while only the current HTTP PUT's requireOrderVersion enforces it. Preserve that old internal/Tour compatibility, but do not accidentally carry its optional-version entry into the new required-authority interface.
2. The scope consumed by editSalesOrderTx after lock waits must be the exact detached scope admitted by the helper. A copied immutable policy combined with work closing over a mutable different input.scope would not establish that binding. The first entry can bind/copy its business input and scope explicitly without changing unrelated legacy wrappers.

The contract correctly keeps initial request authentication and transaction admission separate. req.session contains the verified sessionId/epoch/scope and freshly resolved request principal, but the command must read principal/form rights again under its own transaction. It must not populate identity from submitted scope/epoch fields or silently adopt a later stored context. Exact browser headers remain optional compatibility only: their absence cannot establish the creation epoch of an old UI draft. A current JWT identity is still mandatory for the transaction helper.

Compatibility limits are explicit and acceptable for this slice: only authenticated Sales Order PUT adopts the new entry. Sales Order create/delete, Tour and other internal wrappers remain outside it. Permission/configuration reads are admission-time observations, not locks against unrelated USER_SET/CO_SET writers. No session last-used/JTI/epoch update belongs in the command, and unknown ledger context must remain unchanged. Session receipt recovery is not financial idempotency; a lost successful order response requires authoritative reload/version handling, never automatic replay. Final expiry sampling is a final-statement boundary, not an exact-COMMIT-time guarantee.

The frozen26 schedules align with those meanings. Their one-microsecond/equality descriptions are prospective semantic boundaries, not measured PostgreSQL schedules. Actual tests must establish lock waits, transaction ownership, rollback and independent-actor deltas on the real database. The unknown-COMMIT case must remain uncertain rather than being relabeled context conflict or confirmed rollback. Once concrete source lands, review must pin the one guarded HTTP branch, actual extraction, strict identity/policy validator, error classifier and final live check separately.

Observed at 2026-09-11T21:15:53.576423+00:00

Source pins (capture-time observations only):

- `/tmp/datacare-session-context-next/admission-review/implementation-contract.md` — `ef2e6acba21dca9b6696c3dbe6bac983db42587c56e70ec0a2169b7e8eaacbbe`
- `/tmp/datacare-session-context-next/admission-review/session-command-independent.v1.json` — `ed87f81e039273c6bd25c9a19184b7c964c7b48cbfd7a3bb39eb0c58032f4aa4`
- `/tmp/datacare-session-context-next/admission-review/inputs.json` — `43c297255c2cdf5ddfc9e8b0fb9e295c82f6286a725a548f0eb91c5f57fe71d2`
- `/Users/yakshitsavaliya/Desktop/imodule-extracted/web/packages/db/src/tenant.ts` — `1f158835529c4b5c1692c05e377b00c6b14a9bba3b72b2e43a12ff3687fc0a32`
- `/Users/yakshitsavaliya/Desktop/imodule-extracted/web/apps/api/src/modules/auth/sessionContextAccess.ts` — `4caa701a9c7fb82a43ddaf1c5da01ce04be6a7f1028add2049ef64231ab6ea28`
- `/Users/yakshitsavaliya/Desktop/imodule-extracted/web/apps/api/src/modules/auth/sessionContextSelection.ts` — `9440e509fa5f0938edf9b0031c2bff9f5a4e2091cbe8770be2c0c8d403a53aa5`
- `/Users/yakshitsavaliya/Desktop/imodule-extracted/web/apps/api/src/modules/auth/sessionContextRefresh.ts` — `4d43d2639c5345913a11283b8f626e7106662d4c451db3c54c4354c50fe696d9`
- `/Users/yakshitsavaliya/Desktop/imodule-extracted/web/apps/api/src/modules/auth/passwordAccount.ts` — `f566af63d2048bd64f69c7e04aaede8102a5a789a11750a8450d7016cda5ce56`
- `/Users/yakshitsavaliya/Desktop/imodule-extracted/web/apps/api/src/modules/auth/session.ts` — `17765f43964137139d582695cc0d10e3713227b8e118070e6f3e4a07fdb63bf0`
- `/Users/yakshitsavaliya/Desktop/imodule-extracted/web/apps/api/src/modules/rbac/authorization.ts` — `ee079f09d0076f2339dd1307a3912c249624786566d216b1f17466af134b3acd`
- `/Users/yakshitsavaliya/Desktop/imodule-extracted/web/apps/api/src/modules/sales/salesOrder.ts` — `556d87d9eb73974f4a06eec64a0f6a6fe0096b90e59b14522176021ea10fc8d9`
- `/Users/yakshitsavaliya/Desktop/imodule-extracted/web/apps/api/src/modules/sales/orderLifecyclePolicy.ts` — `a226087e96f0bbb3c4de2d75b3634b0a0b8d39f33f8d5630b98e775de1f05251`
- `/Users/yakshitsavaliya/Desktop/imodule-extracted/web/apps/api/src/modules/sales/orderDesignSelection.ts` — `c4d7ee655c8ebd26193dac07411bde9ee95ebd0cbc40bc160a2223f2450caa82`
- `/Users/yakshitsavaliya/Desktop/imodule-extracted/web/apps/api/src/modules/posting/posting.ts` — `31cb38b11b25cdfdaaf796ae2d4305888b6f61f71704fde9e97424bacb6df44e`
- `/Users/yakshitsavaliya/Desktop/imodule-extracted/web/apps/api/src/modules/vouchers/lifecycle.ts` — `346f7d64fb293666a6b430414844c5fba5ca635a71946244df46b383136a0c8b`
- `/Users/yakshitsavaliya/Desktop/imodule-extracted/web/apps/api/src/modules/vouchers/numbering.ts` — `ccf924ae90087c682e8ea915dcaa018cc59e250e9c1825b68600dc20fb2f09db`
- `/Users/yakshitsavaliya/Desktop/imodule-extracted/web/apps/api/src/routes/txn.ts` — `5935fe23532df5248db5b03a7d6ab920375f1c30f9b19c23bf3aaf7016b3cc9c`
