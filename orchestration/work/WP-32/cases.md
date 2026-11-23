# WP-32 frozen residual case list

This is the residual contract derived from `orchestration/work/WP-32/study.md`, not a replacement for the existing 19-case browser module. Each T01–T18 kind applies to these residuals; none is silently omitted. Existing matching IDs are retained, including the five `.pending` IDs: the suffix is an identity, not a status. Previously implemented behaviours outside the study remain owned by the existing module.

“Executable” means the steps and oracle are specified for implementation and execution; it does not mean the feature exists or a test passed. Missing controls, fixture variants, route wiring and version handling inside this menu are expected failures, not external blockers. No browser or database test was run for this document. Gap numbers refer to the study. Run each case in both OPSTK and TAG GEN unless a case explicitly restricts its mode; supply the stock item in TAG GEN except when testing its absence. Retain evidence separately for each mode and each variant. No blocked case may be removed from the denominator.

For every mutation, collect the request, response, scoped before/after database diff, reopened values and the downstream observation stated in the case. Scope includes tenant, company, location, year, book and voucher, plus tag/row identity where relevant. Compare unrelated sentinel rows exactly. Query synthetic fixtures only through the isolated parity database. Blank/refused inputs must leave zero new business rows. UI checks use 1366×768 and a larger counter viewport; required controls must be reachable with the keyboard.

## Decisions resolving the study questions

- **architect, 2026-11-23, owner may override — controls/defaults:** apply the source-defined Print and Set actions and right checks, with keyboard access; do not invent a complete tab graph from this residual study. Missing full initial-focus/tab-order evidence remains explicitly outside this residual freeze. Print denial is defined by TR_TAG_OPBL.cs:11479 {{You Have No Print Rights.....}}; setting a default acknowledges TR_TAG_OPBL.cs:12362 {{Tag Print Report Default Set}}.
- **architect, 2026-11-23, owner may override — auto features:** both settings remain in scope, independently gated; temporary row save precedes row printing when both are Y. The source gates are TR_TAG_OPBL.cs:9108 {{if (Operators.CompareString(DC_Main.MsTagVchAutoSave, "Y", false) == 0)}} and TR_TAG_OPBL.cs:9112 {{if (Operators.CompareString(DC_Main.MsTagRowAutoPrint, "Y", false) == 0)}}, followed by TR_TAG_OPBL.cs:9114 {{TagLastRowPrint((int)Math.Round(Conversion.Val(mSG[mSG.Row, 0])));}}. Use an atomic, operator-scoped implementation. The complete hosted temporary-write/recovery contract is not settled by the study; the separate database case remains blocked on that exact question, while the observable gate/order case stays executable.
- **architect, 2026-11-23, owner may override — concurrency:** apply accepted D17 in document 11 §4: GET supplies a 64-hex SHA-256 version of the complete write set; PUT and DELETE require expectedVersion; stale writes return HTTP 409 with `voucher-version-conflict`. This is a hosted safety contract, not an invented desktop message. No unverified user-facing sentence is prescribed.
- **architect, 2026-11-23, owner may override — templates:** seed synthetic PRINT_MAST choices for functional tests; do not claim they are shipped Lite templates. The chooser filters are TR_TAG_OPBL.cs:10086 {{PRINT_TYPE = 'QR' ORDER BY PRINT_FILE}} and TR_TAG_OPBL.cs:10090 {{PRINT_TYPE = 'TAG' ORDER BY PRINT_FILE}}. MISSING: the actual Lite TAG/QR template names, corresponding report assets and physical label reference. Only physical/layout equivalence is blocked by these external artifacts.
- **architect, 2026-11-23, owner may override — lookup/key scope:** freeze the documented order identity, manufacturing weights and lot-derived karigar values. Do not infer extra order valuation or a complete grid shortcut map. The order identity anchor is TR_TAG_OPBL.cs:8336 {{mSG[DC_Main.i, 90] = Conversions.ToString(DC_Main.Rshlp.Rows[0]["ORD_SRNO"]);}}. The auto-row Enter workflow has its own case below.
- **architect, 2026-11-23, owner may override — hosted safety:** use D18 from document 11 §4 for idempotent creates, atomic deletion and operator-isolated print jobs. Preserve observable results without reproducing global staging deletion: TR_TAG_OPBL.cs:11482 {{DC_Main.ExeQuteDc("DELETE FROM TAG_PRINT_DATA");}}. A hidden karigar column remains presentation behaviour; this study does not establish a separate field-level secrecy entitlement.

## Cases


### tag-opening.entry.menu-books   (T01 Entry/defaults)
Layer: browser
Steps: 1. Open each menu with its configured book as administrator and view-only operator. 2. Inspect the selected family and residual print controls.
Expected: Tag Opening selects OPSTK; Only Tag Entry selects TAG GEN. Print, label skip, file chooser and Set are reachable; a denied print uses the specified refusal rather than executing a job. (The desktop rule: MDI_FORM.cs:7701 {{DC_Main.CurBookHelp("OPSTK");}}; MDI_FORM.cs:8575 {{DC_Main.CurBookHelp("TAG GEN");}}; TR_TAG_OPBL.cs:11479 {{You Have No Print Rights.....}}; TR_TAG_OPBL.cs:11485 {{int num = (int)Math.Round(Conversion.Val(nLableSkip.Text));}}; TR_TAG_OPBL.cs:12362 {{Tag Print Report Default Set}})
Status: executable
Gap: 6; reuse of the existing menu-books ID adds residual controls.


