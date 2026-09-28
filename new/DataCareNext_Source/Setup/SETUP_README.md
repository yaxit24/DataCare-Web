# DataCareNext — Complete Setup Guide

## ─── SYSTEM REQUIREMENTS ────────────────────────────────────────

| Requirement       | Minimum                          |
|-------------------|----------------------------------|
| OS                | Windows 10 / 11 (64-bit)         |
| .NET Framework    | 4.8 (pre-installed on Win10+)    |
| Visual Studio     | 2019 Community or 2022 Community |
| SQL Server        | SQL Express 2017+ (free) or full |
| Crystal Reports   | SAP Crystal Reports Runtime SP35 |
| RAM               | 4 GB                             |
| Disk              | 2 GB                             |

---

## ─── STEP 1 : INSTALL SQL SERVER EXPRESS ─────────────────────────

1. Download: https://www.microsoft.com/en-us/sql-server/sql-server-downloads
2. Choose **Express** (free)
3. Install with instance name: `SQLEXPRESS`
4. Also install **SQL Server Management Studio (SSMS)**: https://aka.ms/ssmsfullsetup
5. Enable **TCP/IP** in SQL Server Configuration Manager → Protocols for SQLEXPRESS

---

## ─── STEP 2 : CREATE THE DATABASE ────────────────────────────────

1. Open **SSMS** → connect to `(local)\SQLEXPRESS`
2. Open file: `Database\01_Schema.sql`
3. Click **Execute (F5)**
   - Creates `DataCareNext` database
   - Creates all 100 tables
   - Applies all ALTER TABLE migrations
4. Verify: expand **DataCareNext** → **Tables** → should show ~100 tables

---

## ─── STEP 3 : SEED INITIAL DATA ──────────────────────────────────

Run the following SQL in SSMS to insert minimal startup data:

