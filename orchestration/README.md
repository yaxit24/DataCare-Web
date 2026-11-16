# Orchestration: a team of AI sessions for DataCare-Web

One strong session plans and checks. Cheap sessions read, write and test. A script with no model in it starts
them, fences them in and measures what they did.

| Read | For |
|---|---|
| [PLAN.md](PLAN.md) | The whole plan: levels, pipeline, quality ladder, routing, rollout, decisions |
| [ARCHITECTURE.md](ARCHITECTURE.md) | The parts, the files, one run step by step, how to extend it |
| [QUALITY.md](QUALITY.md) | Risk tiers, every check, the architect's review, the parity checklist |
| [PACKETS.md](PACKETS.md) | How to write and run a work packet |
| [RUNNERS.md](RUNNERS.md) | Worker tools, providers and plans, and how to choose |
| [SETUP.md](SETUP.md) | Set up a machine; move to another laptop |
| [`roles/`](roles/) | What each kind of worker session is told |
| [`work/`](work/README.md) | What workers produced, per work package |

What to build and in which order is not here: it is
[`docs/parity/LITE-MASTER-PLAN.md`](../docs/parity/LITE-MASTER-PLAN.md).

## Five commands

```bash
node orchestration/setup/bootstrap.mjs --install          # once per machine
node orchestration/bin/orch.mjs doctor                    # is this machine ready
node orchestration/bin/orch.mjs providers                 # which tools, plans and models are ready per tier
node orchestration/bin/orch.mjs run <packet.md> --dry-run # what would be sent, to whom
node orchestration/bin/orch.mjs run <packet.md> --commit  # run one worker session and check it
```

## Who does what

- **Architect** (Claude Code on the strongest model): open Claude Code in the base clone and run `/dc-architect`.
- **Lead** (Claude on a chosen model): a `lead` packet through the dispatcher, the `dc-reviewer` subagent, or a
  second interactive session with `/dc-lead`.
- **Worker** (any tool, cheap model): never started by hand; the dispatcher starts it from a packet.

## The rules in six lines

1. The desktop source decides business behaviour; every claim about it carries a quote a script checks.
2. Tests are written before the code by one session and locked for the session that implements.
3. A worker changes only the paths its packet allows, and never commits or pushes.
4. A model's claim is not evidence; a guard, a gate, a second reader or CI is.
5. Money, stock, tenant scope and sign-in are reviewed by the architect, always.
6. Model and vendor names appear only in `config/routing.json` and `config/providers.json`.
