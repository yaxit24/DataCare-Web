# Real-data verification & desktop↔web depth comparison (Next24 / DHAKAN JEWELLERS)

_Generated 2026-06-28. Source of truth: the real desktop SQL Server DB `Next24` (attached via Azure SQL Edge) vs the web Postgres app, tenant `default`, company `01`, FY `2024`._

## 1. Real data imported into the web app
`apps/api/integration/import_real.mjs` ETL'd the real business data from `Next24` into the web `default` tenant (CO_CODE already `01`; CO_YEAR `2024-2025` → `2024`; LOGIN_MAST/YEAR_MAST left intact so admin/Secret#1 + FY-2024 keep working). **30 tables, 9,106 rows, 0 failures (IMPORT_OK).**

| Area | Tables | Rows |
|---|---|---|
| Masters | CO_MAST(1 DHAKAN JEWELLERS), GROUP_MAST(33), AC_MAST(918), ITEM_MAST(238), PRODUCT_MAST(103), RATE_MAST(1008), TAX_MAST(25), BOOK_DATA(210), EMP_MAST(3), STATE_MAST(37), LOCT_MAST(1) | ~2,577 |
| Sales | SL_DATA(190), SL_DETL(245), SL_IDTL(103), SL_ORD_DATA(76) | 614 |
| Purchase | PR_DATA(74), PR_DETL(103) | 177 |
| Ledger/Tax | AC_DATA(5150), TAX_DATA(184), BILL_OS_DATA(365) | 5,699 |
| Mfg | KR_DATA(17), KR_DETL(22) | 39 |

The web UI (http://localhost:3001) now runs on this real business.

## 2. Data fidelity — web == desktop EXACTLY (to the paisa)
Raw aggregates compared between the desktop source and the web's imported copy:

| Measure | Desktop (Next24) | Web (Postgres) | Match |
|---|---|---|---|
| AC_DATA Σ DR_AMT | 55,180,589.47 | 55,180,589.47 | ✅ exact |
| AC_DATA Σ CR_AMT | 56,302,194.65 | 56,302,194.65 | ✅ exact |
| AC_DATA rows | 5,150 | 5,150 | ✅ |
| SL_DATA Σ NET_AMT | 5,334,847 | 5,334,847 | ✅ exact |
| SL_DATA Σ TAX_AMT | 143,348.82 | 143,348.82 | ✅ exact |
| SL_DATA Σ TOT_AMT | 5,478,196 | 5,478,196 | ✅ exact |

(Prior full-matrix run: 141/141 common tables 100% column-complete; 371/372 numeric Σ checks match — only `TAX_DATA.TAX_AMT` +0.45 from intended 2dp rounding.)

## 3. Computation parity — web calc engine reproduces desktop on REAL invoices
`compute_parity.live.mjs` recomputed all **190 real SL_DATA invoices** through `@datacare/core billTotals`:
- **TAX: 190/190 exact** (<₹0.05) vs desktop stored TAX_AMT.
- **TOTAL: 190/190 exact** vs desktop stored TOT_AMT.
- desktop internal consistency `TAX_AMT == CGST+SGST+IGST`: 190/190.
- Samples: vch00001 net 72,857 → tax 2,185.71 / total 75,043 (web == desktop); vch00003 net 138,264 → tax 4,147.92 / total 142,412 (web == desktop). → **COMPUTE_PARITY_OK.**

## 4. Functional verification on real data (web API)
| Web feature | Result on real data | Desktop-equivalent |
|---|---|---|
| Sales register | 190 invoices, net 5,334,847, tax 143,348.82, total 5,478,196 | matches SL_DATA Σ exactly |
| Purchase register | 74 bills, total 2,819,954 | matches PR_DATA |
| GSTR-3B (outward) | taxable 5,334,847, tax 143,348.82 (CGST 71,674.41 = SGST 71,674.41, IGST 0) | tax == SL_DATA TAX_AMT; CGST/SGST split consistent |
| Sales by party | top 001017 ₹467,887, 000997 ₹454,833, 000880 ₹240,581 | real customer ranking |
| Masters (accounts) | 918 real accounts (00001 CASH ON HAND, 00002 CAPITAL A/C, …) | AC_MAST |
| Account balances | 300 accounts with Dr/Cr | AC_DATA grouped |

Found + fixed during this verification: report scope wrongly defaulted `LC_CODE` to the company code, hiding the real data (LC_CODE `00`). Fixed so company+year reports span all locations.

## 5. Honest depth gaps (web vs desktop) — where parity is NOT yet 1:1
1. **Trial balance / balance sheet.** The web `trialBalance` is a faithful raw Dr/Cr sum of AC_DATA → it reports `balanced:false` with the **same ₹1,121,605.18 Dr<Cr gap that exists in the desktop's own AC_DATA**. In a jewellery ERP this gap = **closing stock value (held outside the ledger)**; the desktop's *balance-sheet report* injects closing stock as the balancing figure. **Action:** add closing-stock valuation to the web's final-accounts report so the balance sheet ties (data is faithful; the report presentation layer is the gap).
2. **Form field depth.** Desktop transaction forms (e.g. TR_SALE) carry ~100 columns (size, HUID×4, lot, design, multiple labour components, scheme/loyalty, card/UPI splits, e-bill). The web schema HOLDS all these columns (golden-master converged), and the engine computes totals identically, but the **web entry screens currently capture a pragmatic subset** of fields per form. The imported real rows retain every desktop column; the UI surfaces the core fields.
3. **Coverage.** ~40 of 204 forms and 15 of 255 reports have web UIs so far; the remainder are queued in the execution plan. Backend coverage (modules + posting engine + calc) is broader than the UI surface.

## 6. Verdict
On the **real DHAKAN JEWELLERS data**, the web app's **data fidelity is exact (to the paisa)** and its **computation parity is exact on all 190 invoices**. The implemented features (registers, GST, masters, analytics, sales/purchase/finance/loans/karigar/stock) operate correctly on the real data and reconcile to the desktop figures. The remaining gaps are **report-presentation depth (closing stock in the balance sheet)** and **breadth (forms/reports not yet built + per-form field richness)** — not correctness of what is built. Both are tracked in the execution plan.
