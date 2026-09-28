# DataCareNext Desktop-to-Web Parity Matrix

**Generated:** 2026-07-29T08:12:14+00:00  
**Machine sources:** `DESKTOP-WEB-PARITY-MATRIX.json`, `DESKTOP-WEB-PARITY-MATRIX.csv`  
**Decision:** **NO-GO for production or live financial/inventory migration.**

This matrix replaces route/model/test-count completion claims with six monotonic gates. The current web has substantial engineering breadth, but **0 forms, tables, reports, settings, shortcuts, or invariants have a desktop-comparison artifact, and 0 are production-certified**.

## Gate contract

| Code | Gate/status meaning |
|---|---|
| P | Passed with a cited artifact |
| IP | Work/evidence exists but pass criteria are not met |
| NS | Not started/no qualifying artifact |
| B | Blocked by a named external or prerequisite dependency |
| EG | Required desktop evidence is absent from supplied artifacts |
| W | Formally waived with a dated documented rationale |

Gate codes: G1 extracted, G2 understood, G3 implemented, **GD depth**, G4 tested, G5 desktop-compared, G6 production-certified.

- **extracted:** Canonical source/schema/layout exists, or an explicit evidence gap is recorded.
- **understood:** Approved fields, focus/keys, validation, calculations, writes, reversal and report semantics exist.
- **depth:** Persists >=99% of the desktop write set with no unwritten desktop table, >=95% grid-column coverage and an approved contract. Breadth without depth is not parity.
- **implemented:** Complete reachable UI/API/DB/report/security/integration behavior exists; routes/models/generic renderers alone do not pass.
- **tested:** CI invokes real functions and dependencies across unit, invariant, integration, authorization, concurrency, migration and failure paths.
- **desktop_compared:** Scripted desktop and web workflows have zero/approved row, calculation, keyboard and visual/PDF differences.
- **production_certified:** Load, security, observability, backup/restore, DR, device/site UAT and business sign-off pass.

Anti-inflation rule: a route, `ready: true`, model, layout preview, 200 response, build, or mock/builder test is progress—not parity. Only `desktop_compared=passed` contributes to a parity percentage.

## Universe and current gates

| Surface | Units | Extracted | Understood | Implemented | Depth | Tested | Desktop-compared | Production-certified |
|---|---:|---|---|---|---|---|---|---|
| Forms | 204 | P 204 | IP 201, P 3 | IP 193, W 11 | EG 25, IP 104, NS 1, P 1, W 73 | IP 98, NS 106 | NS 204 | NS 204 |
| Desktop tables | 146 | P 146 | IP 146 | IP 146 | IP 56, NS 43, P 47 | IP 112, NS 34 | NS 146 | NS 146 |
| Report obligations | 275 | EG 20, IP 1, P 253, W 1 | B 20, IP 255 | B 20, IP 254, W 1 | W 275 | IP 254, NS 20, W 1 | NS 275 | NS 275 |
| Settings | 57 | P 57 | IP 57 | IP 47, W 10 | W 57 | IP 45, NS 12 | NS 57 | NS 57 |
| Shortcuts | 13 | IP 10, P 3 | IP 13 | IP 13 | W 13 | IP 13 | NS 13 | NS 13 |
| Critical invariants | 25 | P 25 | P 25 | IP 17, NS 1, P 7 | W 25 | IP 11, NS 8, P 6 | NS 25 | NS 25 |

Report obligations include **255 supplied RPT binaries plus 20 code-referenced RPTs absent from all supplied roots**. Supplied layouts are 253 complete, one partial (`SalesQuotation`), and one unavailable (`TagStkIdtlRpt`).

## Current implementation shape (not parity)

### Form mapping classes

| Mapping class | Forms | Meaning |
|---|---:|---|
| `conceptual-engine` | 41 | Behavior is intended to be absorbed by a cross-cutting engine. |
| `conceptual-report-engine` | 34 | Computed/generic report engine, not a ported desktop dialog. |
| `dedicated-current-surface` | 48 | Dedicated route/handler exists; behavior remains uncertified. |
| `generic-crud-scaffold` | 16 | Metadata-driven CRUD only. |
| `generic-report-scaffold` | 12 | Generic report/layout surface only. |
| `generic-scaffold` | 1 | Adjacent/generic surface only. |
| `variant-shared` | 41 | Several desktop variants share one current engine/surface. |
| `waived-documented` | 11 |  |

### Mapping shape by desktop category

| Category | Mapping classes |
|---|---|
| master | `conceptual-engine` 2, `dedicated-current-surface` 2, `generic-crud-scaffold` 16, `generic-scaffold` 1, `variant-shared` 10, `waived-documented` 2 |
| other | `conceptual-engine` 36, `variant-shared` 1, `waived-documented` 6 |
| report | `conceptual-report-engine` 34, `generic-report-scaffold` 11 |
| transaction | `conceptual-engine` 2, `dedicated-current-surface` 39, `variant-shared` 18, `waived-documented` 2 |
| utility | `conceptual-engine` 1, `dedicated-current-surface` 7, `generic-report-scaffold` 1, `variant-shared` 12, `waived-documented` 1 |

### Engineering breadth kept separate

- 100 frontend pages; 369 declared API routes; 170 Prisma models; 97 API test files.
- 175 web form-layout asset files normalize to 163/204 distinct desktop form IDs; 254 web report spec files.
- One headless-Chromium production smoke covers selected workflows and keyboard paths; there is still no visual, load, or desktop-comparison suite, and the report package remains incomplete.

## Release-blocking invariants

| Invariant | Implemented | Tested | Blockers | Acceptance focus |
|---|---|---|---|---|
| Tenant isolation | P | P | — | Close every linked blocker with reproducible test evidence. |
| Authoritative company/location/year/book scope | P | P | — | Close every linked blocker with reproducible test evidence. |
| USER_SET per-form View/Edit/Delete/Print API enforcement | P | P | — | Close every linked blocker with reproducible test evidence. |
| Per-tenant/company/location/year/book unique numbering under concurrency | IP | IP | C3-numbering-concurrency | Close every linked blocker with reproducible test evidence. |
| Fail-closed lock date for create/edit/delete/reversal | IP | NS | H2-period-lock-reversal | Close every linked blocker with reproducible test evidence. |
| ΣDr = ΣCr on every posting and reversal | IP | IP | QA-no-real-posting-tests | Close every linked blocker with reproducible test evidence. |
| Independent gold/silver/fine ledger balance | IP | NS | C4-workflow-fine-policy | Close every linked blocker with reproducible test evidence. |
| Workflow-specific fine formula and rounding policy | IP | IP | C4-workflow-fine-policy | Close every linked blocker with reproducible test evidence. |
| Every tagged and loose line emits correct signed MAIN_STOCK movement | IP | NS | C1-loose-stock | Close every linked blocker with reproducible test evidence. |
| Tag can be consumed once under concurrency | IP | NS | H3-tag-concurrency | Close every linked blocker with reproducible test evidence. |
| Server derives complete reversal from persisted voucher state | IP | NS | C2-server-derived-reversal | Close every linked blocker with reproducible test evidence. |
| Voucher, ledgers, tax, bill, stock, tags and audit commit/rollback atomically | IP | NS | QA-no-real-posting-tests | Close every linked blocker with reproducible test evidence. |
| Book/company-configured monetary and weight rounding | IP | IP | ROUNDING-policy | Close every linked blocker with reproducible test evidence. |
| GST place-of-supply split, registers and statutory reconciliation | IP | IP | QA-no-desktop-gst-comparison | Close every linked blocker with reproducible test evidence. |
| Bill allocation/outstanding lifecycle and reversal | IP | IP | POSTING-bill-allocation | Close every linked blocker with reproducible test evidence. |
| Crystal dataset/formula/group/pagination/image/font fidelity | IP | IP | H7-report-fidelity, H10-no-desktop-comparison | Close every linked blocker with reproducible test evidence. |
| Real PDF renderer is mandatory and ready in production image | P | P | — | Close every linked blocker with reproducible test evidence. |
| Password migration/reset, strong JWT secret, refresh/revocation and secure cookies | P | P | — | Close every linked blocker with reproducible test evidence. |
| Schema, audit_log, RLS and roles are migration-owned and startup-verified | P | IP | — | Close every linked blocker with reproducible test evidence. |
| Immutable tenant-isolated audit trail with observable failures | P | P | — | Close every linked blocker with reproducible test evidence. |
| Scale, webcam/scanner and printer bridge with site certification | NS | NS | DEVICE-no-bridge | Close every linked blocker with reproducible test evidence. |
| Rates, e-invoice, SMS/WhatsApp certified with idempotency/reconciliation | IP | IP | INTEGRATION-live-certification | Close every linked blocker with reproducible test evidence. |
| Structured logs, metrics/traces, readiness and invariant alerts | IP | IP | OPS-observability | Close every linked blocker with reproducible test evidence. |
| Offsite backup, automated restore drill and approved RPO/RTO | IP | NS | OPS-backup-restore | Close every linked blocker with reproducible test evidence. |
| CI applies migrations/RLS and runs integration/concurrency/visual/load suites | IP | IP | QA-missing-live-suites | Close every linked blocker with reproducible test evidence. |

## All 204 desktop forms

The row maps current evidence only. `IP` never means desktop behavior is complete.

