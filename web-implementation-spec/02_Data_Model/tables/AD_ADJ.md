# AD_ADJ

- **Cluster:** ancillary
- **Source:** DDL
- **Columns:** 32
- **Primary key:** CO_CODE, LC_CODE, CO_YEAR, CO_BOOK, VCH_NO, SR_NO
- **Tenant/scope keys present:** CO_CODE, LC_CODE, CO_YEAR, CO_BOOK  ·  fully tenant-keyed
- **Web mapping:** `tenant_id` + the scope keys above; preserve column names verbatim.

| # | Column | Type | Len | Null | Default | Source |
|---|--------|------|-----|------|---------|--------|
| 1 | CO_CODE 🔑 ⟨scope⟩ | VARCHAR | 2 | Y |  | ddl |
| 2 | LC_CODE 🔑 ⟨scope⟩ | VARCHAR | 2 | Y |  | ddl |
| 3 | CO_YEAR 🔑 ⟨scope⟩ | VARCHAR | 9 | Y |  | ddl |
| 4 | CO_BOOK 🔑 ⟨scope⟩ | VARCHAR | 3 | Y |  | ddl |
| 5 | VCH_NO 🔑 | VARCHAR | 10 | Y |  | ddl |
| 6 | SR_NO 🔑 | FLOAT |  | N | 0 | ddl |
| 7 | VCH_DATE | DATE |  | Y |  | ddl |
| 8 | VCH_TIME | DATETIME |  | Y |  | ddl |
| 9 | VCH_TYPE | VARCHAR | 5 | Y |  | ddl |
| 10 | INOUT_TYPE | VARCHAR | 1 | Y |  | ddl |
| 11 | ENTRY_TYPE | VARCHAR | 1 | Y |  | ddl |
| 12 | BOOK_NAME | VARCHAR | 50 | Y |  | ddl |
| 13 | SCHM_CODE | VARCHAR | 3 | Y |  | ddl |
| 14 | MEMB_CODE | VARCHAR | 5 | Y |  | ddl |
| 15 | MEMB_AMT | FLOAT |  | N | 0 | ddl |
| 16 | MEMB_BONUS | FLOAT |  | N | 0 | ddl |
| 17 | MEMB_LESS | FLOAT |  | N | 0 | ddl |
| 18 | ADJ_AMT | FLOAT |  | N | 0 | ddl |
| 19 | AC_CODE | VARCHAR | 8 | Y |  | ddl |
| 20 | AC_NAME | VARCHAR | 50 | Y |  | ddl |
| 21 | SBILL_NO | VARCHAR | 10 | Y |  | ddl |
| 22 | SBILL_LC_CODE | VARCHAR | 2 | Y |  | ddl |
| 23 | SBILL_YRCD | VARCHAR | 10 | Y |  | ddl |
| 24 | SBILL_DBCD | VARCHAR | 3 | Y |  | ddl |
| 25 | SBILL_AMT | FLOAT |  | N | 0 | ddl |
| 26 | SBILL_HD_VCH_NO | VARCHAR | 10 | Y |  | ddl |
| 27 | EMP_CODE | VARCHAR | 3 | Y |  | ddl |
| 28 | VCH_DESC | VARCHAR | 50 | Y |  | ddl |
| 29 | SIGN | VARCHAR | 1 | Y |  | ddl |
| 30 | HD_VCH_NO | VARCHAR | 8 | Y |  | ddl |
| 31 | MAIN_USER | VARCHAR | 15 | Y |  | ddl |
| 32 | DATA_TRFR | VARCHAR | 1 | Y |  | ddl |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
