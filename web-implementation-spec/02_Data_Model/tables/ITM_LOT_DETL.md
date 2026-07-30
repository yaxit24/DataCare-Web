# ITM_LOT_DETL

- **Cluster:** inventory
- **Source:** DDL
- **Columns:** 46
- **Primary key:** CO_CODE, LC_CODE, CO_YEAR, CO_BOOK, VCH_NO, SR_NO
- **Tenant/scope keys present:** CO_CODE, LC_CODE, CO_YEAR, CO_BOOK  ·  fully tenant-keyed
- **Web mapping:** `tenant_id` + the scope keys above; preserve column names verbatim.

| # | Column | Type | Len | Null | Default | Source |
|---|--------|------|-----|------|---------|--------|
| 1 | CO_CODE 🔑 ⟨scope⟩ | VARCHAR | 2 | Y |  | ddl |
| 2 | LC_CODE 🔑 ⟨scope⟩ | VARCHAR | 2 | Y |  | ddl |
| 3 | CO_YEAR 🔑 ⟨scope⟩ | VARCHAR | 10 | Y |  | ddl |
| 4 | CO_BOOK 🔑 ⟨scope⟩ | VARCHAR | 3 | Y |  | ddl |
| 5 | VCH_NO 🔑 | VARCHAR | 8 | Y |  | ddl |
| 6 | SR_NO 🔑 | FLOAT |  | N | 0 | ddl |
| 7 | VCH_DATE | DATE |  | Y |  | ddl |
| 8 | VCH_TYPE | VARCHAR | 6 | Y |  | ddl |
| 9 | INOUT_TYPE | VARCHAR | 1 | Y |  | ddl |
| 10 | ENTRY_TYPE | VARCHAR | 1 | Y |  | ddl |
| 11 | BOOK_NAME | VARCHAR | 20 | Y |  | ddl |
| 12 | AC_CODE | VARCHAR | 8 | Y |  | ddl |
| 13 | LOT_NO | VARCHAR | 10 | Y |  | ddl |
| 14 | DESIGN_NO | VARCHAR | 20 | Y |  | ddl |
| 15 | TBL_CODE | VARCHAR | 3 | Y |  | ddl |
| 16 | ITM_SIZE | VARCHAR | 20 | Y |  | ddl |
| 17 | IT_CODE | VARCHAR | 5 | Y |  | ddl |
| 18 | PR_CODE | VARCHAR | 5 | Y |  | ddl |
| 19 | IT_TYPE | VARCHAR | 1 | Y |  | ddl |
| 20 | ITM_PCS | FLOAT |  | Y | 0 | ddl |
| 21 | ITM_GWT | FLOAT |  | Y | 0 | ddl |
| 22 | ITM_OTH_WT | FLOAT |  | Y | 0 | ddl |
| 23 | ITM_NWT | FLOAT |  | Y | 0 | ddl |
| 24 | ITM_TOUCH | FLOAT |  | Y | 0 | ddl |
| 25 | ITM_WEST_PRC | FLOAT |  | Y | 0 | ddl |
| 26 | ITM_FINE | FLOAT |  | Y | 0 | ddl |
| 27 | KR_OTH_WT | FLOAT |  | Y | 0 | ddl |
| 28 | KR_NET_WT | FLOAT |  | Y | 0 | ddl |
| 29 | KR_TOUCH | FLOAT |  | Y | 0 | ddl |
| 30 | KR_WEST_PRC | FLOAT |  | Y | 0 | ddl |
| 31 | KR_FINE | FLOAT |  | Y | 0 | ddl |
| 32 | LBR_TYPE | VARCHAR | 1 | Y |  | ddl |
| 33 | LBR_PRC | FLOAT |  | Y | 0 | ddl |
| 34 | LBR_RATE | FLOAT |  | Y | 0 | ddl |
| 35 | LBR_AMT | FLOAT |  | Y | 0 | ddl |
| 36 | OTH_AMT | FLOAT |  | Y | 0 | ddl |
| 37 | ITM_RATE | FLOAT |  | Y | 0 | ddl |
| 38 | ITM_AMT | FLOAT |  | Y | 0 | ddl |
| 39 | HD_VCH_NO | VARCHAR | 10 | Y |  | ddl |
| 40 | KR_CODE | VARCHAR | 5 | Y |  | ddl |
| 41 | EMP_CODE | VARCHAR | 5 | N | '' | ddl |
| 42 | ITM_REMARK | VARCHAR | 50 | Y |  | ddl |
| 43 | DESIGN_IMG_ID | VARCHAR | 50 | Y |  | ddl |
| 44 | DATA_TYPE | VARCHAR | 1 | N | 'A' | ddl |
| 45 | DATA_TRFR | VARCHAR | 1 | N | 'N' | ddl |
| 46 | MAIN_USER | VARCHAR | 15 | Y |  | ddl |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
