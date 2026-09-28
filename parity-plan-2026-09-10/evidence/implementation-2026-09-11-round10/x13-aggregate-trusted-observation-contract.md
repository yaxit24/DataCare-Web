# X13 next incoming aggregate API: trusted observation contract

Status: prospective Round10 integration contract from static source inspection. **No aggregate API, database test, browser journey, original-runtime execution, numeric save or desktop acceptance is implemented or credited by this note.** The existing Round9 row-only API and its frozen evidence remain unchanged. The proposed next API consumes the independently implemented pure aggregate prerequisite only after the observations below are available.

The smallest complete integration is a saved, incoming-only, twelve-field, nonpersisting preview. It observes the whole saved incoming grid, even when the journal edits one row. It separates exact saved values, formatted load state, simulated saved-open state, and subsequent event results. Customer closing balance is a separate capability: unavailable ledger mode or clock must produce an unavailable balance, never an assumed zero.

## 1. Source and current implementation boundary

Primary references in this note are to `unified/src/csharp/DataCareNext/` unless a web or schema path is shown. These are readable decompiled sources, not measured Windows/ActiveX behavior. The Round9 `x13-next-aggregate-requirements.md`, independent review and runtime-probe note remain the source contract and explicit numerical limitations. Source hashes are pinned at the end.

| Input or phase | Exact source | Consequence for the next integration |
| --- | --- | --- |
| Incoming saved query and load | `TR_SALE_RTN.cs:10353–10438` | All saved rows ordered by database `SR_NO`; immutable SR/OLD/instance keys differ from displayed ordinal. Load visible cells and eight comparison caches without calling the incoming calculator. |
| Running incoming aggregate | `TR_SALE_RTN.cs:5162–5202` | Source visits every grid row and formats after each addition. The server cannot filter out an unsupported row and claim a complete document aggregate. |
| Callback order | `TR_SALE_RTN.cs:5157–5158` | Each actual successful row calculation is followed by incoming aggregation and then bill calculation, before the next event. |
| Clear versus saved-open | `TR_SALE_RTN.cs:9979–9987`, `10101–10148`, `10447`, `10491–10504` | Saved tax caches and tenders must be hydrated before saved-open simulation. This differs from a new-form zero state. |
| Bill calculation | `TR_SALE_RTN.cs:16381–16458` | Independently rounded legs, conditional bill tax, stateful caches, post-outstanding inactive-side clearing and closing from opening balance. |
| Outgoing saved callback | `TR_SALE_RTN.cs:10497–10501`, `15328–15405`, `7196` | Outgoing rows can recalculate during saved open. Continue to refuse them; saved header `NET_AMT` is not a substitute for the missing outgoing grid workflow. |
| Ledger opening and helper closing | `DC_Main.cs:1463–1489`; call `TR_SALE_RTN.cs:10198`, values `10226–10227` | Same company/location/year/customer across all books; exact mode; second-precision timestamp; opening `<` and helper closing `<=`. |
| Tax rounding | `MS_OPNCOMP.cs:657–671`, `717`, `741–743`, `929–931`, `1297–1303`; `DC_Main.cs:2088–2102` | Company-open policy has ordered raw conversion, fallback and final override. |
| Live tax setting | `UT_SETTING.cs:4930–4936`; `UT_SETTING_MAIN.cs:8821–8834` | The process can temporarily have policy different from a fresh company-open calculation. Name the web profile; do not claim arbitrary live-history parity. |
| Ledger mode ownership | `MS_OPNCOMP.cs:1459–1475`; `MDI_FORM.cs:12726–12790` | Mode is mutable desktop session state, distinct from selected-book posting data type. |

Current web boundaries to retain:

- `saleReturnIncomingReplay.ts:251–310` composes saved document, configuration and item-master observations; its token includes the row projection version. `:409–441` uses one `RepeatableRead` transaction. `:463–535` replays one row and returns `aggregateRequired`; it does not calculate the bill or inspect the customer's cross-book ledger. Do not silently change that v1 meaning.
- `savedSaleReturn.ts:94–109`, `161–172`, `226–267` observes fourteen document-scoped tables, raw business values and physical row revision/locator/identity. Its `AC_DATA` subset is the selected voucher, not the customer opening balance. The transaction-local reader at `:419–425` is reusable inside a larger snapshot.
- `saleReturnIncomingConfiguration.ts:212–225`, `277–284`, `489–515`, `535–550` exposes six qualified raw setting keys and projects `TAX_ROF` out of its relevant raw setting set. Its row rounding policy is not yet a bill-tax policy. A physical CO_SET update can already invalidate its token, but that does not resolve or expose tax precision.
- `auth/jwt.ts:8–24` and `auth/session.ts:7–18` establish company/location/year/session and rights, but contain no authoritative ledger-data-mode property. The existing report staging `dataType` argument is a report input, not a session-mode authority source.

## 2. Proposed contract and rollout capabilities

Use a new contract identifier, proposed `x13-saved-incoming-aggregate-replay-v2`, and profile `saved-primary-incoming-money-aggregate-preview-v2`. Prefer distinct routes such as `GET /sales-returns/:vchNo/incoming-aggregate-state` and `POST /sales-returns/:vchNo/incoming-aggregate`. Final route naming belongs to integration; these are proposed names, not declared routes. Preserve both Round9 row-only routes.

Reuse the same strict request authority boundary:

