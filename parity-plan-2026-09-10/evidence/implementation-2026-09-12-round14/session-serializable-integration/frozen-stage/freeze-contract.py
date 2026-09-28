import json,hashlib,pathlib
s=pathlib.Path('/tmp/datacare-session-serializable-command-staged')
r=pathlib.Path('/Users/yakshitsavaliya/Desktop/imodule-extracted')
identity=dict(tenantId='serial-command-unit',sessionId='11111111-1111-4111-8111-111111111111',loginName='operator',loginCoCode='01',coCode='01',lcCode='01',coYear='2024-2025',contextEpoch='7')
# Literal admission decisions specified before the new coordinator exists.
rows=[
('ready','Serializable; canonical subject; View Y/Edit Y','success',200),
('numeric-epoch','epoch is numeric 7','session-invalid',401),
('leading-zero-epoch','epoch is text 07','session-invalid',401),
('overflow-epoch','epoch exceeds positive PostgreSQL BIGINT','session-invalid',401),
('authority-extra','identity includes isAdmin','session-invalid',401),
('missing-year','identity has own coYear undefined','scope-incomplete',409),
('scope-mismatch','policy company02; retained company01','scope-mismatch',409),
('mutable-action','policy includes action read','invalid-serializable-command-policy',500),
('mutable-form','policy includes another form','invalid-serializable-command-policy',500),
('admin-override','policy includes adminOnly true','invalid-serializable-command-policy',500),
('wrong-tenant','transaction tenant differs','invalid-transaction-context',500),
('wrong-isolation','transaction reports read committed','invalid-transaction-context',500),
('repeatable-isolation','transaction reports repeatable read','invalid-transaction-context',500),
('missing-session','no exact scoped session','session-invalid',401),
('foreign-subject','immutable credential login company differs','session-invalid',401),
('stale-epoch','database8 versus bearer7','context-stale',409),
('scope-aba','same company but database9 versus bearer7','context-stale',409),
('malformed-ledger','caller cannot activate known mode A','session-invalid',401),
('revoked','post-lock SQL revoked true','session-revoked',401),
('expired','post-lock SQL unexpired false','session-expired',401),
('principal-missing','current principal absent','session-invalid',401),
('forced-reset','fresh selected principal requires password reset','password-reset-required',403),
('view-denied','View N/Edit Y','forbidden',403),
('update-denied','View Y/Edit N','forbidden',403),
('year-unavailable','stored configured year absent; never default','year-unavailable',409),
('company-forbidden','stored company exists but company rights false','company-forbidden',403),
('final-expiry','callback returns after SQL expiry','session-expired',401),
('final-epoch','callback changes epoch in same transaction','context-stale',409),
('final-ledger','callback changes unknown ledger reason','context-stale',409),
('raw-serialization','raw40001 during row lock','session-command-conflict',409),
('prisma-conflict','P2034 at commit','session-command-conflict',409),
('wrapped-serialization','P2010/meta40001','session-command-conflict',409),
('raw-deadlock','raw40P01','session-command-conflict',409),
('wrapped-deadlock','P2010/meta40P01','session-command-conflict',409),
('connection-failure','08006 unknown connection outcome','propagate-original',None),
('unknown-commit','unclassified commit acknowledgment failure','propagate-original',None),
]
schedules=[
('D01','No-op admitted callback; SERIALIZABLE, fixed Return update; all scoped raw/xmin/ctid unchanged','success; one callback; no auth writes'),
('D02','Command SHARE first; callback marker write; selection UPDATE waits until commit','command marker committed then selection epoch8; no command auth write'),
('D03','Selection UPDATE uncommitted before command snapshot; command SHARE waits; selection commits','command409 known serialization before callback; selection remains8; no marker change'),
('D04','Actor holds session UPDATE lock without changing tuple; expiry passes during command wait','401 session-expired after lock; no callback; exact raw unchanged'),
('D05','Actor updates marker after command first read; command rereads same row in same snapshot','both reads before; actor change committed; no latest-at-response claim'),
('D06','Command SHARE held; actual refresh waits','command succeeds then actual refresh rotates JTI; command did not rotate'),
('D07','Command SHARE held; actual logout waits','command succeeds then revoked logout'),
('D08','Command SHARE held; reset holds LOGIN then waits session','command completes without later LOGIN lock; actual reset succeeds'),
('D09','Callback writes marker then natural expiry before final SQL','401 final expiry; marker and all raw/xmin/ctid rollback'),
('D10','selected company02; immutable login company01','admitted selected principal company02; session unchanged'),
('D11','Committed FRM_EDIT=N before snapshot while FRM_VIEW=Y','403 update denied before callback; unchanged raw'),
('D12','USER_SET edit revocation commits after snapshot','first snapshot retains EditY; subsequent command403; no universal current-rights guarantee'),
('D13','Callback marker DML then explicit throw','original error; exact full rollback'),
('D14','Prohibited callback mutates same session epoch then returns','409 context-stale; session and marker rollback'),
('D15','Two Serializable commands share session; both read PARTY+PEER then independently update one different marker','exactly one success and one409 SSI; each callback once; one marker changes; auth unchanged'),
('D16','Callback reads PARTY, independent actor commits PARTY update, callback attempts same row update','409 serialization; actor value preserved; no retry; auth/foreign rows unchanged'),
('D17','Prohibited callback changes only unknown ledger reason plus marker','409 context-stale; entire candidate transaction rollback'),
]
f={'version':'session-serializable-return-update-v1','authoredBeforeNewImplementation':True,'identity':identity,'policy':{'scope':dict(tenantId=identity['tenantId'],coCode='01',lcCode='01',coYear='2024-2025',coBook='R14')},'unitCases':[dict(id=f'S{i+1:02}',scenario=a,given=b,expected=dict(code=c,statusCode=d)) for i,(a,b,c,d) in enumerate(rows)],'databaseSchedules':[dict(id=a,schedule=b,expected=c) for a,b,c in schedules]}
p=s/'web/apps/api/test/fixtures/sessionSerializableCommand.independent.json';p.write_text(json.dumps(f,indent=2)+'\n')
(s/'implementation-contract.md').write_text('''# Separate Serializable Return update admission prerequisite

This stage adds only an internal transaction coordinator. No Return route/adopter, numeric writer, financial effect builder, schema change, mode authority, closing authority or external side effect is added. Existing ReadCommitted six-order and RepeatableRead preview helpers remain byte-identical. The frozen Round13 writer contract and mandatory stock-identity erratum remain prerequisites to an eventual financial adopter: MAIN_STOCK SR_NO=2 and ISR_NO=incoming SR_NO, not the erroneous shorthand in the original contract.

## Typed interface

`SESSION_CONTEXT_SERIALIZABLE_COMMAND_VERSION = 'session-serializable-return-update-v1'`.
`withSessionContextSerializableCommand(prisma, identity:unknown, policy:{scope:{tenantId,coCode,lcCode,coYear,coBook}}, work(tx, {context,principal,authorization}))` returns the callback result only after the transaction commits. Export identity/policy/admission types and `SessionSerializableCommandError(code,statusCode,message?,form?,action?:'update')`. Policy has exactly scope; fixed form `Sales/Sales Return`, fixed action `update`; form/action/adminOnly extras are invalid500. Identity is the existing eight-own-data-field retained session shape, with own coYear permitted undefined but incomplete scope409. All strings retain exact text and existing identity maximum lengths; no epoch coercion (canonical positive BIGINT). Policy scope requires all five nonempty text fields within database identity widths. Blank scope409, malformed/oversized policy500. No selected-book validation is invented: complete coBook is bound policy context; the future adopter must validate exact Return book and document/profile in this same transaction.

Detach own enumerable plain descriptors synchronously before the first await. Accessors, prototypes, symbols and unknown fields refuse; reflection failures are contained without invoking getters. Valid caller data is neither mutated nor frozen. Freeze detached context/ledger/principal/rights/authorization passed to work. Principal loginCoCode can be selected credential owner and must not replace immutable session loginCoCode.

## Transaction and authority sequence

One `withTenant` Serializable transaction; verify tenant binding and actual isolation. The first application-row lock is exact tenant/session `auth_session FOR SHARE`. Separate SQL `expires_at > clock_timestamp()` after row-lock acquisition (subject first, then revoked/expired, then complete identity/scope/epoch/unknown-ledger checks). Fresh nonlocking loadPrincipalTx; refuse missing principal/reset; exact validateStoredScopeTx without defaults; fixed Return update authorizeFormTx. Existing authority semantics remain unchanged (including USER_SET lookup company behavior); this is not a new rights model.

Run callback on that same Tx, then reread all subject/scope/epoch/ledger/revocation/SQL-live fields. Any mismatch/failure rolls back callback writes. Hold SHARE through COMMIT. No nested transaction, session/JTI/receipt writes, lock upgrade, LOGIN_MAST row lock, external side effect or auto-retry. The callback may perform only its separately approved business plan. This generic Tx type cannot mechanically prohibit callback misuse; controlled tests demonstrate rollback rather than claim a sandbox. The module itself contains SELECT only.

Tenant setup/binding may establish the Serializable snapshot before SHARE. A session UPDATE committing after snapshot while SHARE waits normally produces40001, mapped409, not a refreshed context. Principal/configuration observations are as of the snapshot, not latest-at-response. Nonparticipating rights/config writers can commit after it; Serializable does not mean every overlapping writer aborts, or every phantom is synchronously blocked. The final clock check is the final SQL statement boundary, not an exact later COMMIT-time guarantee. Session SHARE serializes with cooperating lifecycle UPDATE/DELETE but not every unrelated business writer.

Known raw40001/40P01, PrismaP2034 and P2010 meta40001/40P01 map `session-command-conflict`409 exactly once. PrincipalUnavailable→401; ScopeError preserves code/status; FormForbidden→403 with fixed update/form; arbitrary callback/transport/ambiguous commit errors propagate unchanged. No successful commit/recovery is inferred from a connection loss. Financial operation idempotency/receipts remain a separate future contract.

## Independent evidence and tests

The adjacent literal fixture is authored/frozen before this new module.36 admission outcomes and17 actual PostgreSQL schedules. Unit harness may reuse existing scripted-query mechanics, not expectations. Real tests use only isolated55433 owner fixtures/runtime app_user, two tenant sentinels, raw JSON text plus xmin/ctid snapshots, actual selection/refresh/logout/reset, observed pg_stat_activity lock waits, barriers raced against operation settlement and finally release/drain. Callback marker DML is synthetic rollback/SSI proof, not Return financial-effect acceptance. D15 requires a real read/write dependency cycle (both read both rows, write disjoint rows) with one survivor, no mocked SQLSTATE; D16 proves same-row concurrent update refusal. Unit conflicts separately test all mapped codes and ambiguous errors. No execution is claimed by staging.
''')
paths=['web/apps/api/src/modules/auth/sessionContextCommand.ts','web/apps/api/src/modules/auth/sessionContextReadSnapshot.ts','web/apps/api/src/modules/auth/businessScope.ts','web/apps/api/src/modules/rbac/authorization.ts','web/apps/api/src/modules/auth/sessionContextValue.ts','web/apps/api/src/modules/auth/sessionContextAccess.ts','web/packages/db/src/tenant.ts','web/apps/api/test/sessionContextCommand.test.ts','web/apps/api/test/sessionContextCommand.db.test.ts','web/apps/api/test/sessionContextReadSnapshot.test.ts','web/apps/api/test/sessionContextReadSnapshot.db.test.ts','parity-plan-2026-09-10/evidence/implementation-2026-09-12-round13/return-next-write-contract/implementation-contract.md','parity-plan-2026-09-10/evidence/implementation-2026-09-12-round13/return-next-write-contract-review/review.md','parity-plan-2026-09-10/evidence/implementation-2026-09-12-round13/return-next-write-contract-review/mandatory-stock-identity-erratum.json']
h=lambda p:hashlib.sha256(p.read_bytes()).hexdigest()
m={'stage':'preimplementation-frozen','fixture':{'path':str(p.relative_to(s)),'sha256':h(p),'unitCases':len(rows),'databaseSchedules':len(schedules)},'contract':{'path':'implementation-contract.md','sha256':h(s/'implementation-contract.md')},'sources':[{'path':x,'sha256':h(r/x)} for x in paths]}
(s/'fixture-freeze.json').write_text(json.dumps(m,indent=2)+'\n')
print(json.dumps({'fixture':h(p),'freeze':h(s/'fixture-freeze.json'),'contract':h(s/'implementation-contract.md')}))
