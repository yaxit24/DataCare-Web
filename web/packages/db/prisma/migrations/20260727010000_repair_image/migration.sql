-- Repair-line image persistence for the desktop TR_REP_REC "ReparingImage" attachment.
-- Desktop stores one JPEG per repair line on a shared path named
--   CO_CODE + LC_CODE + left(CO_YEAR,4) + CO_BOOK + VCH_NO + SR_NO
-- under <MSImageSavePath>\ReparingImage\. The web keeps the same logical key but stores the bytes in
-- the tenant database so the image is transactional, backed up and RLS-isolated like every other row.
BEGIN;

CREATE TABLE IF NOT EXISTS "REP_IMAGE" (
  "tenant_id"  VARCHAR(24) NOT NULL,
  "CO_CODE"    VARCHAR(2)  NOT NULL,
  "LC_CODE"    VARCHAR(2)  NOT NULL,
  "CO_YEAR"    VARCHAR(10) NOT NULL,
  "CO_BOOK"    VARCHAR(3)  NOT NULL,
  "VCH_NO"     VARCHAR(8)  NOT NULL,
  "SR_NO"      DOUBLE PRECISION NOT NULL,
  "IMAGE_NO"   VARCHAR(60) NOT NULL,
  "IMAGE_TYPE" VARCHAR(30) NOT NULL DEFAULT 'ReparingImage',
  "MIME_TYPE"  VARCHAR(40) NOT NULL,
  "IMAGE_SIZE" INTEGER     NOT NULL,
  "REP_IMAGE"  BYTEA       NOT NULL,
  "MAIN_USER"  VARCHAR(15),
  "ENTRY_TIME" TIMESTAMP(6),
  CONSTRAINT "REP_IMAGE_pkey"
    PRIMARY KEY ("tenant_id","CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO")
);

CREATE INDEX IF NOT EXISTS "REP_IMAGE_tenant_idx" ON "REP_IMAGE" ("tenant_id");
CREATE INDEX IF NOT EXISTS "REP_IMAGE_no_idx" ON "REP_IMAGE" ("tenant_id","IMAGE_NO");

ALTER TABLE "REP_IMAGE" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "REP_IMAGE" FORCE ROW LEVEL SECURITY;
DROP POLICY IF EXISTS tenant_isolation ON "REP_IMAGE";
DROP POLICY IF EXISTS audit_tenant ON "REP_IMAGE";
CREATE POLICY tenant_isolation ON "REP_IMAGE"
  FOR ALL TO PUBLIC
  USING (("tenant_id")::text=current_setting('app.tenant_id',true))
  WITH CHECK (("tenant_id")::text=current_setting('app.tenant_id',true));

-- setup_roles.sql normally runs after migrations; existing installations already have app_user.
DO $$
BEGIN
  IF EXISTS (SELECT 1 FROM pg_roles WHERE rolname='app_user') THEN
    GRANT SELECT,INSERT,UPDATE,DELETE ON TABLE "REP_IMAGE" TO app_user;
  END IF;
END
$$;

COMMIT;
