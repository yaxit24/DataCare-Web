-- Column TYPE parity with the desktop schema.
--
-- 226 columns were `character varying` in Postgres while the desktop holds them as `float` (223) or `int` (3).
-- The direction was entirely one-way - 226 desktop-numeric to web-text, zero the reverse - which is what makes
-- it a migration defect rather than a deliberate choice.
--
-- WHY IT MATTERS
--   * SUM/AVG need an explicit cast, and a cast meeting a non-numeric string throws at QUERY time, not at write
--     time, so the failure surfaces in a report rather than at the point of the bad write.
--   * ORDER BY is lexicographic: '9' sorts after '10'. A report ordered by amount orders wrongly.
--   * The column carries no domain guarantee at all.
--
-- WHY `double precision` AND NOT `numeric(p,s)`
-- The desktop type is `float` - 8-byte IEEE with NO declared scale. `double precision` is its exact Postgres
-- equivalent. Choosing numeric(18,6) would impose a scale the desktop never had, and this project has already
-- been bitten by inventing precision that the source did not specify. There is precedent in the schema:
-- SL_DATA.CGST_TAX is already `double precision` so it can hold the unrounded GST half (22.725) that the
-- desktop stores.
--
-- WHY A DIRECT ALTER IS SAFE HERE
--   1. Every one of these columns is float or int on the desktop, so any REAL migrated data is numeric by
--      construction - the varchar typing could only ever have received junk from a web-side write.
--   2. Checked: zero existing values in any of the 226 columns fail a numeric cast.
--   3. No production deployment exists yet, so there is no live data to convert in place.
-- The USING clause still guards blanks explicitly rather than relying on those facts holding forever.

-- AC_MAST (3 column(s))
ALTER TABLE "AC_MAST" ALTER COLUMN "AC_CR_DAYS" TYPE double precision USING NULLIF(btrim("AC_CR_DAYS"), '')::double precision;
ALTER TABLE "AC_MAST" ALTER COLUMN "AC_INT_PRC" TYPE double precision USING NULLIF(btrim("AC_INT_PRC"), '')::double precision;
ALTER TABLE "AC_MAST" ALTER COLUMN "DPC_PRC" TYPE double precision USING NULLIF(btrim("DPC_PRC"), '')::double precision;

-- APR_DETL (4 column(s))
ALTER TABLE "APR_DETL" ALTER COLUMN "ADJ_GWT" TYPE double precision USING NULLIF(btrim("ADJ_GWT"), '')::double precision;
ALTER TABLE "APR_DETL" ALTER COLUMN "ADJ_NWT" TYPE double precision USING NULLIF(btrim("ADJ_NWT"), '')::double precision;
ALTER TABLE "APR_DETL" ALTER COLUMN "ITM_LESS_TCH" TYPE double precision USING NULLIF(btrim("ITM_LESS_TCH"), '')::double precision;
ALTER TABLE "APR_DETL" ALTER COLUMN "ITM_LOSS_WT" TYPE double precision USING NULLIF(btrim("ITM_LOSS_WT"), '')::double precision;

-- BAL_GR (9 column(s))
ALTER TABLE "BAL_GR" ALTER COLUMN "AVG_AMT" TYPE double precision USING NULLIF(btrim("AVG_AMT"), '')::double precision;
ALTER TABLE "BAL_GR" ALTER COLUMN "AVG_FINE" TYPE double precision USING NULLIF(btrim("AVG_FINE"), '')::double precision;
ALTER TABLE "BAL_GR" ALTER COLUMN "AVG_NWT" TYPE double precision USING NULLIF(btrim("AVG_NWT"), '')::double precision;
ALTER TABLE "BAL_GR" ALTER COLUMN "AVG_RATE" TYPE double precision USING NULLIF(btrim("AVG_RATE"), '')::double precision;
ALTER TABLE "BAL_GR" ALTER COLUMN "AVG_TOUCH" TYPE double precision USING NULLIF(btrim("AVG_TOUCH"), '')::double precision;
ALTER TABLE "BAL_GR" ALTER COLUMN "OP_FINE" TYPE double precision USING NULLIF(btrim("OP_FINE"), '')::double precision;
ALTER TABLE "BAL_GR" ALTER COLUMN "OP_TOUCH" TYPE double precision USING NULLIF(btrim("OP_TOUCH"), '')::double precision;
ALTER TABLE "BAL_GR" ALTER COLUMN "TRAD_AMT" TYPE double precision USING NULLIF(btrim("TRAD_AMT"), '')::double precision;
ALTER TABLE "BAL_GR" ALTER COLUMN "TRAD_WT" TYPE double precision USING NULLIF(btrim("TRAD_WT"), '')::double precision;

