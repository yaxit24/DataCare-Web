# Round 8 column-settings database and authenticated-route verification

The first focused run passed **2 files / 58 tests / 0 skips**: 21 new real service/authenticated HTTP cases in `web/apps/api/test/columnSettings.db.test.ts`, plus the implementation owner's 37 pure cases in `columnSettings.test.ts`. The complete output is `column-settings-db-first.txt`. No product or fixture correction was needed after this run.

Command from `web`:

```sh
node scripts/parity-test-env.mjs -- pnpm --filter @datacare/api test test/columnSettings.db.test.ts test/columnSettings.test.ts
```

Only the disposable PostgreSQL instance on localhost55433 and unique synthetic tenants were used. Test owner credentials seed/clean the fixtures; the actual service and API use the non-owner app runtime with forced tenant RLS. Fastify inject runs real authentication, route policy, service dispatch and PostgreSQL queries; no service/SQL/HTTP response is mocked. This is authenticated route integration, not browser or desktop executable acceptance. Root owns the separate live-browser and final workspace checks.

## Exact contracts checked

The identity is `(tenant, selected company, BOOK_NAME, COL_NAME)`, where BOOK_NAME is the original form family and COL_NAME is the original column name. It is not the former company/name pair and not the mutable caption. GET `/masters/styles` returns the original raw array contract with textual physical row ID, exact six business values, a row version, company collection version, total filtered count, and identity count computed before search filtering. GET `/masters/styles/meta` exposes all three business-key columns and current owning-form capabilities. Both reads set `Cache-Control: no-store`.

POST creates from the explicit family/name and optional caption/repeat/visibility fields. PUT uses the same key, a valid observed row version and partial value changes. DELETE accepts only key/version. POST `/masters/styles/import` retains the existing per-row `{created,failed,errors}` result while using the same validated create path and same absent-key lock. Duplicate imported physical identities remain readable and cannot be updated/deleted by selecting an arbitrary row.

The new 21 cases verify:

1. Exact original identities, NULL caption, blank repeat, numeric identity/total counts, opaque versions and a read with no business-row changes.
2. Full-scope update and delete affect one Return/Fine identity; complete raw/physical snapshots prove same-name Sales/Fine, other company, other tenant and saved business tables unchanged.
3. Another family can create the same original column name independently; omitted values remain NULL and explicit blank caption remains blank.
4. A caption-only edit preserves untouched imported unusual flags and NULLs; an unchanged unusual flag can be resent, explicit caption NULL/blank intent is retained, and a new invalid flag is rejected without writes.
5. Duplicate identity count remains 2 even when a caption search returns just one matching physical row; create/update/delete all refuse that ambiguous key without changing either row.
6. Real owner updates A→B→A change the row token. Stale update/delete fail with 409. Deleting/recreating an identical business row receives a new physical identity and refuses the previous token.
7. Two actual concurrent service creates of one absent key yield one success, one duplicate409, and exactly one physical row.
8. Another family or tenant's row version cannot authorize a change to Return/Fine.
9. An empty filtered family remains an empty read; a subsequent insertion changes the surviving company collection observation. No deleted-history guarantee is inferred from this test.
10. A family with 125 rows returns deterministic pages100+25 with no overlap, complete total125 and one shared collection token. Updating row125 changes the collection token observed on page1 while the first row's own token remains unchanged.
11. Family equality is exact; percent, underscore and backslash in the search are literal characters rather than wildcard matching instructions.
12. Other company/tenant changes cannot alter the selected company's row or collection token.
13. Updating the authoritative Return/Fine visibility through the new service changes the separate incoming-calculation resolver from nominal1000 to0 and changes its observation token, with full saved Return data unchanged and numeric saving still unavailable.
14. Metadata follows existing source-backed authorization: View permits create, while Edit/Delete control existing-row changes. A view-only user receives `{canCreate:true,canUpdate:false,canDelete:false}`, cannot PUT/DELETE, and can create according to that existing policy.
15. Anonymous and unrelated-master access are denied. Changing rights while the same authenticated session remains open changes metadata and action results immediately; revoked View also denies import.
16. Authenticated create→list→PUT→list→DELETE→list uses the new dispatch paths and preserves an unrelated same-name family's values/version.
17. Missing family, missing/malformed version, surrogate-row injection, foreign scope and stale updates refuse changes. The shared request-scope guard returns409 for selected-company/branch/year conflicts; the service returns its precise version conflict error.
18. Authenticated reads and row versions remain tenant-separated, and another tenant refuses the original tenant's token.
19. Import creates two independent family rows, reports duplicate/missing-family rows with exact error positions, preserves the existing duplicate row, and retains explicit NULLs. A non-array import request is400.
20. A real concurrent normal HTTP create and CSV import of the same absent key share one lock and produce exactly one successful creation and one saved row.
21. HTTP pagination/filter validation rejects negative, fractional, excessive and repeated-array values; bounded scalar pagination returns the complete filtered total.

## Limits and provenance

The fixture contains exact same-name sentinels across families/companies/tenants plus saved Return header/parent values with microsecond time, a large decimal, raw NULL and blank data. Snapshot comparisons exclude only the single intended column-setting identity when testing a permitted update/delete. They do not mask unrelated business changes. Authentication/session records are intentionally outside these business snapshots.

Row and collection versions observe surviving physical revisions. They are not durable history across database restore or an absent-row insert/delete cycle. Company cloning, restore and administrator SQL are not asserted to participate in the service's advisory lock. No unique constraint was imposed on unreconciled imported duplicate rows. The test does not authorize renamed-key migration, resolve unknown desktop collation behavior, or prove every source form's use of every column setting.

The independent test file was authored and run by `/root/tour_order_ui`. Production `columnSettings.ts`, master dispatch, app routes and pure tests belong to `/root/design_components`; no product files were edited during this task. The associated `.run.json` pins this test, relevant implementation inputs and the exact passing log. Final full-API/typecheck/browser results are owned by the root checkpoint and were not inferred from this focused pass.
