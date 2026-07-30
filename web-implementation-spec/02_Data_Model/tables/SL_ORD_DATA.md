# SL_ORD_DATA

- **Cluster:** sales
- **Source:** code-recovered
- **Columns:** 55
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
| 6 | VCH_DATE | DATE |  | Y |  | code+inferred-type |
| 7 | VCH_TIME | DATETIME |  | Y |  | code+inferred-type |
| 8 | BILL_NO | VARCHAR | 30 | Y |  | code+inferred-type |
| 9 | HD_VCH_NO | VARCHAR | 10 | Y |  | code+inferred-type |
| 10 | AC_CODE | VARCHAR | 8 | Y |  | code+inferred-type |
| 11 | AC_NAME | VARCHAR | 50 | Y |  | code+inferred-type |
| 12 | NET_AMT | FLOAT |  | Y |  | code+inferred-type |
| 13 | TAX_CODE | VARCHAR | 2 | Y |  | code+inferred-type |
| 14 | TAX_PRC | FLOAT |  | Y |  | code+inferred-type |
| 15 | TAX_AMT | FLOAT |  | Y |  | code+inferred-type |
| 16 | TOT_AMT | FLOAT |  | Y |  | code+inferred-type |
| 17 | ADV_AMT | unknown |  | Y |  | code |
| 18 | ORD_ADJ_AMT | unknown |  | Y |  | code |
| 19 | OLD_GL_AMT | unknown |  | Y |  | code |
| 20 | OLD_SL_AMT | unknown |  | Y |  | code |
| 21 | CASH_AMT | FLOAT |  | Y |  | code+inferred-type |
| 22 | CARD_AMT | FLOAT |  | Y |  | code+inferred-type |
| 23 | CHQ_AMT | FLOAT |  | Y |  | code+inferred-type |
| 24 | SCHM_AMT | FLOAT |  | Y |  | code+inferred-type |
| 25 | DEL_DATE | unknown |  | Y |  | code |
| 26 | CARD_AC | VARCHAR | 8 | Y |  | code+inferred-type |
| 27 | BANK_AC | VARCHAR | 8 | Y |  | code+inferred-type |
| 28 | CHQ_NO | VARCHAR | 10 | Y |  | code+inferred-type |
| 29 | BANK_NAME | VARCHAR | 50 | Y |  | code+inferred-type |
| 30 | EMP_CODE | VARCHAR | 3 | Y |  | code+inferred-type |
| 31 | VCH_DESC | VARCHAR | 50 | Y |  | code+inferred-type |
| 32 | ENTRY_TIME | DATE |  | Y |  | code+inferred-type |
| 33 | SL_BILL_TYPE | unknown |  | Y |  | code |
| 34 | OLD_GL | unknown |  | Y |  | code |
| 35 | ADJ_GOLD | unknown |  | Y |  | code |
| 36 | OLD_SL | unknown |  | Y |  | code |
| 37 | ADJ_SILVER | unknown |  | Y |  | code |
| 38 | CARD_ADJ | unknown |  | Y |  | code |
| 39 | DATA_TRFR | VARCHAR | 1 | Y |  | code+inferred-type |
| 40 | OLD_VCH_NO | VARCHAR | 8 | Y |  | code+inferred-type |
| 41 | NEW_VCH_NO | VARCHAR | 8 | Y |  | code+inferred-type |
| 42 | MAIN_USER | VARCHAR | 15 | Y |  | code+inferred-type |
| 43 | ADD1 | unknown |  | Y |  | code |
| 44 | ADD2 | unknown |  | Y |  | code |
| 45 | ADD3 | unknown |  | Y |  | code |
| 46 | CITY | unknown |  | Y |  | code |
| 47 | MOBILE | unknown |  | Y |  | code |
| 48 | USER_UPDATE | VARCHAR | 1 | Y |  | code+inferred-type |
| 49 | USER_DELETE | VARCHAR | 1 | Y |  | code+inferred-type |
| 50 | MOB_ENTRY_SAVE | unknown |  | Y |  | code |
| 51 | FUN_DATE | unknown |  | Y |  | code |
| 52 | RCUT_RATE | unknown |  | Y |  | code |
| 53 | RCUT_FINE | unknown |  | Y |  | code |
| 54 | RCUT_AMT | unknown |  | Y |  | code |
| 55 | UPI_AMT | FLOAT |  | Y |  | code+inferred-type |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
