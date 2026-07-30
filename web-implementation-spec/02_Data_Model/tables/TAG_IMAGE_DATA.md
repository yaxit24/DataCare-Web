# TAG_IMAGE_DATA

- **Cluster:** inventory
- **Source:** DDL
- **Columns:** 5
- **Primary key:** CO_CODE, LC_CODE, TAG_NO, VCH_SRNO
- **Tenant/scope keys present:** CO_CODE, LC_CODE
- **Web mapping:** `tenant_id` + the scope keys above; preserve column names verbatim.

| # | Column | Type | Len | Null | Default | Source |
|---|--------|------|-----|------|---------|--------|
| 1 | CO_CODE 🔑 ⟨scope⟩ | VARCHAR | 2 | N |  | ddl |
| 2 | LC_CODE 🔑 ⟨scope⟩ | VARCHAR | 2 | N |  | ddl |
| 3 | TAG_NO 🔑 | VARCHAR | 20 | N |  | ddl |
| 4 | VCH_SRNO 🔑 | FLOAT |  | Y | 0 | ddl |
| 5 | IMAGE_TYPE | VARCHAR | 1 | Y | 'T' | ddl |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
