# DataCareNext — Desktop → Web GAP ANALYSIS (Deep, Verified)

**Author:** independent verification pass
**Date:** 2026-07-27
**Desktop baseline:** VB.NET WinForms ERP — decompiled C# `unified/src/csharp/DataCareNext/*.cs` (212), original VB `DataCareNext_Source/Forms/*.vb` (44), form catalogs `project-memory/catalogs/forms/*.md` (206), real DB `catalogs/realdb-schema-full.json` (146 tables / 5,254 cols).
**Web target:** `web/` turborepo — Next.js 15.1.6 frontend (`apps/web`, ~90 pages), Fastify API (`apps/api`, 30 modules, 122 TS files, 252 routes), Prisma/Postgres (168 models), packages `core/db/types/parity/reports`.
**Supporting evidence files (this pass):** `project-memory/parity/gap-2026-07-27/{01-fine-formula, 02-txn-completeness, 03-uncertain-semantics, 04-reports-masters-ux}.md`.

> **How this report differs from the prior audit (`WEB-IMPLEMENTATION-AUDIT.md`, 2026-07-26).** That audit is high quality but **partly stale** — the code has advanced since. Every claim below was **re-verified against current source** with file:line citations. The headline result: **most of the prior "critical" data-integrity blockers (C1, C2, C3, C5, H1, H2, H3, H6) are now CLOSED in code.** The real remaining gaps have shifted to **calculation-formula divergence, whole classes of unimplemented forms/reports, report-print fidelity, and the total absence of desktop-comparison evidence.**

---

## 1. Executive summary & verdict

The web rebuild is a **genuinely substantial, buildable, mostly-sound reimplementation** of the desktop ERP's transactional core — not a scaffold. Its double-entry posting engine, voucher numbering, tenant isolation, period-lock, per-form RBAC, stock-movement model, and ~55 report dataset builders are real and internally consistent.

However, it is **not at exact functional parity and not production-certifiable for a live jewelry business**, for four structural reasons:

1. **Calculation divergence (correctness):** the web uses **one** universal fine-weight formula where the desktop uses **several workflow-specific** ones; monetary rounding is hardcoded where the desktop is per-company configurable. This silently produces **wrong weights/amounts** in specific flows (karigar-issue, old-gold purchase, item-opening/lot).
2. **Coverage gaps (missing behavior):** ~7 desktop transaction forms are **entirely unimplemented** (VP, VP-adjust, gold-book, bullion-sale, location-amount, tour-order, other-commission); several are **stubs** that don't post stock (physical-stock, melting) or lose engines (wholesale-sale); many implemented forms **omit satellite tables/sub-grids** (stones/diamonds, tender, day-book, re-tagging).
3. **Report/print fidelity (the biggest single gap):** the 255 Crystal reports are covered by **category-level dataset builders**, not 1:1; the per-`.rpt` binder **silently defaults unknown reports to SALES data**; the layout engine has **no images/barcodes/subreports/fonts/pagination/grouping/running-totals/suppression**; the formula evaluator handles only the simplest of ~5,991 formulas.
4. **Zero desktop-comparison evidence (the governance gap):** **0 of 204 forms and 0 of 255 reports** have a golden-data / visual / PDF comparison against the desktop. Frontend tests are near-absent; 3 DB-integration test files are skipped by default; 28 live integration scripts are outside CI. "It compiles and unit tests pass" ≠ "it behaves like the desktop."

**Verdict: NO-GO for exact-parity production.** Controlled demo on synthetic data is reasonable. The path to exact parity is now **well-scoped and finite** — see the roadmap in §13.

---

## 2. Verified build/test ground truth (my runs)

Environment: Node v20.20.2, pnpm 9.15.4, Docker `web-postgres-1` :5433 up.

| Gate | Command | Result |
|---|---|---|
| Typecheck | `pnpm typecheck` | **PASS** — 10/10 turbo tasks |
| Unit/builder tests | `pnpm test` | **PASS** — 252 passed, 15 skipped, 49 files (API) |
| Frontend build | `pnpm --filter @datacare/web build` (fresh `.next`) | **PASS** — all pages compiled + prerendered |
| Format | `pnpm format:check` | **PASS** (prior audit: 704 files failing — now fixed) |

