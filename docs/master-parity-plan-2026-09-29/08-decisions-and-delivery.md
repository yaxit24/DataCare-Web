# Decisions, delivery management and acceptance

## 1. Decisions to resolve during implementation

These are named design/capture tasks. They do not block this planning deliverable and do not grant a narrower product scope. Record the selected option, reason, owner, date, source evidence and affected requirements in ADRs.

| ID | Decision and recommended starting position | Owner / deadline | Evidence needed |
|---|---|---|---|
| D01 | Primary desktop version and reachable DataCareNext/NextDm country/edition variants; start from preserved canonical DataCareNext and explicitly reconcile alternate branches | Product owner + desktop specialist, W00 | Binary/deployment provenance, live menus/books/settings and branch diffs |
| D02 | Scope outside main executable: NextEmp messaging, NextImage/AllImage, helper services, devices and startup tasks; classify behavior instead of inferring features from filenames | Desktop specialist, W00 | Callers, supported business uses, data and executable inventory |
| D03 | Target service topology; start with browser UI and authoritative web service, preserve recoverable drafts, determine required internet-outage business capability | Owner + operations + architect, before W02 design closes | Business continuity scenarios, branches/network conditions, recovery needs |
| D04 | Which visible differences are acceptable web adaptations: browser-reserved keys, tabs/dialogs, responsive layout, printer bridge and installation | Operators + UX, W02 | Desktop/web benchmark captures, task completion and explicit acceptance |
| D05 | Legacy arithmetic versus decimal adaptation for each affected field/runtime edge; do not infer blanket equivalence | Domain lead + independent QA, W01 and each new formula | Windows numeric vectors, source events, SQL type behavior and business review |
| D06 | Statutory behavior/effective dates and change from desktop; preserve historical policy and get qualified jurisdiction review | Finance/compliance owner, before statutory release | Dated authoritative rules/provider specifications and validated examples; this plan makes no current-law threshold claim |
| D07 | Internal numbering reuse versus externally issued immutable IDs and audit trail | Finance + domain lead, W01 | Source identity behavior, external document linkage and approved policy |
| D08 | Ambiguous commit recovery and durable financial command receipt scope | Backend lead, W01 | Failure injection, request identity/payload/version contract, multi-session tests |
| D09 | Printer/scanner/scale/camera and browser/OS support matrix | Operations + operators, W00 inventory / W13 proof | Actual device models, connection modes, drivers/bridges and test outputs |
| D10 | Report layout tolerances and business mandatory output variants | Operators + reporting lead, before each report acceptance | Reference prints, paper/label sizes, fonts and dataset fixtures |
| D11 | Performance/volume, RPO/RTO, backup retention and incident response targets | Owner + operations, before W14 rehearsal | Measured business volume, acceptable downtime/data-loss policy and capacity tests |
| D12 | Migration source schemas, histories, cutover freeze/delta and rollback boundary | Data lead + finance + owner, W00 discovery / W14 release | Complete ownership manifest, two rehearsal reports and historical continuation |
| D13 | Treatment of source ambiguities or inferred tables without runnable evidence | Desktop specialist + QA, continuously | IL/decompiler/caller analysis, another preserved build or original-runtime capture; unresolved required behavior remains open |
| D14 | Full rollout and stabilization duration, support ownership, retained desktop access | Owner + operations, before W15 | Candidate certification, staff training, daily reconciliation and rollback rehearsal |

Decisions D15–D22 (identity convention, request validation, concurrency token, idempotency, date and number formats, layout parity, screens outside the menu table, language) were added on 1 October 2026 in [document 11 §4](11-audit-implementation-plan-2026-10-01.md), with the same owner and evidence rules.

## 2. Explicitly acceptable adaptation categories

The web may use PostgreSQL and different physical storage, API/service boundaries, transactions, technical IDs, optimistic version tokens, server-side roles, browser dialogs, web printing and responsive layouts. These choices must preserve the business data and outcomes. Any changed visible behavior is documented and operator-tested.

Do not port SQL injection, broad unscoped deletes, machine-wide mutable session state, hard-coded customer credentials or accidental partial-write behavior as requirements. Preserve the legitimate business effect through a scoped, audited and recoverable implementation. Similarly, do not simplify a jewelry ledger to a generic invoice total: fine-metal balances, custody, tags, labour methods, source linkage and historic report behavior remain required.

