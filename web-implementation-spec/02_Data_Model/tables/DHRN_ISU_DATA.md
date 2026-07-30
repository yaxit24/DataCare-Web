# DHRN_ISU_DATA

- **Cluster:** dhrn
- **Source:** DDL
- **Columns:** 44
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
| 7 | VCH_TYPE | VARCHAR | 6 | Y |  | ddl |
| 8 | INOUT_TYPE | VARCHAR | 1 | Y |  | ddl |
| 9 | ENTRY_TYPE | VARCHAR | 1 | Y |  | ddl |
| 10 | VCH_TIME | DATETIME |  | Y |  | ddl |
| 11 | BOOK_NAME | VARCHAR | 20 | Y |  | ddl |
| 12 | AC_CODE | VARCHAR | 8 | Y |  | ddl |
| 13 | AC_NAME | VARCHAR | 50 | Y |  | ddl |
| 14 | LEDR_ACCD | VARCHAR | 8 | Y |  | ddl |
| 15 | DHRN_BILL | VARCHAR | 8 | Y |  | ddl |
| 16 | TO_DATE | DATE |  | Y |  | ddl |
| 17 | DHRN_AMT | FLOAT |  | N | 0 | ddl |
| 18 | DHRN_REC_AMT | FLOAT |  | N | 0 | ddl |
| 19 | DHRN_MONTH | FLOAT |  | N | 0 | ddl |
| 20 | INT_MONTH | FLOAT |  | N | 0 | ddl |
| 21 | INT_PRC | FLOAT |  | N | 0 | ddl |
| 22 | INT_AMT | FLOAT |  | N | 0 | ddl |
| 23 | INT_REC_AMT | FLOAT |  | N | 0 | ddl |
| 24 | GOLD_DESC | VARCHAR | 255 | Y |  | ddl |
| 25 | GOLD_AMT | FLOAT |  | N | 0 | ddl |
| 26 | GOLD_WT | FLOAT |  | N | 0 | ddl |
| 27 | VCH_DESC | VARCHAR | 255 | Y |  | ddl |
| 28 | EMP_CODE | VARCHAR | 3 | Y |  | ddl |
| 29 | MONTH_INT_AMT | FLOAT |  | N | 0 | ddl |
| 30 | OLD_ISU_NO | VARCHAR | 10 | Y |  | ddl |
| 31 | OLD_ISU_LC | VARCHAR | 2 | Y |  | ddl |
| 32 | OLD_ISU_YRCD | VARCHAR | 9 | Y |  | ddl |
| 33 | OLD_ISU_DBCD | VARCHAR | 3 | Y |  | ddl |
| 34 | OLD_ITEM_ADJ | VARCHAR | 1 | Y |  | ddl |
| 35 | INT_DAYS | FLOAT |  | N | 0 | ddl |
| 36 | OTH_AMT | FLOAT |  | N | 0 | ddl |
| 37 | PACKET_NO | VARCHAR | 15 | Y |  | ddl |
| 38 | HD_VCH_NO | VARCHAR | 18 | Y |  | ddl |
| 39 | MAIN_USER | VARCHAR | 15 | Y |  | ddl |
| 40 | ISU_REC | VARCHAR | 1 | Y |  | ddl |
| 41 | GOLD_NWT | FLOAT |  | N | 0 | ddl |
| 42 | SILVER_NWT | FLOAT |  | N | 0 | ddl |
| 43 | DHRN_LIC_NO | VARCHAR | 15 | Y |  | ddl |
| 44 | DATA_TRFR | VARCHAR | 1 | Y |  | ddl |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
