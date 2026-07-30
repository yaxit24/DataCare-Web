-- Tier-2 integration test: RLS tenant isolation (Task 7/9).
-- Run: docker compose exec -T postgres psql -U datacare -d datacare -v ON_ERROR_STOP=1 -f - < packages/db/test/rls_isolation.sql
-- Expect: as t2 visible=1, as t1 visible=2, superuser total=3.
DO $$ BEGIN IF NOT EXISTS (SELECT FROM pg_roles WHERE rolname='app_user')
  THEN CREATE ROLE app_user LOGIN PASSWORD 'app' NOSUPERUSER; END IF; END $$;
GRANT USAGE ON SCHEMA public TO app_user;
GRANT SELECT,INSERT,UPDATE,DELETE ON ALL TABLES IN SCHEMA public TO app_user;
GRANT USAGE,SELECT ON ALL SEQUENCES IN SCHEMA public TO app_user;

TRUNCATE TABLE "AC_DATA";
SET ROLE app_user;
SELECT set_config('app.tenant_id','t1',false);
INSERT INTO "AC_DATA"(tenant_id) VALUES ('t1'),('t1');
SELECT set_config('app.tenant_id','t2',false);
INSERT INTO "AC_DATA"(tenant_id) VALUES ('t2');
SELECT 'as t2 visible='||count(*) FROM "AC_DATA";   -- expect 1
SELECT set_config('app.tenant_id','t1',false);
SELECT 'as t1 visible='||count(*) FROM "AC_DATA";   -- expect 2
RESET ROLE;
SELECT 'superuser total='||count(*) FROM "AC_DATA"; -- expect 3
TRUNCATE TABLE "AC_DATA";
