# WP-33 cases: Master → Daily Rate residuals — frozen T01–T18 case list

This is the frozen case list for WP-33, derived from `orchestration/work/WP-33/study.md` and the eighteen case
kinds in `docs/master-parity-plan-2026-09-29/04-verification-playbook.md` §3. It covers three residuals: a real,
authorized location-00 browser session; the conditional per-location copy; and the main-window group rate labels.
It changes no code. Case ids from `web/apps/web/test/features/modules/dailyRate.mjs` are reused where the behaviour
is the same; those ids are marked `[reuse]`.

Every `Expected` value is the desktop rule with its citation copied verbatim from the study. The study's 342
citations were checked against `unified/src/csharp/DataCareNext/` before this list was written; every quote below
is one of those verified quotes.

## Decisions on the study's open questions

The owner's standing rule is "the desktop first; the web adds only what a hosted multi-user service needs to be
safe and correct". Each open question is decided below. Each decision is recorded exactly as
**architect, 2026-11-23, owner may override**. A case whose expected value still cannot be settled by source or by
one of these decisions is written as `blocked` with the exact question.

1. **Hosted equivalent of the registration-gated copy eligibility.** Decision: keep the desktop behaviour (copy
   only from a location-00 source, enumerating non-00 company locations) but replace the hardcoded serial-number
   gate with an explicit, authorized per-company configuration flag controlled by an operator with company scope.
   No fan-out for other 00 sessions by default; no hidden customer backdoor. This is the hosted-safe form of
   `MS_RATE.cs:1937 {{if (Operators.CompareString(DC_Main.SSRegSrNo, "VK142NEVK", false) == 0 && Operators.CompareString(DC_Main.MLc_code, "00", false) == 0)}}`.
   **architect, 2026-11-23, owner may override**. Cases: `daily-rate.copy.gate-false-no-fanout`,
   `daily-rate.settings.copy-eligibility-setting`, `daily-rate.scope.copy-authorized-company-only`.
2. **Copy-side date collisions across CO_YEAR.** Decision: the copy replacement key is company + location + full
   VCH_DATE + the source CO_YEAR; a destination row carrying a different CO_YEAR is neither deleted nor
   overwritten. This keeps all tenant/company/location bounds and avoids silently broadening the delete. The
   desktop reads company/location/date and copies CO_YEAR as data
   (`MS_RATE.cs:1945 {{',CO_YEAR,VCH_DATE,SR_NO,GR_CODE,FINE_GL_RATE,FINE_SL_RATE, }}`), which is not safe on its own.
   **architect, 2026-11-23, owner may override**. Case: `daily-rate.copy.cross-year-collision`.
3. **Web placement of the main-window labels and stale-label treatment.** Decision: mount the scoped
   current-system-date display projection on the web main-window equivalent, show only the first seven
   RATE_DISPLAY=Y groups in SR_NO order with exact name + `"  -  "` + GR_RATE `"0.00"`, show `"ToDays Rate :"` in
   the first slot when empty, and clear every surplus/obsolete slot on each refresh so no stale label remains.
   This replaces the desktop's one-sided visibility weakness. Source establishes the labels and one-sided changes
   (`MDI_FORM.cs:6920 {{Rate_1.Text = "Ac Group";}}`, `MS_RATE.cs:1967 {{((Control)MyProject.Forms.MDI_FORM.Rate_2).Visible = true;}}`)
   but not a web design. **architect, 2026-11-23, owner may override**. Cases: `daily-rate.labels.*`.
4. **MISSING `orchestration/bin/orch.mjs`.** Not a behaviour decision: the required checker is absent from this
   worktree. Evidence uses an equivalent literal citation audit (parse every `File.cs:N {{text}}` and compare to
   the cited source lines). No case blocked by this; it is a verification-tooling gap recorded in the report.
5. **MISSING `.orch/index/DC_Main.md`.** Not needed for these residuals: all residual code is located in the
   supplied MS_RATE/MDI_FORM indexes. The one behaviour it would settle — full shared date validation — is
   explicitly outside WP-33 and is the subject of one blocked case (`daily-rate.lookup.invalid-date-validation`).

---

## T01 Entry/defaults

### daily-rate.entry.rate-master-grid (T01 Entry/defaults) [reuse]
Layer: browser
Steps: 1. Open Other → Daily Rate through the menu. 2. Read the title, Vch Date, mask and grid column order. 3. Read the three rate groups' touch values.
Expected: The caption is `MS_RATE.cs:1043 {{lblBook.Text = "Rate Master";}}`. The grid lists groups with nonzero touch ordered GR_TYPE then GR_NAME (`MS_RATE.cs:1781 {{AND GR_TOUCH <> 0 ORDER BY GR_TYPE,GR_NAME}}`), so groups R18, R22, RSV appear in that order with `Touch R22` = 91.6; Vch Date has mask `MS_RATE.cs:1182 {{mVchDate.Mask = "00/00/0000";}}` and tab 0 `MS_RATE.cs:1185 {{((Control)mVchDate).TabIndex = 0;}}`.
Status: executable

### daily-rate.entry.location-00-session (T01 Entry/defaults)
Layer: browser
Steps: 1. Using a distinct login cache slot, sign in as a user scoped to an authorized location-00 session (Gap 1). 2. Assert the established session location is `00` before opening the screen. 3. Open the screen and confirm location-derived defaults.
Expected: Location comes from the session, not the request body: `MS_RATE.cs:1907 {{dataRow["LC_CODE"] = DC_Main.MLc_code;}}`. On CLEAR_DATA inputs are blank (`MS_RATE.cs:1737 {{val.Text = "";}}`), Vch Date is `MS_RATE.cs:1741 {{mVchDate.Text = Conversions.ToString(DC_Main.MsSysDate);}}` and focus is date `MS_RATE.cs:1749 {{((Control)mVchDate).Focus();}}`. Changing a POST body is not equivalent to this session state.
Status: executable

### daily-rate.entry.mdi-labels-initial (T01 Entry/defaults)
Layer: browser
Steps: 1. Seed today's RATE_MAST with RATE_DISPLAY=Y groups. 2. Open the main window. 3. Read Rate_1..Rate_7.
Expected: Main-window load runs the same scoped query `MDI_FORM.cs:11416 {{AND B.RATE_DISPLAY = 'Y' ORDER BY A.SR_NO}}`; labels start hidden with placeholder `MDI_FORM.cs:6920 {{Rate_1.Text = "Ac Group";}}` and `MDI_FORM.cs:6922 {{((Control)Rate_1).Visible = false;}}`. Populated labels read `MDI_FORM.cs:11429 {{["GR_NAME"}}, (object)"  -  "), (object)Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["GR_RATE"]), "0.00")].`
Status: executable

## T02 Field route

### daily-rate.branches.not-applicable (T02 Field route) [reuse]
Layer: browser
Steps: n/a.
Expected: The four optional fields are shown only for a UAE company (`MS_RATE.cs:1705 {{if (Operators.CompareString(DC_Main.MCo_SName, "UAE", false) == 0)}}`), which makes them visible (`MS_RATE.cs:1711 {{((Control)nGoldOzRate).Visible = true;}}`). The fixture company is not UAE, so there is no UAE field route to exercise through that UI; the hidden defaults are `MS_RATE.cs:1259 {{((Control)nGoldOzRate).Visible = false;}}` and `MS_RATE.cs:1316 {{((Control)nPrGoldRate).Visible = false;}}`.
Status: N/A: the fixture company is not UAE; the UAE recalculation is covered by packages/core/test/dailyRate.test.ts. The copied optional numeric columns are still compared through a controlled UAE fixture in `daily-rate.field-route.copied-optional-numeric-columns` (Gap 6).

