-- WP-02A logical company restore must preserve explicit technical row IDs while all tenant tables use
-- FORCE ROW LEVEL SECURITY. The runtime role therefore cannot calculate a cross-tenant MAX(row_id), and
-- granting broad sequence UPDATE would permit arbitrary setval() calls. This SECURITY DEFINER function
-- exposes no row data and can only move a sequence owned by a company-scoped public table forward.
CREATE OR REPLACE FUNCTION public.datacare_advance_owned_sequence(
  p_table regclass,
  p_column name
) RETURNS bigint
LANGUAGE plpgsql
SECURITY DEFINER
SET search_path = pg_catalog, public
AS $function$
DECLARE
  v_column_number smallint;
  v_sequence regclass;
  v_increment bigint;
  v_sequence_max bigint;
  v_global_max bigint;
  v_last_value bigint;
  v_is_called boolean;
  v_restart numeric;
BEGIN
  SELECT attribute.attnum
    INTO STRICT v_column_number
    FROM pg_catalog.pg_class relation
    JOIN pg_catalog.pg_namespace namespace ON namespace.oid=relation.relnamespace
    JOIN pg_catalog.pg_attribute attribute
      ON attribute.attrelid=relation.oid
     AND attribute.attname=p_column
     AND attribute.attnum > 0
     AND NOT attribute.attisdropped
   WHERE relation.oid=p_table
     AND namespace.nspname='public'
     AND relation.relkind IN ('r','p');

  IF NOT EXISTS (
    SELECT 1
      FROM pg_catalog.pg_attribute attribute
     WHERE attribute.attrelid=p_table
       AND attribute.attname='tenant_id'
       AND attribute.attnum > 0
       AND NOT attribute.attisdropped
  ) OR NOT EXISTS (
    SELECT 1
      FROM pg_catalog.pg_attribute attribute
     WHERE attribute.attrelid=p_table
       AND attribute.attname='CO_CODE'
       AND attribute.attnum > 0
       AND NOT attribute.attisdropped
  ) THEN
    RAISE EXCEPTION 'sequence advance requires a company-scoped public table';
  END IF;

  SELECT sequence_relation.oid::regclass,
         sequence_data.seqincrement,
         sequence_data.seqmax
    INTO STRICT v_sequence,v_increment,v_sequence_max
    FROM pg_catalog.pg_depend dependency
    JOIN pg_catalog.pg_class sequence_relation
      ON sequence_relation.oid=dependency.objid
     AND sequence_relation.relkind='S'
    JOIN pg_catalog.pg_namespace sequence_namespace
      ON sequence_namespace.oid=sequence_relation.relnamespace
    JOIN pg_catalog.pg_sequence sequence_data
      ON sequence_data.seqrelid=sequence_relation.oid
   WHERE dependency.classid='pg_catalog.pg_class'::regclass
     AND dependency.refobjid=p_table
     AND dependency.refobjsubid=v_column_number
     AND dependency.deptype IN ('a','i')
     AND sequence_namespace.nspname='public';

  IF v_increment <= 0 THEN
    RAISE EXCEPTION 'negative or zero owned sequence increments are not supported';
  END IF;

  -- This blocks ordinary INSERT/UPDATE/DELETE writers before reading the RLS-hidden global maximum.
  EXECUTE format('LOCK TABLE %s IN SHARE ROW EXCLUSIVE MODE',p_table);
  EXECUTE format('SELECT max(%I)::bigint FROM %s',p_column,p_table) INTO v_global_max;
  EXECUTE format('SELECT last_value::bigint,is_called FROM %s',v_sequence)
    INTO v_last_value,v_is_called;

  IF v_global_max IS NULL
     OR v_last_value > v_global_max
     OR (v_last_value = v_global_max AND v_is_called) THEN
    RETURN v_last_value;
  END IF;

  v_restart := v_global_max::numeric + v_increment::numeric;
  IF v_restart > v_sequence_max::numeric THEN
    RAISE EXCEPTION 'owned sequence cannot advance beyond its maximum';
  END IF;

  -- Unlike setval(), ALTER SEQUENCE RESTART is transactional and blocks concurrent nextval() calls.
  EXECUTE format('ALTER SEQUENCE %s RESTART WITH %s',v_sequence,v_restart);
  RETURN v_restart::bigint;
EXCEPTION
  WHEN no_data_found THEN
    RAISE EXCEPTION 'column %.% has no owned public sequence',p_table::text,p_column;
  WHEN too_many_rows THEN
    RAISE EXCEPTION 'column %.% has ambiguous owned sequences',p_table::text,p_column;
END
$function$;

REVOKE ALL ON FUNCTION public.datacare_advance_owned_sequence(regclass,name) FROM PUBLIC;
DO $grant$
BEGIN
  IF EXISTS (SELECT 1 FROM pg_catalog.pg_roles WHERE rolname='app_user') THEN
    GRANT EXECUTE ON FUNCTION public.datacare_advance_owned_sequence(regclass,name) TO app_user;
  END IF;
END
$grant$;
