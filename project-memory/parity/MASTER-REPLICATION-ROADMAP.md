# MASTER END-TO-END REPLICATION ROADMAP — DataCareNext desktop → web
_Synthesis of the full coverage matrix (`coverage-matrix.json`) + 7 module audits (`vdw-*.md`) + DB parity (`DB-PARITY-REPORT.md`) + the behavior catalogs. Date 2026-07-14._

## 0. Executive summary
Three independent axes, measured separately:
- **DB schema parity — 100%.** Web now has all 146/146 desktop tables + every column (see DB-PARITY-REPORT). No procs/views/triggers exist in the desktop DB (logic is all in code, extracted).
- **Posting / ledger semantics — strong (≈Match).** Every audited module's double-entry legs, GST split, stock signs and satellite tables match the desktop, verified by tests + the KB Appendix. This is the hard part and it is largely done.
- **Experience depth (form fields, grids, edge calc, niche workflows, print) — the real gap.** Breadth is high (131 of 161 UI forms surfaced) but per-screen depth lags.

**Form breadth (coverage-matrix.json, 161 UI forms):**
| Module | Total | Web PAGE | Report-SPEC | Missing |
|---|--:|--:|--:|--:|
| Transaction | 61 | 50 | – | 11 |
| Master | 33 | 26 | – | 7 |
| Report | 45 | 15 | 30 | 0 |
| Utility | 22 | 10 | – | 12 |
| **Total** | **161** | **101** | **30** | **30** |

## 1. Cross-cutting systemic gaps (fix once → benefits many) — HIGHEST LEVERAGE
1. **Fine-weight formula.** Desktop line fine = `(NetWt + GhtWt) × (Touch + West%) / 100`. The web's main fallbacks (`sales.ts`/`purchase.ts`/`salesOrder.ts` `lineFine`, dhrn, tag-opening, tag-split, mfg UI preview) use the simplified `net × touch / 100`. The correct formula already exists (`rateCut.ts fine()`, `manufacturing/mfg.ts fineWithGhat`, `karigar.ts fineWithWastage`, and tag-transfer/stock-adjust use +West). **→ Route every fine calc through one shared `fine(net,ght,touch,west)` helper.** [POSTING — needs sign-off]
2. **Voucher chrome.** Desktop txn screens have Vch No(+F1)/Vch Date(+time+weekday)/Ref No/Employe/Bank/Vch Desc/◀▶ navigation/Original-Duplicate-Triplicate print picker. Web txn pages are form-only. **→ One shared `<VoucherChrome>` + `<VoucherNav>` reused by all txn screens.** [UI]
3. **Editable grid depth.** Desktop grids show per-line ItAmt/LbrAmt/TotAmt/Tax% + a Pcs/Gross/Net/Fine totals row + F1 in-cell LOV. Web grids are thinner. **→ One `<ItemGrid>` with computed columns + totals row.** [UI]
4. **Tri-currency ledger + stock reports.** Desktop `RP_LEDR` shows gold/silver fine Dr/Cr/Bal alongside amount; `RP_STOCK` shows Opening→Purchase→In→Out→Sale→Closing (pcs+wt) with Group/Product/Design/Counter + Tag-wise tabs. Web ledger is amount-only; stock is a snapshot. **→ Add metal columns + the movement matrix.** [UI/report]
5. **Tender panel depth.** Per-tender deposit-bank selection (cheque/card/UPI → specific bank book), Kasar, Scheme Amt (+ledger leg), Cash-Paid, Apr No. Web routes all tenders to a single 'BANK'. [POSTING-adjacent — sign-off]
6. **Barcoding / QR + label fidelity.** Tag print has Code39 SVG + HUID (good) but no QR and no firm/group/LC-LP/HM-RD label lines; purchase/mfg lack "Only Tag Entry" lot→multi-tag barcoding. [UI]

