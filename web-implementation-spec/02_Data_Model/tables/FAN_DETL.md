# FAN_DETL

- **Cluster:** ancillary
- **Source:** DDL
- **Columns:** 73
- **Primary key:** CO_CODE, LC_CODE, CO_YEAR, CO_BOOK, VCH_NO, SR_NO
- **Tenant/scope keys present:** CO_CODE, LC_CODE, CO_YEAR, CO_BOOK  ·  fully tenant-keyed
- **Web mapping:** `tenant_id` + the scope keys above; preserve column names verbatim.

| # | Column | Type | Len | Null | Default | Source |
|---|--------|------|-----|------|---------|--------|
| 1 | CO_CODE 🔑 ⟨scope⟩ | VARCHAR | 2 | Y |  | ddl |
| 2 | LC_CODE 🔑 ⟨scope⟩ | VARCHAR | 2 | Y |  | ddl |
| 3 | CO_YEAR 🔑 ⟨scope⟩ | VARCHAR | 10 | Y |  | ddl |
| 4 | CO_BOOK 🔑 ⟨scope⟩ | VARCHAR | 3 | Y |  | ddl |
| 5 | VCH_NO 🔑 | VARCHAR | 8 | Y |  | ddl |
| 6 | SR_NO 🔑 | FLOAT |  | N | 0 | ddl |
| 7 | OLD_SRNO | FLOAT |  | N | 0 | ddl |
| 8 | VCH_DATE | DATE |  | Y |  | ddl |
| 9 | VCH_TIME | DATETIME |  | Y |  | ddl |
| 10 | VCH_TYPE | VARCHAR | 6 | Y |  | ddl |
| 11 | INOUT_TYPE | VARCHAR | 1 | Y |  | ddl |
| 12 | ENTRY_TYPE | VARCHAR | 1 | Y |  | ddl |
| 13 | BOOK_NAME | VARCHAR | 20 | Y |  | ddl |
| 14 | AC_CODE | VARCHAR | 8 | Y |  | ddl |
| 15 | TO_FAN_CODE | VARCHAR | 2 | Y |  | ddl |
| 16 | IT_CODE | VARCHAR | 5 | Y |  | ddl |
| 17 | TAG_NO | VARCHAR | 15 | Y |  | ddl |
| 18 | LOT_NO | VARCHAR | 15 | Y |  | ddl |
| 19 | DESIGN_NO | VARCHAR | 15 | Y |  | ddl |
| 20 | TBL_CODE | VARCHAR | 3 | Y |  | ddl |
| 21 | ITM_SIZE | VARCHAR | 20 | Y |  | ddl |
| 22 | ITM_PCS | FLOAT |  | N | 0 | ddl |
| 23 | BAG_WT | FLOAT |  | N | 0 | ddl |
| 24 | ITM_GWT | FLOAT |  | N | 0 | ddl |
| 25 | ITM_OTH_WT | FLOAT |  | N | 0 | ddl |
| 26 | ITM_NWT | FLOAT |  | N | 0 | ddl |
| 27 | ITM_GHT_WT | FLOAT |  | N | 0 | ddl |
| 28 | ITM_TOUCH | FLOAT |  | N | 0 | ddl |
| 29 | ITM_WEST_PRC | FLOAT |  | N | 0 | ddl |
| 30 | ITM_FINE | FLOAT |  | N | 0 | ddl |
| 31 | LBR_PRC | FLOAT |  | N | 0 | ddl |
| 32 | LBR_RATE | FLOAT |  | N | 0 | ddl |
| 33 | LBR_TYPE | VARCHAR | 1 | Y |  | ddl |
| 34 | LBR_AMT | FLOAT |  | N | 0 | ddl |
| 35 | OTH_AMT | FLOAT |  | N | 0 | ddl |
| 36 | ITM_RATE | FLOAT |  | N | 0 | ddl |
| 37 | ITM_AMT | FLOAT |  | N | 0 | ddl |
| 38 | TAG_COST | FLOAT |  | N | 0 | ddl |
| 39 | ITM_MRP | FLOAT |  | N | 0 | ddl |
| 40 | ITM_REMARK | VARCHAR | 50 | Y |  | ddl |
| 41 | VCH_SRNO | FLOAT |  | N | 0 | ddl |
| 42 | KR_NET_WT | FLOAT |  | N | 0 | ddl |
| 43 | KR_TOUCH | FLOAT |  | N | 0 | ddl |
| 44 | KR_WEST_PRC | FLOAT |  | N | 0 | ddl |
| 45 | KR_FINE | FLOAT |  | N | 0 | ddl |
| 46 | KR_NAME | VARCHAR | 5 | Y |  | ddl |
| 47 | RATE_TYPE | VARCHAR | 1 | Y |  | ddl |
| 48 | IT_TYPE | VARCHAR | 1 | Y |  | ddl |
| 49 | PR_CODE | VARCHAR | 2 | Y |  | ddl |
| 50 | HD_VCH_NO | VARCHAR | 10 | Y |  | ddl |
| 51 | MAIN_USER | VARCHAR | 15 | Y |  | ddl |
| 52 | ADD_USER | VARCHAR | 15 | Y |  | ddl |
| 53 | DATA_TRFR | VARCHAR | 1 | Y |  | ddl |
| 54 | LOT_TYPE | VARCHAR | 1 | Y |  | ddl |
| 55 | FROM_FAN_CODE | VARCHAR | 2 | Y |  | ddl |
| 56 | TO_VCH_NO | VARCHAR | 10 | Y |  | ddl |
| 57 | TO_CO_BOOK | VARCHAR | 3 | Y |  | ddl |
| 58 | FROM_VCH_NO | VARCHAR | 10 | Y |  | ddl |
| 59 | FROM_CO_BOOK | VARCHAR | 3 | Y |  | ddl |
| 60 | ITM_COLOR | VARCHAR | 15 | Y |  | ddl |
| 61 | HM_ID | VARCHAR | 10 | Y |  | ddl |
| 62 | HM_ID2 | VARCHAR | 10 | Y |  | ddl |
| 63 | HM_ID3 | VARCHAR | 10 | Y |  | ddl |
| 64 | HM_ID4 | VARCHAR | 10 | Y |  | ddl |
| 65 | HM_ID_WT | FLOAT |  | N | 0 | ddl |
| 66 | HM_ID2_WT | FLOAT |  | N | 0 | ddl |
| 67 | HM_ID3_WT | FLOAT |  | N | 0 | ddl |
| 68 | HM_ID4_WT | FLOAT |  | N | 0 | ddl |
| 69 | NET_AMT | FLOAT |  | N | 0 | ddl |
| 70 | EMP_ISU | VARCHAR | 1 | Y | 'N' | ddl |
| 71 | WITH_RFID | VARCHAR | 1 | Y | 'N' | ddl |
| 72 | MAIN_MARGIN_PRC | FLOAT |  | N | 0 | ddl |
| 73 | MAIN_MRP | FLOAT |  | N | 0 | ddl |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
