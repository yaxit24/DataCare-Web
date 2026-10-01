# Desktop business rules and data conventions

The rules the web must reproduce for business results to match the desktop. Each rule names its source; rules
marked *observed* come from aggregate queries of the desktop databases
(`docs/master-parity-plan-2026-09-29/evidence/audit-2026-10-01/desktop-conventions.json`). Where a rule differs by
form or setting, the form's own source wins.

## Identity and scope

- **Voucher key.** `CO_CODE(2) + LC_CODE(2) + CO_YEAR(9) + CO_BOOK(3) + VCH_NO(5)`. Book and number alone collide
  across companies, locations and years (`web/docs/HANDOFF.md:121-135`).
- **Location `00`.** *Observed:* all 1,096 `BOOK_DATA` rows use 3-digit numeric book codes at location `00`; every
  `LOCT_MAST`, `BOOK_DETL`, posted `AC_DATA` and `SL_DATA` row is at `00`, and every ledger key starts `0100`. The code
  supports other locations; new locations copy their books from `00` (`unified/src/csharp/DataCareNext/MS_LOCT.cs:3612-3614`).
- **Books.** `MAIN_BOOK` is the family (`SALES`, `PURCHASE`, `CASH REC`, `BANK PAY`, …); `BOOK_SNAME` is stored as
  `VCH_TYPE` (*observed* on 39 of 40 families; opening stock differs) (`web/docs/HANDOFF.md:160-183`).
- **Account slots.** `BOOK_DETL` holds numbered account slots per book, not one account per book. Common meanings:
  1 sale/control, 2 cash, 3 kasar, 4 advance, 5 discount, 6 labour income, 7 cash purchase, 8 scheme bonus; the meaning
  can differ by book, so resolve it with the selected book (`web/docs/ROJMEL-HANDBOOK.md:233-258`).
- **Kasar accounts.** *Observed:* `00057` for outgoing and `00042` for incoming kasar in the seed company.
- **Hidden identity.** `HD_VCH_NO` is a hidden number taken from `TEMP_BOOK_DATA` per company, location and book
  (`unified/src/csharp/DataCareNext/TR_SALE.cs:14209-14243`) and carried on the voucher's rows; saving an edited
  voucher deletes and re-reserves its `TEMP_BOOK_DATA` row (`unified/src/csharp/DataCareNext/TR_SALE.cs:15147-15173`).
- **Deletion audit.** `DELETE_DATA` keeps scope, dates and times, voucher, account, amount and fine values, the
  hidden number, the original and deleting users and a description (`unified/src/csharp/DataCareNext/TR_SALE.cs:16320-16333`).
- **Ledger modes.** `DATA_TYPE` separates parallel books; reports offer A, B and C, where C is combined. The session's
  ledger mode is not inferred from the selected book.

## Ledger and day-book rows

- **`LEDR_KEY` has no single layout.** Sale money legs use 23 characters; scheme lines and cash `<line><leg>` tails
  use 33; cash Rojmel uses another 33-character layout; purchases mix 23-character money legs with 33-character fine
  legs (`web/docs/HANDOFF.md:137-158`).
- **Leg codes belong to the family.** Cash receipt uses 01/02 for party/cash and 03/04 for party/kasar; cash payment
  uses 05/06 and 07/08. "Party leg 01" is not a global rule (`web/docs/HANDOFF.md:160-183`).
- **`SIGN`** is the metal direction: blank for money legs, `+` metal in, `-` metal out. *Observed:* only these three
  values in 11,548 rows. `C`/`D` appear only in other fields such as opening-balance signs.
- **Rojmel** records movements, not double entry: usually one metal row per detail, conditional party, tax and tender
  rows, metal type `G`/`S`/`O` and `A` for money. An old-metal exchange row is deliberately `A` with weights, so metal
  is not counted twice ([`web/docs/ROJMEL-HANDBOOK.md`](../../../web/docs/ROJMEL-HANDBOOK.md)).
- **Party row only when outstanding.** `BILL_OS = grand total − paid now − kasar`; a party Rojmel row exists only when
  `BILL_OS` is not zero (*observed* on all 89 sampled sales) (`web/docs/HANDOFF.md:206-222`).

## Calculations

