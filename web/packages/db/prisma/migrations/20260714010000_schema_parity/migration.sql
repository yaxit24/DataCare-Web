-- Additive schema-parity DDL (web -> desktop). Idempotent. Nullable additions preserve demo data.
BEGIN;

CREATE SEQUENCE IF NOT EXISTS "COUNTRY_MAST_row_id_seq";
CREATE TABLE IF NOT EXISTS "COUNTRY_MAST" (
  "tenant_id" varchar(24) NOT NULL,
  "row_id" bigint NOT NULL DEFAULT nextval('"COUNTRY_MAST_row_id_seq"'),
  "CON_CODE" varchar(255),
  "CON_NAME" varchar(255),
  "MAIN_USER" varchar(255),
  PRIMARY KEY ("tenant_id","row_id")
);
ALTER SEQUENCE "COUNTRY_MAST_row_id_seq" OWNED BY "COUNTRY_MAST"."row_id";
ALTER TABLE "COUNTRY_MAST" ENABLE ROW LEVEL SECURITY;
DROP POLICY IF EXISTS tenant_isolation ON "COUNTRY_MAST";
CREATE POLICY tenant_isolation ON "COUNTRY_MAST" USING (("tenant_id")::text = current_setting('app.tenant_id', true));
CREATE UNIQUE INDEX IF NOT EXISTS "COUNTRY_MAST_bk_uq" ON "COUNTRY_MAST" ("tenant_id","CON_CODE");

CREATE SEQUENCE IF NOT EXISTS "IMAGE_DATA_row_id_seq";
CREATE TABLE IF NOT EXISTS "IMAGE_DATA" (
  "tenant_id" varchar(24) NOT NULL,
  "row_id" bigint NOT NULL DEFAULT nextval('"IMAGE_DATA_row_id_seq"'),
  "CO_CODE" varchar(255),
  "LC_CODE" varchar(255),
  "SR_NO" numeric,
  "TAG_NO" varchar(255),
  "VCH_SRNO" numeric,
  "DESIGN" varchar(255),
  "TAG_IMAGE" bytea,
  "SCHM_CODE" varchar(255),
  "MEMB_CODE" varchar(255),
  PRIMARY KEY ("tenant_id","row_id")
);
ALTER SEQUENCE "IMAGE_DATA_row_id_seq" OWNED BY "IMAGE_DATA"."row_id";
ALTER TABLE "IMAGE_DATA" ENABLE ROW LEVEL SECURITY;
DROP POLICY IF EXISTS tenant_isolation ON "IMAGE_DATA";
CREATE POLICY tenant_isolation ON "IMAGE_DATA" USING (("tenant_id")::text = current_setting('app.tenant_id', true));

CREATE SEQUENCE IF NOT EXISTS "LBR_ISU_IDTL_row_id_seq";
CREATE TABLE IF NOT EXISTS "LBR_ISU_IDTL" (
  "tenant_id" varchar(24) NOT NULL,
  "row_id" bigint NOT NULL DEFAULT nextval('"LBR_ISU_IDTL_row_id_seq"'),
  "CO_CODE" varchar(255),
  "LC_CODE" varchar(255),
  "CO_YEAR" varchar(255),
  "CO_BOOK" varchar(255),
  "VCH_NO" varchar(255),
  "SR_NO" numeric,
  "ISR_NO" numeric,
  "VCH_DATE" date,
  "VCH_TYPE" varchar(255),
  "INOUT_TYPE" varchar(255),
  "ENTRY_TYPE" varchar(255),
  "BOOK_NAME" varchar(255),
  "AC_CODE" varchar(255),
  "TAG_NO" varchar(255),
  "VCH_SRNO" numeric,
  "IT_CODE" varchar(255),
  "IT_TYPE" varchar(255),
  "DM_CODE" varchar(255),
  "DM_SIZE" varchar(255),
  "DM_SFNO" varchar(255),
  "DM_LEB" varchar(255),
  "IT_PCS" numeric,
  "IT_PCS_WT" numeric,
  "KR_WT" numeric,
  "KR_LESS_PRC" numeric,
  "IT_GWT" numeric,
  "IT_CON_PRC" numeric,
  "IT_CON_WT" numeric,
  "IT_RATE_TYPE" varchar(255),
  "IT_RATE" numeric,
  "IT_AMT" numeric,
  "IT_LBR_RATE" numeric,
  "IT_LBR_AMT" numeric,
  "IT_NET_AMT" numeric,
  "KR_CON_PRC" numeric,
  "KR_CON_WT" numeric,
  "KR_RATE" numeric,
  "KR_AMT" numeric,
  "KR_LBR_RATE" numeric,
  "KR_LBR_AMT" numeric,
  "KR_NET_AMT" numeric,
  "HD_VCH_NO" varchar(255),
  "MAIN_USER" varchar(255),
  "DM_ORIGIN" varchar(255),
  "DM_REMARK" varchar(255),
  "DM_COLOR" varchar(255),
  "DM_NAME" varchar(255),
  "KR_ACT_WT" numeric,
  "KR_ACT_PRC" numeric,
  "KR_RATE_TYPE" varchar(255),
  "IT_DISC_PRC" numeric,
  "IT_DISC_AMT" numeric,
  PRIMARY KEY ("tenant_id","row_id")
);
ALTER SEQUENCE "LBR_ISU_IDTL_row_id_seq" OWNED BY "LBR_ISU_IDTL"."row_id";
ALTER TABLE "LBR_ISU_IDTL" ENABLE ROW LEVEL SECURITY;
DROP POLICY IF EXISTS tenant_isolation ON "LBR_ISU_IDTL";
CREATE POLICY tenant_isolation ON "LBR_ISU_IDTL" USING (("tenant_id")::text = current_setting('app.tenant_id', true));
CREATE UNIQUE INDEX IF NOT EXISTS "LBR_ISU_IDTL_bk_uq" ON "LBR_ISU_IDTL" ("tenant_id","CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","ISR_NO");

