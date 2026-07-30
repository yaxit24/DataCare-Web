# DHRN_DATA

- **Cluster:** dhrn
- **Source:** DDL
- **Columns:** 33
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
| 8 | FROM_DATE | DATE |  | Y |  | ddl |
| 9 | TO_DATE | DATE |  | Y |  | ddl |
| 10 | VCH_TYPE | VARCHAR | 6 | Y |  | ddl |
| 11 | INOUT_TYPE | VARCHAR | 1 | Y |  | ddl |
| 12 | ENTRY_TYPE | VARCHAR | 1 | Y |  | ddl |
| 13 | VCH_TIME | DATETIME |  | Y |  | ddl |
| 14 | BOOK_NAME | VARCHAR | 20 | Y |  | ddl |
| 15 | AC_CODE | VARCHAR | 8 | Y |  | ddl |
| 16 | DHRN_AMT | FLOAT |  | N | 0 | ddl |
| 17 | DHRN_REC_AMT | FLOAT |  | N | 0 | ddl |
| 18 | INT_PRC | FLOAT |  | N | 0 | ddl |
| 19 | INT_AMT | FLOAT |  | N | 0 | ddl |
| 20 | INT_REC_AMT | FLOAT |  | N | 0 | ddl |
| 21 | ISU_LC | VARCHAR | 2 | Y |  | ddl |
| 22 | ISU_YRCD | VARCHAR | 9 | Y |  | ddl |
| 23 | ISU_DBCD | VARCHAR | 3 | Y |  | ddl |
| 24 | ISU_NO | VARCHAR | 10 | Y |  | ddl |
| 25 | HD_VCH_NO | VARCHAR | 10 | Y |  | ddl |
| 26 | GOLD_AMT | FLOAT |  | N | 0 | ddl |
| 27 | REMARKS | VARCHAR | 255 | Y |  | ddl |
| 28 | INT_DAYS | FLOAT |  | N | 0 | ddl |
| 29 | ADJ_DHRN | FLOAT |  | N | 0 | ddl |
| 30 | MAIN_USER | VARCHAR | 15 | Y |  | ddl |
| 31 | DATA_TRFR | VARCHAR | 1 | Y |  | ddl |
| 32 | DHRN_LIC_NO | VARCHAR | 15 | Y |  | ddl |
| 33 | REC_DATE | DATE |  | Y |  | ddl |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