| Form | Type | Current mapping | Frontend | API/module evidence | Tests | G1 | G2 | G3 | GD | G4 | G5 | G6 | Risk/blockers |
|---|---|---|---|---|---|---:|---:|---:|---:|---:|---:|---:|---|
| `Ac_Final` | other | `conceptual-engine` (high) | /utilities/year-end, /reports/balance-sheet | `web/apps/api/src/modules/accounting/accounting.ts`, `web/apps/api/src/modules/ops/yearEnd.ts` | — | P | IP | IP | IP | NS | NS | NS | low |
| `Ac_Image` | other | `variant-shared` (medium) | /masters/party, /txn/tag-print | `web/apps/api/src/modules/masters/party.ts`, `web/apps/api/src/modules/stock/tagPrint.ts` | — | P | IP | IP | IP | NS | NS | NS | low |
| `Ac_Ledr` | other | `conceptual-engine` (high) | — | `web/apps/api/src/modules/accounting/accounting.ts`, `web/apps/api/src/modules/posting/posting.ts` | — | P | IP | IP | IP | NS | NS | NS | low |
| `Ac_Rojmel` | other | `conceptual-engine` (high) | /reports/day-book | `web/apps/api/src/modules/reports/reports.ts` | — | P | IP | IP | IP | NS | NS | NS | low |
| `Ac_Stock` | other | `conceptual-engine` (high) | /txn/stock, /reports/tag-stock | `web/apps/api/src/modules/stock/stock.ts` | — | P | IP | IP | IP | NS | NS | NS | low |
| `Ac_Tax` | other | `conceptual-engine` (high) | /reports/gstr1, /reports/gstr2, /reports/gstr3b | `web/apps/api/src/modules/gst/gst.ts` | — | P | IP | IP | IP | NS | NS | NS | low |
| `AuthClass` | other | `conceptual-engine` (medium) | /login | `web/apps/api/src/modules/auth/auth.service.ts`, `web/apps/api/src/modules/auth/jwt.ts` | — | P | IP | IP | EG | NS | NS | NS | low |
| `AuthError` | other | `conceptual-engine` (medium) | /login | `web/apps/api/src/modules/auth/auth.service.ts`, `web/apps/api/src/modules/auth/jwt.ts` | — | P | IP | IP | EG | NS | NS | NS | low |
| `BtmSchm` | other | `conceptual-engine` (high) | /txn/scheme | `web/apps/api/src/modules/membership/scheme.ts` | — | P | IP | IP | IP | NS | NS | NS | low |
| `ClassTagList` | other | `conceptual-engine` (high) | /txn/stock, /reports/tag-stock | `web/apps/api/src/modules/stock/stock.ts` | — | P | IP | IP | EG | NS | NS | NS | low |
| `ClsAddlDocDtls` | other | `conceptual-engine` (medium) | /utilities/e-invoice | `web/apps/api/src/modules/einvoice/einvoice.ts` | — | P | IP | IP | EG | NS | NS | NS | low |
| `ClsAttribDtls` | other | `conceptual-engine` (medium) | /utilities/e-invoice | `web/apps/api/src/modules/einvoice/einvoice.ts` | — | P | IP | IP | EG | NS | NS | NS | low |
| `ClsBchDtls` | other | `conceptual-engine` (medium) | /utilities/e-invoice | `web/apps/api/src/modules/einvoice/einvoice.ts` | — | P | IP | IP | EG | NS | NS | NS | low |
| `ClsBuyerDtls` | other | `conceptual-engine` (medium) | /utilities/e-invoice | `web/apps/api/src/modules/einvoice/einvoice.ts` | — | P | IP | IP | EG | NS | NS | NS | low |
| `ClsContrDtls` | other | `conceptual-engine` (medium) | /utilities/e-invoice | `web/apps/api/src/modules/einvoice/einvoice.ts` | — | P | IP | IP | EG | NS | NS | NS | low |
| `ClsDispDtls` | other | `conceptual-engine` (medium) | /utilities/e-invoice | `web/apps/api/src/modules/einvoice/einvoice.ts` | — | P | IP | IP | EG | NS | NS | NS | low |
| `ClsDocDtls` | other | `conceptual-engine` (medium) | /utilities/e-invoice | `web/apps/api/src/modules/einvoice/einvoice.ts` | — | P | IP | IP | EG | NS | NS | NS | low |
| `ClsDocPerdDtls` | other | `conceptual-engine` (medium) | /utilities/e-invoice | `web/apps/api/src/modules/einvoice/einvoice.ts` | — | P | IP | IP | EG | NS | NS | NS | low |
| `ClsExpDtls` | other | `conceptual-engine` (medium) | /utilities/e-invoice | `web/apps/api/src/modules/einvoice/einvoice.ts` | — | P | IP | IP | EG | NS | NS | NS | low |
| `ClsItemList` | other | `waived-documented` (high) | — | — | — | P | IP | W | W | NS | NS | NS | low |
| `ClsPayDtls` | other | `conceptual-engine` (medium) | /utilities/e-invoice | `web/apps/api/src/modules/einvoice/einvoice.ts` | — | P | IP | IP | EG | NS | NS | NS | low |
| `ClsPrecDocDtls` | other | `conceptual-engine` (medium) | /utilities/e-invoice | `web/apps/api/src/modules/einvoice/einvoice.ts` | — | P | IP | IP | EG | NS | NS | NS | low |
| `ClsRefDtls` | other | `conceptual-engine` (medium) | /utilities/e-invoice | `web/apps/api/src/modules/einvoice/einvoice.ts` | — | P | IP | IP | EG | NS | NS | NS | low |
| `ClsSellerDtls` | other | `conceptual-engine` (medium) | /utilities/e-invoice | `web/apps/api/src/modules/einvoice/einvoice.ts` | — | P | IP | IP | EG | NS | NS | NS | low |
| `ClsShipDtls` | other | `conceptual-engine` (medium) | /utilities/e-invoice | `web/apps/api/src/modules/einvoice/einvoice.ts` | — | P | IP | IP | EG | NS | NS | NS | low |
| `ClsTranDtls` | other | `conceptual-engine` (medium) | /utilities/e-invoice | `web/apps/api/src/modules/einvoice/einvoice.ts` | — | P | IP | IP | EG | NS | NS | NS | low |
| `ClsValDtls` | other | `conceptual-engine` (medium) | /utilities/e-invoice | `web/apps/api/src/modules/einvoice/einvoice.ts` | — | P | IP | IP | EG | NS | NS | NS | low |
| `DC_Main` | other | `conceptual-engine` (high) | /dashboard | `web/apps/web/components/Shell.tsx`, `web/apps/web/lib/nav.ts` | — | P | IP | IP | W | NS | NS | NS | low |
| `Data` | other | `waived-documented` (high) | — | — | — | P | IP | W | W | NS | NS | NS | low |
| `DcClass` | other | `waived-documented` (high) | — | — | — | P | IP | W | W | NS | NS | NS | low |
| `DcPrintClass` | other | `waived-documented` (high) | — | — | — | P | IP | W | W | NS | NS | NS | low |
| `ErrorResp` | other | `conceptual-engine` (medium) | /utilities/e-invoice | `web/apps/api/src/modules/einvoice/einvoice.ts` | — | P | IP | IP | EG | NS | NS | NS | low |
| `IRNClass` | other | `conceptual-engine` (medium) | /utilities/e-invoice | `web/apps/api/src/modules/einvoice/einvoice.ts` | — | P | IP | IP | EG | NS | NS | NS | low |
| `IRNData` | other | `conceptual-engine` (medium) | /utilities/e-invoice | `web/apps/api/src/modules/einvoice/einvoice.ts` | — | P | IP | IP | EG | NS | NS | NS | low |
| `MDI_FORM` | other | `conceptual-engine` (high) | /dashboard | `web/apps/web/components/Shell.tsx`, `web/apps/web/lib/nav.ts` | — | P | IP | IP | W | NS | NS | NS | low |
| `MS_ACCT` | master | `variant-shared` (high) | /masters/accounts, /masters/customers, /masters/party | `web/apps/api/src/modules/masters/master.service.ts`, `web/apps/api/src/modules/masters/party.ts` | `web/apps/api/test/masters.test.ts` | P | IP | IP | IP | IP | NS | NS | high: C5-authoritative-scope, H1-api-form-rbac |
| `MS_AC_GROUP` | master | `generic-crud-scaffold` (high) | /masters/ac-groups | `web/apps/api/src/modules/masters/configs.ts`, `web/apps/api/src/modules/masters/master.service.ts` | `web/apps/api/test/masters.test.ts` | P | IP | IP | IP | IP | NS | NS | medium: C5-authoritative-scope, H1-api-form-rbac |
| `MS_ADD_MAST` | master | `generic-crud-scaffold` (high) | /masters/addresses | `web/apps/api/src/modules/masters/configs.ts`, `web/apps/api/src/modules/masters/master.service.ts` | `web/apps/api/test/masters.test.ts` | P | IP | IP | IP | IP | NS | NS | medium: C5-authoritative-scope, H1-api-form-rbac |
| `MS_AUTO_ITEM` | master | `dedicated-current-surface` (high) | /masters/auto-item | `web/apps/api/src/modules/masters/autoItem.ts` | `web/apps/api/test/masters.test.ts` | P | IP | IP | W | IP | NS | NS | medium: C5-authoritative-scope, H1-api-form-rbac |
| `MS_BOOK` | master | `generic-crud-scaffold` (high) | /masters/books | `web/apps/api/src/modules/masters/configs.ts`, `web/apps/api/src/modules/masters/master.service.ts` | `web/apps/api/test/masters.test.ts` | P | IP | IP | W | IP | NS | NS | high: C5-authoritative-scope, H1-api-form-rbac |
| `MS_BOOKLIST` | master | `generic-scaffold` (medium) | /masters/books | `web/apps/api/src/modules/masters/master.service.ts` | — | P | IP | IP | W | NS | NS | NS | medium: C5-authoritative-scope, H1-api-form-rbac |
| `MS_COMPANY` | master | `variant-shared` (high) | /masters/companies, /admin/provision, /select | `web/apps/api/src/modules/masters/master.service.ts`, `web/apps/api/src/modules/ops/seedCompany.ts` | — | P | IP | IP | IP | NS | NS | NS | critical: C5-authoritative-scope, H1-api-form-rbac |
| `MS_DESIGN_BOOK` | master | `variant-shared` (medium) | /masters/styles, /masters/designs, /masters/models | `web/apps/api/src/modules/masters/master.service.ts` | `web/apps/api/test/masters.test.ts` | P | IP | IP | IP | IP | NS | NS | medium: C5-authoritative-scope, H1-api-form-rbac |
| `MS_DM` | master | `generic-crud-scaffold` (high) | /masters/diamonds | `web/apps/api/src/modules/masters/configs.ts`, `web/apps/api/src/modules/masters/master.service.ts` | `web/apps/api/test/masters.test.ts` | P | IP | IP | W | IP | NS | NS | medium: C5-authoritative-scope, H1-api-form-rbac |
| `MS_EMP` | master | `generic-crud-scaffold` (high) | /masters/employees | `web/apps/api/src/modules/masters/configs.ts`, `web/apps/api/src/modules/masters/master.service.ts` | `web/apps/api/test/masters.test.ts` | P | IP | IP | W | IP | NS | NS | medium: C5-authoritative-scope, H1-api-form-rbac |
| `MS_GOLD_MAST` | master | `generic-crud-scaffold` (high) | /masters/gold-rate | `web/apps/api/src/modules/masters/configs.ts`, `web/apps/api/src/modules/masters/master.service.ts` | `web/apps/api/test/masters.test.ts` | P | IP | IP | IP | IP | NS | NS | medium: C5-authoritative-scope, H1-api-form-rbac |
| `MS_GROUP` | master | `generic-crud-scaffold` (high) | /masters/groups | `web/apps/api/src/modules/masters/configs.ts`, `web/apps/api/src/modules/masters/master.service.ts` | `web/apps/api/test/masters.test.ts` | P | IP | IP | W | IP | NS | NS | medium: C5-authoritative-scope, H1-api-form-rbac |
| `MS_HELP` | master | `waived-documented` (high) | — | — | — | P | IP | W | W | NS | NS | NS | medium: C5-authoritative-scope, H1-api-form-rbac |
| `MS_ITEM` | master | `generic-crud-scaffold` (high) | /masters/items | `web/apps/api/src/modules/masters/configs.ts`, `web/apps/api/src/modules/masters/master.service.ts` | `web/apps/api/test/masters.test.ts` | P | IP | IP | IP | IP | NS | NS | medium: C5-authoritative-scope, H1-api-form-rbac |
| `MS_LBR_TYPE` | master | `generic-crud-scaffold` (high) | /masters/labour, /masters/labour-update | `web/apps/api/src/modules/masters/labourUpdate.ts`, `web/apps/api/src/modules/masters/master.service.ts` | `web/apps/api/test/masters.test.ts` | P | IP | IP | W | IP | NS | NS | medium: C5-authoritative-scope, H1-api-form-rbac |
| `MS_LOCT` | master | `generic-crud-scaffold` (high) | /masters/locations | `web/apps/api/src/modules/masters/configs.ts`, `web/apps/api/src/modules/masters/master.service.ts` | `web/apps/api/test/masters.test.ts` | P | IP | IP | IP | IP | NS | NS | medium: C5-authoritative-scope, H1-api-form-rbac |
| `MS_LOGIN` | master | `conceptual-engine` (high) | /login, /admin/users | `web/apps/api/src/modules/auth/auth.service.ts`, `web/apps/api/src/modules/auth/jwt.ts`, +1 | `web/apps/api/test/auth.jwt.test.ts`, +2 | P | IP | IP | IP | IP | NS | NS | critical: H1-api-form-rbac, H6-password-session, C5-authoritative-scope |
| `MS_MEMB` | master | `variant-shared` (high) | /txn/membership, /txn/scheme | `web/apps/api/src/modules/membership/membership.ts`, `web/apps/api/src/modules/membership/scheme.ts` | `web/apps/api/test/salesFamilyLifecycle.db.test.ts`, +1 | P | IP | IP | W | IP | NS | NS | medium: C5-authoritative-scope, H1-api-form-rbac |
| `MS_MFG_MAST` | master | `generic-crud-scaffold` (high) | /masters/mfg | `web/apps/api/src/modules/masters/configs.ts`, `web/apps/api/src/modules/masters/master.service.ts` | `web/apps/api/test/masters.test.ts` | P | IP | IP | IP | IP | NS | NS | medium: C5-authoritative-scope, H1-api-form-rbac |
| `MS_OPNCOMP` | master | `variant-shared` (high) | /masters/companies, /admin/provision, /select | `web/apps/api/src/modules/masters/master.service.ts`, `web/apps/api/src/modules/ops/seedCompany.ts` | — | P | IP | IP | IP | NS | NS | NS | medium: C5-authoritative-scope, H1-api-form-rbac |
| `MS_POINT` | master | `generic-crud-scaffold` (high) | /masters/points | `web/apps/api/src/modules/masters/configs.ts`, `web/apps/api/src/modules/masters/master.service.ts` | `web/apps/api/test/masters.test.ts` | P | IP | IP | W | IP | NS | NS | medium: C5-authoritative-scope, H1-api-form-rbac |
| `MS_PRINT` | master | `generic-crud-scaffold` (high) | /masters/print-formats | `web/apps/api/src/modules/masters/configs.ts`, `web/apps/api/src/modules/masters/master.service.ts` | `web/apps/api/test/masters.test.ts` | P | IP | IP | EG | IP | NS | NS | medium: C5-authoritative-scope, H1-api-form-rbac |
| `MS_PRODUCT` | master | `generic-crud-scaffold` (high) | /masters/products | `web/apps/api/src/modules/masters/configs.ts`, `web/apps/api/src/modules/masters/master.service.ts` | `web/apps/api/test/masters.test.ts` | P | IP | IP | IP | IP | NS | NS | medium: C5-authoritative-scope, H1-api-form-rbac |
| `MS_RATE` | master | `variant-shared` (high) | /masters/rates, /txn/daily-rate | `web/apps/api/src/modules/masters/dailyRate.ts`, `web/apps/api/src/modules/masters/rate.ts` | `web/apps/api/test/rates.test.ts` | P | IP | IP | IP | IP | NS | NS | medium: C5-authoritative-scope, H1-api-form-rbac |
| `MS_STK_LIMIT` | master | `variant-shared` (medium) | /masters/item-weights | `web/apps/api/src/modules/masters/master.service.ts` | — | P | IP | IP | W | NS | NS | NS | medium: C5-authoritative-scope, H1-api-form-rbac |
| `MS_STYLE` | master | `variant-shared` (medium) | /masters/styles, /masters/designs, /masters/models | `web/apps/api/src/modules/masters/master.service.ts` | `web/apps/api/test/masters.test.ts` | P | IP | IP | IP | IP | NS | NS | medium: C5-authoritative-scope, H1-api-form-rbac |
| `MS_TASTING` | master | `waived-documented` (high) | — | — | — | P | IP | W | W | NS | NS | NS | medium: C5-authoritative-scope, H1-api-form-rbac |
| `MS_TAX` | master | `generic-crud-scaffold` (high) | /masters/taxes | `web/apps/api/src/modules/masters/configs.ts`, `web/apps/api/src/modules/masters/master.service.ts` | `web/apps/api/test/masters.test.ts` | P | IP | IP | W | IP | NS | NS | medium: C5-authoritative-scope, H1-api-form-rbac |
| `MS_TRADE` | master | `generic-crud-scaffold` (high) | /masters/trade | `web/apps/api/src/modules/masters/configs.ts`, `web/apps/api/src/modules/masters/master.service.ts` | `web/apps/api/test/masters.test.ts` | P | IP | IP | W | IP | NS | NS | medium: C5-authoritative-scope, H1-api-form-rbac |
| `MS_UPDATE` | master | `conceptual-engine` (high) | /utilities/data-refresh, /masters/labour-update | `web/apps/api/src/modules/masters/labourUpdate.ts`, `web/apps/api/src/modules/utilities/dataRefresh.ts` | — | P | IP | IP | IP | NS | NS | NS | medium: C4-workflow-fine-policy, C5-authoritative-scope, H1-api-form-rbac |
| `MS_USER` | master | `dedicated-current-surface` (high) | /admin/users | `web/apps/api/src/modules/rbac/formRights.ts`, `web/apps/api/src/modules/rbac/users.ts` | `web/apps/api/test/rbac.policy.test.ts` | P | IP | IP | IP | IP | NS | NS | critical: H1-api-form-rbac, H6-password-session, C5-authoritative-scope |
| `MS_WINDOW_SET` | master | `variant-shared` (medium) | /settings, /masters/styles | `web/apps/api/src/modules/settings/settings.ts` | — | P | IP | IP | W | NS | NS | NS | medium: C5-authoritative-scope, H1-api-form-rbac |
| `MS_YEAR` | master | `variant-shared` (high) | /masters/years, /masters/year-create, /utilities/year-end | `web/apps/api/src/modules/masters/year.ts`, `web/apps/api/src/modules/ops/yearEnd.ts` | — | P | IP | IP | IP | NS | NS | NS | critical: C5-authoritative-scope, H1-api-form-rbac |
| `Mfg_Module` | other | `conceptual-engine` (high) | /txn/mfg-issue, /txn/mfg-receive | `web/apps/api/src/modules/manufacturing/mfg.ts` | — | P | IP | IP | IP | NS | NS | NS | low |
| `Module_Save` | other | `conceptual-engine` (high) | — | `web/apps/api/src/modules/accounting/accounting.ts`, `web/apps/api/src/modules/posting/posting.ts` | — | P | IP | IP | W | NS | NS | NS | low |
| `Module_Schm` | other | `conceptual-engine` (high) | /txn/scheme | `web/apps/api/src/modules/membership/scheme.ts` | — | P | IP | IP | IP | NS | NS | NS | low |
| `Module_WhatsApp` | other | `conceptual-engine` (high) | /integrations | `web/apps/api/src/modules/integrations/messaging.ts` | — | P | IP | IP | W | NS | NS | NS | low |
| `OlockerService` | other | `waived-documented` (high) | — | — | — | P | IP | W | W | NS | NS | NS | low |
| `PolicyModels` | other | `conceptual-engine` (medium) | /utilities/e-invoice | `web/apps/api/src/modules/einvoice/einvoice.ts` | — | P | IP | IP | EG | NS | NS | NS | low |
| `RP_ADDRESS` | report | `generic-report-scaffold` (low) | /reports/report-layouts | `web/apps/api/src/modules/reports/reportEngine.ts`, `web/apps/api/src/modules/reports/reports.ts` | — | P | IP | IP | IP | NS | NS | NS | medium: C5-authoritative-scope, H1-api-form-rbac, H7-report-fidelity, H10-no-desktop-comparison |
| `RP_ALL` | report | `conceptual-report-engine` (medium) | /reports/report-layouts | `web/apps/api/src/modules/reports/reportEngine.ts`, `web/apps/api/src/modules/reports/reports.ts` | — | P | IP | IP | IP | NS | NS | NS | medium: C5-authoritative-scope, H1-api-form-rbac, H7-report-fidelity, H10-no-desktop-comparison |
| `RP_BALANCE` | report | `conceptual-report-engine` (medium) | /reports/balance-sheet, /reports/account-balances | `web/apps/api/src/modules/reports/reportEngine.ts`, `web/apps/api/src/modules/reports/reports.ts` | — | P | IP | IP | IP | NS | NS | NS | medium: C5-authoritative-scope, H1-api-form-rbac, H7-report-fidelity, H10-no-desktop-comparison |
| `RP_BAL_ZOOM` | report | `conceptual-report-engine` (medium) | /reports/account-balances | `web/apps/api/src/modules/reports/reportEngine.ts`, `web/apps/api/src/modules/reports/reports.ts` | — | P | IP | IP | IP | NS | NS | NS | medium: C5-authoritative-scope, H1-api-form-rbac, H7-report-fidelity, H10-no-desktop-comparison |
| `RP_BILL_PROFIT` | report | `generic-report-scaffold` (low) | /reports/report-layouts | `web/apps/api/src/modules/reports/reportEngine.ts`, `web/apps/api/src/modules/reports/reports.ts` | — | P | IP | IP | W | NS | NS | NS | medium: C5-authoritative-scope, H1-api-form-rbac, H7-report-fidelity, H10-no-desktop-comparison |
| `RP_CASH_BANK` | report | `conceptual-report-engine` (medium) | /reports/cash-book | `web/apps/api/src/modules/reports/reportEngine.ts`, `web/apps/api/src/modules/reports/reports.ts` | — | P | IP | IP | IP | NS | NS | NS | medium: C5-authoritative-scope, H1-api-form-rbac, H7-report-fidelity, H10-no-desktop-comparison |
| `RP_CONSI_APR` | report | `generic-report-scaffold` (low) | /reports/report-layouts | `web/apps/api/src/modules/reports/reportEngine.ts`, `web/apps/api/src/modules/reports/reports.ts` | — | P | IP | IP | W | NS | NS | NS | medium: C5-authoritative-scope, H1-api-form-rbac, H7-report-fidelity, H10-no-desktop-comparison |
| `RP_CUST` | report | `conceptual-report-engine` (medium) | /reports/customer-crm | `web/apps/api/src/modules/reports/reportEngine.ts`, `web/apps/api/src/modules/reports/reports.ts` | — | P | IP | IP | W | NS | NS | NS | medium: C5-authoritative-scope, H1-api-form-rbac, H7-report-fidelity, H10-no-desktop-comparison |
| `RP_CUST_CRM` | report | `conceptual-report-engine` (medium) | /reports/customer-crm | `web/apps/api/src/modules/reports/reportEngine.ts`, `web/apps/api/src/modules/reports/reports.ts` | — | P | IP | IP | W | NS | NS | NS | medium: C5-authoritative-scope, H1-api-form-rbac, H7-report-fidelity, H10-no-desktop-comparison |
| `RP_DAY_WORK` | report | `conceptual-report-engine` (medium) | /reports/day-book | `web/apps/api/src/modules/reports/reportEngine.ts`, `web/apps/api/src/modules/reports/reports.ts` | — | P | IP | IP | W | NS | NS | NS | medium: C5-authoritative-scope, H1-api-form-rbac, H7-report-fidelity, H10-no-desktop-comparison |
| `RP_DHRN_LOAN` | report | `conceptual-report-engine` (medium) | /reports/dhrn-outstanding | `web/apps/api/src/modules/reports/reportEngine.ts`, `web/apps/api/src/modules/reports/reports.ts` | — | P | IP | IP | IP | NS | NS | NS | medium: C5-authoritative-scope, H1-api-form-rbac, H7-report-fidelity, H10-no-desktop-comparison |
| `RP_DHRN_OS` | report | `conceptual-report-engine` (medium) | /reports/dhrn-outstanding | `web/apps/api/src/modules/reports/reportEngine.ts`, `web/apps/api/src/modules/reports/reports.ts` | — | P | IP | IP | IP | NS | NS | NS | medium: C5-authoritative-scope, H1-api-form-rbac, H7-report-fidelity, H10-no-desktop-comparison |
| `RP_EMP` | report | `conceptual-report-engine` (medium) | /reports/employee-sales | `web/apps/api/src/modules/reports/reportEngine.ts`, `web/apps/api/src/modules/reports/reports.ts` | — | P | IP | IP | IP | NS | NS | NS | medium: C5-authoritative-scope, H1-api-form-rbac, H7-report-fidelity, H10-no-desktop-comparison |
| `RP_GRAPH` | report | `conceptual-report-engine` (medium) | /reports/daily-sales, /reports/top-items | `web/apps/api/src/modules/reports/reportEngine.ts`, `web/apps/api/src/modules/reports/reports.ts` | — | P | IP | IP | W | NS | NS | NS | medium: C5-authoritative-scope, H1-api-form-rbac, H7-report-fidelity, H10-no-desktop-comparison |
| `RP_GST` | report | `conceptual-report-engine` (medium) | /reports/gstr1, /reports/gstr2, /reports/gstr3b | `web/apps/api/src/modules/reports/reportEngine.ts`, `web/apps/api/src/modules/reports/reports.ts` | — | P | IP | IP | W | NS | NS | NS | medium: C5-authoritative-scope, H1-api-form-rbac, H7-report-fidelity, H10-no-desktop-comparison |
| `RP_HUID` | report | `conceptual-report-engine` (medium) | /reports/tag-stock | `web/apps/api/src/modules/reports/reportEngine.ts`, `web/apps/api/src/modules/reports/reports.ts` | — | P | IP | IP | IP | NS | NS | NS | medium: C5-authoritative-scope, H1-api-form-rbac, H7-report-fidelity, H10-no-desktop-comparison |
| `RP_INOUT` | report | `conceptual-report-engine` (medium) | /reports/item-stock-ledger | `web/apps/api/src/modules/reports/reportEngine.ts`, `web/apps/api/src/modules/reports/reports.ts` | — | P | IP | IP | IP | NS | NS | NS | medium: C5-authoritative-scope, H1-api-form-rbac, H7-report-fidelity, H10-no-desktop-comparison |
| `RP_JDTR_ZOOM` | report | `conceptual-report-engine` (medium) | /reports/karigar-ledger | `web/apps/api/src/modules/reports/reportEngine.ts`, `web/apps/api/src/modules/reports/reports.ts` | — | P | IP | IP | W | NS | NS | NS | medium: C5-authoritative-scope, H1-api-form-rbac, H7-report-fidelity, H10-no-desktop-comparison |
| `RP_LC_INOUT` | report | `conceptual-report-engine` (medium) | /reports/stock-by-location | `web/apps/api/src/modules/reports/reportEngine.ts`, `web/apps/api/src/modules/reports/reports.ts` | — | P | IP | IP | W | NS | NS | NS | medium: C5-authoritative-scope, H1-api-form-rbac, H7-report-fidelity, H10-no-desktop-comparison |
| `RP_LC_SALE` | report | `conceptual-report-engine` (medium) | /reports/location-wise-sales | `web/apps/api/src/modules/reports/reportEngine.ts`, `web/apps/api/src/modules/reports/reports.ts` | — | P | IP | IP | W | NS | NS | NS | medium: C5-authoritative-scope, H1-api-form-rbac, H7-report-fidelity, H10-no-desktop-comparison |
| `RP_LEDR` | report | `conceptual-report-engine` (medium) | /reports/account-ledger | `web/apps/api/src/modules/reports/reportEngine.ts`, `web/apps/api/src/modules/reports/reports.ts` | — | P | IP | IP | IP | NS | NS | NS | medium: C5-authoritative-scope, H1-api-form-rbac, H7-report-fidelity, H10-no-desktop-comparison |
| `RP_MFG` | report | `generic-report-scaffold` (low) | /reports/report-layouts | `web/apps/api/src/modules/reports/reportEngine.ts`, `web/apps/api/src/modules/reports/reports.ts` | — | P | IP | IP | W | NS | NS | NS | medium: C5-authoritative-scope, H1-api-form-rbac, H7-report-fidelity, H10-no-desktop-comparison |
| `RP_MFG_LEDR` | report | `conceptual-report-engine` (medium) | /reports/karigar-ledger | `web/apps/api/src/modules/reports/reportEngine.ts`, `web/apps/api/src/modules/reports/reports.ts` | — | P | IP | IP | W | NS | NS | NS | medium: C5-authoritative-scope, H1-api-form-rbac, H7-report-fidelity, H10-no-desktop-comparison |
| `RP_MFG_ZOOM` | report | `generic-report-scaffold` (low) | /reports/report-layouts | `web/apps/api/src/modules/reports/reportEngine.ts`, `web/apps/api/src/modules/reports/reports.ts` | — | P | IP | IP | W | NS | NS | NS | medium: C5-authoritative-scope, H1-api-form-rbac, H7-report-fidelity, H10-no-desktop-comparison |
| `RP_MOVEMENT` | report | `conceptual-report-engine` (medium) | /reports/item-stock-ledger | `web/apps/api/src/modules/reports/reportEngine.ts`, `web/apps/api/src/modules/reports/reports.ts` | — | P | IP | IP | W | NS | NS | NS | medium: C5-authoritative-scope, H1-api-form-rbac, H7-report-fidelity, H10-no-desktop-comparison |
| `RP_ORDER` | report | `generic-report-scaffold` (low) | /reports/report-layouts | `web/apps/api/src/modules/reports/reportEngine.ts`, `web/apps/api/src/modules/reports/reports.ts` | — | P | IP | IP | W | NS | NS | NS | medium: C5-authoritative-scope, H1-api-form-rbac, H7-report-fidelity, H10-no-desktop-comparison |
| `RP_ORD_TRACK` | report | `generic-report-scaffold` (low) | /reports/report-layouts | `web/apps/api/src/modules/reports/reportEngine.ts`, `web/apps/api/src/modules/reports/reports.ts` | — | P | IP | IP | W | NS | NS | NS | medium: C5-authoritative-scope, H1-api-form-rbac, H7-report-fidelity, H10-no-desktop-comparison |
| `RP_OS` | report | `conceptual-report-engine` (medium) | /reports/outstanding, /reports/bill-outstanding | `web/apps/api/src/modules/reports/reportEngine.ts`, `web/apps/api/src/modules/reports/reports.ts` | — | P | IP | IP | IP | NS | NS | NS | medium: C5-authoritative-scope, H1-api-form-rbac, H7-report-fidelity, H10-no-desktop-comparison |
| `RP_OTH_DETL` | report | `generic-report-scaffold` (low) | /reports/report-layouts | `web/apps/api/src/modules/reports/reportEngine.ts`, `web/apps/api/src/modules/reports/reports.ts` | — | P | IP | IP | W | NS | NS | NS | medium: C5-authoritative-scope, H1-api-form-rbac, H7-report-fidelity, H10-no-desktop-comparison |
| `RP_PHY_STOCK` | report | `conceptual-report-engine` (medium) | /txn/physical-stock | `web/apps/api/src/modules/reports/reportEngine.ts`, `web/apps/api/src/modules/reports/reports.ts` | — | P | IP | IP | IP | NS | NS | NS | medium: C5-authoritative-scope, H1-api-form-rbac, H7-report-fidelity, H10-no-desktop-comparison |
| `RP_REMINDER` | report | `conceptual-report-engine` (medium) | /utilities/reminders | `web/apps/api/src/modules/reports/reportEngine.ts`, `web/apps/api/src/modules/reports/reports.ts` | — | P | IP | IP | IP | NS | NS | NS | medium: C5-authoritative-scope, H1-api-form-rbac, H7-report-fidelity, H10-no-desktop-comparison |
| `RP_ROJMEL` | report | `conceptual-report-engine` (medium) | /reports/day-book | `web/apps/api/src/modules/reports/reportEngine.ts`, `web/apps/api/src/modules/reports/reports.ts` | — | P | IP | IP | IP | NS | NS | NS | medium: C5-authoritative-scope, H1-api-form-rbac, H7-report-fidelity, H10-no-desktop-comparison |
| `RP_SLPR_ZOOM` | report | `conceptual-report-engine` (medium) | /reports/sales-register, /reports/purchase-register | `web/apps/api/src/modules/reports/reportEngine.ts`, `web/apps/api/src/modules/reports/reports.ts` | — | P | IP | IP | W | NS | NS | NS | medium: C5-authoritative-scope, H1-api-form-rbac, H7-report-fidelity, H10-no-desktop-comparison |
| `RP_STK_LEVEL` | report | `conceptual-report-engine` (medium) | /reports/item-group-stock | `web/apps/api/src/modules/reports/reportEngine.ts`, `web/apps/api/src/modules/reports/reports.ts` | — | P | IP | IP | W | NS | NS | NS | medium: C5-authoritative-scope, H1-api-form-rbac, H7-report-fidelity, H10-no-desktop-comparison |
| `RP_STK_MOVE` | report | `conceptual-report-engine` (medium) | /reports/item-stock-ledger | `web/apps/api/src/modules/reports/reportEngine.ts`, `web/apps/api/src/modules/reports/reports.ts` | — | P | IP | IP | W | NS | NS | NS | medium: C5-authoritative-scope, H1-api-form-rbac, H7-report-fidelity, H10-no-desktop-comparison |
| `RP_STOCK` | report | `conceptual-report-engine` (medium) | /reports/stock-valuation | `web/apps/api/src/modules/reports/reportEngine.ts`, `web/apps/api/src/modules/reports/reports.ts` | — | P | IP | IP | IP | NS | NS | NS | medium: C5-authoritative-scope, H1-api-form-rbac, H7-report-fidelity, H10-no-desktop-comparison |
| `RP_STOCK_FINE` | report | `conceptual-report-engine` (medium) | /reports/stock-valuation | `web/apps/api/src/modules/reports/reportEngine.ts`, `web/apps/api/src/modules/reports/reports.ts` | — | P | IP | IP | W | NS | NS | NS | medium: C5-authoritative-scope, H1-api-form-rbac, H7-report-fidelity, H10-no-desktop-comparison |
| `RP_STOCK_VALUE` | report | `conceptual-report-engine` (medium) | /reports/stock-valuation | `web/apps/api/src/modules/reports/reportEngine.ts`, `web/apps/api/src/modules/reports/reports.ts` | — | P | IP | IP | W | NS | NS | NS | medium: C5-authoritative-scope, H1-api-form-rbac, H7-report-fidelity, H10-no-desktop-comparison |
| `RP_TAG` | report | `conceptual-report-engine` (medium) | /reports/tag-stock | `web/apps/api/src/modules/reports/reportEngine.ts`, `web/apps/api/src/modules/reports/reports.ts` | — | P | IP | IP | IP | NS | NS | NS | medium: C5-authoritative-scope, H1-api-form-rbac, H7-report-fidelity, H10-no-desktop-comparison |
| `RP_TAG_ESTMATE` | report | `conceptual-report-engine` (medium) | /reports/report-layouts | `web/apps/api/src/modules/reports/reportEngine.ts`, `web/apps/api/src/modules/reports/reports.ts` | — | P | IP | IP | IP | NS | NS | NS | medium: C5-authoritative-scope, H1-api-form-rbac, H7-report-fidelity, H10-no-desktop-comparison |
| `RP_TAG_IMAGE` | report | `conceptual-report-engine` (medium) | /reports/report-layouts | `web/apps/api/src/modules/reports/reportEngine.ts`, `web/apps/api/src/modules/reports/reports.ts` | — | P | IP | IP | W | NS | NS | NS | medium: C5-authoritative-scope, H1-api-form-rbac, H7-report-fidelity, H10-no-desktop-comparison |
| `RP_TAX` | report | `conceptual-report-engine` (medium) | /reports/hsn-summary, /reports/gst-input-register | `web/apps/api/src/modules/reports/reportEngine.ts`, `web/apps/api/src/modules/reports/reports.ts` | — | P | IP | IP | W | NS | NS | NS | medium: C5-authoritative-scope, H1-api-form-rbac, H7-report-fidelity, H10-no-desktop-comparison |
| `RP_TOUR_ZOOM` | report | `generic-report-scaffold` (low) | /reports/report-layouts | `web/apps/api/src/modules/reports/reportEngine.ts`, `web/apps/api/src/modules/reports/reports.ts` | — | P | IP | IP | W | NS | NS | NS | medium: C5-authoritative-scope, H1-api-form-rbac, H7-report-fidelity, H10-no-desktop-comparison |
| `RP_TRADING` | report | `generic-report-scaffold` (low) | /reports/report-layouts | `web/apps/api/src/modules/reports/reportEngine.ts`, `web/apps/api/src/modules/reports/reports.ts` | — | P | IP | IP | W | NS | NS | NS | medium: C5-authoritative-scope, H1-api-form-rbac, H7-report-fidelity, H10-no-desktop-comparison |
| `RP_USER` | report | `generic-report-scaffold` (low) | /reports/report-layouts | `web/apps/api/src/modules/reports/reportEngine.ts`, `web/apps/api/src/modules/reports/reports.ts` | — | P | IP | IP | IP | NS | NS | NS | medium: C5-authoritative-scope, H1-api-form-rbac, H7-report-fidelity, H10-no-desktop-comparison |
| `TR_AC_OPBL` | transaction | `dedicated-current-surface` (high) | /txn/ac-opbl, /masters/opening-balance | `web/apps/api/src/modules/finance/acOpening.ts`, `web/apps/api/src/modules/masters/openingBalance.ts` | `web/apps/api/test/accounting.test.ts` | P | IP | IP | IP | IP | NS | NS | critical: C5-authoritative-scope, H1-api-form-rbac, C3-numbering-concurrency, H2-period-lock-reversal |
| `TR_APR_ISU` | transaction | `variant-shared` (high) | /txn/tour, /txn/tour-return, /txn/sales-order | `web/apps/api/src/modules/sales/salesOrder.ts`, `web/apps/api/src/modules/tour/tour.ts` | `web/apps/api/test/workflows.test.ts` | P | IP | IP | IP | IP | NS | NS | high: C5-authoritative-scope, H1-api-form-rbac, C3-numbering-concurrency, H2-period-lock-reversal |
| `TR_BILL_TO` | transaction | `dedicated-current-surface` (high) | /txn/bill-to-bill | `web/apps/api/src/modules/finance/billToBill.ts` | `web/apps/api/test/financeLifecycle.db.test.ts`, +1 | P | IP | IP | IP | IP | NS | NS | critical: C5-authoritative-scope, H1-api-form-rbac, C3-numbering-concurrency, H2-period-lock-reversal |
| `TR_BUL_BOOKING` | transaction | `dedicated-current-surface` (high) | /txn/bullion | `web/apps/api/src/modules/bullion/bullion.ts` | `web/apps/api/test/rateCut.test.ts` | P | IP | IP | IP | IP | NS | NS | high: C5-authoritative-scope, H1-api-form-rbac, C3-numbering-concurrency, H2-period-lock-reversal |
| `TR_BUL_SALE` | transaction | `variant-shared` (high) | /txn/bullion, /txn/rate-cut | `web/apps/api/src/modules/bullion/bullion.ts`, `web/apps/api/src/modules/sales/rateCut.ts` | `web/apps/api/test/rateCut.test.ts` | P | IP | IP | IP | IP | NS | NS | high: C5-authoritative-scope, H1-api-form-rbac, C3-numbering-concurrency, H2-period-lock-reversal |
| `TR_CARD_REC` | transaction | `variant-shared` (high) | /txn/receipt, /txn/payment, /txn/batch-receipt | `web/apps/api/src/modules/finance/finance.ts`, `web/apps/api/src/modules/finance/tender.ts` | `web/apps/api/test/documents.test.ts`, +1 | P | IP | IP | IP | IP | NS | NS | high: C5-authoritative-scope, H1-api-form-rbac, C3-numbering-concurrency, H2-period-lock-reversal |
| `TR_CASH` | transaction | `variant-shared` (high) | /txn/receipt, /txn/payment, /txn/batch-receipt | `web/apps/api/src/modules/finance/finance.ts`, `web/apps/api/src/modules/finance/tender.ts` | `web/apps/api/test/documents.test.ts`, +1 | P | IP | IP | IP | IP | NS | NS | critical: C5-authoritative-scope, H1-api-form-rbac, C3-numbering-concurrency, H2-period-lock-reversal |
| `TR_CONTRA` | transaction | `dedicated-current-surface` (high) | /txn/contra, /txn/journal | `web/apps/api/src/modules/finance/finance.ts`, `web/apps/api/src/modules/finance/journal.ts` | `web/apps/api/test/finance.test.ts`, +1 | P | IP | IP | IP | IP | NS | NS | critical: C5-authoritative-scope, H1-api-form-rbac, C3-numbering-concurrency, H2-period-lock-reversal |
| `TR_DHRN_INTREC` | transaction | `dedicated-current-surface` (high) | /txn/dhrn-interest | `web/apps/api/src/modules/dhrn/dhrn.ts` | `web/apps/api/test/dhrn.test.ts` | P | IP | IP | IP | IP | NS | NS | high: C5-authoritative-scope, H1-api-form-rbac, C3-numbering-concurrency, H2-period-lock-reversal |
| `TR_DHRN_ISU` | transaction | `dedicated-current-surface` (high) | /txn/dhrn-issue | `web/apps/api/src/modules/dhrn/dhrn.ts` | `web/apps/api/test/dhrn.test.ts` | P | IP | IP | IP | IP | NS | NS | high: C5-authoritative-scope, H1-api-form-rbac, C3-numbering-concurrency, H2-period-lock-reversal |
| `TR_DHRN_REC` | transaction | `dedicated-current-surface` (high) | /txn/dhrn-receipt | `web/apps/api/src/modules/dhrn/dhrn.ts`, `web/apps/api/src/modules/dhrn/dhrnReceipt.ts` | `web/apps/api/test/dhrn.test.ts` | P | IP | IP | IP | IP | NS | NS | high: C5-authoritative-scope, H1-api-form-rbac, C3-numbering-concurrency, H2-period-lock-reversal |
| `TR_EMP_JV` | transaction | `dedicated-current-surface` (high) | /txn/employee-jv | `web/apps/api/src/modules/finance/employeeJv.ts` | `web/apps/api/test/financeLifecycle.db.test.ts`, +1 | P | IP | IP | W | IP | NS | NS | high: C5-authoritative-scope, H1-api-form-rbac, C3-numbering-concurrency, H2-period-lock-reversal |
| `TR_FINE_SL_PR` | transaction | `dedicated-current-surface` (high) | /txn/fine-sale | `web/apps/api/src/modules/bullion/fineSalePurchase.ts` | `web/apps/api/test/rateCut.test.ts` | P | IP | IP | W | IP | NS | NS | high: C5-authoritative-scope, H1-api-form-rbac, C3-numbering-concurrency, H2-period-lock-reversal |
| `TR_FN_INOUT` | transaction | `dedicated-current-surface` (high) | /txn/fine-inout | `web/apps/api/src/modules/inout/fineInout.ts` | `web/apps/api/test/stock.test.ts` | P | IP | IP | IP | IP | NS | NS | high: C5-authoritative-scope, H1-api-form-rbac, C3-numbering-concurrency, H2-period-lock-reversal |
| `TR_GOLD_BOOK` | transaction | `dedicated-current-surface` (high) | /txn/gold-book | `web/apps/api/src/modules/finance/goldBook.ts` | `web/apps/api/test/goldBookLoctAmt.db.test.ts` | P | IP | IP | IP | IP | NS | NS | high: C5-authoritative-scope, H1-api-form-rbac, C3-numbering-concurrency, H2-period-lock-reversal |
| `TR_INOUT` | transaction | `variant-shared` (medium) | /txn/fine-inout | `web/apps/api/src/modules/inout/fineInout.ts` | `web/apps/api/test/stock.test.ts` | P | IP | IP | IP | IP | NS | NS | high: C5-authoritative-scope, H1-api-form-rbac, C3-numbering-concurrency, H2-period-lock-reversal |
| `TR_ITM_LOT` | transaction | `dedicated-current-surface` (high) | /txn/item-lot | `web/apps/api/src/modules/stock/stock.ts`, `web/apps/api/src/modules/stock/stockVoucherLifecycle.ts` | `web/apps/api/test/stock.test.ts`, +1 | P | IP | IP | IP | IP | NS | NS | high: C5-authoritative-scope, H1-api-form-rbac, C3-numbering-concurrency, H2-period-lock-reversal |
| `TR_ITM_OPBL` | transaction | `dedicated-current-surface` (high) | /txn/item-opening | `web/apps/api/src/modules/stock/stock.ts`, `web/apps/api/src/modules/stock/stockVoucherLifecycle.ts` | `web/apps/api/test/stock.test.ts`, +1 | P | IP | IP | W | IP | NS | NS | critical: C4-workflow-fine-policy, C5-authoritative-scope, H1-api-form-rbac, C3-numbering-concurrency |
| `TR_JDT_REC` | transaction | `variant-shared` (medium) | /txn/jobwork-issue, /txn/jobwork-receive | `web/apps/api/src/modules/manufacturing/karigar.ts`, `web/apps/api/src/modules/manufacturing/mfg.ts` | `web/apps/api/test/karigar.test.ts`, +1 | P | IP | IP | IP | IP | NS | NS | high: C5-authoritative-scope, H1-api-form-rbac, C3-numbering-concurrency, H2-period-lock-reversal |
| `TR_KR_ISU` | transaction | `dedicated-current-surface` (high) | /txn/karigar-issue | `web/apps/api/src/modules/manufacturing/karigar.ts` | `web/apps/api/test/karigar.test.ts`, +1 | P | IP | IP | IP | IP | NS | NS | critical: C4-workflow-fine-policy, C5-authoritative-scope, H1-api-form-rbac, C3-numbering-concurrency |
| `TR_LEDR_ADJ` | transaction | `dedicated-current-surface` (high) | /txn/ledger-adjust, /txn/fine-jv | `web/apps/api/src/modules/finance/fineJv.ts`, `web/apps/api/src/modules/finance/ledgerAdjust.ts` | `web/apps/api/test/financeLifecycle.db.test.ts`, +1 | P | IP | IP | W | IP | NS | NS | high: C5-authoritative-scope, H1-api-form-rbac, C3-numbering-concurrency, H2-period-lock-reversal |
| `TR_LOCT_AMT` | transaction | `dedicated-current-surface` (high) | /txn/location-amount | `web/apps/api/src/modules/finance/locationAmount.ts` | `web/apps/api/test/goldBookLoctAmt.db.test.ts` | P | IP | IP | IP | IP | NS | NS | high: C5-authoritative-scope, H1-api-form-rbac, C3-numbering-concurrency, H2-period-lock-reversal |
| `TR_MEMB_ADJ` | transaction | `variant-shared` (high) | /txn/membership, /txn/scheme, /reports/scheme-adjustments | `web/apps/api/src/modules/membership/membership.ts`, `web/apps/api/src/modules/membership/scheme.ts` | `web/apps/api/test/salesFamilyLifecycle.db.test.ts`, +1 | P | IP | IP | IP | IP | NS | NS | high: C5-authoritative-scope, H1-api-form-rbac, C3-numbering-concurrency, H2-period-lock-reversal |
| `TR_MEMB_ENT` | transaction | `dedicated-current-surface` (high) | /txn/membership, /txn/scheme | `web/apps/api/src/modules/membership/membership.ts`, `web/apps/api/src/modules/membership/scheme.ts` | `web/apps/api/test/salesFamilyLifecycle.db.test.ts`, +1 | P | IP | IP | IP | IP | NS | NS | high: C5-authoritative-scope, H1-api-form-rbac, C3-numbering-concurrency, H2-period-lock-reversal |
| `TR_MFG_GHAT_REC` | transaction | `variant-shared` (high) | /txn/mfg-receive | `web/apps/api/src/modules/manufacturing/mfg.ts` | `web/apps/api/test/karigar.test.ts`, +1 | P | IP | IP | IP | IP | NS | NS | high: C5-authoritative-scope, H1-api-form-rbac, C3-numbering-concurrency, H2-period-lock-reversal |
| `TR_MFG_ISU_REC` | transaction | `dedicated-current-surface` (high) | /txn/mfg-issue, /txn/mfg-receive | `web/apps/api/src/modules/manufacturing/mfg.ts` | `web/apps/api/test/karigar.test.ts`, +1 | P | IP | IP | IP | IP | NS | NS | critical: C5-authoritative-scope, H1-api-form-rbac, C3-numbering-concurrency, H2-period-lock-reversal |
| `TR_MFG_ITEM` | transaction | `dedicated-current-surface` (high) | /txn/mfg-issue, /txn/mfg-receive | `web/apps/api/src/modules/manufacturing/mfg.ts` | `web/apps/api/test/karigar.test.ts`, +1 | P | IP | IP | IP | IP | NS | NS | high: C5-authoritative-scope, H1-api-form-rbac, C3-numbering-concurrency, H2-period-lock-reversal |
| `TR_MFG_KR_ISU_REC` | transaction | `variant-shared` (high) | /txn/karigar-issue, /txn/karigar-receive, /txn/mfg-issue, /txn/mfg-receive | `web/apps/api/src/modules/manufacturing/karigar.ts`, `web/apps/api/src/modules/manufacturing/mfg.ts` | `web/apps/api/test/karigar.test.ts`, +1 | P | IP | IP | IP | IP | NS | NS | high: C4-workflow-fine-policy, C5-authoritative-scope, H1-api-form-rbac, C3-numbering-concurrency |
| `TR_MFG_ORD_ISU` | transaction | `dedicated-current-surface` (high) | /txn/mfg-order-issue | `web/apps/api/src/modules/manufacturing/mfg.ts` | `web/apps/api/test/karigar.test.ts`, +1 | P | IP | IP | IP | IP | NS | NS | high: C5-authoritative-scope, H1-api-form-rbac, C3-numbering-concurrency, H2-period-lock-reversal |
| `TR_MFG_ORD_REC` | transaction | `variant-shared` (high) | /txn/mfg-receive | `web/apps/api/src/modules/manufacturing/mfg.ts` | `web/apps/api/test/karigar.test.ts`, +1 | P | IP | IP | IP | IP | NS | NS | high: C5-authoritative-scope, H1-api-form-rbac, C3-numbering-concurrency, H2-period-lock-reversal |
| `TR_MFG_WITH_LOT` | transaction | `variant-shared` (high) | /txn/mfg-receive | `web/apps/api/src/modules/manufacturing/mfg.ts` | `web/apps/api/test/karigar.test.ts`, +1 | P | IP | IP | IP | IP | NS | NS | high: C5-authoritative-scope, H1-api-form-rbac, C3-numbering-concurrency, H2-period-lock-reversal |
| `TR_MLT_PRO` | transaction | `dedicated-current-surface` (high) | /txn/melting | `web/apps/api/src/modules/manufacturing/melting.ts`, `web/apps/api/src/modules/manufacturing/meltingParity.ts`, +1 | `web/apps/api/test/melting.test.ts`, +2 | P | P | IP | P | IP | NS | NS | high: C4-workflow-fine-policy, C5-authoritative-scope, H1-api-form-rbac, C3-numbering-concurrency |
| `TR_OTH_COMM` | transaction | `dedicated-current-surface` (high) | /txn/other-commission | `web/apps/api/src/modules/purchase/otherCommission.ts` | `web/apps/api/test/otherCommission.db.test.ts` | P | IP | IP | IP | IP | NS | NS | high: C5-authoritative-scope, H1-api-form-rbac, C3-numbering-concurrency, H2-period-lock-reversal |
| `TR_OTH_PURC` | transaction | `dedicated-current-surface` (high) | /txn/other-purchase | `web/apps/api/src/modules/purchase/purchase.ts` | `web/apps/api/test/purchase.test.ts` | P | IP | IP | IP | IP | NS | NS | high: C1-loose-stock, C2-server-derived-reversal, C4-workflow-fine-policy, C5-authoritative-scope |
| `TR_PHYSTK` | transaction | `dedicated-current-surface` (high) | /txn/physical-stock | `web/apps/api/src/modules/stock/physicalStock.ts`, `web/apps/api/src/modules/stock/stock.ts` | `web/apps/api/test/physicalStock.db.test.ts`, +1 | P | IP | IP | IP | IP | NS | NS | high: C5-authoritative-scope, H1-api-form-rbac, C3-numbering-concurrency, H2-period-lock-reversal |
| `TR_PR_SL_HEDG` | transaction | `conceptual-engine` (medium) | /txn/rate-cut | `web/apps/api/src/modules/bullion/fineSalePurchase.ts`, `web/apps/api/src/modules/sales/rateCut.ts` | `web/apps/api/test/rateCut.test.ts` | P | IP | IP | W | IP | NS | NS | high: C5-authoritative-scope, H1-api-form-rbac, C3-numbering-concurrency, H2-period-lock-reversal |
| `TR_PR_SL_UAE` | transaction | `waived-documented` (high) | — | — | — | P | IP | W | W | NS | NS | NS | high: C5-authoritative-scope, H1-api-form-rbac, C3-numbering-concurrency, H2-period-lock-reversal |
| `TR_PURC` | transaction | `dedicated-current-surface` (high) | /txn/purchase, /txn/purchase-return | `web/apps/api/src/modules/purchase/purchase.ts`, `web/apps/api/src/modules/purchase/purchaseBill.ts`, +1 | `web/apps/api/test/purchase.lifecycle.db.test.ts`, +2 | P | P | IP | IP | IP | NS | NS | critical: C1-loose-stock, C2-server-derived-reversal, C4-workflow-fine-policy, H3-tag-concurrency |
| `TR_PURC_HM` | transaction | `variant-shared` (high) | /txn/purchase-hm | `web/apps/api/src/modules/purchase/purchase.ts` | `web/apps/api/test/purchase.test.ts` | P | IP | IP | IP | IP | NS | NS | high: C1-loose-stock, C2-server-derived-reversal, C4-workflow-fine-policy, H3-tag-concurrency |
| `TR_REP_REC` | transaction | `dedicated-current-surface` (high) | /txn/repair-receipt, /txn/repair-karigar-issue, /txn/repair-karigar-receipt, /txn/repair-customer-issue | `web/apps/api/src/modules/repair/repairImage.ts`, `web/apps/api/src/modules/repair/repairReceipt.ts` | `web/apps/api/test/repairImage.test.ts`, +2 | P | IP | IP | W | IP | NS | NS | high: C5-authoritative-scope, H1-api-form-rbac, C3-numbering-concurrency, H2-period-lock-reversal |
| `TR_SALE` | transaction | `dedicated-current-surface` (high) | /txn/sales | `web/apps/api/src/modules/sales/invoice.ts`, `web/apps/api/src/modules/sales/sales.ts` | `web/apps/api/test/sales.lifecycle.db.test.ts`, +2 | P | P | IP | IP | IP | NS | NS | critical: C1-loose-stock, C2-server-derived-reversal, C4-workflow-fine-policy, H3-tag-concurrency |
| `TR_SALE_HM` | transaction | `variant-shared` (high) | /txn/hallmark-sale | `web/apps/api/src/modules/sales/sales.ts` | `web/apps/api/test/sales.test.ts` | P | IP | IP | IP | IP | NS | NS | high: C1-loose-stock, C2-server-derived-reversal, C4-workflow-fine-policy, C5-authoritative-scope |
| `TR_SALE_LBR` | transaction | `dedicated-current-surface` (high) | /txn/labour-sale | `web/apps/api/src/modules/sales/labourInvoice.ts` | `web/apps/api/test/documents.test.ts` | P | IP | IP | IP | IP | NS | NS | high: C5-authoritative-scope, H1-api-form-rbac, C3-numbering-concurrency, H2-period-lock-reversal |
| `TR_SALE_ORD` | transaction | `dedicated-current-surface` (high) | /txn/sales-order, /txn/order-cancel | `web/apps/api/src/modules/sales/salesOrder.ts` | `web/apps/api/test/workflows.test.ts` | P | IP | IP | IP | IP | NS | NS | high: C5-authoritative-scope, H1-api-form-rbac, C3-numbering-concurrency, H2-period-lock-reversal |
| `TR_SALE_RTN` | transaction | `dedicated-current-surface` (high) | /txn/sale-return | `web/apps/api/src/modules/sales/salesReturn.ts` | `web/apps/api/test/salesFamilyLifecycle.db.test.ts`, +1 | P | IP | IP | IP | IP | NS | NS | critical: C1-loose-stock, C2-server-derived-reversal, C4-workflow-fine-policy, H3-tag-concurrency |
| `TR_SALE_RTN_UAE` | transaction | `waived-documented` (high) | — | — | — | P | IP | W | W | NS | NS | NS | high: C5-authoritative-scope, H1-api-form-rbac, C3-numbering-concurrency, H2-period-lock-reversal |
| `TR_SL_EBILL` | transaction | `variant-shared` (high) | /utilities/e-invoice | `web/apps/api/src/modules/einvoice/einvoice.ts` | `web/apps/api/test/einvoice.test.ts`, +1 | P | IP | IP | IP | IP | NS | NS | high: C5-authoritative-scope, H1-api-form-rbac, C3-numbering-concurrency, H2-period-lock-reversal |
| `TR_SL_ORD_ADJ` | transaction | `dedicated-current-surface` (high) | /txn/sales-order, /txn/order-cancel | `web/apps/api/src/modules/sales/salesOrder.ts` | `web/apps/api/test/workflows.test.ts` | P | IP | IP | IP | IP | NS | NS | high: C5-authoritative-scope, H1-api-form-rbac, C3-numbering-concurrency, H2-period-lock-reversal |
| `TR_SL_PR_ITEM` | transaction | `conceptual-engine` (medium) | /txn/rate-cut | `web/apps/api/src/modules/bullion/fineSalePurchase.ts`, `web/apps/api/src/modules/sales/rateCut.ts` | `web/apps/api/test/rateCut.test.ts` | P | IP | IP | IP | IP | NS | NS | high: C5-authoritative-scope, H1-api-form-rbac, C3-numbering-concurrency, H2-period-lock-reversal |
| `TR_TAG_CAN` | transaction | `dedicated-current-surface` (high) | /txn/tag-cancel | `web/apps/api/src/modules/stock/tagOps.ts` | `web/apps/api/test/stock.test.ts` | P | IP | IP | IP | IP | NS | NS | critical: H3-tag-concurrency, C5-authoritative-scope, H1-api-form-rbac, C3-numbering-concurrency |
| `TR_TAG_OPBL` | transaction | `dedicated-current-surface` (high) | /txn/tag-opening | `web/apps/api/src/modules/stock/stock.ts`, `web/apps/api/src/modules/stock/stockVoucherLifecycle.ts` | `web/apps/api/test/stock.test.ts`, +1 | P | IP | IP | IP | IP | NS | NS | critical: H3-tag-concurrency, C5-authoritative-scope, H1-api-form-rbac, C3-numbering-concurrency |
| `TR_TAG_SPLIT` | transaction | `dedicated-current-surface` (high) | /txn/tag-split | `web/apps/api/src/modules/stock/tagSplit.ts` | `web/apps/api/test/stock.test.ts` | P | IP | IP | IP | IP | NS | NS | critical: H3-tag-concurrency, C5-authoritative-scope, H1-api-form-rbac, C3-numbering-concurrency |
| `TR_TAG_WT_DIFF` | transaction | `dedicated-current-surface` (high) | /txn/tag-weight-diff | `web/apps/api/src/modules/stock/tagOps.ts` | `web/apps/api/test/stock.test.ts` | P | IP | IP | IP | IP | NS | NS | high: H3-tag-concurrency, C5-authoritative-scope, H1-api-form-rbac, C3-numbering-concurrency |
| `TR_TOUR` | transaction | `dedicated-current-surface` (high) | /txn/tour | `web/apps/api/src/modules/tour/tour.ts` | `web/apps/api/test/workflows.test.ts` | P | IP | IP | IP | IP | NS | NS | high: C5-authoritative-scope, H1-api-form-rbac, C3-numbering-concurrency, H2-period-lock-reversal |
| `TR_TOUR_ORD` | transaction | `variant-shared` (high) | /txn/tour, /txn/tour-return, /txn/sales-order | `web/apps/api/src/modules/sales/salesOrder.ts`, `web/apps/api/src/modules/tour/tour.ts` | `web/apps/api/test/workflows.test.ts` | P | IP | IP | IP | IP | NS | NS | high: C5-authoritative-scope, H1-api-form-rbac, C3-numbering-concurrency, H2-period-lock-reversal |
| `TR_TOUR_SALE` | transaction | `variant-shared` (high) | /txn/tour, /txn/tour-return, /txn/sales-order | `web/apps/api/src/modules/sales/salesOrder.ts`, `web/apps/api/src/modules/tour/tour.ts` | `web/apps/api/test/workflows.test.ts` | P | IP | IP | IP | IP | NS | NS | high: C5-authoritative-scope, H1-api-form-rbac, C3-numbering-concurrency, H2-period-lock-reversal |
| `TR_UPI_REC` | transaction | `variant-shared` (high) | /txn/receipt, /txn/payment, /txn/batch-receipt | `web/apps/api/src/modules/finance/finance.ts`, `web/apps/api/src/modules/finance/tender.ts` | `web/apps/api/test/documents.test.ts`, +1 | P | IP | IP | W | IP | NS | NS | high: C5-authoritative-scope, H1-api-form-rbac, C3-numbering-concurrency, H2-period-lock-reversal |
| `TR_VP` | transaction | `dedicated-current-surface` (high) | /txn/vp-parcel | `web/apps/api/src/modules/sales/vpParcel.ts` | `web/apps/api/test/vpParcel.db.test.ts` | P | IP | IP | IP | IP | NS | NS | high: C5-authoritative-scope, H1-api-form-rbac, C3-numbering-concurrency, H2-period-lock-reversal |
| `TR_VP_ADJ` | transaction | `dedicated-current-surface` (high) | /txn/vp-adjustment | `web/apps/api/src/modules/finance/vpAdjustment.ts` | `web/apps/api/test/vpLifecycle.db.test.ts` | P | IP | IP | IP | IP | NS | NS | high: C5-authoritative-scope, H1-api-form-rbac, C3-numbering-concurrency, H2-period-lock-reversal |
| `TR_WH_SALE` | transaction | `variant-shared` (high) | /txn/wholesale-sale | `web/apps/api/src/modules/sales/rateCut.ts`, `web/apps/api/src/modules/sales/sales.ts` | `web/apps/api/test/rateCut.test.ts`, +1 | P | IP | IP | IP | IP | NS | NS | high: C1-loose-stock, C2-server-derived-reversal, C4-workflow-fine-policy, C5-authoritative-scope |
| `TR_WH_SALE_RTN` | transaction | `dedicated-current-surface` (high) | /txn/wholesale-sale-return | `web/apps/api/src/modules/sales/wholesaleSaleReturn.ts` | `web/apps/api/test/wholesaleSaleReturn.db.test.ts` | P | IP | IP | IP | IP | NS | NS | high: C1-loose-stock, C2-server-derived-reversal, C4-workflow-fine-policy, C5-authoritative-scope |
| `TagOthDetail` | other | `conceptual-engine` (high) | /txn/stock, /reports/tag-stock | `web/apps/api/src/modules/stock/stock.ts` | — | P | IP | IP | EG | NS | NS | NS | low |
| `Translator` | other | `waived-documented` (high) | — | — | — | P | IP | W | W | NS | NS | NS | low |
| `UT_AI_TRFR` | utility | `variant-shared` (high) | /txn/tag-transfer, /txn/counter-transfer | `web/apps/api/src/modules/stock/stock.ts` | `web/apps/api/test/stock.test.ts` | P | IP | IP | NS | IP | NS | NS | medium: C5-authoritative-scope, H1-api-form-rbac |
| `UT_BANK` | utility | `variant-shared` (high) | /txn/bank-recon | `web/apps/api/src/modules/finance/bankRecon.ts` | `web/apps/api/test/finance.test.ts`, +1 | P | IP | IP | W | IP | NS | NS | medium: C5-authoritative-scope, H1-api-form-rbac |
| `UT_BKP` | utility | `dedicated-current-surface` (high) | /backup | `web/apps/api/src/modules/ops/backup.ts` | — | P | IP | IP | W | NS | NS | NS | high: OPS-backup-restore, C5-authoritative-scope, H1-api-form-rbac |
| `UT_CUST_ENTRY` | utility | `variant-shared` (medium) | /masters/party | `web/apps/api/src/modules/masters/party.ts` | — | P | IP | IP | W | NS | NS | NS | medium: C5-authoritative-scope, H1-api-form-rbac |
| `UT_EXPORT` | utility | `variant-shared` (medium) | /backup, /masters/accounts | `web/apps/api/src/modules/masters/master.service.ts`, `web/apps/api/src/modules/ops/backup.ts` | — | P | IP | IP | IP | NS | NS | NS | medium: C5-authoritative-scope, H1-api-form-rbac |
| `UT_E_INVOICE` | utility | `dedicated-current-surface` (high) | /utilities/e-invoice | `web/apps/api/src/modules/einvoice/einvoice.ts` | `web/apps/api/test/einvoice.test.ts`, +1 | P | IP | IP | W | IP | NS | NS | medium: C5-authoritative-scope, H1-api-form-rbac |
| `UT_HDD` | utility | `dedicated-current-surface` (high) | /utilities/hdd-registry | `web/apps/api/src/modules/utilities/hddRegistry.ts` | `web/apps/api/test/utilities.db.test.ts` | P | IP | IP | IP | IP | NS | NS | medium: C5-authoritative-scope, H1-api-form-rbac |
| `UT_IMPORT` | utility | `variant-shared` (medium) | /backup, /masters/accounts | `web/apps/api/src/modules/masters/master.service.ts`, `web/apps/api/src/modules/ops/backup.ts` | — | P | IP | IP | IP | NS | NS | NS | medium: C5-authoritative-scope, H1-api-form-rbac |
| `UT_PWD_UPDATE` | utility | `conceptual-engine` (high) | /login | `web/apps/api/src/modules/auth/password.ts` | `web/apps/api/test/auth.password.test.ts` | P | IP | IP | W | IP | NS | NS | high: H1-api-form-rbac, H6-password-session, C5-authoritative-scope |
| `UT_REMINDER` | utility | `variant-shared` (high) | /utilities/reminders, /utilities/reminder-entry, /txn/reminders | `web/apps/api/src/modules/finance/reminders.ts`, `web/apps/api/src/modules/utilities/reminderEntry.ts` | — | P | IP | IP | W | NS | NS | NS | medium: C5-authoritative-scope, H1-api-form-rbac |
| `UT_REPORT` | utility | `generic-report-scaffold` (medium) | /reports/report-layouts | `web/apps/api/src/modules/reports/reportEngine.ts` | `web/apps/api/test/reportEngine.test.ts` | P | IP | IP | W | IP | NS | NS | medium: C5-authoritative-scope, H1-api-form-rbac |
| `UT_SETTING` | utility | `variant-shared` (high) | /settings, /admin/users | `web/apps/api/src/modules/rbac/formRights.ts`, `web/apps/api/src/modules/settings/settings.ts` | `web/apps/api/test/rbac.policy.test.ts` | P | IP | IP | W | IP | NS | NS | high: H1-api-form-rbac, H6-password-session, C5-authoritative-scope |
| `UT_SETTING_MAIN` | utility | `variant-shared` (high) | /settings, /admin/users | `web/apps/api/src/modules/rbac/formRights.ts`, `web/apps/api/src/modules/settings/settings.ts` | `web/apps/api/test/rbac.policy.test.ts` | P | IP | IP | W | IP | NS | NS | high: H1-api-form-rbac, H6-password-session, C5-authoritative-scope |
| `UT_SET_ADMIN` | utility | `variant-shared` (high) | /settings, /admin/users | `web/apps/api/src/modules/rbac/formRights.ts`, `web/apps/api/src/modules/settings/settings.ts` | `web/apps/api/test/rbac.policy.test.ts` | P | IP | IP | W | IP | NS | NS | high: H1-api-form-rbac, H6-password-session, C5-authoritative-scope |
| `UT_SMS` | utility | `variant-shared` (high) | /integrations | `web/apps/api/src/modules/integrations/messaging.ts` | `web/apps/api/test/integrations.test.ts`, +1 | P | IP | IP | IP | IP | NS | NS | medium: C5-authoritative-scope, H1-api-form-rbac |
| `UT_TAG_PRINT` | utility | `dedicated-current-surface` (high) | /txn/tag-print | `web/apps/api/src/modules/integrations/barcode.ts`, `web/apps/api/src/modules/stock/tagPrint.ts` | `web/apps/api/test/barcode.test.ts` | P | IP | IP | IP | IP | NS | NS | medium: C5-authoritative-scope, H1-api-form-rbac |
| `UT_USER_REQUEST` | utility | `dedicated-current-surface` (high) | /utilities/user-request | `web/apps/api/src/modules/utilities/userRequest.ts` | `web/apps/api/test/utilities.db.test.ts` | P | IP | IP | IP | IP | NS | NS | medium: C5-authoritative-scope, H1-api-form-rbac |
| `UT_VCH_RE_NUMBR` | utility | `dedicated-current-surface` (high) | /utilities/voucher-renumber | `web/apps/api/src/modules/utilities/voucherRenumber.ts` | — | P | IP | IP | W | NS | NS | NS | medium: C5-authoritative-scope, H1-api-form-rbac |
| `UT_WAPP_WITH_API` | utility | `variant-shared` (high) | /integrations | `web/apps/api/src/modules/integrations/messaging.ts` | `web/apps/api/test/integrations.test.ts`, +1 | P | IP | IP | IP | IP | NS | NS | medium: C5-authoritative-scope, H1-api-form-rbac |
| `UT_WEB_CAM` | utility | `waived-documented` (high) | — | — | — | P | IP | W | W | NS | NS | NS | medium: C5-authoritative-scope, H1-api-form-rbac |
| `UT_WHATSAPP` | utility | `variant-shared` (high) | /integrations | `web/apps/api/src/modules/integrations/messaging.ts` | `web/apps/api/test/integrations.test.ts`, +1 | P | IP | IP | IP | IP | NS | NS | medium: C5-authoritative-scope, H1-api-form-rbac |
| `UT_WINDOW` | utility | `dedicated-current-surface` (high) | /utilities/window-tiles | `web/apps/api/src/modules/utilities/windowTiles.ts` | `web/apps/api/test/utilities.db.test.ts` | P | IP | IP | W | IP | NS | NS | medium: C5-authoritative-scope, H1-api-form-rbac |

