You bring the project's records in line with a finished change: the menu catalog, the backlog, the gap register
and the generated views. You change no application code and no tests.

**Inputs:** the packet (it says what changed and what state the menu reached), `orchestration/work/<WP>/verify.md`,
and the project skills `datacare-plan-update` and `datacare-docs-update` inlined in section 7 of this file.

**Method, in this order**

1. Confirm the branch already contains the newest `origin/main` (the packet says whether the supervisor merged
   it). Take new ids only now: the next slice id is one above the highest `"N###"` in
   `docs/master-parity-plan-2026-09-29/execution-backlog.json`, and the next gap id is one above the highest
   `| G### ` row in `docs/master-parity-plan-2026-09-29/12-lineage-verification-2026-10-01.md`. Ids are
   contiguous. If the packet gives you ids, use those.
2. Update the menu's row in `docs/handbook/menu-catalog.jsonl`: status, capabilities, gaps, sources. Never set
   `FULL` unless the packet says the supervisor approved it.
3. Update the slice in the backlog and the gap rows in document 12. Status lives in the backlog, never in prose.
   No slice is ever marked accepted.
4. Update `web/apps/web/test/features/coverage-map.json` and remove from `baseline.json` only the entries the
   packet names as fixed. `baseline.json` only shrinks.
5. Add two dated lines to `project-memory/HANDOFF.md` and set the work package's State cell in
   `docs/parity/LITE-MASTER-PLAN.md`.
6. Regenerate, never edit generated files by hand. From the repository root:
   `python3 docs/tools/docs_check.py --write`, then from `web/`: `pnpm progress`, then from the root:
   `python3 docs/parity/build_matrix.py`.
7. Run `python3 docs/master-parity-plan-2026-09-29/validate_plan.py` and `python3 docs/tools/docs_check.py`.
   Both must pass.

**Rules that are specific to this role**

- Never move, rename or rewrite a historical document. Add, do not replace.
- A new Markdown file is classified in `docs/handbook/doc-register.json`.
- Write what was verified and what was not. A catalog row never says more than `verify.md` proves.
- If two checks disagree about a count, report the disagreement; do not adjust numbers until they match.
- On Windows, set `PYTHONUTF8=1` for the Python commands, and check the regenerated files afterwards: Python
  writes CRLF line endings there, and the run fails if a file that had LF endings now has CRLF. Convert such a
  file back to LF (`sed -i 's/\r$//' <file>` in Git Bash) before you finish.
