# End-to-End Parity Audit — Exhaustive Form Appendix (2026-07-29)

> **Status: current static evidence appendix for the immutable 2026-07-29T08:10:12Z snapshot.** The official matrix generator completed successfully at `2026-07-29T08:12:14+00:00`. A passed static generator does not establish desktop runtime parity.

## Provenance and interpretation

- Immutable snapshot evidence: `snapshot_utc=20260729T081012Z; snapshot_path=/tmp/imodule-parity-snapshot-20260729T081012Z; live_before=f9f80c1462be2df52aa454c9d71709f46f37cd3d226e2e3988a300eb04ced7be files=5277; live_after=f9f80c1462be2df52aa454c9d71709f46f37cd3d226e2e3988a300eb04ced7be files=5277; snapshot=f9f80c1462be2df52aa454c9d71709f46f37cd3d226e2e3988a300eb04ced7be files=5277`.
- Audit-cutoff official matrix: `project-memory/parity/snapshots/immutable-20260729T081012Z/DESKTOP-WEB-PARITY-MATRIX.json`; all 204 rows below come from that successful snapshot run.
- Static write-union detection: **3,280/3,669 (89.4%)**; parser coverage is not workflow parity.
- Validation-text heuristic: **435/655 (66.4%)**; detection is not enforcement proof.
- Audited API-field capture: **492/492 (100.0%)**; both Sales and Sales Order currently have zero uncapturable fields in this narrow audit.
- Calculation inventory: **1327** computed fields; **1041** map to columns detected as written. No calculation parity percentage is asserted.
- Every form remains `desktop_compared=not_started` and `production_certified=not_started`; no row is exact-parity certified.
- Per-form write/grid/field percentages are static name/write indicators and can under- or over-credit semantic equivalence.

## Status legend

- `passed`: only the narrow generator gate passed; not full parity.
- `in_progress`: mapped work/evidence exists but acceptance is incomplete.
- `not_started`: no qualifying evidence.
- `waived`: inapplicable or explicitly waived; see `WAIVERS.md`.
- `evidence_gap`/`blocked`: evidence is absent or externally blocked.

## All 204 canonical desktop forms

Counts: **204** — master 33, other 43, report 45, transaction 61, utility 22.

### Transaction (61)

