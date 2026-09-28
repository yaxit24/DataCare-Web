# X13 Round12 handoff and remaining acceptance

## Current result and exact boundary

Round12 implements two prerequisites: the pure session ledger-mode bootstrap/semantic-command resolver in `web/packages/core/src/sessionLedgerMode.ts`, and the internal transaction-local ledger observation in `web/apps/api/src/modules/shared/desktopAccountBalance.ts`. Reuse them; do not reimplement their source branches or substitute generic balance functions. The pure resolver's independent focused suite passes104 tests and its strict test compiler passes. The ledger reader passes54 dedicated DB tests and a separate14-file420-test regression run. These are scoped, overlapping engineering results; final workspace/API/build/browser evidence belongs to the coordinating progress/checkpoint record and is not claimed here.

**No auth/session adapter, mode-changing endpoint, mode UI or bill-closing integration was added.** The current Return bill service still uses `unresolved-session-ledger-mode-v1`, unavailable opening, and unavailable closing. Its existing row and bill preview contracts, metadata writer, profile exclusions and disabled numeric/stock/financial save authority remain intact. A successful pure mode result or internal ledger observation is not authenticated authority to expose a balance or save a document.

Read the frozen Round11 `x13-session-ledger-mode-next-contract.md`, the Round12 `session-ledger-mode-implementation.md` and `session-ledger-mode-next-adapter-seam.md`, and `x13-account-balance-observation-contract.md`. The independent test/fixture and DB manifests pin their source identities. Checkpoint35 remains the immutable prior baseline.

## Reusable contracts

`bootstrapSessionLedgerMode(unknown)` and `transitionSessionLedgerMode(unknown)` use version `session-ledger-mode-semantic-v1` and profile `trusted-bootstrap-and-commands-abc-v1`. Inputs contain exact plain-data context, known/unknown versioned facts, and complete physical catalog observations. Successful bootstrap facts are not inferred from login, selected book or a missing registration observation. The seven supported source editions are L/B/S/U/P/A/E; A/E normally initializesA, the qualified exception overrides toC, and a completed non-A/E branch resolvesC even when that exception is immaterial/unknown. Unknown needed facts remain unresolved.

Current command edition is distinct from bootstrap edition. Already-classified specialA/B/C and generalD–Z aliases are supported; Windows key classification is not implemented. Catalog ownership is literal company01 within the tenant's application database, even when selected company is02. Special missing-alias fallbackA and general missing-alias retention are different outcomes. Relevant duplicates/noncanonical aliases, incomplete observations and unsupported output modes refuse without changing a valid previous state. Accepted same-valued assignments and retention append proofs. The helper revalidates supplied proof consistency; it cannot establish authenticity, freshness or completeness of externally supplied history.

The pure helper's history100/catalog1000/depth24/200,000-value/8MiB limits are explicit web resource bounds. At a publication boundary it must preserve a valid rereadable previous state. Do not silently truncate history/catalogs, reset mode, drop proof records, page an authority observation, or replace an input-limit result with a successful transition. Durable auditing and any safe compaction policy need their own future adapter contract.

`observeDesktopAccountBalanceTx(tx,input)` uses version `desktop-ms-ac-bal-observation-v1` and profile `canonical-postgresql-fixed-decimal-v1`. It accepts a trusted internal tenant/company/location/year/account, already-qualified local whole-second cutoff, and modeA/B/C. It verifies a matching tenant-bound RepeatableRead or Serializable transaction. One SQL statement observes the complete physical dependency set and both aggregate phases; no separate nested tenant transaction is required.

The reader uses all books under that scope/account. Opening is strictly before the cutoff and helper closing is inclusive. C omits the DATA_TYPE filter and therefore includes storedNULL/other modes; A/B use exact filtered semantics. `SUM(CR_AMT-DR_AMT)` subtracts before summation. Gold/Silver apply the original nested CASE, including literal zero for other types and negation for any non-plus sign. No grouped row preserves the source's initialized zero; a grouped unknown monetary or required metal aggregate remains unsupported. Exact raw/physical observations and the observationVersion support coherent replay binding, not history-sensitive universal ABA detection.

## Current auth/session seams to change deliberately

