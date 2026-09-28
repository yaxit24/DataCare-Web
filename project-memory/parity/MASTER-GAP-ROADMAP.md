# MASTER PARITY GAP ROADMAP — desktop (.cs) ↔ web

Synthesis of the deep code-level analysis (3 parallel agents read the actual 969k-line desktop C#). Detail in `gap-core-sales.md`, `gap-inventory-mfg.md`, `gap-finance-loans.md`.

## CRITICAL RECONCILIATION (verified against real DHAKAN data)
The desktop is a large SUPERSET. The agents measured web vs the desktop's full *capability* (~10%). But DHAKAN's actual saved data uses a SUBSET the web largely matches for the financial spine:
- AC_DATA fine-weight (IT_TYPE G/S) is on only **175/5150 rows — almost all ACOP opening balances**; transactional sale/purchase legs are IT_TYPE 'A' (money) = what the web posts. ✓ spine matches.
- ROJ_MEL_DATA = 0 rows for DHAKAN (rojmel not used here).
- Most bills: no TCS/TDS/scheme/points/multi-payment (those legs are optional desktop features DHAKAN rarely uses).
So the REAL user-felt gaps are: (A) FORM ENTRY richness (lookups, rate auto-fetch, item/tag autofill, keyboard flow), (B) BREADTH of distinct forms, (C) stock-movement detail fidelity, (D) a few real workflows (Dhrn collateral+interest, real MFG, tag split/wt-diff).

## STATUS BY PRIORITY
### DONE this session
- Sale & Purchase: weight-based entry forms (item/tag/pcs/gross/net/touch/rate/making + live totals).
- Sale settlement: payment-split (cash/card/upi/cheque) + old-gold exchange → ledger + SL_PR_DETL + MAIN_STOCK '+'; BILL_OS/REC_AMT. (independently audited 6/6).
- MAIN_STOCK movement now full-detail (ITM_GWT/NWT/TOUCH/FINE/RATE/AMT/LBR/NET) on sale/purchase/karigar/tag-opening. ✓ verified.
- Sales Order: weight-based lines + SL_ORD_DETL/IDTL footprint.
- Tag Opening (TR_TAG_OPBL): full BAR_DATA/DETL/IDTL/MAIN_STOCK + frontend.
- Karigar MAIN_STOCK (TR_TYPE O/I), stock unified on BAR_DETL (real inventory sellable), bill-wise outstanding + old-gold reports, XDB 372/372 Σ cert.

### P1 — FORM RICHNESS (biggest user-felt gap; A)
- [ ] Master LOOKUP pickers (customer/item/account/tag) — type-ahead from masters instead of raw codes. Reusable component.
- [ ] Rate auto-fetch from RATE_MAST by date+group; customer master autofill (name/GST type/balance).
- [ ] Item/tag/barcode scan → autofill line (weight/touch/rate/MRP from BAR_DETL/ITEM_MAST).
- [ ] Wastage % (ITM_WEST_PRC) field in sale/purchase fine calc.

### P2 — BREADTH (verified-distinct forms; B,D)
- [ ] Tag Split (TR_TAG_SPLIT) — split one tag into many; no web code yet.
- [ ] Tag Weight-Diff (TR_TAG_WT_DIFF) — reconcile tag vs actual weight; none.
- [ ] Real Manufacturing (MFG_DATA/DETL/IDTL/MFG_ISU_REC, process stages IR_TYPE, lots ITM_LOT, ghat/loss/chol/ghis reconciliation) — web aliases karigar; build distinct mfg.ts.
- [ ] Dhrn (pledge): DHRN_ISU_DETL collateral grid + DHRN_DATA movement + server-side interest (P×rate/100×days÷yearDays) + interest-only receipt + renewal. Web is header-only. (0 demo data → verify by round-trip.)
- [ ] Sales-order FRONTEND line grid (backend done).
- [ ] Shallow forms → weight grid: hallmark-sale, wholesale-sale, estimate, sale-return.

### P3 — DEPTH/COMPLIANCE (mostly optional for DHAKAN; verify usage first)
- [ ] GST from customer master state + per-item HSN/slab (vs single manual %).
- [ ] TCS/TDS, scheme redemption, loyalty points legs (only if data shows usage).
- [ ] e-Invoice/IRN UI (TR_SL_EBILL), WhatsApp/SMS send on save.
- [ ] Period locks / edit-rights / voucher-collision guards / re-save (edit) vouchers.
- [ ] Receipt/Payment multi-party grid + cheque/KASAR/bank-charges; unify PAY_DATA↔CASH_DATA.

## PRINCIPLE
Verify each desktop feature's ACTUAL usage in real data before prioritizing; the desktop code shows capability, the data shows what's used. Implement verifiable-against-data first.
