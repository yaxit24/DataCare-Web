# X13 next prerequisite: authoritative desktop session ledger mode

Status: prospective implementation preparation from read-only source review on2026-09-11. No product/schema changes, database queries, tests, browser execution, live desktop observation, license decoding or network research were performed for this note. Round10 contracts and all Round11 tested product/evidence remain unchanged. Mode/opening/closing stay unavailable in the current bill preview.

Registration identifiers and credentials are deliberately omitted. The proposed adapter consumes trusted, versioned classification results; it must not expose registration values, reproduce registration algorithms or treat a client-supplied edition/exception as authority.

## 1. What actually owns the value

`DC_Main.cs:805` declares **static string MsDataType**. It is process-wide mutable desktop state, shared by forms; it is not a column of the selected voucher, book, customer or user record. The direct assignment/explicit-reference inventory below finds writes only in `MS_OPNCOMP` and `MDI_FORM` in the inspected readable C# source. This is not proof against reflection, alternate binaries or unobserved runtime behavior.

`DC_Main.MsAcBal` at1463–1487 reads that live value while querying the selected company/location/year/account across all books. At1471 and1479, exact modeC omits the DATA_TYPE predicate; other values produce exact DATA_TYPE=mode. **C means combined eligible rows, including stored NULL/other data types; it does not mean filter stored C.** Source name-comparison/collation behavior is not established for malformed or padded aliases. SQL grouping, NULL arithmetic, time cutoff and gold/silver conversions remain governed by the frozen Round10 contract/addendum.

A second consumer demonstrates why mode cannot be introduced only as a Return request option: `DC_Main.CurBookHelp:1493–1503` filters BOOK_DATA.DATA_TYPE only for A or B, and otherwise lists all matching books. Thus a nonstandard alias code can have a different book-picker branch from the balance predicate. A future global mode must inventory affected selectors/reports; it is not a local formula preference.

Selected-book **ItmDataType** is distinct: `TR_SALE_RTN:9928–9937` reads BOOK_DATA.DATA_TYPE and defaults the book value for posting. It cannot reconstruct MsDataType. No bill POST parameter, saved header DATA_TYPE, selected book type, report dataType filter or visible mode-colored label may supply the missing session authority.

## 2. Company-open bootstrap: order and qualified conditions

The owner is `MS_OPNCOMP.tYearCode_KeyDown`, beginning509. Selected company is already established at463/469 and year/database identity at570–598 before the successful open sequence. The following is source order, not a new web default:

| Stage | Primary source | Required fact / effect |
| --- | --- | --- |
| Initial edition and registration observation | MS_OPNCOMP612–621 | Set MsSoftType=L; query HDD_MAST with nonblank REF_NO, no company predicate/order; absent rows opens registration UI and leaves this open path before mode initialization; otherwise use first row. |
| Registration validation/classification |634–652, CoRegNo starts1798 | Invoke existing registration helper, then establish edition through the source recognized-edition branches and fallbackL. A single-character/member branch and the normal registration-derived branch differ. Do not port or expose registration mechanisms here. |
| Company settings and other open checks |657 onward, through1457 | Many operations precede mode assignment. A provisional edition alone does not prove a successfully completed company-open context. |
| Default mode |1459 | Assign C. This is reached code, not a license/session-missing fallback. |
| Edition override |1460–1462 | If bootstrap edition is A or E, assign A. |
| Qualified registration exception |1464–1476 | Membership in the explicit nine-entry installation exception set assigns C after the edition override. Identifiers are not reproduced here. |
| Later open/exit and form activation |1478–1498,1503–1510 | Separate qualified registration/user validity checks may exit the application; source applies configured previous-day lock and then shows MDI_FORM. A resolved mode assignment does not prove the whole open succeeded. |

A server mode adapter should receive **completed-bootstrap eligibility**, the edition actually used at1459–1462 and a trusted exception classification/revision. For A/E, an unknown exception classification means unresolved. With a fully proved successful non-A/E bootstrap, both ordinary and force-C branches endC, so the exception is immaterial to that particular mode result; this is source control-flow reasoning, not permission to default a missing edition or failed open toC. Keeping the first persisted profile stricter (requiring complete classification for every bootstrap) is acceptable if named as a containment policy.

HDD_MAST's unqualified, unordered first-row read is not a deterministic authority when imports contain multiple physical candidates. Require a separately resolved installation observation or deterministic reconciliation; do not silently choose the newest, minimum, first SQL row, selected-company row or an edition already inferred for another feature. Preserve only classification/provenance hashes publicly.

