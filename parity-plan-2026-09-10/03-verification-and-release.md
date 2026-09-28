# Verification, business acceptance and production release

> 11 September continuation: apply the fixture packs, evidence contract and X03/X34 exact-set implementation in [document 12](12-execution-addendum.md). Current mocked browser suites are not real-browser/database evidence. This verification specification remains mandatory; the 128 anchors expand with discovered modes and requirements.

## What must be proven

The web replacement must let an authorized operator complete every in-scope desktop operation with the required fields, choices, lookups, calculations and outputs. It must preserve historical business data, write the correct new business data, handle subsequent edits/returns/adjustments, and operate safely under concurrent web use. It must also remain usable at the counter and recoverable during failures.

For this request, the full primary-product scope is required. “In scope” cannot be reduced by an old waiver, a missing artifact, an unimplemented web route or an untested branch. A limited pilot/deployment certificate is a separate result and does not complete the requested conversion. Internet-independent operation is a first-class service requirement to resolve and verify in P02-06; an undisclosed cloud-only limitation prevents an unqualified operational-parity claim.

Use separate states: **inventoried → contracted → implemented → engineering-verified → desktop-compared → business-accepted → production-certified**. A requirement may be blocked or excluded with a recorded reason, but it cannot skip a state by having a similar-looking page. Every later state links its evidence. Historical status labels in the supplied registers are review leads, not current certification.

## Test layers and evidence required

| Layer | What to exercise | Required evidence | Cannot establish |
| --- | --- | --- | --- |
| T0: inventory/contract checks | Source/menu/grid/action/report/setting mappings; supported modes; references | Complete requirement registry; no unresolved in-scope unit; scanner positive/negative controls | Runtime equivalence |
| T1: deterministic domain tests | Fine, gross/net, labour, rate basis, tax, rounding, interest, dates, allocation formulas | Source-cited independent vectors; negative midpoint/boundary cases | Correct API wiring or persistence |
| T2: request/domain contract tests | Authentication, scoped lookup, validation, route conversion, numeric/text handling, error mapping | Valid/invalid requests; direct caller assertions; reader/writer schema checks | Actual RLS, database writes or browser state |
| T3: real database integration | Full create/read/edit/delete, rollback, locking, numbering, references, RLS | Before/after row snapshots by full key; invariants; real app-role DB connection | Operator reachability or desktop equivalence |
| T4: real browser/API/database | Fields, keyboard, lookups, intermediate totals, actual requests, hydration, printed/exported data | Playwright traces/screenshots, request bodies, server results and independently read persisted rows | Agreement with desktop unless compared |
| T5: desktop differential | Same starting data/settings and action sequence in independent desktop/web runs | Raw capture hashes, canonicalized comparisons, reviewed exclusions, zero unexplained differences | Production recovery/peripheral quality |
| T6: output/device validation | Real scales, scanners, cameras, printers and rendered reports | Device/version matrix, sample outputs, operator observations and failure/reconnect results | Complete workflow correctness alone |
| T7: deployment/business acceptance | Load, recovery, migration, cutover, role-based UAT | Release manifest, rehearsals, signed UAT, operating runbooks | Nothing remains implied; this is the final gate |

Keep existing tests at their actual level. `browser.smoke.mjs` and `route-coverage.mjs` currently stub API calls. They can prove UI interactions and renderability, not database effects. `operatorDepth.roundtrip.db.test.ts` can prove module round-trips for its fixtures, but does not prove the page sends the same fields. Every important input needs both proofs connected.

## Mandatory per-form test matrix

Every applicable row below runs for every supported form/mode, not just once per reused component. For a read-only form or engine, record which rows are inapplicable and test its callers instead.

| ID | Action | Required result |
| --- | --- | --- |
| FORM-01 | Open via intended menu, shortcut and direct URL with correct role/context | Correct form/mode, book, title, default date and visible fields |
| FORM-02 | Open with denied role, wrong context, expired session or forced password reset | Correct denial/recovery; no data disclosure or mutation |
| FORM-03 | Create the smallest valid document | Correct identity, defaults, records and visible success state |
| FORM-04 | Create a maximally rich valid document with distinct values | Every applicable field/child/relationship reaches the intended writer and reader |
| FORM-05 | Submit each required field blank; invalid enum, length, precision, sign and date | Correct blocking/confirmation/focus behaviour; no partial writes |
| FORM-06 | Use every lookup and dependent-fill branch | Correct scope, search, selected identity, related fills and recalculation |
| FORM-07 | Exit cells through Tab, Enter, pointer and scanner input | Equivalent derived values and row navigation; no double event or stale total |
| FORM-08 | Reopen and save without changing anything | All business values and source identities preserved; only declared audit effects differ |
| FORM-09 | Edit one header field, one line field and one child field separately | Only intended values and dependent calculations/effects change |
| FORM-10 | Add, remove, reorder and copy lines/components | Stable parent/child references; no orphan or reassigned child |
| FORM-11 | Edit after a dependent receipt/return/issue/adjustment exists | Source-backed restriction or complete dependency-aware recomputation |
| FORM-12 | Cancel/delete/reverse, then retry | Correct stock/money/tax/allocations restored once; history preserved appropriately |
| FORM-13 | Save twice, retry after timeout, submit concurrent edit | Exactly one accepted result or explicit conflict; no silent overwrite |
| FORM-14 | Change company/location/year/book during a draft | Explicit state handling, no stale-scope save or mixed-master references |
| FORM-15 | Print, export, reprint and drill from a report | Same document/filter/context, correct role and numeric totals |
| FORM-16 | Lose network/session/device during entry/save/print | Recoverable state, actionable error and unambiguous posted status |
| FORM-17 | Run allowed setting/edition combinations | Correct visibility, defaults, validation, calculations and persisted effects |
| FORM-18 | Repeat the journey from a fresh provisioned business | No reliance on hidden seed rows, hardcoded accounts, book names or privileged DB roles |