## Data/schema findings

All 146 desktop tables exist in migration SQL and 146 are represented by Prisma mappings. Raw-migration-only drift: **none**. The web-only `audit_log` is now migration-owned, FORCE-RLS protected and append-only for `app_user`.

### Critical/high table rows

| Table | Prisma | Usage | RLS E/F/P | Tests | Blockers |
|---|---|---|---|---|---|
| `AC_DATA` | AC_DATA | runtime-referenced | 1/1/1 | 25 refs | POSTING-money-metal-balance |
| `AC_GROUP` | AC_GROUP | runtime-referenced | 1/1/1 | 2 refs | — |
| `AC_MAST` | AC_MAST | runtime-referenced | 1/1/1 | 23 refs | — |
| `ADD_MAST` | ADD_MAST | runtime-referenced | 1/1/1 | 1 refs | — |
| `AD_ADJ` | AD_ADJ | runtime-referenced | 1/1/1 | 3 refs | — |
| `AD_DATA` | AD_DATA | runtime-referenced | 1/1/1 | 1 refs | — |
| `AD_MAST` | AD_MAST | runtime-referenced | 1/1/1 | 2 refs | — |
| `AD_MEMB` | AD_MEMB | runtime-referenced | 1/1/1 | 2 refs | — |
| `AD_OS` | AD_OS | runtime-referenced | 1/1/1 | 1 refs | — |
| `APR_DATA` | APR_DATA | runtime-referenced | 1/1/1 | 2 refs | — |
| `APR_DETL` | APR_DETL | runtime-referenced | 1/1/1 | 1 refs | — |
| `APR_IDTL` | APR_IDTL | runtime-referenced | 1/1/1 | 1 refs | — |
| `BAL_GR` | BAL_GR | runtime-referenced | 1/1/1 | 0 refs | — |
| `BANK_RECONCILE` | BANK_RECONCILE | runtime-referenced | 1/1/1 | 0 refs | — |
| `BAR_CAN_DATA` | BAR_CAN_DATA | runtime-referenced | 1/1/1 | 2 refs | — |
| `BAR_CAN_DETL` | BAR_CAN_DETL | runtime-referenced | 1/1/1 | 2 refs | — |
| `BAR_CAN_IDTL` | BAR_CAN_IDTL | runtime-referenced | 1/1/1 | 0 refs | — |
| `BAR_DATA` | BAR_DATA | runtime-referenced | 1/1/1 | 3 refs | — |
| `BAR_DETL` | BAR_DETL | runtime-referenced | 1/1/1 | 10 refs | C2-server-derived-reversal, H3-tag-concurrency |
| `BAR_IDTL` | BAR_IDTL | runtime-referenced | 1/1/1 | 5 refs | C2-server-derived-reversal, H3-tag-concurrency |
| `BILL_OS_DATA` | BILL_OS_DATA | runtime-referenced | 1/1/1 | 5 refs | POSTING-bill-allocation |
| `BOOK_DATA` | BOOK_DATA | runtime-referenced | 1/1/1 | 24 refs | — |
| `BOOK_DETL` | BOOK_DETL | runtime-referenced | 1/1/1 | 13 refs | — |
| `BOOK_IDTL` | BOOK_IDTL | runtime-referenced | 1/1/1 | 0 refs | — |
| `BUL_DATA` | BUL_DATA | runtime-referenced | 1/1/1 | 0 refs | — |
| `CARD_DATA` | CARD_DATA | runtime-referenced | 1/1/1 | 2 refs | — |
| `CASH_DATA` | CASH_DATA | runtime-referenced | 1/1/1 | 2 refs | — |
| `COL_MAST` | COL_MAST | runtime-referenced | 1/1/1 | 0 refs | — |
| `CONTRA_DATA` | CONTRA_DATA | runtime-referenced | 1/1/1 | 1 refs | — |
| `CONV_MAST` | CONV_MAST | runtime-referenced | 1/1/1 | 0 refs | — |
| `COUNTRY_MAST` | COUNTRY_MAST | runtime-referenced | 1/1/1 | 0 refs | — |
| `CO_MAST` | CO_MAST | runtime-referenced | 1/1/1 | 6 refs | C5-authoritative-scope |
| `CO_SET` | CO_SET | runtime-referenced | 1/1/1 | 22 refs | C4-workflow-fine-policy, H2-period-lock-reversal, ROUNDING-policy |
| `CO_SET_NEW` | CO_SET_NEW | runtime-referenced | 1/1/1 | 4 refs | — |
| `CRNT_DATA` | CRNT_DATA | runtime-referenced | 1/1/1 | 1 refs | — |
| `CUT_DATA` | CUT_DATA | runtime-referenced | 1/1/1 | 4 refs | — |
| `CUT_DETL` | CUT_DETL | runtime-referenced | 1/1/1 | 1 refs | — |
| `CUT_STK_DETL` | CUT_STK_DETL | runtime-referenced | 1/1/1 | 0 refs | — |
| `DELETE_DATA` | DELETE_DATA | runtime-referenced | 1/1/1 | 15 refs | — |
| `DESIGN_DETL` | DESIGN_DETL | runtime-referenced | 1/1/1 | 1 refs | — |
| `DESIGN_IDTL` | DESIGN_IDTL | runtime-referenced | 1/1/1 | 0 refs | — |
| `DESIGN_MAST` | DESIGN_MAST | runtime-referenced | 1/1/1 | 1 refs | — |
| `DHRN_DATA` | DHRN_DATA | runtime-referenced | 1/1/1 | 2 refs | — |
| `DHRN_ISU_DATA` | DHRN_ISU_DATA | runtime-referenced | 1/1/1 | 3 refs | — |
| `DHRN_ISU_DETL` | DHRN_ISU_DETL | runtime-referenced | 1/1/1 | 2 refs | — |
| `DHRN_REC_DATA` | DHRN_REC_DATA | runtime-referenced | 1/1/1 | 4 refs | — |
| `DHRN_REC_DETL` | DHRN_REC_DETL | runtime-referenced | 1/1/1 | 1 refs | — |
| `DM_DATA` | DM_DATA | runtime-referenced | 1/1/1 | 4 refs | — |
| `DM_KR_DATA` | DM_KR_DATA | runtime-referenced | 1/1/1 | 1 refs | — |
| `DM_MAST` | DM_MAST | runtime-referenced | 1/1/1 | 2 refs | — |
| `DM_SIZE` | DM_SIZE | runtime-referenced | 1/1/1 | 4 refs | — |
| `EMP_DATA` | EMP_DATA | runtime-referenced | 1/1/1 | 2 refs | — |
| `EMP_MAST` | EMP_MAST | runtime-referenced | 1/1/1 | 2 refs | — |
| `E_DATA` | E_DATA | runtime-referenced | 1/1/1 | 30 refs | — |
| `E_MAST` | E_MAST | runtime-referenced | 1/1/1 | 3 refs | — |
| `FINE_DATA` | FINE_DATA | runtime-referenced | 1/1/1 | 2 refs | — |
| `GROUP_MAST` | GROUP_MAST | runtime-referenced | 1/1/1 | 10 refs | — |
| `HDD_MAST` | HDD_MAST | runtime-referenced | 1/1/1 | 1 refs | — |
| `IMAGE_DATA` | IMAGE_DATA | runtime-referenced | 1/1/1 | 0 refs | — |
| `INOUT_DATA` | INOUT_DATA | runtime-referenced | 1/1/1 | 1 refs | — |
| `INOUT_DETL` | INOUT_DETL | runtime-referenced | 1/1/1 | 0 refs | — |
| `INOUT_IDTL` | INOUT_IDTL | runtime-referenced | 1/1/1 | 0 refs | — |
| `ITEM_MAST` | ITEM_MAST | runtime-referenced | 1/1/1 | 19 refs | — |
| `ITM_CITY` | ITM_CITY | runtime-referenced | 1/1/1 | 0 refs | — |
| `ITM_LOT_DETL` | ITM_LOT_DETL | runtime-referenced | 1/1/1 | 2 refs | — |
| `ITM_OPBL` | ITM_OPBL | runtime-referenced | 1/1/1 | 2 refs | — |
| `ITM_WT_MAST` | ITM_WT_MAST | runtime-referenced | 1/1/1 | 0 refs | — |
| `KR_DATA` | KR_DATA | runtime-referenced | 1/1/1 | 2 refs | — |
| `KR_DETL` | KR_DETL | runtime-referenced | 1/1/1 | 1 refs | — |
| `KR_IDTL` | KR_IDTL | runtime-referenced | 1/1/1 | 1 refs | — |
| `LBR_DATA` | LBR_DATA | runtime-referenced | 1/1/1 | 2 refs | — |
| `LBR_ISU_DETL` | LBR_ISU_DETL | runtime-referenced | 1/1/1 | 2 refs | — |
| `LBR_ISU_IDTL` | LBR_ISU_IDTL | runtime-referenced | 1/1/1 | 1 refs | — |
| `LBR_MAST` | LBR_MAST | runtime-referenced | 1/1/1 | 0 refs | — |
| `LBR_REC_DETL` | LBR_REC_DETL | runtime-referenced | 1/1/1 | 1 refs | — |
| `LDR_ADJ_DATA` | LDR_ADJ_DATA | runtime-referenced | 1/1/1 | 2 refs | — |
| `LEDR_AC_DATA` | LEDR_AC_DATA | runtime-referenced | 1/1/1 | 1 refs | — |
| `LOCT_AMT` | LOCT_AMT | runtime-referenced | 1/1/1 | 1 refs | — |
| `LOCT_MAST` | LOCT_MAST | runtime-referenced | 1/1/1 | 3 refs | C5-authoritative-scope |
| `LOGIN_MAST` | LOGIN_MAST | runtime-referenced | 1/1/1 | 2 refs | — |
| `LOT_DETL` | LOT_DETL | runtime-referenced | 1/1/1 | 5 refs | — |
| `MAIN_STOCK` | MAIN_STOCK | runtime-referenced | 1/1/1 | 15 refs | C1-loose-stock, C2-server-derived-reversal, H3-tag-concurrency |
| `MFG_DATA` | MFG_DATA | runtime-referenced | 1/1/1 | 2 refs | — |
| `MFG_DETL` | MFG_DETL | runtime-referenced | 1/1/1 | 3 refs | — |
| `MFG_IDTL` | MFG_IDTL | runtime-referenced | 1/1/1 | 1 refs | — |
| `MFG_ISU_REC` | MFG_ISU_REC | runtime-referenced | 1/1/1 | 2 refs | — |
| `MFG_MAST` | MFG_MAST | runtime-referenced | 1/1/1 | 2 refs | — |
| `MLT_DATA` | MLT_DATA | runtime-referenced | 1/1/1 | 1 refs | — |
| `MLT_DETL` | MLT_DETL | runtime-referenced | 1/1/1 | 1 refs | — |
| `MODEL_MAST` | MODEL_MAST | runtime-referenced | 1/1/1 | 1 refs | — |
| `MSG_MAST` | MSG_MAST | runtime-referenced | 1/1/1 | 0 refs | — |
| `OP_DATA` | OP_DATA | runtime-referenced | 1/1/1 | 0 refs | — |
| `OP_DETL` | OP_DETL | runtime-referenced | 1/1/1 | 0 refs | — |
| `OP_LDR` | OP_LDR | runtime-referenced | 1/1/1 | 0 refs | — |
| `PAY_DATA` | PAY_DATA | runtime-referenced | 1/1/1 | 1 refs | — |
| `PAY_DETL` | PAY_DETL | runtime-referenced | 1/1/1 | 1 refs | — |
| `POINT_DATA` | POINT_DATA | runtime-referenced | 1/1/1 | 1 refs | — |
| `POINT_MAST` | POINT_MAST | runtime-referenced | 1/1/1 | 0 refs | — |
| `POINT_MEMB` | POINT_MEMB | runtime-referenced | 1/1/1 | 0 refs | — |
| `PRINT_MAST` | PRINT_MAST | runtime-referenced | 1/1/1 | 0 refs | — |
| `PRODUCT_MAST` | PRODUCT_MAST | runtime-referenced | 1/1/1 | 3 refs | — |
| `PR_DATA` | PR_DATA | runtime-referenced | 1/1/1 | 5 refs | C1-loose-stock, C2-server-derived-reversal, C4-workflow-fine-policy |
| `PR_DETL` | PR_DETL | runtime-referenced | 1/1/1 | 7 refs | C1-loose-stock, C2-server-derived-reversal, C4-workflow-fine-policy |
| `PR_IDTL` | PR_IDTL | runtime-referenced | 1/1/1 | 3 refs | — |
| `RATE_CUT_DATA` | RATE_CUT_DATA | runtime-referenced | 1/1/1 | 4 refs | — |
| `RATE_CUT_ISU` | RATE_CUT_ISU | runtime-referenced | 1/1/1 | 2 refs | — |
| `RATE_CUT_ISU_REC` | RATE_CUT_ISU_REC | runtime-referenced | 1/1/1 | 1 refs | — |
| `RATE_CUT_REC` | RATE_CUT_REC | runtime-referenced | 1/1/1 | 1 refs | — |
| `RATE_MAST` | RATE_MAST | runtime-referenced | 1/1/1 | 0 refs | — |
| `REM_DATA` | REM_DATA | runtime-referenced | 1/1/1 | 0 refs | — |
| `REPORT_DATA` | REPORT_DATA | runtime-referenced | 1/1/1 | 1 refs | — |
| `REP_DATA` | REP_DATA | runtime-referenced | 1/1/1 | 3 refs | — |
| `REP_DETL` | REP_DETL | runtime-referenced | 1/1/1 | 2 refs | — |
| `ROJMEL_BAL` | ROJMEL_BAL | runtime-referenced | 1/1/1 | 0 refs | — |
| `ROJ_MEL_DATA` | ROJ_MEL_DATA | runtime-referenced | 1/1/1 | 9 refs | — |
| `SL_DATA` | SL_DATA | runtime-referenced | 1/1/1 | 10 refs | C1-loose-stock, C2-server-derived-reversal, C4-workflow-fine-policy |
| `SL_DETL` | SL_DETL | runtime-referenced | 1/1/1 | 7 refs | C1-loose-stock, C2-server-derived-reversal, C4-workflow-fine-policy |
| `SL_DETL_RTN` | SL_DETL_RTN | runtime-referenced | 1/1/1 | 1 refs | — |
| `SL_IDTL` | SL_IDTL | runtime-referenced | 1/1/1 | 6 refs | — |
| `SL_ORD_ADJ` | SL_ORD_ADJ | runtime-referenced | 1/1/1 | 3 refs | — |
| `SL_ORD_DATA` | SL_ORD_DATA | runtime-referenced | 1/1/1 | 1 refs | — |
| `SL_ORD_DETL` | SL_ORD_DETL | runtime-referenced | 1/1/1 | 3 refs | — |
| `SL_ORD_IDTL` | SL_ORD_IDTL | runtime-referenced | 1/1/1 | 1 refs | — |
| `SL_PR_DETL` | SL_PR_DETL | runtime-referenced | 1/1/1 | 4 refs | — |
| `SRNO_MAST` | SRNO_MAST | runtime-referenced | 1/1/1 | 5 refs | C3-numbering-concurrency |
| `STATE_MAST` | STATE_MAST | runtime-referenced | 1/1/1 | 0 refs | — |
| `TABLE_MAST` | TABLE_MAST | runtime-referenced | 1/1/1 | 2 refs | — |
| `TAG_DATA` | TAG_DATA | runtime-referenced | 1/1/1 | 0 refs | — |
| `TAG_PRINT_DATA` | TAG_PRINT_DATA | runtime-referenced | 1/1/1 | 2 refs | — |
| `TAG_SET` | TAG_SET | runtime-referenced | 1/1/1 | 0 refs | — |
| `TAG_STOCK_PRINT` | TAG_STOCK_PRINT | runtime-referenced | 1/1/1 | 2 refs | — |
| `TAG_SUM_DATA` | TAG_SUM_DATA | runtime-referenced | 1/1/1 | 0 refs | — |
| `TAX_DATA` | TAX_DATA | runtime-referenced | 1/1/1 | 8 refs | POSTING-gst-register |
| `TAX_MAST` | TAX_MAST | runtime-referenced | 1/1/1 | 10 refs | — |
| `TEMP_ADD` | TEMP_ADD | runtime-referenced | 1/1/1 | 1 refs | — |
| `TEMP_AD_DATA` | TEMP_AD_DATA | runtime-referenced | 1/1/1 | 1 refs | — |
| `TEMP_BOOK_DATA` | TEMP_BOOK_DATA | runtime-referenced | 1/1/1 | 17 refs | — |
| `TOUCH_MAST` | TOUCH_MAST | runtime-referenced | 1/1/1 | 0 refs | — |
| `UPI_DATA` | UPI_DATA | runtime-referenced | 1/1/1 | 3 refs | — |
| `USER_DATA` | USER_DATA | runtime-referenced | 1/1/1 | 1 refs | — |
| `USER_MAST` | USER_MAST | runtime-referenced | 1/1/1 | 0 refs | — |
| `USER_REQUEST` | USER_REQUEST | runtime-referenced | 1/1/1 | 1 refs | — |
| `VP_ADJ_DATA` | VP_ADJ_DATA | runtime-referenced | 1/1/1 | 1 refs | — |
| `WEB_DATA` | WEB_DATA | runtime-referenced | 1/1/1 | 0 refs | — |
| `WEIGHT_MAST` | WEIGHT_MAST | runtime-referenced | 1/1/1 | 0 refs | — |
| `YEAR_MAST` | YEAR_MAST | runtime-referenced | 1/1/1 | 12 refs | C5-authoritative-scope |