### tag-opening.entry.karigar-visibility   (T01 Entry/defaults)
Layer: browser
Steps: 1. Set MsUserKrTouchHide=Y and open as non-admin, then admin. 2. Repeat as non-admin with N.
Expected: With Y, non-admin sees none of KrTouch, KrWst%, KrFine; admin sees all three. With N all three are visible. Saving an unrelated field does not zero stored karigar values. (The desktop rule: TR_TAG_OPBL.cs:5156 {{DC_Main.MsUserKrTouchHide, "Y", false) == 0) & (Operators.CompareString(DC_Main.MCo_UserType, "A", false) != 0)}})
Status: executable
Gap: 5 (G217).


### tag-opening.field.lot-header   (T02 Field route)
Layer: browser
Steps: 1. Choose synthetic lot L32 with touch 92 and wastage 1.50. 2. Add a source-A tag row. 3. Inspect the row, request and reopened persisted values.
Expected: The new row receives KrTouch 92.00 and KrWst% 1.50. Lot identity stays L32 through request, save and reopen; a second tag retains its own identity. (The desktop rule: TR_TAG_OPBL.cs:5579 {{if ((Operators.CompareString(mSG[mSG.Row, 69], "A", false) == 0) & (Conversion.Val(nLotTouch.Text) != 0.0))}}; TR_TAG_OPBL.cs:10994 {{dataRow3["KR_TOUCH"] = Strings.Format((object)Conversion.Val(nLotTouch.Text), "0.00");}}; TR_TAG_OPBL.cs:10995 {{dataRow3["KR_WEST_PRC"] = Strings.Format((object)Conversion.Val(nLotWestPrc.Text), "0.00");}})
Status: executable
Gap: 5 (G217).


### tag-opening.field.column-rename   (T02 Field route)
Layer: browser
Steps: 1. Configure TAG_DETL KrTouch as renamed to Artisan Touch and KrWst% hidden. 2. Reload, edit Artisan Touch to 92 and save. 3. Restore the column configuration and reopen.
Expected: Artisan Touch is the visible header; KrWst% has no visible column. The edited original KrTouch field persists as 92.00, without a new Artisan Touch payload property. Original stable accessibility identity remains usable (hosted testability requirement). (The desktop rule: TR_TAG_OPBL.cs:5395 {{dataView.RowFilter = "BOOK_NAME = 'TAG_DETL' AND COL_NAME = '" + mSG[0, DC_Main.M] + "'";}}; TR_TAG_OPBL.cs:5402 {{mSG[0, DC_Main.M] = Conversions.ToString(dataView[0]["COL_NEW_NAME"]);}}; TR_TAG_OPBL.cs:5618 {{dataView.RowFilter = "BOOK_NAME = 'TAG_DETL' AND COL_NEW_NAME = '"}})
Status: executable
Gap: 7.


### tag-opening.formula.lot-blank-touch   (T03 Formula sequence)
Layer: browser
Steps: 1. Use L32 and source A. 2. Enter gross 10.500, KrOthWt 0.500 and KrGht 0; clear KrTouch to zero before saving. 3. Compare grid, request, detail and stock.
Expected: KrNwt = 10.500 − 0.500 = 10.000. Save fills KR_TOUCH=92.00 and KR_WEST_PRC=1.50. KrFine = (10+0) × (92+1.5)/100 = 9.35; persisted detail and tag stock have numeric karigar fine 9.35. This deliberately uses an exact two-decimal result so the lot-save precision is not confused with the typed-block path. (The desktop rule: TR_TAG_OPBL.cs:10990 {{if ((mSG[21] == 0) & (Operators.CompareString(tLotNo.Text, "", false) != 0) & (Conversion.Val(nLotTouch.Text) != 0.0))}}; TR_TAG_OPBL.cs:10994 {{dataRow3["KR_TOUCH"] = Strings.Format((object)Conversion.Val(nLotTouch.Text), "0.00");}}; TR_TAG_OPBL.cs:10995 {{dataRow3["KR_WEST_PRC"] = Strings.Format((object)Conversion.Val(nLotWestPrc.Text), "0.00");}}; TR_TAG_OPBL.cs:10996 {{if ((Conversion.Val(mSG[DC_Main.i, 18]) != 0.0) & (Conversion.Val(nLotTouch.Text) != 0.0))}})
Status: executable
Gap: 5 (G217).


