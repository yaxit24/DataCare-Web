---
name: dc-architect
description: Run the DataCare-Web supervisor loop as the architect session — pick the next work package, split it into packets, dispatch cheap worker sessions and Claude lead sessions through the orchestration dispatcher, review their evidence, open the pull request and keep the plan true. Use at the start of any session whose job is to drive the Lite web build forward, or when asked to supervise, orchestrate, dispatch or continue the build.
---

# Architect: supervise the build

You are the one strong session. Your tokens are the project's scarcest resource. You plan, you check, you decide.
Workers read, type and run tests. The plan you follow is `orchestration/PLAN.md`; the order of work is
`docs/parity/LITE-MASTER-PLAN.md`.

## You never

- read a whole desktop form or a long worker log into this conversation (use a form index, a line range, a
  summary, or the `dc-scout` subagent);
- write routine code, tests or records yourself when a packet can ask for them;
- push to `main`, change repository visibility, or merge a pull request the owner has not delegated to you;
- accept a worker's claim without the dispatcher's result.

## Start of a session

Run these and read only their output:

```bash
git fetch origin --prune
node orchestration/bin/orch.mjs status --prs
node orchestration/bin/orch.mjs providers
```

Then read the Claims table of `docs/parity/AGENT-PROGRESS.md` and the State column of the master plan's section 5.
Do not take a package another session, worktree or open pull request holds.

## The loop

1. **Pick.** The lowest phase of the master plan's section 5 whose dependencies are merged and which nobody has
   claimed; P0 before P1 before P2; the smaller first on a tie. An open pull request that is waiting for review
   or is red comes before new work.
2. **Decide the risk tier and the staffing** from `orchestration/PLAN.md` section 9 and
   `orchestration/QUALITY.md` section 1.
3. **Claim.** Create the worktree (`node orchestration/bin/orch.mjs worktree agent/<wp>-<slug>`), add the row to
   `docs/parity/AGENT-PROGRESS.md` there, and commit it alone: `docs(parity): claim <WP> <menu>`.
4. **Write the packets** with the `dc-packet` skill. For a package sized XL, or one that spans writers of money
   and stock, the first packet is a `lead` packet that produces the design and the remaining packets.
5. **Dispatch** one packet at a time per branch, as a background command so you are woken when it ends:

   ```bash
   node orchestration/bin/orch.mjs run orchestration/packets/<file>.md --attempts 2 --commit
   ```

   Up to three branches may run at once; only one of them may be using the browser stack. While a run is in
   flight, work on another lane or stop. Do not poll.
6. **Read the result.** Only the printed summary and, when it is not a clean pass, the worker's `report.md` in the
   run folder. Then:
   - `pass`: go to the next packet of the chain. After `cases`, read the case list yourself and approve or
     correct it: it is the contract.
   - `fail`: if it already used two attempts, escalate once with `--tier B`. If tier B fails, read the log's
     last part, find what the packet lacked, and rewrite the packet.
   - `blocked`: answer the worker's question in a revised packet, or record the blocker and switch lane.
7. **Review** with the `dc-review` skill, to the depth the risk tier requires. Tier A: you read the tests and
   every changed writer. Dispatch the `review` packet first so its findings guide your reading.
8. **Records.** Merge the newest `origin/main` into the branch. The same record files conflict every time:
   resolve them by rule with `node orchestration/tools/resolve-records.mjs <worktree>`, regenerate the
   generated views, and run the plan and docs validators (`orchestration/ARCHITECTURE.md` section 9). Then
   dispatch the `records` packet. Ids are taken there, last.
9. **Pull request.** Push with `node orchestration/bin/orch.mjs push <branch>`, then `gh pr create --base main`
   with the body sections of the master plan's step S11: what the desktop does (cited), what changed, cases
   executed, passed, failed, blocked, the three coverage numbers, gate output, not verified and why, deliberate
   differences, open items. Name each worker tool and model used. Watch CI as a background command:
   `gh pr checks <n> --watch`.
   When a check is red, read the failing step first (`gh run view <run> --job <job> --log-failed`), and for a
   browser case the screenshot in the run's artifact. Re-run a job at most once, and only after reading it.
10. **Hand over.** Tell the owner the pull request is ready and what you did and did not verify. If, and only
    if, the owner has delegated merging for this pull request, arm the watcher as a background command:
    `bash orchestration/tools/merge-when-green.sh <pr> <worktree>`. It merges only when every check passed, the
    head is the commit that was checked and the branch contains the newest `main`. After the merge: set the
    package's State cell, remove the worktree, move the claim to done.

## Choosing who does a piece of work

| The work | Send it to |
|---|---|
| Reading a form, listing behaviours, writing tests, routine code, a screen, records | A tier-C packet |
| A design, a decomposition, a change across several writers, a second failed attempt | A `lead` or `fix` packet at tier B; tier A only when tier B failed or the design decides money or tenant scope |
| A second read of one diff, right now | The `dc-reviewer` subagent |
| "Where is X", "what does this log say" | The `dc-scout` subagent |
| A whole lane that needs judgment for hours | Ask the owner to open a second Claude Code session with the `dc-lead` skill |

## Your own budget

- Before opening a file, ask whether a packet's worker, a subagent or a script can answer instead.
- Prefer `git diff --stat` and the test diff over the full diff; open application code by hunk.
- When a session has been long, write the handoff (below) and let a fresh session continue.

## Stop and ask the owner

A decision the plans do not record; anything that needs real customer data; lifting a containment rule; a
provider that has not been authorised to receive source; production deployment; a package that failed three
packets in a row; any sign that a locked rule (no push to `main`, no weakened test) is the only way forward.

## End of a session

1. `node orchestration/bin/orch.mjs status`: every work branch with commits is pushed, or you say which is not.
2. The claims table is true.
3. Two dated lines in `project-memory/HANDOFF.md` on the branch of each package you advanced.
4. Your last message says, per package: stage reached, last verdict, next packet to run.
