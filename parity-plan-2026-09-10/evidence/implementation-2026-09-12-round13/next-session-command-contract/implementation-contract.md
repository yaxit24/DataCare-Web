# Transaction-bound session context admission — next implementation contract

Status: proposed implementation only, based on the pinned current local sources. No product code, database execution, compiler, browser, or runtime acceptance is supplied. `session-command-independent.v1.json` contains independently chosen prospective schedules, frozen before a command helper exists. This is a web concurrency contract, not a claim of desktop transaction equivalence.

## Concrete gap and first integration

The active `validateAccessSessionContext` ends its own `withTenant` read at `sessionContextAccess.ts:19–49`; its comment at18 explicitly excludes financial transaction protection. `app.ts:290–318` then loads a principal in another transaction, and its scope/form authorization at393–416 also finishes before the route calls a writer. `txn.ts:658–665` merely recognizes that earlier authorization. A session selection/revocation committed after those checks does not cancel a previously admitted financial transaction.

Use **PUT `/sales-orders/:vchNo`**, with fixed form `Sales/Sales Order` and action `update`, as the first actual financial caller. The route is `txn.ts:1425–1436`. `editSalesOrder` (`salesOrder.ts:1596–1661`) already owns a transaction, advisory document lock, saved-version check, period/consumption checks, deletion, and replacement through `createSalesOrder(...,{tx,...})`. The replacement includes advance ledger and Rojmel writes at1192–1234. A seeded advance edit from100 to125 therefore proves a real financial boundary rather than metadata-only success.

Do not start by wrapping `postVoucherTx` after document rows were read/deleted, or by passing an optional session to every existing service: both make bypass/lock ordering difficult to assess. Extract the existing edit callback into `editSalesOrderTx(tx,input,voucherNo)`, retaining its complete validation and numerical/write behavior. Its internal replacement already accepts the same Tx through `OrderWriteContext`; no nested transaction is needed. Preserve the existing non-session wrapper for its explicitly internal/test/Tour callers during this bounded slice, and route this one authenticated Sales Order PUT through a new required-authority entry point. Mark every other writer, including Sales Order create/delete, as still outside this adoption. A source-level route assertion should prove this exact PUT cannot reach the old wrapper.

Saved Return incoming metadata (`savedSaleReturn.ts:542–639`) is a smaller later adoption but does not establish financial posting protection. Incoming Return preview remains read-only and does not become a numeric writer because the helper exists.

## Proposed server-only seam

New `auth/sessionContextCommand.ts`:

```ts
type SessionCommandIdentity = Readonly<{
  tenantId: string; sessionId: string; loginName: string; loginCoCode: string;
  coCode: string; lcCode: string; coYear: string | undefined;
  contextEpoch: ContextEpoch;
}>;

type SessionCommandPolicy = Readonly<{
  form: string; action: RouteAction; adminOnly?: boolean;
  scope: Readonly<{tenantId: string; coCode: string; lcCode: string;
    coYear: string; coBook: string}>;
}>;

withSessionContextCommand<T>(
  prisma: PrismaClient,
  identity: SessionCommandIdentity,
  policy: SessionCommandPolicy,
  work: (tx: Tx, admitted: Readonly<{
    context: AuthenticatedSessionContext;
    principal: Principal;
    authorization: FormAuthorization;
  }>) => Promise<T>,
): Promise<T>;
```

These inputs come from trusted route code: copy identity from the verified request's retained session, never from body/query values. The route hardcodes form/action and supplies the already-scoped business input. Detach before any await. Reject malformed/missing canonical positive BIGINT epoch, mismatched tuple, unknown authority fields, or incomplete financial scope; do not fill from the later session row. Compare company/location/year/tenant exactly, preserving absent-year semantics as undefined; the first financial policy requires a stored year. Book is a command selection, not part of the session descriptor, and remains subject to existing server book validation.

The optional browser context headers remain checked by current prehandler policy. The identity given to the helper always includes the server-verified access epoch even when a compatibility caller omitted those headers. The helper proves request-context ordering from this captured identity; absent browser headers cannot prove when a legacy UI draft was created. It neither reparses a newer cookie mid-command nor retries an old body under a newer context.

Extract `authorizeFormTx(tx,input)` in `rbac/authorization.ts`, with the old public wrapper delegating once. Preserve current admin behavior, alias selection, first row ordered by row_id, View requirement for create, and Edit/Delete/Print requirements (`authorization.ts:96–147`); no new global USER_UPDATE gate or client-supplied permission. Reuse `loadPrincipalTx` (selected-company then immutable credential-company precedence) and `validateStoredScopeTx` (exact saved scope, no defaults). Keep all these authority reads plain SQL reads, not LOGIN_MAST/USER_SET locking reads.

The first entry point, e.g. `editSalesOrderInSession(prisma,{identity,input,voucherNo})`, uses the wrapper and extracted Tx body. The callback cannot publish HTTP output, sign/refresh tokens, select scope, revoke sessions, start an independent transaction, or perform external I/O. Do not return a Tx/lease to another request or reuse it after commit. Only the wrapper's committed result reaches `run(reply,200,...)`.

