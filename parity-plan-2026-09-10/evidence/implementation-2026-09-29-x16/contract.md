# Contract: X16 wholesale sale and rate cut — stock movement and money legs

Queue item X16 (doc 12) and [PARITY-EVALUATION-2026-09-28.md](../../../PARITY-EVALUATION-2026-09-28.md) found the following on real desktop vouchers 034/4-6 (Next23) and 034/1-2 (Next25):

- The web wholesale sale moves no stock. A sold tag stays in stock and can be sold again.
- A rate cut posts no money leg. The fine that is cut never becomes rupees on the party's account.
- Every ledger key uses a positional code that no desktop routine writes.

Every expected value below comes from the desktop source or from the desktop rows the evaluation captured. None is taken from web code. Where the web deliberately differs, the entry is marked **Web adaptation**.

## Sources

Paths are relative to `unified/src/csharp/DataCareNext/`. Hashes are SHA-256, first 16 hex characters.

| File | sha256/16 | Lines used |
|---|---|---|
| Ac_Ledr.cs | b58ba77dbd2c960f | 613-778 `Wh_Sales_Ledr` (legs 01-68) |
| Ac_Stock.cs | 946f9ba4f7e85835 | 146-176 `Wh_Sale_Stk` |
| TR_WH_SALE.cs | bac1e3578f9c0284 | See the list below |
| TR_BUL_SALE.cs | ca0942cc78c4081d | 9026-9100 (bullion REC row), 9107-9117 (same three posting routines), 9200 (delete audit) |
| TR_WH_SALE_RTN.cs | 53e42397cbb42492 | 4775-4800 (return tag help: `RATE_CUT_ISU` rows only; no stock balance test) |
| MS_OPNCOMP.cs | 180f295f9595dfc7 | 690, 813-816 (`TRAD_FINE`: blank means N); 979, 1132-1135 (`OLD_GOLD_TYPE`: blank means N); 664, 733-735 (`LBR_TYPE`: blank means G); 1224-1226 (`LBR_WITH_GHT`: blank means Y) |
| MDI_FORM.cs | cb91085c50d07a07 | 8038-8046 and 8110-8118 (menus), 12486-12489 (F6), 14188-14210 (`ShoF6WhSales_Click`), 16107-16121 (`ShoCtrlF6RateCut_Click`) |

TR_WH_SALE.cs lines used:

- 12004 and 12008: a new voucher takes the logged-in user and the current time.
- 12196 and 12325: a reopened voucher keeps its own time and `MAIN_USER`.
- 12956-13050: header columns.
- 13062-13141: `RATE_CUT_ISU` row.
- 13255-13320: `RATE_CUT_REC` row.
- 13349-13358: the voucher posts through `Wh_Sales_Ledr`, `Wh_Sales_Rojmel` and `Wh_Sale_Stk`.
- 13552-13594: delete.
- 14904-14914: settlement band. Column 3 is "Payment" (`PR_*`); column 4 is "Received" (`SL_*`).
- 15369-15503: `BILL_TOTAL`.
- 15633-15642: fine totals and band totals.
- 9834: line `NET_AMT` = labour + other + item amount. Column 43 (`TOT_AMT`) is never computed for a new line.

Desktop rows: `parity-plan-2026-09-10/evidence/independent-evaluation-2026-09-28/differential/`

| File | sha256/16 | Cases |
|---|---|---|
| next23-corrected-harness.json | a59371665bc43a57 | n23-wh-034-00004, -00005, -00006 |
| next25-corrected-harness.json | 6a8fb8515b3e9c3a | n25-wh-034-00001, -00002 |

## Findings

1. **No stock movement.** `Wh_Sale_Stk` inserts one `MAIN_STOCK` row per issued line (`SR_NO` 1, 'S' '-') and per received line (`SR_NO` 2, 'P' '+'). It does so for any book whose `MAIN_BOOK` is one of the five below and whose `BOOK_INOUT` is 'O'. The web writes neither. Issued tags are never reserved, and `RATE_CUT_ISU.VCH_SRNO` is always 0 where the desktop stores the tag identity (for example 100312000009).
2. **No money leg for the cut fine.** `settleMoneyMetal` is never given the header fine rate. `DR_AMT` therefore stays 0 on 034/5 (desktop 3517) and on 034/6 (desktop 32240), and legs 01/02 are never posted. The party keeps a fine balance that the voucher settled.
3. **Wrong ledger shape.**
   - Keys use the reserved 51-53 band where the desktop writes 01/02/23/29/43/44/17/18.
   - Fine legs carry `FINE_RATE` 6500 where the desktop writes 0.
   - Contra legs carry the contra as `PARTY_AC_CODE` where the desktop writes ''.
   - The web's "value" leg (party Dr item amount, IT_TYPE 'A') is not a desktop leg. The desktop leg 01 carries money and the cut fine on one row, with IT_TYPE 'G'.
