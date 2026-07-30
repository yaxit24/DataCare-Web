-- Authoritative scope, per-form RBAC and revocable refresh-session ownership.
-- Historical migrations remain immutable; this migration upgrades fresh and existing installations.
-- Fail clearly before transactional DDL when a manually pre-created session table cannot be
-- completed safely. The in-transaction checks below remain the authoritative data validation.
DO $preflight$
DECLARE
  primary_key_columns text[];
  missing_required_columns integer;
  has_rows boolean;
BEGIN
  IF to_regclass('public."auth_session"') IS NULL THEN
    RETURN;
  END IF;

  SELECT array_agg(a.attname ORDER BY k.ordinality)
    INTO primary_key_columns
    FROM pg_constraint c
    CROSS JOIN LATERAL unnest(c.conkey) WITH ORDINALITY AS k(attnum, ordinality)
    JOIN pg_attribute a ON a.attrelid=c.conrelid AND a.attnum=k.attnum
   WHERE c.conrelid='public."auth_session"'::regclass AND c.contype='p';

  IF primary_key_columns IS NOT NULL
     AND primary_key_columns <> ARRAY['tenant_id','session_id']::text[] THEN
    RAISE EXCEPTION 'auth_session has incompatible primary key columns: %', primary_key_columns;
  END IF;

  EXECUTE 'SELECT EXISTS (SELECT 1 FROM public."auth_session")' INTO has_rows;
  IF has_rows THEN
    SELECT count(*)::integer
      INTO missing_required_columns
      FROM unnest(ARRAY[
        'tenant_id','session_id','login_name','login_co_code','co_code','lc_code',
        'refresh_jti_hash','created_at','last_used_at','expires_at'
      ]) AS required(column_name)
     WHERE NOT EXISTS (
       SELECT 1 FROM pg_attribute a
        WHERE a.attrelid='public."auth_session"'::regclass
          AND a.attname=required.column_name AND NOT a.attisdropped
     );
    IF missing_required_columns > 0 THEN
      RAISE EXCEPTION
        'non-empty auth_session partial table is missing % required columns',
        missing_required_columns;
    END IF;
  END IF;
END
$preflight$;

BEGIN;

ALTER TABLE "LOGIN_MAST"
  ADD COLUMN IF NOT EXISTS "USER_UPDATE" VARCHAR(1),
  ADD COLUMN IF NOT EXISTS "USER_DELETE" VARCHAR(1),
  ADD COLUMN IF NOT EXISTS "USER_PRINT" VARCHAR(1),
  ADD COLUMN IF NOT EXISTS "PASSWORD_RESET_REQUIRED" VARCHAR(1) NOT NULL DEFAULT 'N',
  ADD COLUMN IF NOT EXISTS "PASSWORD_CHANGED_AT" TIMESTAMPTZ(6);

UPDATE "LOGIN_MAST"
   SET "PASSWORD_RESET_REQUIRED"='N'
 WHERE "PASSWORD_RESET_REQUIRED" IS NULL OR "PASSWORD_RESET_REQUIRED" NOT IN ('Y','N');
ALTER TABLE "LOGIN_MAST" ALTER COLUMN "PASSWORD_RESET_REQUIRED" SET DEFAULT 'N';
ALTER TABLE "LOGIN_MAST" ALTER COLUMN "PASSWORD_RESET_REQUIRED" SET NOT NULL;

DO $$
BEGIN
  IF NOT EXISTS (
    SELECT 1 FROM pg_constraint
     WHERE conrelid='public."LOGIN_MAST"'::regclass
       AND conname='LOGIN_MAST_password_reset_check'
  ) THEN
    ALTER TABLE "LOGIN_MAST"
      ADD CONSTRAINT "LOGIN_MAST_password_reset_check"
      CHECK ("PASSWORD_RESET_REQUIRED" IN ('Y','N'));
  END IF;
END
$$;

CREATE INDEX IF NOT EXISTS "LOGIN_MAST_identity_idx"
  ON "LOGIN_MAST" ("tenant_id","CO_CODE","LOGIN_NAME");

