# OP_DATA

- **Cluster:** ancillary
- **Source:** code-recovered
- **Columns:** 17
- **Primary key:** (none recovered)
- **Tenant/scope keys present:** CO_CODE, LC_CODE, CO_YEAR, CO_BOOK  ·  fully tenant-keyed
- **Web mapping:** `tenant_id` + the scope keys above; preserve column names verbatim.

| # | Column | Type | Len | Null | Default | Source |
|---|--------|------|-----|------|---------|--------|
| 1 | FINE_BAL | unknown |  | Y |  | code |
| 2 | SL_FINE_BAL | unknown |  | Y |  | code |
| 3 | CO_CODE ⟨scope⟩ | VARCHAR | 2 | Y |  | code+inferred-type |
| 4 | LC_CODE ⟨scope⟩ | VARCHAR | 2 | Y |  | code+inferred-type |
| 5 | CO_YEAR ⟨scope⟩ | VARCHAR | 10 | Y |  | code+inferred-type |
| 6 | CO_BOOK ⟨scope⟩ | VARCHAR | 3 | Y |  | code+inferred-type |
| 7 | VCH_NO | VARCHAR | 8 | Y |  | code+inferred-type |
| 8 | AC_CODE | VARCHAR | 8 | Y |  | code+inferred-type |
| 9 | OP_AMT | unknown |  | Y |  | code |
| 10 | OP_SIGN | unknown |  | Y |  | code |
| 11 | FINE_SIGN | unknown |  | Y |  | code |
| 12 | SL_FINE_SIGN | unknown |  | Y |  | code |
| 13 | DATA_TYPE | VARCHAR | 1 | Y |  | code+inferred-type |
| 14 | MAIN_USER | VARCHAR | 15 | Y |  | code+inferred-type |
| 15 | ADD_USER | VARCHAR | 15 | Y |  | code+inferred-type |
| 16 | ADD_DATE | unknown |  | Y |  | code |
| 17 | DATA_TRFR | VARCHAR | 1 | Y |  | code+inferred-type |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
