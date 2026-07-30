# MAIN_STOCK

- **Cluster:** inventory
- **Source:** code-recovered
- **Columns:** 50
- **Primary key:** (none recovered)
- **Tenant/scope keys present:** CO_CODE, LC_CODE, CO_YEAR, CO_BOOK  ·  fully tenant-keyed
- **Web mapping:** `tenant_id` + the scope keys above; preserve column names verbatim.

| # | Column | Type | Len | Null | Default | Source |
|---|--------|------|-----|------|---------|--------|
| 1 | VCH_SRNO | FLOAT |  | Y |  | code+inferred-type |
| 2 | CO_CODE ⟨scope⟩ | VARCHAR | 2 | Y |  | code+inferred-type |
| 3 | LC_CODE ⟨scope⟩ | VARCHAR | 2 | Y |  | code+inferred-type |
| 4 | CO_YEAR ⟨scope⟩ | VARCHAR | 10 | Y |  | code+inferred-type |
| 5 | CO_BOOK ⟨scope⟩ | VARCHAR | 3 | Y |  | code+inferred-type |
| 6 | VCH_NO | VARCHAR | 8 | Y |  | code+inferred-type |
| 7 | SR_NO | FLOAT |  | Y |  | code+inferred-type |
| 8 | ISR_NO | FLOAT |  | Y |  | code+inferred-type |
| 9 | VCH_DATE | DATE |  | Y |  | code+inferred-type |
| 10 | STK_DATE | unknown |  | Y |  | code |
| 11 | VCH_TYPE | VARCHAR | 6 | Y |  | code+inferred-type |
| 12 | BOOK_NAME | VARCHAR | 20 | Y |  | code+inferred-type |
| 13 | AC_CODE | VARCHAR | 8 | Y |  | code+inferred-type |
| 14 | IT_CODE | VARCHAR | 5 | Y |  | code+inferred-type |
| 15 | TAG_NO | VARCHAR | 15 | Y |  | code+inferred-type |
| 16 | TBL_CODE | VARCHAR | 3 | Y |  | code+inferred-type |
| 17 | TR_TYPE | VARCHAR | 1 | Y |  | code+inferred-type |
| 18 | ITM_SIGN | VARCHAR | 1 | Y |  | code+inferred-type |
| 19 | ITM_QTY | FLOAT |  | Y |  | code+inferred-type |
| 20 | ITM_PCS | FLOAT |  | Y |  | code+inferred-type |
| 21 | ITM_GWT | FLOAT |  | Y |  | code+inferred-type |
| 22 | ITM_NWT | FLOAT |  | Y |  | code+inferred-type |
| 23 | ITM_TOUCH | FLOAT |  | Y |  | code+inferred-type |
| 24 | ITM_WEST | FLOAT |  | Y |  | code+inferred-type |
| 25 | ITM_FINE | FLOAT |  | Y |  | code+inferred-type |
| 26 | ITM_RATE | FLOAT |  | Y |  | code+inferred-type |
| 27 | ITM_AMT | FLOAT |  | Y |  | code+inferred-type |
| 28 | LBR_RATE | FLOAT |  | Y |  | code+inferred-type |
| 29 | LBR_AMT | FLOAT |  | Y |  | code+inferred-type |
| 30 | OTH_AMT | FLOAT |  | Y |  | code+inferred-type |
| 31 | ITM_MRP | FLOAT |  | Y |  | code+inferred-type |
| 32 | NET_AMT | FLOAT |  | Y |  | code+inferred-type |
| 33 | KR_NWT | unknown |  | Y |  | code |
| 34 | KR_TOUCH | FLOAT |  | Y |  | code+inferred-type |
| 35 | KR_WEST | unknown |  | Y |  | code |
| 36 | KR_FINE | FLOAT |  | Y |  | code+inferred-type |
| 37 | KR_LBR_AMT | FLOAT |  | Y |  | code+inferred-type |
| 38 | KR_OTH_AMT | unknown |  | Y |  | code |
| 39 | KR_COST | unknown |  | Y |  | code |
| 40 | EMP_CODE | VARCHAR | 3 | Y |  | code+inferred-type |
| 41 | ENTRY_TIME | DATE |  | Y |  | code+inferred-type |
| 42 | MAIN_USER | VARCHAR | 15 | Y |  | code+inferred-type |
| 43 | DATA_TYPE | VARCHAR | 1 | Y |  | code+inferred-type |
| 44 | DESIGN_NO | VARCHAR | 15 | Y |  | code+inferred-type |
| 45 | ITM_SIZE | VARCHAR | 20 | Y |  | code+inferred-type |
| 46 | ITM_DESC | unknown |  | Y |  | code |
| 47 | GHT_PRC | FLOAT |  | Y |  | code+inferred-type |
| 48 | ITM_LOT | unknown |  | Y |  | code |
| 49 | ITM_DISC | unknown |  | Y |  | code |
| 50 | GRID_SCROLL | unknown |  | Y |  | code |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
