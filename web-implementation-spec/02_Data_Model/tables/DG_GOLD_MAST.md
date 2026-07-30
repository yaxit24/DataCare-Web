# DG_GOLD_MAST

- **Cluster:** masters
- **Source:** DDL
- **Columns:** 14
- **Primary key:** CO_CODE, COUNTRY_CODE
- **Tenant/scope keys present:** CO_CODE
- **Web mapping:** `tenant_id` + the scope keys above; preserve column names verbatim.

| # | Column | Type | Len | Null | Default | Source |
|---|--------|------|-----|------|---------|--------|
| 1 | CO_CODE 🔑 ⟨scope⟩ | VARCHAR | 2 | N |  | ddl |
| 2 | COUNTRY_CODE 🔑 | VARCHAR | 4 | N | 'INR' | ddl |
| 3 | SHOW_DG_GOLD | VARCHAR | 1 | N | 'N' | ddl |
| 4 | API_KEY | VARCHAR | 150 | N | '' | ddl |
| 5 | CURRENCY_RATE | FLOAT |  | N | 0 | ddl |
| 6 | OUNCES_CONV | FLOAT |  | N | 0 | ddl |
| 7 | GOLD_CONV | FLOAT |  | N | 0 | ddl |
| 8 | SILVER_CONV | FLOAT |  | N | 0 | ddl |
| 9 | CUST_BUY_RATE_ADD | FLOAT |  | N | 0 | ddl |
| 10 | CUST_SALE_RATE_LESS | FLOAT |  | N | 0 | ddl |
| 11 | BOOK_WITH_LIVE_RATE | VARCHAR | 1 | N | 'N' | ddl |
| 12 | GOLD_FIX_RATE | FLOAT |  | N | 0 | ddl |
| 13 | SILVER_FIX_RATE | FLOAT |  | N | 0 | ddl |
| 14 | MAIN_USER | VARCHAR | 15 | Y | 'ABC' | ddl |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
