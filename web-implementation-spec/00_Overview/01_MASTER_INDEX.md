# Master Index

Live index of the whole specification + per-module status. Status legend in `00_README.md §6`.

## Section index

| Section | Contents | Status |
|---|---|---|
| `00_Overview/` | README, this index, doc template, glossary | 📋 SPEC |
| `01_Architecture/` | tech-stack mapping, system architecture, multitenancy/scoping, conventions | 📋 SPEC |
| `02_Data_Model/` | overview + per-cluster ERDs + 162-table reference (generated) | 📋 SPEC |
| `03_Modules/` | the 14 functional module deep-dives (37+ form docs) | 📋 SPEC |
| `04_Cross_Cutting_Engines/` | posting, calc, numbering, GST, RBAC, reporting, integrations | 📋 SPEC |
| `05_Reports/` | report catalog (255 .rpt) + per-report field specs | 📋 SPEC |
| `06_Parity/` | parity method, 4-tier model, per-module gates + risk register | 📋 SPEC |
| `07_Build_Plan/` | phased, dependency-ordered build order with parity gates | 📋 SPEC |

## Functional modules (the 204 forms grouped)

Forms are grouped into **14 functional modules**, aligned to the proven `web/apps/api/src/modules`
decomposition. "Web module" is the existing reference implementation folder (if any).

| # | Module | Key forms | Web module | Doc | Build |
|---|---|---|---|---|---|
| 0 | **Foundation / Auth / Company-Year** | MS_LOGIN, MS_OPNCOMP, MS_COMPANY, MS_YEAR, MS_USER, AuthClass | `auth`, `rbac` | ⬜ TODO | 🟩 BUILT |
| 1 | **Masters** (33) | MS_ACCT, MS_ITEM, MS_RATE, MS_TAX, MS_BOOK, MS_EMP, MS_GROUP, MS_STYLE, MS_PRODUCT, … | `masters` | [📋 SPEC](../03_Modules/1_Masters/README.md) | 🟩 BUILT |
| 2 | **Sales** | TR_SALE, TR_SALE_LBR, TR_SALE_HM, TR_SALE_ORD, TR_SALE_RTN, TR_WH_SALE, TR_SL_ORD_ADJ | `sales` | 📋 SPEC *(gold standard)* | 🟩 BUILT |
| 3 | **Purchase** | TR_PURC, TR_PURC_HM, TR_OTH_PURC, TR_PR_SL_UAE, TR_PR_SL_HEDG | `purchase` | ⬜ TODO | 🟩 BUILT |
| 4 | **Inventory / Tags / Stock** | TR_TAG_OPBL, TR_TAG_SPLIT, TR_TAG_CAN, TR_TAG_WT_DIFF, TR_PHYSTK, TR_ITM_LOT, Ac_Stock | `stock` | ⬜ TODO | 🟩 BUILT |
| 5 | **Manufacturing / Karigar** | TR_MFG_ISU_REC, TR_MFG_ORD_*, TR_MFG_WITH_LOT, TR_KR_ISU, TR_MLT_PRO, TR_REP_REC | `manufacturing` | [📋 SPEC](../03_Modules/5_Manufacturing/README.md) | 🟦 PARTIAL |
| 6 | **Loans / Dhrn (pledge)** | TR_DHRN_ISU, TR_DHRN_REC, TR_DHRN_INTREC | `dhrn` | 📋 SPEC | 🟩 BUILT |
| 7 | **Finance / Cash-Bank** | TR_CASH, TR_CONTRA, TR_CARD_REC, TR_UPI_REC, TR_LOCT_AMT | `finance` | 📋 SPEC | 🟩 BUILT |
| 8 | **Accounting / Ledgers** | Ac_Ledr, Ac_Final, Ac_Rojmel, Ac_Tax, TR_AC_OPBL, TR_LEDR_ADJ, TR_JDT_REC, TR_EMP_JV | `accounting`, `posting` | [📋 SPEC](../03_Modules/8_Accounting/README.md) | 🟩 BUILT |
| 9 | **GST & E-Invoice** | RP_GST, TR_SL_EBILL, UT_E_INVOICE, IRNClass | `gst`, `einvoice` | [📋 SPEC](../03_Modules/9_GST_EInvoice/README.md) | 🟩 BUILT |
| 10 | **Membership / Loyalty** | TR_MEMB_ENT, TR_MEMB_ADJ, MS_MEMB, MS_POINT | `membership` | [📋 SPEC](../03_Modules/10_Membership/README.md) | 🟩 BUILT |
| 11 | **Bullion / Tour / VP** | TR_BUL_SALE, TR_TOUR_SALE, TR_VP, TR_GOLD_BOOK, TR_FINE_SL_PR, TR_FN_INOUT, TR_INOUT | `bullion`, `tour`, `inout` | [📋 SPEC](../03_Modules/11_Bullion_Tour_VP/README.md) | 🟦 PARTIAL |
| 12 | **Reports** (45 + 255 .rpt) | RP_* | `reports` | [📋 SPEC](../05_Reports/README.md) | 🟦 PARTIAL |
| 13 | **Utilities / Settings / Integrations** | UT_* (22), MS_UPDATE, CO_SET | `settings`, `utilities`, `integrations` | [📋 SPEC](../03_Modules/13_Utilities_Settings_Integrations/README.md) | 🟦 PARTIAL |

