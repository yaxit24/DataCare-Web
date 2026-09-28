# Desktop ⇄ Web Parity — GST/STATUTORY · UTILITIES · WHOLESALE/LABOUR/TOUR

Read-only verification. Extends `vdw-sales.md` / `vdw-purchase-karigar.md` / `vdw-masters-reports.md`.

**Desktop truth** = video-research KB (`851f2afc…`, `KB_transaction.md`, `KB_other.md`, `KB_karigar.md`, `README`) + mined behavior catalogs `catalogs/form-behavior/*.behavior.json` (gridColumns / inlineSql / calc / validations / keyboard) + `catalogs/coverage-matrix.json`.
**Web truth** = `web/apps/web/app/(app)/{utilities/*,backup,settings,txn/*}/page.tsx` + `web/apps/api/src/modules/{einvoice,gst,reports,ops,tour,sales,settings,integrations,utilities}/*.ts` + `routes/txn.ts` (route wiring read directly).

Verdicts quote real evidence on both sides. Legend: **Match** = desktop behavior reproduced · **Partial** = present but incomplete/differs · **Gap** = absent.

Coverage-matrix status for these forms: `UT_E_INVOICE`/`UT_BKP`/`UT_VCH_RE_NUMBR`/`UT_SETTING(_MAIN)`/`TR_WH_SALE`/`TR_WH_SALE_RTN`/`TR_SALE_LBR`/`TR_TOUR`/`TR_TOUR_ORD`/`TR_TOUR_SALE`/`MS_YEAR` = **PAGE**; `RP_GST`/`RP_HUID`/`RP_TAX` = **SPEC** (report-layouts); `UT_IMPORT`/`UT_EXPORT`/`UT_SMS`/`UT_WHATSAPP`/`UT_WAPP_WITH_API`/`UT_WEB_CAM`/`UT_SET_ADMIN`/`UT_HDD`/`UT_AI_TRFR`/`UT_CUST_ENTRY` = **MISSING**.

---

# MODULE A · GST / STATUTORY

Desktop GST returns live in `RP_GST.cs` (loc 3945) — a **section-type export** driven off the tax register `TAX_DATA ⨝ AC_MAST ⨝ STATE_MAST ⨝ TAX_MAST`, selected by a `cboSectionType` dropdown ("Please Select Section Type And Try…"), computing per-state / per-rate / reverse-charge (`R_CHARG`) net + IGST/CGST/SGST sums and finally emitting a file ("File is Generate…"). e-Invoice lives in `UT_E_INVOICE.cs` (loc 2041) + `IRNClass`/`IRNData` + `GenIRN.txt`, with a **57-column payload grid** (buyer/dispatch/ship/item/tax/cess/export/e-way).

Web GST is split across `modules/gst/gst.ts` (GSTR-1), `modules/reports/reports.ts` `gstr3b()`, `modules/reports/reports3.ts` `gstr2Purchase()`, statutory docs in `modules/reports/statementDocs.ts` + `modules/gst/gstr1Doc.ts`, and e-invoice in `modules/einvoice/einvoice.ts`.

## (A1) GSTR-1 — sections & HSN

Desktop `RP_GST` inlineSql builds B2B/B2C/interstate splits: `SELECT … A.R_CHARG, D.TAX_PRC, A.NET_AMT … FROM TAX_DATA A INNER JOIN AC_MAST B … LEFT JOIN STATE_MAST C ON B.AC_STATE=C.STATE_NAME …` and interstate summary `… WHERE … B.AC_STATE <> '?' AND AC_STATE <> ''`; HSN comes from `ITEM_MAST.HSN_CODE`/`GROUP_MAST.HSN_CODE`.

| GSTR-1 section | Web implementation | Verdict | Evidence |
|---|---|---|---|
| 4A/4B **B2B** (registered recipient) | `classifyInvoice` → `hasGstin(gstin)?'B2B'`; `gstr1()` reads `SL_DATA ⨝ AC_MAST.AC_GSTNO` | **Match** | `gst.ts` `if (hasGstin(inv.gstin)) return 'B2B'`; doc `4. B2B — Supplies to Registered Persons` (`gstr1Doc.ts`) |
| 5 **B2CL** (large inter-state, unregistered) | `inv.interState && inv.invoiceValue > B2CL_THRESHOLD (250000)` | **Match** | `gst.ts` `B2CL_THRESHOLD = 250000`; `interState: Number(r.igst) > 0` |
| 7 **B2CS** (small, state+rate summary) | `summarizeB2CS` groups by `stateCode|ratePct` | **Match** | `gst.ts` `key = \`${state}|${inv.ratePct}\``; doc `7. B2CS — Others (state + rate)` |
| 12 **HSN-wise summary** | `summarizeHsn(detail, hsnMap)` but **keyed on `IT_CODE` as HSN proxy** | **Partial** | `gst.ts` detail SQL `SELECT D."IT_CODE" … GROUP BY D."IT_CODE"`; comment "HSN summary groups detail by HSN (**IT_CODE proxy — a dedicated HSN master is a parity item, see Task 30**)"; desktop pulls real `HSN_CODE` |
| Source register | Web reads **`SL_DATA`/`SL_DETL` directly**; desktop reads **`TAX_DATA`** register (book-typed `T`) | **Partial** | `gst.ts` `FROM "SL_DATA" S … FROM "SL_DETL" D`; desktop `RP_GST` all queries `FROM TAX_DATA A` |
| **Reverse-charge** (`R_CHARG`) flag | not modeled | **Gap** | desktop selects `A.R_CHARG`; no `rCharge` in `InvoiceRow` |
| CDNR/CDNUR (credit-note sections) | returns excluded, not a distinct section | **Gap** | web filters returns out (`CO_BOOK<>'SRT'` in 3B); no credit-note return section emitted for GSTR-1 |
| **Export to JSON/portal file** | HTML document only (`renderGstr1Doc` → `docShell`) | **Partial** | `gstr1Doc.ts` renders `GSTR-1 — Outward Supplies` HTML "Mirrors desktop Gstr_1.rpt"; no GST-portal JSON; desktop `RP_GST` "File is Generate…" |
| Route wiring | `/reports/gstr1` (dataset) + `/reports/gstr1-doc` (HTML) | **Match** | `txn.ts:1091 app.get('/reports/gstr1-doc' …)`; `gstr1` imported `txn.ts:71` |

