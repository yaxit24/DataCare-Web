-- The web-provisioned sale book SL gets its discount slot, BOOK_DETL SR_NO 5.
--
-- Sales_Ledr posts a bill discount as the pair 33/34 against the book's slot 5 (Ac_Ledr.cs:155-157 `B.SR_NO = 5`).
-- seedCompany.ts now creates SL with slot 5 = DISCOUNT; it used to stop at slot 4, so a discounted sale on a company
-- provisioned before would be refused for a missing slot. The row copies the book's slot-1 row and names the
-- company's DISCOUNT account, only where SL (MAIN_BOOK SALES, the web's literal code) has no slot 5 and the account
-- exists. A second run inserts nothing. The migration role must see every tenant despite FORCE ROW LEVEL SECURITY.
BEGIN;

DO $preflight$
BEGIN
  IF NOT EXISTS (
    SELECT 1 FROM pg_roles WHERE rolname=current_user AND (rolsuper OR rolbypassrls)
  ) THEN
    RAISE EXCEPTION 'web sales discount slot backfill requires a migration role with complete tenant visibility';
  END IF;
END
$preflight$;

SET LOCAL row_security=off;

INSERT INTO "BOOK_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","SR_NO","BOOK_NAME","BOOK_SNAME","MAIN_BOOK",
                        "BOOK_INOUT","AC_CODE","AC_NAME","DATA_TYPE")
SELECT d.tenant_id, d."CO_CODE", d."LC_CODE", d."CO_BOOK", 5, d."BOOK_NAME", d."BOOK_SNAME", d."MAIN_BOOK",
       d."BOOK_INOUT", 'DISCOUNT', a."AC_NAME", d."DATA_TYPE"
  FROM "BOOK_DETL" d
  JOIN LATERAL (SELECT m."AC_NAME" FROM "AC_MAST" m
                 WHERE m.tenant_id=d.tenant_id AND m."CO_CODE"=d."CO_CODE" AND btrim(m."AC_CODE")='DISCOUNT'
                 ORDER BY m.row_id LIMIT 1) a ON true
 WHERE btrim(d."CO_BOOK") = 'SL'
   AND btrim(d."MAIN_BOOK") = 'SALES'
   AND coalesce(d."SR_NO", 0) = 1
   AND NOT EXISTS (SELECT 1 FROM "BOOK_DETL" x
                    WHERE x.tenant_id=d.tenant_id AND x."CO_CODE"=d."CO_CODE" AND x."LC_CODE"=d."LC_CODE"
                      AND x."CO_BOOK"=d."CO_BOOK" AND coalesce(x."SR_NO", 0) = 5);

COMMIT;