-- BAR_DETL (16 column(s))
ALTER TABLE "BAR_DETL" ALTER COLUMN "JDT_GHT_WT" TYPE double precision USING NULLIF(btrim("JDT_GHT_WT"), '')::double precision;
ALTER TABLE "BAR_DETL" ALTER COLUMN "JDT_JDT_WT" TYPE double precision USING NULLIF(btrim("JDT_JDT_WT"), '')::double precision;
ALTER TABLE "BAR_DETL" ALTER COLUMN "JDT_KUN_NET" TYPE double precision USING NULLIF(btrim("JDT_KUN_NET"), '')::double precision;
ALTER TABLE "BAR_DETL" ALTER COLUMN "JDT_KUN_TOUCH" TYPE double precision USING NULLIF(btrim("JDT_KUN_TOUCH"), '')::double precision;
ALTER TABLE "BAR_DETL" ALTER COLUMN "JDT_KUN_WT" TYPE double precision USING NULLIF(btrim("JDT_KUN_WT"), '')::double precision;
ALTER TABLE "BAR_DETL" ALTER COLUMN "JDT_WAX_WT" TYPE double precision USING NULLIF(btrim("JDT_WAX_WT"), '')::double precision;
ALTER TABLE "BAR_DETL" ALTER COLUMN "KR_COST" TYPE double precision USING NULLIF(btrim("KR_COST"), '')::double precision;
ALTER TABLE "BAR_DETL" ALTER COLUMN "KR_GHT_PRC" TYPE double precision USING NULLIF(btrim("KR_GHT_PRC"), '')::double precision;
ALTER TABLE "BAR_DETL" ALTER COLUMN "KR_GHT_WT" TYPE double precision USING NULLIF(btrim("KR_GHT_WT"), '')::double precision;
ALTER TABLE "BAR_DETL" ALTER COLUMN "KR_GWT_TOUCH" TYPE double precision USING NULLIF(btrim("KR_GWT_TOUCH"), '')::double precision;
ALTER TABLE "BAR_DETL" ALTER COLUMN "KR_OTH_AMT" TYPE double precision USING NULLIF(btrim("KR_OTH_AMT"), '')::double precision;
ALTER TABLE "BAR_DETL" ALTER COLUMN "KR_OTH_FINE" TYPE double precision USING NULLIF(btrim("KR_OTH_FINE"), '')::double precision;
ALTER TABLE "BAR_DETL" ALTER COLUMN "KR_OTH_RATE" TYPE double precision USING NULLIF(btrim("KR_OTH_RATE"), '')::double precision;
ALTER TABLE "BAR_DETL" ALTER COLUMN "KR_TOT_FINE" TYPE double precision USING NULLIF(btrim("KR_TOT_FINE"), '')::double precision;
ALTER TABLE "BAR_DETL" ALTER COLUMN "MFG_SRNO" TYPE double precision USING NULLIF(btrim("MFG_SRNO"), '')::double precision;
ALTER TABLE "BAR_DETL" ALTER COLUMN "TAG_SRNO" TYPE integer USING NULLIF(btrim("TAG_SRNO"), '')::integer;

-- BAR_IDTL (2 column(s))
ALTER TABLE "BAR_IDTL" ALTER COLUMN "IT_DISC_AMT" TYPE double precision USING NULLIF(btrim("IT_DISC_AMT"), '')::double precision;
ALTER TABLE "BAR_IDTL" ALTER COLUMN "IT_DISC_PRC" TYPE double precision USING NULLIF(btrim("IT_DISC_PRC"), '')::double precision;

-- CASH_DATA (1 column(s))
ALTER TABLE "CASH_DATA" ALTER COLUMN "BANK_CHARGES" TYPE double precision USING NULLIF(btrim("BANK_CHARGES"), '')::double precision;

-- CONV_MAST (6 column(s))
ALTER TABLE "CONV_MAST" ALTER COLUMN "GOLD_OZ_RATE" TYPE double precision USING NULLIF(btrim("GOLD_OZ_RATE"), '')::double precision;
ALTER TABLE "CONV_MAST" ALTER COLUMN "GOLD_PR_RATE" TYPE double precision USING NULLIF(btrim("GOLD_PR_RATE"), '')::double precision;
ALTER TABLE "CONV_MAST" ALTER COLUMN "GOLD_SL_RATE" TYPE double precision USING NULLIF(btrim("GOLD_SL_RATE"), '')::double precision;
ALTER TABLE "CONV_MAST" ALTER COLUMN "SILVER_OZ_RATE" TYPE double precision USING NULLIF(btrim("SILVER_OZ_RATE"), '')::double precision;
ALTER TABLE "CONV_MAST" ALTER COLUMN "SILVER_PR_RATE" TYPE double precision USING NULLIF(btrim("SILVER_PR_RATE"), '')::double precision;
ALTER TABLE "CONV_MAST" ALTER COLUMN "SILVER_SL_RATE" TYPE double precision USING NULLIF(btrim("SILVER_SL_RATE"), '')::double precision;

-- CO_SET (10 column(s))
ALTER TABLE "CO_SET" ALTER COLUMN "CASH_LIMIT" TYPE double precision USING NULLIF(btrim("CASH_LIMIT"), '')::double precision;
ALTER TABLE "CO_SET" ALTER COLUMN "DHRN_PRC" TYPE double precision USING NULLIF(btrim("DHRN_PRC"), '')::double precision;
ALTER TABLE "CO_SET" ALTER COLUMN "FX_RATE" TYPE double precision USING NULLIF(btrim("FX_RATE"), '')::double precision;
ALTER TABLE "CO_SET" ALTER COLUMN "INT_YEAR_DAYS" TYPE double precision USING NULLIF(btrim("INT_YEAR_DAYS"), '')::double precision;
ALTER TABLE "CO_SET" ALTER COLUMN "ITM_RATE_ROF" TYPE double precision USING NULLIF(btrim("ITM_RATE_ROF"), '')::double precision;
ALTER TABLE "CO_SET" ALTER COLUMN "LBR_ROF" TYPE double precision USING NULLIF(btrim("LBR_ROF"), '')::double precision;
ALTER TABLE "CO_SET" ALTER COLUMN "OZ_CON_VAL" TYPE double precision USING NULLIF(btrim("OZ_CON_VAL"), '')::double precision;
ALTER TABLE "CO_SET" ALTER COLUMN "PAN_CARD_VAL" TYPE double precision USING NULLIF(btrim("PAN_CARD_VAL"), '')::double precision;
ALTER TABLE "CO_SET" ALTER COLUMN "TAX_ROF" TYPE integer USING NULLIF(btrim("TAX_ROF"), '')::integer;
ALTER TABLE "CO_SET" ALTER COLUMN "THEME" TYPE integer USING NULLIF(btrim("THEME"), '')::integer;

