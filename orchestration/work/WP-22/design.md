# WP-22 design: Company → Year Create (desktop `MS_YEAR`)

Inputs: `study.md` (20 gaps), `cases.md` (74 cases, 8 blocked, 5 N/A entries), the nine decisions in
`orchestration/packets/WP-22.cases.md`. Risk tier A. Desktop citations are copied from the study; the study checked them.
`orchestration/PACKETS.md` and `orchestration/roles/` are not in this worktree (`MISSING: both`); the packets follow `WP-22.cases.md`.

## 1. What is built, in one paragraph

The desktop copies **a baseline subset** of company `01` into a new company's first year (17 tables, narrow column lists,
selected rows). The web copies **everything** (19 tables, wide columns, all rows) through `cloneCompanyTx`. The core change adds
a `selection: 'baseline'` mode to `cloneCompanyTx` and makes `createYear` use it. The old behaviour stays as `selection: 'all'`,
the default, so `cloneCompany` and its callers (the Company package WP-07) do not change until that package chooses to. Then the
alternate-year branch (`ALTER_YEAR = 'Y'`), a lock against two simultaneous creates, and the page's desktop keys and texts.

**Facts found while reading that the study does not state (they shape the design):**

1. `seedCompany` (admin provisioning, `seedCompany.ts`) does **not** use the clone. It writes 29 named accounts (`CASH`, `SALES`,
   `ROUNDOFF` ...), books at location `01`, one location `01` and a year itself; the clone never runs for it because it writes a
   `YEAR_MAST` row, so `createYear` sees `firstYear = false`. The clone runs only when a company with **no** year row calls
   `POST /years` (`year.ts:87`, `:106`). **Every desktop-shaped test `01` (numeric codes, location `00`) and every web-seeded `01`
   (named codes, location `01`, the demo tenant: `server.ts:31`) must give a working company.** The two shapes are the central risk.
2. The desktop filter `CAST(AC_CODE AS INT) < 101` (`MS_YEAR.cs:1560 {{AND CAST(AC_CODE AS INT) < 101}}`) raises an error in PostgreSQL
   on `CASH`, and PostgreSQL does not promise `AND` order. The web filter must be a `CASE` that tests the pattern first.
3. `YEAR_MAST.CO_YEAR` is `VarChar(9)` and about 100 other `CO_YEAR` columns are `VarChar(9)` or `VarChar(10)` (`schema.prisma:6977`).
   The desktop's 15-character code (gap 7) cannot be stored without widening every one of them. No packet is written for it (section 9).
4. `YEAR_MAST` has no unique index (`schema.prisma:6983`), so two simultaneous creates both pass the probe (`year.ts:86`).

## 2. What changes for a new company, table by table

"Web today" is `companyClone.ts` (`COMPANY_CLONE_TABLES`, 20 entries). Desktop: study lines 206-224 and `MS_YEAR.cs:1557-1592`.
Columns are listed by difference only. A row filter applies to the template company `01` (the source).

