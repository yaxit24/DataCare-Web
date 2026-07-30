# LOT_DETL

- **Cluster:** inventory
- **Source:** DDL
- **Columns:** 23
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
| 8 | VCH_TYPE | VARCHAR | 6 | Y |  | ddl |
| 9 | INOUT_TYPE | VARCHAR | 1 | Y |  | ddl |
| 10 | ENTRY_TYPE | VARCHAR | 1 | Y |  | ddl |
| 11 | BOOK_NAME | VARCHAR | 20 | Y |  | ddl |
| 12 | AC_CODE | VARCHAR | 8 | Y |  | ddl |
| 13 | LOT_NO | VARCHAR | 15 | Y |  | ddl |
| 14 | IT_CODE | VARCHAR | 5 | Y |  | ddl |
| 15 | IT_TYPE | VARCHAR | 1 | Y |  | ddl |
| 16 | IT_PCS | FLOAT |  | Y | 0 | ddl |
| 17 | IT_GWT | FLOAT |  | Y | 0 | ddl |
| 18 | IT_NWT | FLOAT |  | Y | 0 | ddl |
| 19 | IT_SIGN | VARCHAR | 1 | Y |  | ddl |
| 20 | HD_VCH_NO | VARCHAR | 10 | Y |  | ddl |
| 21 | MAIN_USER | VARCHAR | 15 | Y |  | ddl |
| 22 | DATA_TYPE | VARCHAR | 1 | N | 'A' | ddl |
| 23 | DATA_TRFR | VARCHAR | 1 | N | 'N' | ddl |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