The JSON/CSV contain all 146 table rows, referencing forms, schema/model/migration/RLS/source/test evidence and per-table acceptance checks.

## Report findings

- Supplied: 255 RPTs; layout status: {'absent': 20, 'complete': 253, 'partial': 1, 'unavailable': 1}.
- Missing obligations: 20 — `aprbillimg.rpt`, `balzoom.rpt`, `bankadj.rpt`, `billwiseos.rpt`, `empdaysumm.rpt`, `empsumm.rpt`, `franchisebill.rpt`, `jdterskt.rpt`, `jdtvch.rpt`, `krisureport.rpt`, `krrecreport.rpt`, `loctamtvch.rpt`, `mainacsumm.rpt`, `mltingisu.rpt`, `purcquot.rpt`, `reminderschm.rpt`, `remindervch.rpt`, `salesrtna4print.rpt`, `vpparcelbill.rpt`, `whquotation.rpt`.
- Current binder classification across supplied reports: {'KR_DATA': 8, 'PR_DATA': 22, 'SL_DATA': 32, 'SL_DATA_DEFAULT_UNSAFE': 193}. `SL_DATA_DEFAULT_UNSAFE` means the current binder finds no SL/PR/KR family and silently defaults to sales.
- Web `SalesQuotation.spec.json` is still an unusable error stub even though the project catalog contains the recovered partial layout.
- Every report remains G5/G6 `NS`; no desktop PDF/image or physical-printer certification exists.

