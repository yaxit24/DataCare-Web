# AC_IMAGE

- **Cluster:** accounting
- **Source:** DDL
- **Columns:** 4
- **Primary key:** (none recovered)
- **Tenant/scope keys present:** CO_CODE, LC_CODE
- **Web mapping:** `tenant_id` + the scope keys above; preserve column names verbatim.

| # | Column | Type | Len | Null | Default | Source |
|---|--------|------|-----|------|---------|--------|
| 1 | CO_CODE ⟨scope⟩ | VARCHAR | 2 | Y |  | ddl |
| 2 | LC_CODE ⟨scope⟩ | VARCHAR | 2 | Y |  | ddl |
| 3 | AC_CODE | VARCHAR | 10 | Y |  | ddl |
| 4 | AC_IMAGE | IMAGE |  | Y |  | ddl |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
