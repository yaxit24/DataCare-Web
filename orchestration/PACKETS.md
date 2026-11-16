# Work packets

A packet is one Markdown file that tells one session exactly what to do. The dispatcher reads its header; the
worker reads its brief. Packets live in `orchestration/packets/` and are named `<WP>.<stage>.md`, for example
`WP-18.study.md`. Copy [`packets/_template.md`](packets/_template.md) to start one, and validate it with
`node orchestration/bin/orch.mjs check <file>`.

## 1. Header

The first fenced `json` block in the file.

| Field | Required | Meaning |
|---|---|---|
| `id` | yes | Unique, equal to the file name without `.md` |
| `wp` | no | The work package in the master plan, for example `WP-18` |
| `title` | yes | One line: the outcome, not the activity |
| `role` | yes | One of the roles in `config/routing.json`: `study`, `cases`, `tests`, `implement`, `ui`, `verify`, `records`, `review`, `fix`, `lead` |
| `tier` | no | `A`, `B` or `C`. Default: the role's tier |
| `risk` | no | The package's risk tier (see QUALITY.md section 1). Decides review depth |
| `branch` | yes | The work branch, like `agent/wp18-huid-report`. All packets of one package share it |
| `base` | no | Where a new branch starts. Default `origin/main` |
| `dependsOn` | no | Packet ids that must have passed first |
| `allow` | yes, except for `review` | Globs of paths the session may create or change |
| `deny` | no | Globs it may not change, in addition to the role's and the always-locked paths |
| `denyDefaults` | no | `false` lifts the role's default locks (use only when the packet explains why) |
| `outputs` | no | Files that must exist when the session stops |
| `context` | no | Files to read first, as `path` or `path:start-end`. A desktop form listed here gets a form index |
| `inline` | no | `path:start-end` excerpts pasted into the prompt with line numbers. Keep under about 300 lines in total |
| `skills` | no | Names of project skills under `.kiro/skills/` to paste into the prompt |
| `gates` | no | Checks after the session, in order (below) |
| `limits` | no | `minutes`, `maxChangedFiles`, `maxDiffLines`. Defaults come from the role |
| `commit` | no | The commit subject when run with `--commit`. Default `<wp>: <title>` |
| `allowTestDeletion` | no | `true` when the packet really asks for a test file to be removed |

**Gates**

```json
{ "type": "cite", "file": "orchestration/work/WP-18/study.md", "requireSnippets": true, "min": 25 }
{ "type": "cmd", "cwd": "web", "run": "pnpm lint && pnpm typecheck", "timeoutMin": 20 }
{ "type": "cmd", "cwd": ".", "run": "{python} docs/tools/docs_check.py" }
{ "type": "cmd", "cwd": "web", "run": "node scripts/parity-test-env.mjs -- pnpm --filter @datacare/api exec vitest run test/huidReport.db.test.ts", "env": { "PARITY_TEST_PORT": "55502" }, "timeoutMin": 30 }
{ "type": "node-test", "path": "scripts/some.test.mjs" }
```

Gates stop at the first failure unless a gate sets `"stopOnFail": false`. Environment variables go in `env`, not
in front of the command, so the same packet runs on Windows, macOS and Linux.

**Gates for a packet that changes code.** At least `pnpm typecheck`, and on Linux, macOS or WSL also
`pnpm size:budget` and `pnpm lint`. On native Windows those two and `check-kernel-conformance.mjs` misreport
(section 5 of SETUP.md), so there CI is the gate. Because of that, state the size rule in the brief itself: a
source file may not pass 1,500 lines, and a file that is already near its ceiling gets new code in a new file.
Give the line count of each file the packet will touch (`wc -l`) under "Facts you need".

**When the machine cannot run the database or the browser** (no Docker), a `tests`, `implement` or `fix` session
can only type-check what it wrote. It reports `PARTIAL` and lists the tests it could not run; the dispatcher's
verdict is then `fail` and nothing is committed. The supervisor reads the diff, commits with `--no-worker
--commit`, pushes, and lets CI run the tests: on a draft pull request for a work package, the tests-only push
must show the new tests failing and the implementation push must turn them green.

## 2. Brief

Everything after the header. Required sections: `## Goal` and `## Done when`. Recommended: `## What to cover` or
`## Steps`, `## Out of scope`, and `## Facts you need` for anything the worker would otherwise have to find.

The brief is written for a model that knows nothing about the project and will not ask questions:

- **Name files and line ranges.** "The scheme tender is at `TR_SALE_ORD.cs:11264-11290`" beats "find the scheme
  tender code".
- **Name the example to copy.** "Structure it like `web/apps/api/test/stockAdjust.routes.db.test.ts`."
- **State the expected output shape.** Sections of a document, names of tests, the route path.
- **State what not to do.** The nearest wrong turn, in one line each.
- **Write "Done when" as checks.** Each line is something a script or a reader can verify in a minute.
- **One role, one output.** If the brief says "and then also", make a second packet.

## 3. Sizing

| Role | A good packet | Split when |
|---|---|---|
| study | One form, or one branch of a shared form, up to about 6,000 source lines in scope | The form is larger: one packet per mode or per branch, each writing its own section file |
| cases | One menu | Never; it must see the whole menu |
| tests | One layer for one menu (unit, or database, or browser) | More than about 25 cases in the layer |
| implement | About 400 changed lines, one module | It touches two writers, or needs a migration and a writer |
| ui | One screen | The screen has a grid and a print: print is its own packet |
| fix | One failure or one review finding group | Findings have different causes |
| records | One merged change | Never |
| review | One pull request or one packet's diff | The diff is over about 1,500 lines: review per module |

## 4. The usual chain for one work package

```
WP-nn.study      role study      -> work/WP-nn/study.md
WP-nn.cases      role cases      -> work/WP-nn/cases.md         dependsOn: study     (architect approves)
WP-nn.tests-db   role tests      -> api tests + red.md           dependsOn: cases
WP-nn.tests-ui   role tests      -> browser module + red.md      dependsOn: cases
WP-nn.api        role implement  -> api module, route            dependsOn: tests-db
WP-nn.screen     role ui         -> page                         dependsOn: api, tests-ui
WP-nn.verify     role verify     -> work/WP-nn/verify.md         dependsOn: screen
WP-nn.review     role review     -> findings                     dependsOn: verify
WP-nn.records    role records    -> catalog, backlog, views      dependsOn: review
```

`dependsOn` is checked against the ledger of the machine that runs the packet. When the earlier stages ran on
another machine and their output is already on the branch, run with `--force`.

## 5. Running

```bash
node orchestration/bin/orch.mjs check  orchestration/packets/WP-18.study.md
node orchestration/bin/orch.mjs run    orchestration/packets/WP-18.study.md --dry-run   # show prompt size and command
node orchestration/bin/orch.mjs run    orchestration/packets/WP-18.study.md --commit    # run it
node orchestration/bin/orch.mjs run    orchestration/packets/WP-18.study.md --attempts 2 --commit
node orchestration/bin/orch.mjs run    orchestration/packets/WP-18.study.md --tier B --commit   # escalate
node orchestration/bin/orch.mjs run    orchestration/packets/WP-18.study.md --no-worker  # re-check after a hand fix
node orchestration/bin/orch.mjs push   orchestration/packets/WP-18.study.md             # push the branch
```

The summary printed at the end is also at `<root>/state/runs/<run>/summary.md`, next to the worker's report.
