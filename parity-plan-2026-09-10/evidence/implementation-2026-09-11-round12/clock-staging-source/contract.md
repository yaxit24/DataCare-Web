# Saved Return clock adapter — prospective Round13 staging contract

This directory is isolated staging. Nothing here is installed in the web repository or parity plan. Implementation begins only after the independent literal vector fixture is frozen. No compiler/build/database/browser runs are authorized while root completes Round12 checks.

Primary `TR_SALE_RTN.cs:10104` reads saved `VCH_DATE`;10106 formats saved `VCH_TIME` as `HH:mm:ss`;10197 calls `MsAcBal` using the concatenated displayed date and clock. `DC_Main.cs:1471/1479` formats the supplied cutoff to whole seconds for strict opening/inclusive helper-closing predicates. The source therefore takes the calendar day from VCH_DATE and the whole-second clock from VCH_TIME. It never takes the day from VCH_TIME and does not round its fractional part forward.

Current `SL_DATA` schema5648–5649 stores VCH_DATE as Date and VCH_TIME as timestamp(6). The saved reader's JSONB-text projection (`savedSaleReturn.ts:159`) supplies YYYY-MM-DD and YYYY-MM-DDTHH:mm:ss[.1..6]. This first profile accepts those representations only. Timestamp-shaped VCH_DATE, space-separated SQL::text timestamp, offsets, timezone suffixes, locale strings, BC/infinite/year-outside1..9999 values and impossible dates/clocks remain unsupported. Both date portions must be valid, even though the VCH_TIME day does not contribute to the cutoff. No JavaScript Date, timezone conversion, locale parser or import-clock repair is used.

## Approved public types

Constants: `SAVED_SALE_RETURN_CLOCK_VERSION = 'saved-sale-return-clock-v1'` and `SAVED_SALE_RETURN_CLOCK_PROFILE = 'canonical-postgresql-jsonb-local-clock-v1'`.

Function: `projectSavedSaleReturnClock(input: unknown): SavedSaleReturnClockResult`.

Exact input:

```ts
{
  raw: { VCH_DATE?: string | null; VCH_TIME?: string | null };
  provenance: { documentIdentity: string; documentVersion: string };
}
```

Provenance fields are opaque nonblank printable ASCII strings, at most256 characters, without leading/trailing whitespace. They are preserved exactly, not authenticated. Both raw keys are optional only to distinguish a missing saved observation from SQL NULL; no other raw key is accepted. The adapter owns these two fields rather than accepting or copying a full arbitrary header.

Every result contains the version/profile, status, observation and diagnostics. A ready observation retains exact raw/provenance and adds `cutoffLocalSecond: string`; diagnostics is empty. An unsupported observation retains raw/provenance with `cutoffLocalSecond: null`. An invalid-input result has `observation: null`. Diagnostics contain a nonempty message, a code from `invalid-input`, `missing-saved-column`, `null-saved-column`, `unsupported-saved-date`, `unsupported-saved-time`, and optionally sourceField VCH_DATE/VCH_TIME.

Complete exact plain input with missing/NULL/malformed date/time is unsupported and remains inspectable. Unknown keys, non-string/non-NULL raw cells, malformed provenance, accessors, sparse/custom-prototype/cyclic-shaped envelopes and other invalid data are invalid-input. Ordinary/null-prototype data records are allowed; caller-owned objects are never frozen, mutated or retained. Results are detached and recursively frozen. Since all owned values are scalar and nesting is fixed, there is no arbitrary recursive raw-data walk.

Fraction removal is string projection after validation: VCH_DATE2024-07-10 with VCH_TIME2024-07-09T23:59:59.999999 yields2024-07-10 23:59:59. Leap-year/calendar validation uses bounded integer components only. No wall-clock/global locale state participates.

The adapter qualifies a canonical current-PostgreSQL representation, not the factual reliability of imported data, full desktop Conversions.ToDate/Format behavior or a successful original Windows form opening. It does not initialize session mode, read balances, grant closing capability, change saved values or persist numeric data. A future trusted same-transaction caller must bind complete saved identity/raw provenance and this derivation version into the broader replay observation.