## Transaction algorithm and exact guarantee

Use one `withTenant` transaction with explicit `ReadCommitted` for this first adoption; retain current timeout/maxWait defaults rather than expanding them to hide contention. `tenant.ts:17–26` binds `app.tenant_id` once. A private Tx admission routine checks that transaction-local tenant equals the immutable identity before reading authority. Do not expose a generally callable late-admission helper whose caller may already hold document/configuration locks. Refuse mismatched transaction context; never reset a tenant inside an existing business transaction.

1. **First application row lock:** SELECT the exact `(tenant_id,session_id)` from `auth_session FOR SHARE`, with full retained subject/login-company/scope/epoch, revocation and raw expiry. No business query, advisory document lock, counter allocation, settings write, or principal row lock precedes it. Multiple commands may share this lock; mutations of that session must wait. `FOR KEY SHARE` is insufficient because ordinary non-key scope/epoch/revocation changes can use a compatible non-key update lock.
2. After the lock has actually been obtained, use a separate SQL statement to evaluate `expires_at > clock_timestamp()` and revoked status. The first SELECT's target expression or transaction-start `now()` must not be used as an after-wait clock (`sessionContextSelection.ts:218–226` already explains this seam). Reject absent/wrong subject or immutable login company, revocation, expiry, malformed persisted epoch/unknown-ledger envelope, or changed scope/epoch before entering `work`. A→B→A must conflict even when tupleA matches.
3. Load the fresh current principal in this transaction, refuse password-reset-required, validate exact stored scope, and authorize the fixed form/action with `authorizeFormTx`. Do not trust prehandler/JWT rights. Compare returned context to command scope again; existing workflow validation still checks its configured book, dates, document version, children, and supported state.
4. Execute the entire financial callback using this same Tx while retaining the session SHARE lock. Existing document serialization/versioning and all business checks remain. A successful share lock is not a substitute for document locks or a universal database snapshot.
5. After the callback completes, perform a final separate SQL live/identity/epoch check before returning from the transaction callback. A session whose expiry was crossed during the work aborts the whole write set, without extending expiry, rotating JTI, touching last_used_at, setting revocation, or applying last-day-lock. This is an explicit final-statement admission boundary: the unavoidable interval from that check to COMMIT is not proof the session was still live at the exact commit timestamp. No `Date` truncation is used for authoritative timestamp comparison.
6. Commit once, then return the result. On known database rollback, all callback writes disappear. On a lost COMMIT acknowledgment or HTTP response, commit status may be unknown or already committed; no automatic financial replay, epoch rebase, or idempotency promise is added.

For a participating command and a same-session context mutation/revocation, this imposes an order: if mutation wins the conflicting session lock and commits first, the command sees its new state and refuses stale authority; if the command wins, the other transaction waits until the command commits/rolls back. The waiting mutation does not retroactively cancel the command. If the final expiry check fails, the command rolls back and the waiter proceeds. Fresh same-epoch refresh is compatible semantically but still waits on the lock; the command neither reads nor compares refresh JTI.

Errors: reuse session-invalid/revoked/expired as401; valid retained identity with changed scope/epoch returns409 `context-stale`; fresh form denial/reset requirement remains403; domain/document/version errors retain their existing mappings. SQL serialization/deadlock failures become an explicit409 `session-command-conflict` only when SQLSTATE/Prisma metadata proves that classification, with no internal retry. A timeout, connection error, or lost COMMIT response must not be mislabeled as a confirmed context conflict or rollback. Internal transaction misuse is a server error, never permission to proceed. Final route status names should be pinned by focused tests before rollout.

## Lock order against current lifecycle writers

| Operation | Current/proposed order | Consequence |
| --- | --- | --- |
| Participating financial command | one auth_session SHARE → plain scope/principal/form reads → existing document advisory/header/child/counter/ledger locks | Hold the session until the complete financial transaction ends. Never acquire another session or upgrade this lock. |
| Selection | one auth_session UPDATE → plain current/target authority reads → target CO_SET UPDATE → guarded session UPDATE; Serializable (`sessionContextSelection.ts:268–331`) | Conflicts with SHARE. Selection's settings changes stay atomic with its epoch. |
| Refresh | one auth_session UPDATE → after-lock clock/reuse decision → plain principal/scope → local signer → guarded JTI UPDATE; ReadCommitted (`sessionContextRefresh.ts:159–242`) | No command changes JTI; strict old-JTI reuse still commits revocation in its own coordinator before error. |
| Logout/revoke | auth_session UPDATE, possibly several sessions (`session.ts:229–273`) | Waits for command SHARE; never resurrects state. Multi-session writer ordering remains existing behavior. |
| Password reset/change | LOGIN_MAST UPDATE/lock → matching auth_session UPDATE (`passwordAccount.ts:66–94,111–132`) | Commands must not acquire a LOGIN_MAST row lock after session SHARE. A plain MVCC read of committed credentials avoids that direct inverse-lock cycle. |
| Login | credential LOGIN_MAST UPDATE lock → new session insert (`sessionContextLogin.ts:68–137`) | It is a separate new session and does not authorize a prior session's pending draft. |

