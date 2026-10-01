---
name: datacare-plan-update
description: Update the DataCare master plan correctly — slice status and evidence in execution-backlog.json or phase2-backlog.json, new gaps (G82+), slices (N89+, SP25+) and decisions (D28+), status tables, lineage items — and keep validate_plan.py green. Use whenever work changes a slice's state or reveals a new defect.
---

# Plan update

Change: `$ARGUMENTS`.

Plan package: `docs/master-parity-plan-2026-09-29/`. Status lives only in the JSON backlogs; prose documents are
historical once written.

## 1. Slice status

1. Allowed statuses: `planned`, `in-progress`, `implemented-unverified`. Never write `done`, `accepted` or `closed`:
   acceptance belongs to the parent packages (document 04).
2. A non-planned slice needs `statusAsOf` (YYYY-MM-DD), `evidence` (repository paths that exist: the code, tests and
   progress records) and a factual `statusNote` (what landed, what remains).
3. Add a row to document 11 §2 ("Status corrections to existing slices") for slices N01–N82, or to document 12 §6 for
   N83 onward.
4. Change a prior card's finding only through `currentFindingCorrection` (`asOf`, `finding`, `source`); never edit
   `currentFinding`.

## 2. New gap

1. Next ID: G82 onward, in the table of `12-lineage-verification-2026-10-01.md` §3, with the same columns:
   `| ID | Sev | Area | Desktop authority | Web evidence | Required behaviour | Slice |`. Severity: S1 blocks a daily
   workflow, loses data, prints a wrong legal or financial document, or is a security exposure; S2 wrong or
   incomplete in a supported branch; S3 depth or ergonomics.
2. Cite desktop and web evidence as `path:line`.
3. Every gap from G20 must be cited by a slice's `gapIds` (Phase 1) or a Phase 2 slice's `gapIds`.

## 3. New slice

1. Phase 1: next ID N89 onward in `execution-backlog.json` `newSlices`, with `id`, `status`, `action`,
   `parentLabels`, `startAfter` (existing slice IDs, no cycles), `entryDefinition`, `requiredProof`, `gapIds`,
   `sourceAndModuleDetail`, `universalContract`, `verification`; plus a specification section in document 12 §5
   (gap, parents, severity, size, start after, steps, "Done when").
2. Phase 2: next ID SP25 onward in `phase2-backlog.json` `slices`, with `milestone` (M0–M7), `size`, `title`,
   `gapIds`, `startAfter`, `steps`, `tests`, `doneWhen`.
3. Update the minimum counts in `validate_plan.py` (`len(slices)>=…`, `len(gap_ids)>=…`, decision count) in the same
   change.

## 4. New decision

Next ID D28 onward in document 12 §4 with the columns `| ID | Decision and recommended position | Owner / deadline |
Evidence |`. A decision is "accepted" only when the owner has said so; write the date and source.

## 5. Lineage

When an item in `lineage-register.json` closes, set its disposition to `closed` with `evidence` paths; keep the row.
Update the `<!-- lineage-counts: … -->` comment and the table in document 12 §2 if the totals change.

## 6. JSON format

Write the backlogs so that this round-trips exactly (the validator and reviewers rely on stable diffs):

```python
import json
data = json.load(open(path, encoding='utf-8'))
# … edit …
open(path, 'w', encoding='utf-8').write(json.dumps(data, indent=2, ensure_ascii=False) + '\n')
```

## 7. Validate

```bash
python3 docs/master-parity-plan-2026-09-29/validate_plan.py
python3 docs/tools/docs_check.py
(cd web && pnpm docs:refs)
```

Another session may edit the same backlog: `git fetch origin && git rebase origin/main` before pushing, resolve
conflicts by keeping both sessions' entries, and re-run the validator.
