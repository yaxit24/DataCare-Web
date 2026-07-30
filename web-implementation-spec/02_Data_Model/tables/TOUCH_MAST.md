# TOUCH_MAST

- **Cluster:** inventory
- **Source:** DDL
- **Columns:** 12
- **Primary key:** CO_CODE, LC_CODE, AC_CODE, AC_IT_CODE
- **Tenant/scope keys present:** CO_CODE, LC_CODE
- **Web mapping:** `tenant_id` + the scope keys above; preserve column names verbatim.

| # | Column | Type | Len | Null | Default | Source |
|---|--------|------|-----|------|---------|--------|
| 1 | CO_CODE 🔑 ⟨scope⟩ | VARCHAR | 2 | Y |  | ddl |
| 2 | LC_CODE 🔑 ⟨scope⟩ | VARCHAR | 2 | Y |  | ddl |
| 3 | AC_CODE 🔑 | VARCHAR | 8 | Y |  | ddl |
| 4 | AC_IT_CODE 🔑 | VARCHAR | 5 | Y |  | ddl |
| 5 | AC_TOUCH | FLOAT |  | Y | 0 | ddl |
| 6 | AC_WEST | FLOAT |  | Y | 0 | ddl |
| 7 | AC_GHAT_PRC | FLOAT |  | Y | 0 | ddl |
| 8 | AC_LBR_PRC | FLOAT |  | Y | 0 | ddl |
| 9 | AC_LBR_RATE | FLOAT |  | Y | 0 | ddl |
| 10 | AC_RATE | FLOAT |  | Y | 0 | ddl |
| 11 | AC_LBR_TYPE | VARCHAR | 1 | Y |  | ddl |
| 12 | MAIN_USER | VARCHAR | 15 | Y |  | ddl |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
