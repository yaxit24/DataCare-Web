# Web module map

Every API module in `web/apps/api/src/modules/` and the shared frontend pieces. Module-level gaps and target files
are in [document 06](../../master-parity-plan-2026-09-29/06-module-detail.md); per-menu status is in the
[menu catalog](../menu-catalog.md). `docs/tools/docs_check.py` fails when a module directory is missing from the
table below.

## API modules

| Module | Responsibility | Main desktop forms |
|---|---|---|
| `accounting` | Trial balance, account ledger, balances | `RP_LEDR`, `RP_BALANCE` |
| `auth` | JWT and passwords, persisted sessions, business scope, context epoch | `MS_LOGIN`, `MS_OPNCOMP`, password update |
| `bullion` | Bullion booking, bullion sale, fine sale and purchase posting | `TR_BUL_BOOKING`, `TR_BUL_SALE`, `TR_FINE_SL_PR` |
| `dhrn` | Pledge and loan issue, receipt and interest; outstanding; receipt and khata documents | `TR_DHRN_ISU`, `TR_DHRN_REC`, `TR_DHRN_INTREC` |
| `documents` | Scoped A4 document chrome and the voucher document key | Sales, purchase, finance, karigar and loan prints |
| `einvoice` | E-invoice and e-credit-note lifecycle, IRN payload, transport, cancel, export | `TR_SL_EBILL`, `UT_E_INVOICE` |
| `finance` | Cash, payment, contra, journal, fine and employee JV, tenders, bill allocation, bank reconciliation, location amounts | `TR_CASH`, `TR_CONTRA`, `TR_EMP_JV`, `TR_LOCT_AMT`, `TR_LEDR_ADJ`, `TR_BILL_TO`, `UT_BANK` |
| `forms` | Static HTML preview of extracted WinForms layouts (not interactive forms) | Layout catalog |
| `gst` | GSTR-1 families, HSN summary and documents | `RP_GST`, `RP_TAX` |
| `images` | Versioned entity, order and tag images with provenance | `Ac_Image`, order and design images |
| `inout` | Fine-metal in/out posting and delete | `TR_FN_INOUT` |
| `integrations` | Code39 and QR, scale protocol, live rates, WhatsApp and SMS, readiness | Scale handlers, rate feed, `UT_WHATSAPP`, `UT_WAPP_WITH_API`, `UT_SMS` |
| `manufacturing` | Manufacturing issue and receipt, karigar, job work, melting; lot browse | `TR_MFG_*`, `TR_KR_ISU`, melting |
| `masters` | Generic and curated master CRUD, lookups, party, rate, year, openings, design book, company configuration | `MS_*` masters, `MS_YEAR`, `MS_DESIGN_BOOK`, `MS_RATE` |
| `membership` | Loyalty points; scheme enrolment, instalments, maturity and gold adjustment | `MS_POINT`, `MS_MEMB`, `TR_MEMB_ENT`, `TR_MEMB_ADJ` |
| `ops` | Health, readiness, metrics, invariants, audit, demo seed, provisioning, backup, year end, migration manifest, release certification | `UT_BKP`, year transfer and close |
| `parity` | Golden vectors, typed bundles and row-pairing differential (diagnostics only) | — |
| `posting` | Desktop column defaults, row insert, balance check, period guard, post and reverse | `Ac_Ledr`, `Ac_Stock`, `Ac_Rojmel`, `Ac_Tax` |
| `purchase` | Purchase, hallmark purchase, quotation, consignment purchase, return, other income and expenses, commission, documents | `TR_PURC`, `TR_PURC_HM`, `TR_KR_ISU`, `TR_OTH_PURC`, `TR_OTH_COMM`, `TR_PR_SL_UAE` |
| `rbac` | Form catalog, route policy, current principal, users and form rights | `MS_USER`, MDI menu rights |
| `repair` | Repair intake, karigar issue and receipt, customer delivery, photos and documents | `TR_REP_REC` repair modes |
| `reports` | Report datasets, filters, staging, Crystal bindings, formulas, layout engine, CSV, XLSX, PDF rendering | `RP_*` report forms |
| `sales` | Retail, hallmark, wholesale and labour sales, orders, quotations, returns, rate cut, VP parcel | `TR_SALE`, `TR_SALE_HM`, `TR_SALE_RTN`, `TR_WH_SALE`, `TR_WH_SALE_RTN`, `TR_SALE_ORD`, `TR_TOUR_ORD`, `TR_SALE_LBR`, `TR_VP` |
| `scheme` | Scheme passbook staging and document | Scheme passbook (`RP_CASH_BANK` scheme mode) |
| `security` | SQL identifier validation and quoting | — |
| `settings` | Typed, NULL-preserving `CO_SET` and `CO_SET_NEW` read and write | `UT_SETTING`, `UT_SETTING_MAIN`, `UT_SET_ADMIN` |
| `shared` | Book, account, tax, fine, labour, rounding, period and stock policies; Rojmel builder | `DC_Main` helpers |
| `stock` | Tags, openings, stock in/out, physical stock, adjustments, tag split, cancel, transfer, print, invariants | `TR_TAG_*`, `TR_PHYSTK`, `TR_INOUT`, `TR_ITM_OPBL`, `TR_ITM_LOT`, `UT_TAG_PRINT` |
| `tour` | Approval and tour issue, return, source lines, billing and delete | `TR_APR_ISU`, `TR_TOUR` |
| `utilities` | Data repair, export, refresh, renumber, estimate reset, reminders, HDD registry, window tiles, user requests | `MS_UPDATE`, `UT_EXPORT`, `UT_VCH_RE_NUMBR`, `UT_IMPORT`, `UT_HDD`, `MS_WINDOW_SET`, `UT_USER_REQUEST` |
| `vouchers` | Visible and hidden numbering, header lock, fiscal key, recent lists, field audit | All voucher forms |

