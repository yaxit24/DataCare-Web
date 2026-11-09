-- N229 / G242: desktop Approval Isu / Approval Rtn book identity.
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

-- The retired web return writer linked rows only with ISU_NO/ISU_SRNO, stored R in both the
-- return row and source row, and put the line ordinal in VCH_SRNO. Repair only exact old-web rows.
-- A tag serial or source link is changed only when the source candidate is unique, so custom and
-- ambiguous history is left untouched rather than guessed.
UPDATE "APR_DETL" d
   SET "VCH_SRNO" = source."VCH_SRNO"
  FROM (
    SELECT issue.row_id,min(bar."VCH_SRNO")::float8 AS "VCH_SRNO"
      FROM "APR_DETL" issue
      JOIN "BOOK_DATA" book
        ON book.tenant_id=issue.tenant_id AND book."CO_CODE"=issue."CO_CODE"
       AND book."LC_CODE"=issue."LC_CODE" AND book."CO_BOOK"=issue."CO_BOOK"
      JOIN "BAR_DETL" bar
        ON bar.tenant_id=issue.tenant_id AND bar."CO_CODE"=issue."CO_CODE"
       AND bar."LC_CODE"=issue."LC_CODE" AND bar."TAG_NO"=issue."TAG_NO"
       AND coalesce(bar."IT_CODE"::text,'')=coalesce(issue."IT_CODE"::text,'')
     WHERE upper(btrim(book."MAIN_BOOK"))='APPROVAL ISSUE'
       AND upper(btrim(coalesce(issue."VCH_TYPE",'')))='TOUR'
       AND upper(btrim(coalesce(issue."BOOK_NAME",'')))='EMP ISU'
       AND coalesce(issue."TAG_NO",'N')<>'N'
     GROUP BY issue.row_id
    HAVING count(DISTINCT bar.row_id)=1
  ) source
 WHERE d.row_id=source.row_id;

UPDATE "APR_DETL" rtn
   SET "ISU_YRCD" = source."CO_YEAR",
       "ISU_DBCD" = source."CO_BOOK",
       "ISU_LC_CODE" = source."LC_CODE",
       "ISU_SRNO" = source."OLD_SRNO",
       "VCH_SRNO" = source."VCH_SRNO",
       "INOUT_TYPE" = 'I',
       "ISU_REC" = 'N'
  FROM (
    SELECT legacy.row_id,min(issue."CO_YEAR") AS "CO_YEAR",min(issue."CO_BOOK") AS "CO_BOOK",
           min(issue."LC_CODE") AS "LC_CODE",min(coalesce(issue."OLD_SRNO",issue."SR_NO"))::float8 AS "OLD_SRNO",
           min(issue."VCH_SRNO")::float8 AS "VCH_SRNO"
      FROM "APR_DETL" legacy
      JOIN "BOOK_DATA" return_book
        ON return_book.tenant_id=legacy.tenant_id AND return_book."CO_CODE"=legacy."CO_CODE"
       AND return_book."LC_CODE"=legacy."LC_CODE" AND return_book."CO_BOOK"=legacy."CO_BOOK"
      JOIN "APR_DETL" issue
        ON issue.tenant_id=legacy.tenant_id AND issue."CO_CODE"=legacy."CO_CODE"
       AND issue."LC_CODE"=legacy."LC_CODE" AND issue."CO_YEAR"=legacy."CO_YEAR"
       AND issue."VCH_NO"=legacy."ISU_NO"
       AND coalesce(issue."OLD_SRNO",issue."SR_NO")=coalesce(legacy."ISU_SRNO",legacy."OLD_SRNO")
       AND coalesce(issue."IT_CODE"::text,'')=coalesce(legacy."IT_CODE"::text,'')
       AND coalesce(issue."TAG_NO",'N')=coalesce(legacy."TAG_NO",'N')
      JOIN "BOOK_DATA" issue_book
        ON issue_book.tenant_id=issue.tenant_id AND issue_book."CO_CODE"=issue."CO_CODE"
       AND issue_book."LC_CODE"=issue."LC_CODE" AND issue_book."CO_BOOK"=issue."CO_BOOK"
      JOIN "BAR_DETL" bar
        ON bar.tenant_id=issue.tenant_id AND bar."CO_CODE"=issue."CO_CODE"
       AND bar."LC_CODE"=issue."LC_CODE" AND bar."TAG_NO"=issue."TAG_NO"
       AND coalesce(bar."IT_CODE"::text,'')=coalesce(issue."IT_CODE"::text,'')
     WHERE upper(btrim(return_book."MAIN_BOOK"))='APPROVAL RETURN'
       AND upper(btrim(issue_book."MAIN_BOOK"))='APPROVAL ISSUE'
       AND upper(btrim(coalesce(legacy."VCH_TYPE",'')))='TOURR'
       AND upper(btrim(coalesce(legacy."BOOK_NAME",'')))='EMP REC'
       AND upper(btrim(coalesce(legacy."INOUT_TYPE",'')))='R'
     GROUP BY legacy.row_id
    HAVING count(DISTINCT issue.row_id)=1
       AND count(DISTINCT bar.row_id)=1
       AND min(coalesce(bar."VCH_SRNO",0))::numeric=min(coalesce(issue."VCH_SRNO",0))::numeric
  ) source
 WHERE rtn.row_id=source.row_id;

