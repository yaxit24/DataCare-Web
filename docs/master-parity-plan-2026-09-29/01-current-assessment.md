# Current assessment and evidence boundaries

## 1. Baseline and preservation

The GitHub repository and `/Users/yakshitsavaliya/Desktop/imodule-extracted` both reported commit `03148fef5899224b8c4c9805ca07161a920efeb1` on 29 September 2026. The desktop working tree was clean. A fresh clone was used for this analysis. Across the selected canonical source, active web, September plan and project catalog trees, **5,509 tracked non-LFS files were byte-identical**, with no differences or absent counterparts; 191 LFS pointers in that selected set were excluded from the byte comparison. See `evidence/source-comparison.json` for the exact selection result.

Canonical paths stay as documented in `REPOSITORY-MANIFEST.md`: `web/` is the application, `unified/` is the normalized desktop reference, and the raw extraction trees are provenance. No desktop files or application sources are modified by this package. Large binaries/report assets in the clone may be LFS pointers; an existing path is not proof that its bytes are available. Hydration and hash validation are explicit prerequisites for Windows replay and physical print comparison.

The repository is private or otherwise unavailable through unauthenticated web fetch in this review; authenticated Git access succeeded. Assessment is based on the actual Git checkout, not a public web summary.

## 2. Actual architecture

| Layer | Current evidence | Planning consequence |
|---|---|---|
| Frontend | `web/apps/web/package.json`: Next.js 15.1.6, React 19; routes, shared grids, lookups, tenders and saved-document panels | Extend domain screens and interaction contracts; avoid rebuilding the shell |
| API | `web/apps/api/package.json`, `src/app.ts`, `src/routes/txn.ts`: Fastify 5.8.5 | Some historical text says NestJS; the implementation is Fastify |
| Domain calculations | `web/packages/core/src/`; decimal.js plus legacy Number-based adapters | Prove per-field numeric semantics; the presence of decimal.js does not establish desktop equality |
| Persistence | Prisma 6.19.3, PostgreSQL schema and migrations; raw scoped SQL for legacy-shaped data | Preserve identity, raw imported values and relationships while enforcing web isolation |
| Desktop | Windows Forms/.NET, SQL Server, Crystal Reports; DataCareNext and NextDm | Original Windows executions and SQL captures are needed for final behavior and print proof |
| Verification | Vitest, frontend unit runner, real-stack browser runner, parity extraction/replay/diff scripts and release certifier | Keep engineering tests separate from source-derived vectors and original-runtime comparisons |

Version values above describe the pinned repository only, not an upgrade recommendation. Resolve runtime support and deployment choices in the delivery work; do not change dependencies merely to make this planning review current.

## 3. Inventory and coverage

The retained primary inventory contains 204 namespace source units plus eight supporting startup/assembly units. These are not 204 independent operator screens. The alternate NextDm namespace contains 199 units. The retained menu register has 198 entries; aliases and configuration-dependent callers mean each entry must be tested independently even when it shares a form or API.

The September registers retain 3,508 named-grid requirements, 1,599 control records, 5,838 event records, and 916 additional input declarations missed by a simpler scanner. They are raw coverage obligations, not necessarily independent business features. Resolve duplicates and designer-only declarations with source/caller evidence, preserving original IDs. Do not add these counts and call the sum a feature denominator.

Other retained coverage includes 275 report references (a different concept from the 255 preserved `.rpt` files), 146 desktop table units and 130 scanned settings. Reports require data, layout, parameter and mode coverage; table presence requires ownership and migration disposition; setting presence requires observable behavior.

`web/docs/COMPLETION-REGISTER.json` still classifies all 198 entries as `implemented-unverified`. Its strict classification gate can pass while its release gate fails. All 83 original packages and 34 cards remain open. The retained 72.1% surface ratio and 61.3% visible grid-column ratio do not measure functioning business journeys or effort remaining.

## 4. Findings that materially change the implementation order

