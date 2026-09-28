# Prospective saved Return clock: independent literals

This temporary artifact is prepared before Round12 checkpoint37 integration. It changes no workspace source, tests, plan or frozen evidence. No adapter implementation was inspected before the fixture was sealed; the source owner explicitly held implementation until receiving its SHA. No test, compiler, database, browser or Windows runtime result is claimed.

The frozen fixture is `saved-sale-return-clock.v1.json`, SHA256 `d360162bc731cb383e33146c29265586358413821fca0cf5d94c4bdf753cdd78`. Its 139 literal cases contain24 ready observations,83 unsupported saved-field observations, and32 malformed-envelope observations. Ten additional non-JSON constructions are descriptions for later tests, not executed cases. Diagnostic codes/sourceField form an unordered complete set; prose and ordering are intentionally outside the golden contract.

## Source rule and declared web profile

Primary `TR_SALE_RTN.cs:10104–10106` loads the saved VCH_DATE into the displayed date and formats VCH_TIME as HH:mm:ss. At10197 the form concatenates the displayed date and clock for MsAcBal. Therefore cutoff day is taken from VCH_DATE; the timestamp's embedded calendar day is independently validated but does not replace it. Fractional seconds disappear through this clock-only format and do not round to a later second.

Current `schema.prisma:5648–5649` declares SL_DATA.VCH_DATE as PostgreSQL Date and VCH_TIME as Timestamp(6). The agreed initial transport profile accepts only date text `YYYY-MM-DD` and JSONB timestamp text `YYYY-MM-DDTHH:mm:ss` with an optional1–6 fractional digits. Gregorian years0001 through9999 are the explicit bounded web profile. SQL-space timestamp text, Date timestamps, offsets, infinity, locale strings and invalid calendars are refused. This is not a statement that the original Windows application forbids all other inputs or a proof of its culture, DateTime or SQL Server representation semantics.

No saved-load default is established for a missing, NULL, blank or malformed date/time. The source excerpts contain direct assignments/conversion, not a fallback to current date, midnight, the other field's date, UTC, business date or ledger entry time. Both owned raw keys are validated; absent and SQLNULL remain distinct observations with distinct diagnostics.

The raw record is intentionally limited to those two observed columns by the agreed API. Document identity/version are opaque retained provenance strings, not authenticated authority. They cannot independently qualify a live document, session, ledger mode or coherent transaction. Caller-provided clockStatus/cutoff/representation keys are rejected rather than used as authority.

## Discriminating expected values

| Literal inputs | Literal result | Distinguishes |
| --- | --- | --- |
| Date2024-07-10; time2024-07-09T12:00:00.900000 | 2024-07-10 12:00:00 | Voucher day rather than timestamp day; fraction removal rather than rounding |
| Date2024-01-01; time2025-12-31T23:59:59.999999 | 2024-01-01 23:59:59 | No implicit day/year substitution or rollover |
| Date9999-12-31; time9999-12-31T23:59:59.999999 | 9999-12-31 23:59:59 | Upper bound stays valid without rounding into year10000 |
| Date2024-03-10; time2024-03-10T02:30:00 | 2024-03-10 02:30:00 | Local plain clock; no machine timezone/DST conversion |
| Date2024-11-03; time2024-11-03T01:30:00 | 2024-11-03 01:30:00 | No timezone overlap disambiguation |
| Date2023-03-01; time2024-02-29T23:59:59.999999 | 2023-03-01 23:59:59 | Independently valid timestamp leap day; clock extraction only |
| Date2024-07-10; time1900-02-29T12:00:00 | unsupported saved time | Invalid timestamp date cannot be ignored just because its day is not used |

Calendar refusals distinguish divisible-by4 leap years from1900/2100 century exceptions and2000/2400 leap centuries. Bounds0000,10000, impossible month/day and24:00:00/second60 are not normalized. One through six fractional digits are each covered; seven digits are refused, not partially truncated. Explicit terminal LF/CR/U+2028 and other control/Unicode cases distinguish whole-string qualification from permissive regex end anchors or trimming.

## Later consumer boundary

`DC_Main.MsAcBal:1463–1487` uses the resulting local second in two separate queries: opening ENTRY_TIME is strictly less than cutoff; helper closing is inclusive. For the literal cutoff2024-07-10 12:00:00, an entry at11:59:59.999999 belongs to opening; an entry at12:00:00 belongs only to helper closing; an entry at12:00:00.000001 belongs to neither. These are source-derived follow-on scenarios, not tests of a clock module that performs no ledger query.

The existing internal reader already expects a qualified local whole-second cutoff. A future trusted adapter must obtain the saved raw header, source identity/version, session mode/context and complete physical ledger observation within the relevant transaction and bind these dependencies before replay. The pure clock result alone must not make current bill closing available or enable numeric saving. Original runtime equivalence, trusted session bootstrap/commands and the ledger/UI integration remain separate work.

## Preservation requirements for later executable tests

For ready and unsupported observations, compare raw/provenance exactly, including own-key absence and fractions. Returned nested containers must be detached and frozen while caller containers remain untouched/unfrozen. Mutating caller raw or provenance after a result must not rewrite the earlier observation. Invalid envelope results have observation:null and do not invoke getters. The later test adapter must assert these invariants directly without deriving golden cutoffs from the implementation.

Exact primary source, current schema and frozen Round12 handoff hashes are retained in `vector-authorship.json`. Additional integration/checkpoint changes are reserved for root after checkpoint37 confirmation.