UPDATE "APR_DETL" issue
   SET "ISU_REC" = 'Y'
  FROM "APR_DETL" rtn
  JOIN "BOOK_DATA" return_book
    ON return_book.tenant_id=rtn.tenant_id AND return_book."CO_CODE"=rtn."CO_CODE"
   AND return_book."LC_CODE"=rtn."LC_CODE" AND return_book."CO_BOOK"=rtn."CO_BOOK"
 WHERE issue.tenant_id=rtn.tenant_id AND issue."CO_CODE"=rtn."CO_CODE"
   AND issue."LC_CODE"=rtn."ISU_LC_CODE" AND issue."CO_YEAR"=rtn."ISU_YRCD"
   AND issue."CO_BOOK"=rtn."ISU_DBCD" AND issue."VCH_NO"=rtn."ISU_NO"
   AND coalesce(issue."OLD_SRNO",issue."SR_NO")=rtn."ISU_SRNO"
   AND upper(btrim(return_book."MAIN_BOOK"))='APPROVAL RETURN'
   AND upper(btrim(coalesce(rtn."VCH_TYPE",'')))='TOURR'
   AND upper(btrim(coalesce(rtn."BOOK_NAME",'')))='EMP REC';

UPDATE "APR_DATA" header
   SET "ISU_YRCD" = source."ISU_YRCD",
       "ISU_DBCD" = source."ISU_DBCD",
       "ISU_LC_CODE" = source."ISU_LC_CODE"
  FROM (
    SELECT h.row_id,min(d."ISU_YRCD") AS "ISU_YRCD",min(d."ISU_DBCD") AS "ISU_DBCD",
           min(d."ISU_LC_CODE") AS "ISU_LC_CODE"
      FROM "APR_DATA" h
      JOIN "BOOK_DATA" book
        ON book.tenant_id=h.tenant_id AND book."CO_CODE"=h."CO_CODE"
       AND book."LC_CODE"=h."LC_CODE" AND book."CO_BOOK"=h."CO_BOOK"
      JOIN "APR_DETL" d
        ON d.tenant_id=h.tenant_id AND d."CO_CODE"=h."CO_CODE" AND d."LC_CODE"=h."LC_CODE"
       AND d."CO_YEAR"=h."CO_YEAR" AND d."CO_BOOK"=h."CO_BOOK" AND d."VCH_NO"=h."VCH_NO"
     WHERE upper(btrim(book."MAIN_BOOK"))='APPROVAL RETURN'
       AND h."ISU_NO"=d."ISU_NO" AND d."ISU_DBCD" IS NOT NULL
     GROUP BY h.row_id
    HAVING count(DISTINCT concat_ws('|',d."ISU_YRCD",d."ISU_DBCD",d."ISU_LC_CODE",d."ISU_NO"))=1
  ) source
 WHERE header.row_id=source.row_id;

UPDATE "APR_IDTL" stone
   SET "VCH_SRNO" = detail."VCH_SRNO"
  FROM "APR_DETL" detail
  JOIN "BOOK_DATA" book
    ON book.tenant_id=detail.tenant_id AND book."CO_CODE"=detail."CO_CODE"
   AND book."LC_CODE"=detail."LC_CODE" AND book."CO_BOOK"=detail."CO_BOOK"
 WHERE stone.tenant_id=detail.tenant_id AND stone."CO_CODE"=detail."CO_CODE"
   AND stone."LC_CODE"=detail."LC_CODE" AND stone."CO_YEAR"=detail."CO_YEAR"
   AND stone."CO_BOOK"=detail."CO_BOOK" AND stone."VCH_NO"=detail."VCH_NO"
   AND stone."SR_NO"=detail."SR_NO"
   AND upper(btrim(book."MAIN_BOOK"))='APPROVAL ISSUE'
   AND upper(btrim(coalesce(stone."VCH_TYPE",'')))='TOUR'
   AND upper(btrim(coalesce(stone."BOOK_NAME",'')))='EMP ISU';

UPDATE "MAIN_STOCK" stock
   SET "VCH_SRNO" = detail."VCH_SRNO",
       "TR_TYPE" = CASE WHEN upper(btrim(book."MAIN_BOOK"))='APPROVAL RETURN'
                              AND upper(btrim(coalesce(stock."TR_TYPE",'')))='R' THEN 'I'
                         ELSE stock."TR_TYPE" END
  FROM "APR_DETL" detail
  JOIN "BOOK_DATA" book
    ON book.tenant_id=detail.tenant_id AND book."CO_CODE"=detail."CO_CODE"
   AND book."LC_CODE"=detail."LC_CODE" AND book."CO_BOOK"=detail."CO_BOOK"
 WHERE stock.tenant_id=detail.tenant_id AND stock."CO_CODE"=detail."CO_CODE"
   AND stock."LC_CODE"=detail."LC_CODE" AND stock."CO_YEAR"=detail."CO_YEAR"
   AND stock."CO_BOOK"=detail."CO_BOOK" AND stock."VCH_NO"=detail."VCH_NO"
   AND stock."SR_NO"=detail."SR_NO"
   AND upper(btrim(book."MAIN_BOOK")) IN ('APPROVAL ISSUE','APPROVAL RETURN')
   AND ((upper(btrim(book."MAIN_BOOK"))='APPROVAL ISSUE'
         AND upper(btrim(coalesce(stock."VCH_TYPE",'')))='TOUR'
         AND upper(btrim(coalesce(stock."BOOK_NAME",'')))='EMP ISU')
     OR (upper(btrim(book."MAIN_BOOK"))='APPROVAL RETURN'
         AND upper(btrim(coalesce(stock."VCH_TYPE",'')))='TOURR'
         AND upper(btrim(coalesce(stock."BOOK_NAME",'')))='EMP REC'));

-- Detail and stock stamps follow, while the old MAIN_BOOK still identifies exactly the old web books.
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
