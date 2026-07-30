# MSG_MAST

- **Cluster:** masters
- **Source:** DDL
- **Columns:** 4
- **Primary key:** CO_CODE, MSG_TYPE, MSG_TYPING
- **Tenant/scope keys present:** CO_CODE
- **Web mapping:** `tenant_id` + the scope keys above; preserve column names verbatim.

| # | Column | Type | Len | Null | Default | Source |
|---|--------|------|-----|------|---------|--------|
| 1 | CO_CODE 🔑 ⟨scope⟩ | VARCHAR | 2 | Y |  | ddl |
| 2 | MSG_TYPE 🔑 | VARCHAR | 1 | Y |  | ddl |
| 3 | MSG_TYPING 🔑 | VARCHAR | 1 | Y |  | ddl |
| 4 | MSG_DETL | NVARCHAR | 500 | Y |  | ddl |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