4. **Misread kasar.** The observed 064 voucher in `project-memory/parity/spec-rate-cut.md` §4.1 is a **purchase-side** rate cut:
   - leg 08: party Cr 14965, '-' 2.050 at 7300;
   - legs 45/46: 15800 cash **paid** to the party;
   - legs 51/52: purchase kasar 15.

   The web read it as a sale and posted sale-side kasar as party Dr / kasar Cr. Source legs 47/48 post a positive sale-side kasar the other way: party Cr / kasar Dr.
5. **Header totals.**
   - `TOT_FINE_CR` omits `PR_FINE`: web 0.541 against desktop 24.541.
   - `SL_NET_AMT` omits `DR_AMT` whenever lines also carry value.
   - Bill outstanding is taken from the request rather than derived.
6. **Line rows.**
   - Tag lines lose `TBL_CODE`, `KR_NAME`, `PR_CODE`, `ITM_REMARK`, `ITM_SIZE`, `HM_ID` and `HM_ID_WT`.
   - Received lines write `HM_ID_WT` = gross weight (desktop 0), '' for `HM_ID2-4` (desktop NULL) and `ISU_LC_CODE` = location (desktop NULL).
   - Received lines have no `EMP_CODE` and no company `LBR_TYPE`.
7. **Wholesale return.** It requires a tag's signed `MAIN_STOCK` count to be exactly -1. A purchased tag has a '+' row, so once the sale writes its '-' row the count is 0 and the return refuses a genuinely sold tag.

## Contract

### C1. Book

1. The desktop opens `TR_WH_SALE` from two menus, each checking its own right and scoping the book help (`CurBookHelp`): "Wh Sales" (F6) on `WH SALES` books, "Rate Cut" (Ctrl+F6) on `RATE CUT` books (MDI_FORM.cs:8038-8046, 8110-8118, 14188-14210, 16107-16121). The web keeps the two scopes apart:
   - `/wholesale-sales` (right `Sales/Wholesale Sale`) accepts only `WH SALES` books;
   - `/rate-cut` (right `Cash / Bank/Rate Cut (price fixing)`) accepts only `RATE CUT` books;
   - a bullion book keeps its existing message ("use the bullion sale workflow"); a book of the other family is refused naming the right workflow; any other book is refused with a validation error.
   - **Web adaptation:** a book with no `BOOK_DATA` row keeps the existing `RATE CUT` fallback classification.
2. `VCH_TYPE` = `BOOK_SNAME`, `BOOK_NAME` = `MAIN_BOOK`. `MAIN_STOCK.DATA_TYPE` = `BOOK_DATA.DATA_TYPE`, and 'A' when blank.
3. Stock moves only when a `BOOK_DATA` row exists with `MAIN_BOOK` in {WH SALES, RATE CUT, VP PARCEL, BUL WH SALE, TOUR SALES} **and** `BOOK_INOUT` = 'O'. This is the `LEFT JOIN … WHERE` of `Wh_Sale_Stk`. An unconfigured book writes no stock and reserves no tags.

### C2. Settlement (`BILL_TOTAL`)

1. The header fine rate reaches the settlement engine (`@datacare/core` `settleMoneyMetal`, shared by the API and the screen). `FINE_RATE` = operator rate, else conversion rate, else back-calculated rate — and nothing else: the desktop never copies a line's rate there (TR_WH_SALE.cs:12975), so a voucher with a blank header rate stores 0 on the header and on legs 01/02. The earlier first-line-rate fallback is removed.
2. The settlement's own results are persisted:
   - `DR_AMT` = `round(CR_FINE × rate / F)`, banker's rounding on the double product (desktop `Math.Round`). For example 0.541 × 6500 = 3516.5000000000005, which gives 3517.
   - `CR_AMT` likewise from `DR_FINE`.
   - `CR_FINE` / `DR_FINE` are derived from an amount when only the amount was given.
   - An operator-entered value is never overwritten.

### C3. Header (TR_WH_SALE.cs:12956-13050, 15633-15642)

| Column | Rule |
|---|---|
| `SL_FINE` / `PR_FINE` | Fine of the **unpriced** lines (item amount 0) plus every line's other fine: `TotDrFine + Σ OFine` (TR_WH_SALE.cs:8344-8346, 7105-7107, 12976-12977). A priced line is sold for money on leg 01; counting its metal on leg 23 too charged the party twice. Stock rows still carry each line's own fine. |
| `TOT_FINE_DR` | `SL_FINE + DR_FINE + KSR_FINE_DR` (KSR 0) |
| `TOT_FINE_CR` | `PR_FINE + CR_FINE + KSR_FINE_CR` (KSR 0) |
| `SL_NET_AMT` = `SL_TOT_AMT` | `Math.Round(DR_AMT + Σ issued NET_AMT − SlOthAmtLess, 0)` — banker's rounding (it was half-up) |
| `PR_NET_AMT` = `PR_TOT_AMT` | `Math.Round(CR_AMT + Σ received NET_AMT − PrOthAmtLess, 0)` |
| `SL_BILL_OS` | `SL_NET_AMT − SL_CASH − SL_CHQ − SL_CARD − SL_KASAR`, formatted "0.00" |
| `PR_BILL_OS` | `PR_NET_AMT − PR_CASH − PR_CHQ − PR_CARD − PR_KASAR`, formatted "0.00" |
| `SL_*` / `PR_*` cash, cheque, card, kasar | The band cell as typed, `Strings.Format(Val, "0.00")` (`MSG2_TOTAL_LeaveCell`, :15041-15047). They were rounded to whole rupees, so 1000.50 posted 1001. |

