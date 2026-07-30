# TEMP_ADD

- **Cluster:** ancillary
- **Source:** DDL
- **Columns:** 18
- **Primary key:** (none recovered)
- **Tenant/scope keys present:** CO_CODE, LC_CODE
- **Web mapping:** `tenant_id` + the scope keys above; preserve column names verbatim.

| # | Column | Type | Len | Null | Default | Source |
|---|--------|------|-----|------|---------|--------|
| 1 | CO_CODE ⟨scope⟩ | VARCHAR | 2 | Y |  | ddl |
| 2 | LC_CODE ⟨scope⟩ | VARCHAR | 2 | Y |  | ddl |
| 3 | AC_CODE | VARCHAR | 10 | Y |  | ddl |
| 4 | AC_NAME | VARCHAR | 50 | Y |  | ddl |
| 5 | AC_ADD1 | VARCHAR | 50 | Y |  | ddl |
| 6 | AC_ADD2 | VARCHAR | 50 | Y |  | ddl |
| 7 | AC_ADD3 | VARCHAR | 50 | Y |  | ddl |
| 8 | AC_CITY | VARCHAR | 30 | Y |  | ddl |
| 9 | AC_PIN | VARCHAR | 10 | Y |  | ddl |
| 10 | AC_PHONE | VARCHAR | 20 | Y |  | ddl |
| 11 | AC_MOBILE | VARCHAR | 21 | Y |  | ddl |
| 12 | AC_MOBILE2 | VARCHAR | 21 | Y |  | ddl |
| 13 | AC_EMAIL | VARCHAR | 50 | Y |  | ddl |
| 14 | AC_PARSON | VARCHAR | 50 | Y |  | ddl |
| 15 | AC_AREA | VARCHAR | 50 | Y |  | ddl |
| 16 | B_DATE | DATE |  | Y |  | ddl |
| 17 | A_DATE | DATE |  | Y |  | ddl |
| 18 | L_DATE | DATE |  | Y |  | ddl |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
