# TAX_DATA

- **Cluster:** gst_tax
- **Source:** code-recovered
- **Columns:** 23
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
| 6 | SR_NO | FLOAT |  | Y |  | code+inferred-type |
| 7 | BOOK_NAME | VARCHAR | 20 | Y |  | code+inferred-type |
| 8 | TRAN_TYPE | unknown |  | Y |  | code |
| 9 | VCH_DATE | DATE |  | Y |  | code+inferred-type |
| 10 | AC_CODE | VARCHAR | 8 | Y |  | code+inferred-type |
| 11 | TAX_CODE | VARCHAR | 2 | Y |  | code+inferred-type |
| 12 | TAX_TYPE | VARCHAR | 1 | Y |  | code+inferred-type |
| 13 | TAX_PRC | FLOAT |  | Y |  | code+inferred-type |
| 14 | NET_AMT | FLOAT |  | Y |  | code+inferred-type |
| 15 | TAX_AMT | FLOAT |  | Y |  | code+inferred-type |
| 16 | DISC_AMT | FLOAT |  | Y |  | code+inferred-type |
| 17 | TOT_AMT | FLOAT |  | Y |  | code+inferred-type |
| 18 | TAX_SIGN | unknown |  | Y |  | code |
| 19 | PARTY_NAME | unknown |  | Y |  | code |
| 20 | R_CHARG | unknown |  | Y |  | code |
| 21 | ISR_NO | FLOAT |  | Y |  | code+inferred-type |
| 22 | TAX_FREE_AMT | unknown |  | Y |  | code |
| 23 | ZERO_RATED_AMT | unknown |  | Y |  | code |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