Routes: most business routes are declared in `web/apps/api/src/routes/txn.ts`; authentication, context, masters,
lookups and settings in `web/apps/api/src/app.ts`. The exact route universe (608 routes on 1 October) is fixed by
`web/apps/api/test/routePolicy.test.ts`. Slice N88 moves each family into a route plugin in its module.

## Frontend

**Shell and navigation.** `web/apps/web/app/(app)/layout.tsx` loads the current user and business scope and renders
`web/apps/web/components/Shell.tsx`; `web/apps/web/lib/nav.ts` defines 13 web navigation groups (Sales, Purchase,
Cash / Bank, Inventory and so on — not the desktop's 13 ribbon tabs), filtered by the user's form rights.

**Shared components** (`web/apps/web/components/`):

| Component | Use |
|---|---|
| `BookSelect` | Book chooser for a `MAIN_BOOK` family (desktop `CurBookHelp`) |
| `LookupPicker` | Type-ahead and F1 lookup (desktop "DataCare Help") |
| `GridKeyboard`, `KeyboardNav`, `FormKeys` | Arrow, Enter and row keys in grids; Enter navigation; desktop F-keys and Ctrl chords |
| `SubDetailGrid`, `ExtendedGrid` | Per-line stone/component sub-detail (`*_IDTL`); extended grid columns |
| `VoucherChrome`, `VoucherList` | Voucher header and toolbar; recent vouchers |
| `PaymentForm` | Cash and bank receipts and payments |
| `KarigarForm` | Karigar issue and receipt, old-item sales |
| `WholesaleVoucherForm` | Wholesale sale and quotation, rate cut |
| `EBillEntry` | E-invoice and e-credit-note |
| `StockInoutForm`, `TagSplitForm`, `TagCancelForm`, `MfgLotForm` | Stock movement, tag split, tag cancel and transfer, manufacturing lots |
| `ScaleCapture`, `CameraCapture`, `DeviceCapabilityProbe` | Weighing scale (WebSerial), camera, device detection |

**Libraries** (`web/apps/web/lib/`): `api.ts` (the only way pages call the API), `nav.ts`, `companySettings.ts`
(settings cache), `pageContext.ts` (drops responses from an old session context).

**Page pattern for a voucher screen:**

1. Read the business scope; choose a book with `BookSelect`.
2. Load lookups (parties, items, accounts) with `LookupPicker`.
3. Keep an editable draft; recalculate with `@datacare/core` functions, never with ad-hoc arithmetic.
4. Create with POST; reopen with GET and hydrate **every** returned field; update with PUT; delete with
   confirmation; print; reload the saved voucher to show persisted values.
5. Show the API's field errors next to the fields.

Slice N88 turns this pattern into a shared voucher editor in `web/apps/web/lib/voucher/` (lossless hydration, dirty
tracking, version token, idempotency key, delete, print and a recent list with the full voucher identity).
