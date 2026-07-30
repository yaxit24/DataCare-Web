# DHRN_REC_DETL

- **Cluster:** dhrn
- **Source:** DDL
- **Columns:** 38
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
| 16 | IT_NAME | VARCHAR | 100 | Y |  | ddl |
| 17 | IT_DESC | VARCHAR | 50 | Y |  | ddl |
| 18 | ITM_PCS | FLOAT |  | N | 0 | ddl |
| 19 | REC_QTY | FLOAT |  | N | 0 | ddl |
| 20 | ITM_GWT | FLOAT |  | N | 0 | ddl |
| 21 | ITM_OTH_WT | FLOAT |  | N | 0 | ddl |
| 22 | ITM_NWT | FLOAT |  | N | 0 | ddl |
| 23 | REC_NWT | FLOAT |  | N | 0 | ddl |
| 24 | ITM_TOUCH | FLOAT |  | N | 0 | ddl |
| 25 | ITM_WEST_PRC | FLOAT |  | N | 0 | ddl |
| 26 | ITM_FINE | FLOAT |  | N | 0 | ddl |
| 27 | ITM_RATE | FLOAT |  | N | 0 | ddl |
| 28 | ITM_AMT | FLOAT |  | N | 0 | ddl |
| 29 | NET_AMT | FLOAT |  | N | 0 | ddl |
| 30 | ISU_NO | VARCHAR | 10 | Y |  | ddl |
| 31 | ISU_LC | VARCHAR | 2 | Y |  | ddl |
| 32 | ISU_YRCD | VARCHAR | 9 | Y |  | ddl |
| 33 | ISU_DBCD | VARCHAR | 3 | Y |  | ddl |
| 34 | RATE_TYPE | VARCHAR | 1 | Y |  | ddl |
| 35 | IT_TYPE | VARCHAR | 1 | Y |  | ddl |
| 36 | HD_VCH_NO | VARCHAR | 10 | Y |  | ddl |
| 37 | MAIN_USER | VARCHAR | 15 | Y |  | ddl |
| 38 | DATA_TRFR | VARCHAR | 1 | Y |  | ddl |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
