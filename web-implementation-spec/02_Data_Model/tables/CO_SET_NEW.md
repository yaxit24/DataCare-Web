# CO_SET_NEW

- **Cluster:** masters
- **Source:** DDL
- **Columns:** 2
- **Primary key:** CO_CODE
- **Tenant/scope keys present:** CO_CODE
- **Web mapping:** `tenant_id` + the scope keys above; preserve column names verbatim.

| # | Column | Type | Len | Null | Default | Source |
|---|--------|------|-----|------|---------|--------|
| 1 | CO_CODE 🔑 ⟨scope⟩ | VARCHAR | 2 | N | '00' | ddl |
| 2 | COUNTER_STK | VARCHAR | 1 | Y | 'N' | ddl |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
