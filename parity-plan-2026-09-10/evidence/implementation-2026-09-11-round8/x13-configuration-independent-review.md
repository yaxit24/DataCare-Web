# X13 effective incoming Return configuration — independent Round8 review

This review concerns the read-only configuration prerequisite and its pure resolver. It does not enable a numeric writer, UI commit, stock admission, original-sale copy, aggregate/header accounting, or reversal. The frozen Round7 core/source artifacts were not modified.

## Source findings and independent expectations

The primary company loader is MS_OPNCOMP:657–659,675,686,691,717,733–735,757–759,817–819,881–883,929–931,948–950,1006,1224–1226 and1297–1303. Conversion of LBR_ROF comes before >3→0 and final ALL_ROF_REMOVE=Y→2. A valid negative Int32 can reach the final override; an overflowing, fractional, nonfinite, NULL or malformed conversion is not rescued by a later setting. The strict profile deliberately contains those unmeasured conversions. It preserves exact raw strings/NULL and treats only exact empty strings as the documented N/G/Y defaults. Current shared web rounding/default normalizers are not substituted.

The runtime column source is company COL_MAST, loaded by DC_Main:1686–1692. The grid filters the literal SALES RETURNE family and original headings at TR_SALE_RTN:3739–3755, then forces Sr325 and RecCode300 at3758–3759. COL_NEW_NAME is display text, not an event key; duplicate captions on distinct original fields may coexist. No company00 fallback or GET provisioning is performed. COL_RPT is not a Return calculation/repeat policy. The original IL proves actual column-width getters; only zero/nonzero is adapted at canonical source scale, never current browser CSS.

`x13-configuration-independentvectors.json` contains35 expectations authored directly from this source contract before implementation review. Its byte-identical API test fixture pins SHA256 2a75aa523224004fa7ac5e015e6c70a8260db9b18ec3c087c6fa65c5c3cc6e7f. The independent test also pins the unchanged35 arithmetic and8 width fixtures from Round7. It passes each width case through the new configuration resolver into the frozen core. Expected arithmetic is never computed from the implementation under review.

The initial implementation was reviewed for exact configured company/branch/book/year scoping, company-wide collection before column collision classification, a single RepeatableRead observation, settings whitelisting, detached response values, stable source IDs, original-name lookup, edition uncertainty, and physical revision/locator hashing. All numerical mutation capability remains false. Catalog definitions are frozen; the response is intentionally a detached mutable DTO, not an Object.freeze claim.

## Executed independent checks

The coordinated `configuration-focused-complete.txt` run passed all69 tests in `saleReturnIncomingConfiguration.review.test.ts`. These cover35 independent setting vectors plus catalog/forced-width/alias/caption/edition/raw/scope/token checks and all8 frozen width-to-core cases. No independent DB run or alternate Vitest setup was used. The service owner ran this file with the ordinary isolated wrapper and coordinated DB lease.

That combined stage passed the service's36 pure and26 DB tests and54 route-policy tests. The one root-owned HTTP failure was an expected-status mismatch: the existing scope middleware rejected a missing configured book with409 before the new service could return422. The combined194-test result was193 passing/one failing, not a complete green run. Root owns the corrected HTTP expectation and final full regression. A subsequent Style-caption correction and its new service test are described below; no earlier pass is retroactively credited to that later source stage.

## Concrete defects found and disposition

1. A noncanonical Fine alias first marked its width unresolved, but an exact Fine/N candidate later overwrote the DTO to resolved zero. Calculation capability was already blocked, so no wrong calculation was enabled, but the observation advertised an unjustified authoritative width. The owner now reapplies ambiguous-width state after exact candidate processing. The69-case independent run covers this correction.
2. A noncanonical family row could unset RecCode's width state despite source3758–3759 forcing it positive after all overrides. The owner preserves forced-visible columns during ambiguity marking. The independent run covers RecCode300/nonzero while still blocking the ambiguous configuration.
3. Post-run review found that unresolved software edition plus a canonical Style override could populate an effective caption. Actual non-A/E source never assigns the Style heading and never matches that override. The owner now retains null effective/original captions until edition resolution, while configured:true records the observed row and stable sourceName remains Style. A/E resolves the caption; other editions stay hidden. The owner added a37th pure service case. This correction awaits root's final coordinated run at this document's capture time; the previous69-test stage is historical evidence, not proof of the later source hash.

No implementation source was edited by the independent reviewer. Owned changes are the independent test, its portable expected fixture, and these new Round8 evidence files.

## Important limits and next verification

