# DataCareNext — Desktop Knowledge Base: **master** playlist (Setup + Masters)

> Purpose: drive an EXACT web replica. Each entry documents the desktop screen (exact labels/grids
> from keyframes), the operator workflow (from the Sarvam Hindi narration), the DB/ledger/stock
> effects (narration + decompiled `extracted_code/DataCareNext/DataCareNext/*.cs` + web
> `web/apps/api/src/modules/**`), cross-module links, and the web parity mapping
> (`web/apps/web/app/(app)/**`).
>
> Evidence base: full `transcript.sarvam.txt` per video + 5–9 `keyframes/kf_*.jpg` read as images +
> decompiled `.cs` forms + web API/pages. Keyframes cited as `kf_NNN`.

---

## Global UI shell (applies to every screen)

Confirmed across all six videos (kf_001 of most videos):

- **Title bar:** `<CoCode> - <CoName> - <CoYear> - <User> - P` — e.g. `01 - DATACARE SOFTECH - 2021-2022 - ABC - P` (kf_001, VnXnYL5F6VE). The `<User>` segment changes to `USER 1` after a non-admin login (kf_049, X-ba6-Q_L1g).
- **Top menu bar** (orange): `Home | Company | Master | Tran 1 | Tran 2 | Other | Karigar | Reports | Scheme | Dhiran | Exit`. A date field sits at the far left (e.g. `12/05/2021`).
- **Left "Pro" sidebar:** context-sensitive to the selected top menu.
  - `Company →` Company, Year Create, Balance TrFr, Books, User Create, Account Group, Trade Master, Setting, Setting Main, Data Refresh, Data Backup, Year Select (kf_002 VnXnYL5F6VE; kf_004 vLIK-w9pFlY).
  - `Master →` Party, Address, Product, Group, Item, AutoItem, Employee, Tax, Party Opening, Item Opening, Tag Opening, Counter, Labour (kf_002 WmJ9la4_FP4).
- **Status bar (bottom):** `Orange` (theme) · `Live Rate ☐` · `Fine Gold : 49368` · `Fine Silver : 69917` · `Rate Date : 18-04-2021 11:26` · `Service End : 01/01/0001`.
- **Common bottom action bar on masters/transactions:** `Print | Save | Cancel | Delete | Exit`.
- **Keys / conventions:** `Enter` walks field→field; pressing `Enter` on a *code* field opens a **"DataCare Help"** lookup grid (e.g. company list, account-group list, product/group list). **F1** = lookup/help on the current field. **F3** = Stock Report (narration: *"यहां पे एक शॉर्टकट की है F3 स्टॉक रिपोर्ट"* — "there's a shortcut key F3, Stock Report"). Master screens use a **left search grid + right form**; the primary **Code auto-generates**.
- **Multi-tenancy keys:** every table is keyed by `CO_CODE` (company) + `LC_CODE` (location, default `01`; company-level rows use `00`) + `CO_YEAR` where applicable. In the web these become the tenant/`CO_CODE` scope enforced by `withTenant(...)` (RLS).

---

## Summary table

| Video (id) | Desktop screen | Menu path | Desktop form (.cs) | Web route | Web API module | Parity |
|---|---|---|---|---|---|---|
| Company Create (`VnXnYL5F6VE`) | Company Master (+ Year Create, Company-Select login) | Company → Company; Company → Year Create | `MS_COMPANY`, `MS_YEAR`, `MS_OPNCOMP`, `MS_LOGIN` | `/admin/provision` (+ `/masters/companies`, `/masters/years`, `/login`+`/select`) | `ops/seedCompany.ts` | **Partial / Gap** — provisioning (code+name+seed) matches; full company-detail form (state/work-type/metal-type/GST/bank) is a gap |
| User Create (`X-ba6-Q_L1g`) | User Create + per-form Rights grid | Company → User Create | `MS_USER` (enforced by `MDI_FORM`) | `/admin/users` | `rbac/users.ts`, `rbac/formRights.ts` | **Partial** — LOGIN_MAST + global Update/Delete/Print match; per-form View/Edit/Delete/Print matrix present in API (`USER_SET`) but not in the admin UI |
| Account Create (`NyEAB-xn7Hw`) | Party Master (+ inline Opening Balance) | Master → Party | `MS_ACCT` | `/masters/accounts` (+ `/masters/opening-balance`, `/masters/ac-groups`, `/txn/ac-opbl`) | `masters/master.service.ts` (`AC_MAST_CONFIG`), `masters/openingBalance.ts`, `finance/acOpening.ts` | **Matches (fields)** — opening balance split to its own page; Family/photo tabs = gap |
| Item Create (`WmJ9la4_FP4`) | Product, Item Group, Item, Auto Item | Master → Product / Group / Item / AutoItem | `MS_PRODUCT`, `MS_GROUP`, `MS_ITEM`, `MS_AUTO_ITEM` | `/masters/products`, `/masters/groups`, `/masters/items` | `masters/master.service.ts` (`PRODUCT_MAST_CONFIG`, `GROUP_MAST_CONFIG`, `ITEM_MAST_CONFIG`) | **Matches (Product/Group/Item)** — Auto-Item Y/N matrix = gap |
| Barcoding Stock (`3eHsCZC1gu4`) | Item Opening (bulk) + Tag Opening (barcode) + Stock/Tag reports | Master → Item Opening / Tag Opening | `TR_ITM_OPBL`, `TR_TAG_OPBL`, `RP_STOCK`, `RP_TAG` | `/txn/item-opening`, `/txn/tag-opening` (+ `/txn/stock`) | `stock/stock.ts` (`itemOpening`, `tagOpening`) | **Partial** — postings match; auto barcode #, rich tag fields, QR/label print, Tag-Stock-Report tabs = gap |
| Data Backup (`vLIK-w9pFlY`) | Backup Data (+ Restore) | Company → Data Backup | `UT_BKP` | `/backup` | `ops/backup.ts` (+ `deploy/backup.sh`) | **Partial** — different mechanism: web = per-company JSON export + `pg_dump` cron; desktop = native SQL `.BAK` to chosen drive + in-app Restore |

