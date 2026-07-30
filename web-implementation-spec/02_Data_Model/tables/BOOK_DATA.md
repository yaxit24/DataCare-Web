# BOOK_DATA

- **Cluster:** ancillary
- **Source:** code-recovered
- **Columns:** 22
- **Primary key:** (none recovered)
- **Tenant/scope keys present:** CO_CODE, LC_CODE, CO_BOOK
- **Web mapping:** `tenant_id` + the scope keys above; preserve column names verbatim.

| # | Column | Type | Len | Null | Default | Source |
|---|--------|------|-----|------|---------|--------|
| 1 | CUR_USE | unknown |  | Y |  | code |
| 2 | CO_CODE ⟨scope⟩ | VARCHAR | 2 | Y |  | code+inferred-type |
| 3 | LC_CODE ⟨scope⟩ | VARCHAR | 2 | Y |  | code+inferred-type |
| 4 | CO_BOOK ⟨scope⟩ | VARCHAR | 3 | Y |  | code+inferred-type |
| 5 | BOOK_NAME | VARCHAR | 20 | Y |  | code+inferred-type |
| 6 | BOOK_SNAME | VARCHAR | 5 | Y |  | code+inferred-type |
| 7 | BOOK_INOUT | unknown |  | Y |  | code |
| 8 | MAIN_BOOK | VARCHAR | 30 | Y |  | code+inferred-type |
| 9 | ITM_TYPE | VARCHAR | 1 | Y |  | code+inferred-type |
| 10 | BOOK_TYPE | unknown |  | Y |  | code |
| 11 | BOOK_VCH_TYPE | unknown |  | Y |  | code |
| 12 | MAIN_USER | VARCHAR | 15 | Y |  | code+inferred-type |
| 13 | BOOK_SR_NAME | unknown |  | Y |  | code |
| 14 | RESET_BOOK | unknown |  | Y |  | code |
| 15 | DATA_TYPE | VARCHAR | 1 | Y |  | code+inferred-type |
| 16 | TRFR_BOOK | unknown |  | Y |  | code |
| 17 | DATA_TRFR | VARCHAR | 1 | Y |  | code+inferred-type |
| 18 | USER_EMP_CODE | unknown |  | Y |  | code |
| 19 | WITH_MOBILE_ENTRY | unknown |  | Y |  | code |
| 20 | MENU_NAME | VARCHAR | 50 | Y |  | code+inferred-type |
| 21 | BOOK_TBL_NAME | unknown |  | Y |  | code |
| 22 | BOOK_TBL_DETL | unknown |  | Y |  | code |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
