# CONV_MAST

- **Cluster:** masters
- **Source:** code-recovered
- **Columns:** 15
- **Primary key:** (none recovered)
- **Tenant/scope keys present:** CO_CODE
- **Web mapping:** `tenant_id` + the scope keys above; preserve column names verbatim.

| # | Column | Type | Len | Null | Default | Source |
|---|--------|------|-----|------|---------|--------|
| 1 | GOLD_OZ_RATE | unknown |  | Y |  | code |
| 2 | GOLD_CONV | FLOAT |  | Y |  | code+inferred-type |
| 3 | SILVER_CONV | FLOAT |  | Y |  | code+inferred-type |
| 4 | CO_CODE ⟨scope⟩ | VARCHAR | 2 | Y |  | code+inferred-type |
| 5 | CON_CODE | unknown |  | Y |  | code |
| 6 | CON_NAME | unknown |  | Y |  | code |
| 7 | RATE_DATE | unknown |  | Y |  | code |
| 8 | SILVER_OZ_RATE | unknown |  | Y |  | code |
| 9 | CURRENCY_RATE | FLOAT |  | Y |  | code+inferred-type |
| 10 | OUNCES_CONV | FLOAT |  | Y |  | code+inferred-type |
| 11 | GOLD_PR_RATE | unknown |  | Y |  | code |
| 12 | GOLD_SL_RATE | unknown |  | Y |  | code |
| 13 | SILVER_PR_RATE | unknown |  | Y |  | code |
| 14 | SILVER_SL_RATE | unknown |  | Y |  | code |
| 15 | MAIN_USER | VARCHAR | 15 | Y |  | code+inferred-type |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
