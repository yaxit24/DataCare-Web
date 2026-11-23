# WP-33 frozen residual cases

This is the frozen contract for the study of Master → Daily Rate. It is test design, not execution evidence or desktop acceptance. The repository menu is Other → Daily Rate; dispatch opens MS_RATE: MDI_FORM.cs:8566 {{MS_RATE mS_RATE = new MS_RATE();}}

The current playbook T01–T18 meanings govern this document. Matching dailyRate.mjs IDs are retained even where that module uses older group numbers: create.desktop-rows moves T05→T07, reopen.f1-list T07→T04, and refusal.negative-rate-no-write T04→T06. settings.pending keeps its ID but is now executable; missing implementation or fixtures inside this menu are work to perform, not external blockers. “Executable” means a specified test can be implemented and run, not that it passes today. All browser mutations require before/after database evidence in addition to UI evidence. Use only synthetic data in the isolated test database.

## Architect decisions

Each decision is **architect, 2026-11-23, owner may override**, under the packet's standing desktop-first and hosted-safety rule.

- A1 — Copy remains restricted to the legacy eligible company entitlement, represented by explicit server-managed company configuration, default off. A privileged administrator may provision that entitlement; ordinary Daily Rate users cannot set it through requests. Do not enable it for every company or treat the registration literal as an authentication secret. Source location must still be 00. Enabling the entitlement authorizes the company-wide destination write; individual target login rights do not narrow the target set. Desktop gate: MS_RATE.cs:1937 {{if (Operators.CompareString(DC_Main.SSRegSrNo, "VK142NEVK", false) == 0 && Operators.CompareString(DC_Main.MLc_code, "00", false) == 0)}}
- A2 — Preserve stored CO_YEAR in the copy projection. For ordinary dates with one year, copy replaces the destination day. Cross-year collision business resolution remains blocked: “When the same company/date exists under more than one CO_YEAR at source or destination, should copy replace all years, isolate the active year, or refuse the operation?” The source omits a year predicate, but cannot settle the hosted destructive-collision policy. Do not silently ship cross-year overwrite; retain the blocked case until the owner or responsible policy package chooses. Desktop projection: MS_RATE.cs:1945 {{',CO_YEAR,VCH_DATE,SR_NO,GR_CODE,FINE_GL_RATE,FINE_SL_RATE, }}
- A3 — Mount today's group labels on the authenticated dashboard, the main-window equivalent. Keep the transaction ticker separate. Refresh on dashboard entry and after committed saves without waiting for the minute poll. Replace the entire visible label set; hide unused slots. After delete, invalidate the read projection too so users cannot mistake stale quotes for saved rates; this changes no persisted business value. Desktop placement and empty state: MDI_FORM.cs:6827 {{((Control)PanelImage).Controls.Add((Control)(object)Rate_1);}} MS_RATE.cs:1956 {{MyProject.Forms.MDI_FORM.Rate_1.Text = "ToDays Rate :";}}
- A4 — Enforce server tenant/company/location scope and current rights. Source replacement, group updates and all destination replacements form one transaction. Serialize intersecting write sets in deterministic order, including local destination saves/deletes; allow complete serial last-writer results or explicit conflicts, never a mixed result. Retry without an intervening edit replaces the same business set. These are hosted safety rules, not claimed desktop transaction guarantees. Desktop write boundaries: MS_RATE.cs:1928 {{((DbDataAdapter)(object)DC_Main.Da).Update(RsDetl);}} MS_RATE.cs:1946 {{DC_Main.ExeQuteDc(DC_Main.RsQry);}}
- A5 — Read company copy configuration at save inside the transaction; a setting changed before save governs that save. Use posted, validated grid values for group rates; do not secretly reprice from changed master defaults. Reject invalid references, non-finite/negative rates and unauthorized writes before any effects as hosted validation, not invented desktop messages. The actual value written by the desktop is: MS_RATE.cs:1920 {{dataRow["GR_RATE"] = Conversion.Val(MSG[DC_Main.i, 5]);}}
- A6 — MISSING: orchestration/bin/orch.mjs. Verify every literal quotation against its cited source lines with a local audit, but report the dispatcher checker as not run. MISSING: .orch/index/DC_Main.md. Do not infer shared date-helper behaviour; full date validation remains outside this residual contract.

## Common evidence and values

D = controlled system date 2026-11-23; H = 2026-11-22. Both use the configured fiscal year containing these dates. Use genuine authenticated company 01 sessions at locations 00, 01 and 02, with distinct login cache slots. Assert the server session scope before opening or saving; never simulate 00 by adding a location to the POST. Compare full affected-day row multisets, every GROUP_MAST column, and unrelated synthetic sentinels before/after. Before each case restore isolated fixtures; cases must not depend on execution order.

Vector A uses gold 72000 and silver 85000. R18 is Gold 18K (touch 75, tax 0, purchase touch 76): TaxRate = Rate10gm = 75×72000/100 = 54000; PrRate = 76×72000/100 = 54720. R22 is Gold 22K (91.6, 3, 92): TaxRate = 91.6×72000/100 = 65952; Rate10gm = round(65952/103×100) = round(64031.067961…) = 64031; PrRate = 92×72000/100 = 66240. RSV is Silver 925 (92.5, 3, 90): TaxRate = round(92.5×85000/10000) = round(786.25) = 786; Rate10gm = round(786/103×100) = round(763.106796…) = 763; PrRate = 90×85000/10000 = 765. All displayed results use two decimals. Desktop formulas: MS_RATE.cs:2340 {{mSG[DC_Main.M, 5] = Strings.Format((object)Math.Round(Conversion.Val(mSG[DC_Main.M, 3]) * Conversion.Val(nGoldRate.Text) / 100.0), "0.00");}} MS_RATE.cs:2341 {{mSG[DC_Main.M, 6] = Strings.Format((object)Math.Round(Conversion.Val(mSG[DC_Main.M, 3]) * Conversion.Val(nGoldRate.Text) / 100.0), "0.00");}} MS_RATE.cs:2344 {{mSG[DC_Main.M, 5] = Strings.Format((object)Math.Round(Conversion.Val(mSG[DC_Main.M, 6]) / (Conversion.Val(mSG[DC_Main.M, 4]) + 100.0) * 100.0, 0), "0.00");}} MS_RATE.cs:2346 {{mSG[DC_Main.M, 8] = Strings.Format((object)Math.Round(Conversion.Val(mSG[DC_Main.M, 7]) * Conversion.Val(nGoldRate.Text) / 100.0), "0.00");}} MS_RATE.cs:2352 {{mSG[DC_Main.M, 6] = Strings.Format((object)Math.Round(Conversion.Val(mSG[DC_Main.M, 3]) * Conversion.Val(nSilverRate.Text) / 10000.0), "0.00");}} MS_RATE.cs:2355 {{mSG[DC_Main.M, 5] = Strings.Format((object)Math.Round(Conversion.Val(mSG[DC_Main.M, 6]) / (Conversion.Val(mSG[DC_Main.M, 4]) + 100.0) * 100.0, 0), "0.00");}} MS_RATE.cs:2357 {{mSG[DC_Main.M, 8] = Strings.Format((object)Math.Round(Conversion.Val(mSG[DC_Main.M, 7]) * Conversion.Val(nSilverRate.Text) / 10000.0), "0.00");}}

Vector B uses gold 73000, silver 86000: R18 [TaxRate, Rate10gm, PrRate] = [54750,54750,55480]; R22 = [66868,64920,67160], since 66868/103×100 = 64920.388349…; RSV = [796,773,774], since round(795.5) = 796 and round(796/103×100) = 773. These use the same cited formulas. Original group GR_RATE values are R18=111, R22=222, RSV=333. Other group attributes must remain equal to their fixture values.

Projection P is the exact copy column list quoted below, with LC_CODE replaced by the destination. Compare every value, preserving NULL versus zero, numeric scale where the database supports it, and stored metadata. Do not substitute GR_TAX_RATE for GR_RATE or invent new ADD_USER/ADD_DATE values in copied columns. GR_NAME is not projected. Any hosted audit is separate from these business columns. MS_RATE.cs:1945 {{INSERT INTO RATE_MAST(CO_CODE,LC_CODE,CO_YEAR,VCH_DATE,SR_NO,GR_CODE,FINE_GL_RATE,FINE_SL_RATE,  GR_RATE,GR_TOUCH,GR_TYPE,EMP_CODE,CASH_AMT,MAIN_USER,ADD_USER,ADD_DATE,GR_PR_TOUCH,GR_PR_RATE,  FINE_GL_PR_RATE,FINE_SL_PR_RATE,DOLLAR_GL_RATE,DOLLAR_SL_RATE,AND_TRFR,GR_TAX_RATE,GR_TAX_PRC,OP_GL_RATE)}}

### daily-rate.entry.rate-master-grid   (T01 Entry/defaults)
Layer: browser
Steps: 1. Sign in at 00 through the real selector. 2. Open the Daily Rate menu with a fresh D. 3. Capture scope, heading, date, focus and grid.
Expected: Session location is 00; heading is “Rate Master”; date is D and focused. Header inputs are blank on clear. Rows are R18, R22, RSV in type/name order; zero-touch group Z00 is absent. Columns are Sr., GrCode, GrName, Touch, Tax%, Rate10gm, TaxRate, PrTouch, PrRate; GrType is hidden. (the desktop rule: MS_RATE.cs:1043 {{lblBook.Text = "Rate Master";}} MS_RATE.cs:1737 {{val.Text = "";}} MS_RATE.cs:1741 {{mVchDate.Text = Conversions.ToString(DC_Main.MsSysDate);}} MS_RATE.cs:1749 {{((Control)mVchDate).Focus();}} MS_RATE.cs:1781 {{AND GR_TOUCH <> 0 ORDER BY GR_TYPE,GR_NAME}} MS_RATE.cs:1402 {{mSG[9] = 0;}})
Gap: 1. This is an expected missing-behaviour/evidence assertion from the study, not a recorded failing run.
Status: executable

### daily-rate.entry.shortcut-rights   (T01 Entry/defaults)
Layer: browser
Steps: 1. Open using Ctrl+F1 with view rights. 2. Repeat with no view rights.
Expected: Authorized route opens Rate Master; refused route shows “You Have No Rights.....” and does not open an editable form. (the desktop rule: MDI_FORM.cs:14405 {{MS_RATE mS_RATE = new MS_RATE();}} MDI_FORM.cs:14395 {{AND FRM_VIEW = 'Y'}} MDI_FORM.cs:14400 {{Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);}})
Status: executable

### daily-rate.field.net-rate-route   (T02 Field route)
Layer: browser
Steps: 1. Price A at 00. 2. Change only R22 Rate10gm to 64032 and employee to synthetic E01. 3. Save, inspect request and all rows, reopen, view dashboard.
Expected: R22 GR_RATE and group GR_RATE are 64032; GR_TAX_RATE remains 65952; EMP_CODE is E01. Label is exactly “Rate Gold 22K  -  64032.00”. No recomputation to 64031 occurs. (the desktop rule: MS_RATE.cs:1920 {{dataRow["GR_RATE"] = Conversion.Val(MSG[DC_Main.i, 5]);}} MS_RATE.cs:1921 {{dataRow["GR_TAX_RATE"] = Conversion.Val(MSG[DC_Main.i, 6]);}} MS_RATE.cs:1925 {{dataRow["EMP_CODE"] = tEmpCode.Text;}} MS_RATE.cs:1932 {{UPDATE GROUP_MAST SET GR_RATE = }} MS_RATE.cs:1963 {{MyProject.Forms.MDI_FORM.Rate_1.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.M]["GR_NAME"], (object)"  -  "), (object)Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["GR_RATE"]), "0.00")));}})
Gap: 1, 3. This is an expected missing-behaviour/evidence assertion from the study, not a recorded failing run.
Status: executable

