# FINE_DATA

- **Cluster:** bullion_tour
- **Source:** DDL
- **Columns:** 34
- **Primary key:** (none recovered)
- **Tenant/scope keys present:** CO_CODE, LC_CODE, CO_YEAR, CO_BOOK  ·  fully tenant-keyed
- **Web mapping:** `tenant_id` + the scope keys above; preserve column names verbatim.

| # | Column | Type | Len | Null | Default | Source |
|---|--------|------|-----|------|---------|--------|
| 1 | CO_CODE ⟨scope⟩ | VARCHAR | 2 | Y |  | ddl |
| 2 | LC_CODE ⟨scope⟩ | VARCHAR | 2 | Y |  | ddl |
| 3 | CO_YEAR ⟨scope⟩ | VARCHAR | 10 | Y |  | ddl |
| 4 | CO_BOOK ⟨scope⟩ | VARCHAR | 3 | Y |  | ddl |
| 5 | VCH_NO | VARCHAR | 8 | Y |  | ddl |
| 6 | SR_NO | FLOAT |  | Y | 0 | ddl |
| 7 | ISR_NO | FLOAT |  | Y | 0 | ddl |
| 8 | VCH_DATE | DATE |  | Y |  | ddl |
| 9 | VCH_TYPE | VARCHAR | 6 | Y |  | ddl |
| 10 | BOOK_NAME | VARCHAR | 20 | Y |  | ddl |
| 11 | AC_CODE | VARCHAR | 8 | Y |  | ddl |
| 12 | AC_NAME | VARCHAR | 50 | Y |  | ddl |
| 13 | LD_CODE | VARCHAR | 8 | Y |  | ddl |
| 14 | IT_CODE | VARCHAR | 5 | Y |  | ddl |
| 15 | IT_DESC | VARCHAR | 50 | Y |  | ddl |
| 16 | TAG_NO | VARCHAR | 15 | Y |  | ddl |
| 17 | ITM_PCS | FLOAT |  | Y | 0 | ddl |
| 18 | ITM_GWT | FLOAT |  | Y | 0 | ddl |
| 19 | ITM_NWT | FLOAT |  | Y | 0 | ddl |
| 20 | ITM_TOUCH | FLOAT |  | Y | 0 | ddl |
| 21 | ITM_WEST | FLOAT |  | Y | 0 | ddl |
| 22 | ITM_FINE | FLOAT |  | Y | 0 | ddl |
| 23 | ITM_RATE | FLOAT |  | Y | 0 | ddl |
| 24 | ITM_AMT | FLOAT |  | Y | 0 | ddl |
| 25 | LBR_RATE | FLOAT |  | Y | 0 | ddl |
| 26 | LBR_AMT | FLOAT |  | Y | 0 | ddl |
| 27 | OTH_AMT | FLOAT |  | Y | 0 | ddl |
| 28 | NET_AMT | FLOAT |  | Y | 0 | ddl |
| 29 | DR_AMT | FLOAT |  | Y | 0 | ddl |
| 30 | CR_AMT | FLOAT |  | Y | 0 | ddl |
| 31 | TR_TYPE | VARCHAR | 1 | Y |  | ddl |
| 32 | ITM_SIGN | VARCHAR | 1 | Y |  | ddl |
| 33 | ENTRY_TYPE | VARCHAR | 1 | Y |  | ddl |
| 34 | DATA_TYPE | VARCHAR | 1 | Y |  | ddl |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
