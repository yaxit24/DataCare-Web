# Round 4 Sales Order API lifecycle and source replay contract

This is the bounded X11/X14 Sales API implementation record. It supplements [the editor contract](sales-order-lifecycle-contract.md), [Design selection review](x11-sales-integration-review.md), and [round 4 progress](../../20-implementation-progress-round4.md). It does not close Sales Order, X11, X14, the original execution cards, or full desktop/business acceptance.

The final coordinated API run after the source-blank correction passed **219 files / 1,713 tests, zero skips** in431.78 seconds. All997 before-run API/core/database inputs, including binary fixtures, remained unchanged. The earlier219/1,711 run (193.47 seconds,995 inputs) remains retained as pre-fix evidence and is not relabelled. Final production build passed7 tasks, lint/types passed10 tasks, web passed21 files/114 tests, and the unchanged core passed8 files/106 tests. Serial strict API test types completed with exit0 (parent tool completion; the successful tsc log is silent). The combined real-browser run passed ten journeys with zero mocked requests; the legacy mocked smoke also passed and is recorded separately. These are bounded engineering checks, not desktop/business acceptance. The focused results below retain their actual run stages.

## Authoritative source and decisions

All desktop line references in this file use `unified/src/csharp/DataCareNext/TR_SALE_ORD.cs` in the extracted project. Alternate decompilations are not interchangeable line references.

| Contract | Desktop evidence | Implemented boundary |
| --- | --- | --- |
| Book, company, branch, year and voucher define the saved order | Full-scope reads8527; save9054/9104; next visible number9058; recent list11711 | Every ordinary Sales operation requires selected company/location/year/book. Active configured book and Sales family are verified; an absent or wrong book never falls back to SOR. |
| Header date and clock are distinct saved inputs | Reopen8541; header clock9162; parent9308; ledger/rojmel9466/9511/9540 | Explicit create date; complete calendar validation before JavaScript timestamp conversion. Omitted saved date/clock on edit retain the saved values. PostgreSQL six-digit clock precision survives without a JavaScript Date round trip. |
| Add refreshes clock; later dates fail; earlier dates use a distinct confirmed exception |9005–9028 | Web preserves explicit supported clock input, an intentional difference from desktop add-time overwrite. Selected YEAR_MAST dates define ordinary valid dates. After-close dates fail400; before-opening returns422 `prior-year-confirmation-unavailable`. No guessed confirmation or fiscal-lock bypass is implemented. |
| F1 copies visible values without running totals |7341–7364; explicit clear7366–7370 | Resolve exact Design source and version in the writer transaction; copy only source-defined fields. Existing saved parents are identified by the locked server snapshot, not client A/E flags. |
| F1 does not replace current child rows or current gross weight | Same F1 block7341–7364 | Existing parent components and gross weight remain independent order input. Selecting a Design does not import its components. |
| Save uses cached fine and monetary cells |9217–9233 and9244–9250 | F1-only selection preserves cached fine, metal, net and total. Later numeric/labour events have ordered effects and may calculate. |
| Hidden labour caches differ from currently displayed labour values |6732–6874; later conditional refresh7108–7136 | Separate cache84/85/86; amount→percentage→rate pipeline. The rate branch changes visible amount but does not simply reset all caches. Later tax/MRP branches are not asserted covered by this helper. |
| Identity and protected downstream state remain meaningful on reopen | Parent/tag load8678 onward; save9205–9215; delete guards9690 and audit9700 | Surviving parent SR_NO and component ISR_NO are retained, including gaps. Unsupported tagged removals and settlement/allocation/consumed transitions remain refused. |

## HTTP contract for the ordinary Sales form

The authenticated tenant is server-derived. Requests carry selected `coCode`, `lcCode`, `coYear`, `coBook`; routing owns Sales family. Use the form's configured book even when it is not SOR. Configuration and master selection load under a consistent transaction snapshot.

