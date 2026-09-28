# Current state and gap analysis

> Historical review of 10 September. For the 11 September implementation status and remaining concrete work, read [the current review](11-current-completion-review.md) and [execution continuation](12-execution-addendum.md). The earlier counts and absence statements below are retained as dated evidence, not current completion claims.

## Review basis

The review uses the working tree under `Desktop/imodule-extracted`, at Git HEAD `41a7ba4e2bd529be25f80144c97bb647b6795781`, including substantial uncommitted modifications and additions. HEAD alone does not identify the reviewed implementation. [The source manifest](evidence/source-manifest.json) hashes 1,325 source/configuration/contract files; [the initial Git status](evidence/git-status.txt) records the differences present when review began.

Desktop references use `unified/src/csharp/DataCareNext/`; the web is a pnpm workspace using Next.js/React, Fastify and PostgreSQL/Prisma. The package description still says NestJS; actual API dependencies and code use Fastify. The 204 desktop source units include forms and shared engines. The source scanner finds 153 with a positive input/grid surface, so “204 desktop screens versus 101 web pages” is not a defensible UI completion metric.

The analysis inventories every source unit and report reference, reruns available source measurements, reads the shared implementation and representative complex workflows, and checks earlier findings against current code. It does **not** claim manual interpretation of all 969,133 decompiled lines or observation of every running desktop interaction. The plan makes that remaining behavioural extraction and runtime validation explicit work with acceptance gates.

Earlier plans and project memory remain useful evidence leads. Their completion claims and archived waivers do not automatically establish current acceptance. In particular, the user's request includes richness and working interactions: old exclusions for keyboard preferences, grid navigation and duplicate printing cannot be used to call those requirements complete.

The fresh secondary-source comparison finds **199 NextDm source units**, all with filenames also present in the primary tree. Of the shared files, 76 are byte-identical and 123 differ; the primary adds `OlockerService.cs`, `PolicyModels.cs`, `RP_STOCK_VALUE.cs`, `TR_FN_INOUT.cs` and `UT_PWD_UPDATE.cs`. NextDm has 1,575 input-control and 3,420 named-grid occurrences in the same scanner. This is a filename/hash comparison, not proof that one edition is a behavioural subset of the other: the 123 differing files require semantic/version review in P13. See [the edition delta](evidence/edition-delta.json).

## Re-verification correction

The follow-up review found that the original control-declaration regex omits modifiers: **916 additional input declarations across 143 primary source units** are absent from the frozen 1,599-record index. `MS_PRINT` has three `private virtual CheckBox` controls despite its scanned input count of zero. The whole primary C# tree also has eight supporting files outside the 204-unit namespace register. These are additional unverified obligations, not newly verified web features. Combined input candidates number 2,515, but semantic visibility, deduplication and remaining extraction gaps still require P00. The field ratios below are retained historical scanner results with an incomplete desktop denominator. See [the re-verification](08-plan-reverification.md) and [supplement](09-additional-source-register.md).

## Fresh measurements and their limits

