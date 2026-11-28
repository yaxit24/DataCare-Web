# Desktop adaptations

The desktop source decides behaviour, and the web copies it by default. This page lists every place the web
deliberately does something else, and why. A difference that is not listed here is a gap, not an adaptation
(see [testing.md](testing.md)).

An entry names the desktop behaviour with its source lines, what the web does instead, the reason, and the
evidence. Owner rule (2026-11-27): features that exist only because the desktop is offline or single-PC get a
web version that suits a shared server; features no Lite business can reach are left dormant, not built.

| Area                      | Desktop                                                                                                                                                                             | Web                                                                                                                  | Reason                                                                                                                                                                                                                                                         |
| ------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Wh Sales interest fine    | `PnlAcInt` (Month Int%, IntDay, IntFine) shows only when `CO_SET_NEW.OS_FINE_INT='Y'` (`TR_WH_SALE.cs:11871-11875`, `MS_OPNCOMP.cs:985,1119-1121`)                                  | Not built. The setting stays `SCHEMA_ONLY`                                                                           | No desktop screen writes `OS_FINE_INT`; only the vendor can turn it on in the database                                                                                                                                                                         |
| Wh Sales silver cut       | `chkSilverCut` and `PnlSilverCut` show only when `MsMfgType='B'` (`TR_WH_SALE.cs:11842-11845`), set for one registration serial (`MS_OPNCOMP.cs:48527-48533`)                       | Not built                                                                                                            | A single-customer build option, not part of Lite                                                                                                                                                                                                               |
| Data Refresh              | About 190 wipe-and-rebuild routines (`MS_UPDATE.cs`)                                                                                                                                | Check and repair (being built): preview the differences, then apply per voucher type in one transaction              | A shared server must not wipe live postings; see [data-refresh.md](data-refresh.md)                                                                                                                                                                            |
| Company credential panels | F1 or a double-click on the Company name opens `GroupBox1` (e-invoice GST portal and ASP logins) or, for UAE, `pnlUae` (client id and secret) (`MS_COMPANY.cs:6502-6521,7411-7421`) | Not shown; F1 on the name does nothing. Ctrl+R's registration-gated "Reset Compnay" box (`:6477-6480`) only explains | The panels hold integration credentials, not company identity, and the web keeps them off the screen (`web/apps/web/app/(app)/masters/companies/page.tsx` header). The reset box needs a licence flag the web does not model and triggers a data wipe at login |

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