## (A2) GSTR-3B — outward summary

| 3B item | Web | Verdict | Evidence |
|---|---|---|---|
| 3.1 outward taxable + tax (CGST/SGST/IGST) | `gstr3b()` Σ over `SL_DATA` | **Match** | `reports.ts:233` `SELECT sum(NET_AMT-DISC_AMT) taxable, sum(TAX_AMT) tax, sum(CGST_TAX/SGST_TAX/IGST_TAX) … FROM "SL_DATA" WHERE "CO_CODE"=$1 AND "CO_BOOK"<>'SRT'` → `{outwardTaxable,outwardTax,outwardCGST,outwardSGST,outwardIGST}` |
| Document (3.1 + 5.1 net payable) | `gstr3bDocHtml` "Gstr_3.rpt" parity | **Partial** | `statementDocs.ts:45` `gstr3bDocHtml`; comment "3.1 outward supplies + tax, 5.1 net payable" |
| **4. Eligible ITC (inward)** | **not in 3B** | **Gap** | `reports.ts:232` comment "**ITC/inward is a follow-up**"; 3B is outward-only, so net tax payable is gross (no ITC offset) |
| 3.2 inter-state to unregistered / composition | not modeled | **Gap** | no 3.2 breakdown in `gstr3b()` |
| Route | `/reports/gstr3b` + `/reports/gstr3b-doc` | **Match** | `gstr3b` imported `txn.ts:71`; `renderGstr3bDoc` `statementDocs.ts:59` |

## (A3) GSTR-2 — inward ITC (purchase)

| Item | Web | Verdict | Evidence |
|---|---|---|---|
| Inward taxable + tax split | `gstr2Purchase()` single-row Σ over `PR_DATA` | **Partial** | `reports3.ts:109` `SELECT sum(NET_AMT) taxable, sum(TAX_AMT) tax, sum(CGST_TAX/SGST_TAX/IGST_TAX) … FROM "PR_DATA"` → one summary row |
| Invoice-level B2B ITC (per-supplier GSTIN rows) | **not modeled** — a single totals row only | **Gap** | `reports3.ts:104` comment "single-row totals … returned as a **one-row ListReport**"; no supplier/GSTIN/HSN breakup |
| `OTH PURC` input register (`TAX_DATA TAX_SIGN='-'`) merge | reads `PR_DATA` only, not the `TAX_DATA` input register | **Partial** | KB §11.4 other-expenses posts input GST to `TAX_DATA (BOOK_NAME 'OTH PURC', TAX_SIGN '-')`; `gstr2Purchase` ignores it |
| Route | `/reports/gstr2` + `/reports/gstr2-doc` | **Match** | `txn.ts:884 app.get('/reports/gstr2' …)`, `txn.ts:913 …'/reports/gstr2-doc'` |

## (A4) e-Invoice — IRN payload (57-col desktop `UT_E_INVOICE` vs NIC v1.1 web)

Desktop grid columns (57): `BillType·RCharge·EComGstn·IgstOnIntra · Doc(Type/Number/Date) · Byer(Gstn/LegalName/TradName/Pos/Add1/Add2/Loct/PinCode/State/Phone/Email) · Disp(Name/Add1/Add2/Loct/PinCode/State) · Ship(Gstn/LegalName/TradName/Add1/Add2/Loct/PinCode/State) · item(SlNo/ProdDesc/IsService/HsnCode/Barcode/Qty/FreeQry/Unit/UnitRate/GrossAmt/Discount/PreTaxVal/TaxablVal/GstRate/Sgst/Cgst/Igst/CessPrc/CessAmtAdVal/CessNonAdVal/StateCess*/OthCharge/ItmTotal) · Batch(Name/Expiry/Waranty) · Tot(TaxablVal/Sgst/Cgst/Igst/Cess/StateCess/Disc/OthCharg/RoundOff/InvoiceVal) · Export(BillNo/Date/Port/Refund/ForeignCur/CountryCode/DutyAmt) · Eway(id/TranName/TarnMode/Distance/DocNo/DocDate/VehicalNo/VehicalType)`.

Web `buildIrnPayload` (`einvoice.ts`) builds NIC v1.1 `{Version,TranDtls,DocDtls,SellerDtls,BuyerDtls,ItemList,ValDtls}`.

