# Work products of dispatched sessions

One folder per work package: `orchestration/work/<WP>/`. A folder is created on the package's branch and reaches
`main` with the package's pull request. It holds what later sessions and reviewers need, and nothing else:

| File | Written by | Read by |
|---|---|---|
| `study.md` | `study` | `cases`, `tests`, `implement`, `ui`, `review`, the architect (the Gaps section) |
| `cases.md` | `cases`, approved by the architect | `tests`, `verify`, `review` |
| `red.md` | `tests` | `implement`, the architect |
| `verify.md` | `verify` | `review`, `records`, the architect, the pull request body |
| `design.md` | `lead`, when the package has one | The packets the lead wrote |

These documents are evidence of what was known and checked when the package was built. They are not the
authority for status (the backlog and the menu catalog are) or for behaviour (the desktop source is). After a
package merges they are not kept current.

Scratch files of a session (its prompt, form indexes, its report) are in the worktree's `.orch` folder, which git
ignores. Run records are under `<root>/state/` on the machine that ran them.

## Pilot record

The first real run of the dispatcher, on 16 November 2026, so the plan's status section can point at a fact.

| Item | Value |
|---|---|
| Packet | `orchestration/packets/WP-18.study.md` (HuId Report, desktop form `RP_HUID.cs`, 2,731 lines) |
| Worker | The `claude` tool on Haiku, the tier-C fallback (no cheap provider was connected yet) |
| Context pack | About 3,900 tokens, plus the generated form index |
| Session | 12.3 minutes, 53 turns, one attempt; 0.83 USD at list price (it ran on the subscription) |
| Output | `orchestration/work/WP-18/study.md`, 415 lines, the twelve sections, 29 numbered gaps |
| Guards | Pass: one file changed, inside the allow list |
| Citation gate | Pass: 250 citations, 250 verified by their quoted source text |
| Verdict | `pass` |

What the study found that the existing records did not say: the desktop form has three views (Stock, In, Out),
not the four the catalog names; the web report applies no date window and no financial year; the web's "with
HUID" test reads four columns where the desktop reads one; and the desktop's stock filter sums movement serial
numbers, which looks like a defect. The worker stopped with four questions for the supervisor instead of deciding
them, which is the behaviour the role contract asks for.

What the pilot showed about the layer itself:

- The worker wrote its own citation checker, because the package's worktree (created from `main`) did not yet
  contain `orchestration/`. Once this layer is on `main`, a worker can run
  `node orchestration/bin/orch.mjs cite <file>` itself before stopping.
- Many quotes are the first characters of one very long query-building line. They prove the location, as
  intended, but say little; the study role now asks for the distinguishing part of the line.
- The study stays on its own branch (`agent/wp18-huid-report`), committed locally and not pushed: it becomes part
  of WP-18's pull request when that package is taken.

Not yet exercised by a real model: the `tests`, `implement`, `ui`, `verify`, `records` and `review` roles, the
OpenCode and Codex tools, and any gate that needs Docker.
