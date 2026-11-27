# Data Import (Old Software Import, Lite Soft)

## Milestone state

Other → Data Import is the desktop `UT_IMPORT` ("Old Softwar Import", `UT_IMPORT.cs:3187`), opened for the caption
"Data Import" (`MDI_FORM.cs:8606-8615`). Only the **Lite Soft** importer is built (owner decision D-IMP-1); the other
~34 buttons are bespoke importers for other legacy products and stay out of scope. The catalog row stays **PARTIAL**:
no real Lite `.mdb` is in the repository, so reading one is a blocked case, and desktop-match coverage is 0%.

Web: `/utilities/data-import` (`web/apps/web/app/(app)/utilities/data-import/page.tsx`), API
`POST /utilities/data-import/lite/preview` and `POST /utilities/data-import/lite/apply`
(`web/apps/api/src/routes/dataImport.ts`), modules `web/apps/api/src/modules/utilities/dataImportSource.ts` (reader), `dataImportLite.ts`,
`dataImportLiteTags.ts` and `dataImportAccess.ts` (the five steps, pure) and `dataImport.ts` (preview, transaction). Browser module `data-import`.

## What the desktop does (BtnLite_Click, `UT_IMPORT.cs:8413-8445`)

1. Asks `Are You Sure To Import Old Software Data In Next Software ?`, opens a `MDB (*.mdb)` file with Jet OLEDB 4.0
   (`TrfrConn`, `:3193-3202`).
2. `Lite_AcMast` (`:8694-8780`): deletes `AC_MAST` rows `AC_CODE >= '00101'`, copies the file's accounts above `00100`
   (`AC_GR` first two characters, area name from `AREA_MAST` cut to 25, phone/mobiles cut to 11, PAN to 10,
   `LAST_DATE '01/01/2010'`, `MAIN_USER 'ABC'`), stores the last account in `AC_MAST_SRNO`, sets `CO_SET.VB_IMPORT='Y'`.
3. `Wh_Item` (`:4241-4328`, Lite branches): replaces `PRODUCT_MAST`, `GROUP_MAST` (TRAD_TYPE blank, purchase touch,
   wastage, tax and averages 0), `TABLE_MAST` (session location) and `ITEM_MAST` (PR_CODE cut to 2, rates and averages
   0, `AC_ITEM = IT_CODE`, `STK_DISPLAY 'Y'`, `SAFE_NAME 'MAIN'`).
4. `WH_AcOpbl` (`:4330-4363`): per account, `Sum(CR-DR)` formatted `0.00`, gold and silver signed fine formatted `0.000`,
   up to the closing date; written to `OP_DATA` (book `000`, voucher `00000`) with `C` when a head is positive, else
   `D` (a zero head is `D`).
5. `Lite_BarData` (`:8447-8692`): deletes the company's tags; one voucher per tagged item (in `IT_TYPE, IT_CODE` order,
   numbered `00001`…), one `BAR_DETL` per distinct tag/detail combination copied from the tag's latest `BAR_DETL` of the
   year, dated `MOp_dt - 1` in book `000`; `VCH_SRNO = "1" & voucher & serial`; `KR_FINE` takes `ITM_FINE` and
   `TAG_TYPE` takes `IT_TYPE`; `BAR_IDTL` from the stone rows whose `TAG_NWT` equals the tag's net weight.
6. `WH_ItOpbl` (`:3887-3965`): loose stock (`TAG_NO` blank) per item, signed pieces/net/gross, amount = pieces x
   `ITEM_RATE`, fine = net x `AVG_TOUCH` / 100 at `0.000`; written when `gross + net + pieces <> 0`; `VCH_NO` holds the
   item type and `SR_NO` the row's place among all grouped items.
7. Sets `HDD_MAST.REF_NO = 'S'`, `YEAR_MAST.OP_DATE = today` for the company, `LOCT_MAST.TRY_DATE = today + 10`, says
   `Process Are Complete....` and exits the application.