Notes verified during this pass:
- The turbo-level `pnpm build` reports a **false failure** for `@datacare/web#build` (`ENOENT … build-manifest.json` during page-data collection). Re-running after `rm -rf .next` **succeeds cleanly** → this is a **stale turbo/.next cache artifact, not a source defect.**
- **3 DB-integration test files are skipped by default:** `transaction.integrity.db.test.ts`, `repairReceipt.db.test.ts`, `app.security.db.test.ts` — i.e. the tests that would exercise real posting/stock/reversal integrity are **not in the default run**.
- **28 `*.live.mjs` integration scripts** exist under `apps/api/integration` but are **not part of `pnpm test` or CI**.

---

## 3. Parity scorecard (six-gate model, re-verified)

Using the existing gate framing (extracted → understood → implemented → tested → **desktop_compared** → production_certified). Only `desktop_compared` counts toward a true parity %.

| Level | Extracted | Implemented (real) | Tested (unit) | Desktop-compared | Verdict |
|---|---|---|---|---|---|
| Forms (204) | ✅ 204 | 🟡 ~183 mapped, quality varies | 🟡 partial | ❌ **0** | Broad but uncertified |
| DB tables (146) | ✅ 146 | ✅ 168 (superset) | 🟡 16 | ❌ 0 | Schema parity done; behavior not |
| Reports (255) | ✅ 253 | 🟡 ~55 category builders + low-fi per-rpt engine | 🟡 1 | ❌ 0 | **Largest gap** |
| Business-logic invariants (25) | ✅ | 🟡 most, C4/rounding open | 🟡 | ❌ 0 | Mostly sound; formula gaps |
| Settings (57) | ✅ | 🟡 CO_SET partial | 🟡 2 | ❌ 0 | Rounding config unread |
| Keyboard/UX (13 shortcuts) | 🟡 | 🟡 ~4 | ❌ | ❌ 0 | Global F-keys missing |

**True parity % (desktop_compared) = 0%.** Engineering-breadth counts (pages/routes/models/tests) are progress, not parity.

---

## 4. Cross-cutting business-logic invariants — RE-ADJUDICATED vs current source

This is the most important section: the prior audit's critical/high findings, re-checked against **today's** code.

| Prior finding | Prior status | **Current status (verified)** | Evidence |
|---|---|---|---|
| **C1** loose/bulk stock not posted | CRITICAL open | ✅ **CLOSED** | Every txn builds `MAIN_STOCK` via `computed.map(...)` over **all** lines, `TAG_NO: tagNo ?? 'N'` — `sales.ts:564`, `purchase.ts:704`, `salesReturn.ts:437`, `purchaseReturn.ts:420`, `fineInout.ts:149`, `tour.ts:148`, `tagSplit.ts`, `fineSalePurchase.ts:273`, `karigar.ts`, `mfg.ts`. (The `.filter(c=>c.in.tagNo)` at `sales.ts:542` builds only the SL_IDTL tag sub-detail, not stock.) |
| **C2** reversal depends on client-sent tags | CRITICAL open | ✅ **CLOSED** | `deleteSale` derives tags from persisted `SL_DETL`, checks `BAR_DETL`, builds `legacyRestores` server-side, calls `reverseVoucherTx`; no client `tagRestores` param — `sales.ts deleteSale`. |
| **C3** numbering scope/concurrency mismatch | CRITICAL open | ✅ **CLOSED** | `nextVoucherNoTx` takes a **full-scope** `pg_advisory_xact_lock(hashtext('voucher\|'+scopeKey))` held to commit, then re-derives `MAX(VCH_NO)+1` per book/year from the book's header table (`BOOK_DATA.BOOK_TBL_NAME`, or a fallback union of full-identity voucher tables). `SRNO_MAST` is now used **only** for tag serials — `numbering.ts`. |
| **C5** active company/year/loc not authoritative | CRITICAL open | ✅ **CLOSED** | Scope derives from `scopeOfRequest` (session/`updateSessionScope`); routes use `scopeOf`/`readScope` off that, not client body — `app.ts:206`, `routes/txn.ts:283-299`. |
| **H1** per-form USER_SET rights not enforced | HIGH open | ✅ **CLOSED** | `rbac/formRights.ts`, `rbac/authorization.ts` (USER_SET by LC_CODE+USER_NAME+SUB_MENU, missing-row denial), `rbac/formCatalog.ts`, `routeAuthorized` + `assertRight` on mutations. |
| **H2** delete bypasses lock-date | HIGH open | ✅ **CLOSED** | `reverseVoucherTx` calls `assertPeriodOpen` from **persisted** VCH_DATE before any delete; config errors **fail closed** — `posting.ts`. |
| **H3** real-tag issue race | HIGH open | ✅ **MITIGATED** | `issueTagTx` uses `pg_advisory_xact_lock('tag-issue\|CO\|LC\|TAG_NO')` + `SELECT … FOR UPDATE` + delete — `stock.ts:156`. |
| **H4/H5** RLS/audit migration-owned | HIGH open | ✅ **CLOSED** (per addendum) | 5 versioned migrations replay to zero diff; RLS ENABLE+FORCE on all tenant tables; `/ready` role assertion. |
| **H6** plaintext-password migration | HIGH open | ✅ **CLOSED** (per addendum) | Password migration/reset + refresh rotation/revocation. |
| **H9** fake-PDF silent success | HIGH open | ✅ **CLOSED** (per addendum) | Chromium mandatory; renderer failure returns 503. |
| **C4** universal fine formula | CRITICAL open | ⚠️ **STILL OPEN (HIGH)** | See §5 — real per-workflow divergence, desktop-confirmed. |
| **H7/H8/H10** report/Crystal fidelity + comparison | HIGH open | ⚠️ **STILL OPEN (BLOCKER/HIGH)** | See §9. |