```sql
USE DataCareNext;

-- Company master (required)
INSERT INTO CO_MAST(CO_CODE,CO_NAME,CO_SNAME,CO_GST_NO,CO_PAN_NO,
  CO_ADD1,CO_CITY,CO_STATE,CO_MOBILE,CO_TYPE,METAL_TYPE,ALTER_YEAR,MAIN_USER)
VALUES('01','My Jewellery Shop','MJS','27AAAAA0000A1Z5','AAAAA0000A',
  '123 Gold Street','Mumbai','Maharashtra','9999999999','J','G','Y','ABC');

-- CO_SET defaults
INSERT INTO CO_SET(CO_CODE,TAG_RPT,FINE_STK_TYPE,SL_AMT_TYPE,
  DUP_PRINT,TAX_CODE,DHRN_INT_TYPE,GRID_SCROLL,LDR_SUMM,CASH_LIMIT)
VALUES('01','N','N','N','N','10','M','N','N',200000);

-- CO_SET_NEW defaults
INSERT INTO CO_SET_NEW(CO_CODE,COUNTER_STK,TILE_MENU,WAPP_API,CRYSTAL_RPT)
VALUES('01','N','N','N','N');

-- Location master
INSERT INTO LOCT_MAST(CO_CODE,LC_CODE,LC_NAME,LC_CITY,LC_STATE)
VALUES('01','00','Main Branch','Mumbai','Maharashtra');

-- Login user (admin / admin)
INSERT INTO LOGIN_MAST(CO_CODE,LOGIN_NAME,PASSWORD,USER_TYPE)
VALUES('01','ADMIN','ADMIN','A');

-- HDD Key (required for login)
INSERT INTO HDD_MAST(REF_NO) VALUES('DEMO2025');

-- Account groups (mandatory)
INSERT INTO AC_GROUP VALUES('01','01','Sundry Debtors','01','D','Y','ADMIN');
INSERT INTO AC_GROUP VALUES('01','02','Sundry Creditors','02','C','Y','ADMIN');
INSERT INTO AC_GROUP VALUES('01','03','Cash In Hand','05','C','Y','ADMIN');
INSERT INTO AC_GROUP VALUES('01','04','Bank Accounts','05','C','Y','ADMIN');
INSERT INTO AC_GROUP VALUES('01','05','Sales Account','06','I','Y','ADMIN');
INSERT INTO AC_GROUP VALUES('01','06','Purchase Account','07','E','Y','ADMIN');

-- Default cash account
INSERT INTO AC_MAST(CO_CODE,AC_CODE,AC_NAME,AC_MAIN_GR,AC_GR,AC_TYPE,MAIN_USER)
VALUES('01','001','Cash','05','03','C','ADMIN');

-- Gold & Silver item groups
INSERT INTO GROUP_MAST(CO_CODE,GR_CODE,GR_NAME,GR_TYPE,GR_TOUCH,GR_PURC_TOUCH,MAIN_USER)
VALUES('01','001','Gold 22K','G',91.67,91.67,'ADMIN');
INSERT INTO GROUP_MAST(CO_CODE,GR_CODE,GR_NAME,GR_TYPE,GR_TOUCH,GR_PURC_TOUCH,MAIN_USER)
VALUES('01','002','Silver','S',92.5,92.5,'ADMIN');

-- Today's rate
INSERT INTO RATE_MAST(CO_CODE,LC_CODE,VCH_DATE,SR_NO,GR_CODE,GR_NAME,
  FINE_GL_RATE,FINE_SL_RATE,GR_RATE)
VALUES('01','00',CAST(GETDATE() AS DATE),1,'001','Gold 22K',7100,7100,6510);
INSERT INTO RATE_MAST(CO_CODE,LC_CODE,VCH_DATE,SR_NO,GR_CODE,GR_NAME,
  FINE_GL_RATE,FINE_SL_RATE,GR_RATE)
VALUES('01','00',CAST(GETDATE() AS DATE),2,'002','Silver',87,87,80);

-- Voucher books
INSERT INTO BOOK_DATA(CO_CODE,LC_CODE,CO_BOOK,BOOK_NAME,MAIN_BOOK,
  BOOK_SR_NAME,BOOK_TYPE,CUR_IN_USE,LC_TYPE)
VALUES('01','00','001','SALES','SALES','SL','T','Y','S');
INSERT INTO BOOK_DATA(CO_CODE,LC_CODE,CO_BOOK,BOOK_NAME,MAIN_BOOK,
  BOOK_SR_NAME,BOOK_TYPE,CUR_IN_USE,LC_TYPE)
VALUES('01','00','002','PURCHASE','PURCHASE','PR','T','Y','S');
INSERT INTO BOOK_DATA(CO_CODE,LC_CODE,CO_BOOK,BOOK_NAME,MAIN_BOOK,
  BOOK_SR_NAME,BOOK_TYPE,CUR_IN_USE,LC_TYPE)
VALUES('01','00','003','CASH PAY','CASH PAY','CP','A','Y','A');
INSERT INTO BOOK_DATA(CO_CODE,LC_CODE,CO_BOOK,BOOK_NAME,MAIN_BOOK,
  BOOK_SR_NAME,BOOK_TYPE,CUR_IN_USE,LC_TYPE)
VALUES('01','00','004','CASH REC','CASH REC','CR','A','Y','A');
INSERT INTO BOOK_DATA(CO_CODE,LC_CODE,CO_BOOK,BOOK_NAME,MAIN_BOOK,
  BOOK_SR_NAME,BOOK_TYPE,CUR_IN_USE,LC_TYPE)
VALUES('01','00','005','CONTRA','CONTRA','CT','A','Y','A');
INSERT INTO BOOK_DATA(CO_CODE,LC_CODE,CO_BOOK,BOOK_NAME,MAIN_BOOK,
  BOOK_SR_NAME,BOOK_TYPE,CUR_IN_USE,LC_TYPE)
VALUES('01','00','006','KARIGAR ISU','KARIGAR ISU','KI','I','Y','I');
INSERT INTO BOOK_DATA(CO_CODE,LC_CODE,CO_BOOK,BOOK_NAME,MAIN_BOOK,
  BOOK_SR_NAME,BOOK_TYPE,CUR_IN_USE,LC_TYPE)
VALUES('01','00','007','KARIGAR RECEIPT','KARIGAR RECEIPT','KR','I','Y','I');
INSERT INTO BOOK_DATA(CO_CODE,LC_CODE,CO_BOOK,BOOK_NAME,MAIN_BOOK,
  BOOK_SR_NAME,BOOK_TYPE,CUR_IN_USE,LC_TYPE)
VALUES('01','00','008','TAG GEN','TAG GEN','TG','M','Y','M');
INSERT INTO BOOK_DATA(CO_CODE,LC_CODE,CO_BOOK,BOOK_NAME,MAIN_BOOK,
  BOOK_SR_NAME,BOOK_TYPE,CUR_IN_USE,LC_TYPE)
VALUES('01','00','009','DHIRAN ISSUE','DHIRAN ISSUE','DI','D','Y','D');
INSERT INTO BOOK_DATA(CO_CODE,LC_CODE,CO_BOOK,BOOK_NAME,MAIN_BOOK,
  BOOK_SR_NAME,BOOK_TYPE,CUR_IN_USE,LC_TYPE)
VALUES('01','00','010','DHIRAN RECEIVED','DHIRAN RECEIVED','DR','D','Y','D');

-- Financial Year
INSERT INTO YEAR_MAST(CO_CODE,CO_YEAR,FROM_DATE,TO_DATE,CUR_IN_USE)
VALUES('01','2025-2026','2025-04-01','2026-03-31','Y');
```

