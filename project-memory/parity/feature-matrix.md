# Desktop ↔ Web — Feature / Working Comparison Matrix

_2026-06-28. Desktop = DataCareNext (VB.NET/SQL Server). Web = this repo (Fastify/Postgres). "Evidence" = the automated test proving equivalent working._

| # | Desktop feature (form / source) | Web module | REST endpoint(s) | Test evidence |
|---|---|---|---|---|
| 1 | Login + sessions (`MS_LOGIN`, `LOGIN_MAST` plaintext) | `auth/*` (Argon2, JWT) | `POST /auth/login`,`/logout` | auth.live `AUTH_INTEGRATION_PASS`; http.live login+cookie |
| 2 | Company/Year open (`MS_OPNCOMP`, `CO_MAST`/`YEAR_MAST`) | `app.ts` context | `GET /context/companies|years`, `POST /context/select` | http.live (companies CO01, year 200/409) |
| 3 | User rights / dynamic nav (`MS_USER`, USER_UPDATE/DELETE/PRINT) | `rbac/policy` | guards on all mutations | http.live (clerk delete 403); http_txn (clerk 403) |
| 4 | Masters — accounts/items/rates/taxes/groups/emp/books (`AC_MAST`,`ITEM_MAST`,…) | `masters/*` | `GET/POST/DELETE /masters/:name` | masters.live 11/11 |
| 5 | Sales (`TR_SALE`, `SL_DATA/SL_DETL/SL_IDTL`) + GST split | `sales/*` | `POST /sales`,`DELETE /sales/:vchNo` | sales.live 14/14; **compute_parity 190/190 exact tax+total vs desktop** |
| 6 | Purchase (`TR_PURC`, `PR_DATA/PR_DETL`) + stock-in | `purchase/*` | `POST /purchases`,`DELETE /purchases/:vchNo` | purchase.live 13/13 |
| 7 | Double-entry posting / ledger (`Ac_Ledr`, `AC_DATA`) | `posting/*` | (internal, used by all txns) | posting.live 6/6; **xdb: AC_DATA 5150 rows + Σ DR/CR/FINE match desktop** |
| 8 | Receipts / Payments / Contra (`CASH_DATA`/`PAY_DATA`/`CONTRA_DATA`) | `finance/*` | `POST /receipts`,`/payments`,`/contra` | finance.live 11/11; cash-limit→PAN |
| 9 | Trial balance / account ledger (`RP_LEDR`) | `accounting/*` | `GET /reports/trial-balance`,`/account-ledger/:ac` | accounting.live 8/8 |
| 10 | Tag & stock, double-issue prevention (`TAG_STOCK`,`MAIN_STOCK`) | `stock/*` | (internal) | stock.live 8/8 (concurrent double-issue) |
| 11 | Voucher numbering (`SRNO_MAST`) | `vouchers/numbering` | (internal) | numbering.live (8 concurrent → 1..8) |
| 12 | Dhrn pledge loans (`DHRN_*`, `RP_DHRN_OS`) | `dhrn/*` | `POST /dhrn/issue|receipt`,`GET …/outstanding` | dhrn.live 13/13; **knob INT_TYPE='M' confirmed vs golden-master** |
| 13 | Karigar manufacturing (`KR_*`, `MS_UPDATE` wastage) | `manufacturing/karigar` | `POST /karigar/issue|receive`,`GET …/balance` | karigar.live 11/11; **knob INOUT 'I'/'O' confirmed+fixed** |
| 14 | GST returns B2B/B2CL/B2CS/HSN | `gst/*` | `GET /gst/gstr1` | gst.live 11/11 |
| 15 | E-Invoice IRN (`GenIRN.txt`, `UT_E_INVOICE`) | `einvoice/*` | `POST /einvoice/:vchNo` | einvoice.live 7/7 (real GSP = creds-gated) |
| 16 | Reports / registers (`.rpt`) | `reports/*` | `GET /reports/sales-register|purchase-register|day-book` | reports.live 10/10 |
| 17 | Print → PDF (Crystal Reports) | `reports/render` | HTML→PDF | render.live 5/5 (real Chromium = install-gated) |
| 18 | WhatsApp/SMS + barcode (`UT_WHATSAPP`/`UT_SMS`/`FRE3OF9X.TTF`) | `integrations/*` | `notify`, Code39 SVG, UPI | integrations.live 6/6 (real providers = creds-gated) |
| 19 | Security: tenant isolation, injection | `security/*`, RLS | — | security.live 3/3 (RLS isolation) |
| 20 | Data migration SQL Server→Postgres | ETL + `@datacare/parity` | `xdb_diff`,`compute_parity` | **141/141 cols, 371/372 Σ, 190/190 invoice compute** |

## Working-equivalence summary
- **Data:** 141/141 common tables column-complete vs golden-master; 371/372 numeric Σ checks match (1 = intended money-rounding); core txn/ledger/sales/master path byte-faithful.
- **Computation:** the web calc engine reproduces **every** real desktop invoice's tax & total **exactly** (190/190).
- **Behaviour:** 20 live integration scripts exercise each feature end-to-end (auth/RBAC, posting, all transactions, reports, GST, e-invoice, integrations, parity, security).
- **Creds-gated (identical interface, fake until provided):** GSP e-invoice submit, WhatsApp/SMS, server-side Chromium PDF.
- **Client:** the mobile app consumes the 26-route REST API; the desktop's WinForms UI is replaced by that API + (your) mobile app.