### daily-rate.field.copy-optional-projection   (T02 Field route)
Layer: database
Steps: 1. Provision a controlled source projection fixture with distinct optional values as defined in Test data. 2. Exercise the same copy operation used by save in the isolated database. 3. Compare P at 01 and 02.
Expected: Both destination copies preserve all 26 P columns exactly except LC_CODE, including the four distinct optional rates and NULL/zero variants. No conversion or recalculation occurs. This is database projection coverage, not UAE UI execution. (the desktop rule: MS_RATE.cs:1945 {{INSERT INTO RATE_MAST(CO_CODE,LC_CODE,CO_YEAR,VCH_DATE,SR_NO,GR_CODE,FINE_GL_RATE,FINE_SL_RATE,  GR_RATE,GR_TOUCH,GR_TYPE,EMP_CODE,CASH_AMT,MAIN_USER,ADD_USER,ADD_DATE,GR_PR_TOUCH,GR_PR_RATE,  FINE_GL_PR_RATE,FINE_SL_PR_RATE,DOLLAR_GL_RATE,DOLLAR_SL_RATE,AND_TRFR,GR_TAX_RATE,GR_TAX_PRC,OP_GL_RATE)}})
Gap: 2, 6. This is an expected missing-behaviour/evidence assertion from the study, not a recorded failing run.
Status: executable

### daily-rate.formula.enter-on-silver-recomputes   (T03 Formula sequence)
Layer: browser
Steps: 1. Enter A headers in an unsaved non-UAE form. 2. Press Silver Enter. 3. Record TaxRate, Rate10gm and PrRate. 4. Press Enter again unchanged.
Expected: Rows equal A: R18 [54000,54000,54720], R22 [65952,64031,66240], RSV [786,763,765]. Repeated unchanged headers leave those values unchanged; focus is row 1 Rate10gm. (the desktop rule: MS_RATE.cs:2338 {{if ((Conversion.Val(nGoldRate.Text) != 0.0) & (OldGoldRate != Conversion.Val(nGoldRate.Text)))}} MS_RATE.cs:2344 {{mSG[DC_Main.M, 5] = Strings.Format((object)Math.Round(Conversion.Val(mSG[DC_Main.M, 6]) / (Conversion.Val(mSG[DC_Main.M, 4]) + 100.0) * 100.0, 0), "0.00");}} MS_RATE.cs:2349 {{else if (Operators.CompareString(mSG[DC_Main.M, 9], "S", false) == 0 && ((Conversion.Val(nSilverRate.Text) != 0.0) & (OldSlRate != Conversion.Val(nSilverRate.Text))))}} MS_RATE.cs:2355 {{mSG[DC_Main.M, 5] = Strings.Format((object)Math.Round(Conversion.Val(mSG[DC_Main.M, 6]) / (Conversion.Val(mSG[DC_Main.M, 4]) + 100.0) * 100.0, 0), "0.00");}} MS_RATE.cs:2362 {{MSG.Col = 5;}} MS_RATE.cs:2363 {{MSG.Row = 1;}} MS_RATE.cs:2366 {{((Control)TEXT_ENTRY).Focus();}})
Status: executable

### daily-rate.reopen.f1-list   (T04 Lookup)
Layer: browser
Steps: 1. Save A at H and B at D. 2. Open F1 saved-date help. 3. Cancel without selection. 4. Reopen help and choose H, then D.
Expected: List is descending D then H with saved user/gold/silver; cancel leaves the current date unchanged. Selecting H gives gold 72000.00 and R22 64031; selecting D gives gold 73000.00 and R22 64920; selection returns focus to date. (the desktop rule: MS_RATE.cs:2373 {{GROUP BY VCH_DATE,MAIN_USER,FINE_GL_RATE,FINE_SL_RATE  ORDER BY VCH_DATE DESC}} MS_RATE.cs:2386 {{mVchDate.Text = DC_Main.ColValue[0];}} MS_RATE.cs:2388 {{((Control)mVchDate).Focus();}} MS_RATE.cs:1761 {{nGoldRate.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsDetl.Rows[0]["FINE_GL_RATE"]), "0.00");}})
Status: executable

