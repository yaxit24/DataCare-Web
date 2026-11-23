# WP-35 — frozen case list: the blocked cases of Fine Jv, Party Opening, Item Opening, Open Company and Settings

Scope: this list freezes only the blocked, pending and skipped cases of the five modules named in
`orchestration/work/WP-35/study.md`. The green cases of each module stay as they are and are cited here by id so no
playbook kind is dropped silently. Every desktop rule is quoted from the study, whose quotes the citation check
verified (`108 citations: 108 verified by quote, 0 range only, 0 wrong`).

Case ids reuse the existing module ids where the behaviour is the same. The old blocked rows end in `.pending`
(e.g. `fine-jv.concurrency.pending`); the frozen case keeps the group and drops the status marker. A case marked
`blocked` is one that cannot be run yet for a reason outside this case list; the reason and what unblocks it are
in the case.

## Decisions taken under the owner's standing rule

Owner's rule: the desktop first; the web adds only what a hosted multi-user service needs to be safe and correct.
Each decision is recorded as: architect, 2026-11-23, owner may override.

| # | Study gap / open question | Decision | Basis |
|---|---|---|---|
| D1 | Gap 3, open question 5: Fine Jv T13 retry | A lost-acknowledgement replay must not create a second financial voucher: the create takes an `Idempotency-Key` (accepted D18, document 11 section 4, `api_command_receipt`); the same key and body replays the first answer, the same key with another body is `409 idempotency-key-reused`. The desktop renumbering of a taken number stays as the answer for two different requests that meet the same number. Corrected after Claude review: the first version chose the desktop renumber for a replay, which writes the fine legs twice. | TR_CONTRA.cs:2723 {{Current Voucher No has been changd New Voucher No is  '}} (a used number only; the desktop has no replay control) and the hosted-safety rule |
| D2 | Gap 2, G170: Fine Jv T12 concurrency | The web must use the existing version token. The wiring is missing code inside this menu, so the case is executable and fails today (not blocked). | The desktop has no check, but a hosted multi-user service must not let two operators overwrite each other; N51 version tokens exist in `modules/vouchers/version.ts`. |
| D3 | Gap 7, G209/G211: Party Opening T15 | The A/B data type and the A/B Merge are an Advance/Enterprise feature, not Lite. Lite is frozen as data type A only, with no B choice and no Merge button. | TR_AC_OPBL.cs:2519 {{tDataType.Text = "A";}} and MS_OPNCOMP.cs:612 {{DC_Main.MsSoftType = "L";}} |
| D4 | Gap 11: Settings T12 concurrency | The desktop rule is decided, not unknown: each button writes one column, so different settings by two administrators both survive and the same setting ends with the later value. The stale blocked reason is replaced by a real case. | UT_SETTING.cs:5014 {{DC_Main.RsQry = "UPDATE CO_SET SET LBR_ROF = " + Conversions.ToString(Conversion.Val(cbolbrrof.Text)) + " WHERE CO_CODE = '" + DC_Main.MCo_code + "'";}} |
| D5 | Gap 10, open question 4: Open Company last-day lock | The web does write `CO_SET.LOCK_DATE`, set to the system date minus one day on open, exactly as the desktop does. The case is therefore executable. Deviation to record: the desktop writes yesterday unconditionally; the web moves the lock forward only (`lastDayLock.ts`, an existing later lock date is kept), a hosted safety rule so opening a company cannot reopen a closed period. | MS_OPNCOMP.cs:1505 {{DC_Main.ExeQuteDc("UPDATE CO_SET SET LOCK_DATE = '}} |
| D6 | Gap 9: Open Company T02–T18 mapping | Refusals are the web's choice lists plus the server's `year-unavailable` / `location-unavailable` answers; the desktop "wrong code opens the help list" has no web text box, so it is not frozen as a typing case. | MS_OPNCOMP.cs:536 {{Select * From YEAR_MAST WHERE CO_CODE}} |
| D7 | Open question 6: registration and licence checks | Open Company's registration ids and phone number are not a Lite web feature and stay out of scope. | MS_OPNCOMP.cs:1999 {{Yor Regester Id Is Not Valid Please Contact  9879966455}} |
| D8 | Open question 3: RP_LEDR physical print for Fine Jv | The Fine Jv T18 case asserts the web ledger dataset and drill-down, which belong to this menu's frozen cases; the RP_LEDR physical layout belongs to the L6 report cases and is not re-frozen here. | TR_CONTRA.cs:2886 {{Ac_Ledr.Contra_Ledr(DC_Main.MCo_Book, tVchNo.Text);}} |
| D9 | Open question 1: Fine Jv screen, keyboard and print parameters | The blocked cases do not need the unread ranges; the green Fine Jv keyboard and print cases already cover them and are not re-frozen. | The green cases `fine-jv.keyboard.alt-s-saves`, `fine-jv.keyboard.voucher-number-enter-opens` and `fine-jv.print.fine-jv-bill` already exist. |
| D10 | Open question 2: Item Opening keyboard and Ac_Stock write set | No new keyboard case is frozen; the rollback case takes the table list from a measured web save, not from unread desktop lines. | TR_ITM_OPBL.cs:1453 {{DC_Main.RsQry = "DELETE FROM MAIN_STOCK}} |

## Gap map

Every gap in the study has at least one case that fails today because of it, or is listed under Not covered.

| Gap | Case(s) |
|---|---|
| 1 Fine Jv T14 rollback | `fine-jv.rollback.save`, `fine-jv.rollback.edit`, `fine-jv.rollback.delete` |
| 2 Fine Jv T12 concurrency | `fine-jv.concurrency.stale-second-save` (blocked, D2) |
| 3 Fine Jv T13 retry | `fine-jv.retry.idempotent-replay` (D1) |
| 4 Fine Jv T18 downstream report | `fine-jv.downstream-report` |
| 5 Party Opening T12 concurrency | `party-opening.concurrency.last-save-wins` |
| 6 Party Opening T14 rollback | `party-opening.rollback.save` |
| 7 Party Opening T15 config | `party-opening.config.data-type-a-only`, `party-opening.config.ab-merge` |
| 8 Item Opening T14 rollback | `item-opening.rollback.save`, `item-opening.rollback.delete` |
| 9 Open Company T02–T18 | `company-open.branches.year-choice-carried` and the other `company-open.*` cases |
| 10 Open Company last-day lock | `company-open.settings.last-day-lock` (D5) |
| 11 Settings T12 concurrency | `settings.concurrency.two-admins.different-settings`, `settings.concurrency.two-admins.same-setting` (D4) |
| 12 Settings T14 rollback | `settings.rollback.second-table-fault` |
| 13 Settings T15 variant company (G174) | Not covered: the settings consumer cases are green; see Not covered |
| 14 Fine Jv sign rule | `fine-jv.downstream-report` asserts the debit and credit sides |

## Fine Jv (`fine-jv`)

The blocked rows of `web/apps/web/test/features/modules/fineJv.mjs` are T12, T13, T14 (save/edit/delete) and T18.

| Kind | Disposition | Reason |
|---|---|---|
| T01 Entry/defaults | N/A | Green `fine-jv.entry.fine-jv-book-and-defaults`. |
| T02 Field route | N/A | Green `fine-jv.book.family-isolated`. |
| T03 Formula | N/A | Green `fine-jv.formula.three-decimal-fine`. |
| T04 Lookup | N/A | Green `fine-jv.refusal.unknown-account-no-write`. |
| T05 Children | N/A | Green `fine-jv.create.desktop-write-set` and `fine-jv.create.multi-account-grid`. |
| T06 Required/invalid | N/A | Green heavy refusals (`refusal.unequal-totals-no-write`, `refusal.date-outside-year-no-write`). |
| T07 Create | N/A | Green create cases prove the footprint. |
| T08 Reopen/no-op | N/A | Green `fine-jv.reopen.lossless`. |
| T09 Edit | N/A | Green `fine-jv.edit.unchanged-write-set` and `fine-jv.edit.reprice-metal`. |
| T10 Delete | N/A | Green `fine-jv.delete.audit-and-reversal`. |
| T11 Scope/rights | N/A | Green `fine-jv.scope.sentinel-tenant`, `rights.print-denied`, `rights.journal-routes-refuse-fine-jv-book`. |
| T12 Concurrency | Applied | One case, executable and failing until the version-token wiring lands (D2). |
| T13 Retry | Applied | One case (D1). |
| T14 Rollback | Applied | Three cases: save, edit, delete. |
| T15 Config/history | N/A | Green `fine-jv.settings.lock-date`. |
| T16 Report/output | N/A | Green `fine-jv.print.fine-jv-bill`. |
| T17 Keyboard | N/A | Green `fine-jv.keyboard.alt-s-saves` and `fine-jv.keyboard.voucher-number-enter-opens`. |
| T18 Full journey | Applied | One case: the ledger and its drill-down. |

### fine-jv.concurrency.stale-second-save   (T12 Concurrency)
Layer: browser
Steps: 1. Save a Fine Jv with two rows (DR E2ELOC 12.3456, CR E2EINT 12.3456, metal G) and keep its `VCH_NO` V.
2. Open `/txn/fine-jv` in two sessions of two operators and load V in both. 3. In session A change the fine to
11.0000 and save. 4. In session B, still holding the row it loaded, change the fine to 10.0000 and save.
Expected: B is refused with HTTP 409 `voucher-version-conflict` and the text "This voucher was changed by someone
else after you opened it. Reload it before saving or deleting."; the stored CONTRA_DATA row 2 has `DR_FINE` 11.0000
(A's save survives) and B reads 11.0000 after reload. The desktop lets the later save overwrite because it has no
check: TR_CONTRA.cs:2739 {{DC_Main.ExeQuteDc("DELETE FROM CONTRA_DATA WHERE CO_CODE}} rewrites the rows; the web
adds the version token because a hosted service must not lose a save.
Status: executable. Fails today: `web/apps/api/src/routes/fineJv.ts` GET/PUT/DELETE do not carry `expectedVersion` and
the page does not send it (study gap 2 / G170); the wiring is part of this menu (N51; `modules/vouchers/version.ts`
and the 409 mapping already exist). Corrected after Claude review: a missing feature of this menu is an expected
failure, not a block.
Gap: 2.

### fine-jv.retry.idempotent-replay   (T13 Retry)
Layer: browser
Steps: 1. Post a new Fine Jv (DR E2ELOC 12.3456, CR E2EINT 12.3456, metal G) with `Idempotency-Key` K1; record the
returned `vchNo` N. 2. Re-send the exact same request with K1 as a lost acknowledgement would. 3. Re-send K1 with
the fine changed to 11.0000. 4. Post the same body with a new key K2. 5. Read `CONTRA_DATA` and `AC_DATA`.
Expected: step 2 returns the first answer (same `vchNo` N) and there is exactly one voucher N with its two source rows
and its two ledger legs (fine 12.3456 once, not twice); step 3 is HTTP 409 `idempotency-key-reused` and writes
nothing; step 4 is a new request and takes the next number N+1 (after a fresh book N = 00001, N+1 = 00002), as the
desktop gives a new number when the typed one is taken: TR_CONTRA.cs:2723 {{Current Voucher No has been changd New Voucher No is  '}}.
Total fine legs after step 5: 2 vouchers x 12.3456 on each side, never 3.
Status: executable. Fails today: `POST /fine-jv` takes no idempotency key (`routes/fineJv.ts:105`). Decision D1.
Gap: 3.

### fine-jv.rollback.save   (T14 Rollback)
Layer: browser
Steps: 1. Through `/txn/fine-jv`, save DR E2ELOC 12.3456 / CR E2EINT 12.3456 and measure the tables the save
writes (expected `CONTRA_DATA`, `AC_DATA`, `ROJ_MEL_DATA`, `REMARK_DATA`; include `TEMP_BOOK_DATA` only if the
measured save writes it). 2. `rollbackMatrix(ctx, { tables: measured, book: 'FJV', headerTable: 'CONTRA_DATA',
submit })` where `submit` clicks Save on a fresh two-row screen. 3. For each faulted table read the tenant
fingerprint before and after and the `e2e_fault_pending` count. 4. Remove the fault and save the same screen again.
Expected: every faulted save answers 4xx and leaves every tenant table byte-identical; the last-written table found
the other write-set tables uncommitted (pendingElsewhere = tables.length−1); the successful save takes the number the
failed attempts did not consume and writes exactly the measured tables. The desktop has no transaction at all:
TR_CONTRA.cs:2739 {{DC_Main.ExeQuteDc("DELETE FROM CONTRA_DATA WHERE CO_CODE}} runs the deletes row by row, so a
half-written voucher is possible there; the web is all-or-nothing on purpose (fineJv.ts `withTxBudget`).
Status: executable. The blocked reason at `fineJv.mjs:830` is stale: `faults.mjs:64 rollbackMatrix` exists.
Gap: 1.

### fine-jv.rollback.edit   (T14 Rollback)
Layer: browser
Steps: 1. Create and measure a two-row Fine Jv; note its write set and number. 2. Load it, change the fine of row 2
to 11.0000, and fault each write-set table in turn with `rollbackMatrix` (same `tables`, `book: 'FJV'`,
`headerTable: 'CONTRA_DATA'`, `submit` clicks Update). 3. After each fault reopen the voucher and read its rows.
Expected: each faulted edit answers 4xx and every table is unchanged; the voucher still opens with the pre-edit fine
12.3456 in `CONTRA_DATA.DR_FINE`. The desktop rewrites the rows first and then rebuilds the ledger, remark and Rojmel
legs with no transaction: TR_CONTRA.cs:2739 {{DC_Main.ExeQuteDc("DELETE FROM CONTRA_DATA WHERE CO_CODE}}.
Status: executable.
Gap: 1.

### fine-jv.rollback.delete   (T14 Rollback)
Layer: browser
Steps: 1. Create a two-row Fine Jv; note its number and the tenant fingerprint. 2. Install a `BEFORE DELETE` trigger
on `CONTRA_DATA` for this tenant and book that raises once, then delete through the screen's Delete button. 3. Check
`CONTRA_DATA`, `AC_DATA`, `ROJ_MEL_DATA`, `REMARK_DATA`, `DELETE_DATA` and `TEMP_BOOK_DATA`. 4. Drop the trigger and
delete again.
Expected: the faulted delete answers 4xx and all tables (including `DELETE_DATA`, which is written before the source
rows) are unchanged; the voucher still opens and prints after the failure. The desktop writes the audit row first and
then deletes table by table with no transaction: TR_CONTRA.cs:2961 {{INSERT INTO DELETE_DATA}}. Removing the trigger
deletes the voucher once with "Delete Success." — TR_CONTRA.cs:2969 {{Delete Success.}} — and leaves no source rows.
Status: executable (per-case `BEFORE DELETE` trigger, as `contraEntry.mjs:823` uses a per-case trigger).
Gap: 1.

### fine-jv.downstream-report   (T18 Full journey)
Layer: browser
Steps: 1. Save a Fine Jv DR E2ELOC 12.3456, CR E2EINT 12.3456, metal G, description "bill line note"; record V.
2. Open `/reports/account-ledger`, Report "Ledger Detail", Account E2ELOC, Fine Gold, From/To spanning the voucher
date, Run. 3. Repeat for E2EINT. 4. Drill down from the E2ELOC row.
Expected: E2ELOC shows the voucher V on the debit side with fine 12.3456 (Cr Fine 0); E2EINT shows V on the credit
side with fine 12.3456 (Dr Fine 0); the account fine movement is +12.3456 Dr for E2ELOC and 12.3456 Cr for E2EINT, so
the two sides net to 12.3456 − 12.3456 = 0. The drill-down opens `/txn/fine-jv` with voucher V loaded and the same
two rows. The desktop writes the ledger and the Rojmel from the saved rows: TR_CONTRA.cs:2886 {{Ac_Ledr.Contra_Ledr(DC_Main.MCo_Book, tVchNo.Text);}} and TR_CONTRA.cs:2889 {{Ac_Rojmel.Contra_Rojmel(DC_Main.MCo_Book, tVchNo.Text);}}; the fine is CR_FINE from column 5 and DR_FINE from column 6 — TR_CONTRA.cs:2787 {{dataRow2["CR_FINE"] = Conversion.Val(mSG[DC_Main.i, 5]);}} and TR_CONTRA.cs:2788 {{dataRow2["DR_FINE"] = Conversion.Val(mSG[DC_Main.i, 6]);}}. Gap 14: this case also asserts the sign, so a reversed CR/DR shows up here.
Status: executable.
Gap: 4, 14.

## Party Opening (`party-opening`)

The blocked rows of `web/apps/web/test/features/modules/partyOpening.mjs` are T12, T14 and T15.

| Kind | Disposition | Reason |
|---|---|---|
| T01 Entry/defaults | N/A | Green `party-opening.entry.defaults`. |
| T02 Field route | N/A | Green `party-opening.field.gold-sign`. |
| T03 Formula | N/A | Green `party-opening.formula.rounding`. |
| T04 Lookup | N/A | Green `party-opening.lookup.switch-party`. |
| T05 Children | N/A | Green `party-opening.children.bill-rows`. |
| T06 Required/invalid | N/A | Green `party-opening.refusal.no-party`. |
| T07 Create | N/A | Green `party-opening.create.amount-and-gold`. |
| T08 Reopen/no-op | N/A | Green `party-opening.reopen.unchanged-save`. |
| T09 Edit | N/A | Green `party-opening.edit.replaces-legs`. |
| T10 Delete | N/A | Green `party-opening.delete.audit-and-remove`. |
| T11 Scope/rights | N/A | Green `party-opening.rights.desktop-row`. |
| T12 Concurrency | Applied | One case: last save wins. |
| T13 Retry | N/A | Green `party-opening.retry.double-save`. |
| T14 Rollback | Applied | One case, blocked on a harness number-check override. |
| T15 Config/history | Applied | One Lite check, plus the A/B Merge as N/A (D3). |
| T16 Report/output | N/A | Green `party-opening.output.list-by-type`. |
| T17 Keyboard | Applied | One case: Esc and the upper-case/apostrophe keys. |
| T18 Full journey | N/A | Green `party-opening.journey.balance-on-receipt`. |

### party-opening.concurrency.last-save-wins   (T12 Concurrency)
Layer: browser
Steps: 1. In two sessions of two operators open `/txn/ac-opbl` and pick E2EINT. 2. Operator A sets Opening Amount
777 Cr and saves (200). 3. Operator B, which loaded before A's save, sets Opening Amount 888 Cr and saves.
4. Read `OP_DATA` and the opening legs for E2EINT.
Expected: the stored opening is the later save: exactly one `OP_DATA` row with `VCH_NO` '00000' and `OP_AMT` 888,
`OP_SIGN` 'C'; exactly one amount leg with `DR_AMT` 0 and `CR_AMT` 888; no second row and no mixed 777/888 state.
The desktop deletes and rewrites the party's row with no check, so the last save wins: TR_AC_OPBL.cs:2694 {{DELETE FROM OP_DATA WHERE CO_CODE}} and TR_AC_OPBL.cs:2710 {{dataRow["OP_SIGN"] = Strings.Mid(cboAmt.Text, 1, 1);}}. No version token is wanted here: the desktop has none, and the web serialises the two saves on the account row.
Status: executable (the second slot is the pattern `companyOpen.mjs` uses with four sessions).
Gap: 5.

### party-opening.rollback.save   (T14 Rollback)
Layer: browser
Steps: 1. Save a Party Opening for E2EINT with two bill rows so the save writes `OP_DATA`, `OP_DETL` and `AC_DATA`.
2. `rollbackMatrix(ctx, { tables: ['OP_DATA','OP_DETL','AC_DATA'], book: '000', headerTable: 'OP_DATA', submit,
voucherNoOf: async () => '00000' })` with the harness's "no number check" option. 3. For each fault read the tenant
fingerprint before and after. 4. Remove the fault and save again.
Expected: every faulted save answers 4xx and every tenant table is unchanged — no `OP_DATA` row, no `OP_DETL` rows
and no ledger legs. The desktop commits the opening before writing the legs in a second transaction, so a leg failure
leaves an opening without legs: TR_AC_OPBL.cs:2765 {{Tran.Commit();}} before TR_AC_OPBL.cs:2773 {{Module_Save.TranPosting = DC_Main.Dc.BeginTransaction();}}, and only the second transaction rolls back at TR_AC_OPBL.cs:2785 {{Module_Save.TranPosting.Rollback();}}. The web is one transaction on purpose.
Status: blocked: `faults.mjs:64 rollbackMatrix` assumes a numeric voucher number (`nextVoucherNo` and the
number-unchanged check); Party Opening stores the fixed '00000' — TR_AC_OPBL.cs:2706 {{dataRow["VCH_NO"] = "00000";}}.
Unblocks when the T14 test packet adds a skip-number-check/no-number option to the helper (harness change, not this
case list).
Gap: 6.

### party-opening.config.data-type-a-only   (T15 Config/history)
Layer: browser
Steps: 1. Open `/txn/ac-opbl` in the Lite edition. 2. Look for the desktop A/B data-type box (`tDataType`, A or B) and an A/B Merge button. 3. Save an opening for E2EINT (amount 100 Cr) and read
`OP_DATA.DATA_TYPE`.
Expected: there is no B data-type choice and no A/B Merge button; the stored `DATA_TYPE` is 'A'. This is Lite, where
the desktop sets the edition first — MS_OPNCOMP.cs:612 {{DC_Main.MsSoftType = "L";}} — and forces the single type —
TR_AC_OPBL.cs:2519 {{tDataType.Text = "A";}} — because the A/B box exists only for Advance and Enterprise: TR_AC_OPBL.cs:2499 {{if ((Operators.CompareString(DC_Main.MsSoftType, "A", false) == 0) | (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0))}}.
Status: executable (D3).
Gap: 7.

### party-opening.config.ab-merge   (T15 Config/history)
Layer: browser
Steps: 1. Open `/txn/ac-opbl` in Lite. 2. Look for the A/B Merge action.
Expected: no A/B Merge action exists. It is an Advance/Enterprise feature: TR_AC_OPBL.cs:3387 {{A And B Data Merge Transfer...}}, behind the same edition test at TR_AC_OPBL.cs:2499 {{if ((Operators.CompareString(DC_Main.MsSoftType, "A", false) == 0) | (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0))}}, and is not to be built for Lite.
Status: N/A: Advance/Enterprise only (D3). This row is kept so T15 is not dropped silently.
Gap: 7.

### party-opening.keyboard.esc-and-keys   (T17 Keyboard/usability)
Layer: browser
Steps: 1. Open `/txn/ac-opbl`, pick E2EINT, change nothing and press Esc. 2. Reopen, change Opening Amount
from the loaded value without saving and press Esc. 3. Type a lower-case letter and
an apostrophe into a text field.
Expected: with nothing changed Esc closes the form; with a changed total Esc leaves the cell editor and puts focus on
Save instead of closing — TR_AC_OPBL.cs:2924 {{if ((int)e.KeyCode == 27)}} (the form closes only when the changed
total equals the old total). Typed letters are upper-cased and the apostrophe is swallowed —
TR_AC_OPBL.cs:2916 {{if (num == 0 || num == 39)}}.
Status: executable.
Gap: 7 (keyboard described for the Lite/blocked screen; no existing Party Opening keyboard case).

## Item Opening (`item-opening`)

The blocked row of `web/apps/web/test/features/modules/itemOpening.mjs` is T14.

| Kind | Disposition | Reason |
|---|---|---|
| T01 Entry/defaults | N/A | Green `item-opening.entry.type-grid`. |
| T02 Field route | N/A | Green `item-opening.field.every-cell`. |
| T03 Formula | N/A | Green `item-opening.formula.sequence`. |
| T04 Lookup | N/A | Green `item-opening.lookup.change-type`. |
| T05 Children | N/A | Green `item-opening.children.two-types-row-gaps`. |
| T06 Required/invalid | N/A | Green `item-opening.refusal.type-and-item`. |
| T07 Create | N/A | Green `item-opening.create.footprint`. |
| T08 Reopen/no-op | N/A | Green `item-opening.reopen.unchanged-imported`. |
| T09 Edit | N/A | Green `item-opening.edit.gross-only`. |
| T10 Delete | N/A | Green `item-opening.delete.type`. |
| T11 Scope/rights | N/A | Green `item-opening.rights.view-only`. |
| T12 Concurrency | N/A | Green `item-opening.concurrency.two-operators`. |
| T13 Retry | N/A | Green `item-opening.retry.replayed-save`. |
| T14 Rollback | Applied | Two cases: save and delete. |
| T15 Config/history | N/A | Green `item-opening.history.other-year`. |
| T16 Report/output | N/A | Green `item-opening.output.item-stock-ledger`. |
| T17 Keyboard | N/A | Green `item-opening.keyboard.desktop-keys` and `keyboard.esc-with-focus-on-the-page`. |
| T18 Full journey | N/A | Green `item-opening.journey.open-then-sell`. |

### item-opening.rollback.save   (T14 Rollback)
Layer: browser
Steps: 1. Through `/txn/item-opening` load metal type G and enter one GLD22 row with pieces 1 and gross 5.000;
measure the tables a real save writes (the web names `ITM_OPBL`, `MAIN_STOCK`, `DM_DATA`, `BAR_DATA`; use the
measured set). 2. `rollbackMatrix` with that table list, `book: '000'`, `headerTable: 'ITM_OPBL'`, `submit` = Save,
and a voucher-number override (the key is the metal letter, not a number). 3. Read the tenant fingerprint for each
fault. 4. Remove the fault and save again.
Expected: every faulted save answers 4xx and every tenant table is unchanged — no `ITM_OPBL`, `MAIN_STOCK`, `DM_DATA`
or `BAR_DATA` change. The desktop runs the statements one after another with no transaction — it deletes the rows
with TR_ITM_OPBL.cs:1414 {{DC_Main.OpenRecordSetDc("DELETE FROM ITM_OPBL}} then rebuilds the stock with
TR_ITM_OPBL.cs:1453 {{DC_Main.RsQry = "DELETE FROM MAIN_STOCK}} — so a failure leaves a half-written opening there;
the web is one transaction on purpose (stockVoucherLifecycle.ts:1022). Only rows with pieces or gross are saved:
TR_ITM_OPBL.cs:1423 {{if (Conversion.Val(MSG[DC_Main.i, 5]) + Conversion.Val(MSG[DC_Main.i, 4]) != 0.0)}}.
Status: blocked: `faults.mjs:64 rollbackMatrix` casts `VCH_NO` to int in `nextVoucherNo`, but Item Opening stores the
metal letter (TR_ITM_OPBL.cs:1414 {{DC_Main.OpenRecordSetDc("DELETE FROM ITM_OPBL}}; key VCH_NO = 'G'). Unblocks when
the T14 test packet adds a no-number override (harness change, not this case list), and the table list is confirmed
from a measured save.
Gap: 8.

### item-opening.rollback.delete   (T14 Rollback)
Layer: browser
Steps: 1. Save the gold opening from the save case so it writes `ITM_OPBL`, `MAIN_STOCK`, `DM_DATA`. 2. Install a
`BEFORE DELETE` trigger that raises on one of the three tables in turn; press Delete for type G. 3. Compare every
table with the pre-delete fingerprint. 4. Drop the trigger and delete again.
Expected: each faulted delete answers 4xx and no table changes; the opening still shows and the stock is still posted.
The desktop deletes `MAIN_STOCK` (:1509), `DM_DATA` (:1511) and `ITM_OPBL` (:1513) with no transaction, so a failure
leaves a partial delete there; removing the trigger deletes all three once with TR_ITM_OPBL.cs:1514 {{Delete Success.}}.
Status: blocked: same harness gap as the save case (a per-case `BEFORE DELETE` trigger exists in `contraEntry.mjs`, but
the delete-rollback helper/no-number override is not built yet). Unblocks with the T14 test packet.
Gap: 8.

## Open Company (`company-open`, desktop MS_OPNCOMP, web `/select`)

Only T01 and T12 are green today; the other sixteen rows are `*.pending` in `companyOpen.mjs`. The study's proposed
split (gap 9) is frozen below.

| Kind | Disposition | Reason |
|---|---|---|
| T01 Entry/defaults | N/A | Green `company-open.entry.lists-choices`. |
| T02 Field route | Applied | The chosen year is carried into the session. |
| T03 Formula | N/A | The form computes nothing the operator sees; the database-name and month-wise-year rules are provisioning internals and the Lite fixture has no month-wise company. |
| T04 Refusals | Applied | A stale year/location is refused by the server; the desktop "wrong code opens the help list" has no web text box (D6). |
| T05 Children | N/A | The form has no child rows. |
| T06 Required/invalid | N/A | Validity is the choice lists (covered by T04); there is no free numeric entry. |
| T07 Reopen | Applied | The year list defaults to the newest. |
| T08 Unchanged save | N/A | The form has no save. |
| T09 Edit | N/A | The form edits no stored record. |
| T10 Delete | N/A | The form deletes nothing. |
| T11 Scope/rights | Applied | One case, blocked on a second location and a non-A user type. |
| T12 Concurrency | N/A | Green `company-open.concurrency.sessions-open-at-once`. |
| T13 Retry | Applied | Replayed selection applies once. |
| T14 Rollback | Applied | A faulted open leaves the old company. |
| T15 Config/history | Applied | Last-day lock and the settings in force. |
| T16 Output | N/A | The form has no print or export. |
| T17 Keyboard | Applied | Tab order and Enter. |
| T18 Full journey | Applied | Login → Open → dashboard. |

### company-open.branches.year-choice-carried   (T02 Field route)
Layer: browser
Steps: 1. Sign in and open `/select`; choose company 01 and Financial Year 2024-2025. 2. Press Open and land on
`/dashboard`. 3. Reload `/select` and read the Financial Year select and the session scope.
Expected: the session's `coYear` is 2024-2025 and `/select` shows 2024-2025 selected; a later voucher dated
2024-06-01 is accepted and one dated outside 2024-2025 is refused as outside the year. The desktop opens the chosen
year's database: MS_OPNCOMP.cs:598 {{DC_Main.SqlData = "Next" + Strings.Mid(DC_Main.MCo_year, 3, 2);}}.
Status: executable (the fixture has the current fiscal year and 2024-2025).
Gap: 9.

### company-open.refusals.stale-choice-refused   (T04 Refusals)
Layer: browser
Steps: 1. Override the loaded year so the next Open sends a year the company does not have (e.g. 1999-2000) with a
valid location; submit `/context/select`. 2. Repeat with a location code the company does not have. 3. Read the
session scope and the screen message after each.
Expected: the year attempt answers HTTP 409 `{error: "year-unavailable"}` and the location attempt HTTP 409
`{error: "location-unavailable"}`; the session still has the previous company, location and year; failing that while
on `/select` shows "Selected year is not available." or "Selected location is not available." and the dashboard is not
reached. The desktop re-opens the help list for a year not in the company's years:
MS_OPNCOMP.cs:536 {{Select * From YEAR_MAST WHERE CO_CODE}}.
Status: executable.
Gap: 9.

### company-open.reopen.year-newest-default   (T07 Reopen)
Layer: browser
Steps: 1. Open `/select` for a tenant with the current fiscal year and 2024-2025. 2. Read the Financial Year options
in order and the selected value.
Expected: the options are newest first — the current fiscal year y first, then 2024-2025 — and y is selected by
default when no year is on the session. On 2026-11-23 y = 2026-2027, so the list is 2026-2027, 2024-2025. The desktop
orders the year list newest first: MS_OPNCOMP.cs:487 {{SELECT * FROM YEAR_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' ORDER BY CO_YEAR DESC}}. Today the web orders ascending (`businessScope.ts listScopeYears` `ORDER BY 1`), so this case fails until that is fixed.
Status: executable.
Gap: 9.

### company-open.rights.location-scope   (T11 Scope/rights)
Layer: browser
Steps: 1. Provision a second location LC2 for company 01. 2. Sign in as a user whose home location is 01 (user type
B) and open `/select`; read the Location options. 3. Repeat as an administrator (user type A) whose home location is 01.
4. Repeat as an administrator whose home location is the company-wide "00".
Expected: the desktop tests the home location first. With a home location other than "00" the user, of any type,
may open only that location (`MS_OPNCOMP.cs:4401 {{if ((Operators.CompareString(DC_Main.CurLc, "00", false) != 0) & (Operators.CompareString(tlcCode.Text, "", false) != 0))}}`):
steps 2 and 3 list only 01. Only with home "00" does user type A reach every location
(`MS_OPNCOMP.cs:4405 {{else if (Operators.CompareString(DC_Main.MCo_UserType, "A", false) == 0)}}`): step 4 lists 01 and
LC2; a non-A user with home "00" is held to location "00" by the last branch. Corrected after Claude review: the first
version said an A user always sees every location. Today `listScopeLocations` returns every location of the company, so
steps 2 and 3 fail once the case can run.
Status: blocked: the catalogue has one location and no non-A user type or home-location setting; unblocks when the
fixture pack adds a second location and a user-type-B user (fixtures work package, outside this case list).
Gap: 9.

### company-open.retry.replayed-selection   (T13 Retry)
Layer: browser
Steps: 1. Open `/select` and press Open once; capture the exact `POST /context/select` request body (same
`selectionId`). 2. Send that body a second time from the same session. 3. Read the response's `replayed` flag and
`CO_SET.LOCK_DATE`; reload `/select`.
Expected: the second answer is HTTP 200 with `replayed: true`, not a second context change; `LOCK_DATE` is the same
value after both calls (when LAST_DAY_LOCK='Y' it is set once to yesterday, never twice); the session still shows one
company, one location and one year. G172: the screen retries a raw `context-transaction-conflict` and the server
replays a selection that already committed; a lost acknowledgement must not apply a company change twice. The desktop
opens the single modal company form once: MDI_FORM.cs:7562 {{((Form)MyProject.Forms.MS_OPNCOMP).ShowDialog();}}.
Status: executable.
Gap: 9.

### company-open.rollback.fault   (T14 Rollback)
Layer: browser
Steps: 1. Set `CO_SET.LAST_DAY_LOCK='Y'` and clear `LOCK_DATE`. 2. Install a fault that makes the context-selection
transaction fail after it starts (a `BEFORE UPDATE` trigger that raises on `auth_session` for this tenant, or an
equivalent server fault). 3. On `/select` press Open. 4. Read the session, `LOCK_DATE` and the screen message.
5. Remove the fault and press Open again.
Expected: the failed open answers 4xx and the previous company, location and year are still the session's; the
dashboard still shows the old company and `CO_SET.LOCK_DATE` is unchanged, so the last-day lock write rolled back with
the scope change. Removing the fault opens the company and sets `LOCK_DATE` to yesterday. The context switch is one
serializable command (`sessionContextSelection.ts:492`); the desktop writes the settings and the lock date on open — MS_OPNCOMP.cs:1505 {{DC_Main.ExeQuteDc("UPDATE CO_SET SET LOCK_DATE = '}} — and MS_OPNCOMP.cs:666 {{DC_Main.MsLockDt = Conversions.ToDate}}.
Status: executable.
Gap: 9.

### company-open.settings.last-day-lock   (T15 Config/history)
Layer: browser
Steps: 1. Set `CO_SET.LAST_DAY_LOCK='Y'` and clear `CO_SET.LOCK_DATE` for company 01. 2. Open `/select` and press
Open. 3. Read `CO_SET.LOCK_DATE` and the returned `lastDayLock`. 4. Save a voucher dated today and one dated
yesterday.
Expected: after open, `LOCK_DATE` is the system date minus one day (on 2026-11-23, 2026-11-22) and `lastDayLock.applied`
is true; a voucher dated 2026-11-22 is refused by the lock gate and one dated 2026-11-23 saves. The desktop sets the
lock date on open when the setting is Y: MS_OPNCOMP.cs:1503 {{if (Operators.CompareString(DC_Main.MsLastDayLock, "Y", false) == 0)}} then MS_OPNCOMP.cs:1505 {{DC_Main.ExeQuteDc("UPDATE CO_SET SET LOCK_DATE = '}} (set to yesterday). The web keeps the lock moving forward only; a later existing lock date is left untouched.
Status: executable (D5; the web's `applyLastDayLockTx` is the implementation).
Gap: 9, 10.

### company-open.settings.settings-in-force   (T15 Config/history)
Layer: browser
Steps: 1. Provision a second company 02 in the same tenant with `TAX_ROF` 0 and `LBR_ROF` 5, while company 01 keeps
`TAX_ROF` blank and `LBR_ROF` 0. 2. Open company 01, make a sale, note the tax rounding. 3. Open company 02, make the
same sale, note the tax rounding and the labour rate. 4. Reopen company 01 and make the sale again.
Expected: company 01 uses its own rounding and labour rate, company 02 uses `TAX_ROF` 0 and `LBR_ROF` 5, and reopening
01 restores 01's values; no company inherits the other's settings. The desktop loads the company's settings into the
running variables on open: MS_OPNCOMP.cs:668 {{object Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Rshlp.Rows[0])["TAX_ROF"]);}} and MS_OPNCOMP.cs:691 {{DC_Main.MsLbrRof = Conversions.ToInteger(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["LBR_ROF"], (object)""));}}.
Status: blocked: G174 — the catalogue provisions one company, so there is no second company with different
settings to compare. Unblocks when the fixture pack adds the settings-variant company (fixtures work package).
Gap: 9.

### company-open.keyboard.tab-and-enter   (T17 Keyboard/usability)
Layer: browser
Steps: 1. Open `/select` and use only the keyboard: focus the Company list, choose a company with the arrow keys and
Enter, then Tab. 2. Note where focus is; Tab to Financial Year, then to Open, and press Enter. 3. Repeat from the
Location list.
Expected: the Tab order is Company → Location → Financial Year → Open; accepting the company moves focus to the
Location list; Enter on Open reaches `/dashboard`. The desktop moves the focus from the company box to the location
box when the code is accepted — MS_OPNCOMP.cs:493 {{((Control)tlcCode).Focus();}} — and accepts only Enter in the
code boxes: MS_OPNCOMP.cs:4396 {{if ((int)e.KeyCode != 13)}}. The web replaces the three text boxes with choice
lists, so the case asserts the same order and Enter behaviour, not typing a code.
Status: executable.
Gap: 9.

### company-open.journey.open-then-dashboard   (T18 Full journey)
Layer: browser
Steps: 1. Sign in as the administrator and land on `/select`. 2. Open company 01, location 01 and the current fiscal
year. 3. Read the dashboard heading and the session scope. 4. Sign out and sign in again.
Expected: the dashboard loads with company 01 and the chosen year, and the session context is coCode 01, lcCode 01,
coYear y (the year the operator chose); after signing out and in the login company is 01 and the previous choice is
not silently changed. The desktop opens the company and then shows the main screen after the modal form:
MDI_FORM.cs:7562 {{((Form)MyProject.Forms.MS_OPNCOMP).ShowDialog();}}.
Status: executable.
Gap: 9.

## Settings (`settings`)

The blocked rows of `web/apps/web/test/features/modules/settingsEffects.mjs` are T12 and T14.

| Kind | Disposition | Reason |
|---|---|---|
| T01 Entry/defaults | N/A | Green `settings.entry.all-settings`. |
| T02 Field route | N/A | Green `settings.field.route-and-reload`, `field.pan-limit-any-amount`, `field.grid-row-height-whole-number`. |
| T03 Formula | N/A | Green `settings.formula.n-a`: the settings screen computes nothing; the effects are the green T15 consumer cases. |
| T04 Lookup | N/A | Green `settings.lookup.n-a`. |
| T05 Children | N/A | Green `settings.children.n-a`. |
| T06 Required/invalid | N/A | Green `settings.refusal.invalid-cash-limit`. |
| T07 Create | N/A | Green `settings.create.n-a`. |
| T08 Reopen/no-op | N/A | Green `settings.reopen.n-a` (the reload in `field.route-and-reload`). |
| T09 Edit | N/A | Green `settings.edit.n-a`. |
| T10 Delete | N/A | Green `settings.delete.n-a`. |
| T11 Scope/rights | N/A | Green `settings.rights.clerk-cannot-change`. |
| T12 Concurrency | Applied | Two cases: different settings and the same setting. |
| T13 Retry | N/A | Green `settings.retry.n-a`. |
| T14 Rollback | Applied | One case: a fault on the second table. |
| T15 Config/history | N/A | Green `settings.effect.*` consumer cases. |
| T16 Output | N/A | Green `settings.output.n-a`. |
| T17 Keyboard | N/A | Green `settings.keyboard.n-a`. |
| T18 Full journey | N/A | Green `settings.journey.n-a` (the consumer cases are the journey). |

### settings.concurrency.two-admins.different-settings   (T12 Concurrency)
Layer: browser
Steps: 1. Open `/settings` in two administrator sessions (a second slot). 2. Admin A saves `CO_SET.CASH_LIMIT` =
50000. 3. Admin B, which loaded before A's save, saves `CO_SET_NEW.TOT_AMT_ROF` = 1. 4. Read `CO_SET.CASH_LIMIT` and
`CO_SET_NEW.TOT_AMT_ROF`.
Expected: both values survive — `CASH_LIMIT` 50000 in `CO_SET` and `TOT_AMT_ROF` 1 in `CO_SET_NEW` — because each
desktop button writes one column: UT_SETTING.cs:5014 {{DC_Main.RsQry = "UPDATE CO_SET SET LBR_ROF = " + Conversions.ToString(Conversion.Val(cbolbrrof.Text)) + " WHERE CO_CODE = '" + DC_Main.MCo_code + "'";}} and UT_SETTING.cs:4912 {{UPDATE CO_SET SET RATE_PAR = '}}. The web's `saveSettings` likewise writes only the keys sent (`UPDATE ... SET ${sets}`).
Status: executable (D4).
Gap: 11.

### settings.concurrency.two-admins.same-setting   (T12 Concurrency)
Layer: browser
Steps: 1. Open `/settings` in two administrator sessions. 2. Admin A saves `CO_SET.CASH_LIMIT` = 50000. 3. Admin B,
which loaded before A's save, saves `CO_SET.CASH_LIMIT` = 60000. 4. Read `CO_SET.CASH_LIMIT`.
Expected: the later save wins: `CASH_LIMIT` = 60000. Two different columns never overwrite each other, and the same
column ends with the last statement, exactly as one desktop button writing one column behaves:
UT_SETTING.cs:5014 {{DC_Main.RsQry = "UPDATE CO_SET SET LBR_ROF = " + Conversions.ToString(Conversion.Val(cbolbrrof.Text)) + " WHERE CO_CODE = '" + DC_Main.MCo_code + "'";}}.
Status: executable (D4).
Gap: 11.

### settings.rollback.second-table-fault   (T14 Rollback)
Layer: browser
Steps: 1. Note `CO_SET.CASH_LIMIT` (table `CO_SET`) and `CO_SET_NEW.TOT_AMT_ROF` (table `CO_SET_NEW`). 2. Install a
`BEFORE UPDATE` trigger on `CO_SET_NEW` that raises for this tenant. 3. Through `/settings` save a patch containing
both `CO_SET.CASH_LIMIT` = 50000 and `CO_SET_NEW.TOT_AMT_ROF` = 1. 4. Read both values, the screen error, then drop
the trigger and save both again.
Expected: the save answers 4xx and shows an error; `CO_SET.CASH_LIMIT` is unchanged (the first table's UPDATE rolled
back) and `CO_SET_NEW.TOT_AMT_ROF` is unchanged; no half-applied save. With the trigger gone, one save stores
`CASH_LIMIT` 50000 and `TOT_AMT_ROF` 1 together. The desktop writes one column per button with no cross-table
transaction: UT_SETTING.cs:5014 {{DC_Main.RsQry = "UPDATE CO_SET SET LBR_ROF = " + Conversions.ToString(Conversion.Val(cbolbrrof.Text)) + " WHERE CO_CODE = '" + DC_Main.MCo_code + "'";}};
the web writes both tables in one transaction on purpose (`settings.ts` `TABLES` loop inside `withTxBudget`).
Status: executable (a per-case `BEFORE UPDATE` trigger, as `contraEntry.mjs:823` uses a per-case trigger).
Gap: 12.

## Coverage table

One row per playbook kind. "Cases" counts the cases written for the blocked work of the five modules; "Blocked"
counts those whose Status is blocked.

| Kind | Cases | Blocked |
|---|---|---|
| T01 Entry/defaults | 0 | 0 (all five modules green) |
| T02 Field route | 1 | 0 |
| T03 Formula | 0 | 0 (all green; Open Company computes nothing visible) |
| T04 Lookup/refusals | 1 | 0 |
| T05 Children | 0 | 0 (all green; Open Company has none) |
| T06 Required/invalid | 0 | 0 (all green) |
| T07 Create/reopen | 1 | 0 |
| T08 Reopen/no-op | 0 | 0 (all green; Open Company has no save) |
| T09 Edit | 0 | 0 (all green; Open Company has none) |
| T10 Delete | 0 | 0 (all green; Open Company has none) |
| T11 Scope/rights | 1 | 1 (company-open needs fixture) |
| T12 Concurrency | 4 | 0 (fine-jv fails until the version slice lands) |
| T13 Retry | 2 | 0 |
| T14 Rollback | 8 | 3 (party/item opening need the harness override) |
| T15 Config/history | 3 | 1 (company-open needs the second company) |
| T16 Report/output | 0 | 0 (all green) |
| T17 Keyboard | 2 | 0 |
| T18 Full journey | 2 | 0 |
| **Total** | **25** | **5** |

N/A rows are not counted as cases; they are listed in each module's disposition table with the green case or the
reason they do not apply.

## Test data

The smallest seed data the cases need, described (not SQL):

- **Base catalogue (already provisioned):** company 01 "E2E Jeweller", location 01, the current fiscal year plus
  2024-2025, the users `e2eadmin` (ADMIN), `e2eclerk` and `e2eprint`, items GLD22 (gold) and SLV92 (silver), parties
  E2ELOC (local, PAN ABCDE1234F), E2EINT (inter-state) and E2EBANK, and the opening stock of 500 g gold and 2,000 g
  silver.
- **Fine Jv:** the provisioned FJV book; test vouchers DR E2ELOC fine 12.3456 / CR E2EINT fine 12.3456, metal G. For
  the rollback matrix, a fresh name-numbered voucher in that book.
- **Party Opening:** E2EINT with a saved opening (amount 777 Cr, then 888 Cr for the concurrency case) and, for the
  rollback save, a party opening with two bill rows so `OP_DETL` is written. The fixed opening number is '00000' in
  book '000'.
- **Item Opening:** the gold grid row for GLD22 with pieces 1 and gross 5.000 in book '000'; a delete of type G. The
  voucher number is the letter G.
- **Open Company:** the two existing years (current fiscal year, 2024-2025). For the last-day-lock case,
  `LAST_DAY_LOCK='Y'` with `LOCK_DATE` cleared. The rights and settings-in-force cases need fixtures that do not
  exist yet: a second location LC2 with a user-type-B user, and a second company 02 with different `TAX_ROF`/`LBR_ROF`.
- **Settings:** `CO_SET.CASH_LIMIT` and `CO_SET_NEW.TOT_AMT_ROF`, both already present after provisioning; a second
  administrator slot; a patch carrying one setting from each table for the rollback case.

## Not covered

- **Gap 13, settings-variant company (G174) for other modules.** Not in this packet's blocked list and not needed by
  the settings consumer cases, which change a setting and restore it. If G174 needs a catalogue variant company, it
  belongs to the fixtures work package.
- **Open Company registration and licence checks** (`MS_OPNCOMP` around lines 1798–2009, including the "ABC" bypass and
  the phone-number message). Not a Lite web feature (D7); no case is frozen.
- **Month-wise company year.** The desktop shows a month box only for a month-wise year:
  MS_OPNCOMP.cs:582 {{((Control)tMonth).Visible = true;}} and builds the year as
  MS_OPNCOMP.cs:583 {{DC_Main.MCo_year = Strings.Mid(tYearCode.Text, 1, 4) + tMonth.Text;}}. The Lite fixture has no
  month-wise company and the web has no month box, so no case is frozen; if a month-wise company enters Lite, a T02
  case is needed.
- **RP_LEDR physical print layout for FINE JV rows.** The T18 case asserts the web ledger dataset and drill-down, not
  the printed RP_LEDR page; the physical layout belongs to the L6 report cases (D8).
- **Fine Jv print parameters and unread screen/keyboard ranges** (`TR_CONTRA` InitializeComponent, the print routine
  beyond the template choice, and the key handlers). The green Fine Jv print and keyboard cases cover the web; no new
  case is frozen (D9).
- **Item Opening keyboard and the `Ac_Stock` write sets not read from the desktop.** The green Item Opening keyboard
  cases cover the web, and the rollback cases take the table list from a measured web save (D10).
- **Open Company's desktop MDI "please close all open forms" refusal** (MDI_FORM.cs:7559 {{Please First Close All Open Form And Try...}}). There is no web MDI and `/select` is reached by navigation, so no case is frozen.