### daily-rate.field-route.copied-optional-numeric-columns (T02 Field route)
Layer: browser
Steps: 1. Using a controlled UAE company fixture, set Gold Purc 10gm, Silver Purc 1Kg, Gold USD Pr Oz and Silver USD Pr Oz through their controls. 2. Save at location 00 with copy enabled. 3. Trace each value from request → RATE_MAST source row → destination row → reopened header, and assert the six header fields map to their own columns (Gap 6).
Expected: The UAE branch makes all four visible (`MS_RATE.cs:1712 {{((Control)nSilverOzRate).Visible = true;}}`, `MS_RATE.cs:1713 {{((Control)nPrGoldRate).Visible = true;}}`, `MS_RATE.cs:1714 {{((Control)nPrSilverRate).Visible = true;}}`) and each writes to its own column: `MS_RATE.cs:1912 {{dataRow["FINE_GL_PR_RATE"] = Conversion.Val(nPrGoldRate.Text);}}`, `MS_RATE.cs:1913 {{dataRow["FINE_SL_PR_RATE"] = Conversion.Val(nPrSilverRate.Text);}}`, `MS_RATE.cs:1914 {{dataRow["DOLLAR_GL_RATE"] = Conversion.Val(nGoldOzRate.Text);}}`, `MS_RATE.cs:1915 {{dataRow["DOLLAR_SL_RATE"] = Conversion.Val(nSilverOzRate.Text);}}`. The copy projects them unchanged (`MS_RATE.cs:1945 {{FINE_GL_PR_RATE,FINE_SL_PR_RATE,DOLLAR_GL_RATE,DOLLAR_SL_RATE,AND_TRFR,GR_TAX_RATE,GR_TAX_PRC,OP_GL_RATE)}}`). A core calculation test is not UI coverage.
Status: executable

## T03 Formula sequence

### daily-rate.formula.enter-on-silver-recomputes (T03 Formula sequence) [reuse]
Layer: unit
Steps: 1. Set Gold Rate 10gm = 72000 and Silver Rate 1Kg = 85000. 2. Press Enter on silver. 3. Record TaxRate, Rate10gm and PrRate for R18, R22, RSV.
Expected: Worked arithmetic: R18 (G, touch 75, tax 0) TaxRate = Round(75×72000/100) = 54000, tax 0 so Rate10gm stays 54000, PrRate = Round(76×72000/100) = 54720 (`MS_RATE.cs:2340 {{mSG[DC_Main.M, 5] = Strings.Format((object)Math.Round(Conversion.Val(mSG[DC_Main.M, 3]) * Conversion.Val(nGoldRate.Text) / 100.0), "0.00");}}`). R22 (G, touch 91.6, tax 3) TaxRate = Round(91.6×72000/100) = 65952, Rate10gm = Round(65952/(3+100)×100, 0) = 64031, PrRate = Round(92×72000/100) = 66240 (`MS_RATE.cs:2344 {{mSG[DC_Main.M, 5] = Strings.Format((object)Math.Round(Conversion.Val(mSG[DC_Main.M, 6]) / (Conversion.Val(mSG[DC_Main.M, 4]) + 100.0) * 100.0, 0), "0.00");}}`). RSV (S, touch 92.5, tax 3) TaxRate = Round(92.5×85000/10000) = Round(786.25) = 786 (to even), Rate10gm = Round(786/103×100, 0) = 763, PrRate = Round(90×85000/10000) = 765 (`MS_RATE.cs:2355 {{mSG[DC_Main.M, 5] = Strings.Format((object)Math.Round(Conversion.Val(mSG[DC_Main.M, 6]) / (Conversion.Val(mSG[DC_Main.M, 4]) + 100.0) * 100.0, 0), "0.00");}}`). The resulting grid is R18 [54000,54000,54720], R22 [65952,64031,66240], RSV [786,763,765].
Status: executable

### daily-rate.formula.gold-enter-tax-precedence (T03 Formula sequence)
Layer: unit
Steps: 1. Change only Gold Rate 10gm from 72000 to 73000 with a nonzero touch and tax. 2. Press Enter on gold. 3. Check the intermediate TaxRate and the overridden Rate10gm.
Expected: Only a changed nonzero header recomputes (`MS_RATE.cs:2338 {{if ((Conversion.Val(nGoldRate.Text) != 0.0) & (OldGoldRate != Conversion.Val(nGoldRate.Text)))}}`); TaxRate is set first (`MS_RATE.cs:2341 {{mSG[DC_Main.M, 6] = Strings.Format((object)Math.Round(Conversion.Val(mSG[DC_Main.M, 3]) * Conversion.Val(nGoldRate.Text) / 100.0), "0.00");}}`) and, when tax is nonzero, Rate10gm is replaced by the tax-divided value (`MS_RATE.cs:2344 {{mSG[DC_Main.M, 5] = Strings.Format((object)Math.Round(Conversion.Val(mSG[DC_Main.M, 6]) / (Conversion.Val(mSG[DC_Main.M, 4]) + 100.0) * 100.0, 0), "0.00");}}`). For R22: TaxRate = Round(91.6×73000/100) = 66868, Rate10gm = Round(66868/103×100, 0) = 64920. PrRate = Round(92×73000/100) = 67160 (`MS_RATE.cs:2346 {{mSG[DC_Main.M, 8] = Strings.Format((object)Math.Round(Conversion.Val(mSG[DC_Main.M, 7]) * Conversion.Val(nGoldRate.Text) / 100.0), "0.00");}}`). Math.Round is to-even on midpoint.
Status: executable

### daily-rate.formula.uae-purchase-override (T03 Formula sequence)
Layer: unit
Steps: 1. In the UAE fixture, set sale gold/silver and then change only Gold Purc 10gm. 2. Confirm PrRate is overridden from the purchase header. 3. Repeat with Silver Purc 1Kg.
Expected: After the sale formulas, a changed nonzero purchase header overrides PrRate with divisor 100 for gold (`MS_RATE.cs:2428 {{mSG[DC_Main.M, 8] = Strings.Format((object)Math.Round(Conversion.Val(mSG[DC_Main.M, 7]) * Conversion.Val(nPrGoldRate.Text) / 100.0), "0.00");}}`) and 10000 for silver (`MS_RATE.cs:2445 {{mSG[DC_Main.M, 8] = Strings.Format((object)Math.Round(Conversion.Val(mSG[DC_Main.M, 7]) * Conversion.Val(nPrSilverRate.Text) / 10000.0), "0.00");}}`). This overrides only when the purchase header changed (`MS_RATE.cs:2426 {{if ((Conversion.Val(nPrGoldRate.Text) != 0.0) & (OldPrGoldRate != Conversion.Val(nPrGoldRate.Text)))}}`). No new residual arithmetic is needed.
Status: executable

## T04 Lookup

### daily-rate.lookup.f1-saved-dates (T04 Lookup)
Layer: browser
Steps: 1. Save two different days. 2. Click F1, cancel once, reopen F1, choose the older day. 3. Confirm the chosen day's grid and headers load.
Expected: F1 lists saved dates/users/gold/silver grouped without a year predicate, newest first (`MS_RATE.cs:2373 {{GROUP BY VCH_DATE,MAIN_USER,FINE_GL_RATE,FINE_SL_RATE  ORDER BY VCH_DATE DESC}}`); after selection focus returns to date (`MS_RATE.cs:2388 {{((Control)mVchDate).Focus();}}`). Saved values come from RATE_MAST by company, location and date (`MS_RATE.cs:1756 {{VCH_DATE = '}}`), with FINE_GL_RATE formatted `"0.00"` on reopen (`MS_RATE.cs:1761 {{nGoldRate.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsDetl.Rows[0]["FINE_GL_RATE"]), "0.00");}}`).
Status: executable

### daily-rate.lookup.date-enter-reload (T04 Lookup)
Layer: browser
Steps: 1. Fill Vch Date with a saved date and press Enter. 2. Confirm the grid reloads and focus advances with Tab.
Expected: Date Enter calls the shared setter (`MS_RATE.cs:2293 {{DC_Main.SetDate(ref MsDate);}}`); on a valid date only, it reloads and sends Tab (`MS_RATE.cs:2295 {{if (!DC_Main.RongDate)}}`, `MS_RATE.cs:2297 {{DISPLAY_DATA();}}`, `MS_RATE.cs:2298 {{SendKeys.Send("{TAB}");}}`). On an invalid date RongDate suppresses the reload.
Status: executable

