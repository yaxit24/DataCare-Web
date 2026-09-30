# Contract: N18 — Tag Cancel (X19) and Tag Transfer (X18), desktop `TR_TAG_CAN`

Master plan slice N18 (`docs/master-parity-plan-2026-09-29/02-execution-plan.md` §3): *qualify tag transfer
and cancellation separately, preserving exact live serial and referenced children/images — full lifecycle,
conflict, reversal and complete DB diff.* Verification journey J14 (`04-verification-playbook.md`).

Both desktop menus open the same form, `TR_TAG_CAN`, on a book of their own `MAIN_BOOK`. Every expected value
below is taken from the desktop source. None is taken from web code. No desktop `BAR_CAN_*` rows were ever
captured (the imported demo holds two `TGCAN` `MAIN_STOCK` rows and no register rows,
`project-memory/parity/verify-stock-tags.md` §0), so the database diff is derived from the source and the
vectors are source-derived, not replayed. Where the web deliberately differs, the entry says **Web adaptation**.

## Sources

Paths are relative to `unified/src/csharp/DataCareNext/`. Hashes are SHA-256, first 16 hex characters.

| File | sha256/16 | Lines used |
|---|---|---|
| MDI_FORM.cs | cb91085c50d07a07 | 8585-8595 "Tag Cancel" → `CurBookHelp("TAG CANCEL")`; 8663-8673 "Tag Transfer" → `CurBookHelp("TAG TRFR")`; both open `TR_TAG_CAN` |
| DC_Main.cs | — | `CurBookHelp`: only books with `CUR_USE = 'Y'` and the menu's `MAIN_BOOK`, for the company and location |
| TR_TAG_CAN.cs | 04e7ae5842f63116 | See the list below |
| Ac_Stock.cs | 946f9ba4f7e85835 | 48-58 `Tag_Can_Stk`; 642 `StkAdj_Lot` (STOCK ADJUST only); 824-828 `Dm_Tag_Cancel_Detl` |
| MS_UPDATE.cs / Mfg_Module.cs | — | 7825 / 1005: `BOOK_TBL_NAME = 'BAR_CAN_DATA'` for `TAG CANCEL` and `TAG TRFR` books |
| MS_OPNCOMP.cs | 180f295f9595dfc7 | 664, 733-735 (`LBR_TYPE`: blank means G); 1224-1226 (`LBR_WITH_GHT`: blank means Y) |

`TR_TAG_CAN.cs` lines used:

- 1865-1953 `MSG_IDTL_CLEAR` (stone grid), 2279-2424 `CommPassTotal_Idtl` (stone arithmetic and its effect on the row).
- 2426-2760 `MSG_CLEAR` (columns per `MAIN_BOOK`, `COL_MAST` `TAG_CAN_DETL` visibility), 2762-2810 `MSG_TOT_FILL`.
- 3107-3680 `CommPassTotal` (row arithmetic), `CommPassAdd` (new row), `MSG_EnterCell` (read-only cells), `MSG_LeaveCell`.
- 3690-4100 grid keys: Ctrl+D removes a row, tag entry (col 1), duplicate check, instance picker, tag fill, stone load.
- 4191-4340 item (col 4), counter (col 5), gross (col 11 → stone grid), transfer item (col 20), karigar (col 28).
- 4626-4650 book capture, 4650-4700 `CLEAR_DATA`, 4702-4880 `DISPLAY_DATA`.
- 4942-5330 `BtnSave_Click`, 5331-5362 `BtnDelete_Click`, `BtnFirst_Click` / `BtnLast_Click`, `BtnF1_Click`, `tEmpCode_KeyDown`.

## Findings in the web before this slice

1. **Two unrelated thin writers.** Cancel (`tagOps.ts tagCancel`) and transfer (`stock.ts tagTransfer`) shared nothing although the
   desktop has one form. Both were HTTP-contained (503) and both pages were read-only notices.
2. **Wrong book stamps.** Cancel hard-coded `VCH_TYPE 'TGCAN'`, `BOOK_NAME 'TAG CANCEL'`, `ENTRY_TYPE 'C'`; the desktop takes
   `BOOK_SNAME`, `MAIN_BOOK` and writes `ENTRY_TYPE 'T'`. Transfer wrote `TR_TYPE 'A'` on both legs (desktop 'O' / 'I'), a
   `TBL_CODE '000'`, the line's rate and amount on the `+` leg (desktop 0) and no register at all.
3. **Identity.** Transfer resolved the source item from any `BAR_DETL` row of the tag number — no location, no serial, no
   availability, no lock. A sold tag could be transferred and the same tag transferred twice.
