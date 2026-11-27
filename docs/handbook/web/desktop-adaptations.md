# Desktop adaptations

The desktop source decides behaviour, and the web copies it by default. This page lists every place the web
deliberately does something else, and why. A difference that is not listed here is a gap, not an adaptation
(see [testing.md](testing.md)).

An entry names the desktop behaviour with its source lines, what the web does instead, the reason, and the
evidence. Owner rule (2026-11-27): features that exist only because the desktop is offline or single-PC get a
web version that suits a shared server; features no Lite business can reach are left dormant, not built.

| Area                      | Desktop                                                                                                                                                                                                                                | Web                                                                                                                                                | Reason                                                                                                                                                            |
| ------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Wh Sales interest fine    | `PnlAcInt` (Month Int%, IntDay, IntFine) shows only when `CO_SET_NEW.OS_FINE_INT='Y'` (`TR_WH_SALE.cs:11871-11875`, `MS_OPNCOMP.cs:985,1119-1121`)                                                                                     | Not built. The setting stays `SCHEMA_ONLY`                                                                                                         | No desktop screen writes `OS_FINE_INT`; only the vendor can turn it on in the database                                                                            |
| Wh Sales silver cut       | `chkSilverCut` and `PnlSilverCut` show only when `MsMfgType='B'` (`TR_WH_SALE.cs:11842-11845`), set for one registration serial (`MS_OPNCOMP.cs:48527-48533`)                                                                          | Not built                                                                                                                                          | A single-customer build option, not part of Lite                                                                                                                  |
| Data Refresh              | About 190 wipe-and-rebuild routines (`MS_UPDATE.cs`)                                                                                                                                                                                   | Check and repair (being built): preview the differences, then apply per voucher type in one transaction                                            | A shared server must not wipe live postings; see [data-refresh.md](data-refresh.md)                                                                               |
| Company credential panels | F1 or a double-click on the Company name opens `GroupBox1` (e-invoice GST portal and ASP logins) or, for UAE, `pnlUae` (client id and secret) (`MS_COMPANY.cs:6502-6521,7411-7421`)                                                    | Not shown; F1 on the name does nothing                                                                                                             | The panels hold integration credentials, not company identity, and the web keeps them off the screen (`web/apps/web/app/(app)/masters/companies/page.tsx` header) |
| Company reset             | Ctrl+R shows "Reset Compnay" for six licences only (`MS_COMPANY.cs:6477-6480`); ticked and saved it sets `CO_MAST.RTGS_TYPE='Y'` (`:6116,6162`) and the next login clears the company (`Module_Schm.cs:60-230`, `MS_LOGIN.cs:581-593`) | Immediate clear of the company's data in one transaction, keeping the company; every web administrator; second confirmation; deleted rows archived | A shared server cannot leave a wipe pending until someone signs in, and the web has no operator backup step; see [Company reset](#company-reset)                  |

## Wh Sales interest fine and silver cut

Evidence that no Lite business uses either (2026-11-27, the owner's local desktop databases Next23, Next24,
Next24M and Next25, never committed):

- `OS_FINE_INT` is `N` for every company.
- None of the 45 `RATE_CUT_DATA` vouchers has a non-zero `INT_FINE`, `INT_PRC_FINE`, `SLV_FINE_CR`,
  `SLV_FINE_DR`, `SLV_AMT_CR` or `SLV_AMT_DR`.
- No `AC_DATA` row posts to the desktop interest account `00061`.

What already exists and stays: the `RATE_CUT_DATA` columns, `AC_MAST.AC_INT_PRC`, `CO_SET.INT_YEAR_DAYS`, and the
day-book rows 29/30 and 33-36 in `web/apps/api/src/modules/shared/rojmelWholesale.ts` (unit-tested, fed nothing).

If an imported company ever arrives with `OS_FINE_INT='Y'` or non-zero silver-cut values, build it from the study
in this order:

1. `AcFineInt` (`TR_WH_SALE.cs:14691-14707`) computes
   `INT_FINE = round(|gold balance| × IntPrc×12/100 × IntDay / INT_YEAR_DAYS, 3)`, where a year of 0 days is
   treated as 360. A blank IntDay is taken as the days since the party's last gold `AC_DATA` row.
2. The interest posts AC legs 53/54 one-sided to `00061` (`Ac_Ledr.cs:743-745`). The silver cut posts legs 57-60
   on BOOK_DETL SR8/SR9 (`Ac_Ledr.cs:751-757`); leg 59's condition has a desktop typo.
3. The silver-cut steps of `BILL_TOTAL` (`TR_WH_SALE.cs:15462-15593`) include two quirks that write the gold
   fields.

## Company reset

Owner decisions 2026-11-27 and 2026-11-28. Desktop: Ctrl+R on Company → Company shows the "Reset Compnay" box only
where `MsMasterResetAllData='Y'`, a flag six registration serials set (`MS_OPNCOMP.cs:5077-5262`). Ticked and saved,
it stores `CO_MAST.RTGS_TYPE='Y'` (`MS_COMPANY.cs:6116,6162`). After the next login `MS_OPNCOMP.cs:1513,2010-2013`
runs `Module_Schm.CompnyRest` (`Module_Schm.cs:873-1060`, the same statements as `:60-230`): it deletes the flagged
company's vouchers, stock and masters table by table (`:83-222`) but keeps the default rows (account codes up to 99,
location 00, login and user set ABC, employee 001, table 001, balance groups up to 7, the current year) and puts
`AC_GROUP`, `BOOK_DETL`, `CO_SET` and `CONV_MAST` back to defaults (`:89,109,116,118`). Its last statements and
`MS_LOGIN.cs:581-593` also delete the `CO_MAST` row.

