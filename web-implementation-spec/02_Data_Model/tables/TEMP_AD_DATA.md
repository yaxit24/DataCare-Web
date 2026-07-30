# TEMP_AD_DATA

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
| 6 | SR_NO | FLOAT |  | Y | 0 | ddl |
| 7 | VCH_DATE | DATE |  | Y |  | ddl |
| 8 | SCHM_DATE | DATE |  | Y |  | ddl |
| 9 | SCHM_CODE | VARCHAR | 3 | Y |  | ddl |
| 10 | MEMB_CODE | VARCHAR | 5 | Y |  | ddl |
| 11 | REC_AC | VARCHAR | 8 | Y |  | ddl |
| 12 | ITM_GWT | FLOAT |  | N | 0 | ddl |
| 13 | ITM_RATE | FLOAT |  | N | 0 | ddl |
| 14 | REC_AMT | FLOAT |  | N | 0 | ddl |
| 15 | BAL_AMT | FLOAT |  | N | 0 | ddl |
| 16 | CHQ_NO | VARCHAR | 8 | Y |  | ddl |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
