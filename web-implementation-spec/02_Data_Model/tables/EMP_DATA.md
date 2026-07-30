# EMP_DATA

- **Cluster:** ancillary
- **Source:** DDL
- **Columns:** 35
- **Primary key:** CO_CODE, LC_CODE, CO_YEAR, CO_BOOK, VCH_NO, SR_NO
- **Tenant/scope keys present:** CO_CODE, LC_CODE, CO_YEAR, CO_BOOK  ·  fully tenant-keyed
- **Web mapping:** `tenant_id` + the scope keys above; preserve column names verbatim.

| # | Column | Type | Len | Null | Default | Source |
|---|--------|------|-----|------|---------|--------|
| 1 | CO_CODE 🔑 ⟨scope⟩ | VARCHAR | 2 | Y |  | ddl |
| 2 | LC_CODE 🔑 ⟨scope⟩ | VARCHAR | 2 | Y |  | ddl |
| 3 | CO_YEAR 🔑 ⟨scope⟩ | VARCHAR | 10 | Y |  | ddl |
| 4 | CO_BOOK 🔑 ⟨scope⟩ | VARCHAR | 3 | Y |  | ddl |
| 5 | VCH_NO 🔑 | VARCHAR | 8 | Y |  | ddl |
| 6 | SR_NO 🔑 | FLOAT |  | Y | 0 | ddl |
| 7 | VCH_DATE | DATE |  | Y |  | ddl |
| 8 | VCH_TYPE | VARCHAR | 6 | Y |  | ddl |
| 9 | INOUT_TYPE | VARCHAR | 1 | Y |  | ddl |
| 10 | ENTRY_TYPE | VARCHAR | 1 | Y |  | ddl |
| 11 | VCH_TIME | DATETIME |  | Y |  | ddl |
| 12 | BOOK_NAME | VARCHAR | 20 | Y |  | ddl |
| 13 | AC_CODE | VARCHAR | 8 | Y |  | ddl |
| 14 | AC_NAME | VARCHAR | 50 | Y |  | ddl |
| 15 | PAID_AC_CODE | VARCHAR | 8 | Y |  | ddl |
| 16 | MONTHLY_SALARY | FLOAT |  | N | 0 | ddl |
| 17 | SALARY_AMT | FLOAT |  | N | 0 | ddl |
| 18 | PAID_AMT | FLOAT |  | N | 0 | ddl |
| 19 | TDS_PRC | FLOAT |  | N | 0 | ddl |
| 20 | TDS_AMT | FLOAT |  | N | 0 | ddl |
| 21 | PF_PRC | FLOAT |  | N | 0 | ddl |
| 22 | PF_AMT | FLOAT |  | N | 0 | ddl |
| 23 | EMP_DAY | FLOAT |  | N | 0 | ddl |
| 24 | DAY_HOURS | FLOAT |  | N | 0 | ddl |
| 25 | TOT_HOURS | FLOAT |  | N | 0 | ddl |
| 26 | BANK_NAME | VARCHAR | 50 | Y |  | ddl |
| 27 | IT_DESC | VARCHAR | 100 | Y |  | ddl |
| 28 | CHQ_NO | VARCHAR | 10 | Y |  | ddl |
| 29 | EMP_CODE | VARCHAR | 3 | Y |  | ddl |
| 30 | OLD_VCH_NO | VARCHAR | 8 | Y |  | ddl |
| 31 | NEW_VCH_NO | VARCHAR | 8 | Y |  | ddl |
| 32 | DATA_TRFR | VARCHAR | 1 | Y |  | ddl |
| 33 | HD_VCH_NO | VARCHAR | 8 | Y |  | ddl |
| 34 | MAIN_USER | VARCHAR | 15 | Y |  | ddl |
| 35 | ADD_USER | VARCHAR | 15 | Y |  | ddl |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
