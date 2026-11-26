-- The web-provisioned sale book 'SL' takes the desktop's tax-invoice book type.
--
-- seedCompany.ts now creates book SL with BOOK_TYPE 'T' and ITM_TYPE 'A', the desktop's 'Sales Invoice' book
-- (MS_UPDATE.cs:7320). It used to create it with neither, and the sale writer kept writing TAX_DATA for a blank type
-- as an exception. The writer now follows Sales_GST exactly (Ac_Tax.cs:92-98: TAX_DATA only for BOOK_TYPE 'T'), so a
-- company provisioned before this change would stop getting its GST register; the GST reports already required 'T'
-- (gstReportQueries.ts) and so never listed those bills.
--
-- Only the web literal book code SL on MAIN_BOOK SALES is touched, and only while its type is still blank, so a type
-- an operator set in the Books master is kept. Desktop books use 3-digit codes and never match. ITM_TYPE is set only
-- when blank. Every statement matches nothing on a second run. The migration role must see every tenant despite
-- FORCE ROW LEVEL SECURITY.
BEGIN;

DO $preflight$
BEGIN
  IF NOT EXISTS (
    SELECT 1 FROM pg_roles WHERE rolname=current_user AND (rolsuper OR rolbypassrls)
  ) THEN
    RAISE EXCEPTION 'web sales book type backfill requires a migration role with complete tenant visibility';
  END IF;
END
$preflight$;

SET LOCAL row_security=off;

UPDATE "BOOK_DATA"
   SET "BOOK_TYPE" = 'T',
       "ITM_TYPE" = coalesce(nullif(btrim("ITM_TYPE"), ''), 'A')
 WHERE btrim("CO_BOOK") = 'SL'
   AND btrim("MAIN_BOOK") = 'SALES'
   AND coalesce(btrim("BOOK_TYPE"), '') = '';

COMMIT;
