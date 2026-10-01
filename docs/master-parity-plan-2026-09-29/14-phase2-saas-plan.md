# Phase 2 plan — DataCare as a SaaS product

Phase 2 turns the certified Phase 1 application into a product sold online to many jewellery businesses: a
super-admin console, tenant onboarding and lifecycle, plans and billing, managed operations, privacy compliance and
an architecture that is easy to maintain and to scale when demand grows. Traffic will be low at first, so every
scaling step waits for a measured trigger.

- **Machine record:** [`phase2-backlog.json`](phase2-backlog.json) — milestones M0–M7 and slices SP01–SP24 with
  steps, tests and done-when criteria. Gaps G75–G78 and G80 ([document 12](12-lineage-verification-2026-10-01.md))
  are owned there; `validate_plan.py` checks the identifiers, dependencies and gap coverage.
- **Entry gate (D28):** Phase 1 is complete as defined in [document 13](13-phase1-delivery-plan.md) §1 and certified
  (N30). Nothing in this document starts earlier, including the M0 decisions (owner instruction, 1 October 2026).
  Two Phase 1 slices prepare for it and are not affected: the supported runtime (N86) and maintainability
  boundaries (N88).
- **Rule that never changes:** Phase 1 golden vectors, write-set database tests, zero-mock journeys and the desktop
  differential stay blocking. A SaaS change to an operator workflow ships behind a per-tenant flag that defaults to
  desktop behaviour for migrated tenants and never changes an accounting, stock or tax result (D25).

Items below marked **proposal** are recommendations for the owner; facts cite the code.

## 1. Where the code stands for SaaS

| Area | Today | What a sellable product needs |
|---|---|---|
| Tenancy | 174 tables with `tenant_id` and forced RLS; `withTenant` sets the tenant per transaction (`web/packages/db/prisma/rls.sql`, `web/packages/db/src/tenant.ts`) | Keep. Add isolation for files, jobs, caches and meters, and continuous isolation tests |
| Tenant resolution | Outside production a raw `x-tenant-id` header; in production one `APP_TENANT_ID` per deployment (`web/apps/api/src/app.ts:241-246`, `web/apps/api/src/server.ts:86-95`) | One deployment for many tenants, resolved from the host name, never from a public header (SP04) |
| Identity | Company-scoped tenant users with `ADMIN` or `USER` and per-form rights; 15-minute access and 7-day refresh tokens; Argon2 passwords (`web/apps/api/src/modules/rbac/users.ts`, `web/apps/api/src/modules/auth/session.ts`) | A separate platform realm (owner, support, billing), MFA, invitations and recovery (SP05) |
| Provisioning | `POST /admin/companies/:coCode/provision` seeds one company inside the signed-in tenant (`web/apps/api/src/modules/ops/seedCompany.ts`) | Tenant creation, lifecycle and a company wizard (SP06, SP13) |
| Background work | None: Compose omits Redis because nothing consumes a queue (`web/docker-compose.yml`) | Outbox, queue and workers for PDFs, reports, exports, messages, migration and backups (SP09) |
| Files | Images stored as `bytea` in PostgreSQL, 4 MiB cap (`web/apps/api/src/modules/images/entityImage.ts`) | Object storage with signed URLs (SP10) |
| Provider credentials | GSP, WhatsApp and SMS read process environment variables (`web/apps/api/src/modules/integrations/messaging.ts`, `web/apps/api/src/modules/einvoice/einvoice.ts`) | Per-tenant secrets by reference (SP11) |
| Operations | `/health`, `/ready` (database, non-bypass role, RLS, renderer) and per-process Prometheus metrics (`web/apps/api/src/modules/ops/health.ts`, `web/apps/api/src/modules/ops/metrics.ts`) | Central telemetry, SLOs and on-call (SP18) |
| Backup | Host `pg_dump` with local retention (`web/deploy/backup.sh`) | Managed point-in-time recovery and per-tenant restore (SP12) |
| Audit | Method, path and status logged after the response (`web/apps/api/src/modules/ops/audit.ts`) | Durable, transactional platform audit (SP20) |
| Maintainability | 8,400-line route file without schemas; no OpenAPI | Module route plugins with schemas (N88), OpenAPI and a contract package (SP03) |
| Runtime | Node 20 (end of life), Next.js 15.1.6 and React 19.0.0 inside an advisory range, Prisma 6 (fixes end 19 November 2026) | N86 now: patched Next.js 15.5, Node 24 and Prisma 7 by 19 November 2026 (D26); Next.js 16 and PostgreSQL 18 in SP02 |

