# CO_SET

- **Cluster:** masters
- **Source:** code-recovered
- **Columns:** 59
- **Primary key:** (none recovered)
- **Tenant/scope keys present:** CO_CODE
- **Web mapping:** `tenant_id` + the scope keys above; preserve column names verbatim.

| # | Column | Type | Len | Null | Default | Source |
|---|--------|------|-----|------|---------|--------|
| 1 | THEME | unknown |  | Y |  | code |
| 2 | TAG_RPT | unknown |  | Y |  | code |
| 3 | FINE_STK_TYPE | unknown |  | Y |  | code |
| 4 | RATE_MAST_OPEN | unknown |  | Y |  | code |
| 5 | LBR_RATE_GEN | unknown |  | Y |  | code |
| 6 | VB_IMPORT | unknown |  | Y |  | code |
| 7 | SL_ROW_CHANGE | unknown |  | Y |  | code |
| 8 | DHRN_INT_TYPE | unknown |  | Y |  | code |
| 9 | INT_YEAR_DAYS | unknown |  | Y |  | code |
| 10 | OP_DHRN | unknown |  | Y |  | code |
| 11 | INT_DAY | FLOAT |  | Y |  | code+inferred-type |
| 12 | HELP_SERCH | unknown |  | Y |  | code |
| 13 | WEIGHT_PORT | unknown |  | Y |  | code |
| 14 | LDR_SUMM | unknown |  | Y |  | code |
| 15 | SL_AMT_TYPE | unknown |  | Y |  | code |
| 16 | SMS_LINK | unknown |  | Y |  | code |
| 17 | OP_LOAN | unknown |  | Y |  | code |
| 18 | LOAN_INT_TYPE | unknown |  | Y |  | code |
| 19 | TRAD_FINE | unknown |  | Y |  | code |
| 20 | LBR_ROF | unknown |  | Y |  | code |
| 21 | REMINDER_OPEN | unknown |  | Y |  | code |
| 22 | ITM_RATE_ROF | unknown |  | Y |  | code |
| 23 | ADMIN_SMS | unknown |  | Y |  | code |
| 24 | CUST_SMS | unknown |  | Y |  | code |
| 25 | PURC_WITH_LBR | unknown |  | Y |  | code |
| 26 | DHIRN_COMPOUND | unknown |  | Y |  | code |
| 27 | GRID_SCROLL | unknown |  | Y |  | code |
| 28 | STK_RPT_TYPE | unknown |  | Y |  | code |
| 29 | TOUCH_AUTO_SAVE | unknown |  | Y |  | code |
| 30 | PAN_CARD_VAL | unknown |  | Y |  | code |
| 31 | DHRN_PRC | unknown |  | Y |  | code |
| 32 | DUP_PRINT | unknown |  | Y |  | code |
| 33 | TAX_CODE | VARCHAR | 2 | Y |  | code+inferred-type |
| 34 | IP_WITH_PC | unknown |  | Y |  | code |
| 35 | CO_STK_MERGE | unknown |  | Y |  | code |
| 36 | STK_RPT_VIEW | unknown |  | Y |  | code |
| 37 | PR_AMT_TYPE | unknown |  | Y |  | code |
| 38 | CARD_COM_ADJ | unknown |  | Y |  | code |
| 39 | CASH_PURC_AC | unknown |  | Y |  | code |
| 40 | EMP_CODE_MANDATORY | unknown |  | Y |  | code |
| 41 | STOCK_RPT_TYPE | unknown |  | Y |  | code |
| 42 | LAST_DAY_LOCK | unknown |  | Y |  | code |
| 43 | CASH_LIMIT | unknown |  | Y |  | code |
| 44 | DHRN_WAPP | unknown |  | Y |  | code |
| 45 | SCHM_WAPP | unknown |  | Y |  | code |
| 46 | LEDR_BILL_COL | unknown |  | Y |  | code |
| 47 | ALL_ROF_REMOVE | unknown |  | Y |  | code |
| 48 | CO_CODE ⟨scope⟩ | VARCHAR | 2 | Y |  | code+inferred-type |
| 49 | BTN_NAME | unknown |  | Y |  | code |
| 50 | COUNTRY_CODE | VARCHAR | 4 | Y |  | code+inferred-type |
| 51 | LBR_TYPE | VARCHAR | 1 | Y |  | code+inferred-type |
| 52 | AC_LC_CODE_LEN | unknown |  | Y |  | code |
| 53 | LOCK_DATE | unknown |  | Y |  | code |
| 54 | TAX_ROF | unknown |  | Y |  | code |
| 55 | RATE_PAR | VARCHAR | 1 | Y |  | code+inferred-type |
| 56 | OZ_CON_VAL | unknown |  | Y |  | code |
| 57 | FX_RATE | unknown |  | Y |  | code |
| 58 | FX_CODE | unknown |  | Y |  | code |
| 59 | COUNTRY_ID | unknown |  | Y |  | code |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
