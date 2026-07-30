# APR_DETL

- **Cluster:** inventory
- **Source:** code-recovered
- **Columns:** 77
- **Primary key:** (none recovered)
- **Tenant/scope keys present:** CO_CODE, LC_CODE, CO_YEAR, CO_BOOK  ·  fully tenant-keyed
- **Web mapping:** `tenant_id` + the scope keys above; preserve column names verbatim.

| # | Column | Type | Len | Null | Default | Source |
|---|--------|------|-----|------|---------|--------|
| 1 | VCH_SRNO | FLOAT |  | Y |  | code+inferred-type |
| 2 | TAG_NO | VARCHAR | 15 | Y |  | code+inferred-type |
| 3 | ISU_REC | VARCHAR | 1 | Y |  | code+inferred-type |
| 4 | TBL_CODE | VARCHAR | 3 | Y |  | code+inferred-type |
| 5 | ADJ_GWT | unknown |  | Y |  | code |
| 6 | ADJ_NWT | unknown |  | Y |  | code |
| 7 | CON_ISU_REC | unknown |  | Y |  | code |
| 8 | CO_CODE ⟨scope⟩ | VARCHAR | 2 | Y |  | code+inferred-type |
| 9 | LC_CODE ⟨scope⟩ | VARCHAR | 2 | Y |  | code+inferred-type |
| 10 | CO_YEAR ⟨scope⟩ | VARCHAR | 10 | Y |  | code+inferred-type |
| 11 | CO_BOOK ⟨scope⟩ | VARCHAR | 3 | Y |  | code+inferred-type |
| 12 | VCH_NO | VARCHAR | 8 | Y |  | code+inferred-type |
| 13 | SR_NO | FLOAT |  | Y |  | code+inferred-type |
| 14 | OLD_SRNO | FLOAT |  | Y |  | code+inferred-type |
| 15 | VCH_DATE | DATE |  | Y |  | code+inferred-type |
| 16 | VCH_TIME | DATETIME |  | Y |  | code+inferred-type |
| 17 | AC_CODE | VARCHAR | 8 | Y |  | code+inferred-type |
| 18 | VCH_TYPE | VARCHAR | 6 | Y |  | code+inferred-type |
| 19 | INOUT_TYPE | VARCHAR | 1 | Y |  | code+inferred-type |
| 20 | ENTRY_TYPE | VARCHAR | 1 | Y |  | code+inferred-type |
| 21 | BOOK_NAME | VARCHAR | 20 | Y |  | code+inferred-type |
| 22 | IT_CODE | VARCHAR | 5 | Y |  | code+inferred-type |
| 23 | LOT_NO | VARCHAR | 15 | Y |  | code+inferred-type |
| 24 | DESIGN_NO | VARCHAR | 15 | Y |  | code+inferred-type |
| 25 | ITM_SIZE | VARCHAR | 20 | Y |  | code+inferred-type |
| 26 | ITM_PCS | FLOAT |  | Y |  | code+inferred-type |
| 27 | BAG_WT | FLOAT |  | Y |  | code+inferred-type |
| 28 | ITM_GWT | FLOAT |  | Y |  | code+inferred-type |
| 29 | ITM_OTH_WT | FLOAT |  | Y |  | code+inferred-type |
| 30 | ITM_NWT | FLOAT |  | Y |  | code+inferred-type |
| 31 | ITM_GHT_WT | FLOAT |  | Y |  | code+inferred-type |
| 32 | ITM_TOUCH | FLOAT |  | Y |  | code+inferred-type |
| 33 | ITM_WEST_PRC | FLOAT |  | Y |  | code+inferred-type |
| 34 | ITM_FINE | FLOAT |  | Y |  | code+inferred-type |
| 35 | LBR_PRC | FLOAT |  | Y |  | code+inferred-type |
| 36 | LBR_RATE | FLOAT |  | Y |  | code+inferred-type |
| 37 | LBR_TYPE | VARCHAR | 1 | Y |  | code+inferred-type |
| 38 | LBR_AMT | FLOAT |  | Y |  | code+inferred-type |
| 39 | OTH_AMT | FLOAT |  | Y |  | code+inferred-type |
| 40 | ITM_RATE | FLOAT |  | Y |  | code+inferred-type |
| 41 | ITM_AMT | FLOAT |  | Y |  | code+inferred-type |
| 42 | TAG_COST | FLOAT |  | Y |  | code+inferred-type |
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
| 54 | MAIN_USER | VARCHAR | 15 | Y |  | code+inferred-type |
| 55 | ISU_NO | VARCHAR | 10 | Y |  | code+inferred-type |
| 56 | ISU_YRCD | VARCHAR | 9 | Y |  | code+inferred-type |
| 57 | ISU_DBCD | VARCHAR | 3 | Y |  | code+inferred-type |
| 58 | ISU_SRNO | FLOAT |  | Y |  | code+inferred-type |
| 59 | ITM_MRP | FLOAT |  | Y |  | code+inferred-type |
| 60 | EMP_SALE | unknown |  | Y |  | code |
| 61 | ISU_AC_CODE | VARCHAR | 8 | Y |  | code+inferred-type |
| 62 | ISU_AC_NAME | VARCHAR | 50 | Y |  | code+inferred-type |
| 63 | MTL_COLOR | unknown |  | Y |  | code |
| 64 | HM_ID | VARCHAR | 10 | Y |  | code+inferred-type |
| 65 | HM_ID2 | VARCHAR | 10 | Y |  | code+inferred-type |
| 66 | HM_ID3 | VARCHAR | 10 | Y |  | code+inferred-type |
| 67 | HM_ID4 | VARCHAR | 10 | Y |  | code+inferred-type |
| 68 | HM_ID_WT | FLOAT |  | Y |  | code+inferred-type |
| 69 | HM_ID2_WT | FLOAT |  | Y |  | code+inferred-type |
| 70 | HM_ID3_WT | FLOAT |  | Y |  | code+inferred-type |
| 71 | HM_ID4_WT | FLOAT |  | Y |  | code+inferred-type |
| 72 | ITM_COLOR | VARCHAR | 15 | Y |  | code+inferred-type |
| 73 | ORNA_REC_DATE | unknown |  | Y |  | code |
| 74 | EMP_CODE | VARCHAR | 3 | Y |  | code+inferred-type |
| 75 | ITM_LESS_TCH | unknown |  | Y |  | code |
| 76 | ITM_LOSS_WT | unknown |  | Y |  | code |
| 77 | DESIGN_IMG_ID | VARCHAR | 50 | Y |  | code+inferred-type |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
