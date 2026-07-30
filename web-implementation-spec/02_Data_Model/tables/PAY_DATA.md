# PAY_DATA

- **Cluster:** finance
- **Source:** DDL
- **Columns:** 36
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
| 8 | BILL_NO | VARCHAR | 30 | Y |  | ddl |
| 9 | BILL_DATE | DATE |  | Y |  | ddl |
| 10 | BILL_TYPE | VARCHAR | 1 | Y |  | ddl |
| 11 | VCH_TYPE | VARCHAR | 6 | Y |  | ddl |
| 12 | INOUT_TYPE | VARCHAR | 1 | Y |  | ddl |
| 13 | ENTRY_TYPE | VARCHAR | 1 | Y |  | ddl |
| 14 | BOOK_NAME | VARCHAR | 20 | Y |  | ddl |
| 15 | AC_CODE | VARCHAR | 8 | Y |  | ddl |
| 16 | AC_NAME | VARCHAR | 50 | Y |  | ddl |
| 17 | AC_TYPE | VARCHAR | 1 | Y |  | ddl |
| 18 | LEDR_CODE | VARCHAR | 8 | Y |  | ddl |
| 19 | NET_AMT | FLOAT |  | N | 0 | ddl |
| 20 | IGST_TAX | FLOAT |  | N | 0 | ddl |
| 21 | CGST_TAX | FLOAT |  | N | 0 | ddl |
| 22 | SGST_TAX | FLOAT |  | N | 0 | ddl |
| 23 | TOT_AMT | FLOAT |  | N | 0 | ddl |
| 24 | CASH_AMT | FLOAT |  | N | 0 | ddl |
| 25 | CHQ_AMT | FLOAT |  | N | 0 | ddl |
| 26 | BANK_AC | VARCHAR | 8 | Y |  | ddl |
| 27 | CHQ_NO | VARCHAR | 10 | Y |  | ddl |
| 28 | CARD_AMT | FLOAT |  | N | 0 | ddl |
| 29 | CARD_AC | VARCHAR | 8 | Y |  | ddl |
| 30 | KASAR_AMT | FLOAT |  | N | 0 | ddl |
| 31 | BILL_OS | FLOAT |  | N | 0 | ddl |
| 32 | HD_VCH_NO | VARCHAR | 10 | Y |  | ddl |
| 33 | EMP_CODE | VARCHAR | 5 | Y |  | ddl |
| 34 | VCH_DESC | VARCHAR | 50 | Y |  | ddl |
| 35 | DATA_TRFR | VARCHAR | 1 | Y |  | ddl |
| 36 | MAIN_USER | VARCHAR | 15 | Y |  | ddl |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