### daily-rate.children.destination-ownership   (T05 Children)
Layer: browser
Steps: 1. Seed 01 with one old row and 02 with two different rows. 2. Save A at eligible 00. 3. Inspect each destination and unrelated day.
Expected: Each destination has exactly R18, R22, RSV, SR_NO 1,2,3 and its own LC_CODE. Old destination-only rows are gone; source remains at 00. The unrelated day is byte-for-byte unchanged. No append or cross-parent row movement occurs. (the desktop rule: MS_RATE.cs:1916 {{dataRow["SR_NO"] = DC_Main.i;}} MS_RATE.cs:1939 {{SELECT LC_CODE FROM LOCT_MAST}} MS_RATE.cs:1944 {{DELETE FROM RATE_MAST WHERE CO_CODE = '}} MS_RATE.cs:1945 {{INSERT INTO RATE_MAST(CO_CODE,LC_CODE,CO_YEAR,VCH_DATE,SR_NO,GR_CODE,FINE_GL_RATE,FINE_SL_RATE,  GR_RATE,GR_TOUCH,GR_TYPE,EMP_CODE,CASH_AMT,MAIN_USER,ADD_USER,ADD_DATE,GR_PR_TOUCH,GR_PR_RATE,  FINE_GL_PR_RATE,FINE_SL_PR_RATE,DOLLAR_GL_RATE,DOLLAR_SL_RATE,AND_TRFR,GR_TAX_RATE,GR_TAX_PRC,OP_GL_RATE)}})
Gap: 2. This is an expected missing-behaviour/evidence assertion from the study, not a recorded failing run.
Status: executable

### daily-rate.refusal.zero-touch-or-rate   (T06 Required/invalid)
Layer: browser
Steps: 1. Set R18 Touch to 0, R22 Rate10gm to 0 and keep RSV from A. 2. Save at 00. 3. Repeat with blank numeric entries for the first two rows.
Expected: Only RSV is stored and group RSV becomes 763; R18 and R22 groups remain 111 and 222. Zero or blank qualification does not create rows or zero out skipped groups. (the desktop rule: MS_RATE.cs:1904 {{if ((Conversion.Val(MSG[DC_Main.i, 3]) != 0.0) & (Conversion.Val(MSG[DC_Main.i, 5]) != 0.0))}} MS_RATE.cs:1930 {{if (Operators.CompareString(DC_Main.MLc_code, "00", false) == 0)}} MS_RATE.cs:1932 {{UPDATE GROUP_MAST SET GR_RATE = }})
Gap: 1, 7. This is an expected missing-behaviour/evidence assertion from the study, not a recorded failing run.
Status: executable

### daily-rate.refusal.negative-rate-no-write   (T06 Required/invalid)
Layer: browser
Steps: 1. Price A. 2. Set R18 Rate10gm to -5. 3. Save through UI and inspect all scopes.
Expected: Hosted A5 validation returns HTTP 400 and zero business writes; source/destinations/groups stay at their snapshots. No desktop negative-rate refusal text is asserted: its nonzero predicate alone does not reject negatives. (the desktop rule: MS_RATE.cs:1904 {{if ((Conversion.Val(MSG[DC_Main.i, 3]) != 0.0) & (Conversion.Val(MSG[DC_Main.i, 5]) != 0.0))}})
Status: executable

### daily-rate.refusal.invalid-payload   (T06 Required/invalid)
Layer: browser
Steps: 1. Submit non-finite and overflowing numeric values, an unknown group and an employee code longer than three characters as separate attempts. 2. Inspect source/groups/destinations.
Expected: Hosted A5 returns HTTP 400 for each malformed request and leaves all snapshots unchanged. Employee UI accepts at most three characters. Exact new web error wording is not a desktop claim. (the desktop rule: MS_RATE.cs:1199 {{((TextBoxBase)tEmpCode).MaxLength = 3;}} MS_RATE.cs:1917 {{dataRow["GR_CODE"] = MSG[DC_Main.i, 1];}} MS_RATE.cs:1925 {{dataRow["EMP_CODE"] = tEmpCode.Text;}})
Status: executable

### daily-rate.create.desktop-rows   (T07 Create)
Layer: browser
Steps: 1. Use a genuine 00 session with copy off. 2. Price A at D and save once. 3. Query all source columns and group fields.
Expected: Exactly three source rows have A values, SR_NO 1/2/3, CO_CODE 01, LC_CODE 00, current CO_YEAR, date D, EMP_CODE blank and MAIN_USER equal to the synthetic actor. Six header fields are [72000,85000,0,0,0,0]. Group GR_RATE becomes [54000,64031,763]; every other group field and destination row is unchanged. Success text is “Data Are Saved.”; ordinary mode clears and focuses date. (the desktop rule: MS_RATE.cs:1906 {{dataRow["CO_CODE"] = DC_Main.MCo_code;}} MS_RATE.cs:1907 {{dataRow["LC_CODE"] = DC_Main.MLc_code;}} MS_RATE.cs:1908 {{dataRow["CO_YEAR"] = DC_Main.MCo_year;}} MS_RATE.cs:1909 {{dataRow["VCH_DATE"] = mVchDate.Text;}} MS_RATE.cs:1910 {{dataRow["FINE_GL_RATE"] = Conversion.Val(nGoldRate.Text);}} MS_RATE.cs:1911 {{dataRow["FINE_SL_RATE"] = Conversion.Val(nSilverRate.Text);}} MS_RATE.cs:1912 {{dataRow["FINE_GL_PR_RATE"] = Conversion.Val(nPrGoldRate.Text);}} MS_RATE.cs:1913 {{dataRow["FINE_SL_PR_RATE"] = Conversion.Val(nPrSilverRate.Text);}} MS_RATE.cs:1914 {{dataRow["DOLLAR_GL_RATE"] = Conversion.Val(nGoldOzRate.Text);}} MS_RATE.cs:1915 {{dataRow["DOLLAR_SL_RATE"] = Conversion.Val(nSilverOzRate.Text);}} MS_RATE.cs:1916 {{dataRow["SR_NO"] = DC_Main.i;}} MS_RATE.cs:1925 {{dataRow["EMP_CODE"] = tEmpCode.Text;}} MS_RATE.cs:1926 {{dataRow["MAIN_USER"] = MainUser;}} MS_RATE.cs:1932 {{UPDATE GROUP_MAST SET GR_RATE = }} MS_RATE.cs:2007 {{Interaction.MsgBox((object)"Data Are Saved.", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);}} MS_RATE.cs:2015 {{CLEAR_DATA();}} MS_RATE.cs:1749 {{((Control)mVchDate).Focus();}})
Gap: 1, 7. This is an expected missing-behaviour/evidence assertion from the study, not a recorded failing run.
Status: executable

### daily-rate.copy.eligible-two-destinations   (T07 Create)
Layer: browser
Steps: 1. Provision A1 eligibility for company 01. 2. Sign in at 00 and save A. 3. Inspect 00, 01, 02 and sentinels.
Expected: Exactly three rows at each location, nine total; each destination equals source P with its location substituted. Groups equal [54000,64031,763]. Listed destinations are included even without an operator login there; unlisted 98, other tenant/company and H stay unchanged. No copy confirmation is required. (the desktop rule: MS_RATE.cs:1937 {{if (Operators.CompareString(DC_Main.SSRegSrNo, "VK142NEVK", false) == 0 && Operators.CompareString(DC_Main.MLc_code, "00", false) == 0)}} MS_RATE.cs:1939 {{SELECT LC_CODE FROM LOCT_MAST}} MS_RATE.cs:1945 {{INSERT INTO RATE_MAST(CO_CODE,LC_CODE,CO_YEAR,VCH_DATE,SR_NO,GR_CODE,FINE_GL_RATE,FINE_SL_RATE,  GR_RATE,GR_TOUCH,GR_TYPE,EMP_CODE,CASH_AMT,MAIN_USER,ADD_USER,ADD_DATE,GR_PR_TOUCH,GR_PR_RATE,  FINE_GL_PR_RATE,FINE_SL_PR_RATE,DOLLAR_GL_RATE,DOLLAR_SL_RATE,AND_TRFR,GR_TAX_RATE,GR_TAX_PRC,OP_GL_RATE)}} MS_RATE.cs:1946 {{DC_Main.ExeQuteDc(DC_Main.RsQry);}})
Gap: 2. This is an expected missing-behaviour/evidence assertion from the study, not a recorded failing run.
Status: executable

### daily-rate.copy.disabled-at-zero   (T07 Create)
Layer: browser
Steps: 1. Disable A1 eligibility. 2. Save A from real 00.
Expected: Source has three A rows and groups [54000,64031,763]; 01 and 02 retain their old row multisets. Eligibility false prevents fan-out, not the group update. (the desktop rule: MS_RATE.cs:1930 {{if (Operators.CompareString(DC_Main.MLc_code, "00", false) == 0)}} MS_RATE.cs:1937 {{if (Operators.CompareString(DC_Main.SSRegSrNo, "VK142NEVK", false) == 0 && Operators.CompareString(DC_Main.MLc_code, "00", false) == 0)}})
Gap: 2. This is an expected missing-behaviour/evidence assertion from the study, not a recorded failing run.
Status: executable

### daily-rate.copy.enabled-away-from-zero   (T07 Create)
Layer: browser
Steps: 1. Enable A1. 2. Save A from real 01.
Expected: 01 has three A rows; groups remain [111,222,333]; 00 and 02 remain at snapshots. Eligibility alone is insufficient. (the desktop rule: MS_RATE.cs:1930 {{if (Operators.CompareString(DC_Main.MLc_code, "00", false) == 0)}} MS_RATE.cs:1937 {{if (Operators.CompareString(DC_Main.SSRegSrNo, "VK142NEVK", false) == 0 && Operators.CompareString(DC_Main.MLc_code, "00", false) == 0)}})
Gap: 2. This is an expected missing-behaviour/evidence assertion from the study, not a recorded failing run.
Status: executable

### daily-rate.edit.unchanged-save   (T08 Reopen/no-op)
Layer: browser
Steps: 1. Save A with eligible 00. 2. Close/reopen that day. 3. Save unchanged.
Expected: Source and both targets each retain exactly three A rows and groups [54000,64031,763]. Business columns retain A; there is no duplicated day or altered rate. Separately record any hosted audit event, without asserting opaque row identities survive a replace-day operation. (the desktop rule: MS_RATE.cs:1756 {{AND LC_CODE = '}} MS_RATE.cs:1894 {{DELETE FROM RATE_MAST WHERE CO_CODE = '}} MS_RATE.cs:1928 {{((DbDataAdapter)(object)DC_Main.Da).Update(RsDetl);}} MS_RATE.cs:1945 {{INSERT INTO RATE_MAST(CO_CODE,LC_CODE,CO_YEAR,VCH_DATE,SR_NO,GR_CODE,FINE_GL_RATE,FINE_SL_RATE,  GR_RATE,GR_TOUCH,GR_TYPE,EMP_CODE,CASH_AMT,MAIN_USER,ADD_USER,ADD_DATE,GR_PR_TOUCH,GR_PR_RATE,  FINE_GL_PR_RATE,FINE_SL_PR_RATE,DOLLAR_GL_RATE,DOLLAR_SL_RATE,AND_TRFR,GR_TAX_RATE,GR_TAX_PRC,OP_GL_RATE)}})
Status: executable

### daily-rate.reopen.imported-projection   (T08 Reopen/no-op)
Layer: browser
Steps: 1. Provision the imported optional-value fixture. 2. Reopen it through the destination session without saving. 3. Compare the database before/after.
Expected: Stored P, NULL metadata, date, year and numeric values are unchanged by reading. Gold displays 72000.00 and the saved R22 Rate10gm is 64031. Imported no-op save of unsupported hidden fields is not certified by this read-only case. (the desktop rule: MS_RATE.cs:1756 {{AND LC_CODE = '}} MS_RATE.cs:1761 {{nGoldRate.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsDetl.Rows[0]["FINE_GL_RATE"]), "0.00");}} MS_RATE.cs:1802 {{dataView.RowFilter = "GR_CODE = '" + mSG[DC_Main.i + 1, 1] + "'";}})
Status: executable

### daily-rate.edit.unpriced-group-skipped   (T09 Edit)
Layer: browser
Steps: 1. Save A with eligible 00. 2. Reopen and blank R18 Rate10gm; set R22 to 64032. 3. Save and reopen all locations.
Expected: Each location now has R22=64032 and RSV=763 only; no R18 row remains. Group R18 stays 54000 from the first save, R22 becomes 64032 and RSV remains 763. Other group columns are unchanged. (the desktop rule: MS_RATE.cs:1894 {{DELETE FROM RATE_MAST WHERE CO_CODE = '}} MS_RATE.cs:1904 {{if ((Conversion.Val(MSG[DC_Main.i, 3]) != 0.0) & (Conversion.Val(MSG[DC_Main.i, 5]) != 0.0))}} MS_RATE.cs:1932 {{UPDATE GROUP_MAST SET GR_RATE = }} MS_RATE.cs:1944 {{DELETE FROM RATE_MAST WHERE CO_CODE = '}})
Gap: 1, 2. This is an expected missing-behaviour/evidence assertion from the study, not a recorded failing run.
Status: executable

### daily-rate.edit.all-unpriced-clears-copies   (T09 Edit)
Layer: browser
Steps: 1. Save A with eligible 00. 2. Set all Rate10gm cells to zero and save.
Expected: Source, 01 and 02 each have zero rows for D. Group rates remain [54000,64031,763]; zero-row save does not reverse them. Unrelated days/scopes remain intact. (the desktop rule: MS_RATE.cs:1894 {{DELETE FROM RATE_MAST WHERE CO_CODE = '}} MS_RATE.cs:1904 {{if ((Conversion.Val(MSG[DC_Main.i, 3]) != 0.0) & (Conversion.Val(MSG[DC_Main.i, 5]) != 0.0))}} MS_RATE.cs:1944 {{DELETE FROM RATE_MAST WHERE CO_CODE = '}} MS_RATE.cs:1945 {{AND LC_CODE = '00' AND VCH_DATE = '}})
Gap: 1, 2. This is an expected missing-behaviour/evidence assertion from the study, not a recorded failing run.
Status: executable

### daily-rate.delete.day   (T10 Delete/cancel/reverse)
Layer: browser
Steps: 1. Save A at eligible 00. 2. Click Delete and answer No. 3. Repeat and answer Yes.
Expected: Prompt is exactly “Are You Sure To Delete This Day Rate?”. No keeps all rows. Yes removes only 00 day rows, leaves target A rows and group rates [54000,64031,763], clears the form and focuses date. A3 refresh clears current-day dashboard labels without reversing group/copy business effects. (the desktop rule: MS_RATE.cs:2104 {{else if ((int)Interaction.MsgBox((object)"Are You Sure To Delete This Day Rate?", (MsgBoxStyle)4, (object)DC_Main.MsgTitle) == 6)}} MS_RATE.cs:2106 {{DELETE FROM RATE_MAST WHERE CO_CODE = '}} MS_RATE.cs:2107 {{CLEAR_DATA();}} MS_RATE.cs:1749 {{((Control)mVchDate).Focus();}})
Gap: 1, 5. This is an expected missing-behaviour/evidence assertion from the study, not a recorded failing run.
Status: executable

### daily-rate.cancel.no-reversal   (T10 Delete/cancel/reverse)
Layer: browser
Steps: 1. Save A at eligible 00. 2. Enter B without saving. 3. Cancel; then repeat unsaved edits and Exit.
Expected: All three locations retain A and group rates [54000,64031,763]. Cancel clears and returns focus to date; Exit closes. No B rows or group changes exist. (the desktop rule: MS_RATE.cs:2118 {{CLEAR_DATA();}} MS_RATE.cs:2113 {{((Form)this).Close();}} MS_RATE.cs:1749 {{((Control)mVchDate).Focus();}})
Gap: 1. This is an expected missing-behaviour/evidence assertion from the study, not a recorded failing run.
Status: executable

### daily-rate.scope.no-rights-user   (T11 Scope/rights)
Layer: browser
Steps: 1. Create A as admin. 2. Use a session without view/edit/delete/print rights and call the read/save/delete/print endpoints directly. 3. Repeat save on a previously empty day.
Expected: Hosted rights return 403 on all four and on new-day save; there are zero writes or leaked rows. UI save/delete denial text is “You Have No Rights.....”; print denial is “You Have No Print Rights.....”. (the desktop rule: MS_RATE.cs:1830 {{EntryMode = "E";}} MS_RATE.cs:1886 {{if ((Operators.CompareString(UserEdit, "Y", false) != 0) & (Operators.CompareString(EntryMode, "E", false) == 0))}} MS_RATE.cs:1888 {{Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);}} MS_RATE.cs:2102 {{Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);}} MS_RATE.cs:1839 {{Interaction.MsgBox((object)"You Have No Print Rights.....", (MsgBoxStyle)0, (object)null);}} MDI_FORM.cs:14395 {{AND FRM_VIEW = 'Y'}})
Status: executable

### daily-rate.scope.copy-entitlement-forgery   (T11 Scope/rights)
Layer: browser
Steps: 1. Use an ordinary 01 session and forge tenant/company/location/eligibility fields in save/config requests. 2. Repeat with revoked rights before saving from 00.
Expected: Forged authority never enables copying or reaches another scope; requests attempting authority changes are refused. Revoked edit rights return 403. No target/group changes occur. A1 authorization is server-managed, not a client registration bypass. (the desktop rule: MS_RATE.cs:1906 {{dataRow["CO_CODE"] = DC_Main.MCo_code;}} MS_RATE.cs:1907 {{dataRow["LC_CODE"] = DC_Main.MLc_code;}} MS_RATE.cs:1937 {{if (Operators.CompareString(DC_Main.SSRegSrNo, "VK142NEVK", false) == 0 && Operators.CompareString(DC_Main.MLc_code, "00", false) == 0)}} MS_RATE.cs:1565 {{UserEdit = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["FRM_EDIT"], (object)""));}})
Gap: 2. This is an expected missing-behaviour/evidence assertion from the study, not a recorded failing run.
Status: executable

### daily-rate.concurrency.two-operators-same-day   (T12 Concurrency)
Layer: browser
Steps: 1. Two genuine 00 sessions load D. 2. Price A and B respectively. 3. Race eligible saves and inspect all rows/groups.
Expected: A serial winner yields exactly three rows per location, all A or all B, never a mixture. Group rates equal the winner: [54000,64031,763] or [54750,64920,773]. At least one request succeeds; another may be an explicit conflict. This atomic result is A4 hosted safety. (the desktop rule: MS_RATE.cs:1894 {{DELETE FROM RATE_MAST WHERE CO_CODE = '}} MS_RATE.cs:1932 {{UPDATE GROUP_MAST SET GR_RATE = }} MS_RATE.cs:1946 {{DC_Main.ExeQuteDc(DC_Main.RsQry);}})
Gap: 2, 4. This is an expected missing-behaviour/evidence assertion from the study, not a recorded failing run.
Status: executable

### daily-rate.concurrency.copy-versus-local-save   (T12 Concurrency)
Layer: browser
Steps: 1. Race eligible 00 save A with direct 01 save B. 2. Repeat with 01 delete.
Expected: For local save: 00/02 are A; 01 is all A if copy commits last, all B if local save commits last. Groups are A. For delete: 01 is either zero rows or all A according to commit order. No partial day or duplicate group exists; explicit conflicts are allowed under A4. (the desktop rule: MS_RATE.cs:1937 {{if (Operators.CompareString(DC_Main.SSRegSrNo, "VK142NEVK", false) == 0 && Operators.CompareString(DC_Main.MLc_code, "00", false) == 0)}} MS_RATE.cs:1944 {{DELETE FROM RATE_MAST WHERE CO_CODE = '}} MS_RATE.cs:1946 {{DC_Main.ExeQuteDc(DC_Main.RsQry);}} MS_RATE.cs:2106 {{DELETE FROM RATE_MAST WHERE CO_CODE = '}})
Gap: 2, 4. This is an expected missing-behaviour/evidence assertion from the study, not a recorded failing run.
Status: executable

### daily-rate.retry.replayed-save   (T13 Retry/unknown)
Layer: browser
Steps: 1. Save A at eligible 00 and lose acknowledgment after commit. 2. Reconnect, reread D and replay identical save with no intervening edit.
Expected: Read recovers A; after replay all locations still contain exactly three A rows and groups [54000,64031,763]. No append or duplicate financial effect occurs. Hosted audit records may distinguish attempts. (the desktop rule: MS_RATE.cs:1894 {{DELETE FROM RATE_MAST WHERE CO_CODE = '}} MS_RATE.cs:1944 {{DELETE FROM RATE_MAST WHERE CO_CODE = '}} MS_RATE.cs:1945 {{INSERT INTO RATE_MAST(CO_CODE,LC_CODE,CO_YEAR,VCH_DATE,SR_NO,GR_CODE,FINE_GL_RATE,FINE_SL_RATE,  GR_RATE,GR_TOUCH,GR_TYPE,EMP_CODE,CASH_AMT,MAIN_USER,ADD_USER,ADD_DATE,GR_PR_TOUCH,GR_PR_RATE,  FINE_GL_PR_RATE,FINE_SL_PR_RATE,DOLLAR_GL_RATE,DOLLAR_SL_RATE,AND_TRFR,GR_TAX_RATE,GR_TAX_PRC,OP_GL_RATE)}})
Gap: 2. This is an expected missing-behaviour/evidence assertion from the study, not a recorded failing run.
Status: executable

### daily-rate.rollback.rate-write-fault   (T14 Rollback)
Layer: browser
Steps: 1. Establish A at eligible 00. 2. Attempt B with an isolated test fault after source deletion, after a source insert, then after a group update in separate runs.
Expected: Each failed request leaves the entire source/destination/group snapshot equal to A, including sentinels. No success message or B label appears. A4 deliberately makes all write families atomic. (the desktop rule: MS_RATE.cs:1895 {{DC_Main.ExeQuteDc(DC_Main.RsQry);}} MS_RATE.cs:1928 {{((DbDataAdapter)(object)DC_Main.Da).Update(RsDetl);}} MS_RATE.cs:1932 {{UPDATE GROUP_MAST SET GR_RATE = }})
Gap: 1, 2. This is an expected missing-behaviour/evidence assertion from the study, not a recorded failing run.
Status: executable

### daily-rate.rollback.last-destination-fault   (T14 Rollback)
Layer: browser
Steps: 1. Establish A. 2. Attempt B with faults after 01 replacement, after 02 deletion, after 02 insertion, and immediately before commit, as separate runs.
Expected: All four attempts fail with zero durable changes: each location keeps three A rows and all group values remain A. UI retains the last committed A labels. No partial target copy survives. (the desktop rule: MS_RATE.cs:1944 {{DELETE FROM RATE_MAST WHERE CO_CODE = '}} MS_RATE.cs:1946 {{DC_Main.ExeQuteDc(DC_Main.RsQry);}} MS_RATE.cs:2024 {{Interaction.MsgBox((object)("Error Found: " + Information.Err().Description + "\rClick Ok to Exit."), (MsgBoxStyle)48, (object)DC_Main.MsgTitle);}})
Gap: 2. This is an expected missing-behaviour/evidence assertion from the study, not a recorded failing run.
Status: executable

### daily-rate.settings.pending   (T15 Config/history)
Layer: browser
Steps: 1. Sign in at 00 via UI using its own login slot and assert session scope. 2. Save A at D. 3. Save B at H, then reopen D.
Expected: Group rates are [54750,64920,773] after the backdated save; D rows remain A. Today labels remain A. This replaces the misleading claim of HTTP/browser evidence with real required browser and complete write-set proof. (the desktop rule: MS_RATE.cs:1907 {{dataRow["LC_CODE"] = DC_Main.MLc_code;}} MS_RATE.cs:1930 {{if (Operators.CompareString(DC_Main.MLc_code, "00", false) == 0)}} MS_RATE.cs:1932 {{UPDATE GROUP_MAST SET GR_RATE = }} MS_RATE.cs:1950 {{Strings.Format((object)DC_Main.MsSysDate, "MM/dd/yyyy")}})
Gap: 1. This is an expected missing-behaviour/evidence assertion from the study, not a recorded failing run.
Status: executable

### daily-rate.settings.changed-before-save   (T15 Config/history)
Layer: browser
Steps: 1. Load A with eligibility on, disable it using authorized configuration before save, then save. 2. Restore; load with it off, enable before save, then save. 3. In a separate run change master touch after preview without altering submitted grid.
Expected: A5 uses committed configuration at save: first attempt changes source/groups only; second copies A to 01/02. A posted R22 rate of 64031 remains 64031 despite a changed master default; group touch is not overwritten by saving its rate. (the desktop rule: MS_RATE.cs:1937 {{if (Operators.CompareString(DC_Main.SSRegSrNo, "VK142NEVK", false) == 0 && Operators.CompareString(DC_Main.MLc_code, "00", false) == 0)}} MS_RATE.cs:1920 {{dataRow["GR_RATE"] = Conversion.Val(MSG[DC_Main.i, 5]);}} MS_RATE.cs:1932 {{UPDATE GROUP_MAST SET GR_RATE = }})
Gap: 2. This is an expected missing-behaviour/evidence assertion from the study, not a recorded failing run.
Status: executable

### daily-rate.copy.cross-year-collision   (T15 Config/history)
Layer: database
Steps: 1. Seed company/date D under two distinct CO_YEAR values at 00 and a destination. 2. Attempt the eligible copy after an external policy decision supplies the expected result.
Expected: Pending decision must select an exact resulting row multiset; until then this case cannot claim either deletion or preservation across years as accepted hosted behaviour. Preserve this case in the coverage denominator. (the desktop rule: MS_RATE.cs:1945 {{',CO_YEAR,VCH_DATE,SR_NO,GR_CODE,FINE_GL_RATE,FINE_SL_RATE, }})
Gap: 2. This is an expected missing-behaviour/evidence assertion from the study, not a recorded failing run.
Status: blocked: external owner/policy decision required — when company/date collides across CO_YEAR, replace all years, isolate active year, or refuse? Unblocks when that choice and exact expected footprint are recorded.

### daily-rate.print.rate-report   (T16 Report/output)
Layer: browser
Steps: 1. Save A at eligible 00. 2. Open destination 01 through its own session and print D. 3. Repeat after the dropped-group edit.
Expected: Report title is “Daily Rate Report 23/11/2026”; dataset contains only 01/D rows: initially R18=54000, R22=64031, RSV=763, then only R22=64032 and RSV=763. No 00/H/foreign rows appear. Template internals and physical print layout remain outside this packet. (the desktop rule: MS_RATE.cs:1843 {{string rptName = "RateRpt";}} MS_RATE.cs:1845 {{DC_Main.MsRptTitelStr = "'Daily Rate Report " + Strings.Format((object)Conversions.ToDate(mVchDate.Text), "dd/MM/yyyy") + "'";}} MS_RATE.cs:1846 {{DC_Main.MsWappPrintType = "All";}} MS_RATE.cs:1848 {{{RATE_MAST.LC_CODE} = '}})
Gap: 2. This is an expected missing-behaviour/evidence assertion from the study, not a recorded failing run.
Status: executable

### daily-rate.labels.0-eligible   (T16 Report/output)
Layer: browser
Steps: 1. Seed D with 0 eligible display rows using the display fixture. 2. Include a RATE_DISPLAY=N row ahead of them and different header/tax values. 3. Enter dashboard.
Expected: Only “ToDays Rate :” is visible; there are no group-value labels. (the desktop rule: MDI_FORM.cs:11416 {{AND B.RATE_DISPLAY = 'Y' ORDER BY A.SR_NO}} MDI_FORM.cs:11422 {{Rate_1.Text = "ToDays Rate :";}} MDI_FORM.cs:11429 {{Rate_1.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.M]["GR_NAME"], (object)"  -  "), (object)Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["GR_RATE"]), "0.00")));}} MS_RATE.cs:1990 {{if (DC_Main.M == 6)}})
Gap: 3. This is an expected missing-behaviour/evidence assertion from the study, not a recorded failing run.
Status: executable

### daily-rate.labels.1-eligible   (T16 Report/output)
Layer: browser
Steps: 1. Seed D with 1 eligible display rows using the display fixture. 2. Include a RATE_DISPLAY=N row ahead of them and different header/tax values. 3. Enter dashboard.
Expected: Visible labels in order are “Display 1  -  101.00”. All texts use net GR_RATE and exactly two spaces on each side of the hyphen. (the desktop rule: MDI_FORM.cs:11416 {{AND B.RATE_DISPLAY = 'Y' ORDER BY A.SR_NO}} MDI_FORM.cs:11422 {{Rate_1.Text = "ToDays Rate :";}} MDI_FORM.cs:11429 {{Rate_1.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.M]["GR_NAME"], (object)"  -  "), (object)Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["GR_RATE"]), "0.00")));}} MS_RATE.cs:1990 {{if (DC_Main.M == 6)}})
Gap: 3. This is an expected missing-behaviour/evidence assertion from the study, not a recorded failing run.
Status: executable

### daily-rate.labels.7-eligible   (T16 Report/output)
Layer: browser
Steps: 1. Seed D with 7 eligible display rows using the display fixture. 2. Include a RATE_DISPLAY=N row ahead of them and different header/tax values. 3. Enter dashboard.
Expected: Visible labels in order are “Display 1  -  101.00”, “Display 2  -  102.00”, “Display 3  -  103.00”, “Display 4  -  104.00”, “Display 5  -  105.00”, “Display 6  -  106.00”, “Display 7  -  107.00”. All texts use net GR_RATE and exactly two spaces on each side of the hyphen. (the desktop rule: MDI_FORM.cs:11416 {{AND B.RATE_DISPLAY = 'Y' ORDER BY A.SR_NO}} MDI_FORM.cs:11422 {{Rate_1.Text = "ToDays Rate :";}} MDI_FORM.cs:11429 {{Rate_1.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.M]["GR_NAME"], (object)"  -  "), (object)Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["GR_RATE"]), "0.00")));}} MS_RATE.cs:1990 {{if (DC_Main.M == 6)}})
Gap: 3. This is an expected missing-behaviour/evidence assertion from the study, not a recorded failing run.
Status: executable

### daily-rate.labels.8-eligible   (T16 Report/output)
Layer: browser
Steps: 1. Seed D with 8 eligible display rows using the display fixture. 2. Include a RATE_DISPLAY=N row ahead of them and different header/tax values. 3. Enter dashboard.
Expected: Visible labels in order are “Display 1  -  101.00”, “Display 2  -  102.00”, “Display 3  -  103.00”, “Display 4  -  104.00”, “Display 5  -  105.00”, “Display 6  -  106.00”, “Display 7  -  107.00”. Display 8 is absent; the limit is seven. All texts use net GR_RATE and exactly two spaces on each side of the hyphen. (the desktop rule: MDI_FORM.cs:11416 {{AND B.RATE_DISPLAY = 'Y' ORDER BY A.SR_NO}} MDI_FORM.cs:11422 {{Rate_1.Text = "ToDays Rate :";}} MDI_FORM.cs:11429 {{Rate_1.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.M]["GR_NAME"], (object)"  -  "), (object)Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["GR_RATE"]), "0.00")));}} MS_RATE.cs:1990 {{if (DC_Main.M == 6)}})
Gap: 3. This is an expected missing-behaviour/evidence assertion from the study, not a recorded failing run.
Status: executable

