# RATE_MAST

- **Cluster:** masters
- **Source:** DDL
- **Columns:** 9
- **Primary key:** CO_CODE, LC_CODE, VCH_DATE, SR_NO
- **Tenant/scope keys present:** CO_CODE, LC_CODE
- **Web mapping:** `tenant_id` + the scope keys above; preserve column names verbatim.

| # | Column | Type | Len | Null | Default | Source |
|---|--------|------|-----|------|---------|--------|
| 1 | CO_CODE 🔑 ⟨scope⟩ | VARCHAR | 2 | N |  | ddl |
| 2 | LC_CODE 🔑 ⟨scope⟩ | VARCHAR | 2 | N |  | ddl |
| 3 | VCH_DATE 🔑 | DATE |  | N |  | ddl |
| 4 | SR_NO 🔑 | FLOAT |  | N |  | ddl |
| 5 | GR_CODE | VARCHAR | 3 | Y | '' | ddl |
| 6 | GR_NAME | VARCHAR | 40 | Y | '' | ddl |
| 7 | FINE_GL_RATE | FLOAT |  | N | 0 | ddl |
| 8 | FINE_SL_RATE | FLOAT |  | N | 0 | ddl |
| 9 | GR_RATE | FLOAT |  | N | 0 | ddl |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
