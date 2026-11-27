# Data Refresh

## Milestone state

Company → Data Refresh remains **PARTIAL**. PR-1 exposes the six operator-visible `MS_UPDATE` actions in desktop tab order and implements Approval Adj as a complete writer; Account adds check-and-repair for the Contra, Fine Jv and Cash/Bank families (below). Desktop-match coverage remains 0% because no case has run on the original Windows desktop.

The web deliberately uses preview-first, audited, idempotent execution. A preview writes no business row, but it appends a `data_repair_run` audit row, so it is not literally read-only. Apply re-derives the candidate set under the repair lock and writes the business changes plus the applied audit record in one transaction.

## Operator surface

The screen shows exactly these actions:

1. Account
2. Stock
3. Field Update
4. Approval Adj
5. Image Data
6. Old Field

This order follows the controls' desktop declaration and tab order (`MS_UPDATE.cs:1371-1504,1606-1615`). After an asynchronous preview, focus moves to the preview heading without adding that heading to the native tab order; after a successful apply removes the preview panel, focus returns to the operation that started it. Ctrl+O reveals eleven vendor controls and conditionally Scheme Data on the desktop (`MS_UPDATE.cs:2275-2301`); none is exposed on the web. Mfg Refresh is edition/setting controlled (`MS_UPDATE.cs:2178-2183`) and is also absent.

Account and Stock locally check `UserPrint` and answer `You Have No Print Rights.....` (`MS_UPDATE.cs:2334-2342,2671-2679`). Approval Adj and Image Data do not contain that local check (`MS_UPDATE.cs:8809-9038`). The owner chose one consistent Data Refresh Print boundary for all six web actions. The screen therefore reads `USER_SET.SUB_MENU = 'Data Refresh'` (`MS_UPDATE.cs:2042-2050`): the six actions run through `GET /utilities/data-refresh/operations`, `POST /utilities/data-refresh/:id/preview`, `POST /utilities/data-refresh/:id/apply` and `GET /utilities/data-refresh/runs`, which need the caption's View and Print rights and answer `You Have No Print Rights.....` without them. These routes run the same registered repairs as the advanced Data Repair console, narrowed to the six; the advanced console (`/utilities/data-repair/*`) stays administrator-only (G225).

## Operation classifications

### Account: preview-only

The preview identifies the independently safe prefix of the desktop action:

- blank `BOOK_DATA.DATA_TYPE` and `BOOK_DETL.DATA_TYPE` values;
- `CASH_DATA.CLR_DATE IS NULL` where a voucher date exists;
- the scoped `BANK_RECONCILE` replacement derived from ledger rows in account groups 02, 22 and 23.

The Account preview hash binds one complete, deterministically ordered candidate query rather than aggregate counts: scoped book and voucher business keys, physical row identities, stored values, expected values, and both the current and expected `BANK_RECONCILE` replacement sides. Display samples remain bounded summaries. A database regression replaces one book candidate with another while preserving every diff count and displayed sample, then proves the Account hash changes and the old applicable prefix hash is rejected as stale.

The desktop then calls `AcRefresh()` and a long `Ac_Ledr`, `Ac_Rojmel` and `Ac_Tax` builder sequence (`MS_UPDATE.cs:2334-2669`). That complete graph is not proved. The full Account operation therefore refuses Apply. The separately named advanced `ledger-normalise` repair remains available; it is not presented as full Account parity.

### Account: check and repair per voucher family (owner decision 2026-11-27)

The desktop's Account button deletes the year's `AC_DATA`, `ROJ_MEL_DATA`, `TAX_DATA` and derived tables and re-posts every voucher (`MS_UPDATE.cs:2334-2398` btnAc_Click, `:2401-2669` AcRefresh). The owner decided on 27 Nov 2026 that the web does **not** copy that wipe-and-rebuild. Account is instead _check and repair_, one voucher family at a time:

1. **Check.** For every voucher of the family in scope, the web re-derives what its `AC_DATA`, `ROJ_MEL_DATA` and `TAX_DATA` rows should be from the voucher's own stored rows, using the same pure builders the family's writer posts with, and materialises them exactly as the posting layer would insert them (`materializeVoucherRowsTx`: DATA_TYPE, provenance, ledger enrichment, measured column defaults). Nothing is written. Each expected value is cast to its column type through the same parameter path as an INSERT, then compared with the stored row by key (`LEDR_KEY` for `AC_DATA` and `ROJ_MEL_DATA`, `SR_NO` for `TAX_DATA`), only on the columns the writer sets; `row_id`, timestamps, `CLR_DATE` and the audit columns (`ADD_USER`, `USER_UPDATE`, `USER_DELETE`, `OLD_VCH_NO`, `NEW_VCH_NO`) are not compared.
2. **Preview.** Each voucher gets a status: `match`, `differs`, `missing` (no posting rows at all), `locked`, `orphan` or `unverified` (the builders cannot re-derive it, e.g. a contra whose rows do not pair into a balanced ledger). A differing voucher lists its rows only stored, only expected, and changed columns with both values. The screen shows the counts by status and a paged list (`GET /utilities/data-refresh/account/:family/vouchers`). The preview hash binds every voucher's key, stored-rows hash, expected-rows hash, status and version token, so any save between preview and apply makes the apply stale.
3. **Apply.** Through the shared repair framework, risk `danger` (typed confirmation, reason, password, backup under 24 hours). Under a company-level advisory lock, for each `differs`/`missing` voucher: take the writer's lock and the header rows `FOR UPDATE`, re-derive and refuse with `stale-preview` if anything moved, check the period is open, keep the voucher's current rows, delete its rows in the three tables and insert the materialised rows. One transaction; any failure rolls every voucher back. The replaced rows are stored in `data_repair_run.before_rows` (per voucher and table) so the repair is audited and can be undone. A second preview is clean; the same hash replays the earlier run; a stale hash is refused.

