# DataCare-Web steering

- Repository: the DataCareNext desktop jewellery ERP (`unified/`) rebuilt as a web app (`web/`). Phase 1 = desktop
  parity in the web; Phase 2 = SaaS product. Read `AGENTS.md` and `docs/README.md` before working.
- Never push to `main`; branch, pull request, CI. Stage specific files. Keep hooks.
- The desktop source is the authority for business behaviour; cite `file:line`. Do not port desktop weaknesses.
- Never print secrets or customer data. Desktop SQL Server: aggregate queries only. Tests only on the isolated
  database (port 55433).
- Status lives in `docs/master-parity-plan-2026-09-29/execution-backlog.json` and `phase2-backlog.json`; never claim
  acceptance.
- Before finishing: `python3 docs/master-parity-plan-2026-09-29/validate_plan.py`, `python3 docs/tools/docs_check.py`,
  and the web gates in `AGENTS.md`.
- Skills: `datacare-implement-slice`, `datacare-desktop-authority`, `datacare-write-set-test`, `datacare-e2e-visual`,
  `datacare-code-review`, `datacare-plan-update`, `datacare-docs-update`.
