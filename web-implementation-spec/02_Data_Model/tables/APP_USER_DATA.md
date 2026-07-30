# APP_USER_DATA

- **Cluster:** ancillary
- **Source:** DDL
- **Columns:** 3
- **Primary key:** MEMB_NUMBER
- **Tenant/scope keys present:** (none)
- **Web mapping:** `tenant_id` + the scope keys above; preserve column names verbatim.

| # | Column | Type | Len | Null | Default | Source |
|---|--------|------|-----|------|---------|--------|
| 1 | MEMB_NUMBER 🔑 | VARCHAR | 10 | N |  | ddl |
| 2 | MEMB_NAME | VARCHAR | 50 | Y | '' | ddl |
| 3 | MEMB_EMAIL | VARCHAR | 50 | Y | '' | ddl |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
