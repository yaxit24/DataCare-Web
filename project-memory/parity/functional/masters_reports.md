# FUNCTIONAL PARITY — MASTERS + REPORTS + STATUTORY + SETTINGS/RBAC

**Agent:** masters_reports · **Date:** 2026-06-30 (refresh of `audit-E-statutory-reports-masters.md`, same day)
**Method:** FIELD/BUTTON/FLOW-level. Real `file:line` on both sides. Live DB READ-ONLY
(`PGPASSWORD=app psql -h127.0.0.1 -p5433 -U app_user -d datacare`, `app.tenant_id=default`).
**cwd:** `/Users/yakshitsavaliya/Desktop/imodule-extracted` (READ-ONLY). NO BLUFF — unconfirmed = CANNOT-VERIFY.
**Classification key:** OK = depth+breadth reproduced · DEPTH = form exists but loses fields/buttons/calc/flow · BREADTH = form/capability absent.

Desktop inventory (glob `extracted_code/DataCareNext/DataCareNext/`): **33 `MS_*.cs`**, **45 `RP_*.cs`** (was 44 in baseline — `RP_STOCK_VALUE.cs` now present), `UT_E_INVOICE.cs`, `UT_SETTING.cs`/`UT_SETTING_MAIN.cs`, `MS_USER.cs`.
Web inventory: `masters/configs.ts:130` MASTERS = **32 route keys** (incl `ac-groups`); report builders `reports.ts`+`reports2..10.ts`; **49 report/gst routes** wired in `routes/txn.ts` (grep `app.(get|post)('/(reports|gst)/` = 49) = **49 Reports-group nav links** (`web/lib/nav.ts`).

---

## REFRESH DELTAS vs baseline (audit-E)

| Change | Baseline | CURRENT | Evidence |
|---|---|---|---|
| **MS_AC_GROUP master** | GAP (not registered) | **REGISTERED** `ac-groups`→AC_GROUP (refs AC_MAST); table exists in DB | `configs.ts:122` AC_GROUP_CONFIG, `:162` `'ac-groups'`; `registry.test.ts` asserts 32-key list incl `ac-groups`; DB: AC_GROUP present |
| **e-invoice HSN/unit** | hardcoded `7113`/`GMS` | **master-driven** from ITEM_MAST.HSN_CODE/UNIT_NAME (fallback 7113/GMS) | `einvoice.ts:283` `hsn = im.HSN_CODE ‖ '7113'`; `:284` `unit = im.UNIT_NAME ‖ 'GMS'` |
| **RP_LC_SALE (location-wise sales)** | GAP | **COVERED** `location-wise-sales` | `reports9.ts:104` `locationWiseSales` (pivots SL_DATA by LC_CODE); route `txn.ts` |
| **RP_CUST_CRM** | PARTIAL (party-statement) | **COVERED** dedicated `customer-crm` | `reports9.ts:35` `customerCrm` |
| **+ new report endpoints** | — | `area-wise-sales`, `gst-input-register` | `reports9.ts:71`, `reports10.ts:113` |
| **RBAC rights writer** | read-only mapping | **`setUserRights`** persists USER_UPDATE/DELETE/PRINT(+CATG) | `rbac/users.ts setUserRights` |

Net: 2 baseline gaps closed (ac-groups master, location-wise-sales), 1 PARTIAL→COVERED (customer-crm), e-invoice HSN partial substantially closed. Remaining gaps below are still material.

---

## (1) MASTERS — which MS_* registered vs missing + field/column coverage

**Breadth (does the master exist):** 28 of 33 desktop `MS_*` are backed by a registered web master with a live table; 1 utility/company-open (`MS_OPNCOMP`→company select), 4 UI/utility (`MS_WINDOW_SET, MS_HELP, MS_UPDATE, MS_BOOKLIST`).

