# DM_MAST

- **Cluster:** finance
- **Source:** DDL
- **Columns:** 11
- **Primary key:** CO_CODE, DM_CODE
- **Tenant/scope keys present:** CO_CODE
- **Web mapping:** `tenant_id` + the scope keys above; preserve column names verbatim.

| # | Column | Type | Len | Null | Default | Source |
|---|--------|------|-----|------|---------|--------|
| 1 | CO_CODE 🔑 ⟨scope⟩ | VARCHAR | 2 | Y |  | ddl |
| 2 | DM_CODE 🔑 | VARCHAR | 8 | Y |  | ddl |
| 3 | DM_NAME | VARCHAR | 50 | Y |  | ddl |
| 4 | GR_CODE | VARCHAR | 3 | Y |  | ddl |
| 5 | DM_SHAPE | VARCHAR | 20 | Y |  | ddl |
| 6 | DM_CLARITY | VARCHAR | 20 | Y |  | ddl |
| 7 | SL_RATE | FLOAT |  | N | 0 | ddl |
| 8 | PR_RATE | FLOAT |  | N | 0 | ddl |
| 9 | SALE_AC | VARCHAR | 10 | Y |  | ddl |
| 10 | PURC_AC | VARCHAR | 10 | Y |  | ddl |
| 11 | MAIN_USER | VARCHAR | 15 | Y |  | ddl |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
