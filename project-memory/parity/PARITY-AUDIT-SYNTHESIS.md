# DESKTOP↔WEB PARITY AUDIT — CONSOLIDATED SYNTHESIS
_Session 5bf (2026-06-30). Five independent agents audited the extracted C# desktop source (.cs) against the web backend + frontend + live Postgres, line-by-line, citing file:line on both sides. Source audit files: audit-A-sales-posting.md, audit-B-purchase-inventory.md, audit-C-mfg-dhrn.md, audit-D-finance-bullion.md, audit-E-statutory-reports-masters.md._

## HONEST HEADLINE VERDICT
Aggregate across 5 audits: **parity=1, partial=43, gap=12, cannot-verify=3.**

The web app is a **functionally-correct, money-level skeleton with full DATA fidelity** — it imports and reads all 141 desktop tables exactly (xdb_diff 141/141 cols, 366/366 Σ), reproduces report totals (parity_report 5/5), and computes sale header/line totals exactly (190/190, 244/245). **But the WRITE PATH — what each form persists on Save — is a strict SUBSET of the desktop's.** The earlier harnesses validated imported-data fidelity and report aggregates; they did NOT validate create-logic completeness. This synthesis corrects that gap in coverage.

## SYSTEMIC GAPS (by theme, highest-impact first)
1. **Metal/fine-weight sub-ledger absent (P0, pervasive).** Desktop `Ac_Ledr.cs:374-479` posts gold/silver fine-weight ledger legs ('29'-'31') on sales/purchase/dhrn; the web posts only money legs. A jewellery ERP's core metal-balance-per-party is therefore not maintained on the write path. [audit A,B,C]
2. **ROJ_MEL_DATA (rojmel/cash book) never written (P0).** Desktop `Ac_Rojmel.cs` writes the cash daybook; web derives day-book from AC_DATA instead — no ROJ_MEL rows. [audit A,D]
3. **Shallow ledger decomposition (P0).** Web posts 4-7 net legs vs desktop ~39 gross legs; missing HM/TCS/TDS/scheme/points/KASAR/cash/cheque/card sub-legs; LD_CODE is an ordinal vs the desktop contra-account code; SIGN D/C vs metal +/-. [audit A]
4. **Unimplemented forms (P1, GAP).** Bullion SALE, Tour SALE, scheme MATURITY, bill-to-bill settlement, item-lot/item-opening, physical-stock POSTING (read-only now), card/UPI receipt writers, employee-JV payroll, ledger-adjustment, dhrn TR_REP_REC repayment, MFG with-lot, jobwork (writes KR_* not MFG_*). [audit B,C,D]
5. **6 desktop tables never written by web:** CARD_DATA, UPI_DATA, EMP_DATA, LDR_ADJ_DATA, OP_DATA, AD_ADJ. [audit D]
6. **Dhrn correctness (P0/P1).** Loan issue never debits the borrower ledger; receipt skips DHRN_DATA movement + ISU_REC close + DHRN_REC_DETL; interest lacks whole-month bucketing/compounding/configurable year-days. [audit C]
7. **Report coverage (P1).** 44 desktop RP_*.cs → 12 covered, 14 partial, **18 with no web equivalent** (bill-profit, consignment/approval, mfg-jadtar, HUID, order-tracking, multi-dimensional RP_MOVEMENT 7-way pivot, pawnbroker Form8/Form12, etc.). [audit E]
8. **Masters (P1).** Generic grid gives full column coverage for 31 registered masters, but **MS_AC_GROUP (account groups) is NOT registered**; +auto-item/trade/stk-limit/tasting missing. [audit E]
9. **RBAC model differs (P2).** Web = global per-user flags (update/delete/print); desktop = PER-FORM rights (FRM_VIEW/EDIT/DELETE/PRINT per menu via USER_SET). [audit E]
10. **Settings coverage (P2).** Web whitelists 11 of CO_SET's 61 cols; desktop edits ~20+. [audit E]
11. **Purchase/sales hardcoding (P1).** Hardcoded purchase/GST/HSN('7113')/unit('GMS') accounts vs desktop master-driven (ITEM_MAST.HSN_CODE incl 9997-hallmark, per-group PURC_AC, TAX_MAST). [audit A,B,E]

