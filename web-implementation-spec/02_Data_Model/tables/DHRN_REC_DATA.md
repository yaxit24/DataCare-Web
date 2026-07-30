# DHRN_REC_DATA

- **Cluster:** dhrn
- **Source:** DDL
- **Columns:** 48
- **Primary key:** CO_CODE, LC_CODE, CO_YEAR, CO_BOOK, VCH_NO
- **Tenant/scope keys present:** CO_CODE, LC_CODE, CO_YEAR, CO_BOOK  ·  fully tenant-keyed
- **Web mapping:** `tenant_id` + the scope keys above; preserve column names verbatim.

| # | Column | Type | Len | Null | Default | Source |
|---|--------|------|-----|------|---------|--------|
| 1 | CO_CODE 🔑 ⟨scope⟩ | VARCHAR | 2 | Y |  | ddl |
| 2 | LC_CODE 🔑 ⟨scope⟩ | VARCHAR | 2 | Y |  | ddl |
| 3 | CO_YEAR 🔑 ⟨scope⟩ | VARCHAR | 10 | Y |  | ddl |
| 4 | CO_BOOK 🔑 ⟨scope⟩ | VARCHAR | 3 | Y |  | ddl |
| 5 | VCH_NO 🔑 | VARCHAR | 8 | Y |  | ddl |
| 6 | VCH_DATE | DATE |  | Y |  | ddl |
| 7 | DHRN_BILL | VARCHAR | 8 | Y |  | ddl |
| 8 | DHRN_DATE | DATE |  | Y |  | ddl |
| 9 | DHRN_MONTH | FLOAT |  | N | 0 | ddl |
| 10 | VCH_TYPE | VARCHAR | 6 | Y |  | ddl |
| 11 | INOUT_TYPE | VARCHAR | 1 | Y |  | ddl |
| 12 | ENTRY_TYPE | VARCHAR | 1 | Y |  | ddl |
| 13 | VCH_TIME | DATETIME |  | Y |  | ddl |
| 14 | BOOK_NAME | VARCHAR | 20 | Y |  | ddl |
| 15 | AC_CODE | VARCHAR | 8 | Y |  | ddl |
| 16 | AC_NAME | VARCHAR | 50 | Y |  | ddl |
| 17 | LEDR_ACCD | VARCHAR | 8 | Y |  | ddl |
| 18 | FROM_DATE | DATE |  | Y |  | ddl |
| 19 | TO_DATE | DATE |  | Y |  | ddl |
| 20 | DHRN_AMT | FLOAT |  | N | 0 | ddl |
| 21 | DHRN_ADJ_AMT | FLOAT |  | N | 0 | ddl |
| 22 | DHRN_OS_AMT | FLOAT |  | N | 0 | ddl |
| 23 | DHRN_REC_AMT | FLOAT |  | N | 0 | ddl |
| 24 | DHRN_DAY | FLOAT |  | N | 0 | ddl |
| 25 | INT_MONTH | FLOAT |  | N | 0 | ddl |
| 26 | INT_DAY | FLOAT |  | N | 0 | ddl |
| 27 | INT_PRC | FLOAT |  | N | 0 | ddl |
| 28 | INT_AMT | FLOAT |  | N | 0 | ddl |
| 29 | INT_REC_AMT | FLOAT |  | N | 0 | ddl |
| 30 | KASAR_AMT | FLOAT |  | N | 0 | ddl |
| 31 | GOLD_AMT | FLOAT |  | N | 0 | ddl |
| 32 | GOLD_WT | FLOAT |  | N | 0 | ddl |
| 33 | ISU_LC | VARCHAR | 2 | Y |  | ddl |
| 34 | ISU_NO | VARCHAR | 10 | Y |  | ddl |
| 35 | ISU_DBCD | VARCHAR | 3 | Y |  | ddl |
| 36 | ISU_YRCD | VARCHAR | 9 | Y |  | ddl |
| 37 | VCH_DESC | VARCHAR | 255 | Y |  | ddl |
| 38 | EMP_CODE | VARCHAR | 3 | Y |  | ddl |
| 39 | MONTH_INT_AMT | FLOAT |  | N | 0 | ddl |
| 40 | PACKET_NO | VARCHAR | 15 | Y |  | ddl |
| 41 | PAN_ADJ_AMT | FLOAT |  | N | 0 | ddl |
| 42 | ADJ_INT | FLOAT |  | N | 0 | ddl |
| 43 | ADJ_DHRN | FLOAT |  | N | 0 | ddl |
| 44 | HD_VCH_NO | VARCHAR | 10 | Y |  | ddl |
| 45 | ORNA_AMT | FLOAT |  | N | 0 | ddl |
| 46 | DHRN_LIC_NO | VARCHAR | 15 | Y |  | ddl |
| 47 | DATA_TRFR | VARCHAR | 1 | Y |  | ddl |
| 48 | MAIN_USER | VARCHAR | 15 | Y |  | ddl |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
