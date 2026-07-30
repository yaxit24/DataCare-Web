# FAN_DATA

- **Cluster:** ancillary
- **Source:** DDL
- **Columns:** 65
- **Primary key:** CO_CODE, LC_CODE, CO_YEAR, CO_BOOK, VCH_NO
- **Tenant/scope keys present:** CO_CODE, LC_CODE, CO_YEAR, CO_BOOK  ·  fully tenant-keyed
- **Web mapping:** `tenant_id` + the scope keys above; preserve column names verbatim.

| # | Column | Type | Len | Null | Default | Source |
|---|--------|------|-----|------|---------|--------|
| 1 | CO_CODE 🔑 ⟨scope⟩ | VARCHAR | 2 | Y |  | ddl |
| 2 | LC_CODE 🔑 ⟨scope⟩ | VARCHAR | 2 | Y |  | ddl |
| 3 | CO_YEAR 🔑 ⟨scope⟩ | VARCHAR | 10 | Y |  | ddl |
| 4 | CO_BOOK 🔑 ⟨scope⟩ | VARCHAR | 3 | Y |  | ddl |
| 5 | VCH_NO 🔑 | VARCHAR | 8 | Y |  | ddl |
| 6 | VCH_DATE | DATE |  | Y |  | ddl |
| 7 | VCH_TIME | DATETIME |  | Y |  | ddl |
| 8 | VCH_TYPE | VARCHAR | 6 | Y |  | ddl |
| 9 | INOUT_TYPE | VARCHAR | 1 | Y |  | ddl |
| 10 | ENTRY_TYPE | VARCHAR | 1 | Y |  | ddl |
| 11 | BOOK_NAME | VARCHAR | 20 | Y |  | ddl |
| 12 | AC_CODE | VARCHAR | 8 | Y |  | ddl |
| 13 | TO_FAN_CODE | VARCHAR | 8 | Y |  | ddl |
| 14 | TOT_GWT | FLOAT |  | Y | 0 | ddl |
| 15 | TOT_NWT | FLOAT |  | Y | 0 | ddl |
| 16 | TOT_FINE | FLOAT |  | Y | 0 | ddl |
| 17 | LBR_AMT | FLOAT |  | Y | 0 | ddl |
| 18 | OTH_AMT | FLOAT |  | Y | 0 | ddl |
| 19 | NET_AMT | FLOAT |  | Y | 0 | ddl |
| 20 | DISC_PRC | FLOAT |  | Y | 0 | ddl |
| 21 | DISC_AMT | FLOAT |  | Y | 0 | ddl |
| 22 | TAX_CODE | VARCHAR | 2 | Y |  | ddl |
| 23 | TAX_PRC | FLOAT |  | N | 0 | ddl |
| 24 | TAX_AMT | FLOAT |  | N | 0 | ddl |
| 25 | ROF_AMT | FLOAT |  | N | 0 | ddl |
| 26 | TOT_AMT | FLOAT |  | N | 0 | ddl |
| 27 | CASH_AMT | FLOAT |  | N | 0 | ddl |
| 28 | CARD_AMT | FLOAT |  | N | 0 | ddl |
| 29 | CHQ_AMT | FLOAT |  | N | 0 | ddl |
| 30 | KASAR_AMT | FLOAT |  | N | 0 | ddl |
| 31 | BILL_OS | FLOAT |  | N | 0 | ddl |
| 32 | CR_DAYS | FLOAT |  | N | 0 | ddl |
| 33 | AC_GST_TYPE | VARCHAR | 1 | Y |  | ddl |
| 34 | IGST_TAX | FLOAT |  | N | 0 | ddl |
| 35 | CGST_TAX | FLOAT |  | N | 0 | ddl |
| 36 | SGST_TAX | FLOAT |  | N | 0 | ddl |
| 37 | PARTY_FINE | FLOAT |  | N | 0 | ddl |
| 38 | IT_TYPE | VARCHAR | 1 | Y |  | ddl |
| 39 | TCS_CODE | VARCHAR | 1 | Y |  | ddl |
| 40 | CARD_AC | VARCHAR | 10 | Y |  | ddl |
| 41 | BANK_AC | VARCHAR | 10 | Y |  | ddl |
| 42 | CHQ_NO | VARCHAR | 10 | Y |  | ddl |
| 43 | BANK_NAME | VARCHAR | 50 | Y |  | ddl |
| 44 | TCS_PRC | FLOAT |  | N | 0 | ddl |
| 45 | TCS_AMT | FLOAT |  | N | 0 | ddl |
| 46 | TDS_CODE | VARCHAR | 2 | Y |  | ddl |
| 47 | TDS_PRC | FLOAT |  | N | 0 | ddl |
| 48 | TDS_AMT | FLOAT |  | N | 0 | ddl |
| 49 | VCH_DESC | VARCHAR | 150 | Y |  | ddl |
| 50 | EMP_CODE | VARCHAR | 3 | Y |  | ddl |
| 51 | OLD_VCH_NO | VARCHAR | 8 | Y |  | ddl |
| 52 | NEW_VCH_NO | VARCHAR | 8 | Y |  | ddl |
| 53 | DATA_TRFR | VARCHAR | 1 | Y |  | ddl |
| 54 | HD_VCH_NO | VARCHAR | 8 | Y |  | ddl |
| 55 | MAIN_USER | VARCHAR | 15 | Y |  | ddl |
| 56 | ADD_USER | VARCHAR | 15 | Y |  | ddl |
| 57 | FROM_FAN_CODE | VARCHAR | 2 | Y |  | ddl |
| 58 | STK_TRFR | VARCHAR | 1 | Y |  | ddl |
| 59 | TO_VCH_NO | VARCHAR | 10 | Y |  | ddl |
| 60 | TO_CO_BOOK | VARCHAR | 3 | Y |  | ddl |
| 61 | FROM_VCH_NO | VARCHAR | 10 | Y |  | ddl |
| 62 | FROM_CO_BOOK | VARCHAR | 3 | Y |  | ddl |
| 63 | USER_UPDATE | VARCHAR | 1 | Y |  | ddl |
| 64 | USER_DELETE | VARCHAR | 1 | Y |  | ddl |
| 65 | TAG_VCH_NO | VARCHAR | 10 | Y |  | ddl |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
