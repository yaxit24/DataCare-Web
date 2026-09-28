-- Add positive session context epochs, explicit unknown ledger context, and selection receipts.
-- Prerequisite: the authoritative auth_session migration is already installed.
-- Stop old context writers before adopting this migration and the matching new runtime.
-- The migration role must see every tenant despite FORCE ROW LEVEL SECURITY.
BEGIN;

DO $preflight$
DECLARE
  table_kind "char";
  rls_enabled boolean;
  rls_forced boolean;
  primary_columns text[];
BEGIN
  IF to_regclass('public.auth_session') IS NULL THEN
    RAISE EXCEPTION 'session context migration requires existing public.auth_session';
  END IF;
  LOCK TABLE public.auth_session IN ACCESS EXCLUSIVE MODE;

  SELECT c.relkind,c.relrowsecurity,c.relforcerowsecurity
    INTO table_kind,rls_enabled,rls_forced
    FROM pg_class c WHERE c.oid='public.auth_session'::regclass;
  IF table_kind <> 'r' OR NOT rls_enabled OR NOT rls_forced THEN
    RAISE EXCEPTION 'auth_session must be an ordinary table with enabled, forced tenant RLS';
  END IF;
  IF NOT EXISTS (
    SELECT 1 FROM pg_roles WHERE rolname=current_user AND (rolsuper OR rolbypassrls)
  ) THEN
    RAISE EXCEPTION 'session context migration requires a migration role with complete tenant visibility';
  END IF;

  SELECT array_agg(a.attname::text ORDER BY k.ordinality)
    INTO primary_columns
    FROM pg_constraint c
    CROSS JOIN LATERAL unnest(c.conkey) WITH ORDINALITY AS k(attnum,ordinality)
    JOIN pg_attribute a ON a.attrelid=c.conrelid AND a.attnum=k.attnum
   WHERE c.conrelid='public.auth_session'::regclass AND c.contype='p';
  IF primary_columns IS DISTINCT FROM ARRAY['tenant_id','session_id']::text[] THEN
    RAISE EXCEPTION 'auth_session primary key must remain (tenant_id,session_id)';
  END IF;
  IF EXISTS (SELECT 1 FROM pg_inherits
              WHERE inhrelid='public.auth_session'::regclass
                 OR inhparent='public.auth_session'::regclass)
     OR EXISTS (SELECT 1 FROM pg_trigger
                 WHERE tgrelid='public.auth_session'::regclass AND NOT tgisinternal)
     OR EXISTS (SELECT 1 FROM pg_rewrite WHERE ev_class='public.auth_session'::regclass) THEN
    RAISE EXCEPTION 'auth_session inheritance, user triggers, or rewrite rules require separate review';
  END IF;
END
$preflight$;

SET LOCAL row_security=off;

-- A temporary typed reference provides PostgreSQL-normalized definitions without evaluating
-- an unknown existing default or CHECK expression. It is dropped at commit/rollback.
CREATE TEMPORARY TABLE datacare_auth_context_v1_reference (
  tenant_id varchar(24) NOT NULL,
  session_id varchar(36) NOT NULL,
  login_name varchar(255) NOT NULL,
  login_co_code varchar(2) NOT NULL,
  co_code varchar(2) NOT NULL,
  lc_code varchar(2) NOT NULL,
  co_year varchar(9),
  refresh_jti_hash char(64) NOT NULL,
  created_at timestamptz(6) NOT NULL,
  last_used_at timestamptz(6) NOT NULL,
  expires_at timestamptz(6) NOT NULL,
  revoked_at timestamptz(6),
  revoke_reason varchar(40),
  context_epoch bigint NOT NULL DEFAULT 1,
  ledger_context jsonb NOT NULL DEFAULT
    '{"version":"server-session-ledger-context-v1","status":"unknown","mode":null,"reason":"vendor-authority-unresolved"}'::jsonb,
  last_context_selection_id varchar(36),
  last_context_request_sha256 char(64),
  last_context_from_epoch bigint,
  CONSTRAINT auth_session_expiry_check CHECK (expires_at>created_at),
  CONSTRAINT auth_session_context_epoch_v1_check CHECK (context_epoch > 0),
  CONSTRAINT auth_session_ledger_context_v1_check CHECK (
    ledger_context IN (
      '{"version":"server-session-ledger-context-v1","status":"unknown","mode":null,"reason":"vendor-authority-unresolved"}'::jsonb,
      '{"version":"server-session-ledger-context-v1","status":"unknown","mode":null,"reason":"legacy-session-uninitialized"}'::jsonb,
      '{"version":"server-session-ledger-context-v1","status":"unknown","mode":null,"reason":"scope-incomplete"}'::jsonb
    )
  ),
  CONSTRAINT auth_session_context_receipt_v1_check CHECK (
    (
      last_context_selection_id IS NULL
      AND last_context_request_sha256 IS NULL
      AND last_context_from_epoch IS NULL
    ) OR (
      last_context_selection_id IS NOT NULL
      AND last_context_request_sha256 IS NOT NULL
      AND last_context_from_epoch IS NOT NULL
      AND octet_length(last_context_selection_id)=36
      AND (last_context_selection_id COLLATE "C") ~
        '^[0-9a-f]{8}-[0-9a-f]{4}-4[0-9a-f]{3}-[89ab][0-9a-f]{3}-[0-9a-f]{12}$'
      AND (last_context_request_sha256::text COLLATE "C") ~ '^[0-9a-f]{64}$'
      AND last_context_from_epoch > 0
      AND last_context_from_epoch < context_epoch
    )
  )
) ON COMMIT DROP;

