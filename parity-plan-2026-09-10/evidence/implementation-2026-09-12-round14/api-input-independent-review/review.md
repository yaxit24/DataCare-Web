# Round14 API external input audit

Source-only review; no tests, database commands, builds, browser runs or active-tree edits. The comparison baseline is the captured `browser-context-final.inputs.json` (1883 declared paths), not a claim about a later final API result.

The identified **non-secret direct API inputs are already captured** in that baseline. Final API qualification must enforce their current equality as well as API/package/script equality. A broad source archive alone does not establish that a particular API run used those final bytes.

| Additional current-equality domain | Actual API consumer |
| --- | --- |
| `web/apps/web/app/` and `web/apps/web/components/` | `pageEndpointFamily.test.ts:24–26,38–60,81–84` reads five transaction pages and `KarigarForm.tsx`. `completionRegister.test.ts:72–75` checks eight distinct page paths selected from the register. |
| `web/docs/COMPLETION-REGISTER.json` | `completionRegister.test.ts:30–31,115–125`; changing this file changes page membership and asserted classification. |
| `web/deploy/.env.example`, `web/deploy/docker-compose.prod.yml`, `web/docker-compose.yml` | `einvoiceProductionGuard.test.ts:103–105,117–119,130–131` reads exact deployment text. |
| `project-memory/contracts/*.contract.md` and `unified/src/csharp/DataCareNext/*.cs` | `contractIntegrity.test.ts:28–41` enumerates and reads all 11 contracts and 204 C# files. Include directory membership, so additions are checked too. |

Keep the previously identified release inputs: `parity-plan-2026-09-10/evidence/report-register.json`, `project-memory/parity/PARITY-RATCHET.json`, `web/apps/web/test/parity.real-stack.mjs`, both root and nested `ci.yml`/`release-certification.yml`, and the imported release scripts. The retained evidence reads are exactly `project-memory/parity/g5/parity-diff-latest.json`, `project-memory/parity/restore-drill-result.json`, and the **absent** `project-memory/parity/reports/report-comparison-latest.json`. Their consumers are `releaseCertification.test.ts:327–329,510–512,693–701,1088–1118,1183–1205,1258–1322`. Optional existence checks must be captured too: absence can remove an assertion branch.

The initial draft accidentally shortened the report register to repository-root `report-register.json`. Source line 327 proves the longer path above; the draft was corrected before freeze. No actual root-level read exists.

The wrapper and generated Prisma client add local environment inputs missing from the observed 1883 set:

- `web/.env.parity-test`: direct wrapper read at `parity-test-env.mjs:12–29`.
- `web/packages/db/.env`: present; the generated Prisma client records this `schemaEnvPath` at `index.js:6895–6897` and passes it to `warnEnvConflicts` at `6945–6947`.
- `web/.env`: present CLI/environment-discovery candidate, not a demonstrated direct Vitest import.
- `web/packages/db/prisma/.env` and `web/apps/api/.env`: absent discovery candidates.

Record these five paths separately by presence and before/after SHA, without copying their contents into the public source archive. The wrapper explicitly supplies isolated DSNs, test flags and UTC (`parity-test-env.mjs:31–40`); this does not make every other inherited environment option or installed binary part of the source manifest. `environment-input-observations.json` contains only identities, no values. Root reports subsequently adding these separate observations; this review does not credit execution of that revised helper.

Module-resolution inputs also need final equality: `web/package.json`, lock/workspace manifests, package manifests, API Vitest/TypeScript configs, shared tsconfig, isolated compose file and capture/run/universe helpers. Package source and generated dist used by workspace exports must stay covered. All listed non-secret paths were already present in 1883. The existing universe helper explicitly discovers current API tests, web source, package core/DB source/test/dist, scripts and the two desktop/reference directories (`capture_implementation_checkpoint_round12_isolated.py:37–47,117–128`).

Do not expand API claims from comments or mocked helpers. `reportContract.test.ts` mentions `project-memory/catalogs/realdb-schema-full.json` in provenance, but reads only report specs and Prisma schema. `typeParityInput.test.mjs` supplies literal schema/dump data; the imported CLI main is guarded. Release identity tests inject Git observations and use virtual or test-created temporary files. `releaseCertificationRecord.test.mjs` reads only its temporary outputs. These do not establish a live candidate Git checkout, type dump or production release certification.

`verification-only-inputs.json` separately records conditional CLI dependencies: depth/settings/schema baselines, exact generated API dist imports, `MSSQL_TYPES`, complete Markdown/citation resolution for the docs gate, and release artefacts/commit trees. For example, the 1883 manifest does not include every `web/docs/parity-evidence` Markdown file; a standalone docs gate needs that membership and citation closure. This is not an API-suite omission. Neither `web/deploy/backup.sh` nor the alternate NextDm source tree is read by the API paths found here.

The R13 3050-pass result preceded the seventeenth browser journey and cannot be attributed to the final R13 runner. Preserve checkpoint39 and the failed R14 3156/3157 stage. The final R14 proof needs the corrected 17-journey assertion, a fresh input record and current equality over the complete declared domains above. Run outcome is root-owned and not inferred by this audit.

This is a bounded static filesystem-read review, not runtime file-access tracing or an immutable operating-system/toolchain image. Exact directory/file identities and consumer references are in `audit.json`; source hashes are in `review-inputs.json`. Installed Prisma/Node/Playwright and PostgreSQL process state remain execution-environment evidence, not blanket source-capture guarantees.
