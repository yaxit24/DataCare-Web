# DM_SIZE

- **Cluster:** finance
- **Source:** DDL
- **Columns:** 9
- **Primary key:** CO_CODE, IT_CODE, DM_SIZE
- **Tenant/scope keys present:** CO_CODE
- **Web mapping:** `tenant_id` + the scope keys above; preserve column names verbatim.

| # | Column | Type | Len | Null | Default | Source |
|---|--------|------|-----|------|---------|--------|
| 1 | CO_CODE 🔑 ⟨scope⟩ | VARCHAR | 2 | Y |  | ddl |
| 2 | IT_CODE 🔑 | VARCHAR | 5 | Y |  | ddl |
| 3 | DM_SIZE 🔑 | VARCHAR | 15 | Y |  | ddl |
| 4 | DM_WT | FLOAT |  | N | 0 | ddl |
| 5 | PCS_GHT | FLOAT |  | N | 0 | ddl |
| 6 | PCS_LBR | FLOAT |  | N | 0 | ddl |
| 7 | RATE_TYPE | VARCHAR | 1 | N | 'W' | ddl |
| 8 | DM_RATE | FLOAT |  | N | 0 | ddl |
| 9 | MAIN_USER | VARCHAR | 15 | Y |  | ddl |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
