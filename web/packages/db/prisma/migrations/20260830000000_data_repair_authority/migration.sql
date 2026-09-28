-- Data-repair authority evidence (P0-02/P0-03 slice of WP-02).
--
-- WHY
-- ===
-- `MS_UPDATE` repairs rewrite historical ledger, stock and serial data. The web already previews, hashes and
-- records every run, but a destructive apply could still be authorised by a delegated form right alone, with
-- no reason, no proof the operator is still present at the keyboard, and no proof a restorable backup exists.
--
-- This migration adds the two persistence pieces that make the tightened policy verifiable rather than
-- advisory:
--
--  1. `company_backup_run` — an append-only record of every company backup document produced by
--     `backupCompany`. A destructive repair can then be required to name a REAL, RECENT backup for the same
--     tenant and company instead of a string the operator typed. Without this table a "backup reference"
--     would be unverifiable decoration.
--
--  2. `data_repair_run.backup_reference` / `.reauthenticated_at` — the evidence actually relied upon at
--     apply time, stored beside the counts and preview hash so an auditor sees, for one run, what changed,
--     who ran it, why, which backup it was covered by, and when that operator re-proved their identity.
--
-- Both are additive. No existing column, index, policy or trigger is altered.

-- ---------------------------------------------------------------------------------------------------------
-- 1. Company backup ledger
-- ---------------------------------------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS "company_backup_run" (
  "row_id"           bigserial PRIMARY KEY,
  "tenant_id"        varchar(24) NOT NULL,
  "co_code"          varchar(12) NOT NULL,
  -- sha256 of the canonical backup document: the operator-visible identity of that artefact.
  "checksum"         varchar(64) NOT NULL,
  "document_version" integer     NOT NULL,
  "generated_at"     timestamptz NOT NULL,
  "table_count"      integer     NOT NULL DEFAULT 0,
  "row_count"        bigint      NOT NULL DEFAULT 0,
  -- Nullable: a scheduled/CLI backup has no interactive operator.
  "operator"         varchar(64),
  "created_at"       timestamptz NOT NULL DEFAULT now()
);

-- A repair apply looks a reference up by tenant + company + checksum, newest first.
CREATE INDEX IF NOT EXISTS "company_backup_run_lookup_idx"
  ON "company_backup_run" ("tenant_id", "co_code", "generated_at" DESC);

-- The same document must resolve to exactly one ledger row, so a replayed backup cannot create two
-- competing records of one artefact.
CREATE UNIQUE INDEX IF NOT EXISTS "company_backup_run_checksum_uq"
  ON "company_backup_run" ("tenant_id", "co_code", "checksum");

ALTER TABLE "company_backup_run" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "company_backup_run" FORCE ROW LEVEL SECURITY;
DROP POLICY IF EXISTS "tenant_isolation" ON "company_backup_run";
CREATE POLICY "tenant_isolation" ON "company_backup_run"
  USING (("tenant_id")::text = current_setting('app.tenant_id', true))
  WITH CHECK (("tenant_id")::text = current_setting('app.tenant_id', true));

-- Append-only, for the same reason `data_repair_run` is: a backup record that can be edited or deleted
-- cannot be used as evidence that a backup existed. Retention uses the same explicit opt-in that the repair
-- ledger uses, so ordinary application code can never remove a row.
CREATE OR REPLACE FUNCTION "company_backup_run_immutable"() RETURNS trigger AS $$
BEGIN
  IF TG_OP = 'DELETE'
     AND coalesce(current_setting('app.allow_repair_purge', true), '') = 'on' THEN
    RETURN OLD;
  END IF;
  RAISE EXCEPTION 'company_backup_run %: backup records are immutable', OLD."row_id";
END;
$$ LANGUAGE plpgsql;

DROP TRIGGER IF EXISTS "company_backup_run_immutable_trg" ON "company_backup_run";
CREATE TRIGGER "company_backup_run_immutable_trg"
  BEFORE UPDATE OR DELETE ON "company_backup_run"
  FOR EACH ROW EXECUTE FUNCTION "company_backup_run_immutable"();

-- ---------------------------------------------------------------------------------------------------------
-- 2. Authority evidence on the repair run ledger
-- ---------------------------------------------------------------------------------------------------------
ALTER TABLE "data_repair_run"
  ADD COLUMN IF NOT EXISTS "backup_reference"   varchar(64),
  ADD COLUMN IF NOT EXISTS "reauthenticated_at" timestamptz;

COMMENT ON COLUMN "data_repair_run"."backup_reference" IS
  'company_backup_run.checksum relied on when a high/danger repair was applied';
COMMENT ON COLUMN "data_repair_run"."reauthenticated_at" IS
  'when the applying operator re-proved their password for a high/danger repair';
