# Independent desktop → web parity evaluation — 28 September 2026

Scope: I evaluated the current `main` (HEAD `03148fe`) against the latest plan, `parity-plan-2026-09-10/` (Round 15 status, 12 Sep; checkpoint 41 was the last one sealed). I did this by **running** the application, not by re-reading earlier claims. Everything below was measured in this session. Commands, raw logs and machine-readable artifacts are in [`parity-plan-2026-09-10/evidence/independent-evaluation-2026-09-28/`](parity-plan-2026-09-10/evidence/independent-evaluation-2026-09-28/).

## 1. Bottom line

- **The web app is real and substantial.**
  - It builds cleanly, and the full test estate passes against a real PostgreSQL with forced RLS: 3,158 API, 1,613 core and 522 web tests.
  - Its three real-stack browser suites also pass.
  - A sales invoice entered through the browser posts a balanced ledger, a Rojmel, stock, tax and outstanding rows. It can then be reloaded, edited, printed and deleted with a `DELETE_DATA` audit.
- **It is not at desktop parity, and it is not usable end-to-end as a replacement today.** Four problems were found in the running app, none of them in documents:
  - **Cash Received and Cash Payment cannot be saved from the UI.** Both forms omit the book, so every save returns HTTP 400.
  - **The core retail calculation diverges on a web-provisioned company.** Blank `SL_AMT_TYPE` is priced on *fine* weight, where the desktop prices on *net*. A 10 g 22K line bills ₹54,960 instead of ₹60,000.
  - **Wholesale sale / rate cut writes no stock movement, and no money leg when fine is rate-cut.**
  - **7 report screens call the wrong or a non-existent endpoint**, including GSTR-2 and GSTR-3B.
- **The fresh desktop-vs-web comparison matched 0 of 9 vouchers.** These are 9 real vouchers that had never been compared before, from the `Next23` and `Next25` desktop databases. That is consistent with the retained Live24 result of 0/70. Most differences are known classes: descriptive columns left blank, ledger-key tails, unmeasured leg codes, and no `TEMP_BOOK_DATA`. Some are functional: wholesale stock and money.
- **The plan's own status is accurate and honest.** It reports 198/198 menus mapped, 0/198 accepted, and 83 packages / 34 cards open. My results do not justify any improvement in that status. They add concrete defects the plan does not list (§5).

A single "percent complete" figure would be invented, so none is given. The measurable proxies are in §3.

## 2. What was actually run

| Layer | Setup |
|---|---|
| Desktop data | Downloaded the original SQL Server files through the GitHub media API; SHA-256 matched the LFS OIDs. `NextMain`, `Next23` and `Next24` were restored from `.BAK`; `Next25` and `NextImage` were attached from `.mdf`. Engine: SQL Server 2022 (Linux container). Contents: 5 databases, `MENU_DATA` = 209 rows. |
| Web data | PostgreSQL 16. All 29 Prisma migrations applied, then `rls.sql` and `setup_roles.sql`. Result: 175 tables, 174 with forced RLS, and a non-superuser `app_user`. |
| Web stack | API built from `apps/api/dist/server.js` (dev mode, demo seed), and Next.js production build (`next start`). |
| Browser | Playwright 1.61.1 headless Chromium. Every request hit the real API and DB; nothing was mocked in my journeys. |

`Live24`, the real-customer database behind the historical 70-case comparison, is **not in the repository**, so those cases could not be re-captured. I did re-run the retained bundle diff.

## 3. Gate results (all run in this session)

| Gate | Result |
|---|---|
| `pnpm typecheck` (10 tasks), `pnpm build` (7), `typecheck:tests`, ESLint, workspace lint (917 files), Prettier | **pass** |
| Core tests | **1,613 / 1,613 pass** (26 files) |
| API tests, real DB, `RUN_DB_INTEGRITY/SECURITY_TESTS=1` | **3,158 / 3,158 pass** (271 files, 188 s) |
| Web unit tests | **522 / 522 + 6 node tests pass** |
| `parity.real-stack.mjs`, session-context (14 checks), labour lifecycle (5 checks) | **pass**, zero mocked requests |
| `browser.smoke.mjs`, `route-coverage` (124/124 routes render) | pass, but **the API is mocked** in both, so they do not prove behaviour |
| `settings:parity` 128/128, `schema:readiness` 145/145 tables and 5,231/5,231 columns, `fresh:provision`, `report-baselines` (254 unchanged), `register:check`, contracts | pass |
| `g5:parity` (retained Live24 bundle) | **RED**: 0/70 cases match, 510 field differences, 153 missing rows, 137 extra rows |
| `depth:parity` | **FAIL**: API fields no screen can supply rose from 96 to 106. Surface is 72.1% (3,681/5,107), grid columns 61.3%, settings honoured 47/130, 6 contained operations |
| `depth:deadcells` | **FAIL**: 33 of 48 Sales Return grid columns are never read by the writer |
| `check-kernel-conformance` | **FAIL**: 127 module-local rounding bypasses in 80 files, above the ceiling of 108 |
| `docs:refs` | **FAIL on a clean clone**: 4 evidence files cite git-ignored `test-results/**` outputs |