| # | Table | Web today (rows / columns) | Desktop first year | Change |
|---|---|---|---|---|
| 1 | AC_GROUP | all rows, 5 columns | all rows, same 5 | none |
| 2 | AC_MAST | all rows, 26 columns incl. address, contact, GST, PAN, `DATA_TRFR` copied | `LC_CODE = '00'` and `CAST(AC_CODE AS INT) < 101`; 7 columns + `DATA_TRFR` = `'N'` (`MS_YEAR.cs:1560 {{AND CAST(AC_CODE AS INT) < 101}}`) | rows: location `00` **and** (numeric code < 101 **or** non-numeric code, see Q1); columns: `LC_CODE, AC_CODE, AC_NAME, AC_SHORT, AC_MAIN_GR, AC_GR, AC_GST_TYPE`; `DATA_TRFR` written as constant `'N'` |
| 3 | BAL_GR | all rows | all rows | none |
| 4 | BOOK_DATA | all rows, 21 columns | `LC_CODE = '00'`; 16 columns up to `DATA_TRFR` | rows: location filter (rule L below); drop `USER_EMP_CODE, WITH_MOBILE_ENTRY, MENU_NAME, BOOK_TBL_NAME, BOOK_TBL_DETL` |
| 5 | BOOK_DETL | all rows, 13 columns, **listed twice** (lines 238 and 284) | `LC_CODE = '00'` | rows: location filter; delete the dead second entry (gap 4) |
| 6 | CO_SET | all rows of `01` | all rows | none |
| 7 | CO_SET_NEW | all rows | all rows | none |
| 8 | COL_MAST | all rows | all rows | none |
| 9 | CONV_MAST | all rows | all rows | none |
| 10 | EMP_MAST | all rows, 12 columns | `EMP_CODE = '001'`; 7 columns (`MS_YEAR.cs:1576 {{AND EMP_CODE = '001'}}`) | rows: `EMP_CODE = '001'`; drop `TDS_PRC, TDS_AMT, PF_PRC, PF_AMT, DAY_HOURS` |
| 11 | GROUP_MAST | all rows, 23 columns | `GR_CODE IN ('916','DM','EM','FGL','FSL','GO','OG','ORD','OS','OT','SL','SN')`; 21 columns | rows: that list; drop `RATE_DISPLAY, DATA_TRFR` |
| 12 | ITEM_MAST | all rows, 32 columns | `IT_CODE IN ('999','DM','EM','FSL','HM','OG','ORG','ORS','OS','OT','RD','SN')`; same columns | rows: that list |
| 13 | LOCT_MAST | all rows, 9 columns | `LC_CODE = '00'` (`MS_YEAR.cs:1582 {{AND LC_CODE = '00'}}`); the desktop also writes a second copy to its master database | rows: location filter (rule L). The master-database copy does not exist on the web. |
| 14 | PRINT_MAST | all rows | all rows | none |
| 15 | PRODUCT_MAST | all rows | `PR_CODE IN ('DM','EM','FN','HM','OD','OG','OR','OS','OT','RD','SN')` | rows: that list |
| 16 | TABLE_MAST | all rows | `TABLE_CODE = '001'` (`MS_YEAR.cs:1590 {{AND TABLE_CODE = '001'}}`) | rows: that code |
| 17 | TAX_MAST | all rows | all rows | none |
| – | AC_MAST_SRNO | all rows (web-only table) | never copied | removed from the first-year copy (gap 3) |
| – | BANK_RECONCILE | all rows (web-only table) | never copied; the desktop purge empties it | removed from the first-year copy (gap 3) |

**Rule L (the location).** The desktop template always has location `00`. A web-seeded template has only location `01`. The baseline
location is `00` when the template has any `LOCT_MAST` row `00`; otherwise the template's lowest `LC_CODE` (Q2). It is computed once
per call and used for AC_MAST, BOOK_DATA, BOOK_DETL and LOCT_MAST, so the four tables always agree.
**Rule N (non-numeric account codes).** A code that does not match `^[0-9]+$` is kept (Q1); the web's literal system accounts
(`SYSTEM_ACCOUNTS`) are exactly such codes and the posting writers resolve them by name.

`selection: 'all'` keeps today's behaviour for every table, including the two web-only tables and the double `BOOK_DETL` (harmless: it
is skipped once the first entry has written rows). Existing tests that call `cloneCompany` directly are therefore unchanged.

## 3. What must not change: the rows the writers find at posting time

Resolvers that read the copied tables, all keyed by `tenant_id, CO_CODE, LC_CODE, CO_BOOK`:

| Resolver | File | Reads | Still found because |
|---|---|---|---|
| `resolveBookPolicyTx` | `shared/bookPolicy.ts:57` | BOOK_DATA | BOOK_DATA rows of the baseline location are copied with `MAIN_BOOK, BOOK_INOUT, BOOK_SNAME` (kept columns) |
| `resolveBookAccountTx`, `resolveBookSlotRowTx` | `shared/bookPolicy.ts:124`, `:160` | BOOK_DETL, row `SR_NO` | BOOK_DETL rows of the same location are copied with `AC_CODE`; the integrity check below proves each `AC_CODE` exists in AC_MAST |
| `resolveBookSlotAccountTx`, `resolveBookSlotRowsTx` | `shared/postingAccounts.ts:100`, `:151` | BOOK_DETL + AC_MAST | same |
| `resolveTaxPolicyTx` | `shared/taxPolicy.ts:29` | TAX_MAST | TAX_MAST is copied whole; unchanged |
| login scope (`resolveLoginScope`) | `auth/businessScope.ts` | LOCT_MAST, YEAR_MAST | the baseline location is copied; the year row is written by `createYear` itself |

