# USER_MAST

- **Cluster:** masters
- **Source:** DDL
- **Columns:** 2
- **Primary key:** TBL_COL_NAME, COL_NAME
- **Tenant/scope keys present:** (none)
- **Web mapping:** `tenant_id` + the scope keys above; preserve column names verbatim.

| # | Column | Type | Len | Null | Default | Source |
|---|--------|------|-----|------|---------|--------|
| 1 | TBL_COL_NAME 🔑 | VARCHAR | 20 | Y |  | ddl |
| 2 | COL_NAME 🔑 | VARCHAR | 20 | Y |  | ddl |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
