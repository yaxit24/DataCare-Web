# PAY_DETL

- **Cluster:** finance
- **Source:** DDL
- **Columns:** 31
- **Primary key:** CO_CODE, LC_CODE, CO_YEAR, CO_BOOK, VCH_NO, SR_NO
- **Tenant/scope keys present:** CO_CODE, LC_CODE, CO_YEAR, CO_BOOK  ·  fully tenant-keyed
- **Web mapping:** `tenant_id` + the scope keys above; preserve column names verbatim.

| # | Column | Type | Len | Null | Default | Source |
|---|--------|------|-----|------|---------|--------|
| 1 | CO_CODE 🔑 ⟨scope⟩ | VARCHAR | 2 | Y |  | ddl |
| 2 | LC_CODE 🔑 ⟨scope⟩ | VARCHAR | 2 | Y |  | ddl |
| 3 | CO_YEAR 🔑 ⟨scope⟩ | VARCHAR | 10 | Y |  | ddl |
| 4 | CO_BOOK 🔑 ⟨scope⟩ | VARCHAR | 3 | Y |  | ddl |
| 5 | VCH_NO 🔑 | VARCHAR | 8 | Y |  | ddl |
| 6 | SR_NO 🔑 | FLOAT |  | N | 0 | ddl |
| 7 | VCH_DATE | DATE |  | Y |  | ddl |
| 8 | VCH_TIME | DATETIME |  | Y |  | ddl |
| 9 | BILL_NO | VARCHAR | 30 | Y |  | ddl |
| 10 | BILL_DATE | DATE |  | Y |  | ddl |
| 11 | BILL_TYPE | VARCHAR | 1 | Y |  | ddl |
| 12 | VCH_TYPE | VARCHAR | 6 | Y |  | ddl |
| 13 | INOUT_TYPE | VARCHAR | 1 | Y |  | ddl |
| 14 | ENTRY_TYPE | VARCHAR | 1 | Y |  | ddl |
| 15 | BOOK_NAME | VARCHAR | 20 | Y |  | ddl |
| 16 | AC_CODE | VARCHAR | 8 | Y |  | ddl |
| 17 | HSN_CODE | VARCHAR | 10 | Y |  | ddl |
| 18 | IT_NAME | VARCHAR | 50 | Y |  | ddl |
| 19 | TAX_CODE | VARCHAR | 2 | Y |  | ddl |
| 20 | TAX_PRC | FLOAT |  | N | 0 | ddl |
| 21 | NET_AMT | FLOAT |  | N | 0 | ddl |
| 22 | TAX_TYPE | VARCHAR | 1 | Y |  | ddl |
| 23 | TAXABLE_AMT | FLOAT |  | N | 0 | ddl |
| 24 | IGST_PRC | FLOAT |  | N | 0 | ddl |
| 25 | IGST_TAX | FLOAT |  | N | 0 | ddl |
| 26 | CGST_PRC | FLOAT |  | N | 0 | ddl |
| 27 | CGST_TAX | FLOAT |  | N | 0 | ddl |
| 28 | SGST_PRC | FLOAT |  | N | 0 | ddl |
| 29 | SGST_TAX | FLOAT |  | N | 0 | ddl |
| 30 | TOT_AMT | FLOAT |  | N | 0 | ddl |
| 31 | MAIN_USER | VARCHAR | 15 | Y |  | ddl |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
