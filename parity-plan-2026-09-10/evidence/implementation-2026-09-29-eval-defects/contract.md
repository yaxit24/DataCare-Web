# Contract: running-app defects from the 28 September evaluation

This contract covers defects D1–D6 and the 500-on-bad-input probes. They were found by running the application in [PARITY-EVALUATION-2026-09-28.md](../../../PARITY-EVALUATION-2026-09-28.md) §4b, §5a, §5b and §5c.

Every expected value below was derived from the desktop source before the web code was changed. Where the web deliberately differs, the entry is marked **Web adaptation**.

## Sources

Paths are relative to `unified/src/csharp/DataCareNext/`. Hashes are SHA-256, first 16 hex characters.

| File | sha256/16 | Lines used |
|---|---|---|
| MDI_FORM.cs | cb91085c50d07a07 | 8052-8099 (cash/bank menus), 8100-8111 (Contra Entry), 8456-8467 (Card Rec), 8628-8639 (Order Cancel) |
| DC_Main.cs | 7ff3543a78440db0 | 1489-1559 `CurBookHelp` |
| TR_CASH.cs | 1f70eeb3afdd2436 | 2569-2650 (book decides layout), 2674-2698 (numbering), 3043 (KASAR_AMT) |
| Ac_Ledr.cs | b58ba77dbd2c960f | 567-581 (CASH REC/PAY legs 01-08, slot 1 and slot 2); BANK REC/PAY equivalents |
| MS_OPNCOMP.cs | 180f295f9595dfc7 | 686 (load), 881-888 (blank SL→N, PR→F) |
| Ac_Image.cs | fa653d152ad95f8a | 6221 `UPDATE CO_SET SET SL_AMT_TYPE='N' WHERE … IS NULL`; 7101 same for PR_AMT_TYPE='F' |
| UT_SETTING_MAIN.cs | 76116b14149afc1c | 8486-8489, 8526-8545 (blank shows "Net Wise") |
| TR_SALE.cs | b122837a890d99c3 | 9161 (new row col 21 = MsSlAmtType), 10716-10936 (`CommPassTotal` item amount), 12833 (col 58 = ITEM_MAST.RATE_TYPE), 15432/15446 (save RATE_WITH/RATE_TYPE) |
| MS_ITEM.cs | eff38e440fc81375 | 2731-2734, 3243 (RATE_TYPE G/1/K/P) |
| TR_SALE_RTN.cs | cdee9c3777252272 | 4915-4917, 6813-6821 (return grids use their own basis rules) |
| TR_SL_ORD_ADJ.cs | 450fb8a06d12db4a | 2523 (orders open for adjustment) |

## D1: Cash, Bank and Card receipts and payments cannot be saved

### Desktop behaviour

- Each menu fixes the book **before** the form opens (MDI_FORM.cs:8052-8099):
  - Cash Received → `CurBookHelp("CASH REC")`
  - Cash Payment → `"CASH PAY"`
  - Bank Received → `"BANK REC"`
  - Bank Payment → `"BANK PAY"`
  - Contra Entry → `"CONTRA"` (8100-8111)
- `CurBookHelp` lists active `BOOK_DATA` rows of that `MAIN_BOOK` for the company and location (DC_Main.cs:1489-1559):
  - exactly one row: that book is used;
  - several rows: the operator picks one;
  - none: "Please Creat Book From …", and the form does not open.
- The book's `MAIN_BOOK` decides whether TR_CASH uses the cash or the bank layout (TR_CASH.cs:2629-2650). Voucher numbers are per book (2674-2698).
- Kasar (write-off) posts legs 03/04 (receipt) and 07/08 (payment) against the book's **BOOK_DETL slot 2** (Ac_Ledr.cs:571-581, `B.SR_NO = 2 AND A.KASAR_AMT <> 0`). The cash or bank legs use slot 1.

### Web defect

- `PaymentForm` sends no `coBook`, so every save returns 400.
- The print link hard-codes RCT/PAY.
- The server never reads slot 2 for kasar, and the form cannot send `kasarAc`, so any non-zero kasar returns 400.
- The Contra page has the same missing book.

### Contract

