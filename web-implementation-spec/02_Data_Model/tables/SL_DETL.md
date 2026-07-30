# SL_DETL

- **Cluster:** sales
- **Source:** code-recovered
- **Columns:** 106
- **Primary key:** (none recovered)
- **Tenant/scope keys present:** CO_CODE, LC_CODE, CO_YEAR, CO_BOOK  ·  fully tenant-keyed
- **Web mapping:** `tenant_id` + the scope keys above; preserve column names verbatim.

| # | Column | Type | Len | Null | Default | Source |
|---|--------|------|-----|------|---------|--------|
| 1 | VCH_SRNO | FLOAT |  | Y |  | code+inferred-type |
| 2 | TAG_NO | VARCHAR | 15 | Y |  | code+inferred-type |
| 3 | IT_TAX_AMT | unknown |  | Y |  | code |
| 4 | VCH_NO | VARCHAR | 8 | Y |  | code+inferred-type |
| 5 | CO_CODE ⟨scope⟩ | VARCHAR | 2 | Y |  | code+inferred-type |
| 6 | LC_CODE ⟨scope⟩ | VARCHAR | 2 | Y |  | code+inferred-type |
| 7 | CO_YEAR ⟨scope⟩ | VARCHAR | 10 | Y |  | code+inferred-type |
| 8 | CO_BOOK ⟨scope⟩ | VARCHAR | 3 | Y |  | code+inferred-type |
| 9 | SR_NO | FLOAT |  | Y |  | code+inferred-type |
| 10 | OLD_SRNO | FLOAT |  | Y |  | code+inferred-type |
| 11 | VCH_DATE | DATE |  | Y |  | code+inferred-type |
| 12 | VCH_TIME | DATETIME |  | Y |  | code+inferred-type |
| 13 | VCH_TYPE | VARCHAR | 6 | Y |  | code+inferred-type |
| 14 | INOUT_TYPE | VARCHAR | 1 | Y |  | code+inferred-type |
| 15 | ENTRY_TYPE | VARCHAR | 1 | Y |  | code+inferred-type |
| 16 | BOOK_NAME | VARCHAR | 20 | Y |  | code+inferred-type |
| 17 | AC_CODE | VARCHAR | 8 | Y |  | code+inferred-type |
| 18 | IT_CODE | VARCHAR | 5 | Y |  | code+inferred-type |
| 19 | LOT_NO | VARCHAR | 15 | Y |  | code+inferred-type |
| 20 | DESIGN_NO | VARCHAR | 15 | Y |  | code+inferred-type |
| 21 | TBL_CODE | VARCHAR | 3 | Y |  | code+inferred-type |
| 22 | ITM_SIZE | VARCHAR | 20 | Y |  | code+inferred-type |
| 23 | ITM_PCS | FLOAT |  | Y |  | code+inferred-type |
| 24 | BAG_WT | FLOAT |  | Y |  | code+inferred-type |
| 25 | ITM_GWT | FLOAT |  | Y |  | code+inferred-type |
| 26 | ITM_OTH_WT | FLOAT |  | Y |  | code+inferred-type |
| 27 | ITM_NWT | FLOAT |  | Y |  | code+inferred-type |
| 28 | ITM_GHT_WT | FLOAT |  | Y |  | code+inferred-type |
| 29 | ITM_TOUCH | FLOAT |  | Y |  | code+inferred-type |
| 30 | ITM_WEST_PRC | FLOAT |  | Y |  | code+inferred-type |
| 31 | ITM_FINE | FLOAT |  | Y |  | code+inferred-type |
| 32 | LBR_PRC | FLOAT |  | Y |  | code+inferred-type |
| 33 | LBR_RATE | FLOAT |  | Y |  | code+inferred-type |
| 34 | LBR_TYPE | VARCHAR | 1 | Y |  | code+inferred-type |
| 35 | LBR_AMT | FLOAT |  | Y |  | code+inferred-type |
| 36 | OTH_AMT | FLOAT |  | Y |  | code+inferred-type |
| 37 | ITM_RATE | FLOAT |  | Y |  | code+inferred-type |
| 38 | ITM_AMT | FLOAT |  | Y |  | code+inferred-type |
| 39 | TAG_COST | FLOAT |  | Y |  | code+inferred-type |
| 40 | ITM_MRP | FLOAT |  | Y |  | code+inferred-type |
| 41 | TOT_AMT | FLOAT |  | Y |  | code+inferred-type |
| 42 | TAX_PRC | FLOAT |  | Y |  | code+inferred-type |
| 43 | NET_AMT | FLOAT |  | Y |  | code+inferred-type |
| 44 | ITM_REMARK | VARCHAR | 50 | Y |  | code+inferred-type |
| 45 | KR_NET_WT | FLOAT |  | Y |  | code+inferred-type |
| 46 | KR_TOUCH | FLOAT |  | Y |  | code+inferred-type |
| 47 | KR_WEST_PRC | FLOAT |  | Y |  | code+inferred-type |
| 48 | KR_FINE | FLOAT |  | Y |  | code+inferred-type |
| 49 | KR_NAME | VARCHAR | 5 | Y |  | code+inferred-type |
| 50 | RATE_TYPE | VARCHAR | 1 | Y |  | code+inferred-type |
| 51 | IT_TYPE | VARCHAR | 1 | Y |  | code+inferred-type |
| 52 | PR_CODE | VARCHAR | 2 | Y |  | code+inferred-type |
| 53 | HD_VCH_NO | VARCHAR | 10 | Y |  | code+inferred-type |
| 54 | DATA_TRFR | VARCHAR | 1 | Y |  | code+inferred-type |
| 55 | OLD_VCH_NO | VARCHAR | 8 | Y |  | code+inferred-type |
| 56 | NEW_VCH_NO | VARCHAR | 8 | Y |  | code+inferred-type |
| 57 | MAIN_USER | VARCHAR | 15 | Y |  | code+inferred-type |
| 58 | ADD_USER | VARCHAR | 15 | Y |  | code+inferred-type |
| 59 | ISU_NO | VARCHAR | 10 | Y |  | code+inferred-type |
| 60 | ISU_LC_CODE | unknown |  | Y |  | code |
| 61 | ISU_YRCD | VARCHAR | 9 | Y |  | code+inferred-type |
| 62 | ISU_DBCD | VARCHAR | 3 | Y |  | code+inferred-type |
| 63 | ISU_SRNO | FLOAT |  | Y |  | code+inferred-type |
| 64 | ITM_GHT_PRC | FLOAT |  | Y |  | code+inferred-type |
| 65 | GHT_AMT | unknown |  | Y |  | code |
| 66 | HM_ID | VARCHAR | 10 | Y |  | code+inferred-type |
| 67 | HM_ID2 | VARCHAR | 10 | Y |  | code+inferred-type |
| 68 | HM_ID3 | VARCHAR | 10 | Y |  | code+inferred-type |
| 69 | HM_ID4 | VARCHAR | 10 | Y |  | code+inferred-type |
| 70 | HM_ID_WT | FLOAT |  | Y |  | code+inferred-type |
| 71 | HM_ID2_WT | FLOAT |  | Y |  | code+inferred-type |
| 72 | HM_ID3_WT | FLOAT |  | Y |  | code+inferred-type |
| 73 | HM_ID4_WT | FLOAT |  | Y |  | code+inferred-type |
| 74 | HM_AMT | unknown |  | Y |  | code |
| 75 | IT_DISC_AMT | unknown |  | Y |  | code |
| 76 | TAG_GWT | unknown |  | Y |  | code |
| 77 | TAG_NWT | unknown |  | Y |  | code |
| 78 | FINE_RATE | FLOAT |  | Y |  | code+inferred-type |
| 79 | DISC_PRC | FLOAT |  | Y |  | code+inferred-type |
| 80 | DISC_AMT | FLOAT |  | Y |  | code+inferred-type |
| 81 | TAX_CODE | VARCHAR | 2 | Y |  | code+inferred-type |
| 82 | TAXABL_RATE | unknown |  | Y |  | code |
| 83 | ITM_IGST_AMT | unknown |  | Y |  | code |
| 84 | ITM_CGST_AMT | unknown |  | Y |  | code |
| 85 | ITM_SGST_AMT | unknown |  | Y |  | code |
| 86 | GRAND_TOTAL | unknown |  | Y |  | code |
| 87 | ITM_COLOR | VARCHAR | 15 | Y |  | code+inferred-type |
| 88 | EMP_CODE | VARCHAR | 3 | Y |  | code+inferred-type |
| 89 | ORD_TAG_STK_ADD | unknown |  | Y |  | code |
| 90 | DESIGN_IMG_ID | VARCHAR | 50 | Y |  | code+inferred-type |
| 91 | RATE_WITH | unknown |  | Y |  | code |
| 92 | ITM_LOT | unknown |  | Y |  | code |
| 93 | MCX_RATE | unknown |  | Y |  | code |
| 94 | PRM_AMT | FLOAT |  | Y |  | code+inferred-type |
| 95 | PRM_DISC | unknown |  | Y |  | code |
| 96 | ITM_STYLE | unknown |  | Y |  | code |
| 97 | TAX_TYPE | VARCHAR | 1 | Y |  | code+inferred-type |
| 98 | TAX_FREE_AMT | unknown |  | Y |  | code |
| 99 | TAX_RVRS | unknown |  | Y |  | code |
| 100 | ORD_NO | VARCHAR | 8 | Y |  | code+inferred-type |
| 101 | ORD_LC_CODE | unknown |  | Y |  | code |
| 102 | ORD_YRCD | VARCHAR | 10 | Y |  | code+inferred-type |
| 103 | ORD_DBCD | VARCHAR | 8 | Y |  | code+inferred-type |
| 104 | ORD_SRNO | FLOAT |  | Y |  | code+inferred-type |
| 105 | IT_LBR_TAX | unknown |  | Y |  | code |
| 106 | POINT_VAL | FLOAT |  | Y |  | code+inferred-type |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
