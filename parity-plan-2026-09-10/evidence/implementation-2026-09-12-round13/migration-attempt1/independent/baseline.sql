-- Disposable-database fixture ONLY. Never execute against a runtime database.
BEGIN;
DO $guard$
BEGIN
  IF current_database() !~ '^datacare_context_migration_[a-z0-9_]+$' THEN
    RAISE EXCEPTION 'fixture requires a dedicated datacare_context_migration_ database';
  END IF;
  IF to_regclass('public.auth_session') IS NOT NULL THEN
    RAISE EXCEPTION 'fixture requires a fresh database without public.auth_session';
  END IF;
END
$guard$;

CREATE TABLE public.auth_session (
  tenant_id varchar(24) NOT NULL,
  session_id varchar(36) NOT NULL,
  login_name varchar(255) NOT NULL,
  login_co_code varchar(2) NOT NULL,
  co_code varchar(2) NOT NULL,
  lc_code varchar(2) NOT NULL,
  co_year varchar(9),
  refresh_jti_hash char(64) NOT NULL,
  created_at timestamptz(6) NOT NULL DEFAULT now(),
  last_used_at timestamptz(6) NOT NULL DEFAULT now(),
  expires_at timestamptz(6) NOT NULL,
  revoked_at timestamptz(6),
  revoke_reason varchar(40),
  CONSTRAINT auth_session_pkey PRIMARY KEY (tenant_id,session_id),
  CONSTRAINT auth_session_expiry_check CHECK (expires_at>created_at)
);
CREATE INDEX auth_session_login_idx ON public.auth_session (tenant_id,login_name,login_co_code);
CREATE INDEX auth_session_expiry_idx ON public.auth_session (tenant_id,expires_at);
ALTER TABLE public.auth_session ENABLE ROW LEVEL SECURITY;
ALTER TABLE public.auth_session FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON public.auth_session
  FOR ALL TO PUBLIC
  USING ((tenant_id)::text=current_setting('app.tenant_id',true))
  WITH CHECK ((tenant_id)::text=current_setting('app.tenant_id',true));
DO $grant_existing_role$
BEGIN
  IF EXISTS (SELECT 1 FROM pg_roles WHERE rolname='app_user') THEN
    GRANT SELECT,INSERT,UPDATE,DELETE ON TABLE public.auth_session TO app_user;
  END IF;
END
$grant_existing_role$;

INSERT INTO public.auth_session
  (tenant_id,session_id,login_name,login_co_code,co_code,lc_code,co_year,
   refresh_jti_hash,created_at,last_used_at,expires_at,revoked_at,revoke_reason)
VALUES
  ('migration-alpha','11111111-1111-4111-8111-111111111111','fixture-alpha','01','02','03','2024-2025',
   'aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa',
   '2024-01-02 03:04:05.123456+00','2024-06-07 08:09:10.654321+00','2030-01-01 00:00:00.000001+00',NULL,NULL),
  ('migration-beta','11111111-1111-4111-8111-111111111111','fixture-beta','03','03','01',NULL,
   'bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb',
   '2023-02-03 04:05:06.999999+00','2023-02-04 05:06:07.000001+00','2024-02-03 00:00:00+00',
   '2023-05-06 07:08:09.987654+00','fixture-revoked');
COMMIT;
