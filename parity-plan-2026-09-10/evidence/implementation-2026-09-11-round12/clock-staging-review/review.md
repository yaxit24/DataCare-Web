# Prospective Round13 saved Return clock adapter — independent source review

Status: read-only source review, not implementation or API/desktop acceptance. No database query, compiler, build, browser, installation or web browsing was performed. Only this /tmp review was written; frozen plan/product/test files were untouched.

## Finding

The proposed `saved-sale-return-clock-v1` / `canonical-postgresql-jsonb-local-clock-v1` profile is justified as a strict current-storage representation boundary. It must not be described as a general DateTime parser, imported-clock repair, Windows locale emulation, or authority to make closing balances available.

1. `savedSaleReturn.ts:158–170` selects `jsonb_each_text(to_jsonb(t)-'tenant_id'-'row_id')` and reconstructs a JSONB object of scalar strings/NULL inside PostgreSQL. The timestamp is therefore already a JSON string when Prisma receives the raw envelope; this path does not return a top-level Prisma Date and then call JavaScript `toISOString`. The query does not cast VCH_TIME through SQL `::text` or explicitly format it with `to_char`.
2. Prisma's PostgreSQL schema declares SL_DATA.VCH_DATE `@db.Date` and VCH_TIME `@db.Timestamp(6)` at5648–5649. These are separate nullable values; the latter is timestamp without time zone. AC_DATA.ENTRY_TIME is also Timestamp(6) at33. A nullable Prisma DateTime annotation alone would not prove the wire string; the actual JSONB projection is the relevant boundary.
3. Existing real-database saved-reader tests pin the exact JSON string `2024-07-10T12:34:56.123456` at `savedSaleReturn.db.test.ts:399,760`. The saved raw values and physical revisions are included in the document version at `savedSaleReturn.ts:360–370`; header.raw returns that observation directly at384. The transaction-local helper420–425 composes reads without a nested transaction; the standalone getter434–439 uses RepeatableRead. Those facts support reusing exact raw/provenance, not rebuilding timestamps through Date.

## Desktop sequence

- Primary `TR_SALE_RTN.cs:10104`: the displayed voucher date is loaded from saved VCH_DATE (object/string conversion).
-10105 also uses Conversions.ToDate for the weekday display;10106 converts saved VCH_TIME and formats only `HH:mm:ss` into mTime.
-10197 calls `MsAcBal(tAcCode.Text, Conversions.ToDate(mVchDate.Text + " " + mTime.Text))`. The chosen calendar day is therefore VCH_DATE; only the hour/minute/second comes from VCH_TIME. A different valid date inside VCH_TIME must not replace the voucher day or force an equality error. Source uses no fractional field here, so .999999 is removed rather than rounded into the next second/day.
- `DC_Main.cs:1471/1479` formats that DateTime as `MM/dd/yyyy HH:mm:ss` and compares AC_DATA.ENTRY_TIME with `<` for opening and `<=` for helper closing. Scope is source company/location/year/account across books, with MsDataType C combining modes and other modes filtered.1465–1470 initializes six balances;1475–1477/1483–1485 converts amount, gold and silver sums. A correct clock alone does not establish mode, complete-helper conversion or closing authority.

Conversions.ToDate, masked date controls, VB object-to-string behavior, current Windows culture/calendar and SQL Server's parsing of the emitted slash-date literal have not been executed or proven equivalent. The adapter should document its Gregorian local-clock subset instead of silently assuming all those runtime steps behave identically.

## Approved DTO alignment and validation

Both implementer and independent-vector author confirm `projectSavedSaleReturnClock(unknown)` with exact `{raw:{VCH_DATE?:string|null,VCH_TIME?:string|null},provenance:{documentIdentity:string,documentVersion:string}}`. IDs are opaque printable ASCII, nonblank, <=256 characters, without outer whitespace; their presence is not authentication. Raw omitted versus SQL NULL remains distinct.

- VCH_DATE: exactly YYYY-MM-DD, Gregorian year0001–9999 and real month/day.
- VCH_TIME: exactly YYYY-MM-DDTHH:mm:ss, optionally followed by a dot and1–6 decimal digits. Validate its entire date and clock, including seconds0–59, then take only HH:mm:ss. No rounding or UTC adjustment.
- Reject nonprintable/non-ASCII input before regex matching (including terminal newline/U+2028), timezone suffixes/offsets, space-separated SQL timestamp text, shortened fields, bare time, more than6 fractions, 24:00, leap-second60, BC/infinity/expanded years and impossible dates. Do not trim or normalize unsupported values into supported ones.
- Wrong envelope/type/provenance yields invalid-input and observation:null. Well-shaped missing/NULL/noncanonical saved columns yield unsupported with retained detached raw/provenance and cutoff:null. A ready result retains exact observations and adds the local whole-second string. No current date, midnight, VCH_TIME date or default clock fallback.