- Mandatory explicit selected `coCode`, `lcCode`, `coYear`, `coBook` in query; tenant/session from authenticated server context. Exact five-digit nonzero saved voucher key for this first profile. Reject unknown, duplicate/array query values and cross-session scope before observing data.
- Fresh own `Sales / Sales Return` View permission for both read operations. The POST is a read simulation, not a writer or Edit grant. Continue to enforce existing saved period/configuration/profile restrictions as the named rollout profile. These restrictions are not evidence that desktop View is a write right.
- POST body remains exactly `{replayVersion,rowIdentity,events:[{fieldId,editorText}]}`. At most100 ordered events, original text at most10 characters, the same twelve canonical source field IDs and existing hidden/unsupported distinction. Keep unknown fields400; known unsupported events422; stale composite observation409. No client rows, policy, source values, totals, tax, mode, clock, opening, caches, phase, book aliases or flags.
- The initial journal edits one selected saved row, while all other rows remain trusted baselines participating in every aggregate. Multi-row journals, tax/tender/header events, F1 selection, admission, delete and numeric persistence require separate contracts.
- `canSaveNumeric:false` is unconditional. Existing metadata save receives none of this preview's rows, header totals or tokens.

Suggested response shape, with decimal data serialized as text:

```ts
{
  contractVersion, profile, scope, voucherNo,
  replayVersion, documentVersion, configurationVersion,
  aggregateObservationVersion,
  rows: [/* exact raw, immutable identity, projected cells/caches, diagnostics */],
  savedHeader: { raw, displayLabels, diagnostics },
  taxPolicy: { state: 'resolved' | 'unavailable', rawSettings, value, diagnostics },
  ledgerContext: {
    state: 'resolved' | 'unavailable', mode, accountCode,
    voucherDateRaw, voucherTimeRaw, cutoffLocal, cutoffPolicy,
    opening, savedHelperClosing, diagnostics
  },
  phases: {
    loaded: /* projected header/matrix/caches; no bill callback */,
    opened: /* incoming aggregate then final saved-open bill callback */,
    preview: /* POST last completed event prefix, otherwise absent */
  },
  capabilities: {
    canInspectSaved, canAggregate, canPreviewBill, canPreviewClosing,
    canReplayEvents, canSaveNumeric: false
  },
  diagnostics
}
```

`value`, a phase, opening or closing must be null/unavailable when unresolved, with a precise reason. Never encode unavailable as `0`, `''`, a guessed default or an apparently complete object. Raw saved rows remain readable when projection or aggregate calculation is unsupported. A mathematically projected row may remain displayed under a document-level refusal, as in v1. A single unsupported incoming projection blocks the whole-grid aggregate; it must not disappear from the sum.

For an empty saved header, retain readable header/related rows and `rows:[]`, with no event authority. Do not turn this into a synthetic saved incoming row. Source empty-grid clear leaves a blank editable row, which is a distinct grid-shape case; the first saved API profile contains that case rather than claiming an empty-array fold is the complete desktop empty-form path.

`canPreviewBill` requires all row projections, aggregate profile, bill-header projection and tax policy. `canPreviewClosing` additionally requires authoritative ledger context. Unknown opening is allowed to coexist with known incoming totals, tax, tenders and outstanding; closing alone stays unavailable. If a required aggregate or bill stage fails, the event is refused as a whole and the response retains the last complete row/aggregate/bill prefix. Do not accept a partially changed row while its mandatory callback failed.

## 3. Authoritative company-open tax policy

### Raw identities and precedence

Fetch all selected-company physical `CO_SET` rows in the same transaction. Require exactly one canonical company row; distinguish missing row, duplicate rows and SQL NULL in an existing row. There is no source company00 fallback in `MS_OPNCOMP:657`. Its `Rows.Count >= 0` followed by `Rows[0]` is not a valid missing-setting default to emulate.

Add qualified public raw aliases under a versioned extension:

| Qualified raw alias | Physical field | Meaning |
| --- | --- | --- |
| `CO_SET.TAX_ROF` | Exact `TAX_ROF` column | Bill tax precision before source company-open conversion. |
| `CO_SET.ALL_ROF_REMOVE` | Exact `ALL_ROF_REMOVE` column | Existing flag, reused with the same raw observation. |

These are output/provenance aliases. Do not accept client aliases such as `taxRound`, `MsTaxRof`, lowercase keys or alternate tables as sources. Keep `CO_SET.LBR_ROF` separate; labour precision cannot stand in for tax precision. Retain raw NULL versus blank and every physical duplicate; do not mutate the observation while resolving it.

Resolve in source order:

1. `DC_Main.Fnv` maps DBNull, null and exactly empty text to zero, otherwise calls `Val(Value.ToString())`. This **does** establish SQL NULL→0 for TAX_ROF's Fnv path. It does not establish NULL→0 for all saved header fields, which take different boxed-object `Val` paths.
2. Apply source `Math.Round(a)` then Int32 conversion (`MS_OPNCOMP:671`), before either later fallback. The current Prisma `CO_SET.TAX_ROF` is `Int?` at1426, so canonical observed integers and NULL form a bounded implementable database profile. Pure imported text tests may distinguish blank, fractional, prefix and overflow values, but must not invent unmeasured VB output for them.
3. If the resulting integer is greater than5, replace it with2 (`:741–743`). Thus6 and the maximum admitted Int32 become2; do not clamp them to5.
4. ALL_ROF_REMOVE is read at717; source exactly blank becomesN at929–931. ExactY finally forces tax precision2 at1297–1303. Preserve the existing configuration service's explicit refusal for noncanonical/NULL flags rather than silently treating every non-Y value as N. A valid negative integer withY ends2; without that override a negative precision is unsupported for the later Math.Round call.
5. A value failing the preceding numeric/Int32 conversion cannot be rescued by `>5` or finalY. Do not let a permissive JavaScript conversion accept NaN, Infinity, whitespace, exponential or numeric-prefix text accidentally. Any future broadening needs the runtime probe results already specified in Round9.

