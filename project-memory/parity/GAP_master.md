# Parity-Gap Analysis — **master / setup** module

> Goal: make the web function EXACTLY like the desktop for the setup/master screens.
> Method: read the KB spec (`project-memory/video-research/_kb/KB_master.md`) + the actual web pages
> (`web/apps/web/app/(app)/**`), API modules (`web/apps/api/src/modules/**`), the route handlers
> (`web/apps/api/src/{app.ts,routes/txn.ts}`) and — where needed — the decompiled desktop
> (`extracted_code/DataCareNext/DataCareNext/*.cs`). Every claim below is grounded in a file I opened.
>
> Scope (6 screens): **Company Create**, **User Create + rights**, **Account/Party master (+ opening
> balance)**, **Item / Item-Group / Product (+ Auto Item)**, **Barcoding (Tag Opening + Item Opening)**,
> **Backup**.
>
> Evidence anchors read this session: `admin/provision/page.tsx`, `admin/users/page.tsx`,
> `masters/[name]/page.tsx`, `masters/opening-balance/page.tsx`, `backup/page.tsx`,
> `txn/tag-opening/page.tsx`, `txn/item-opening/page.tsx`, `utilities/year-end/page.tsx`;
> `ops/seedCompany.ts`, `ops/backup.ts`, `ops/yearEnd.ts`, `masters/master.service.ts`,
> `masters/configs.ts`, `masters/openingBalance.ts`, `finance/acOpening.ts`, `rbac/users.ts`,
> `rbac/formRights.ts`, `stock/stock.ts`; `app.ts`, `routes/txn.ts`; desktop `MS_COMPANY.cs`,
> `TR_TAG_OPBL.cs`, `MS_ACCT.cs`, `MS_USER.cs`.

---

## Cross-cutting finding (applies to every master screen)

The generic master form `masters/[name]/page.tsx` renders **only `<input type=text|number>`** for every
field (it maps `meta.formFields` → plain inputs; keys become `*`). It has **no lookup pickers and no
dropdowns**. The desktop, by contrast, opens a **"DataCare Help" grid** on Enter for every *code* field
(Account Group, Product, Group, Sales/Purchase A/c, State, Counter, Karigar) and uses **combo dropdowns**
for enum fields (Work Type, Metal Type, Item Type, GST Type, Labour Type). Only two web pages use the
`LookupPicker` component at all (`masters/opening-balance` and some `txn/*` pages).

Consequently **every "pick a code" gap below shares one root cause**: `FormField` in
`master.service.ts` supports only `type?: 'text' | 'number'`, and the generic form cannot render a
select or a lookup. Fixing this once (add `type: 'select' | 'lookup'` + options/entity to `FormField`,
and teach `masters/[name]/page.tsx` to render `<select>` / `LookupPicker`) unblocks the AC_GR /
PR_CODE / GR_CODE / SALE_AC / PURC_AC / STATE / Counter / Karigar gaps together. This is the single
highest-leverage backend+frontend change for the module — referenced as **[Lookup infra]** below.

---

## 1. Company Create  (desktop `MS_COMPANY` / `MS_YEAR`; menu Company → Company / Year Create)

**Desktop spec.** Full Company Master form → `CO_MAST`: Code (auto), Name, Short Name, Address1/2/3,
Country, **State (Enter → state list)** + State Code, City, Pin, Phone/Phone2, Mobile/Mobile2, Email,
Jurisdiction, **Work Type (Retail/Wholesale)**, **Metal Type (Gold/Silver/Other)**, GST No, CST No,
PAN, Dhiran No, Bank Name/Branch/AcNo/RTGS(IFSC), CO_TYPE. On save → **Year Create** auto-opens
(`YEAR_MAST`: Create-New `2021-2022`, **Opening Date 01/04/2021**, Close Date, Year Month) which
**auto-seeds all masters + parameters + a default login** and prompts *"All Master And Parameter are
Created…Now ReOpen Software"*. Company-select login popup lists companies (**Code | Name | Address**).
No ledger/stock.

