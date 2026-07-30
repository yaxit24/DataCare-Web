# EMP_MAST

- **Cluster:** masters
- **Source:** code-recovered
- **Columns:** 13
- **Primary key:** (none recovered)
- **Tenant/scope keys present:** CO_CODE
- **Web mapping:** `tenant_id` + the scope keys above; preserve column names verbatim.

| # | Column | Type | Len | Null | Default | Source |
|---|--------|------|-----|------|---------|--------|
| 1 | CO_CODE ⟨scope⟩ | VARCHAR | 2 | Y |  | code+inferred-type |
| 2 | EMP_CODE | VARCHAR | 3 | Y |  | code+inferred-type |
| 3 | EMP_NAME | VARCHAR | 40 | Y |  | code+inferred-type |
| 4 | USER_NAME | VARCHAR | 15 | Y |  | code+inferred-type |
| 5 | EMP_TYPE | unknown |  | Y |  | code |
| 6 | EMP_AC | unknown |  | Y |  | code |
| 7 | EMP_AMT | unknown |  | Y |  | code |
| 8 | MAIN_USER | VARCHAR | 15 | Y |  | code+inferred-type |
| 9 | TDS_PRC | FLOAT |  | Y |  | code+inferred-type |
| 10 | TDS_AMT | FLOAT |  | Y |  | code+inferred-type |
| 11 | PF_PRC | FLOAT |  | Y |  | code+inferred-type |
| 12 | PF_AMT | FLOAT |  | Y |  | code+inferred-type |
| 13 | DAY_HOURS | FLOAT |  | Y |  | code+inferred-type |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
