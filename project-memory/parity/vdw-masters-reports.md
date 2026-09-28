# Desktop ↔ Web Parity — MASTERS + REPORTS (VDW module)

Scope: Party (MS_ACCT), Item/Group/Product (MS_ITEM / MS_GROUP / MS_PRODUCT), and 3 key reports
(Ledger RP_LEDR, Stock RP_STOCK/RP_TAG, GST RP_GST/Gstr_1). **Read-only verification — no code changed.**

Ground truth (desktop):
- Video-research KB (`851f2afc-...`): `_kb/KB_master.md`, `_kb/KB_transaction.md`, `_kb/KB_other.md`
- Behavior catalogs: `project-memory/catalogs/form-behavior/{MS_ACCT,MS_ITEM,MS_GROUP,MS_PRODUCT,RP_LEDR,RP_GST,RP_TAG,RP_STOCK}.behavior.json`
- Report layouts: `project-memory/catalogs/report-layouts/{AcLedger,Gstr_1}.spec.json`

Web implementation:
- `web/apps/web/app/(app)/masters/party/page.tsx`, `masters/[name]/page.tsx`, `reports/tag-stock/page.tsx`, `reports/[report]/page.tsx`
- `web/apps/api/src/modules/masters/{master.service.ts,configs.ts}`, `reports/{reports.ts,reports2.ts,tagStock.ts}`, `accounting/accounting.ts`, `gst/gst.ts`
- routes: `web/apps/api/src/routes/txn.ts`

Legend: **Match** = field/behavior faithfully reproduced · **Partial** = present but reduced/renamed/moved · **Gap** = absent.

---

## 1 · Party Master (MS_ACCT)

Two web surfaces exist and must be read together:
- **`/masters/party`** — dedicated page, tabs **Details · Photo · Family · Opening**, but the Details tab captures only 5 columns. It POSTs `{CO_CODE, AC_CODE, AC_NAME, AC_KHATA_NO, AC_MOBILE, AC_GR}` to `/masters/customers` (evidence: `masters/party/page.tsx` `save()` → `post('/masters/customers', {...})`).
- **`/masters/customers` (alias `/masters/accounts`)** via generic `masters/[name]/page.tsx` — renders the full `AC_MAST_CONFIG.formFields` (40 fields) grouped into heuristic tabs.

Desktop field list is the `INSERT INTO AC_MAST(...)` column set in `MS_ACCT.behavior.json`; tabs + opening balance from `KB_master.md §3` / `KB_transaction.md §4.2` ("*tabs `Company Detail · Other Detail · Family Detl`*"; "*Opening Balance (Amount/Gold/Silver, each Cr/Dr)*").

### 1a. Fields

| Desktop (AC_MAST column) | Web `AC_MAST_CONFIG.formFields` | Status | Evidence / Note |
|---|---|---|---|
| AC_CODE / AC_NAME | `AC_CODE`, `AC_NAME` | Match | both, required |
| AC_GR (group) / AC_MAIN_GR | `AC_GR` (lookup `ac-groups`, fills `AC_MAIN_GR`) / `AC_MAIN_GR` | Match | web adds fill side-effect |
| AC_SHORT | `AC_SHORT` (Short Name) | Match | |
| AC_PERSON | `AC_PERSON` (Contact Person) | Match | |
| AC_ADD1/2/3 | `AC_ADD1/2/3` | Match | |
| AC_CITY / AC_AREA / AC_PIN | `AC_CITY`,`AC_AREA`,`AC_PIN` | Match | |
| AC_STATE | `AC_STATE` (plain text) | Partial | desktop resolves via `STATE_MAST` picker + `CO_STATE_CODE` (see MS_ACCT inline SQL `SELECT * FROM STATE_MAST…`); web field is free text, no state-code lookup |
| AC_DISTRICT / AC_COUNTRY | `AC_DISTRICT`,`AC_COUNTRY` | Match | |
| AC_PHONE/AC_PHONE2 / AC_MOBILE/AC_MOBILE2 | all four present | Match | |
| AC_EMAIL | `AC_EMAIL` | Match | |
| AC_GSTNO / AC_GST_TYPE | `AC_GSTNO` / `AC_GST_TYPE` select L/I | Match | matches desktop `AC_GST_TYPE` Local/Inter |
| AC_PANNO / AC_ADHAR_NO | `AC_PANNO` / `AC_ADHAR_NO` (Aadhaar) | Match | |
| AC_REF_CODE / AC_REF_NAME | `AC_REF_CODE` (lookup accounts) / `AC_REF_NAME` | Match | |
| AC_KHATA_NO | `AC_KHATA_NO` (Khata No) | Match | family-ledger key |
| BR_DATE / AN_DATE | `BR_DATE` (Birth) / `AN_DATE` (Anniversary) date | Match | |
| AC_CR_DAYS / AC_INT_PRC / DPC_PRC | all present (number) | Match | |
| BANK_NAME/BANK_AREA/BANK_AC_NO/BANK_RTGS_NO | all present | Match | RTGS→"IFSC" label |
| AC_TYPE | `AC_TYPE` | Match | |
| **L_BR_DATE** | — | Gap | last-brought date column in AC_MAST INSERT, absent from web formFields |
| **BANK_DETL** | — | Gap | free-text bank detail column, absent |
| — | `AMT_LIMIT`,`GOLD_LIMIT`,`SILVER_LIMIT` | (web extra) | credit-limit fields web adds beyond the INSERT set |

