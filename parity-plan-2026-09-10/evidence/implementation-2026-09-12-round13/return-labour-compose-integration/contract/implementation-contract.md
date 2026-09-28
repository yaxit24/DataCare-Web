# Atomic resolved labour copy and incoming calculation — prospective contract

This is preparation for one pure internal operation. It changes no HTTP route, replay allowlist, client state, master reader, session or numeric writer. It must not be described as financial or Windows runtime acceptance. No implementation of this composition was inspected or executed before the accompanying literal vectors were authored.

## Source order and operation boundary

Primary `TR_SALE_RTN.cs` enters these branches under Enter key handling at4137–4143. The c13 branch4248–4319 and c29 branch4322–4380 resolve LBR_MAST for the current company. Blank input exits the case; absent lookup opens help and returns before copying/calculating (4250–4277;4324–4351). A resolved c13 copy clears23/24/21/14/17/28 only when the code changed, sets13, fills29 only when29 is exactly blank, applies the first-two-character category mapping, then unconditionally calls CommPassTotal_Pr at4319. A resolved c29 copy clears31/32/30/35 only on changed code, sets29, applies its narrower destination mapping, then unconditionally calls CommPassTotal_Pr at4380. Tag categories04/05 assign no amount destination but still call the calculator. Same-code resolution also still calculates.

The already implemented copy preserves raw row values, all eight comparison caches and the old row journal. Preserving caches is material: a freshly copied fixed labour amount may subsequently be overwritten when the old labour-rate cache disagrees with the now-cleared rate. Do not reseed caches from the copied visible cells or skip a same-code/no-destination operation.

CommPassTotal_Pr4866–5156 performs the existing ordered row arithmetic, then calls MSG_PR_TOT_FILL5157 and BILL_TOTAL5158 in that order. MSG_PR_TOT_FILL5162–5202 folds the 14 existing columns in source grid order with formatting after every addition. UpDown skips this fold and preserves totals/counters; it does not skip the separately invoked BILL_TOTAL. Bill calculation16381–16458 consumes retained or newly folded incoming c38 and the explicitly supplied outgoing total24, rounds the sides separately, compares numeric caches, handles manual tax and tenders, then closing. A→B→A labour changes must run the bill callback at each prefix: a restored final row value does not restore a superseded manual bill tax.

This semantic operation ends at those callbacks. It does not simulate subsequent Windows focus/navigation/LeaveCell callbacks, choose a help result, admit a sold tag, resolve outgoing children, infer configured widths from CSS, or produce save payloads.

## Proposed exact pure boundary

Suggested export `composeSaleReturnIncomingLabour(input: unknown)` with an exact plain-data envelope:

```ts
{
  state: SaleReturnIncomingAggregateState;
  scope: SaleReturnIncomingLabourScope;
  rowIdentity: string;
  field: 13 | 29;
  editorText: string;
  expectedObservationVersion: string;
  observation: SaleReturnIncomingLabourObservation;
  rowPolicy: SaleReturnIncomingPolicy;
  context: SaleReturnIncomingAggregateContext;
}
```

The operation finds the selected row by its opaque identity within the complete ordered aggregate rows; neither visual ordinal nor a separately supplied row snapshot may substitute. Keep the existing contiguous ordinal/c0 invariant and unique identities. Require detached bounded plain data without getters, custom prototypes, cycles, sparse arrays, nonfinite values or unknown top-level keys. Do not freeze caller-owned mutable objects. A malformed envelope may return unsupported with no valid state; when the original state itself is valid, unsupported selection/policy/observation must return a detached frozen equivalent of that complete original state. Rejection diagnostics must not publish a usable partially copied state. Exact diagnostic DTO names are an implementation detail; the fixture pins semantic origin and existing dependency diagnostic code, not invented message prose.

