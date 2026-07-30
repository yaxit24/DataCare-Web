# COMM_DATA

- **Cluster:** membership
- **Source:** DDL
- **Columns:** 25
- **Primary key:** CO_CODE, LC_CODE, CO_YEAR, CO_BOOK, VCH_NO, SR_NO, ISR_NO
- **Tenant/scope keys present:** CO_CODE, LC_CODE, CO_YEAR, CO_BOOK  ·  fully tenant-keyed
- **Web mapping:** `tenant_id` + the scope keys above; preserve column names verbatim.

| # | Column | Type | Len | Null | Default | Source |
|---|--------|------|-----|------|---------|--------|
| 1 | CO_CODE 🔑 ⟨scope⟩ | VARCHAR | 2 | N |  | ddl |
| 2 | LC_CODE 🔑 ⟨scope⟩ | VARCHAR | 2 | N |  | ddl |
| 3 | CO_YEAR 🔑 ⟨scope⟩ | VARCHAR | 9 | N |  | ddl |
| 4 | CO_BOOK 🔑 ⟨scope⟩ | VARCHAR | 3 | N |  | ddl |
| 5 | VCH_NO 🔑 | VARCHAR | 10 | N |  | ddl |
| 6 | SR_NO 🔑 | FLOAT |  | N |  | ddl |
| 7 | ISR_NO 🔑 | FLOAT |  | N |  | ddl |
| 8 | VCH_DATE | DATE |  | Y |  | ddl |
| 9 | VCH_TIME | DATETIME |  | N | GETDATE() | ddl |
| 10 | VCH_TYPE | VARCHAR | 6 | Y | '' | ddl |
| 11 | INOUT_TYPE | VARCHAR | 1 | Y | 'O' | ddl |
| 12 | BOOK_NAME | VARCHAR | 20 | Y | 'N' | ddl |
| 13 | AC_CODE | VARCHAR | 10 | N |  | ddl |
| 14 | COM_TYPE | VARCHAR | 1 | N | 'W' | ddl |
| 15 | NET_AMT | FLOAT |  | N | 0 | ddl |
| 16 | LBR_AMT | FLOAT |  | N | 0 | ddl |
| 17 | TOT_NET_WT | FLOAT |  | N | 0 | ddl |
| 18 | COM_PRC | FLOAT |  | N | 0 | ddl |
| 19 | COM_WT | FLOAT |  | N | 0 | ddl |
| 20 | COM_FINE | FLOAT |  | N | 0 | ddl |
| 21 | COM_AMT | FLOAT |  | N | 0 | ddl |
| 22 | ITM_TYPE | VARCHAR | 1 | N | 'G' | ddl |
| 23 | DATA_TYPE | VARCHAR | 1 | N | 'A' | ddl |
| 24 | EMP_CODE | VARCHAR | 5 | Y | '' | ddl |
| 25 | MAIN_USER | VARCHAR | 15 | Y | 'ABC' | ddl |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