The band arithmetic is one function, `@datacare/core` `wholesaleBand`, used by the API header and the screen.
| `SL_TAX_AMT`, `PR_TAX_AMT`, `TAX_PRC` | 0 on the wholesale/rate-cut workflow. Bullion keeps its tax figures (`Ac_Tax.Bul_Sales_GST`; legs 55/56 are deferred). |
| `VCH_TIME`, `MAIN_USER` | Voucher date + wall clock, and the acting user. An edit keeps the stored clock and user. |

### C4. Ledger (`Wh_Sales_Ledr`)

- The two-digit key tail is the desktop leg code.
- P is the party; Sn is `BOOK_DETL` slot n.
- The gold legs fire when header `IT_TYPE` = 'G'. The silver twins use S8/S9 when it is 'S'.
- TF legs fire only when `CO_SET.TRAD_FINE` = 'Y' (blank means N).

| Leg | Account (LD) | Dr / Cr | IT_TYPE, SIGN, FINE_WT | FINE_RATE | Condition |
|---|---|---|---|---|---|
| 01 / 04 | P (S1 / S8) | Dr `DR_AMT + SL_ITM_AMT` | header type, '+', `CR_FINE` | header | `DR_AMT + SL_ITM_AMT ≠ 0` |
| 02 / 05 | S1 / S8 (P) | Cr `DR_AMT + SL_ITM_AMT` | A | header | same |
| 03 / 06 (TF) | S2 / S9 (P) | — | type, '-', `CR_FINE` | 0 | `CR_FINE ≠ 0` |
| 08 / 11 | P (S2 / S9) | Cr `CR_AMT + PR_ITM_AMT` | type, '-', `DR_FINE` | header | `CR_AMT + PR_ITM_AMT ≠ 0` |
| 09 / 12 | S2 / S9 (P) | Dr `CR_AMT + PR_ITM_AMT` | A | 0 | same |
| 10 / 13 (TF) | S1 / S8 (P) | — | type, '+', `DR_FINE` | 0 | `DR_FINE ≠ 0` |
| 15 / 16 | P (S6) / S6 (P) | P Dr / S6 Cr `SL_LBR_AMT` | A | 0 | ≠ 0 |
| 17 / 18 | P (S11) / S11 (P) | P Dr / S11 Cr `SL_OTH_AMT` | A | 0 | ≠ 0 |
| 19 / 20 | P (S7) / S7 (P) | P Cr / S7 Dr `PR_LBR_AMT` | A | 0 | ≠ 0 |
| 21 / 22 | P (S11) / S11 (P) | P Cr / S11 Dr `PR_OTH_AMT` | A | 0 | ≠ 0 |
| 23 / 25 | P (S1 / S8) | — | type, '-', `SL_FINE` | 0 | `SL_FINE ≠ 0` |
| 24 / 26 (TF) | S1 / S8 (P) | — | type, '+', `SL_FINE` | 0 | same |
| 29 / 31 | P (S2 / S9) | — | type, '+', `PR_FINE` | 0 | `PR_FINE ≠ 0` |
| 30 / 32 (TF) | S2 / S9 (P) | — | type, '-', `PR_FINE` | 0 | same |
| 35 / 36 | P (bank) / bank (P) | P Cr / bank Dr `SL_CHQ_AMT` | A | 0 | ≠ 0 |
| 37 / 38 | P (bank) / bank (P) | P Dr / bank Cr `PR_CHQ_AMT` | A | 0 | ≠ 0 |
| 39 / 40 | P (card) / card (P) | P Cr / card Dr `SL_CARD_AMT` | A | 0 | ≠ 0 |
| 41 / 42 | P (card) / card (P) | P Dr / card Cr `PR_CARD_AMT` | A | 0 | ≠ 0 |
| 43 / 44 | P (S3) / S3 (P) | P Cr / S3 Dr `SL_CASH_AMT` | A | 0 | ≠ 0 |
| 45 / 46 | P (S3) / S3 (P) | P Dr / S3 Cr `PR_CASH_AMT` | A | 0 | ≠ 0 |
| 47 / 48 | P (S4) / S4 (P) | P Cr / S4 Dr `SL_KASAR_AMT` | A | 0 | > 0 |
| 49 / 50 | P (S4) / S4 (P) | P Dr / S4 Cr `ABS(SL_KASAR_AMT)` | A | 0 | < 0 |
| 51 / 52 | P (S4) / S4 (P) | P Dr / S4 Cr `PR_KASAR_AMT` | A | 0 | ≠ 0 |