| Form | Sev. | Mapping | Web surface | Impl. | Depth | Tested | Write %* | Grid %* | Field %* | Missing tables* | E5 | E6 |
|---|---:|---|---|---|---|---|---:|---:|---:|---|---|---|
| `TR_AC_OPBL` | critical | dedicated-current-surface | /txn/ac-opbl, /masters/opening-balance | in_progress | in_progress | in_progress | 100% | 31.6% | 100% | none | not_started | not_started |
| `TR_APR_ISU` | high | variant-shared | /txn/tour, /txn/tour-return, /txn/sales-order | in_progress | in_progress | in_progress | 100% | 39.4% | 100% | none | not_started | not_started |
| `TR_BILL_TO` | critical | dedicated-current-surface | /txn/bill-to-bill | in_progress | in_progress | in_progress | 100% | 33.3% | 53.3% | none | not_started | not_started |
| `TR_BUL_BOOKING` | high | dedicated-current-surface | /txn/bullion | in_progress | in_progress | in_progress | 100% | 0% | 84.6% | none | not_started | not_started |
| `TR_BUL_SALE` | high | variant-shared | /txn/bullion, /txn/rate-cut | in_progress | in_progress | in_progress | 100% | 7.8% | 75.7% | none | not_started | not_started |
| `TR_CARD_REC` | high | variant-shared | /txn/receipt, /txn/payment, /txn/batch-receipt | in_progress | in_progress | in_progress | 100% | n/a | 100% | none | not_started | not_started |
| `TR_CASH` | critical | variant-shared | /txn/receipt, /txn/payment, /txn/batch-receipt | in_progress | in_progress | in_progress | 100% | 100% | 100% | none | not_started | not_started |
| `TR_CONTRA` | critical | dedicated-current-surface | /txn/contra, /txn/journal | in_progress | in_progress | in_progress | 100% | 100% | 100% | none | not_started | not_started |
| `TR_DHRN_INTREC` | high | dedicated-current-surface | /txn/dhrn-interest | in_progress | in_progress | in_progress | 100% | n/a | 21.4% | none | not_started | not_started |
| `TR_DHRN_ISU` | high | dedicated-current-surface | /txn/dhrn-issue | in_progress | in_progress | in_progress | 100% | 37% | 66.7% | none | not_started | not_started |
| `TR_DHRN_REC` | high | dedicated-current-surface | /txn/dhrn-receipt | in_progress | in_progress | in_progress | 100% | 0% | 23.4% | none | not_started | not_started |
| `TR_EMP_JV` | high | dedicated-current-surface | /txn/employee-jv | in_progress | waived | in_progress | n/a | 0% | 100% | none | not_started | not_started |
| `TR_FINE_SL_PR` | high | dedicated-current-surface | /txn/fine-sale | in_progress | waived | in_progress | n/a | 24.6% | 100% | none | not_started | not_started |
| `TR_FN_INOUT` | high | dedicated-current-surface | /txn/fine-inout | in_progress | in_progress | in_progress | 100% | 5.8% | 61.9% | none | not_started | not_started |
| `TR_GOLD_BOOK` | high | dedicated-current-surface | /txn/gold-book | in_progress | in_progress | in_progress | 100% | 42.1% | 100% | none | not_started | not_started |
| `TR_INOUT` | high | variant-shared | /txn/fine-inout | in_progress | in_progress | in_progress | 100% | 5.5% | 68.4% | none | not_started | not_started |
| `TR_ITM_LOT` | high | dedicated-current-surface | /txn/item-lot | in_progress | in_progress | in_progress | 100% | 36.1% | 62.5% | none | not_started | not_started |
| `TR_ITM_OPBL` | critical | dedicated-current-surface | /txn/item-opening | in_progress | waived | in_progress | n/a | 44.4% | 100% | none | not_started | not_started |
| `TR_JDT_REC` | high | variant-shared | /txn/jobwork-issue, /txn/jobwork-receive | in_progress | in_progress | in_progress | 100% | 35.6% | 100% | none | not_started | not_started |
| `TR_KR_ISU` | critical | dedicated-current-surface | /txn/karigar-issue | in_progress | in_progress | in_progress | 100% | 30% | 91.3% | none | not_started | not_started |
| `TR_LEDR_ADJ` | high | dedicated-current-surface | /txn/ledger-adjust, /txn/fine-jv | in_progress | waived | in_progress | n/a | 0% | 100% | none | not_started | not_started |
| `TR_LOCT_AMT` | high | dedicated-current-surface | /txn/location-amount | in_progress | in_progress | in_progress | 100% | 50% | 82.4% | none | not_started | not_started |
| `TR_MEMB_ADJ` | high | variant-shared | /txn/membership, /txn/scheme, /reports/scheme-adjustments | in_progress | in_progress | in_progress | 100% | 34.8% | 100% | none | not_started | not_started |
| `TR_MEMB_ENT` | high | dedicated-current-surface | /txn/membership, /txn/scheme | in_progress | in_progress | in_progress | 100% | 21.4% | 100% | none | not_started | not_started |
| `TR_MFG_GHAT_REC` | high | variant-shared | /txn/mfg-receive | in_progress | in_progress | in_progress | 100% | 13.9% | 100% | none | not_started | not_started |
| `TR_MFG_ISU_REC` | critical | dedicated-current-surface | /txn/mfg-issue, /txn/mfg-receive | in_progress | in_progress | in_progress | 100% | 20.2% | 100% | none | not_started | not_started |
| `TR_MFG_ITEM` | high | dedicated-current-surface | /txn/mfg-issue, /txn/mfg-receive | in_progress | in_progress | in_progress | 100% | 16% | 100% | none | not_started | not_started |
| `TR_MFG_KR_ISU_REC` | high | variant-shared | /txn/karigar-issue, /txn/karigar-receive, /txn/mfg-issue, /txn/mfg-receive | in_progress | in_progress | in_progress | 100% | 37.1% | 100% | none | not_started | not_started |
| `TR_MFG_ORD_ISU` | high | dedicated-current-surface | /txn/mfg-order-issue | in_progress | in_progress | in_progress | 100% | 8.8% | 92.9% | none | not_started | not_started |
| `TR_MFG_ORD_REC` | high | variant-shared | /txn/mfg-receive | in_progress | in_progress | in_progress | 100% | 8.6% | 100% | none | not_started | not_started |
| `TR_MFG_WITH_LOT` | high | variant-shared | /txn/mfg-receive | in_progress | in_progress | in_progress | 100% | 11.1% | 89.5% | none | not_started | not_started |
| `TR_MLT_PRO` | high | dedicated-current-surface | /txn/melting | in_progress | passed | in_progress | 100% | 100% | 100% | none | not_started | not_started |
| `TR_OTH_COMM` | high | dedicated-current-surface | /txn/other-commission | in_progress | in_progress | in_progress | 100% | 22.6% | 100% | none | not_started | not_started |
| `TR_OTH_PURC` | high | dedicated-current-surface | /txn/other-purchase | in_progress | in_progress | in_progress | 100% | 37.5% | 83.3% | none | not_started | not_started |
| `TR_PHYSTK` | high | dedicated-current-surface | /txn/physical-stock | in_progress | in_progress | in_progress | 93.7% | 56.2% | 100% | none | not_started | not_started |
| `TR_PR_SL_HEDG` | high | conceptual-engine | /txn/rate-cut | in_progress | waived | in_progress | n/a | 68.8% | 100% | none | not_started | not_started |
| `TR_PR_SL_UAE` | high | waived-documented | none | waived | waived | not_started | 100% | 0% | 0% | none | not_started | not_started |
| `TR_PURC` | critical | dedicated-current-surface | /txn/purchase, /txn/purchase-return | in_progress | in_progress | in_progress | 83.3% | 14.5% | 100% | TAG_SET | not_started | not_started |
| `TR_PURC_HM` | high | variant-shared | /txn/purchase-hm | in_progress | in_progress | in_progress | 93.1% | 8.3% | 50% | none | not_started | not_started |
| `TR_REP_REC` | high | dedicated-current-surface | /txn/repair-receipt, /txn/repair-karigar-issue, /txn/repair-karigar-receipt, /txn/repair-customer-issue | in_progress | waived | in_progress | n/a | 88.9% | 100% | none | not_started | not_started |
| `TR_SALE` | critical | dedicated-current-surface | /txn/sales | in_progress | in_progress | in_progress | 100% | 16.3% | 100% | none | not_started | not_started |
| `TR_SALE_HM` | high | variant-shared | /txn/hallmark-sale | in_progress | in_progress | in_progress | 100% | 7.4% | 73% | none | not_started | not_started |
| `TR_SALE_LBR` | high | dedicated-current-surface | /txn/labour-sale | in_progress | in_progress | in_progress | 100% | 9.2% | 51.6% | none | not_started | not_started |
| `TR_SALE_ORD` | high | dedicated-current-surface | /txn/sales-order, /txn/order-cancel | in_progress | in_progress | in_progress | 100% | 20.4% | 76.9% | none | not_started | not_started |
| `TR_SALE_RTN` | critical | dedicated-current-surface | /txn/sale-return | in_progress | in_progress | in_progress | 89.9% | 9.1% | 100% | TAG_SET | not_started | not_started |
| `TR_SALE_RTN_UAE` | high | waived-documented | none | waived | waived | not_started | 94.1% | 0% | 0% | none | not_started | not_started |
| `TR_SL_EBILL` | high | variant-shared | /utilities/e-invoice | in_progress | in_progress | in_progress | 100% | 6.9% | 4% | none | not_started | not_started |
| `TR_SL_ORD_ADJ` | high | dedicated-current-surface | /txn/sales-order, /txn/order-cancel | in_progress | in_progress | in_progress | 91.1% | 87.9% | 100% | none | not_started | not_started |
| `TR_SL_PR_ITEM` | high | conceptual-engine | /txn/rate-cut | in_progress | in_progress | in_progress | 100% | 8.6% | 94.4% | none | not_started | not_started |
| `TR_TAG_CAN` | critical | dedicated-current-surface | /txn/tag-cancel | in_progress | in_progress | in_progress | 100% | 9.6% | 100% | none | not_started | not_started |
| `TR_TAG_OPBL` | critical | dedicated-current-surface | /txn/tag-opening | in_progress | in_progress | in_progress | 91.5% | 11.1% | 36.7% | TAG_SET | not_started | not_started |
| `TR_TAG_SPLIT` | critical | dedicated-current-surface | /txn/tag-split | in_progress | in_progress | in_progress | 93.2% | 5.1% | 51.5% | TAG_SET | not_started | not_started |
| `TR_TAG_WT_DIFF` | high | dedicated-current-surface | /txn/tag-weight-diff | in_progress | in_progress | in_progress | 100% | 11.2% | 51.7% | none | not_started | not_started |
| `TR_TOUR` | high | dedicated-current-surface | /txn/tour | in_progress | in_progress | in_progress | 100% | 8.5% | 100% | none | not_started | not_started |
| `TR_TOUR_ORD` | high | variant-shared | /txn/tour, /txn/tour-return, /txn/sales-order | in_progress | in_progress | in_progress | 100% | 32.8% | 100% | none | not_started | not_started |
| `TR_TOUR_SALE` | high | variant-shared | /txn/tour, /txn/tour-return, /txn/sales-order | in_progress | in_progress | in_progress | 100% | 22.9% | 85.4% | none | not_started | not_started |
| `TR_UPI_REC` | high | variant-shared | /txn/receipt, /txn/payment, /txn/batch-receipt | in_progress | waived | in_progress | n/a | 100% | 100% | none | not_started | not_started |
| `TR_VP` | high | dedicated-current-surface | /txn/vp-parcel | in_progress | in_progress | in_progress | 100% | 14.6% | 90.5% | none | not_started | not_started |
| `TR_VP_ADJ` | high | dedicated-current-surface | /txn/vp-adjustment | in_progress | in_progress | in_progress | 100% | 64.3% | 100% | none | not_started | not_started |
| `TR_WH_SALE` | high | variant-shared | /txn/wholesale-sale | in_progress | in_progress | in_progress | 99% | 6% | 31.6% | none | not_started | not_started |
| `TR_WH_SALE_RTN` | high | dedicated-current-surface | /txn/wholesale-sale-return | in_progress | in_progress | in_progress | 100% | 10% | 65.4% | none | not_started | not_started |

