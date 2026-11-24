# WP-14 cases: Report → Order Report — frozen T01–T18 case list

Feature slug: `order-report` (case-id style of `web/apps/web/test/features/modules/salesReport.mjs`, which uses
`sales-report.<group>.<name>` on the same RP_ALL engine). The future browser module is named `orderReportRp.mjs`
(decision D12) so it is never confused with the per-order voucher print in `orderReportLayout.ts`.

Inputs: `orchestration/work/WP-14/study.md` (the study; every desktop quote below is copied from it, or from the
source line named), `docs/master-parity-plan-2026-09-29/04-verification-playbook.md` §3 (T01–T18), the seven
template XMLs under `extraction_output/rpt_xml/` (group, sort, formula and summary definitions, read for this
case list as the study's open question 5 required), and `docs/parity/rpall-sales-inventory.md` §6 (the Sales
adapter's recorded deliberate differences).

Status semantics: `executable` means no blocker outside this menu. Today every browser and database case below
fails, because the screen, the route and the `order` adapter do not exist (study gap 1); that red state is what
this list drives, not a reason to mark cases blocked. `N/A` kinds keep their reason in the coverage table.
Template and web facts are cited `file:line` without quotes (the citation script reads C# lines only); desktop
facts carry `FORM.cs:N {{quoted text}}`.

Seed orders O1–O8, bills S1–S2 and masters P1/P2 etc. are defined once in `## Test data` and referenced by name.
Unless a case says otherwise the session is company C1, location `01`, financial year 2026, and the selectors are
From `01/01/2026`, To `31/01/2026`, every other selector empty.

## Decisions (architect, 2026-11-23, owner may override)

Each decides one open question of the study by the standing rule "the desktop first; the web adds only what a
hosted multi-user service needs to be safe and correct".

- **D1 — Lite visibility (open question 1): the menu is Lite and visible.** Resolved by the handbook, not a
  guess: `docs/handbook/menu-editions.json:1540-1548` lists `Report/Order Report` with `"edition": "L"`,
  `"visible": true`. The dispatch itself has no edition check (`MDI_FORM.cs:8931 {{case "Order Report":}}`).
- **D2 — "Design issued" / the writing report (open question 2): the web report is read-only and derives the
  pending set.** The desktop flags every fully adjusted order of the company and location
  (`RP_ALL.cs:10933 {{UPDATE SL_ORD_DETL SET DESIGN_ISU = 'Y' WHERE CO_CODE = '}}`, executed per order by
  `RP_ALL.cs:10934 {{DC_Main.ExeQuteDc(DC_Main.RsQry);}}`) and then prints only lines still `N`
  (`RP_ALL.cs:10940 {{AND {SL_ORD_DETL.DESIGN_ISU} = 'N'}}`). The visible result is therefore: a line prints in
  Making Panding / Making Summ iff its stored `DESIGN_ISU` is `N` **and** its order is not in the fully adjusted
  set (`RP_ALL.cs:10927 {{HAVING SUM(CASE WHEN B.ORD_SIGN = '+' THEN B.ORD_AMT ELSE - B.ORD_AMT END)  = 0}}`,
  company and location scoped, **not** date or filter scoped). The stored flag matters because other screens
  write it too: a stock-less order line is saved with `Y` (`TR_SALE_ORD.cs:9276 {{dataRow3["DESIGN_ISU"] = "Y";}}`)
  and an approval issue sets `Y` (`TR_APR_ISU.cs:6396 {{UPDATE SL_ORD_DETL SET SL_ORD_DETL.DESIGN_ISU = 'Y' FROM SL_ORD_DETL,APR_DETL AS B}}`).
  The web reproduces the visible rows with that predicate and never writes the flag (study weakness 2; hard rule
  against partial writes). Consequence, accepted: a web run does not change what the desktop's karigar-issue
  lists would show after a desktop run; persisting the flag is a separate, rights-checked action outside WP-14.
- **D3 — "Cancelled" orders (open question 3): this form has no status distinction.** No handler appends a
  status clause; modes 1 and 2 list every order in the range, open, delivered or cancelled alike (study
  Lifecycle). Cancel semantics belong to the Order Cancel screen (G245), out of scope here.
- **D4 — `MsDataType` A/B/C (open question 4): not ported, exactly as the Sales adapter.** The desktop appends
  `BOOK_DATA.DATA_TYPE` only for session value A or B (`RP_ALL.cs:8405 {{if (Operators.CompareString(DC_Main.MsDataType, "A", false) == 0)}}`);
  the web session has no such value and the Sales branch already omits it
  (`docs/parity/rpall-sales-inventory.md:178-180`, "not ported … Needs an owner decision before it is ported").
  The Order adapter omits the clause too; books of both data types list. Owner may override.
- **D5 — template group/sort order (open question 5): settled by reading the XMLs.** Per-mode group and sort
  keys are listed in case `order-report.grouping.template-groups` with XML line citations; no case is blocked on
  row order.
- **D6 — rights row (open question 6, G225): the caption's own row.** The desktop reads USER_SET for
  `SUB_MENU = "Order Report"` (`MDI_FORM.cs:7034 {{DC_Main.MsUserRightForm = MsSideBtn;}}`,
  `RP_ALL.cs:6656 {{Select * From USER_SET WHERE LC_CODE = '}}`); it never reads the Sales Order row. The web
  route checks the "Order Report" caption (new alias in `formCatalog.ts`); a Sales Order right alone grants
  nothing here. The catalog's present pointer at `/txn/sales-order` is the gap, not the rule.
- **D7 — print rights (study gap 11): enforced like the Sales Report.** The desktop loads `FRM_PRINT` and never
  compares it (`RP_ALL.cs:6777 {{UserPrint = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["FRM_PRINT"], (object)""));}}`);
  the web Sales Report refuses export without the print right (`salesReport.mjs` case
  `sales-report.scope.tenant-company-location-year-book-rights`). A hosted multi-user service needs that check;
  the Order Report follows the same rule. Running/listing needs the caption's list right.
- **D8 — dead selectors (study weakness 9): Pr Code, Gr Code and Item Type are shown disabled.** They are
  visible on the desktop and read by no Order handler; the web keeps the surface but disables them instead of
  building dead active filters. Employee and Select Book stay hidden
  (`RP_ALL.cs:6400 {{((Control)cboEmploy).Visible = false;}}`, `RP_ALL.cs:6539 {{((Control)chkBookSelect).Visible = false;}}`).
- **D9 — Cust Name help source (study weakness 8, gap 13): kept as the desktop.** The help lists names from
  `SL_ORD_DATA` in every mode (`RP_ALL.cs:9693 {{SELECT A.AC_NAME As CustomerNameL,A.AC_CODE AS AcCodel FROM SL_ORD_DATA AS A WHERE A.CO_CODE}}`),
  even though mode 7 filters `SL_DATA.AC_NAME` (`RP_ALL.cs:12631 {{CurFormula = CurFormula + " And {SL_DATA.AC_NAME} = '" + tCustName.Text + "'";}}`).
  The mismatch is the desktop behaviour and is reproduced with a bound lookup; it is not a safety weakness.
- **D10 — bad dates (study weakness 6): the web refuses an impossible or incomplete date with a clear message;
  From after To stays an empty report.** The desktop has no guard (only the mask and
  `DC_Main.cs:1561 {{public static void SetDate(ref MaskedTextBox MsDate)}}`); a runtime crash is not ported,
  the empty-range result is (`RP_ALL.cs:8380 {{CurFormula = "{SL_ORD_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {}}`).
- **D11 — the hard-coded default (study weakness 7): the visible default From `01/01/2010` is kept**
  (`RP_ALL.cs:7177 {{mFromDt.Text = "01/01/2010";}}`); it is the desktop's constructor branch, not a weakness to
  redesign. To defaults to the system date (`RP_ALL.cs:7203 {{mToDt.Text = Conversions.ToString(DC_Main.MsSysDate);}}`).
- **D12 — naming (study gap 14): the new browser module is `orderReportRp.mjs`, the page is a dedicated
  `/reports/order-report` surface, and the menu-catalog row is updated when the page exists.** The existing
  `orderReportLayout.ts` / `orderReport.test.ts` voucher print is untouched.
- **D13 — study correction, mode 7 totals.** The study's Lifecycle §7 says mode 7 totals
  `Sum ({@AdjAmt}, {SL_ORD_DATA.VCH_NO})`; the template has no summary fields at all
  (`extraction_output/rpt_xml/BillWiseOrderAdjust.xml:398` is `<SummaryFields />`, and no field object prints
  `@PandingTot`). Mode 7 prints no total band; the cases below expect that. The `Sum (...)` total belongs to
  mode 4 only (`extraction_output/rpt_xml/OrdAdjBillWise.xml:419`).

## Cases

### order-report.entry.menu-route   (T01 Entry/defaults)
Layer: browser
Steps: 1. Sign in as a Lite-edition user with the Order Report right. 2. Open Report → Order Report from the menu.
Expected: a dedicated Order Report screen opens (the future `/reports/order-report` page), not the Sales Order
screen `/txn/sales-order` that the catalog row points at today; the form title label reads "Order Report"
(`RP_ALL.cs:6659 {{lblBook.Text = CurRpt;}}`, mode from the caption via `RP_ALL.cs:6658 {{CurRpt = DC_Main.MsUserRightForm;}}`).
The menu is present in Lite (D1). Fails today: gap 14 (catalog row `docs/handbook/menu-catalog.jsonl:184` says
UI `/txn/sales-order`) and gap 1 (no page).
Status: executable

### order-report.entry.defaults-and-seven-buttons   (T01 Entry/defaults)
Layer: browser
Steps: 1. Open the screen as the location-`01` user. 2. Record every selector default, the visible controls and
the panel buttons in tab order.
Expected: From `01/01/2010` (`RP_ALL.cs:7177 {{mFromDt.Text = "01/01/2010";}}` under the branch
`RP_ALL.cs:7175 {{if (Operators.CompareString(CurRpt, "Order Report", false) == 0)}}`), To = system date
(`RP_ALL.cs:7203 {{mToDt.Text = Conversions.ToString(DC_Main.MsSysDate);}}`), initial focus on From
(`RP_ALL.cs:7204 {{CurActCtrl = (Control)(object)mFromDt;}}`); date mask `00/00/0000`
(`RP_ALL.cs:5619 {{mFromDt.Mask = "00/00/0000";}}`); lc Code shows `01` and is disabled
(`RP_ALL.cs:6662 {{tLcCode.Text = DC_Main.MLc_code;}}`, `RP_ALL.cs:6664 {{((Control)tLcCode).Enabled = false;}}`);
Book, Pr Code, Gr Code, Party Code, Cust Name empty; City and Area show one blank item; Item Type index 0;
Party Code max 8 (`RP_ALL.cs:4813 {{((TextBoxBase)tAcCode).MaxLength = 8;}}`), Cust Name max 50
(`RP_ALL.cs:5792 {{((TextBoxBase)tCustName).MaxLength = 50;}}`). Pr Code, Gr Code, Item Type are disabled (D8).
No Employ box, no Select Book box (`RP_ALL.cs:6400 {{((Control)cboEmploy).Visible = false;}}`,
`RP_ALL.cs:6539 {{((Control)chkBookSelect).Visible = false;}}`). Exactly seven panel buttons
(`RP_ALL.cs:6715 {{((Control)PanelOrder).Visible = true;}}`), in tab order 0–6 with captions verbatim:
`&Order Report` (`RP_ALL.cs:5360 {{btnOrdRpt.Text = "&Order Report";}}`),
`&Order Advance` (`RP_ALL.cs:5386 {{btnOrdAdvance.Text = "&Order Advance";}}`),
`&Order Adjust` (`RP_ALL.cs:5412 {{btnOrdAdj.Text = "&Order Adjust";}}`),
`&Order Wise Bill ` with trailing space (`RP_ALL.cs:5334 {{btnOrdWithBill.Text = "&Order Wise Bill ";}}`),
`&Making Panding` (`RP_ALL.cs:5308 {{btnOrdMakePan.Text = "&Making Panding";}}`),
`& Making Summ` with space after `&` (`RP_ALL.cs:5282 {{btnDesignSumm.Text = "& Making Summ";}}`),
`Bill Wise Adjust` (`RP_ALL.cs:5256 {{btnbillwiseordadj.Text = "Bill Wise Adjust";}}`).
Fails today: gaps 1 and 9.
Status: executable

### order-report.entry.location-lock   (T01 Entry/defaults)
Layer: browser
Steps: 1. Open the screen as a user whose session location is `01`. 2. Try to edit lc Code. 3. Repeat as a user
whose session location is `00`.
Expected: at `01` the field is disabled and every mode filters `LC_CODE = '01'`
(`RP_ALL.cs:6660 {{if (Operators.CompareString(DC_Main.MLc_code, "00", false) != 0)}}`,
`RP_ALL.cs:6664 {{((Control)tLcCode).Enabled = false;}}`); at `00` the field is enabled, still pre-filled `00`,
and may be changed to another location or cleared; a cleared lc Code appends no location clause
(`RP_ALL.cs:8383 {{CurFormula = CurFormula + " And {SL_ORD_DATA.LC_CODE} = '" + tLcCode.Text + "'";}}` is
conditional on non-empty text), so the `00` user can list all locations. Sentinel O6 (location `00`) appears
only in that all-locations run. Fails today: gap 9.
Status: executable

### order-report.filters.one-at-a-time   (T02 Field route)
Layer: browser
Steps: 1. With the default range, run mode 1 with each selector alone: Book `B1`; Party Code `P1`;
City `SURAT`; Area `ADAJAN`; Cust Name `ALPHA JEWELS`; then Pr Code `I1`, Gr Code `G1`, Item Type `Gold`.
2. For each run inspect the request filter and the returned rows.
Expected: Book `B1` → orders O1, O3, O4 (clause `RP_ALL.cs:8387 {{CurFormula = CurFormula + " And {SL_ORD_DATA.CO_BOOK} = '" + tBookCode.Text + "'";}}`);
Party `P1` → O1, O3 (`RP_ALL.cs:8391 {{CurFormula = CurFormula + " And {SL_ORD_DATA.AC_CODE} = '" + tAcCode.Text + "'";}}`);
City `SURAT` → O1, O3 (`RP_ALL.cs:8395 {{CurFormula = CurFormula + " And {AC_MAST.AC_CITY} = '" + cboCity.Text + "'";}}`);
Area `ADAJAN` → O1, O3 (`RP_ALL.cs:8399 {{CurFormula = CurFormula + " And {AC_MAST.AC_AREA} = '" + cboArea.Text + "'";}}`);
Cust Name `ALPHA JEWELS` → O1, O3, exact stored name (`RP_ALL.cs:8403 {{CurFormula = CurFormula + " And {SL_ORD_DATA.AC_NAME} = '" + tCustName.Text + "'";}}`).
Pr Code, Gr Code, Item Type change nothing: no handler appends them (study Rules; the clause chain ends at
`RP_ALL.cs:8405 {{if (Operators.CompareString(DC_Main.MsDataType, "A", false) == 0)}}`), and on the web they are
disabled (D8). Each value reaches request, query and result; no dead active field. Fails today: gaps 2, 9.
Status: executable

### order-report.filters.date-range-no-year   (T02 Field route)
Layer: browser
Steps: 1. Run mode 1 with From `01/01/2026`, To `31/01/2026`. 2. Move an order's date to 31/12/2025 and to
01/02/2026 in two variants. 3. Set From `01/12/2025`, To `31/01/2026` and run again with prior-year order O5 present.
Expected: the range is inclusive on `VCH_DATE` (`RP_ALL.cs:8380 {{CurFormula = "{SL_ORD_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {}}`
builds `VCH_DATE >= #From# AND VCH_DATE <= #To#`): an order dated 01/01/2026 or 31/01/2026 is listed, one dated
31/12/2025 or 01/02/2026 is not. With From `01/12/2025` the prior-year order O5 (year 2025, dated 20/12/2025)
**is** listed: buttons 1–5 append no `CO_YEAR` clause (contrast the Sales With Order handler
`RP_ALL.cs:11748 {{CurFormula = "{SL_DETL.CO_CODE} = '" + DC_Main.MCo_code + "' AND {SL_DETL.CO_YEAR} = '"}}`,
which does). Fails today: gap 2.
Status: executable

### order-report.filters.combined-city-area-walkin   (T02 Field route)
Layer: browser
Steps: 1. Run mode 1 with Book `B1` AND Party `P1` AND City `SURAT`. 2. Run with no city/area filter and note
walk-in order O4. 3. Run with City `SURAT` only. 4. Run with City `SURAT` AND Area `ALKAPURI`.
Expected: filters combine as AND in the fixed order lc, book, party, city, area, cust name
(`RP_ALL.cs:8383 {{CurFormula = CurFormula + " And {SL_ORD_DATA.LC_CODE} = '" + tLcCode.Text + "'";}}` through
`RP_ALL.cs:8403 {{CurFormula = CurFormula + " And {SL_ORD_DATA.AC_NAME} = '" + tCustName.Text + "'";}}`):
step 1 → O1, O3; step 2 lists O4 (its customer name comes from the stored `SL_ORD_DATA.AC_NAME`, so the missing
AC_MAST row does not hide it); step 3 drops O4 because the city clause filters the joined `AC_MAST`
(`RP_ALL.cs:8395 {{CurFormula = CurFormula + " And {AC_MAST.AC_CITY} = '" + cboCity.Text + "'";}}`) and O4 has no
account row; step 4 → empty (no party is in both SURAT and ALKAPURI). Fails today: gaps 2, 9.
Status: executable

### order-report.formula.order-adjust-signs   (T03 Formula sequence)
Layer: browser
Steps: 1. Run mode 3 (Order Adjust, template `OrdAdvAdj`, `RP_ALL.cs:8550 {{DC_Main.RptName = "OrdAdvAdj";}}`)
with the default range. 2. Read every detail row, each group band and the grand band.
Expected: one row per `SL_ORD_ADJ` row of the in-range orders: O1 shows `+` 5000, `-` 1500, `-` 500; O3 shows
`+` 3000, `-` 1500, `-` 1500; O2, O4, O8 have no adjustment rows and print no detail. The template formulas
(`extraction_output/rpt_xml/OrdAdvAdj.xml:246-251`) are `@OrdAmt = if ORD_SIGN='+' then ORD_AMT` (else 0) and
`@OrdAdjAmt = if ORD_SIGN='-' then ORD_AMT` (else 0); `@BalAmt = @OrdAmt - @OrdAdjAmt`
(`extraction_output/rpt_xml/OrdAdvAdj.xml:240-241`). Groups are `@OrdGroup = ORD_LC+ORD_YRCD+ORD_DBCD+ORD_NO`
(`extraction_output/rpt_xml/OrdAdvAdj.xml:252-253`), i.e. one group per adjusted order. Arithmetic: O1 group
OrdAmt 5000, OrdAdjAmt 1500+500=2000, BalAmt 5000−2000=3000; O3 group OrdAmt 3000, OrdAdjAmt 1500+1500=3000,
BalAmt 0; grand OrdAmt 5000+3000=8000, OrdAdjAmt 2000+3000=5000, BalAmt 3000+0=3000. This sign convention is
the desktop's own balance rule (`RP_ALL.cs:10927 {{HAVING SUM(CASE WHEN B.ORD_SIGN = '+' THEN B.ORD_AMT ELSE - B.ORD_AMT END)  = 0}}`).
Fails today: gap 4.
Status: executable

### order-report.formula.pcs-nwt-totals   (T03 Formula sequence)
Layer: browser
Steps: 1. Run mode 1 (Order Report, `RP_ALL.cs:8418 {{DC_Main.RptName = "OrdDetlRpt";}}`) with the default
range. 2. Read the grand-total band. 3. Run mode 5 (Making Panding, `RP_ALL.cs:10978 {{DC_Main.RptName = "OrdDetlPanding";}}`)
and read its grand band.
Expected: mode 1 lists one row per order line — O1 line 1 (pcs 1, nwt 10.500), O1 line 2 (pcs 2, nwt 5.250),
O2 (pcs 3, nwt 7.125), O3 (pcs 1, nwt 4.000), O4 (pcs 1, nwt 2.000), O8 (pcs 1, nwt 3.000) — with no status
filter (cancelled and delivered orders alike, D3). Grand totals are `Sum (ITM_PCS)` and `Sum (ITM_NWT)`
(`extraction_output/rpt_xml/OrdDetlRpt.xml:309-310`): pieces 1+2+3+1+1+1 = **9**, net weight
10.500+5.250+7.125+4.000+2.000+3.000 = **31.875**. Mode 5 prints only the pending lines (case
`order-report.formula.pending-set`): O1's two lines, O2, O4 → pieces 1+2+3+1 = **7**, net weight
15.750+7.125+2.000 = **24.875** (`extraction_output/rpt_xml/OrdDetlPanding.xml:403-404`, same two sums).
The form itself computes nothing; every sum is the template's (study Calculations). Fails today: gaps 2, 6.
Status: executable

### order-report.formula.order-advance-tender   (T03 Formula sequence)
Layer: browser
Steps: 1. Run mode 2 (Order Advance, `RP_ALL.cs:8484 {{DC_Main.RptName = "OrdAdvRpt";}}`) with the default range.
2. Read every row and look for a grand-total band.
Expected: one row per order header, grouped by customer name ascending: ALPHA JEWELS → O1 (order total
`TOT_AMT` 20000, cash 5000, card 0, cheque 0, old gold 0, old silver 0, advance `ADV_AMT` 5000) and O3
(total 9000, advance 3000); BETA TRADERS → O2 (total 9000, all tenders 0, advance 0) and O8; WALK IN CUSTOMER →
O4. Every tender value is the stored `SL_ORD_DATA` column, not a recomputation; the template defines **no**
summary field (`extraction_output/rpt_xml/OrdAdvRpt.xml` has no `SummaryFieldDefinition`), so there is no grand
total band. Fails today: gap 3.
Status: executable

### order-report.formula.order-wise-bill-total   (T03 Formula sequence)
Layer: browser
Steps: 1. Run mode 4 (Order Wise Bill, `RP_ALL.cs:9776 {{DC_Main.RptName = "OrdAdjBillWise";}}`) with the
default range. 2. Read the detail rows and the per-order total bands.
Expected: the base is the order, left-joined to its adjustments and then to the bill
(`extraction_output/rpt_xml/OrdAdjBillWise.xml:21-62`, all `LeftOuter`): O1 prints its `+` 5000 advance row with
empty bill fields (the `+` row's own voucher keys are the order's, so no `SL_DATA` row matches) and its two `-`
rows with bill S1, bill total 12000; O3 prints `+` 3000 (empty bill) and two `-` 1500 rows with bill S2, bill
total 9000; O2, O4, O8 print one row with empty adjustment/bill fields. The total is
`Sum ({@AdjAmt}, {SL_ORD_DATA.VCH_NO})` (`extraction_output/rpt_xml/OrdAdjBillWise.xml:419`) with
`@AdjAmt = if ORD_SIGN='-' then ORD_AMT` else 0 (`extraction_output/rpt_xml/OrdAdjBillWise.xml:399-401`):
O1 total 1500+500 = **2000** (the `+` 5000 contributes 0), O3 total 1500+1500 = **3000**, O2/O4/O8 total **0**.
There is no grand total across orders (only the per-order summary exists). Fails today: gap 5.
Status: executable

### order-report.formula.pending-set   (T03 Formula sequence)
Layer: database
Steps: 1. With the default range, run mode 5 and mode 6 (answer No to the prompt) and record the line keys.
2. Widen the range to From `01/12/2025` and run mode 5 again. 3. Query `SL_ORD_DETL.DESIGN_ISU` for every order.
Expected: the pending set is derived, never written (D2). A line prints iff stored `DESIGN_ISU = 'N'`
(`RP_ALL.cs:10940 {{AND {SL_ORD_DETL.DESIGN_ISU} = 'N'}}`) and its order is **not** in the fully adjusted set
(`RP_ALL.cs:10927 {{HAVING SUM(CASE WHEN B.ORD_SIGN = '+' THEN B.ORD_AMT ELSE - B.ORD_AMT END)  = 0}}`):
O1 nets +5000−1500−500 = +3000 → pending; O3 nets +3000−1500−1500 = 0 → excluded; O2 has no adjustment row,
the LEFT JOIN sum is NULL and `NULL = 0` is false → **not** selected → pending (study Lifecycle §5); O4 pending;
O8 is stored `Y` (stock-less, `TR_SALE_ORD.cs:9276 {{dataRow3["DESIGN_ISU"] = "Y";}}`) → excluded even though it
is not fully adjusted. Step 1 therefore prints exactly O1 line 1, O1 line 2, O2, O4. Step 2: O5 (year 2025) is
fully adjusted by adjustments dated 2025; the desktop's set query is scoped by company and location only
(`RP_ALL.cs:10927 {{DC_Main.RsQry = "Select A.CO_YEAR,A.CO_BOOK,A.VCH_NO FROM SL_ORD_DATA }}`, no date clause —
study weakness 3), so O5's lines stay excluded even though the adjustments fall outside the printed range; the
web predicate must use the same unscoped set. Step 3: every `DESIGN_ISU` value is exactly as seeded (the desktop
would have set O3's and O5's lines to `Y` via `RP_ALL.cs:10933 {{UPDATE SL_ORD_DETL SET DESIGN_ISU = 'Y' WHERE CO_CODE = '}}`;
the web must not). Fails today: gaps 6, 7.
Status: executable

### order-report.formula.bill-wise-adjust   (T03 Formula sequence)
Layer: browser
Steps: 1. Run mode 7 (Bill Wise Adjust, `RP_ALL.cs:12646 {{DC_Main.RptName = "BillWiseOrderAdjust";}}`) with the
default range. 2. Set Cust Name `ALPHA JEWELS` and run again. 3. Look for any total band.
Expected: the base is the **sale bill** table: `RP_ALL.cs:12608 {{CurFormula = "{SL_DATA.CO_CODE} = '}}` with
`RP_ALL.cs:12611 {{CurFormula = CurFormula + " And {SL_DATA.LC_CODE} = '" + tLcCode.Text + "'";}}`. Rows are the
bills that carry adjustments: S1 (party ALPHA JEWELS, book SB, bill total 12000, advance on bill 0) with its two
adjustment rows against O1 (year 2026, book B1, amounts 1500 and 500, order party from live `AC_MAST.AC_NAME`),
and S2 with two rows against O3 (1500, 1500). The printed adjusted amount is the raw `ORD_AMT`
(`@AdjAmt = {SL_ORD_ADJ.ORD_AMT}`, `extraction_output/rpt_xml/BillWiseOrderAdjust.xml:378-379`, no sign logic).
Cust Name filters the **bill's** stored name, `RP_ALL.cs:12631 {{CurFormula = CurFormula + " And {SL_DATA.AC_NAME} = '" + tCustName.Text + "'";}}`:
step 2 keeps S1 and S2 (both bills are party P1's). There is **no** total band: the template has no summary
fields (`extraction_output/rpt_xml/BillWiseOrderAdjust.xml:398`, `<SummaryFields />`; decision D13 corrects the
study here). Fails today: gap 8.
Status: executable

### order-report.lookup.book-party-location   (T04 Lookup)
Layer: browser
Steps: 1. In Book, press Enter empty; type `B1` + Enter; type `ZZ` + Enter, pick a book from the help, press
Enter again; repeat canceling the help. 2. Repeat in Party Code with `P1` and an unknown code. 3. As the `00`
user, repeat in lc Code with `01` and an unknown code.
Expected: empty Book + Enter tabs on (`RP_ALL.cs:7328 {{SendKeys.Send("{tab}");}}`); a known book shows its name
(`RP_ALL.cs:7322 {{tBookName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["BOOK_NAME"], (object)""));}}`)
and tabs; an unknown book opens the help of **all books of the session location**, not only order books
(`RP_ALL.cs:7303 {{SELECT A.BOOK_NAME As BookNameL,A.CO_BOOK As BookL FROM BOOK_DATA AS A}}`, lookup
`RP_ALL.cs:7299 {{Select * From BOOK_DATA WHERE CO_CODE = '}}`); picking writes code and name and focus returns
to Book (`RP_ALL.cs:7317 {{((Control)tBookCode).Focus();}}`); canceling leaves the typed text unchanged. Party:
known code → name and tab (`RP_ALL.cs:7382 {{Select * From AC_MAST WHERE CO_CODE = '}}`,
`RP_ALL.cs:7421 {{tAcName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Mai}}`); unknown → party
help (`RP_ALL.cs:7388 {{DC_Main.RsQry = "SELECT A.AC_NAME As AcNameL,A.AC_CODE As AcCodeL,B.AC}}`), pick fills
both fields, focus returns (`RP_ALL.cs:7416 {{((Control)tAcCode).Focus();}}`). Location (only editable at `00`):
known → name and tab; empty → tab (`RP_ALL.cs:7718 {{SendKeys.Send("{tab}");}}`); unknown → location help
(`RP_ALL.cs:7695 {{Select LC_CODE As CodeL,LC_NAME As NameL,LC_ADD1 As AddressL,LC_CITY As CityL FROM LOCT_MAST}}`).
A delayed help response never overwrites a newer selection. Fails today: gap 9.
Status: executable

### order-report.lookup.cust-name   (T04 Lookup)
Layer: browser
Steps: 1. Type `ALPHA JEWELS` in Cust Name and press Enter. 2. Type `NO SUCH NAME` and press Enter; pick a name
from the help; repeat and cancel. 3. Press Enter on the empty field. 4. Run mode 7 and open the same help.
Expected: the Order Report branch (`RP_ALL.cs:9687 {{if (Operators.CompareString(CurRpt, "Order Report", false) == 0)}}`)
looks the name up in the orders: a found name is copied back exactly as stored
(`RP_ALL.cs:9689 {{SELECT A.AC_NAME FROM SL_ORD_DATA AS A  WHERE A.CO_CODE}}`) and focus moves to City
(`RP_ALL.cs:9712 {{((Control)cboCity).Focus();}}`); an unknown name opens the help of distinct order names
(`RP_ALL.cs:9693 {{SELECT A.AC_NAME As CustomerNameL,A.AC_CODE AS AcCodel FROM SL_ORD_DATA AS A WHERE A.CO_CODE}}`),
picking writes the name and focus returns to Cust Name; canceling leaves the text; empty + Enter goes to City
(`RP_ALL.cs:9723 {{((Control)cboCity).Focus();}}`). In mode 7 the help still lists `SL_ORD_DATA` names (D9) even
though the button filters `SL_DATA.AC_NAME` — the inherited mismatch is kept. The typed name is never cleared
(the clear at `RP_ALL.cs:9717 {{tCustName.Text = "";}}` runs only in other captions). Fails today: gap 13.
Status: executable

### order-report.grouping.template-groups   (T05 Children)
Layer: browser
Steps: 1. Seed O1's two lines in reverse insertion order (line 2 first). 2. Run each of the seven modes with
the default range and record group bands, row order and which level each row belongs to.
Expected (template definitions, D5): mode 1 groups `SL_ORD_DATA.VCH_NO` ascending, record sort `AC_CODE`
ascending (`extraction_output/rpt_xml/OrdDetlRpt.xml:288-291`); mode 2 groups `AC_NAME` ascending, record sort
`AC_CODE` (`extraction_output/rpt_xml/OrdAdvRpt.xml:246-249`); mode 3 groups `@OrdGroup` ascending, record sort
`CO_YEAR`, `VCH_DATE`, `VCH_NO` (`extraction_output/rpt_xml/OrdAdvAdj.xml:233-238`); mode 4 groups `AC_NAME`
then `VCH_NO`, record sort `AC_CODE` (`extraction_output/rpt_xml/OrdAdjBillWise.xml:384-388`); modes 5 and 6
group `@VchGroup` ascending, record sort `AC_CODE` (`extraction_output/rpt_xml/OrdDetlPanding.xml:375-378`,
`extraction_output/rpt_xml/OrdDesignSumm.xml:375-378`) where mode 5's `@VchGroup = CO_YEAR&CO_BOOK&VCH_NO`
(`extraction_output/rpt_xml/OrdDetlPanding.xml:393-394`) and mode 6's `@VchGroup = TAG_NO&DESIGN_NO`
(`extraction_output/rpt_xml/OrdDesignSumm.xml:395-396`) — so mode 6 groups by tag+design, not by voucher;
mode 7 groups `SL_DATA.AC_CODE` then `@VchGroup = CO_CODE+LC_CODE+CO_YEAR+CO_BOOK+VCH_NO` of the bill
(`extraction_output/rpt_xml/BillWiseOrderAdjust.xml:365-366`, `:388-389`). O1's lines print in group order
regardless of insertion order; header values (customer, advance) repeat on each line row but every total counts
each line once; no row of one order appears under another order's group. Mode 6 detail shows the design fallback
`@Design = if DESIGN_NO='' then TAG_NO else DESIGN_NO` (`extraction_output/rpt_xml/OrdDetlPanding.xml:384-388`,
same formula in OrdDesignSumm). Fails today: gaps 2–8.
Status: executable

### order-report.invalid.dates   (T06 Required/invalid)
Layer: browser
Steps: 1. Type `31/02/2026` in From and press Enter. 2. Leave the mask incomplete (`__/__/____`) and click
Order Report. 3. Set From `01/02/2026`, To `01/01/2026` and run mode 1.
Expected: steps 1–2 are refused with a clear date message and no run (web-added guard, D10; the desktop only
has the mask and `DC_Main.cs:1561 {{public static void SetDate(ref MaskedTextBox MsDate)}}`, which flags a bad
entry, and an incomplete mask would crash `Conversions.ToDate` — not ported). Step 3 runs and prints an empty
report with zero totals and no error: the filter is a plain range
(`RP_ALL.cs:8380 {{CurFormula = "{SL_ORD_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {}}`) and no handler
compares From with To (study Rules). No message box exists in the desktop Order branch for this; the web's
refusal text is its own, the empty-range result is the desktop's. Fails today: gap 9.
Status: executable

### order-report.invalid.unknown-codes-no-recheck   (T06 Required/invalid)
Layer: browser
Steps: 1. Type unknown party code `ZZ99` in Party Code and click Order Report **without** pressing Enter.
2. Repeat with unknown book `ZZ`. 3. Check the database for writes.
Expected: no existence re-check happens on the button click; the typed text goes straight into the filter
(`RP_ALL.cs:8391 {{CurFormula = CurFormula + " And {SL_ORD_DATA.AC_CODE} = '" + tAcCode.Text + "'";}}`), so both
runs print an empty report with no message (study Rules: existence is checked only on Enter). Nothing is
written. The web uses bound parameters, never string-built SQL (study weakness 1); a quote typed into any field
is swallowed as on the desktop (`RP_ALL.cs:7251 {{if (num == 0 || num == 39)}}`). Fails today: gaps 2, 9.
Status: executable

### order-report.lifecycle.source-order-appears   (T07 Create)
Layer: browser
Steps: 1. Create an order through the Sales Order screen: party P1, book B1, two lines (pcs 1 nwt 10.500 and
pcs 2 nwt 5.250), cash advance 5000, total 20000. 2. Run modes 1 and 2. 3. Edit the second line's net weight to
6.000 through the Sales Order screen and re-run mode 1. 4. Delete the order through its screen and re-run.
Expected: the report creates nothing itself; it follows the source document. After step 2 mode 1 lists the two
new lines and mode 2 shows one row with `ADV_AMT` 5000 and `TOT_AMT` 20000; the cash advance also wrote a `+`
adjustment row of 5000 (`TR_SALE_ORD.cs:9503 {{dataRow7["ORD_SIGN"] = "+";}}`, amount
`TR_SALE_ORD.cs:9504 {{dataRow7["ORD_AMT"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(Conversion.Val(MSG2_TOTAL[9, 1]) == 0.0}}`
— the cash advance when there is no tender split), so mode 3 shows `+` 5000 and mode 5 lists the order as
pending. After step 3 mode 1's grand net weight rises by 0.750 (5.250 → 6.000). After step 4 the order's rows
are gone from every mode. Fails today: gaps 2, 3.
Status: executable

### order-report.lifecycle.writes-nothing   (T07 Create)
Layer: database
Steps: 1. Snapshot every `SL_ORD_DETL.DESIGN_ISU` value and the row counts of SL_ORD_DATA, SL_ORD_DETL,
SL_ORD_ADJ, SL_DATA. 2. Run all seven modes, including Making Panding and Making Summ (answer Yes once), twice
each, with fully adjusted order O3 present. 3. Snapshot again and compare.
Expected: the complete footprint of every run is **zero writes**: all `DESIGN_ISU` values and all row counts are
byte-identical, including O3's lines which the desktop would flag
(`RP_ALL.cs:10933 {{UPDATE SL_ORD_DETL SET DESIGN_ISU = 'Y' WHERE CO_CODE = '}}`,
`RP_ALL.cs:10934 {{DC_Main.ExeQuteDc(DC_Main.RsQry);}}`; same in Making Summ at `RP_ALL.cs:11843 {{DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Opera}}`).
The second run returns the same rows as the first (a read-only report is idempotent; the desktop's second run
would show fewer lines because the first flagged them). The dead `SELECT TOP(5)` read
(`RP_ALL.cs:10937 {{SELECT TOP(5) * FROM SL_ORD_DATA WHERE CO_CODE = '}}`) is not ported. Fails today: gaps 6, 7
(the modes do not exist); once built, this case guards the read-only decision D2.
Status: executable

### order-report.scope.sentinels   (T11 Scope/rights)
Layer: database
Steps: 1. As the location-`01` user of company C1, run all seven modes with the default range and with the
widest range (From `01/01/2010`). 2. Inspect grid, totals, CSV and XLSX for the sentinel rows O6 (location `00`)
and O7 (company C2, same book and number as O1). 3. Call the report API directly with another company's scope
and with a reused order id from C2.
Expected: O6 and O7 never appear in any mode, total or export. Modes 1–6 filter
`SL_ORD_DATA.CO_CODE = C1` (`RP_ALL.cs:8380 {{CurFormula = "{SL_ORD_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {}}`)
and `LC_CODE = '01'` (`RP_ALL.cs:8383 {{CurFormula = CurFormula + " And {SL_ORD_DATA.LC_CODE} = '" + tLcCode.Text + "'";}}`);
mode 7 filters `SL_DATA.CO_CODE`/`LC_CODE` (`RP_ALL.cs:12608 {{CurFormula = "{SL_DATA.CO_CODE} = '}}`,
`RP_ALL.cs:12611 {{CurFormula = CurFormula + " And {SL_DATA.LC_CODE} = '" + tLcCode.Text + "'";}}`). The server
rejects the cross-scope API call; no sentinel value leaks through an export. Fails today: gaps 1, 10.
Status: executable

### order-report.rights.caption-and-print   (T11 Scope/rights)
Layer: browser
Steps: 1. As a user with the Sales Order right but **no** Order Report right, open the menu and call the report
API. 2. As a user with the Order Report right but `FRM_PRINT = 'N'`, run mode 1 and request CSV/XLSX/print.
3. As a user with the Order Report right and `FRM_PRINT = 'Y'`, repeat.
Expected: rights key on the caption's own USER_SET row, "Order Report"
(`MDI_FORM.cs:7034 {{DC_Main.MsUserRightForm = MsSideBtn;}}`, `RP_ALL.cs:6656 {{Select * From USER_SET WHERE LC_CODE = '}}`;
decision D6, G225): step 1 is refused (menu hidden or 403 from the API) even though the Sales Order right
exists; step 2 runs and lists (the desktop never checks print rights —
`RP_ALL.cs:6777 {{UserPrint = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["FRM_PRINT"], (object)""));}}`
is loaded and never compared, `RP_ALL.cs:6775 {{UserEdit = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["FRM_EDIT"], (object)""));}}`
likewise — but the web enforces the print right on export/print exactly as the Sales Report does, D7);
step 3 exports succeed. Fails today: gaps 10, 11.
Status: executable

### order-report.history.snapshot-and-live   (T15 Config/history)
Layer: browser
Steps: 1. Run modes 1 and 7 with the default range. 2. Rename party P1 in the party master to `ALPHA RENAMED`
and change its city to `BARODA`. 3. Re-run modes 1 and 7, then run mode 1 with Cust Name `ALPHA JEWELS` and with
City `SURAT`.
Expected: modes 1–6 print the **stored order name** `SL_ORD_DATA.AC_NAME`
(`extraction_output/rpt_xml/OrdDetlRpt.xml:696`, same field in OrdAdvRpt.xml:508, OrdAdvAdj.xml:467,
OrdAdjBillWise.xml:625, OrdDetlPanding.xml:660, OrdDesignSumm.xml:759), so after the rename they still print
`ALPHA JEWELS`; mode 7 prints the bill's stored `SL_DATA.AC_NAME` for the sale party and the **live**
`AC_MAST.AC_NAME` for the adjusted order's party (`extraction_output/rpt_xml/BillWiseOrderAdjust.xml:603`,
`:751`), so its order-party column shows `ALPHA RENAMED`. The Cust Name filter matches the stored name
(`RP_ALL.cs:8403 {{CurFormula = CurFormula + " And {SL_ORD_DATA.AC_NAME} = '" + tCustName.Text + "'";}}`):
`ALPHA JEWELS` still selects O1/O3, `ALPHA RENAMED` selects nothing. The City filter reads live master data
(`RP_ALL.cs:8395 {{CurFormula = CurFormula + " And {AC_MAST.AC_CITY} = '" + cboCity.Text + "'";}}`): after the
move, City `SURAT` no longer selects O1/O3 and City `BARODA` does. No hidden global default changes between
runs. Fails today: gaps 2, 8, 9.
Status: executable

### order-report.filters.data-type-omitted   (T15 Config/history)
Layer: browser
Steps: 1. With the default range, run mode 1 (books B1 of DATA_TYPE `A` and B2 of DATA_TYPE `B` both carry
orders). 2. Check the request for any data-type parameter.
Expected: both O1 (book B1) and O2 (book B2) list. The desktop would append `BOOK_DATA.DATA_TYPE = 'A'` or
`'B'` only when the session value is A or B (`RP_ALL.cs:8405 {{if (Operators.CompareString(DC_Main.MsDataType, "A", false) == 0)}}`,
`RP_ALL.cs:8409 {{else if (Operators.CompareString(DC_Main.MsDataType, "B", false) == 0)}}`); the web session
has no such value and the clause is omitted, exactly as in the Sales adapter (D4,
`docs/parity/rpall-sales-inventory.md:178-180`). If the owner later ports a session data type, this case's
expectation changes with that decision. Fails today: gap 9.
Status: executable

### order-report.output.titles   (T16 Report/output)
Layer: browser
Steps: 1. Run each of the seven modes with From `01/01/2026`, To `31/01/2026`. 2. Read the title line of each
output (grid header and print/PDF).
Expected: the titles are the desktop's fixed strings with `dd/MM/yyyy` dates (the formula uses `MM/dd/yyyy`,
the title `dd/MM/yyyy` — study Calculations): mode 1 "Order Report From 01/01/2026 To 31/01/2026"
(`RP_ALL.cs:8416 {{DC_Main.MsRptTitelStr = "'Order Report From "}}`); mode 2 "Order Advance Report From
01/01/2026 To 31/01/2026" (`RP_ALL.cs:8482 {{DC_Main.MsRptTitelStr = "'Order Advance Report From "}}`); mode 3
"Order Adjust Report From 01/01/2026 To 31/01/2026" (`RP_ALL.cs:8548 {{DC_Main.MsRptTitelStr = "'Order Adjust Report From "}}`);
modes 4 **and** 7 both "Bill Wise Order Adjust Report From 01/01/2026 To 31/01/2026"
(`RP_ALL.cs:9774 {{DC_Main.MsRptTitelStr = "'Bill Wise Order Adjust Report From "}}`,
`RP_ALL.cs:12644 {{DC_Main.MsRptTitelStr = "'Bill Wise Order Adjust Report From "}}`); modes 5 **and** 6 both
"Order Design Issue Panding Report From 01/01/2026 To 31/01/2026"
(`RP_ALL.cs:10976 {{DC_Main.MsRptTitelStr = "'Order Design Issue Panding Report From "}}`,
`RP_ALL.cs:11887 {{DC_Main.MsRptTitelStr = "'Order Design Issue Panding Report From "}}`). The typos
"Panding" and (in the prompt) "Summery" are kept verbatim. Fails today: gap 12.
Status: executable

### order-report.output.grid-export-print-match   (T16 Report/output)
Layer: browser
Steps: 1. Seed enough orders to overflow one printed page (repeat O1's pattern under 30 distinct voucher
numbers). 2. Run every mode; export CSV and XLSX; open the print preview. 3. Compare rows, column order,
captions and totals across grid, CSV, XLSX and print.
Expected: all four surfaces show the same dataset in the template's column order and captions (study Lifecycle
per mode; the seven specs `web/apps/api/report-specs/OrdDetlRpt.spec.json` etc. carry the field lists), with the
totals computed in the T03 cases: mode 1 grand pcs/nwt; mode 2 **no** grand band; mode 3 group and grand
OrdAmt/OrdAdjAmt/BalAmt bands; mode 4 one total per order; modes 5/6 grand pcs/nwt (mode 6 also per tag+design
group, `extraction_output/rpt_xml/OrdDesignSumm.xml:405-408`); mode 7 **no** total band (D13). Exports come from
the same shared result as the grid (study gap 15, the Sales `exportRows.ts` pattern). The preview path applies
the selection formula exactly once (`Module_Save.cs:110 {{val.RecordSelectionFormula = DC_Main.RptFormula;}}`
is the desktop analogue; `RP_ALL.cs:8413 {{if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)}}`
chooses the preview path, `RP_ALL.cs:8417 {{DC_Main.MsWappPrintType = "All";}}` — no page-range subset).
Fails today: gaps 2–8, 15.
Status: executable

