# TAG_PRINT_DATA

- **Cluster:** inventory
- **Source:** code-recovered
- **Columns:** 60
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
| 7 | IT_CODE | VARCHAR | 5 | Y |  | code+inferred-type |
| 8 | VCH_SRNO | FLOAT |  | Y |  | code+inferred-type |
| 9 | OLD_SRNO | FLOAT |  | Y |  | code+inferred-type |
| 10 | VCH_DATE | DATE |  | Y |  | code+inferred-type |
| 11 | STK_DATE | unknown |  | Y |  | code |
| 12 | VCH_TIME | DATETIME |  | Y |  | code+inferred-type |
| 13 | VCH_TYPE | VARCHAR | 6 | Y |  | code+inferred-type |
| 14 | INOUT_TYPE | VARCHAR | 1 | Y |  | code+inferred-type |
| 15 | ENTRY_TYPE | VARCHAR | 1 | Y |  | code+inferred-type |
| 16 | BOOK_NAME | VARCHAR | 20 | Y |  | code+inferred-type |
| 17 | AC_CODE | VARCHAR | 8 | Y |  | code+inferred-type |
| 18 | TAG_NO | VARCHAR | 15 | Y |  | code+inferred-type |
| 19 | LOT_NO | VARCHAR | 15 | Y |  | code+inferred-type |
| 20 | DESIGN_NO | VARCHAR | 15 | Y |  | code+inferred-type |
| 21 | TBL_CODE | VARCHAR | 3 | Y |  | code+inferred-type |
| 22 | ITM_SIZE | VARCHAR | 20 | Y |  | code+inferred-type |
| 23 | ITM_PCS | FLOAT |  | Y |  | code+inferred-type |
| 24 | BAG_WT | FLOAT |  | Y |  | code+inferred-type |
| 25 | ITM_GWT | FLOAT |  | Y |  | code+inferred-type |
| 26 | ITM_OTH_WT | FLOAT |  | Y |  | code+inferred-type |
| 27 | ITM_NWT | FLOAT |  | Y |  | code+inferred-type |
| 28 | ITM_GHT_PRC | FLOAT |  | Y |  | code+inferred-type |
| 29 | ITM_GHT_WT | FLOAT |  | Y |  | code+inferred-type |
| 30 | ITM_TOUCH | FLOAT |  | Y |  | code+inferred-type |
| 31 | ITM_WEST_PRC | FLOAT |  | Y |  | code+inferred-type |
| 32 | ITM_FINE | FLOAT |  | Y |  | code+inferred-type |
| 33 | LBR_PRC | FLOAT |  | Y |  | code+inferred-type |
| 34 | LBR_RATE | FLOAT |  | Y |  | code+inferred-type |
| 35 | LBR_TYPE | VARCHAR | 1 | Y |  | code+inferred-type |
| 36 | LBR_AMT | FLOAT |  | Y |  | code+inferred-type |
| 37 | OTH_AMT | FLOAT |  | Y |  | code+inferred-type |
| 38 | ITM_RATE | FLOAT |  | Y |  | code+inferred-type |
| 39 | ITM_AMT | FLOAT |  | Y |  | code+inferred-type |
| 40 | TAG_COST | FLOAT |  | Y |  | code+inferred-type |
| 41 | ITM_MARGIN | FLOAT |  | Y |  | code+inferred-type |
| 42 | ITM_MRP | FLOAT |  | Y |  | code+inferred-type |
| 43 | ITM_REMARK | VARCHAR | 50 | Y |  | code+inferred-type |
| 44 | SF_NO | unknown |  | Y |  | code |
| 45 | KR_NAME | VARCHAR | 5 | Y |  | code+inferred-type |
| 46 | RATE_TYPE | VARCHAR | 1 | Y |  | code+inferred-type |
| 47 | IT_TYPE | VARCHAR | 1 | Y |  | code+inferred-type |
| 48 | TAG_TYPE | VARCHAR | 1 | Y |  | code+inferred-type |
| 49 | PR_CODE | VARCHAR | 2 | Y |  | code+inferred-type |
| 50 | HM_ID | VARCHAR | 10 | Y |  | code+inferred-type |
| 51 | HM_ID2 | VARCHAR | 10 | Y |  | code+inferred-type |
| 52 | HM_ID3 | VARCHAR | 10 | Y |  | code+inferred-type |
| 53 | HM_ID4 | VARCHAR | 10 | Y |  | code+inferred-type |
| 54 | HM_ID_WT | FLOAT |  | Y |  | code+inferred-type |
| 55 | HM_ID2_WT | FLOAT |  | Y |  | code+inferred-type |
| 56 | HM_ID3_WT | FLOAT |  | Y |  | code+inferred-type |
| 57 | HM_ID4_WT | FLOAT |  | Y |  | code+inferred-type |
| 58 | ITM_COLOR | VARCHAR | 15 | Y |  | code+inferred-type |
| 59 | LBR_CODE | VARCHAR | 2 | Y |  | code+inferred-type |
| 60 | ITM_STYLE | unknown |  | Y |  | code |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
