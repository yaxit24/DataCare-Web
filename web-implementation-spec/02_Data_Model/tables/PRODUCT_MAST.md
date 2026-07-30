# PRODUCT_MAST

- **Cluster:** masters
- **Source:** code-recovered
- **Columns:** 5
- **Primary key:** (none recovered)
- **Tenant/scope keys present:** CO_CODE
- **Web mapping:** `tenant_id` + the scope keys above; preserve column names verbatim.

| # | Column | Type | Len | Null | Default | Source |
|---|--------|------|-----|------|---------|--------|
| 1 | CO_CODE ⟨scope⟩ | VARCHAR | 2 | Y |  | code+inferred-type |
| 2 | PR_CODE | VARCHAR | 2 | Y |  | code+inferred-type |
| 3 | PR_NAME | VARCHAR | 40 | Y |  | code+inferred-type |
| 4 | MAIN_USER | VARCHAR | 15 | Y |  | code+inferred-type |
| 5 | DATA_TRFR | VARCHAR | 1 | Y |  | code+inferred-type |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