### Extraction/web exceptions

| Report | Desktop layout | Web usable/indexed | Binder | G1 | G3 | G4 | Blockers |
|---|---|---|---|---:|---:|---:|---|
| `AcCrList` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `AcDrList` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `AcFineGold` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `AcFineSilver` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `AcGroupRpt` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `AcLastVisit` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `AcLedger` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `AcLedgerSelected` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `AcOsArea` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `AcOsWithAdd` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `AcPurcWhRpt` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `AcSaleWhRpt` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `AcSumm` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `AcSummLdr` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `AcWithWt` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `AcWithWtGold` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `AcWithWtSumm` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `AngdiyaIsuRpt` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `AprInOut` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `AprPan` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `AprPartyWise` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `BalanceHz` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `BarPrint10` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `BarPrint13` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `BillRecVch` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `BulCustAdjust` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `BulCustBooking` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `BullBookBill` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `CashBankBill` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `CashBankBillAc` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `ChqPrint010` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `ChqPrint011` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `ChqPrint012` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `ChqPrint013` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `ChqPrint014` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `ChqPrint135` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `CntrTagStkRpt` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `CntrTagSumRpt` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `Company` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `ContraBill` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `CounterSale` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `CounterTrfr` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `CustRepIsu` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `CustRepRec` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `CustRepRecBill` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `DharnDue` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `DhiranIssuRec` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `DhiranitemRpt` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `DhiranReg` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `DhiranStock` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `DhrnIntRec` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `DhrnIssue` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `DhrnIssueImg` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `DhrnKhataVahi` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `DhrnKhataVahiSumm` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `DhrnOsLetter` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `DhrnReceivedSumm` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `DiamondSf` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `FineJvBill` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `FineSalesGstBill` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `Form12` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `Form8` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `GhatTagPrnt` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `GoldInterest` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `GroupStkRpt` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `Gstr_1` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `Gstr_2` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `Gstr_3` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `HedgingFixVch` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `InTax_PurcRpt` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `ItemInOut` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `ItemInOutSumm` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `ItemInword` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `ItemLedger` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `ItemOutword` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `ItemStkRpt` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `ItmLotPrint` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `ItmStkBalance` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `ItmStkWithGrid` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `ItmStkWithOthWt` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `JadtarInOut` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `JadtarIssue` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `JadtarRec` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `JdtProcessRec` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `JmUdAmt` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `JmUdFine` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `JmUdFineHz` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `JmUdFineHzSumm` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `JmUdFineHzSummVch` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `JmUdFineSl` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `JmUdFineSlHz` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `JmUdFineSlSum` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `KrRepRec` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `LabourBill` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `LabourBillGst` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `LabourWorkVch` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `LbrWorkRpt` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `LedrAdjVch` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `LedrInOut` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `LedrInOutWh` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `LoanStock` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `LoanWisePacket` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `MembBonus` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `MembCommRpt` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `MembDailyRecRpt` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `MembGoldRpt` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `MembOpenNew` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `MembQr` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `MembRpt` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `MembRptAdd` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `MembSumm` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `MembVch` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `MfgGhatRec` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `MfgLedger` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `MfgMinoIsuRec` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `MfgVch` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `OrdAdvAdj` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `OrdAdvRpt` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `OrdDesignSumm` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `OrdDetlPanding` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `OrdDetlRpt` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `OrderBill` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `OrderCancelVch` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `OrderVch` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `OrdVchImg` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `OthCommVch` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `OthExpUae` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `OthItmLoose` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `OthItmStud` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `OutTax_SaleRpt` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `PartyInterest` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `PartyIntSumm` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `PaymentVch` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `ProdStkRpt` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `ProfitLossHz` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `PrTaxRpt` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `QrPrint10` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `RateCutBill` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `RateCutItmBill` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `RateRpt` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `ReminderAll` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `ReparingCustIsu` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `ReparingKrRec` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `ReparingRec` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `RojMel` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `RojMelCash` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `RojMelCrDr` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `RojMelEstmat` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `RojMelGr` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `RojMelItem` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `RojMelJmaUdhar` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `SafeStkSumm` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `SalarySlip` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `SalesQuotation` | partial | True/True | `SL_DATA` | IP | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, WAIVER-partial-salesquotation-extraction |
| `SalesWithOrder` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `SchmAdj` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `SchmMonthRpt` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `SchmPassBook` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `SchmRecVch` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `SlTaxRpt` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `StkInOutVch` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `StngIsuRec` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `TableStkGwtRpt` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `TagCanBill` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `TagHuIdRpt` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `TagItmSumm` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `TagReNumberVch` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `TagSplitVch` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `TagStkIdtlRpt` | unavailable | False/False | `SL_DATA_DEFAULT_UNSAFE` | W | W | W | H7-report-fidelity, H10-no-desktop-comparison, WAIVER-crystal-runtime-required, H7-unknown-report-defaults-to-sales |
| `TagStkItemSumRpt` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `TagStkRpt` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `TagStkRptDmSum` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `TagStkSummRpt` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `TagWtChangeVch` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `TagWtChangSplit` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `TaxInOutRpt` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `TaxSummUae` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `TempAdd2` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `TempAdd3` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `TempPhone` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `TourOrdImg` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `TourOrdVch` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `TRialBalHz` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `UserDtlRpt` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `VpAdjustBill` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `VpIsuRpt` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `WhHuidPrint` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `WhSalesBill` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `WhSalesBillSumm` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `WhSalesEmp` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `WhSalesImage` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `WhSalesIsuRec` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `WhSalesRtnBill` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `WhSalesSumm` | complete | True/True | `SL_DATA_DEFAULT_UNSAFE` | P | IP | IP | H7-report-fidelity, H10-no-desktop-comparison, H7-unknown-report-defaults-to-sales |
| `aprbillimg` | absent | False/False | `SL_DATA_DEFAULT_UNSAFE` | EG | B | NS | H7-report-fidelity, H10-no-desktop-comparison, EVIDENCE-absent-rpt, H7-unknown-report-defaults-to-sales |
| `balzoom` | absent | False/False | `SL_DATA_DEFAULT_UNSAFE` | EG | B | NS | H7-report-fidelity, H10-no-desktop-comparison, EVIDENCE-absent-rpt, H7-unknown-report-defaults-to-sales |
| `bankadj` | absent | False/False | `SL_DATA_DEFAULT_UNSAFE` | EG | B | NS | H7-report-fidelity, H10-no-desktop-comparison, EVIDENCE-absent-rpt, H7-unknown-report-defaults-to-sales |
| `billwiseos` | absent | False/False | `SL_DATA_DEFAULT_UNSAFE` | EG | B | NS | H7-report-fidelity, H10-no-desktop-comparison, EVIDENCE-absent-rpt, H7-unknown-report-defaults-to-sales |
| `empdaysumm` | absent | False/False | `SL_DATA_DEFAULT_UNSAFE` | EG | B | NS | H7-report-fidelity, H10-no-desktop-comparison, EVIDENCE-absent-rpt, H7-unknown-report-defaults-to-sales |
| `empsumm` | absent | False/False | `SL_DATA_DEFAULT_UNSAFE` | EG | B | NS | H7-report-fidelity, H10-no-desktop-comparison, EVIDENCE-absent-rpt, H7-unknown-report-defaults-to-sales |
| `franchisebill` | absent | False/False | `SL_DATA_DEFAULT_UNSAFE` | EG | B | NS | H7-report-fidelity, H10-no-desktop-comparison, EVIDENCE-absent-rpt, H7-unknown-report-defaults-to-sales |
| `jdterskt` | absent | False/False | `SL_DATA_DEFAULT_UNSAFE` | EG | B | NS | H7-report-fidelity, H10-no-desktop-comparison, EVIDENCE-absent-rpt, H7-unknown-report-defaults-to-sales |
| `jdtvch` | absent | False/False | `SL_DATA_DEFAULT_UNSAFE` | EG | B | NS | H7-report-fidelity, H10-no-desktop-comparison, EVIDENCE-absent-rpt, H7-unknown-report-defaults-to-sales |
| `krisureport` | absent | False/False | `SL_DATA_DEFAULT_UNSAFE` | EG | B | NS | H7-report-fidelity, H10-no-desktop-comparison, EVIDENCE-absent-rpt, H7-unknown-report-defaults-to-sales |
| `krrecreport` | absent | False/False | `SL_DATA_DEFAULT_UNSAFE` | EG | B | NS | H7-report-fidelity, H10-no-desktop-comparison, EVIDENCE-absent-rpt, H7-unknown-report-defaults-to-sales |
| `loctamtvch` | absent | False/False | `SL_DATA_DEFAULT_UNSAFE` | EG | B | NS | H7-report-fidelity, H10-no-desktop-comparison, EVIDENCE-absent-rpt, H7-unknown-report-defaults-to-sales |
| `mainacsumm` | absent | False/False | `SL_DATA_DEFAULT_UNSAFE` | EG | B | NS | H7-report-fidelity, H10-no-desktop-comparison, EVIDENCE-absent-rpt, H7-unknown-report-defaults-to-sales |
| `mltingisu` | absent | False/False | `SL_DATA_DEFAULT_UNSAFE` | EG | B | NS | H7-report-fidelity, H10-no-desktop-comparison, EVIDENCE-absent-rpt, H7-unknown-report-defaults-to-sales |
| `purcquot` | absent | False/False | `SL_DATA_DEFAULT_UNSAFE` | EG | B | NS | H7-report-fidelity, H10-no-desktop-comparison, EVIDENCE-absent-rpt, H7-unknown-report-defaults-to-sales |
| `reminderschm` | absent | False/False | `SL_DATA_DEFAULT_UNSAFE` | EG | B | NS | H7-report-fidelity, H10-no-desktop-comparison, EVIDENCE-absent-rpt, H7-unknown-report-defaults-to-sales |
| `remindervch` | absent | False/False | `SL_DATA_DEFAULT_UNSAFE` | EG | B | NS | H7-report-fidelity, H10-no-desktop-comparison, EVIDENCE-absent-rpt, H7-unknown-report-defaults-to-sales |
| `salesrtna4print` | absent | False/False | `SL_DATA_DEFAULT_UNSAFE` | EG | B | NS | H7-report-fidelity, H10-no-desktop-comparison, EVIDENCE-absent-rpt, H7-unknown-report-defaults-to-sales |
| `vpparcelbill` | absent | False/False | `SL_DATA_DEFAULT_UNSAFE` | EG | B | NS | H7-report-fidelity, H10-no-desktop-comparison, EVIDENCE-absent-rpt, H7-unknown-report-defaults-to-sales |
| `whquotation` | absent | False/False | `SL_DATA_DEFAULT_UNSAFE` | EG | B | NS | H7-report-fidelity, H10-no-desktop-comparison, EVIDENCE-absent-rpt, H7-unknown-report-defaults-to-sales |