Round 15 is unsealed. With these runs, 14 of its 18 recipe checks now have a current result: they passed, apart from the known red gates above. They are **not** a sealed checkpoint 43.

## 4. Fresh desktop-vs-web differential (never-compared vouchers)

**Method.** I used the repo's own harness:
1. `parity-import-masters` copies the real desktop masters into a web tenant.
2. `parity-replay-generic` rebuilds each voucher's operator inputs from the desktop rows and posts them through the current web engine.
3. `parity-extract-mssql/pg` captures both sides, and `parity-compare` diffs every written row.

**Cases:**
- Next23 (DEMO COMPANY): sales 026/1, 026/2 and 032/1, purchase 035/1, wholesale/rate-cut 034/4, 034/5 and 034/6.
- Next25 (NJ GOLD): purchase 035/1, wholesale 034/1 and 034/2.

### 4a. Harness defects found first (so they are not blamed on the web)

The shipped generic replay produced false differences. I corrected a copy (`scripts/eval-replay-corrected.mjs`):

| Defect | Effect |
|---|---|
| Passes the desktop's untagged literal `TAG_NO='N'` as a tag | Every untagged sale fails with "tag not available for issue: N" |
| Omits `OTH_AMT`, labour (`LBR_RATE`/`LBR_AMT`) and header discount | Purchase and sale totals come out 0, or short by the labour |
| Maps only `RATE_CUT_ISU` | Receive-only rate cuts fail with "requires at least one issued or received line" |
| Omits `CR_FINE` | That is operator input; TR_WH_SALE.cs:15428-15482 derives `DR_AMT = round(CR_FINE × rate)` from it |

The original-harness and corrected-harness artifacts are both retained.

### 4b. Result with the corrected harness

- **0 of 9 cases match.**
- 2,541 fields compared; 165 field differences, 66 missing rows, 24 extra rows.
- 17 table-cases where the web wrote nothing.
- Sale 026/00001 was refused by the web's defaulter-list guard, which is correct behaviour, so it was not replayed.

| Class | Evidence | Assessment |
|---|---|---|
| **Wholesale / rate cut writes no stock** | 034/4, 034/6, N25 034/1 and 034/2: `MAIN_STOCK` has 2, 3, 1 and 1 desktop rows and 0 on the web. `rateCut.ts:992`: "PHASE-2 TODO: … MAIN_STOCK (tag/stock movement) … deferred" | **Functional gap.** Tags sold wholesale stay in web stock. Also missing: `RATE_CUT_ISU_REC`, `SL_IDTL`, and the `BAR_DETL` sold flag. |
| **Rate-cut money leg missing** | 034/5: desktop `DR_AMT` 3,517, web 0. 034/6: desktop 32,240, web 0. N25 034/2: desktop 81,102, web 0. `AC_DATA` has 4–5 desktop rows against 2–3 on the web; the party-Dr / sale-Cr pair is absent even though `settleCrFine` and `fineRate` were supplied. | **Functional gap.** A fine balance converted to money never reaches the party ledger. |
| **Ledger-key tails and leg codes** | Rate-cut fine legs: desktop `…23`/`…29`, web `…51`/`…52`/`…53`. This is the documented "reserved band 50+srno" for unmeasured codes. Estimate book 032 uses a 33-character layout on the desktop against 23 on the web. | Known, and still open for these books |
| **Descriptive / denormalised columns blank** | `LDR_NAME`, `IT_DESC`, `ITM_REMARK`, `PR_CODE`, `TBL_CODE`, `EMP_CODE`, `WITH_STOCK`, `STK_DATE`, `KR_NWT`, `ISR_NO`, `RATE_TYPE`, `IRN_NO`/`ACK_NO` default `N`, `MOBILE`, `KR_NAME` | Reports and Crystal layouts that read these columns will print blanks |
| **Extra web rows** | `BILL_OS_DATA` on a fully paid purchase (035/1), `LOT_DETL` on purchases, `TAX_DATA` on a book-032 estimate | Divergent write sets |
| **Missing web rows** | `TEMP_BOOK_DATA` is never written. `SL_ORD_ADJ` is absent because the order advance was not replayable. | Known |
| **Schema gaps** found by import/diff | `PR_DATA` lacks 5 columns and `PR_DETL` lacks 13 (for example `ITM_CGST_AMT`, `TAX_CODE`, `GRAND_TOTAL`). `RATE_CUT_*`: `RE_TRFR`, `FIX_WEST_PRC`, `ITM_STYLE`. `AD_MAST.BANK_AC`. | These are Next25-edition columns. The "5,231/5,231 columns" readiness figure only covers the Live24-derived baseline. |

