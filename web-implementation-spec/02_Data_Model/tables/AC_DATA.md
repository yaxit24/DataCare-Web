# AC_DATA

- **Cluster:** accounting
- **Source:** code-recovered
- **Columns:** 29
- **Primary key:** (none recovered)
- **Tenant/scope keys present:** CO_CODE, LC_CODE, CO_YEAR, CO_BOOK  ·  fully tenant-keyed
- **Web mapping:** `tenant_id` + the scope keys above; preserve column names verbatim.

| # | Column | Type | Len | Null | Default | Source |
|---|--------|------|-----|------|---------|--------|
| 1 | VCH_NO | VARCHAR | 8 | Y |  | code+inferred-type |
| 2 | CO_CODE ⟨scope⟩ | VARCHAR | 2 | Y |  | code+inferred-type |
| 3 | LC_CODE ⟨scope⟩ | VARCHAR | 2 | Y |  | code+inferred-type |
| 4 | CO_YEAR ⟨scope⟩ | VARCHAR | 10 | Y |  | code+inferred-type |
| 5 | CO_BOOK ⟨scope⟩ | VARCHAR | 3 | Y |  | code+inferred-type |
| 6 | VCH_TYPE | VARCHAR | 6 | Y |  | code+inferred-type |
| 7 | VCH_DATE | DATE |  | Y |  | code+inferred-type |
| 8 | LEDR_KEY | VARCHAR | 50 | Y |  | code+inferred-type |
| 9 | BOOK_NAME | VARCHAR | 20 | Y |  | code+inferred-type |
| 10 | BILL_NO | VARCHAR | 30 | Y |  | code+inferred-type |
| 11 | BILL_DATE | DATE |  | Y |  | code+inferred-type |
| 12 | CHQ_NO | VARCHAR | 10 | Y |  | code+inferred-type |
| 13 | AC_CODE | VARCHAR | 8 | Y |  | code+inferred-type |
| 14 | LD_CODE | VARCHAR | 8 | Y |  | code+inferred-type |
| 15 | CR_AMT | FLOAT |  | Y |  | code+inferred-type |
| 16 | DR_AMT | FLOAT |  | Y |  | code+inferred-type |
| 17 | IT_TYPE | VARCHAR | 1 | Y |  | code+inferred-type |
| 18 | SIGN | VARCHAR | 1 | Y |  | code+inferred-type |
| 19 | FINE_WT | FLOAT |  | Y |  | code+inferred-type |
| 20 | IT_DESC | VARCHAR | 50 | Y |  | code+inferred-type |
| 21 | ENTRY_TIME | DATE |  | Y |  | code+inferred-type |
| 22 | HD_VCH_NO | VARCHAR | 10 | Y |  | code+inferred-type |
| 23 | CLR_DATE | DATE |  | Y |  | code+inferred-type |
| 24 | DATA_TYPE | VARCHAR | 1 | Y |  | code+inferred-type |
| 25 | DATA_TRFR | VARCHAR | 1 | Y |  | code+inferred-type |
| 26 | MAIN_USER | VARCHAR | 15 | Y |  | code+inferred-type |
| 27 | FINE_RATE | FLOAT |  | Y |  | code+inferred-type |
| 28 | PARTY_AC_CODE | unknown |  | Y |  | code |
| 29 | LDR_NAME | unknown |  | Y |  | code |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
