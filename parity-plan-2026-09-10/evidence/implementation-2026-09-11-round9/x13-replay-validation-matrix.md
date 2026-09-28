# X13 saved Incoming Return replay — proposed validation matrix

This matrix defines acceptance for the bounded Round9 saved-row calculation preview agreed in `x13-next-server-replay-contract.md`. It records source inspection and proposed tests, **not executed verification**. Checkpoint29 was frozen before implementation authorization. Earlier checkpoints, source fixtures and acceptance criteria remain unchanged.

The intended result is a trusted, ordered, read-only preview of twelve numeric LeaveCell actions on one eligible saved incoming row. It does not enable numeric persistence, source admission, tag allocation, component editing, voucher totals, refunds, ledger posting or stock changes. `canSaveNumeric` must remain false. X13/P05-03 and its remaining workflows stay open even if every proposed test passes.

## 1. Agreed request and response boundary

Both routes require explicit authenticated company/location/year/configured Return book query scope; tenant is server-owned. Use fresh owning `Sales / Sales Return` View rights for this simulation. POST must be explicitly classified as a read action. Edit rights do not expand the accepted journal.

- `GET /sales-returns/:vchNo/incoming-replay-state` observes and projects saved rows, returning an embedded configuration, composite `replayVersion`, informational `documentVersion` and `configurationVersion`, exact identities, untouched raw values, visible cells, eight caches, editor presentation, diagnostics and twelve field capabilities.
- `POST /sales-returns/:vchNo/incoming-replay` accepts only `{replayVersion,rowIdentity,events:[{fieldId,editorText}]}`. Both tokens/opaque identities are64 lowercase hexadecimal characters. The request contains0–100 ordered events, each editor text a string of at most10 characters. Those limits are the named API/editor profile, not a claimed general desktop data limit.
- Full field IDs are `x13.primary-incoming.c19`, `c20`, `c21`, `c23`, `c24`, `c25`, `c26`, `c27`, `c28`, `c36`, `c37`, `c38`. Captions, array indexes, source references and arbitrary numeric column IDs are not selectors.
- Each request rebuilds trusted state. A prior preview is not a new baseline. Empty events returns the loaded baseline without a row calculation. Nonempty events retain original editor text, order and repeated commits.
- Unsupported saved rows remain in GET with raw data, exact identity and reasons. They are not silently omitted. Preview success returns baseline and transient result, original journal dispositions and `aggregateRequired`; it never returns a saved flag or a final refundable amount.
- Proposed errors are400 malformed/unknown input,403 owning-rights denial,404 absent saved voucher,409 stale composite observation/identity mismatch,422 known unsupported action/profile/projection or calculator refusal. Preserve established central scope errors where they preempt service handling. Unexpected errors remain errors, not successful unsupported results.

The first record profile is exact five-digit saved keys, canonical primary incoming P/I, ordinary untagged N/empty, no active approval/employee issue state, no outgoing parent/component or BAR parent/component/DM state. Multiple ordinary incoming parents may exist; each preview selects one. A plain BAR header needs separate proven shape before acceptance. Require existing saved period/document eligibility as a conservative rollout restriction, independently of user Edit rights. Historical records outside it remain readable. No eligibility flag proves live stock availability.

## 2. Can saved rows be hydrated without invented formatting?

**Raw data can be read losslessly; universal exact desktop visible projection is not yet proven.** Current saved observations convert database scalars to text before JSON and preserve raw NULL, blank, exact decimal and timestamp values (`savedSaleReturn.ts`:150–167). The new display projection must remain separate from those raw values.

Desktop saved load explicitly formats cells. Retaining every SQL decimal string unchanged as a visible cell would also be a mismatch. The supported projection must use the pinned source mapping and a declared exact-decimal profile, with diagnostics for unresolved interoperation rather than implicit defaults.

All source lines in this table refer to primary `unified/src/csharp/DataCareNext/TR_SALE_RTN.cs`.