### tag-opening.formula.manufacturing-pull   (T03 Formula sequence)
Layer: browser
Steps: 1. Select manufacturing source M32 with gross 10.500, other 0.500, net 10.000 and fine 9.200. 2. Inspect copied values before further edits. 3. Save and reopen.
Expected: Gross is 10.500, KrOthWt 0.500, KrNwt 10.000 and KrFine 9.200. Derived KrTouch = 9.200 × 100 / 10.000 = 92.00. The same numeric values survive detail, tag stock and reopen. (The desktop rule: TR_TAG_OPBL.cs:8587 {{mSG[DC_Main.i, 14] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GWT"])), "0.000");}}; TR_TAG_OPBL.cs:8593 {{mSG[DC_Main.i, 17] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_OTH_WT"])), "0.000");}}; TR_TAG_OPBL.cs:8595 {{mSG[DC_Main.i, 23] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_FINE"])), "0.000");}})
Status: executable
Gap: 5 (G217).


### tag-opening.lookup.order-source   (T04 Lookup)
Layer: browser
Steps: 1. Select synthetic order line O32 with ORD_SRNO 7, size 18 and pieces 2. 2. Cancel a second lookup. 3. Select a different order line with ORD_SRNO 9, size 20 and pieces 3. 4. Save and reopen.
Expected: First selection fills source row identity 7, size 18 and pieces 2; cancel preserves these values. Replacement and reopen show identity 9, size 20 and pieces 3, with no identity 7 retained on that tag. Cancellation preservation is the hosted interaction contract; no additional order-derived karigar formula is inferred. (The desktop rule: TR_TAG_OPBL.cs:8336 {{mSG[DC_Main.i, 90] = Conversions.ToString(DC_Main.Rshlp.Rows[0]["ORD_SRNO"]);}})
Status: executable
Gap: 5 (G217), order source omitted from the study’s three suggested cases.


### tag-opening.lookup.print-file-family   (T04 Lookup)
Layer: browser
Steps: 1. Seed TAG choices Z32 and A32, QR choices Q32 and B32, and an unrelated report type. 2. Open with QR generation N, then Y. 3. Select and cancel a choice.
Expected: N lists A32, Z32 in that order; Y lists B32, Q32. The unrelated type and other company choices never appear. Cancel leaves the prior selected choice intact under the hosted interaction contract. (The desktop rule: TR_TAG_OPBL.cs:10086 {{PRINT_TYPE = 'QR' ORDER BY PRINT_FILE}}; TR_TAG_OPBL.cs:10090 {{PRINT_TYPE = 'TAG' ORDER BY PRINT_FILE}})
Status: executable
Gap: 6.


### tag-opening.children.column-settings   (T05 Children)
Layer: browser
Steps: 1. Give tag A one detail child with pieces 2 and tag B one child with pieces 3. 2. Rename TAG_IDTL Pcs to Child Pieces and hide PcsWt in COL_MAST. 3. Reload, edit A to 4 pieces, save and reopen both tags.
Expected: Child Pieces is visible and PcsWt hidden in the detail grid; the independently configured TAG_DETL header remains Artisan Touch. A has exactly one child with pieces 4 and B exactly one with pieces 3; neither child changes owner. TAG_IDTL treatment is specified in the study’s Gap 7; the quoted company-load anchor is shared by both grids. (The desktop rule: TR_TAG_OPBL.cs:5402 {{mSG[0, DC_Main.M] = Conversions.ToString(dataView[0]["COL_NEW_NAME"]);}}; DC_Main.cs:1688 {{SELECT * FROM COL_MAST WHERE CO_CODE = '}})
Status: executable
Gap: 7.


### tag-opening.refusal.counter-required   (T06 Required/invalid)
Layer: browser
Steps: 1. With CNTR_STK=Y create two rows, first counter 001 and second blank. 2. Save through UI and repeat by direct API. 3. Fill second counter 001 and retry.
Expected: Refusal text is exactly “Please Insert Counter Code and Try Because It is Mandatory...”; UI focuses row 2 counter entry and Save is re-enabled. Refused attempts add zero voucher/detail/stock/identity rows. After correction there is one voucher with two counter-001 tags. (The desktop rule: TR_TAG_OPBL.cs:10793 {{if (Operators.CompareString(DC_Main.MsCntrStk, "Y", false) == 0)}}; TR_TAG_OPBL.cs:10801 {{Please Insert Counter Code and Try Because It is Mandatory...}})
Status: executable
Gap: 8.


### tag-opening.field.only-tag-entry-stock   (T06 Required/invalid)
Layer: browser
Steps: 1. Open TAG GEN and leave stock item blank. 2. Try Save; then select the synthetic stock item and retry.
Expected: Blank stock item yields “Stock item code Insert First...” and focus on the stock-item input; zero rows are written. Selecting the item removes this refusal. This reuses the existing behaviour ID; its non-residual stock-sign assertions remain in the original module. (The desktop rule: TR_TAG_OPBL.cs:10813 {{(Operators.CompareString(FormMainBook, "TAG GEN", false) == 0)}}; TR_TAG_OPBL.cs:10815 {{Stock item code Insert First...}})
Status: executable


### tag-opening.create.lot-karigar-footprint   (T07 Create)
Layer: database
Steps: 1. Create one L32 source-A tag with one detail child through the browser using the lot formula vector. 2. Query the complete scoped write set and reopen.
Expected: Exactly one BAR_DATA header, one BAR_DETL tag, one BAR_IDTL child and one tag identity exist. The tag detail and matching tag stock carry touch 92.00, wastage 1.50 and fine 9.35. TAG GEN additionally retains its existing source-stock consumption contract. All unrelated sentinel rows are identical to before; no second voucher is created. (The desktop rule: TR_TAG_OPBL.cs:10858 {{DELETE FROM BAR_DATA WHERE CO_CODE}}; TR_TAG_OPBL.cs:10994 {{dataRow3["KR_TOUCH"] = Strings.Format((object)Conversion.Val(nLotTouch.Text), "0.00");}}; TR_TAG_OPBL.cs:10995 {{dataRow3["KR_WEST_PRC"] = Strings.Format((object)Conversion.Val(nLotWestPrc.Text), "0.00");}}; TR_TAG_OPBL.cs:10996 {{if ((Conversion.Val(mSG[DC_Main.i, 18]) != 0.0) & (Conversion.Val(nLotTouch.Text) != 0.0))}})
Status: executable
Gap: 5 (G217).


### tag-opening.reopen.lot-values   (T08 Reopen/no-op)
Layer: browser
Steps: 1. Reopen a newly saved L32 tag and an imported synthetic equivalent. 2. Save unchanged, then print and reopen again.
Expected: Both remain touch 92.00, wastage 1.50, fine 9.35 with the same tag and child identities. Printing adds zero business voucher/stock rows. Compare raw stored NULLs, scales, timestamps and images before/after and require preservation of untouched values under the hosted no-op contract; do not silently normalize imported values. (The desktop rule: TR_TAG_OPBL.cs:10994 {{dataRow3["KR_TOUCH"] = Strings.Format((object)Conversion.Val(nLotTouch.Text), "0.00");}}; TR_TAG_OPBL.cs:10995 {{dataRow3["KR_WEST_PRC"] = Strings.Format((object)Conversion.Val(nLotWestPrc.Text), "0.00");}}; TR_TAG_OPBL.cs:11523 {{ITM_COLOR,LBR_CODE,ITM_STYLE  FROM BAR_DETL WHERE CO_CODE}})
Status: executable
Gap: 5 and 6.


### tag-opening.edit.counter-required   (T09 Edit)
Layer: browser
Steps: 1. Save two counter-001 tags with CNTR_STK=N. 2. Turn CNTR_STK=Y, reload and clear row 2 counter. 3. Attempt update via UI and direct API.
Expected: Both updates are refused with “Please Insert Counter Code and Try Because It is Mandatory...”. Both saved counters remain 001; every persisted row equals its before-image. This covers the edit writer separately from create. (The desktop rule: TR_TAG_OPBL.cs:10793 {{if (Operators.CompareString(DC_Main.MsCntrStk, "Y", false) == 0)}}; TR_TAG_OPBL.cs:10801 {{Please Insert Counter Code and Try Because It is Mandatory...}})
Status: executable
Gap: 8.


### tag-opening.delete.cancel-and-atomic   (T10 Delete/cancel/reverse)
Layer: browser
Steps: 1. Open an unsold synthetic voucher and cancel the delete confirmation. 2. Confirm deletion on a second attempt. 3. Compare voucher, stock, lot links, identities and image rows.
Expected: Confirmation is “Are You Sure To Delete This Voucher now?”. Cancel changes zero rows. Confirm displays “Delete Success.” and leaves zero owned rows in SRNO_MAST, TAG_IMAGE_DATA, MAIN_STOCK, LOT_DETL, BAR_DATA, BAR_DETL and BAR_IDTL. Unrelated sentinels survive; all removal is atomic as a hosted safety requirement. (The desktop rule: TR_TAG_OPBL.cs:11387 {{Are You Sure To Delete This Voucher now?}}; TR_TAG_OPBL.cs:11421 {{DELETE FROM SRNO_MAST WHERE CO_CODE}}; TR_TAG_OPBL.cs:11431 {{Delete Success.}})
Status: executable


### tag-opening.rights.pending   (T11 Scope/rights)
Layer: browser
Steps: 1. Provision a view-only menu rights row; attempt create, edit and delete through UI and API. 2. Test an edit-enabled operator against voucher USER_UPDATE=N and USER_DELETE=N. 3. Revoke rights after load and retry.
Expected: Each forbidden mutation is denied server-side with HTTP 403 and zero business changes; UI displays “You Have No Rights.....”. Granting create must not implicitly grant edit/delete; per-voucher flags still restrict the operation. This resolves the old missing-fixture case without calling that absence an external blocker. (The desktop rule: TR_TAG_OPBL.cs:10787 {{You Have No Rights.....}}; TR_TAG_OPBL.cs:9827 {{Select * From USER_SET WHERE LC_CODE}}; TR_TAG_OPBL.cs:10414 {{UsUPdate = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["USER_UPDATE"], (object)""));}}; TR_TAG_OPBL.cs:10415 {{UsDelete = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["USER_DELETE"], (object)""));}})
Status: executable
Gap: 1.


### tag-opening.rights.print-denied   (T11 Scope/rights)
Layer: browser
Steps: 1. Set FRM_PRINT=N while retaining view and create. 2. Attempt toolbar Print and direct print request; also attempt automatic row print with its setting Y.
Expected: UI displays “You Have No Print Rights.....”; direct print returns HTTP 403. Zero staging rows, QR images or print jobs are created. The auto path must enforce the same right as a hosted safety rule. (The desktop rule: TR_TAG_OPBL.cs:11477 {{if (Operators.CompareString(UserPrint, "Y", false) != 0)}}; TR_TAG_OPBL.cs:11479 {{You Have No Print Rights.....}}; TR_TAG_OPBL.cs:9834 {{UserPrint = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["FRM_PRINT"], (object)""));}})
Status: executable
Gap: 1 and 6.


