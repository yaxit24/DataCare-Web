# TAG_DATA

- **Cluster:** inventory
- **Source:** code-recovered
- **Columns:** 13
- **Primary key:** (none recovered)
- **Tenant/scope keys present:** CO_CODE, LC_CODE
- **Web mapping:** `tenant_id` + the scope keys above; preserve column names verbatim.

| # | Column | Type | Len | Null | Default | Source |
|---|--------|------|-----|------|---------|--------|
| 1 | CO_HDD | unknown |  | Y |  | code |
| 2 | CO_CODE ⟨scope⟩ | VARCHAR | 2 | Y |  | code+inferred-type |
| 3 | LC_CODE ⟨scope⟩ | VARCHAR | 2 | Y |  | code+inferred-type |
| 4 | TAG_NO | VARCHAR | 15 | Y |  | code+inferred-type |
| 5 | VCH_SRNO | FLOAT |  | Y |  | code+inferred-type |
| 6 | LOGIN_NAME | unknown |  | Y |  | code |
| 7 | SR_NO | FLOAT |  | Y |  | code+inferred-type |
| 8 | VCH_DATE | DATE |  | Y |  | code+inferred-type |
| 9 | PR_NAME | VARCHAR | 40 | Y |  | code+inferred-type |
| 10 | ITM_GWT | FLOAT |  | Y |  | code+inferred-type |
| 11 | ITM_NWT | FLOAT |  | Y |  | code+inferred-type |
| 12 | IMG_ID | unknown |  | Y |  | code |
| 13 | IMG_IMPORT | unknown |  | Y |  | code |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