-- EMP_MAST (1 column(s))
ALTER TABLE "EMP_MAST" ALTER COLUMN "EMP_AMT" TYPE double precision USING NULLIF(btrim("EMP_AMT"), '')::double precision;

-- GROUP_MAST (14 column(s))
ALTER TABLE "GROUP_MAST" ALTER COLUMN "AVG_FINE" TYPE double precision USING NULLIF(btrim("AVG_FINE"), '')::double precision;
ALTER TABLE "GROUP_MAST" ALTER COLUMN "AVG_NWT" TYPE double precision USING NULLIF(btrim("AVG_NWT"), '')::double precision;
ALTER TABLE "GROUP_MAST" ALTER COLUMN "AVG_RATE" TYPE double precision USING NULLIF(btrim("AVG_RATE"), '')::double precision;
ALTER TABLE "GROUP_MAST" ALTER COLUMN "AVG_TOUCH" TYPE double precision USING NULLIF(btrim("AVG_TOUCH"), '')::double precision;
ALTER TABLE "GROUP_MAST" ALTER COLUMN "DAY_CL_PCS" TYPE double precision USING NULLIF(btrim("DAY_CL_PCS"), '')::double precision;
ALTER TABLE "GROUP_MAST" ALTER COLUMN "DAY_CL_WT" TYPE double precision USING NULLIF(btrim("DAY_CL_WT"), '')::double precision;
ALTER TABLE "GROUP_MAST" ALTER COLUMN "DAY_OP_PCS" TYPE double precision USING NULLIF(btrim("DAY_OP_PCS"), '')::double precision;
ALTER TABLE "GROUP_MAST" ALTER COLUMN "DAY_OP_WT" TYPE double precision USING NULLIF(btrim("DAY_OP_WT"), '')::double precision;
ALTER TABLE "GROUP_MAST" ALTER COLUMN "GR_PURC_TOUCH" TYPE double precision USING NULLIF(btrim("GR_PURC_TOUCH"), '')::double precision;
ALTER TABLE "GROUP_MAST" ALTER COLUMN "GR_TOUCH" TYPE double precision USING NULLIF(btrim("GR_TOUCH"), '')::double precision;
ALTER TABLE "GROUP_MAST" ALTER COLUMN "MELTING_PRC" TYPE double precision USING NULLIF(btrim("MELTING_PRC"), '')::double precision;
ALTER TABLE "GROUP_MAST" ALTER COLUMN "OP_FINE" TYPE double precision USING NULLIF(btrim("OP_FINE"), '')::double precision;
ALTER TABLE "GROUP_MAST" ALTER COLUMN "OP_TOUCH" TYPE double precision USING NULLIF(btrim("OP_TOUCH"), '')::double precision;
ALTER TABLE "GROUP_MAST" ALTER COLUMN "WEST_PRC" TYPE double precision USING NULLIF(btrim("WEST_PRC"), '')::double precision;

-- KR_DATA (4 column(s))
ALTER TABLE "KR_DATA" ALTER COLUMN "HM_AMT" TYPE double precision USING NULLIF(btrim("HM_AMT"), '')::double precision;
ALTER TABLE "KR_DATA" ALTER COLUMN "HM_TAX_AMT" TYPE double precision USING NULLIF(btrim("HM_TAX_AMT"), '')::double precision;
ALTER TABLE "KR_DATA" ALTER COLUMN "HM_TAX_PRC" TYPE double precision USING NULLIF(btrim("HM_TAX_PRC"), '')::double precision;
ALTER TABLE "KR_DATA" ALTER COLUMN "OS_ADJ_AMT" TYPE double precision USING NULLIF(btrim("OS_ADJ_AMT"), '')::double precision;

-- KR_DETL (10 column(s))
ALTER TABLE "KR_DETL" ALTER COLUMN "AVG_AMT" TYPE double precision USING NULLIF(btrim("AVG_AMT"), '')::double precision;
ALTER TABLE "KR_DETL" ALTER COLUMN "AVG_RATE" TYPE double precision USING NULLIF(btrim("AVG_RATE"), '')::double precision;
ALTER TABLE "KR_DETL" ALTER COLUMN "CONV_PRC" TYPE double precision USING NULLIF(btrim("CONV_PRC"), '')::double precision;
ALTER TABLE "KR_DETL" ALTER COLUMN "CONV_RATE" TYPE double precision USING NULLIF(btrim("CONV_RATE"), '')::double precision;
ALTER TABLE "KR_DETL" ALTER COLUMN "CON_RATE" TYPE double precision USING NULLIF(btrim("CON_RATE"), '')::double precision;
ALTER TABLE "KR_DETL" ALTER COLUMN "ITM_LESS_TCH" TYPE double precision USING NULLIF(btrim("ITM_LESS_TCH"), '')::double precision;
ALTER TABLE "KR_DETL" ALTER COLUMN "ITM_LOSS_WT" TYPE double precision USING NULLIF(btrim("ITM_LOSS_WT"), '')::double precision;
ALTER TABLE "KR_DETL" ALTER COLUMN "ITM_OTH_FINE" TYPE double precision USING NULLIF(btrim("ITM_OTH_FINE"), '')::double precision;
ALTER TABLE "KR_DETL" ALTER COLUMN "ITM_OTH_RATE" TYPE double precision USING NULLIF(btrim("ITM_OTH_RATE"), '')::double precision;
ALTER TABLE "KR_DETL" ALTER COLUMN "SILVER_FINE" TYPE double precision USING NULLIF(btrim("SILVER_FINE"), '')::double precision;

