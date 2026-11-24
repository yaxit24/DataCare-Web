# WP-20 red report — Ledger Report fine-print data routes and the Lite ageing gate

These tests were written before any implementation. They are red on the current code for the behaviour itself:
the three data routes are not registered (the existing `/reports/account-ledger/:acCode` alias catches them and
returns `400 acCode must be at most 8 characters`), the print refusals do not carry the desktop text, and the
ageing request in Lite is stopped by the ordinary rights check instead of the edition gate.

## Commands run

- Unit file (standalone, no database needed):
  `ALLOW_SKIP_DB_TESTS=1 pnpm --filter @datacare/api exec vitest run test/ledgerFinePrints.test.ts`
- Final combined run (database wrapper, isolated database on the requested port):
  `PARITY_TEST_PORT=55623 node scripts/parity-test-env.mjs -- pnpm --filter @datacare/api exec vitest run test/ledgerFinePrints.test.ts test/ledgerFinePrints.db.test.ts`
- Gate: `pnpm typecheck:tests`, `pnpm exec eslint apps/api/test/ledgerFinePrints*.ts`,
  `pnpm exec prettier --check apps/api/test/ledgerFinePrints*.ts` — all pass (ESLint reports only
  "File ignored because no matching configuration was supplied", 0 errors).

Final combined result: `Test Files 2 failed (2)`, `Tests 11 failed | 7 passed (18)`. The 7 passing tests are the
self-contained kernel vectors in `ledgerFinePrints.test.ts`; they pass now because they compute the expected
desktop arithmetic locally rather than importing an implementation that does not exist yet. They are kept as the
frozen expectation contract. Every one of the 11 failures is a new test failing on the missing behaviour.

## Per-test record

| Case id / test id | Test file and name | Command | Failing line |
|---|---|---|---|
| (route contract) | `ledgerFinePrints.db.test.ts` > "registers the three fine-print data routes and their export siblings" | wrapper command above | `test/ledgerFinePrints.db.test.ts:370` — `expect(printed, \`${route} is not registered\`).toContain(route)` |
| `account-ledger.output.jmaudr-print` | `ledgerFinePrints.db.test.ts` > "JmUdAmt figures ignore OP_LDR and write nothing" | wrapper command above | `test/ledgerFinePrints.db.test.ts:379` — `expect(res.statusCode, res.body).toBe(200)` |
| `account-ledger.output.gold-figures` | `ledgerFinePrints.db.test.ts` > "JmUdFine opening/closing, parameters and title" | wrapper command above | `test/ledgerFinePrints.db.test.ts:393` — `expect(res.statusCode, res.body).toBe(200)` |
| `account-ledger.output.gold-rows` | `ledgerFinePrints.db.test.ts` > "the zero-amount opening-stock fine is kept, old rows excluded" | wrapper command above | `test/ledgerFinePrints.db.test.ts:409` — `expect(res.statusCode, res.body).toBe(200)` |
| `account-ledger.output.silver-print` | `ledgerFinePrints.db.test.ts` > "JmUdFineSl rows and two-decimal balance" | wrapper command above | `test/ledgerFinePrints.db.test.ts:420` — `expect(res.statusCode, res.body).toBe(200)` |
| (exports + no-write) | `ledgerFinePrints.db.test.ts` > "each data route answers its PDF and XLSX siblings and writes nothing" | wrapper command above | `test/ledgerFinePrints.db.test.ts:438` — `expect(pdf.statusCode, ...).toBe(200)` |
| `account-ledger.scope.print-route-rights` | `ledgerFinePrints.db.test.ts` > "every export refuses with the exact desktop text" | wrapper command above | `test/ledgerFinePrints.db.test.ts:464` — `expect(hasText(res.json(), 'You Have No Print Rights.....')).toBe(true)` |
| `account-ledger.scope.print-route-rights` | `ledgerFinePrints.db.test.ts` > "another tenant's account never leaks into a print" | wrapper command above | `test/ledgerFinePrints.db.test.ts:484` — `expect([200, 404], ...).toContain(res.statusCode)` |
| `account-ledger.refuse.no-user-set-row` | `ledgerFinePrints.db.test.ts` > "no USER_SET row refuses with the same text" | wrapper command above | `test/ledgerFinePrints.db.test.ts:505` — `expect(hasText(res.json(), 'You Have No Print Rights.....')).toBe(true)` |
| `account-ledger.refuse.lc-code-empty` | `ledgerFinePrints.db.test.ts` > "silver with no location refuses with the exact text" | wrapper command above | `test/ledgerFinePrints.db.test.ts:522` — `expect(hasText(res.json(), 'Please Select Lc Code and Try...')).toBe(true)` |
| `account-ledger.config.lite-ageing-hidden` | `ledgerFinePrints.test.ts` > "refuses the ageing view in Lite with 403 edition-unavailable" | wrapper command above (also passes standalone with `ALLOW_SKIP_DB_TESTS=1`) | `test/ledgerFinePrints.test.ts:125` — `expect(response.json().error, response.body).toBe('edition-unavailable')` |

