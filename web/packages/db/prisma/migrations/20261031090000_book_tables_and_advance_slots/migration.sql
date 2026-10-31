-- N191 (G201) and N198 (G207, G208): bring companies provisioned before this change to the provisioning they now get.
--
-- 1. BOOK_TBL_NAME / BOOK_TBL_DETL. The desktop writes them for every book of a family on company open
--    (MS_UPDATE.cs:7829 CONTRA, :7837 SALES ORDER, :7841 SALES and SALES RETURNE, :7849 PURCHASE, PURC RETURN and
--    TAG PURCHASE, :7897 FINE JV, :7933 OTH INC and OTH EXP). Web provisioning left them NULL, so the Purchase Return
--    Register listed nothing. Only blank values are filled; a value already set (desktop data) is kept.
-- 2. The order-advance account ORDADV and the sale books' slot 4 (Sales_Rojmel names slot 4 for an adjusted advance,
--    Ac_Rojmel.cs:96). Without slot 4 a sale that adjusts an order advance failed with "book ... account row 4 is
--    missing". Only books with the web's provisioned layout (slot 1 = SALES) are touched.
-- 3. The SALES ORDER books' slot 1: Order_Ledr debits it with the cash advance (Ac_Ledr.cs:28-35). Web provisioning
--    gave it the sales account, so an advance debited SALES. Only slot 1 = SALES on a company that has the CASH
--    system account is changed.
-- The migration role must see every tenant despite FORCE ROW LEVEL SECURITY.
BEGIN;

DO $preflight$
BEGIN
  IF NOT EXISTS (
    SELECT 1 FROM pg_roles WHERE rolname=current_user AND (rolsuper OR rolbypassrls)
  ) THEN
    RAISE EXCEPTION 'book provisioning backfill requires a migration role with complete tenant visibility';
  END IF;
END
$preflight$;

SET LOCAL row_security=off;

-- 1. Desktop table names, blank only.
UPDATE "BOOK_DATA" b
   SET "BOOK_TBL_NAME" = v.t,
       "BOOK_TBL_DETL" = coalesce(nullif(btrim(b."BOOK_TBL_DETL"), ''), v.d)
  FROM (VALUES
          ('SALES', 'SL_DATA', 'SL_DETL'),
          ('SALES RETURNE', 'SL_DATA', 'SL_DETL'),
          ('PURCHASE', 'PR_DATA', 'PR_DETL'),
          ('PURC RETURN', 'PR_DATA', 'PR_DETL'),
          ('TAG PURCHASE', 'PR_DATA', 'PR_DETL'),
          ('SALES ORDER', 'SL_ORD_DATA', 'SL_ORD_DETL'),
          ('CONTRA', 'CONTRA_DATA', 'CONTRA_DATA'),
          ('FINE JV', 'CONTRA_DATA', 'CONTRA_DATA'),
          ('OTH INC', 'PAY_DATA', 'PAY_DETL'),
          ('OTH EXP', 'PAY_DATA', 'PAY_DETL')
       ) AS v(mb, t, d)
 WHERE upper(btrim(b."MAIN_BOOK")) = v.mb
   AND nullif(btrim(b."BOOK_TBL_NAME"), '') IS NULL;

-- 2a. The order-advance account, for every company that has a web-layout sale book and no ORDADV yet.
INSERT INTO "AC_MAST"(tenant_id, "CO_CODE", "LC_CODE", "AC_CODE", "AC_NAME", "AC_GR")
SELECT DISTINCT d.tenant_id, d."CO_CODE", d."LC_CODE", 'ORDADV', 'ORDER ADVANCE', '04'
  FROM "BOOK_DETL" d
 WHERE upper(btrim(d."MAIN_BOOK")) = 'SALES'
   AND d."SR_NO" = 1
   AND btrim(d."AC_CODE") = 'SALES'
   AND NOT EXISTS (
         SELECT 1 FROM "AC_MAST" a
          WHERE a.tenant_id = d.tenant_id AND a."CO_CODE" = d."CO_CODE" AND btrim(a."AC_CODE") = 'ORDADV');

-- 2b. Slot 4 on those sale books.
INSERT INTO "BOOK_DETL"(tenant_id, "CO_CODE", "LC_CODE", "CO_BOOK", "SR_NO", "BOOK_NAME", "BOOK_SNAME", "MAIN_BOOK",
                        "BOOK_INOUT", "AC_CODE", "AC_NAME", "DATA_TYPE")
SELECT d.tenant_id, d."CO_CODE", d."LC_CODE", d."CO_BOOK", 4, d."BOOK_NAME", d."BOOK_SNAME", d."MAIN_BOOK",
       d."BOOK_INOUT", 'ORDADV', 'ORDADV', d."DATA_TYPE"
  FROM "BOOK_DETL" d
 WHERE upper(btrim(d."MAIN_BOOK")) = 'SALES'
   AND d."SR_NO" = 1
   AND btrim(d."AC_CODE") = 'SALES'
   AND NOT EXISTS (
         SELECT 1 FROM "BOOK_DETL" x
          WHERE x.tenant_id = d.tenant_id AND x."CO_CODE" = d."CO_CODE" AND x."LC_CODE" = d."LC_CODE"
            AND x."CO_BOOK" = d."CO_BOOK" AND x."SR_NO" = 4);

-- 3. The order books' slot 1 becomes the cash account.
UPDATE "BOOK_DETL" d
   SET "AC_CODE" = 'CASH', "AC_NAME" = 'CASH'
 WHERE upper(btrim(d."MAIN_BOOK")) = 'SALES ORDER'
   AND d."SR_NO" = 1
   AND btrim(d."AC_CODE") = 'SALES'
   AND EXISTS (
         SELECT 1 FROM "AC_MAST" a
          WHERE a.tenant_id = d.tenant_id AND a."CO_CODE" = d."CO_CODE" AND btrim(a."AC_CODE") = 'CASH');

COMMIT;
