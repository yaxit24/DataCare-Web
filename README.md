# DataCareNext — Desktop-to-Web Migration

Private engineering repository for converting the DataCareNext Windows jewellery/gold ERP into a complete web application. It preserves the active Next.js/Fastify/PostgreSQL implementation together with the original Windows deployment, SQL Server datasets, decompiled and reconstructed source, Crystal Reports, extraction evidence, project memory, and the latest parity plans.

> **Restricted plaintext snapshot:** this repository intentionally contains legacy credentials, realistic database records, local environment snapshots, and proprietary binaries. It must remain private. Read [SECURITY-NOTICE.md](SECURITY-NOTICE.md) before granting access, forking, exporting, or changing visibility.

## Start here

**29 September master planning review:** [Detailed current analysis and master parity implementation plan](docs/master-parity-plan-2026-09-29/README.md). Includes all 31 API modules, reconciliation of the 83 prior packages/34 cards, desktop source references, retained field/action registers and step-by-step end-to-end verification. This documentation update preserves the application and historical checkpoints; it does not claim full parity.

1. **Current implementation status:** [parity-plan-2026-09-10/README.md](parity-plan-2026-09-10/README.md)
2. **Paused Round 15 continuation:** [parity-plan-2026-09-10/42-implementation-progress-round15.md](parity-plan-2026-09-10/42-implementation-progress-round15.md)
3. **Full implementation plan:** [parity-plan-2026-09-10/02-implementation-plan.md](parity-plan-2026-09-10/02-implementation-plan.md)
4. **Web handoff:** [web/docs/HANDOFF.md](web/docs/HANDOFF.md)
5. **Desktop resource center:** [unified/README.md](unified/README.md)
6. **Repository/provenance map:** [REPOSITORY-MANIFEST.md](REPOSITORY-MANIFEST.md)

## Repository map

| Path | Purpose |
|---|---|
| `web/` | Active pnpm monorepo: Next.js UI, Fastify API, shared calculation/report packages, Prisma/PostgreSQL schema, migrations, tests, deployment files, and parity harnesses. |
| `docs/master-parity-plan-2026-09-29/` | Current source-based planning review, master execution sequence, module detail, prior-plan reconciliation, source/requirement indexes and verification playbook. |
| `parity-plan-2026-09-10/` | Current 83-package/34-card implementation and acceptance plan, progress records, immutable checkpoints, scripts, and evidence. |
| `project-memory/` | Cross-session continuity store, ADRs, catalogs, contracts, raw parity captures/diffs, video research, journal, state, and handoff. |
| `unified/` | Canonical desktop extraction: decompiled C#, VB.NET reconstruction, original DLLs, EXEs, databases, 255 Crystal reports, resources, images, configuration, tools, and manifests. |
| `DataCareSetup/` | Original setup files and the complete dated RAR deployment archive. |
| `DataCareSetup_extracted/` | Extracted original desktop deployment, including binaries, dependencies, reports, images, and SQL Server files. |
| `DataCareNext.exe`, `NextDm.exe` | Loose original Windows executables retained as provenance inputs. |
| `extracted_code/`, `extraction_output/` | Raw decompiler projects, dumps, categorized metadata, report XML, and extracted images. |
| `DataCareNext_Source/`, `new/` | Reconstructed/original-style VB.NET source trees and archived source copy. |
| `Report/`, `zip_contents/`, loose `*.rpt` | Raw report and package inputs retained alongside the canonical `unified/` copies. |
| `web-implementation-spec/` | Form-, table-, report-, and architecture-level web implementation specifications. |
| `docs/`, `audit/`, `tools/` | Desktop build guidance, fidelity audits, and extraction/verification utilities. |
| `.kiro/specs/` and `.verify_*.md` | Project-local requirements and retained verification context. |

The duplicated raw and canonical trees are deliberate: raw files preserve provenance while `unified/` provides the normalized desktop reference used by the rebuild.

## Current status

The web implementation is substantial, but complete desktop parity and production readiness are **not** established. The latest status records 198/198 menu entries mapped, 0/198 whole-menu acceptances closed, all 83 implementation packages and all 34 execution cards still open, and Round 15 paused after only its bounded core checks. Do not infer functional completion from page counts, static field ratios, or historical checkpoints; the linked parity plan is authoritative.

## Clone and hydrate artifacts

Git LFS is required because the repository stores original executables, databases, libraries, archives, reports, media, and evidence bundles.

```bash
git lfs install
git clone https://github.com/yaxit24/DataCare-Web.git
cd DataCare-Web
git lfs pull
```

Use `git lfs fsck` after cloning to verify local LFS objects. Binary integrity can also be checked against `ARTIFACT-MANIFEST.sha256`.

## Develop the web application

Requirements: Node.js 20 or newer, pnpm 9.15.4, Docker for the full database-backed workflows.

```bash
cd web
corepack enable
pnpm install --frozen-lockfile
pnpm typecheck
pnpm test
pnpm build
```

Additional gates are defined in `web/package.json`, including lint, schema readiness, settings/type/depth parity, report baselines, and release certification. Some integration and browser gates require PostgreSQL, SQL Server parity inputs, or external hardware/providers; consult `web/docs/HANDOFF.md` and the current parity plan rather than treating a skipped external gate as a pass.

## Reproduce or inspect the desktop application

Use Windows and begin with [unified/docs/WINDOWS_BUILD_GUIDE.md](unified/docs/WINDOWS_BUILD_GUIDE.md). The canonical reference material is under `unified/`; raw deployment copies are retained separately so extraction and provenance can be independently checked.

## Repository rules

- Keep original artifacts byte-for-byte; add corrected or sanitized derivatives as separate files rather than overwriting provenance inputs.
- Keep implementation changes, migrations, tests, documentation, and parity evidence together.
- Update the current handoff/plan when implementation state changes.
- Keep large/binary formats in Git LFS according to `.gitattributes`.
- Never make this repository public without first removing and purging all content listed in `SECURITY-NOTICE.md` from Git history and LFS storage.

No open-source license is granted by this repository. The desktop product, extracted code, data, and bundled third-party components remain restricted to authorized project use.
