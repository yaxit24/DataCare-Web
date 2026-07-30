# CUST_DATA

- **Cluster:** ancillary
- **Source:** DDL
- **Columns:** 27
- **Primary key:** CO_CODE, LC_CODE, CO_YEAR, CO_BOOK, VCH_NO, SR_NO
- **Tenant/scope keys present:** CO_CODE, LC_CODE, CO_YEAR, CO_BOOK  ·  fully tenant-keyed
- **Web mapping:** `tenant_id` + the scope keys above; preserve column names verbatim.

| # | Column | Type | Len | Null | Default | Source |
|---|--------|------|-----|------|---------|--------|
| 1 | CO_CODE 🔑 ⟨scope⟩ | VARCHAR | 2 | N |  | ddl |
| 2 | LC_CODE 🔑 ⟨scope⟩ | VARCHAR | 2 | N |  | ddl |
| 3 | CO_YEAR 🔑 ⟨scope⟩ | VARCHAR | 9 | N |  | ddl |
| 4 | CO_BOOK 🔑 ⟨scope⟩ | VARCHAR | 5 | N |  | ddl |
| 5 | VCH_NO 🔑 | VARCHAR | 10 | N |  | ddl |
| 6 | SR_NO 🔑 | FLOAT |  | N | 0 | ddl |
| 7 | VCH_DATE | DATE |  | Y |  | ddl |
| 8 | VCH_TIME | DATETIME |  | Y |  | ddl |
| 9 | REM_DATE | DATE |  | Y |  | ddl |
| 10 | REM_TIME | DATETIME |  | Y |  | ddl |
| 11 | AC_CODE | VARCHAR | 8 | Y |  | ddl |
| 12 | CUST_CODE | VARCHAR | 8 | Y |  | ddl |
| 13 | AC_NAME | VARCHAR | 50 | Y |  | ddl |
| 14 | MOBILE_NO | VARCHAR | 13 | Y |  | ddl |
| 15 | TAG_NO | VARCHAR | 15 | Y |  | ddl |
| 16 | VCH_SRNO | FLOAT |  | N | 0 | ddl |
| 17 | IT_CODE | VARCHAR | 6 | Y |  | ddl |
| 18 | IT_NAME | VARCHAR | 50 | Y |  | ddl |
| 19 | ITM_PCS | FLOAT |  | N | 0 | ddl |
| 20 | ITM_GWT | FLOAT |  | N | 0 | ddl |
| 21 | ITM_NWT | FLOAT |  | N | 0 | ddl |
| 22 | ITM_FINE | FLOAT |  | N | 0 | ddl |
| 23 | ITM_BUY | VARCHAR | 1 | Y |  | ddl |
| 24 | ITM_REMARK | VARCHAR | 150 | Y |  | ddl |
| 25 | MAIN_USER | VARCHAR | 15 | Y |  | ddl |
| 26 | EMP_CODE | VARCHAR | 5 | Y |  | ddl |
| 27 | EMP_NAME | VARCHAR | 40 | Y |  | ddl |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