For each grid, enumerate **all named columns**, not only current visible cells. Classify operator-input, computed, hidden bookkeeping, browse-only, conditional or obsolete. Explain every omission. The 3,508 requirement records in `evidence/grid-requirements.json` provide stable initial IDs and candidate source lines. Header positions are extraction ordinals, not guaranteed desktop numeric column indices; resolve the actual grid index and field identity while contracting.

Standalone input controls, buttons, menu modes, formulas, validations and hidden persisted fields need their own requirement records in P00. The grid register is not the complete requirement denominator by itself.

## Field-path proof procedure

1. Choose distinctive valid values for every field so crossed mappings cannot accidentally match. Use nonzero quantities, different weights, alphanumeric HUIDs, different child values and different amounts at each level.
2. Enter them through the real UI under the required setting/mode. Capture the submitted request and map it through the exact route adapter. A field on the page must not be dropped by body normalization.
3. Assert server calculation/validation output, then query all affected persisted rows independently using the full ownership key. Do not only assert the response echoes the input.
4. Close the form, reload it from the server and check hydration of all fields, children, images and source references.
5. Save unchanged. Compare persisted business columns and identity; allow only documented audit/timestamp effects. Test omitted versus null versus blank versus explicit zero separately.
6. Change an upstream value and check every dependent display and persisted calculation. Ensure a previously calculated value did not become a frozen manual override.
7. Change one child, remove another, reorder parents, save/reopen and confirm child ownership.
8. Reverse/delete through the supported workflow. Compare stock, ledger, Rojmel, outstanding, tax, source allocation, images and audit effects against the desktop.
9. Print/export the resulting document and compare all relevant displayed values to the persisted result.

A broken-field negative control must be demonstrated: remove a request field, drop a writer mapping, omit it in the reader, alter its decimal scale and change parent linkage. Each fault should fail at its relevant layer. Revert the deliberate fault before normal verification. This avoids tests that pass because they only exercise a helper unrelated to the changed caller.

## Invariants for money, metal, identity and scope

| Invariant | How to verify |
| --- | --- |
| Voucher identity is complete | Key sets match for tenant/company/location/year/book/voucher and table-specific serials; reused visible numbers stay distinct |
| Ledger balance is necessary but insufficient | Assert total debits/credits and the exact row count, accounts, leg codes, signs, narration, amounts and source keys |
| Rojmel expresses the correct movements | Compare metal versus money rows, item/party/contra identity, one-per-line rules, tax, outstanding and tender branches |
| Physical material is conserved | Opening + receipts − issues ± explicit adjustments = closing, separately for pieces, gross/net/fine and components at the relevant scope |
| Fine transformations explain losses | Input fine − output fine equals measured permitted loss/residual; preserve source precision and allocation rules |
| Outstanding reflects actual allocations | Bill total minus allowed adjustments/settlements equals outstanding; no overconsumption or duplicate allocation |
| Booking/order/scheme availability is reversible | Consume on accepted transition, release on reverse, preserve partial availability and prevent duplicate consumption |
| Child identity remains attached | Components, HUIDs, images and allocation rows retain their intended parent and historical source references |
| No-change edit is stable | All business columns unchanged except explicitly justified derived/audit updates; hidden fields are included |
| Denied/failed mutation is atomic | No header without detail, no partial ledger/stock rows, no advanced sequence exposed incorrectly, no incomplete children |
| Scope is enforced by real roles | Non-owner app role under forced RLS plus company/location/year/form rights; direct requests cannot widen scope |
| Printed/exported data agrees | Source totals and selected filters equal UI/PDF/CSV/XLSX values; unsupported reports do not fall back to another family |

Compare exact decimal values at each source-defined persisted scale. Do not apply one global floating tolerance to money and weight. Preserve decimal text where necessary rather than converting large precise values through JavaScript Number. Distinguish a real null from an empty string, zero and missing property unless that specific column's compatibility contract permits normalization. Do not trim every string: padded ledger/reference keys can be meaningful. Normalize timestamps only according to the column's actual date/local-time/UTC semantics.

## Fixture matrix for real jewellery businesses

Build deterministic fixture packs with published seed and hashes. Start with synthetic business records for repeatable tests; independently validate rules against sanitized desktop captures. Never derive the expected desktop output from the new web calculator.

