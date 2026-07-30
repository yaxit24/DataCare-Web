# SL_DATA

- **Cluster:** sales
- **Source:** code-recovered
- **Columns:** 99
- **Primary key:** (none recovered)
- **Tenant/scope keys present:** CO_CODE, LC_CODE, CO_YEAR, CO_BOOK  ·  fully tenant-keyed
- **Web mapping:** `tenant_id` + the scope keys above; preserve column names verbatim.

| # | Column | Type | Len | Null | Default | Source |
|---|--------|------|-----|------|---------|--------|
| 1 | VCH_NO | VARCHAR | 8 | Y |  | code+inferred-type |
| 2 | IRN_NO | VARCHAR | 100 | Y |  | code+inferred-type |
| 3 | CO_CODE ⟨scope⟩ | VARCHAR | 2 | Y |  | code+inferred-type |
| 4 | LC_CODE ⟨scope⟩ | VARCHAR | 2 | Y |  | code+inferred-type |
| 5 | CO_YEAR ⟨scope⟩ | VARCHAR | 10 | Y |  | code+inferred-type |
| 6 | CO_BOOK ⟨scope⟩ | VARCHAR | 3 | Y |  | code+inferred-type |
| 7 | VCH_DATE | DATE |  | Y |  | code+inferred-type |
| 8 | VCH_TIME | DATETIME |  | Y |  | code+inferred-type |
| 9 | BILL_NO | VARCHAR | 30 | Y |  | code+inferred-type |
| 10 | HD_VCH_NO | VARCHAR | 10 | Y |  | code+inferred-type |
| 11 | AC_CODE | VARCHAR | 8 | Y |  | code+inferred-type |
| 12 | AC_NAME | VARCHAR | 50 | Y |  | code+inferred-type |
| 13 | NET_AMT | FLOAT |  | Y |  | code+inferred-type |
| 14 | DISC_PRC | FLOAT |  | Y |  | code+inferred-type |
| 15 | DISC_AMT | FLOAT |  | Y |  | code+inferred-type |
| 16 | TAX_CODE | VARCHAR | 2 | Y |  | code+inferred-type |
| 17 | TAX_PRC | FLOAT |  | Y |  | code+inferred-type |
| 18 | TAX_AMT | FLOAT |  | Y |  | code+inferred-type |
| 19 | ROF_AMT | FLOAT |  | Y |  | code+inferred-type |
| 20 | TOT_AMT | FLOAT |  | Y |  | code+inferred-type |
| 21 | ADV_AMT | unknown |  | Y |  | code |
| 22 | OLD_GL_AMT | unknown |  | Y |  | code |
| 23 | OLD_SL_AMT | unknown |  | Y |  | code |
| 24 | CASH_AMT | FLOAT |  | Y |  | code+inferred-type |
| 25 | CARD_AMT | FLOAT |  | Y |  | code+inferred-type |
| 26 | CHQ_AMT | FLOAT |  | Y |  | code+inferred-type |
| 27 | SCHM_AMT | FLOAT |  | Y |  | code+inferred-type |
| 28 | CASH_PAID | FLOAT |  | Y |  | code+inferred-type |
| 29 | KASAR_AMT | FLOAT |  | Y |  | code+inferred-type |
| 30 | BILL_OS | FLOAT |  | Y |  | code+inferred-type |
| 31 | OS_ADJ_AMT | unknown |  | Y |  | code |
| 32 | CR_DAYS | FLOAT |  | Y |  | code+inferred-type |
| 33 | CARD_AC | VARCHAR | 8 | Y |  | code+inferred-type |
| 34 | BANK_AC | VARCHAR | 8 | Y |  | code+inferred-type |
| 35 | CHQ_NO | VARCHAR | 10 | Y |  | code+inferred-type |
| 36 | BANK_NAME | VARCHAR | 50 | Y |  | code+inferred-type |
| 37 | EMP_CODE | VARCHAR | 3 | Y |  | code+inferred-type |
| 38 | VCH_DESC | VARCHAR | 50 | Y |  | code+inferred-type |
| 39 | ENTRY_TIME | DATE |  | Y |  | code+inferred-type |
| 40 | OLD_GL | unknown |  | Y |  | code |
| 41 | OLD_SL | unknown |  | Y |  | code |
| 42 | ADD1 | unknown |  | Y |  | code |
| 43 | ADD2 | unknown |  | Y |  | code |
| 44 | ADD3 | unknown |  | Y |  | code |
| 45 | CITY | unknown |  | Y |  | code |
| 46 | MOBILE | unknown |  | Y |  | code |
| 47 | AC_GST_TYPE | VARCHAR | 1 | Y |  | code+inferred-type |
| 48 | IGST_TAX | FLOAT |  | Y |  | code+inferred-type |
| 49 | CGST_TAX | FLOAT |  | Y |  | code+inferred-type |
| 50 | SGST_TAX | FLOAT |  | Y |  | code+inferred-type |
| 51 | DATA_TRFR | VARCHAR | 1 | Y |  | code+inferred-type |
| 52 | OLD_VCH_NO | VARCHAR | 8 | Y |  | code+inferred-type |
| 53 | NEW_VCH_NO | VARCHAR | 8 | Y |  | code+inferred-type |
| 54 | MAIN_USER | VARCHAR | 15 | Y |  | code+inferred-type |
| 55 | SCHM_AC | VARCHAR | 10 | Y |  | code+inferred-type |
| 56 | CARD_ADJ | unknown |  | Y |  | code |
| 57 | ISU_NO | VARCHAR | 10 | Y |  | code+inferred-type |
| 58 | ISU_LC_CODE | unknown |  | Y |  | code |
| 59 | ISU_YRCD | VARCHAR | 9 | Y |  | code+inferred-type |
| 60 | ISU_DBCD | VARCHAR | 3 | Y |  | code+inferred-type |
| 61 | RTN_NET_AMT | unknown |  | Y |  | code |
| 62 | RTN_TOT_AMT | unknown |  | Y |  | code |
| 63 | RTN_CHQ_AMT | unknown |  | Y |  | code |
| 64 | RTN_CARD_AMT | unknown |  | Y |  | code |
| 65 | RTN_CASH_AMT | unknown |  | Y |  | code |
| 66 | RTN_KASAR_AMT | unknown |  | Y |  | code |
| 67 | RTN_BILL_OS | unknown |  | Y |  | code |
| 68 | TCS_CODE | VARCHAR | 1 | Y |  | code+inferred-type |
| 69 | TCS_PRC | FLOAT |  | Y |  | code+inferred-type |
| 70 | TCS_AMT | FLOAT |  | Y |  | code+inferred-type |
| 71 | HM_AMT | unknown |  | Y |  | code |
| 72 | HM_TAX_PRC | unknown |  | Y |  | code |
| 73 | HM_TAX_AMT | unknown |  | Y |  | code |
| 74 | HM_TAX_CODE | unknown |  | Y |  | code |
| 75 | TDS_CODE | VARCHAR | 2 | Y |  | code+inferred-type |
| 76 | TDS_PRC | FLOAT |  | Y |  | code+inferred-type |
| 77 | TDS_AMT | FLOAT |  | Y |  | code+inferred-type |
| 78 | CARD_COM_AMT | FLOAT |  | Y |  | code+inferred-type |
| 79 | USER_UPDATE | VARCHAR | 1 | Y |  | code+inferred-type |
| 80 | USER_DELETE | VARCHAR | 1 | Y |  | code+inferred-type |
| 81 | POINT_VAL | FLOAT |  | Y |  | code+inferred-type |
| 82 | ACK_NO | VARCHAR | 25 | Y |  | code+inferred-type |
| 83 | ACK_DATE | DATE |  | Y |  | code+inferred-type |
| 84 | ORNA_ISU | unknown |  | Y |  | code |
| 85 | MOB_ENTRY_SAVE | unknown |  | Y |  | code |
| 86 | UPI_AMT | FLOAT |  | Y |  | code+inferred-type |
| 87 | LBR_AMT | FLOAT |  | Y |  | code+inferred-type |
| 88 | OTH_AMT | FLOAT |  | Y |  | code+inferred-type |
| 89 | CRNT_ADJ_AMT | unknown |  | Y |  | code |
| 90 | PARTY_FINE | FLOAT |  | Y |  | code+inferred-type |
| 91 | IT_TYPE | VARCHAR | 1 | Y |  | code+inferred-type |
| 92 | OZ_RATE | unknown |  | Y |  | code |
| 93 | OZ_CONV | unknown |  | Y |  | code |
| 94 | FX_RATE | unknown |  | Y |  | code |
| 95 | FX_CODE | unknown |  | Y |  | code |
| 96 | MTL_RATE | unknown |  | Y |  | code |
| 97 | TOT_TAX_FREE_AMT | unknown |  | Y |  | code |
| 98 | ZERO_RATED_AMT | unknown |  | Y |  | code |
| 99 | RATE_UNFIX | unknown |  | Y |  | code |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
