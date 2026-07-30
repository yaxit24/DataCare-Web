# VP_ADJ_DATA

- **Cluster:** bullion_tour
- **Source:** DDL
- **Columns:** 28
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
| 8 | VCH_TYPE | VARCHAR | 5 | Y |  | ddl |
| 9 | INOUT_TYPE | VARCHAR | 1 | Y |  | ddl |
| 10 | ENTRY_TYPE | VARCHAR | 1 | Y |  | ddl |
| 11 | BOOK_NAME | VARCHAR | 15 | Y |  | ddl |
| 12 | VCH_TIME | DATETIME |  | Y |  | ddl |
| 13 | AC_CODE | VARCHAR | 8 | Y |  | ddl |
| 14 | AC_NAME | VARCHAR | 50 | Y |  | ddl |
| 15 | REC_AMT | FLOAT |  | N | 0 | ddl |
| 16 | KASAR_AMT | FLOAT |  | N | 0 | ddl |
| 17 | IT_DESC | VARCHAR | 150 | Y |  | ddl |
| 18 | EMP_CODE | VARCHAR | 3 | Y |  | ddl |
| 19 | DATA_TRFR | VARCHAR | 1 | Y | 'N' | ddl |
| 20 | HD_VCH_NO | VARCHAR | 8 | Y |  | ddl |
| 21 | VP_NO | VARCHAR | 8 | Y |  | ddl |
| 22 | VP_LC_CODE | VARCHAR | 2 | Y |  | ddl |
| 23 | VP_YRCD | VARCHAR | 10 | Y |  | ddl |
| 24 | VP_DBCD | VARCHAR | 8 | Y |  | ddl |
| 25 | ANGDIYA_AC | VARCHAR | 8 | Y |  | ddl |
| 26 | ANGDIYA_NAME | VARCHAR | 50 | Y |  | ddl |
| 27 | MAIN_USER | VARCHAR | 15 | Y |  | ddl |
| 28 | ADD_USER | VARCHAR | 15 | Y |  | ddl |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
