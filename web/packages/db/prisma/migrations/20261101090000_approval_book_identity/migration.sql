-- N211 / G224: desktop Approval Isu / Approval Rtn book identity.
--
-- The desktop opens TR_APR_ISU only through MAIN_BOOK 'APR ISU' or 'APR RTN'
-- (MDI_FORM.cs:8300-8317), maps both to APR_DATA/APR_DETL (MS_UPDATE.cs:7833), and stamps
-- BOOK_DATA.BOOK_SNAME plus MAIN_BOOK on APR_DETL/APR_IDTL/MAIN_STOCK
-- (TR_APR_ISU.cs:6166-6169,6351-6354; Ac_Stock.cs:60-85).
--
-- Older web provisioning invented MAIN_BOOK 'APPROVAL ISSUE'/'APPROVAL RETURN', while its writer
-- stamped TOUR/TOURR and EMP ISU/EMP REC. Update only those exact web values and only rows belonging
-- to a book being renamed. Existing desktop books, custom short names and nonblank custom table names
-- remain untouched. The migration needs complete tenant visibility because BOOK_DATA is forced-RLS.
BEGIN;

DO $preflight$
BEGIN
  IF NOT EXISTS (
    SELECT 1 FROM pg_roles WHERE rolname=current_user AND (rolsuper OR rolbypassrls)
  ) THEN
    RAISE EXCEPTION 'approval book identity backfill requires a migration role with complete tenant visibility';
  END IF;
END
$preflight$;

SET LOCAL row_security=off;

-- Detail and stock stamps first, while the old MAIN_BOOK still identifies exactly the old web books.
UPDATE "APR_DETL" d
   SET "VCH_TYPE" = b."BOOK_SNAME",
       "BOOK_NAME" = CASE upper(btrim(b."MAIN_BOOK"))
                       WHEN 'APPROVAL ISSUE' THEN 'APR ISU'
                       WHEN 'APPROVAL RETURN' THEN 'APR RTN'
                     END
  FROM "BOOK_DATA" b
 WHERE d.tenant_id=b.tenant_id
   AND d."CO_CODE"=b."CO_CODE" AND d."LC_CODE"=b."LC_CODE" AND d."CO_BOOK"=b."CO_BOOK"
   AND upper(btrim(b."MAIN_BOOK")) IN ('APPROVAL ISSUE','APPROVAL RETURN')
   AND ((upper(btrim(b."MAIN_BOOK"))='APPROVAL ISSUE'
         AND upper(btrim(coalesce(d."VCH_TYPE",'')))='TOUR'
         AND upper(btrim(coalesce(d."BOOK_NAME",'')))='EMP ISU')
     OR (upper(btrim(b."MAIN_BOOK"))='APPROVAL RETURN'
         AND upper(btrim(coalesce(d."VCH_TYPE",'')))='TOURR'
         AND upper(btrim(coalesce(d."BOOK_NAME",'')))='EMP REC'));

UPDATE "APR_IDTL" d
   SET "VCH_TYPE" = b."BOOK_SNAME",
       "BOOK_NAME" = 'APR ISU'
  FROM "BOOK_DATA" b
 WHERE d.tenant_id=b.tenant_id
   AND d."CO_CODE"=b."CO_CODE" AND d."LC_CODE"=b."LC_CODE" AND d."CO_BOOK"=b."CO_BOOK"
   AND upper(btrim(b."MAIN_BOOK"))='APPROVAL ISSUE'
   AND upper(btrim(coalesce(d."VCH_TYPE",'')))='TOUR'
   AND upper(btrim(coalesce(d."BOOK_NAME",'')))='EMP ISU';

UPDATE "MAIN_STOCK" d
   SET "VCH_TYPE" = b."BOOK_SNAME",
       "BOOK_NAME" = CASE upper(btrim(b."MAIN_BOOK"))
                       WHEN 'APPROVAL ISSUE' THEN 'APR ISU'
                       WHEN 'APPROVAL RETURN' THEN 'APR RTN'
                     END
  FROM "BOOK_DATA" b
 WHERE d.tenant_id=b.tenant_id
   AND d."CO_CODE"=b."CO_CODE" AND d."LC_CODE"=b."LC_CODE" AND d."CO_BOOK"=b."CO_BOOK"
   AND upper(btrim(b."MAIN_BOOK")) IN ('APPROVAL ISSUE','APPROVAL RETURN')
   AND ((upper(btrim(b."MAIN_BOOK"))='APPROVAL ISSUE'
         AND upper(btrim(coalesce(d."VCH_TYPE",'')))='TOUR'
         AND upper(btrim(coalesce(d."BOOK_NAME",'')))='EMP ISU')
     OR (upper(btrim(b."MAIN_BOOK"))='APPROVAL RETURN'
         AND upper(btrim(coalesce(d."VCH_TYPE",'')))='TOURR'
         AND upper(btrim(coalesce(d."BOOK_NAME",'')))='EMP REC'));

UPDATE "BOOK_DETL"
   SET "MAIN_BOOK" = CASE upper(btrim("MAIN_BOOK"))
                       WHEN 'APPROVAL ISSUE' THEN 'APR ISU'
                       WHEN 'APPROVAL RETURN' THEN 'APR RTN'
                     END
 WHERE upper(btrim("MAIN_BOOK")) IN ('APPROVAL ISSUE','APPROVAL RETURN');

UPDATE "BOOK_DATA"
   SET "MAIN_BOOK" = CASE upper(btrim("MAIN_BOOK"))
                       WHEN 'APPROVAL ISSUE' THEN 'APR ISU'
                       WHEN 'APPROVAL RETURN' THEN 'APR RTN'
                     END,
       "BOOK_TBL_NAME" = coalesce(nullif(btrim("BOOK_TBL_NAME"),''),'APR_DATA'),
       "BOOK_TBL_DETL" = coalesce(nullif(btrim("BOOK_TBL_DETL"),''),'APR_DETL')
 WHERE upper(btrim("MAIN_BOOK")) IN ('APPROVAL ISSUE','APPROVAL RETURN');

COMMIT;
