# DESKTOP ⟷ WEB — DETAILED PARITY VERIFICATION (2026-07-13)

Ground truth for the **actual desktop app** = the video-research knowledge base (`datacare-desktop-kb`, built from screen recordings) + the mined per-form behavior catalogs (`catalogs/form-behavior/*.behavior.json`: grid schema, inline SQL, keyboard, calc, validations). Compared against the **actual web code** (`web/apps/{web,api}`). Three independent auditor passes (`vdw-sales.md`, `vdw-purchase-karigar.md`, `vdw-masters-reports.md`) + a main-agent spot-verification of the top finding.

## 0. Bug fixed this session
**React "two children with the same key `00024`"** — `recentVouchers` selected every `SL_DATA` row, but the header table holds several rows per voucher (party leg + tax + old-gold share one `VCH_NO`), so `<VoucherList>` rendered duplicate rows/keys. **Fix:** query now `DISTINCT ON ("VCH_NO")` picking the representative row (matches the desktop voucher navigator = one row per voucher) + row key hardened with index. Verified: book 032 now 50 rows / 50 distinct / 0 dupes; browser console shows **no duplicate-key error** on sales/purchase/sale-return.

## 1. Headline
Web is **data- and ledger-faithful** (posting semantics strongly match, verified by tests + KB Appendix) but **UI-depth-thin** and has a **few edge calc/validation gaps**. Composite: posting ≈ Match; form depth + report fidelity = Partial.

## 2. SALES (`/txn/sales`, `sales/*.ts`) — verified
| Area | Verdict | Evidence |
|---|---|---|
| Ledger legs (Cr party / Dr income per-group SALE_AC / Cr GST out) | **Match** | `buildIncomeLegs` + live `GROUP_MAST.SALE_AC` query; `assertBalanced` |
| GST CGST/SGST/IGST split, round-off, TCS, kasar | **Match** | `gstSplit`, `billTotals` ROUND_HALF_UP |
| Old-gold-in (SL_PR_DETL + MAIN_STOCK MIXSL '+'), order-advance clamp + SL_ORD_ADJ | **Match** | createSale + satellite tables |
| Keyboard: F1-LOV, Enter-chaining, Ctrl+Enter save | **Match** | `LookupPicker.tsx:61`, `KeyboardNav.tsx`, mounted in `(app)/layout.tsx` |
| **Fine formula (fallback)** | **Gap** | desktop `(Net+Ght)×(Touch+West%)/100`; web `sales.ts lineFine` fallback = `net×touch/100` (correct formula exists in `rateCut.ts fine()` but isn't the main-path fallback) |
| Old-gold N/F rate-type toggle + melting%/touch-back-calc | **Gap** | desktop val "Select Rate type N/F"; web fine-wise only |
| Header/tender inputs: Apr No, Scheme Amt (+leg), Cash-Paid Amt, per-tender deposit-bank | **Gap** | web routes cheque/card/upi → single `BANK` |
| Sale-time validations: cheque/card-bank, employee-mandatory, defaulter party, out-of-year date, cash>₹2L PAN gate | **Gap** | createSale enforces party + non-empty lines + balance only |
| Per-line ItAmt/LbrAmt/TotAmt/Tax% columns + Pcs/Gross/Net totals row, Vch Desc, date time/weekday, print-copy picker | **Partial** | UI depth |

## 3. PURCHASE + KARIGAR — verified
| Area | Verdict | Evidence |
|---|---|---|
| Purchase ledger (Cr supplier / Dr PURCHASE per-group / Dr GSTINPUT), satellite tables, tags-in | **Match** | `purchase.ts`; KB §6.4 |
| Karigar issue/receipt metal ledger (Dr/Cr Gold), labour payable, balanced | **Match** | `karigar.ts`; `karigar.test.ts` |
| **Purchase line fine** | **Gap** | same `net×touch/100` fallback — omits West%/OthWt; no stone-detail box |
| **"Only Tag Entry" barcoding on purchase** | **Gap** | web creates 1 tag/line; no lot→multi-tag grid (Counter/Design/Size/Mrp/PrCost/KrCode) + no QR-916 label |
| **Karigar Receipt settlement** | **Gap** | `receiveKarigar` only credits karigar A/c; no Cheque/Card/Cash/Kasar/Os tender + RojMel/bank leg |
| Karigar stock-IN KR_* making-cost cols (KR_NWT/TOUCH/WEST/FINE/LBR_AMT/OTH_AMT/COST) | **Gap** | making cost not carried into valuation |
| Karigar/purchase voucher chrome (Vch No/Date/time, Ref, Bank, Employe, <> nav, print copies) + party F1 inline-create | **Partial/Gap** | form-chrome thin |

## 4. MASTERS + REPORTS — verified
| Area | Verdict | Evidence |
|---|---|---|
| Item master fields (20/20), Product, opening balance (Amt/Gold/Silver Cr/Dr), Photo, Family | **Match** | `ITEM_MAST_CONFIG`, party page tabs |
| Party fields | **Partial** | 38/40 match; **State picker (STATE_MAST) + L_BR_DATE/BANK_DETL** gaps |
| Party page split-brain | **Gap** | `/masters/party` (Photo/Family/Opening tabs) edits ~5 fields; full 40-field set only in `/masters/customers` which lacks those tabs + the desktop's 3 named tabs |
| Group master validation | **Partial** | mandatory Sales+Purchase A/c not enforced |
| **Ledger report metal columns** | **Gap (critical)** | desktop RP_LEDR is tri-currency (gold/silver fine Dr/Cr/Bal); web `accountLedger` amount-only |
| **Item-wise Stock movement matrix** | **Gap** | desktop Opening/Purchase/In/Out/Sale/Closing pcs+wt + Group/Product/Design/Safe/Table tabs + filters; web = snapshot valuation + coarse itemStockLedger |
| Ledger aging buckets, contra/BillNo/BookName/Remark cols, party-scope filters | **Gap** | — |
| GSTR-1 | **Partial** | built from SL_DATA with IT_CODE as HSN proxy (no HSN master), no reverse-charge, no credit/debit-note section |

## 5. Prioritized fixes (verified, actionable)
**Calc/posting (need explicit sign-off — touches the posting engine):**
1. **Fine-weight fallback** — make `sales.ts`/`purchase.ts`/`salesOrder.ts` `lineFine` use `(net+ght)×(touch+west)/100` (reuse `rateCut.ts fine()`), matching desktop `val[,20]`. Mis-prices wastage/ghat lines today.
2. Karigar stock-IN KR_* making-cost columns; karigar-receipt tender settlement leg.

**UI depth (no posting risk):**
3. Ledger report → add gold/silver fine Dr/Cr/Bal columns (tri-currency) — highest-value report gap.
4. Item-wise stock movement matrix report (Opening→Closing pcs+wt).
5. Unify Party into one page: full 40 fields + the 3 desktop tabs + State picker + Photo/Family/Opening.
6. Sales UI: per-line amount/tax columns + totals row; header Vch Desc + date time/weekday; per-tender deposit-bank.
7. Sale-time validations (employee-mandatory, cash>₹2L PAN gate, out-of-year date, cheque/card-bank).
8. Purchase "Only Tag Entry" lot→multi-tag barcoding + QR-916 label.

## 6. Verification status
api build 0 · web typecheck 0 · vitest **180 passed (38 files)** · demo intact · duplicate-key error resolved. Per-module detail: `vdw-sales.md`, `vdw-purchase-karigar.md`, `vdw-masters-reports.md`.
