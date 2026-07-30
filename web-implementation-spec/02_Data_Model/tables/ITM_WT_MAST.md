# ITM_WT_MAST

- **Cluster:** inventory
- **Source:** DDL
- **Columns:** 9
- **Primary key:** CO_CODE, IT_CODE, SR_NO
- **Tenant/scope keys present:** CO_CODE
- **Web mapping:** `tenant_id` + the scope keys above; preserve column names verbatim.

| # | Column | Type | Len | Null | Default | Source |
|---|--------|------|-----|------|---------|--------|
| 1 | CO_CODE 🔑 ⟨scope⟩ | VARCHAR | 2 | Y |  | ddl |
| 2 | IT_CODE 🔑 | VARCHAR | 5 | Y |  | ddl |
| 3 | SR_NO 🔑 | FLOAT |  | N | 0 | ddl |
| 4 | FROM_WT | FLOAT |  | N | 0 | ddl |
| 5 | TO_WT | FLOAT |  | N | 0 | ddl |
| 6 | MIN_PCS | FLOAT |  | N | 0 | ddl |
| 7 | LBR_RATE | FLOAT |  | N | 0 | ddl |
| 8 | LBR_PRC | FLOAT |  | N | 0 | ddl |
| 9 | LBR_TYPE | VARCHAR | 1 | Y |  | ddl |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
