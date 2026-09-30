# Shared implementation contracts

These requirements apply to every module in document 06 and every relevant leaf in `requirement-index.json`. They are mandatory implementation work, not a claim that current helpers already satisfy them. Paths below are repository-relative. Use the actual source version and symbol alongside line references because later edits move lines.

## A. Source and behavior contract per field/action

Use one record per meaningful behavior, preserving links to each raw scanner occurrence:

```json
{
  "id": "SEM-<form>-<mode>-<field-or-action>-<branch>",
  "parents": ["Pxx-xx", "Xxx"],
  "rawRequirementIds": [],
  "desktop": {"binaryHash": "required", "sourcePath": "required", "sourceHash": "required", "symbol": "required", "lines": [], "callers": []},
  "conditions": {"edition": [], "country": [], "book": [], "settings": [], "roles": [], "states": []},
  "field": {"kind": "input|derived|display|hidden|action", "type": "required", "unit": "required", "precision": "source-derived", "nullBlankZero": "required"},
  "behavior": {"default": "source-derived", "lookup": "source-derived", "triggerOrder": [], "formula": "source-derived", "validation": [], "errorFocus": "required"},
  "web": {"page": "required", "control": "required", "requestField": "required", "route": "required", "domainSymbol": "required", "reader": "required", "writes": []},
  "effects": {"ownedIdentities": [], "preservedValues": [], "sourceAllocations": [], "stock": [], "ledger": [], "tax": [], "reports": [], "external": []},
  "evidence": {"unit": [], "database": [], "api": [], "browser": [], "desktop": [], "operator": []},
  "state": {"implemented": false, "engineeringTested": false, "desktopMatched": false, "businessAccepted": false, "releaseCertified": false}
}
```

The illustrative `required` values above are schema guidance, not completed evidence. Fill every applicable property before closure. A hidden field generally belongs in trusted server state or preserved imported data; exposing it as an editable textbox is not parity. A readonly computed field still needs a display/readback contract. A duplicate or designer artifact needs a source/caller-based disposition; silently deleting its requirement is prohibited.

For each desktop `EnterCell`, `LeaveCell`, `KeyDown`, lookup selection, checkbox, timer, button and open/save event, classify its behavior: calculate, validate, fill, clear dependent data, query, persist, print, authorize or navigate. Follow helper calls and global mode values. Capture event order; equal final inputs do not necessarily imply equal cached/overridden totals.

## B. Identity, storage and scope

**Reference:** `DC_Main.cs`, `Ac_Ledr.cs`, `Ac_Stock.cs`, `Ac_Rojmel.cs`, `Ac_Tax.cs`; each form's Save/Delete/Select branch. **Web targets:** `web/packages/db/src/tenant.ts`, `scope.ts`; API `auth/businessScope.ts`, `vouchers/numbering.ts`, `vouchers/lifecycle.ts`, `posting/posting.ts`; Prisma schema/migrations/RLS.

1. Define table-specific keys, not one guessed voucher key for all tables. Include tenant/company/location/year/book/voucher and actual detail/serial/tag/hidden identity fields where they belong. Distinguish master scope, location-specific stock, shared company rows and multi-year references.
2. Specify every text identifier's width, padding, case/collation behavior and range. Preserve leading zeros, alphanumeric HUID and right-aligned source ledger suffixes; never round-trip them through JavaScript Number.
3. For every imported column record source SQL type/scale, target type, transformation and evidence. Explicitly distinguish SQL NULL, missing field, empty string, zero, string zero and formatted scale. Validate dates, timestamps, wall clocks and fiscal-year boundaries separately.
4. Separate source business IDs from technical surrogate IDs and concurrency tokens. Technical IDs may be added, but must not replace tag/voucher/source lineage in reports or business APIs.
5. Resolve voucher numbering from actual configured book tables inside the transaction. Derive desktop top-delete/reuse semantics, then distinguish internal sequence behavior from issued invoices, externally referenced IDs and permanent audit identity. Adjudicate any reuse policy explicitly; do not mechanically reuse an externally issued identity. The current `MAX(VCH_NO)+1` with scoped advisory lock is not a generic gap-free sequence specification. Test imports, full range, simultaneous create and independent scopes.
6. Maintain exact imported values on no-op open/save. Any normalization requires an explicit, reviewed conversion rule and historical comparison, especially for Float fields, timestamps and text-coded numbers.
7. Put tenant RLS in transaction-local context with a non-owner/non-bypass role. Also enforce company/location/year/book authorization on every read and write. Tenant isolation alone cannot stop wrong-company operations within a tenant.
8. Test list/search/help/report/export/image/device/integration paths as well as primary saves. An ID from another scope must not be accepted because a later join happens to find it.
9. Add missing schema support with forward migrations, indexes and constraints after surveying imported collisions. Rehearse from empty and representative old schemas; never rewrite a historical migration to hide upgrade failures.

