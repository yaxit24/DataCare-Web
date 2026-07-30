# POINT_MEMB

- **Cluster:** membership
- **Source:** DDL
- **Columns:** 11
- **Primary key:** CO_CODE, POINT_CODE, MEMB_CODE
- **Tenant/scope keys present:** CO_CODE
- **Web mapping:** `tenant_id` + the scope keys above; preserve column names verbatim.

| # | Column | Type | Len | Null | Default | Source |
|---|--------|------|-----|------|---------|--------|
| 1 | CO_CODE 🔑 ⟨scope⟩ | VARCHAR | 2 | Y |  | ddl |
| 2 | POINT_CODE 🔑 | VARCHAR | 2 | Y |  | ddl |
| 3 | MEMB_CODE 🔑 | VARCHAR | 10 | Y |  | ddl |
| 4 | MEMB_NAME | VARCHAR | 50 | Y |  | ddl |
| 5 | CARD_NO | VARCHAR | 20 | Y |  | ddl |
| 6 | MOBILE_NO | VARCHAR | 12 | Y |  | ddl |
| 7 | SL_POINT | VARCHAR | 1 | Y |  | ddl |
| 8 | REF_POINT | VARCHAR | 1 | Y |  | ddl |
| 9 | MEMB_POINT | VARCHAR | 1 | Y |  | ddl |
| 10 | DATA_TRFR | VARCHAR | 1 | Y | 'N' | ddl |
| 11 | LAST_BILL_DATE | DATE |  | Y |  | ddl |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
