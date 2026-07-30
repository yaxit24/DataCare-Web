# TAG_STOCK_PRINT

- **Cluster:** inventory
- **Source:** DDL
- **Columns:** 26
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
| 7 | VCH_DATE | DATE |  | Y |  | ddl |
| 8 | VCH_TYPE | VARCHAR | 6 | Y |  | ddl |
| 9 | INOUT_TYPE | VARCHAR | 1 | Y |  | ddl |
| 10 | BOOK_NAME | VARCHAR | 20 | Y |  | ddl |
| 11 | IT_CODE | VARCHAR | 5 | Y |  | ddl |
| 12 | TAG_NO | VARCHAR | 15 | Y |  | ddl |
| 13 | VCH_SRNO | FLOAT |  | Y | 0 | ddl |
| 14 | ITM_SIGN | VARCHAR | 1 | Y |  | ddl |
| 15 | DESIGN_NO | VARCHAR | 15 | Y |  | ddl |
| 16 | ITM_SIZE | VARCHAR | 15 | Y |  | ddl |
| 17 | TBL_CODE | VARCHAR | 15 | Y |  | ddl |
| 18 | ITM_QTY | FLOAT |  | Y | 0 | ddl |
| 19 | ITM_PCS | FLOAT |  | Y | 0 | ddl |
| 20 | ITM_GWT | FLOAT |  | Y | 0 | ddl |
| 21 | ITM_NWT | FLOAT |  | Y | 0 | ddl |
| 22 | ITM_FINE | FLOAT |  | Y | 0 | ddl |
| 23 | DATA_TYPE | VARCHAR | 1 | Y |  | ddl |
| 24 | HD_VCH_NO | VARCHAR | 8 | Y |  | ddl |
| 25 | MAIN_USER | VARCHAR | 15 | Y |  | ddl |
| 26 | ADD_USER | VARCHAR | 15 | Y |  | ddl |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
