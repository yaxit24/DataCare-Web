# X13 internal account-balance reader: focused verification

The new internal reader passed54 PostgreSQL tests on its first run. A subsequent combined run passed420 tests in14 files, covering the reader and existing saved Return metadata, empty-header, configuration, v1 row replay, v2 bill replay and route-policy checks. No fixture, expected-value or runtime correction was needed between these runs. The database lease was released after completion.

The reader is an internal prerequisite only. Its caller must already own a resolved A/B/C mode and qualified local whole-second cutoff in a matching tenant-bound RepeatableRead or Serializable transaction. This work does not add a route, resolve a session mode, change existing preview tokens or grant a known closing balance. The fixed-decimal PostgreSQL observation profile does not assert complete original VB/SQL Server runtime equivalence, historical clock reconstruction, numeric persistence or desktop acceptance.

## Independent inputs

`x13-account-balance-independent-vectors.json` and the byte-identical local test fixture retain SHA256 `32f1d4533a01923972f650ed06c4825f0c4f567d2a44e383f609ed059018e6c7`. All12 expected cases were literal source derivations before inspecting the new reader. The only fixture adaptation substitutes isolated service/foreign tenant identifiers; no numeric output was derived from production code. The separate independent review `x13-account-balance-vector-independent-review.json` confirms all12 against DC_Main1463–1487 without executing the reader.

The main vectors distinguish A14.00→42.00, B20.00→20.00 and C39.00→67.00, with exact Gold/Silver balances, across different books. C includes NULL and unrelated stored data types. An exactly-at-cutoff row belongs only to helper closing, one microsecond after belongs to neither, and a future VCH_DATE with earlier ENTRY_TIME remains eligible. Foreign tenant/company/location/year/account and NULL entry-clock rows are excluded by the stated predicate.

Grouped SQL NULL stays distinct from no group. The tests reject per-leg COALESCE and filtered-metal SUM behavior: CR−DR is evaluated before SUM; Gold/Silver use complete source CASE with opposite-type zeros; NULL/blank SIGN takes the non-plus negation branch. A monetary subtotal10 with NULL Gold or Silver remains an unsupported complete-helper observation. Two opposite NULL metal rows can correctly resolve both sums to0 because of the other row's CASE zero.

## Actual engineering checks

The54 cases additionally verify:

- Complete raw business values, preserved decimal scales/NULL/microseconds, both contributing books, raw SQL groups, physical row IDs/xmin/ctid and explicit local timestamps.
- Strict request shape, canonical keys and Gregorian cutoff validation without guessed mode/default year/book; short legitimate company/location keys and a10-character financial-year key remain usable.
- Refusal of unbound/wrong-tenant/default Read Committed context; existing tenant-bound Serializable works. A real second owner client changes data between two reads inside RepeatableRead; both reads remain identical and a subsequent transaction sees the changed amount.
- Same-value physical updates, eligible other-book insertion and present-row recreation invalidate observation versions. Later, NULL-time and foreign-scope rows do not enter the narrow token. The empty→insert→delete cycle can restore the empty token, explicitly documenting the absence-history limitation.
- Account/year/mode/metal/sign comparison aliases are returned as unsupported with observations/raw groups retained and no apparently complete numeric phase.
-151 contributing rows are all observed and summed in one actual reader SQL statement. The test only counts the real SQL method calls; no query result is replaced or mocked.
- Two maximum stored monetary/fine values produce exact19999999999999999.98 and199999999999.998 sums without JavaScript Number coercion. This is current fixed-decimal intent, not a claim about the original final Double conversion. PostgreSQL numeric NaN remains present in raw/group observations but yields unsupported/null monetary output.
- Before and after success and refusal, all27 observed business/configuration/master/counter tables preserve complete raw rows and physical revisions in both isolated fixture tenants.

## Recorded runs

| Log | Command from web | Result |
| --- | --- | --- |
| account-balance-db-first.txt | `node scripts/parity-test-env.mjs -- pnpm --filter @datacare/api exec vitest run test/desktopAccountBalance.db.test.ts` |1file54passed,0skipped;12.39s;exit0 |
| account-balance-regressions.txt | Same wrapper with the new reader and13 existing bill/v1/configuration/saved/policy files |14files420passed,0skipped;90.79s;exit0 |

The wrapper verified disposable localhost55433, app_user runtime and forced RLS; only dedicated fixture tenants were inserted/cleaned. No normal application database or real customer data was used. Both actual runs passed on their first invocation; there is no failed reader stage to hide or relabel. Test files were formatted before execution and stayed unchanged thereafter. The earlier source/fixture contract, ready capture and independent review remain frozen. The companion scoped manifest pins current inputs and actual logs. Final full API, strict test compilation, build and browser results belong to root's checkpoint and are not precredited here.
