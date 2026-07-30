# DM_KR_DATA

- **Cluster:** finance
- **Source:** DDL
- **Columns:** 23
- **Primary key:** CO_CODE, LC_CODE, CO_YEAR, CO_BOOK, VCH_NO, MAIN_SRNO, SR_NO, ISR_NO
- **Tenant/scope keys present:** CO_CODE, LC_CODE, CO_YEAR, CO_BOOK  ·  fully tenant-keyed
- **Web mapping:** `tenant_id` + the scope keys above; preserve column names verbatim.

| # | Column | Type | Len | Null | Default | Source |
|---|--------|------|-----|------|---------|--------|
| 1 | CO_CODE 🔑 ⟨scope⟩ | VARCHAR | 2 | Y |  | ddl |
| 2 | LC_CODE 🔑 ⟨scope⟩ | VARCHAR | 2 | Y |  | ddl |
| 3 | CO_YEAR 🔑 ⟨scope⟩ | VARCHAR | 10 | Y |  | ddl |
| 4 | CO_BOOK 🔑 ⟨scope⟩ | VARCHAR | 3 | Y |  | ddl |
| 5 | VCH_NO 🔑 | VARCHAR | 8 | Y |  | ddl |
| 6 | MAIN_SRNO 🔑 | FLOAT |  | N | 0 | ddl |
| 7 | SR_NO 🔑 | FLOAT |  | N | 0 | ddl |
| 8 | ISR_NO 🔑 | FLOAT |  | N | 0 | ddl |
| 9 | VCH_DATE | DATE |  | Y |  | ddl |
| 10 | ENTRY_TYPE | VARCHAR | 1 | Y |  | ddl |
| 11 | BOOK_NAME | VARCHAR | 20 | Y |  | ddl |
| 12 | AC_CODE | VARCHAR | 8 | Y |  | ddl |
| 13 | DM_LOT | VARCHAR | 10 | Y |  | ddl |
| 14 | IT_CODE | VARCHAR | 6 | Y |  | ddl |
| 15 | DM_CODE | VARCHAR | 8 | Y |  | ddl |
| 16 | DM_SIZE | VARCHAR | 20 | Y |  | ddl |
| 17 | DM_PCS | FLOAT |  | N | 0 | ddl |
| 18 | DM_WT | FLOAT |  | N | 0 | ddl |
| 19 | DM_SIGN | VARCHAR | 1 | Y |  | ddl |
| 20 | DM_RATE | FLOAT |  | N | 0 | ddl |
| 21 | DM_AMT | FLOAT |  | N | 0 | ddl |
| 22 | EMP_CODE | VARCHAR | 3 | Y |  | ddl |
| 23 | MAIN_USER | VARCHAR | 15 | Y |  | ddl |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
