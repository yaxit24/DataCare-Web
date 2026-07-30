# DG_GOLD_DATA

- **Cluster:** ancillary
- **Source:** DDL
- **Columns:** 34
- **Primary key:** CO_CODE, LC_CODE, CO_YEAR, CO_BOOK, VCH_NO, SR_NO
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
| 7 | VCH_DATE | DATE |  | Y |  | ddl |
| 8 | VCH_TIME | DATETIME |  | N | GETDATE() | ddl |
| 9 | VCH_TYPE | VARCHAR | 6 | Y | 'N' | ddl |
| 10 | INOUT_TYPE | VARCHAR | 1 | Y | 'N' | ddl |
| 11 | ENTRY_TYPE | VARCHAR | 1 | Y | 'N' | ddl |
| 12 | BOOK_NAME | VARCHAR | 20 | Y | 'N' | ddl |
| 13 | AC_CODE | VARCHAR | 10 | N |  | ddl |
| 14 | AC_NAME | VARCHAR | 50 | N |  | ddl |
| 15 | AC_MOBILE | VARCHAR | 15 | N |  | ddl |
| 16 | ITM_RATE | FLOAT |  | N | 0 | ddl |
| 17 | ITM_AMT | FLOAT |  | N | 0 | ddl |
| 18 | ITM_FINE | FLOAT |  | N | 0 | ddl |
| 19 | LDR_AC | VARCHAR | 10 | N |  | ddl |
| 20 | TAX_CODE | VARCHAR | 2 | Y | '10' | ddl |
| 21 | TAX_PRC | FLOAT |  | N | 0 | ddl |
| 22 | TAX_AMT | FLOAT |  | N | 0 | ddl |
| 23 | TOT_AMT | FLOAT |  | N | 0 | ddl |
| 24 | ITM_TYPE | VARCHAR | 1 | N | 'G' | ddl |
| 25 | ITM_SIGN | VARCHAR | 1 | N | '+' | ddl |
| 26 | DATA_TRFR | VARCHAR | 1 | N | 'N' | ddl |
| 27 | DATA_TYPE | VARCHAR | 1 | N | 'A' | ddl |
| 28 | APP_TRFR | VARCHAR | 1 | N | 'N' | ddl |
| 29 | EMP_CODE | VARCHAR | 5 | Y | '' | ddl |
| 30 | IT_DESC | VARCHAR | 100 | Y | '' | ddl |
| 31 | MAIN_USER | VARCHAR | 15 | Y | 'ABC' | ddl |
| 32 | HD_VCH_NO | VARCHAR | 10 | Y | '' | ddl |
| 33 | USER_UPDATE | VARCHAR | 1 | Y | 'N' | ddl |
| 34 | USER_DELETE | VARCHAR | 1 | Y | 'N' | ddl |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