**Field verdict: Match** for the full `/masters/customers` form (38/40 desktop user columns present; only L_BR_DATE, BANK_DETL missing, State picker downgraded to text).
**But** on the dedicated `/masters/party` page only 5 of these are editable → see gap #5.

### 1b. Tabs & sub-features

| Desktop | Web | Status | Evidence / Note |
|---|---|---|---|
| Tab: **Company Detail** | grouped tabs `General/Address/Contact/Tax & GST/Bank/…` (generic form) | Partial | `masters/[name]/page.tsx` `FieldGroups` + `groupForColumn()` produce 8 heuristic tabs, not the desktop's named "Company Detail" |
| Tab: **Other Detail** | same heuristic tabs | Partial | no distinct "Other Detail" grouping |
| Tab: **Family Detl** | `/masters/party` **Family** tab (members sharing `AC_KHATA_NO`) | Match | `masters/party/page.tsx` family tab + `GET /party/:code/family` |
| Party **photo/image** (Ac_Image) | `/masters/party` **Photo** tab (`POST /party/:code/photo`) | Match | present (bonus over generic form) |
| **Opening Balance** Amount/Gold/Silver each Cr/Dr (inline group-box) | `/masters/party` **Opening** tab: Amount+`D/C`, Gold+`+/−`, Silver+`+/−` → `OP_DATA` | Match | `masters/party/page.tsx` opening tab; also standalone `/masters/opening-balance`. Mirrors desktop OP_DATA model exactly |
| `F1/D/S` account-code auto-number helpers | — | Gap | desktop `calc[]` auto-formats AcCode (`Strings.Format(...+1,"00000")`); web types code manually |
| Validation "Please Insert Party Name" / group required | web requires `CO_CODE,AC_CODE,AC_NAME` | Match | `AC_MAST_CONFIG.requiredColumns` |

---

## 2 · Item / Group / Product Masters

### 2a. Item Master (MS_ITEM → `items` / `ITEM_MAST_CONFIG`)

Desktop fields (KB_master §4.2 + MS_ITEM `ITEM_MAST` columns): Pr Code, Gr Code, Item Code(+auto), Stk Display, Item Name, Safe Name, Hsn, Unit, Rate Per, Labour Rate, Labour %, Conversion, Discount %, Item Rate, Oth Rate, Bag Weight, Touch, West.

| Desktop | Web formField | Status |
|---|---|---|
| Pr Code / Gr Code | `PR_CODE` (lookup products) / `GR_CODE` (lookup groups) | Match |
| Item Code / Item Name | `IT_CODE` / `IT_NAME` | Match |
| Item Type G/S | `IT_TYPE` select Gold/Silver | Match |
| Touch % / West % | `IT_TOUCH` / `IT_WEST` | Match |
| Labour Rate / Labour % | `IT_LBR_RATE` / `LBR_PRC` | Match |
| Hsn / Unit / Rate Per | `HSN_CODE` / `UNIT_NAME` / `RATE_TYPE` | Match |
| Item Rate / Oth Rate | `ITEM_RATE` / `OTHER_RATE` | Match |
| Conversion / Discount % | `CON_PRC` / `DISC_PRC` | Match |
| Bag Weight / Safe / Stk Display | `IT_BAG_WT` / `SAFE_NAME` / `STK_DISPLAY` | Match |
| Min Stock | `MIN_STK` | Match |
| **Item Code + Item Name auto-generate** (Product×Group merge) | manual entry | Partial | KB: "*Item Code + Item Name auto-generate*"; web enters both manually (bulk gen only via `/masters/auto-item`) |