## Settings and keyboard

- Settings: all 57 extracted keys are present in the editable API registry; only 57 have an exact-key source reference outside that registry. Registry/storage presence is not behavioral parity.
- Keyboard: F1/Enter/Escape and Ctrl/Cmd+Enter plus grid movement/removal have shared handlers and selected Chromium workflow coverage; F2/F3/F4/F5/F7/F8/F9/F11/F12 remain absent or form-incomplete.

| Shortcut | Desktop files | Web files | G3 | G4 |
|---|---:|---:|---:|---:|
| `F1` | 0 | 1 | IP | IP |
| `F2` | 0 | 1 | IP | IP |
| `F3` | 0 | 1 | IP | IP |
| `F4` | 0 | 1 | IP | IP |
| `F5` | 0 | 1 | IP | IP |
| `F7` | 0 | 1 | IP | IP |
| `F8` | 0 | 1 | IP | IP |
| `F9` | 0 | 1 | IP | IP |
| `F11` | 0 | 1 | IP | IP |
| `F12` | 0 | 1 | IP | IP |
| `Enter` | 1 | 6 | IP | IP |
| `Escape` | 1 | 2 | IP | IP |
| `Ctrl+Enter` | 0 | 2 | IP | IP |

## G5 comparison harness

- Runner: `web/apps/api/integration/g5-compare.mjs`; latest artifact: `project-memory/parity/g5/latest.json`; current mode: **DEGRADED**.
- Qualifying retained zero-diff form artifacts: **0**. Skipped, failed, incomplete, or report-only artifacts never advance a form gate.
- External inputs still required: A reachable desktop SQL Server runtime containing sanitized representative shop data. Read-only desktop source credentials in CUTOVER_SOURCE_* environment variables. A matching migrated PostgreSQL target tenant in DATABASE_URL and G5_TARGET_TENANT. G5_FORMS JSON identifying matching desktop and web vouchers for each form.

