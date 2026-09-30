# Contract: N19 — Tag Split (X20), desktop `TR_TAG_SPLIT`

Master plan slice N19 (`docs/master-parity-plan-2026-09-29/02-execution-plan.md` §3, on the `docs/master-parity-plan-2026-09-29` branch): *implement tag split and explicit weight replacement separately, including sale-driven `SL_TAG_WT_DIFF` ownership; child identity allocation and conservation; every parent relation and image correct.* This contract covers **Tag Split (card X20 / P07-04)** only; weight replacement (X21) is a separate slice. Verification journey J15 (`04-verification-playbook.md`).

The desktop menu "Tag Split" opens `TR_TAG_SPLIT` on a book of `MAIN_BOOK = 'TAG SPLIT'` (MDI_FORM.cs:8686-8695, `CurBookHelp("TAG SPLIT")`). One or more **parent** tags are consumed and one or more **child** tags are created, conserving metal. Every expected value below is taken from the desktop source. None is taken from web code. No desktop split voucher was ever captured (`project-memory/parity/verify-stock-tags.md` §0: the demo has no `TAG SPLIT` rows), so the database diff is derived from the source and the vectors are source-derived, not replayed. Where the web deliberately differs, the entry says **Web adaptation**.

## Sources

Paths are relative to `unified/src/csharp/DataCareNext/`. Hashes are SHA-256, first 16 hex characters.

| File | sha256/16 | Lines used |
|---|---|---|
| MDI_FORM.cs | cb91085c50d07a07 | 8686-8695 "Tag Split" → `CurBookHelp("TAG SPLIT")`, opens `TR_TAG_SPLIT` |
| TR_TAG_SPLIT.cs | d43ab71230437abd | See the list below |
| Ac_Stock.cs | 946f9ba4f7e85835 | 403-413 `Tag_Split_Stk` (MAIN_STOCK); 841-847 `Dm_Tag_Split_Detl` (DM_DATA) |
| Ac_Ledr.cs | b58ba77dbd2c960f | 1951-1985 `Tag_Split_Ledr` (AC_DATA legs 01-10) |
| Ac_Rojmel.cs | d1097c87b8109a31 | 929-941 `Tag_Split_Rojmel` (ROJ_MEL_DATA legs 01-05) |
| MS_OPNCOMP.cs | 180f295f9595dfc7 | 678 `TAG_RPT`, 690 `TRAD_FINE`, 710 `EMP_CODE_MANDATORY`, 1006 `LBR_WITH_GHT`, 952 `COUNTER_STK`, 1022 `RENDOM_TAG`, 1023 `RENDOM_WITH_PRCODE` |
| Module_Save.cs | 1775f578aa82706e | 609-654 `RendomTagGen` |

`TR_TAG_SPLIT.cs` lines used:

- 5020-5348 `MSG_PR_CLEAR` (child grid columns), 5332-5355 `CommPassAdd_Pr` (new child row + col 62 VCH_SRNO string), 5361-5975 `TEXT_PR_KeyDown` / `MSG_PR_EnterCell` / `MSG_PR_LeaveCell` (child entry).
- 6075-6198 `NewTagNo` (child tag number allocation), 6338-6704 `CommPassTotal_Pr` (child row arithmetic), 6705-6772 `MSG_PR_TOT_FILL`.
- 6705-6858 `MSG_IDTL_CLEAR`, 7337-7426 `CommPassTotal_Idtl` (parent stone upsert), 4310-4886 `CommPassAdd_Rtn_Idtl` / `CommPassTotal_Rtn_Idtl` (child stone arithmetic and its effect on the child row).
- 7428-7735 `MSG_CLEAR` (parent grid columns), 7736-7783 `MSG_TOT_FILL`, 8073-8160 `CommPassTotal`.
- 8162-8570 `TEXT_ENTRY_KeyDown` (parent tag entry, lookup SQL, duplicate check, instance picker, cell fill, `chkSameTag`).
- 9322-9461 `CLEAR_DATA`, 9461-9960 `DISPLAY_DATA`, 9960-10770 `BtnSave_Click`, 10774-10869 `Mobile_image_Save`, 10871-10912 `BtnDelete_Click`, 12200-12256 `BILL_TOTAL`.

