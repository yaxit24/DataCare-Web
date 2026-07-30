# TEMP_BOOK_DATA

- **Cluster:** ancillary
- **Source:** code-recovered
- **Columns:** 5
- **Primary key:** (none recovered)
- **Tenant/scope keys present:** CO_CODE, LC_CODE, CO_BOOK
- **Web mapping:** `tenant_id` + the scope keys above; preserve column names verbatim.

| # | Column | Type | Len | Null | Default | Source |
|---|--------|------|-----|------|---------|--------|
| 1 | CO_CODE ⟨scope⟩ | VARCHAR | 2 | Y |  | code+inferred-type |
| 2 | LC_CODE ⟨scope⟩ | VARCHAR | 2 | Y |  | code+inferred-type |
| 3 | CO_BOOK ⟨scope⟩ | VARCHAR | 3 | Y |  | code+inferred-type |
| 4 | VCH_NO | VARCHAR | 8 | Y |  | code+inferred-type |
| 5 | BOOK_NAME | VARCHAR | 20 | Y |  | code+inferred-type |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
