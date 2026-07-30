# LEDR_AC_DATA

- **Cluster:** accounting
- **Source:** code-recovered
- **Columns:** 15
- **Primary key:** (none recovered)
- **Tenant/scope keys present:** CO_CODE, LC_CODE, CO_YEAR, CO_BOOK  ·  fully tenant-keyed
- **Web mapping:** `tenant_id` + the scope keys above; preserve column names verbatim.

| # | Column | Type | Len | Null | Default | Source |
|---|--------|------|-----|------|---------|--------|
| 1 | CO_CODE ⟨scope⟩ | VARCHAR | 2 | Y |  | code+inferred-type |
| 2 | LC_CODE ⟨scope⟩ | VARCHAR | 2 | Y |  | code+inferred-type |
| 3 | CO_YEAR ⟨scope⟩ | VARCHAR | 10 | Y |  | code+inferred-type |
| 4 | CO_BOOK ⟨scope⟩ | VARCHAR | 3 | Y |  | code+inferred-type |
| 5 | VCH_DT | unknown |  | Y |  | code |
| 6 | MAIN_USER | VARCHAR | 15 | Y |  | code+inferred-type |
| 7 | AC_CODE | VARCHAR | 8 | Y |  | code+inferred-type |
| 8 | CR_AMT | FLOAT |  | Y |  | code+inferred-type |
| 9 | DR_AMT | FLOAT |  | Y |  | code+inferred-type |
| 10 | CR_FINE_WT | unknown |  | Y |  | code |
| 11 | DR_FINE_WT | unknown |  | Y |  | code |
| 12 | CR_SL_FINE | FLOAT |  | Y |  | code+inferred-type |
| 13 | DR_SL_FINE | FLOAT |  | Y |  | code+inferred-type |
| 14 | DATA_TYPE | VARCHAR | 1 | Y |  | code+inferred-type |
| 15 | AC_GR | unknown |  | Y |  | code |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
