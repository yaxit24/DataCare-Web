# ROJMEL_BAL

- **Cluster:** ancillary
- **Source:** DDL
- **Columns:** 5
- **Primary key:** CO_CODE, LC_CODE, VCH_DATE
- **Tenant/scope keys present:** CO_CODE, LC_CODE
- **Web mapping:** `tenant_id` + the scope keys above; preserve column names verbatim.

| # | Column | Type | Len | Null | Default | Source |
|---|--------|------|-----|------|---------|--------|
| 1 | CO_CODE 🔑 ⟨scope⟩ | VARCHAR | 2 | Y |  | ddl |
| 2 | LC_CODE 🔑 ⟨scope⟩ | VARCHAR | 2 | Y |  | ddl |
| 3 | VCH_DATE 🔑 | DATE |  | Y |  | ddl |
| 4 | MAIN_USER | VARCHAR | 15 | Y |  | ddl |
| 5 | CLOSING_CASH | FLOAT |  | N | 0 | ddl |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
