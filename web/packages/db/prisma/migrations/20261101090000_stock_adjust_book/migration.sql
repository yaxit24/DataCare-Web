-- N220 (desktop TR_TAG_CAN, Stock Adjust). Web provisioning created the Stock Adjust book SAJ as an in book with its
-- own code as the short name and no register table. The desktop's Stock Adjust book is an out book with short name
-- STADJ (MS_UPDATE.cs:24207 "Only Stock Adjust", :25049 BOOK_INOUT 'O'), and TR_TAG_CAN books number from
-- BAR_CAN_DATA (MS_UPDATE.cs:7825). Only rows the web wrote match: book code SAJ, short name SAJ or blank.
-- The migration role must see every tenant despite FORCE ROW LEVEL SECURITY: a role that RLS would filter would
-- otherwise update nothing and report success.
BEGIN;

DO $preflight$
BEGIN
  IF NOT EXISTS (
    SELECT 1 FROM pg_roles WHERE rolname=current_user AND (rolsuper OR rolbypassrls)
  ) THEN
    RAISE EXCEPTION 'stock adjust book migration requires a migration role with complete tenant visibility';
  END IF;
END
$preflight$;

-- Belt and braces: should a policy still apply, fail instead of silently filtering rows.
SET LOCAL row_security=off;

UPDATE "BOOK_DATA"
   SET "BOOK_SNAME" = 'STADJ',
       "BOOK_INOUT" = 'O',
       "BOOK_TBL_NAME" = coalesce(nullif(btrim("BOOK_TBL_NAME"), ''), 'BAR_CAN_DATA'),
       "BOOK_TBL_DETL" = coalesce(nullif(btrim("BOOK_TBL_DETL"), ''), 'BAR_CAN_DETL')
 WHERE "MAIN_BOOK" = 'STOCK ADJUST' AND "CO_BOOK" = 'SAJ' AND coalesce(btrim("BOOK_SNAME"), '') IN ('', 'SAJ');

UPDATE "BOOK_DETL"
   SET "BOOK_SNAME" = 'STADJ',
       "BOOK_INOUT" = 'O'
 WHERE "MAIN_BOOK" = 'STOCK ADJUST' AND "CO_BOOK" = 'SAJ' AND coalesce(btrim("BOOK_SNAME"), '') IN ('', 'SAJ');

COMMIT;
