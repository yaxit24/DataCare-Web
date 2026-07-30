# ITM_OPBL

- **Cluster:** inventory
- **Source:** code-recovered
- **Columns:** 27
- **Primary key:** (none recovered)
- **Tenant/scope keys present:** CO_CODE, LC_CODE, CO_YEAR, CO_BOOK  ·  fully tenant-keyed
- **Web mapping:** `tenant_id` + the scope keys above; preserve column names verbatim.

| # | Column | Type | Len | Null | Default | Source |
|---|--------|------|-----|------|---------|--------|
| 1 | CO_CODE ⟨scope⟩ | VARCHAR | 2 | Y |  | code+inferred-type |
| 2 | LC_CODE ⟨scope⟩ | VARCHAR | 2 | Y |  | code+inferred-type |
| 3 | CO_YEAR ⟨scope⟩ | VARCHAR | 10 | Y |  | code+inferred-type |
| 4 | CO_BOOK ⟨scope⟩ | VARCHAR | 3 | Y |  | code+inferred-type |
| 5 | IT_CODE | VARCHAR | 5 | Y |  | code+inferred-type |
| 6 | VCH_NO | VARCHAR | 8 | Y |  | code+inferred-type |
| 7 | SR_NO | FLOAT |  | Y |  | code+inferred-type |
| 8 | ITM_PCS | FLOAT |  | Y |  | code+inferred-type |
| 9 | ITM_GWT | FLOAT |  | Y |  | code+inferred-type |
| 10 | ITM_NWT | FLOAT |  | Y |  | code+inferred-type |
| 11 | ITM_TOUCH | FLOAT |  | Y |  | code+inferred-type |
| 12 | ITM_FINE | FLOAT |  | Y |  | code+inferred-type |
| 13 | ITM_RATE | FLOAT |  | Y |  | code+inferred-type |
| 14 | ITM_AMT | FLOAT |  | Y |  | code+inferred-type |
| 15 | LBR_AMT | FLOAT |  | Y |  | code+inferred-type |
| 16 | OTH_AMT | FLOAT |  | Y |  | code+inferred-type |
| 17 | NET_AMT | FLOAT |  | Y |  | code+inferred-type |
| 18 | DM_WT | FLOAT |  | Y |  | code+inferred-type |
| 19 | DM_RATE | FLOAT |  | Y |  | code+inferred-type |
| 20 | DM_AMT | FLOAT |  | Y |  | code+inferred-type |
| 21 | MAIN_USER | VARCHAR | 15 | Y |  | code+inferred-type |
| 22 | ADD_DATE | unknown |  | Y |  | code |
| 23 | LBR_RATE | FLOAT |  | Y |  | code+inferred-type |
| 24 | LBR_TYPE | VARCHAR | 1 | Y |  | code+inferred-type |
| 25 | ITM_WEST_PRC | FLOAT |  | Y |  | code+inferred-type |
| 26 | DATA_TRFR | VARCHAR | 1 | Y |  | code+inferred-type |
| 27 | DATA_TYPE | VARCHAR | 1 | Y |  | code+inferred-type |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
