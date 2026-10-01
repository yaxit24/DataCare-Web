# Lineage verification, documentation hub and new gaps — 1 October 2026

This document answers one question: **does the current plan account for every earlier plan, gap list, audit and
requirement?** It records the method, the result per source, the items that no current identifier owned (new gaps
G69–G80, plus G81 found by the independent review of this change), the decisions they need (D23–D28, all accepted by the owner on
1 October 2026) and the slices that close them (N83–N88). It also records the
documentation hub created in the same change.

- **Baseline:** `main` at `675d845` (after PR #25, G67, and PR #26, N47).
- **Machine record:** [`lineage-register.json`](lineage-register.json) lists every item with its disposition and
  current owners. `validate_plan.py` checks that every owner identifier exists, every evidence path exists and the
  counts below match the register.
- **Scope rule:** like documents 10 and 11, this document closes no package (P00–P14), card (X01–X34) or acceptance.
  "Carried" means a current identifier owns the remaining work, not that the work is done.

## 1. Method

Two independent reviews read every planning and status document outside the current package — the twelve root
plans and reports, the September package (`parity-plan-2026-09-10/`, documents 01–48), `web/docs/`,
`project-memory/` (handoffs, ADRs, contracts, parity audits, the video knowledge base), `web-implementation-spec/`
and the original requirements (`.kiro/specs/datacare-web-rebuild/requirements.md`). For each open item they decided:

| Disposition | Rule |
|---|---|
| closed | Fixed in engineering, with a file, test or record that shows it. A closed defect never closes its parent package |
| carried | A current P, X, N, G, D, J, R or SP identifier's text actually covers the remaining work |
| new-gap | No current identifier covers it; it becomes a gap in §3 with a slice in §5 |
| superseded | A later plan structure replaced it; the successor identifiers carry it |
| decision | It conflicts with current policy or needs an owner choice; recorded in §4 |

A third review read the 198 desktop menus one by one against the decompiled dispatch (`MDI_FORM.cs`), the form
sources, the tutorial knowledge base and the web code. Its result is the
[menu catalog](../handbook/menu-catalog.md), checked by `docs/tools/docs_check.py`. It found no menu without an
owner, and 20 rows where `web/docs/COMPLETION-REGISTER.json` names the wrong form or web surface (G71).

## 2. Result

<!-- lineage-counts: sources=37 items=228 closed=32 carried=178 new-gap=14 superseded=4 -->

37 sources, 228 items: **32 closed, 178 carried, 14 new gaps, 4 superseded.** The two items that needed an owner
decision (requirements 19.2 and 21.1) were decided on 1 October 2026 (D23, D24) and are now carried. Every new-gap
item maps to one of the gaps G69–G80 below.

| Source group | Items | Closed | Carried | New gap | Other | Notes |
|---|---:|---:|---:|---:|---:|---|
| Root plans and reports, August–September (9 files) | 127 | 24 | 99 | 2 | 2 superseded | Already reconciled at package level by [document 07](07-previous-plan-reconciliation.md); this review checked item by item |
| `PARITY-EVALUATION-2026-09-28.md` | 10 | 2 | 5 | 3 | — | Harness defects, missing builders and Next25 columns had no leaf owner |
| `report.md`, `req.md` | 2 | — | 1 | — | 1 superseded | Extraction gaps carried by X32 and N74–N77 |
| `.kiro` requirements 1–22 | 22 | 1 | 20 | 1 | — | Requirements 1–4 closed by the extraction; traceability itself was missing; 19.2 and 21.1 decided by D23 and D24 |
| September package (01, 02, 03, 08, 11, 12) | 22 | — | 22 | — | — | CR-01 and CR-02 findings in the backlog were stale; corrected (§6) |
| `web/docs` plans, catalogue and status | 25 | 3 | 21 | 1 | — | Phase 2 SaaS product not owned anywhere |
| `project-memory`, `web-implementation-spec`, security reviews | 14 | 2 | 9 | 2 | 1 superseded | ADR-0002 levers without triggers; SQL interpolation lint |
| Register, index, dependencies, route file, desktop utilities | 6 | — | 1 | 5 | — | Register mapping errors, fragmentation, runtime support, maintainability, SaaS utilities |

The row counts are taken from the register's per-source totals; [`lineage-register.json`](lineage-register.json) is
the authority for each item.

### Requirement traceability (`.kiro` requirements 1–22)

| Requirement | Disposition | Current owners |
|---|---|---|
| 1–4 Extraction audit, unified centre, manifest, blockers | closed | `unified/MANIFEST.md`, `unified/README.md` |
| 5 Multi-tenant data foundation | carried | P01-01, X05 |
| 6 Authentication and company/year selection | carried | X09, N55 |
| 7 Users and rights | carried | X29, P11-04 |
| 8 Masters | carried | X10, P03-01, P03-02, N58, N69 |
| 9 Calculation engine | carried | X04, P01-02, N48 |
| 10–15 Sales, purchase, stock, manufacturing, dhiran, finance | carried | X13, X12, X18, X23, X24, X16 with their packages |
| 16–18 Accounting, GST/e-invoice, schemes | carried | X16, X26, X15, N16, X24 |
| 19 Reports and documents | carried; 19.2 decided by D23 (refuse and list the missing fields) | X25, X26, N74, N75 |
| 20 Integrations | carried | X28, N25, N54 |
| 21 Behavioural parity verification | carried; 21.1 decided by D24 (enforced by tests and release gates) | X03, X06, X34, N82 |
| 22 Phased delivery | carried | X31, X33, N80, N82, D25 |

## 3. Gap register G69–G83

Severity as in documents 10 and 11. G69–G74, G79 and G81–G83 are Phase 1 (desktop parity in the web); G75–G78 and G80 are
Phase 2 (the sellable SaaS product, [document 14](14-phase2-saas-plan.md)) and are owned by its SP slices.

| ID | Sev | Area | Desktop authority | Web evidence | Required behaviour | Slice |
|---|---|---|---|---|---|---|
| G69 | S2 | Replay harness inputs and builders | `PARITY-EVALUATION-2026-09-28.md` §9; corrected copy `parity-plan-2026-09-10/evidence/independent-evaluation-2026-09-28/scripts/eval-replay-corrected.mjs:105-115` (drops literal untagged `N`, carries header discount, line other and labour amounts, receive rows and `CR_FINE`) | `web/apps/api/integration/parity-replay-generic.mjs:110` passes `TAG_NO` unfiltered and omits those fields; only PURCHASE, SALES and RATE CUT/WH SALES have builders, every other family returns `NO_BUILDER` (`:274`) | The shipped harness carries the four corrections and has builders for karigar issue/receipt (050/052), sales order (020) and estimate (032), each with a positive and a deliberately broken fixture | N83 |
| G70 | S2 | Next25 edition columns | Next25 schema: `PR_DATA` OTH_TAX_AMT, OTH_TAX_CODE, OTH_TAX_PRC, RE_TRFR, ZERO_RATED_AMT; 13 `PR_DETL` columns (BAG_TOT, GRAND_TOTAL, ITM_CGST_AMT, ITM_IGST_AMT, ITM_SGST_AMT, ITM_REMARK, IT_TAX_AMT, RATE_WITH, TAXABL_RATE, TAX_CODE, TAX_FREE_AMT, TAX_RVRS, TAX_TYPE); `RATE_CUT_DATA.RE_TRFR`; `RATE_CUT_ISU.FIX_WEST_PRC`; `RATE_CUT_REC.ITM_STYLE`; `AD_MAST.BANK_AC` (`parity-plan-2026-09-10/evidence/independent-evaluation-2026-09-28/differential/field-summary-corrected.txt:153-192`) | None of the 21 columns exists on those models in `web/packages/db/prisma/schema.prisma` (checked model by model on 1 October) | Forward migration with desktop types and defaults; writers, readers, import and differential include them where the edition writes them | N84 |
| G71 | S3 | Completion-register mapping | `MDI_FORM.cs` dispatch for each menu | 20 rows of `web/docs/COMPLETION-REGISTER.json` name the wrong form or surface (for example Style → `COL_MAST` instead of `MODEL_MAST`; Member Mast → loyalty `POST /members`; Loan Intrest → pledge-only interest; HuId Report → stale tag-stock alias). Full list: [menu catalog](../handbook/menu-catalog.md#completion-register-corrections) | Register, navigation and catalog agree with the dispatch; `register:check` refuses a planted mismatch | N85 |
| G72 | S1 | Supported runtime and framework | — | `web/apps/web/package.json:16-18` and the lockfile pin `next` 15.1.6 and `react` 19.0.0 — inside the range of the December 2025 React Server Components RCE advisory (GHSA-9qr9-h5gf-34mp, CVE-2025-55182 / CVE-2025-66478, App Router; fixed in React 19.0.1 and Next.js 15.1.9). Later 2026 Next.js security releases (May, July, August, 30 September: 15.5.27 / 16.3.8) patch only the 15.5 and 16 lines. CI (`.github/workflows/ci.yml:43,97,279`), release certification (`.github/workflows/release-certification.yml:88`) and `web/Dockerfile.web:16,37` use Node 20, which reached end of life on 30 April 2026. Prisma 6.19.3 receives security fixes only until 19 November 2026 | No installed package inside a known critical or high advisory; Node 24 LTS in CI and images; a recorded Next 16 and Prisma 7 decision (D26) | N86 |
| G73 | S3 | Requirement traceability | — | The original requirements 1–22 had no mapping to plan identifiers; 19.2 (partial invoices) conflicts with the fail-closed template binding (`web/apps/api/src/modules/reports/reportBindingContract.ts`); 21.1 asks for runtime blocking on a parity difference | Every requirement mapped (§2); D23 and D24 decided | N87 |
| G74 | S3 | Documentation fragmentation | — | About 970 Markdown files in eleven trees; `web/docs/README.md` and `project-memory/README.md` each present themselves as the entry point; `web/README.md` and `project-memory/state.json` still name NestJS; backlog findings for X15 and X18 were stale; `pnpm docs:refs` checks only `web/docs` | One hub (`docs/README.md`), a register that classifies every Markdown file, handbooks, a generated menu catalog and a blocking check in CI | N87 |
| G75 | S2 | Platform control plane (Phase 2) | — | Tenant is a raw `x-tenant-id` header outside production or one `APP_TENANT_ID` per deployment (`web/apps/api/src/app.ts:241-246`, `web/apps/api/src/server.ts:91-94`); roles are tenant `ADMIN`/`USER` only; provisioning is per company | Platform realm separate from tenant users; tenant directory and lifecycle; trusted tenant resolution; consented, audited support access; onboarding | SP04–SP08, SP13, SP14, SP17 |
| G76 | S2 | Commercial model (Phase 2) | — | No plan, entitlement, subscription, invoice or usage model in the schema or route policy | Versioned plans and entitlements, limits, subscriptions, GST-compliant subscription invoices, metering | SP07, SP15, SP16 |
| G77 | S2 | Asynchronous work, storage and scale (Phase 2) | — | No durable queue (`web/docker-compose.yml` omits Redis because nothing consumes it); entity images stored as database `bytea`; per-process metrics and rate limits; local unencrypted `pg_dump` backups (`web/deploy/backup.sh`); ADR-0002 levers have no activation triggers | Outbox, queue and workers; object storage; managed PITR and per-tenant restore; telemetry and SLOs; measured scale triggers | SP09, SP10, SP12, SP18, SP24 |
| G78 | S2 | Privacy, security and compliance (Phase 2) | — | Provider credentials are process-wide environment variables; mutation audit is written after the response and records method, path and status only (`web/apps/api/src/app.ts:176`); no data-principal request workflow; India's DPDP Rules apply in phases from 14 November 2026 and 14 May 2027 | Per-tenant secrets; durable platform audit; DPDP notice, consent, request and breach workflows; independent penetration test | SP11, SP19, SP20 |
| G79 | S2 | Maintainability boundaries | — | `web/apps/api/src/routes/txn.ts` is 8,400 lines with 602 route declarations and maps errors by name pattern (lines 755–864); the largest pages are 1,867 and 1,485 lines; no OpenAPI or shared request contract (`web/packages/types/src/index.ts`); no rule rejects unbound SQL interpolation (`project-memory/parity/SECURITY-REVIEW.md:41-45`) | Per-module route plugins with schemas, typed error taxonomy, a shared voucher editor, size budgets and import/SQL lint (Phase 1); OpenAPI and contract package (Phase 2) | N88, SP03 |
| G80 | S3 | Desktop-only utilities in a SaaS (Phase 2) | `UT_BKP.cs:1223-1271` (drive backup and restore), `UT_HDD.cs:748-765` (machine registry), `UT_WINDOW.cs:1434-1439` (global tiles), destructive import/export and renumber | Phase 1 reproduces them where safe; several are unsafe or meaningless for a hosted multi-tenant service | Managed, flagged replacements that keep business results unchanged (D25) | SP21 |
| G81 | S2 | Client-side CSV export | — (the desktop exports through Crystal and Excel, not this path) | `downloadCsv` in `web/apps/web/lib/api.ts:204-212` only quotes values, and the generic report page uses it; the server encoder neutralises a leading `=`, `+`, `-` or `@` (`web/apps/api/src/modules/reports/reportCsv.ts:30-41`). Found by the independent review of this change | Every CSV the browser downloads is produced by the server encoder or encoded the same way; a test exports a cell containing `=1+1` | N57 |
| G82 | S2 | Provisioned tax masters lack the parent row | `web/apps/api/src/modules/shared/taxPolicy.ts` resolves a tax code by its parent row, `TAX_MAST.SR_NO = 0`, as the desktop tax queries do (`AND D.SR_NO = 0`) | Found while implementing N40: `web/apps/api/src/modules/ops/seedCompany.ts` provisions each tax code as a single row at `SR_NO = 1`. A sale created by rate resolves; any save that names the code (`taxCode`) fails with "tax code is not configured: 10" on every web-provisioned company | Provisioning writes the desktop shape (parent at `SR_NO = 0`, components at 1..n) and existing provisioned companies are repaired | N58 |
| G83 | S2 | Old-metal header and ledger use the posted amount | `unified/src/csharp/DataCareNext/TR_SALE.cs` totals the exchange grid (`MSG_OLD` column 13, :19336-19350) into `OLD_GL_AMT`; the web values the detail row server-side (`web/apps/api/src/modules/sales/sales.ts` `resolveOldGoldValuation`) | Found while implementing N40: `SL_PR_DETL.NET_AMT` is the server valuation (25,810 in the round-trip fixture) while `SL_DATA.OLD_GL_AMT`, `AC_DATA` and `BILL_OS` sum the client-posted `amount` (25,821.60), so one voucher carries two old-gold values | Header, ledger and detail use one valuation, chosen against the desktop grid source | N15 |
| G84 | S2 | Hallmark sale on-screen preview totals | The desktop grid shows the same line amounts it saves (`unified/src/csharp/DataCareNext/TR_SALE.cs` CommPassTotal) | Found in the N40 browser journey: `web/apps/web/app/(app)/txn/hallmark-sale/page.tsx` previews metal from fine × rate and per-gram making only, so it omits west %, ghat amount, other charges and line discounts the writer applies; one voucher previewed ₹63,056.35 and saved ₹67,414.53 | The preview uses the writer's own line arithmetic from `@datacare/core`, or the screen shows the server's computed totals | N63 |
| G85 | S3 | Depth reachability counts any literal | — | Found while implementing N54: `project-memory/parity/gap_manifest.py` treats an API input field as reachable when its name appears anywhere in the web sources; `phone` and `pin` on `EnrollSchemeInput` counted as reachable only because a report-PDF column regex contained those words, while no screen could supply them | Reachability counts only values a screen sends to that route (form state, request bodies and query strings) | N83 |

## 4. Decisions D23–D28

They continue document 11 §4 and use the same rules. All six were accepted by the owner on 1 October 2026: D25 and
D28 as the owner's instructions, D23, D24, D26 and D27 as recommended.

| ID | Decision and recommended position | Owner / deadline | Evidence |
|---|---|---|---|
| D23 | Requirement 19.2 (partial invoices). Never issue an incomplete legal document. When a template cannot be bound, refuse and list the missing fields — that satisfies "indicate which fields are missing". A watermarked draft preview is allowed for non-legal documents only | Product owner — accepted as recommended, 1 October 2026 | `web/apps/api/src/modules/reports/reportBindingContract.ts` refuses unbound templates |
| D24 | Requirement 21.1 (block on parity difference). Parity is enforced by verification and release gates (write-set database tests, the G5 differential, the release certifier), not by blocking live transactions; production records invariant failures and alerts | Product owner — accepted as recommended, 1 October 2026 | `GET /ops/invariants`, `web/apps/api/src/modules/ops/releaseCertification.ts` |
| D25 | Phase boundary. Phase 1 delivers desktop-equivalent business results and semantic layout (D20) and does not port desktop weaknesses (document 08). Phase 2 productizes. SaaS workflow changes ship behind per-tenant flags that default to desktop behaviour for migrated tenants and never change an accounting or stock result without a versioned, effective-dated decision. Accepted: owner instruction, 1 October 2026 | Product owner — accepted | [ADR-0004](../../project-memory/decisions/ADR-0004-two-phase-delivery.md) |
| D26 | Runtime and framework target. Upgrade now to the latest Next.js 15.5 security release with the React 19 patch release it requires, and move CI, images and `engines` to Node 24 LTS; rehearse Next.js 16 and Prisma 7 on a branch with the full parity suite; finish Prisma 7 before 19 November 2026 or record a dated risk acceptance | Product owner — accepted as recommended, 1 October 2026; platform lead implements it now (N86) | G72 |
| D27 | Route split timing. Strangler extraction: each N50 milestone moves its route family out of `web/apps/api/src/routes/txn.ts` into a Fastify plugin in its module, together with that family's schemas; no single large move; the exact route-universe test stays green throughout | Product owner — accepted as recommended, 1 October 2026; API lead, with N50 milestone 1 | G79 |
| D28 | Phase 2 timing. Nothing in Phase 2 starts, including the M0 decisions of document 14 §15, until Phase 1 is complete as defined in document 13 §1 and certified (N30). N86 and N88 are Phase 1 slices and continue. The plan enforces it: every Phase 2 slice depends on SP01, SP01 on N30, and `validate_plan.py` refuses a Phase 2 status other than `planned` while a Phase 1 slice it depends on is not `implemented-unverified` | Product owner — accepted (instruction), 1 October 2026 | [ADR-0004](../../project-memory/decisions/ADR-0004-two-phase-delivery.md) amendment |

## 5. Slices N83–N88

Each slice follows document 02 §4–§5 and the definition of done in document 11 §7.

#### N83 — Replay harness corrections and missing builders

Gap G69 · Parents P00-04, P01-03; X03, X06 · S2 · Size M · Start after N49

Steps:
1. Port the four corrections from the evaluation's corrected harness into
   `web/apps/api/integration/parity-replay-generic.mjs`: no `TAG_NO` for untagged lines (`N`), header discount,
   line other and labour amounts, receive-side rows with `CR_FINE`.
2. Add builders for KARIGAR ISSUE (050), KARIGAR RECEIPT (052), SALES ORDER (020) and ESTIMATE (032), using the
   request schemas from N50 where they exist.
3. For each builder, a captured desktop voucher replays to an identical write set, and a deliberately broken mapping
   fails.
4. The harness output lists every `NO_BUILDER` family, so coverage is visible in the G5 job.

Done when: no known input defect remains, the four families replay, and G5 reports coverage per family.

#### N84 — Next25 edition columns

Gap G70 · Parents P01-01, P13-01; X05, X32 · S2 · Size M · Start after N47

Steps:
1. Read the column types and defaults from the Next25 catalog (aggregate catalog queries only, no customer rows).
2. Add a forward migration with the 21 columns and register its checksum in `web/apps/api/src/modules/ops/migrationManifest.ts`.
3. Write the columns where the edition's desktop writer does (purchase tax split, `RATE_WITH`, rate-cut transfer
   and wastage fields, scheme bank account); otherwise preserve them on import and edit.
4. Include them in the migration ownership manifest (N78) and the differential comparison.

Done when: a Next25 purchase and rate cut write the same column set as the desktop, and imports keep the values.

#### N85 — Completion-register corrections

Gap G71 · Parents P00-01, P00-03; X01 · S3 · Size S · Start after N47

Steps:
1. Correct the 20 rows listed in the menu catalog in a new register revision, and regenerate the source hashes in
   `requirement-index.json` in the same pull request (the register is a hashed source).
2. Navigation: Style opens Models; "Members & Loyalty" is labelled as loyalty points; HuId Report uses
   `/reports/huid`.
3. `web/scripts/check-completion-register.mjs` checks every row's forms against the `MDI_FORM.cs` dispatch range and
   every web surface against the declared routes, using the same rules as `docs/tools/docs_check.py`.

Done when: register, navigation and catalog agree, and the check fails on a planted mismatch.

#### N86 — Supported runtime and framework baseline

Gap G72 · Parents P00-04, P12-05; X31, X34 · S1 · Size L · Start immediately

Steps:
1. Upgrade `next` to the latest 15.5 security release and `react`/`react-dom` to the patched version it requires;
   regenerate the lockfile; run every gate and the zero-mock browser suite.
2. Move `setup-node` in both workflows, `web/Dockerfile.web` and `engines` to Node 24 LTS; confirm the Playwright
   API image runs Node 24.
3. Add a dependency-advisory gate (audit against the lockfile, with reviewed exceptions by advisory identifier) to the
   static-gates CI job.
4. Upgrade Prisma to 7 with the full parity suite before 19 November 2026, when Prisma 6 security fixes end (D26).
   If it cannot land in time, record a dated risk acceptance.
5. Rehearse Next.js 16 on a branch with the full parity suite and record the result. If the 15.5 line stops
   receiving security fixes before Phase 1 is complete, move to Next.js 16 in this slice.

Done when: no installed package matches a known critical or high advisory, CI and images run Node 24, Prisma 7 is in
use (or a dated risk acceptance is recorded) before 19 November 2026, and the Next.js 16 rehearsal is recorded.

#### N87 — Documentation hub, lineage register and requirement traceability

Gaps G73, G74 · Parents P00-01, P14-06; X01, X34 · S3 · Size M · Start after N47

Steps (delivered in the pull request that added this document):
1. `docs/README.md` as the single entry point; the Desktop and Web handbooks; the generated menu catalog; the
   document register that classifies every Markdown file.
2. `lineage-register.json`, validated by `validate_plan.py`, with every earlier item and requirement.
3. `docs/tools/docs_check.py` in the blocking static-gates CI job.
4. The Phase 1 delivery plan ([document 13](13-phase1-delivery-plan.md)), the Phase 2 plan
   ([document 14](14-phase2-saas-plan.md)), agent skills under `.kiro/skills/` and `AGENTS.md`.

Remaining before acceptance: an independent reviewer compares one tab of the catalog per wave with the desktop
screens and tutorial keyframes. (The owner approved D23 and D24 on 1 October 2026.)

#### N88 — Module boundaries and static rules

Gap G79 · Parents P00-05, P02-01; X04, X07 · S2 · Size L · Start after N47; each route move is paired with an N50
milestone (D27)

Steps:
<!-- planned: web/apps/api/src/routes/index.ts -->
<!-- planned: web/apps/api/src/modules/shared/errors.ts -->

1. Route plugins: `web/apps/api/src/modules/<module>/routes.ts` registers its routes with their JSON Schemas (D16)
   and is mounted from `web/apps/api/src/routes/index.ts`; each N50 milestone moves its family (D27). The
   route-universe test (`web/apps/api/test/routePolicy.test.ts`) stays exact.
2. Typed error taxonomy in `web/apps/api/src/modules/shared/errors.ts`: 400 `invalid-request` with field paths, 401, 403, 404, 409
   version or idempotency conflict, 422 business rule, 429, 502/503 provider, 500 opaque with a correlation ID.
   It replaces the name-pattern mapping in `web/apps/api/src/routes/txn.ts:755-864`.
3. Shared voucher editor in `web/apps/web/lib/voucher/`: load, lossless hydrate, dirty tracking, save with version
   (D17) and idempotency key (D18), delete, print and a recent list with full identity. N63, N64 and N67 adopt it.
4. Static rules as CI ratchets: new or moved route and module files at most 800 lines, pages at most 600; import
   boundaries (`web/packages/core` has no I/O, pages call the API only through `web/apps/web/lib/api.ts`);
   `$queryRawUnsafe` and `$executeRawUnsafe` only inside the allow-listed helpers of
   `web/apps/api/src/modules/security/sql.ts`.

Done when: `web/apps/api/src/routes/txn.ts` shrinks with each moved family, the budgets and lint rules fail on planted violations, and
the screens moved to the shared editor pass unchanged-save tests.

## 6. Status corrections

| Item | Before | Now |
|---|---|---|
| X18 `currentFinding` (CR-01) | Tag transfer remains contained | Tag cancel, transfer and split released by N18 and N19; weight difference still contained. Recorded as `currentFindingCorrection` |
| X15 `currentFinding` (CR-02) | Credit-note IRN assumes the document exists | E CRNT and E INVOICE create/edit/delete/print lifecycle exists (N16); provider and desktop acceptance remain. Recorded as `currentFindingCorrection` |
| Completion register | 198 rows mapped | 20 rows mapped to the wrong form or surface (G71); the catalog carries the corrected view until N85 |
| N87 | — | implemented-unverified, evidence in this change |
| Decisions D23, D24, D26, D27 | Recommended, awaiting approval | Accepted as recommended by the owner, 1 October 2026; D28 added (Phase 2 waits for Phase 1) |

## 7. Documentation hub

- **Entry point:** [`docs/README.md`](../README.md). Desktop knowledge is in
  [`docs/handbook/desktop/`](../handbook/desktop/README.md), web knowledge in
  [`docs/handbook/web/`](../handbook/web/README.md), and the per-menu join of both in the
  [menu catalog](../handbook/menu-catalog.md).
- **No historical file was moved or rewritten.** Tests, scripts, evidence manifests and other documents cite them by
  path. The [document register](../handbook/doc-register.md) labels each one current, reference, historical,
  superseded, evidence or generated, with its successor.
- **Enforcement:** `python3 docs/tools/docs_check.py` fails when a Markdown file is unclassified, a catalog row
  cites a missing form, dispatch line, page, route or plan identifier, a hub link is broken, a credential-shaped
  string appears, or a generated view is stale. It runs in the static-gates CI job.

## 8. Keeping this record current

- New gaps continue at **G84** (here or in document 11, keeping numbers unique); new slices continue at **N89**, Phase 2
  slices at **SP25**, decisions at **D29**.
  Update the thresholds in `validate_plan.py` in the same pull request.
- When an item in `lineage-register.json` closes, change its disposition to `closed` with evidence; keep the row.
- Run `python3 docs/master-parity-plan-2026-09-29/validate_plan.py`, `python3 docs/tools/docs_check.py` and
  `pnpm docs:refs` before merging.