**Item verdict: Match** (20/20 field parity; only the auto-code-generation convenience differs).

### 2b. Item Group Master (MS_GROUP → `groups` / `GROUP_MAST_CONFIG`)

| Desktop | Web formField | Status |
|---|---|---|
| Gr Code / Gr Name | `GR_CODE` / `GR_NAME` | Match |
| Item Type Gold/Silver | `GR_TYPE` select G/S | Match |
| Gr Rate Touch / Purc Touch | `GR_TOUCH` / `GR_PURC_TOUCH` | Match |
| Melting % / West % | `MELTING_PRC` / `WEST_PRC` | Match |
| Sales Ac / Purchase Ac | `SALE_AC` / `PURC_AC` (lookup accounts) | Match |
| Hsn Code / Rate Tax % | `HSN_CODE` / `TAX_PRC` | Match |
| ☐ Rate Display In Main Screen | `RATE_DISPLAY` (text Y/N) | Partial | desktop is a checkbox; web is a plain text field |
| Trading type (`TRAD_TYPE`, GROUP_MAST INSERT) | — | Gap | trading-group link not in web formFields |
| **Validation:** "Please Select Sales and Purchase Account And Try" (both mandatory) | web requires only `CO_CODE,GR_CODE,GR_NAME` | Gap | desktop blocks save without Sales+Purchase A/c (`MS_GROUP.validations`); web does not enforce |

**Group verdict: Match (fields) / Partial (validation + TRAD_TYPE + checkbox).**

### 2c. Product Master (MS_PRODUCT → `products` / `PRODUCT_MAST_CONFIG`)

| Desktop | Web | Status |
|---|---|---|
| Code (2-char) + Name | `PRODUCT_MAST_CONFIG` (CO_CODE, PR_CODE, PR_NAME) | Match |
| Validation "Product Code 2 Digit" | none | Partial | web `PRODUCT_MAST_CONFIG` has **no `formFields`** → renders bare required cols; no 2-digit rule |
| Auto Item bulk-generate (MS_AUTO_ITEM) | `/masters/auto-item` (`autoItem.ts`) present | Match(route) | page + API module exist; deep behavior not line-verified here |

**Product verdict: Match** (trivial 2-field master; only the 2-digit validation missing).

---

## 3 · Reports

### 3a. Ledger Report (RP_LEDR → `/reports/account-ledger/:acCode` = `accounting.ts accountLedger`)

Desktop RP_LEDR is a **tri-currency** party ledger. `RP_LEDR.behavior.json` `gridColumns` (detail group `c2*/c3*`):
`BookName, VchNo, VchDate, BillNo, AcName(contra), CrAmt, DrAmt, BalAmt, CrDr, DrGold, CrGold, BalGold, GlCrDr, CrSilver, DrSilver, BalSilver, SlCrDr, CoBook, MainBook, Remark`; plus an all-party summary (`c*`: DrAmt/CrAmt/DrGold/CrGold/DrSilver/CrSilver + Address/Mobile/City/Khata/RefBy) and an **aging** block (`ct*`: `Amt15…Amt151`, `Wt15…Wt151`).

Web `accountLedger` returns per-row `{ vchNo, vchType, vchDate, dr, cr, runningBalance }` + `opening`/`closing` (evidence: `accounting.ts` `LedgerRow` + the `sum("DR_AMT"-"CR_AMT") OVER (…)` window query).

| Desktop column / feature | Web | Status | Note |
|---|---|---|---|
| VchNo / VchDate | `vchNo` / `vchDate` | Match | |
| Dr / Cr Amount + running Balance | `dr` / `cr` / `runningBalance` | Match | window-fn running balance |
| Opening balance (pre-period) | `opening` (Σ before `fromDate`) | Match | |
| **DrGold / CrGold / BalGold** (metal fine) | — | **Gap** | web ledger is amount-only; no gold-fine sub-ledger |
| **DrSilver / CrSilver / BalSilver** | — | **Gap** | no silver-fine columns |
| BookName / CoBook / MainBook | `vchType` only | Partial | book name/code not resolved |
| BillNo | — | Gap | |
| Contra AcName / LdrName | — | Gap | other-side account not returned |
| Remark | — | Gap | |
| All-party ledger summary | separate `/reports/account-balances`, `/reports/outstanding` | Partial | amount-only; not the RP_LEDR summary shape |
| Aging 15/30/45/60/90/120/150 (amt+wt) | — | **Gap** | `/reports/bill-outstanding` gives bill balances but no day-buckets |
| Filters: date range + AC_CODE | `fromDate`,`toDate`,`acCode`,`coYear` | Match | |
| Filters: AC_GR, AC_CITY, AC_AREA, AC_STATE, AC_KHATA_NO, AC_REF_CODE, AC_TYPE | — | Gap | desktop scopes ledger by group/city/area/khata/referrer (MS/RP inline SQL); web = single party only |

