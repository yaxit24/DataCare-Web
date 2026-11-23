-- N240 (G252): companies provisioned before N240 get the desktop template slots their web-seeded books lacked.
--
-- seedCompany.ts now writes the MS_UPDATE.cs templates for its OTH INC / OTH EXP (slots 2 cash, 3 kasar;
-- MS_UPDATE.cs:22860-22892), PURCHASE / TAG PURCHASE (slot 5 discount; :25022, :30221), TAG SPLIT (slots 1-9;
-- :32078-32110) and LABOUR WORK (slots 8-11; :23749-23761) books. Provisioning only seeds an absent book, so an
-- existing company kept the old web slots, and its TAG SPLIT book posted the gold debit fine (Ac_Ledr.cs:1951ff,
-- tagSplitRows.ts slot 6) to PURCHASE: the old seed swapped 6/7 and put the gold accounts in the silver slots 8/9.
--
-- Only the web-seeded books are touched (their literal CO_BOOK with its MAIN_BOOK). Desktop books are never matched.
-- 1. A TAG SPLIT slot is rewritten only while it still holds exactly the account the old seed wrote there
--    (6 PURCHASE, 7 SALES, 8 PURCHASE, 9 SALES); a slot an operator changed is kept. The target account must exist.
-- 2. The DISCOUNT system account seedCompany now provisions, for companies with a web PURCHASE / TAG PURCHASE book.
-- 3. Template slots absent from those books are inserted when their account exists. Present slots are never changed.
-- Every statement matches nothing on a second run. The migration role must see every tenant despite FORCE ROW LEVEL
-- SECURITY.
BEGIN;

DO $preflight$
BEGIN
  IF NOT EXISTS (
    SELECT 1 FROM pg_roles WHERE rolname=current_user AND (rolsuper OR rolbypassrls)
  ) THEN
    RAISE EXCEPTION 'book template slots backfill requires a migration role with complete tenant visibility';
  END IF;
END
$preflight$;

SET LOCAL row_security=off;

-- 1. TAG SPLIT slots still at the old web seed account move to the desktop template account.
UPDATE "BOOK_DETL" d
   SET "AC_CODE" = v.new_ac,
       "AC_NAME" = coalesce((SELECT a."AC_NAME" FROM "AC_MAST" a
                              WHERE a.tenant_id = d.tenant_id AND a."CO_CODE" = d."CO_CODE"
                                AND btrim(a."AC_CODE") = v.new_ac
                              ORDER BY a.row_id LIMIT 1), v.new_ac)
  FROM "BOOK_DATA" b,
       (VALUES (6, 'PURCHASE', 'SALES'),
               (7, 'SALES', 'PURCHASE'),
               (8, 'PURCHASE', 'SLVSALE'),
               (9, 'SALES', 'SLVPURC')
       ) AS v(sr, old_ac, new_ac)
 WHERE b.tenant_id = d.tenant_id AND b."CO_CODE" = d."CO_CODE" AND b."LC_CODE" = d."LC_CODE"
   AND b."CO_BOOK" = d."CO_BOOK"
   AND b."CO_BOOK" = 'TSP' AND upper(btrim(b."MAIN_BOOK")) = 'TAG SPLIT'
   AND d."SR_NO" = v.sr
   AND btrim(d."AC_CODE") = v.old_ac
   AND EXISTS (
         SELECT 1 FROM "AC_MAST" a
          WHERE a.tenant_id = d.tenant_id AND a."CO_CODE" = d."CO_CODE" AND btrim(a."AC_CODE") = v.new_ac);

-- 2. The discount account of the purchase books' slot 5 (seedCompany SYSTEM_ACCOUNTS DISCOUNT).
INSERT INTO "AC_MAST"(tenant_id, "CO_CODE", "LC_CODE", "AC_CODE", "AC_NAME", "AC_GR")
SELECT DISTINCT ON (b.tenant_id, b."CO_CODE") b.tenant_id, b."CO_CODE", b."LC_CODE", 'DISCOUNT', 'DISCOUNT A/C', '22'
  FROM "BOOK_DATA" b
 WHERE (b."CO_BOOK", upper(btrim(b."MAIN_BOOK"))) IN (('PR', 'PURCHASE'), ('TPR', 'TAG PURCHASE'))
   AND NOT EXISTS (
         SELECT 1 FROM "AC_MAST" a
          WHERE a.tenant_id = b.tenant_id AND a."CO_CODE" = b."CO_CODE" AND btrim(a."AC_CODE") = 'DISCOUNT')
 ORDER BY b.tenant_id, b."CO_CODE", b."LC_CODE";

