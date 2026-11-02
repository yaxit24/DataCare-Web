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
| G84 | S2 | Hallmark sale on-screen preview totals | The desktop grid shows the same line amounts it saves (`unified/src/csharp/DataCareNext/TR_SALE.cs` CommPassTotal totals each line as item+labour+other into column 35) | Found in the N40 browser journey: `web/apps/web/app/(app)/txn/hallmark-sale/page.tsx` previewed metal + per-gram making only, so it omitted other charges; one voucher previewed ₹63,056.35 and saved ₹67,414.53. N93 makes every document preview compose the line net as the server does — `@datacare/core` `lineNet({ metal, labour, other })` — so the preview matches the posted `SL_DETL.NET_AMT` | Every document preview totals the line net the server posts (metal + gross labour + other), proven by a DB test pinning the server rule — done (N93) | N93 |
| G85 | S3 | Depth reachability counts any literal | — | Found while implementing N54: `project-memory/parity/gap_manifest.py` treats an API input field as reachable when its name appears anywhere in the web sources; `phone` and `pin` on `EnrollSchemeInput` counted as reachable only because a report-PDF column regex contained those words, while no screen could supply them | Reachability counts only values a screen sends to that route (form state, request bodies and query strings) | N83 |
| G86 | S2 | Provisioned tax masters name no ledger account | `unified/src/csharp/DataCareNext/Ac_Ledr.cs` Sales_Ledr and Purc_Ledr post the tax leg to the parent row's `D.TAX_AC` (`D.SR_NO = 0`); the seed company's GST codes carry accounts `00085`-`00087` (`desktop-conventions.json`) | Found reviewing G82: `web/apps/api/src/modules/ops/seedCompany.ts` provisions `TAX_MAST` with no `TAX_AC`. Sales and purchases still post through the literal fallbacks `GST` / `GSTINPUT`, but every flow that requires the master's account refuses on a web-provisioned company: E Invoice tax (`web/apps/api/src/modules/einvoice/eBillWriter.ts` requires code `10` `SR_NO = 0` to name the GST account), E Invoice automatic TCS above the threshold (code `20`), Other Income and Expenses by tax code (`web/apps/api/src/modules/purchase/otherIncome.ts`), the gold book and the repair tax rows | Provisioning names the tax ledger accounts under the D15 convention and the literal fallbacks are removed (one account per code, as the desktop posts) | N58, N59 |
| G87 | S2 | Stock In/Out line amount | `unified/src/csharp/DataCareNext/TR_INOUT.cs:4105-4117`: `ItAmt = Math.Round(fine × rate, 0)`, with the rate per gram, per 10 g (`RATE_TYPE` `1`), per kg (`K`) or per piece (`P`, on pieces) | Found reviewing N48: `web/apps/api/src/modules/stock/stockInout.ts` values a rated line as `fine × rate` at 2 decimals with no unit branch, so a per-10 g or per-kg rate is overstated 10× or 1,000× and a whole-rupee amount keeps paise. **Fixed standalone (2 October):** `web/packages/core/src/stockInoutAmount.ts` (`stockInoutItemAmount`) recomputes a line only when rate and fine are non-zero, by `RATE_TYPE` ('P' pieces, '1' per 10 g, 'K' per kg, else per gram), half to even at 0 decimals, otherwise the entered amount stands; `web/apps/api/src/modules/stock/stockInout.ts` takes the type as the desktop fills column 50 (saved or entered, else the scanned tag's `BAR_DETL.RATE_TYPE`, else `ITEM_MAST.RATE_TYPE`) and stores it; `web/apps/api/test/stockInoutAmount.routes.db.test.ts` covers each type, the tag source, reopen and an unchanged save. The Stock In/Out screen does not yet preview the computed amount (the form is at its size limit) | A rated line is valued with the desktop unit branch and whole-rupee rounding; a write-set test per rate type | N68 |
| G88 | S3 | Other Income/Expenses total under ALL_ROF_REMOVE | `unified/src/csharp/DataCareNext/TR_OTH_PURC.cs:5007-5026`: the total after TDS is `Math.Round(x, 2)` when `CO_SET.ALL_ROF_REMOVE = 'Y'`, otherwise `Math.Round(x, 0)` | Found reviewing N48: `web/apps/api/src/modules/purchase/otherIncome.ts` always rounds the total to whole rupees, so a company that removes round-off still gets it. **Fixed standalone (2 October):** the total after TDS is `roundHalfEven(x, 0)`, or `roundHalfEven(x, 2)` when the company's `allRoundingRemoved` setting is on; `web/apps/api/test/otherIncome.db.test.ts` saves the same voucher with the flag off (1,131) and on (1,130.70) and checks header, outstanding, party leg, balance and reopen | The total follows `ALL_ROF_REMOVE`; a DB test with the flag on and off | N33 |
| G89 | S3 | Old-metal conversion weight trusted from the screen | `unified/src/csharp/DataCareNext/TR_SALE.cs:7911-7942` derives the conversion weight (`cUrConWt`) from Con% and the fine weight before valuing the row | Found reviewing G83: `web/apps/api/src/modules/sales/sales.ts` valued an exchange row on the client-posted `conversionWt`, so the stored `CON_WT` and amount depended on the screen's arithmetic. N96 added `@datacare/core` `oldGoldConversionWeight` (Con% > 100 → `round(fine × Con%/100, 3)`; 0 < Con% ≤ 100 → `round(fine/Con%×100 − fine, 3) + fine`; Con% 0 → the legacy supplied weight), used by `valueOldGoldLine`/`oldGoldBasisWeight` so the writer and every preview derive and store `CON_WT` server-side; a posted `conversionWt` is ignored when a `CON_PRC` is given | The writer derives `CON_WT` from `CON_PRC` and the fine weight with the desktop branches; kernel vectors per branch and a DB write-set assertion — done (N96) | N96 |
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
| G100 | S3 | Demo defaults on transaction screens | The desktop grids start empty and `TR_SALE.cs:14139-14142` defaults the cash party to `00045`, an account the company template carries | Found in the 2026-10-26 E2E run: nine screens started every new line with item `GOLD` (a demo item; company 07 had none) — fixed by N90; sales, hallmark sale and sales quotation still default the party to `WALKIN`, which web provisioning does not create | New lines start empty (done); **CORE-CYCLE BLOCKER confirmed in the 2026-10-28 full browser review**: a logged-in operator on the seeded demo company entered a 10 g gold line (live totals correct: Net 60,916, Tax 3% 1,827.48, Total 62,743.48) and Save returned HTTP 400 `account not found for tax policy: WALKIN` — `seedCompany` provisions no walk-in party (`WALKIN`/`00045`), so the default retail sale cannot post on a fresh company. Fixed by N115: seed the `WALKIN` walk-in customer (debtor group `03`, GST type `L`) so the screen default resolves and the tax policy succeeds | N58, N115 |
| G101 | S3 | Book lists not limited to the workflow's book family | Each desktop menu opens its form on `CurBookHelp(<MAIN_BOOK>)` (`MDI_FORM.cs:7868` purchase, `:7969` sales return, `:9527`/`:9539` dhiran) | Found in the 2026-10-26 E2E run: Purchase Invoice and Tag Opening listed every book (Contra, Journal, Sales…). N90 limited Purchase and Sales Return; N98 the three Dhiran screens; N99 the Journal (JOURNAL), Item Lot (ITEM LOT) and Tour/Approval Issue (APPROVAL ISSUE) screens — each browser- or match-confirmed against the provisioned book. Still unfiltered: tag/item opening, manufacturing, fine JV, hallmark sale, labour sale, batch receipt, bullion, fine in/out, tag weight difference and account opening — most need their MAIN_BOOK book provisioned first (LABOUR WORK, FINE JV/SALE, BULLION, TAG OPENING are not seeded) or a per-writer confirmation | Every screen offers only the MAIN_BOOK values its writer accepts; purchase/sales-return (N90), the three dhiran screens (N98) and journal/item-lot/tour (N99) done, the rest under N62 | N62 |
| G102 | S2 | Screen totals rounded differently from the posted totals | The desktop grid shows the amounts it saves (`TR_PURC.cs:15474-15502` `BILL_TOTAL` rounds with `MsTotAmtRof`/`MsTaxRof`) | Found in the 2026-10-26 E2E run: purchase return previewed ₹20,865 and posted ₹20,865.23; a sale previewed ₹75,319 (balance due 319) and posted ₹75,318.75. The nine document screens previewed `Math.round(taxable + tax)` instead of the company rounding policy (`TOT_AMT_ROF`, `TAX_ROF`). N92 moved `resolveRoundingPolicy` into `@datacare/core`, surfaced the company flags on `/me`, and made purchase, sales, hallmark sale, sale return, purchase return, consignment purchase, estimate and both quotations preview with `billTotals(input, policy)` — the same arithmetic and rounding the server posts | Previews use the writer's totals arithmetic and the company rounding policy from `@datacare/core` — done (N92) | N92 |
| G103 | S3 | "Today" defaults use the UTC day | The desktop fills its date masks from the workstation's local `DateAndTime.Today` (`MS_YEAR.cs:1012`) | Found in the 2026-10-26 E2E run at 02:07 IST: new vouchers defaulted to 26 October (48 `new Date().toISOString().slice(0, 10)` defaults in 36 web files), Bank Reconciliation's month start became the previous month's last day, and Journal Voucher started with no date | One local-calendar helper (`web/apps/web/lib/localDate.ts`) for every default; unit test `localDate.test.ts` | N90 |
| G104 | S2 | Typed lookup codes not resolved | `unified/src/csharp/DataCareNext/TR_PURC.cs:14619-14628` `tAcCode_KeyDown` looks the typed code up in AC_MAST on Enter and fills the party (F1 help opens only when nothing matches); `TR_SALE.cs:17340` is the same | Found in the 2026-10-26 E2E run: `web/apps/web/components/LookupPicker.tsx` ran its `onPick` effects only when a row was chosen from the open list, so a supplier typed and tabbed past (or Enter pressed before the list opened) left the name blank and Inter-state "No", and the purchase was refused (`interState does not match the persisted supplier GST type`) | A typed value that matches one lookup code exactly is picked on Enter and when the field is left, running the screen's pick effects; browser re-check on Purchase | N90 |
| G105 | S2 | Stock In / Out unusable on a provisioned company | The desktop ships `INWORD` / `OUTWORD` books and every location carries a branch account (`MS_LOCT.cs:3458` binds `LOCT_MAST.AC_CODE`); `TR_INOUT.cs:5268-5282` posts the signed metal rows against that branch account and `web/apps/api/src/modules/stock/stockInout.ts:19-23,344-355` reads `LOCT_MAST.AC_CODE` for the location account | Found in the 2026-10-26 E2E run: on provisioned company 07 the Stock In Book select was empty and Save stayed disabled — `web/apps/web/components/StockInoutForm.tsx:230,422` filters `BookSelect` to `mainBook` `INWORD`/`OUTWORD`, but `web/apps/api/src/modules/ops/seedCompany.ts` creates 22 book families without either and seeds `LOCT_MAST` with no `AC_CODE`, so even with a book the metal/ledger rows (`stockInout.ts:760,807` filter on `locationAccount.acCode`) would be dropped | Provisioning creates the `INWORD` and `OUTWORD` books and a branch stock-in-hand account wired to `LOCT_MAST.AC_CODE`, so Stock In/Out opens, saves, and posts a reconciling metal + ledger entry; DB test on the isolated database | N91 |
| G106 | S2 | Sales previews netted the line discount and added the ghat amount into the line total | The desktop line total (`TR_SALE.cs` CommPassTotal, column 35) is item + labour + other; the per-line discount and ghat amount are stored on their own columns (`SL_DETL.DISC_AMT`/`GHT_AMT`) and never fold into the line net — the server matches it (`web/apps/api/src/modules/sales/sales.ts` `calcLineNet({ metal, labour, other })`, confirmed by a DB test posting a line with a 10% discount and a ₹250 ghat that stores `NET_AMT` = metal + gross labour + other) | Found resolving G84: `web/apps/web/app/(app)/txn/sales/page.tsx` and `web/apps/web/app/(app)/txn/sales-quotation/page.tsx` previewed `recalcLine(...).totalAmount`, which nets the line discount off labour and adds the ghat amount — so a line carrying a `Line Disc %` or `Ghat Amt` (both editable grid columns) previewed a total the server does not post | The sales and sales-quotation previews compose the line net as the server does (`lineNet({ metal, labour, other })`), leaving the discount and ghat on their own columns; a DB test pins the server rule (`web/apps/api/test/sales.lifecycle.db.test.ts`) — done (N93) | N93 |
| G107 | S2 | No static rule rejected a request value interpolated into raw SQL | `project-memory/parity/SECURITY-REVIEW.md` §6: values reach `$queryRawUnsafe`/`$executeRawUnsafe` only as `$n` parameters and only identifiers/fragments are interpolated — but "there is no general static rule that parses all SQL templates and rejects unbound value interpolation", so a future call could reopen SQL injection | A new AST gate (`web/scripts/sql-interpolation.mjs`, wired into `web/scripts/lint-workspace.mjs`) inspects the first argument of every raw-unsafe call and flags any `${…}` that reads a value out of the HTTP request/input (`req`/`request`/`body`/`query`/`params`/`input` as a value), including nested fragment templates; `$n`-bind indices, identifier sanitizers and SQL fragments pass. Zero findings on the current tree; a planted `req.body` interpolation fails the gate | A static lint gate rejects a request/input value interpolated into a raw-SQL template; a test proves it flags a planted violation and passes the vetted forms — done (N94) | N94 |
| G108 | S2 | No budget stopped large source files from growing | G79 records `web/apps/api/src/routes/txn.ts` at 8,558 lines and nine modules over 1,500; N88 reduces them by extracting per-module route plugins and a shared voucher editor, but nothing prevented them from growing further meanwhile | A size-budget ratchet (`web/scripts/check-size-budget.mjs`, baseline `web/parity/size-budget.json`, wired into CI next to the depth gate) freezes each over-cap file's line count as a ceiling that may only fall and caps every new source file at 1,500 lines; `--audit` re-derives counts and `--write` only tightens, so a raised ceiling is a reviewed baseline diff. Passes the current tree (20 ceilings); a planted +5-line growth and a new 1,600-line file both fail the gate | A per-file line-count ceiling that may only fall, with a default cap on new files, enforced in CI; a test proves it flags growth and a new over-cap file — done (N95) | N95 |
| G109 | S2 | Dhiran (pledge loan) unusable on a provisioned company | The desktop opens Pledge Loan Issue on MAIN_BOOK `DHIRAN ISSUE` and Pledge Receipt on `DHIRAN RECEIPT` (`unified/src/csharp/DataCareNext/MDI_FORM.cs:9527,9539` `Dhiran_Form`); the issue writes `DHRN_ISU_DATA`, the receipt `DHRN_REC_DATA` | Found operating the production build (2026-10-27): the Pledge Loan Issue screen's book select offered no Dhiran book (`web/apps/api/src/modules/ops/seedCompany.ts` provisioned 24 book families with no DHIRAN book), so the operator could not post a pledge loan — the same class as the Stock In/Out gap (G105) | Provisioning creates the `DHI` (DHIRAN ISSUE) and `DHR` (DHIRAN RECEIPT) books routed to `DHRN_ISU_DATA`/`DHRN_REC_DATA`, so Pledge Loan Issue/Receipt open and post; a seed-completeness DB assertion — done (N97) | N97 |
| G110 | S2 | Labour Sale and Fine Settlement unusable on a provisioned company | The desktop opens Labour Sale on MAIN_BOOK `LABOUR WORK` (`unified/src/csharp/DataCareNext/MDI_FORM.cs:8325`) and Fine Settlement on `FINE SALE`/`FINE PURC` (`:8505`/`:8493`); the labour writer routes to `LBR_DATA`, fine settlement to `CUT_DATA` | Found continuing the G101 book-filter review: `web/apps/api/src/modules/ops/seedCompany.ts` provisioned no `LABOUR WORK`, `FINE SALE` or `FINE PURC` book, so those screens had no book to select (the same class as the Stock In/Out and Dhiran gaps, G105/G109), and the screens could not be book-filtered either | Provisioning creates the `LBR` (LABOUR WORK → LBR_DATA), `FSL` (FINE SALE → CUT_DATA) and `FPR` (FINE PURC → CUT_DATA) books with their control slots; a seed-completeness DB assertion, and the Labour Sale book list filtered to `LABOUR WORK` — done (N100) | N100 |
| G111 | S2 | Tag Opening unusable on a provisioned company | Tag Opening (TR_TAG_OPEN) opens tag stock: it writes `BAR_DATA` and a positive `MAIN_STOCK` with no ledger leg (`web/apps/api/src/modules/stock/stockVoucherLifecycle.ts:258-276` empty `AC_DATA` lines) on a book routed to `BAR_DATA` | Found continuing the G110 provisioning review: `web/apps/api/src/modules/ops/seedCompany.ts` provisioned no Tag Opening book, so the Tag Opening screen had no book to select on a provisioned company (the Stock In/Out, Dhiran, Labour/Fine class — G105/G109/G110) | Provisioning creates the `TOP` (TAG OPENING → `BAR_DATA`) book as a ledger-less stock book (empty slots, like WH QUOT); a seed-completeness DB assertion, and the Tag Opening book list filtered to `TAG OPENING` — done (N101) | N101 |
| G112 | S2 | Fine In/Out unusable on a provisioned company | Fine In/Out (TR_FINE_INOUT) is a pure metal movement: it writes `INOUT_DATA` + signed `MAIN_STOCK` with no money ledger (`web/apps/api/src/modules/inout/fineInout.ts:299` empty `AC_DATA` lines), stamped `BOOK_NAME 'FINE INOUT'` | Found continuing the G111 provisioning review: `web/apps/api/src/modules/ops/seedCompany.ts` provisioned no Fine In/Out book, so the Fine In/Out screen had no book to select on a provisioned company (the Stock In/Out, Dhiran, Labour/Fine, Tag Opening class — G105/G109/G110/G111) | Provisioning creates the `FIO` (FINE INOUT → `INOUT_DATA`) book as a ledger-less metal-movement book (empty slots); a seed-completeness DB assertion, and the Fine In/Out book list filtered to `FINE INOUT` — done (N102) | N102 |
| G113 | S2 | Bullion Booking unusable on a provisioned company | Bullion Booking (TR_BUL_BOOKING, `MDI_FORM.cs:8171` BUL SALE / `:8183` BUL PURC) books bulk fine metal at a locked rate: the header lands in `BUL_DATA` and a balanced Dr cash / Cr bullion-payable entry in `AC_DATA` (`web/apps/api/src/modules/bullion/bullion.ts`) | Found continuing the G112 provisioning review: `web/apps/api/src/modules/ops/seedCompany.ts` provisioned no Bullion Booking book, so the Bullion Booking screen had no book to select on a provisioned company (the Stock In/Out, Dhiran, Labour/Fine, Tag Opening, Fine In/Out class — G105/G109/G110/G111/G112) | Provisioning creates the `BUL` (BUL SALE → `BUL_DATA`) book; the writer resolves its ledger accounts (`BULLION`/`CASH`) from the payload, so the standard slots are nominal; a seed-completeness DB assertion, and the Bullion Booking book list filtered to `BUL SALE` — done (N103) | N103 |
| G114 | S2 | Item Opening unusable on a provisioned company | Item Opening (TR_ITM_OPBL, `MDI_FORM.cs:7701` CurBookHelp("OPSTK")) opens non-tag item stock: it writes `ITM_OPBL` + positive `MAIN_STOCK` with no money ledger (empty `AC_DATA`) on a book routed to `BAR_DATA` | Found continuing the G113 provisioning review: `web/apps/api/src/modules/ops/seedCompany.ts` provisioned no Item Opening book, so the Item Opening screen had no book to select on a provisioned company (the Stock In/Out, Dhiran, Labour/Fine, Tag Opening, Fine In/Out, Bullion class) | Provisioning creates the `IOP` (OPSTK → `BAR_DATA`) book as a ledger-less stock book (empty slots); a seed-completeness DB assertion, and the Item Opening book list filtered to `OPSTK` — done (N104) | N104 |
| G115 | High | Labour | `unified/src/csharp/DataCareNext/Ac_Ledr.cs:1203` | `web/apps/api/src/modules/sales/labourInvoice.ts` | The labour-income leg must credit the book's BOOK_DETL slot SR_NO 6 (desktop joins `B.SR_NO = 6` under MAIN_BOOK `LABOUR WORK`), not a literal `LABOUR` account that exists only in the provisioning seed and is absent on a migrated company. | N106 |
| G116 | Med | Sales return | `unified/src/csharp/DataCareNext/Ac_Ledr.cs` (SALES RETURNE book legs) | `web/apps/api/src/modules/sales/salesReturn.ts` | The control/revenue, cash and round/kasar accounts must come from the book's BOOK_DETL slots (SR_NO 1/2/3), not literal `SALES`/`CASH`/`ROUNDOFF`/`KASAR` placeholders that only the provisioning seed carries. | N107 |
| G117 | Med | Purchase return | `unified/src/csharp/DataCareNext/Ac_Ledr.cs` (PURC RETURN book legs) | `web/apps/api/src/modules/purchase/purchaseReturn.ts` | The control/expense, cash and round/kasar accounts must come from the book's BOOK_DETL slots (SR_NO 1/2/3), not literal `PURCHASE`/`CASH`/`ROUNDOFF`/`KASAR` placeholders. | N108 |
| G118 | Med | Dhiran | `unified/src/csharp/DataCareNext/Ac_Ledr.cs:1066` | `web/apps/api/src/modules/dhrn/dhrn.ts` | The dhrn funding (cash) account must come from the book's BOOK_DETL slot 2 (desktop joins `B.SR_NO = 2` under MAIN_BOOK `DHIRAN ISSUE`/`DHIRAN RECEIPT`), not a literal `CASH` that only the seed carries. | N109 |
| G119 | Med | Sales | `unified/src/csharp/DataCareNext/Ac_Ledr.cs` (SALES book legs) | `web/apps/api/src/modules/sales/sales.ts` | The sale cash and round/kasar accounts must come from the book's BOOK_DETL slots (2/3), not literal `CASH`/`ROUNDOFF`/`KASAR` initializers. | N110 |
| G120 | Med | Purchase | `unified/src/csharp/DataCareNext/Ac_Ledr.cs` (PURCHASE book legs) | `web/apps/api/src/modules/purchase/purchase.ts` | The purchase cash and round/kasar accounts must come from the book's BOOK_DETL slots (2/3), not literal `CASH`/`ROUNDOFF`/`KASAR` initializers. | N111 |
| G121 | Med | Bullion | `unified/src/csharp/DataCareNext/Ac_Ledr.cs` (BUL SALE book legs) | `web/apps/api/src/modules/bullion/bullion.ts` | The bullion payable and funding accounts must come from the booking book's BOOK_DETL slots (1/2), not literal `BULLION`/`CASH`. | N112 |
| G122 | Med | Order cancel | `unified/src/csharp/DataCareNext/MDI_FORM.cs:8629` | `web/apps/api/src/modules/ops/seedCompany.ts` | Provisioning must create the ORDER CANCEL book (CO_BOOK ORC, SL_ORD_ADJ) so a fresh company can cancel/refund a sales order; the cancel writer targets book ORC. | N113 |
| G123 | Med | Fine settlement | `unified/src/csharp/DataCareNext/Ac_Ledr.cs` (CUT_DATA FSL/FPR legs) | `web/apps/api/src/modules/bullion/fineSalePurchase.ts` | The fine-sale/fine-purchase metal account must come from the FSL/FPR book's BOOK_DETL slot 1, not literal `FINESALE`/`FINEPURC`. | N114 |
| G124 | High | Sales | `unified/src/csharp/DataCareNext/TR_SALE.cs:14141` (cash party `00045` from the company template) | `web/apps/api/src/modules/ops/seedCompany.ts` | A fresh/provisioned company must carry the walk-in party the sales/hallmark-sale/sales-quotation screens default to, so the core retail sale posts without the operator first creating an account (the live review hit HTTP 400 on the default sale). | N115 |
| G125 | High | Sales / documents | `unified/src/csharp/DataCareNext/SaleBillA4Gst.rpt` | `web/apps/api/src/routes/txn.ts` `GET /sales/:vchNo/print`, `web/apps/api/src/modules/sales/salesBill.ts` | The retail sale must produce a printable Tax Invoice (the single highest-value desktop document); every sale needs a bill. | N116 |
| G126 | Med | Purchase / documents | `unified/src/csharp/DataCareNext/PurcBillA4Gst.rpt` | `web/apps/api/src/routes/txn.ts` `GET /purchases/:vchNo/print` | The purchase must produce a printable supplier bill (the purchase counterpart of the Tax Invoice). | N117 |
| G127 | Med | Sales return / documents | `unified/src/csharp/DataCareNext/SaleRtnBillA4Gst.rpt` | `web/apps/api/src/routes/txn.ts` `GET /sales-returns/:vchNo/print`, `web/apps/api/src/modules/sales/saleReturnBill.ts` | The sales return must produce a printable credit note (returned goods + value credited to the customer). | N118 |
| G128 | Med | Contra / documents | `unified/src/csharp/DataCareNext/ContraVch.rpt` | `web/apps/api/src/routes/txn.ts` `GET /contra/:vchNo/print`, `web/apps/api/src/modules/finance/contraVoucher.ts` | The contra (bank<->cash transfer) must produce a printable voucher showing the from/to accounts and amount. | N119 |
| G129 | Med | Journal / documents | `unified/src/csharp/DataCareNext/JournalVch.rpt` | `web/apps/api/src/routes/txn.ts` `GET /journal/:vchNo/print`, `web/apps/api/src/modules/finance/contraVoucher.ts` `journalVoucherHtml` | The journal voucher must produce a printable multi-line Dr/Cr entry (Particulars, Debit, Credit, totals, narration). | N120 |
| G130 | Med | Fine sale/purchase / lifecycle | `unified/src/csharp/DataCareNext/TR_FINE_SL_PR.cs:4288` | `web/apps/api/src/routes/txn.ts` `GET /fine-sale/:vchNo`, `web/apps/api/src/modules/bullion/fineSalePurchase.ts` `getFineSalePurchase` | The fine sale/purchase must be reopenable (read CUT_DATA + CUT_DETL back into the form) so the operator can reload a posted voucher. | N121 |
| G131 | Med | Ledger adjust & employee JV / lifecycle | `unified/src/csharp/DataCareNext/TR_EMP_JV.cs`, ledger-adjust form | `web/apps/api/src/routes/txn.ts` `GET/PUT /ledger-adjust/:vchNo`, `GET/PUT /employee-jv/:vchNo` | Both vouchers must be reopenable and editable (the reader/editor already existed in the modules; only the routes were missing). | N122 |
| G132 | High | Card Rec (MISSING workflow) | `unified/src/csharp/DataCareNext/TR_CARD_REC.cs`, `Ac_Ledr.cs:1790-1804` | `web/apps/api/src/modules/finance/cardReceipt.ts`, `web/apps/api/src/routes/txn.ts` `POST/GET/PUT/DELETE /card-receipts` | The Card Receipt (CARD ADJUST) workflow must exist: a customer card settlement posting the exact 8-leg ledger (party/bank/commission/cash), writing CARD_DATA + ROJ_MEL_DATA, reopenable, editable and deletable with the desktop DELETE_DATA audit. | N123 |
| G133 | High | Cust Entry (MISSING workflow) | `unified/src/csharp/DataCareNext/UT_CUST_ENTRY.cs` | `web/apps/api/src/modules/crm/customerEntry.ts`, `web/apps/api/src/routes/crm.ts` `POST/GET/PUT/DELETE /crm/customer-entries` | The Customer Entry (CRM enquiry / item-interest / follow-up reminder) workflow must exist: an employee-scoped, non-financial CUST_DATA + CUST_DETL aggregate, reopenable, editable and deletable. | N124 |
| G134 | High | Loan Intrest (MISSING workflow) | `unified/src/csharp/DataCareNext/TR_DHRN_INTREC.cs`, `Ac_Ledr.cs:1152-1166` | `web/apps/api/src/modules/dhrn/dhrnInterest.ts`, `web/apps/api/src/routes/crm.ts` `POST/GET/PUT/DELETE /dhrn/interest` | The Loan/Dhrn Interest Receipt must be desktop-faithful: the amount-loan 8-leg ledger (principal/interest-assess/interest-collect/kasar pairs), full DHRN_REC_DATA header, DHRN_DATA movement (INT_REC_AMT = R+K), ROJ_MEL_DATA and REMARK_DATA, on its own INTREST RECIVED book, with reopen/edit/delete. | N125 |
| G135 | Med | Dhrn Os Letter (MISSING workflow) | `unified/src/csharp/DataCareNext/RP_DHRN_OS.cs`, `DhrnOsLetter.RPT` | `web/apps/api/src/modules/dhrn/dhrnOsLetter.ts`, `web/apps/api/src/routes/crm.ts` `GET /dhrn/os-letter` | The Dhrn Os Letter must produce a per-party pledge outstanding statement/letter: each open pledge with principal, repaid, outstanding, accrued interest to a cut-off and total due, with the reminder wording. | N126 |
| G136 | High | Tour Sales (MISSING workflow) | `unified/src/csharp/DataCareNext/TR_TOUR_SALE.cs:11252` (Ac_Ledr.Wh_Sales_Ledr) | `web/apps/api/src/modules/sales/tourSale.ts`, `web/apps/api/src/routes/crm.ts` `POST/GET/PUT/DELETE /tour-sales` | Tour Sales must post the same TR_WH_SALE engine (Wh_Sales_Ledr/Rojmel/Stk over RATE_CUT_DATA) on a TOUR SALES book, with create/reopen/edit/delete. | N127 |
| G137 | Med | Journal / lifecycle | `unified/src/csharp/DataCareNext/TR_JOURNAL` (journal voucher) | `web/apps/api/src/routes/crm.ts` `GET/PUT /journal/:vchNo`, `web/apps/api/src/modules/finance/journal.ts` `getJournal`/`editJournal` | The journal voucher must be reopenable and editable through the API (the reader/editor already existed; only the routes were missing). | N128 |
| G138 | High | Finance vouchers / frontend lifecycle | `unified/src/csharp/DataCareNext/TR_CONTRA.cs` | `web/apps/web/app/(app)/txn/contra/page.tsx` | The finance-voucher pages were create-only in the UI even though the backend supports reopen/edit/delete/print; the operator must be able to load, edit, delete and print a saved voucher from the screen. Contra is the first page wired (template for the rest). | N129 |
| G139 | High | Journal / frontend lifecycle | `unified/src/csharp/DataCareNext/TR_JOURNAL` | `web/apps/web/app/(app)/txn/journal/page.tsx` | The journal page was create-only; the operator must load/edit/delete/print a saved journal from the screen (backend ready via N128). | N130 |
| G140 | High | Ledger-adjust & Employee-JV / frontend lifecycle | `unified/src/csharp/DataCareNext/TR_LEDR_ADJ.cs`, `TR_EMP_JV.cs` | `web/apps/web/app/(app)/txn/ledger-adjust/page.tsx`, `web/apps/web/app/(app)/txn/employee-jv/page.tsx`, `web/apps/api/src/modules/vouchers/list.ts` | Both pages were create-only; add a book selector + full reopen/edit/delete lifecycle, and allow-list LDR_ADJ_DATA + EMP_DATA (with DIFF_AMT/SALARY_AMT amount detection) in the recent-voucher list. | N131 |
| G141 | High | Loan Interest / frontend lifecycle | `unified/src/csharp/DataCareNext/TR_DHRN_INTREC.cs` | `web/apps/web/app/(app)/txn/dhrn-interest/page.tsx`, `web/apps/api/src/modules/vouchers/list.ts` | The dhrn-interest page was create-only and still used the old DHIRAN RECEIPT book; point it at the INTREST RECIVED (DIR) book and add the full reopen/edit/delete lifecycle (backend ready from N125), allow-listing DHRN_REC_DATA. | N132 |
| G142 | High | Tour Sales / frontend page | `unified/src/csharp/DataCareNext/TR_TOUR_SALE.cs` | `web/apps/web/app/(app)/txn/tour-sales/page.tsx`, `web/apps/web/lib/wholesaleVoucher.ts`, `web/apps/web/lib/nav.ts` | Tour Sales (backend N127) had no frontend page; the operator could not reach it from the menu. Reuse the shared wholesale-sale form on the TOUR SALES book. | N133 |
| G143 | High | Card Receipt / frontend page | `unified/src/csharp/DataCareNext/TR_CARD_REC.cs` | `web/apps/web/app/(app)/txn/card-receipt/page.tsx`, `web/apps/web/lib/nav.ts`, `web/apps/api/src/modules/vouchers/list.ts` | Card Rec (backend N123) had no frontend page and the Card/UPI menu opened the generic receipt; build a bespoke card-receipt page on the CRD book with the card/bank commission fields and the full lifecycle. | N134 |
| G144 | High | Customer Entry / frontend page | `unified/src/csharp/DataCareNext/UT_CUST_ENTRY.cs` | `web/apps/web/app/(app)/txn/customer-entry/page.tsx`, `web/apps/web/lib/nav.ts` | Customer Entry (backend N124) had no frontend page; build an employee-scoped multi-row CRM grid with load/edit/delete by employeeCode+vchNo. | N135 |
| G145 | Med | Dhrn Os Letter / frontend page | `unified/src/csharp/DataCareNext/RP_DHRN_OS.cs` | `web/apps/web/app/(app)/txn/dhrn-os-letter/page.tsx`, `web/apps/web/lib/nav.ts` | The Dhrn Os Letter (backend N126) had no UI; add a party + as-of page that opens the HTML/PDF letter from GET /dhrn/os-letter. | N136 |
| G146 | High | Receipt/Payment / frontend lifecycle + edit fixes | `unified/src/csharp/DataCareNext/TR_CASH.cs` | `web/apps/web/components/PaymentForm.tsx`, `web/apps/api/src/modules/finance/finance.ts`, `web/apps/api/src/routes/txn.ts` | The receipt/payment pages were create-only; add reopen/delete (both) + edit (receipt) in the UI, fix editReceipt to reverse ROJ_MEL_DATA, and make the payment delete resolve its mode from the persisted voucher. | N137 |
| G147 | High | Fine JV / frontend lifecycle + book | `unified/src/csharp/DataCareNext/MDI_FORM.cs:8360` (FINE JV) | `web/apps/web/app/(app)/txn/fine-jv/page.tsx`, `web/apps/api/src/routes/txn.ts`, `web/apps/api/src/modules/ops/seedCompany.ts` | The Fine JV page was create-only and no FINE JV book was provisioned (POST 409 book-unavailable). Add PUT /fine-jv/:vchNo, wire the page lifecycle, and provision the FJV book. | N138 |
| G148 | High | Payment edit | `unified/src/csharp/DataCareNext/TR_CASH.cs` | `web/apps/api/src/modules/finance/finance.ts` `postPayment`/`editPayment`, `web/apps/api/src/routes/txn.ts` `PUT /payments/:vchNo`, `web/apps/web/components/PaymentForm.tsx` | Payment edit was unavailable (postPayment had no lifecycle-context hook). Refactor postPayment to the FinanceWriteContext pattern, write HD_VCH_NO + the hidden identity, add editPayment + PUT /payments/:vchNo, and enable payment edit in the UI. | N139 |
| G149 | Med | Scheme instalment / edit | `unified/src/csharp/DataCareNext/TR_MEMB_ENT.cs` | `web/apps/api/src/routes/txn.ts` `PUT /scheme/installment/:vchNo`, `web/apps/api/src/modules/membership/scheme.ts` `editSchemeInstallment` | The scheme instalment (highest-volume workflow) could be created, reopened and deleted but not edited; expose editSchemeInstallment via a PUT route (extract a shared input helper). | N140 |
| G150 | High | CI health / release gates | `.github/workflows/ci.yml`, `web/apps/api/src/modules/finance/cardReceipt.ts`, `web/apps/web/components/PaymentForm.tsx`, `web/parity/depth-parity-baseline.json` | `web/apps/api/src/modules/finance/cardReceipt.ts` `cardReceiptInputFromBody`, `web/apps/web/components/PaymentForm.tsx`, `web/parity/unreachable-triage.json`, `web/parity/depth-parity-baseline.json` | CI red since N124: the `cardReceiptInputFromBody` export was never committed (lived in an uncommitted working-tree change a `git stash` dropped), so a clean `tsc -p` failed TS2724 — masked locally by the dirty tree across ~16 merges. Also the PaymentForm `resetForm()`-after-save wiped the save confirmation (real-stack journey timeout), and the depth ceiling drifted 96→102 from the Stage D/E writers. Commit the export, keep `res` after a new save, resync the depth baseline + triage. | N141 |
| G151 | Med | Batch receipt / kasar write-off | `unified/src/csharp/DataCareNext/Ac_Ledr.cs:571-581` | `web/apps/api/src/modules/finance/batchReceipt.ts`, `web/apps/api/src/modules/finance/finance.ts` `kasarAccountTx`, `web/apps/api/test/batchReceiptKasar.db.test.ts` | `postBatchReceipt` required the caller to name the kasar (write-off) account, but the batch grid has no kasar-account column and the route forwards only `{scope,vchDate,lines}`, so every on-screen write-off on a batch collection was refused. The single-row receipt/payment path already resolves BOOK_DETL slot 2 (desktop `Ac_Ledr.cs:571-581`); the batch path must do the same. | N142 |
| G152 | High | Dhiran pledge issue / reopen+edit | `unified/src/csharp/DataCareNext/TR_DHRN_ISU.cs` | `web/apps/api/src/modules/dhrn/dhrn.ts` `getDhrnIssue`/`editDhrnIssue`, `web/apps/api/src/routes/txn.ts` `GET/PUT/DELETE /dhrn/issue/:isuNo`, `web/apps/web/app/(app)/txn/dhrn-issue/page.tsx` | The pledge issue (a core daily workflow) could be created and deleted but not reopened or edited: `issueDhrn`/`deleteDhrn` existed but there was no reader/editor or GET/PUT routes, and the page was create-only (no VoucherList). Add `getDhrnIssue`/`editDhrnIssue` mirroring the N125 interest pattern, the three routes, and the lifecycle UI. | N143 |
| G153 | High | Dhiran pledge receipt / reopen+edit + ISU_REC restore | `unified/src/csharp/DataCareNext/TR_DHRN_REC.cs:6376` | `web/apps/api/src/modules/dhrn/dhrn.ts` `getDhrnReceipt`/`editDhrnReceipt`/`deleteDhrn`, `web/apps/api/src/routes/crm.ts` `registerDhrnLifecycleRoutes`, `web/apps/web/app/(app)/txn/dhrn-receipt/page.tsx` | The pledge receipt (redemption) was create-only, and worse, deleting a receipt did NOT restore the issue's `ISU_REC` flag, so a reversed receipt left the pledge permanently marked redeemed (desktop `TR_DHRN_REC.cs:6376` sets it back to `'N'`). Add reader/editor + routes, restore `ISU_REC='N'` on receipt delete/edit, and wire the lifecycle UI. | N144 |
| G154 | Med | Loan Received / Loan Issue reopen+edit | `unified/src/csharp/DataCareNext/TR_DHRN_ISU.cs`, `unified/src/csharp/DataCareNext/TR_DHRN_REC.cs` | `web/apps/api/src/modules/dhrn/dhrn.ts` `editLoanReceived`/`editLoanIssue`, `web/apps/api/src/routes/crm.ts` `registerDhrnLifecycleRoutes`, `web/apps/web/app/(app)/txn/loan-issue/page.tsx`, `web/apps/web/app/(app)/txn/loan-received/page.tsx` | Loan Received (receiveLoan→issueDhrn, DHRN_ISU_DATA) and Loan Issue (issueLoan→receiveDhrn, DHRN_REC_DATA) were create-only. They share the pledge tables, so reopen reuses the dhrn readers; add loan-flag-injecting editors + the six routes + the lifecycle UI. | N145 |
| G155 | Med | Karigar / Old-Item-Sales reopen+edit (shared form) | `unified/src/csharp/DataCareNext/TR_KR_ISU.cs`, `unified/src/csharp/DataCareNext/TR_MFG_KR_ISU_REC.cs` | `web/apps/web/components/KarigarForm.tsx` | The shared KarigarForm (karigar-issue/receive, old-item-sales, jobwork-issue/receive) is create-only even though `getKarigar`/`editKarigar` and `getOldItemSale`/`editOldItemSale` and their GET/PUT/DELETE routes already exist (karigar + old-item-sales; jobwork reads through a different backend, see G157). `useSubDetail.load()` is already built for reopen. Wire `loadVoucher` + PUT-when-loaded + a family-gated VoucherList (UI-only). | N146 |
| G156 | Med | Fine Sale / Fine Purchase edit | `unified/src/csharp/DataCareNext/TR_FINE_SL_PR.cs` | `web/apps/api/src/modules/bullion/fineSalePurchase.ts`, `web/apps/web/app/(app)/txn/fine-sale/page.tsx` | Fine Sale/Purchase can create, reopen (`getFineSalePurchase`, N121) and delete, but there is no `editFineSalePurchase` or PUT route, and the page is create-only. The writer uses `nextVoucherNoTx`, not the identity/context pattern, so it must be refactored before an edit (which must also reverse+rewrite MAIN_STOCK) can resolve. | N147 |
| G157 | Med | Jobwork reopen+edit in KarigarForm | `unified/src/csharp/DataCareNext/TR_JDT_REC.cs` | `web/apps/web/components/KarigarForm.tsx` | N146 wired KarigarForm reopen/edit but excluded jobwork, which reads through a different backend (`getMfg`/MFG_KR_DATA via `/mfg/jobwork-*`, not `getKarigar`/KR_DATA). The jobwork GET/PUT/DELETE routes exist; extend `loadVoucher` with a jobwork branch that maps the `getMfg` reader shape. | N148 |
| G158 | Med | Manufacturing Issue reopen+edit (UI) | `unified/src/csharp/DataCareNext/TR_MFG_ISU_REC.cs` | `web/apps/web/app/(app)/txn/mfg-issue/page.tsx` | The mfg-issue page was create-only though `getMfg`/`editMfg`/`deleteMfg` and `GET/PUT/DELETE /mfg/issue/:vchNo` exist and are covered by `mfgLifecycle.db.test.ts`. The getMfg reader's field names match the page Line exactly and `useSubDetail.load()` exists; wire `loadVoucher` + PUT-when-loaded + VoucherList (UI-only). | N149 |
| G159 | Med | Manufacturing Receive reopen+edit (UI) | `unified/src/csharp/DataCareNext/TR_MFG_ISU_REC.cs` | `web/apps/web/app/(app)/txn/mfg-receive/page.tsx` | Companion to G158: mfg-receive was create-only though the same `getMfg`/`editMfg`/`deleteMfg` backend and `GET/PUT/DELETE /mfg/receive/:vchNo` exist (mfgLifecycle.db.test.ts). Wire the same lifecycle (plus the labourAmt header). | N150 |
| G160 | Med | Bullion Sale reopen+edit+delete (UI) | `unified/src/csharp/DataCareNext/TR_BUL_SALE.cs` | `web/apps/web/app/(app)/txn/bullion-sale/page.tsx` | The bullion-sale page was create-only (imported only `post`) though `getBullionSale`/`editBullionSale`/`deleteBullionSale` and `GET/PUT/DELETE /bullion-sales/:vchNo` exist and are covered by `bullionSale.db.test.ts` (post → reopen → edit → delete). The reader (`readRateCut` with `bookGuard:'bullion-sale'`) returns header fields + `lines`/`receivedLines`; wire `loadVoucher` (GET + full header/tender/line restore) + PUT-when-loaded + delete + New/Update (UI-only, no new routes). | N151 |
| G161 | Med | Manufacturing Order Issue reopen+edit (needs reader extension) | `unified/src/csharp/DataCareNext/TR_MFG_ISU_REC.cs` | `web/apps/web/app/(app)/txn/mfg-order-issue/page.tsx` | The Order Issue page is create-only; `GET/PUT/DELETE /mfg/order-issue/:vchNo` exist (getMfg/editMfg/deleteMfg, coBook DIS, irType D). **Not a safe UI-only slice** — unlike mfg-issue/mfg-receive, this bespoke page's POST payload sends ~51 writer-verified `extendedLineFields` plus header `karigarName`, but `getMfg` (`web/apps/api/src/modules/manufacturing/mfg.ts:1155-1271`) omits nine persisted line keys (`totalNetWt`,`oldNetWt`,`rateType`,`prCode`,`itmLoss`,`netAmt`,`krName`,`ordAcCode`,`ordDesign`) and `karigarName`. Because `editMfg` deletes-and-rebuilds the write set, an unchanged reopen→save would blank those columns. Requires a **backend** `getMfg` reader extension to return every persisted payload field (plus issue-side `itmLoss` and `karigarName` semantics) with an all-fields GET→payload round-trip test, THEN the UI reopen wiring. | N153 (reader) + N152 (UI) |
| G162 | Med | Multi-Party (batch) Receipt reopen/edit/delete | `unified/src/csharp/DataCareNext/TR_CASH.cs` | `web/apps/web/app/(app)/txn/batch-receipt/page.tsx`, `web/apps/api/src/modules/finance/batchReceipt.ts` | The desktop Multi-Party Receipt (TR_CASH, a grid of party rows) is fully reopen/edit/delete-capable — `BtnF` loads by voucher no., an edit deletes `CASH_DATA`+`AC_DATA` by VCH_NO and rebuilds them, writing a `DELETE_DATA` audit (`TR_CASH.cs:2988-3081,3217`). The web batch-receipt page was create-only: the backend had `postBatchReceipt`/`deleteBatchReceipt` but no reader or editor, and the single-row `getReceipt` refuses a multi-row voucher. Add `getBatchReceipt` (reads every CASH_DATA row as `lines[]`, deriving pay mode from `REC_AC_CODE` vs the book slot-1 cash account) + `editBatchReceipt` (reverse + re-post under the same number via `forceVchNo`) + `GET/PUT/DELETE /receipts/batch/:vchNo` + the UI reopen/edit/delete + VoucherList on CASH_DATA. | N154 |
| G163 | Med | Order-cancel refund/kasar accounts are literals | `unified/src/csharp/DataCareNext/TR_SL_ORD_ADJ.cs` | `web/apps/api/src/modules/sales/salesOrder.ts` `cancelSalesOrderAdjust` | `cancelSalesOrderAdjust` fell back to the string literals `'CASH'` (refund settlement) and `'KASAR'` (write-off) when the request named neither — codes that do not exist in a real company's AC_MAST, so a cancel without an explicit account posted the refund/kasar legs to a non-existent ledger (the N59 anti-pattern). The desktop posts the adjustment via `Ac_Ledr.Order_Adj_Ledr` (`TR_SL_ORD_ADJ.cs:3665`), resolving both accounts from the cancel book's BOOK_DETL slots (1=settlement, 2=kasar). Resolve the same configured accounts on the transaction (explicit wins, else slot 1/2) and FAIL-CLOSED when unconfigured. | N155 |
| G164 | Med | Sales-order advance cash account is a literal | `unified/src/csharp/DataCareNext/TR_SALE_ORD.cs` | `web/apps/api/src/modules/sales/salesOrder.ts` | The order-advance debit leg used `input.cashAc ?? 'CASH'` — when an advance was taken without a named account it posted the Dr leg to the non-existent `'CASH'` ledger (N59 anti-pattern). The desktop debits the order book's BOOK_DETL slot-1 account (noted at `salesOrder.ts:1197`). Resolve slot 1 on the posting transaction (explicit wins) and FAIL-CLOSED when unconfigured. | N156 |
| G165 | Med | Core sale posting used literal account fallbacks | `unified/src/csharp/DataCareNext/TR_SALE.cs`; `unified/src/csharp/DataCareNext/Ac_Tax.cs` | `web/apps/api/src/modules/sales/sales.ts` | The sale writer carried 11 literal account fallbacks. Five were genuine N59 defects with a configured/persisted source: the cash leg and the electronic-tender (card/upi/cheque) bank leg (incl. the cheque Rojmel row) posted to `'CASH'`/`'BANK'`, and the sale-income account defaulted to `'SALES'`. These now resolve from BOOK_DETL slot 1 (income) / slot 2 (cash) or the persisted `BANK_AC`, FAIL-CLOSED when an electronic tender posts with no bank account. The remaining six (`'OLDGOLD'`, `'HMCHRG'`x2, `'TCS'`x2, `'GST'`) are legitimate fixed defaults with NO BOOK_DETL slot, NO persisted header column, and no tax-code resolution (a documented web provisioning gap), so fail-closing them would break legitimate reopen — left intact and tracked in the posting-literals REMAINING ledger. | N157 |
| G166 | Med | Purchase posting used literal account fallbacks | `unified/src/csharp/DataCareNext/TR_PURC.cs` | `web/apps/api/src/modules/purchase/purchase.ts` | The purchase writer mirrored the sale one: 5 literal fallbacks. Two were genuine N59 defects — the purchase expense account defaulted to `'PURCHASE'` (both the writer base and the single-expense income branch). These now resolve from BOOK_DETL slot 1 (explicit wins, fail-closed for a posting purchase; placeholder for a no-ledger quotation). The remaining three (`'GSTINPUT'`, `'HMCHRG'`x2) are legitimate fixed defaults — the tax-input account depends on the documented TAX_MAST provisioning gap and hallmark has no slot/persisted column — left intact and tracked in REMAINING. | N158 |
| G167 | Med | Labour invoice metal-sale/round-off accounts were literals | `unified/src/csharp/DataCareNext/Ac_Ledr.cs` | `web/apps/api/src/modules/sales/labourInvoice.ts` | The labour invoice already resolved its labour-income leg from BOOK_DETL slot 6 (G115) but still defaulted the metal-sale income to `'SALES'` and the round-off to `'ROUNDOFF'`. Both now resolve from the labour book (slot 1 and slot 3) through a generalized `resolveLabourBookSlot`, inside the tx and gated on their legs posting (explicit wins, fail-closed). The `'GST'` tax account stays a documented default (TAX_MAST provisioning gap). | N159 |
| G168 | Med | Malformed request body returned 500, not 400 | PARITY-EVALUATION §5c 500 probes | `web/apps/api/src/routes/txn.ts` | A malformed body shape that reached a writer (e.g. a non-array `lines`) threw a synchronous `TypeError` (`lines.map is not a function`) that fell through the shared `run()` catch to Fastify's default 500. Now a `TypeError`/`RangeError` from a handler body — after auth and routing have already succeeded — is answered as a 400 `invalid-request`. Typed server-fault errors keep their own status (mapped earlier). First increment of N50; full per-route JSON Schemas remain. | N160 |
| G169 | High | A sale with items from two groups cannot be saved | `unified/src/csharp/DataCareNext/Ac_Ledr.cs` | `web/apps/api/src/modules/sales/sales.ts` | Found by the feature E2E suite (`sales-invoice.create.two-lines-dissimilar`): a bill with a gold line (group SALE_AC `SALES`) and a silver line (`SLVSALE`) fails with `duplicate key … AC_DATA_tenant_ledr_key_key`, because every per-group income leg is posted with the same leg type 03. The desktop posts one revenue row per detail line keyed `VCH_NO+STR(SR_NO)+'05'` (`Ac_Ledr.cs:74`). Any shop selling gold and silver on one bill is blocked. | N161 |
| G170 | High | Lost update: a stale second save overwrites the first | `unified/src/csharp/DataCareNext/TR_SALE.cs` | `web/apps/api/src/modules/sales/sales.ts` | Found by `sales-invoice.concurrency.stale-second-save`: two operators load voucher 1, the first saves rate 6500, the second (stale) saves rate 7000 and is answered 200; the line ends at 70,000 and the first save is gone. `editSale` reads no version token. Tracked by N51 (version tokens on every update/delete, waiting on decision D17) Also seen on purchases (`purchase-invoice.concurrency.stale-second-save`: the stale save answered 200 and the line ended at the second operator's amount). | N161 |
| G171 | Low | No keyboard save on voucher screens | `unified/src/csharp/DataCareNext/TR_SALE.cs` | `web/apps/web/components/VoucherChrome.tsx` | Found by `sales-invoice.keyboard.alt-s-saves`: the desktop saves with the `&Save` mnemonic, Alt+S (`TR_SALE.cs:4896`). No web Save button sets `accessKey`, so an operator who saves from the keyboard cannot. (The desktop has no Ctrl+S binding; the case was corrected to Alt+S.) | N161 |
| G172 | Low | Opening the company from two sessions at once shows a raw error code | — | `web/apps/api/src/modules/auth/sessionContextSelection.ts` | Found while building the surface crawl: four sessions of the same user pressing Open at the same moment got `409` from `POST /context/select` and the Open Company screen showed the raw code `context-transaction-conflict` (`sessionContextSelection.ts:492`). Rare in a shop, but the operator sees a code instead of a message and no retry is offered. | N165 |
| G173 | Med | Feature E2E cannot run rollback (T14) cases | `docs/master-parity-plan-2026-09-29/04-verification-playbook.md` | `web/apps/web/test/features/harness.mjs` | T14 needs a declared fault at each write boundary before commit; the harness has no fault injector, so `sales-invoice.rollback.mid-write` is blocked. | N166 |
| G174 | Med | Feature E2E has no settings-variant company (T15) | `docs/master-parity-plan-2026-09-29/04-verification-playbook.md` | `web/apps/web/test/features/fixtures/catalogue.mjs` | T15 needs a company with other settings (fine-basis pricing, whole-rupee rounding, negative stock refused); the catalogue provisions one configuration only, so `sales-invoice.config.setting-change` is blocked. | N166 |
| G175 | Low | Negative-weight sale line: rule undecided | `unified/src/csharp/DataCareNext/TR_SALE.cs` | `web/apps/api/src/modules/sales/sales.ts` | No desktop source refuses a negative weight (`TR_SALE_KeyPress` 14870-14883 only uppercases) and the web saves one. Needs an original-Windows run to decide; `sales-invoice.refusal.negative-weight` is blocked until then. | N167 |
| G176 | High | A purchase with items from two groups cannot be saved | `unified/src/csharp/DataCareNext/Ac_Ledr.cs` | `web/apps/api/src/modules/purchase/purchase.ts` | Found by the feature E2E suite (`purchase-invoice.create.two-groups`): a gold line (GROUP_MAST.PURC_AC `PURCHASE`) and a silver line (`SLVPURC`) on one purchase fail with `duplicate key … AC_DATA_tenant_ledr_key_key`; every per-group expense leg is posted with the same leg type. Same class as G169 on sales. | N162 |
| G177 | Med | Settings with an amount limited to fixed presets | `unified/src/csharp/DataCareNext/UT_SETTING.cs` | `web/apps/api/src/modules/settings/settingsCatalog.ts` | Found by `settings.field.pan-limit-any-amount`: the web renders PAN_CARD_VAL as a select of 100000/200000, but the desktop `cboPanCardVal` is an editable combo (presets at :4300-4301, saved as `Val(Text)` at :5059; no DropDownList style anywhere in the setting forms), so a shop cannot enter its own PAN limit such as 50000. FONT_SIZE, GRID_ROW_HIGHT and VCH_DESC_HELP_LENT are limited the same way. | N168 |
| G178 | High | The only administrator can remove their own admin role and lock the company out | `unified/src/csharp/DataCareNext/MS_USER.cs` | `web/apps/api/src/modules/rbac/users.ts` | Observed on the live demo database: `POST /admin/users/:loginName/rights` (200 at 10:20:16 UTC) set `admin` to LOGIN_CATG `USER` with every right `N`; every later admin request answered 403 and the sales register says `forbidden`. `setUserRights` updates LOGIN_CATG with no check for the last administrator or the caller's own account. The desktop has no such check either, but always keeps the built-in `ABC` user with full rights (`MS_USER.cs:1330`), so it cannot lock itself out; the web has no recovery short of editing the database. | N169 |
| G179 | Med | Voucher number box ignores Enter, Up and Down | `unified/src/csharp/DataCareNext/TR_SALE.cs` | `web/apps/web/app/(app)/txn/sales/page.tsx` | Found in the 30 October browser run of Sales Invoice: typing a saved voucher number and pressing Enter leaves the screen empty; only the Load button opens it. The desktop `tVchNo_KeyDown` (`TR_SALE.cs:17068-17096`) opens the voucher on Enter (`DISPLAY_DATA`) and the voucher list on F1. Up and Down call `BtnLast_Click` and `BtnFirst_Click`, which step to the next and the previous saved voucher, not the last and the first (`TR_SALE.cs:17164-17222`; corrected from the source on 30 October). Operators reopen vouchers by keyboard all day; the same box is on the other voucher screens. | N172 |
| G180 | Med | The print window shows `unauthenticated` after the session's access cookie expires | — | `web/apps/web/app/(app)/txn/sales/page.tsx` | Found in the 30 October browser run: about 40 minutes into a session, Print opened `/api/sales/invoice?…&format=html` showing `{"error":"unauthenticated"}`. The screen's own API calls refresh the 15-minute access cookie (`POST /auth/refresh`), but the print window is a plain navigation and cannot; pressing Print again after any other API call works. An operator sees an error instead of the bill. | N173 |
| G181 | Med | The printed invoice's HSN table disagrees with the bill tax by a paisa | `unified/src/csharp/DataCareNext/TR_SALE.cs` | `web/apps/api/src/modules/documents/docChrome.ts` | Found in the 30 October browser run (gold + silver bill, tax 2,043.29): the printed HSN table shows CGST 1,021.64 + SGST 1,021.64 = 2,043.28 while the summary beside it shows CGST and SGST 1,021.65 each and the grand total includes 2,043.29. The halves are stored unrounded (`TR_SALE.cs` keeps `SGST_TAX = CGST_TAX = tax / 2`), so the print must round them one way consistently and the table must total the bill tax. A legal document must not show two different tax totals. | N174 |
| G182 | Low | Request storms: every page prefetches all navigation routes, and the party box fetches a balance per keystroke | — | `web/apps/web/components/Shell.tsx` | Found in the 30 October browser run: each page load requested about 240 `?_rsc=` route prefetches (one per navigation link), and typing `CUST01` in the party box sent six balance requests (`/party/C/balance`, `/party/CU/balance`, …). Wasted server work on every screen, worse on a slow shop connection. | N175 |
| G183 | Med | The web has no edition: it shows the menus of every desktop edition | `unified/src/csharp/DataCareNext/MDI_FORM.cs` | `web/apps/web/lib/nav.ts` | The desktop loads only its edition's menus (`MENU_DATA` filtered by `SM_TYPE`, `MDI_FORM.cs:11249-11322`) and hides the Scheme and Dhiran buttons in Standard (`:11282-11285`). The web lists all 240 routes for every company, so a Standard shop sees Pro, Advance and Enterprise screens (Dhiran, schemes, consignment, tour, design book) that its desktop never shows, and their APIs accept requests. Needed for decision D31. | N171 |
| G184 | Med | A provisioned purchase book has no slot 4, so a purchase with labour is refused when labour is posted separately | `unified/src/csharp/DataCareNext/Ac_Ledr.cs` | `web/apps/api/src/modules/ops/seedCompany.ts` | Found while fixing G176: with the setting PURC_WITH_LBR = 'N' the desktop posts a line's labour and other charges to the purchase book's BOOK_DETL slot 4 (`Ac_Ledr.cs:419-421`). `seedCompany` gives the purchase book slots 1-3 only, so the writer's fail-closed slot-4 lookup refuses every purchase with labour on a web-provisioned company once the setting is switched. The N162 test adds slot 4 in its fixture. | N176 |
| G185 | High | Typing a code and pressing Enter at once picks the first row of the previous list | `unified/src/csharp/DataCareNext/TR_PURC.cs` | `web/apps/web/components/LookupPicker.tsx` | Found in the 30 October browser run of Purchase Invoice: in the supplier box, typing `SUPL` and pressing Enter straight away put `BANK` (the first row of the list shown before typing) on the bill; it happened twice. The lookup searches 180 ms after the last keystroke and Enter picks the highlighted row of the last list that arrived, which can belong to earlier text. The desktop looks the typed code up exactly on Enter (`TR_PURC.cs:14619-14628`; `TR_SALE.cs` does the same). A fast operator or a barcode scanner can post a voucher to the wrong account. | N177 |
| G186 | Low | Two refusals use web wording instead of the desktop message | `unified/src/csharp/DataCareNext/TR_SALE.cs` | `web/apps/api/src/modules/sales/sales.ts`; `web/apps/api/src/modules/posting/posting.ts` | Seen in `settings.effect.negative-stock-refused` and `settings.effect.lock-date-refuses`: the web says `negative stock is not allowed: item … needs … but only …` (`sales.ts:1107`) and `period is locked: voucher date … is on or before the lock date …` (`posting.ts:273`), where the desktop says `Negative Stock is Not Allow Curent Stock = …` (`TR_SALE.cs:10398`) and `You Cant Save and Delete This Voucher Becouse Lock Date is = …` (`TR_SALE.cs:15066`, `:16308`). Other refusals already use the desktop text through `desktopMessages.ts`. | N178 |
| G187 | Low | Tax rounding setting is labelled as Y/N but is a decimal count | `unified/src/csharp/DataCareNext/MS_OPNCOMP.cs` | `web/apps/api/src/modules/settings/settingsCatalog.ts` | Found while preparing the settings cases: TAX_ROF is shown as `Round-off tax (Y/N)` with options 0/1/2, but it is the number of decimals tax is rounded to (`MS_OPNCOMP.cs:671`; values above 5 fall back to 2 at `:741-743`) and the web rounding policy accepts 0–5. An operator reading the label cannot tell what 0, 1 or 2 mean. | N168 |
| G188 | Low | 141 buttons with no visible effect are not yet classified | — | `docs/handbook/web/ui-surface-map.md` | The with-data sweep pressed 848 buttons; 141 (27 distinct names) produced no request, navigation, dialog or screen change: CSV on 43 report pages, New on a blank form (19), removing the only row (39 across ×, Remove … row 1 and Remove), Load without a voucher number (7), Cancel (6), Check balance without a party (5), Details (1). Most are expected, but none is proven so. The sales register CSV exports correctly when it has rows (`sales-invoice.output.register-csv`); the 43 are probably CSV on an empty section, which silently exports nothing. | N179 |
| G189 | Low | The login limit refuses a busy counter with a raw 'Too Many Requests' | `unified/src/csharp/DataCareNext/MS_LOGIN.cs` | `web/apps/api/src/app.ts` | Hit while building the suite: `/auth/login` allows 10 attempts a minute (`app.ts:500`, per client address), and the login screen then shows the raw text `Too Many Requests`. Several counters behind one shop address logging in at opening time would be refused this way; the desktop login (`MS_LOGIN.cs`) has no attempt limit. The limit itself is a security control and stays; the message and the per-address key need a decision. | N55 |
| G190 | High | Sales Return prices the line on fine weight and keeps paise | `unified/src/csharp/DataCareNext/TR_SALE_RTN.cs` | `web/apps/api/src/modules/sales/salesReturn.ts`; `web/apps/api/src/modules/sales/sales.ts`; `web/apps/web/app/(app)/txn/sale-return/page.tsx` | Found by `sales-return.formula.net-basis` and `sales-return.create.amount-net-basis`: a 10 g GLD22 line (touch 91.6, rate 6,123.45, making 237.5/g) previews and saves 58,465.80, which is fine 9.16 × rate + making. The desktop prices on `CO_SET.SL_AMT_TYPE` (`TR_SALE_RTN.cs:4914-4931`: net + ghat for `N`, gross for `G`, fine only for `F`) and rounds the item and labour amounts to whole rupees with `Math.Round(x, 0)` (`:4955`, `:4985`), and the bill total too (`:16405`): 61,234 + 2,375 = 63,609, tax 1,908.27, total 65,517. The web return calls the sale calculation with a blank amount type on purpose, which keeps a fine basis (`sales.ts:293-300`). | N181 |
| G191 | Med | A loose-stock sale line imported into a return cannot be saved | `unified/src/csharp/DataCareNext/TR_SALE_RTN.cs` | `web/apps/api/src/modules/sales/salesReturn.ts`; `web/apps/web/app/(app)/txn/sale-return/page.tsx` | Found by `sales-return.create.from-bill-import`: Orig Book `SL`, Orig Bill No and Import fill the customer and the sold line, then Save answers 400 `tag provenance is missing or ambiguous: N`. The sold line has no tag and is stored with `TAG_NO` `N`, the desktop's loose-stock marker. The desktop copies it into the return grid as it is (`TR_SALE_RTN.cs:3917`) and every tag step skips `N` (`:4773`, `:8585`, `:13387`, `:13395`). The web writer treats any non-blank tag as a tag (`salesReturn.ts:155`), although its reader already maps `N` to blank (`salesReturn.ts:739`). | N182 |
| G192 | Low | The Tax % box covers the Import button on the Sales Return screen | `unified/src/csharp/DataCareNext/TR_SALE_RTN.cs` | `web/apps/web/app/(app)/txn/sale-return/page.tsx` | Found by `sales-return.ui.import-button-clickable`: at 1600 px the Tax % input lies over Import beside Orig Bill No, so a click lands on the input and Import works only from the keyboard (focus and Enter). | N182 |
| G193 | Med | Deleting a voucher that is already gone answers 500 | `docs/master-parity-plan-2026-09-29/03-shared-contracts.md` | `web/apps/api/src/modules/vouchers/lifecycle.ts`; `web/apps/api/src/routes/txn.ts` | Found by `sales-return.concurrency.double-delete`: two operators delete the same return; the first answers 200 and reverses the stock once (580 → 570), the second answers 500. `persistedVoucherHeaderTx` throws `PersistedVoucherNotFoundError` (`lifecycle.ts:131`) and `run()` (`txn.ts:950-1040`) does not map it, so it surfaces as a server error. The shared contract asks for a stable conflict reason for a stale document (`03-shared-contracts.md`, rule 9 of the conflict list). 18 writer modules read their header through `persistedVoucherHeaderTx`. The Sales Order delete answers 500 the same way (`sales-order.concurrency.double-delete`). | N183 |
| G194 | Med | Sales Return does not record who created or deleted it | `unified/src/csharp/DataCareNext/TR_SALE_RTN.cs` | `web/apps/api/src/routes/txn.ts` | Found by `sales-return.create.records-user` and `sales-return.delete.audit-user`. A return saved by `e2eadmin` stores `SL_DATA.MAIN_USER` blank, because `POST /sales-returns` (`txn.ts:1804-1833`) does not pass the user; the desktop stores `DC_Main.MCo_User` (`TR_SALE_RTN.cs:9966`, `:12908`). Its delete writes `DELETE_DATA.DELETE_USER` = `feature-e2e`, the tenant id, because the route passes `sess(req).tenantId` (`txn.ts:1856`); the desktop writes `MCo_User` (`:15076`). Six more deletes pass the tenant id: labour invoice (`txn.ts:2083`), multi receipt (`:2907`), multi payment (`:2946`), MFG order issue (`:3810`), MFG (`:3823`) and fine sale (`:8360`). | N183 |
| G195 | High | Sale line amounts are rounded by TOT_AMT_ROF instead of to whole rupees | `unified/src/csharp/DataCareNext/TR_SALE.cs` | `web/apps/api/src/modules/sales/sales.ts`; `web/packages/core/src/calc.ts` | Found while checking the return's rounding. The desktop's `CommPassTotal` starts with `digits = 0` and uses 2 only when `CO_SET.ALL_ROF_REMOVE = 'Y'` (`TR_SALE.cs:10343-10362`), then rounds the item amount (`:10905`) and the labour amount (`:11100-11108`) with it; `TOT_AMT_ROF` rounds only the bill total (`:19192`, `:19274`). The web rounds each line component with `TOT_AMT_ROF` (`sales.ts:337-349`), a rule taken from a customer database where `TOT_AMT_ROF` is 0, so the two agree only at 0. With `TOT_AMT_ROF` 2, or blank (read as 2), a 10 g line at 6,123.45 is 61,234.50 on the web and 61,234 on the desktop. The web's E-Bill calculation already follows the desktop rule (`web/packages/core/src/eBillCalc.ts:30`). The merged cases of `sales-invoice` (EXPECT_A 61,234.50) and `settings.effect.sale-amount-fine` (56,090.80) assert the web value; the desktop values are 61,234 and 56,091. | N184 |
| G196 | Med | A new web company leaves the rounding settings blank, and the web reads blank as 2 decimals | `unified/src/csharp/DataCareNext/Ac_Image.cs` | `web/packages/core/src/roundingPolicy.ts` | The desktop schema makes the rounding settings NOT NULL with defaults: `LBR_ROF` 0 and `ITM_RATE_ROF` 0 (`Ac_Image.cs:6320`, `:6358`), `PR_RATE_ROF` 2 (`:7010`), `TOT_AMT_ROF` 0 (`:7357`) and `ALL_ROF_REMOVE` `N` (`:7565`). A new desktop company copies them from an existing one (`MS_YEAR.cs:1529-1531`), and a blank `TAX_ROF` reads as 0 decimals (`MS_OPNCOMP.cs:668-671`, `DC_Main.cs:2088-2101`). On the live demo company `TAX_ROF` and `ALL_ROF_REMOVE` are NULL and there is no `CO_SET_NEW` row, and `resolveRoundingPolicy` reads blank as 2 decimals on purpose (`roundingPolicy.ts:103`). So a new web company keeps paise on the bill total, tax, labour rate and item rate where a new desktop company rounds to whole rupees. To decide under D05: provision the desktop defaults, or keep 2 decimals for web-created companies and record why. | N185 |
| G197 | Med | A rebuilt checkout served the previous build's pages to the browser tests | `docs/master-parity-plan-2026-09-29/04-verification-playbook.md` | `web/apps/web/package.json` | Found while checking N172 in Chrome: after `pnpm build`, `next start` (Next.js 15.5.28) answered `/txn/sales` with `x-nextjs-cache: HIT` and the previous build's page chunk, because pages served by the previous server stay in `apps/web/.next/server/route-cache` and the build does not remove that directory. Deleting it made the same server serve the new chunk. A local feature or real-stack run after a rebuild could therefore pass or fail on old code; CI builds from a clean checkout and was not affected. | N186 |
| G198 | High | Purchase-family line amounts keep paise where the desktop rounds to whole rupees | `unified/src/csharp/DataCareNext/TR_KR_ISU.cs` | `web/apps/api/src/modules/purchase/purchaseReturn.ts`; `web/apps/web/lib/purchaseReturnForm.ts` | Found by `purchase-return.formula.whole-rupees` and `purchase-return.create.amounts`: a 10 g GLD22 return line (touch 91.6, rate 6,123.45, making 237.5/g) previews and stores 56,090.80 + 2,375 = 58,465.80, tax 1,753.97 and total 60,219.77. TR_KR_ISU rounds the item amount (`TR_KR_ISU.cs:4015`) and the labour amount (`:4028`) with `Math.Round(x, 0)`, sums the bill to whole rupees (`:6522`) and rounds the total to whole rupees (`:6528`): 56,091 + 2,375 = 58,466, tax 1,753.98, total 60,220. TR_PURC rounds its line amounts the same way (`TR_PURC.cs:9946-9958`, `:9983-9987`); the Purchase Invoice module's lines happen to give whole rupees, so its cases do not show it. Same mechanism as G195 (sales) and G190 (sales return). | N188 |
| G199 | Med | A purchase return cannot be saved without choosing an original purchase book | `unified/src/csharp/DataCareNext/TR_KR_ISU.cs` | `web/apps/web/app/(app)/txn/purchase-return/page.tsx`; `web/apps/web/components/BookSelect.tsx` | Found by `purchase-return.create.without-original`: Orig Purchase Book is a `BookSelect`, which is always `required` (`BookSelect.tsx:83`), and with two purchase books (PR and the TAG PURCHASE book) nothing is preselected, so the browser blocks Save ("Please select an item in the list") on a return that is not against a purchase. A saved free-standing return reopens with the field blank again, so every edit needs a book chosen first. The desktop save checks a party and a voucher number, not an original purchase (`TR_KR_ISU.cs:4986-4999`). | N189 |
| G200 | Med | Alt+S does not save on the Purchase Return screen and 19 other voucher screens | `unified/src/csharp/DataCareNext/TR_KR_ISU.cs` | `web/apps/web/app/(app)/txn/purchase-return/page.tsx`; `web/apps/web/lib/saveMnemonic.ts` | Found by `purchase-return.keyboard.alt-s-saves`: N163 (G171) made Alt+S press the button marked `data-save-mnemonic`, and the Purchase Return save button is not marked, so the key does nothing. The desktop button is `&Save` (`TR_KR_ISU.cs:2330`). A scan of `web/apps/web/app/(app)/txn/*/page.tsx` finds 20 screens whose primary Save button is unmarked: batch-receipt, card-receipt, customer-entry, dhrn-interest, dhrn-issue, dhrn-receipt, employee-jv, fine-inout, fine-sale, ledger-adjust, loan-issue, loan-received, melting, mfg-issue, mfg-receive, purchase-hm, purchase-return, scheme-gold-adjust, tag-adjust and tour-order. | N190 |
| G201 | Med | The Purchase Return Register lists no return on a web-provisioned company | `unified/src/csharp/DataCareNext/MS_UPDATE.cs` | `web/apps/api/src/modules/reports/reports6.ts`; `web/apps/api/src/modules/ops/seedCompany.ts` | Found by `purchase-return.report.register-lists-return`: after saving PRT returns the register shows "No rows". The register keeps books with `BOOK_TBL_NAME = 'PR_DATA'` and a name containing "return" (`reports6.ts:50-55`), and `seedCompany` provisions PRT (and PR, SL, SRT) with `BOOK_TBL_NAME` NULL (`seedCompany.ts:174`, no `table`). The desktop sets `BOOK_TBL_NAME = 'PR_DATA'`, `BOOK_TBL_DETL = 'PR_DETL'` for every PURCHASE, PURC RETURN, CON PUR, TAG PURCHASE and PR QUOT book (`MS_UPDATE.cs:7849`, `:16402`). | N191 |
| G202 | Low | The Standard plan had no order inside Standard and no per-tier progress | `unified/src/csharp/DataCareNext/MDI_FORM.cs` | `docs/master-parity-plan-2026-09-29/15-standard-edition-plan.md` | The desktop builds Standard from three cumulative tiers (Lite `L`, Basic `B`, Standard `S`; `MDI_FORM.cs:11278-11299`), but document 15 ordered all 114 menus by screen family and reported one number. The owner asked on 31 October 2026 for Lite to be completed first and the further editions after it (D32); the plan needs that order and a progress view per tier. | N192 |
| G203 | Med | A cheque receipt or payment lost its cheque number on the ledger | `unified/src/csharp/DataCareNext/Ac_Ledr.cs` | `web/apps/api/src/modules/finance/finance.ts` | Found by `cash-bank.create.cheque-receipt`: the cheque number was saved on CASH_DATA but every AC_DATA leg had an empty CHQ_NO, while the desktop `Bank_Ledr` (`Ac_Ledr.cs:585-593`) writes `A.CHQ_NO` on each leg; bank reconciliation and cheque reports read it from the ledger. | N193 |
| G204 | High | Contra Entry was a fixed two-account form, not the desktop grid | `unified/src/csharp/DataCareNext/TR_CONTRA.cs` | `web/apps/web/app/(app)/txn/contra/page.tsx` | Found while writing the contra module: the desktop grid holds any number of rows and writes a CONTRA_DATA pair per row against row 1 (`TR_CONTRA.cs:2760-2866`), one Contra_Ledr leg per row, and refuses unequal totals with its own message (`:2694`); the web took one Dr and one Cr account, wrote one row with both amounts and used its own wording. A shop could not deposit cash into two banks in one voucher. | N194 |
| G205 | High | Sales Order line priced on fine weight with paise | `unified/src/csharp/DataCareNext/TR_SALE_ORD.cs` | `web/apps/api/src/modules/sales/salesOrder.ts`; `web/apps/web/lib/salesOrderForm.ts` | Found by `sales-order.formula.whole-rupees` and `sales-order.create.amounts`. The desktop prices a line's metal as weight × rate rounded to whole rupees, the weight following SL_AMT_TYPE: fine for F, gross for G, otherwise net + ghat (`TR_SALE_ORD.cs:6560-6672`). The bill takes tax as round(net × %, 0) and the total as round(net + tax, 0) (`:11340-11342`). The web always uses the fine weight and keeps paise (`salesOrder.ts` `calculateOrderLine`, `fineWt` then `round2(fine × rate)`), and `billTotals` runs without a rounding policy, so tax keeps paise. Net 10 g, touch 91.6, rate 6,123.45, labour 237.5 /g on a company with SL_AMT_TYPE N: desktop 61,234 + 2,375 = 63,609, tax 1,908, total 65,517; web 56,090.80 + 2,375 = 58,465.80, tax 1,753.97, total 60,220. | N196 |
| G206 | Med | Sales Order takes one cash advance and stores no tender breakdown | `unified/src/csharp/DataCareNext/TR_SALE_ORD.cs`; `unified/src/csharp/DataCareNext/Ac_Ledr.cs` | `web/apps/web/app/(app)/txn/sales-order/page.tsx`; `web/apps/api/src/modules/sales/salesOrder.ts` | Found by `sales-order.create.header-tender` and `sales-order.create.tender-modes`. The desktop advance is the sum of its tender rows: cash, UPI, cheque, card, old gold, old silver and scheme (`TR_SALE_ORD.cs:11368`); each is stored on SL_ORD_DATA (`:9126-9142`: CASH_AMT, UPI_AMT, CHQ_AMT, CARD_AMT, OLD_GL_AMT, OLD_SL_AMT, SCHM_AMT) and Order_Ledr posts each to its own account (`Ac_Ledr.cs:28-61`, legs 01-06 and 12-13). The web screen has one Advance amount, saved as ADV_AMT with CASH_AMT 0, and shows the other tender fields read-only. | N197, N222, N225 |
| G207 | Med | Order advance debits the sales account on a provisioned company | `unified/src/csharp/DataCareNext/Ac_Ledr.cs`; `unified/src/csharp/DataCareNext/Ac_Rojmel.cs` | `web/apps/api/src/modules/ops/seedCompany.ts` | Found by `sales-order.create.advance-ledger`: a 5,000 cash advance posts Dr SALES / Cr customer. Order_Ledr debits the order book's BOOK_DETL slot 1 with CASH_AMT (`Ac_Ledr.cs:28-35`) and Order_Rojmel uses slot 1 as the advance contra (`Ac_Rojmel.cs:11`); on the real data slot 1 of book 020 is 00001, the cash account (recorded in `salesOrder.ts`). `seedCompany.ts:219` gives the SOR book the sale layout (1 SALES, 2 CASH, 3 ROUNDOFF). | N198 |
| G208 | Med | A sale cannot adjust an order advance on a provisioned company | `unified/src/csharp/DataCareNext/Ac_Rojmel.cs` | `web/apps/api/src/modules/ops/seedCompany.ts`; `web/apps/api/src/modules/sales/sales.ts` | Found by `sales-order.journey.order-to-sale`: Sales Invoice with Ord No and Order Amt answers 400 "book SL account row 4 is missing". Sales_Rojmel posts the sale's ADV_AMT against BOOK_DETL slot 4 (`Ac_Rojmel.cs:96`) and `sales.ts` resolves slot 4 when an advance applies, but provisioned sale books get slots 1-3 only. | N198 |
| G209 | High | Party Opening was a balanced multi-account voucher, not the desktop's per-party opening | `unified/src/csharp/DataCareNext/TR_AC_OPBL.cs`; `unified/src/csharp/DataCareNext/Ac_Ledr.cs` | `web/apps/web/app/(app)/txn/ac-opbl/page.tsx`; `web/apps/api/src/modules/finance/partyOpening.ts` | Found while writing the Party Opening case list: the desktop keeps one OP_DATA row per party in book '000' with Cr/Dr signs (`TR_AC_OPBL.cs:2694-2722`) and posts it through AcOp_Ledr (`Ac_Ledr.cs:9-28`) as up to six legs dated the day before the year opens. The web numbered an 'ACO' voucher, demanded that debits equal credits, wrote no OP_DATA and had no reopen, edit, list or desktop messages, so a shop could not enter one party's opening on its own. The balanced-voucher module is removed. | N199 |
| G210 | High | Openings were counted twice in party balances and written in a shape the desktop does not read | `unified/src/csharp/DataCareNext/DC_Main.cs`; `unified/src/csharp/DataCareNext/BtmSchm.cs` | `web/apps/api/src/modules/finance/partyBalance.ts`; `web/apps/api/src/modules/masters/year.ts`; `web/apps/api/src/modules/finance/partyOpening.ts` | The desktop balance reads AC_DATA alone (`DC_Main.MsAcBal`, `DC_Main.cs:1463`), where the opening legs already are; the web added OP_DATA on top, so a migrated desktop opening (117 legs in the migrated data, all in AcOp_Ledr's layout) counted twice. The inline opening (a separate module, now removed) and the year carry-forward wrote OP_DATA in books 'OPN' and 'OPB' with '+'/'-' metal signs and no legs, and the carry-forward dropped silver. | N199 |
| G211 | Med | Party Opening had no bill-wise grid | `unified/src/csharp/DataCareNext/TR_AC_OPBL.cs` | `web/apps/web/app/(app)/txn/ac-opbl/page.tsx` | The desktop screen has a bill-wise grid saved to OP_DETL (`TR_AC_OPBL.cs:2724-2760`) whose signed totals set the opening heads (MSG_TOT_FILL), with the fine worked out from net weight, touch and wastage (CommPassTotal); the web kept existing OP_DETL rows but could not show or edit them. The desktop Print button only checks print rights (`:2626-2633`) and prints nothing. | N200 |
| G212 | Med | Year End close and Balance TrFr write next-year openings in two different shapes | `unified/src/csharp/DataCareNext/BtmSchm.cs`; `unified/src/csharp/DataCareNext/Ac_Final.cs` | `web/apps/api/src/modules/ops/yearEnd.ts`; `web/apps/api/src/modules/masters/year.ts` | Found while moving the carry-forward to the Party Opening writer: year-end close writes '000' ACOP legs with its own key and no OP_DATA, while Balance TrFr now writes OP_DATA and AcOp_Ledr legs. Running one after the other can leave both sets of legs, counting the opening twice. | N201 |
| G213 | Med | Deployments ran Standard while only Lite was being completed | `unified/src/csharp/DataCareNext/MDI_FORM.cs` | `web/apps/api/src/modules/ops/runtimeConfig.ts`; `web/apps/api/src/modules/rbac/editionGate.ts` | The owner asked for the Lite edition to be completed first with the other menus held back as Beta (D33); the API defaulted to Standard, so 65 Basic and Standard menus that are not yet verified were open to users. Running Lite also showed that Lite screens read the company settings through the Basic Settings route, which the Lite gate would refuse. | N202 |
| G214 | High | Reopening a tag voucher and saving it unchanged blanked most of its fields | `unified/src/csharp/DataCareNext/TR_TAG_OPBL.cs` | `web/apps/web/app/(app)/txn/tag-opening/page.tsx` | The desktop reloads 87 BAR_DETL columns into the grid when a voucher opens (`TR_TAG_OPBL.cs:10452-10574`) and the stock item with it (`:10398`). The web reopen copied 15 of the 65 line fields, so an unchanged save rewrote the tag with blank hallmark ids and weights, karigar costing, JDT weights and order and manufacturing links; the reopened Fine column showed the formula instead of the stored fine. | N203 |
| G215 | High | Only Tag Entry was not a working menu | `unified/src/csharp/DataCareNext/MDI_FORM.cs`; `unified/src/csharp/DataCareNext/TR_TAG_OPBL.cs`; `unified/src/csharp/DataCareNext/MS_UPDATE.cs` | `web/apps/web/lib/nav.ts`; `web/apps/web/app/(app)/txn/tag-opening/page.tsx`; `web/apps/api/src/modules/ops/seedCompany.ts` | The desktop opens TR_TAG_OPBL on the TAG GEN books for Only Tag Entry (`MDI_FORM.cs:8574-8584`), provisions them (`MS_UPDATE.cs:17020-17036`) and refuses a save without the stock item the tags are made from ("Stock item code Insert First...", `TR_TAG_OPBL.cs:10813-10818`). The web had no TAG GEN book and no menu entry, and showed the stock item on every tag opening. | N203 |
| G216 | High | Tag opening stock rows did not follow Tag_Opbl_Stk, and its refusals used web wording | `unified/src/csharp/DataCareNext/Ac_Stock.cs`; `unified/src/csharp/DataCareNext/TR_TAG_OPBL.cs` | `web/apps/api/src/modules/stock/stockVoucherLifecycle.ts`; `web/apps/api/src/modules/shared/desktopMessages.ts` | `Ac_Stock.Tag_Opbl_Stk` (`Ac_Stock.cs:22-36`) writes an opening tag as P / 'TAGOP' / 'TAG OPBL' with ITM_QTY 1 and the tag's wastage, labour rate, karigar cost and design; an Only Tag Entry tag as I / the book's short name / 'TAG GEN'; and one 'O' row per voucher taking the stock item out by the voucher's totals. The migrated data agrees (1169 P rows, 159 I rows, 31 relief rows with TAG_NO 'N'). The web wrote 'TAGOP' and the book's own name for both menus, TR_TYPE P for TAG GEN tags and ITM_QTY = pieces, and one relief row per tag whenever a stock item was sent, so an opening voucher could take loose stock out. A tag typed twice and the delete of a sold tag were refused with web texts instead of "Duplicate Tag No" (`:8562`) and "You Cant Delete This Voucher Because  Tag Use in Sales Transection...." (`:11383`). | N203 |
| G217 | Med | The tag grid's karigar weight block is not saved | `unified/src/csharp/DataCareNext/TR_TAG_OPBL.cs`; `unified/src/csharp/DataCareNext/Ac_Stock.cs` | `web/apps/api/src/modules/stock/stockVoucherLifecycle.ts`; `web/apps/web/app/(app)/txn/tag-opening/page.tsx` | Found in the Chrome check of N203: the desktop grid carries KrOthWt, KrNwt, KrGht%, KrGht, KrTouch, KrWst% and KrFine (columns 17-23, `TR_TAG_OPBL.cs:5146-5172`), works out KrNwt = gross − KrOthWt and KrFine = (KrNwt + KrGht) × (KrTouch + KrWst%) / 100 (`:6686-6826`), saves them to BAR_DETL (`:9325-9330`), and Tag_Opbl_Stk copies them to MAIN_STOCK KR_NWT, KR_TOUCH, KR_WEST and KR_FINE. All 1359 migrated tag stock rows carry KR_NWT. The web has no input for them, so they stay 0. | N204 |
| G218 | Med | Browser suites could test an older build | — (test infrastructure) | `web/apps/web/next.config.mjs`; `web/apps/web/test/real-stack-target.mjs`; `web/apps/web/test/features/harness.mjs` | Found while verifying N203. The build clears the route cache (N186), but turbo replays a cached web build without running that step, so the pages a previous server cached survived and a fresh `next start` served an older chunk (`x-nextjs-cache: HIT`); a full feature run failed the reopen case on it. Separately, a suite whose ports were still held by a demo stack got a 200 from that stack's readiness probe and ran against its build: the new Next server could not bind the port. | N205 |
| G219 | High | Fine Jv Entry was a reduced two-account form with reversed fine signs, and the routes sharing CONTRA_DATA reached each other's books | `unified/src/csharp/DataCareNext/MDI_FORM.cs:8360-8365`; `unified/src/csharp/DataCareNext/TR_CONTRA.cs:1426-1446,2666-2890,2951-2968,3000-3069`; `unified/src/csharp/DataCareNext/Ac_Ledr.cs:846-848`; `unified/src/csharp/DataCareNext/Ac_Rojmel.cs:342-344`; `unified/src/csharp/DataCareNext/Ac_Tax.cs:686-694` | `web/apps/api/src/modules/finance/fineJv.ts`; `web/apps/api/src/routes/fineJv.ts`; `web/apps/web/app/(app)/txn/fine-jv/page.tsx`; `web/apps/api/src/modules/finance/contra.ts`; `web/apps/api/src/modules/finance/journal.ts`; `web/apps/api/src/modules/finance/contraVoucher.ts` | The desktop screen is the TR_CONTRA grid in FINE JV mode: row 1 is paired with every later row, the row is written first as LDR_TYPE 0 with its own side and description and row 1 is mirrored as LDR_TYPE 1 (`TR_CONTRA.cs:2760-2847`); each CR_FINE row posts a `STR(SR_NO)+'03'` `+` leg and each DR_FINE row a `'04'` `-` leg (33-character keys, `Ac_Ledr.cs:846-848`); Vch_Remark rebuilds REMARK_DATA from described rows; save refuses a missing mandatory employee, a new voucher in a type-B company, a date outside the year and unequal totals with the desktop texts; FineJvBill prints 'Gold '/'Silver ' + BOOK_NAME, the IT_DESC line and the signature footer. The web stored To as DR_FINE, offered one From/To pair, keyed legs with a 2-wide line number, named TEMP_BOOK_DATA after MAIN_BOOK, skipped the fiscal-date, employee and company-type checks, kept stale desktop flags, never wrote REMARK_DATA, and its Contra and Journal routes could read, rewrite, delete or print a FINE JV voucher; their documents needed only view rights. | N206 |
| G220 | Med | The generic voucher list and number-box routes read any book of an allow-listed table | `unified/src/csharp/DataCareNext/MDI_FORM.cs:8100-8111,8360-8365`; `unified/src/csharp/DataCareNext/TR_CONTRA.cs:3136-3146` | `web/apps/api/src/routes/voucherNavigation.ts`; `web/apps/api/src/modules/vouchers/list.ts`; `web/apps/api/src/modules/rbac/routePolicy.ts` | Found in the N206 review. `GET /vouchers/recent` and `GET /vouchers/neighbour` are SYSTEM routes that take the table and book from the request, so any signed-in user of the company can list another menu's vouchers of a shared table (for example a Fine JV book through CONTRA_DATA) with their dates, accounts and totals, within the session's tenant, company, location and year. The desktop's list (TR_CONTRA.cs:3136-3146) only lists the open form's own book. The routes should require view rights on the form that owns the requested book. | N207 |
| G221 | High | Daily Rate did not follow MS_RATE and its save deleted other locations' rates | `unified/src/csharp/DataCareNext/MS_RATE.cs:1752-2109,2314-2458` | `web/apps/api/src/modules/masters/dailyRate.ts`; `web/apps/api/src/routes/dailyRate.ts`; `web/apps/web/app/(app)/txn/daily-rate/page.tsx`; `web/packages/core/src/dailyRate.ts` | The desktop lists the groups with a touch (GR_TYPE, GR_NAME), derives TaxRate = Round(Touch × Gold / 100) (silver / 10000) with Rate10gm net of the group's Tax% and PrRate from the purchase touch, using banker's rounding, and saves the grid per company, location, year and date. The web derived silver per kg, added tax on top, rounded half up, used one Tax% for every group, deleted every location's rows for the date, read and listed without the location, wrote GR_NAME, had no delete or print, and allowed any save without edit rights. | N208 |
| G222 | High | Item Opening was not the desktop TR_ITM_OPBL metal-type grid | `unified/src/csharp/DataCareNext/TR_ITM_OPBL.cs`; `unified/src/csharp/DataCareNext/Ac_Stock.cs`; `unified/src/csharp/DataCareNext/MDI_FORM.cs:7690-7699` | `web/apps/web/app/(app)/txn/item-opening/page.tsx`; `web/apps/api/src/modules/stock/stockVoucherLifecycle.ts`; `web/apps/api/src/routes/txn.ts` | The desktop opens TR_ITM_OPBL directly, with no book help (`MDI_FORM.cs:7690-7699`). Enter on the Item Type select lists every item of that metal type (`TR_ITM_OPBL.cs:1269-1370`) in a 17-column grid with a Total row, and Save replaces the type's rows in book '000' with VCH_NO = the type letter (`:1380-1490`); the stock rows come from `Ac_Stock.Itm_Opbl_Stk` (`Ac_Stock.cs:11-21`: AC_CODE '00000', VCH_TYPE ITOBL, BOOK_NAME 'ITM OPBL', P / +, the KR_* fields, dated the year's opening date less one day) and DM_DATA from `Dm_Itm_Opbl_Detl` for OTH_DETL_POSTING items (`:734-741`). The web wrote a numbered BAR_DATA voucher in book IOP on the voucher date; its fine ignored the wastage, its stock rows lacked those fields, it wrote no per-type ITM_OPBL rows and no DM_DATA, and its grid had no West%, labour, other amount, net amount or totals. | N209 |
| G223 | Med | Tag Cancel had no print, accepted a new voucher in a type B company and answered the lock and fiscal refusals with web wording | `unified/src/csharp/DataCareNext/TR_TAG_CAN.cs:4950-4990,5330-5345,5386-5440` | `web/apps/api/src/modules/stock/tagCancel.ts`; `web/apps/api/src/modules/stock/tagCancelBill.ts`; `web/apps/web/components/TagCancelForm.tsx` | The desktop refuses a new voucher when CO_TYPE is 'B', a date outside the year and a date on or before the lock date with its own texts, in that order, and prints TagCanBill behind UserPrint. The web had no print route, never checked the company type, checked the lock after reading the lines and answered with "period is locked …" / "voucher date … is outside fiscal year …". | N210 |
| G224 | Medium | The Employee master was a generic field form, not the desktop MS_EMP screen | `unified/src/csharp/DataCareNext/MS_EMP.cs`; `unified/src/csharp/DataCareNext/MDI_FORM.cs:7660-7669`; `web/apps/api/form-specs/DataCareNext.MS_EMP.layout.json` | `web/apps/web/app/(app)/masters/[name]/page.tsx`; `web/apps/api/src/modules/masters/configs.ts`; `web/apps/api/src/modules/rbac/formCatalog.ts` | The desktop opens MS_EMP from the 'Employee' button, whose caption is the USER_SET SUB_MENU (`MDI_FORM.cs:7660-7669`, `:7034`). The screen has a SEARCH RECORD box over a Code / Name list ordered by name, and Employee Code, Employee Name, Account Code with the account name, User Name (the company-01 login names), Amount and Day Hour, in that tab order (form spec). A new entry takes the next code ('001', else the highest + 1 as "000", `MS_EMP.cs:1260-1268`); leaving the code or name refuses one another employee has (`:1350-1411`); Save replaces the row with Val of the numbers, 'ABC' for a blank user and the creator (`:1462-1550`); Delete refuses the default employee '001' (`:1552-1584`). The web rendered the generic master form, which showed EMP_TYPE, TDS and PF as typed boxes, had no search list, next code, duplicate checks, desktop texts or account help, and the rights alias 'Employee' was missing, so a desktop USER_SET row gave no access. Not closed here: the EmpMast report layout is not in the repository, so Print lists the employees on screen; the help list's create path (MsCreat opens MS_ACCT with group 10, `:1659-1665`) is shared MS_HELP behaviour left to the Party master slice. | N211 |
| G225 | High | Desktop rights rows named by the menu caption did not reach fifteen Lite screens | `unified/src/csharp/DataCareNext/MDI_FORM.cs:7034-7046`; `unified/src/csharp/DataCareNext/MDI_FORM.cs:7610-8951`; `unified/src/csharp/DataCareNext/TR_AC_OPBL.cs:2020-2030` | `web/apps/api/src/modules/rbac/formCatalog.ts`; `web/apps/api/src/modules/rbac/authorization.ts`; `web/apps/api/src/routes/partyOpening.ts` | The desktop reads USER_SET by LC_CODE, USER_NAME and SUB_MENU = the menu button's caption (MsUserRightForm = MsSideBtn, `MDI_FORM.cs:7034-7046`), so a migrated or desktop-written rights row names the caption. The web matches a row against the form's name and aliases, and the captions Address, Product, Group, AutoItem, Tax, Party Opening, Purchase Rtn, Approval Isu, Approval Rtn, Fine Jv Entry, Tag Stock, Sales Report, Purchase Rpt, Cash Bank and Gst Report were not aliases of the forms their screens use: a restricted user with the desktop's rights was refused. Party Opening's Save also ignored FRM_EDIT for an existing opening (`TR_AC_OPBL.cs:2647-2650`). Not closed here: captions whose screens also use another menu's form (Company, Data Refresh, Data Import, Order Report, Cash Received, Bank Received, and Approval Rtn's issue lines), and 14 Basic and 19 Standard menus, which follow their tiers. | N212 |
| G226 | High | The Tax master was a generic field form that could not edit a code's components, and its generic update rewrote them | `unified/src/csharp/DataCareNext/MS_TAX.cs`; `unified/src/csharp/DataCareNext/MDI_FORM.cs:7670-7679`; `web/apps/api/form-specs/DataCareNext.MS_TAX.layout.json` | `web/apps/web/app/(app)/masters/[name]/page.tsx`; `web/apps/api/src/modules/masters/master.service.ts`; `web/apps/api/src/modules/masters/configs.ts`; `web/apps/web/components/LookupPicker.tsx` | MS_TAX edits a tax code as a header row (SR_NO 0, TAX_GROUP 'N') with a grid of component rows (SR_NO 1, 2, …: SGST, CGST, IGST), which the sale and purchase postings read by SR_NO; Save replaces every row of the code (`MS_TAX.cs:1824-1933`). The web rendered the generic one-row form keyed by CO_CODE + TAX_CODE: it listed the component rows as duplicates, could not add or change a component, and its update wrote the header's name and rate into every component row of the code, so an edited GST code taxed SGST, CGST and IGST at the full rate. It had no desktop keys, texts, account helps or Print. The browser check also found the shared account picker replacing a row chosen from its help with the typed text's exact code on leave. Not closed here: web provisioning keeps its tax accounts in group 30, outside the desktop help's group 12 (N58), and the Sales screen resolves the code by rate rather than from the desktop's tax-code help (`TR_SALE.cs:18668`), refusing a rate another code's component carries. | N213 |
| G227 | High | The Item Group master was a generic field form without the desktop's item update, helps, texts or Print | `unified/src/csharp/DataCareNext/MS_GROUP.cs`; `unified/src/csharp/DataCareNext/MDI_FORM.cs:7630-7636`; `web/apps/api/form-specs/DataCareNext.MS_GROUP.layout.json` | `web/apps/web/app/(app)/masters/[name]/page.tsx`; `web/apps/api/src/modules/masters/configs.ts`; `web/apps/api/src/modules/masters/master.service.ts` | MS_GROUP keeps an item group's metal type, trade type, touches, melting and wastage, the sales and purchase accounts the postings use per group, the HSN code and the rate tax %, and its Save sets the trade type, item type and HSN code on every item of the group (`MS_GROUP.cs:1825-1919`, `:1887`). The web rendered the generic form: its Item Type offered only Gold and Silver of the desktop's seven, the trade type box and the Rate Display check box were missing, the account boxes searched every account instead of groups 25 and 30, the save did not update the group's items (so a changed HSN code never reached the invoice), the delete question, the in-use refusal order and Print were missing, and none of the desktop keys or texts applied. Not closed here: web provisioning keeps CAPITAL in group 25 and its GST and TCS accounts in group 30 while SALES and PURCHASE sit in 20 and 21, so the desktop helps list the wrong accounts on a web-provisioned company (N58). | N214 |
| G228 | Medium | The Product master was a generic field form without the desktop's guards, keys or texts | `unified/src/csharp/DataCareNext/MS_PRODUCT.cs`; `unified/src/csharp/DataCareNext/MDI_FORM.cs:7620-7628`; `web/apps/api/form-specs/DataCareNext.MS_PRODUCT.layout.json` | `web/apps/web/app/(app)/masters/[name]/page.tsx`; `web/apps/api/src/modules/masters/configs.ts` | MS_PRODUCT in Product mode keeps a two-character code and a name; its Save replaces the row with the signed-in user, and its Delete asks first and then refuses a product an item uses and the ten default products (`MS_PRODUCT.cs:2570-2804`). The web rendered the generic form: it had no item-use or default-product guard, no delete question, none of the desktop keys (Up and Down to the list, Enter on the name to Save) or texts, and it kept MAIN_USER from an earlier save where the desktop writes the signed-in user. | N215 |
| G229 | High | Cash/Bank and Contra accepted a date outside the year, and the Contra recent list showed Total 0 | `unified/src/csharp/DataCareNext/TR_CASH.cs:2934-2947`; `unified/src/csharp/DataCareNext/TR_CONTRA.cs:2680-2691,3140-3144` | `web/apps/api/src/modules/finance/finance.ts`; `web/apps/api/src/modules/finance/batchReceipt.ts`; `web/apps/api/src/modules/finance/contra.ts`; `web/apps/api/src/modules/vouchers/list.ts` | TR_CASH and TR_CONTRA refuse a voucher dated outside the open year with "You Cant Save Entry Because Voucher Date Not In Current Year... Please Change Date...", before the lock-date check and before any write. The web receipt, payment, multi-line, multi-party receipt and Contra writers saved such vouchers (a Contra dated 2026-03-31 in year 2026-2027 answered 201). The recent-voucher list reads one of nine amount columns, none of which CONTRA_DATA has, so every Contra listed Total 0 where the desktop list sums the voucher's CR_AMT and DR_AMT. | N216 |
| G230 | Medium | The Address master was a generic field form without the desktop's tabs, combos, helps, mobile check, delete cascade or next code | `unified/src/csharp/DataCareNext/MS_ADD_MAST.cs`; `unified/src/csharp/DataCareNext/MDI_FORM.cs:7610-7619`; `web/apps/api/form-specs/DataCareNext.MS_ADD_MAST.layout.json` | `web/apps/web/app/(app)/masters/[name]/page.tsx`; `web/apps/api/src/modules/masters/configs.ts` | MS_ADD_MAST keeps a location's addresses on three tabs, offers the next code of the location, fills its combos from the company's addresses and STATE_MAST, refuses a mobile the company already has, and deletes an address with its opening rows of the year (`MS_ADD_MAST.cs:3119-4544`). The web rendered the generic form keyed by CO_CODE + AC_CODE: no tabs, no next code, no combos, help or name type-ahead, no mobile check, its config left the three dates out as if the account master kept them, and its delete left the address's OP_DATA and AC_DATA opening rows behind. | N217 |
| G231 | High | The Item master was a generic field form without the desktop's helps, item code from product and group, exists question, leave checks, settings boxes, delete checks or Tag Value Update | `unified/src/csharp/DataCareNext/MS_ITEM.cs`; `unified/src/csharp/DataCareNext/MDI_FORM.cs:7650-7659`; `web/apps/api/form-specs/DataCareNext.MS_ITEM.layout.json` | `web/apps/web/app/(app)/masters/[name]/page.tsx`; `web/apps/api/src/modules/masters/configs.ts`; `web/apps/web/lib/lookupEnter.ts` | MS_ITEM takes the product and group from their helps, makes the item code and name from them and asks before reusing a code, refuses a taken code or name on leaving it, shows the setting-driven boxes, writes the combo letters and Val of the number boxes, refuses deleting an item with stock or a default code, and updates the item's tags from its Tag Value Update panel (`MS_ITEM.cs:2748-4015`). The web rendered the generic form: free-typed product and group, no item code or name from them, no question or leave checks, no setting-driven boxes, a delete that only failed on a foreign key, and no tag update. Its lookups also dropped every answer for a box that upper-cases typing. | N218 |
| G232 | High | Auto Item reversed the desktop's item code, offered the default products and had no group help, grid keys, MinStk, rights or most columns | `unified/src/csharp/DataCareNext/MS_AUTO_ITEM.cs`; `unified/src/csharp/DataCareNext/MDI_FORM.cs:7640-7649` | `web/apps/web/app/(app)/masters/auto-item/page.tsx`; `web/apps/api/src/modules/masters/autoItem.ts`; `web/apps/api/src/routes/txn.ts` | MS_AUTO_ITEM's AutoItem mode lists the company's products but the default ones for a group chosen from its help, marks the ones the group already has, and makes PR_CODE + GR_CODE items named product name + group code with the desktop's columns, under the edit right (`MS_AUTO_ITEM.cs:1640-3493`). The web made GR_CODE + PR_CODE items named group + product, wrote eight columns, offered every product including the default ones, and had no group help, grid keys, MinStk, rights or Print and Delete checks. | N219 |
| G233 | High | Wh Sales saved what TR_WH_SALE refuses, and had no print | `unified/src/csharp/DataCareNext/TR_WH_SALE.cs:12779-12896`, `:13553-13592`, `:13654-13800`; `unified/src/csharp/DataCareNext/TR_TOUR_SALE.cs:10585-10690` | `web/apps/api/src/modules/sales/rateCut.ts`; `web/apps/web/components/WholesaleVoucherForm.tsx` | TR_WH_SALE refuses a save for a defaulter party left owing, a missing mandatory employee, a new voucher in a type-B company, a cheque or card amount without its bank account, a date outside the year, a date on or before the lock date and a grid row with weight or value but no item code, each with its own text, before it writes. The web saved every one of them: a cheque without a bank posted to the cash slot, an item-less receive row posted as received fine, and the lock date was refused with web wording. The delete asked a web question and Print (WhSalesBill) did not exist. | N220 |
| G234 | High | Stock Adjust was a separate writer citing a desktop form that does not exist, posting stock rows the desktop never writes, with no register, sign rule, lot columns, reopen or print | `unified/src/csharp/DataCareNext/TR_TAG_CAN.cs`; `unified/src/csharp/DataCareNext/MDI_FORM.cs:8616-8627`; `unified/src/csharp/DataCareNext/Ac_Stock.cs:48-58`; `unified/src/csharp/DataCareNext/MS_UPDATE.cs:24207` | `web/apps/web/app/(app)/txn/stock-adjust/page.tsx`; `web/apps/api/src/modules/stock/stock.ts`; `web/apps/api/src/modules/ops/seedCompany.ts` | The Stock Adjust menu opens TR_TAG_CAN on a STOCK ADJUST book: the Tag Cancel grid with a + / - Sign column and optional lot columns, a signed register, MAIN_STOCK rows in or out by sign, LOT_DETL rows for a lot, reopen, edit, delete and TagCanBill (`TR_TAG_CAN.cs:2514-5440`, `Ac_Stock.cs:53`, `:642-646`). The web had its own writer that cited a form TR_STK_ADJ, posted MAIN_STOCK rows with VCH_TYPE STADJ, BOOK_NAME STOCK ADJ and TR_TYPE A and no register, so nothing could be reopened or printed; and it provisioned the book as an in book with its code as the short name. | N221 |
| G235 | High | The Ledger Report was a single-account money statement with the wrong balance sign and none of the desktop's summary, drill-down, ageing or metal columns | `unified/src/csharp/DataCareNext/RP_LEDR.cs`; `unified/src/csharp/DataCareNext/MDI_FORM.cs:8871-8880` | `web/apps/api/src/modules/accounting/accounting.ts`; `web/apps/web/app/(app)/reports/[report]/page.tsx` | RP_LEDR is an account-summary screen (DGV_AC) that drills into a per-voucher or per-ledger-key detail (DGV_VCH/DGV_DETL) and a debit-ageing view (DGV_MONTH), reporting money AND signed gold/silver fine. The summary nets money as Σ(CR−DR), gold/silver as signed fine, splits a negative net to Dr and a positive net to Cr, and drops display-zero rows unless With Zero; detail keeps a running Σ(Cr)−Σ(Dr) balance with its side; voucher summary keeps gross Dr/Cr; ageing consumes the oldest debit first (`RP_LEDR.cs:6408-6435,6862-7266,7694-8205,9514-10314`). The web answered only `/reports/account-ledger/:acCode` with a money statement whose running balance used DR−CR (the opposite sign) and had no summary, drill-down, ageing, metal columns, selectors or Excel/CSV export. | N223 |
| G236 | High | The Party menu opened a generic page that skipped MS_ACCT's rules | `unified/src/csharp/DataCareNext/MS_ACCT.cs:5584-6587`, `:6606-7648`, `:7650-8025`, `:8162-8574`, `:9024-9640`; `unified/src/csharp/DataCareNext/MDI_FORM.cs:7600-7609` | `web/apps/web/app/(app)/masters/party/page.tsx`; `web/apps/api/src/modules/masters/master.service.ts` | Master → Party opens MS_ACCT: the location's Code / Name / Mobile list, the next code of the location, Company Detail and Other Detail with Enter in the form's tab order, the group, mobile, second mobile, short name, GST number, main account and reference checks, a new entry's opening (OP_DATA book 000 and the AcOp_Ledr legs), the AC_MAST_SRNO row, the photo, the D, S and A copy helps, Print and Delete with their refusals. The web's Party page saved only code, name, khata, mobile and group through the generic master (no group or default-account rule, no name check), set the opening through a second request after the account, had no delete or print, and AC_MAST lacked the five columns the desktop's updater adds (LCS_NO, TRN_DATE, CUST_ID_DATE, AC_WITH_MEMB_COM, AC_SHARE_HOLDER_COM). | N224 |
| G237 | High | Tag Print listed tags by range and skipped UT_TAG_PRINT's voucher, group and stock selection | `unified/src/csharp/DataCareNext/UT_TAG_PRINT.cs:1816-2077`, `:4735-5013`, `:5073-5226`, `:5284-5403`, `:5499-5635`, `:5636-5666`; `unified/src/csharp/DataCareNext/MDI_FORM.cs:8596-8605` | `web/apps/web/app/(app)/txn/tag-print/page.tsx`; `web/apps/api/src/modules/stock/tagPrint.ts` | Other → Tag Print opens UT_TAG_PRINT: Book and Vch No fill the grid with a voucher's tags, Gr Code, Pr Code and Item Type with the in-stock tags, a typed tag is looked up in the stock, Y/N and Ctrl+D choose the rows, Hm Id Update edits the four HM ids, weights, LRate, Mrp and Lbr%, Set marks the default label file, and Print copies each Y row's BAR_DETL row after the Lable Skip blanks. The web page listed in-stock tags by counter, item and tag range, had no voucher, group, product or item-type selection, no Y/N, no Hm Id Update and no default file, and its print staged by voucher only. | N225 |
| G238 | High | Four web defects found by un-blocking old browser cases: two operators saving one Daily Rate day hit the RATE_MAST key and the screen showed database text; the rate lookup ignored the session's location; every voucher form's lock-date refusal used a web-only message; and the Cash Received/Payment Employee box was sent by the page but dropped by the API | `unified/src/csharp/DataCareNext/MS_RATE.cs:1867-1947`; `unified/src/csharp/DataCareNext/TR_SALE.cs:12547`; `unified/src/csharp/DataCareNext/TR_CASH.cs:2753,2907-2911,2943,3050` | `web/apps/api/src/modules/masters/dailyRate.ts`; `web/apps/api/src/modules/masters/rate.ts`; `web/apps/api/src/routes/dailyRate.ts`; `web/apps/api/src/modules/posting/posting.ts`; `web/apps/api/src/modules/finance/lifecycle.ts`; `web/apps/api/src/modules/finance/finance.ts`; `web/apps/web/components/PaymentForm.tsx` | MS_RATE deletes the day and inserts it again with no lock, so the web (which keeps the RATE_MAST primary key) failed the second of two operators; saves of one day now run one after the other and the last writer's rows stay. TR_SALE reads RATE_MAST for the user's own CO_CODE and LC_CODE; the web lookup read every location. Every desktop voucher form refuses a locked date with "You Cant Save and Delete This Voucher Becouse Lock Date is = dd/MM/yyyy ...."; the web carried its own sentence. TR_CASH stores the Employee box on the voucher (:3050), refuses a blank one when CO_SET.EMP_CODE_MANDATORY = 'Y' (:2907-2911) and shows it again when the voucher is opened (:2753); the web page sent it and the API dropped it. Deliberate difference: the desktop fills the box with the logged-in user's employee code (:2671); the web session has no such field yet. | N226 |

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
| D30 | Purchase Return source limits and stone rows. G47 asks for residual-limited source selection and `PR_IDTL` stone writes, but the desktop does neither: `TR_KR_ISU.cs:6845-6880` lists purchase vouchers with their full weights, `:6882-6975` imports full `ITM_NWT`/`ITM_GWT` for PURC RETURN (the `ADJ_NWT` residual applies only to the approval branch, `:6918`, `:6943-6950`), and `PR_IDTL` is only deleted (`:5035`, `:5385`), never inserted; `Ac_Stock.cs:774-778` posts `DM_DATA` from `PR_DETL` alone. Recommended: follow the desktop (no residual limit, no stone rows) and keep the web's existing over-return guard for tags (a returned tag must be in stock and on the named purchase); record a residual limit, if wanted, as a Phase 2 product rule. Rejected: implementing G47 as written, which changes desktop results | Product owner and desktop specialist, before N34 closes — **accepted as recommended, 30 October 2026** (the owner delegated the decision to the implementer) | `web/apps/api/test/purchaseReturnEdit.routes.db.test.ts` |
| D31 | Edition-first delivery. Phase 1 is delivered one desktop edition at a time, Standard first: the menus the desktop shows when `DC_Main.MsSoftType` is `S`, i.e. `MENU_DATA` rows with `SM_TYPE` in `L`, `B`, `S` (`unified/src/csharp/DataCareNext/MDI_FORM.cs:11278-11286`), 114 menus listed in `docs/handbook/menu-editions.json`. Standard is built to production before any Ultra, Pro, Advance or Enterprise menu (78 deferred). Deferred features are not deleted or commented out: a snapshot branch keeps the pre-change state, and an edition gate hides them in navigation and rights and refuses their routes and APIs, as the desktop does by edition; for internal use they can be switched on as labelled Beta. Standard is complete only when all 114 menus pass their full browser case lists with no failing or blocked case (document 15 §6, confirmed by the owner on the evening of 30 October). Plan: document 15 | Owner instruction, 30 October 2026 — accepted | `docs/master-parity-plan-2026-09-29/15-standard-edition-plan.md` |
| D32 | Edition tier order inside Standard. Within D31, the work follows the desktop's edition tiers: first every Lite menu (the 49 `MENU_DATA` rows with `SM_TYPE` `L`) is made to work end to end like the desktop, then the 29 menus Basic adds (`B`), then the 36 menus Standard adds (`S`); the higher editions (Ultra, Pro, Advance, Enterprise) follow Standard as D31 says. Shared defects found on a Lite screen are still fixed once for every screen. Progress is reported per tier by the generated `docs/handbook/web/standard-progress.md` | Product owner — instruction, 31 October 2026 | document 15 §5 (Lite packages L1–L6, PR #162); `web/scripts/generate-standard-progress.mjs` |
| D33 | Lite is the running edition until Lite is complete. Deployments run the Lite edition by default (`APP_EDITION`, default `L`): the navigation lists only the 49 Lite menus, a higher edition's screen opened by URL is refused, and its API answers `403 edition-unavailable`. The Basic, Standard and higher menus are not deleted; with `APP_EDITION_BETA=1` they appear in the Beta group with a Beta notice for internal use. The company settings and the scale settings stay readable in every edition, because the desktop loads `CO_SET` when a company opens in every edition (`MS_OPNCOMP.cs:657-684`) | Product owner — instruction, 31 October 2026 | document 15 |

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

### N91 — Stock In/Out on a provisioned company (G105)

Found while continuing the 2026-10-26 browser run: on the freshly provisioned company the Stock In screen showed
an empty Book select and kept Save disabled. `web/apps/web/components/StockInoutForm.tsx:230,422` filters the book
list to the `INWORD` (Stock In) / `OUTWORD` (Stock Out) MAIN_BOOK, but `web/apps/api/src/modules/ops/seedCompany.ts`
provisioned 22 book families with neither, and seeded `LOCT_MAST` with no `AC_CODE`. The desktop ships both books
(`MDI_FORM.cs:8159`/`:8136`) and every location carries a branch account (`MS_LOCT.cs:3458`); the writer posts the
signed metal against that account (`web/apps/api/src/modules/stock/stockInout.ts:19-23,344-355`) and drops the
metal/ledger rows (`:760,807`) when it is blank, so even a hand-added book would have posted nothing.

Provisioning now adds a `BRANCH` stock-in-hand account (current-asset group), wires it to `LOCT_MAST.AC_CODE`, and
creates the `SIN` (`INWORD`) and `SOT` (`OUTWORD`) books. `web/apps/api/test/seedCompleteness.db.test.ts` asserts
both books and the branch account; `web/apps/api/test/stockInoutAmount.routes.db.test.ts` posts a Stock In and a
Stock Out through the real `/stock/in` and `/stock/out` routes against the seeded books and reconciles.

Done when: a provisioned company's Stock In/Out screens list a book and save, and the stock in/out routes post a
reconciling metal and ledger entry on the isolated database.

### N92 — Document previews use the company rounding policy (G102)

Found in the 2026-10-26 browser run: the nine document screens previewed `Math.round(taxable + tax)`, so the
operator saw a different total from the one the server posts — a purchase return previewed ₹20,865 but posted
₹20,865.23, and a sale previewed ₹75,319 but posted ₹75,318.75. The server already posts with the company
rounding policy (`TOT_AMT_ROF`/`TAX_ROF`, `TR_PURC.cs:15474-15502`), through `billTotals(input, policy)`; the
screens did not have the policy.

The rule `resolveRoundingPolicy` (and `roundNearest`) moved into `@datacare/core` so the server and the web
build the identical policy from the same flags — there is now exactly one source of truth. The API's
`web/apps/api/src/modules/shared/roundingPolicy.ts` re-exports it and keeps the server-only `PARITY_STRICT`
gate; `/me` carries the
company flags (`loadRoundingFlags`); and a web `useRoundingPolicy()` hook (session-scoped, kept separate from
`BusinessScope` so the scope object stays a clean query-parameter bag) builds the policy for the screens.
Purchase, sales, hallmark sale, sale return, purchase return, consignment purchase, estimate and both
quotations now preview with `billTotals(input, policy)`. A company with no configured flags keeps the 2dp
default, so nothing changes for it.

Done when: each document screen previews the total the server posts (verified by core vectors for the 1515
whole-rupee and the 75318.75 paise cases, the `/me` flag exposure, the full suite and the real-stack browser
suite with zero mocks). G84 (the hallmark preview also omitted other charges, a line-arithmetic gap, not
rounding) is resolved by N93.

### N93 — Document previews compose the line net as the server posts it (G84, G106)

Found resolving G84: the document screens built the line net inconsistently and none matched the server. The
desktop line total (`TR_SALE.cs` CommPassTotal, column 35) is **item + labour + other**; the per-line discount
and ghat amount are stored on their own columns (`SL_DETL.DISC_AMT`/`GHT_AMT`) and never fold into the line
net. The server matches this (`web/apps/api/src/modules/sales/sales.ts` and `web/apps/api/src/modules/purchase/purchase.ts`,
`calcLineNet({ metal, labour, other })`). The previews did not:

- hallmark sale, purchase, consignment purchase, purchase quotation, sale return and estimate previewed
  `metal + making` only, **omitting other charges** (G84 — a hallmark voucher previewed ₹63,056.35 and saved
  ₹67,414.53);
- sales and sales quotation previewed `recalcLine(...).totalAmount`, which **nets the line discount off
  labour and adds the ghat amount** — so a line carrying a `Line Disc %` or `Ghat Amt` (both editable grid
  columns) previewed a total the server does not post (G106).

Every document preview now composes the line net with `@datacare/core` `lineNet({ metal, labour, other })`,
exactly as the server does, keeping the discount and ghat on their own columns. A DB test
(`web/apps/api/test/sales.lifecycle.db.test.ts`) posts a line with a 10% discount and a ₹250 ghat and pins
`SL_DETL.NET_AMT` to metal + gross labour + other, so a preview can be checked against the server's rule.

Done when: each document preview totals the line net the server posts (metal + gross labour + other), proven by
the DB composition test, the web unit suite and the real-stack browser suite with zero mocks.

### N94 — Static gate: a request value may not be interpolated into raw SQL (G107, SP03)

The SECURITY-REVIEW recorded that the codebase always binds values as `$n` parameters and only interpolates
identifiers and SQL fragments into `$queryRawUnsafe`/`$executeRawUnsafe`, but that there was **no static rule**
enforcing it — so a future call could interpolate a request value and reopen SQL injection. This slice adds
that rule, the first SP03 (maintainability/safety boundary) ratchet of N88.

`web/scripts/sql-interpolation.mjs` is an AST checker (TypeScript compiler API, the same foundation
as the secret scanner) wired into `web/scripts/lint-workspace.mjs`. For every raw-unsafe call it
inspects **only the first argument** (the SQL template) and flags any `${…}` that reads a value out of the HTTP
request/input — `req`/`request`/`reply`/`body`/`query`/`params`/`input` used as a value, including a value
smuggled through a nested fragment template or a string concatenation. The vetted forms all pass: a `$n`-bind
placeholder index (`$${params.length + 1}`), an identifier sanitizer (`quoteIdent`), a column/SQL-builder call
(`n(...)`, `NN(...)`, `fineExpr(...)`, `*.join(...)`), and a SQL-fragment variable. The classifier is framed
around the injection vector rather than a name allow-list, because the codebase names fragments freely; the
builder allow-list is kept explicit so adding one is a reviewed change.

The gate reports zero findings on the current tree (192 raw-SQL files), and a planted `req.body` interpolation
fails `lint-workspace`. `web/scripts/sql-interpolation.test.mjs` (run first in the `lint` script)
proves both directions: eight dangerous shapes flagged, nine vetted shapes allowed.

Done when: the gate passes the clean tree, fails a planted request-value interpolation, and its test runs in
CI; recorded as the SQL-lint part of N88/SP03 (route plugins, error taxonomy, shared editor and size budgets
remain).

### N95 — Source file-size budget ratchet (G108, SP03)

The second SP03 ratchet of N88. `web/apps/api/src/routes/txn.ts` is 8,558 lines and nine modules exceed 1,500
(G79); N88 shrinks them by extracting route plugins and a shared voucher editor, but nothing stopped them from
growing further in the meantime. `web/scripts/check-size-budget.mjs` (baseline `web/parity/size-budget.json`,
wired into CI next to the depth and dead-cell gates) records every over-cap file's line count as a **ceiling
that may only fall** and caps every new source file at 1,500 lines. `--audit` re-derives counts from source and
`--write` only tightens an existing ceiling (never raises it silently), so a loosened ceiling is a reviewed
baseline diff, exactly as the depth ratchet works. The baseline holds 20 ceilings today, led by `txn.ts`.

`web/scripts/check-size-budget.test.mjs` (run first by the `size:budget` script) proves the ratchet flags a
tracked file grown past its ceiling and a new file over the cap, and passes a file at or below its ceiling; a
planted +5-line growth on `finance.ts` and a planted 1,600-line file both failed the gate locally and passed
after revert.

Done when: the budget passes the current tree, fails a tracked file that grows and a new over-cap file, runs
in CI, and its test runs first; recorded as the file-size-budget part of N88/SP03 (route plugins and the
typed error taxonomy remain).

### N96 — Old-metal conversion weight is derived, not trusted from the screen (G89)

The desktop derives an exchange row's conversion weight `cUrConWt` from Con% and the fine weight before valuing
the row (`TR_SALE.cs:7911-7942`); the web valued the row on the client-posted `conversionWt`, so a screen's (or
a tampered client's) arithmetic decided the stored `CON_WT` and the row amount. `@datacare/core`
`oldGoldConversionWeight` now derives it exactly as the desktop does — Con% > 100 is an uplift
(`round(fine × Con%/100, 3)`), 0 < Con% ≤ 100 is the usual lower purity (`round(fine/Con%×100 − fine, 3) +
fine`), Con% 0 means no conversion and falls back to the supplied weight (a legacy row). `valueOldGoldLine`
returns the derived weight and `oldGoldBasisWeight` values the row on it, so the sale writer stores the derived
`CON_WT` and the sale/sales-quotation previews (`oldGoldRowAmount`) show the same figure; the `KJ001NEKJ`
per-installation branch stays waived.

Verified: core vectors for each branch (`oldGold.test.ts`), the web preview test (`oldGoldRow.test.ts`), and a
DB write-set assertion in `sales.lifecycle.db.test.ts` where a row with Con% 92 and a tampered
`conversionWt: 0.1` stores `CON_WT = 4.207` (derived), not 0.1; full API+DB suite 313 files.

Done when: the writer and the previews derive `CON_WT` from `CON_PRC` and the fine; a posted weight is ignored
when a percentage is given; proven by kernel vectors and a DB assertion.

### N97 — Dhiran (pledge loan) books on a provisioned company (G109)

Found operating the production build as a shop user: the Pledge Loan Issue screen (`/txn/dhrn-issue`) rendered,
but its book select offered no Dhiran book — `seedCompany` provisioned 24 book families with no DHIRAN book, so
the operator could not post a pledge loan. The same class as the Stock In/Out gap (G105): the desktop opens
Pledge Loan Issue on MAIN_BOOK `DHIRAN ISSUE` and Pledge Receipt on `DHIRAN RECEIPT` (`MDI_FORM.cs:9527,9539`),
the issue writing `DHRN_ISU_DATA` and the receipt `DHRN_REC_DATA`.

`seedCompany` now provisions the `DHI` (DHIRAN ISSUE, out, `DHRN_ISU_DATA`) and `DHR` (DHIRAN RECEIPT, in,
`DHRN_REC_DATA`) books against the `DHRN` receivable, with the standard three posting legs. `seedCompleteness`
asserts both books exist with their routing tables; `provisioning.db.test.ts` book-group and leg counts were
updated (27 → 29 groups, 95 → 101 legs). The dhiran writer resolves its ledger accounts from the payload
(`loanAc`/`cashAc`), so the books need no bespoke slots.

Done when: a provisioned company's Pledge Loan Issue/Receipt screens offer a Dhiran book and post; a
seed-completeness DB assertion proves the books and their routing tables exist.

### N98 — Dhiran book lists filtered to their workflow family (G101 part)

Operating the production build after N97 showed the Pledge Loan Issue book select offering all 28 books — the
G101 class: a screen's `BookSelect` should offer only the MAIN_BOOK family its writer accepts, as each desktop
menu opens on `CurBookHelp(<MAIN_BOOK>)` (`MDI_FORM.cs:9527`/`9539` for dhiran). N90 did purchase and sales
return; this does the three Dhiran screens: Pledge Issue → `DHIRAN ISSUE`, Pledge Receipt → `DHIRAN RECEIPT`,
and Interest Receipt → `DHIRAN RECEIPT` (interest is entered on the receipt book; its `preferred` book code was
corrected from the non-existent `DIN` to `DRC`). Each passes `mainBooks={[…]}` to `BookSelect`, which already
filters the fetched list case-insensitively.

Browser-confirmed: after login on the seedCompany demo, the Pledge Loan Issue book select now shows only
`DHI — Dhiran Issue` (auto-selected), down from all 28 books, with no console errors. Typecheck, lint
(including the size budget), web unit 646 and the full gate battery pass.

Done when: the dhiran screens offer only their MAIN_BOOK family; the rest of G101's screens remain under N62.

### N99 — Journal, Item Lot and Tour book lists filtered (G101 part)

Three more G101 screens whose provisioned book's MAIN_BOOK matches the desktop `CurBookHelp` family exactly, so
filtering is safe (the preferred book is present, the list cannot empty): Journal → `JOURNAL` (seeded `JV`),
Item Lot → `ITEM LOT` (seeded `ILT`), and Tour/Approval Issue → `APPROVAL ISSUE` (seeded `TUR`). Each passes
`mainBooks={[…]}` to `BookSelect`. Browser-confirmed on the seedCompany demo: the Item Lot book select shows
only `ILT — Item Lot` (auto-selected), with no console errors.

The remaining unfiltered screens were deliberately left to N62: tag/item opening, manufacturing, fine JV,
hallmark sale, labour sale, batch receipt, bullion, fine in/out, tag weight difference and account opening —
their desktop MAIN_BOOK families (`LABOUR WORK`, `FINE JV`, `FINE SALE`, `BULLION`, `TAG OPENING`, …) are not
yet provisioned by `seedCompany`, so filtering them would empty the list until those books are seeded (a
provisioning follow-up), or they need a per-writer confirmation that the writer accepts the family.

Done when: Journal, Item Lot and Tour offer only their MAIN_BOOK family; the rest stay under N62.

### N100 — Labour Sale and Fine Settlement books on a provisioned company (G110)

Continuing the G101 review showed the next step was provisioning, not filtering: several screens' MAIN_BOOK
families were never seeded, so filtering them would empty the list. Labour Sale (`LABOUR WORK`,
`MDI_FORM.cs:8325`) and Fine Settlement (`FINE SALE`/`FINE PURC`, `:8505`/`:8493`) were two such — their books
were absent, so the screens had no book to select at all (the Stock In/Out and Dhiran class, G105/G109).

`seedCompany` now provisions `LBR` (LABOUR WORK → `LBR_DATA`), `FSL` (FINE SALE → `CUT_DATA`) and `FPR`
(FINE PURC → `CUT_DATA`), each with its single control slot, mirroring the authoritative
`labourFineTaxRows.routes.db.test.ts`. With the labour book present, the Labour Sale screen's book list is now
filtered to `LABOUR WORK` (G101). `seedCompleteness` asserts the three books and their routing tables;
`provisioning.db.test.ts` counts were updated (29 → 32 book groups, 101 → 104 legs, with LBR/FSL/FPR in the
single-slot leg list). The Fine Settlement screen's own book filter is deferred (its `BookSelect` sits in a
rate-cut sub-grid that needs separate analysis).

Done when: a provisioned company's Labour Sale and Fine Settlement screens offer their book; a seed-completeness
DB assertion proves the books and routing tables; the Labour Sale list is filtered.

### N101 — Tag Opening book on a provisioned company (G111)

The next screen in the provision-then-filter sweep. Tag Opening (TR_TAG_OPEN) opens tag stock — it writes
`BAR_DATA` and a positive `MAIN_STOCK` with no ledger leg (`stockVoucherLifecycle.ts` posts empty `AC_DATA`
lines) — but `seedCompany` provisioned no Tag Opening book, so the screen had no book to select (the Stock
In/Out, Dhiran and Labour/Fine class, G105/G109/G110).

`seedCompany` now provisions `TOP` (TAG OPENING → `BAR_DATA`) as a **ledger-less** stock book with empty slots,
mirroring `tagOpeningRoundTrip.db.test.ts`. Because it carries no ledger leg, it joins `WH QUOT` as a
legitimately BOOK_DETL-less book: the seed-completeness orphans check now allows both, and asserts the
ledger-less set is exactly `['TOP','WHQ']`. With the book present, the Tag Opening screen's list is filtered to
`TAG OPENING` (G101); the mocked-browser smoke's book mock was aligned to the real `TAG OPENING` MAIN_BOOK so
the filter keeps it (the same alignment the item-lot filter needed in N99).

Done when: a provisioned company's Tag Opening screen offers its book; a seed-completeness DB assertion proves
the ledger-less `TOP` book and its `BAR_DATA` routing; the list is filtered and the smoke passes.


### N102 — Fine In/Out book on a provisioned company (G112)

The provision-then-filter sweep continued to Fine In/Out (TR_FINE_INOUT), a pure metal movement writing
`INOUT_DATA` + signed `MAIN_STOCK` with no money ledger (`fineInout.ts` posts empty `AC_DATA`). `seedCompany`
provisioned no Fine In/Out book, so the screen had no book to select (the Stock In/Out, Dhiran, Labour/Fine and
Tag Opening class — G105/G109/G110/G111).

`seedCompany` now provisions `FIO` (FINE INOUT → `INOUT_DATA`) as a **ledger-less** metal-movement book with
empty slots, mirroring `fineInoutGrid.db.test.ts`. It joins `TAG OPENING` and `WH QUOT` in the
seed-completeness orphans allowance (the ledger-less set is now `['FIO','TOP','WHQ']`). With the book present,
the Fine In/Out screen's list is filtered to `FINE INOUT` (G101). The book is not exercised by the mocked
smoke, so no mock alignment was needed.

Done when: a provisioned company's Fine In/Out screen offers its book; a seed-completeness DB assertion proves
the ledger-less `FIO` book and its `INOUT_DATA` routing; the list is filtered.


### N103 — Bullion Booking book on a provisioned company (G113)

The provision-then-filter sweep continued to Bullion Booking (TR_BUL_BOOKING): a party books bulk fine metal at
a locked rate, writing `BUL_DATA` and a balanced Dr cash / Cr bullion-payable entry in `AC_DATA`. `seedCompany`
provisioned no Bullion Booking book, so the screen had no book to select (the Stock In/Out, Dhiran, Labour/Fine,
Tag Opening and Fine In/Out class — G105/G109/G110/G111/G112).

`seedCompany` now provisions `BUL` (BUL SALE → `BUL_DATA`) with the standard three slots. Unlike the ledger-less
stock books, this one is ledger-bearing, but the writer resolves its accounts (`BULLION`/`CASH`) from the
payload rather than BOOK_DETL, so the slots are nominal. With the book present, the Bullion Booking screen's
list is filtered to `BUL SALE` (G101). `seedCompleteness` asserts the book and its `BUL_DATA` routing;
`provisioning.db.test.ts` counts were updated (32 → 33 book groups, 104 → 107 legs).

Done when: a provisioned company's Bullion Booking screen offers its book; a seed-completeness DB assertion
proves the `BUL` book and its `BUL_DATA` routing; the list is filtered.


### N104 — Item Opening book on a provisioned company (G114)

The provision-then-filter sweep continued to Item Opening (TR_ITM_OPBL, `CurBookHelp("OPSTK")`): it opens
non-tag (loose/lot) item stock, writing `ITM_OPBL` + positive `MAIN_STOCK` with no money ledger (empty
`AC_DATA`). `seedCompany` provisioned no Item Opening book, so the screen had no book to select.

`seedCompany` now provisions `IOP` (OPSTK → `BAR_DATA`) as a **ledger-less** stock book with empty slots. It
joins `TAG OPENING`, `FINE INOUT` and `WH QUOT` in the seed-completeness orphans allowance (the ledger-less
set is now `['FIO','IOP','TOP','WHQ']`). With the book present, the Item Opening screen's list is filtered to
`OPSTK` (G101); the mocked-browser smoke's IOP book mock was aligned to the real `OPSTK` MAIN_BOOK.

Done when: a provisioned company's Item Opening screen offers its book; a seed-completeness DB assertion proves
the ledger-less `IOP` book and its `BAR_DATA` routing; the list is filtered and the smoke passes.


### N105 — Multi-Party Receipt book list filtered (G101 part)

A clean filter-only G101 step: Multi-Party Receipt (batch receipt) posts to the RECEIPT family (`batchReceipt.ts`
stamps `BOOK_NAME 'RECEIPT'`) and the seeded `RCT` book already carries MAIN_BOOK `RECEIPT`, so filtering is
safe (the preferred book is present). The screen now passes `mainBooks={['RECEIPT']}` to `BookSelect`.

Done when: Multi-Party Receipt offers only the RECEIPT family.


### N106 — Labour-income account resolved from the book, not a literal (G115, P0-04)

The labour invoice credited its labour part to a literal `LABOUR` account (`labourInvoice.ts`
`input.labourAc ?? 'LABOUR'`). `LABOUR` is not a seeded account on a provisioned company (the seed
names the labour-income account `LBRINC`) and is absent on a migrated one, so a labour bill with a
labour amount posted a Cr to a non-existent account. The desktop (`Ac_Ledr.cs:1203`, leg `01`) credits
`A.DR_LBR` to `B.AC_CODE` where `B.SR_NO = 6` under `MAIN_BOOK IN ('LABOUR WORK')` — i.e. the book's
configured labour-income slot. The writer now resolves that account through the kernel primitive
`resolveBookAccountTx(tx, scope, policy, 6)` (fail-closed on a missing/ambiguous slot); an explicit
caller override still wins. `seedCompany` provisions the labour book's SR_NO 6 slot (`LBRINC`) alongside
SR_NO 1, so a fresh company resolves it. This closes one of the P0-04 posting-account literals
(`labourInvoice.ts` 4 → 3; total 68 → 67).

Done when: a labour bill on a provisioned company credits the book's configured labour-income account.


### N107 — Sales-return posting accounts resolved from the book (G116, P0-04)

The sales-return writer already resolved its cash/round accounts from the book when the amount was
non-zero, but kept literal initializers (`SALES`, `CASH`, `ROUNDOFF`, `KASAR`) that the P0-04 scan
counts and that could post to a seed-only account in a degenerate path. The control account is now
resolved unconditionally from the book's BOOK_DETL slot 1 (desktop `LD_CODE = B.AC_CODE`) and used as
the per-item revenue fallback; cash resolves from slot 2 and round/kasar from slot 3, with no literal
initializer. The only remaining literal is the GST account (a separate tax-config concern), so the
file falls from 5 to 1 (P0-04 total 67 → 63).

Done when: a sales return credits the book's configured control/cash/round accounts on a provisioned company.


### N108 — Purchase-return posting accounts resolved from the book (G117, P0-04)

The mirror of N107 for the purchase side. The control account is now resolved unconditionally from the
book's BOOK_DETL slot 1 and reused as the per-item expense fallback; cash from slot 2, round/kasar from
slot 3; the literal `PURCHASE`/`CASH`/`ROUNDOFF`/`KASAR` initializers are gone. Only the GSTINPUT account
literal remains (a tax-config concern), so the file falls from 5 to 1 (P0-04 total 63 → 59).

Done when: a purchase return debits the book's configured control/cash/round accounts on a provisioned company.


### N109 — Dhrn funding account resolved from the book (G118, P0-04)

The three dhrn writers (issue, receipt, interest-only) defaulted the funding account to a literal
`CASH`. The desktop credits/debits the book's BOOK_DETL slot 2 (`Ac_Ledr.cs:1066`, `B.SR_NO = 2`), so the
writers now resolve the cash account via the kernel primitive `resolveBookAccountTx(..., 2)` (fail-closed),
honouring an explicit caller override. The seeded DHI/DHR books already carry slot 2 = `CASH` (the default
leg layout). The dedicated interest-income account (`INTINC`) is left as a documented remaining literal
because the web models interest income as a separate account while the desktop routes it through book
slots 1/2 — a modelling decision for a later slice. dhrn.ts falls from 5 to 2 (P0-04 total 59 → 56).

Done when: a dhrn issue/receipt/interest voucher funds from the book's configured cash account on a provisioned company.


### N110 — Sale cash/round/kasar accounts resolved from the book (G119, P0-04, first sales.ts pass)

First sub-pass on sales.ts (the largest P0-04 file). The sale writer already resolved its cash/round
accounts from the book under `!isSalesQuotation` but kept literal initializers `CASH`/`ROUNDOFF`/`KASAR`.
Those initializers now default to the resolved control account (the book's slot 1), so a degenerate or
non-posting path never names a seed-only literal; the posting path still resolves slots 2/3 exactly as
before. The remaining sales.ts literals (SALES control fallback for quotations/rate-unfix, GST, tender
cash/bank/old-gold, HMCHRG, TCS) are left for later sub-passes. sales.ts falls from 14 to 11 (P0-04
total 56 → 53).

Done when: a retail sale funds cash and settles round/kasar from the book's configured accounts.


### N111 — Purchase cash/round/kasar accounts resolved from the book (G120, P0-04)

The purchase mirror of N110. The cash/round/kasar literal initializers (`CASH`/`ROUNDOFF`/`KASAR`) now
default to the resolved control account (book slot 1); the posting path still resolves slots 2/3 under
`!isPurchaseQuotation`. The remaining purchase.ts literals (PURCHASE control fallback, GSTINPUT, HMCHRG)
are left for later sub-passes. purchase.ts is now pinned at its true count 5 (the ratchet had carried
slack at 10); P0-04 total 53 → 48.

Done when: a purchase funds cash and settles round/kasar from the book's configured accounts.


### N112 — Bullion booking accounts resolved from the book (G121, P0-04)

Bullion booking had no book-account resolution: `payableAc`/`cashAc` fell back to literal
`BULLION`/`CASH`. They now resolve from the booking book's BOOK_DETL slots (1 = payable/control,
2 = cash) via the kernel primitive (fail-closed), honouring an explicit override. The seeded BUL
book (N103) already carries slot 1 = BULLION and slot 2 = CASH. bullion.ts drops to zero literals
and leaves the P0-04 register (total 48 → 46).

Done when: a bullion booking posts to the book's configured payable and cash accounts on a provisioned company.


### N113 — Order Cancel book provisioned (G122)

The Order Cancel screen refunds a sales order's advance through SL_ORD_ADJ + a balanced AC_DATA refund,
and its writer targets book `ORC` (desktop MDI_FORM.cs:8629 CurBookHelp("ORDER CANCEL")). `seedCompany`
provisioned no ORDER CANCEL book, so a fresh company could not cancel/refund an order. Provisioned the
`ORC` book (MAIN_BOOK 'ORDER CANCEL', table SL_ORD_ADJ, standard 3 legs). This also lays the groundwork
for resolving the order-cancel refund accounts from the book in a later P0-04 sub-pass. Provisioning
book-groups 33 → 34, BOOK_DETL legs 108 → 111.

Done when: a provisioned company can cancel and refund a sales order.


### N114 — Fine settlement metal account resolved from the book (G123, P0-04)

Fine Settlement (FINE SALE / FINE PURC) credited/debited its metal leg to a literal
`FINESALE`/`FINEPURC`. The account is the FSL/FPR book's BOOK_DETL slot 1 (the seed already names
FINESALE/FINEPURC there, N100), so the writer now resolves it via the kernel primitive (fail-closed),
honouring an explicit override. fineSalePurchase.ts drops to zero account literals (the GST/GSTINPUT
tax account is a separate tax-config concern and is not matched by the P0-04 scan). P0-04 total 46 → 44.

Done when: a fine sale/purchase posts its metal leg to the book's configured account on a provisioned company.


### N115 — Seed the walk-in customer so the default retail sale posts (G124, G100 remainder)

The 2026-10-28 full browser review (below) reproduced G100 as a live core-cycle blocker: the Sales Invoice, Hallmark
Sale and Sales Quotation screens default the party to `WALKIN`, but `seedCompany` provisions no such account, so the
tax-policy resolver throws `account not found for tax policy: WALKIN` and the default sale returns HTTP 400. The desktop
defaults the cash party to `00045`, an account its company template carries (`TR_SALE.cs:14141`). N115 provisions a
`WALKIN` walk-in customer account (debtor group `03`, local GST type `L`) in the seed so the screen default resolves and
the sale posts, matching the desktop behaviour of a ready-to-trade company.

Done when: a freshly provisioned company can post the default retail sale (cash party `WALKIN`) end to end.

### 2026-10-28 — full Phase 1 review (plan + programmatic + live browser)

A complete review re-measured Phase 1 against the definition of done. The implementation plan remains the authoritative
gap list; this review confirms its structure and adds one elevated blocker (G124/G100).

- **Programmatic.** The five MISSING workflows (Card Rec, Tour Sales, Dhrn Os Letter, Loan Intrest, Cust Entry) are still
  absent in code. 60 reopen (GET-by-voucher) endpoints exist. The engineering-grade capability tally across the 133
  workflow screens: create 113, reopen 72, edit 74, delete 68, **print 28**, list 58. Of the 85 P1-core workflow screens,
  37 can create but not reopen, 34 lack edit, **64 lack print**, and only 7 have the full create/reopen/edit/delete/print/list
  lifecycle. This matches stages D (lifecycle) and E (documents) as the dominant remaining work.
- **Live browser (seeded demo company, real API+DB).** Login, company/year selection and the dashboard work; the navigation
  exposes the full menu surface; the Sales Invoice screen is faithful (auto voucher number, date with weekday, configured-book
  selector, old-gold exchange grid, 40-column full grid, desktop F-key shortcuts, Load/New reopen, recent-voucher list) and
  its live calculation is correct. The one hard defect found is G124/G100 (the `WALKIN` default sale 400), fixed by N115.
- **Conclusion.** No new module-level gap was discovered; the remaining work is the recorded Stage D (reopen/edit lifecycle
  on ~37 P1-core screens), Stage E (prints on 64 P1-core screens, report modes/filters/layouts) and the 5 MISSING workflows,
  plus the in-flight P0-04 posting-account sweep (N106–N114). N115 is executed first because it unblocks the core cycle.


### N116 — Sales Tax Invoice print (G125, Stage E)

The live 2026-10-28 review confirmed the plan's largest gap end to end: NONE of the core daily transaction
screens (sales, purchases, sales/purchase returns, receipt, payment, contra, journal) had a print endpoint
(only 28 of 133 workflow screens do). The retail Tax Invoice is the single highest-value missing document —
every sale needs a printable bill. N116 adds `GET /sales/:vchNo/print`: a new `salesBill.ts` reads SL_DATA +
SL_DETL (joined seller/customer/HSN) and renders the shared A4 GST-bill chrome (docShell + gstBillBody +
billFooter, the same one the purchase bill uses), returning HTML (`?format=html`) or a PDF. Two reusable
helpers were extracted to `web/apps/api/src/modules/documents/voucherPrint.ts` (`resolvePrintScope`, `sendVoucherDocument`) so this
and the existing purchase-return print share the scope/copy/PDF scaffold; the route is registered under the
Sales Invoice RBAC policy and pinned in the route universe (609 → 610). Verified end to end on the running
stack: a posted sale's `.../print?format=html&copy=O` returns HTTP 200 with the company, WALK-IN CUSTOMER,
item, HSN, CGST/SGST and the correct amounts (60,000 taxable / 900+900 tax / 61,800 total).

Done when: a posted retail sale produces a Tax Invoice (HTML and PDF) with the desktop copies.


### N117 — Purchase bill print (G126, Stage E)

The supplier-side counterpart of N116. Adds `GET /purchases/:vchNo/print`, reusing the existing
`purchaseBill.ts` data/HTML and the shared print helpers (`resolvePrintScope`, `sendVoucherDocument`).
Four more existing inline-PDF print endpoints (purchase-return already done, plus wholesale-quotation,
estimate/quotation and the sales-return credit note) were converted to the shared helper while adding this,
so `txn.ts` stayed under its size ceiling (which tightened further). Route registered under the Purchase
Invoice RBAC policy; route universe 610 → 611. Verified live: a posted purchase's print returned HTTP 200
with the company, Supplier caption, item, HSN and CGST/SGST.

Done when: a posted purchase produces a supplier bill (HTML and PDF).


### N118 — Sales-return Credit Note print (G127, Stage E)

The sales-return keeps its header in SL_DATA but its returned items in SL_DETL_RTN (not SL_DETL), so the
plain sales bill cannot print it. N118 adds `GET /sales-returns/:vchNo/print` backed by a new
`saleReturnBill.ts` that reads SL_DATA + SL_DETL_RTN and renders the shared GST-bill chrome marked as a
Credit Note. Five more legacy inline-PDF print endpoints (the /sales, /purchases, /finance/receipt-voucher
and /finance/payment-voucher invoice prints) were converted to the shared `sendVoucherDocument` helper while
adding this, keeping txn.ts under its (tightening) size ceiling. Route registered under the Sales Return
policy; route universe 611 → 612. Verified live: a posted 5 g return's credit note returned HTTP 200 with
the customer, HSN, CGST/SGST and the correct taxable (27,480) and half-tax (412).

Done when: a posted sales return produces a credit-note document (HTML and PDF).


### N119 — Contra voucher print (G128, Stage E)

The contra (bank<->cash transfer) had create/reopen/edit/delete but no print. N119 adds
`GET /contra/:vchNo/print` backed by a new `contraVoucher.ts` that reads the two CONTRA_DATA rows
(Cr the from-account, Dr the to-account) and renders a From -> To transfer voucher on the shared docShell
chrome. Two more legacy inline-PDF prints (karigar-issue and purchase-quotation) were converted to the
shared helper to keep txn.ts under its tightening size ceiling. Route registered under the Contra policy;
route universe 612 -> 613. Verified live: a CASH -> BANK contra of 15,000 printed HTTP 200 showing the
accounts, the amount and the narration.

Done when: a posted contra produces a transfer voucher (HTML and PDF).


### N120 — Journal voucher print (G129, Stage E)

The journal voucher (multi-line Dr/Cr) had create/delete but no print. The journal writer stores its lines
in CONTRA_DATA (shared with contra) + AC_DATA, so N120 adds `journalVoucherHtml` alongside the contra
renderer and reuses `contraVoucherData` to read the rows. `GET /journal/:vchNo/print` renders the classic
accounting journal table (Particulars | Debit | Credit with the credited account indented under "To",
totals, narration and amount in words). Two more legacy inline-PDF prints (sales-quotation and dhrn) were
converted to the shared helper to keep txn.ts under its ceiling. Route registered under the Journal policy;
route universe 613 -> 614. Verified live: a 5,000 Dr HMCHRG / Cr CASH journal printed HTTP 200 with both
legs, the totals and the narration.

Done when: a posted journal produces a Dr/Cr voucher (HTML and PDF).


### N121 — Fine sale/purchase reopen (G130, Stage D)

The fine sale/purchase (pure-metal trade on fine weight) could be created and deleted but not reopened.
D31 adds `getFineSalePurchase` (reads the CUT_DATA header + CUT_DETL lines back into the same shape the
create endpoint accepts, deriving side from INOUT_TYPE and fine from CR_FINE/DR_FINE) and `GET /fine-sale/:vchNo`.
Four report-doc PDF tails (gstr1, trial-balance, gstr3b, balance-sheet) were converted to the shared
sendVoucherDocument helper to keep txn.ts under its ceiling. Route registered under the Fine Settlement
policy; route universe 614 -> 615. Verified live: a 10-fine sale at 6000 reopened HTTP 200 with the
party, totals (60000/1800/61800), the line and the ISO voucher date.

Done when: a posted fine sale/purchase can be reloaded through the reopen endpoint.


### N122 — Ledger-adjust & employee-JV reopen + edit (G131, Stage D)

Both the ledger adjustment and the employee salary JV already had their reopen readers (getLedgerAdjust,
getEmployeeJv) and editors (editLedgerAdjust, editEmployeeJv) implemented in their modules, but the HTTP
layer only wired POST + DELETE. N122 exposes `GET`/`PUT /ledger-adjust/:vchNo` and
`GET`/`PUT /employee-jv/:vchNo`, completing both lifecycles. Six legacy inline-PDF prints (gstr2 report doc,
the four repair-document prints, the passbook and khata docs) were converted to the shared
sendVoucherDocument helper to keep txn.ts under its ceiling. Routes registered under the Ledger Adjustment
and Employee Salary JV policies; route universe 615 -> 619. Verified live: a ledger adjustment reopened
(500, debit) and edited to 750; an employee JV reopened (salary 20000) and edited to 25000, each confirmed
by reload.

Done when: both vouchers reopen and edit through the API.


### N123 — Card Receipt / CARD ADJUST workflow (G132, one of the 5 MISSING workflows)

Card Rec (desktop TR_CARD_REC) was entirely absent from the web — one of the five MISSING workflows and the
only P1-core one. N123 builds it end to end. A new `cardReceipt.ts` writer posts the exact desktop 8-leg
ledger (Ac_Ledr.cs:1790-1804): 01 Cr party R, 02 Dr party C, 03 Cr slot1 C, 04 Dr bank R, 05 Cr bank B,
06 Dr slot1 B, 07 Dr party H, 08 Cr slot2 H — where R = CARD_AMT + card commission, C = card commission,
B = bank commission, H = cash paid; the commission/charges account is BOOK_DETL slot 1 and the cash account
slot 2 of a newly provisioned CRD (CARD ADJUST) book (with a new CARDCOMM account). It writes the full
CARD_DATA header and the 4-row ROJ_MEL_DATA projection (Ac_Rojmel.cs:843-849). `getCardReceipt`,
`editCardReceipt` (replace-and-repost) and `deleteCardReceipt` (reverse the write set + the desktop
DELETE_DATA audit carrying VCH_VAL_CR = CARD_AMT + hidden-identity cleanup) complete the lifecycle, exposed
at POST/GET/PUT/DELETE /card-receipts. Card commission uses the desktop whole-unit rounding
(TR_CARD_REC.cs:3796); the two local rounding helpers are grandfathered in the kernel baseline like the
sibling finance writers. Route universe 619 -> 623; a dedicated routes DB test asserts the 8 legs, the
cash-leg variant (07/08), CARD_DATA/ROJ_MEL_DATA, reopen, edit and delete. Verified live: a 10,000 card
receipt at 2% card / 1% bank posted (gross 10,200, bank net 10,098), reopened, edited to 20,000 and deleted.

Done when: the Card Receipt workflow creates, reopens, edits and deletes with the desktop write-set.


### N124 — Customer Entry / CRM workflow (G133, one of the 5 MISSING workflows)

Cust Entry (desktop UT_CUST_ENTRY) was absent — the second of the five MISSING workflows to be built. It
is a NON-FINANCIAL employee-scoped customer CRM enquiry / item-interest / follow-up-reminder log: a new
`web/apps/api/src/modules/crm/customerEntry.ts` writes only CUST_DATA (one row per customer/interest line, keyed by
CO_BOOK = employeeCode with an employee-scoped VCH_NO) plus a seed CUST_DETL follow-up row (ISR_NO=1) per
line — no AC_DATA/ROJ_MEL_DATA/DELETE_DATA, no configured book. A row persists only when it carries a
name+remark, a tag, or an item+reminder date (UT_CUST_ENTRY.cs:2503-2509). post/get/edit/delete complete
the lifecycle (edit replaces the aggregate; delete removes both tables). The 4 routes live in a new
`web/apps/api/src/routes/crm.ts` plugin (wired from registerTxnRoutes with the shared helpers, per the size-budget split
guidance) so the monolithic route file stayed under its ceiling. A new `Utilities/Customer Entry` form was
added to the catalog. Route universe 623 -> 627; a new DB test asserts the row predicate, reopen, edit and
delete, and that no ledger is written. Verified live: a 2-row entry posted, reopened, edited to 1 row and
deleted.

Done when: the Customer Entry workflow creates, reopens, edits and deletes its CUST_DATA + CUST_DETL aggregate.


### N125 — Loan/Dhrn Interest Receipt made desktop-faithful (G134, 3rd of the 5 MISSING workflows)

The web `/dhrn/interest` was a sparse interest-only stub (Dr cash / Cr income, two legs, hardcoded book).
N125 rebuilds it to the desktop TR_DHRN_INTREC: a new `web/apps/api/src/modules/dhrn/dhrnInterest.ts` posts the exact
amount-loan 8-leg ledger (Ac_Ledr.cs:1152-1166) — 01/02 principal pair, 03/04 interest assessed, 05/06
interest collected, 07/08 kasar — each pair conditional, with assessed I, received R and kasar K kept
distinct, plus optional principal (regular P + unchak U). It writes the full DHRN_REC_DATA header on its
own provisioned `INTREST RECIVED` book (DIR, inward; interest income from BOOK_DETL slot 2), a DHRN_DATA
movement (INT_REC_AMT = R + K), the ROJ_MEL_DATA projection and a REMARK_DATA row. Identity uses
createIdentityTx/insertHiddenIdentityTx (hidden number + TEMP_BOOK_DATA); getDhrnInterest/editDhrnInterest
(replace-and-repost) and a desktop-faithful delete (reverse the write set + DELETE_DATA audit carrying
VCH_VAL_CR = INT_REC_AMT + hidden identity cleanup) complete the lifecycle. The settlement account defaults
literal-free to the issue book's cash slot; only the kasar write-off remains a registered P0-04 literal
(moved from dhrn.ts, total unchanged at 44). The 4 routes live in the shared routes plugin; route universe
627 -> 630. A new lifecycle DB test asserts the legs, header, movement, roj, remark, reopen, edit (adds
kasar -> 8 legs) and delete. Verified live: a 50,000 pledge's 1,800 interest posted, reopened, edited
(received 1,700 + kasar 100) and deleted.

Done when: the interest receipt posts the desktop write-set and reopens/edits/deletes.


### N126 — Dhrn Os Letter document (G135, 4th of the 5 MISSING workflows)

The Dhrn Os Letter (desktop RP_DHRN_OS "Dhrn Due" + DhrnOsLetter.RPT) was absent. N126 adds a stateless
per-party pledge outstanding statement/letter: a new `web/apps/api/src/modules/dhrn/dhrnOsLetter.ts` reads every still-open
DHRN_ISU_DATA pledge of the borrower (issued on/before an as-of date), aggregates receipts from DHRN_DATA
through the cut-off, computes the outstanding principal and the accrued (unpaid) interest via the shared
`desktopDhrnInterest` (rolled forward from the latest TO_DATE + prior assessed − prior received), lists the
pledged items from DHRN_ISU_DETL, and renders a letter on the shared doc chrome with the reminder wording
and the total due. `GET /dhrn/os-letter?acCode=&asOf=` returns HTML or a PDF via sendVoucherDocument; it
posts nothing and writes no REPORT_DATA. Route registered under Reports/Pledge Outstanding (universe 630 ->
631) and lives in the shared routes plugin. A DB test asserts the open-pledge row (principal/outstanding/
interest/total) and the null-when-no-pledge case. Verified live: an 80,000 pledge's letter returned HTTP
200 with the borrower, amounts and wording.

Done when: the letter lists a party's open pledges with outstanding and total due.


### N127 — Tour Sales (G136, the 5th and final MISSING workflow)

Tour Sales (desktop TR_TOUR_SALE) is NOT a bespoke 14k-line reimplementation: the desktop form posts the
SAME TR_WH_SALE engine (Ac_Ledr.Wh_Sales_Ledr / Wh_Sales_Rojmel / Wh_Sale_Stk over RATE_CUT_DATA,
TR_TOUR_SALE.cs:11252), the only difference being the book — the "Tour Sales" menu opens it on a TOUR SALES
book (MDI_FORM.cs:9321). N127 adds `tour-sale` as a workflow to the wholesale-sale pipeline: a `tour-sale`
entry in WORKFLOW_MAIN_BOOK + book guard (accepts only a TOUR SALES book), and four thin wrappers in a new
`web/apps/api/src/modules/sales/tourSale.ts` over the exported wholesale-sale internals (writeRateCut/readRateCut/
reverseRateCut). A TSL (TOUR SALES) book is provisioned with the same twelve BOOK_DETL slots as WH SALES;
rateCut.ts already lists TOUR SALES in STOCK_MAIN_BOOKS. Routes POST/GET/PUT/DELETE /tour-sales live in the
shared routes plugin under the Tour/Approval Sale right; route universe 631 -> 635. A routes DB test posts a
tour sale that moves a tag out, cuts the balance fine into money, reopens it, and asserts the book guard
rejects a non-TOUR-SALES book. Verified live: a 10 g fine tour sale at 6000 posted (net 60,000) on the TSL
book and reopened.

Done when: Tour Sales posts the wholesale engine on a TOUR SALES book and reopens/edits/deletes.


### N128 — Journal reopen + edit (G137, Stage D)

The journal voucher had create, delete and print but no reopen/edit routes, even though `getJournal` and
`editJournal` were already implemented in the module (same situation as N122's ledger-adjust/employee-jv).
N128 exposes `GET`/`PUT /journal/:vchNo` from the shared routes plugin, completing the journal lifecycle
(create/reopen/edit/delete/print). Route universe 635 -> 637. Verified live: a 5,000 Dr/Cr journal posted,
reopened (2 lines), and edited to 6,000 (the amounts round-trip; the reader surfaces the first line's
description as the narration, a pre-existing getJournal display detail).

Done when: a posted journal reopens and edits through the API.


### N129 — Contra page full lifecycle UI (G138, Stage D frontend)

A fresh capability audit found the real operator-blocking gap is not the backend but the FRONTEND: the
finance-voucher pages (contra, journal, ledger-adjust, employee-jv, payment, receipt, fine-jv) were
create-only in the UI even though the backend has reopen/edit/delete/print. N129 wires the full lifecycle
into the contra page as the template: a `loadContra(vchNo)` that GETs `/contra/:vchNo` and repopulates the
form, a submit that PUTs when editing (POSTs when new, with a New button + edit-aware button label), and the
reusable `<VoucherList table="CONTRA_DATA" book deleteBase="/contra" onLoad printHref>` for the recent list
(reopen/delete/print). Verified LIVE in the browser: logged in, opened the contra page (renders cleanly, no
console errors, CON book pre-selected), filled Dr BANK / Cr CASH 3000 (Balanced ✓), saved — "Contra posted
— Voucher #2". The API-level round-trip (POST -> recent list -> PUT edit 5000->7500 -> reopen) was also
verified.

Done when: the operator can create, reopen, edit, delete and print a contra from the screen. (Follow-up
slices replicate this template to journal, ledger-adjust, employee-jv, payment, receipt, fine-jv.)


### N130 — Journal page lifecycle UI (G139, Stage D frontend)

Applies the N129 contra template to the journal page: `loadJournal(vchNo)` GETs `/journal/:vchNo` and
rebuilds the Dr/Cr grid + narration; submit PUTs when editing (POSTs when new) with a New button and an
edit-aware label; the reusable `<VoucherList table="CONTRA_DATA" book deleteBase="/journal" onLoad
printHref>` (journal rows live in CONTRA_DATA, filtered by the JV book) gives reopen/delete/print. Verified
live in the browser: the journal page renders cleanly (no console errors), the JV book is pre-selected, and
the Dr/Cr grid + Post button are present; the GET/PUT/delete/print APIs were live-verified in N128.

Done when: the operator can create, reopen, edit, delete and print a journal from the screen.


### N131 — Ledger-adjust & Employee-JV lifecycle UI (G140, Stage D frontend)

Applies the N129/N130 lifecycle-UI template to the ledger-adjust and employee-jv pages, which were
create-only. Both gained a `BookSelect` (preferred JV / JOURNAL), a `load<X>(vchNo)` that GETs
`/<x>/:vchNo` and repopulates the form, submit that PUTs when editing (POSTs when new) with a New button and
an edit-aware label, and the reusable `<VoucherList>` for reopen/delete. The recent-voucher list
(modules/vouchers/list.ts) was extended to allow-list `LDR_ADJ_DATA` and `EMP_DATA` and to detect their
amount columns (`DIFF_AMT`, `SALARY_AMT`). Verified through the web `/api` proxy (the exact path the UI
uses): a ledger adjustment posted (201), appeared in the recent list (total 250), and reopened with the
account/amount/direction/remark intact. Full API+DB 318/3492 (incl. the voucher-list scope test) stayed
green with the allow-list extension.

Done when: the operator can create, reopen, edit and delete a ledger adjustment and an employee JV from the screen.


### N132 — Loan Interest page lifecycle UI (G141, Stage D frontend)

The dhrn-interest page was create-only and still numbered on the old DHIRAN RECEIPT book. N132 repoints it
to the INTREST RECIVED (DIR) book provisioned in N125, exposes the richer desktop fields (assessed interest,
interest received, kasar, issue book), and wires the full lifecycle: `loadInterest(vchNo)` GETs
`/dhrn/interest/:vchNo` and repopulates, submit PUTs when editing (POSTs when new) with a New button, and the
reusable `<VoucherList table="DHRN_REC_DATA" book deleteBase="/dhrn/interest" onLoad>` for reopen/delete.
DHRN_REC_DATA was allow-listed in the recent-voucher list. Verified through the web `/api` proxy: issue a
pledge, post interest on DIR (201), it appears in the recent list, and reopens with the borrower/interest/
received/issue intact.

Done when: the operator can create, reopen, edit and delete a pledge interest receipt from the screen.


### N133 — Tour Sales frontend page (G142)

Tour Sales had its backend built in N127 but no UI entry point, so a trained operator could not reach it
from the menu. Because the desktop TR_TOUR_SALE posts the same TR_WH_SALE engine on a TOUR SALES book, the
web reuses the shared `WholesaleVoucherForm`: a new `tour-sale` workflow was added to WHOLESALE_WORKFLOWS
(title "Tour Sales", endpoint `/tour-sales`, mainBook `TOUR SALES`), a thin `/txn/tour-sales` page renders
`<WholesaleVoucherForm workflow="tour-sale">`, and a Sales-menu nav entry was added. The shared form already
implements the full create/load/edit/delete lifecycle keyed off the workflow endpoint. Verified live in the
browser: the page renders with the book selector filtered to "TSL — Tour Sales", the issue/receive grids,
and the Load / Save / Delete / New buttons, with no console errors.

Done when: the operator can create, load, edit and delete a tour sale from the Tour Sales screen.


### N134 — Card Receipt frontend page (G143)

Card Rec (backend N123) had no UI entry point and the "Card / UPI Receipt" menu opened the generic receipt
screen, which cannot enter the dedicated CARD ADJUST fields. N134 adds a bespoke `/txn/card-receipt` page on
the CRD (CARD ADJUST) book with the customer, card bank account, card amount, card/bank commission %,
schedule-charge %, cash paid and narration, a live preview of the computed card commission / gross / bank
commission / bank net (the server remains authoritative), and the full lifecycle (load/edit/delete via
`<VoucherList table="CARD_DATA" deleteBase="/card-receipts">`). The nav "Card / UPI Receipt" entry was
repointed to it, and CARD_DATA was allow-listed in the recent-voucher list (with CARD_AMT amount detection).
Verified: the page serves 200 and the full lifecycle via the web `/api` proxy — a 10,000 card receipt at 2%
card / 1% bank posted (gross 10,200, bank net 10,098, party net 10,000), appeared in the recent list, and
reopened with the amounts intact.

Done when: the operator can create, reopen, edit and delete a card receipt from the Card Receipt screen.


### N135 — Customer Entry frontend page (G144)

Customer Entry (backend N124) had no UI entry point. N135 adds an employee-scoped, multi-row CRM grid at
`/txn/customer-entry`: employee code/name + date, and one row per customer/item-interest line (party, name,
mobile, remark, reminder date, item, like flag, pcs/weights). Non-qualifying rows are dimmed to mirror the
desktop write predicate (name+remark, or a tag, or item+reminder date). Because the entry is keyed by
employeeCode + vchNo (not an accounting book), reopen uses an employee + Load-entry-no input (not the
VoucherList); edit PUTs and Delete removes the aggregate. A nav entry was added under ExtraTran. Verified via
the web `/api` proxy: a 2-row entry posted, reopened (2 rows), edited to 1 row and deleted; the page serves
200.

Done when: the operator can create, reopen, edit and delete a customer entry from the screen.


### N136 — Dhrn Os Letter frontend page (G145); all 5 MISSING workflows now reachable in the UI

The Dhrn Os Letter document endpoint (backend N126) had no UI entry point. N136 adds a focused
`/txn/dhrn-os-letter` page: a borrower account picker + an as-of date, with Preview (HTML) and Open Letter
(PDF) buttons that open `GET /dhrn/os-letter?acCode=&asOf=&format=` in a new tab. A nav entry was added under
LOANS (DHRN). Verified: the page serves 200 and, for a party with an open pledge, the letter returns HTTP
200 with the borrower, amounts and total due. With this slice all five previously-MISSING workflows are now
reachable and usable from the web menu: Tour Sales (N133), Card Receipt (N134), Customer Entry (N135), Dhrn
Os Letter (N136) and Loan Interest (wired N132).

Done when: the operator can generate a pledge outstanding letter for a party from the screen.


### N137 — Receipt/Payment lifecycle UI + two edit/delete fixes (G146, Stage D frontend)

The shared PaymentForm (receipt + payment) was create-only in the single-party mode. N137 wires reopen
(`getReceipt`/`getPayment`), edit and delete into it, and surfaces the recent-voucher list
(`<VoucherList table="CASH_DATA"|"PAY_DATA">`). Two real backend defects surfaced and were fixed: (1)
`editReceipt` replaced RECEIPT_WRITE_TABLES but that set omitted ROJ_MEL_DATA, so a receipt edit collided on
the ROJ_MEL_DATA primary key — ROJ_MEL_DATA was added to the set; (2) the payment DELETE route required the
`mode` in the body, which a generic recent-voucher delete does not send — it now resolves the mode from the
persisted PAY_DATA VCH_TYPE (CPAY/BPAY) inside an RLS-scoped read. A new `PUT /receipts/:vchNo` route exposes
`editReceipt` (route universe 637 -> 638); payment edit is deferred (postPayment lacks the lifecycle-context
hook, so the UI shows a delete-and-re-enter note). Verified live via the web `/api` proxy: a receipt posted
(5,000), edited to 7,500 and reopened at 7,500; a payment posted and deleted with no mode in the body (the
path the VoucherList uses).

Done when: the operator can reopen/delete receipts and payments and edit a receipt from the screen.


### N138 — Fine JV lifecycle UI + FINE JV book provisioning (G147, Stage D)

The Fine JV (metal-weight transfer) page was create-only, and a provisioned company had no FINE JV book, so
every save returned 409 "book-unavailable". N138 adds `PUT /fine-jv/:vchNo` (editFineJv existed; route
universe 638 -> 639), wires the page lifecycle (loadFineJv GETs /fine-jv/:vchNo + repopulates; submit PUTs
when editing; a New button; `<VoucherList table="CONTRA_DATA" deleteBase="/fine-jv">` since fine-jv stores
in CONTRA_DATA under its own FJV book), and provisions the FJV (FINE JV, inward) book in seedCompany (the
transfer needs no BOOK_DETL slots, so it takes the 3 default legs). Provisioning counts updated (book 37 ->
38, BOOK_DETL 127 -> 130). Verified live via the web `/api` proxy: a 10-fine gold transfer WALKIN -> CASH
posted (201), edited to 15 (200) and reopened at 15.

Done when: the operator can create, reopen, edit and delete a fine JV from the screen on a provisioned company.


### N139 — Payment edit (G148, completes the receipt/payment lifecycle)

N137 deferred payment edit because `postPayment` inlined `withTxBudget`/`nextVoucherNoTx` and so could not be
re-driven inside an edit transaction the way `postReceipt` (with its `FinanceWriteContext`) can. N139
refactors `postPayment` to the same `write(tx, identity)` + lifecycle-dispatch shape, writes
`HD_VCH_NO = identity.hiddenVoucherNo` to the PAY_DATA row and calls `insertHiddenIdentityTx` (so
`editIdentityTx` can later read the hidden number — the missing HD_VCH_NO was why the first attempt returned
"invalid voucher number"), and adds `editPayment` (replace PAYMENT_WRITE_TABLES + repost) and
`PUT /payments/:vchNo` (route universe 639 -> 640). The PaymentForm now offers Update for payments too (the
earlier "delete and re-enter" note is removed). Verified live via the web `/api` proxy: a payment posted
(4,000), edited to 9,000 and reopened at 9,000.

Done when: the operator can edit a saved payment from the screen; the payment lifecycle matches the receipt.


### N140 — Scheme instalment edit (G149, Stage D)

The scheme instalment — the highest-volume workflow (841 vouchers) — had create, reopen (getSchemeInstallment)
and delete but no edit route, even though editSchemeInstallment already existed in the module. N140 extracts
the large installment input mapping into a shared `schemeInstallmentInput(req, b)` helper (the POST now calls
it, which net-reduced txn.ts) and adds `PUT /scheme/installment/:vchNo` (route universe 640 -> 641). The
route-input-forwarding test was updated to verify the helper (via helperKeys) forwards every
SchemeInstallmentInput field, matching the rate-cut pattern. Full API+DB 318/3492 green. (A live end-to-end
edit additionally needs a seeded scheme master and book 074, which the demo company does not provision — a
separate provisioning concern; the route and field forwarding are verified by the suite.)

Done when: a scheme instalment can be edited through the API with every input field forwarded.

### N141 — Restore CI to green (G150, Phase-release)

CI had been failing on every run since N124 (`febec1a`). Root cause: `web/apps/api/src/routes/txn.ts`
imported `cardReceiptInputFromBody` from `web/apps/api/src/modules/finance/cardReceipt.ts`, but the export was never
committed — it lived only in an uncommitted working-tree change that a later `git stash` workflow dropped. A
clean checkout (CI, or `pnpm --filter @datacare/api build` = `tsc -p`) failed `TS2724: has no exported member
'cardReceiptInputFromBody'`. Local `tsc --noEmit` passed only because the dirty working tree carried the
export, masking the break across ~16 merges. N141 commits the 31-line body mapper.

A second regression surfaced once the build was fixed and the `Real-stack browser journeys (zero mocks)` job
ran: the `cash-receipt-payment` journey timed out waiting for `Saved — Voucher #1`. `PaymentForm.submit()`
called `resetForm()` after a successful single-party save, and `resetForm()` sets `res = null`, immediately
wiping the confirmation it had just set. The fix clears only the entry inputs after a new save and keeps
`res`, matching the multi-line branch (which only resets its grid).

A third failure was the `operator-reachable field depth did not worsen` gate: `API fields no screen can
supply` rose 96 → 102. This is accumulated healthy growth, not a regression — the Stage D/E slices (card
receipt, customer entry, loan interest, tour sale, the dhrn-interest rewrite, stock in/out and
purchase/order refinements) added 367 API input fields; 361 are reachable from a screen and the 6 net
unreachable rise is entirely server-derived/internal (BOOK_DETL-resolved posting slots, book-classification
flags, writer-assigned voucher numbers, day-book projection rows, read-query keys). `web/parity/unreachable-triage.json`
was resynced to the exact current 102-field set — 0 operator-class (every former operator-backlog gap was
closed by the same slices), 71 serverDerived, 31 internal, each spot-checked against its writer — and
`web/parity/depth-parity-baseline.json` was re-recorded (preserving `note`/`metricChanges`/`endToEnd`/`phases`
that `--write` drops) with an honest `metricChanges` entry documenting the ceiling rise.

Verified: clean-tree `pnpm --filter @datacare/api build`; all three real-stack journeys green; `depth:parity`
+ `depth:deadcells` green; the full local battery; PR #109 all CI jobs pass (static-gates, quality,
Real-stack browser journeys); the main post-merge CI run (`40827479158`) completed `success`.

Done when: CI is green on `main` again and a clean `tsc -p` build succeeds with an empty working tree.

### N142 — Batch receipt kasar write-off account (G151, Stage D)

`postBatchReceipt` was the last receipt path that still *required* the caller to name the kasar
(write-off) account: `requirePostingAccount('kasar', l.kasarAc ?? input.kasarAc, …)` threw when
neither was supplied. The batch grid has no kasar-account column and `POST /receipts/batch` forwards
only `{ scope, vchDate, lines }`, so every on-screen write-off entered on a batch collection was
refused — the exact defect the single-row form had already fixed by resolving `BOOK_DETL` slot 2
(desktop `Ac_Ledr.cs:571-581`, which joins `BOOK_DETL … SR_NO = 2 AND KASAR_AMT <> 0`).

N142 exports `kasarAccountTx` from `finance.ts` and reuses it in `batchReceipt.ts` (converting the
per-line `forEach` to an async `for` loop so the slot resolution can be awaited): an explicit line or
voucher account still wins, else the book's slot-2 kasar account answers, guarded against naming the
slot-1 settlement account (posting a write-off to the cash account would overstate cash on hand). A
new DB test proves all four branches — slot-2 fallback, explicit override wins, slot-1/2 collision
refused with rollback, and a no-kasar line posting cleanly without any slot 2.

Verified: `batchReceiptKasar.db.test.ts` (4 cases) green; full API+DB 319/3496; the full local gate
battery; and live on the running stack — `POST /receipts/batch` with `{ RCT, WALKIN, amount 1000,
kasarAmt 15 }` returned `201 { vchNo: 1, total: 1000 }`, where before the fix it returned `400 kasar
account is not configured`.

Done when: an operator can enter a kasar on a batch-receipt line and the voucher posts, writing the
give-up to the book's configured slot-2 account.

### N143 — Dhiran pledge issue reopen/edit/delete (G152, Stage D)

The pledge issue — a core daily workflow for a jewellery shop — could be created (`issueDhrn`) and
deleted (`deleteDhrn`) but not reopened or edited: there was no `getDhrnIssue` reader, no
`editDhrnIssue`, and no GET/PUT routes, and the page imported only `post` (create-only, no
VoucherList). An operator could book a pledge but could not load it, correct a wrong principal or
collateral, or re-save.

N143 mirrors the N125 dhrn-interest pattern. `getDhrnIssue` reads the DHRN_ISU_DATA header and its
DHRN_ISU_DETL collateral rows into a `DhrnIssueInput`-shaped object; the FROM_DATE and the
licence/remarks/adjusted/unchecked fields that the header does not carry are read from the DHRN_DATA
movement row. `editDhrnIssue` takes the edit identity, clears the whole write set
(`replaceWriteSetTx(DHRN_ISU_TABLES)` — header, collateral, movement and ledger, so a shrunk
collateral grid cannot orphan rows) and reposts through `issueDhrn`, which already accepts a
`{ tx, identity }` context and persists HD_VCH_NO via insertHiddenIdentityTx so the edit identity
resolves. GET/PUT/DELETE `/dhrn/issue/:isuNo` were added (route universe 641 → 644), classified in
routePolicy, and DHRN_ISU_DATA + DHRN_AMT were added to the recent-voucher allow-list. The page was
rewired with `loadIssue`/`resetForm`/`VoucherList`, PUT-when-loaded, and an Update/New control. About
30 comment lines in txn.ts were reclaimed to keep the file under its size ceiling.

Verified: `dhrnIssueLifecycle.db.test.ts` (3 cases, including a collateral SHRINK that proves no
orphan DHRN_ISU_DETL rows) green; routePolicy + routeInputForwarding green; full API+DB 320/3499; and
live — `POST /dhrn/issue` returned 201, `PUT /dhrn/issue/00001` returned 200, and the recent-voucher
list showed the edited principal (30000). The GET reopen follows the identical `scopeOf(req)` pattern
as the verified contra reopen (coBook arrives on the page-context ticket the browser sends).

Done when: an operator can load a saved pledge, change its principal or collateral and re-save.

### N144 — Dhiran pledge receipt reopen/edit/delete + ISU_REC restore (G153, Stage D)

Companion to N143. The pledge **receipt** (redemption) was create-only — `receiveDhrn` and
`deleteDhrn` existed but there was no `getDhrnReceipt`/`editDhrnReceipt`, no GET/PUT routes, and the
page imported only `get`/`post`. There was also a correctness defect: `deleteDhrn` reversed the
receipt's own rows but did NOT restore the issue's `ISU_REC` flag, so a reversed (or edited) receipt
left the pledge permanently marked redeemed — diverging from desktop `TR_DHRN_REC.cs:6376`, which
sets `DHRN_ISU_DATA.ISU_REC='N'` on delete.

N144 adds `getDhrnReceipt` (DHRN_REC_DATA + its DHRN_REC_DETL released items) and `editDhrnReceipt`
(`editIdentityTx` + `replaceWriteSetTx(DHRN_REC_TABLES)` + `receiveDhrn` lifecycle; it restores
`ISU_REC='N'` before the repost so the repost's outstanding check sees the pre-receipt balance, and
`receiveDhrn` re-sets `ISU_REC='Y'` on success). `deleteDhrn` now reads the receipt's
ISU_YRCD/ISU_DBCD/ISU_NO before reversal and restores `ISU_REC='N'` for the receipt case.

To keep `web/apps/api/src/routes/txn.ts` under its size ceiling (both this and N143 add three routes each), all six
dhrn issue+receipt lifecycle routes were extracted into a new `registerDhrnLifecycleRoutes` in
`web/apps/api/src/routes/crm.ts`; the issue/receipt body mappers are passed in (they also feed the POST handlers).
txn.ts shrank and its ceiling was lowered. Route universe 644 → 647. The page was rewired with
`loadReceipt`/`resetForm`/`VoucherList`, PUT-when-loaded and Update/New.

Verified: `dhrnReceiptLifecycle.db.test.ts` (3 cases — a receipt marks the issue redeemed and delete
restores `ISU_REC='N'`; reopen into input shape; edit a partial repayment to full redeems the pledge)
green; routePolicy + routeInputForwarding green; full API+DB 3502. Live: `POST /dhrn/issue` → 201 and
`POST /dhrn/receipt` → 201 (outstanding 0). The delete-restore is proven by the DB test (explicit
scope); the GET/DELETE routes follow the identical `scopeOf(req)` pattern as the verified contra
reopen (coBook arrives on the page-context ticket the browser sends).

Done when: an operator can load a saved redemption, change it and re-save, and deleting one reopens
the pledge for a fresh redemption.

### N145 — Loan Received + Loan Issue reopen/edit/delete (G154, Stage D)

Loan Received (`receiveLoan` wraps `issueDhrn`, writing DHRN_ISU_DATA with ENTRY_TYPE 'L') and Loan
Issue (`issueLoan` wraps `receiveDhrn`, writing DHRN_REC_DATA) were both create-only. Because the
loan vouchers share the pledge tables, their reopen readers are exactly `getDhrnIssue` (loan-received)
and `getDhrnReceipt` (loan-issue) — unchanged. N145 adds thin `editLoanReceived`/`editLoanIssue`
wrappers that inject the loan flags (`entryType: 'L'`, LOAN REC / LOAN ISSUE books, the loan
ledgerMode) and delegate to `editDhrnIssue`/`editDhrnReceipt`, so an edited loan reposts as a loan,
not a pledge. Six routes were added to `registerDhrnLifecycleRoutes` in `web/apps/api/src/routes/crm.ts`
(GET/PUT/DELETE on `/loan/received/:isuNo` and `/loan/issue/:vchNo`), classified in routePolicy
(universe 647 → 653). Both pages were wired with load/New/Update and a VoucherList (loan-issue mirrors
dhrn-receipt, loan-received mirrors dhrn-issue).

Verified: `loanLifecycle.db.test.ts` (2 cases — loan-received and loan-issue each reopen and edit and
keep ENTRY_TYPE 'L' across the edit, proving the repost stayed a loan) green; routePolicy +
routeInputForwarding green; full API+DB 3504.

Done when: an operator can reopen and edit a saved Loan Received or Loan Issue and it stays a loan.

### N146 — KarigarForm reopen/edit lifecycle (G155, Stage D)

The shared `KarigarForm` (backing karigar-issue, karigar-receive, old-item-sales and
jobwork-issue/receive) was create-only even though the backend was fully built: `getKarigar`/
`editKarigar`/`deleteKarigar` and `getOldItemSale`/`editOldItemSale`/`deleteOldItemSale` with
GET/PUT/DELETE routes already existed for karigar and old-item-sales (jobwork has none), and
`useSubDetail` already exposed `load(perLine)`/`reset()` built for reopen. The form just never called
them — it imported only `get`/`post`.

N146 wires the lifecycle into the shared component: `loadVoucher` fetches `GET ${ep}/:vchNo?coBook=`,
stringifies the reader's header and 40+ line fields into the form `Line` shape, and rebuilds the
stone sub-detail in one shot via `sub.load(perLine)`; `resetForm` clears to a New voucher; submit PUTs
to `${ep}/${loadedVch}` when a voucher is loaded; and a VoucherList (keyed on `KR_DATA`) is shown only
when `lifecycle` is true — `family === 'karigar' || oldItemSales`, so jobwork stays create-only until
its own backend routes exist. This is a UI-only change: no new routes, so no size-budget or
route-universe impact, and it lit up three workflows at once.

Verified live on the running stack: a karigar-receive created (201), reopened through
`GET /karigar/receive/00001?coBook=KRR` (returned the line grid, pcs 2), edited via `PUT` (200,
pcs 2 → 3), and reopened again to confirm the change (pcs 3). Gates (typecheck/lint/format/
typecheck:tests/size) green; web tests 9/9. The backend readers/editors were already covered by the
existing API suite.

Done when: an operator can load a saved karigar or old-item-sales voucher, edit its lines (and stones)
and re-save.

### N147 — Fine Sale / Fine Purchase edit (G156, Stage D)

Fine Sale/Purchase could create (`createFineSalePurchase`), reopen (`getFineSalePurchase`, N121) and
delete, but there was no `editFineSalePurchase` and no PUT route, and the page was create-only. The
writer allocated its number with `nextVoucherNoTx` (not the identity/context pattern), and it writes
MAIN_STOCK and draws down the rate-cut source lines' open fine on PR_DETL — side effects an edit must
unwind before reposting.

N147 refactors `createFineSalePurchase` to accept an optional `{ tx, forceVchNo }` context (the
`withTxBudget` closure became a `run(tx)` function; `no = context.forceVchNo ?? nextVoucherNoTx`). The
delete's restore-and-reverse body was extracted into `reverseFineSaleTx` (restore the
CUT_STK_DETL→PR_DETL open-fine drawdown, then `reverseVoucherTx` over
CUT_DATA/CUT_DETL/CUT_STK_DETL/AC_DATA/TAX_DATA/MAIN_STOCK). `editFineSalePurchase` runs
`reverseFineSaleTx(old)` then `createFineSalePurchase(new, { tx, forceVchNo })` in one transaction, so
the repost reuses the same voucher number and its own rate-cut validation sees the restored open
balances. A `PUT /fine-sale/:vchNo` route (universe 653 → 654), a shared `fineSaleInput` helper and
`fineSide`/`fineBook` helpers (which removed the inline side duplication in GET/DELETE and kept
`txn.ts` under its lowered ceiling) complete the backend. The page was wired with `loadVoucher`
(CUT_DETL stores only the fine weight + rate, so a reopened line sets `netWt = fineWt`, `touch = 100`
— reproducing the same fine and priced metal), `resetForm`, PUT-when-loaded, New, and a VoucherList on
`CUT_DATA` (added to the recent-voucher allow-list).

Verified: `fineSaleEdit.db.test.ts` (create 2 lines fine 15 → reopen → edit to 1 line fine 8 at the
same vchNo with CUT_DETL 2→1 and no orphan rows, MAIN_STOCK re-derived → delete reverses everything)
green; routePolicy + routeInputForwarding green; full API+DB 3505. Live: `POST /fine-sale` → 201
(fine 13.74), `GET` reopen (2 lines), `PUT` → 200 (re-derived to fine 8).

Done when: an operator can load a saved fine sale/purchase, change its lines and re-save at the same
voucher number with stock and ledger re-derived.

### N148 — Jobwork reopen/edit/delete lifecycle in KarigarForm (G157, Stage D)

N146 wired reopen/edit/delete into the shared `KarigarForm` but gated it to the karigar +
old-item-sales families, because jobwork-issue/receive read through a different backend
(`getMfg`/MFG_DATA via `/mfg/jobwork-{issue,receive}`, not `getKarigar`/KR_DATA) with a `components`
sub-detail rather than `stones`. The jobwork GET/PUT/DELETE routes already existed
(`web/apps/api/src/routes/txn.ts:3968-4035`, via `checkedJobworkScope`), and N153 made the last
MFG_DETL columns (`krName`/`totalNetWt`) readable — so jobwork reopen is now lossless (the
`jobworkLine` POST payload is a strict subset of what `getMfg` returns).

N148 extends the `lifecycle` flag to jobwork, makes `lifecycleTable` family-dependent
(`MFG_DATA` for jobwork, `KR_DATA` otherwise), and adds a jobwork branch in `loadVoucher` that maps
the `getMfg` line shape into the form `Line` (`size→itmSize`, `itemRemark→itDesc`, `itRate→rate`,
`itAmt→amount`, a new `totalNetWt` slot, `krName`→header `karigarName`) and replaces the sub-detail
with `components` (translating the reader's `lbrAmt`/`netAmt` to the grid's `lbrAmount`/`netAmount`
so the serializer re-emits them on an unchanged save). The karigar/old-item-sales `stones` + `KR_DATA`
path is untouched.

Implemented by a sub-agent implement+independent-audit pipeline (AUDIT_PASS after the auditor caught
and the implementer fixed two real reopen-losses: `totalNetWt` had no `Line` slot, and the component
`lbrAmt`/`netAmt` needed the UI alias). The auditor's AST proof: all 23 jobwork line fields and all
18 component fields round-trip (`MISSING=none`, `NOT_RESTORED=none`), and the non-jobwork mapper +
stones loader are byte-identical to `HEAD` (matching SHA-256).

Verified: gates (typecheck/typecheck:tests/lint/format/size/register/kernel/docs:refs) + clean-tree
`@datacare/api` build + web tests 646+9 + `depth:parity` green. UI-only — no new routes
(jobwork routes already classified; `MFG_DATA` already in the recent-voucher allow-list). Live click
deferred — the demo provisions no jobwork (JDTR) book.

Done when: an operator can load a saved jobwork issue/receive, edit its lines and components, re-save,
and delete.


### N149 — Manufacturing Issue reopen/edit lifecycle UI (G158, Stage D)

The mfg-issue page was create-only (it imported only `post`) even though `getMfg`/`editMfg`/
`deleteMfg` and `GET/PUT/DELETE /mfg/issue/:vchNo` already exist and are covered by
`mfgLifecycle.db.test.ts` (9 tests: create/get/edit/persisted-date-lock/delete). The getMfg reader
returns a line shape whose field names match the page `Line` interface exactly — itCode, netWt, the
reconciliation columns (rtnChol/rtnGhis/itmGhat/totalGrossWt), the karigar/old-metal/material/
provenance block — and `useSubDetail` already exposes `load()` for the component sub-detail.

N149 wires `loadVoucher` (GET `/mfg/issue/:vchNo?coBook`, a field-for-field stringify copy over the
`blank()` keys, `sub.load(perLine)` for the MFG_IDTL components), `resetForm`, PUT-when-loaded, a New
button and a VoucherList on `MFG_DATA` (added to the recent-voucher allow-list). This is a UI-only
change — no new routes, so no size-budget or route-universe impact.

Verified: gates (typecheck/lint/format/size/register) green; web tests 9/9; and the backend the UI
calls is green under `mfgLifecycle.db.test.ts`. Live click was deferred because the demo company
provisions no manufacturing book, so the DB-tested backend could not be exercised through the running
stack; the wiring uses the identical reopen pattern verified live on six other workflows this session.

Done when: an operator can load a saved MFG issue, edit its lines and components, and re-save.

### N150 — Manufacturing Receive reopen/edit lifecycle UI (G159, Stage D)

Companion to N149. The mfg-receive page was create-only though the same `getMfg`/`editMfg`/`deleteMfg`
backend and `GET/PUT/DELETE /mfg/receive/:vchNo` exist and are covered by `mfgLifecycle.db.test.ts`.
N150 applies the identical wiring (plus the `labourAmt` header field): `loadVoucher`
(GET `/mfg/receive/:vchNo?coBook`, field-for-field stringify over the `blank()` keys, `sub.load`
for the component sub-detail), `resetForm`, PUT-when-loaded, New, and a VoucherList on `MFG_DATA`.
UI-only — no new routes.

Verified: gates (typecheck/lint/format) + web tests 9/9 green; backend green under
`mfgLifecycle.db.test.ts`. Live click deferred for the same reason as N149 (the demo provisions no
manufacturing book).

Done when: an operator can load a saved MFG receive, edit its lines and components, and re-save.


### N151 — Bullion Sale reopen/edit/delete lifecycle UI (G160, Stage D)

The bullion-sale page (`/txn/bullion-sale`, desktop `TR_BUL_SALE.cs`) was create-only: it imported
only `post` and had no way to reopen, edit or delete a saved voucher. The backend was already
complete and tested — `getBullionSale`/`editBullionSale`/`deleteBullionSale` (in
`web/apps/api/src/modules/sales/rateCut.ts`, the bullion family shares `readRateCut`/`writeRateCut`
with `bookGuard:'bullion-sale'`) and `GET/PUT/DELETE /bullion-sales/:vchNo`, exercised by
`web/apps/api/test/bullionSale.db.test.ts` (post → reopen → edit → delete, 2 tests).

N151 is UI-only. It extracts the submit body into a `payload()` helper, makes submit PUT when a
voucher is loaded (else POST), and adds `loadVoucher` (GET `/bullion-sales/:vchNo?coBook`, restoring
every header field the payload sends — party, `fineRate`/`convRate`/`convPct`/`itType`, address, all
four `settle*` values, and both the issue-side and receive-side tender bands — plus rebuilding
`lines`/`receivedLines` through a `lineFromView` mapper that converts the reader's `ghtWt`→`ghtPct`
and `westPct`→`west`), `remove` (DELETE with confirm), `reset` (New), a voucher-no Load input, and
New/Delete buttons with an Update label and Posted/Updated feedback. No new routes.

Implemented by a sub-agent pipeline (implementer + independent auditor). The auditor confirmed the
change is confined to the one page, every submitted header field is restored on load (the standard
reopen-then-save-blanks defect class — none found), and re-ran the full battery.

Verified: gates (typecheck/typecheck:tests/lint/format/size/register/kernel) + clean-tree
`@datacare/api` build (empty error scan) + web tests 646+9 green; backend green under
`bullionSale.db.test.ts` (2/2); `depth:parity` passed (+2 txn grid pages now lifecycle-complete).
Live click deferred for the same reason as N149/N150 — the demo company provisions no bullion book.

Done when: an operator can load a saved bullion sale, edit its lines/tenders, re-save, and delete.


### N152 — Manufacturing Order Issue reopen/edit/delete lifecycle UI (G161, Stage D)

An exhaustive sweep for remaining create-only voucher pages that have a full `GET+PUT+DELETE
/route/:vchNo` backend lifecycle but no UI reopen/edit/delete found exactly one: `mfg-order-issue`
(Order Issue). After N151, every other txn voucher page with a reopen-capable backend exposes the
lifecycle in the UI (directly or via a shared component such as `WholesaleVoucherForm`,
`KarigarForm`, `StockInoutForm`, `OtherPurcForm`, `PaymentForm`, `ContraForm`); the UI-lifecycle
sweep is otherwise complete.

Order Issue is **not** a safe UI-only slice. An implement-then-independent-audit attempt confirmed
(by mechanical key comparison) that the bespoke page's POST payload sends ~51 writer-verified
`extendedLineFields` plus header `karigarName`, while `getMfg` returns neither `karigarName` nor nine
persisted line columns (`totalNetWt`, `oldNetWt`, `rateType`, `prCode`, `itmLoss`, `netAmt`,
`krName`, `ordAcCode`, `ordDesign`). Because `editMfg` deletes-and-rebuilds the whole write set
(`mfg.ts:1368-1383`), an unchanged reopen→Update would silently blank those columns — a
data-corruption defect, not merely lossy. (N149/N150 are unaffected: mfg-issue/mfg-receive do not
send those extended fields and their line shape round-trips cleanly through `getMfg`.)

Prerequisite for N152: a **backend** change extending `getMfg` to return every persisted payload
field — `TOT_NWT→totalNetWt`, `OLD_NWT→oldNetWt`, `RATE_TYPE→rateType`, `PR_CODE→prCode`,
`NET_AMT→netAmt`, `KR_NAME→krName`, `ORD_AC_CODE→ordAcCode`, `ORD_DESIGN→ordDesign`, defined
issue-side `itmLoss`, and `karigarName` — with an all-fields GET→payload unchanged round-trip test,
followed by the page reopen wiring. Recorded planned-only; no page was shipped.

Done when: `getMfg` round-trips the Order Issue payload and the page offers reopen/edit/delete.

**Resolved (UI wiring).** With the N153 reader fix merged, this became a safe UI-only slice and was
implemented via a sub-agent implement+independent-audit pipeline (AUDIT_PASS). The page now imports
`get/put/del`, extracts `payload()`, PUTs when a voucher is loaded (else POSTs), reopens via GET
`/mfg/order-issue/:vchNo?coBook=DIS` restoring `karigarAc`/`vchDate`/`rows` field-by-field over the
`blank()` template and the header `karigarName` from `lines[0].krName`, deletes with confirm, and
offers New/Load/Update/Delete with a stale-target guard (Update/Delete disabled when the search box
differs from the loaded voucher). The auditor's independent AST comparison confirmed all 61 sent line
keys are both returned by `getMfg` and restored by `loadVoucher` (`missing=[]`). Gates + clean API
build + web 646+9 + `depth:parity` green. Live click deferred — demo provisions no MFG/DIS book.


### N153 — getMfg reader round-trips the last nine MFG_DETL columns (G161 prerequisite, Stage D)

The backend half of N152, shipped on its own because it is a correctness fix independent of any UI:
`getMfg` (`web/apps/api/src/modules/manufacturing/mfg.ts`) now maps the nine MFG_DETL columns it
previously dropped — `TOT_NWT→totalNetWt`, `OLD_NWT→oldNetWt`, `NET_AMT→netAmt`, `ITM_LOSS→itmLoss`,
`RATE_TYPE→rateType`, `PR_CODE→prCode`, `KR_NAME→krName`, `ORD_AC_CODE→ordAcCode`,
`ORD_DESIGN→ordDesign`. All are already fetched by the reader's `SELECT *`; the writer persists them
(`detlRows`, `:606-676`) and `editMfg` deletes-then-rebuilds the write set from the request, so
before this fix a reopen→unchanged-save blanked them. `itmLoss` is receive-only at the writer (`:771`
gates it on `ctx.isReceipt`), read unconditionally (an issue voucher stored 0); `netAmt` is the line
`NET_AMT` (`lineNetAmt`, `:641`), distinct from the component `IT_NET_AMT`.

Proof: the manufacturing case in `operatorDepth.roundtrip.db.test.ts` (the "preserves every supplied
field across an unchanged save" harness: create → read → edit with the read-back values → assert the
inputs survived) now supplies and asserts the eight issue-valid fields; `itmLoss` stays on the
receive path like `itmGhat`. This is the fourth time this module's WRITE side was complete while the
READ side was not (P3-1 extended it once before).

Verified: gates (typecheck/typecheck:tests/lint/format/size/register/kernel/docs:refs) + clean-tree
`@datacare/api` build; `operatorDepth.roundtrip.db.test.ts` 3/3 and `mfgLifecycle.db.test.ts` 9/9;
`depth:parity` passed (unreachable API fields unchanged at 102 — the fields are reachable through the
existing editMfg write path). The `mfg.ts` size ceiling rose 1504→1516 (a visible baseline diff).
N152's UI reopen wiring is now unblocked.

Done when: `getMfg` returns every persisted MFG_DETL payload field and a round-trip test proves it.


### N154 — Multi-Party (batch) Receipt reopen/edit/delete lifecycle (G162, Stage D)

The desktop Multi-Party Receipt (`TR_CASH.cs`, a grid of party rows written to `CASH_DATA`) is
fully reopen/edit/delete-capable: `BtnF` loads an existing voucher, `BtnSave` re-saves, and an edit
deletes `CASH_DATA`+`AC_DATA` by `VCH_NO` and rebuilds them while writing a `DELETE_DATA` audit row
(`TR_CASH.cs:2988-3081,3217`). The web batch-receipt page could only POST — the backend had
`postBatchReceipt`/`deleteBatchReceipt` but no reader or editor, and the single-row `getReceipt`
rejects a voucher with more than one `CASH_DATA` row.

N154 adds, in `web/apps/api/src/modules/finance/batchReceipt.ts`:
- **`getBatchReceipt`** — reads every `CASH_DATA` row of the voucher, in `SR_NO` order, into a
  `lines[]` shaped to feed straight back into `BatchReceiptLineInput`. The pay **mode is derived**,
  not stored: `postBatchReceipt` settles a cash line to the book's slot-1 cash-settlement account and
  a non-cash line to its own bank ledger (`REC_AC_CODE`), so a row whose `REC_AC_CODE` equals that
  slot-1 account reads back as `cash` (no `bankAc`), otherwise a bank-side mode (`cheque` when it
  carries a cheque number, else `bank`) with `bankAc = REC_AC_CODE` — mirroring the writer so an
  unchanged reopen→save re-posts the identical ledger.
- **`editBatchReceipt`** — reverses the old `CASH_DATA`+`AC_DATA` write set (with the `DELETE_DATA`
  audit, via `deleteBatchReceipt`) and re-posts the new grid under the **same** voucher number
  (`postBatchReceipt` + the new edit-only `forceVchNo`), matching the desktop delete-then-rebuild.

Plus `GET/PUT/DELETE /receipts/batch/:vchNo` (classified under the existing Multi-Party Receipt
form), and the UI reopen/edit/delete on the batch-receipt page (Voucher-no Load input, New/Delete,
`Update #N` label, and a `VoucherList` on `CASH_DATA` — already in the recent-voucher allow-list).

Proof: `batchReceiptLifecycle.db.test.ts` (2 tests) posts a two-party batch (a cash line with a kasar
write-off and a cheque line into the bank), reopens it asserting the **derived mode** and every field,
edits it in place (same `VCH_NO`, dropping a party and changing an amount) asserting the balanced
`AC_DATA` (3515 → 1200) and the `DELETE_DATA` audit, then deletes it; a second test proves an
unchanged reopen→re-save re-posts the identical lines and ledger sums. `batchReceiptKasar.db.test.ts`
(4) still passes.

Verified: gates (typecheck/typecheck:tests/lint/format/size/register/kernel/docs:refs) + clean-tree
`@datacare/api` build + web tests 646+9 + `routePolicy` 56/56 (universe 654→657). The new
edit-only `BatchReceiptInput.forceVchNo` is triaged `internal` in `unreachable-triage.json`
(unreachable 102→103, operator still 0) and the depth baseline resynced; `depth:parity` passes.
`txn.ts` size ceiling rose 8443→8482 (visible baseline diff). Live click deferred — exercised by the
DB lifecycle test rather than the demo (which provisions a receipt book but the batch reopen path is
proven end-to-end at the service layer).

Done when: an operator can load a saved multi-party receipt, edit its party rows, re-save, and delete.


### N155 — Order-cancel refund/kasar accounts resolved from BOOK_DETL, not literals (G163, Stage D)

`cancelSalesOrderAdjust` posted the order-cancel refund leg to `input.paidAc ?? 'CASH'` and the
write-off leg to `input.kasarAc ?? 'KASAR'`. The strings `'CASH'`/`'KASAR'` are not account codes in
a real company's `AC_MAST` (a real cash account is a code like `00001`), so a cancel entered without
an explicit account posted a balanced-but-wrong voucher to a non-existent ledger — the N59 literal
anti-pattern already removed from the single/batch receipt and scheme paths. The desktop posts this
voucher through `Ac_Ledr.Order_Adj_Ledr` (`TR_SL_ORD_ADJ.cs:3665`), which answers the settlement and
write-off accounts from the cancel book's `BOOK_DETL` slots.

N155 resolves both on the posting transaction against the cancel book (`ORC`): `paidAc` =
`resolveBookSlotAccountTx(tx, {…coBook:'ORC'}, 'cash-settlement', 1, input.paidAc)` when a refund is
paid (an explicit request account wins, else slot 1), and `kasarAc` = `kasarAccountTx(tx, …, input.kasarAc, paidAc, kasar)`
when a write-off is taken (explicit, else slot 2, guarded against naming the settlement account).
Both **fail closed** — an unconfigured book is refused, not posted to an invented ledger.

Proof: `salesOrderCancelAccounts.db.test.ts` (4) — a cancel with no named account posts the refund to
the configured slot-1 account (asserting `'CASH'` never appears); a write-off resolves slot 2; an
explicit account wins; and an unconfigured book is refused with the voucher rolled back. The existing
`salesFamilyLifecycle.db.test.ts` (31) is unaffected (it passes `paidAc` explicitly, which still
wins). Verified: full gates + clean `@datacare/api` build + web 646+9 + sales-order DB suite 58/58;
`depth:parity` passes (the fix removes a literal and adds no unreachable field). `salesOrder.ts` size
ceiling rose 2350→2361.

Done when: an order cancel without a named account posts to the configured settlement/kasar accounts,
and a book without them is refused.


### N156 — Sales-order advance debits the configured book account, not the 'CASH' literal (G164, Stage D)

The sales-order writer debited the advance to `input.cashAc ?? 'CASH'`. When a customer paid an
advance on an order without the request naming an account, the balanced voucher (Dr cash / Cr
customer) posted its debit leg to the string `'CASH'`, which is not an account code in a real
company's `AC_MAST` — the same N59 literal defect fixed for the receipt/scheme/order-cancel paths.
The writer's own comment (`salesOrder.ts:1197`) records that the desktop debits the order book's
BOOK_DETL slot-1 account.

N156 moves the `cashAc` resolution inside the posting transaction (after the order book is resolved)
and, only when an advance is actually taken, resolves
`resolveBookSlotAccountTx(tx, {…coBook: book.coBook}, 'cash-settlement', 1, input.cashAc)` — an
explicit request account wins, else the book's slot 1, FAIL-CLOSED when unconfigured. An order with
no advance needs no cash account.

Proof: `salesOrderRound4.db.test.ts` gains a case asserting an advance with no account is refused
(nothing left behind) and an explicit account still posts the Dr leg; `salesFamilyLifecycle.db.test.ts`
(whose `orderInput()` takes a 100 advance with no `cashAc`) now configures a `SOR` slot-1 and still
passes 32 — proving the resolution path works end-to-end. Verified: full gates + clean
`@datacare/api` build + web 646+9 + sales-order DB suite (round4 11/11, family 32, lifecycle,
cancel-accounts 4/4) + `depth:parity` green. `salesOrder.ts` size ceiling 2361→2374.

Done when: an order advance without a named account posts to the configured slot-1 account, and a
book without it is refused.


### N157 — Core sale posting resolves its tender/income accounts, no longer the 'CASH'/'BANK'/'SALES' literals (G165, Stage D)

The sale writer (`sales.ts`) carried eleven literal account fallbacks. Not all were defects, so each
was checked against the desktop authority before changing — and five were cleaned, six deliberately
left.

Cleaned (genuine N59, a real configured/persisted source exists): the cash receipt leg now takes the
already-resolved BOOK_DETL slot-2 account the writer computes (the `?? 'CASH'` was inert); the
sale-income account resolves from BOOK_DETL slot 1 (`resolveBookAccountTx(..,1)`, explicit request
wins) for a posting sale and keeps a harmless preview placeholder for a quotation (which posts no
ledger); the electronic-tender (card/upi/cheque) bank leg and the cheque Rojmel settlement row now use
the persisted `BANK_AC` (returned by the reader and round-tripped via `VIEW_HEADER_PASSTHROUGH`),
FAIL-CLOSED when any electronic tender posts without a bank account; and the single-account income
branch throws an invariant instead of defaulting to `'SALES'` (every item now carries a resolved
account, so it is unreachable).

Left intact (verified NOT the N59 class): old gold (`'OLDGOLD'`), hallmark charge (`'HMCHRG'`), TCS
(`'TCS'`) and the GST tax account (`'GST'`). None has a BOOK_DETL slot; none is persisted in a header
column (SL_DATA has only `BANK_AC`/`CARD_AC`/`SCHM_AC`), so a reopen cannot recover a resolved value;
and the tax account depends on an already-documented provisioning gap (TAX_MAST rows at SR_NO 1 while
the code lookup pins SR_NO 0) under which the web charges tax by rate with no resolvable TAX_AC.
Fail-closing any of these breaks a legitimate create-then-reopen-and-save, which was confirmed
empirically (the fail-closed experiment reproduced 400s on the hallmark round-trip and the
amount-basis/quotation tests). They remain in the posting-literals REMAINING ledger as honest debt.

Proof: `postingAccountLiterals.test.ts` REMAINING for `sales.ts` drops 11 to 6, REMAINING_TOTAL
41 to 36, guard green. The full sales DB suite is unchanged and green (sales lifecycle, family 32,
hallmark round-trip, amount-basis, quotation, bullion, old-item, fine-sale edit = 69 across 9 files),
proving the resolved cash/bank/income accounts reproduce the same ledger and the six kept defaults
still post as before. Verified: full gates + clean `@datacare/api` build + web 646+9 + `depth:parity`.
`sales.ts` size ceiling 2809 to 2845.

Done when: the sale cash/bank/income accounts come from configuration (fail-closed for bank), and the
non-configurable defaults are documented rather than silently literal.


### N158 — Purchase posting resolves its expense account from configuration, not the 'PURCHASE' literal (G166, Stage D)

The purchase writer (`purchase.ts`) mirrors the sale writer and carried the same class of literal
fallbacks. Applying the N157 reasoning file-for-file: the purchase expense account now resolves from
BOOK_DETL slot 1 (`resolveBookAccountTx(..,1)`, explicit request wins) for a posting purchase and
keeps a harmless preview placeholder for a quotation (no ledger); and the single-account expense
branch throws an invariant instead of defaulting to `'PURCHASE'` (every item carries a resolved
account, so it is unreachable).

Left intact (verified NOT the N59 class, same reasoning as the sale counterparts): the tax-input
account (`'GSTINPUT'`, depends on the documented TAX_MAST SR_NO provisioning gap) and the hallmark
charge (`'HMCHRG'`, no BOOK_DETL slot and no persisted header column). They remain in the
posting-literals REMAINING ledger as honest debt.

Proof: `postingAccountLiterals.test.ts` REMAINING for `purchase.ts` drops 5 to 3, REMAINING_TOTAL
36 to 34, guard green. The full purchase DB suite is unchanged and green (lifecycle, consignment,
quotation, returns, rojmel = 55 across 9 files). Verified: full gates + clean `@datacare/api` build +
web 646+9 + `depth:parity`. `purchase.ts` size ceiling 2860 to 2883.

Done when: the purchase expense account comes from configuration (fail-closed), and the
non-configurable defaults are documented rather than silently literal.


### N159 — Labour invoice resolves its metal-sale/round-off accounts from the labour book, not literals (G167, Stage D)

The labour invoice (`labourInvoice.ts`) already resolved its labour-income leg from BOOK_DETL slot 6
(the G115 fix), but the metal-sale income still defaulted to `'SALES'` and the round-off to
`'ROUNDOFF'`. The G115 resolver was generalized into `resolveLabourBookSlot(tx, scope, srNo, label)`,
and the metal-sale account now resolves from slot 1 and the round-off from slot 3 — inside the
transaction and gated on their legs actually posting (`metalT.taxable !== 0` / `roundOff !== 0`), with
an explicit caller account winning and fail-closed otherwise.

Left intact: the `'GST'` tax account, which depends on the documented TAX_MAST SR_NO provisioning gap
(same as every other family's tax leg).

Proof: `postingAccountLiterals.test.ts` REMAINING for `labourInvoice.ts` drops 3 to 1, REMAINING_TOTAL
34 to 32, guard green. `salesFamilyLifecycle.db.test.ts` gained LBR slots 1 and 3 (it had seeded only
slot 6) and its labour-invoice create/edit/receive cases pass (31), proving the slot resolution works
end-to-end. The labour DB suite (desktop grid, fine-tax rows, sale-return labour replay = 118 across
8 files) is unchanged and green. Verified: full gates + clean `@datacare/api` build + web 646+9 +
`depth:parity`.

Done when: the labour metal-sale and round-off accounts come from the book slots (fail-closed), and
the tax default is documented rather than silently literal.


### N160 — A malformed request body is a 400, not a 500 (G168, first increment of N50)

A malformed body shape that reaches a writer used to crash with a 500. Confirmed empirically:
`POST /sales` with `lines: 'not-an-array'` returned `500 "lines.map is not a function"` — the writer
reads `lines` as an array, the synchronous `TypeError` fell through the shared `run()` catch (which
only recognised typed `*ValidationError`s and DB-constraint errors) to Fastify's default 500.

The fix adds one branch to `run()`'s fallthrough: a `TypeError` or `RangeError` thrown from the
handler body — by which point authentication and routing have already succeeded, so the fault lies in
the request shape, not the server — is answered as a 400 `invalid-request`. Typed server-fault errors
(for example the serializable-command policy's `statusCode: 500`) are matched by earlier branches and
keep their status, so genuine 500s are preserved.

Proof: two new probes in `saleAmountBasis.routes.db.test.ts` — a non-array `lines` now returns 400
(was the 500 above), and a non-object body stays under 500. The serializable-command suite still
asserts its deliberate 500s (78 pass), and a broad `routes.db` batch (53 across 14 files) is green.
Verified: full gates + clean `@datacare/api` build + web 646+9 + `depth:parity`. `txn.ts` size ceiling
8482 to 8491.

This is the first increment of N50; full per-route Fastify JSON Schemas (typed body validation that
rejects before the handler runs) remain planned under N50.

Done when: a malformed request body is rejected with a 400 rather than crashing with a 500.


### N161 — Feature E2E suites: every T01–T18 case of a feature, through the real screen (G169–G171)

The journeys prove single workflows. N161 adds a suite per **feature** that runs its whole frozen case matrix —
every applicable T01–T18 group of the verification playbook — through the real browser on the zero-mock
real-stack harness, with a shared sample-data catalogue, an evidence bundle checked by the evidence-contract
validator, and a shrink-only baseline of known defects. Details and the per-slice rule are in
`docs/handbook/web/testing.md` §4a.

Framework (`web/apps/web/test/features/`): `web/apps/web/test/features/harness.mjs` boots the disposable stack once; one real login per
user slot through the login and Open Company screens, reused through saved browser state because `/auth/login`
is limited to 10 per minute (`web/apps/api/src/app.ts:500`) and refresh tokens are single-use (re-login after 10
minutes, inside the 15-minute access cookie). Each case gets its own browser context, screenshots, API request
log and console errors; no request is intercepted. `web/apps/web/test/features/fixtures/catalogue.mjs` provisions the base company with the
real `seedCompany` and adds items, groups, local and inter-state parties, a bank account, opening stock, an
admin, a clerk without the delete right, a historic year and a second-tenant sentinel voucher.

First module, Sales Invoice (TR_SALE), 22 cases. Expected values are hand-computed from the desktop rules
(net-weight pricing when `SL_AMT_TYPE='N'`, components rounded to `TOT_AMT_ROF`, SGST = CGST = tax / 2
unrounded, delete writes DELETE_DATA at `TR_SALE.cs:16316-16322`). Result on the candidate: **16 passed, 3
failed, 3 blocked** — executed 86.36%, browser/business pass 72.73%, desktop match 0% (no Windows run).
Passed: book filtering and defaults, preview formula, create with cash, inter-state IGST, discount, reopen
round-trip, unchanged save is a no-op, edit re-prices and rebuilds a balanced ledger, delete reverses with
DELETE_DATA, PDF print, cheque-without-bank / no-lines / unknown-item refusals with no write, clerk delete
refused with the voucher intact, double-click creates one voucher, and the sale reaching the sales register
and day book. Failed (baselined): G169 two-group sale cannot save, G170 lost update, G171 no Alt+S save.
Blocked with reasons: T14 rollback needs a fault injector; T15 needs a settings-variant company; a
negative-weight line has no desktop rule to test against.

Six first-run failures were test bugs, each fixed against the desktop source rather than the web code: the
2-decimal default for a blank `TOT_AMT_ROF`, the unrounded GST halves, a non-existent `VCH_CLOCK` column,
Chrome logging 4xx answers as console errors, the PDF popup request, and Ctrl+S (the desktop uses Alt+S).
A negative control (dropping G171 from the baseline) failed the gate as a new failure, as intended.

Done when: each feature's matrix runs in CI on every pull request, every failure is a recorded gap in the
baseline, and each fixed defect leaves the baseline in the change that fixed it.


### N162 — A sale or purchase that posts to two item accounts writes one leg per line (G169, G176)

The desktop posts a bill's item side on one of two paths, chosen by `BOOK_DATA.ITM_TYPE`. The header path credits
or debits the book's slot-1 account once (sale `unified/src/csharp/DataCareNext/Ac_Ledr.cs:92`, purchase `:414-421`).
The line path posts each detail line to its group's `GROUP_MAST.SALE_AC` or `PURC_AC` for `A.NET_AMT`, keyed
`VCH_NO + STR(A.SR_NO) + code` (sale `:90`, purchase `:410`). The G169 row cited `:74` with code `05`; that
statement is the UAE `RATE_UNFIX = 'Y'` branch.

The web posts to per-group accounts but gave every item leg the family's single code `03` with no line number, so a
gold plus silver bill wrote two legs with one key and the save failed. Posting to several accounts is the line path's
behaviour, so such a bill now posts one leg per line: the tail is `STR(SR_NO)` (right-aligned in 10) followed by the
measured role code `03`. The decompiled code map disagrees with the measured one on every role, so its codes are not
borrowed. The layout is inferred: the captured data has no bill that posts to two item accounts. A bill whose lines
share one account keeps the measured single leg. With a bill discount the amount is shared by line value and the
last funded line takes the rounding remainder. A purchase whose labour is posted separately (PURC_WITH_LBR = 'N')
also collided, because its slot-4 labour leg used code `03` too; that leg now keeps the unmapped band (50 and up)
because its desktop code is not measured.

Code: `web/apps/api/src/modules/posting/lineLegs.ts`, used by the sale writer (`web/apps/api/src/modules/sales/sales.ts`)
and the purchase writer (`web/apps/api/src/modules/purchase/purchase.ts`). Tests: `web/apps/api/test/lineLegs.test.ts`
(vectors), `web/apps/api/test/saleTwoGroupRevenue.routes.db.test.ts` and
`web/apps/api/test/purchaseTwoGroupLegs.routes.db.test.ts` (write sets over HTTP: create, reopen and unchanged save,
edit, discount, single-account control, cash tender, labour split, delete), and the feature cases
`sales-invoice.create.two-lines-dissimilar` and `purchase-invoice.create.two-groups`, which now assert each group
account's amount and have left the baseline. Browser runs through the Chrome DevTools MCP covered both screens:
two-group bill typed in the grid, ledger checked, reopened, edited, printed and deleted.

Not verified: a desktop run. Found on the way: G184 (no slot 4 on a provisioned purchase book) and G185 (Enter in a
lookup can pick a row of an earlier list).

Done when: a sale and a purchase with lines from two item groups save, post each line to its group's account, and
reopen, edit, print and delete like any other bill.


### N163 — Alt+S saves the voucher, as the desktop &Save mnemonic (G171)

`unified/src/csharp/DataCareNext/TR_SALE.cs:4896` captions the save button `&Save`, and 106 desktop forms do the
same, so Alt+S saves on every one of them; the desktop has no Ctrl+S binding. The shell's global key handler
(`web/apps/web/components/GlobalFormKeys.tsx`, logic in `web/apps/web/lib/saveMnemonic.ts`) presses the first enabled,
on-screen button marked `data-save-mnemonic`. It matches the physical key, so Option+S works on a Mac, and it ignores
auto-repeat, so a held key cannot submit twice. The Save buttons of `web/apps/web/components/VoucherChrome.tsx`, the
shared voucher forms and the single-Save Standard voucher pages are marked; Order Cancel and Tag Print are not, because
their primary buttons are not a save.

Verified: unit tests `web/apps/web/test/saveMnemonic.test.ts`; the feature cases `sales-invoice.keyboard.alt-s-saves`
and `purchase-invoice.keyboard.alt-s-saves` pass through the real screen and left the baseline; a Chrome DevTools run
saved a Contra voucher with Alt+S from its amount box. Each remaining screen's Alt+S case comes with its feature module.

Done when: Alt+S saves on every Standard voucher screen, proven by each screen's feature module.


### N171 — Standard edition gate: only the Standard menus in navigation, rights, pages and API (G183, D31)

The desktop shows a menu only in its edition and above (`unified/src/csharp/DataCareNext/MDI_FORM.cs:11249-11322`
loads `MENU_DATA` by `SM_TYPE`). `web/scripts/generate-edition-table.mjs` builds `web/packages/core/src/editionTable.ts`:
each web route takes the lowest edition of the visible desktop menus it serves (from `docs/handbook/menu-editions.json`
and the menu catalog), and the routes and rights forms that serve no desktop menu row take the reviewed edition in
`docs/handbook/web-route-editions.json`, each with its reason. Every navigation item, page and rights form must be
classified, or the generator, its CI gate and a gated API all refuse.

`APP_EDITION` (default `L` since D33; `S` before) sets the running edition. The API refuses a higher edition's routes with
`403 edition-unavailable` before any rights or scope check (`web/apps/api/src/modules/rbac/editionGate.ts`), `/me`
reports the edition, and the rights editor lists only its forms. The screens list only its menus, name the edition in
the header and refuse a deferred page opened by URL (`web/apps/web/components/Shell.tsx`,
`web/apps/web/lib/editionNav.ts`). `APP_EDITION_BETA=1` opens the higher editions for internal use in a separate Beta
group, each page marked Beta. The deferred code stays compiled and tested: the harnesses build the application without
an edition, so every suite still runs.

Done when: a Standard deployment shows, allows and lists exactly the Standard menus, proven by the unit, API and
navigation tests and a browser run in Standard and with Beta.

### N169 — Users & Rights cannot leave the company without an administrator (G178)

`web/apps/api/src/modules/rbac/users.ts` refuses a category change that would demote the last administrator,
including the caller's own account, after locking the company's administrator rows so concurrent demotions cannot
both succeed. The Users & Rights screen shows the reason. Proven by `web/apps/api/test/lastAdministrator.routes.db.test.ts`
and the new feature module `web/apps/web/test/features/modules/usersRights.mjs`, whose other groups are recorded as
not yet written (document 15 step E11).

Done when: no sequence of rights changes leaves a company without an administrator.

### N172 — Voucher number box keys like the desktop (G179), Sales and Purchase first

`GET /vouchers/neighbour` (`web/apps/api/src/modules/vouchers/list.ts`, `web/apps/api/src/routes/voucherNavigation.ts`) runs the
desktop walk of `BtnLast_Click` and `BtnFirst_Click` (`unified/src/csharp/DataCareNext/TR_SALE.cs:17164-17222`): the next or
previous saved voucher within 10 numbers, the next new number after the last saved voucher, and "Last Record..." beyond it.
`web/apps/web/components/VoucherNumberKeys.tsx` gives the voucher number box F1, Up, Down and Enter, and
`web/apps/web/components/VoucherList.tsx` opens on F1 with the focus on its newest voucher. Proven by
`web/apps/api/test/voucherNeighbour.routes.db.test.ts`, `web/apps/web/test/voucherNumberKeys.test.ts` and the
`keyboard.voucher-number-keys` cases of the Sales and Purchase feature modules.

Done when: every Standard voucher screen's number box answers F1, Up, Down and Enter as the desktop does.

### N177 — Enter in a lookup picks the typed code, never a row of an older list (G185)

The desktop looks the typed code up exactly on Enter (`unified/src/csharp/DataCareNext/TR_PURC.cs:14619-14628`). The web
lookup searched 180 ms after the last keystroke, so Enter pressed straight after typing picked the first row of the
previous list. `web/apps/web/components/LookupPicker.tsx` now remembers the text each list was fetched for, ignores an
answer for older text, and on Enter with a list for other text looks the typed code up exactly before picking
(`web/apps/web/lib/lookupEnter.ts`). Proven by `web/apps/web/test/lookupEnter.test.ts` and the feature cases
`sales-invoice.lookup.code-enter-at-once` and `purchase-invoice.lookup.code-enter-at-once`, which fail against the old
component with the 30 October symptom.

Done when: typing a code and pressing Enter at once always puts that code on the voucher, on every lookup.


### N174 — The printed HSN summary agrees with the tax summary and totals the bill tax (G181)

`web/apps/api/src/modules/documents/docChrome.ts` splits the header tax heads across the HSN groups for every GST bill, as
every desktop sales bill prints `SL_DATA.CGST_TAX` and `SGST_TAX` and never the line halves
(`extraction_output/rpt_xml/SalesBillA4Gst.xml`, `extraction_output/rpt_xml/B2BSaleBillA4Tax.xml`). Each group takes its
taxable share rounded half-up and the last group the exact remainder. Proven by `web/apps/api/test/documents.test.ts` and
the `print.hsn-agrees-with-summary` case of `web/apps/web/test/features/modules/salesInvoice.mjs`.

Done when: on every printed GST bill the HSN columns add up to the printed heads and the Tax column to the bill tax.


### N173 — A print window opens the document after the access cookie has expired (G180)

`web/apps/web/lib/openDocument.ts` opens the window inside the click and points it at the document only after an API
call has refreshed the session; the screens' `window.open` calls use it, and `web/apps/web/components/GlobalFormKeys.tsx`
sends new-tab `/api` links the same way. Proven by `web/apps/web/test/openDocument.test.ts` and the
`print.after-access-expiry` case of `web/apps/web/test/features/modules/salesInvoice.mjs`.

Done when: no print, PDF or export window shows `unauthenticated` while the session can still refresh.

### N186 — Every server started after a build serves that build (G197)

`web/apps/web/package.json` runs `web/apps/web/scripts/clearRouteCache.mjs` after `next build`, which removes the route
cache a previous server wrote. Proven by `web/apps/web/test/clearRouteCache.test.ts` and a real build.

Done when: no local browser run can be answered with a previous build's page.


### N56 milestones 1–2 — Canonical dates and printed years (G36, D19)

`web/packages/core/src/dates.ts` converts dates for transport (`toIsoDate`) and display (`formatDesktopDate`,
`dd/MM/yyyy`). The printed documents and `web/apps/web/components/VoucherList.tsx` use them, and
`web/apps/api/src/modules/ops/kernelConformance.ts` refuses a new date sliced from its string form. Milestone 2
migrates the remaining 50 executable API transport sites to `toIsoDate`, removes the detector's self-matching
example comment, broadens the direct-string-truncation rule for `dbText`/`txt` and date/day aliases, and migrates
the additional direct slices and local date helpers exposed by independent review. The date-normalization baseline is
now empty, and
`web/apps/api/test/kernelConformance.test.ts` requires it to stay empty. Browser form hydration now uses
`toIsoDate`, while dedicated lists, messages and saved views use `formatDesktopDate`; the Order report binder formats bound date fields before rendering, and `web/apps/web/test/dateConformance.test.ts` guards the browser
policies. The two fixed Sales Order G36 cases leave the shrink-only feature baseline. The original display behavior is covered by `web/packages/core/test/dates.test.ts`, `web/apps/api/test/documents.test.ts` and the
`print.date-with-year` case of `web/apps/web/test/features/modules/salesInvoice.mjs`.

Implementation status is `implemented-unverified`: direct execution of the conformance detector reports zero date
normalization bypasses, while the full dependency-backed and real-browser gates still need a successful run.

Done when: no document or list prints a date without its year and the date-normalization rule is at zero.

### N51 milestone 2 — Sale version tokens (G170, D17)

`web/apps/api/src/modules/vouchers/version.ts` hashes a voucher's complete write set. `GET /sales/:vchNo` returns it
as `version`; `PUT` and `DELETE` require it as `expectedVersion` (`web/apps/api/src/routes/saleVoucher.ts`), and
`web/apps/api/src/modules/sales/sales.ts` refuses a stale one with `409 voucher-version-conflict` after locking the
header and before any write. Proven by `web/apps/api/test/saleVersion.routes.db.test.ts` and the
`concurrency.stale-second-save` case of `web/apps/web/test/features/modules/salesInvoice.mjs`.

Done when: every Standard voucher family refuses a stale update or delete.


### N164 — UI surface map: every page and every button, plus a browser test with every behaviour change (G172)

`web/apps/web/test/features/run-surface.mjs` crawls every route an operator can reach — the 235 sidebar links
(234 distinct routes; Accounts is linked twice) and 7 pages the menu does not link (`/txn/cheque-print`,
`/txn/e-crnt-note`, `/txn/e-invoice`, `/txn/membership`, `/txn/other-commission`, `/txn/wholesale-sale-return`,
`/password-change`) — as a logged-in operator on the disposable stack. It records every control and API call,
probes the main action on the empty form and a missing-voucher load, runs reports and their PDF, and in sweep
mode presses every distinct button (844 presses). The result is committed as
`docs/handbook/web/ui-surface-map.md`, joined with the desktop menu-catalog status and the journeys or feature
modules that already prove each route's lifecycle.

Result of the full sweep: all 241 routes render and behave at smoke level — no crash, no server error, no lost
session, no refusal hidden from the operator. 22 empty-form saves are blocked by required fields; the rest refuse
with a visible message. Three medium findings are the desktop's own behaviour and are recorded as `byDesign` with
their source (HDD Registry saves an empty entry, `UT_HDD.cs:765`; two reminder tabs with a count of 0). 22 routes
have deep lifecycle tests; the other 219 are proven only at this smoke level, which is the coverage still to build.

Open review items (low, not gated): 172 buttons showed no visible effect on an empty company. Most are expected
(`New` on a blank form, removing the only row, `Load` with no number), but `CSV` on 75 report pages did nothing on
an empty report while `Excel` downloaded, and `Post Installment` / `Post Maturity` / `Post Points` gave no message
on an empty form. These need a rerun with data before they are called defects.

Building the crawl found G172 (two sessions opening the company at the same moment show the raw code
`context-transaction-conflict`).

The same change makes the browser-test rule binding: `web/scripts/check-browser-test-coverage.mjs` runs in
static-gates on every pull request and fails one that changes a page, component, web library, API module, route
or core calculation without changing a browser test; files listed in
`web/apps/web/test/features/coverage-map.json` must change their own feature module. A PR with no browser-visible
effect says why in its body (`Browser-Test-Exempt: <reason>`). Checked against history: the N157 commit (a
`sales.ts` change without a browser test) fails, the same diff with an exemption passes, the N161 commit (tests
only) passes.

Every defect found so far is now a planned slice: N162 (G169 two-group sale), N163 (G171 Alt+S save), N51 now
carries G170 (lost update), N165 (G172), N166 (G173/G174 rollback and settings-variant infrastructure), N167
(G175 negative-weight rule).

Done when: the map is regenerated from a full sweep whenever screens change, the probe gate runs on every pull
request, and no behaviour change merges without a browser test or a stated exemption.


### N170 — Deep feature modules on real data: Purchase Invoice and Company Settings (G176–G178)

The surface map of N164 was crawled on a company with masters only. N170 makes the suite run on real business data
and goes deeper. The feature runner now provisions one company for the whole run, and each module adds its
vouchers to it through the screens, as a shop's day would. With `FEATURE_E2E_THEN_SURFACE=1` the runner then crawls
every page and presses every button on that data; the committed `docs/handbook/web/ui-surface-map.md` now comes
from this run (241 routes, 848 presses, 43 of 88 reports returned rows after Run; all routes behave at smoke level).

**Purchase Invoice (TR_PURC), 21 cases** — expectations hand-computed from the desktop fine-weight rule
(`PR_AMT_TYPE='F'`, TR_PURC.cs:7396): 16 passed, 3 failed (baselined), 2 blocked. Passed: book filter and defaults,
preview, create (header, lines, MAIN_STOCK +20, balanced ledger, supplier credited with the bill total, sentinel
untouched, purchase register), inter-state supplier gets IGST without a manual toggle, URD with no GST, discount,
reopen, unchanged save, edit re-prices on fine, delete reverses with DELETE_DATA, bill print, refusals, a clerk
without the purchase right writes nothing, double-click makes one purchase, the purchase raises item stock and
reaches the register and day book. Failed: G176 (gold + silver purchase cannot save, the purchase twin of G169),
G170 (lost update, now shown on purchases too) and G171 (no Alt+S save).

**Company Settings and their effect on a sale, 24 cases (13 applicable)** — each consumer case changes one setting
through the Settings screen, makes a sale through the Sales screen, compares the stored result with the desktop
rule and restores the setting: 10 passed, 1 failed, 2 blocked, 11 not applicable with reasons. Passed: every
setting on a tab (all CO_SET and CO_SET_NEW settings), a change is stored and shown again after reload, a
non-numeric cash limit is refused, `SL_AMT_TYPE=F` prices a new line on fine (56,090.80, RATE_WITH F),
`NEGATIVE_STK_SALE=N` refuses an oversell and still allows an in-stock sale, `TOT_AMT_ROF=0` rounds the line
banker's-style to 61,234 and the bill to 65,517, `LOCK_DATE` refuses a sale on the lock date, `CASH_LIMIT`
refuses cash above the limit with the desktop message, `PAN_CARD_VAL` refuses a no-PAN party above the limit and
allows a party with a PAN, and a clerk cannot change a setting. Failed: G177 — the PAN limit can only be 100000 or
200000 on the web, while the desktop combo is editable (FONT_SIZE, GRID_ROW_HIGHT and VCH_DESC_HELP_LENT have
the same shape). Message differences recorded as observations: the negative-stock and period-lock refusals use web
wording, not the desktop's "Negative Stock is Not Allow …" and "You Cant Save and Delete This Voucher …".

**Sales Invoice** gains `output.register-csv`: the sales register's CSV export contains the saved voucher
(passed). This settles the N164 review item: the CSV buttons that "did nothing" on an empty company had no rows
to export, which is the intended behaviour.

**G178 (High)**, found on the live demo database while checking a report: `admin` had been changed to an ordinary
user with every right `N` (`POST /admin/users/:loginName/rights` answered 200), and from then on every admin
request answered 403. Nothing stops the only administrator from removing their own role. Planned as N169.

Done when: every daily voucher screen has a module like these, run on shared real data, and the map is
regenerated from that run.

### N180 — Sales Return feature module on real data (G190–G196)

**Sales Return (TR_SALE_RTN), 24 cases**, run through the real screen on the shared company. Expectations come
from the desktop return rules: the line is priced on `CO_SET.SL_AMT_TYPE` (net + ghat for `N`,
`TR_SALE_RTN.cs:4914-4931`); the item amount, the labour amount and the bill total are rounded to whole rupees
whatever the settings (`:4955`, `:4985`, `:16405`); tax is rounded with `TAX_ROF` (`:16402`). Result: 14 passed,
7 failed (baselined), 3 blocked.

Passed: book filter and defaults; create effects (stock +10, customer credited with the bill total, balanced
ledger); gold and silver lines on one return; inter-state IGST; cash refund; the no-lines and missing-bill
refusals write nothing; delete reverses stock and ledger and writes DELETE_DATA; the credit-note print; reopen in
the Saved returns panel; a clerk without the return right writes nothing; a double-click makes one return; Alt+S
saves; and the J07 journey, where a sale and its full return put the stock back, move the customer by the sale
total less the return total, and the return reaches the sales-return register.

Failed: G190 twice (fine basis with paise: 58,465.80 where the desktop has 63,609), G191 (an imported loose line
carries tag `N` and Save refuses it), G192 (Tax % covers Import), G193 (the second of two deletes answers 500),
G194 twice (the return stores no creator, and its delete records the tenant id as the deleting user). Blocked:
numeric edit of a saved return (planned in N10/N11), T14 rollback (G173) and T15 settings variant (G174).

Two first-run failures were test bugs: the return lines live in `SL_DETL_RTN`, and the Saved returns panel
clears the voucher box when its book finishes loading, so the case now picks the book before typing.

**Correction to N161 and N170.** Both narratives say sale line amounts are rounded with `TOT_AMT_ROF`. The
desktop rounds them to whole rupees unless `ALL_ROF_REMOVE = 'Y'` (`TR_SALE.cs:10343-10362`, `:10905`,
`:11100-11108`); `TOT_AMT_ROF` rounds only the bill total (`:19192`, `:19274`). The merged expectations
`sales-invoice` EXPECT_A (61,234.50) and `settings.effect.sale-amount-fine` (56,090.80) are therefore web values;
the desktop gives 61,234 and 56,091. This is G195; N184 moves those cases to the desktop values. The
`settings.effect.whole-rupee-rounding` case keeps its numbers (61,234 and 65,517), but its line rounding comes
from the whole-rupee rule, not from `TOT_AMT_ROF`. G196 records that a new web company has blank rounding
settings, which the web reads as 2 decimals, while the desktop schema defaults them to whole rupees.

Done when: every daily voucher screen has a module like this, run on shared real data, and each fixed defect
leaves the baseline in the change that fixes it.

### N181 — Sales Return amount basis and whole-rupee stages (G190)

The New return screen and writer now follow `TR_SALE_RTN.cs:4892-5030,16384-16407`. The server resolves
`CO_SET.SL_AMT_TYPE`; N and blank use net plus ghat, G uses gross, F uses fine, and the desktop's nominal P company
mode falls through to the N branch while item `RATE_TYPE=P` still prices pieces. Item, labour, line-net and final-total
stages round directly to whole rupees with midpoint-to-even semantics; tax keeps `TAX_ROF`. The browser preview uses
the same shared policy as the writer.

The independent N-basis fixture stores 61,234 item plus 2,375 labour, 63,609 net, 1,908.27 tax and 65,517 total. The
F-basis control stores 56,091 plus 2,375, 58,466 net, 1,753.98 tax and 60,220 total. Core vectors include a 1.499
case to prove no two-decimal intermediate. The database test checks header, detail, stock, tax, ledger and Rojmel
amounts. `sales-return.formula.net-basis`, `sales-return.create.amount-net-basis` and the formerly blocked F-basis
T15 case pass; the two G190 entries left the shrink-only baseline. Latest browser result: 23 passed, 0 failed and 2
blocked among 25 applicable cases. The quality, API/database, zero-mock browser and UI-surface CI jobs passed.
Original-Windows side-by-side and operator acceptance remain open.

### N182 — Sales Return: an imported loose line saves, and Import can be clicked (G191, G192)

G191: the return writer treated any non-blank tag as a tag to verify, so a loose sale line imported with
`TAG_NO` `N` was refused on save. The desktop copies `N` into the return grid as it is (`TR_SALE_RTN.cs:3917`)
and every tag step skips it (`:4773`, `:8585`, `:13387`, `:13395`). The writer now treats blank and `N` as no tag
(`web/apps/api/src/modules/sales/salesReturn.ts`), so the line saves as loose stock with `TAG_NO` `N`, as the
desktop stores it (`:14326-14334`); a real tag still has to be a line of the original sale.

G192: the Orig Bill No input kept its default width, so the Import button spilled under the next field (Tax %),
which took the click. The input now shrinks inside its field and the button keeps its size
(`web/apps/web/app/(app)/txn/sale-return/page.tsx`).

Evidence: `sales-return.create.from-bill-import` (Import clicked with the mouse, the return saves and stores tag
`N`) and `sales-return.ui.import-button-clickable` pass, and both leave `web/apps/web/test/features/baseline.json`; the Sales
Return module runs 16 passed, 5 failed (baselined), 3 blocked. A new database test in
`web/apps/api/test/salesFamilyLifecycle.db.test.ts` saves a line marked `N` as loose stock and still refuses the
unknown tag `NOSUCH`; it fails without the fix. The two return lifecycle test files pass (39 tests).

Also checked by hand in the local Chrome on the seeded stack (`web/apps/web/test/features/serve.mjs`): at 1600 px
Import is the top element at its own centre and ends 12 px before the Tax % box; importing sale 00002 with a mouse
click filled `E2ELOC` and a `GLD22` line with tag `N`, Save answered 201, and the database holds `SL_DETL_RTN.TAG_NO`
`N` with `VCH_SRNO` 0 and a `MAIN_STOCK` + 10 g row with tag `N`. The same screen still prices the line on fine weight
(58,465.80), which is G190 (N181).

### N187 — Purchase Return feature module on real data (G198–G201)

**Purchase Return (TR_KR_ISU in PURC RETURN mode), 22 cases**, run through the real screen on the shared company.
Expectations come from the desktop form: metal = fine × rate and per-gram labour = (net + ghat) × rate, each
rounded to whole rupees (`TR_KR_ISU.cs:4015`, `:4028`); the bill summed and its total rounded to whole rupees
(`:6522`, `:6528`), tax with `TAX_ROF` (`:6527`); metal goes out of stock and the supplier is debited; the tender
has no UPI (`:5066-5072`). Lifecycle cases use a line whose amounts are whole rupees (5 g at 1,500, 40/g), so only
the rounding cases depend on rounding. Result: 15 passed, 5 failed (baselined), 2 blocked.

Passed: book and defaults; create effects (stock −5, supplier debited with the total, balanced ledger, creator
recorded); a return against a purchase imported from the Purchase screen; gold and silver lines on one return;
an inter-state supplier on IGST; the no-lines and UPI refusals write nothing; reopen by voucher number; an
unchanged save changes nothing and a new weight re-derives the line keeping number, hidden number and creator;
delete reverses everything and writes DELETE_DATA with the user; the debit-note print; a clerk without the right
writes nothing; two operators deleting the same return (the second answers 400 and stock is restored once); a
double-click makes one return; and the J07-style journey (a purchase and its full return put the stock back and
move the supplier by the return total less the purchase total).

Failed: G198 twice (amounts keep paise: 58,465.80 where the desktop has 58,466), G199 (a free-standing return
cannot be saved until an original purchase book is chosen), G200 (Alt+S does nothing on this screen) and G201
(the Purchase Return Register lists nothing). Blocked: T14 rollback (G173) and T15 settings variant (G174).

### N188 milestone 1 — Purchase Return whole-rupee stages (G198)

The Purchase Return preview and writer now follow `TR_KR_ISU.cs:3938-4036,6517-6538`. The item basis is the
three-decimal fine cell unless item `RATE_TYPE=P` selects pieces; `1` and `K` only change the divisor. Company
`PR_AMT_TYPE` does not alter this form. Item and labour amounts round directly to whole rupees with midpoint-to-even
semantics, fractional other charges remain in the line, header net and final total round to whole rupees, and
purchase-rate and tax precision remain independent.

The fixture now previews and stores fine 9.160, item 56,091, labour 2,375, net 58,466, tax 1,753.98, round-off 0.02
and total 60,220. The database test checks PR_DATA, PR_DETL, MAIN_STOCK sign and amounts, TAX_DATA, balanced AC_DATA
and Rojmel presence. Both G198 cases pass and left the baseline. Latest browser result: 20 passed, 0 failed and 2
blocked among 22 applicable cases; full quality, database, zero-mock browser and UI-surface CI passed. N188 remains
in progress because its ordinary Purchase half and paise-producing Purchase proof are still open.

**Scope note for G193.** The purchase-return delete answers 400 for a voucher that is already gone, so G193 is
narrower than recorded: it is the sale-return delete (and any writer whose route does not map
`PersistedVoucherNotFoundError`) that answers 500.

Done when: every daily voucher screen has a module like this, run on shared real data, and each fixed defect
leaves the baseline in the change that fixes it.

### N192 — Lite first: per-tier delivery progress page (D32, G202)

The owner asked on 31 October 2026 that the Lite edition be made to work end to end like the desktop first, and the
features of the further editions added after it. D32 records the order: Lite (49 menus), then the menus Basic adds
(29), then the menus Standard adds (36), then the editions above Standard. Document 15 §5 groups the Lite menus
into packages L1–L6 (PR #162).

`web/scripts/generate-standard-progress.mjs` writes `docs/handbook/web/standard-progress.md` from
`docs/handbook/menu-editions.json`, `docs/handbook/menu-catalog.jsonl` and the feature E2E coverage map and
baseline: per tier, how many menus have a browser feature module, how many have no open defect, and how many are
done (catalog row FULL and no open defect), with every menu's routes, module, state and open gaps. On 31 October:
Lite 49 menus, 5 with a module, 3 with no open defect, 0 done; Basic 29, 1 and 1, 0; Standard 36, none yet.
`--check` reports a stale page.
### N190 — Alt+S saves on every voucher screen (G200)

N163 made Alt+S press the button marked `data-save-mnemonic`, the desktop's `&Save` mnemonic (for example
`TR_KR_ISU.cs:2330`), but 20 voucher pages, Purchase Return among them, had an unmarked primary Save. Those 20 are
now marked, and two more found by the new scan (Lot Intake on `item-lot`, Post Weight Change on `tag-weight-diff`).
`web/apps/web/test/saveMnemonicCoverage.test.ts` reads every `app/(app)/txn/*/page.tsx` and fails when a primary
button labelled Save, Update, Post, Issue or Receive is unmarked, unless the page renders a shared form that marks
its own button; it also refuses two marks on one page. Two pages with several independent forms (`membership`,
`scheme`) are listed with their reason: Alt+S there must press the focused form's Save, which `findSaveButton`
does not do yet, and neither menu is in the Standard edition.

Evidence: `purchase-return.keyboard.alt-s-saves` passes in the browser and leaves the baseline; a negative control
(Purchase Return unmarked) fails the scan.

### N195 — Sales Order feature module (G205–G208)

`web/apps/web/test/features/modules/salesOrder.mjs` drives Transaction → Sales Order (desktop `TR_SALE_ORD`,
`MDI_FORM.cs:7992-8003`) through the real screen: 25 cases over T01–T18. Expected values come from the desktop:
whole-rupee metal on the SL_AMT_TYPE basis (`TR_SALE_ORD.cs:6560-6672`), labour from its own rate (`:6858`), tax and
total rounded to rupees (`:11340-11342`), the advance as the sum of the tender rows (`:11368`) posted by Order_Ledr
(`Ac_Ledr.cs:28-61`), and the refusals for a missing party (`:9040`) and a date after the year (`:9012-9015`).

The run gave 14 passed, 9 failed (all baselined) and 2 blocked. Two expectations were corrected against the
desktop before baselining: the desktop re-prices labour only when its rate or amount changes (columns 84 and 85,
`:6800-6836`), so a weight-only edit is not a defect, and the printed order is the desktop `OrderBill` layout, not
the confirmation page. The failures are G205 (fine-weight pricing with paise), G206 (one cash advance, no tender
breakdown), G207 and G208 (provisioning of the order and sale book slots), G193 (a second delete answers 500) and
G36 (the order list and the printed bill show `2026-10-31`; N56 is in progress).

### N196 — Sales Order line priced on SL_AMT_TYPE in whole rupees (G205)

`web/packages/core/src/salesOrderAmount.ts` holds the TR_SALE_ORD rules. The metal weight follows SL_AMT_TYPE: fine for
F (net + ghat at touch + wastage, or net when those are blank), gross for G, net + ghat otherwise
(`TR_SALE_ORD.cs:6571-6627`). The line's rate type then prices pieces, per 10 g or per kg (`:6646-6672`), and every
branch rounds to whole rupees, half to even. The bill takes tax as round(net × %, 0) and the total as
round(net + tax, 0) (`:11340-11342`). `web/apps/api/src/modules/sales/salesOrderPricing.ts` applies them to a Sales
Order only; the Tour Order is its own desktop form (TR_TOUR_ORD) and keeps its pricing. The screen gets the basis from
`GET /sales-orders/configuration` and previews the same amount (`web/apps/web/lib/salesOrderForm.ts`).

One existing expectation changed: `salesOrderRound4.db.test.ts` priced a copied touch on the fine weight (184) on a
company whose SL_AMT_TYPE is blank, which the desktop reads as N, so the metal is net × rate (200).

Evidence: `sales-order.formula.whole-rupees` and `sales-order.create.amounts` pass in the browser and leave the
baseline (sales-order 16 passed, 7 baselined); the new DB test pins 61,234 / 1,908 / 65,517 on N and 56,091 / 1,754 /
60,220 on F and fails on the previous writer; core tests cover the bases, rate types and half-even rounding.

### N197 — Sales Order cash, cheque and card tenders (G206, part)

`web/apps/api/src/modules/sales/salesOrderTender.ts` takes the order's money tenders as TR_SALE_ORD does. The screen's
Advance is the cash tender; Cheque Amt (with Bank A/c and Cheque No) and Card Amt (with Card A/c) are now editable in
the order details. The header stores CASH_AMT, CHQ_AMT and CARD_AMT, and ADV_AMT is their sum
(`TR_SALE_ORD.cs:9131-9150`, `:11368`). A cheque without its bank, or a card amount without its account, is refused
with the desktop message (`:8988-8996`). Order_Ledr's legs are written with their desktop leg types: 01/02 cash
(party CR, slot-1 account DR), 03/04 cheque and 05/06 card, with LD_CODE, CHQ_NO, BILL_NO, the party as PARTY_AC_CODE
and the 'CASH - ', 'BANK - ', 'CARD - ' names (`Ac_Ledr.cs:28-47`). The day book credits the whole advance (type 01)
and debits the cheque's bank (02) and the card account (03) (`Ac_Rojmel.cs:11-16`). A reopened order shows its cash,
cheque and card separately; an order saved before this change keeps its cash in ADV_AMT. Tendered orders are no
longer blocked from editing. The Tour Order (TR_TOUR_ORD) keeps its single cash advance. UPI, old metal and scheme
remain read-only; their slice is recorded once the IDs held by #169 are merged.

Evidence: `sales-order.create.cheque-card-advance`, `refusal.cheque-needs-bank` and `create.header-tender` pass in
the browser (sales-order 19 passed, 6 baselined, 2 blocked); a DB test pins the header, legs 01-06 and day-book rows
01-03; `salesOrderSessionCommand.db.test.ts` now expects CASH_AMT to follow an advance edit.

### N199 — Party Opening is the desktop TR_AC_OPBL (G209, G210)

`web/apps/api/src/modules/finance/partyOpening.ts` holds every opening write. A save replaces the party's OP_DATA row in
book '000', voucher '00000', with the Cr/Dr signs the desktop stores (`TR_AC_OPBL.cs:2694-2722`), then replaces its
ledger legs as AcOp_Ledr does (`Ac_Ledr.cs:9-28`): 01/02 amount Cr/Dr, 03/04 gold Cr '+' / Dr '-', 05/06 silver, dated
the day before the year opens. A delete writes the two DELETE_DATA rows and removes OP_DATA, OP_DETL and the legs
(`:2856-2880`). The screen `/txn/ac-opbl` follows the desktop: Party Code, the three heads with Cr/Dr (default Cr),
Save, Delete, Cancel, the opening list by balance type, and the desktop messages. The Party master's inline opening, the
Opening Balance page and the year carry-forward use the same writer, and the party balance no longer adds OP_DATA to
AC_DATA. The bill-wise grid (OP_DETL) is on the screen too (G211, N200): its signed totals set the heads, as MSG_TOT_FILL
does. The two carry-forward paths are G212 (N201).

### N183 — Stale-voucher answers and the real user on create and delete (G193, G194)

`web/apps/api/src/modules/vouchers/lifecycle.ts` gives `PersistedVoucherNotFoundError` a stable reason
`voucher-not-found` with status 404, and its ambiguous twin `voucher-ambiguous` with 409; `run()` in
`web/apps/api/src/routes/txn.ts` answers them, and `statusCode` gives routes outside `run()` the same answer. A voucher
another operator has already deleted is a stale document (`03-shared-contracts.md`, conflict rule 9), not a server
fault. `POST /sales-returns` now passes the login name as `mainUser` (`TR_SALE_RTN.cs:9966`, `:12908`), and the seven
delete routes that passed the tenant id as the delete user (sales return, labour invoice, multi receipt, multi payment,
MFG order issue, MFG, fine sale) pass the login name (`TR_SALE_RTN.cs:15076`).

Evidence: `sales-return.concurrency.double-delete`, `sales-return.create.records-user`,
`sales-return.delete.audit-user` and `sales-order.concurrency.double-delete` pass in the browser (second delete 404)
and leave the baseline. `web/apps/api/test/voucherLifecycleAnswers.routes.db.test.ts` proves over HTTP that a return
records the login on create and delete, that a second delete answers 404 with no second DELETE_DATA row, and that no
voucher route passes the tenant id as the delete user; both tests fail on the previous code.

### N202 — Lite is the running edition (D33, G213)

`APP_EDITION` now defaults to `L`. The navigation, the page guard and the API gate (N171) therefore show and allow only
the 49 Lite menus; `APP_EDITION_BETA=1` lists the Basic and higher menus in the Beta group. `GET /settings` and
`GET /integrations/device-settings` pass the gate in every edition (`EDITION_EXEMPT_ROUTES`), because every edition
loads the company settings when a company opens (`MS_OPNCOMP.cs:657-684`); saving settings stays a Basic action.
`liteEditionCalls.test.ts` scans every Lite page and shared module for its API calls and fails if one needs a higher
edition, and `edition.real-stack.mjs` checks the Lite navigation, a refused Basic screen and API, the settings read,
the Sales screen, and the Beta group in a real browser.

### N203 — Tag Opening and Only Tag Entry are the desktop TR_TAG_OPBL (G214, G215, G216)

The two menus share `/txn/tag-opening`: Tag Opening lists the opening books (OPSTK and the web's TAG OPENING), Only
Tag Entry (`?mode=TAG GEN`, a new Inventory menu entry) lists the TAG GEN books, and provisioning adds the TGN book
(TAG GEN, short name TGEN). Only Tag Entry shows and requires the stock item; Tag Opening hides it and draws on no loose
stock. Reopening a voucher copies every field the API returns back into the grid and restores the stock item, and the
Fine column shows the stored fine until weight, touch, ghat or wastage change, as the desktop recomputes it. The
writer follows Tag_Opbl_Stk (`Ac_Stock.cs:22-36`): P / 'TAGOP' / 'TAG OPBL' rows for an opening book, I / short name /
'TAG GEN' rows plus one 'O' relief row by the voucher's totals for Only Tag Entry, ITM_QTY 1, and the tag's wastage,
labour rate, karigar cost and design on each row. Duplicate tags, a missing stock item and the delete of a sold tag are
refused with the desktop texts; delete asks the desktop question and reports "Delete Success.". The voucher number box
has the N172 keys (Enter, F1, Up, Down) and the recent list reads BAR_DATA. The relief row leaves the counter empty, as
the decompiled insert does (`Ac_Stock.cs:28`), although 30 of the 31 migrated relief rows carry counter 001. The karigar
weight block is G217 (N204).

### N204 — The tag grid's karigar weight block (G217)

The tag grid carries KrOthWt, KrNwt, KrGht%, KrGht, KrTouch, KrWst% and KrFine with the desktop headers
(`TR_TAG_OPBL.cs:5146-5172`), in the full grid after the base columns and in each row's desktop fields. Leaving a cell
runs CommPassTotal's karigar block (`:6679-6826`), ported to `@datacare/core` as `tagKarigarBlock`: KrNwt is gross −
KrOthWt while both are non-zero, otherwise a blank KrNwt takes the net weight and a typed one stays (`:6690-6704`);
with no karigar touch or wastage KrFine is KrNwt + KrGht (`:6793-6800`), otherwise a blank KrFine is (KrNwt + KrGht) ×
(KrTouch + KrWst%) / 100 (`:6804-6811`) and a typed one stays until KrNwt, KrTouch, KrWst% or KrGht changes (`:6712`,
`:6749`, `:6771`, `:6815`). The save writes the block as BtnSave_Click does (`:10975-11022`, `tagKarigarColumns`):
KR_NET_WT is the KrNwt cell, and without a KrTouch the row takes the tag's own touch, wastage and fine (`:11010-11012`).
Tag_Opbl_Stk copies KR_NET_WT, KR_TOUCH, KR_WEST_PRC and KR_FINE to MAIN_STOCK KR_NWT, KR_TOUCH, KR_WEST and KR_FINE
(`Ac_Stock.cs:28`), and reopen reloads the seven cells (`:10478-10491`). The migrated data agrees: 1327 of 1330 tags
store KR_NET_WT = ITM_NWT, 92 of the 93 with no KrOthWt and a net below the gross store the net weight, and all 1170
opening tag stock rows carry their BAR_DETL karigar values.

Not covered: the order, manufacturing and lot paths fill the block from other vouchers (`:5572-5584`, `:8330-8368`,
`:8586-8600`, and the lot branch of the save at `:10990-11005`); the web tag screen has no lot header or order pull, so
these stay with those features. The MsUserKrTouchHide setting that hides KrTouch, KrWst% and KrFine for non-admin users
(`:5156-5172`) is not applied.

Evidence: `tagKarigar.test.ts` (core, 9 cases) and the new case in `tagOpeningStock.db.test.ts` (BAR_DETL and
MAIN_STOCK for a tag with a block and for one without a KrTouch; it fails with main's writer) pass with
`tagOpeningRoundTrip.db.test.ts`, whose rich line now carries the block. The zero-mock `tag-opening` module passes 14
cases with 5 blocked, including `formula.karigar-block` (typed through the screen: KrNwt 10.000 and KrFine 9.584 shown,
then stored in BAR_DETL and MAIN_STOCK). Chrome DevTools on the demo stack: the block typed in the full grid showed
KrNwt 10.000 and KrFine 9.584 after leaving the cell, saved as BAR_DETL 0.5 / 10 / 2.5 / 0.25 / 92 / 1.5 / 9.584 and
MAIN_STOCK KR_NWT 10, KR_TOUCH 92, KR_WEST 1.5, KR_FINE 9.584, reopened with Enter in Vch No with every cell, saved
unchanged with the same values, and deleted with the desktop prompt. Desktop-runtime comparison and parent acceptance
remain open.

### N205 — Browser suites run against the build they were given (G218)

`next.config.mjs` clears the route cache when the production server starts (`PHASE_PRODUCTION_SERVER`), so a server
serves its own build however the build was produced, including a turbo cache replay. Every real-stack suite and the
feature harness call `assertPortsFree` before they start their servers and stop with the port named when something
already answers there.

### N189 — A purchase return without an original purchase saves (G199)

`web/apps/web/components/BookSelect.tsx` takes `required` (default true). The voucher's own book stays required; the
Purchase Return's Orig Purchase Book passes `required={false}`, because the desktop needs only the party and the voucher
number to save a return (`TR_KR_ISU.cs:4986-4999`) and the writer already stores no original reference when there is no
original voucher. The browser no longer blocks Save on a blank original book, so a free-standing return saves and a
reopened free-standing return saves unchanged.

Evidence: `purchase-return.create.without-original` passes and leaves the baseline; `edit.unchanged-and-reprice` now
saves the reopened return without choosing a book; `create.against-purchase` still imports and saves with PR chosen;
`web/apps/web/test/bookSelect.test.ts` pins the default and the opt-out.
### N191 and N198 — Book tables and the order/sale advance slots, with a backfill (G201, G207, G208)

`web/apps/api/src/modules/ops/seedCompany.ts` now gives the sale, sales-return, purchase, purchase-return, tag-purchase,
sales-order, contra, fine-JV, other-income and other-expense books the desktop's `BOOK_TBL_NAME` and `BOOK_TBL_DETL`
(`MS_UPDATE.cs:7829`, `:7837`, `:7841`, `:7849`, `:7897`, `:7933`), only for families whose web writer uses the same
header table. The SALES ORDER book's slot 1 is the cash account: Order_Ledr debits it with the cash advance
(`Ac_Ledr.cs:28-35`), and on the real data every cash leg 02 of book 020 is `00001` CASH ON HAND. The SALES book gets
slot 4, a new system account ORDADV "ORDER ADVANCE" (the real chart's `00020 ORDER ADVANCE`, group 04), which Sales_Rojmel
names for an adjusted advance (`Ac_Rojmel.cs:96`); the desktop posts no ledger leg for it.

`web/packages/db/prisma/migrations/20261031090000_book_tables_and_advance_slots/migration.sql` brings existing companies
to the same state: it fills blank table names only, adds ORDADV and slot 4 only to sale books with the web layout
(slot 1 SALES), and moves the order books' slot 1 from SALES to CASH only where the CASH account exists. Desktop data is
not touched.

Evidence: `purchase-return.report.register-lists-return`, `sales-order.create.advance-ledger` (Dr CASH / Cr customer)
and `sales-order.journey.order-to-sale` (sale 7,931 with the 5,000 advance leaves 2,931 outstanding) pass in the browser
and leave the baseline. `web/apps/api/test/bookTablesMigration.db.test.ts` runs the migration's statements on old-layout
and desktop-shaped rows: it fills the first, leaves the second unchanged and is idempotent; the provisioning test pins
the new table names and slots.

### N206 — Fine Jv Entry is the desktop TR_CONTRA grid in FINE JV mode (G219, Lite L4)

The menu opens only the inward FINE JV book (`MDI_FORM.cs:8360-8365`, `Ac_Ledr.cs:846`) and shows the desktop grid: Sr,
Cr/Dr, AcCode, Ac Name, It Desc, CrFine and DrFine at 0.000 (`TR_CONTRA.cs:1426-1446`), with Vch No (Enter, F1, Up,
Down), Vch Date, Item Type (Gold/Silver) and Employee in the header (`:1107-1372`, `:2329-2343`). Row 1 is DR and a new
row takes the other side (`:1530-1545`). A save pairs row 1 with every later row: the row is written first (LDR_TYPE
'0', its side, CR_FINE from the Cr column, DR_FINE from the Dr column, LD_CODE row 1, its description) and row 1 is
mirrored against it (LDR_TYPE '1', the opposite fine, row 1's description), with INOUT_TYPE, ENTRY_TYPE 'J', the
employee, the creator in MAIN_USER and DATA_TRFR, USER_UPDATE and USER_DELETE reset to 'N' (`:2760-2847`). Each CR_FINE
row posts one AC_DATA leg keyed `STR(SR_NO)+'03'` with `+` and each DR_FINE row one keyed `'04'` with `-`, 33 characters
in all (`Ac_Ledr.cs:846-848`); the day book copies each row's AC_NAME, description and the book's DATA_TYPE
(`Ac_Rojmel.cs:342-344`); TEMP_BOOK_DATA takes BOOK_DATA.BOOK_NAME (`TR_CONTRA.cs:2742-2753`, `:2307`); and REMARK_DATA
is deleted and rebuilt from the described rows with the AC_MAST name and MAIN_BOOK (`Ac_Tax.cs:686-694`, called at
`TR_CONTRA.cs:2890`). Save refuses, in desktop order and with the desktop texts, a missing employee when
`EMP_CODE_MANDATORY='Y'`, a new voucher when the company's CO_TYPE is 'B', a date outside the year, a date on or before
the lock date ("You Cant Save and Delete This Voucher Becouse Lock Date is = dd/MM/yyyy ....") and unequal Cr/Dr totals
(`:2666-2697`); an unknown new account or employee is refused before anything is written. Reopen groups the mirrors
and the counter rows by account, name, side and description as the desktop queries do (`:2467`, `:2541`), so equal
counter rows reopen as one row with their fines summed; an edit keeps the saved date, metal and employee when the
request omits them, and an unchanged account keeps its saved name even when its master row is gone (`:2502`, `:2550`). Delete checks the lock against the voucher's
date, audits every row with the first 149 characters of its description, then removes remarks, the hidden identity,
ledger, day book, source rows and APR_IDTL (`:2951-2968`). Print needs UserPrint (`:3000-3004`) and renders
FineJvBill for every saved row: 'Gold '/'Silver ' + BOOK_NAME, the copy label (ORIGINAL by default), the page number,
Vch Date and Vch No, Party Name / Cr Fine / Dr Fine (zero sides print 0.000) with the IT_DESC line suppressed when
blank, no total, and 'For : ' + CO_NAME, 'Party signature.' and 'signature.' (`:3021`, `:3061-3069`,
`web/apps/api/report-specs/FineJvBill.spec.json`).

Contra Entry opens only CONTRA books (`MDI_FORM.cs:8100-8111`), so `contra.ts` and `journal.ts` now refuse another
family's book on create, read, edit and delete, and the Contra and Journal documents need print rights like FineJvBill.
Without the guard `getContra` read the Fine JV voucher (the red run of `financeLifecycle.db.test.ts`). The Contra API now takes only the grid's
`lines`; the older two-account `fromAc`/`toAc`/`amount` input, which no screen sends, is removed (the depth gate counts
it as API input no screen can supply).

Deliberate differences: the desktop deletes REMARK_DATA without CO_YEAR (`TR_CONTRA.cs:2963`), which would also remove
another year's remarks for the same voucher number; the web deletes the voucher's own year only. The web has no RE_TRFR
column, so the re-transfer flag the desktop sets on an edited, already-transferred voucher (`:2806-2813`) is not stored.
The per-voucher USER_UPDATE / USER_DELETE override (`:2698`, `:2955`) and the employee default from EMP_AS_USER (`:2390`)
are not implemented. The extracted FineJvBill spec carries no numeric field formats, so fines print as 0.000. A grid whose
row 1 is paired with rows on both sides reopens row 1 with its net fine only, where the desktop shows both columns.
The generic voucher list routes still read any book of a shared table (G220, planned as N207).

Evidence: `fineJv.routes.db.test.ts` (9 cases; the first 7 red against the old writer, and the refusal-order,
grouped-reopen, print-layout and audit-length cases red against this slice's first draft) and the cross-family case in
`financeLifecycle.db.test.ts` (red before the guard) pass with `reopenVoucher.db.test.ts`, `routePolicy.test.ts`,
`contraDelete.db.test.ts`, `financeBookSelection.routes.db.test.ts` and `transactionBudget.routes.db.test.ts`; the full
workspace suite passes (api 338 files / 3614 tests, web 56 / 693, core 40 / 1791). The zero-mock `fine-jv` module passes
18 executable cases (entry, book family, 0.000, unequal totals, unknown account, out-of-year date, two-row write set,
three-row grid, reopen, unchanged save, edit, delete, tenant sentinel, print denied, Journal routes refusing the FINE JV
book, FineJvBill, Alt+S, Vch No Enter) with 5 blocked (version concurrency, idempotency retry, fault rollback, browser
settings matrix, L6 report filters) and 1 not applicable; the `contra` module adds a print-denied case and a FINE JV
book refusal. Chrome DevTools: a three-row voucher entered through the lookups, printed as Gold Fine JV with both
descriptions and the signature footer, reopened with Enter in Vch No, edited, and deleted with the desktop prompt;
Lighthouse on the reopened grid scores Accessibility, Best Practices, SEO and Agentic Browsing 100 with no failed audit.
Desktop-runtime comparison and parent acceptance remain open.
### N207 — The voucher list reads only books the user may open (G220)

`GET /vouchers/recent` and `GET /vouchers/neighbour` now read the requested book's BOOK_DATA.MAIN_BOOK and require read
rights on a form that owns it; an administrator passes and a book with no owning form is refused with 403. The owners
come from `web/apps/api/src/modules/vouchers/bookForms.ts`: the desktop's MENU_NAME per MAIN_BOOK (MS_UPDATE.cs)
resolved through the rights catalogue, the pages' BookSelect families, and the web-only books' screens.

Evidence: `web/apps/api/test/voucherListRights.db.test.ts` (red against main) shows every provisioned book family maps
to an existing form, and a Contra-only user lists CON but is refused FJV and an unknown book while an administrator may
list both; the whole feature suite still passes.

### N208 — Daily Rate is the desktop MS_RATE (G221, Lite L3)

The screen is the desktop Rate Master (`MDI_FORM.cs:8564-8573`): Vch Date with F1 (saved days with user, gold and
silver rate, `MS_RATE.cs:2370-2396`), Gold Rate 10gm, Silver Rate 1Kg and Employee, and a grid of the GROUP_MAST
groups with a touch in GR_TYPE then GR_NAME order (Sr., GrCode, GrName, Touch, Tax%, Rate10gm, TaxRate, PrTouch,
PrRate; `:1364-1414`, `:1752-1832`). Enter on Silver Rate 1Kg recomputes the gold and silver rows whose metal rate
changed (`:2314-2368`): TaxRate = Round(Touch × Gold / 100), the silver 1 kg rate / 10000, Rate10gm = Round(TaxRate /
(Tax% + 100) × 100, 0) when the group has a Tax%, and PrRate from the purchase touch, all with .NET banker's rounding
(`recalcDailyRateGrid` in `web/packages/core/src/dailyRate.ts`). A UAE company also shows the purchase and USD rates and
recomputes PrRate from a changed purchase rate (`:1705-1715`, `:2397-2458`). Save stores the grid as shown: the
company/location/year/date rows are replaced by one row per group with a touch and a Rate10gm, SR_NO the grid row,
with the header rates, GR_TYPE, the employee and the creator; location '00' also sets GROUP_MAST.GR_RATE
(`:1867-1947`). Changing a saved day needs edit rights (`:1882-1886`); delete needs delete rights and asks "Are You
Sure To Delete This Day Rate?" (`:2095-2109`); RateRpt needs print rights and prints 'Daily Rate Report dd/MM/yyyy'
with Group Name and Rate 10gm (`:1834-1866`, `web/apps/api/report-specs/RateRpt.spec.json`).

Not carried over: the per-location copy for one customer's registration (`:1937-1948`), the push of rates to an
external app database (AppSchemeTrfr, `:2048-2094`) and the MDI rate labels (the web keeps its RateTicker). The
sale and purchase rate lookup (`rate.ts`) still reads RATE_MAST without the location (TR_SALE.cs:12547 uses it).

Evidence: `web/packages/core/test/dailyRate.test.ts` (7 hand-worked vectors, banker's rounding included) and
`web/apps/api/test/dailyRate.routes.db.test.ts` (8 cases, all red against the old writer) pass; the zero-mock
`daily-rate` module passes 10 executable cases (grid order, Enter recalculation, negative refusal, saved rows,
F1 reopen, unchanged save, unpriced group skipped, delete, RateRpt, Alt+S) with 6 blocked and 2 not applicable.

### N209 — Item Opening is the desktop TR_ITM_OPBL metal-type grid (G222, Lite L2)

The screen is the desktop grid. The Item Type select lists Gold, Silver, Diamond, Real Stone, Emitation, Other and
Platinum after a blank entry (`TR_ITM_OPBL.cs:1227-1234`); Enter on it loads every item of that type in desktop order and focuses row 1
Rtype (`:1269-1370`). The 17 columns are Sr., ItCode, Item Name, Rtype, Pcs, GrWt, NetWt, Touch, West%, Fine, Rate,
ItmAmt, LType, LRate, LbrAmt, OthAmt and NetAmt, with a Total row (MSG_TOT_FILL `:995-1026`). Enter moves one cell right,
NetAmt goes to the next row's Pcs and on the last row adds a row at ItCode, and Enter on an empty ItCode goes to Save
(`:1538-1684`). Esc leaves when the gross and net totals are unchanged and otherwise goes to Save. Leaving a cell works
the row out as CommPassTotal does (`:942-993`), ported to `@datacare/core` as `itemOpeningRow`: a blank net takes the
gross, fine = net × (touch + wastage) / 100, amount is pcs × rate for rate type P with no fine, otherwise fine × rate
(a typed amount stays when either is zero), labour by LType (P pieces, K net / 1000, G gross, otherwise net) rounded as
VB rounds (half to even), and net amount = amount + labour + other.

Save refuses without the update right ("You Have No Rights.....", `:1061-1063`) or a type ("Please Select
Metaltype....", `:1407`), replaces the type's ITM_OPBL rows in book 000 with each cell as the grid holds it and
DATA_TRFR 'Y' (the column default, `MS_UPDATE.cs:21658`), writes the ITOBL MAIN_STOCK rows of `Itm_Opbl_Stk`
(SR_NO = grid row, ISR_NO 1, the opening date less one day, QTY = pieces, KR_COST = net amount) and DM_DATA rows for
items with OTH_DETL_POSTING 'Y', then clears the screen ("Data Are Saved."). Delete asks "Are You Sure To Delete All
Item Opening From This Record now?" and removes the type's ITM_OPBL, ITOBL stock and ITOBL DM_DATA rows ("Delete
Success.", `:1492-1517`). Print checks the print right (`:1371-1379`). The desktop Save writes no DM_WT, DM_RATE or
DM_AMT (`:1424-1446`), so the web-only diamond fields of the older numbered-voucher writer are removed.

Deliberate differences: the grid reads only this year's book 000 rows, where DISPLAY_DATA has no year or book filter
(`:1286`) and could show and save another year's opening into this one; the stock and DM deletes are limited to ITOBL
rows because book 000 also holds the TAGOP rows of Tag Opening; Save and Delete carry a version token (N51, D17) where
the desktop's later save wins; the web refuses a row with weight but no item code, an item of another metal type, and a
save or delete while the shown grid is not the chosen type; arrow keys keep a typed value, where the desktop drops it
because MSG_LeaveCell stores nothing while UpDown is set. The older numbered-voucher routes (POST /stock/item-opening,
GET|PUT|DELETE /stock/item-opening/:vchNo) stay for the IOP vouchers they wrote, but the screen no longer lists them.

Evidence: `itemOpening.test.ts` (core, 8 cases) and `itemOpening.db.test.ts` (8 cases: desktop grid order, book 000 with
ITOBL rows, DM_DATA only for OTH_DETL_POSTING items, an unchanged save keeps the stored cells, a cleared row is dropped
while other types and TAGOP rows stay, stock on hand rises and the delete removes it, a stale version is refused, the
desktop messages) pass with `stockLifecycle`, `tagOpeningStock`, `partyOpening`, `provisioning`, `seedCompleteness` and
`routePolicy`. The zero-mock `item-opening` module passes 17 of 18 cases (T14 fault rollback blocked: no fault injector),
including the rights refusal through a USER_SET row, two sessions, a replayed request, another year's rows and the item
stock ledger after a loose sale. Chrome DevTools on the demo stack: Gold loaded with Enter, 10.5 g at 91.6 + 2 gives
fine 9.828, 58968.00 at 6000, labour G 13 gives 136 and net 59204.00; Alt+S saved one ITM_OPBL row and one ITOBL row
dated 2026-03-31; the reopen showed every stored cell; Esc left an unchanged grid and went to Save after a change; Delete
removed both rows. The check found two keyboard defects, fixed here: Enter on the type loaded a blank grid when the
select's value changed without a React change event, and Esc from the type select left the screen. Desktop-runtime
comparison and parent acceptance remain open.

### N210 — Tag Cancel prints TagCanBill and refuses with the desktop texts (G223, Lite L3)

Save follows TR_TAG_CAN's order (`TR_TAG_CAN.cs:4959-4990`): a new voucher in a company whose CO_TYPE is 'B' is refused
with "You Cant Save This Voucher Becouse This Company Type is B......", a date outside the year with "You Cant Save Entry
Because Voucher Date Not In Current Year... Please Change Date..." and a date on or before the lock date with "You Cant
Save and Delete This Voucher Becouse Lock Date is = dd/MM/yyyy ....", before any line is read; delete uses the same lock
text (`:5338-5341`). The error names stay FiscalDateValidationError and PeriodLockValidationError. Print needs print
rights (`:5390-5393`) and renders TagCanBill (`:5386-5440`, `web/apps/api/report-specs/TagCanBill.spec.json`): the book
name, the copy label (ORIGINAL by default), the company block (LOCT_MAST's when REP_ADD_TYPE is 'L'), Vch Date and Vch
No, the party, the SNO / Item Name / Pcs. / Gr Wt. / Net Wt / Rate / Item Amt / Oth Amt / Net Amount columns with
TAG - item name per line and its stone rows, the Total row, Vch Desc, 'For : ' + CO_NAME and the two signatures. The
form shows Print for a loaded voucher.

Evidence: two new cases in `web/apps/api/test/tagCancel.routes.db.test.ts` (red against main) pass with the existing
Tag Cancel route, lifecycle, identity and row suites (114 tests); the new zero-mock `tag-cancel` module passes 12
executable cases (book, tag fill, duplicate tag, lock date, write set and stock out, Enter reopen, unchanged save, add
a tag, delete back to stock, print rights, TagCanBill, Alt+S) with 5 blocked and 2 not applicable.

### N211 — The Employee master is the desktop MS_EMP screen (G224, Lite L2)

The screen follows MS_EMP's form spec: the SEARCH RECORD box and the Code / Name list on the left, and Employee Code,
Employee Name, Account Code with the account name, User Name, Amount and Day Hour on the right in that tab order, then
Save, Print, Cancel, Delete and Exit (Print drawn first, Save first in the tab order). A new entry has the next code
('001' for a company without employees, else the highest code + 1 as "000", `MS_EMP.cs:1260-1268`), SEARCH RECORD and the
cursor in the name; the list is ordered by name (`:1144`) and by code right after a delete (`:1579`); the User Name list
is a blank entry and LOGIN_MAST's names of company '01' (`:1152-1177`). Enter or a double click on the list opens an
employee with its code read-only and Amount and Day Hour shown as 0.00 (`:1274-1299`, `:1600-1629`).

Keys as the desktop: typed letters are upper-cased and the apostrophe refused (`:1319-1332`); Enter on the code moves on
and F1 goes to the search box (`:1334-1348`); Enter on a blank name says "Please Insert Employee Name ..." (`:1381`);
Enter on the account takes a code found in AC_MAST whatever its group, else opens the help of groups 09, 10 and 45
without 00020 ordered by group and name (`:1631-1680`); Enter on Amount and Day Hour shows Val of the box as 0.00 and
moves on (`:1681-1724`); Up and Down go to the list and Esc leaves (`:1436-1446`); in the list F1 goes to the search box
and Backspace shortens it (`:1600-1622`). Leaving the code refuses a code another employee has and leaving the name a
name another code has, with the desktop texts (`:1350-1411`).

Save (`:1462-1550`) needs the edit right only for an opened employee ("You Have No Rights.....") and refuses a blank code
and name ("Enter Employee Detail"); it replaces the EMP_MAST row with the code, the name, the account, Conversion.Val of
Amount and Day Hour as typed (a port of VB Val, `@datacare/core` `vbVal`), the user or 'ABC' when blank, and MAIN_USER:
the operator for a new entry (CLEAR_DATA `:1253`), the creator for an opened one (`:1293`). Delete needs the delete right,
says "Please Select Employee For Delete." for a blank code, asks "Are You Sure To Delete This Record now?" and refuses the
default employee '001' after the question, as the desktop orders them (`:1552-1584`). Print needs the print right
(`:1585-1599`). The rights row is the desktop's: 'Employee' is added as the form's USER_SET alias (it had none, so a
desktop rights row did not apply).

Deliberate differences: Save also refuses a blank name, an account not in AC_MAST, a user that is not a company-01 login
and a name over the 40-character column; it keeps EMP_TYPE, TDS and PF, which the desktop's DELETE + INSERT resets
although only an import sets them (`UT_IMPORT.cs:9984`) and TR_EMP_JV reads them (`TR_EMP_JV.cs:1567`); the next code
skips a code that is not a number, where `ORDER BY EMP_CODE DESC` offers '001' again; an opened employee carries a
version token (N51, D17), so a save or delete after another operator's change or delete is refused with 409 where the
desktop's later save wins, and a new entry whose code another operator took meanwhile is refused with the code text
under the company lock; the search box drops SEARCH RECORD whenever it gets the cursor, where the desktop clears it only
on a click and then searched for "SEARCH RECORD…"; Up and Down stay in the User Name list and an open account help;
the account box keeps lower-case letters until a code is taken. Print shows the company's employees on screen in code
order (code, name, user, account, amount, day hours) because the EmpMast report is not in the repository. Not done here:
the help's create path (MsCreat opens MS_ACCT with group 10, `:1659-1665`), shared MS_HELP behaviour for the Party master
slice. The generic `/masters/employees` API stays for imports.

Evidence: core `vbVal.test.ts` (6 cases), `employeeMaster.test.ts` (3 cases: next code and the two texts) and
`employeeMaster.db.test.ts` (13 cases through the real routes on forced RLS: empty company '001' with the login names,
the write set with Val, 'ABC' and the operator, next code and both orders, every refusal with nothing written, the read
with the account name and a 404, an edit keeping creator, type, TDS and PF, a same-code new entry as the operator, the
clerk's desktop 'Employee' row (view and add only, 403 for edit, delete and print, 403 without a row), the account help,
the print order, stale-version, replay and missing-version refusals, a save after another operator's delete refused, the
'001' and blank-code refusals and another tenant untouched) and `routePolicy.test.ts` pass. The zero-mock
`employee-master` feature module passes 17 of 17 applicable cases (T05 not applicable), including a T14 fault injected
on the insert after the delete, which rolls back with every row id kept, the year switch to 2024-2025 and the Daily
Rate journey. Chrome DevTools on the demo stack: the keyboard entry upper-cased "o'neil desai", took SAL01 with Enter,
showed 12500.56 and 8.50 and saved through Enter on Save (EMP_MAST 01 | 001 | ONEIL DESAI | SAL01 | 12500.56 | 8.5 |
admin | admin); the list opened with Down and Enter, Alt+S saved the change, the question came before the '001' refusal,
Delete removed 002 with the list read again by code, F1 and the search filtered by name, and Esc left the screen. The
check found a defect, fixed here: upper-casing the account box as it was typed made the picker drop every answer to a
lower-case search, so the help never opened. Desktop-runtime comparison and parent acceptance remain open.

### N212 — Desktop rights rows reach the Lite screens by their menu captions (G225, Lite)

The desktop names a rights row by the menu button's caption: MDI_FORM sets MsUserRightForm = MsSideBtn and reads USER_SET
WHERE LC_CODE, USER_NAME and SUB_MENU = the caption (`MDI_FORM.cs:7034-7046`, `:7111-7116`, `:7264-7269`), and the form
reads FRM_EDIT, FRM_DELETE and FRM_PRINT of the same row (for example `TR_AC_OPBL.cs:2020-2030`). The web looks a row up
by the form's name and its aliases (`authorization.ts`), and fifteen Lite captions were not aliases of the forms their
screens use, so a migrated shop's restricted users were refused: Address, Product, Group, AutoItem, Tax, Party Opening,
Purchase Rtn, Approval Isu, Approval Rtn, Fine Jv Entry, Tag Stock, Sales Report, Purchase Rpt, Cash Bank and Gst Report.
The captions are now aliases of those forms (the dispatch case labels `:7610`, `:7620`, `:7630`, `:7640`, `:7670`,
`:7680`, `:7893`, `:8300`, `:8312`, `:8360`, `:8891`, `:8901`, `:8911`, `:8941`, `:8951`; RP_GST's Gstr 1, 2 and 3 views at
`RP_GST.cs:1340-1392`), and 'Party' also reaches the Party page's opening routes, which MS_ACCT shows itself.

Party Opening's Save now checks the edit right for an opening that exists, as TR_AC_OPBL does (`:2647-2650`, EntryMode E
set at `:2621`): a new opening needs only the view right, a change answers "You Have No Rights....." and writes nothing.
The screen shows the desktop text for a refused change or delete (`:2649`, `:2864`).

Not closed here, recorded on the gap: the captions whose screens also use another menu's form are left, because an alias
would grant that menu (Company → Provision Company, an administrator screen; Data Refresh → Data Repair; Data Import →
the Party master; Order Report → Sales Order; Cash Received and Bank Received → the Multi-Party Receipt routes the
receipt screen's multi-party mode posts to; Approval Rtn → the issue lines read under Tour / Approval Sale). The Basic
tier has 14 and the Standard tier 19 more menus whose captions do not reach their forms; they follow their tiers.

Evidence: `desktopRightsCaptions.db.test.ts` (28 cases) logs a view-only user in for each caption with the rights row the
desktop writes (SUB_MENU = the caption) and reads the screen's routes (200) and another menu's (403), checks that each
caption reaches its forms and no other menu's, and saves a new party opening, is refused the change and the delete, and
saves the change once FRM_EDIT is 'Y'. Against main's form catalog 27 of the 28 fail. `partyOpening.db.test.ts` passes.
The `party-opening` feature module's T11, blocked before, passes through a desktop 'Party Opening' row (new opening saved,
change and delete refused on screen with the desktop text, OP_DATA unchanged): 15 passed, 0 failed, 3 blocked. The full
API suite (343 files, 3665 tests), web unit tests and the smoke pass.

### N213 — The Tax master is the desktop MS_TAX screen (G226, Lite L2)

The screen follows MS_TAX's form spec: the SEARCH RECORD box and the Code / Name list on the left; Tax Type (the code),
Tax Desc, Tax % with Add Tax %, and Ac Code with the account name on the right, over the component grid Sr / Tax Type /
Tax Name / Ac Code / Tax %; Print, Save, Cancel, Delete and Exit along the bottom. The list is TAX_MAST's header rows
(SR_NO 0) ordered by code (`MS_TAX.cs:1608`); a new entry has blank boxes, one empty grid row and the cursor in the code
(CLEAR_DATA `:1590-1614`). Enter on the list opens a code with the cursor in the name and a double click with it in the
code; the code is read-only once opened, Tax % and Add Tax % show as 0.00 and the components' Tax % as 0.000
(`:1616-1668`, `:1973-2002`).

Keys as the desktop: typed letters are upper-cased and the apostrophe refused (`:1689-1702`); Enter on the code moves on
and F1 goes to the search box (`:1704-1718`); Enter on a blank name says "Please Insert Tax Name ..." (`:1751`); Enter on
Tax % and Add Tax % shows Val of the box as 0.00 (`:2004-2024`); Enter on Ac Code takes a code found in the account
master and goes to row 1 of the grid, else opens the help of group 12 and account 00013 by name (`:2026-2063`). In the
grid Enter moves one cell right; on Ac Code it takes a found code or opens the help of every account; on Tax % it shows
0.000 and goes to the next row, adds a row on the last one, and on a blank last Tax % goes to Save; the arrows move one
cell (TEXT_ENTRY_KeyDown `:1200-1310`). Esc leaves (`:1806-1814`). Leaving the code refuses a code another tax has and
leaving the name a name another code has, with the desktop texts (`:1720-1781`).

Save (`:1824-1933`) needs the edit right only for an opened code, refuses a blank code ("Enter Tax Code.") and name
("Enter Tax Name."), and replaces the code's rows: the header (SR_NO 0, TAX_GROUP 'N', Val of Tax % and Add Tax %, the
account) and one row per grid row whose Tax % is not zero (`:1886`), SR_NO = the grid row (`:1889`), with the row's type,
name, account, Val(Tax %) and the header's Add Tax %; MAIN_USER is not written. Delete (`:1935-1956`) needs the delete
right, refuses a blank code ("Please Select Tax Code For Delete."), asks the desktop question and removes every row of
the code. Print needs the print right. A sale reads the code by its header (SR_NO 0) and its components by SR_NO
(`web/apps/api/src/modules/shared/taxPolicy.ts`) and posts its tax to the header's account (Ac_Ledr Sales_Ledr).

The generic `/masters/taxes` routes now only read TAX_MAST (`MasterConfig.dedicatedWriter`): a generic update keyed by
CO_CODE + TAX_CODE wrote the header's name and rate into every component row, so SGST/CGST/IGST of an edited code all
became the header's rate. The desktop import does not import TAX_MAST.

Deliberate differences: Save runs in one transaction (the desktop deletes the rows first, so an insert that fails leaves
the code deleted); Val of a blank or text box is 0; an unknown account in the header or a component, a name over 40
characters and a component type over 5 are refused; an opened code's components are shown at their SR_NO rows with a
blank row in a gap, so a save keeps IGST at SR_NO 3 where the desktop packs and renumbers the rows; an opened code
carries a version token (N51, D17), so a save or delete after another operator's change is refused with 409 and a new
code another operator took meanwhile is refused with the code text; a pick from an account help moves on at once; Print
lists the rows on screen because the TaxMast report layout is not in the repository. The Input Tax account
(INPUT_TAX_AC) is shown only for one registration (SSRegSrNo VK195NEPH, `:1518-1527`) and is left out.

Shared fix found by the browser check: in `web/apps/web/components/LookupPicker.tsx` a pick moved the focus on at once, and the leave
that followed resolved the text the pick had replaced; typing 'GST' (an account code) and choosing 00085 from the help
therefore took GST. The picker now keeps the chosen row. The Sales Invoice party box had the same defect (typing 'BANK'
and choosing E2EBANK took BANK); a new `sales-invoice` case covers it and fails on the old picker.

Open, recorded on the gap: the web provisioning puts its tax accounts in group 30 (`seedCompany.ts`), so on a
web-provisioned company the desktop's group-12 help lists none of them (desktop-equivalent provisioning, N58); and the
Sales screen takes a Tax % and resolves the code by rate, where TR_SALE picks the code from the header rows
(`TR_SALE.cs:18668`), so a rate that another code's component also carries (1.5%: code 10's SGST and CGST) is refused as
ambiguous.

Evidence: `taxMaster.db.test.ts` (11 cases through the real routes on forced RLS: the list, the write set with Val,
upper-casing and no MAIN_USER, the sale resolver reading the new code, a 0% row skipped with SR_NO kept and the Add Tax %
on every row, every refusal with nothing written, the read with the account name, the edit with stale, replayed and
missing versions and a code deleted meanwhile, a view-only rights row, both helps, print and delete, another tenant
untouched, and the refused generic writes) and `routePolicy.test.ts` pass. The zero-mock `tax-master` module passes 18
of 18 cases, none blocked: a T14 fault injected on a component insert rolls the delete back with every row id kept, T15
reads the code in 2024-2025, T18 sells at the code's 2% rate (tax 1,272.19 = 63,609.50 × 2%, SGST = CGST = 636.095,
1,272.19 Cr to the header account). The `sales-invoice` module passes 28 cases with 3 blocked, `purchase-invoice` 25 with
2 blocked. Chrome DevTools on the demo stack: the keyboard entry of 15 GST 2% (code, name, 2.00, 0.00, 00085 picked from
the help after typing GST, three components with Enter adding rows and a blank last Tax % going to Save, Enter on Save)
stored `15|0|N|GST 2% ONLY|2|0|00085`, `15|1|SGST|1|00085`, `15|2|CGST|1|00086`, `15|3|IGST|2|00087` with no MAIN_USER;
the double click reopened it with every value; a Sales Invoice at 2% for WALKIN stored TAX_CODE 15, TAX_AMT 1272.19 and
posted Dr WALKIN 64,881.69, Cr SALES 63,609.50 and Cr 00085 1,272.19; Print listed the rows; Delete asked the desktop
question and removed the code; Esc left the screen. Desktop-runtime comparison and parent acceptance remain open.

### N214 — The Item Group master is the desktop MS_GROUP screen (G227, Lite L2)

The screen follows MS_GROUP's form spec: the SEARCH RECORD box and the Code / Name list on the left; Gr Code, Gr Name,
Item Type with the trade type box beside it, Gr Rate Touch with Purc Touch, Melting % with West %, Sales Ac and Purchase
Ac with their names, Hsn Code, Rate Tax % and Rate Display In Main Screen on the right; Print, Save, Cancel, Delete and
Exit along the bottom. The list is every GROUP_MAST row of the company ordered by code (CLEAR_DATA, `MS_GROUP.cs:1732`);
a new entry has blank boxes, Item Type Gold and the cursor in the code (`:1713-1736`); the Item Type combo is Gold,
Silver, Diamond, Real Stone, Emitation, Other and Platinum (`:1642-1648`). Enter on the list or a double click opens a
group with the cursor in the name, with the touches, melting, wastage and tax % shown as 0.00, each account with its name
and the code read-only (DISPLAY_DATA `:1738-1808`, `:2110-2139`).

Keys as the desktop: typed letters are upper-cased and the apostrophe refused (`:1975-1988`); Enter on the code moves on
and F1 goes to the search box (`:1990-2004`); Enter on a blank name says "Please Insert Group Name ..." (`:2091-2108`);
Enter on the item type moves on (`:2141-2149`); Enter on the trade type takes a BAL_GR code, else opens BAL_GR by name
(`:2271-2304`); Enter on the touches, melting and wastage shows Val of the box as 0.00 (`:2151-2193`); Enter on Sales Ac
takes a group-25 code, else opens the help of group 25 by name without 00099 (`:2195-2231`); Enter on Purchase Ac does
the same over group 30 (`:2233-2269`); Enter on Hsn Code moves on and on Rate Tax %, which is not formatted, goes to Save
(`:2318-2336`, tab index 12). Esc leaves (`:2073-2081`). Leaving the code refuses a code another group has and leaving
the name a name another code has, with the desktop texts (`:2006-2048`); a refusal also stops Save, Delete and Print, as
the desktop's cancelled Validating suppresses the button's click.

Save (`:1825-1919`) needs the edit right only for an opened group, refuses a blank sales or purchase account ("Please
Select Sales and Purchase Account And Try") and then a blank code or name ("Enter Group Detail"), writes the group with
Val of each number box, GR_TYPE = the item type's first letter and RATE_DISPLAY Y or N, keeps MAIN_USER for an opened
group and writes the user for a new one (`:1725`, `:1802`), and sets the trade type, item type and HSN code on every item
of the group (`:1887`). Delete (`:1921-1954`) needs the delete right, refuses a blank code ("Please Select Group For
Delete.") and a group an item uses ("You Cant Delete Record This Group Code Use in Item Master....") before it asks "Are
You Sure To Delete This Group now?". Print needs the print right. The sale credits each line to its item group's SALE_AC
(`web/apps/api/src/modules/sales/sales.ts`, G169) and the invoice prints the item's HSN code
(`web/apps/api/src/modules/sales/invoice.ts`), which the group's save sets.

Deliberate differences: Save updates the group's row in place, in one transaction with the item update. The desktop
deletes the row and inserts one from a blank DataRow (`:1862-1886`), which writes NULL into every column the form does not
show, among them the day's rate the Daily Rate screen keeps in GR_RATE (`web/apps/api/src/modules/masters/dailyRate.ts`)
and the average and day-close fields; and a failed item update leaves the new group row written. A second row of the
same code is removed, as the desktop's delete leaves one. An unknown account, a name over 40 characters and a trade type
over the 2 characters ITEM_MAST.TRAD_TYPE holds are refused (the desktop's item update fails on a longer one after the
group is written). An opened group carries a version token over the boxes it shows (N51, D17), so a Daily Rate save does
not make it stale, and a save or delete after another operator's change is refused with 409. A pick from a help moves on
at once and does not switch a new group to edit mode (the desktop sets EntryMode "E" after an account help, `:2222` and
`:2260`, so a user without the edit right cannot save that new group). Cancel and Exit work while a box is refused. Print
lists the groups on screen because the GroupMast report layout is not in the repository. The Add Touch box (ADD_TOUCH)
is shown only for one registration (SSRegSrNo VK289NEPH, `:1638-1641`) and the web schema has no such column, so it is
left out. The generic `/masters/groups` routes stay for the CSV import (UT_IMPORT also imports GROUP_MAST); the screen
no longer uses them.

Open, recorded on the gap: the web provisioning keeps CAPITAL A/C in group 25 and its GST and TCS accounts in group 30
(`web/apps/api/src/modules/ops/seedCompany.ts`), the desktop's sales and purchase groups, while its SALES and PURCHASE
accounts sit in groups 20 and 21; on a web-provisioned company the desktop's helps therefore list the wrong accounts and
refuse SALES typed into Sales Ac (desktop-equivalent provisioning, N58).

Evidence: `groupMaster.db.test.ts` (10 cases through the real routes on forced RLS: the write set with Val, upper-casing,
the type letter, Y/N and the user; the list with the rights and one group with its account names; an edit that keeps
GR_RATE, AVG_TOUCH and MAIN_USER while a Daily Rate write does not make the version stale, and sets the type, trade and
HSN on the group's two items only; every refusal in the desktop order with nothing written; stale, replayed and missing
versions and a group deleted meanwhile; a new entry with a group's code and name replacing it under the signed-in user
and collapsing a duplicate row; a view-only `Group` rights row; the three helps; print; delete with the blank and in-use
refusals; another tenant untouched) and `routePolicy.test.ts` (690 routes) pass. The zero-mock `group-master` module
passes 18 of 18 cases, none blocked: T05 checks the item update on the group's items only, T14 injects a fault on the item
update and finds the group and its item unchanged, T15 reads the group in 2024-2025, T18 sells an item of a new group and
finds 63,609.50 (10 g × 6,123.45 + 10 g × 237.50) credited to the group's sales account and the HSN code the group's save
gave the item on the invoice. Chrome DevTools on the demo stack: the keyboard entry of SLV SILVER ORNAMENT (code and name
upper-cased with the apostrophe dropped, SL taken from the trade type box with Enter, 70 → 70.00, 72.5x → 72.50, a blank
melting → 0.00, 1.5 → 1.50, SALES SILVER A/C chosen from the group-25 help after typing "silver", 00052 taken with Enter,
Rate Tax % 3 left unformatted and Enter going to Save, Rate Display ticked, Alt+S) stored
`SLV|SILVER ORNAMENT|S|SL|70|72.5|0|1.5|3|00042|00052|7114|Y|admin`; a typed 01 was refused on leave with the GOLD
JEWELLERY text; Enter and a double click reopened SLV with every value and the cursor in the name; an HSN change saved
with Enter on Save and the group's item took it; Delete of SLV, which that item uses, was refused without the question;
Print listed both groups; a temporary group was deleted after the desktop question; Esc left the screen.
Desktop-runtime comparison and parent acceptance remain open.

### N215 — The Product master is the desktop MS_PRODUCT screen (G228, Lite L2)

Master → Product opens MS_PRODUCT after setting MsUserRightForm to the menu caption (`MDI_FORM.cs:7111`,
`:7620-7628`); MS_PRODUCT_Load keeps it as CurMast, shows it as the title and, for 'Product', hides the scheme boxes
(`MS_PRODUCT.cs:1918-2150`). The screen follows the form spec in that mode: the SEARCH RECORD box and the Code / Name
list on the left; Code (two characters) and Name on the right; Print, Save, Cancel, Delete and Exit along the bottom. The
list is every PRODUCT_MAST row of the company by code (`:2142`); a new entry has blank boxes and the cursor in the code
(CLEAR_DATA `:2217-2264`); Enter on the list or a double click opens a product with the cursor in the name and the code
read-only (`:2266-2340`, `:2806-2949`).

Keys as the desktop: typed letters are upper-cased and the apostrophe refused (`:2361-2377`); Enter on the code moves on
and F1 goes to the search box (`:2379-2393`); Enter on a blank name says "Please Insert Product Name ...", else goes to
Save, the next tab stop (`:2434-2465`); Up and Down from a box move to the list and Esc leaves (MS_PRODUCT_KeyDown
`:2529-2560`). Leaving the code refuses a code another product has and leaving the name a name another code has, with
the desktop texts (`:2395-2504`); a refusal also stops Save and Delete. Save (`:2570-2665`) needs the edit right only for
an opened product, refuses a blank code ("Enter Product Code."), a blank name ("Enter Product Name.") and a one-character
code ("Please Insert Product Code 2 Digit..."), and replaces the code's row with CO_CODE, PR_CODE, PR_NAME, MAIN_USER =
the signed-in user (CLEAR_DATA sets MainUser at `:2230` and no product read sets it back) and DATA_TRFR 'N'. Delete
(`:2706-2804`) needs the delete right, refuses a blank code ("Please Select Product For Delete."), asks "Are You Sure To
Delete This Record now?" and only then refuses a product an item uses ("You Cant Delete Record This Product Use in Itme
Master....") and the default products DM, EM, FN, HM, OG, OR, OS, OT, RD and SN ("You Cant Delete Record, This Product
Is Default Product...."). Print does nothing: BtnPrint_Click is empty (`:1914-1917`). A saved product is offered by the
Item master's product help (`web/apps/api/src/modules/masters/lookup.ts`, entity products).

Deliberate differences: the delete and insert of a save run in one transaction (the desktop's failed insert leaves the
product deleted); a name over the box's 40 characters is refused; an opened product carries a version token (N51,
D17), so a save or delete after another operator's change is refused with 409. The generic `/masters/products` routes
stay for the CSV import; the screen no longer uses them. MS_PRODUCT's other modes (Counter on TABLE_MAST, Scheme Mast on
AD_MAST) belong to other menus and are not part of this slice.

Evidence: `productMaster.db.test.ts` (7 cases through the real routes on forced RLS: the write set upper-cased with the
user and N; the list with the rights and one product with its item count; every refusal in the desktop order with
nothing written; an edit writing the signed-in user, stale, replayed and missing versions and a product deleted
meanwhile; a new entry with a product's code and name replacing its row; a view-only `Product` rights row; delete with
the blank, item-use and default refusals and another tenant untouched) and `routePolicy.test.ts` pass. The zero-mock
`product-master` module passes 17 of 17 applicable cases (T05 not applicable: no child rows), none blocked: T10 checks
that the question comes before the item-use and default refusals and that No keeps the product, T14 injects a fault on
the insert and finds every row as before, T15 reads the product in 2024-2025, T16 checks that Print sends nothing, T18
finds the product in the Item master's help, blocked by an item and deleted once the item is gone. Chrome DevTools on
the demo stack: BR BRACELET keyed in (br and brace'let upper-cased with the apostrophe dropped, Enter on the name going
to Save, Enter there) stored `BR|BRACELET|admin|N`; Down from the code box moved to the list and Enter opened CH with
the cursor in the name; an edited name saved with Enter on Save as `CH|CHAIN 22K|admin|N`; Delete of RG (an item uses it)
and OG (a default product) asked the question and then refused with the desktop texts; Print did nothing; BR was deleted
after the question; a one-character code was refused with "Please Insert Product Code 2 Digit..."; Esc left the screen.
Desktop-runtime comparison and parent acceptance remain open.

### N216 — Cash/Bank and Contra refuse dates outside the year; the Contra list shows its total (G229, Lite L1)

Gap G229 · Parents P9 · L1 · High · Size M · Start after N193, N194

TR_CASH (`TR_CASH.cs:2934-2947`) and TR_CONTRA (`TR_CONTRA.cs:2680-2691`) check the voucher date against the open
year before the lock date and before any row is written, and refuse with "You Cant Save Entry Because Voucher Date Not
In Current Year... Please Change Date...". The Contra voucher list selects `SUM(CR_AMT)` and `SUM(DR_AMT)` per voucher
(`TR_CONTRA.cs:3140-3144`); one side is the amount transferred.

The receipt and payment writers (single and multi-line), the multi-party receipt and Contra now call
`assertFinanceVoucherDateTx` (`web/apps/api/src/modules/finance/lifecycle.ts`) inside their voucher transaction. A
create checks the year before it allocates the visible or hidden voucher number (`createFinanceIdentityTx`), so a
refusal takes no numbering lock. An edit checks the requested date before it reads and locks the saved voucher, so the
year text comes before the lock text, as on the desktop, and a refusal leaves the saved voucher untouched. Only the
ordinary out-of-range refusal is translated to the desktop text; a missing or ambiguous YEAR_MAST row still fails
closed with its own message. The recent-voucher list (`web/apps/api/src/modules/vouchers/list.ts`) shows the summed
`DR_AMT` of the scoped voucher for a table that has no amount column but has `DR_AMT`, and orders such a table's rows
by `SR_NO` so the listed row does not change between reads. Among the 17 listed tables this is CONTRA_DATA alone;
APR_DATA and BAR_DATA have neither column and still list 0.

Deliberate differences: none in behaviour. The web also checks the year on the server for the multi-party receipt
and the multi-line writers, which the desktop reaches through the same TR_CASH save.

Bounded G37 / N57 follow-up (2026-11-01), implemented-unverified: the generic report grid now applies an explicit date
descriptor only to `contra-register.date`, displaying the stored calendar date as `dd/MM/yyyy` through the shared
formatter. The zero-mock `contra.report.contra-register` baseline entry is removed; its existing T16 case still asserts
the date, both accounts and the amount. Desktop authority is the voucher-date mask `00/00/0000`
(`unified/src/csharp/DataCareNext/TR_CONTRA.cs:1092-1098`) and the Contra F1 projection using SQL Server style 103
(`TR_CONTRA.cs:3136-3162`). Broad N57 / G37 remains planned and open for typed descriptors across reports, Indian
number grouping, authoritative totals and identical screen/PDF/CSV/XLSX output; G81 also remains open. This bounded
change is not accepted or verified. The double-click cases prove one voucher per double-click only, not the durable
idempotency of N52 (D18).

Evidence: `finance.test.ts` proves an out-of-year create reads YEAR_MAST and takes no numbering lock.
`cashReceiptLegs.db.test.ts`, `batchReceiptLifecycle.db.test.ts` and `contraDelete.db.test.ts` refuse out-of-year
creates and edits through every writer with the desktop text and compare every row of the write set before and after;
two of them set a lock date and require the year text first, with an in-year locked edit as the control. Those two
order tests failed against the previous order with "period is locked" and pass now.
`voucherListScope.routes.db.test.ts` lists a balanced two-row Contra at 12,345.67, not 0 or 24,691.34. The full
isolated workspace suite passes (API 348 files / 3,719 tests, core 44 / 1,821, web 59 / 700); the zero-mock
`cash-bank` module passes 17 cases with 4 blocked, `contra` 22 with 2 blocked and the G37 register case baselined; the
real-stack suite passes with zero mocks. Chrome DevTools on a disposable stack: a Contra and a Receipt dated before the
year answered 400 with the desktop text and saved nothing; the Contra saved on the year's first day listed
`01/04/2026` and `12,345.67`. Desktop-runtime comparison and parent acceptance remain open.

### N217 — The Address master is the desktop MS_ADD_MAST screen (G230, Lite L2)

Master → Address opens MS_ADD_MAST directly (`MDI_FORM.cs:7610-7619`). The screen follows its form spec: the SEARCH
RECORD box and the Code / Name list on the left; Ac Code with its F1 button above the Company Detail, Other Detail and
Family Detl tabs on the right (Ac Name, Ac Group, Mobile No with Phone No, Con Person, Address1-3, City with Pin Code,
City Area, Country, State, District, Email, Birth Date with Anv Date and L Birth Date; Mobile No2 and Phone No2 on Other
Detail); Print, Save, Cancel, Delete and Exit along the bottom. The list is the location's ADD_MAST rows by code
(`MS_ADD_MAST.cs:3119-3396`); a new entry offers the next code of the location, read-only, with the cursor in the name
(CLEAR_DATA `:3454-3547`), and Ctrl+E unlocks the code box (`:3721-3738`). The combos list the company's distinct groups,
countries, districts, cities and areas and the states of ADD_MAST with STATE_MAST's, duplicates kept as the desktop's
UNION ALL keeps them (AddCboItem `:3939-4046`). Enter on the list or a double click opens an address with the cursor in
the name (`:3690-3719`); DISPLAY_DATA reads the code of the company whatever its location (`:3549-3583`).

Keys as the desktop: typed letters are upper-cased and the apostrophe refused (`:3604-3617`); F1 on the name and the F1
button open the help of the location's addresses by name with group, address, phone and mobile (`:3740-3775`); typing a
name refills the list with up to 99 of the company's addresses whose name starts with it (tAcName_KeyUp `:4171-4294`);
Enter on a blank name says "Please Insert Party Name ..."; Enter on the mobile of a new entry refuses a mobile another
address of the company has ("This Mobile No = <name>  With this Account .....", `:3867-3887`); Enter moves box to box and
on L Birth Date goes to Save (`:4296-4325`); the date boxes take the 00/00/0000 mask; Esc leaves. Leaving the name refuses
a name another code of the location has (`:4389-4409`); the refusal also stops Save, Delete and Print. Save
(`:4411-4515`) needs the edit right only for an opened address, refuses a blank code or name ("Please Select Customer
name and try...."), and replaces the code's row of the operator's location with every box upper-cased, a date box that
is not a date (IsDate) as NULL, MAIN_USER (the user for a new address, the stored one for an opened address) and
DATA_TRFR 'N'. Delete (`:4517-4544`) needs the delete right, refuses a blank code ("Please Select AcCode For Delete."),
asks "Are You Sure To Delete This Account now?" and deletes the address with its book-000 OP_DATA and AC_DATA rows of the
year. Print needs the print right and lists the location's addresses (PartyMast).

Deliberate differences: the next code is the location prefix and the next four-digit number; the desktop adds 1 to Val
of the whole last code, prefix included, and formats it after the prefix again (`:3505-3540`), so from the second address
of location 01 it offers 0110002 and then the same code again, and the save replaces the earlier address. The desktop's
code check (tAcCode_Validating `:3619-3639`) filters CO_CODE by the typed code and never refuses; the web refuses nothing
there either. Save and Delete run in one transaction; an opened address carries a version token (N51, D17); a box longer
than its MaxLength is refused; a stale name-search answer is dropped. Print lists the addresses on screen because the
PartyMast layout is not in the repository. The customer-detail box over the tabs (tCustDetl) and the hidden Excel
import button (btnAcImport, `:4628-4662`) are left out. The generic `/masters/addresses` routes stay for the CSV import;
their config still says the dates are kept on the account master, which MS_ADD_MAST contradicts (it writes BR_DATE,
AN_DATE and L_BR_DATE, `:4459-4461`).

Evidence: `addressMaster.db.test.ts` (8 cases through the real routes on forced RLS: the IsDate rule; the list with the
rights, combos and next code; the write set with every box upper-cased, 31/02/2020 stored as NULL and the user; one
address read with its dates, the company-wide name list and the mobile check; every refusal with nothing written; an edit
keeping the stored user with stale and missing versions; a view-only `Address` rights row; delete with its OP_DATA row,
the blank refusal, another location's address and another tenant untouched, and print) and `routePolicy.test.ts` pass.
The zero-mock `address-master` module passes 17 of 17 applicable cases (T05 not applicable: no child rows), none
blocked: T03 checks the IsDate rule on 29/02/2024 and 29/02/2023, T14 injects a fault on the insert and finds every row
as before, T15 lists the address in 2024-2025, T18 opens an address of location 02 from the name list and saves it as a
row of location 01 while location 02's row stays. Chrome DevTools on the demo stack: the keyboard entry of RAMESH SHAH
(apostrophe dropped, every box upper-cased, 31/02/2020 left as NULL, Enter on L Birth Date going to Save) stored
`01|010001|RAMESH SHAH|CUSTOMER|<mobile>|<phone>|SURESH|12 RING ROAD|NEAR MARKET|BLOCK B|SURAT|395002|ADAJAN|INDIA|GUJARAT|SURAT|RAMESH@EXAMPLE.COM|15/08/1990|NULL|1960-01-01|admin|N`
and offered 010002 next; Enter on that mobile in a new entry was refused with "This Mobile No = RAMESH SHAH
With this Account ....."; F1 on the name opened the help and Enter on it reopened the address with every value; Delete
asked the desktop question and removed it; Esc left the screen. Desktop-runtime comparison and parent acceptance remain
open.

### N218 — The Item master is the desktop MS_ITEM screen (G231, Lite L2)

Master → Item opens MS_ITEM directly (`MDI_FORM.cs:7650-7659`). The screen follows its form spec: the SEARCH RECORD box
and the Code / Name / Safe list on the left; Pr Code with the product name, Gr Code with the group name and trade type,
Item Code with the item and tag types, Item Name, Safe Name with Stk Display, Hsn Code, Unit Name, Rate Per, Labour Rate,
Labour % with Ght %, Conversion %, Discount %, Item Rate, Oth itm Rate with Oth Dtl Rate Type and Bag Weight on the right;
Print, Save, Cancel, Delete and Exit along the bottom. The list is every ITEM_MAST row of the company by name
(`MS_ITEM.cs:2776`); a search keeps the items whose name or code starts with the text (`:3118-3139`). A new entry has
blank boxes, Safe MAIN, Gram Wise, Yes and Weight with the cursor in the product (CLEAR_DATA `:2845-2877`); the units and
safes are the company's distinct values (AddCboItem `:3631-3673`). The Oth Item Wt Less In Wh Sal and Lot Wise Stock
boxes show when CO_SET_NEW.OTH_ITM_WT_REMOVE and ITM_WITH_LOT_STK are Y (`:2748-2768`, read at company open,
`MS_OPNCOMP.cs:1008-1011`).

The product and group boxes take their codes from the helps (read-only boxes, `:2135`, `:2139`): the product help lists
PRODUCT_MAST by name (`:3081-3116`), the group help GROUP_MAST by name with its type and trade type (`:3397-3450`). A
chosen group fills the item type, tag type and trade type and, on a new entry, the item code (product + group) and name
(product name + " " + group code); when that item code exists the desktop asks "This Item already Exist in '<name>'
Item Name...You Want to Creat New Item...", Yes clearing the code and name for a new code and No clearing the group
(`:3452-3495`). Leaving the item code refuses a code another item has under another name and leaving the name a name
another code has (`:3497-3629`); the refusals also stop Save and Delete. Enter moves box to box in the desktop order
(the product-dependent boxes only once a product is chosen); Enter on the number boxes shows Val as 0.00, the bag weight
as 0.0000, and on Bag Weight goes to Save (`:3559-3754`); Esc leaves (`:3141-3155`). Save (`:3165-3300`) needs the edit
right only for an opened item, refuses a blank product ("Product Code Is Null Please Create Item Again.."), group and item
code (the last with the cursor in the group, `:3223`), and writes Val of the number boxes, the first letter of Rate Per,
Stk Display and Oth Dtl Rate Type, and MAIN_USER (the user for a new item, the stored one for an opened item,
`:2857`, `:2990`). Delete (`:3302-3355`) needs the delete right and refuses an item with stock rows ("You Can't Delete
Record This Item Use in Transaction...."), a default code (SN, RD, OS, OG, OE, HM, FSL, DM, 24CT, 999, ORG, ORS, ORD, OO)
and a blank code before it asks. Print runs BtnPrint_Click_1 (`:3697-3705`, wired at `:990`), which only checks the print
right. A double click on the button bar opens the Item Wise Tag Value Update panel (`:3922-3934`): after its question the
item's tags at the location take each non-zero box where their value is zero (the karigar wastage only with a karigar
touch), outside the desktop's sold-tag subquery, and KR_FINE = KR_NET_WT × (KR_TOUCH + KR_WEST_PRC) / 100 is recomputed
for the year (`:3969-4015`).

Shared fix found by the browser check: `web/apps/web/lib/lookupEnter.ts` compared a lookup's answer with the box's text
exactly, so a master that upper-cases what is typed (the box shows RIN while the search went out for rin) dropped every
answer and the help kept the list fetched on focus. The comparison is now case-insensitive, as the searches are (ILIKE);
`item-master` T04 types in lower case and fails on main's file, and new `sales-invoice` and `purchase-invoice` cases take
a code typed in lower case.

Deliberate differences: Save updates the row in place in one transaction (the desktop's delete and blank insert,
`:3225-3263`, writes NULL into the minimum stock of the Item Stock Limit screen, the averages and the opening touch and
fine); an unknown product or group, a blank name (the desktop warns on leaving the name but saves it) and over-long boxes
are refused; an opened item's code is read-only (the desktop leaves it open, and a changed code saves a copy while the old
item stays); Enter on the list opens the item as the double click does (the desktop's Enter puts the item code into the
product box and reads the blank item code, which clears the entry, `:3366-3389`); a new entry unlocks the product box
(the desktop keeps it read-only once an item was opened); a pick from a help moves on at once; an opened item carries a
version token over the boxes it shows (N51, D17); the Tag Value Update needs the edit right (the desktop checks none);
the boxes the desktop reaches late in its tab order follow Bag Weight. The edition- and registration-specific boxes (Ac
Item, UniCode Name, Tax Free, Tag Oth Detail, Oth Detail Posting, App Item) are not shown in Lite; an opened item keeps
their stored values and a new item writes them blank or N. The web schema has no TAX_FREE_ITEM, APP_ITEM or
EMP_COM_PRC column. The Excel import (Ctrl+O, `:3856-3909`) belongs to Data Import.

Evidence: `itemMaster.db.test.ts` (8 cases through the real routes on forced RLS: the write set with Val, the combo
letters, the setting-driven flag and the user; the list with the rights, combos and settings, and one item; both helps;
every refusal in the desktop order with nothing written; an edit keeping MIN_STK, the averages and the stored user while a
moved average does not make the version stale, with stale and missing versions; a view-only `Item` rights row including
the tag update; the tag value update on four tags across locations and years; delete with the stock, default and blank
refusals and another tenant untouched) and `routePolicy.test.ts` pass. The zero-mock `item-master` module passes 18 of 18
cases, none blocked: T04 checks the lower-case help and both answers to the question, T05 the tag value update across
locations and items, T14 injects a fault on the item write and finds every row as before, T18 sells an item made on the
screen and finds 63,609.50 credited to its group's sales account and its HSN code on the invoice. Chrome DevTools on the
demo stack: RG RING chosen by typing "rin", G22 typed, giving RGG22 RING G22 with types G/G/GO, then 711319, gm, 10Gm Wise (chosen in its list),
350, 12.5, 0.75, a blank conversion, 2, 6123.45 and 150x keyed in with Enter, Pcs chosen in its list, 0.0125 shown as 0.0125 and Enter on
Save stored `RG|G22|RGG22|RING G22|G|G|GO|MAIN|711319|GM|1|Y|350.00|12.5000|0.7500|0.0000|2.0000|6123.45|150.00|P|0.013|admin|N`;
CHG22 reopened from the list with the product, group and code read-only, and Alt+S saved a new labour % with its MIN_STK
5 kept; Delete of CHG22 (with a stock row) was refused without the question; the tag panel set DT1 to 12/92/1.5 with
KR_FINE 9.350 and DT2's wastage to 1.5 with KR_FINE 4.655; RG with G22 again asked the desktop question, No cleared the
group and Yes cleared the code and name; a typed CHG22 was refused on leave; Print did nothing; RGG22 was deleted after
the question; Esc left the screen. Desktop-runtime comparison and parent acceptance remain open.

### N223 — The Ledger Report is the desktop RP_LEDR screen (G235, Lite L-report)

Report → Ledger Report opens RP_LEDR (`MDI_FORM.cs:8871-8880`). The desktop form is an account-summary screen first and a
drill-down second. The summary grid (DGV_AC, `AcSumm` `RP_LEDR.cs:6403-6435`) lists one row per account with a money
balance of Σ(CR_AMT−DR_AMT), a gold balance of the signed FINE_WT where IT_TYPE='G' (SIGN '+' adds, any other sign
subtracts) and the same for silver; a negative net shows as an absolute Dr column and a positive net as an absolute Cr
column (`:6408,6417,6426`). The nonzero mode drops a row whose displayed components are all zero; With Zero keeps it; the
opening-only mode balances before the company opening date (`:6415-6433`). Double-clicking an account drills into its
ledger detail (DGV_DETL, `DGV_DETL_FILL` `:6862-7266`): an opening balance strictly before the From date, the inclusive
period's rows netted per book/voucher/ledger-key then split into Dr/Cr, and a running Σ(Cr)−Σ(Dr) balance labelled
Cr (positive), Dr (negative) or blank (`:6989-7160`). The voucher-summary variant (DGV_VCH, `:7694-8205`) keeps gross
Dr/Cr and gross +/- fine per complete voucher. The time-wise view (DGV_MONTH, `TimeLedr_Dr` `:9514-10314`) ages each
account's debit into the buckets 0-15, 16-30, 31-45, 46-60, 61-90, 91-120, 121-150 and 151+, consuming the oldest debit
first with the account's total credit, for money and the selected fine independently. The desktop prints the summary and
the selected account and exports the active grid to Excel.

The web now serves all of this from one read-only resolver. `web/apps/api/src/modules/reports/accountLedgerReport.ts`
answers the four views (summary, detail, voucher-summary, ageing) with the desktop sign conventions and totals; the route
plugin `web/apps/api/src/routes/accountLedger.ts` exposes the canonical screen `GET /reports/account-ledger`
(view/acCode/from/to/dataType/withZero/fineType selectors) and its `export.pdf`, `export.xlsx` and `export.csv`, all from
the same dataset, keeping the two account-in-path aliases so the earlier screen and its PDF keep working. The dedicated
page `web/apps/web/app/(app)/reports/account-ledger/page.tsx` (with `useAccountLedger.ts` and `AccountLedgerGrid.tsx`)
offers the selectors, the account lookup, one primary Run action, the account summary and drill-down grids with their
totals, debit ageing, and Print/PDF/Excel/CSV, with Enter running and Esc leaving a drill-down back to the summary.

Deliberate differences: the balance sign is the desktop's Σ(CR−DR) (the old web statement used DR−CR); the zero test is
numeric at display precision, not a comparison of SQL FORMAT strings; the four views have stable tie-break ordering the
desktop lacks (account code for the summary; book, voucher and row for the drill-down); the youngest ageing bucket is
bounded by the as-of date and ageing is scoped to the requested location, fixing two desktop defects (future-dated rows
leaking into 0-15, and the OP_LDR presence test using a different location); the desktop's OP_LDR opening-ledger union and
its staging-table gold/silver fine PRINTS (which DELETE and repopulate a shared table) are not reproduced, because an
unscoped staging write is unsafe in a multi-tenant web app.

Evidence: `accountLedgerReport.test.ts` (pure vectors for the sign split, the running balance and the FIFO ageing from the
desktop-derived scenarios, and the query parser's refusals) and `accountLedgerReport.db.test.ts` (through the real routes
on forced RLS: the summary sign split and zero-row drop, With Zero, the voucher-summary gross netting with aggregated
remarks, the detail opening and running balance, the FIFO ageing, the PDF/Excel/CSV exports, the account-in-path alias,
the invalid-request and missing-account refusals, the view-vs-print rights, and a same-number sentinel in another tenant
untouched). `routePolicy.test.ts` carries the four new routes (720 → 724). The zero-mock `account-ledger` feature module
covers T01, T03-T06, T11, T15-T18, with T02 and the write groups T07-T10/T12-T14 marked not-applicable with reasons
(a read-only report). Desktop-runtime comparison and parent acceptance remain open.

### N219 — Auto Item is the desktop MS_AUTO_ITEM screen in its AutoItem mode (G232, Lite L2)

Master → AutoItem opens MS_AUTO_ITEM with the menu caption as its mode (`MDI_FORM.cs:7640-7649`); the Labour Disc,
Labour Update, Labour and Item Touch modes belong to other menus. The screen shows Group Code with the group name, type,
trade type and HSN code over the Sr. / Pr Code / Pr Name / MinStk / Y/N grid (MSG_CLEAR `MS_AUTO_ITEM.cs:1640-1683`), and
Print, Save, Cancel, Delete and Exit, with the cursor in the group code. The group comes from its help by name
(`tGrCode_KeyDown :3432-3493`), which fills the name, type, trade type and HSN code; DISPLAY_DATA (`:2614-2650`) then lists
the company's products but HM, DM, OG, OS, SN, FN, RD, EM and OT by code, Y (in red) for a product the group already has
an item of and N otherwise, and the cursor goes to row 1's Y/N.

Grid keys (`TEXT_ENTRY_KeyDown :3040-3239`, MSG_EnterCell and MSG_LeaveCell `:1712-1956`): typed letters are upper-cased;
Enter on Y/N needs Y or N ("Please Enter Y or N and Try Again...") and moves to the next row's Y/N, and on the last row
adds a row with the cursor in its Pr Code (CommPassAdd `:1957-1976`); Enter on a blank Pr Code goes to Save; Enter
elsewhere moves one cell right; MinStk keeps Val as a whole number; the arrows move a cell; F1 copies the cell above; Esc
in the grid goes to Save and elsewhere leaves the screen (`:2980-3007`).

Save (`:2876-2923`) needs the edit right once a group is shown (DISPLAY_DATA sets EntryMode "E", `:2648`, checked at
`:2668-2672`). For each Y row whose item the group lacks it writes PR_CODE + GR_CODE with IT_NAME = product name + " " +
group code, IT_TYPE and TAG_TYPE from the type box, TRAD_TYPE, SAFE_NAME MAIN, the HSN code, UNIT_NAME GMS, RATE_TYPE G,
MIN_STK, MAIN_USER (blank for a listed product, the user for an added row), STK_DISPLAY Y, DATA_TRFR N and the flags N;
existing items and N rows are left as they are; it answers "Data Are Saved." and clears the screen. Print and Delete only
check their rights in this mode (`:2652-2659`, `:2927-2944`).

Deliberate differences: one transaction under the item master's lock; a code another group's item already has and an
added product that is not in the product master are refused (the desktop would insert a duplicate code or an item of an
unknown product); Save with no group or no Y row writes nothing and answers "Data Are Saved." without a request (the
desktop would also make a group-less item from a Pr Code and Y typed into the blank row); the red marker colours the made
product's row (DISPLAY_DATA colours the grid's current cell, `:2632`, which is row 1, column 1); a typed group code fills
the HSN code too; the HSN box holds ten characters (its designer MaxLength is 1). The web schema has no TAX_FREE_ITEM or
EMP_COM_PRC column (`:2892-2912`).

Evidence: `autoItem.db.test.ts` (5 cases through the real routes on forced RLS: the grid without the default products
and with Y for the group's own, with the rights; the write set of the Y rows the group lacks; the refusals of a code
another group has, an added unknown product and an unknown group with nothing written; a blank group or no Y row writing
nothing; a view-only rights row) and `routePolicy.test.ts` pass. The zero-mock `auto-item` module passes 18 of 18 cases:
T04 checks the help by name and the red rows, T05 an added row made under the user, T12 two operators saving the same
item (one row), T13 a replayed save, T14 a fault on the second item rolling the first back, T15 the items in the historic
year, T17 every desktop key, T18 a made item offered by the items lookup. Chrome DevTools on the demo stack: G22 and Enter
showed GOLD 22K, G, GO, 7113 and the grid BG BANGLE N, CH CHAIN Y in red, RG RING N with the cursor on row 1's Y/N; X and
Enter said "Please Enter Y or N and Try Again..." and kept the cursor; Y and Enter moved down, Enter on the last row
added row 4 with the cursor in its Pr Code, and Enter on its blank Pr Code went to Save; Save stored
`BGG22|BANGLE G22|G|G|GO|BG|G22|MAIN|7113|GMS|G|0||Y|N|N|N|N` and left CHG22 as it was; reopening G22 showed BG and CH as Y
in red; F1 on row 3 copied the Y above and Save made RGG22; Esc in the grid went to Save and Esc in the group code left
the screen. Desktop-runtime comparison and parent acceptance remain open.

### N220 — Wh Sales refuses a save as TR_WH_SALE does and prints WhSalesBill (G233, Lite L1)

Gap G233 · Parents P1-core · L1 · High · Size M · Start after N219

Transaction → Wh Sales opens TR_WH_SALE on CurBookHelp('WH SALES') (`MDI_FORM.cs:8040-8051`); a web-provisioned
company has book WHS (`BOOK_SNAME` WSALE, `BOOK_TBL_NAME` RATE_CUT_DATA) with the twelve BOOK_DETL slots of the real
book 034. BtnSave_Click (`TR_WH_SALE.cs:12779-12896`) refuses, before it writes and with its own texts: a defaulter
party (AC_MAST.DEFAULTER_AC 'Y') when the sale-side Os Amt plus the fine still due is above zero ("You Cant Save
Entry Because This Party Is in Defaulter List..."); a blank employee when CO_SET.EMP_CODE_MANDATORY is 'Y'; a new
voucher in a company whose CO_TYPE is 'B'; a cheque or a card amount in either column without its bank account; a
date outside the open year; a date on or before the lock date ("You Cant Save and Delete This Voucher Becouse Lock
Date is = dd/MM/yyyy ...."); and, per row, a row with GrWt, LbrAmt, NetAmt or Mrp but no item code ("Please Select
Item Code In Row N and Try......"). TR_TOUR_SALE carries the same block (`TR_TOUR_SALE.cs:10585-10690`).

`web/apps/api/src/modules/sales/wholesaleSaveChecks.ts` holds these checks. `writeRateCut` runs the ones that need no
figures after the book-family guard and before the edit reversal or any tag is reserved, and the defaulter, cheque
and card checks after the band is computed and before any row is written, all inside its transaction, for the
TR_WH_SALE engine (Wh Sales, Rate Cut, Wh Quotation, Tour Sales; Bullion Sale keeps its own rules). A refusal leaves
no row, no voucher or hidden number, and the tags in stock. Delete asks "Are You Sure To Delete This Voucher now?"
(`:13567`). Print (`:13654-13800`) needs the print right and renders WhSalesBill
(`web/apps/api/report-specs/WhSalesBill.spec.json`): the party block, Vch Date and Vch No, the issue and receive
rows, the Purchase / Sales band (fine, rate cut, bill total, cash, card, cheque, kasar, bill outstanding) from the
stored header, Vch Desc, and the party's opening and closing money, gold and silver (its ledger without and with this
voucher's legs), through `GET /wholesale-sales/:vchNo/print`.

Deliberate differences: the defaulter check runs after the figure-free checks (the desktop runs it first) because it
reads the computed band; the order of all other checks is the desktop's. The licence-expiry check and the two
registration-specific checks (HM176NEKU, HM037NEKU) do not apply. `releaseRateCutTagsTx` moved to
`web/apps/api/src/modules/sales/rateCutTags.ts`, unchanged, so `rateCut.ts` stays under its size ceiling.

Evidence: `wholesaleSaveChecks.db.test.ts` (9 cases over HTTP on a provisioned company: every refusal with its text
and an unchanged footprint of RATE_CUT_DATA/ISU/REC, MAIN_STOCK, AC_DATA, ROJ_MEL_DATA and TEMP_BOOK_DATA, the
paid-in-full defaulter control, the year before the lock date, and the print with opening 0.00 Dr and closing 9,500.00
Dr) and the existing TR_WH_SALE-family tests (12 files, 153 tests) pass; `rateCutSettlement.db.test.ts` now seeds its
fiscal year. The new zero-mock `wholesale-sale` module passes 25 of 25 cases over T01-T18, none blocked: T03 checks
Math.Round(0.125 × 6500) = 812 (banker's) and a 237.50/g net-wise tag labour of 2,375; T05 two tags and 5.000 fine
received; T08 an unchanged save leaves every row the same; T09 a dropped tag returns to stock; T12 a second delete is
refused; T14 a fault on the issue row rolls everything back; T18 a 9,500 outstanding is cleared by a Cash Received.
Against the code before this change, all eight refusal cases saved the voucher and the lock date answered "period is
locked …". The full workspace suite and the real-stack suite pass. Desktop-runtime comparison and parent acceptance
remain open.
### N221 — Stock Adjust is the desktop TR_TAG_CAN on a STOCK ADJUST book (G234, Lite L3)

Other → Stock Adjust opens TR_TAG_CAN after CurBookHelp("STOCK ADJUST") (`MDI_FORM.cs:8616-8627`), the form Tag Cancel and
Tag Transfer use. Its grid (MSG_CLEAR `TR_TAG_CAN.cs:2514-2566`) is the Tag Cancel grid without LbrRate, LbrAmt and OthAmt,
with Sign after Size, and TagLot and ItmLot after TagNo only when CO_SET_NEW.PURC_LOT and ITM_WITH_LOT_STK are Y. The web now
runs it as the Tag Cancel writer's third mode (`web/apps/api/src/modules/stock/tagCancel.ts`,
`web/apps/api/src/modules/stock/tagCancelRows.ts`) behind its own form right, and the page is the shared form in that
mode (`web/apps/web/components/TagCancelForm.tsx`). The provisioned book is the desktop's: short name STADJ, an out book
(`MS_UPDATE.cs:24207`, `:25049`), numbered from BAR_CAN_DATA and BAR_CAN_DETL (`:7825`); a data migration moves the SAJ
books the web provisioned before.

Keys: Enter on a blank TagNo moves on (`:3866`), so a line may be a loose item from the ItCode help; a tag fills its line
from BAR_DETL as in Tag Cancel; Enter on Sign needs + or - ("Please Insert Item Sign + or - then Try", `:4259-4263`); a new
row starts with the sign of the row above (CommPassAdd `:2835-2838`). The TagLot help lists the location's LOT_DETL lots
with a signed balance and the ItmLot help its loose MAIN_STOCK lots (`:4089-4188`); a choice fills the item, the pieces
(when the lot has gross weight), the gross and net weight and the less weight between them, and a blank lot is allowed.

Save writes the register with each line's sign (`:5138-5145`); Tag_Can_Stk posts one MAIN_STOCK row per line, TR_TYPE I
for + and O for - (`Ac_Stock.cs:53`); StkAdj_Lot posts a LOT_DETL row for a line with a TagLot (`Ac_Stock.cs:642-646`); no
DM_DATA is written (Dm_Tag_Cancel_Detl is for TAG CANCEL books, `Ac_Stock.cs:824-828`). A - tag line takes the instance
out of stock as a Tag Cancel line does; a + tag line adds a stock row without taking it out, and its delete gives nothing
back. Delete asks "Are You Sure To Delete This Voucher now?" and removes the write set with one DELETE_DATA row per line;
Print prints TagCanBill (`:5386-5440`), where a loose line reads "N - item name", as the desktop formula
`if {BAR_CAN_DETL.TAG_NO} <> ''` gives for the stored N.

Extra code found and removed: the web's Stock Adjust was a separate writer (`stockAdjust` and `deleteStockAdjust` in
`web/apps/api/src/modules/stock/stock.ts`, routes POST /stock/adjust and DELETE /stock/adjust/:vchNo) that cited a desktop
form TR_STK_ADJ, which does not exist, and posted MAIN_STOCK rows with VCH_TYPE STADJ, BOOK_NAME STOCK ADJ and TR_TYPE A
and no register, so a voucher could not be reopened, edited or printed. Its two rounding helpers leave the kernel
baseline with it.

Deliberate differences: one transaction under the tag locks; a TagLot or ItmLot sent while its setting is off is refused; a
replayed save of a loose line makes a second voucher (no idempotency key yet; a replayed tag line is refused because the
tag is already out).

Evidence: `stockAdjust.routes.db.test.ts` (6 cases through the real routes on forced RLS: the provisioned STADJ book; the
menu's own right and another menu's book refused; the sign refusals, the Sign refused on the Tag Cancel menu and a hidden
TagLot refused, with nothing written; the lifecycle with the signed register, I and O stock rows, the LOT_DETL row,
reopen, edit, print with rights, delete and another tenant untouched; a + tag line; both lot helps with their balances),
the tagCancelRows and tagCancelVoucher unit tests, and `routePolicy.test.ts` (719 routes) pass. The zero-mock
`stock-adjust` module passes 18 of 18 cases, none blocked: T12 two operators adjusting one tag out (one voucher), T13 a
replayed tag save refused, T14 a fault on the stock write rolling the voucher back, T15 Purchase LOT showing TagLot, its
help filling the line and the save posting the - LOT_DETL row, T17 the Enter walk with the Sign refusal and Alt+S, T18 a
tag adjusted out leaving the available-tags lookup sales use and coming back after the delete; `tag-cancel` T01 now
checks that its grid keeps the labour columns and shows none of Stock Adjust's. Chrome DevTools on the demo stack: the
grid showed Sr, TagNo, ItCode, Counter, Design, Size, Sign, BagWt, Pcs, GrWt, LsWt, NetWt, Ght%, GhtWt, Touch, West%,
Fine, Mrp, KrCode with Save the only main button; Enter on the blank TagNo went to ItCode; GOLD from its help moved to
Counter; X and Enter in Sign said "Please Insert Item Sign + or - then Try" and kept the cursor, + moved on to BagWt;
5.5, 0.5 and 91.6 gave NetWt 5.000 and Fine 4.580; tag DT9001 filled line 2 (12.500, 12.000, 10.992) with the sign +
copied from line 1, changed to -; Alt+S saved voucher 00001 with `1|N|GOLD|+|5.500|0.500|5.000|91.600|4.580|STADJ|O` and
`2|DT9001|GOLD|-|12.500|0.000|12.000|91.600|10.992|STADJ|O` and the stock rows I/+ and O/-, the tag balance 0; Vch No
00001 and Enter reopened both lines; TagCanBill showed both lines and the totals 18.000 / 17.000; Delete asked the desktop
question, removed every row and wrote a DELETE_DATA row per line, and the tag balance went back to 1. Desktop-runtime
comparison and parent acceptance remain open.

### N222 — Sales Order UPI tender rows (G206, part)

Gap G206 · Parents P9; R03 · L1 · Med · Size M · Start after N221

TR_SALE_ORD takes UPI in its own grid, MSG_UPI (Sr., AcCode, Upi Bank Name, UpiType, Upi Id, UpiAmt). The account
comes from the account master, whose name fills Upi Bank Name (TEXT_UPI_KeyDown, `TR_SALE_ORD.cs:3814-3879`). UPI
Amt is the total of the rows with an account and a non-zero amount (TotAmt, `:3698-3711`), and the advance ADV_AMT
adds it to the other tenders (`:11368`). The save rewrites UPI_DATA with one row per such row, SR_NO its grid line
(`:9520-9556`). Order_Ledr posts each row as leg 12 (party credit, LDR_NAME 'UPI - ' and the party name) and leg 13
(UPI account debit), keyed with STR(SR_NO) after the leg type (`Ac_Ledr.cs:55-57`); Order_Rojmel adds type 08 per row
(`Ac_Rojmel.cs:25`), and its type 01 credits the whole advance. On a new order an Upi Id already in UPI_DATA for the
company and location is refused: "This UpiId already Exist In Book No =  <book> AND VchNo = <no> Please Change Upi
Id ..." (`:3913-3925`). The web showed UPI Amt read-only, stored it without rows or legs and left it out of ADV_AMT,
and refused to edit an order that had UPI rows.

The order screen now has the UPI grid in its Order details (`web/apps/web/components/SalesOrderUpiGrid.tsx`), and UPI
Amt shows the grid total. `web/apps/api/src/modules/sales/salesOrderTender.ts` keeps the rows with an account and an
amount, checks the account in AC_MAST and takes its name, refuses a used Upi Id on a new order, and builds the
UPI_DATA rows, legs 12/13 and Rojmel type 08. ADV_AMT includes UPI. An order with UPI rows can be edited and deleted;
an edit that omits the rows is refused rather than deleting them. A bare UPI amount without rows is refused on a Sales
Order. The Tour Order keeps its previous behaviour, and its UPI rows still block an edit.

Deliberate differences: the desktop checks the Upi Id as it is typed; the web checks the rows it saves. UPI_DATA's
ISR_NO, a web split key added for TR_MEMB_ENT, is 1. An unknown account is refused with a web message, where the
desktop opens its account help. Old gold, old silver (SL_PR_DETL, legs 07-10, Rojmel 04/06) and the scheme amount stay
open under G206, as the baselined case `sales-order.create.old-metal-and-scheme-tenders`.

Evidence: `salesOrderRound4.db.test.ts` (UPI_DATA rows with their grid lines 1 and 4, legs 12/13 with 33-character
keys and the party-name label, Rojmel 01 for the whole advance and 08 per row, the reopened rows, the used-id refusal
with its text and no write, the unknown-account and bare-amount refusals, the edit that omits the rows, an amount
edit, and the delete) passes, and fails against the code before this change. The order-related API tests (22 files,
272 tests) pass. In the zero-mock `sales-order` module the new cases `create.upi-tender`,
`edit.upi-amount-then-delete` and `refusal.duplicate-upi-id` pass (they failed before: the screen had no UPI grid);
the module passes 27 of 30 with the old-metal case baselined and two cases blocked as before. Desktop-runtime
comparison and parent acceptance remain open.

### N224 — Party is the desktop MS_ACCT screen (G236, Lite L2)

Gap G236 · Parents P1-core · L2 · High · Size L · Start after N223

Master → Party opens MS_ACCT directly (`MDI_FORM.cs:7600-7609`). `web/apps/api/src/modules/masters/partyMaster.ts`
and `web/apps/api/src/routes/partyMaster.ts` (registered through `web/apps/api/src/routes/masterScreens.ts`) carry
it, and `web/apps/web/app/(app)/masters/party/page.tsx` is the screen. The list is MS_ACCT_Load's (`:5944-5958`): with
BRANCH_ALL_AC_SHOW every account of the company by location and code, at a location other than 00 the company's codes
below 100 and the location's codes from 200 by code, at location 00 the location's accounts by their first two
characters, length and code. CLEAR_DATA (`:6134-6355`) offers the next code read-only with the cursor in the name,
type A, GST Local, the company's state, Cr openings and today's Last Visit; the next code follows VB_IMPORT,
AC_LC_CODE_LEN (blank is 1) and the company type (the 80000 series for P and B). DISPLAY_DATA (`:6356-6587`) fills
every box, the group's name and the reference's name, and the year's opening (book 000), read-only.

The form upper-cases every key and drops the apostrophe (`:6606-6619`); the email is lower case (`:5050`). Enter
moves in the form's tab order: a blank name says "Please Insert Party Name ..."; the group code fills its name and
main group or opens the AC_GROUP help (`:7030-7069`); the mobile, second mobile and short name refuse a value another
account has, with the desktop's texts (`:6893-6956`, `:7230-7278`); the GST number's first two digits give the state
and the GST type against CO_MAST.CO_STATE_CODE (`:6978-7018`); the main account and the reference open the account
help when the code is unknown (`:7481-7528`, `:9542-9598`); the opening and percentage boxes are formatted
(`:7573`, `:8071-8160`, `:9059`); Silver's Cr/Dr goes to Mobile No2 on Other Detail and Khata No to Save. F1 on the
name, the F1 button and F1 on the short name (administrator) open their helps, the D, S and A buttons copy an address,
a scheme member or another account (`:8501-8574`, `:9024-9058`); Ctrl+E unlocks the code; Esc leaves. The photo
(AC_IMAGE) is picked or taken, saved at once, zoomed on a double click and deleted after "Are You Sure To Delete This
Image now?" (`:8162-8466`).

Save (`:7650-7962`) needs the edit right for an opened party and refuses, with the desktop's texts, a blank mobile
with BRANCH_ALL_AC_SHOW, a five-character (software default) code without Ctrl+E or away from location 00, a blank
code, name or group ("Enter Party Name and Account group Detail") and a name another listed code has; a new entry
whose code exists takes the next code. It replaces the code's AC_MAST row of the location with every box (AC_TYPE's
first letter, AC_GST_TYPE I or L, Val() of the numbers, Y/N flags, a date box that is not a date as NULL, MAIN_USER,
DATA_TRFR 'N', VISIT_TRAN 'AC'), writes a new entry's opening as OP_DATA book 000, voucher 00000, DATA_TRFR 'Y' with
the AcOp_Ledr legs (`web/apps/api/src/modules/finance/partyOpening.ts`), and replaces the AC_MAST_SRNO row. Delete
(`:7963-8025`) needs the delete right and refuses a blank code, a code used outside the opening voucher ("You Can't
Delete Record This Party Code Use in Transection....") and a software default account, before the question; Yes
deletes the AC_MAST_SRNO, AC_MAST, OP_DATA and AC_DATA (book 000 of the year) rows. Print needs the print right.
Migration `20261102090000_ac_mast_party_columns` adds the five AC_MAST columns of the desktop's updater
(`Ac_Image.cs:8094`, `:8318`, `:8405`, `:8439`).

Deliberate differences: Save writes AC_MAST, the opening and AC_MAST_SRNO in one transaction (the desktop commits
AC_MAST first and writes the rest after it); an opened party carries a version token; a new entry never replaces an
account (the desktop would delete and rewrite one when the next code is taken too); the next code also counts AC_MAST's
codes, as migrated companies have no AC_MAST_SRNO rows, and the two-character prefix and the 80000 series add 1 to the
last five digits (the desktop adds 1 to the whole code, so location 01's second party would get 01100202 and the third
the same code again); a code that is not a number (the web's seeded accounts) is listed with its location (the
desktop's CAST fails on it); the opening boxes of an opened party are read-only (Party Opening edits them) and show the
year's opening; Delete refuses a software default account (the desktop shows the text and then still deletes after the
question); a code of another location answers "This Ac Code Is Branch With : <lc> You Cant Change..." without
BRANCH_ALL_AC_SHOW too; Print lists the accounts on screen because the AcMast report layout is not in the repository.
The hidden admin panel, the defaulter box and the three limits (Advance and Enterprise software types, `:5964-5973`),
the UAE boxes and the hidden Excel and old-year import buttons are left out; Family Detl is empty as on the desktop.

Evidence: `partyMaster.test.ts` (7 cases: every next-code branch, the date boxes, the list filters, the message
texts) and `partyMaster.db.test.ts` (10 cases over HTTP on a forced-RLS database: the list and next code, the full
write set with OP_DATA, the legs and AC_MAST_SRNO, the read-back, every refusal with an unchanged footprint, the
taken-code path, the edit's MAIN_USER and version, the Enter checks and helps, the clerk's rights, the photo, and the
delete with its refusals and dry run) pass; the full API suite passes (353 files, 3,757 tests). The new zero-mock
`party-master` module passes 18 of 18 cases over T01-T18, none blocked: T05 an opening of 1,000 Dr, 1.5 gold Cr and
2 silver Dr writes the legs 02, 03 and 06; T06 every refusal with its text and no row changed; T14 a fault on the
AC_MAST insert or on the opening leaves every row as it was; T15 the historic year lists the party without this
year's opening; T17 Enter through both tabs and the opening, Ctrl+E, Alt+S and Esc; T18 the D help copies an address
and Party Opening reads the opening saved here. A Chrome DevTools pass on the demo stack keyed a party through every
box (the GST number 27… gave MAHARASHTRA and Inter state), saved 100203 with OP_DATA 1500.5 C / 2 C, legs 01 and 03
dated 2026-03-31 and its AC_MAST_SRNO row, reopened it with the opening read-only, picked, zoomed and deleted a photo,
refused SALES' save and delete with the desktop texts, copied PATEL TRADERS with the A help, printed the list and
deleted 100203 with all its rows. Desktop-runtime comparison and parent acceptance remain.
### N225 — Tag Print is the desktop UT_TAG_PRINT screen (G237, Lite L3)

Gap G237 · Parents P1-core · L3 · High · Size L · Start after N224

Other → Tag Print opens UT_TAG_PRINT directly (`MDI_FORM.cs:8596-8605`). `web/apps/api/src/modules/stock/tagPrintScreen.ts` and
`web/apps/api/src/routes/tagPrintScreen.ts` carry it, and `web/apps/web/app/(app)/txn/tag-print/page.tsx` is the screen.
Load (`:4735-5013`) lists the label files of PRINT_MAST (type TAG, QR with QR_CODE_GEN), selects the one marked PRINT_SET_A 'Y' and
the item type Gold, or Silver for CO_MAST.METAL_TYPE S. The grid is filled from a voucher (Book and Vch No; a book of the Tag Cancel
family reads BAR_CAN_DETL joined to BAR_DETL, `:5284-5403`) or from the stock (Gr Code, Pr Code and Item Type, MSG_VCH_FILL
`:5575-5635`), every row Y; a tag typed in the TagNo column is looked up in the stock, the latest instance first, "Duplicate Tag No"
when it is already in the grid, the tag help when it is unknown (`:3508`, `:4102-4420`); Y/N toggles a row and Ctrl+D removes one
after "This Row Record will Removed permantley ?" (`:3532-3561`). Print (`:5122-5226`) needs the print right ("You Have No Print
Rights....."), clears TAG_PRINT_DATA, writes the Lable Skip blanks (Math.Round, banker's: SR_NO 1..n, VCH_NO 00000, IT_CODE '00') and
copies the BAR_DETL row of every Y row; with Hm Id Update it first says "Please First Update Hmid Data and Then print". Save
(`:5073-5096`) writes HM_ID..HM_ID4 with their weights, LBR_PRC, ITM_MRP and LBR_RATE to BAR_DETL for rows with a tag and an HM id
or a Lbr% / Mrp, then prints. Set (`:5636-5655`) makes the chosen file the default of its type.

Deliberate differences: the label sheet is the web's (the Crystal label files are not in the repository); a blank Gr Code goes on and a
blank Pr Code loads the stock (the desktop opens the help); F1 on Vch No keeps the Book (the desktop's CLEAR_DATA clears it); the
typed cells of ItCode, Counter and GrWt are not editable because a label is copied from BAR_DETL; Delete does nothing (the desktop's
BtnDelete_Click is empty); Save outside Hm Id Update says so; Hm Id Update and Set need the edit right; TAG_PRINT_DATA is cleared for the
tenant and IMAGE_DATA is not cleared (the desktop's unqualified DELETE FROM IMAGE_DATA also removes scheme member pictures); the stock rule is
the tag balance over MAIN_STOCK of every year; the RFID writer, the Print Type box and the QR picture (named registrations only) are left
out. The older `GET /stock/tag-print`, `POST /stock/tag-print/stage` and `GET /stock/tag-print/label` routes had no other caller and are
removed; `stageTagPrintRowsTx` stays for the other forms that stage labels.

Evidence: `tagPrintScreen.db.test.ts` (9 cases over HTTP on a forced-RLS database: the load, the stock lists with filters, the typed tag and
helps, a voucher and a Tag Cancel voucher, Print with the skip rows and banker's rounding, the tenant-only staging, Hm Id Update, Set and
the clerk's rights) and the existing staging tests pass. The new zero-mock `tag-print` module passes 17 of 17 applicable cases over T01-T18
(T10 is not applicable: Tag Print has no delete), none blocked: T02 the three staged rows equal their BAR_DETL rows; T07 BAR_DETL (hashed),
MAIN_STOCK, AC_DATA and BAR_DATA do not change; T14 a fault on the third copied label leaves the earlier labels; T16 the sheet shows two blanks
for 2.5, then three labels with barcodes and the MRP; T18 an HM id keyed here reaches the next plain print's label. Desktop-runtime comparison,
physical-printer acceptance (D29) and parent acceptance remain.
### N226 — Sales Order old gold and old silver rows (G206, part)

Gap G206 · Parents P9; R03 · L1 · Med · Size L · Start after N225

TR_SALE_ORD takes old metal in its own grid, MSG_OLD (Sr, ItCode, ItName, Pcs, GrWt, OthWt, NetWt, Touch, Fine, RTyp,
Rate, NetAmt; `TR_SALE_ORD.cs:3957-4020`). The item comes from the item master, which gives the name and the type
(`:4207-4210`). CommPassTotal_Old derives net weight (gross minus other weight), fine (net x touch / 100, or the typed
fine, or the net weight when there is no touch) and, from the rate type N (net wise) or F (fine wise), the rate from a
typed amount or the amount from a typed rate, in whole rupees with `Math.Round` (`:4427-4500`). A rate type other than
N or F is refused with "Please Slelect Rate type = N - Net Wise Or F - Fine Wise" (`:4157-4161`). BILL_TOTAL sums the
rows by item type into OLD_GL_AMT and OLD_GL (type G) and OLD_SL_AMT and OLD_SL (any other type), and the advance adds
both amounts (`:11345-11368`). The save rewrites SL_PR_DETL with one row for each grid row that has an item code and a
net weight or an amount, SR_NO the grid row (`:9421-9475`). Order_Rojmel keys a valued row 04 + STR(SR_NO) and a row
with fine and no amount 06 + STR(SR_NO) (`Ac_Rojmel.cs:17-21`). Order_Ledr legs 07-10 (`Ac_Ledr.cs:42-50`) join
BOOK_DATA with `BOOK_INOUT = 'I'`.

The order screen now has the old metal grid in its Order details (`web/apps/web/components/SalesOrderOldMetalGrid.tsx`,
`web/apps/web/lib/salesOrderOldMetal.ts`), and Old Gold / Old Silver Amt and Fine show the grid totals.
`web/apps/api/src/modules/sales/salesOrderOldMetal.ts` repeats the derivation on save, resolves each item and its
group's purchase account, writes SL_PR_DETL, fills the OLD_GL* header columns, adds the amounts to ADV_AMT and feeds the
shared Rojmel builder. An order with old metal can be reopened, edited and deleted; an edit that omits the rows is
refused rather than deleting them.

Deliberate differences and what stays open:
- Legs 07-10 are built and tested, but a Sales Order book is always BOOK_INOUT 'O' here (the book check refuses any
  other), so the screen's ledger carries the cash legs only and the old metal reaches the day book (Rojmel 04/06) and
  ADV_AMT. The desktop's own default order books (Mobile Order 1-4, `MS_UPDATE.cs:17799`) are 'I'. If the real Sales
  Order books are 'I', the book check must accept it and the legs will post; this needs the real BOOK_INOUT.
- The 'T' book variant (the Old Gold Amt cell typed, an URD Purchase voucher opened, `:11080-11195`) is not built. An
  order with old metal amounts but no SL_PR_DETL rows cannot be edited here, so an edit cannot zero them.
- The SL_ORD_ADJ 'O' row with ORD_GOLD and ORD_SILVER (`:9481-9516`) is not written, so metal taken without a value
  cannot yet be set against a later sale. Leg 11 (trading fine) belongs to rate cut.
- An item that is not in the master, or whose group has no purchase account, is refused with a web message; the
  desktop would insert a blank account.
- The scheme amount stays open under G206 as the baselined case `sales-order.create.scheme-tender`: the desktop types
  it in the Lite edition and adds it to the advance, but its day-book row, type 05 to the fixed account 00079, is
  absent from the real data for the 7 of 76 orders that carry a scheme amount (`web/docs/PLAN-SALESORDER-ROJMEL.md`
  section 2.4).

Evidence: `salesOrderOldMetal.test.ts` (the derivation vectors, the totals, the legs 07-10 keys for an 'I' book and
none for 'O') and `salesOrderOldMetal.db.test.ts` (refusals that leave nothing, the SL_PR_DETL rows, header totals,
ADV_AMT, Rojmel 01/04/06 with 33-character keys, reopen, the edit that omits the rows, an amount edit, the delete, an
old-metal-only advance, the edit block for amounts without rows) pass under forced RLS and fail against the code
before this change. The new browser cases `create.old-metal-tenders`, `create.old-metal-unvalued-fine` and
`edit.old-metal-then-delete` pass through the real screen (they failed before: the screen had no grid). Desktop-runtime
comparison and operator acceptance are not claimed.

### N227 — Un-blocked Lite browser cases and the four defects they found (G238, Lite L1/L3)

Gap G238 · Parents P1-core · L1 · L3 · High · Size M · Start after N226

Browser cases that had been recorded as blocked now run against the real stack. Four of them failed on a real defect,
which this slice fixes. Each fix cites the desktop line it follows.

- **Daily Rate, two operators on one day** (`MS_RATE.cs:1867-1947`). The desktop deletes the day's RATE_MAST rows and
  inserts them again with no lock; the web keeps the table's primary key, so the second of two concurrent first saves
  of a day failed with raw database text. `saveDailyRate` (`web/apps/api/src/modules/masters/dailyRate.ts`) now takes a transaction
  advisory lock keyed on tenant, company, location and date, so saves of one day run in turn and the last writer's rows
  stay.
- **Rate lookup by location** (`TR_SALE.cs:12547`). The desktop reads the day's RATE_MAST rows for its own CO_CODE and
  LC_CODE. `GET /rate` (behind the ticker and the sale forms) read every location; it now filters by the session's
  location (`web/apps/api/src/modules/masters/rate.ts`). The route moved from `web/apps/api/src/routes/txn.ts`, which is at its size ceiling, to
  `web/apps/api/src/routes/dailyRate.ts` with the same literal path.
- **Lock-date text** (`TR_CASH.cs:2943,3209`, `TR_SALE.cs:15066`, `TR_KR_ISU.cs:4980`). Every desktop voucher form
  refuses a locked date with "You Cant Save and Delete This Voucher Becouse Lock Date is = dd/MM/yyyy ....".
  `PeriodLockValidationError` (`web/apps/api/src/modules/posting/posting.ts`) carried a web-only sentence for every form that uses it; it
  now carries the desktop text with the lock date as dd/MM/yyyy.
- **Cash Received / Payment Employee box** (`TR_CASH.cs:2907-2911,3050,2753`). The page sent `empCode`; the API ignored
  it. `financeEmployeeTx` (`web/apps/api/src/modules/finance/lifecycle.ts`) refuses a blank when CO_SET.EMP_CODE_MANDATORY = 'Y' with
  "Please Select Employee Code and Try......" (before the cash limit, year and lock checks, as on the desktop) and
  refuses a code that is not a company employee; `EMP_CODE` is written to CASH_DATA and PAY_DATA, and `getReceipt` and
  `getPayment` return it so the page shows it when a voucher is opened.

Deliberate differences: the desktop defaults the Employee box to the logged-in user's employee code
(`TR_CASH.cs:2671`); the web session has no such field, so the box starts empty. Daily Rate T15 (location 00 also
stores `GROUP_MAST.GR_RATE`) stays blocked because the harness cannot start a session at location 00.

New or un-blocked browser cases: Tag Cancel T12, T13, T14, T18 (T15 is not applicable: only the STOCK ADJUST book reads
`MsPurcLot`, `TR_TAG_CAN.cs:2514-2535`), Daily Rate T11-T14 and T18, Purchase Invoice T14 and T15 (`PR_AMT_TYPE = G`),
Contra T14 and T15, Cash/Bank T14 and T15 (employee mandatory).

Evidence: `dailyRate.routes.db.test.ts` (two operators, one day; the location-scoped lookup), `cashReceiptLegs.db.test.ts`
(employee code), `periodLockMessage.test.ts`; the daily-rate DB test and the lookup test fail on the previous code. The
modules tag-cancel 16/16, purchase-invoice 29/29, contra 25/25, daily-rate 15 of 16 (1 blocked), cash-bank 19 of 21
(T03 and T06 blocked) pass on a fresh production build, and sales-invoice and sales-order (shared lock text and rate
lookup) have no new failure. Sales Return and Purchase Return were left alone; their cases are patches for their owners.
Not accepted: no desktop-runtime comparison was made.

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
| N91 | — | implemented-unverified, evidence in this change (G105: provisioning creates the INWORD/OUTWORD books and the branch account so Stock In/Out opens, saves and posts) |
| N92 | — | implemented-unverified, evidence in this change (G102: the nine document screens preview the total the server posts, via the shared `@datacare/core` rounding policy on `/me`) |
| N93 | — | implemented-unverified, evidence in this change (G84, G106: every document preview composes the line net the server posts — metal + gross labour + other — with discount/ghat on their own columns) |
| N94 | — | implemented-unverified, evidence in this change (G107/SP03: an AST lint gate rejects a request/input value interpolated into raw `$queryRawUnsafe`/`$executeRawUnsafe` SQL; proven by a planted-violation test) |
| N95 | — | implemented-unverified, evidence in this change (G108/SP03: a per-file line-count ceiling that may only fall, capping new files at 1,500 lines, enforced in CI; proven by a growth test) |
| N96 | — | implemented-unverified, evidence in this change (G89: the writer and previews derive the old-metal conversion weight `CON_WT` from `CON_PRC` and the fine, matching the desktop; a posted weight is ignored) |
| N97 | — | implemented-unverified, evidence in this change (G109: provisioning creates the DHIRAN ISSUE/RECEIPT books so Pledge Loan Issue/Receipt open and post) |
| N98 | — | implemented-unverified, evidence in this change (G101 part: the three Dhiran screens filter their book list to DHIRAN ISSUE / DHIRAN RECEIPT; browser-confirmed) |
| N99 | — | implemented-unverified, evidence in this change (G101 part: Journal → JOURNAL, Item Lot → ITEM LOT, Tour → APPROVAL ISSUE book filters; Item Lot browser-confirmed) |
| N100 | — | implemented-unverified, evidence in this change (G110: provisioning creates the LABOUR WORK / FINE SALE / FINE PURC books so Labour Sale and Fine Settlement open; Labour Sale list filtered) |
| N101 | — | implemented-unverified, evidence in this change (G111: provisioning creates the ledger-less TAG OPENING book so Tag Opening opens; list filtered) |
| N102 | — | implemented-unverified, evidence in this change (G112: provisioning creates the ledger-less FINE INOUT book so Fine In/Out opens; list filtered) |
| N103 | — | implemented-unverified, evidence in this change (G113: provisioning creates the BUL SALE / BUL_DATA book so Bullion Booking opens; list filtered) |
| N104 | — | implemented-unverified, evidence in this change (G114: provisioning creates the ledger-less OPSTK / BAR_DATA book so Item Opening opens; list filtered) |
| N105 | — | implemented-unverified, evidence in this change (G101 part: Multi-Party Receipt book list filtered to RECEIPT) |
| N106 | — | implemented-unverified, evidence in this change (G115: labour-income account resolved from BOOK_DETL SR_NO 6, not a literal; P0-04 68→67) |
| N107 | — | implemented-unverified, evidence in this change (G116: sales-return control/cash/round accounts resolved from BOOK_DETL slots; P0-04 67→63) |
| N108 | — | implemented-unverified, evidence in this change (G117: purchase-return control/cash/round accounts resolved from BOOK_DETL slots; P0-04 63→59) |
| N109 | — | implemented-unverified, evidence in this change (G118: dhrn funding account resolved from BOOK_DETL slot 2, not a literal; P0-04 59→56) |
| N110 | — | implemented-unverified, evidence in this change (G119: sale cash/round/kasar accounts default to the resolved control account, not literals; P0-04 56→53) |
| N111 | — | implemented-unverified, evidence in this change (G120: purchase cash/round/kasar default to the resolved control account; purchase.ts pinned to true count 5; P0-04 53→48) |
| N112 | — | implemented-unverified, evidence in this change (G121: bullion payable/cash resolved from BOOK_DETL slots 1/2; bullion.ts cleared; P0-04 48→46) |
| N113 | — | implemented-unverified, evidence in this change (G122: provisioning creates the ORDER CANCEL book so Order Cancel is usable) |
| N114 | — | implemented-unverified, evidence in this change (G123: fine-settlement metal account resolved from FSL/FPR BOOK_DETL slot 1; fineSalePurchase.ts cleared; P0-04 46→44) |
| N115 | — | implemented-unverified, evidence in this change (G124/G100: seed the WALKIN walk-in customer so the default retail sale posts) |
| N116 | — | implemented-unverified, evidence in this change (G125: sales Tax Invoice print GET /sales/:vchNo/print; verified live HTML 200 with correct bill) |
| N117 | — | implemented-unverified, evidence in this change (G126: purchase bill print GET /purchases/:vchNo/print; verified live HTML 200) |
| N118 | — | implemented-unverified, evidence in this change (G127: sales-return credit-note print GET /sales-returns/:vchNo/print; verified live HTML 200) |
| N119 | — | implemented-unverified, evidence in this change (G128: contra voucher print GET /contra/:vchNo/print; verified live HTML 200) |
| N120 | — | implemented-unverified, evidence in this change (G129: journal voucher print GET /journal/:vchNo/print; verified live HTML 200) |
| N121 | — | implemented-unverified, evidence in this change (G130: fine sale/purchase reopen GET /fine-sale/:vchNo; verified live HTTP 200) |
| N122 | — | implemented-unverified, evidence in this change (G131: ledger-adjust & employee-jv reopen+edit; verified live round-trip) |
| N123 | — | implemented-unverified, evidence in this change (G132: Card Receipt / CARD ADJUST workflow; verified live full lifecycle) |
| N124 | — | implemented-unverified, evidence in this change (G133: Customer Entry CRM workflow; verified live full lifecycle) |
| N125 | — | implemented-unverified, evidence in this change (G134: desktop-faithful Loan/Dhrn Interest Receipt; verified live full lifecycle) |
| N126 | — | implemented-unverified, evidence in this change (G135: Dhrn Os Letter pledge-outstanding document; verified live HTML 200) |
| N127 | — | implemented-unverified, evidence in this change (G136: Tour Sales via the wholesale engine on a TOUR SALES book; verified live full lifecycle) |
| N128 | — | implemented-unverified, evidence in this change (G137: journal reopen+edit routes; verified live round-trip) |
| N129 | — | implemented-unverified, evidence in this change (G138: contra page full lifecycle UI; verified live in browser) |
| N130 | — | implemented-unverified, evidence in this change (G139: journal page lifecycle UI; verified live render) |
| N131 | — | implemented-unverified, evidence in this change (G140: ledger-adjust & employee-jv lifecycle UI + voucher-list allow-list; verified via the web /api proxy) |
| N132 | — | implemented-unverified, evidence in this change (G141: loan-interest page lifecycle UI on the DIR book; verified via the web /api proxy) |
| N133 | — | implemented-unverified, evidence in this change (G142: Tour Sales frontend page via the shared wholesale form; verified live in browser) |
| N134 | — | implemented-unverified, evidence in this change (G143: Card Receipt frontend page on the CRD book; verified via the web /api proxy) |
| N135 | — | implemented-unverified, evidence in this change (G144: Customer Entry frontend page; verified via the web /api proxy) |
| N136 | — | implemented-unverified, evidence in this change (G145: Dhrn Os Letter frontend page; verified page 200 + letter 200) |
| N137 | — | implemented-unverified, evidence in this change (G146: receipt/payment lifecycle UI + editReceipt ROJ_MEL_DATA fix + payment-delete mode resolution; verified via the web /api proxy) |
| N138 | — | implemented-unverified, evidence in this change (G147: fine-jv lifecycle UI + FINE JV book provisioning; verified live) |
| N139 | — | implemented-unverified, evidence in this change (G148: payment edit — postPayment lifecycle refactor + editPayment + PUT; verified live) |
| N140 | — | implemented-unverified, evidence in this change (G149: scheme-installment edit route + input-helper extraction; verified by the suite) |
| N141 | — | implemented-unverified, evidence in this change (G150: committed the missing cardReceiptInputFromBody export, fixed the PaymentForm save-confirmation regression, resynced the depth baseline + triage; PR #109 all CI jobs green, main run 40827479158 success) |
| N142 | — | implemented-unverified, evidence in this change (G151: batch-receipt kasar now resolves BOOK_DETL slot 2 via the shared kasarAccountTx; DB test 4/4, full API+DB 319/3496, live POST 201 was 400) |
| N143 | — | implemented-unverified, evidence in this change (G152: dhrn pledge-issue reopen/edit/delete + lifecycle UI; route universe 641→644, DB test 3/3, full API+DB 320/3499, live POST 201 + PUT 200) |
| N144 | — | implemented-unverified, evidence in this change (G153: dhrn pledge-receipt reopen/edit/delete + ISU_REC-restore fix; routes extracted to crm.ts, universe 644→647, DB test 3/3, full API+DB 3502, live POST 201) |
| N145 | — | implemented-unverified, evidence in this change (G154: Loan Received + Loan Issue reopen/edit/delete reusing the dhrn readers + loan-flag editors; universe 647→653, DB test 2/2, full API+DB 3504) |
| N146 | — | implemented-unverified, evidence in this change (G155: KarigarForm reopen/edit lifecycle lighting up karigar-issue/receive + old-item-sales; UI-only, live create 201→GET→PUT 200→GET verified) |
| N147 | — | implemented-unverified, evidence in this change (G156: Fine Sale/Purchase edit — writer refactored to a forceVchNo context + reverseFineSaleTx + editFineSalePurchase + PUT; universe 653→654, DB test 1/1, full API+DB 3505, live create 201→reopen→PUT 200) |
| N148 | — | implemented-unverified, evidence in this change (G157: jobwork reopen/edit/delete extended into the shared KarigarForm — lifecycle+MFG_DATA table+getMfg-shape loadVoucher branch with components sub-detail; sub-agent implement+audit AUDIT_PASS, AST proof all 23 line + 18 component fields round-trip and the karigar/stones path byte-identical; gates + clean API build + web 646+9 + depth:parity green; live deferred — demo has no jobwork book) |
| N149 | — | implemented-unverified, evidence in this change (G158: mfg-issue reopen/edit lifecycle UI wired to the DB-tested getMfg/editMfg routes; UI-only, gates + web 9/9 green, live deferred — demo has no MFG book) |
| N150 | — | implemented-unverified, evidence in this change (G159: mfg-receive reopen/edit lifecycle UI, companion to N149; UI-only, gates + web 9/9 green, live deferred — demo has no MFG book) |
| N151 | — | implemented-unverified, evidence in this change (G160: bullion-sale reopen/edit/delete lifecycle UI; UI-only, sub-agent implement+audit AUDIT_PASS, gates + clean API build + web 646+9 + bullionSale.db.test.ts 2/2 + depth:parity green, live deferred — demo has no bullion book) |
| N153 | — | implemented-unverified, evidence in this change (G161 prerequisite: getMfg reader now maps the nine MFG_DETL columns it dropped — totalNetWt/oldNetWt/netAmt/itmLoss/rateType/prCode/krName/ordAcCode/ordDesign; backend correctness fix proven by operatorDepth.roundtrip.db.test.ts 3/3 + mfgLifecycle.db.test.ts 9/9; gates + clean API build + depth:parity green; size ceiling 1504→1516; unblocks N152 UI) |
| N152 | — | implemented-unverified, evidence in this change (G161: mfg-order-issue reopen/edit/delete lifecycle UI, unblocked by N153; UI-only, sub-agent implement+audit AUDIT_PASS with AST field-mapping proof all 61 sent keys restored, stale-target guard; gates + clean API build + web 646+9 + depth:parity green, live deferred — demo has no MFG/DIS book) |
| N154 | — | implemented-unverified, evidence in this change (G162: multi-party batch-receipt reopen/edit/delete — getBatchReceipt reader with derived pay mode + editBatchReceipt reverse+re-post + GET/PUT/DELETE routes + UI + VoucherList; proven by batchReceiptLifecycle.db.test.ts 2/2 (balanced AC_DATA + DELETE_DATA audit + unchanged round-trip) and batchReceiptKasar 4/4; routePolicy 56/56 universe 654→657; forceVchNo triaged internal (unreachable 102→103, operator 0); gates + clean API build + web 646+9 + depth:parity green; txn.ts ceiling 8443→8482) |
| N155 | — | implemented-unverified, evidence in this change (G163: order-cancel refund/kasar accounts resolved from BOOK_DETL slots instead of the 'CASH'/'KASAR' literals — explicit wins, else slot 1/2, fail-closed; proven by salesOrderCancelAccounts.db.test.ts 4/4 (slot resolution, kasar slot-2, explicit wins, fail-closed) with salesFamilyLifecycle 31/31 unaffected; gates + clean API build + web 646+9 + sales-order DB 58/58 + depth:parity green; salesOrder.ts ceiling 2350→2361) |
| N156 | — | implemented-unverified, evidence in this change (G164: sales-order advance debits the order book BOOK_DETL slot-1 account instead of the 'CASH' literal — explicit wins, fail-closed; proven by salesOrderRound4 fail-closed+explicit case (11/11) and salesFamilyLifecycle SOR slot-1 (32); gates + clean API build + web 646+9 + sales-order DB green; salesOrder.ts ceiling 2361→2374) |
| N157 | — | implemented-unverified, evidence in this change (G165: core sale posting resolves cash=BOOK_DETL slot-2, income=slot-1, electronic-tender bank=persisted BANK_AC fail-closed, and a single-income invariant instead of literals; the 6 non-configurable defaults oldgold/hmcharge×2/tcs×2/gst are verified legitimate and left, tracked in REMAINING 11→6, TOTAL 41→36; full sales DB suite 69/9 + gates + clean API build + web 646+9 + depth green; sales.ts ceiling 2809→2845) |
| N158 | — | implemented-unverified, evidence in this change (G166: purchase expense account resolves from BOOK_DETL slot-1 instead of the 'PURCHASE' literal, explicit wins/fail-closed, plus a single-expense invariant; the 3 non-configurable defaults gstinput/hmcharge×2 verified legitimate and left, tracked in REMAINING 5→3, TOTAL 36→34; full purchase DB suite 55/9 + gates + clean API build + web 646+9 + depth green; purchase.ts ceiling 2860→2883) |
| N159 | — | implemented-unverified, evidence in this change (G167: labour invoice resolves metal-sale from BOOK_DETL slot 1 and round-off from slot 3 via a generalized resolveLabourBookSlot, gated on their legs posting, explicit wins/fail-closed; the 'GST' tax default left documented; REMAINING labourInvoice.ts 3→1, TOTAL 34→32; salesFamilyLifecycle gained LBR slots 1/3 and passes 31; labour DB suite 118/8 + gates + clean API build + web 646+9 + depth green) |
| N160 | — | implemented-unverified, evidence in this change (G168/N50-increment: a synchronous input-shape TypeError/RangeError from a mutation handler body now maps to a 400 invalid-request in run(), so a non-array 'lines' is 400 not 500 'lines.map is not a function'; typed server-fault 500s preserved — serializable-command 78 pass; two new probes in saleAmountBasis.routes.db.test.ts + broad routes.db 53/14 + gates + clean API build + web 646+9 + depth green; txn.ts ceiling 8482→8491) |
| N161 | — | implemented-unverified, evidence in this change (feature E2E suite framework + Sales Invoice matrix of 22 cases through the real screen: 16 passed, 3 failed and baselined as G169/G170/G171, 3 blocked with reasons; evidence bundle valid under the evidence-contract validator; negative control fails the gate; CI step added to the real-stack job) |
| N162 | — | implemented-unverified, evidence in this change (G169, G176: one item leg per detail line keyed STR(SR_NO)+03 when a sale or purchase posts to two item accounts; labour-split leg off code 03; vectors 60 passed, HTTP write-set suites 13 passed, negative control reproduces the duplicate-key 400; feature E2E Sales 18/2/3 and Purchase 17/2/2 with both baseline entries removed; browser runs of both screens) |
| N163 | — | implemented-unverified, evidence in this change (G171: Alt+S presses the marked Save button from any field; web unit 12 passed; sales and purchase Alt+S feature cases pass and left the baseline; Contra saved with Alt+S in a Chrome DevTools run) |
| N164 | — | implemented-unverified, evidence in this change (UI surface crawl + committed map `docs/handbook/web/ui-surface-map.md` + PR browser-test gate; found G172) |
| N165 | — | implemented-unverified, evidence in this change (G172: the selection retries a transaction conflict and the screen explains; unit 3, new Open Company module, fails against the old screen) |
| N166 | — | planned (G173, G174: fault injection for T14 and a settings-variant company for T15 in the feature E2E harness) |
| N167 | — | planned (G175: decide the negative-weight line rule from an original-Windows run, then implement and execute the case) |
| N168 | — | implemented-unverified, evidence in this change (G177: four numeric setting combos accept typed amounts with presets; unit 3, DB 14, two feature cases; baseline entry removed) |
| N169 | — | implemented-unverified, evidence in this change (G178: last-administrator refusal with row locks; DB test 3 passed and fails against the old code; Users & Rights feature module: 3 cases pass through the real screen); live demo `dc-shop` `admin` restored to ADMIN with all three rights on 31 October, row backed up first |
| N170 | — | implemented-unverified, evidence in this change (Purchase Invoice module 16/3/2, Settings effects module 10/1/2 + 11 N/A, Sales CSV export case, one shared company per run, with-data crawl and regenerated map; found G176, G177, G178) |
| N171 | — | planned (G183, D31: Standard edition gate — the 114 Standard menus only in navigation, rights, pages and API; deferred editions available only as labelled Beta when switched on) |
| N172 | — | in-progress, evidence in this change (G179: Sales and Purchase voucher number box F1/Up/Down/Enter with the shared walk endpoint and hook; DB test 8, web unit 4, two feature cases with a negative control; the other voucher screens remain) |

| N171 | — | implemented-unverified, evidence in this change (G183: generated edition table, 245 routes and 252 forms; API 403 edition-unavailable, /me edition, rights catalog filtered; Standard navigation, page guard and Beta group; core, API, web and generator tests; browser runs in Standard and with Beta) |
| N172 | — | planned (G179: voucher number box — Enter opens the voucher, Up the last, Down the first, F1 the list, on every Standard voucher screen) |
| N173 | — | implemented-unverified, evidence in this change (G180: print windows refresh the session first; unit 5, feature case with the access cookie dropped, fails against the old screen) |
| N174 | — | planned (G181: printed HSN table rounds the GST halves consistently and totals the bill tax) |

| N173 | — | planned (G180: the print window works after the access cookie expires) |
| N174 | — | implemented-unverified, evidence in this change (G181: the HSN summary prints the header tax heads; unit 23 incl. 300 generated bills, feature case through Print, both fail against the old code) |
| N175 | — | implemented-unverified, evidence in this change (G182: no navigation prefetch; one balance request per typed party; feature case fails against the old code) |
| N176 | — | implemented-unverified, evidence in this change (G184: provisioned purchase books carry slot 4; DB tests, feature case fails against the old provisioning) |
| N177 | — | implemented-unverified, evidence in this change (G185: Enter resolves the typed code when the list is for older text; web unit 7 passed; two new feature cases pass and fail against the old component) |
| N178 | — | planned (G186: negative-stock and period-lock refusals use the desktop wording) |
| N179 | — | planned (G188: classify the 141 no-effect buttons as by-design with source, or open a gap) |
| N180 | — | implemented-unverified, evidence in this change (Sales Return module 14/7/3 on shared real data; found G190–G196; corrects the N161/N170 rounding statement) |
| N181 | — | implemented-unverified, evidence in this change (G190: N/G/F Sales Return basis; whole-rupee item, labour, line-net and total; tax precision retained; 23/0/2 browser result) |
| N182 | — | implemented-unverified, evidence in this change (an imported loose line with tag N saves as loose stock and an unknown tag is still refused; Import stays inside its field; both feature cases pass and leave the baseline) |
| N183 | — | implemented-unverified, evidence in this change (G193: a second delete answers 404 voucher-not-found; G194: the sales return and seven deletes record the login name; 4 baselined cases pass in the browser) |
| N184 | — | planned (G195: sale line amounts round to whole rupees unless ALL_ROF_REMOVE = Y; merged feature expectations move to desktop values) |
| N185 | — | planned (G196: decide under D05 and provision the desktop rounding defaults for new companies, or record the 2-decimal choice) |
| N186 | — | implemented-unverified, evidence in this change (G197: the web build clears the route cache; unit 2, a real build removed 13 entries) |
| N187 | — | implemented-unverified, evidence in this change (Purchase Return module 15/5/2 on shared real data; found G198–G201; narrows G193) |
| N188 | — | in-progress, milestone 1 evidence in this change (G198 Purchase Return: 58,466 net, 1,753.98 tax, 60,220 total; 20/0/2 browser result; ordinary Purchase half remains) |
| N189 | — | implemented-unverified, evidence in this change (G199: BookSelect `required` opt-out; a free-standing purchase return saves, and a reopened one saves unchanged) |
| N190 | — | implemented-unverified, evidence in this change (G200: 22 voucher screens marked; a unit scan keeps every voucher page's primary Save marked; purchase-return Alt+S passes in the browser) |
| N191 | — | implemented-unverified, evidence in this change (G201: desktop BOOK_TBL_NAME/BOOK_TBL_DETL on ten families, backfill migration; purchase-return register case passes) |
| N192 | — | implemented-unverified, evidence in this change (G202, D32 recorded; generated per-tier progress page; Lite packages in document 15 §5) |
| N193 | — | implemented-unverified (G203: cheque number on every bank leg, #165) |
| N194 | — | implemented-unverified, evidence in this change (G204: the TR_CONTRA grid) |
| N195 | — | implemented-unverified, evidence in this change (G205-G208: Sales Order feature module, 14 passed / 9 baselined / 2 blocked) |
| N196 | — | implemented-unverified, evidence in this change (G205: order line priced on SL_AMT_TYPE in whole rupees; tax and total rounded; sales-order formula and amounts cases pass) |
| N197 | — | implemented-unverified, evidence in this change (G206 part: cash, cheque and card tenders stored per tender and posted on legs 01-06; UPI, old metal and scheme stay open) |
| N198 | — | implemented-unverified, evidence in this change (G207: SOR slot 1 is the cash account; G208: sale books get slot 4 ORDER ADVANCE; backfill migration; advance-ledger and order-to-sale cases pass) |
| N199 | — | implemented-unverified, evidence in this change (G209, G210: Party Opening is TR_AC_OPBL; openings counted once) |
| N200 | — | implemented-unverified, evidence in this change (G211: the bill-wise opening grid) |
| N201 | — | planned (G212: one carry-forward writer for Year End close and Balance TrFr) |
| N202 | — | implemented-unverified, evidence in this change (G213, D33: Lite is the default edition; the configuration reads pass the gate) |
| N203 | — | implemented-unverified, evidence in this change (G214, G215, G216: Tag Opening and Only Tag Entry follow TR_TAG_OPBL; reopen keeps every field; stock rows follow Tag_Opbl_Stk) |
| N204 | — | implemented-unverified, evidence in this change (G217: the karigar weight block is on the tag grid with the CommPassTotal rules, saved to BAR_DETL and copied to MAIN_STOCK) |
| N205 | — | implemented-unverified, evidence in this change (G218: the production server starts from an empty route cache; suites refuse occupied ports) |
| N206 | — | implemented-unverified, evidence in this change (G219: Fine Jv Entry is the TR_CONTRA FINE JV grid with paired rows, 33-character fine legs, remark rebuild and the desktop refusals; Contra and Journal refuse another family's book and need print rights; 18 browser cases pass, 5 blocked) |
| N207 | — | implemented-unverified, evidence in this change (G220: the voucher list and number-box routes require read rights on a form that owns the book's MAIN_BOOK) |
| N208 | — | implemented-unverified, evidence in this change (G221: Daily Rate is MS_RATE — grid source, recalculation, scoped save/delete, F1, RateRpt, rights) |
| N209 | — | implemented-unverified, evidence in this change (G222: Item Opening is the TR_ITM_OPBL metal-type grid in book 000 with ITOBL stock rows, DM_DATA for OTH_DETL_POSTING items and the desktop messages) |
| N210 | — | implemented-unverified, evidence in this change (G223: Tag Cancel prints TagCanBill behind print rights and refuses type B, the year and the lock date with the desktop texts in desktop order) |
| N211 | — | implemented-unverified, evidence in this change (G224: the Employee master is the MS_EMP screen with its list, next code, keys, desktop texts, rights alias and account help; version tokens and the web refusals recorded on the gap) |
| N212 | — | implemented-unverified, evidence in this change (G225: the Lite menu captions reach their screens' forms as USER_SET aliases; Party Opening's Save checks the edit right for an existing opening) |
| N213 | — | implemented-unverified, evidence in this change (G226: the Tax master is the MS_TAX header and component grid with the desktop keys, texts, helps and rights; generic TAX_MAST writes refused; the account picker keeps a chosen row) |
| N214 | — | implemented-unverified, evidence in this change (G227: the Item Group master is MS_GROUP with the desktop keys, texts, helps, rights and the item update; the row is updated in place in one transaction) |
| N215 | — | implemented-unverified, evidence in this change (G228: the Product master is MS_PRODUCT's Product mode with the desktop keys, texts, rights and the item-use and default-product guards after the question) |
| N216 | — | implemented-unverified, evidence in this change (G229: Cash/Bank and Contra refuse dates outside the year with the desktop text before numbering and before the lock-date check, with no partial write; the Contra recent list shows the summed debit once; the bounded register-date manifestation is now implemented-unverified under N57, while broad N57 / G37 remains planned and open) |
| N217 | — | implemented-unverified, evidence in this change (G230: the Address master is MS_ADD_MAST with its tabs, next code, combos, helps, mobile check, rights and the delete of its opening rows) |
| N218 | — | implemented-unverified, evidence in this change (G231: the Item master is MS_ITEM with its helps, item code from product and group, exists question, leave checks, setting-driven boxes, delete checks, rights and the Tag Value Update panel) |
| N219 | — | implemented-unverified, evidence in this change (G232: Auto Item is MS_AUTO_ITEM's AutoItem mode with the group help, the product grid and its keys, the desktop write set, the refusals and the rights) |
| N220 | — | implemented-unverified, evidence in this change (G233: Wh Sales refuses as TR_WH_SALE does — defaulter, employee, type B, cheque/card bank, year, lock date, item code — with no partial write; the delete asks the desktop question; WhSalesBill prints behind the print right) |
| N221 | — | implemented-unverified, evidence in this change (G234: Stock Adjust is TR_TAG_CAN on a STOCK ADJUST book with the Sign column, the signed register, I and O stock rows, the lot columns and LOT_DETL, reopen, edit, delete and TagCanBill) |
| N222 | — | implemented-unverified, evidence in this change (G206 part: UPI tender rows stored in UPI_DATA, posted on legs 12/13 and Rojmel 08, included in ADV_AMT, editable and deletable; old metal and scheme stay open) |
| N223 | — | implemented-unverified, evidence in this change (G235: the Ledger Report is RP_LEDR with its account summary, voucher/detail drill-down, debit ageing, signed money/gold/silver balances, totals, selectors and PDF/Excel/CSV, from one read-only resolver) |
| N224 | — | implemented-unverified, evidence in this change (G236: Party is MS_ACCT — the list and next code of the location, both tabs in tab order with the group, mobile, short-name, GST and account checks, the opening and AC_MAST_SRNO in one transaction with the save, the photo, the copy helps, Print and Delete with the desktop's refusals) |
| N225 | — | implemented-unverified, evidence in this change (G237: Tag Print is UT_TAG_PRINT — the voucher and stock selection, typed tags, Y/N rows, Hm Id Update, the default file and a print that stages after the Lable Skip blanks) |
| N226 | — | implemented-unverified, evidence in this change (G206 part: old gold and old silver rows stored in SL_PR_DETL, totalled into the header and ADV_AMT, day book 04/06, editable and deletable; scheme stays open) |
| N227 | — | implemented-unverified, evidence in this change (G238: two operators saving one Daily Rate day no longer collide, the rate lookup is scoped to the session's location, every voucher form's lock-date refusal carries the desktop text, and the Cash Received/Payment Employee box is stored, enforced when mandatory and read back; browser cases un-blocked for Tag Cancel, Daily Rate, Purchase Invoice, Contra and Cash/Bank) |
| Decisions D23, D24, D26, D27 | Recommended, awaiting approval | Accepted as recommended by the owner, 1 October 2026; D28 added (Phase 2 waits for Phase 1) |
| Decisions D15–D22, D30 and D01–D14 starting positions | Recommended, awaiting the owner | Accepted as recommended on 30 October 2026, when the owner delegated the open decisions to the implementer; D01–D14 starting positions recorded in document 08 §1 |

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
