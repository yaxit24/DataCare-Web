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
| GROUP_MAST | 24 | 12 | 12 | 0 | New-company projection: company 01, 12 allowed codes, copied columns only (MS_YEAR.cs:1578); SALE_AC/PURC_AC mapped to web role accounts (below). |
| ITEM_MAST | 24 | 12 | 12 | 0 | New-company projection: company 01, 12 allowed codes, copied columns only (MS_YEAR.cs:1580). |
| PRODUCT_MAST | 22 | 11 | 11 | 0 | New-company projection: company 01, 11 allowed codes (MS_YEAR.cs:1588). |
| TAX_MAST | 25 | 22 | comparison | comparison | Deliberate G82 exception: installer TDS 0.1% conflicts with existing TCS rate lookup. |
| WEIGHT_MAST | 36 | 0 | 36 | 0 | Deliberate: not copied by MS_YEAR.cs:1504-1595; no CO_CODE. |
| MFG_MAST | 20 | 0 | 20 | 0 | Deliberate: not copied by MS_YEAR.cs:1504-1595, despite having CO_CODE. |
| PRINT_MAST   |             9 |        0 |          9 |          0 | Crystal Reports file mappings are desktop-only; web reports use web renderers.                   |
| BAL_GR | 5 | 5 | 0 | 0 | All five company 01 rows; only the 10 copied columns (MS_YEAR.cs:1562); account columns mapped to web role accounts (below). |
| CO_SET | 2 | 1 | 1 | 0 | Company 01's whole row, all 58 copied columns (MS_YEAR.cs:1568); an established company keeps the minimal `SL_AMT_TYPE=N`, `PR_AMT_TYPE=F` row. |
| CONV_MAST | 1 | 1 | 0 | 0 | Company 01 row INR, 15 copied columns (MS_YEAR.cs:1574); `CURRENCY_RATE` is numeric(18,2) in the web schema, so 82.772 is stored as 82.77. |
| CO_SET_NEW | 2 | 1 | 1 | 0 | Company 01 settings, all 69 copied columns including CO_CODE (MS_YEAR.cs:1570). |
| EMP_MAST | 1 | 1 | 0 | 0 | Employee 001; eight copied columns, no payroll-field copy (MS_YEAR.cs:1576). |
| TABLE_MAST | 1 | 1 | 0 | 0 | Table 001; four copied columns; LC_CODE is the company's location, not the installer's '00' (adaptation below). |
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
intentional exclusions as parity gaps. CO_CODE is rewritten, and the two adaptations below apply (account codes, TABLE_MAST location).

WEIGHT_MAST, MFG_MAST, STATE_MAST and COUNTRY_MAST are deliberate exclusions: neither branch of
`MS_YEAR.cs:1504-1595` copies them. WEIGHT_MAST and the geography tables have no company column. Their
presence in the installer database does not authorize copying them into each new web company.

## Adaptations of copied values

**Account codes (GROUP_MAST, BAL_GR).** The installer rows name installer AC_MAST accounts 00003-00035, which a web
company does not have (its chart is the named role accounts of `SYSTEM_ACCOUNTS`). The sale and purchase writers
post to `GROUP_MAST.SALE_AC` / `PURC_AC` without checking AC_MAST, so an unmapped code would post to a nameless
account. `DESKTOP_ACCOUNT_ROLES` in `desktopTemplateMasters.ts` maps each code to the web account of the same meaning
(the same roles `bookTemplates.ts` `DESKTOP_DEFAULT_ACCOUNT_ROLES` already uses for 00003-00006 and 00008-00009). A
code with no web account of the same meaning is left blank (NULL) and none is invented. The three accounts the desktop posts old silver purchases and other-type sales/purchases to (00011, 00007, 00012; Ac_Ledr.cs:44/50, :308) did not exist in the web chart, so `OLDSLVPR` (AC_CODE is varchar(8)), `OTHSALE` and `OTHPURC` are added to `SYSTEM_ACCOUNTS` with the installer names and groups. They are insert-if-absent, so an established company only gains the rows when it is re-provisioned.

