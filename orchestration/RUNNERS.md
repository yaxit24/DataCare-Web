# Worker tools, providers and plans

Which tools can run a worker session, which providers and subscriptions can serve the models, and how to choose.
The choice of the cheap provider is **not final**; this file is the catalog the decision is made from, and
`config/routing.json` is the one place the decision is written.

See what is installed, keyed and ready on a machine at any time:

```bash
node orchestration/bin/orch.mjs providers
```

## 1. Two separate choices

A worker session is a **tool** (the program that runs the agent loop and edits files) talking to a **provider**
(who serves the model). They vary independently:

| Tool | Providers it can use |
|---|---|
| `claude` (Claude Code, headless) | The Claude subscription; any Anthropic-compatible endpoint |
| `opencode` (OpenCode, headless) | OpenCode Go, DeepSeek, OpenRouter, OpenAI, and any OpenAI-compatible endpoint |
| `codex` (Codex CLI, headless) | A ChatGPT plan or an OpenAI API key |

A routing candidate names both: `{ "runner": "opencode", "provider": "deepseek", "model": "<id>" }`.

## 2. Tools

Flags below were read from each tool's own `--help` on 16 November 2026 (Claude Code 2.1.325, OpenCode 2.3.0,
Codex CLI 0.169.0). The dispatcher's command lines are in `config/runners.json`.

### claude

`claude -p --model <alias or id> --effort <low|medium|high|xhigh|max> --permission-mode acceptEdits
--output-format json --allowedTools ... --disallowedTools ...`, prompt on standard input.

- Model aliases: `opus`, `sonnet`, `haiku`, `fable`. This is how a Claude session's model is chosen per task.
- The worker definition denies `git push`, `git commit`, branch switching, `gh pr`, and web access.
- With a provider that has a `set` map, the dispatcher sets `ANTHROPIC_BASE_URL` and `ANTHROPIC_AUTH_TOKEN`
  only inside the worker's process, so the architect's own session keeps using the subscription.
- `--max-budget-usd <amount>` caps a session's spend when it runs on an API key.
- Verified here: started by the dispatcher for the pilot packet (see `work/README.md`).

### opencode

`opencode run --standalone --auto --agent dc-worker --format json --title <run> --model <provider/model> "<pointer>"`.

- `--auto` approves every permission that is not explicitly denied. The denials are in
  `.opencode/agents/dc-worker.md`.
- `--standalone` gives the session a private server, so keys passed in the environment reach it.
- Model ids are `provider/model`, optionally `#variant`. List them with `opencode models`; connect accounts with
  `opencode auth login <provider>`; see spend with `opencode stats --cost`.
- OpenCode reads `AGENTS.md` and skills in `.claude/skills/`, `.agents/skills/` and `.opencode/skills/`. The
  dispatcher does not rely on that: the prompt carries what the session needs.
- Not verified here: no provider is connected, so no packet has run through it.

### codex

`codex exec --sandbox workspace-write --json [-m <model>] -C <worktree> -o <file> -`, prompt on standard input.

- The default sandbox is read-only; `workspace-write` allows edits inside the worktree.
- `codex exec review` runs a code review of the repository; the `review` role uses the ordinary `exec` with the
  role contract instead, so every reviewer follows the same rubric.
- Sign in once with `codex login` (ChatGPT plan) or put `CODEX_API_KEY` in `state/providers.env`.
- Not verified here: not signed in.

### Others that would fit the same contract

Qwen Code, Gemini CLI, Kiro CLI (the tool the repository's earlier process used), Cursor CLI, GitHub Copilot CLI.
Any tool that can run headless in a directory and take a prompt from standard input or an argument can be added
in `config/runners.json` ([ARCHITECTURE.md](ARCHITECTURE.md) section 6). None has been evaluated.

## 3. Providers and plans

The authoritative list, with key names, prices read on the stated date and terms, is `config/providers.json`.
Summary:

| Provider or plan | Kind | Scripted use | Role here |
|---|---|---|---|
| Claude subscription | Subscription | Yes | Tiers A and B. The scarce one |
| OpenCode Go | Subscription, 10 USD per month (Plus 40) | Not confirmed: read the terms | Candidate for tier C |
| DeepSeek API | Pay as you go | Yes | Candidate for tier C |
| OpenRouter | Gateway, pay as you go | Yes | Candidate for any tier; best for the bake-off because one key reaches many models |
| An Anthropic-compatible endpoint | Gateway | Depends on the plan behind it | Tier C through the `claude` tool |
| Alibaba Cloud Coding Plan | Subscription, Pro 50 USD per month | **No**: its terms prohibit automated and non-interactive use | Interactive sessions only; never in `routing.json` |
| Codex with a ChatGPT plan or API key | Subscription or pay as you go | Yes | Tier B cross-review |

Not yet evaluated: OpenCode Zen, the Z.AI GLM plan, the Kimi and MiniMax plans, Alibaba Model Studio
pay-as-you-go and Token Plan.

**Before any provider receives source code** the owner authorises it (`SECURITY-NOTICE.md`, control 5) and its
data-retention terms are read. Record the date in the provider's `checked` field.

## 4. Connecting a provider

1. Put its key in `<root>/state/providers.env` as `NAME=value` (names are in `config/providers.json`; the file is
   outside the repository and is never printed). For OpenCode Go, connect inside OpenCode instead:
   `opencode auth login`.
2. Find the model id: `opencode models` for OpenCode providers.
3. Set the `model` of that candidate in `config/routing.json` and move it to the top of its tier.
4. `node orchestration/bin/orch.mjs providers` must show it `READY`.
5. `node orchestration/bin/orch.mjs run orchestration/packets/WP-18.study.md --dry-run` shows the exact command.
6. Run one study packet for real before trusting it with code.

## 5. Choosing the tier-C provider: the bake-off

Run the same three packets (a study, a `tests` packet, an `implement` packet) twice on each candidate with
`--runner <tool> --model <id>`, and compare the ledger rows: verdict, attempts, minutes, citation errors. Add the
cost from each provider's own usage page. Choose the cheapest candidate with at least five passes in six. Repeat
when a provider changes its models or prices; the ledger makes the comparison cheap.

Expect differences by role: a model that is good at reading and citing (study, cases) is not always the one that
is good at writing code to a test (implement). `routing.json` can give a role its own tier, and a tier can have a
different first candidate per machine if needed.

## 6. Claude sessions on a chosen model

For work that needs a strong model, the architect has three ways to start another Claude session:

| Way | Start | Model chosen by | Use for |
|---|---|---|---|
| Subagent inside the architect session | The Agent tool with `dc-reviewer` or `dc-scout` | The agent file (`sonnet`, `haiku`) or the call | A second read of a diff, a lookup, a summary of a long log |
| Headless through the dispatcher | `orch run <packet> --tier A` or `--tier B` | `routing.json` | Lead packets: design, decomposition, hard fixes, cross-review, with guards and a ledger entry |
| Interactive lane lead | A second terminal: `claude --model sonnet` in the package's worktree, then the `dc-lead` skill | The person or session that starts it | A whole lane that needs continuous judgment |

## 7. herdr (optional)

herdr is a terminal workspace that shows each agent pane as working, blocked or idle and can be scripted. It is
useful when several interactive sessions run at once (lane leads, an Alibaba-plan session). The dispatcher does
not depend on it. Install it from its own instructions (`https://herdr.dev`); on Windows it is in beta. Useful
commands: `herdr workspace create --cwd <worktree> --label <lane>`, `herdr pane run <pane> "<command>"`,
`herdr agent wait <pane> --until blocked`.