**Acceptance:** at least two tenants, two companies in one tenant, two locations, two years, reused book/voucher numbers, duplicate tag labels with distinct serials, and unowned sentinel rows. Wrong-scope requests deny or return the defined non-disclosing response; all sentinel hashes remain unchanged. Use complete row snapshots rather than checking only count or sum.

## C. Numerical behavior and configuration precedence

**Reference:** form `Row_Cal`, `ROW_TOTAL`, `BILL_TOTAL`, rate/labour handlers, source `Math.Round`, `Strings.Format`, VB `Val`/conversion and caches; `MS_OPNCOMP.cs` settings load. **Web:** `core/src/money.ts`, `calc.ts`, `finePolicy.ts`, `orderLabour*.ts`, `saleReturn*.ts`; `modules/shared/{roundingPolicy,roundingPolicyLoader,fine,taxPolicy,labourDesktop,settingsBehavior,bookPolicy}.ts`.

1. Derive a policy per field and event: weight/fine/money precision, sign, units, rounding stage/mode and raw-versus-display value. Do not impose one two-decimal policy on all jewelry values.
2. Trace gross, net, stone/nonmetal subtraction, touch/purity, wastage/ghat, fine, rate, labour method/slab, discounts, other amounts, taxes, rounding/kasar, tender and outstanding in the exact source order.
3. Derive and freeze per-field/event precedence among imported document values, manual overrides, item/design/master settings, book/company settings and defaults. There is no assumed universal order. Determine which are snapshotted on document creation and which refresh on open/recalculation.
4. Separate mathematical decimal models from original .NET Double/format/culture behavior. Test actual runtime midpoint and representation cases; comments asserting universal `Strings.Format` behavior are not sufficient evidence.
5. Exercise positive/negative half cases, signed zero, 0.005/0.0005 boundaries, large/small finite values, blank/NULL/zero and division by zero. Choose exact expected values from source/runtime capture, not the implementation under test.
6. Preserve intermediate cache and manual override state. Replay an event sequence, including repeated/same-value/undo/backtrack edits; a final value-only test misses desktop cache semantics.
7. Avoid precision loss in API serialization and form state; use explicit decimal text/raw representations where needed. Each boundary conversion to Number must have a representability test or documented adaptation.
8. Bind calculations to current settings/master/document versions. A preview under one rate/precision configuration cannot be committed under another without recalculation or a defined conflict.
9. Compute authoritative values on the server, while providing matching client feedback. Show a clear correction/conflict if submitted values do not match the authoritative contract; do not silently overwrite manual values.
10. Derive statutory calculations from versioned jurisdiction/effective-date rules and qualified business review. If current law differs from the desktop, preserve historical documents and implement the approved change as an explicit policy version, not an unnoticed formula drift.

**Acceptance:** independent vectors for every formula/rounding branch, cross-layer equality at each event phase, matching desktop/database/report values, and deliberately mutated rounding/settings inputs making the relevant tests fail.

## D. Posting, edits, reversals and concurrent work

**Reference:** complete save/delete helper call graph and source table writes. **Web:** `posting/posting.ts`, `desktopColumnDefaults.ts`, shared Rojmel/stock helpers, each transaction builder, auth command wrappers and document version utilities.

