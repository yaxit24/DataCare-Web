# LBR_REC_DETL

- **Cluster:** ancillary
- **Source:** code-recovered
- **Columns:** 2
- **Primary key:** (none recovered)
- **Tenant/scope keys present:** (none)
- **Web mapping:** `tenant_id` + the scope keys above; preserve column names verbatim.

| # | Column | Type | Len | Null | Default | Source |
|---|--------|------|-----|------|---------|--------|
| 1 | TAG_NO | VARCHAR | 15 | Y |  | code+inferred-type |
| 2 | ITM_SIGN | VARCHAR | 1 | Y |  | code+inferred-type |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