| Desktop MS_* | Web route / table | Verdict |
|---|---|---|
| MS_ACCT, MS_ITEM, MS_GROUP, MS_TAX, MS_RATE, MS_EMP, MS_PRODUCT, MS_LOCT, MS_DM, MS_POINT, MS_LBR_TYPE, MS_STYLE, MS_ADD_MAST, MS_COMPANY, MS_YEAR, MS_PRINT, MS_BOOK, MS_MFG_MAST | accounts/items/groups/taxes/rates/employees/products/locations/diamonds/points/labour/styles/addresses/companies/years/print-formats/books/mfg | OK (breadth) |
| **MS_AC_GROUP** | **`ac-groups`→AC_GROUP** (`configs.ts:122/162`) | **OK (NEW)** — but UI-nav gap (see below) |
| **MS_DESIGN_BOOK** | `designs`→DESIGN_MAST (DB ✓) | OK |
| **MS_GOLD_MAST** | `gold-rate`→DG_GOLD_MAST (DB ✓) | OK |
| MS_USER/MS_LOGIN | admin/users→LOGIN_MAST | OK (RBAC, see §5) |
| MS_MEMB | membership txn (not generic master) | DEPTH/PARTIAL |
| **MS_AUTO_ITEM** | — (table AUTO_ITEM absent in DB) | **BREADTH GAP** |
| **MS_TRADE** | — (table TRADE absent) | **BREADTH GAP** |
| **MS_STK_LIMIT** | — (table STK_LIMIT absent) | **BREADTH GAP** |
| **MS_TASTING** | — (table TASTING absent) | **BREADTH GAP** |

DB-verified absent: `AUTO_ITEM, TRADE, STK_LIMIT, TASTING` (no table, no route, no UI). `MS_AUTO_ITEM.cs`/`MS_TRADE.cs` confirmed real entry forms (AxMSFlexGrid grid + group-code entry).

**Depth (field/button/flow of the generic grid) — DEPTH GAP, applies to ALL registered masters:**
- Routes (`app.ts:204-253`): GET `:name`, GET `:name/meta`, POST `:name` (create), DELETE `:name`, POST `:name/import`. **There is NO PUT/PATCH — no in-place UPDATE.** `master.service.ts` exports `createMaster/listMaster/deleteMaster/importMaster` only (no `updateMaster`). To change a value you delete+recreate or re-import CSV. Desktop `MS_*` `BtnSave` does insert-OR-update in place.
- `listMaster` = `SELECT *` (full read), but the UI grid shows only the **first 9 columns** (`masters/[name]/page.tsx` `cols=…slice(0,9)`), and the **New form renders inputs for `requiredColumns` only** (`page.tsx:113` `meta.requiredColumns.map`). So manual create exposes just the business key + a couple required fields; non-required columns (e.g. TAX_MAST.TAX_PRC/ADD_TAX_PRC/TAX_AC) are only settable via **CSV import**, not the form.
- **No per-form validation/computation/print:** generic grid lacks MS_TAX tax-account linkage & add-tax handling, MS_ITEM/MS_RATE computed defaults, and the `BtnPrint` master print every `MS_*` form has.
- **UI-nav gap:** `nav.ts` Masters group = **31 links**; `ac-groups` (Account Groups) is registered + the generic `/masters/ac-groups` page would render it, but it is **not in the nav menu** (not user-discoverable yet). 30 derived masters (states/touch/messages/conversions/schemes/counters/item-weights/einvoice-gsp/franchise/models) have no `MS_*` source.

**Verdict: BREADTH GAP ×4 (auto-item, trade, stk-limit, tasting); DEPTH GAP on the generic grid (no update, partial create-form, no per-form validation/print); ac-groups breadth now OK (minor UI-nav gap).**

---

## (2) REPORTS — 45 desktop RP_* → 49 web endpoints

Refreshed tally (45 RP_*): **COVERED ≈ 14 · PARTIAL ≈ 13 · GAP ≈ 17.** (vs baseline 12/14/18 — RP_LC_SALE & RP_CUST_CRM upgraded.)

COVERED (register/ledger/balance/stock/GST families): RP_ALL→sales/purchase/return/voucher registers; RP_GST/RP_TAX→gstr1/gstr2/gstr3b/hsn-summary/gst-input-register; RP_LEDR/RP_BAL_ZOOM→account-ledger/balances; RP_BALANCE→trial-balance(-full)/balance-sheet; RP_CASH_BANK→cash-book/cash-day-summary; RP_DHRN_OS→dhrn-outstanding; RP_EMP→employee-sales; RP_INOUT/RP_STOCK/RP_STOCK_VALUE/RP_PHY_STOCK→item-stock-ledger/stock-valuation/item-group-stock; **RP_LC_SALE→location-wise-sales (NEW)**; **RP_CUST_CRM→customer-crm (NEW)**.

