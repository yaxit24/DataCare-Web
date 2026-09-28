# X13 internal account-balance observation: source and independent fixture

This is the implementation contract for an internal reader, not a route or a ledger-mode authority adapter. It does not make the existing bill preview's closing balance known. No database, browser, SQL Server, VB runtime or new reader was executed to author the independent expectations. The fixture `x13-account-balance-independent-vectors.json` is frozen at SHA256 `32f1d4533a01923972f650ed06c4825f0c4f567d2a44e383f609ed059018e6c7`; its12 cases use literal outputs, not production-calculated goldens.

## Exact source operation

`DC_Main.MsAcBal` at1463–1487 resets six amount/Gold/Silver opening and closing variables to zero. Query1471 groups eligible AC_DATA by AC_CODE with ENTRY_TIME strictly before the formatted cutoff; query1479 uses the inclusive cutoff. Both query the selected company, location, financial year and account **across all books**. There is no VCH_DATE predicate, voucher exclusion, current-book filter, tax/account-master join or posted-document lookup.

Mode comes from the desktop's session `MsDataType`, not BOOK_DATA.DATA_TYPE. Exact modeC omits the DATA_TYPE predicate altogether and includes SQL NULL and other stored types. Every other source mode applies its exact comparison; the proposed internal profile admits only already-resolved A/B/C. A/B must not be inferred from a selected book, a row's data type, a caller's request or whichever mode happens to have rows.

The SQL expressions are:

- Amount: `SUM(CR_AMT - DR_AMT)`. Subtract first; either NULL operand produces a NULL contribution ignored by SUM. A present group with no non-NULL differences remains SQL NULL. Per-operand COALESCE is incorrect.
- Gold: `SUM(CASE WHEN IT_TYPE = 'G' THEN CASE WHEN SIGN = '+' THEN FINE_WT ELSE -FINE_WT END ELSE 0 END)`.
- Silver: the same expression for IT_TYPE S. Any non-plus ordinary SIGN, including SQL NULL or blank, follows negation. A NULL fine remains NULL after either sign branch. Every opposite/other item type contributes literal zero. Therefore one G row with NULL fine can leave Gold NULL, but a G-NULL row plus an S-NULL row yields known zero for both metal sums via each other's ELSE zero. Do not replace this CASE with a filtered SUM.

Only no grouped row leaves the initialized zeros untouched. A returned group with NULL Amount/GoldWt/SilverWt must preserve that NULL and prevent a claim that the complete helper was reproduced. A known Amount alongside NULL GoldWt is useful partial mathematical evidence, not successful complete helper or saved-form loading.

Source1475–1477 and1483–1485 apply `Strings.Format` to the SQL aggregate object (F2 for Amount, F3 for metals), followed by `Conversions.ToDouble`. **These six assignments do not call Val or Fnv.** There is no evidence for importing the tax resolver's NULL→0 rule here. The broader DBNull Format/ToDouble outcome, binary Double limits and locale behavior require original-runtime evidence. The named implementation profile uses current PostgreSQL fixed decimal inputs, where SQL sums of Decimal(18,2) money and Decimal(14,3) fine have exact scale before final textual F2/F3 presentation. This avoids claiming a general Val parser or arbitrary floating-point parity.

## Cutoff and timestamp authority

Saved TR_SALE_RTN:10104 supplies the displayed date from VCH_DATE;10106 formats the clock from VCH_TIME as HH:mm:ss;10197 combines those displayed date/clock values and calls MsAcBal. The helper itself formats the supplied DateTime as `MM/dd/yyyy HH:mm:ss`, dropping fractional seconds. The relevant cutoff is a local wall-clock second, not UTC conversion, midnight, raw VCH_TIME's date or a new browser clock.

The internal reader accepts an already-resolved `YYYY-MM-DD HH:mm:ss`. It validates exact syntax and Gregorian calendar fields without JavaScript Date rollover/timezone parsing. Reject fractional, offset/Z, T separator, impossible date,24:00 and leap-second strings under this explicit profile. A future trusted source-clock adapter must separately observe/preserve the raw voucher date/time, construct the source second and establish import-clock reliability. For example date2024-07-10 with timestamp2024-07-09 12:00:00.900000 supplies cutoff2024-07-10 12:00:00; the reader does not own that adapter.

AC_DATA.ENTRY_TIME is currently timestamp(6) without time zone, while VCH_DATE is Date (schema:10–40). Under this current PostgreSQL profile,12:00:00.000001 is later than the second and excluded from both queries; a row exactly12:00:00 contributes only to helper closing. SQL NULL ENTRY_TIME satisfies neither predicate and is not replaced by VCH_DATE. These microsecond vectors verify current storage comparison; they do not assert unmeasured historical SQL Server datetime quantization or imported clock completeness. Migration20260911020000 widened old date-only values to midnight and could not reconstruct clocks already lost. A known lost-clock import remains an external unresolved prerequisite; a legitimate midnight is not automatically corrupt.

