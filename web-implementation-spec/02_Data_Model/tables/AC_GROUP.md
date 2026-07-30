# AC_GROUP

- **Cluster:** accounting
- **Source:** code-recovered
- **Columns:** 7
- **Primary key:** (none recovered)
- **Tenant/scope keys present:** CO_CODE
- **Web mapping:** `tenant_id` + the scope keys above; preserve column names verbatim.

| # | Column | Type | Len | Null | Default | Source |
|---|--------|------|-----|------|---------|--------|
| 1 | USER_SHOW_GROUP | unknown |  | Y |  | code |
| 2 | CO_CODE ⟨scope⟩ | VARCHAR | 2 | Y |  | code+inferred-type |
| 3 | AC_GR | unknown |  | Y |  | code |
| 4 | AC_GR_NAME | unknown |  | Y |  | code |
| 5 | AC_MAIN_GR | unknown |  | Y |  | code |
| 6 | AC_SUB_GR | unknown |  | Y |  | code |
| 7 | MAIN_USER | VARCHAR | 15 | Y |  | code+inferred-type |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
