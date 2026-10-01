# AGENTS.md — DataCare-Web

Instructions for AI coding agents in this repository. People should start at [`docs/README.md`](docs/README.md).

## What this repository is

The offline Windows jewellery ERP **DataCareNext** (decompiled in `unified/`) is being rebuilt as a web application
(`web/`: Next.js, Fastify, PostgreSQL with forced row-level security).

- **Phase 1 — the desktop, in the web:** same menus, workflows, forms, prints and business results as the desktop.
  Plan: [`docs/master-parity-plan-2026-09-29/13-phase1-delivery-plan.md`](docs/master-parity-plan-2026-09-29/13-phase1-delivery-plan.md).
- **Phase 2 — the SaaS product:** super admin, plans and billing, managed operations, scale.
  Plan: [`docs/master-parity-plan-2026-09-29/14-phase2-saas-plan.md`](docs/master-parity-plan-2026-09-29/14-phase2-saas-plan.md).
- The boundary and the rule that SaaS changes never alter business results:
  [ADR-0004](project-memory/decisions/ADR-0004-two-phase-delivery.md).

## Start of every session

1. Read [`project-memory/HANDOFF.md`](project-memory/HANDOFF.md).
2. `git status`, `git fetch origin`, `git worktree list`: other sessions often work in parallel worktrees. Do not
   touch their branches or files; rebase before pushing because the backlog changes often.
3. Find the work in `docs/master-parity-plan-2026-09-29/execution-backlog.json` (slices N01–N88) or
   `phase2-backlog.json` (SP01–SP24), and the affected menus in `docs/handbook/menu-catalog.jsonl`.

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
- **Tests run on the isolated database** (`web/scripts/parity-test-env.mjs`, port 55433), never on a database with
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
| `datacare-code-review` | Review a change against the engineering standards |
| `datacare-plan-update` | Record status, gaps, slices and decisions in the plan |
| `datacare-docs-update` | Keep the menu catalog, register and handbooks current |

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
```

## Definition of done for a change

1. Desktop authority cited; behaviour matches it.
2. Tests: kernel vectors for calculations, a write-set database test for writers, schema and policy tests for
   routes, a zero-mock journey and the visual protocol for screens
   ([`docs/handbook/web/testing.md`](docs/handbook/web/testing.md)).
3. Code follows [`docs/handbook/web/engineering-standards.md`](docs/handbook/web/engineering-standards.md).
4. All commands above pass.
5. Backlog, document 11 §2 (or document 12 §6) and the affected menu-catalog rows are updated.
6. The pull request states what was verified and what was not.

## Where to look

| Need | Path |
|---|---|
| Documentation hub | [`docs/README.md`](docs/README.md) |
| Desktop behaviour | [`docs/handbook/desktop/README.md`](docs/handbook/desktop/README.md), `unified/src/csharp/DataCareNext/` |
| One menu, end to end | [`docs/handbook/menu-catalog.md`](docs/handbook/menu-catalog.md) |
| Web architecture and modules | [`docs/handbook/web/README.md`](docs/handbook/web/README.md), [`docs/handbook/web/modules.md`](docs/handbook/web/modules.md) |
| Gaps and decisions | Documents 10, 11 and 12 in `docs/master-parity-plan-2026-09-29/` |
| Acceptance rules and journeys J01–J28 | [`docs/master-parity-plan-2026-09-29/04-verification-playbook.md`](docs/master-parity-plan-2026-09-29/04-verification-playbook.md) |
