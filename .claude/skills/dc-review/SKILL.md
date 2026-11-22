---
name: dc-review
description: Review the result of a DataCare-Web worker run or a work-package pull request as the architect — read the dispatcher summary, the tests before the code, and the writers of money and stock to the depth the risk tier requires, then decide merge-ready, fix packet, case-list correction or owner question. Use after a packet chain reaches review, before opening or approving any pull request, and whenever a run passed but something looks off.
---

# Review as the architect

The checks and tiers are defined in `orchestration/QUALITY.md`. This is the procedure. Stop at the first step
that fails and act on it; do not keep reading for completeness.

## 1. What scripts already proved

```bash
node orchestration/bin/orch.mjs status
```

Open the last run's `summary.md` (its path is in the ledger line and in the dispatcher's output). Note: verdict,
attempts, tier used, changed files, warnings. More than one attempt, an escalation, or a baseline warning means
you read one level deeper than the tier requires.

## 2. Scope

In the package's worktree:

```bash
git diff --stat origin/main...HEAD
```

Every file should follow from the packets. Open any that does not.

## 3. Tests before code

```bash
git diff origin/main...HEAD -- 'web/**/test/**' 'web/**/*.test.*'
```

For each new assertion ask where the expected value comes from. Accept: computed in the test from seeded inputs
with the desktop formula, citation above it. Reject: a literal that could have been copied from the
application, a snapshot of current output, an assertion only that a call did not throw. Check `red.md`: each new
test id failed before the change for the stated reason.

## 4. Depth by risk tier

| Tier | You read |
|---|---|
| A | Every changed writer end to end, and the desktop lines each rule cites. Check: one transaction; tenant, company, location and year in every statement; accounts from book slots; rounding only through the core functions; delete restores what create consumed; a replay posts once; a second tenant sees nothing; the migration's manifest hash |
| B | The `review` packet's findings and the hunks they point at; the resolver's totals against the case list; one in three pull requests in full |
| C | Nothing more, unless step 1 or 2 raised a flag |

Use the `dc-reviewer` subagent for a second read of a specific file when you want an opinion that is not
anchored on yours: give it the path and the study, not your conclusion.

## 5. The screen and the print

Read `orchestration/work/<WP>/verify.md`: the three numbers, the case table, the differences from the desktop.
"Not ready" in its verdict is a stop. A case marked blocked needs a reason that is outside this package.

## 6. Decide

| Decision | When | Next |
|---|---|---|
| Merge-ready | Every rung required for the tier is done and clean | Records packet, pull request, tell the owner |
| Fix | Concrete findings | A `fix` packet that lists each finding with file, line and the failing input |
| Case list | A behaviour of the desktop has no case | Correct `cases.md` yourself or with a `cases` packet, then a `tests` packet |
| Owner | The source and the data disagree, or a decision is missing | One clear question; switch lane meanwhile |

Write the decision and its reason in the pull request, including what you did not read.
