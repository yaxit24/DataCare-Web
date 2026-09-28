# Repository Manifest and Provenance Map

This repository is both an active application repository and a preservation baseline. Its apparent duplication is intentional: normalized/canonical material supports development while byte-preserved raw inputs support provenance and re-verification.

## Canonical working paths

| Concern | Canonical path | Start document |
|---|---|---|
| Active web implementation | `web/` | `web/docs/HANDOFF.md` |
| Current parity plan/status | `parity-plan-2026-09-10/` | `parity-plan-2026-09-10/README.md` |
| Cross-session state and catalogs | `project-memory/` | `project-memory/README.md` |
| Desktop extraction/resource center | `unified/` | `unified/README.md` |
| Web implementation specification | `web-implementation-spec/` | `web-implementation-spec/00_Overview/01_MASTER_INDEX.md` |
| Desktop Windows build guidance | `docs/` and `unified/docs/` | `unified/docs/WINDOWS_BUILD_GUIDE.md` |

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

1. `parity-plan-2026-09-10/README.md`
2. `parity-plan-2026-09-10/42-implementation-progress-round15.md`
3. `parity-plan-2026-09-10/02-implementation-plan.md`
4. `web/docs/HANDOFF.md`
5. `project-memory/state.json`, `project-memory/JOURNAL.md`, and relevant ADRs/catalogs

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
