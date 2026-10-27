# HANDOFF — START HERE every new session

> Read this first, then the todo list (authoritative task graph) + `state.json`. Verify against reality before trusting it.

## ⚙️ STANDING DIRECTIVE (user, reaffirmed 2026-06-28)
**Run CONTINUOUSLY, NON-STOP, until EVERY item in the implementation plan is complete (scorecard ≈100% — all 204 forms, 255 reports, full frontend+backend+DB, parity-certified).** Do NOT stop after a phase/slice or wait for permission (all permissions granted). Each turn: complete ≥1 verified vertical slice, keep the gate green + trial balance tied, checkpoint JOURNAL/HANDOFF, then immediately continue. Only pause for a real external blocker (GSP/WhatsApp/payment creds) or a genuine ambiguity. The agentic loop re-prompts automatically — keep going every iteration.

## Active plan
**Full-parity rebuild (52 tasks / 15 phases A–O)** — replicate the ENTIRE desktop (204 forms, 255 reports, full frontend+backend+DB) at 100% functional parity. The earlier 34-task plan delivered the verified backend CORE; this plan builds out the rest. Task graph = the session todo list (IDs 1–20 group the phases). Run continuously; checkpoint every task.

## Latest slice (2026-10-27, cont.4) — N95: source file-size budget ratchet (G108/SP03)
- `web/scripts/check-size-budget.mjs` (baseline `web/parity/size-budget.json`, CI gate next to the depth gate) freezes each over-cap file's line count as a ceiling that may only fall and caps new source files at 1,500; `--audit` re-derives, `--write` only tightens. Test (`check-size-budget.test.mjs`, run first by `size:budget`) proves growth fails. 20 ceilings today, led by `txn.ts` (8,558). **PR #60 stacked on #59 (base = N94 branch).** Second SP03 ratchet of N88; route plugins, error taxonomy, shared voucher editor still open.
- Worktree note: `main` is checked out in `~/Desktop/imodule-extracted`, so `git checkout main` fails in the `~/dc-wt/e2e-fixes` worktree — branch from `origin/main` or the stacking base instead.
- Next gap **G109**, slice **N96**, decision **D31**.

## Latest slice (2026-10-27, cont.3) — N94: static SQL-injection gate (G107/SP03)
- `web/scripts/sql-interpolation.mjs` (AST, wired into `lint-workspace.mjs`) rejects a request/input value interpolated into a raw `$queryRawUnsafe`/`$executeRawUnsafe` template; `$n`-bind indices, identifier sanitizers and SQL fragments pass. Zero findings today; a planted `req.body` interpolation fails lint. Test runs first in the `lint` script. **PR #59 → main.** First SP03 ratchet of N88 (route plugins, error taxonomy, shared editor, size budgets still open).
- Lesson: don't allow-list fragment NAMES (160 false positives) — flag the injection vector (request-rooted values) instead. Prisma methods are `$queryRawUnsafe` with the `$`.
- Next gap **G108**, slice **N95**, decision **D31**.

## Latest slice (2026-10-27, cont.2) — N93: document previews compose the line net the server posts (G84, G106)
- Every document preview now totals each line as metal + GROSS labour + other (`@datacare/core` `lineNet`), exactly as the server posts (`calcLineNet`). Six screens had omitted other charges (G84: hallmark preview ₹63,056.35 vs saved ₹67,414.53); sales + sales-quotation had used `recalcLine.totalAmount`, which wrongly nets the line discount and adds the ghat amount (G106, found while fixing G84). The per-line discount and ghat stay on SL_DETL.DISC_AMT/GHT_AMT and never enter the line net — pinned by a DB test (10% discount + ₹250 ghat → NET_AMT unchanged).
- **PR #58 → main.** Verified: DB composition test, API+DB 313/3477, web unit 645, real-stack 25/0-mocks, all gates. Lesson: `recalcLine.totalAmount` is NOT the bill-net composition (it nets discount + adds ghat) — use `lineNet({metal,labour,other})`.
- Next gap **G107**, slice **N94**, decision **D31**.

