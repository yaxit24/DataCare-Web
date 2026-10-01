> **1 October 2026.** The documentation entry point is now [`docs/README.md`](../docs/README.md) and work status lives
> in the plan backlogs (`docs/master-parity-plan-2026-09-29/execution-backlog.json`). This file still defines the
> continuity protocol for `HANDOFF.md`, `JOURNAL.md` and `state.json`.

# Project Memory & Continuity Store

This directory is the **single source of truth for project progress** across sessions.
It exists because the build spans many sessions and the LLM context window is limited.
Any agent (or human) starting a new session MUST read this before doing anything.

## Files

| File | Purpose |
|---|---|
| `state.json` | Machine-readable 34-task graph + status. The backlog. |
| `HANDOFF.md` | "START HERE next session" — current state, exact next action, how to verify. |
| `JOURNAL.md` | Append-only log: per session/task what changed, why, blockers. |
| `CHANGELOG.md` | Demoable increments per phase. |
| `decisions/ADR-*.md` | Architecture Decision Records (locked decisions + deferred levers). |
| `catalogs/` | Phase-0 outputs: `data-model.json`, per-form behavioral specs, completeness manifest. |
| `parity/` | Latest Tier-4 parity results per module (`latest.json`). |

## Continuity protocol (every session)

1. **Load**: read `state.json` + `HANDOFF.md`.
2. **Verify against reality** before trusting memory:
   - `git -C <repo> log --oneline -10` (or inspect file mtimes if not a git repo yet)
   - check that artifacts listed as `done` actually exist on disk
   - re-run the relevant test/scan command named in `HANDOFF.md`
3. **Reconcile** any drift (update `state.json` to match reality).
4. **Resume** the exact next action named in `HANDOFF.md`.
5. **Checkpoint** after every task AND before any context compaction:
   - update `state.json` (status, testStatus, parityStatus, timestamps, notes)
   - append a `JOURNAL.md` entry
   - refresh `HANDOFF.md` "next action"
   - (when KB available) re-index `project-memory/` + `unified/` catalogs

## Status vocabulary

- task `status`: `todo` | `in_progress` | `blocked` | `done`
- `testStatus.tierN`: `n/a` | `pending` | `pass` | `fail`
- `parityStatus`: `n/a` | `pending` | `pass` | `fail`

## Definition of Done (gate to mark a task `done`)

code + Tier 1–3 green + Tier-4 parity green (where applicable) + reviewer/security approved
+ docs/ADRs updated + this project-memory updated (+ KB re-indexed when available).
