# CASH_DATA

- **Cluster:** finance
- **Source:** code-recovered
- **Columns:** 33
- **Primary key:** (none recovered)
- **Tenant/scope keys present:** CO_CODE, LC_CODE, CO_YEAR, CO_BOOK  ·  fully tenant-keyed
- **Web mapping:** `tenant_id` + the scope keys above; preserve column names verbatim.

| # | Column | Type | Len | Null | Default | Source |
|---|--------|------|-----|------|---------|--------|
| 1 | CO_CODE ⟨scope⟩ | VARCHAR | 2 | Y |  | code+inferred-type |
| 2 | LC_CODE ⟨scope⟩ | VARCHAR | 2 | Y |  | code+inferred-type |
| 3 | CO_YEAR ⟨scope⟩ | VARCHAR | 10 | Y |  | code+inferred-type |
| 4 | CO_BOOK ⟨scope⟩ | VARCHAR | 3 | Y |  | code+inferred-type |
| 5 | VCH_NO | VARCHAR | 8 | Y |  | code+inferred-type |
| 6 | SR_NO | FLOAT |  | Y |  | code+inferred-type |
| 7 | VCH_DATE | DATE |  | Y |  | code+inferred-type |
| 8 | VCH_TYPE | VARCHAR | 6 | Y |  | code+inferred-type |
| 9 | INOUT_TYPE | VARCHAR | 1 | Y |  | code+inferred-type |
| 10 | ENTRY_TYPE | VARCHAR | 1 | Y |  | code+inferred-type |
| 11 | BOOK_NAME | VARCHAR | 20 | Y |  | code+inferred-type |
| 12 | VCH_TIME | DATETIME |  | Y |  | code+inferred-type |
| 13 | AC_CODE | VARCHAR | 8 | Y |  | code+inferred-type |
| 14 | AC_NAME | VARCHAR | 50 | Y |  | code+inferred-type |
| 15 | CHQ_NO | VARCHAR | 10 | Y |  | code+inferred-type |
| 16 | REC_AMT | FLOAT |  | Y |  | code+inferred-type |
| 17 | KASAR_AMT | FLOAT |  | Y |  | code+inferred-type |
| 18 | IT_DESC | VARCHAR | 50 | Y |  | code+inferred-type |
| 19 | BANK_NAME | VARCHAR | 50 | Y |  | code+inferred-type |
| 20 | EMP_CODE | VARCHAR | 3 | Y |  | code+inferred-type |
| 21 | DATA_TRFR | VARCHAR | 1 | Y |  | code+inferred-type |
| 22 | OLD_VCH_NO | VARCHAR | 8 | Y |  | code+inferred-type |
| 23 | NEW_VCH_NO | VARCHAR | 8 | Y |  | code+inferred-type |
| 24 | HD_VCH_NO | VARCHAR | 10 | Y |  | code+inferred-type |
| 25 | MAIN_USER | VARCHAR | 15 | Y |  | code+inferred-type |
| 26 | ADD_USER | VARCHAR | 15 | Y |  | code+inferred-type |
| 27 | REC_AC_CODE | unknown |  | Y |  | code |
| 28 | CHQ_PRINT_NAME | unknown |  | Y |  | code |
| 29 | CLR_DATE | DATE |  | Y |  | code+inferred-type |
| 30 | USER_UPDATE | VARCHAR | 1 | Y |  | code+inferred-type |
| 31 | USER_DELETE | VARCHAR | 1 | Y |  | code+inferred-type |
| 32 | BANK_CHARGES | unknown |  | Y |  | code |
| 33 | MOB_ENTRY_SAVE | unknown |  | Y |  | code |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