### daily-rate.labels.no-fallback-foreign-location   (T16 Report/output)
Layer: browser
Steps: 1. Clear own-location D rows and seed today rows only at 02. 2. Enter dashboard as 01 and inspect the display response.
Expected: Projection is empty and only “ToDays Rate :” is shown. No rate from another location, past date or future date is substituted. Sentinels are unread and unchanged. (the desktop rule: MS_RATE.cs:1950 {{AND A.LC_CODE = '}} MS_RATE.cs:1950 {{Strings.Format((object)DC_Main.MsSysDate, "MM/dd/yyyy")}} MS_RATE.cs:1956 {{MyProject.Forms.MDI_FORM.Rate_1.Text = "ToDays Rate :";}})
Gap: 3, 4 (G238). This is an expected missing-behaviour/evidence assertion from the study, not a recorded failing run.
Status: executable

### daily-rate.labels.no-fallback-past-day   (T16 Report/output)
Layer: browser
Steps: 1. Clear own-location D rows and seed own-location rows only at H. 2. Enter dashboard as 01 and inspect the display response.
Expected: Projection is empty and only “ToDays Rate :” is shown. No rate from another location, past date or future date is substituted. Sentinels are unread and unchanged. (the desktop rule: MS_RATE.cs:1950 {{AND A.LC_CODE = '}} MS_RATE.cs:1950 {{Strings.Format((object)DC_Main.MsSysDate, "MM/dd/yyyy")}} MS_RATE.cs:1956 {{MyProject.Forms.MDI_FORM.Rate_1.Text = "ToDays Rate :";}})
Gap: 3, 4 (G238). This is an expected missing-behaviour/evidence assertion from the study, not a recorded failing run.
Status: executable

### daily-rate.labels.no-fallback-future-day   (T16 Report/output)
Layer: browser
Steps: 1. Clear own-location D rows and seed own-location rows only at 2026-11-24. 2. Enter dashboard as 01 and inspect the display response.
Expected: Projection is empty and only “ToDays Rate :” is shown. No rate from another location, past date or future date is substituted. Sentinels are unread and unchanged. (the desktop rule: MS_RATE.cs:1950 {{AND A.LC_CODE = '}} MS_RATE.cs:1950 {{Strings.Format((object)DC_Main.MsSysDate, "MM/dd/yyyy")}} MS_RATE.cs:1956 {{MyProject.Forms.MDI_FORM.Rate_1.Text = "ToDays Rate :";}})
Gap: 3, 4 (G238). This is an expected missing-behaviour/evidence assertion from the study, not a recorded failing run.
Status: executable

### daily-rate.labels.no-fallback-absent-own-day   (T16 Report/output)
Layer: browser
Steps: 1. Clear own-location D rows and seed own-location H rows plus foreign-location D rows. 2. Enter dashboard as 01 and inspect the display response.
Expected: Projection is empty and only “ToDays Rate :” is shown. No rate from another location, past date or future date is substituted. Sentinels are unread and unchanged. (the desktop rule: MS_RATE.cs:1950 {{AND A.LC_CODE = '}} MS_RATE.cs:1950 {{Strings.Format((object)DC_Main.MsSysDate, "MM/dd/yyyy")}} MS_RATE.cs:1956 {{MyProject.Forms.MDI_FORM.Rate_1.Text = "ToDays Rate :";}})
Gap: 3, 4 (G238). This is an expected missing-behaviour/evidence assertion from the study, not a recorded failing run.
Status: executable

### daily-rate.labels.refresh-today   (T16 Report/output)
Layer: browser
Steps: 1. Display A at D. 2. Save B at D. 3. Inspect dashboard as soon as save finishes, before the 60-second ticker poll.
Expected: Labels immediately show “Rate Gold 18K  -  54750.00”, “Rate Gold 22K  -  64920.00”, “Rate Silver 925  -  773.00”. No stale A or header rates remain. (the desktop rule: MS_RATE.cs:1950 {{Strings.Format((object)DC_Main.MsSysDate, "MM/dd/yyyy")}} MS_RATE.cs:1963 {{MyProject.Forms.MDI_FORM.Rate_1.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.M]["GR_NAME"], (object)"  -  "), (object)Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["GR_RATE"]), "0.00")));}})
Gap: 3, 5. This is an expected missing-behaviour/evidence assertion from the study, not a recorded failing run.
Status: executable

### daily-rate.labels.refresh-historical   (T16 Report/output)
Layer: browser
Steps: 1. Keep A rows at D. 2. Save B at H. 3. Inspect refreshed display and GROUP_MAST.
Expected: Today labels remain “Rate Gold 18K  -  54000.00”, “Rate Gold 22K  -  64031.00”, “Rate Silver 925  -  763.00”, while group rates become [54750,64920,773]. Display is based on D RATE_MAST, not H or GROUP_MAST.GR_RATE. (the desktop rule: MS_RATE.cs:1950 {{Strings.Format((object)DC_Main.MsSysDate, "MM/dd/yyyy")}} MS_RATE.cs:1963 {{MyProject.Forms.MDI_FORM.Rate_1.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.M]["GR_NAME"], (object)"  -  "), (object)Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["GR_RATE"]), "0.00")));}} MS_RATE.cs:1932 {{UPDATE GROUP_MAST SET GR_RATE = }})
Gap: 1, 5. This is an expected missing-behaviour/evidence assertion from the study, not a recorded failing run.
Status: executable

