# LBR_ISU_DETL

- **Cluster:** ancillary
- **Source:** code-recovered
- **Columns:** 16
- **Primary key:** (none recovered)
- **Tenant/scope keys present:** (none)
- **Web mapping:** `tenant_id` + the scope keys above; preserve column names verbatim.

| # | Column | Type | Len | Null | Default | Source |
|---|--------|------|-----|------|---------|--------|
| 1 | ITM_REMARK | VARCHAR | 50 | Y |  | code+inferred-type |
| 2 | KR_LBR_RATE | FLOAT |  | Y |  | code+inferred-type |
| 3 | KR_LBR_AMT | FLOAT |  | Y |  | code+inferred-type |
| 4 | KR_COST | unknown |  | Y |  | code |
| 5 | KR_OTH_AMT | unknown |  | Y |  | code |
| 6 | VCH_SRNO | FLOAT |  | Y |  | code+inferred-type |
| 7 | TAG_NO | VARCHAR | 15 | Y |  | code+inferred-type |
| 8 | IT_TAX_AMT | unknown |  | Y |  | code |
| 9 | IT_LBR_TAX | unknown |  | Y |  | code |
| 10 | ORD_TAG_STK_ADD | unknown |  | Y |  | code |
| 11 | EMP_CODE | VARCHAR | 3 | Y |  | code+inferred-type |
| 12 | ITM_RATE | FLOAT |  | Y |  | code+inferred-type |
| 13 | KR_OTH_WT | FLOAT |  | Y |  | code+inferred-type |
| 14 | NEW_VCH_SRNO | unknown |  | Y |  | code |
| 15 | NEW_FINE | unknown |  | Y |  | code |
| 16 | IT_CODE | VARCHAR | 5 | Y |  | code+inferred-type |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
