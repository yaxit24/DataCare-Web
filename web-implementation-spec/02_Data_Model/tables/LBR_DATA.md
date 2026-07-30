# LBR_DATA

- **Cluster:** ancillary
- **Source:** DDL
- **Columns:** 33
- **Primary key:** CO_CODE, LC_CODE, CO_YEAR, CO_BOOK, VCH_NO
- **Tenant/scope keys present:** CO_CODE, LC_CODE, CO_YEAR, CO_BOOK  ·  fully tenant-keyed
- **Web mapping:** `tenant_id` + the scope keys above; preserve column names verbatim.

| # | Column | Type | Len | Null | Default | Source |
|---|--------|------|-----|------|---------|--------|
| 1 | CO_CODE 🔑 ⟨scope⟩ | VARCHAR | 2 | Y |  | ddl |
| 2 | LC_CODE 🔑 ⟨scope⟩ | VARCHAR | 2 | Y |  | ddl |
| 3 | CO_YEAR 🔑 ⟨scope⟩ | VARCHAR | 10 | Y |  | ddl |
| 4 | CO_BOOK 🔑 ⟨scope⟩ | VARCHAR | 3 | Y |  | ddl |
| 5 | VCH_NO 🔑 | VARCHAR | 8 | Y |  | ddl |
| 6 | VCH_DATE | DATE |  | Y |  | ddl |
| 7 | VCH_TYPE | VARCHAR | 6 | Y |  | ddl |
| 8 | INOUT_TYPE | VARCHAR | 1 | Y |  | ddl |
| 9 | ENTRY_TYPE | VARCHAR | 1 | Y |  | ddl |
| 10 | VCH_TIME | DATETIME |  | Y |  | ddl |
| 11 | BOOK_NAME | VARCHAR | 20 | Y |  | ddl |
| 12 | AC_CODE | VARCHAR | 8 | Y |  | ddl |
| 13 | BILL_NO | VARCHAR | 8 | Y |  | ddl |
| 14 | DR_WT | FLOAT |  | Y | 0 | ddl |
| 15 | CR_WT | FLOAT |  | Y | 0 | ddl |
| 16 | DR_TOUCH | FLOAT |  | Y | 0 | ddl |
| 17 | CR_TOUCH | FLOAT |  | Y | 0 | ddl |
| 18 | DR_FINE | FLOAT |  | Y | 0 | ddl |
| 19 | CR_FINE | FLOAT |  | Y | 0 | ddl |
| 20 | DR_RATE | FLOAT |  | Y | 0 | ddl |
| 21 | CR_RATE | FLOAT |  | Y | 0 | ddl |
| 22 | DR_AMT | FLOAT |  | Y | 0 | ddl |
| 23 | CR_AMT | FLOAT |  | Y | 0 | ddl |
| 24 | DR_LBR | FLOAT |  | Y | 0 | ddl |
| 25 | CR_LBR | FLOAT |  | Y | 0 | ddl |
| 26 | VCH_DESC | VARCHAR | 150 | Y |  | ddl |
| 27 | EMP_CODE | VARCHAR | 3 | Y |  | ddl |
| 28 | OLD_VCH_NO | VARCHAR | 8 | Y |  | ddl |
| 29 | NEW_VCH_NO | VARCHAR | 8 | Y |  | ddl |
| 30 | DATA_TRFR | VARCHAR | 1 | Y |  | ddl |
| 31 | HD_VCH_NO | VARCHAR | 8 | Y |  | ddl |
| 32 | MAIN_USER | VARCHAR | 15 | Y |  | ddl |
| 33 | ADD_USER | VARCHAR | 15 | Y |  | ddl |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