### daily-rate.labels.shrink-clears-surplus   (T16 Report/output)
Layer: browser
Steps: 1. Display seven eligible rows. 2. Replace D with only Display 1, then zero eligible rows. 3. Refresh via committed save each time.
Expected: After shrink there is only “Display 1  -  101.00”; after empty there is only “ToDays Rate :”. Slots 2–7 are hidden in both results. A3 removes stale-label weakness, rather than preserving one-sided visibility updates. (the desktop rule: MS_RATE.cs:1956 {{MyProject.Forms.MDI_FORM.Rate_1.Text = "ToDays Rate :";}} MS_RATE.cs:1967 {{((Control)MyProject.Forms.MDI_FORM.Rate_2).Visible = true;}})
Gap: 3, 5. This is an expected missing-behaviour/evidence assertion from the study, not a recorded failing run.
Status: executable

### daily-rate.keyboard.alt-s-saves   (T17 Keyboard/usability)
Layer: browser
Steps: 1. Enter A using keyboard in an eligible 00 session. 2. Press Alt+S. 3. Inspect source/group/target rows.
Expected: Alt+S performs one save: three A rows at each location and groups [54000,64031,763], with “Data Are Saved.”. Ordinary mode returns date focus. (the desktop rule: MS_RATE.cs:1124 {{BtnSave.Text = "&Save";}} MS_RATE.cs:2007 {{Interaction.MsgBox((object)"Data Are Saved.", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);}} MS_RATE.cs:2015 {{CLEAR_DATA();}} MS_RATE.cs:1749 {{((Control)mVchDate).Focus();}})
Status: executable

