# AUDIT_E — Independent Parity Audit: Statutory + Reports + Masters + RBAC/Utilities

**Scope:** DataCareNext desktop (C#/WinForms, decompiled) vs Web (Fastify API + Next.js).
**cwd:** `/Users/yakshitsavaliya/Desktop/imodule-extracted`
**Method:** Real `file:line` citations on BOTH sides; DB cross-checked via `docker exec web-postgres-1 psql -U datacare -d datacare`. Unconfirmed claims marked **CANNOT-VERIFY**. NO BLUFF.
**Date:** 2026-06-30

Desktop inventory (globbed): **44 `RP_*.cs`**, **33 `MS_*.cs`**, **17 `Cls*Dtls/ItemList`** IRN payload DTOs.
Web inventory: report builders in `reports.ts`+`reports2..8.ts`+`voucherRegister.ts`; **45** report routes wired in `routes/txn.ts`; **31** master routes in `masters/configs.ts`.
DB: **164** public tables; all report source tables present (`SL_DATA,SL_DETL,PR_DATA,AC_DATA,BILL_OS_DATA,MAIN_STOCK,BAR_DETL,E_DATA,KR_DETL,DHRN_ISU_DATA,SL_DETL_RTN,AD_ADJ,RATE_MAST`).

---

## MAIN VERDICT TABLE

| # | Dimension | Verdict | Desktop evidence (file:line) | Web evidence (file:line) | Note |
|---|-----------|---------|------------------------------|---------------------------|------|
| 1 | e-invoice IRN payload | **PARTIAL** | `ClsItemList.cs` (24 item fields), `ClsTranDtls.cs:10` (TaxSch GST/SupTyp B2B), `ClsValDtls.cs`, `ClsDocDtls.cs`; `TR_SL_EBILL.cs:9189` (HsnCd=HSN_CODE), `:9169` (UNIT_NAME), `:9556-9558` (HSN 7113/9997) | `einvoice.ts:116` (TranDtls GST/B2B/N/N), `:63` payload shape, `:92` HsnCd, `:95` Unit GMS, `submitIrnForSale` hardcodes `hsn:'7113'`/`unit:'GMS'` | Core payload + transport PARITY; sale-loader hardcodes HSN/unit; 11/17 optional NIC sections not modeled |
| 2 | e-way / e-bill (TR_SL_EBILL) | **PARITY (by absence)** | `TR_SL_EBILL.cs:36` is the **IRN e-invoice** form (`:29` Newtonsoft.Json, `:30` QRCoder, `:183` btnIrnGen). **No e-way bill** anywhere (grep EwbNo/EwbDt/GenEwb/VehNo/TransMode = 0 hits) | No e-way module exists web-side either | "EBILL"=electronic invoice (=row 1). e-Way Bill absent on BOTH → no divergence |
| 3 | GST returns GSTR-1/3B | **PARTIAL** | `RP_GST.cs:1139` (Gstr 1), `:1746` (Gstr_2.RPT), `:2084` (SlTaxRpt); classification done downstream in Crystal `.rpt` (no in-code B2B/B2C) | `gst.ts:44-45` (B2B/B2CL in-code), `:12` B2CL=250000, `:78` HSN via IT_CODE proxy; `reports.ts gstr3b` (SL_DATA outward, excl 'SRT') | Same SL_DATA/AC_MAST GSTIN source; web adds explicit buckets (parity+). PARTIAL: HSN uses IT_CODE proxy, no portal-JSON export |
| 4 | **REPORT COVERAGE (44 vs 45)** | **PARTIAL** | 44 `RP_*.cs` (see sub-table) | 45 routes `txn.ts` `/reports/*`; `nav.ts` Reports group = 45 | **12 COVERED / 14 PARTIAL / 18 GAP**. 18 desktop reports have NO web equivalent (most important gap dimension) |
| 5 | Report column/total (RP_OS, RP_MOVEMENT, RP_GST) | **PARTIAL** | `RP_OS.cs:3501` (AC_NAME/AC_GR_NAME/AC_AREA/AC_ADD1/AC_CITY/AC_MOBILE), `:3763/3854/3946`; `RP_MOVEMENT.cs:2746-2872` (pivot by AC/karigar/emp/city/state/area/product) | `reports.ts outstandingReport` (acCode/party/balance/type); `reports6.ts areaOutstanding`; `reports2.ts itemStockLedger` (by IT_CODE only) | RP_OS: balance+receivable/payable+area present; address/mobile/group cols missing. RP_MOVEMENT: web pivots by item only (multi-dim GAP). RP_GST: parity |
| 6 | Masters field coverage + count (33 vs 31) | **PARTIAL** | 33 `MS_*.cs`; `MS_TAX.cs:31-61` (TaxCode/Name/Prc/AcCode/AddTaxPrc); AC_GROUP cols (`MS_YEAR.cs:1511`) | `configs.ts:122` MASTERS (31 keys); `master.service.ts listMaster` `SELECT *` generic grid | Generic grid exposes ALL columns of registered masters (full field coverage). **AC_GROUP (account groups) NOT registered = GAP**; +4 more GAPs |
| 7 | RBAC rights model (MS_USER) | **PARTIAL** | `MS_USER.cs:1339-1341` (USER_SET.FRM_EDIT/FRM_DELETE/FRM_PRINT **per-form**), `:1572-1596` (per SUB_MENU, MENU_DATA SM_TYPE filter) | `policy.ts:14-26` can() (userUpdate/Delete/Print, read open), filterNav; `users.ts` LOGIN_MAST USER_UPDATE/DELETE/PRINT (**global**) | Same 3 action flags (edit/delete/print) + nav filter; web flattens per-form→global. Per-form granularity is the gap |
| 8 | Settings field coverage (UT_SETTING) | **PARTIAL** | `UT_SETTING.cs:4903-5050` writes ~20+ CO_SET flags (LBR_TYPE,RATE_PAR,TAX_ROF,SL_ROW_CHANGE,LBR_RATE_GEN,RATE_MAST_OPEN,OP_DHRN,DHRN_INT_TYPE,HELP_SERCH,LDR_SUMM,REMINDER_OPEN,LBR_ROF,ITM_RATE_ROF,PURC_WITH_LBR,STK_RPT_TYPE,TOUCH_AUTO_SAVE…) | `settings.ts:13` SETTING_FIELDS=**11 keys**, `:26` WHITELIST enforced | DB: CO_SET=**61** cols. Web whitelists 11/61; desktop UT_SETTING edits ~20+. Web adds DHRN_PRC/LOAN_INT_TYPE/INT_YEAR_DAYS/CASH_LIMIT/CUST_SMS/ADMIN_SMS/LOCK_DATE not in UT_SETTING grep |
| 9 | Reminders (UT_REMINDER) | **PARTIAL** | `UT_REMINDER.cs:984` "Reminder Entry" (manual entry form); `RP_REMINDER.cs:4106/4110` (ReminderSchm/ReminderAll Crystal) | `ops/reminders.ts` overdueReminders (BILL_OS_DATA), birthdayReminders (AC_MAST BR_DATE/L_BR_DATE/AN_DATE), sendReminder (WA/SMS) | Different models: web auto-derives overdue+birthday & can send; desktop = manual reminder entry + scheme/all reminder reports |

---

## DETAILED FINDINGS

### (1) e-invoice IRN payload — PARTIAL
Desktop builds the **full NIC v1.1 schema** via 17 DTO classes (`ClsTranDtls, ClsDocDtls, ClsSellerDtls, ClsBuyerDtls, ClsDispDtls, ClsShipDtls, ClsItemList, ClsValDtls, ClsPayDtls, ClsRefDtls, ClsExpDtls, ClsContrDtls, ClsAddlDocDtls, ClsPrecDocDtls, ClsDocPerdDtls, ClsAttribDtls, ClsBchDtls`). Web models **6** sections (`TranDtls, DocDtls, SellerDtls, BuyerDtls, ItemList, ValDtls`).

**Field-by-field (item):** `ClsItemList.cs` fields = SlNo, PrdDesc, IsServc, HsnCd, Qty, FreeQty, Unit, UnitPrice, TotAmt, Discount, PreTaxVal, AssAmt, GstRt, IgstAmt, CgstAmt, SgstAmt, **CesRt, CesAmt, CesNonAdvlAmt, StateCesRt, StateCesAmt, StateCesNonAdvlAmt**, OthChrg, TotItemVal, **PrdSlNo, BchDtls, AttribDtls**. Web `einvoice.ts:84-103` item = SlNo, PrdDesc, IsServc, HsnCd, Qty, FreeQty, Unit, UnitPrice, TotAmt, Discount, PreTaxVal, AssAmt, GstRt, IgstAmt, CgstAmt, SgstAmt, OthChrg, TotItemVal. → **All core fields PARITY**; web omits cess(6)/batch/attrib/prdSlNo (0 for domestic jewellery).
**TranDtls:** desktop `ClsTranDtls.cs:11-14` TaxSch=GST, SupTyp=B2B, RegRev=N, IgstOnIntra=N (+EcmGstin) ≡ web `einvoice.ts:116`. **PARITY.**
**ValDtls:** desktop AssVal/CgstVal/SgstVal/IgstVal/CesVal/StCesVal/Discount/OthChrg/RndOffAmt/TotInvVal/TotInvValFc ≡ web AssVal/Cgst/Sgst/Igst/Discount/OthChrg/RndOffAmt/TotInvVal (omits Ces/StCes/Fc). **PARITY core.**
**B2B gate:** web throws if no buyer GSTIN (`einvoice.ts:79`); desktop default SupTyp=B2B. **PARITY.**
**HSN:** desktop reads per-item `ITEM_MAST.HSN_CODE` (`TR_SL_EBILL.cs:9189`), defaulting gold/silver→7113, hallmark 'HM'→9997 (`:9556-9558`). Web `buildIrnPayload` accepts per-item `hsn` (`:92`) but `submitIrnForSale` **hardcodes `hsn:'7113'`** for every line (`einvoice.ts:275`). → **PARTIAL** (correct for the dominant gold/silver case; loses 9997-hallmark/service differentiation).
**Unit:** desktop reads `ITEM_MAST.UNIT_NAME` (`:9169`); web defaults `'GMS'` (`:95`) and `submitIrnForSale` hardcodes `unit:'GMS'` (`einvoice.ts:275`). → **PARTIAL** (GMS correct for jewellery).
**Transport:** desktop GSP = Chartered Info: auth `eivital/dec/v1.04/auth` (`:9493`), IRN `eicore/dec/v1.03/Invoice` (`:9308`), prod `einvapi.charteredinfo.com` / sandbox `gstsandbox.charteredinfo.com`. Web `CharteredInfoIrnTransport` uses the **identical** endpoints (`einvoice.ts:229,219` + host switch). → **PARITY.**
**Persistence:** web stores IRN to `SL_DATA` + `E_DATA(IRN_NO,ACK_NO,ACK_DATE,QR_DATA)` (`einvoice.ts:196`); DB confirms `E_DATA` has all 4 cols. **PARITY.** Real GSP submission is an external blocker (creds) on both sides; web ships a deterministic FakeIrnTransport + unit-tested pure builder.

### (2) e-way / e-bill — PARITY (by absence)
`TR_SL_EBILL.cs` is the **sales + IRN (e-invoice / "e-bill") generation** form, covered under (1). Exhaustive grep for e-Way Bill markers (`EwbNo|EwbDt|EwbValidTill|GenEwb|ewaybill|EwayBill|TransMode|VehNo|/ewb/`) returns **0 matches** across the entire `DataCareNext` tree — the desktop has **no e-Way Bill**. The web likewise has none. No divergence to score; flagged so it is not mistaken for a web gap.

### (3) GST returns — PARTIAL
Desktop `RP_GST.cs` exposes Gstr-1/2/3 buttons (`:1139` "Gstr 1", `:1298` "Gstr 3", `:1324` "Gstr 2") feeding Crystal reports `SlTaxRpt` (sales tax, `:2084`), `PrTaxRpt` (purchase, `:1742`), `Gstr_2.RPT` (`:1746`); B2B/B2C/HSN bucketing happens in the `.rpt`/GST-portal offline tool, **not in code**. Web `gst.ts` implements bucketing **in code**: `classifyInvoice` B2B(has GSTIN)/B2CL(interState & >250000)/B2CS (`:44-45,12`), `summarizeB2CS`, `summarizeHsn`, `buildGstr1`, live `gstr1` over `SL_DATA⋈AC_MAST(AC_GSTNO,AC_STATE)`; `reports.ts gstr3b` sums outward SL_DATA (excl book 'SRT'). Same data basis, web is more structured. **PARTIAL** only because HSN summary uses `IT_CODE` as HSN proxy (`gst.ts:78`, no dedicated HSN master — self-flagged Task 30) and neither side emits the GSTN portal JSON.

### (5) Sampled report column/total correctness
- **RP_OS (Outstanding)** — `RP_OS.cs` modes `AcGroupRpt` (`:3763`), `AcOsWithAdd` (`:3854`), `AcOsArea` (`:3946`); picker columns AC_NAME, AC_CODE, **AC_GR_NAME (group), AC_AREA, AC_ADD1, AC_CITY, AC_MOBILE, MAIN_AC_CODE** (`:3501-3509`). Web `outstandingReport` = acCode, party, balance(ΣDR−ΣCR), type(Receivable/Payable); `areaOutstanding` = city, area, bills, balance; `billOutstanding` = party/bills/billed/received/balance. → **PARTIAL**: balance + receivable/payable classification + area pivot present; **address/mobile/account-group-name columns absent**, and the "with-address" label variant has no web form.
- **RP_MOVEMENT (Stock Movement)** — `RP_MOVEMENT.cs:2746-2872` pivots `MAIN_STOCK` (ITM_SIGN filter) by **AC_CODE / KR_NAME(karigar) / EMP_CODE / AC_CITY / AC_STATE / AC_AREA / PR_CODE**, columns Code, Name, Qty=SUM(1), Pcs=ΣITM_PCS, ΣITM_NWT, ΣITM_FINE. Web `itemStockLedger` groups MAIN_STOCK by **IT_CODE only** (inFine/outFine/netFine/inPcs/outPcs/moves). → **PARTIAL**: web has richer +/− direction split but **only one dimension (item)**; the 7-way movement pivot (salesman/karigar/area/state/product) is a **GAP**.
- **RP_GST** — see (3): aggregation basis matches; **PARITY** on the figures, web HSN proxy noted.

### (6) Masters — PARTIAL
Web uses a **declarative generic grid** (`master.service.ts`: `createMaster/listMaster(SELECT *)/deleteMaster`, key/required/reference config). `listMaster` returns `SELECT *`, so **all columns** of a registered master are exposed/editable — DB confirms `TAX_MAST` carries TAX_CODE, TAX_NAME, TAX_PRC, ADD_TAX_PRC, TAX_AC, TAX_GROUP, SR_NO, matching `MS_TAX.cs:31-61` controls (tTaxCode, tTaxName, nTaxPrc, tTaxAcCode, nAddTaxPrc). So **field coverage = full for registered masters**, but the generic grid lacks per-form validation/computed behavior (e.g. tax-account linkage, add-tax handling).
**Count:** 33 desktop `MS_*` vs 31 web master routes (30 distinct tables; `accounts`+`customers`→AC_MAST). Mapping (sub-table below): **22 COVERED, 2 PARTIAL, 5 GAP, 4 N/A(utility)**.
**Headline GAP:** `MS_AC_GROUP` (account-group master: AC_GR, AC_GR_NAME, AC_MAIN_GR, AC_SUB_GR — DB-confirmed table) is **NOT registered** in `configs.ts MASTERS` (`groups`→GROUP_MAST is the *item/metal* group, a different table). Account groups are read-only-consumed by `reports3.ts groupSummary` but have **no editable web master**.

### (7) RBAC — PARTIAL
Desktop: per-user **per-form** rights in `USER_SET` (DB cols FRM_VIEW, FRM_EDIT, FRM_DELETE, FRM_PRINT) keyed by USER_NAME + SUB_MENU, read at `MS_USER.cs:1339-1341`, with dynamic menu materialization joining `MENU_DATA` filtered by `SM_TYPE` ('L','B','S','U','P','A') (`:1572-1596`). Web: per-user **global** flags in `LOGIN_MAST` (DB cols USER_UPDATE, USER_DELETE, USER_PRINT) → `policy.can()` maps create/update→userUpdate, delete→userDelete, print→userPrint, read always (`policy.ts:14-26`); `filterNav` prunes the nav tree by an allowed-form set; admin = LOGIN_CATG starts 'A'. **Action taxonomy matches (edit/update, delete, print)**; the **per-form granularity** (each form's own FRM_* flags) and SM_TYPE menu-type gating are **not modeled** — web rights are global per user.

### (8) Settings — PARTIAL
DB: `CO_SET` = **61 columns** (single row/company). Web exposes a curated **11-key** whitelist (`settings.ts:13`) strictly enforced on write (`:26` WHITELIST). Desktop `UT_SETTING.cs:4903-5050` edits **~20+** behavior flags (LBR_TYPE, RATE_PAR, TAX_ROF, SL_ROW_CHANGE, LBR_RATE_GEN, RATE_MAST_OPEN, OP_DHRN, DHRN_INT_TYPE, HELP_SERCH, LDR_SUMM, REMINDER_OPEN, LBR_ROF, ITM_RATE_ROF, PURC_WITH_LBR, STK_RPT_TYPE, TOUCH_AUTO_SAVE, DUP_PRINT, …). Overlap is partial both ways: TAX_CODE, TAX_ROF, DHRN_INT_TYPE, DUP_PRINT common; web-only = DHRN_PRC, LOAN_INT_TYPE, INT_YEAR_DAYS, CASH_LIMIT, CUST_SMS, ADMIN_SMS, LOCK_DATE (not seen in the UT_SETTING write grep). Net: **11/61 columns surfaced**; many desktop operational flags unported.

### (9) Reminders — PARTIAL
Desktop `UT_REMINDER.cs` = manual "Reminder Entry" form (`:984`); reminder *reports* are `RP_REMINDER.cs` ReminderSchm / ReminderAll (`:4106/4110`). Web `ops/reminders.ts` auto-derives **overdueReminders** (BILL_OS_DATA net balance + party mobile + days overdue), **birthdayReminders** (AC_MAST BR_DATE/L_BR_DATE/AN_DATE month-day match) and **sendReminder** (WhatsApp/SMS). Web covers the *auto* dunning + occasion use-cases (superset there) but lacks the desktop's *manual reminder entry/scheduling*.

---

## REPORT-COVERAGE SUB-TABLE (44 desktop `RP_*.cs` → web status)

| Desktop RP_*.cs | Purpose (Crystal .rpt / RptName) | Web equivalent | Status |
|---|---|---|---|
| RP_ALL.cs | Universal register launcher — SaleReport/SaleRtnReport/Purchase… (`:7520-7540`, 207 .rpt refs) | sales-register, purchase-register, sales-return-register, purchase-return-register, voucher-register | COVERED |
| RP_GST.cs | GSTR-1/2/3 (SlTaxRpt/Gstr_2) `:1139,1746` | /gst/gstr1, /reports/gstr2, /reports/gstr3b | COVERED |
| RP_TAX.cs | Sales/Purchase tax (SlTaxRpt/PrTaxRpt/InTax_PurcRpt) `:1954,2017,2080` | hsn-summary, sales-gst-monthly, gstr2 | COVERED |
| RP_LEDR.cs | Account ledger (JmUdAmt/AcSummLdr/AcWithWtSumm) `:4050,6179,6256` | account-ledger, party-statement | COVERED |
| RP_BAL_ZOOM.cs | Balance zoom (BalZoom/AcSummLdr) `:4712,4785` | account-balances | COVERED |
| RP_BALANCE.cs | Trial Bal / P&L / Balance (TRialBalhz/ProfitLossHz/BalanceHz) `:2314,2421,2469` | trial-balance, trial-balance-full, balance-sheet | COVERED (P&L statement partial) |
| RP_CASH_BANK.cs | Cash/Bank + scheme passbook (SchmPassBook/AcLedger) `:3522,3570` | cash-book, cash-day-summary | COVERED |
| RP_DHRN_OS.cs | Pledge due/outstanding (DharnDue) `:3475` | dhrn-outstanding | COVERED |
| RP_EMP.cs | Employee summary (EmpDaySumm/EmpSumm) `:3890,3894` | employee-sales | COVERED |
| RP_INOUT.cs | Item stock in/out (ItmStkWithGrid/ItmStkBalance) `:3431,3440` | item-stock-ledger | COVERED |
| RP_STOCK.cs | Item stock (ItmStkWithGrid/SafeStkSumm) `:4071,4162` | stock-valuation, item-group-stock | COVERED |
| RP_PHY_STOCK.cs | Physical stock (TagStkRpt) `:1860` | stock-valuation (physical-reconcile=txn) | COVERED |
| RP_OS.cs | Outstanding by group/area/address (AcGroupRpt/AcOsWithAdd/AcOsArea) `:3763,3854,3946` | outstanding, area-outstanding, bill-outstanding | PARTIAL (addr/mobile/group cols missing) |
| RP_MOVEMENT.cs | Stock movement pivot AC/karigar/emp/city/state/area/product `:2746-2872` | item-stock-ledger (item-only) | PARTIAL (multi-dim pivot GAP) |
| RP_ROJMEL.cs | Day book (RojMelCrDr/RojMelItem/RojMelEstmat) `:3095,3315,3475` | day-book | PARTIAL (item/estimate variants) |
| RP_TAG.cs | Tag stock (TagStkRpt/TagStkIdtlRpt) `:8575,8612` | stock-valuation, stock-by-location | PARTIAL (tag-detail variants) |
| RP_TAG_ESTMATE.cs | Tag stock estimate (TagStkRpt/TagStkSummRpt) `:4595,4621` | stock-valuation | PARTIAL |
| RP_STOCK_FINE.cs | Stock fine (dynamic .rpt) `:2724` | stock-valuation (fine col) | PARTIAL |
| RP_STK_MOVE.cs | Stock move | item-stock-ledger | PARTIAL |
| RP_LC_INOUT.cs | Location in/out | stock-by-location | PARTIAL |
| RP_DAY_WORK.cs | Daily work summary | daily-sales | PARTIAL |
| RP_TRADING.cs | Trading account (AcLedger) `:2531` | balance-sheet (closingStock derived) | PARTIAL (explicit trading a/c) |
| RP_CUST_CRM.cs | Customer CRM/ledger (AcLedger/JmUdAmt) `:3325,3443` | party-statement | PARTIAL (CRM features) |
| RP_DHRN_LOAN.cs | Pledge register + statutory (DhrnKhataVahi/Form8/Form12/DhiranReg) `:2563-2778` | dhrn-outstanding | PARTIAL (Form8/Form12 pawnbroker forms GAP) |
| RP_REMINDER.cs | Reminder reports (ReminderSchm/ReminderAll) `:4106,4110` | utilities/reminders (not /reports) | PARTIAL |
| RP_SLPR_ZOOM.cs | Sales/purchase drill-down zoom | (data in registers) | PARTIAL |
| RP_BILL_PROFIT.cs | Bill-wise profitability/margin | — | **GAP** |
| RP_OTH_DETL.cs | Other-item stud/loose diamond detail (OthItmStud/OthItmLoose) `:3354,3666` | — | **GAP** |
| RP_ADDRESS.cs | Address/phone labels (TempAdd2/TempPhone/TempAdd3) `:3333,3500,3529` | — | **GAP** |
| RP_CONSI_APR.cs | Consignment/approval register (AcLedger/JmUdAmt) `:2386,2551` | — | **GAP** |
| RP_MFG.cs | Mfg jadtar issue/receive (JadtarIssue/JadtarRec/JdtProcessRec) `:1785,1834,1838` | — | **GAP** |
| RP_MFG_LEDR.cs | Manufacturing ledger (MfgLedger) `:3121` | — | **GAP** |
| RP_MFG_ZOOM.cs | Manufacturing zoom | — | **GAP** |
| RP_JDTR_ZOOM.cs | Jadtar/diamond zoom | — | **GAP** |
| RP_HUID.cs | HUID hallmark-ID report (TagHuIdRpt) `:2217` | — | **GAP** |
| RP_ORDER.cs | Order report (JmUdAmt) `:3846` | — | **GAP** |
| RP_ORD_TRACK.cs | Order tracking (AcLedger/JmUdAmt) `:3459,3598` | — | **GAP** |
| RP_TOUR_ZOOM.cs | Tour/approval-sale report | — | **GAP** |
| RP_LC_SALE.cs | Location-wise sales | — | **GAP** |
| RP_STK_LEVEL.cs | Stock level / reorder | — | **GAP** |
| RP_GRAPH.cs | Graphical/chart report | — (dashboard ≠ parity) | **GAP** |
| RP_TAG_IMAGE.cs | Tag image / catalog report | — | **GAP** |
| RP_USER.cs | User detail report (UserDtlRpt) `:3549` | — | **GAP** |
| RP_CUST.cs | Customer last-visit (AcLastVisit) `:1506` | — | **GAP** |

**Report-coverage tally: COVERED=12, PARTIAL=14, GAP=18 (of 44).**
NB: the web's 45 routes are more *granular endpoints* than desktop files (desktop consolidates many into RP_ALL + zoom forms), so this is a capability map, not a 1:1 file count. The 18 GAPs above are desktop report capabilities with **no web equivalent**.

---

## MASTERS SUB-TABLE (33 desktop `MS_*.cs` → web status)

| Desktop MS_* | Table | Web master route | Status |
|---|---|---|---|
| MS_ACCT | AC_MAST | accounts/customers | COVERED |
| MS_ITEM | ITEM_MAST | items | COVERED |
| MS_GROUP | GROUP_MAST | groups | COVERED |
| MS_TAX | TAX_MAST | taxes | COVERED |
| MS_RATE | RATE_MAST | rates | COVERED |
| MS_EMP | EMP_MAST | employees | COVERED |
| MS_PRODUCT | PRODUCT_MAST | products | COVERED |
| MS_LOCT | LOCT_MAST | locations | COVERED |
| MS_DESIGN_BOOK | DESIGN_MAST | designs | COVERED |
| MS_DM | DM_MAST | diamonds | COVERED |
| MS_POINT | POINT_MAST | points | COVERED |
| MS_LBR_TYPE | LBR_MAST | labour | COVERED |
| MS_STYLE | COL_MAST | styles | COVERED |
| MS_ADD_MAST | ADD_MAST | addresses | COVERED |
| MS_COMPANY | CO_MAST | companies | COVERED |
| MS_YEAR | YEAR_MAST | years | COVERED |
| MS_GOLD_MAST | DG_GOLD_MAST | gold-rate | COVERED |
| MS_PRINT | PRINT_MAST | print-formats | COVERED |
| MS_BOOK | BOOK_DATA | books | COVERED |
| MS_MFG_MAST | MFG_MAST | mfg | COVERED |
| MS_USER / MS_LOGIN | LOGIN_MAST | admin/users (RBAC) | COVERED |
| MS_MEMB | MEMB_MAST | txn/membership (not generic master) | PARTIAL |
| MS_BOOKLIST | book list | (subsumed by books) | PARTIAL |
| **MS_AC_GROUP** | **AC_GROUP** | **— (only item-GROUP_MAST registered)** | **GAP** |
| MS_AUTO_ITEM | AUTO_ITEM | — | **GAP** |
| MS_TRADE | TRADE | — | **GAP** |
| MS_STK_LIMIT | STK_LIMIT | — | **GAP** |
| MS_TASTING | (assay/testing) | — | **GAP** |
| MS_WINDOW_SET | UI prefs | — | N/A (utility) |
| MS_OPNCOMP | company-open | company select | N/A (utility) |
| MS_HELP | help content | — | N/A (utility) |
| MS_UPDATE | software update | — | N/A (utility) |

**Masters tally: COVERED=22, PARTIAL=2, GAP=5, N/A=4 (of 33).**
Web also adds 9 masters with no `MS_*` source form (derived from schema): states(STATE_MAST), touch(TOUCH_MAST), messages(MSG_MAST), conversions(CONV_MAST), schemes(AD_MAST), counters(TABLE_MAST), item-weights(ITM_WT_MAST), einvoice-gsp(E_MAST), franchise-accounts(FAN_AC_MAST).

---

## GAPS FOUND (consolidated, prioritized)

1. **18 desktop reports have NO web equivalent** (dimension 4, most important): bill-profit, other-item stud/loose, address/phone labels, consignment/approval, mfg jadtar issue/receive, mfg ledger, mfg zoom, jadtar zoom, HUID, order, order-tracking, tour, location-sales, stock-level/reorder, graph/charts, tag-image catalog, user report, customer last-visit. Plus statutory **pawnbroker Form8/Form12** (RP_DHRN_LOAN).
2. **RP_MOVEMENT multi-dimensional stock-movement pivot** (by salesman/karigar/area/state/product) unported — web has item-only stock ledger.
3. **MS_AC_GROUP (account-group master) not registered** — account groups (AC_GR/AC_MAIN_GR/AC_SUB_GR) are read-consumed by reports but not editable in web. +4 master GAPs (auto-item, trade, stk-limit, tasting).
4. **e-invoice:** `submitIrnForSale` hardcodes HSN 7113 + unit GMS (loses 9997-hallmark/service HSN & true UNIT_NAME); 11/17 NIC payload sections (cess, batch, attrib, dispatch, ship, export, pay, ref, contract, addl/prec doc, doc-period) not modeled.
5. **RBAC granularity:** web rights are global-per-user (LOGIN_MAST) vs desktop per-form (USER_SET.FRM_*); SM_TYPE menu-type gating absent.
6. **Settings:** only 11 of 61 CO_SET columns surfaced; many operational flags (LBR_TYPE, RATE_PAR, SL_ROW_CHANGE, STK_RPT_TYPE, TOUCH_AUTO_SAVE, …) unported.
7. **GST:** HSN summary uses IT_CODE proxy (no HSN master); no GSTN-portal JSON export.
8. **RP_OS columns:** address/mobile/account-group-name not in web outstanding reports.
9. **Reminders:** manual reminder-entry (UT_REMINDER) unported (web is auto overdue/birthday only).
10. **e-Way Bill:** absent on BOTH sides (not a web regression — flagged for completeness).

## CANNOT-VERIFY
- Exact numeric tie-out of RP_OS / RP_MOVEMENT / RP_GST Crystal `.rpt` outputs vs web JSON (the `.rpt` layout files were not in scope; comparison is by SQL source + grid columns, not rendered figures).
- Whether the desktop ever emits SupTyp other than B2B for IRN (default is B2B; no B2C branch observed but full 9621-line `TR_SL_EBILL` flow not exhaustively traced).
- Real GSP IRN round-trip on both sides (external blocker: GSP credentials + outbound network).

---

## AUDIT_E VERDICT: parity=1 partial=8 gap=0 cannot-verify=0

(9 primary dimensions scored. parity=1 [e-way/e-bill by absence]; partial=8 [e-invoice payload, GST returns, report coverage, sampled columns, masters, RBAC, settings, reminders]; no dimension is a total web blank, but item-level GAPs are material — **18/44 reports** and **5/33 masters** have no web equivalent, headlined by the unported account-group master and the multi-dimensional stock-movement pivot.)