**The safety net (new, runs inside the same transaction):** after a `baseline` copy, `assertBaselineUsableTx` must find
(a) at least one `LOCT_MAST` row, (b) every `BOOK_DATA` row has at least one `BOOK_DETL` row and the reverse, (c) every non-empty
`BOOK_DETL.AC_CODE`, `TAX_MAST.TAX_AC`, `GROUP_MAST.SALE_AC` and `PURC_AC` exists in the company's `AC_MAST`. Otherwise it throws
and the whole `createYear` rolls back, so a company with a book that cannot post is never left behind. This turns the silent failure
("a missing account shows up weeks later as a posting that cannot resolve") into a loud refusal at creation.

Proof that each shape still works (tests `t-pin`, `t-copy-a`): (i) a template built by `seedCompany('01')` (named codes, location `01`):
create company `04`'s first year, then resolve slots 1, 2, 3 of the `SAL` book and the tax policy for a GST code and compare with
company `01`; (ii) a desktop-shaped template (numeric codes, location `00`, accounts 050/100/101): same resolvers, and account 101
absent from the new company.

## 4. Ordering inside `cloneCompanyTx` and the one function boundary

`createYear` calls `cloneCompanyTx(tx, tenantId, coCode, { selection: 'baseline' })`. The new option, the table specs
(`baselineColumns`, `baselineWhere`, `baselineConstants`, `baseline: false`), and `assertBaselineUsableTx` all live in
`companyClone.ts` (531 lines now; budget +120, far below 1,500). WP-07 reuses the same call and can pass `selection: 'baseline'`
(desktop default branch). "Import All Party" (gap 5) would be a third value, `selection: 'import'`, not built here (blocked).
Static SQL only: every filter is a literal string constant in the table spec; no value from a request reaches the SQL text.
`txn.ts` is untouched by the copy change.

## 5. The alternate-year branch

Company flag: `CO_MAST.ALTER_YEAR = 'Y'` (`MS_OPNCOMP.cs:475 {{DC_Main.MsAlterYear = Conversions.ToString}}`). It is read **on the server** inside
`createYear`; a request body cannot set it.

| Item | Rule | Desktop |
|---|---|---|
| Default month | current month, two digits | `MS_YEAR.cs:1012 {{tMonth.Text = Strings.Mid(Conversions.ToString(DateAndTime.Today), 4, 2);}}` |
| Default code | Apr-Dec `Y-(Y+1)`; Jan-Mar `(Y-1)-Y` | study Calculations |
| Default opening / closing | `01/MM/Y` and `01/MM/(Y+1)`; Jan-Mar: opening year is `Y` (the later year) | `MS_YEAR.cs:1016 {{mOpDate.Text = "01/" + tMonth.Text + "/" + Strings.Mid(tYearCode.Text, 1, 4);}}`, `MS_YEAR.cs:1017 {{mClDate.Text = "01/" + tMonth.Text + "/" + Strings.Mid(tYearCode.Text, 6, 4);}}` |
| Month from opening | on a valid opening date the month field takes its month | `MS_YEAR.cs:1111 {{tMonth.Text = Strings.Mid(mOpDate.Text, 4, 2);}}` |
| Stored key | `CO_YEAR` = first four characters of the code + month, e.g. `202611` | `MS_YEAR.cs:1189 {{dataRow["CO_YEAR"] = Strings.Mid(tYearCode.Text, 1, 4) + tMonth.Text;}}` |
| `OLD_METHOD` | `N` (standard keeps `Y`) | `MS_YEAR.cs:1197 {{dataRow["OLD_METHOD"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(}}` |
| `YEAR_MONTH` | the month, two digits | `MS_YEAR.cs:1198 {{dataRow["YEAR_MONTH"] = tMonth.Text;}}` |

