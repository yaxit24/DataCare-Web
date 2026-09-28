#!/bin/bash
set -e
cd /projects/sandbox/DataCare-Web/web
APP_PW='datacare_local_app_pw_2026'
psql -v ON_ERROR_STOP=1 -tAc "DO \$\$BEGIN IF NOT EXISTS (SELECT 1 FROM pg_roles WHERE rolname='datacare') THEN CREATE ROLE datacare LOGIN SUPERUSER PASSWORD 'datacare_local_pg'; END IF; END\$\$;"
psql -tAc "SELECT 1 FROM pg_database WHERE datname='datacare'" | grep -q 1 || psql -c "CREATE DATABASE datacare OWNER datacare"
export MIGRATE_DATABASE_URL='postgresql://datacare:datacare_local_pg@127.0.0.1:55433/datacare?schema=public'
DATABASE_URL="$MIGRATE_DATABASE_URL" pnpm --filter @datacare/db exec prisma migrate deploy --schema prisma/schema.prisma 2>&1 | tail -5
psql -X -U datacare -d datacare -v ON_ERROR_STOP=1 -q -f packages/db/prisma/rls.sql > /dev/null
psql -X -U datacare -d datacare -v ON_ERROR_STOP=1 -q -v app_password="$APP_PW" -f packages/db/setup_roles.sql > /dev/null
psql -X -U datacare -d datacare -At -c "SELECT count(*) FROM pg_tables WHERE schemaname='public'; SELECT count(*) FROM pg_class c JOIN pg_namespace n ON n.oid=c.relnamespace WHERE n.nspname='public' AND c.relkind='r' AND c.relforcerowsecurity; SELECT rolname, rolsuper, rolbypassrls FROM pg_roles WHERE rolname='app_user';"