| Endpoint | Input/behavior |
| --- | --- |
| `GET /sales-orders/configuration` | Complete scope. Returns labour includes-ghat/rate-decimal settings plus `fiscalOpeningDate`, `fiscalClosingDate`, `priorYearConfirmationSupported:false`. Ambiguous/missing year configuration is a validation error. |
| `GET /sales-orders` | Complete scope; lists only that configured Sales book. |
| `GET /sales-orders/:vchNo` | Complete scope; full input-shaped header, all saved parent/component identities, read-only cached amounts, current version and edit diagnostics. Reads under RepeatableRead. |
| `POST /sales-orders` | Explicit valid voucher date; complete parent array; explicit `components:[]` when there are no children. No inferred child from a parent in this modern HTTP path. |
| `PUT /sales-orders/:vchNo` | Same complete body plus the loaded64-hex `expectedVersion`. Locks/checks current saved state before replacement. Missing/malformed version400; stale version409; no partial rewrite. |
| `DELETE /sales-orders/:vchNo` | Complete scope and loaded `expectedVersion`; owning delete right and saved downstream-state guards. Deletes only that exact document. |
| `GET /sales-orders/designs` | Complete scope, current `itCode`, optional search/offset/limit. Product and exact saved Design identities are server-resolved. |
| `GET /sales-orders/design-image` | Complete scope, current `itCode`, source `prCode/bookName/srNo/oldSrNo/version`. Returns direct absent/present image union after validating source; arbitrary image keys are not accepted. |
| `GET /sales/order-confirmation` | Existing full-scope Sales-family report adapter. Uses saved headers/parents/children and ORD_IMG_PRINT from the report snapshot. OrderBill/OrdVchImg child bands do not print DM_NAME; browser evidence must assert their actual source fields. |
| Saved order image endpoints | Existing Sales-owned read/update/delete rights and parent identity. Round4 image revision/token behavior is documented separately. |

The established desktop role mapping is retained: a permitted View role may create, while update/delete require their own rights. Print does not create permission to read or change saved photographs. Tour rights do not imply Sales rights.

The route adapter sets internal `requireDesignSelection:true` unconditionally. Caller JSON cannot turn it off. A new or changed non-N linked Design image identity therefore requires a resolved source event; unchanged saved imported identity remains readable/editable without a synthetic selection. Direct trusted legacy service callers can omit this internal policy and still use earlier input shapes. That legacy/import boundary is deliberately documented as remaining work, not counted as modern source-selection acceptance.

## Ordered event protocol

Each parent optionally carries `orderEdits` (maximum512 committed events). A supplied journal cannot be mixed with `labourEdits` or `labourAction`. Journals may contain no Design event; the new Sales editor uses them for actual numeric/labour chronology. Tour continues its established separate protocol.

- `{kind:'design',source:{prCode,bookName,srNo,oldSrNo,version}}`: resolve the saved source with the item current at this event. Source rows stay locked against concurrent change until save commits. Never trust client default values as source data.
- `{kind:'clearDesign'}`: clear Design number and set image identity N; leave size, karigar, components and cached calculations according to the narrow source clear behavior.
- `{kind:'field',field,value}`: finite number for `pcs`, `grossWt`, `netWt`, `ghtWt`, `rate`, `touch`, `westPct`, `labourPct`, `labourRate`, `labourAmount`, `otherAmount`; string for `itCode`, `designNo`, `itmSize`, `karigarName`, `designImageId`, `labourType`. Numeric calculation triggers are pcs/gross/net/ghat/rate/touch/west/otherAmount. Linked-image changes cannot be forged as arbitrary field commits.
- `{kind:'labour',edit}`: existing action/value/basis contract, validated before the source amount→percentage→rate cache pipeline.

Baseline is the locked persisted parent or a known new-row zero/text/N state. New-row F1 copies eligible nonzero Touch/West/Labour percentage, or rate only when source percentage is zero and rate is nonzero, each at the source precision. Existing-row F1 changes only Design/size/karigar/image. Neither branch calculates merely because F1 occurred. The replay retains both the last calculation basis and hidden labour caches separately from visible defaults. A later actual blur may calculate even when the displayed copied number did not change.

