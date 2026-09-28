-- Desktop TR_MEMB_ENT stores multiple UPI_DATA rows per member installment line.
-- The split identity is (SR_NO, ISR_NO), not SR_NO alone.
UPDATE "UPI_DATA" SET "ISR_NO" = 1 WHERE "ISR_NO" IS NULL;

ALTER TABLE "UPI_DATA" ALTER COLUMN "ISR_NO" SET NOT NULL;

ALTER TABLE "UPI_DATA" DROP CONSTRAINT IF EXISTS "UPI_DATA_pkey";

ALTER TABLE "UPI_DATA"
  ADD CONSTRAINT "UPI_DATA_pkey"
  PRIMARY KEY ("tenant_id", "CO_CODE", "LC_CODE", "CO_YEAR", "CO_BOOK", "VCH_NO", "SR_NO", "ISR_NO");