> **Build status caveat.** "BUILT" reflects what `project-memory/HANDOFF.md` claims the `web/`
> monorepo implements (core backend + ~50 screens + 16 reports, certified on real data). It must
> be **re-verified against this spec** per `06_Parity/` — a built module is not a parity-certified
> module until its acceptance criteria pass.

## Cross-cutting engines (build before transaction modules)

| Engine | Desktop source | Web target | Doc |
|---|---|---|---|
| Double-entry posting / ledger | `Ac_Ledr.cs` → `AC_DATA` | `modules/posting` | ⬜ TODO |
| Weight / fine / labour calc | inline in TR_* forms | `packages/core` calc | ⬜ TODO |
| Voucher numbering | `SRNO_MAST` | `modules/vouchers` | ⬜ TODO |
| GST engine (CGST/SGST/IGST) | inline + `Ac_Tax.cs`, `TAX_MAST` | `modules/gst` | ⬜ TODO |
| RBAC / auth | `AuthClass.cs`, `LOGIN_MAST` | `modules/auth`, `modules/rbac` | ⬜ TODO |
| Reporting engine | Crystal `.rpt` | `packages/reports`, `modules/reports` | [📋 SPEC](../05_Reports/README.md) |
| Integrations framework | `Module_WhatsApp`, `UT_SMS`, `OlockerService` | `modules/integrations` | ⬜ TODO |

## Progress log

