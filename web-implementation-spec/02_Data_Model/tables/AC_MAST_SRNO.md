# AC_MAST_SRNO

- **Cluster:** accounting
- **Source:** code-recovered
- **Columns:** 6
- **Primary key:** (none recovered)
- **Tenant/scope keys present:** CO_CODE, LC_CODE
- **Web mapping:** `tenant_id` + the scope keys above; preserve column names verbatim.

| # | Column | Type | Len | Null | Default | Source |
|---|--------|------|-----|------|---------|--------|
| 1 | CO_CODE ⟨scope⟩ | VARCHAR | 2 | Y |  | code+inferred-type |
| 2 | LC_CODE ⟨scope⟩ | VARCHAR | 2 | Y |  | code+inferred-type |
| 3 | AC_CODE | VARCHAR | 8 | Y |  | code+inferred-type |
| 4 | AC_NAME | VARCHAR | 50 | Y |  | code+inferred-type |
| 5 | AC_GR | unknown |  | Y |  | code |
| 6 | MAIN_USER | VARCHAR | 15 | Y |  | code+inferred-type |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
