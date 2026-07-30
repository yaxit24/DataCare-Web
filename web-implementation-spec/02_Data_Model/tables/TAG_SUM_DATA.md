# TAG_SUM_DATA

- **Cluster:** inventory
- **Source:** DDL
- **Columns:** 18
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
| 6 | SR_NO | FLOAT |  | N | 0 | ddl |
| 7 | ISR_NO | FLOAT |  | N | 0 | ddl |
| 8 | VCH_DATE | DATE |  | Y |  | ddl |
| 9 | IT_CODE | VARCHAR | 5 | Y |  | ddl |
| 10 | TAG_NO | VARCHAR | 15 | Y |  | ddl |
| 11 | VCH_SRNO | FLOAT |  | N | 0 | ddl |
| 12 | IT_TYPE | VARCHAR | 1 | Y |  | ddl |
| 13 | DATA_TYPE | VARCHAR | 1 | Y |  | ddl |
| 14 | ITM_QTY | FLOAT |  | Y | 0 | ddl |
| 15 | ITM_PCS | FLOAT |  | Y | 0 | ddl |
| 16 | ITM_GWT | FLOAT |  | Y | 0 | ddl |
| 17 | ITM_NWT | FLOAT |  | Y | 0 | ddl |
| 18 | ITM_FINE | FLOAT |  | Y | 0 | ddl |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
