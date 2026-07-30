# AC_MAST

- **Cluster:** accounting
- **Source:** code-recovered
- **Columns:** 50
- **Primary key:** (none recovered)
- **Tenant/scope keys present:** CO_CODE, LC_CODE
- **Web mapping:** `tenant_id` + the scope keys above; preserve column names verbatim.

| # | Column | Type | Len | Null | Default | Source |
|---|--------|------|-----|------|---------|--------|
| 1 | CO_CODE ⟨scope⟩ | VARCHAR | 2 | Y |  | code+inferred-type |
| 2 | AC_CODE | VARCHAR | 8 | Y |  | code+inferred-type |
| 3 | LC_CODE ⟨scope⟩ | VARCHAR | 2 | Y |  | code+inferred-type |
| 4 | AC_NAME | VARCHAR | 50 | Y |  | code+inferred-type |
| 5 | AC_SHORT | unknown |  | Y |  | code |
| 6 | AC_MAIN_GR | unknown |  | Y |  | code |
| 7 | AC_GR | unknown |  | Y |  | code |
| 8 | AC_PERSON | unknown |  | Y |  | code |
| 9 | AC_ADD1 | VARCHAR | 50 | Y |  | code+inferred-type |
| 10 | AC_ADD2 | VARCHAR | 50 | Y |  | code+inferred-type |
| 11 | AC_ADD3 | VARCHAR | 50 | Y |  | code+inferred-type |
| 12 | AC_COUNTRY | unknown |  | Y |  | code |
| 13 | AC_STATE | unknown |  | Y |  | code |
| 14 | AC_DISTRICT | VARCHAR | 50 | Y |  | code+inferred-type |
| 15 | AC_CITY | VARCHAR | 20 | Y |  | code+inferred-type |
| 16 | AC_AREA | VARCHAR | 30 | Y |  | code+inferred-type |
| 17 | AC_PIN | VARCHAR | 10 | Y |  | code+inferred-type |
| 18 | AC_PHONE | VARCHAR | 20 | Y |  | code+inferred-type |
| 19 | AC_PHONE2 | VARCHAR | 21 | Y |  | code+inferred-type |
| 20 | AC_MOBILE | VARCHAR | 21 | Y |  | code+inferred-type |
| 21 | AC_MOBILE2 | VARCHAR | 21 | Y |  | code+inferred-type |
| 22 | AC_EMAIL | VARCHAR | 50 | Y |  | code+inferred-type |
| 23 | AC_GSTNO | unknown |  | Y |  | code |
| 24 | AC_GST_TYPE | VARCHAR | 1 | Y |  | code+inferred-type |
| 25 | AC_PANNO | unknown |  | Y |  | code |
| 26 | AC_REF_CODE | VARCHAR | 8 | Y |  | code+inferred-type |
| 27 | AC_KHATA_NO | unknown |  | Y |  | code |
| 28 | BR_DATE | unknown |  | Y |  | code |
| 29 | L_BR_DATE | DATE |  | Y |  | code+inferred-type |
| 30 | AN_DATE | unknown |  | Y |  | code |
| 31 | AC_CR_DAYS | unknown |  | Y |  | code |
| 32 | AC_INT_PRC | unknown |  | Y |  | code |
| 33 | DPC_PRC | unknown |  | Y |  | code |
| 34 | BANK_NAME | VARCHAR | 50 | Y |  | code+inferred-type |
| 35 | BANK_AREA | VARCHAR | 40 | Y |  | code+inferred-type |
| 36 | BANK_AC_NO | VARCHAR | 30 | Y |  | code+inferred-type |
| 37 | BANK_RTGS_NO | VARCHAR | 30 | Y |  | code+inferred-type |
| 38 | BANK_DETL | unknown |  | Y |  | code |
| 39 | AC_TYPE | VARCHAR | 1 | Y |  | code+inferred-type |
| 40 | LAST_DATE | unknown |  | Y |  | code |
| 41 | DATA_TRFR | VARCHAR | 1 | Y |  | code+inferred-type |
| 42 | MAIN_USER | VARCHAR | 15 | Y |  | code+inferred-type |
| 43 | LAST_VISIT | unknown |  | Y |  | code |
| 44 | VISIT_TRAN | unknown |  | Y |  | code |
| 45 | APP_TRFR | VARCHAR | 1 | Y |  | code+inferred-type |
| 46 | AC_REF_NAME | unknown |  | Y |  | code |
| 47 | AC_ADHAR_NO | unknown |  | Y |  | code |
| 48 | AC_PARSON | VARCHAR | 50 | Y |  | code+inferred-type |
| 49 | DEFAULTER_AC | unknown |  | Y |  | code |
| 50 | MAIN_AC_CODE | unknown |  | Y |  | code |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
