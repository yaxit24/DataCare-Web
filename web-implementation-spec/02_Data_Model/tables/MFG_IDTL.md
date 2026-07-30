# MFG_IDTL

- **Cluster:** manufacturing
- **Source:** DDL
- **Columns:** 31
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
| 9 | VCH_TYPE | VARCHAR | 6 | Y |  | ddl |
| 10 | INOUT_TYPE | VARCHAR | 1 | Y |  | ddl |
| 11 | ENTRY_TYPE | VARCHAR | 1 | Y |  | ddl |
| 12 | BOOK_NAME | VARCHAR | 20 | Y |  | ddl |
| 13 | AC_CODE | VARCHAR | 8 | Y |  | ddl |
| 14 | TAG_NO | VARCHAR | 15 | Y |  | ddl |
| 15 | VCH_SRNO | FLOAT |  | N | 0 | ddl |
| 16 | IT_CODE | VARCHAR | 5 | Y |  | ddl |
| 17 | IT_TYPE | VARCHAR | 1 | Y |  | ddl |
| 18 | IT_PCS | FLOAT |  | Y | 0 | ddl |
| 19 | IT_PCS_WT | FLOAT |  | Y | 0 | ddl |
| 20 | IT_GWT | FLOAT |  | Y | 0 | ddl |
| 21 | IT_CON_PRC | FLOAT |  | Y | 0 | ddl |
| 22 | IT_CON_WT | FLOAT |  | Y | 0 | ddl |
| 23 | IT_RATE_TYPE | VARCHAR | 1 | Y |  | ddl |
| 24 | IT_RATE | FLOAT |  | Y | 0 | ddl |
| 25 | IT_AMT | FLOAT |  | Y | 0 | ddl |
| 26 | IT_LBR_RATE | FLOAT |  | Y | 0 | ddl |
| 27 | IT_LBR_AMT | FLOAT |  | Y | 0 | ddl |
| 28 | IT_NET_AMT | FLOAT |  | Y | 0 | ddl |
| 29 | HD_VCH_NO | VARCHAR | 10 | Y |  | ddl |
| 30 | MAIN_USER | VARCHAR | 15 | Y |  | ddl |
| 31 | OLD_ITM_ISU | VARCHAR | 1 | Y | 'N' | ddl |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