| Axis | Required coverage |
| --- | --- |
| Business configurations | Retail gold/silver, wholesale/bullion, manufacturing/jobwork, diamond/component-heavy work, scheme/pledge services as in scope |
| Organization | Two tenants; two companies within one tenant; at least two locations and fiscal years; deliberately repeated codes/numbers |
| Books/accounts | Different book codes/names and chart-of-accounts codes across businesses; missing/duplicate/blank configured slots |
| Metals/items | Gold, silver, other; tagged and untagged; lot-tracked; component/stone; multiple HUIDs; fractional and large weights |
| Calculation modes | All supported fine/rate/labour/interest/rounding settings; blank/default/zero/manual overrides |
| Money | Cash, credit, bank/cheque, card/UPI identity, advance, old gold, scheme, credit note, kasar and mixed settlement where supported |
| Lifecycle | New, reopened, edited, partially allocated, returned, canceled/deleted, locked period, active dependency and historical reference |
| Data shape | 1/2/many lines; multiple child sets; long Unicode text; empty optional values; leading zeros; maximum supported values |
| Authorization | Owner/admin, cashier, salesman, accountant, stock clerk, karigar/manufacturing, report-only and restricted branch roles |
| Failure | Invalid input, stale edit, transaction rollback, network loss, server restart, provider timeout, device disconnect and restore interruption |
| Hardware/output | Supported OS/browser/device pairs; thermal receipt, tag, A4 and cheque layouts where used |

Every enumerated business mode must have a positive case and each distinct validation/decision branch needs a negative or alternate case. Use pairwise combinations for low-risk appearance/preferences, but explicitly cover high-risk interactions: cross-scope identity + edit; partial allocation + reversal; multi-tender + tax/rounding; tagged item + component + return; source conversion + stale/concurrent consumption; year-end + opening balances.

## Concrete scenario catalog

These scenarios are minimum acceptance anchors. Expand each across applicable modes and combine with FORM-01–18; the count below is not the final test count. Each case records initial state, actual user actions, expected UI, request, database changes, forbidden changes, output documents and desktop evidence.

There are now **128 anchors**, including 12 added during plan re-verification. Neither 128 cases nor 83 completed work packages is an adequate release criterion by itself. Enumerated leaf requirements determine the actual mandatory case set.

### Inventory, setup and instrumentation

| ID | Scenario | Expected proof |
| --- | --- | --- |
| SET-01 | New company, branch, year and books, then first purchase/sale | Complete provisioning; no manual SQL or assumed default business codes |
| SET-02 | Same account/design/tag/voucher code in two companies and years | Correct lookup, image, edit and report isolation |
| SET-03 | Missing/duplicate configured posting account slot | Explicit configuration error, no fallback ledger or partial voucher |
| SET-04 | Setting values blank, Y/N, explicit zero and invalid code | Desktop defaults and effects; invalid values reported consistently |
| SET-05 | Master with conditional city/mobile/tax requirements | Whole-row/config-dependent validation matches desktop |
| SET-06 | Design book with two products, same design number and different images/components | Full composite identity, DESIGN_DETL/IDTL preservation and correct print |
| SET-07 | Slab/party touch/labour selection at lower/upper boundary | Correct default rate/touch and recomputation in transaction |
| SET-08 | Import with valid, duplicate, invalid and foreign-parent rows | Complete preview/errors and atomic/explicit batch outcome |
| SET-09 | Add unused input on an unrelated page using a missing field name | Reachability audit still reports the original field gap |
| SET-10 | Add a report registry property without quotes and a newly unmapped grid | Report count remains correct; grid audit refuses missing coverage |

### Purchasing and returns

| ID | Scenario | Expected proof |
| --- | --- | --- |
| PUR-01 | Multi-item purchase with stones, lot, HUIDs and cost overrides | Exact header/detail/IDTL, supplier, stock, tax and Rojmel rows |
| PUR-02 | Fully paid purchase versus identical credit purchase | Correct outstanding/party movement branches; no unjustified extra rows |
| PUR-03 | Mixed cash, bank, advance and kasar settlement | Correct identity rows, account slots, leg codes and liability |
| PUR-04 | Hallmark purchase with hallmark tax off/on | Correct tax/amount and visible policy effect per variant |
| PUR-05 | Old-gold purchase with automatic touch and manual override | Exact conversion, fine, rate and provenance behaviour |
| PUR-06 | Purchase TDS-enabled versus disabled totals-band row | Correct row meaning, payload and posting; no stale hidden tax |
| PUR-07 | Partial component/tag purchase return against original source | Remaining source quantity/cost, tax and refund/credit are correct |
| PUR-08 | Return repeated beyond available quantity | Rejected without additional stock/ledger effects |
| PUR-09 | Rich purchase/return reopened unchanged | Every business field and reference preserved |
| PUR-10 | Edit/delete a purchase with downstream tag/sale/return | Measured lock or complete dependency-aware correction |

### Sales, orders and returns