| Current code | Established behavior | Required adapter work |
| --- | --- | --- |
| `schema.prisma:3791–3809` AuthSession | Composite tenant/session owner; login company separate from selected co/lc/year; refresh hash, expiry/revocation | Add owned context epoch and mode generation/state/provenance/audit, with schema/RLS/backup/reset contract. Current coYear storage is nullable varchar9; the pure transport bound does not widen it. |
| `auth/session.ts:75–121` createAuthSession | Creates scoped session in its own tenant transaction | Establish initial unresolved/resolved bootstrap state atomically from approved trusted facts. A login success alone is not completed desktop-open evidence. |
| `auth/session.ts:124–140`, `app.ts:278–318` | Live session checks plus JWT/stored-scope comparison and fresh principal load | Preserve these checks. Re-read authoritative live session/mode/full context inside any dependent business snapshot; an earlier middleware transaction does not bind a later ledger observation. |
| `auth/session.ts:143–205` refresh rotation | Locks refresh session, rejects reuse and commits revocation before reporting it | Retain mode/history for the same session; do not bootstrap on refresh. Preserve revocation-on-reuse semantics. |
| `auth/session.ts:208–226`, `app.ts:707–751` context select | Scope validation, last-day lock and session scope update are currently separate calls; then access cookie is issued | Design one explicit scope/mode reset transaction and expected epoch. Reconcile last-day-lock effects before claiming completed-open atomicity. Issue token only after commit; provide readback recovery after a lost response. |
| `auth/session.ts:229+` revokeSession and related callers | Marks existing session revoked | No previously resolved mode or stale JWT can revive it. Define mode retention for audit separately from eligibility to read/change it. |
| `auth/jwt.ts`, `BusinessScope.tsx:5–9` | Session/scope claims and UI context have no mode epoch | JWT/UI values can invalidate displays, but cannot replace fresh persisted mode authority. Scope strings alone cannot distinguish A→B→A. |

A future child record keyed by tenant/session is reasonable, but no schema choice is already implemented. Context generation and mode generation must remain separate and exact; do not route database counters through JavaScript Number. Reopen/same-scope selection semantics need an explicit policy. A scoped voucher load, token refresh or browser reload must not silently become a company-open reset.

## Smallest next integration slice

1. **Settle trusted facts and change authority.** Identify the approved provider of completed-bootstrap, bootstrap-edition, exception and later-command-edition classifications, including revision/revalidation policy. No client JSON, vendor registration decoding, selected-book DATA_TYPE, current label color or hardcodedA/C may supply these facts. If the authority is unavailable, implement an explicit persisted unresolved observation rather than pretending the session is initialized. Decide who may change a global business mode; Return View alone is not that permission.
2. **Implement the session-owned observation boundary.** Add storage, explicit context/mode epochs and a transaction-local reader. Atomically create/reset mode with the appropriate scoped session transition, preserving failed-operation recovery. Bind separate logins independently. Persist classification/provenance references without exposing registration details. Do not claim durable ABA safety from a hash of currently absent rows.
3. **Implement locked semantic command/CAS, if its authority is approved.** Recheck live session, permission, complete context and expected epoch/version; obtain current command edition and complete company01 catalog in that transaction; call the pure helper; persist accepted state/generation and audit together. Refused/failed commands preserve prior state. Same-valued accepted commands still invalidate prior mode observations according to the declared concurrency policy.
4. **Implement the source date-clock adapter separately.** Produce the exact local whole-second cutoff from the saved raw header, retain the original raw observations and bind both to the token. Use the rule below, not generic timestamp/UTC utilities.
5. **Integrate read-only bill balance observation under a new explicit contract/profile.** Within the existing bill RepeatableRead transaction, resolve live session mode/context, saved header/configuration/master observations and the internal ledger observation coherently. Hash mode/context/provenance generations, cutoff derivation version/raw inputs and complete physical ledger observation into the outer bill version before transient projection/replay. Stale inputs must fail before any row event. Do not append a mode lookup or balance HTTP call after the snapshot.
6. **Expose guarded observation/UI only after those contracts pass.** Unknown mode, unsupported source clock, ambiguous catalog or incomplete required aggregate stays unavailable with a useful reason. Preserve raw/saved/loaded/opened/event separation and metadata/preview ownership. A mode change must invalidate or require explicit reload of open journals across tabs; it must not silently reprice and save an existing draft. Keep numeric writing disabled.

These are prospective steps, not newly declared endpoints or accepted permissions. The existing source phase/order, row allowlist and unsupported outgoing/companion/variant states remain the initial containment boundary until separately expanded.

## Exact saved date and clock seam

Primary `TR_SALE_RTN.cs:10104–10106` assigns the displayed date from saved VCH_DATE and formats only HH:mm:ss from saved VCH_TIME. At10197 it calls MsAcBal with the concatenated date and clock. Therefore the source cutoff is **VCH_DATE's calendar day plus VCH_TIME's clock at whole-second precision**. It is not necessarily the calendar date embedded in VCH_TIME.

A discriminating case is VCH_DATE=`2024-07-10`, VCH_TIME=`2024-07-09 12:00:00.900000`: the source cutoff is `2024-07-10 12:00:00`. A ledger row at11:59:59.999999 belongs to opening; one at12:00:00 belongs only to helper closing; one at12:00:00.000001 belongs to neither phase. Fractions are removed by the source HH:mm:ss projection, never rounded into the next second.