-- LBR_ISU_DETL (4 column(s))
ALTER TABLE "LBR_ISU_DETL" ALTER COLUMN "KR_COST" TYPE double precision USING NULLIF(btrim("KR_COST"), '')::double precision;
ALTER TABLE "LBR_ISU_DETL" ALTER COLUMN "KR_OTH_AMT" TYPE double precision USING NULLIF(btrim("KR_OTH_AMT"), '')::double precision;
ALTER TABLE "LBR_ISU_DETL" ALTER COLUMN "NEW_FINE" TYPE double precision USING NULLIF(btrim("NEW_FINE"), '')::double precision;
ALTER TABLE "LBR_ISU_DETL" ALTER COLUMN "NEW_VCH_SRNO" TYPE double precision USING NULLIF(btrim("NEW_VCH_SRNO"), '')::double precision;

-- LEDR_AC_DATA (2 column(s))
ALTER TABLE "LEDR_AC_DATA" ALTER COLUMN "CR_FINE_WT" TYPE double precision USING NULLIF(btrim("CR_FINE_WT"), '')::double precision;
ALTER TABLE "LEDR_AC_DATA" ALTER COLUMN "DR_FINE_WT" TYPE double precision USING NULLIF(btrim("DR_FINE_WT"), '')::double precision;

-- MAIN_STOCK (4 column(s))
ALTER TABLE "MAIN_STOCK" ALTER COLUMN "KR_COST" TYPE double precision USING NULLIF(btrim("KR_COST"), '')::double precision;
ALTER TABLE "MAIN_STOCK" ALTER COLUMN "KR_NWT" TYPE double precision USING NULLIF(btrim("KR_NWT"), '')::double precision;
ALTER TABLE "MAIN_STOCK" ALTER COLUMN "KR_OTH_AMT" TYPE double precision USING NULLIF(btrim("KR_OTH_AMT"), '')::double precision;
ALTER TABLE "MAIN_STOCK" ALTER COLUMN "KR_WEST" TYPE double precision USING NULLIF(btrim("KR_WEST"), '')::double precision;

-- OP_DATA (3 column(s))
ALTER TABLE "OP_DATA" ALTER COLUMN "FINE_BAL" TYPE double precision USING NULLIF(btrim("FINE_BAL"), '')::double precision;
ALTER TABLE "OP_DATA" ALTER COLUMN "OP_AMT" TYPE double precision USING NULLIF(btrim("OP_AMT"), '')::double precision;
ALTER TABLE "OP_DATA" ALTER COLUMN "SL_FINE_BAL" TYPE double precision USING NULLIF(btrim("SL_FINE_BAL"), '')::double precision;

-- PR_DATA (4 column(s))
ALTER TABLE "PR_DATA" ALTER COLUMN "HM_AMT" TYPE double precision USING NULLIF(btrim("HM_AMT"), '')::double precision;
ALTER TABLE "PR_DATA" ALTER COLUMN "HM_TAX_AMT" TYPE double precision USING NULLIF(btrim("HM_TAX_AMT"), '')::double precision;
ALTER TABLE "PR_DATA" ALTER COLUMN "HM_TAX_PRC" TYPE double precision USING NULLIF(btrim("HM_TAX_PRC"), '')::double precision;
ALTER TABLE "PR_DATA" ALTER COLUMN "OS_ADJ_AMT" TYPE double precision USING NULLIF(btrim("OS_ADJ_AMT"), '')::double precision;

-- PR_DETL (12 column(s))
ALTER TABLE "PR_DETL" ALTER COLUMN "CONSI_SRNO" TYPE double precision USING NULLIF(btrim("CONSI_SRNO"), '')::double precision;
ALTER TABLE "PR_DETL" ALTER COLUMN "CONV_PRC" TYPE double precision USING NULLIF(btrim("CONV_PRC"), '')::double precision;
ALTER TABLE "PR_DETL" ALTER COLUMN "CONV_RATE" TYPE double precision USING NULLIF(btrim("CONV_RATE"), '')::double precision;
ALTER TABLE "PR_DETL" ALTER COLUMN "FINE_CUT_FINE" TYPE double precision USING NULLIF(btrim("FINE_CUT_FINE"), '')::double precision;
ALTER TABLE "PR_DETL" ALTER COLUMN "FINE_CUT_GWT" TYPE double precision USING NULLIF(btrim("FINE_CUT_GWT"), '')::double precision;
ALTER TABLE "PR_DETL" ALTER COLUMN "FINE_CUT_NWT" TYPE double precision USING NULLIF(btrim("FINE_CUT_NWT"), '')::double precision;
ALTER TABLE "PR_DETL" ALTER COLUMN "FINE_CUT_PCS" TYPE double precision USING NULLIF(btrim("FINE_CUT_PCS"), '')::double precision;
ALTER TABLE "PR_DETL" ALTER COLUMN "ITM_LESS_TCH" TYPE double precision USING NULLIF(btrim("ITM_LESS_TCH"), '')::double precision;
ALTER TABLE "PR_DETL" ALTER COLUMN "ITM_LOSS_WT" TYPE double precision USING NULLIF(btrim("ITM_LOSS_WT"), '')::double precision;
ALTER TABLE "PR_DETL" ALTER COLUMN "ITM_OTH_FINE" TYPE double precision USING NULLIF(btrim("ITM_OTH_FINE"), '')::double precision;
ALTER TABLE "PR_DETL" ALTER COLUMN "ITM_OTH_RATE" TYPE double precision USING NULLIF(btrim("ITM_OTH_RATE"), '')::double precision;
ALTER TABLE "PR_DETL" ALTER COLUMN "SILVER_FINE" TYPE double precision USING NULLIF(btrim("SILVER_FINE"), '')::double precision;