CREATE SEQUENCE IF NOT EXISTS "OP_DETL_row_id_seq";
CREATE TABLE IF NOT EXISTS "OP_DETL" (
  "tenant_id" varchar(24) NOT NULL,
  "row_id" bigint NOT NULL DEFAULT nextval('"OP_DETL_row_id_seq"'),
  "CO_CODE" varchar(255),
  "LC_CODE" varchar(255),
  "CO_YEAR" varchar(255),
  "CO_BOOK" varchar(255),
  "AC_CODE" varchar(255),
  "VCH_NO" varchar(255),
  "SR_NO" varchar(255),
  "VCH_DATE" date,
  "BILL_NO" varchar(255),
  "ITM_AMT" numeric,
  "ITM_GHTWT" numeric,
  "ITM_GWT" numeric,
  "ITM_NWT" numeric,
  "ITM_TOUCH" numeric,
  "DM_PCS" varchar(255),
  "DM_WT" numeric,
  "DM_AMT" numeric,
  "ITM_WEST" numeric,
  "ITM_GL_FINE" numeric,
  "ITM_SL_FINE" numeric,
  "ITM_SIGN" varchar(255),
  "ITM_DESC" varchar(255),
  "CR_DAYS" numeric,
  "MAIN_USER" varchar(255),
  "ADD_USER" varchar(255),
  "ADD_DATE" timestamp,
  "ITM_TYPE" varchar(255),
  PRIMARY KEY ("tenant_id","row_id")
);
ALTER SEQUENCE "OP_DETL_row_id_seq" OWNED BY "OP_DETL"."row_id";
ALTER TABLE "OP_DETL" ENABLE ROW LEVEL SECURITY;
DROP POLICY IF EXISTS tenant_isolation ON "OP_DETL";
CREATE POLICY tenant_isolation ON "OP_DETL" USING (("tenant_id")::text = current_setting('app.tenant_id', true));

ALTER TABLE "TAG_DATA" ADD COLUMN IF NOT EXISTS "B2B_LRATE" numeric;
ALTER TABLE "TAG_DATA" ADD COLUMN IF NOT EXISTS "B2B_WEST" numeric;
ALTER TABLE "TAG_DATA" ADD COLUMN IF NOT EXISTS "B2C_LRATE" numeric;
ALTER TABLE "TAG_DATA" ADD COLUMN IF NOT EXISTS "B2C_WEST" numeric;
ALTER TABLE "TAG_DATA" ADD COLUMN IF NOT EXISTS "DESIGN_NO" varchar(255);
ALTER TABLE "TAG_DATA" ADD COLUMN IF NOT EXISTS "EMP_CODE" varchar(255);
ALTER TABLE "TAG_DATA" ADD COLUMN IF NOT EXISTS "ITM_CITY" varchar(255);
ALTER TABLE "TAG_DATA" ADD COLUMN IF NOT EXISTS "ITM_LOT" varchar(255);
ALTER TABLE "TAG_DATA" ADD COLUMN IF NOT EXISTS "ITM_MRP" numeric;
ALTER TABLE "TAG_DATA" ADD COLUMN IF NOT EXISTS "ITM_TOUCH" numeric;
ALTER TABLE "TAG_DATA" ADD COLUMN IF NOT EXISTS "IT_CODE" varchar(255);
ALTER TABLE "TAG_DATA" ADD COLUMN IF NOT EXISTS "IT_TYPE" varchar(255);
ALTER TABLE "TAG_DATA" ADD COLUMN IF NOT EXISTS "KR_NAME" varchar(255);
ALTER TABLE "TAG_DATA" ADD COLUMN IF NOT EXISTS "LBR_TYPE" varchar(255);
ALTER TABLE "TAG_DATA" ADD COLUMN IF NOT EXISTS "LC_LRATE" numeric;
ALTER TABLE "TAG_DATA" ADD COLUMN IF NOT EXISTS "LC_WEST" numeric;
ALTER TABLE "TAG_DATA" ADD COLUMN IF NOT EXISTS "MAIN_USER" varchar(255);
ALTER TABLE "TAG_DATA" ADD COLUMN IF NOT EXISTS "MODEL_NAME" varchar(255);
ALTER TABLE "TAG_DATA" ADD COLUMN IF NOT EXISTS "OLD_SRNO" numeric;
ALTER TABLE "TAG_DATA" ADD COLUMN IF NOT EXISTS "PR_CODE" varchar(255);

ALTER TABLE "DM_DATA" ADD COLUMN IF NOT EXISTS "INOUT_TYPE" varchar(255);
ALTER TABLE "DM_DATA" ADD COLUMN IF NOT EXISTS "MAIN_IT_CODE" varchar(255);

COMMIT;