**Web now.**
- `admin/provision/page.tsx` — captures **only `coCode` + optional `coName`** → `POST
  /admin/companies/{coCode}/provision`. Shows result tiles (accounts/taxes/books added). No company
  detail fields.
- `ops/seedCompany.ts` — inserts `CO_MAST(tenant_id, CO_CODE, CO_NAME, LC_CODE)` **only**, then seeds
  19 system accounts, 7 taxes, 14 books, `SRNO_MAST`, `CO_SET`. Idempotent. (Grounded: the single
  `INSERT INTO "CO_MAST"(tenant_id,"CO_CODE","CO_NAME","LC_CODE")`.)
- `masters/configs.ts` → `CO_MAST_CONFIG = { table:'CO_MAST', keyColumns:['CO_CODE'],
  requiredColumns:['CO_CODE','CO_NAME'], references:[] }` — **no `formFields`**, so the generic
  `/masters/companies` form renders just **Company + CO_CODE + CO_NAME**.
- Year: `masters/years` → `YEAR_MAST_CONFIG` (required `CO_CODE`,`CO_YEAR`, **no formFields**, no
  OP_DATE/CL_DATE). `utilities/year-end` is a *different* thing (balance carry-forward close), not
  desktop "Year Create".
- Company-select: `app.ts` `GET /context/companies` returns `CO_CODE, CO_NAME` only.

**GAPS.**
- **No Company Master detail form.** Missing every `CO_MAST` field beyond code+name (grounded in
  `MS_COMPANY.cs` field-load): `CO_SNAME`, `CO_ADD1/2/3`, `CO_COUNTRY`, **`CO_STATE` + `CO_STATE_CODE`**,
  `CO_CITY`, `CO_PIN`, `CO_PHONE`/`CO_PHONE2`, `CO_MOBILE`/`CO_MOBILE2`, `CO_MAIL`, `CO_JUD`
  (jurisdiction), **`WORK_TYPE`** (R/W), **`METAL_TYPE`** (G/S/O), `CO_GST_NO`, `CO_CSTNO`,
  `CO_PAN_NO`, `DHIRAN_NO`, `BANK_NAME`/`BANK_AREA`/`BANK_AC_NO`/`BANK_RTGS_NO`, `CO_TYPE`,
  `REP_ADD_TYPE`.
- **State picker missing.** Desktop Enter→state list; web has a `states` master (`STATE_MAST_CONFIG`)
  but it is **not wired** to any company form. → **[Lookup infra]**.
- **Work Type / Metal Type dropdowns missing** (no `select` field type).
- **Year Create parity:** no **Opening Date** (`OP_DATE`), **Close Date** (`CL_DATE`), **Year Month**;
  the master/parameter **auto-seed is not triggered by year creation** (it's the separate manual
  `/admin/provision`); no "reopen software" flow.
- **GST correctness risk:** company **State/GST** drive IGST-vs-CGST/SGST determination on sales; with
  no company state captured, inter/intra-state tax split can't key off the company's own state.
- Company-select popup shows no **Address** column (desktop `Code|Name|Address`).

**Fill plan.**
- *Backend* — add a full `formFields` array to `CO_MAST_CONFIG` in `masters/configs.ts` using the exact
  columns above; add `STATE`/`GST` as `lookup`/`select` fields via **[Lookup infra]**. Optionally extend
  `seedCompany` to accept and persist the full company payload (or rely on the generic `CO_MAST` PUT for
  detail after provisioning). Add `OP_DATE`/`CL_DATE`/`YEAR_MONTH` `formFields` to `YEAR_MAST_CONFIG`
  and trigger `seedCompany` immediately after a year row is created (a combined "Create Company + Year"
  server flow mirroring `MS_YEAR`).
