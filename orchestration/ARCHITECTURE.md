# Orchestration architecture

How the parts fit, what each file is, and how to extend it. The reasons are in [PLAN.md](PLAN.md).

## 1. The parts

```
                         owner (decisions, merge, UAT)
                                   |
                 +-----------------v------------------+
                 |  ARCHITECT  one Claude Code session |   reads: summaries, reports, chosen diffs
                 |  skills: dc-architect, dc-packet,   |   writes: packets, claims, pull requests
                 |          dc-review                  |
                 +---+-------------+---------------+---+
                     |             |               |
        in-session   |   orch run  |  --tier A/B   |  orch run (tier C)
        subagents    |   (headless Claude leads)   |
   dc-reviewer (Sonnet)            |               |
   dc-scout   (Haiku)              v               v
                 +-----------------------------------------+
                 |  DISPATCHER  orchestration/bin/orch.mjs |   no model inside
                 |  worktree -> context pack -> session -> |
                 |  guards -> gates -> result -> ledger    |
                 +----+-----------+-----------+------------+
                      |           |           |
                   claude      opencode     codex            worker tools (config/runners.json)
                      |           |           |
              Anthropic or   OpenCode Go,   ChatGPT plan     providers (config/providers.json)
              compatible     DeepSeek,      or API key
              endpoint       OpenRouter ...
                      |           |           |
                      v           v           v
              one git worktree per work-package branch:  <root>/wt/<branch>
                      |
                      v
              GitHub: branch -> pull request -> CI (full suites) -> merge by the owner
```

The architect never talks to a worker. It writes a packet, the dispatcher runs it, and the architect reads the
result. A lead is a worker on a stronger model with a harder packet; it is launched the same way.

## 2. What lives where

**In the repository** (identical on every machine):

| Path | Content |
|---|---|
| `orchestration/PLAN.md` and the other top-level documents | This plan and its companions |
| `orchestration/bin/orch.mjs`, `orchestration/lib/` | The dispatcher. Node 20 or newer, no dependencies |
| `orchestration/test/` | Its tests: `node --test orchestration/test/orch.test.mjs` |
| `orchestration/config/routing.json` | Tiers A, B, C: which tool and model serve each; role defaults (tier, locked paths, limits) |
| `orchestration/config/runners.json` | Worker tools: the command line for a headless session of each |
| `orchestration/config/providers.json` | Catalog of providers and plans: key names, terms, whether scripted use is allowed |
| `orchestration/roles/` | Role contracts: the instructions every session of that role receives |
| `orchestration/packets/` | Work packets, one file per session to run |
| `orchestration/work/<WP>/` | What workers produced that later sessions need: study, cases, red list, verification |
| `orchestration/setup/` | Machine bootstrap scripts |
| `orchestration/tools/` | Two helpers for the merge queue (section 10): the rule-based resolver for record-file conflicts and the merge watcher |
| `.claude/skills/`, `.claude/agents/`, `CLAUDE.md` | The architect's and lead's skills, the two subagents, the entry file Claude Code reads |
| `.opencode/agents/dc-worker.md` | Permission rules for OpenCode worker sessions |
| `AGENTS.md` | The project rules every tool reads, with a section for dispatched workers |

**On each machine, outside the repository** (`<root>` is the folder that holds the base clone):

| Path | Content |
|---|---|
| `<root>/DataCare-Web` | The base clone, on `main`, never edited. LFS downloads skipped |
| `<root>/wt/<branch>` | One worktree per work-package branch |
| `<root>/wt/<branch>/.orch/` | Scratch for the session: `prompt.md`, `index/<FORM>.md`, `report.md`. Ignored by git |
| `<root>/state/runs/<run>/` | Per run: the prompts, the worker log, gate logs, `result.json`, `summary.md`, `report.md` |
| `<root>/state/ledger.jsonl` | One line per run: packet, role, tier, worker, minutes, verdict |
| `<root>/state/providers.env` | Provider keys as `NAME=value` lines |