Sale 026/00002 still differs in tax, discount distribution (`IT_DISC_AMT`) and `ADV_AMT`/`BILL_OS`. That is because its 149,350 order advance cannot be replayed without the order. I do not count it as a proven calculation defect.

### 4c. Migration path

- `cutover.mjs --dry-run` on Next23 reads 561 rows from **42 tables**; the desktop has 138–151 tables.
- The real load is refused by containment WP-01 ("partial table list, unscoped extraction, tenant-wide replacement").
- **There is currently no way to move a desktop customer's data into the web app.**

## 5. Real-browser end-to-end results

### 5a. Full-surface crawl: 236 pages (234 nav hrefs + concrete routes), real API

- 173 pages rendered with no failed API call. There were no runtime `pageerror`s and no error boundaries.
- 63 pages had failed API calls:
  - On 53 of them, the only failure is the benign `GET /reports/<slug>/filters` 404, which is handled by design.
  - **The rest are real defects:**

| # | Defect (confirmed in the browser and in source) | Where |
|---|---|---|
| D1 | **Cash Received and Cash Payment cannot be saved.** `POST /api/receipts` returns 400 "voucher requires … configured book" and `POST /api/payments` returns 400 "voucher numbering requires … book". The same receipt sent through the API with `coBook=RCT` in the same session returns **201**. Bank Received/Payment, Card Rec and multi-line receipts share the same component. | `components/PaymentForm.tsx:78-105` sends no `coBook`. The API is `completeFinanceScope` (`finance/lifecycle.ts:30`). |
| D2 | **GSTR-2 and GSTR-3B screens are empty.** The URL builder strips digits, so `gstr2` becomes `/reports/gstr` and `gstr3b` becomes `/reports/gstrb`. Both return 404, although `/reports/gstr2` and `/reports/gstr3b` exist. | `app/(app)/reports/[report]/page.tsx:97` |
| D3 | **HUID Report, Item Stock Level, Bill Wise Profit, Physical Stock Verify and Stock Movement show no data.** Their builders are only registered in `REPORT_BUILDERS`, which serves `/reports/:report/export.xlsx`. There is no `GET /reports/<slug>`, so the screens get a 404. The Excel export works. | `routes/txn.ts:3965-3990` vs `:4226` |
| D4 | `/reports/balance-sheet` and `/reports/gstr1` filters return 403 `form: unresolved`: the rights mapping is missing for those slugs. | `reports/reportAuthorization.ts` |
| D5 | `/txn/order-cancel` loads its list with 400 "complete voucher scope". The page opens with an error until a scope is supplied. | Order Cancel page |

### 5b. Business journeys through the UI, with DB verification

Tenant: fresh web-provisioned company (`seedCompany` + demo seed).

| Journey | Result |
|---|---|
| Login → Open Company → Dashboard | Pass |
| Daily rate (gold 60,000/10 g, silver 70,000/kg) | Pass (`POST /daily-rate` 201) |
| Sales invoice (book SL, CUST01, GOLD 1 pc, 10 g, touch 91.6, ₹6,000/g, ₹500/g making, ₹20,000 cash) | Saved as voucher #1. Writes `SL_DATA`, `SL_DETL`, 5 `AC_DATA` (balanced: Dr 61,758.80 / Cr 61,758.80), 3 `ROJ_MEL_DATA`, `MAIN_STOCK`, 2 `TAX_DATA` (CGST/SGST 899.40 each) and `BILL_OS_DATA` (41,758.80). Correct against the web's own rules. **But see D6.** |
| Reload, edit (gross 8 → 9), Update Invoice | Pass. The ledger re-posts (48,583.04 → 54,655.92) and row counts are unchanged, so there is no duplication. |
| Print | HTML tax invoice with the correct totals and CGST/SGST split. This is **not** the desktop Crystal layout (255 `.rpt` files); visual parity is unverified. |
| Delete | Pass. All 7 posting tables return to 0 and 2 `DELETE_DATA` audit rows are written. |
| Cash receipt / cash payment | **Fail (D1)** |
| Purchase (book PR) | **Fail on a fresh company:** 400 "missing `GROUP_MAST.PURC_AC` for item GOLD". Web provisioning creates the group with a `SALE_AC` only (`server.ts:54`). Purchase is unusable until an operator edits the group master; the error message is clear. |
| Account ledger, Rojmel, Trial balance, Sales register | Pass. The on-screen rows equal the direct SQL aggregates, for example trial balance CASH 20,000 Dr, CUST01 41,758.80 Dr, GST 1,798.80 Cr, SALES 59,960 Cr. |
| GSTR-3B | Empty (D2) |

