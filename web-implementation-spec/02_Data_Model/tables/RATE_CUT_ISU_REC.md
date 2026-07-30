# RATE_CUT_ISU_REC

- **Cluster:** ancillary
- **Source:** code-recovered
- **Columns:** 58
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
| 7 | ENTRY_TYPE | VARCHAR | 1 | Y |  | code+inferred-type |
| 8 | AC_CODE | VARCHAR | 8 | Y |  | code+inferred-type |
| 9 | IT_CODE | VARCHAR | 5 | Y |  | code+inferred-type |
| 10 | IT_DESC | VARCHAR | 50 | Y |  | code+inferred-type |
| 11 | TAG_NO | VARCHAR | 15 | Y |  | code+inferred-type |
| 12 | DESIGN_NO | VARCHAR | 15 | Y |  | code+inferred-type |
| 13 | ITM_PCS | FLOAT |  | Y |  | code+inferred-type |
| 14 | BAG_WT | FLOAT |  | Y |  | code+inferred-type |
| 15 | ITM_GWT | FLOAT |  | Y |  | code+inferred-type |
| 16 | ITM_OTH_WT | FLOAT |  | Y |  | code+inferred-type |
| 17 | ITM_NWT | FLOAT |  | Y |  | code+inferred-type |
| 18 | ITM_GHT_WT | FLOAT |  | Y |  | code+inferred-type |
| 19 | ITM_TOUCH | FLOAT |  | Y |  | code+inferred-type |
| 20 | ITM_WEST_PRC | FLOAT |  | Y |  | code+inferred-type |
| 21 | ITM_FINE | FLOAT |  | Y |  | code+inferred-type |
| 22 | LBR_PRC | FLOAT |  | Y |  | code+inferred-type |
| 23 | LBR_RATE | FLOAT |  | Y |  | code+inferred-type |
| 24 | LBR_TYPE | VARCHAR | 1 | Y |  | code+inferred-type |
| 25 | LBR_AMT | FLOAT |  | Y |  | code+inferred-type |
| 26 | OTH_AMT | FLOAT |  | Y |  | code+inferred-type |
| 27 | ITM_RATE | FLOAT |  | Y |  | code+inferred-type |
| 28 | ITM_AMT | FLOAT |  | Y |  | code+inferred-type |
| 29 | ITM_MRP | FLOAT |  | Y |  | code+inferred-type |
| 30 | NET_AMT | FLOAT |  | Y |  | code+inferred-type |
| 31 | RATE_TYPE | VARCHAR | 1 | Y |  | code+inferred-type |
| 32 | IT_TYPE | VARCHAR | 1 | Y |  | code+inferred-type |
| 33 | LESS_TOUCH | unknown |  | Y |  | code |
| 34 | ITM_OTH_FINE | unknown |  | Y |  | code |
| 35 | CONV_RATE | unknown |  | Y |  | code |
| 36 | CONV_PRC | unknown |  | Y |  | code |
| 37 | LESS_WT | FLOAT |  | Y |  | code+inferred-type |
| 38 | VCH_DATE | DATE |  | Y |  | code+inferred-type |
| 39 | EMP_CODE | VARCHAR | 3 | Y |  | code+inferred-type |
| 40 | ITM_COLOR | VARCHAR | 15 | Y |  | code+inferred-type |
| 41 | HM_ID | VARCHAR | 10 | Y |  | code+inferred-type |
| 42 | HM_ID2 | VARCHAR | 10 | Y |  | code+inferred-type |
| 43 | HM_ID3 | VARCHAR | 10 | Y |  | code+inferred-type |
| 44 | HM_ID4 | VARCHAR | 10 | Y |  | code+inferred-type |
| 45 | HM_ID_WT | FLOAT |  | Y |  | code+inferred-type |
| 46 | HM_ID2_WT | FLOAT |  | Y |  | code+inferred-type |
| 47 | HM_ID3_WT | FLOAT |  | Y |  | code+inferred-type |
| 48 | HM_ID4_WT | FLOAT |  | Y |  | code+inferred-type |
| 49 | IMAGE_ID | unknown |  | Y |  | code |
| 50 | ITM_LOT | unknown |  | Y |  | code |
| 51 | DESIGN_IMG_ID | VARCHAR | 50 | Y |  | code+inferred-type |
| 52 | ITM_STYLE | unknown |  | Y |  | code |
| 53 | FIX_WEST_PRC | unknown |  | Y |  | code |
| 54 | OTH_IT_1 | unknown |  | Y |  | code |
| 55 | OTH_IT_2 | unknown |  | Y |  | code |
| 56 | OTH_IT_3 | unknown |  | Y |  | code |
| 57 | OTH_IT_4 | unknown |  | Y |  | code |
| 58 | SILVER_FINE | unknown |  | Y |  | code |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
