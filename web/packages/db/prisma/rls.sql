-- AUTO-GENERATED RLS policies. Apply after `prisma migrate deploy` as a repeatable safety bootstrap.
-- Session must set tenant context transaction-locally through packages/db/src/tenant.ts.
BEGIN;

DO $$
DECLARE target record;
BEGIN
  FOR target IN
    SELECT schemaname, tablename, policyname
    FROM pg_policies
    WHERE schemaname = 'public'
      AND policyname IN ('tenant_isolation', 'audit_tenant')
  LOOP
    EXECUTE format(
      'DROP POLICY %I ON %I.%I',
      target.policyname,
      target.schemaname,
      target.tablename
    );
  END LOOP;
END
$$;

ALTER TABLE "AC_DATA" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "AC_DATA" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "AC_DATA" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "AC_GROUP" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "AC_GROUP" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "AC_GROUP" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "AC_IMAGE" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "AC_IMAGE" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "AC_IMAGE" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "AC_MAST" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "AC_MAST" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "AC_MAST" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "AC_MAST_SRNO" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "AC_MAST_SRNO" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "AC_MAST_SRNO" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "ADD_MAST" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "ADD_MAST" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "ADD_MAST" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "AD_ADJ" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "AD_ADJ" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "AD_ADJ" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "AD_DATA" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "AD_DATA" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "AD_DATA" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "AD_MAST" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "AD_MAST" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "AD_MAST" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "AD_MEMB" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "AD_MEMB" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "AD_MEMB" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "AD_OS" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "AD_OS" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "AD_OS" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "APP_USER_DATA" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "APP_USER_DATA" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "APP_USER_DATA" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "APR_DATA" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "APR_DATA" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "APR_DATA" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "APR_DETL" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "APR_DETL" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "APR_DETL" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "APR_IDTL" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "APR_IDTL" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "APR_IDTL" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "BAL_GR" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "BAL_GR" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "BAL_GR" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "BANK_RECONCILE" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "BANK_RECONCILE" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "BANK_RECONCILE" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "BAR_CAN_DATA" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "BAR_CAN_DATA" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "BAR_CAN_DATA" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "BAR_CAN_DETL" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "BAR_CAN_DETL" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "BAR_CAN_DETL" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "BAR_CAN_IDTL" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "BAR_CAN_IDTL" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "BAR_CAN_IDTL" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "BAR_DATA" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "BAR_DATA" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "BAR_DATA" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "BAR_DETL" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "BAR_DETL" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "BAR_DETL" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "BAR_IDTL" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "BAR_IDTL" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "BAR_IDTL" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "BILL_OS_DATA" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "BILL_OS_DATA" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "BILL_OS_DATA" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "BOOK_DATA" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "BOOK_DATA" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "BOOK_DATA" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "BOOK_DETL" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "BOOK_DETL" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "BOOK_DETL" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "BOOK_IDTL" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "BOOK_IDTL" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "BOOK_IDTL" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "BUL_DATA" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "BUL_DATA" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "BUL_DATA" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "CARD_DATA" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "CARD_DATA" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "CARD_DATA" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "CASH_DATA" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "CASH_DATA" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "CASH_DATA" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "COL_MAST" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "COL_MAST" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "COL_MAST" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "COMM_DATA" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "COMM_DATA" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "COMM_DATA" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "CONTRA_DATA" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "CONTRA_DATA" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "CONTRA_DATA" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "CONV_MAST" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "CONV_MAST" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "CONV_MAST" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "CO_MAST" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "CO_MAST" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "CO_MAST" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "CO_SET" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "CO_SET" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "CO_SET" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "CO_SET_NEW" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "CO_SET_NEW" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "CO_SET_NEW" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "CRNT_DATA" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "CRNT_DATA" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "CRNT_DATA" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "CUST_DATA" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "CUST_DATA" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "CUST_DATA" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "CUST_DETL" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "CUST_DETL" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "CUST_DETL" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "CUT_DATA" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "CUT_DATA" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "CUT_DATA" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "CUT_DETL" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "CUT_DETL" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "CUT_DETL" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "CUT_STK_DETL" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "CUT_STK_DETL" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "CUT_STK_DETL" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "DELETE_DATA" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "DELETE_DATA" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "DELETE_DATA" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "DESIGN_DETL" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "DESIGN_DETL" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "DESIGN_DETL" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "DESIGN_IDTL" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "DESIGN_IDTL" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "DESIGN_IDTL" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "DESIGN_MAST" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "DESIGN_MAST" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "DESIGN_MAST" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "DG_GOLD_DATA" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "DG_GOLD_DATA" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "DG_GOLD_DATA" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "DG_GOLD_MAST" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "DG_GOLD_MAST" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "DG_GOLD_MAST" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "DHRN_DATA" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "DHRN_DATA" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "DHRN_DATA" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "DHRN_ISU_DATA" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "DHRN_ISU_DATA" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "DHRN_ISU_DATA" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "DHRN_ISU_DETL" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "DHRN_ISU_DETL" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "DHRN_ISU_DETL" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "DHRN_REC_DATA" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "DHRN_REC_DATA" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "DHRN_REC_DATA" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "DHRN_REC_DETL" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "DHRN_REC_DETL" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "DHRN_REC_DETL" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "DM_DATA" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "DM_DATA" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "DM_DATA" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "DM_KR_DATA" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "DM_KR_DATA" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "DM_KR_DATA" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "DM_MAST" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "DM_MAST" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "DM_MAST" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "DM_SIZE" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "DM_SIZE" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "DM_SIZE" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "EMP_DATA" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "EMP_DATA" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "EMP_DATA" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "EMP_MAST" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "EMP_MAST" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "EMP_MAST" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "E_DATA" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "E_DATA" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "E_DATA" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "E_MAST" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "E_MAST" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "E_MAST" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "FAN_AC_MAST" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "FAN_AC_MAST" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "FAN_AC_MAST" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "FAN_DATA" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "FAN_DATA" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "FAN_DATA" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "FAN_DETL" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "FAN_DETL" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "FAN_DETL" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "FAN_IDTL" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "FAN_IDTL" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "FAN_IDTL" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "FINE_DATA" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "FINE_DATA" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "FINE_DATA" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "GROUP_MAST" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "GROUP_MAST" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "GROUP_MAST" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "HDD_MAST" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "HDD_MAST" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "HDD_MAST" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "INOUT_DATA" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "INOUT_DATA" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "INOUT_DATA" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "INOUT_DETL" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "INOUT_DETL" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "INOUT_DETL" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "INOUT_IDTL" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "INOUT_IDTL" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "INOUT_IDTL" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "ITEM_MAST" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "ITEM_MAST" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "ITEM_MAST" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "ITM_CITY" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "ITM_CITY" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "ITM_CITY" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "ITM_LOT_DETL" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "ITM_LOT_DETL" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "ITM_LOT_DETL" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "ITM_OPBL" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "ITM_OPBL" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "ITM_OPBL" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "ITM_WT_MAST" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "ITM_WT_MAST" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "ITM_WT_MAST" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "KR_DATA" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "KR_DATA" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "KR_DATA" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "KR_DETL" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "KR_DETL" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "KR_DETL" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "KR_IDTL" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "KR_IDTL" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "KR_IDTL" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "LBR_DATA" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "LBR_DATA" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "LBR_DATA" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "LBR_ISU_DETL" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "LBR_ISU_DETL" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "LBR_ISU_DETL" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "LBR_MAST" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "LBR_MAST" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "LBR_MAST" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "LBR_REC_DETL" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "LBR_REC_DETL" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "LBR_REC_DETL" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "LDR_ADJ_DATA" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "LDR_ADJ_DATA" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "LDR_ADJ_DATA" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "LEDR_AC_DATA" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "LEDR_AC_DATA" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "LEDR_AC_DATA" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "LIKE_DATA" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "LIKE_DATA" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "LIKE_DATA" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "LOCT_AMT" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "LOCT_AMT" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "LOCT_AMT" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "LOCT_MAST" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "LOCT_MAST" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "LOCT_MAST" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "LOGIN_MAST" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "LOGIN_MAST" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "LOGIN_MAST" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "LOT_DETL" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "LOT_DETL" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "LOT_DETL" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "MAIN_STOCK" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "MAIN_STOCK" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "MAIN_STOCK" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "MENU_DATA" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "MENU_DATA" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "MENU_DATA" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "MFG_ASMBL_DETL" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "MFG_ASMBL_DETL" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "MFG_ASMBL_DETL" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "MFG_DATA" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "MFG_DATA" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "MFG_DATA" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "MFG_DETL" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "MFG_DETL" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "MFG_DETL" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "MFG_IDTL" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "MFG_IDTL" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "MFG_IDTL" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "MFG_ISU_REC" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "MFG_ISU_REC" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "MFG_ISU_REC" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "MFG_MAST" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "MFG_MAST" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "MFG_MAST" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "MLT_DATA" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "MLT_DATA" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "MLT_DATA" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "MLT_DETL" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "MLT_DETL" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "MLT_DETL" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "MODEL_MAST" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "MODEL_MAST" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "MODEL_MAST" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "MSG_MAST" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "MSG_MAST" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "MSG_MAST" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "message_attempt_log" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "message_attempt_log" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "message_attempt_log" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "OP_DATA" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "OP_DATA" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "OP_DATA" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "OP_LDR" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "OP_LDR" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "OP_LDR" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "PAY_DATA" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "PAY_DATA" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "PAY_DATA" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "PAY_DETL" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "PAY_DETL" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "PAY_DETL" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "POINT_DATA" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "POINT_DATA" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "POINT_DATA" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "POINT_MAST" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "POINT_MAST" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "POINT_MAST" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "POINT_MEMB" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "POINT_MEMB" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "POINT_MEMB" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "PRINT_MAST" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "PRINT_MAST" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "PRINT_MAST" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "PRODUCT_MAST" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "PRODUCT_MAST" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "PRODUCT_MAST" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "PR_DATA" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "PR_DATA" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "PR_DATA" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "PR_DETL" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "PR_DETL" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "PR_DETL" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "PR_IDTL" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "PR_IDTL" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "PR_IDTL" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "RATE_CUT_DATA" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "RATE_CUT_DATA" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "RATE_CUT_DATA" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "RATE_CUT_ISU" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "RATE_CUT_ISU" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "RATE_CUT_ISU" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "RATE_CUT_ISU_REC" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "RATE_CUT_ISU_REC" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "RATE_CUT_ISU_REC" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "RATE_CUT_REC" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "RATE_CUT_REC" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "RATE_CUT_REC" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "RATE_MAST" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "RATE_MAST" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "RATE_MAST" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "REMARK_DATA" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "REMARK_DATA" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "REMARK_DATA" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "REM_DATA" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "REM_DATA" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "REM_DATA" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "REPORT_DATA" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "REPORT_DATA" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "REPORT_DATA" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "REP_DATA" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "REP_DATA" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "REP_DATA" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "REP_DETL" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "REP_DETL" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "REP_DETL" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "REP_IMAGE" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "REP_IMAGE" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "REP_IMAGE" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "ROJMEL_BAL" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "ROJMEL_BAL" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "ROJMEL_BAL" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "ROJ_MEL_DATA" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "ROJ_MEL_DATA" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "ROJ_MEL_DATA" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "SL_DATA" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "SL_DATA" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "SL_DATA" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "SL_DETL" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "SL_DETL" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "SL_DETL" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "SL_DETL_RTN" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "SL_DETL_RTN" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "SL_DETL_RTN" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "SL_IDTL" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "SL_IDTL" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "SL_IDTL" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "SL_ORD_ADJ" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "SL_ORD_ADJ" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "SL_ORD_ADJ" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "SL_ORD_DATA" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "SL_ORD_DATA" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "SL_ORD_DATA" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "SL_ORD_DETL" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "SL_ORD_DETL" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "SL_ORD_DETL" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "SL_ORD_IDTL" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "SL_ORD_IDTL" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "SL_ORD_IDTL" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "SL_PR_DETL" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "SL_PR_DETL" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "SL_PR_DETL" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "SRNO_MAST" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "SRNO_MAST" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "SRNO_MAST" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "STATE_MAST" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "STATE_MAST" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "STATE_MAST" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "TABLE_MAST" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "TABLE_MAST" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "TABLE_MAST" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "TAG_DATA" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "TAG_DATA" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "TAG_DATA" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "TAG_IMAGE_DATA" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "TAG_IMAGE_DATA" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "TAG_IMAGE_DATA" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "TAG_PRINT_DATA" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "TAG_PRINT_DATA" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "TAG_PRINT_DATA" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "TAG_SET" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "TAG_SET" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "TAG_SET" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "TAG_STOCK" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "TAG_STOCK" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "TAG_STOCK" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "TAG_STOCK_PRINT" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "TAG_STOCK_PRINT" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "TAG_STOCK_PRINT" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "TAG_SUM_DATA" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "TAG_SUM_DATA" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "TAG_SUM_DATA" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "TAX_DATA" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "TAX_DATA" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "TAX_DATA" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "TAX_MAST" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "TAX_MAST" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "TAX_MAST" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "TEMP_ADD" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "TEMP_ADD" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "TEMP_ADD" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "TEMP_AD_DATA" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "TEMP_AD_DATA" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "TEMP_AD_DATA" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "TEMP_BOOK_DATA" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "TEMP_BOOK_DATA" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "TEMP_BOOK_DATA" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "TILE_DATA" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "TILE_DATA" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "TILE_DATA" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "TOUCH_MAST" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "TOUCH_MAST" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "TOUCH_MAST" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "UPI_DATA" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "UPI_DATA" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "UPI_DATA" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "USER_DATA" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "USER_DATA" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "USER_DATA" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "USER_MAST" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "USER_MAST" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "USER_MAST" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "USER_REQUEST" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "USER_REQUEST" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "USER_REQUEST" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "USER_SET" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "USER_SET" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "USER_SET" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "VP_ADJ_DATA" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "VP_ADJ_DATA" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "VP_ADJ_DATA" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "WEB_DATA" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "WEB_DATA" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "WEB_DATA" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "WEIGHT_MAST" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "WEIGHT_MAST" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "WEIGHT_MAST" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "YEAR_MAST" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "YEAR_MAST" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "YEAR_MAST" USING (tenant_id = current_setting('app.tenant_id', true)) WITH CHECK (tenant_id = current_setting('app.tenant_id', true));


ALTER TABLE "COUNTRY_MAST" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "COUNTRY_MAST" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "COUNTRY_MAST"
  USING (tenant_id = current_setting('app.tenant_id', true))
  WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "IMAGE_DATA" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "IMAGE_DATA" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "IMAGE_DATA"
  USING (tenant_id = current_setting('app.tenant_id', true))
  WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "LBR_ISU_IDTL" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "LBR_ISU_IDTL" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "LBR_ISU_IDTL"
  USING (tenant_id = current_setting('app.tenant_id', true))
  WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "OP_DETL" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "OP_DETL" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "OP_DETL"
  USING (tenant_id = current_setting('app.tenant_id', true))
  WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "auth_session" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "auth_session" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "auth_session"
  USING (tenant_id = current_setting('app.tenant_id', true))
  WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

ALTER TABLE "audit_log" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "audit_log" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "audit_log"
  USING (tenant_id = current_setting('app.tenant_id', true))
  WITH CHECK (tenant_id = current_setting('app.tenant_id', true));

COMMIT;
