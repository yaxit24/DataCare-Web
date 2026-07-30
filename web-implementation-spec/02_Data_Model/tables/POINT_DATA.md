# POINT_DATA

- **Cluster:** membership
- **Source:** DDL
- **Columns:** 21
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
| 7 | VCH_DATE | DATE |  | Y |  | ddl |
| 8 | VCH_TIME | DATETIME |  | Y |  | ddl |
| 9 | VCH_TYPE | VARCHAR | 6 | Y |  | ddl |
| 10 | INOUT_TYPE | VARCHAR | 1 | Y |  | ddl |
| 11 | BOOK_NAME | VARCHAR | 20 | Y |  | ddl |
| 12 | POINT_CODE | VARCHAR | 2 | Y |  | ddl |
| 13 | POINT_TYPE | VARCHAR | 1 | Y |  | ddl |
| 14 | MEMB_CODE | VARCHAR | 10 | Y |  | ddl |
| 15 | TOT_AMT | FLOAT |  | N | 0 | ddl |
| 16 | POINT_VAL | FLOAT |  | N | 0 | ddl |
| 17 | TOT_POINT | FLOAT |  | N | 0 | ddl |
| 18 | ITM_SIGN | VARCHAR | 1 | Y |  | ddl |
| 19 | REF_CUST | VARCHAR | 10 | Y |  | ddl |
| 20 | REF_NAME | VARCHAR | 50 | Y |  | ddl |
| 21 | MAIN_USER | VARCHAR | 15 | Y |  | ddl |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
