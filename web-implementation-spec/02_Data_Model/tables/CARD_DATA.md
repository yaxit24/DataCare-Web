# CARD_DATA

- **Cluster:** finance
- **Source:** DDL
- **Columns:** 39
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
| 7 | VCH_TYPE | VARCHAR | 5 | Y |  | ddl |
| 8 | INOUT_TYPE | VARCHAR | 1 | Y |  | ddl |
| 9 | ENTRY_TYPE | VARCHAR | 1 | Y |  | ddl |
| 10 | BOOK_NAME | VARCHAR | 15 | Y |  | ddl |
| 11 | VCH_TIME | DATETIME |  | Y |  | ddl |
| 12 | AC_CODE | VARCHAR | 8 | Y |  | ddl |
| 13 | AC_NAME | VARCHAR | 50 | Y |  | ddl |
| 14 | BILL_NO | VARCHAR | 8 | Y |  | ddl |
| 15 | BILL_LC_CODE | VARCHAR | 2 | Y |  | ddl |
| 16 | BILL_YRCD | VARCHAR | 10 | Y |  | ddl |
| 17 | BILL_DBCD | VARCHAR | 8 | Y |  | ddl |
| 18 | BILL_AMT | FLOAT |  | N | 0 | ddl |
| 19 | BILL_ADJ_AMT | FLOAT |  | N | 0 | ddl |
| 20 | BILL_OS_AMT | FLOAT |  | N | 0 | ddl |
| 21 | CARD_AMT | FLOAT |  | N | 0 | ddl |
| 22 | CARD_COM_PRC | FLOAT |  | N | 0 | ddl |
| 23 | CARD_COM_AMT | FLOAT |  | N | 0 | ddl |
| 24 | CARD_REC_AMT | FLOAT |  | N | 0 | ddl |
| 25 | CASH_PAID | FLOAT |  | N | 0 | ddl |
| 26 | BANK_ACCD | VARCHAR | 8 | Y |  | ddl |
| 27 | BANK_NAME | VARCHAR | 50 | Y |  | ddl |
| 28 | BANK_COM_PRC | FLOAT |  | N | 0 | ddl |
| 29 | BANK_SCH_PRC | FLOAT |  | N | 0 | ddl |
| 30 | BANK_COMM_1 | FLOAT |  | N | 0 | ddl |
| 31 | BANK_COMM_2 | FLOAT |  | N | 0 | ddl |
| 32 | BANK_COM_AMT | FLOAT |  | N | 0 | ddl |
| 33 | BANK_NET_AMT | FLOAT |  | N | 0 | ddl |
| 34 | IT_DESC | VARCHAR | 150 | Y |  | ddl |
| 35 | EMP_CODE | VARCHAR | 3 | Y |  | ddl |
| 36 | DATA_TRFR | VARCHAR | 1 | Y | 'N' | ddl |
| 37 | HD_VCH_NO | VARCHAR | 8 | Y |  | ddl |
| 38 | MAIN_USER | VARCHAR | 15 | Y |  | ddl |
| 39 | ADD_USER | VARCHAR | 15 | Y |  | ddl |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