| Rule | Desktop behaviour | Source |
|---|---|---|
| Fine weight | `net × touch / 100` (karigar issue); karigar receipts use `net × (touch + wastage) / 100`; the normal sale branch uses `(net + ghat weight) × (touch + wastage) / 100`, other branches differ | `project-memory/video-research/_kb/KB_karigar.md:51-66,131`; `docs/master-parity-plan-2026-09-29/05-desktop-reference.md:61` |
| Sale amount basis | `SL_AMT_TYPE`: `F` fine, `G` gross, otherwise net; a line can override the company default; rate per piece, per 10 g, per 1,000 or per weight; entering an amount back-calculates the rate | `unified/src/csharp/DataCareNext/TR_SALE.cs:10765-10932,11436-11452` |
| Labour | Per piece, per gram of net or gross, per 1,000, percentage or fixed; with `LBR_WITH_GHT='N'` the net-weight branch uses net only, otherwise net + ghat | `unified/src/csharp/DataCareNext/TR_SALE.cs:11082-11131` |
| Rounding | Mixed `Conversion.Val`, `Strings.Format` and `Math.Round`; .NET `Math.Round` rounds half to even. Freeze each stage (weight, rate, labour, tax, header, final round) separately; one global half-up rule is wrong | [Document 05](../../master-parity-plan-2026-09-29/05-desktop-reference.md) |
| GST | On the taxable amount after discount; CGST + SGST inside the state, IGST across states; recorded on lines, headers, `TAX_DATA` and tax-account `AC_DATA` legs | `web-implementation-spec/04_Cross_Cutting_Engines/gst-engine.md:8-45` |
| TCS | Sale TCS compares accumulated receipts plus the current amount with a 5,000,000 threshold and prorates the crossing amount (source behaviour, not current law) | `unified/src/csharp/DataCareNext/TR_SALE.cs:19201-19251` |
| TDS | `SL_TDS_TAX` and `PR_TDS_TAX` (from `CO_SET_NEW`) enable TDS; the purchase screen loads the party's TDS code and rate and the payable is reduced by TDS | `unified/src/csharp/DataCareNext/MS_OPNCOMP.cs:971-972`; `unified/src/csharp/DataCareNext/TR_PURC.cs:12158-12173` |
| Hallmark charge | Separate `HM_AMT` with its own tax code, rate and amount; separate tax-register rows written by the GST helper | `unified/src/csharp/DataCareNext/TR_SALE_HM.cs:10441-10454,11643-11645`; `unified/src/csharp/DataCareNext/Ac_Tax.cs:81-94` |
| Kasar and round-off | Kasar reduces `BILL_OS` and posts to the Avak or Javak account; `ROF_AMT` is the separate bill round-off | `web/docs/HANDOFF.md:166-181` |
| Old-metal exchange | Pieces, gross, net, touch, fine and rate in `SL_PR_DETL`; metal enters stock; value is credited to the sale tender | `project-memory/video-research/_kb/KB_transaction.md:70-77` |
| Fine trade and rate cut | Value = fine × fine rate; a rate cut draws down the open position (`ITM_FINE − FINE_CUT_FINE`), increments `FINE_CUT_*` and writes stock, ledger and tax rows; delete subtracts the increments | `web-implementation-spec/03_Modules/11_Bullion_Tour_VP/TR_FINE_SL_PR.md:12-22`; `unified/src/csharp/DataCareNext/TR_FINE_SL_PR.cs:4476-4481,4703-4737,4824-4845` |
| Dhiran interest | Daily: principal × rate / 100 / year days × days; compound: annual compounding then monthly proration; months = round(pending days / 30 − 0.51) + 1; rate-cut converts interest through the fine rate | [Document 05](../../master-parity-plan-2026-09-29/05-desktop-reference.md) |

## Company and year creation

- `MS_YEAR` creates the yearly database. Only for a **new company** it calls `NewCompParmCreat`
  (`unified/src/csharp/DataCareNext/MS_YEAR.cs:1357-1363`), which copies 17 tables from a chosen company or company 01
  (`unified/src/csharp/DataCareNext/MS_YEAR.cs:1504-1595`):
  `AC_GROUP`, `AC_MAST` (codes below 101), `BAL_GR`, `BOOK_DATA` and `BOOK_DETL` at location `00`, `CO_SET`,
  `CO_SET_NEW`, `COL_MAST`, `CONV_MAST`, `EMP_MAST` (employee 001), `GROUP_MAST` and `ITEM_MAST` (12 codes each),
  `LOCT_MAST` (location 00), `PRINT_MAST`, `PRODUCT_MAST`, `TABLE_MAST` and `TAX_MAST`.
- *Observed:* the 35 `AC_GROUP` rows are identical in every desktop company; the seed company is in `Next24`.
- The web does not yet do this: year creation calls `cloneCompanyTx` (`web/apps/api/src/modules/masters/year.ts:72`)
  and provisioning creates 9 tables at location `01` (gaps G38, G39; slice N58; decision D15).

## Data model

- Naming: `*_DATA` header, `*_DETL` line, `*_IDTL` stone/component sub-detail, `*_MAST` reference data, `*_OS`
  outstanding. Cross-cutting tables: `AC_DATA` (ledger), `ROJ_MEL_DATA` (day book), `TAX_DATA`, `MAIN_STOCK`,
  `BILL_OS_DATA`, `SRNO_MAST` (serials), `TEMP_BOOK_DATA`, `DELETE_DATA`
  (`web-implementation-spec/02_Data_Model/overview.md:1-37`).