### daily-rate.lookup.invalid-date-validation (T04 Lookup)
Layer: browser
Steps: 1. Enter malformed, out-of-range and boundary dates and press Enter. 2. Record the message, refusal and focus (if any).
Expected: The branch is `MS_RATE.cs:2295 {{if (!DC_Main.RongDate)}}` after `MS_RATE.cs:2293 {{DC_Main.SetDate(ref MsDate);}}`, but the study does not contain the full shared date-validation rule.
Status: blocked: MISSING `.orch/index/DC_Main.md`. Exact question: what message text, refusal and focus does the shared `DC_Main.SetDate`/`RongDate` validation produce for an invalid date, and is any RATE_MAST write suppressed? Full date-helper parity is explicitly outside WP-33; unblocks when the shared date-helper study is supplied.

### daily-rate.lookup.group-membership (T04 Lookup)
Layer: browser
Steps: 1. Add a zero-touch group and an RATE_MAST row for a group no longer in GROUP_MAST. 2. Open the day and read the grid. 3. Confirm which rows appear.
Expected: Grid membership is current company groups with `MS_RATE.cs:1781 {{AND GR_TOUCH <> 0 ORDER BY GR_TYPE,GR_NAME}}`; saved values are matched by code only (`MS_RATE.cs:1802 {{dataView.RowFilter = "GR_CODE = '" + mSG[DC_Main.i + 1, 1] + "'";}}`). A zero-touch group is absent; an orphan saved row has no grid cell and is not written back.
Status: executable

## T05 Children

### daily-rate.children.two-days-independent (T05 Children)
Layer: browser
Steps: 1. Save day A with groups R18+R22 priced and day B with RSV priced. 2. Edit A's R18 rate. 3. Query both days.
Expected: A replace-day save deletes only its own company/location/year/date set (`MS_RATE.cs:1894 {{DELETE FROM RATE_MAST WHERE CO_CODE = '}}`) before inserting qualifying rows (`MS_RATE.cs:1904 {{if ((Conversion.Val(MSG[DC_Main.i, 3]) != 0.0) & (Conversion.Val(MSG[DC_Main.i, 5]) != 0.0))}}`). Day B keeps its single RSV row; no child moves between parents.
Status: executable

### daily-rate.children.sr-no-order (T05 Children)
Layer: browser
Steps: 1. Price all three groups and save. 2. Read SR_NO against grid row. 3. Reorder the grid inputs and re-save.
Expected: SR_NO is the grid row (`MS_RATE.cs:1916 {{dataRow["SR_NO"] = DC_Main.i;}}`); R18=1, R22=2, RSV=3 in the seeded order, with GR_CODE from `MS_RATE.cs:1917 {{dataRow["GR_CODE"] = MSG[DC_Main.i, 1];}}`. Re-save follows the new order and writes no duplicate rows.
Status: executable

## T06 Required/invalid

### daily-rate.refusal.negative-rate-no-write (T06 Required/invalid) [reuse]
Layer: browser
Steps: 1. Price the day, then set `Rate10gm R18` = -5. 2. Save. 3. Query the day.
Expected: A negative rate is refused with HTTP 400 and no business write; qualifying rows require both touch and Rate10gm nonzero (`MS_RATE.cs:1904 {{if ((Conversion.Val(MSG[DC_Main.i, 3]) != 0.0) & (Conversion.Val(MSG[DC_Main.i, 5]) != 0.0))}}`), so the day holds no rows.
Status: executable

### daily-rate.refusal.save-no-rights (T06 Required/invalid)
Layer: browser
Steps: 1. As a user with FRM_EDIT != Y and an existing day (EntryMode E), attempt Save. 2. Record the message and focus. 3. Query the day.
Expected: The exact gate is `MS_RATE.cs:1886 {{if ((Operators.CompareString(UserEdit, "Y", false) != 0) & (Operators.CompareString(EntryMode, "E", false) == 0))}}` and the message is `MS_RATE.cs:1888 {{Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);}}`, then `MS_RATE.cs:1889 {{goto end_IL_0001;}}` exits with no explicit focus assignment and no partial write. DISPLAY_DATA sets EntryMode E unconditionally (`MS_RATE.cs:1830 {{EntryMode = "E";}}`), so the gate is active on every reopened day.
Status: executable

### daily-rate.refusal.delete-no-rights-and-confirm (T06 Required/invalid)
Layer: browser
Steps: 1. As a user without delete right, click Delete; record the message. 2. As a user with delete right, click Delete and answer No, then Yes.
Expected: Refusal is `MS_RATE.cs:2102 {{Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);}}` under `MS_RATE.cs:2100 {{if (Operators.CompareString(UserDelete, "Y", false) != 0)}}`; permitted delete asks `MS_RATE.cs:2104 {{else if ((int)Interaction.MsgBox((object)"Are You Sure To Delete This Day Rate?", (MsgBoxStyle)4, (object)DC_Main.MsgTitle) == 6)}}` and only Yes runs `MS_RATE.cs:2107 {{CLEAR_DATA();}}`; No has no focus assignment.
Status: executable

### daily-rate.refusal.print-no-rights (T06 Required/invalid)
Layer: browser
Steps: 1. As a user without print right, click Print. 2. Record the message, focus and absence of output.
Expected: `MS_RATE.cs:1837 {{if (Operators.CompareString(UserPrint, "Y", false) != 0)}}` then `MS_RATE.cs:1839 {{Interaction.MsgBox((object)"You Have No Print Rights.....", (MsgBoxStyle)0, (object)null);}}`; no focus assignment follows in that branch and no report is produced.
Status: executable

### daily-rate.settlement.not-applicable (T06 Required/invalid) [reuse]
Layer: browser
Steps: n/a.
Expected: The source description is corrected for Gap 7: MS_RATE also updates GROUP_MAST at 00 (`MS_RATE.cs:1932 {{UPDATE GROUP_MAST SET GR_RATE = }}`) and can write destination RATE_MAST rows (`MS_RATE.cs:1945 {{INSERT INTO RATE_MAST}}`), so the old summary "writes RATE_MAST only" is inaccurate; the full footprint is asserted in `daily-rate.write-set.full-footprint`.
Status: N/A: a daily rate has no tender, ledger or stock effect; no settlement workflow is created from the corrected summary.

### daily-rate.write-set.full-footprint (T06 Required/invalid)
Layer: database
Steps: 1. Seed sentinels in another tenant, company, location and date. 2. Save at location 00 with copy enabled. 3. Compare every affected row in RATE_MAST, GROUP_MAST and destinations before/after (Gap 7).
Expected: Source rows are inserted with all header and detail fields (`MS_RATE.cs:1910 {{dataRow["FINE_GL_RATE"] = Conversion.Val(nGoldRate.Text);}}`, `MS_RATE.cs:1920 {{dataRow["GR_RATE"] = Conversion.Val(MSG[DC_Main.i, 5]);}}`, `MS_RATE.cs:1926 {{dataRow["MAIN_USER"] = MainUser;}}`); GROUP_MAST is updated only for location 00 (`MS_RATE.cs:1930 {{if (Operators.CompareString(DC_Main.MLc_code, "00", false) == 0)}}`); destinations are inserted by `MS_RATE.cs:1945 {{INSERT INTO RATE_MAST(CO_CODE,LC_CODE,CO_YEAR,VCH_DATE,SR_NO,GR_CODE,FINE_GL_RATE,FINE_SL_RATE,  GR_RATE,GR_TOUCH,GR_TYPE,EMP_CODE,CASH_AMT,MAIN_USER,ADD_USER,ADD_DATE,GR_PR_TOUCH,GR_PR_RATE,  FINE_GL_PR_RATE,FINE_SL_PR_RATE,DOLLAR_GL_RATE,DOLLAR_SL_RATE,AND_TRFR,GR_TAX_RATE,GR_TAX_PRC,OP_GL_RATE)}}`. All sentinels are byte-identical.
Status: executable