CREATE POLICY tenant_isolation ON pg_temp.datacare_auth_context_v1_reference
  FOR ALL TO PUBLIC
  USING ((tenant_id)::text=current_setting('app.tenant_id',true))
  WITH CHECK ((tenant_id)::text=current_setting('app.tenant_id',true));

-- Existing columns are never recast, truncated, renamed, or reconstructed. Base-column metadata
-- must already match the historical schema. Only nullability of the two new required columns
-- may be temporarily weaker in a compatible partial rollout.
DO $compatible_columns$
DECLARE
  reference_column record;
  actual_column record;
  actual_default text;
  expected_default text;
  new_column boolean;
  actual_policy record;
  expected_policy record;
  actual_expiry record;
  expected_expiry text;
BEGIN
  FOR reference_column IN
    SELECT a.* FROM pg_attribute a
     WHERE a.attrelid='pg_temp.datacare_auth_context_v1_reference'::regclass
       AND a.attnum>0 AND NOT a.attisdropped
  LOOP
    new_column := reference_column.attname IN (
      'context_epoch','ledger_context','last_context_selection_id',
      'last_context_request_sha256','last_context_from_epoch'
    );
    SELECT a.* INTO actual_column FROM pg_attribute a
     WHERE a.attrelid='public.auth_session'::regclass
       AND a.attname=reference_column.attname AND NOT a.attisdropped;
    IF NOT FOUND THEN
      IF new_column THEN CONTINUE; END IF;
      RAISE EXCEPTION 'auth_session missing legacy column %',reference_column.attname;
    END IF;
    IF actual_column.atttypid <> reference_column.atttypid
       OR actual_column.atttypmod <> reference_column.atttypmod
       OR actual_column.attcollation <> reference_column.attcollation
       OR actual_column.attidentity <> '' OR actual_column.attgenerated <> '' THEN
      RAISE EXCEPTION 'auth_session column % has an incompatible type, collation, or generation',
        reference_column.attname;
    END IF;
    IF (NOT new_column AND actual_column.attnotnull <> reference_column.attnotnull)
       OR (new_column AND NOT reference_column.attnotnull AND actual_column.attnotnull) THEN
      RAISE EXCEPTION 'auth_session column % has incompatible nullability',reference_column.attname;
    END IF;

    IF new_column THEN
      SELECT pg_get_expr(d.adbin,d.adrelid) INTO actual_default FROM pg_attrdef d
       WHERE d.adrelid=actual_column.attrelid AND d.adnum=actual_column.attnum;
      SELECT pg_get_expr(d.adbin,d.adrelid) INTO expected_default FROM pg_attrdef d
       WHERE d.adrelid=reference_column.attrelid AND d.adnum=reference_column.attnum;
      IF actual_default IS NOT NULL AND actual_default IS DISTINCT FROM expected_default THEN
        RAISE EXCEPTION 'auth_session column % has an incompatible default',reference_column.attname;
      END IF;
    END IF;
  END LOOP;

  SELECT pg_get_expr(c.conbin,c.conrelid) INTO expected_expiry FROM pg_constraint c
   WHERE c.conrelid='pg_temp.datacare_auth_context_v1_reference'::regclass
     AND c.conname='auth_session_expiry_check';
  SELECT c.contype,c.convalidated,c.connoinherit,
         pg_get_expr(c.conbin,c.conrelid) AS expression_sql
    INTO actual_expiry FROM pg_constraint c
   WHERE c.conrelid='public.auth_session'::regclass AND c.conname='auth_session_expiry_check';
  IF NOT FOUND THEN
    RAISE EXCEPTION 'auth_session is missing the existing expiry check';
  END IF;
  IF actual_expiry.contype <> 'c' OR NOT actual_expiry.convalidated OR actual_expiry.connoinherit
     OR actual_expiry.expression_sql IS DISTINCT FROM expected_expiry THEN
    RAISE EXCEPTION 'auth_session expiry check differs from the required validated baseline';
  END IF;

  SELECT p.*,pg_get_expr(p.polqual,p.polrelid) AS using_sql,
         pg_get_expr(p.polwithcheck,p.polrelid) AS check_sql
    INTO expected_policy FROM pg_policy p
   WHERE p.polrelid='pg_temp.datacare_auth_context_v1_reference'::regclass
     AND p.polname='tenant_isolation';
  SELECT p.*,pg_get_expr(p.polqual,p.polrelid) AS using_sql,
         pg_get_expr(p.polwithcheck,p.polrelid) AS check_sql
    INTO actual_policy FROM pg_policy p
   WHERE p.polrelid='public.auth_session'::regclass AND p.polname='tenant_isolation';
  IF NOT FOUND THEN
    RAISE EXCEPTION 'auth_session is missing the existing tenant_isolation policy';
  END IF;
  IF actual_policy.polcmd IS DISTINCT FROM expected_policy.polcmd
     OR actual_policy.polpermissive IS DISTINCT FROM expected_policy.polpermissive
     OR actual_policy.polroles IS DISTINCT FROM expected_policy.polroles
     OR actual_policy.using_sql IS DISTINCT FROM expected_policy.using_sql
     OR actual_policy.check_sql IS DISTINCT FROM expected_policy.check_sql THEN
    RAISE EXCEPTION 'auth_session tenant_isolation policy differs from the required baseline';
  END IF;
