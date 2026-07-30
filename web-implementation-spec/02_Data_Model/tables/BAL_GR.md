# BAL_GR

- **Cluster:** ancillary
- **Source:** code-recovered
- **Columns:** 18
- **Primary key:** (none recovered)
- **Tenant/scope keys present:** CO_CODE
- **Web mapping:** `tenant_id` + the scope keys above; preserve column names verbatim.

| # | Column | Type | Len | Null | Default | Source |
|---|--------|------|-----|------|---------|--------|
| 1 | CO_CODE ⟨scope⟩ | VARCHAR | 2 | Y |  | code+inferred-type |
| 2 | TRAD_TYPE | unknown |  | Y |  | code |
| 3 | TRAD_NAME | unknown |  | Y |  | code |
| 4 | SALE_AC | VARCHAR | 10 | Y |  | code+inferred-type |
| 5 | PURC_AC | VARCHAR | 10 | Y |  | code+inferred-type |
| 6 | CLOSING_AC | unknown |  | Y |  | code |
| 7 | OP_AC | unknown |  | Y |  | code |
| 8 | TRAD_AMT | unknown |  | Y |  | code |
| 9 | TRAD_WT | unknown |  | Y |  | code |
| 10 | CLG_AC | unknown |  | Y |  | code |
| 11 | OP_TOUCH | unknown |  | Y |  | code |
| 12 | OP_FINE | unknown |  | Y |  | code |
| 13 | AVG_TOUCH | unknown |  | Y |  | code |
| 14 | AVG_FINE | unknown |  | Y |  | code |
| 15 | AVG_NWT | unknown |  | Y |  | code |
| 16 | AVG_AMT | unknown |  | Y |  | code |
| 17 | AVG_RATE | unknown |  | Y |  | code |
| 18 | IT_TYPE | VARCHAR | 1 | Y |  | code+inferred-type |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