| Source | Required projection assertion |
| --- | --- |
| 10353–10359 | Full scoped incoming query, business SR ordering; display c0 is ordinal i+1, not saved SR_NO. Keep exact row identity separately. |
| 10360,10419–10420 | OLD_SRNO and TAG_SRNO use Format0 for display; VCH_SRNO uses text concatenation. These presentations cannot replace immutable raw identities. |
| 10361–10375 | Text fields have explicit source mappings. Description uses nonempty ITM_REMARK, otherwise master IT_NAME. The fallback must not overwrite raw NULL/blank. |
| 10376 | PCS uses `Conversions.ToString` directly. Fractional saved pieces must not be integer-rounded on hydration. Actual c9 LeaveCell Format0 at4631 is outside this journal. |
| 10377–10388 | Gross/other/net/ghat/fine use three decimals; ghat%, touch and west% use two. Cache45/46/47/48 copy their separately formatted visible source values. |
| 10390–10417 | Labour%, rate, amount, discount%, discount amount, other, MRP, tag values, item rate/amount, total, tax and net use two decimals. Cache58/66/49/67 match rate/labour%/item rate/tax respectively. |
| 10400–10404 | Blank TAG_LBR_CODE falls back to LBR_CODE only in the visible projection. |
| 10421–10438 | Hidden type/product/tag/approval/employee/image fields retain explicit source ownership; c57 is E; hallmark weights62–65 use three decimals. Do not borrow outgoing-grid meanings. |
| 10359–10438 | Saved loader does not seed c41/c42. The primary calculator does not read them. No invented labour-amount cache. |
| 10440–10447 | Load calls `MSG_PR_TOT_FILL`, not per-row `CommPassTotal_Pr`. Constructor and empty journal must not calculate rows or apply new-row defaults. |
| 10458–10465 | Incoming saved children are BAR_IDTL with original SR/ISR. SL_IDTL is outgoing; do not call an unrelated orphan SL_IDTL an accepted incoming child. |

Exactly eight caches are initialized from already projected cells:45←10,46←12,47←16,48←17,49←19,58←23,66←21,67←37. This agrees with `packages/core/src/saleReturnIncoming.ts`:10,98–133. Raw, visible, cache and editor values are separate objects. After replay starts, preserve cache chronology; never reseed all caches after each event.

Saved query10353 selects `A.*,B.IT_NAME,B.RATE_TYPE,B.IT_TYPE`, but A already declares RATE_TYPE/IT_TYPE (`01_Schema.sql`:591). `DC_Main.cs`:1232–1239 fills a fresh DataTable with SqlDataAdapter. Original duplicate-column name binding has not been executed or established. Do not claim master B wins. The first profile must require a unique exact master and agreement of relevant saved/master types, or return an unsupported reason. A duplicate master can duplicate source query rows and must not be collapsed by name or array position.

The remaining formatting limits are explicit: original DBNull/NULL conversion, locale/culture, binary Double-to-Format midpoint behavior and some unusually large/overprecision values are not proved by the mathematical core. Raw numeric NULL is not the same as a deliberately blank editor event. Do not implicitly turn it into zero through the core's blank-as-zero editor policy. Preserve the raw read and contain unsupported projection cases. Use independently pinned nonambiguous values first; do not generate expected strings by the same projection implementation under test.

Opening one of the twelve editors uses source two-decimal editor presentation (4538–4541,4561–4575), even when the current calculated visible percentage has three decimals (5115). Focus alone must not change visible values, caches or journal. `editorTextByField` must therefore be projected separately and recomputed for each preview.

## 3. Same observation and staleness

Existing public saved/configuration readers each own a RepeatableRead transaction (`savedSaleReturn.ts`:411–421; `saleReturnIncomingConfiguration.ts`:534–559). Calling them sequentially or in parallel is not a single snapshot. Extract transaction-local read helpers and compose document, configuration and projection masters under one caller-owned tenant transaction. Helpers must not nest `withTenant` or perform writes.

The saved metadata token (`savedSaleReturn.ts`:355–364) includes document tables/settings/books but omits the item-name query at263–269. It cannot alone authenticate replay hydration. `replayVersion` must additionally cover exact item-master raw/physical observations, duplicates/absence, full configured policy version, supported field/profile/mapping semantics and exact scope/voucher. Physical revisions belong in the observation token; immutable rowIdentity belongs to exact business identity, not ctid or visual ordinal.

POST compares the freshly rebuilt composite token before accepting any journal. A consistent snapshot is valid as of its database observation; it does not reserve state until the response arrives. A mutation after a RepeatableRead snapshot begins may legitimately be absent from that snapshot, but a later fresh request must detect it. Tests must not demand impossible latest-at-response behavior.

Surviving xmin/ctid detect same-value updates and present-row recreation. An initially absent override inserted and deleted between observations can return to the same token; no tombstone records that history. Preserve this documented limitation. A future numeric writer needs re-resolution with all source/stock effects inside its locked/Serializable write transaction and an agreed cross-writer protocol; this preview adds no such authority.

