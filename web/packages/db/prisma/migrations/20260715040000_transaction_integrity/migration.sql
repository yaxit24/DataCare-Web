-- Task 5 transaction-integrity indexes.
-- Historical migrations remain immutable; this migration only adds constraints/indexes required by
-- full-scope numbering and VCH_SRNO-aware tag issue/reversal checks.

DO $$
BEGIN
  IF EXISTS (
    SELECT 1
      FROM "SRNO_MAST"
     WHERE "CO_CODE" IS NOT NULL AND "LC_CODE" IS NOT NULL
     GROUP BY tenant_id, "CO_CODE", "LC_CODE"
    HAVING count(*) > 1
  ) THEN
    RAISE EXCEPTION USING
      MESSAGE = 'transaction-integrity migration: duplicate SRNO_MAST tenant/company/location rows',
      HINT = 'Merge duplicate tag-counter rows before retrying the migration.';
  END IF;
END
$$;

DROP INDEX IF EXISTS "idx_srno_mast_key";
CREATE UNIQUE INDEX IF NOT EXISTS "uq_srno_mast_tenant_company_location"
  ON "SRNO_MAST" (tenant_id, "CO_CODE", "LC_CODE");

CREATE INDEX IF NOT EXISTS "idx_bar_detl_tag_identity"
  ON "BAR_DETL" (tenant_id, "CO_CODE", "LC_CODE", "TAG_NO", "VCH_SRNO", "IT_CODE");

CREATE INDEX IF NOT EXISTS "idx_main_stock_tag_identity"
  ON "MAIN_STOCK" (tenant_id, "CO_CODE", "LC_CODE", "TAG_NO", "VCH_SRNO", "IT_CODE");
