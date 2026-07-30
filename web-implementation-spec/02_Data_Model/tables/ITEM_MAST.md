# ITEM_MAST

- **Cluster:** masters
- **Source:** DDL
- **Columns:** 13
- **Primary key:** CO_CODE, IT_CODE
- **Tenant/scope keys present:** CO_CODE
- **Web mapping:** `tenant_id` + the scope keys above; preserve column names verbatim.

| # | Column | Type | Len | Null | Default | Source |
|---|--------|------|-----|------|---------|--------|
| 1 | CO_CODE 🔑 ⟨scope⟩ | VARCHAR | 2 | N |  | ddl |
| 2 | IT_CODE 🔑 | VARCHAR | 5 | N |  | ddl |
| 3 | IT_NAME | VARCHAR | 50 | Y |  | ddl |
| 4 | IT_TYPE | VARCHAR | 1 | Y |  | ddl |
| 5 | PR_CODE | VARCHAR | 2 | Y |  | ddl |
| 6 | GR_CODE | VARCHAR | 3 | Y |  | ddl |
| 7 | RATE_TYPE | VARCHAR | 1 | Y |  | ddl |
| 8 | LBR_PRC | FLOAT |  | N | 0 | ddl |
| 9 | IT_TOUCH | FLOAT |  | N | 0 | ddl |
| 10 | IT_WEST | FLOAT |  | N | 0 | ddl |
| 11 | OTH_RATE | FLOAT |  | N | 0 | ddl |
| 12 | IT_LBR_RATE | FLOAT |  | N | 0 | ddl |
| 13 | IT_GHT_PRC | FLOAT |  | N | 0 | ddl |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
