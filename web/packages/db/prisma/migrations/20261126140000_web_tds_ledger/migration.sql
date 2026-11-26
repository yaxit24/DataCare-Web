-- Web-provisioned companies get the TDS ledger their sales' TDS pair falls back to.
--
-- A sale on a SL_TDS_TAX company posts TDS as the pair 13/14 against the TDS code's TAX_MAST.TAX_AC (Ac_Ledr.cs:112-114).
-- seedCompany.ts leaves TAX_AC unset on its tax codes, so the writer falls back to the literal TDS ledger, which
-- seedCompany.ts now provisions (TDS RECEIVABLE, group 18 as the template's TDS ledger). A company provisioned before
-- would post to an account it does not have. This adds the account wherever the web's seeded TCS ledger exists (the
-- marker of a web-provisioned company) and TDS does not; desktop charts use 5-digit codes and never match. A second run
-- inserts nothing. The migration role must see every tenant despite FORCE ROW LEVEL SECURITY.
BEGIN;

DO $preflight$
BEGIN
  IF NOT EXISTS (
    SELECT 1 FROM pg_roles WHERE rolname=current_user AND (rolsuper OR rolbypassrls)
  ) THEN
    RAISE EXCEPTION 'web TDS ledger backfill requires a migration role with complete tenant visibility';
  END IF;
END
$preflight$;

SET LOCAL row_security=off;

INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GR")
SELECT t.tenant_id, t."CO_CODE", t."LC_CODE", 'TDS', 'TDS RECEIVABLE', '18'
  FROM "AC_MAST" t
 WHERE btrim(t."AC_CODE") = 'TCS'
   AND btrim(t."AC_NAME") = 'TCS PAYABLE'
   AND NOT EXISTS (SELECT 1 FROM "AC_MAST" x
                    WHERE x.tenant_id=t.tenant_id AND x."CO_CODE"=t."CO_CODE" AND btrim(x."AC_CODE")='TDS');

COMMIT;
