# MFG_ASMBL_DETL

- **Cluster:** manufacturing
- **Source:** DDL
- **Columns:** 52
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
| 7 | OLD_SRNO | FLOAT |  | N | 0 | ddl |
| 8 | VCH_DATE | DATE |  | Y |  | ddl |
| 9 | VCH_TIME | DATETIME |  | Y |  | ddl |
| 10 | VCH_TYPE | VARCHAR | 6 | Y |  | ddl |
| 11 | INOUT_TYPE | VARCHAR | 1 | Y |  | ddl |
| 12 | ENTRY_TYPE | VARCHAR | 1 | Y |  | ddl |
| 13 | BOOK_NAME | VARCHAR | 20 | Y |  | ddl |
| 14 | AC_CODE | VARCHAR | 8 | Y |  | ddl |
| 15 | IT_CODE | VARCHAR | 5 | Y |  | ddl |
| 16 | TAG_NO | VARCHAR | 15 | Y |  | ddl |
| 17 | VCH_SRNO | FLOAT |  | N | 0 | ddl |
| 18 | LOT_NO | VARCHAR | 15 | Y |  | ddl |
| 19 | DESIGN_NO | VARCHAR | 15 | Y |  | ddl |
| 20 | DESIGN_SRNO | FLOAT |  | N | 0 | ddl |
| 21 | ITM_PCS | FLOAT |  | N | 0 | ddl |
| 22 | ITM_GWT | FLOAT |  | N | 0 | ddl |
| 23 | ITM_OTH_WT | FLOAT |  | N | 0 | ddl |
| 24 | ITM_NWT | FLOAT |  | N | 0 | ddl |
| 25 | ITM_TOUCH | FLOAT |  | N | 0 | ddl |
| 26 | ITM_WEST_PRC | FLOAT |  | N | 0 | ddl |
| 27 | ITM_FINE | FLOAT |  | N | 0 | ddl |
| 28 | LBR_RATE | FLOAT |  | N | 0 | ddl |
| 29 | LBR_TYPE | VARCHAR | 1 | Y |  | ddl |
| 30 | LBR_AMT | FLOAT |  | N | 0 | ddl |
| 31 | OTH_AMT | FLOAT |  | N | 0 | ddl |
| 32 | NET_AMT | FLOAT |  | N | 0 | ddl |
| 33 | REP_YRCD | VARCHAR | 10 | Y |  | ddl |
| 34 | REP_DBCD | VARCHAR | 8 | Y |  | ddl |
| 35 | REP_NO | VARCHAR | 8 | Y |  | ddl |
| 36 | REP_SRNO | FLOAT |  | N | 0 | ddl |
| 37 | REP_AC_CODE | VARCHAR | 10 | Y |  | ddl |
| 38 | ORD_YRCD | VARCHAR | 10 | Y |  | ddl |
| 39 | ORD_DBCD | VARCHAR | 8 | Y |  | ddl |
| 40 | ORD_NO | VARCHAR | 8 | Y |  | ddl |
| 41 | ORD_SRNO | FLOAT |  | N | 0 | ddl |
| 42 | ORD_AC_CODE | VARCHAR | 10 | Y |  | ddl |
| 43 | ORD_PCS | FLOAT |  | N | 0 | ddl |
| 44 | ORD_GWT | FLOAT |  | N | 0 | ddl |
| 45 | ORD_OTH_WT | FLOAT |  | N | 0 | ddl |
| 46 | ORD_NWT | FLOAT |  | N | 0 | ddl |
| 47 | REC_YRCD | VARCHAR | 10 | Y |  | ddl |
| 48 | REC_DBCD | VARCHAR | 8 | Y |  | ddl |
| 49 | REC_NO | VARCHAR | 8 | Y |  | ddl |
| 50 | REC_SRNO | FLOAT |  | N | 0 | ddl |
| 51 | MAIN_USER | VARCHAR | 15 | Y |  | ddl |
| 52 | ADD_USER | VARCHAR | 15 | Y |  | ddl |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