**Bottom line:** the transactional **integrity** blockers are resolved; the remaining correctness risk is in **formulas** (§5) and the remaining parity risk is in **coverage** (§6–8) and **reporting/print** (§9).

---

## 5. Fine-weight & money calculation parity (HIGH — correctness)

Web routes **all** fine through one helper: `shared/fine.ts` → `fineWt(net,ght,touch,west) = (net+ght)×(touch+west)/100`. The desktop is **not uniform**. Verified per-workflow against decompiled save-handlers:

| Workflow | Desktop formula (file:line) | Web | Verdict |
|---|---|---|---|
| Sale | `(Net+Ght)×(Touch+West)/100` — `TR_SALE.cs:10693` | same | ✅ EQUAL |
| Sales Order | same | `salesOrder.ts:76` | ✅ EQUAL |
| Purchase (std item) | `(Net+Ght)×(Touch+West)/100` — `TR_PURC.cs:9862` | same (but `purchase.ts:102` **comment** wrongly says `net×touch/100`) | ✅ EQUAL (doc bug) |
| **Purchase (old-gold/Kun)** | `(Net+Ght)×(Touch+West−LesTch)/100 + KunFine` — `TR_PURC.cs:7312` | no `−LesTch`/`+KunFine` terms | ❌ **DIVERGENT** |
| **Karigar Issue** | `(Net+Ght)×(Touch+West)/100 − LesWt` — `TR_KR_ISU.cs:3940` | drops `+Ght`, `West`, `−LesWt` | ❌ **DIVERGENT** |
| Karigar Receipt | `Net×(Touch+West)/100` — `MS_UPDATE.cs:2691` | `karigar.ts:47` | ✅ EQUAL |
| Melting | `Net×Touch/100` — `TR_MLT_PRO.cs:2832` | reduces correctly | ✅ EQUAL |
| Tag Opening | `(Net+Ght)×(Touch+West)/100` — `TR_TAG_OPBL.cs:6590` | same | ✅ EQUAL |
| **Item Opening (ITM_OPBL)** | `Net×(Touch+West)/100` **(no Ght)** — `TR_ITM_OPBL.cs:951` | `fineWt` **adds** ght — `stock.ts:692` | ❌ **DIVERGENT if ghtWt>0** |
| **Item Lot (ITM_LOT)** | `Net×(Touch+West)/100` **(no Ght)** — `TR_ITM_LOT.cs:2728` | adds ght / no dedicated module | ❌ **DIVERGENT if ghtWt>0** |
| Mfg Issue/Receive | `(Net+Ght)×(Touch+West)/100` — `TR_MFG_ISU_REC.cs:4159` | same | ✅ EQUAL |

