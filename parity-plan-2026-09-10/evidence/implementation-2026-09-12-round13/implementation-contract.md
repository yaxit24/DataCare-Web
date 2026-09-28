# Next server session context slice — proposed implementation contract

Status: source-derived implementation plan only. No repository writes, database actions, compiler, browser or deployment action has been performed. This slice establishes atomic session context changes and explicit unknown ledger-mode state. It does not resolve vendor registration/edition, turn balances on, or certify all in-flight financial requests.

## Current behavior and concrete seams

| Source | Current behavior and implication |
|---|---|
| auth/session.ts:65–73,123–141 | Access validation reads the session row in a tenant transaction and checks identity/revocation/expiry. There is no context epoch. |
| app.ts:291–322 | Authentication separately compares JWT co/lc/year/login-company with the row, then reloads the principal. Returning A→B→A restores the same tuple, so no generation distinguishes the original A token. |
| auth/businessScope.ts:47–132,134–180 | Company, location and year each use their own transaction. Selected scope requires a year; login can remain without one. Defaults and permissions must survive extraction into Tx functions. |
| app.ts:707–747 | Company selection resolves scope, commits last-day-lock, commits session scope, then signs access using the old request principal. Failure after the lock commit can leave a lock write without a selected context. |
| auth/session.ts:208–228 | Scope UPDATE has no expected scope/epoch predicate and checks revoked_at but not current expiry inside that operation. Concurrent selections have no stale-selection outcome. |
| auth/session.ts:143–205; app.ts:547–586 | Refresh locks one session and rotates the JTI; principal reload and token issuance occur after commit. Later failure/lost response can consume the old refresh token. Reusing it deliberately revokes the session. |
| auth/session.ts:231–279; auth/passwordAccount.ts:66–94,109–136 | Logout/user revocations persist. Password change/reset locks/updates LOGIN_MAST before revoking session rows. A new inverse LOGIN_MAST/session lock order must not be introduced. |
| shared/lastDayLock.ts:39–97 | Tx helper already exists. Y writes database-yesterday only when forward; N/blank do not; missing/duplicate settings are no-op; invalid nonblank flag throws. Wrapper creates a separate transaction. |
| app.ts:448–545 | Login resolves scope/principal then creates a session separately. It currently does not invoke last-day-lock. Password verification/migration is a preceding operation. |
| jwt.ts:7–24,82–95; schema.prisma:3791–3809 | JWT/session carry scope, no epoch. AuthSession.coYear is varchar9; current YEAR_MAST.CO_YEAR6961 is also varchar9. Wider10-character fields elsewhere do not justify guessing a migration here. |
| Shell.tsx:31–92; app/select/page.tsx:64–77 | Select callers have no expected version or operation identity; Shell changes visible selectors before success and reloads afterward. BusinessScope contains only co/lc/year. |

The proposed work must preserve immutable loginCoCode separately from selected coCode. It must continue reloading permissions from LOGIN_MAST/USER_SET rather than trusting rights embedded in JWT or a mode/edition value supplied by a client.

## Minimal persistent schema

Add fields to the existing tenant-scoped auth_session; do not create a second independent context authority:

- `context_epoch BIGINT NOT NULL DEFAULT 1`, CHECK >0. Prisma BigInt, SQL reads cast to text, JWT/JSON carries canonical positive decimal strings. Identity is `(tenantId,sessionId,contextEpoch)`. Never coerce this value through Number. No numeric zero generation or claim about historical transitions.
- `ledger_context JSONB NOT NULL`: server-owned versioned object initially exactly `{version:'server-session-ledger-context-v1',status:'unknown',mode:null,reason:'vendor-authority-unresolved'}`. Migrated rows use explicit reason `legacy-session-uninitialized`; incomplete login scope uses `scope-incomplete`. Validate the shape on writes/reads and constrain status/mode to unknown/null for this first migration. Context binding comes from the containing session tuple/epoch; do not accept a second client-controlled scope inside this object.
- Nullable last-operation receipt: `last_context_selection_id VARCHAR(36)`, `last_context_request_sha256 CHAR(64)`, `last_context_from_epoch BIGINT`. Require all three present or all three absent. The current context_epoch and row scope are the receipt's committed outcome. This is one-operation recovery, not a universal retained history or an audit log.