1. **Book selection.** The receipt and payment forms show a configured-book selector, filtered by the chosen mode:

   | Form | Mode | Accepted `MAIN_BOOK` |
   |---|---|---|
   | Receipt | cash | `CASH REC`, `RECEIPT` |
   | Receipt | bank, cheque, card, upi | `BANK REC`, `RECEIPT` |
   | Payment | cash | `CASH PAY`, `PAYMENT` |
   | Payment | other modes | `BANK PAY`, `PAYMENT` |

   - `RECEIPT` and `PAYMENT` are the books that web provisioning creates (`seedCompany`).
   - A single matching book is chosen automatically, as `CurBookHelp` does.
   - `?mode=BANK` (Ctrl+F8/F9) opens in bank mode.
   - Save stays disabled until a book is chosen.
2. **The book reaches every request.** It is sent with single and multi-line saves and with the print link.
3. **Server-side family check (Web adaptation, hardening).** Receipt and payment writers reject a book whose `MAIN_BOOK` is outside the family above. They also reject a cash-mode save into a bank book, or the reverse. The error is a 400 validation error.
   - The desktop cannot reach these states, because the menu filters books by `MAIN_BOOK`.
4. **Kasar account.** When no explicit `kasarAc` is sent, the kasar account is BOOK_DETL slot 2 of the book, as in Ac_Ledr.cs:571-581.
   - **Web adaptation:** refuse when slot 2 names the same account as the slot-1 settlement account. Older web-provisioned books have `CASH` in both slots, and posting a write-off to cash would overstate cash on hand.
   - Web provisioning now gives RCT and PAY books slot 2 = `KASAR`.
5. **Contra.** The Contra page selects a `CONTRA` book and sends it.
   - Found while testing: `Cash / Bank/Contra` had no rights alias. A user holding the desktop right `Contra Entry` (MENU_DATA SM_NAME; MDI_FORM.cs:8100) was refused with 403. The alias `Contra Entry` is added.

### Vectors

| ID | Setup | Action | Expected |
|---|---|---|---|
| D1-1 | Web-provisioned company (RCT = RECEIPT, slot 1 CASH) | Receipt, cash, party CUST01, 1000, through the browser | 201, voucher 00001. `CASH_DATA` has CO_BOOK=RCT and REC_AMT=1000. `AC_DATA` has 2 legs: CUST01 Cr 1000 and CASH Dr 1000. |
| D1-2 | Same | Payment, cash, 750 | 201. `PAY_DATA` has CO_BOOK=PAY and NET_AMT=750. `AC_DATA`: party Dr 750, CASH Cr 750. |
| D1-3 | CASH REC book, slot 1 = 00001, slot 2 = 00057 | Receipt 60000, kasar 771, no kasarAc | 4 legs (01/02 = 60000; 03/04 = 771, with the kasar leg on 00057). `CASH_DATA.KASAR_AMT` = 771. |
| D1-4 | CASH PAY book, slot 2 = 00042 | Payment 5000, kasar 160, no kasarAc | Legs 05/06 = 5000; legs 07/08 = 160, with the kasar account 00042. |
| D1-5 | Book with MAIN_BOOK = SALES | Receipt | 400, and no rows written |
| D1-6 | BANK REC book | Receipt with mode = cash | 400, and no rows written |
| D1-7 | Slot 2 = slot 1 = CASH | Receipt with kasar 10 | 400 that names slot 2, and no rows written |

## D6: sale amount basis for a blank SL_AMT_TYPE

### Desktop behaviour

- A blank `SL_AMT_TYPE` is `N` in all three places it can be seen:
  - in memory (MS_OPNCOMP.cs:881-884);
  - in the database (Ac_Image.cs:6221 backfills NULL to `N`);
  - in the settings screen (UT_SETTING_MAIN.cs:8545 shows it as "Net Wise").
- A blank `PR_AMT_TYPE` is `F` (MS_OPNCOMP.cs:885-888; Ac_Image.cs:7101).

Each TR_SALE line carries its own `RtWith` (grid column 21, saved to `SL_DETL.RATE_WITH`). A new line copies it from the company setting (9161). Column 58 is `RATE_TYPE`, copied from `ITEM_MAST.RATE_TYPE`, whose values are G, 1, K and P (12833; MS_ITEM.cs:2731-2734).

The item amount calculation in `CommPassTotal`, TR_SALE.cs:10716-10936:

| RATE_TYPE | RtWith | Item amount |
|---|---|---|
| P | any | pcs × rate |
| 1 | F | (fine + ghat) × rate / 10 |
| 1 | G | (gross + ghat) × rate / 10 |
| 1 | other | (net + ghat) × rate / 10 |
| K | F / G / other | as for `1`, but ÷ 1000 |
| blank or G | F | fine × rate. Fine is (net + ghat) × (touch + wastage) / 100, or net + ghat when touch + wastage is 0. |
| blank or G | P | pcs × rate |
| blank or G | G | (gross + ghat) × rate |
| blank or G | N, blank or anything else | (net + ghat) × rate |

### Contract

1. The settings loader maps a blank `SL_AMT_TYPE` to `N` and a blank `PR_AMT_TYPE` to `F`. The purchase result is unchanged, because blank already priced fine.
2. The retail sale writer (sale, quotation and edit) prices each line by its effective RtWith and RATE_TYPE, using the table above:
   - effective RtWith = the line's own value if non-blank, otherwise the company value;
   - an explicit `metalAmount` still wins.
3. `SL_DETL.RATE_WITH` stores the effective RtWith, so a new line stores `N` as the desktop does.
   - **Web adaptation:** a reopened line whose stored value is blank is re-saved with the company value. The desktop keeps the blank, but the price is the same.
4. The browser preview uses the same core function, fed with the company's `SL_AMT_TYPE`. Before this change it treated blank as net without ghat, and ignored G, P, ghat and RATE_TYPE.
5. Web provisioning writes `SL_AMT_TYPE='N'` and `PR_AMT_TYPE='F'`, matching the desktop backfills.
6. **Out of scope** (recorded as remaining work):
   - The legacy Sale Return writer (`salesReturn.ts`) passes no amount type. It keeps its current fine basis. TR_SALE_RTN uses its own grid rules (4915-4917, 6813-6821), which belong to X13.
   - Desktop path-dependent recalculation is not reproduced: a visible, unchanged `G` cell reverts to net on later passes (10772-10798). The web computes from the final line.

### Vectors

All vectors are one line with ghat 0 unless a ghat value is shown.

| ID | Company | Line | Expected ITM_AMT |
|---|---|---|---|
| D6-1 | blank | 1 pc, gross 10, net 10, touch 91.6, rate 6000 | 60,000 (previously 54,960) |
| D6-2 | blank / F / G / N / P | pcs 1, gross 12, net 10, touch 91.6, rate 1000 | 10,000 / 9,160 / 12,000 / 10,000 / **1,000** |
| D6-3 | N, with line RtWith F / G / P | same line, pcs 2 | 9,160 / 12,000 / 2,000 |
| D6-4 | N / F / G | gross 12, net 10, ghat 0.5, touch 91.6, rate 1000 | 10,500 / 9,618 / 12,500 |
| D6-5 | N, RATE_TYPE K | net 250, rate 70,000 per kg | 17,500 |
| D6-6 | N, RATE_TYPE 1 | net 10, rate 60,000 per 10 g | 60,000 |
| D6-7 | N, RATE_TYPE 1, line RtWith F | net 10, ghat 0.5, touch 91.6, rate 60,000 | (9.618 + 0.5) × 6000 = 60,708 |
| D6-8 | N, RATE_TYPE P, line RtWith F | pcs 3, net 10, touch 91.6, rate 500 | 1,500 |
| D6-9 | blank PR_AMT_TYPE | purchase net 10, touch 91.6, rate 1000 | 9,160 (unchanged) |

## D2–D5: report screens and Order Cancel

| ID | Defect | Contract | Expected |
|---|---|---|---|
| D2 | The report page strips digits from the slug, so `gstr2` → `/reports/gstr` and `gstr3b` → `/reports/gstrb` | The slug sanitiser keeps `a-z`, `0-9` and `-` | Both screens request their real routes and get 200 |
| D3 | HUID, Item Stock Level, Bill Wise Profit, Physical Stock Verify and Stock Movement are registered only in `REPORT_BUILDERS` | Add literal `GET /reports/<slug>` routes that call the same builders as the export. Their route policies already exist. | 200 on screen, and the screen rows equal the export rows |
| D4 | `balance-sheet` and `gstr1` are missing from `REPORT_FORM_BY_SLUG`, so filters and exports return 403 `form: unresolved` | Map them to `Reports/Balance Sheet` and `Reports/GSTR-1` and register their builders for export. Add a `GET /reports/gstr1` alias for the fixed GSTR-1 screen, so the generic slug has a fixed route on the same form. | filters → 404 `unknown-report` (benign); XLSX → 200 |
| D5 | Order Cancel loads `/sales-orders` with no scope, so 400; Void sends no scope or version | Select a `SALES ORDER` book, then send the scope on list, void and refund. Void first reads the saved order's version. | List 200; Void and Refund reach their writers |

