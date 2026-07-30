-- Data-repair console run ledger.
--
-- The desktop MS_UPDATE console runs destructive maintenance (rebuild ledgers, repair duplicate tag
-- identities, rebuild opening balances, convert tag stock) with no record of what happened. On the web
-- every run is recorded append-only so an operator can see afterwards exactly what an operation changed.
--
-- Design points that matter:
--  * `preview_hash` binds an apply to the exact candidate set the operator reviewed. If the data moved
--    between preview and apply the hash no longer matches and the apply is refused, rather than silently
--    acting on rows nobody saw.
--  * Terminal rows are immutable (enforced by trigger) so history cannot be rewritten.
--  * tenant_id is varchar(24) to match every other table in this schema.
CREATE TABLE IF NOT EXISTS "data_repair_run" (
  "row_id"        bigserial PRIMARY KEY,
  "tenant_id"     varchar(24) NOT NULL,
  "operation_id"  varchar(64) NOT NULL,
  "co_code"       varchar(12) NOT NULL,
  "lc_code"       varchar(12),
  "co_year"       varchar(16),
  "state"         varchar(16) NOT NULL,          -- previewed | applied | failed
  "preview_hash"  varchar(64) NOT NULL,
  "counts"        jsonb NOT NULL DEFAULT '{}',   -- per-table insert/update/delete the preview promised
  "applied_counts" jsonb,                        -- what the apply actually changed
  "samples"       jsonb NOT NULL DEFAULT '[]',   -- bounded business-key sample shown to the operator
  "operator"      varchar(64) NOT NULL,
  "reason"        text,
  "error"         text,
  "created_at"    timestamptz NOT NULL DEFAULT now(),
  "applied_at"    timestamptz
);

CREATE INDEX IF NOT EXISTS "data_repair_run_tenant_op_idx"
  ON "data_repair_run" ("tenant_id", "operation_id", "created_at" DESC);

-- One apply per reviewed preview: a replayed request resolves to the existing row instead of running again.
CREATE UNIQUE INDEX IF NOT EXISTS "data_repair_run_applied_uq"
  ON "data_repair_run" ("tenant_id", "operation_id", "preview_hash")
  WHERE "state" = 'applied';

ALTER TABLE "data_repair_run" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "data_repair_run" FORCE ROW LEVEL SECURITY;
DROP POLICY IF EXISTS "tenant_isolation" ON "data_repair_run";
CREATE POLICY "tenant_isolation" ON "data_repair_run"
  USING (("tenant_id")::text = current_setting('app.tenant_id', true))
  WITH CHECK (("tenant_id")::text = current_setting('app.tenant_id', true));

-- Append-only history: an applied or failed run is a permanent record.
--
-- UPDATE of a terminal run is always refused — that would be rewriting history. DELETE is refused too,
-- except when a caller explicitly opts in via `app.allow_repair_purge`, which exists so a retention job (or
-- a test fixture) has a legitimate, auditable way to remove old rows. Ordinary application code never sets
-- it, so an accidental or malicious delete still fails.
CREATE OR REPLACE FUNCTION "data_repair_run_immutable"() RETURNS trigger AS $$
BEGIN
  IF OLD."state" NOT IN ('applied', 'failed') THEN
    RETURN NEW;                                  -- a preview row may still be superseded
  END IF;
  IF TG_OP = 'DELETE'
     AND coalesce(current_setting('app.allow_repair_purge', true), '') = 'on' THEN
    RETURN OLD;                                  -- explicit retention/purge
  END IF;
  RAISE EXCEPTION 'data_repair_run %: terminal runs are immutable', OLD."row_id";
END;
$$ LANGUAGE plpgsql;

DROP TRIGGER IF EXISTS "data_repair_run_immutable_trg" ON "data_repair_run";
CREATE TRIGGER "data_repair_run_immutable_trg"
  BEFORE UPDATE OR DELETE ON "data_repair_run"
  FOR EACH ROW EXECUTE FUNCTION "data_repair_run_immutable"();
