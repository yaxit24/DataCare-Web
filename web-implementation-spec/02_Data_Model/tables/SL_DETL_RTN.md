# SL_DETL_RTN

- **Cluster:** sales
- **Source:** DDL
- **Columns:** 51
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
| 9 | VCH_TYPE | VARCHAR | 6 | Y |  | ddl |
| 10 | INOUT_TYPE | VARCHAR | 1 | Y |  | ddl |
| 11 | ENTRY_TYPE | VARCHAR | 1 | Y |  | ddl |
| 12 | VCH_TIME | DATETIME |  | Y |  | ddl |
| 13 | BOOK_NAME | VARCHAR | 20 | Y |  | ddl |
| 14 | AC_CODE | VARCHAR | 8 | Y |  | ddl |
| 15 | IT_CODE | VARCHAR | 5 | Y |  | ddl |
| 16 | TAG_NO | VARCHAR | 15 | Y |  | ddl |
| 17 | TBL_CODE | VARCHAR | 3 | Y |  | ddl |
| 18 | DESIGN_NO | VARCHAR | 15 | Y |  | ddl |
| 19 | ITM_SIZE | VARCHAR | 15 | Y |  | ddl |
| 20 | ITM_PCS | FLOAT |  | N | 0 | ddl |
| 21 | ITM_GWT | FLOAT |  | N | 0 | ddl |
| 22 | ITM_OTH_WT | FLOAT |  | N | 0 | ddl |
| 23 | ITM_NWT | FLOAT |  | N | 0 | ddl |
| 24 | ITM_GHT_WT | FLOAT |  | N | 0 | ddl |
| 25 | ITM_TOUCH | FLOAT |  | N | 0 | ddl |
| 26 | ITM_WEST_PRC | FLOAT |  | N | 0 | ddl |
| 27 | ITM_FINE | FLOAT |  | N | 0 | ddl |
| 28 | ITM_RATE | FLOAT |  | N | 0 | ddl |
| 29 | ITM_AMT | FLOAT |  | N | 0 | ddl |
| 30 | LBR_TYPE | VARCHAR | 1 | Y |  | ddl |
| 31 | LBR_PRC | FLOAT |  | N | 0 | ddl |
| 32 | LBR_RATE | FLOAT |  | N | 0 | ddl |
| 33 | LBR_AMT | FLOAT |  | N | 0 | ddl |
| 34 | OTH_AMT | FLOAT |  | N | 0 | ddl |
| 35 | TAG_LBR_PRC | FLOAT |  | N | 0 | ddl |
| 36 | TAG_LBR_RATE | FLOAT |  | N | 0 | ddl |
| 37 | TAG_LBR_AMT | FLOAT |  | N | 0 | ddl |
| 38 | TAG_OTH_AMT | FLOAT |  | N | 0 | ddl |
| 39 | ITM_MRP | FLOAT |  | N | 0 | ddl |
| 40 | TOT_AMT | FLOAT |  | N | 0 | ddl |
| 41 | TAX_PRC | FLOAT |  | N | 0 | ddl |
| 42 | NET_AMT | FLOAT |  | N | 0 | ddl |
| 43 | RATE_TYPE | VARCHAR | 1 | Y |  | ddl |
| 44 | IT_TYPE | VARCHAR | 1 | Y |  | ddl |
| 45 | HD_VCH_NO | VARCHAR | 10 | Y |  | ddl |
| 46 | MAIN_USER | VARCHAR | 15 | Y |  | ddl |
| 47 | DATA_TRFR | VARCHAR | 1 | Y |  | ddl |
| 48 | KR_NAME | VARCHAR | 5 | Y |  | ddl |
| 49 | TAG_COST | FLOAT |  | N | 0 | ddl |
| 50 | ITM_MARGIN | FLOAT |  | N | 0 | ddl |
| 51 | VCH_SRNO | FLOAT |  | N | 0 | ddl |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