-- 3. Absent template slots, named and typed as their book's other slots.
INSERT INTO "BOOK_DETL"(tenant_id, "CO_CODE", "LC_CODE", "CO_BOOK", "SR_NO", "BOOK_NAME", "BOOK_SNAME", "MAIN_BOOK",
                        "BOOK_INOUT", "AC_CODE", "AC_NAME", "DATA_TYPE")
SELECT b.tenant_id, b."CO_CODE", b."LC_CODE", b."CO_BOOK", v.sr, b."BOOK_NAME", b."BOOK_SNAME", b."MAIN_BOOK",
       b."BOOK_INOUT", v.ac,
       coalesce((SELECT a."AC_NAME" FROM "AC_MAST" a
                  WHERE a.tenant_id = b.tenant_id AND a."CO_CODE" = b."CO_CODE" AND btrim(a."AC_CODE") = v.ac
                  ORDER BY a.row_id LIMIT 1), v.ac),
       coalesce((SELECT min(s."DATA_TYPE") FROM "BOOK_DETL" s
                  WHERE s.tenant_id = b.tenant_id AND s."CO_CODE" = b."CO_CODE" AND s."LC_CODE" = b."LC_CODE"
                    AND s."CO_BOOK" = b."CO_BOOK"), 'A')
  FROM "BOOK_DATA" b
  JOIN (VALUES ('OIN', 'OTH INC', 1, 'INTINC'), ('OIN', 'OTH INC', 2, 'CASH'), ('OIN', 'OTH INC', 3, 'KASAR'),
               ('OEX', 'OTH EXP', 1, 'OTHCHRG'), ('OEX', 'OTH EXP', 2, 'CASH'), ('OEX', 'OTH EXP', 3, 'KASAR'),
               ('PR', 'PURCHASE', 1, 'PURCHASE'), ('PR', 'PURCHASE', 2, 'CASH'), ('PR', 'PURCHASE', 3, 'ROUNDOFF'),
               ('PR', 'PURCHASE', 4, 'LBREXP'), ('PR', 'PURCHASE', 5, 'DISCOUNT'),
               ('TPR', 'TAG PURCHASE', 1, 'PURCHASE'), ('TPR', 'TAG PURCHASE', 2, 'CASH'),
               ('TPR', 'TAG PURCHASE', 3, 'ROUNDOFF'), ('TPR', 'TAG PURCHASE', 4, 'LBREXP'),
               ('TPR', 'TAG PURCHASE', 5, 'DISCOUNT'),
               ('TSP', 'TAG SPLIT', 1, 'CASH'), ('TSP', 'TAG SPLIT', 2, 'KASAR'), ('TSP', 'TAG SPLIT', 3, 'KASAR'),
               ('TSP', 'TAG SPLIT', 4, 'LBRINC'), ('TSP', 'TAG SPLIT', 5, 'LBREXP'), ('TSP', 'TAG SPLIT', 6, 'SALES'),
               ('TSP', 'TAG SPLIT', 7, 'PURCHASE'), ('TSP', 'TAG SPLIT', 8, 'SLVSALE'),
               ('TSP', 'TAG SPLIT', 9, 'SLVPURC'),
               ('LBR', 'LABOUR WORK', 1, 'LBRINC'), ('LBR', 'LABOUR WORK', 6, 'LBRINC'),
               ('LBR', 'LABOUR WORK', 8, 'SLVSALE'), ('LBR', 'LABOUR WORK', 9, 'SLVPURC'),
               ('LBR', 'LABOUR WORK', 10, 'OG'), ('LBR', 'LABOUR WORK', 11, 'OS')
       ) AS v(book, main_book, sr, ac)
    ON b."CO_BOOK" = v.book AND upper(btrim(b."MAIN_BOOK")) = v.main_book
 WHERE EXISTS (
         SELECT 1 FROM "AC_MAST" a
          WHERE a.tenant_id = b.tenant_id AND a."CO_CODE" = b."CO_CODE" AND btrim(a."AC_CODE") = v.ac)
   AND NOT EXISTS (
         SELECT 1 FROM "BOOK_DETL" x
          WHERE x.tenant_id = b.tenant_id AND x."CO_CODE" = b."CO_CODE" AND x."LC_CODE" = b."LC_CODE"
            AND x."CO_BOOK" = b."CO_BOOK" AND x."SR_NO" = v.sr);

COMMIT;
