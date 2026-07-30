# MENU_DATA

- **Cluster:** ancillary
- **Source:** code-recovered
- **Columns:** 9
- **Primary key:** (none recovered)
- **Tenant/scope keys present:** (none)
- **Web mapping:** `tenant_id` + the scope keys above; preserve column names verbatim.

| # | Column | Type | Len | Null | Default | Source |
|---|--------|------|-----|------|---------|--------|
| 1 | SM_NAME | unknown |  | Y |  | code |
| 2 | SM_VIEW | unknown |  | Y |  | code |
| 3 | SM_CODE | VARCHAR | 2 | Y |  | code+inferred-type |
| 4 | SM_MAIN_CODE | VARCHAR | 2 | Y |  | code+inferred-type |
| 5 | MAIN_SRNO | FLOAT |  | Y |  | code+inferred-type |
| 6 | BTN_NAME | unknown |  | Y |  | code |
| 7 | SM_MAIN_NAME | VARCHAR | 25 | Y |  | code+inferred-type |
| 8 | SM_TYPE | unknown |  | Y |  | code |
| 9 | TILE_ITEM | unknown |  | Y |  | code |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