- `PARTY_AC_CODE` is the party on party legs and '' on contra legs.
- A slot is required only when a leg that uses it fires. A missing slot refuses the voucher, because the desktop's `INSERT … JOIN` would silently leave it unbalanced.
- **Web adaptations:**
  - A cheque or card without an account keeps the existing fallback to S3.
  - Legs 01/02 exclude `SL_TAX_AMT` and legs 08/09 exclude `PR_TAX_AMT` until the tax legs 55/56 exist. On the wholesale workflow both are 0 (C3).

### C5. Stock rows (Ac_Stock.cs:151, 153)

One row per issued line: `SR_NO` 1, `ISR_NO` = line `SR_NO`, `TR_TYPE` 'S', `ITM_SIGN` '-'.

One row per received line: `SR_NO` 2, `TR_TYPE` 'P', `ITM_SIGN` '+', `TAG_NO` 'N', `VCH_SRNO` 0.

Common columns on both kinds of row:

- `VCH_DATE` = `STK_DATE` = voucher date.
- `VCH_TYPE` = `BOOK_SNAME`, `BOOK_NAME` = `MAIN_BOOK`.
- `AC_CODE`, `IT_CODE`, `TBL_CODE` come from the line.
- `ITM_QTY` 1, `ITM_PCS`, `ITM_GWT`.
- `ITM_NWT` = net weight. For `IT_CODE` OG/OS it is the gross weight when `OLD_GOLD_TYPE` = 'G'.
- `ITM_TOUCH`, `ITM_WEST` = wastage %, `ITM_FINE`, `ITM_RATE`, `ITM_AMT`, `LBR_RATE`, `LBR_AMT`, `OTH_AMT`, `NET_AMT`.
- `EMP_CODE`, `ENTRY_TIME` = line `VCH_TIME`, `MAIN_USER`, `DATA_TYPE`, `DESIGN_NO`, `ITM_SIZE`, `ITM_DESC` = line remark, `GHT_PRC` 0, `ITM_DISC` 0.

Columns that differ between the two:

| Column | Issued line | Received line |
|---|---|---|
| `TAG_NO` / `VCH_SRNO` | the line's tag and identity | 'N' / 0 |
| `ITM_MRP` | the line's MRP | 0 |
| `KR_NWT` / `KR_TOUCH` / `KR_WEST` / `KR_FINE` | the line's `KR_*` | the line's net weight / touch / wastage / fine |
| `KR_LBR_AMT`, `KR_OTH_AMT` | 0 | 0 |
| `KR_COST` | `TAG_COST` | 0 |
| `ITM_LOT` | the line lot | '' |

Deferred:

- `SR_NO` 7 (approval return), `SR_NO` 4 (tour), `SR_NO` 5/6 (weight difference, X21);
- `DM_DATA` / `SL_IDTL` from the tag's stones (`Dm_Wh_Tour_Sale_Detl`).

### C6. Tags

1. When stock moves (C1.3), each issued tag line reserves its exact instance inside the voucher transaction (`issueTagTx`):
   - a `TAG_STOCK` row is removed;
   - a `BAR_DETL` tag becomes unavailable through its '-' row.

   A tag that is not available, or appears twice in one voucher, is refused with 400.
2. `RATE_CUT_ISU.VCH_SRNO` = tag identity. `IT_CODE` comes from the tag, and a conflicting line item is refused.
3. The desktop fills a tag line from the tag (TR_WH_SALE.cs:10641-10736). When the caller leaves them blank, these come from the tag: weights, pieces, ghat %, touch, wastage, the stored fine `ITM_FINE` (kept while weight and purity are unchanged, :10697), `TBL_CODE`, `DESIGN_NO`, `ITM_SIZE`, `HM_ID`, `HM_ID_WT`, `KR_NAME`, `PR_CODE`, `LBR_TYPE` (blank included), `LBR_RATE`, `LBR_AMT`, `OTH_AMT`, `ITM_RATE`, `RATE_TYPE`, `ITM_MRP` and `KR_COST` → `TAG_COST` (col 58). `ITM_REMARK` comes from `ITEM_MAST.IT_NAME`. An API caller can therefore sell a tag by number alone, as the operator does.
4. **Edit** releases the voucher's tags before the rewrite and reserves the new set:
   - `TAG_STOCK`-only tags are re-inserted, as `releaseSaleReferencesTx` does;
   - `BAR_DETL` tags are freed when the '-' row is deleted.
5. **Delete** releases in the same way.

