# Phase 1 delivery plan — the desktop, in the web

Phase 1 makes the web application do what DataCareNext does: every in-scope menu, workflow, form, print and business
rule, across database, API and screens, with the same write sets, calculations and report data
([ADR-0004](../../project-memory/decisions/ADR-0004-two-phase-delivery.md)). This document orders the existing plan
for that goal. It does not replace documents 02, 10, 11 or 12: the slices, gaps and decisions stay where they are
defined, and their status lives in [`execution-backlog.json`](execution-backlog.json).

- **Baseline:** `main` at `675d845`; per-menu state in the [menu catalog](../handbook/menu-catalog.md).
- **Inputs:** documents 02 (waves W00–W15), 04 (acceptance), 10 (G01–G19, N31–N46), 11 (G20–G68, N47–N82, phases A–F),
  12 (G69–G81, N83–N88).
- **Companions:** [engineering standards](../handbook/web/engineering-standards.md) (how code is written),
  [testing](../handbook/web/testing.md) (how it is proven), the agent skills listed in [`AGENTS.md`](../../AGENTS.md).

## 1. Definition of done

**For one menu.** A P1-core menu is always in scope; a P1-edition menu is in scope for a customer when one of its
books is in use or its edition setting is on (D21). It is done when:

1. Every desktop mode of the menu (book family, constructor mode, edition branch) opens the right web screen.
2. The lifecycle the desktop allows works: create, reopen a saved voucher with every field, edit, delete or cancel,
   print with the selected copies, and list saved vouchers with their full identity.
3. A database test compares the complete write set with independently derived expected rows (testing §3), and the
   desktop differential matches when a desktop capture exists (N83).
4. A zero-mock journey drives the screen (testing §4), and the Chrome DevTools visual protocol is recorded for it
   (testing §5).
5. Its print uses a bound template with the desktop copies (N73–N75); its reports show the desktop modes and filters.
6. An operator accepts it in the side-by-side comparison of document 04.

Engineering completion of a slice (document 11 §7) moves it to `implemented-unverified`; items 5 and 6 and the
release certificate are recorded on the parent packages.

**For Phase 1.** All P1-core menus and the P1-edition menus of the pilot customers are done; journeys J01–J28 pass
on the desktop and the web from the same data; two migration rehearsals reconcile (N79); a restore drill meets the
agreed RPO and RTO (N80); the release certifier passes on one candidate (gates from N82, certification in N30). No desktop weakness from the desktop
handbook §8 is reproduced.

## 2. Starting point

