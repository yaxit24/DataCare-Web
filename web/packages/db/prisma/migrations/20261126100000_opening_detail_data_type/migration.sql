-- Web-only ownership column for the opening detail rows (PR #292 review rounds 3 and 4). The desktop deletes and lists
-- OP_DETL by account alone (TR_AC_OPBL.cs:2584, :2696, :2877) and DM_DATA by book and type letter (TR_ITM_OPBL.cs:1456,
-- :1511), which lets one data type destroy the other's rows. A new row takes the DEFAULT 'A' (blank or NULL is read as A).
--
-- An existing row takes its parent's type when the parent has exactly one distinct type (blank or NULL read as 'A'):
-- OP_DETL from OP_DATA of the same tenant, company, location, year, book and account; DM_DATA from ITM_OPBL of the same
-- tenant, company, location, year, book, voucher and item. A row with no parent, or with parents of mixed types, stays
-- 'A'. The migration role must see every tenant despite FORCE ROW LEVEL SECURITY.
ALTER TABLE "OP_DETL" ADD COLUMN "DATA_TYPE" varchar(1) DEFAULT 'A';
ALTER TABLE "DM_DATA" ADD COLUMN "DATA_TYPE" varchar(1) DEFAULT 'A';

BEGIN;

DO $preflight$
BEGIN
  IF NOT EXISTS (
    SELECT 1 FROM pg_roles WHERE rolname=current_user AND (rolsuper OR rolbypassrls)
  ) THEN
    RAISE EXCEPTION 'opening detail data type backfill requires a migration role with complete tenant visibility';
  END IF;
END
$preflight$;

SET LOCAL row_security=off;

UPDATE "OP_DETL" d
   SET "DATA_TYPE" = p.ty
  FROM (SELECT tenant_id, "CO_CODE", "LC_CODE", "CO_YEAR", "CO_BOOK", "AC_CODE", min(ty) AS ty
          FROM (SELECT tenant_id, "CO_CODE", "LC_CODE", "CO_YEAR", "CO_BOOK", "AC_CODE",
                       COALESCE(NULLIF(trim("DATA_TYPE"), ''), 'A') AS ty
                  FROM "OP_DATA") x
         GROUP BY tenant_id, "CO_CODE", "LC_CODE", "CO_YEAR", "CO_BOOK", "AC_CODE"
        HAVING count(DISTINCT ty) = 1) p
 WHERE d.tenant_id = p.tenant_id AND d."CO_CODE" = p."CO_CODE" AND d."LC_CODE" = p."LC_CODE"
   AND d."CO_YEAR" = p."CO_YEAR" AND d."CO_BOOK" = p."CO_BOOK" AND d."AC_CODE" = p."AC_CODE"
   AND d."DATA_TYPE" IS DISTINCT FROM p.ty;

UPDATE "DM_DATA" d
   SET "DATA_TYPE" = p.ty
  FROM (SELECT tenant_id, "CO_CODE", "LC_CODE", "CO_YEAR", "CO_BOOK", "VCH_NO", "IT_CODE", min(ty) AS ty
          FROM (SELECT tenant_id, "CO_CODE", "LC_CODE", "CO_YEAR", "CO_BOOK", "VCH_NO", "IT_CODE",
                       COALESCE(NULLIF(trim("DATA_TYPE"), ''), 'A') AS ty
                  FROM "ITM_OPBL") x
         GROUP BY tenant_id, "CO_CODE", "LC_CODE", "CO_YEAR", "CO_BOOK", "VCH_NO", "IT_CODE"
        HAVING count(DISTINCT ty) = 1) p
 WHERE d.tenant_id = p.tenant_id AND d."CO_CODE" = p."CO_CODE" AND d."LC_CODE" = p."LC_CODE"
   AND d."CO_YEAR" = p."CO_YEAR" AND d."CO_BOOK" = p."CO_BOOK" AND d."VCH_NO" = p."VCH_NO"
   AND d."IT_CODE" = p."IT_CODE" AND d."DATA_TYPE" IS DISTINCT FROM p.ty;

COMMIT;