**Rounding:**
- Fine/weight = 3 dp on both (`round3` / core `PRECISION.fine=3`) → ✅ EQUAL.
- **Monetary = DIVERGENT (MEDIUM).** Desktop reads per-company `CO_SET_NEW` rounding flags `TAX_ROF / LBR_ROF / ITM_RATE_ROF / TOT_AMT_ROF / PR_RATE_ROF` (`MS_OPNCOMP.cs:671-991`); web hardcodes 2 dp (`core/money.ts:7`) and reads none. A company configured for whole-rupee bill totals will see wrong totals/labour/tax.

**Remediation:** replace the single helper with a named per-workflow policy (`fineFor('karigarIssue'|'oldGoldPurchase'|'itemOpening'|…)`), add `LesWt/LesTch/KunFine` terms, and load rounding flags from `CO_SET_NEW`. Add golden-vector tests per workflow.

---

## 6. Form-level coverage (204 desktop forms)

Mapping classes (from re-verification, aligned to the parity matrix + this pass):

| Class | Count | Meaning |
|---|---|---|
| Dedicated (real module + UI) | ~38 | Ported behavior; quality varies (many with satellite gaps) |
| Variant-shared (several desktop forms → 1 web engine) | ~41 | e.g. sale variants reuse `sales.ts` |
| Conceptual-engine / report-engine | ~75 | Behavior absorbed by cross-cutting engine or generic report |
| Generic CRUD/report scaffold | ~29 | Metadata-driven only |
| **No current evidence / MISSING** | ~21 | No proven behavior |

**Transaction forms — completeness grades (25 checked, evidence `02-txn-completeness.md`):**
- **MISSING (0)** among the 25 core txn forms — all have *some* counterpart.
- **STUB / incomplete (HIGH):**
  - `TR_PHYSTK` — `physicalReconcile` (`stock.ts:325`) is **report-only; never posts a MAIN_STOCK/BAR_DETL adjustment**. Physical count cannot correct stock.
  - `TR_MLT_PRO` — `melting.ts` writes `MLT_DATA/MLT_DETL` only; **no `MAIN_STOCK`/`MFG_ISU_REC` movement** → melting doesn't move metal.
  - `TR_WH_SALE` — wholesale-sale UI posts a **plain `/sales`**; loses rate-cut / consignment / lot / APR engine.
  - `TR_SL_ORD_ADJ` — no standalone form; only implicit in `sales.ts adjustOrderIntoSaleTx`.
- **DEDICATED but with satellite/sub-grid gaps (HIGH/MED):**
  - `TR_PURC` missing `PR_IDTL` (stones/diamonds), `DM_DATA`, `ITM_LOT_DETL/LOT_DETL`.
  - `TR_SALE_RTN` no **re-tagging** of returned goods (`BAR_*`/`TAG_SET`), no `SL_IDTL`/`DM_DATA`.
  - `TR_TAG_WT_DIFF` simplified to a net-difference; drops labour/rate-cut/tax/full-replace.
  - `TR_KR_ISU` writes `KR_DATA/KR_DETL` instead of desktop `MFG_ISU_REC`; drops `DM_KR_DATA`.
  - `TR_MFG_ORD_ISU/REC` omit `APR_DATA/APR_DETL/APR_IDTL`.
  - Retail sale family (`TR_SALE`/HM/LBR/ORD) skips `CARD_DATA`/`UPI_DATA`/`ROJ_MEL_DATA`/`DM_DATA`/`POINT_*`.

---

## 7. Module-by-module gap summary