## Findings in the web before this slice

The web `stock/tagSplit.ts` (198 lines) is a thin, HTTP-contained (503) placeholder:

1. **Stock only.** It writes `MAIN_STOCK` for the parent (`SR_NO 1`, '-') and each child (`SR_NO i+2`, '+'), and nothing else. No `LBR_DATA/ISU_DETL/ISU_IDTL`, no `LBR_REC_DETL`, no `BAR_DATA/DETL/IDTL`, no `AC_DATA`, no `ROJ_MEL_DATA`, no `DM_DATA`, no `TEMP_BOOK_DATA`, no image.
2. **No identity.** The parent is not resolved through the shared resolver, so no live check, no location, no serial and no lock. A sold parent could be split and the same parent split twice.
3. **No child creation.** Child tag numbers come from the client (the page even picks *existing* tags), no `TAG_NO`/`VCH_SRNO`/`TAG_SRNO` is allocated, and no `SRNO_MAST` row is written — so a child tag has no barcode record and cannot be sold, cancelled or transferred afterwards.
4. **Stock columns missing.** `STK_DATE`, `AC_CODE`, `TBL_CODE`, the whole karigar block, `ENTRY_TIME`, `MAIN_USER`, `DATA_TYPE`, `DESIGN_NO`, `ITM_SIZE`, `GHT_PRC` are unset; `SR_NO`/`ISR_NO` do not carry the desktop's leg semantics.
5. **No lifecycle.** No read, edit or voucher list; delete removes the `MAIN_STOCK` rows only and restores nothing.

## Contract

### K1. Form, book and mode

1. The web keeps one page `/txn/tag-split` (`components/TagSplitForm.tsx`, model `lib/tagSplitVoucher.ts`) and one writer `modules/stock/tagSplit.ts`, on `TAG SPLIT` books only.
2. The book must be exactly one `BOOK_DATA` row for the company, location and `CO_BOOK`, with `CUR_USE = 'Y'` and `MAIN_BOOK = 'TAG SPLIT'`. Anything else is refused (400). The desktop's book help offers only such books (`CurBookHelp`).
3. From the book: register `VCH_TYPE` = `BOOK_SNAME`, `INOUT_TYPE` = `BOOK_INOUT`, `BOOK_NAME` = `MAIN_BOOK`, `MAIN_STOCK.DATA_TYPE` = the book's `DATA_TYPE` (**Web adaptation:** 'A' when blank, as every web stock writer does). `Tag_Split_Stk` joins `BOOK_DATA`, so `CUR_USE` is not re-checked in the stock insert; the book resolver enforces it.

### K2. Parent identity, availability and locks

1. A parent line names a tag; the number is trimmed and upper-cased. The desktop's live-tag query (`TEXT_ENTRY_KeyDown`, :8355) is:
   `SELECT … FROM MAIN_STOCK A LEFT JOIN BAR_DETL B … WHERE A.TAG_NO=@t AND B.EMP_ISU<>'Y' GROUP BY … HAVING SUM(CASE WHEN A.ITM_SIGN='+' THEN A.VCH_SRNO ELSE -A.VCH_SRNO END) > 0 ORDER BY B.VCH_TIME DESC`.
   The web resolves the same "in stock" condition through the shared resolver `issueTagTx` (a `TAG_STOCK` row, or an available `BAR_DETL` instance), so a split, a sale, a cancel and a transfer agree on what "in stock" means.