**D6: calculation divergence (high severity).**
- **On the web:**
  - A web-provisioned company gets `CO_SET.SL_AMT_TYPE` = blank (`seedCompany.ts:268` inserts only the key).
  - `saleAmountBase` treats blank as the fine basis: `shared/settingsBehavior.ts:651-653`, "Blank deliberately returns fine to preserve the pre-setting web calculation".
  - Purchase is not affected: in `purchaseAmountBase`, blank also falls to fine, and that matches TR_PURC.cs:7396.
- **On the desktop:**
  - When a company is opened, a blank `SL_AMT_TYPE` is explicitly set to `N` (MS_OPNCOMP.cs:881-884).
  - The amount basis is `F` only when `RATE_WITH`/`MsSlAmtType = "F"` (TR_SALE.cs ~10760-10935). Anything else uses (net + ghat) × rate.
  - Every real desktop company I inspected stores `N`: Next23, and Next25 companies 00, 01 and 02.
- **Effect:** 10 g at 91.6 touch and ₹6,000 prices at **₹54,960 on the web against ₹60,000 on the desktop**, for every sale of non-fine metal in a web-provisioned company.
- Separately, per-line `RATE_WITH` override (desktop column 21) is ignored by the writer. `rateWith` appears in the dead-cell list.

### 5c. Robustness and containment probes (authenticated, real API)

- **Still contained (HTTP 503 `PARITY_CONTAINMENT`, as the plan states):** Tag Transfer, Tag Cancel, Tag Weight Difference, and logical restore. Tag Split returns 409 `book-unavailable` on a fresh company.
- **Unvalidated input returns HTTP 500 instead of a validation error:**
  - `POST /sales-returns` with an incomplete line gives 500 `[DecimalError] Invalid argument: undefined`.
  - `createSale` with an unknown `labourType` gives a `TypeError` in `labourCharge` (`packages/core/src/calc.ts:47`).
  - `POST /sales` passes the body through without schema validation (`routes/txn.ts:1055-1058`).

## 6. Module-by-module status against the 198 desktop menus

In the register, every entry is `implemented-unverified`: 4 are contained and 3 are partial. The web navigation uses 13 re-grouped sections with 234 links, not the desktop's 13 ribbon tabs (Company/Master/Transaction/ExtraTran/Karigar/Dhiran/Scheme/Mfg/Report/More/Analysis/Other/Crm). "Verified here" means verified by this session.

| Desktop tab (menus) | What I verified in this session | Open or confirmed gaps |
|---|---|---|
| **Transaction (24)** | Sales: create, edit, print and delete all work, and ledger/Rojmel/stock/tax/outstanding posting is balanced. Purchase: the posting engine replays real vouchers. | **D1:** cash/bank received and payment are broken in the UI. **D6:** sale amount basis. Wholesale/rate cut: no `MAIN_STOCK`, no money leg (§4b). Sales Return: numeric save disabled (plan X13), and 33/48 dead cells. E CrntNote: partial (IRN only). Purchase on a fresh company needs a group `PURC_AC`. |
| **ExtraTran (21)** | Pages render with a real API | Approval/consignment/tour/parcel lifecycle not independently verified (X17). Fine JV, Labour Work, Other Income/Expense: only covered by unit/DB tests. Card Rec shares the broken PaymentForm (D1). |
| **Karigar (15)** | Pages render; repair workflows are covered by smoke (mocked) and DB tests | Tour Order is partial (plan CR-03). No desktop comparison of karigar issue/receipt; book 050/052 cases exist in Next23 but the generic replay has no builder for them. |
| **Dhiran (12)** | Pages render | Interest/redemption variants unverified against the desktop (X24). No desktop loan data exists in Next23/24/25. |
| **Scheme (11)** | Pages render | Retained family-2 Live24 comparison only; no new data |
| **Mfg (4, plus unlisted process screens)** | Report pages render | Lot manufacturing operator path absent (CR-06 / GAP-01). Process screens (Casting, Ghat, Filling, Polish and others; MDI_FORM.cs:9951-10672) are outside `MENU_DATA` and unverified. |
| **Master (23)** | The generic master grid renders. Party (rich) exists. Masters were imported from real desktop DBs through the harness. | `/masters/accounts` shows raw column names (`row_id`, `CO_CODE`, …) rather than the desktop MS_ACCT form layout. Design Book is partial (no `DESIGN_IDTL`). Next25-edition columns are missing (§4b). |
| **Company (16)** | Login, open company, year select, provisioning | Fresh provisioning leaves `SL_AMT_TYPE` blank (D6) and `PURC_AC` unset. Settings honoured in business logic: 47/130. Backup restore is contained. |
| **Report (26), More (12), Analysis (8)** | Ledger, Rojmel, trial balance and sales register reconcile to SQL | **D2/D3:** 7 screens broken. Report output is HTML, not Crystal; 254 layouts are baselined but none is visually compared. `g5` report differential absent. |
| **Other (24)** | Daily rate works; containment confirmed | Tag Transfer/Cancel/Weight Diff/Split contained. Voucher renumber misses Rojmel/UPI/order refs (GAP-12). Data Import to production is contained. |
| **Crm (2)** | Page renders | No desktop form found in the dispatch (register note) |