### Master (33)

| Form | Sev. | Mapping | Web surface | Impl. | Depth | Tested | Write %* | Grid %* | Field %* | Missing tables* | E5 | E6 |
|---|---:|---|---|---|---|---|---:|---:|---:|---|---|---|
| `MS_ACCT` | high | variant-shared | /masters/accounts, /masters/customers, /masters/party | in_progress | in_progress | in_progress | 97.9% | n/a | 100% | none | not_started | not_started |
| `MS_AC_GROUP` | medium | generic-crud-scaffold | /masters/ac-groups | in_progress | in_progress | in_progress | 53.8% | n/a | 100% | BOOK_IDTL | not_started | not_started |
| `MS_ADD_MAST` | medium | generic-crud-scaffold | /masters/addresses | in_progress | in_progress | in_progress | 100% | n/a | 100% | none | not_started | not_started |
| `MS_AUTO_ITEM` | medium | dedicated-current-surface | /masters/auto-item | in_progress | waived | in_progress | n/a | 9.3% | 61.5% | none | not_started | not_started |
| `MS_BOOK` | high | generic-crud-scaffold | /masters/books | in_progress | waived | in_progress | n/a | n/a | 29.4% | none | not_started | not_started |
| `MS_BOOKLIST` | medium | generic-scaffold | /masters/books | in_progress | waived | not_started | n/a | n/a | 100% | none | not_started | not_started |
| `MS_COMPANY` | critical | variant-shared | /masters/companies, /admin/provision, /select | in_progress | in_progress | not_started | 97.9% | n/a | 13.7% | none | not_started | not_started |
| `MS_DESIGN_BOOK` | medium | variant-shared | /masters/styles, /masters/designs, /masters/models | in_progress | in_progress | in_progress | 100% | 2.6% | 62.5% | none | not_started | not_started |
| `MS_DM` | medium | generic-crud-scaffold | /masters/diamonds | in_progress | waived | in_progress | n/a | n/a | 100% | none | not_started | not_started |
| `MS_EMP` | medium | generic-crud-scaffold | /masters/employees | in_progress | waived | in_progress | n/a | n/a | 100% | none | not_started | not_started |
| `MS_GOLD_MAST` | medium | generic-crud-scaffold | /masters/gold-rate | in_progress | in_progress | in_progress | 86.7% | n/a | n/a | none | not_started | not_started |
| `MS_GROUP` | medium | generic-crud-scaffold | /masters/groups | in_progress | waived | in_progress | n/a | n/a | 100% | none | not_started | not_started |
| `MS_HELP` | medium | waived-documented | none | waived | waived | not_started | n/a | n/a | 0% | none | not_started | not_started |
| `MS_ITEM` | medium | generic-crud-scaffold | /masters/items | in_progress | in_progress | in_progress | 96.8% | n/a | 100% | none | not_started | not_started |
| `MS_LBR_TYPE` | medium | generic-crud-scaffold | /masters/labour, /masters/labour-update | in_progress | waived | in_progress | n/a | n/a | 100% | none | not_started | not_started |
| `MS_LOCT` | medium | generic-crud-scaffold | /masters/locations | in_progress | in_progress | in_progress | 100% | n/a | 17.9% | none | not_started | not_started |
| `MS_LOGIN` | critical | conceptual-engine | /login, /admin/users | in_progress | in_progress | in_progress | 83.3% | n/a | 100% | none | not_started | not_started |
| `MS_MEMB` | medium | variant-shared | /txn/membership, /txn/scheme | in_progress | waived | in_progress | n/a | n/a | 100% | none | not_started | not_started |
| `MS_MFG_MAST` | medium | generic-crud-scaffold | /masters/mfg | in_progress | in_progress | in_progress | 100% | 14.3% | 100% | none | not_started | not_started |
| `MS_OPNCOMP` | medium | variant-shared | /masters/companies, /admin/provision, /select | in_progress | in_progress | not_started | 100% | n/a | 100% | none | not_started | not_started |
| `MS_POINT` | medium | generic-crud-scaffold | /masters/points | in_progress | waived | in_progress | n/a | 12.5% | 62.5% | none | not_started | not_started |
| `MS_PRINT` | medium | generic-crud-scaffold | /masters/print-formats | in_progress | evidence_gap | in_progress | n/a | n/a | 100% | none | not_started | not_started |
| `MS_PRODUCT` | medium | generic-crud-scaffold | /masters/products | in_progress | in_progress | in_progress | 60.9% | n/a | 100% | BOOK_IDTL | not_started | not_started |
| `MS_RATE` | medium | variant-shared | /masters/rates, /txn/daily-rate | in_progress | in_progress | in_progress | 92.6% | 70% | 100% | none | not_started | not_started |
| `MS_STK_LIMIT` | medium | variant-shared | /masters/item-weights | in_progress | waived | not_started | n/a | 11.1% | 100% | none | not_started | not_started |
| `MS_STYLE` | medium | variant-shared | /masters/styles, /masters/designs, /masters/models | in_progress | in_progress | in_progress | 77.8% | n/a | 100% | none | not_started | not_started |
| `MS_TASTING` | medium | waived-documented | none | waived | waived | not_started | n/a | n/a | n/a | none | not_started | not_started |
| `MS_TAX` | medium | generic-crud-scaffold | /masters/taxes | in_progress | waived | in_progress | n/a | 40% | 100% | none | not_started | not_started |
| `MS_TRADE` | medium | generic-crud-scaffold | /masters/trade | in_progress | waived | in_progress | n/a | 22.2% | n/a | none | not_started | not_started |
| `MS_UPDATE` | medium | conceptual-engine | /utilities/data-refresh, /masters/labour-update | in_progress | in_progress | not_started | 86.9% | n/a | 100% | BOOK_IDTL, MENU_DATA, USER_MAST, WEIGHT_MAST | not_started | not_started |
| `MS_USER` | critical | dedicated-current-surface | /admin/users | in_progress | in_progress | in_progress | 70.6% | n/a | 100% | BOOK_IDTL, MENU_DATA | not_started | not_started |
| `MS_WINDOW_SET` | medium | variant-shared | /settings, /masters/styles | in_progress | waived | not_started | n/a | 33.3% | 100% | none | not_started | not_started |
| `MS_YEAR` | critical | variant-shared | /masters/years, /masters/year-create, /utilities/year-end | in_progress | in_progress | not_started | 100% | n/a | 100% | none | not_started | not_started |

