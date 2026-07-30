# USER_DATA

- **Cluster:** ancillary
- **Source:** DDL
- **Columns:** 16
- **Primary key:** (none recovered)
- **Tenant/scope keys present:** CO_CODE, LC_CODE, CO_YEAR, CO_BOOK  ·  fully tenant-keyed
- **Web mapping:** `tenant_id` + the scope keys above; preserve column names verbatim.

| # | Column | Type | Len | Null | Default | Source |
|---|--------|------|-----|------|---------|--------|
| 1 | CO_CODE ⟨scope⟩ | VARCHAR | 2 | Y |  | ddl |
| 2 | LC_CODE ⟨scope⟩ | VARCHAR | 2 | Y |  | ddl |
| 3 | CO_YEAR ⟨scope⟩ | VARCHAR | 10 | Y |  | ddl |
| 4 | CO_BOOK ⟨scope⟩ | VARCHAR | 3 | Y |  | ddl |
| 5 | VCH_NO | VARCHAR | 8 | Y |  | ddl |
| 6 | AC_CODE | VARCHAR | 8 | Y |  | ddl |
| 7 | VCH_DATE | DATE |  | Y |  | ddl |
| 8 | EDIT_DATE | DATE |  | Y |  | ddl |
| 9 | ENTRY_TIME | DATETIME |  | Y |  | ddl |
| 10 | USER_NAME | VARCHAR | 15 | Y |  | ddl |
| 11 | NEW_USER | VARCHAR | 15 | Y |  | ddl |
| 12 | BOOK_NAME | VARCHAR | 50 | Y |  | ddl |
| 13 | COL_TYPE | VARCHAR | 20 | Y |  | ddl |
| 14 | OLD_VAL | VARCHAR | 50 | Y |  | ddl |
| 15 | NEW_VAL | VARCHAR | 50 | Y |  | ddl |
| 16 | ENTRY_CHECK | VARCHAR | 1 | Y |  | ddl |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
