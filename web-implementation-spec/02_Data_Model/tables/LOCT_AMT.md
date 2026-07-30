# LOCT_AMT

- **Cluster:** ancillary
- **Source:** DDL
- **Columns:** 24
- **Primary key:** CO_CODE, LC_CODE, CO_YEAR, CO_BOOK, VCH_NO, SR_NO
- **Tenant/scope keys present:** CO_CODE, LC_CODE, CO_YEAR, CO_BOOK  ·  fully tenant-keyed
- **Web mapping:** `tenant_id` + the scope keys above; preserve column names verbatim.

| # | Column | Type | Len | Null | Default | Source |
|---|--------|------|-----|------|---------|--------|
| 1 | CO_CODE 🔑 ⟨scope⟩ | VARCHAR | 2 | Y |  | ddl |
| 2 | LC_CODE 🔑 ⟨scope⟩ | VARCHAR | 2 | Y |  | ddl |
| 3 | CO_YEAR 🔑 ⟨scope⟩ | VARCHAR | 9 | Y |  | ddl |
| 4 | CO_BOOK 🔑 ⟨scope⟩ | VARCHAR | 3 | Y |  | ddl |
| 5 | VCH_NO 🔑 | VARCHAR | 8 | Y |  | ddl |
| 6 | SR_NO 🔑 | FLOAT |  | N | 0 | ddl |
| 7 | VCH_DATE | DATE |  | Y |  | ddl |
| 8 | VCH_TYPE | VARCHAR | 5 | Y |  | ddl |
| 9 | INOUT_TYPE | VARCHAR | 1 | Y |  | ddl |
| 10 | ENTRY_TYPE | VARCHAR | 1 | Y |  | ddl |
| 11 | BOOK_NAME | VARCHAR | 15 | Y |  | ddl |
| 12 | FROM_LC_CODE | VARCHAR | 2 | Y |  | ddl |
| 13 | TO_LC_CODE | VARCHAR | 2 | Y |  | ddl |
| 14 | AC_CODE | VARCHAR | 10 | Y |  | ddl |
| 15 | AC_NAME | VARCHAR | 50 | Y |  | ddl |
| 16 | CHQ_NO | VARCHAR | 2 | Y |  | ddl |
| 17 | REC_AMT | FLOAT |  | N | 0 | ddl |
| 18 | IT_DESC | VARCHAR | 200 | Y |  | ddl |
| 19 | EMP_CODE | VARCHAR | 3 | Y |  | ddl |
| 20 | DATA_TRFR | VARCHAR | 3 | Y |  | ddl |
| 21 | HD_VCH_NO | VARCHAR | 8 | Y |  | ddl |
| 22 | USER_UPDATE | VARCHAR | 1 | Y |  | ddl |
| 23 | USER_DELETE | VARCHAR | 1 | Y |  | ddl |
| 24 | MAIN_USER | VARCHAR | 15 | Y |  | ddl |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
