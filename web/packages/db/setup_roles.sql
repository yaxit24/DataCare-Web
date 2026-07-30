-- Runtime role for the app (RLS only enforces for NON-superusers). Idempotent.
-- Required invocation:
--   psql "$MIGRATE_DATABASE_URL" -v ON_ERROR_STOP=1 -v app_password="$APP_DB_PASSWORD" -f packages/db/setup_roles.sql
\if :{?app_password}
\else
  \echo 'setup_roles.sql requires -v app_password=...'
  \set app_password ''
\endif

-- Deliberately fail before changing the role when an empty/weak bootstrap secret is supplied.
SELECT CASE WHEN length(:'app_password') >= 16 THEN 1 ELSE 1 / 0 END AS password_length_ok;

DO $$
BEGIN
  IF NOT EXISTS (SELECT FROM pg_roles WHERE rolname = 'app_user') THEN
    CREATE ROLE app_user LOGIN;
  END IF;
END
$$;

-- format(%L) quotes the psql literal safely; the secret is never committed to this file.
SELECT format(
  'ALTER ROLE app_user WITH LOGIN PASSWORD %L NOSUPERUSER NOCREATEDB NOCREATEROLE NOINHERIT NOREPLICATION NOBYPASSRLS',
  :'app_password'
) \gexec

SELECT format('GRANT CONNECT ON DATABASE %I TO app_user', current_database()) \gexec
GRANT USAGE ON SCHEMA public TO app_user;
GRANT SELECT, INSERT, UPDATE, DELETE ON ALL TABLES IN SCHEMA public TO app_user;
REVOKE UPDATE, DELETE, TRUNCATE ON TABLE "audit_log" FROM app_user;
GRANT SELECT, INSERT ON TABLE "audit_log" TO app_user;
GRANT USAGE, SELECT ON ALL SEQUENCES IN SCHEMA public TO app_user;
ALTER DEFAULT PRIVILEGES IN SCHEMA public
  GRANT SELECT, INSERT, UPDATE, DELETE ON TABLES TO app_user;
ALTER DEFAULT PRIVILEGES IN SCHEMA public
  GRANT USAGE, SELECT ON SEQUENCES TO app_user;
