# COL_MAST

- **Cluster:** masters
- **Source:** code-recovered
- **Columns:** 6
- **Primary key:** (none recovered)
- **Tenant/scope keys present:** CO_CODE
- **Web mapping:** `tenant_id` + the scope keys above; preserve column names verbatim.

| # | Column | Type | Len | Null | Default | Source |
|---|--------|------|-----|------|---------|--------|
| 1 | CO_CODE ⟨scope⟩ | VARCHAR | 2 | Y |  | code+inferred-type |
| 2 | BOOK_NAME | VARCHAR | 20 | Y |  | code+inferred-type |
| 3 | COL_NAME | VARCHAR | 20 | Y |  | code+inferred-type |
| 4 | COL_NEW_NAME | unknown |  | Y |  | code |
| 5 | COL_RPT | unknown |  | Y |  | code |
| 6 | YES_NO | unknown |  | Y |  | code |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
