# Staged incoming Return labour prerequisite

This is a new, unexecuted internal prerequisite. It is not integrated into the repository, any preview, HTTP route, UI, numeric writer or financial workflow. Root owns integration and all compiler/test/DB execution after the current session runtime milestone. No old core module, fixture, source evidence or accepted card was edited.

## Contract and exact source boundary

`web/packages/core/src/saleReturnIncomingLabour.ts` exports `copySaleReturnIncomingLabour(input: unknown)` and its typed DTOs. The exact input has `scope:{tenantId,coCode}`, `rowIdentity`, complete `state`, `field:13|29`, `editorText`, `expectedObservationVersion`, and a complete physical `observation`. Ready returns detached/frozen `state`, `observation`, `visiblePatch`, `nextEvent`, and no diagnostics. A lookup-required or unsupported result has no patch or event and retains a detached valid previous state and valid observation; malformed data cannot be published as a valid state. The function never invokes row, aggregate or bill calculation and never appends a journal entry.

Primary `TR_SALE_RTN.cs`:

- 4137–4141: this is an Enter-key branch, not a generic Leave event.
- 4248–4277 / 4322–4351: resolve current-company `LBR_MAST` by entered code; missing master opens help and returns. Help selection does not execute the resolved copy in that invocation.
- 4279–4292: changed c13 clears c23,c24,c21,c14,c17,c28. Assign c13; fill c29 only if its visible text is exactly empty. Preserve a space-only or existing tag code.
- 4293–4319: prefix categories01/02/03/04/05/06/07 assign c23/c21/c24/c17/c14/c23/c28. Only category06 sets c22=K. Zero is copied as Format2 zero. The source then calls `CommPassTotal_Pr`.
- 4353–4380: changed c29 clears c31,c32,c30,c35; assign c29. Prefix01/06→c31,02→c30,03→c32,07→c35;04/05 copy no tag value. Category06 does not set c22. The source then calculates.
- 4508–4512: editor MaxLength4 does not widen the current master key.
- 4620–4628: plain Leave copies code text; it is not this resolved Enter sequence.

`MS_UPDATE.cs:31583` declares code varchar2 and Float default0/non-NULL. Current Prisma `LBR_MAST` at3509–3518 has tenant/company/code composite PK, no row_id, code/company varchar2 and nullable Float value. Raw NULL is retained and refused for formatting in this initial profile. No SQL or schema change is proposed.

The copy profile is explicitly smaller than desktop behavior: exact nonblank unpadded printable ASCII code of length1–2; one exact master with no discovered relevant case/ASCII-space alias; exact category prefix01–07; finite plain ASCII decimal at most128 characters,36 significant digits,18 fractional digits, absolute value below1e36; mathematical Format2 half-up through the existing string helper. It does not use JavaScript Number or alter global Decimal precision. Category04/05 in c29 also requires a qualified value even though the desktop does not assign it: this is a named conservative profile restriction. Blank/help/cancel, wider imported codes, SQL Server collation, Double/DBNull/culture behavior and full keyboard admission are open.

A complete row means63 visible string cells plus the eight comparison caches45/46/47/48/49/58/66/67, immutable raw string/NULL values and a structurally retained prior journal. Numeric contents and unresolved policy are not recalculated or normalized by copying. The plain-data envelope refuses getters/cycles/symbols/sparse arrays, with bounded depth/node/text size; these are internal containment limits, not desktop limits.

## Transaction reader and snapshot limit

`web/apps/api/src/modules/sales/saleReturnIncomingLabour.ts` exports `readSaleReturnIncomingLabourTx(tx: Tx, input: unknown)`. It owns no transaction wrapper. Input is exactly `{scope:{tenantId,coCode},enteredCode}`. One parameterized SELECT observes current tenant setting, caller isolation and all matching PostgreSQL uppercase/ASCII-space-trim candidates. It requires matching tenant and RepeatableRead or Serializable isolation. There is no company fallback, LIMIT, write, row lock, schema change or session touch.

Raw fields are converted to text inside PostgreSQL using `jsonb_each_text(to_jsonb(t))`; tenant/company/code remain in raw and xmin/ctid are separate. JSONB may expand Float exponent notation into plain numeric text. A dedicated staged DB case expects1e30→`1000000000000000000000000000000`; this is a current PostgreSQL representation test, not original SQL Server Double equivalence. Raw malformed/nonfinite/NULL remains visible to the pure refusal.