No field admits known A/B/C yet. A future known-state migration/adapter must carry qualified vendor facts, their revisions and the pure kernel version; adding a string mode column with default A is forbidden. Any future mode/bootstrap-authority change must participate in this same CAS/epoch boundary (or a separately proven mode version included in every dependent observation); it must not silently change known mode while retaining a token/cache identity for old facts. Refresh preserves this exact unknown observation. An explicit successful context open replaces it with a new unknown observation bound to the new epoch; a failed open does not mutate it.

Migration steps: additive columns → initialize all existing rows at epoch1/unknown with no receipt → validate backfilled shape and positive epoch → NOT NULL/check constraints → retain existing composite primary key, forced RLS, expiry check and grants. Preserve all session IDs, identity/scope, expiry, refresh hashes and revocation values. Do not rewrite current LOCK_DATE or any business row during migration. Check partial-schema compatibility like the existing20260715030000 migration and stop on incompatible live definitions; do not overwrite non-null existing epochs blindly.

Deploy all session writers/readers together. An old API node can update scope without bumping the epoch, so mixed old/new writers are not a qualified rollout. Existing access JWTs lack epoch and are rejected; valid existing refresh tokens can rotate once to obtain epoch-bearing access without inventing a new business context. Revoked/expired sessions remain revoked/expired. Do not install a silent epoch1 default in JWT verification. All same-key A→B→A protection begins at this migration boundary; no retrospective guarantee is made.

## Transaction-aware functions and ownership

| File | Concrete refactor |
|---|---|
| auth/businessScope.ts | Extract private `companyTx`, `locationTx`, `yearTx`; export `resolveLoginScopeTx(tx,input)` and `resolveSelectedScopeTx(tx,input)`. Existing public wrappers each open ONE withTenant transaction and call their Tx form. Preserve current company-access/admin rule, exact requested branch/year behavior, default ordering, no-year login and required-year selection. Add `validateStoredScopeTx` for refresh: validate exact saved scope without selecting new defaults; absent login year remains incomplete. |
| rbac/authorization.ts | Extract `loadPrincipalTx(tx,input)`; wrapper remains for current callers. Preserve selected-company-first then immutable login-company lookup, rightsOf and forced-reset behavior. Plain transactional reads here; do not add FOR SHARE of LOGIN_MAST after locking auth_session, because password changes use the opposite order. |
| auth/session.ts | Extract tenant-qualified `readAuthSessionTx(tx,{tenantId,sid},lock)`, `createAuthSessionTx`, `validateAccessSessionTx`, `rotateRefreshSessionTx`, `revokeSessionTx`, `revokeUserSessionsTx`. Keep wrappers and outcome mapping. Refactor `updateSessionScope` into an internal CAS operation; no independently callable unchecked scope setter remains for selection. Every UPDATE explicitly includes tenant, sid and expected current epoch when relevant. |
| new auth/sessionContext.ts | Own `startSessionContext`, `selectSessionContext`, `refreshSessionContext` coordinators and typed returned committed-state/token descriptors. They call Tx helpers in one tenant transaction. No nested withTenant calls. |
| shared/lastDayLock.ts | Reuse `applyLastDayLockTx`, not its wrapper. Serialize existing company-setting rows with FOR UPDATE in this operation so a concurrent later manual lock cannot be overwritten after a stale read. Preserve all existing flag/date/ambiguous/missing behavior and use database current_date. |
| jwt.ts/app.ts | Add contextEpoch to required access claims; authenticate from persisted epoch and scope before loading route authority. All login/select/refresh cookies describe the same committed context. /me returns epoch and explicit unknown ledger-context diagnostics, not known balance capability. |
| web Shell, select page, layout, BusinessScope | Consume server epoch, send it with an operation ID for selection, freeze context-sensitive controls while selection/recovery is pending, and carry epoch into response identity/generation guards. Do not mark success or rewrite captured drafts before authoritative response. |