### order-report.output.making-summ-prompt   (T16 Report/output)
Layer: browser
Steps: 1. Click Making Summ. 2. Read the prompt, answer Yes, read the output. 3. Run again, answer No, read the
output. 4. Compare totals and focus.
Expected: before the report runs, a Yes/No prompt with the exact text "Only Design Summery Report.."
(`RP_ALL.cs:11889 {{Only Design Summery Report..}}`, same text on the legacy path
`RP_ALL.cs:11906 {{Only Design Summery Report..}}`), title "DataCareNext"
(`DC_Main.cs:851 {{public static string MsgTitle = "DataCareNext";}}`). Yes passes `OnlySumm = 'Y'`
(`RP_ALL.cs:11892 {{DC_Main.MsCrForStr1 = "'Y'";}}`), No passes `'N'`
(`RP_ALL.cs:11897 {{DC_Main.MsCrForStr1 = "'N'";}}`). With Yes the detail band is suppressed — the template's
detail section carries `EnableSuppress="{@OnlySumm} = "Y""`
(`extraction_output/rpt_xml/OrdDesignSumm.xml:685`) — so only group headers and totals print; with No the detail
lines print. Suppression never changes a total: the per-group and grand pcs/nwt sums are identical for Yes and
No (the pending-set arithmetic of `order-report.formula.pending-set`, grouped by tag+design). Focus is unchanged
by the prompt (study Rules). The prompt is the only message box in the whole Order branch. Fails today: gaps 7, 12.
Status: executable