The observation version hashes the reader semantic version, exact scope/code, complete candidate raw values and physical revisions in deterministic order. It detects observed extant-row updates/recreation. An absent→insert→delete cycle returning to the same empty observation produces the original token; no durable absent-history, clone/restore or universal ABA guarantee is claimed. RepeatableRead is an as-of-snapshot observation, not “latest when the response arrives.” A later writer using another isolation/locking protocol must qualify that protocol independently.

This is a master-only hash, not an authentication capability. The pure comparison does not recompute or authenticate the reader hash and is not a public client-baseline API. A future server-owned operation must bind complete document, configuration, live session and master observations together in its own transaction before copy/replay. No master data/category/rate from a request can become authoritative just by matching an opaque token.

## Rollback responsibility before any future integration

Ready means only that the pre-calculation copy is known. The returned event is `calculateAfterCopy`, activeColumn13 or29, original editor text, and `labourCodeSelection` or `tagLabourCodeSelection`. A future coordinator must retain the entire original pre-copy row and whole-grid prefix, then compose copy→row calculation→aggregate→bill in source order as one accepted operation. The existing row reducer returns the state it was given on rejection; if given copiedState, that is not the pre-copy state. The outer coordinator must restore the original state, caches and both journals when any downstream phase rejects. This stage neither calls those phases nor claims that rollback integration is implemented.

## Existing previews stay unchanged

Current root-owned sources and web validators are pinned in `inputs.json` as observed unchanged by this staging task:

- Incoming replay contract `x13-saved-incoming-replay-v1`, profile `saved-primary-incoming-money-preview-v1`.
- Bill replay contract `x13-saved-incoming-bill-replay-v1`, profile `saved-primary-incoming-bill-preview-v1`.
- Incoming projection `saved-primary-incoming-projection-v1`, bill projection `sale-return-bill-projection-v1`.
- Aggregate `primary-incoming-aggregate-decimal-v1`, tax policy `sale-return-company-open-tax-policy-v1` / `sql-int32-text-and-null-v1`.
- Allowed numeric columns remain19,20,21,23,24,25,26,27,28,36,37,38; c13/c29 are not added. `canSaveNumeric:false` and bill `canPreviewClosing:false` remain unchanged.

`required-core-export.txt` contains the single proposed export for later root integration. Existing index, money, row reducer, projection, preview service and route files were not edited. No full original-sale/party/consumption/child admission, generated tag ownership, numeric/stock/financial persistence/reversal, outgoing/UAE or Windows runtime acceptance is claimed.

## Evidence and verification status

The original24 independent literal cases were authored before this implementation and are copied byte-for-byte as `web/packages/core/test/fixtures/saleReturnIncomingLabour.independent.json`, SHA256 `17ad183d4f9f143202fcdedac515aa58616a1d552dac06e01634212d44e941aa`. The original candidate file, contract and source hashes are pinned. Expectations were not calculated by the new copy/reducer.

Declared, unexecuted tests:73 core cases (including those24 and a SHA guard),16 API controlled-query cases,15 real PostgreSQL cases;104 total. Controlled-query tests prove adapter calls/containment only, not actual PostgreSQL semantics. The real DB file requires isolated localhost55433 plus non-owner app_user, uses dedicated fixture tenants, and keeps exact raw/xmin/ctid snapshots of master/configuration/ledger/Return tables. It includes real aliases, NULL/nonfinite values, no fallback, same-value update/recreation, documented absence-cycle equality and RepeatableRead interleaving.

Only source reads, static review, staged file creation, SHA checks and Prettier parsing/formatting occurred. No compiler, runtime tests, DB statements or browser were executed by this owner. Counts are declarations, not passing results. Root must retain any first failure and correction as a separate verification stage. Root independently compared TR_SALE_RTN4248–4380 with the staged copy and reviewed the reader boundary, reporting no blocking source finding. This is a bounded read review only; it supplies no runtime, DB, integration or Windows acceptance credit. Design’s optional review was not required to freeze this stage.