| ID | Scenario | Expected proof |
| --- | --- | --- |
| SAL-01 | Scan a tagged item with HUID, components and image | Correct live instance, weights/cost/price fills and document |
| SAL-02 | Retype gross/less/ghat/touch/rate/labour cells in different orders | Intermediate and posted totals match source precedence |
| SAL-03 | Negative stock permitted/refused; direct request bypass attempt | Same server policy as UI, including desktop blank default |
| SAL-04 | Net/fine locked versus editable | Correct visible behaviour and server authority |
| SAL-05 | Sale with old-gold detail, order advance, scheme and UPI split | Every allocation/identity preserved and outstanding reconciles |
| SAL-06 | Cash/credit/mixed sale with discount and rounding boundaries | Exact ledger/Rojmel/tax/outstanding branches and print values |
| SAL-07 | Hallmark sale with several HUID weights | Text identity, weight association and return/reprint preserved |
| SAL-08 | Wholesale with issue and receive material grids | Both sides persist and fine/money settlement reconciles |
| SAL-09 | Labour sale with blank derived labour versus explicit zero/override | Correct received material and labour calculation/print |
| SAL-10 | Retail return with separate received/exchange grid and both child sets | Correct source relationship, inventory and refund/credit |
| SAL-11 | Wholesale return carrying original tag cost and karigar values | No copied-registry dead fields or loss on unchanged save |
| SAL-12 | Quote imported into final invoice twice | First conversion correct; repeat handled without double allocation |
| SAL-13 | Sale order with design, components, photo, old-gold and UPI advances | Full order specification and balances round-trip |
| SAL-14 | Partial order manufacturing/delivery across two invoices | Remaining quantities and money/fine advances remain correct |
| SAL-15 | Cancel a delivery and edit the source order | Allocations restored; source edits obey dependency rules |
| SAL-16 | Design reissue and subsequent manufacture | Correct source design state/history and component specification |
| SAL-17 | Approval issue imported partially then completely into sales | Source stock/status and components track exact consumption |
| SAL-18 | Transfer an invoice to another book with number collision/locked period | Rejected atomically or fully transferred with every reference updated |
| SAL-19 | Bulk wholesale wastage edit at allowed/over-negative boundary | Correct per-line recalculation and confirmation/validation |
| SAL-20 | Save rich sale, close, reopen, unchanged save, return, reverse | Full lifecycle and printed/ledger/stock reconciliation |

### Approval, tour, parcel and repair

| ID | Scenario | Expected proof |
| --- | --- | --- |
| FLOW-01 | Approval issue with multiple tags; partial return and sale | Custody and saleability remain distinct; no duplicate consumption |
| FLOW-02 | Tour order → issue → sale/return → final settlement | Remaining stock and responsibility reconcile by location/source |
| FLOW-03 | VP parcel, adjustment and cancellation | Parcel state, charge/payment and outstanding restore correctly |
| FLOW-04 | Repair receipt with condition/images and partial karigar return | Complete stage identity, weight and component custody |
| FLOW-05 | Repair completion/delivery with charges, then permitted reversal | Customer/karigar balances and acknowledgements agree |
| FLOW-06 | Source transfer/conversion while another user edits it | Explicit conflict; neither operation silently drops lineage |

### Finance and bullion

| ID | Scenario | Expected proof |
| --- | --- | --- |
| FIN-01 | Multi-line cash receipt/payment with direction-specific kasar | Correct leg/key layouts and Rojmel row pattern |
| FIN-02 | Bank receipt/payment with charges and cheque clearance | Bank-specific codes, clearance date and reconciliation |
| FIN-03 | Batch receipt, UPI/card settlement and account-payee cheque | Separate payer/payee/transaction identities preserved |
| FIN-04 | One receipt allocated across bills and several receipts to one bill | Exact remaining balances and allocation lineage |
| FIN-05 | Delete one bill allocation after another payment | Only selected allocation reversed; residual outstanding correct |
| FIN-06 | Concurrent settlement of the last outstanding amount | At most one full allocation, explicit conflict/no overpayment |
| FIN-07 | Opening amount and gold/silver fine with distinct signs | Exact opening/current balances and year-end carry |
| FIN-08 | Contra, journal, employee JV and fine/location transfer | Correct allowed lines, scopes and reversible movement |
| FIN-09 | Fine in/out with supported tax/party-fine settlement | Actual desktop money/fine footprint, not old comment assumptions |
| FIN-10 | Multi-party bullion booking with rate basis/premium | Correct individual booking balances and print |
| FIN-11 | Rate-cut issue-only, receive-only and both sides | RATE_CUT_ISU/REC, totals, ledger and daybook match |
| FIN-12 | Booking partially consumed then edited/deleted | ADJ_WT and availability restored exactly |
| FIN-13 | Two cuts compete for final booking weight | Shared lock prevents overdraw; losing request has no side effects |
| FIN-14 | Gram/ten-gram/kg/piece bases with negative midpoint correction | Source-specific rounding and preview/post parity |

### Tags and physical stock