### tag-opening.rights.scope-sentinels   (T11 Scope/rights)
Layer: database
Steps: 1. Reuse voucher/tag/template identifiers in a second tenant, company, location and year. 2. Call read, mutation, print and Set with those identities from the first scope.
Expected: Zero foreign rows are returned or changed; no foreign tag appears in output. Invalid authority receives a denial rather than a cross-scope success. Authorized Set changes defaults only within its company and selected TAG/QR family. Scope enforcement is the hosted correction to company-only print selection. (The desktop rule: TR_TAG_OPBL.cs:11538 {{DC_Main.RptFormula = "{TAG_PRINT_DATA.CO_CODE} = '"}}; TR_TAG_OPBL.cs:12357 {{UPDATE PRINT_MAST SET PRINT_SET_A = 'N' WHERE  CO_CODE}}; TR_TAG_OPBL.cs:12359 {{UPDATE PRINT_MAST SET PRINT_SET_A = 'Y' WHERE  CO_CODE}})
Status: executable
Gap: 1, 6 and 7.


### tag-opening.concurrency.pending   (T12 Concurrency)
Layer: browser
Steps: 1. Operators A and B GET one voucher and the same version. 2. A saves touch 93.00. 3. B attempts touch 94.00 with its stale expectedVersion; then tries DELETE with that token. 4. Reload and retry with the fresh version.
Expected: D17: both original tokens are 64 hexadecimal characters. A succeeds; B’s stale PUT and DELETE each return 409 voucher-version-conflict, with touch still 93.00 and no lost child/stock changes. Reload supplies a changed token. A new authorized update with that token can persist 94.00. This is a hosted rule protecting the replace-on-save operation. (The desktop rule: TR_TAG_OPBL.cs:10858 {{DELETE FROM BAR_DATA WHERE CO_CODE}})
Status: executable
Gap: 2.


