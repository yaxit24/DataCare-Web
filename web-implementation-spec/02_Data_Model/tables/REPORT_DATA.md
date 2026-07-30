# REPORT_DATA

- **Cluster:** ancillary
- **Source:** DDL
- **Columns:** 16
- **Primary key:** (none recovered)
- **Tenant/scope keys present:** CO_CODE, LC_CODE
- **Web mapping:** `tenant_id` + the scope keys above; preserve column names verbatim.

| # | Column | Type | Len | Null | Default | Source |
|---|--------|------|-----|------|---------|--------|
| 1 | CO_CODE ⟨scope⟩ | VARCHAR | 2 | Y |  | ddl |
| 2 | LC_CODE ⟨scope⟩ | VARCHAR | 2 | Y |  | ddl |
| 3 | SR_NO | VARCHAR | 5 | Y |  | ddl |
| 4 | COL_1 | VARCHAR | 50 | Y |  | ddl |
| 5 | COL_2 | VARCHAR | 50 | Y |  | ddl |
| 6 | COL_3 | VARCHAR | 50 | Y |  | ddl |
| 7 | COL_4 | VARCHAR | 50 | Y |  | ddl |
| 8 | COL_5 | VARCHAR | 50 | Y |  | ddl |
| 9 | COL_6 | VARCHAR | 50 | Y |  | ddl |
| 10 | COL_7 | VARCHAR | 50 | Y |  | ddl |
| 11 | COL_8 | VARCHAR | 50 | Y |  | ddl |
| 12 | COL_9 | VARCHAR | 50 | Y |  | ddl |
| 13 | COL_10 | VARCHAR | 50 | Y |  | ddl |
| 14 | COL_11 | VARCHAR | 50 | Y |  | ddl |
| 15 | COL_12 | VARCHAR | 50 | Y |  | ddl |
| 16 | COL_13 | VARCHAR | 50 | Y |  | ddl |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