| Payload area | Desktop cols | Web `buildIrnPayload` | Verdict | Evidence |
|---|---|---|---|---|
| Version / TranDtls | BillType/RCharge/IgstOnIntra | `Version:'1.1'`, `TranDtls:{TaxSch:'GST',SupTyp:'B2B',RegRev:'N',IgstOnIntra:'N'}` | **Partial** | `einvoice.ts` fixed `SupTyp:'B2B'`,`RegRev:'N'`; desktop drives SupTyp/RegRev/IgstOnIntra from grid |
| DocDtls | DockType/Number/Date | `{Typ:'INV',No:sale.billNo,Dt:fmtIrnDate}` (dd/MM/yyyy) | **Match** | `einvoice.ts` `fmtIrnDate` → `dd/MM/yyyy` |
| SellerDtls | (from CO_MAST) | `partyDtls(seller)` Gstin/LglNm/TrdNm/Addr1/Loc/Pin/Stcd | **Match** | `submitIrnForSale` seller from `CO_MAST` (`CO_GST_NO/CO_NAME/CO_ADD1/CO_CITY/CO_PIN/CO_STATE_CODE`) |
| BuyerDtls (+POS) | Byer 11 cols | `{...partyDtls(buyer),Pos:buyer.stcd}` from `AC_MAST` | **Match** | `submitIrnForSale` buyer `AC_GSTNO/AC_NAME/AC_CITY/AC_STATE`; **B2B guard** throws if no recipient GSTIN |
| ItemList | 24 item cols | `SlNo/PrdDesc/IsServc/HsnCd/Qty/FreeQty/Unit/UnitPrice/TotAmt/Discount/PreTaxVal/AssAmt/GstRt/Igst/Cgst/Sgst/OthChrg/TotItemVal` | **Partial** | `einvoice.ts` item map; **HSN de-hardcoded from `ITEM_MAST.HSN_CODE` (fallback `7113`), Unit from `UNIT_NAME` (fallback GMS)**; **no Cess/StateCess/Batch/Barcode fields** |
| ValDtls | 10 total cols | `AssVal/CgstVal/SgstVal/IgstVal/Discount/OthChrg/RndOffAmt/TotInvVal` | **Partial** | `einvoice.ts` ValDtls; **no CesVal/StCesVal/Discount≠0/OthChrg≠0** |
| **Dispatch / Ship-to** party blocks | Disp 6 + Ship 8 cols | **absent** | **Gap** | web payload has no `DispDtls`/`ShipDtls` (drop-ship / bill-to-ship-to) |
| **Cess / State-Cess** (per-item + totals) | CessPrc/CessAmtAdVal/CessNonAdVal/StateCess* | **absent** | **Gap** | not in `IrnItemInput`/`ValDtls` |
| **Export block** (SEZ/export invoice) | 7 Exp cols | **absent** | **Gap** | no export fields |
| **e-Way bill block** | 8 Way cols | **absent** | **Gap** | no transporter/vehicle/distance in payload |
| **Batch** (name/expiry/warranty) | 3 cols | **absent** | **Gap** | n/a for jewellery but present in desktop schema |
| Pre-submit validation | HSN-missing + PIN/GSTIN-missing scans (`inlineSql` #1/#2) | `validateIrnPayload` (Seller/Buyer Gstin, Doc No/Dt, ItemList, TotInvVal>0) | **Partial** | desktop pre-scans `SL_DETL` for blank `HSN_CODE` and `AC_MAST` for blank `AC_PIN/AC_GSTNO` before build; web validates the assembled payload only |
| per-item CGST=SGST=tax/2 | `calc` `SgstAmt=IT_TAX_AMT/2; CgstAmt=IT_TAX_AMT/2` | web carries posted `ITM_CGST/SGST/IGST_AMT` | **Match** | `submitIrnForSale` `cgst:N(d.ITM_CGST_AMT)…` |

## (A5) e-Invoice — transport & workflow

| Item | Web | Verdict | Evidence |
|---|---|---|---|
| GSP provider (Chartered Info) | `CharteredInfoIrnTransport` two-step auth→IRN | **Match** | `einvoice.ts` `eivital/dec/v1.04/auth` → `eicore/dec/v1.03/Invoice`; hosts `einvapi.charteredinfo.com` (prod) / `gstsandbox.charteredinfo.com` (sandbox); comment "the desktop's GSP, TR_SL_EBILL/UT_E_INVOICE" |
| Generate IRN / Ack / QR | `submitIrnForSale` → persists `SL_DATA.IRN_NO/ACK_NO/ACK_DATE` + `E_DATA` row (QR) | **Match** | `einvoice.ts submitIrn`; page POST `/einvoice/irn` |
| Cancel IRN (24h) | `cancelIrnForSale` → GSP `/Cancel` + clear IRN/ACK + delete `E_DATA` | **Match**+ | `einvoice.ts` NIC reason codes 1-4; page `cancelIrn` (reason '3') |
| Credential status / test | `gspStatus` (masked) + `testGspAuth` round-trip | **Match**+ | page `/einvoice/gsp-config` + `/einvoice/gsp-test`; env `GSP_ASPID/PASSWORD/GSTIN/USER/EINV_PWD[/SANDBOX]` |
| No-creds behavior | `FakeIrnTransport` deterministic IRN (mode `fake`) | **Match** (dev) | `irnTransportFromEnv` → Fake until creds set; README "e-Invoice: code-complete; needs a commercial GSP account" |
| Batch/bulk generation | page lists sales register, one-click **per row** | **Partial** | page `/utilities/e-invoice` iterates rows individually; desktop grid is a bulk export of all `BOOK_TYPE='T'` invoices in a date range |
| Print rights guard | none | **Gap** | desktop validation "You Have No Print Rights" |

---

# MODULE B · UTILITIES

## (B1) Year-End Close / carry-forward — desktop `MS_YEAR.cs` + `Ac_Final.cs`

Desktop `MS_YEAR` (loc 1597) creates a new `YEAR_MAST` year, copies masters (`AC_GROUP/AC_MAST/BAL_GR/BOOK_DATA`), and purges all non-current-year transactional data: **48 `DELETE FROM <tbl> WHERE CO_YEAR <> '?'`** statements (`AC_DATA, AD_*, APR_*, BAR_*, BILL_OS_DATA, BUL_DATA, CARD/CASH/CONTRA_DATA, CUT_*, DHRN_*, FINE_DATA, INOUT_*, ITM_OPBL, KR_*` …). Messages: "New Year are Created…Now ReOpen Software…", "Year Is Already Exist…".

| Item | Web (`ops/yearEnd.ts` + `utilities/year-end/page.tsx`) | Verdict | Evidence |
|---|---|---|---|
| Per-account closing balance (ΣDr−ΣCr) | `computeClosingsTx` over `AC_DATA` for fromYear, excludes book `'999'` | **Match** | `yearEnd.ts` `SELECT … sum(DR_AMT) dr, sum(CR_AMT) cr … WHERE CO_YEAR=$2 AND CO_BOOK <> '999'`; comment "AcBalInsert parity" |
| Carry-forward opening leg | `yearEndClose` writes one `AC_DATA` leg per account, `VCH_TYPE 'ACOP'`, `CO_BOOK '000'`, into toYear | **Match** | `yearEnd.ts buildOpeningRow`; page "writes one opening leg (VCH_TYPE ACOP, book 000) per account" |
| Metal (fine) carry | `FINE_WT` + `IT_TYPE` (G/S) carried, debit-positive with sign | **Match** | `yearEnd.ts` `fineSigned = CASE WHEN SIGN='C' THEN -FINE_WT ELSE FINE_WT`; row `FINE_WT: round3(abs(c.fineWt))` |
| Closing-stock fine (Trading_Stock) | `closingStockFineTx` Σ `MAIN_STOCK` ±, fallback on-hand `BAR_DETL` | **Match** | `yearEnd.ts` "desktop Trading_Stock parity" |
| Idempotent re-run | deletes prior toYear `ACOP '000'` before re-write | **Match**+ | `yearEnd.ts` `DELETE FROM AC_DATA … VCH_TYPE=$4('ACOP')`; page "safe to re-run" |
| Preview (read-only) | `/year-end/preview` returns closings + totals + stock fine | **Match**+ | page `runPreview` → `POST /year-end/preview` |
| **New-year creation + master copy** (`YEAR_MAST`, copy `AC_MAST/BAL_GR/BOOK_DATA`) | web carries balances but does **not** create the new `YEAR_MAST`/copy masters here | **Partial** | desktop `MS_YEAR` `SELECT/INSERT YEAR_MAST` + master copy; web year-create is a separate `masters/year-create` page (coverage `MS_YEAR→year-create`) |
| **Non-current-year data purge** (48 DELETEs) | **not performed** (web keeps all years; multi-year by `CO_YEAR`) | **Gap** (by design) | desktop deletes `WHERE CO_YEAR<>'?'`; web is multi-year retentive — intentional architecture difference, must be noted |
| Close-books / lock prior year | none | **Gap** | no period-close lock flip on carry (desktop close blocks the closed year) |

## (B2) Backup — desktop `UT_BKP.cs`

Desktop: pick a folder path ("Please Select Path and Try"), SQL-Server `.bak` backup + optional **de-attach** ("De-Attach is Complete", "Backup Process Complete").

| Item | Web (`ops/backup.ts` + `backup/page.tsx`) | Verdict | Evidence |
|---|---|---|---|
| Company backup | `backupCompany` → JSON of 54 whitelisted tables (masters+txns) | **Partial** | `backup.ts` `TABLES=[CO_MAST,AC_MAST,…,YEAR_MAST]`; page downloads `backup-YYYY-MM-DD.json`; route `app.ts:147 app.get('/backup')` |
| Native DB `.bak` / physical | delegated to `deploy/backup.sh` (pg_dump), not in-app | **Partial** | page "For full physical database backups, the server cron uses `deploy/backup.sh` (pg_dump)"; desktop makes the `.bak` in-app |
| Restore | `restoreCompany` (per-row SAVEPOINT, RLS-scoped, `ON CONFLICT DO NOTHING`) | **Match**+ | `backup.ts restoreCompany`; comment "desktop UT_BKP restore" |
| De-attach / detach DB | none | **Gap** | desktop "De-Attach is Complete"; no web equivalent (managed Postgres) |
| Path picker / scheduled | download-only (no path, no schedule in UI) | **Partial** | page single "Download" button; desktop picks a target path |
| Backup coverage | 54 tables (not all ~140) | **Partial** | `backup.ts TABLES` omits e.g. `LBR_*` partly, `SL_ORD_IDTL`, rate-cut, mfg detail tables |

## (B3) Voucher Renumber — desktop `UT_VCH_RE_NUMBR.cs`

Desktop (loc 4446): per-book (`MAIN_BOOK` SALES/PURCHASE/CASH REC), ordered by `VCH_DATE,VCH_NO`, two-phase collision-safe (`VCH_NO='A'+tmp` w/ `NEW_VCH_NO` → `VCH_NO=NEW_VCH_NO`), cascading updates across header+detail+`SL_IDTL`+`SL_PR_DETL`+`SL_ORD_ADJ`+`BILL_OS_DATA`+`UPI_DATA`+`BAR_*`, plus cross-refs (`AD_ADJ.SBILL_NO`, `PR_DATA.SL_BILL_NO`). Guard "Are you sure to Voucher Re Numbering Data?" → "Please Data Refresh After…".

| Item | Web (`utilities/voucherRenumber.ts` + `utilities/voucher-renumber/page.tsx`) | Verdict | Evidence |
|---|---|---|---|
| Per-book resequence to gapless 1..N by date | GET `/utilities/vch-renumber/preview?book=` dry-run | **Match** | page comment "gapless 1..N (ordered by date, then number)"; route `txn.ts:581` |
| Collision-safe apply across all tables, one txn | POST `/utilities/vch-renumber/apply {book,confirm}` | **Match** | page "rewrites VCH_NO … across ALL of the book's tables … in one transaction"; route `txn.ts:585`; returns `tablesTouched[]` |
| Dry-run preview + confirm guard + already-gapless no-op | preview shows `current→new` + `gaps` count; apply guarded | **Match**+ | page `canApply = preview.gaps>0`; confirm dialog |
| "Data Refresh after renumber" hint | not surfaced | **Partial** | desktop message "Please Data Refresh After Vch No Is Re Numbring"; web relies on the transactional rewrite (no stale cache) |
| Books scope | any `CO_BOOK` (free text) | **Match** | page input "e.g. 026"; desktop restricts to SALES/PURCHASE/CASH-REC main-books |

## (B4) Data Refresh — desktop (integrity/rebuild)

| Item | Web (`utilities/dataRefresh.ts` + `utilities/data-refresh/page.tsx`) | Verdict | Evidence |
|---|---|---|---|
| Integrity check | POST `/api/utilities/data-refresh` → ledger ΣDr=ΣCr, row counts, orphans, `ANALYZE` | **Partial** | page "re-checks the double-entry ledger balance, key row counts, orphan detail lines, and refreshes … statistics" |
| **Stored-balance / stock rebuild** (write-back recompute) | **intentionally not done** | **Gap** | page "Rebuilding stored balances/stock (a write-back recompute) is **intentionally not performed here**"; desktop refresh rebuilds `AC_DATA`/stock aggregates |

## (B5) Settings — desktop `UT_SETTING_MAIN.cs`

Desktop (loc 9496): **~64 CO_SET / CO_SET_NEW toggles** via `UPDATE CO_SET(_NEW) SET <flag>=…`. Notables: `CASH_LIMIT` (PAN gate), `LOCK_DATE`+`LAST_DAY_LOCK` (period lock), `EMP_CODE_MANDATORY`, `SALES_WITH_HMTAX`/`PURC_WITH_HMTAX`, `SL_TDS_TAX`/`PR_TDS_TAX`, `ADMIN_SMS`/`CUST_SMS`/`COUNTRY_ID`/`WAPP_SL_PRINT` (messaging), `QR_CODE_GEN`, `ITM_FINE_LOCK`, `FONT_*`/`GRID_ROW_HIGHT` (UI), plus a hidden Member-Setting tab gated by password `GJ11DC`.

| Item | Web (`settings/settings.ts` + `settings/page.tsx`) | Verdict | Evidence |
|---|---|---|---|
| Curated CO_SET editor (upsert) | `SETTING_FIELDS` whitelist (~60 keys) → `getSettings`/`saveSettings` | **Partial** | `settings.ts` comment "the desktop UT_SETTING_MAIN … CURATED, whitelisted subset"; upsert `INSERT/UPDATE "CO_SET"` |
| Cash limit / PAN gate | `CASH_LIMIT`, `PAN_CARD_VAL` | **Match** | `settings.ts SETTING_FIELDS` |
| Period lock | `LOCK_DATE`, `LAST_DAY_LOCK` | **Match** | `settings.ts` `{key:'LOCK_DATE',…'Block vouchers dated on/before…'}` |
| Employee-code mandatory | `EMP_CODE_MANDATORY` | **Match** | `settings.ts` field present |
| Messaging templates/toggles | `CUST_SMS`,`ADMIN_SMS`,`DHRN_WAPP`,`SCHM_WAPP`,`SMS_LINK` | **Match** | `settings.ts` fields |
| HM-tax / TDS-tax on sale/purchase | `SALES_WITH_HMTAX`/`SL_TDS_TAX` etc. | **Gap** | desktop `UPDATE CO_SET_NEW SET SALES_WITH_HMTAX/SL_TDS_TAX…`; **not** in web whitelist |
| `CO_SET_NEW` table | web writes **`CO_SET` only** (single table) | **Partial** | desktop splits flags across `CO_SET` + `CO_SET_NEW`; web whitelist targets `CO_SET` |
| QR gen / font / grid-height / whatsapp country-id | not exposed | **Gap** | `QR_CODE_GEN`,`FONT_*`,`GRID_ROW_HIGHT`,`COUNTRY_ID`,`WAPP_SL_PRINT` absent from whitelist |
| Admin-setting subtab (`UT_SET_ADMIN`, pwd `GJ11DC`) | absent | **Gap** | coverage `UT_SET_ADMIN=MISSING`; no admin subtab |

## (B6) Import / Export / WebCam — desktop MISSING in web

| Desktop form | Purpose (behavior/coverage) | Web | Verdict | Evidence |
|---|---|---|---|---|
| `UT_IMPORT` | Import legacy/old-software + Excel into all masters+txns ("Are You Sure To Import Old Software Data…", "Import Excel Data…?"); 50+ insert SQL across `AC_GROUP/AC_MAST/ADD_MAST/AD_*` | none | **Gap** | coverage `UT_IMPORT=MISSING`; no import page in `(app)` route tree (backup **restore** ≠ legacy import) |
| `UT_EXPORT` | Export to Excel/Tally/GST (50 SQL over `AC_MAST/AD_*/BAR_CAN_*`) | none | **Gap** | coverage `UT_EXPORT=MISSING`; JSON backup ≠ Tally/GST export |
| `UT_WEB_CAM` | Capture customer/item photo via webcam | none | **Gap** | coverage `UT_WEB_CAM=MISSING` (0 grid/sql/calc); no webcam capture route |
| `UT_HDD` / `UT_AI_TRFR` / `UT_CUST_ENTRY` | HDD-lock licensing / all-item transfer / kiosk customer-entry | none | **Gap** | coverage all `MISSING` |

---

# MODULE C · WHOLESALE + LABOUR + TOUR

## (C1) Wholesale Sale — desktop `TR_WH_SALE.cs` (loc 18008, **101 grid cols**)

Desktop is a **super-set trade (vepari) sale**: per-party **`TOUCH_MAST`** memory (`AC_TOUCH`/`AC_WEST`/`AC_LBR_RATE`/`AC_LBR_TYPE` remembered per party+item), **rate-cut** metal-exchange legs (`RATE_CUT_DATA`/`RATE_CUT_ISU`/`RATE_CUT_REC`), a purchase-side sub-grid `mSG_PR` (buy from vepari), **profit tracking** (`cPrCost`/`cTagCost`/`cMargin`/`cProfitAmt`/`cProfitFine`), Ght weight + less-touch, N/F rate types, diamond (`DM_MAST`), 4× hallmark IDs, approval-import (`APR ISU`), order-tag import, item-lot, karigar-cost columns.

Web `/txn/wholesale-sale` **posts to `/sales`** (the ordinary sale service) with `coBook:'WH'`.

| Desktop capability | Web wholesale-sale | Verdict | Evidence |
|---|---|---|---|
| Save a GST sale (metal+making+tax) | `POST /sales {coBook:'WH', lines, taxRatePct, interState, discountAmount}` | **Match** (basic) | `wholesale-sale/page.tsx submit()` `setResult(await post('/sales', body))` |
| Line calc fine=net×touch/100, metal=fine×rate | client `calc()` identical to sales | **Match** | page `const fine = r2((n(l.netWt)*n(l.touch))/100); const metal=r2(fine*n(l.rate))` |
| **Per-party `TOUCH_MAST` touch/west/labour memory** | none | **Gap** | desktop `INSERT/UPDATE TOUCH_MAST … AC_TOUCH/AC_WEST/AC_LBR_RATE` per party+item; web sends plain per-line touch |
| **Rate-cut metal exchange** (`RATE_CUT_*`) | none in wholesale page | **Gap** | desktop `RATE_CUT_DATA/ISU/REC` legs; web posts a plain sale (rate-cut lives only in `sales/rateCut.ts`, not wired here) |
| **Profit / margin / cost** columns | none | **Gap** | desktop `cPrCost/cTagCost/cMargin/cProfitAmt/cProfitFine`; absent |
| Purchase-from-vepari sub-grid (`mSG_PR`, ~35 cols) | none | **Gap** | desktop bidirectional buy+sell; web is sell-only sale |
| N/F rate type · Ght wt · less-touch · fix-west | none | **Gap** | desktop `cRateType/cGhtWt/cLessTch/cFixWestPrc` + calc `(Net+Ght)×(Touch+West−LessTch)/100`; web `net×touch/100` only |
| Approval / order-tag import into bill | none | **Gap** | desktop `APR_DETL 'APR ISU'` + `SL_ORD_DETL` import SQL; web has no importer on wholesale |
| Full tender panel (Chq/Card/Order/Kasar/Os + bank pick) | Tax%/Discount only (no tender fields) | **Gap** | page has no cheque/card/cash/kasar/os inputs (unlike `/txn/sales`) |
| Settlement validations (bank if chq≠0, defaulter, out-of-year date, emp-mandatory) | none | **Gap** | desktop validations present; web wholesale posts through `/sales` (which itself lacks these per `vdw-sales.md` (g)) |
| Wholesale **Return** (`TR_WH_SALE_RTN`) | coverage maps to `wholesale-sale`; no distinct return page | **Gap** | coverage `TR_WH_SALE_RTN→wholesale-sale` (PAGE) but the page has no return/import flow |

**Net:** web "wholesale" is a **cosmetic re-skin of the standard sale** (book `WH`); none of the wholesale-specific machinery (per-party touch memory, rate-cut, profit, buy-sub-grid, tender depth) is implemented.

## (C2) Labour Invoice — desktop `TR_SALE_LBR.cs` (dual GST) → web `createLabourInvoice`

Desktop KB §10: made-weight − order-gold credit = chargeable metal; **dual GST — 3% on metal (`Sale Tax`) + 5% on making (`Lbr Tax`) = two `TAX_DATA` rows**; tables `LBR_DATA` + `LBR_ISU_DETL/IDTL` + `LBR_REC_DETL`; order-gold via `Ord No` from `SL_ORD_DATA/SL_ORD_ADJ`; tax rates from `TAX_MAST TAX_CODE '10'/'11'`.

| Item | Web (`sales/labourInvoice.ts` + `labour-sale/page.tsx`) | Verdict | Evidence |
|---|---|---|---|
| **Dual GST (metal% + labour%) → 2 TAX_DATA rows** | `metalTaxPct(3)` + `labourTaxPct(5)`; `split()` writes metal-GST (SR 1/2) + labour-GST (SR 5/6) | **Match** | `labourInvoice.ts` `taxRows=[...split(metalT,metalPct,…,1), ...split(labourT,labourPct,…,5)]`; page defaults `metalTaxPct='3'`,`labourTaxPct='5'` |
| CGST/SGST split intra vs IGST inter | `inter ? [IGST] : [CGST,SGST]` per rate | **Match** | `labourInvoice.ts split()` |
| Ledger Dr customer / Cr metal-sale + Cr labour + Cr GST + roundoff | `assertBalanced(ledger)` | **Match** | `labourInvoice.ts` ledger legs `salesAc`+`labourAc`+`taxAc`+`roundAc` |
| Order-gold credit → Cr Gold fine leg | `orderGoldFine>0 → {IT_TYPE:'G',SIGN:'+',FINE_WT}` | **Partial** | `labourInvoice.ts` posts the Cr-Gold leg; but page takes a **manual `orderGoldFine` number** — no `Ord No` picker/import from `SL_ORD_DATA` |
| Tables `LBR_DATA` + `LBR_ISU_DETL` + `TAX_DATA` + `BILL_OS_DATA`, book `LBR`, VCH_TYPE `LBRI` | written via `postVoucherTx` | **Match** | `labourInvoice.ts writes:[LBR_DATA, LBR_ISU_DETL, TAX_DATA, BILL_OS_DATA]` |
| Labour types (per_gram/per_piece/%/fixed) | `making()` all 4 | **Match**+ | page `making()`; desktop `Ltype` |
| Tender (cash/cheque/card/upi/kasar) | `receiptLegs` | **Match** | `labourInvoice.ts` `tender = receiptLegs(...)` |
| **`LBR_ISU_IDTL` (stone sub-detail) + `LBR_REC_DETL` (metal received)** | not written | **Gap** | desktop reads/writes both; web writes only header + issue-detl |
| Metal amount = surplus (made−order) × rate, auto | **manual `metalAmount` entry** per line | **Partial** | page line has raw `metalAmount` input; desktop computes chargeable metal from made-wt − order-gold |
| Tax codes from `TAX_MAST '10'/'11'` | hardcoded 3/5 defaults (input-overridable) | **Partial** | `labourInvoice.ts` `metalTaxPct ?? 3`, `labourTaxPct ?? 5`; desktop resolves `TAX_MAST TAX_CODE='10'/'11'` |
| Settlement validations (bank/defaulter/date/emp) | none | **Gap** | `TR_SALE_LBR` validations present; web enforces only acCode + non-empty lines + balanced |

**Net:** the **dual-GST core (the unique, must-replicate feature) is at true parity**; gaps are the order-gold **import**, stone/received sub-details, and auto metal computation.

## (C3) Tour / Approval — desktop `TR_TOUR` (issue) + `TR_TOUR_SALE` (on-tour sale) → web `tour/tour.ts`

Desktop KB §9 + `TR_TOUR_SALE.cs` (loc 14057): salesman takes tagged stock **on approval** (EMP ISU), then **sells on tour** from that stock (`TR_TOUR_SALE` — full sale tender panel, rate-cut, guard "This Tag Not In Employee Stock List / You Have No item Stock…Please Tour Isu First", profit, HM), or returns unsold (EMP REC).

| Item | Web (`tour/tour.ts` + `txn/tour`,`txn/tour-return`) | Verdict | Evidence |
|---|---|---|---|
| Approval **Issue** (goods out, no money) | `tourIssue` → `APR_DATA`+`APR_DETL`+`MAIN_STOCK('-')`, VCH_TYPE `TOUR`, book `TUR`, empty `AC_DATA` | **Match** | `tour.ts tourIssue`; page `/txn/tour` `POST /tour/issue`; "No money ledger on issue" |
| Approval **Return** (unsold back) | `tourReturn` → book `TRR`, `MAIN_STOCK('+')`, flips orig `ISU_REC 'N'→'R'` | **Match** | `tour.ts tourReturn`; `/txn/tour-return` |
| line fine = net×touch/100 | `tourLineFine` | **Match** | `tour.ts tourLineFine` |
| Delete/reverse (both issue & return, re-open lines) | `deleteTour` / `deleteTourReturn` | **Match**+ | `tour.ts` reverse + re-open `ISU_REC 'R'→'N'` |
| **On-tour SALE billing** (`TR_TOUR_SALE`: sell from salesman stock w/ tender+GST+rate-cut) | **no dedicated screen** — billed via normal `/sales` + `markApprovalBilled` bridge | **Partial/Gap** | `tour.ts` comment "**Goods SOLD on tour are billed via the normal sale**; this handles the unsold return"; `markApprovalBilled` sets `EMP_SALE='Y',ISU_REC='Y'` — no EMP-stock-restricted picker, no rate-cut, no profit, no tour-sale tender panel |
| Guard "sell only from salesman's issued stock" | not enforced (normal sale sells from main stock) | **Gap** | desktop `TR_TOUR_SALE` blocks tags not in EMP-ISU list; web has no such restriction on the bridging sale |
| `EMP_CODE` (salesman) on lines | `empCode` (varchar 3) on header+detl | **Match** | `tour.ts` `empCode = (input.empCode??'').slice(0,3)` |
| Isu-No picker (open approval lines) | `tourLines` (open = `ISU_REC<>'Y'`) | **Match** | `tour.ts tourLines` |
| Tour **Order** (`TR_TOUR_ORD`) | none distinct (coverage→`/txn/tour`) | **Gap** | no tour-order pre-booking workflow |
| Approval-import into a Tax Invoice (`Apr No` on sale) | `markApprovalBilled` marks billed; but sales page has no Apr-No import (see `vdw-sales.md` (d) Gap) | **Partial** | bridge exists server-side; UI import absent |

**Net:** custody **issue + return** are at parity; the **billing SALE from a salesman's tour stock (`TR_TOUR_SALE`) is not a dedicated web workflow** — it is approximated by "sell via normal invoice + mark approval billed", losing the EMP-stock restriction, rate-cut, and profit tracking.

## (C4) Messaging — desktop `UT_SMS` / `UT_WHATSAPP` / `UT_WAPP_WITH_API` → web `integrations/messaging.ts`

Desktop `UT_SMS` (loc 4783) + `UT_WHATSAPP` (loc 6774) are **bulk-campaign screens**: build/edit `MSG_MAST` templates (types O/B/A/G/N/L), select recipients by **AC group / area / city / scheme / birthday+anniversary / outstanding (`LEDR_AC_DATA` Dr filter) / daily-rate**, then blast SMS (packs, ">70 chars = 2 credits") or WhatsApp (subscription, `WAPP_DELAY`, Excel import, from-row/to-row range). Providers: SMS GET APIs; WhatsApp via web-session / API.

| Item | Web (`integrations/messaging.ts`) | Verdict | Evidence |
|---|---|---|---|
| WhatsApp Cloud transport (text/template/PDF-doc) | `WhatsAppCloudSender` (Meta Graph v22.0, /media upload → document) | **Match** | `messaging.ts` comment "desktop UT_WAPP_WITH_API used graph.facebook.com/v22.0"; `senderFromEnv` `WA_PHONE_ID+WA_TOKEN` |
| SMS gateway transport | `HttpSmsSender` (`{key}{sender}{mobile}{text}` URL template) | **Match** | `messaging.ts` "desktop used simple GET APIs (tripadasmsbox / ping4sms / mobileadz)" |
| Template rendering (`CUST_SMS` placeholders) | `renderTemplate` `{token}` substitution | **Match** | `messaging.ts renderTemplate` |
| Best-effort (never voids the sale) | `notify()` never throws | **Match** | `messaging.ts` "delivery failure must not roll back the business transaction" |
| No-creds fallback | `FakeMessageSender` (mode `fake`) | **Match** (dev) | `senderFromEnv` |
| UPI deep-link/QR | `buildUpiUri` (NPCI) | **Match**+ | `messaging.ts buildUpiUri` |
| **Bulk-campaign UI** (recipient filter → template → blast) | **none** — transport used only for transactional notify (reminders/invoice) | **Gap** | coverage `UT_SMS/UT_WHATSAPP/UT_WAPP_WITH_API=MISSING`; `ops/reminders.ts sendReminder` uses `notify` per-record, no bulk screen |
| **`MSG_MAST` template CRUD** | none | **Gap** | desktop `INSERT/DELETE MSG_MAST … MSG_TYPE O/B/A/G/N`; web templates are code/`CO_SET` strings |
| Recipient selectors (group/area/city/scheme/birthday/OS/rate) | none | **Gap** | desktop rich audience SQL (incl. `LEDR_AC_DATA` outstanding, birthday UNIONs across `AC_MAST/ADD_MAST/AD_MEMB`) not surfaced |
| Send log / credits / subscription / delay | none | **Gap** | desktop "You Have No SMS Pack", "WAPP_DELAY", from/to-row range |

**Net:** the messaging **transport + templates are fully wired** (WhatsApp Cloud + SMS + UPI, gated on env creds like e-invoice) — but there is **no bulk-messaging application** (audience builder, `MSG_MAST` CRUD, campaign screen, send log). Hence the coverage-matrix "MISSING" refers to the *screens*, not the send capability.

---

## Summary verdict

| Area | Verdict | One-line |
|---|---|---|
| GSTR-1 (B2B/B2CL/B2CS) | **Match** | classification + doc correct; sourced from SL_DATA not TAX_DATA |
| GSTR-1 HSN summary | **Partial** | keyed on `IT_CODE` proxy, not real `HSN_CODE` |
| GSTR-3B | **Partial** | outward 3.1 only — **no ITC (4)**, no 3.2 |
| GSTR-2 | **Partial** | single-row inward totals — no invoice/GSTIN breakup |
| e-Invoice IRN core | **Match** | NIC v1.1 payload + Chartered-Info GSP + cancel + fake mode, all wired |
| e-Invoice payload depth | **Partial/Gap** | no Dispatch/Ship-to, Cess, Export, e-Way, Batch blocks |
| Year-end carry-forward | **Match** | ACOP per-account + fine + closing-stock, idempotent |
| Backup | **Partial** | JSON logical export (no in-app .bak/detach) |
| Voucher renumber | **Match** | per-book gapless, collision-safe, all tables |
| Data refresh | **Partial** | integrity check only (no balance/stock rebuild) |
| Settings | **Partial** | ~60 curated CO_SET flags (no CO_SET_NEW / HM-TDS / QR / admin subtab) |
| Import / Export / WebCam | **Gap** | absent (coverage MISSING) |
| Wholesale sale | **Gap** | thin re-skin of `/sales` — no touch-memory / rate-cut / profit / buy-grid / tender |
| Labour invoice | **Match** (core) | dual GST 3%+5% at true parity; order-import & sub-details partial |
| Tour issue/return | **Match** | approval custody in/out at parity |
| Tour SALE (`TR_TOUR_SALE`) | **Partial/Gap** | no dedicated on-tour billing screen (bridged via normal sale) |
| Messaging | **Partial** | transport+templates wired; no bulk-campaign UI / MSG_MAST CRUD |

The **statutory posting/transport layer is strong** — GSTR-1 classification, the e-invoice IRN payload + real GSP transport, year-end ACOP carry-forward, and voucher-renumber are faithful; **labour's dual-GST (the one must-replicate money rule) matches exactly**. The real deficits are (1) **wholesale**, which is not actually built (it reuses the plain sale), (2) the **tour SALE** billing screen, (3) **GST return depth** (ITC/GSTR-2 invoice-level, HSN master, portal-JSON export, reverse-charge), (4) the **e-invoice payload's optional blocks** (ship-to/cess/export/e-way), and (5) **utility screens** entirely absent — Import, Export, WebCam, and the SMS/WhatsApp bulk-campaign UI (though the send transport exists).

## Top 5 concrete gaps (prioritized)

1. **Wholesale sale is not implemented** — `/txn/wholesale-sale` posts a plain `/sales` (book `WH`) and drops every wholesale-specific feature of `TR_WH_SALE` (101 cols): **per-party `TOUCH_MAST` touch/west/labour memory, rate-cut metal exchange (`RATE_CUT_*`), buy-from-vepari sub-grid, profit/margin/cost tracking, N/F rate types + Ght/less-touch, and the full tender panel**. *(wholesale-sale/page.tsx `post('/sales', body)`)*
2. **Tour SALE (`TR_TOUR_SALE`) has no dedicated screen** — on-tour billing from a salesman's issued stock (with the "not in Employee Stock" restriction, rate-cut, profit, and tender panel) is approximated by "sell via normal `/sales` + `markApprovalBilled`". Loses the EMP-stock gate and rate-cut. *(tour.ts "Goods SOLD on tour are billed via the normal sale")*
3. **GST return depth** — GSTR-3B has **no ITC section (4)** (outward-only, so net payable is overstated), GSTR-2 is a **single totals row** (no supplier/GSTIN/HSN breakup), HSN summary uses **`IT_CODE` as a proxy** (no HSN master), reverse-charge (`R_CHARG`) is unmodeled, and there is **no GST-portal JSON export** (desktop `RP_GST` "File is Generate"). *(reports.ts:232 "ITC/inward is a follow-up"; gst.ts "IT_CODE proxy")*
4. **e-Invoice payload optional blocks absent** — `buildIrnPayload` omits **DispDtls/ShipDtls (bill-to-ship-to), Cess/State-Cess, Export block, and the e-Way-bill block** present in the desktop 57-col grid; and pre-submit HSN/PIN/GSTIN scans (`UT_E_INVOICE` inlineSql #1/#2) are not run before build. *(einvoice.ts `IrnPayload`/`IrnItemInput`)*
5. **Utility screens missing entirely** — **`UT_IMPORT`** (legacy/Excel import), **`UT_EXPORT`** (Tally/GST/Excel export), **`UT_WEB_CAM`** (photo capture), and the **`UT_SMS`/`UT_WHATSAPP` bulk-campaign UI** + `MSG_MAST` template CRUD are all absent (coverage `MISSING`). The messaging *transport* (WhatsApp Cloud + SMS) exists in `integrations/messaging.ts` but has no audience-builder/blast screen. *(coverage-matrix.json; no `(app)` route for import/export/webcam/bulk-messaging)*

**Also Partial:** year-end doesn't create the new `YEAR_MAST`/copy masters or purge non-current-year data (multi-year retentive by design) and no prior-year close-lock; backup is JSON-only (no in-app `.bak`/detach, 54 of ~140 tables); settings whitelist omits `CO_SET_NEW`, HM-tax/TDS toggles, QR-gen, fonts, WhatsApp country-id, and the `UT_SET_ADMIN` subtab; labour takes a manual `orderGoldFine`/`metalAmount` (no `Ord No` import, no `LBR_ISU_IDTL`/`LBR_REC_DETL`); voucher-renumber doesn't surface the "Data Refresh after" hint.

---
*Report file: `/Users/yakshitsavaliya/Desktop/imodule-extracted/project-memory/parity/vdw-statutory-utilities.md`*
*Verification: read-only. Desktop = KB (`851f2afc…`) + behavior catalogs (UT_E_INVOICE, RP_GST, MS_YEAR, UT_BKP, UT_VCH_RE_NUMBR, UT_SETTING_MAIN, UT_SMS, UT_WHATSAPP, TR_WH_SALE, TR_SALE_LBR, TR_TOUR_SALE) + coverage-matrix.json. Web = einvoice.ts, gst.ts, gstr1Doc.ts, reports.ts (gstr3b), reports3.ts (gstr2), statementDocs.ts, ops/yearEnd.ts, ops/backup.ts, utilities/voucherRenumber.ts + data-refresh page, settings.ts, sales/labourInvoice.ts, tour/tour.ts, integrations/messaging.ts, and the 5 utility pages + wholesale/labour/tour pages; routes confirmed in routes/txn.ts + app.ts.*