## Failing lines (verbatim from the final run)

```
 FAIL  test/ledgerFinePrints.db.test.ts > RP_LEDR fine prints over HTTP > registers the three fine-print data routes and their export siblings
AssertionError: /reports/account-ledger/jama-udhar is not registered: expected '└── /\n    ├── health (GET, HEAD)\n  …' to contain '/reports/account-ledger/jama-udhar'

 FAIL  test/ledgerFinePrints.db.test.ts > RP_LEDR fine prints over HTTP > account-ledger.output.jmaudr-print: JmUdAmt figures ignore OP_LDR and write nothing
AssertionError: {"error":"invalid-request","message":"acCode must be at most 8 characters"}: expected 400 to be 200 // Object.is equality

 FAIL  test/ledgerFinePrints.db.test.ts > RP_LEDR fine prints over HTTP > account-ledger.output.gold-figures: JmUdFine opening/closing, parameters and title
AssertionError: {"error":"invalid-request","message":"acCode must be at most 8 characters"}: expected 400 to be 200 // Object.is equality

 FAIL  test/ledgerFinePrints.db.test.ts > RP_LEDR fine prints over HTTP > account-ledger.output.gold-rows: the zero-amount opening-stock fine is kept, old rows excluded
AssertionError: {"error":"invalid-request","message":"acCode must be at most 8 characters"}: expected 400 to be 200 // Object.is equality

 FAIL  test/ledgerFinePrints.db.test.ts > RP_LEDR fine prints over HTTP > account-ledger.output.silver-print: JmUdFineSl rows and two-decimal balance
AssertionError: {"error":"invalid-request","message":"acCode must be at most 8 characters"}: expected 400 to be 200 // Object.is equality

 FAIL  test/ledgerFinePrints.db.test.ts > RP_LEDR fine prints over HTTP > each data route answers its PDF and XLSX siblings and writes nothing on the export path
AssertionError: /reports/account-ledger/jama-udhar/export.pdf {"error":"invalid-request","message":"acCode must be at most 8 characters"}: expected 400 to be 200 // Object.is equality

 FAIL  test/ledgerFinePrints.db.test.ts > RP_LEDR fine prints over HTTP > account-ledger.scope.print-route-rights: every export refuses with the exact desktop text
AssertionError: expected false to be true // Object.is equality

 FAIL  test/ledgerFinePrints.db.test.ts > RP_LEDR fine prints over HTTP > account-ledger.scope.print-route-rights: another tenant's account never leaks into a print
AssertionError: /reports/account-ledger/jama-udhar {"error":"invalid-request","message":"acCode must be at most 8 characters"}: expected [ 200, 404 ] to include 400

 FAIL  test/ledgerFinePrints.db.test.ts > RP_LEDR fine prints over HTTP > account-ledger.refuse.no-user-set-row: no USER_SET row refuses with the same text
AssertionError: expected false to be true // Object.is equality

 FAIL  test/ledgerFinePrints.db.test.ts > RP_LEDR fine prints over HTTP > account-ledger.refuse.lc-code-empty: silver with no location refuses with the exact text
AssertionError: expected false to be true // Object.is equality

 FAIL  test/ledgerFinePrints.test.ts > account-ledger.config.lite-ageing-hidden — Debit Ageing is gated in Lite (D33/D7) > refuses the ageing view in Lite with 403 edition-unavailable
AssertionError: {"error":"forbidden","form":"Reports/Account Ledger","action":"read"}: expected 'forbidden' to be 'edition-unavailable' // Object.is equality

 Test Files  2 failed (2)
      Tests  11 failed | 7 passed (18)
```