| ID | Scenario | Expected proof |
| --- | --- | --- |
| STK-01 | Rich tag opening with four HUIDs, image and components | All barcode/IDTL/image fields and serial survive reopen/save |
| STK-02 | Counter/tag transfer with historical tag number reuse | Exactly one live identity moved; correct lineage and reverse |
| STK-03 | Cancel a live tag versus a sold/issued/historical tag | Valid cancellation only; full detail and dependent locks |
| STK-04 | Split parent into unequal children with components and images | Atomic consume/create, unique child identities and conservation |
| STK-05 | Split fails after preparing first child | Entire operation rolls back, including sequence/reference effects |
| STK-06 | Sale and split/cancel target the same tag concurrently | One succeeds according to state/lock; no duplicate availability |
| STK-07 | Weight difference positive, negative and zero | Complete replacement/lineage/posting branch and reversal |
| STK-08 | Sale/tag weight mismatch with SL_TAG_WT_DIFF toggled | Exact additional stock reconciliation rows when applicable |
| STK-09 | Physical count duplicate/unknown/wrong-location scan | Clear discrepancy; no accidental double quantity |
| STK-10 | Count while stock is sold after snapshot | Documented snapshot adjustment; no unexplained variance |
| STK-11 | Finalize the count twice, cancel and reopen where permitted | Idempotent posting and correct audit/dependency rules |
| STK-12 | Item-lot/opening/adjustment followed by stock-level/HUID/valuation reports | Quantity, fine, cost and identifiers reconcile by scope |

### Manufacturing and melting

| ID | Scenario | Expected proof |
| --- | --- | --- |
| MFG-01 | Karigar issue with wastage, ghat and less-weight fine policy | Correct issue fine and source-backed signs/legs |
| MFG-02 | Jobwork receipt with automatic and explicit labour | Blank/zero/override respected through UI/API/database |
| MFG-03 | Manufacturing issue/receive with components returned and broken | Component quantity/value balances and identities preserved |
| MFG-04 | Lot issue, partial receipt, second receipt and exhaustion | Accessible lot workflow, full source links and remaining balance |
| MFG-05 | Multiple lots with loss/chole/ghis/residual branches | Correct difference-weight/fine formula and explicit losses |
| MFG-06 | Order design issue → stages → partial production → tag | Complete order/WIP/tag lineage and remaining production |
| MFG-07 | Rework/reissue after rejected receipt | Correct history, permitted status transition and material balance |
| MFG-08 | Melting multiple inputs into several outputs | Gross/net/fine conservation and desktop loss/valuation treatment |
| MFG-09 | Melting edit/delete after output consumed | Measured restriction or complete dependency-aware correction |
| MFG-10 | WIP spans year boundary and karigar settlement | Opening/closing material and money reports reconcile |

### Loans, schemes and loyalty

| ID | Scenario | Expected proof |
| --- | --- | --- |
| SCH-01 | Pledge with several items, valuations and images | Principal/custody/identity and issue document match |
| SCH-02 | Blank interest versus explicit zero versus override | Correct automatic branch and editable result |
| SCH-03 | Monthly/daily/compound calculation over month/leap boundaries | Source-backed day count and rounding vectors |
| SCH-04 | Partial principal/interest receipts followed by release | Correct accrued amount, remaining balance and item custody |
| SCH-05 | Reverse receipt or attempt source deletion after repayment | Exact balances restored or dependency-protected refusal |
| SCH-06 | Scheme enrollment with nominee/demographics and multi-line receipts | Full member data and installment history |
| SCH-07 | UPI split, arrears, prepayment and configured commission/bonus | Actual identity rows and correct balances |
| SCH-08 | Maturity/redemption across two invoices and canceled invoice | Remaining entitlement restored exactly; no double redemption |
| SCH-09 | Branch transfer/refund/gold adjustment and loyalty points | Correct distinction of money, fine, member entitlement and points |
| SCH-10 | Two users redeem the final available entitlement | Atomic allocation and explicit conflict |

### Reports, devices and operations

| ID | Scenario | Expected proof |
| --- | --- | --- |
| RPT-01 | Render same voucher number in two branches/years | Exact intended header/details; no mixed report rows |
| RPT-02 | Open an unbound non-sales Crystal layout | Unsupported state, never a substituted sales dataset |
| RPT-03 | Ledger/outstanding detail/summary/opening/fine/interest variants | Dataset, totals, grouping and filters match desktop |
| RPT-04 | Blank, multiselect, unsupported and invalid filters on every route family | Correct selection or explicit rejection; no silent dropping |
| RPT-05 | GST sections and direct JSON/document endpoints with identical parameters | Same scoped dataset and current validated policy |
| RPT-06 | Stock/WIP/lot/order/approval/tour/scheme/loan reports after full journeys | All aggregates explained by underlying source/adjustment rows |
| RPT-07 | One-line and multi-page invoice with long Unicode text/images | Legible and complete PDF/physical print, repeated headings and totals |
| RPT-08 | Report drill-down and PDF/CSV/XLSX export under denied Print/View rights | Correct role enforcement and exact authorized content |
| RPT-09 | Tag barcode/HUID label scanned back into a sale | Printed identity corresponds to correct live tag instance |
| OPS-01 | Scale unstable/negative/tared reading, disconnect/reconnect | Correct unit/precision/stability and recoverable input state |
| OPS-02 | Scanner double scan, wrong focus, keyboard terminator | No duplicate item or lost input; clear operator action |
| OPS-03 | Camera upload fails, image transfer, reprint | Correct entity association and recoverable image state |
| OPS-04 | Provider accepts request but response times out | Status query/retry does not duplicate message/invoice/payment |
| OPS-05 | Missing/invalid credentials or provider rejection | Explicit failed/unavailable result; no fabricated success |
| OPS-06 | Renumber/transfer/refresh with incomplete dependency or locked year | Safe refusal/preview; no partial cross-table rewrite |
| OPS-07 | Migrate two companies/years with overlapping identifiers | Exact ownership and full data/image/reference reconciliation |
| OPS-08 | Missing migration table or truncated/corrupt backup | Fail with specific evidence; never skipped/pass |
| OPS-09 | Restore one company while another remains active | Non-target rows unchanged; restored sequences and journeys valid |
| OPS-10 | Server dies before commit versus after commit/before response | Atomic rollback or one committed idempotent result |
| OPS-11 | Expired session/network loss during a rich form | Draft recovery and unambiguous save outcome |
| OPS-12 | Load/soak with transactions, reports, exports and printing together | Agreed latency/error/resource limits; no balances drift |
| OPS-13 | Cutover rehearsal and rollback after accepted web transactions | No lost/duplicated business; explicit reconciliation/replay |
| OPS-14 | Candidate evidence for another SHA/tree or missing capture | Certification refuses even when ordinary tests pass |
| OPS-15 | Olocker policy generation from saved/reopened invoice, invalid-age invoice and repeated/failed request | Correct invoice/tag/metal/stone payload, desktop eligibility behaviour, authorized provider result and no duplicate policy |