- *Frontend* — extend `masters/[name]/page.tsx` to render `select` (Work/Metal type) + `LookupPicker`
  (State) per the new field types; or build a dedicated `admin/provision`/`masters/companies` form that
  captures the detail fields and calls provision + `CO_MAST` update. Add the "reopen/relaunch"
  confirmation copy on year create.

**Priority / effort.** Detail form **P1 / M** (State+GST subset is **P0-flavoured / S** for tax
correctness). Year opening-date + auto-seed-on-create **P2 / M**.

---

## 2. User Create + Rights  (desktop `MS_USER`; enforced `MDI_FORM`; menu Company → User Create)

**Desktop spec.** Create/edit user (User Name, Old/New/Confirm password, User Type User/Admin) →
`LOGIN_MAST` (+ global `USER_UPDATE`/`USER_DELETE`/`USER_PRINT`). **"Update User Right"** opens a rights
grid — columns **`SrNo | Main Menu | Sub Menu | View | Edit | Delete | Print`** enumerating **every**
menu→form (~54 rows: Company/*, Master/*, Transaction/*, Other/*, …) → `USER_SET`
(`FRM_VIEW/EDIT/DELETE/PRINT`, each Y/N). Runtime block: opening a form with `FRM_VIEW<>'Y'` ⇒
*"You Have No Rights…"*. Admin (`LOGIN_CATG` starting `A`) holds all rights.

**Web now.**
- `admin/users/page.tsx` — new-user form (Company / Login name / Password / Role ADMIN|USER) + a grid
  with per-user **Update / Delete / Print** checkboxes + **Category** (Admin/User) + Save. Uses `GET/POST
  /admin/users` and `POST /admin/users/:loginName/rights`.
- `rbac/users.ts` — `LOGIN_MAST` CRUD; **passwords hashed with Argon2id** (improvement over desktop
  plaintext); `setUserRights` writes `USER_UPDATE/DELETE/PRINT` + `LOGIN_CATG`.
- `rbac/formRights.ts` — `getUserFormRights` / `setUserFormRights` / `resolveAllowedForms` over
  **`USER_SET`** with `FRM_VIEW/EDIT/DELETE/PRINT`; "no rows ⇒ unrestricted" matches desktop.
- Routes `GET/POST /admin/users/:loginName/form-rights` **exist** (`routes/txn.ts`), and `GET /me`
  returns `allowedForms` via `resolveAllowedForms`. **So the per-form engine is complete server-side.**

**GAPS.**
- **The per-form View/Edit/Delete/Print matrix has NO UI.** `admin/users/page.tsx` exposes only the
  three global flags + Category — it never calls `…/form-rights`. The desktop **"Update User Right"**
  grid (Main/Sub menu × 4 checkboxes, ~54 rows) is not renderable, so an admin **cannot configure
  per-form access from the web** despite the API + `/me` enforcement being present.
- **No canonical menu/form catalog.** `setUserFormRights` accepts arbitrary rows but there is **no
  source list** of the `MAIN_MENU/SUB_MENU` rows (the desktop's fixed ~54-row menu tree) to render the
  grid or seed defaults.
- **Verify enforcement in the web shell:** `/me.allowedForms` is returned but I did not confirm the web
  nav/route guard actually hides/blocks non-VIEW forms (desktop hard-blocks). Needs a check + wiring.
- **No password change/reset** for existing users (Old/New/Confirm). Create sets a password; the grid
  has no reset.
- **Admin gate deviation:** the routes gate on the global **`delete`** right (`guard(req,reply,'delete')`)
  rather than `LOGIN_CATG` admin. `rbac/users.ts` ships `assertAdmin` but the route doesn't use it.

**Fill plan.**
- *Backend* — add `rbac/formCatalog.ts` exporting the canonical `{ srno, mainMenu, subMenu }[]` (mirror
  the desktop ~54 rows) + a route `GET /admin/form-catalog`; optionally seed `USER_SET` from it. Add a
  password-change endpoint reusing `auth/password.hashPassword`. Optionally switch the admin gate to
  `assertAdmin`.
- *Frontend* — in `admin/users/page.tsx` add a per-user **Rights** expander that `GET`s
  `/admin/users/:loginName/form-rights` merged with the catalog and renders the
  `SrNo|Main Menu|Sub Menu|View|Edit|Delete|Print` grid, POSTing back to `…/form-rights`. Add a
  password-reset control. Ensure the app shell consumes `allowedForms` to hide/deny forms.

**Priority / effort.** Per-form matrix UI **P1 / M** (behaviour parity; API already exists). Password
change + admin-gate + nav enforcement **P2 / S–M**.

---

## 3. Account / Party Master (+ Opening Balance)  (desktop `MS_ACCT`; menu Master → Party)

**Desktop spec.** `AC_MAST` party with tabs **Company Detail / Other Detail / Family Detl** + a **party
photo**. Company Detail: Ac Code (auto), Name, **Ac Group (Enter→GrCod|AcGroup|MainGroup list)**, Mobile,
Phone, Con Person, Ac Short, Address1/2/3, City, Area, Pin, Country, **GST No + Local/Inter type**, PAN,
State, District, Email. Inline **Opening Balance**: Amount Dr/Cr, Gold ±, Silver ± (+ Last Visit, Ledger
Date) → `OP_DATA`. Other Detail: Mobile No2, Aadhaar, Bank/Branch/AcNo/IFSC, **Ref By, Birth Date, Anv
Date, L Birth, Cr Day, Dpc %, Khata No**.

**Web now.**
- `masters/master.service.ts` → `AC_MAST_CONFIG.formFields` — a **30-field** set whose labels map 1:1 to
  the desktop Company-Detail + bank + Cr Days + Interest % + DPC %: `AC_CODE, AC_NAME, AC_GR,
  AC_MAIN_GR, AC_SHORT, AC_PERSON, AC_MOBILE, AC_PHONE, AC_ADD1/2/3, AC_CITY, AC_AREA, AC_PIN, AC_STATE,
  AC_DISTRICT, AC_COUNTRY, AC_GSTNO, AC_GST_TYPE, AC_PANNO, AC_ADHAR_NO, AC_EMAIL, AC_CR_DAYS,
  AC_INT_PRC, DPC_PRC, BANK_NAME, BANK_AREA, BANK_AC_NO, BANK_RTGS_NO, AC_TYPE`.
- Opening balance is a **separate page** `masters/opening-balance/page.tsx` → `masters/openingBalance.ts`
  (`OP_DATA`: `OP_AMT`+`OP_SIGN` D/C, `FINE_BAL`+`FINE_SIGN` ±, `SL_FINE_BAL`+`SL_FINE_SIGN` ±) with a
  live `PartyBalance` panel. A second voucher opening exists at `/txn/ac-opbl` → `finance/acOpening.ts`
  (`ACOP` legs). **Field model matches the desktop.**

**GAPS.**
- **`AC_GR` is free-text** (generic form has no picker); desktop opens the Account-Group help grid and
  auto-fills **`AC_MAIN_GR`** from the chosen group. Web operator must know the numeric group + type
  the main group by hand. → **[Lookup infra]**.
- **Missing Other-Detail fields** (present on desktop, absent from `AC_MAST_CONFIG.formFields`):
  **`AC_MOBILE2`** (Mobile No2), **Ref By**, **`BIRTH_DATE`**, **`ANV_DATE`**, **L Birth**, **`KHATA_NO`**
  (grounded: `MS_ACCT.cs` `tKhataNo`). Also **Last Visit** + **Ledger Date** on the opening group.
- **GST Type** is a plain text field, not a **Local/Inter dropdown** (no `select`).
- **No party photo/image** (desktop `PicImage`, grounded in `MS_ACCT.cs`).
- **No Family Detl tab.**
- **Opening balance can't be set at party-create time** (it's a separate screen) — a workflow/UX
  difference vs the desktop's single inline group-box.

**Fill plan.**
- *Backend* — append the missing columns to `AC_MAST_CONFIG.formFields` (`AC_MOBILE2`, a `REF_BY`/
  `AC_REF`, `BIRTH_DATE`, `ANV_DATE`, `KHATA_NO` — verify exact live-schema names against the
  `MS_ACCT` insert). Mark `AC_GR` as a `lookup` (entity `ac-groups`, side-effect: fill `AC_MAIN_GR`) and
  `AC_GST_TYPE` as a `select` (L/I) via **[Lookup infra]**.
- *Frontend* — render the lookup/select field types in `masters/[name]/page.tsx`; on `AC_GR` pick fetch
  the group's main-group and set `AC_MAIN_GR`. (Photo upload + Family tab are larger, separate work.)

**Priority / effort.** `AC_GR` lookup + missing Other-Detail fields + GST-type select **P1 / M**. Photo +
Family tab + inline-opening-at-create **P2 / L**.

---

## 4. Item / Item-Group / Product (+ Auto Item)  (desktop `MS_PRODUCT/MS_GROUP/MS_ITEM/MS_AUTO_ITEM`)

**Desktop spec.** Create order Product → Group → Item / Auto Item. **Product** (`PR_CODE,PR_NAME`).
**Group** (`GR_CODE,GR_NAME,Item Type G/S,Gr Touch,Purc Touch,Melting %,West %,Sales A/c,Purchase A/c,
HSN,Tax %,Rate Display`) — Sales/Purchase A/c chosen from a **posting-account list**. **Item** = Product ×
Group; **Item Code + Item Name auto-generate** on picking Product+Group. **Auto Item**: pick a **Group** →
grid of products with **Y/N** per product → **bulk-create** many `ITEM_MAST` rows at once.

**Web now.**
- `PRODUCT_MAST_CONFIG` (configs.ts) — no `formFields`; generic form shows `CO_CODE/PR_CODE/PR_NAME`.
  **Matches** (product only needs code+name).
- `GROUP_MAST_CONFIG.formFields` — match desktop labels (`Group Code, Group Name, Item Type (G/S),
  Rate Touch %, Purchase Touch %, Melting %, Wastage %, Sales A/c, Purchase A/c, HSN, Tax %,
  Rate Display`).
- `ITEM_MAST_CONFIG.formFields` — match desktop labels (`Item Code, Item Name, Product, Group,
  Metal (G/S), Touch %, Wastage %, Labour Rate, Labour %, HSN, Unit, Rate Per, Item Rate, Other Rate,
  Conversion %, Discount %, Bag Weight, Safe, Stock Display, Min Stock`).

**GAPS.**
- **No Auto Item (`MS_AUTO_ITEM`) at all** — no route, no page, no module. Items must be created one at a
  time; the "pick group → tick products → bulk-generate" convenience is absent.
- **Item Code / Item Name are NOT auto-generated** — the web operator types them; desktop derives them
  from Product×Group.
- **Group `SALE_AC`/`PURC_AC` and Item `PR_CODE`/`GR_CODE` are free-text** — no Enter-to-list picker
  (desktop shows product/group/posting-account lists). → **[Lookup infra]**.
- Minor: Group `AVG_*` (running average) columns not surfaced (low value at create time).

**Fill plan.**
- *Backend* — add `masters/autoItem.ts` `autoItem(prisma, tenantId, { coCode, grCode, products:[{prCode,
  yn}] })` that bulk-inserts `ITEM_MAST` rows (IT_CODE = `PR_CODE+GR_CODE` pattern, IT_NAME from
  product+group names), mirroring `MS_AUTO_ITEM.cs`; route `POST /masters/auto-item`. For single-item
  auto-code, compute `IT_CODE`/`IT_NAME` server-side on create when blank. Add `lookup` types for
  `PR_CODE`, `GR_CODE`, `SALE_AC`, `PURC_AC` via **[Lookup infra]**.
- *Frontend* — new page `masters/auto-item/page.tsx` (pick group → product Y/N grid → submit). Render the
  new lookup field types in the generic Group/Item forms.

**Priority / effort.** Auto Item **P1 / M**. Posting-account/product/group lookups **P2 / S–M**
(rides **[Lookup infra]**). Item code/name auto-derive **P2 / S**.

---

## 5. Barcoding — Tag Opening + Item Opening  (desktop `TR_TAG_OPBL` / `TR_ITM_OPBL`)

**Desktop spec.** **Item Opening** = bulk/loose stock line → `ITM_OPBL` + `MAIN_STOCK 'ITOBL' '+'`.
**Tag Opening** ("Opening Stock", per-piece barcoding): header Vch No (auto) + Date + **Print file
(`QrPrint10`)**; main grid columns **`Sr|ItCode|TagNo|Counter|Design|Size|Pcs|GrWt|LsWt|NetWt|Lbr%|LType|
LbrRate|LbrAmt|OthAmt|PrCost|Mrp|Image|KrCode`** + an item sub-grid (`ItName|KrWt|Weight|Con%|P/W|Rate|
ItAmt|NetAmt`) + footer Employee / Lable Skip. **Barcode number auto-generates** (`CHG00001`) and a
**QR/barcode label prints**. Writes `BAR_DETL`/`BAR_IDTL` + `MAIN_STOCK 'TAGOP' '+'`; `fine=net×touch/100`.

**Web now.**
- `txn/item-opening/page.tsx` grid: **Item, Pcs, Gross, Net, Touch, Fine (computed), Rate** →
  `POST /stock/item-opening` → `stock/stock.ts itemOpening` (`ITM_OPBL` + `MAIN_STOCK 'ITOBL' '+'`).
  **Matches** the bulk desktop flow.
- `txn/tag-opening/page.tsx` grid: **Tag No, Item, Pcs, Gross Wt, Net Wt, Touch %, Rate, MRP** →
  `POST /stock/tag-opening` → `stock/stock.ts tagOpening` (`BAR_DATA`+`BAR_DETL`+`BAR_IDTL`+
  `MAIN_STOCK 'TAGOP'`). Core posting matches; **`TAG_NO` is user-typed**. `TagOpeningLine` carries only
  `tagNo,itCode,pcs,grossWt,netWt,touch,fineWt,rate,mrp`.

**GAPS.**
- **No auto barcode/tag number.** Desktop allocates it from `SRNO_MAST.TAG_SRNO` (6-digit, `000001…`;
  grounded `TR_TAG_OPBL.cs:5589` `Select Max(TAG_SRNO)… LEN=6` → `"000001"`) and prefixes it
  (`CHG00001`). Web requires manual `TAG_NO`; `tagOpening` allocates only `VCH_SRNO` (via
  `nextVoucherNoTx`), never `TAG_SRNO`. **Blocks real barcoding.**
- **Rich tag fields missing — backend AND frontend.** `TagOpeningLine`/`BAR_DETL` do **not** carry:
  **Counter** (`TBL_CODE`, hard-coded `'001'`), **Design** (`DESIGN_NO`), **Size** (`ITM_SIZE`),
  **Less Wt**, **Lbr %** (`LBR_PRC`), **L Type** (N/G/P labour basis), **Labour Rate** (`LBR_RATE`),
  **Labour Amt** (`LBR_AMT`), **OthAmt** (= Hallmark + Rhodium charges), **PrCost**, **Karigar Code**
  (`KR_CODE`/`AC_SHORT`), **Image**. So opening tags are stored **without labour, charges, counter,
  karigar, design or size** — contradicting the desktop `BAR_DETL` footprint and breaking downstream
  valuation/labels. (Desktop grid columns confirmed by `TR_TAG_OPBL.cs` constants `cCounter=6, cDesign=7,
  cLbrCode=24`.)
- **No Counter master picker.** `counters` (`TABLE_MAST`) master exists but isn't wired; `TBL_CODE` is
  fixed. → **[Lookup infra]**.
- **No item sub-grid** (`BAR_IDTL` richer columns `ItName/KrWt/Weight/Con%/P/W/Rate/ItAmt/NetAmt`).
- **No QR/barcode label print** (`QrPrint10`): barcode no, G./N. weight, HM/RD charges, LC/LP, firm,
  product, group + QR — none rendered.
- **No per-tag Image**, no **Employee** footer, no **Vch date/time** header, no **Lable Skip**.
- **Tag Stock Report** tabs (`In/Out/Stock/Mrp/Apr Panding/All Tag`), filters (Date, Tag search, Item
  Type, Product, Group, TagNo) and **Summ/Print/Excel** — the `/txn/stock` view is minimal.

**Fill plan.**
- *Backend* — extend `TagOpeningLine` + `tagOpening` (`stock/stock.ts`) to accept & persist
  `tblCode/counter, designNo, itmSize, lessWt, lbrPct, lType, lbrRate, lbrAmt, othAmt(=hm+rd),
  prCost, krCode, image` into `BAR_DETL` (+ the matching `MAIN_STOCK` cols). Add **auto tag numbering**:
  a `nextTagNoTx` helper (`vouchers/numbering.ts`) that reads+increments `SRNO_MAST.TAG_SRNO` in the same
  tx (mirroring `nextVoucherNoTx`) and builds `PR+metal+000001`; make `tagNo` optional (auto when blank).
- *Frontend* — expand the `txn/tag-opening` grid to the full column set; add Counter + Karigar
  `LookupPicker`s, a Labour-Type `<select>`, live fine, and display the generated barcode. Add the item
  sub-grid + Employee/Lable-Skip footer. Label print + a full Tag-Stock report are follow-on work.

**Priority / effort.** Auto tag number **P0 / M** (barcoding is unusable without it). Rich tag fields +
karigar/labour/charges **P1 / M–L**. Counter picker **P1 / S**. QR/label print **P2 / M**. Tag-Stock
report tabs/filters/Excel **P2 / M**.

---

## 6. Data Backup  (desktop `UT_BKP`; menu Company → Data Backup)

**Desktop spec.** Native SQL Server `BACKUP DATABASE` to a **user-chosen drive/pen-drive** → date-stamped
`.BAK` (`Next21_120521_17.BAK` + `NextMain.BAK`), path saved in the registry, plus an **in-app Restore**
(detach/attach) and an **exit-hook** ("take backup now?"). Covers the whole SQL instance (all
companies/years).

**Web now.**
- `backup/page.tsx` — a single button downloads `GET /api/backup` as `backup-YYYY-MM-DD.json`.
- `ops/backup.ts backupCompany` — `SELECT *` over a **fixed 25-table list** → one JSON doc; RLS-scoped to
  the tenant. Full physical backup is `deploy/backup.sh` (`pg_dump` cron).

**GAPS.**
- **Different mechanism** (logical JSON vs native `.BAK`): no drive/path picker, no `.BAK`, **no in-app
  Restore**, no per-date `.BAK` naming, single-company vs whole-instance. (Browser sandbox makes an OS
  drive-picker infeasible — a genuine, documentable web deviation.)
- **The JSON export is data-incomplete.** The `TABLES` list **omits** the tag/stock and setup tables:
  `BAR_DATA/BAR_DETL/BAR_IDTL`, `MAIN_STOCK`, `ITM_OPBL`, **`OP_DATA`** (opening balances),
  `LOGIN_MAST`/`USER_SET`, `CO_SET`, `SRNO_MAST`, `YEAR_MAST`, `AC_GROUP`, `TABLE_MAST`. A restore from
  this file would **lose tag inventory, stock movements, openings, users and numbering** — so it is not a
  faithful backup.
- **No restore/import path** exists at all.

**Fill plan.**
- *Backend* — expand `TABLES` in `ops/backup.ts` to include the stock/opening/rbac/numbering tables
  above; add an admin-gated `POST /backup/restore` that re-inserts rows within `withTenant` (desktop
  Restore parity); optionally an endpoint that streams a downloadable `pg_dump`/`.sql`.
- *Frontend* — add a "Restore from JSON" upload to `backup/page.tsx`; document that browser downloads land
  in the browser's download folder (no arbitrary-drive picker) as an intentional web deviation.

**Priority / effort.** Backup completeness (add tables) **P1 / S**. Restore endpoint + UI **P2 / M**.
`.BAK`/drive-picker parity — **not feasible in-browser**, document as a deviation.

---

## Module summary — top 5 gaps by priority

1. **[P0] Tag Opening has no auto barcode/tag number.** Desktop auto-allocates from
   `SRNO_MAST.TAG_SRNO` (`CHG00001`; `TR_TAG_OPBL.cs:5589`); web requires a manual `TAG_NO` and
   `tagOpening` never touches `TAG_SRNO`. Fix in `stock/stock.ts` + `vouchers/numbering.ts` +
   `txn/tag-opening/page.tsx`. **(M)**
2. **[P0→P1] Tag Opening loses the rich per-tag data.** `Counter, Design, Size, Less Wt, Lbr%, LType,
   LbrRate, LbrAmt, OthAmt(=Hallmark+Rhodium), PrCost, Karigar, Image` are absent from both
   `TagOpeningLine`/`BAR_DETL` and the grid → labels + downstream valuation are wrong. **(M–L)**
3. **[P1] No Company Master detail form.** Web stores only `CO_CODE`+`CO_NAME`; missing `CO_STATE`(+picker),
   `WORK_TYPE`, `METAL_TYPE`, GST/CST/PAN, address, bank, jurisdiction (`MS_COMPANY.cs`). State/GST is
   **P0-flavoured** for correct tax split. Fix: `CO_MAST_CONFIG.formFields` + **[Lookup infra]**. **(M)**
4. **[P1] User per-form rights matrix has no UI.** `USER_SET` engine (`rbac/formRights.ts`) + `/me`
   enforcement exist, but `admin/users/page.tsx` exposes only 3 global flags — the desktop "Update User
   Right" grid (Main/Sub menu × View/Edit/Delete/Print, ~54 rows) can't be configured from the web.
   Needs a form-catalog + grid UI. **(M)**
5. **[P1] No Auto Item bulk generator** (`MS_AUTO_ITEM`) — items are one-at-a-time; plus all master code
   fields (`AC_GR, PR_CODE, GR_CODE, SALE_AC, PURC_AC, STATE, Counter, Karigar`) are **free-text** because
   `FormField` supports no `select`/`lookup` type. Fix: `masters/autoItem.ts` + route + page, and the
   shared **[Lookup infra]** enhancement to `master.service.ts` + `masters/[name]/page.tsx`. **(M)**

_Runner-up **[P1]** — Backup JSON omits stock/opening/user/numbering tables and offers no Restore
(`ops/backup.ts`): expand the table list + add a restore path._

**Highest-leverage single change:** **[Lookup infra]** — add `type: 'select' | 'lookup'` (+ options /
lookup entity) to `FormField` in `masters/master.service.ts` and teach `masters/[name]/page.tsx` to
render `<select>` / `LookupPicker`. It simultaneously closes the code-field gaps in **Company (State,
Work/Metal type)**, **Party (Ac Group + GST type)** and **Item/Group (Product, Group, Sales/Purchase
A/c)** — three of the six screens — with one backend + one frontend edit.
