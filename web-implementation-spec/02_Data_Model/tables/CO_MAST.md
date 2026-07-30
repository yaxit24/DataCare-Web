# CO_MAST

- **Cluster:** masters
- **Source:** DDL
- **Columns:** 40
- **Primary key:** CO_CODE
- **Tenant/scope keys present:** CO_CODE, LC_CODE
- **Web mapping:** `tenant_id` + the scope keys above; preserve column names verbatim.

| # | Column | Type | Len | Null | Default | Source |
|---|--------|------|-----|------|---------|--------|
| 1 | CO_CODE 🔑 ⟨scope⟩ | VARCHAR | 2 | N |  | ddl |
| 2 | CO_NAME | VARCHAR | 50 | Y | '' | ddl |
| 3 | LC_CODE ⟨scope⟩ | VARCHAR | 2 | Y | '' | ddl |
| 4 | CO_SNAME | VARCHAR | 3 | Y | '' | ddl |
| 5 | CO_ADD1 | VARCHAR | 50 | Y | '' | ddl |
| 6 | CO_ADD2 | VARCHAR | 50 | Y | '' | ddl |
| 7 | CO_ADD3 | VARCHAR | 50 | Y | '' | ddl |
| 8 | CO_COUNTRY | VARCHAR | 25 | Y | '' | ddl |
| 9 | CO_STATE_CODE | VARCHAR | 2 | Y | '' | ddl |
| 10 | CO_STATE | VARCHAR | 25 | Y | '' | ddl |
| 11 | CO_CITY | VARCHAR | 25 | Y | '' | ddl |
| 12 | CO_PIN | VARCHAR | 10 | Y | '' | ddl |
| 13 | CO_PHONE | VARCHAR | 15 | Y | '' | ddl |
| 14 | CO_PHONE2 | VARCHAR | 15 | Y | '' | ddl |
| 15 | CO_MOBILE | VARCHAR | 15 | Y | '' | ddl |
| 16 | CO_MOBILE2 | VARCHAR | 15 | Y | '' | ddl |
| 17 | CO_MAIL | VARCHAR | 50 | Y | '' | ddl |
| 18 | CO_JUD | VARCHAR | 30 | Y | '' | ddl |
| 19 | CO_LSTNO | VARCHAR | 30 | Y | '' | ddl |
| 20 | CO_CSTNO | VARCHAR | 30 | Y | '' | ddl |
| 21 | CO_GST_NO | VARCHAR | 15 | Y | '' | ddl |
| 22 | CO_PAN_NO | VARCHAR | 30 | Y | '' | ddl |
| 23 | DHIRAN_NO | VARCHAR | 30 | Y | '' | ddl |
| 24 | BANK_NAME | VARCHAR | 50 | Y | '' | ddl |
| 25 | BANK_AREA | VARCHAR | 40 | Y | '' | ddl |
| 26 | BANK_AC_NO | VARCHAR | 30 | Y | '' | ddl |
| 27 | BANK_RTGS_NO | VARCHAR | 30 | Y | '' | ddl |
| 28 | CO_TYPE | VARCHAR | 1 | Y | '' | ddl |
| 29 | ALTER_YEAR | VARCHAR | 1 | Y | '' | ddl |
| 30 | CO_MSG | VARCHAR | 100 | Y | '' | ddl |
| 31 | REP_ADD_TYPE | VARCHAR | 1 | Y | '' | ddl |
| 32 | MAIN_USER | VARCHAR | 15 | Y | '' | ddl |
| 33 | WORK_TYPE | VARCHAR | 1 | Y | '' | ddl |
| 34 | METAL_TYPE | VARCHAR | 1 | Y | '' | ddl |
| 35 | URL_NAME | VARCHAR | 150 | Y | '' | ddl |
| 36 | URL_ID | VARCHAR | 50 | Y | '' | ddl |
| 37 | URL_PWD | VARCHAR | 25 | Y | '' | ddl |
| 38 | HTTP_NAME | VARCHAR | 150 | Y | '' | ddl |
| 39 | MAIL_API | VARCHAR | 100 | Y | '' | ddl |
| 40 | RAZOR_PAY_LIVE | VARCHAR | 1 | Y | 'Y' | ddl |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
