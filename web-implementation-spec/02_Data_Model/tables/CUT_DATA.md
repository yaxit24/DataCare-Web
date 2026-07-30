# CUT_DATA

- **Cluster:** ancillary
- **Source:** DDL
- **Columns:** 43
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
| 8 | BILL_NO | VARCHAR | 20 | Y |  | ddl |
| 9 | BILL_DATE | DATE |  | Y |  | ddl |
| 10 | VCH_TYPE | VARCHAR | 6 | Y |  | ddl |
| 11 | INOUT_TYPE | VARCHAR | 1 | Y |  | ddl |
| 12 | ENTRY_TYPE | VARCHAR | 1 | Y |  | ddl |
| 13 | BOOK_NAME | VARCHAR | 20 | Y |  | ddl |
| 14 | AC_CODE | VARCHAR | 8 | Y |  | ddl |
| 15 | AC_NAME | VARCHAR | 50 | Y |  | ddl |
| 16 | IT_TYPE | VARCHAR | 1 | Y |  | ddl |
| 17 | NET_AMT | FLOAT |  | N | 0 | ddl |
| 18 | TAX_CODE | VARCHAR | 2 | Y |  | ddl |
| 19 | TAX_PRC | FLOAT |  | N | 0 | ddl |
| 20 | TAX_AMT | FLOAT |  | N | 0 | ddl |
| 21 | ROF_AMT | FLOAT |  | N | 0 | ddl |
| 22 | TOT_AMT | FLOAT |  | N | 0 | ddl |
| 23 | CASH_AMT | FLOAT |  | N | 0 | ddl |
| 24 | CHQ_AMT | FLOAT |  | N | 0 | ddl |
| 25 | CARD_AMT | FLOAT |  | N | 0 | ddl |
| 26 | KASAR_AMT | FLOAT |  | N | 0 | ddl |
| 27 | BILL_OS | FLOAT |  | N | 0 | ddl |
| 28 | CARD_AC | VARCHAR | 10 | Y |  | ddl |
| 29 | BANK_AC | VARCHAR | 10 | Y |  | ddl |
| 30 | CHQ_NO | VARCHAR | 10 | Y |  | ddl |
| 31 | EMP_CODE | VARCHAR | 3 | Y |  | ddl |
| 32 | VCH_DESC | VARCHAR | 100 | Y |  | ddl |
| 33 | AC_GST_TYPE | VARCHAR | 1 | Y |  | ddl |
| 34 | IGST_TAX | FLOAT |  | N | 0 | ddl |
| 35 | CGST_TAX | FLOAT |  | N | 0 | ddl |
| 36 | SGST_TAX | FLOAT |  | N | 0 | ddl |
| 37 | TDS_CODE | VARCHAR | 2 | Y |  | ddl |
| 38 | TDS_PRC | FLOAT |  | N | 0 | ddl |
| 39 | TDS_AMT | FLOAT |  | N | 0 | ddl |
| 40 | USER_UPDATE | VARCHAR | 1 | Y |  | ddl |
| 41 | USER_DELETE | VARCHAR | 1 | Y |  | ddl |
| 42 | MAIN_USER | VARCHAR | 15 | Y |  | ddl |
| 43 | DATA_TRFR | VARCHAR | 1 | Y |  | ddl |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