## G6 production-certification status

- Ledger: `project-memory/parity/G6-STATUS.md`; production-certified units: **0/720**; certified: **false**.
- Local evidence does not clear blocked deployment, DR, hardware/site UAT, live-service, or signer requirements.
- `load-local` — **evidence_produced**; artifact: `project-memory/parity/LOAD-PROFILE.md`; external input: none for this local artifact
- `load-production` — **blocked**; artifact: `project-memory/parity/LOAD-PROFILE.md`; external input: Production-like multi-instance deployment/network; representative sanitized shop data volume; approved traffic mix and latency/error/capacity targets; database sizing/pool budget.
- `security-local` — **evidence_produced**; artifact: `project-memory/parity/SECURITY-REVIEW.md`; external input: none for this local artifact
- `security-live` — **blocked**; artifact: `project-memory/parity/SECURITY-REVIEW.md`; external input: Deployed HTTPS origin/proxy/WAF; trusted-proxy and distributed rate-limit design; CSP/HSTS/Permissions-Policy decisions; test roles; authorized independent assessor and window.
- `observability-local` — **evidence_produced**; artifact: `web/apps/api/src/modules/ops/metrics.ts`; external input: none for this local artifact
- `observability-live` — **blocked**; artifact: `web/apps/api/src/modules/ops/metrics.ts`; external input: Monitoring/log platform and credentials; alert destinations/escalation roster; retention/SLO policy; deployed endpoints; named on-call participants and exercise window.
- `backup-restore-local` — **evidence_produced**; artifact: `project-memory/parity/DR-RUNBOOK.md`; external input: none for this local artifact
- `dr-production` — **blocked**; artifact: `project-memory/parity/DR-RUNBOOK.md`; external input: Backup store/vault and credentials; encryption/KMS and retention policy; secondary topology; production-sized encrypted snapshot; approved RPO/RTO; incident commander and recovery approver.
- `device-protocol` — **evidence_produced**; artifact: `project-memory/parity/DEVICE-BRIDGE.md`; external input: none for this local artifact
- `device-uat` — **blocked**; artifact: `project-memory/parity/UAT-PLAN.md`; external input: Actual manufacturer/model/firmware/driver inventory; scale calibration/capacity/precision and USB/serial identity/settings; printer media/DPI; scanner mode; camera/browser; physical devices/workstation.
- `site-uat` — **blocked**; artifact: `project-memory/parity/UAT-PLAN.md`; external input: Named customer site; approved UAT tenant/build/data/control totals; module operators; supported workstations/browser; execution window.
- `integrations-live` — **blocked**; artifact: `project-memory/parity/G6-STATUS.md`; external input: e-Invoice GSP sandbox credentials/GSTIN; WhatsApp test number/token; SMS account/key/sender; live-rate account/key; approved recipients and reconciliation owner.
- `business-signoff` — **blocked**; artifact: `project-memory/parity/G6-STATUS.md`; external input: Completed passing G5/G6 evidence and named authorized operations, finance, inventory/manufacturing, and security/deployment signers with dated signatures and authority.

