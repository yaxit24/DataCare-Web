# Desktop module guide — the 13 ribbon tabs

One section per tab: what it is for, the screens operators use, a typical workflow, the tables it writes, its main
outputs and how it connects to other tabs. Workflows marked *tutorial* follow the official videos; the others are
derived from the source. Each tab links to its menus in the [menu catalog](../menu-catalog.md), which also gives the
web screen, status and plan owners of every menu.

## Company — 16 menus ([catalog](../menu-catalog.md#company))

- **Purpose.** Business context and administration: company, location, year, books and account slots, users and
  rights, account and trade groups, settings and menu tiles, year-end balance transfer, data refresh, backup.
- **Typical workflow** (*tutorial*, `project-memory/video-research/_kb/KB_master.md:45-70`): create the company →
  enter address, state, work type (retail/wholesale) and metal type → save → create the first year (masters and
  settings are seeded) → reopen → log in and choose company, location and year.
- **Writes.** `CO_MAST`, `LOCT_MAST`, `YEAR_MAST`, `BOOK_DATA`, `BOOK_DETL`, `LOGIN_MAST`, `USER_SET`, `CO_SET`,
  `CO_SET_NEW`; no ledger or stock effect.
- **Links.** Every other tab depends on the selected company, location, year, books and rights.

## Master — 23 menus ([catalog](../menu-catalog.md#master))

- **Purpose.** Parties and accounts, products, groups, items and auto-items, touch and labour, employees, taxes,
  counters, design book, diamonds and sizes, styles, points, stock limits and openings.
- **Typical workflow** (*tutorial*, `project-memory/video-research/_kb/KB_master.md:113-178`): create a product →
  create a group with metal type, touch, sales and purchase accounts, HSN and tax → create items (or generate them
  with AutoItem) → enter opening item stock and opening tags.
- **Writes.** `AC_MAST`, `AC_GROUP`, `OP_DATA`, `PRODUCT_MAST`, `GROUP_MAST`, `ITEM_MAST`, `RATE_MAST`, `TAX_MAST`,
  `EMP_MAST`, `LBR_MAST`, `TOUCH_MAST`, design and diamond tables, `ITM_OPBL`, `BAR_DETL` for opening tags.
- **Links.** Masters drive pricing, posting accounts, stock identity and every report; deleting a referenced master
  must be refused.

## Transaction — 24 menus ([catalog](../menu-catalog.md#transaction))

- **Purpose.** Daily trade and finance: sales, purchase, returns, orders and quotations, cash, bank and contra,
  wholesale, stock in and out, bullion booking and sale, rate cut, e-invoice and e-credit-note.
- **Typical sale** (*tutorial*, `project-memory/video-research/_kb/KB_transaction.md:43-107`): choose the invoice
  book → select the party → scan a tag or enter a loose item → weights, touch, labour, charges and GST are calculated
  → add old metal, order advance or scheme redemption → split the tender (cash, card, UPI, cheque) → save → print the
  original and copies → the ledger, stock, GST and outstanding update.
- **Writes.** `SL_*`, `PR_*`, `CASH_DATA`, `PAY_DATA`, `CONTRA_DATA`, `BUL_DATA`, `RATE_CUT_*` with `AC_DATA`,
  `ROJ_MEL_DATA`, `MAIN_STOCK`, `TAX_DATA` and `BILL_OS_DATA`.
- **Outputs.** Invoice, return, quotation and order prints; sales and purchase registers; ledgers; GST returns.

## ExtraTran — 21 menus ([catalog](../menu-catalog.md#extratran))

- **Purpose.** Secondary but financially material work: approval and consignment, fine JV and fine trade, bill-wise
  and card receipts, labour billing, old-item and tag-wise purchase, other income and expenses, service commission,
  VP parcels and inter-location amounts.
- **Typical approval** (*tutorial*, `project-memory/video-research/_kb/KB_transaction.md:331-387`): issue selected
  tags to a party → stock shows as pending approval with no sale ledger → receive back some tags → bill the accepted
  tags through Sales.
- **Writes.** `APR_*`, `CUT_*`, `LBR_*`, `PAY_DATA`, `CARD_DATA`, `BILL_OS_DATA`, `VP_ADJ_DATA`, `LOCT_AMT` with the
  shared ledger, day-book, stock and tax tables.

## Karigar — 15 menus ([catalog](../menu-catalog.md#karigar))

- **Purpose.** Artisan custody: metal issue and ornament receipt, design issue, the customer repair chain, employee
  and tour stock.
- **Typical karigar cycle** (*tutorial*, `project-memory/video-research/_kb/KB_karigar.md:36-68,93-147`): check stock
  → issue fine metal to the karigar (the ledger shows metal receivable) → receive finished ornaments with touch,
  wastage, labour and stones → tag them → settle labour, tax and cash or leave it payable → check the manufacturing
  ledger and stock.
- **Repair chain.** Customer repair receipt → issue to karigar → receipt from karigar → delivery to the customer with
  labour and material settlement.
- **Writes.** `KR_*`, `MFG_*`, `REP_*`, `APR_*`, `BAR_*`, `MAIN_STOCK`, `AC_DATA`, `ROJ_MEL_DATA`, `TAX_DATA`.

## Dhiran — 12 menus ([catalog](../menu-catalog.md#dhiran))