No plan, subscription, entitlement, usage, invoice, support-grant or data-request model exists in the schema or the
route policy (gaps G75–G78).

## 2. Product and packaging (proposal)

Desktop edition codes (Lite, Basic, Standard, Ultra, Pro, Advance, Enterprise) already gate menus, for example
schemes up to Standard and Dhiran up to Ultra (`unified/src/csharp/DataCareNext/MDI_FORM.cs:11249-11338`). Migrated
customers keep their effective desktop entitlement. SP01 builds the menu-by-menu matrix from the
[menu catalog](../handbook/menu-catalog.md) before plans are fixed.

| Plan | Desktop scope it maps to | Suggested limits |
|---|---|---|
| Starter | Lite and Basic: retail trading, cash and bank, masters, stock, core reports | 1 company, 1 location, 3 users, 5 GB files |
| Growth | Standard and Ultra: richer operations and reports, CRM; schemes as an add-on | 1 company, 3 locations, 10 users, 25 GB |
| Professional | Pro: Growth plus Dhiran and loans and advanced operations | 3 companies, 10 locations, 30 users, 100 GB |
| Enterprise | Advance and Enterprise: the full certified scope, tour and approval depth, SSO | Contracted |

- **Trial:** 30 days on Growth with one company and location; at expiry the tenant can read, export and pay, then is
  suspended under the retention policy. No silent conversion.
- **Add-ons:** manufacturing and job work, schemes, e-invoice (per GSTIN or volume), WhatsApp and SMS message packs,
  extra companies, locations, users and storage, assisted migration, priority support.
- **Limits** are enforced on the server with warnings at 80, 90 and 100 percent. Exceeding a limit blocks new
  consumption after a grace period; it never hides or corrupts existing records.
- **The owner decides** prices, terms, discounts, overage, grace, refunds, reseller terms and whether a card is needed
  for the trial.

## 3. Target architecture (proposal)

```text
Internet ─ CDN and TLS edge ─┬─ app.<domain>   tenant web (Next.js)     ┐
                             └─ admin.<domain> platform console          │ stateless containers, ≥2 replicas
                                       │                                 │
                               Fastify API (tenant routes, platform routes, webhooks) ┘
                                 │            │              │                │
                PostgreSQL (tenant schema, RLS)  Control-plane DB   Queue + workers   Object storage
                + connection pooler, PITR        (tenants, plans,   (PDF, reports,    (images, PDFs,
                                                  billing, audit)    exports, messages, exports)
                                                                     migration, backup)
                Secrets manager (per-tenant provider credentials) · OpenTelemetry collector → metrics, traces, logs
```

- **Modular monolith.** One deployable API with clear module boundaries; extract a service only when a measured
  hotspot or team boundary needs it.
- **Control plane separate** from tenant business data: its own database or schema and its own role. Platform code
  reads jewellery tables only through audited lifecycle jobs.
- **Region:** production data, files, backups and primary logs in India (owner chooses provider and region pair).

## 4. Super-admin console (SP05–SP08, SP15–SP17)

