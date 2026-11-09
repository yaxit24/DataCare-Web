-- TR_APR_ISU.cs:6223-6225 persists line discount percentage, discount amount and exact net amount.
-- APR_DETL already carries NET_AMT; these two columns were absent from the restored PostgreSQL schema.
ALTER TABLE "APR_DETL"
  ADD COLUMN IF NOT EXISTS "DISC_PRC" DECIMAL(9,4),
  ADD COLUMN IF NOT EXISTS "DISC_AMT" DECIMAL(18,2);