-- RATE_CUT_DATA (40 column(s))
ALTER TABLE "RATE_CUT_DATA" ALTER COLUMN "CONV_PRC" TYPE double precision USING NULLIF(btrim("CONV_PRC"), '')::double precision;
ALTER TABLE "RATE_CUT_DATA" ALTER COLUMN "CONV_RATE" TYPE double precision USING NULLIF(btrim("CONV_RATE"), '')::double precision;
ALTER TABLE "RATE_CUT_DATA" ALTER COLUMN "INT_FINE" TYPE double precision USING NULLIF(btrim("INT_FINE"), '')::double precision;
ALTER TABLE "RATE_CUT_DATA" ALTER COLUMN "INT_PRC_FINE" TYPE double precision USING NULLIF(btrim("INT_PRC_FINE"), '')::double precision;
ALTER TABLE "RATE_CUT_DATA" ALTER COLUMN "KSR_FINE_CR" TYPE double precision USING NULLIF(btrim("KSR_FINE_CR"), '')::double precision;
ALTER TABLE "RATE_CUT_DATA" ALTER COLUMN "KSR_FINE_DR" TYPE double precision USING NULLIF(btrim("KSR_FINE_DR"), '')::double precision;
ALTER TABLE "RATE_CUT_DATA" ALTER COLUMN "PR_ADV_AMT" TYPE double precision USING NULLIF(btrim("PR_ADV_AMT"), '')::double precision;
ALTER TABLE "RATE_CUT_DATA" ALTER COLUMN "PR_BILL_OS" TYPE double precision USING NULLIF(btrim("PR_BILL_OS"), '')::double precision;
ALTER TABLE "RATE_CUT_DATA" ALTER COLUMN "PR_CARD_AMT" TYPE double precision USING NULLIF(btrim("PR_CARD_AMT"), '')::double precision;
ALTER TABLE "RATE_CUT_DATA" ALTER COLUMN "PR_CASH_AMT" TYPE double precision USING NULLIF(btrim("PR_CASH_AMT"), '')::double precision;
ALTER TABLE "RATE_CUT_DATA" ALTER COLUMN "PR_CHQ_AMT" TYPE double precision USING NULLIF(btrim("PR_CHQ_AMT"), '')::double precision;
ALTER TABLE "RATE_CUT_DATA" ALTER COLUMN "PR_FINE" TYPE double precision USING NULLIF(btrim("PR_FINE"), '')::double precision;
ALTER TABLE "RATE_CUT_DATA" ALTER COLUMN "PR_ITM_AMT" TYPE double precision USING NULLIF(btrim("PR_ITM_AMT"), '')::double precision;
ALTER TABLE "RATE_CUT_DATA" ALTER COLUMN "PR_KASAR_AMT" TYPE double precision USING NULLIF(btrim("PR_KASAR_AMT"), '')::double precision;
ALTER TABLE "RATE_CUT_DATA" ALTER COLUMN "PR_LBR_AMT" TYPE double precision USING NULLIF(btrim("PR_LBR_AMT"), '')::double precision;
ALTER TABLE "RATE_CUT_DATA" ALTER COLUMN "PR_NET_AMT" TYPE double precision USING NULLIF(btrim("PR_NET_AMT"), '')::double precision;
ALTER TABLE "RATE_CUT_DATA" ALTER COLUMN "PR_OTH_AMT" TYPE double precision USING NULLIF(btrim("PR_OTH_AMT"), '')::double precision;
ALTER TABLE "RATE_CUT_DATA" ALTER COLUMN "PR_TAX_AMT" TYPE double precision USING NULLIF(btrim("PR_TAX_AMT"), '')::double precision;
ALTER TABLE "RATE_CUT_DATA" ALTER COLUMN "PR_TOT_AMT" TYPE double precision USING NULLIF(btrim("PR_TOT_AMT"), '')::double precision;
ALTER TABLE "RATE_CUT_DATA" ALTER COLUMN "SILVER_FINE_CR" TYPE double precision USING NULLIF(btrim("SILVER_FINE_CR"), '')::double precision;
ALTER TABLE "RATE_CUT_DATA" ALTER COLUMN "SILVER_FINE_DR" TYPE double precision USING NULLIF(btrim("SILVER_FINE_DR"), '')::double precision;
ALTER TABLE "RATE_CUT_DATA" ALTER COLUMN "SL_ADV_AMT" TYPE double precision USING NULLIF(btrim("SL_ADV_AMT"), '')::double precision;
ALTER TABLE "RATE_CUT_DATA" ALTER COLUMN "SL_BILL_OS" TYPE double precision USING NULLIF(btrim("SL_BILL_OS"), '')::double precision;
ALTER TABLE "RATE_CUT_DATA" ALTER COLUMN "SL_CARD_AMT" TYPE double precision USING NULLIF(btrim("SL_CARD_AMT"), '')::double precision;
ALTER TABLE "RATE_CUT_DATA" ALTER COLUMN "SL_CASH_AMT" TYPE double precision USING NULLIF(btrim("SL_CASH_AMT"), '')::double precision;
ALTER TABLE "RATE_CUT_DATA" ALTER COLUMN "SL_CHQ_AMT" TYPE double precision USING NULLIF(btrim("SL_CHQ_AMT"), '')::double precision;
ALTER TABLE "RATE_CUT_DATA" ALTER COLUMN "SL_FINE" TYPE double precision USING NULLIF(btrim("SL_FINE"), '')::double precision;
ALTER TABLE "RATE_CUT_DATA" ALTER COLUMN "SL_ITM_AMT" TYPE double precision USING NULLIF(btrim("SL_ITM_AMT"), '')::double precision;
ALTER TABLE "RATE_CUT_DATA" ALTER COLUMN "SL_KASAR_AMT" TYPE double precision USING NULLIF(btrim("SL_KASAR_AMT"), '')::double precision;
ALTER TABLE "RATE_CUT_DATA" ALTER COLUMN "SL_LBR_AMT" TYPE double precision USING NULLIF(btrim("SL_LBR_AMT"), '')::double precision;
ALTER TABLE "RATE_CUT_DATA" ALTER COLUMN "SL_NET_AMT" TYPE double precision USING NULLIF(btrim("SL_NET_AMT"), '')::double precision;
ALTER TABLE "RATE_CUT_DATA" ALTER COLUMN "SL_OTH_AMT" TYPE double precision USING NULLIF(btrim("SL_OTH_AMT"), '')::double precision;
ALTER TABLE "RATE_CUT_DATA" ALTER COLUMN "SL_TAX_AMT" TYPE double precision USING NULLIF(btrim("SL_TAX_AMT"), '')::double precision;
ALTER TABLE "RATE_CUT_DATA" ALTER COLUMN "SL_TOT_AMT" TYPE double precision USING NULLIF(btrim("SL_TOT_AMT"), '')::double precision;
ALTER TABLE "RATE_CUT_DATA" ALTER COLUMN "TOT_FINE_CR" TYPE double precision USING NULLIF(btrim("TOT_FINE_CR"), '')::double precision;
ALTER TABLE "RATE_CUT_DATA" ALTER COLUMN "TOT_FINE_DR" TYPE double precision USING NULLIF(btrim("TOT_FINE_DR"), '')::double precision;
ALTER TABLE "RATE_CUT_DATA" ALTER COLUMN "VP_ADJ_AMT" TYPE double precision USING NULLIF(btrim("VP_ADJ_AMT"), '')::double precision;
ALTER TABLE "RATE_CUT_DATA" ALTER COLUMN "VP_AMT" TYPE double precision USING NULLIF(btrim("VP_AMT"), '')::double precision;
ALTER TABLE "RATE_CUT_DATA" ALTER COLUMN "VP_CHARG_AMT" TYPE double precision USING NULLIF(btrim("VP_CHARG_AMT"), '')::double precision;
ALTER TABLE "RATE_CUT_DATA" ALTER COLUMN "VP_INS_AMT" TYPE double precision USING NULLIF(btrim("VP_INS_AMT"), '')::double precision;

