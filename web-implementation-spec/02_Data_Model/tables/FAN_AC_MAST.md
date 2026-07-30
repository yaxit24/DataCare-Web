# FAN_AC_MAST

- **Cluster:** masters
- **Source:** DDL
- **Columns:** 4
- **Primary key:** CO_CODE, FAN_CO_CODE
- **Tenant/scope keys present:** CO_CODE
- **Web mapping:** `tenant_id` + the scope keys above; preserve column names verbatim.

| # | Column | Type | Len | Null | Default | Source |
|---|--------|------|-----|------|---------|--------|
| 1 | CO_CODE 🔑 ⟨scope⟩ | VARCHAR | 2 | Y |  | ddl |
| 2 | FAN_CO_CODE 🔑 | VARCHAR | 2 | Y |  | ddl |
| 3 | FAN_AC_CODE | VARCHAR | 10 | Y |  | ddl |
| 4 | FAN_CO_NAME | VARCHAR | 50 | Y |  | ddl |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
