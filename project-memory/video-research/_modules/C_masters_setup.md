# C_masters_setup — Masters & Setup UX-parity map (desktop golden master → web)

_Phase D video-research. Desktop = DataCareNext tutorial keyframes (1280px screens) + Hindi narration.
Web = `web/apps/web/app/(app)/{masters,admin,backup,txn}`. Spec cross-ref =
`web-implementation-spec/03_Modules/1_Masters/` + `13_Utilities…/BACKUP_RESTORE.md` +
`04_Cross_Cutting_Engines/auth-and-rbac.md`._

**Corpus:** `project-memory/video-research/master/<id>/{transcript.txt,keyframes/kf_*.jpg}`
**Frames sampled** (evenly): Company `VnXnYL5F6VE` 1/2/3/4/5/6/8 · User `X-ba6-Q_L1g` 10/20/28/38/46 ·
Account `NyEAB-xn7Hw` 5/11/17/22/27 · Item `WmJ9la4_FP4` 8/20/32/44/56 · Barcoding `3eHsCZC1gu4`
2/3/6/8/9 · Backup `vLIK-w9pFlY` 3/7/10/13/16.

> **Headline finding:** the desktop masters are dense, multi-tab, picker-driven forms with auto-codes,
> opening balances, posting-account wiring, photos and per-form Print. The web rebuilds **~32 masters
> as ONE generic-CRUD engine** (`masters/[name]/page.tsx` driven by `configs.ts`) whose New form
> renders **only `requiredColumns`** — for `accounts` that is just `CO_CODE/AC_CODE/AC_NAME`, for
> `items` just `CO_CODE/IT_CODE/IT_NAME`. So virtually every business field a jeweller fills on the
> desktop (group, touch, HSN, posting A/cs, GSTIN, address, opening balance, labour, MRP, photo…) is
> **unreachable in the web UI**. The two *setup* forms (Company, Year) **seed dozens of tables** on the
> desktop; the web maps them to bare CRUD slugs that seed **nothing**. User rights are a per-form
> `{View,Edit,Delete,Print}` matrix on the desktop vs **3 global booleans** on the web. Backup writes
> date-stamped SQL `.BAK` to any drive vs a single JSON download.

---

## Cross-cutting gaps (apply to most/all masters)

- [ ] **No UPDATE path in the masters engine** (highest-priority, confirmed in `master.service.ts` + README §2/§8): only `create/delete/list/import`. Desktop edits a row **in place** (double-click record → change → Save). On the web, editing means delete-then-create, which the **referenced-delete guard blocks** for any account/item/group already used in a transaction → such rows are effectively frozen.
- [ ] **Generic form exposes only `requiredColumns`** (`masters/[name]/page.tsx` maps `meta.requiredColumns` → inputs). Every non-key field (group, GST, touch, HSN, posting A/cs, address, opening bal, labour…) has no input. The Edit panel shows only the first **9** returned columns.
- [ ] **No code auto-allocation.** Desktop auto-generates `Ac Code / Pr Code / Gr Code / Item Code / Tag No` (e.g. max+1 `00000`, or `Pr+Gr → CH916`, or `CHG00001`). Web makes the user type the business key.
- [ ] **No reference-help (F1/Enter) pickers inside master forms.** Desktop pops a `DataCare Help` grid for Group / State / Company / Product (kf_011 account-group, kf_005 company). Web master forms are bare text inputs (the `LookupPicker` exists for txn screens, not wired into the generic master form).
- [ ] **No left record grid + double-click-to-edit.** Every desktop master has a `SEARCH NAME-MOBILE` / `SEARCH RECORD` grid on the left (kf_005, kf_008, kf_044); the web table shows ≤9 cols + Edit/Del buttons only.
- [ ] **No image/photo capture** (camera/gallery/scissors icons on Party kf_005, Item, Tag kf_006). **No per-form Print** (desktop Print button on every master, gated by `USER_PRINT`).
- [ ] **No live-rate status bar** (`Fine Gold 49368 | Fine Silver 69917 | Rate Date 18-04-2021 | Service End`) present on every desktop frame.

---