## T07 Create

### daily-rate.create.desktop-rows (T07 Create) [reuse]
Layer: browser
Steps: 1. Price the day (72000/85000). 2. Save once. 3. Query the complete RATE_MAST footprint.
Expected: One row per priced group with SR_NO = grid row, the six header rates, GR_TYPE and MainUser, and no GR_NAME: `MS_RATE.cs:1908 {{dataRow["CO_YEAR"] = DC_Main.MCo_year;}}`, `MS_RATE.cs:1911 {{dataRow["FINE_SL_RATE"] = Conversion.Val(nSilverRate.Text);}}`, `MS_RATE.cs:1924 {{dataRow["GR_TYPE"] = MSG[DC_Main.i, 9];}}`, inserted via `MS_RATE.cs:1928 {{((DbDataAdapter)(object)DC_Main.Da).Update(RsDetl);}}`. Rows: R18 [54000,54000,54720], R22 [65952,64031,66240], RSV [786,763,765].
Status: executable

### daily-rate.create.group-rate-at-00 (T07 Create)
Layer: database
Steps: 1. At location 00 save a day with R18 and R22 priced and RSV skipped. 2. Read GROUP_MAST.GR_RATE for all three. 3. Seed a non-00 location and repeat.
Expected: For each qualifying insert, location 00 sets GR_RATE from the displayed Rate10gm, not TaxRate or a header: `MS_RATE.cs:1920 {{dataRow["GR_RATE"] = Conversion.Val(MSG[DC_Main.i, 5]);}}` and `MS_RATE.cs:1932 {{UPDATE GROUP_MAST SET GR_RATE = }}`. So R18.GR_RATE = 54000.00 and R22.GR_RATE = 64031.00, while skipped RSV retains its prior value; touch/tax/purchase rate are unchanged. At a non-00 location the update does not run (`MS_RATE.cs:1930 {{if (Operators.CompareString(DC_Main.MLc_code, "00", false) == 0)}}`).
Status: executable

## T08 Reopen/no-op

### daily-rate.reopen.f1-list (T08 Reopen/no-op) [reuse]
Layer: browser
Steps: 1. Save a day, close the form, reopen through F1. 2. Confirm raw values, scale and identities are preserved. 3. Save unchanged.
Expected: Reopen selects by company/location/year/date (`MS_RATE.cs:1756 {{AND LC_CODE = '}}`, `MS_RATE.cs:1756 {{AND CO_YEAR = '}}`), so the day's six header fields and per-group values return unchanged; gold is formatted to two places (`MS_RATE.cs:1761 {{nGoldRate.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsDetl.Rows[0]["FINE_GL_RATE"]), "0.00");}}`), giving 72000.00.
Status: executable

### daily-rate.edit.unchanged-save (T08 Reopen/no-op) [reuse]
Layer: browser
Steps: 1. Save a day. 2. Save the same day again without edits. 3. Compare all rows and clocks.
Expected: An unchanged re-save still deletes and rewrites the day (`MS_RATE.cs:1894 {{DELETE FROM RATE_MAST WHERE CO_CODE = '}}`) but produces an identical set of rows; success is `MS_RATE.cs:2007 {{Interaction.MsgBox((object)"Data Are Saved.", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);}}` followed by `MS_RATE.cs:2015 {{CLEAR_DATA();}}` in normal mode.
Status: executable

## T09 Edit

### daily-rate.edit.unpriced-group-skipped (T09 Edit) [reuse]
Layer: browser
Steps: 1. Save all three groups. 2. Clear `Rate10gm R18` and re-save. 3. Query the day.
Expected: Re-save deletes the whole day first (`MS_RATE.cs:1896 {{SELECT * FROM RATE_MAST}}`) and inserts only rows where both touch and Rate10gm are nonzero (`MS_RATE.cs:1904 {{if ((Conversion.Val(MSG[DC_Main.i, 3]) != 0.0) & (Conversion.Val(MSG[DC_Main.i, 5]) != 0.0))}}`), leaving R22 and RSV and dropping R18; no orphan R18 row remains.
Status: executable

### daily-rate.edit.dropped-group (T09 Edit)
Layer: database
Steps: 1. Save a day with all three groups at 00 (group GR_RATEs set). 2. Remove R22 from GROUP_MAST (or set its touch to 0) and re-save. 3. Compare RATE_MAST and GROUP_MAST.
Expected: The dropped group is absent from the grid (`MS_RATE.cs:1781 {{AND GR_TOUCH <> 0 ORDER BY GR_TYPE,GR_NAME}}`) so no row is written for it, and the group update runs only inside the qualifying insert loop (`MS_RATE.cs:1930 {{if (Operators.CompareString(DC_Main.MLc_code, "00", false) == 0)}}`, `MS_RATE.cs:1932 {{UPDATE GROUP_MAST SET GR_RATE = }}`): R22 retains its previous GR_RATE while R18 and R22's RATE_MAST history is replaced correctly.
Status: executable

### daily-rate.edit.backdated-group-update (T09 Edit)
Layer: database
Steps: 1. At 00, first save today's date, then save an older date with different rates. 2. Read GROUP_MAST.GR_RATE after each. 3. Confirm the backdated save updates the group.
Expected: The location-00 group update has no newest-date condition (`MS_RATE.cs:1932 {{UPDATE GROUP_MAST SET GR_RATE = }}` inside `MS_RATE.cs:1930 {{if (Operators.CompareString(DC_Main.MLc_code, "00", false) == 0)}}`), so a backdated save still overwrites GR_RATE with that day's Rate10gm (`MS_RATE.cs:1920 {{dataRow["GR_RATE"] = Conversion.Val(MSG[DC_Main.i, 5]);}}`) — the last save wins regardless of date.
Status: executable

## T10 Delete/cancel/reverse

### daily-rate.delete.day (T10 Delete/cancel/reverse) [reuse]
Layer: browser
Steps: 1. Save a day. 2. Click Delete and answer Yes. 3. Query the day.
Expected: The confirm text is `MS_RATE.cs:2104 {{else if ((int)Interaction.MsgBox((object)"Are You Sure To Delete This Day Rate?", (MsgBoxStyle)4, (object)DC_Main.MsgTitle) == 6)}}`; Yes runs `MS_RATE.cs:2106 {{DELETE FROM RATE_MAST WHERE CO_CODE = '}}` and `MS_RATE.cs:2107 {{CLEAR_DATA();}}`, so the day has no rows.
Status: executable

### daily-rate.delete.non-reversal (T10 Delete/cancel/reverse)
Layer: database
Steps: 1. At 00 save with copy enabled (group GR_RATE updated, destinations written). 2. Delete the source day. 3. Check GROUP_MAST, destinations and labels.
Expected: Delete is only the company/location/date RATE_MAST deletion plus clear (`MS_RATE.cs:2106 {{DELETE FROM RATE_MAST WHERE CO_CODE = '}}`, `MS_RATE.cs:2107 {{CLEAR_DATA();}}`). It does not undo GROUP_MAST.GR_RATE, does not run the copy (`MS_RATE.cs:1937 {{if (Operators.CompareString(DC_Main.SSRegSrNo, "VK142NEVK", false) == 0 && Operators.CompareString(DC_Main.MLc_code, "00", false) == 0)}}`), and does not refresh labels; those values remain as after the save.
Status: executable