From the [menu catalog](../handbook/menu-catalog.md#summary) (engineering grade, 1 October):

| Measure | Count |
|---|---:|
| Desktop menus | 198 (131 P1-core, 66 P1-edition, 1 web-only dashboard) |
| Working web workflow with gaps (PARTIAL) | 126 |
| Report menus with incomplete modes, filters or prints (REPORT) | 65 |
| Contained on purpose (data backup restore, tag weight change) | 2 |
| Missing workflows (Card Rec, Tour Sales, Dhrn Os Letter, Loan Intrest, Cust Entry) | 5 |
| Voucher and master screens that can create but not reopen or edit (29 of them P1-core) | 48 |
| Screens with every lifecycle action (create, reopen, edit, delete, print, list) | 11 |
| Completion-register rows that name the wrong form or surface (G71) | 20 |

Cross-cutting blockers recorded in document 11: no request schemas (G25), no version tokens or idempotency
(G27–G29), web-only provisioning conventions (G38–G41), lossy reopen on seven families (G45, G46), 28 of 254 report
layouts bound (G59, G60), a non-hermetic browser suite (G23), and the runtime advisory of G72.

## 3. Delivery order

Stages follow document 11 phases A–F, with the new slices placed where they unblock work. Stages overlap where
dependencies allow; changes to shared posting, numbering, scope and rounding code pass through one integration owner
(document 02 §2).

| Stage | Purpose | Slices | Exit gate |
|---|---|---|---|
| 0 — Now | Remove known security exposure | N86 (runtime advisory, Node 24, Prisma 7 by 19 November 2026 — D26), N81 (secrets) | No installed package inside a known critical advisory; no credential in the delivery source |
| A — Trustworthy build | Gates and harnesses green before more behaviour is claimed | N47, N48 (restore milestone), N49, N83, N85, N87 (status of each in the backlog) | Every engineering gate, the 24-journey suite and the documentation checks block in CI; the differential reports coverage per family |
| B — Stop wrong documents and data loss | Small S1 fixes | N56, N53, N40, N51 milestone 1, N50 milestone 1, N54 milestone 1, N34 remainder | Printed dates carry the year; no observed 500; no edit loses data; the timeout test is stable |
| C — Foundations | Contracts every workflow depends on | N50, N51, N52, N55, N58–N63, N84, N88 | Schemas, versions and idempotency on every financial path; desktop-shaped provisioning; no literal account fallbacks; route plugins and the shared voucher editor in use |
| D — Workflow completeness | Finish what operators use daily, then the rest | §4 waves D1–D5 (N64–N72 with N17–N23, N32, N37, N38, N44–N46) | Each workflow passes create, reopen, edit, delete and print with its write-set test, journey and visual record |
| E — Documents and operator experience | Desktop-equivalent prints, reports, language and layout | N57, N73, N43, N74, N75, N76, N77, N24 | Wave A–D templates bound; the top 20 forms pass the layout comparison |
| F — Migration, operations and release | Move real customers safely and certify | N78, N79 (completes N27), N80, N82, N25, N28–N30 | Two clean rehearsals; restore drill meets RPO/RTO; certifier passes on one candidate |

**First queue, in order:** N86; N49 step 1 (hermetic tag-split seed); N53; N56; N51 milestone 1; N54 milestone 1;
N40; N50 milestone 1 together with the first N88 route plugin for the same family (D27); N48 restore milestone; N58
template generator; N83; N85.

**Parallel lanes.** Five lanes keep engineers out of each other's files:

| Lane | Slices | Main files |
|---|---|---|
| 1 Platform and gates | N86, N81, N48, N49, N83, N85, N88 (structure) | CI workflows, `web/scripts/`, `web/apps/api/integration/`, package manifests |
| 2 API integrity and conventions | N50–N55, N58–N63, N84 | `web/apps/api/src/modules/{vouchers,posting,shared,auth,ops}`, migrations |
| 3 Workflows | N64–N72 and the earlier workflow slices | Domain modules and their pages |
| 4 Documents and experience | N56, N57, N73–N77, N24, N43 | `web/apps/api/src/modules/reports`, `web/apps/api/src/modules/documents`, report and layout pages |
| 5 Migration and operations | N78–N80, N82, N25–N30 | `web/apps/api/integration/cutover.mjs`, `web/deploy/`, release certification |

## 4. Module delivery map

Waves inside stage D. Each row lists the work in order; the catalog rows of the tab give the per-menu detail.

**D1 — The daily shop cycle (P1-core).**

| Tab | Now | Work, in order | Proven by |
|---|---|---|---|
| Transaction | 24 partial (13 core) | N40 and N63 lossless sales, quotation and purchase edit → N64 cash and bank receipt/payment lifecycle → N67 contra and bullion-sale screens on their existing APIs → N62 book families → N61 companion columns → N34 purchase return → N44/N46 quotation-to-order-to-sale → N74 daily prints | J04, J02, J12, J07, J08 |
| Master | 23 partial (14 core) | N58 and N69 master semantics (auto-item order, labour propagation, Style opens Models) → N67 party lifecycle → N63 tag opening without loss → N77 child grids and layout | J01, J02 |
| Company | 14 partial, backup contained | N58 company, year and location creation with the desktop 17-table copy → N59 configured accounts → N60 trading groups and final statements → N55 users and rights → N77 settings layout | J01, J21 |
| Other (daily) | Daily rate, bank reconciliation, tag print, order cancel | Daily-rate grid and print → bank-reconciliation print and running balance → N25 label printing → N37 multi-order cancel | J12, J22 |

**D2 — Stock and custody.**

| Tab | Now | Work | Proven by |
|---|---|---|---|
| Other (stock) | Tag cancel, transfer and split implemented; weight change contained; physical stock partial | N20 physical stock session → N19 weight change (lift containment) → stock adjust and tag adjust lifecycle (X18) → N26 import, export, renumber and estimate reset | J14, J15, J16, J23 |
| ExtraTran | 20 partial, Card Rec missing | N22 approval, consignment and VP chain → N68 bill-wise receipt lifecycle → N70 Card Rec → N67 fine JV and old-item sales → N33 other income and expense lists → N17 fine sale and purchase | J09, J10, J12 |
| Karigar (repair, tour) | Repair chain CRUD; Tour Sales missing | N22 repair chain and employee stock → N70 Tour Sales | J11, J10 |

**D3 — Karigar and manufacturing.**

| Tab | Now | Work | Proven by |
|---|---|---|---|
| Karigar | Issue and receipt create-only; design issue writes the wrong family | N67 karigar issue and receipt screens → N71 design issue in the APR family → N24 karigar reports | J17, J18 |
| Mfg | Process master generic; stage screens outside the menu table | N71 process-master side effects → N21 lot workflow → N72 stage screens by D21 | J17, J18 |

**D4 — Schemes, Dhiran and loans.**

| Tab | Now | Work | Proven by |
|---|---|---|---|
| Scheme | 6 partial, 5 report | N66 member master and multi-member entry → N23 maturity and gold adjustment → N24 reports → N84 scheme bank account column | J20 |
| Dhiran | 5 partial, 5 report, 2 missing | N65 pledge and loan lifecycles including Loan Interest and the outstanding letter → N23 → N24 → N75 letter template | J19 |

**D5 — Edition modes.** Bullion booking and sale (X16), UAE VAT forms (X32), Next25 columns (N84), e-invoice and
e-credit-note provider flows (N16, X15), SMS and WhatsApp campaigns (N54, N25), CRM customer entry (N70). Each is
scheduled when a pilot customer's edition needs it.

**Stage E for the report tabs.** Report (26), More (12) and Analysis (8) are all REPORT today: N57 typed grid and
exports → N24 desktop modes, filters and drill-downs → N36 sales and purchase classification → N60 final statements
→ N73–N75 template bindings. Proven by J22.

## 5. What to add, and where

Files that do not exist yet are marked as planned.

<!-- planned: web/apps/api/src/modules/shared/errors.ts -->
<!-- planned: web/apps/api/src/routes/index.ts -->

**Database (`web/packages/db`).**
- Forward migrations only, each registered in `web/apps/api/src/modules/ops/migrationManifest.ts`, followed by
  `rls.sql`, `setup_roles.sql` and `pnpm fresh:provision`: the 21 Next25 columns (N84), the command-receipt table for
  idempotency (D18, N52), atomic audit or outbox rows (N55).
- The desktop-equivalent provisioning template (N58): location `00`, 3-digit books, the 5-digit chart, account roles in
  `BOOK_DETL` and the 17 tables that `NewCompParmCreat` copies (desktop handbook, business rules).

**API (`web/apps/api`).**
- One route plugin per module, `web/apps/api/src/modules/<module>/routes.ts`, registered from
  `web/apps/api/src/routes/index.ts`, each route with a JSON Schema (D16, N50, N88). Move one family at a time out of
  `web/apps/api/src/routes/txn.ts` (D27).
- A typed error taxonomy in `web/apps/api/src/modules/shared/errors.ts` (N88).
- Version tokens on every voucher GET, PUT and DELETE and idempotency keys on financial creates, in
  `web/apps/api/src/modules/vouchers/` (D17, D18, N51, N52).
- Configured accounts and books only: remove literal fallbacks behind `web/apps/api/src/modules/shared/postingAccounts.ts`
  and `web/apps/api/src/modules/shared/bookPolicy.ts` (N59).
- Explicit transaction budgets per family on `withTenant` (N53); PDF rendering only from server-built documents in
  `web/apps/api/src/modules/reports/render.ts` (N54).
- Missing workflows: card receipt in `finance`, tour sale in `sales`, customer entry as a new `crm` module (add it to
  the [module map](../handbook/web/modules.md); the check requires it) (N70).

**Web (`web/apps/web`).**
- A shared voucher editor in `web/apps/web/lib/voucher/` (lossless hydration, dirty tracking, version and idempotency
  handling, delete, print, recent list), adopted first by sales, purchase and the cash and bank screens (N88, N63,
  N64, N67).
- A typed report grid replacing the generic formatting of `web/apps/web/app/(app)/reports/[report]/page.tsx` (N57).
- Grids driven by `COL_MAST` captions and visibility, and desktop tab order on the top 20 forms (N77).
- Reviewed language catalogues `en-IN`, `gu-IN` and `hi-IN` (N76); dates shown as `dd/MM/yyyy` (N56).
- Navigation corrections from the catalog (N85).

**Tests, for every slice.** A write-set database test, a zero-mock journey for each changed screen, the visual
protocol record, kernel vectors when calculations change, and the exact route-universe test when routes change
([testing](../handbook/web/testing.md)).

**Size limits (N88).** New or moved route and module files at most 800 lines and pages at most 600; existing larger
files may not grow. `web/packages/core` stays free of I/O; pages call the API only through `web/apps/web/lib/api.ts`.

## 6. How a slice is executed

1. Read the slice in document 10, 11 or 12, its catalog rows and its parent cards.
2. Establish the desktop authority: dispatch line, form source, posting helpers, tutorial keyframe, aggregate
   database facts (desktop handbook §9).
3. Write the expected write set and calculations independently, then failing tests.
4. Implement inside the module's boundaries, following the [engineering standards](../handbook/web/engineering-standards.md).
5. Run every gate locally; run the zero-mock journey and the visual protocol.
6. Update `execution-backlog.json` (status, `statusAsOf`, evidence, note) and document 11 §2 in the same pull request.
7. Open a pull request with what was verified and what was not.

The `datacare-implement-slice` skill in `.kiro/skills/` encodes these steps for agents.

## 7. Exit and hand-over to Phase 2

Phase 1 is complete when everything in §1 holds and the release is certified (N30). Its scope is all P1-core menus
plus the P1-edition menus of the first customers, decided under D01 and D21. **Nothing in Phase 2 starts before
that, including the Phase 2 decisions** (milestone M0 in [document 14](14-phase2-saas-plan.md)): decision D28, the
owner's instruction of 1 October 2026. N86 and N88 are Phase 1 slices and are not affected. The Phase 1 golden
vectors, write-set tests, journeys and differential stay blocking for every later change.

## 8. Risks and decisions

| Risk | Mitigation |
|---|---|
| A shared kernel or posting change breaks a family that is already correct | One integration owner; write-set tests and journeys for every family on every change |
| No runnable Windows desktop to capture expected rows | Prefer captured desktop database rows and tutorial evidence; keep source-derived items marked until a capture confirms them (document 05) |
| Parallel sessions collide (backlog edits, fixed test ports) | Rebase before pushing; N49 makes the harness ports configurable |
| Customer data leaks into the repository | Aggregate queries only; fixtures are synthetic; the documentation check scans for credential and phone patterns |
| Edition scope grows without limit | D21 per customer, recorded in the catalog phase column |

Decisions: D23–D28 (document 12) were accepted by the owner on 1 October 2026. Still to be approved before their
slices start: D15–D22 (document 11), and the role-owned decisions D01–D14 of document 08 when their waves begin.