Parity legend: **Matches** = web reproduces the desktop behaviour/fields; **Partial** = core works, notable pieces missing; **Gap** = not implemented in web.

---

## 1. Company Create — `VnXnYL5F6VE`

### 1.1 Screen title + menu path
- **Company Master** — `Company → Company` (first item of the Company sidebar). Narration: *"कंपनी बनाने के लिए … मेनू है कंपनी … फर्स्ट ऑप्शन है कंपनी"* ("to create a company … the menu is Company … the first option is Company").
- **Year Create** — `Company → Year Create` (auto-opens right after a company is saved).
- **Company-Select login** — `MS_OPNCOMP`/`MS_LOGIN` (shown on app launch).

### 1.2 Header fields + grids
- **Company-select / login popup** (kf_005, kf_004): fields **Company Name** (code box, e.g. `02`), **Location Name** (`00`), **Exit**. A **"DataCare Help"** grid lists existing companies — columns **Code | Name | Address** (`01  DATACARE SOFTECH  505, SHIVALIK SATYMEV`; `02  ABC JEWELLERS`).
- **Company Master detail form** — the full detail form was *not* isolated in a scene-change keyframe (the 11 keyframes captured the list popup, Year Create, and login). Field set from narration, in entry order: **Company Code** (auto-generated), **Company Name**, **Address**, **Country**, **State** (Enter opens a state list → e.g. *Gujarat*), **City**, **Work Type** (Retail / Wholesale), **Metal Type** (Gold / Silver), **Tax Detail → GST number**, **Bank Detail**. (`extracted_code/.../MS_COMPANY.cs` reads/writes `CO_MAST`, incl. `CO_TYPE`.)
- **Year Create form** (kf_002): **Create New** = `2021-2022`, **Opening Date** = `01/04/2021`. On save a dialog reads **"All Master And Parameter are Created…Now ReOpen Software.."** → **OK**.

