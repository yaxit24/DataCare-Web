-- Data Refresh > Account check-and-repair keeps the rows it replaced on the run record.
--
-- An applied Account repair deletes a voucher's AC_DATA, ROJ_MEL_DATA and TAX_DATA rows and writes the rows the
-- web's own builders derive from the stored voucher (owner decision 2026-11-27, docs/handbook/web/data-refresh.md).
-- `before_rows` holds the replaced rows of every repaired voucher, so an auditor sees exactly what changed and the
-- repair can be undone. Additive: the run ledger stays append-only and no existing column, policy or trigger changes.
ALTER TABLE "data_repair_run" ADD COLUMN IF NOT EXISTS "before_rows" jsonb;

COMMENT ON COLUMN "data_repair_run"."before_rows" IS
  'rows an applied repair replaced, per voucher and table, kept so the change can be audited and undone';