### order-report.keyboard.selector-run-flow   (T17 Keyboard/usability)
Layer: browser
Steps: 1. Complete a full run using only the keyboard at the supported viewports: type From, Enter; To, Enter;
walk lc, Book, Pr, Gr, Party, Cust Name, City, Area, Item Type with Enter; activate Order Report; Esc. 2. Type
lower-case letters and a `'` into Party Code. 3. Click Cancel (or its hot key) after setting City and dates;
inspect every field. 4. Click Print; click Exit.
Expected: Enter on a date runs the date accept and tabs on (`RP_ALL.cs:7517 {{DC_Main.SetDate(ref MsDate);}}`,
`RP_ALL.cs:7521 {{SendKeys.Send("{tab}");}}`); the selector walk follows the tab order From 0, To 1, lc 2,
Book 3, Pr 4, Gr 5, Party 6, Cust Name 7, City 8, Area 9, Item Type 10
(`RP_ALL.cs:5622 {{((Control)mFromDt).TabIndex = 0;}}`, `RP_ALL.cs:4816 {{((Control)tAcCode).TabIndex = 6;}}`,
`RP_ALL.cs:4902 {{((Control)cboItemTyp).TabIndex = 10;}}`); empty Pr Code + Enter jumps to City
(`RP_ALL.cs:7506 {{((Control)cboCity).Focus();}}`); City/Area + Enter tab on
(`RP_ALL.cs:7548 {{SendKeys.Send("{tab}");}}`). Every typed character is upper-cased and `'` is swallowed
(`RP_ALL.cs:7251 {{if (num == 0 || num == 39)}}`). Esc closes the form from anywhere
(`RP_ALL.cs:7261 {{if ((int)e.KeyCode == 27)}}`, `RP_ALL.cs:7263 {{((Form)this).Close();}}`); no F-key or Ctrl
combination is handled (`RP_ALL.cs:7257-7266 {{private void RP_ALL_KeyDown(object sender, KeyEventArgs e)}}`).
Cancel clears every text box and resets the masks (`RP_ALL.cs:7273 {{CLEAR_DATA();}}`,
`RP_ALL.cs:7221 {{val.Text = DC_Main.MMask;}}`) but keeps City/Area/Item Type selections and does **not** restore
the default dates (study Keyboard). The form-level Print button does nothing
(`RP_ALL.cs:7267-7269 {{private void BtnPrint_Click(object sender, EventArgs e)}}`, empty body); each panel
button prints for itself; Exit closes (`RP_ALL.cs:7230 {{((Form)this).Close();}}`). Button captions carry the
desktop hot-key marks verbatim (four buttons share `&O`; Making Summ's `& ` gives no hot key; Bill Wise Adjust
has none — study Keyboard); the web must not invent new accelerators. Fails today: gaps 1, 9.
Status: executable

