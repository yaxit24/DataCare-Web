# AD_MEMB

- **Cluster:** ancillary
- **Source:** DDL
- **Columns:** 36
- **Primary key:** CO_CODE, LC_CODE, SCHM_CODE, MEMB_CODE
- **Tenant/scope keys present:** CO_CODE, LC_CODE
- **Web mapping:** `tenant_id` + the scope keys above; preserve column names verbatim.

| # | Column | Type | Len | Null | Default | Source |
|---|--------|------|-----|------|---------|--------|
| 1 | CO_CODE 🔑 ⟨scope⟩ | VARCHAR | 2 | N |  | ddl |
| 2 | LC_CODE 🔑 ⟨scope⟩ | VARCHAR | 2 | N |  | ddl |
| 3 | SCHM_CODE 🔑 | VARCHAR | 3 | N |  | ddl |
| 4 | MEMB_CODE 🔑 | VARCHAR | 5 | Y | '' | ddl |
| 5 | MEMB_NAME | VARCHAR | 50 | Y | '' | ddl |
| 6 | MEMB_AMT | FLOAT |  | N | 0 | ddl |
| 7 | ITM_GWT | FLOAT |  | N | 0 | ddl |
| 8 | EMP_CODE | VARCHAR | 3 | Y | '' | ddl |
| 9 | AC_PHONE | VARCHAR | 20 | Y | '' | ddl |
| 10 | AC_MOBILE | VARCHAR | 21 | Y | 'N' | ddl |
| 11 | AC_ADD1 | VARCHAR | 50 | Y | '' | ddl |
| 12 | AC_ADD2 | VARCHAR | 50 | Y | '' | ddl |
| 13 | AC_ADD3 | VARCHAR | 50 | Y | '' | ddl |
| 14 | AC_CITY | VARCHAR | 20 | Y | '' | ddl |
| 15 | AC_PIN | VARCHAR | 10 | Y | '' | ddl |
| 16 | AC_AREA | VARCHAR | 30 | Y | '' | ddl |
| 17 | AC_MOBILE2 | VARCHAR | 21 | Y | '' | ddl |
| 18 | AC_PHONE2 | VARCHAR | 21 | Y | '' | ddl |
| 19 | ID_PROF | VARCHAR | 50 | Y | '' | ddl |
| 20 | NOMINEE_NAME | VARCHAR | 50 | Y | '' | ddl |
| 21 | AC_EMAIL | VARCHAR | 50 | Y | '' | ddl |
| 22 | AC_DISTRICT | VARCHAR | 50 | Y | '' | ddl |
| 23 | BIRTH_DATE | DATE |  | Y |  | ddl |
| 24 | ANV_DATE | DATE |  | Y |  | ddl |
| 25 | L_BR_DATE | DATE |  | Y |  | ddl |
| 26 | JOIN_DATE | DATE |  | Y |  | ddl |
| 27 | EXP_DATE | DATE |  | Y |  | ddl |
| 28 | BANK_NAME | VARCHAR | 50 | Y | '' | ddl |
| 29 | BANK_AREA | VARCHAR | 40 | Y | '' | ddl |
| 30 | BANK_AC_NO | VARCHAR | 30 | Y | '' | ddl |
| 31 | BANK_RTGS_NO | VARCHAR | 30 | Y | '' | ddl |
| 32 | AC_REF_CODE | VARCHAR | 8 | Y | '' | ddl |
| 33 | SCHM_SHORT | VARCHAR | 50 | Y | '' | ddl |
| 34 | MEMB_BONUS | FLOAT |  | N | 0 | ddl |
| 35 | DATA_TRFR | VARCHAR | 50 | Y | 'N' | ddl |
| 36 | MAIN_USER | VARCHAR | 15 | Y | '' | ddl |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