Jan-Mar subtlety, resolved by the cases: code `2026-2027` with clock 15 February 2027 gives opening `2027-02-01`, closing `2028-02-01`,
key `202602` (first four characters of the code are `2026`; the opening year is the code's second year). The key and the opening year
differ here by design; do not "fix" it.

**API.** `POST /years` body is unchanged (`coYear`, optional `opDate`, `clDate`, `yearMonth`). For an alternate company `createYear`
reads the flag, derives month from `yearMonth` or the opening date, stores the key above, `OLD_METHOD 'N'`, and detects a duplicate on the
**key** (so `2026-2027` month 11 twice is refused). The user-facing code in the response stays the typed code plus a `coYearKey` field. The
page needs the flag and defaults: add `GET /years/context` returning `{ alterYear: boolean, today-derived defaults are computed in the page }`;
route policy gets the new route under `Masters/Year Create` (`routePolicy.ts:918`), registered with at most two added lines in `txn.ts`
(the handler lives in a new file). Pure functions go to `@datacare/core` (`fiscalYear.ts`, 67 lines now): `alternateYearDefaults(today)`,
`alternateYearKey(code, month)`; kernel vectors in `packages/core/test`.
UAE rule (gap 10): not built.

## 6. Concurrency and failure

- **Lock.** First statement of `createYear`'s transaction: `SELECT pg_advisory_xact_lock(hashtext($1))` with `year-create:<tenant>:<company>`
  (same pattern as `addressMaster.ts:128`). The second request waits, then sees the row and is refused with `year 2026-2027 already exists`.
  No migration and no unique index: an index could fail on existing desktop-imported duplicates (Q4).
- **Atomicity.** The year row, the copy and `assertBaselineUsableTx` run in one `withTxBudget(... 'heavy')` transaction (30 s). A failure rolls back all of it.
- **Tenant isolation.** Every statement keeps `tenant_id=$1` explicitly (the clone already does, `companyClone.ts:495-513`); the new `baselineWhere`
  fragments only add conditions. The `01` source rows are selected with the same tenant predicate; a test with a second tenant proves it.

## 7. The page (`masters/year-create/page.tsx`, 238 lines)

Only what the cases need. Desktop keys and texts (study Keyboard and Rules):

| Change | Desktop |
|---|---|
| Defaults on open and after Cancel: code, month, opening, closing per section 5 / study Calculations; focus on the year-code field | `MS_YEAR.cs:1054 {{((Control)tYearCode).Focus();}}` |
| Buttons `&Save`, `&Cancel`, `E&xit` with Alt+S, Alt+C, Alt+X; no Delete, no Print | `MS_YEAR.cs:644 {{"&Save"}}` |
| Enter in the code moves to the opening date; Enter in the opening date validates, then moves to the closing date; an invalid date keeps focus and shows `Date Not Valid...` or `Month Not Valid...` and clears to `__/__/____` | `MS_YEAR.cs:1105 {{DC_Main.SetDate(ref MsDate);}}`, `DC_Main.cs:1644 {{Date Not Valid...}}`, `DC_Main.cs:1664 {{Month Not Valid...}}` |
| Esc closes the screen | `MS_YEAR.cs:955 {{if ((int)e.KeyCode == 27)}}` |
| Typed characters upper-case; the apostrophe is ignored | `MS_YEAR.cs:942 {{num = (short)Strings.Asc(Strings.UCase(Strings.Chr(unchecked((int)num))));}}`, `MS_YEAR.cs:947 {{e.Handled = true;}}` |
| Month field visible only for an alternate company | `MS_YEAR.cs:887 {{((Control)tMonth).Visible = true;}}` |

Date fields become masked text `dd/mm/yyyy` and are converted to ISO before the request (core already has `formatDesktopDate`). Test ids
(fixed here so the browser tests and the page agree): `year-code`, `year-month`, `year-opening`, `year-closing`, `year-save`, `year-cancel`,
`year-exit`, `year-message`, `year-list`. Not built: Enter-loads-existing-year, edit, print, delete, the 15-character code (blocked, section 9).
The carry-forward panel stays untouched.

## 8. Order of work (so `main` never holds a broken row set)

All packets run on `agent/wp22-year-create` and merge as **one pull request**; CI judges the branch head. Inside the branch each push keeps
every test that exists green, except the new tests that name a not-yet-built change (they are written first, and the supervisor does not
push the branch for CI until the wave that makes them pass is in).

| Wave | Packets (parallel inside a wave) | Why this order |
|---|---|---|
| 1a | `t-pin` (tier B) | Pins first: passes on today's code and must stay passing. `t-copy-a` and `t-copy-b` read it for style. |
| 1b | `t-scope`, `t-copy-a`, `t-copy-b`, `t-alt`, `t-ui` (tests; each writes a different new file, so they run in parallel with each other) | `t-scope` passes today except the concurrency case; the rest fail until wave 2. |
| 2a | `impl-copy` (tier B) | companyClone.ts + one line in `year.ts`. Default `selection` unchanged, so no existing test changes. |
| 2b | `impl-alt` (tier B) | `year.ts` again (lock, alternate year); must follow 2a because both edit `createYear`. Also core, route. |
| 2c | `ui` | needs the route and test ids of 2b. |
| 3 | `review` | independent read of the whole diff, then supervisor decides. |

Table independence: the 17 tables have no foreign keys among them; the copy is not split by table in code. Test packets are split by table
group (A: location, accounts, books, B: masters and settings).

**Existing tests whose numbers change: none**, provided `cloneCompany` keeps `selection: 'all'` as default.
`provisioning.db.test.ts` counts (29 `AC_MAST`, 133 `BOOK_DETL`, line 79 and 367) describe `seedCompany`, which is not touched.
`companySettings.db.test.ts:154` (`createYear` then `CO_SET_NEW` count 1) is unaffected (the table is copied whole). `masterSaveFidelity.db.test.ts:169-221`
creates years for a company whose template has no rows, so the copy writes nothing; its duplicate-year assertion `/already exists/` is kept.
`companySettings.db.test.ts:198-240` uses `cloneCompany` directly with a location-`01` template row and expects it copied: kept because the default is `'all'`.
If the supervisor decides `cloneCompany` should default to `baseline` (Q3), that test and its `LC_CODE` expectation (line 228) must change in a tests packet.

## 9. Case → layer → packet

Layers: `unit` = vitest without a database, `db` = `pnpm --filter @datacare/api test` on the isolated database (CI only here),
`browser` = `apps/web/test/features` (CI only). Packet names are `WP-22.<name>`.

| Cases | Layer | Packet |
|---|---|---|
| `entry.default-apr-dec`, `entry.default-jan-mar`, `entry.cancel-resets-defaults`, `entry.focus-on-year-code`, `entry.lite-menu-visible` | browser | `t-ui` (build: `ui`) |
| `entry.uae-default`, `na.print-no-button`, `na.carry-forward-not-here`, `na.restore-and-purge`, `na.delete-user-form` | N/A entries | none (reasons in `cases.md`) |
| `field.year-code-route`, `field.closing-date-route`, `validate.year-code-blank-refused` | db | `t-scope` |
| `field.opening-date-stored-format`, `lookup.enter-loads-existing-year`, `edit.save-dates-existing-year`, `rights.edit-no-rights-desktop-text`, `copy.import-all-party-prompt`, `copy.import-all-party-copies-every-row`, `journey.party-master-shared`, `messages.success-first-year` | blocked | none (owner decision) |
| `validate.year-code-12-chars-accepted`, `validate.year-code-stops-at-15`, `validate.year-code-any-text-accepted` | browser | **no packet**: needs the `CO_YEAR` width migration across ~100 columns and the dropped `yyyy-yyyy` rule (Q5). Remain failing cases. |
| `validate.closing-before-opening-refused`, `validate.duplicate-year-refused`, `delete.no-delete-action`, `rights.create-refused-message`, `copy.further-year-no-import-prompt`, `journey.first-year-party-then-second-year` | browser | `t-ui` |
| `validate.date-day-invalid-desktop-text`, `validate.month-invalid-desktop-text`, `keyboard.*` (6 cases) | browser | `t-ui` (build: `ui`) |
| `create.first-year-footprint`, `create.further-year-no-copy`, `create.footprint-no-vouchers` | db | `t-pin` |
| `copy.ac-group-rows`, `copy.bal-gr-rows`, `copy.co-set-rows`, `copy.co-set-new-rows`, `copy.col-mast-rows`, `copy.conv-mast-rows`, `copy.print-mast-rows`, `copy.tax-mast-rows`, `copy.emp-mast-rows`, `copy.emp-mast-columns`, `copy.group-mast-rows`, `copy.group-mast-columns`, `copy.item-mast-rows`, `copy.product-mast-rows` | db | `t-copy-b` (build: `impl-copy`) |
| `copy.ac-mast-rows`, `copy.ac-mast-columns`, `copy.book-data-rows`, `copy.book-data-columns`, `copy.book-detl-rows`, `copy.loct-mast-rows`, `copy.table-mast-rows`, `copy.ac-mast-srno-not-copied`, `copy.bank-reconcile-not-copied` | db | `t-copy-a` (build: `impl-copy`) |
| `copy.book-detl-listed-once` | unit | `t-copy-a` (reads `COMPANY_CLONE_TABLES`) |
| `alt.default-apr-dec`, `alt.default-jan-mar`, `alt.start-month-from-opening` | browser (+ unit vectors) | `t-alt` (unit), `t-ui` (browser); build: `impl-alt`, `ui` |
| `alt.create-footprint-apr-dec`, `alt.create-footprint-jan-mar`, `alt.second-year-same-month` | db | `t-alt` (build: `impl-alt`) |
| `rights.create-without-right-refused`, `scope.other-company-same-year-code`, `scope.other-tenant-no-leak`, `scope.body-company-ignored`, `retry.same-request-after-commit`, `rollback.year-row-failure-no-copy` | db | `t-scope` |
| `concurrency.same-year-two-requests` | db | `t-scope` (fails until `impl-alt`'s lock) |
| `rollback.copy-failure-leaves-nothing` | db | `t-pin` |

Not in the table by design: the posting-account proof of section 3 (new, in `t-pin` for the web-seeded shape and `t-copy-a` for the desktop shape).

## 10. Risks and the test that catches each

| Risk (silent unless tested) | Test |
|---|---|
| A posting account no longer resolves (account `>= 101` or filtered; book slot or tax row missing) | `t-pin` resolves slots 1-3 of `SAL`, a GST tax code, on a company created from a `seedCompany` template; `t-copy-a` does it on a desktop-shaped template and asserts account 101 is absent; the runtime `assertBaselineUsableTx` refuses a copy with a dangling reference (`t-copy-a`, case "dangling account refused, nothing written") |
| Location filter yields no books (web-seeded template has only location `01`) | `t-pin`: template from `seedCompany('01', {lcCode:'01'})` must give a company whose `BOOK_DATA` count is greater than 0 |
| `CAST(AC_CODE AS INT)` raises on a named code and aborts the whole create | `t-copy-a`: mixed template (`CASH`, `050`, `101`) creates without error |
| A second tenant's baseline rows read or changed | `t-scope` `scope.other-tenant-no-leak`; `t-copy-b` adds a same-company-code row in tenant B and asserts it is neither read nor changed |
| A half-finished copy after a failure | `t-pin` `rollback.copy-failure-leaves-nothing` (trigger on `TAX_MAST` raises; zero rows in every copied table); `t-scope` `rollback.year-row-failure-no-copy` |
| Two requests create the same year | `t-scope` `concurrency.same-year-two-requests` (`Promise.all` of two calls on two connections; exactly one fulfils; one `YEAR_MAST` row; `AC_GROUP` count equals the template's) |
| Alternate-year key breaks code that parses `CO_YEAR` as `yyyy-yyyy` | `t-alt` posts a voucher date check (`assertFiscalDateTx`) in year `202611` and lists years; `review` greps for `split('-')` and `slice(0, 4)` on a year code |
| Alternate-year flag taken from the request | `t-alt`: body `alterYear:'Y'` on a standard company is ignored |
| Wide-column data leaks (address, PAN, GST) to the new company | `t-copy-a` `copy.ac-mast-columns`: those columns are NULL in the new company |
| `DATA_TRFR = 'N'` forgotten, so rows sync as transferred | `t-copy-a`: every new `AC_MAST` row has `DATA_TRFR = 'N'` |

## 11. Questions for the owner (also in the report)

- **Q1** Non-numeric account codes are kept (rule N). The desktop has none, so this is a web rule.
- **Q2** Baseline location is `00`, or the template's lowest location when `00` is absent. Otherwise the demo tenant's Year Create would break.
- **Q3** `cloneCompany` default stays `'all'`; WP-07 chooses. Changing it changes `companySettings.db.test.ts:198-240`.
- **Q4** No unique index on `YEAR_MAST`; an advisory lock instead. An index needs a duplicate scan of production data first.
- **Q5** The 15-character, any-format year code is not built: it needs a migration of ~100 `CO_YEAR` columns and loses the `yyyy-yyyy` guard.
- **Q6** The runtime integrity check (section 3) refuses the create when a template is inconsistent; the desktop never refuses.