## 2. Per-module gap digest (from the 7 audits)
- **Sales** (`vdw-sales.md`): posting Match; gaps = fine formula, old-gold N/F rate-type + melting-back-calc, Apr/Scheme/Cash-paid inputs, sale-time validations (PAN>₹2L, employee-mandatory, out-of-year, cheque/card-bank).
- **Purchase+Karigar** (`vdw-purchase-karigar.md`): posting Match; gaps = purchase fine wastage, "Only Tag Entry" barcoding, karigar-receipt tender settlement, karigar stock-IN KR_* making-cost columns, voucher chrome.
- **Masters+Reports** (`vdw-masters-reports.md`): Item/Product Match; gaps = Party split-brain (unify 40 fields + 3 tabs + State/Country picker), ledger metal columns, item-wise stock movement, GSTR-1 HSN (reads IT_CODE not ITEM_MAST.HSN_CODE — now present in DB).
- **Dhrn+Scheme+Loyalty** (`vdw-dhrn-scheme-loyalty.md`): issue/interest Match; gaps = compound interest, rate-cut→fine on receipt, collateral release + renewal, scheme gold-conversion + maturity gold-valuation + redeem-to-bill, loyalty accrual engine not wired to sales.
- **Mfg+Stock+Tags** (`vdw-mfg-stock-tags.md`): `/mfg/*` engine faithful; gaps = mfg pages thin (no lot/design/counter/diamond/per-line-labour, no finished-piece barcoding), **melting moves no inventory** (biggest data gap), no mfg-order-receive, jobwork is the toy 4-col karigar not TR_MFG_KR, physical-stock read-only.
- **Finance+RateCut+Bullion** (`vdw-finance-ratecut.md`): receipt/payment/journal/fine-JV/bill-to-bill/bank-recon Match; gaps = contra + ledger-adjust lack metal legs, rate-cut fixing loop not closed on `/txn/rate-cut`, bullion booking drops premium/tax/rate-basis, estimate/approval can't convert to sale, employee-JV lacks attendance/%.
- **Statutory+Utilities** (`vdw-statutory-utilities.md`): e-invoice core + year-end + voucher-renumber Match; gaps = GSTR HSN/ITC/reverse-charge/portal-JSON, e-invoice Dispatch/Ship/Export/eWay/Cess blocks, **wholesale drops all TR_WH_SALE machinery** (per-party touch memory, rate-cut, vepari sub-grid, profit), tour-sale on-tour billing, backup .bak, messaging campaign UI, import/export/webcam missing.

## 3. Missing forms (30) — by priority
- **Build (real features):** TR_REP_REC (repairing receive), TR_JDT_REC (consignment/jadtar), TR_SL_EBILL (e-bill), TR_OTH_COMM (commission), TR_PR_SL_HEDG (hedging), MS_GOLD_MAST (gold-rate master), MS_DESIGN_BOOK (design catalog + scale), MS_STK_LIMIT (stock limits), UT_IMPORT/UT_EXPORT (data migration), UT_SMS/UT_WHATSAPP/UT_WAPP_WITH_API (bulk-messaging UI), UT_WEB_CAM (photo capture).
- **Lower priority / internal / chrome:** TR_VP/TR_VP_ADJ (voucher-posting internals), TR_GOLD_BOOK, TR_LOCT_AMT, TR_SL_PR_ITEM, TR_FINE_SL_PR, MS_BOOKLIST, MS_HELP, MS_TASTING, MS_WINDOW_SET, UT_HDD/UT_WINDOW/UT_SET_ADMIN/UT_CUST_ENTRY/UT_USER_REQUEST/UT_AI_TRFR.

## 4. Phased roadmap (prioritized)
**Phase A — Systemic foundations (highest ROI).**
- A1 shared `fine(net,ght,touch,west)` everywhere [POSTING sign-off] · A2 `<VoucherChrome>`+`<VoucherNav>` · A3 `<ItemGrid>` computed cols + totals · A4 tri-currency Ledger report + Stock movement matrix report · A5 Party unification (40 fields + 3 tabs + State/Country picker) + wire ITEM_MAST.HSN_CODE into GSTR-1.

**Phase B — Module depth.** Dhrn compound/rate-cut/collateral/renewal · Scheme gold-conversion + maturity + redeem-to-bill · Melting inventory legs (MAIN_STOCK + avg-touch + loss) · Wholesale machinery (touch memory + rate-cut + vepari + profit) · Mfg page depth + finished-piece barcoding + mfg-order-receive · Tender panel depth + per-tender bank [POSTING sign-off] · Karigar receipt settlement + KR_* stock columns [POSTING sign-off].

**Phase C — Missing feature forms.** Repairing, consignment, e-bill, gold-rate master, design-book (+scale), import/export.

**Phase D — Integrations + shell.** Messaging campaign UI (+MSG_MAST), webcam capture, QR + full label lines, print-template picker, GSTR ITC/reverse-charge + portal JSON, e-invoice extended blocks, DevExpress-like grid/LOV/tab shell.

_Every Phase-A/B item that recomputes fine, tenders, or stock legs is flagged **[POSTING sign-off]** — do not merge without confirming Σ Dr = Σ Cr on the isolated `e2e` tenant + demo intact._

## 5. Explicitly NOT gaps (verified Match — do not redo)
DB schema (146/146); double-entry posting + GST split + stock signs across all modules; e-invoice IRN core (NIC v1.1 + GSP); year-end carry-forward; voucher-renumber; tag transfer/cancel/split/opening auto-number; labour dual-GST (3% metal + 5% labour); dhrn day-count interest; scheme installment↔maturity mirror ledger; mfg `/mfg/*` posting engine; keyboard F1-LOV + Enter-chaining + Ctrl+Enter save; most master field sets (Item 20/20, Company 25, etc.).
