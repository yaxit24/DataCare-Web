# Machine setup, and moving to another laptop

Everything the team of sessions needs is in git except three things that are per machine: the installed tools,
the provider keys, and the run records. This file sets up a machine from nothing and says what to carry when you
move.

## 1. The layout

Pick a folder on a drive with at least 30 GB free. Everything goes under it:

```
<root>/
  DataCare-Web/     the base clone: stays on main, is never edited, LFS binaries not downloaded
  wt/               one git worktree per work-package branch (created by the dispatcher)
  state/            run records, the ledger, providers.env (keys)
```

On the first laptop `<root>` is `D:\datacare`.

## 2. Prerequisites

| Tool | Version | Windows | macOS | Ubuntu or WSL |
|---|---|---|---|---|
| Git and Git LFS | current | `winget install -e --id Git.Git` then `git lfs install` | `brew install git git-lfs` | `sudo apt install git git-lfs` |
| Node.js | 24 | `winget install -e --id OpenJS.NodeJS` | `brew install node@24` | nvm, `nvm install 24` |
| pnpm | 9.15.4 | `npm install --global pnpm@9.15.4` | same | same |
| GitHub CLI | current | `winget install -e --id GitHub.cli` | `brew install gh` | `sudo apt install gh` |
| Python | 3.12 | `winget install -e --id Python.Python.3.12 --scope user` | `brew install python@3.12` | preinstalled |
| Docker | current | Docker Desktop (needs WSL 2, section 5) | Docker Desktop | Docker Engine |
| Claude Code | current | `https://claude.com/claude-code` | same | same |

Sign in once: `gh auth login`, and start `claude` once to sign in to the subscription.

## 3. Clone and bootstrap

```bash
mkdir -p <root> && cd <root>
GIT_LFS_SKIP_SMUDGE=1 git -c core.autocrlf=false -c core.longpaths=true clone https://github.com/yaxit24/DataCare-Web.git DataCare-Web
cd DataCare-Web
node orchestration/setup/bootstrap.mjs --install
```

In PowerShell set the variable first: `$env:GIT_LFS_SKIP_SMUDGE = '1'`, then the `git clone` line.

The bootstrap script:

1. sets `core.autocrlf=false` (CRLF checkouts fail the format gate), `core.longpaths=true` on Windows, and makes
   Git LFS skip downloads in this clone;
2. creates `<root>/wt`, `<root>/state` and `<root>/state/providers.env` from the example;
3. with `--install`, installs pnpm, OpenCode and Codex through npm when they are missing;
4. runs `orch doctor` and `orch providers` and prints what is still to do by hand.

Set a commit identity for the clone if the script says none exists. Use your GitHub no-reply address so your
email is not published:

```bash
git config user.name "<login>"
git config user.email "<id>+<login>@users.noreply.github.com"
```

Then check the dispatcher itself:

```bash
node --test orchestration/test/orch.test.mjs      # 13 tests, no model and no network needed
node orchestration/bin/orch.mjs doctor
```

## 4. Worker tools and keys

1. Sign in to the tools you will use: `opencode auth login`, `codex login`.
2. Put provider keys in `<root>/state/providers.env` (key names: `orchestration/config/providers.example.env`).
3. Set the model ids in `orchestration/config/routing.json` ([RUNNERS.md](RUNNERS.md) section 4).
4. `node orchestration/bin/orch.mjs providers` shows what is ready for each tier.

Until a cheap provider is connected, tier C falls back to Claude Haiku, so the pipeline works from the first day.

## 5. Docker on Windows (administrator step)

Database and browser tests start PostgreSQL in Docker. Docker Desktop on Windows Home needs WSL 2:

1. In an **administrator** terminal: `wsl --install --no-distribution`. Restart Windows.
2. Start Docker Desktop. In Settings > Resources > Advanced set **Disk image location** to a drive with space
   (the system drive of the first laptop has about 11 GB free).
3. `docker info` must answer. `node orchestration/bin/orch.mjs doctor` then shows the engine as running.

Until this is done, sessions on this machine can do study, cases, implementation and reviews; tests that need the
database run only on GitHub CI.