## 1. Company Create / Year Create (setup, seeding) — `VnXnYL5F6VE` → `masters/companies` + `masters/years` (no setup service)

### (1) DESKTOP LAYOUT
- Top menu **Company** → left sidebar: `Company` · `Year Create` · `Balance TrFr` · `Books` · `User Create` · `Account Group` · `Trade Master` · `Setting` · `Setting Main` · `Data Refresh` · `Data Backup` · `Year Select` (kf_002).
- **Company form (CO_MAST)** — *from narration* (sampled frames landed on year-create/login, not the form): `Comp Code`[auto] · `Company Name` · `Country` · `State`[picker→Gujarat] · `City` · `Work Type`[Retail] · `Metal Traffic`[Gold/Silver] · Tax `GSTIN` · `Bank Detail`. F1 reference-help lists existing companies for edit.
- **Year Create form** (kf_002): `Create New [2021-2022]` · `Opening Date [01/04/2021]` → on save: *"All Master And Parameter are Created…Now ReOpen Software"* dialog.
- **Company picker on launch** (kf_004/006): `Company Name`[code] · `Location Name`[00] · `Exit`; F1 `DataCare Help` lists `Code|Name|Address` → `01 DATACARE SOFTECH | 505 SHIVALIK SATYAMEV`, `02 ABC JEWELLERS` (kf_005). After select → app reopens into `02 - ABC JEWELLERS` with full txn sidebar (kf_008).

### (2) WORKFLOW + effects
Company → *A Company* → reference-help shows existing companies, double-click to edit name/address. New: code auto, type name (ABC), country, state Gujarat, city, work-type retail, metal Gold/Silver, GSTIN, bank → Save → message → OK → **auto-opens Account Group** (Enter×3 to seed) → **Year auto-created** → *reopen software* → login picker → choose `02 ABC JEWELLERS` → now active. Net effect: Company+Year **provision and seed** the chart of accounts, groups, books, taxes, settings (a whole working company), then force a restart.

### (3) CURRENT WEB STATE
- `companies` → `CO_MAST_CONFIG` (key `CO_CODE`, required `CO_CODE,CO_NAME`); `years` → `YEAR_MAST_CONFIG` (key `CO_CODE,CO_YEAR`). Both run through the **generic** `masters/[name]/page.tsx` → New form shows only required cols.
- **Creating a `companies` row seeds nothing** — one `CO_MAST` insert, no chart of accounts / groups / books / taxes / settings. Spec README §3c marks `MS_COMPANY`/`MS_YEAR` as **setup forms not yet implemented as services** (🟦). Auth can *select* a company/year (`/context/select`) but cannot *create/seed* one.

### (4) CONCRETE GAPS
- [ ] No **company-provisioning service** that seeds the system accounts/groups/books/taxes/settings (desktop "All Master And Parameter are Created"). An empty company breaks every downstream txn (no `AC_CODE<00101` system accounts for `buildSaleLedger`).
- [ ] No **Year-Create service** that provisions a `CO_YEAR` partition + seeds ~17 tables (MS_YEAR deep-dive); `years` is bare CRUD.
- [ ] No **company-master form** for `Country / State / City / Work Type (Retail/Wholesale) / Metal Traffic (Gold/Silver) / GSTIN / Bank`.
- [ ] No **post-create reopen/refresh** + auto **Account-Group seed** step.
- [ ] No web form for the other Company-menu items: **Balance TrFr, Trade Master, Books, Data Refresh, Setting Main, Account Group (UI)**.

---

## 2. User Create + Rights (MS_USER) — `X-ba6-Q_L1g` → `admin/users/page.tsx` + rbac