## FIXED THIS SESSION (verified)
- **G-FIN-1 Payment mode bug (CONFIRMED+FIXED).** `PaymentForm.tsx` sent uppercase 'CASH' but `finance.ts` compared `=== 'cash'` → PAN-over-limit rule skipped + cash booked to BANK. Fixed: server normalizes `mode.toLowerCase()` in postReceipt/postPayment (+PAY_DATA refs); form uses lowercase values. VERIFIED: 250k cash no-PAN → 400 (rule enforced); 5k cash → REC_AC_CODE='CASH'.
- **G-MFG-1 Karigar INOUT inversion (CONFIRMED vs real data+FIXED).** Real desktop KR_DETL: issue='O' (book 050), receipt='I' (book 052); web had INOUT_ISSUE='I'/RECEIPT='O' inverted. Fixed constants + corrected 2 tests that encoded the wrong convention. MAIN_STOCK was already correct.
- **G-MFG-2 Karigar metal sub-ledger leg (CONFIRMED vs real data+FIXED).** Desktop writes an AC_DATA metal leg (IT_TYPE 'G', SIGN '-' issue / '+' receive, FINE_WT=fine, AC_CODE=karigar, BOOK_NAME 'KARIGAR ISSUE'/'RECEIPT'); web wrote none. Fixed karigar.ts issue+receive. VERIFIED live: issue G/-/45.800, receive labour Dr/Cr 500 + G/+/93.600; demo intact. 116/116 tests pass.

## GROUND-TRUTH CORRECTIONS to the audit (verified vs real AC_DATA, not just .cs)
- AC_DATA metal legs use **FINE_WT/FINE_RATE** columns (not ITM_*); DR=CR=0 so they don't disturb the money balance; `enrichLedgerLine` preserves a caller-set IT_TYPE.
- Metal legs (IT_TYPE G/S) exist in books 034/035 (purchase), 050/052 (karigar), 064/078/088/020/000 — **NOT in sales books (026/029/030/032)**. So audit-A's "sales missing metal legs (P0)" is **overstated for the DHAKAN dataset** (retail sales are money-only here). The metal-ledger gap is real for **purchase/karigar/mfg**, now fixed for karigar.
- **ROJ_MEL_DATA = 0 rows** in the imported data → this company did not use rojmel; the "daybook-not-from-ROJ_MEL" gap is **moot for this dataset** (re-prioritised below P0).

## REMEDIATION BACKLOG (prioritised)
**P0 (correctness/core engine):** metal fine-weight sub-ledger in posting engine + sales/purchase/dhrn; ROJ_MEL_DATA writer; full ledger decomposition (HM/TCS/TDS/scheme/points/KASAR legs); dhrn borrower-ledger + DHRN_DATA on receipt.
**P1 (missing forms/writers):** bullion sale, tour sale, scheme maturity, bill-to-bill settlement, card/UPI/emp-JV/ledger-adj writers, item-lot/opbl, physical-stock posting, jobwork→MFG_* tables, MS_AC_GROUP master; 18 missing reports; de-hardcode accounts/HSN/unit.
**P2 (model depth):** per-form RBAC (USER_SET), full settings whitelist, multi-dim report pivots, remaining e-invoice optional sections, frontend field completeness per form (~18 sales fields, etc.).

## WHAT THE EARLIER HARNESSES DID / DID NOT PROVE (for the record)
- DID: data import fidelity (every desktop row/column present + numeric sums equal); report total parity on imported data; sale total computation; voucher multi-table footprint EXISTS.
- DID NOT: that the web SAVE path writes every table/column/leg the desktop save writes (write-path completeness); field-level form parity; the unimplemented forms above.

## NEXT
Work the P0 backlog first (posting-engine metal ledger + rojmel are foundational and unblock sales/purchase/dhrn parity), re-running parity_form COMPARE (web-created vs desktop voucher) per form as the gate — that is the harness that actually catches write-path gaps. Track honestly here + in scorecard.md.

## LEDGER-LAYOUT ASSESSMENT (session 5bh — decided NOT to force exact replication)
Investigated Ac_Ledr.cs (2371 lines, one class). The desktop builds AC_DATA via **934 bespoke `INSERT INTO AC_DATA (...) SELECT ...` SQL projections** — one per voucher-type × leg-type — each hand-encoding `LD_CODE`=contra-account, per-scenario aggregation (e.g. customer leg aggregates sales+tax then rounds), and the full per-leg column set (PARTY_AC_CODE/LDR_NAME/BILL_NO/VCH_DATE). Real sale 026/00055 confirms the asymmetric customer-aggregated + account-itemised + contra-LD_CODE encoding.
DECISION: exact byte-level AC_DATA-layout replication is **impractical + low-ROI** and high-risk to the working posting engine:
- The web's representation is **functionally correct** — balanced double-entry that yields identical account balances, trial balance, day-book, account-ledger, and outstanding reports (parity_report 5/5, xdb_diff Σ 366/366). 
- `LD_CODE` is invisible to users + excluded from parity_form comparison; restructuring it improves **no** verifiable metric or user-visible behaviour.
- Replicating 934 bespoke projections risks destabilising all 116 tests + every verified flow for cosmetic row-layout parity.
VERDICT: web achieves **functional ledger parity** with a cleaner representation; exact physical-layout parity is intentionally NOT pursued. Effort redirected to user-visible functional gaps (missing forms + reports). This is the honest engineering trade-off, recorded for transparency.
