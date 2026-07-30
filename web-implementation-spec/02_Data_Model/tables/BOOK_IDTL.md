# BOOK_IDTL

- **Cluster:** ancillary
- **Source:** code-recovered
- **Columns:** 6
- **Primary key:** (none recovered)
- **Tenant/scope keys present:** (none)
- **Web mapping:** `tenant_id` + the scope keys above; preserve column names verbatim.

| # | Column | Type | Len | Null | Default | Source |
|---|--------|------|-----|------|---------|--------|
| 1 | AC_CODE | VARCHAR | 8 | Y |  | code+inferred-type |
| 2 | MAIN_BOOK | VARCHAR | 30 | Y |  | code+inferred-type |
| 3 | SR_NO | FLOAT |  | Y |  | code+inferred-type |
| 4 | INOUT_TYPE | VARCHAR | 1 | Y |  | code+inferred-type |
| 5 | AC_NAME | VARCHAR | 50 | Y |  | code+inferred-type |
| 6 | SVR_PWD | unknown |  | Y |  | code |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
