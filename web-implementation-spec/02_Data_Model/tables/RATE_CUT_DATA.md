# RATE_CUT_DATA

- **Cluster:** ancillary
- **Source:** code-recovered
- **Columns:** 78
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
| 10 | IT_TYPE | VARCHAR | 1 | Y |  | code+inferred-type |
| 11 | AC_CODE | VARCHAR | 8 | Y |  | code+inferred-type |
| 12 | AC_NAME | VARCHAR | 50 | Y |  | code+inferred-type |
| 13 | DR_AMT | FLOAT |  | Y |  | code+inferred-type |
| 14 | CR_FINE | FLOAT |  | Y |  | code+inferred-type |
| 15 | CR_AMT | FLOAT |  | Y |  | code+inferred-type |
| 16 | DR_FINE | FLOAT |  | Y |  | code+inferred-type |
| 17 | RATE_PAR | VARCHAR | 1 | Y |  | code+inferred-type |
| 18 | FINE_RATE | FLOAT |  | Y |  | code+inferred-type |
| 19 | SL_FINE | unknown |  | Y |  | code |
| 20 | PR_FINE | unknown |  | Y |  | code |
| 21 | TOT_FINE_DR | unknown |  | Y |  | code |
| 22 | TOT_FINE_CR | unknown |  | Y |  | code |
| 23 | KSR_FINE_CR | unknown |  | Y |  | code |
| 24 | KSR_FINE_DR | unknown |  | Y |  | code |
| 25 | SL_NET_AMT | unknown |  | Y |  | code |
| 26 | SL_ITM_AMT | unknown |  | Y |  | code |
| 27 | SL_LBR_AMT | unknown |  | Y |  | code |
| 28 | SL_OTH_AMT | unknown |  | Y |  | code |
| 29 | SL_ADV_AMT | unknown |  | Y |  | code |
| 30 | SL_CASH_AMT | unknown |  | Y |  | code |
| 31 | SL_CARD_AMT | unknown |  | Y |  | code |
| 32 | SL_CHQ_AMT | unknown |  | Y |  | code |
| 33 | SL_KASAR_AMT | unknown |  | Y |  | code |
| 34 | SL_BILL_OS | unknown |  | Y |  | code |
| 35 | PR_NET_AMT | unknown |  | Y |  | code |
| 36 | PR_ITM_AMT | unknown |  | Y |  | code |
| 37 | PR_LBR_AMT | unknown |  | Y |  | code |
| 38 | PR_OTH_AMT | unknown |  | Y |  | code |
| 39 | PR_ADV_AMT | unknown |  | Y |  | code |
| 40 | PR_CASH_AMT | unknown |  | Y |  | code |
| 41 | PR_CARD_AMT | unknown |  | Y |  | code |
| 42 | PR_CHQ_AMT | unknown |  | Y |  | code |
| 43 | PR_KASAR_AMT | unknown |  | Y |  | code |
| 44 | PR_BILL_OS | unknown |  | Y |  | code |
| 45 | CR_DAYS | FLOAT |  | Y |  | code+inferred-type |
| 46 | CARD_AC | VARCHAR | 8 | Y |  | code+inferred-type |
| 47 | BANK_AC | VARCHAR | 8 | Y |  | code+inferred-type |
| 48 | CHQ_NO | VARCHAR | 10 | Y |  | code+inferred-type |
| 49 | BANK_NAME | VARCHAR | 50 | Y |  | code+inferred-type |
| 50 | EMP_CODE | VARCHAR | 3 | Y |  | code+inferred-type |
| 51 | VCH_DESC | VARCHAR | 50 | Y |  | code+inferred-type |
| 52 | ENTRY_TIME | DATE |  | Y |  | code+inferred-type |
| 53 | ADD1 | unknown |  | Y |  | code |
| 54 | ADD2 | unknown |  | Y |  | code |
| 55 | ADD3 | unknown |  | Y |  | code |
| 56 | CITY | unknown |  | Y |  | code |
| 57 | MOBILE | unknown |  | Y |  | code |
| 58 | DATA_TRFR | VARCHAR | 1 | Y |  | code+inferred-type |
| 59 | OLD_VCH_NO | VARCHAR | 8 | Y |  | code+inferred-type |
| 60 | NEW_VCH_NO | VARCHAR | 8 | Y |  | code+inferred-type |
| 61 | MAIN_USER | VARCHAR | 15 | Y |  | code+inferred-type |
| 62 | CONV_RATE | unknown |  | Y |  | code |
| 63 | CONV_PRC | unknown |  | Y |  | code |
| 64 | SILVER_FINE_DR | unknown |  | Y |  | code |
| 65 | SILVER_FINE_CR | unknown |  | Y |  | code |
| 66 | MOB_ENTRY_SAVE | unknown |  | Y |  | code |
| 67 | VP_ADJ_AMT | unknown |  | Y |  | code |
| 68 | PR_TAX_AMT | unknown |  | Y |  | code |
| 69 | PR_TOT_AMT | unknown |  | Y |  | code |
| 70 | SL_TAX_AMT | unknown |  | Y |  | code |
| 71 | SL_TOT_AMT | unknown |  | Y |  | code |
| 72 | INT_DAYS | FLOAT |  | Y |  | code+inferred-type |
| 73 | INT_OS_FINE | unknown |  | Y |  | code |
| 74 | INT_PRC_FINE | unknown |  | Y |  | code |
| 75 | INT_FINE | unknown |  | Y |  | code |
| 76 | VP_AMT | unknown |  | Y |  | code |
| 77 | VP_INS_AMT | unknown |  | Y |  | code |
| 78 | VP_CHARG_AMT | unknown |  | Y |  | code |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
