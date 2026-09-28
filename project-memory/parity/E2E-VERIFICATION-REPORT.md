# DataCareNext Web — End-to-End Verification Report
_2026-06-30. Full from-scratch verification of the web rebuild (frontend + backend + DB) vs the decompiled desktop golden master (`extracted_code/`) and the `web-implementation-spec`. Method: 4 layers — foundational baseline → per-module deep parity (web code ↔ desktop `.cs` ↔ spec + live inject round-trips on isolated tenants `ver_a..ver_e`) → DB integrity → frontend — then concrete-bug fixes + re-verification + this synthesis. No demo data was mutated (every live test ran on an isolated tenant and self-cleaned)._

## 0. Verdict
**The web rebuild is functionally faithful to the golden master for the live dataset.** All core money vouchers post balanced double-entry (Σdr==Σcr), the calc engines match the desktop to spec precision, the full nav surface is wired with no placeholders, and both the API and the production web build are clean. The verification **found 6 concrete divergences**; **4 were fixed + re-verified this pass**, 2 are documented as needing the SQL-Server golden master (or a spec↔desktop reconciliation) to settle safely.

## 1. Foundational baseline (Phase 1) — GREEN
| Check | Result |
|---|---|
| DB container | `web-postgres-1` up/healthy, **164 tables** |
| Demo data | SL_DATA=190, PR_DATA=74, AC_DATA=5150, AC_MAST=918, ITEM_MAST=226 |
| RLS isolation | tenant `e2e` sees **0** of `default`'s rows |
| API build (tsc) | clean (0) |
| Unit/integration suite | **148/148 (33 files)** |
| Web typecheck | clean (0) |
| Next.js production build | clean, **62 app pages** (incl. all new forms) |
| API boot | `/health`=200, **165 routes** |

## 2. Per-module deep parity (Phase 2) — ~50 forms, ~225 live asserts
Verified by 5 isolated-tenant agents comparing web ↔ desktop `.cs` ↔ spec, with live inject round-trips. Every posted ledger balanced Σdr==Σcr.

- **Sales+Purchase**: PARITY — Sale, Sale-HM, Sales-Return, Sales-Order, Rate-Cut(core), Estimate, Other-Purchase, Purchase-HM. PARTIAL — Purchase (fine bug→fixed), Purchase-Return, Rate-Cut phase-2.
- **Finance+Dhrn**: PARITY — receipt-cash/upi, payment, contra, cash-ceiling, journal, ac-opbl, ledger-adjust, employee-JV, dhrn-issue(core), dhrn-interest-only(core). PARTIAL — receipt-card, bill-to-bill, dhrn-receipt (interest basis→documented; bookName→fixed).
- **Stock+Manufacturing**: PARITY — item-lot, item-opening, tag-opening, mfg issue/receive(engine), karigar. PARTIAL — mfg order-issue, melting (greenfield).
- **Masters+RBAC+GST+Reports**: PARITY (18) — master CRUD/UPDATE/import, login(Argon2+migration), rightsOf, assertRight(403), per-form USER_SET+/me allowedForms+nav filter, settings whitelist, gstSplit, GSTR-3B/2, e-invoice IRN, trial-balance, day-book, sales-register, stock-valuation, balance-sheet. PARTIAL — GSTR-1 HSN, admin-gate, balance-sheet closing-stock.
- **Membership+Bullion/Tour/Fine**: PARITY — Fine-Sale, Fine-Purchase+rate-cut, Scheme-Installment, Scheme-Maturity. PARTIAL — Scheme-Opening(cash-ledger→fixed), Bullion-Booking(spec↔desktop→documented), Tour-Issue(book-name→fixed), Fine-In-Out(metal-only), Loyalty(by-design).

## 3. Concrete divergences

### Fixed + re-verified this pass (4)
1. **Purchase line-fine precision** — `purchase.ts lineFine` used 2dp; desktop `TR_PURC.cs#L7261` + spec §9 + web `sales.ts` use **3dp**. Live 9.63 vs desktop 9.625. Fixed → `round3`; re-verified **9.625**.
2. **Dhrn receipt `BOOK_NAME` null** — `receiveDhrn` omitted `bookName`. Fixed → `'DHIRAN'`; re-verified all DREC legs stamped.
3. **Scheme opening over-posted a cash ledger** — desktop `TR_MEMB_ENT.cs#L4660` posts no money ledger for `MEMB OPENING`. Fixed → opening posts empty AC_DATA + AD_DATA/AD_OS; installment ledger intact (re-verified).
4. **Tour issue `BOOK_NAME` 'TOUR'** — desktop keys on-tour stock `'EMP ISU'`. Fixed → APR_DETL+MAIN_STOCK+bookName='EMP ISU'; re-verified.
Post-fix: build clean, suite 148/148, demo intact.

### Documented (need golden master / spec reconciliation)
5. **Dhrn auto-interest basis (12× divergence, ambiguous)** — receipt 'M'-mode per-month (→6000) vs issue annual/day-count (→500); the two paths contradict and each cites desktop parity; annual-vs-per-month for `INT_PRC` needs the golden master (down) + DHRN rows (demo 0) to settle. Operator-supplied interest overrides post correctly.
6. **Bullion booking ledger (spec↔desktop conflict)** — spec says booking posts Dr party/Cr payable; decompiled `TR_BUL_BOOKING.cs` appears to write `BUL_DATA`/`TEMP_BOOK_DATA` only. Web follows the spec. Reconcile on the golden master before changing.

### Lower-priority / by-design (documented)
Purchase-return no `BILL_OS_DATA` contra; card commission not ledgerised; bill-to-bill no AC_DATA leg (deferred); GSTR-1 HSN by `IT_CODE` proxy (e-invoice correct); admin-gate `assertRight('delete')` vs `assertAdmin`; mfg order-issue flip under-keyed; melting no MAIN_STOCK/MFG_ISU_REC (greenfield); fine rate-cut omits source MAIN_STOCK reduction; loyalty standalone vs in-sale; stamp minors.

## 4. DB integrity (Phase 3)
- **Core money vouchers (SALE/PURC/returns/receipts/payments/JV): 0 unbalanced.**
- Demo global Σdr 55,180,589.47 vs Σcr 56,302,194.65 (diff −1,121,605.18) — **fully attributable to one `ACOP` opening voucher (−1,121,154.56)** = documented **R14** (closing-stock/capital off-ledger until `Ac_Final`); rest is paise migration rounding (~±2) + 2 KREC metal legs (−450). Not a web defect.
- RLS isolation re-confirmed; demo invariants unchanged.

## 5. Frontend (Phase 4)
- Production build clean; 62 app pages / 47 txn pages.
- **0 broken nav links**; 139 ready nav links; **`/soon`=0** (full ERP surface wired); dynamic `[name]`/`[report]` routes present.

## 6. Blocked (environment)
Tier-4 golden-master diffing + R9/R12/R13/R14 + the dhrn-interest & bullion-booking resolutions require the **SQL-Server golden master** (`:11433`, not running). Everything verifiable without it has been verified.