### order-report.journey.order-adjust-reconcile   (T18 Full journey)
Layer: browser
Steps: 1. Through the Sales Order screen create order J1: party P1, book B1, one line pcs 2 nwt 15.000, cash
advance 5000, total 12000. 2. Run modes 1, 2, 3, 5 and record rows and totals. 3. Apply a bill adjustment of
3000 against J1 (a `-` SL_ORD_ADJ row of 3000 referencing J1, as a sale bill against the order writes; the bill
S3 has total 8000), then re-run modes 3, 4, 5, 7. 4. Apply a second `-` adjustment of 2000 so J1 nets to zero,
re-run modes 1, 2, 5, 6. 5. Query the database for J1's stored flags.
Expected: step 2 — mode 1 lists J1's line (grand band includes pcs 2, nwt 15.000); mode 2 shows ADV_AMT 5000,
TOT_AMT 12000; mode 3 shows the `+` 5000 advance row the order screen wrote
(`TR_SALE_ORD.cs:9503 {{dataRow7["ORD_SIGN"] = "+";}}`), group BalAmt 5000; mode 5 lists J1 (net +5000 ≠ 0).
Step 3 — mode 3 group J1: OrdAmt 5000, OrdAdjAmt 3000, BalAmt 2000; mode 4 prints bill S3 (total 8000) with the
`-` 3000 row and a per-order total of 3000 (`@AdjAmt` counts `-` rows only,
`extraction_output/rpt_xml/OrdAdjBillWise.xml:399-401`); mode 5 still lists J1 (net +2000); mode 7 prints S3's
row with raw amount 3000. Step 4 — J1 nets +5000−3000−2000 = 0
(`RP_ALL.cs:10927 {{HAVING SUM(CASE WHEN B.ORD_SIGN = '+' THEN B.ORD_AMT ELSE - B.ORD_AMT END)  = 0}}`): modes 5
and 6 drop J1's line, modes 1 and 2 **still list it** (no status filter, D3); mode 3 BalAmt is 0. Step 5 —
J1's `DESIGN_ISU` is still `N` in the database (the web never writes, D2; the desktop would have set `Y` via
`RP_ALL.cs:10933 {{UPDATE SL_ORD_DETL SET DESIGN_ISU = 'Y' WHERE CO_CODE = '}}`). Every report total reconciles
to the hand sums of the created documents at every stage. Fails today: gaps 1–8.
Status: executable