`DATACARE_WT_ROOT` and `DATACARE_STATE_ROOT` move the last two groups. Nothing else is configured per machine.

## 3. One run, step by step

`node orchestration/bin/orch.mjs run orchestration/packets/<file>.md`

1. **Parse and validate the packet.** A missing role, a branch named `main`, an empty allow list or a brief
   without "Goal" and "Done when" stops here.
2. **Check dependencies.** Each id in `dependsOn` must have a passing run in this machine's ledger (`--force`
   skips this when the earlier work is already on the branch from another machine).
3. **Worktree.** `<root>/wt/<branch>` is reused, or created from the remote branch, or from the packet's base
   (`origin/main` by default). The commit it stands on is recorded as the start point.
4. **Form indexes.** For each desktop form in the packet's context, `.orch/index/<FORM>.md` is generated.
5. **Context pack.** `.orch/prompt.md` is assembled: rules for every worker, the role contract, the brief, the
   enforced scope, the reading list, inlined excerpts with line numbers, the named project skills, the report
   layout. On a retry, the failed checks of the previous attempt are placed at the top.
6. **Pick the worker.** The packet's tier (or the role's default, or `--tier`) selects a list of candidates in
   `routing.json`. The first whose tool is installed, whose keys are present and whose model is set is used.
7. **Session.** The tool is started headless in the worktree with the prompt on standard input or, for tools
   that take a message argument, a one-line pointer to the prompt file. Output goes to the run's log. The session
   is killed at the packet's time limit.
8. **Guards.** Everything that differs from the start point (commits, edits, new files) is compared with the
   scope: the allow list, the role's locked paths, the always-locked paths, the size limits, the content rules,
   the required outputs.
9. **Gates.** Only if the guards pass: citation checks and the packet's commands, each with a time limit and its
   own log.
10. **Verdict.** `pass` needs: guards and gates pass, the session exited normally, and its report starts with
    `STATUS: DONE`. `blocked` is a clean run whose report says `STATUS: BLOCKED`. Everything else is `fail`.
11. **Record.** `result.json`, `summary.md` and a ledger line are written. With `--commit` and a pass, the changed
    files are staged by name and committed with the packet id, the worker and the run id in the message.

Exit codes: 0 pass, 2 fail, 3 blocked, 1 the dispatcher itself could not run.

## 4. Scope enforcement

A changed file is accepted only if it matches the packet's `allow` globs and none of the deny lists:

- **Always locked** (`lib/packet.mjs`): `unified/**` and the other desktop provenance trees, `.github/**`,
  `.claude/**`, `.opencode/**`, `.kiro/**`, `AGENTS.md`, `CLAUDE.md`, the dispatcher's own code, configuration,
  roles, setup and tests, and every `.env` file.
- **Locked per role** (`config/routing.json`): the test directories for `implement` and `ui`; the API for `ui`;
  application source for `records`; `orchestration/work/**` for `implement`, `ui` and `fix`, so the contract
  cannot be rewritten by the session it measures.
- **Locked per packet**: the packet's own `deny` list.

A `review` session is read-only: any change outside `.orch/` fails it.

Globs: `*` stays inside one path segment, `**` crosses segments, `?` is one character.

The tool-level permission rules (the disallowed commands in `runners.json`, the rules in
`.opencode/agents/dc-worker.md`) stop a session early. The guards are what is relied on, because they do not
depend on the tool.

## 5. Citations

`FORM.cs:123 {{quoted source text}}` or `FORM.cs:120-128 {{...}}`. The file is resolved under
`unified/src/csharp/DataCareNext/`. The check fails when the file is missing, the range is outside the file, or
the quote (whitespace collapsed) does not occur within two lines of the cited range. With `requireSnippets` every
citation must carry a quote, and `min` sets a minimum count. Run by hand:
`node orchestration/bin/orch.mjs cite <file> --require-snippets`.

## 6. Adding or changing a worker tool

Add an entry to `config/runners.json`:

