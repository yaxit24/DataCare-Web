-- WP-36: web-provisioned sale, purchase and tax ledgers move to the desktop groups the master helps filter on.
--
-- seedCompany.ts now provisions SALES / SLVSALE / FINESALE in group 25 and PURCHASE / SLVPURC / FINEPURC in group 30
-- (MS_GROUP.cs:2204 Sales Ac, :2242 Purchase Ac; MS_TRADE.cs:1190, :1234), and GST / GSTINPUT / TCS in group 12
-- (MS_TAX.cs:2039 tax header help). It used to write 20, 21 and 30, so on such a company the Group helps listed no sales
-- or purchase ledger, the Tax header help listed no tax ledger, and the customer reports listed SALES (group 20).
--
-- Only the web literal codes are touched, and only while they still carry the old seed group and the seed name, so an
-- account an operator renamed or regrouped is kept. Desktop charts use 5-digit codes and never match. Every statement
-- matches nothing on a second run. The migration role must see every tenant despite FORCE ROW LEVEL SECURITY.
BEGIN;

DO $preflight$
BEGIN
  IF NOT EXISTS (
    SELECT 1 FROM pg_roles WHERE rolname=current_user AND (rolsuper OR rolbypassrls)
  ) THEN
    RAISE EXCEPTION 'seeded ledger groups backfill requires a migration role with complete tenant visibility';
  END IF;
END
$preflight$;

SET LOCAL row_security=off;

UPDATE "AC_MAST" a
   SET "AC_GR" = v.new_gr
  FROM (VALUES ('SALES', 'SALES A/C', '20', '25'),
               ('SLVSALE', 'SALES SILVER A/C', '20', '25'),
               ('FINESALE', 'FINE METAL SALE', '20', '25'),
               ('PURCHASE', 'PURCHASE A/C', '21', '30'),
               ('SLVPURC', 'PURCHASE SILVER A/C', '21', '30'),
               ('FINEPURC', 'FINE METAL PURCHASE', '21', '30'),
               ('GST', 'GST OUTPUT (PAYABLE)', '30', '12'),
               ('GSTINPUT', 'GST INPUT CREDIT', '30', '12'),
               ('TCS', 'TCS PAYABLE', '30', '12')) AS v(code, name, old_gr, new_gr)
 WHERE btrim(a."AC_CODE") = v.code
   AND btrim(a."AC_NAME") = v.name
   AND btrim(a."AC_GR") = v.old_gr;

COMMIT;
