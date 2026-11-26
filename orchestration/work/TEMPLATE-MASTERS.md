# New-company template-master comparison

Source oracle: `.wtmp/desktop-template/*.json`, captured from every row of the desktop installer year database
`Next24.BAK` (with `AC_GROUP` confirmed identical in `Next23.BAK`). The self-contained test copy is
`web/apps/api/test/fixtures/desktop-template/`. The desktop copies company 01 defaults to later companies in
`unified/src/csharp/DataCareNext/MS_YEAR.cs:1504-1595`; the web equivalent is new-company-only
`web/apps/api/src/modules/ops/seedCompany.ts`.

“Missing” and “extra” below are row counts against the captured template. For deliberate adaptations, rows are
compared on every fixture business column by `templateMasters.db.test.ts` (using the desktop new-company
projection for the seven newly copied masters), but the exception permits a different
row set; the counts therefore describe the current seed shape rather than claiming key-for-key overlap.

| Master       | Template rows | Web rows |    Missing |      Extra | Exception / result                                                                               |
| ------------ | ------------: | -------: | ---------: | ---------: | ------------------------------------------------------------------------------------------------ |
| AC_GROUP     |            35 |       35 |          0 |          0 | Exact parity; all seven business columns are compared.                                           |
| AC_MAST      |            89 |       30 |         89 |         30 | Named web posting-role accounts replace the numeric installer chart (`SYSTEM_ACCOUNTS`).         |
| BOOK_DATA    |           226 |       43 |        226 |         43 | Supported workflow books and web role codes; includes compatibility book IOP.                    |
| BOOK_DETL    |           494 |      146 |        494 |        146 | Named account roles and fail-closed slots from N198/N240 replace numeric installer slots.        |
| BOOK_IDTL    |           341 |        0 |        341 |          0 | Legacy password-bearing detail is not consumed by a web writer.                                  |
| GROUP_MAST | 24 | 12 | 12 | 0 | New-company projection: company 01, 12 allowed codes, copied columns only (MS_YEAR.cs:1578). |
| ITEM_MAST | 24 | 12 | 12 | 0 | New-company projection: company 01, 12 allowed codes, copied columns only (MS_YEAR.cs:1580). |
| PRODUCT_MAST | 22 | 11 | 11 | 0 | New-company projection: company 01, 11 allowed codes (MS_YEAR.cs:1588). |
| TAX_MAST | 25 | 22 | comparison | comparison | Deliberate G82 exception: installer TDS 0.1% conflicts with existing TCS rate lookup. |
| WEIGHT_MAST | 36 | 0 | 36 | 0 | Deliberate: not copied by MS_YEAR.cs:1504-1595; no CO_CODE. |
| MFG_MAST | 20 | 0 | 20 | 0 | Deliberate: not copied by MS_YEAR.cs:1504-1595, despite having CO_CODE. |
| PRINT_MAST   |             9 |        0 |          9 |          0 | Crystal Reports file mappings are desktop-only; web reports use web renderers.                   |
| BAL_GR | 5 | 5 | 0 | 0 | All five company 01 rows; only the 10 copied columns (MS_YEAR.cs:1562). |
| CO_SET       |             2 |        1 | comparison | comparison | One web row stores source-backed `SL_AMT_TYPE=N`, `PR_AMT_TYPE=F`; fixture has two edition rows. |
| CO_SET_NEW | 2 | 1 | 1 | 0 | Company 01 settings, all 69 copied columns including CO_CODE (MS_YEAR.cs:1570). |
| EMP_MAST | 1 | 1 | 0 | 0 | Employee 001; eight copied columns, no payroll-field copy (MS_YEAR.cs:1576). |
| TABLE_MAST | 1 | 1 | 0 | 0 | Table 001; four copied columns, original LC_CODE retained (MS_YEAR.cs:1590). |
| STATE_MAST | 37 | 0 | 37 | 0 | Deliberate: shared geography has no CO_CODE and is not copied by MS_YEAR.cs:1504-1595. |
| COUNTRY_MAST | 151 | 0 | 151 | 0 | Deliberate: shared geography has no CO_CODE and is not copied by MS_YEAR.cs:1504-1595. |
| COL_MAST     |           699 |        0 |        699 |          0 | Desktop grid-caption overrides are not copied into a web company.                                |
| YEAR_MAST    |             3 |        1 |          3 |          1 | Web creates the current April–March year dynamically, not three historical template years.       |
| LOCT_MAST    |             1 |        1 |          1 |          1 | Web creates Main Counter with BRANCH for Stock In/Out (N91/G105).                                |

`comparison` means the two sets share business keys but differ in row bodies, so a subtraction of totals would be
misleading. The DB test performs the full canonical row comparison and requires every exception to remain an actual
difference; when an exception reaches parity, the test fails until the stale exception is removed.

## Phase 2 result

GROUP_MAST, ITEM_MAST, PRODUCT_MAST, BAL_GR, CO_SET_NEW, EMP_MAST and TABLE_MAST now follow the
**new-company** branch, `unified/src/csharp/DataCareNext/MS_YEAR.cs:1555-1592`. The installer fixture contains
both company 00 and 01 for several tables; only company 01 is the source. The counts above retain the raw
fixture totals, so the excluded company 00 rows appear as missing. Tests compare the exact new-company
projection, including NULL for fixture columns omitted by the desktop INSERT, rather than treating those
intentional exclusions as parity gaps. Only CO_CODE is rewritten; TABLE_MAST.LC_CODE is retained verbatim.

WEIGHT_MAST, MFG_MAST, STATE_MAST and COUNTRY_MAST are deliberate exclusions: neither branch of
`MS_YEAR.cs:1504-1595` copies them. WEIGHT_MAST and the geography tables have no company column. Their
presence in the installer database does not authorize copying them into each new web company.

TAX_MAST remains a deliberate exception. `MS_YEAR.cs:1592` copies its rows, but the absent installer keys
are VAT 01, CST 02 and TDS 25. TDS 25 has rate 0.1%, already used by web TCS 20. The percentage-only
resolver in `web/apps/api/src/modules/shared/taxPolicy.ts` rejects multiple codes at the same rate, so adding
these defaults would change existing tax behavior. Installer TAX_AC values also name numeric accounts absent
from the web role chart. All 22 G82 rows remain unchanged; no partial installer tax merge is performed.

The earlier deliberate adaptations remain AC_MAST/BOOK_DATA/BOOK_DETL (named posting roles), BOOK_IDTL
(password-bearing), PRINT_MAST (Crystal Reports), COL_MAST (desktop grid captions), YEAR_MAST and LOCT_MAST
(created dynamically). This task does not change them.

## Provisioning safety

All template inserts use the existing seedCompany tenant transaction and freshChart guard, and test absence
with explicit tenant and business-key predicates. No migrations or backfills are added. Established charts
are not populated again, even after a user deletes a seeded master. AC_GROUP and most other legacy master
tables lack unique business-key indexes; tests must not insert duplicates of the seeded defaults.

Schema review: all target tables were checked in `web/packages/db/prisma/schema.prisma`. ITEM_MAST has key
(tenant_id, CO_CODE, IT_CODE), CO_SET_NEW has (tenant_id, CO_CODE); the other newly copied tables use row_id
and explicit business-key absence checks. The runtime security migration
`web/packages/db/prisma/migrations/20260715010000_runtime_schema_security/migration.sql:75-117` enables and
forces tenant RLS on every table with tenant_id. No schema or policy changes are needed.

Database execution is pending supervisor verification; the task environment cannot run Docker/PostgreSQL.
