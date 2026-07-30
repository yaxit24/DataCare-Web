# REP_DATA

- **Cluster:** manufacturing
- **Source:** DDL
- **Columns:** 45
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
| 7 | BILL_NO | VARCHAR | 20 | Y |  | ddl |
| 8 | BILL_DATE | DATE |  | Y |  | ddl |
| 9 | VCH_TYPE | VARCHAR | 6 | Y |  | ddl |
| 10 | INOUT_TYPE | VARCHAR | 1 | Y |  | ddl |
| 11 | ENTRY_TYPE | VARCHAR | 1 | Y |  | ddl |
| 12 | VCH_TIME | DATETIME |  | Y |  | ddl |
| 13 | BOOK_NAME | VARCHAR | 20 | Y |  | ddl |
| 14 | AC_CODE | VARCHAR | 8 | Y |  | ddl |
| 15 | AC_NAME | VARCHAR | 50 | Y |  | ddl |
| 16 | NET_AMT | FLOAT |  | N | 0 | ddl |
| 17 | DISC_PRC | FLOAT |  | N | 0 | ddl |
| 18 | DISC_AMT | FLOAT |  | N | 0 | ddl |
| 19 | TAX_CODE | VARCHAR | 2 | Y |  | ddl |
| 20 | TAX_PRC | FLOAT |  | N | 0 | ddl |
| 21 | TAX_AMT | FLOAT |  | N | 0 | ddl |
| 22 | AC_GST_TYPE | VARCHAR | 1 | Y |  | ddl |
| 23 | IGST_TAX | FLOAT |  | N | 0 | ddl |
| 24 | CGST_TAX | FLOAT |  | N | 0 | ddl |
| 25 | SGST_TAX | FLOAT |  | N | 0 | ddl |
| 26 | GR_WT | FLOAT |  | N | 0 | ddl |
| 27 | NET_WT | FLOAT |  | N | 0 | ddl |
| 28 | ROF_AMT | FLOAT |  | N | 0 | ddl |
| 29 | TOT_AMT | FLOAT |  | N | 0 | ddl |
| 30 | CASH_AMT | FLOAT |  | N | 0 | ddl |
| 31 | CHQ_AMT | FLOAT |  | N | 0 | ddl |
| 32 | BANK_AC | VARCHAR | 8 | Y |  | ddl |
| 33 | CHQ_NO | VARCHAR | 10 | Y |  | ddl |
| 34 | BANK_NAME | VARCHAR | 50 | Y |  | ddl |
| 35 | CARD_AMT | FLOAT |  | N | 0 | ddl |
| 36 | CARD_AC | VARCHAR | 8 | Y |  | ddl |
| 37 | KASAR_AMT | FLOAT |  | N | 0 | ddl |
| 38 | BILL_OS | FLOAT |  | N | 0 | ddl |
| 39 | HD_VCH_NO | VARCHAR | 10 | Y |  | ddl |
| 40 | OLD_VCH_NO | VARCHAR | 10 | Y |  | ddl |
| 41 | NEW_VCH_NO | VARCHAR | 10 | Y |  | ddl |
| 42 | EMP_CODE | VARCHAR | 5 | Y |  | ddl |
| 43 | VCH_DESC | VARCHAR | 50 | Y |  | ddl |
| 44 | DATA_TRFR | VARCHAR | 1 | Y |  | ddl |
| 45 | MAIN_USER | VARCHAR | 15 | Y |  | ddl |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