Example: VCH_DATE2024-07-10 plus VCH_TIME2024-07-09T23:59:59.999999 yields2024-07-10 23:59:59. A local value resembling a timezone DST gap remains a calendar/clock value under this profile; there is no timezone authority to shift or reject it. Valid midnight can be retained, but old date-only imports may already have lost real clocks; this adapter cannot distinguish or repair that history.

## PostgreSQL formatting assumptions and proposed follow-up evidence

The saved read path sets neither DateStyle nor TimeZone. JSONB date/timestamp rendering is delegated to PostgreSQL's JSON conversion; SQL `timestamp::text` and JavaScript Date formatting are different paths and must not be substituted. Existing tests establish the sampled T-separated microsecond form, not every DateStyle/TimeZone setting, fractional length, server version or historical date range. No installed PostgreSQL formatter implementation was independently read in this review. Thus broad DateStyle/TimeZone invariance is not claimed here. Strict format acceptance keeps unexpected representations inspectable rather than coercing them.

Before connecting a future trusted API adapter, add real transaction-local comparisons of this exact JSONB projection under DateStyle ISO/SQL/German with MDY/DMY and TimeZone UTC/Asia-Kolkata/America-New_York, preserving the same timestamp-without-zone values. Test zero fractions and1–6 digits (including trailing-zero normalization), day mismatch, leap-century boundaries, midnight/23:59:59.999999 and special PostgreSQL infinity/BC/out-of-profile years. These are prospective tests, not results. Verify complete raw/provenance and no business writes; do not require an artificial date+time match. Bind clock semantic version and exact saved observation version/identity into the future same-transaction replay token, with stale source changes refused before use. Raw string provenance remains caller-supplied until that trusted adapter is implemented.

## Local source hashes

- `unified/src/csharp/DataCareNext/TR_SALE_RTN.cs` (10104–10106,10197): `cdee9c37772522727d08c86baee71a46daa7b11cdfdf2eeb1ef656d80dfbb7a1`.
- `unified/src/csharp/DataCareNext/DC_Main.cs` (1463–1487): `7ff3543a78440db0f6f18eaf442aade59a105fcb398c0ba7fd9f9c53c195a688`.
- `web/apps/api/src/modules/sales/savedSaleReturn.ts` (158–170,198–205,360–370,420–439): `f23c529ea4ea7003e5d6f553e03d4f596beb3914be24076d6a16ea26eeafffec`.
- `web/packages/db/prisma/schema.prisma` (SL_DATA5648–5649; AC_DATA33): `158aa2c66db0ff7b5b07931d853d73cb2aad0973880a0d7385eee6695c973754`.
- `web/apps/api/test/savedSaleReturn.db.test.ts` (399,760): `4a89b531ea665426669660547b7ab3df941f1e246958fc233aa1c05876724ac7`.
- `web/apps/api/src/modules/shared/desktopAccountBalance.ts` (92–109,156–181): `375629060abeb7454079996c19f61dcc3f8dbdff095616358257e1fa9ce4a2bd`.
- `web/packages/db/prisma/migrations/20260911020000_ledger_entry_timestamp/migration.sql` (entire migration): `b6dd19d5450d9c9a6ddfe12521bfbfed1e327979f0d67b4d980e3d1c6e3a2061`.
- `parity-plan-2026-09-10/evidence/implementation-2026-09-11-round10/x13-aggregate-trusted-observation-contract.md` (prior integration contract): `7240e8f6b3e0ea5b25ddd98535862d6e7a8cbf50cd981caccf049ef35b707b6b`.
- `parity-plan-2026-09-10/evidence/implementation-2026-09-11-round10/x13-aggregate-trusted-observation-source-addendum.md` (complete-helper qualification): `9f41889ef665c3a0934412c619921bf5788b853269967ea81e8ca267f09347ae`.
- Staged coordinated DTO contract `/tmp/datacare-return-clock-round13/contract.md`: `9d8f19bd79768e4b4610de089a1237b4acb9777a7898e145bf5fe992e4300d6e`.

Review captured 2026-09-11T17:40:19.762522+00:00.
