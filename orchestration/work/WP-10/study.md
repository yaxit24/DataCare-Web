# WP-10 study: typed-number race audit (the G241 pattern)

Status: complete for the server create routes and for the two pages that pre-fill a number. No code changed, nothing committed, no database run (no Docker); every web statement is from reading code at `main`.

## Scope

Question: when two users of one book save, or when an operator types a voucher number, can the web issue a duplicate number, silently replace the typed number, or report a collision differently from the desktop? G241 fixed one page (Tag Cancel: a late next-number answer replaced a typed number, `docs/master-parity-plan-2026-09-29/12-lineage-verification-2026-10-01.md:256`) and noted "the same race can exist in other voucher forms that fill a next number on entry; not checked here" (same file, `:2596`). `docs/parity/LITE-MASTER-PLAN.md:318` lists WP-10 as "Every voucher form with a next number read"; WP-04 (replay idempotency, `:312`, PR #229) is a separate defect (a replayed request gets a second, different number) and is only recorded here as a column.

Inventory: the 83 voucher create routes that allocate a number (all of `NOT_YET_GUARDED` and `GUARDED` in `web/apps/api/test/idempotencyRoutePolicy.test.ts:59`, plus `/crm/customer-entries` and `/reminder-entries`, which are outside that list). Six policy-list routes allocate no voucher number and are out of the counts: `/estimate` (calculation only, `routes/txn.ts:1459`), `/daily-rate` (keyed by date), `/ac-opbl` (keyed by party), `/members` (member number), `/stock/tags` (tag serial from `SRNO_MAST`, `numbering.ts:181`), `/tour/:vchNo/bill` (contained, not reachable). Out of scope: PUT and DELETE, except where a PUT can create (finding F2).

## Result in one paragraph

The server is mostly sound. Every create route but one takes its number from `nextVoucherNoTx` or `createIdentityTx` inside the same transaction as the insert, under a transaction-scoped advisory lock on the full scope, and no HTTP create accepts a typed number. So the typed number cannot collide on a create: it is ignored. The defects are (F1) one writer with no lock, (F2) six PUT routes that create at a typed number without the lock, (F3) one page with the unfixed G241 race, (F4) three pages that drop a typed number without the desktop notice, and (F5) the headline header tables (sales, purchase, cash, wholesale, orders, tag, stock) have no database unique key on the voucher number, so the lock is the only protection.

## Rules: the desktop number logic

Read on open or New, per book, MAX+1. A screen reads the next number when it opens and when it clears. TR_SALE shows the pattern; the visible number is year-scoped, the hidden number is not.
- Visible: TR_SALE.cs:14197 {{Select MAX(VCH_NO) As VchNo  From SL_DATA}} with `CO_CODE`, `LC_CODE`, `CO_YEAR`, `CO_BOOK` in the WHERE, and `HAVING MAX(VCH_NO) > 0`; an empty book gives `00001` and the text is formatted `00000`.
- Hidden (the `HD_VCH_NO` kept in `TEMP_BOOK_DATA`): TR_SALE.cs:14209 {{From TEMP_BOOK_DATA WHERE CO_CODE}}, no `CO_YEAR`, so it is per company, location and book across years.
- Scope in one line: visible = company + location + year + book; hidden = company + location + book. Web equal: `numbering.ts:8` (`VoucherScope`) and `vouchers/lifecycle.ts:48` (`nextHiddenVoucherNoTx`, lock key `melting-temp|tenant|co|lc|book`).

Override. The number box is locked and the operator must unlock it, then Enter opens that number.
- Locked by default: TR_SALE.cs:4851 {{((TextBoxBase)tVchNo).ReadOnly = true;}}.
- Double-click unlocks: TR_SALE.cs:17061 {{((TextBoxBase)tVchNo).ReadOnly = false;}}.
- Enter runs the open: TR_SALE.cs:17093 {{if ((int)e.KeyCode == 13)}}. `DISPLAY_DATA` (TR_SALE.cs:14226 {{private void DISPLAY_DATA()}}) loads the saved voucher, or, when the number has no voucher, sets add mode and leaves the typed text in the box (TR_SALE.cs:14851 {{EntryMode = "A";}}).
- Tag Cancel has the same lock: TR_TAG_CAN.cs:1509 {{((TextBoxBase)tVchNo).ReadOnly = true;}}.

Save re-checks in add mode (this is the duplicate rule). If the number now exists, the desktop re-reads MAX and renumbers, with a notice; it never stops the save.
- Existence check: TR_SALE.cs:15135 {{SELECT * FROM SL_DATA WHERE CO_CODE}}.
- Message, verbatim, with the source spelling: `Current Voucher No has been changd New Voucher No is  '00014'` (two spaces before the quote, `00014` stands for MAX+1). Quote: TR_SALE.cs:15143 {{Current Voucher No has been changd New Voucher No is}}
- Then the write set deletes by `tVchNo.Text` and inserts under it: TR_SALE.cs:15167 {{DELETE FROM SL_DATA WHERE}}.
- The same message appears in 47 of the 49 forms in the table below. Tag Cancel uses a shorter text (Item Opening has none): TR_TAG_CAN.cs:5046 {{New Voucher No: }}, which reads `"New Voucher No: " + tVchNo.Text` after the same existence check, and its open read is TR_TAG_CAN.cs:4711 {{MAX(VCH_NO) As VchNo  From BAR_CAN_DATA}}.
- Hidden-only books: Order Adjust reads only `TEMP_BOOK_DATA`: TR_SL_ORD_ADJ.cs:3169 {{From TEMP_BOOK_DATA}}.
- Customer Entry numbers per employee book: UT_CUST_ENTRY.cs:2355 {{From CUST_DATA}}.
- Item Opening does not number by MAX at all; its `VCH_NO` is the item-type letter: TR_ITM_OPBL.cs:1429 {{dataRow["VCH_NO"] = Strings.Mid(cboItemTyp.Text, 1, 1);}}. The web allocates a number for it anyway (open question 3).

Per form: the open read, its scope and the save-time notice (every row quoted from the desktop):

| Desktop form | Open read | Scope | Save-time notice |
|---|---|---|---|
| TR_APR_ISU | TR_APR_ISU.cs:5760 {{MAX(VCH_NO) As VchNo  From APR_DATA}} | year | TR_APR_ISU.cs:6080 {{Current Voucher No has been changd}} |
| TR_BILL_TO | TR_BILL_TO.cs:4334 {{MAX(VCH_NO) As VchNo  From CASH_DATA}} | year | TR_BILL_TO.cs:4729 {{Current Voucher No has been changd}} |
| TR_BUL_BOOKING | TR_BUL_BOOKING.cs:2778 {{MAX(VCH_NO) As VchNo  From BUL_DATA}} | year | TR_BUL_BOOKING.cs:3048 {{Current Voucher No has been changd}} |
| TR_BUL_SALE | TR_BUL_SALE.cs:8232 {{MAX(VCH_NO) As VchNo  From RATE_CUT_DATA}} | year | TR_BUL_SALE.cs:8798 {{Current Voucher No has been changd}} |
| TR_CARD_REC | TR_CARD_REC.cs:3039 {{MAX(VCH_NO) As VchNo  From CARD_DATA}} | year | TR_CARD_REC.cs:3255 {{Current Voucher No has been changd}} |
| TR_CASH | TR_CASH.cs:2674 {{MAX(VCH_NO) As VchNo  From CASH_DATA}} | year | TR_CASH.cs:2972 {{Current Voucher No has been changd}} |
| TR_CONTRA | TR_CONTRA.cs:2393 {{MAX(VCH_NO) As VchNo  From CONTRA_DATA}} | year | TR_CONTRA.cs:2723 {{Current Voucher No has been changd}} |
| TR_DHRN_INTREC | TR_DHRN_INTREC.cs:4413 {{MAX(VCH_NO) As VchNo  From DHRN_REC_DATA}} | year | TR_DHRN_INTREC.cs:4690 {{Current Voucher No has been changd}} |
| TR_DHRN_ISU | TR_DHRN_ISU.cs:4816 {{MAX(VCH_NO) As VchNo  From DHRN_ISU_DATA}} | year | TR_DHRN_ISU.cs:5140 {{Current Voucher No has been changd}} |
| TR_DHRN_REC | TR_DHRN_REC.cs:5743 {{MAX(VCH_NO) As VchNo  From DHRN_REC_DATA}} | year | TR_DHRN_REC.cs:6106 {{Current Voucher No has been changd}} |
| TR_EMP_JV | TR_EMP_JV.cs:2648 {{MAX(VCH_NO) As VchNo  From EMP_DATA}} | year | TR_EMP_JV.cs:2871 {{Current Voucher No has been changd}} |
| TR_FINE_SL_PR | TR_FINE_SL_PR.cs:4020 {{MAX(VCH_NO) As VchNo  From CUT_DATA}} | year | TR_FINE_SL_PR.cs:4456 {{Current Voucher No has been changd}} |
| TR_FN_INOUT | TR_FN_INOUT.cs:5037 {{MAX(VCH_NO) AS VchNo  From FAN_DATA}} | year | TR_FN_INOUT.cs:6169 {{Current Voucher No has been changd}} |
| TR_GOLD_BOOK | TR_GOLD_BOOK.cs:2389 {{MAX(VCH_NO) As VchNo  From DG_GOLD_DATA}} | year | TR_GOLD_BOOK.cs:2618 {{Current Voucher No has been changd}} |
| TR_INOUT | TR_INOUT.cs:5380 {{MAX(VCH_NO) As VchNo  From INOUT_DATA}} | year | TR_INOUT.cs:7645 {{Current Voucher No has been changd}} |
| TR_ITM_LOT | TR_ITM_LOT.cs:3540 {{MAX(VCH_NO) As VchNo  From BAR_DATA}} | year | TR_ITM_LOT.cs:3741 {{Current Voucher No has been changd}} |
| TR_ITM_OPBL | no MAX(VCH_NO) read found | - | none found |
| TR_KR_ISU | TR_KR_ISU.cs:4585 {{MAX(VCH_NO) As VchNo  From "}} | year | TR_KR_ISU.cs:5017 {{Current Voucher No has been changd}} |
| TR_LEDR_ADJ | TR_LEDR_ADJ.cs:2592 {{MAX(VCH_NO) As VchNo  From LDR_ADJ_DATA}} | year | TR_LEDR_ADJ.cs:2916 {{Current Voucher No has been changd}} |
| TR_LOCT_AMT | TR_LOCT_AMT.cs:2857 {{MAX(VCH_NO) As VchNo  From LOCT_AMT}} | year | TR_LOCT_AMT.cs:3119 {{Current Voucher No has been changd}} |
| TR_MEMB_ADJ | TR_MEMB_ADJ.cs:2429 {{MAX(VCH_NO) As VchNo  From AD_ADJ}} | year | TR_MEMB_ADJ.cs:2705 {{Current Voucher No has been changd}} |
| TR_MEMB_ENT | TR_MEMB_ENT.cs:4234 {{MAX(VCH_NO) As VchNo  From AD_DATA}} | year | TR_MEMB_ENT.cs:4512 {{Current Voucher No has been changd}} |
| TR_MFG_ISU_REC | TR_MFG_ISU_REC.cs:5230 {{MAX(VCH_NO) As VchNo  From MFG_DATA}} | year | TR_MFG_ISU_REC.cs:5737 {{Current Voucher No has been changd}} |
| TR_MFG_KR_ISU_REC | TR_MFG_KR_ISU_REC.cs:8971 {{MAX(VCH_NO) As VchNo  From MFG_DATA}} | year | TR_MFG_KR_ISU_REC.cs:9444 {{Current Voucher No has been changd}} |
| TR_MFG_ORD_ISU | TR_MFG_ORD_ISU.cs:5499 {{MAX(VCH_NO) As VchNo  From APR_DATA}} | year | TR_MFG_ORD_ISU.cs:5843 {{Current Voucher No has been changd}} |
| TR_MLT_PRO | TR_MLT_PRO.cs:3875 {{MAX(VCH_NO) As VchNo  From MLT_DATA}} | year | TR_MLT_PRO.cs:4133 {{Current Voucher No has been changd}} |
| TR_OTH_COMM | TR_OTH_COMM.cs:3127 {{MAX(VCH_NO) As VchNo  From PAY_DATA}} | year | TR_OTH_COMM.cs:3506 {{Current Voucher No has been changd}} |
| TR_OTH_PURC | TR_OTH_PURC.cs:3295 {{MAX(VCH_NO) As VchNo  From PAY_DATA}} | year | TR_OTH_PURC.cs:3683 {{Current Voucher No has been changd}} |
| TR_PHYSTK | TR_PHYSTK.cs:3499 {{MAX(VCH_NO) As VchNo  From BAR_CAN_DATA}} | year | TR_PHYSTK.cs:3740 {{Current Voucher No has been changd}} |
| TR_PURC | TR_PURC.cs:12088 {{MAX(VCH_NO) As VchNo  From "}} | year | TR_PURC.cs:12915 {{Current Voucher No has been changd}} |
| TR_REP_REC | TR_REP_REC.cs:4233 {{MAX(VCH_NO) As VchNo  From REP_DATA}} | year | TR_REP_REC.cs:4641 {{Current Voucher No has been changd}} |
| TR_SALE | TR_SALE.cs:14197 {{MAX(VCH_NO) As VchNo  From SL_DATA}} | year | TR_SALE.cs:15143 {{Current Voucher No has been changd}} |
| TR_SALE_LBR | TR_SALE_LBR.cs:8517 {{MAX(VCH_NO) As VchNo  From LBR_DATA}} | year | TR_SALE_LBR.cs:9211 {{Current Voucher No has been changd}} |
| TR_SALE_ORD | TR_SALE_ORD.cs:8496 {{MAX(VCH_NO) As VchNo  From SL_ORD_DATA}} | year | TR_SALE_ORD.cs:9062 {{Current Voucher No has been changd}} |
| TR_SALE_RTN | TR_SALE_RTN.cs:10061 {{MAX(VCH_NO) As VchNo  From SL_DATA}} | year | TR_SALE_RTN.cs:12454 {{Current Voucher No has been changd}} |
| TR_SL_EBILL | TR_SL_EBILL.cs:6937 {{MAX(VCH_NO) As VchNo  From SL_DATA}} | year | TR_SL_EBILL.cs:7467 {{Current Voucher No has been changd}} |
| TR_SL_ORD_ADJ | TR_SL_ORD_ADJ.cs:3169 {{MAX(VCH_NO) AS VchNo  From TEMP_BOOK_DATA}} | no year | TR_SL_ORD_ADJ.cs:3490 {{Current Voucher No has been changd}} |
| TR_TAG_CAN | TR_TAG_CAN.cs:4711 {{MAX(VCH_NO) As VchNo  From BAR_CAN_DATA}} | year | TR_TAG_CAN.cs:5046 {{New Voucher No: }} |
| TR_TAG_OPBL | TR_TAG_OPBL.cs:9231 {{MAX(VCH_NO) AS VchNo  From BAR_DATA}} | year | TR_TAG_OPBL.cs:10833 {{Current Voucher No has been changd}} |
| TR_TAG_SPLIT | TR_TAG_SPLIT.cs:9433 {{MAX(VCH_NO) As VchNo  From LBR_DATA}} | year | TR_TAG_SPLIT.cs:10060 {{Current Voucher No has been changd}} |
| TR_TAG_WT_DIFF | TR_TAG_WT_DIFF.cs:7358 {{MAX(VCH_NO) As VchNo  From LBR_DATA}} | year | TR_TAG_WT_DIFF.cs:7933 {{Current Voucher No has been changd}} |
| TR_TOUR_ORD | TR_TOUR_ORD.cs:6758 {{MAX(VCH_NO) As VchNo  From SL_ORD_DATA}} | year | TR_TOUR_ORD.cs:7242 {{Current Voucher No has been changd}} |
| TR_TOUR_SALE | TR_TOUR_SALE.cs:10042 {{MAX(VCH_NO) As VchNo  From RATE_CUT_DATA}} | year | TR_TOUR_SALE.cs:10755 {{Current Voucher No has been changd}} |
| TR_VP | TR_VP.cs:5127 {{MAX(VCH_NO) As VchNo  From RATE_CUT_DATA}} | year | TR_VP.cs:5573 {{Current Voucher No has been changd}} |
| TR_VP_ADJ | TR_VP_ADJ.cs:2375 {{MAX(VCH_NO) As VchNo  From VP_ADJ_DATA}} | year | TR_VP_ADJ.cs:2613 {{Current Voucher No has been changd}} |
| TR_WH_SALE | TR_WH_SALE.cs:12151 {{MAX(VCH_NO) As VchNo  From RATE_CUT_DATA}} | year | TR_WH_SALE.cs:12911 {{Current Voucher No has been changd}} |
| TR_WH_SALE_RTN | TR_WH_SALE_RTN.cs:6671 {{MAX(VCH_NO) As VchNo  From "}} | year | TR_WH_SALE_RTN.cs:7197 {{Current Voucher No has been changd}} |
| UT_CUST_ENTRY | UT_CUST_ENTRY.cs:2355 {{MAX(VCH_NO) As VchNo  From CUST_DATA}} | year | UT_CUST_ENTRY.cs:2491 {{Current Voucher No has been changd}} |
| UT_REMINDER | UT_REMINDER.cs:1924 {{MAX(VCH_NO) As VchNo  From REM_DATA}} | year | UT_REMINDER.cs:2091 {{Current Voucher No has been changd}} |

## Web today: how a number is allocated

Shared helper (the "G241 helper" the plan refers to is the client guard `numberTouched` in `web/apps/web/components/TagCancelForm.tsx:229`; the server counterpart is `nextVoucherNoTx`).
- `web/apps/api/src/modules/vouchers/numbering.ts:163` `nextVoucherNoTx(tx, scope)`: `completeScope`, then `pg_advisory_xact_lock(hashtext('voucher|tenant|co|lc|year|book'))` (`:166`), then `currentMaxVoucherNo` (`:129`) = max over the book's header table(s), plus the legacy MAIN_STOCK for Stock Adjust, plus 1. The lock lasts to commit, so a second writer of the same scope waits, then sees the first writer's row (default isolation is READ COMMITTED: `txBudget.ts:193` shows SERIALIZABLE is opted into by name, and none of the create paths uses it).
- `finance/lifecycle.ts:175` `createIdentityTx` takes the visible number then the hidden one; `finance/lifecycle.ts:165` `createFinanceIdentityTx` first checks the date so a refused date takes no lock. Lock order is always visible, then hidden, then tag locks; I found no create that takes two visible locks in the opposite order (one `receipts/batch` and one `bill-to-bill/settle` number per voucher).
- Tag serial: `numbering.ts:181` `nextTagNoTx` locks, then `SELECT ... FOR UPDATE` on `SRNO_MAST`, backed by the unique index `uq_srno_mast_tenant_company_location` (`migrations/20260715040000_transaction_integrity/migration.sql:22`).
- No create route accepts a typed number. `routes/txn.ts` builds each POST body without `vchNo`/`voucherNo` (checked by search: the only `b.vchNo` reads are repair images and IRN calls, `:3584`, `:3603`, `:7636`, `:7845`). Typed numbers reach a writer only on PUT.
- Collision report: there is none to report on a create. A raw unique violation (`23505`/`P2002`) or "duplicate key" is mapped to `400 {error:'invalid-data'}` (`routes/txn.ts:1009`), not to a 409 and not to the desktop text.
- Idempotency: 7 routes are guarded (`shared/idempotency.ts:44`; list restated at `idempotencyRoutePolicy.test.ts:30`); 80 are queued. Unguarded: a replay allocates the next number and posts a second voucher (WP-04, not a number collision).

Database keys (`web/packages/db/prisma/schema.prisma`; the only voucher-number unique index added by migration is `LBR_ISU_IDTL_bk_uq`, `migrations/20260714010000_schema_parity/migration.sql:101`; `20261102120000_stock_adjust_legacy_numbering` adds a deliberately non-unique index):
- Of 104 models that carry `VCH_NO` and `CO_BOOK`, 57 have an `@@id` or `@@unique` that includes `VCH_NO`; 47 do not. Keyed headers: CONTRA_DATA `:1270`, PAY_DATA, CARD_DATA, CUT_DATA, MFG_DATA, LBR_DATA, INOUT_DATA, DHRN_*_DATA, EMP_DATA, REP_DATA, CUST_DATA `:1556`. A concurrent duplicate there ends in `23505`, which `routes/txn.ts:1009` answers as a 400.
- Not keyed (a surrogate `row_id` is the primary key): SL_DATA `:5665`, SL_ORD_DATA `:6079`, PR_DATA `:4663`, CASH_DATA `:1183`, RATE_CUT_DATA `:4921`, BAR_CAN_DATA `:609`, BAR_DATA, APR_DATA, MAIN_STOCK, TEMP_BOOK_DATA `:6764` (and their detail tables). These carry sales, purchase, cash, wholesale, orders, tags, approvals and stock. The advisory lock is the only guard there: a writer that skips it (F1, F2, a desktop import, a data repair) makes a silent duplicate number, which the reports then show twice.

## Findings

F1. Customer Entry has no lock (race possible). `web/apps/api/src/modules/crm/customerEntry.ts:95` `nextCustVchNoTx` runs `SELECT coalesce(MAX(("VCH_NO")::int),0) ... FROM "CUST_DATA"` with no advisory lock, and `:206` calls it inside the transaction before the inserts (`:129`). Interleaving: A and B post to one employee book (`CO_BOOK` = employee code) at the same time; both read MAX = 7 under READ COMMITTED; A inserts `00008` row 1 and commits; B's insert of `00008` row 1 hits the primary key `(tenant, co, lc, year, book, VCH_NO, SR_NO)` (`schema.prisma:1556`), fails with `23505`, and the operator sees `invalid-data` (400) instead of a saved voucher. Not silent (the key catches it), but the second save is lost and the message is wrong; the desktop would renumber (UT_CUST_ENTRY has the notice, table above). (`/reminder-entries` is not affected: `utilities/reminderEntry.ts:38` uses `nextVoucherNoTx`.)

F2. PUT creates at a typed number, without the lock (typed-number collision possible). Six edit routes call a writer that treats "voucher missing" as "create it", with the number taken from the URL:
- `PUT /rate-cut/:vchNo`, `/bullion-sales/:vchNo`, `/wholesale-sales/:vchNo`, `/wholesale-quotations/:vchNo` (`routes/txn.ts:7011`, `:7023`, `:7063`, `:7122`) and `PUT /tour-sales/:vchNo` (`routes/crm.ts:172`) reach `writeRateCut` with `options.vchNo`. `modules/sales/rateCut.ts:1932` `options.vchNo == null ? await nextVoucherNoTx(tx, input.scope) : Number(options.vchNo)`; `:1965` reads the prior header with `persistedHeaderTx` (a `FOR UPDATE` on a row that may not exist, `:2528`) and carries on when it is absent. There is no not-found refusal in this path (the only one is the reader at `:1652`).
- `PUT /stock/tag-adjust/:vchNo` (`routes/txn.ts:5182`) calls `saveTagAdjust` with `vchNo` (`modules/stock/tagAdjust.ts:394-398`), then `deleteRegisterTx` (`:398`, deletes `BAR_CAN_IDTL/DETL/DATA` of that number) and inserts. A PUT to an unused number creates a voucher; a PUT to an existing number overwrites it with no version token.
- Interleaving (rate-cut, RATE_CUT_DATA has no unique key): A POSTs and takes `00012` under the lock; before A commits, B PUTs `/wholesale-sales/00012` (a number B typed or guessed); B takes no lock, sees no header, inserts `00012` rows; A commits its `00012`. Two vouchers, one number. Also a PUT to a not-yet-used `00500` leaves a gap, and the next POST of that book is MAX+1 = `00501`.
- Desktop: typing a number and pressing Enter opens it; a missing number stays an add-mode form, and save renumbers if the number exists (rules above). It never overwrites another voucher. Other PUT routes (`/stock/in`, `/stock/out`, `/stock/tag-split`, `/stock/physical-stock`, `/stock/stone-dm-cf`, `/receipts/batch`, `/fine-sale`, `/stock/tag-opening`, `/stock/item-lot`, `/stock/item-opening`, `/sales/wholesale-sale-return`) were not checked for the same hole (open question 1).

F3. Tag Split has the G241 race, unfixed (race possible, client). `web/apps/web/components/TagSplitForm.tsx:309` `void refreshListing(coBook).then((view) => setVoucherNo(view?.nextVoucherNo ?? ''))` replaces the box unconditionally; Tag Cancel fixed this at `TagCancelForm.tsx:398-400` with `numberTouched`. Interleaving: the book effect fires, the list request is slow, the operator types `00013` and presses Enter, the answer arrives and writes `00014`. Also `TagSplitForm.tsx:299` `clearScreen` sets the box from the possibly stale `listing`. The displayed number also comes from a different query than the allocator: `modules/stock/tagSplit.ts:1016-1021` takes max over `LBR_DATA` only, while save uses `nextVoucherNoTx` (`:610`), so after a gap or an import the box can show a number the save will not use. A held-response browser case is needed (model: `tag-cancel.reopen.late-list-keeps-typed-voucher-number`); Tag Split has no browser module (`web/apps/web/test/features/modules` has `tagCancel.mjs`, `stockAdjust.mjs`, no tag split).

F4. Typed number is dropped without a notice (message differs). Stock Adjust, Tag Cancel and Tag Transfer share `TagCancelForm.tsx`. The box is pre-filled from `nextVoucherNo` (`TagCancelForm.tsx:385`). Save posts a body without the number (`:465-471`, `postCommand(cfg.endpoint, body, command.key)`), the server allocates MAX+1 at that moment (`modules/stock/tagCancel.ts:763`), and the status line then reads `Saved voucher <actual>` (`:477`). Interleaving: A and B both see `00014`; B types `00020`; A saves `00014`; B saves and gets `00015`; B is told `Saved voucher 00015` with no notice that `00020` was not used and `00014` was taken. Desktop: honours the typed `00020` if free (it deletes and inserts by `tVchNo.Text`), and shows `New Voucher No: 00015` when it is taken (Tag Cancel) or the `changd` text (other forms). Tag Split has the same drop (F3). The voucher numbers match whenever the typed number is the book's next one, which is the normal case.

F5. No unique key on the main header tables (see Web today). Fix is a data question: a unique index on header tables that hold one row per voucher (SL_DATA, SL_ORD_DATA, PR_DATA, BAR_CAN_DATA, BAR_DATA, APR_DATA, RATE_CUT_DATA) needs a duplicate scan of real data first, because `20261102120000_stock_adjust_legacy_numbering` records that "deployed databases may already contain old/current key collisions". CASH_DATA and MAIN_STOCK hold several rows per voucher, so the key would need `SR_NO`.

F6. Smaller points.
- The visible and hidden numbers use different lock keys (`voucher|...` and `melting-temp|...`; repair uses `repair-header|...`, `repair/repairWorkflowCommon.ts:219`) on one table family. They guard different sequences, so no race today; any new writer must reuse the helper, not copy the SQL (`customerEntry.ts`, `locationAmount.ts:258`, `tagSplit.ts:1016` are copies).
- Checks that read before the lock (the cash receipt ceiling `partyCashReceivedTx` runs before `createFinanceIdentityTx`, `finance/finance.ts:860-868`) can pass two concurrent receipts that together exceed the ceiling; not a number problem, record for WP-05.
- The lock wait is bounded by the `voucher` budget (20 s, 5 s to start, `txBudget.ts:24`); a timeout answers `503 transaction-timeout` and the retry takes a new number unless the route is guarded.
- Fallback numbering when `BOOK_TBL_NAME` is empty takes the max over every table carrying the six identity columns (`numbering.ts:112-124`): gaps are possible, collisions are not.

## Classification of the 83 routes

| Class | Count | Routes |
|---|---:|---|
| safe | 72 | allocation and insert in one transaction under the full-scope lock; no typed number accepted; the page shows no pre-read number |
| race possible | 2 | `/crm/customer-entries` (F1, server), `/stock/tag-split` (F3, client) |
| typed-number collision possible | 6 | `/rate-cut`, `/bullion-sales`, `/wholesale-sales`, `/wholesale-quotations`, `/tour-sales`, `/stock/tag-adjust` (F2, through the sibling PUT; the POST itself is safe) |
| message differs | 3 | `/stock/stock-adjust`, `/stock/tag-cancel`, `/stock/tag-transfer` (F4) |

Note on "safe": it is about numbers. Idempotency (WP-04) is a separate column: only 7 of 83 are guarded. Also true for all rows: the desktop's unlock-and-type override (double-click, then Enter) has a web counterpart only on the three Tag Cancel family pages and Tag Split (typed number opens a saved voucher; a typed new number is not used on save); on the other pages the number box is a lookup, empty until a save returns the number.

Per route (writer = file and line of the allocation call; desktop = form named in the table above; idem = guarded):

| Route | Writer allocation | Desktop form | Idem | Class |
|---|---|---|---|---|
| `/sales` | `sales/sales.ts:2106` | TR_SALE | no | safe |
| `/sales-quotations` | `sales/sales.ts:2106` | TR_SALE | no | safe |
| `/sales-returns` | `sales/salesReturn.ts:279` | TR_SALE_RTN | no | safe |
| `/sales-orders` | `sales/salesOrder.ts:931` | TR_SALE_ORD | no | safe |
| `/tour-orders` | `sales/salesOrder.ts:931` | TR_TOUR_ORD | no | safe |
| `/order-cancel` | `sales/orderCancel.ts:597` | TR_SL_ORD_ADJ | yes | safe |
| `/labour-invoice` | `sales/labourInvoice.ts:275` | TR_SALE_LBR | no | safe |
| `/wholesale-sales` | `sales/rateCut.ts:1932` | TR_WH_SALE | no | typed |
| `/wholesale-quotations` | `sales/rateCut.ts:1932` | TR_WH_SALE | no | typed |
| `/rate-cut` | `sales/rateCut.ts:1932` | TR_WH_SALE | no | typed |
| `/bullion-sales` | `sales/rateCut.ts:1932` | TR_BUL_SALE | no | typed |
| `/tour-sales` | `sales/rateCut.ts:1932` | TR_TOUR_SALE | no | typed |
| `/sales/vp-parcel` | `sales/vpParcel.ts:1203` | TR_VP | no | safe |
| `/sales/wholesale-sale-return` | `sales/wholesaleSaleReturn.ts:1335` | TR_WH_SALE_RTN | no | safe |
| `/e-invoices` | `einvoice/eBillWriter.ts:1562` | TR_SL_EBILL | no | safe |
| `/e-credit-notes` | `einvoice/eBillWriter.ts:1562` | TR_SL_EBILL | no | safe |
| `/purchases` | `purchase/purchase.ts:1727` | TR_PURC | no | safe |
| `/consignment-purchases` | `purchase/purchase.ts:1727` | TR_PURC | no | safe |
| `/purchase-quotations` | `purchase/purchase.ts:1727` | TR_PURC | no | safe |
| `/purchase-returns` | `purchase/purchaseReturn.ts:269` | not located | no | safe |
| `/other-purchase` | `purchase/otherIncome.ts:936` | TR_OTH_PURC | no | safe |
| `/other-income` | `purchase/otherIncome.ts:936` | TR_OTH_PURC | no | safe |
| `/other-commission` | `purchase/otherCommission.ts:823` | TR_OTH_COMM | no | safe |
| `/receipts` | `finance/finance.ts:557` | TR_CASH | yes | safe |
| `/receipts/multi` | `finance/finance.ts:557` | TR_CASH | yes | safe |
| `/payments` | `finance/finance.ts:557` | TR_CASH | yes | safe |
| `/payments/multi` | `finance/finance.ts:557` | TR_CASH | yes | safe |
| `/receipts/batch` | `finance/batchReceipt.ts:138` | TR_CASH | no | safe |
| `/contra` | `finance/contra.ts:226` | TR_CONTRA | no | safe |
| `/card-receipts` | `finance/cardReceipt.ts:424` | TR_CARD_REC | no | safe |
| `/journal` | `finance/journal.ts:162` | not located | no | safe |
| `/ledger-adjust` | `finance/ledgerAdjust.ts:135` | TR_LEDR_ADJ | no | safe |
| `/employee-jv` | `finance/employeeJv.ts:148` | TR_EMP_JV | no | safe |
| `/fine-jv` | `finance/fineJv.ts:495` | TR_CONTRA | no | safe |
| `/bill-to-bill/settle` | `finance/billToBill.ts:183` | TR_BILL_TO | no | safe |
| `/finance/gold-book` | `finance/goldBook.ts:519` | TR_GOLD_BOOK | no | safe |
| `/finance/location-amount` | `finance/locationAmount.ts:677` | TR_LOCT_AMT | no | safe |
| `/finance/vp-adjustment` | `finance/vpAdjustment.ts:584` | TR_VP_ADJ | no | safe |
| `/fine-sale` | `bullion/fineSalePurchase.ts:197` | TR_FINE_SL_PR | no | safe |
| `/bullion/booking` | `bullion/bullion.ts:159` | TR_BUL_BOOKING | no | safe |
| `/inout/fine` | `inout/fineInout.ts:176` | TR_FN_INOUT | no | safe |
| `/dhrn/issue` | `dhrn/dhrn.ts:585` | TR_DHRN_ISU | no | safe |
| `/loan/issue` | `dhrn/dhrn.ts:585` | TR_DHRN_ISU | no | safe |
| `/dhrn/receipt` | `dhrn/dhrn.ts:585` | TR_DHRN_REC | no | safe |
| `/loan/received` | `dhrn/dhrn.ts:585` | TR_DHRN_REC | no | safe |
| `/dhrn/interest` | `dhrn/dhrnInterest.ts:450` | TR_DHRN_INTREC | no | safe |
| `/tour/issue` | `tour/approvalVoucher.ts:590` | TR_APR_ISU | no | safe |
| `/tour/return` | `tour/approvalVoucher.ts:590` | TR_APR_ISU | no | safe |
| `/karigar/issue` | `manufacturing/karigar.ts:649` | TR_KR_ISU | no | safe |
| `/karigar/receive` | `manufacturing/karigar.ts:649` | TR_KR_ISU | no | safe |
| `/old-item-sales` | `manufacturing/karigar.ts:649` | not located | no | safe |
| `/mfg/issue` | `manufacturing/mfg.ts:865` | TR_MFG_ISU_REC | no | safe |
| `/mfg/receive` | `manufacturing/mfg.ts:865` | TR_MFG_ISU_REC | no | safe |
| `/mfg/order-issue` | `manufacturing/mfg.ts:865` | TR_MFG_ORD_ISU | no | safe |
| `/mfg/jobwork-issue` | `manufacturing/mfg.ts:865` | TR_MFG_KR_ISU_REC | no | safe |
| `/mfg/jobwork-receive` | `manufacturing/mfg.ts:865` | TR_MFG_KR_ISU_REC | no | safe |
| `/melting` | `manufacturing/meltingPro.ts:462` | TR_MLT_PRO | no | safe |
| `/members/points` | `membership/membership.ts:110` | not located | no | safe |
| `/scheme/enroll` | `membership/scheme.ts:583` | TR_MEMB_ENT | no | safe |
| `/scheme/installment` | `membership/scheme.ts:583` | TR_MEMB_ENT | no | safe |
| `/scheme/opening` | `membership/scheme.ts:583` | TR_MEMB_ENT | no | safe |
| `/scheme/maturity` | `membership/scheme.ts:583` | TR_MEMB_ENT | no | safe |
| `/scheme/gold-adjust` | `membership/scheme.ts:583` | TR_MEMB_ADJ | no | safe |
| `/stock/stock-adjust` | `stock/tagCancel.ts:763` | TR_TAG_CAN | yes | message |
| `/stock/tag-cancel` | `stock/tagCancel.ts:763` | TR_TAG_CAN | yes | message |
| `/stock/tag-transfer` | `stock/tagCancel.ts:763` | TR_TAG_CAN | no | message |
| `/stock/tag-split` | `stock/tagSplit.ts:610` | TR_TAG_SPLIT | no | race |
| `/stock/tag-weight-diff` | `stock/tagOps.ts:116` | TR_TAG_WT_DIFF | no | safe |
| `/stock/tag-opening` | `stock/stockVoucherLifecycle.ts:995` | TR_TAG_OPBL | no | safe |
| `/stock/item-lot` | `stock/stockVoucherLifecycle.ts:995` | TR_ITM_LOT | no | safe |
| `/stock/item-opening` | `stock/stockVoucherLifecycle.ts:995` | TR_ITM_OPBL | no | safe |
| `/stock/in` | `stock/stockInout.ts:897` | TR_INOUT | no | safe |
| `/stock/out` | `stock/stockInout.ts:897` | TR_INOUT | no | safe |
| `/stock/physical-stock` | `stock/physicalStock.ts:314` | TR_PHYSTK | no | safe |
| `/stock/stone-dm-cf` | `stock/stoneDmCf.ts:499` | not located | no | safe |
| `/stock/counter-transfer` | `stock/stock.ts:795` | not located | no | safe |
| `/stock/tag-adjust` | `stock/tagAdjust.ts:396` | not located | no | typed |
| `/repair-receipts` | `repair/repairReceipt.ts:808` | TR_REP_REC | no | safe |
| `/repair-customer-issues` | `repair/repairCustomerIssue.ts:1237` | not located | no | safe |
| `/repair-karigar-issues` | `repair/repairKarigarIssue.ts:588` | not located | no | safe |
| `/repair-karigar-receipts` | `repair/repairKarigarReceipt.ts:1183` | not located | no | safe |
| `/reminder-entries` | `utilities/reminderEntry.ts:38` | UT_REMINDER | no | safe |
| `/crm/customer-entries` | `crm/customerEntry.ts:206` | UT_CUST_ENTRY | no | race |

"Not located" rows: the web module names no desktop form and a search of `unified/src/csharp/DataCareNext` by caption did not settle it; the numbering shape is the same helper (open question 2).

## Proposed shared pattern

Reuse what G241 and the numbering module already give, in three parts. Nothing new is invented.

1. Server: one allocator, one place. `nextVoucherNoTx` (`numbering.ts:163`) and `createIdentityTx` (`finance/lifecycle.ts:175`) stay the only allocators. Replace the three copies (`customerEntry.ts:95`, `locationAmount.ts:258`, the display read `tagSplit.ts:1016`) with the helper; a source-text test (same style as `idempotencyRoutePolicy.test.ts`) fails when a module under `src/modules` contains `MAX(` over `VCH_NO` outside `numbering.ts`, `vouchers/list.ts` and reports.
2. Server: a create never writes at a number it did not allocate. Add `createAtNumberTx` or, simpler, a guard `assertSavedVoucherTx(tx, scope, vchNo)` that every PUT calls first and that throws the existing `voucher-not-found` (404, `vouchers/lifecycle.ts:25`) when the header is absent. Apply it to the six PUTs in F2 first. The test per route: PUT of an unused number answers 404 and writes no row.
3. Client: the G241 guard as a hook. Lift `numberTouched` (`TagCancelForm.tsx:229`, `:398-400`) into `web/apps/web/lib/` (for example `useNextNumber`), apply it to `TagSplitForm.tsx:299` and `:309`, and show the desktop notice when the saved number differs from the one the operator saw: `Current Voucher No has been changd New Voucher No is  '<n>'` (other forms) or `New Voucher No: <n>` (Tag Cancel family), in the same status line that now says `Saved voucher <n>`. For this the create response already carries `voucherNo`; the page compares it with the box.
4. Database: after a duplicate scan on real data, add a unique index on `(tenant_id, CO_CODE, LC_CODE, CO_YEAR, CO_BOOK, VCH_NO)` for the one-row header tables of F5, in a migration that fails closed (lists the duplicates, creates nothing). Map `23505` on these tables to `409 {error:'voucher-number-taken'}` in `routes/txn.ts:1009` instead of `invalid-data`. Until then the guard in item 2 is what protects the lock.
5. Held-response browser cases. For each page that shows a number from a read: `tag-split.reopen.late-list-keeps-typed-voucher-number` (new module), and the existing Stock Adjust and Tag Cancel cases stay. A DB test per fixed writer: two concurrent creates of one scope get two numbers (use `Promise.all` and the real lock), and the PUT-at-unused-number case from F2.

Order by business risk (sales, purchase and cash first):

| Order | Routes | What to apply | Why |
|---|---|---|---|
| 1 | `/wholesale-sales`, `/wholesale-quotations`, `/rate-cut`, `/bullion-sales`, `/tour-sales` | item 2 (PUT guard) then item 4 | sales on RATE_CUT_DATA, no unique key, duplicate number possible today |
| 2 | `/stock/tag-adjust` | item 2 | stock voucher overwritable by typed number, no version token |
| 3 | `/sales`, `/sales-returns`, `/sales-orders`, `/purchases`, `/purchase-returns`, `/receipts`, `/payments`, `/contra` | item 4 (unique key and 409 text) | already safe by lock; the key adds a backstop for imports and repairs; SL_DATA, PR_DATA, CASH_DATA are unkeyed |
| 4 | `/stock/stock-adjust`, `/stock/tag-cancel`, `/stock/tag-transfer`, `/stock/tag-split` | item 3 (notice, hook) | operator-visible number; Tag Split also gets the race fix |
| 5 | `/crm/customer-entries` | item 1 (helper) | lowest value, real race, key catches it |
| 6 | other 60 rows | item 1 test only | no change |

## Desktop weaknesses not to port

- Save-time renumber instead of a refusal: two desktop users on a shared server can both pass the existence check and then both delete and insert (TR_SALE.cs:15135 {{SELECT * FROM SL_DATA WHERE CO_CODE}}, then TR_SALE.cs:15167 {{DELETE FROM SL_DATA WHERE}}), a check-then-act race with no lock. The web lock is the right answer; keep the notice, not the race.
- The delete-then-insert by typed number (TR_SALE.cs:15167 {{DELETE FROM SL_DATA WHERE}}) makes a typed existing number an overwrite in add mode if the check is skipped; the web must not copy it (F2).

## Gaps

1. Missing key and wrong result: six PUT routes create at a typed number without the lock (F2).
2. Missing key: `UT_CUST_ENTRY` numbering has no lock (F1; wrong text on collision, `invalid-data` instead of a renumber).
3. Wrong result (client): Tag Split replaces a typed number with a late answer (F3).
4. Wrong text: the `changd` / `New Voucher No:` notice is never shown (F4). Search of `web/` for `has been changd` finds nothing.
5. Missing feature: typed-number override on create is not supported on any page except as an "open" action; the desktop honours a typed free number on save.
6. Missing key: no unique key on the main header tables (F5).
7. Not a number gap but the same class of bug: `Idempotency-Key` on 80 routes (WP-04).

## Open questions

1. Do the other PUT routes listed in F2 refuse a missing voucher? The code path per route (`lockedVoucherTx` use) needs one read each; a generic test (`PUT` of an unused number answers 404) will settle all.
2. Desktop forms not located for: `/purchase-returns` (module header cites `TR_KR_ISU.cs`), `/old-item-sales`, `/journal`, `/members/points`, `/stock/stone-dm-cf`, `/stock/counter-transfer`, `/stock/tag-adjust`, `/repair-customer-issues`, `/repair-karigar-issues`, `/repair-karigar-receipts`. Their number rule is the same MAX+1 by `BOOK_TBL_NAME`; the form file is needed for the citation only.
3. Item Opening: the desktop `VCH_NO` is the item-type letter (TR_ITM_OPBL.cs:1429 {{dataRow["VCH_NO"] = Strings.Mid(cboItemTyp.Text, 1, 1);}}), but `stock/stockVoucherLifecycle.ts` allocates a numeric voucher. Whether this is by design needs the TR_ITM_OPBL write set.
4. Do deployed databases hold duplicate `(book, VCH_NO)` headers in SL_DATA, PR_DATA, RATE_CUT_DATA? A read-only count per tenant answers F5; it needs a database, which this study did not run.
5. Is the Tag Split display read meant to stay different from the allocator (`tagSplit.ts:1016` versus `numbering.ts:129`)? Desktop TR_TAG_SPLIT reads `LBR_DATA` (table above), so the display may be the faithful one and the allocator the outlier for books with `BOOK_TBL_NAME` set elsewhere.
