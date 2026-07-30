# LIKE_DATA

- **Cluster:** ancillary
- **Source:** DDL
- **Columns:** 12
- **Primary key:** CO_CODE, LC_CODE, AC_MOBILE, TAG_NO
- **Tenant/scope keys present:** CO_CODE, LC_CODE
- **Web mapping:** `tenant_id` + the scope keys above; preserve column names verbatim.

| # | Column | Type | Len | Null | Default | Source |
|---|--------|------|-----|------|---------|--------|
| 1 | CO_CODE 🔑 ⟨scope⟩ | VARCHAR | 2 | N |  | ddl |
| 2 | LC_CODE 🔑 ⟨scope⟩ | VARCHAR | 2 | N |  | ddl |
| 3 | AC_MOBILE 🔑 | VARCHAR | 15 | N |  | ddl |
| 4 | TAG_NO 🔑 | VARCHAR | 15 | N |  | ddl |
| 5 | VCH_DATE | DATE |  | Y |  | ddl |
| 6 | DESIGN_IMG_ID | VARCHAR | 50 | Y | '' | ddl |
| 7 | LIKE_ITEM | VARCHAR | 1 | N | 'N' | ddl |
| 8 | SAVE_ITEM | VARCHAR | 1 | N | 'N' | ddl |
| 9 | VCH_SRNO | FLOAT |  | N | 0 | ddl |
| 10 | ITM_PCS | FLOAT |  | N | 0 | ddl |
| 11 | ITM_GWT | FLOAT |  | N | 0 | ddl |
| 12 | ITM_NWT | FLOAT |  | N | 0 | ddl |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
