# KR_DATA

- **Cluster:** manufacturing
- **Source:** code-recovered
- **Columns:** 61
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
| 13 | DISC_PRC | FLOAT |  | Y |  | code+inferred-type |
| 14 | DISC_AMT | FLOAT |  | Y |  | code+inferred-type |
| 15 | TAX_CODE | VARCHAR | 2 | Y |  | code+inferred-type |
| 16 | TAX_PRC | FLOAT |  | Y |  | code+inferred-type |
| 17 | TAX_AMT | FLOAT |  | Y |  | code+inferred-type |
| 18 | ROF_AMT | FLOAT |  | Y |  | code+inferred-type |
| 19 | TOT_AMT | FLOAT |  | Y |  | code+inferred-type |
| 20 | CASH_AMT | FLOAT |  | Y |  | code+inferred-type |
| 21 | CARD_AMT | FLOAT |  | Y |  | code+inferred-type |
| 22 | CHQ_AMT | FLOAT |  | Y |  | code+inferred-type |
| 23 | KASAR_AMT | FLOAT |  | Y |  | code+inferred-type |
| 24 | BILL_OS | FLOAT |  | Y |  | code+inferred-type |
| 25 | OS_ADJ_AMT | unknown |  | Y |  | code |
| 26 | CR_DAYS | FLOAT |  | Y |  | code+inferred-type |
| 27 | CARD_AC | VARCHAR | 8 | Y |  | code+inferred-type |
| 28 | BANK_AC | VARCHAR | 8 | Y |  | code+inferred-type |
| 29 | CHQ_NO | VARCHAR | 10 | Y |  | code+inferred-type |
| 30 | BANK_NAME | VARCHAR | 50 | Y |  | code+inferred-type |
| 31 | EMP_CODE | VARCHAR | 3 | Y |  | code+inferred-type |
| 32 | VCH_DESC | VARCHAR | 50 | Y |  | code+inferred-type |
| 33 | DATA_TRFR | VARCHAR | 1 | Y |  | code+inferred-type |
| 34 | ENTRY_TIME | DATE |  | Y |  | code+inferred-type |
| 35 | ADD1 | unknown |  | Y |  | code |
| 36 | ADD2 | unknown |  | Y |  | code |
| 37 | ADD3 | unknown |  | Y |  | code |
| 38 | CITY | unknown |  | Y |  | code |
| 39 | MOBILE | unknown |  | Y |  | code |
| 40 | AC_GST_TYPE | VARCHAR | 1 | Y |  | code+inferred-type |
| 41 | IGST_TAX | FLOAT |  | Y |  | code+inferred-type |
| 42 | CGST_TAX | FLOAT |  | Y |  | code+inferred-type |
| 43 | SGST_TAX | FLOAT |  | Y |  | code+inferred-type |
| 44 | OLD_VCH_NO | VARCHAR | 8 | Y |  | code+inferred-type |
| 45 | NEW_VCH_NO | VARCHAR | 8 | Y |  | code+inferred-type |
| 46 | MAIN_USER | VARCHAR | 15 | Y |  | code+inferred-type |
| 47 | LBR_AMT | FLOAT |  | Y |  | code+inferred-type |
| 48 | OTH_AMT | FLOAT |  | Y |  | code+inferred-type |
| 49 | SL_BILL_NO | unknown |  | Y |  | code |
| 50 | SL_BILL_LC | unknown |  | Y |  | code |
| 51 | SL_BILL_YRCD | unknown |  | Y |  | code |
| 52 | SL_BILL_DBCD | unknown |  | Y |  | code |
| 53 | PARTY_FINE | FLOAT |  | Y |  | code+inferred-type |
| 54 | IT_TYPE | VARCHAR | 1 | Y |  | code+inferred-type |
| 55 | TCS_CODE | VARCHAR | 1 | Y |  | code+inferred-type |
| 56 | TCS_PRC | FLOAT |  | Y |  | code+inferred-type |
| 57 | TCS_AMT | FLOAT |  | Y |  | code+inferred-type |
| 58 | HM_AMT | unknown |  | Y |  | code |
| 59 | HM_TAX_PRC | unknown |  | Y |  | code |
| 60 | HM_TAX_AMT | unknown |  | Y |  | code |
| 61 | TDS_AMT | FLOAT |  | Y |  | code+inferred-type |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