**Ledger verdict: Partial** — amount ledger + running balance + opening match; **metal (gold/silver) fine columns, aging buckets, bill/contra/book columns, and party-scope filters are all Gaps.**

### 3b. Stock Reports (RP_STOCK item-wise + RP_TAG tag-wise)

**Item-wise (RP_STOCK).** Desktop columns (KB_other §3.3 + `RP_STOCK.behavior.json` `gridColumns` `cM*`): `ItCode, ItName, ItType, OpPcs, OpWt, PrPcs, PrWt, InPcs, InWt, OuPcs, OuWt, SlPcs, SlWt, ClPcs, ClWt` (Opening/Purchase/In/Out/Sale/Closing pcs+wt). Tabs `Group | Product | Item | Design | Safe | Table | Trading`; filters gross-wise wt, date range, item type, Gr, Pr, Safe, Table.

| Desktop | Web candidate | Status | Note |
|---|---|---|---|
| Op/Pr/In/Out/Sl/Cl pcs+wt matrix | `stockValuation` (BAR_DETL by item: item,tags,pcs,gwt,nwt,fine,mrp) | **Gap** | snapshot only — no opening/purchase/sale/closing split |
| in/out movement | `itemStockLedger` (MAIN_STOCK: inFine,outFine,netFine,inPcs,outPcs) | Partial | in/out/net fine only; no opening/closing, no wt-vs-fine matrix |
| Tabs Group/Product/Item/Design/Safe/Table/Trading | — | Gap | web is a single item-grouped list |
| Filters date range / item type / Gr / Pr / Safe / Table | — | Gap | `stockValuation` & `itemStockLedger` take **no** filters (co-scope only) |

**Tag-wise (RP_TAG → `/reports/tag-stock` = `tagStock.ts`).**

| Desktop | Web | Status | Note |
|---|---|---|---|
| Tabs In Tag / Out Tag / Stock Tag / Mrp Tag / Apr Panding / All Tag | `in / out / stock / mrp / apr / all` | **Match** | 1:1 tab set (`TagStockTab`) |
| Cols TagNo, ItCode, Counter, Design, VchTyp, VchDate, Pcs, GrWt, NetWt, Mrp | `tagNo, itCode, tblCode, designNo, vchType, vchDate, pcs, grossWt, netWt, mrp` | Match | core columns + web adds `fine` |
| Cols Style, Size, VchNo | — | Gap | not returned |
| Cols LbrRate, LbrAmt, Lbrprc, OthAmt, PrCost | — | Gap | labour/cost columns absent |
| Cols Book, KrName, HM_ID | — | Gap | book/karigar/hallmark absent |
| Filters Date from/to, Item Type, Product, Group, Tag Search | Counter (`tblCode`) + Item (`itCode`) only | Partial | no date range / item-type / product / group / tag-search |

**Stock verdict: item-wise = Gap (movement matrix + tabs + filters); tag-wise = Partial (tabs match, several columns + filters missing).**

### 3c. GST / GSTR-1 (RP_GST / Gstr_1 → `/gst/gstr1` = `gst.ts gstr1/buildGstr1`)

Desktop RP_GST drives the **FORM GSTR-1** (`Gstr_1.spec.json` text "FORM GSTR 1 — Details of outward supplies") from the unified **`TAX_DATA`** register joined to `AC_MAST` (GSTIN, `AC_STATE`), `STATE_MAST` (state code), `TAX_MAST` (rate), `BOOK_DATA` — with `R_CHARG` (reverse charge), `BILL_NO/BILL_DATE`, `BILL_DBCD` (bill book), per-rate splits, and a section-type selector (`RP_GST.validations`: "Please Select Section Type And Try...").