| Dimension | Fresh observation | What it establishes |
| --- | --- | --- |
| Desktop source units | 204; 153 with positive field surface | Extracted catalog breadth, including engines |
| Desktop inputs / named grid columns | 1,599 / 3,508 | Heuristic source occurrences; some are conditional or computed |
| Web pages / transaction pages | 101 / 66 | Filesystem routes, including dynamic generic routes |
| Web inputs / grid columns, distinct composed files | 1,024 / 1,653 | Markup and recognized column-registry occurrences |
| Web field surface | 2,677 / 5,107 = 52.4% | A conservative scanner ratio, **not** parity |
| Web per-page field surface | 3,554 / 5,107 = 69.6% | Shared components counted per page; still not semantic matching |
| Editable transaction grids with keyboard hook | 50 / 50 identified | Hook presence; keyboard behaviour and conditional modes need browser tests |
| Pages with shared subdetail component | 12 | Adoption; not complete per-grid field/payload/round-trip proof |
| Recalculation adoption | Scanner reports 0; direct code search finds `recalcLine` used by sales | The scanner searches `lineRecalc`/`useLineRecalc` and misses the actual name |
| Report authorization registry | **53 entries** | Existing scanner reports 48 because it counts only quoted property names |
| API input scan | 2,138 fields across 152 interfaces; 96 with no frontend name match | Lexical reachability leads, not endpoint-specific data flow |
| API-only classifier | 14 operator candidates; 53 server-derived; 29 internal | Review queue; exposing all 96 would be incorrect |
| Settings inventory | 130 rows | Distinct denominator from the old 128-key exposure gate |
| Raw-key settings scan | 45 business matches, 2 UI-only matches, 82 inert rows | Incomplete heuristic; typed aliases and duplicate keys make totals unsuitable for certification |
| Containment registry | 6 operations; 9 transaction-route call sites | Four tag operations, logical restore and production migration remain blocked |
| Menu completion register | 145 implemented-unverified, 53 absent, 198 total | Every entry fails the release gate; several absence mappings are stale |
| Report reference register | 255 supplied binaries + 20 absent references | 275 reconciliation obligations; not 275 proven runnable reports |
| Desktop table register | 146 retained units | Must reconcile with 145-table initializer and restored-schema inventories |

The source metrics are retained unchanged in [evidence](evidence/). The corrected report count and alias leads are separate outputs; no baseline was rewritten to create a passing result. The alias search found consumer candidates for eight settings the raw scanner calls inert. It still does not prove every branch or call site honours those settings.

## Verification performed now

| Check | Result | Limit |
| --- | --- | --- |
| API TypeScript, no emit | Passed | Static types only |
| Web TypeScript, no emit | Passed | Static types only |
| Web Vitest | 8 files / 51 tests passed | Pure/helper/source tests; not live business journeys |
| Core Vitest | 3 files / 17 tests passed | Shared arithmetic and containment tests |
| Depth audit / ratchet | Passed | Maintains an existing floor; can pass with substantial gaps |
| Dead-cell audit | Passed; 603 extended columns across 20 configured pages | Checks textual member consumption, including imported modules; not all pages or actual writes |
| Settings exposure | Passed, reports 128/128 | Exposure and options; not 130-row behavioural coverage |
| Completion register `--strict --release` | Failed; 198 entries not releasable | Retained mapping needs refresh as well as implementation |
| Desktop comparison gate | Failed; retained comparison has 510 field differences | Reads the September 1 artifact, does not recapture current source |
| Docker availability | Daemon unavailable | No new DB-backed suite, migration drill or SQL Server replay was run |

The retained September 1 comparison contains 70 cases, zero completely matching cases, 27,895 fields compared, 1,701 fields excluded, 153 missing rows, 137 extra rows, 59 desktop-only table occurrences and 76 web-only table occurrences. These are per-case comparison totals, not counts of distinct missing tables. The retained release certification failed. No `project-memory/parity/reports/report-comparison-latest.json` exists.

The repository has 161 API test files, including 67 `*.db.test.ts` files. Their existence does not mean they passed this review. The current global setup deliberately refuses an unconfigured database run. The plan preserves that distinction rather than requesting skipped tests and reporting a green full suite.

## Current improvements that should be preserved

