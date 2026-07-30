# E_MAST

- **Cluster:** masters
- **Source:** DDL
- **Columns:** 9
- **Primary key:** CO_CODE
- **Tenant/scope keys present:** CO_CODE
- **Web mapping:** `tenant_id` + the scope keys above; preserve column names verbatim.

| # | Column | Type | Len | Null | Default | Source |
|---|--------|------|-----|------|---------|--------|
| 1 | CO_CODE 🔑 ⟨scope⟩ | VARCHAR | 2 | Y |  | ddl |
| 2 | GSP_NAME | VARCHAR | 50 | Y |  | ddl |
| 3 | ASP_ID | VARCHAR | 50 | Y |  | ddl |
| 4 | ASP_PWD | VARCHAR | 50 | Y |  | ddl |
| 5 | AUTH_URL | VARCHAR | 250 | Y |  | ddl |
| 6 | BASE_URL | VARCHAR | 250 | Y |  | ddl |
| 7 | E_LOGIN_USER | VARCHAR | 50 | Y |  | ddl |
| 8 | E_LOGIN_PWD | VARCHAR | 50 | Y |  | ddl |
| 9 | E_LOGIN_GST_NO | VARCHAR | 15 | Y |  | ddl |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
