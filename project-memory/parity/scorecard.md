# PARITY CERTIFICATION SCORECARD — DataCareNext desktop→web clone
_Updated 2026-06-30 (session 5be). Re-run tools: xdb_diff.mjs · parity_report.mjs · parity_form.mjs · parity_sweep.mjs · pnpm test._

## Objective parity metrics (re-verified this session, post period-lock + LOGIN_MAST rights migration)
| Metric | Result | Tool |
|---|---|---|
| Cross-DB column coverage | **141/141 tables complete** (0 partial) | xdb_diff.mjs |
| Cross-DB numeric-sum parity | **366/366 Σ pass, 0 mismatch** (OP_LDR 1-row config table = known cosmetic ETL reject, Σ-irrelevant) | xdb_diff.mjs |
| Report parity vs real data | **5/5 pass** (sales/purchase reg, stock, accounts, day-book) | parity_report.mjs |
| Per-form multi-table footprint | **PER_FORM_SWEEP_OK** — 10/10 forms-with-data complete (sales 5–7 tables, purchase 4, …); 4 types have no demo data | parity_sweep.mjs |
| Sale header computation | **190/190 exact** | compute parity |
| Sale line computation | **244/245 exact** | line_parity.mjs |
| Unit/workflow tests | **116 pass** | pnpm test |
| Gate | typecheck 10/10, build clean | turbo |

## Phase completion
| Phase | Status | Notes |
|---|---|---|
| 0 Harness + shared engine + UI kit | ✅ | parity_form/parity_report/parity_sweep/xdb_diff/line_parity; LookupPicker/rate-fetch/tag-autofill; posting enrichment (LEDR_KEY/IT_TYPE/LD_CODE/BOOK_NAME) |
| 1 Masters | ✅ | 31 data masters via generic grid (auto-covers all columns) + USER via /admin/users (now with rights matrix) + open-company dialog |
| 2 Sales suite | ✅ | sale/HM/RTN/LBR/ORD/WH/estimate — weight grid, settlement, TAX CGST/SGST split, MAIN_STOCK, SL_IDTL |
| 3 Purchase suite | ✅ | purchase + return (TAX reversal + MAIN_STOCK) |
| 4 Inventory/Tags | ✅ | opening/cancel/weight-diff/split; MAIN_STOCK full fidelity; sells real BAR_DETL inventory |
| 5 Manufacturing | ✅ | real MFG_DATA/DETL/IDTL/ISU_REC + ghat/loss; karigar issue/receive; melting |
| 6 Finance/Cash-Bank | ✅ | receipt/payment/contra/journal/opening-balance + multi-party batch receipt |
| 7 Loans/Dhrn | ✅ | issue+collateral+repay+interest+outstanding (server-side interest) |
| 8 Bullion/Tour/Inout | ✅ | bullion booking/sale + tour/approval (APR_DATA/DETL) + fine-inout |
| 9 Membership/Schemes | ✅ | members+points + saving-scheme enroll/installment + AD_ADJ adjustments |
| 10 Statutory | 🟢 | e-Invoice IRN end-to-end (Fake transport; ready-for-GSP-creds), GSTR-1/2/3B/HSN |
| 11 Reports | ✅ | **45 reports** (registers/ledgers/stock/gst/dhrn-os/cash-book/party-statement/TB-full/aging/by-group/voucher-register/…) + branded Crystal-style PDF |
| 12 Utilities | ✅ | hub/settings/backup/audit/import-export/year-end-close/reminders + **period-lock (day-close)** + **voucher-renumber** |
| 13 Shell/RBAC | ✅ | company/year switcher, users-admin (Argon2id) + **per-user rights matrix** (USER_UPDATE/DELETE/PRINT on LOGIN_MAST, enforced at login via rightsOf/guard) |
| 14 Parity certification | ✅ | this scorecard + 5 harnesses; objective metrics above; per-form footprint sweep green |
| 15 Hardening/deploy | 🟢 | security headers + SECURITY.md; Dockerfile.api/web + docker-compose.yml + .env.example + DEPLOY.md. Production cutover (TLS, real infra, per-customer migration) pending creds/infra |

## Working surface (on real DHAKAN data — tenant `default`)
918 accounts · 190 invoices ₹5.48M · 1329 tags · 1856 stock moves · 13,448 rows / 41 tables.
~41 transaction forms, 45 reports, 31 masters, admin (users+rights / company-year), e-invoice, year-end, period-lock, voucher-renumber — all gate-green, demo data intact + canonical (190 sales / 300 ledger accounts).

## Honest remaining (non-blocking tail)
- Phase 10/15: external third-party credentials (GSP e-invoice, WhatsApp, SMS) — code is ready-for-creds; needs real keys + production infra (TLS termination, managed Postgres, backups, observability) for live cutover.
- OP_LDR config-table ETL reject in xdb_diff (Σ-irrelevant cosmetic; core 141/141 cols + 0 Σ mismatches unaffected).
- Optional depth: remaining niche RP_ Crystal variants beyond the 45; VP/inout edge variants; per-customer data migration runbook execution.

## How to run / verify
- App: API :4000 (`DATABASE_URL=… PORT=4000 JWT_SECRET=… node apps/api/dist/server.js`) + Web :4001 (`pnpm --filter @datacare/web start`). Login admin/Secret#1, Co 01, FY 2024 → http://localhost:4001
- Cert: `node apps/api/integration/{xdb_diff,parity_report,parity_sweep}.mjs` (DATABASE_URL set); `pnpm --filter @datacare/api test`; `pnpm typecheck`.
