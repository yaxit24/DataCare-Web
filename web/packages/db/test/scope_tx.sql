-- Tier-2: proves the semantics withTenant()/atomic() rely on — set_config(local) + RLS + ROLLBACK.
-- Run: docker compose exec -T postgres psql -U datacare -d datacare -v ON_ERROR_STOP=1 -f - < packages/db/test/scope_tx.sql
-- Expect: after_rollback=0, tB_sees=0, superuser_total=1.
TRUNCATE TABLE "AC_DATA";

-- (1) rollback: a tenant-scoped tx that fails leaves nothing behind
BEGIN;
  SET LOCAL ROLE app_user;
  SELECT set_config('app.tenant_id','tA',true);
  INSERT INTO "AC_DATA"(tenant_id) VALUES ('tA'),('tA');
ROLLBACK;
SELECT 'after_rollback='||count(*) FROM "AC_DATA";   -- 0

-- (2) commit one tenant's row, then a different tenant must NOT see it
BEGIN;
  SET LOCAL ROLE app_user;
  SELECT set_config('app.tenant_id','tA',true);
  INSERT INTO "AC_DATA"(tenant_id) VALUES ('tA');
COMMIT;
BEGIN;
  SET LOCAL ROLE app_user;
  SELECT set_config('app.tenant_id','tB',true);
  SELECT 'tB_sees='||count(*) FROM "AC_DATA";          -- 0 (isolation)
COMMIT;
SELECT 'superuser_total='||count(*) FROM "AC_DATA";    -- 1
TRUNCATE TABLE "AC_DATA";