END
$compatible_columns$;

ALTER TABLE public.auth_session
  ADD COLUMN IF NOT EXISTS context_epoch bigint,
  ADD COLUMN IF NOT EXISTS ledger_context jsonb,
  ADD COLUMN IF NOT EXISTS last_context_selection_id varchar(36),
  ADD COLUMN IF NOT EXISTS last_context_request_sha256 char(64),
  ADD COLUMN IF NOT EXISTS last_context_from_epoch bigint;

-- Never overwrite a non-NULL existing value. Adding the same-named CHECK only after comparing
-- its normalized definition prevents an earlier weaker/foreign constraint from being trusted.
DO $constraints_and_values$
DECLARE
  expected_constraint record;
  actual_constraint record;
  invalid_rows boolean;
BEGIN
  FOR expected_constraint IN
    SELECT c.conname,pg_get_expr(c.conbin,c.conrelid) AS expression_sql,
           pg_get_constraintdef(c.oid) AS definition_sql
      FROM pg_constraint c
     WHERE c.conrelid='pg_temp.datacare_auth_context_v1_reference'::regclass
       AND c.contype='c'
       AND c.conname IN ('auth_session_context_epoch_v1_check',
         'auth_session_ledger_context_v1_check','auth_session_context_receipt_v1_check')
  LOOP
    SELECT c.contype,c.connoinherit,pg_get_expr(c.conbin,c.conrelid) AS expression_sql
      INTO actual_constraint FROM pg_constraint c
     WHERE c.conrelid='public.auth_session'::regclass AND c.conname=expected_constraint.conname;
    IF FOUND THEN
      IF actual_constraint.contype <> 'c' OR actual_constraint.connoinherit
         OR actual_constraint.expression_sql IS DISTINCT FROM expected_constraint.expression_sql THEN
        RAISE EXCEPTION 'auth_session constraint % is incompatible',expected_constraint.conname;
      END IF;
    ELSE
      EXECUTE format('ALTER TABLE public.auth_session ADD CONSTRAINT %I %s NOT VALID',
        expected_constraint.conname,expected_constraint.definition_sql);
    END IF;

    EXECUTE format('SELECT EXISTS (SELECT 1 FROM public.auth_session WHERE (%s) IS FALSE)',
      expected_constraint.expression_sql) INTO invalid_rows;
    IF invalid_rows THEN
      RAISE EXCEPTION 'auth_session contains invalid non-NULL values for %',expected_constraint.conname;
    END IF;
  END LOOP;

  -- A receipt with a missing current epoch cannot be safely backfilled to generation 1.
  IF EXISTS (SELECT 1 FROM public.auth_session
              WHERE context_epoch IS NULL AND (
                last_context_selection_id IS NOT NULL
                OR last_context_request_sha256 IS NOT NULL
                OR last_context_from_epoch IS NOT NULL
              )) THEN
    RAISE EXCEPTION 'auth_session receipt has no existing current epoch';
  END IF;
END
$constraints_and_values$;

UPDATE public.auth_session
   SET context_epoch=COALESCE(context_epoch,1),
       ledger_context=COALESCE(ledger_context,
         '{"version":"server-session-ledger-context-v1","status":"unknown","mode":null,"reason":"legacy-session-uninitialized"}'::jsonb)
 WHERE context_epoch IS NULL OR ledger_context IS NULL;

ALTER TABLE public.auth_session
  ALTER COLUMN context_epoch SET DEFAULT 1,
  ALTER COLUMN context_epoch SET NOT NULL,
  ALTER COLUMN ledger_context SET DEFAULT
    '{"version":"server-session-ledger-context-v1","status":"unknown","mode":null,"reason":"vendor-authority-unresolved"}'::jsonb,
  ALTER COLUMN ledger_context SET NOT NULL,
  VALIDATE CONSTRAINT auth_session_context_epoch_v1_check,
  VALIDATE CONSTRAINT auth_session_ledger_context_v1_check,
  VALIDATE CONSTRAINT auth_session_context_receipt_v1_check;

-- No changes to legacy fields, PK/indexes, expiry constraint, policies, RLS flags, owner, or ACL.
-- No known mode, business/config/ledger update, expiry extension, or refresh-token rotation.
COMMIT;