## Latest slice (2026-10-27, cont.) — N92: document previews use the company rounding policy (G102)
- The nine document screens previewed `Math.round(taxable + tax)` while the server posts with the company rounding policy; the operator saw a total the ledger didn't store. Moved `resolveRoundingPolicy`/`roundNearest` into `@datacare/core` (one source of truth), surfaced the flags on `/me` (`loadRoundingFlags`), added a web `useRoundingPolicy()` hook (separate from `BusinessScope`), and converted purchase, sales, hallmark sale, sale return, purchase return, consignment purchase, estimate and both quotations to `billTotals(input, policy)`.
- Verified: 4 core vectors + `/me` assertion; core 1771, API+DB 313, web unit 645, real-stack 25/0-mocks, all gates. On the PR #57 branch (stacks on N90+N91). **G84** (hallmark preview omits west %/ghat/other charges/line discounts — line arithmetic) stays with N63.
- **Disk hazard:** the machine disk hit 100%; reclaimed ~27 GB of Docker cache/images/volumes. Watch free space before long test runs.
- Next gap **G106**, slice **N93**, decision **D31**.

## Latest slice (2026-10-27) — land N90 on main (PR #57), fix the G104 regression, add N91 Stock In/Out provisioning
- **Merge-gap corrected:** N90's PR #56 had merged into the advisories branch (`fix/n86-advisories-2026-10-26`), NOT main, when #55 merged — its 7 commits never reached main. Opened **PR #57** from `fix/e2e-defects-2026-10-26` (rebased onto current main) → **base main**. Do NOT stack a PR on a not-yet-merged branch (that is what stranded #56).
- **G104 regression (found + fixed):** the first G104 cut resolved a typed code on every programmatic blur for any LookupPicker with onPick, which fired an extra async onPick during Design Book grid navigation and broke the `design-repeat` real-stack journey. It was a REAL regression (not a flake — I initially misdiagnosed it as machine load; the moving failure line was the async onPick racing). Fix: typed-code resolution is opt-in via `resolveTypedCode`, enabled only on party/supplier header fields (purchase, sales, purchase return, sale return, payment). Grids untouched. Real-stack 25/25 locally and on CI.
- **N91 (`implemented-unverified`, G105):** Stock In/Out was unusable on a provisioned company (empty book list, Save disabled). `seedCompany` now seeds the INWORD (`SIN`) / OUTWORD (`SOT`) books and a `BRANCH` stock-in-hand account wired to `LOCT_MAST.AC_CODE` (MS_LOCT.cs:3458). Verified: `seedCompleteness` + a real-route Stock In/Out posting that reconciles; full API+DB suite 313/3475. Open: the exact desktop `AC_GR` for the branch account was chosen as current-asset `01` without a desktop-DB confirmation.
- **Ask the owner:** confirm "Canto" meant Contra; decisions D15–D19 and D30 still pending (block N50/N51/N52/N56/N58, G47). Next gap **G106**, slice **N92**, decision **D31**.

## Latest slice (2026-10-26, night) — N90 browser-run defects; N86 advisories (PR #55)
- PR #55 (N86): advisory gate back to 0/0/0/0 with next 15.5.28; Next.js 16.4.3 rehearsal passes. Merge it before the N90 PR so CI's advisory job is green on N90.
- N90 (`implemented-unverified`): defects found by operating the production build as a shop user — Year Create (G97), generic master save (G98), bank-mode settlement (G99), purchase print HSN tax (G95), grid Enter (G96), GOLD line default (G100 part), purchase/sales-return book families (G101 part), local-day defaults (G103), typed lookup codes resolved on leave (G104). Open: G100 WALKIN (N58), G101 remaining screens (N62), G102 preview vs posted totals (N63).
- Ask the owner: confirm "Canto" meant Contra (the run tested Contra); decisions D15–D19 and D30 are still pending and block N50/N51/N52/N56/N58 and G47 items.

