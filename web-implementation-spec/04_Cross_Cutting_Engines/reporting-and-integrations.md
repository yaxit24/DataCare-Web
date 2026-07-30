# Reporting & Integrations Engines

Two subsystems that many modules plug into: the **report engine** (Crystal `.rpt` → HTML/PDF) and the
**integrations framework** (WhatsApp/SMS/e-invoice/rates/barcode), wired so a failed external call
never breaks a saved transaction.

Source: `packages/reports`, `modules/reports`, `modules/integrations`. Requirements: Req 19 (reports), 20 (integrations).

---

## A. Report Engine

### A.1 Anatomy of a web report
A report = **dataset builder** + **HTML template** + **PDF renderer**.
```
request(scope, dateRange, params)
  → datasetBuilder()   // scoped SQL read-model (e.g. salesRegister, dayBook, trialBalance)
  → HTML template      // same columns/fields as the Crystal .rpt
  → PdfRenderer         // Playwright/Chromium → PDF (or CSV export)
```

### A.2 Renderer contract
```ts
interface PdfRenderer { render(html: string): Promise<Buffer>; }
// FakePdfRenderer  → tests (no browser)
// PlaywrightPdfRenderer → real PDF via Chromium
```

### A.3 Parity rule
The **dataset** (records + fields) must equal the corresponding Crystal `.rpt` for the same scope
(Req 19.1/19.3). Pixel layout is re-created in HTML/CSS; data is the parity contract. Empty scope →
an empty report that says "no records" (Req 19.5). Print requires `USER_PRINT`.

### A.4 Built so far (re-verify vs spec)
HANDOFF cites 16 reports live with CSV+PDF: sales/purchase registers, day-book, trial-balance,
balance-sheet, account-ledger, account-balances, outstanding, monthly-sales, sales-by-party/item,
pledge-outstanding, karigar-balances, stock-valuation, GSTR-1, GSTR-3B. Full catalog + per-report
field specs live in `05_Reports/` (255 `.rpt` + 45 report forms).

---

## B. Integrations Framework

### B.1 The non-blocking rule — Req 20.3
A failed WhatsApp/SMS/IRN call must **never** roll back the underlying transaction. Senders are
called **after** commit and swallow errors into a logged result:
```ts
MessageSender.notify(...)  // returns {ok|failed, error?}; never throws into the txn
```

### B.2 Adapter pattern (env-driven, Fake until creds)
Each integration is an interface with a `Fake*` default and a real adapter activated by env vars —
**no code change** to go live, just configuration:

| Integration | Real adapter | Activate with | Desktop origin |
|---|---|---|---|
| Live gold/silver/forex rates | gold-api.com + frankfurter.app | (live now, no creds) | rate fetch |
| Barcode / QR | pure Code39 SVG + QR encoder | (live now) | tag print |
| PDF | PlaywrightPdfRenderer (Chromium) | (live now) | Crystal export |
| WhatsApp | Meta Graph v22 Cloud API | `WA_PHONE_ID`, `WA_TOKEN` | `UT_WAPP_WITH_API`, `Module_WhatsApp` |
| SMS | generic HTTP gateway | `SMS_URL_TEMPLATE`,`SMS_KEY`,`SMS_SENDER` | `UT_SMS` |
| E-invoice IRN | Chartered Info GSP | `aspid`/`password`/`Gstin`/`User_Name`/`eInvPwd` | `TR_SL_EBILL`, `UT_E_INVOICE`, `IrnTransport` |
| Insurance locker | OLocker | TBD | `OlockerService` |
| Payment / UAE Planet Pay | adapter TBD | TBD | UAE variant |

### B.3 E-invoice (IRN) summary
`buildIrnPayload()` produces the NIC v1.1 payload (GenIRN parity) from a B2B invoice; `submitIrn()`
posts via the GSP and stores the returned IRN + ack on `SL_DATA`/`E_DATA`; on error, the error is
recorded and the sale keeps no IRN (Req 18.4/18.5). Real GSP submit is an **external blocker** until
creds are set. Full spec in `03_Modules/gst-einvoice/`.

### B.4 Parity criteria (DoD)
- Reports: dataset equals the `.rpt` dataset for the scope; PDF/CSV export works; print gated by `USER_PRINT`.
- Integrations: a forced adapter failure logs + reports but leaves the saved transaction intact.
- IRN payload validates against NIC schema; stored IRN/ack round-trips onto the invoice.