### tag-opening.concurrency.print-isolation   (T12 Concurrency)
Layer: browser
Steps: 1. A prints voucher A32 with two tags and skip 2 while B prints voucher B32 with one tag and skip 0. 2. Interleave staging/render calls and repeat in another company.
Expected: A receives exactly four labels, two blank then its two tags. B receives exactly one label, its own tag. Neither operator’s job is deleted or contaminated; no shared QR image is overwritten. Operator/job isolation is a hosted correction, not reproduction of the global delete. (The desktop rule: TR_TAG_OPBL.cs:11482 {{DC_Main.ExeQuteDc("DELETE FROM TAG_PRINT_DATA");}}; TR_TAG_OPBL.cs:11523 {{ITM_COLOR,LBR_CODE,ITM_STYLE  FROM BAR_DETL WHERE CO_CODE}})
Status: executable
Gap: 6.


### tag-opening.retry.pending   (T13 Retry/unknown)
Layer: database
Steps: 1. POST a one-tag voucher with key K32. 2. Repeat identical body/key after dropping the first response following commit. 3. Reconnect and replay again.
Expected: D18: all responses recover the same durable voucher/tag identity and original response; there is exactly one header, one tag detail, one tag identity and one set of stock effects, plus one command receipt. The source replace-write is not run as an additional create. No assumption is made that policy registration proves route enforcement. (The desktop rule: TR_TAG_OPBL.cs:10858 {{DELETE FROM BAR_DATA WHERE CO_CODE}})
Status: executable
Gap: 3.


### tag-opening.retry.changed-body   (T13 Retry/unknown)
Layer: database
Steps: 1. Commit the K32 request. 2. Reuse K32 with gross weight changed from 10.500 to 11.500.
Expected: D18 returns 409 idempotency-key-reused. The original gross remains 10.500; no second voucher, receipt or stock effect appears. D18 is the hosted contract layered over voucher persistence. (The desktop rule: TR_TAG_OPBL.cs:10858 {{DELETE FROM BAR_DATA WHERE CO_CODE}})
Status: executable
Gap: 3.


### tag-opening.rollback.pending   (T14 Rollback)
Layer: database
Steps: 1. On the isolated database install a scoped trigger that raises at MAIN_STOCK, then BAR_DETL, then BAR_IDTL, in separate runs. 2. For each point create a tag with a child and then repeat an edit of an existing tag. 3. Remove each trigger in cleanup.
Expected: At each of the three points, create leaves zero new BAR_DATA/BAR_DETL/BAR_IDTL/MAIN_STOCK/SRNO_MAST rows and no success receipt. Edit restores the complete previous write set, including stock and child ownership. Unrelated sentinels survive. Trigger provisioning is part of this menu’s test implementation; absence is not permission to skip G173. (The desktop rule: TR_TAG_OPBL.cs:10858 {{DELETE FROM BAR_DATA WHERE CO_CODE}})
Status: executable
Gap: 4 (G173).


### tag-opening.rollback.delete-and-print   (T14 Rollback)
Layer: database
Steps: 1. Inject a scoped failure after the first deletion family, then after stock deletion in separate runs. 2. Separately fail a print after blank staging rows but before real rows.
Expected: Failed delete preserves all original voucher, stock, child, lot, identity and image rows with zero durable delete audit. Failed print creates no renderable partial job and leaves existing jobs and business rows unchanged. Atomicity is the hosted safety requirement for source operations that clear data first. (The desktop rule: TR_TAG_OPBL.cs:11421 {{DELETE FROM SRNO_MAST WHERE CO_CODE}}; TR_TAG_OPBL.cs:11482 {{DC_Main.ExeQuteDc("DELETE FROM TAG_PRINT_DATA");}})
Status: executable
Gap: 4 and 6.


