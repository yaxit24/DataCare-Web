-- Repeatable RLS bootstrap. Apply after `prisma migrate deploy`.
-- Session must set tenant context transaction-locally through packages/db/src/tenant.ts.
--
-- WHY THIS IS DYNAMIC AND NOT A GENERATED TABLE LIST
-- =================================================
-- This file used to carry one hand-generated block per table (170 of them). Because it *first* drops every
-- policy named `tenant_isolation`/`audit_tenant` and *then* recreates only the tables in its own list, any
-- table that gained a policy in a migration but was missing from the list ended up with
--
--     RLS enabled + FORCED, and ZERO policies  ->  Postgres default-deny
--
-- which reads at runtime as "the table is silently empty" for SELECT and a hard RLS error for INSERT.
--
-- That is exactly what happened to `ENTITY_IMAGE` (migration 20260730030000) and `data_repair_run`
-- (migration 20260730010000). Both migrations create `tenant_isolation` correctly; this script dropped it
-- and never restored it, breaking entity images and the data-repair console and failing
-- packages/db/test/verify_runtime.sql with "170 of 172 tables have read/write policy".
--
-- Enumerating `tenant_id` columns from the catalogue removes the possibility of that drift: a new tenant
-- table is protected the moment it exists, with no second place to remember to edit.
BEGIN;

-- Drop the policies this script owns so it is idempotent. Any policy created by a migration under these
-- names is recreated identically by the loop below.
DO $$
DECLARE target record;
BEGIN
  FOR target IN
    SELECT schemaname, tablename, policyname
    FROM pg_policies
    WHERE schemaname = 'public'
      AND policyname IN ('tenant_isolation', 'audit_tenant')
  LOOP
    EXECUTE format('DROP POLICY %I ON %I.%I', target.policyname, target.schemaname, target.tablename);
  END LOOP;
END
$$;

-- Enable, force and police every ordinary table that carries a tenant_id column.
DO $$
DECLARE target record;
        protected int := 0;
BEGIN
  FOR target IN
    SELECT c.relname AS tablename
    FROM pg_class c
    JOIN pg_namespace n ON n.oid = c.relnamespace
    WHERE n.nspname = 'public'
      AND c.relkind = 'r'
      AND EXISTS (
        SELECT 1 FROM information_schema.columns col
        WHERE col.table_schema = 'public'
          AND col.table_name = c.relname
          AND col.column_name = 'tenant_id'
      )
    ORDER BY c.relname
  LOOP
    EXECUTE format('ALTER TABLE %I ENABLE ROW LEVEL SECURITY', target.tablename);
    EXECUTE format('ALTER TABLE %I FORCE ROW LEVEL SECURITY', target.tablename);
    EXECUTE format(
      'CREATE POLICY tenant_isolation ON %I'
      ' USING (tenant_id = current_setting(''app.tenant_id'', true))'
      ' WITH CHECK (tenant_id = current_setting(''app.tenant_id'', true))',
      target.tablename
    );
    protected := protected + 1;
  END LOOP;

  RAISE NOTICE 'rls.sql: protected % tenant table(s)', protected;
END
$$;

-- Fail the bootstrap rather than leaving a table forced-but-unpoliced. This is the invariant whose absence
-- allowed the ENTITY_IMAGE / data_repair_run outage to ship.
DO $$
DECLARE unpoliced text;
BEGIN
  SELECT string_agg(t.relname, ', ' ORDER BY t.relname) INTO unpoliced
  FROM pg_class t
  JOIN pg_namespace n ON n.oid = t.relnamespace
  WHERE n.nspname = 'public'
    AND t.relkind = 'r'
    AND EXISTS (
      SELECT 1 FROM information_schema.columns col
      WHERE col.table_schema = 'public'
        AND col.table_name = t.relname
        AND col.column_name = 'tenant_id'
    )
    AND NOT EXISTS (
      SELECT 1 FROM pg_policies p
      WHERE p.schemaname = 'public' AND p.tablename = t.relname
    );

  IF unpoliced IS NOT NULL THEN
    RAISE EXCEPTION 'rls.sql left tenant table(s) forced without a policy: %', unpoliced;
  END IF;
END
$$;

COMMIT;
