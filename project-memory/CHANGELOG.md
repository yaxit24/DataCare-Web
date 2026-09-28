# CHANGELOG — demoable increments per phase

Format: `[phase/task] summary` — date.

## Unreleased
- [follow-up] **Mobile-facing REST API**: `routes/txn.ts` exposes sales/purchase/finance/dhrn/karigar/reports/gst/einvoice as RBAC-guarded JSON endpoints (auth+assertRight, domain→HTTP errors); `http_txn.live.mjs` 12/12; thin `apps/web/test-harness.html`. Real client = mobile app. — 2026-06-28
- [11/task-33] **34-TASK PLAN COMPLETE.** Migration & cutover runbook; final verification 19/19 live + gate 10/10. — 2026-06-28
- [11/task-32] Deployment/observability/backups: Dockerfile, prod compose (healthchecks), health/readiness, daily pg_dump backup, `.env.example`, perf indexes (applied + verified live). — 2026-06-28
- [11/task-31] Security hardening: injection audit + `quoteIdent`, live RLS re-assertion, security-review.md. LIVE 3/3. — 2026-06-28
- [10/task-29] **PHASE 10 COMPLETE.** Integrations: pure Code39 SVG, `MessageSender`/`notify` (never throws), `buildUpiUri`. LIVE 6/6. — 2026-06-28
- [9/task-28] **PHASE 9 COMPLETE.** HTML→PDF rendering (HTML templates + `PdfRenderer`/`FakePdfRenderer`/`PlaywrightPdfRenderer`). LIVE 5/5. — 2026-06-28
- [9/task-27] Report datasets (`salesRegister`/`purchaseRegister`/`dayBook` + unified read-models). LIVE 10/10. — 2026-06-28
- [8/task-26] **PHASE 8 COMPLETE.** E-Invoice IRN (`buildIrnPayload`/`submitIrn`/`FakeIrnTransport`): NIC v1.1 payload (GenIRN parity), B2B validation, store IRN/ACK→SL_DATA + E_DATA. LIVE 7/7. Real GSP submit = external blocker. — 2026-06-28
- [8/task-25] GST GSTR-1 datasets (`classifyInvoice`/`buildGstr1`/`gstr1`): B2B/B2CL/B2CS/HSN over SL_DATA⋈AC_MAST + SL_DETL. LIVE 11/11. — 2026-06-28
- [7/task-24] **PHASE 7 COMPLETE.** Karigar metal flow (`issueKarigar`/`receiveKarigar`/`karigarMetalBalance`): fine OUT/IN, wastage folded into fine (NWT×(TOUCH+WEST)/100, MS_UPDATE parity), metal balance, labour ledger. LIVE 11/11. — 2026-06-28
- [7/task-23] Dhrn pledge-loan (`issueDhrn`/`receiveDhrn`/`outstanding`/`accruedInterest`): DHRN_* tables, day-count interest (RP_DHRN_OS parity), outstanding=issue−Σreceipts, over-repay guard. LIVE 13/13. — 2026-06-28
- [6/task-22] Accounting read-model (`trialBalance`/`accountLedger`): per-account Dr/Cr rollup + window-function running balance over AC_DATA. LIVE 8/8 (trial balance nets Dr=Cr=8000). — 2026-06-28
- [6/task-21] Finance vouchers (`postReceipt`/`postPayment`/`postContra`/`deleteFinance`): balanced 2-line AC_DATA + header (CASH_DATA/PAY_DATA/CONTRA_DATA); cash-limit→PAN (Req 17.2). LIVE 11/11. — 2026-06-28
- [5/task-20] **PHASE 5 COMPLETE.** Purchase end-to-end (`createPurchase`/`deletePurchase`): atomic number+stock-IN+reversed posting (Cr supplier / Dr purchase + Dr GST-input) in one tx; reverse+tag-removal on delete. LIVE 13/13. — 2026-06-28
- [5/task-19] Sales end-to-end (`createSale`/`deleteSale`): atomic number+tag-issue+GST+balanced posting in one tx; reverse+tag-restore on delete. LIVE 14/14 incl atomic rollback on ghost tag. First full desktop-parity workflow. — 2026-06-28
- [5/task-18] Tag & stock lifecycle (`TAG_STOCK` create/issue/restore/onHand; presence-based; double-issue guard). LIVE 8/8 incl concurrent issue (1 win/1 reject). — 2026-06-28
- [5/task-17] Posting engine + double-entry ledger (`postVoucher`/`reverseVoucher`, ΣCR=ΣDR, atomic, DELETE_DATA log). LIVE 6/6 (post+reverse). Shared core for all transactions. — 2026-06-28
- [4/task-16] **PHASE 4 COMPLETE.** Voucher numbering (advisory-lock + SRNO_MAST); 8 concurrent → distinct 1..8. — 2026-06-28
- [4/task-15] Calc engine: labour types, metalAmount, lineNet, gstSplit, billTotals. 10 golden vectors. — 2026-06-28
- [3/task-14] **PHASE 3 COMPLETE.** Master registry + generic `/masters/:name` routes. Live CRUD 11/11. — 2026-06-28
- [3/task-13] Master-data framework (pure builders + live CRUD; required/duplicate/referenced-delete guards) + AC_MAST/ITEM_MAST. — 2026-06-28
- [2/task-12] **PHASE 2 COMPLETE.** Fastify HTTP app: login cookie+refresh+rate-limit, /context companies/years/select, RBAC guard. LIVE e2e 10/10. — 2026-06-28
- [2/task-11] RBAC policy core: `can`/`assertRight` + `filterNav`. 5 Tier-1 tests. — 2026-06-28
- [2/task-10] Auth core: Argon2 (+plaintext→forcedReset), jose JWT, `authenticate` vs LOGIN_MAST + audit + rights. 13 Tier-1 + LIVE Tier-2. — 2026-06-28
- [1/task-9] **PHASE 1 COMPLETE.** Scoped data-access (`buildScopeWhere` +3 tests) + `withTenant`/`atomic` tx wrapper. LIVE Tier-2: rollback + tenant isolation proven. — 2026-06-28
- [1/task-8] ETL coercion core (`etl_mssql_to_pg.py`, +5 tests) + `@datacare/parity` diff engine (+6 tests). LIVE: Postgres migrate of all 162 models + RLS tenant-isolation proven. — 2026-06-28
- [1/task-7] Prisma schema generator (`gen_prisma.py`) + 4 Tier-1 tests. 162-model `schema.prisma` — `prisma validate` PASSED; LIVE migrate (163 tables) + RLS verified. — 2026-06-28
- [1/task-6] Monorepo scaffold (pnpm+Turborepo) at `web/` — apps/{web,api} + packages/{core,types,db,reports}, CI, docker-compose. Gates GREEN: install + test 8/8 + typecheck 8/8 + build 6/6. — 2026-06-28
- [0/task-5] **PHASE 0 COMPLETE (gate PASSED).** Manifest verifier (`verify_manifest.py`) + 3 tests (19 total). `unified/MANIFEST.md` sign-off + `build-blocker-report.md`. Web build unblocked. — 2026-06-28
- [0/task-4] Per-form catalog (`build_form_specs.py`) + 3 Tier-1 tests. 204 form specs + module-map.json (61 txn/45 rpt/33 mast/22 util/43 other); curated TR_SALE/TR_PURC. Ledger posting centralized in Ac_Ledr. — 2026-06-28
- [0/task-3] Data-model catalog (`build_data_model.py`) + 3 Tier-1 tests. 162 tables / 4666 columns (100 DDL + 62 code-recovered); core tables resolved; 7 flagged for Docker pass; core ERD. — 2026-06-28
- [0/task-2] Report reconciliation tool (`reconcile_reports.py`) + 3 Tier-1 tests. Wide Raw_Source search (255 .rpt) confirms 20 reports as external-blockers; "200+ missing" was stale. unified/ complete for file artifacts. — 2026-06-28
- [0/task-1] Completeness audit scanner (`audit_completeness.py`) + 7 Tier-1 tests + manifest (933 artifacts) + canonical-layout contract. Surfaced: schema missing ~69 core tables; 20 reports external-blocker. — 2026-06-28
- [bootstrap/task-0] Project-memory & continuity store created (state.json 34-task graph, HANDOFF, JOURNAL, ADRs). — 2026-06-28
