# BAR_CAN_IDTL

- **Cluster:** inventory
- **Source:** code-recovered
- **Columns:** 43
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
| 7 | ISR_NO | FLOAT |  | Y |  | code+inferred-type |
| 8 | VCH_DATE | DATE |  | Y |  | code+inferred-type |
| 9 | VCH_TYPE | VARCHAR | 6 | Y |  | code+inferred-type |
| 10 | INOUT_TYPE | VARCHAR | 1 | Y |  | code+inferred-type |
| 11 | ENTRY_TYPE | VARCHAR | 1 | Y |  | code+inferred-type |
| 12 | BOOK_NAME | VARCHAR | 20 | Y |  | code+inferred-type |
| 13 | AC_CODE | VARCHAR | 8 | Y |  | code+inferred-type |
| 14 | TAG_NO | VARCHAR | 15 | Y |  | code+inferred-type |
| 15 | VCH_SRNO | FLOAT |  | Y |  | code+inferred-type |
| 16 | IT_CODE | VARCHAR | 5 | Y |  | code+inferred-type |
| 17 | IT_TYPE | VARCHAR | 1 | Y |  | code+inferred-type |
| 18 | DM_CODE | VARCHAR | 8 | Y |  | code+inferred-type |
| 19 | DM_SIZE | VARCHAR | 20 | Y |  | code+inferred-type |
| 20 | DM_SFNO | VARCHAR | 20 | Y |  | code+inferred-type |
| 21 | DM_LEB | VARCHAR | 15 | Y |  | code+inferred-type |
| 22 | IT_PCS | FLOAT |  | Y |  | code+inferred-type |
| 23 | IT_PCS_WT | FLOAT |  | Y |  | code+inferred-type |
| 24 | KR_WT | FLOAT |  | Y |  | code+inferred-type |
| 25 | KR_LESS_PRC | FLOAT |  | Y |  | code+inferred-type |
| 26 | IT_GWT | FLOAT |  | Y |  | code+inferred-type |
| 27 | IT_CON_PRC | FLOAT |  | Y |  | code+inferred-type |
| 28 | IT_CON_WT | FLOAT |  | Y |  | code+inferred-type |
| 29 | IT_RATE_TYPE | VARCHAR | 1 | Y |  | code+inferred-type |
| 30 | IT_RATE | FLOAT |  | Y |  | code+inferred-type |
| 31 | IT_AMT | FLOAT |  | Y |  | code+inferred-type |
| 32 | IT_LBR_RATE | FLOAT |  | Y |  | code+inferred-type |
| 33 | IT_LBR_AMT | FLOAT |  | Y |  | code+inferred-type |
| 34 | IT_NET_AMT | FLOAT |  | Y |  | code+inferred-type |
| 35 | KR_CON_PRC | FLOAT |  | Y |  | code+inferred-type |
| 36 | KR_CON_WT | FLOAT |  | Y |  | code+inferred-type |
| 37 | KR_RATE | FLOAT |  | Y |  | code+inferred-type |
| 38 | KR_AMT | FLOAT |  | Y |  | code+inferred-type |
| 39 | KR_LBR_RATE | FLOAT |  | Y |  | code+inferred-type |
| 40 | KR_LBR_AMT | FLOAT |  | Y |  | code+inferred-type |
| 41 | KR_NET_AMT | FLOAT |  | Y |  | code+inferred-type |
| 42 | MAIN_USER | VARCHAR | 15 | Y |  | code+inferred-type |
| 43 | HD_VCH_NO | VARCHAR | 10 | Y |  | code+inferred-type |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