The desktop Order Cancel (TR_SL_ORD_ADJ.cs:2523) lists every order with an open advance for the company and location. The web still lists one order book at a time; this is recorded as remaining work.

## 500 on bad input (§5c)

| Probe | Contract |
|---|---|
| `createSale` or `POST /sales` with an unknown `labourType` | 400 `SaleValidationError` naming the value. Previously a `TypeError` in `labourCharge`. |
| `POST /sales-returns` with an incomplete line | 400 naming the missing numeric field. Previously a `DecimalError`. |

## Found while implementing

These were fixed in the same change, because they sat on the same paths:

| Finding | Fix |
|---|---|
| `GET /settings` keys values by descriptor id (`CO_SET.SL_AMT_TYPE`). The web UI asked for bare column names, so `LBR_WITH_GHT`, `SL_NWT_LOCK` and `ITM_FINE_LOCK` always took their blank defaults on screen. | `companySetting()` resolves a bare column through its `CO_SET` / `CO_SET_NEW` id, and `companyFlag` uses it. |
| The Sales page listed every active book. Only `SALES` books can be saved (desktop `CurBookHelp("SALES")`, MDI_FORM.cs:7918-7919). | `mainBooks={['SALES']}`. |
| The receipt/payment form had no voucher date and saved today's date. TR_CASH saves the operator's date (`mVchDate`, TR_CASH.cs:3021). | Date field. The single-voucher routes now forward `vchDate`. |
| `Cash / Bank/Contra` had no rights alias. A user holding the desktop right `Contra Entry` got 403. | Alias `Contra Entry`. |
| Refused saves showed only `invalid-data`. | The form shows the server `detail`. |
| The demo seed's item group had no `PURC_AC`, so the first purchase failed (evaluation §5b). | Demo `GROUP_MAST` gets `PURC_AC='PURCHASE'`. |

These remain open, with owners:

| Finding | Owner |
|---|---|
| Web provisioning writes TAX_MAST parents at `SR_NO 1`. A sale that names a tax code pins `SR_NO 0` and gets "tax code is not configured". A rate-only lookup still works. | X10 provisioning |
| Ghat %: the preview derives ghat weight from gross × % (desktop: net × %, TR_SALE.cs:10581), and the server ignores `ghtPct` without `ghtWt`. | X13 / X07 |
| The legacy Sale Return writer keeps the fine basis (see D6 item 6). | X13 |
| Order Cancel lists one order book at a time. TR_SL_ORD_ADJ.cs:2523 lists every order with an open advance. | X14 |
| Receipts and payments do not reject a date outside the fiscal year. `assertFiscalDateTx` exists and is used by other writers. | X05 |
| `/reports/account-ledger/filters` and `/export.*` are captured by `/reports/account-ledger/:acCode`. | X26 |

## Status and evidence

- **State:** implemented; engineering evidence only.
- **Not yet done:** independent desktop replay of the vectors, and business acceptance of the web adaptations (D1 items 3 and 4, D6 item 3).
- **Tests:**
  - Core: `packages/core/test/saleAmount.test.ts` (22).
  - API: `financeBookFamily.db.test.ts`, `financeBookSelection.routes.db.test.ts`, `saleAmountBasis.routes.db.test.ts` and `reportScreens.routes.db.test.ts`, plus updated pins in `sales.lifecycle`, `settingsBehavior`, `provisioning`, `routePolicy`, `reportAuthorization` and `releaseCertification`.
  - Web: `financeBooks.test.ts`, `reportSlug.test.ts` and `lineRecalc.test.ts`.
- **Real browser:** journeys `cash-receipt-payment` and `sale-amount-basis`. The full real-stack run passed 21/21 with zero mocked requests ([real-stack-result.json](real-stack-result.json)).
- **Deliberate failures:** 15 source mutations, one per changed path, were each caught by its focused test and then restored ([mutation-checks.json](mutation-checks.json), [mutation-check.py](mutation-check.py)).
