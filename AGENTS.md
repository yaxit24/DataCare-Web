# AGENTS.md — DataCare-Web

Instructions for AI coding agents in this repository. People should start at [`docs/README.md`](docs/README.md).

## What this repository is

The offline Windows jewellery ERP **DataCareNext** (decompiled in `unified/`) is being rebuilt as a web application
(`web/`: Next.js, Fastify, PostgreSQL with forced row-level security).

- **Phase 1 — the desktop, in the web:** same menus, workflows, forms, prints and business results as the desktop.
  Plan: [`docs/master-parity-plan-2026-09-29/13-phase1-delivery-plan.md`](docs/master-parity-plan-2026-09-29/13-phase1-delivery-plan.md).
- **Phase 2 — the SaaS product:** super admin, plans and billing, managed operations, scale. **Not started until
  Phase 1 is complete and certified (decision D28).**
  Plan: [`docs/master-parity-plan-2026-09-29/14-phase2-saas-plan.md`](docs/master-parity-plan-2026-09-29/14-phase2-saas-plan.md).
- The boundary and the rule that SaaS changes never alter business results:
  [ADR-0004](project-memory/decisions/ADR-0004-two-phase-delivery.md).

## Start of every session

1. Start with `kiro-cli chat --agent datacare` from the repository root: it loads this file, the handbooks, the
   handoff and the Phase 1 plan, and runs the session-status check (step 2) for you. Then read
   [`project-memory/HANDOFF.md`](project-memory/HANDOFF.md).
2. See what other sessions are doing: `python3 docs/tools/session_status.py` (the `datacare` agent runs it on
   start). It lists active kiro-cli sessions and what each is doing, the worktrees, open pull requests, recently
   pushed branches, and whether the test database port is busy. Never take a slice another session, worktree or open
   PR already has; do not touch their branches or files. Rebase before pushing, because the backlog changes often.
   If main's CI is red and nobody is fixing it, fix that first.
3. Take the next slice from document 13 §3 and check its status in
   `docs/master-parity-plan-2026-09-29/execution-backlog.json` (slices N01–N88). Phase 2 slices in
   `phase2-backlog.json` are not started until Phase 1 is certified (D28). Read the affected menus in
   `docs/handbook/menu-catalog.jsonl`.

## Which documents to follow

The plan is one set: the folder `docs/master-parity-plan-2026-09-29/` (documents 01–14, `execution-backlog.json` and
`phase2-backlog.json`) plus the handbooks in `docs/handbook/`. Documents 01–11 (29 September and 1 October) hold the
slice specifications; documents 12–14 and the handbooks (1 October) add the delivery order, the newer slices and
decisions, and how to build and test. Use them together:

| Question | Where |
|---|---|
| Which slice is next? | Document 15 §5 (Standard edition first, decision D31), then document 13 §3, then the slice's status in `execution-backlog.json` |
| Is a menu in scope now? | Its edition in `docs/handbook/menu-editions.json`: only Lite, Basic and Standard menus (`L`, `B`, `S`) until Standard runs in production (document 15) |
| What exactly must the slice do? | Its specification — document 02 §4 with document 06 (N01–N30), 10 (N31–N46), 11 §6 (N47–N82), 12 §5 (N83–N88) — its gap rows, and the decisions it cites |
| What rules apply to every slice? | Document 03 (shared contracts), document 04 (tests, journeys, acceptance), `docs/handbook/web/engineering-standards.md` |
| What does the desktop do? | The desktop source, through the `datacare-desktop-authority` skill; document 05; `docs/handbook/desktop/` |
| What is the state of a menu? | Its row in `docs/handbook/menu-catalog.jsonl` |
| How do I build and test it? | `docs/handbook/web/` and the skills below |

Do not plan or prioritise from older documents: the root plans and reports of August–September 2026,
`parity-plan-2026-09-10/`, the plans in `web/docs/`, `web-implementation-spec/07_Build_Plan/` and the July plans in
`project-memory/parity/`. Every open item in them is already carried into the backlog (`lineage-register.json`), and
`docs/handbook/doc-register.md` labels each of them. Reference material — the video knowledge base, the catalogs,
the table specifications in `web-implementation-spec/02_Data_Model/`, `web/docs/TECHNICAL-REFERENCE.md` — is still
useful background.

When documents disagree:

1. Status: the backlog JSON wins over any prose.
2. Plan content: the later document wins (12 over 11 over 10 over 01–09), and an accepted decision wins over the
   text it decides.
3. Business behaviour: the desktop source wins over every document.
4. The code wins over a handbook's description of it; correct the handbook in the same pull request.
5. A slice that needs a decision the owner has not accepted stops until the user decides. The decision tables in
   documents 08 §1, 11 §4 and 12 §4 record which are accepted.

## Hard rules

- **Never push to `main`.** Work on a branch, open a pull request with `gh pr create`, watch CI.
- **Stage specific files** (no `git add .`); keep hooks enabled; do not amend pushed commits; no force push without
  the user's permission.
- **The desktop is the authority** for business behaviour: cite `unified/src/csharp/DataCareNext/<FORM>.cs:<line>`
  for every behaviour change. Do not port desktop weaknesses (string-built SQL, plaintext passwords, global state,
  unscoped deletes, partial writes).