---

## ─── STEP 4 : INSTALL VISUAL STUDIO ──────────────────────────────

1. Download VS 2022 Community: https://visualstudio.microsoft.com/downloads/
2. During install, select workloads:
   - ✅ .NET desktop development
   - ✅ Data storage and processing

---

## ─── STEP 5 : INSTALL CRYSTAL REPORTS RUNTIME ────────────────────

1. Download from SAP: https://www.sap.com/products/technology-platform/crystal-reports.html
2. Or directly: https://origin.softwaredownloads.sap.com/public/site/index.html
   - Search: "Crystal Reports runtime SP35 for Visual Studio"
3. Install `CRRuntime_64bit_13_0_35.msi` (or latest SP)
4. Restart Visual Studio after installation

---

## ─── STEP 6 : OPEN & BUILD THE PROJECT ───────────────────────────

1. Open **Visual Studio 2022**
2. File → Open → Project/Solution
3. Select `DataCareNext.sln`
4. Edit `Config\App.config`:
   ```xml
   Data Source=(local)\SQLEXPRESS;Initial Catalog=DataCareNext;Integrated Security=True;
   ```
   Replace `(local)\SQLEXPRESS` with your SQL Server instance name if different
5. Build → Build Solution (Ctrl+Shift+B)
6. Press **F5** to run in debug mode

---

## ─── STEP 7 : FIRST LOGIN ─────────────────────────────────────────

- **Company Code:** `01`
- **Location:** `Main Branch`
- **User ID:** `ADMIN`
- **Password:** `ADMIN`

> ⚠️ Change the admin password immediately after first login via  
> **Utilities → User Management**

---

## ─── REPORTS SETUP ────────────────────────────────────────────────

Copy the original `.rpt` files (from the original installation) into:
```
bin\Debug\Reports\
bin\Release\Reports\
```

RPT files required:
- `ItemSalesVch.rpt`  → Sales bill print
- `SaleReport.rpt`   → Sales register
- `PurcReport.rpt`   → Purchase register  
- `AcLedger.rpt`     → Account ledger
- `Gstr_1.rpt`       → GST Return 1
- `Gstr_2.rpt`       → GST Return 2
- `TRialBalHz.rpt`   → Trial Balance
- `RojMelCash.rpt`   → Day Book
- `TagStkRpt.rpt`    → Tag Stock
- (all remaining .rpt files from your original ZIP)

---

## ─── ARCHITECTURE SUMMARY ────────────────────────────────────────