| Area | Functions |
|---|---|
| Tenant directory | Search by code, domain, status, plan; contacts, companies, locations, users, storage, last activity, onboarding and health |
| Lifecycle | Create, start trial, activate, extend trial, suspend with reason, reactivate, export, legal hold, schedule deletion. States: draft → trialing → active ↔ past_due → suspended → export_only → deletion_pending → deleted. Suspended tenants can read, export and pay but not post |
| Plans and entitlements | Versioned plans and add-ons with effective dates, grandfathering, limits, scheduled upgrades and downgrades, proration preview |
| Feature flags | Per-tenant rollout flags, separate from commercial entitlements, evaluated on the server and audited |
| Billing | Gateway customer and mandate status, signed and idempotent webhook inbox, renewal, retries, dunning, manual payments, credits and refunds, immutable GST invoices and credit notes |
| Usage | Companies, locations, active users, storage bytes, documents, e-invoices and messages; raw events plus daily roll-ups |
| Support access | Ticket-bound, time-boxed, read-only-by-default session granted by the tenant admin; banner, step-up MFA, full audit, tenant notification; changes need fresh consent or two-person break-glass approval |
| Operations | Announcements, service and dependency health, queue depth, lag and dead letters, deployed version, backup age and restore status, onboarding and migration runs |
| Requests and security | Data export and erasure requests, security events (failed logins, rate limits, RLS refusals, suspicious activity) |

**Platform roles:** owner (tenants, plans, roles), support (operational metadata and consented sessions, no billing
secrets), billing (subscriptions, invoices, refunds, no ledgers), and later a read-only security auditor. A tenant
`ADMIN` stays inside its tenant.

## 5. Tenancy and identity (SP04, SP05)

1. **Resolution:** `<tenant-code>.<product-domain>`, or tenant code at login for custom domains, resolved to an
   immutable tenant ID before credentials are checked. Public `x-tenant-id` headers are stripped; only an
   authenticated edge may pass internal context. Host tenant and token tenant must match on every request, job and
   socket. Login and discovery failures are generic.
2. **Tenant users:** keep company, location and form rights; add invitations, verified contact, recovery, MFA for
   admins and session revocation. Later, user IDs separate from login names, with memberships per company.
3. **Platform realm:** separate host, user store, issuer, audience, signing keys and cookies; mandatory
   phishing-resistant MFA. Platform tokens are never accepted by tenant routes.
4. **SSO** (Enterprise): OIDC first; SAML through a broker if a customer needs it; a local break-glass admin remains.
5. **Isolation gate:** two- and three-tenant tests on every route, report, export, job, cache key, meter, object path
   and support grant; negative tests for a missing tenant context and for the owner connection.

## 6. Onboarding and migration (SP13, SP14)

- **New customer:** reserve the tenant code → verify the owner, accept terms, privacy notice and DPA → choose trial
  or plan → create the tenant admin with MFA → company wizard (legal identity, GSTIN and state, financial year,
  locations, books and numbering, chart template, taxes, rates, printers and scale, users and rights, integrations)
  → preview → one atomic creation using the N58 provisioning → checklist (first sale, purchase, receipt, report,
  backup). Optional sample data is labelled and removable before the first real posting.
- **Existing desktop customer:** encrypted upload of SQL Server backups → quarantine and scan → staged restore →
  checkpointed ETL using the N78 ownership manifest → row, ledger and report reconciliation → mapping decisions →
  two rehearsals → freeze and delta → cutover and rollback → signed acceptance. This turns
  `web/docs/runbooks/migration.md` and slices N78–N79 into an observable service.

## 7. Workflow refinements for SaaS (SP21, SP22)

All behind per-tenant flags (D25); "result" means accounting, stock and tax results.