## Latest slice (2026-10-26) — N34 Purchase Return edit lifecycle
- Edit (`PUT /purchase-returns/:vchNo`), lossless reopen and the screen's reopen/edit/delete are implemented and tested (write-set test `web/apps/api/test/purchaseReturnEdit.routes.db.test.ts`, journey `purchase-return`). N34 stays `in-progress`: decision **D30** (document 12 §4, not accepted) asks the owner whether to follow the desktop — no residual limit, no `PR_IDTL` stone rows — instead of G47 as written. New gaps G95 (print HSN tax, N74), G96 (grid Enter, N77). Next in the document 13 queue after this: N56 waits for D19; N50/N51/N52/N58 wait for D15–D18.

## Latest planning update (2026-10-01, fourth) — device fakes, dev setup and device guides
- **Decision D29:** Phase 1 is built and tested against device **fakes** with recorded sample inputs and against the desktop source, screenshots and transcripts as the oracle; Odoo IoT is a device-protocol reference only; real hardware and live providers are deferred to acceptance (N25); a fake must fail honestly in production (G33). Slice **N89** adds the device-fake test harness and journeys.
- **New developer docs:** `docs/handbook/dev/setup.md` (prerequisites, install, run, test, and where the desktop reference code lives) and `docs/handbook/dev/devices.md` (scale, scanner, label printer, camera: how each is triggered and connected to a laptop). Linked from the hub.

## Latest planning update (2026-10-01, third) — owner decisions and the agent reading order
- The owner accepted D23, D24, D26 and D27 as recommended and added **D28: nothing in Phase 2 starts, including its M0 decisions, until Phase 1 is complete and certified (N30)**. N86 now also lands Prisma 7 before 19 November 2026. Recorded in document 12 §4 and the ADR-0004 amendment; `validate_plan.py` enforces the Phase 2 gate.
- Building agents follow "Which documents to follow" in `AGENTS.md`: the next slice from document 13 §3, its specification in document 02/06, 10, 11 or 12, status in the backlog. Older plans are history.
- Still to approve: D15–D22 (document 11), needed before N50, N51 (version tokens), N52, N56, N58 and N72–N77; D01–D14 (document 08) as their waves begin. Next gap G84, slice N89, decision D29.