- **Purpose.** Pledge loans against customer ornaments and the mirror money-loan directions: packets and images,
  principal, interest, renewal, release, dues and outstanding letters.
- **Typical cycle** (*source*): issue a loan against valued packets → collect interest only or part principal →
  release eligible packets → renew across the year if configured → settle by cash or fine rate cut → print dues,
  outstanding letters, khata and stock reports.
- **Writes.** `DHRN_ISU_DATA/DETL`, `DHRN_REC_DATA/DETL`, `DHRN_DATA`, `MAIN_STOCK`, `AC_DATA`, `ROJ_MEL_DATA`,
  images and `DELETE_DATA`; packet close flags must be reversed on delete.
- **Edition.** Hidden up to the Ultra edition.

## Scheme — 11 menus ([catalog](../menu-catalog.md#scheme))

- **Purpose.** Monthly savings schemes (separate from loyalty points).
- **Typical cycle** (*source*): define the scheme and enrol the member → enter openings or monthly instalments for one
  or many members by cash, bank or UPI → optionally convert to gold at the daily rate → redeem into a sale → mature
  with bonus or deduction, or pay out → print the passbook, ledger and monthly reports.
- **Writes.** `AD_MAST`, `AD_MEMB`, `AD_DATA`, `AD_OS`, `AD_ADJ`; loyalty uses `POINT_MAST`, `POINT_MEMB`,
  `POINT_DATA`.
- **Edition.** Hidden up to the Standard edition.

## Mfg — 4 menus plus stage screens ([catalog](../menu-catalog.md#mfg))

- **Purpose.** Manufacturing configuration and reports. The stage screens themselves are dispatched outside the menu
  table (see the desktop handbook §4).
- **Stage chain** (*inferred* from the stage graph): metal and design issue → wax and casting → ghat, filing,
  pre-polish, engraving, enamel, setting, assembly, second filing, polish → partial receipts, rework and loss →
  finished tags or order fulfilment.
- **Writes.** `MFG_DATA/DETL/IDTL`, `MFG_ISU_REC`, `MAIN_STOCK`, `APR_*`, `SL_ORD_*`, `DM_*`, `AC_DATA`,
  `ROJ_MEL_DATA`, `TAX_DATA`. Routing depends on the one-form, order-linked and lot settings.

## Report — 26 menus ([catalog](../menu-catalog.md#report))

- **Purpose.** Operational and statutory reporting: ledgers, final accounts, Rojmel, cash-bank, outstanding, sales,
  purchase, stock, tags, HUID, GST, orders, approval, bullion, VP, trading, address and image reports.
- **How operators use it:** choose the report → enter date, location, book, party and item filters → build the grid
  → double-click to drill to the voucher → View, Print or export.
- **Tables.** Reads business tables; some `RP_*` forms rebuild scratch tables per run (`REPORT_DATA`,
  `LEDR_AC_DATA`, `TAG_STOCK_PRINT`, `FINE_DATA`, `ROJMEL_BAL`).

## More — 12 menus ([catalog](../menu-catalog.md#more))

- **Purpose.** Management analysis: bill-wise profit, employee sales, entry and user checks, graphs, movement,
  design and stock levels, order tracking and lots, points and stone reports.
- Report-centric; some modes stage rows in `REPORT_DATA` or `USER_DATA`. Entry Check also marks reviewed rows.

## Analysis — 8 menus ([catalog](../menu-catalog.md#analysis))

- **Purpose.** Bill ageing by days, the deletion audit, last visit, order zoom, party and item stock ledgers,
  movement and tag detail.
- Reads `BILL_OS_DATA`, `DELETE_DATA`, `AC_MAST`, `AC_DATA`, `MAIN_STOCK`, `SL_ORD_*` and tag tables.

## Other — 24 menus ([catalog](../menu-catalog.md#other))

- **Purpose.** Daily controls and utilities: daily rate, physical stock, tag cancel, transfer, split, weight change,
  print and adjust, bank reconciliation, order cancellation and refund, labour update, reminders, SMS and WhatsApp,
  import, export, estimate reset, e-invoice export and voucher renumber.
- **Typical physical count** (*tutorial*, `project-memory/video-research/_kb/KB_other.md:216-260`): scan every tag on
  the counter → save the count → run the All or Diff report → post shortages separately through Tag Cancel or Stock
  Adjust.
- **Typical daily rate** (*tutorial*, `project-memory/video-research/_kb/KB_other.md:44-103`): enter gold per 10 g
  and silver per kg → group sale and purchase rates are derived by touch → save.
- **Writes.** `RATE_MAST`, `BAR_CAN_*`, `MAIN_STOCK`, `TAG_PRINT_DATA`, `AC_DATA.CLR_DATE`, `SL_ORD_ADJ`,
  `REMARK_DATA`, `REM_DATA`.

## Crm — 2 menus ([catalog](../menu-catalog.md#crm))

- **Purpose.** Customer interactions and follow-ups: customer entry (`UT_CUST_ENTRY`) records interest, items and
  remarks per customer and employee; the customer report reviews follow-ups and reminders and closes them.
- Reads and writes `CUST_DATA`, `CUST_DETL`, `AC_MAST`, `BILL_OS_DATA` and reminder data.
