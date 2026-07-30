# POINT_MAST

- **Cluster:** membership
- **Source:** DDL
- **Columns:** 13
- **Primary key:** CO_CODE, POINT_CODE, SR_NO
- **Tenant/scope keys present:** CO_CODE
- **Web mapping:** `tenant_id` + the scope keys above; preserve column names verbatim.

| # | Column | Type | Len | Null | Default | Source |
|---|--------|------|-----|------|---------|--------|
| 1 | CO_CODE 🔑 ⟨scope⟩ | VARCHAR | 2 | Y |  | ddl |
| 2 | POINT_CODE 🔑 | VARCHAR | 2 | Y |  | ddl |
| 3 | SR_NO 🔑 | FLOAT |  | N | 0 | ddl |
| 4 | POINT_NAME | VARCHAR | 30 | Y |  | ddl |
| 5 | POINT_TYPE | VARCHAR | 1 | Y |  | ddl |
| 6 | FIX_POINT | FLOAT |  | N | 0 | ddl |
| 7 | SL_AMT | FLOAT |  | N | 0 | ddl |
| 8 | SL_POINT | FLOAT |  | N | 0 | ddl |
| 9 | POINT_AMT | FLOAT |  | N | 0 | ddl |
| 10 | MIN_POINT | FLOAT |  | N | 0 | ddl |
| 11 | GRM_POINT | FLOAT |  | N | 0 | ddl |
| 12 | MAIN_USER | VARCHAR | 15 | Y |  | ddl |
| 13 | DATA_TRFR | VARCHAR | 1 | Y | 'N' | ddl |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