Expose both raw value and named effective policy, e.g. `company-open-tax-policy-v1`, effective precision0..5, conversion/fallback/override provenance and any diagnostic. The three literal whole-unit rounding sites in BILL_TOTAL remain0 regardless of this precision or flag. Only the tax amount step consumes MsTaxRof.

### Live-history limitation

`UT_SETTING:4933–4935` updates TAX_ROF and directly sets the live MsTaxRof using checked rounded conversion; it does not rerun the company-open `>5` and ALL_ROF_REMOVE steps. `UT_SETTING_MAIN:8821–8834` sets the flag, forces values whenY and exits the application. A fresh read of persisted settings cannot reconstruct every intermediate live process history. The proposed service deliberately resolves a fresh company-open policy per observation. Do not label that policy as captured original desktop session state.

### Tax identity and saved amounts

Saved open loads TAX_CODE, TAX_PRC and TAX_AMT from the header. Only the display name is queried by selected company + exact code + `TAX_MAST.SR_NO=0` (`TR_SALE_RTN:10130–10154`). Observe matching physical tax-master rows for versioned labels and alias/duplicate diagnostics, but do not replace the saved percentage or manual tax amount with the current master rate.

Missing display tax name does not by itself make an otherwise explicit saved percentage/amount numerically unknowable. Return a name diagnostic. Blank code with a saved amount remains raw; do not apply new-book default code10. That default belongs to new-form `FormBookType == T` at10017–10032. The proposed profile has no tax picker and grants no authority to edit bill tax merely because the pure function consumes it.

## 4. Saved bill hydration and source phases

Start a detached cleared9-by6 matrix, then project only the source's assigned cells. Preserve blank cells separately from zero strings. Keep raw business header fields in a separate immutable object. Header amounts sent by the client are never input to this projection.

| Saved raw field | Loaded control/cell | Projection and cache ownership |
| --- | --- | --- |
| `NET_AMT` | `nAcDrAmt` | Source F2 of boxed Val, full outgoing saved amount; do not use it as a fabricated outgoing row. |
| `RTN_NET_AMT` | `nAcCrAmt` and `OldNetAmt` | F2; seed cache from the full saved incoming amount, not net difference. |
| `TAX_CODE` | bill[2,5] | Raw text concatenation; preserve leading zeros. No Val identity conversion in this read. |
| `TAX_PRC` | bill[2,2] and `OldTaxPrc` | F2 and numeric comparison cache. |
| `TAX_AMT` | bill[2,3] | F2; retain manual value until a source cache comparison changes. |
| `TOT_AMT`, `CHQ_AMT`, `CARD_AMT`, `CASH_AMT` | received c4 rows3,4,5,6 | F2 from their saved values. |
| `KASAR_AMT`, `BILL_OS` | received c4 rows7,8 | Explicit Fnv then Val/F2; NULL→0 is source-known for these fields. |
| `RTN_TOT_AMT`, `RTN_CHQ_AMT`, `RTN_CARD_AMT`, `RTN_CASH_AMT` | payment c3 rows3,4,5,6 | F2 from their saved values. |
| `RTN_KASAR_AMT`, `RTN_BILL_OS` | payment c3 rows7,8 | Explicit Fnv then Val/F2; retain raw separately. |
| `BANK_AC`, `CHQ_NO`, `CARD_AC` | bill[4,5], bill[4,2], bill[5,5] | Saved text; current company account names fill row4/5 c1 only. No tender-account substitution. |

References: header projection10112–10169; labels15917–15929; persistence12623,12707–12719,12789–12821. The names `RTN_TOT_AMT` and `RTN_BILL_OS` describe payment-side settlement, not an additional incoming item sum. Row c38, bill payment net and payment total are distinct quantities.

`SL_DATA.RTN_*` seven fields are historical FLOAT (`unified/database/schema/01_Schema.sql:2867–2868`; current Prisma5702–5708). Current header NET/TAX/TOT are Decimal while BILL_OS is Float. Serialize raw SQL text before the JSON driver sees numbers. A plain-decimal mathematical projection may be supported without rewriting raw values, but it cannot recover already lost binary precision. Unsupported exponent/nonfinite/header numeric NULL cases must be contained per field; do not format every missing imported amount to0. The four explicit Fnv fields above are distinguishable from ordinary boxed Val fields. Nonfinite intermediate values and excessive precision/resource ranges need recoverable diagnostics, not silent clipping.

Proposed phases:

