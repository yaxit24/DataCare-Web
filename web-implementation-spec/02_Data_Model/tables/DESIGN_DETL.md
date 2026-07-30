# DESIGN_DETL

- **Cluster:** ancillary
- **Source:** DDL
- **Columns:** 34
- **Primary key:** CO_CODE, BOOK_NAME, PR_CODE, SR_NO
- **Tenant/scope keys present:** CO_CODE
- **Web mapping:** `tenant_id` + the scope keys above; preserve column names verbatim.

| # | Column | Type | Len | Null | Default | Source |
|---|--------|------|-----|------|---------|--------|
| 1 | CO_CODE 🔑 ⟨scope⟩ | VARCHAR | 2 | Y |  | ddl |
| 2 | BOOK_NAME 🔑 | VARCHAR | 20 | Y |  | ddl |
| 3 | PR_CODE 🔑 | VARCHAR | 2 | Y |  | ddl |
| 4 | SR_NO 🔑 | FLOAT |  | N | 0 | ddl |
| 5 | OLD_SRNO | FLOAT |  | N | 0 | ddl |
| 6 | PAGE_NO | VARCHAR | 2 | Y |  | ddl |
| 7 | VCH_DATE | DATE |  | Y |  | ddl |
| 8 | GR_CODE | VARCHAR | 3 | Y |  | ddl |
| 9 | DESIGN_NO | VARCHAR | 15 | Y |  | ddl |
| 10 | ITM_SIZE | VARCHAR | 15 | Y |  | ddl |
| 11 | DIE_NO | VARCHAR | 10 | Y |  | ddl |
| 12 | ITM_PCS | FLOAT |  | N | 0 | ddl |
| 13 | ITM_GWT | FLOAT |  | N | 0 | ddl |
| 14 | ITM_OTH_WT | FLOAT |  | N | 0 | ddl |
| 15 | ITM_NWT | FLOAT |  | N | 0 | ddl |
| 16 | ITM_TOUCH | FLOAT |  | N | 0 | ddl |
| 17 | ITM_WEST_PRC | FLOAT |  | N | 0 | ddl |
| 18 | ITM_FINE | FLOAT |  | N | 0 | ddl |
| 19 | ITM_RATE | FLOAT |  | N | 0 | ddl |
| 20 | ITM_AMT | FLOAT |  | N | 0 | ddl |
| 21 | LBR_TYPE | VARCHAR | 1 | Y |  | ddl |
| 22 | LBR_PRC | FLOAT |  | N | 0 | ddl |
| 23 | LBR_RATE | FLOAT |  | N | 0 | ddl |
| 24 | LBR_AMT | FLOAT |  | N | 0 | ddl |
| 25 | OTH_AMT | FLOAT |  | N | 0 | ddl |
| 26 | TAG_COST | FLOAT |  | N | 0 | ddl |
| 27 | ITM_MRP | FLOAT |  | N | 0 | ddl |
| 28 | GHT_PRC | FLOAT |  | N | 0 | ddl |
| 29 | ITM_GHT | FLOAT |  | N | 0 | ddl |
| 30 | NET_AMT | FLOAT |  | N | 0 | ddl |
| 31 | RATE_TYPE | VARCHAR | 1 | Y |  | ddl |
| 32 | IT_TYPE | VARCHAR | 1 | Y |  | ddl |
| 33 | KR_NAME | VARCHAR | 5 | Y |  | ddl |
| 34 | MAIN_USER | VARCHAR | 15 | Y |  | ddl |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