## Coverage table

| Kind | Cases | Blocked | Note |
|---|---|---|---|
| T01 Entry/defaults | 3 | 0 | menu-route, defaults-and-seven-buttons, location-lock |
| T02 Field route | 3 | 0 | one-at-a-time, date-range-no-year, combined-city-area-walkin |
| T03 Formula sequence | 6 | 0 | order-adjust-signs, pcs-nwt-totals, order-advance-tender, order-wise-bill-total, pending-set, bill-wise-adjust |
| T04 Lookup | 2 | 0 | book-party-location, cust-name |
| T05 Children | 1 | 0 | grouping.template-groups (report analogue: order→lines, order→adjustments, bill→adjustments) |
| T06 Required/invalid | 2 | 0 | invalid.dates, invalid.unknown-codes-no-recheck |
| T07 Create | 2 | 0 | lifecycle.source-order-appears, lifecycle.writes-nothing (footprint = zero writes) |
| T08 Reopen/no-op | 0 | 0 | N/A: the report saves no document; closing and reopening the screen re-applies the constructor defaults, which T01 proves; there are no raw values, clocks or images of its own to preserve |
| T09 Edit | 0 | 0 | N/A: the report owns no editable field; editing the source order and re-running is covered by lifecycle.source-order-appears (T07) |
| T10 Delete/cancel/reverse | 0 | 0 | N/A: the report deletes and reverses nothing; deleting the source order is covered in T07; the Order Cancel flow is G245, outside this study (D3) |
| T11 Scope/rights | 2 | 0 | scope.sentinels, rights.caption-and-print |
| T12 Concurrency | 0 | 0 | N/A: the web report is read-only (D2) — no save, delete or number allocation to race; the desktop's unscoped concurrent write is the weakness not ported, and lifecycle.writes-nothing proves no write occurs |
| T13 Retry/unknown | 0 | 0 | N/A: a report run is a read; a duplicate or retried request returns the same dataset with no financial effect — asserted inside lifecycle.writes-nothing (second run identical) |
| T14 Rollback | 0 | 0 | N/A: there is no write to roll back (D2); a failed run leaves the database untouched, which lifecycle.writes-nothing verifies |
| T15 Config/history | 2 | 0 | history.snapshot-and-live, filters.data-type-omitted |
| T16 Report/output | 3 | 0 | output.titles, output.grid-export-print-match, output.making-summ-prompt |
| T17 Keyboard/usability | 1 | 0 | keyboard.selector-run-flow |
| T18 Full journey | 1 | 0 | journey.order-adjust-reconcile |
| **Total** | **28** | **0** | six kinds N/A with reasons above |

