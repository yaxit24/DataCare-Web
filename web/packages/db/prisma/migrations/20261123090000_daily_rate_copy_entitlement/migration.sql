-- WP-33 Daily Rate residuals (decided 2026-11-23 by the architect, owner may override).
-- MS_RATE.cs:1937 copies a location-00 day to every other location only for one registered desktop install
-- (DC_Main.SSRegSrNo literal). The web replaces the hardcoded literal with an explicit per-company entitlement that
-- only an operator can provision: no API route writes this table, the default is off, and a company without a row is
-- off. Web-only table: the desktop has no equivalent. No data is written here, so no RLS bypass is needed.
CREATE TABLE "daily_rate_copy_entitlement" (
  "tenant_id"  varchar(24)    NOT NULL,
  "co_code"    varchar(2)     NOT NULL,
  "enabled"    boolean        NOT NULL DEFAULT false,
  "updated_by" varchar(64),
  "updated_at" timestamptz(6) NOT NULL DEFAULT now(),
  CONSTRAINT "daily_rate_copy_entitlement_pkey" PRIMARY KEY ("tenant_id", "co_code")
);

ALTER TABLE "daily_rate_copy_entitlement" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "daily_rate_copy_entitlement" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "daily_rate_copy_entitlement"
  USING (tenant_id = current_setting('app.tenant_id', true))
  WITH CHECK (tenant_id = current_setting('app.tenant_id', true));
