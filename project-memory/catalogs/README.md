# catalogs/ — Phase-0 outputs (source of truth for the web build)

Populated by Phase 0 tasks. The web build (Phases 1–11) references these.

- `completeness-manifest.json` — Task 1/2/5: every required artifact + present|missing|external-blocker.
- `report-reconciliation.json` — Task 2: code-referenced .rpt vs collected; copied/conflict/blocker.
- `data-model.json` — Task 3: tables -> columns/types/nullability/defaults/PKs/composite tenant keys.
- `erd-core.md` — Task 3: ERD of core tables.
- `forms/` — Task 4: one behavioral spec per form (save sequence, validations, delete/reverse).
- `module-map.json` — Task 4: form -> module classification (master|transaction|report|utility).
- `build-blocker-report.md` — Task 5: reference-build attempt results + external blockers.