### C7. Line rows

**Issued lines (wholesale workflow):**

- `TOT_AMT` 0 (column 43 is never computed);
- `FINE_CUT_PCS` 0;
- `EMP_CODE`, `VCH_TIME` and `MAIN_USER` from the header;
- tag values as in C6.

**Received lines (wholesale workflow):**

- `LBR_TYPE` = line value or company `CO_SET.LBR_TYPE`, and the labour is computed on it (C13);
- `ITM_REMARK` = item name;
- `HM_ID_WT` 0;
- `HM_ID2-4` NULL;
- `ISU_LC_CODE` NULL unless given;
- `TAG_NWT` 0 unless given;
- `OLD_VCH_SRNO` 0;
- `APR_ISU` and `EMP_ISU` 'N';
- `FINE_CUT_PCS` 0;
- `EMP_CODE`, `VCH_TIME`, `MAIN_USER`.

Bullion received lines keep the `TR_BUL_SALE` shape: `ISU_*`, `MCX_RATE` and `LESS_WT` from the grid. `HM_ID_WT` is 0 on both.

### C8. Delete audit (TR_WH_SALE.cs:13569, TR_BUL_SALE.cs:9200)

The delete writes one `DELETE_DATA` row with `SR_NO` 0:

| Column | Value |
|---|---|
| `VCH_DATE`, `VCH_TIME` | from the header |
| `DELETE_DATE`, `DELETE_TIME` | now |
| `VCH_TYPE` | `BOOK_SNAME` |
| `BOOK_NAME` | first 20 characters of `BOOK_DATA.BOOK_NAME` |
| `AC_CODE`, `AC_NAME` | from the header |
| `VCH_VAL_DR` | `SL_NET_AMT` |
| `VCH_VAL_CR` | `PR_NET_AMT` |
| `FINE_TYPE` | `IT_TYPE` |
| `VCH_FINE_DR` | `TOT_FINE_DR` |
| `VCH_FINE_CR` | `TOT_FINE_CR` |
| `HD_VCH_NO` | from the header |
| `MAIN_USER` | the header's `MAIN_USER` |
| `DELETE_USER` | the acting user |
| `VCH_DESC` | first 150 characters |

An edit writes no audit row.

### C9. Wholesale sale return

A tag is "currently sold" when its latest `MAIN_STOCK` movement is the '-' row of the source wholesale voucher. An edited return is valid when its latest movement is the return's own '+' row. This replaces the signed-count test, which only held for tags with no purchase row.

### C10. Provisioning

A new company gets two books:

- `WHS` (Wholesale Sale, `WH SALES`, 'O');
- `RTC` (Rate Cut, `RATE CUT`, 'O').

Both have `BOOK_DETL` slots 1-12 in the desktop layout (TR_WH_SALE legs):

| Slot | Account |
|---|---|
| 1 | SALES |
| 2 | PURCHASE |
| 3 | CASH |
| 4 | KASAR |
| 5 | KASAR |
| 6 | LBRINC |
| 7 | LBREXP |
| 8 | SLVSALE |
| 9 | SLVPURC |
| 10 | INTINC |
| 11 | OTHCHRG |
| 12 | FINEKSR |

Each named account is created.

### C11. Screens

`/txn/wholesale-sale` and `/txn/rate-cut` mount one form (`components/WholesaleVoucherForm.tsx`, model in `lib/wholesaleVoucher.ts`), as TR_WH_SALE serves both books. F6 opens the first and Ctrl+F6 the second (Ctrl+F6 used to open the wholesale page, which does not list RATE CUT books).

