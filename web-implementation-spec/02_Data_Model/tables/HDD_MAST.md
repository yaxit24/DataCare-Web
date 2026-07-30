# HDD_MAST

- **Cluster:** masters
- **Source:** DDL
- **Columns:** 1
- **Primary key:** (none recovered)
- **Tenant/scope keys present:** (none)
- **Web mapping:** `tenant_id` + the scope keys above; preserve column names verbatim.

| # | Column | Type | Len | Null | Default | Source |
|---|--------|------|-----|------|---------|--------|
| 1 | REF_NO | VARCHAR | 10 | Y |  | ddl |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