- Families: company and security (`CO_MAST`, `YEAR_MAST`, `LOGIN_MAST`, `USER_SET`, settings, books), accounts, sales
  `SL_*`, purchase `PR_*`, tags and lots `BAR_*`, finance, karigar and manufacturing `KR_*`/`MFG_*`, Dhiran `DHRN_*`,
  schemes `AD_*` and points `POINT_*`, approval and tour `APR_*`, bullion `BUL_*`, rate cut `RATE_CUT_*`.
- Two schema universes: the audited real database has 146 tables with 5,254 columns and no procedures, views,
  triggers or foreign keys; the reconstructed `data-model.json` has 162 tables. Full detail:
  `project-memory/catalogs/realdb-schema-full.json`, `project-memory/catalogs/erd-core.md` and one page per table in
  `web-implementation-spec/02_Data_Model/tables/`.

## Settings

- `UT_SETTING` and `UT_SETTING_MAIN` edit `CO_SET` and `CO_SET_NEW`; after a company opens, `MS_OPNCOMP` copies the
  values into process-wide `DC_Main.Ms*` variables (`CO_SET`: `unified/src/csharp/DataCareNext/MS_OPNCOMP.cs:657-713`;
  `CO_SET_NEW`: `unified/src/csharp/DataCareNext/MS_OPNCOMP.cs:948-1011`).
- Settings with the largest effect on results: `LOCK_DATE`; `CASH_LIMIT` and `PAN_CARD_VAL`; `SL_AMT_TYPE` and
  `PR_AMT_TYPE`; `TAX_CODE`, `TAX_ROF` and `TOT_AMT_ROF`; `SL_TDS_TAX` and `PR_TDS_TAX`; `EMP_CODE_MANDATORY`;
  `NEGATIVE_STK_SALE`; `SL_NWT_LOCK`; `SL_TAG_WT_DIFF`; rate-master and rate-rounding settings; `LBR_TYPE`,
  `LBR_WITH_GHT` and `LBR_ROF`; Dhiran interest type, year days and compounding; manufacturing one-form, order and lot
  routing; counter and branch visibility; country and currency conversion; print-copy and QR settings; weighing-scale
  port and messaging settings ([document 09](../../master-parity-plan-2026-09-29/09-surface-register.md)).
- A setting whose only evidence is its name and consumer list must be traced through each consumer before it is
  treated as a rule.

## Printing and reports

- **Templates.** 255 Crystal `.rpt` files; 275 names are referenced by code, of which 20 have no recovered file
  (alias, unreachable or retired). Geometry was extracted for 254 templates to `extraction_output/rpt_xml/`.
- **Selection.** `PRINT_MAST(CO_CODE, PRINT_TYPE, PRINT_FILE, BOOK_TYPE, PRINT_SET_A)` lists the candidate and default
  template per transaction and book type. Sales looks it up at `unified/src/csharp/DataCareNext/TR_SALE.cs:13933-13963`
  and overrides it at `unified/src/csharp/DataCareNext/TR_SALE.cs:16484-16500` (book 099 prints SalesQuotation, HUID
  sales print RtlHuidPrint, one edition overrides SalesBillHzGST). Purchase prints at
  `unified/src/csharp/DataCareNext/TR_PURC.cs:14021-14062`, cash at `unified/src/csharp/DataCareNext/TR_CASH.cs:3325-3334`.
- **Copies.** Original, Duplicate and Triplicate are independent; each prints its copy label.
- **Report families.** Accounting and ledger 45, stock and tag 39, manufacturing and karigar 34, sales 32, purchase 16,
  Dhiran 15, schemes 14, orders 13, tour/bullion/VP 11, wholesale 11, other 11, GST 7, Rojmel 7
  (`web-implementation-spec/05_Reports/README.md:112-138`).
- **Report scratch tables.** `RP_*` forms rebuild `REPORT_DATA`, `LEDR_AC_DATA`, `TAG_STOCK_PRINT`, `FINE_DATA` and
  `ROJMEL_BAL` per run; these are not business vouchers.

## Language

- Crystal reports use the Gujarati font KAP139 (`extraction_output/rpt_xml/Form8.xml:353`).
- The SMS and WhatsApp screens translate message text online between languages the operator chooses
  (`unified/src/csharp/DataCareNext/UT_SMS.cs:4711-4718`, `unified/src/csharp/DataCareNext/UT_WHATSAPP.cs:6196-6203`,
  using `unified/src/csharp/DataCareNext/Translator.cs:31-98`). The web will use reviewed catalogues instead (D22,
  slice N76, still planned).