- **Header:** book filtered by `MAIN_BOOK` (no hard-coded book; the Rate Cut page no longer defaults to the Receipt book `RCT`), voucher number with Load, date, Bill No, Item Type Gold/Silver, party picker (fills name and mobile, C15), address 1-3, city, employee picker, Vch Desc.
- **Issue grid (`MSG`)** in the desktop column order: TagNo (availability picker, C14; a typed number resolves on leaving the cell when it names exactly one tag), ItCode (read-only on a tag line), Pcs, GrWt, OthWt, NetWt, Touch, West%, Fine, ItRate, Per, ItAmt, LType, LbrRate, LbrAmt, OthAmt, NetAmt; the full grid adds ItName, lots, Counter, Design, Size, HuId, KrName, PrCode, Ght%, GhtWt, LessWt, HmFine, ConRate, Con%, ORate, OFine, Mrp, TagCost, Tax%, SlvrFine, TagGwt/TagNwt, McxRate, AdjWt and the order/issue reference.
- **Receive grid (`MSG_PR`):** no tags; GhtWt is a typed weight; LTouch; the same money columns.
- **Cascades as on the desktop:** gross or other weight recomputes net; a ghat % and a ghat weight replace each other; a conversion replaces the typed rate; a labour rate replaces the typed labour amount; an other rate turns other charges into fine; retyping a picked tag starts the line afresh; a spare row always follows the last typed one.
- **Rate-cut band** laid out as the desktop's two columns beside the settlement band: Tot Fine Cr / Dr, Ac Amt Dr ↔ Ac Fine Cr, Ac Amt Cr ↔ Ac Fine Dr, Conv % / Convrt Rate, Os Fine, and the fine rate captioned by `RATE_PAR` ("1gm Rate", "10gm Rate", "Kg Rate"). A blank field shows the value BILL_TOTAL derives for it.
- **Settlement band (`MSG2_TOTAL`)** with the desktop's labels: column "Payment" is `PR_*` (API `receivedPay`), column "Received" is `SL_*` (API `pay`) — the old Rate Cut page had them the other way round. Rows Net / Cheque (bank a/c + cheque no) / Card (card a/c) / Cash / Kasar / Os, and "Diff Amount … Pay | Rec" (`lblDiffAmt`). One bank and one card account per voucher (`BANK_AC`, `CHQ_NO`, `CARD_AC`).
- **Every computed cell is the posting arithmetic:** the preview runs `@datacare/core` (`wholesaleIssueLine`, `wholesaleReceiveLine`, `wholesaleGridTotals`, `settleMoneyMetal`, `wholesaleBand`) on the exact payload the form sends, with `RATE_PAR`, `LBR_TYPE` and `LBR_WITH_GHT` from `/settings`.
- **Payload rules:** a loose row omits blank cells; a row from a tag or a saved voucher sends blank numbers as 0, so the server cannot fill a different tag value back in; the stored fine is sent only while weight and purity are as they came; the labour basis is omitted while it is the company's.
- **Lifecycle:** Save posts, then reloads the stored voucher so every figure on screen is the saved one; Update (PUT) and Delete (with confirmation) on a loaded voucher; New clears.

### C12. Line arithmetic (TR_WH_SALE grid, `@datacare/core` `wholesaleLine.ts`)

Used by the wholesale and rate-cut workflows and by the screen. The bullion workflow keeps the older rule until TR_BUL_SALE's grid is derived.

| Result | Issue grid (`CommPassTotal`, :9160-9860) | Receive grid (`CommPassTotal_Pr`, :6857-7040) |
|---|---|---|
| Net | explicit net, else gross − other ("0.000") | same |
| Ghat | explicit ghat weight, else net × Ght% / 100 | typed ghat weight (col 11) |
| Fine | stored fine while no hallmark fine; touch + wastage 0 → net + ghat − less wt + hm fine; weightless with purity → 0 unless hm fine; else (net + ghat) × (touch + wastage) / 100 − less wt + hm fine | stored fine; touch + wastage 0 → net + ghat; weightless → 0; else (net + ghat) × (touch + wastage − less touch) / 100 |
| Rate | `Math.Round(ConRate / Con% × 100, 2)`, else ConRate, else the typed rate | same |
| Item amount | by rate type: P pcs × rate, 1 fine × (rate / 10), K fine × (rate / 1000), else fine × rate; `Math.Round(…, 0)` | same |
| Labour | with a rate, by basis: P pcs, N net + ghat (net alone when `LBR_WITH_GHT` = N), K gross / 1000 when `LBR_TYPE` = G else (net + ghat) / 1000, else gross; `Math.Round(…, 0)`; without a rate the typed amount | same |
| Other fine | `Math.Round(OthAmt [× 10 | × 1000] / ORate, 3)` by rate type; that amount leaves the money totals | same |
| Net amount | labour + other + item amount (no MRP override, no tax) | total, with a tax % backed out: `Math.Round(total / (tax + 100) × 100)` |
| `TOT_AMT` | 0 (col 43 is never computed) | the total |

Money is `Math.Round` (half-to-even); weights and fine are `Strings.Format` (half-up), in the desktop's operand order.

### C13. Labour basis of a new row

A new grid row starts on the company's labour basis — `CommPassAdd` col 34 and `CommPassAdd_Pr` col 23 = `MsLbrType` (:8362, :6324; blank means G) — and its labour is **computed** on that basis. The web wrote the basis on the row but computed the labour gross-wise. A tag's own basis (blank included) wins.

### C14. Tag picker (`/lookup/available-tags`)

