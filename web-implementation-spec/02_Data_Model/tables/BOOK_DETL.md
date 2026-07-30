# BOOK_DETL

- **Cluster:** ancillary
- **Source:** code-recovered
- **Columns:** 14
- **Primary key:** (none recovered)
- **Tenant/scope keys present:** CO_CODE, LC_CODE, CO_BOOK
- **Web mapping:** `tenant_id` + the scope keys above; preserve column names verbatim.

| # | Column | Type | Len | Null | Default | Source |
|---|--------|------|-----|------|---------|--------|
| 1 | AC_CODE | VARCHAR | 8 | Y |  | code+inferred-type |
| 2 | CO_CODE ⟨scope⟩ | VARCHAR | 2 | Y |  | code+inferred-type |
| 3 | LC_CODE ⟨scope⟩ | VARCHAR | 2 | Y |  | code+inferred-type |
| 4 | CO_BOOK ⟨scope⟩ | VARCHAR | 3 | Y |  | code+inferred-type |
| 5 | SR_NO | FLOAT |  | Y |  | code+inferred-type |
| 6 | BOOK_NAME | VARCHAR | 20 | Y |  | code+inferred-type |
| 7 | BOOK_SNAME | VARCHAR | 5 | Y |  | code+inferred-type |
| 8 | BOOK_TYPE | unknown |  | Y |  | code |
| 9 | ITM_TYPE | VARCHAR | 1 | Y |  | code+inferred-type |
| 10 | BOOK_INOUT | unknown |  | Y |  | code |
| 11 | AC_NAME | VARCHAR | 50 | Y |  | code+inferred-type |
| 12 | MAIN_BOOK | VARCHAR | 30 | Y |  | code+inferred-type |
| 13 | RESET_BOOK | unknown |  | Y |  | code |
| 14 | DATA_TYPE | VARCHAR | 1 | Y |  | code+inferred-type |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
