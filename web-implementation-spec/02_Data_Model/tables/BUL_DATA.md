# BUL_DATA

- **Cluster:** bullion_tour
- **Source:** DDL
- **Columns:** 31
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
| 16 | ITM_GWT | FLOAT |  | N | 0 | ddl |
| 17 | ITM_NWT | FLOAT |  | N | 0 | ddl |
| 18 | ADJ_WT | FLOAT |  | N | 0 | ddl |
| 19 | IT_TYPE | VARCHAR | 1 | Y |  | ddl |
| 20 | ITM_RATE | FLOAT |  | N | 0 | ddl |
| 21 | ITM_AMT | FLOAT |  | N | 0 | ddl |
| 22 | AMT_TYPE | VARCHAR | 1 | Y |  | ddl |
| 23 | PRM_AMT | FLOAT |  | N | 0 | ddl |
| 24 | TAX_PRC | FLOAT |  | N | 0 | ddl |
| 25 | TOT_AMT | FLOAT |  | N | 0 | ddl |
| 26 | RATE_TYPE | VARCHAR | 1 | Y |  | ddl |
| 27 | HD_VCH_NO | VARCHAR | 8 | Y |  | ddl |
| 28 | IT_DESC | VARCHAR | 100 | Y |  | ddl |
| 29 | MAIN_USER | VARCHAR | 15 | Y |  | ddl |
| 30 | DATA_TRFR | VARCHAR | 1 | Y |  | ddl |
| 31 | DATA_TYPE | VARCHAR | 1 | Y |  | ddl |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