### Report (45)

| Form | Sev. | Mapping | Web surface | Impl. | Depth | Tested | Write %* | Grid %* | Field %* | Missing tables* | E5 | E6 |
|---|---:|---|---|---|---|---|---:|---:|---:|---|---|---|
| `RP_ADDRESS` | medium | generic-report-scaffold | /reports/report-layouts | in_progress | in_progress | not_started | 100% | n/a | 4.2% | none | not_started | not_started |
| `RP_ALL` | medium | conceptual-report-engine | /reports/report-layouts | in_progress | in_progress | not_started | 100% | n/a | 5.3% | none | not_started | not_started |
| `RP_BALANCE` | medium | conceptual-report-engine | /reports/balance-sheet, /reports/account-balances | in_progress | in_progress | not_started | 96.4% | 15.4% | 25% | none | not_started | not_started |
| `RP_BAL_ZOOM` | medium | conceptual-report-engine | /reports/account-balances | in_progress | in_progress | not_started | 100% | 4.9% | 18.2% | none | not_started | not_started |
| `RP_BILL_PROFIT` | medium | generic-report-scaffold | /reports/report-layouts | in_progress | waived | not_started | n/a | 7.7% | 8.3% | none | not_started | not_started |
| `RP_CASH_BANK` | medium | conceptual-report-engine | /reports/cash-book | in_progress | in_progress | not_started | 94.1% | 7.4% | 13.3% | none | not_started | not_started |
| `RP_CONSI_APR` | medium | generic-report-scaffold | /reports/report-layouts | in_progress | waived | not_started | n/a | 20% | 50% | none | not_started | not_started |
| `RP_CUST` | medium | conceptual-report-engine | /reports/customer-crm | in_progress | waived | not_started | n/a | n/a | 66.7% | none | not_started | not_started |
| `RP_CUST_CRM` | medium | conceptual-report-engine | /reports/customer-crm | in_progress | waived | not_started | n/a | 7.4% | 8.7% | none | not_started | not_started |
| `RP_DAY_WORK` | medium | conceptual-report-engine | /reports/day-book | in_progress | waived | not_started | n/a | 7.4% | 33.3% | none | not_started | not_started |
| `RP_DHRN_LOAN` | medium | conceptual-report-engine | /reports/dhrn-outstanding | in_progress | in_progress | not_started | 92.9% | n/a | 16.7% | none | not_started | not_started |
| `RP_DHRN_OS` | medium | conceptual-report-engine | /reports/dhrn-outstanding | in_progress | in_progress | not_started | 100% | 3.3% | 14.3% | none | not_started | not_started |
| `RP_EMP` | medium | conceptual-report-engine | /reports/employee-sales | in_progress | in_progress | not_started | 100% | 8.7% | 14.3% | none | not_started | not_started |
| `RP_GRAPH` | medium | conceptual-report-engine | /reports/daily-sales, /reports/top-items | in_progress | waived | not_started | n/a | n/a | 22.2% | none | not_started | not_started |
| `RP_GST` | medium | conceptual-report-engine | /reports/gstr1, /reports/gstr2, /reports/gstr3b | in_progress | waived | not_started | n/a | 10.5% | 22.2% | none | not_started | not_started |
| `RP_HUID` | medium | conceptual-report-engine | /reports/tag-stock | in_progress | in_progress | not_started | 100% | n/a | 37.5% | none | not_started | not_started |
| `RP_INOUT` | medium | conceptual-report-engine | /reports/item-stock-ledger | in_progress | in_progress | not_started | 100% | 2.5% | 25% | none | not_started | not_started |
| `RP_JDTR_ZOOM` | medium | conceptual-report-engine | /reports/karigar-ledger | in_progress | waived | not_started | n/a | 28.6% | 25% | none | not_started | not_started |
| `RP_LC_INOUT` | medium | conceptual-report-engine | /reports/stock-by-location | in_progress | waived | not_started | n/a | 9.1% | 40% | none | not_started | not_started |
| `RP_LC_SALE` | medium | conceptual-report-engine | /reports/location-wise-sales | in_progress | waived | not_started | n/a | 9.1% | 28.6% | none | not_started | not_started |
| `RP_LEDR` | medium | conceptual-report-engine | /reports/account-ledger | in_progress | in_progress | not_started | 100% | 2.5% | 9.5% | none | not_started | not_started |
| `RP_MFG` | medium | generic-report-scaffold | /reports/report-layouts | in_progress | waived | not_started | n/a | n/a | 9.1% | none | not_started | not_started |
| `RP_MFG_LEDR` | medium | conceptual-report-engine | /reports/karigar-ledger | in_progress | waived | not_started | n/a | 22.9% | 18.2% | none | not_started | not_started |
| `RP_MFG_ZOOM` | medium | generic-report-scaffold | /reports/report-layouts | in_progress | waived | not_started | n/a | 11.6% | 9.1% | none | not_started | not_started |
| `RP_MOVEMENT` | medium | conceptual-report-engine | /reports/item-stock-ledger | in_progress | waived | not_started | n/a | 4.1% | 16.7% | none | not_started | not_started |
| `RP_ORDER` | medium | generic-report-scaffold | /reports/report-layouts | in_progress | waived | not_started | n/a | 6.8% | 12.5% | none | not_started | not_started |
| `RP_ORD_TRACK` | medium | generic-report-scaffold | /reports/report-layouts | in_progress | waived | not_started | n/a | 10% | 7.7% | none | not_started | not_started |
| `RP_OS` | medium | conceptual-report-engine | /reports/outstanding, /reports/bill-outstanding | in_progress | in_progress | not_started | 100% | n/a | 9.1% | none | not_started | not_started |
| `RP_OTH_DETL` | medium | generic-report-scaffold | /reports/report-layouts | in_progress | waived | not_started | n/a | n/a | 5% | none | not_started | not_started |
| `RP_PHY_STOCK` | medium | conceptual-report-engine | /txn/physical-stock | in_progress | in_progress | not_started | 100% | 100% | 100% | none | not_started | not_started |
| `RP_REMINDER` | medium | conceptual-report-engine | /utilities/reminders | in_progress | in_progress | not_started | 100% | n/a | 100% | none | not_started | not_started |
| `RP_ROJMEL` | medium | conceptual-report-engine | /reports/day-book | in_progress | in_progress | not_started | 71.7% | 4.9% | 40% | ROJMEL_BAL | not_started | not_started |
| `RP_SLPR_ZOOM` | medium | conceptual-report-engine | /reports/sales-register, /reports/purchase-register | in_progress | waived | not_started | n/a | 1.4% | 15.4% | none | not_started | not_started |
| `RP_STK_LEVEL` | medium | conceptual-report-engine | /reports/item-group-stock | in_progress | waived | not_started | n/a | 10.5% | 28.6% | none | not_started | not_started |
| `RP_STK_MOVE` | medium | conceptual-report-engine | /reports/item-stock-ledger | in_progress | waived | not_started | n/a | 5.3% | 22.2% | none | not_started | not_started |
| `RP_STOCK` | medium | conceptual-report-engine | /reports/stock-valuation | in_progress | in_progress | not_started | 100% | 5.3% | 14.3% | none | not_started | not_started |
| `RP_STOCK_FINE` | medium | conceptual-report-engine | /reports/stock-valuation | in_progress | waived | not_started | n/a | 4.4% | 33.3% | none | not_started | not_started |
| `RP_STOCK_VALUE` | medium | conceptual-report-engine | /reports/stock-valuation | in_progress | waived | not_started | n/a | 4.4% | 25% | none | not_started | not_started |
| `RP_TAG` | medium | conceptual-report-engine | /reports/tag-stock | in_progress | in_progress | not_started | 50% | 37.9% | 12% | TAG_SUM_DATA | not_started | not_started |
| `RP_TAG_ESTMATE` | medium | conceptual-report-engine | /reports/report-layouts | in_progress | in_progress | not_started | 100% | 10.4% | 9.1% | none | not_started | not_started |
| `RP_TAG_IMAGE` | medium | conceptual-report-engine | /reports/report-layouts | in_progress | waived | not_started | n/a | 21.7% | 7.7% | none | not_started | not_started |
| `RP_TAX` | medium | conceptual-report-engine | /reports/hsn-summary, /reports/gst-input-register | in_progress | waived | not_started | n/a | n/a | 16.7% | none | not_started | not_started |
| `RP_TOUR_ZOOM` | medium | generic-report-scaffold | /reports/report-layouts | in_progress | waived | not_started | n/a | 6.5% | 7.1% | none | not_started | not_started |
| `RP_TRADING` | medium | generic-report-scaffold | /reports/report-layouts | in_progress | waived | not_started | n/a | 26.3% | 12.5% | none | not_started | not_started |
| `RP_USER` | medium | generic-report-scaffold | /reports/report-layouts | in_progress | in_progress | not_started | 93.6% | 9.3% | 12.5% | none | not_started | not_started |

