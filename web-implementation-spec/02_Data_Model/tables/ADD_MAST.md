# ADD_MAST

- **Cluster:** masters
- **Source:** code-recovered
- **Columns:** 25
- **Primary key:** (none recovered)
- **Tenant/scope keys present:** CO_CODE, LC_CODE
- **Web mapping:** `tenant_id` + the scope keys above; preserve column names verbatim.

| # | Column | Type | Len | Null | Default | Source |
|---|--------|------|-----|------|---------|--------|
| 1 | CO_CODE ⟨scope⟩ | VARCHAR | 2 | Y |  | code+inferred-type |
| 2 | AC_CODE | VARCHAR | 8 | Y |  | code+inferred-type |
| 3 | LC_CODE ⟨scope⟩ | VARCHAR | 2 | Y |  | code+inferred-type |
| 4 | AC_NAME | VARCHAR | 50 | Y |  | code+inferred-type |
| 5 | AC_GR | unknown |  | Y |  | code |
| 6 | AC_ADD1 | VARCHAR | 50 | Y |  | code+inferred-type |
| 7 | AC_ADD2 | VARCHAR | 50 | Y |  | code+inferred-type |
| 8 | AC_ADD3 | VARCHAR | 50 | Y |  | code+inferred-type |
| 9 | AC_COUNTRY | unknown |  | Y |  | code |
| 10 | AC_STATE | unknown |  | Y |  | code |
| 11 | AC_DISTRICT | VARCHAR | 50 | Y |  | code+inferred-type |
| 12 | AC_CITY | VARCHAR | 20 | Y |  | code+inferred-type |
| 13 | AC_AREA | VARCHAR | 30 | Y |  | code+inferred-type |
| 14 | AC_PIN | VARCHAR | 10 | Y |  | code+inferred-type |
| 15 | AC_PHONE | VARCHAR | 20 | Y |  | code+inferred-type |
| 16 | AC_PHONE2 | VARCHAR | 21 | Y |  | code+inferred-type |
| 17 | AC_MOBILE | VARCHAR | 21 | Y |  | code+inferred-type |
| 18 | AC_MOBILE2 | VARCHAR | 21 | Y |  | code+inferred-type |
| 19 | AC_EMAIL | VARCHAR | 50 | Y |  | code+inferred-type |
| 20 | BR_DATE | unknown |  | Y |  | code |
| 21 | L_BR_DATE | DATE |  | Y |  | code+inferred-type |
| 22 | AN_DATE | unknown |  | Y |  | code |
| 23 | MAIN_USER | VARCHAR | 15 | Y |  | code+inferred-type |
| 24 | DATA_TRFR | VARCHAR | 1 | Y |  | code+inferred-type |
| 25 | AC_PERSON | unknown |  | Y |  | code |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
