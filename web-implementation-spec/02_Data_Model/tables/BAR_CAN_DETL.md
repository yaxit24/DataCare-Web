# BAR_CAN_DETL

- **Cluster:** inventory
- **Source:** code-recovered
- **Columns:** 58
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
| 8 | OLD_SRNO | FLOAT |  | Y |  | code+inferred-type |
| 9 | VCH_DATE | DATE |  | Y |  | code+inferred-type |
| 10 | VCH_TIME | DATETIME |  | Y |  | code+inferred-type |
| 11 | VCH_TYPE | VARCHAR | 6 | Y |  | code+inferred-type |
| 12 | INOUT_TYPE | VARCHAR | 1 | Y |  | code+inferred-type |
| 13 | ENTRY_TYPE | VARCHAR | 1 | Y |  | code+inferred-type |
| 14 | BOOK_NAME | VARCHAR | 20 | Y |  | code+inferred-type |
| 15 | AC_CODE | VARCHAR | 8 | Y |  | code+inferred-type |
| 16 | IT_CODE | VARCHAR | 5 | Y |  | code+inferred-type |
| 17 | TAG_NO | VARCHAR | 15 | Y |  | code+inferred-type |
| 18 | LOT_NO | VARCHAR | 15 | Y |  | code+inferred-type |
| 19 | DESIGN_NO | VARCHAR | 15 | Y |  | code+inferred-type |
| 20 | TBL_CODE | VARCHAR | 3 | Y |  | code+inferred-type |
| 21 | ITM_SIZE | VARCHAR | 20 | Y |  | code+inferred-type |
| 22 | ITM_PCS | FLOAT |  | Y |  | code+inferred-type |
| 23 | BAG_WT | FLOAT |  | Y |  | code+inferred-type |
| 24 | ITM_GWT | FLOAT |  | Y |  | code+inferred-type |
| 25 | ITM_OTH_WT | FLOAT |  | Y |  | code+inferred-type |
| 26 | ITM_NWT | FLOAT |  | Y |  | code+inferred-type |
| 27 | ITM_GHT_WT | FLOAT |  | Y |  | code+inferred-type |
| 28 | ITM_TOUCH | FLOAT |  | Y |  | code+inferred-type |
| 29 | ITM_WEST_PRC | FLOAT |  | Y |  | code+inferred-type |
| 30 | ITM_FINE | FLOAT |  | Y |  | code+inferred-type |
| 31 | LBR_PRC | FLOAT |  | Y |  | code+inferred-type |
| 32 | LBR_RATE | FLOAT |  | Y |  | code+inferred-type |
| 33 | LBR_TYPE | VARCHAR | 1 | Y |  | code+inferred-type |
| 34 | LBR_AMT | FLOAT |  | Y |  | code+inferred-type |
| 35 | OTH_AMT | FLOAT |  | Y |  | code+inferred-type |
| 36 | ITM_RATE | FLOAT |  | Y |  | code+inferred-type |
| 37 | ITM_AMT | FLOAT |  | Y |  | code+inferred-type |
| 38 | TAG_COST | FLOAT |  | Y |  | code+inferred-type |
| 39 | ITM_MRP | FLOAT |  | Y |  | code+inferred-type |
| 40 | ITM_REMARK | VARCHAR | 50 | Y |  | code+inferred-type |
| 41 | KR_NET_WT | FLOAT |  | Y |  | code+inferred-type |
| 42 | KR_TOUCH | FLOAT |  | Y |  | code+inferred-type |
| 43 | KR_WEST_PRC | FLOAT |  | Y |  | code+inferred-type |
| 44 | KR_FINE | FLOAT |  | Y |  | code+inferred-type |
| 45 | KR_NAME | VARCHAR | 5 | Y |  | code+inferred-type |
| 46 | RATE_TYPE | VARCHAR | 1 | Y |  | code+inferred-type |
| 47 | IT_TYPE | VARCHAR | 1 | Y |  | code+inferred-type |
| 48 | PR_CODE | VARCHAR | 2 | Y |  | code+inferred-type |
| 49 | HD_VCH_NO | VARCHAR | 10 | Y |  | code+inferred-type |
| 50 | MAIN_USER | VARCHAR | 15 | Y |  | code+inferred-type |
| 51 | ADD_USER | VARCHAR | 15 | Y |  | code+inferred-type |
| 52 | DATA_TRFR | VARCHAR | 1 | Y |  | code+inferred-type |
| 53 | ITM_SIGN | VARCHAR | 1 | Y |  | code+inferred-type |
| 54 | TRFR_IT_CODE | unknown |  | Y |  | code |
| 55 | TO_TBL_CODE | unknown |  | Y |  | code |
| 56 | TAG_NWT | unknown |  | Y |  | code |
| 57 | IT_DESC | VARCHAR | 50 | Y |  | code+inferred-type |
| 58 | TBL_POSTING | unknown |  | Y |  | code |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
