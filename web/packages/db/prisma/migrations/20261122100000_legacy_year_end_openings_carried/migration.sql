-- WP-23 (architect, 2026-11-22, owner may override): Year-End Close used to write a party's next-year opening as AC_DATA
-- book '000', VCH_TYPE 'ACOP', BOOK_NAME 'OPENING', VCH_NO '1' (ops/yearEnd.ts before N236). Those legs are carried
-- openings: the cross-year readers (Account Ledger and the others in shared/carriedOpening.ts) must not add them to the
-- closed year's history. Relabel only such a leg that has a carried OP_DATA row of the same company, location, year and
-- account (book '000', DATA_TRFR 'Y'), so an imported real Account Opening leg is never hidden. A legacy leg without
-- one is left as it is; the next Year-End Close, Balance TrFr or Carry Forward of that year replaces it.
-- Idempotent. AC_DATA and OP_DATA are forced-RLS, so the migration needs complete tenant visibility.
BEGIN;

DO $preflight$
BEGIN
  IF NOT EXISTS (
    SELECT 1 FROM pg_roles WHERE rolname=current_user AND (rolsuper OR rolbypassrls)
  ) THEN
    RAISE EXCEPTION 'legacy year-end opening relabel requires a migration role with complete tenant visibility';
  END IF;
END
$preflight$;

SET LOCAL row_security=off;

UPDATE "AC_DATA" d
   SET "BOOK_NAME" = 'BAL TRFR'
 WHERE d."CO_BOOK" = '000'
   AND d."VCH_TYPE" = 'ACOP'
   AND d."BOOK_NAME" = 'OPENING'
   AND d."VCH_NO" = '1'
   AND EXISTS (
     SELECT 1 FROM "OP_DATA" o
      WHERE o.tenant_id = d.tenant_id
        AND o."CO_CODE" = d."CO_CODE"
        AND o."LC_CODE" = d."LC_CODE"
        AND o."CO_YEAR" = d."CO_YEAR"
        AND o."AC_CODE" = d."AC_CODE"
        AND o."CO_BOOK" = '000'
        AND o."DATA_TRFR" = 'Y'
   );

COMMIT;
