-- Primary MS_OPNCOMP.cs:5709, confirmed in original executable UTF-16 string pool.
-- Existing blank values do not reconstruct a lost historical ledger override; reimport it from source.
ALTER TABLE "SL_DATA" ADD COLUMN "LDR_CODE" VARCHAR(10) NOT NULL DEFAULT '';
