# BAR_DETL

- **Cluster:** inventory
- **Source:** code-recovered
- **Columns:** 108
- **Primary key:** (none recovered)
- **Tenant/scope keys present:** CO_CODE, LC_CODE, CO_YEAR, CO_BOOK  ·  fully tenant-keyed
- **Web mapping:** `tenant_id` + the scope keys above; preserve column names verbatim.

| # | Column | Type | Len | Null | Default | Source |
|---|--------|------|-----|------|---------|--------|
| 1 | ITM_REMARK | VARCHAR | 50 | Y |  | code+inferred-type |
| 2 | KR_LBR_RATE | FLOAT |  | Y |  | code+inferred-type |
| 3 | KR_LBR_AMT | FLOAT |  | Y |  | code+inferred-type |
| 4 | KR_COST | unknown |  | Y |  | code |
| 5 | KR_OTH_AMT | unknown |  | Y |  | code |
| 6 | CO_CODE ⟨scope⟩ | VARCHAR | 2 | Y |  | code+inferred-type |
| 7 | LC_CODE ⟨scope⟩ | VARCHAR | 2 | Y |  | code+inferred-type |
| 8 | CO_YEAR ⟨scope⟩ | VARCHAR | 10 | Y |  | code+inferred-type |
| 9 | CO_BOOK ⟨scope⟩ | VARCHAR | 3 | Y |  | code+inferred-type |
| 10 | VCH_NO | VARCHAR | 8 | Y |  | code+inferred-type |
| 11 | SR_NO | FLOAT |  | Y |  | code+inferred-type |
| 12 | OLD_SRNO | FLOAT |  | Y |  | code+inferred-type |
| 13 | VCH_DATE | DATE |  | Y |  | code+inferred-type |
| 14 | STK_DATE | unknown |  | Y |  | code |
| 15 | VCH_TIME | DATETIME |  | Y |  | code+inferred-type |
| 16 | VCH_TYPE | VARCHAR | 6 | Y |  | code+inferred-type |
| 17 | INOUT_TYPE | VARCHAR | 1 | Y |  | code+inferred-type |
| 18 | ENTRY_TYPE | VARCHAR | 1 | Y |  | code+inferred-type |
| 19 | BOOK_NAME | VARCHAR | 20 | Y |  | code+inferred-type |
| 20 | AC_CODE | VARCHAR | 8 | Y |  | code+inferred-type |
| 21 | IT_CODE | VARCHAR | 5 | Y |  | code+inferred-type |
| 22 | TAG_NO | VARCHAR | 15 | Y |  | code+inferred-type |
| 23 | LOT_NO | VARCHAR | 15 | Y |  | code+inferred-type |
| 24 | DESIGN_NO | VARCHAR | 15 | Y |  | code+inferred-type |
| 25 | TBL_CODE | VARCHAR | 3 | Y |  | code+inferred-type |
| 26 | ITM_SIZE | VARCHAR | 20 | Y |  | code+inferred-type |
| 27 | ITM_PCS | FLOAT |  | Y |  | code+inferred-type |
| 28 | BAG_WT | FLOAT |  | Y |  | code+inferred-type |
| 29 | ITM_GWT | FLOAT |  | Y |  | code+inferred-type |
| 30 | ITM_OTH_WT | FLOAT |  | Y |  | code+inferred-type |
| 31 | ITM_NWT | FLOAT |  | Y |  | code+inferred-type |
| 32 | ITM_GHT_PRC | FLOAT |  | Y |  | code+inferred-type |
| 33 | ITM_GHT_WT | FLOAT |  | Y |  | code+inferred-type |
| 34 | ITM_TOUCH | FLOAT |  | Y |  | code+inferred-type |
| 35 | ITM_WEST_PRC | FLOAT |  | Y |  | code+inferred-type |
| 36 | ITM_FINE | FLOAT |  | Y |  | code+inferred-type |
| 37 | LBR_PRC | FLOAT |  | Y |  | code+inferred-type |
| 38 | LBR_RATE | FLOAT |  | Y |  | code+inferred-type |
| 39 | LBR_TYPE | VARCHAR | 1 | Y |  | code+inferred-type |
| 40 | LBR_AMT | FLOAT |  | Y |  | code+inferred-type |
| 41 | OTH_AMT | FLOAT |  | Y |  | code+inferred-type |
| 42 | ITM_RATE | FLOAT |  | Y |  | code+inferred-type |
| 43 | ITM_AMT | FLOAT |  | Y |  | code+inferred-type |
| 44 | TAG_COST | FLOAT |  | Y |  | code+inferred-type |
| 45 | ITM_MARGIN | FLOAT |  | Y |  | code+inferred-type |
| 46 | ITM_MRP | FLOAT |  | Y |  | code+inferred-type |
| 47 | SF_NO | unknown |  | Y |  | code |
| 48 | KR_NAME | VARCHAR | 5 | Y |  | code+inferred-type |
| 49 | KR_OTH_WT | FLOAT |  | Y |  | code+inferred-type |
| 50 | KR_NET_WT | FLOAT |  | Y |  | code+inferred-type |
| 51 | KR_GHT_PRC | unknown |  | Y |  | code |
| 52 | KR_GHT_WT | unknown |  | Y |  | code |
| 53 | KR_TOUCH | FLOAT |  | Y |  | code+inferred-type |
| 54 | KR_WEST_PRC | FLOAT |  | Y |  | code+inferred-type |
| 55 | KR_FINE | FLOAT |  | Y |  | code+inferred-type |
| 56 | TAG_SRNO | unknown |  | Y |  | code |
| 57 | VCH_SRNO | FLOAT |  | Y |  | code+inferred-type |
| 58 | RATE_TYPE | VARCHAR | 1 | Y |  | code+inferred-type |
| 59 | IT_TYPE | VARCHAR | 1 | Y |  | code+inferred-type |
| 60 | TAG_TYPE | VARCHAR | 1 | Y |  | code+inferred-type |
| 61 | PR_CODE | VARCHAR | 2 | Y |  | code+inferred-type |
| 62 | APR_ISU | unknown |  | Y |  | code |
| 63 | ORD_NO | VARCHAR | 8 | Y |  | code+inferred-type |
| 64 | ORD_SRNO | FLOAT |  | Y |  | code+inferred-type |
| 65 | ORD_YRCD | VARCHAR | 10 | Y |  | code+inferred-type |
| 66 | ORD_DBCD | VARCHAR | 8 | Y |  | code+inferred-type |
| 67 | ORD_AC | unknown |  | Y |  | code |
| 68 | MAIN_USER | VARCHAR | 15 | Y |  | code+inferred-type |
| 69 | ADD_USER | VARCHAR | 15 | Y |  | code+inferred-type |
| 70 | DATA_TRFR | VARCHAR | 1 | Y |  | code+inferred-type |
| 71 | HD_VCH_NO | VARCHAR | 10 | Y |  | code+inferred-type |
| 72 | OLD_VCH_NO | VARCHAR | 8 | Y |  | code+inferred-type |
| 73 | NEW_VCH_NO | VARCHAR | 8 | Y |  | code+inferred-type |
| 74 | HM_ID | VARCHAR | 10 | Y |  | code+inferred-type |
| 75 | HM_ID2 | VARCHAR | 10 | Y |  | code+inferred-type |
| 76 | HM_ID3 | VARCHAR | 10 | Y |  | code+inferred-type |
| 77 | HM_ID4 | VARCHAR | 10 | Y |  | code+inferred-type |
| 78 | HM_ID_WT | FLOAT |  | Y |  | code+inferred-type |
| 79 | HM_ID2_WT | FLOAT |  | Y |  | code+inferred-type |
| 80 | HM_ID3_WT | FLOAT |  | Y |  | code+inferred-type |
| 81 | HM_ID4_WT | FLOAT |  | Y |  | code+inferred-type |
| 82 | DATA_TYPE | VARCHAR | 1 | Y |  | code+inferred-type |
| 83 | APP_TRFR | VARCHAR | 1 | Y |  | code+inferred-type |
| 84 | ITM_COLOR | VARCHAR | 15 | Y |  | code+inferred-type |
| 85 | MAIN_MARGIN_PRC | FLOAT |  | Y |  | code+inferred-type |
| 86 | MAIN_MRP | FLOAT |  | Y |  | code+inferred-type |
| 87 | JDT_JDT_WT | unknown |  | Y |  | code |
| 88 | JDT_GHT_WT | unknown |  | Y |  | code |
| 89 | JDT_KUN_WT | unknown |  | Y |  | code |
| 90 | JDT_WAX_WT | unknown |  | Y |  | code |
| 91 | KR_WAX_WT | FLOAT |  | Y |  | code+inferred-type |
| 92 | JDT_KUN_TOUCH | unknown |  | Y |  | code |
| 93 | JDT_KUN_NET | unknown |  | Y |  | code |
| 94 | EMP_ISU | VARCHAR | 1 | Y |  | code+inferred-type |
| 95 | LBR_CODE | VARCHAR | 2 | Y |  | code+inferred-type |
| 96 | DESIGN_IMG_ID | VARCHAR | 50 | Y |  | code+inferred-type |
| 97 | SL_TYPE | unknown |  | Y |  | code |
| 98 | KR_OTH_RATE | unknown |  | Y |  | code |
| 99 | KR_OTH_FINE | unknown |  | Y |  | code |
| 100 | KR_TOT_FINE | unknown |  | Y |  | code |
| 101 | KR_GWT_TOUCH | unknown |  | Y |  | code |
| 102 | ITM_WEST | FLOAT |  | Y |  | code+inferred-type |
| 103 | ITM_STYLE | unknown |  | Y |  | code |
| 104 | ORD_LC_CODE | unknown |  | Y |  | code |
| 105 | MFG_YRCD | unknown |  | Y |  | code |
| 106 | MFG_DBCD | unknown |  | Y |  | code |
| 107 | MFG_NO | unknown |  | Y |  | code |
| 108 | MFG_SRNO | unknown |  | Y |  | code |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