Defaults chosen with the decision:

- scope is the session's company, location and year;
- a voucher in a locked period (`CO_SET.LOCK_DATE`) is listed as `locked` and never changed;
- posting rows of a family book with no voucher are listed as `orphan` and never deleted;
- books `888` and `000` are never touched;
- `AC_DATA.CLR_DATE` (and the audit columns above) are carried over by key onto the replacing row, as the desktop restores `CLR_DATE` by `LEDR_KEY` after its rebuild (`MS_UPDATE.cs:2379-2396`); `BANK_RECONCILE` is not touched.

Families and their state (`ACCOUNT_REFRESH_VERIFIED` in `web/apps/api/src/modules/utilities/accountRefresh.ts`): a family's apply is enabled only once every write-set fixture of it, saved through the normal writer, previews clean (`accountRefresh.db.test.ts`); any other family previews and shows "apply not available until verified".

| Family    | Operation                        | Builders re-used                                                                                                   | Apply |
| --------- | -------------------------------- | ------------------------------------------------------------------------------------------------------------------ | ----- |
| Contra    | `data-refresh-account-contra`    | `contraPostInput` (Contra_Ledr `Ac_Ledr.cs:840-848`, Contra_Rojmel `Ac_Rojmel.cs:336-340`)                         | yes   |
| Fine Jv   | `data-refresh-account-fine-jv`   | `fineJvPostInput` (Contra_Ledr `Ac_Ledr.cs:846-848`, Contra_Rojmel `Ac_Rojmel.cs:342-344`)                         | yes   |
| Cash/Bank | `data-refresh-account-cash-bank` | `cashBankPostInput` (Cash_Ledr / Bank_Ledr `Ac_Ledr.cs:565-610`, Cash_Rojmel / Bank_Rojmel `Ac_Rojmel.cs:179-219`) | yes   |

The expected postings are derived from the stored `CONTRA_DATA` rows as they are, the way the desktop's builders read them, not re-gridded through the form. `REMARK_DATA` (rebuilt by the desktop's `Vch_Remark`, `MS_UPDATE.cs:2370-2373`) is not part of this check. The classification preview above stays on the Account button; the family checks are picked on the Account preview's "Account check and repair" panel. Next: the Purchase family.

#### Cash/Bank

One family covers every TR_CASH book: `CASH REC`, `CASH PAY`, `BANK REC`, `BANK PAY` and the web's generic `RECEIPT` / `PAYMENT` books. The desktop rebuilds them from `CASH_DATA` alone (`MS_UPDATE.cs:2470-2476`), Cash_Ledr / Cash_Rojmel for the cash books and Bank_Ledr / Bank_Rojmel for the bank books, joining `BOOK_DETL` slot 1 (cash or bank), slot 2 (kasar) and slot 3 (bank charges). The web passes the stored `CASH_DATA` rows (amount, kasar, charges, narration, cheque number, clearing date, serial) unchanged to `cashBankPostInput`, the same builder `writeCashVoucherTx` posts with; the settlement account is `REC_AC_CODE` when the writer kept it, else slot 1. The card / UPI detail rows (`CARD_DATA`, `UPI_DATA`) carry no posting, so the `cashBankCardUpi` flag does not change the check; vouchers saved with it on still check clean after it is turned off.

What `CASH_DATA` does not record is never guessed:

- A generic book takes every mode. A voucher settled to slot 1 is cash; card / UPI rows or bank charges prove bank; a voucher naming another account may be either, so the check accepts it if its postings equal the bank posting (as the voucher reopens) or the cash one, and otherwise lists it `unverified`.
- A kasar account the API named instead of slot 2 is offered the same way, from the accounts on the voucher's own legs.
- Rows another screen wrote into a receipt book (Bill to Bill, Batch Receipt: no `ENTRY_TYPE 'C'` or hidden number), rows that disagree on the voucher identity, repeated serials, a bank row without a clearing date and charges in a cash book are `unverified`.
- Payments the web kept in `PAY_DATA` before payments moved to `CASH_DATA` are listed `unverified`, not as orphans.

Bank reconciliation writes only `AC_DATA.CLR_DATE` (`bankRecon.ts`), which the check ignores and the apply carries by `LEDR_KEY`, including a cleared mark removed (NULL). A bank leg's ledger date is the row's clearing date, so a changed `CASH_DATA.CLR_DATE` re-dates the leg and changes its key-stable row only; a cleared leg whose key the voucher no longer posts is warned about in the preview and in the run record. `BANK_RECONCILE` is not touched.

