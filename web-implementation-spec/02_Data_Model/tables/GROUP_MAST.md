# GROUP_MAST

- **Cluster:** masters
- **Source:** code-recovered
- **Columns:** 27
- **Primary key:** (none recovered)
- **Tenant/scope keys present:** CO_CODE
- **Web mapping:** `tenant_id` + the scope keys above; preserve column names verbatim.

| # | Column | Type | Len | Null | Default | Source |
|---|--------|------|-----|------|---------|--------|
| 1 | CO_CODE ⟨scope⟩ | VARCHAR | 2 | Y |  | code+inferred-type |
| 2 | GR_CODE | VARCHAR | 3 | Y |  | code+inferred-type |
| 3 | GR_NAME | VARCHAR | 40 | Y |  | code+inferred-type |
| 4 | GR_TYPE | unknown |  | Y |  | code |
| 5 | TRAD_TYPE | unknown |  | Y |  | code |
| 6 | GR_TOUCH | unknown |  | Y |  | code |
| 7 | GR_PURC_TOUCH | unknown |  | Y |  | code |
| 8 | MELTING_PRC | unknown |  | Y |  | code |
| 9 | GR_RATE | FLOAT |  | Y |  | code+inferred-type |
| 10 | WEST_PRC | unknown |  | Y |  | code |
| 11 | SALE_AC | VARCHAR | 10 | Y |  | code+inferred-type |
| 12 | PURC_AC | VARCHAR | 10 | Y |  | code+inferred-type |
| 13 | HSN_CODE | VARCHAR | 10 | Y |  | code+inferred-type |
| 14 | MAIN_USER | VARCHAR | 15 | Y |  | code+inferred-type |
| 15 | TAX_PRC | FLOAT |  | Y |  | code+inferred-type |
| 16 | AVG_TOUCH | unknown |  | Y |  | code |
| 17 | AVG_FINE | unknown |  | Y |  | code |
| 18 | AVG_NWT | unknown |  | Y |  | code |
| 19 | DAY_OP_PCS | unknown |  | Y |  | code |
| 20 | DAY_OP_WT | unknown |  | Y |  | code |
| 21 | DAY_CL_PCS | unknown |  | Y |  | code |
| 22 | DAY_CL_WT | unknown |  | Y |  | code |
| 23 | RATE_DISPLAY | unknown |  | Y |  | code |
| 24 | DATA_TRFR | VARCHAR | 1 | Y |  | code+inferred-type |
| 25 | OP_TOUCH | unknown |  | Y |  | code |
| 26 | OP_FINE | unknown |  | Y |  | code |
| 27 | AVG_RATE | unknown |  | Y |  | code |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