Gap coverage: gap 1 → entry.menu-route, scope.sentinels, keyboard; gap 2 → filters.date-range-no-year,
formula.pcs-nwt-totals, grouping; gap 3 → formula.order-advance-tender, lifecycle.source-order-appears; gap 4 →
formula.order-adjust-signs; gap 5 → formula.order-wise-bill-total; gap 6 → formula.pending-set,
lifecycle.writes-nothing; gap 7 → formula.pending-set, output.making-summ-prompt, lifecycle.writes-nothing;
gap 8 → formula.bill-wise-adjust, history.snapshot-and-live; gap 9 → entry.defaults-and-seven-buttons,
entry.location-lock, filters.one-at-a-time, invalid.dates, lookup.book-party-location, filters.data-type-omitted;
gap 10 → rights.caption-and-print, scope.sentinels; gap 11 → rights.caption-and-print; gap 12 → output.titles,
output.making-summ-prompt; gap 13 → lookup.cust-name; gap 14 → entry.menu-route (and D12); gap 15 →
output.grid-export-print-match. Every gap has at least one case that fails today because of it.

## Test data

Smallest seed that satisfies every case (described, not SQL; all in the isolated test database). Masters and
sentinels are seeded directly; the journey and lifecycle cases create their orders through the real Sales Order
screen. Amounts are plain numbers; weights carry three decimals.

