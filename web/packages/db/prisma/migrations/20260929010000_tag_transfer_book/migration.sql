-- N18 (desktop TR_TAG_CAN, Tag Transfer). Web provisioning created the Tag Transfer book with MAIN_BOOK
-- 'TAG TRANSFER', a value no desktop routine recognises: MDI_FORM.cs:8664 opens Tag Transfer on
-- CurBookHelp("TAG TRFR"), and Ac_Stock.Tag_Can_Stk (Ac_Stock.cs:54-56) writes stock only for MAIN_BOOK 'TAG TRFR'.
-- The desktop never writes 'TAG TRANSFER', so only web-provisioned rows match. The short name the web seeded was the
-- book code; the desktop's is TAGTR, and TR_TAG_CAN books number from BAR_CAN_DATA (MS_UPDATE.cs:7825).
-- The migration role must see every tenant despite FORCE ROW LEVEL SECURITY: a role that RLS would filter would
-- otherwise update nothing and report success.
BEGIN;

DO $preflight$
BEGIN
  IF NOT EXISTS (
    SELECT 1 FROM pg_roles WHERE rolname=current_user AND (rolsuper OR rolbypassrls)
  ) THEN
    RAISE EXCEPTION 'tag transfer book migration requires a migration role with complete tenant visibility';
  END IF;
END
$preflight$;

-- Belt and braces: should a policy still apply, fail instead of silently filtering rows.
SET LOCAL row_security=off;

UPDATE "BOOK_DATA"
   SET "MAIN_BOOK" = 'TAG TRFR',
       "BOOK_SNAME" = CASE WHEN "BOOK_SNAME" IS NULL OR "BOOK_SNAME" = "CO_BOOK" THEN 'TAGTR' ELSE "BOOK_SNAME" END,
       "BOOK_TBL_NAME" = coalesce(nullif(btrim("BOOK_TBL_NAME"), ''), 'BAR_CAN_DATA')
 WHERE "MAIN_BOOK" = 'TAG TRANSFER';

UPDATE "BOOK_DETL"
   SET "MAIN_BOOK" = 'TAG TRFR',
       "BOOK_SNAME" = CASE WHEN "BOOK_SNAME" IS NULL OR "BOOK_SNAME" = "CO_BOOK" THEN 'TAGTR' ELSE "BOOK_SNAME" END
 WHERE "MAIN_BOOK" = 'TAG TRANSFER';

COMMIT;