| Desktop behaviour | Web change | Result changes? |
|---|---|---|
| Backup and restore to a chosen drive (`unified/src/csharp/DataCareNext/UT_BKP.cs:1223-1271`) | Managed encrypted backups; tenant export on demand; approved restore to an isolated copy, reconciled, then promoted | No |
| Import/export by file and `DATA_TRFR` flags (`web/apps/api/src/modules/utilities/dataExport.ts`) | Asynchronous cloud import and export jobs with preview, row errors, signed expiring downloads and audit | No |
| Machine registry by disk serial (`unified/src/csharp/DataCareNext/UT_HDD.cs:748-765`) | Named devices and active sessions with revoke; printer and scale bridge status | No |
| Global menu tiles (`unified/src/csharp/DataCareNext/MS_WINDOW_SET.cs`) | Per-user favourites and recent work; rights stay on the server | No |
| Edit/delete "user request" with a reason (`unified/src/csharp/DataCareNext/UT_USER_REQUEST.cs`) | Approval inbox with assignee, expiry, notification and audited decision | Only the approved change itself |
| Estimate reset, data refresh (`web/apps/api/src/modules/utilities/estimateReset.ts`, `web/apps/api/src/modules/utilities/dataRefresh.ts`) | Locked jobs with preview hash, fresh backup, two-person approval and reconciliation | No |
| Year end and voucher renumber (`web/apps/api/src/modules/ops/yearEnd.ts`, `web/apps/api/src/modules/utilities/voucherRenumber.ts`) | Wizards with pre-close checks, backup, preview, approval and idempotency; renumber disabled after statutory issue unless the accountant approves | Renumber changes identifiers only, never amounts |
| SMS and WhatsApp from process settings | Per-tenant providers, templates, consent and opt-out, queued delivery with status webhooks | No |
| Branches synchronised by transfer utilities | One live dataset with optimistic versions and explicit conflicts | Timing only |
| Fixed-width desktop shell (`web/apps/web/app/globals.css`) | Responsive task views (approvals, lookups, stock checks, dashboards); dense grids kept for data entry | No |
| Reminders read on screen (`web/apps/api/src/modules/ops/reminders.ts`) | Notification centre with optional email, push and WhatsApp | No |

## 8. Maintainable architecture (N88, SP03)

- **Module boundaries:** platform, identity and access, organisation and configuration, masters, sales, purchase,
  inventory, finance, manufacturing, schemes and loans, reports and documents, integrations, migration and
  operations. Each owns its routes, commands, queries and tables; cross-module writes go through an application
  service.
- **Routes:** every module registers a Fastify plugin with JSON Schemas; OpenAPI is generated from them, client types
  go to `web/packages/types`, and CI fails on an undocumented route or an incompatible change. Public API versions
  live under `/v1`.
- **Errors:** one taxonomy (400 invalid-request with field paths, 401, 403, 404, 409 version or idempotency conflict,
  422 business rule or plan limit, 429, 502/503 provider, 500 opaque with a correlation ID).
- **Dependency rules:** UI → API client only; route → application → domain and repository; `web/packages/core` has no
  I/O; reports read models; integrations go through ports and the outbox.
- **Configuration:** startup configuration, tenant configuration and secret references are separate. Entitlements
  and rollout flags are separate. No accounting formula changes behind a flag without a versioned decision.
- **Keep:** Fastify, Next.js, PostgreSQL with forced RLS, Prisma migrations, the pure kernel, server-owned session
  context, the central route policy, readiness and invariants, and the parity and release harnesses.

## 9. Scaling in stages (SP24)

| Stage | Topology | Enter when |
|---|---|---|
| Pilot (1–5 tenants) | Managed PostgreSQL with PITR in India, one small app pool, queue and one worker, object storage and CDN, secrets manager, telemetry | Phase 2 starts |
| Tens | Two or more API and web replicas, connection pooler (replicas × pool size below the database limit), worker autoscaling, shared rate limiting, versioned lookup cache | p95 latency or connections approach their budgets, or availability requires redundancy |
| Hundreds | Read replicas for stale-tolerant reports and exports, separate report and migration worker pools, per-tenant queue quotas, time partitioning of audit, job, message and meter tables | Report load or table growth breaches budgets |
| Thousands | Tenant cells (several database clusters) behind a tenant catalog, rehearsed tenant moves, dedicated cells for large tenants | One cluster cannot meet SLOs at forecast load |

Provisional budgets (proposal): p95 reads under 300 ms and writes under 750 ms excluding providers; first page under
2.5 s on broadband; report enqueue under 500 ms and 95 percent of normal reports within 30 s. Before each stage, load
tests at twice the forecast peak with one noisy tenant.

## 10. Engineering and operations (SP18, SP20)

- **Environments:** local, disposable pull-request previews, staging that mirrors production in India with synthetic
  data, and production; separate accounts, networks and secrets.
