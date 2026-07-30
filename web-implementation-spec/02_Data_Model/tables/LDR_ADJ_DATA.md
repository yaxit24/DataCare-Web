# LDR_ADJ_DATA

- **Cluster:** ancillary
- **Source:** DDL
- **Columns:** 29
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
| 14 | IT_TYPE | VARCHAR | 1 | Y |  | ddl |
| 15 | CR_AMT | FLOAT |  | N | 0 | ddl |
| 16 | DR_AMT | FLOAT |  | N | 0 | ddl |
| 17 | DIFF_AMT | FLOAT |  | N | 0 | ddl |
| 18 | CR_FINE | FLOAT |  | N | 0 | ddl |
| 19 | DR_FINE | FLOAT |  | N | 0 | ddl |
| 20 | DIFF_FINE | FLOAT |  | N | 0 | ddl |
| 21 | IT_REMARK | VARCHAR | 255 | Y |  | ddl |
| 22 | EMP_CODE | VARCHAR | 3 | Y |  | ddl |
| 23 | ADJ_DATE | DATE |  | Y |  | ddl |
| 24 | LEDR_OK | VARCHAR | 3 | Y |  | ddl |
| 25 | HD_VCH_NO | VARCHAR | 8 | Y |  | ddl |
| 26 | DATA_TRFR | VARCHAR | 1 | Y |  | ddl |
| 27 | MAIN_USER | VARCHAR | 15 | Y |  | ddl |
| 28 | USER_UPDATE | VARCHAR | 1 | Y |  | ddl |
| 29 | USER_DELETE | VARCHAR | 1 | Y |  | ddl |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