## 3. Bootstrap edition and current command edition are different observations

`MDI_FORM_Load` starts11048, after `MS_OPNCOMP:1510` shows it. It subsequently mutates **MsSoftType** without assigning **MsDataType**:

-11155–11193: registration/time-qualified edition overrides.
-11195–11213: registration/company-qualified overrides.
-11224–11247: manufacturing mode plus single-character registration conditions can set editionS.

These branches can change whether later A/E-only commands are available while leaving the already established ledger mode unchanged. Current edition, a registration substring, server calendar date, or current manufacturing setting alone cannot recreate mode history. The adapter needs separate `bootstrapEdition` and `commandEdition` provenance/epochs when their distinction matters. Expiry of a qualifying date alone is not evidence that an already running desktop process reran MDI_FORM_Load and changed state.

There is no direct MsDataType persistence write in the traced setters. Reopening a company/year reaches a new bootstrap; it must not be modeled as restoring a per-book last mode. Whether every same-context dialog invocation reruns the complete load, and whether an existing MDI form reruns its Load event, require runtime observation. The proposed web `context/select` transition below deliberately makes its own reset policy explicit.

## 4. Mutable MDI commands and unresolved keyboard boundary

`MDI_FORM` registers KeyDown at4352, initializes CodVal blank at4356 and sets KeyPreview=true at6967. The handler begins12313; readable decompilation contains unknown-IL/key-comparison annotations. Its relevant phases are:

1. `OpenForms.Count<=2` at12530 encloses Ctrl+A..Z→CodVal mappings12616–12719. Other shortcuts may run earlier in the same handler.
2. The editionA/E gate at12721 surrounds the mode mutation branches, **outside** the OpenForms-count gate.
3. The special A/B/C key branch12723–12724 first queries literal company01 CONV_MAST for CON_CODE=A at12726–12727.
4. If that sentinel set is absent,12728–12745 selects A/B/C from CodVal, otherwise falls back toA.
5. If the sentinel exists,12749–12757 looks up CON_NAME=CodVal in company01, assigns first result CON_CODE, otherwise falls back toA.
6. A different nonblank CodVal uses the general alias lookup12784–12790; a missing alias **retains the previous mode**, unlike the special A/B/C fallback.
7.12760–12782 and12792–12814 change display text/visibility/color. A is hidden; B is red; C uses green in one branch and LightSeaGreen in the other. Other codes retain prior presentation branches. This label is not mode authority.
8.12817–12823 has a qualified menu-visibility exception, then12824 clears CodVal. There is no row/bill recalculation or mode-history persistence in the mutation block itself.

**Do not summarize this as 'mode can change only when no child forms are open'.** Because the special branch is outside the count gate, a delivered Ctrl+A/B/C event with CodVal still blank can reach a fallback/blank-alias path. Whether child controls/MDI KeyPreview deliver that event, how the decompiled masked key comparisons behave, and whether handled/Alt combinations reach the handler require IL and actual desktop key-routing evidence. This note does not propose reproducing raw keyboard shortcuts in the web.

A next pure resolver can accept an already classified semantic command (`special-letter` versus `general-alias`) and immutable trusted observations, while keeping the unknown Windows key classifier outside its accepted input profile. Explicit web controls may later dispatch server-advertised commands under a named profile; that would be an intentional web interaction, not measured shortcut parity.

## 5. Alias identity and deterministic containment

Source queries use **literal company01** of the current application database, no location/year predicate. Web observations must add tenant ownership but preserve that source company; do not substitute selected company, company00 or a configuration fallback. Observe complete physical sentinel and alias candidate sets in one transaction.

Current Prisma CONV_MAST at1300–1318 has surrogate row_id, nullable CO_CODE and nullable255-character CON_CODE/CON_NAME. It does not enforce unique canonical mode mappings. AC_DATA.DATA_TYPE is nullable varchar1 (schema36). Source takes the first match without ORDER BY and concatenates CON_CODE with empty text. That is not a safe deterministic mapping when rows are duplicate, NULL, padded, case-colliding or longer than the ledger representation.

Proposed first profile:

- Require exactly one canonical physical alias row for a mapped command; preserve discovered normalized/case/padding collisions as diagnostics rather than guessing SQL Server collation.
- Keep sentinel absence separate from sentinel ambiguity; ambiguity must not be interpreted as absence and trigger defaultA.
- Initially admit A/B/C outputs only; other raw outputs remain inspectable/unsupported until their business/code/filter behavior is separately approved. This is explicit containment, not a claim that the desktop only permits A/B/C.
- Preserve special-command fallbackA versus general-alias missing→retain. Never manufacture a successful transition from an unresolved catalog, unknown command edition or absent current mode needed for retain.
- Tokenize relevant complete catalog candidates and physical revisions; no pagination/default row limit in the authority observation. Do not return registration/entitlement source rows to a normal operator.

## 6. Current web gap and narrow integration points

| Current file | Established behavior | Missing mode ownership |
| --- | --- | --- |
| auth/session.ts7–18,38–73,75–140 | Tenant/session/login/current company/location/year, expiry/revocation; persisted auth_session read per request | No mode, source profile, bootstrap context, mode generation or transition history. |
| auth/session.ts143–205 | Locked refresh-token rotation in the same session | No mode initialization/reset; refresh must not become a hidden bootstrap. |
| auth/session.ts208–226 | Persists company/location/year via UPDATE | No atomic mode-context reset/generation change. |
| auth/jwt.ts8–28,79–108 | Access/refresh claims carry identity/scope/rights and session ID | No authoritative mode claim; a future JWT value cannot replace fresh server state. |
| app.ts288–314 | Validates stored session against JWT scope, reloads principal rights | This auth transaction precedes the business snapshot; a future adapter must revalidate mode/scope coherently in the balance transaction. |
| app.ts475–518;706–742 | Login creates scoped session; context/select validates scope, applies last-day lock, updates session and issues access cookie | No authoritative desktop bootstrap or mode transitions. |
| auth/businessScope.ts125–166 | Validates company/location/year availability | Book selection is not a mode bootstrap and scope resolution currently uses separate tenant callbacks. |
| Prisma AuthSession3791–3809; LOGIN_MAST3772–3788 | Scope/session/account persistence | Neither is an existing mode store. |
| BusinessScope.tsx5–9 | Server-authenticated company/location/year context | No public mode/revision signal to invalidate preview state across tabs. |
| saleReturnIncomingConfiguration.ts535–550 | Observes settings/new settings/columns/books/years | Does not pass an authoritative edition observation; cannot supply bootstrap/history. |

Current Round11 bill replay deliberately uses `unresolved-session-ledger-mode-v1` and unavailable opening/closing. Preserve that response/profile until a complete trusted adapter is implemented and independently verified. The full source contract remains broader than any new session setting alone.

## 7. Proposed server state and transitions (not implemented)

Prefer an explicit session-owned child record, keyed by `(tenant_id,session_id)`, or equivalently scoped columns owned by the auth-session service. One shared tenant/company default must not overwrite independent operator sessions. Fields should include:

- `status: unresolved|resolved`, `mode: A|B|C|null`, a nonblank unavailable reason when unresolved, semantic profile version.
- Exact current company/location/year and a monotonic **context generation**, distinct from scope strings; A→B→A must not reuse an old mode observation.
- Monotonic **mode generation**, initialized even for unresolved state; no JavaScript Number conversion of database counters.
- Initialization/last-transition kind and trusted bootstrap/command-edition/exception/catalog provenance references/hashes; no public registration values.
- Append-only transition audit: previous/next generation, actor/session/context, semantic command identifier, result/classification version, timestamp. Keep this separate from accounting entries.

A proposed GET `/context/ledger-mode` can return status/mode/reason/opaqueversion/scope and server-advertised allowed command IDs. A proposed POST accepts only `{version,commandId}` and exact expected context; it cannot accept raw mode/edition/registration/aliases/policy. Route and RBAC integration require separate authorization design: existing Sales Return View does not automatically authorize changing a process-wide business mode. Unknown change authority stays false. These are proposed endpoints, not current routes.

Transition sequence:

