# AD_DATA

- **Cluster:** ancillary
- **Source:** DDL
- **Columns:** 33
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
| 8 | SCHM_CODE | VARCHAR | 3 | N | '' | ddl |
| 9 | SCHM_DATE | DATE |  | Y |  | ddl |
| 10 | MEMB_CODE | VARCHAR | 5 | N | '' | ddl |
| 11 | MEMB_AMT | FLOAT |  | N | 0 | ddl |
| 12 | TOT_AMT | FLOAT |  | N | 0 | ddl |
| 13 | IT_DESC | VARCHAR | 50 | Y | '' | ddl |
| 14 | MONTH_CODE | VARCHAR | 2 | Y | '' | ddl |
| 15 | EMP_CODE | VARCHAR | 3 | N | '' | ddl |
| 16 | ENT_TYPE | VARCHAR | 1 | Y | '' | ddl |
| 17 | REC_AC | VARCHAR | 8 | Y | '' | ddl |
| 18 | ITM_GWT | FLOAT |  | N | 0 | ddl |
| 19 | ITM_RATE | FLOAT |  | N | 0 | ddl |
| 20 | BANK_NAME | VARCHAR | 50 | Y | '' | ddl |
| 21 | CHQ_NO | VARCHAR | 10 | Y | '' | ddl |
| 22 | ENTRY_TIME | DATE |  | Y |  | ddl |
| 23 | HD_VCH_NO | VARCHAR | 10 | Y | '' | ddl |
| 24 | MAIN_USER | VARCHAR | 15 | Y | '' | ddl |
| 25 | DATA_TRFR | VARCHAR | 1 | Y | 'N' | ddl |
| 26 | VCH_TIME | DATE |  | Y |  | ddl |
| 27 | VCH_TYPE | VARCHAR | 5 | Y | '' | ddl |
| 28 | INOUT_TYPE | VARCHAR | 1 | Y | '' | ddl |
| 29 | BOOK_NAME | VARCHAR | 50 | Y | '' | ddl |
| 30 | USER_UPDATE | VARCHAR | 1 | Y | 'N' | ddl |
| 31 | USER_DELETE | VARCHAR | 1 | Y | 'N' | ddl |
| 32 | WITH_UPI | VARCHAR | 1 | Y | 'N' | ddl |
| 33 | UPI_NAME | VARCHAR | 255 | Y | '' | ddl |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
