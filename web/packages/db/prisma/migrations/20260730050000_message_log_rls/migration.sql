-- Tenant isolation for message_attempt_log.
--
-- THE DEFECT
-- ----------
-- `20260715010000_runtime_schema_security` enables and FORCES row level security, with a `tenant_isolation`
-- policy, on every table carrying `tenant_id`. `message_attempt_log` was created later by
-- `20260728010000_message_attempt_log`, so that blanket pass had already run and never covered it. The table
-- has a `tenant_id` column but, on any database built by applying the migration chain in order, NO row level
-- security and NO policy.
--
-- This was not visible on a long-lived development database, where the table had acquired RLS through
-- unrelated history. It was found by provisioning a FRESH database from the migration chain and diffing:
-- `message_attempt_log` was the only table with a `tenant_id` column and `relrowsecurity = false`.
--
-- WHY IT MATTERED
-- ---------------
-- Two statements in `modules/integrations/messaging.ts` filtered on `idempotency_key` ALONE and relied on RLS
-- for isolation:
--
--   SELECT "status","provider_reference","failure_reason" FROM "message_attempt_log"
--    WHERE "idempotency_key" = $1 LIMIT 1
--   UPDATE "message_attempt_log" SET "status"=…,"provider_reference"=…,"failure_reason"=…
--    WHERE "idempotency_key" = $4
--
-- Without RLS, a caller whose idempotency key collides with another tenant's could READ that tenant's
-- delivery status and provider reference, and the UPDATE could OVERWRITE another tenant's row. Keys derived
-- from voucher identifiers would collide across tenants routinely.
--
-- Both layers are fixed: this migration restores the isolation guarantee, and the queries now carry an
-- explicit tenant predicate so isolation does not depend on a single mechanism.
ALTER TABLE "message_attempt_log" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "message_attempt_log" FORCE ROW LEVEL SECURITY;

DROP POLICY IF EXISTS "tenant_isolation" ON "message_attempt_log";
CREATE POLICY "tenant_isolation" ON "message_attempt_log"
  USING (("tenant_id")::text = current_setting('app.tenant_id', true))
  WITH CHECK (("tenant_id")::text = current_setting('app.tenant_id', true));
