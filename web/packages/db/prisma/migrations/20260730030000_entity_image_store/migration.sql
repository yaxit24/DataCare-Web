-- Generalise the image store from tag-only to ENTITY-keyed.
--
-- WHY
-- The 24 desktop forms carrying image buttons do NOT all photograph a tag. `MS_ACCT` stores a party photo
-- keyed on the account, `MS_MEMB` a member photo, `MS_PRODUCT` a scheme image, `MS_DESIGN_BOOK` a design.
-- Keying all of them on TAG_NO would have been wrong, so identity becomes (ENTITY_TYPE, ENTITY_KEY,
-- INSTANCE):
--
--   TAG    + tag number     + voucher serial   -- the 12 tag-image forms; also indexed in TAG_IMAGE_DATA
--   AC     + account code   + 0                -- party / karigar photo (MS_ACCT, TR_DHRN_ISU)
--   MEMB   + member code    + 0                -- membership photo (MS_MEMB)
--   SCHM   + scheme code    + 0                -- scheme artwork (MS_PRODUCT)
--   DESIGN + design number  + 0                -- design book image (MS_DESIGN_BOOK)
--
-- Only the TAG entity is mirrored into `TAG_IMAGE_DATA`, because that table is the desktop's tag index and
-- its primary key has no room for another entity kind.
--
-- Safe as a plain rename+add: the table was introduced hours earlier in this same work and holds no
-- production data.
ALTER TABLE "TAG_IMAGE_BLOB" RENAME TO "ENTITY_IMAGE";

ALTER TABLE "ENTITY_IMAGE"
  ADD COLUMN IF NOT EXISTS "ENTITY_TYPE" varchar(8) NOT NULL DEFAULT 'TAG';

-- TAG_NO becomes the generic key; INSTANCE replaces the tag-specific voucher serial.
ALTER TABLE "ENTITY_IMAGE" RENAME COLUMN "TAG_NO" TO "ENTITY_KEY";
ALTER TABLE "ENTITY_IMAGE" RENAME COLUMN "VCH_SRNO" TO "INSTANCE";

DROP INDEX IF EXISTS "tag_image_blob_key_uq";
CREATE UNIQUE INDEX IF NOT EXISTS "entity_image_key_uq"
  ON "ENTITY_IMAGE" ("tenant_id", "CO_CODE", "LC_CODE", "ENTITY_TYPE", "ENTITY_KEY", "INSTANCE");

DROP INDEX IF EXISTS "tag_image_blob_tenant_idx";
CREATE INDEX IF NOT EXISTS "entity_image_tenant_idx" ON "ENTITY_IMAGE" ("tenant_id");

ALTER TABLE "ENTITY_IMAGE" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "ENTITY_IMAGE" FORCE ROW LEVEL SECURITY;
DROP POLICY IF EXISTS "tenant_isolation" ON "ENTITY_IMAGE";
CREATE POLICY "tenant_isolation" ON "ENTITY_IMAGE"
  USING (("tenant_id")::text = current_setting('app.tenant_id', true))
  WITH CHECK (("tenant_id")::text = current_setting('app.tenant_id', true));