### Stock: preview-only

The preview reports exact missing-fine candidates from the opening Stock step, using net weight × (touch + wastage) / 100, and exact matching `SL_DETL_RTN` rows whose copied fine value differs (`MS_UPDATE.cs:2671-2705`). The complete `StockRefresh()` and `Ac_Stock` builder graph is not proved (`MS_UPDATE.cs:2671-3047`), so the full Stock operation refuses Apply. The separately named advanced `stock-fine-refresh` operation remains available and is not relabelled as full Stock parity.

### Field Update: implemented (two repairs)

Of the 520 writes in `btnFildUpdate_Click` (`MS_UPDATE.cs:3958-8807`), two repair web data: `AC_MAST.AC_MAIN_GR` re-aligned to its `AC_GROUP` (`MS_UPDATE.cs:7214`) and a blank `AC_MAST.DEFAULTER_AC` set to `N` (`MS_UPDATE.cs:8608`). The preview reports the row count and up to 20 account codes; Apply runs both in one transaction with an audit row, scoped to the tenant and company, and a second run changes nothing. When nothing differs the screen says "No records need adjustment." The other statements are anomaly queries that must return no rows on web data (tested) or desktop migration-loader work; see `orchestration/work/WP-24/field-update.md`.

### Old Field: classification pending

Old Field covers about 22,900 lines of legacy updates. D-REF-3 requires each statement to be classified before implementation. It exposes the caption and an audited classification preview, with no Apply.

### Approval Adj: implemented

For the selected tenant, company, location and year, Approval Adj sets each `APR_DETL` `BOOK_NAME='APR ISU'` row's final `ISU_REC` to `Y` exactly when a matching consumed row exists, otherwise `N`. The consumed sources are:

- `APR_DETL`, `BOOK_NAME='APR RTN'`;
- `SL_DETL`, `BOOK_NAME='SALES'`;
- `RATE_CUT_ISU`, `BOOK_NAME='WH SALES'`;
- `RATE_CUT_ISU`, `BOOK_NAME='RATE CUT'`.

Every source requires non-empty `ISU_NO`. Matching is source `ISU_YRCD/ISU_DBCD/ISU_NO/ISU_SRNO` to issue `CO_YEAR/CO_BOOK/VCH_NO/OLD_SRNO`, as in `MS_UPDATE.cs:8815-8817`. The three text identities use right-trimmed equality to preserve SQL Server varchar trailing-space behavior without accepting leading-space changes; the numeric serial remains an exact comparison.

The operation then sets `BAR_DETL.APR_ISU='Y'` only for a tag/serial matching an unconsumed APR ISU row; every other in-scope tag becomes `N` (`MS_UPDATE.cs:8818-8820`). Unlike the desktop's final cross-location-weak update, the web includes tenant, company, location and year containment. Apply writes only `APR_DETL.ISU_REC` and `BAR_DETL.APR_ISU` and returns `Approval Refersh Process Complete.` (`MS_UPDATE.cs:8821`).

The database fixture covers five issue rows consumed by APR RTN, SALES, WH SALES, RATE CUT, and no source; trailing-padded year, book and voucher references for all four valid source families; a leading-space distractor; opposite starting flags; invalid book, blank reference, wrong location, wrong year, wrong company, and second-tenant sentinels; complete row snapshots; audit; clean second preview; replay deduplication; and rollback when a fault is injected between the APR and BAR updates.

### Image Data: verified no-op (D-REF-3 class b)

Every statement of the desktop handler is schema work in a side database: it creates NextImage when its file is missing, creates `TAG_IMAGE_DATA` (key CO_CODE, LC_CODE, TAG_NO, VCH_SRNO, IMAGE_TYPE) and adds the `MOB_IMAGE`, `IMG_IMPORT` and `CONV_IMAGE` columns, then defaults the two flags to `N` (`MS_UPDATE.cs:8825-9038`). It copies no image bytes and touches no business row. The web keeps tag image metadata in the committed, tenant-scoped `TAG_IMAGE_DATA` and the bytes in `ENTITY_IMAGE`; its schema belongs to the migrations and runtime DDL is forbidden. The preview verifies that the committed table has the key columns the desktop creates and reports no row change ("No records need adjustment", the desktop's own outcome on a current database). Apply is accepted and audited and writes nothing.

## Compatibility and remaining work

`/utilities/data-repair` remains the advanced operation/history console. Preview-only operations publish neutral authority metadata: no confirmation, reason, reauthentication or backup requirement. Both consoles independently gate Apply and authority inputs on `applyAvailable`, and direct API calls are refused with `code: preview-only` before a transaction starts.

PR-2 must classify Field Update and Old Field statement by statement. Account check-and-repair must be extended family by family (Purchase next); Stock's builder graph remains unproved (see KIRO-REPORT.md of the company-utils-blocked branch), and Old Field must be classified. No current record claims FULL, accepted, verified desktop parity, or a non-zero desktop match.
