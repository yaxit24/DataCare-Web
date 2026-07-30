# APR_DATA

- **Cluster:** inventory
- **Source:** code-recovered
- **Columns:** 16
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
| 6 | VCH_DATE | DATE |  | Y |  | code+inferred-type |
| 7 | VCH_TIME | DATETIME |  | Y |  | code+inferred-type |
| 8 | HD_VCH_NO | VARCHAR | 10 | Y |  | code+inferred-type |
| 9 | AC_CODE | VARCHAR | 8 | Y |  | code+inferred-type |
| 10 | VCH_DESC | VARCHAR | 50 | Y |  | code+inferred-type |
| 11 | EMP_CODE | VARCHAR | 3 | Y |  | code+inferred-type |
| 12 | MAIN_USER | VARCHAR | 15 | Y |  | code+inferred-type |
| 13 | ISU_NO | VARCHAR | 10 | Y |  | code+inferred-type |
| 14 | ISU_LC_CODE | unknown |  | Y |  | code |
| 15 | ISU_YRCD | VARCHAR | 9 | Y |  | code+inferred-type |
| 16 | ISU_DBCD | VARCHAR | 3 | Y |  | code+inferred-type |

> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.