-- RATE_CUT_ISU (14 column(s))
ALTER TABLE "RATE_CUT_ISU" ALTER COLUMN "CONV_PRC" TYPE double precision USING NULLIF(btrim("CONV_PRC"), '')::double precision;
ALTER TABLE "RATE_CUT_ISU" ALTER COLUMN "CONV_RATE" TYPE double precision USING NULLIF(btrim("CONV_RATE"), '')::double precision;
ALTER TABLE "RATE_CUT_ISU" ALTER COLUMN "FINE_CUT_FINE" TYPE double precision USING NULLIF(btrim("FINE_CUT_FINE"), '')::double precision;
ALTER TABLE "RATE_CUT_ISU" ALTER COLUMN "FINE_CUT_GWT" TYPE double precision USING NULLIF(btrim("FINE_CUT_GWT"), '')::double precision;
ALTER TABLE "RATE_CUT_ISU" ALTER COLUMN "FINE_CUT_NWT" TYPE double precision USING NULLIF(btrim("FINE_CUT_NWT"), '')::double precision;
ALTER TABLE "RATE_CUT_ISU" ALTER COLUMN "FINE_CUT_PCS" TYPE double precision USING NULLIF(btrim("FINE_CUT_PCS"), '')::double precision;
ALTER TABLE "RATE_CUT_ISU" ALTER COLUMN "HM_FINE" TYPE double precision USING NULLIF(btrim("HM_FINE"), '')::double precision;
ALTER TABLE "RATE_CUT_ISU" ALTER COLUMN "ITM_OTH_FINE" TYPE double precision USING NULLIF(btrim("ITM_OTH_FINE"), '')::double precision;
ALTER TABLE "RATE_CUT_ISU" ALTER COLUMN "ITM_OTH_RATE" TYPE double precision USING NULLIF(btrim("ITM_OTH_RATE"), '')::double precision;
ALTER TABLE "RATE_CUT_ISU" ALTER COLUMN "LESS_TOUCH" TYPE double precision USING NULLIF(btrim("LESS_TOUCH"), '')::double precision;
ALTER TABLE "RATE_CUT_ISU" ALTER COLUMN "MCX_RATE" TYPE double precision USING NULLIF(btrim("MCX_RATE"), '')::double precision;
ALTER TABLE "RATE_CUT_ISU" ALTER COLUMN "SILVER_FINE" TYPE double precision USING NULLIF(btrim("SILVER_FINE"), '')::double precision;
ALTER TABLE "RATE_CUT_ISU" ALTER COLUMN "TAG_GWT" TYPE double precision USING NULLIF(btrim("TAG_GWT"), '')::double precision;
ALTER TABLE "RATE_CUT_ISU" ALTER COLUMN "TAG_NWT" TYPE double precision USING NULLIF(btrim("TAG_NWT"), '')::double precision;

-- RATE_CUT_ISU_REC (5 column(s))
ALTER TABLE "RATE_CUT_ISU_REC" ALTER COLUMN "CONV_PRC" TYPE double precision USING NULLIF(btrim("CONV_PRC"), '')::double precision;
ALTER TABLE "RATE_CUT_ISU_REC" ALTER COLUMN "CONV_RATE" TYPE double precision USING NULLIF(btrim("CONV_RATE"), '')::double precision;
ALTER TABLE "RATE_CUT_ISU_REC" ALTER COLUMN "ITM_OTH_FINE" TYPE double precision USING NULLIF(btrim("ITM_OTH_FINE"), '')::double precision;
ALTER TABLE "RATE_CUT_ISU_REC" ALTER COLUMN "LESS_TOUCH" TYPE double precision USING NULLIF(btrim("LESS_TOUCH"), '')::double precision;
ALTER TABLE "RATE_CUT_ISU_REC" ALTER COLUMN "SILVER_FINE" TYPE double precision USING NULLIF(btrim("SILVER_FINE"), '')::double precision;