### (1) DESKTOP LAYOUT
- **Company → User Create** (kf_010). Top: `User Name`[▾ existing users]. Right panel: `Create New`[USER 1] · `Old Password` · `New Password` · `Confirm` · `User Type`[User/Admin ▾]. `[Update User Right]` button. Print/Save/Cancel/Delete/Exit.
- **Rights matrix** (appears when a user is selected): grid `SrNo | Main Menu | Sub Menu | View | Edit | Delete | Print` — **one row per form** across every menu, **4 independent checkboxes each**.
  - Company rows (kf_020): Company, Year Create, Balance TrFr, Books, User Create, Account Group, Trade Master, Setting, Setting Main, Location, Data Refresh, Data Backup, Main Menu, Admin Setting, Year Select.
  - Transaction rows (kf_028): Purchase, Purchase Rtn, Sales Order, **Sales `[View✓ Edit☐ Delete☐ Print✓]`**, Sales Return, Wh Sales, Cash Received, Cash Payment, Bank Received, Bank Payment, Contra Entry, Rate Cut; Other → Daily Rate, Only Tag Entry; Master → Conversation (row 38).

### (2) WORKFLOW + effects
Select/create user, set password + type → tick/untick View/Edit/Delete/Print **per form** → `[Update User Right]` saves. Effects (narration + kf_046 = logged in as `USER 1`): untick Company.View → *"you do not have the right to open the company"*; Sales Edit/Delete off → user can **create + print** a sale/estimate but editing an existing bill → *"You have no rights"*; admin can change everything. Semantics: **View = access/nav-visibility, Edit = create/update, Delete, Print** — per individual form.

### (3) CURRENT WEB STATE
`admin/users/page.tsx` + `auth-and-rbac.md`: New user = `CO_CODE, loginName, password, role[ADMIN/USER]`. Rights = **3 global per-user booleans** `USER_UPDATE` (create/update) / `USER_DELETE` / `USER_PRINT` + `LOGIN_CATG` Admin/User (admin ⇒ all rights, boxes disabled-on). Enforced by `assertRight('create'|'delete'|'print')` on every mutation; nav filtered server-side by `filterNav(rights)`. **No per-form/per-menu rows.**

### (4) CONCRETE GAPS
- [ ] No **per-form rights matrix** — web has 3 global flags vs desktop `{View,Edit,Delete,Print}` × **every menu/submenu**. Cannot grant "Sales but not Purchase", "Reports view-only", etc.
- [ ] No **per-form View/access right** → web nav filtering is all-or-nothing off the 3 globals; desktop hides individual forms a user lacks View on.
- [ ] **Create vs Edit not separable** — desktop "Edit" (modify existing) is its own checkbox; web folds create+update into one `USER_UPDATE`.
- [ ] No **edit-user / change-password / old-password** flow on the web user form (create-only).
- [ ] No **`MENU_DATA`/`USER_SET` per-form persistence** that the matrix writes to (the substrate for per-screen rights + nav).

---

## 3. Account Create (MS_ACCT — Party Master) — `NyEAB-xn7Hw` → `masters/accounts` (AC_MAST)

### (1) DESKTOP LAYOUT
- Title **Party Master**. Left: `SEARCH NAME - MOBILE` grid `Code|Name|Mobile` listing the seeded system accounts `00001 CASH ON HAND, 00002 CAPITAL A/C, 00003 SALES GOLD A/C … 00010 PURCHASE OLD GOLD A/C` (the `AC_CODE<00101` defaults) (kf_005).
- Header: `Ac Code`[000201]+`F1` · `[D][S]` buttons.
- **Tab — Company Detail** (kf_005/017/022): `Ac Name` · `Ac Group`[code+name picker, + button] · `Mobile No` · `Phone No` · `Con Person` · `Ac Short` · `Address1/2/3` · `City`[▾]+`Pin Code` · `City Area`[▾] · `Country`[▾] · `Gst No` + `[Local ▾]`(GST type) · `Pan No` · `State`[▾ Gujarat] · `District`[▾] · `Email`.
- **Opening Balance** box: `Amount`[+ Cr/Dr] · `Gold`[+ Cr/Dr] · `Silver`[+ Cr/Dr] (kf_027 shows `Amount 25000.00 Dr`); `Last Visit`; `Ledger Date`; camera/gallery/scissors (party photo).
- **Tab — Other Detail** (kf_027): `Mobile No2` · `Phone No2` · `Adhar No` · `Bank` · `Branch` · `Bank AcNo` · `ISFC Code` · `Ref By`[code+name] · `Birth Date` · `Anv Date` · `L Birth` · `Cr Day` · `Dpc %` · `Khata No`.
- **Tab — Family Detl** (3rd tab + ▾ for more).
- `Ac Group` picker (kf_011) `DataCare Help` = `GrCod|AcGroup|MainGroup`: `00 CAPITAL ACCOUNT/SOURCES OF FUNDS · 05 VEPARI/CURRENT LIABILITIES · 06 SUNDRY CREDITORS LABOUR · 20 CUSTOMER` — each group rolls up to a **MainGroup**.
- Toolbar: Print/Save/Cancel/Delete/Exit.

