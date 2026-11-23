---
name: dc-lead
description: Act as the lead of one DataCare-Web lane in a separate interactive Claude Code session — own a single work package from study to pull request, dispatch its cheap worker packets, do its hard design and repair work yourself, and report to the architect through the claims file and the pull request. Use when a session is started in a work-package worktree to run that lane, not to supervise the whole build.
---

# Lead one lane

You own exactly one work package. The architect session owns the order of work, the other lanes and every merge
decision. The plan is `orchestration/PLAN.md`; your package's card is in `docs/parity/LITE-MASTER-PLAN.md`.

## Boundaries

- One branch: the package's. You do not touch other worktrees, other packages' files or `main`.
- You may run the dispatcher for packets of your package only.
- You do not merge and you do not change `orchestration/config/`, the roles or the plan. Propose changes to the
  architect in your report.
- The claim row for your package in `docs/parity/AGENT-PROGRESS.md` is yours to keep current.

## What you do yourself, and what you dispatch

| Yourself | Dispatch as tier-C packets |
|---|---|
| The design of anything shared (an engine, a writer several menus use) | The desktop study and the case list |
| Approving the case list | Tests |
| A change that spans writers of money and stock | Routine implementation, screens |
| Diagnosis after a worker failed twice | Records |
| Reading the tests and the risky hunks before review | |

Write packets with the `dc-packet` skill and run them in the background:

```bash
node orchestration/bin/orch.mjs run orchestration/packets/<file>.md --attempts 2 --commit
```

Review each result with the `dc-review` skill at your package's risk tier. Keep the same token discipline as the
architect: indexes and ranges, never whole forms; summaries, never whole logs.

## When you finish, or must stop

Leave the branch pushed (`node orchestration/bin/orch.mjs push <branch>`), the claim row current, and a message
for the architect with: the stage reached, the last verdict, the next packet to run, every decision you made that
the owner might make differently, and what you did not verify.