## 7. How this maps onto the plan (X-cards)

My findings reinforce these open cards. None can be closed on this evidence.

| Card | Findings |
|---|---|
| X12 (Purchases) | Fresh-company `PURC_AC` |
| X13 (Sales/Returns) | D6, Sales Return 500 on bad input |
| X16 (Finance / rate cut) | D1; rate-cut money and stock |
| X06 (Posting footprints) | 0/9 fresh cases; blank descriptive columns; unmeasured leg codes |
| X08 (Settings) | Blank-setting defaults disagree with the desktop |
| X10 (Provisioning) | `SL_AMT_TYPE`, `PURC_AC` |
| X26 (Reports) | D2–D4 |
| X30 (Migration) | 42-table loader, contained |
| X03 / X34 (Verification) | Browser gates that mock the API passed while D1 and D2 were broken; the shipped replay harness has 4 input defects; `docs:refs` depends on ignored files |

The plan does not currently record **D1, D2, D3, D4, D6**, the rate-cut `DR_AMT` money-leg gap, or the harness defects.

## 8. Limits of this evaluation

- **No original Windows desktop was executed** (no Windows host). Desktop behaviour comes from the restored databases and the decompiled source.
- `Live24` is absent, so only 9 new real vouchers were available. Loans, scheme, manufacturing, karigar and approval have no desktop transactions in Next23/24/25.
- **Not tested:** hardware (scales, printers, camera), external providers (GSP/IRN, WhatsApp, SMS), multi-user concurrency at scale, and offline behaviour.
- Screenshots of all 236 pages were captured locally. They are not committed because `*.png` is LFS-tracked and LFS upload is unavailable here.

## 9. Recommended order of work

1. **D1:** send `coBook` from `PaymentForm` (and a book selector for bank/card), then add a real-stack browser test that saves a receipt and a payment.
2. **D6:** either make blank `SL_AMT_TYPE` behave as the desktop does (non-`F` means the net basis), or have `seedCompany` write the desktop default `N`. Honour per-line `RATE_WITH`.
3. **D2/D3/D4:** fix the slug regex, register `GET /reports/<slug>` for the 5 export-only builders, and add rights mappings. Extend the route crawl to run against the real API. The crawl script here does exactly that and caught all of these.
4. **Rate cut / wholesale:** implement `MAIN_STOCK`/`BAR_DETL`/`RATE_CUT_ISU_REC` and the settled-fine money leg, then re-run the 034 cases.
5. **Replay harness:** fold in the four corrections, add builders for karigar (050/052), orders (020) and estimate (032), and schema-validate API inputs so bad data returns 400, not 500.
6. **Provisioning:** give `seedCompany` desktop-equivalent `CO_SET` and `GROUP_MAST` account defaults, and add the Next25-edition columns.
7. **Migration:** implement the scope-safe loader for all desktop tables (X30) before any customer pilot.

## 10. Reproduce

The scripts are in `evidence/independent-evaluation-2026-09-28/scripts/`:
- `withpg.sh`, `withmssql.sh` and `withapp.sh` boot Postgres, SQL Server and the API + web per command.
- `bootstrap_db.sh` applies migrations, RLS and roles.
- `gates.sh` runs all the repository gates.
- `diff_run.sh` with `eval-replay-corrected.mjs` runs the fresh differential.
- `crawl.mjs`, `journey.mjs`, `journey3.mjs` and `containment.mjs` are the headless-browser suites.