1. **Saved:** exact header, all parent/companion rows, raw timestamp and immutable identities; no calculation. Existing saved metadata/no-event semantics remain intact.
2. **Loaded:** independently project every incoming row and its eight caches; project the bill matrix and two tax caches exactly as above. `EditOPen=true` represents the source load phase. Retain a snapshot of this state for comparison.
3. **Opened:** for the supported nonempty incoming-only profile, fold the saved incoming rows in SQL SR order; do not run the per-row calculator merely on load. With no outgoing rows, MSG_CLEAR at10234 leaves the source blank grid, the unconditional MSG_TOT_FILL at10309 folds its blank row, and its c24 is formatted0.00 (6051–6080). This is zero at the bill numeric boundary. Mark this as an explicit incoming-only source profile, not a substitute for a nonzero outgoing document. Set `EditOPen=false` and run the explicit final BILL_TOTAL call at10503–10504. Opening simulation may replace tax/totals even without a row edit; raw saved values stay unchanged.
4. **Event preview:** start from the opened state. Apply each permitted actual row event to the selected row, then run incoming aggregation and bill calculation before the next event. Keep every other row's trusted state and caches. Same-value events can change caches. A text-only or skipped event does not gain a synthetic calculation callback. Initial API fixes UpDown=false and stable selected ordinal; navigation/suppression phases remain out of scope.
5. **Failure:** return last complete prefix plus attempted field/text/event index and all affected state; a downstream aggregate/bill error rolls back that event's transient row change too. No database rows change in any phase.

The aggregate fold has exactly14 numeric columns:9 uses0 decimals;10/11/12/15/18/42 use3;20/24/27/28/36/38/35 use2, in source assignment order. It clears other totals, preserves total c0, labels c5, resets TotCrFine/PrOthAmtLess. Hidden42 remains the trusted saved projection's blank value; aggregation does not authorize inventing its storage field or a client edit. Do not sum once then round, use SQL SUM for grid totals, filter by column width, or recompute row c38 from c36 and an assumed tax formula.

Numerical cache comparisons must compare values, so `200` and `200.00`, or an established blank and zero, are not new changes merely due to string spelling. Conversely saved F2 caches and literal cache resets remain observable text and should not be normalized away in evidence.

## 5. Customer/account and ledger observation

### Identity and clock

The opening account key is exact saved `SL_DATA.AC_CODE` under selected company/location/year. Saved AC_NAME is retained separately. Do not use party name, current account-group defaults, LD_CODE, BANK_AC, a client-selected account or company00 as the customer key. Nonblank canonical identity is required for the initial balance profile. Observe aliases/collisions conservatively rather than merging them into a guessed account.

Saved customer opening does not reread a current account rate or opening-balance master field: `MsAcBal` reads AC_DATA. Account master names used for bank/card labels at10157–10169 are company-scoped and display-only. Observe relevant physical account masters if labels are returned; ambiguous or missing labels can be unavailable without altering a known saved account key or ledger arithmetic.

Construct the cutoff from **the date part of saved VCH_DATE plus the HH:mm:ss clock part of saved VCH_TIME** (`TR_SALE_RTN:10104–10106`, `10198`). The helper formats it to seconds again. Preserve complete raw VCH_TIME including six fractional digits independently; do not round fractional seconds, convert through UTC or use the date portion of VCH_TIME instead of VCH_DATE. A valid historical VCH_TIME whose date differs from VCH_DATE is not silently repaired: the source composition uses the latter's date and the former's clock. A missing/invalid required date or clock yields unavailable ledger context.

Use timestamp without time zone for this source local-wall-clock profile. A cutoff like `2024-08-02 12:00:00.900000` is **not** the source cutoff: saved clock formatting yields `2024-08-02 12:00:00`. Compare in PostgreSQL using timestamp semantics, not lexicographic text or JavaScript Date millisecond conversion. Current Prisma AC_DATA.ENTRY_TIME is Timestamp6 at33. Migration `20260911020000_ledger_entry_timestamp` preserves earlier date-only values at midnight; it cannot recover their lost clock. Do not assert that midnight proves loss or fabricate recovered times. If import provenance proves lost clocks, expose that limitation and contain exact intraday closing acceptance pending source reimport.

### Exact query semantics

Within the tenant and selected company/location/year, evaluate the saved account across **all books**. Source `DC_Main:1471` groups by AC_CODE and selects `SUM(CR_AMT - DR_AMT)` over rows with `ENTRY_TIME < cutoff`. Its separate helper-closing query at1479 uses `<=`. There is no VCH_DATE range, book restriction, selected-voucher exclusion, cross-year carry or independent AC_MAST opening addition.

- ModeC means no DATA_TYPE predicate, including NULL and any stored type value under source SQL behavior.
- Any other resolved mode adds exact `DATA_TYPE = mode`; do not reinterpret C as stored DATA_TYPE C only.
- Do not replace `SUM(CR_AMT-DR_AMT)` by two separate sums or coalesce each nullable leg. A row with one NULL operand has a NULL difference and does not contribute to the SQL sum. If a matching group exists but its sum is NULL, original Format(DBNull) behavior remains unverified; report unavailable rather than0.
- A truly absent eligible group under fully resolved scope, mode and cutoff leaves the source reset amount0. This is the only no-ledger-row zero conclusion authorized here. Missing mode/configuration is not absence of a group.
- NULL ENTRY_TIME fails both comparisons in SQL; record raw data/provenance without giving it VCH_DATE or today's timestamp. An actual earlier entry for the current saved voucher contributes if it satisfies the source predicate; do not add a convenient current-voucher exclusion.
- Retain both opening amount and source helper-closing amount as distinct observations if exposed. The later BILL_TOTAL closing is `CustOpAmt` plus post-clearing payment outstanding minus received outstanding, not the helper's `<=` result and not a fresh post-preview database sum.

