# MFG_ISU_REC

- **Cluster:** manufacturing
- **Source:** DDL
- **Columns:** 55
- **Primary key:** CO_CODE, LC_CODE, CO_YEAR, CO_BOOK, VCH_NO, SR_NO, ISR_NO
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
| 7 | ISR_NO 🔑 | FLOAT |  | N | 0 | ddl |
| 8 | VCH_DATE | DATE |  | Y |  | ddl |
| 9 | VCH_TIME | DATETIME |  | Y |  | ddl |
| 10 | VCH_TYPE | VARCHAR | 6 | Y |  | ddl |
| 11 | INOUT_TYPE | VARCHAR | 1 | Y |  | ddl |
| 12 | BOOK_NAME | VARCHAR | 20 | Y |  | ddl |
| 13 | AC_CODE | VARCHAR | 8 | Y |  | ddl |
| 14 | KR_AC_CODE | VARCHAR | 8 | Y |  | ddl |
| 15 | IT_CODE | VARCHAR | 5 | Y |  | ddl |
| 16 | LOT_NO | VARCHAR | 15 | Y |  | ddl |
| 17 | DESIGN_NO | VARCHAR | 20 | Y |  | ddl |
| 18 | ITM_SIZE | VARCHAR | 20 | Y |  | ddl |
| 19 | IT_TYPE | VARCHAR | 1 | Y |  | ddl |
| 20 | ITM_SIGN | VARCHAR | 1 | Y |  | ddl |
| 21 | IR_TYPE | VARCHAR | 1 | Y |  | ddl |
| 22 | IR_PCS | FLOAT |  | N | 0 | ddl |
| 23 | IR_WT | FLOAT |  | N | 0 | ddl |
| 24 | DM_PCS | FLOAT |  | N | 0 | ddl |
| 25 | DM_WT | FLOAT |  | N | 0 | ddl |
| 26 | ITM_GWT | FLOAT |  | N | 0 | ddl |
| 27 | ITM_NWT | FLOAT |  | N | 0 | ddl |
| 28 | ITM_TOUCH | FLOAT |  | N | 0 | ddl |
| 29 | ITM_WEST | FLOAT |  | N | 0 | ddl |
| 30 | ITM_FINE | FLOAT |  | N | 0 | ddl |
| 31 | KDM_WT | FLOAT |  | N | 0 | ddl |
| 32 | ADD_WT | FLOAT |  | N | 0 | ddl |
| 33 | LESS_WT | FLOAT |  | N | 0 | ddl |
| 34 | RTN_CHOL | FLOAT |  | N | 0 | ddl |
| 35 | RTN_KDM | FLOAT |  | N | 0 | ddl |
| 36 | RTN_GHIS | FLOAT |  | N | 0 | ddl |
| 37 | ITM_GHAT | FLOAT |  | N | 0 | ddl |
| 38 | MINO_WT | FLOAT |  | N | 0 | ddl |
| 39 | ITM_LOSS | FLOAT |  | N | 0 | ddl |
| 40 | RTN_MTRL | FLOAT |  | N | 0 | ddl |
| 41 | LBR_RATE | FLOAT |  | N | 0 | ddl |
| 42 | LBR_AMT | FLOAT |  | N | 0 | ddl |
| 43 | OTH_AMT | FLOAT |  | N | 0 | ddl |
| 44 | ITM_RATE | FLOAT |  | N | 0 | ddl |
| 45 | ITM_AMT | FLOAT |  | N | 0 | ddl |
| 46 | CR_AMT | FLOAT |  | N | 0 | ddl |
| 47 | DR_AMT | FLOAT |  | N | 0 | ddl |
| 48 | IR_LC | VARCHAR | 2 | Y |  | ddl |
| 49 | IR_YRCD | VARCHAR | 10 | Y |  | ddl |
| 50 | IR_DBCD | VARCHAR | 3 | Y |  | ddl |
| 51 | IR_NO | VARCHAR | 10 | Y |  | ddl |
| 52 | IR_SRNO | FLOAT |  | N | 0 | ddl |
| 53 | IR_AC | VARCHAR | 10 | Y |  | ddl |
| 54 | EMP_CODE | VARCHAR | 3 | Y |  | ddl |
| 55 | MAIN_USER | VARCHAR | 15 | Y |  | ddl |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
