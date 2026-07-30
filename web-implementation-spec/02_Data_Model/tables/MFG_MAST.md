# MFG_MAST

- **Cluster:** manufacturing
- **Source:** DDL
- **Columns:** 9
- **Primary key:** CO_CODE, SM_MAIN_CODE
- **Tenant/scope keys present:** CO_CODE, CO_BOOK
- **Web mapping:** `tenant_id` + the scope keys above; preserve column names verbatim.

| # | Column | Type | Len | Null | Default | Source |
|---|--------|------|-----|------|---------|--------|
| 1 | CO_CODE 🔑 ⟨scope⟩ | VARCHAR | 2 | Y |  | ddl |
| 2 | SM_MAIN_CODE 🔑 | VARCHAR | 2 | Y |  | ddl |
| 3 | SM_CODE | VARCHAR | 2 | Y |  | ddl |
| 4 | CO_BOOK ⟨scope⟩ | VARCHAR | 3 | Y |  | ddl |
| 5 | BOOK_SNAME | VARCHAR | 5 | Y |  | ddl |
| 6 | MENU_NAME | VARCHAR | 50 | Y |  | ddl |
| 7 | CUR_IN_USE | VARCHAR | 1 | N | 'N' | ddl |
| 8 | ENTRY_TYPE | VARCHAR | 2 | Y |  | ddl |
| 9 | STK_REC | VARCHAR | 1 | N | 'N' | ddl |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