-- RATE_CUT_REC (7 column(s))
ALTER TABLE "RATE_CUT_REC" ALTER COLUMN "CONV_PRC" TYPE double precision USING NULLIF(btrim("CONV_PRC"), '')::double precision;
ALTER TABLE "RATE_CUT_REC" ALTER COLUMN "CONV_RATE" TYPE double precision USING NULLIF(btrim("CONV_RATE"), '')::double precision;
ALTER TABLE "RATE_CUT_REC" ALTER COLUMN "ITM_OTH_FINE" TYPE double precision USING NULLIF(btrim("ITM_OTH_FINE"), '')::double precision;
ALTER TABLE "RATE_CUT_REC" ALTER COLUMN "ITM_OTH_RATE" TYPE double precision USING NULLIF(btrim("ITM_OTH_RATE"), '')::double precision;
ALTER TABLE "RATE_CUT_REC" ALTER COLUMN "LESS_TOUCH" TYPE double precision USING NULLIF(btrim("LESS_TOUCH"), '')::double precision;
ALTER TABLE "RATE_CUT_REC" ALTER COLUMN "OLD_VCH_SRNO" TYPE double precision USING NULLIF(btrim("OLD_VCH_SRNO"), '')::double precision;
ALTER TABLE "RATE_CUT_REC" ALTER COLUMN "SILVER_FINE" TYPE double precision USING NULLIF(btrim("SILVER_FINE"), '')::double precision;

-- SL_DATA (22 column(s))
ALTER TABLE "SL_DATA" ALTER COLUMN "ADV_AMT" TYPE double precision USING NULLIF(btrim("ADV_AMT"), '')::double precision;
ALTER TABLE "SL_DATA" ALTER COLUMN "CRNT_ADJ_AMT" TYPE double precision USING NULLIF(btrim("CRNT_ADJ_AMT"), '')::double precision;
ALTER TABLE "SL_DATA" ALTER COLUMN "FX_RATE" TYPE double precision USING NULLIF(btrim("FX_RATE"), '')::double precision;
ALTER TABLE "SL_DATA" ALTER COLUMN "HM_AMT" TYPE double precision USING NULLIF(btrim("HM_AMT"), '')::double precision;
ALTER TABLE "SL_DATA" ALTER COLUMN "HM_TAX_AMT" TYPE double precision USING NULLIF(btrim("HM_TAX_AMT"), '')::double precision;
ALTER TABLE "SL_DATA" ALTER COLUMN "HM_TAX_PRC" TYPE double precision USING NULLIF(btrim("HM_TAX_PRC"), '')::double precision;
ALTER TABLE "SL_DATA" ALTER COLUMN "MTL_RATE" TYPE double precision USING NULLIF(btrim("MTL_RATE"), '')::double precision;
ALTER TABLE "SL_DATA" ALTER COLUMN "OLD_GL" TYPE double precision USING NULLIF(btrim("OLD_GL"), '')::double precision;
ALTER TABLE "SL_DATA" ALTER COLUMN "OLD_GL_AMT" TYPE double precision USING NULLIF(btrim("OLD_GL_AMT"), '')::double precision;
ALTER TABLE "SL_DATA" ALTER COLUMN "OLD_SL" TYPE double precision USING NULLIF(btrim("OLD_SL"), '')::double precision;
ALTER TABLE "SL_DATA" ALTER COLUMN "OLD_SL_AMT" TYPE double precision USING NULLIF(btrim("OLD_SL_AMT"), '')::double precision;
ALTER TABLE "SL_DATA" ALTER COLUMN "OS_ADJ_AMT" TYPE double precision USING NULLIF(btrim("OS_ADJ_AMT"), '')::double precision;
ALTER TABLE "SL_DATA" ALTER COLUMN "OZ_CONV" TYPE double precision USING NULLIF(btrim("OZ_CONV"), '')::double precision;
ALTER TABLE "SL_DATA" ALTER COLUMN "OZ_RATE" TYPE double precision USING NULLIF(btrim("OZ_RATE"), '')::double precision;
ALTER TABLE "SL_DATA" ALTER COLUMN "RTN_BILL_OS" TYPE double precision USING NULLIF(btrim("RTN_BILL_OS"), '')::double precision;
ALTER TABLE "SL_DATA" ALTER COLUMN "RTN_CARD_AMT" TYPE double precision USING NULLIF(btrim("RTN_CARD_AMT"), '')::double precision;
ALTER TABLE "SL_DATA" ALTER COLUMN "RTN_CASH_AMT" TYPE double precision USING NULLIF(btrim("RTN_CASH_AMT"), '')::double precision;
ALTER TABLE "SL_DATA" ALTER COLUMN "RTN_CHQ_AMT" TYPE double precision USING NULLIF(btrim("RTN_CHQ_AMT"), '')::double precision;
ALTER TABLE "SL_DATA" ALTER COLUMN "RTN_KASAR_AMT" TYPE double precision USING NULLIF(btrim("RTN_KASAR_AMT"), '')::double precision;
ALTER TABLE "SL_DATA" ALTER COLUMN "RTN_NET_AMT" TYPE double precision USING NULLIF(btrim("RTN_NET_AMT"), '')::double precision;
ALTER TABLE "SL_DATA" ALTER COLUMN "RTN_TOT_AMT" TYPE double precision USING NULLIF(btrim("RTN_TOT_AMT"), '')::double precision;
ALTER TABLE "SL_DATA" ALTER COLUMN "TOT_TAX_FREE_AMT" TYPE double precision USING NULLIF(btrim("TOT_TAX_FREE_AMT"), '')::double precision;