- **Delivery:** build once, sign the image, promote staging → canary → production with approval and automatic
  rollback criteria. CI adds contract and OpenAPI checks, dependency and licence scanning with an SBOM, static
  analysis, secret, container and infrastructure-as-code scanning.
- **Infrastructure as code** for network, compute, database, pooler, queue, storage and CDN, secrets, DNS and
  certificates, telemetry and alerts.
- **Database changes:** reviewed forward migrations; expand → backfill → switch → contract for incompatible changes;
  online indexes; tenant-batched backfills with checkpoints; never `db push`.
- **Dependencies:** automated weekly update pull requests, a monthly review of supported versions, and an emergency
  security lane.
- **Observability:** OpenTelemetry traces, metrics and logs for API, workers, database and browser, keeping the
  existing request IDs; the tenant ID is a restricted attribute; no customer names or payloads in telemetry.
- **SLOs and on-call (proposal):** 99.9 percent availability for paid plans, financial-write error rate, queue
  latency and backup freshness, each with an alert on error-budget burn, a runbook, an on-call rota, a status page
  and blameless post-incident reviews.

## 11. Security, privacy and compliance (SP19, SP20)

- **India DPDP Act and Rules.** The Rules were notified on 14 November 2025; some obligations apply from 14 November
  2026 and the substantive ones from 14 May 2027. Before those dates: itemised notices and purposes, consent where
  required with equally easy withdrawal, data minimisation, access, correction, erasure and grievance channels,
  processor contracts, reasonable safeguards, retention and erasure schedules, and a breach workflow. Accounting and
  tax records under statutory retention are restricted, not erased. Roles (data fiduciary or processor) are set in
  the contracts. Legal review signs off.
- **Data-principal requests** are routed to the right tenant, with identity checks, scope, decision, deadline and
  evidence.
- **Protection:** TLS and HSTS; managed encryption at rest; envelope encryption of provider credentials and sensitive
  fields; encrypted files and backups; key rotation; least-privilege database and cloud roles; egress control;
  short-lived credentials; signed webhooks with replay protection.
- **Audit:** actor, realm, tenant, resource, action, reason, support grant, before and after hashes, outcome and
  correlation ID, written in the same transaction as the change; tamper-evident export.
- **Assurance:** threat model, independent penetration test before the pilot and yearly; continuous dependency and
  container scanning. Production images are built from sanitized sources only (N81); every credential that was ever
  tracked in the repository is treated as compromised (`SECURITY-NOTICE.md`).
- **Subscription invoices:** DataCare's own GST invoices and credit notes (supplier and customer GSTIN, financial-year
  serial, date, SAC and description, taxable value, tax rates and amounts, place of supply). The SAC, rate, CGST/SGST
  or IGST choice, e-invoice applicability and export rules are decided with the tax adviser, not copied from the
  jewellery invoice logic.
- **Published documents:** terms of service, privacy notice, DPA, subprocessor list, retention and deletion schedule,
  acceptable-use policy, SLA and support policy, security and breach contacts; acceptances are versioned.

## 12. Testing for Phase 2

- **Isolation:** generated multi-tenant suites for every route, report, job, meter, cache key, file path, export,
  backup and support grant; owner-role and missing-context negatives; a gate for every new table.
- **Plans and billing:** limit boundaries, grace, suspension and reactivation, trial conversion, upgrade and downgrade
  with proration, tax and place of supply, invoice sequence, credits, duplicate, out-of-order and lost webhooks,
  gateway reconciliation. A billing outage never loses tenant ledgers.
- **Console:** end-to-end journeys for each platform role and tenant state; tenant admins cannot call platform
  routes; billing and support cannot read business data.
- **Resilience:** small and large tenants, skew and a noisy neighbour; worker killed after commit, duplicate job,
  queue outage, database failover, provider timeout, storage failure; quarterly tenant and full restore drills and a
  yearly regional drill with measured RPO and RTO.
- **Unchanged results:** each SaaS flag on and off yields identical ledger, stock, tax and report results; the Phase 1
  suites stay blocking. Browser checks follow the [testing handbook](../handbook/web/testing.md) on the supported
  device matrix, with accessibility checks.

