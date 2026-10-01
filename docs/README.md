# DataCare documentation hub

DataCareNext is an offline Windows jewellery and gold ERP (VB.NET WinForms, SQL Server, Crystal Reports) sold by
DataCare Softech India. This repository rebuilds it as a web application (`web/`: Next.js, Fastify, PostgreSQL) and
keeps the complete desktop product as the reference (`unified/`). This page is the single entry point to the
documentation; every other document is reachable from here.

## The goal, in two phases

| Phase | Outcome | Plan |
|---|---|---|
| **Phase 1 — the desktop, in the web** | Every in-scope desktop menu, workflow, form, print and business rule works in the browser, with the same database write sets, calculations and report data as the desktop. Layout parity is semantic (same regions, fields, order, keyboard flow), not pixel-exact. Desktop weaknesses are not ported. | [Phase 1 delivery plan](master-parity-plan-2026-09-29/13-phase1-delivery-plan.md) |
| **Phase 2 — the SaaS product** | The certified web application becomes a product sold online to many jewellery businesses: super-admin console, tenant onboarding, plans and billing, managed operations, compliance and measured scaling. SaaS workflow changes ship behind per-tenant flags and never change business results. Starts only after Phase 1 is complete and certified (decision D28). | [Phase 2 SaaS plan](master-parity-plan-2026-09-29/14-phase2-saas-plan.md) |

The boundary is recorded in [ADR-0004](../project-memory/decisions/ADR-0004-two-phase-delivery.md).

## Where things stand (1 October 2026)

- The web application is substantial: 128 pages, 608 declared API routes, 174 PostgreSQL tables under forced
  row-level security, a pure calculation kernel and about 5,700 automated tests. A fresh company can log in, set the
  daily rate, sell, reopen, edit and print a sale, take a receipt and record a purchase, with balanced ledger, day
  book, stock and GST effects ([document 11 §1](master-parity-plan-2026-09-29/11-audit-implementation-plan-2026-10-01.md)).
- **Nothing is accepted yet:** 0 of 198 desktop menus, 0 of 83 packages and 0 of 34 cards. Acceptance needs a desktop
  comparison, operator sign-off and release certification ([document 04](master-parity-plan-2026-09-29/04-verification-playbook.md)).