Web `gstr1` builds `{ b2b, b2cl, b2cs, hsn }` from **`SL_DATA`** (+ `SL_DETL` for HSN detail), classifying B2B by `AC_GSTNO`, inter-state by `IGST_TAX>0`, B2CL by value threshold.

| Desktop | Web | Status | Note |
|---|---|---|---|
| B2B (registered) | `b2b` (has GSTIN) | Match | `classifyInvoice` |
| B2CL (unreg. inter-state > threshold) | `b2cl` (`B2CL_THRESHOLD=250000`) | Match | |
| B2CS (remaining B2C by state+rate) | `b2cs` (`summarizeB2CS`) | Match | |
| HSN summary | `hsn` (`summarizeHsn`) | Partial | **uses `IT_CODE` as HSN proxy** — code comment: "HSN summary groups by HSN (IT_CODE proxy — a dedicated HSN master is a parity item)" |
| Source = unified `TAX_DATA` (sales + other-income) | `SL_DATA` only | Partial | other-income/GST from non-sales books not included |
| Reverse charge (`R_CHARG`) | — | Gap | not modelled |
| Credit/Debit-note (CDNR — sales returns) section | — | Gap | returns not split out for GSTR-1 |
| Place-of-supply state **code** (`STATE_MAST.STATE_CODE`) | `AC_STATE` name string | Partial | no numeric POS code |
| Exports / Nil-rated / Advances sections | — | Gap | |
| Section-type selector + book/party/date filters | `coYear` + `threshold` only | Partial | |
| Statutory FORM GSTR-1 document | `gstr1Doc.ts renderGstr1Doc` → PDF | Match | statutory doc renderer present |

**GST verdict: Partial** — core B2B/B2CL/B2CS/HSN + statutory doc present; HSN-proxy, SL_DATA-only source, no reverse-charge, and no CDNR/export/nil sections are Gaps.

---

## Top 5 Gaps (highest impact)

1. **Ledger has no metal (gold/silver fine) columns.** Desktop RP_LEDR shows `DrGold/CrGold/BalGold` and `DrSilver/CrSilver/BalSilver` alongside amount (tri-currency ledger — core to a jewellery ERP). Web `accountLedger` (`accounting.ts`) returns amount-only `dr/cr/runningBalance`. **Gap.**

2. **Item-wise Stock movement report is absent.** Desktop RP_STOCK produces the `Op/Pr/In/Out/Sl/Cl × pcs/wt` matrix with Group/Product/Item/Design/Safe/Table/Trading tabs and date/item-type filters. Web has only `stockValuation` (snapshot) + `itemStockLedger` (in/out fine) — neither reproduces the opening→closing movement matrix, tabs, or filters. **Gap.**

3. **Ledger aging + contra/bill/book columns + party-scope filters missing.** No 15/30/45/60/90/120/150-day aging buckets, no contra-account / BillNo / BookName / Remark columns, and no group/city/area/khata/referrer filters (all present in `RP_LEDR.behavior.json`). **Gap/Partial.**

4. **GSTR-1 fidelity.** Built from `SL_DATA` with `IT_CODE` as an HSN proxy (no HSN master), no reverse-charge (`R_CHARG`), and no credit/debit-note (sales-return) section — whereas desktop drives GSTR-1 from the unified `TAX_DATA` register with real HSN/state-code/rate + reverse charge. **Partial.**

5. **Party master split-brain + reduced tabs.** The dedicated `/masters/party` page (which alone carries the Photo/Family/Opening tabs) captures only 5 header fields and POSTs 6 columns; the full 40-field set lives only in the generic `/masters/customers` form, which lacks those tabs, does not reproduce the desktop's 3 named tabs (Company Detail/Other Detail/Family Detl), and downgrades the State (`STATE_MAST`) picker to free text. Group master also omits the desktop's mandatory Sales+Purchase-A/c save validation. **Partial.**

---

## Summary scorecard

| Area | Verdict |
|---|---|
| Party — fields (`/masters/customers` form) | Match (38/40) |
| Party — 3 desktop tabs + State picker | Partial |
| Party — opening balance (Amt/Gold/Silver Cr/Dr) | Match |
| Party — Photo + Family | Match |
| Item master fields | Match (20/20) |
| Group master fields | Match; validation Partial |
| Product master | Match |
| Auto Item | Match (route present) |
| Ledger report | Partial (metal + aging + columns/filters = Gap) |
| Stock — item-wise (movement) | Gap |
| Stock — tag-wise | Partial (tabs Match) |
| GST / GSTR-1 | Partial |