Concrete forbidden cycle: reset holds LOGIN_MAST and waits to revoke sessionS; financial command holds sessionS SHARE then attempts LOGIN_MAST SHARE/UPDATE. Both wait. Do not attempt to make rights stable by adding that latter lock. Likewise, a participating command must not call password change/reset, selection, refresh, last-used updates, or multi-session revocation while retaining its SHARE lock. Two SHARE-holding commands that both upgrade to UPDATE can deadlock; the new wrapper must perform no session UPDATE at all.

Keep admission before order's `pg_advisory_xact_lock` (`salesOrder.ts:1325–1331`). Do not mix an old document-first service that later obtains a session lock with this session-first service. Audit every Tx callee before each later adoption; source grep alone cannot prove absence of indirect triggers/custom database locks. The first order path's inspected posting/lifecycle/numbering helpers do not reference auth_session or LOGIN_MAST, but arbitrary database triggers are not certified.

The first command locks one session only. Password reset may revoke several sessions in planner order; that existing multi-row update can still have independent contention/deadlock risks with other multi-row writers. No universal deadlock-freedom is claimed. PostgreSQL chooses conflicts and aborts as usual; preserve abort evidence and require an explicit retry with still-current authority.

## Preserved and unresolved authority boundaries

- Successful commands do not alter context_epoch, scope, receipt, immutable login company, unknown ledger context, refresh hash, expiry or last-used values. SHARE row locks may change internal tuple lock metadata; verify business text values plus xmin/ctid, not a promise of unchanged xmax/lock bits.
- `applyLastDayLockTx` remains company-selection-only. A financial command reads the existing period gate; it never invokes the company-open trigger. Selection's CO_SET lock remains row_id ordered (`lastDayLock.ts:41–47`).
- Same-session ordering does **not** serialize a settings edit/selection in another session with a financial command on this company. `posting.ts:324–355` currently reads CO_SET without a row lock. Preserving that behavior cannot be advertised as atomic period/configuration invalidation. A later configuration-lock/version protocol needs its own cross-writer contract.
- Principal/form reads include committed changes visible at admission. An unrelated role/USER_SET update not coupled to this session lock can commit after that read. A selected-company forced reset whose credential owner differs from immutable loginCoCode may not revoke this session via the current reset predicate; this too is outside the ordered revocation guarantee. Do not claim all concurrent permission changes cancel in-flight commands.
- A self password change deliberately excludes its current session (`passwordAccount.ts:85–91`); preserve that exception. An in-flight command on that same retained session is not retroactively revoked merely by password change.
- Existing old `updateSessionScope` (`session.ts:208–226`) remains an epoch-less internal export. The current HTTP selection uses the new coordinator, but a source audit must identify any future caller before claiming every context writer bumps the epoch. This helper compares both exact scope and epoch and does not repair nonparticipating writers.
- Vendor registration/edition authority is a separate hard dependency for resolving known A/B/C ledger mode and incoming closing. This helper requires no vendor classification and carries the current explicit unknown envelope unchanged. It does not wire the internal ledger observer, enable a known closing, or authorize new numeric Return writes. Existing posting `DATA_TYPE` defaults are not repurposed as session-mode evidence.

## Prospective tests and execution constraints

The adjacent literal schedules specify exact winner/waiter order, result classes, final epoch/revocation state, callback invocation, and allowed deltas. They are not runtime traces. Implement real PostgreSQL tests using dedicated test tenants and the existing isolated55433 wrapper only after a lease is granted. Use two real transactions and observed row-lock waits (owner connection/barrier or inspected blocking PID), always release in finally, preserve unchanged deadlines, and avoid mock success in place of database exclusion. Keep serializable-selection conflict handling explicit; do not silently retry it to force a schedule.

Use a saved untagged Sales Order with noncontiguous parent/child identity and an existing cash advance100. Test an actual requested125 advance: expected saved ADV_AMT125, exactly balanced cash debit/customer credit125, and matching Rojmel125 according to the existing route/service fixture. Compare this to the standalone pre-extraction service result so no new accounting formula is invented. Verify independent books/companies/tenants and sibling rows remain exact. For denied/aborted commands, snapshot all nine ORDER_WRITE_TABLES plus TEMP_BOOK_DATA, DELETE_DATA, BOOK_DATA, SRNO_MAST, CO_SET/CO_SET_NEW, scope/master/rights tables and auth_session as per-column SQL text + xmin/ctid, retaining nulls and clocks. Attribute legitimate selection/reset/refresh deltas separately rather than asserting those actors did not write.

Static/unit checks should pin one withTenant boundary, exact SQL/parameter preservation for extracted form/order Tx helpers, no nested wrappers, no callback on failed admission, final failure rollback, no auth writes, and no missing-authority HTTP branch. Real authenticated tests should cover View-without-Edit denial, fresh rights removal between prehandler and transaction, exact optional-header compatibility, and stale-header rejection. No tests, DB runs or compilers have been executed in this staging task.