- **Never print or copy secrets.** The repository intentionally tracks legacy credentials (`SECURITY-NOTICE.md`);
  refer to environment variables by key name only.
- **Desktop databases: aggregate queries only.** One of them holds real customer data; never select or store names,
  phone numbers, addresses or row dumps.
- **Tests run on the isolated database** (`web/scripts/parity-test-env.mjs`, port 55433 by default), never on a database with
  real data.
- **Never move, rename or rewrite historical documents**; they are cited by path. Add new documents and classify them
  in `docs/handbook/doc-register.json`.
- **Status lives in the backlogs**, never in prose, and no slice is ever marked accepted.

## Skills (`.kiro/skills/`)

| Skill | Use it to |
|---|---|
| `datacare-implement-slice` | Implement a slice, gap or menu end to end |
| `datacare-desktop-authority` | Find exactly what the desktop does, with citations |
| `datacare-write-set-test` | Write a complete write-set database test |
| `datacare-e2e-visual` | Verify screens in Chrome through the Chrome DevTools MCP |
| `datacare-feature-browser-validation` | Operate the complete feature in the browser, validate business effects, and measure exact required-case coverage separately from desktop match |
| `datacare-code-review` | Review a change against the engineering standards |
| `datacare-plan-update` | Record status, gaps, slices and decisions in the plan |
| `datacare-docs-update` | Keep the menu catalog, register and handbooks current |
| `datacare-test-first` | Write the test before the code, with desktop-derived expected values |
| `datacare-debug` | Find a bug's root cause before fixing it |
| `datacare-verify-before-done` | Run the gates and quote the output before claiming success |

The last three are DataCare adaptations of [Superpowers](https://github.com/obra/superpowers) skills (MIT); see
`.kiro/skills/third-party/README.md`.

## Commands

```bash
# in web/
pnpm install --frozen-lockfile
pnpm lint && pnpm typecheck && pnpm typecheck:tests && pnpm format:check && pnpm build
node scripts/parity-test-env.mjs -- pnpm --filter @datacare/api test          # API + database tests
API_ORIGIN=http://127.0.0.1:4410 pnpm build && node scripts/parity-test-env.mjs -- node apps/web/test/parity.real-stack.mjs
pnpm docs:refs

# at the repository root
python3 docs/master-parity-plan-2026-09-29/validate_plan.py
python3 docs/tools/docs_check.py            # add --write to regenerate the generated views
python3 docs/tools/session_status.py        # what other sessions, worktrees and PRs are in flight
```

## Agent and optional tools

- **Project agent:** `.kiro/agents/datacare.json`. `kiro-cli chat --agent datacare` loads this file, the handbooks,
  the handoff and the Phase 1 plan, runs the session-status check on start, keeps your global MCP servers
  (`chrome-devtools`, `browsermcp`), and blocks pushing to `main`, force-push, `git reset --hard`, `git clean -f`,
  `--no-verify` and `gh pr merge`.
- **Context7 (optional, off by default):** an MCP server that gives up-to-date, version-specific library
  documentation (useful for the Next.js, React and Prisma 7 upgrade in N86). It sends your questions to Upstash's
  service, so turn it on only with the owner's agreement and never send code, data or secrets through it. To enable
  it, add it to your global `~/.kiro/settings/mcp.json`, not to a committed file.

## Definition of done for a change

1. Desktop authority cited; behaviour matches it.
2. Tests: kernel vectors for calculations, a write-set database test for writers, schema and policy tests for
   routes, a zero-mock journey and the visual protocol for screens
   ([`docs/handbook/web/testing.md`](docs/handbook/web/testing.md)).
3. For a feature or workflow claim, use the [feature browser validation skill](.kiro/skills/datacare-feature-browser-validation/SKILL.md): freeze the applicable T01–T18 cases, execute through the real UI, check complete persisted and downstream effects, and retain the validated evidence bundle. Blocked/untested cases remain in coverage; browser success never implies desktop acceptance.
4. Code follows [`docs/handbook/web/engineering-standards.md`](docs/handbook/web/engineering-standards.md).
5. All commands above pass.
6. Backlog, document 11 §2 (or document 12 §6) and the affected menu-catalog rows are updated.
7. The pull request states what was verified and what was not.

## Where to look

| Need | Path |
|---|---|
| Documentation hub | [`docs/README.md`](docs/README.md) |
| Desktop behaviour | [`docs/handbook/desktop/README.md`](docs/handbook/desktop/README.md), `unified/src/csharp/DataCareNext/` |
| One menu, end to end | [`docs/handbook/menu-catalog.md`](docs/handbook/menu-catalog.md) |
| Web architecture and modules | [`docs/handbook/web/README.md`](docs/handbook/web/README.md), [`docs/handbook/web/modules.md`](docs/handbook/web/modules.md) |
| Gaps and decisions | Documents 10, 11 and 12 in `docs/master-parity-plan-2026-09-29/` |
| Acceptance rules and journeys J01–J28 | [`docs/master-parity-plan-2026-09-29/04-verification-playbook.md`](docs/master-parity-plan-2026-09-29/04-verification-playbook.md) |