| Earlier gap claim | Current source evidence | Remaining obligation |
| --- | --- | --- |
| Blank dhiran interest becomes zero | `txn/dhrn-receipt/page.tsx:100` and `txn/dhrn-interest/page.tsx:64` now omit a blank interest override | Live browser → API tests for blank, explicit zero, recalculated and manual values |
| Jobwork labour derivation suppressed | `components/KarigarForm.tsx:265,302` conditionally omits blank labour amount | Verify every issue/receive variant and unchanged edit |
| Karigar issue loses wastage | `KarigarForm.tsx:257,301` now sends `westPct` | Differential formula/settlement proof |
| No shared stone/component grid | `components/SubDetailGrid.tsx`; 12 pages use it | Cover all required grids, parent linkage, computed fields and persistence |
| F6 absent | `components/FormKeys.tsx:180` maps F6 | Test real navigation/focus and browser conflicts |
| F10 must be added | Current source notes the caption exists but the desktop handler is absent | Observe the desktop; do not implement behaviour inferred only from a label |
| Bullion booking consumption never updated | `sales/rateCut.ts:1090–1133` contains consume/release logic | Verify booking selector, outstanding availability, edit/delete and concurrent drawdown |
| No hallmark tax or negative-stock setting effects | `sales/sales.ts:776,934` and `purchase/purchase.ts:725` consume typed settings | Confirm defaults, all variants and bypass resistance |
| Tag-opening edit always disabled | Removed from containment; rich round-trip test exists | Retain regression and obtain desktop differential / device evidence |
| Bill profit/HUID/physical-stock/stock-level reports wholly absent | Dedicated report modules and registry entries exist | Refresh menu mappings; verify filters, data, layouts and business usefulness |

These are source-confirmed changes with varying test support. They are not blanket “desktop parity achieved” statements.

## Confirmed current gaps and high-risk limitations

| ID | Observation and evidence | Business consequence | Plan |
| --- | --- | --- | --- |
| GAP-01 | `manufacturing/mfg.ts:978` exports `mfgLotBalance`; no registration/call in `routes/txn.ts` or dedicated lot workflow page was found | Lot-based manufacturing cannot reproduce `TR_MFG_WITH_LOT` end to end | P08 |
| GAP-02 | `sales/rateCut.ts` builds `RATE_CUT_DATA` and `RATE_CUT_ISU`; `RATE_CUT_REC` appears only in commentary, with no receive writer; desktop `TR_BUL_SALE` has a separate receive grid | Two-sided metal receipt/issue and settlement are incomplete | P06 |
| GAP-03 | `masters/designBook.ts:78` replaces `DESIGN_DETL` only; no `DESIGN_IDTL` persistence or child collection contract | Design stone/component specifications cannot round-trip as on desktop | P03 |
| GAP-04 | `masters/[name]/page.tsx` supports scalar field inputs; images for designs use `DESIGN_NO` alone at line 27 | Parent-child editing and book/product-specific images need full identity and UI support | P03 |
| GAP-05 | `containment.mjs` blocks tag transfer, cancel, weight difference and split | Visible or implemented endpoints remain unusable for four stock workflows | P07 |
| GAP-06 | `recalcLine` is called from sales only; rate-cut still uses local `Math.round` previews at page lines 57–81 | Per-cell recomputation and preview/post equivalence remain incomplete | P01/P02 |
| GAP-07 | `branchAllAccountShow`, `duplicatePrint`, `stockRefreshFromDateOnly`, `saleTagWeightDiffReconciled` are loaded but no business consumer was found outside the loader | Configurable lookup, printing, refresh and stock effects are missing | P02/P07/P11 |
| GAP-08 | `reportBind.ts:42–58` supports six table families and defaults unknown layouts to `SL_DATA` | An available template can render the wrong dataset; blank or plausible output can mislead | P10, priority 0 |
| GAP-09 | `reportBind.ts:100–115` filters voucher rows by company/book/number only; `/reports/render` at `txn.ts:4392` does not pass fiscal year or location | Reused voucher numbers can select or combine another branch/year's rows within the tenant | P10, priority 0 |
| GAP-10 | `reportFilters.ts` exposes 11 scalar dimensions; `/gst/gstr1` at `txn.ts:5117` forwards threshold only beyond scope | Rich report modes and additional filters require explicit mapping; unsupported input must not silently vanish | P10 |
| GAP-11 | `/render/pdf` accepts submitted HTML and is listed as a system route | Printed financial output and print permissions need an explicit document contract and authorization review | P10/P11 |
| GAP-12 | `voucherRenumber.ts:64–75` allows ten tables; auxiliary references such as Rojmel/UPI/order allocations are outside that list | Renumbering is not evidence of safe cross-book transfer; reference closure must be measured | P11 |
| GAP-13 | Browser smoke and route coverage stub `**/api/**` and point the server at an unavailable API origin | Passing browser tests cannot establish persisted business effects | P00/P14 |
| GAP-14 | `check-dead-cells.mjs` iterates its fixed 20-page map; its “unmapped” counter concerns missing mapped modules, with no filesystem discovery of other pages | New or differently declared grids can escape the check | P00 |
| GAP-15 | The repository root has `.github/workflows/rpt-extract.yml`; web CI and release files live under `web/.github/workflows/` | Those nested files are not automatically GitHub workflows for this root repository | P00/P14 |
| GAP-16 | Release runner validates a supplied SHA; clean checkout enforcement exists in the nested CI file, not in the local runner | Local results may be labelled with HEAD while testing uncommitted source; bind tree/build/evidence identities | P14 |
| GAP-17 | Only 11 retained `*.contract.md` files cover the 204 source units | Most units lack the same authored validation/formula contract discipline | P00 onward |
| GAP-18 | No report differential artifact; desktop case set concentrated in a small set of families | Complete reporting and broad workflow equivalence remain unproven | P10/P14 |
| GAP-19 | Desktop `TR_SALE.cs:21567` has a wired Olocker policy-generation action; `OlockerService.cs:87` builds invoice/tag/metal/stone policy payloads. No Olocker/insurance/policy-generation counterpart was found in current web source | A post-sale desktop integration is absent from the web workflow | P05/P11 |

