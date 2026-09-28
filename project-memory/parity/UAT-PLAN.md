# G6 Shop User Acceptance Test Plan

**Execution status: NOT EXECUTED. No scenario below was run in this environment, no result is implied, and business sign-off is outstanding.** Execute on an approved customer-site/UAT tenant with representative sanitized or approved test data. Record executor, date/time, browser/device, build, evidence links, actual result, defects, and pass/fail for every scenario.

## Common data and controls

Required before execution: approved company/location/year/books; administrator and restricted users with known `USER_SET` rights; parties with intra/inter-state GST profiles; configured taxes, items/groups/accounts, rates, lock date, rounding settings, stock/tags, karigars, pledge customers, printers and devices; opening balances; and expected control totals signed by the business owner. For every financial scenario capture voucher JSON/UI, printed document, affected ledgers/stock, audit entry, and reversal state.

## Sales

### SAL-1 — Counter sale, posting, print, and reopen

**Data:** customer, active sales book, one loose item, one available tag, GST configuration, cash/bank accounts, expected tax and fine calculations.

1. Sign in as a user with Sales View but no Edit/Delete and create a sale with one tagged and one loose line, mixed tender, discount, and GST. **Expected:** save succeeds; one unique voucher number is allocated; totals, fine, GST split, tender, bill outstanding, ledger, tag consumption, and stock movements equal the pre-calculated control sheet.
2. Reopen the voucher and render/print the invoice. **Expected:** persisted values and copy label match; barcode/QR/images (if configured) are legible; no recalculation drift.
3. Attempt edit/delete as the restricted user. **Expected:** both are denied without data change and an authorized user can perform the permitted action.
4. Reverse/delete as an authorized user. **Expected:** server-derived reversal restores tag/stock/outstanding/ledger state and records deletion/audit evidence exactly once.

### SAL-2 — Interstate and boundary validation

Create an interstate sale, then try a mismatched client `interState`, unavailable tag, invalid book, locked date, and duplicate concurrent save. **Expected:** valid IGST posts; every invalid case fails closed with no partial rows or consumed tag; concurrent saves receive distinct voucher numbers.

## Purchase

### PUR-1 — Purchase invoice through stock and payable

**Data:** supplier GST profile, purchase book/accounts, tagged and loose items, labour/other charges, supplier bill number.

1. Enter purchase lines and supplier bill details. **Expected:** gross/net/fine, tax, payable, stock/tag creation, account posting, hidden/main numbering, and bill outstanding match controls.
2. Reopen/edit quantities and charges. **Expected:** identity is preserved and all dependent rows are replaced atomically.
3. Print purchase invoice/register and reverse. **Expected:** report includes the voucher once; reversal removes payable/stock/tax effects and creates expected deletion evidence.

### PUR-2 — Purchase return and duplicate controls

Return part of the purchase and attempt over-return, duplicate supplier reference, wrong tax geography, and locked-date reversal. **Expected:** valid quantities and financial effects reverse proportionally; invalid attempts leave the source and stock unchanged.

## Tags and stock

### STK-1 — Tag opening, transfer, split, weight difference, and cancellation

**Data:** unique tag series, source/destination location/counter, item purity, scale/manual control weights.

1. Create tag opening and verify tag print. **Expected:** exact tag identity, pieces, gross/net/fine and label content persist.
2. Transfer the tag between counters/locations. **Expected:** source decreases and destination increases once; history remains traceable.
3. Split a tag with weights summing to the source, then record an authorized weight difference. **Expected:** source/new identities and signed movements reconcile to approved tolerance.
4. Try duplicate, already-consumed, cross-tenant, and over-weight operations. **Expected:** all fail atomically.
5. Cancel an eligible tag. **Expected:** availability and stock reports reconcile and audit/delete evidence is present.

### STK-2 — Physical stock

Count selected tags plus a missing/unexpected tag and reconcile after approval. **Expected:** variance preview is stable; no posting occurs before approval; approved adjustments match count evidence and cannot be applied twice.

## Manufacturing

### MFG-1 — Karigar issue/receipt and lot lifecycle

**Data:** karigar, manufacturing book/accounts, input lot/tag, expected loss/wastage/fine, output items.

1. Issue material to a karigar against a lot/order. **Expected:** stock and karigar metal balance move out once.
2. Receive finished item, by-product and loss with approved touch/fine. **Expected:** issue references are consumed correctly; input/output/fine/labour balance to the control sheet; generated tags are unique.
3. Reopen/edit and then reverse receipt/issue in allowed order. **Expected:** dependent state prevents unsafe reversal; valid reversal restores balances atomically.