Offers only tags that can be issued now: `BAR_DETL` instances with a positive signed stock balance (the desktop help's `HAVING SUM(…) > 0`, :10601), plus tags that exist only in `TAG_STOCK`, for the session's company and location. One row per instance (`TAG_NO`, `VCH_SRNO`, `IT_CODE`) with the figures of C6.3. When two live instances share a number, each is labelled with its serial and the pick sends it; without the serial the save refuses to guess.

### C15. Party

Choosing the party fills its name and mobile from `AC_MAST` (:14621-14623); an API call that omits them gets the same defaults. Address lines and city are typed.

## Vectors

Values from the evaluation's desktop rows, keyed as the desktop keys them.

| ID | Voucher | Input | Expected |
|---|---|---|---|
| V1 | Next23 034/4 | Party 000209. Tags LRG00001 (VCH_SRNO 100312000009, 12.300 g, touch 92, wastage 5) and LRG00002 (100312000010, 13.000 g) | See V1 below |
| V2 | Next23 034/5 | Received 999 GOLD, 24.000 fine. Rate 6500, cut 0.541, cash 3517 | See V2 below |
| V3 | Next23 034/6 | Tags CHG00002 (100312000004, 12.000 g, touch 92, wastage 4, size 3, HM UY76UY / 12.000, SJ) and CHG00003 (100312000005, 14.000 g, KJ). Received 20.000. Rate 6500, cut 4.960 | See V3 below |
| V4 | Next25 034/1 | Party 000202. Tag GRG00001 (100512000001, GR18K, other amount 500) | See V4 below |
| V5 | Next25 034/2 | Received 5.000. Rate 14000, cut 5.793, cash 81602 | See V5 below |
| V6 | Live24 064/00004 (`project-memory/parity/spec-rate-cut.md` §4.1) | Header-only purchase-side cut: rate 7300, Dr fine 2.050, cash paid 15800, purchase kasar 15 | See V6 below |

**V1 expected:**

- ISU fine 11.931 / 12.610. `TBL_CODE` 001, `PR_CODE` LR, `KR_NAME` KJ / AB, `ITM_REMARK` 'L RING 916'.
- Header `SL_FINE` 24.541, `TOT_FINE_DR` 24.541, `TOT_FINE_CR` 0, `DR_AMT` 0.
- `AC_DATA` has one row: `…0000423`, 000209, LD 00003, G, '-', 24.541, `FINE_RATE` 0.
- `MAIN_STOCK` has two rows: `SR_NO` 1, 'S' '-', LR916, tag and identity, TBL 001, fine 11.931 / 12.610.

**V2 expected:**

- Header `DR_AMT` 3517, `CR_FINE` 0.541, `FINE_RATE` 6500, `PR_FINE` 24, `TOT_FINE_CR` 24.541, `SL_NET_AMT` 3517, `SL_BILL_OS` 0.
- `AC_DATA` has five legs:

  | Leg | Account (LD) | Amount | Metal | Other |
  |---|---|---|---|---|
  | 01 | 000209 (00003) | Dr 3517 | G '+' 0.541 | rate 6500 |
  | 02 | 00003 (000209) | Cr 3517 | — | rate 6500; party '' |
  | 29 | 000209 (00008) | — | G '+' 24.000 | rate 0 |
  | 43 | 000209 (00001) | Cr 3517 | — | — |
  | 44 | 00001 (000209) | Dr 3517 | — | party '' |

- `MAIN_STOCK` has one row: `SR_NO` 2, 'P' '+', 999, 'N', 0.
- REC row: `LBR_TYPE` G (company), `ITM_REMARK` '999 GOLD', `HM_ID_WT` 0, `ISU_LC_CODE` NULL, `EMP_CODE` 001.

**V3 expected:**

- Fine 11.520 + 13.440 = 24.960. `DR_AMT` 32240. `TOT_FINE_DR` 24.960, `TOT_FINE_CR` 24.960.
- `AC_DATA` has four legs:
  - 01: Dr 32240, '+' 4.960, rate 6500;
  - 02: 00003 Cr 32240;
  - 23: '-' 24.960;
  - 29: '+' 20.000.
- `MAIN_STOCK`: CH916 '-' ×2 and 999 '+'.
- ISU CHG00002 carries `ITM_SIZE` 3, `HM_ID` UY76UY and `HM_ID_WT` 12.000.

**V4 expected:**

- ISU `NET_AMT` 500, `TOT_AMT` 0, `FINE_CUT_PCS` 0, `TBL_CODE` 001, `KR_NAME` YT, `PR_CODE` GR, `LBR_TYPE` N (tag), `ITM_REMARK` 'GENTS RING 18K'.
- `SL_OTH_AMT` 500, `SL_NET_AMT` 500.
- `AC_DATA`:
  - 17: 000202 Dr 500 (LD 00077);
  - 18: 00077 Cr 500 (party '');
  - 23: '-' fine.
- `MAIN_STOCK`: GR18K '-'.

**V5 expected:**

- `DR_AMT` 81102, `TOT_FINE_CR` 10.793.
- `AC_DATA`: 01 (Dr 81102, '+' 5.793, rate 14000), 02, 29 ('+' 5.000), 43 (Cr 81602), 44 (Dr 81602).
- `MAIN_STOCK`: 999 '+'.
- REC `LBR_TYPE` N (company), `TAG_NWT` 0, `APR_ISU` 'N', `EMP_ISU` 'N', `OLD_VCH_SRNO` 0.

**V6 expected** (the six real legs):

- 08: party Cr 14965, G '-' 2.050, rate 7300, LD S2 00008.
- 09: S2 Dr 14965, rate 0.
- 45: party Dr 15800. 46: S3 00001 Cr 15800.
- 51: party Dr 15. 52: S4 00057 Cr 15.
- ΣDr = ΣCr = 30780.

The web previously read this voucher as a sale, with party Dr value and party Dr kasar.

Web-specific vectors (derived from the rules above, not from desktop rows):

| ID | Setup | Expected |
|---|---|---|
| W1 | V1, then sell LRG00001 again in a second voucher | 400 "tag not available"; nothing written |
| W2 | V1, then delete | Both tags available again (the `BAR_DETL` signed count is back to 1). `DELETE_DATA` row as in C8: `VCH_VAL_DR` 0, `VCH_FINE_DR` 24.541 |
| W3 | V1, then edit to LRG00002 only | LRG00001 available; LRG00002 still sold; one '-' row |
| W4 | Silver voucher (`IT_TYPE` 'S'), a 1000 g loose line valued 80000, cash 80000 | Legs 04 (P Dr 80000, LD S8), 05 (S8 Cr), 25 (P '-' fine, LD S8), 43/44 |
| W5 | `TRAD_FINE` 'Y' on V3 | Adds 03 (S2 '-' 4.960), 24 (S1 '+' 24.960) and 30 (S2 '-' 20.000). Money unchanged |
| W6 | Sale kasar +15 / −15; purchase kasar 5 | 47/48 (P Cr 15 / S4 Dr 15); 49/50 (P Dr 15 / S4 Cr 15); 51/52 (P Dr 5 / S4 Cr 5) |
| W8 | Wholesale return of a V1 tag (purchase '+' row present) | Accepted. A second return of the same tag is refused |
| W9 | A voucher in the Receipt book `RCT` through `/rate-cut`; a WH SALES book through `/rate-cut`; a RATE CUT book through `/wholesale-sales` | 400 each; each resource accepts only its own `MAIN_BOOK` |
| W10 | Tag MKG00001 (stored fine 9.500, labour N 150, other 300, MRP 25000, cost 18000) and a loose 10 g × 91.6 % at 6000 | Fine 9.500 kept; labour `Math.Round(10 × 150)` 1500; net 1800; loose line 54960; `SL_FINE` 9.500 (the priced line is not counted); `SL_NET_AMT` 56760; mobile 9856525 from the party |
| W11 | Company `LBR_TYPE` N: loose issued 10.5 − 0.5 g at labour 100; received 5 − 1 g with typed ghat 0.800 at labour 50; then reopen and edit unchanged | Labour 1000 and 240 (gross-wise would be 1050 and 250); `ITM_GHT_WT` 0.800 and fine 4.800 survive the round trip |
| W12 | Cash 1000.50 and kasar 0.25 on a 54960 sale | `SL_CASH_AMT` 1000.5, `SL_KASAR_AMT` 0.25, `SL_BILL_OS` 53959.25; legs 43/44 1000.50 and 47/48 0.25 |
| W13 | Two live instances of LRG00002 | Both listed with their serial; a save without the serial is refused; with it, exactly that instance moves |
| W14 | A priced line and no header rate | `FINE_RATE` 0 on the header and on legs 01/02 |

## Open items

These go to the next X16 slices and are not claimed here:

- `Wh_Sales_Rojmel` alignment: type 03 should carry `CR_FINE`, `AC_NAME` should be `BOOK_SNAME + ' - ' + AC_NAME`, and rows 05/06/14/27 are missing.
- `SL_IDTL` / `DM_DATA` from tag stones.
- Legs 07/14, 27/28, 33/34, 53/54, 55/56, 57-68.
- `MAIN_STOCK` `SR_NO` 4/5/6/7.
- `BAR_DETL` `APR_ISU` / `APP_TRFR` and `SL_ORD_DETL` / `APR_DETL` flag resets (X17).
- Negative-stock refusal for loose wholesale lines.
- `TEMP_BOOK_DATA` hidden voucher number (`HD_VCH_NO`).
- Grid columns not modelled: FixWst% (col 22) and the header wastage override `nWestPrc`, the "All" item type's MRP pricing, PsWt × pieces gross and bag weight (`BagTot`, col 13, comes off the net), Lbr% (`LBR_PRC`).
- Band items not modelled: fine kasar (`KSR_FINE_DR/CR`), the Order Amt row (`SL_ADV_AMT`), silver amounts (`SLV_*`), credit/interest days (`CR_DAYS`, `INT_*`), and the party's opening / closing balance (`LOpAmt`, `LClAmt`).
- TR_BUL_SALE's own grid arithmetic (McxRate, Premium, AdjWt); the bullion workflow keeps the older line rule.
- Every card remains open until the desktop is replayed and the business accepts it.
