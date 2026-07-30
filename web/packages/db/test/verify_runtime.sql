\set ON_ERROR_STOP on

DO $$
DECLARE
  is_superuser boolean;
  bypasses_rls boolean;
  tenant_tables integer;
  protected_tables integer;
  policy_tables integer;
BEGIN
  SELECT rolsuper, rolbypassrls
  INTO is_superuser, bypasses_rls
  FROM pg_roles
  WHERE rolname = current_user;

  IF is_superuser OR bypasses_rls THEN
    RAISE EXCEPTION 'runtime role % is allowed to bypass RLS', current_user;
  END IF;

  SELECT
    count(*)::integer,
    count(*) FILTER (WHERE c.relrowsecurity AND c.relforcerowsecurity)::integer
  INTO tenant_tables, protected_tables
  FROM pg_class c
  JOIN pg_namespace n ON n.oid = c.relnamespace
  WHERE n.nspname = 'public'
    AND c.relkind IN ('r', 'p')
    AND EXISTS (
      SELECT 1 FROM pg_attribute a
      WHERE a.attrelid = c.oid
        AND a.attname = 'tenant_id'
        AND NOT a.attisdropped
    );

  IF tenant_tables = 0 OR protected_tables <> tenant_tables THEN
    RAISE EXCEPTION 'tenant RLS coverage incomplete: % of % tables protected',
      protected_tables, tenant_tables;
  END IF;

  SELECT count(DISTINCT (p.schemaname, p.tablename))::integer
  INTO policy_tables
  FROM pg_policies p
  WHERE p.schemaname = 'public'
    AND p.policyname = 'tenant_isolation'
    AND p.qual IS NOT NULL
    AND p.with_check IS NOT NULL;

  IF policy_tables <> tenant_tables THEN
    RAISE EXCEPTION 'tenant policy coverage incomplete: % of % tables have read/write policy',
      policy_tables, tenant_tables;
  END IF;

  RAISE NOTICE 'runtime role % safe; %/% tenant tables FORCE protected with write checks',
    current_user, protected_tables, tenant_tables;
END
$$;

BEGIN;
SELECT set_config('app.tenant_id', 'ci-tenant-a', true);
INSERT INTO "CO_MAST" ("tenant_id", "CO_CODE", "CO_NAME")
VALUES ('ci-tenant-a', 'ZZ', 'CI tenant A');

DO $$
BEGIN
  IF (SELECT count(*) FROM "CO_MAST" WHERE "CO_CODE" = 'ZZ') <> 1 THEN
    RAISE EXCEPTION 'tenant A cannot read its own probe row';
  END IF;
END
$$;

INSERT INTO "audit_log" (action, path, status)
VALUES ('CI', '/tenant-a-probe', 200);

-- Persistent authentication sessions must be writable by the runtime role but remain tenant-bound.
INSERT INTO "auth_session" (
  "tenant_id", "session_id", "login_name", "login_co_code", "co_code", "lc_code",
  "co_year", "refresh_jti_hash", "expires_at"
) VALUES (
  'ci-tenant-a', '00000000-0000-4000-8000-000000000001', 'ci-user', '01', '01', '01',
  '2024-2025', repeat('a', 64), clock_timestamp() + interval '1 day'
);
UPDATE "auth_session"
   SET "refresh_jti_hash"=repeat('b', 64), "last_used_at"=clock_timestamp()
 WHERE "session_id"='00000000-0000-4000-8000-000000000001'
   AND "refresh_jti_hash"=repeat('a', 64) AND "revoked_at" IS NULL;
UPDATE "auth_session"
   SET "revoked_at"=clock_timestamp(), "revoke_reason"='ci-revoke'
 WHERE "session_id"='00000000-0000-4000-8000-000000000001'
   AND "refresh_jti_hash"=repeat('b', 64) AND "revoked_at" IS NULL;