### daily-rate.keyboard.grid-and-escape   (T17 Keyboard/usability)
Layer: browser
Steps: 1. Enter gold 72000 and press Enter, then enter silver 85000 and press Enter. 2. Use arrows and Enter through the grid. 3. Escape while editing, then Escape outside the editor.
Expected: Gold becomes 72000.00; Silver Enter enters row 1 Rate10gm. Enter in Rate10gm/PrRate advances to next row Rate10gm, or Save at last row. Escape from editor commits the cell, hides editor and focuses Save; subsequent Escape closes the form. No save occurs until explicitly invoked. (the desktop rule: MS_RATE.cs:2309 {{nGoldRate.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nGoldRate.Text)), "0.00");}} MS_RATE.cs:2310 {{SendKeys.Send("{TAB}");}} MS_RATE.cs:2362 {{MSG.Col = 5;}} MS_RATE.cs:2363 {{MSG.Row = 1;}} MS_RATE.cs:2244 {{if (col == 5 || col == 8)}} MS_RATE.cs:2248 {{((Control)BtnSave).Focus();}} MS_RATE.cs:2251 {{mSG.Row += 1;}} MS_RATE.cs:2252 {{mSG.Col = 5;}} MS_RATE.cs:2153 {{MSG_LeaveCell(MSG, new EventArgs());}} MS_RATE.cs:2156 {{((Control)TEXT_ENTRY).Visible = false;}} MS_RATE.cs:2157 {{((Control)BtnSave).Focus();}} MS_RATE.cs:2161 {{((Form)this).Close();}})
Status: executable