### Additional closure scenarios from plan re-verification

| ID | Scenario | Expected proof |
| --- | --- | --- |
| SET-11 | Scanner omits a modifier-bearing checkbox, an assembly support file or a source-discovered mode | Inventory reconciliation fails; MS_PRINT's three checkbox declarations and eight support files are accounted for; no false complete denominator |
| SET-12 | Launch/login, switch business, exit/reopen and load retained preferences | Correct main form, context, defaults and authorized preference scope; no cross-user/company leakage |
| SET-13 | Combine consequential stock/tax/rounding/override settings in a rich transaction | Every decision branch and known coupled interaction matches independent vectors; unknown interactions remain open, not implicitly pairwise-certified |
| FLOW-07 | Continue real workflows using migrated historic and partially completed records | Permitted return/edit/settlement/tag consumption/order delivery/scheme redemption and reversal work; historic values preserved; subsequent reports reconcile |
| RPT-10 | Original/duplicate/triplicate, preview/print/cancel, selected template and reprint | MS_PRINT/caller semantics, copies, default focus, selected format and actual physical output agree; cancel causes no unintended action |
| OPS-16 | Disconnect internet, LAN, application server and device bridge separately | Declared service matrix is observed; required internet-independent posting/lookup/printing continues in its supported topology; local state is reconciled on recovery |
| OPS-17 | Keep an invoice open while browsing ledger/master and editing another document | Draft, selected row, context and source versions remain correct across forms/tabs; stale edit/session/context conflicts are explicit |
| OPS-18 | Remove or duplicate a required case/result; supply an empty extraction as success | Exact-set release validator fails even when all returned results say pass; failure reason identifies the missing/duplicate obligation |
| OPS-19 | Change a shared calculator, template, setting contract or schema after passing evidence | Dependency-linked evidence becomes stale; affected downstream cases must rerun on the candidate; old approval cannot survive an invalidating change |
| OPS-20 | Submit a subset certificate or waived missing capability as full-product parity | Full-product gate refuses; technical normalizations remain reviewed and narrowly scoped; deliberate business differences are disclosed |
| OPS-21 | Reconnect after locally accepted work with stale rate/permission/stock or repeated sync | For the selected service mode, accepted business is neither lost nor duplicated; conflicts/number ownership/reconciliation are tested; non-applicability needs architecture evidence |
| OPS-22 | Two tabs/users or restarted workers trigger the same scheduled desktop-derived action | Correct schedule/ownership and exactly one intended business effect, attributable retries/status, no unintended customer/provider sends |

## Exact-set completeness and certification contract

P00-05 and P14-02 must implement this contract. It is a specification for the release harness, not a claim that the existing validator already enforces it. The package's `validate_plan.py` checks documentation structure only.

1. Freeze a versioned product universe. Include assembly/source/dependency artifacts, every reachable form/menu/constructor mode, controls including the additional 916 declarations, semantic fields, helpers/actions/decisions, settings, table/SQL footprints, report modes/templates, integrations and operating service modes. Keep unreachable/duplicate candidates as reviewed dispositions with evidence. A missing extraction remains unresolved.
2. Give each applicable leaf requirement a stable ID, revision, owner, source/caller evidence, expected behaviour, work-item IDs, required layers, explicit test case IDs and dependency links. Record why a layer is inapplicable; for example, a purely local focus action need not fabricate a DB test, while its workflow still needs browser proof. Compute requirements from discovery, never backwards from available passing tests.
3. Before running, freeze expected case IDs and dimensions: form/mode, action/branch, fixture/configuration, role/scope, device/service topology, table/field extraction and output mode. Hash this manifest. Adding a discovered branch expands the universe and reopens its ancestors. Dropping an obligation requires a reviewed source/version change; a subset scope change changes the certificate label.
4. A result names its requirement revision, case ID, input/expected-output provenance, run ID, timestamps, actual desktop executable/hash, web tree/build digest, schema/configuration/template hashes, expected and observed rows/fields, pass/fail/error/skip status and protected raw-evidence references/hashes. Report captures additionally name dataset/mode, filter parameters and output artifacts. Distinguish observed desktop execution from historical SQL exports and synthetic differ tests.
5. Check set equality: expected cases equal unique returned cases for the manifest. Unexpected, duplicate, skipped, missing or invalidly empty results fail. Check expected extracted tables, keys and fields before value comparisons, including explicitly expected zero-row tables. A returned success flag without raw extractor completion and assertions cannot pass.
6. Require every applicable requirement at its terminal acceptance state, every package descendant closed, every necessary cross-module edge verified, every source item disposition reviewed and R00–R14 all passed. A module's discovery/start dependency is not a release dependency. Financial/stock/return/migration/report families cannot self-certify independently of the shared paths they consume.
7. Invalidate evidence when its requirement, source, code, schema, configuration, build or template dependencies change. Record the impact analysis; rerun relevant cases on the actual candidate. A shared-engine change may invalidate many families. Never retarget a capture to a new build by replacing only its SHA string.
8. Certify full-product parity only with zero missing/contained/unverified required capabilities and no hidden service restriction. Publish deliberate business differences separately. Approved technical ID/storage mappings may normalize representation only; they must preserve every business reference and effect. No monetary or stock discrepancy is excused by unrelated matching totals.