## Failing for the right reason

- The 400s are not a seed or typo problem. `beforeAll` seeded the company, accounts, AC_DATA legs, OP_LDR,
  MAIN_STOCK/ITEM_MAST rows and the login successfully (the tests reach their HTTP assertions). The alias
  `GET /reports/account-ledger/:acCode` in `web/apps/api/src/routes/accountLedger.ts:227` absorbs the new path
  segment, so `jama-udhar` is read as an 11-character `acCode` and fails the 8-character validation. The explicit
  route-registration test names the missing routes directly.
- The 403 bodies on the refusal tests carry the ordinary `forbidden` error, not the desktop text quoted in the
  test comments (`RP_LEDR.cs:8236 {{Interaction.MsgBox((object)"You Have No Print Rights.....", (MsgBoxStyle)0, (object)null);}}`,
  `RP_LEDR.cs:6125 {{Interaction.MsgBox((object)"Please Select Lc Code and Try...", (MsgBoxStyle)0, (object)null);}}`).
  That is the missing behaviour, not a bad assertion.
- The Lite test reaches the rights check and receives `forbidden` instead of `edition-unavailable`; the edition
  gate for the ageing view has not been added.
- No test was weakened, skipped, focused or added to a baseline.

## Blocked cases (no test written, per the case list)

- `account-ledger.output.voucher-wise-row-shapes` — the four per-`MAIN_BOOK` row shapes that `Gold_Summ` /
  `Silver_Summ` re-insert were never read line by line. `cases.md` says a follow-up study packet must read
  `RP_LEDR.cs:8449-8658 {{SELECT * FROM AC_DATA WHERE CO_CODE = '}}` and `RP_LEDR.cs:8680-8830 {{SELECT * FROM AC_DATA WHERE CO_CODE = '}}`
  before expected values can be frozen (decision D6). No owner decision needed.
- `account-ledger.journey.desktop-comparison` — needs a desktop runtime with OP_LDR rows loaded; the case is
  environment-blocked (decision D16). No source question remains.

## Case ids indexed in the test files but exercised by other WP-20 workers

The case list has 49 executable cases, most of them browser-layer OP_LDR ageing cases. This packet's scope is the
Lite ageing gate and the three fine-print data routes, so the ageing/zoom/scope/mfg-type/journey case ids are
indexed in the header comment of `ledgerFinePrints.db.test.ts` as belonging to the WP-20 browser/implement
worker rather than silently dropped. They are not claimed as covered by these tests.

## Assumptions the implement packet must honour

- Data route paths are the literal ones in the packet: `/reports/account-ledger/jama-udhar`, `/gold-fine`,
  `/silver-fine`, each with `/export.pdf` and `/export.xlsx`.
- Query parameters reuse the existing report names: `acCode`, `fromDate`, `toDate` (company, location and year
  come from the session, as in `GET /reports/account-ledger`); `dataType=A` is accepted. The no-location case
  sends `location=` empty on `silver-fine` and expects `400` with `Please Select Lc Code and Try...`.
- The JSON body is not pinned to an invented shape: figure assertions search the response's scalar values and
  its serialised text, so any reasonable `{ rows, totals, parameters }` shape satisfies them.