1. Make an ownership graph for every command: header, details, sub-details, source reservations, tag/lot/custody, AC_DATA, Rojmel, MAIN_STOCK, TAX_DATA, bill allocations, images and audit. Include zero-valued rows the desktop intentionally creates. Follow post-commit work too: `TR_SALE.cs` commits at line 16136, calls `Ac_Tax.Vch_Remark` at 16137 and then performs further tax adjustment. Decide which effects belong in the web atomic database transaction and which require a durable outbox; preserve successful business outcomes without copying partial-write defects.
2. Record business row identity and full expected write footprint, not just balanced debit/credit totals. Balanced accounts can conceal the wrong book, party, fine quantity, source or tax row.
3. Use trusted reads and current permission/settings checks in the same transaction as mutation. Cover inserts into previously absent membership sets (phantoms), not only version checks on rows already read.
4. Treat pure planners' `qualified`/`ready` outputs and client observations as data, not authorization. Admission requires server-origin scope, session, versions, provider/edition state and complete observed membership.
5. Allocate number/serial and consume source balance under appropriate transaction/locks. Prove competing returns, tag use, loan release, points redemption and installment/maturity cannot over-consume available quantities.
6. An update must preserve unowned rows/fields and histories. Reverse-and-repost may be valid for a particular source lifecycle; it is not a universal edit strategy. Prove exact source behavior and reject changes with incompatible downstream references.
7. Define delete versus cancel versus reversal per source mode and external status. Preserve audit and dependent document relations. Do not delete a parent while leaving orphan children, stock, tax, IRN or allocations.
8. Define idempotency for business commands, not merely login/context selection. Bind durable command receipts to scope, intent/payload and document version. Decide recovery after a lost acknowledgment; do not blindly repeat a financially committed operation.
9. Return stable conflict reasons for stale document, stale scope, changed rights/configuration, exhausted source, period lock and external status. Retain the user's draft and offer reload/review; do not automatically merge financial fields.
10. Inject failures after each logical write boundary and before/after commit acknowledgment. Rollback must leave all owned and unowned business data unchanged, except intentionally recorded failed-attempt audit entries with separately defined ownership.

**Saved Return continuation:** reuse the existing incoming replay, header Float qualifier, N BAR matcher, effect storage context, seven-row effect planner and save guards. First qualify the narrow Other-amount replay profile against trusted database observations. In its documented ordinary qualified example, a c27 edit can affect line, header, two account rows, stock, two Rojmel and two tax rows; that nine-row example is not a universal journal recipe. Prove BAR/physical companions, old clocks, identities and guard predicates before adding an atomic numeric writer. Then add API/UI and full numeric/child/tender/edition variants. Independently audit and reconcile the older active `createSaleReturn`/legacy writer family; it is not automatically proven by the new profile.

## E. Complete operator experience

**Reference:** form designer geometry, grid columns and visibility settings; help forms, key handlers, focus/validation branches and captions. **Web:** `components/{Shell,VoucherChrome,VoucherList,GridKeyboard,ExtendedGrid,SubDetailGrid,LookupPicker,TenderPanel,PaymentForm,FormKeys,GlobalFormKeys}.tsx`, app routes, `lib/lineRecalc.ts` and per-form adapters.

1. Preserve module grouping, familiar business labels, book/mode identity and dense data entry. Give every required menu alias an explicit mode; a generic route that discards the mode is insufficient.
2. Define field order, column widths, visible/hidden/read-only conditions, default values, help/search columns, required indicators, validation placement, totals and side panels per form.
3. Keep one live control per field. Compact/full-grid modes must retain values, current row and focus; hidden fields must not clear values or become editable through a duplicate panel.
4. Implement children as explicit row-owned objects with stable identity. Two parents with different stone/component details must remain distinct after insert/delete/reorder/copy/import. Map accepted aliases deliberately and reject ambiguous fields.
5. Implement ordered lookups and dependent fills: selected item/design/party → source identity → permitted rates/labour/tax/counter → computed line and header totals. Changing a parent must clear or revalidate now-invalid child/source choices.
6. Reproduce supported keyboard actions and event triggers while accounting for browser-reserved shortcuts. Define a visible alternative where keys cannot be preserved. Test Enter/Tab/arrows at cell boundaries, current-row delete, help open/close, copy, save, escape and focus after error.
7. Test async lookup races, delayed scale/camera/image results and response ordering. Bind each to current row, document and page-context ticket; discard stale responses without overwriting newer edits.
8. Implement empty/loading/error/denied/partial/contained states honestly. A read-only lot or diagnostic preview must say what can be done. Do not render an apparently successful Save when nothing was committed.
9. Support long tables via measured rendering/pagination/virtualization without breaking keyboard navigation, totals or unsaved edits. Preserve search/filter/sort when reopening list items.
10. Define desktop-size layouts first for accounting/data-entry throughput, then usable laptop/tablet/mobile adaptations. Mobile need not expose a 100-column grid in one row; it must preserve access to every required operation and exact values within the supported device policy.
11. Implement accessible labels, error association, keyboard focus, contrast, zoom and dialog behavior. Validate supported scripts/fonts, money/weight alignment and print translations against the real business setup.
12. Measure trained operator completion time, keystrokes, error/recovery rates and print steps against desktop benchmark journeys. Agree acceptance thresholds before UAT; do not claim parity solely from screenshots.

