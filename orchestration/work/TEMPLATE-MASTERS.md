# New-company template-master comparison

Source oracle: `.wtmp/desktop-template/*.json`, captured from every row of the desktop installer year database
`Next24.BAK` (with `AC_GROUP` confirmed identical in `Next23.BAK`). The self-contained test copy is
`web/apps/api/test/fixtures/desktop-template/`. The desktop copies company 01 defaults to later companies in
`unified/src/csharp/DataCareNext/MS_YEAR.cs:1504-1595`; the web equivalent is new-company-only
`web/apps/api/src/modules/ops/seedCompany.ts`.

“Missing” and “extra” below are row counts against the captured template. For deliberate adaptations, rows are
compared on every fixture business column by `templateMasters.db.test.ts`, but the exception permits a different
row set; the counts therefore describe the current seed shape rather than claiming key-for-key overlap.

| Master       | Template rows | Web rows |    Missing |      Extra | Exception / result                                                                               |
| ------------ | ------------: | -------: | ---------: | ---------: | ------------------------------------------------------------------------------------------------ |
| AC_GROUP     |            35 |       35 |          0 |          0 | Exact parity; all seven business columns are compared.                                           |
| AC_MAST      |            89 |       30 |         89 |         30 | Named web posting-role accounts replace the numeric installer chart (`SYSTEM_ACCOUNTS`).         |
| BOOK_DATA    |           226 |       43 |        226 |         43 | Supported workflow books and web role codes; includes compatibility book IOP.                    |
| BOOK_DETL    |           494 |      146 |        494 |        146 | Named account roles and fail-closed slots from N198/N240 replace numeric installer slots.        |
| BOOK_IDTL    |           341 |        0 |        341 |          0 | Legacy password-bearing detail is not consumed by a web writer.                                  |
| GROUP_MAST   |            24 |        0 |         24 |          0 | Product groups remain user-created.                                                              |
| ITEM_MAST    |            24 |        0 |         24 |          0 | Items remain user-created.                                                                       |
| PRODUCT_MAST |            22 |        0 |         22 |          0 | Products remain user-created.                                                                    |
| TAX_MAST     |            25 |       22 | comparison | comparison | Supported GST/TCS policy uses explicit parent/component rows (G82).                              |
| WEIGHT_MAST  |            36 |        0 |         36 |          0 | Desktop report weight bands are not provisioned.                                                 |
| MFG_MAST     |            20 |        0 |         20 |          0 | Manufacturing workflow defaults are not provisioned.                                             |
| PRINT_MAST   |             9 |        0 |          9 |          0 | Crystal Reports file mappings are desktop-only; web reports use web renderers.                   |
| BAL_GR       |             5 |        0 |          5 |          0 | Desktop trading-account balance groups are not provisioned.                                      |
| CO_SET       |             2 |        1 | comparison | comparison | One web row stores source-backed `SL_AMT_TYPE=N`, `PR_AMT_TYPE=F`; fixture has two edition rows. |
| CO_SET_NEW   |             2 |        0 |          2 |          0 | No row; web settings loaders retain documented defaults.                                         |
| EMP_MAST     |             1 |        0 |          1 |          0 | Web authentication identities replace the installer employee placeholder.                        |
| TABLE_MAST   |             1 |        0 |          1 |          0 | Desktop table/counter placeholder is not provisioned.                                            |
| STATE_MAST   |            37 |        0 |         37 |          0 | Reference geography is not copied per tenant.                                                    |
| COUNTRY_MAST |           151 |        0 |        151 |          0 | Reference geography is not copied per tenant.                                                    |
| COL_MAST     |           699 |        0 |        699 |          0 | Desktop grid-caption overrides are not copied into a web company.                                |
| YEAR_MAST    |             3 |        1 |          3 |          1 | Web creates the current April–March year dynamically, not three historical template years.       |
| LOCT_MAST    |             1 |        1 |          1 |          1 | Web creates Main Counter with BRANCH for Stock In/Out (N91/G105).                                |

`comparison` means the two sets share business keys but differ in row bodies, so a subtraction of totals would be
misleading. The DB test performs the full canonical row comparison and requires every exception to remain an actual
difference; when an exception reaches parity, the test fails until the stale exception is removed.

## Phase 2 (pending, not deliberate)

The owner's parity rule is to copy the desktop. These masters are read by web code and a desktop user expects the
installer defaults in a new company, so the exceptions above are temporary and will be removed by phase 2:
GROUP_MAST, ITEM_MAST, PRODUCT_MAST, WEIGHT_MAST, MFG_MAST, BAL_GR, STATE_MAST, COUNTRY_MAST, EMP_MAST, TABLE_MAST,
CO_SET_NEW and TAX_MAST. The deliberate adaptations are AC_MAST/BOOK_DATA/BOOK_DETL (named posting roles),
BOOK_IDTL (password-bearing), PRINT_MAST (Crystal Reports), COL_MAST (desktop grid captions), YEAR_MAST and
LOCT_MAST (created dynamically). AC_GROUP has no unique key on `(tenant_id, CO_CODE, AC_GR)`; tests must use the
seeded desktop groups rather than inserting their own.

## Provisioning safety

The account-group seed is insert-if-absent on `(tenant_id, CO_CODE, AC_GR)` inside the existing tenant transaction.
It is invoked only by `seedCompany`; there is no migration or backfill, so existing tenants are unchanged.