The source also computes gold/silver balances using IT_TYPE/SIGN/FINE_WT in the same query; this next amount-only API must not claim those metal balances or reuse their names for the cash opening amount. Keep the original three-branch closing operation order in the pure bill prerequisite. Expose signed amount and Cr/Dr/zero semantics. Zero source label does not reset its historical color at16453–16455; an API without previous UI color cannot invent that history. Saved load first displays the helper closing amount at10211–10225, so a known positive/negative helper closing establishes blue/red before a later zero bill closing. If that helper amount is zero, prior form color is not persisted or otherwise established. Retain an explicitly known prior presentation or expose neutral/unknown presentation separately from the correct zero amount; never accept an arbitrary client color as business state.

### Who owns DATA_TYPE mode

`TR_SALE_RTN:9928–9937` reads selected BOOK_DATA.DATA_TYPE into **ItmDataType**, defaulting blank toA for row/posting use. This is not **DC_Main.MsDataType**, which the balance query consumes.

Company opening initializes MsDataType toC, changes it toA for editionsA/E, then applies explicit registration exceptions back toC (`MS_OPNCOMP:1459–1475`). MDI mode controls subsequently change it. `MDI_FORM:12726–12790` checks CONV_MAST in literal company01 and either selects A/B/C or maps a mode name to CON_CODE. The mode is mutable even with the same voucher/book. Registration/edition state and this mapping have not been provisioned as an authoritative web mode in the inspected auth/session services.

Required next integration decision: supply a **server-owned, scoped, versioned ledger-mode observation**. Its internal adapter should return either unresolved with reason, or `{mode, provenance, revision}`. No HTTP field may directly become MsDataType. A fixed deployment/company preview mode is acceptable only as an explicitly configured web profile reviewed by the business, not as recovered desktop session state. A later actual mode selector requires its own validated session persistence, allowed transitions and authorization; it cannot be introduced by accepting an arbitrary request parameter.

If deriving a company-open default, both edition and the registration-exception decision must be known, versioned and server-owned; editionA/E alone does not prove modeA. If supporting original mode aliases, observe relevant CONV_MAST physical rows and duplicates at source company01; do not quietly relocate them to selected company or expose license identifiers. The selected target company remains unchanged. Until such an adapter is supplied, return ledger mode/opening/closing unavailable while permitting independently resolved non-ledger aggregate and bill observations.

## 6. One trusted transaction and complete token

Compose new transaction-local readers under one tenant-bound `RepeatableRead` callback, following the existing saved/configuration helpers. No nested `withTenant`, request to an HTTP endpoint, client-provided observation or read outside that snapshot should supply business calculation inputs. Fresh scope/own-form access must be checked per request; a revoked session/permission is not rescued by an old token.

The new composite token must bind these observations, including missing sets and physical duplicates:

1. Contract/profile, row projection and aggregate/bill semantic versions, allowed event catalog, server phase policy and exact selected tenant/company/location/year/book/voucher identity.
2. Existing full saved document observation/version: all fourteen table sets, header and every incoming/related/outgoing row, raw values, count and physical row identifier/revision/locator. Include incoming SQL order/ordinal identity, not a Number-sort approximation.
3. Existing row configuration and a new tax configuration observation: canonical selected book/year, relevant CO_SET/CO_SET_NEW/COL_MAST raw inputs plus physical revisions, absent sets/duplicates, edition resolution when consumed, tax policy profile and qualified TAX_ROF raw alias.
4. Relevant item-master raw/physical observations for **all** incoming rows, including discovered company/item aliases and duplicates already contained by v1 projection. Editing a master used only by an unselected row must invalidate the document-wide aggregate observation.
5. Saved tax/account display master observations if included in the returned phase; raw code/label data and physical revisions. Keep current master presentation from overwriting saved business fields.
6. Authoritative mode value and provenance/version, any relevant server session/config row and CONV_MAST alias observations. If mode is external to the business DB, provide a coherent server revision protocol or leave it unresolved; do not describe two unrelated reads as one database snapshot.
7. Ledger predicate identity: exact account, selected scope, source date/clock policy, computed second-precision cutoff and mode. Include the complete raw/physical set relevant to opening and helper closing (all eligible books with time at or before cutoff), duplicate counts and eligible-group/NULL-sum evidence. Bind relevant discovered normalized identity aliases separately so a padded key cannot be silently treated as absent under unknown SQL Server collation. Genuine foreign tenant/company/location/year/account data remains out of scope.
8. Any import-timestamp reliability/provenance observation that changes whether the balance is declared usable. Do not infer a trustworthy clock merely because the current column is Timestamp6.

Use the existing SQL `jsonb_each_text(to_jsonb(t)-'tenant_id'-'row_id')` pattern so numbers/timestamps become text before JSON driver coercion. Keep raw NULL and exact decimal scale where PostgreSQL preserves it. Sort canonical physical observations for hashing separately from business row order. Do not use xmin as a standalone public numeric version; hash the complete observation and return opaque tokens. Display may expose provenance counts/reasons; internal row_id/xmin/ctid and raw account-ledger lines need not be disclosed to a Sales Return operator.

A customer ledger may exceed a UI page. Never hash only the first page, use a generic report balance with a different cutoff/mode, or silently cap the ledger sum. Implement a complete snapshot query/streamed canonical observation or explicitly refuse on a documented resource limit. If only amount observations are public, still bind the full relevant set internally. Scope/name aliases are diagnostic candidates, not an instruction to normalize and merge monetary rows.