DO $$
BEGIN
  IF (
    SELECT count(*) FROM "auth_session"
     WHERE "session_id"='00000000-0000-4000-8000-000000000001'
       AND "refresh_jti_hash"=repeat('b', 64)
       AND "revoked_at" IS NOT NULL AND "revoke_reason"='ci-revoke'
  ) <> 1 THEN
    RAISE EXCEPTION 'runtime role could not create, rotate and revoke its auth session';
  END IF;
END
$$;

DO $$
BEGIN
  IF (SELECT count(*) FROM "audit_log" WHERE path = '/tenant-a-probe') <> 1 THEN
    RAISE EXCEPTION 'tenant A cannot read its own audit probe row';
  END IF;

  BEGIN
    UPDATE "audit_log" SET status = 500 WHERE path = '/tenant-a-probe';
    RAISE EXCEPTION 'runtime role unexpectedly updated audit_log';
  EXCEPTION
    WHEN insufficient_privilege THEN NULL;
  END;

  BEGIN
    DELETE FROM "audit_log" WHERE path = '/tenant-a-probe';
    RAISE EXCEPTION 'runtime role unexpectedly deleted from audit_log';
  EXCEPTION
    WHEN insufficient_privilege THEN NULL;
  END;

  BEGIN
    EXECUTE 'TRUNCATE TABLE "audit_log"';
    RAISE EXCEPTION 'runtime role unexpectedly truncated audit_log';
  EXCEPTION
    WHEN insufficient_privilege THEN NULL;
  END;
END
$$;

SELECT set_config('app.tenant_id', 'ci-tenant-b', true);
DO $$
BEGIN
  IF (SELECT count(*) FROM "CO_MAST" WHERE "CO_CODE" = 'ZZ') <> 0 THEN
    RAISE EXCEPTION 'tenant B can read tenant A probe row';
  END IF;
  IF (SELECT count(*) FROM "audit_log" WHERE path = '/tenant-a-probe') <> 0 THEN
    RAISE EXCEPTION 'tenant B can read tenant A audit probe row';
  END IF;
  IF (
    SELECT count(*) FROM "auth_session"
     WHERE "session_id"='00000000-0000-4000-8000-000000000001'
  ) <> 0 THEN
    RAISE EXCEPTION 'tenant B can read tenant A authentication session';
  END IF;
END
$$;

INSERT INTO "CO_MAST" ("tenant_id", "CO_CODE", "CO_NAME")
VALUES ('ci-tenant-b', 'ZZ', 'CI tenant B');

DO $$
BEGIN
  BEGIN
    INSERT INTO "CO_MAST" ("tenant_id", "CO_CODE", "CO_NAME")
    VALUES ('ci-tenant-a', 'ZY', 'forbidden cross-tenant write');
    RAISE EXCEPTION 'cross-tenant INSERT unexpectedly succeeded';
  EXCEPTION
    WHEN insufficient_privilege THEN
      NULL;
  END;

  BEGIN
    INSERT INTO "audit_log" (tenant_id, action, path, status)
    VALUES ('ci-tenant-a', 'CI', '/forbidden-audit-write', 500);
    RAISE EXCEPTION 'cross-tenant audit INSERT unexpectedly succeeded';
  EXCEPTION
    WHEN insufficient_privilege THEN
      NULL;
  END;
END
$$;

SELECT set_config('app.tenant_id', 'ci-tenant-a', true);
DO $$
BEGIN
  IF (SELECT count(*) FROM "CO_MAST" WHERE "CO_CODE" = 'ZZ') <> 1 THEN
    RAISE EXCEPTION 'tenant A isolation changed after tenant B insert';
  END IF;
  IF (
    SELECT count(*) FROM "audit_log"
    WHERE path = '/tenant-a-probe' AND status = 200
  ) <> 1 THEN
    RAISE EXCEPTION 'tenant A audit row was lost or mutated';
  END IF;
END
$$;

ROLLBACK;
