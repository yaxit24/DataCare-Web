# Data Refresh

## Milestone state

Company → Data Refresh remains **PARTIAL**. PR-1 exposes the six operator-visible `MS_UPDATE` actions in desktop tab order and implements only Approval Adj as a complete writer. Desktop-match coverage remains 0% because no case has run on the original Windows desktop.

The web deliberately uses preview-first, audited, idempotent execution. A preview writes no business row, but it appends a `data_repair_run` audit row, so it is not literally read-only. Apply re-derives the candidate set under the repair lock and writes the business changes plus the applied audit record in one transaction.

## Operator surface

The screen shows exactly these actions:

1. Account
2. Stock
3. Field Update
4. Approval Adj
5. Image Data
6. Old Field

This order follows the controls' desktop declaration and tab order (`MS_UPDATE.cs:1371-1504,1606-1615`). Ctrl+O reveals eleven vendor controls and conditionally Scheme Data on the desktop (`MS_UPDATE.cs:2275-2301`); none is exposed on the web. Mfg Refresh is edition/setting controlled (`MS_UPDATE.cs:2178-2183`) and is also absent.

Account and Stock locally check `UserPrint` and answer `You Have No Print Rights.....` (`MS_UPDATE.cs:2334-2342,2671-2679`). Approval Adj and Image Data do not contain that local check (`MS_UPDATE.cs:8809-9038`). The owner chose one consistent Data Refresh Print boundary for all six web actions. The current Data Repair endpoints are admin-only, but the exact `USER_SET.SUB_MENU = 'Data Refresh'` Print-right handoff remains the G225 blocked case because `routePolicy.ts` and `formCatalog.ts` are owned by active work outside this milestone.

## Operation classifications

### Account: preview-only

The preview identifies the independently safe prefix of the desktop action:

- blank `BOOK_DATA.DATA_TYPE` and `BOOK_DETL.DATA_TYPE` values;
- `CASH_DATA.CLR_DATE IS NULL` where a voucher date exists;
- the scoped `BANK_RECONCILE` replacement derived from ledger rows in account groups 02, 22 and 23.

The desktop then calls `AcRefresh()` and a long `Ac_Ledr`, `Ac_Rojmel` and `Ac_Tax` builder sequence (`MS_UPDATE.cs:2334-2669`). That complete graph is not proved. The full Account operation therefore refuses Apply. The separately named advanced `ledger-normalise` repair remains available; it is not presented as full Account parity.

### Stock: preview-only

The preview reports exact missing-fine candidates from the opening Stock step, using net weight × (touch + wastage) / 100 (`MS_UPDATE.cs:2671-2705`). The complete `StockRefresh()` and `Ac_Stock` builder graph is not proved (`MS_UPDATE.cs:2671-3047`), so the full Stock operation refuses Apply. The separately named advanced `stock-fine-refresh` operation remains available and is not relabelled as full Stock parity.

### Field Update and Old Field: classification pending

These actions cover about 27,700 lines of legacy updates. D-REF-3 requires each statement to be classified as a web-reachable repair, an old-desktop-only anomaly query, or migration-loader work before implementation. PR-1 exposes both captions and an audited classification preview, with no Apply.

### Approval Adj: implemented

For the selected tenant, company, location and year, Approval Adj sets each `APR_DETL` `BOOK_NAME='APR ISU'` row's final `ISU_REC` to `Y` exactly when a matching consumed row exists, otherwise `N`. The consumed sources are:

- `APR_DETL`, `BOOK_NAME='APR RTN'`;
- `SL_DETL`, `BOOK_NAME='SALES'`;
- `RATE_CUT_ISU`, `BOOK_NAME='WH SALES'`;
- `RATE_CUT_ISU`, `BOOK_NAME='RATE CUT'`.

Every source requires non-empty `ISU_NO`. Matching is source `ISU_YRCD/ISU_DBCD/ISU_NO/ISU_SRNO` to issue `CO_YEAR/CO_BOOK/VCH_NO/OLD_SRNO`, as in `MS_UPDATE.cs:8815-8817`.

The operation then sets `BAR_DETL.APR_ISU='Y'` only for a tag/serial matching an unconsumed APR ISU row; every other in-scope tag becomes `N` (`MS_UPDATE.cs:8818-8820`). Unlike the desktop's final cross-location-weak update, the web includes tenant, company, location and year containment. Apply writes only `APR_DETL.ISU_REC` and `BAR_DETL.APR_ISU` and returns `Approval Refersh Process Complete.` (`MS_UPDATE.cs:8821`).

The database fixture covers five issue rows consumed by APR RTN, SALES, WH SALES, RATE CUT, and no source; opposite starting flags; invalid book, blank reference, wrong location, wrong year, wrong company, and second-tenant sentinels; complete row snapshots; audit; clean second preview; replay deduplication; and rollback when a fault is injected between the APR and BAR updates.

### Image Data: preview-only

The desktop creates a local SQL Server database/table and adds `MOB_IMAGE`, `IMG_IMPORT` and `CONV_IMAGE` columns (`MS_UPDATE.cs:8825-9038`). The web already has committed, tenant-scoped `TAG_IMAGE_DATA` schema. No source proves semantics for the legacy flags or a byte-copy operation. Runtime `CREATE`/`ALTER`, byte copying and Apply are forbidden in this milestone. The preview reports zero row changes and explains the classification.

## Compatibility and remaining work

`/utilities/data-repair` remains the advanced operation/history console. It also consumes the new apply capability metadata, so it cannot render an Apply control for preview-only operations. Direct API calls are independently refused with `code: preview-only` before a transaction starts.

PR-2 must classify Field Update and Old Field statement by statement. Later work must prove the complete Account and Stock builder graphs, settle G225's Data Refresh caption Print handoff, and define any legacy image migration semantics. No current record claims FULL, accepted, verified desktop parity, or a non-zero desktop match.