POST reobserves all inputs, recomputes the token and refuses a mismatch before transient replay. Changes to eligible ledger rows, a new earlier row in another book, current row/header, a hidden row, policy, relevant master or mode invalidate the old token. A later-than-cutoff unrelated row need not invalidate a narrowly defined amount token unless the chosen observation includes it; this policy must be deterministic and tested. Same-value physical updates and present-row delete/recreate are detectable through observed physical revisions. **Absent→insert→delete between observations is not detected by an empty-set hash**, and restored databases can replay physical markers. This read-only token is an observation, not an eternal version, reservation or universal ABA defense. Future writes need locked re-resolution/serialization and a durable generation/revision protocol where required.

## 7. Diagnostics, UI phases and restrictions

Return200 for an existing inspectable document with capability diagnostics when a calculation prerequisite is unavailable, as the current configuration/read model does. Keep missing/ambiguous configured book, invalid scope, missing voucher, identity conflict and malformed event statuses explicit and consistent with existing route guards. Do not collapse shared book-unavailable409, semantic configuration422 and invalid-input400 into one generic status. A stale POST409 retains the operator's journal and attempted text; Reload is explicit and discards/restarts only with the established UI flow.

Suggested diagnostic codes and capability effects:

| Diagnostic | Keep visible | Refuse/unavailable |
| --- | --- | --- |
| `empty-incoming-document` | Raw header and related records | Events and complete saved-grid simulation |
| `unsupported-row-projection` / `ambiguous-row-identity` | Raw rows/identities; ready projections independently | Complete aggregate and bill journal; never sum a subset |
| `unsupported-outgoing-profile` / `unsupported-companion-profile` | Existing raw read | Aggregate API event path; separate outgoing/admission implementation required |
| `unsupported-bill-header` | Raw header and supported field projections | Bill simulation; reason names offending raw field/conversion |
| `unresolved-tax-rounding` | Raw settings and saved bill amount | Bill simulation; no precision guess |
| `tax-name-unavailable` / `account-name-unavailable` | Raw saved keys/names and mathematically known amounts | Only the unresolved current display label |
| `ledger-mode-unresolved` / `ledger-clock-unavailable` / `ledger-amount-unavailable` | Known row/aggregate/payment/outstanding | Opening/closing amount; no fabricated0 |
| `ambiguous-ledger-identity` / `historical-clock-loss` | Exact raw provenance and independent calculations | Claimed exact opening/closing pending reconciliation |

The UI must label **Saved amounts**, **On opening**, and **Preview after N changes** separately. Show payment/received labels corresponding to source matrix columns; do not call RTN_TOT_AMT the incoming item total. Show loaded versus effective tax cache changes where explaining a difference helps the operator. Read-only amounts must be visually distinct from supported row editors. Unknown balance must read as unavailable with a reason, never a red/green zero balance.

All render and action barriers remain bound to full scope/book/voucher/row identity and request generation. Scope A→B→A, close/reopen and metadata changes invalidate a pending aggregate response, even if a late response carries the same visible voucher number. Keep the existing explicit editor-text/Preview action and same-value chronology. Switching selected row starts a new journal from the authoritative opened baseline in this one-row profile, rather than merging unsubmitted histories by final values. No Save totals, Apply to return, refund, stock, admission or tender controls are added.

## 8. Proposed verification matrix

These are future test IDs, not tests executed by this note. Freeze hand-derived complete expected vectors before implementing adapters; do not obtain expected values by running the function under test.