Use a consistent session-row lock before any context/refresh mutation. Do not hold password Argon2 work inside long session transactions. Login may verify credentials outside, then reread the same credential identity/hash before creating a session; for a reset race, a brief LOGIN_MAST lock before the new session insert preserves the existing password-reset lock order. If password verification/migration remains separate in the initial patch, disclose that remaining boundary instead of claiming the entire credential-upgrade workflow atomic.

## Exact company-selection operation

Public body: `{coCode:string,lcCode?:string,coYear?:string,expectedContextEpoch:string,selectionId:string}`. Reject unknown keys, arrays, numeric/coerced values, hidden tenant/sid/login/rights/mode/edition/catalog/clock fields and invalid canonical epoch/operation ID. Company-only selection can retain existing server-derived defaults; omitted keys and explicit keys remain distinct in the request fingerprint. Do not fill a missing expected epoch from the current row to preserve old clients.

In one Serializable tenant transaction (or another explicitly proven equivalent):

1. Lock the exact auth_session row FOR UPDATE; validate signed subject/tenant/session/login-company, revocation and expiry inside the lock. Refresh principal/forced-reset authority transactionally. Use persisted identity, never request rights/isAdmin.
2. Recognize only an exact retry of the current last receipt: same selectionId, same request hash and same original expected epoch. If recognized, revalidate current principal and return current committed state without applying last-day-lock, bumping epoch or resetting mode again. If any intervening selection replaced this receipt, return context-stale; do not replay historical actions. Reusing the same ID with another body returns context-operation-conflict.
3. For a new operation, require expectedContextEpoch equals stored epoch. On mismatch return409 context-stale before any company settings/session write. Resolve target scope with the Tx resolver and current principal's existing company-access rules. Load the target principal using current target/login-company precedence, so issued rights match the selected context.
4. Apply last-day-lock in this SAME transaction. On invalid flag/configuration, fail with a clear diagnostic and roll back both lock and context changes. On missing/duplicate CO_SET preserve the current no-op result; do not manufacture a lock. Handle Serializable conflict as a retryable conflict, not a hidden success or unbounded automatic retry.
5. Increment epoch exactly once, set target scope, initialize explicit unknown ledger context, and store the request receipt in one guarded UPDATE. Same-scope open with a fresh operation ID also increments: it is a new company-open event and must invalidate prior same-tuple work. A retry with the same receipt does not increment.
6. Prepare signed access from target principal and the prospective epoch before commit if token generation failure must roll everything back; keep this local trusted cryptographic work, never network I/O. Expose cookies/body only after successful commit. Scope selection does not rotate or replace the refresh cookie.

`selectionId` supports safe recovery of a known committed selection, not arbitrary mutation retries. Expired/revoked sessions cannot use a receipt to recover authority. Epoch overflow is a contained transaction error; do not wrap to1 or0.

Response: current scope, canonical epoch, `scoped:true`, `replayed:boolean`, fresh current rights/forced-reset state and explicit unknown ledger context. No tenant override, registration bytes, refresh hash/JTI or fake closing number is returned. Keep the existing generic credential error and form rights behavior; map new context conflicts deliberately, without turning ScopeError into a success.

## Refresh, revocation and lost responses

