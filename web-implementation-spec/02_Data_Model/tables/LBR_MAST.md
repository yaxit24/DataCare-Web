# LBR_MAST

- **Cluster:** masters
- **Source:** DDL
- **Columns:** 5
- **Primary key:** CO_CODE, LBR_CODE
- **Tenant/scope keys present:** CO_CODE
- **Web mapping:** `tenant_id` + the scope keys above; preserve column names verbatim.

| # | Column | Type | Len | Null | Default | Source |
|---|--------|------|-----|------|---------|--------|
| 1 | CO_CODE 🔑 ⟨scope⟩ | VARCHAR | 2 | Y |  | ddl |
| 2 | LBR_CATG | VARCHAR | 25 | Y |  | ddl |
| 3 | LBR_CODE 🔑 | VARCHAR | 2 | Y |  | ddl |
| 4 | LBR_VAL | FLOAT |  | N | 0 | ddl |
| 5 | MAIN_USER | VARCHAR | 15 | Y |  | ddl |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