### (2) WORKFLOW + effects
Master → *A Party* → Party Master. AcCode auto. Type Ac Name (RAHUL JI). Enter `Ac Group` → picker → pick `05 VEPARI` (supplier) / `20 CUSTOMER` (kf_017). Mobile (kf_022), contact, address, city. Opening Balance `Amount 25000 Dr` + Gold/Silver metal opening (kf_027). Other Detail bank/Aadhaar/birthday/credit-days. Save → account created. (Narration: a karigar/customer is classified via group + train-no/AC_TYPE.)

### (3) CURRENT WEB STATE
`masters/accounts` → `AC_MAST_CONFIG`: key `CO_CODE,AC_CODE`, **required `CO_CODE,AC_CODE,AC_NAME` only**. Generic New form renders exactly those 3 inputs (`CO_CODE` defaulted `01`). Edit shows first 9 returned cols. refs→`AC_DATA` delete-guard; no update route. `accounts`=`customers` (same table, AC_TYPE filter). MS_ACCT spec documents the full ~50-col `AC_MAST` INSERT, but the engine requires/exposes only the 3.

### (4) CONCRETE GAPS
- [ ] New-account form exposes only `AC_CODE/AC_NAME` — **missing** `AC_GR`(+MainGroup), GST type, GSTIN, PAN, Aadhaar, full address (Add1-3 / City / Area / Pin / State / District / Country), Mobile/Phone (×2), Contact person, Short name, Ref-by, Cr-days, Int%, DPC%, Bank (name/branch/acno/IFSC), birthday/anniversary, Khata No.
- [ ] No **Opening Balance** capture (Amount Dr/Cr + **Gold/Silver metal opening** Dr/Cr) — desktop seeds `OP_DATA` from this form; web has neither field nor `OP_DATA` write.
- [ ] No **Ac Group picker** with Group→MainGroup classification (sets `AC_GR`/`AC_MAIN_GR` that the trial balance rolls up) — web cannot even set `AC_GR`.
- [ ] No **AcCode auto-allocation** (desktop max+1 `00000`; web user must type the key).
- [ ] No **system-account protection** (`AC_CODE<00101` un-deletable/un-renamable) and no **name/short/mobile uniqueness** validations (spec §8 "port").
- [ ] No **party photo**, no **F1 reference grid**, no **Other/Family tabs**, no per-form **Print**.
- [ ] No **edit-in-place** (the `AC_DATA` referenced-delete guard blocks delete+recreate for any used account).

---

## 4. Item Create (MS_PRODUCT / MS_GROUP / MS_ITEM / MS_AUTO_ITEM) — `WmJ9la4_FP4` → `masters/{products,groups,items}`

### (1) DESKTOP LAYOUT
- **Product** (kf_008): title "Product". Grid `Code|Name` (DM DIAMOND, CH CHAIN, HM HALL MARK CHARGES, RD RODIAM CHARGES, OG OLD GOLD…). Form: `Code`[CH, 2-char] · `Name`[CHAIN]. (`PRODUCT_MAST` PR_CODE/PR_NAME.)
- **Item Group Master** (kf_020/032): `Gr Code`[916] · `Gr Name`[916 GOLD ORNAMENTS] · `Item Type`[Gold ▾]+code · `Gr Rate Touch` + `Purc Touch` · `Melting %` + `West %`(wastage) · `Sales Ac`[00003 SALES GOLD A/C] · `Purchase Ac`[00008 PURCHASE GOLD A/C] · `Hsn Code` · `Rate Tax %` · ☐`Rate Display In Main Screen`.
- **Item Master** (kf_044): `Pr Code`[CH CHAIN] · `Gr Code`[916…]+`GO` · `Item Code`[**CH916 auto**] + `Stk Display`[Yes ▾] · `Item Name`[CHAIN 916] · `Safe Name`[MAIN ▾] · `Hsn Code` · `Unit Name`[GMS ▾] · `Rate Per`[Gram Wise ▾] · `Labour Rate` · `Labour %` · `Conversion` · `Discount %` · `Item Rate` · `Oth itm Rate` · `Bag Weight`.
- **Auto Item** (kf_056): `Group Code`[+ boxes]; grid `Sr|Pr Code|Pr Name|MinStk|Y/N` — bulk-generate items by ticking products per group.

