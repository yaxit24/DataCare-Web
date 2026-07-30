# CUT_STK_DETL

- **Cluster:** ancillary
- **Source:** DDL
- **Columns:** 54
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
| 15 | IT_CODE | VARCHAR | 5 | Y |  | ddl |
| 16 | TAG_NO | VARCHAR | 15 | Y |  | ddl |
| 17 | LOT_NO | VARCHAR | 15 | Y |  | ddl |
| 18 | DESIGN_NO | VARCHAR | 15 | Y |  | ddl |
| 19 | TBL_CODE | VARCHAR | 3 | Y |  | ddl |
| 20 | ITM_SIZE | VARCHAR | 20 | Y |  | ddl |
| 21 | ITM_PCS | FLOAT |  | N | 0 | ddl |
| 22 | ITM_GWT | FLOAT |  | N | 0 | ddl |
| 23 | ITM_OTH_WT | FLOAT |  | N | 0 | ddl |
| 24 | ITM_NWT | FLOAT |  | N | 0 | ddl |
| 25 | ITM_GHT_WT | FLOAT |  | N | 0 | ddl |
| 26 | ITM_TOUCH | FLOAT |  | N | 0 | ddl |
| 27 | ITM_WEST_PRC | FLOAT |  | N | 0 | ddl |
| 28 | ITM_FINE | FLOAT |  | N | 0 | ddl |
| 29 | STK_PCS | FLOAT |  | N | 0 | ddl |
| 30 | STK_GWT | FLOAT |  | N | 0 | ddl |
| 31 | STK_NWT | FLOAT |  | N | 0 | ddl |
| 32 | STK_FINE | FLOAT |  | N | 0 | ddl |
| 33 | VCH_SRNO | FLOAT |  | N | 0 | ddl |
| 34 | STK_IT_CODE | VARCHAR | 5 | Y |  | ddl |
| 35 | SL_NO | VARCHAR | 8 | Y |  | ddl |
| 36 | SL_LC_CODE | VARCHAR | 2 | Y |  | ddl |
| 37 | SL_YRCD | VARCHAR | 10 | Y |  | ddl |
| 38 | SL_DBCD | VARCHAR | 3 | Y |  | ddl |
| 39 | SL_SRNO | FLOAT |  | N | 0 | ddl |
| 40 | LOT_TYPE | VARCHAR | 1 | Y |  | ddl |
| 41 | HM_ID | VARCHAR | 10 | Y |  | ddl |
| 42 | HM_ID2 | VARCHAR | 10 | Y |  | ddl |
| 43 | HM_ID3 | VARCHAR | 10 | Y |  | ddl |
| 44 | HM_ID4 | VARCHAR | 10 | Y |  | ddl |
| 45 | HM_ID_WT | FLOAT |  | N | 0 | ddl |
| 46 | HM_ID2_WT | FLOAT |  | N | 0 | ddl |
| 47 | HM_ID3_WT | FLOAT |  | N | 0 | ddl |
| 48 | HM_ID4_WT | FLOAT |  | N | 0 | ddl |
| 49 | MAIN_USER | VARCHAR | 15 | Y |  | ddl |
| 50 | DATA_TRFR | VARCHAR | 1 | Y |  | ddl |
| 51 | SL_DATE | DATE |  | Y |  | ddl |
| 52 | STK_NET_AMT | FLOAT |  | N | 0 | ddl |
| 53 | STK_ITM_RATE | FLOAT |  | N | 0 | ddl |
| 54 | STK_ITM_AMT | FLOAT |  | N | 0 | ddl |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
