-- D38 / OD-5: retain business rows for operator recovery for thirty days.
ALTER TABLE "CO_MAST" ADD COLUMN deleted_at timestamptz;
CREATE INDEX company_purge_due ON "CO_MAST" (deleted_at) WHERE deleted_at IS NOT NULL;