### (2) WORKFLOW + effects
Master → **Product** (create categories: chain, ladies ring, mangalsutra…). → **Group**: code (916), name, Item Type Gold/Silver, touch/melting/wastage, **Sales A/c + Purchase A/c posting links**, HSN. → **Item**: pick Product + Group → ItemCode auto `CH916`, name auto `CHAIN 916`, safe/unit/rate-per/labour. OR **Auto Item**: pick group, tick Yes/No per product to mass-create the item matrix (narration: chain Yes, mangalsutra No for 925 silver). Verify in Item master (`CH916` etc. created).

### (3) CURRENT WEB STATE
`items` → `ITEM_MAST_CONFIG` required `CO_CODE,IT_CODE,IT_NAME` only; refs→`SL_DETL`. `products` → `PRODUCT_MAST` (req `CO_CODE,PR_CODE,PR_NAME`). `groups` → `GROUP_MAST` (req `CO_CODE,GR_CODE,GR_NAME`). All via the generic engine → New form exposes only required cols. Spec marks items/groups/products 🟦 ("form does more than single-table CRUD"), but the **web form does single-table CRUD only**.

### (4) CONCRETE GAPS
- [ ] Item New form exposes only `IT_CODE/IT_NAME` — **missing** Product link, Group link, ItemCode auto-derive (`Pr+Gr→CH916`), Safe/warehouse, HSN, Unit, Rate-Per, Labour Rate, Labour %, Conversion, Discount %, Item Rate, Oth-item Rate, Bag Weight, Stk-Display.
- [ ] Group New form exposes only `GR_CODE/GR_NAME` — **missing** Item Type (Gold/Silver), Gr-Rate-Touch, Purc-Touch, Melting %, **Wastage %**, **Sales A/c + Purchase A/c posting links**, HSN, Rate-Tax %, Rate-Display flag. These drive sale/purchase ledger posting + metal valuation → unreachable.
- [ ] No **Auto-Item bulk generator** (MS_AUTO_ITEM, ⬛ in spec) — the desktop's primary way to build the product×group item matrix.
- [ ] No **code auto-allocation** (Pr/Gr 2-char; ItemCode = Pr+Gr).
- [ ] No **`GR_NAME`→`ITEM_MAST` rename cascade**, no posting-account/touch wiring, no item **photo**, no per-form **Print**, no F1 reference grids.
- [ ] No **edit-in-place** (`SL_DETL` referenced-delete blocks delete+recreate of any sold item).

---

## 5. Barcoding / Tag Opening (Opening Stock) — `3eHsCZC1gu4` → `txn/tag-opening/page.tsx` (+ `txn/item-opening`)