### daily-rate.downstream.copy-reopen-display   (T18 Full journey)
Layer: browser
Steps: 1. Save A at eligible 00. 2. Sign into 01 and 02 independently. 3. Reopen D, print and enter each dashboard. 4. Edit 00 R22 to 64032 and repeat.
Expected: Both destinations reopen A, report A and display R22 “Rate Gold 22K  -  64031.00”; after source edit both reopen/report/display 64032. Source group R22 equals 64032; foreign scopes stay unchanged. This journey covers the residual chain, not a sale posting or external app transfer. (the desktop rule: MS_RATE.cs:1756 {{AND LC_CODE = '}} MS_RATE.cs:1945 {{INSERT INTO RATE_MAST(CO_CODE,LC_CODE,CO_YEAR,VCH_DATE,SR_NO,GR_CODE,FINE_GL_RATE,FINE_SL_RATE,  GR_RATE,GR_TOUCH,GR_TYPE,EMP_CODE,CASH_AMT,MAIN_USER,ADD_USER,ADD_DATE,GR_PR_TOUCH,GR_PR_RATE,  FINE_GL_PR_RATE,FINE_SL_PR_RATE,DOLLAR_GL_RATE,DOLLAR_SL_RATE,AND_TRFR,GR_TAX_RATE,GR_TAX_PRC,OP_GL_RATE)}} MS_RATE.cs:1848 {{{RATE_MAST.LC_CODE} = '}} MS_RATE.cs:1963 {{MyProject.Forms.MDI_FORM.Rate_1.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.M]["GR_NAME"], (object)"  -  "), (object)Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["GR_RATE"]), "0.00")));}})
Gap: 1, 2, 3, 5. This is an expected missing-behaviour/evidence assertion from the study, not a recorded failing run.
Status: executable

## Retained subcase exclusions