Suggested success `{status:'applied',state,visiblePatch,nextEvent,observation,aggregateApplied,billApplied}`. Lookup refusal remains distinguishable as `status:'lookup-required'`; other refusals use `status:'rejected'` (or input `unsupported`), preserving a diagnostic with origin copy/calculation/input and exact attempted code/field/row identity when safely representable. A caller retry is a new explicit operation; no internal auto-retry/replay.

Implementation sequence:

1. Detach/validate the entire pre-copy aggregate observation and command; retain it as the only rollback result. Preserve raw header, every raw row, visible cells, caches, grid order/identities, totals/counters, all54 matrix strings, bill caches/rounded amounts/closing, outgoing total and both prior journals.
2. Invoke the existing copy helper with the selected row from that observation, the scoped complete master observation and matching expected observation version. On absent/ambiguous/unsupported/stale copy, return the pre-copy observation and no new journal event.
3. Replace only that row in a private temporary aggregate with the copied row, preserving ordinal and all prior aggregate/row journals. Do not use the aggregate constructor here: it would reset the aggregate journal.
4. Invoke the existing aggregate reducer exactly once with the copy-produced calculateAfterCopy event, trusted row policy and phase context. This performs row→fold→bill and appends one selected-row journal event and one aggregate journal event on success. Copy itself appends neither.
5. If this downstream call rejects or unexpectedly skips, return the original pre-copy aggregate state, not the aggregate reducer's temporary-input state. Any caught boundary/precision failure must also preserve that original valid state. A skip is not successful labour copy acceptance in this resolved callback profile. Publish the composed state only after every required stage succeeds.

## Explicit profile and authority limits

Reuse the existing resolved-ascii-code2-decimal-copy-v1 copy profile exactly: nonblank unpadded printable ASCII code of at most2 characters, complete matching tenant/company observation, exact64hex version, one unambiguous exact master row, known first-two-character category01–07 and qualified finite decimal value. Category04/05 on tag still requires a valid value as the copy helper's conservative containment rule even though the source assigns no amount. Case/space collisions, duplicates, NULL/noncanonical category or value, blank/help/cancel and unresolved master absence remain unavailable or lookup-required; do not silently pick/fill.

Version equality proves internal observation coherence only. The pure function cannot authenticate a caller, mint trusted master/configuration/document authority, prove DB freshness or authorize a client-supplied hash. A future trusted server coordinator must obtain and bind master, configuration, document and phase observations itself. This operation must never be exposed by merely accepting client maps/hashes/policies.

Use existing local100-digit decimal arithmetic, input/result bounds and rounding semantics. Format-style decimal presentation and explicit Math.Round half-even are separate operations. No Number/Date conversion, reformatting of untouched cells, raw NULL→blank rewrite, current-date inference or hidden cache reseeding. The fixture is an exact-decimal mathematical profile, not measured VB Double/Format/collation equivalence.

The initial integration target should retain unavailable closing with explicit reason unless a separate trusted opening authority exists. Synthetic resolved/outgoing phase inputs in pure tests do not establish that such an authority exists at runtime. Saved-header projection, saved-open phases, original-source admission and outgoing recalculation retain their own contracts. The operation never upgrades current preview permissions or writes numeric values.

## Required independent verification

Run the literal full-state cases before adding broad cases. Compare complete returned state, all63+8 selected row cells, other rows, raw values, 71 totals and counters,9×6 bill matrix, caches and journal prefixes; sparse selected-value assertions alone are insufficient. Rejected copy, row, sibling fold and bill cases must compare the entire pre-copy state and both journals. Mutating returned data must not mutate inputs or later observations. A malformed command with a valid prior state must not erase the retained prior state. Runtime-only getter/cycle/custom-prototype checks are separate prospective cases, not JSON fixture execution credit. Confirm no new route/core reducer implementation changes or writer use as part of this pure slice.

Fixture version strings are inert matching sentinels, not cryptographically derived master observations or runtime authorization. Existing journal entries are explicit preservation inputs, not a claim that this pure boundary has authenticated their entire historical replay. The companion author script expands only literal strings and shape copies; it does not invoke Decimal, a calculator, core code or application code.
