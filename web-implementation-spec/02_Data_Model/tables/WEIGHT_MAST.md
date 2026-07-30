# WEIGHT_MAST

- **Cluster:** masters
- **Source:** DDL
- **Columns:** 4
- **Primary key:** (none recovered)
- **Tenant/scope keys present:** (none)
- **Web mapping:** `tenant_id` + the scope keys above; preserve column names verbatim.

| # | Column | Type | Len | Null | Default | Source |
|---|--------|------|-----|------|---------|--------|
| 1 | SR_NO | FLOAT |  | Y |  | ddl |
| 2 | LOW_WT | FLOAT |  | Y |  | ddl |
| 3 | HIGH_WT | FLOAT |  | Y |  | ddl |
| 4 | COL_NAME | VARCHAR | 20 | Y |  | ddl |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