## 4. Validation matrix

The following are proposed test IDs, not current passing test names. Keep raw-before/after comparisons independent of the returned DTO wherever stated.

| ID | Fixture/action | Required result |
| --- | --- | --- |
| R01 | Omit each scope key; arrays/extra query keys; foreign company/location/year/book; wrong family/inactive/missing book | Established strict scope errors; no default fallback or business write. |
| R02 | Exact00017 versus17,000017,100000,zero,decimal,exponent,letters | Only named exact five-digit profile accepted. Current reader/writer numbering behavior unchanged. |
| R03 | Missing/null/array body, extra top/event keys, numeric editorText, invalid token/identity,101 events,11-character text |400 with precise diagnostic; no coercion/truncation. Empty journal succeeds only for eligible authoritative state. |
| R04 | Inject raw,cells,caches,policy,context,width,edition,tenant/source ref or calculateAfterCopy |400; no request-controlled calculation authority. |
| R05 | Unknown stable ID versus known unsupported c1/c9/c13/c22/c29/c31/c41/c45/hidden identity | Unknown400; known unsupported422. Valid visibility alone never makes an unsupported action admissible. |
| H01 | Parents SR17/42, OLD31/58, nonzero historical instance IDs, fractional pieces, raw NULL/blank text and six-digit clock | Exact identity/raw preserved; display ordinal1/2 independent; fractional PCS preserved; clock never parsed through millisecond Date serialization. |
| H02 | Source2dp/3dp values with independent expected strings, all eight distinct cache source values | Exact projection and cache map; c41/42 remain unseeded. No global Number/parseFloat roundtrip. |
| H03 | Persisted totals intentionally inconsistent with current derivable totals; empty journal | Baseline/preview equal; no constructor recalculation or saved-type default replacement. |
| H04 | Blank description/TgLCode with master/labour fallback | Visible fallback only; raw NULL/blank and document token unchanged. |
| H05 | Saved/master type agreement, disagreement, NULL ambiguity, missing and duplicate masters | Only proven agreement admitted; unsupported rows retained with diagnostic; no arbitrary first row or master overwrite. |
| H06 | Numeric NULL, malformed/huge/excess-precision values, midpoint/culture cases outside declared profile | Read retained; explicit projection containment; no silently fabricated zero or desktop-equivalence claim. |
| H07 | Visible calculated3dp labour% then editor focus | Server editor presentation2dp; opening does not change visible/caches/journal. |
| P01 | Tagged/unknown-tag, non-P/I, approval/employee issued, invalid/closed period, USER_UPDATE denied | Readable diagnostic, no enabled numeric field. These are named preview profile limits. |
| P02 | Outgoing SL_DETL/SL_IDTL, BAR parent/component, DM companions; ambiguous BAR header | No preview admission; all raw companions and sibling scopes unchanged. Do not credit child/stock parity. |
| A01 | Fresh own View with EditN versus own Update; unrelated-form grants only; rights revoked after login | View may simulate eligible record, unrelated rights denied, revoked rights effective. Every result says canSaveNumeric:false. |
| A02 | Legacy metadata PUT supplied numeric changes or preview output | Existing strict metadata rejection remains; preview cannot escape through Save or numeric mutation route. |
| E01 | Each of twelve allowed fields with positive authoritative width | One committed LeaveCell event, source2dp editor formatting, expected row result and original editor text retained. |
| E02 | Rate→amount versus amount→rate; repeated identical tax/rate commits | Preserve order and eight-cache transitions; do not replace journal with final values or deduplicate same text. |
| E03 | Discount0 retention, MRP/tax/non-MRP, manual total original editor comparison, K labour inverse | Independently pinned frozen-source outcomes; no generic Sales billTotals substitution. |
| E04 | Same stable ID after caption rename/duplicate caption; hidden width0; ambiguous width | Caption changes do not retarget field. Hidden/unresolved known field422; caller cannot make it visible. |
| E05 | Blank editor, strict signed decimal,hex/exponent/culture/trailing text,NaN/infinity | Follow explicitly declared plain-decimal editor policy; reject unsupported parsing. RawNULL is not this event. |
| E06 | Valid prefix followed by failing division/invalid event | Error includes event index/attempted text and recoverable last-valid transient state; failing event does not partially mutate it; no committed batch. |
| E07 | Calculation triggers aggregate callbacks in source5157–5158 | Return aggregateRequired; do not invent header net/refund/tender/report totals. |
| V01 | Same voucher in second book/year/branch/tenant; token/row from another scope | No cross-scope row resolution; conflicting identity/token refused. Read-only sentinel rows unchanged. |
| V02 | Header microsecond/hidden column, selected/sibling parent, companion change after GET |409 from whole observed document token, draft retained until explicit reload. |
| V03 | Relevant setting/column/Fine override/book/year change, same-value physical update or delete/recreate | Composite token changes and POST409; no automatic replay under new policy. |
| V04 | Item name/type/master physical change while metadata/config versions otherwise unchanged | Composite replay token changes; stale POST409. Master is an observed calculation/display input. |
| V05 | Initially absent override→insert→delete | Explicit current recurrence limitation recorded; no invented persistent revision or universal ABA claim. |
| V06 | Real DB interleaving between transaction-local reads | All document/config/master data belong to one RepeatableRead snapshot; no mixed old/new input. Next fresh request detects committed changes. |
| W01 | Every success/400/409/422 path | Complete raw business snapshots before/after identical; no sequence, stock, ledger, outstanding, source or tag write. |
| B01 | Actual browser load→focus→commit→preview→reload | Authoritative baseline, separate transient values and source labels; no submit to legacy save. Actual API/PG with0 HTTP mocks. |
| B02 | Scope/book/document A→B→A, failed configuration/state load, real delayed response | Immediate render/action barrier; stale response cannot repopulate old row or enable controls. |
| B03 | Independent HTTP config/document change; preview409; explicit reload and explicit retry | Local journal preserved on conflict, never auto-replayed; reload is deliberate and obtains new baseline/token. |

