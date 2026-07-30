# TAG_STOCK

- **Cluster:** inventory
- **Source:** DDL
- **Columns:** 25
- **Primary key:** CO_CODE, LC_CODE, TAG_NO
- **Tenant/scope keys present:** CO_CODE, LC_CODE
- **Web mapping:** `tenant_id` + the scope keys above; preserve column names verbatim.

| # | Column | Type | Len | Null | Default | Source |
|---|--------|------|-----|------|---------|--------|
| 1 | CO_CODE 🔑 ⟨scope⟩ | VARCHAR | 2 | N |  | ddl |
| 2 | LC_CODE 🔑 ⟨scope⟩ | VARCHAR | 2 | N | '' | ddl |
| 3 | TAG_NO 🔑 | VARCHAR | 15 | N | '' | ddl |
| 4 | SR_NO | VARCHAR | 5 | Y | '' | ddl |
| 5 | STK_TYPE | VARCHAR | 1 | N | 'T' | ddl |
| 6 | DESIGN_NO | VARCHAR | 20 | Y | '' | ddl |
| 7 | ITM_SIZE | VARCHAR | 20 | Y | '' | ddl |
| 8 | IT_TYPE | VARCHAR | 1 | Y | 'G' | ddl |
| 9 | GR_CODE | VARCHAR | 3 | Y | '' | ddl |
| 10 | GR_NAME | VARCHAR | 40 | Y | '' | ddl |
| 11 | PR_CODE | VARCHAR | 2 | Y | '' | ddl |
| 12 | PR_NAME | VARCHAR | 40 | Y | '' | ddl |
| 13 | GR_RATE | FLOAT |  | N | 0 | ddl |
| 14 | ITM_PCS | FLOAT |  | N | 0 | ddl |
| 15 | ITM_GWT | FLOAT |  | N | 0 | ddl |
| 16 | ITM_NWT | FLOAT |  | N | 0 | ddl |
| 17 | LBR_PRC | FLOAT |  | N | 0 | ddl |
| 18 | LBR_TYPE | VARCHAR | 1 | N | 'G' | ddl |
| 19 | LBR_RATE | FLOAT |  | N | 0 | ddl |
| 20 | LBR_AMT | FLOAT |  | N | 0 | ddl |
| 21 | OTH_AMT | FLOAT |  | N | 0 | ddl |
| 22 | ITM_MRP | FLOAT |  | N | 0 | ddl |
| 23 | VCH_SRNO | FLOAT |  | N | 0 | ddl |
| 24 | DESIGN_IMG_ID | VARCHAR | 50 | Y | 'N' | ddl |
| 25 | MAIN_USER | VARCHAR | 15 | Y | '' | ddl |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