- Missing CO_SET/CO_SET_NEW, canonical-key collisions, duplicate physical business identities and unsupported raw setting conversions contain calculation under a named strict web profile. These rejections are not proof of identical desktop DBNull/CInt/culture behavior.
- Existing book compatibility is explicit: blank table/direction is accepted consistently with the current helper's fallback; explicit contradictions reject. This is not a claim that the helper requires nonblank table/direction. Lowercase n activity rejection is a separate conservative profile choice.
- Unknown edition leaves Style unavailable while known Fine/ordinary policy can remain usable. The trusted runtime currently does not infer edition from caller data or expose registration values. Caption-only CSS changes never become source identities or calculation widths.
- Tokens cover exact represented scoped rows, counts, catalog, settings, physical revision and locator. They detect observed existing-row updates and delete/recreate. They do **not** record an initially absent Fine override that is inserted and then deleted back to the identical empty set: the old token can recur. An independent pure expectation explicitly documents this equality, and root requested the actual DB absence-cycle counterpart. Universal/history-sensitive ABA requires a durable company/family revision protocol. Future numeric replay also requires complete locked Serializable re-resolution, including phantom configuration insertion; this read token grants no write authority.
- The raw-to-visible projection, actual source selection/copy, new tag instances, components, totals, accounting and exact runtime/business acceptance remain separate. The configuration endpoint does not make any field editable.
- Root must run the corrected full focused suite, strict API test types and complete API/build/browser regressions against captured inputs before the checkpoint. This review's69 passing pure cases do not substitute for those integration checks.

## Read-review capture

Captured UTC: 2026-09-11T09:50:42.336452+00:00

These hashes identify the current read-review source stage (including the post-focused Style correction), not a before-run snapshot for the earlier194-test log. Root owns final execution input capture.

| Path relative to web | SHA256 |
| --- | --- |
| `apps/api/src/modules/sales/saleReturnIncomingConfiguration.ts` | `f7161a49c156621f048f7105f9648018f5726c017938f9e2bb356d74905f9308` |
| `apps/api/test/saleReturnIncomingConfiguration.review.test.ts` | `01ea87768ac8e99158e64813014b33a59b54365042e3b28fcb26c992f9e3655a` |
| `apps/api/test/fixtures/saleReturnIncomingConfiguration.independent.json` | `2a75aa523224004fa7ac5e015e6c70a8260db9b18ec3c087c6fa65c5c3cc6e7f` |
| `../parity-plan-2026-09-10/evidence/implementation-2026-09-11-round7/x13-next-configuration-contract.md` | `e1cb24964b8d1e9ab5dc2fa687f520a5084d08ef9fbe510e9eaad85265171a46` |
| `../unified/src/csharp/DataCareNext/MS_OPNCOMP.cs` | `180f295f9595dfc7c28ee34629563889c943eea0a0afc7c7a9baa519a11c4561` |
| `../unified/src/csharp/DataCareNext/TR_SALE_RTN.cs` | `cdee9c37772522727d08c86baee71a46daa7b11cdfdf2eeb1ef656d80dfbb7a1` |
| `../unified/src/csharp/DataCareNext/DC_Main.cs` | `7ff3543a78440db0f6f18eaf442aade59a105fcb398c0ba7fd9f9c53c195a688` |
| `../parity-plan-2026-09-10/evidence/implementation-2026-09-11-round8/configuration-focused-complete.txt` | `a583c7ab5d8550586a2ccaf279d9676e4b8d493c238c01ac20a08c74f8dc57c6` |

## Subsequent root HTTP verification

The root-owned corrected HTTP run passed all9 tests (one file) in `configuration-http-corrected.txt`. The retained first combined failure was the existing middleware409 versus service422 expectation described above. This additional HTTP pass does not retroactively change the initial193/194 outcome or prove the later Style-specific pure test; root still owns the final coordinated source capture and complete regression.

Root HTTP log SHA256: `7633c5ffa929f66d614361c2aca9ebd624f77774a887bc75107822dc5942400f`.

## Final focused source-stage verification

The subsequent root-coordinated `focused-complete.txt` run passed **7 files / 253 tests / 0 skips** in30.97s. The actual file counts were37 configuration pure (including the later unresolved-Style caption case),26 configuration DB,69 independent review,9 configuration HTTP,54 route policy,37 column-setting pure and21 column-setting DB/HTTP. This is the first credited combined run here covering the later Style correction with the independent69 cases and corrected HTTP expectation together.

The earlier193/194 combined result and its HTTP expectation failure remain historical evidence; the9/9 corrected HTTP run is a separate intermediate stage. Neither earlier result is relabelled as the final source stage. Root's final complete API input capture/full suite, strict API test types and15 actual-browser journeys were still pending at this update; no pass is awarded to them in this note.

Focused log SHA256: `098b62e2c8a9d856c7cf01cee26486d6e5394c2d235354127eff71c8b69be04f`.

Current configuration implementation SHA256 at attribution: `f7161a49c156621f048f7105f9648018f5726c017938f9e2bb356d74905f9308`. Independent review test SHA256: `01ea87768ac8e99158e64813014b33a59b54365042e3b28fcb26c992f9e3655a`; portable expected fixture SHA256: `2a75aa523224004fa7ac5e015e6c70a8260db9b18ec3c087c6fa65c5c3cc6e7f`. Root owns execution-wide before/after hash verification.
