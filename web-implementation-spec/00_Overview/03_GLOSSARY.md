# Glossary — domain terms

DataCareNext is built around the Indian (and UAE) **jewelry & gold trade**. The schema, column
names, and business logic assume this vocabulary. An implementer must internalize these terms —
they explain *why* the data model and calculations look the way they do.

> Terms marked **(confirm)** are inferred from context/column usage and should be verified against
> the decompiled form before final implementation.

## Weight & purity

| Term | Meaning | Where it shows up |
|---|---|---|
| **Gross weight (GWT)** | Total weight of an item including stones, beads, strings. | `ITM_GWT`, `*_GWT` |
| **Net weight (NWT)** | Metal-only weight (gross minus stone/other weight). | `ITM_NWT`, `*_NWT` |
| **Touch / Tunch** | Purity **percentage** of the metal (e.g. 91.60 for 22-karat gold). | `ITM_TOUCH`, `TOUCH_MAST` |
| **Fine / Fine weight** | Pure-metal content = **NWT × Touch / 100**. The core unit for valuation & metal ledgers. | `ITM_FINE`, `FINE_WT` |
| **Fine rate** | Price per gram of *fine* (pure) metal. | `FINE_RATE` |
| **Wastage / West** | Extra metal charged/lost in manufacturing, added to fine (`NWT × (TOUCH+WEST)/100`). | `WEST`, `WASTAGE` |
| **Ghat (confirm)** | Weight loss/deduction during melting or refining. | `TR_MFG_GHAT_REC` |
| **Stone weight** | Weight of stones/diamonds (priced separately, not metal). | `STONE_WT`, sub-detail tables |

## Money & charges

| Term | Meaning | Where |
|---|---|---|
| **Labour / Making charges (LBR)** | Charge for making/crafting. Computed by **labour type**: per-gram, per-piece, percentage, or fixed. | `LBR_TYPE`, `LBR_RATE`, `LBR_AMT` |
| **Rate type** | How metal value is computed: on fine, on net weight, fixed, etc. | `RATE_TYPE`, `RATE_MAST` |
| **Kasar (confirm)** | Small rounding/discount written off to settle a round figure. | `*_KASAR_AMT` |
| **Round-off (ROF)** | Final bill rounding to whole rupees. | `ROF_AMT` |
| **Advance / Order advance** | Amount paid in advance against an order, adjusted on the final bill. | `ADV_AMT`, `SL_ORD_ADJ`, `AD_ADJ` |
| **Outstanding (OS)** | Unpaid balance on a bill or account. | `BILL_OS`, `BILL_OS_DATA`, `RP_OS` |

## Documents & accounting

| Term | Meaning | Where |
|---|---|---|
| **Voucher** | A single transaction document (sale, purchase, receipt, …) with header + detail. | `VCH_NO`, `VCH_TYPE`, `VCH_DATE` |
| **Book (CO_BOOK)** | A voucher series/ledger book that governs numbering & posting (e.g. SALES, CASH). | `CO_BOOK`, `MS_BOOK` |
| **Rojmel / Rojmal** | The **day book / cash register** — daily running record of receipts & payments. | `ROJ_MEL_DATA`, `Ac_Rojmel`, `RP_ROJMEL` |
| **Ledger posting** | Double-entry debit/credit rows written to `AC_DATA` when a voucher saves. | `AC_DATA`, `Ac_Ledr` |
| **Contra** | A transfer between two of the company's own cash/bank accounts. | `TR_CONTRA`, `CONTRA_DATA` |
| **Final accounts** | Trial balance, P&L, balance sheet roll-ups. | `Ac_Final`, `LEDR_AC_DATA` |
| **Metal (fine) ledger** | A parallel ledger that tracks **fine-weight** balances (not money) per account. | `FINE_WT`/`FINE_RATE` in `AC_DATA` |

## Inventory