The repository's gates were written and run on macOS and Linux. Measured on native Windows on 16 November 2026:

| Gate | Native Windows | Note |
|---|---|---|
| `pnpm install --frozen-lockfile` | Works (46 s, Prisma client generated) | |
| `python docs/tools/docs_check.py` | Works | With `--write` Python emits CRLF line endings: convert the regenerated files back to LF before committing. The dispatcher refuses a run that turns an LF file into CRLF |
| `python docs/master-parity-plan-2026-09-29/validate_plan.py` | Works only with `PYTHONUTF8=1` | The dispatcher sets it for every gate |
| `pnpm docs:refs` | **Fails** | The script runs POSIX shell snippets (`test $(ls ... | wc -l) -ge ...`) through the system shell, which is `cmd.exe` on Windows |
| Type checks, lint, database and browser tests | Not yet run here | The database and browser tests need Docker |

So a native Windows machine is sound for study, case lists, implementation, reviews and the Python gates, and
relies on GitHub CI for the rest. To run every gate locally on Windows, install an Ubuntu distribution in WSL 2
(`wsl --install -d Ubuntu`) and repeat sections 2 to 4 inside it, with `<root>` on the Linux file system; the
layout and every command stay the same.

## 6. Start working

Open Claude Code in the base clone (`<root>/DataCare-Web`). It reads `CLAUDE.md`. Then:

```
/dc-architect
```

loads the supervisor's procedure: read the claims, pick the next work package, write packets, dispatch, review.

Useful by hand:

```bash
node orchestration/bin/orch.mjs status --prs
node orchestration/bin/orch.mjs run orchestration/packets/<packet>.md --dry-run
node orchestration/bin/orch.mjs outline RP_HUID.cs --out /tmp/RP_HUID.index.md
```

## 7. Moving to another laptop

| What | Where it is | To move it |
|---|---|---|
| Plan, roles, skills, packets, configuration, dispatcher | git | Clone (section 3) |
| Work in progress | Work branches on GitHub | Push every branch first: `node orchestration/bin/orch.mjs push <branch>`; unpushed commits exist only in `<root>/wt` |
| Study notes, case lists, verification records | `orchestration/work/` on each branch | Travel with the branch |
| Claims and status | `docs/parity/AGENT-PROGRESS.md`, the backlog | git |
| Provider keys | `<root>/state/providers.env` | Copy the file by a private channel, or re-enter the keys |
| Tool sign-ins | Each tool's own store | Sign in again on the new machine |
| Run records and ledger | `<root>/state/` | Optional: copy the folder if you want the history for routing statistics |

Before leaving a machine: `git worktree list` in the base clone, and for each worktree `git status` and
`git log origin/<branch>..HEAD`. Anything listed there is not on GitHub yet.

On the new machine: sections 2 to 4, then `/dc-architect`. A packet whose earlier stages ran on the old machine
is run with `--force`, because the dependency check reads the local ledger.

The reference copy with the real binaries (the desktop executables, databases, Crystal templates) is a separate,
ordinary clone with `git lfs pull`. It is needed only for the desktop oracle and for reading `.rpt` files, not for
worker sessions.

## 8. Troubleshooting

| Symptom | Cause | Fix |
|---|---|---|
| `doctor` says Python is missing right after installing it | The terminal started before the install | Open a new terminal, or set `DATACARE_PYTHON` to the interpreter's path |
| `pnpm format:check` fails on every file | The clone converted line endings | `git config core.autocrlf false`, then `git rm --cached -r . && git reset --hard` in a clean worktree |
| A worktree shows 130-byte `.rpt` or `.exe` files | LFS downloads are skipped on purpose | Use the reference clone when you need the binary |
| `no ready worker for tier C` | No candidate has a model set and its keys | `orch providers` names what each candidate lacks |
| A worker session exits at once | The tool is not signed in, or the model id is wrong | Read `<root>/state/runs/<run>/worker-1.log` |
| `packet X has not passed on this machine` | The dependency ran elsewhere | `--force` |
| The dispatcher is killed when the terminal closes | It ran in the foreground | Start long runs as background commands |
