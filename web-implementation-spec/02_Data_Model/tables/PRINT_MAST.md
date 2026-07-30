# PRINT_MAST

- **Cluster:** masters
- **Source:** code-recovered
- **Columns:** 5
- **Primary key:** (none recovered)
- **Tenant/scope keys present:** CO_CODE
- **Web mapping:** `tenant_id` + the scope keys above; preserve column names verbatim.

| # | Column | Type | Len | Null | Default | Source |
|---|--------|------|-----|------|---------|--------|
| 1 | PRINT_SET_A | unknown |  | Y |  | code |
| 2 | CO_CODE ⟨scope⟩ | VARCHAR | 2 | Y |  | code+inferred-type |
| 3 | PRINT_TYPE | unknown |  | Y |  | code |
| 4 | PRINT_FILE | unknown |  | Y |  | code |
| 5 | BOOK_TYPE | unknown |  | Y |  | code |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