| Term | Meaning | Where |
|---|---|---|
| **Tag** | A barcoded label uniquely identifying one physical item (weight, touch, labour baked in). | `TAG_STOCK`, `TAG_MAST`, `TAG_NO` |
| **Lot** | A batch grouping of items (e.g. received together). | `ITM_LOT`, `LOT_DETL`, `ITM_LOT_DETL` |
| **Main stock** | Aggregate item-wise stock balances (qty/gwt/nwt/fine). | `MAIN_STOCK` |
| **APR / Approval / Consignment** | Items given out "on approval" (not yet sold). | `APR_DETL`, `TR_APR_ISU`, `RP_CONSI_APR` |
| **Melting** | Melting old/scrap gold to recover fine metal. | `TR_MLT_PRO` |
| **Physical stock** | Stock-taking / reconciliation against system stock. | `TR_PHYSTK`, `RP_PHY_STOCK` |

## Trade-specific transaction types

| Term | Meaning | Form |
|---|---|---|
| **Karigar** | The goldsmith/artisan (job-worker). Material is *issued* to them and finished goods *received*; their **metal balance** is tracked. | `TR_KR_ISU`, `TR_MFG_KR_ISU_REC`, `KR_DATA` |
| **Dhrn / Dharan** | A **gold loan / pledge** — customer pledges gold ornaments as security for a cash loan; interest accrues by day-count. | `TR_DHRN_ISU/REC/INTREC`, `DHRN_*` |
| **HUID** | **Hallmark Unique ID** — the 6-char BIS hallmark identifier now mandatory per item in India. | `TR_SALE_HM`, `RP_HUID` |
| **Hallmark** | BIS purity certification of an item. | `TR_SALE_HM`, `TR_PURC_HM` |
| **Hedging / Rate fixing** | Locking the gold rate now for metal to be delivered/billed later. | `TR_PR_SL_HEDG`, fixing links `SL_PR_DETL` |
| **Fine sale/purchase** | Trading **pure metal (fine)** directly (bullion-style), priced on fine weight. | `TR_FINE_SL_PR` |
| **Gold book / scheme (confirm)** | A savings scheme where a customer deposits money over time to buy gold later. | `TR_GOLD_BOOK`, `MS_GOLD_MAST` |
| **VP (confirm)** | A scheme/voucher type (e.g. value-payable / instalment); confirm exact semantics from `TR_VP.cs`. | `TR_VP`, `TR_VP_ADJ` |
| **Tour** | Salesman takes stock "on tour" (exhibition/customer visit) and books orders/sales remotely. | `TR_TOUR`, `TR_TOUR_SALE`, `TR_TOUR_ORD` |
| **Bullion** | Raw gold/silver bars & coins trading (wholesale). | `TR_BUL_SALE`, `TR_BUL_BOOKING` |
| **Wholesale (WH)** | Wholesale sales/returns (B2B, different pricing/posting). | `TR_WH_SALE`, `TR_WH_SALE_RTN` |
| **Loyalty points** | Customer reward points earned/redeemed on sales. | `TR_MEMB_*`, `POINT_DATA`, `MS_POINT` |

## Multi-tenancy / scoping keys

| Key | Meaning |
|---|---|
| **CO_CODE** | Company (top-level tenant), e.g. `01`. |
| **LC_CODE** | Location / branch / counter within a company. |
| **CO_YEAR** | Accounting/financial year (was a separate SQL Server DB per year; becomes a column in the web DB). |
| **CO_BOOK** | Voucher book/series within a company+location. |
| **VCH_NO / SR_NO** | Voucher number / line serial within the composite key. |

The full composite key for transactional rows is **(CO_CODE, LC_CODE, CO_YEAR, CO_BOOK, VCH_NO, SR_NO)**;
masters key on **(CO_CODE, …)**. In the web DB an outer `tenant_id` wraps these and Postgres RLS
enforces isolation. See `01_Architecture/multitenancy-scoping.md`.

## Indian GST terms

| Term | Meaning |
|---|---|
| **CGST / SGST** | Central & State GST — each half of the tax for an **intra-state** supply. |
| **IGST** | Integrated GST — the full tax for an **inter-state** supply. |
| **B2B / B2CL / B2CS** | GSTR-1 classifications: business-to-business / large B2C inter-state / small B2C. |
| **HSN** | Harmonized System Nomenclature code (per item, for tax summary). |
| **IRN** | Invoice Reference Number — the hash returned by the government e-invoice system. |
| **GSP** | GST Suvidha Provider — the gateway used to submit e-invoices/returns. |