```json
"mytool": {
  "name": "My tool, headless",
  "bin": "mytool",
  "install": "how to install it",
  "prompt": "stdin",
  "args": ["run", ["--model", "{model}"], "--cwd", "{worktree}"]
}
```

- `prompt` is `stdin` (the whole prompt is piped in) or `pointer` (the placeholder `{pointer}` in `args` becomes
  one sentence telling the session to read `.orch/prompt.md`).
- Placeholders: `{model}`, `{effort}`, `{worktree}`, `{runId}`, `{pointer}`, `{lastMessage}`, plus any field of
  the candidate or of the tool's `defaults`. A nested array is dropped when one of its placeholders is empty.
- `modelRequired: false` lets the tool run on its own default model.

Then list it as a candidate in `routing.json`. `node orchestration/bin/orch.mjs providers` shows whether it is
ready, and `run <packet> --dry-run` prints the exact command without starting anything.

## 7. Adding a provider

Add an entry to `config/providers.json` with the key names it needs (`env`), and, when a tool reads different
variable names, a `set` map from the tool's variable to a template over the key names. Put the values in
`<root>/state/providers.env`. Name the provider in the candidate: `{ "runner": "opencode", "provider": "deepseek",
"model": "<provider/model id>" }`. Record `automation`, `checked` and the terms you read: only entries whose
terms allow scripted use belong in `routing.json`.

## 8. Adding a role

Write `roles/<name>.md` (what it reads, what it produces, its method, its own rules), add it to `roles` in
`routing.json` with a tier and any locked paths, and add a row to [PLAN.md](PLAN.md) section 4 if it is a stage of
the pipeline. `common.md` and `report.md` are included for every role and are not roles themselves.

## 9. The merge queue: two helpers

Every pull request that carries plan ids edits the same record files, so after `git merge origin/main` the same
five files conflict each time: the backlog JSON, document 12, the claims file, the master plan's state table and
the handoff. Both helpers contain no model.

**`node orchestration/tools/resolve-records.mjs <worktree>`** resolves those conflicts by rule and stops, leaving
the file conflicted, on anything the rules cannot decide:

- the backlog: a three-way merge of the parsed JSON, where arrays of objects with an `id` merge by id;
- Markdown tables: rows are keyed by their first cell, and a row changed on one side only takes that side;
- `project-memory/HANDOFF.md`: both sides' new sections are kept, the branch's first.

After it, regenerate and check, exactly as the master plan's step S9 says:
`python3 docs/tools/docs_check.py --write`, `pnpm progress` (from `web/`), `python3 docs/parity/build_matrix.py`,
then `validate_plan.py`, `docs_check.py` and `pnpm progress:check`. Stage the files by name and commit the merge.

**`bash orchestration/tools/merge-when-green.sh <pr> <worktree>`** waits for the pull request's checks and
squash-merges it only if all of these hold: every check passed; the pull request is open and mergeable; its
remote head is the commit that was checked; the branch contains the newest `origin/main`. Otherwise it prints
why and merges nothing. Use it only when the owner has delegated merging for that pull request. It is a
background process: stopping the supervising session does not always stop it, so when work is paused, check that
no `merge-when-green` process is left.

A red check is read from the run itself before anything is re-run: `gh run view <run> --job <job> --log-failed`
for the failing step, and for a browser case the run's artifact (`gh api repos/<owner>/<repo>/actions/artifacts/<id>/zip`),
whose `01-*.png` shows what the screen held.

## 10. Limits of the design

- The dispatcher runs one packet per invocation. Parallelism is several invocations, each on a different branch;
  two packets on the same branch must not run at once.
- The ledger and run records are per machine. What must travel is committed (`orchestration/work/`) or quoted in
  the pull request.
- The guards see file changes, not intent. A change that stays in scope, passes weak tests and is wrong is caught
  only by review and by the case list being good. That is why the case list is approved by the architect.
- Gate commands run through bash where it exists (Git for Windows on Windows), so the repository's runbook
  commands work unchanged. `{python}` in a command is replaced by the machine's Python 3.
