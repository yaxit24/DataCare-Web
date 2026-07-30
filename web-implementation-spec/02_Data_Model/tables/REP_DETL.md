# REP_DETL

- **Cluster:** manufacturing
- **Source:** DDL
- **Columns:** 62
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
| 15 | IT_CODE | VARCHAR | 8 | Y |  | ddl |
| 16 | IT_NAME | VARCHAR | 50 | Y |  | ddl |
| 17 | IT_DESC | VARCHAR | 200 | Y |  | ddl |
| 18 | ITM_SIZE | VARCHAR | 15 | Y |  | ddl |
| 19 | TAG_NO | VARCHAR | 15 | Y |  | ddl |
| 20 | DESIGN_NO | VARCHAR | 15 | Y |  | ddl |
| 21 | VCH_SRNO | FLOAT |  | N | 0 | ddl |
| 22 | ITM_PCS | FLOAT |  | N | 0 | ddl |
| 23 | ITM_GWT | FLOAT |  | N | 0 | ddl |
| 24 | ITM_OTH_WT | FLOAT |  | N | 0 | ddl |
| 25 | ADD_WT | FLOAT |  | N | 0 | ddl |
| 26 | LESS_WT | FLOAT |  | N | 0 | ddl |
| 27 | ITM_NWT | FLOAT |  | N | 0 | ddl |
| 28 | ITM_TOUCH | FLOAT |  | N | 0 | ddl |
| 29 | ITM_WEST | FLOAT |  | N | 0 | ddl |
| 30 | ITM_FINE | FLOAT |  | N | 0 | ddl |
| 31 | LESS_FINE | FLOAT |  | N | 0 | ddl |
| 32 | ITM_RATE | FLOAT |  | N | 0 | ddl |
| 33 | ITM_AMT | FLOAT |  | N | 0 | ddl |
| 34 | LBR_TYPE | VARCHAR | 1 | Y | 'G' | ddl |
| 35 | LBR_RATE | FLOAT |  | N | 0 | ddl |
| 36 | LBR_AMT | FLOAT |  | N | 0 | ddl |
| 37 | RATE_TYPE | VARCHAR | 1 | Y |  | ddl |
| 38 | IT_TYPE | VARCHAR | 1 | Y | 'G' | ddl |
| 39 | OTH_AMT | FLOAT |  | N | 0 | ddl |
| 40 | NET_AMT | FLOAT |  | N | 0 | ddl |
| 41 | REP_NO | VARCHAR | 8 | Y |  | ddl |
| 42 | REP_SRNO | FLOAT |  | N | 0 | ddl |
| 43 | REP_LC | VARCHAR | 2 | Y |  | ddl |
| 44 | REP_YRCD | VARCHAR | 10 | Y |  | ddl |
| 45 | REP_DBCD | VARCHAR | 3 | Y |  | ddl |
| 46 | REP_AC_CODE | VARCHAR | 8 | Y |  | ddl |
| 47 | REP_AC_NAME | VARCHAR | 50 | Y |  | ddl |
| 48 | REP_HD_VCH_NO | VARCHAR | 8 | Y |  | ddl |
| 49 | REP_ADJ | VARCHAR | 1 | Y | 'N' | ddl |
| 50 | ISU_NO | VARCHAR | 8 | Y |  | ddl |
| 51 | ISU_SRNO | FLOAT |  | N | 0 | ddl |
| 52 | ISU_LC | VARCHAR | 2 | Y |  | ddl |
| 53 | ISU_YRCD | VARCHAR | 10 | Y |  | ddl |
| 54 | ISU_DBCD | VARCHAR | 3 | Y |  | ddl |
| 55 | ISU_AC_CODE | VARCHAR | 8 | Y |  | ddl |
| 56 | ISU_AC_NAME | VARCHAR | 50 | Y |  | ddl |
| 57 | ISU_HD_VCH_NO | VARCHAR | 8 | Y |  | ddl |
| 58 | ISU_ADJ | VARCHAR | 1 | Y | 'N' | ddl |
| 59 | HD_VCH_NO | VARCHAR | 10 | Y |  | ddl |
| 60 | EMP_CODE | VARCHAR | 5 | Y |  | ddl |
| 61 | DATA_TRFR | VARCHAR | 1 | Y |  | ddl |
| 62 | MAIN_USER | VARCHAR | 15 | Y |  | ddl |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