| ID | Fixture/action | Required distinguishing assertion |
| --- | --- | --- |
| AG-OBS-01 | Two incoming saved rows, SR17/42, OLD31/58, hidden/raw sentinels and exact microseconds; edit only second row | All rows aggregate in source order; row identity/cache ownership preserved; only supported transient state changes. |
| AG-OBS-02 | Missing/NULL/duplicate projection in unselected row | Raw read remains; no partial document sum or apparently complete bill. |
| AG-OBS-03 | Incoming pieces0.4+0.4 and0.6+0.6 | Running formatted totals0 and2, respectively; rejects sum-then-round implementations. |
| AG-OBS-04 | Empty header, one actual blank grid row pure fixture, and nonempty saved profile | Distinct raw-read/blank-grid behavior; no fabricated incoming admission. |
| AG-OBS-05 | Hidden42, unsummed26/37 and widths0 | Pure aggregate follows exact14-column catalog; API cannot supply42 or discard hidden contributions. |
| AG-TAX-01 | Physical TAX_ROF NULL,0,5,6,Int32 max; flagN/Y | NULL→0 via Fnv;6/max→2; finalY→2; raw NULL retained. Company00 setting never fallback. |
| AG-TAX-02 | Pure negative integer withN/Y; fractional/overflow/prefix/malformed raw fixtures | Valid negative/Y→2; negative without override unavailable; failed earlier conversion not rescued byY. Unsupported cases have no invented executable result. |
| AG-TAX-03 | Duplicate/missing company settings, noncanonical flag, raw aliases | Configuration diagnostic/no guessed precision; exactly qualified raw keys preserved. |
| AG-TAX-04 | Incoming101, tax1.4, tax precision0 versus finalY→2 | Bill tax1.00 versus1.41 while both whole payment totals102.00; testing only final amount is insufficient. |
| AG-OPEN-01 | Saved RTN_NET_AMT200, matching row sum200, cached percent10, manual tax7 | Open preserves manual7 and payment total207; current tax master rate must not overwrite it. |
| AG-OPEN-02 | Saved RTN_NET_AMT200.60 and row sum200.60, cached percent10/manual7 | Open rounded incoming201 changes cache; tax20.10, payment221; raw saved header remains200.60/7. |
| AG-OPEN-03 | Source saved direct-Val NULL versus Fnv KASAR/BILL_OS NULL | Distinct field diagnostics/projections; no universal header NULL→0. Large FLOAT/decimal raw preserved. |
| AG-OPEN-04 | Outgoing parent/child exists despite incoming row readiness | Explicit refusal; no fake outgoing amount from header NET_AMT. |
| AG-EVT-01 | Complete Round9 independent baseline110, manual bill tax7/cache110/10; Other1 thenOther0 | First prefix111/tax11.10/payment122; final110/tax11/payment121, not final-only117. Compare every row, aggregate, bill cache and matrix prefix. |
| AG-EVT-02 | Same-value events, cache strings200 versus200.00, skipped/text-only pure events, wrong active ordinal | Numerical cache equality; actual source callbacks only; original event order preserved. No phantom callbacks on skipped text. |
| AG-EVT-03 | A valid event followed by a row-valid event causing aggregate/bill failure | Second event rolls back its transient row and all downstream state; exact last complete prefix and attempted text returned; zero business writes. |
| AG-EVT-04 | Pure UpDowntrue or EditOpen phase; zero difference/manual tax; negative outstanding | Preserve source skip and clearing order; no blanket zero cleanup or overpayment clamp. These pure phases are not automatically admitted API flags. |
| AG-LED-01 | Date plus12:00:00.900000 saved clock; entries11:59:59.900 credit10, another book before cutoff credit7, at12:00:00 credit20, at12:00:00.100 credit30 | Cutoff exactly12:00:00; opening17; helper closing37; actual bill closing separately computed. No same-voucher exclusion. |
| AG-LED-02 | Same scope/account A/B/NULL types; modeC thenA thenB; selected book type deliberately different | ModeC includes all types, A/B exact; book posting type cannot substitute for session mode. |
| AG-LED-03 | Foreign tenant/co/lc/year/account, future VCH_DATE but earlier ENTRY_TIME, earlier samevoucher entry | Scope isolation; ENTRY_TIME predicate controls inclusion; no extra date or voucher filter. |
| AG-LED-04 | No eligible group; all-NULL difference group; mixedNULL/nonNULL; NULL ENTRY_TIME | Only absent eligible group proves zero. Exact SUM(CR-DR) behavior; no per-leg COALESCE or guessed clock. |
| AG-LED-05 | Missing mode, malformed clock, proven lost historical clocks, padded identity candidate | Known aggregate/bill still inspectable; opening/closing unavailable with specific diagnostic and raw provenance. |
| AG-VER-01 | Independent client changes other-book eligible ledger, unselected-row master, tax setting, account label, mode or physical same-value header | Composite token changes; old POST409 before calculation; local journal retained. Unrelated out-of-scope data never enters result. |
| AG-VER-02 | Present row ABA versus absent→insert→delete | Present physical revision invalidates; absent-only cycle limitation explicitly measured, not called universal ABA protection. |
| AG-TX-01 | Independent transaction changes policy/master/ledger between reader steps | One RepeatableRead response is internally coherent; subsequent request stale. No nested reads escaping the snapshot. |
| AG-HTTP-01 | Own View, view revoked, generic unrelated rights, crossbook/year/voucher, unknown query/body authority fields | Correct fresh rights/scope/status; POST stays a read action and canSaveNumeric alwaysfalse. |
| AG-UI-01 | Real saved load/open/preview, unchanged raw section, late request under real held read, scope A→B→A, reload after independent change | Clear phase labels; no stale rendering/action; no autosave or silent retry; unavailable balance visibly distinguished from0. |

For every service/HTTP success and refusal, compare complete business values **and physical revisions** before/after across the existing24-table replay snapshot: SL_DATA, SL_DETL_RTN, SL_DETL, SL_IDTL, BAR_DATA, BAR_DETL, BAR_IDTL, MAIN_STOCK, AC_DATA, TAX_DATA, BILL_OS_DATA, ROJ_MEL_DATA, DM_DATA, REMARK_DATA, SRNO_MAST, TAG_SET, TEMP_BOOK_DATA, CO_SET, CO_SET_NEW, COL_MAST, BOOK_DATA, YEAR_MAST, ITEM_MAST, EMP_MAST. Add TAX_MAST, AC_MAST and CONV_MAST/server-mode configuration where newly observed. Exclude only explicitly understood authentication activity from business no-write assertions. No baseline recapture may erase the distinction between an intended second-client fixture change and a forbidden preview mutation.

## 9. Implementation order and remaining acceptance

1. Freeze the pure running aggregate/bill state contract and independent prefix expectations, including unknown opening and rollback. Keep its mathematical rounding profile distinct from original VB/runtime evidence.
2. Add detached saved-header projection with the exact Fnv/direct-Val distinctions, matrix/caches and immutable raw values. Add a versioned company-open tax resolver, sharing the existing physical settings observation rather than obtaining a second snapshot.
3. Compose all saved rows/masters/configuration and source phases into a new nonpersisting API observation. Block incomplete-grid projection and outgoing/companion branches. Implement the new token, strict request envelope and aggregate+bill failure recovery before a UI consumes it.
4. Add authoritative mode ownership and exact ledger observation as a distinct dependency. Until then, permit known independent outputs with unavailable closing, visibly bounded. Do not substitute a mode from the selected book to make a fixture pass.
5. Run meaningful pure, isolated DB, authenticated HTTP and real-stack browser verification with explicit source hashes and before/after business snapshots; then independently review new evidence. No such execution occurred for this note.
6. Keep numeric saves, tax/ledger posting, tender/refund/allocation, source admission/availability, outgoing exchange, component/tag effects, reversal, print/report reconciliation, original runtime/locale/ActiveX behavior and business acceptance open. Successful v2 aggregate preview would complete this prerequisite only, not end-to-end Sales Return or desktop-to-web parity.

