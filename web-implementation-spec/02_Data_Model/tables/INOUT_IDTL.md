# INOUT_IDTL

- **Cluster:** ancillary
- **Source:** DDL
- **Columns:** 48
- **Primary key:** CO_CODE, LC_CODE, CO_YEAR, CO_BOOK, VCH_NO, SR_NO, ISR_NO
- **Tenant/scope keys present:** CO_CODE, LC_CODE, CO_YEAR, CO_BOOK  ·  fully tenant-keyed
- **Web mapping:** `tenant_id` + the scope keys above; preserve column names verbatim.

| # | Column | Type | Len | Null | Default | Source |
|---|--------|------|-----|------|---------|--------|
| 1 | CO_CODE 🔑 ⟨scope⟩ | VARCHAR | 2 | Y |  | ddl |
| 2 | LC_CODE 🔑 ⟨scope⟩ | VARCHAR | 2 | Y |  | ddl |
| 3 | CO_YEAR 🔑 ⟨scope⟩ | VARCHAR | 10 | Y |  | ddl |
| 4 | CO_BOOK 🔑 ⟨scope⟩ | VARCHAR | 3 | Y |  | ddl |
| 5 | VCH_NO 🔑 | VARCHAR | 8 | Y |  | ddl |
| 6 | SR_NO 🔑 | FLOAT |  | N | 0 | ddl |
| 7 | ISR_NO 🔑 | FLOAT |  | N | 0 | ddl |
| 8 | VCH_DATE | DATE |  | Y |  | ddl |
| 9 | VCH_TYPE | VARCHAR | 6 | Y |  | ddl |
| 10 | INOUT_TYPE | VARCHAR | 1 | Y |  | ddl |
| 11 | ENTRY_TYPE | VARCHAR | 1 | Y |  | ddl |
| 12 | BOOK_NAME | VARCHAR | 20 | Y |  | ddl |
| 13 | AC_CODE | VARCHAR | 8 | Y |  | ddl |
| 14 | TO_LC_CODE | VARCHAR | 8 | Y |  | ddl |
| 15 | TAG_NO | VARCHAR | 15 | Y |  | ddl |
| 16 | VCH_SRNO | FLOAT |  | Y | 0 | ddl |
| 17 | IT_CODE | VARCHAR | 5 | Y |  | ddl |
| 18 | IT_TYPE | VARCHAR | 1 | Y |  | ddl |
| 19 | DM_CODE | VARCHAR | 8 | Y |  | ddl |
| 20 | DM_SIZE | VARCHAR | 20 | Y |  | ddl |
| 21 | DM_SFNO | VARCHAR | 20 | Y |  | ddl |
| 22 | DM_LEB | VARCHAR | 15 | Y |  | ddl |
| 23 | IT_PCS | FLOAT |  | Y | 0 | ddl |
| 24 | IT_PCS_WT | FLOAT |  | Y | 0 | ddl |
| 25 | KR_WT | FLOAT |  | Y | 0 | ddl |
| 26 | KR_LESS_PRC | FLOAT |  | Y | 0 | ddl |
| 27 | IT_GWT | FLOAT |  | Y | 0 | ddl |
| 28 | IT_CON_PRC | FLOAT |  | Y | 0 | ddl |
| 29 | IT_CON_WT | FLOAT |  | Y | 0 | ddl |
| 30 | IT_RATE_TYPE | VARCHAR | 1 | Y |  | ddl |
| 31 | IT_RATE | FLOAT |  | Y | 0 | ddl |
| 32 | IT_AMT | FLOAT |  | Y | 0 | ddl |
| 33 | IT_LBR_RATE | FLOAT |  | Y | 0 | ddl |
| 34 | IT_LBR_AMT | FLOAT |  | Y | 0 | ddl |
| 35 | IT_NET_AMT | FLOAT |  | Y | 0 | ddl |
| 36 | KR_CON_PRC | FLOAT |  | Y | 0 | ddl |
| 37 | KR_CON_WT | FLOAT |  | Y | 0 | ddl |
| 38 | KR_RATE | FLOAT |  | Y | 0 | ddl |
| 39 | KR_AMT | FLOAT |  | Y | 0 | ddl |
| 40 | KR_LBR_RATE | FLOAT |  | Y | 0 | ddl |
| 41 | KR_LBR_AMT | FLOAT |  | Y | 0 | ddl |
| 42 | KR_NET_AMT | FLOAT |  | Y | 0 | ddl |
| 43 | HD_VCH_NO | VARCHAR | 10 | Y |  | ddl |
| 44 | MAIN_USER | VARCHAR | 15 | Y |  | ddl |
| 45 | DM_ORIGIN | VARCHAR | 20 | Y |  | ddl |
| 46 | DM_REMARK | VARCHAR | 20 | Y |  | ddl |
| 47 | DM_COLOR | VARCHAR | 15 | Y |  | ddl |
| 48 | DM_NAME | VARCHAR | 50 | Y |  | ddl |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
