# Isolated API external-input audit

This is a read-only audit of the frozen API test sources under `/tmp/datacare-round12-verification/web/apps/api/test`, their filesystem-reading runtime/script dependencies, and corresponding active files. No tests, assertions, source files, database, compiler or repository documents were changed. This is static source and directory-membership evidence, not syscall tracing.

## Exact qualified additions

Keep all1546 already captured inputs byte-identical. Add only the188 paths listed with exact SHA256 and byte size in `recommended-reference-additions.json` (SHA256 `6c982a86008b80f34ea6f4099395265c89835caf7eeafce1cb175799a8a75f84`):

- 186 omitted `unified/src/csharp/DataCareNext/*.cs` files. `contractIntegrity.test.ts:37–42` enumerates the complete204-file top-level source directory, totaling43,280,092 bytes. The18 already captured sources remain unchanged; add the missing members rather than recopying mutable source indiscriminately.
- `project-memory/parity/PARITY-RATCHET.json`, read unconditionally by the frozen `releaseCertification.test.ts:393` exact-case-set assertion.
- `web/deploy/.env.example`, read by `einvoiceProductionGuard.test.ts:102–112`. An uncaptured stale Git-baseline copy exists in the isolated worktree; replace that copy with the newly qualified exact reference. No environment contents were printed by this audit.

The additions total34,415,024 bytes. No other omitted persistent input was found in the inspected direct reads, transitive filesystem consumers, script imports or directory scans. `audit.json` (SHA256 `2309e537ccc40db5174d50fa789c08ec5e7e6b704031180ae2a6fe7ce872a18c`) records every inspected group, concrete member hashes and the point-in-time comparison.

## Required sets already captured

| Input path or directory | Consumer and reason |
| --- | --- |
| `project-memory/contracts/*.contract.md` (11) | `contractIntegrity.test.ts:31–34` enumerates and reads all contracts. Preserve directory membership as well as bytes. |
| `parity-plan-2026-09-10/evidence/report-register.json` | Frozen release certification checks the complete independent report identity set. |
| `web/docs/COMPLETION-REGISTER.json` and every declared page surface | Completion tests read the register and call exists/stat on page paths. |
| `project-memory/parity/g5/parity-diff-latest.json`, `project-memory/parity/restore-drill-result.json` | Frozen release tests inspect retained G5/restore evidence and expect its actual red/stale classification. |
| `.github/workflows/{ci,release-certification}.yml`, `web/.github/workflows/{ci,release-certification}.yml` | Both active-root and historical nested workflow texts are compared by frozen assertions. |
| `web/deploy/docker-compose.prod.yml`, `web/docker-compose.yml` | GSP variable forwarding and forbidden sandbox default assertions. |
| `web/apps/web/test/parity.real-stack.mjs` | Frozen release test reads the producer's exact emitted journey set. |
| `web/apps/web/components/KarigarForm.tsx` and transaction pages `jobwork-issue`, `jobwork-receive`, `karigar-issue`, `karigar-receive`, `wholesale-sale` | `pageEndpointFamily.test.ts` reads their actual source text. |
| `web/apps/api/src/**/*.ts` (238) and `web/packages/core/src/**/*.ts` (15) | Literal/kernel scanners enumerate these trees as data; route tests also read specific source files. |
| `web/apps/api/report-specs/*.json` (255) | Contract test reads all report specs; runtime engine also loads the index or enumerates specs. |
| `web/apps/api/form-specs/*.json` (176) | Runtime form engine reads named alternatives and enumerates complete layout data. |
| `web/packages/db/prisma/schema.prisma` | Report schema assertions read the raw schema. |
| `web/packages/core/test/fixtures/saleReturnIncoming.{independent,widths}.json` | API configuration review reads and hashes these cross-package independent goldens. |
| `web/apps/api/test/fixtures/**` (7 files) | Image bytes, independent JSONs and helper imports used by actual tests. |
| `web/scripts/lib/release-certification-record.mjs`, `web/scripts/lib/release-candidate-identity.mjs`, `web/scripts/load-profile.mjs`, `web/scripts/secret-scanner.mjs`, `web/apps/api/package.json` | Imported script helper implementations; load-profile anchors require resolution at API package.json. |

All inspected already-captured frozen files still matched their manifest hashes. The enumerated API/core/spec/fixture directories contained no additional uncaptured Git-baseline member. The desktop directory has18 captured members and needs the186 additions. Directory member lists should remain explicit so additions or stale leftovers cannot silently evade the capture.

## Required absence and synthetic files

Keep `project-memory/parity/reports/report-comparison-latest.json` absent, as the existing externalAbsences record requires. The frozen release test expects that artifact to be missing. An absence is an observed test input, not a file to fabricate.

Release candidate identity tests create their own temporary lock/schema fixture tree and inject Git responses. Certification-record tests write and read their own temporary results. These generated files are derived from captured test literals; they are not missing live repository inputs. `reportContract.test.ts` mentions `project-memory/catalogs/realdb-schema-full.json` only in explanatory provenance comments; the test does not read it. The metrics and security tests call pure functions from their script modules; they do not execute those scripts' CLI scans. `server.ts` has a UI harness file reader, but API tests build `app.ts` and do not start that server entry point. Dependency packages and rebuilt core/DB outputs remain governed by the dependency/build qualification, separately from this appendix.

## Active drift: do not import it

The active worktree differs from the frozen capture in two release tests and four inspected dependencies: both `release-certification.yml` copies, `apps/api/src/modules/ops/releaseCertification.ts`, and `scripts/lib/release-certification-record.mjs`. Exact observed source hashes are in `audit.json`.

In particular, active `releaseCertification.test.ts` now wraps report-register/ratchet reads in existsSync guards and adds a text read of `web/scripts/release-certify.mjs`. The frozen assertions remain authoritative. The runner script itself was already captured in1546; its new active-only read introduces no missing-reference addition. Do not adopt active assertion guards or unrelated latest source edits to make the isolated run pass.

The final rerun should qualify the188 additional reference bytes, verify the original1546 bytes remain exact, preserve the required absence, and rerun unchanged frozen assertions. No test result is inferred from this audit.
