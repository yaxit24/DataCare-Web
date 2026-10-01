# DataCare-Web steering

- Repository: the DataCareNext desktop jewellery ERP (`unified/`) rebuilt as a web app (`web/`). Phase 1 = desktop
  parity in the web; Phase 2 = SaaS product, not started until Phase 1 is certified (D28). Read `AGENTS.md` and
  `docs/README.md` before working.
- The plan is `docs/master-parity-plan-2026-09-29/` (documents 01–14 and the backlogs) plus `docs/handbook/`: next
  slice from document 13 §3, its specification in document 02, 10, 11 or 12, status in the backlog. Older plans are
  history; see "Which documents to follow" in `AGENTS.md`.
- Never push to `main`; branch, pull request, CI. Stage specific files. Keep hooks.
- The desktop source is the authority for business behaviour; cite `file:line`. Do not port desktop weaknesses.
- Never print secrets or customer data. Desktop SQL Server: aggregate queries only. Tests only on the isolated
  database (port 55433).
- Status lives in `docs/master-parity-plan-2026-09-29/execution-backlog.json` and `phase2-backlog.json`; never claim
  acceptance.
- Before finishing: `python3 docs/master-parity-plan-2026-09-29/validate_plan.py`, `python3 docs/tools/docs_check.py`,
  and the web gates in `AGENTS.md`.
- Start with `kiro-cli chat --agent datacare` (`.kiro/agents/datacare.json`): it loads the plan and handbooks,
  runs `docs/tools/session_status.py` to show other sessions, and blocks pushing to `main`.
- Skills: `datacare-implement-slice`, `datacare-desktop-authority`, `datacare-write-set-test`, `datacare-e2e-visual`,
  `datacare-code-review`, `datacare-plan-update`, `datacare-docs-update`, `datacare-test-first`, `datacare-debug`,
  `datacare-verify-before-done`.