### daily-rate.cancel-and-exit (T10 Delete/cancel/reverse)
Layer: browser
Steps: 1. Dirty a grid, click Cancel; confirm clear only. 2. Click Exit; confirm close only. 3. Open/close enough forms to cross the three-form boundary and observe PanelImage.
Expected: Cancel is `MS_RATE.cs:2118 {{CLEAR_DATA();}}` with no delete; Exit is `MS_RATE.cs:2113 {{((Form)this).Close();}}` with no clear. On closing, PanelImage is shown only when open forms are at most three (`MS_RATE.cs:2270 {{if (((ReadOnlyCollectionBase)(object)((WindowsFormsApplicationBase)MyProject.Application).OpenForms).Count <= 3)}}`, `MS_RATE.cs:2272 {{((Control)MyProject.Forms.MDI_FORM.PanelImage).Visible = true;}}`), else hidden (`MS_RATE.cs:2276 {{((Control)MyProject.Forms.MDI_FORM.PanelImage).Visible = false;}}`).
Status: executable

## T11 Scope/rights

### daily-rate.scope.no-rights-user (T11 Scope/rights) [reuse]
Layer: browser
Steps: 1. Save a day as admin. 2. As clerk without Daily Rate rights, call GET, GET print, DELETE and POST directly. 3. Compare the day.
Expected: Rights come from USER_SET by location/user/form (`MS_RATE.cs:1560 {{Select * From USER_SET WHERE LC_CODE = '}}`, `MS_RATE.cs:1565 {{UserEdit = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["FRM_EDIT"], (object)""));}}`); all four calls are refused with HTTP 403 and the day is byte-identical, matching the save/delete/print gates above.
Status: executable

### daily-rate.scope.mdi-shortcut-view-rights (T11 Scope/rights)
Layer: browser
Steps: 1. Invoke the F1+Ctrl Daily Rate shortcut as a user without FRM_VIEW. 2. Record the refusal and PanelImage. 3. Repeat with FRM_VIEW=Y.
Expected: The shortcut is advertised as `MDI_FORM.cs:5604 {{((ToolStripItem)F1CtrlDailyRateToolStripMenuItem).Text = "F1 + Ctrl Daily Rate";}}`; its handler requires `MDI_FORM.cs:14395 {{AND FRM_VIEW = 'Y'}}`, refuses with `MDI_FORM.cs:14400 {{Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);}}` and shows `MDI_FORM.cs:14401 {{((Control)PanelImage).Visible = true;}}`; with the right it opens `MDI_FORM.cs:14405 {{MS_RATE mS_RATE = new MS_RATE();}}`.
Status: executable

### daily-rate.scope.copy-authorized-company-only (T11 Scope/rights)
Layer: database
Steps: 1. With copy enabled at 00, seed another tenant/company and a location outside the authorized company. 2. Save. 3. Confirm neither is a copy destination (decision 1).
Expected: The desktop enumerates only non-00 locations of the current company (`MS_RATE.cs:1939 {{AND LC_CODE <> '00' ORDER BY LC_CODE}}`) and executes per destination (`MS_RATE.cs:1946 {{DC_Main.ExeQuteDc(DC_Main.RsQry);}}`); the hosted form adds an explicit authorized company scope so no client-supplied registration value can fan out to another tenant/company. Foreign sentinels are untouched.
Status: executable

## T12 Concurrency

### daily-rate.concurrency.two-operators-same-day (T12 Concurrency) [reuse]
Layer: browser
Steps: 1. Two sessions load the same day (72000/85000 vs 73000/86000). 2. Save both concurrently. 3. Query the day.
Expected: The desktop deletes and rewrites with no version check, so the hosted result must be one valid outcome — statuses 201/201 or 201/409 with at least one 201 — and exactly three rows from a single writer (all gold 72000 or all 73000), never a mixture or duplicates (`MS_RATE.cs:1894 {{DELETE FROM RATE_MAST WHERE CO_CODE = '}}`, `MS_RATE.cs:1928 {{((DbDataAdapter)(object)DC_Main.Da).Update(RsDetl);}}`).
Status: executable

### daily-rate.copy.overlapping-save-locks (T12 Concurrency)
Layer: database
Steps: 1. Configure two source companies whose copy destinations overlap. 2. Save both concurrently. 3. Confirm each destination holds one complete set from a single source.
Expected: The copy loop advances one location at a time (`MS_RATE.cs:1947 {{DC_Main.R++;}}`) with no cross-destination coordination, so the hosted service must use deterministic overlapping-save locks (extending the same-day serialization at `web/apps/api/src/modules/masters/dailyRate.ts:231–234`): one complete set per destination, no interleaved or duplicate rows.
Status: executable

## T13 Retry/unknown

### daily-rate.retry.replayed-save (T13 Retry/unknown) [reuse]
Layer: browser
Steps: 1. Save a day (201). 2. Replay the identical POST after the acknowledgment is "lost". 3. Compare the day.
Expected: Replay is an idempotent replace-day: delete then rewrite (`MS_RATE.cs:1894 {{DELETE FROM RATE_MAST WHERE CO_CODE = '}}`), success `MS_RATE.cs:2007 {{Interaction.MsgBox((object)"Data Are Saved.", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);}}`, and identical rows with no duplicates and no second group update effect.
Status: executable

### daily-rate.copy.replayed-no-duplicate (T13 Retry/unknown)
Layer: database
Steps: 1. Save at 00 with copy enabled (201). 2.Replay the same request. 3. Count destination rows in every location.
Expected: The copy is a replacement, not an append: each destination day is deleted before insert (`MS_RATE.cs:1944 {{DELETE FROM RATE_MAST WHERE CO_CODE = '}}`), so a replay yields the same single set per destination and the same GROUP_MAST.GR_RATE (`MS_RATE.cs:1932 {{UPDATE GROUP_MAST SET GR_RATE = }}`), with no duplicate financial effect.
Status: executable

## T14 Rollback

### daily-rate.rollback.rate-write-fault (T14 Rollback) [reuse]
Layer: database
Steps: 1. Save a day. 2. Install a trigger that fails an INSERT for RSV at that date. 3. Edit gold and re-save; compare before/after.
Expected: The desktop has no enclosing transaction (`MS_RATE.cs:1895 {{DC_Main.ExeQuteDc(DC_Main.RsQry);}}`, `MS_RATE.cs:1928 {{((DbDataAdapter)(object)DC_Main.Da).Update(RsDetl);}}`) and only shows `MS_RATE.cs:2024 {{Interaction.MsgBox((object)("Error Found: " + Information.Err().Description + "\rClick Ok to Exit."), (MsgBoxStyle)48, (object)DC_Main.MsgTitle);}}`; the hosted service must roll the delete back completely, so the day keeps its earlier three rows and unrelated sentinels are intact.
Status: executable

