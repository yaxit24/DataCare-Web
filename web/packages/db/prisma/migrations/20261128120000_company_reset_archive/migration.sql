-- Company reset archive (MS_COMPANY Ctrl+R "Reset Compnay", web adaptation of 2026-11-28).
--
-- A company reset deletes the company's vouchers, stock, postings and non-default masters in one transaction.
-- There is no operator backup step on the web, so the same transaction copies every deleted row here first
-- (`WITH deleted AS (DELETE ... RETURNING *) INSERT ... SELECT to_jsonb(deleted)`). Support can recover a row
-- from it; there is no self-service undo.
--
--  * Tenant-level, not company-scoped: it has `co_code`, not `CO_CODE`, so the reset's own delete set and the
--    company backup's table scope (tenant_id + CO_CODE) never include it.
--  * One archive row per deleted row, tied to the reset's `data_repair_run` row. The foreign key is deferred
--    because the run row is written last, with the final counts, and is immutable once applied.
--  * Append-only: UPDATE is refused; DELETE only with the same explicit retention opt-in the run ledger uses
--    (`app.allow_repair_purge`), which a purge of the run row cascades through.
CREATE TABLE IF NOT EXISTS "company_reset_archive" (
  "row_id"     bigserial PRIMARY KEY,
  "tenant_id"  varchar(24) NOT NULL,
  "run_id"     bigint NOT NULL,
  "co_code"    varchar(12) NOT NULL,
  "table_name" varchar(63) NOT NULL,
  "row_data"   jsonb NOT NULL,
  "created_at" timestamptz NOT NULL DEFAULT now(),
  CONSTRAINT "company_reset_archive_run_fk" FOREIGN KEY ("run_id")
    REFERENCES "data_repair_run" ("row_id") ON DELETE CASCADE DEFERRABLE INITIALLY DEFERRED
);

CREATE INDEX IF NOT EXISTS "company_reset_archive_run_idx"
  ON "company_reset_archive" ("tenant_id", "run_id", "table_name");

ALTER TABLE "company_reset_archive" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "company_reset_archive" FORCE ROW LEVEL SECURITY;
DROP POLICY IF EXISTS "tenant_isolation" ON "company_reset_archive";
CREATE POLICY "tenant_isolation" ON "company_reset_archive"
  USING (("tenant_id")::text = current_setting('app.tenant_id', true))
  WITH CHECK (("tenant_id")::text = current_setting('app.tenant_id', true));

CREATE OR REPLACE FUNCTION "company_reset_archive_immutable"() RETURNS trigger AS $$
BEGIN
  IF TG_OP = 'DELETE'
     AND coalesce(current_setting('app.allow_repair_purge', true), '') = 'on' THEN
    RETURN OLD;
  END IF;
  RAISE EXCEPTION 'company_reset_archive %: archived rows are immutable', OLD."row_id";
END;
$$ LANGUAGE plpgsql;

DROP TRIGGER IF EXISTS "company_reset_archive_immutable_trg" ON "company_reset_archive";
CREATE TRIGGER "company_reset_archive_immutable_trg"
  BEFORE UPDATE OR DELETE ON "company_reset_archive"
  FOR EACH ROW EXECUTE FUNCTION "company_reset_archive_immutable"();
