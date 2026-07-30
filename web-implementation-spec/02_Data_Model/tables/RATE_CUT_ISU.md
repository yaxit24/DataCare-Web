# RATE_CUT_ISU

- **Cluster:** ancillary
- **Source:** code-recovered
- **Columns:** 82
- **Primary key:** (none recovered)
- **Tenant/scope keys present:** CO_CODE, LC_CODE, CO_YEAR, CO_BOOK  ·  fully tenant-keyed
- **Web mapping:** `tenant_id` + the scope keys above; preserve column names verbatim.

| # | Column | Type | Len | Null | Default | Source |
|---|--------|------|-----|------|---------|--------|
| 1 | VCH_SRNO | FLOAT |  | Y |  | code+inferred-type |
| 2 | TAG_NO | VARCHAR | 15 | Y |  | code+inferred-type |
| 3 | CO_CODE ⟨scope⟩ | VARCHAR | 2 | Y |  | code+inferred-type |
| 4 | LC_CODE ⟨scope⟩ | VARCHAR | 2 | Y |  | code+inferred-type |
| 5 | CO_YEAR ⟨scope⟩ | VARCHAR | 10 | Y |  | code+inferred-type |
| 6 | CO_BOOK ⟨scope⟩ | VARCHAR | 3 | Y |  | code+inferred-type |
| 7 | VCH_NO | VARCHAR | 8 | Y |  | code+inferred-type |
| 8 | SR_NO | FLOAT |  | Y |  | code+inferred-type |
| 9 | OLD_SRNO | FLOAT |  | Y |  | code+inferred-type |
| 10 | VCH_DATE | DATE |  | Y |  | code+inferred-type |
| 11 | VCH_TIME | DATETIME |  | Y |  | code+inferred-type |
| 12 | VCH_TYPE | VARCHAR | 6 | Y |  | code+inferred-type |
| 13 | INOUT_TYPE | VARCHAR | 1 | Y |  | code+inferred-type |
| 14 | ENTRY_TYPE | VARCHAR | 1 | Y |  | code+inferred-type |
| 15 | BOOK_NAME | VARCHAR | 20 | Y |  | code+inferred-type |
| 16 | AC_CODE | VARCHAR | 8 | Y |  | code+inferred-type |
| 17 | IT_CODE | VARCHAR | 5 | Y |  | code+inferred-type |
| 18 | LOT_NO | VARCHAR | 15 | Y |  | code+inferred-type |
| 19 | DESIGN_NO | VARCHAR | 15 | Y |  | code+inferred-type |
| 20 | TBL_CODE | VARCHAR | 3 | Y |  | code+inferred-type |
| 21 | ITM_SIZE | VARCHAR | 20 | Y |  | code+inferred-type |
| 22 | ITM_PCS | FLOAT |  | Y |  | code+inferred-type |
| 23 | BAG_WT | FLOAT |  | Y |  | code+inferred-type |
| 24 | ITM_GWT | FLOAT |  | Y |  | code+inferred-type |
| 25 | ITM_OTH_WT | FLOAT |  | Y |  | code+inferred-type |
| 26 | ITM_NWT | FLOAT |  | Y |  | code+inferred-type |
| 27 | ITM_GHT_WT | FLOAT |  | Y |  | code+inferred-type |
| 28 | ITM_TOUCH | FLOAT |  | Y |  | code+inferred-type |
| 29 | ITM_WEST_PRC | FLOAT |  | Y |  | code+inferred-type |
| 30 | ITM_FINE | FLOAT |  | Y |  | code+inferred-type |
| 31 | LBR_PRC | FLOAT |  | Y |  | code+inferred-type |
| 32 | LBR_RATE | FLOAT |  | Y |  | code+inferred-type |
| 33 | LBR_TYPE | VARCHAR | 1 | Y |  | code+inferred-type |
| 34 | LBR_AMT | FLOAT |  | Y |  | code+inferred-type |
| 35 | OTH_AMT | FLOAT |  | Y |  | code+inferred-type |
| 36 | ITM_RATE | FLOAT |  | Y |  | code+inferred-type |
| 37 | ITM_AMT | FLOAT |  | Y |  | code+inferred-type |
| 38 | TAG_COST | FLOAT |  | Y |  | code+inferred-type |
| 39 | ITM_MRP | FLOAT |  | Y |  | code+inferred-type |
| 40 | TOT_AMT | FLOAT |  | Y |  | code+inferred-type |
| 41 | TAX_PRC | FLOAT |  | Y |  | code+inferred-type |
| 42 | NET_AMT | FLOAT |  | Y |  | code+inferred-type |
| 43 | ITM_REMARK | VARCHAR | 50 | Y |  | code+inferred-type |
| 44 | KR_NET_WT | FLOAT |  | Y |  | code+inferred-type |
| 45 | KR_TOUCH | FLOAT |  | Y |  | code+inferred-type |
| 46 | KR_WEST_PRC | FLOAT |  | Y |  | code+inferred-type |
| 47 | KR_FINE | FLOAT |  | Y |  | code+inferred-type |
| 48 | KR_NAME | VARCHAR | 5 | Y |  | code+inferred-type |
| 49 | RATE_TYPE | VARCHAR | 1 | Y |  | code+inferred-type |
| 50 | IT_TYPE | VARCHAR | 1 | Y |  | code+inferred-type |
| 51 | PR_CODE | VARCHAR | 2 | Y |  | code+inferred-type |
| 52 | HD_VCH_NO | VARCHAR | 10 | Y |  | code+inferred-type |
| 53 | DATA_TRFR | VARCHAR | 1 | Y |  | code+inferred-type |
| 54 | OLD_VCH_NO | VARCHAR | 8 | Y |  | code+inferred-type |
| 55 | NEW_VCH_NO | VARCHAR | 8 | Y |  | code+inferred-type |
| 56 | MAIN_USER | VARCHAR | 15 | Y |  | code+inferred-type |
| 57 | ADD_USER | VARCHAR | 15 | Y |  | code+inferred-type |
| 58 | LESS_TOUCH | unknown |  | Y |  | code |
| 59 | ITM_OTH_RATE | unknown |  | Y |  | code |
| 60 | ITM_OTH_FINE | unknown |  | Y |  | code |
| 61 | CONV_RATE | unknown |  | Y |  | code |
| 62 | CONV_PRC | unknown |  | Y |  | code |
| 63 | SILVER_FINE | unknown |  | Y |  | code |
| 64 | ISU_NO | VARCHAR | 10 | Y |  | code+inferred-type |
| 65 | ISU_LC_CODE | unknown |  | Y |  | code |
| 66 | ISU_YRCD | VARCHAR | 9 | Y |  | code+inferred-type |
| 67 | ISU_DBCD | VARCHAR | 3 | Y |  | code+inferred-type |
| 68 | ISU_SRNO | FLOAT |  | Y |  | code+inferred-type |
| 69 | LESS_WT | FLOAT |  | Y |  | code+inferred-type |
| 70 | TAG_GWT | unknown |  | Y |  | code |
| 71 | TAG_NWT | unknown |  | Y |  | code |
| 72 | MCX_RATE | unknown |  | Y |  | code |
| 73 | HM_FINE | unknown |  | Y |  | code |
| 74 | DESIGN_IMG_ID | VARCHAR | 50 | Y |  | code+inferred-type |
| 75 | ADJ_WT | FLOAT |  | Y |  | code+inferred-type |
| 76 | ITM_LOT | unknown |  | Y |  | code |
| 77 | FINE_CUT_FINE | unknown |  | Y |  | code |
| 78 | FINE_CUT_NWT | unknown |  | Y |  | code |
| 79 | FINE_CUT_GWT | unknown |  | Y |  | code |
| 80 | FINE_CUT_PCS | unknown |  | Y |  | code |
| 81 | EMP_CODE | VARCHAR | 3 | Y |  | code+inferred-type |
| 82 | PRM_AMT | FLOAT |  | Y |  | code+inferred-type |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
