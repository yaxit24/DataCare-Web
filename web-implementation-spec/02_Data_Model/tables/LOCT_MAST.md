# LOCT_MAST

- **Cluster:** masters
- **Source:** code-recovered
- **Columns:** 12
- **Primary key:** (none recovered)
- **Tenant/scope keys present:** CO_CODE, LC_CODE
- **Web mapping:** `tenant_id` + the scope keys above; preserve column names verbatim.

| # | Column | Type | Len | Null | Default | Source |
|---|--------|------|-----|------|---------|--------|
| 1 | ITEM_DISCOUNT | unknown |  | Y |  | code |
| 2 | TRY_DATE | unknown |  | Y |  | code |
| 3 | CO_CODE ⟨scope⟩ | VARCHAR | 2 | Y |  | code+inferred-type |
| 4 | LC_CODE ⟨scope⟩ | VARCHAR | 2 | Y |  | code+inferred-type |
| 5 | LC_NAME | unknown |  | Y |  | code |
| 6 | LC_ADD1 | unknown |  | Y |  | code |
| 7 | LC_ADD2 | unknown |  | Y |  | code |
| 8 | LC_ADD3 | unknown |  | Y |  | code |
| 9 | LC_CITY | unknown |  | Y |  | code |
| 10 | LC_PHONE | unknown |  | Y |  | code |
| 11 | LC_MOBILE | unknown |  | Y |  | code |
| 12 | MAIN_USER | VARCHAR | 15 | Y |  | code+inferred-type |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