### Utility (22)

| Form | Sev. | Mapping | Web surface | Impl. | Depth | Tested | Write %* | Grid %* | Field %* | Missing tables* | E5 | E6 |
|---|---:|---|---|---|---|---|---:|---:|---:|---|---|---|
| `UT_AI_TRFR` | medium | variant-shared | /txn/tag-transfer, /txn/counter-transfer | in_progress | not_started | in_progress | 0% | 100% | 100% | BOOK_IDTL, TAG_DATA | not_started | not_started |
| `UT_BANK` | medium | variant-shared | /txn/bank-recon | in_progress | waived | in_progress | n/a | 61.1% | 100% | none | not_started | not_started |
| `UT_BKP` | high | dedicated-current-surface | /backup | in_progress | waived | not_started | n/a | n/a | 0% | none | not_started | not_started |
| `UT_CUST_ENTRY` | medium | variant-shared | /masters/party | in_progress | waived | not_started | n/a | 17.6% | 100% | none | not_started | not_started |
| `UT_EXPORT` | medium | variant-shared | /backup, /masters/accounts | in_progress | in_progress | not_started | 91.2% | n/a | n/a | none | not_started | not_started |
| `UT_E_INVOICE` | medium | dedicated-current-surface | /utilities/e-invoice | in_progress | waived | in_progress | n/a | 9.1% | 50% | none | not_started | not_started |
| `UT_HDD` | medium | dedicated-current-surface | /utilities/hdd-registry | in_progress | in_progress | in_progress | 100% | n/a | 33.3% | none | not_started | not_started |
| `UT_IMPORT` | medium | variant-shared | /backup, /masters/accounts | in_progress | in_progress | not_started | 91.4% | n/a | 100% | OP_LDR | not_started | not_started |
| `UT_PWD_UPDATE` | high | conceptual-engine | /login | in_progress | waived | in_progress | n/a | n/a | 0% | none | not_started | not_started |
| `UT_REMINDER` | medium | variant-shared | /utilities/reminders, /utilities/reminder-entry, /txn/reminders | in_progress | waived | not_started | n/a | 100% | 87.5% | none | not_started | not_started |
| `UT_REPORT` | medium | generic-report-scaffold | /reports/report-layouts | in_progress | waived | in_progress | n/a | n/a | n/a | none | not_started | not_started |
| `UT_SETTING` | high | variant-shared | /settings, /admin/users | in_progress | waived | in_progress | n/a | 100% | 37% | none | not_started | not_started |
| `UT_SETTING_MAIN` | high | variant-shared | /settings, /admin/users | in_progress | waived | in_progress | n/a | n/a | 18.5% | none | not_started | not_started |
| `UT_SET_ADMIN` | high | variant-shared | /settings, /admin/users | in_progress | waived | in_progress | n/a | n/a | 90.9% | none | not_started | not_started |
| `UT_SMS` | medium | variant-shared | /integrations | in_progress | in_progress | in_progress | 100% | n/a | 40% | none | not_started | not_started |
| `UT_TAG_PRINT` | medium | dedicated-current-surface | /txn/tag-print | in_progress | in_progress | in_progress | 100% | 11.3% | 42.9% | none | not_started | not_started |
| `UT_USER_REQUEST` | medium | dedicated-current-surface | /utilities/user-request | in_progress | in_progress | in_progress | 100% | n/a | 100% | none | not_started | not_started |
| `UT_VCH_RE_NUMBR` | medium | dedicated-current-surface | /utilities/voucher-renumber | in_progress | waived | not_started | n/a | n/a | 50% | none | not_started | not_started |
| `UT_WAPP_WITH_API` | medium | variant-shared | /integrations | in_progress | in_progress | in_progress | 94.7% | n/a | 37.5% | APP_CHATMESSAGES, WEBHOOKINBOX | not_started | not_started |
| `UT_WEB_CAM` | medium | waived-documented | none | waived | waived | not_started | n/a | n/a | n/a | none | not_started | not_started |
| `UT_WHATSAPP` | medium | variant-shared | /integrations | in_progress | in_progress | in_progress | 95.7% | n/a | 28.6% | none | not_started | not_started |
| `UT_WINDOW` | medium | dedicated-current-surface | /utilities/window-tiles | in_progress | waived | in_progress | n/a | n/a | n/a | none | not_started | not_started |

