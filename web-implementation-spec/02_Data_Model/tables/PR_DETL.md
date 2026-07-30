# PR_DETL

- **Cluster:** purchase
- **Source:** code-recovered
- **Columns:** 68
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
| 7 | OLD_SRNO | FLOAT |  | Y |  | code+inferred-type |
| 8 | VCH_DATE | DATE |  | Y |  | code+inferred-type |
| 9 | VCH_TIME | DATETIME |  | Y |  | code+inferred-type |
| 10 | VCH_TYPE | VARCHAR | 6 | Y |  | code+inferred-type |
| 11 | INOUT_TYPE | VARCHAR | 1 | Y |  | code+inferred-type |
| 12 | ENTRY_TYPE | VARCHAR | 1 | Y |  | code+inferred-type |
| 13 | BOOK_NAME | VARCHAR | 20 | Y |  | code+inferred-type |
| 14 | AC_CODE | VARCHAR | 8 | Y |  | code+inferred-type |
| 15 | IT_CODE | VARCHAR | 5 | Y |  | code+inferred-type |
| 16 | TAG_NO | VARCHAR | 15 | Y |  | code+inferred-type |
| 17 | LOT_NO | VARCHAR | 15 | Y |  | code+inferred-type |
| 18 | DESIGN_NO | VARCHAR | 15 | Y |  | code+inferred-type |
| 19 | TBL_CODE | VARCHAR | 3 | Y |  | code+inferred-type |
| 20 | ITM_SIZE | VARCHAR | 20 | Y |  | code+inferred-type |
| 21 | ITM_PCS | FLOAT |  | Y |  | code+inferred-type |
| 22 | BAG_WT | FLOAT |  | Y |  | code+inferred-type |
| 23 | ITM_GWT | FLOAT |  | Y |  | code+inferred-type |
| 24 | ITM_OTH_WT | FLOAT |  | Y |  | code+inferred-type |
| 25 | ITM_NWT | FLOAT |  | Y |  | code+inferred-type |
| 26 | ITM_GHT_WT | FLOAT |  | Y |  | code+inferred-type |
| 27 | ITM_TOUCH | FLOAT |  | Y |  | code+inferred-type |
| 28 | ITM_WEST_PRC | FLOAT |  | Y |  | code+inferred-type |
| 29 | ITM_FINE | FLOAT |  | Y |  | code+inferred-type |
| 30 | LBR_PRC | FLOAT |  | Y |  | code+inferred-type |
| 31 | LBR_RATE | FLOAT |  | Y |  | code+inferred-type |
| 32 | LBR_TYPE | VARCHAR | 1 | Y |  | code+inferred-type |
| 33 | LBR_AMT | FLOAT |  | Y |  | code+inferred-type |
| 34 | OTH_AMT | FLOAT |  | Y |  | code+inferred-type |
| 35 | ITM_RATE | FLOAT |  | Y |  | code+inferred-type |
| 36 | ITM_AMT | FLOAT |  | Y |  | code+inferred-type |
| 37 | TAG_COST | FLOAT |  | Y |  | code+inferred-type |
| 38 | ITM_MRP | FLOAT |  | Y |  | code+inferred-type |
| 39 | TOT_AMT | FLOAT |  | Y |  | code+inferred-type |
| 40 | TAX_PRC | FLOAT |  | Y |  | code+inferred-type |
| 41 | NET_AMT | FLOAT |  | Y |  | code+inferred-type |
| 42 | RATE_TYPE | VARCHAR | 1 | Y |  | code+inferred-type |
| 43 | IT_TYPE | VARCHAR | 1 | Y |  | code+inferred-type |
| 44 | WITH_STOCK | unknown |  | Y |  | code |
| 45 | HD_VCH_NO | VARCHAR | 10 | Y |  | code+inferred-type |
| 46 | OLD_VCH_NO | VARCHAR | 8 | Y |  | code+inferred-type |
| 47 | NEW_VCH_NO | VARCHAR | 8 | Y |  | code+inferred-type |
| 48 | MAIN_USER | VARCHAR | 15 | Y |  | code+inferred-type |
| 49 | ADD_USER | VARCHAR | 15 | Y |  | code+inferred-type |
| 50 | ITM_OTH_RATE | unknown |  | Y |  | code |
| 51 | ITM_OTH_FINE | unknown |  | Y |  | code |
| 52 | SL_BILL_NO | unknown |  | Y |  | code |
| 53 | SL_BILL_LC | unknown |  | Y |  | code |
| 54 | SL_BILL_YRCD | unknown |  | Y |  | code |
| 55 | SL_BILL_DBCD | unknown |  | Y |  | code |
| 56 | CONV_RATE | unknown |  | Y |  | code |
| 57 | CONV_PRC | unknown |  | Y |  | code |
| 58 | ITM_LESS_TCH | unknown |  | Y |  | code |
| 59 | IT_DESC | VARCHAR | 50 | Y |  | code+inferred-type |
| 60 | ITM_LOSS_WT | unknown |  | Y |  | code |
| 61 | FINE_CUT_FINE | unknown |  | Y |  | code |
| 62 | FINE_CUT_NWT | unknown |  | Y |  | code |
| 63 | FINE_CUT_GWT | unknown |  | Y |  | code |
| 64 | FINE_CUT_PCS | unknown |  | Y |  | code |
| 65 | CONSI_SRNO | unknown |  | Y |  | code |
| 66 | SILVER_FINE | unknown |  | Y |  | code |
| 67 | VCH_SRNO | FLOAT |  | Y |  | code+inferred-type |
| 68 | ITM_GHT_PRC | FLOAT |  | Y |  | code+inferred-type |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