CREATE TABLE IF NOT EXISTS "auth_session" (
  "tenant_id" VARCHAR(24) NOT NULL,
  "session_id" VARCHAR(36) NOT NULL,
  "login_name" VARCHAR(255) NOT NULL,
  "login_co_code" VARCHAR(2) NOT NULL,
  "co_code" VARCHAR(2) NOT NULL,
  "lc_code" VARCHAR(2) NOT NULL,
  "co_year" VARCHAR(9),
  "refresh_jti_hash" CHAR(64) NOT NULL,
  "created_at" TIMESTAMPTZ(6) NOT NULL DEFAULT NOW(),
  "last_used_at" TIMESTAMPTZ(6) NOT NULL DEFAULT NOW(),
  "expires_at" TIMESTAMPTZ(6) NOT NULL,
  "revoked_at" TIMESTAMPTZ(6),
  "revoke_reason" VARCHAR(40),
  CONSTRAINT "auth_session_pkey" PRIMARY KEY ("tenant_id","session_id"),
  CONSTRAINT "auth_session_expiry_check" CHECK ("expires_at">"created_at")
);

-- A prior db-push or interrupted manual rollout may have created only part of this new table.
-- Complete an empty/compatible partial table; incompatible data or a conflicting primary key fails
-- the transaction rather than leaving a session store with weaker identity or expiry guarantees.
ALTER TABLE "auth_session"
  ADD COLUMN IF NOT EXISTS "tenant_id" VARCHAR(24),
  ADD COLUMN IF NOT EXISTS "session_id" VARCHAR(36),
  ADD COLUMN IF NOT EXISTS "login_name" VARCHAR(255),
  ADD COLUMN IF NOT EXISTS "login_co_code" VARCHAR(2),
  ADD COLUMN IF NOT EXISTS "co_code" VARCHAR(2),
  ADD COLUMN IF NOT EXISTS "lc_code" VARCHAR(2),
  ADD COLUMN IF NOT EXISTS "co_year" VARCHAR(9),
  ADD COLUMN IF NOT EXISTS "refresh_jti_hash" CHAR(64),
  ADD COLUMN IF NOT EXISTS "created_at" TIMESTAMPTZ(6),
  ADD COLUMN IF NOT EXISTS "last_used_at" TIMESTAMPTZ(6),
  ADD COLUMN IF NOT EXISTS "expires_at" TIMESTAMPTZ(6),
  ADD COLUMN IF NOT EXISTS "revoked_at" TIMESTAMPTZ(6),
  ADD COLUMN IF NOT EXISTS "revoke_reason" VARCHAR(40);

ALTER TABLE "auth_session"
  ALTER COLUMN "tenant_id" TYPE VARCHAR(24) USING "tenant_id"::VARCHAR(24),
  ALTER COLUMN "session_id" TYPE VARCHAR(36) USING "session_id"::VARCHAR(36),
  ALTER COLUMN "login_name" TYPE VARCHAR(255) USING "login_name"::VARCHAR(255),
  ALTER COLUMN "login_co_code" TYPE VARCHAR(2) USING "login_co_code"::VARCHAR(2),
  ALTER COLUMN "co_code" TYPE VARCHAR(2) USING "co_code"::VARCHAR(2),
  ALTER COLUMN "lc_code" TYPE VARCHAR(2) USING "lc_code"::VARCHAR(2),
  ALTER COLUMN "co_year" TYPE VARCHAR(9) USING "co_year"::VARCHAR(9),
  ALTER COLUMN "refresh_jti_hash" TYPE CHAR(64) USING "refresh_jti_hash"::CHAR(64),
  ALTER COLUMN "created_at" TYPE TIMESTAMPTZ(6) USING "created_at"::TIMESTAMPTZ(6),
  ALTER COLUMN "last_used_at" TYPE TIMESTAMPTZ(6) USING "last_used_at"::TIMESTAMPTZ(6),
  ALTER COLUMN "expires_at" TYPE TIMESTAMPTZ(6) USING "expires_at"::TIMESTAMPTZ(6),
  ALTER COLUMN "revoked_at" TYPE TIMESTAMPTZ(6) USING "revoked_at"::TIMESTAMPTZ(6),
  ALTER COLUMN "revoke_reason" TYPE VARCHAR(40) USING "revoke_reason"::VARCHAR(40);

DO $$
DECLARE
  primary_key_columns text[];
