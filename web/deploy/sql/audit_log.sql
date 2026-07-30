-- Compatibility bootstrap for installations that predate migration-owned audit_log.
-- New deployments receive the same DDL from 20260715010000_runtime_schema_security.
BEGIN;

CREATE TABLE IF NOT EXISTS "audit_log" (
  id bigserial PRIMARY KEY,
  tenant_id varchar(24) NOT NULL DEFAULT current_setting('app.tenant_id', true),
  ts timestamptz(6) NOT NULL DEFAULT now(),
  login_name varchar(64),
  co_code varchar(8),
  action varchar(16),
  path varchar(255),
  status integer
);
CREATE INDEX IF NOT EXISTS "audit_log_tenant_ts_idx"
  ON "audit_log" (tenant_id, ts);
ALTER TABLE "audit_log" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "audit_log" FORCE ROW LEVEL SECURITY;
DROP POLICY IF EXISTS audit_tenant ON "audit_log";
DROP POLICY IF EXISTS tenant_isolation ON "audit_log";
CREATE POLICY tenant_isolation ON "audit_log"
  USING (tenant_id = current_setting('app.tenant_id', true))
  WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

DO $$
BEGIN
  IF EXISTS (SELECT 1 FROM pg_roles WHERE rolname = 'app_user') THEN
    REVOKE UPDATE, DELETE, TRUNCATE ON TABLE "audit_log" FROM app_user;
    GRANT SELECT, INSERT ON TABLE "audit_log" TO app_user;
    GRANT USAGE, SELECT ON SEQUENCE "audit_log_id_seq" TO app_user;
  END IF;
END
$$;

COMMIT;