4. **Register.** Cancel's `BAR_CAN_IDTL.VCH_SRNO` was the LINE INDEX (desktop: the tag's serial), `SR_NO` the line index (desktop:
   the parent's `OLD_SRNO`), `HD_VCH_NO` the voucher number, and no `TEMP_BOOK_DATA` row was written. The register carried
   nine web-only columns the desktop never writes (`HM_ID`, `ITM_STYLE`, `ITM_COLOR`, `ITM_POLISH`, `IT_DESC`, `ITM_REMARK`,
   `TAG_COST`, `TAG_NWT`, `TO_TBL_CODE`), every one a database-diff difference.
5. **No stones from the tag.** A cancel wrote only the stones the request carried; the desktop copies the tag's `BAR_IDTL` rows.
6. **No `DM_DATA`.** `Dm_Tag_Cancel_Detl` (diamond register) was not modelled.
7. **No lifecycle.** No read, no edit, no voucher list; delete wrote no `DELETE_DATA` for cancel and a one-row log for transfer
   with none of the desktop columns.
8. **Provisioning.** Book `TTR` was provisioned with `MAIN_BOOK 'TAG TRANSFER'`, which no desktop routine recognises
   (`Tag_Can_Stk` filters `'TAG TRFR'`), and no Tag Cancel book was provisioned.

## Contract

### K1. Form, book and mode

1. One writer serves both menus. The mode is the route's (`/stock/tag-cancel` → `cancel`, `/stock/tag-transfer` → `transfer`),
   and the book must agree: exactly one `BOOK_DATA` row for the company, location and `CO_BOOK`, with `CUR_USE = 'Y'` and
   `MAIN_BOOK` = `TAG CANCEL` (cancel) or `TAG TRFR` (transfer). Anything else is refused (400) naming the book's real
   `MAIN_BOOK`. The book help never offers another book (`CurBookHelp`), so a book of the other mode, a book not in use, or a
   missing book is a caller error.
2. From the book: `VCH_TYPE` = `BOOK_SNAME`, `INOUT_TYPE` = `BOOK_INOUT`, register `BOOK_NAME` = `MAIN_BOOK`,
   `TEMP_BOOK_DATA.BOOK_NAME` and `DELETE_DATA.BOOK_NAME` = `BOOK_DATA.BOOK_NAME`, `MAIN_STOCK.DATA_TYPE` = `BOOK_DATA.DATA_TYPE`
   (**Web adaptation:** 'A' when blank, as every web stock writer does).
3. The desktop's `STOCK ADJUST` and `TAG ADJ` modes of the same form are out of scope (X20 / existing `tagAdjust.ts`).

### K2. Tag identity, availability and locks

1. A line with a tag number is a **tag line**; the number is trimmed and upper-cased (the form upper-cases every key,
   `TR_TAG_CAN_KeyPress`). A line without one is a **loose line** (`TAG_NO 'N'`, `VCH_SRNO 0`).
2. A tag line cancels exactly one live instance: company + location + `TAG_NO` + `VCH_SRNO` with a positive signed stock
   balance and `EMP_ISU <> 'Y'` (tag entry query, :3860), or a web `TAG_STOCK` row. The shared resolver (`issueTagTx`) is
   used, so a cancel, a transfer and a sale agree on what "in stock" means.
3. **Web adaptation (fail closed):** when two live instances share the number and the line names no `vchSrno`, the save is
   refused. The desktop opens an instance picker at entry (:3918-3945) and, at save, silently takes the newest instance by
   `BAR_DETL.VCH_TIME` (:4995-5003).
4. The same tag number twice on one voucher is refused with the desktop message **"Duplicate Tag No"** (:3907-3915) — by number,
   whatever the serials.
5. A tag line's item is the tag's. A line that names a different item is refused.
6. **Locks.** Every tag number the save touches — the request's and, on edit and delete, the voucher's own — is locked in
   sorted order with the resolver's key (`pg_advisory_xact_lock(hashtext('tag-issue|CO|LC|TAG_NO'))`) before any tag is
   resolved, released or written. A create takes them before the voucher number. An edit or a delete first locks the
   voucher's header row (`persistedVoucherHeaderTx`, `FOR UPDATE` — which also serialises two edits of one voucher), then
   the tags. No path takes a tag lock and then waits for a header, so the orders cannot cross. Two cancels, a cancel and a
   transfer, or a cancel and a sale of the same tag therefore serialise; the second sees the first's committed `-` row and
   is refused (400 "tag not available"). A database deadlock or serialisation failure (Prisma P2034, SQLSTATE 40P01 / 40001)
   is reported as 409 `TagCancelConflictError`, never as a 500 or a partial write.
7. Another location's tag, a sold or already-cancelled tag, and an employee-issued tag are all "not available".

### K3. Tag fill (tag entry, :4020-4085)

A tag line starts from the **first `BAR_DETL` row of the instance** (`ORDER BY row_id`, as `availableBarTags` does), with the
desktop's grid formatting, which is what the desktop saves:

| Cell (col) | From `BAR_DETL` | Format |
|---|---|---|
| ItCode (4), Counter (5), Design (6), Size (7) | `IT_CODE`, `TBL_CODE`, `DESIGN_NO`, `ITM_SIZE` | text |
| Sign (8) | '-' | |
| BagWt (9), GrWt (11), LsWt (12), NetWt (13), GhtWt (15), Fine (18) | `BAG_WT`, `ITM_GWT`, `ITM_OTH_WT`, `ITM_NWT`, `ITM_GHT_WT`, `ITM_FINE` | 0.000 |
| Pcs (10) | `ITM_PCS` | as stored |
| Ght% (14), Touch (16), West% (17) | `ITM_GHT_PRC`, `ITM_TOUCH`, `ITM_WEST_PRC` | 0.00 |
| — when `ITM_TOUCH` is 0 | Touch, West%, Fine ← `KR_TOUCH`, `KR_WEST_PRC`, `KR_FINE` | |
| Lbr% (22), LType (23), LbrRate (24), LbrAmt (25), OthAmt (26) | `LBR_PRC`, `LBR_TYPE`, `LBR_RATE`, `LBR_AMT`, `OTH_AMT` | 0.00 |
| KrNwt (30) | `KR_NET_WT` | **0.00** (sic — the desktop formats the karigar net to two places, so 4.905 saves 4.91) |
| KrTouch (33), KrWst% (34), KrFine (35) | `KR_TOUCH`, `KR_WEST_PRC`, `KR_FINE` | 0.00 / 0.00 / 0.000 |
| ItRate (41), ItAmt (42), Mrp (27) | `ITM_RATE`, `ITM_AMT`, `ITM_MRP` | 0.00 |
| KrCode (28), RateType (48), ItType (49), PrCode (51) | `KR_NAME`, `RATE_TYPE`, `IT_TYPE`, `PR_CODE` | text |
| TagId (40), Image (65) | `VCH_SRNO`, `DESIGN_IMG_ID` | |

- LotNo (2) and ItmLot (3) are not filled from the tag and are hidden in both modes: a tag line saves `LOT_NO ''`, `ITM_LOT ''`.
- A `TAG_STOCK`-only tag (web-created) fills from `TAG_STOCK` (`DESIGN_NO`, `ITM_SIZE`, pieces, weights, `ITM_MRP`, labour,
  `OTH_AMT`, `PR_CODE`, `IT_TYPE`, `DESIGN_IMG_ID`); it has no item code, so the line must name one.
- The request may change only the cells the operator can type on a tag line: Design, Size, BagWt, GrWt, LsWt, NetWt,
  GhtWt, Touch, West%, Fine, LbrRate, LbrAmt, OthAmt, Mrp (and TrfrItm in transfer mode), plus the hidden cells the grid
  computes (ItAmt, KrNwt, KrTouch, KrWst%, KrFine — K4). ItCode, Counter, Pcs and KrCode are read-only on a tag line
  (`MSG_EnterCell`: cols 0/4/5/10/20/28 are `ReadOnly` when col 1 is filled): a different value is refused, not ignored.
  Ght% (col 14) is shown from the tag and never saved or used by the arithmetic (K4.6), so the request has no such field.
- A loose line starts from `CommPassAdd`: `LBR_TYPE` = the company basis (`CO_SET.LBR_TYPE`, blank → G), `DESIGN_IMG_ID 'N'`,
  and the item's `IT_TYPE`, `PR_CODE`, `RATE_TYPE` from `ITEM_MAST` (col 4 entry, :4219-4226).

### K4. Row arithmetic (`CommPassTotal`, :3107-3680) — `@datacare/core` `tagCancelRecompute`

The desktop recomputes a row when the operator leaves a numeric cell, comparing each input with the value it had when last
computed (hidden cols 56/57/60/61/62/63/64). The core function takes the row and that baseline and returns both, so the
screen can run it on every cell commit, exactly as the desktop does, and the server can run it once for an API caller.

1. Gross changed → net = gross − less (and KrNwt = gross − KrOthWt when both are non-zero). Less ≠ 0 and gross ≠ 0 → net =
   gross − less, always.
2. Net changed, touch changed or wastage changed, with touch + wastage ≠ 0 and net ≠ 0 → fine = (net + ghat) × (touch +
   wastage) / 100. Touch + wastage = 0 → fine = net + ghat. Fine 0 with a purity → fine recomputed. Otherwise a typed or
   stored fine stands.
3. Loose line → KrNwt = net, KrTouch = touch, KrWst% = wastage, KrFine = fine. Tag line → the karigar block recomputes from
   its own baseline (which the tag fill never sets, so the first recompute of a tag line derives KrFine from KrNwt).
4. Item amount, when rate ≠ 0 and fine ≠ 0, by `RATE_TYPE`: P pcs × rate, 1 fine × (rate / 10), K fine × (rate / 1000),
   else fine × rate — `Math.Round(…, 0)`.
5. Labour, when the labour rate ≠ 0, by `LBR_TYPE`: P pcs × rate; N net × rate when `LBR_WITH_GHT` = N, else (net + ghat) ×
   rate; K (net + ghat) × (rate / 1000); else gross × rate — `Math.Round(…, 0)`.
6. Ght% never drives GhtWt on this form (no col 14 → col 15 step); GhtWt is typed.
7. Weights and fine are `Strings.Format` (half-up), money is `Math.Round` (half-to-even), in the desktop operand order.

**Server rule** (`applyLineInput`). The row starts from the tag fill (a new tag line), the saved line (a kept line) or
`CommPassAdd` zeros (a new loose line), with the matching baseline. Then:

1. The given visible numeric cells are replayed **in column order** (BagWt, Pcs, GrWt, LsWt, NetWt, GhtWt, Touch, West%,
   Fine, LbrRate, LbrAmt, OthAmt, Mrp), each formatted as `MSG_LeaveCell` formats it. A value that differs from the row's
   runs `CommPassTotal` (Pcs only stores its value); an equal value is not an edit, so an untouched tag keeps its stored
   fine, item amount and labour exactly (the desktop never recomputes a row the operator does not edit).
2. Edited stones (K5.2) act on the row after GrWt, where the desktop's grid hands focus to the stone grid (:4265-4278),
   followed by one `CommPassTotal`.
3. Every cell the request gives — visible or hidden (ItAmt, KrNwt, KrTouch, KrWst%, KrFine) — is then stored as given, as
   the desktop stores the grid it shows. The screen runs the same core function on every cell commit in the operator's own
   order and sends every cell, so what it shows is what is saved even where the operator's order differs from the column
   order.
4. Tag Transfer: GhtWt, LbrRate, Mrp and KrCode are hidden inputs nothing computes; a value different from the row's is
   refused ("… is not a Tag Transfer column"). LbrAmt and OthAmt are hidden there too but still computed (labour from the
   tag's rate when a weight changes, other amount from the stones), so on that grid they are hidden computed cells: never an
   edit, stored as given. Tag Cancel: TrfrItm is refused.

### K5. Stones (`BAR_CAN_IDTL`)

1. A new tag line copies the instance's stones: the `BAR_IDTL` rows of the first `BAR_DETL` row's voucher
   (`CO_YEAR`, `CO_BOOK`, `VCH_NO`) with `SR_NO` = that row's `OLD_SRNO` and the same `TAG_NO` — the join
   `Dm_Counter_Trfr_Detl` uses (Ac_Stock.cs:833). `ISR_NO` is renumbered 1…n in `SR_NO, ISR_NO` order (the desktop numbers
   them `i + 1` as loaded, :4058). Values take the stone grid's formats: `IT_PCS` as stored; `IT_GWT`, `KR_WT`, `IT_CON_PRC`,
   `IT_CON_WT` 0.000; `IT_RATE`, `IT_AMT`, `IT_LBR_RATE`, `IT_LBR_AMT`, `IT_NET_AMT` 0.00; `IT_RATE_TYPE`, `IT_TYPE`.
   **Web adaptation:** the desktop loads every `BAR_IDTL` row of `TAG_NO + VCH_SRNO` (:4050); a tag re-recorded under a
   second voucher (a wholesale return writes a second `BAR_DETL` row for the same instance) would get its stones twice.
2. An edited voucher keeps the stones it saved (`DISPLAY_DATA` loads them from `BAR_CAN_IDTL`, :4847-4870) unless the
   request replaces them. A line the request gives `stones` (an empty array included) uses exactly those.
3. A stone row is saved when `IT_PCS + IT_GWT + IT_NET_AMT ≠ 0` (:5200).
4. Stone arithmetic (`CommPassTotal_Idtl`), core `tagCancelStone`: weight ↔ karigar weight fill each other when one is 0;
   ConWt = weight × Con% and KrConWt = KrWt × Con% (0.000) when both are non-zero; item amount by P/W (blank: pcs × rate when
   there is no weight, else weight × rate; P: pcs × rate; else weight × rate; 0.00); labour = pcs × labour rate; net =
   item amount + labour. On the row: Σ ConWt ≠ 0 → LsWt = Σ ConWt and net = gross − Σ; Σ KrConWt ≠ 0 → KrOthWt and KrNwt;
   Σ net ≠ 0 → OthAmt = Σ net.

### K6. Register rows (`BtnSave_Click`, :5040-5245) — exactly the desktop column set

A line is saved when `(item ≠ '' and tag ≠ '' and MRP ≠ 0) or pcs + gross + net + labour + other ≠ 0` (:5099).
**Web adaptation:** a tag line that does not qualify is refused instead of silently left in stock; a voucher with no
qualifying line is refused (the desktop would save nothing and, on edit, empty the voucher without an audit row).

`BAR_CAN_DATA` (one row): keys, `VCH_NO`, `AC_CODE ''` (the party box is hidden on this form, `tAcCode.Visible = false`),
`VCH_DATE`, `HD_VCH_NO`, `EMP_CODE`, `VCH_DESC`, `VCH_TIME` = date + clock, `DATA_TRFR 'N'`, `MAIN_USER`, `USER_UPDATE 'N'`,
`USER_DELETE 'N'`. (`RE_TRFR` has no web column.)

`BAR_CAN_DETL` (one row per saved line):

| Column | Value | Column | Value |
|---|---|---|---|
| keys, `VCH_DATE`, `HD_VCH_NO`, `AC_CODE ''` | header | `VCH_TYPE` / `INOUT_TYPE` / `BOOK_NAME` | K1.2 |
| `ENTRY_TYPE` | 'T' | `SR_NO` / `OLD_SRNO` | K9 |
| `IT_CODE`, `TAG_NO` ('N' when blank), `VCH_SRNO` | K2 | `TBL_CODE`, `DESIGN_NO`, `LOT_NO`, `ITM_LOT`, `ITM_SIZE` | cols 5, 6, 2, 3, 7 |
| `ITM_SIGN` | '-' | `TRFR_IT_CODE` | col 20 in transfer mode; **not written** in cancel mode (NULL) |
| `BAG_WT`, `ITM_PCS`, `ITM_GWT`, `ITM_OTH_WT`, `ITM_NWT` | cols 9-13 | `ITM_GHT_WT`, `ITM_TOUCH`, `ITM_WEST_PRC`, `ITM_FINE` | cols 15-18 |
| `LBR_PRC`, `LBR_TYPE`, `LBR_RATE`, `LBR_AMT`, `OTH_AMT` | cols 22-26 | `ITM_RATE`, `ITM_AMT`, `ITM_MRP` | cols 41, 42, 27 |
| `KR_NET_WT`, `KR_TOUCH`, `KR_WEST_PRC`, `KR_FINE` | cols 30, 33, 34, 35 | `KR_NAME`, `RATE_TYPE`, `IT_TYPE`, `PR_CODE` | cols 28, 48, 49, 51 |
| `VCH_TIME`, `DATA_TRFR 'N'`, `MAIN_USER` | header | `DESIGN_IMG_ID` | col 65 |

`DATA_TYPE` is written only by the `TAG ADJ` mode; here the measured default applies. No other column is written.

`BAR_CAN_IDTL` (one row per saved stone): keys, `HD_VCH_NO`, `VCH_DATE`, `AC_CODE ''`, `VCH_TYPE`, `INOUT_TYPE`,
`ENTRY_TYPE 'T'`, `BOOK_NAME`, `SR_NO` = the parent's `OLD_SRNO`, `TAG_NO` and `VCH_SRNO` = the parent's, `ISR_NO`,
`IT_CODE`, `IT_PCS`, `IT_GWT`, `KR_WT`, `IT_CON_PRC`, `IT_RATE_TYPE`, `IT_RATE`, `IT_AMT`, `IT_LBR_RATE`, `IT_LBR_AMT`,
`IT_NET_AMT`, `IT_CON_WT`, `IT_TYPE`, `MAIN_USER`. No `DM_*` and no karigar valuation columns.

The source tag is never modified: `BAR_DETL`, `BAR_IDTL`, `TAG_IMAGE_DATA` and the image store are untouched, so the
tag's children and image survive a cancel and are exactly what a reversal makes available again.

### K7. Stock rows (`Tag_Can_Stk`, Ac_Stock.cs:48-58)

Insert 1, every saved line (both modes): `SR_NO` = line `SR_NO`, `ISR_NO 1`, `VCH_DATE`, `STK_DATE` = `VCH_DATE`,
`VCH_TYPE` = `BOOK_SNAME`, `BOOK_NAME` = `MAIN_BOOK`, `AC_CODE ''`, `IT_CODE`, `TAG_NO` ('' → 'N'), `VCH_SRNO`, `TBL_CODE`,
`TR_TYPE` 'O' (the sign is '-'), `ITM_SIGN '-'`, `ITM_QTY 1`, `ITM_PCS`, `ITM_GWT`, `ITM_NWT`, `ITM_TOUCH`,
`ITM_WEST` = `ITM_WEST_PRC`, `ITM_FINE`, `ITM_RATE`, `ITM_AMT`, `LBR_RATE`, `LBR_AMT`, `OTH_AMT`, `ITM_MRP`, `NET_AMT 0`,
`KR_NWT` = `KR_NET_WT`, `KR_TOUCH`, `KR_WEST` = `KR_WEST_PRC`, `KR_FINE`, `KR_LBR_AMT 0`, `KR_OTH_AMT 0`, `KR_COST 0`,
`EMP_CODE ''`, `ENTRY_TIME` = `VCH_TIME`, `MAIN_USER`, `DATA_TYPE` (K1.2), `DESIGN_NO`, `ITM_SIZE`, `ITM_DESC ''`,
`GHT_PRC 0`, `ITM_LOT`, `ITM_DISC 0`. (The web schema's `MAIN_STOCK.ENTRY_TIME` is a `DATE` column, so it keeps the voucher
date and drops the clock; the clock survives in the register's `VCH_TIME`.)

Insert 2, transfer mode, every line with a transfer item: `ISR_NO 2`, `IT_CODE` = `TRFR_IT_CODE`, `TAG_NO 'N'`, `VCH_SRNO 0`,
`TBL_CODE '001'`, `TR_TYPE 'I'`, `ITM_SIGN '+'`, `ITM_QTY 1`, the same pieces, weights, touch, wastage and fine; `ITM_RATE`,
`ITM_AMT`, `LBR_RATE`, `LBR_AMT`, `OTH_AMT`, `ITM_MRP`, `NET_AMT` all 0; the same `KR_*`; `ITM_LOT ''`; otherwise as insert 1.
The metal therefore moves from the tag to the loose item unchanged in pieces, weight and fine.

`StkAdj_Lot` inserts only for `STOCK ADJUST` books, so neither mode writes `LOT_DETL` (both still delete it on save and delete).

### K8. Diamond register (`Dm_Tag_Cancel_Detl`, Ac_Stock.cs:824-828) — cancel mode only

One `DM_DATA` row per saved stone whose item has `ITEM_MAST.OTH_DETL_POSTING = 'Y'`, joined to its parent by
`OLD_SRNO = SR_NO`: `MAIN_SRNO 1`, `SR_NO`, `ISR_NO`, `VCH_DATE`, `ENTRY_TYPE 'S'`, `BOOK_NAME` = `BOOK_SNAME`, `AC_CODE`,
`IT_CODE`, `DM_CODE`/`DM_ORIGIN`/`DM_REMARK`/`DM_SIZE`/`DM_COLOR` from the stone (NULL — the form never writes them),
`DM_LOT_NO ''`, `DM_PCS` = `IT_PCS`, `DM_WT` = `IT_GWT`, `DM_SIGN '-'`, `DM_RATE` = `IT_RATE`, `DM_AMT` = `IT_AMT`,
`EMP_CODE ''`, `TAG_NO`, `VCH_SRNO`, `MAIN_IT_CODE` = the parent's item, `INOUT_TYPE 'O'`. The desktop's `TBL_CODE` has no
`DM_DATA` column in the web schema. A transfer writes no `DM_DATA`.

### K9. Numbers, time and user

1. Create: `VCH_NO` = MAX + 1 over `BAR_CAN_DATA` for company, location, year and book (the desktop replaces a taken
   number by MAX + 1, :4985-4995), under the numbering lock. `HD_VCH_NO` = MAX + 1 over `TEMP_BOOK_DATA` for company,
   location and book (`CLEAR_DATA`), and one `TEMP_BOOK_DATA` row (keys, `VCH_NO` = `HD_VCH_NO`, `BOOK_NAME` =
   `BOOK_DATA.BOOK_NAME`). `SR_NO` = `OLD_SRNO` = the line's position (1…n). `VCH_TIME` = date + wall clock; `MAIN_USER` =
   the acting user.
2. Edit: the voucher keeps `VCH_NO`, `HD_VCH_NO`, the `VCH_TIME` clock and `MAIN_USER` (`DISPLAY_DATA`); the date may
   change. `SR_NO` = the line's position; a kept line keeps its `OLD_SRNO`; a new line takes one more than the highest
   `OLD_SRNO` on the voucher (`CommPassAdd` in edit mode). **Web adaptation:** a removed middle row leaves no gap in
   `SR_NO` (the desktop's Ctrl+D clears the row in place).

### K10. Edit

In one transaction: lock (K2.6), check the period for the saved and the new date (K12), give back the voucher's own tags
(its `-` rows are deleted; a `TAG_STOCK`-only tag is re-inserted, K11.3), delete `BAR_CAN_DATA/DETL/IDTL`, `MAIN_STOCK`,
`DM_DATA`, `LOT_DETL` and the `TEMP_BOOK_DATA` row, then resolve every line again (K2) and write K6-K9. A tag dropped from
the voucher is available again; a tag kept is re-reserved; a tag added must be live. No `DELETE_DATA` on edit.

### K11. Delete (`BtnDelete_Click`, :5331-5362)

1. One `DELETE_DATA` row per `BAR_CAN_DETL` row: keys, `SR_NO`, `VCH_DATE`, `DELETE_DATE` = today, `VCH_TYPE` =
   `BOOK_SNAME`, `VCH_TIME`, `DELETE_TIME` = now, `BOOK_NAME` = `BOOK_DATA.BOOK_NAME` (first 20 characters), `AC_CODE`,
   `AC_NAME ''`, `VCH_VAL_DR 0`, `VCH_VAL_CR 0`, `FINE_TYPE` = `IT_TYPE`, `VCH_FINE_DR 0`, `VCH_FINE_CR` = `ITM_NWT`,
   `HD_VCH_NO`, `MAIN_USER` = the row's, `DELETE_USER` = the acting user, `VCH_DESC` = `'ItCode/' + IT_CODE + ' TagNo/' + TAG_NO`.
2. Then delete `TEMP_BOOK_DATA` (the voucher's `HD_VCH_NO`), `MAIN_STOCK`, `DM_DATA`, `LOT_DETL`, `BAR_CAN_DATA`,
   `BAR_CAN_DETL`, `BAR_CAN_IDTL` — all in one transaction (the desktop runs them as separate statements; a failure
   part-way would leave a half-deleted voucher).
3. A `TAG_STOCK`-only tag consumed by the voucher is re-inserted into `TAG_STOCK` unless a `BAR_DETL` instance or a
   `TAG_STOCK` row already vouches for it (`releaseRateCutTagsTx` rule). A `BAR_DETL` tag becomes available because its `-`
   row is gone. **The restore is lossy** — it can only use what `BAR_CAN_DETL` kept: serial, pieces, gross and net weight,
   design, size, `PR_CODE` and `IT_TYPE` (the line's item's when the tag had none), labour, other amount, MRP and image
   come back; `SR_NO`, `GR_CODE`, `GR_NAME`,
   `GR_RATE`, `PR_NAME` and `MAIN_USER` do not, and `STK_TYPE` comes back as 'R' (as every web restore path writes it). A
   `TAG_STOCK` tag is a web-only construct; the desktop has no such row to restore.

### K12. Guards

- Voucher date inside the fiscal year (`YEAR_MAST`, desktop :4960) and after the lock date (`CO_SET.LOCK_DATE`, :4965 —
  "You Cant Save and Delete This Voucher Becouse Lock Date is = …"); delete checks the saved date.
- Rights: `Inventory/Tag Cancel` and `Inventory/Tag Transfer` (view, create, update, delete). The per-voucher
  `USER_UPDATE`/`USER_DELETE` overrides, the licence check and the company-type-B check are not modelled.
- A loose line with gross, labour, other or MRP but no item: "Please Select Item Code In Row N and Try......" (:5006).
- An unknown employee, item or transfer item is refused.

### K13. Transfer specifics

1. **Web adaptation:** every transfer line must name a transfer item that exists in `ITEM_MAST`. The desktop lets it be blank,
   and a blank line silently becomes a cancel (insert 2 is skipped) inside a transfer voucher.
2. The transfer item may be the tag's own item (tag → loose of the same item). `CommPassAdd` copies the previous row's
   transfer item into a new row; the screen does the same.
3. Loose lines are allowed in both modes (a loose-to-loose transfer moves metal between items).

### K14. Reading

- `GET …/:vchNo` returns the header, every line (with item and transfer-item names, `OLD_SRNO`, serial and all cells), each
  line's stones, and the totals of `MSG_TOT_FILL` — `DISPLAY_DATA`.
- `GET …` (the voucher help, `BtnF1_Click`): VchNo, date, party name, description, user for the book in this company,
  location and year, in `VCH_NO` order, plus the next number. The screen's `<` / `>` step through it (`BtnFirst` /
  `BtnLast` move one voucher down / up, skipping gaps).
- `GET …/source?tagNo=&vchSrno=`: the K3 tag fill and K5 stones for one live instance, without reserving it — the same
  function the save uses, so the screen shows what will be saved.

### K15. Screens

`/txn/tag-cancel` and `/txn/tag-transfer` mount one form (`components/TagCancelForm.tsx`, model in `lib/tagCancelVoucher.ts`).

- **Header:** book (only its `MAIN_BOOK`), Vch No with Enter = load, `<` / `>`, F1 voucher list; Vch Date; Employee
  (picker); Vch Desc. The hidden number is shown read-only after save.
- **Grid** in the desktop column order. Cancel: Sr, TagNo, ItCode, Counter, Design, Size, BagWt, Pcs, GrWt, LsWt, NetWt,
  Ght%, GhtWt, Touch, West%, Fine, LbrRate, LbrAmt, OthAmt, Mrp, KrCode. Transfer: Sr, TagNo, ItCode, Counter, Design, Size,
  BagWt, Pcs, GrWt, LsWt, NetWt, Touch, West%, Fine, TrfrItm, TrfrItmName. ItCode, Counter, Pcs and KrCode are read-only on
  a tag line. Ght% is display-only (K3). A totals row under the grid (`MSG_TOT_FILL`). The item name of the current row.
- **Image (web adaptation):** the panel shows the tag's own image (`EntityImagePanel`, entity `TAG`, read-only, served under
  the `Inventory/Tag Print` right) where the desktop shows the design image (`DESIGN_IMG_ID`). The register still saves
  `DESIGN_IMG_ID` from the tag (K6); the tag's image store is never touched (K6), so the picture shown is the one a
  reversal gives back.
- **Tag entry:** the available-tag picker (one row per live instance, serial shown when a number repeats); a typed number
  resolves on leaving the cell when it names exactly one live instance; "Duplicate Tag No" is shown at once. A row whose
  retyped number is not resolved yet still holds the old tag's cells, so Save is refused until it is resolved or cleared.
- **Stones** of the current row (`MSG_IDTL`): Sr, ItCode, ItName, Pcs, Weight, KrWt, Con%, P/W, Rate, ItAmt, LbrRate,
  LbrAmt, NetAmt — editable, with K5.4 applied to the row. A row's stones are sent only when the operator edited them;
  otherwise the server copies the tag's (new line) or keeps the saved ones (kept line), K5.1/K5.2.
- **Every computed cell is `@datacare/core`** (`tagCancelRecompute`, `tagCancelStone`, `tagCancelTotals`) run with the
  row's baseline when a cell is left (blur), like the desktop's `MSG_LeaveCell`, which recomputes whether or not the value
  changed; the screen then sends every cell of the row (K4.3).
- **Lifecycle:** Save posts (or updates a loaded voucher), then reloads it; Delete asks for confirmation; Cancel clears.

### K16. Containment and provisioning

1. `tag-cancel` and `tag-transfer` leave the containment registry (`packages/core/containment.mjs`) with a discharge note
   citing this contract and its evidence; `tag-weight-difference`, `tag-split`, `logical-restore` and
   `production-cutover-load` stay blocked. Merging the change is the release decision; cards X18/X19 stay open until the
   desktop replay and business acceptance.
2. A new company gets `TGC` (Tag Cancel, `TAG CANCEL`, 'O', `BOOK_SNAME 'TGCAN'`) and `TTR` (Tag Transfer, `TAG TRFR`, 'O',
   `BOOK_SNAME 'TAGTR'`), both `BOOK_TBL_NAME 'BAR_CAN_DATA'` (the desktop's own short names, `verify-stock-tags.md` §0:
   `016/TGCAN/TAG CANCEL`, `121/TAGTR/TAG TRFR`).

## Vectors

Fixture (DB tests): company 01, locations 01 and 02, year 2024-2025, books `TGC` (Tag Cancel / TGCAN / TAG CANCEL / O) and
`TTR` (Tag Transfer / TAGTR / TAG TRFR / O), `CO_SET.LBR_TYPE` blank, `LBR_WITH_GHT` blank, employee 001. Items `RNG`
(Ring 22K, G, `PR_CODE` RG), `OG` (Old Gold, G), `OS` (Old Silver, S), `DIA` (Diamond, D, `OTH_DETL_POSTING` Y), `CZ` (CZ
stone, D, N).

| Tag | Instance | Setup |
|---|---|---|
| RNG00001 | 100100000001, loc 01 | Tag opening TOP/00001 SR 1: gross 10.500, less 0.500, net 10.000, touch 91.60, wastage 2.00, fine 9.360, KR net 10.000 / touch 90 / wastage 1.5 / fine 9.150, labour N 150 = 1500, other 1200, bag 0.050, counter 001, design D-101, size 12, KR_NAME KJ, image IMG-101. Stone DIA ×10, 0.500, KrWt 0.500, Con% 1, W, rate 2000, amount 1000, labour 20 → 200, net 1200 |
| RNG00002 | 100100000002 sold; 100100000009 live | The number was re-used: the old instance has a `-` row, the new one a `+` row. Stone CZ ×2, 0.040, amount 50 on the live one |
| RNG00003 | 100100000003 and 100100000004, both live | Two live instances of one number |
| RNG00004 | 100100000005, loc 02 | Another location |
| RNG00005 | 100100000006 | Two `BAR_DETL` rows for the instance (TOP/00001 SR 5 and a return voucher WRT/00001 SR 1), one stone each |
| TS00001 | TAG_STOCK only, serial 1 | Web tag: IT_TYPE G, 1 pc, 5.200 / 5.000, MRP 25000 |

| ID | Action | Expected |
|---|---|---|
| V1 | Cancel TGC create on 2024-06-10, employee 001, desc "Damaged": RNG00001; RNG00002 #…009; loose OG gross 2.000 touch 75 | `TEMP_BOOK_DATA` (TGC, 00001, "Tag Cancel"). Header K6 with `HD_VCH_NO` 00001, `AC_CODE ''`. DETL 1: RNG00001, OLD_SRNO 1, TGCAN / O / T / TAG CANCEL, `TRFR_IT_CODE` NULL, `LOT_NO ''`, the K3 values (fine 9.360, KR_FINE 9.150, LBR_AMT 1500, OTH_AMT 1200, DESIGN_IMG_ID IMG-101), `VCH_SRNO` 100100000001. DETL 2: RNG00002, `VCH_SRNO` 100100000009. DETL 3: OG, `TAG_NO 'N'`, `VCH_SRNO 0`, net 2.000, fine 1.500, KR = item values, `LBR_TYPE 'G'`, `DESIGN_IMG_ID 'N'`, `IT_TYPE 'G'`. IDTL: DIA (SR_NO 1, ISR 1, serial 100100000001), CZ (SR_NO 2). `MAIN_STOCK` three '-' rows (K7 insert 1), `DATA_TYPE 'A'`. `DM_DATA` one row (DIA: DM_PCS 10, DM_WT 0.5, DM_RATE 2000, DM_AMT 1000, MAIN_IT_CODE RNG, BOOK_NAME TGCAN). Nothing else in the database changes |
| V2 | Edit V1: drop RNG00002, add RNG00003 #…004, loose touch 80 | `HD_VCH_NO`, clock and `MAIN_USER` kept. DETL SR 1 RNG00001 (OLD 1), SR 2 OG (OLD 3, fine 1.600), SR 3 RNG00003 (OLD 4). RNG00002 #…009 available again; RNG00003 #…004 not; #…003 untouched. No `DELETE_DATA` |
| V3 | Delete V1 | Three `DELETE_DATA` rows (`VCH_FINE_CR` = net, `FINE_TYPE` G, `VCH_DESC` `ItCode/RNG TagNo/RNG00001`, `BOOK_NAME` "Tag Cancel"), then the voucher's rows and `TEMP_BOOK_DATA` gone; every tag available; the database equals its state before V1 except `DELETE_DATA` |
| V4 | RNG00003 without `vchSrno` | 400 ambiguous; nothing written, no number used |
| V5 | RNG00001 twice | 400 "Duplicate Tag No" |
| V6 | RNG00004 from location 01 | 400 not available |
| V7 | Cancel RNG00001 and sell RNG00001 concurrently | Exactly one commits; the other 400 "tag not available"; no partial rows |
| V8 | Transfer failing on the `+` leg (injected) | Nothing written; the TAG_STOCK tag still there; no `TEMP_BOOK_DATA` |
| V9 | `LOCK_DATE` 2024-06-30, cancel dated 2024-06-10; delete of a voucher dated 2024-06-10 | 400 period lock each; nothing written or deleted |
| V10 | Cancel TS00001 (item RNG), then delete | `TAG_STOCK` row removed, then restored with its weights |
| V11 | Cancel RNG00005 | One stone copied (the first `BAR_DETL` row's), not two |
| V12 | Cancel through `TTR`; transfer through `TGC`; a book with `CUR_USE` N | 400 each |
| T1 | Transfer TTR create: RNG00001 → OG | DETL `VCH_TYPE 'TAGTR'`, `BOOK_NAME 'TAG TRFR'`, `TRFR_IT_CODE 'OG'`; IDTL the DIA stone; `MAIN_STOCK` ISR 1 '-' RNG00001 and ISR 2 '+' OG, `TAG_NO 'N'`, `VCH_SRNO 0`, `TBL_CODE '001'`, `TR_TYPE 'I'`, pcs 1, gross 10.5, net 10, touch 91.6, wastage 2, fine 9.36, rate / amounts 0, KR as the tag; no `DM_DATA`. OG's loose stock rises by exactly the tag's weight and fine |
| T2 | Transfer line without a transfer item; with an unknown item | 400 each |
| T3 | Edit T1 to OS | The `+` row moves to OS; the tag stays transferred |
| T4 | Delete T1 | `DELETE_DATA` with `VCH_TYPE 'TAGTR'`, `BOOK_NAME` "Tag Transfer"; both stock rows gone |

## Web adaptations (summary)

A1 ambiguous serial refused (K2.3). A2 a non-qualifying tag line and an empty voucher refused (K6). A3 stones of the first
`BAR_DETL` row only (K5.1). A4 no `SR_NO` gap after a removed row (K9.2). A5 transfer item required (K13.1). A6 delete and
edit are one transaction (K11.2). A7 `DATA_TYPE` 'A' when the book's is blank (K1.2). A8 deadlock / serialisation → 409.
A9 `RE_TRFR`, `DM_DATA.TBL_CODE` have no web column; `MAIN_STOCK.ENTRY_TIME` is a date (K7). A10 the tag's own image
instead of the design image (K15). A11 the `TAG_STOCK` restore is lossy (K11.3). A12 a read-only or other-mode cell with a
different value is refused rather than ignored (K3, K4.4). A13 Save waits for a retyped tag to be resolved (K15).

## Open items (not claimed)

- Print (`TagCanBill.rpt`), the `COL_MAST` `TAG_CAN_DETL` / `TAG_IDTL` column overrides, `EMP_AS_USER` default employee,
  the description help (`VCH_DESC_HELP_LENT`) and `DESIGN_HELP` list order.
- The `STOCK ADJUST` and `TAG ADJ` modes of `TR_TAG_CAN` (X20 and the existing tag-adjust module).
- Negative loose stock is not refused (the desktop does not refuse it either).
- The desktop's per-voucher `USER_UPDATE`/`USER_DELETE`, licence and company-type-B checks.
- Lifecycle labels outside this form: that reports and physical-stock screens show a cancelled or transferred tag as such
  (J14 step 5) is not verified here; the available-tag lookup and the resolver are.
- Master-plan wording: J14 step 2 describes a transfer "to another permitted counter/location". `TR_TAG_CAN`'s `TAG TRFR`
  mode moves a tag's metal to a loose item (K7, K13); a counter move is the desktop's separate Counter Transfer form. This
  contract follows the desktop source.
- Cards X18/X19 remain open until the desktop replay (a live Windows capture of V1-V3 and T1-T4) and business acceptance.

## Verification added after the first implementation pass

- **K2.6 lock order**, deterministically: another writer holds the lower tag number; a voucher naming the higher number first
  must wait for it holding no lock (`pg_locks` probe) — `tagCancelLifecycle.db.test.ts` "locks every tag in sorted order".
  The V7 race now requires the loser's reason to be exactly `TagNotAvailableError` (sorted locks leave no deadlock).
- **A8 over HTTP**: a real lock cycle with another writer; the save is PostgreSQL's deadlock victim and the route answers 409
  `TagCancelConflictError`, with no row written and no number used — `tagCancel.routes.db.test.ts`.
- **K9.2**: an edit keeps its hidden number while a later voucher holds a higher one (a fresh `MAX + 1` would not).
- **A2**: a live tag with no pieces, weight or amount is refused and stays in stock.
- **K16.2 data migration** (`20260929010000_tag_transfer_book`): one guarded transaction that refuses a migration role row-level
  security would filter, then moves `TAG TRANSFER` books (and their `BOOK_DETL`) to `TAG TRFR` / `TAGTR` and leaves desktop
  books alone — `tagTransferBookMigration.db.test.ts`.
- Mutation checks: 60 deliberate breaks across writer, row model, resolver, 409 mapping, provisioning, rights, core arithmetic
  and the screen model, all caught ([mutation-checks.json](mutation-checks.json), script [mutation-check.py](mutation-check.py)).
- Real browser: journey `tag-cancel-transfer` ([real-stack-result.json](real-stack-result.json)).