### Other (43)

| Form | Sev. | Mapping | Web surface | Impl. | Depth | Tested | Write %* | Grid %* | Field %* | Missing tables* | E5 | E6 |
|---|---:|---|---|---|---|---|---:|---:|---:|---|---|---|
| `Ac_Final` | low | conceptual-engine | /utilities/year-end, /reports/balance-sheet | in_progress | in_progress | not_started | 97.7% | n/a | n/a | none | not_started | not_started |
| `Ac_Image` | low | variant-shared | /masters/party, /txn/tag-print | in_progress | in_progress | not_started | 98.4% | n/a | n/a | none | not_started | not_started |
| `Ac_Ledr` | low | conceptual-engine | none | in_progress | in_progress | not_started | 96.6% | n/a | n/a | none | not_started | not_started |
| `Ac_Rojmel` | low | conceptual-engine | /reports/day-book | in_progress | in_progress | not_started | 100% | n/a | n/a | none | not_started | not_started |
| `Ac_Stock` | low | conceptual-engine | /txn/stock, /reports/tag-stock | in_progress | in_progress | not_started | 83.8% | n/a | n/a | TAG_SUM_DATA | not_started | not_started |
| `Ac_Tax` | low | conceptual-engine | /reports/gstr1, /reports/gstr2, /reports/gstr3b | in_progress | in_progress | not_started | 86.1% | n/a | n/a | none | not_started | not_started |
| `AuthClass` | low | conceptual-engine | /login | in_progress | evidence_gap | not_started | n/a | n/a | n/a | none | not_started | not_started |
| `AuthError` | low | conceptual-engine | /login | in_progress | evidence_gap | not_started | n/a | n/a | n/a | none | not_started | not_started |
| `BtmSchm` | low | conceptual-engine | /txn/scheme | in_progress | in_progress | not_started | 87.6% | n/a | 100% | OP_LDR | not_started | not_started |
| `ClassTagList` | low | conceptual-engine | /txn/stock, /reports/tag-stock | in_progress | evidence_gap | not_started | n/a | n/a | n/a | none | not_started | not_started |
| `ClsAddlDocDtls` | low | conceptual-engine | /utilities/e-invoice | in_progress | evidence_gap | not_started | n/a | n/a | n/a | none | not_started | not_started |
| `ClsAttribDtls` | low | conceptual-engine | /utilities/e-invoice | in_progress | evidence_gap | not_started | n/a | n/a | n/a | none | not_started | not_started |
| `ClsBchDtls` | low | conceptual-engine | /utilities/e-invoice | in_progress | evidence_gap | not_started | n/a | n/a | n/a | none | not_started | not_started |
| `ClsBuyerDtls` | low | conceptual-engine | /utilities/e-invoice | in_progress | evidence_gap | not_started | n/a | n/a | n/a | none | not_started | not_started |
| `ClsContrDtls` | low | conceptual-engine | /utilities/e-invoice | in_progress | evidence_gap | not_started | n/a | n/a | n/a | none | not_started | not_started |
| `ClsDispDtls` | low | conceptual-engine | /utilities/e-invoice | in_progress | evidence_gap | not_started | n/a | n/a | n/a | none | not_started | not_started |
| `ClsDocDtls` | low | conceptual-engine | /utilities/e-invoice | in_progress | evidence_gap | not_started | n/a | n/a | n/a | none | not_started | not_started |
| `ClsDocPerdDtls` | low | conceptual-engine | /utilities/e-invoice | in_progress | evidence_gap | not_started | n/a | n/a | n/a | none | not_started | not_started |
| `ClsExpDtls` | low | conceptual-engine | /utilities/e-invoice | in_progress | evidence_gap | not_started | n/a | n/a | n/a | none | not_started | not_started |
| `ClsItemList` | low | waived-documented | none | waived | waived | not_started | n/a | n/a | n/a | none | not_started | not_started |
| `ClsPayDtls` | low | conceptual-engine | /utilities/e-invoice | in_progress | evidence_gap | not_started | n/a | n/a | n/a | none | not_started | not_started |
| `ClsPrecDocDtls` | low | conceptual-engine | /utilities/e-invoice | in_progress | evidence_gap | not_started | n/a | n/a | n/a | none | not_started | not_started |
| `ClsRefDtls` | low | conceptual-engine | /utilities/e-invoice | in_progress | evidence_gap | not_started | n/a | n/a | n/a | none | not_started | not_started |
| `ClsSellerDtls` | low | conceptual-engine | /utilities/e-invoice | in_progress | evidence_gap | not_started | n/a | n/a | n/a | none | not_started | not_started |
| `ClsShipDtls` | low | conceptual-engine | /utilities/e-invoice | in_progress | evidence_gap | not_started | n/a | n/a | n/a | none | not_started | not_started |
| `ClsTranDtls` | low | conceptual-engine | /utilities/e-invoice | in_progress | evidence_gap | not_started | n/a | n/a | n/a | none | not_started | not_started |
| `ClsValDtls` | low | conceptual-engine | /utilities/e-invoice | in_progress | evidence_gap | not_started | n/a | n/a | n/a | none | not_started | not_started |
| `DC_Main` | low | conceptual-engine | /dashboard | in_progress | waived | not_started | n/a | n/a | n/a | none | not_started | not_started |
| `Data` | low | waived-documented | none | waived | waived | not_started | n/a | n/a | n/a | none | not_started | not_started |
| `DcClass` | low | waived-documented | none | waived | waived | not_started | n/a | n/a | n/a | none | not_started | not_started |
| `DcPrintClass` | low | waived-documented | none | waived | waived | not_started | n/a | n/a | n/a | none | not_started | not_started |
| `ErrorResp` | low | conceptual-engine | /utilities/e-invoice | in_progress | evidence_gap | not_started | n/a | n/a | n/a | none | not_started | not_started |
| `IRNClass` | low | conceptual-engine | /utilities/e-invoice | in_progress | evidence_gap | not_started | n/a | n/a | n/a | none | not_started | not_started |
| `IRNData` | low | conceptual-engine | /utilities/e-invoice | in_progress | evidence_gap | not_started | n/a | n/a | n/a | none | not_started | not_started |
| `MDI_FORM` | low | conceptual-engine | /dashboard | in_progress | waived | not_started | n/a | n/a | 0% | none | not_started | not_started |
| `Mfg_Module` | low | conceptual-engine | /txn/mfg-issue, /txn/mfg-receive | in_progress | in_progress | not_started | 84.7% | n/a | n/a | BOOK_IDTL, MENU_DATA | not_started | not_started |
| `Module_Save` | low | conceptual-engine | none | in_progress | waived | not_started | n/a | n/a | n/a | none | not_started | not_started |
| `Module_Schm` | low | conceptual-engine | /txn/scheme | in_progress | in_progress | not_started | 93.6% | n/a | n/a | none | not_started | not_started |
| `Module_WhatsApp` | low | conceptual-engine | /integrations | in_progress | waived | not_started | n/a | n/a | n/a | none | not_started | not_started |
| `OlockerService` | low | waived-documented | none | waived | waived | not_started | n/a | n/a | n/a | none | not_started | not_started |
| `PolicyModels` | low | conceptual-engine | /utilities/e-invoice | in_progress | evidence_gap | not_started | n/a | n/a | n/a | none | not_started | not_started |
| `TagOthDetail` | low | conceptual-engine | /txn/stock, /reports/tag-stock | in_progress | evidence_gap | not_started | n/a | n/a | n/a | none | not_started | not_started |
| `Translator` | low | waived-documented | none | waived | waived | not_started | n/a | n/a | n/a | none | not_started | not_started |

* Current per-form static indicators for the cited immutable snapshot. Table-union matching can over-credit workflows; name matching can under- or over-credit semantics.

## Current generator outcome

- `validation_audit.py`: passed.
- `calc_audit.py`: passed.
- `ui_field_audit.py`: passed with 492/492 capturable fields; Sales 0 gaps; Sales Order 0 gaps.
- `deep_column_audit.py`: passed with 3,280/3,669 static write-column intersections.
- `build_parity_matrix.py`: passed and published the current JSON/Markdown/CSV matrix.
- This resolves the earlier transient Sales Order publication assertion, not any E5/E6 gate.

## Machine evidence

- Audit-cutoff matrix: `project-memory/parity/snapshots/immutable-20260729T081012Z/DESKTOP-WEB-PARITY-MATRIX.{json,md,csv}`
- Audit-cutoff audits: `project-memory/parity/snapshots/immutable-20260729T081012Z/{VALIDATION-AUDIT.json,CALC-AUDIT.json,UI-FIELD-AUDIT.json,DEEP-COLUMN-AUDIT*.json}`
- Immutable snapshot hash/log: `project-memory/parity/snapshots/immutable-snapshot-20260729T081012Z.txt`, `immutable-generator-20260729T081012Z.log`