2. **Web adaptation (fail closed):** two live instances of one number with no `vchSrno` on the line are refused (`TagIdentityAmbiguousValidationError`). The desktop opens an instance picker (:8480) and takes the chosen serial.
3. The same tag number twice among the parent lines is refused with the desktop message **"Duplicate Tag No"** (:8501), by number.
4. **Locks (K-parity with N18).** Every tag number the save touches — each parent's, each child's, and on edit/delete the saved voucher's own parents and children — is locked in sorted order with the resolver's key (`pg_advisory_xact_lock(hashtext('tag-issue|CO|LC|TAG_NO'))`) before any tag is resolved, reserved or written. An edit or delete first takes the header row `FOR UPDATE`. A deadlock or serialisation failure (Prisma P2034, SQLSTATE 40P01/40001) is reported as 409 `TagSplitConflictError`, never a 500 or a partial write.
5. A parent that is another location's tag, sold, already split, employee-issued or already cancelled is "not available" and refused.

### K3. Parent line fill (tag entry, :8341-8570)

A parent line starts from the live instance's first `BAR_DETL` row (`ORDER BY row_id`), with the desktop grid formats:

| Cell | From `BAR_DETL` | Format |
|---|---|---|
| IT_CODE, TBL_CODE, DESIGN_NO, ITM_COLOR, ITM_SIZE, HM_ID, KR_NAME | text | |
| BAG_WT, ITM_GWT, ITM_OTH_WT, ITM_NWT, KR_OTH_WT, KR_NET_WT, KR_GHT_WT, KR_FINE, ITM_GHT_WT, ITM_FINE | weights | 0.000 |
| ITM_PCS | | as stored |
| ITM_GHT_PRC, KR_TOUCH, KR_WEST_PRC, ITM_TOUCH, ITM_WEST_PRC, LBR_PRC, LBR_RATE, LBR_AMT, OTH_AMT, KR_LBR_RATE, KR_LBR_AMT, KR_OTH_AMT, ITM_RATE, ITM_AMT, KR_COST, TAG_COST, ITM_MARGIN, ITM_MRP | rates / money / purity | 0.00 |
| LBR_CODE, LBR_TYPE, RATE_TYPE, IT_TYPE, TAG_TYPE, PR_CODE, DATA_TYPE, DESIGN_IMG_ID, HM_ID2/3/4 | text | |
| VCH_SRNO (col 61), TAG_SRNO (col 55) | the tag instance | |

The parent line is stored verbatim (a parent is not recomputed); it is the metal being consumed. The parent's stones are its `BAR_IDTL` rows (same load as N18 K5.1), stored to `LBR_ISU_IDTL`.

**`chkSameTag` (Web adaptation: not offered.)** The desktop's "same tag" tick pre-loads one child identical to the parent, keeping the parent's `TAG_NO`. The web always allocates fresh child numbers (K4), so a straight re-tag is a one-child split with a new number. The desktop's image copy only fires under `chkSameTag` (it keys the image on the parent's own number), so the web's image lineage rule is stated in K8.

### K4. Child tag allocation (`NewTagNo`, :6075-6198)

Each child line names an item and gets a fresh tag number. **Web adaptation:** the web allocates the child number through the shared `nextTagNoTx` (an advisory lock on `tag|tenant|CO|LC`, a `SRNO_MAST` row `FOR UPDATE`, `TAG_SRNO`+1, and a `PR_CODE`+serial number), which is unique and locked. The desktop's `NewTagNo` sequential branch reads `MAX(TAG_SRNO)` from `BAR_DETL` for the item's `PR_CODE`+`TAG_TYPE` with **no lock and no company filter**, then composes `TAG_NO = PR_CODE + TAG_TYPE + numeric(LC) + serial`; its random and reuse branches (`RENDOM_TAG`, `TAG_RPT`) are settings the web does not model. The web's number is derived from the child item's `PR_CODE` (prefix) and the tenant serial, so it is stable, unique and race-safe. `VCH_SRNO` for a child is the allocated `srno` (as tag opening and purchase do), not the desktop's minute-resolution timestamp string (col 62, :5345) — that string is not unique under concurrency and is a documented web deviation.