Resolve unsupported-family handling and explicit bindings before expanding template availability.

GitHub documents the repository `.github/workflows` requirement in its [workflow syntax reference](https://docs.github.com/en/actions/reference/workflows-and-actions/workflow-syntax). The path finding above is an inference from that requirement and this checkout's root/layout; a separately published web-only repository would need separate evidence.

## Gaps that need targeted observation, not an invented answer

The plan includes sales/order/quotation/approval imports, voucher transfer, wholesale bulk edits, separate sale-return receive grids, old-gold and UPI allocation grids, tour-order modes, bill adjustment, consignment, loan variants, commission, tax sections and report drill-down. Earlier audits identify these, but current endpoint/variant equivalence requires fresh contracts and browser captures. Their individual status is **unverified/partial**, rather than automatically repeating every old “missing” claim.

The same applies to full stock rebuild, year-end/carry-forward, repair stages, data import/export, balance transfer, user requests, book provisioning and image inheritance. Useful modules exist. Their complete transitions, scope keys and reversal effects must be tested in the related family, not inferred from a filename or a generic menu link.

## Source index for implementation

- Desktop source and loader: `unified/src/csharp/DataCareNext/`, especially `MDI_FORM.cs`, `MS_OPNCOMP.cs`, `Ac_Stock.cs`, `Module_Save.cs` and each named form.
- Current UI: `web/apps/web/app/(app)/txn/`, `components/`, `lib/api.ts`, `lib/nav.ts`, `lib/lineRecalc.ts`.
- Routes: `web/apps/api/src/routes/txn.ts`; session/context and app hooks in `src/app.ts` and `modules/auth/`.
- Posting compatibility: `modules/posting/posting.ts`, `modules/vouchers/`, `modules/shared/`, `web/packages/core/src/`.
- Data and isolation: `web/packages/db/prisma/schema.prisma`, `prisma/migrations/`, `prisma/rls.sql`, `src/tenant.ts`.
- Evidence and older specifications: `project-memory/contracts/`, `catalogs/form-behavior/`, `catalogs/form-logic/`, `parity/IDTL-REFERENCE.md`, `web-implementation-spec/`.

References are relative to the project root unless noted. The fresh registers link actual source paths and preserve candidate mappings with their limitations.