```
DataCareNext/
├── DataCareNext.sln            ← Visual Studio solution
├── DataCareNext.vbproj         ← VB.NET project
├── Config/
│   └── App.config              ← Connection string ← EDIT THIS
├── Database/
│   └── 01_Schema.sql           ← Run this on SQL Server first
├── Modules/
│   ├── Globals.vb              ← Global vars, constants, helpers
│   ├── Database.vb             ← SQL connection & query helpers
│   └── MyApplication.vb       ← App entry point (Sub Main)
├── Forms/
│   ├── MS_LOGIN.vb             ← Login/auth
│   ├── MDI_FORM.vb             ← Main MDI shell + menus
│   ├── MS_ACCT.vb              ← Account master
│   ├── MS_ITEM.vb              ← Item master
│   ├── MS_RATE.vb              ← Daily rate entry
│   ├── MS_COMPANY.vb           ← Company settings
│   ├── MS_USER.vb              ← User management
│   ├── TR_SALE.vb              ← Sales bill (complete)
│   ├── TR_PURC.vb              ← Purchase bill
│   ├── TR_CASH.vb              ← Cash voucher
│   ├── TR_KR_ISU.vb            ← Karigar issue
│   ├── TR_APR_ISU.vb           ← Approval/consignment
│   ├── TR_DHRN_ISU.vb          ← Gold loan issue
│   ├── TR_DHRN_REC.vb          ← Gold loan receipt
│   ├── TR_MFG_ITEM.vb          ← Tag/item generation
│   ├── TR_INOUT.vb             ← Stock in/out
│   ├── ... (41 form files total)
│   ├── RP_LEDR.vb              ← Ledger report
│   ├── RP_STOCK.vb             ← Stock report
│   ├── RP_GST.vb               ← GST returns
│   ├── RP_BALANCE.vb           ← Trial balance
│   ├── UT_BKP.vb               ← Backup
│   ├── UT_SETTING.vb           ← Settings
│   ├── UT_E_INVOICE.vb         ← E-Invoice / IRN
│   └── UT_WAPP_WITH_API.vb     ← WhatsApp API
└── Setup/
    └── SETUP_README.md         ← This file
```

---

## ─── DATABASE TABLES (100 tables) ───────────────────────────────

| Category      | Tables |
|---------------|--------|
| Company/Setup | CO_MAST, CO_SET, CO_SET_NEW, LOCT_MAST, BOOK_DATA, YEAR_MAST |
| Masters       | AC_MAST, AC_GROUP, ITEM_MAST, GROUP_MAST, PRODUCT_MAST, LBR_MAST |
| Masters       | RATE_MAST, DM_MAST, DM_SIZE, EMP_MAST, TOUCH_MAST, TAG_STOCK |
| Masters       | AD_MAST, AD_MEMB, POINT_MAST, DESIGN_MAST, DG_GOLD_MAST, E_MAST |
| Transactions  | SL_DATA, SL_DETL, PR_DATA, PR_DETL, AC_DATA, ROJ_MEL_DATA |
| Transactions  | INOUT_DATA/DETL/IDTL, MFG_DATA/DETL/IDTL, KR_DATA/DETL |
| Transactions  | DHRN_ISU_DATA/DETL, DHRN_REC_DATA/DETL, BUL_DATA |
| Transactions  | CARD_DATA, UPI_DATA, CONTRA_DATA, CRNT_DATA, LDR_ADJ_DATA |
| Transactions  | AD_DATA, AD_ADJ, AD_OS, BILL_OS_DATA, CUT_DATA/DETL/STK_DETL |
| Audit         | DELETE_DATA, USER_DATA, REMARK_DATA |
| E-Invoice     | E_DATA, TAX_DATA |
| Mobile/Web    | APP_USER_DATA, WEB_DATA, LIKE_DATA, USER_REQUEST |

---

## ─── BUSINESS LOGIC NOTES ─────────────────────────────────────────

| Rule | Description |
|------|-------------|
| Fine = NWT × Touch% | Always stored in ITM_FINE |
| GST split | AC_GST_TYPE='I' → full IGST; else CGST+SGST each at half |
| Cash limit | Default ₹2,00,000; triggers PAN collection |
| Stock sign | '+' = stock in; '-' = stock out (in MAIN_STOCK) |
| Tag lifecycle | MFG_ITEM → TAG_STOCK → SL_DETL (sold) → removed from TAG_STOCK |
| Karigar | INOUT_DATA (book=KARIGAR ISU) → INOUT_DATA (book=KARIGAR RECEIPT) |
| Voucher keys | Always keyed on (CO_CODE, LC_CODE, CO_YEAR, CO_BOOK, VCH_NO) |
| E-Invoice | Fire when TAX_AMT ≠ 0 and IRN_NO is blank |
| WhatsApp | Async send after successful save; uses CO_SET_NEW.WAPP_API_MOBILE |

---

## ─── SUPPORT ──────────────────────────────────────────────────────

- This project was reconstructed from binary analysis of `DataCareNext.exe v11.06`
- Extracted: 100 CREATE TABLE DDL, 6,241 SQL queries, 28,168 runtime strings
- All SQL queries are embedded as comments in each form file
