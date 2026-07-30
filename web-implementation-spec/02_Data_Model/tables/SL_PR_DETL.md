# SL_PR_DETL

- **Cluster:** sales
- **Source:** code-recovered
- **Columns:** 38
- **Primary key:** (none recovered)
- **Tenant/scope keys present:** CO_CODE, LC_CODE, CO_YEAR, CO_BOOK  ·  fully tenant-keyed
- **Web mapping:** `tenant_id` + the scope keys above; preserve column names verbatim.

| # | Column | Type | Len | Null | Default | Source |
|---|--------|------|-----|------|---------|--------|
| 1 | VCH_NO | VARCHAR | 8 | Y |  | code+inferred-type |
| 2 | CO_CODE ⟨scope⟩ | VARCHAR | 2 | Y |  | code+inferred-type |
| 3 | LC_CODE ⟨scope⟩ | VARCHAR | 2 | Y |  | code+inferred-type |
| 4 | CO_YEAR ⟨scope⟩ | VARCHAR | 10 | Y |  | code+inferred-type |
| 5 | CO_BOOK ⟨scope⟩ | VARCHAR | 3 | Y |  | code+inferred-type |
| 6 | SR_NO | FLOAT |  | Y |  | code+inferred-type |
| 7 | VCH_DATE | DATE |  | Y |  | code+inferred-type |
| 8 | VCH_TIME | DATETIME |  | Y |  | code+inferred-type |
| 9 | VCH_TYPE | VARCHAR | 6 | Y |  | code+inferred-type |
| 10 | INOUT_TYPE | VARCHAR | 1 | Y |  | code+inferred-type |
| 11 | ENTRY_TYPE | VARCHAR | 1 | Y |  | code+inferred-type |
| 12 | BOOK_NAME | VARCHAR | 20 | Y |  | code+inferred-type |
| 13 | AC_CODE | VARCHAR | 8 | Y |  | code+inferred-type |
| 14 | IT_CODE | VARCHAR | 5 | Y |  | code+inferred-type |
| 15 | IT_DESC | VARCHAR | 50 | Y |  | code+inferred-type |
| 16 | ITM_PCS | FLOAT |  | Y |  | code+inferred-type |
| 17 | ITM_GWT | FLOAT |  | Y |  | code+inferred-type |
| 18 | ITM_NWT | FLOAT |  | Y |  | code+inferred-type |
| 19 | ITM_TOUCH | FLOAT |  | Y |  | code+inferred-type |
| 20 | ITM_FINE | FLOAT |  | Y |  | code+inferred-type |
| 21 | ITM_RATE | FLOAT |  | Y |  | code+inferred-type |
| 22 | NET_AMT | FLOAT |  | Y |  | code+inferred-type |
| 23 | IT_TYPE | VARCHAR | 1 | Y |  | code+inferred-type |
| 24 | HD_VCH_NO | VARCHAR | 10 | Y |  | code+inferred-type |
| 25 | DATA_TRFR | VARCHAR | 1 | Y |  | code+inferred-type |
| 26 | OLD_VCH_NO | VARCHAR | 8 | Y |  | code+inferred-type |
| 27 | NEW_VCH_NO | VARCHAR | 8 | Y |  | code+inferred-type |
| 28 | MAIN_USER | VARCHAR | 15 | Y |  | code+inferred-type |
| 29 | ITM_OTH_WT | FLOAT |  | Y |  | code+inferred-type |
| 30 | HM_ID2 | VARCHAR | 10 | Y |  | code+inferred-type |
| 31 | HM_ID3 | VARCHAR | 10 | Y |  | code+inferred-type |
| 32 | HM_ID4 | VARCHAR | 10 | Y |  | code+inferred-type |
| 33 | HM_ID_WT | FLOAT |  | Y |  | code+inferred-type |
| 34 | HM_ID2_WT | FLOAT |  | Y |  | code+inferred-type |
| 35 | HM_ID3_WT | FLOAT |  | Y |  | code+inferred-type |
| 36 | HM_ID4_WT | FLOAT |  | Y |  | code+inferred-type |
| 37 | HM_ID | VARCHAR | 10 | Y |  | code+inferred-type |
| 38 | ITM_OTH | unknown |  | Y |  | code |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
