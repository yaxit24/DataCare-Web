# X13 incoming Return configuration — round 8 implementation evidence

This is the read-only configuration prerequisite defined by the frozen round 7 `x13-next-configuration-contract.md`. It resolves the primary desktop incoming grid's source policy and stable field catalog. It does not implement source admission, numeric event replay against saved vouchers, totals/settlement posting, or numeric saving. No desktop executable or business acceptance is claimed.

## Ownership and API contract

Owned production file: `web/apps/api/src/modules/sales/saleReturnIncomingConfiguration.ts`. Owned tests: `saleReturnIncomingConfiguration.test.ts` and `saleReturnIncomingConfiguration.db.test.ts`. The root agent owns the GET route, central policy and authenticated route tests; the independent reviewer owns `saleReturnIncomingConfiguration.review.test.ts` and its source-derived fixture. No shared settings resolver, master writer, schema, core reducer or historical checkpoint was changed by this implementation.

Exports:

```ts
getSaleReturnIncomingConfiguration(prisma, scope: SavedSaleReturnScope)
  : Promise<SaleReturnIncomingConfiguration>
resolveSaleReturnIncomingConfiguration(scope, observations)
  : SaleReturnIncomingConfiguration
SALE_RETURN_INCOMING_COLUMN_CATALOG
SaleReturnIncomingConfigurationError // statusCode 400 | 422, code, message
```

The root-integrated route is `GET /sales-returns/incoming-calculation-configuration` with explicit selected `coCode`, `lcCode`, `coYear`, `coBook` query strings and authenticated tenant. No client policy, cache map, width or extra scope field is an accepted input. Response scope omits tenant; the observation token binds tenant internally. The response includes the contract version, six raw setting values, detached column descriptors, resolved policy or NULL, diagnostics with `blocking`, new-row labour default, and `canSaveNumeric:false`.

Service validation rejects malformed scope with 400 and invalid/ambiguous book or year with 422. Settings/column ambiguity is a successful read observation with blocking diagnostics, `policy:null` and `canCalculate:false`. Existing central business-scope validation can preempt a missing or inactive book with 409 `book-unavailable`; the authenticated tests distinguish that result from service-level 422 instead of weakening the shared guard. View permission does not confer write permission.

## Source behavior implemented

The six inputs are exactly `CO_SET.SL_AMT_TYPE`, `LBR_ROF`, `LBR_RATE_GEN`, `ALL_ROF_REMOVE`, `LBR_TYPE`, and `CO_SET_NEW.LBR_WITH_GHT`. Other company settings are not returned. Each company settings table must yield one row. Duplicate CO_SET and absent CO_SET/CO_SET_NEW are diagnostic; no arbitrary first row, company-00 fallback or generic web default is used.

Source references are `MS_OPNCOMP.cs:664,675,686,691,717,733–735,757–759,817–819,881–883,929–931,1006,1224–1226,1297–1303`:

- Blank strings apply the source defaults: amount N, labour type G, generation N, all-rounding override N, ghat inclusion Y. NULL and malformed imports remain distinct and contained.
- LBR_ROF must be exact integral SQL text within signed Int32 before any override. Values greater than 3 become 0; the later ALL_ROF_REMOVE Y makes the final precision 2. Thus 4/N →0, 4/Y →2, and a representable negative/Y →2. Negative/non-Y, fractional, non-finite, NULL and out-of-Int32 values remain unsupported. The later Y does not rescue an earlier invalid CInt conversion.
- The strict profile accepts canonical amount N/G/F/P, flags N/Y, and new-row labour N/G/P/K. It does not trim or case-fold these settings into a different source branch. Global amount P remains the primary grid's net-plus-ghat branch; piece-based metal calculation still depends on the row's RATE_TYPE, as the unchanged core reducer records.
- `newRowDefaults.labourType` is configuration metadata. No saved/source row is rewritten to this value.

`DC_Main.OpenTable_ColMast:1686–1692` loads company COL_MAST. `TR_SALE_RTN.MSG_PR_CLEAR:3577–3759` supplies 71 original positions and matches the literal family `SALES RETURNE` by original source headings. It does not use COL_DETL, the configured book's display name, renamed captions, browser layout widths, or COL_RPT as event authority.

The implementation returns stable IDs `x13.primary-incoming.c00` through `c70`. All hidden identities and comparison-cache positions remain distinct; hidden slots are not ordinary commit targets. `commitKind` describes the source LeaveCell formatting category, not editing permission. Renamed captions cannot merge IDs. Fine's nominal baseline is 1000; an explicit canonical Fine/N override resolves zero. Y or blank visibility preserves the baseline. Sr is excluded from override lookup and ends at 325; RecCode's label may change but its final width is 300 even after an N override. `COL_RPT` is observed/versioned without invented repeat behavior.

The resolver reads every column row for the active company before family classification. Canonical known rows apply once. Duplicate original keys, including identical rows, block the strict profile. Case/spacing collisions in family or original heading are diagnosed; a subsequent exact Fine/N row cannot turn an ambiguous width into an authoritative zero. Empty original names cannot configure hidden fields. Unknown extra original names are warnings and never become dynamic IDs. Two canonical fields may share a caption while retaining different IDs. A blank new caption remains blank; a NULL caption is separately diagnosed.