### daily-rate.branches.not-applicable   (T02 Field route)
Layer: browser
Steps: 1. Record that this packet's interactive fixture is non-UAE.
Expected: Full UAE optional-input recalculation is excluded from this residual packet; copied optional values remain required in field.copy-optional-projection. No unit test counts as UAE browser coverage. (the desktop rule: MS_RATE.cs:1705 {{if (Operators.CompareString(DC_Main.MCo_SName, "UAE", false) == 0)}} MS_RATE.cs:1711 {{((Control)nGoldOzRate).Visible = true;}} MS_RATE.cs:2428 {{mSG[DC_Main.M, 8] = Strings.Format((object)Math.Round(Conversion.Val(mSG[DC_Main.M, 7]) * Conversion.Val(nPrGoldRate.Text) / 100.0), "0.00");}} MS_RATE.cs:2445 {{mSG[DC_Main.M, 8] = Strings.Format((object)Math.Round(Conversion.Val(mSG[DC_Main.M, 7]) * Conversion.Val(nPrSilverRate.Text) / 10000.0), "0.00");}})
Gap: 6, retained scope boundary; not a product failure or a passing UI branch.
Status: N/A: full UAE workflow belongs to its own scope; T02 itself applies.

### daily-rate.settlement.not-applicable   (T06 Required/invalid)
Layer: database
Steps: 1. Record the residual write-set boundary.
Expected: The relevant writes include RATE_MAST source and copies plus GROUP_MAST rates, not merely RATE_MAST. No tender/stock/ledger workflow is added to this packet. (the desktop rule: MS_RATE.cs:1932 {{UPDATE GROUP_MAST SET GR_RATE = }} MS_RATE.cs:1945 {{INSERT INTO RATE_MAST(CO_CODE,LC_CODE,CO_YEAR,VCH_DATE,SR_NO,GR_CODE,FINE_GL_RATE,FINE_SL_RATE,  GR_RATE,GR_TOUCH,GR_TYPE,EMP_CODE,CASH_AMT,MAIN_USER,ADD_USER,ADD_DATE,GR_PR_TOUCH,GR_PR_RATE,  FINE_GL_PR_RATE,FINE_SL_PR_RATE,DOLLAR_GL_RATE,DOLLAR_SL_RATE,AND_TRFR,GR_TAX_RATE,GR_TAX_PRC,OP_GL_RATE)}})
Gap: 7, inaccurate existing evidence text; covered by create.desktop-rows and copy cases, not a missing tender feature.
Status: N/A: tender/settlement is outside Daily Rate; T06 validation itself applies.

## Coverage table

Counts include only applicable cases; the two N/A subcases above are separately noted. Blocked cases stay in the denominator. Every kind applies to these residuals.

| Kind | Applicability | Cases | Blocked |
|---|---|---:|---:|
| T01 Entry/defaults | Applied | 2 | 0 |
| T02 Field route | Applied | 2 | 0 |
| T03 Formula sequence | Applied | 1 | 0 |
| T04 Lookup | Applied | 1 | 0 |
| T05 Children | Applied | 1 | 0 |
| T06 Required/invalid | Applied | 3 | 0 |
| T07 Create | Applied | 4 | 0 |
| T08 Reopen/no-op | Applied | 2 | 0 |
| T09 Edit | Applied | 2 | 0 |
| T10 Delete/cancel/reverse | Applied | 2 | 0 |
| T11 Scope/rights | Applied | 2 | 0 |
| T12 Concurrency | Applied | 2 | 0 |
| T13 Retry/unknown | Applied | 1 | 0 |
| T14 Rollback | Applied | 2 | 0 |
| T15 Config/history | Applied | 3 | 1 |
| T16 Report/output | Applied | 12 | 0 |
| T17 Keyboard/usability | Applied | 2 | 0 |
| T18 Full journey | Applied | 1 | 0 |

Total: 45 applicable cases, 1 blocked; two explicitly N/A subcases.

## Test data

- One synthetic tenant/company with locations 00, 01 and 02 listed in LOCT_MAST. One synthetic rate sentinel at unlisted location 98; other-company and other-tenant sentinels share group codes and D. Use fresh independent login slots for every scope and concurrent operator. Include full-rights, no-rights and revoked-rights actors, plus an authorized configuration administrator. No real user data is needed.
- Non-UAE company and synthetic employee E01. Groups R18 “Rate Gold 18K”, R22 “Rate Gold 22K”, RSV “Rate Silver 925” have the touches, taxes and purchase touches specified in A; original group rates are 111/222/333. Z00 has zero touch and rate 444. Turn RATE_DISPLAY on for the three priced groups. No opening balances, tender or stock vouchers are needed.
- D, H and tomorrow as defined above. Source and destination old-day rows use deliberately different groups/rates so replacement can be distinguished from append. Current fiscal-year identifier comes from fixture configuration, not a guessed schema literal. Cross-year case additionally needs a second valid year identifier for the same synthetic date.
- Optional projection fixture: FINE_GL_RATE=72000, FINE_SL_RATE=85000, FINE_GL_PR_RATE=71000, FINE_SL_PR_RATE=84000, DOLLAR_GL_RATE=2301.25, DOLLAR_SL_RATE=27.75; R22 carries A group values, EMP_CODE=E01 and synthetic MAIN_USER. Supply controlled nullable stored metadata variants: CASH_AMT NULL versus 0, ADD_USER NULL versus a synthetic actor, ADD_DATE NULL versus 2026-11-23 10:00:00, AND_TRFR NULL versus Y, OP_GL_RATE NULL versus 123.45. Each variant must retain its own exact stored value through P. Do not require ordinary save to manufacture imported metadata. Seed through an isolated fixture helper and exercise the production copy primitive; unsupported fixture construction is implementation work, not evidence that the UI passed.
- Display fixture reuses at most eight groups, named “Display 1” through “Display 8”, SR_NO 1–8, GR_RATE 101–108. Their GR_TAX_RATE is 901–908, header gold 72000, and group-master default 999 so wrong value sources are distinguishable. Add a RATE_DISPLAY=N row ahead of them. Vary eligible count per case and restore after each run.

## Not covered

- Gap 6 full UAE workflow stays excluded; optional-column copying is covered by field.copy-optional-projection. Source purchase override context: MS_RATE.cs:2428 {{mSG[DC_Main.M, 8] = Strings.Format((object)Math.Round(Conversion.Val(mSG[DC_Main.M, 7]) * Conversion.Val(nPrGoldRate.Text) / 100.0), "0.00");}} MS_RATE.cs:2445 {{mSG[DC_Main.M, 8] = Strings.Format((object)Math.Round(Conversion.Val(mSG[DC_Main.M, 7]) * Conversion.Val(nPrSilverRate.Text) / 10000.0), "0.00");}}
- Gap 7 settlement stays N/A, but the inaccurate write-set summary is explicitly corrected in this contract and checked by create/copy cases. No study gap is silently omitted. Gaps 1–5 have required cases above; gap 2's cross-year collision remains blocked, not passed.
- General voucher /rate fallback and the existing daily-rate.downstream.rate-lookup-own-location case are outside the residual projection contract. The existing ID tests a different latest-date voucher behaviour; it is not reused for exact-system-date labels. No TR_SALE citation was supplied by the study, so none is invented here.
- External AppSchemeTrfr remains excluded as the study directs. Its invocation is conditional: MS_RATE.cs:1997 {{if (Operators.CompareString(DC_Main.MsAppSchem, "Y", false) == 0)}} MS_RATE.cs:1999 {{AppSchemeTrfr();}}
- Full shared date validation is not specified: MISSING .orch/index/DC_Main.md. The local handler delegates to SetDate: MS_RATE.cs:2293 {{DC_Main.SetDate(ref MsDate);}}
- Crystal template internals, physical printer layout, employee-help internals, every character-filter edge case, all optional UAE keyboard controls, generated-daily-rate launch integration, and desktop MDI child-count visibility are context outside this residual packet. Source anchors for the latter two are MS_RATE.cs:2008 {{if (DC_Main.MsDailyRateGen)}} MS_RATE.cs:2011 {{((Form)this).Close();}} MS_RATE.cs:2270 {{if (((ReadOnlyCollectionBase)(object)((WindowsFormsApplicationBase)MyProject.Application).OpenForms).Count <= 3)}} MS_RATE.cs:2272 {{((Control)MyProject.Forms.MDI_FORM.PanelImage).Visible = true;}} MS_RATE.cs:2276 {{((Control)MyProject.Forms.MDI_FORM.PanelImage).Visible = false;}}. None is claimed as browser-certified here.
- Imported unchanged-save preservation of hidden optional values and metadata needs its own full-form contract; this packet verifies imported reopen without writes and exact P copying, not preservation through a destructive source re-save.
- MISSING orchestration/bin/orch.mjs prevents running that checker here. A literal source audit may validate quotes, but is not represented as execution of the missing dispatcher tool.