BEGIN
  IF EXISTS (
    SELECT 1 FROM "auth_session"
     WHERE "tenant_id" IS NULL OR "session_id" IS NULL OR "login_name" IS NULL
        OR "login_co_code" IS NULL OR "co_code" IS NULL OR "lc_code" IS NULL
        OR "refresh_jti_hash" IS NULL OR "created_at" IS NULL
        OR "last_used_at" IS NULL OR "expires_at" IS NULL
        OR "expires_at" <= "created_at"
  ) THEN
    RAISE EXCEPTION 'auth_session contains incomplete or invalid pre-migration rows';
  END IF;

  IF EXISTS (
    SELECT 1 FROM "auth_session"
     GROUP BY "tenant_id", "session_id" HAVING count(*) > 1
  ) THEN
    RAISE EXCEPTION 'auth_session contains duplicate tenant/session identities';
  END IF;

  SELECT array_agg(a.attname ORDER BY k.ordinality)
    INTO primary_key_columns
    FROM pg_constraint c
    CROSS JOIN LATERAL unnest(c.conkey) WITH ORDINALITY AS k(attnum, ordinality)
    JOIN pg_attribute a ON a.attrelid=c.conrelid AND a.attnum=k.attnum
   WHERE c.conrelid='public."auth_session"'::regclass AND c.contype='p';

  IF primary_key_columns IS NULL THEN
    ALTER TABLE "auth_session"
      ADD CONSTRAINT "auth_session_pkey" PRIMARY KEY ("tenant_id","session_id");
  ELSIF primary_key_columns <> ARRAY['tenant_id','session_id']::text[] THEN
    RAISE EXCEPTION 'auth_session has incompatible primary key columns: %', primary_key_columns;
  END IF;

  IF NOT EXISTS (
    SELECT 1 FROM pg_constraint
     WHERE conrelid='public."auth_session"'::regclass
       AND conname='auth_session_expiry_check'
  ) THEN
    ALTER TABLE "auth_session"
      ADD CONSTRAINT "auth_session_expiry_check" CHECK ("expires_at">"created_at");
  END IF;
END
$$;

ALTER TABLE "auth_session"
  ALTER COLUMN "created_at" SET DEFAULT NOW(),
  ALTER COLUMN "last_used_at" SET DEFAULT NOW(),
  ALTER COLUMN "tenant_id" SET NOT NULL,
  ALTER COLUMN "session_id" SET NOT NULL,
  ALTER COLUMN "login_name" SET NOT NULL,
  ALTER COLUMN "login_co_code" SET NOT NULL,
  ALTER COLUMN "co_code" SET NOT NULL,
  ALTER COLUMN "lc_code" SET NOT NULL,
  ALTER COLUMN "refresh_jti_hash" SET NOT NULL,
  ALTER COLUMN "created_at" SET NOT NULL,
  ALTER COLUMN "last_used_at" SET NOT NULL,
  ALTER COLUMN "expires_at" SET NOT NULL;

CREATE INDEX IF NOT EXISTS "auth_session_login_idx"
  ON "auth_session" ("tenant_id","login_name","login_co_code");
CREATE INDEX IF NOT EXISTS "auth_session_expiry_idx"
  ON "auth_session" ("tenant_id","expires_at");

ALTER TABLE "auth_session" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "auth_session" FORCE ROW LEVEL SECURITY;
DROP POLICY IF EXISTS tenant_isolation ON "auth_session";
DROP POLICY IF EXISTS audit_tenant ON "auth_session";
CREATE POLICY tenant_isolation ON "auth_session"
  FOR ALL TO PUBLIC
  USING (("tenant_id")::text=current_setting('app.tenant_id',true))
  WITH CHECK (("tenant_id")::text=current_setting('app.tenant_id',true));

-- setup_roles.sql normally runs after migrations. Existing installations may already have app_user.
DO $$
BEGIN
  IF EXISTS (SELECT 1 FROM pg_roles WHERE rolname='app_user') THEN
    GRANT SELECT,INSERT,UPDATE,DELETE ON TABLE "auth_session" TO app_user;
    GRANT SELECT,INSERT,UPDATE,DELETE ON TABLE "LOGIN_MAST" TO app_user;
  END IF;
END
$$;

COMMIT;