- **Company/session:** company C1 (the session company), financial year 2026; a second company C2 for the
  sentinel. Locations `00` (head office) and `01`. Users: an admin at location `01` with the Order Report right
  and `FRM_PRINT = 'Y'`; a `00` user with the same rights; a user with the Sales Order right but no Order Report
  right; a user with the Order Report right and `FRM_PRINT = 'N'`.
- **Books:** order book `B1` (DATA_TYPE `A`) and order book `B2` (DATA_TYPE `B`) at location `01`; sale book
  `SB`; one book at location `00`. All books of the location exist in BOOK_DATA so the book help lists them.
- **Parties (AC_MAST):** `P1` name `ALPHA JEWELS`, city `SURAT`, area `ADAJAN`; `P2` name `BETA TRADERS`, city
  `BARODA`, area `ALKAPURI`. The rename variant of the history case changes P1 to `ALPHA RENAMED`, city
  `BARODA`. Locations exist in LOCT_MAST for the location help.
- **Items:** `I1`, `I2` in ITEM_MAST (names printed on the line rows); group `G1` exists only to prove the
  Gr Code selector is inert.
- **Orders (SL_ORD_DATA + SL_ORD_DETL, company C1, location 01, year 2026 unless stated):**
  - `O1`: book B1, party P1, date 05/01/2026, TOT_AMT 20000, ADV_AMT 5000, CASH_AMT 5000, other tenders 0;
    line 1 pcs 1 nwt 10.500 (item I1, design D1, tag T1), line 2 pcs 2 nwt 5.250 (item I2, design D2, tag T2);
    all lines DESIGN_ISU `N`. Adjustment rows: `+` 5000 (the advance, own keys = O1), `-` 1500 and `-` 500
    (own keys = bill S1).
  - `O2`: book B2, party P2, date 10/01/2026, TOT_AMT 9000, ADV_AMT 0, no tender; one line pcs 3 nwt 7.125;
    **no** SL_ORD_ADJ row (the NULL-sum pending case).
  - `O3`: book B1, party P1, date 15/01/2026, TOT_AMT 9000, ADV_AMT 3000; one line pcs 1 nwt 4.000, tag T3,
    design D3, DESIGN_ISU `N`. Adjustments: `+` 3000 (advance), `-` 1500 and `-` 1500 (own keys = bill S2) →
    nets to zero (fully adjusted).
  - `O4`: walk-in, AC_CODE empty, stored AC_NAME `WALK IN CUSTOMER` (no AC_MAST row), book B1, date 12/01/2026,
    one line pcs 1 nwt 2.000, no adjustments.
  - `O5`: year **2025**, book B1, party P1, date 20/12/2025, one line pcs 2 nwt 6.000; adjustments `+` 1000 and
    `-` 1000 dated 2025 → fully adjusted outside the 2026 range (the unscoped-set case).
  - `O6`: location `00`, book B1, party P1, date 08/01/2026, one line pcs 1 nwt 1.000 (location sentinel).
  - `O7`: company **C2**, same book/number/date as O1 (company sentinel; never visible).
  - `O8`: book B1, party P2, date 20/01/2026, one line pcs 1 nwt 3.000 with TAG_STK_LESS `Y` and stored
    DESIGN_ISU `Y` (as the stock-less save writes, `TR_SALE_ORD.cs:9276 {{dataRow3["DESIGN_ISU"] = "Y";}}`); no adjustments.