## Agreed internal interface and snapshot

Root owns `observeDesktopAccountBalanceTx(tx,input:unknown)` in a new shared module. Exact input is `{scope:{tenantId,coCode,lcCode,coYear},accountCode,cutoffLocalSecond,mode}`. Reject unknown keys, malformed/nonnative identities and modes. The transaction must already be tenant-bound by its trusted server caller. This function neither authenticates the mode nor starts a public authority path. No book is accepted because the source balance spans books.

A same-statement CTE should collect the complete relevant raw and physical candidate set through the inclusive cutoff, then derive strict-before and inclusive SQL groups from that observation. Use SQL JSONB-text projection before driver numeric coercion; retain exact NULLs, decimal scales, timestamp text and all business fields, plus row_id/xmin/ctid internally. Record group presence separately from count and three nullable aggregate results. Do not page/cap/limit the sum or hash only displayed rows.

Discover normalized scope/account/type candidates for diagnostic purposes but require canonical exact identities for a supported result. A case-equivalent account or A/B DATA_TYPE alongside an exact row must not disappear and produce a false complete sum under unverified SQL Server collation assumptions. Eligible lowercase g/s item types and non-ASCII sign equivalence remain explicitly contained. Foreign tenant/company/location/year/account rows are excluded. ModeC's absence of a DATA_TYPE predicate must remain true; an ordinary unrelated data type does not become an A/B inference. NULL/blank ordinary SIGN is already defined by source CASE and is not a reason to invent plus.

Return the semantic/profile version, exact input identity, complete observations, opaque observation hash, opening and helperClosing `{groupPresent,eligibleRows,amount,gold,silver}`, and diagnostics. No group yields formatted0.00/0.000 with a no-group provenance; present NULL stays NULL and makes overall status unsupported. The labels opening/helperClosing name this helper's observations. They are not the later BILL_TOTAL preview closing, which is calculated from opening and outstanding under separate authority.

The hash must bind contract/profile, exact scope/account/mode/cutoff, raw candidates and physical revisions, aliases/diagnostics, group presence/count and aggregates. Include other-book eligible inserts and same-value physical updates. Excluding later-than-cutoff and NULL-time rows from this narrow observation follows the stated predicate; if a future adapter needs timestamp/import provenance, version those dependencies separately. Present-row deletion/recreation is observable. Empty→insert→delete between observations can restore the same empty-set token; this is not a universal ABA guard or a reservation. Keep SQL grouping and observations coherent in the caller's transaction; a future writer still requires fresh locked/serialized observation.

## Independently pinned distinctions

| Vector family | Expected distinction |
| --- | --- |
| Shared scope across R11/Z09, before/at/after cutoff | A opening14.00/Gold1.000/Silver0; helper closing42.00/Gold2.000/Silver0. B remains20.00/Gold0/Silver2.500. |
| ModeC with A/B/NULL/X | Opening39.00/Gold0.875/Silver2.000; helper closing67.00/Gold1.875/Silver2.000. |
| Future VCH_DATE with earlier ENTRY_TIME; foreign scope sentinels | Future document date is included; foreign scopes/accounts/tenant and after-cutoff rows do not contribute. |
| Empty and NULL-time-only sets | No grouped row, count0, initialized zero values. |
| Both money differences NULL | Present group, AmountNULL, unsupported full-helper profile; no leg coalescing. |
| One NULL difference plus known10 and other-type zero | Amount10.00, known metal zero; distinguishes both wrong money coalescing and wrong filtered metal sums. |
| G-only/S-only NULL fine; two opposite NULL fine rows | Single metal sum NULL blocks helper completeness; opposite-type CASE zeros can resolve both sums to0.000. |
| NULL/blank signs and negative fine | Exact source negation produces Gold−1.500 and Silver+0.500. |
| Fixed decimal cancellation | Money0.10−0.20 plus0.20−0.10 is0.00; signed fine cancellation is0.000. |

Prospective DB verification: insert these raw fixtures only in a unique isolated tenant; call through app_user in a real tenant transaction; compare every group's exact outputs and all contributing row identities. Compare complete raw/xmin/ctid business rows before/after success and refusal. Add exact/malformed calendar keys, missing/extra input fields, alias cases, same-value update, other-book insert, present-row recreation, narrow excluded-row changes and empty-cycle limitation. Use an independent concurrent owner transaction to prove snapshot consistency without replacing SQL responses. Root owns the new reader and build; test ownership is the new `apps/api/test/desktopAccountBalance.db.test.ts`, with the DB lease still requiring explicit coordination. No current API/UI closing capability or existing v1/v2 behavior is changed by this contract.