1. **New authenticated session / explicit company open:** after scope and fresh rights validation, lock/create session-mode state and resolve completed bootstrap facts inside a coherent transaction. Unknown facts persist unresolved, never defaultA/C. Record new context/mode generations. Scope update plus mode reset must commit atomically; preserve auth revocation/refresh semantics.
2. **Explicit command:** lock live auth-session and mode state; check expiry/revocation/full context/current version/change capability. Resolve effective command edition and complete literal-company01 catalog in that transaction. Run pure semantic transition. An unsupported command leaves business mode unchanged and returns a diagnostic; an accepted transition, including deliberately accepted same-value selection, receives a new monotonic mode generation and audit entry. That generation policy is web concurrency containment, not a desktop setter side effect.
3. **Context switch / re-open:** define an explicit bootstrap/reset transition, do not restore a per-book cached mode. A→B→A invalidates old observations even if final mode strings agree. Do not silently infer that token refresh, selecting a voucher or browser reload reopens the desktop company.
4. **Refresh/revocation/logout:** refresh keeps resolved mode/history for the same session; expired/revoked sessions cannot resolve or mutate it. Separate logins remain independent. No stale claim can resurrect a revoked mode.
5. **Return balance preview:** use a transaction-local reader in the same RepeatableRead snapshot as saved document/config/master/ledger observations; recheck current session/fullscope/mode generation. Include mode/context/provenance generations in the outer replay hash. GET may show unavailable mode, while POST reobserves before any transient replay. The client cannot provide a replacement mode or opening amount.
6. **UI invalidation:** publish the server mode/context version with current context; explicit mode change disposes or requires deliberate reload of open financial previews/drafts and invalidates old journals. Cross-tab stale POST must409. The desktop mutation block itself does not reprice existing forms, so this web containment requires a named interaction policy and runtime/business acceptance rather than a false claim of exact focus/history behavior.

A server-database mode row permits a coherent mode+ledger snapshot. If an entitlement authority remains external, pin a durable classification revision when initializing the session and define refresh/revalidation transitions; do not claim an HTTP entitlement call and SQL ledger read were one database snapshot. Absent-row hashing alone is not durable ABA protection; mode generations and explicit mutation serialization are required before any future financial writer.

## 8. Executable next-step boundaries and verification matrix

The next feasible isolated implementation is **pure bootstrap/semantic-transition resolution**, with injected trusted classifications and literal catalog observations, immutable inputs, explicit resolved/unsupported results and source provenance. It must not infer a live session, decode registration, expose shortcuts, change auth or query a balance. Independently author literal expectations before executing the helper.

| Vector | Expected bounded outcome |
| --- | --- |
| Proven eligible bootstrap A or E + exception false | A |
| Proven eligible bootstrap A or E + exception true | C |
| A/E + exception unknown, edition unknown, or successful open unknown | unresolved, no fallback |
| Proven eligible non-A/E bootstrap | C by reached source branches; optional stricter-classification containment explicitly named |
| Current command edition changes after bootstrap | Existing mode retained until a classified accepted command; do not recompute bootstrap |
| Command edition not A/E or unresolved | No accepted transition in initial command profile |
| Special A/B/C command + definitively absent sentinel | Select corresponding mode from proved semantic CodVal; ambiguous/raw keyboard state refused |
| Sentinel exists + unique canonical matching alias | Resolve exact supported CON_CODE |
| Special command alias missing | Source fallbackA only under fully resolved special branch |
| General alias command missing | Retain previous resolved mode; unknown previous mode cannot be invented |
| Duplicate sentinel/alias, SQL NULL/padding/case collision or unsupported output | Explicit unsupported result, immutable previous state |
| Source company02 selected, mapping only in company01 | Use tenant-owned company01 mapping; do not search company02 fallback |
| Two concurrent same-version mode changes | One accepted; stale second409; no mixed audit/state |
| A→B→A, same-value command, refresh and separate login | Monotonic invalidation where specified; refresh preserves; separate sessions independent |
| Scope switch during balance GET/POST; rights revoked | Recheck within snapshot; reject stale context/mode; preserve client draft until explicit reload |
| ResolvedC vsA/B with NULL and other stored DATA_TYPE | Combined predicate differs from exact mode equality; no stored-C-only shortcut |

After pure proof, add serialized auth/session-mode DB/HTTP tests and required schema/RLS/backup/inventory checks as a distinct implementation batch. Use existing auth.session.test.ts, auth.jwt.test.ts, rbac.authorization.test.ts and context/app security tests as regression anchors; Return v1/v2 tests must remain intact. A later actual browser needs two independent clients, context/command versions, dirty-preview invalidation and explicit reload, without HTTP mocks. Do not count those as done in this note.

## 9. Still requires original runtime or business authority