A child line the operator gives: ItCode (required), TBL_CODE, DESIGN_NO, ITM_SIZE, Pcs, GrWt, LsWt, NetWt, GhtWt, Touch, West%, Fine, LbrRate, LbrAmt, OthAmt, Mrp, ItRate, sign (default '+'), KrCode and the karigar block, and its own stones. Read-only cells: the allocated TAG_NO, TAG_SRNO, VCH_SRNO, PR_CODE, TAG_TYPE.

### K5. Child arithmetic (`CommPassTotal_Pr`, :6338-6704) — `@datacare/core` `tagSplitChild`

The child row recomputes on each leave, exactly as the desktop's `CommPassTotal_Pr`:

1. Net = GrWt − LsWt; KrNwt = GrWt − KrOthWt.
2. GhtWt = Net × Ght% / 100.
3. Fine = (Net + GhtWt) × (Touch + West%) / 100 when Touch + West% ≠ 0, else Fine = Net + GhtWt. KrFine likewise from the karigar block.
4. Item amount by `RATE_TYPE`: P → Pcs × ItRate; '1' → Fine × (ItRate/10); K → Fine × (ItRate/1000); else Fine × ItRate — `Math.Round(…, 0)`.
5. Labour by `LBR_TYPE`: P → Pcs × LbrRate; N → Net × LbrRate (or (Net+GhtWt) × LbrRate when `LBR_WITH_GHT` ≠ 'N'); K → (Net+GhtWt) × (LbrRate/1000); else GrWt × LbrRate — `Math.Round(…, 0)`. Karigar labour likewise.
6. TagCost / PrCost = KrLbrAmt + KrOthAmt + ItAmt; Mrp/margin = round(TagCost × (1 + Margin/100)). (The `SSRegSrNo` special branches and the `VK191NEVK` fine columns are per-installation and out of scope.)
7. Weights `Strings.Format` (half-up); money `Math.Round` (half-to-even), in the desktop operand order.

Every computed cell is the same `@datacare/core` function on the screen and the server, run in the operator's cell order with the row's recompute baseline (as N18 does for cancel/transfer).

### K6. Child stones (`CommPassTotal_Rtn_Idtl`, :4758-4886)