### daily-rate.copy.atomic-all-locations-rollback (T14 Rollback)
Layer: database
Steps: 1. Configure three copy destinations; make the second fail on insert. 2. Save at 00 with copy enabled. 3. Check source day, GROUP_MAST, first/second/third destinations and sentinels.
Expected: The desktop executes source, each group update and each destination separately (`MS_RATE.cs:1895 {{DC_Main.ExeQuteDc(DC_Main.RsQry);}}`, `MS_RATE.cs:1932 {{DC_Main.ExeQuteDc(}}, `MS_RATE.cs:1946 {{DC_Main.ExeQuteDc(DC_Main.RsQry);}}`) with the error handler above. The hosted service must wrap all of them in one transaction: a later failure rolls back the source rewrite, every group update and every destination replacement, leaving all tables as before.
Status: executable

## T15 Config/history

### daily-rate.settings.pending (T15 Config/history) [reuse — replaces the original blocked declaration]
Layer: browser
Steps: 1. Provision/choose an authorized 00 session through the real UI and assert its scope (Gap 1). 2. Save and edit a day through the page. 3. Assert the full RATE_MAST and GROUP_MAST writes plus other-location/tenant sentinels; include skipped groups, a backdated save, cancel/delete non-reversal and rollback.
Expected: Location 00 writes the saved Rate10gm to company/group GR_RATE (`MS_RATE.cs:1930 {{if (Operators.CompareString(DC_Main.MLc_code, "00", false) == 0)}}`, `MS_RATE.cs:1932 {{UPDATE GROUP_MAST SET GR_RATE = }}`) as verified in `daily-rate.create.group-rate-at-00`. The original blocked reason — "Location 00 also sets GROUP_MAST.GR_RATE; covered in the HTTP test." — is corrected: that test calls the writer directly, not through an HTTP or browser session. Use a distinct login cache slot; do not spoof scope in the POST.
Status: executable

### daily-rate.settings.copy-eligibility-setting (T15 Config/history)
Layer: browser
Steps: 1. With copy disabled, save a priced day at 00; assert no destinations written. 2. Enable the explicit authorized setting and save a different day; assert destinations written. 3. Toggle between preview and save and record which snapshot applies (decision 1).
Expected: The desktop gate is `MS_RATE.cs:1937 {{if (Operators.CompareString(DC_Main.SSRegSrNo, "VK142NEVK", false) == 0 && Operators.CompareString(DC_Main.MLc_code, "00", false) == 0)}}`; the hosted form substitutes an authorized company setting while keeping the location-00 source requirement. Both false-gate cases (setting off, or source location not 00) produce no fan-out.
Status: executable

### daily-rate.copy.gate-false-no-fanout (T15 Config/history)
Layer: database
Steps: 1. Case A: authorized setting on but source location 01. Case B: source location 00 but setting off. 2. Save priced days in each. 3. Query all non-00 locations.
Expected: No destination rows are written in either case and GROUP_MAST is updated only in the 00 case (`MS_RATE.cs:1930 {{if (Operators.CompareString(DC_Main.MLc_code, "00", false) == 0)}}`). The gate requires both predicates together (`MS_RATE.cs:1937 {{if (Operators.CompareString(DC_Main.SSRegSrNo, "VK142NEVK", false) == 0 && Operators.CompareString(DC_Main.MLc_code, "00", false) == 0)}}`).
Status: executable

### daily-rate.copy.destination-enumeration (T15 Config/history)
Layer: database
Steps: 1. Seed locations 01, 02, 98 for the company, a non-00 location for another company and an inactive location. 2. Save at 00 with copy on. 3. List every location that received rows.
Expected: Destinations are exactly the non-00 locations of the same company, ordered LC_CODE (`MS_RATE.cs:1939 {{AND LC_CODE <> '00' ORDER BY LC_CODE}}`), each written by `MS_RATE.cs:1946 {{DC_Main.ExeQuteDc(DC_Main.RsQry);}}`. No active-location or rights filter exists in the desktop loop, but the hosted form adds authorized company scope (decision 1); no other company/location is a target.
Status: executable

### daily-rate.copy.full-column-projection (T15 Config/history)
Layer: database
Steps: 1. Save a source day at 00 with all optional fields set. 2. Read one destination row. 3. Compare every column to the source.
Expected: Copy projects all columns verbatim with no arithmetic and no GR_NAME: `MS_RATE.cs:1945 {{INSERT INTO RATE_MAST(CO_CODE,LC_CODE,CO_YEAR,VCH_DATE,SR_NO,GR_CODE,FINE_GL_RATE,FINE_SL_RATE,  GR_RATE,GR_TOUCH,GR_TYPE,EMP_CODE,CASH_AMT,MAIN_USER,ADD_USER,ADD_DATE,GR_PR_TOUCH,GR_PR_RATE,  FINE_GL_PR_RATE,FINE_SL_PR_RATE,DOLLAR_GL_RATE,DOLLAR_SL_RATE,AND_TRFR,GR_TAX_RATE,GR_TAX_PRC,OP_GL_RATE)}}`. The projected rate is the stored GR_RATE (`MS_RATE.cs:1945 {{GR_RATE,GR_TOUCH,GR_TYPE,EMP_CODE,CASH_AMT,MAIN_USER,ADD_USER,ADD_DATE,GR_PR_TOUCH,GR_PR_RATE}}`); only LC_CODE is substituted.
Status: executable

### daily-rate.copy.replaces-not-appends (T15 Config/history)
Layer: database
Steps: 1. Pre-seed a destination day with old rows. 2. Save a new source day at 00 with copy on. 3. Count and compare destination rows.
Expected: Each destination day is deleted before insert (`MS_RATE.cs:1944 {{DELETE FROM RATE_MAST WHERE CO_CODE = '}}`, `MS_RATE.cs:1944 {{AND VCH_DATE = '}}`), then replaced from source (`MS_RATE.cs:1945 {{AND LC_CODE = '00' AND VCH_DATE = '}}`). The destination holds exactly the new source set, with no old rows appended.
Status: executable

### daily-rate.copy.zero-source-deletion (T15 Config/history)
Layer: database
Steps: 1. Pre-seed a destination day with old rows but leave source location 00 empty for that date. 2. Save at 00 with copy on (or with an empty grid). 3. Query the destination.
Expected: An empty source selection still deletes the destination day because the delete is unconditional before the insert-select (`MS_RATE.cs:1944 {{DELETE FROM RATE_MAST WHERE CO_CODE = '}}`, `MS_RATE.cs:1945 {{AND LC_CODE = '00' AND VCH_DATE = '}}`). The destination ends with zero rows.
Status: executable

### daily-rate.copy.cross-year-collision (T15 Config/history)
Layer: database
Steps: 1. Seed a destination row for the same company/location/date but a different CO_YEAR. 2. Save the source day at 00 with copy on. 3. Compare both CO_YEAR rows (decision 2).
Expected: The hosted replacement key includes CO_YEAR so the different-year sentinel is not deleted or overwritten: it remains byte-identical, while the same-year destination day is replaced. The desktop omits CO_YEAR from the copy predicates (`MS_RATE.cs:1944 {{AND VCH_DATE = '}}`) and copies it as data (`MS_RATE.cs:1945 {{',CO_YEAR,VCH_DATE,SR_NO,GR_CODE,FINE_GL_RATE,FINE_SL_RATE, }}`); the hosted form keeps all required tenant/company/location bounds.
Status: executable

### daily-rate.labels.historical-save-refresh (T15 Config/history)
Layer: browser
Steps: 1. Establish today's labels with one rate set. 2. Save a historical date at 00 with a different rate set. 3. Read the labels without a manual reload (Gap 5).
Expected: The desktop refreshes today's display after every successful save using MsSysDate, not the voucher date (`MS_RATE.cs:1950 {{Strings.Format((object)DC_Main.MsSysDate, "MM/dd/yyyy")}}`), so the labels update to the new values immediately even though the saved voucher date is historical; the web must invalidate the display projection on commit rather than wait for the 60000 ms poll.
Status: executable

## T16 Report/output

### daily-rate.print.rate-report (T16 Report/output) [reuse]
Layer: browser
Steps: 1. Save a day. 2. Run Print and capture the RateRpt HTML/print output. 3. Check title, columns and rates. Also check the print-right refusal above.
Expected: New path rptName is `MS_RATE.cs:1843 {{string rptName = "RateRpt";}}` with `MS_RATE.cs:1845 {{DC_Main.MsRptTitelStr = "'Daily Rate Report " + Strings.Format((object)Conversions.ToDate(mVchDate.Text), "dd/MM/yyyy") + "'";}}` and `MS_RATE.cs:1846 {{DC_Main.MsWappPrintType = "All";}}`; old path uses `MS_RATE.cs:1857 {{Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\RateRpt.RPT";}}` with preview destination `MS_RATE.cs:1860 {{Cr.Destination = (DestinationConstants)0;}}`. For date YYYY-MM-DD the title is `Daily Rate Report DD/MM/YYYY` and R22/R SV show 64,031.00 and 763.00.
Status: executable

## T17 Keyboard/usability

### daily-rate.keyboard.alt-s-saves (T17 Keyboard/usability) [reuse]
Layer: browser
Steps: 1. Price a day using keyboard only. 2. Press Alt+S. 3. Query the day.
Expected: `MS_RATE.cs:1124 {{BtnSave.Text = "&Save";}}` makes Alt+S the Save mnemonic; the save writes three rows with `MS_RATE.cs:2007 {{Interaction.MsgBox((object)"Data Are Saved.", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);}}`. The sibling mnemonics are `MS_RATE.cs:1137 {{BtnPrint.Text = "&Print";}}`, `MS_RATE.cs:1111 {{BtnCancel.Text = "&Cancel";}}`, `MS_RATE.cs:1097 {{BtnDelete.Text = "&Delete";}}`, `MS_RATE.cs:1084 {{BtnExit.Text = "E&xit";}}`.
Status: executable

### daily-rate.keyboard.editor-navigation (T17 Keyboard/usability)
Layer: browser
Steps: 1. Focus the grid editor and drive it with arrow keys, Enter and Esc. 2. Record cell movements and editor visibility.
Expected: Left/right/up/down change column/row within bounds (`MS_RATE.cs:2218 {{mSG.Col -= 1;}}`, `MS_RATE.cs:2224 {{mSG.Col += 1;}}`, `MS_RATE.cs:2230 {{mSG.Row -= 1;}}`, `MS_RATE.cs:2236 {{mSG.Row += 1;}}`); Enter in rate column 5 or 8 advances to the next row column 5 (`MS_RATE.cs:2251 {{mSG.Row += 1;}}`, `MS_RATE.cs:2252 {{mSG.Col = 5;}}`) or focuses Save at the last row (`MS_RATE.cs:2248 {{((Control)BtnSave).Focus();}}`); other Enter advances a column (`MS_RATE.cs:2259 {{MSG.Col += 1;}}`). Esc with a visible editor commits, moves to final row column 0, hides the editor and focuses Save (`MS_RATE.cs:2156 {{((Control)TEXT_ENTRY).Visible = false;}}`, `MS_RATE.cs:2157 {{((Control)BtnSave).Focus();}}`), otherwise closes the form (`MS_RATE.cs:2161 {{((Form)this).Close();}}`). Key-up selects editor text (`MS_RATE.cs:2178 {{if ((Operators.CompareString(((ContainerControl)this).ActiveControl.Name, "TEXT_ENTRY", false) == 0) & (((int)e.KeyCode == 39) | ((int)e.KeyCode == 37) | ((int)e.KeyCode == 38) | ((int)e.KeyCode == 40) | ((int)e.KeyCode == 13)))}}`).
Status: executable

### daily-rate.keyboard.enter-formatting-and-f1 (T17 Keyboard/usability)
Layer: browser
Steps: 1. Enter gold 72000 and press Enter; observe "0.00" formatting and Tab. 2. Enter gold 72 (whole) and silver 85000 with Enter and observe the editor target. 3. Click F1 help, choose a saved date, observe focus.
Expected: Gold Enter formats then tabs (`MS_RATE.cs:2309 {{nGoldRate.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nGoldRate.Text)), "0.00");}}`, `MS_RATE.cs:2310 {{SendKeys.Send("{TAB}");}}`); non-UAE silver recalculation ends at row 1 column 5 (`MS_RATE.cs:2362 {{MSG.Col = 5;}}`, `MS_RATE.cs:2363 {{MSG.Row = 1;}}`); visible USD inputs make silver Enter just Tab (`MS_RATE.cs:2323 {{if (((Control)nGoldOzRate).Visible)}}`, `MS_RATE.cs:2325 {{SendKeys.Send("{TAB}");}}`). F1 help opens `MS_RATE.cs:2381 {{((Form)MyProject.Forms.MS_HELP).ShowDialog();}}`, copies the chosen date (`MS_RATE.cs:2386 {{mVchDate.Text = DC_Main.ColValue[0];}}`) and refocuses date (`MS_RATE.cs:2388 {{((Control)mVchDate).Focus();}}`). Form KeyPress uppercases input (`MS_RATE.cs:2136 {{num = (short)Strings.Asc(Strings.UCase(Strings.Chr(unchecked((int)num))));}}`).
Status: executable

## T18 Full journey

### daily-rate.downstream.rate-lookup-own-location (T18 Full journey) [reuse]
Layer: browser
Steps: 1. Save a R22 rate at location 01. 2. Seed a later rate at another location with GR_RATE=11111. 3. Request the rate for that later day through the downstream lookup.
Expected: The lookup returns this location's 64031.00 dated the saved date, not 11111 from the other location; the display projection requires own location and exactly MsSysDate (`MS_RATE.cs:1950 {{AND A.LC_CODE = '}}`, `MS_RATE.cs:1950 {{Strings.Format((object)DC_Main.MsSysDate, "MM/dd/yyyy")}}`) and RtView is replaced from the saved-date query only when it has rows (`MS_RATE.cs:2003 {{if (DC_Main.Rshlp.Rows.Count > 0)}}`, `MS_RATE.cs:2005 {{DC_Main.RtView = new DataView(DC_Main.Rshlp);}}`).
Status: executable

### daily-rate.labels.system-date-display (T18 Full journey)
Layer: browser
Steps: 1. Seed eight RATE_DISPLAY=Y groups with distinct GR_RATE, GR_TAX_RATE and header rates; include one hidden group. 2. Open the main window. 3. Read Rate_1..Rate_7 (Gap 3).
Expected: The query joins RATE_MAST to GROUP_MAST by company/group with `MS_RATE.cs:1950 {{ON A.CO_CODE = B.CO_CODE AND A.GR_CODE = B.GR_CODE}}`, filters `MS_RATE.cs:1950 {{AND B.RATE_DISPLAY = 'Y' ORDER BY A.SR_NO}}`, and the first seven rows populate slots 0..6 (`MS_RATE.cs:1960 {{if (DC_Main.M == 0)}}` … `MS_RATE.cs:1990 {{if (DC_Main.M == 6)}}`). For R22 the label reads `Rate Gold 22K  -  64031.00` — GR_RATE, not GR_TAX_RATE 65952 or header gold 72000, formatted `MS_RATE.cs:1963 {{["GR_RATE"}}), "0.00")]`. Hidden groups are absent and row 8 has no slot.
Status: executable

### daily-rate.labels.empty-and-count-boundaries (T18 Full journey)
Layer: browser
Steps: 1. With 0 eligible rows open the main window. 2. Repeat with 1, 7 and 8 eligible rows. 3. Read every label slot.
Expected: With no rows, Rate_1 is exactly `MDI_FORM.cs:11422 {{Rate_1.Text = "ToDays Rate :";}}` and the rest hidden (`MDI_FORM.cs:6912 {{((Control)Rate_2).Visible = false;}}`); with 1/7/8 rows exactly min(n,7) labels are visible, each using `MDI_FORM.cs:11429 {{["GR_NAME"}}, (object)"  -  "), (object)Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["GR_RATE"]), "0.00")].`, and all seven slots obey the tab order `MDI_FORM.cs:6919 {{((Control)Rate_1).TabIndex = 1137;}}`.
Status: executable

### daily-rate.labels.no-fallback (T18 Full journey)
Layer: browser
Steps: 1. Absent own-day: no RATE_MAST for the session location on system date. 2. Only foreign location has rows. 3. Rows exist only on a past day and only on a future day. 4. Read labels each time (Gap 4).
Expected: The MDI projection requires own location and exactly MsSysDate (`MS_RATE.cs:1950 {{AND A.LC_CODE = '}}`, `MS_RATE.cs:1950 {{Strings.Format((object)DC_Main.MsSysDate, "MM/dd/yyyy")}}`), so all four scenarios return no rows and show the empty state `MS_RATE.cs:1956 {{MyProject.Forms.MDI_FORM.Rate_1.Text = "ToDays Rate :";}}` — no "latest available" or another-location fallback. Existing same-day serialization (`web/apps/api/src/modules/masters/dailyRate.ts:231–234`) is preserved and is distinct from this read path.
Status: executable

### daily-rate.labels.surplus-cleared (T18 Full journey)
Layer: browser
Steps: 1. Display seven labels. 2. Save a day whose projection has two rows. 3. Read all seven slots after refresh (decision 3).
Expected: The desktop refresh only sets populated labels visible and never clears the remaining ones (`MS_RATE.cs:1967 {{((Control)MyProject.Forms.MDI_FORM.Rate_2).Visible = true;}}`, `MS_RATE.cs:1995 {{DC_Main.M++;}}`), leaving stale Rate_3..Rate_7. The hosted form must clear every surplus slot so exactly two labels are visible and the others hidden/blank, with the empty wording `MS_RATE.cs:1956 {{MyProject.Forms.MDI_FORM.Rate_1.Text = "ToDays Rate :";}}` when appropriate.
Status: executable

### daily-rate.labels.refresh-after-save (T18 Full journey)
Layer: browser
Steps: 1. Establish today's labels with rate set A (R22=64031.00). 2. Save today with set B (R22=64920.00). 3. Read labels immediately, without waiting for the poll (Gap 5).
Expected: After the commit the labels show 64920.00 for R22 using `MS_RATE.cs:1963 {{["GR_RATE"}}), "0.00")]`, derived from `MS_RATE.cs:1920 {{dataRow["GR_RATE"] = Conversion.Val(MSG[DC_Main.i, 5]);}}` and the MsSysDate query `MS_RATE.cs:1950 {{Strings.Format((object)DC_Main.MsSysDate, "MM/dd/yyyy")}}`. A historical save is covered separately in `daily-rate.labels.historical-save-refresh`.
Status: executable

### daily-rate.transfer.external-scheme.pending (T18 Full journey)
Layer: browser
Steps: 1. Set MsAppSchem=Y and save. 2. Observe the external transfer and its downstream effects.
Expected: Save invokes it separately under the flag `MS_RATE.cs:1997 {{if (Operators.CompareString(DC_Main.MsAppSchem, "Y", false) == 0)}}` via `MS_RATE.cs:1999 {{AppSchemeTrfr();}}`, after labels and before the success message.
Status: blocked: "External app transfer and full UAE/date-helper parity are outside this residual packet" (study Scope). Exact question: what contract and downstream effects must AppSchemeTrfr satisfy in the hosted service, and which tables/outputs does it own? This is another work package; unblocks when that work package defines its contract.

---

## Coverage table

| Kind | Meaning | Cases | Blocked | N/A |
|---|---|---|---|---|
| T01 | Entry/defaults | 3 | 0 | 0 |
| T02 | Field route | 2 | 0 | 1 |
| T03 | Formula sequence | 3 | 0 | 0 |
| T04 | Lookup | 4 | 1 | 0 |
| T05 | Children | 2 | 0 | 0 |
| T06 | Required/invalid | 6 | 0 | 1 |
| T07 | Create | 2 | 0 | 0 |
| T08 | Reopen/no-op | 2 | 0 | 0 |
| T09 | Edit | 3 | 0 | 0 |
| T10 | Delete/cancel/reverse | 3 | 0 | 0 |
| T11 | Scope/rights | 3 | 0 | 0 |
| T12 | Concurrency | 2 | 0 | 0 |
| T13 | Retry/unknown | 2 | 0 | 0 |
| T14 | Rollback | 2 | 0 | 0 |
| T15 | Config/history | 9 | 0 | 0 |
| T16 | Report/output | 1 | 0 | 0 |
| T17 | Keyboard/usability | 3 | 0 | 0 |
| T18 | Full journey | 7 | 1 | 0 |
| **Total** | | **59** | **2** | **2** |

Every kind T01–T18 is either applied with at least one case or justified as N/A above; none is silently dropped.

Gap coverage: Gap 1 → `daily-rate.entry.location-00-session`, `daily-rate.create.group-rate-at-00`, `daily-rate.settings.pending`, `daily-rate.edit.backdated-group-update`; Gap 2 → `daily-rate.copy.gate-false-no-fanout`, `daily-rate.copy.destination-enumeration`, `daily-rate.copy.full-column-projection`, `daily-rate.copy.replaces-not-appends`, `daily-rate.copy.zero-source-deletion`, `daily-rate.copy.cross-year-collision`, `daily-rate.copy.overlapping-save-locks`, `daily-rate.copy.atomic-all-locations-rollback`; Gap 3 → `daily-rate.entry.mdi-labels-initial`, `daily-rate.labels.system-date-display`, `daily-rate.labels.empty-and-count-boundaries`, `daily-rate.labels.surplus-cleared`; Gap 4 → `daily-rate.labels.no-fallback`, `daily-rate.downstream.rate-lookup-own-location`; Gap 5 → `daily-rate.labels.historical-save-refresh`, `daily-rate.labels.refresh-after-save`; Gap 6 → `daily-rate.field-route.copied-optional-numeric-columns`, `daily-rate.branches.not-applicable`; Gap 7 → `daily-rate.write-set.full-footprint`, `daily-rate.settlement.not-applicable`.

## Test data

Smallest seed needed, described not as SQL:

- **Company/tenant fixtures.** Tenant `feature-e2e`, company `01` (non-UAE, LC `01`), an authorized location-00 session for a distinct login cache slot, and locations `02`, `98` for company `01` (one inactive) plus one location under another company/tenant as sentinels.
- **Groups.** Three groups with 3-character codes R18 (Gold 18K, type G, touch 75, tax 0, purchase touch 76), R22 (Gold 22K, G, 91.6, tax 3, purchase touch 92), RSV (Silver 925, S, 92.5, tax 3, purchase touch 90); one zero-touch group and one group with RATE_DISPLAY=N; for the labels case, eight RATE_DISPLAY=Y groups with distinct GR_RATE/GR_TAX_RATE/header rates and distinct SR_NO, one labelled `Rate Gold 22K`.
- **UAE fixture.** A separate company with short name `UAE` and nonblank Gold Purc, Silver Purc, Gold USD and Silver USD inputs so the optional columns and purchase override can be routed and copied.
- **Opening balances.** Prior GROUP_MAST.GR_RATE for all groups (so skipped/backdated non-reversal is observable) and prior destination-day rows for replacement and zero-source deletion.
- **Vouchers/prices.** Header Gold 72000 / Silver 85000 (R22→64031, RSV→763), alternative 73000 / 86000 (R22→64920), a historical date distinct from MsSysDate, a past date and a future date for fallback, and one saved day with all optional fields set for column projection.
- **Faults.** A before-INSERT trigger raising an error for one group at one date, and a copy destination configured to fail on insert at the second of three locations.
- **Rights.** A user with FRM_EDIT/DELETE/PRINT and FRM_VIEW=Y; a clerk with none; a user with FRM_EDIT≠Y on an existing day; copy setting on/off.
- **No real data.** All values are synthetic; tests run only on the isolated database started by `web/scripts/parity-test-env.mjs`.

## Not covered

- **External app transfer (AppSchemeTrfr / MsAppSchem).** Explicitly outside WP-33 per the study Scope; blocked case `daily-rate.transfer.external-scheme.pending` records the exact question.
- **Full shared date validation (DC_Main.SetDate / RongDate).** Outside the residuals; no `.orch/index/DC_Main.md`. Blocked case `daily-rate.lookup.invalid-date-validation` records the exact question.
- **Full UAE workflow execution.** Belongs to its own case scope (Gap 6); only the field route, copied optional numeric columns and purchase-rate formula are covered here.
- **General voucher rate fallback in `web/apps/api/src/modules/masters/rate.ts`.** Changing it is a separate scope decision (Gap 4); the new MDI projection is specified to return no rows instead, and the existing G238 same-day serialization is preserved, not redefined.
- **Report-template internals of RateRpt.** The study excludes them; only selection, title and displayed rates are specified.
- **Print/drilldown of the copy destination through its own session.** The study directs downstream copy tests to print/reopen the destination through its own session; that belongs to the destination's menu cases, not WP-33.