| Module | State | Key gaps |
|---|---|---|
| **Sales** (TR_SALE + variants) | Strong core | Loyalty POINT_DATA **not written** on sale (only reversed); no SL_IDTL stone grid; tender satellites (CARD/UPI/ROJ_MEL/DM) not persisted |
| **Purchase** (TR_PURC*) | Good | Old-gold fine formula divergent (§5); PR_IDTL/DM_DATA/lot missing |
| **Inventory/Tags** (TR_TAG_*, TR_PHYSTK, TR_ITM_LOT/OPBL) | Mixed | Physical-stock report-only; item-opening/lot fine adds ght wrongly; tag-weight-diff over-simplified |
| **Manufacturing/Karigar** (TR_MFG_*, TR_KR_ISU, TR_MLT_PRO) | Mixed | Karigar-issue fine divergent; melting posts no stock; MFG-order drops APR_*; KR uses wrong ledger table |
| **Finance/Cash-Bank** (TR_CASH/CONTRA/CARD/UPI) | ✅ Good | `TR_LOCT_AMT` missing |
| **Loans/Dhrn** (TR_DHRN_*) | Partial | Interest **simple-only** — no compound (CO_SET `MsDhrnCompound`), no rate-cut (`nRcutAmt`), no kasar/unchak (`TR_DHRN_INTREC.cs`); pledge `MAIN_STOCK`/renewal gap |
| **Scheme/Membership** (TR_MEMB_*) | Partial | Cash-only; no gold-gram/multi-member/UPI; scheme gold-amt/SBILL-redeem/EXP_DATE gaps; loyalty accrual rule engine missing |
| **Bullion/Tour/VP** | **Big gaps** | **MISSING:** `TR_VP`, `TR_VP_ADJ`, `TR_GOLD_BOOK`, `TR_BUL_SALE`, `TR_TOUR_ORD`, `TR_OTH_COMM`. `TR_BUL_BOOKING` has no drawdown consumer (booking→sale broken). Tour-sale/inout partial |
| **GST/E-Invoice** | Good | GSTR read-models sound; e-invoice behind GSP creds (external) |
| **Masters (33)** | Generic | **All 33 via one generic CRUD**; 5 dedicated screens; referential delete guards on **4 of ~32** tables; no single-record auto-code |
| **Reports (255)** | **Weakest** | See §9 |
| **Utilities/Settings** | Partial | CO_SET_NEW rounding flags unread; device/hardware utilities absent |

Full per-form tables in `gap-2026-07-27/*.md`.

---

## 8. Genuinely-missing forms (HIGH/BLOCKER)

Confirmed by grep — **zero web references**:

- `TR_VP` (Value-Payable parcel via Angadia) — stored in `RATE_CUT_DATA` (VP_AMT/VP_INS_AMT/VP_CHARG_AMT/AC_ANGDIYA); items issued via `Wh_Sale_Stk`.
- `TR_VP_ADJ` (settles VP by updating `RATE_CUT_DATA.VP_ADJ_AMT`).
- `TR_GOLD_BOOK` (per-customer fine-gold accumulation, `DG_GOLD_DATA`, Fine=Amount/Rate +3% GST).
- `TR_BUL_SALE` (bullion sale — the consumer of bullion bookings).
- `TR_LOCT_AMT` (location amount transfer), `TR_TOUR_ORD` (tour order), `TR_OTH_COMM` (other commission).

These are **whole business capabilities absent**, not cosmetic gaps.

---

## 9. Report / Crystal-print fidelity (BLOCKER + HIGH — the largest gap)

Two report paths exist:

**(a) ~55 hand-written analytical dataset builders** (`reports.ts`, `reports2-10.ts`, `voucherRegister.ts`, `tagStock.ts`, `statementDocs`) → **GOOD** category parity for registers/summaries/statutory returns (sales/purchase register, trial balance, day-book, GST, stock, karigar, dhrn, ageing, contra). But they map to report **categories**, not the **255 named `.rpt`** 1:1.

**(b) Per-`.rpt` engine** (`reportEngine.ts` + `reportBind.ts` + 254 `spec.json`) → **LOW fidelity:**
- **BLOCKER:** `reportBind.detectFamily` returns **`'SL_DATA'`** for any spec not referencing SL/PR/KR, and `FAMILIES` fallback also defaults to `SL_DETL`. Only 3 voucher families are supported → **account/dhrn/mfg/order/memb/scheme/rate/loan/cheque `.rpt` silently bind to SALES data → wrong voucher or 404.** (verified in `reportBind.ts`.)
- **HIGH:** layout engine renders positioned **text/field/line/box only** — **no images, no barcodes** (Code39 exists only for tag labels), **no subreports, no fonts** (fixed CSS), **no pagination, no real grouping** (Detail repeats only), **no running totals, no conditional suppression**.
- **HIGH:** `crystalFormula.ts` is a minimal evaluator (single-level if/then/else, concat, +−×, comparisons, ToText/Trim/CStr); **no aggregates/division/booleans/string/date fns/variables**; parse failure returns `''` silently. Of ~5,991 extracted formulas, only the simplest display formulas evaluate.