At the end, submitted writable fields must match replay. For source-selected Design/Size/Karigar/Image text, the final server replay supplies the actual persisted value, even if an older JSON serializer omitted a blank cell. Source NULL/empty text copies as an explicit empty string; it cannot fall back to an older linked image or the new-row N sentinel. Subsequent manual text events already changed the final replay state. An explicit clear changes Design/Image only; untouched imported NULL cells with no source event remain NULL. Client cached totals cannot override the replay. Plain precision refusal from the pure Design helper is converted to domain validation400; unexpected database failures remain errors. Numeric values that cannot safely enter the current JavaScript-number calculation are refused explicitly rather than silently rounded.

The web deliberately preserves the current selection when cancelling the picker. Deeper MS_HELP tracing showed desktop Escape may return a blank selection and clear Design/Image. See `x11-help-cancel-source-trace.json`. Explicit clear is available; cancellation preservation requires desktop/business acceptance and is not marked identical.

## Complete saved state and explicit edit intent

`orderLifecyclePolicy.ts` defines only mapped input fields and their database columns. GET returns true null for nullable mapped input fields, and exact decimal strings where a JavaScript number would change the value. It also exposes read-only saved fine/metal/net/total values for correct editor hydration.

During replacement the writer merges its locked raw header, parent and component snapshots with the fields it owns. Client raw database rows never own tenant/scope, ledger, downstream state or hidden identity. Saved business columns not represented by the current editor are retained. Stable parent/child numbers identify siblings; display position is not their identity.

`dirtyFields` distinguishes an explicit empty string or zero commit from an untouched imported null. Supported field names are validated; header/parent/child dirty lists are separate. Journal events also establish ownership of the cells they actually change. Unchanged saved nulls are restored after the common insertion defaults; new rows retain normal defaults. The restoration excludes explicit dirty cells, so intentional null→zero or null→blank changes are not undone.

Saved exact large decimal strings are preserved if unchanged. A changed supported value is accepted; an unrepresentable new/change is rejected. Decimal comparisons use exact Decimal equality, not Number equality. No unchanged imported large value is treated as a nearby but distinct number.

VCH_TIME is projected as SQL text with microseconds. Exact clock updates apply to the header, saved parents and order ledger timestamp in the same transaction. An unchanged legacy ENTRY_TIME null remains null; ordinary no-op edits do not manufacture a new historical clock. Earlier migrations cannot recover previously lost source time; reimport remains an operational requirement.

## Verification already captured

| Run | Actual result | Evidence |
| --- | --- | --- |
| Sales service, Tour hydration, route policy |3 files/72 tests passed, no skips; Sales suite then had6 tests | `sales-service-first.txt` |
| Expanded Sales service plus existing Sales-family lifecycle |2 files/37 tests passed, no skips;8 new Sales +29 existing family tests | `sales-service-legacy-verified.txt` |
| API source TypeScript | Passed before and after the blank-source correction | `sales-service-types.txt`, `sales-source-blank-types.txt` |
| Corrected source-blank writer + Tour hydration + Sales HTTP |3 files/37 tests passed, no skips;10 Sales +14 Tour +13 HTTP | `sales-source-blank-verified.txt` |
| Sales HTTP with complete-shape rejection |1 file/13 tests passed, no skips | `sales-http-complete-shape-verified.txt` |
| First whole API suite, before blank-source correction |219 files/1,711 tests passed, no skips;995 pinned inputs unchanged at completion | `api-full.txt`, `api-input-snapshot.json` |
| Final whole API suite after blank-source correction |219 files/1,713 tests passed, no skips;997 pinned inputs unchanged | `api-full-complete.txt`, `api-input-snapshot-complete.json`, `api-input-verification-complete.json` |

