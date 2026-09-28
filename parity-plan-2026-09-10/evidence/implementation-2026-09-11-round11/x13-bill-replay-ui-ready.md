# X13 totals and bill preview UI: ready for integration

Status: implemented frontend boundary and local verification, 2026-09-11. Root-owned API, complete build, real browser and end-to-end business write-set verification are not credited by this scoped note. It adds a nonpersisting preview prerequisite; numeric Return editing/saving, source admission, outgoing exchange, refund/tender/ledger posting and desktop business acceptance remain open.

## Behavior and ownership

The existing saved Return editor now offers separate **Calculation preview** and **Totals and bill preview** openers. One synchronous owner binds preview kind to the selected saved document context and hydration generation. A second preview cannot acquire that owner; a stale close from another kind/document cannot release it. Only the active preview component remains mounted. Either preview freezes metadata editing and save/load/book actions; ordinary pending saved reads still allow a configured-book switch and late-read discard. Reload, closing the saved document, scope change and authoritative metadata rehydration invalidate previous ownership.

The new panel owns its own request generation. Scope A→B→A, close→reopen, a newer request and unmount reject old success/error/finally/focus work. Closing restores its opener on a guarded next animation frame. Metadata requests never contain preview cells, totals, matrix, policies, tokens or journals.

Each explicit button click or Enter creates one event; focus, Tab, field selection and row selection create none. Repeated equal text remains an event. Every POST replays the complete ordered journal from the observed saved baseline. Requests contain only outer v2 replayVersion, exact selected opaque rowIdentity and events[{fieldId,editorText}]. The embedded v1 token is used only to validate its own observation and never substitutes for the outer token. The same twelve stable field IDs are supported, with printable ASCII decimal text or ordinary blank/spaces, maximum ten characters and maximum100 events. Full loaded editor text remains visible even when longer than ten characters; unchanged oversized submission fails locally and an explicit shorter replacement is allowed. Nothing truncates a saved decimal.

Malformed observations/results, stale409, lost rights401/403, missing404, HTTP5xx and network/uncertain failures retain the entry and require deliberate reload. Recoverable400/422 retains both the draft and last successful prefix. Partial recovery payloads are not promoted into successful displayed phases. There is no automatic retry/replay, and no numeric save action.

## Trusted response boundary

The helper checks exact saved scope, voucher, document/configuration versions, independent64-character outer token, embedded v1 raw/identity/configuration projection and raw saved header equality. It validates the header-projection semantic version, complete71-string incoming totals, all9×6 string matrix cells, four string cache/rounded properties, the tax resolver's ready/unsupported shape/provenance and unavailable closing reason. No numeric values are coerced through Number. Known nonready phases remain null and display Unavailable. A ready embedded row never overrides a false outer canPreviewBill capability.

Successful results must retain the exact previously observed loaded/opened phases and selected-row baseline, contain complete row preview maps, echo the exact original journal in order (applied/skipped), and retain false closing/numeric-save capabilities. No client CSS, caption, mode, cache or policy becomes an input to calculation.

## Operator comparison

Exact saved header values are shown separately, preserving NULL as Not stored and empty text as (blank). The fourteen incoming totals use source columns9,10,11,12,15,18,20,24,27,42,28,36,38,35 and server configuration captions. On opening and After N changes are separate observations. The bill matrix compares Saved amounts, On opening and After N changes under Payment/Received columns, retains unassigned blank net cells in the loaded phase, and identifies the full incoming/outgoing raw amounts separately from settlement totals. Source tax/account labels remain display-only, with diagnostic reasons shown when unresolved. Closing balance is explicitly unavailable with a reason; it is never fabricated as zero or assigned a financial color. Tables contain their own horizontal overflow, with no modal or nested form.

Source semantics are inherited from the frozen Round10 trusted-observation contract and its qualification addendum: primary TR_SALE_RTN.cs10112–10169 (saved header),15917–15929 (labels),5162–5202 (incoming aggregate),16381–16458 (bill),10503–10504 (final opened callback). This browser adapter performs no source arithmetic. The underlying exact-decimal profile is not measured Windows Double/locale/ActiveX execution. The unavailable ledger mode also leaves full MsAcBal metal/amount helper acceptance unresolved, as the source addendum requires.

## Local verification

- `bill-ui-focused-ready.txt`: three files,129 tests passed, zero skips;66 new bill-boundary/ownership tests plus unchanged32 v1 replay and31 saved metadata tests.
- `bill-ui-types-ready.txt`: full web runtime/test TypeScript configuration, exit0.
- `bill-ui-lint-ready.txt`: focused configured React Hooks ESLint check, exit0; this is the repository's deliberately narrow hooks rule set.
- `bill-ui-test-types-corrected.txt`: explicit strict, isolatedModules new-test compiler with JSX/import support, exit0.
- `bill-ui-ready-inputs.json` / `bill-ui-ready-input-verification.json`: nine owned/dependent inputs captured before final focused checks and unchanged afterward.

Historical first `bill-ui-types-first.txt` records a TypeScript predicate that narrowed a validated object to identity fields only; retaining Record<string,unknown> in the predicate fixed this typing error without changing runtime semantics. `bill-ui-test-types-first.txt` is an exploratory compiler run beyond the web tsconfig: it additionally enabled noUncheckedIndexedAccess and omitted JSX. It found own expected-event indexing (fixed with an explicit presence guard), existing api.ts:73 and unchanged v1 salesReturnReplay.ts:357 diagnostics, and the missing JSX command option. The standard strict web compiler and corrected explicit strict test compiler passed; this note does not claim repository-wide noUncheckedIndexedAccess coverage or alteration of the old v1 sources.

## Browser integration selectors

All new selectors have prefix `sale-return-bill-replay`:

| Suffix | Meaning |
| --- | --- |
| open / close / reload | Open totals and bill preview; Discard preview and close; Reload saved return and discard preview |
| row / field / entry / commit | Opaque row identity selector; stable field selector; exact draft editor; explicit Preview totals after field change |
| discard-entry / events / status | Discard uncommitted field only; ordered list; accepted event count |
| error / conflict / readonly / empty / closing | Recoverable status and blocked capabilities |
| saved-{RAW_HEADER_KEY} | Exact saved header amount |
| total-{sourceColumn}-opened / total-{sourceColumn}-preview | Fourteen aggregate comparison cells |
| matrix-{loaded\|opened\|preview}-{row1..8}-{col3\|4} | Payment/Received comparison cells |
| value-{sourceColumn} | Selected item field row with label, baseline and preview cells |

Expected browser verification remains root-owned: actual GET/POST outer tokens, zero saved business writes, prefix-sensitive bill arithmetic, repeated/blank events, local invalid/oversized correction, mutually exclusive v1/v2 controls, metadata freeze, deliberate stale reload, delayed state/result/close and A→B→A, unsupported and view-only states, focus return, actual visual overflow/readability. This scoped local pass is not a substitute for those checks.
