# Gap register and plan amendment — 1 October 2026

This amendment records the defects and missing behaviour found by the static desktop-versus-web audit of
1 October 2026 and folds them into the master plan as ordered slices **N31–N46**. It supplements documents
01–09; it does not close, narrow or replace any original package (P00–P14), continuation card (X01–X34) or
slice (N01–N30).

- **Web baseline:** `main` at `c7d02c7` (after X15, the D1–D6 evaluation fixes, X16, N18 and N19).
- **Desktop authority:** `unified/src/csharp/DataCareNext/` (decompiled C#). Line numbers below are 1-based in
  that tree and in `web/` at the web baseline.
- **Method:** source tracing of screen → request → route → writer/reader → tables, compared with the desktop
  form, its `MDI_FORM` dispatch and its posting routines. No original Windows run and no fresh
  desktop/web database differential was performed for this register, so every gap still needs its own
  independent desktop comparison before acceptance (document 04).

## 1. Corrections to the 29 September assessment

| Area | 29 September statement | Current state at `c7d02c7` |
|---|---|---|
| Containment | Six operations contained | **Three** remain: `logical-restore`, `production-cutover-load`, `tag-weight-difference` (`web/packages/core/containment.mjs`). Tag cancel, transfer and split were released by N18/N19 after their exit gates. |
| E Credit Note (X15, slice N16) | Browse + IRN only | Create/edit/delete/print lifecycle for **E CRNT and E INVOICE** exists (`modules/einvoice/eBillWriter.ts`, `/e-credit-notes`, `/e-invoices`). Desktop replay, provider state machine and business acceptance remain open. |
| Wholesale / rate cut (X16, slice N17) | No stock, no rate-cut money leg | `TR_WH_SALE` rebuilt: `MAIN_STOCK` tag movement, `Wh_Sales_Ledr` legs, `BILL_TOTAL` settlement, shared form. Open items listed in `parity-plan-2026-09-10/46-implementation-progress-x16-2026-09-29.md`. |
| Tag operations (slices N18, N19) | Contained | Tag cancel/transfer (`stock/tagCancel.ts`) and tag split (`stock/tagSplit.ts`) implemented with real-stack journeys; **weight difference still contained**. |
| Evaluation defects D1–D6 | Open | Fixed in engineering evidence (`45-implementation-progress-eval-defects-2026-09-29.md`): finance book selection, sale amount basis, report slugs/routes/rights, order-cancel scope, 400-not-500 validation. |
| CI on `main` | Red | Still red at `c7d02c7` on `depth:parity` (unreachable API fields 98 > ceiling 96); `depth:deadcells` also fails behind it. A fix is prepared (sale-return grid/writer alignment, 98 → 94). |

These are **engineering** improvements. Menu acceptance remains **0/198**, package acceptance **0/83** and card
acceptance **0/34**; no functional percentage is established.

## 2. Gap register

Severity: **S1** blocks a daily workflow or produces a wrong financial/legal document; **S2** wrong or
incomplete result in a supported branch; **S3** missing variant, parity detail or ergonomics.

| ID | Sev | Workflow | Desktop authority | Web evidence (`c7d02c7`) | Required behaviour | Slice |
|---|---|---|---|---|---|---|
| G01 | S1 | All sale/purchase/quotation/credit-note prints | `TR_SALE.cs:16475,16532` and `TR_PURC.cs:14007` filter `CO_CODE`,`LC_CODE`,`CO_YEAR`,`CO_BOOK`,`VCH_NO` | `modules/sales/invoice.ts:29-40` and `modules/purchase/purchaseBill.ts:24-34` omit `LC_CODE`; detail queries also omit `CO_YEAR`; `routes/txn.ts:1740,1781,1886,2142` default the book to `SAL`/`PUR`/`SRT` | Every document reader uses the complete voucher key from the authenticated scope; no default book | N31 |
| G02 | S1 | Tag Wise Purc / hallmark purchase (`TR_PURC_HM`) | `MDI_FORM.cs:8540-8541` `CurBookHelp("TAG PURCHASE")`; `:7865-7866` `PURCHASE` with `MsPurcWithHmTax` | `txn/purchase-hm/page.tsx:286` posts `/purchases` without `coBook`; `purchase.ts:544-550` requires a configured book, so every save is refused; page is create-only | Book selector by MAIN_BOOK; reopen/edit/delete/print; then the 95-column receive grid (P04-02) | N32 |
| G03 | S1 | Other Expenses (`TR_OTH_PURC`, `OTH EXP`) | `MDI_FORM.cs:8372-8383`; grid `TR_OTH_PURC.cs:2351-2432` (TaxCode, Disc%, DiscAmt, TaxableAmt, CGST/SGST/IGST, ConIt, Con%) | `txn/other-purchase/page.tsx:92` posts no book; `vouchers/numbering.ts:38-44` requires one; list hard-codes book `OPR` (`:289`); API has create/delete only (`txn.ts:2425,2450`) | Book selection; full grid; get/edit/delete/print lifecycle mirroring Other Income | N33 |
| G04 | S1 | Purchase Return (`TR_KR_ISU`) | Source picker `TR_KR_ISU.cs:6850-6895`; posting `:5249-5285` (`Purc_Rtn_Ledr`, `Purc_Rtn_Rojmel`, `Purc_Rtn_GST`, `Purc_Rtn_Stk`, `Dm_PrRtn_Detl`) | `txn/purchase-return/page.tsx:223,259` never sends `origVchNo`/`origBook`; `purchaseReturn.ts:157` refuses any tagged return without them; write set `:525-589` has no `ROJ_MEL_DATA` or `DM_DATA`; no read/edit/print route | Original-purchase selector with remaining quantities; Rojmel and diamond detail; reopen/edit/print | N34 |
| G05 | S2 | Sales Return original-bill import | Original sale browse by configured SALES books | `txn/sale-return/page.tsx:259` free-text original book defaulting to `SAL`; `txn.ts:1490` defaults `qs.book ?? 'SAL'` | Original book chosen from active SALES books; no literal default | N35 |
| G06 | S1 | Sales/purchase/GST/daily/employee registers | `RP_ALL.cs:7826-7890`: sales by `SL_DATA.NET_AMT <> 0`, returns by `RTN_NET_AMT <> 0`, optional LC/book/party filters | `reports/reports.ts:197,206,465,486,756`, `reports5.ts:39,97`, `reports7.ts:35`, `reports9.ts:46` exclude literal `CO_BOOK='SRT'`/`'PRT'`; a desktop-shaped company (e.g. books 026/027/035) has returns, quotations and credit notes counted as sales | Classify by stored amounts and `BOOK_DATA.MAIN_BOOK`, never by literal book codes; apply LC/book filters | N36 |
| G07 | S2 | Order Cancel (`TR_SL_ORD_ADJ`) | Multi-order grid `TR_SL_ORD_ADJ.cs:2152-2190` (OrdAmt, AdjAmt, KsarAmt, PaidAmt, PaiidAc); save `:3510-3671` (`SL_ORD_ADJ` rows, `APR_DETL`/`BAR_DETL` tags, `Order_Adj_Ledr`, `Order_Adj_Rojmel`, `Ord_Adj_Stk`) | `salesOrder.ts:2119-2230` single order, book literal `ORC`/`SADJ`, `CASH`/`KASAR` fallbacks, no `paid + kasar ≤ open advance` bound, no Rojmel/stock/tag rows, no edit/delete/print | Desktop adjustment voucher: configured book, multi-order grid, bounds, full write set, lifecycle, print | N37 |
| G08 | S2 | Wh Quotation | `MDI_FORM.cs:8242-8252` `CurBookHelp("Wh QUOT")` → `TR_WH_SALE` | `lib/wholesaleVoucher.ts:30` supports only `wholesale-sale` and `rate-cut` | Quotation mode of the shared wholesale form: persisted, no stock/ledger, print, convert | N38 |
| G09 | S1 | Estimate print | Company master drives document headers | `txn/estimate/page.tsx:322` prints the literal `DHAKAN JEWELLERS` for every business | Company name/address/GSTIN from `CO_MAST`; persisted estimate decision recorded (D-list) | N39 |
| G10 | S2 | Hallmark Sale (`TR_SALE_HM`) | Same lifecycle as `TR_SALE` | `txn/hallmark-sale/page.tsx` create + print only; no reopen/edit/delete | Reopen/edit/delete through `/sales/:vchNo` with the hallmark fields | N40 |
| G11 | S2 | Line previews | `TR_SALE.cs:11112`, `TR_PURC.cs:9991`, `TR_PURC_HM.cs:6207`: labour on (net + ghat) unless `MsLbrWithGht = 'N'` | `withGhat: true` hard-coded in six previews (`hallmark-sale:297`, `purchase-hm:235`, `sale-return:331`, `purchase-return:202`, `estimate:253`, `purchase:252`) | Preview reads `LBR_WITH_GHT` like the writer, so preview = posting | N41 |
| G12 | S2 | Sales save validation | `TR_SALE.cs:15030` "Please Select Employee Code and Try......" when employee is mandatory | `sales.ts` persists `EMP_CODE` but never enforces `CO_SET.EMP_CODE_MANDATORY` (other writers do: `finance/locationAmount.ts:227`, `einvoice/eBillWriter.ts:745`) | Enforce with the desktop message, before any write | N42 |
| G13 | S1 | Invoice/bill print variants and copies | `TR_SALE.cs:16435-16562` (`SalesBillHzGST`, `SalesQuotation`, `RtlHuidPrint`, selectable file, CUSTOMER/ACCOUNT copy); `TR_PURC.cs:13950-14061` (`PurcBillA4Gst`, `PurcBillA4`, `PurcBill<book>`, `PurcQuot`, `OldItmSaleVch`, `KrRecVch*`) | One generic A4 GST HTML body (`documents/docChrome.ts`); copy label only on sales | Template registry per book/setting, copies, HUID print, dataset-then-layout comparison (P10-05) | N43 |
| G14 | S2 | Sales Order settlement and fulfilment | `TR_SALE_ORD.cs` UPI/old-metal grids (`:3556-4016`); `Ac_Rojmel.Order_Rojmel` types 02–08 | Page: "Separate tender, metal and allocation workflows are not available here"; `salesOrder.ts:1195-1240` writes Rojmel type 01 only | Tender rows, old-metal advance (`SL_PR_DETL`), delivery allocation into invoices | N44 |
| G15 | S2 | Wholesale remaining branches | X16 open list | `46-implementation-progress-x16-2026-09-29.md` Status | Rojmel types, stones into `SL_IDTL`/`DM_DATA`, remaining legs, `MAIN_STOCK` SR_NO 4–7, negative-stock refusal, `TEMP_BOOK_DATA`, print for sale and return | N45 |
| G16 | S2 | Quotation conversion | Sales/purchase quotation feed invoices | No conversion path from `/sales-quotations` or `/purchase-quotations` | Explicit source selection and lineage into sale/purchase | N46 |
| G17 | S2 | Other Income print | `EInvOthIncom.rpt` | No print route or button | Printable voucher | N43 |
| G18 | S1 | CI integrity | — | `main` red on `depth:parity`; dead-cell gate hidden | Keep `main` green; every slice lands through a PR with all gates | N30 |

## 3. New slices

All new slices are **planned** until implemented; implementation moves a slice to `implemented-unverified`,
never to accepted. Each follows document 02 §4–§5 and must add: a DB test that compares the complete write
set, a deliberate failing variant, and a real-stack browser journey with zero mocked requests.

| Slice | Action | Parents | Start after | Must prove |
|---|---|---|---|---|
| N31 | Scope every document reader (sales, purchase, quotation, credit note) with company, location, year and book; remove literal book defaults from document routes | P10-01, P01-01, X05/X25 | N13 | Same book/voucher in two locations and two years prints only the selected voucher; missing book is a 400 |
| N32 | Hallmark/tag-wise purchase: configured book, full lifecycle, print; then TR_PURC_HM receive grid | P04-02, X12 | N15 | Save/reopen/edit/delete through the screen; stored rows compared column by column |
| N33 | Other Expenses: configured OTH EXP book, desktop grid, get/edit/delete/print | P04-02, X12 | N15 | Forward and reverse tax lines, discount, inter/intra split reproduce desktop arithmetic; edit replaces the exact write set |
| N34 | Purchase Return: original-purchase selector with remaining quantities, Rojmel and diamond detail, reopen/edit/print | P04-04, X12 | N15 | Over-return refused; tagged return accepted; Rojmel/DM rows present; reversal restores stock |
| N35 | Sales Return original book from active SALES books | P05-03, X13 | N15 | Import from a non-`SAL` sales book; wrong-family book refused |
| N36 | Registers classify by amounts and MAIN_BOOK, not literal codes | P10-03, X26 | N13 | Desktop-shaped fixture (books 026/027/035/036, quotation, credit note) totals match the desktop rule |
| N37 | Order Cancel as the desktop adjustment voucher | P05-04, X14 | N22 | Multi-order adjustment, bounds, ledger/Rojmel/stock/tag rows, edit/delete/print |
| N38 | Wholesale quotation mode | P05-02/04, X13/X14 | N17 | No stock or ledger rows; print; conversion lineage |
| N39 | Estimate document from company master; decide persisted-estimate scope | P05-01, X13 | N15 | Two companies print their own headers |
| N40 | Hallmark sale reopen/edit/delete | P05-01, X13 | N15 | Unchanged save preserves HUIDs and hallmark charge; delete reverses all effects |
| N41 | Previews honour LBR_WITH_GHT | P02-05, X08 | N15 | Preview equals posted labour with the setting Y and N |
| N42 | Enforce EMP_CODE_MANDATORY on sales | P05-01, X13 | N15 | Refusal with the desktop message; no partial write |
| N43 | Document template registry: sales/purchase variants, copies, HUID print, Other Income voucher | P10-05, X25 | N24, N31 | Dataset equality then desktop layout review per template |
| N44 | Sales Order tenders, old-metal advance and delivery allocation | P05-04, X14 | N22 | Advance consumed exactly once across partial deliveries |
| N45 | Wholesale remaining branches from X16 | P05-02, P06-05, X16 | N17 | Each listed branch has a write-set test and journey |
| N46 | Quotation → invoice conversion with lineage | P05-06, X14 | N38 | Converted lines keep source identity; repeated conversion refused |

## 4. Order of execution

1. Land the CI fix and keep `main` green (G18).
2. S1 defects that block daily work or print wrong documents: **N31, N32, N33, N34, N36, N39**.
3. S2 correctness in supported branches: **N35, N40, N41, N42, N37**.
4. Variant and document depth: **N43, N44, N45, N38, N46**.
5. Continue the existing N-sequence for the programme-level blockers that remain open: weight difference
   (N19), physical stock (N20), lot manufacturing writes (N21, `mfgLot.ts:212` `writes: false`),
   custody chains (N22), loans/schemes (N23), reports (N24), devices (N25), utilities (N26), migration
   (N27, contained), restore (N28, contained), full journeys and UAT (N29), certification (N30).

A slice is never closed by this register. Parents stay open until their desktop comparison and business
acceptance exist.
