# USER_SET

- **Cluster:** ancillary
- **Source:** code-recovered
- **Columns:** 11
- **Primary key:** (none recovered)
- **Tenant/scope keys present:** CO_CODE, LC_CODE
- **Web mapping:** `tenant_id` + the scope keys above; preserve column names verbatim.

| # | Column | Type | Len | Null | Default | Source |
|---|--------|------|-----|------|---------|--------|
| 1 | CO_CODE ⟨scope⟩ | VARCHAR | 2 | Y |  | code+inferred-type |
| 2 | LC_CODE ⟨scope⟩ | VARCHAR | 2 | Y |  | code+inferred-type |
| 3 | MAIN_SRNO | FLOAT |  | Y |  | code+inferred-type |
| 4 | SUB_SRNO | unknown |  | Y |  | code |
| 5 | USER_NAME | VARCHAR | 15 | Y |  | code+inferred-type |
| 6 | MAIN_MENU | unknown |  | Y |  | code |
| 7 | SUB_MENU | unknown |  | Y |  | code |
| 8 | FRM_VIEW | unknown |  | Y |  | code |
| 9 | FRM_EDIT | unknown |  | Y |  | code |
| 10 | FRM_DELETE | unknown |  | Y |  | code |
| 11 | FRM_PRINT | unknown |  | Y |  | code |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
