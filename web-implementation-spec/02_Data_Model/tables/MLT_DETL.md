# MLT_DETL

- **Cluster:** manufacturing
- **Source:** DDL
- **Columns:** 33
- **Primary key:** CO_CODE, LC_CODE, CO_YEAR, CO_BOOK, VCH_NO, ENTRY_TYPE, SR_NO
- **Tenant/scope keys present:** CO_CODE, LC_CODE, CO_YEAR, CO_BOOK  ·  fully tenant-keyed
- **Web mapping:** `tenant_id` + the scope keys above; preserve column names verbatim.

| # | Column | Type | Len | Null | Default | Source |
|---|--------|------|-----|------|---------|--------|
| 1 | CO_CODE 🔑 ⟨scope⟩ | VARCHAR | 2 | Y |  | ddl |
| 2 | LC_CODE 🔑 ⟨scope⟩ | VARCHAR | 2 | Y |  | ddl |
| 3 | CO_YEAR 🔑 ⟨scope⟩ | VARCHAR | 10 | Y |  | ddl |
| 4 | CO_BOOK 🔑 ⟨scope⟩ | VARCHAR | 3 | Y |  | ddl |
| 5 | VCH_NO 🔑 | VARCHAR | 8 | Y |  | ddl |
| 6 | ENTRY_TYPE 🔑 | VARCHAR | 1 | Y |  | ddl |
| 7 | SR_NO 🔑 | FLOAT |  | N | 0 | ddl |
| 8 | VCH_DATE | DATE |  | Y |  | ddl |
| 9 | VCH_TIME | DATETIME |  | Y |  | ddl |
| 10 | BILL_NO | VARCHAR | 30 | Y |  | ddl |
| 11 | VCH_TYPE | VARCHAR | 6 | Y |  | ddl |
| 12 | INOUT_TYPE | VARCHAR | 1 | Y |  | ddl |
| 13 | BOOK_NAME | VARCHAR | 20 | Y |  | ddl |
| 14 | AC_CODE | VARCHAR | 8 | Y |  | ddl |
| 15 | IT_CODE | VARCHAR | 5 | Y |  | ddl |
| 16 | IT_NAME | VARCHAR | 50 | Y |  | ddl |
| 17 | ITM_PCS | FLOAT |  | N | 0 | ddl |
| 18 | ITM_GWT | FLOAT |  | N | 0 | ddl |
| 19 | ITM_OTH_WT | FLOAT |  | N | 0 | ddl |
| 20 | ITM_NWT | FLOAT |  | N | 0 | ddl |
| 21 | ITM_TOUCH | FLOAT |  | N | 0 | ddl |
| 22 | ITM_WEST | FLOAT |  | N | 0 | ddl |
| 23 | PARTY_FINE | FLOAT |  | N | 0 | ddl |
| 24 | NET_FINE | FLOAT |  | N | 0 | ddl |
| 25 | IT_TYPE | VARCHAR | 1 | Y |  | ddl |
| 26 | CON_IT_CODE | VARCHAR | 5 | Y |  | ddl |
| 27 | CON_PRC | FLOAT |  | N | 0 | ddl |
| 28 | CON_WT | FLOAT |  | N | 0 | ddl |
| 29 | FINE_PRC | FLOAT |  | N | 0 | ddl |
| 30 | FINE_ADD | FLOAT |  | N | 0 | ddl |
| 31 | LOSS_WT | FLOAT |  | N | 0 | ddl |
| 32 | MAIN_USER | VARCHAR | 15 | Y |  | ddl |
| 33 | ADD_USER | VARCHAR | 15 | Y |  | ddl |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