## 10. Pinned inspected sources

Hashes below identify the read inputs, not executed test artifacts or a product checkpoint. Paths are relative to the extracted folder. Newly changing Round10 pure source is intentionally not pinned before its owner freezes it.

| Inspected path | SHA256 |
| --- | --- |
| `unified/src/csharp/DataCareNext/TR_SALE_RTN.cs` | `cdee9c37772522727d08c86baee71a46daa7b11cdfdf2eeb1ef656d80dfbb7a1` |
| `unified/src/csharp/DataCareNext/DC_Main.cs` | `7ff3543a78440db0f6f18eaf442aade59a105fcb398c0ba7fd9f9c53c195a688` |
| `unified/src/csharp/DataCareNext/MS_OPNCOMP.cs` | `180f295f9595dfc7c28ee34629563889c943eea0a0afc7c7a9baa519a11c4561` |
| `unified/src/csharp/DataCareNext/MDI_FORM.cs` | `cb91085c50d07a07ae5c5a8e6982ef6f9a2c533e2b55d61fc8c35f093f5dfbbc` |
| `unified/src/csharp/DataCareNext/UT_SETTING.cs` | `a47be9b0e2b7754511e8d0aeab135c8352c58f9f417101e550b23ccbc78c30ad` |
| `unified/src/csharp/DataCareNext/UT_SETTING_MAIN.cs` | `76116b14149afc1c6a5b93562c9aa9877979c43bdf6372e1d8fe1e6296aec4c5` |
| `unified/database/schema/01_Schema.sql` | `1eb684c7e2bec72a330a9038a2da72ffea669b3ae7ef50b85b34e0e3126efa0d` |
| `web/packages/db/prisma/schema.prisma` | `158aa2c66db0ff7b5b07931d853d73cb2aad0973880a0d7385eee6695c973754` |
| `web/packages/db/prisma/migrations/20260911020000_ledger_entry_timestamp/migration.sql` | `b6dd19d5450d9c9a6ddfe12521bfbfed1e327979f0d67b4d980e3d1c6e3a2061` |
| `web/apps/api/src/modules/sales/saleReturnIncomingReplay.ts` | `69a8e90c32258e756e8294dd3c8ebb5aeb185d64fb567e1fcf03b74f7e8f4190` |
| `web/apps/api/src/modules/sales/savedSaleReturn.ts` | `f23c529ea4ea7003e5d6f553e03d4f596beb3914be24076d6a16ea26eeafffec` |
| `web/apps/api/src/modules/sales/saleReturnIncomingConfiguration.ts` | `2352433c0fb065d5ef17c227a594ba887875c7d024817848da3056c852466505` |
| `web/apps/api/src/modules/auth/jwt.ts` | `4bd2d709bcd6ec64d3734822972932aed4bcd1797422815caf4a8eaa90de3169` |
| `web/apps/api/src/modules/auth/session.ts` | `17765f43964137139d582695cc0d10e3713227b8e118070e6f3e4a07fdb63bf0` |
| `web/apps/api/src/modules/auth/businessScope.ts` | `7eca43829be9e9034be1779cf33760d94deb92dd55d6ec99d67b2a6d1310535e` |
| `web/apps/api/src/modules/posting/posting.ts` | `31cb38b11b25cdfdaaf796ae2d4305888b6f61f71704fde9e97424bacb6df44e` |
| `web/apps/api/src/modules/reports/ledgerStaging.ts` | `9f84032fcbe8d9ff10fc834fb1d88eb0037042a905961ec2cfd83620756efc1f` |
| `web/packages/core/src/saleReturnIncomingProjection.ts` | `3f3b9ac1e937f1adfbf535283cd66701438b791a24ed691d641c573f63e9d96e` |
| `web/apps/api/test/saleReturnIncomingReplay.db.test.ts` | `b3438681084ed99e11b2ec06db38d766e53799db439800fca76de7065ba1251a` |
| `web/apps/api/test/saleReturnIncomingReplay.routes.db.test.ts` | `22295cc1b5905795b49a4c0b7253750f8c2050a817189c0efdae312e84f6cb19` |
| `parity-plan-2026-09-10/evidence/implementation-2026-09-11-round9/x13-next-aggregate-requirements.md` | `ae2b95e059748d34facb152c7ea1268058eb0bf9058ec7f9b91dd30051889ddc` |
| `parity-plan-2026-09-10/evidence/implementation-2026-09-11-round9/x13-next-aggregate-independent-review.md` | `038745a3fb3ca94016f0801065a638523e2791f19e452e29a20fd29b564ad6df` |
| `parity-plan-2026-09-10/evidence/implementation-2026-09-11-round9/x13-runtime-probe-next-steps.md` | `131546be4d787838ca2c4b274bee54c1881da253b8ecefb2fc77ade20c61834c` |
| `parity-plan-2026-09-10/evidence/implementation-2026-09-11-round9/x13-replay-independent-journal-vectors.json` | `68c3744d2e2cdbf741723effeef853dc05c97222f47bd740ecdd126127f7d83d` |