### (1) DESKTOP LAYOUT
- Two stock-entry paths under Master sidebar: `Item Opening` (bulk/loose) and `Tag Opening` (barcoded); also `Counter`.
- **Item Opening** (narration): pick metal Gold → item list → bulk qty (999 Gold 300 g) → shows in Stock Report (item-wise) as opening.
- **Tag Opening / "Opening Stock"** (kf_006): header `Vch No`[00002] · `Vch Date`+weekday+time · `Print file`[QrPrint10 ▾] + `[Set]`. **Tag grid columns:** `Sr | ItCode | TagNo | Counter | Design | Size | Pcs | GrWt | LsWt | NetWt | Lbr% | LType | LbrRate | LbrAmt | OthAmt | PrCost | Mrp | Image | KrCode`. Live **QR-label preview**: `DATACARE SOFTECH / CHG00002 / G.15.000 / N.15.000 / LP 600 / DG / 916`. Lower grid `Sr|ItCode|ItName|Pcs|KrWt|Weight|Con%|P/W|Rate|ItAmt|NetAmt`. `Employe` · `Vch` · `Lable Skip` · camera/gallery/scissors. Print/Save/Cancel/Delete/Exit; ◄ ►.
- **Tag Stock Report** (kf_009): filters `Date range · Tag Search · Item Type[Gold ▾] · Product · Group · TagNo`; tabs `In Tag | Out Tag | Stock Tag | Mrp Tag | Apr Panding | All Tag`; grid `Vch Typ|Vch No|Stk Date|Tag No|It Code|Counter|Design|Size|Qty|Pcs|Grwt|Net Wt|Lbr Rate|Lbrprc|Lbr Amt|Oth Amt|Mrp|Kr Name|Tag Id`; rows e.g. `OPSTK 00001 CHG00001 CH916 001 … 12.65/12.65 … Lbr 14 … 900 … DG … 100105000001`. Summ/Print/Excel/Cancel/Delete/Exit.

### (2) WORKFLOW + effects
Tag Opening → Enter → product list → pick item (916 chain) → **TagNo auto `CHG00001`** → account/counter (counter-wise stock per account; default `Match`) → `Design No` → `Size` → `Pcs` → `GrWt` → `Touch` → other charges (Hallmark ₹300, Rhodium ₹600 → `OthAmt`) → less-wt → making % **or** labour/gram → `Help`=label tag → `PrCost`/`MRP` (MRP-only for branded) → item photo (webcam/file) → `Karigar code` (supplier traceability) → next tag (`CHG00002`). Save → View → **Print QR/barcode label** (firm, tag, gross/net, group, labour 600/g, ₹40, QR) via template (`QrPrint10`). Stock Report → tag-source → barcoding-only stock; filter; print bifurcation; Excel export.

### (3) CURRENT WEB STATE
`txn/tag-opening/page.tsx` → POST `/stock/tag-opening`: a single `Book` field + line grid `Tag No | Item | Pcs | Gross Wt | Net Wt | Touch % | Rate | MRP` + Add-tag/Load. Each tag → `BAR_DETL` + opening stock-in (`TAG_STOCK` mirror). Returns `voucher #, tags added`. `item-opening/page.tsx` is the separate bulk path. TAG_STOCK.md confirms availability primitives exist; on-hand omits **fine**.

### (4) CONCRETE GAPS
- [ ] Tag form omits **Design, Size, Counter, Lbr%/LType/LbrRate/LbrAmt, OthAmt (HM/Rhodium), PrCost, Image, KrCode** — only Pcs/GrWt/NetWt/Touch/Rate/MRP (no **LsWt** either).
- [ ] No **TagNo auto-generation** (`CHG00001`…); user types the tag.
- [ ] No **12-digit Tag Id / barcode** allocation (`100105000001`).
- [ ] No **QR/barcode label PRINT** (firm/tag/wt/group/labour/MRP) and no **print-template selector** (`QrPrint10` / `[Set]`).
- [ ] No **counter/account assignment** (counter-wise stock per account).
- [ ] No **karigar/supplier code** for return traceability; no **item photo** capture.
- [ ] No **Tag Stock Report** with In/Out/Stock/Mrp/Apr-Pending/All-Tag filters + **Excel export** + print bifurcation.
- [ ] No **MRP-only mode** toggle (branded items at MRP, skip making).
- [ ] (Spec) on-hand net omits **fine** + non-tag (lot/bulk) movements.

---

## 6. Data Backup (UT_BKP) — `vLIK-w9pFlY` → `backup/page.tsx`

