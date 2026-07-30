# MFG_DETL

- **Cluster:** manufacturing
- **Source:** DDL
- **Columns:** 62
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
| 28 | ITM_GHT_PRC | FLOAT |  | N | 0 | ddl |
| 29 | ITM_GHT_WT | FLOAT |  | N | 0 | ddl |
| 30 | TOT_GWT | FLOAT |  | N | 0 | ddl |
| 31 | TOT_LWT | FLOAT |  | N | 0 | ddl |
| 32 | TOT_NWT | FLOAT |  | N | 0 | ddl |
| 33 | KR_JDT_WT | FLOAT |  | N | 0 | ddl |
| 34 | KR_KUNDAN_WT | FLOAT |  | N | 0 | ddl |
| 35 | KR_WAX_WT | FLOAT |  | N | 0 | ddl |
| 36 | KR_GHAT_WT | FLOAT |  | N | 0 | ddl |
| 37 | KR_MINO_WT | FLOAT |  | N | 0 | ddl |
| 38 | KR_MINO_AMT | FLOAT |  | N | 0 | ddl |
| 39 | LBR_RATE | FLOAT |  | N | 0 | ddl |
| 40 | LBR_TYPE | VARCHAR | 1 | Y |  | ddl |
| 41 | LBR_AMT | FLOAT |  | N | 0 | ddl |
| 42 | OTH_AMT | FLOAT |  | N | 0 | ddl |
| 43 | ITM_RATE | FLOAT |  | N | 0 | ddl |
| 44 | ITM_AMT | FLOAT |  | N | 0 | ddl |
| 45 | OLD_FINE | FLOAT |  | N | 0 | ddl |
| 46 | OLD_LBR_AMT | FLOAT |  | N | 0 | ddl |
| 47 | OLD_OTH | FLOAT |  | N | 0 | ddl |
| 48 | KR_NAME | VARCHAR | 5 | Y |  | ddl |
| 49 | RATE_TYPE | VARCHAR | 1 | Y |  | ddl |
| 50 | IT_TYPE | VARCHAR | 1 | Y |  | ddl |
| 51 | PR_CODE | VARCHAR | 2 | Y |  | ddl |
| 52 | ADJ_DATE | DATE |  | Y |  | ddl |
| 53 | REP_ADJ | VARCHAR | 1 | Y | 'N' | ddl |
| 54 | REP_YRCD | VARCHAR | 10 | Y |  | ddl |
| 55 | REP_DBCD | VARCHAR | 8 | Y |  | ddl |
| 56 | REP_NO | VARCHAR | 8 | Y |  | ddl |
| 57 | REP_SRNO | FLOAT |  | N | 0 | ddl |
| 58 | REP_AC_CODE | VARCHAR | 10 | Y |  | ddl |
| 59 | HD_VCH_NO | VARCHAR | 10 | Y |  | ddl |
| 60 | MAIN_USER | VARCHAR | 15 | Y |  | ddl |
| 61 | ADD_USER | VARCHAR | 15 | Y |  | ddl |
| 62 | DATA_TRFR | VARCHAR | 1 | Y |  | ddl |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