### MFG-2 — Melting

Create melting with multiple inputs and outputs, print/reopen it, and attempt an unbalanced or duplicate-source save. **Expected:** valid persisted families reconcile; invalid save has zero partial writes.

## Dhiran (pledge loans)

### DHR-1 — Issue, receipt, interest, and khata

**Data:** pledge customer, collateral/tag details, principal, rate policy (monthly/day-count), dates, cash/bank account, expected interest schedule.

1. Issue pledge principal and collateral. **Expected:** issue receipt, cash/bank ledger, outstanding principal, and collateral custody match controls.
2. Record partial principal receipt and interest on a later date. **Expected:** allocation cannot exceed open principal; interest uses configured method/days; ledgers and outstanding update exactly once.
3. Print khata/outstanding and settle. **Expected:** chronology, principal, interest and zero/remaining balance reconcile.
4. Try receipt against another customer/tenant, future-invalid date, overpayment, and locked-period reversal. **Expected:** fail closed without changing collateral or balances.

## Finance

### FIN-1 — Receipt/payment/contra/journal

**Data:** parties and cash/bank/expense/income accounts, opening balances, bill-wise outstanding, cheque details.

1. Post receipt allocated across two bills plus a permitted round-off. **Expected:** Dr=Cr, bill balances reduce exactly, tender/cheque data persists, and party ledger agrees.
2. Post payment, contra, and balanced journal. **Expected:** each book uses configured control accounts and unique numbering; cash/bank day totals reconcile.
3. Attempt unbalanced journal, unavailable configured account, duplicate allocation, unauthorized edit, and locked-date reversal. **Expected:** no partial writes; appropriate denial.

### FIN-2 — Bank reconciliation and rate cut

Clear selected bank entries and post a gold rate cut. **Expected:** cleared state/date and fixed/unfixed balances match controls; re-running is idempotent or explicitly rejected; reports reconcile.

## Reports

### RPT-1 — Financial and stock control totals

**Data:** the vouchers created above plus pre-approved expected totals.

1. Run sales/purchase registers, day book, trial balance, account ledger, outstanding, stock valuation/tag stock, karigar balance, and Dhiran outstanding for exact filters. **Expected:** every qualifying voucher appears once, excluded vouchers do not appear, totals agree across reports and ledgers, and Dr=Cr.
2. Change date/company/location/book filters. **Expected:** scope changes only authorized data; no cross-tenant/company/location leakage.
3. Export CSV and render/print configured documents. **Expected:** columns, ordering, grouping, totals, pagination, fonts, images, barcodes and page dimensions meet approved desktop/business samples.
4. Run with no rows and high row volume. **Expected:** clear empty state; high-volume rendering completes within business-approved targets without truncation.

## Devices

### DEV-1 — Scale

**Required hardware data:** manufacturer/model, firmware, capacity/precision, USB VID/PID or serial adapter/chipset, OS driver, baud/data/parity/stop settings, and calibration certificate.

1. Pair/connect from an approved browser or authenticated loopback agent. **Expected:** exact device identity and permission state are visible; no false connected state.
2. Send stable, unstable, stale, future, malformed, over-range, wrong-unit, and excess-precision readings. **Expected:** only fresh stable in-policy readings populate weight; no reading auto-saves a voucher.
3. Disconnect/revoke permission. **Expected:** clear error and manual-entry fallback; no stale value reuse.

### DEV-2 — Printer/scanner/camera

**Required hardware data:** label/A4/receipt printer model and driver, media dimensions/DPI, barcode scanner model/mode, camera model/browser permission, sample labels/documents.

Print tags/invoices/reports; scan valid/invalid barcodes; capture/deny/remove an image. **Expected:** physical dimensions and readability pass operator checks, duplicate scans are handled, permissions are explicit, image retention/scope is correct, and each device failure has a truthful fallback.

## Acceptance and sign-off

A scenario passes only when expected business outcomes, database/control totals, authorization, audit, printed/device output, and reversal behavior all pass with attached evidence and no unresolved severity-1/2 defect. Required signers: authorized shop operations owner, finance/accounting owner, inventory/manufacturing owner, and deployment/security owner (names and authority must be supplied by the customer). No signer or site was available here; therefore all execution and sign-off remain outstanding.