## Required evidence to advance gates

1. **G2:** source-linked behavior contracts per form/report/setting, including branches, table ownership, delete/reversal, keyboard/focus and exact formula policy.
2. **G3:** close numbering, loose stock, server reversal, workflow fine-policy, posting/reversal integrity and report/PDF blockers before claiming complete implementation.
3. **G4:** CI must invoke real posting/reversal/numbering/tenant functions against migrated PostgreSQL and add authorization, cross-tenant, concurrency, failure, browser, migration and restore suites.
4. **G5:** run scripted workflows on desktop and web with the same sanitized fixture; require row/aggregate reconciliation plus screenshot/PDF/keyboard comparison artifacts.
5. **G6:** pass security/load/observability/readiness, backup/restore/DR, device/service/site UAT and signed business acceptance.

## External evidence still required

- Compatible Windows Crystal runtime/reader for exact TagStkIdtlRpt and improved SalesQuotation extraction.
- Another complete installation for the 20 referenced-but-absent RPT files.
- Safe project PostgreSQL with seeded migration/RLS fixtures for integration/concurrency/isolation tests.
- Desktop runtime and representative sanitized shop data for row, workflow, keyboard and PDF comparisons.
- Shop printers/scales/scanners/webcams and service sandboxes/credentials for device/integration certification.
- Business-owner decisions for unresolved Dhiran, VP/GOLD_BOOK, rounding, book and report variants.

## How to regenerate

```bash
python3 project-memory/parity/build_parity_matrix.py
```

The generator asserts the frozen universes (204 forms, 146 tables, 255 supplied reports, 20 absent referenced reports, 57 settings, 369 declared API routes) and refuses silent count drift. It also self-checks measurement integrity: every declared business route must be claimed by a desktop unit row (or be one of the declared infrastructure routes), every claimed route must exist, and the transaction voucher-lifecycle split (full create/read/edit/delete vs create-without-edit vs no write path) is recomputed from the route universe rather than asserted by hand.
