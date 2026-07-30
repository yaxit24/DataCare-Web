-- Converge migration ownership and tenant security for both fresh installs and upgrades.
-- Historical migrations are intentionally left immutable.
BEGIN;

CREATE SEQUENCE IF NOT EXISTS "audit_log_id_seq";
CREATE TABLE IF NOT EXISTS "audit_log" (
  "id" bigint NOT NULL DEFAULT nextval('"audit_log_id_seq"'),
  "tenant_id" varchar(24) NOT NULL DEFAULT current_setting('app.tenant_id', true),
  "ts" timestamptz(6) NOT NULL DEFAULT now(),
  "login_name" varchar(64),
  "co_code" varchar(8),
  "action" varchar(16),
  "path" varchar(255),
  "status" integer
);
ALTER SEQUENCE "audit_log_id_seq" OWNED BY "audit_log"."id";

-- CREATE TABLE IF NOT EXISTS does not converge a partially/manual-deployed table.
ALTER TABLE "audit_log" ADD COLUMN IF NOT EXISTS "id" bigint;
ALTER TABLE "audit_log" ADD COLUMN IF NOT EXISTS "tenant_id" varchar(24);
ALTER TABLE "audit_log" ADD COLUMN IF NOT EXISTS "ts" timestamptz(6);
ALTER TABLE "audit_log" ADD COLUMN IF NOT EXISTS "login_name" varchar(64);
ALTER TABLE "audit_log" ADD COLUMN IF NOT EXISTS "co_code" varchar(8);
ALTER TABLE "audit_log" ADD COLUMN IF NOT EXISTS "action" varchar(16);
ALTER TABLE "audit_log" ADD COLUMN IF NOT EXISTS "path" varchar(255);
ALTER TABLE "audit_log" ADD COLUMN IF NOT EXISTS "status" integer;
ALTER TABLE "audit_log" ALTER COLUMN "id" SET DEFAULT nextval('"audit_log_id_seq"');
ALTER TABLE "audit_log" ALTER COLUMN "tenant_id" SET DEFAULT current_setting('app.tenant_id', true);
ALTER TABLE "audit_log" ALTER COLUMN "ts" SET DEFAULT now();

-- A previously deployed audit table has these constraints already. A malformed partial table fails
-- here rather than silently accepting unscoped or unkeyed audit rows.
DO $$
BEGIN
  IF EXISTS (SELECT 1 FROM "audit_log" WHERE "id" IS NULL) THEN
    RAISE EXCEPTION 'audit_log contains NULL id values; repair before migration';
  END IF;
  IF EXISTS (SELECT 1 FROM "audit_log" WHERE "tenant_id" IS NULL OR "tenant_id" = '') THEN
    RAISE EXCEPTION 'audit_log contains unscoped tenant rows; repair before migration';
  END IF;
  IF EXISTS (SELECT 1 FROM "audit_log" WHERE "ts" IS NULL) THEN
    RAISE EXCEPTION 'audit_log contains NULL timestamps; repair before migration';
  END IF;
END
$$;
ALTER TABLE "audit_log" ALTER COLUMN "id" SET NOT NULL;
ALTER TABLE "audit_log" ALTER COLUMN "tenant_id" SET NOT NULL;
ALTER TABLE "audit_log" ALTER COLUMN "ts" SET NOT NULL;

DO $$
BEGIN
  IF NOT EXISTS (
    SELECT 1 FROM pg_constraint
    WHERE conrelid = 'public.audit_log'::regclass AND contype = 'p'
  ) THEN
    ALTER TABLE "audit_log" ADD CONSTRAINT "audit_log_pkey" PRIMARY KEY ("id");
  END IF;
END
$$;

CREATE INDEX IF NOT EXISTS "audit_log_tenant_ts_idx"
  ON "audit_log" ("tenant_id", "ts");
CREATE INDEX IF NOT EXISTS "COUNTRY_MAST_tenant_idx"
  ON "COUNTRY_MAST" ("tenant_id");
CREATE INDEX IF NOT EXISTS "IMAGE_DATA_tenant_idx"
  ON "IMAGE_DATA" ("tenant_id");
CREATE INDEX IF NOT EXISTS "IMAGE_DATA_tag_idx"
  ON "IMAGE_DATA" ("tenant_id", "CO_CODE", "LC_CODE", "TAG_NO");
CREATE INDEX IF NOT EXISTS "LBR_ISU_IDTL_tenant_idx"
  ON "LBR_ISU_IDTL" ("tenant_id");
CREATE INDEX IF NOT EXISTS "OP_DETL_tenant_idx"
  ON "OP_DETL" ("tenant_id");
CREATE INDEX IF NOT EXISTS "OP_DETL_voucher_idx"
  ON "OP_DETL" ("tenant_id", "CO_CODE", "LC_CODE", "CO_YEAR", "CO_BOOK", "VCH_NO");

-- Rebuild only the repository's generic tenant policies. Other purpose-specific policies, if any,
-- are preserved. Explicit WITH CHECK prevents cross-tenant INSERT/UPDATE as well as reads.
DO $$
DECLARE
  target record;
  policy_name text;
BEGIN
  FOR target IN
    SELECT n.nspname AS schema_name, c.relname AS table_name
    FROM pg_class c
    JOIN pg_namespace n ON n.oid = c.relnamespace
    WHERE n.nspname = 'public'
      AND c.relkind IN ('r', 'p')
      AND EXISTS (
        SELECT 1
        FROM pg_attribute a
        WHERE a.attrelid = c.oid
          AND a.attname = 'tenant_id'
          AND NOT a.attisdropped
      )
    ORDER BY c.relname
  LOOP
    EXECUTE format('ALTER TABLE %I.%I ENABLE ROW LEVEL SECURITY', target.schema_name, target.table_name);
    EXECUTE format('ALTER TABLE %I.%I FORCE ROW LEVEL SECURITY', target.schema_name, target.table_name);

    FOR policy_name IN
      SELECT p.policyname
      FROM pg_policies p
      WHERE p.schemaname = target.schema_name
        AND p.tablename = target.table_name
        AND p.policyname IN ('tenant_isolation', 'audit_tenant')
    LOOP
      EXECUTE format(
        'DROP POLICY %I ON %I.%I',
        policy_name,
        target.schema_name,
        target.table_name
      );
    END LOOP;

    EXECUTE format(
      'CREATE POLICY tenant_isolation ON %I.%I FOR ALL TO PUBLIC USING ((tenant_id)::text = current_setting(''app.tenant_id'', true)) WITH CHECK ((tenant_id)::text = current_setting(''app.tenant_id'', true))',
      target.schema_name,
      target.table_name
    );
  END LOOP;
END
$$;

-- setup_roles.sql normally runs after migrations. Preserve idempotent upgrades where it already exists.
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
