# TABLE_MAST

- **Cluster:** masters
- **Source:** code-recovered
- **Columns:** 6
- **Primary key:** (none recovered)
- **Tenant/scope keys present:** CO_CODE, LC_CODE
- **Web mapping:** `tenant_id` + the scope keys above; preserve column names verbatim.

| # | Column | Type | Len | Null | Default | Source |
|---|--------|------|-----|------|---------|--------|
| 1 | CO_CODE ⟨scope⟩ | VARCHAR | 2 | Y |  | code+inferred-type |
| 2 | LC_CODE ⟨scope⟩ | VARCHAR | 2 | Y |  | code+inferred-type |
| 3 | TABLE_CODE | unknown |  | Y |  | code |
| 4 | TABLE_NAME | unknown |  | Y |  | code |
| 5 | MAIN_USER | VARCHAR | 15 | Y |  | code+inferred-type |
| 6 | DATA_TRFR | VARCHAR | 1 | Y |  | code+inferred-type |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