**Impact:** printed invoices/vouchers/statements will **not match** the desktop's Crystal output in content or layout, and some reports will render **plausible-but-wrong** data. For a shop that prints customer-facing bills, this is release-blocking.

---

## 10. Frontend / UX / keyboard parity (MEDIUM)

- **Implemented:** F1 list-of-values (`LookupPicker.tsx:88`), grid Arrows/Enter/Escape/Ctrl+D (`GridKeyboard.tsx`), Esc-to-tender focus on sales/repair grids (`sales/page.tsx:120`), Enter-to-advance + Ctrl/Cmd+Enter submit (`KeyboardNav.tsx`).
- **Missing (MEDIUM):** desktop **global F-keys** F2=Save / F3=Delete / F5=Print / Esc=Close on every form (`MS_ACCT.vb:73-76` pattern) are **not bound** globally; `VoucherChrome` buttons aren't wired to F-keys.
- **Complex-form simplification:** dedicated screens still omit desktop sub-grids (stone/diamond), separate tender panels, full voucher chrome, copy-print flow, and load/edit navigation on several forms.
- **Frontend tests thin:** `apps/web` has **2 test files** (`gridKeyboard.test.ts` unit, `browser.smoke.mjs` Playwright smoke); **no `playwright.config`, no E2E dir, no visual/snapshot tests.**

---

## 11. Data model / DB parity (LOW — largely done)

- Web Postgres is a **complete superset** of the desktop schema: **168 tables ≥ 146**, every real table + column present (4 tables + 22 cols were added additively; drift closed via versioned migrations per the DB-parity report and audit addendum).
- Desktop has **0 procs/views/triggers/FKs** — all logic is in app code (already extracted). So there is nothing DB-side left to extract.
- Residual (LOW): newly-added tables/columns (e.g. `COUNTRY_MAST`, `IMAGE_DATA`, `TAG_DATA` extras) are **not all wired into the UI** yet — that's build-out, not schema gap.

---

## 12. Testing & verification gap (HIGH — governance)

The single most important non-code gap: **there is no proof the web behaves like the desktop.**

- **0 / 204 forms** and **0 / 255 reports** have a `desktop_compared` artifact (golden data / screenshot / PDF diff). `packages/parity` compares rows with toy objects only.
- The **3 DB-integration tests are skipped by default** — including `transaction.integrity.db.test.ts`, exactly the posting/stock/reversal integrity proof.
- **28 `.live.mjs`** scripts (the real end-to-end checks) are **outside CI**.
- **No** browser E2E, visual, concurrency, load, migration-drift, or restore-drill suite.
- **No hardware/device bridge** (scale, scanner, label printer, webcam) — a real desktop surface.
- Observability/DR partial (logger disabled by default; backup script exists, no restore drill).

Green unit tests + typecheck + build are **engineering hygiene, not parity**.

---

## 13. Consolidated gap register (severity-ranked)