Define the completion calculation as sets, not percentages: every required leaf is verified and accepted; every required case has exactly one valid passing result; every needed operational gate passes; no required capability is excluded. The certificate records what was proven, against which desktop baseline, on which web candidate and configurations. It is never a prediction that future configurations and code changes must work.

## Desktop differential execution

Use a case manifest with executable/version, original database snapshot, sanitized fixture identity, settings, book/location/year, actions, expected business branch and all affected tables/reports. Replay the same actions independently in both applications. Collect before and after snapshots; compare the **change** plus the resulting state, because comparing only final headers can miss mutations to unrelated records.

Store raw captures in protected evidence storage, not the source repository or public reports. Record hashes, counts, provenance, operator/run identity, capture time and release build. Link sanitized summaries from work packages. Independently verify the extractor's ownership predicates against real schema and rejected/out-of-scope fixtures.

Compare key sets before field values. Report missing/extra cases, tables, rows and fields separately; compare full expected write footprints even where a family normally writes zero rows. An empty source result is valid only with explicit expected emptiness and successful extraction, not after a swallowed SQL/connection error.

Every excluded field needs an ID, column/table, reason, allowed normalization, affected cases and review. Technical surrogate keys may differ only when the contract explicitly maps them and business references still match. Do not exclude wrong business columns to reduce difference counts. Test the differ with a dropped row/table, swapped child parent, shifted date, money change, weight decimal, altered space-padded key and a difference inside an excluded-looking column.

The retained 70-case comparison is a starting regression set. Expand it to every family/transition/setting branch, including manufacturing, tags, returns, loans, reports, utility and cross-module workflows that the current case set does not demonstrate. Matching 70 cases would not certify all 204 source units.

## Performance and usability validation

Record current desktop task time and web baseline on the same representative operations. The following are **proposed initial test targets**, not measured capacity or an accepted contractual SLA. Confirm them against deployment hardware, network and shop needs during P00; do not weaken agreed targets after a failed test without recording the business decision.

| Operation | Proposed initial acceptance target |
| --- | --- |
| Local grid key/focus or recomputation | p95 at or below 100 ms for a typical document |
| Scoped master/tag lookup | p95 at or below 500 ms on the target business network |
| Typical invoice/receipt save | p95 at or below 2 seconds; clear progress for slower cases |
| Standard daily report | p95 at or below 3 seconds on the agreed dataset |
| Large export/report | Background/progress/cancel where needed; no apparent hang or browser lockup |
| Counter task throughput | No material regression against experienced desktop operators; document and address re-entry/keystroke cost |
| Correctness under load | Zero duplicate accepted business operations, lost updates, orphan rows or unexplained reconciliation drift |

Test realistic and upper-bound dataset sizes derived from actual shops, plus a growth multiple agreed in P00. Publish row volumes, concurrent sessions, transaction mix, report mix, device clients, connection pool size and hardware. Do not claim support for an invented user count. Include a hot-tag/hot-book contention test, long reports alongside sales, exports, queue backlog and database restart. Run a business-day soak and a recovery test at the agreed load.

Evaluate layouts with full data at common counter resolutions, keyboard-only operation and required local languages. A screen with 100 columns needs useful groups, fixed identifiers and discoverable extended fields; merely making the table horizontally scrollable is not acceptance.

## Migration and disaster-recovery acceptance

Required migration evidence includes every source table/file disposition, counts and key sets, transformed-value rules, orphan/duplicate exceptions, image hashes, source/target totals and an immutable source snapshot. Reconcile opening/closing money, gold/silver fine, physical stock, WIP, outstanding bills, pledges and scheme entitlements. The accountant must validate reports, not only the database engineer's row counts.

Two clean shadow loads must be repeatable. Restarted loads must produce the same target without duplicates. Changed-source data between snapshot and cutover needs an explicit delta/freeze procedure. Company/branch/year ownership must be enforced in extraction and target writes. Both missing mandatory data and unauthorized data from another scope are failures.