- Successful vendor entitlement/classification source and completed-bootstrap evidence, including qualified exception decisions; no guessed edition/default.
- Actual MDI key routing, masked-key IL branches, child-form count semantics and modifier collisions; the semantic helper is not a shortcut port.
- Original SQL Server collation/duplicate-first-row behavior and legitimate alias outputs beyond initial A/B/C containment.
- Desired web authorization and operator terminology for global mode changes; a source edition gate alone is not a complete web permission policy.
- Reopen/current-form/history behavior, per-session versus cross-tab interaction and effective-edition refresh rules.
- Full MsAcBal monetary **and gold/silver** sum/NULL/Format behavior, exact source clock provenance, ledger completeness and zero-color history. Resolving mode alone cannot close those balance prerequisites.
- Numeric Return writing, accounting/stock/source admission, payment/refund allocation and end-to-end business acceptance remain open.

## 10. Source inventory and hashes

Paths below are relative to the extracted folder. Hashes pin static inspected bytes, not executed acceptance.

Direct assignment/explicit-ref scan inspected 204 readable C# files and found 10 entries:

- `unified/src/csharp/DataCareNext/MDI_FORM.cs:12732`
- `unified/src/csharp/DataCareNext/MDI_FORM.cs:12736`
- `unified/src/csharp/DataCareNext/MDI_FORM.cs:12740`
- `unified/src/csharp/DataCareNext/MDI_FORM.cs:12744`
- `unified/src/csharp/DataCareNext/MDI_FORM.cs:12753`
- `unified/src/csharp/DataCareNext/MDI_FORM.cs:12757`
- `unified/src/csharp/DataCareNext/MDI_FORM.cs:12790`
- `unified/src/csharp/DataCareNext/MS_OPNCOMP.cs:1459`
- `unified/src/csharp/DataCareNext/MS_OPNCOMP.cs:1462`
- `unified/src/csharp/DataCareNext/MS_OPNCOMP.cs:1475`

| Inspected file | SHA256 |
| --- | --- |
| `unified/src/csharp/DataCareNext/MS_OPNCOMP.cs` | `180f295f9595dfc7c28ee34629563889c943eea0a0afc7c7a9baa519a11c4561` |
| `unified/src/csharp/DataCareNext/MDI_FORM.cs` | `cb91085c50d07a07ae5c5a8e6982ef6f9a2c533e2b55d61fc8c35f093f5dfbbc` |
| `unified/src/csharp/DataCareNext/DC_Main.cs` | `7ff3543a78440db0f6f18eaf442aade59a105fcb398c0ba7fd9f9c53c195a688` |
| `unified/src/csharp/DataCareNext/TR_SALE_RTN.cs` | `cdee9c37772522727d08c86baee71a46daa7b11cdfdf2eeb1ef656d80dfbb7a1` |
| `web/apps/api/src/modules/auth/session.ts` | `17765f43964137139d582695cc0d10e3713227b8e118070e6f3e4a07fdb63bf0` |
| `web/apps/api/src/modules/auth/jwt.ts` | `4bd2d709bcd6ec64d3734822972932aed4bcd1797422815caf4a8eaa90de3169` |
| `web/apps/api/src/modules/auth/businessScope.ts` | `7eca43829be9e9034be1779cf33760d94deb92dd55d6ec99d67b2a6d1310535e` |
| `web/apps/api/src/modules/auth/auth.service.ts` | `cb6269a6b3793d9dc7163bbd1f144336f12da461cdec7177e620b5f5f74f026e` |
| `web/apps/api/src/app.ts` | `919f79ce65b1580b35f7a1bc5be7aeab8374a52c6c002bfa4b704b8c0b7c793a` |
| `web/apps/api/src/modules/sales/saleReturnIncomingConfiguration.ts` | `2352433c0fb065d5ef17c227a594ba887875c7d024817848da3056c852466505` |
| `web/apps/api/src/modules/sales/saleReturnBillReplay.ts` | `b78bbed89d97a401227fa1399448b3b56081c07676986621b89e697ef968d953` |
| `web/apps/web/components/BusinessScope.tsx` | `ffe8f4922dd0c65e7dc9bbb91ae8cdd10b67edd8b1349ef57388ee64d2119213` |
| `web/packages/db/prisma/schema.prisma` | `158aa2c66db0ff7b5b07931d853d73cb2aad0973880a0d7385eee6695c973754` |
| `parity-plan-2026-09-10/evidence/implementation-2026-09-11-round10/x13-aggregate-trusted-observation-contract.md` | `7240e8f6b3e0ea5b25ddd98535862d6e7a8cbf50cd981caccf049ef35b707b6b` |
| `parity-plan-2026-09-10/evidence/implementation-2026-09-11-round10/x13-aggregate-trusted-observation-source-addendum.md` | `9f41889ef665c3a0934412c619921bf5788b853269967ea81e8ca267f09347ae` |
