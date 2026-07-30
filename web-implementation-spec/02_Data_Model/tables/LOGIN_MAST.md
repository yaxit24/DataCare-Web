# LOGIN_MAST

- **Cluster:** masters
- **Source:** code-recovered
- **Columns:** 5
- **Primary key:** (none recovered)
- **Tenant/scope keys present:** CO_CODE
- **Web mapping:** `tenant_id` + the scope keys above; preserve column names verbatim.

| # | Column | Type | Len | Null | Default | Source |
|---|--------|------|-----|------|---------|--------|
| 1 | CO_CODE ⟨scope⟩ | VARCHAR | 2 | Y |  | code+inferred-type |
| 2 | LOGIN_NAME | unknown |  | Y |  | code |
| 3 | LOGIN_PWD | unknown |  | Y |  | code |
| 4 | LOGIN_CATG | unknown |  | Y |  | code |
| 5 | MAIN_USER | VARCHAR | 15 | Y |  | code+inferred-type |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