### tag-opening.settings.pending   (T15 Config/history)
Layer: browser
Steps: 1. Run create and edit with CNTR_STK=N and a blank counter. 2. Switch to Y between loading a draft and saving; repeat both operations. 3. Reopen the untouched historical voucher.
Expected: With N, blank counter is not refused by this rule. With Y at save, both operations refuse with “Please Insert Counter Code and Try Because It is Mandatory...”; no hidden cached N bypass is allowed. Historical reopen alone writes zero rows. Current-rule validation at save is the hosted interpretation of the source setting check. (The desktop rule: TR_TAG_OPBL.cs:10793 {{if (Operators.CompareString(DC_Main.MsCntrStk, "Y", false) == 0)}}; TR_TAG_OPBL.cs:10801 {{Please Insert Counter Code and Try Because It is Mandatory...}})
Status: executable
Gap: 8.


### tag-opening.settings.default-label-file   (T15 Config/history)
Layer: browser
Steps: 1. Select Z32 from TAG choices and press Set. 2. Inspect PRINT_MAST; reopen the chooser. 3. Repeat with Q32 in QR mode.
Expected: Set displays “Tag Print Report Default Set”. Exactly Z32 has PRINT_SET_A=Y among this company’s TAG rows; A32 is N. Exactly Q32 has Y among its QR rows; B32 is N. Setting QR does not unset TAG or another company’s default. Reopening selects the configured default as the required persistence contract. (The desktop rule: TR_TAG_OPBL.cs:12357 {{UPDATE PRINT_MAST SET PRINT_SET_A = 'N' WHERE  CO_CODE}}; TR_TAG_OPBL.cs:12359 {{UPDATE PRINT_MAST SET PRINT_SET_A = 'Y' WHERE  CO_CODE}}; TR_TAG_OPBL.cs:12362 {{Tag Print Report Default Set}}; TR_TAG_OPBL.cs:10086 {{PRINT_TYPE = 'QR' ORDER BY PRINT_FILE}})
Status: executable
Gap: 6.