### (1) DESKTOP LAYOUT
- **Company → Data Backup** → "Backup Data" screen: `[Select]` button · `Backup Path`[D:\] · `[Backup]` button (kf_013).
- `[Select]` → Windows **"Browse For Folder"** (Desktop/OneDrive/ANDROID/This PC/Libraries/Network/Control Panel/Recycle Bin/drives) → pick any drive incl. **pen drive** (kf_007).
- `[Backup]` → "DataCareNext: **Backup Process Complete**" → OK (kf_010).
- Output: date-stamped SQL Server `.BAK` on the chosen drive — `Next21_120521_17.BAK` (7,445 KB, per-year DB) + `NextMain.BAK` (2,903 KB, main DB) (kf_016).
- Second trigger (narration): on **Exit**, prompt *"do you want backup? Yes"* → same flow.

### (2) WORKFLOW + effects
Choose destination drive/folder → Backup → completes → two `.BAK` files (per-year + main) written with the date in the name. Also offered automatically on app exit.

### (3) CURRENT WEB STATE
`backup/page.tsx` + BACKUP_RESTORE.md: a single `[Download Company Backup (JSON)]` → `GET /backup` streams a per-tenant **JSON** snapshot of a curated table set (≤100k rows/table, RLS-scoped, bigint→string, binary→`[binary]`). Physical full-DB backup is **ops-only** `deploy/backup.sh` (`pg_dump -Fc`, 14-day retention, cron). **No restore endpoint** by design.

### (4) CONCRETE GAPS
- [ ] No **destination picker** (drive/folder/pen-drive) — web is a fixed browser download, not "save to my D:\ / USB".
- [ ] No **per-year + main split** or **date-stamped filename** (desktop `Next21_120521_17.BAK`).
- [ ] No **exit-time backup prompt**.
- [ ] **Format differs by design** (logical JSON vs SQL `.BAK`) — acceptable, but note images elide to `[binary]`, and physical pg_dump is ops-only (not user-driven from the app).
- [ ] No **in-app restore** (operator-only `pg_restore`) — flag if customers expect "restore my company from this file".
- [ ] No **scheduled/automatic** in-app backup surface (only server cron).

---

## Desktop screens with NO web equivalent (net-new builds)

1. **Company provisioning + Year seeding** (`MS_COMPANY`/`MS_YEAR`) — `companies`/`years` are bare CRUD that seed nothing; the desktop "creates all masters & parameters". **Blocker** for standing up a new company.
2. **Per-form rights matrix** (`MS_USER` rights, kf_020/028) — web has only 3 global flags; the `{View,Edit,Delete,Print}`×every-menu grid does not exist.
3. **Auto Item bulk generator** (`MS_AUTO_ITEM`, kf_056) — the desktop's main item-creation path.
4. **Tag Stock Report** (In/Out/Stock/Mrp/Apr-Pending/All-Tag + Excel/print, kf_009) and **QR/barcode label printing** (kf_006).
5. **Account/Group business forms** — opening-balance (Amount+Gold+Silver Dr/Cr), Ac-Group→MainGroup picker, Group posting-A/c + touch/wastage wiring; none reachable through the generic 3-field form.
6. **Backup destination picker / `.BAK`** (kf_007/016) — only a JSON download exists.
7. **Company-menu utilities** with no surface: **Balance TrFr, Trade Master, Books, Data Refresh, Setting Main, Counter**.

## Top priority order (for implementation)
1. **Masters UPDATE path** (`updateMaster` + `PUT /masters/:name`) — unblocks editing every master (cross-cutting).
2. **Field-complete master forms** (drive inputs from a per-master field schema, not just `requiredColumns`): Account (group/GST/address/opening-bal), Group (posting A/cs + touch/wastage/HSN), Item (product/group/labour/HSN/unit).
3. **Company/Year provisioning service** (seed chart of accounts/groups/books/taxes/settings) — without it new tenants are non-functional.
4. **Per-form RBAC matrix** (View/Edit/Delete/Print × menu) + MENU_DATA persistence.
5. **Barcoding tag-gen parity**: auto TagNo/Tag-Id, design/size/counter/labour/charges/MRP/photo/karigar, QR-label print, Tag Stock Report.
6. **Backup**: destination choice + date-stamped artifact (or document JSON+pg_dump as the intentional replacement).
