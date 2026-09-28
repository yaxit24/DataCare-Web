-- Web-only concurrency state. Keep the identity after bytes are deleted so a stale
-- client cannot mistake a delete/recreate sequence for its originally observed image.
-- Historical image bytes and desktop keys are unchanged; their initial revision is 0.
CREATE TABLE "ENTITY_IMAGE_REVISION" (
  tenant_id text NOT NULL,
  "CO_CODE" varchar(12) NOT NULL,
  "LC_CODE" varchar(12) NOT NULL DEFAULT '',
  "ENTITY_TYPE" varchar(8) NOT NULL,
  "ENTITY_KEY" varchar(255) NOT NULL,
  "INSTANCE" double precision NOT NULL,
  "REVISION" bigint NOT NULL DEFAULT 0 CHECK ("REVISION" >= 0),
  PRIMARY KEY (tenant_id,"CO_CODE","LC_CODE","ENTITY_TYPE","ENTITY_KEY","INSTANCE")
);
ALTER TABLE "ENTITY_IMAGE_REVISION" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "ENTITY_IMAGE_REVISION" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "ENTITY_IMAGE_REVISION"
  USING (tenant_id = current_setting('app.tenant_id', true))
  WITH CHECK (tenant_id = current_setting('app.tenant_id', true));