- Refresh claims continue identifying the session/JTI without selecting context. The locked row is the only source of current scope/epoch/mode. Revalidate exact current configured scope and principal transactionally; never choose a new default year/company during refresh and never apply last-day-lock on refresh.
- Preserve current absolute session expiresAt; refresh does not extend it or change context_epoch. Rotate one JTI with the existing one-winner rule. Preserve explicit transaction outcomes so expired/reuse revocation commits before an error is raised outside the transaction.
- Prepare principal and locally signed tokens before committing JTI rotation. Any pre-commit error rolls back the rotation; after commit, a network failure remains a lost response, not a database rollback. Do not automatically accept the old JTI, cache plaintext credentials, introduce a grace window, or infer that a repeated refresh was harmless.
- Lost refresh response / concurrent use of one old refresh token retains the present strict policy: a repeated old JTI revokes the session and requires login. This inconvenience is explicit; resilient refresh recovery would require a separately reviewed protocol. The browser currently deduplicates refresh in one JavaScript realm only, not across tabs. Do not claim cross-tab recovery implemented.
- Selection racing refresh is serialized on the same session row. Refresh may return an access token for epochE immediately before a selection commits E+1; that late token is rejected thereafter. Selection never overwrites refresh, so it cannot roll the refresh generation backward. A late HTTP response cannot restore an earlier database epoch.
- Selection response loss: retain the original operation ID/body. Recover current access through the existing refresh flow (if usable), reload authoritative /me, then retry only the exact recorded selection operation when explicitly requested. A recognized current receipt is read-only recovery; stale receipt after another selection returns409. Do not resubmit with a new operation ID/epoch automatically or apply last-day-lock twice.
- Logout/reset/revoke must use the same row authority and never un-revoke a row. Keep current password-change exception for its active session unless separately changed. In race tests, whichever revocation commits last still prevents all subsequent access; an old selection result cannot resurrect it. Avoid auth-row→LOGIN_MAST row locks that deadlock with existing password reset's LOGIN_MAST→auth-row sequence.

## Last-day-lock preservation and explicit existing differences

Preserve the trigger currently installed at /context/select, including same-company opens, and preserve flag Y/N/blank validation, database-yesterday, forward-only update and missing/ambiguous no-op. Do not silently move it to every voucher save or refresh. The source MS_OPNCOMP1503–1507 unconditionally writes yesterday for flagY; the current web's forward-only protection is an existing behavioral difference, not proof of identical source monotonic logic.

Login currently resolves a business scope without calling this helper. Adding lock application at login may be source-justified when login means company-open, but it is a distinct trigger change and must be explicitly selected before implementation. The initial atomic refactor can preserve existing login behavior and leave this source parity gap open. Unknown mode must not disable or bypass lock application on a successful selection.

## Boundaries: what this slice does not prove

A new epoch checked only in requireAuth does not revoke a business transaction already admitted before a selection. Selection/CAS protects session state and tokens, not universal transaction ordering. For any later closing/numeric writer, pass expected epoch into a transaction-aware session guard and hold the required session lock in that SAME database transaction before document/config/ledger observation; define one lock order across writers/revocation. Do not wire known balances until that guard and trusted vendor mode adapter exist.

Similarly, a generic browser automatic401 refresh/retry must never silently replace a draft's expected epoch. Preserve the original context identity in request metadata; on context change return a recoverable conflict and require an explicit reload. Updating only JWT comparison while leaving scope-only component keys would not protect A→B→A responses. Inventory all context/select callers and affected compatibility fixtures; no legacy missing-epoch bypass is allowed merely to keep old tests green.

## Independent lifecycle acceptance matrix (proposed, not run)

