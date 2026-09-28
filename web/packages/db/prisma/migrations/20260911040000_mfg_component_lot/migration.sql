-- Primary desktop Ac_Image.CoFieldAdd:8213/8590 and original EXE string pool.
-- These identities belong to each component. Never populate them from its parent's LOT_NO.
ALTER TABLE "MFG_IDTL" ADD COLUMN "ITM_LOT" VARCHAR(10) NOT NULL DEFAULT '';
ALTER TABLE "MFG_IDTL" ADD COLUMN "ITM_LOT_AC_CODE" VARCHAR(10) NOT NULL DEFAULT '';