Validate both owned raw columns before adapting. Missing is not SQLNULL; invalid/infinite dates, absent clocks, unresolved timezone/culture representation or impossible calendar/time values must be contained with diagnostics. Preserve exact raw microseconds independently. Do not use Date.toISOString, browser timezone, the ledger row's VCH_DATE, midnight, the timestamp's embedded day or a source-time fallback. The internal reader already accepts only a valid qualified whole-second string; it does not own this adapter or repair bad input.

MsAcBal1463–1487 resets six monetary/metal balances, then performs opening and inclusive helper-closing queries. Saved Return10198–10227 displays/copies those values. Positive/negative labels/colors and the zero branch have source history, and later BILL_TOTAL recomputes the form's closing from its opening and current bill. Do not equate helperClosing with every later bill closing or fabricate prior zero-color state. The frozen aggregate/bill contracts still govern those later phases.

## Meaningful adapter verification

Freeze expected cases before implementation; use the existing52 mode vectors,12 ledger vectors and complete bill goldens without deriving expectations from the new code.

- Bootstrap each source edition and qualified exception, failed/unknown open and classification refresh. Preserve distinct bootstrap/current edition and separate session identities. Unknown required facts never default to a successful mode.
- Context A→B→A and explicit same-scope reopen follow documented epoch semantics. Refresh preserves state/history; expired/revoked/reused sessions refuse; losing a response after a committed context switch requires readback instead of duplicate bootstrap.
- Two real clients submitting the same mode generation produce one accepted transition and one stale refusal. Same-value commands invalidate old observations without inventing an accounting effect. Permission revocation and context changes between middleware and the final locked operation cannot publish a stale new state.
- Literal company01 catalog under selected02; foreign rows cannot supply mappings. Physical same-value update, delete/recreate, relevant alias collision, NULL output, unsupported mode and an incomplete observation trigger the correct stale/refusal behavior with unchanged session state.
- Date/clock mismatch, leap day, fractional boundary, SQLNULL/missing/infinity and offset/culture strings distinguish the source adapter from generic date conversions. Retain all raw columns and identity before/after.
- Real same-snapshot session/mode/header/config/master/ledger observations under concurrent changes must be coherent as of the transaction snapshot. Do not claim latest-at-response. Existing absence→insert→delete equality remains an explicit observation-hash limitation; durable session generations do not magically add durable ledger-history generations.
- Known A/B/C plus cross-book monetary and metal cases match both helper phases. A groupedNULL required metal must not become an available amount-only full helper. Unsupported mode/clock/ledger keeps closing unavailable.
- Current bill v1/v2 and metadata APIs/UI remain unchanged until explicit versioned integration. New tests must prove rejected stale/unsupported events preserve the last full accepted row/aggregate/bill prefix and cause no stock, money, document, source, tender or unrelated-session writes.

The API reader's54 and420 results and the pure104 results are narrower proofs. Before any integration claim, run affected auth/session/context/RLS/backup and complete API/compiler/build/web regressions, then real multi-client browser journeys without mocked requests. Static scanner gates127/102/33 remain open; passing counts cannot close them.

## Remaining full X13 acceptance

After trusted mode, cutoff and read-only balance integration, complete original-sale selection/copy and stable child identities, incoming item/tag/component admission, remaining keyboard/gross/weight/code/header events, outgoing exchange and UAE/other reachable variants. Complete numeric stock/financial writers, all RTN header effects, allocation/settlement/refund, dependency enforcement, retry/concurrency and exact reversal. Verify complete raw unchanged edits, intentional updates, reports and printed output against independent source/runtime cases.

Original Windows/Double/Format/SQL Server collation/ActiveX behavior, keyboard routing, vendor classification and business acceptance of declared web differences remain required. Migration/recovery, actual devices/providers and production certification are separate. No original X-card/package/menu acceptance is closed and no functional implementation percentage is inferred.

## Evidence navigation

- `session-ledger-mode-independent-tests.md` and `.run.json`: independent104-case focused proof, frozen52 vectors and retained iterations.
- `session-ledger-mode-implementation.md` and `.run.json`: exact pure profile, bounded publication correction, final source/test/fixture identities.
- `x13-account-balance-db-verification.md` and `.run.json`: dedicated54 and broader420 real DB regressions, with scoped source/fixture identities.
- `x13-account-balance-vector-independent-review.json`: independent arithmetic/source review of all12 literal cases.
- `browser-smoke-wait-independent-review.json`: bounded read review of a separate legacy mocked-smoke wait correction; no extra product or real-stack acceptance credit.
- The adjacent handoff reference manifest pins the exact current code and frozen prospective contracts inspected for this note. Mutable plan/progress/checkpoint ownership stays with the coordinating agent.