| Date | Change |
|---|---|
| (init) | Scaffolded tree; wrote 00_Overview (README, template, glossary, index). |
| 2026-06-30 | Module 8 Accounting/Ledgers documented: README + deep-dives (Account Ledger, Trial Balance, TR_AC_OPBL) + Ac_Final, Ac_Rojmel, Journal Vouchers (TR_LEDR_ADJ/TR_JDT_REC/TR_EMP_JV). |
| 2026-06-30 | Module 5 Manufacturing/Karigar/Job-Work documented: README + flowchart (issue→karigar→receive→stock) + full deep-dives (TR_MFG_ISU_REC process issue/receive incl. lot variant, TR_MLT_PRO melting, TR_KR_ISU karigar) + variant stubs (TR_MFG_GHAT_REC, TR_MFG_ORD_ISU/REC, TR_MFG_WITH_LOT, TR_REP_REC). Build set to 🟦 PARTIAL (mfg.ts engine built; MFG_MAST unseeded, MFG_ISU_REC multi-row + lot schema gaps flagged). |
| 2026-06-30 | Module 1 Masters documented: README (config-driven generic-CRUD engine with the real MASTERS registry code, full 33-form inventory table → table/keys/required/web-status, ER diagram, /masters/:name +meta/import API, build checklist) + deep-dives MS_ACCT (chart of accounts + AC_GROUP, referenced-delete vs AC_DATA), MS_RATE (per-day metal rate driving valuation, GROUP_MAST back-write, fetchRate), MS_YEAR (year setup seeding ~17 tables; CREATE DATABASE → CO_YEAR collapse). Flagged the engine's missing UPDATE path and the unbuilt MS_YEAR/MS_COMPANY seed services. Doc status → 📋 SPEC. |
| 2026-06-30 | Module 13 Utilities/Settings/Integrations documented: README (form inventory of 22 UT_* + env-adapter model + ER + API surface + build checklist) + full deep-dives SETTINGS (CO_SET incl. LOCK_DATE period-lock consumed by posting engine, CASH_LIMIT→PAN, GST/e-invoice config split), BACKUP_RESTORE (JSON /backup + pg_dump/restore), INTEGRATIONS (WhatsApp Cloud API + SMS gateway + never-throws notify Req 20.3 + Code39/QR + live rates) + variant stubs (UT_VCH_RE_NUMBR, UT_REMINDER, UT_IMPORT/EXPORT, MS_UPDATE, UT_WEB_CAM/UT_HDD device-bound, audit log). Doc → 📋 SPEC; build stays 🟦 PARTIAL (CO_SET_NEW + import/export + MS_UPDATE recompute gaps flagged). |
| 2026-06-30 | Module 9 GST & E-Invoice documented: README + form inventory + module ERD + full deep-dives — RP_GST (GSTR-1 B2B/B2CL/B2CS/HSN read-models over SL_DATA⋈AC_MAST⋈SL_DETL + GSTR-3B summary + GSTR-2/input-register; cites Ac_Tax.Sales_GST TAX_DATA posting) and TR_SL_EBILL (NIC v1.1 IRN payload, Chartered Info GSP submit via IrnTransport, store IRN/ACK on SL_DATA + E_DATA, error→no-IRN Req 18.4/18.5; sequence diagram). GSP creds flagged as EXTERNAL BLOCKER (FakeIrnTransport until set). Doc set to 📋 SPEC; build remains 🟩 BUILT (gstr1 11/11; IRN Fake). |
| 2026-06-30 | **05_Reports documented** (Module 12 → 📋 SPEC): catalog README (report-engine = read-only dataset builder → HTML→PDF via Playwright/Fake, USER_PRINT gate, empty-scope "no records", parity-on-data rule; **CSV flagged claimed-but-unbuilt** — grep found no emitter) + **exhaustive 255-.rpt catalog** classified into 13 domains (Accounting 45, Stock/Tag 39, Mfg 34, Sales 32, Purchase 16, Dhrn 15, Membership 14, Order 13, Tour/Bullion 11, Wholesale 11, Other 11, GST 7, Rojmel 7) each row → .rpt → web status → builder/route (≈46 dataset builders live in reports.ts/reports2-10.ts/voucherRegister.ts). Per-report field specs for 12 key reports (SaleReport, PurcReport, AcLedger, TRialBalHz, Gstr_1, Gstr_2, RojMelCash, TagStkRpt, ItmStkBalance, RP_DHRN_OS, MfgLedger, LbrWorkRpt) — purpose, filters, dataset SQL + scope, all_rpt_fields field lists w/ line cites, grouping/totals, builder mapping + parity. Flagged: CSV unbuilt, USER_PRINT gates PDF not dataset GET, metal/labour columns + interest accrual pending, MfgLedger MFG_ISU_REC-vs-KR_DETL source parity. |
| 2026-06-30 | Module 10 Membership/Loyalty documented: README (two-subsystem reconciliation — loyalty POINTS via POINT_MAST/POINT_MEMB/POINT_DATA + MS_POINT slabs, web membership.ts; member SAVING SCHEMES via AD_MAST/AD_MEMB/AD_DATA/AD_OS/AD_ADJ, web scheme.ts) + full 11-section TR_MEMB_ENT.md (scheme installment/opening ENT_TYPE E/O + AD_OS + balanced AC_DATA + UPI split, AND the loyalty earn/redeem engine: MS_POINT slab rules + TR_SALE POINT_DATA SR_NO 1 earn/2 redeem) + TR_MEMB_ADJ stub (Member Scheme Adjust → AD_ADJ maturity, payout=amt+bonus−less). Flagged the TR_MEMB_ENT name-trap (it is the scheme form, not the points form) and the earn/redeem SR_NO-vs-INOUT_TYPE modeling difference. Doc → 📋 SPEC; build 🟩 BUILT. |
| 2026-06-30 | Module 11 Bullion/Tour/VP documented: README (bullion booking/sale, fine sale/purchase, tour issue/order/sale, VP parcel/adjust, gold booking, branch/franchise in-out, other commission; flags VP & GOLD_BOOK semantics UNCERTAIN + the web fineInout.ts↔TR_FN_INOUT 'franchise vs fine' divergence) + full 11-section deep-dives TR_FINE_SL_PR.md (pure-metal trade priced on fine×FINE_RATE + rate-cut drawdown of PR_DETL.FINE_CUT_*; CUT_*/TAX_DATA/MAIN_STOCK) and TR_TOUR_SALE.md (sale engine + APR_DETL 'EMP ISU' approval drawdown) + 8 variant stubs (TR_BUL_SALE, TR_BUL_BOOKING✅, TR_TOUR✅, TR_TOUR_ORD, TR_VP⚠️, TR_VP_ADJ⚠️, TR_GOLD_BOOK⚠️, TR_FN_INOUT⚠️, TR_INOUT, TR_OTH_COMM). VP=Value-Payable Parcel & GOLD_BOOK=customer gold-accumulation derived from source and FLAGGED, not invented. Doc → 📋 SPEC; build stays 🟦 PARTIAL (booking/tour-issue/inout built; priced sale sides unbuilt). |
