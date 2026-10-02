---
name: datacare-implement-slice
description: Implement one DataCare plan slice (N.., or SP.. once Phase 1 is certified), gap (G..) or desktop menu end to end — desktop authority, tests first, implementation, verification, plan record and pull request. Use when asked to implement, continue or fix a slice, gap or menu in the DataCare-Web repository.
---

# Implement a DataCare slice

Target: `$ARGUMENTS` (a slice such as `N64`, a gap such as `G50`, or a menu such as `Transaction/Cash Received`).

Follow every step. Stop and ask the user before anything destructive, before pushing to `main` (never do it), or
when the desktop authority and the plan disagree.

## 0. Orient

1. Read `project-memory/HANDOFF.md` and the top of `project-memory/JOURNAL.md`.
2. `git status`, `git fetch origin`, `git worktree list`. Other sessions may be working in other worktrees: do not
   touch their branches or files, and expect `execution-backlog.json` to change under you (rebase before pushing).
3. Create a branch from `origin/main`: `feat/<slice>-<short-name>` (or `fix/…`, `docs/…`).

## 1. Find the work

1. The slice in `docs/master-parity-plan-2026-09-29/execution-backlog.json` (`newSlices`): status, `startAfter`,
   `gapIds`, `parentLabels`. Phase 2 slices (`phase2-backlog.json`) are not started until Phase 1 is certified (D28):
   if the target is an SP slice, stop and tell the user.
2. Its specification in `docs/master-parity-plan-2026-09-29/`: document 02 §4 with document 06 (N01–N30), 10
   (N31–N46), 11 §6 (N47–N82) or 12 §5 (N83–N88); its gap rows; and the decisions it cites. If a decision it needs
   is not marked accepted in document 08 §1, 11 §4 or 12 §4, stop and ask the user.
3. The parent cards in `priorCards` (`existingFiles`, `currentRemainingGap`, `verificationCases`).
4. The menus it touches: search `docs/handbook/menu-catalog.jsonl` for the slice ID; read those rows.
5. If a `startAfter` slice is not done, say so and propose the order before continuing.

## 2. Establish the desktop authority

Use the `datacare-desktop-authority` skill. Write a short note: dispatch line, form source lines for load, save,
delete and print, posting helpers, tables written, calculations with their rounding stages, validations and their
messages, prints and copies, and the tutorial keyframe that shows the screen. Mark anything source-derived but not
confirmed by a desktop row as *inferred*.

## 3. Write the contract and tests first

1. Inputs and their JSON Schema (D16), the business-scope fields the server owns, refusals and their status codes.
2. Expected write set per table, derived independently (never from the web's own output).
3. Failing tests: kernel vectors for calculation changes; a write-set database test (`datacare-write-set-test`
   skill); route schema and policy tests; the route-universe count if routes change.

## 4. Implement

Follow `docs/handbook/web/engineering-standards.md`. In particular:

- New routes get a JSON Schema. If module route plugins exist (`web/apps/api/src/modules/<module>/routes.ts`, slice
  N88), add them there; until N88 creates the first plugin, add them next to their family in
  `web/apps/api/src/routes/txn.ts` so they move with it, and say so in the pull request.
- Accounts and books from `BOOK_DETL` slots and the session; no literal codes.
- Calculations through `@datacare/core`; rounding at the desktop's stages.
- One `withTenant` transaction for the whole write set; version token on edit and delete; idempotency key on
  financial creates.
- Screens hydrate every returned field; an unchanged save changes nothing.
- File-size limits: new or moved API files ≤ 800 lines, pages ≤ 600; existing large files may not grow.

## 5. Verify

From `web/`:

```bash
pnpm lint && pnpm typecheck && pnpm typecheck:tests && pnpm format:check && pnpm build
node scripts/parity-test-env.mjs -- pnpm --filter @datacare/api test
API_ORIGIN=http://127.0.0.1:4410 pnpm build && node scripts/parity-test-env.mjs -- node apps/web/test/parity.real-stack.mjs
pnpm depth:parity && pnpm depth:deadcells && pnpm docs:refs
```

From the repository root:

```bash
python3 docs/master-parity-plan-2026-09-29/validate_plan.py
python3 docs/tools/docs_check.py
```

Add or extend a zero-mock journey for every changed screen (`docs/handbook/web/testing.md` §4) and run the visual
protocol with the `datacare-e2e-visual` skill. If the isolated database port 55433 is busy (another session), run the
wrapper on another port (`PARITY_TEST_PORT`, and `PARITY_API_PORT`/`PARITY_WEB_PORT` for browser suites; testing §2);
never point tests at a database that holds real data.

## 6. Record

1. `datacare-plan-update` skill: slice status (`in-progress` or `implemented-unverified` only), `statusAsOf`,
   `evidence` paths that exist, `statusNote`; document 11 §2 row; any new defect as a gap continuing at G84.
2. `datacare-docs-update` skill: update the menu-catalog rows whose web state changed and regenerate.

## 7. Commit and open the pull request

1. `git add` the specific files (never `git add .`); check for secrets; keep hooks enabled.
2. Commit message: `<type>(<scope>): <what> (<slice>)`.
3. `git fetch origin && git rebase origin/main`, re-run the validators, `git push -u origin <branch>`.
4. `gh pr create` with: summary, desktop authority cited, tests added, commands run with results, visual protocol
   summary, what was not verified, and follow-ups.
5. Watch CI (`gh pr checks`) and fix failures.

## Done when

- The slice's "Done when" in its specification holds, with evidence in the backlog.
- Every gate above is green, and the pull request says plainly what was and was not verified.
- No acceptance is claimed: acceptance belongs to the parent packages (document 04).
