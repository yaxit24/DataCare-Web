# Audit implementation plan — 1 October 2026 (second amendment)

This amendment turns the full-stack audit of 1 October 2026 into implementable work. It adds gaps **G20–G66**,
decisions **D15–D22** and slices **N47–N82**, corrects the recorded status of slices that landed since
[document 10](10-gap-register-2026-10-01.md), and fixes an execution order. It supplements documents 01–10. It does
not close, narrow or replace any package (P00–P14), card (X01–X34) or slice (N01–N46). No acceptance count changes:
menus 0/198, packages 0/83 and cards 0/34 remain open.

- **Plan baseline:** `main` at `fd6c82d` (after PRs #18–#22). The audit ran at `0da250a`; the gates affected by later
  merges were re-run at `dcba5a4` (see §1).
- **Desktop authority:** `unified/src/csharp/DataCareNext/` (decompiled C#) and the original SQL Server databases
  (`Live24`, `Next23`, `Next24` seed, `Next25`, `NextMain`), queried read-only and in aggregate only. File and line
  references are 1-based at the plan baseline unless stated otherwise.
- **Evidence:** [audit observations](evidence/audit-2026-10-01/observations.json) with hashed logs, the 239-route
  crawl, browser probes, aggregate desktop conventions and the scripts used.
- **What was not done:** the Windows desktop was not run; hardware, live GST/IRN, WhatsApp/SMS, load and offline
  behaviour were not tested.

## 1. What the audit measured

Evidence paths in this table are relative to `evidence/audit-2026-10-01/`.

| Area | Result | Evidence |
|---|---|---|
| Lint, typecheck, production build | Pass: 982 files linted, typecheck 10/10, build 7/7 | `logs/static-lint.log`, `logs/production-build.log` |
| Test type compilation | Red at `0da250a` (4 × TS18048, `registerClassify.db.test.ts:115,120`); green at `dcba5a4` after PR #18; not run by CI | `logs/typecheck-tests.log`, `logs/recheck-dcba5a4/typecheck-tests.log` |
| Core and web unit tests | Core 1,737/1,737 (32 files); web 594/594 plus 6 protocol tests | `logs/full-db-tests.log` |
| API tests on an isolated, migrated PostgreSQL (forced RLS on 174 tables, non-owner `app_user`) | 3,346/3,349. One deterministic failure: sales-return create exceeded Prisma's 5,000 ms interactive transaction (5,143 ms). The other two failures were a lost connection caused by another session's container on the same port | `logs/full-db-tests.log`, `logs/rerun-*.log` |
| Repository gates | Pass: depth, dead cells, settings 128/128, schema 145/145 tables and 5,231/5,231 columns, fresh provision, 254 report layouts, format, contracts (17 draft debt lines), parity ratchet. Red: menu register in release mode (0/198), kernel conformance (124 rounding bypasses, ceiling 108), `docs:refs` (stale test count), G5 desktop comparison (retained 1 September capture, 0/70). Type parity in release mode is a SKIP | `logs/gates/*.log`, `logs/recheck-dcba5a4/*.log` |
| Zero-mock browser suite (`parity.real-stack.mjs`, 24 journeys) | Red at tag split: the seed did not take effect on a clean database. 14 journey sections completed, 10 never ran | `logs/real-stack-run.log`, `logs/real-stack-result.json` |
| Operator journey in Chrome (DevTools MCP and Playwright) on a fresh web company | Login → company → dashboard; daily rate; sale 10 g at 91.6 touch, ₹6,000/g, ₹500/g making: ₹65,000 + ₹1,950 GST = ₹66,950, ledger balanced (₹86,950 each side), day book, stock, tax and outstanding written; reopen and edit to 9 g re-posted without duplicates; print correct except the date; cash receipt; purchase on a fresh company. 23 report screens checked against the ledger | `browser-probes-1.json`, `browser-probes-2.json` |
| Full route crawl | 239/239 routes render without failing API calls or runtime errors (1,410 API calls; 62 expected report-filter 404s) | `crawl-239-routes.json` |
| Desktop databases (aggregate) | 1,096/1,096 `BOOK_DATA` rows in the four databases are 3-digit numeric codes at location `00`; every posting uses `LC_CODE='00'`; `AC_GROUP` has the same 35 rows (checksum 551216197) in every company; `CO_SET.SL_AMT_TYPE` is `N`; the sales party name is filled on every sale | `desktop-conventions.json` |

## 2. Status corrections to existing slices

These corrections are applied to `execution-backlog.json` with evidence. "In-progress" means some engineering
evidence exists and named work remains. No slice is accepted.

| Slice | Recorded | Corrected | Engineering evidence on `main` | Remaining work |
|---|---|---|---|---|
| N32 | implemented-unverified | in-progress | TAG PURCHASE book lifecycle (PR #11), jobwork books (PR #16, PR #19) | 95-column `TR_PURC_HM` receive band; lossless reopen (G46) |
| N34 | planned | in-progress | Day book written (PR #17); full-scope GET and print, complete reversal including `ROJ_MEL_DATA`, `PR_IDTL`, `DM_DATA`, source year and hidden identity (PR #18) | G47: edit lifecycle, `PR_IDTL`/`DM_DATA` writes, residual-limited source selection |
| N36 | planned | in-progress | Sales/purchase registers, GSTR-3B, by-party, daily and employee summaries classify by `MAIN_BOOK` (PRs #13, #14) | G48 |
| N38 | planned | in-progress | Document-only Wholesale Quotation lifecycle: own WH QUOT book, rights, create, read, edit, delete and print, with no ledger, Rojmel or stock rows (PR #22) | Conversion lineage into wholesale sale (with N46) |
| N39 | planned | in-progress | Estimate prints the active company name (PR #12) | G49: persisted estimate and full company header |
| N40 | planned | in-progress | Hallmark Sale reopen, edit, delete and voucher list (PR #15) | G45: unchanged saves lose data |
| N41 | planned | implemented-unverified | Labour previews read `LBR_WITH_GHT` (PR #14) | Desktop comparison |
| N42 | planned | implemented-unverified | `EMP_CODE_MANDATORY` enforced with the desktop message (PR #14) | Desktop comparison |
| N43 | planned | in-progress | Canonical O/D/T copy labels for sales, purchase, purchase return and karigar documents (PR #20) | Template registry and resolver (needs N73), HUID print, variants |
| N45 | planned | in-progress | Wholesale/rate cut own and persist the hidden voucher identity and `TEMP_BOOK_DATA` (PR #21) | Remaining X16 branches |

## 3. Gap register G20–G66

Severity as in document 10: **S1** blocks a daily workflow, loses data, prints a wrong legal or financial document,
or is a security exposure; **S2** wrong or incomplete in a supported branch; **S3** depth or ergonomics.

| ID | Sev | Area | Desktop authority | Web evidence | Required behaviour | Slice |
|---|---|---|---|---|---|---|
| G20 | S2 | Test type safety in CI | — | `pnpm typecheck:tests` was red at `0da250a` and is green at `dcba5a4`; `.github/workflows/ci.yml` never runs it, nor a strict compile of core tests | CI fails on any test type error | N47 |
| G21 | S3 | Documentation and plan integrity | — | `pnpm docs:refs` red: `web/docs/TECHNICAL-REFERENCE.md:27,39` claim 266 API test files (289 exist); neither `docs:refs` nor `validate_plan.py` runs in CI | Executable documentation claims and plan integrity are CI gates | N47 |
| G22 | S2 | Rounding-kernel adoption | Desktop `Strings.Format` versus `.NET Math.Round` semantics (document 03, numeric profiles) | `web/scripts/check-kernel-conformance.mjs:37` ceiling 108; 124 module-local helpers in 80 files; the mirror test `apps/api/test/kernelConformance.test.ts:66` uses another scope and ceiling (125); 21 sites added since the baseline; script not in CI | One site-identity baseline shared by script and test, CI-enforced, additions refused, burn-down to zero | N48 |
| G23 | S2 | Zero-mock browser suite | — | `web/apps/web/test/tag-split.journey.mjs:253` updates an `SRNO_MAST` row that `vouchers/numbering.ts:165-198` creates lazily, so on a clean database the update matches no row and the assertion at `:514` fails; 10 of 24 journeys never run; suite not in CI | Hermetic seeds with asserted row counts; full suite green and blocking in CI | N49 |
| G24 | S2 | Test isolation | — | `web/scripts/parity-test-env.mjs:34-45` and `docker-compose.parity-test.yml` fix port 55433 and the compose project; `parity.real-stack.mjs:122-134` fixes ports 4410/4411; `apps/api/test/globalSetup.ts:44` checks only `SELECT 1`. During the audit another session's container on the same port broke an API run | Per-worktree project and ports; database identity asserted before and after; deterministic teardown | N49 |
| G25 | S1 | Request validation | The desktop validates in the form before save | 0 of 288 mutation routes declare `schema.body`; `routes/txn.ts:883` casts the raw body. `POST /sales` with `lines:[null]` returns 500 (`sales.ts:738`); `POST /estimate` with `otherAmount:'zz'` returns 500 `[DecimalError]` (`packages/core/src/calc.ts:44`) | Every mutation has a JSON Schema; malformed input is a 400 with field paths and never reaches a writer | N50 |
| G26 | S2 | Sales-return admissibility | `TR_SALE_RTN.cs:12396-12405` "Please Insert Item Value and try"; `TR_SALE.cs:15092` | `POST /sales-returns` with `lines:[{itCode:'GOLD'}]` returned 201 and wrote SRT/00001 with a +0.000 g `MAIN_STOCK` row (`salesReturn.ts:248-256,543`) | Refuse rows and vouchers without item value with the desktop message; no zero stock rows | N50 |
| G27 | S1 | Concurrent edits | One operator holds a desktop voucher | Only sales order, tour order and the saved-return numeric path require a version; the e-bill token is optional; `DELETE /sales/00001` without any version returned 200; `vouchers/lifecycle.ts:108-137` locks but returns no version | Every voucher GET returns a version; PUT and DELETE require it; a stale request is a 409 with no write | N51 |
| G28 | S1 | Voucher identity in recent lists | Voucher key is company, location, year, book, number | `vouchers/list.ts:72` filters only company and book (no location or year); PR #18 makes `VoucherList.tsx:57` forward the book but not year or location, and the sales page offers no load from the list | Recent lists carry and use the complete key for load and delete | N51 |
| G29 | S1 | Duplicate submission | — | Two identical `POST /receipts` created RCT/00002 and RCT/00003; financial creates carry no command identity (only messaging and data repair are idempotent) | Same key returns the same result with one write set; same key with a different payload is a 409 | N52 |
| G30 | S2 | Transaction budgets | — | About 525 `withTenant` calls in `apps/api/src`, 6 with an explicit timeout, so Prisma's implicit 5 s applies (`packages/db/src/tenant.ts:11-26`); `posting/posting.ts:391-438` queries `information_schema` inside the posting transaction | Column metadata warmed at startup; explicit per-command budgets; a timeout is a retryable 503 with full rollback | N53 |
| G31 | S2 | Loyalty redemption | Points balance is the `POINT_DATA` ledger | `membership/membership.ts:98-107` reads the balance before taking any lock; two sessions can redeem the same points | Member row locked before the balance read | N53 |
| G32 | S1 | Server rendering security | Crystal owns templates; clients never send layouts | `POST /render/pdf` (`routes/txn.ts:6246`) is a SYSTEM route (`rbac/routePolicy.ts:44`), so any signed-in user can render arbitrary HTML in Chromium started with `--no-sandbox` (`reports/render.ts:130`) through `setContent` without request interception (`:202`) | No client HTML; server-owned document identities; print rights; JavaScript off, network blocked, sandboxed, size and time limits | N54 |
| G33 | S2 | Messaging truthfulness | A failed gateway send is not a success | `integrations/messaging.ts:45-50,209` fall back to `FakeMessageSender`, which reports `status:'sent'` when credentials are missing, in any environment | Production refuses unconfigured sends; fake mode only in explicit test mode, labelled simulated | N54 |
| G34 | S2 | Authentication hardening | — | Login is limited only by an in-memory 10/minute per-IP rule (`app.ts:481`); no account lockout; Argon2 defaults (4 MiB memory) because `auth/password.ts:5` passes no options; no Origin or Fetch-Metadata check on cookie-authenticated mutations; production tenant falls back to `'default'` (`ops/runtimeConfig.ts:42`) | Persistent account-and-IP throttle, explicit Argon2id parameters, origin enforcement, mandatory production tenant | N55 |
| G35 | S2 | Audit atomicity | `DELETE_DATA` and `USER_DATA` are written with the voucher | The mutation audit runs in `onResponse` (`app.ts:176`) in a separate transaction and ignores failures (`ops/audit.ts`) | Audit event written inside the business transaction; export through an outbox | N55 |
| G36 | S1 | Printed dates | Desktop display format `dd/MM/yyyy` (847 literals in the desktop source) | `String(h.VCH_DATE).slice(0, 10)` turns a JavaScript `Date` into "Thu Oct 01" at `sales/invoice.ts:60`, `purchase/purchaseBill.ts:56` (also used by the purchase-return print), `finance/financeVoucher.ts:137`, `manufacturing/karigarVoucher.ts:110` and `masters/rate.ts:50`; the printed tax invoice showed no year | Shared date helpers; every document prints `dd/MM/yyyy`; a conformance rule forbids the pattern | N56 |
| G37 | S2 | Report presentation | Report-specific formats and totals | The generic report table (`reports/[report]/page.tsx:262`) prints raw values: the cash book shows `2026-10-01T00:00:00.000Z`; amounts lack Indian grouping; server totals are not shown; PDF totals are inferred by summing numeric-looking columns | Typed column descriptors, desktop date format, `en-IN` grouping, authoritative totals, identical PDF/CSV/XLSX | N57 |
| G38 | S1 | Company provisioning | `MS_YEAR.cs:1504-1600` `NewCompParmCreat` copies 17 tables from a chosen company or company 01; the seed holds 35 `AC_GROUP`, 89 default accounts, 226 books, 494 book details, 5 `BAL_GR`, 9 `PRINT_MAST`, 699 `COL_MAST` rows | `ops/seedCompany.ts:289` writes 9 tables (`CO_MAST`, `LOCT_MAST`, `YEAR_MAST`, `CO_SET`, `BOOK_DATA`, `BOOK_DETL`, `AC_MAST`, `TAX_MAST`, `SRNO_MAST`); no account groups, closing-stock groups, item groups, items, products, employee, column, print, extended-setting, conversion, counter or state masters | Provisioning reproduces the desktop copy set from a pinned template or a source company | N58 |
| G39 | S1 | Identity conventions | Every desktop database uses location `00` for the location, books and postings; 3-digit numeric books; a 5-digit default chart; ledger keys start `0100` | Web provisions location `01` (`seedCompany.ts:296`), books `SL`, `PR`, `RCT`…, accounts `CASH`, `SALES`…; a 2-letter book produces a 22-character ledger key instead of 23 | Web-created and migrated companies share one desktop-shaped identity convention (D15) | N58 |
| G40 | S1 | Account and book literals | Accounts come from `BOOK_DETL` slots, `GROUP_MAST`, `TAX_MAST` and settings; books from `CurBookHelp` (`DC_Main.cs:1489-1521`) | Writers fall back to `'CASH'`, `'SALES'`, `'GST'`, `'GSTINPUT'`, `'PURCHASE'`, `'ROUNDOFF'`, `'KASAR'`… (for example `sales/salesReturn.ts:257-258`) and to literal books `'SAL'`, `'PUR'`, `'SRT'`, `'PRT'`, `'ORC'`, `'CTR'`, `'TRR'`, `'PNT'`, `'SAJ'`, `'DIS'`, `'MIS'`, `'MRC'`… | Configured roles only; a missing configuration fails before numbering | N59 |
| G41 | S2 | Location fallbacks | Location comes from the session | `?? '01'` in `finance/billToBill.ts:186,193,375`, `masters/party.ts:27`, `masters/openingBalance.ts:110`, `masters/dailyRate.ts:95`, `masters/year.ts:167` | Complete session scope or refusal | N59 |
| G42 | S2 | Descriptive companions | `TR_SALE.cs:15188-15199` stores the party name; the desktop fills it on all 194 sales checked | A browser sale stored `SL_DATA.AC_NAME=''` because `sales/sales.ts:1356` takes an optional client value; the corrected differential also lists blank `LDR_NAME`, `IT_DESC`, `ITM_REMARK`, `EMP_CODE`, `TBL_CODE`, `STK_DATE`, `PR_CODE`, `RATE_TYPE`, `KR_NAME` | The server resolves and stores companions in the posting transaction | N61 |
| G43 | S2 | Book selectors | `CurBookHelp` lists in-use books of one `MAIN_BOOK` | `components/BookSelect.tsx` lists every book when `mainBooks` is omitted; Purchase Invoice offered contra, journal, karigar and payment books (`txn/purchase/page.tsx:537`); about 20 transaction screens are unfiltered | Every transaction selector filtered by workflow family; the server refuses the wrong family | N62 |
| G44 | S1 | Final statements | `AC_GROUP.AC_MAIN_GR` 1–6 classify the statements; `BAL_GR` drives closing stock | On a fresh web company Profit & Loss shows no rows and the balance sheet shows only ledger totals with closing stock 0 while 11.656 g fine gold is in stock; provisioning writes no account groups | Profit & Loss and balance sheet classified by group; closing stock valued from `BAL_GR` | N60 |
| G45 | S1 | Hallmark Sale edit | `TR_SALE_HM.cs` reopens the complete voucher | `txn/hallmark-sale/page.tsx:352-388` restores about 13 of the 50+ line fields returned by `sales.ts:2304-2518`, and PUT rebuilds the full write set (`sales.ts:2607-2619`), so an unchanged save blanks HUID 2–4, HUID weights, source references and descriptors | An unchanged reopen and save changes nothing | N40 |
| G46 | S1 | Unchanged-save fidelity | Desktop reopen restores every column | The same loader/serializer gap exists on sales, sales quotation, purchase, purchase quotation, consignment purchase, hallmark purchase and tag opening | Typed lossless view-to-editor-to-command adapters per family | N63 |
| G47 | S2 | Purchase-return lifecycle remainder | `TR_KR_ISU.cs:5249-5285` (write), `:5356-5386` (delete), `:6850-6895` (source picker) | After PRs #17 and #18: no edit (PUT) lifecycle; `PR_IDTL` and `DM_DATA` are reversed but never written; the source picker does not limit quantities to what remains unreturned | Edit lifecycle, child and stone rows, residual-limited selection | N34 |
| G48 | S2 | Register-family remainder | `RP_ALL.cs:7826-7890` | Unclassified queries remain in `reports3.ts:37,68,138`, `reports9.ts:88-89,124`, `reports.ts:513`, `reports5.ts:68`, `reports8.ts:86-89`, `reports2.ts:116`, `reports7.ts:120`; literal `'SRT'` in `reports4.ts:54`; a name heuristic in `reports6.ts:50-55` | Every family report classifies by `MAIN_BOOK` and stored amounts | N36 |
| G49 | S2 | Estimate | Book 032 (MIXSL) persists in `SL_DATA` with ledger effects; `TR_SALE.cs:14168-14184` estimate tax setting | `POST /estimate` (`routes/txn.ts:1215`) writes nothing; the print shows the company name but no address or GSTIN | Persisted estimate book mode with the complete company header | N39 |
| G50 | S2 | Cash/bank lifecycle | `TR_CASH.cs:2742-3200` browse, reopen, edit, delete, print | `components/PaymentForm.tsx` only creates and prints; `GET /receipts/:vchNo` and `GET /payments/:vchNo` (`routes/txn.ts:7601,7609`) and DELETE exist; `editReceipt` (`finance/finance.ts:1404`) has no route; no payment edit | Reopen, edit, delete and reprint from the receipt and payment screens, single and multi-line | N64 |
| G51 | S2 | Dhiran and loan lifecycle | `TR_DHRN_ISU.cs:4844-5524`, `TR_DHRN_REC.cs:5771-6384`, `TR_DHRN_INTREC.cs:4442-4694` | The five loan screens only create; no saved read, edit, delete or print routes; `deleteDhrn` (`dhrn/dhrn.ts:1058-1080`) has no route | Full lifecycle per mode with packet residuals and dependency guards | N65 |
| G52 | S2 | Scheme members | `MS_MEMB.cs:4824-4915` maintains `AD_MEMB`; `TR_MEMB_ENT.cs:4269-4807` | The web "Members & Loyalty" screen is the `POINT_*` loyalty ledger (`membership/membership.ts:4-8`); no `AD_MEMB` master; `editSchemeInstallment` has no route | Separate scheme-member master; scheme entry reopen, edit, delete, print; loyalty relabelled | N66 |
| G53 | S2 | Create-only screens over existing APIs | Desktop full lifecycle | Bullion Sale page only creates although GET, PUT and DELETE exist; karigar issue/receive (`components/KarigarForm.tsx`) only creates although CRUD exists; the party master ignores a create conflict and offers no update or delete | The screens use the existing lifecycle APIs | N67 |
| G54 | S2 | Missing lifecycle services | `TR_BUL_BOOKING.cs:2805-3295`, `TR_BILL_TO.cs:4361-5010`, `TR_INOUT.cs:661-739`, `TR_TAG_OPBL.cs:853-931` | Bullion booking only creates and deletes; bill-to-bill only settles and deletes; stock in/out and tag opening have no print | Read, edit and print services and screens | N68 |
| G55 | S2 | Master semantics | `MS_AUTO_ITEM.cs:2893-2910` (code and name built from product and group, stock flags); `MS_AUTO_ITEM.cs:2450-2660` (labour update on unsold tags, labour master mode) | `masters/autoItem.ts:43-70` reverses the code/name order and writes 8 columns; `masters/labourUpdate.ts:52-87` changes 4 `ITEM_MAST` columns only | Desktop-equivalent auto item and labour update | N69 |
| G56 | S2 | Missing desktop menus | `MDI_FORM.cs:9321` Tour Sales → `TR_TOUR_SALE`; `:8456` Card Rec → `TR_CARD_REC` (`CARD_DATA`); `:10774` Cust Entry → `UT_CUST_ENTRY` (`CUST_DATA`, `CUST_DETL`) | No equivalent workflow; the completion register maps Tour Sales to the approval bill bridge and Cust Entry to a report | Distinct workflows and corrected register mappings | N70 |
| G57 | S2 | Manufacturing books and families | Desktop selects process books (`MDI_FORM.cs:9257,9268`); `TR_MFG_ORD_ISU.cs:5527-6020` writes `APR_DATA`, `APR_DETL`, `APR_IDTL`, `MFG_DETL` and stock | PR #19 validates jobwork books only; generic `POST /mfg/issue` and `/mfg/receive` accept any book and key vouchers by literal `MIS`/`MRC` when no book is sent (`manufacturing/mfg.ts:96-97,416`); `POST /mfg/order-issue` (`routes/txn.ts:3746`) writes `MFG_*` through `issueMfg` | Family-validated books everywhere; order issue as the APR-family writer | N71 |
| G58 | S2 | Desktop screens outside the menu table | About 60 dispatch labels without `MENU_DATA` rows (manufacturing stages, Jadtar, B2B, Hedging Fix, Item Purc/Sales, MRP Update, Bill Interest, Day Work, Franchise, Digital Gold) with in-use seed books such as 730/735, 740, 112/113 | No web workflow and no scope decision | Per-family decision (D21); must-have families implemented | N72 |
| G59 | S1 | Print-format registry | `PRINT_MAST(CO_CODE, PRINT_TYPE, PRINT_FILE, BOOK_TYPE, PRINT_SET_A)`; `TR_SALE.cs:13933-13963,16484-16500,20620-20622` | `masters/configs.ts:344-348` keys the table by company and print type only, so several files per print type collide; no print path reads it | Desktop natural key, one default per print type and book type, seeded from the template, consumed by N43 | N73 |
| G60 | S1 | Crystal template coverage | 255 `.rpt` templates with callers in desktop forms | 28 of 254 specs have binding contracts (`reports/reportBindingContract.ts`); transaction prints use generic HTML (`documents/docChrome.ts`) | Daily, accounting/statutory, stock/label and service documents bound, wired and certified in waves | N74, N75 |
| G61 | S2 | Language | `Translator.cs:117-128`, `UT_SMS.cs:3218-3222`; Gujarati Crystal font KAP139 (`extraction_output/rpt_xml/Form8.xml:353`) | No internationalisation; `app/layout.tsx` fixes English; no Gujarati or Hindi labels or prints | Reviewed catalogues, per-user UI language, per-template print language, embedded Unicode fonts | N76 |
| G62 | S2 | Operator layout parity | WinForms field and tab order; `COL_MAST` captions and visibility (`TR_SALE.cs:9038-9049`) | No screen uses the extracted layout data; the column-settings editor exists but transaction grids ignore `COL_MAST` | Semantic layout and tab/focus parity for the top 20 forms; grids apply `COL_MAST` | N77 |
| G63 | S1 | Data migration | 145 desktop tables in the real-schema baseline | `api/integration/cutover.mjs` covers 42 tables, extracts without scope, deletes the whole tenant table (`:450`), labels mismatches `dry-run` (`:336`) and continues on missing tables (`:262`); production load is contained | Signed ownership manifest for every table, scoped shadow loads, fail-closed validators, two rehearsals | N78, N79 |
| G64 | S1 | Deployment and recovery | — | `web/docker-compose.yml` publishes database 5433, API 4000 and web 4001 on all interfaces; no `.dockerignore`; stale `web/deploy/docker-compose.prod.yml`; `web/deploy/backup.sh` keeps a local unencrypted dump with no off-host copy; no scheduled restore drill; no upgrade or rollback runbook | TLS edge only; private services; sanitized build context; encrypted off-host backups; timed restore drill; rehearsed upgrade and rollback | N80 |
| G65 | S1 | Secrets and delivery source | — | `SECURITY-NOTICE.md` records intentionally tracked credentials; tracked `web/.env`, `web/.env.parity-test`, `web/packages/db/.env`; no secret scanning in CI | Sanitized history-free deployment source; rotated credentials; CI scanning and push protection | N81 |
| G66 | S2 | Release-certification coverage | Document 04 gates R02, R03, R08, R09, R12 | `ops/releaseCertification.ts` declares 19 gates; none covers test type compilation, documentation/plan integrity, the two additional real-browser suites, hardware/providers, migration continuation or business UAT | Exact-set, candidate-bound gates for each missing family | N82 |

## 4. Decisions D15–D22

They continue document 08 §1 (D01–D14) and use the same rules. Each needs owner approval before its first slice
starts. The recommended position is the starting point, not a decision already made.

| ID | Decision and recommended position | Owner / deadline | Evidence |
|---|---|---|---|
| D15 | Identity convention. Web-provisioned companies use the desktop convention: first location `00`, 3-digit book codes from the template, the 5-digit default chart (`00001` cash on hand, `00003` gold sales, `00008` gold purchase, `00085`–`00087` GST, CGST, IGST…) and account roles in `BOOK_DETL`. Existing web-only test tenants keep their mnemonic data; N59 removes the literal fallbacks that depend on it. Rejected: keeping mnemonic codes, which leaves two conventions that every reader, report and migration must handle | Product owner and data lead, before N58 | `desktop-conventions.json`; `MS_YEAR.cs:1504-1600` |
| D16 | Request validation. Plain JSON Schema objects per route, compiled by Fastify's built-in Ajv with `removeAdditional:false`, `coerceTypes:false`, `useDefaults:false` and `additionalProperties:false`; no new dependency; errors become `400 {error:'invalid-request', fields:[…]}`. Rejected: Zod (new dependency); TypeScript types alone (erased at runtime). Fastify's defaults strip unknown fields and coerce types silently, which would hide UI drift | API lead, N50 | `app.ts:117` creates Fastify without Ajv options |
| D17 | Concurrency token. Every voucher GET returns `version`, the SHA-256 (64 hex) of the canonical complete write set; PUT and DELETE require `expectedVersion`; a stale token is `409 voucher-version-conflict`. Rejected: PostgreSQL `xmin` (one row only), optional tokens, lock-only checks | API lead, N51 | Sales-order pattern `sales/salesOrder.ts:1368-1414` |
| D18 | Idempotency. Financial creates require an `Idempotency-Key` header; an `api_command_receipt` row (tenant, key, request hash, response, expiry) is written in the same transaction; same key and hash replays the stored response; a different hash is `409 idempotency-key-reused`; 30-day retention unless the finance owner sets another | API lead and finance owner, N52 | Duplicate receipts observed |
| D19 | Formats. The API carries calendar dates as `YYYY-MM-DD` and never shifts them between time zones; screens and prints show `dd/MM/yyyy`; amounts use `en-IN` grouping with 2 decimals; weights 3 decimals unless company precision settings say otherwise | UX and domain lead, N56 | Desktop source format literals |
| D20 | Layout parity is semantic, not pixel-exact: same regions, visible field order, tab and focus graph, captions, grid column order and `COL_MAST` captions and visibility. Responsive reflow is allowed; operators approve each deviation | Operators and UX, N77 | `forms/formLayoutEngine.ts` is preview-only |
| D21 | Screens outside the menu table are in scope for a customer when any of their books is in use (`BOOK_DATA.CUR_USE='Y'`) or their edition setting is on; otherwise they are recorded as deferred with the evidence. Rejected: implementing every family (unbounded) or none (silent loss) | Product owner and desktop specialist, N72 | Seed books in use |
| D22 | Language. No runtime machine translation; reviewed catalogues `en-IN`, `gu-IN`, `hi-IN` seeded from desktop captions, messages and report text; UI language per user with a company default; print language per template; Unicode Gujarati fonts embedded in PDFs | Product owner and translators, N76 | `Translator.cs` uses an online translator only for SMS/WhatsApp text |

## 5. Execution order

Relative sizes are for one engineer and are not delivery dates: **S** up to 2 days, **M** up to a week, **L** up
to three weeks, **XL** more. Document 02 §1 still applies: estimate after the slice's inventory exists.

| Phase | Purpose | Slices | Exit gate |
|---|---|---|---|
| A — Trustworthy build | Gates and harness must be green before more behaviour is claimed | N47, N48 (restore milestone), N49 | Every engineering gate, including the 24-journey browser suite, is green and blocking in CI |
| B — Stop wrong documents and data loss | S1 defects with small, local fixes | N56, N53, N40, N51 milestone 1 (recent-list identity), N50 milestone 1 (sales, estimate, returns, purchase, receipts, payments), N54 milestone 1 (remove raw PDF rendering), N34 remainder | Printed dates carry the year; no observed 500; no edit loses data; the timeout test is stable |
| C — Multi-user and data foundations | Contracts every later slice depends on | N50, N51, N52, N55, N58, N59, N60, N61, N62, N63 | Schemas, versions and idempotency on every financial path; desktop-shaped provisioning; no literal fallbacks |
| D — Workflow completeness | Finish the screens desktop operators use daily | N64–N72 with existing N20–N23, N32, N37, N38, N44–N46 | Each workflow passes create, reopen, edit, delete and print with its write set and journey |
| E — Documents and operator experience | Desktop-equivalent prints, reports, language and layout | N57, N73, N43, N74, N75, N76, N77 with N24 | Wave A–D templates certified; top 20 forms pass layout comparison |
| F — Migration, operations and release | Move real customers safely and certify | N78, N79 (complete N27), N80, N81, N82 with N25, N28–N30 | Two clean migration rehearsals; restore drill meets RPO/RTO; release certifier passes on one candidate |

N81 has no product dependency and can run alongside phase A. Phases overlap where dependencies allow, but changes
to shared posting, numbering, scope and rounding code pass through one integration owner (document 02 §2).

**First implementation queue** (in order): N47; N49 step 1 (tag-split seed); N53; N56; N51 milestone 1; N54
milestone 1; N40; N50 milestone 1; N48 restore milestone; N58 template generator.

### Slice index

| Slice | Workstream | Title | Gaps | Start after | Phase | Size |
|---|---|---|---|---|---|---|
| N47 | WS1 Gates | Restore red engineering gates and run them in CI | G20, G21 | — | A | S |
| N48 | WS1 Gates | Kernel conformance by site identity; restore and burn down | G22 | N47 | A | L |
| N49 | WS1 Gates | Hermetic, isolated database and browser harness in CI | G23, G24 | N47 | A | L |
| N50 | WS2 API integrity | Runtime request schemas and admissibility | G25, G26 | N47 | B/C | XL |
| N51 | WS2 API integrity | Version tokens on every voucher edit/delete; full identity in lists | G27, G28 | N50 | B/C | XL |
| N52 | WS2 API integrity | Idempotent financial commands | G29 | N50 | C | L |
| N53 | WS2 API integrity | Transaction budgets and loyalty redemption locking | G30, G31 | N47 | B | M |
| N54 | WS2 API integrity | Rendering and messaging safety | G32, G33 | N50 | B/C | L |
| N55 | WS2 API integrity | Authentication hardening and atomic audit | G34, G35 | N50 | C | L |
| N56 | WS3 Documents | Canonical date transport and display | G36 | N47 | B | M |
| N57 | WS3 Documents | Typed report grid and export parity | G37 | N56 | E | M |
| N58 | WS4 Conventions | Desktop-equivalent company provisioning | G38, G39 | N49 | C | XL |
| N59 | WS4 Conventions | Configured accounts, books and locations only | G40, G41 | N58 | C | XL |
| N60 | WS4 Conventions | Final statements on provisioned and migrated companies | G44 | N58 | C | M |
| N61 | WS4 Conventions | Descriptive companion columns | G42 | N59 | C | L |
| N62 | WS4 Conventions | Book selectors by workflow family | G43 | N58 | C | M |
| N63 | WS5 Workflows | Lossless reopen/edit adapters | G46 | N51 | C | L |
| N64 | WS5 Workflows | Cash and bank receipt/payment lifecycle | G50 | N51, N52 | D | M |
| N65 | WS5 Workflows | Dhiran and loan lifecycles | G51 | N51 | D | XL |
| N66 | WS5 Workflows | Scheme members and scheme entry lifecycle | G52 | N51 | D | L |
| N67 | WS5 Workflows | Existing lifecycle APIs wired into create-only screens | G53 | N63 | D | M |
| N68 | WS5 Workflows | Missing lifecycle services | G54 | N51 | D | L |
| N69 | WS5 Workflows | Master semantic corrections | G55 | N58 | D | M |
| N70 | WS5 Workflows | Missing desktop menus | G56 | N63 | D | XL |
| N71 | WS5 Workflows | Manufacturing books and order-issue family | G57 | N59 | D | L |
| N72 | WS5 Workflows | Desktop screens outside the menu table | G58 | N71 | D | XL |
| N73 | WS6 Documents | Print-format registry identity and administration | G59 | N58 | E | M |
| N74 | WS6 Documents | Crystal binding wave A: daily documents | G60 | N73, N43 | E | XL |
| N75 | WS6 Documents | Crystal binding waves B–D | G60 | N74 | E | XL |
| N76 | WS6 Documents | Internationalisation (Gujarati, Hindi) | G61 | N57 | E | L |
| N77 | WS6 Documents | Semantic layout and tab-order parity for 20 forms | G62 | N63 | E | L |
| N78 | WS7 Operations | Migration ownership manifest and fail-closed validator | G63 | N58, N59 | F | XL |
| N79 | WS7 Operations | Scoped shadow loading, reconciliation and two rehearsals | G63 | N78 | F | XL |
| N80 | WS7 Operations | Production deployment hardening and disaster recovery | G64 | N49 | F | XL |
| N81 | WS7 Operations | Secrets hygiene and sanitized delivery source | G65 | N47 | A/F | L |
| N82 | WS7 Operations | Release-certification gate completion | G66 | N47, N49 | F | XL |

## 6. Slice specifications

Each card follows the ready-to-implement definition in document 02 §4. Code paths are relative to `web/`; paths
that start with `unified/`, `project-memory/`, `docs/master-parity-plan-2026-09-29/` or `.github/` are relative to
the repository root. Line anchors are at the plan baseline; re-confirm them on the implementation branch, because
`main` moves daily.

### WS1 — Engineering gates and harness

#### N47 — Restore red engineering gates and run them in CI

Gaps G20, G21 · Parents P00-04, P00-05; X03, X34 · S2 · Size S · Start after: none

CI can be green while the repository's own gates are red. `typecheck:tests` was red at the audit commit (fixed by
PR #18), `docs:refs` is red, and CI runs neither, nor the plan validator.

Steps:
1. Update the count in `docs/TECHNICAL-REFERENCE.md:27,39` and re-check the neighbouring inventory rows. Keep each
   number tied to its `verify` command so it cannot drift silently.
2. Add a blocking `static-gates` job to `.github/workflows/ci.yml` (frozen install, Prisma generate) that runs
   `pnpm typecheck:tests`, `pnpm docs:refs` and `python3 docs/master-parity-plan-2026-09-29/validate_plan.py`.
3. Add `packages/core/tsconfig.test.json` covering every `packages/core/test/*.test.ts` with the strict options of
   the document 04 §5 recipe, a `typecheck:tests` script in `packages/core/package.json`, and call it from the root
   `typecheck:tests` script.
4. Keep the PR #18 assertions in `apps/api/test/registerClassify.db.test.ts:115-121`; a missing `totals` still
   fails because `undefined` is not 1000.

Tests: on a scratch branch, a type error in a test file, a stale documentation claim and a broken plan link each
fail CI.

Done when: the three commands exit 0 locally and in CI on `main`, and each one fails CI when broken.

#### N48 — Kernel conformance by site identity; restore and burn down

Gap G22 · Parents P01-02, P00-05; X04, X06 · S2 · Size L · Start after N47

There are 124 module-local rounding helpers against a ceiling of 108. The script
(`scripts/check-kernel-conformance.mjs:37`, API sources) and its mirror test
(`apps/api/test/kernelConformance.test.ts:66`, API and core, ceiling 125) disagree, and a total-count ratchet lets
an addition hide behind an unrelated removal.

Design: one checked-in baseline, `parity/kernel-conformance-baseline.json`, holding the scanned roots, exemptions,
rule set and the exact grandfathered site IDs (`<path>#<helper or formula fingerprint>`). Script and test both load
it. A site not in the baseline fails; removing a site deletes its ID in the same change. CI never runs a write mode.

Steps:
1. Generate the baseline from the last reviewed 108-site tree (the parent of `b533d6a`), review it, and record the
   21 later additions as violations: `einvoice/einvoiceExport.ts:117-118`, `membership/scheme.ts:1383`,
   `purchase/otherIncome.ts:162-163`, `reports/consiReport.ts:8-9`, `reports/graphReport.ts:36-37`,
   `reports/manufacturingReports.ts:8-9`, `reports/otherItemReport.ts:20-21`, `reports/branchInoutReport.ts:11`,
   `reports/designMoveReport.ts:11`, `reports/oldStockReport.ts:13`, `reports/tourReports.ts:12`,
   `reports/tradingReport.ts:10-11`, `stock/stockInout.ts:189`, `stock/tagSplitRows.ts:46` (resolve by helper
   identity, not line).
2. Replace each addition with the primitive that matches its desktop source: `round` for `Strings.Format`,
   `roundHalfEven` for `.NET Math.Round` (`packages/core/src/money.ts`), `decimalCellText` at text boundaries,
   `resolveRoundingPolicy` for company precision settings (`modules/shared/roundingPolicy.ts`). Report builders keep
   exact numerics and format only at output (N57).
3. Point the script and the test at the baseline and add the script to the N47 job as blocking.
4. Burn down to zero in milestones owned by whichever slice next touches the file: posting families (sales,
   purchase, stock), then finance, then reports (after N57), then the rest. Move the five inline `BOOK_DETL` reads
   (`sales/rateCut.ts:241`, `repair/repairReceipt.ts:394`, `repair/repairWorkflowCommon.ts:123`,
   `repair/repairCustomerIssue.ts:295`, `repair/repairKarigarReceipt.ts:281`) to
   `postingAccounts.resolveBookSlotRowsTx` once N59 settles location precedence.

Tests: detector positive and negative controls; exact site-set equality between script and test; signed midpoint
vectors (±x.5, ±x.005) for every migrated helper; write-set tests of the touched writers.

Done when: script and test report the same site IDs, CI blocks any new site, at most 108 sites remain (the 21
additions removed), and the burn-down table is in the progress record.

#### N49 — Hermetic, isolated database and browser harness in CI

Gaps G23, G24 · Parents P00-04; X03 · S2 · Size L · Start after N47

Steps:
1. `apps/web/test/tag-split.journey.mjs:253`: replace the `UPDATE "SRNO_MAST"` with an upsert on
   `(tenant_id, "CO_CODE", "LC_CODE")` that sets `TAG_SRNO` to 9000; delete that exact row in cleanup (`:285`);
   assert that the `CO_SET` update at `:121` affected one row. Children then become RH9001 and RH9002 and the
   assertion at `:514` holds on a clean database.
2. Make every seed `UPDATE` in `apps/web/test/*.journey.mjs` either an upsert or an asserted row count
   (`sale-amount-basis.journey.mjs:22`, `sales-return-replay.journey.mjs:52,57`,
   `sales-return-bill-replay.journey.mjs:84,89`, `sales-return-labour-replay.journey.mjs:113,123`,
   `e-invoice-entry.journey.mjs:63`, `repair-image-conflict.journey.mjs:74`), and add a static test that fails on a
   seed `UPDATE` without one. Cleanup statements may be idempotent no-ops and must say so.
3. `scripts/parity-test-env.mjs` and `docker-compose.parity-test.yml`: `PARITY_TEST_PORT` (default 55433); a compose
   project derived from a hash of the worktree path (override `PARITY_TEST_PROJECT`); a per-project credentials file
   outside the repository; `down --volumes` in `finally`; pass the project, container ID and
   `pg_control_system().system_identifier` to the child process and re-check them after it exits.
4. `PARITY_API_PORT` and `PARITY_WEB_PORT` (defaults 4410 and 4411) in `apps/web/test/parity.real-stack.mjs`,
   `session-context.real-stack.additive.mjs` and `labour-preview-lifecycle.real-stack.mjs`; build Next with the
   matching `API_ORIGIN`, which is fixed at build time (`apps/web/next.config.mjs`).
5. `apps/api/test/globalSetup.ts`: before enabling database tests, verify host, port, database, the expected system
   identifier, and that the runtime role is `app_user` without superuser or BYPASSRLS; replace the per-test literal
   port checks with one helper.
6. CI job `real-stack-browser`: install Chromium with its dependencies; build the API; build the web with the
   matching `API_ORIGIN`; run the three suites through the wrapper; upload `result.json` and screenshots on
   failure; always tear down; 30-minute timeout.

Tests: two consecutive runs from an empty volume; two worktrees in parallel on different ports; replacing the
container mid-run fails with an identity error; the static test catches a planted unasserted seed update.

Done when: all 24 journeys and the two additional suites pass twice in a row from a clean volume, and the CI job
blocks merges.

### WS2 — API contract, integrity and security

#### N50 — Runtime request schemas and admissibility

Gaps G25, G26 · Parents P01-04, P02-06; X05, X13 · S1 · Size XL · Start after N47 · Decision D16

Schemas describe what the screens actually send, including `coBook`, `coYear`, `lcCode` and every line array, not
only the module interfaces. Domain validation stays as a second line of defence.

Steps:
1. `apps/api/src/app.ts:117`: create Fastify with
   `ajv: { customOptions: { removeAdditional: false, coerceTypes: false, useDefaults: false, allErrors: true } }`.
   Add a `setErrorHandler` that turns `error.validation` into
   `400 {error:'invalid-request', fields:[{path, keyword, message}]}` without echoing the payload, and maps named
   domain errors centrally instead of the per-route pattern list (`routes/txn.ts:831`).
2. Create `apps/api/src/schemas/`: `common.ts` (scope fields, money, weight, percent, codes, bounded arrays whose
   items are non-null objects) and one module per family (sales, purchase, finance, stock, manufacturing, loans,
   scheme, utilities, masters).
3. Attach `schema.body` (plus `params` and `querystring` where read) to all 288 mutation routes:
   - Milestone 1 (phase B): `/sales`, `/estimate`, `/sales-returns`, `/purchases`, `/receipts`, `/payments` and
     their PUT and DELETE routes.
   - Then the remaining financial routes: receipts and payments multi, contra, gold book, VP adjustment, location
     amount, other commission, batch receipt, account opening, fine JV, bill-to-bill, bank clearing, rate cut,
     journal, ledger adjustment, employee JV.
   - Then inventory; manufacturing and repair; loans and scheme; utilities and administration; masters. Bodyless
     deletes get an empty-object schema.
4. Extend the `onRoute` hook (`app.ts:148`) so the application refuses to start when a POST, PUT or DELETE route
   has no `schema.body`.
5. `modules/sales/salesReturn.ts`, before numbering: every row needs a non-blank `itCode` and a non-zero net weight
   or computed net amount; a voucher whose item value sums to zero is refused with the desktop message "Please
   Insert Item Value and try"; remove the `|| 1` piece default at `:543`.

Tests:
- Per family: `lines:[null]`, a non-object line, `otherAmount:'zz'`, `"NaN"` and `"Infinity"` strings, a wrong
  enum, a missing required field and an unknown property each return 400 and change no row (counts before and
  after).
- A full payload captured from the browser for sales, purchase and receipt reaches the writer unchanged (spy):
  nothing stripped, coerced or defaulted.
- The zero-value return is refused with the desktop text and consumes no voucher number; valid tagged and loose
  returns still post and reverse.
- A contract test enumerates registered routes and requires a body schema on every mutation.

Done when: 288 of 288 mutation routes have schemas (enforced at startup), no malformed request produces a 5xx, and
the browser suites still pass.

#### N51 — Version tokens on every voucher edit and delete; full identity in lists

Gaps G27, G28 · Parents P01-04, P01-05; X05 · S1 · Size XL · Start after N50 · Decision D17

Steps:
1. Move canonical serialization and SHA-256 hashing into `modules/vouchers/version.ts`, reusing the order-version
   logic (`sales/salesOrder.ts:1368-1414`). Define per-family write-set descriptors (header, details, children,
   effect tables); N63 reuses them.
2. Every voucher GET returns `version`; every PUT and DELETE schema requires `expectedVersion` (64 hex). Writers
   lock the voucher (`vouchers/lifecycle.ts:108-137`), recompute the version in the same transaction and compare
   before changing anything; a mismatch is `409 voucher-version-conflict`.
3. E-bills: make `expectedRevision` required and 64-hex (`einvoice/eBillWriter.ts:840-870`).
4. Milestone 1 (phase B): `vouchers/list.ts` filters by tenant, company, location, year and book and returns those
   fields with `version`; `components/VoucherList.tsx` hands the row identity to parent `onLoad` and `onDelete`
   callbacks instead of building a path from the number; the sales page gains `loadSale(identity)`, which selects
   the row's book before loading.
5. Every editor keeps the loaded version and sends it on update and delete; on a 409 a banner keeps the draft and
   offers a reload.

Tests: a missing or malformed token is a 400 in every family; two sessions load one voucher, A saves, and B's PUT
and DELETE with the old token return 409 and change nothing; with the same voucher number in two books, years and
locations, only the clicked row loads or deletes; in the browser, open a recent sale in a non-default book and
delete it.

Done when: no supported voucher can be updated or deleted without its current version, and recent lists never act
on an incomplete key.

#### N52 — Idempotent financial commands

Gap G29 · Parents P01-05; X05 · S1 · Size L · Start after N50 · Decision D18

Steps:
1. Migration: `api_command_receipt(tenant_id, idempotency_key, request_sha256, method, route, co_code, lc_code,
   co_year, co_book, actor, state, http_status, response_body jsonb, resource_key jsonb, created_at, expires_at)`,
   primary key `(tenant_id, idempotency_key)`, an index on `expires_at`, forced RLS with the standard tenant policy,
   and a purge job for expired rows.
2. `modules/ops/commandReceipt.ts`: `claimCommandTx` inserts the receipt inside the business transaction; a
   conflict with the same hash returns the stored response with `Idempotency-Replayed: true`; a different hash is
   `409 idempotency-key-reused`; `completeCommandTx` stores status, body and resource key before commit, so a
   rollback removes both.
3. A pre-handler after authentication and scope requires `Idempotency-Key` (1–128 characters) on financial creates
   (sales, purchase, returns, receipts and payments single and multi, contra, journal, fine JV, rate cut, bullion,
   wholesale, other income and expenses, scheme installments, dhiran and loans) and hashes the method, route
   template, authenticated scope and body.
4. `apps/web/lib/api.ts`: `postCommand(path, body, key)`. Each draft gets a `crypto.randomUUID()` key that survives
   the token-refresh retry and a manual retry after an ambiguous network failure, and is renewed only when the
   draft changes. Wire `components/PaymentForm.tsx`, sales, purchase, returns, journal and the other financial
   forms.

Tests: sequential and barrier-synchronized duplicates create one voucher; a changed body under the same key is a
409; a dropped response followed by a retry replays the original; a validation failure leaves no receipt; tenants
are isolated; a double click on Save in the browser creates one voucher.

Done when: every financial create is exactly-once per key under concurrency, and replays are visible in the
response header.

#### N53 — Transaction budgets and loyalty redemption locking

Gaps G30, G31 · Parents P01-05, P09-04; X05, X24 · S2 · Size M · Start after N47

Steps:
1. `modules/posting/posting.ts`: export `warmPostingMetadata(prisma)`, which loads all public-schema columns in one
   query; call it in `server.ts` before `listen` (`:84-102`) and in test setup. `columnsOf` and `_hasDataType` then
   read only the cache; an unknown table is a configuration error, never a query inside a transaction.
2. `COMMAND_TX_BUDGETS`: reads 5 s (2 s wait), vouchers 20 s (5 s wait), heavy commands 30 s (10 s wait). Mutation
   coordinators pass one to `withTenant` (`packages/db/src/tenant.ts:11-26`), starting with sales, sales return
   (`salesReturn.ts:608`), purchase and receipts.
3. Central error mapping: Prisma P2028 and transaction-start timeouts become
   `503 {error:'transaction-timeout', retryable:true}` with `Retry-After: 1`; no automatic retry (N52 makes a manual
   retry safe).
4. `membership/membership.ts`: `SELECT … FOR UPDATE` on the member row (tenant, `CO_CODE`, `POINT_CODE`,
   `MEMB_CODE`) before `balanceTx`, for both earning and redeeming.
5. Publish a duration histogram per budget class on `/ops/metrics`.

Tests: after a cold start a posting transaction issues no `information_schema` query; a lock held past the budget
returns 503 and writes nothing; the `salesFamilyLifecycle.db.test.ts` case "creates, gets and replaces a sales
return" passes ten runs in a row; two sessions redeeming 80 of 100 points concurrently produce one success, a
balance of 20 and one redemption row.

Done when: no mutation path relies on the implicit 5-second default and the timeout failure no longer occurs.

#### N54 — Rendering and messaging safety

Gaps G32, G33 · Parents P10-05, P11-03; X25, X28 · S1 · Size L · Start after N50

Steps:
1. Milestone 1 (phase B): remove `POST /render/pdf` (`routes/txn.ts:6246`) and its SYSTEM entry
   (`rbac/routePolicy.ts:44`). Add server-owned `POST /estimate/pdf` (typed estimate input, by voucher key once N39
   persists estimates) and `GET /reports/:report.pdf` (filters only), built from the existing report builders and
   the bound renderer, each mapped to its form with action `print`.
2. Move the client HTML builders (`txn/estimate/page.tsx:330-345`, `reports/[report]/page.tsx:170-259`) to the
   server; screens request PDFs by identity or filter.
3. Harden `reports/render.ts`: drop `--no-sandbox` (the API image already runs unprivileged); disable JavaScript;
   abort every request with `page.route('**/*', r => r.abort())` before `setContent`; limit input to 64 KB, HTML to
   2 MB, rows to 5,000, output to 20 MB and time to 15 s, with bounded concurrency, returning 413, 422 or 503.
4. `integrations/messaging.ts`: in production a missing provider configuration yields `unconfigured`, and send
   routes return 503 before recording an attempt; the fake sender exists only with `MESSAGING_FAKE_MODE=1` outside
   production and reports `simulated`; a provider acceptance is `accepted`, and only a callback marks it delivered.
   `integrations/page.tsx` and `utilities/reminders/page.tsx` show "not delivered" or "simulated" instead of a
   success message.

Tests: a user without print rights gets 403; HTML in a request body is rejected by the schema; a fixture page with
`<script>` and a remote `<img>` proves JavaScript is off and every request is aborted; oversize and timeout cases;
estimate and report PDFs still download for the right company; production without credentials refuses to send and
records no "sent" attempt.

Done when: no client-controlled HTML reaches Chromium, the renderer is sandboxed and offline, and production never
reports a simulated delivery as sent.

#### N55 — Authentication hardening and atomic audit

Gaps G34, G35 · Parents P11-04, P12-05; X29, X31 · S2 · Size L · Start after N50

Steps:
1. `auth/password.ts`: hash with `{algorithm: Algorithm.Argon2id, version: Version.V0x13, memoryCost: 65536,
   timeCost: 3, parallelism: 1, outputLen: 32}` (option names from the installed `@node-rs/argon2` typings); rehash
   on successful login when the stored parameters are weaker.
2. A persistent login throttle keyed by an HMAC of the normalized account plus the client IP (pepper
   `AUTH_THROTTLE_PEPPER`): five failures in 15 minutes lock the pair with exponential back-off capped at one hour;
   responses are identical for known and unknown users; the per-IP limit at `app.ts:481` stays; forwarded
   addresses are trusted only from configured proxy ranges.
3. An early hook for cookie-authenticated POST, PUT and DELETE: `Origin` must equal the configured `WEB_ORIGIN` and
   `Sec-Fetch-Site` must be `same-origin`; otherwise 403 before any database work.
4. `ops/runtimeConfig.ts`: production requires a non-blank `APP_TENANT_ID`, with no fallback.
5. Audit: a migration for an append-only `audit_event` table and an `audit_outbox`; `insertAuditEventTx` inside
   every mutation coordinator (actor, request ID, form, action, scoped resource key, outcome; no bodies or personal
   data); `onResponse` logging remains only for rejected-request telemetry; an outbox exporter with idempotent
   delivery and metrics.

Tests: the stored PHC string shows argon2id with m=65536, t=3, p=1; the throttle holds across two API instances;
cross-site and missing-origin mutations get 403 while same-origin requests pass; production without
`APP_TENANT_ID` fails before listening; a forced audit-insert failure rolls back the voucher; the outbox exports
once after a retry.

Done when: all listed controls are active and tested, and every committed mutation has exactly one immutable audit
event.

### WS3 — Dates and report presentation

#### N56 — Canonical date transport and display

Gap G36 · Parents P10-05, P02-05; X25 · S1 · Size M · Start after N47 · Decision D19

Steps:
1. Add `packages/core/src/dates.ts` and export `toIsoDate(value)` (a `Date` read from a `@db.Date` column becomes
   `YYYY-MM-DD` from its UTC parts; a string must be a real calendar date or an ISO timestamp and is converted
   without a time-zone shift) and `formatDesktopDate(value)`, which returns `dd/MM/yyyy`.
2. Replace the five document sites (`sales/invoice.ts:60`, `purchase/purchaseBill.ts:56`,
   `finance/financeVoucher.ts:137`, `manufacturing/karigarVoucher.ts:110`, `masters/rate.ts:50`). Convert the other
   `String(…).slice(0, 10)` date sites for consistency: `stock/stoneDmCf.ts:639`, `stock/physicalStock.ts:492`,
   `reports/orderTagReports.ts:332,333,403,457`, `utilities/userRequest.ts:62`, `utilities/voucherRenumber.ts:177`,
   `finance/bankRecon.ts:130`, `masters/dailyRate.ts:55,139`.
3. Documents rendered through `documents/docChrome.ts` print `dd/MM/yyyy`; DTOs keep ISO dates.
4. Add a kernel-conformance concern `date-normalization`, ceiling 0, forbidding `String(…).slice(0, 10)` on date
   values outside the helper.

Tests: unit vectors for a `Date`, an ISO date, ISO timestamps at 00:00Z and at 23:30+05:30, 29 February and invalid
input; HTML snapshots of sale, purchase, purchase-return, finance and karigar documents show `01/10/2026`; the rate
list shows the full date.

Done when: no document or list prints a date without its year and the conformance rule is green.

#### N57 — Typed report grid and export parity

Gap G37 · Parents P10-02, P10-06; X26 · S2 · Size M · Start after N56 · Decision D19

Steps:
1. Report response contract `{columns:[{key, label, type, scale, align, totalKey}], rows, totals}`, with types date,
   datetime, text/id, integer, money (2), weight and fine (3, or company precision), rate and percent.
2. A shared `ReportGrid` replaces `Table` in `reports/[report]/page.tsx:262`: formatted cells and an authoritative
   `<tfoot>`. Running balances, rates, percentages and identifiers are never summed.
3. Migrate builders to descriptors: the cash book first (`reports/reports2.ts:23-55`), then ledger, Rojmel, trial
   balance, P&L, balance sheet, GSTR-1/2/3B, HSN and stock reports, then the rest. Builders not yet migrated keep
   today's renderer.
4. PDF, CSV and XLSX use the same descriptors: CSV keeps machine values (ISO dates, plain decimals), XLSX writes
   typed numeric and date cells, and the PDF matches the screen.

Tests: `2026-10-01T00:00:00.000Z` shows as `01/10/2026`; `1234567.89` as `12,34,567.89`; null, zero and negative
values; empty, single-page and multi-page reports; screen, PDF and XLSX totals equal the server totals; a running
balance is not summed.

Done when: no report shows a raw ISO timestamp, and every migrated report shows authoritative totals that are
identical across exports.

### WS4 — Provisioning and identity conventions

#### N58 — Desktop-equivalent company provisioning

Gaps G38, G39 · Parents P03-04, P03-01, P03-02; X10 · S1 · Size XL · Start after N49 · Decision D15

Desktop authority: `MS_YEAR.cs:1357-1363` calls `NewCompParmCreat` (`:1504-1600`) only when a new company is
created. With a chosen source company it copies that company's masters; otherwise it copies from company 01:
`AC_GROUP`; the default chart (`AC_MAST` with `AC_CODE < 101`); `BAL_GR`; `BOOK_DATA` and `BOOK_DETL` at location
`00`; `CO_SET`; `CO_SET_NEW`; `COL_MAST`; `CONV_MAST`; employee `001` in `EMP_MAST`; item groups `916, DM, EM, FGL,
FSL, GO, OG, ORD, OS, OT, SL, SN`; items `999, DM, EM, FSL, HM, OG, ORG, ORS, OS, OT, RD, SN`; location `00`;
`PRINT_MAST`; `PRODUCT_MAST`; `TABLE_MAST`; `TAX_MAST`. A new location copies its books from `00`
(`MS_LOCT.cs:3612-3614`).

Design:
- Template assets in `packages/db/seed-templates/datacare-next/v1/` (`index.json` plus `tables/<TABLE>.json`),
  generated by `scripts/generate-datacare-seed-template.mjs` from an authorized offline export of the desktop seed
  database (`Next24`). Configuration only, canonical column and key order, a SHA-256 per table and for the index.
  The sanitizer removes credentials, contacts, machine paths, integration identifiers and user or provenance
  columns, and neutralizes the single employee.
- The 17 tables above are allowed; `STATE_MAST` is seeded once per tenant.
- Two modes: `template` (the desktop branch without a source company) and `copy` (from a source company;
  `copyParties` copies all parties, otherwise the default chart is used). The first location is `00`.

Steps:
1. Write the generator, a JSON schema and a hash verifier; commit template v1 with its provenance (source database,
   export date, sanitizer version) in `index.json`.
2. Rewrite `ops/seedCompany.ts` (`:289`) as one create-only transaction under an advisory lock: verify template
   hashes, refuse a non-empty target with 409, apply the mode filters, and write a provisioning record (mode,
   template version and hash, source company).
3. Reduce `masters/companyClone.ts` to one manifest without duplicates (`BOOK_DETL` is declared twice, at `:238` and
   `:284`) and without tables the desktop does not copy. Because desktop year creation copies nothing for an
   existing company, call it from company provisioning only, not from `masters/year.ts:72`.
4. Provisioning API (`routes/txn.ts:4667`) and screen (`admin/provision`): mode, source company, parties
   confirmation, fixed location `00`, template version and hash, and a per-table result.
5. Creating a location copies `BOOK_DATA`, `BOOK_DETL` and `TABLE_MAST` from `00`.
6. Switch the demo seed (`apps/api/src/server.ts:30,48-77`) to template mode with numeric accounts. Move
   `provisioning.db.test.ts`, `seedCompleteness.db.test.ts` and the route tests that provision companies to
   manifest-based expectations; real-stack journeys share one desktop-shaped fixture instead of inserting mnemonic
   books.
7. Ship behind `PROVISION_TEMPLATE_V1` and flip the default once the tests have moved. Existing tenants are not
   rewritten.

Tests: on a fresh tenant a sale, a purchase, a receipt and a stock movement post and reverse; every in-use book
resolves its account slots; every book code has three characters and every baseline row uses location `00`; copy
mode equals the source table by table; a tampered template hash, a partially filled target and a re-run are all
refused.

Done when: for the 17 tables a fresh web company equals a desktop-created company in row counts and checksums, and
journey J01 runs without manual SQL.

#### N59 — Configured accounts, books and locations only

Gaps G40, G41 · Parents P01-03, P03-04; X06, X10 · S1 · Size XL · Start after N58

Steps:
1. Remove the literals family by family:
   - account fallbacks in the sales, purchase, returns, labour invoice, dhiran, bullion, fine sale/purchase,
     employee JV, sales order, bill-to-bill, ledger adjustment, tag operation, karigar and manufacturing writers;
   - literal books `SAL`, `PUR`, `SRT`, `PRT`, `LBR`, `BUL`, `FSL`, `FPR`, `ORC`, `SAJ`, `CTR`, `TRR`, `PNT`,
     `DIS`, `MLT`, `REM`, `ACO`, `FIO`, `TWD`, `TAD`, `MIS`, `MRC` and `RTC` (`SADJ` is a voucher type, not a book);
   - reader assumptions: the e-invoice default `SAL`, the `SRT` register literal, and receipt mode decided by an
     account named `CASH`;
   - screen defaults in `txn/order-cancel`, `txn/ledger-adjust` and `txn/employee-jv`.
2. Extend `shared/postingAccounts.ts` with per-family role resolution (book slot, item group, tax, setting); a
   missing role is a validation error raised before numbering.
3. Every writer requires the selected book and validates its family with `shared/bookPolicy.ts`
   (`resolveBookPolicyTx`); cash or bank mode comes from the book family.
4. Replace `?? '01'` (G41) with the authenticated session scope and refuse a missing location.
5. A static test fails on any account or book literal outside an allow-list (tests, template, display text).

Tests: a desktop-shaped fixture with numeric books and accounts posts, reads, edits and deletes in every family
without mnemonic rows; an omitted role, book or location returns 4xx with no row written and the counter unchanged;
the server refuses a wrong-family book; locations stay isolated.

Done when: the static test is green and desktop-shaped and migrated companies work end to end.

#### N60 — Final statements on provisioned and migrated companies

Gap G44 · Parents P06-06, P10-03; X16, X26 · S1 · Size M · Start after N58

Desktop authority: `AC_GROUP.AC_MAIN_GR` 1 liabilities, 2 assets, 3 trading income, 4 trading expense, 5 income,
6 expenses; `RP_BALANCE.cs:2314-2469` (trial balance, P&L, balance sheet); `BAL_GR` for closing stock.

Steps:
1. Keep `AC_MAST.AC_MAIN_GR` filled from `AC_GROUP` on provisioning, import and every account create or update.
2. Balance sheet (`reports/reports.ts:533-590`): classify accounts with `AC_MAIN_GR` below 3 by group hierarchy and
   carry the P&L result. P&L (`:595-627`): `AC_MAIN_GR` 3 and above, with a trading section and closing stock.
3. Closing stock through `reports/closingStock.ts` with the `BAL_GR` rows; an unvalued item or a missing rate is an
   explicit warning, never a silent zero.
4. Build a dataset fixture from the `Next23` and `Next25` desktop statements.

Tests: on a template company, after a sale and a purchase, P&L shows sales, purchases and gross profit, and the
balance sheet balances including the 11.656 g closing stock at the day's rate; an account without a group fails
explicitly; one company-year matches the desktop dataset.

Done when: P&L, balance sheet and closing stock are populated, balanced and equal to the desktop datasets of the
fixture.

#### N61 — Descriptive companion columns

Gap G42 · Parents P01-03; X06 · S2 · Size L · Start after N59

Steps:
1. `modules/shared/descriptiveCompanions.ts`: declarative per-table policies and `hydrateCompanionsTx`, called
   before `postVoucherTx`. Precedence: an editable value sent by the operator, then the linked source (tag, order,
   original voucher), then the scoped master, then the documented default. An unresolved required companion fails;
   header employee, counter and date flow to child rows; stored values survive a later master rename.
2. Apply in this order:
   - sales header, details and ledger: `AC_NAME`, `LDR_NAME`, `EMP_CODE`, `TBL_CODE`, `RATE_TYPE`, `PR_CODE`,
     `ITM_REMARK`;
   - stock: `STK_DATE`, `TBL_CODE`, `EMP_CODE`;
   - purchase: `IT_DESC`, `PR_CODE`, `WITH_STOCK`;
   - wholesale and rate cut: `MOBILE`, `KR_NAME`, `LBR_TYPE`;
   - documented defaults: `IRN_NO`, `ACK_NO`, `ORD_TAG_STK_ADD`, `DESIGN_IMG_ID`, `USER_DELETE`, `R_CHARG`,
     `APR_ISU`, `EMP_ISU`.
3. Screens clear a companion when its code text changes.

Tests: a code-only request stores the companions; an ambiguous or missing master fails before any write; a rename
after saving keeps the stored value; the corrected differential harness shows no blank-companion differences for
the nine fresh cases of the 28 September evaluation.

Done when: the blank-companion class of the field summary is empty.

#### N62 — Book selectors by workflow family

Gap G43 · Parents P02-01, P03-04; X07, X10 · S2 · Size M · Start after N58

| Screen under `apps/web/app/(app)/` | Desktop family (`MDI_FORM.cs` line) |
|---|---|
| `txn/purchase` | PURCHASE (7868) |
| `txn/purchase-return` | PURC RETURN (7896) |
| `txn/sale-return` | SALES RETURNE (7969) |
| `txn/hallmark-sale` | SALES (7919) |
| `txn/fine-jv` | FINE JV (8361) |
| `txn/labour-sale` | LABOUR WORK (8325) |
| `txn/batch-receipt` | CASH REC (8053) or BANK REC (8077), by tender |
| `txn/item-lot` | ITM LOT (7712) |
| `txn/tag-opening` | OPSTK (7701) |
| `txn/dhrn-issue`, `txn/dhrn-receipt`, `txn/dhrn-interest` | DHIRAN ISSUE (9527), DHIRAN RECEIVED (9539), INTREST RECIVED (9551) |
| `txn/bullion` | BUL SALE (8171) |
| `txn/fine-sale` (source purchase) | PURCHASE (7868) |
| `txn/tour` | EMP ISU (9299) |
| `txn/tag-weight-diff` | TAG WT CHANGE (8698) |
| `txn/mfg-issue`, `txn/mfg-receive` | MFG ISU ITEM (9257), MFG REC ITEM (9268) |
| `txn/item-opening`, `txn/ac-opbl` | No selector; the desktop opens these directly (7690) with fixed book `000` |
| `txn/journal` | Decision needed: the desktop has no JOURNAL family and the web writer uses `CONTRA_DATA`; merge into CONTRA (8101) or label it a web extension |
| `txn/fine-inout` | Decision needed: desktop `TR_FN_INOUT` is FAN PURC/FAN SALE (10793/10807) while the web writes `INOUT_DATA` (INWORD 8159, OUTWORD 8136); settle the identity first |

Steps:
1. Make `mainBooks` required on `components/BookSelect.tsx`; add a separately named unfiltered selector for
   configuration screens only.
2. `GET /context/books` accepts a family filter, and writers validate the family (N59).
3. Remove the mnemonic `preferred` props; auto-select only when exactly one eligible book exists.
4. Record the journal and fine in/out decisions before filtering those two screens.

Tests: a static test fails on any transaction `BookSelect` without a family; each screen lists exactly its eligible
books; a wrong-family request is refused before numbering.

Done when: Purchase Invoice lists only PURCHASE books and every screen and writer agree on the family.

### WS5 — Workflow completeness

#### N63 — Lossless reopen/edit adapters

Gap G46 · Parents P01-04, P02-01; X05, X07, X12, X13 · S1 · Size L · Start after N51

Steps:
1. Per family, a typed adapter in `apps/web/lib/<family>Adapter.ts` maps the GET view to editor state and editor
   state to the command. Editor state keeps every property the server returns, including hidden identities
   (`VCH_SRNO`, source references), and distinguishes blank, null, zero and untouched values. Serializers send
   complete arrays.
2. Readers return every field their writer owns; the purchase reader (`purchase/purchase.ts:2180-2405`) omits many
   today.
3. Order: sales and sales quotation (`txn/sales/page.tsx:529-584,716-758`); purchase, purchase quotation,
   consignment purchase and hallmark purchase (`txn/purchase/page.tsx:308-350`,
   `txn/consi-purchase/page.tsx:173-235`, `txn/purchase-hm/page.tsx:299-325`); tag opening
   (`txn/tag-opening/page.tsx:299-319,346-421`). Reuse the helper written for Hallmark Sale in N40.

Tests: for each page, a fixture with non-default, null and zero values is opened in the browser and saved without
changes, and a full snapshot (business columns, effects, identities) equals the original apart from permitted
audit metadata; a one-field edit changes only the fields that depend on it; duplicate tag numbers with different
`VCH_SRNO` survive.

Done when: an unchanged browser save is a no-op on every listed page.

#### N64 — Cash and bank receipt/payment lifecycle

Gap G50 · Parents P06-01; X16 · S2 · Size M · Start after N51, N52

Steps:
1. Route `PUT /receipts/:vchNo` to `editReceipt` (`finance/finance.ts:1404`); implement `editPayment` over
   `PAY_DATA`; add multi-line GET and PUT.
2. `components/PaymentForm.tsx`: load by number or from the recent list (full identity), update, delete with the
   version, reprint. Preserve voucher date and time, accounts, bank charges, kasar, cheque number, clearing date and
   print name, bank name, employee and narration.
3. Accounts come from book slots (N59).

Tests: cash and bank, receipt and payment; multi-line; cheque, card and UPI; an unchanged edit is a no-op; a changed
edit produces exactly the expected effects; a stale edit is a 409; delete and re-enter; print; snapshots of
`CASH_DATA`, `PAY_DATA`, `AC_DATA` and `ROJ_MEL_DATA`.

Done when: every saved receipt and payment can be reopened, edited, deleted and reprinted from its own screen.

#### N65 — Dhiran and loan lifecycles

Gap G51 · Parents P09-01, P09-02; X24 · S2 · Size XL · Start after N51

Steps:
1. Separate state machines for pledge issue, principal receipt, interest-only receipt, loan issue and loan received.
2. Full-key list, get, put, delete and print routes per mode; a route for `deleteDhrn`; a packet residual and
   release selector; edits and deletes refused while a later receipt depends on the voucher.
3. A server-side interest preview that follows the desktop settings `DHIRN_COMPOUND`, `INT_YEAR_DAYS`, `INT_DAY` and
   `DHRN_INT_TYPE`.
4. Documents `DhrnIssue` and `DhrnIntRec` in N75 wave D.

Tests: partial principal and interest; packet release; compound and simple interest; a leap-year boundary; refusal
while a later receipt depends on the voucher; reversal restores the outstanding; interest vectors calculated
independently from the desktop source.

Done when: journey J19 passes for all five modes.

#### N66 — Scheme members and scheme entry lifecycle

Gap G52 · Parents P09-03, P09-04; X24 · S2 · Size L · Start after N51

Steps:
1. A scheme-member master over `AD_MEMB` (`MS_MEMB.cs:4824-4915`) with create, edit, delete and print; deletion is
   refused while installments exist.
2. Relabel `txn/membership` as loyalty points so it is not mistaken for scheme membership.
3. Route `editSchemeInstallment`; reopen, edit and delete multi-member installment vouchers
   (`TR_MEMB_ENT.cs:4269-4807`) including UPI splits; passbook output.

Tests: enrol, pay cash and UPI installments, save unchanged, delete; a member with installments cannot be deleted;
loyalty rows never answer scheme-member reads; passbook page continuation.

Done when: the scheme part of journey J20 passes and loyalty is separate.

#### N67 — Existing lifecycle APIs wired into create-only screens

Gap G53 · Parents P05-02, P08-02, P03-01; X13, X23, X10 · S2 · Size M · Start after N63

Steps:
1. The Bullion Sale screen uses `GET`, `PUT` and `DELETE /bullion-sales/:vchNo` through a lossless adapter.
2. `components/KarigarForm.tsx` loads, updates and deletes through the existing `/karigar/issue/:vchNo` and
   `/karigar/receive/:vchNo` routes.
3. Party master: a create conflict offers an update (generic master PUT and DELETE in `app.ts`); deletion checks
   references; print.

Tests: create, reopen, unchanged save, edit and delete on each screen with write-set snapshots.

Done when: the three screens complete their desktop lifecycle from the UI.

#### N68 — Missing lifecycle services

Gap G54 · Parents P06-03, P06-04, P07-02; X16, X18 · S2 · Size L · Start after N51

Steps:
1. Bullion booking: GET, PUT and print (`TR_BUL_BOOKING.cs:2805-3295`).
2. Bill-to-bill: persist allocation identities; read, edit and print a saved settlement; safe reversal
   (`TR_BILL_TO.cs:4361-5010`).
3. Stock in/out document (`TR_INOUT.cs:661-739`).
4. Label print from the tag-opening screen (`TR_TAG_OPBL.cs:853-931`) through the tag-print module.

Tests: the lifecycle and document dataset of each service; bill allocation refuses over-allocation and double
allocation and reverses exactly.

Done when: each listed screen can reopen, edit and print.

#### N69 — Master semantic corrections

Gap G55 · Parents P03-02; X10 · S2 · Size M · Start after N58

Steps:
1. Auto Item: the code is the product code followed by the group code and the name is the product name followed by
   the group name (`MS_AUTO_ITEM.cs:2893-2910`), with the stock-display flags and minimum stock; duplicates are
   refused.
2. Labour update modes: item labour; labour on unsold tags in `BAR_DETL` and `BAR_IDTL`; a labour master over
   `TOUCH_MAST` (`MS_AUTO_ITEM.cs:2450-2660`). Preview the affected tags and audit the change.

Tests: exact code and name vectors; an unsold-tag update leaves sold tags untouched; `TOUCH_MAST` create, edit and
delete.

Done when: outputs equal the desktop for the fixtures.

#### N70 — Missing desktop menus

Gap G56 · Parents P05-05, P06-01, P11-05; X17, X16, X29 · S2 · Size XL · Start after N63

Steps:
1. Tour Sales (`TR_TOUR_SALE.cs:10771-11261`): `RATE_CUT_DATA`, `RATE_CUT_ISU`, `RATE_CUT_REC`, `SL_IDTL`, approval
   links, ledger, Rojmel, stock and stones; each approval or tour issue line is consumed exactly once.
2. Card Adjust (`TR_CARD_REC.cs:3192-3370`): `CARD_DATA` with ledger and Rojmel, including commission, net and bank
   legs.
3. CRM customer entry (`UT_CUST_ENTRY.cs:1900-2555`): `CUST_DATA` and `CUST_DETL` with create, edit, delete and
   print, in a migration with forced RLS.
4. When each lands, correct its row in `docs/COMPLETION-REGISTER.json` (Tour Sales, Card Rec, Cust Entry) and the
   RBAC aliases.

Tests: a dispatch-to-route contract test; full lifecycles; an approval is consumed once; card legs; the CRM entry
stays distinct from the CRM report.

Done when: each menu opens a workflow that matches its desktop form.

#### N71 — Manufacturing books and order-issue family

Gap G57 · Parents P08-01, P08-04; X23 · S2 · Size L · Start after N59

Steps:
1. Remove `ISSUE_BOOK = 'MIS'` and `RECEIPT_BOOK = 'MRC'` (`manufacturing/mfg.ts:96-97`) and the fallback in
   `keyOf` (`:416`). Generic issue and receive require a selected book and validate its family with
   `requireMfgMainBook`, which PR #19 added for jobwork.
2. Implement MFG order issue as the APR-family writer of `TR_MFG_ORD_ISU.cs:5527-6020` (`APR_DATA`, `APR_DETL`,
   `APR_IDTL`, material `MFG_DETL`, `MAIN_STOCK`, `SL_ORD_DETL` flags) and its receipt
   (`TR_MFG_ORD_REC.cs:6668-7189`); keep the signed metal flow in `MFG_ISU_REC`.
3. `txn/mfg-issue` and `txn/mfg-receive` drop `preferred="MIS"` and filter by family (N62).

Tests: issue and receive with two process books; order issue writes the APR tables rather than manufacturing
headers; order flags; reversal.

Done when: no manufacturing writer uses a literal book and order issue matches the desktop write set.

#### N72 — Desktop screens outside the menu table

Gap G58 · Parents P00-01, P13-01, P08-01; X01, X32, X23 · S2 · Size XL · Start after N71 · Decision D21

| Family | Desktop form and dispatch | Seed books in use | Recommended scope |
|---|---|---|---|
| Manufacturing stages: metal and design issue, wax receive, casting, ghat, filling, pre-polish, nakshi, mino, setting, assemble, filling 2, polish | `TR_MFG_KR_ISU_REC`, `TR_MFG_ISU_REC`, `TR_MFG_GHAT_REC` (`MDI_FORM.cs:9963-10734`) | 301 GHAT ISU, 111 GHAT REC, MFG PREP, STNG, NAKSHI and POLISH issue and receipt | Must-have for manufacturing customers |
| MFG tag entry and MFG order | `TR_TAG_OPBL`, `RP_ORD_TRACK` | 325 | Must-have where active |
| Jadtar, fitting, chediya, para | `TR_JDT_REC` (`MDI_FORM.cs:9707-9787`) | 112 JDTR ISU, 113 JDTR REC | Edition-specific; jobwork books landed in PR #19 |
| B2B sales and purchase | `TR_PR_SL_UAE` (`MDI_FORM.cs:8004-8027`) | 730, 735 | Must-have where active |
| Hedging Fix | `TR_PR_SL_HEDG` (`MDI_FORM.cs:8028-8040`) | 740 | Must-have where active |
| Item Purc/Sales | `TR_SL_PR_ITEM` (`MDI_FORM.cs:8276-8299`) | 425, 435 | Edition-specific |
| MRP Update | `TR_PHYSTK` (`MDI_FORM.cs:8708-8718`) | 140 | Edition-specific |
| Item Balance, Day Work, Stock Value | `RP_INOUT`, `RP_DAY_WORK`, `RP_STOCK_VALUE` (`MDI_FORM.cs:7195-7243`) | — | Must-have reports |
| Bill Interest | `RP_INOUT` (`MDI_FORM.cs:7225-7233`) | — | Edition-specific |
| Digital Gold and gold master | `MS_GOLD_MAST`, `TR_GOLD_BOOK` (`MDI_FORM.cs:9472-9495`) | 165, 166 | Edition-specific; defer the adjustment, whose desktop branch is empty (`:9494-9495`) |
| Franchise sales and purchase | `TR_FN_INOUT` (`MDI_FORM.cs:10787-10820`) | 061, 062 | Edition-specific |

Steps:
1. Apply D21 to each pilot customer's `BOOK_DATA` and settings and record the decision per family in this table.
2. When a must-have family starts, open a child slice for it using the document 02 §4 template. Order: B2B, Hedging
   Fix, manufacturing stages, the three reports, MRP Update, Item Purc/Sales, Jadtar, Franchise, Digital Gold.

Done when: every family has a recorded decision and the must-have families of the pilot customers are implemented.

### WS6 — Prints, reports and operator experience

#### N73 — Print-format registry identity and administration

Gap G59 · Parents P10-05; X25 · S1 · Size M · Start after N58

Steps:
1. Migration: a unique key `(tenant_id, CO_CODE, PRINT_TYPE, PRINT_FILE, BOOK_TYPE)`; `PRINT_SET_A` restricted to
   `'Y'` and `'N'`; a partial unique index allowing one `'Y'` per `(tenant_id, CO_CODE, PRINT_TYPE, BOOK_TYPE)`.
2. Change the key columns in `masters/configs.ts:344-348`, and add a print-format screen that lists the variants per
   print type and book type and makes one the default atomically, as `TR_SALE.cs:20620-20622` does.
3. Seed the nine desktop rows through the N58 template.
4. Hand over to N43, whose resolver reads the company registry first and company 01 only when the company has none
   (`TR_SALE.cs:13933-13963`).

Tests: several files per print type coexist; switching the default is atomic; a duplicate key is refused; the
seeded rows equal the desktop seed.

Done when: the registry represents the desktop seed exactly and N43 resolves against it.

#### N74 — Crystal binding wave A: daily documents

Gap G60 · Parents P10-05, P10-01; X25 · S1 · Size XL · Start after N73, N43

Templates: SalesBillA4, SalesBillA4Gst, SalesBillHz, SalesBillHzGst, SalesBillVr, RtlHuidPrint, SalesQuotation,
WhSalesBill, B2BSaleBillA4Tax, PurcBillA4, PurcBillA4Gst, PurcBillHalfGst, B2BPurcBillA4Tax, PurcQuot (its `.rpt`
is missing: recover it or capture desktop output), KrRecVchGst, OldItmSaleVch, CashBankBill, CashBankBillAc,
PaymentVch, ContraBill. Desktop callers include `TR_SALE.cs:16482-16500`, `TR_PURC.cs:14019-14062`,
`TR_CASH.cs:3325-3334`, `TR_OTH_PURC.cs:4005`, `TR_CONTRA.cs:3059-3068` and `TR_WH_SALE.cs:13789-13804`.

Steps for each template:
1. Freeze the desktop caller, parameters and selection formula.
2. Map datasets and stable row keys and register the contract in `reports/reportBindingContract.ts`.
3. Compare the dataset with a Crystal CSV export and resolve every difference.
4. Implement layout and media (A4, half page, horizontal).
5. Wire the screen's Print action through the N43 resolver, rendering O, D and T copies from one snapshot.
6. Track readiness as bound, compared and certified.

Tests: empty, single-page and multi-page documents; long text; negative values; children and images; each copy;
colliding identities; a refused print right; a PDF snapshot; a physical print on one A4 printer and one thermal or
half-page printer.

Done when: every wave-A template is bound with no unexplained dataset difference, its layout is approved and its
print action is wired.

#### N75 — Crystal binding waves B–D

Gap G60 · Parents P10-02, P10-03, P10-04, P10-05; X25, X26 · S1 · Size XL · Start after N74

- Wave B, accounts and statutory: AcLedger, RojMel, TRialBalHz, ProfitLossHz, BalanceHz, Gstr_1, Gstr_3.
- Wave C, stock, labels and orders: TagStkRpt, ItemStkRpt, ItmStkBalance, BarPrint10 and QrPrint10 (with barcode
  and QR scan-back), OrderVch, OrderBill, KrIsuBill.
- Wave D, service and finance documents: ReparingRec, DhrnIssue, DhrnIntRec, SchmRecVch, SchmPassBook.

The procedure is the same as N74; labels are calibrated on the target printers (N25).

Done when: waves B–D are certified and the remaining templates are listed with owners under N24.

#### N76 — Internationalisation (Gujarati, Hindi)

Gap G61 · Parents P11-05, P10-05; X29, X25 · S2 · Size L · Start after N57 · Decision D22

Steps:
1. Catalogues `apps/web/messages/{en-IN,gu-IN,hi-IN}.json` with semantic keys, a typed `t(key, params)`, and `Intl`
   number, date and plural formatters; no new dependency.
2. UI language per user with a company default, held in a signed cookie so the root layout emits the correct
   `<html lang>`; print language per template through the N43 resolver.
3. Seed the English entries from desktop form captions, runtime messages and report text objects, keeping source
   references; add human-reviewed Gujarati and Hindi; embed Unicode Gujarati fonts in PDFs; convert legacy KAP139
   text as a reviewed migration.
4. CI fails on a missing key in a certified locale.

Tests: fallback and missing keys; interpolation; the language survives login and a company switch; Gujarati PDF
fonts are embedded and searchable; long strings do not break layouts.

Done when: the top workflows and all customer prints have complete, reviewed Gujarati and Hindi catalogues.

#### N77 — Semantic layout and tab-order parity for 20 forms

Gap G62 · Parents P02-01, P02-04; X07 · S2 · Size L · Start after N63 · Decision D20

Forms: TR_SALE, TR_SALE_HM, TR_SALE_RTN, TR_WH_SALE, TR_SALE_ORD, TR_PURC, TR_PURC_HM, TR_KR_ISU, TR_CASH,
TR_CONTRA, TR_TAG_OPBL, TR_TAG_SPLIT, TR_TAG_CAN, TR_MFG_ISU_REC, TR_MFG_KR_ISU_REC, TR_MFG_ORD_ISU, TR_JDT_REC,
TR_DHRN_ISU, TR_DHRN_REC, TR_MEMB_ENT.

Steps:
1. Generate a per-form manifest from the extracted form specifications (tab index, captions, regions, grid
   columns).
2. Mark live controls with `data-desktop-control`, `data-desktop-tab` and `data-desktop-column`.
3. A Playwright comparator resolves settings and `COL_MAST` (caption and visibility; `COL_RPT` repeats the previous
   row's value) and checks visible control order, Tab and Enter traversal and grid columns.
4. Transaction grids apply `COL_MAST` captions and visibility (`TR_SALE.cs:9038-9049`).
5. Operators review and approve each remaining deviation.

Tests: traversal on every form; hidden and renamed column variants; a 100-row keyboard-entry benchmark against
desktop timing.

Done when: none of the 20 forms has an unexplained missing or reordered control or column, and operators have
signed off.

### WS7 — Migration, operations and release

#### N78 — Migration ownership manifest and fail-closed validator

Gap G63 · Parents P12-01; X30 · S1 · Size XL · Start after N58, N59

Steps:
1. `migration/datacare-next/v1/ownership-manifest.json` covers all 145 tables of
   `project-memory/parity/DESKTOP-REAL-SCHEMA.json` and the image assets: source database, disposition, scope
   columns, keys and order, dependencies, column transforms, blank and NULL policy, validators and
   confidentiality.
2. A test requires exact coverage of the real-schema baseline with no duplicates.
3. `apps/api/integration/cutover.mjs`: `source-table-missing`, `target-table-missing`, `no-common-columns`, an
   unexpected column and a checksum mismatch are failures (`:262,336`); the passing `dry-run` status goes;
   extraction filters by company, location and year; target replacement is scoped, never tenant-wide (`:450`).
4. Because D15 makes web data desktop-shaped, identities migrate unchanged.

Proposed dispositions (they cover the 145 tables exactly):

| Disposition | Tables |
|---|---|
| Migrate as-is | AC_GROUP, AC_MAST, ADD_MAST, AD_MAST, BAL_GR, BOOK_DATA, BOOK_DETL, COL_MAST, CONV_MAST, COUNTRY_MAST, CO_MAST, CO_SET, DESIGN_DETL, DESIGN_IDTL, DESIGN_MAST, DM_MAST, DM_SIZE, EMP_MAST, GROUP_MAST, ITEM_MAST, ITM_CITY, ITM_WT_MAST, LBR_MAST, LOCT_MAST, MFG_MAST, MODEL_MAST, MSG_MAST, POINT_MAST, PRINT_MAST, PRODUCT_MAST, RATE_MAST, STATE_MAST, TABLE_MAST, TAX_MAST, TOUCH_MAST, USER_MAST, WEIGHT_MAST, YEAR_MAST |
| Transform: security and configuration (credentials hashed or moved, machine paths remapped, media decoded) | BOOK_IDTL, CO_SET_NEW, E_DATA, E_MAST, IMAGE_DATA, LOGIN_MAST |
| Transform: finance and audit | AC_DATA, BANK_RECONCILE, BILL_OS_DATA, BUL_DATA, CARD_DATA, CASH_DATA, CONTRA_DATA, CRNT_DATA, DELETE_DATA, LDR_ADJ_DATA, LOCT_AMT, OP_DATA, OP_DETL, OP_LDR, PAY_DATA, PAY_DETL, REM_DATA, ROJMEL_BAL, ROJ_MEL_DATA, TAX_DATA, TEMP_BOOK_DATA, UPI_DATA, USER_DATA, USER_REQUEST |
| Transform: sales and purchase | CUT_DATA, CUT_DETL, CUT_STK_DETL, LOT_DETL, PR_DATA, PR_DETL, PR_IDTL, RATE_CUT_DATA, RATE_CUT_ISU, RATE_CUT_ISU_REC, RATE_CUT_REC, SL_DATA, SL_DETL, SL_DETL_RTN, SL_IDTL, SL_ORD_ADJ, SL_ORD_DATA, SL_ORD_DETL, SL_ORD_IDTL, SL_PR_DETL |
| Transform: stock and custody | APR_DATA, APR_DETL, APR_IDTL, BAR_CAN_DATA, BAR_CAN_DETL, BAR_CAN_IDTL, BAR_DATA, BAR_DETL, BAR_IDTL, INOUT_DATA, INOUT_DETL, INOUT_IDTL, ITM_LOT_DETL, ITM_OPBL, MAIN_STOCK, SRNO_MAST, VP_ADJ_DATA |
| Transform: members and loans | AD_ADJ, AD_DATA, AD_MEMB, AD_OS, DHRN_DATA, DHRN_ISU_DATA, DHRN_ISU_DETL, DHRN_REC_DATA, DHRN_REC_DETL, POINT_DATA, POINT_MEMB |
| Transform: manufacturing and service | DM_DATA, DM_KR_DATA, EMP_DATA, KR_DATA, KR_DETL, KR_IDTL, LBR_DATA, LBR_ISU_DETL, LBR_ISU_IDTL, LBR_REC_DETL, MFG_DATA, MFG_DETL, MFG_IDTL, MFG_ISU_REC, MLT_DATA, MLT_DETL, REP_DATA, REP_DETL |
| Rebuild from migrated facts | TAG_SET, TAG_SUM_DATA (and the web-only TAG_STOCK) |
| Regenerate (report staging; drain `WEB_DATA` before cutover) | FINE_DATA, LEDR_AC_DATA, REPORT_DATA, TAG_PRINT_DATA, TAG_STOCK_PRINT, TEMP_ADD, TEMP_AD_DATA, WEB_DATA |
| Archive only | HDD_MAST (machine licence fingerprint) |

Tests: manifest completeness; each validator failure mode; generated scope SQL; transform golden files.

Done when: a signed manifest covers 145 of 145 tables with reviewed dispositions and the validator fails closed.

#### N79 — Scoped shadow loading, reconciliation and two rehearsals

Gap G63 · Parents P12-02, P12-03; X30 · S1 · Size XL · Start after N78

Steps:
1. Freeze a source snapshot with source, schema and manifest hashes.
2. Extract immutable, checksummed chunks per company, location and year (global tables by declared ownership); an
   absent table is distinct from an empty one.
3. Load a run-specific shadow schema in dependency order with idempotent checkpoints
   `(run, table, scope, chunk hash)`; a resumed run re-validates finished chunks.
4. Validate exact key sets, type-aware column checksums (NULL, blank and zero kept distinct; decimals, dates,
   binary), orphans and duplicates. Reconcile debit/credit and gold/silver fine per account; pieces, gross, net and
   fine per tag, lot and counter; outstanding bills, orders, schemes, loans and work in progress; tax; image hashes.
5. Continue imported business in the browser: an old order, a return, a supplier payment, a loan, a scheme
   installment, a manufacturing receipt and a tag operation.
6. Promote atomically with untouched-scope sentinels; rollback returns to the untouched target.
7. Rehearsal A: a clean shadow target with an injected interruption and a corrupt chunk. Rehearsal B: a second,
   production-like target with a timed freeze, final delta, promotion, accountant checks and rollback. Compare the
   two reports.
8. Lift the `production-cutover-load` containment (`packages/core/containment.mjs`) only by a reviewed change once
   both rehearsals meet its exit gate.

Done when: two clean rehearsals show no unexplained difference, the continuation journeys pass and the containment
exit gate is met; N27 can then close its engineering part.

#### N80 — Production deployment hardening and disaster recovery

Gap G64 · Parents P12-04, P12-05; X31 · S1 · Size XL · Start after N49 · Decision D11 (document 08)

Steps:
1. One canonical production compose file; retire `deploy/docker-compose.prod.yml` (stale Redis service, Dockerfile
   path and port). A TLS reverse proxy is the only public listener (443 with an HTTP redirect, HSTS and forwarded
   headers); the database and API are not published; the web listens internally or on loopback.
2. Add `web/.dockerignore` excluding `.git`, environment snapshots, desktop artefacts, parity captures,
   `node_modules`, `.next`, `dist`, logs and caches; produce an SBOM and scan the images; prune development
   dependencies from the runtime layer.
3. Load secrets from a managed store at runtime; the migration-owner connection exists only in a one-off migration
   job.
4. Nightly encrypted `pg_dump` to versioned off-host storage with a checksum manifest, retention per D11, and an
   alert when a backup is missing or too old.
5. A monthly automated restore drill to an isolated target measures RPO and RTO and checks readiness, invariants and
   a sample continuation. This is a physical restore; logical company restore stays contained.
6. Alerts on readiness, database availability, 5xx rate, audit failures, pool saturation, backup age and latency;
   centralized logs with retention and access control.
7. Upgrade runbook: pinned image digests, a verified backup, `migrate deploy` as owner, RLS and roles re-applied, a
   canary, smoke tests, then the switch. Roll back only across backward-compatible (expand-only) migrations.

Done when: an external scan shows only port 443, the restore drill meets the approved RPO and RTO, and upgrade and
rollback have been rehearsed.

#### N81 — Secrets hygiene and sanitized delivery source

Gap G65 · Parents P12-05, P14-02; X31, X34 · S1 · Size L · Start after N47

Steps:
1. A script builds the deployment source from an allow-list: `web/` manifests and lockfile, application and package
   sources, the Prisma schema, migrations, RLS and role scripts, Dockerfiles, approved deploy scripts and runtime
   form and report assets. It is scanned independently and approved by the owner before use.
2. Rotate by key name: `POSTGRES_PASSWORD`, `APP_DB_PASSWORD`, the credentials inside `DATABASE_URL` and
   `MIGRATE_DATABASE_URL`, `JWT_SECRET`, `PARITY_OWNER_PASSWORD`, `PARITY_APP_PASSWORD`, `GSP_PASSWORD`,
   `GSP_EINV_PWD`, `WA_TOKEN`, `SMS_KEY`, the desktop SQL Server credentials and any historical CI or provider
   credentials.
3. Enable platform secret scanning and push protection; run a pinned scanner on pull-request diffs and weekly on
   full history. The archival repository keeps a reviewed baseline of known findings by fingerprint (never values);
   the sanitized source must have none.
4. Pull-request workflows never receive production secrets.

Done when: deployments are built only from the sanitized source, the listed credentials are rotated and CI blocks
new secrets.

#### N82 — Release-certification gate completion

Gap G66 · Parents P14-02; X34 · S2 · Size XL · Start after N47, N49

Steps:
1. Add to `ops/releaseCertification.ts`:
   - `test-types`;
   - `docs-and-plan-integrity`;
   - `real-browser-complete`: the exact suite set (main parity suite, session context, labour-preview lifecycle),
     each with frozen case IDs, extended towards J01–J28;
   - `hardware-providers`: the D09 device and provider matrix;
   - `migration-continuation`: the two rehearsal IDs and the continuation journeys from N79;
   - `business-uat`: cashier, purchasing, inventory and manufacturing, accountant, manager and administrator, each
     on a normal and an exception day.
2. Evidence schemas with freshness and candidate binding for each new gate.
3. Negative controls (document 04 §5) for every new gate: missing, duplicate, unknown, skipped, stale and synthetic
   members are refused.

Done when: the certifier refuses every manipulated evidence set and the owner has approved the new requirement-set
digest.

## 7. Definition of done for these slices

In addition to document 02 §4–§5, a slice in this document moves to `implemented-unverified` only when:

1. It merged through a pull request with every CI gate green, including the gates added by N47–N49.
2. A database test compares the complete write set, and a deliberately broken variant fails.
3. A zero-mock browser journey covers every screen it changed.
4. `execution-backlog.json` records its evidence paths and `statusAsOf`, and §2 of this document is updated.
5. No conformance baseline grew (rounding, dates, literal identities).

Acceptance stays with the parent packages: desktop comparison, operator acceptance and release certification are
recorded there, never on a slice.

## 8. Keeping this record current

- Update slice status in `execution-backlog.json` in the same pull request as the code.
- Run `python3 docs/master-parity-plan-2026-09-29/validate_plan.py` and `pnpm docs:refs` before merging.
- A defect found during implementation becomes a new gap row here (continuing at G67) and a step or child slice.
- When a gap is fixed, keep its row and add the fixing pull request to the slice evidence: the register is
  historical, the backlog is current.