PARTIAL (exists but loses dimensions/columns/variants): RP_OS (addr/mobile/group cols absent), RP_MOVEMENT (web pivots item-only + area-wise-sales; karigar/emp/state/product multi-dim missing), RP_ROJMEL (estimate/item variants), RP_TAG/RP_TAG_ESTMATE (tag-detail), RP_STOCK_FINE, RP_STK_MOVE, RP_LC_INOUT, RP_DAY_WORK, RP_TRADING, RP_DHRN_LOAN (Form8/Form12 pawnbroker statutory forms missing), RP_REMINDER, RP_SLPR_ZOOM.

**GAP — 17 desktop reports with NO web equivalent:**
`RP_BILL_PROFIT` (bill-wise profit/margin), `RP_OTH_DETL` (other-item stud/loose diamond), `RP_ADDRESS` (address/phone labels), `RP_CONSI_APR` (consignment/approval register), `RP_MFG` (jadtar issue/receive), `RP_MFG_LEDR` (mfg ledger), `RP_MFG_ZOOM`, `RP_JDTR_ZOOM` (jadtar/diamond zoom), `RP_HUID` (HUID hallmark report), `RP_ORDER`, `RP_ORD_TRACK` (order tracking), `RP_TOUR_ZOOM` (tour/approval-sale), `RP_STK_LEVEL` (stock level/reorder), `RP_GRAPH` (charts), `RP_TAG_IMAGE` (tag image catalog), `RP_USER` (user-detail report), `RP_CUST` (customer last-visit, AcLastVisit.rpt). Plus statutory **pawnbroker Form8/Form12** (under RP_DHRN_LOAN, PARTIAL).

**Verdict: BREADTH GAP (17 reports) + DEPTH GAP (RP_MOVEMENT multi-dim pivot; RP_OS address/group columns).**

---

## (3) STATUTORY — GST returns + e-invoice IRN

**GST (routes):** `/gst/gstr1` (`txn.ts:604`→`gst.ts gstr1`), `/reports/gstr2` (`:452`), `/reports/gstr3b` (`:605`→`reports.ts:233`), `/reports/hsn-summary` (`:569`→`reports2.ts:102`), `/reports/gst-input-register` (`reports10.ts:113`).
- GSTR-1 does in-code bucketing B2B/B2CL/B2CS (`gst.ts classifyInvoice`, B2CL threshold 250000) over `SL_DATA⋈AC_MAST` — **OK** (web is more structured than desktop, which buckets in Crystal `.rpt`).
- **DEPTH gaps:** GSTR-3B = **outward summary only** (`reports.ts:233-250` sums SL_DATA taxable/CGST/SGST/IGST excl `'SRT'`; no inward/ITC/RCM/exempt sections); HSN summary uses **IT_CODE as HSN proxy** (`gst.ts summarizeHsn`, no HSN master); **no GSTN-portal JSON export** on either side.

**e-invoice IRN (`einvoice.ts`, `UT_E_INVOICE.cs`):**
- Payload `buildIrnPayload` models **6 sections** (`IrnPayload`: TranDtls/DocDtls/SellerDtls/BuyerDtls/ItemList/ValDtls) of NIC's 17 DTOs. Core item + ValDtls fields = PARITY; **cess(6)/batch/attrib/dispatch/ship/export/pay/ref/contract/addl-doc (11 optional sections) not modeled** (0 for domestic jewellery).
- **HSN/unit now master-driven** (`einvoice.ts:283-284` read ITEM_MAST.HSN_CODE incl. 9997-hallmark + UNIT_NAME, fallback 7113/GMS) — baseline hardcode **CLOSED** → **OK**.
- Transport `CharteredInfoIrnTransport` = identical GSP endpoints (`eivital/dec/v1.04/auth`, `eicore/dec/v1.03/Invoice`, prod/sandbox host switch) — PARITY. Persists `SL_DATA.IRN_NO/ACK_NO/ACK_DATE` + `E_DATA(IRN_NO,ACK_NO,ACK_DATE,QR_DATA)`.
- **e-Way Bill:** absent on BOTH sides (grep 0 hits desktop) — no divergence.
- **CANNOT-VERIFY:** real GSP round-trip (needs creds + outbound net; web ships FakeIrnTransport + real transport behind env).

