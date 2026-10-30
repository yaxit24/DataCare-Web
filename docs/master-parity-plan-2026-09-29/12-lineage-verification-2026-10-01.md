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