| Installer code | Installer AC_MAST name                  | Web account | Used by                      |
| -------------- | --------------------------------------- | ----------- | ---------------------------- |
| 00003          | SALES GOLD A/C                          | SALES       | GROUP_MAST sale, BAL_GR GO   |
| 00004          | SALES SILVER A/C                        | SLVSALE     | GROUP_MAST sale, BAL_GR SL   |
| 00005          | SALES OLD GOLD A/C                      | OG          | GROUP_MAST sale, BAL_GR OG   |
| 00006          | SALES OLD SILVER A/C                    | OS          | GROUP_MAST sale, BAL_GR OS   |
| 00007          | SALES OTHER A/C                         | OTHSALE     | new web system account, group 25 |
| 00008          | PURCHASE GOLD A/C                       | PURCHASE    | GROUP_MAST purchase, BAL_GR  |
| 00009          | PURCHASE SILVER A/C                     | SLVPURC     | GROUP_MAST purchase, BAL_GR  |
| 00010          | PURCHASE OLD GOLD A/C                   | OLDGOLD     | GROUP_MAST purchase, BAL_GR  |
| 00011          | PURCHASE OLD SILVER A/C                 | OLDSLVPR    | new web system account, group 30 |
| 00012          | PURCHASE OTHER A/C                      | OTHPURC     | new web system account, group 30 |
| 00021-00025    | CLG.STOCK ... A/C (gold, silver, old gold, old silver, other) | (blank) | BAL_GR CLG_AC; no closing-stock accounts in the web chart |
| 00026-00030    | CLOSING STOCK - P & L - ...             | (blank)     | BAL_GR CLOSING_AC; same      |
| 00031-00035    | OPNING STOCK- ...                       | (blank)     | BAL_GR OP_AC; same           |

Nothing in the web reads the BAL_GR stock accounts (only TRAD_TYPE and TRAD_NAME are read, by Group master), so the
blanks cost nothing today. `templateMastersPosting.db.test.ts` proves that every account the seeded rows name exists in
AC_MAST and that a sale and a purchase of the seeded gold ornament ORG post only to existing accounts.

**TABLE_MAST location.** The desktop copies the counter with the location it is created in; a web company's location
is `opts.lcCode ?? '01'`, so TABLE_MAST.LC_CODE takes that value instead of the installer's '00'.

**CO_SET.** The desktop copies company 01's whole CO_SET row (MS_YEAR.cs:1568): TAX_ROF 2, LBR_ROF 0, ITM_RATE_ROF 0,
TAX_CODE 10, PURC_WITH_LBR Y and the rest. A fresh web company now gets that row (insert-if-absent, fresh company
only), so it rounds like the desktop throughout. With CO_SET_NEW.TOT_AMT_ROF 0 the bill total is a whole rupee, so
most fresh-company bills now carry the web's round-off leg (leg 99, ROUNDOFF). That is the web's balancing leg, which
the desktop does not write (`web/docs/FIRST-REAL-COMPARISON.md` section 3.4); it is unchanged here.

## Known gaps

- `CO_SET.AC_LC_CODE_LEN` ('1' in the installer row) is a code-GENERATION mode on the desktop (MS_ACCT.cs:6285, :7741, :8789-8800), never a length check on a typed code. The web Accounts master used to refuse every account save with a code of another length; that check is removed (`master.service.ts`), and `templateMastersPosting.db.test.ts` creates an account and edits CASH on a fresh company.
- The installer CO_SET carries values the web settings catalog does not list as options (FINE_STK_TYPE 'F', DHRN_PRC 2). They are copied as the desktop has them and left as they are.
- A fresh company has CASH_LIMIT 0 (no 2-lakh cash refusal), as on a fresh desktop company.
- The seeded other-type items (DM, EM, HM, OT, RD, SN; IT_TYPE 'O') are refused by the current sale and purchase
  writers. That is an existing web limitation of those writers, not something the seed changes.

TAX_MAST remains a deliberate exception. `MS_YEAR.cs:1592` copies its rows, but the absent installer keys
are VAT 01, CST 02 and TDS 25. The installer TCS 20 is 0.075% (the web G82 seed made it 0.1%); TDS 25 is 0.1%,
which is the web TCS rate, and VAT 01 and CST 02 are both 1%, which would also collide with each other. The percentage-only
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

The database tests (`templateMasters.db.test.ts`, `templateMastersPosting.db.test.ts`) run in the isolated parity database.