The import itself writes no `MAIN_STOCK` and no ledger legs: the desktop's refresh builds them from the imported rows
(`Ac_Stock.cs:11-26` Itm_Opbl_Stk / Tag_Opbl_Stk, `Ac_Ledr.cs:9-28` AcOp_Ledr).

## Deliberate differences

| Desktop | Web | Why |
|---|---|---|
| Five steps, no transaction, deletes first | One transaction; a failure anywhere changes nothing | D-IMP-2 |
| Question first, no preview | The file is read first; rows per step, row errors and warnings shown; then the question | D-IMP-2 |
| Re-import wipes the company's tags | Refused when the company has a row in any table with a voucher number (every voucher and document, e.g. a repair receipt or a customer entry), in `OP_DATA`/`ITM_OPBL`/`BAR_*`/`MAIN_STOCK`, or any row naming an account (non-system, `>= '00101'`) or item the import would delete | D-IMP-2 |
| Jet OLEDB on the PC | `mdb-reader` 3.2.0 (MIT) in a worker thread: 32 MB file cap, 500,000 rows per table, 768 MB heap, 60 s, table/column allow-list | D-IMP-3 |
| `HDD_MAST.REF_NO`, `LOCT_MAST.TRY_DATE` | Not written (licence and trial state) | D-IMP-4 |
| Application exits | The operator is signed out | no desktop process to end |
| Refresh posts `MAIN_STOCK` / ledger later | Posted in the same transaction, as Ac_Stock.cs / AcOp_Ledr build them | the web has no deferred refresh |
| `AC_CODE >= '00101'` deleted | The same, minus the web chart's named system accounts (`CASH`, `SALES`, …, seedCompany.ts) | those codes sort above `00101` |
| Installer codes 00001-00100 in openings and group ledgers | Mapped to the web account of the same role (`INSTALLER_ACCOUNTS`, incl. 00013 TDS A/C -> `TDS`). A balance with no web account (e.g. 00042 KASAR AVAK A/C) is listed with its total; Import stays disabled until the operator accepts leaving it out (`acknowledgeSkipped`) | the web chart is named, not numeric |
| Two source accounts on one web code would write two OP_DATA rows | Their heads are added (Cr +, Dr -) into one row | one opening per account |
| A file of another company empties the masters | Refused: the file has rows but none for this company | nothing replaced by nothing |
| Tag stock rows by refresh (Ac_Stock.cs:24 joins book 000) | `TAGOP` rows only when the company's book 000 is an opening-stock book; with no book 000 the installer's (`OPSTK`) applies | as the desktop join |
| One parse per PC | At most 2 parsing workers per process and one file per tenant at a time; rows counted inside the worker; the JSON fixture reader never runs with `NODE_ENV=production` | shared server |
| Address line with `'` blanked (`:8722-8752`) | Kept | the blanking only protected string-built SQL |
| `NULL` mobile/PR_CODE/number crashes the import | Written as `''` / 0 (Fnv) | no half-finished import |
| Over-long value stops SQL Server mid-way | Listed as a row error; nothing imported | atomic |
| `AC_MAST.LC_CODE '00'` | The session location | the web's main location is `01` |

## Rights

The desktop opens the form on `USER_SET.FRM_VIEW` for the caption (`MDI_FORM.cs:7034-7046`, "You Have No Rights.....")
and Lite Soft checks nothing more. The web form `Utilities/Data Import` (alias "Data Import"): preview is a read, import
a create; both need View, and a refusal carries the desktop text (G225 settled for this caption).

## Evidence

- `web/apps/api/test/dataImportLite.test.ts`: every mapping rule with hand-worked values; reader caps and allow-list.
- `web/apps/api/test/dataImport.db.test.ts`: full write set, refusal, stale preview, row errors, rollback on a fault in
  five different tables, second tenant untouched.
- Browser module `data-import` (`web/apps/web/test/features/modules/dataImport.mjs`): T01-T18 through the screen with
  the table fixture (`DATACARE_IMPORT_FIXTURE_READER=1`, test harness only). Blocked: reading a real Lite `.mdb` — no
  sample file in the repository; the owner must supply one sanitized or synthetic file.