- Engineering grade of the 198 menus, from the [menu catalog](handbook/menu-catalog.md#summary): 126 partial
  workflows, 65 reports with incomplete modes or layouts, 2 deliberately contained operations, 5 missing workflows.
  131 menus are needed by a typical jewellery business (P1-core), 66 only for specific editions or settings.
- Open work is ordered in [document 13](master-parity-plan-2026-09-29/13-phase1-delivery-plan.md) and tracked in
  [`execution-backlog.json`](master-parity-plan-2026-09-29/execution-backlog.json) (slices N01–N88) and
  [`phase2-backlog.json`](master-parity-plan-2026-09-29/phase2-backlog.json) (SP01–SP24).

## Start here

| I want to… | Read |
|---|---|
| Understand what the desktop product does and how operators use it | [Desktop handbook](handbook/desktop/README.md), then [business rules](handbook/desktop/business-rules.md) and the [module guide](handbook/desktop/modules.md) |
| Look up one desktop menu: its form, tables, web screen, status and owners | [Menu catalog](handbook/menu-catalog.md) |
| Understand the web code, its stack and how a request flows | [Web handbook](handbook/web/README.md) and the [module map](handbook/web/modules.md) |
| Set up the project on my laptop | [Developer setup](handbook/dev/setup.md) |
| Connect a scale, scanner, printer or camera | [Supported devices](handbook/dev/devices.md) |
| Pick up the next piece of work | [`project-memory/HANDOFF.md`](../project-memory/HANDOFF.md), then the queue in [document 13 §3](master-parity-plan-2026-09-29/13-phase1-delivery-plan.md#3-delivery-order) |
| Implement a slice to the expected quality | [Engineering standards](handbook/web/engineering-standards.md), [testing](handbook/web/testing.md) and the agent skills in [`AGENTS.md`](../AGENTS.md) |
| Test in a real browser, including visual checks with Chrome DevTools | [Testing §5](handbook/web/testing.md#5-visual-and-interactive-verification-with-chrome-devtools-mcp) |
| Research a desktop behaviour safely | [Desktop handbook §9](handbook/desktop/README.md#9-sources-and-how-to-research-desktop-behaviour) |
| Change the plan (new gap, slice status, decision) | [Document 12 §8](master-parity-plan-2026-09-29/12-lineage-verification-2026-10-01.md#8-keeping-this-record-current) |
| Find out whether an older document still applies | [Document register](handbook/doc-register.md) and the [lineage verification](master-parity-plan-2026-09-29/12-lineage-verification-2026-10-01.md) |

## Documentation map

**Current — maintained with the code**

- `docs/README.md` (this page), `docs/handbook/desktop/` and `docs/handbook/web/`: the handbooks.
- [Menu catalog](handbook/menu-catalog.md) (generated from `docs/handbook/menu-catalog.jsonl`): one entry per
  desktop menu joining the desktop form, behaviour, look, tables, web routes, capabilities, gaps and plan owners.
- [Master plan](master-parity-plan-2026-09-29/README.md): assessment (01), execution waves (02), shared contracts
  (03), verification playbook and journeys J01–J28 (04), desktop reference (05), module detail (06), reconciliation
  of earlier plans (07), decisions D01–D14 and delivery (08), surface register (09), gap registers G01–G83 (10, 11,
  12), the Phase 1 plan (13) and the Phase 2 plan (14).
- Decisions: [ADRs](../project-memory/decisions/) 0001–0004 and plan decisions D01–D28 (documents 08, 11 and 12).
- Continuity: [`project-memory/HANDOFF.md`](../project-memory/HANDOFF.md), `project-memory/JOURNAL.md` and
  `project-memory/state.json`.
- Agents: [`AGENTS.md`](../AGENTS.md), the project agent `.kiro/agents/datacare.json`
  (`kiro-cli chat --agent datacare`), ten skills in `.kiro/skills/` (three adapted from
  [Superpowers](https://github.com/obra/superpowers), MIT) and `.kiro/steering/`. `docs/tools/session_status.py`
  shows what other sessions are doing.

**Reference — still-valid method and knowledge**

- Desktop: [`unified/README.md`](../unified/README.md) (resource centre), the tutorial-video knowledge base
  [`project-memory/video-research/_kb/`](../project-memory/video-research/_kb/README.md), the per-form catalogs in
  `project-memory/catalogs/forms/`, and the table-by-table specification in `web-implementation-spec/02_Data_Model/`.
- Web: [`web/docs/TECHNICAL-REFERENCE.md`](../web/docs/TECHNICAL-REFERENCE.md) (conventions; its counts are pinned by
  `pnpm docs:refs`), [`web/docs/ROJMEL-HANDBOOK.md`](../web/docs/ROJMEL-HANDBOOK.md), [`web/DEPLOY.md`](../web/DEPLOY.md)
  and [`web/apps/api/SECURITY.md`](../web/apps/api/SECURITY.md).

**History and evidence**

Every Markdown file is listed in the [document register](handbook/doc-register.md) under one of six statuses
(current, generated, reference, historical, superseded, evidence), with its successor where one exists. Their open items are carried, one by one, in
[`lineage-register.json`](master-parity-plan-2026-09-29/lineage-register.json): 228 items from 37 sources, each
closed, owned by a current plan identifier, or recorded as one of the new gaps G69–G80.

## Sources of truth

| Question | Authority |
|---|---|
| What does the desktop do? | The decompiled source in `unified/src/csharp/DataCareNext/`, the desktop databases and the tutorial videos, in the order given by [document 05](master-parity-plan-2026-09-29/05-desktop-reference.md) |
| What does the web do? | The code in `web/`; handbooks describe it but the code wins |
| What is the status of a piece of work? | `execution-backlog.json` and `phase2-backlog.json`, never prose |
| Is anything accepted? | Only what [document 04](master-parity-plan-2026-09-29/04-verification-playbook.md) acceptance and the release certifier record |
| Which document is current? | The [document register](handbook/doc-register.md) |
| Which plan does an agent build from? | This plan folder (documents 01–14 and its backlogs) with the handbooks, as set out in "Which documents to follow" in [`AGENTS.md`](../AGENTS.md#which-documents-to-follow); older plans are history |
| Where is a gap or decision defined? | Gaps G01–G19 in document 10, G20–G68 in 11, G69–G83 in 12; decisions D01–D14 in 08, D15–D22 in 11, D23–D28 in 12 |

## Rules for documentation

1. **Never move, rename or rewrite historical files.** Tests, scripts, evidence manifests and other documents cite
   them by path. To redirect readers, add a short banner at the top.
2. **Classify every new Markdown file** by adding or extending a rule in `docs/handbook/doc-register.json`; the
   check fails on an unclassified file.
3. **Cite files from the repository root** in backticks, with line ranges where they matter
   (`web/apps/api/src/app.ts:241-246`). The check verifies the file exists and the range fits. Declare a file that a
   planned slice will create with `<!-- planned: path -->`.
4. **Keep status out of prose.** Write status in the backlogs; date any count you put in prose, or pin it with a
   checked claim.
5. **Never write credentials or customer data.** Name environment variables by key only. The check scans the hub,
   handbooks, plan documents 12–14, skills and `AGENTS.md` for credential-shaped strings and phone numbers.

## Checks

```bash
python3 docs/tools/docs_check.py            # hub, handbooks, menu catalog, document register, links, citations
python3 docs/tools/docs_check.py --write    # regenerate menu-catalog.md and doc-register.md, then check
python3 docs/master-parity-plan-2026-09-29/validate_plan.py   # plan integrity, lineage register, backlogs
cd web && pnpm docs:refs                    # citations and pinned claims in web/docs
```

All three run in the blocking `static-gates` job of `.github/workflows/ci.yml`.
