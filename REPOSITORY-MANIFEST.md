# Repository Manifest and Provenance Map

This repository is both an active application repository and a preservation baseline. Its apparent duplication is intentional: normalized/canonical material supports development while byte-preserved raw inputs support provenance and re-verification.

## Canonical working paths

| Concern | Canonical path | Start document |
|---|---|---|
| Documentation entry point | `docs/` | `docs/README.md` |
| Active web implementation | `web/` | `docs/handbook/web/README.md` (operating history: `web/docs/HANDOFF.md`) |
| Current plan and status | `docs/master-parity-plan-2026-09-29/` | `docs/master-parity-plan-2026-09-29/README.md`; status in `execution-backlog.json` and `phase2-backlog.json` |
| September plan, progress records and evidence | `parity-plan-2026-09-10/` | `parity-plan-2026-09-10/README.md` |
| Cross-session state and catalogs | `project-memory/` | `project-memory/HANDOFF.md` |
| Desktop extraction/resource center | `unified/` | `docs/handbook/desktop/README.md`, `unified/README.md` |
| Web implementation specification | `web-implementation-spec/` | `web-implementation-spec/00_Overview/01_MASTER_INDEX.md` |
| Desktop Windows build guidance | `docs/` and `unified/docs/` | `unified/docs/WINDOWS_BUILD_GUIDE.md` |
| Agent instructions | repository root, `.kiro/` | `AGENTS.md` |

## Preserved raw inputs

- `DataCareSetup/`: original installer/support files and dated complete deployment archive.
- `DataCareSetup_extracted/`: extracted deployment tree.
- Root `DataCareNext.exe` and `NextDm.exe`: loose executable inputs.
- `zip_contents/`: unpacked package copy used during extraction.
- `extracted_code/`: raw decompiler projects for DataCareNext, NextDm, NextEmp, and AllImage.
- `extraction_output/`: string/metadata dumps, report XML, database-table observations, and images.
- `DataCareNext_Source/` and `new/`: reconstructed/original-style VB.NET source and source archive.
- `Report/` plus root report files: raw Crystal Report inputs.

Do not collapse or deduplicate these paths merely because identical hashes appear under `unified/`. Their paths identify how each artifact was obtained.

## Canonical normalized desktop tree

`unified/` collects the material used by the migration work:

- `src/`: decompiled C# variants and VB.NET reconstruction.
- `binaries/`: all retained executable versions and debug symbols.
- `libs/`: production third-party/runtime dependencies.
- `database/`: schema, SQL Server backups/data files, and exports.
- `reports/`: complete Crystal Report collection.
- `resources/`, `images/`, `fonts/`, `templates/`, `config/`: runtime assets.
- `extraction_metadata/`, `tools/`, `docs/`: audit evidence, reproducible tooling, and guidance.

The original `unified/MANIFEST.md` and project-memory completeness catalogs remain the detailed extraction sign-off.

## Development continuity

Use the documents in this order when resuming work:

1. `docs/README.md` (documentation hub) and `AGENTS.md`
2. `project-memory/HANDOFF.md`, then the top of `project-memory/JOURNAL.md`
3. `docs/master-parity-plan-2026-09-29/13-phase1-delivery-plan.md` and the status in `execution-backlog.json`
4. `docs/handbook/menu-catalog.md` for the menus you will touch
5. Relevant ADRs in `project-memory/decisions/` and catalogs in `project-memory/catalogs/`

The September documents (`parity-plan-2026-09-10/README.md`, `42-implementation-progress-round15.md`,
`02-implementation-plan.md`) and `web/docs/HANDOFF.md` remain the historical record; `docs/handbook/doc-register.md`
labels every document.

Historical checkpoints are immutable evidence for their frozen inputs; they do not certify newer working-tree changes.

## Integrity and large-file handling

Binary/original artifacts are stored with Git LFS according to `.gitattributes`. `ARTIFACT-MANIFEST.sha256` records content hashes for the LFS-managed working-tree artifacts in this baseline. After cloning:

```bash
git lfs pull
git lfs fsck
shasum -a 256 -c ARTIFACT-MANIFEST.sha256
```

## Deliberate exclusions

Only reproducible or machine-local generated material is excluded: package dependencies, `.next`/Turbo caches, compiler intermediates, test-result directories, coverage, Python caches, editor metadata, runtime volumes, and scratch files. Source, plans, evidence, SQL datasets, parity captures, environment snapshots, original binaries, and embedded legacy credentials are intentionally retained under the owner's explicit private-repository authorization.
