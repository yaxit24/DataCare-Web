# WEB_DATA

- **Cluster:** ancillary
- **Source:** DDL
- **Columns:** 16
- **Primary key:** CO_CODE, LC_CODE, CO_YEAR, CO_BOOK, VCH_NO, SR_NO
- **Tenant/scope keys present:** CO_CODE, LC_CODE, CO_YEAR, CO_BOOK  ·  fully tenant-keyed
- **Web mapping:** `tenant_id` + the scope keys above; preserve column names verbatim.

| # | Column | Type | Len | Null | Default | Source |
|---|--------|------|-----|------|---------|--------|
| 1 | CO_CODE 🔑 ⟨scope⟩ | VARCHAR | 2 | Y |  | ddl |
| 2 | LC_CODE 🔑 ⟨scope⟩ | VARCHAR | 2 | Y |  | ddl |
| 3 | CO_YEAR 🔑 ⟨scope⟩ | VARCHAR | 9 | Y |  | ddl |
| 4 | CO_BOOK 🔑 ⟨scope⟩ | VARCHAR | 3 | Y |  | ddl |
| 5 | VCH_NO 🔑 | VARCHAR | 8 | Y |  | ddl |
| 6 | SR_NO 🔑 | FLOAT |  | N | 0 | ddl |
| 7 | VCH_DATE | DATE |  | Y |  | ddl |
| 8 | AC_CODE | VARCHAR | 10 | Y |  | ddl |
| 9 | AC_NAME | VARCHAR | 50 | Y |  | ddl |
| 10 | TOT_AMT | FLOAT |  | N | 0 | ddl |
| 11 | TOT_FINE | FLOAT |  | N | 0 | ddl |
| 12 | ITM_TYPE | VARCHAR | 1 | Y |  | ddl |
| 13 | REC_AMT | FLOAT |  | N | 0 | ddl |
| 14 | REC_FINE | FLOAT |  | N | 0 | ddl |
| 15 | EMP_CODE | VARCHAR | 5 | Y |  | ddl |
| 16 | USER_NAME | VARCHAR | 15 | Y |  | ddl |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
