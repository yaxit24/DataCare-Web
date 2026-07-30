# TILE_DATA

- **Cluster:** ancillary
- **Source:** DDL
- **Columns:** 6
- **Primary key:** SM_MAIN_NAME
- **Tenant/scope keys present:** (none)
- **Web mapping:** `tenant_id` + the scope keys above; preserve column names verbatim.

| # | Column | Type | Len | Null | Default | Source |
|---|--------|------|-----|------|---------|--------|
| 1 | SM_MAIN_NAME 🔑 | VARCHAR | 25 | Y |  | ddl |
| 2 | SR_NO | VARCHAR | 2 | Y |  | ddl |
| 3 | DISPLAY_NAME | VARCHAR | 25 | Y |  | ddl |
| 4 | SHORT_NAME | VARCHAR | 25 | Y |  | ddl |
| 5 | TILE_NAME | VARCHAR | 10 | Y |  | ddl |
| 6 | ITM_SHOW | VARCHAR | 1 | Y |  | ddl |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
