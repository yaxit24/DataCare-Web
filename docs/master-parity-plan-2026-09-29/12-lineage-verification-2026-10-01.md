# Lineage verification, documentation hub and new gaps — 1 October 2026

This document answers one question: **does the current plan account for every earlier plan, gap list, audit and
requirement?** It records the method, the result per source, the items that no current identifier owned (new gaps
G69–G80, plus G81 found by the independent review of this change), the decisions they need (D23–D28, all accepted by the owner on
1 October 2026) and the slices that close them (N83–N88). It also records the
documentation hub created in the same change.

- **Baseline:** `main` at `675d845` (after PR #25, G67, and PR #26, N47).
- **Machine record:** [`lineage-register.json`](lineage-register.json) lists every item with its disposition and
  current owners. `validate_plan.py` checks that every owner identifier exists, every evidence path exists and the
  counts below match the register.
- **Scope rule:** like documents 10 and 11, this document closes no package (P00–P14), card (X01–X34) or acceptance.
  "Carried" means a current identifier owns the remaining work, not that the work is done.

## 1. Method

Two independent reviews read every planning and status document outside the current package — the twelve root
plans and reports, the September package (`parity-plan-2026-09-10/`, documents 01–48), `web/docs/`,
`project-memory/` (handoffs, ADRs, contracts, parity audits, the video knowledge base), `web-implementation-spec/`
and the original requirements (`.kiro/specs/datacare-web-rebuild/requirements.md`). For each open item they decided:

| Disposition | Rule |
|---|---|
| closed | Fixed in engineering, with a file, test or record that shows it. A closed defect never closes its parent package |
| carried | A current P, X, N, G, D, J, R or SP identifier's text actually covers the remaining work |
| new-gap | No current identifier covers it; it becomes a gap in §3 with a slice in §5 |
| superseded | A later plan structure replaced it; the successor identifiers carry it |
| decision | It conflicts with current policy or needs an owner choice; recorded in §4 |

A third review read the 198 desktop menus one by one against the decompiled dispatch (`MDI_FORM.cs`), the form
sources, the tutorial knowledge base and the web code. Its result is the
[menu catalog](../handbook/menu-catalog.md), checked by `docs/tools/docs_check.py`. It found no menu without an
owner, and 20 rows where `web/docs/COMPLETION-REGISTER.json` names the wrong form or web surface (G71).

## 2. Result

<!-- lineage-counts: sources=37 items=228 closed=32 carried=178 new-gap=14 superseded=4 -->

37 sources, 228 items: **32 closed, 178 carried, 14 new gaps, 4 superseded.** The two items that needed an owner
decision (requirements 19.2 and 21.1) were decided on 1 October 2026 (D23, D24) and are now carried. Every new-gap
item maps to one of the gaps G69–G80 below.

| Source group | Items | Closed | Carried | New gap | Other | Notes |
|---|---:|---:|---:|---:|---:|---|
| Root plans and reports, August–September (9 files) | 127 | 24 | 99 | 2 | 2 superseded | Already reconciled at package level by [document 07](07-previous-plan-reconciliation.md); this review checked item by item |
| `PARITY-EVALUATION-2026-09-28.md` | 10 | 2 | 5 | 3 | — | Harness defects, missing builders and Next25 columns had no leaf owner |
| `report.md`, `req.md` | 2 | — | 1 | — | 1 superseded | Extraction gaps carried by X32 and N74–N77 |
| `.kiro` requirements 1–22 | 22 | 1 | 20 | 1 | — | Requirements 1–4 closed by the extraction; traceability itself was missing; 19.2 and 21.1 decided by D23 and D24 |
| September package (01, 02, 03, 08, 11, 12) | 22 | — | 22 | — | — | CR-01 and CR-02 findings in the backlog were stale; corrected (§6) |
| `web/docs` plans, catalogue and status | 25 | 3 | 21 | 1 | — | Phase 2 SaaS product not owned anywhere |
| `project-memory`, `web-implementation-spec`, security reviews | 14 | 2 | 9 | 2 | 1 superseded | ADR-0002 levers without triggers; SQL interpolation lint |
| Register, index, dependencies, route file, desktop utilities | 6 | — | 1 | 5 | — | Register mapping errors, fragmentation, runtime support, maintainability, SaaS utilities |

The row counts are taken from the register's per-source totals; [`lineage-register.json`](lineage-register.json) is
the authority for each item.

### Requirement traceability (`.kiro` requirements 1–22)

| Requirement | Disposition | Current owners |
|---|---|---|
| 1–4 Extraction audit, unified centre, manifest, blockers | closed | `unified/MANIFEST.md`, `unified/README.md` |
| 5 Multi-tenant data foundation | carried | P01-01, X05 |
| 6 Authentication and company/year selection | carried | X09, N55 |
| 7 Users and rights | carried | X29, P11-04 |
| 8 Masters | carried | X10, P03-01, P03-02, N58, N69 |
| 9 Calculation engine | carried | X04, P01-02, N48 |
| 10–15 Sales, purchase, stock, manufacturing, dhiran, finance | carried | X13, X12, X18, X23, X24, X16 with their packages |
| 16–18 Accounting, GST/e-invoice, schemes | carried | X16, X26, X15, N16, X24 |
| 19 Reports and documents | carried; 19.2 decided by D23 (refuse and list the missing fields) | X25, X26, N74, N75 |
| 20 Integrations | carried | X28, N25, N54 |
| 21 Behavioural parity verification | carried; 21.1 decided by D24 (enforced by tests and release gates) | X03, X06, X34, N82 |
| 22 Phased delivery | carried | X31, X33, N80, N82, D25 |

## 3. Gap register G69–G83

Severity as in documents 10 and 11. G69–G74, G79 and G81–G83 are Phase 1 (desktop parity in the web); G75–G78 and G80 are
Phase 2 (the sellable SaaS product, [document 14](14-phase2-saas-plan.md)) and are owned by its SP slices.

| ID | Sev | Area | Desktop authority | Web evidence | Required behaviour | Slice |
|---|---|---|---|---|---|---|
| G69 | S2 | Replay harness inputs and builders | `PARITY-EVALUATION-2026-09-28.md` §9; corrected copy `parity-plan-2026-09-10/evidence/independent-evaluation-2026-09-28/scripts/eval-replay-corrected.mjs:105-115` (drops literal untagged `N`, carries header discount, line other and labour amounts, receive rows and `CR_FINE`) | `web/apps/api/integration/parity-replay-generic.mjs:110` passes `TAG_NO` unfiltered and omits those fields; only PURCHASE, SALES and RATE CUT/WH SALES have builders, every other family returns `NO_BUILDER` (`:274`) | The shipped harness carries the four corrections and has builders for karigar issue/receipt (050/052), sales order (020) and estimate (032), each with a positive and a deliberately broken fixture | N83 |
| G70 | S2 | Next25 edition columns | Next25 schema: `PR_DATA` OTH_TAX_AMT, OTH_TAX_CODE, OTH_TAX_PRC, RE_TRFR, ZERO_RATED_AMT; 13 `PR_DETL` columns (BAG_TOT, GRAND_TOTAL, ITM_CGST_AMT, ITM_IGST_AMT, ITM_SGST_AMT, ITM_REMARK, IT_TAX_AMT, RATE_WITH, TAXABL_RATE, TAX_CODE, TAX_FREE_AMT, TAX_RVRS, TAX_TYPE); `RATE_CUT_DATA.RE_TRFR`; `RATE_CUT_ISU.FIX_WEST_PRC`; `RATE_CUT_REC.ITM_STYLE`; `AD_MAST.BANK_AC` (`parity-plan-2026-09-10/evidence/independent-evaluation-2026-09-28/differential/field-summary-corrected.txt:153-192`) | None of the 21 columns exists on those models in `web/packages/db/prisma/schema.prisma` (checked model by model on 1 October) | Forward migration with desktop types and defaults; writers, readers, import and differential include them where the edition writes them | N84 |
| G71 | S3 | Completion-register mapping | `MDI_FORM.cs` dispatch for each menu | 20 rows of `web/docs/COMPLETION-REGISTER.json` name the wrong form or surface (for example Style → `COL_MAST` instead of `MODEL_MAST`; Member Mast → loyalty `POST /members`; Loan Intrest → pledge-only interest; HuId Report → stale tag-stock alias). Full list: [menu catalog](../handbook/menu-catalog.md#completion-register-corrections) | Register, navigation and catalog agree with the dispatch; `register:check` refuses a planted mismatch | N85 |
| G72 | S1 | Supported runtime and framework | — | `web/apps/web/package.json:16-18` and the lockfile pin `next` 15.1.6 and `react` 19.0.0 — inside the range of the December 2025 React Server Components RCE advisory (GHSA-9qr9-h5gf-34mp, CVE-2025-55182 / CVE-2025-66478, App Router; fixed in React 19.0.1 and Next.js 15.1.9). Later 2026 Next.js security releases (May, July, August, 30 September: 15.5.27 / 16.3.8) patch only the 15.5 and 16 lines. CI (`.github/workflows/ci.yml:43,97,279`), release certification (`.github/workflows/release-certification.yml:88`) and `web/Dockerfile.web:16,37` use Node 20, which reached end of life on 30 April 2026. Prisma 6.19.3 receives security fixes only until 19 November 2026 | No installed package inside a known critical or high advisory; Node 24 LTS in CI and images; a recorded Next 16 and Prisma 7 decision (D26) | N86 |
| G73 | S3 | Requirement traceability | — | The original requirements 1–22 had no mapping to plan identifiers; 19.2 (partial invoices) conflicts with the fail-closed template binding (`web/apps/api/src/modules/reports/reportBindingContract.ts`); 21.1 asks for runtime blocking on a parity difference | Every requirement mapped (§2); D23 and D24 decided | N87 |
| G74 | S3 | Documentation fragmentation | — | About 970 Markdown files in eleven trees; `web/docs/README.md` and `project-memory/README.md` each present themselves as the entry point; `web/README.md` and `project-memory/state.json` still name NestJS; backlog findings for X15 and X18 were stale; `pnpm docs:refs` checks only `web/docs` | One hub (`docs/README.md`), a register that classifies every Markdown file, handbooks, a generated menu catalog and a blocking check in CI | N87 |
| G75 | S2 | Platform control plane (Phase 2) | — | Tenant is a raw `x-tenant-id` header outside production or one `APP_TENANT_ID` per deployment (`web/apps/api/src/app.ts:241-246`, `web/apps/api/src/server.ts:91-94`); roles are tenant `ADMIN`/`USER` only; provisioning is per company | Platform realm separate from tenant users; tenant directory and lifecycle; trusted tenant resolution; consented, audited support access; onboarding | SP04–SP08, SP13, SP14, SP17 |
| G76 | S2 | Commercial model (Phase 2) | — | No plan, entitlement, subscription, invoice or usage model in the schema or route policy | Versioned plans and entitlements, limits, subscriptions, GST-compliant subscription invoices, metering | SP07, SP15, SP16 |
| G77 | S2 | Asynchronous work, storage and scale (Phase 2) | — | No durable queue (`web/docker-compose.yml` omits Redis because nothing consumes it); entity images stored as database `bytea`; per-process metrics and rate limits; local unencrypted `pg_dump` backups (`web/deploy/backup.sh`); ADR-0002 levers have no activation triggers | Outbox, queue and workers; object storage; managed PITR and per-tenant restore; telemetry and SLOs; measured scale triggers | SP09, SP10, SP12, SP18, SP24 |
| G78 | S2 | Privacy, security and compliance (Phase 2) | — | Provider credentials are process-wide environment variables; mutation audit is written after the response and records method, path and status only (`web/apps/api/src/app.ts:176`); no data-principal request workflow; India's DPDP Rules apply in phases from 14 November 2026 and 14 May 2027 | Per-tenant secrets; durable platform audit; DPDP notice, consent, request and breach workflows; independent penetration test | SP11, SP19, SP20 |
| G79 | S2 | Maintainability boundaries | — | `web/apps/api/src/routes/txn.ts` is 8,400 lines with 602 route declarations and maps errors by name pattern (lines 755–864); the largest pages are 1,867 and 1,485 lines; no OpenAPI or shared request contract (`web/packages/types/src/index.ts`); no rule rejects unbound SQL interpolation (`project-memory/parity/SECURITY-REVIEW.md:41-45`) | Per-module route plugins with schemas, typed error taxonomy, a shared voucher editor, size budgets and import/SQL lint (Phase 1); OpenAPI and contract package (Phase 2) | N88, SP03 |
| G80 | S3 | Desktop-only utilities in a SaaS (Phase 2) | `UT_BKP.cs:1223-1271` (drive backup and restore), `UT_HDD.cs:748-765` (machine registry), `UT_WINDOW.cs:1434-1439` (global tiles), destructive import/export and renumber | Phase 1 reproduces them where safe; several are unsafe or meaningless for a hosted multi-tenant service | Managed, flagged replacements that keep business results unchanged (D25) | SP21 |
| G81 | S2 | Client-side CSV export | — (the desktop exports through Crystal and Excel, not this path) | `downloadCsv` in `web/apps/web/lib/api.ts:204-212` only quotes values, and the generic report page uses it; the server encoder neutralises a leading `=`, `+`, `-` or `@` (`web/apps/api/src/modules/reports/reportCsv.ts:30-41`). Found by the independent review of this change | Every CSV the browser downloads is produced by the server encoder or encoded the same way; a test exports a cell containing `=1+1` | N57 |
| G82 | S2 | Provisioned tax masters lack the parent row | `web/apps/api/src/modules/shared/taxPolicy.ts` resolves a tax code by its parent row, `TAX_MAST.SR_NO = 0`, as the desktop tax queries do (`AND D.SR_NO = 0`) | Found while implementing N40: `web/apps/api/src/modules/ops/seedCompany.ts` provisioned each tax code as a single row at `SR_NO = 1`. A sale created by rate resolved; any save that named the code (`taxCode`) failed with "tax code is not configured: 10" on every web-provisioned company. **Fixed standalone:** `seedCompany.ts` now writes the desktop shape (parent at `SR_NO = 0`, SGST/CGST/IGST at `SR_NO = 1/2/3`) and migration `20261002010000_tax_mast_parent_row` repairs existing provisioned companies; `provisioning.db.test.ts` runs the real migration file against a legacy fixture (and twice, for idempotence) and proves every GST code resolves by name and by percentage with the correct component split. Because a parent and its IGST component share the full rate, the by-percentage lookup in `taxPolicy.ts` now measures ambiguity by distinct tax code and returns the parent (two different codes at one rate still refuse, `taxMasterGst.db.test.ts`). `TAX_AC` is deliberately left unset, as before, so no posted account changes: purchase input tax still posts to `GSTINPUT` and sale tax to `GST` (asserted by the same test); choosing tax ledger accounts is D15 and is recorded as G86. The TCS head (code `20`, `SR_NO = 0`) now exists, so the E Invoice automatic TCS above the ₹50 lakh threshold computes instead of being skipped, and refuses to save until G86 gives the head an account. **Follow-up (review):** a sale entered by rate (no tax code) that matches a code's parent row now loads that code's component rows too, so its `TAX_DATA` rows carry `SGST`/`CGST` at half rate instead of the parent group `N` (found in the G83 browser check; purchases and returns are G90) | Provisioning writes the desktop shape (parent at `SR_NO = 0`, components at 1..n) and existing provisioned companies are repaired — done; identity convention remains N58 |
| G83 | S2 | Old-metal header and ledger use the posted amount | `unified/src/csharp/DataCareNext/TR_SALE.cs` totals the exchange grid (`MSG_OLD` column 13, :19336-19350) into `OLD_GL_AMT`; the web values the detail row server-side (`web/apps/api/src/modules/sales/sales.ts` `resolveOldGoldValuation`) | Found while implementing N40: `SL_PR_DETL.NET_AMT` was the server valuation (25,810 in the round-trip fixture) while `SL_DATA.OLD_GL_AMT`, `AC_DATA` and `BILL_OS` summed the client-posted `amount` (25,821.60), so one voucher carried two old-gold values. **Fixed standalone:** `sales.ts` now values each exchange row ONCE through `resolveOldGoldValuation` (which reproduces the desktop grid's recomputed column 13) and uses that single figure for the detail, `OLD_GL_AMT`, the settlement, the old-gold ledger leg and `BILL_OS`; a write-set DB test (`sales.lifecycle.db.test.ts`) proves detail == header == ledger on a by-rate row whose raw posted amount differs | Header, ledger and detail use one valuation, chosen against the desktop grid source — done. **Follow-up (review):** the valuation now lives in `@datacare/core` (`web/packages/core/src/oldGold.ts`) and derives the fine the desktop way (three decimals, the net weight when no touch is given, `TR_SALE.cs:7903-7910`), so the N40 fixture stores 4.452 g and ₹25,822 (it stored 4.45 g and ₹25,810); the sale, sales-quotation and hallmark screens preview that same figure; the conversion weight is still taken from the screen (G89) |
| G84 | S2 | Hallmark sale on-screen preview totals | The desktop grid shows the same line amounts it saves (`unified/src/csharp/DataCareNext/TR_SALE.cs` CommPassTotal) | Found in the N40 browser journey: `web/apps/web/app/(app)/txn/hallmark-sale/page.tsx` previews metal from fine × rate and per-gram making only, so it omits west %, ghat amount, other charges and line discounts the writer applies; one voucher previewed ₹63,056.35 and saved ₹67,414.53 | The preview uses the writer's own line arithmetic from `@datacare/core`, or the screen shows the server's computed totals | N63 |
| G85 | S3 | Depth reachability counts any literal | — | Found while implementing N54: `project-memory/parity/gap_manifest.py` treats an API input field as reachable when its name appears anywhere in the web sources; `phone` and `pin` on `EnrollSchemeInput` counted as reachable only because a report-PDF column regex contained those words, while no screen could supply them | Reachability counts only values a screen sends to that route (form state, request bodies and query strings) | N83 |
| G86 | S2 | Provisioned tax masters name no ledger account | `unified/src/csharp/DataCareNext/Ac_Ledr.cs` Sales_Ledr and Purc_Ledr post the tax leg to the parent row's `D.TAX_AC` (`D.SR_NO = 0`); the seed company's GST codes carry accounts `00085`-`00087` (`desktop-conventions.json`) | Found reviewing G82: `web/apps/api/src/modules/ops/seedCompany.ts` provisions `TAX_MAST` with no `TAX_AC`. Sales and purchases still post through the literal fallbacks `GST` / `GSTINPUT`, but every flow that requires the master's account refuses on a web-provisioned company: E Invoice tax (`web/apps/api/src/modules/einvoice/eBillWriter.ts` requires code `10` `SR_NO = 0` to name the GST account), E Invoice automatic TCS above the threshold (code `20`), Other Income and Expenses by tax code (`web/apps/api/src/modules/purchase/otherIncome.ts`), the gold book and the repair tax rows | Provisioning names the tax ledger accounts under the D15 convention and the literal fallbacks are removed (one account per code, as the desktop posts) | N58, N59 |
| G87 | S2 | Stock In/Out line amount | `unified/src/csharp/DataCareNext/TR_INOUT.cs:4105-4117`: `ItAmt = Math.Round(fine × rate, 0)`, with the rate per gram, per 10 g (`RATE_TYPE` `1`), per kg (`K`) or per piece (`P`, on pieces) | Found reviewing N48: `web/apps/api/src/modules/stock/stockInout.ts` values a rated line as `fine × rate` at 2 decimals with no unit branch, so a per-10 g or per-kg rate is overstated 10× or 1,000× and a whole-rupee amount keeps paise. **Fixed standalone (2 October):** `web/packages/core/src/stockInoutAmount.ts` (`stockInoutItemAmount`) recomputes a line only when rate and fine are non-zero, by `RATE_TYPE` ('P' pieces, '1' per 10 g, 'K' per kg, else per gram), half to even at 0 decimals, otherwise the entered amount stands; `web/apps/api/src/modules/stock/stockInout.ts` takes the type as the desktop fills column 50 (saved or entered, else the scanned tag's `BAR_DETL.RATE_TYPE`, else `ITEM_MAST.RATE_TYPE`) and stores it; `web/apps/api/test/stockInoutAmount.routes.db.test.ts` covers each type, the tag source, reopen and an unchanged save. The Stock In/Out screen does not yet preview the computed amount (the form is at its size limit) | A rated line is valued with the desktop unit branch and whole-rupee rounding; a write-set test per rate type | N68 |
| G88 | S3 | Other Income/Expenses total under ALL_ROF_REMOVE | `unified/src/csharp/DataCareNext/TR_OTH_PURC.cs:5007-5026`: the total after TDS is `Math.Round(x, 2)` when `CO_SET.ALL_ROF_REMOVE = 'Y'`, otherwise `Math.Round(x, 0)` | Found reviewing N48: `web/apps/api/src/modules/purchase/otherIncome.ts` always rounds the total to whole rupees, so a company that removes round-off still gets it. **Fixed standalone (2 October):** the total after TDS is `roundHalfEven(x, 0)`, or `roundHalfEven(x, 2)` when the company's `allRoundingRemoved` setting is on; `web/apps/api/test/otherIncome.db.test.ts` saves the same voucher with the flag off (1,131) and on (1,130.70) and checks header, outstanding, party leg, balance and reopen | The total follows `ALL_ROF_REMOVE`; a DB test with the flag on and off | N33 |
| G89 | S3 | Old-metal conversion weight trusted from the screen | `unified/src/csharp/DataCareNext/TR_SALE.cs:7911-7942` derives the conversion weight (`cUrConWt`) from Con% and the fine weight before valuing the row | Found reviewing G83: `web/apps/api/src/modules/sales/sales.ts` values an exchange row on the client-posted `conversionWt`, so the stored `CON_WT` and amount depend on the screen's arithmetic | The writer derives `CON_WT` from `CON_PRC` and the fine weight with the desktop branches; kernel vectors per branch | N15 |
| G90 | S2 | Purchase and return tax rows use the parent group | `unified/src/csharp/DataCareNext/Ac_Tax.cs:122-132` writes purchase `TAX_DATA` from the component rows (`C.TAX_GROUP`, `C.TAX_PRC` at `C.SR_NO = 1/2/3`), as it does for sales (:92-102) | Found reviewing G82: `web/apps/api/src/modules/purchase/purchase.ts`, `web/apps/api/src/modules/purchase/purchaseReturn.ts` and `web/apps/api/src/modules/sales/salesReturn.ts` write `TAX_TYPE` from the parent's group on every row, so on a master with components a purchase stores `N` where the desktop stores `SGST`/`CGST`/`IGST`; the sale writer already uses the components. **Fixed standalone (2 October):** `web/apps/api/src/modules/shared/taxDataRows.ts` builds the main rows from the components for all four families (sale, purchase, purchase return, sales return): `SR_NO` 1/2 intra-state and 3 inter-state, `TAX_TYPE` and `TAX_PRC` from `C.SR_NO = 1/2/3`, a legacy single-row master keeping its own group; `web/apps/api/test/taxDataComponents.routes.db.test.ts` covers each family over HTTP, intra- and inter-state. Hallmark-charge rows are G91 | Every voucher family writes `TAX_TYPE` and `TAX_PRC` from the component rows; a write-set test per family | N15 |
| G91 | S3 | Hallmark-charge tax rows | `unified/src/csharp/DataCareNext/Ac_Tax.cs` writes the hallmark charge's `TAX_DATA` rows at `SR_NO` 10/20 (intra-state, `HM_TAX_AMT/2` each) or 30 (inter-state), from the components of `HM_TAX_CODE` (`C.SR_NO = 1/2/3`), with `NET_AMT = HM_AMT`, `DISC_AMT = 0` and `TOT_AMT = HM_AMT + HM_TAX_AMT`: sales :98-102, purchase :128-132, sales return :197-201 | Found fixing G90: `web/apps/api/src/modules/sales/sales.ts` and `web/apps/api/src/modules/purchase/purchase.ts` number the hallmark rows after the main rows (`SR_NO` 2-4), give them the main code's parent group, the main rows' `DISC_AMT` and `TOT_AMT`, and store no `HM_TAX_CODE` (the sale writes `''`); the sales-return and purchase-return writers carry no hallmark charge at all | The hallmark charge stores its tax code and writes its rows at `SR_NO` 10/20/30 from that code's components with the desktop amounts; a write-set test per family | N15 |
| G92 | S2 | Labour and fine tax rows ignore the tax master | `unified/src/csharp/DataCareNext/Ac_Tax.cs` `LbrWork_GST` :164-174 writes the labour invoice's rows from the components of `TAX_CODE` (`SR_NO` 1/2/3) and `LBR_TAX_CODE` (`SR_NO` 10/20/30); `Fine_Cut_GST` :289-293 writes fine sale and purchase rows at `SR_NO` 1/2/3 from the components of `TAX_CODE` | Found fixing G90: `web/apps/api/src/modules/sales/labourInvoice.ts` and `web/apps/api/src/modules/bullion/fineSalePurchase.ts` resolve no tax code: they write literal `CGST` at `SR_NO` 1 and `SGST` at 2 (the desktop order is the master's SGST then CGST), `IGST` at `SR_NO` 1 instead of 3, the labour part at `SR_NO` 5-6 instead of 10/20/30, a locally halved rate and no `TAX_CODE`. **Fixed standalone (2 October):** both writers resolve their codes through `taxPolicy.ts` (geography from the party's `AC_GST_TYPE`, a contradicting `interState` refused as the sale writer does), store `TAX_CODE` (and `LBR_TAX_CODE`) and write their rows through `gstTaxRows` at the desktop `SR_NO` (labour part 10/20/30), with equal unrounded halves and no row for a code without components; `web/apps/api/test/labourFineTaxRows.routes.db.test.ts` | Both families resolve their tax codes through `web/apps/api/src/modules/shared/taxPolicy.ts` and write their rows through `web/apps/api/src/modules/shared/taxDataRows.ts` at the desktop `SR_NO`; a write-set test per family | N15, N17 |
| G93 | S3 | Stock Out tag rate and amount | `unified/src/csharp/DataCareNext/TR_INOUT.cs:4550-4551` fills ItRate and ItAmt from the scanned tag's `BAR_DETL.ITM_RATE` and `ITM_AMT` (with column 50 from `RATE_TYPE`, :4558) before `CommPassTotal` recomputes the amount | Found fixing G87: `web/apps/api/src/modules/stock/stockInout.ts` takes a tag line's weights and rate type from the tag but not its rate or amount, so a tag issued without a typed rate is stored at rate 0 and amount 0 where the desktop stores the tag's rate and the recomputed amount | A tag line without a rate or amount takes them from the tag before the amount is computed; a write-set test | N68 |
| G94 | S3 | Lookup list outlives its field | The desktop's F1 help is a modal dialog: `unified/src/csharp/DataCareNext/TR_INOUT.cs:4438-4439` sets `DC_Main.HelpSelect = 1` and calls `MS_HELP.ShowDialog()`, so a help list never stays behind while the operator works in another field | Found on a CI run of PR #49, where the Tour Order journey's "Add stone row" click was intercepted by a stale `CALCS` list: `web/apps/web/components/LookupPicker.tsx` opened its list whenever a debounced search reply arrived, even after focus had moved on, and closed it only on Escape, a pick or an outside mouse click. The floating list covered the controls below it and, being an overlay to `web/apps/web/components/FormKeys.tsx`, kept every F-key inert. **Fixed standalone (2 October):** a reply opens the list only while its field has focus, and the list closes when focus moves to another control; `web/apps/web/test/browser.smoke.mjs` checks both on the sales item grid | A lookup list is open only while its field has focus; F-keys work as soon as the operator leaves it | N77 |
| G95 | S2 | Purchase documents print no HSN tax | `unified/src/csharp/DataCareNext/TR_KR_ISU.cs:5516-5520` prints a tax book's return with `PrRtnBillGst.RPT`, whose tax fields are the header's `PR_DATA.TAX_PRC`, `CGST_TAX`, `SGST_TAX` and `IGST_TAX` (`extraction_output/rpt_xml/PrRtnBillGst.xml`); neither `TR_KR_ISU` nor `TR_PURC` writes per-line tax amounts | Found in the N34 visual check: the shared bill body `web/apps/api/src/modules/documents/docChrome.ts:216-220` builds the HSN summary from per-line `ITM_CGST_AMT`/`ITM_SGST_AMT`, which purchase and purchase-return rows never carry, so a return with CGST 186 and SGST 186 in its totals prints 0.00 tax in every HSN row (seen on the printed return in the Chrome DevTools check) | The HSN summary of purchase and purchase-return prints takes its tax from the header (or `TAX_DATA`), as the desktop report does; a document test with a taxed return | N74 |
| G96 | S3 | Grid Enter stops at a read-only cell | The desktop grid walks Enter to the next editable cell and adds a row after the last one (`unified/src/csharp/DataCareNext/TR_KR_ISU.cs:3220` `TEXT_ENTRY_KeyDown`, the pattern of `TR_SALE.cs:12250-12320`) | Found in the N34 visual check: on `/txn/purchase-return` Enter in Making/g moves to the read-only Fine cell and focus stays put, because `web/apps/web/components/GridKeyboard.tsx:106-110` addresses cells by position and the page's cells carry no `data-grid-row`/`data-grid-column`; other positional grids (journal, MFG issue and receive, stock adjust) share it | Enter skips read-only cells and appends a row from the last editable cell; a keyboard test on a positional grid | N77 |
| G97 | S1 | Year Create dates and close/reopen | `unified/src/csharp/DataCareNext/MS_YEAR.cs:1035-1043` fills 01/04/yyyy – 31/03/yyyy+1 from the year code and `:1196`/`:1224` save `CL_DATE` as the year's closing date; the form has no close or reopen; `:1357-1363` copies masters only when a new company gets its first year (`NewCompCode`, `MS_COMPANY.cs:6196`) | Found in the 2026-10-26 E2E run: `web/apps/api/src/modules/masters/year.ts` read `closed: !!CL_DATE`, so every year showed "Closed"; Reopen set `CL_DATE` NULL and the year could post nothing (`assertFiscalDateTx`); Close wrote today's date; Create Year stored no closing date; Year Create in company 01 failed ("company clone source and target must differ") | Opening and closing dates derived by one shared rule (`@datacare/core` `fiscalYearDates`), no web close/reopen, masters copied only for a company's first year; DB test `masterSaveFidelity.db.test.ts` | N90 |
| G98 | S1 | Generic master save | `MS_GROUP.cs:1873-1883`, `MS_ITEM.cs:3245-3262`, `MS_ACCT.cs:7810-7851` store a blank numeric box as `Conversion.Val` (0) and a blank date mask as DBNull; `MS_GROUP.cs:1725,1802,1882` (same in `MS_ITEM`, `MS_ACCT`) stamp `MAIN_USER` on a new record and keep it on edit; `MS_ACCT.cs:7767` writes `LC_CODE = MLc_code` | Found in the 2026-10-26 E2E run: saving an item group, item or party with any numeric or date field blank failed (`invalid input syntax for type double precision: ""`); masters were saved without `MAIN_USER`; parties were saved with `LC_CODE` NULL, which print and document readers that select by location (`web/apps/api/src/modules/reports/reportBind.ts:159`, `web/apps/api/src/modules/sales/orderDoc.ts:69`) cannot find | Blank values bound by column type, server-side creator stamp, account location written on save; tests `masters.test.ts`, `masterSaveFidelity.db.test.ts` | N90 |
| G99 | S1 | Bank-mode receipt/payment settlement account | A desktop BANK REC / BANK PAY book's `BOOK_DETL` slot 1 is the bank account (`TR_CASH.cs:2629-2650`), so slot 1 is right for the book's own mode | Found in the 2026-10-26 E2E run: Payment, mode Bank, Bank A/c blank, in the provisioned generic PAYMENT book (slot 1 CASH) was saved as `BPAY` with its money leg on CASH; `finance.ts` fell back to slot 1 for every mode | A non-cash movement in a generic RECEIPT/PAYMENT book must name its bank account and may not name the cash account; DB tests in `financeBookFamily.db.test.ts` | N90 |
| G100 | S3 | Demo defaults on transaction screens | The desktop grids start empty and `TR_SALE.cs:14139-14142` defaults the cash party to `00045`, an account the company template carries | Found in the 2026-10-26 E2E run: nine screens started every new line with item `GOLD` (a demo item; company 07 had none) — fixed by N90; sales, hallmark sale and sales quotation still default the party to `WALKIN`, which web provisioning does not create | New lines start empty (done); the cash-party default follows the provisioned template once provisioning carries it | N58 |
| G101 | S3 | Book lists not limited to the workflow's book family | Each desktop menu opens its form on `CurBookHelp(<MAIN_BOOK>)` (`MDI_FORM.cs:7868` purchase, `:7969` sales return) | Found in the 2026-10-26 E2E run: Purchase Invoice and Tag Opening listed every book (Contra, Journal, Sales…); N90 limits Purchase and Sales Return; journal, tag/item opening, item lot, manufacturing, dhiran, fine JV, tour, hallmark sale, labour sale, batch receipt, bullion, fine in/out, tag weight difference and account opening still use an unfiltered `BookSelect` | Every screen offers only the MAIN_BOOK values its writer accepts | N62 |
| G102 | S2 | Screen totals rounded differently from the posted totals | The desktop grid shows the amounts it saves (`TR_PURC.cs:15474-15502` `BILL_TOTAL` rounds with `MsTotAmtRof`/`MsTaxRof`) | Found in the 2026-10-26 E2E run: purchase return previewed ₹20,865 and posted ₹20,865.23; a sale previewed ₹75,319 (balance due 319) and posted ₹75,318.75. Purchase, purchase return, sales, sale return, quotations, consignment, hallmark purchase/sale and estimate preview `Math.round(taxable + tax)` instead of the company rounding policy (`TOT_AMT_ROF`, `TAX_ROF`) | Previews use the writer's own totals arithmetic and rounding policy from `@datacare/core`, or show the server's computed totals | N63 |
| G103 | S3 | "Today" defaults use the UTC day | The desktop fills its date masks from the workstation's local `DateAndTime.Today` (`MS_YEAR.cs:1012`) | Found in the 2026-10-26 E2E run at 02:07 IST: new vouchers defaulted to 26 October (48 `new Date().toISOString().slice(0, 10)` defaults in 36 web files), Bank Reconciliation's month start became the previous month's last day, and Journal Voucher started with no date | One local-calendar helper (`web/apps/web/lib/localDate.ts`) for every default; unit test `localDate.test.ts` | N90 |

## 4. Decisions D23–D28

They continue document 11 §4 and use the same rules. All six were accepted by the owner on 1 October 2026: D25 and
D28 as the owner's instructions, D23, D24, D26 and D27 as recommended.

| ID | Decision and recommended position | Owner / deadline | Evidence |
|---|---|---|---|
| D23 | Requirement 19.2 (partial invoices). Never issue an incomplete legal document. When a template cannot be bound, refuse and list the missing fields — that satisfies "indicate which fields are missing". A watermarked draft preview is allowed for non-legal documents only | Product owner — accepted as recommended, 1 October 2026 | `web/apps/api/src/modules/reports/reportBindingContract.ts` refuses unbound templates |
| D24 | Requirement 21.1 (block on parity difference). Parity is enforced by verification and release gates (write-set database tests, the G5 differential, the release certifier), not by blocking live transactions; production records invariant failures and alerts | Product owner — accepted as recommended, 1 October 2026 | `GET /ops/invariants`, `web/apps/api/src/modules/ops/releaseCertification.ts` |
| D25 | Phase boundary. Phase 1 delivers desktop-equivalent business results and semantic layout (D20) and does not port desktop weaknesses (document 08). Phase 2 productizes. SaaS workflow changes ship behind per-tenant flags that default to desktop behaviour for migrated tenants and never change an accounting or stock result without a versioned, effective-dated decision. Accepted: owner instruction, 1 October 2026 | Product owner — accepted | [ADR-0004](../../project-memory/decisions/ADR-0004-two-phase-delivery.md) |
| D26 | Runtime and framework target. Upgrade now to the latest Next.js 15.5 security release with the React 19 patch release it requires, and move CI, images and `engines` to Node 24 LTS; rehearse Next.js 16 and Prisma 7 on a branch with the full parity suite; finish Prisma 7 before 19 November 2026 or record a dated risk acceptance | Product owner — accepted as recommended, 1 October 2026; platform lead implements it now (N86) | G72 |
| D27 | Route split timing. Strangler extraction: each N50 milestone moves its route family out of `web/apps/api/src/routes/txn.ts` into a Fastify plugin in its module, together with that family's schemas; no single large move; the exact route-universe test stays green throughout | Product owner — accepted as recommended, 1 October 2026; API lead, with N50 milestone 1 | G79 |
| D28 | Phase 2 timing. Nothing in Phase 2 starts, including the M0 decisions of document 14 §15, until Phase 1 is complete as defined in document 13 §1 and certified (N30). N86 and N88 are Phase 1 slices and continue. The plan enforces it: every Phase 2 slice depends on SP01, SP01 on N30, and `validate_plan.py` refuses a Phase 2 status other than `planned` while a Phase 1 slice it depends on is not `implemented-unverified` | Product owner — accepted (instruction), 1 October 2026 | [ADR-0004](../../project-memory/decisions/ADR-0004-two-phase-delivery.md) amendment |
| D29 | Device and provider testing during Phase 1. Phase 1 is built and tested against device **fakes** with recorded real-world sample inputs (scale frame, barcode scan, label output, GSP sandbox response) and against the desktop source, screenshots and transcripts as the oracle. Odoo's IoT documentation is a cited reference for device **protocols** only; what the ERP does with a reading comes from the desktop source. Real hardware and live providers are deferred to acceptance (N25); a fake must fail honestly in production (G33). | Product owner — accepted (instruction), 1 October 2026 | `web/apps/api/src/modules/integrations/deviceBridge.ts`, `scaleProtocol.ts`, `messaging.ts`; `einvoice.ts` `FakeIrnTransport` |
| D30 | Purchase Return source limits and stone rows. G47 asks for residual-limited source selection and `PR_IDTL` stone writes, but the desktop does neither: `TR_KR_ISU.cs:6845-6880` lists purchase vouchers with their full weights, `:6882-6975` imports full `ITM_NWT`/`ITM_GWT` for PURC RETURN (the `ADJ_NWT` residual applies only to the approval branch, `:6918`, `:6943-6950`), and `PR_IDTL` is only deleted (`:5035`, `:5385`), never inserted; `Ac_Stock.cs:774-778` posts `DM_DATA` from `PR_DETL` alone. Recommended: follow the desktop (no residual limit, no stone rows) and keep the web's existing over-return guard for tags (a returned tag must be in stock and on the named purchase); record a residual limit, if wanted, as a Phase 2 product rule. Rejected: implementing G47 as written, which changes desktop results | Product owner and desktop specialist, before N34 closes — **not accepted** | `web/apps/api/test/purchaseReturnEdit.routes.db.test.ts` |

## 5. Slices N83–N89

Each slice follows document 02 §4–§5 and the definition of done in document 11 §7.

#### N83 — Replay harness corrections and missing builders

Gap G69 · Parents P00-04, P01-03; X03, X06 · S2 · Size M · Start after N49

Steps:
1. Port the four corrections from the evaluation's corrected harness into
   `web/apps/api/integration/parity-replay-generic.mjs`: no `TAG_NO` for untagged lines (`N`), header discount,
   line other and labour amounts, receive-side rows with `CR_FINE`.
2. Add builders for KARIGAR ISSUE (050), KARIGAR RECEIPT (052), SALES ORDER (020) and ESTIMATE (032), using the
   request schemas from N50 where they exist.
3. For each builder, a captured desktop voucher replays to an identical write set, and a deliberately broken mapping
   fails.
4. The harness output lists every `NO_BUILDER` family, so coverage is visible in the G5 job.

Done when: no known input defect remains, the four families replay, and G5 reports coverage per family.

#### N84 — Next25 edition columns

Gap G70 · Parents P01-01, P13-01; X05, X32 · S2 · Size M · Start after N47

Steps:
1. Read the column types and defaults from the Next25 catalog (aggregate catalog queries only, no customer rows).
2. Add a forward migration with the 21 columns and register its checksum in `web/apps/api/src/modules/ops/migrationManifest.ts`.
3. Write the columns where the edition's desktop writer does (purchase tax split, `RATE_WITH`, rate-cut transfer
   and wastage fields, scheme bank account); otherwise preserve them on import and edit.
4. Include them in the migration ownership manifest (N78) and the differential comparison.

Done when: a Next25 purchase and rate cut write the same column set as the desktop, and imports keep the values.

#### N85 — Completion-register corrections

Gap G71 · Parents P00-01, P00-03; X01 · S3 · Size S · Start after N47

Steps:
1. Correct the 20 rows listed in the menu catalog in a new register revision, and regenerate the source hashes in
   `requirement-index.json` in the same pull request (the register is a hashed source).
2. Navigation: Style opens Models; "Members & Loyalty" is labelled as loyalty points; HuId Report uses
   `/reports/huid`.
3. `web/scripts/check-completion-register.mjs` checks every row's forms against the `MDI_FORM.cs` dispatch range and
   every web surface against the declared routes, using the same rules as `docs/tools/docs_check.py`.

Done when: register, navigation and catalog agree, and the check fails on a planted mismatch.

#### N86 — Supported runtime and framework baseline

Gap G72 · Parents P00-04, P12-05; X31, X34 · S1 · Size L · Start immediately

Steps:
1. Upgrade `next` to the latest 15.5 security release and `react`/`react-dom` to the patched version it requires;
   regenerate the lockfile; run every gate and the zero-mock browser suite.
2. Move `setup-node` in both workflows, `web/Dockerfile.web` and `engines` to Node 24 LTS; confirm the Playwright
   API image runs Node 24.
3. Add a dependency-advisory gate (audit against the lockfile, with reviewed exceptions by advisory identifier) to the
   static-gates CI job.
4. Upgrade Prisma to 7 with the full parity suite before 19 November 2026, when Prisma 6 security fixes end (D26).
   If it cannot land in time, record a dated risk acceptance.
5. Rehearse Next.js 16 on a branch with the full parity suite and record the result. If the 15.5 line stops
   receiving security fixes before Phase 1 is complete, move to Next.js 16 in this slice.

Done when: no installed package matches a known critical or high advisory, CI and images run Node 24, Prisma 7 is in
use (or a dated risk acceptance is recorded) before 19 November 2026, and the Next.js 16 rehearsal is recorded.

#### N87 — Documentation hub, lineage register and requirement traceability

Gaps G73, G74 · Parents P00-01, P14-06; X01, X34 · S3 · Size M · Start after N47

Steps (delivered in the pull request that added this document):
1. `docs/README.md` as the single entry point; the Desktop and Web handbooks; the generated menu catalog; the
   document register that classifies every Markdown file.
2. `lineage-register.json`, validated by `validate_plan.py`, with every earlier item and requirement.
3. `docs/tools/docs_check.py` in the blocking static-gates CI job.
4. The Phase 1 delivery plan ([document 13](13-phase1-delivery-plan.md)), the Phase 2 plan
   ([document 14](14-phase2-saas-plan.md)), agent skills under `.kiro/skills/` and `AGENTS.md`.

Remaining before acceptance: an independent reviewer compares one tab of the catalog per wave with the desktop
screens and tutorial keyframes. (The owner approved D23 and D24 on 1 October 2026.)

#### N88 — Module boundaries and static rules

Gap G79 · Parents P00-05, P02-01; X04, X07 · S2 · Size L · Start after N47; each route move is paired with an N50
milestone (D27)

Steps:
<!-- planned: web/apps/api/src/routes/index.ts -->
<!-- planned: web/apps/api/src/modules/shared/errors.ts -->

1. Route plugins: `web/apps/api/src/modules/<module>/routes.ts` registers its routes with their JSON Schemas (D16)
   and is mounted from `web/apps/api/src/routes/index.ts`; each N50 milestone moves its family (D27). The
   route-universe test (`web/apps/api/test/routePolicy.test.ts`) stays exact.
2. Typed error taxonomy in `web/apps/api/src/modules/shared/errors.ts`: 400 `invalid-request` with field paths, 401, 403, 404, 409
   version or idempotency conflict, 422 business rule, 429, 502/503 provider, 500 opaque with a correlation ID.
   It replaces the name-pattern mapping in `web/apps/api/src/routes/txn.ts:755-864`.
3. Shared voucher editor in `web/apps/web/lib/voucher/`: load, lossless hydrate, dirty tracking, save with version
   (D17) and idempotency key (D18), delete, print and a recent list with full identity. N63, N64 and N67 adopt it.
4. Static rules as CI ratchets: new or moved route and module files at most 800 lines, pages at most 600; import
   boundaries (`web/packages/core` has no I/O, pages call the API only through `web/apps/web/lib/api.ts`);
   `$queryRawUnsafe` and `$executeRawUnsafe` only inside the allow-listed helpers of
   `web/apps/api/src/modules/security/sql.ts`.

Done when: `web/apps/api/src/routes/txn.ts` shrinks with each moved family, the budgets and lint rules fail on planted violations, and
the screens moved to the shared editor pass unchanged-save tests.

#### N89 — Device-fake test harness and journeys

Gap G33 · Parents P02-03, P11-02, P11-03; X28 · S2 · Size M · Start after N49 · Decision D29

The fakes exist (`web/apps/api/src/modules/integrations/deviceBridge.ts`, `scaleProtocol.ts`, `messaging.ts`;
`web/apps/api/src/modules/einvoice/einvoice.ts` `FakeIrnTransport`). This slice makes them a documented, reusable
test harness so device-dependent screens are fully tested without hardware.

Steps:
1. Record real-world sample inputs as fixtures: a weighing-scale frame (9600 baud 8-N-1, and the 2400 baud 7-N-1
   fallback), a barcode scan string, a QR payload, a Code39/label render, and a GSP sandbox IRN response. Cite the
   device protocol (Odoo IoT documentation) and the desktop behaviour (`TR_TAG_OPBL.cs:7499-7590`,
   `UT_TAG_PRINT.cs`) in each fixture.
2. A browser `FakeSerialPort` and `FakeCamera` that feed those fixtures to `ScaleCapture.tsx` and `CameraCapture.tsx`
   in a Playwright journey, with no real device.
3. Zero-mock journeys that drive tag opening, tag print and labour billing through the fakes end to end, asserting
   the stored weights, labels and ledger match the desktop-derived expected values.
4. The production guard stays: an unconfigured provider or a disabled port fails, it never fakes a success (G33).

Done when: tag opening, tag print and a labour sale pass real-stack journeys using only the device fakes, and the
fixtures cite both the device protocol and the desktop source. Real-hardware acceptance remains N25.

#### N90 — Operator-journey defects found in the 2026-10-26 browser run

Gaps G95–G99, G103 (and the delivered parts of G100, G101) · Parents P03-04, P06-01, P10-05, P02-01; X07, X10, X16,
X25 · S1 · Size M · Start after N49

Found by operating the production build as a shop user in Chrome (DevTools MCP) on an isolated database: a company
provisioned through Admin → Provision, masters created through the screens, then J01/J02/J04/J12 (purchase, purchase
return, supplier payment, retail sale with mixed tender and edit, receipt, contra, journal, day book, ledger, trial
balance).

Steps (done in this slice):
1. Year Create follows `MS_YEAR`: dates from one shared rule (`@datacare/core` `fiscalYearDates`), no web
   close/reopen, masters copied only for a company's first year, `OLD_METHOD 'Y'` and `MAIN_USER` written (G97).
2. The generic master writer binds blank values by column type (numeric 0, date NULL), stamps `MAIN_USER` from the
   session and keeps it on edit, and writes the party's `LC_CODE` (G98).
3. A non-cash receipt or payment in a generic RECEIPT/PAYMENT book must name its bank account and may not settle to
   the cash account; desktop-layout books keep slot 1 (G99).
4. Purchase and purchase-return prints take HSN tax from the header when lines carry none (G95); grid Enter walks to
   the next editable cell and appends after the last (G96).
5. New transaction lines start with no item (G100, part); Purchase and Sales Return offer only their book family
   (G101, part); every "today" default uses the local calendar day (G103).

Remaining elsewhere: the `WALKIN` party default (G100, N58), the other unfiltered book lists (G101, N62) and preview
totals that differ from posted totals (G102, N63).

Done when: the tests named in the gap rows pass, the real-stack suite (including the purchase-return journey's
empty-line and Enter checks) passes with zero mocks, and the same journeys repeated in the browser show the fixed
behaviour.


## 6. Status corrections

| Item | Before | Now |
|---|---|---|
| X18 `currentFinding` (CR-01) | Tag transfer remains contained | Tag cancel, transfer and split released by N18 and N19; weight difference still contained. Recorded as `currentFindingCorrection` |
| X15 `currentFinding` (CR-02) | Credit-note IRN assumes the document exists | E CRNT and E INVOICE create/edit/delete/print lifecycle exists (N16); provider and desktop acceptance remain. Recorded as `currentFindingCorrection` |
| Completion register | 198 rows mapped | Corrected by N85: 26 rows (the 20 listed plus 6 found by the catalog-agreement check); 193 implemented-unverified and 5 absent (Card Rec, Tour Sales, Loan Intrest, Dhrn Os Letter, Cust Entry); `register:check` blocks disagreement |
| N87 | — | implemented-unverified, evidence in this change |
| N86 | planned | in-progress: Next.js 15.5.27, React 19.0.8, Node 24 in CI and images, advisory gate; critical and high advisories 7/35 → 0/0. Prisma 7 and the Next.js 16 rehearsal remain → **implemented-unverified**: Prisma 7.10.0 with the PostgreSQL driver adapter (one @datacare/db boundary, ESM prisma-client generator, prisma.config.ts), three Prisma 7 raw-query behaviour changes adapted without changing business results, Vitest 4.1.11 clears the last moderate advisory, a blocking `runtime:check` gate, and a recorded Next.js 16 rehearsal (`web/security/next16-rehearsal.json`, status regressions-found: mocked-browser smoke regresses on /txn/tag-opening, so production stays on patched 15.5). Full isolated DB suite 309 files/3446 tests green; Chrome DevTools visual pass against the Prisma 7 stack |
| N86 (2026-10-26) | implemented-unverified | Still implemented-unverified: the advisory gate turned red on unchanged dependencies and PR #55 patched it (next 15.5.28, vitest 4.1.12/vite 6.4.5, zod 4.6.7, msal-node 7.1.1 override) to 0/0/0/0; Next.js 16.4.3 rehearsal re-run and passing |
| N90 | — | implemented-unverified, evidence in this change (browser-run defects G95–G99, G103, parts of G100/G101) |
| Decisions D23, D24, D26, D27 | Recommended, awaiting approval | Accepted as recommended by the owner, 1 October 2026; D28 added (Phase 2 waits for Phase 1) |

## 7. Documentation hub

- **Entry point:** [`docs/README.md`](../README.md). Desktop knowledge is in
  [`docs/handbook/desktop/`](../handbook/desktop/README.md), web knowledge in
  [`docs/handbook/web/`](../handbook/web/README.md), and the per-menu join of both in the
  [menu catalog](../handbook/menu-catalog.md).
- **No historical file was moved or rewritten.** Tests, scripts, evidence manifests and other documents cite them by
  path. The [document register](../handbook/doc-register.md) labels each one current, reference, historical,
  superseded, evidence or generated, with its successor.
- **Enforcement:** `python3 docs/tools/docs_check.py` fails when a Markdown file is unclassified, a catalog row
  cites a missing form, dispatch line, page, route or plan identifier, a hub link is broken, a credential-shaped
  string appears, or a generated view is stale. It runs in the static-gates CI job.

## 8. Keeping this record current

- New gaps continue at **G84** (here or in document 11, keeping numbers unique); new slices continue at **N90**, Phase 2
  slices at **SP25**, decisions at **D30**.
  Update the thresholds in `validate_plan.py` in the same pull request.
- When an item in `lineage-register.json` closes, change its disposition to `closed` with evidence; keep the row.
- Run `python3 docs/master-parity-plan-2026-09-29/validate_plan.py`, `python3 docs/tools/docs_check.py` and
  `pnpm docs:refs` before merging.