| ID | Real service/HTTP case and invariant |
|---|---|
| S01 | Login creates epoch1 and unknown mode; /me/JWT agree; no-year login remains incomplete without invented year. |
| S02 | Company/branch/year selection updates scope+epoch+receipt+unknown mode and eligible last-day lock in one commit. |
| S03 | Target company permission, missing branch/year, invalid lock flag or token-signing failure leaves session and every business/config row unchanged. |
| S04 | Two simultaneous different selections from epoch1 yield one winner and one409; loser performs no lock write. |
| S05 | A→B→A yields epochs1→2→3; token/draft/response from epoch1 cannot be accepted merely because tupleA matches. |
| S06 | Same current scope with a new operation ID is a new epoch/open; exact same ID/body retry is read-only and does not apply lock again. |
| S07 | Same ID with changed body conflicts; retry old ID after another selection conflicts and never restores historical scope. |
| S08 | Commit selection then discard HTTP response; current receipt recovers without another lock/epoch; recovery after session revoke/expiry fails. |
| S09 | Fresh principal on target preserves admin/ordinary rules, selected-company priority, immutable loginCoCode, USER_SET branch isolation and forced-reset restrictions. |
| S10 | Current selected-company/LOGIN_MAST/rights change invalidates authority on subsequent requests/refresh; no stale JWT rights override it. |
| S11 | Last-day lock N/blank, Y before-yesterday, Y same-day, Y later-manual-lock, invalid flag, absent and duplicate settings preserve existing outcomes. |
| S12 | Concurrent manual later LOCK_DATE update vs company open never moves the date backward; unrelated tenant/company settings remain untouched. |
| S13 | Refresh rotates once without changing epoch/mode/scope/expiry; principal/signing failure before commit leaves JTI unchanged. |
| S14 | Old refresh reuse commits session revocation; a second concurrent refresh cannot gain authority; lost response follows the documented re-login policy. |
| S15 | Refresh vs selection/revoke in both lock orders; late access cookie is stale, no stale scope or un-revoke survives. |
| S16 | Password reset/self-change vs selection/refresh, with existing active-session exception, completes without inverse lock-order deadlock. |
| S17 | Missing/zero/negative/noncanonical/overflow epoch; malformed IDs/unknown fields; client known-mode/vendor facts are rejected without writes. |
| S18 | Legacy active session backfill preserves all historical columns; old epoch-less access rejected; valid old refresh obtains current epoch; expired/revoked remain denied. |
| S19 | Partial migration incompatible data stops; forced RLS and composite key remain; same sid in another tenant cannot alter or recover a receipt. |
| S20 | Malformed persisted ledger-context object yields a contained diagnostic, never A/B/C or fabricated balance; incomplete scope remains unknown. |
| S21 | Actual UI delayed A→B→A responses, disabled controls while switching, retained draft on conflict, explicit reload and stable operation ID on known retry. |
| S22 | Actual authenticated View-only user keeps existing create/read vs edit/delete/print semantics before/after selection and refresh. |
| S23 | Ordinary non-context business rows/raw values/physical identities unchanged by session operations except the specifically qualified CO_SET lock write. |
| S24 | A deliberately held in-flight financial request demonstrates the current pre-handler boundary; do not close this case until same-transaction epoch guard is integrated. |

Use isolated55433, dedicated tenants, app_user runtime and owner setup, real concurrent clients/held transactions, exact before/after auth_session and CO_SET plus business snapshots. Pure or fake unit tests can cover parsing/outcome mapping but cannot substitute for race/rollback proof. Freeze request/fixture expectations before product changes and retain failed stages. Final original-runtime/business acceptance remains open.

## Ordered implementation batches

1. Migration + strict epoch/unknown-mode DTOs + Tx helper extraction with unchanged wrapper regression tests. No known-mode adapter.
2. Atomic select coordinator, last-lock row serialization, CAS/last-receipt semantics and real concurrent service tests.
3. Login/refresh/token issuance integration, fresh principal/expiry/revocation semantics, epoch-required JWT and authenticated HTTP cases; preserve current last-lock login trigger until explicitly decided.
4. /me/layout/provider/Shell/select-page epoch integration and response/draft barriers; update compatibility callers to explicit CAS, then actual delayed-browser tests.
5. Only afterward design the server-owned vendor observation adapter and transaction-bound closing observation. Source registration/edition, command-time edition, force-combined exceptional flags and CONV_MAST ownership/revisions remain hard dependencies for known mode. Never derive them from book MAIN_BOOK/DATA_TYPE, JWT rights, client key labels or arbitrary configuration defaults.

## Source inputs