## 5. Fixtures and evidence requirements

Use isolated port55433 and unique disposable tenant. The positive fixture should have two configured Return books with the same exact00017 voucher, two incoming parents SR17/42 OLD31/58, all needed numeric baseline fields explicitly valid, untagged P/I and no unsupported companions. Preserve independent source year/book/voucher references without permitting a source event. Seed raw text NULL/blank and exact microsecond header time. Keep numeric-NULL and tagged/companion fixtures separate negative states so the positive case does not depend on an invented conversion.

Compare selected and sentinel scope snapshots from SQL text, including `SL_DATA`, `SL_DETL_RTN`, `SL_DETL`, `SL_IDTL`, `BAR_DATA`, `BAR_DETL`, `BAR_IDTL`, `MAIN_STOCK`, `AC_DATA`, `TAX_DATA`, `BILL_OS_DATA`, `ROJ_MEL_DATA`, `DM_DATA`, `REMARK_DATA`, plus relevant `TEMP_BOOK_DATA`, `SRNO_MAST`, tag reservation/counter tables and observed master/configuration rows. Include empty collections: an accidental insert must fail. Authentication/session maintenance may be excluded explicitly from the business snapshot; do not silently exclude posting or allocation effects.

Retain all35 frozen independent row vectors and8 width vectors, including currently disallowed F1/tag/PCS cases as core regression coverage. Endpoint coverage does not replace those tests. Reuse pinned expected strings for relevant cases and add independent projection/order vectors; do not calculate expected output by invoking the same reducer. Read-only interleavings should use actual database synchronization and a second connection, with bounded timeout/finally cleanup, not mocked HTTP responses.

A browser test should observe the real embedded configuration and successful/failed request envelope, preserve a draft after conflict, and show that no numeric save control exists. It cannot establish original EXE, printer, real customer data, full financial reconciliation or business acceptance. Record source-profile/interop limitations beside any passing engineering evidence.

## 6. Implementation gates and ownership

Root owns routes/policy/authenticated HTTP integration and combined regression. The replay service owner owns transaction-local observations, strict replay adapter and DB tests. The core owner owns saved projection and independent numeric/projection tests. UI owns a separate preview panel with no legacy writer integration. Final tests must cover the exact frozen files and preserve prior failing logs.

Before broadening this slice, resolve the original ADO duplicate-column binding and unsupported formatting cases; implement original F1 versus whole-import admission, tag/instance reservation, BAR child ownership, source availability, full row/header aggregates and all stock/finance/reversal effects. `12-execution-addendum.md`:548–582 and `02-implementation-plan.md` P05-03 remain the controlling broader acceptance requirements. This matrix does not change any completion percentage.