The initial eight service cases compare complete business JSON rows across SL_ORD_DATA, SL_ORD_DETL, SL_ORD_IDTL, AC_DATA and ROJ_MEL_DATA, excluding only physical row_id and tenant_id from equality. Fixtures contain same voucher numbers in books S91/S92; parent7; independent children3/13; a six-digit clock; a100 Cash advance; null MOBILE/ENTRY_TIME/BAG_WT/TAG_GEN/KR_RATE; hidden LOT_NO/child TAG_NO; and exact999999999999999.99 MRP.

They prove unchanged business snapshots, explicit parent/header/one-child changes without sibling or ledger drift, date validation without allocation/write, F1-only cached totals followed by a real numeric trigger, stale source and forged values with no writes, explicit journal zero against saved null, unsafe source precision validation, and refusal of tagged parent removal/deletion. Two later source-text cases exercise both NULL and empty-string master cells. Each covers new-row F1, existing-row F1 replacing an older image/size/karigar, an unchanged imported all-NULL text snapshot, and explicit clear changing only Design/Image. The first run reached the existing positive-amount guard because the new fixture lacked a priced basis; it is retained in `sales-source-blank-first.txt`. The fixture now uses ordered Touch100→Net1→Rate100 before F1.

The existing Tour14 tests and Sales-family29 tests protect shared writer behavior; only the older Sales-family fixture gained explicit YEAR_MAST configuration.

The thirteen HTTP cases add actual authenticated own-form rights, two configured non-SOR books, complete scope, malformed dates and fiscal boundaries, version conflicts, full parent/component arrays, wrong family/unknown book rejection, forced source-selection policy and no-write comparisons after failures. Earlier HTTP failures were test mistakes (assuming every fixture table has row_id; assuming View forbids create). Their logs remain retained. A setup-only wrapper invocation is retained but not credited as a test run.

## Final browser and static verification

The actual combined result is `web/test-results/parity-real-stack-round4-blank-source/result.json`; its log is `browser-blank-source.txt`. Sales lifecycle records12 checks and Design selection11 checks, including actual POST/PUT, source NULL image→persisted empty string, later manual edits, immutable cached fields/components and stale conflicts. The independent screenshot review found the configured book, exact six-digit saved clock, source readonly amount styling and main row readable. Image absence and hidden component preservation are established by DOM/API assertions, not by claiming off-screen panels were visually inspected. Native desktop observation was attempted but the CUA startup failed (`desktop-ui-observation-attempt.json`); no executable desktop observations are credited.

Final31 scanner tests pass; the stricter dead-cell gate remains red at33 of708 without confirmed paths. Kernel127/108 and depth102/96 also remain red. See `sales-static-gate-diagnosis.md` and the source-backed `x13-sale-return-33-next-contract.md` / `.json`. The latter separates primary incoming return rows from outgoing exchange rows, header/source-owned values and the UAE RATE_WITH schema gap. It does not mark any of the33 fields complete.

## Required next descendants

1. Recover and implement the desktop prior-year confirmation/lock exception with explicit audit and acceptance; keep the current422 diagnostic until supported. Verify before/inside/after fiscal boundaries and locked dates without inventing a blanket bypass.
2. Complete later total/MRP/tax/manual-override/tag branches using independently sourced ordered event vectors, not a final-state-only formula. Current bounded cache tests are not evidence for the later tax branch.
3. Implement and reconcile bank/card/UPI splits, old-metal receipts, scheme/rate-cut/order allocations, partial delivery, conversion, cancellation/refund and stock/tag transitions as distinct full write sets, with rollback and cross-scope tests. Existing service names/routes do not make all those workflows accepted.
4. Close the trusted direct-service/import compatibility boundary: document permitted callers, full component semantics, exact selected master identities, unsupported historical values and reimport requirements before treating import as equivalent to the ordinary form.
5. Verify historical high-precision money and hidden identity across every business calculation, including existing Sales/Sales Quotation retained identity on replacement. Removing invalid UI controls is not proof that all hidden identity edit paths are lossless.
6. Compare reports, keyboard/cancel behavior, representative settings and real customer workflows against executable desktop output, then obtain independent business/production acceptance. No acceptance percentage follows from test or inventory counts.