A child's stones are the operator's (there is no parent-stone-to-child copy in scope). Stone arithmetic (`@datacare/core` `tagSplitStone`): Weight = Pcs × PcsWt (or from karigar weight); ConWt = Weight × Con%; KrConWt = KrWt × Con%; item amount by P/W; labour = Pcs × LbrRate; net = amount + labour. On the child row: Σ ConWt → LsWt and Net = GrWt − Σ; Σ KrConWt → KrOthWt and KrNwt; Σ net → OthAmt; Σ KrAmt → KrOthAmt and TagCost. A stone row is saved when `IT_PCS + IT_GWT + IT_NET_AMT ≠ 0` (the save's :10361 filter). Parent stones (`LBR_ISU_IDTL`) are the parent's own `BAR_IDTL` rows; a child's stones go to `LBR_REC_DETL`'s `BAR_IDTL`.

### K7. Conservation and the balance (`BILL_TOTAL`, :12200-12256)

1. The balance is the parent net total (`MSG_TOT[0,12]`) against the child net total (`MSG_PR_TOT[0,13]`):
   - parent net > child net → **Dr** (issued/short) = parent − child;
   - child net > parent net → **Cr** (received/surplus) = child − parent.
2. The save refuses **"Please Insert diff Wt in Received Grid and Try...."** when no absorbing account is given and the parent and child nets differ (:9979). **Web adaptation:** the web requires the child net total to equal the parent net total within a documented tolerance (0.001) unless a `tAcCode` absorbing account is given; with an absorbing account, the residual posts the `Tag_Split_Ledr` fine legs (K9). The desktop lets the difference stand only when an account absorbs it.
3. `nCrFine`/`nDrFine` = the Cr/Dr weight × the operator's `nCrTouch`/`nDrTouch` / 100 (else the weight). `nCrLbrAmt` (a labour difference) is header input; it drives the labour ledger legs 01/02.

### K8. Register and write set (`BtnSave_Click`, :9960-10770)

In one transaction, after resolving and locking (K2):

1. **`TEMP_BOOK_DATA`** (keys, `VCH_NO = HD_VCH_NO`, `BOOK_NAME` = the book's name).
2. **`LBR_DATA`** header (one row): keys, `VCH_NO`, `AC_CODE` = the absorbing account (blank when none), `VCH_DATE`, `HD_VCH_NO`, `VCH_TYPE` = `BOOK_SNAME`, `INOUT_TYPE`, `ENTRY_TYPE 'C'`, `BOOK_NAME` = `MAIN_BOOK`, `CR_WT`/`DR_WT`/`CR_TOUCH`/`DR_TOUCH`/`CR_FINE`/`DR_FINE` (the balance, K7), `CR_LBR` = the labour difference, `DR_LBR 0`, all rate/amount 0, `IT_TYPE`, `EMP_CODE`, `VCH_DESC`, `VCH_TIME` = date + clock, `DATA_TRFR 'N'`, `MAIN_USER`, `USER_UPDATE 'N'`, `USER_DELETE 'N'`. Written only when the voucher carries something (:10078).
3. **`LBR_ISU_DETL`** — one row per parent line (`ENTRY_TYPE 'O'`): the K3 columns, `SR_NO`, `OLD_SRNO`, `VCH_SRNO` = the parent instance.
4. **`LBR_ISU_IDTL`** — the parent lines' stones (`ENTRY_TYPE 'S'`), keyed to the parent by `SR_NO` and carrying its `TAG_NO`/`VCH_SRNO`.
5. **`LBR_REC_DETL`** — one row per child line (`ENTRY_TYPE 'O'`): the child cells, `TAG_NO` ('N' when blank — but the web always allocates one), `ITM_SIGN`, `TAG_SRNO`, `TAG_TYPE`, `PR_CODE`, `VCH_SRNO`, `EMP_ISU`, `DATA_TYPE` ('A' when blank). Row saved when `ITM_GWT + ITM_MRP + OTH_AMT ≠ 0` and IT_CODE ≠ '' (:10332).
6. **`BAR_DATA`** (one row) and **`BAR_DETL`** — one **child** tag record per child line (`ENTRY_TYPE 'I'`): the full child column set (the same wide set N18's tag fill reads), so each child is a real, sellable tag. **`BAR_IDTL`** — the child stones (`ENTRY_TYPE 'S'`).
7. **`MAIN_STOCK`** via `Tag_Split_Stk` (Ac_Stock.cs:409/411), built from `LBR_ISU_DETL`/`LBR_REC_DETL`:
   - insert 1, every parent: `SR_NO 1`, `ISR_NO` = the parent's line SR_NO, `TR_TYPE 'O'`, `ITM_SIGN '-'`, `VCH_TYPE` = `BOOK_SNAME`, `BOOK_NAME` = `MAIN_BOOK`, `ITM_WEST 0`, `NET_AMT` = the parent's, `KR_*` from the parent, `ENTRY_TIME` = `VCH_TIME`, `DATA_TYPE` = the book's.
   - insert 2, every child: `SR_NO 2`, `ISR_NO` = the child's line SR_NO, `TR_TYPE` = 'I' when `ITM_SIGN='+'` else 'O', `ITM_WEST` = the child's `ITM_WEST_PRC`, `ITM_MRP` = the child's, `NET_AMT 0`, `KR_LBR_AMT`/`KR_OTH_AMT`/`KR_COST` from the child, `GHT_PRC` = the child's `ITM_GHT_PRC`, `DATA_TYPE` = the child's.
8. **`AC_DATA`** via `Tag_Split_Ledr` (Ac_Ledr.cs:1953-1982) — only when the header has an absorbing account and a non-zero labour or fine difference: legs 01/02 the labour (party ↔ book slot 5), 03/04 gold DR fine (slot 6, +its `TRAD_FINE` mirror), 05/06 silver DR fine (slot 8), 07/08 gold CR fine (slot 7), 09/10 silver CR fine (slot 9). Even legs 04/06/08/10 fire only when `TRAD_FINE = 'Y'`.
9. **`ROJ_MEL_DATA`** via `Tag_Split_Rojmel` (Ac_Rojmel.cs:929-941): legs 01 (Dr gold), 02 (Cr gold), 03/04 (silver), 05 (labour), each only when its fine/labour and account are present and `VCH_DATE ≥ MOp_dt`.
10. **`DM_DATA`** via `Dm_Tag_Split_Detl` (Ac_Stock.cs:843/845): OUT from the parent stones and IN from the child stones, for stone items with `OTH_DETL_POSTING = 'Y'`.
11. **Image (Web adaptation).** The desktop copies the parent's `TAG_IMAGE_DATA` to a child only under `chkSameTag`, keyed on the parent number. The web instead links each child to the parent's image through `queueTagImageTransfer` (the existing web tag-image lineage helper), so a child shows the parent's picture until its own is set. The parent's own image is never modified.

### K9. Numbers, time and user

Create: `VCH_NO` = MAX+1 over `LBR_DATA` for company/location/year/book (the desktop replaces a taken number by MAX+1, :10054), under the numbering lock. `HD_VCH_NO` = MAX+1 over `TEMP_BOOK_DATA`. `SR_NO`/`OLD_SRNO` = line position. `VCH_TIME` = date + wall clock; `MAIN_USER` = the acting user. Edit: keeps `VCH_NO`, `HD_VCH_NO`, the clock and `MAIN_USER`; a kept line keeps its `OLD_SRNO`; child tags keep their allocated numbers. **Web adaptation:** no `SR_NO` gap after a removed row.

### K10. Edit

In one transaction: lock (K2.4), check the period for the saved and the new date (K12), give the parent tags back and clear the child tags (their `BAR_DETL`/`MAIN_STOCK` rows are deleted; a `TAG_STOCK`-only parent is re-inserted), delete the whole write set and the `TEMP_BOOK_DATA` row, then resolve every line again and re-write K8. **Web adaptation:** a child that was already sold, cancelled, split again or otherwise moved on since the voucher was saved cannot be removed or re-created; the edit is refused. The desktop does not check this.

### K11. Delete (`BtnDelete_Click`, :10871-10912)

The desktop deletes `SRNO_MAST` (per parent line), `TEMP_BOOK_DATA`, `MAIN_STOCK`, `AC_DATA`, `ROJ_MEL_DATA`, `BILL_OS_DATA`, `DM_DATA`, `LBR_DATA/ISU_DETL/ISU_IDTL/REC_DETL`, `BAR_DATA/DETL/IDTL` for the voucher, in that order, and shows "Delete Success." **Web adaptations:**
1. All deletes run in one transaction (the desktop runs them as separate statements).
2. Each **child** tag is deleted from `SRNO_MAST` by its own allocated `(TAG_NO, VCH_SRNO)` (the desktop deletes by the *parent* grid's `MSG[,61]`/`MSG[,1]`, a decompiler quirk that removes the wrong serials — a desktop bug we do not reproduce).
3. A `DELETE_DATA` audit row is written per parent line (the desktop writes none — a gap we close for parity with the other tag forms, N18 K11).
4. The parent tags become available again (their `-` rows are gone; a `TAG_STOCK`-only parent is restored, lossily, as N18 K11.3). A child that was already sold/split/cancelled blocks the delete (K10 rule).

### K12. Guards

- Voucher date inside the fiscal year (:10005) and after the lock date (`CO_SET.LOCK_DATE`, :10012); delete checks the saved date (:10877).
- Rights: `Inventory/Tag Split` (view, create, update, delete).
- Employee required when `EMP_CODE_MANDATORY = 'Y'` (:9988).
- A child line with weight/amount but no item is refused; the counter is required when `COUNTER_STK = 'Y'` (:10032).
- The company-type-B and licence checks (:9972/:9994) are not modelled.

### K13. Reading

- `GET …/:vchNo`: the header (balance, absorbing account, employee, description), every parent line and its stones, every child line and its stones, and the totals — `DISPLAY_DATA`.
- `GET …`: the voucher list for the book (VchNo, date, description, user, line counts) and the next number.
- `GET …/source?tagNo=&vchSrno=`: the K3 parent fill and its stones for one live instance, without reserving it — the same function the save uses.

### K14. Screens (`TR_TAG_SPLIT` layout)

`/txn/tag-split` mounts `components/TagSplitForm.tsx` (model `lib/tagSplitVoucher.ts`).
- **Header:** book (only `TAG SPLIT`), Vch No with Enter = load, `<` / `>`, F1 list; Vch Date; Employee; absorbing Account (optional); Vch Desc; the balance box (Dr/Cr weight, touch, fine) and the hidden number after save.
- **Parent grid** (`MSG` order): Sr, TagNo, ItCode, Counter, Design, Size, BagWt, Pcs, GrWt, LsWt, NetWt, Touch, West%, Fine, plus the karigar and labour columns. Parent cells are read-only (they come from the tag); the operator only picks the parent tag.
- **Child grid** (`MSG_PR` order): Sr, ItCode, TagNo (allocated, read-only), Counter, Design, Size, Sign, BagWt, Pcs, GrWt, LsWt, NetWt, GhtWt, Touch, West%, Fine, LbrRate, LbrAmt, OthAmt, Mrp, KrCode. The operator types the child cells; TagNo is allocated on item entry and shown.
- **Stones** of the current row (`MSG_IDTL` / `MSG_RTN_IDTL`), editable, with K6 applied.
- A conservation banner: parent net, child net, the difference and whether an absorbing account is needed.
- Every computed cell is `@datacare/core` run on each cell commit.
- **Lifecycle:** Save posts (or updates), then reloads; Delete confirms; Cancel clears.

### K15. Containment and provisioning

1. `tag-split` leaves the containment registry (`packages/core/containment.mjs`) with a discharge note citing this contract and its evidence. `tag-weight-difference`, `logical-restore` and `production-cutover-load` stay blocked. Merging the change is the release decision; card X20 stays open until the desktop replay and business acceptance.
2. A new company gets a `TSP` book (Tag Split, `TAG SPLIT`, 'O', `BOOK_SNAME 'TGSPL'`, `BOOK_TBL_NAME 'BAR_CAN_DATA'`… — the split writes `LBR_DATA` as its header table; the web provisioning writes `BOOK_TBL_NAME 'LBR_DATA'`), with the ledger `BOOK_DETL` slots 5 (labour), 6/8 (gold/silver DR fine), 7/9 (gold/silver CR fine) so the absorbing legs can fire.

## Vectors

Fixture (DB tests): company 01, location 01, year 2024-2025, book `TSP` (Tag Split / TGSPL / TAG SPLIT / O) with `BOOK_DETL` slots 5→LBRAC, 6/7→GLDDR/GLDCR, 8/9→SLVDR/SLVCR; employee 001; absorbing account `SPLITAC`; items `RNG` (Ring 22K, G, PR RG), `RNGH` (half ring, G, PR RH), `DIA` (Diamond, D, OTH_DETL_POSTING Y). Parent tag `SPL00001` (instance 100200000001): gross 10.000, net 10.000, touch 91.6, fine 9.160, one DIA stone.

| ID | Action | Expected |
|---|---|---|
| V1 | Split `SPL00001` (net 10) into two children RNGH 6.000 and RNGH 4.000, no absorbing account | `LBR_DATA` header (Dr/Cr 0), `LBR_ISU_DETL` 1 parent, `LBR_REC_DETL` 2 children, `BAR_DATA` 1, `BAR_DETL` 2 children each with an allocated `TAG_NO`/`VCH_SRNO`/`SRNO_MAST` row, `MAIN_STOCK` parent '-' + two child '+' (fine conserved: 9.160 out, 5.496+3.664 in), `TEMP_BOOK_DATA` 1. No `AC_DATA`, no `ROJ_MEL_DATA`. The parent is not in stock; each child is. Nothing else changes |
| V2 | Split with children net 6 + 3 (short 1.000) and no absorbing account | 400 "Please Insert diff Wt…" — nothing written, no number used |
| V3 | Split with children net 6 + 3 and absorbing account `SPLITAC`, touch 91.6 | Header `DR_WT 1.000`, `DR_FINE 0.916`; `AC_DATA` legs 03 (SPLITAC Dr gold fine 0.916) / 04 (GLDDR); `ROJ_MEL_DATA` leg 01. Children in stock, parent out |
| V4 | Edit V1: change child 2 to net 4.5, add child 3 net −0.5 removed → keep conservation | Header/number/clock/user kept; children re-allocated or kept per rule; parent still consumed once |
| V5 | Delete V1 | `DELETE_DATA` per parent line, the whole write set and `SRNO_MAST` child rows gone, parent back in stock, both children gone; database equals its pre-V1 state except `DELETE_DATA` |
| V6 | Split a sold parent; split the same parent twice on one voucher; ambiguous number without serial | 400 each; nothing written |
| V7 | Split `SPL00001`, then sell child 1, then delete the split voucher | Delete refused: a child left stock |
| V8 | Concurrent split and sale of the parent | Exactly one commits; the other 400 not-available; no partial rows |
| V9 | Parent stone DIA copied to `LBR_ISU_IDTL`; a child DIA stone posts `DM_DATA` IN | `DM_DATA` OUT for the parent DIA, IN for the child DIA (OTH_DETL_POSTING) |
| V10 | Failure injected after the first child `BAR_DETL` | Nothing written; the parent still in stock; no orphan child or `SRNO_MAST` row |

## Web adaptations (summary)

A1 ambiguous serial refused (K2.2). A2 child tag numbers allocated server-side through `nextTagNoTx`, `VCH_SRNO` = the tenant serial not the desktop minute string (K4). A3 conservation enforced within tolerance unless an absorbing account is given (K7.2). A4 no `SR_NO` gap (K9). A5 delete and edit are one transaction, with a `DELETE_DATA` audit and a child-already-moved refusal the desktop lacks (K10, K11). A6 `DATA_TYPE` 'A' when blank. A7 deadlock/serialisation → 409. A8 child image lineage via `queueTagImageTransfer` rather than the desktop's `chkSameTag`-only copy (K8.11). A9 `chkSameTag` not offered (K3). A10 the desktop's wrong-serial `SRNO_MAST` delete and its missing sold-child check are treated as desktop bugs and corrected.

## Open items (not claimed)

- The `RENDOM_TAG` / `TAG_RPT` tag-number strategies, `MsLastYearTagSires`, and the `SSRegSrNo`/`VK191NEVK` per-installation arithmetic branches.
- Print (`TagSplitBill`), the `COL_MAST` `TAG_DETL`/`TAG_IDTL` column overrides, the description/design help lists.
- `BILL_OS_DATA` and the cash/cheque/card settlement band (`MSG2_TOTAL`) — the split's money side beyond the fine/labour legs.
- The company-type-B and licence checks.
- Card X20 remains open until the desktop replay (a live Windows capture of V1/V3/V5) and business acceptance.