### tag-opening.settings.columns-history   (T15 Config/history)
Layer: browser
Steps: 1. Save touch 92.00 and a child with pieces 2. 2. Change TAG_DETL/TAG_IDTL captions and visibility. 3. Start a new screen session and reopen the voucher. 4. Leave a second company with original settings.
Expected: The new session displays Artisan Touch and Child Pieces with the chosen hidden columns, but stored touch remains 92.00 and child pieces 2. Other company headers and values remain unchanged. Mid-session hot refresh is not required; the source loads COL_MAST at startup. (The desktop rule: DC_Main.cs:1688 {{SELECT * FROM COL_MAST WHERE CO_CODE = '}}; TR_TAG_OPBL.cs:5395 {{dataView.RowFilter = "BOOK_NAME = 'TAG_DETL' AND COL_NAME = '" + mSG[0, DC_Main.M] + "'";}}; TR_TAG_OPBL.cs:5402 {{mSG[0, DC_Main.M] = Conversions.ToString(dataView[0]["COL_NEW_NAME"]);}})
Status: executable
Gap: 7.


### tag-opening.output.skip-rounding   (T16 Report/output)
Layer: browser
Steps: 1. Open a saved two-tag voucher. 2. Print separately with skip 0, 2.5 and 3.5. 3. Inspect ordered staging and rendered label positions.
Expected: Half-to-even rounds 2.5 to 2 and 3.5 to 4. Label counts are respectively 2, 4 and 6. Each skipped position has IT_CODE=00 and VCH_SRNO=0; real labels follow all blanks in voucher row order. Business rows are unchanged. (The desktop rule: TR_TAG_OPBL.cs:11485 {{int num = (int)Math.Round(Conversion.Val(nLableSkip.Text));}}; TR_TAG_OPBL.cs:11489 {{Conversions.ToString(DC_Main.i) + ",'00',0)"}}; TR_TAG_OPBL.cs:11523 {{ITM_COLOR,LBR_CODE,ITM_STYLE  FROM BAR_DETL WHERE CO_CODE}})
Status: executable
Gap: 6.


### tag-opening.output.voucher-projection   (T16 Report/output)
Layer: database
Steps: 1. Save two tags with distinct color, labour code, style and hallmark sentinels plus a third tag in another voucher. 2. Print the first voucher and compare every selected source field to the staged real rows.
Expected: Exactly the two chosen voucher tags are staged; the third is absent. For each real row every projected column equals its frozen synthetic BAR_DETL value, including ITM_COLOR=C32A/C32B, LBR_CODE=L32A/L32B and ITM_STYLE=S32A/S32B. Retain an explicit per-column fixture oracle from the cited SELECT before execution; comparing only a count or today’s web output is insufficient. (The desktop rule: TR_TAG_OPBL.cs:11523 {{ITM_COLOR,LBR_CODE,ITM_STYLE  FROM BAR_DETL WHERE CO_CODE}})
Status: executable
Gap: 6.


### tag-opening.output.qr-images   (T16 Report/output)
Layer: browser
Steps: 1. Reopen a saved two-tag voucher in edit mode with QR generation Y and print. 2. Decode the rendered codes. 3. Repeat with QR generation N.
Expected: Y produces exactly two QR images whose decoded contents equal the two synthetic tag numbers, one per tag; skipped labels have no tag QR. N creates zero new QR images. All other operator images and voucher data remain unchanged under job isolation. (The desktop rule: TR_TAG_OPBL.cs:11493 {{(Operators.CompareString(EntryMode, "E", false) == 0) & (MSG.Rows > 1)}}; TR_TAG_OPBL.cs:11523 {{ITM_COLOR,LBR_CODE,ITM_STYLE  FROM BAR_DETL WHERE CO_CODE}})
Status: executable
Gap: 6.


### tag-opening.output.preview-and-cancel   (T16 Report/output)
Layer: browser
Steps: 1. Select A32 and request Print with skip 2 for the two-tag voucher. 2. Choose preview, then repeat and cancel the output dialog.
Expected: Preview contains four label positions, first two blank and then the two selected tags, using selected A32. Cancel sends zero physical print jobs. Both operations add zero business writes; staging cleanup must remain operator-scoped. The study’s Print section defines preview/direct selection; the template selection anchor is below. (The desktop rule: TR_TAG_OPBL.cs:11551 {{Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath}})
Status: executable
Gap: 6.


### tag-opening.output.physical-template   (T16 Report/output)
Layer: browser
Steps: 1. Supply approved Lite TAG and QR report files, device and reference sheets. 2. Print the two-tag fixture with two skipped positions using each selected template. 3. Compare measured label geometry and scan codes.
Expected: Exactly four positions are consumed, the first two blank and then the two tags; decoded QR values equal tag identifiers. MISSING: reference label dimensions, font/layout and actual template names, so no numerical geometry tolerance is invented. (The desktop rule: TR_TAG_OPBL.cs:11551 {{Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath}}; TR_TAG_OPBL.cs:11485 {{int num = (int)Math.Round(Conversion.Val(nLableSkip.Text));}})
Status: blocked: external report assets and a label printer/reference sheet are missing; supply the actual Lite TAG/QR templates and measured reference to freeze geometry before execution
Gap: 6.


### tag-opening.keyboard.auto-row-settings   (T17 Keyboard/usability)
Layer: browser
Steps: 1. For each combination (auto-save, auto-print) = (N,N), (Y,N), (N,Y), (Y,Y), finish the last cell on the last row and press Enter. 2. Record operation order and print job tag identity.
Expected: N,N invokes neither action; Y,N invokes one temporary save and zero prints; N,Y invokes zero temporary saves and one print of the current row; Y,Y invokes one temporary save before one current-row print. No other row is printed. Missing controls/settings integration is a failure for Gaps 6 and 9, not a dependency block. (The desktop rule: TR_TAG_OPBL.cs:9108 {{if (Operators.CompareString(DC_Main.MsTagVchAutoSave, "Y", false) == 0)}}; TR_TAG_OPBL.cs:9112 {{if (Operators.CompareString(DC_Main.MsTagRowAutoPrint, "Y", false) == 0)}}; TR_TAG_OPBL.cs:9114 {{TagLastRowPrint((int)Math.Round(Conversion.Val(mSG[mSG.Row, 0])));}})
Status: executable
Gap: 6 and 9.


### tag-opening.keyboard.auto-save-footprint   (T17 Keyboard/usability)
Layer: database
Steps: 1. Enable auto-save, complete a row using Enter, then interrupt the connection after durable save. 2. Reload/recover and finish the voucher.
Expected: Exactly one recoverable current-row save must exist and final save must not duplicate its tag identity. MISSING: an approved complete temporary-save write-set/recovery oracle. Exact question: how are temporary BAR_DATA/BAR_DETL/BAR_IDTL/SRNO_MAST writes represented, scoped, recovered and transitioned to final stock posting in the hosted service? Do not equate a temporary save with a full final stock posting. (The desktop rule: TR_TAG_OPBL.cs:9108 {{if (Operators.CompareString(DC_Main.MsTagVchAutoSave, "Y", false) == 0)}})
Status: blocked: the source gate alone cannot settle the hosted temporary-save recovery/transition contract; architect must freeze the complete safe mapping after a focused TempSave study
Gap: 9.


### tag-opening.journey.sold-tag-blocks-delete   (T18 Full journey)
Layer: browser
Steps: 1. Create the lot-derived tag, reopen and print it. 2. Sell that exact tag through Sales Invoice. 3. Attempt opening deletion. 4. Reverse/delete the sale through its supported UI and retry opening deletion.
Expected: The opening retains karigar touch 92.00, wastage 1.50 and fine 9.35 before sale. While sold, deletion displays “You Cant Delete This Voucher Because  Tag Use in Sales Transection....” and changes zero opening rows. Once the sale is removed, opening deletion displays “Delete Success.” and removes its stock/identity. Printed tag identity equals the sold identity throughout. (The desktop rule: TR_TAG_OPBL.cs:10994 {{dataRow3["KR_TOUCH"] = Strings.Format((object)Conversion.Val(nLotTouch.Text), "0.00");}}; TR_TAG_OPBL.cs:10995 {{dataRow3["KR_WEST_PRC"] = Strings.Format((object)Conversion.Val(nLotWestPrc.Text), "0.00");}}; TR_TAG_OPBL.cs:11383 {{You Cant Delete This Voucher Because  Tag Use in Sales Transection....}}; TR_TAG_OPBL.cs:11431 {{Delete Success.}})
Status: executable
Gap: 5 and 6; reused downstream journey ID.


## Coverage table

Counts are case IDs, not mode/setting repetitions. Both blocked cases remain required. All 18 kinds apply; N/A count is zero.

| Kind | Applies | Cases | Blocked |
|---|---|---:|---:|

| T01 Entry/defaults | Yes | 2 | 0 |

| T02 Field route | Yes | 2 | 0 |

| T03 Formula sequence | Yes | 2 | 0 |

| T04 Lookup | Yes | 2 | 0 |

| T05 Children | Yes | 1 | 0 |

| T06 Required/invalid | Yes | 2 | 0 |

| T07 Create | Yes | 1 | 0 |

| T08 Reopen/no-op | Yes | 1 | 0 |

| T09 Edit | Yes | 1 | 0 |

| T10 Delete/cancel/reverse | Yes | 1 | 0 |

| T11 Scope/rights | Yes | 3 | 0 |

| T12 Concurrency | Yes | 2 | 0 |

| T13 Retry/unknown | Yes | 2 | 0 |

| T14 Rollback | Yes | 2 | 0 |

| T15 Config/history | Yes | 3 | 0 |

| T16 Report/output | Yes | 5 | 1 |

| T17 Keyboard/usability | Yes | 2 | 1 |

| T18 Full journey | Yes | 1 | 0 |

| Total | | 35 | 2 |


Every study gap has an executable failing-behaviour target: Gap 1 rights.pending/rights.print-denied; Gap 2 concurrency.pending; Gap 3 retry.pending; Gap 4 rollback.pending; Gap 5 formula.lot-blank-touch/formula.manufacturing-pull/entry.karigar-visibility/lookup.order-source; Gap 6 output.skip-rounding; Gap 7 field.column-rename/children.column-settings; Gap 8 settings.pending/refusal.counter-required/edit.counter-required; Gap 9 keyboard.auto-row-settings. These are study-reported current failures, not failures executed in this cases-only session. The additional blocked cases preserve unknowns instead of implying coverage.

## Test data

Use synthetic, isolated fixtures only. Reuse the browser catalogue’s configured opening book TOP (OPSTK), TGN (TAG GEN), gold stock item and counter 001. Provide one employee if the fixture’s employee-required setting is enabled, a synthetic sales party for the final journey and enough source stock for TAG GEN. Use an administrator, two independent operators with separate slots and a clerk whose menu rights and per-voucher update/delete flags can be varied. Duplicate identifiers in a second tenant/company/location/year supply isolation sentinels.

The smallest reusable voucher has two tags: A with gross 10.500, other weight 0.500, net 10.000; B with gross 5.250, other 0.250, net 5.000. Give each one distinct synthetic child (pieces 2 and 3). Single-tag cases use A only. Lot L32 has touch 92.00 and wastage 1.50, with source A, zero ghat and a blank-touch save variant; its expected A fine is 9.35. Manufacturing M32 supplies gross 10.500, other 0.500, net 10.000 and fine 9.200. Two order lines supply (source serial, size, pieces) (7,18,2) and (9,20,3). These are invented test inputs, not claims about production seed contents.

Provide a new voucher and an imported synthetic counterpart with explicitly retained raw NULL/scale/time/image sentinels, an unsold and a sold lifecycle state, and one unrelated voucher for print exclusion. Fixtures must record complete before-images and an explicit field-by-field print projection oracle; do not derive expected numbers from the candidate application. TAG choices A32/Z32 and QR choices B32/Q32 are synthetic PRINT_MAST identifiers with usable test render assets, plus one excluded other-type choice and other-company choices. They are not asserted to be actual Lite report names. Supply colors C32A/C32B, labour codes L32A/L32B and styles S32A/S32B for the print projection fixture.

Configuration variants are CNTR_STK Y/N, MsUserKrTouchHide Y/N, QR generation Y/N and both auto-feature switches Y/N. COL_MAST overrides rename TAG_DETL KrTouch to Artisan Touch, hide KrWst%, rename TAG_IDTL Pcs to Child Pieces and hide PcsWt; the second company retains defaults. Use scoped, temporary fault triggers at the listed boundaries and always remove them. Actual Lite template assets, printer and measured reference are external prerequisites only for the blocked physical-output case.

## Not covered

- No numbered study gap is entirely uncovered. Physical template geometry and the complete temporary-save recovery/write-set contract remain in the two blocked cases and in the coverage denominator.
- Full initial defaults, complete Tab/focus graph, all grid shortcuts and source lookup side effects beyond the listed lot/order/manufacturing values lack a complete study oracle. The architect decision limits this residual freeze to the documented controls and values; a source follow-up is needed before claiming full-screen equivalence.
- Typed karigar-block vectors, ordinary fine/wastage formulas, base create/edit/delete audit, voucher-box shortcuts and the Tag Stock report are already separate cases in `web/apps/web/test/features/modules/tagOpening.mjs`. They remain required in that module and are not re-specified here from unsupported study quotes. This list adds residual lifecycle checks without claiming replacement coverage.
- Tag Re Number, New Tag Img, Old New Tag, Jeson Creat, LastYear Idtl, Stk to Vch Imp, Excel and RFID are explicitly outside WP-32 study scope. Scale-device behaviour is outside this packet; only the documented external karigar sources are frozen here.
- No real data, template catalogue or physical print was inspected. Synthetic print choices prove filtering and selection, not which assets ship with Lite. No browser execution, database validation or desktop acceptance is claimed by freezing this list.

