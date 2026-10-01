---
name: datacare-docs-update
description: Keep the DataCare documentation hub current — update menu-catalog rows when a screen's web state changes, classify new Markdown files in the document register, keep handbook facts and citations right, regenerate the generated views and pass docs_check.py. Use after any change that alters what a menu, module or document says.
---

# Documentation update

Change: `$ARGUMENTS`.

Hub: `docs/README.md`. Rules: "Rules for documentation" in that file.

## 1. Menu catalog

For every desktop menu whose web state changed, edit its row in `docs/handbook/menu-catalog.jsonl` (one JSON object
per line):

| Field | Meaning |
|---|---|
| `forms`, `mode`, `dispatch` | Desktop forms, how the menu opens them, and the `MDI_FORM.cs` line range |
| `purpose`, `looks`, `tables` | What it does, how the desktop screen looks, the tables it writes (reads, for reports) |
| `ui`, `api` | Web page routes and declared API routes (`METHOD /path`, exactly as declared) |
| `can` | Six characters `CREDPL` or `-`: create, reopen, edit, delete, print, list |
| `status` | `FULL`, `PARTIAL`, `REPORT`, `CONTAINED` or `MISSING` (engineering grade, not acceptance) |
| `gaps`, `owners` | What remains and the plan IDs that own it |
| `phase`, `sources`, `fix` | `P1-core`, `P1-edition`, `P2` or `defer`; evidence paths; optional register correction |

Then regenerate and check:

```bash
python3 docs/tools/docs_check.py --write
```

The check fails when a form has no source file, a dispatch range does not name the form, a page or API route does not
exist, an owner ID is unknown, or a source line range is out of bounds.

## 2. New Markdown file

- Add or extend a rule in `docs/handbook/doc-register.json` (`match` glob or list, `area`, `kind`, `status`,
  `successor`, `purpose`). Statuses: current, generated, reference, historical, superseded, evidence. The first
  matching rule wins, so put specific rules before broad ones.
- Never move, rename or rewrite a historical file. To redirect readers, add a one-line banner at the top pointing to
  the successor.

## 3. Handbook facts

- `docs/handbook/web/modules.md` must list every directory in `web/apps/api/src/modules/` (checked).
- Counts in prose carry a date or come from a checked source; prefer linking to the backlog or catalog.
- Cite files from the repository root in backticks, with line ranges where they matter; the check verifies the
  file exists and the range fits. For a file a planned slice will create, add `<!-- planned: path -->`.

## 4. Safety

- No credentials, connection strings, tokens or customer data; environment variables by key name only. The check
  scans the hub, handbooks, plan documents 12–14, ADR-0004, skills and `AGENTS.md`.
- Screenshots and query results with personal data never go into the repository.

## 5. Validate

```bash
python3 docs/tools/docs_check.py
python3 docs/master-parity-plan-2026-09-29/validate_plan.py
(cd web && pnpm docs:refs)
```