**Visual evidence per mode:** desktop screenshot/recording, web capture at agreed viewport, annotated field/column mapping, keyboard walkthrough and operator acceptance. Similarity means operational layout and information hierarchy, not copying Windows chrome or eliminating necessary browser feedback.

## F. Settings and master behavior

1. For all 130 retained settings and newly found flags, record storage source (`CO_SET`, `CO_SET_NEW`, `COLUMN_SYS`, book/master/registration state as appropriate), type, scope, default and precedence.
2. Trace setting load into desktop global variables, then every caller/form branch, web consumer, field/route and persisted effect. A scanner finding a name is neither proof of an effect nor proof that the setting is inert.
3. Group by function: precision/tax/labour; stock/counter/tag; validation/credit/cash; manufacturing/order/one-form; UI/columns/theme; documents/devices/providers; edition/country. Assign a domain owner to every consumer.
4. Define refresh rules: what applies immediately, on new row, reopening a document, re-login or explicitly recalculating. Preserve historical values when settings change unless source requires recalculation.
5. Enforce input locks and important business restrictions on the server as well as UI; inspect actual per-field semantics rather than assuming every UI read-only bit is an authorization rule.
6. Master change/delete/import must verify dependents and scope. Provide preview/errors for invalid rows; choose atomic versus per-row import semantics explicitly and reconcile retry/duplicate behavior.
7. Verify two materially different business configurations, including nonstandard codes, disabled/enabled flags and missing/invalid settings. No implicit default may masquerade as desktop proof.

**Acceptance:** setting value → authoritative load → effective policy/version → observable UI or numerical/validation behavior → stored result/report. Capture both toggled branches and stale-draft behavior. Archive obsolete scanner labels after evidence-backed resolution without weakening the requirement.

## G. Reports, documents, images and outputs

**Reference:** actual `.rpt` identity, source `SetDataSource`, SQL/temporary staging, parameter/formula assignments, group/sort/layout and printer setup. **Web:** `modules/reports/`, `report-specs/`, `report-templates/` where present, `modules/documents/`, `modules/images/`, `packages/reports/`, report pages and render endpoints.

1. Give each logical report plus mode and template version its own requirement. Reconcile all 275 retained references against 255 binaries, absent assets, aliases, dynamic report names and NextDm variants.
2. Name an explicit dataset binder for header/detail/children/images/totals and exact scope/filters. No sale-header fallback for an unrelated account, stock, loan or manufacturing report.
3. Match joins, opening/closing cutoffs, canceled/deleted handling, group subtotals, sorting, zero suppression, tax grouping, fine/weight measures and party/outstanding semantics. Drilldown must preserve source scope and original identity.
4. Verify screen grid, CSV/XLSX, HTML/PDF and printed document from one consistent dataset. Handle report injection/escaping, text identifiers, locale and formula-like CSV values according to the approved export contract.
5. Bind historical photos and current document images to exact parent/child identities and revisions. Copy/replace/delete must preserve rights, imported association and stale-image conflicts; no cross-order/repair/tag reuse by loose code alone.
6. Rebuild Crystal formulas only from reviewed semantics. Mark unsupported formula/format/section features as unresolved; generic HTML totals do not replace them.
7. Test zero, one and multipage data, page headers/footers, carry totals, paper sizes, margins, duplicate/customer copies, logos, legal text, barcodes/QR and vernacular fonts.
8. Print on actual required A4/thermal/label devices. Scan output back to exact tag identity; verify label alignment and barcode quiet areas. PDF generation alone is not printer acceptance.
9. Enforce report-specific view/export/print rights and tenant/company/year/book scope, including direct URLs, downloads, stored outputs and background generation.
10. Save independent dataset diffs and layout/physical proof per report/mode; compare business values exactly and document any rendering tolerance separately. Never hide numerical differences behind image thresholds.