## Latest planning update (2026-10-01, second) — documentation hub, Phase 1 and Phase 2 plans
- **Entry point is now `docs/README.md`** (hub). Desktop knowledge: `docs/handbook/desktop/`; web: `docs/handbook/web/` (architecture, module map, engineering standards, testing with the Chrome DevTools MCP visual protocol); every desktop menu: `docs/handbook/menu-catalog.md` (generated from `menu-catalog.jsonl`); every Markdown file classified in `docs/handbook/doc-register.md`. No historical file was moved. Agents: `AGENTS.md` and seven skills in `.kiro/skills/`.
- **Lineage verified** (`docs/master-parity-plan-2026-09-29/12-lineage-verification-2026-10-01.md`, `lineage-register.json`): 228 earlier items — 32 closed, 176 carried, 14 new gaps (G69–G80), 4 superseded, 2 decisions (D23, D24). Gap numbers start at G69 because N53 (PR #29) took G68. G81 (client CSV export does not neutralise formulas, owned by N57) came from the independent review. New slices N83–N88; N87 (this documentation) implemented-unverified. Phase 1 plan: document 13; Phase 2 SaaS plan: document 14 with `phase2-backlog.json` (M0–M7, SP01–SP24). ADR-0004 records the two-phase boundary.
- **Do next:** N86 (Next.js/React advisory range, Node 20 end of life) and the document 13 §3 first queue: N49 step 1, N53, N56, N51 milestone 1, N54 milestone 1, N40, N50 milestone 1 with its N88 route plugin, N48, N58, N83, N85. Owner decisions: see the third update above.
- Checks: `python3 docs/tools/docs_check.py` and `validate_plan.py` both run in the blocking static-gates CI job. Acceptance unchanged (0/198, 0/83, 0/34).

## Latest planning update (2026-10-01) — full-stack audit converted into implementation slices
- The 1 October audit ran `main` on an isolated PostgreSQL with forced RLS, drove the real UI in Chrome, crawled 239 routes and compared with the desktop databases. Results, evidence (`docs/master-parity-plan-2026-09-29/evidence/audit-2026-10-01/`) and the work are in **`docs/master-parity-plan-2026-09-29/11-audit-implementation-plan-2026-10-01.md`**: gaps G20–G66, decisions D15–D22, slices N47–N82 with steps/tests/acceptance, phases A–F.
- **Start with phase A:** N47 (red gates into CI), N49 step 1 (hermetic tag-split seed), then N53, N56, N51 milestone 1, N54 milestone 1, N40, N50 milestone 1. `execution-backlog.json` holds current slice status; the validator now also checks document 11 and the audit evidence hashes.
- Acceptance counts unchanged (0/198 menus, 0/83 packages, 0/34 cards).

## Latest revision (2026-09-29, Round 16 review fixes) — X13 numeric write, review NEEDS_CHANGES addressed
- The 2026-09-29 semantic review flagged 5 issues; all addressed. **Issue 1 (BLOCKING):** the plan's LedrCash all-year cash obligation was UNREACHABLE — the coordinator fed the configured non-zero `CASH_LIMIT` into the pure guard, which refuses any non-zero limit before `observeLedrCash` could run. Fixed by presenting a ZERO limit to the pure guard (its frozen contract requires it) and enforcing the REAL `CO_SET.CASH_LIMIT` in the coordinator's own now-reachable LedrCash ceiling check; removed the dead `!= '00045'` sub-condition (guard already rejects `00045`).
- **Issue 2:** the DB over-limit case now asserts the LedrCash-ceiling message with a two-book aggregate (would fail if `observeLedrCash` reverted); added a guard-clean ACCEPT case. **Issue 3:** edition-`L` is guard-envelope only, no edition/USER_DATA column is persisted or read — confirmed safe. **Issue 4:** endpoint shape gate is a superset-safe subset of the coordinator's authoritative fail-closed `validateRequest` — documented. **Issue 5:** CI (`ci.yml`, `pnpm test` + `RUN_DB_INTEGRITY_TESTS=1`) runs the new `*.db.test.ts`; the live `.mjs` is a standalone smoke, not CI-invoked.
- Gate GREEN (typecheck 10/10, build 7/7, lint clean, core 26/1614 incl. frozen guard fixtures, API pure 125/1901, typecheck:tests OK). DB-backed/live/browser proof authored-for-CI, NOT run in-sandbox. **X13 still NOT closed.** See `parity-plan-2026-09-10/43-implementation-progress-round16.md` (Round 16 revision section).

## Latest slice (2026-09-29, Round 16 / FEAT-003) — X13 steps 8-9
- Strict `PUT /sales-returns/:vchNo/incoming-numeric` routes through the FEAT-002 `updateSaleReturnNumeric` coordinator (never generic `editSaleReturn`); real UI Save on the saved Sale Return screen (`SaleReturnSavedPanel` numeric sub-panel) preserving draft/conflict state and adopting the fresh version. `nav.ts` unchanged (no unearned promotion). Route-coverage + unit + routePolicy coverage added; live smoke `apps/api/integration/sale-return-update.live.mjs` (e2e tenant); report reconciliation (register/trial-balance/account-balances/ledger/outstanding) added to the DB test.
- DB-independent gate GREEN: typecheck 10/10, build 7/7, lint clean, core 26/1614, API pure 125 files/1901 tests 0 fail. DB-backed/live/browser proof authored-for-CI, NOT executed in-sandbox (no working PostgreSQL). **X13 is NOT closed** — finite c27 writer for the ordinary N/P/I/SR1 zero-tax Other 0->1 profile only. See `parity-plan-2026-09-10/43-implementation-progress-round16.md`.

## Where we are (session 4)
- **T1 DONE** — schema is source-of-truth. `web-postgres-1` :5433 has **163 tables / 5878 cols**. `prisma db pull` regenerated `packages/db/prisma/schema.prisma` (162 models, **0 @@ignore** — all PKs present). Gate green; live auth+sales PASS. Backup `/tmp/schema.prisma.bak`.
- **T4 DONE + most of T5** — **a REAL Next.js 15 / React 19 frontend now exists in `apps/web`** and is wired to the live API. Builds clean on Node 25; monorepo gate green (typecheck 10/10, test 10/10, build 7/7).
- **Frontend is the big new thing.** Structure:
  - `app/login` → POST `/api/auth/login`; `app/select` → company+year (`/context/*`); `app/(app)/layout.tsx` auth-guards via `GET /me`.
  - `components/Shell.tsx` → topbar (co/year/user/logout) + sidebar `NAV` mirroring the desktop menu (Masters/Sales/Purchase/Cash-Bank/Inventory/Manufacturing/Loans/Reports/Utilities; unbuilt items tagged "soon").
  - `app/(app)/dashboard` (live KPIs), `masters/[name]` (generic CRUD grid), `reports/[report]` (generic viewer), `txn/sales` (voucher entry), `soon` (placeholder).
  - `lib/api.ts` (fetch `/api/*`, credentials:include), `lib/nav.ts`. `next.config.mjs` proxies `/api/*` → `http://localhost:3000` so httpOnly cookies stay same-origin (no CORS).
- **API additions:** `GET /me`, `GET /masters/:name/meta` (in `apps/api/src/app.ts`).
- **VERIFIED end-to-end through the proxy:** login → select FY2024 → create account CUST900 → create sale (**₹77,250** = 75000 + 3% GST 2250; cgst/sgst 1125) → appears in sales-register. Trial balance balanced.

## How to RUN it (visual test)
```
# API (terminal 1) from web/
DATABASE_URL=postgresql://app_user:app@127.0.0.1:5433/datacare PORT=3000 JWT_SECRET=dev-secret node apps/api/dist/server.js
# Web (terminal 2) from web/
pnpm --filter @datacare/web start      # next start on :3001 (or `dev`)
# Browser: http://localhost:3001  → login admin / Secret#1 / Company 01 → FY 2024
```
(API also still serves the legacy vanilla harness at `http://localhost:3000/`.)

### Real data + tests caveat (RESOLVED)
- The web demo runs on the **real DHAKAN JEWELLERS data** imported into tenant `default` (918 accounts, 190 invoices ₹5.48M, 5150 ledger). Restore/refresh anytime with:
  `DATABASE_URL=postgresql://app_user:app@127.0.0.1:5433/datacare node apps/api/integration/import_real.mjs` (needs SQL Edge `dceparity` up).
- ✅ FIXED (session 5i): all live integration scripts now use a dedicated **`e2e`** tenant (was `default`), so running the full 20/20 suite leaves the demo data + login **completely untouched** (verified SL_DATA/AC_MAST/LOGIN unchanged before/after). auth.live already used `t-auth`.

## Exact next steps
**Working screens now (~50 + 16 reports):** login/select/dashboard · 20 masters (CSV import+export each) · **Sales:** invoice, return, labour, order, hallmark(HUID), wholesale + invoice-PDF · **Purchase:** invoice, return · receipt, payment, contra · dhrn issue/receipt · karigar/MFG/job-work issue+receive · stock/tags, physical-stock · membership(loyalty) · **Reports(16, all CSV+PDF export):** sales/purchase registers, day-book, trial-balance, balance-sheet, account-ledger, account-balances, outstanding, monthly-sales, sales-by-party/item, pledge-outstanding, karigar-balances, stock-valuation, GSTR-1, GSTR-3B · **Utilities:** settings(CO_SET), audit-log, backup, integrations · **3rd-party:** live rates(LIVE), WhatsApp/SMS/e-invoice(real adapters, ready-for-creds), barcode/QR, PDF(Chromium). All on real DHAKAN JEWELLERS data; certified 20/20 live + 190/190 compute parity.
1. **Sale variants:** TR_SALE_LBR (labour), TR_SALE_HM (hallmark), TR_SALE_ORD (order) — reuse `sales.ts`/`computeLine`; new books; add UI + parity. TR_SALE_RTN return is DONE (pattern in `salesReturn.ts`).
2. **More inventory (Phase E):** TR_PHYSTK physical-stock reconcile, TR_TAG_SPLIT, TR_ITM_LOT — extend stock.ts.
3. **Reports (Phase K, biggest bucket):** expand beyond the 6 — add dataset builders for stock valuation, GST 3B/HSN, dhrn outstanding list, karigar ledger, day-book variants; field-parity to `all_rpt_fields`.
4. **Finish T5 UI kit:** lookups, F-key grid, PDF preview, barcode/QR.
5. Then Phases F–O per todo graph. Keep `state.json`+JOURNAL+this file current each task.

## Established port pattern (proven on sale-return)
read form `.cs`/spec → check real PG columns (`docker exec web-postgres-1 psql -U datacare -d datacare -tAc "...information_schema.columns..."`) → port module (reuse posting/calc/numbering) → REST in routes/txn.ts → UI screen + nav `ready:true` → Tier-1 test → live smoke (verify trial balance still balances) → `pnpm typecheck` (catch TS; build emits despite errors). DB errors now auto-map to 400 in `run()`.

## Established patterns (reuse)
- Backend module = pure core (Tier-1) + tx-aware composition via `withTenant`/`atomic`; post via `posting.ts`; number via `vouchers/numbering.ts`; RBAC `assertRight`. Expose REST in `routes/txn.ts`. Live test `apps/api/integration/<x>.live.mjs` run as `DATABASE_URL=<app_user> node ...` after `pnpm --filter @datacare/api build`.
- Masters are config-driven (`configs.ts` MASTERS registry). UI master screen is fully generic — new master = new config + nav entry.
- Frontend screen = client component in `app/(app)/...`, calls `lib/api.ts` get/post/del. Add nav entry in `lib/nav.ts` with `ready:true`.

## Environment
- Docker UP. Postgres `web-postgres-1` :5433. Owner URL `postgresql://datacare:datacare@127.0.0.1:5433/datacare`; **runtime (RLS) `postgresql://app_user:app@127.0.0.1:5433/datacare`** (app MUST use app_user). DDL via `docker exec web-postgres-1 psql -U datacare -d datacare`.
- Golden-master parity (Tier-4): Azure SQL Edge (arm64) image pulled; restore Next24 from `unified/database/backups/`; query via JS `mssql`/`tedious`. Tools: `apps/api/integration/xdb_diff.mjs` (data-fidelity matrix), `compute_parity.live.mjs` (invoice recompute). Proven: 141/141 cols, 371/372 Σ, 190/190 compute.
- Node v25.8.0, pnpm 9.15.4. Next.js 15.1.6 confirmed working on Node 25.

## Reference assets
- Decompiled spec: `unified/src/csharp/DataCareNext/*.cs` (204 forms / 969K LOC). Reports: `unified/reports/*.rpt` (255). Form specs: `project-memory/catalogs/forms/*.md`. Data model: `catalogs/data-model.json`. Module map: `catalogs/module-map.json`.

## Blockers / external deps (only pause for these)
Third-party integrations are RESEARCHED + WIRED (real adapters behind interfaces). **Live now, no creds:** live gold/silver/forex rates (gold-api.com+frankfurter.app), barcode/QR, PDF(Playwright). **Wired — go live by setting env (no code change):**
- WhatsApp Cloud API: `WA_PHONE_ID`, `WA_TOKEN` (Meta Graph v22) — desktop UT_WAPP_WITH_API.
- SMS gateway: `SMS_URL_TEMPLATE` (with {key}{sender}{mobile}{text}), `SMS_KEY`, `SMS_SENDER` — desktop used tripadasmsbox/ping4sms/mobileadz.
- E-invoice GSP: Chartered Info (`einvapi.charteredinfo.com`) aspid/password/Gstin/User_Name/eInvPwd — desktop TR_SL_EBILL/UT_E_INVOICE; behind IrnTransport (Fake until set).
- Payment gateway / UAE Planet Payment / OLocker insurance — adapters TBD when needed.
