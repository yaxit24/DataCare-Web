-- Owner decision 2026-11-25; default preserves desktop Lite All visibility.
ALTER TABLE "LOGIN_MAST"
 ADD COLUMN "DATA_TYPE_ALLOW" varchar(3) NOT NULL DEFAULT 'ABC',
 ADD COLUMN "DATA_TYPE_DEFAULT" varchar(1) NOT NULL DEFAULT 'C',
 ADD CONSTRAINT "login_data_type_allow" CHECK ("DATA_TYPE_ALLOW" IN ('A','B','C','AB','AC','BC','ABC')),
 ADD CONSTRAINT "login_data_type_default" CHECK ("DATA_TYPE_DEFAULT" IN ('A','B','C') AND position("DATA_TYPE_DEFAULT" in "DATA_TYPE_ALLOW") > 0);
ALTER TABLE "auth_session" ADD COLUMN "data_type" varchar(1) NOT NULL DEFAULT 'C'
 CHECK ("data_type" IN ('A','B','C'));
CREATE TABLE "tenant_feature" (
 "tenant_id" varchar(24) NOT NULL,
 "feature" varchar(64) NOT NULL,
 "enabled" boolean NOT NULL DEFAULT true,
 PRIMARY KEY ("tenant_id", "feature")
);
ALTER TABLE "tenant_feature" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "tenant_feature" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "tenant_feature"
 USING (tenant_id = current_setting('app.tenant_id', true))
 WITH CHECK (tenant_id = current_setting('app.tenant_id', true));