- `web/apps/api/src/modules/auth/session.ts` (65–279): `17765f43964137139d582695cc0d10e3713227b8e118070e6f3e4a07fdb63bf0`.
- `web/apps/api/src/modules/auth/businessScope.ts` (47–180,241–249,scope enforcement): `7eca43829be9e9034be1779cf33760d94deb92dd55d6ec99d67b2a6d1310535e`.
- `web/apps/api/src/modules/shared/lastDayLock.ts` (39–97): `d7fa20f7c174b2c8ac1fba41a6e38a23cd219295242e4621379cc25f1c8bd096`.
- `web/apps/api/src/app.ts` (291–322,448–586,633–651,707–747): `919f79ce65b1580b35f7a1bc5be7aeab8374a52c6c002bfa4b704b8c0b7c793a`.
- `web/apps/api/src/modules/auth/jwt.ts` (7–24,82–110): `4bd2d709bcd6ec64d3734822972932aed4bcd1797422815caf4a8eaa90de3169`.
- `web/apps/api/src/modules/auth/auth.service.ts` (65–91): `cb6269a6b3793d9dc7163bbd1f144336f12da461cdec7177e620b5f5f74f026e`.
- `web/apps/api/src/modules/auth/passwordAccount.ts` (22–139): `f566af63d2048bd64f69c7e04aaede8102a5a789a11750a8450d7016cda5ce56`.
- `web/apps/api/src/modules/rbac/authorization.ts` (loadPrincipal54–94,authorizeForm103–170): `6d1fa83af6c80633fe49833ce3ba6e375f76f3334b56050d513280aaba09de34`.
- `web/apps/api/src/modules/rbac/formRights.ts` (per-form rights/read adapters): `a65d249274d56053edc9efa3a3c0618c4dcd65e61d9f46b18782c26856224861`.
- `web/apps/api/src/modules/rbac/routePolicy.ts` (session route ownership32–38): `2e51f3879c8728c8a526a0b4db2f82435e935b0ce690ab3dc52dcb4826053c2e`.
- `web/packages/db/prisma/schema.prisma` (AuthSession3791–3809,YEAR_MAST6956–6961): `158aa2c66db0ff7b5b07931d853d73cb2aad0973880a0d7385eee6695c973754`.
- `web/packages/db/prisma/migrations/20260715030000_authoritative_scope_rbac_sessions/migration.sql` (81–211): `4d011ad562511873982957325ffc47b62ca5d824a25b312495c531c185ae873c`.
- `web/packages/db/src/tenant.ts` (17–26): `1f158835529c4b5c1692c05e377b00c6b14a9bba3b72b2e43a12ff3687fc0a32`.
- `web/packages/core/src/sessionLedgerMode.ts` (65–145,567–599): `651c63fcc715b995d924d79ddb756d8fca504fcee4ae8cf9c64b4ad883844493`.
- `web/apps/web/components/Shell.tsx` (31–92): `96565f34433a6e7f6c7378e0788e544e4126febc0a72bfdbcc9a33e8d1fa2960`.
- `web/apps/web/components/BusinessScope.tsx` (entire scope provider): `ffe8f4922dd0c65e7dc9bbb91ae8cdd10b67edd8b1349ef57388ee64d2119213`.
- `web/apps/web/app/(app)/layout.tsx` (16–57): `2e652cbd457a1ca86eddd937d87ac7456937dc0ffa04d137f4ba4103e78631e1`.
- `web/apps/web/app/select/page.tsx` (64–77): `0364bca395bd87d0470df8c812f091a3f454316ec30d8a3f8431a42264e9a903`.
- `web/apps/web/lib/api.ts` (15–57): `7b07a3387e30d3a685d2974ad63f172ae381d6cebe1de7b1e1ddd147dfc7b5dc`.
- `web/apps/api/test/app.security.db.test.ts` (244–272,318–350): `e372676ca0aec3ce4561e899efe2c8bbb62d398ef8c526590e4fef78d5c23155`.
- `web/apps/api/test/auth.session.test.ts` (121–163): `80587a3473c566fec5e5918e537938fea1458893f61f7d81fddb068fb34c6c4d`.
- `web/apps/api/test/settingsBehavior.db.test.ts` (542–575): `b3cf0a8e5325ee3254ca8df5a8f38134ec265897f4fc09e4dd2751383dfac508`.
- `unified/src/csharp/DataCareNext/MS_OPNCOMP.cs` (1503–1507): `180f295f9595dfc7c28ee34629563889c943eea0a0afc7c7a9baa519a11c4561`.

Captured 2026-09-11T18:13:58.589304+00:00.
