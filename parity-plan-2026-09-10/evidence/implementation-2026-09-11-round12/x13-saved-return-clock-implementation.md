# Saved Return clock prerequisite — Round12

`web/packages/core/src/savedSaleReturnClock.ts` now exports a pure saved-clock projection. The source, fixture and tests were prepared in separate `/tmp` staging directories for a prospective Round13. Because concurrent edits invalidated the still-open Round12 final verification inputs, the clock was integrated into Round12 before its checkpoint was sealed. This note updates the clock prerequisite only; the earlier frozen handoff remains historical evidence.

## Source and representation boundary

`TR_SALE_RTN.cs:10104–10106` loads the voucher date and displays the saved time with `HH:mm:ss`. Its call at10197 combines that displayed day and clock for `DC_Main.MsAcBal`; `DC_Main.cs:1463–1487` supplies the strict opening and inclusive helper-closing observations. The day comes from `VCH_DATE`, even when `VCH_TIME` stores another day. Fractional seconds are discarded, not rounded into another second or day.

The current `SL_DATA` schema stores `VCH_DATE` as PostgreSQL `date` and `VCH_TIME` as `timestamp(6) without time zone`. `savedSaleReturn.ts` extracts scalar strings through `jsonb_each_text(to_jsonb(t))`, preserving the saved timestamp's fractional text rather than selecting it as a JavaScript Date. The named profile is `canonical-postgresql-jsonb-local-clock-v1`, version `saved-sale-return-clock-v1`.

Only exact `YYYY-MM-DD` and `YYYY-MM-DDTHH:mm:ss` with optional1–6 fractional digits qualify. Both full calendar dates must be valid within years0001–9999. Localized/space-separated/offset/timezone/infinite representations, invalid calendar or clock components and extra precision remain unsupported. This profile is deliberately narrower than PostgreSQL's full value range and does not prove Windows locale/Conversions.ToDate equivalence or repair imported observations.

## Contract and behavior

`projectSavedSaleReturnClock(unknown)` accepts only two owned raw fields, `VCH_DATE` and `VCH_TIME`, and opaque `documentIdentity`/`documentVersion` provenance. Missing properties remain distinct from SQL NULL. Invalid envelopes return `invalid-input` with no observation. Well-shaped observations with missing, NULL or unsupported clocks return `unsupported`, retaining exact raw values/provenance with no cutoff. A ready observation includes the canonical local whole-second cutoff.

The projector validates scalar descriptors, detaches its fixed-depth input envelope and recursively freezes its own output. Caller objects remain mutable and unchanged. It does not authenticate the provenance, initialize session mode, query a balance, expose an HTTP route, change an operator form, make closing available or write business tables.

For example, voucher day `2024-03-01` with timestamp `2024-02-29T23:59:59.999999` produces `2024-03-01 23:59:59`. The original timestamp remains visible in the retained raw observation.

## Independent verification

The frozen fixture has139 literal cases:24 ready outcomes,83 unsupported clock/date/absence cases and32 malformed envelopes. SHA256 is `d360162bc731cb383e33146c29265586358413821fca0cf5d94c4bdf753cdd78`. Expected cutoffs and refusal outcomes were authored before the implementation was inspected; no parser produced an expected result. The installed fixture is byte-identical to the staged fixture. The test harness received only the source and fixture import-path relocation.

- `clock-core-first`:159/159 tests passed, including the139 frozen vectors and fixture, containment and immutability checks.
- `clock-strict-first`: source and test passed strict TypeScript with `noUncheckedIndexedAccess`.
- `clock-core-build`: the core package compiled successfully.
- `clock-db-first`:8/8 real PostgreSQL cases passed under the restricted runtime role on the disposable database at55433.
- `clock-db-strict`: the dedicated new DB test and its real dependencies passed the inherited strict API test compiler. This bounded check does not replace the full API test compiler.

The DB cases call the actual saved Return reader. They observe `ISO/MDY + UTC`, `SQL/DMY + Asia/Kolkata` and `German/DMY + America/New_York`, verify the real PostgreSQL column types, preserve the canonical JSONB values, cover mismatched days and near-midnight fractions, and observe the serializer's removal of trailing fractional zeros. SQL NULL, deliberate adapter-only property omission and missing-document404 stay distinct. Raw/physical snapshots across27 tables and both unique fixture tenants remain unchanged after each read/projection. These observations establish the tested setting combinations, not every possible PostgreSQL configuration.

The complete combined core regression subsequently passed16 files/762 tests in the separate frozen verification worktree. All focused checks overlap that complete regression. API/browser/build/type outcomes and any active-workspace drift belong in the final checkpoint and current progress document, not inferred from these focused results.

The preserved staging source contract, source references, independent authorship note, fixture, proposed DB cases and independent harness review are under `clock-staging-source`, `clock-staging-vectors` and `clock-staging-review`. Their original prospective names and unexecuted-at-staging statements are historical; the actual invocations above record later execution.

## Remaining integration

The future trusted caller must obtain both raw fields from the same saved-header observation and bind raw text, document identity/version and projection version into the preview dependency. It must observe current authenticated session/context/mode authority and the full account ledger within the same transaction. Neither this pure projection nor its caller-supplied provenance establishes that authority.

Known closing remains unavailable until that integration has independent numeric, concurrency, stale-input, refresh/revocation and no-write evidence, including a real browser journey. All original34 cards,83 packages and198 whole-menu acceptances remain open. No production or complete desktop-parity acceptance is claimed.