## Configuration profiles and remaining uncertainty

`widthMode:'source-zero-predicate'` means the server resolves the source's zero/nonzero condition at positive nominal scale. These numbers are not browser pixels. Original IL confirms `get_ColWidth` for the LeaveCell gate and Fine basis; the unchanged eight width vectors are exercised through this resolver into the existing core reducer.

Style column 6 depends on a separately established desktop software edition. The runtime service does not read or expose registration values, guess an edition from a letter, or trust a client edition. It returns Style `widthState:'unresolved'` with NULL effective/original caption. A physical Style override is still versioned and marked configured, but cannot present a conditional caption as an established effective heading. Calculations on other resolved catalog fields can remain available; Style-specific events remain unavailable. The pure server boundary tests authoritative A/E and other resolved edition observations, but that does not constitute a runtime edition resolver.

Book family/table/direction comparisons use existing trim-plus-uppercase behavior; doubled internal spaces in MAIN_BOOK do not become a valid family. Blank table and direction retain the existing book-policy compatibility; explicit contradictions fail. This strict read rejects every duplicate selected-book row and treats lowercase imported CUR_USE n as inactive, as the source reader does. Those two containment choices are stricter than the generic bookPolicy's active-row SQL filter and are not represented as measured desktop collation behavior. The target YEAR_MAST row must be unique; year raw values are versioned but this calculation read does not grant a fiscal-period write exception.

Exact malformed VB conversion/culture behavior, imported DataView collation beyond the detected canonical collisions, runtime edition resolution, unusual desktop scaling, hidden-cell entry clearing, repeat/navigation behavior, and business acceptance remain open. The new generic column-maintenance work is separately owned; this GET never provisions or reconciles configuration rows.

## Observation consistency and version limits

The service reads settings, columns, selected book and selected year inside one tenant-scoped PostgreSQL RepeatableRead transaction. Every scalar is converted to text in PostgreSQL before JSON parsing. Settings are whitelisted before response/version construction; registration values are not read. The token hashes the authenticated complete scope, contract/catalog, exact relevant raw values and NULLs, explicit counts, each physical row identity/revision/locator, and the server edition observation if one is provided at the pure boundary. Ordering of independent input rows cannot change the token.

Real tests show stable unchanged reads, relevant insertion/deletion, rename, settings A→B→A, column A→B→A, present-row deletion/recreation, selected book/year changes, and isolation from unrelated company/tenant/family rows. An instrumented scheduling client changes real PostgreSQL settings and inserts Fine after the service's actual CO_SET read; all service query results still come from PostgreSQL. The initial transaction sees one coherent prior snapshot; the next read sees the changed precision and inserted hidden Fine. No HTTP response is mocked.

An important explicit limit is tested: absent Fine → insert → delete → absent produces the original empty observation token. `xmin/ctid` record surviving row changes, not deleted history. This is not universal ABA detection, durable validity across restore, or phantom-write protection. Future numeric replay must re-resolve configuration inside its locked/serializable saved-document/source transaction and compare the observation; all relevant settings writers need a compatible concurrency protocol. A durable company/family revision or tombstone is required if transient absent-row history itself must invalidate a token. None of those future write guarantees is claimed by this read endpoint.

## Verification record

- `configuration-service-first.txt`: 2 files, 61 tests passed (26 real DB, 35 pure), no skips. This predates the later book-normalization and conditional-Style-caption cases.
- `configuration-focused-complete.txt`: 5 files, 193 passed / 1 failed. Service26, pure36, independent69 and routePolicy54 passed. The sole failure was the root HTTP assertion expecting 422 for a centrally rejected missing book; actual 409 `book-unavailable` was correct shared behavior. The failure is retained.
- `configuration-http-corrected.txt`: the precise corrected HTTP contract passed all 9 tests, no product guard change. This run predates the last conditional-Style-caption-only correction.
- `configuration-service-types.txt`: a retained intermediate workspace typecheck failed only in the other in-progress `columnSettings.ts` module. It is not claimed as a passing final check. An earlier runtime typecheck before that integration passed.
- `focused-complete.txt`: the root's final combined run passed **7 files / 253 tests / 0 skips** on the frozen implementation, including the last conditional-Style-caption correction. Counts are configuration pure37, configuration DB26, independent review69, configuration HTTP9, routePolicy54, column-settings pure37 and column-settings DB21. The independent cases include 35 pinned setting vectors and all eight frozen core width vectors. This final pass supersedes the earlier stage failures without erasing their provenance.

The separately authored column-settings database/route checks are documented in [column-settings-db-verification.md](column-settings-db-verification.md), with their own [scoped hash manifest](column-settings-db-verification.run.json). Their successful dispatch into this resolver is included in the final 253-test run.

Database tests used only the isolated wrapper/localhost55433 project, fresh unique test tenants, non-owner app runtime and real PostgreSQL. They compare complete raw/physical snapshots of seeded settings and incoming voucher/component data, and inspect stock/ledger tables for unchanged state. No full suite or browser was run by this agent. The root checkpoint records full-API, typecheck and browser results separately; this evidence establishes the final focused engineering pass and does not infer wider acceptance from it.

There is no new numeric Return UI, numeric writer or additional functional-parity percentage attached to this prerequisite. The associated `.run.json` pins the final owned files and these exact local evidence artifacts.
