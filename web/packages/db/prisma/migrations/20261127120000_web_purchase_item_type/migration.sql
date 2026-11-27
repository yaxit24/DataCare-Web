-- The web-provisioned purchase books 'PR' and 'TPR' take the desktop's all-metal item type 'A'.
--
-- seedCompany.ts now creates them with ITM_TYPE 'A', like the desktop 'Other Purchase' book. They used to be created
-- with a blank type. The purchase writer now follows Purc_Ledr (Ac_Ledr.cs:410-421): an 'A' book posts each line to
-- its item group's GROUP_MAST.PURC_AC, any other book to BOOK_DETL slot 1. Without this backfill a company
-- provisioned before the change would silently move its purchase postings from the group accounts to slot 1. The
-- Books master already shows a blank type as 'A' (booksMaster.ts comboLetter default).
--
-- Only the web literal book codes PR (MAIN_BOOK PURCHASE) and TPR (MAIN_BOOK TAG PURCHASE) are touched, and only
-- while the type is still blank, so a type an operator set is kept. Desktop books use 3-digit codes and never match.
-- Every statement matches nothing on a second run. The migration role must see every tenant despite FORCE ROW LEVEL
-- SECURITY.
BEGIN;

DO $preflight$
BEGIN
  IF NOT EXISTS (
    SELECT 1 FROM pg_roles WHERE rolname=current_user AND (rolsuper OR rolbypassrls)
  ) THEN
    RAISE EXCEPTION 'web purchase item type backfill requires a migration role with complete tenant visibility';
  END IF;
END
$preflight$;

SET LOCAL row_security=off;

UPDATE "BOOK_DATA"
   SET "ITM_TYPE" = 'A'
 WHERE ((btrim("CO_BOOK") = 'PR' AND btrim("MAIN_BOOK") = 'PURCHASE')
     OR (btrim("CO_BOOK") = 'TPR' AND btrim("MAIN_BOOK") = 'TAG PURCHASE'))
   AND coalesce(btrim("ITM_TYPE"), '') = '';

COMMIT;