| # | Gap | Severity | Area | Evidence |
|---|---|---|---|---|
| 1 | Unknown `.rpt` silently binds to SALES data | **BLOCKER** | Reports | `reportBind.ts detectFamily` |
| 2 | Crystal print fidelity absent (images/subreports/fonts/pagination/grouping/formulas) | **BLOCKER** | Reports | `reportEngine.ts`, `crystalFormula.ts` |
| 3 | Missing forms: VP, VP_ADJ, GOLD_BOOK, BUL_SALE (booking has no consumer) | **BLOCKER** | Bullion | grep zero-refs |
| 4 | 0 desktop-comparison evidence (all forms/reports) | **BLOCKER** | Governance | §12 |
| 5 | Fine formula divergent: karigar-issue, old-gold purchase, item-opening/lot | **HIGH** | Calc | `01-fine-formula.md` |
| 6 | Physical-stock reconcile posts no adjustment | **HIGH** | Inventory | `stock.ts:325` |
| 7 | Melting posts no MAIN_STOCK/MFG_ISU_REC | **HIGH** | Mfg | `melting.ts` |
| 8 | Wholesale-sale has no rate-cut/consignment/lot engine | **HIGH** | Sales | `wholesale-sale` → `/sales` |
| 9 | Dhrn interest simple-only (no compound/rate-cut/kasar) | **HIGH** | Loans | `TR_DHRN_INTREC.cs` vs `dhrn.ts` |
| 10 | Masters: 28 of ~32 tables lack referential delete guards | **HIGH** | Masters | `master.service.ts:186-193` |
| 11 | Loyalty POINT_DATA accrual not written on sale | **HIGH** | Membership | `sales.ts` (reversal-only) |
| 12 | Purchase/Sale-return satellites (PR_IDTL/SL_IDTL/DM_DATA/re-tag) missing | **MEDIUM** | Txn | `02-txn-completeness.md` |
| 13 | Monetary rounding not per-company (CO_SET_NEW) | **MEDIUM** | Calc | `core/money.ts:7` |
| 14 | Missing forms: LOCT_AMT, TOUR_ORD, OTH_COMM | **MEDIUM** | Coverage | grep zero-refs |
| 15 | Scheme/membership: gold-gram/multi-member/UPI/maturity gaps | **MEDIUM** | Membership | `03-uncertain-semantics.md` |
| 16 | Global keyboard accelerators (F2/F3/F5/Esc) absent | **MEDIUM** | UX | `KeyboardNav.tsx` |
| 17 | Frontend/E2E/visual tests near-absent; DB-integration tests skipped | **MEDIUM** | Testing | §12 |
| 18 | 33 masters via one generic CRUD (no dedicated screens/auto-code) | **MEDIUM** | Masters | `configs.ts` |
| 19 | Average-touch rebuild unimplemented | **LOW** | Inventory | `03-uncertain-semantics.md` |
| 20 | `purchase.ts:102` fine comment contradicts code | **LOW** | Docs | `purchase.ts:102` |

---

## 14. Remediation roadmap toward EXACT parity

**Phase P0 — Correctness (weeks 1-2, HIGH):** replace the universal fine helper with named per-workflow policies + `LesWt/LesTch/KunFine` terms; load `CO_SET_NEW` rounding flags; add golden-vector calc tests. Post stock in physical-stock and melting.
**Phase P1 — Coverage of missing forms (weeks 2-5, BLOCKER):** implement VP / VP_ADJ / GOLD_BOOK / BUL_SALE (+ booking→sale drawdown), then LOCT_AMT / TOUR_ORD / OTH_COMM; build the wholesale-sale rate-cut/consignment engine.
**Phase P2 — Transaction satellites (weeks 4-6, MED):** add PR_IDTL/SL_IDTL/DM_DATA/stone grids, sale-return re-tagging, tender satellites (CARD/UPI/ROJ_MEL), loyalty accrual on sale, MFG-order APR_*.
**Phase P3 — Report/print fidelity (weeks 5-10, BLOCKER):** extend `reportBind` to all voucher families (kill the SALES default); add images/barcodes/subreports/fonts/pagination/grouping/running-totals/suppression to the layout engine; expand the formula evaluator with aggregate/coverage metrics against the 5,991 formulas.
**Phase P4 — Desktop-comparison harness (parallel, BLOCKER for sign-off):** build a golden-data + PDF/visual diff harness; restore the Azure SQL Edge golden master; compare N invoices/vouchers/reports byte/row/pixel; enable the skipped DB-integration tests + `.live.mjs` in CI.
**Phase P5 — Dhrn/scheme depth, masters, UX, ops (weeks 8-12, HIGH/MED):** Dhrn compound/rate-cut/kasar; scheme gold/maturity; referential delete guards on all masters; global F-keys; observability/restore drills; hardware bridge scope decision.

**Exact-parity acceptance = every form/report passes `desktop_compared` (Phase P4 harness) with zero/approved diffs.**

---

## 15. What's genuinely good (so effort targets the real gaps)

- Sound double-entry posting with `assertBalanced`, atomic `postVoucherTx`/`reverseVoucherTx`, period-lock, full-scope voucher numbering.
- Correct stock-movement model (every line → signed `MAIN_STOCK`), server-derived reversal, tag-issue concurrency guard.
- Authoritative session scope + per-form USER_SET RBAC + tenant RLS (migration-owned).
- Sale core is rich: GST split, per-group income accounts, hallmark/TCS/kasar/old-gold, order-advance adjustment.
- ~55 real report dataset builders; complete DB schema superset; clean typecheck/tests/build.

The rebuild is **~2 phases of correctness + coverage and 1 phase of report-fidelity away from a credible parity pilot**, plus the comparison harness for certification.
