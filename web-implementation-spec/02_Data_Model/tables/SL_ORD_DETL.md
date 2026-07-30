# SL_ORD_DETL

- **Cluster:** sales
- **Source:** code-recovered
- **Columns:** 77
- **Primary key:** (none recovered)
- **Tenant/scope keys present:** CO_CODE, LC_CODE, CO_YEAR, CO_BOOK  ·  fully tenant-keyed
- **Web mapping:** `tenant_id` + the scope keys above; preserve column names verbatim.

| # | Column | Type | Len | Null | Default | Source |
|---|--------|------|-----|------|---------|--------|
| 1 | TAG_GEN | unknown |  | Y |  | code |
| 2 | TAG_SALE | unknown |  | Y |  | code |
| 3 | DESIGN_ISU | unknown |  | Y |  | code |
| 4 | CO_CODE ⟨scope⟩ | VARCHAR | 2 | Y |  | code+inferred-type |
| 5 | LC_CODE ⟨scope⟩ | VARCHAR | 2 | Y |  | code+inferred-type |
| 6 | CO_YEAR ⟨scope⟩ | VARCHAR | 10 | Y |  | code+inferred-type |
| 7 | CO_BOOK ⟨scope⟩ | VARCHAR | 3 | Y |  | code+inferred-type |
| 8 | VCH_NO | VARCHAR | 8 | Y |  | code+inferred-type |
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
| 19 | TAG_NO | VARCHAR | 15 | Y |  | code+inferred-type |
| 20 | LOT_NO | VARCHAR | 15 | Y |  | code+inferred-type |
| 21 | DESIGN_NO | VARCHAR | 15 | Y |  | code+inferred-type |
| 22 | TBL_CODE | VARCHAR | 3 | Y |  | code+inferred-type |
| 23 | ITM_SIZE | VARCHAR | 20 | Y |  | code+inferred-type |
| 24 | ITM_PCS | FLOAT |  | Y |  | code+inferred-type |
| 25 | BAG_WT | FLOAT |  | Y |  | code+inferred-type |
| 26 | ITM_GWT | FLOAT |  | Y |  | code+inferred-type |
| 27 | ITM_OTH_WT | FLOAT |  | Y |  | code+inferred-type |
| 28 | ITM_NWT | FLOAT |  | Y |  | code+inferred-type |
| 29 | ITM_GHT_WT | FLOAT |  | Y |  | code+inferred-type |
| 30 | ITM_TOUCH | FLOAT |  | Y |  | code+inferred-type |
| 31 | ITM_WEST_PRC | FLOAT |  | Y |  | code+inferred-type |
| 32 | ITM_FINE | FLOAT |  | Y |  | code+inferred-type |
| 33 | LBR_PRC | FLOAT |  | Y |  | code+inferred-type |
| 34 | LBR_RATE | FLOAT |  | Y |  | code+inferred-type |
| 35 | LBR_TYPE | VARCHAR | 1 | Y |  | code+inferred-type |
| 36 | LBR_AMT | FLOAT |  | Y |  | code+inferred-type |
| 37 | OTH_AMT | FLOAT |  | Y |  | code+inferred-type |
| 38 | ITM_RATE | FLOAT |  | Y |  | code+inferred-type |
| 39 | ITM_AMT | FLOAT |  | Y |  | code+inferred-type |
| 40 | TAG_COST | FLOAT |  | Y |  | code+inferred-type |
| 41 | ITM_MRP | FLOAT |  | Y |  | code+inferred-type |
| 42 | TOT_AMT | FLOAT |  | Y |  | code+inferred-type |
| 43 | TAX_PRC | FLOAT |  | Y |  | code+inferred-type |
| 44 | NET_AMT | FLOAT |  | Y |  | code+inferred-type |
| 45 | ITM_REMARK | VARCHAR | 50 | Y |  | code+inferred-type |
| 46 | VCH_SRNO | FLOAT |  | Y |  | code+inferred-type |
| 47 | KR_NET_WT | FLOAT |  | Y |  | code+inferred-type |
| 48 | KR_TOUCH | FLOAT |  | Y |  | code+inferred-type |
| 49 | KR_WEST_PRC | FLOAT |  | Y |  | code+inferred-type |
| 50 | KR_FINE | FLOAT |  | Y |  | code+inferred-type |
| 51 | KR_NAME | VARCHAR | 5 | Y |  | code+inferred-type |
| 52 | RATE_TYPE | VARCHAR | 1 | Y |  | code+inferred-type |
| 53 | IT_TYPE | VARCHAR | 1 | Y |  | code+inferred-type |
| 54 | PR_CODE | VARCHAR | 2 | Y |  | code+inferred-type |
| 55 | HD_VCH_NO | VARCHAR | 10 | Y |  | code+inferred-type |
| 56 | DATA_TRFR | VARCHAR | 1 | Y |  | code+inferred-type |
| 57 | OLD_VCH_NO | VARCHAR | 8 | Y |  | code+inferred-type |
| 58 | NEW_VCH_NO | VARCHAR | 8 | Y |  | code+inferred-type |
| 59 | MAIN_USER | VARCHAR | 15 | Y |  | code+inferred-type |
| 60 | ADD_USER | VARCHAR | 15 | Y |  | code+inferred-type |
| 61 | ITM_GHT_PRC | FLOAT |  | Y |  | code+inferred-type |
| 62 | HM_ID2 | VARCHAR | 10 | Y |  | code+inferred-type |
| 63 | HM_ID3 | VARCHAR | 10 | Y |  | code+inferred-type |
| 64 | HM_ID4 | VARCHAR | 10 | Y |  | code+inferred-type |
| 65 | HM_ID_WT | FLOAT |  | Y |  | code+inferred-type |
| 66 | HM_ID2_WT | FLOAT |  | Y |  | code+inferred-type |
| 67 | HM_ID3_WT | FLOAT |  | Y |  | code+inferred-type |
| 68 | HM_ID4_WT | FLOAT |  | Y |  | code+inferred-type |
| 69 | HM_ID | VARCHAR | 10 | Y |  | code+inferred-type |
| 70 | ORD_REC_AMT | unknown |  | Y |  | code |
| 71 | EMP_CODE | VARCHAR | 3 | Y |  | code+inferred-type |
| 72 | ITM_COLOR | VARCHAR | 15 | Y |  | code+inferred-type |
| 73 | OLD_TBL_CODE | unknown |  | Y |  | code |
| 74 | ORD_DEL_DATE | unknown |  | Y |  | code |
| 75 | TAG_STK_LESS | unknown |  | Y |  | code |
| 76 | RATE_FIX | unknown |  | Y |  | code |
| 77 | DESIGN_IMG_ID | VARCHAR | 50 | Y |  | code+inferred-type |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
