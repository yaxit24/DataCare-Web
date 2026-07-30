# CUST_DETL

- **Cluster:** ancillary
- **Source:** DDL
- **Columns:** 14
- **Primary key:** CO_CODE, LC_CODE, CO_YEAR, CO_BOOK, VCH_NO, SR_NO, ISR_NO
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
| 7 | ISR_NO 🔑 | FLOAT |  | N | 0 | ddl |
| 8 | REM_DATE | DATE |  | Y |  | ddl |
| 9 | REM_TIME | DATETIME |  | Y |  | ddl |
| 10 | ITM_REMARK | VARCHAR | 150 | Y |  | ddl |
| 11 | MAIN_USER | VARCHAR | 15 | Y |  | ddl |
| 12 | EMP_CODE | VARCHAR | 5 | Y |  | ddl |
| 13 | ITM_SALE | VARCHAR | 1 | Y |  | ddl |
| 14 | REM_CLOSE | VARCHAR | 1 | Y |  | ddl |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