**Verdict: GST returns PARTIAL/DEPTH (3B outward-only, HSN proxy, no portal JSON); e-invoice payload PARTIAL/DEPTH (6/17 sections) but HSN/unit + transport + persistence OK.**

---

## (4) SETTINGS — CO_SET coverage

- DB: `CO_SET` = **61 columns** (verified, single row/company).
- Web exposes **11** whitelisted keys (`settings.ts:13` SETTING_FIELDS: TAX_CODE, TAX_ROF, DHRN_INT_TYPE, DHRN_PRC, LOAN_INT_TYPE, INT_YEAR_DAYS, CASH_LIMIT, CUST_SMS, ADMIN_SMS, DUP_PRINT, LOCK_DATE), WHITELIST-enforced on write; `saveSettings` upserts the row.
- Desktop `UT_SETTING.cs:4903-5050` writes **~20+** operational flags (LBR_TYPE, RATE_PAR, SL_ROW_CHANGE, LBR_RATE_GEN, RATE_MAST_OPEN, OP_DHRN, HELP_SERCH, LDR_SUMM, REMINDER_OPEN, LBR_ROF, ITM_RATE_ROF, PURC_WITH_LBR, STK_RPT_TYPE, TOUCH_AUTO_SAVE, …) — most unported. Web adds a few not in UT_SETTING (DHRN_PRC, LOAN_INT_TYPE, INT_YEAR_DAYS, CASH_LIMIT, CUST_SMS, ADMIN_SMS, LOCK_DATE).

**Verdict: DEPTH GAP — 11 of 61 CO_SET columns editable; many desktop operational flags unported.**

---

## (5) RBAC — global per-user flags vs desktop per-form USER_SET

- **Web (global per-user):** `LOGIN_MAST` flags `USER_UPDATE/USER_DELETE/USER_PRINT` (Y/N) read by `rbac/users.ts listUsers`, written by `setUserRights` (+optional LOGIN_CATG). `policy.ts:14 can()` maps create/update→userUpdate, delete→userDelete, print→userPrint, read=always; `filterNav` prunes the nav tree by an allowed-form set; admin = LOGIN_CATG starts `'A'`.
- **Desktop (per-form):** `USER_SET` holds `FRM_VIEW/FRM_EDIT/FRM_DELETE/FRM_PRINT` keyed by USER_NAME+SUB_MENU (`MS_USER.cs:1339-1341`), with `MENU_DATA` SM_TYPE gating ('L','B','S','U','P','A') (`:1572-1596`). **`USER_SET` table EXISTS in the live DB (13 cols) but the web does NOT use it** — rights are flattened to 3 global-per-user flags.

**Verdict: DEPTH GAP — action taxonomy (edit/delete/print) matches, but per-form granularity (USER_SET.FRM_*) and SM_TYPE menu-type gating are not modeled; web rights are global per user.**

---

## SCORECARD (this agent's 5 areas)

| Area | Breadth | Depth | Verdict |
|---|---|---|---|
| Masters (registered) | OK (28/33 + ac-groups NEW) | no update / create-form=required-only / no per-form validation+print | **DEPTH GAP** |
| Masters (auto-item/trade/stk-limit/tasting) | absent (no table/route/UI) | — | **BREADTH GAP ×4** |
| Reports | 17 RP_* missing | RP_MOVEMENT multi-dim & RP_OS columns lost | **BREADTH + DEPTH GAP** |
| GST returns | present | 3B outward-only, HSN=IT_CODE proxy, no portal JSON | **DEPTH/PARTIAL** |
| e-invoice IRN | present | 6/17 NIC sections; HSN/unit+transport+persist now OK | **DEPTH/PARTIAL (improved)** |
| Settings | present | 11/61 CO_SET cols | **DEPTH GAP** |
| RBAC | present | global-per-user vs per-form USER_SET | **DEPTH GAP** |

## CANNOT-VERIFY
- Exact numeric tie-out of Crystal `.rpt` figures vs web JSON (rpt layouts out of scope).
- Real GSP IRN round-trip (external blocker: creds + outbound network).
- Whether desktop ever emits IRN SupTyp ≠ B2B (default B2B; full TR_SL_EBILL flow not exhaustively traced).
