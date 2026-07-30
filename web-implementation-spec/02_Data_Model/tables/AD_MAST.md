# AD_MAST

- **Cluster:** masters
- **Source:** DDL
- **Columns:** 16
- **Primary key:** CO_CODE, SCHM_CODE
- **Tenant/scope keys present:** CO_CODE
- **Web mapping:** `tenant_id` + the scope keys above; preserve column names verbatim.

| # | Column | Type | Len | Null | Default | Source |
|---|--------|------|-----|------|---------|--------|
| 1 | CO_CODE 🔑 ⟨scope⟩ | VARCHAR | 2 | N |  | ddl |
| 2 | SCHM_CODE 🔑 | VARCHAR | 3 | N |  | ddl |
| 3 | SCHM_NAME | VARCHAR | 30 | Y | '' | ddl |
| 4 | SCHM_AMT | FLOAT |  | N | 0 | ddl |
| 5 | SCHM_AC | VARCHAR | 10 | Y | '' | ddl |
| 6 | SCHM_TYPE | VARCHAR | 1 | Y | '' | ddl |
| 7 | DATA_TRFR | VARCHAR | 1 | N | 'N' | ddl |
| 8 | MAIN_USER | VARCHAR | 15 | Y | '' | ddl |
| 9 | ADD_USER | VARCHAR | 15 | Y | '' | ddl |
| 10 | BONUS_PRC | FLOAT |  | N | 0 | ddl |
| 11 | SCHM_MONTH | FLOAT |  | N | 0 | ddl |
| 12 | GOLD_RATE | FLOAT |  | N | 0 | ddl |
| 13 | BONUS_MONTH | FLOAT |  | N | 0 | ddl |
| 14 | SCHM_WITH_APP | VARCHAR | 1 | N | 'N' | ddl |
| 15 | SCHM_HADING | VARCHAR | 50 | Y | '' | ddl |
| 16 | SCHM_REMARK | VARCHAR | 250 | Y | '' | ddl |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
