# BILL_OS_DATA

- **Cluster:** ancillary
- **Source:** DDL
- **Columns:** 31
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
| 6 | SR_NO 🔑 | FLOAT |  | N | 0 | ddl |
| 7 | VCH_DATE | DATE |  | Y |  | ddl |
| 8 | VCH_TIME | DATETIME |  | Y |  | ddl |
| 9 | VCH_TYPE | VARCHAR | 6 | Y |  | ddl |
| 10 | INOUT_TYPE | VARCHAR | 1 | Y |  | ddl |
| 11 | ENTRY_TYPE | VARCHAR | 1 | Y |  | ddl |
| 12 | BOOK_NAME | VARCHAR | 20 | Y |  | ddl |
| 13 | AC_CODE | VARCHAR | 8 | Y |  | ddl |
| 14 | LD_CODE | VARCHAR | 8 | Y |  | ddl |
| 15 | BILL_AMT | FLOAT |  | N | 0 | ddl |
| 16 | REC_AMT | FLOAT |  | N | 0 | ddl |
| 17 | KASAR_AMT | FLOAT |  | N | 0 | ddl |
| 18 | BILL_GOLD | FLOAT |  | N | 0 | ddl |
| 19 | REC_GOLD | FLOAT |  | N | 0 | ddl |
| 20 | KASAR_GOLD | FLOAT |  | N | 0 | ddl |
| 21 | BILL_SILVER | FLOAT |  | N | 0 | ddl |
| 22 | REC_SILVER | FLOAT |  | N | 0 | ddl |
| 23 | KASAR_SILVER | FLOAT |  | N | 0 | ddl |
| 24 | BILL_LC | VARCHAR | 2 | Y |  | ddl |
| 25 | BILL_YRCD | VARCHAR | 9 | Y |  | ddl |
| 26 | BILL_DBCD | VARCHAR | 3 | Y |  | ddl |
| 27 | BILL_NO | VARCHAR | 10 | Y |  | ddl |
| 28 | BILL_HD_VCH_NO | VARCHAR | 10 | Y |  | ddl |
| 29 | MAIN_USER | VARCHAR | 15 | Y |  | ddl |
| 30 | DATA_TRFR | VARCHAR | 1 | Y |  | ddl |
| 31 | DATA_TYPE | VARCHAR | 1 | Y |  | ddl |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
