-- Primary desktop: MS_OPNCOMP.cs:5844 and unified/database/schema/01_Schema.sql:3033.
-- Preserve the hidden incoming tag labour code independently of the return labour code.
ALTER TABLE "SL_DETL_RTN" ADD COLUMN "TAG_LBR_CODE" VARCHAR(4) NOT NULL DEFAULT '';