## 13. Milestones

| Milestone | Slices | Exit criteria |
|---|---|---|
| M0 Decisions (after Phase 1, D28) | SP01 | Edition-to-plan matrix for all 198 menus; pricing, legal entity and GST, identity, provider, residency, SLO/RPO/RTO and offline decisions signed (ADR-0005 onward) |
| M1 Supported, contract-first foundation | SP02, SP03 | Supported runtime and framework versions with green parity suites; every route in a module plugin with a schema; OpenAPI generated in CI |
| M2 Tenant and identity control plane | SP04–SP08 | Trusted tenant resolution, platform realm and roles, tenant lifecycle, entitlements and flags, consented support access; isolation suite green |
| M3 Cloud operations and onboarding | SP09–SP14, SP21 | Jobs, object storage, tenant secrets, managed backups with a verified per-tenant restore, the company wizard and migration service, SaaS utility replacements |
| M4 Commercial console | SP15–SP17 | Plans, metering, payments, dunning and GST subscription invoices reconcile over two cycles; console role journeys pass |
| M5 Security and operability | SP18–SP20, SP22 | DPDP workflows and documents, telemetry with SLOs and alerts, threat model, penetration test, responsive task views |
| M6 Assisted pilot | SP23 | Three to five representative tenants, two billing cycles, no open severity 1 or 2 defect, reconciliation, SLO and restore drills pass, tenants sign off |
| M7 General availability and scale | SP24 (GA sign-off closes SP23 in M6) | Support, legal and commercial handover; capacity stages entered only on measured triggers |

## 14. Risks

| Risk | Mitigation |
|---|---|
| Refactoring changes desktop-equivalent results | Strangler extraction, unchanged routes, Phase 1 suites blocking on every change |
| One tenant sees another's data | Immutable tenant resolution, forced RLS, separate platform role, scoped files, jobs and caches, adversarial isolation tests |
| Migration corrupts a customer's history | Quarantine, versioned mappings, resumable batches, exception queue, two rehearsals, reconciliation and rollback |
| Billing problems block a shop's daily work | Internal subscription state is authoritative; grace and read/export/pay mode; audited manual override |
| Noisy neighbour or connection exhaustion | Per-tenant job quotas, pooler budgets, separate report workers, cells when measured |
| Support access is abused | Tenant consent, MFA, least privilege, short expiry, visible banner, immutable audit and notification |
| Premature distributed architecture | Modular monolith on one database until a measured trigger |
| Internet outage at a shop | Decide in M0 whether drafts-only continuity is enough; offline financial posting needs its own certified design |

## 15. Decisions the owner must make (M0)

Deferred by D28: the owner takes these when Phase 1 is complete and certified, not before.

1. Edition-to-plan mapping, bundled versus add-on modules, and grandfathering of migrated customers.
2. Prices, terms, trial, discounts, overage, grace, refunds, reseller model and payment gateway.
3. Legal entity, GST registration, SAC, rate, place-of-supply and e-invoice policy for subscription invoices.
4. Tenant URL and custom-domain policy; login identifier; MFA baseline; Enterprise SSO scope.
5. Self-service versus assisted onboarding; migration eligibility, fee and cutover support; sample data.
6. Support-access consent, break-glass approval and customer notification rules.
7. Cloud provider and India region pair; dedicated-tenant option; SLOs, support hours, RPO and RTO; DR budget.
8. Retention by record class, suspension and export-only periods, deletion recovery window, backup expiry, legal holds.
9. File, message and e-invoice quotas and overage; whether a limit may ever block financial posting (recommended: never).
10. Offline and outage expectations, supported browsers, devices and printers, and the mobile task scope.
11. Pilot tenant profile and number, and who signs general availability.

## 16. Keeping this record current

Phase 2 slices continue at **SP25** in `phase2-backlog.json`; gaps continue in document 12 at G84. A slice moves to
`in-progress` or `implemented-unverified` only with evidence paths. Run `validate_plan.py` and `docs_check.py` before
merging.
