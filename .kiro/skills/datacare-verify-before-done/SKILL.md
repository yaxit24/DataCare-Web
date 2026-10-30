---
name: datacare-verify-before-done
description: Before claiming a DataCare change is complete, fixed or passing — and before committing or opening a pull request — run the actual gate commands this turn and quote their output. Evidence before claims. Use whenever about to report success.
---

# Verify before done

Adapted for DataCare from the Superpowers `verification-before-completion` skill
(github.com/obra/superpowers, MIT; see `.kiro/skills/third-party/README.md`).

## The rule

No completion claim without fresh evidence. If you have not run the command in this turn, you cannot say it passes.
"Should pass", "looks right" and a success message from a sub-agent are not evidence.

## The gate

Before writing "done", "fixed", "passing" or opening a pull request:

1. Name the command that proves the claim.
2. Run the full command now (not a partial run, not a remembered one).
3. Read all of its output and its exit code; count failures.
4. If it does not confirm the claim, report the real status with the output. Only if it does, make the claim and
   quote the evidence.

## The commands for a DataCare change

From `web/` unless noted; see `docs/handbook/web/testing.md` for which apply to your change:

```bash
pnpm lint && pnpm typecheck && pnpm typecheck:tests && pnpm format:check && pnpm build
node scripts/parity-test-env.mjs -- pnpm --filter @datacare/api test            # writers, routes, RLS
API_ORIGIN=http://127.0.0.1:4410 pnpm build && node scripts/parity-test-env.mjs -- node apps/web/test/parity.real-stack.mjs
pnpm depth:parity && pnpm depth:deadcells && pnpm docs:refs
```

From the repository root, for any plan or documentation change:

```bash
python3 docs/master-parity-plan-2026-09-29/validate_plan.py
python3 docs/tools/docs_check.py
```

For a changed screen, the `datacare-e2e-visual` protocol must also have been run and recorded.

## What counts as proof

| Claim | Proof | Not proof |
|---|---|---|
| Tests pass | The test command's output: 0 failures, this turn | A previous run, "should pass" |
| Build succeeds | The build command: exit 0 | Lint passing, logs look fine |
| Bug fixed | The test for the original symptom passes, after a red/green cycle | Code changed, assumed fixed |
| Write set matches | The write-set database test passes with desktop-derived expected values | The web returns something |
| Plan is consistent | `validate_plan.py` and `docs_check.py` print `pass` this turn | Edited carefully |

## Feature behavior claims

Before reporting that a feature works, apply the [feature browser validation skill](../datacare-feature-browser-validation/SKILL.md). Retain the required-case matrix and real browser/business evidence, run its exact-set validator, and report failed, blocked and untested cases. A green code gate or successful page render is not feature verification; desktop execution and product acceptance are separate claims.

## Red flags — stop and run the command

- "should", "probably", "seems to"; "Great!", "Perfect!", "Done!" before any command ran.
- About to commit, push or open a PR without the gate output in front of you.
- Trusting a sub-agent's "success" without checking the diff and the gate.
