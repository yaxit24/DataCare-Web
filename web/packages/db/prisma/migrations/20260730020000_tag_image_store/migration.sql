-- Tag image bytes.
--
-- WHY A NEW TABLE
-- The desktop keeps tag photographs on a Windows file share and uses `TAG_IMAGE_DATA` only as an index —
-- that table carries TAG_NO, VCH_SRNO and IMAGE_TYPE and has no byte column. A web server cannot depend on
-- a shop's file share, and the repair workflow already proves the pattern that works here: `REP_IMAGE`
-- stores bytes in a tenant-scoped `bytea` column alongside MIME type and size.
--
-- This table therefore mirrors REP_IMAGE rather than inventing a second mechanism or provisioning object
-- storage. `TAG_IMAGE_DATA` is left exactly as it is so desktop-shaped reads keep working; the two are
-- joined on (CO_CODE, LC_CODE, TAG_NO, VCH_SRNO).
--
-- Decision recorded here rather than in a separate document because the reason is only meaningful next to
-- the schema it explains.
CREATE TABLE IF NOT EXISTS "TAG_IMAGE_BLOB" (
  "row_id"      bigserial PRIMARY KEY,
  "tenant_id"   varchar(24) NOT NULL,
  "CO_CODE"     varchar(12) NOT NULL,
  "LC_CODE"     varchar(12) NOT NULL,
  "TAG_NO"      varchar(30) NOT NULL,
  "VCH_SRNO"    double precision NOT NULL DEFAULT 0,
  -- Mirrors the desktop's IMAGE_TYPE discriminator so several images can hang off one tag.
  "IMAGE_TYPE"  varchar(40) NOT NULL DEFAULT 'TagImage',
  "MIME_TYPE"   varchar(60) NOT NULL,
  "IMAGE_SIZE"  integer NOT NULL,
  "IMAGE_BYTES" bytea NOT NULL,
  "MAIN_USER"   varchar(64),
  "ENTRY_TIME"  timestamp without time zone NOT NULL DEFAULT now()
);

-- Identity deliberately MATCHES `TAG_IMAGE_DATA`'s primary key
-- (tenant_id, CO_CODE, LC_CODE, TAG_NO, VCH_SRNO), which EXCLUDES IMAGE_TYPE. The desktop model is one
-- image per tag instance with the type as an attribute, so a richer identity here would let the blob table
-- hold two rows the index table cannot represent. Re-uploading replaces.
CREATE UNIQUE INDEX IF NOT EXISTS "tag_image_blob_key_uq"
  ON "TAG_IMAGE_BLOB" ("tenant_id", "CO_CODE", "LC_CODE", "TAG_NO", "VCH_SRNO");

CREATE INDEX IF NOT EXISTS "tag_image_blob_tenant_idx" ON "TAG_IMAGE_BLOB" ("tenant_id");

ALTER TABLE "TAG_IMAGE_BLOB" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "TAG_IMAGE_BLOB" FORCE ROW LEVEL SECURITY;
DROP POLICY IF EXISTS "tenant_isolation" ON "TAG_IMAGE_BLOB";
CREATE POLICY "tenant_isolation" ON "TAG_IMAGE_BLOB"
  USING (("tenant_id")::text = current_setting('app.tenant_id', true))
  WITH CHECK (("tenant_id")::text = current_setting('app.tenant_id', true));