Choose RPO, RTO, backup retention and recovery locations with the business owner before production. This plan does not invent accepted values. Rehearse physical restoration and separately scoped logical restoration with databases, images, templates and required configuration. Verify backed-up sequences by creating new documents after restore; inspect conflicting IDs and missing dependencies. A restore result must carry actual checks, timestamps and release/environment identity.

Rollback before new web writes can switch back to the frozen desktop. Rollback after web business is accepted must preserve/replay/reconcile those accepted transactions. Define this procedure before rollout. Do not advertise “rollback by restoring yesterday's backup” as business-safe recovery.

## Commands and execution boundaries

Run from `web/` using the pinned workspace tools after provisioning an isolated test database. Obtain credentials from secure environment configuration; do not copy historical passwords from old handoffs into plans/logs.

```bash
pnpm typecheck
pnpm typecheck:tests
pnpm lint
pnpm format:check
pnpm test
pnpm build
pnpm test:browser
pnpm test:routes
node scripts/check-contracts.mjs
node scripts/check-kernel-conformance.mjs
node scripts/check-depth.mjs
node scripts/check-dead-cells.mjs
pnpm settings:parity
pnpm schema:readiness
pnpm type:parity
pnpm fresh:provision
node scripts/report-baselines.mjs
node scripts/check-completion-register.mjs --strict --release
pnpm g5:parity
pnpm parity:measure
```

These commands exist in the reviewed workspace. They are **not sufficient as the final gate set**: real browser persistence, complete field/variant/setting coverage, report comparisons, device tests, migration/UAT and operational results must be added. Build-dependent scripts must run against freshly built modules. `fresh:provision`, DB tests, replay, load and restore tools may create/drop/change test data; first inspect their target predicates and provision disposable targets. Do not run them against a business database merely because an old command uses that port.

Use `pnpm restore-drill`, `pnpm load:profile` and the cutover/parity integration scripts only in their documented isolated environments. `pnpm release:certify` requires the exact release SHA and an explicitly agreed evidence freshness window. The current local runner needs stronger clean-tree/build verification and the CI path needs correction before it can be treated as effective enforcement.

Do not use `ALLOW_SKIP_DB_TESTS=1`, `--passWithNoTests`, `continue-on-error`, missing-data skip tokens or rewritten baselines as evidence of release readiness. Their presence in a development workflow must remain clearly separated from certification. Never regenerate a baseline during the same operation that judges parity; create the proposed baseline as a separately reviewable artifact from independent evidence.

## Release gates

| Gate | Mandatory pass condition |
| --- | --- |
| R00 Scope | Full primary product, supplemental controls/support files and all reachable variants reconciled; no unresolved source/discovery item or silently excluded capability |
| R01 Contract | All required fields/actions/formulas/branches have reviewed contracts and evidence mappings; no unresolved draft debt |
| R02 Engineering | Fresh type/lint/test/build pass on the candidate; mandatory DB tests actually ran |
| R03 Interaction | Every supported real-browser form/mode and business journey passes with correct persisted results |
| R04 Desktop | All required independent desktop cases match; zero unexplained missing/extra rows or business value differences |
| R05 Reporting | Every required dataset/mode/layout has explicit binding, data comparison, print/export and role proof |
| R06 Settings | Every supported business setting changes the documented outcomes; defaults/invalid values covered |
| R07 Integrity | Scope, numbering, child identity, concurrency, retries, lifecycle and money/metal invariants pass |
| R08 Devices/providers | Supported device matrix and required provider flows pass with attributable real/sandbox evidence as appropriate |
| R09 Migration | Complete scoped manifest, two clean rehearsals, data/image/business-total reconciliation and successful continued operations on migrated history |
| R10 Recovery/operations | Explicit service/connectivity matrix; required internet-independent workflows, agreed load, RPO/RTO, restore, monitoring, failure/restart and rollback tests pass |
| R11 Scope restrictions | No required full-product capability excluded, contained, unavailable or replaced with necessary desktop/manual fallback; any subset certificate clearly cannot close full-product delivery |
| R12 Business acceptance | Required roles accept normal/exception journeys, outputs and throughput for representative business configurations |
| R13 Candidate provenance | Clean reviewed tree, exact build/schema/configuration/capture identity, immutable fresh evidence, exact expected-result-set equality, dependency invalidation and effective CI enforcement |
| R14 Transition | Timed cutover/rollback rehearsal, named responsibilities, source-of-truth transition and stabilization plan accepted |

All gates are conjunctive: a failure of one cannot be offset by a high percentage elsewhere. Owner decisions on supported editions, actual production activation, evidence freshness, recovery targets and provider/device setup are inputs to release preparation, not reasons to stop building the reviewable implementation plan now.

## Required handover package

Deliver the implemented application; current per-form/menu/report/setting registers; approved contracts; automated test commands/fixtures; desktop capture instructions; sanitized differential summaries; report samples and printer settings; migration/reconciliation records; backup/restore and incident procedures; role/setup documentation; supported business/browser/device matrix; current known exclusions; and signed business/release acceptance.

Keep the exact candidate reproducible. Another engineer should be able to provision a test business, execute a complete shop day, inspect the matching evidence and rehearse recovery without access to this conversation or unstated tribal knowledge.