- **Bills (SL_DATA, location 01, year 2026, book SB):** `S1` party P1, date 18/01/2026, VCH_NO distinct,
  TOT_AMT 12000, ADV_AMT 0 — carries O1's two `-` rows; `S2` party P1, date 22/01/2026, TOT_AMT 9000 — carries
  O3's two `-` rows. The journey adds `S3` (TOT_AMT 8000) with `-` 3000 and later `-` 2000 against J1.
- **Page-overflow variant (output case):** 30 copies of O1's pattern under distinct voucher numbers, same
  party/book, so every mode exceeds one printed page.
- **Journey/lifecycle orders:** J1 and the lifecycle order are created through the Sales Order screen during the
  case (advance 5000 cash produces the `+` adjustment row automatically); their `-` adjustment rows are seeded
  as described above because the bill-against-order writer belongs to the Sales Invoice menu, not to WP-14.

## Not covered

- **The desktop's `DESIGN_ISU` write and its downstream effect on other menus** (study weakness 2/3, open
  question 2 tail): a desktop Making Panding run flags fully adjusted orders, which changes what the
  karigar-issue and order-track screens list afterwards. The web report is read-only by D2, so no case asserts
  the write; persisting the flag would be a separate rights-checked action outside this work package.
  `order-report.lifecycle.writes-nothing` asserts the opposite (no write) on purpose.
- **Order Cancel semantics** (study open question 3, G245): which adjustments a cancellation writes and how a
  refund is signed belong to the Order Cancel screen's own case list; here a cancelled order is only asserted
  to remain listed (D3), using seeded adjustment rows.
- **The Crystal rendering engine and the legacy ActiveX print path** (`RP_ALL.cs:8425 {{Cr.SelectionFormula = CurFormula;}}`,
  `RP_ALL.cs:8430 {{Cr.Action = -1;}}`): out of scope per the study; the web has one preview path, covered by
  output.grid-export-print-match.
- **The dead `SELECT TOP(5)` query** (`RP_ALL.cs:10937 {{SELECT TOP(5) * FROM SL_ORD_DATA WHERE CO_CODE = '}}`):
  reads five rows and uses nothing (study weakness 4); not ported, no behaviour to prove.
- **The Sales book-selection messages** "Book Selection Not Done..." / "Book Selection is Ok..."
  (`RP_ALL.cs:11392 {{Interaction.MsgBox((object)"Book Selection Not Done...", (MsgBoxStyle)}}`,
  `RP_ALL.cs:11398 {{Interaction.MsgBox((object)"Book Selection is Ok...", (MsgBoxStyle)0, }}`): unreachable in
  this caption because `chkBookSelect` is hidden (study Rules); no case.
- **The `BtnOk_Click` book list, the Sales/Purchase/Approval panels and `btnSlWithOrder`**: other captions of
  the shared form, out of scope per the study.
- **Exact Alt+O resolution among the four buttons sharing `&O`**: the desktop captions are reproduced verbatim
  (keyboard case), but which button WinForms activates on a shared mnemonic is an OS behaviour the study did
  not settle; the web asserts the captions and the panel-button click/Enter activation, not a guessed mnemonic
  winner.
- **Physical printer device output**: the print preview layout is covered by the visual protocol in
  output.grid-export-print-match; a paper print on a physical device is not available in this environment.