| Finding | Code/evidence | Required response |
|---|---|---|
| Saved incoming Return replay is diagnostic, while a legacy write path still exists | `core/src/saleReturnOtherAmountReplay.ts`, `saleReturnFinancialEffects.ts`, `saleReturnSaveGuards.ts`; `api/src/routes/txn.ts` POST `/sales-returns`; `modules/sales/salesReturn.ts` | Explicitly reconcile old and new path authority, calculations and side effects before broad release. A passing pure planner cannot authorize a write. Audit the active legacy route too. |
| Four tag mutations remain blocked | `web/packages/core/containment.mjs`: transfer, cancel, weight-difference, split | Give each its own identity, conservation, locking, reversal, browser and desktop proof. Tag-opening update being released does not release these four. |
| Manufacturing Setting issue/receipt only exposes qualified browsing/source selection | `modules/manufacturing/mfgLot.ts`, `settingsTx`, `writes:false` | Implement full staged writes, source consumption, partial receipt and rollback; do not count a populated lot screen as complete. |
| E Credit Note browsing/provider operations are not a full document lifecycle | `modules/einvoice/creditNote.ts`, E-credit routes | Implement create/open/update/delete or legal cancellation transitions, source allocation, ledger/tax and reports before acceptance. |
| Core rules can still drift across modules | `core/src/money.ts`, `shared/roundingPolicy.ts`, `posting/posting.ts`, existing transaction builders | Source-confirmed numerical profiles and write ownership precede broad form editing. Sampled customer defaults are evidence of observations, not universal schema defaults. |
| Business scope has strong recent primitives but adoption must be checked throughout | `auth/sessionContextCommand.ts`, `sessionContextSerializableCommand.ts`, `sessionContextReadSnapshot.ts`, frontend `lib/api.ts` | Audit each command, read, image, device callback, report and background job. A strong wrapper does not cover callers that do not use it. |
| Report assets/specs can exist without proven bindings and outputs | `reports/reportBind.ts`, `reportBindingContract.ts`, retained report register | Review current bindings rather than trusting old unsafe-binder labels; prove every report/mode with real data and printer output. |
| Two operational actions are contained | `containment.mjs`: `production-cutover-load`, `logical-restore` | Separate migration safety work from restore release work; do not bypass the registry to run a rehearsal. |
| Statutory constants and mappings need dated review | `modules/gst/gst.ts`, e-invoice/provider code | Treat desktop compatibility and current statutory compliance as separately versioned requirements. Do not infer current law from legacy code comments. |
| Retained test evidence is not current whole-tree certification | September checkpoint/source manifests versus current tracked files | Rerun against a frozen candidate and preserve missing/stale failures. Historical success only proves its original declared inputs. |

Module-specific evidence and risk candidates, including complete loan/scheme, bullion, custody, image and utility workflows, are in document 06. Static concerns are explicitly marked as hypotheses requiring tests; this is not a claim to have reproduced all defects.

## 5. New checks versus retained evidence

This review installed the exact lockfile dependencies in the isolated clone with package lifecycle scripts disabled, then ran safe local checks. The initial frontend unit invocation failed to resolve the unbuilt workspace core package; the corrective action was to build that existing package, without source edits, and repeat the dependent suite. Both attempts are retained. Detailed final results and exit codes are in `evidence/verification-observations.json` and the referenced logs.

The core suite newly passed 26 files / 1,613 tests. After the core dependency build, the frontend suite newly passed 36 Vitest files / 522 tests plus six native protocol tests. The existing strict menu-classification check newly passed and its release-grade mode newly failed on all 198 unverified entries. Documentation-reference validation newly found missing generated historical browser artifacts; it must not be described as a current pass merely because a September run passed.

No original Windows application was executed in this review. No real customer database was modified. No live provider/device, real API/DB suite, production browser, migration, restore, report print comparison, or full release certificate was run. These are planned acceptance gates, not successful results of this analysis.

The retained Round15 narrative reports only two of its 18 recipe checks completed and no sealed checkpoint43. Checkpoint41 remains the latest sealed record for earlier Round14 inputs. Subsequent repository changes and absent generated artifacts mean neither is a blanket certificate for the current commit. The source manifest comparison in document 07 details that distinction.

## 6. Why a single completion percentage would mislead

There is meaningful reusable work in most modules: domain modules, schemas, forms, lifecycle handlers, configuration consumers, reports, a session model and many tests. There are also missing writes, narrower admitted profiles, unverified variants and absent original-runtime proof. A scalar average of menu mappings, fields or passing tests collapses these different conditions.

Track five states independently for each semantic requirement: implemented, engineering-tested, desktop-matched, business-accepted, release-certified. A requirement can be implemented and unit-tested yet have an incorrect report footprint. A disabled mutation is neither usable nor complete. A retained source-derived test is not an original-runtime comparison. Only after the required semantic set has been reviewed can a completion ratio be reported against that named set and candidate.
