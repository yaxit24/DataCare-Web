# TAG_SET

- **Cluster:** inventory
- **Source:** DDL
- **Columns:** 8
- **Primary key:** CO_CODE, LC_CODE, TAG_NO
- **Tenant/scope keys present:** CO_CODE, LC_CODE, CO_BOOK
- **Web mapping:** `tenant_id` + the scope keys above; preserve column names verbatim.

| # | Column | Type | Len | Null | Default | Source |
|---|--------|------|-----|------|---------|--------|
| 1 | CO_CODE 🔑 ⟨scope⟩ | VARCHAR | 2 | Y |  | ddl |
| 2 | LC_CODE 🔑 ⟨scope⟩ | VARCHAR | 2 | Y |  | ddl |
| 3 | CO_BOOK ⟨scope⟩ | VARCHAR | 3 | Y |  | ddl |
| 4 | VCH_NO | VARCHAR | 8 | Y |  | ddl |
| 5 | TAG_NO 🔑 | VARCHAR | 10 | Y |  | ddl |
| 6 | VCH_SRNO | FLOAT |  | N | 0 | ddl |
| 7 | TAG_TYPE | VARCHAR | 1 | Y |  | ddl |
| 8 | PR_CODE | VARCHAR | 2 | Y |  | ddl |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