## H. Authentication, devices, providers and background jobs

1. Complete login/company/location/year/book selection and role-specific menu/action capabilities. Verify create/update/delete/view/print/export and sensitive rates or balances as required by source.
2. Extend session epoch/context guards across requests, long reports, image mutations, refresh, company switches and logout. Two browser tabs must not reuse a stale company's draft after the other tab changes context.
3. Separate login identity, business scope, edition entitlement, accounting/ledger mode and provider identity. A client flag or login success must not manufacture trusted posting mode/known closing.
4. Maintain durable background job ownership, status and idempotency for rates, exports, messages, backups and provider calls. Timers in desktop startup need explicit server/client owners and startup/restart behavior.
5. Device contract: supported connection, unit/precision, calibration/stability, operator selection, disconnected/permission-denied state, delayed response and fallback. Reuse `ScaleCapture`, `CameraCapture` and capability probes where applicable; verify actual hardware.
6. Provider contract: requested/pending/submitted/acknowledged/rejected/cancel-pending/canceled/reconciled states as required; retries only after checking ambiguous external outcomes. Snapshot sent payload and accepted document version, redact credentials, and authorize each action.
7. Confirm phone/recipient/template/media and business scope for messaging. Use dry-run/test recipients in verification; no customer communication is implied by completing the implementation plan.
8. Log actor, scope, document, action, correlation/command ID, before/after revisions and external acknowledgment. Operators must be able to investigate a wrong output or failed save without reading application logs directly.

## I. Migration, continuity and operation

1. Create a table-by-table ownership/conversion manifest reconciling the 146-table retained real-schema snapshot, the 162-table inferred catalog, live schema additions, references, configuration, images, sequences, audit/history and companion data. Explicitly resolve the seven inferred candidates `AREA_MAST`, `IMAGE_DATA`, `LBR_ISU_IDTL`, `LOAN_ISU_DATA`, `LOAN_REC_DATA`, `OP_DETL` and `TAG_MAST`; absence from one database snapshot does not prove an unused source branch. Record exclusions only for proven duplicate/temporary artifacts without required business continuation.
2. Extract from a fixed snapshot, with explicit source/company/location/year boundaries and checksums. Missing table, failed query or incomplete slice fails the run; it never becomes an empty success.
3. Load into scoped staging/shadow targets with resumable checkpoints and idempotent transforms; validate before atomic promotion. Never replace all of a tenant while intending a single company's migration.
4. Reconcile row identities and fields, opening/closing money/fine/stock, source allocations, outstanding, tax, custody, images, provider documents and report outputs. A matching ledger total does not prove complete migration.
5. Continue imported workflows: old order delivery, partial return, outstanding allocation, loan interest/repayment, scheme maturity, tag movement, production receipt and year-end. This is a required migration outcome, not optional UAT.
6. Rehearse twice with representative histories and a separate unrelated tenant/company/year. Exercise interrupted extraction/load/restart, duplicate run, rejected data and rollback before and after controlled promotion.
7. Define supported service topology and continuity requirements with the owner. For the requested web product, propose online authoritative posting plus recoverable drafts; determine whether loss of internet must still permit business posting. If yes, design and prove a branch-local service/queue and conflicts before claiming replacement of offline capability.
8. Never make offline financial writes implicit. Record unsent/sent/unknown/committed states, reconcile acknowledgment and prevent duplicate effects after reconnection. Visible connection status is insufficient if the operator cannot safely recover the transaction.
9. Separate physical database disaster recovery from logical company restore. Prove isolation, integrity, sequence restoration, media, readiness and an authorized controlled drill before lifting each relevant containment rule.
10. Define deployment configuration, secrets management, TLS, database role separation, schema migration, indexes, backup retention, monitoring/alerts, job supervision and incident/rollback runbooks. Use agreed RPO/RTO and throughput SLOs, then measure; do not invent a passed target.
11. Plan compatibility during upgrade: active browser drafts, schema/app version skew, running jobs, external callbacks and print/template versioning. A deployment that invalidates every pending draft needs explicit operator handling.
12. Rehearse production-like cutover with stop/write boundary, final delta, reconciliation, smoke tests, rollback trigger and clear decision authority. Retain desktop access/archives until accepted stabilization and legal/business retention decisions are complete.