-- SL_DETL (14 column(s))
ALTER TABLE "SL_DETL" ALTER COLUMN "GHT_AMT" TYPE double precision USING NULLIF(btrim("GHT_AMT"), '')::double precision;
ALTER TABLE "SL_DETL" ALTER COLUMN "GRAND_TOTAL" TYPE double precision USING NULLIF(btrim("GRAND_TOTAL"), '')::double precision;
ALTER TABLE "SL_DETL" ALTER COLUMN "HM_AMT" TYPE double precision USING NULLIF(btrim("HM_AMT"), '')::double precision;
ALTER TABLE "SL_DETL" ALTER COLUMN "ITM_CGST_AMT" TYPE double precision USING NULLIF(btrim("ITM_CGST_AMT"), '')::double precision;
ALTER TABLE "SL_DETL" ALTER COLUMN "ITM_IGST_AMT" TYPE double precision USING NULLIF(btrim("ITM_IGST_AMT"), '')::double precision;
ALTER TABLE "SL_DETL" ALTER COLUMN "ITM_SGST_AMT" TYPE double precision USING NULLIF(btrim("ITM_SGST_AMT"), '')::double precision;
ALTER TABLE "SL_DETL" ALTER COLUMN "IT_DISC_AMT" TYPE double precision USING NULLIF(btrim("IT_DISC_AMT"), '')::double precision;
ALTER TABLE "SL_DETL" ALTER COLUMN "IT_TAX_AMT" TYPE double precision USING NULLIF(btrim("IT_TAX_AMT"), '')::double precision;
ALTER TABLE "SL_DETL" ALTER COLUMN "MCX_RATE" TYPE double precision USING NULLIF(btrim("MCX_RATE"), '')::double precision;
ALTER TABLE "SL_DETL" ALTER COLUMN "PRM_DISC" TYPE double precision USING NULLIF(btrim("PRM_DISC"), '')::double precision;
ALTER TABLE "SL_DETL" ALTER COLUMN "TAG_GWT" TYPE double precision USING NULLIF(btrim("TAG_GWT"), '')::double precision;
ALTER TABLE "SL_DETL" ALTER COLUMN "TAG_NWT" TYPE double precision USING NULLIF(btrim("TAG_NWT"), '')::double precision;
ALTER TABLE "SL_DETL" ALTER COLUMN "TAXABL_RATE" TYPE double precision USING NULLIF(btrim("TAXABL_RATE"), '')::double precision;
ALTER TABLE "SL_DETL" ALTER COLUMN "TAX_FREE_AMT" TYPE double precision USING NULLIF(btrim("TAX_FREE_AMT"), '')::double precision;

-- SL_ORD_DATA (11 column(s))
ALTER TABLE "SL_ORD_DATA" ALTER COLUMN "ADJ_GOLD" TYPE double precision USING NULLIF(btrim("ADJ_GOLD"), '')::double precision;
ALTER TABLE "SL_ORD_DATA" ALTER COLUMN "ADJ_SILVER" TYPE double precision USING NULLIF(btrim("ADJ_SILVER"), '')::double precision;
ALTER TABLE "SL_ORD_DATA" ALTER COLUMN "ADV_AMT" TYPE double precision USING NULLIF(btrim("ADV_AMT"), '')::double precision;
ALTER TABLE "SL_ORD_DATA" ALTER COLUMN "OLD_GL" TYPE double precision USING NULLIF(btrim("OLD_GL"), '')::double precision;
ALTER TABLE "SL_ORD_DATA" ALTER COLUMN "OLD_GL_AMT" TYPE double precision USING NULLIF(btrim("OLD_GL_AMT"), '')::double precision;
ALTER TABLE "SL_ORD_DATA" ALTER COLUMN "OLD_SL" TYPE double precision USING NULLIF(btrim("OLD_SL"), '')::double precision;
ALTER TABLE "SL_ORD_DATA" ALTER COLUMN "OLD_SL_AMT" TYPE double precision USING NULLIF(btrim("OLD_SL_AMT"), '')::double precision;
ALTER TABLE "SL_ORD_DATA" ALTER COLUMN "ORD_ADJ_AMT" TYPE double precision USING NULLIF(btrim("ORD_ADJ_AMT"), '')::double precision;
ALTER TABLE "SL_ORD_DATA" ALTER COLUMN "RCUT_AMT" TYPE double precision USING NULLIF(btrim("RCUT_AMT"), '')::double precision;
ALTER TABLE "SL_ORD_DATA" ALTER COLUMN "RCUT_FINE" TYPE double precision USING NULLIF(btrim("RCUT_FINE"), '')::double precision;
ALTER TABLE "SL_ORD_DATA" ALTER COLUMN "RCUT_RATE" TYPE double precision USING NULLIF(btrim("RCUT_RATE"), '')::double precision;

-- SL_ORD_DETL (1 column(s))
ALTER TABLE "SL_ORD_DETL" ALTER COLUMN "ORD_REC_AMT" TYPE double precision USING NULLIF(btrim("ORD_REC_AMT"), '')::double precision;

-- SL_PR_DETL (1 column(s))
ALTER TABLE "SL_PR_DETL" ALTER COLUMN "ITM_OTH" TYPE double precision USING NULLIF(btrim("ITM_OTH"), '')::double precision;

-- TAX_DATA (1 column(s))
ALTER TABLE "TAX_DATA" ALTER COLUMN "TAX_FREE_AMT" TYPE double precision USING NULLIF(btrim("TAX_FREE_AMT"), '')::double precision;

-- TAX_MAST (1 column(s))
ALTER TABLE "TAX_MAST" ALTER COLUMN "ADD_TAX_PRC" TYPE double precision USING NULLIF(btrim("ADD_TAX_PRC"), '')::double precision;

-- 226 column(s) converted.