This is an online web migration request, but the desktop's offline service model is a real difference to resolve. The plan does not silently promise offline browser posting or silently discard outage continuity. Implement only the agreed topology and test its operational capability explicitly before calling it a complete replacement.

## 3. Risks and concrete mitigations

| Risk | Signal in current evidence | Mitigation / closure |
|---|---|---|
| False completion from surface metrics | 198 mappings versus zero whole-menu certificates; scanner blind spots | Semantic requirements and exact-set current evidence; report separate implementation/test/desktop/UAT states |
| Incomplete historical baseline | Current tracked inputs differ from prior manifests, missing generated browser files | Fresh reproducible candidate runs; preserve old result identity and recover/supersede absent artifacts |
| Duplicate business implementations drift | Saved Return diagnostic profile and separate legacy numeric creation | Audit both routes, unify or clearly partition authority and test every reachable path |
| Wrong stock identity or lost lineage | Four tag operations still contained; same tag text can be reused | Full serial/source scope, graph ownership, conservation and competing-use tests |
| Global policy overgeneralization | Customer-derived defaults, mixed numerical primitives, mode-specific source behavior | Per-field/event policy contracts and multiple materially different configurations |
| Designer extraction mistaken for functionality | Thousands of raw controls/events and alternate source variants | Follow callers/helpers, review reachability and original-runtime actions |
| Report specs mistaken for report parity | Many assets/specs, uncertain binding/mode/rendering | Dataset + parameter + layout + actual physical output proof per report/mode |
| Data migration damages unrelated scope | Production load remains contained | Staging/shadow loading, complete manifest, two-company/two-year sentinels, repeated rehearsals |
| Concurrent operators violate offline assumptions | New session primitives only prove adopted callers | Same-transaction observations, source-balance locks/serializable conflicts, idempotency and stale draft UX |
| Deployment interrupts financial workflows | Active drafts/jobs/provider acknowledgments span releases | Versioned contracts, durable status, compatibility checks and tested rollback/reconciliation |

## 4. Tracking and review cadence

Maintain one current status document with candidate, date, completed bounded slices, newly verified evidence, open failures and next slices. Retain historical checkpoints unchanged. The machine-readable backlog is the navigation index; the source contracts and independent tests define acceptance.

At each integration review report:

- Which semantic requirements gained implementation, engineering proof, desktop match or operator acceptance, as separate counts against named sets.
- Which end-to-end journeys and reports are now fully accepted for which configurations.
- Which active routes remain partial/read-only/contained, including exact operation names.
- Which new descendants, source ambiguities, failed tests or changed dependencies reopened work.
- Which release/migration/continuity decisions remain unresolved and their owners.

Estimate effort from reviewed contracts, not source lines or remaining percentage. Slice by a complete behavior path, such as one configured source-linked return or one tag lifecycle, rather than thousands of UI fields without persistence. A module milestone may close only after its related reports, failures, permissions and downstream continuations pass.

## 5. Release and handover checklist

The final delivery includes:

1. Application code and repeatable build/deployment instructions, versioned schema migrations and environment configuration without embedded secrets.
2. Desktop-to-web menu/field/action/settings/report/device/edition mapping with current source references and every required semantic leaf closed.
3. Candidate-bound unit, DB, API, browser, desktop differential, report/print, concurrency and recovery evidence, including independent expected data and retained failures.
4. Role-based operator instructions, keyboard/lookup guides, known approved web adaptations, configuration guide and administration/audit procedures.
5. Complete migration ownership/conversion manifests, reconciliation results, historical continuation scripts, cutover/rollback plan and archived source provenance.
6. Backup/restore runbooks, measured recovery and load results, monitoring/alerts, incident process, provider/device support matrix and support ownership.
7. Business acceptance by cashier, purchasing, inventory/manufacturing, accountant, manager and administrator, plus production transition approval.
8. Stabilization results demonstrating accurate real business-day posting, stock/custody, balances and reports, with no unresolved required parity gaps.

The application is ready as the complete requested replacement only when those outcomes are achieved. A document, an implementation checklist, a passing core suite or a limited pilot does not by itself satisfy that promise.