Web (`web/apps/api/src/modules/masters/companyReset.ts`, `web/apps/web/components/CompanyResetPanel.tsx`): **clear the
data, keep the company**, so the company afterwards looks like a freshly provisioned one with its own identity.

- **Immediate, not at the next login.** `POST /companies/:coCode/reset` runs in one transaction;
  `GET /companies/:coCode/reset/preview` shows what is kept and what is deleted first.
- **Kept as they are:** identity and settings (`CO_MAST`, `CO_SET`, `CO_SET_NEW`, `PRINT_MAST`, `E_MAST`), books
  (`BOOK_DATA`, `BOOK_DETL`), users and rights (`LOGIN_MAST`, `USER_SET`) and locations (`LOCT_MAST`, with this
  company's `TRY_DATE` cleared as `Module_Schm.cs:161` does). The desktop keeps only the default location, login and
  user set; the web keeps them all. `TAG_SET` (tag print settings) is deleted as on the desktop (`:209`); the web does
  not read it.
- **Kept in part:** one financial year (the caller's session year, or the company's latest year when it does not
  have that one); the accounts the desktop keeps (numeric code up to 99, `:90`) plus every account a kept book
  (`BOOK_DETL.AC_CODE`) or location (`LOCT_MAST.AC_CODE`) names, so no kept book posts to a missing account (the
  desktop instead moves some book legs to account 00075, `:109`); and the account groups those accounts sit in.
- **Everything else** in the company scope (every table with `tenant_id` and `CO_CODE`) is deleted for the company,
  and `provisionCompanyTx` (`seedCompany`, `templatesOnly`) puts back the default masters a new company gets
  (account groups, template masters, system accounts, taxes, serials). It inserts only missing rows and never
  creates identity, settings, books, a location (it uses the company's own) or a year. The desktop's unscoped
  statements (`BOOK_IDTL`, `LOCT_MAST.TRY_DATE` of every company, `RATE_CUT_ISU_REC`, `TAG_PRINT_DATA`,
  `TAG_STOCK_PRINT`, `TEMP_AD_DATA`, `TEMP_ADD`) touch other companies and are not ported.
- **Resetting 01** also empties the source a company made through Company Master copies its parties and
  non-default masters from (`companyClone.ts`); new companies then get only what 01 still has.
- **No operator backup step** (the web is a hosted service). Every deleted row is copied, in the statement that
  deletes it, into the tenant-level `company_reset_archive` (forced RLS, append-only, outside the company scope and
  the company backup). Support can recover rows from it; there is no self-service undo.
- **Writers are held off and the apply is tied to the preview.** The reset locks the tables it clears (and
  `BOOK_DETL`, `LOCT_MAST`) `SHARE ROW EXCLUSIVE`, as the logical restore does, with a 10 s lock timeout (busy:
  retryable 503). It refuses with "the data changed since you previewed it" unless the preview's `fingerprint`
  (per-table counts and newest row versions) still matches, and it rolls back unless exactly the planned rows were
  deleted and only seeded rows were added. It runs in its own `maintenance` transaction budget (5 minutes; 50,000
  rows and 20 MB of images took about 4 s in the test).
- **Any company**, including 01 and the company the caller is working in, so a single-company Lite install can reset.
  Every other sign-in to the company ends (`auth_session` revoked with reason `company-reset`); the caller stays
  signed in and, after resetting the open company, returns to the dashboard.
- **Available to every web administrator**, not six licences. Non-administrators see a note only; the routes are
  administrator-only in the route registry and checked again in the handler.
- **Extra safeguards** (the Data Repair danger checks, `dataRepair.ts`): typed company code and name must match
  exactly; the caller re-enters their own password; a written reason of at least 12 characters; one reset per
  company at a time (advisory lock; a second is refused) under the company-identity lock. The run is recorded in
  `data_repair_run` (operation `company-reset`: who, when, why, kept year, rows deleted and archived per table).

### Recovering archived rows (support)

Run as the database owner, inside a transaction, for one tenant and one reset (`run_id` is the `row_id` of the
`data_repair_run` row with `operation_id='company-reset'`):

```sql
-- See what a reset removed, per table.
SELECT table_name, count(*) FROM company_reset_archive
 WHERE tenant_id = '<tenant>' AND run_id = <run_id> GROUP BY table_name ORDER BY table_name;

-- Put one table's rows back (here AC_MAST). jsonb_populate_record turns each archived row into a row of the table
-- (bytea columns were archived as '\x…' hex text and convert back on their own). List every column except row_id,
-- so new ids are taken, and skip rows that already exist (the seeded defaults) by the table's business key.
INSERT INTO "AC_MAST" (tenant_id, "CO_CODE", "LC_CODE", "AC_CODE", "AC_NAME" /* , …every column but row_id */)
SELECT r.tenant_id, r."CO_CODE", r."LC_CODE", r."AC_CODE", r."AC_NAME" /* , … */
  FROM company_reset_archive x, jsonb_populate_record(NULL::"AC_MAST", x.row_data) r
 WHERE x.tenant_id = '<tenant>' AND x.run_id = <run_id> AND x.table_name = 'AC_MAST'
   AND NOT EXISTS (SELECT 1 FROM "AC_MAST" a WHERE a.tenant_id = r.tenant_id
                     AND a."CO_CODE" = r."CO_CODE" AND a."AC_CODE" = r."AC_CODE");
```

Restore parents before children (the company backup's table order, `orderedCompanyTables`). The reset test
(`companyReset.db.test.ts`) runs this recovery for `AC_DATA` and reads image bytes back the same way. The archive itself is never edited;
removing it needs `SET LOCAL app.allow_repair_purge = 'on'`.