### 1.3 Operator workflow (from narration)
1. `Company → Company`; existing companies list on the left; double-click a row to edit (e.g. rename/re-address company #1) → **Save**.
2. New company: **Company Code auto-generates**; type **Company Name** (demo `ABC`) → Enter; **Address** → Enter Enter; **Country**, **State** (Enter → list → *Gujarat* → Enter Enter), **City**.
3. **Work Type** (retail/wholesale), **Metal Type** (gold/silver), **Tax Detail → GST No**, then Enter×6 to **Bank Detail**.
4. **Save** → **OK** → **Year Create** auto-opens → **Enter Enter Enter** → Save → *"ये ईयर ऑटोमेटिकली क्रिएट हो जाएगा"* (the year is auto-created) → **"All Master And Parameter are Created…Now ReOpen Software"** → software closes.
5. Relaunch → login **username / password** → **select Company #2** in the company-select popup → Enter → start working in company #2.

### 1.4 Effects (tables / ledger / stock)
- Writes **`CO_MAST`** (one row per company: `CO_CODE`, `CO_NAME`, address, `STATE`, GST, bank, `CO_TYPE`/work+metal type). `MS_COMPANY.cs`: `SELECT … FROM CO_MAST ORDER BY CO_CODE`, insert/update `CO_MAST`.
- Year Create writes **`YEAR_MAST`** (`CO_CODE`, `CO_YEAR`=`2021-2022`, `YEAR_MONTH`, `OP_DATE`=`01/04/2021`, `CL_DATE`) and **seeds all masters + parameters** and a default login (`LOGIN_MAST` user `ABC`). `MS_YEAR.cs` confirms `YEAR_MAST` + `LOGIN_MAST` writes.
- **No ledger / no stock** impact — this is foundational master data.

### 1.5 Cross-module connections
- Root of the whole data model: **every** master/transaction table is keyed by `CO_CODE` (+ `LC_CODE`, `CO_YEAR`). Feeds the company-select login (`MS_OPNCOMP`), **User Create**, and all masters/transactions. `Year Select` (sidebar) switches the active `CO_YEAR`.

### 1.6 Web parity
- **Route:** `/admin/provision` → `POST /admin/companies/{coCode}/provision` → **`ops/seedCompany.ts`**. Captures **Company Code** + optional **Company Name**, then seeds: `CO_MAST` row, **19 system accounts** (`CASH, BANK, SALES, PURCHASE, GST, GSTINPUT, ROUNDOFF, KASAR, TCS, HMCHRG, OLDGOLD, OG, OS, INTINC, BULLION, FINESALE, FINEPURC, DHRN, CAPITAL`), **7 taxes** (`00 Tax Free, 10 GST 3%, 11 GST 5%, 12 GST 12%, 13 GST 18%, 14 GST 28%, 20 TCS 0.1%`), **14 voucher books** (`SL,PR,RCT,PAY,SOR,SRT,PRT,TUR,TRR,SAJ,TTR,ILT,JV,CON`), `SRNO_MAST` numbering counter, and `CO_SET`. Idempotent (insert-if-absent).
- Year → `/utilities/year-end` (`ops/yearEnd.ts`) or bare `/masters/years` (`YEAR_MAST`). Login/company-select → `/login` + `/select`.
- **Parity: Partial / Gap.** Provisioning + seed match the desktop's "create company then auto-create masters/parameters/year" behaviour. **Gap:** the web has no full **Company Master detail form** — desktop `Address / Country / State (Gujarat list) / City / Work Type / Metal Type / GST / Bank` are not captured (only code+name). A bare `/masters/companies` (`CO_MAST`) CRUD exists but without the state picker, work-type and metal-type. **To-verify:** whether `masters/companies` should be extended into a full company form to reach exact parity.

---

## 2. User Create — `X-ba6-Q_L1g`

### 2.1 Screen title + menu path
- **User Create** — `Company → User Create` (kf_008). Narration: *"कंपनी मेनू में … फर्स्ट ऑप्शन है यूजर क्रिएट"* ("in the Company menu … first option is User Create"). Desktop `MS_USER.cs`; runtime enforcement in `MDI_FORM.cs`.

### 2.2 Header fields + grids
- **Create/edit form** (kf_008): top **User Name** dropdown (existing users). Right-hand fields: **Create New** (login name, e.g. `USER 1`), **Old Password**, **New Password**, **Confirm**, **User Type** (dropdown `User` / `Admin`). Button **"Update User Right"**. Action bar Print/Save/Cancel/Delete/Exit.
- **Rights grid** (kf_014, kf_020, kf_035): after choosing a user in the dropdown, the grid loads with columns **`SrNo | Main Menu | Sub Menu | View | Edit | Delete | Print`** (four checkbox columns). Rows enumerate every menu → form, e.g.:
  - `1 Company (header)`, `2 Company/Company`, `3 Company/Year Create`, `4 Company/Balance TrFr`, `5 Company/Books`, `6 Company/User Create`, `7 Company/Account Group`, `8 Company/Trade Master`, `9 Company/Setting`, `10 Company/Setting Main`, `11 Company/Location`, `12 Company/Data Refresh`, `13 Company/Data Backup`, `14 Company/Main Menu`, `15 Company/Admin Setting`, `16 Company/Year Select`, `17 Master (header)` …
  - … `38 Master/Conversation`, `39 Transaction (header)`, `40 Transaction/Purchase`, `41 Transaction/Purchase Rtn`, `42 Transaction/Sales Order`, `43 Transaction/Sales`, `44 Transaction/Sales Return`, `45 Transaction/Wh Sales`, `46 Transaction/Cash Received`, `47 Transaction/Cash Payment`, `48 Transaction/Bank Received`, `49 Transaction/Bank Payment`, `50 Transaction/Contra Entry`, `51 Transaction/Rate Cut`, `52 Other (header)`, `53 Other/Daily Rate`, `54 Other/Only Tag Entry` (kf_035).
  - Menu-*header* rows (Company, Master, Transaction, Other) carry a blank Sub Menu and gate the whole top-menu.

### 2.3 Operator workflow (from narration)
1. `Company → User Create`; type **User Name** (`User 1`) → Enter; leave **Old Password** blank; type **New Password** (demo `12345`) → **Confirm** → Enter; **User Type** = `User` → Enter → **Save** (*"ये यूजर इस तरह से क्रिएट हो जाएगा"* — the user is created).
2. Click the **User Name** dropdown → pick `USER 1` → the **rights grid** loads.
3. Per form, toggle **View / Edit / Delete / Print**. Untick **View** on a menu ⇒ *"आपको ये राइट्स नहीं है कि आप … ओपन कर पाए"* (you don't have rights to open it). Example given: Sales — keep **View + Print**, untick **Edit + Delete** (*"सेल बिल बना सकता है लेकिन … एडिट नहीं कर सकता और डिलीट भी नहीं कर सकता"*).
4. Click **"Update User Right"** (*"अपडेट यूजर राइट्स … ये अपडेट हो जाएगा"*).
5. **Enforcement demo:** log in as `USER 1` → `Tran 1 → Sales → Estimate`; creating a new bill works; editing an existing bill raises **"You Have No Rights….."** (kf_049) because Edit/Delete were revoked; admin (`ABC`) can edit everything.

### 2.4 Effects (tables / ledger / stock)
- **`LOGIN_MAST`** — one row per user: `CO_CODE`, `LOGIN_NAME`, `LOGIN_PWD`, `LOGIN_CATG` (`User`/`Admin`), plus the three global flags `USER_UPDATE` / `USER_DELETE` / `USER_PRINT`. `MS_USER.cs`: `SELECT * FROM LOGIN_MAST WHERE CO_CODE='01' ORDER BY LOGIN_NAME`.
- **`USER_SET`** — per-user × per-form rights: `CO_CODE, LC_CODE, USER_NAME, MAIN_SRNO, SUB_SRNO, MAIN_MENU, SUB_MENU, FRM_VIEW, FRM_EDIT, FRM_DELETE, FRM_PRINT` (each `Y`/`N`). Enforced at runtime in `MDI_FORM.cs`: `Select * From USER_SET WHERE … AND SUB_MENU='…' AND FRM_VIEW='Y'`.
- **No ledger / no stock.** Admin (`LOGIN_CATG` starting with `A`) implicitly holds all rights.

### 2.5 Cross-module connections
- Gates **every** menu and form in the app (Company/Master/Tran 1/Tran 2/Other/Karigar/…). Feeds the login (`MS_LOGIN`) and the MDI shell's per-form access checks; the Sales/edit example proves transactional enforcement.

### 2.6 Web parity
- **Route:** `/admin/users` → `rbac/users.ts` (`createUser`, `listUsers`, `setUserRole`, `setUserRights` over `LOGIN_MAST`; **passwords hashed with Argon2id** via `auth/password.ts`) and `rbac/formRights.ts` (`getUserFormRights` / `setUserFormRights` / `resolveAllowedForms` over `USER_SET`, with `FRM_VIEW/EDIT/DELETE/PRINT`; "no rows ⇒ unrestricted", matching the desktop).
- New-user form: **Company (CO_CODE)**, **Login name**, **Password**, **Role** (`ADMIN`/`USER`). Rights matrix in the grid: per-user **Update / Delete / Print** checkboxes + **Category** (Admin/User); admins render as all-on/disabled.
- **Parity: Partial.** `LOGIN_MAST` + global Update/Delete/Print + role match; `resolveAllowedForms`/`USER_SET` reproduce the desktop's per-form gating in the **API**. **Gap:** the `/admin/users` **UI** exposes only the three global flags + category, not the full desktop **per-form View/Edit/Delete/Print matrix** across every `MAIN_MENU/SUB_MENU` row. **Improvement over desktop:** hashed passwords (desktop stored plaintext in `LOGIN_PWD`).

---

## 3. Account (Party) Create — `NyEAB-xn7Hw`

### 3.1 Screen title + menu path
- **Party Master** — `Master → Party` (kf_008). Narration: *"मास्टर मेनू में … फर्स्ट ऑप्शन है पार्टी … यहां से सारे अकाउंट्स बनेंगे … कस्टमर … सप्लायर … कारीगर"* ("Master menu … first option Party … all accounts are created here — customer, supplier, karigar"). Desktop `MS_ACCT.cs`.

### 3.2 Header fields + grids
- **Left search grid** (kf_008): **`Code | Name | Mobile`** with `SEARCH NAME - MOBILE` box. Seeded system accounts visible: `00001 CASH ON HAND`, `00002 CAPITAL A/C`, `00003 SALES GOLD A/C`, `00004 SALES SILVER A/C`, `00005 SALES OLD GOLD A/C`, `00006 SALES OLD SILVER A/C`, `00007 SALES OTHER A/C`, `00008 PURCHASE GOLD A/C`, `00009 PURCHASE SILVER A/C`, `00010 PURCHASE OLD GOLD A/C`.
- **Right form — Company Detail tab** (kf_008, kf_020, kf_024): **Ac Code** (auto, e.g. `000201`) + **F1** + **D** + **S** buttons; **Ac Name**; **Ac Group** (code + name + main-group no.); **Mobile No** | **Phone No**; **Con Person** | **Ac Short**; **Address1**, **Address2**, **Address3**; **City** | **Pin Code**; **City Area**; **Country**; **Gst No** + [`Local`/inter dropdown = GST type]; **Pan No**; **State** (`Gujarat`); **District**; **Email**.
- **Opening Balance** group-box (inline, kf_008): **Amount** [ ] `Cr`/`Dr`; **Gold** [ ] `Cr`/`Dr`; **Silver** [ ] `Cr`/`Dr` (kf_028 shows `Amount 25000.00 Cr`). Also **Last Visit** (date) and **Ledger Date**. A photo box + camera/image/scissors icons sit lower-left.
- **Tabs:** `Company Detail | Other Detail | Family Detl`. **Other Detail** (kf_028): **Mobile No2**, **Adhar No**, **Bank**, **Branch**, **Bank AcNo**, **ISFC Code**, **Ref By**, **Birth Date**, **Anv Date**, **L Birth**, **Cr Day**, **Dpc %**, **Khata No** + `Local/Local`.
- **Account-Group lookup ("DataCare Help")** (kf_012, kf_016): columns **`GrCod | AcGroup | MainGroup`** —
  `03 SECURED LOAN / SECURED LOANS`, `04 UNSECURED LOAN / LOANS FUNDS`, `05 VEPARI / CURRENT LIABILITIES`, `06 SUNDRY CREDITORS LABOUR / CURRENT LIABILITIES`, `07 DEPOSIT - LIABILITIES / CURRENT LIABILITIES`, `10 KARIGAR SUNDRY CR / CURRENT LIABILITIES`, `11 PROVISION / PROVISION AND OTHERS`, `12 TAX LIABLITIES / PROVISION AND OTHERS`, `13 FIXED ASSETS / APPLICATION OF FUNDS`, `14 INVESTMENT / INVESTMENTS`, `15 LOANS AND ADVANCES ASSETS / LOANS AND ADVANCES`, `16 DEPOSITS - ASSETS / LOANS AND ADVANCES`, `17 CLOSING STOCK ASSETS / CURRENT ASSETS`, `18 CURRENT ASSETS / CURRENT ASSETS`, `20 CUSTOMER`. Narration maps roles: **supplier/व्यापारी = 05 Vepari**, **कारीगर = 10 Karigar**, **customer = 20** (Sundry Debtors).

### 3.3 Operator workflow (from narration)
1. `Master → Party`; **Ac Code auto**; type **Ac Name** (`राहुल जी` / `RAHUL JI`) → Enter.
2. **Ac Group**: Enter → the `GrCod/AcGroup/MainGroup` list opens → pick a group (demo `20 CUSTOMER`; supplier→`05`, karigar→`10`).
3. **Mobile No** (demo `8787878787`) → **Phone No** → **Con Person** → **Address1** (`SDS`) → City/Area/Country/GST/State etc.
4. **Opening Balance** on the left — **Amount** with **Cr/Dr**, plus **Gold** fine and **Silver** fine (each Cr/Dr). Narration: *"गोल्ड फाइन है, सिल्वर फाइन है वो सारी चीजें आप यहां पे डाल सकते हैं"*.
5. Enter → cursor to **Other Detail** (*"नेक्स्ट अदर डिटेल पे कर्सर आ जाएगा"*) → bank details etc.
6. **Save** → **"Data Are Saved."** (kf_028).

### 3.4 Effects (tables / ledger / stock)
- **`AC_MAST`** — the party row. `MS_ACCT.cs` insert columns include `CO_CODE, LC_CODE, AC_CODE, AC_NAME, AC_SHORT, AC_GR, AC_MAIN_GR, AC_AREA, AC_ADD1/2/3, AC_CITY, AC_PIN, AC_PHONE, AC_MOBILE, AC_MOBILE2, AC_EMAIL, AC_TYPE, …` (+ `AC_GSTNO, AC_GST_TYPE, AC_PANNO, AC_ADHAR_NO, AC_STATE, AC_DISTRICT, AC_COUNTRY, BANK_*`, `AC_CR_DAYS`, `DPC_PRC`). Code rule (from `MS_ACCT.cs`): `AC_CODE < 100` = company-level (`LC_CODE='00'`); `>= 200` = location-level party.
- **Opening balance → `OP_DATA`**: `OP_AMT` + `OP_SIGN` (`D`/`C`), `FINE_BAL` + `FINE_SIGN` (`+`/`-`, gold), `SL_FINE_BAL` + `SL_FINE_SIGN` (`+`/`-`, silver), `DATA_TYPE='O'`. These signed openings are folded into the running **`AC_DATA`** ledger when a party balance is computed (money: `Cr` negative; gold/silver: `-` negative). **Fine** figures are metal weights, valued elsewhere at `net × touch / 100`.
- **No stock** effect (accounts are ledger, not inventory).

### 3.5 Cross-module connections
- Every voucher references an account: Sales/Purchase party, Karigar issue/receive (`AC_SHORT` short-code), Cash/Bank, Dhiran. `AC_GR` → **Account Group** master (`AC_GROUP`, `Company → Account Group`). Karigar `AC_SHORT` is later used as the **Karigar Code** on tag opening. Sale/Purchase posting resolves the party group via `AC_MAST ⨝ AC_GROUP`.

### 3.6 Web parity
- **Route:** `/masters/accounts` (alias `/masters/customers`) → **`AC_MAST_CONFIG`** in `masters/master.service.ts`. `formFields` labels map 1:1 to the desktop: `Account Code, Account Name, Account Group, Main Group, Short Name, Contact Person, Mobile, Phone, Address 1/2/3, City, Area, Pin Code, State, District, Country, GSTIN, GST Type (L/I), PAN, Aadhaar, Email, Credit Days, Interest %, DPC %, Bank Name, Bank Branch, Bank A/c No, IFSC, Account Type`.
- **Opening balance** → `/masters/opening-balance` → `masters/openingBalance.ts` (`OP_DATA`: `amount`+`sign D/C`, `gold`+`goldSign +/-`, `silver`+`silverSign +/-`) — direct match to the inline group-box. A second, voucher-based opening exists at `/txn/ac-opbl` → `finance/acOpening.ts` (writes a balanced `AC_DATA` `ACOP` voucher with separate `IT_TYPE 'G'/'S'` metal legs, `FINE_WT`, `SIGN +/-`).
- **Account groups** → `/masters/ac-groups` (`AC_GROUP`: `AC_GR`, `AC_GR_NAME`).
- **Parity: Matches (fields).** Same columns and same `OP_DATA` opening model. **Gap / to-verify:** desktop's single-screen conveniences — inline left search grid, `F1/D/S` helpers, the party **photo/image**, and the **Family Detl** tab — are not part of the generic web master form (opening balance is a separate page).

---

## 4. Item Create (Product / Group / Item / Auto Item) — `WmJ9la4_FP4`

### 4.1 Screen titles + menu paths
- **Product** — `Master → Product` (kf_005). Narration: *"फर्स्ट ऑफ ऑल आपको सभी प्रोडक्ट बनानी पड़ेगी"*.
- **Item Group Master** — `Master → Group` (kf_020).
- **Item Master** — `Master → Item` (kf_040).
- **Auto Item** — `Master → AutoItem` (kf_048). Desktop `MS_PRODUCT / MS_GROUP / MS_ITEM / MS_AUTO_ITEM`.
- Creation order (narration): **Product → Group → Item / Auto Item**.

### 4.2 Header fields + grids
- **Product** (kf_005, kf_012): left grid **`Code | Name`**; form **Code** (2-char, e.g. `CH`) + **Name** (`CHAIN`). Existing products: `DM DIAMOND, EM EMITATION, FN FINE, HM HALL MARK CHARGES, OD ORDER GOLD, OG OLD GOLD, OR ORNAMENTS, OS OLD SILVER, OT OTHER, RD RODIAM CHARGES, SN STONE`; added `CH CHAIN, LR LADIES RING, MS MANGALSUTRA`.
- **Item Group Master** (kf_020, kf_030): left grid **`Code | Name`**; form **Gr Code** (3-char, e.g. `916`, `20C`), **Gr Name** (`916 GOLD ORNAMENTS`), **Item Type** (dropdown `Gold`/`Silver`), **Gr Rate Touch** | **Purc Touch**, **Melting %** | **West %**, **Sales Ac** (code+name), **Purchase Ac** (code+name), **Hsn Code**, **Rate Tax %**, and checkbox **☐ Rate Display In Main Screen**.
- **Item Master** (kf_040): left grid **`Code | Name | Safe`**; form **Pr Code** (product), **Gr Code** (group), **Item Code** (+ auto) + **Stk Display** (`Yes`), **Item Name**, **Safe Name** (`MAIN`), **Hsn Code**, **Unit Name** (`GMS`), **Rate Per** (`Gram Wise`), **Labour Rate**, **Labour %**, **Conversion**, **Discount %**, **Item Rate**, **Oth itm Rate**, **Bag Weight**.
- **Auto Item** (kf_048): **Group Code** (e.g. `20C  20C GOLD ORNAMENTS`) + grid **`Sr. | Pr Code | Pr Name | MinStk | Y/N`** (rows: `1 CH CHAIN`, `2 LR LADIES RING`, `3 MS MANGALSUTRA`, `4 OD ORDER GOLD`, `5 OR ORNAMENTS`), Y/N per product.

### 4.3 Operator workflow (from narration)
1. **Product:** type **Code** (`CH`) + **Name** (`CHAIN`) → Enter → **Save**; repeat (`LR` Ladies Ring, `MS` Mangalsutra).
2. **Group:** **Gr Code** (`916`) → **Gr Name** (`916 GOLD ORNAMENTS`) → **Item Type** = `Gold` → Enter → (gold selection again) → Enter Enter → a **posting-account list** appears (*"सेल्स गोल्ड अकाउंट सिल्वर सेल्स अकाउंट …"*) → pick **Sales Gold Account**, then **Purchase Gold Account** → Enter Enter → **HSN Code** → Enter Enter Enter → **Save**. Silver group (`925 SILVER`): Item Type `Silver`, Sales Silver, Purchase Silver.
3. **Item (merge Product×Group):** Enter → **Product list** → select `Chain` → Enter Enter → **Group list** → pick `916` → **Item Code + Item Name auto-generate** → Save.
4. **Auto Item (bulk):** select **Group** (`20C`) → the product list loads → set **Y/N** per product (`Chain=Y, Ladies Ring=Y`, skip `Mangalsutra/Order Gold`) → **Save** ⇒ items auto-created (`Chain 20 carat`, `Chain 916`, `Chain 925`).

### 4.4 Effects (tables / ledger / stock)
- **`PRODUCT_MAST`** (`PR_CODE`, `PR_NAME`) — `MS_PRODUCT.cs`: `SELECT * FROM PRODUCT_MAST … ORDER BY PR_CODE`.
- **`GROUP_MAST`** (`GR_CODE, GR_NAME, GR_TYPE (G/S), GR_TOUCH, GR_PURC_TOUCH, MELTING_PRC, WEST_PRC, SALE_AC, PURC_AC, HSN_CODE, TAX_PRC, RATE_DISPLAY`, + `AVG_*`).
- **`ITEM_MAST`** (`IT_CODE, IT_NAME, PR_CODE, GR_CODE, IT_TYPE, SAFE_NAME, HSN_CODE, UNIT_NAME, RATE_TYPE, IT_LBR_RATE, LBR_PRC, CON_PRC, DISC_PRC, ITEM_RATE, OTHER_RATE, IT_BAG_WT, STK_DISPLAY, IT_TOUCH, IT_WEST`). `MS_ITEM.cs` joins `ITEM_MAST ⨝ PRODUCT_MAST ⨝ GROUP_MAST`.
- **Auto Item** bulk-inserts many `ITEM_MAST` rows (one per ticked Product × the chosen Group). `MS_AUTO_ITEM.cs`: reads `GR_CODE, IT_CODE, IT_NAME, DISC_PRC, … FROM ITEM_MAST … WHERE … GR_CODE = …`.
- **No ledger / no stock at creation.** Downstream, the **Group's `SALE_AC`/`PURC_AC`** drive ledger posting on sale/purchase, and `GR_TYPE`/`GR_TOUCH`/`MELTING_PRC` drive fine valuation (**fine = net × touch / 100**).

### 4.5 Cross-module connections
- **Item = Product × Group.** Group's Sales/Purchase accounts point at `AC_MAST` (e.g. `SALES GOLD A/C`, `PURCHASE GOLD A/C`). Items feed **every** stock/transaction screen — Tag Opening, Item Opening, Sales, Purchase, Manufacturing. `IT_TYPE (G/S)` + touch feed all fine-weight math.

### 4.6 Web parity
- **Routes:** `/masters/products` (`PRODUCT_MAST`), `/masters/groups` (`GROUP_MAST`), `/masters/items` (`ITEM_MAST`). `GROUP_MAST_CONFIG.formFields` match the desktop (`Group Code, Group Name, Item Type (G/S), Rate Touch %, Purchase Touch %, Melting %, Wastage %, Sales A/c, Purchase A/c, HSN Code, Tax %, Rate Display`). `ITEM_MAST_CONFIG.formFields` match (`Item Code, Item Name, Product, Group, Metal (G/S), Touch %, Wastage %, Labour Rate, Labour %, HSN Code, Unit, Rate Per, Item Rate, Other Rate, Conversion %, Discount %, Bag Weight, Safe, Stock Display, Min Stock`).
- **Parity: Matches** for Product / Group / Item single-record CRUD. **Gap:** no **Auto Item** (`MS_AUTO_ITEM`) equivalent — the "pick a group → tick products (Y/N) → bulk-generate items" convenience is absent; web items are created one at a time. **To-verify:** add an auto-item/bulk route to reach exact parity.

---

## 5. Barcoding / Opening Stock (Item Opening + Tag Opening) — `3eHsCZC1gu4`

### 5.1 Screen titles + menu paths
- **Item Opening** (bulk/loose stock) — `Master → Item Opening`. Desktop `TR_ITM_OPBL.cs`.
- **Tag Opening** ("Opening Stock", per-piece barcoding) — `Master → Tag Opening`. Desktop `TR_TAG_OPBL.cs`.
- **Stock views** — **F3 Stock Report** (item-wise) and **Tag-wise Stock Report** (`RP_STOCK` / `RP_TAG`). Narration: *"आइटम ओपनिंग में बल्क का स्टॉक … टैग ओपनिंग में बारकोडिंग वाला स्टॉक"* — two ways to load opening stock.

### 5.2 Header fields + grids
- **Item Opening (bulk):** select an item → enter bulk quantity/weight (demo `999 GOLD`, `300 g` fine). Simple line entry; Save.
- **Tag Opening / "Opening Stock"** (kf_008): header **Vch No** (auto, `00002`), **Vch Date** + weekday + time, **Print file** (`QrPrint10` dropdown) + **Set**.
  - **Main tag grid columns:** **`Sr | ItCode | TagNo | Counter | Design | Size | Pcs | GrWt | LsWt | NetWt | Lbr% | LType | LbrRate | LbrAmt | OthAmt | PrCost | Mrp | Image | KrCode`**. A **Total** row totals Pcs/GrWt/LsWt/NetWt/LbrAmt/OthAmt/…
  - **Item sub-grid columns:** **`Sr | ItCode | ItName | Pcs | KrWt | Weight | Con% | P/W | Rate | ItAmt | NetAmt`**.
  - **Footer:** **Employe** (code + name), **Vch**, **Lable Skip** (checkbox), camera/image/scissors icons.
- **Barcode label print** (kf_006): per tag — barcode no (`CHG00001`), `G.12.650` (gross), `N.12.650` (net), `HM/300` (hallmark chrg), `RD/600` (rhodium chrg), `LC:14.00%` (labour % ) / `LP:600` (labour per-gram), firm `DATACARE SOFTECH`, product `DG`, group `916`, and a **QR code** (QR/barcode both selectable).
- **Tag Stock Report** (kf_009): filters **Date** (from/to), **Tag Search**, **Item Type** (`Gold`), **Product**, **Group**, **TagNo**; view tabs **`In Tag | Out Tag | Stock Tag | Mrp Tag | Apr Panding | All Tag`**; grid columns **`Vch Typ | Vch No | Stk Date | Tag No | It Code | Counter | Design | Size | Qty | Pcs | Grwt | Net Wt | Lbr Rate | Lbrprc | Lbr Amt | Oth Amt | Mrp | Kr Name | Tag Id`** (rows `OPSTK 00001 CHG00001 CH916 001 … 12.65 …`, `OPSTK 00001 CHG00002 CH916 001 … 15 …`). Footer buttons **Summ | Print | Excel** (kf_010 shows Excel export).

### 5.3 Operator workflow (from narration)
- **Item Opening:** select item → put bulk stock (`999 GOLD 300 g`) → **Save** → OK. View via **F3 → Item wise** (columns show Opening / In / Out / Closing).
- **Tag Opening:** Enter×5 → product list → pick item (`Chain → 916`) → **barcode auto-generates** `CHG00001` (*"बारकोड नंबर ऑटोमेटिकली जनरेट हो जाएगा … CHG 00001"*) → **Counter** (pick, or default **Main Stock**, e.g. `001`; can create a counter) → **Design No** → **Size** → **Weight** (`12.650`) → cursor drops to other charges → **Hallmark Charges** (`300`) → **Rhodium Charges** (`600`) → **Less Wt** → **Net Wt** → **Making Charge %** (`14%`) → **L Type** (**N**=net default / **G**=gross / **P**=piece) → **Labour Rate** (per gram) *or* **Labour Amount** (lump) → **Purchase Cost MRP** (for MRP-priced items) → **Image** (webcam/attach) → **Karigar Code** (supplier/karigar short-code, for return tracing) → next tag `CHG00002`. **View/Print** → QR/barcode label.
- **Verify:** **F3 → Item wise** then **Tag-wise Stock Report** (`Stock Only`); filter by Chain/Product/Group/TagNo; **Print** (with bifurcation) or **Excel** export.

### 5.4 Effects (tables / ledger / stock)
- **Tag Opening (`TR_TAG_OPBL`)** → per tag: **`BAR_DETL`** (tag master: `TAG_NO, IT_CODE, GrWt, NetWt, LessWt, Touch, Fine, making %, labour, hallmark/rhodium (`OthAmt`), MRP, PrCost, karigar, design, size, counter`), **`BAR_IDTL`** (item sub-detail), and a **`MAIN_STOCK`** in-movement (`VCH_TYPE 'TAGOP'`, `BOOK_NAME 'TAG OPBL'`, `TR_TYPE 'P'`, `ITM_SIGN '+'` ⇒ **signed stock IN**), plus a `TGEN`/`'TAG GEN'` row. Barcode number is auto-allocated (`SRNO_MAST.TAG_SRNO`). **`fine = NetWt × Touch / 100`**. **No money ledger** (pure inventory opening). (Confirmed by web `stock/stock.ts` `tagOpening`, which mirrors this desktop footprint; `TR_TAG_OPBL.cs` reads `ITEM_MAST` and `AC_MAST` (`AC_SHORT` karigar) for the lookups.)
- **Item Opening (`TR_ITM_OPBL`)** → **`ITM_OPBL`** row + **`MAIN_STOCK`** in-movement (`VCH_TYPE 'ITOBL'`, `BOOK_NAME 'ITM OPBL'`, `TR_TYPE 'P'`, `ITM_SIGN '+'`, `TAG_NO 'N'`). No money ledger.
- **Counter** master = `TABLE_MAST` (Counter `001` = Main Stock in the demo).
- **Stock reports** read `MAIN_STOCK` (signed net) and `BAR_DETL` (on-hand = tag exists in `BAR_DETL` AND no `MAIN_STOCK '-'` out-movement).

### 5.5 Cross-module connections
- Depends on **Item** (`ITEM_MAST`) + Product/Group, **Counter** (`TABLE_MAST`), and **Karigar** (`AC_MAST.AC_SHORT`). Feeds **Sales** (tag scan reduces stock), all **Stock reports**, and downstream **Tag Split / Tag Cancel / Tag Weight-Diff / Tag Transfer**.

### 5.6 Web parity
- **Bulk:** `/txn/item-opening` → `POST /stock/item-opening` → `itemOpening` (`ITM_OPBL` + `MAIN_STOCK 'ITOBL' '+'`). Web grid: **Item, Pcs, Gross, Net, Touch, Fine (=net×touch/100, computed), Rate** — **matches** the bulk desktop flow (incl. the `fine = net × touch / 100` note on-screen).
- **Tag:** `/txn/tag-opening` → `POST /stock/tag-opening` → `tagOpening` (`BAR_DETL` + `BAR_IDTL` + `MAIN_STOCK 'TAGOP'`). Core posting **matches**.
- **Stock view:** `/txn/stock` → `stock/stock.ts` (on-hand from `MAIN_STOCK`/`BAR_DETL`).
- **Parity: Partial.** Postings are correct, but the web tag-opening grid is **minimal** (`Tag No, Item, Pcs, Gross Wt, Net Wt, Touch %, Rate, MRP`) versus the desktop's rich set (`Counter, Design, Size, LsWt, Lbr%, LType, LbrRate, LbrAmt, OthAmt (=hallmark+rhodium), PrCost, Image, KrCode` + item sub-grid). **Gaps:** (a) web **tag number is user-entered** whereas desktop **auto-generates** `CHG00001`; (b) no **QR/barcode label print** (`QrPrint10`); (c) no **Counter** master picker, per-tag **Image**, or **Karigar Code**; (d) the **Tag Stock Report** tabs (`In/Out/Stock/Mrp/Apr Panding/All Tag`), filters and Excel export are not reproduced by the simple `/txn/stock` view. **To-verify:** auto tag-number sequence + label printing for exact parity.

---

## 6. Data Backup — `vLIK-w9pFlY`

### 6.1 Screen title + menu path
- **Backup Data** — `Company → Data Backup` (second-to-last in the Company sidebar; kf_004, kf_006). Narration: *"कंपनी मेनू … डेटा बैकअप"*. Desktop `UT_BKP.cs` (form title bar reads `Backup`, header label `Backup Data`).

### 6.2 Header fields + controls
- **Backup Data form** (kf_006, kf_009): **Select** button (opens a Windows folder browser — `XtraFolderBrowserDialog`), **Backup Path** field (`C:\` → after Select, `D:\`), a **progress bar**, and the **Backup** button. Desktop also has a **Restore** button (`BtnRestore`). Action bar Print/Save/Cancel/Delete/Exit.
- **Folder browser** (narration): `This PC` → choose any drive (incl. a **pen drive**). **Confirm prompt** (kf_012): **"Do your Want to Take Backup Now"** → **Yes / No**.
- **Output** (kf_015, D: drive): `Next21_120521_17.BAK` (7,445 KB) + `NextMain.BAK` (2,903 KB) — **date-stamped** (`120521` = 12/05/21).

### 6.3 Operator workflow (from narration)
1. `Company → Data Backup` → **Select** → folder browser → pick a drive (demo `D:`) → **OK** ⇒ **Backup Path** set.
2. Click **Backup** → progress → **"Backup Process Complete."** → **OK** (*"बैकअप प्रोसेस कंप्लीट"*).
3. Alternative: on working/exit the app prompts **"Do your Want to Take Backup Now" → Yes** ⇒ same backup.
4. Open the drive to see the **date-wise** `.BAK` files (`Next21_120521_17.BAK`, `NextMain.BAK`).

### 6.4 Effects (tables / mechanism)
- Runs **native SQL Server** backups (`UT_BKP.cs`):
  - `BACKUP DATABASE <SqlData> TO DISK ='<path>\Next<YY>_<ddMMyy_HH>.BAK'` — the **company data** DB (`<YY>` = `Mid(CO_YEAR,3,2)` → `21`; file e.g. `Next21_120521_17.BAK`).
  - `BACKUP DATABASE <SqlMain> TO DISK ='<path>\NextMain.BAK'` — the **NextMain master** DB.
- **Backup path is persisted** in the registry: `NEXT SOFTWARE\BACKUP_DATABASE\BACKUP_PATH`.
- Guards: **print-rights** check (*"You Have No Print Rights…"*), and *"Please Select Path and Try"* if no path.
- **Restore** = detach/attach (`USE [master] ALTER DATABASE NextMain SET SINGLE_USER … sp_detach_db …` → *"De-Attach iS Complite"*).
- Operates on **database files**, not app tables — it captures **all** companies/years in the SQL instance.

### 6.5 Cross-module connections
- Whole-database operation; independent of any single master/transaction. The **exit hook** ("take backup now?") ties it into normal usage. `NextMain` holds cross-company/system data; `<SqlData>` holds the working company's data.

### 6.6 Web parity
- **Route:** `/backup` → `GET /api/backup` → **`ops/backup.ts` `backupCompany`** — exports the tenant's tables (`CO_MAST, AC_MAST, ITEM_MAST, GROUP_MAST, PRODUCT_MAST, RATE_MAST, TAX_MAST, BOOK_DATA, EMP_MAST, LOCT_MAST, SL_DATA, SL_DETL, SL_IDTL, SL_DETL_RTN, PR_DATA, PR_DETL, AC_DATA, TAX_DATA, POINT_MEMB, POINT_DATA, KR_DATA, KR_DETL, SL_ORD_DATA, BILL_OS_DATA, TAG_STOCK`) as a downloadable **JSON** file. Full physical backups use `deploy/backup.sh` (**`pg_dump`** cron).
- **Parity: Partial (different mechanism).** Both provide a backup, but: web = **per-company logical JSON** (+ server-side `pg_dump`) vs desktop = **native SQL Server `.BAK`** written to a **user-chosen drive/pen-drive** with an in-app **Restore**. **Gaps:** no interactive drive/path picker, no `.BAK` format, no in-app Restore, no per-date `.BAK` naming, and web is single-tenant (one company) whereas the desktop `.BAK` covers the whole instance (`NextMain` + company DB). **To-verify:** whether a "download to chosen location / restore" UX is required for parity, or whether the `pg_dump` cron + JSON export is deemed sufficient.

---

## Appendix — key IDs & literals (for exact web forms)

- **Account groups (`AC_GROUP.GrCod`):** `03 SECURED LOAN, 04 UNSECURED LOAN, 05 VEPARI (supplier), 06 SUNDRY CREDITORS LABOUR, 07 DEPOSIT-LIABILITIES, 10 KARIGAR SUNDRY CR (karigar), 11 PROVISION, 12 TAX LIABLITIES, 13 FIXED ASSETS, 14 INVESTMENT, 15 LOANS & ADVANCES ASSETS, 16 DEPOSITS-ASSETS, 17 CLOSING STOCK ASSETS, 18 CURRENT ASSETS, 20 CUSTOMER`.
- **Seeded system accounts (Party Master left grid):** `00001 CASH ON HAND, 00002 CAPITAL A/C, 00003 SALES GOLD A/C, 00004 SALES SILVER A/C, 00005 SALES OLD GOLD A/C, 00006 SALES OLD SILVER A/C, 00007 SALES OTHER A/C, 00008 PURCHASE GOLD A/C, 00009 PURCHASE SILVER A/C, 00010 PURCHASE OLD GOLD A/C`.
- **Products (demo):** `CH CHAIN, LR LADIES RING, MS MANGALSUTRA` (+ preset `DM,EM,FN,HM,OD,OG,OR,OS,OT,RD,SN`).
- **Groups (demo):** `916 (916 Gold Ornaments), 20C (20 Carat Gold Ornaments), 925 (925 Silver)`; Item Type `Gold`/`Silver`.
- **Tag/stock movement types:** Tag Opening `VCH_TYPE 'TAGOP' / BOOK_NAME 'TAG OPBL' / TR_TYPE 'P' / ITM_SIGN '+'`; Item Opening `'ITOBL' / 'ITM OPBL' / 'P' / '+'`. Report tag type shown as `OPSTK`.
- **Fine formula:** `fine = NetWt × Touch / 100` (metal weight); signed stock via `ITM_SIGN '+'`(in) / `'-'`(out).
- **Backup file naming:** `Next<YY>_<ddMMyy_HH>.BAK` (company data) + `NextMain.BAK` (master DB); path in registry `NEXT SOFTWARE\BACKUP_DATABASE\BACKUP_PATH`.

_Sources: `transcript.sarvam.txt` (all 6) · keyframes cited inline · `extracted_code/DataCareNext/DataCareNext/{MS_COMPANY,MS_YEAR,MS_OPNCOMP,MS_USER,MDI_FORM,MS_ACCT,MS_PRODUCT,MS_GROUP,MS_ITEM,MS_AUTO_ITEM,TR_TAG_OPBL,TR_ITM_OPBL,UT_BKP}.cs` · `web/apps/api/src/modules/{masters/master.service,masters/configs,masters/openingBalance,finance/acOpening,ops/seedCompany,ops/backup,rbac/users,rbac/formRights,stock/stock}.ts` · `web/apps/web/app/(app)/{admin/provision,admin/users,masters/[name],masters/opening-balance,backup,txn/tag-opening,txn/item-opening}/page.tsx`._
