# DESIGN_IDTL

- **Cluster:** ancillary
- **Source:** DDL
- **Columns:** 22
- **Primary key:** CO_CODE, BOOK_NAME, PR_CODE, SR_NO, ISR_NO
- **Tenant/scope keys present:** CO_CODE
- **Web mapping:** `tenant_id` + the scope keys above; preserve column names verbatim.

| # | Column | Type | Len | Null | Default | Source |
|---|--------|------|-----|------|---------|--------|
| 1 | CO_CODE 🔑 ⟨scope⟩ | VARCHAR | 2 | Y |  | ddl |
| 2 | BOOK_NAME 🔑 | VARCHAR | 20 | Y |  | ddl |
| 3 | PR_CODE 🔑 | VARCHAR | 2 | Y |  | ddl |
| 4 | SR_NO 🔑 | FLOAT |  | N | 0 | ddl |
| 5 | ISR_NO 🔑 | FLOAT |  | N | 0 | ddl |
| 6 | DESIGN_NO | VARCHAR | 15 | Y |  | ddl |
| 7 | IT_CODE | VARCHAR | 5 | Y |  | ddl |
| 8 | IT_TYPE | VARCHAR | 1 | Y |  | ddl |
| 9 | IT_PCS | FLOAT |  | Y | 0 | ddl |
| 10 | IT_PCS_WT | FLOAT |  | Y | 0 | ddl |
| 11 | KR_WT | FLOAT |  | Y | 0 | ddl |
| 12 | KR_LESS_PRC | FLOAT |  | Y | 0 | ddl |
| 13 | IT_GWT | FLOAT |  | Y | 0 | ddl |
| 14 | IT_CON_PRC | FLOAT |  | Y | 0 | ddl |
| 15 | IT_CON_WT | FLOAT |  | Y | 0 | ddl |
| 16 | IT_RATE_TYPE | VARCHAR | 1 | Y |  | ddl |
| 17 | IT_RATE | FLOAT |  | Y | 0 | ddl |
| 18 | IT_AMT | FLOAT |  | Y | 0 | ddl |
| 19 | IT_LBR_RATE | FLOAT |  | Y | 0 | ddl |
| 20 | IT_LBR_AMT | FLOAT |  | Y | 0 | ddl |
| 21 | IT_NET_AMT | FLOAT |  | Y | 0 | ddl |
| 22 | MAIN_USER | VARCHAR | 15 | Y |  | ddl |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
