# TAX_MAST

- **Cluster:** gst_tax
- **Source:** code-recovered
- **Columns:** 9
- **Primary key:** (none recovered)
- **Tenant/scope keys present:** CO_CODE
- **Web mapping:** `tenant_id` + the scope keys above; preserve column names verbatim.

| # | Column | Type | Len | Null | Default | Source |
|---|--------|------|-----|------|---------|--------|
| 1 | CO_CODE ⟨scope⟩ | VARCHAR | 2 | Y |  | code+inferred-type |
| 2 | TAX_CODE | VARCHAR | 2 | Y |  | code+inferred-type |
| 3 | SR_NO | FLOAT |  | Y |  | code+inferred-type |
| 4 | TAX_GROUP | unknown |  | Y |  | code |
| 5 | TAX_NAME | unknown |  | Y |  | code |
| 6 | TAX_PRC | FLOAT |  | Y |  | code+inferred-type |
| 7 | ADD_TAX_PRC | unknown |  | Y |  | code |
| 8 | TAX_AC | unknown |  | Y |  | code |
| 9 | MAIN_USER | VARCHAR | 15 | Y |  | code+inferred-type |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
