# Data Model — Overview

The complete relational model behind DataCareNext: **162 tables / 4,666 columns** (100 from DDL,
62 recovered from code, 7 unresolved). This page gives the naming patterns, the overall ERD, and
per-cluster ER diagrams. The exhaustive per-table column reference is generated under
[`tables/`](tables/INDEX.md) (one file per table, regenerate via `_generators/gen_table_reference.py`).

## 1. How to read the schema

### Scoping key on (almost) every row
Transactional tables are partitioned by **(CO_CODE, LC_CODE, CO_YEAR, CO_BOOK, VCH_NO, SR_NO)**;
masters by **(CO_CODE, …)**. In the web DB an outer `tenant_id` wraps these (RLS). See
`01_Architecture/multitenancy-scoping.md`.

### Header / detail / sub-detail naming pattern
The schema is highly regular. Learn these suffixes and most tables explain themselves:

| Suffix | Role | Example |
|---|---|---|
| `*_DATA` | Voucher **header** (one row per document) | `SL_DATA`, `PR_DATA`, `DHRN_ISU_DATA` |
| `*_DETL` | Voucher **detail / line items** | `SL_DETL`, `PR_DETL`, `MFG_DETL` |
| `*_IDTL` | **Sub-detail** of a line (stones, sub-items, breakdown) | `SL_IDTL`, `PR_IDTL` |
| `*_MAST` | **Master / reference** data | `AC_MAST`, `ITEM_MAST`, `RATE_MAST` |
| `*_OPBL` | **Opening balance** entries (year start) | `TR_AC_OPBL`, `TR_TAG_OPBL` |
| `AC_DATA` | The **double-entry ledger** (all postings land here) | — |
| `TAX_DATA` | **Tax** postings (CGST/SGST/IGST) | — |
| `*_OS*` | **Outstanding** (unpaid balances) | `BILL_OS_DATA` |
| `DELETE_DATA` | **Audit log** of deleted vouchers | — |

So `SL_DATA → SL_DETL → SL_IDTL` is "sale header → its lines → each line's stone/sub breakdown",
and every save also writes `AC_DATA` (ledger), `TAX_DATA` (tax), and stock tables.

## 2. Overall ERD (cluster level)

```mermaid
erDiagram
  CO_MAST       ||--o{ LOGIN_MAST : "users"
  CO_MAST       ||--o{ YEAR_MAST  : "years"
  CO_MAST       ||--o{ AC_MAST    : "accounts"
  AC_GROUP      ||--o{ AC_MAST    : "groups"
  AC_MAST       ||--o{ AC_DATA    : "ledger postings"
  SRNO_MAST     ||--o{ AC_DATA    : "voucher numbering"

  AC_DATA       }o--|| TAX_DATA   : "tax legs"
  SL_DATA       ||--o{ AC_DATA    : "posts"
  PR_DATA       ||--o{ AC_DATA    : "posts"
  DHRN_ISU_DATA ||--o{ AC_DATA    : "posts"
  MFG_DATA      ||--o{ AC_DATA    : "posts"
  CASH_DATA     ||--o{ AC_DATA    : "posts"

  ITEM_MAST     ||--o{ TAG_STOCK  : "tagged items"
  TAG_STOCK     ||--o{ MAIN_STOCK : "aggregates to"
  SL_DETL       }o--o{ TAG_STOCK  : "issues"
  PR_DETL       }o--o{ TAG_STOCK  : "creates"
```

Every transaction cluster (sales, purchase, dhrn, manufacturing, finance) ultimately **posts into
`AC_DATA`** (money + metal) and most touch **stock** (`TAG_STOCK`/`MAIN_STOCK`). `AC_DATA` is the hub.

## 3. Per-cluster ER diagrams

### 3.1 Sales (`sales` cluster — 9 tables)
```mermaid
erDiagram
  SL_DATA ||--o{ SL_DETL : "lines"
  SL_DETL ||--o{ SL_IDTL : "sub-detail (stones)"
  SL_DATA }o--|| AC_MAST : "customer (AC_CODE)"
  SL_DATA ||--o{ AC_DATA : "ledger: Dr customer / Cr sales+tax"
  SL_DATA ||--o{ TAX_DATA : "CGST/SGST or IGST"
  SL_DATA ||--o{ SL_ORD_ADJ : "order-advance adjust"
  SL_DATA ||--o{ SL_PR_DETL : "purchase-fixing link"
  SL_DETL }o--o{ TAG_STOCK : "issues tags (stock-out)"
  SL_DATA ||--o{ BILL_OS_DATA : "outstanding"
```
Header `SL_DATA` (totals, customer, payment split) → `SL_DETL` (per item weights/labour/tax) →
`SL_IDTL`. Ancillary: `BILL_OS_DATA`, `POINT_DATA` (loyalty), `UPI_DATA`/`CARD_DATA` (split tender),
`ROJ_MEL_DATA` (day-book), `SL_ORD_ADJ`, `SL_PR_DETL`.

### 3.2 Purchase (`purchase` cluster)
```mermaid
erDiagram
  PR_DATA ||--o{ PR_DETL : "lines"
  PR_DETL ||--o{ PR_IDTL : "sub-detail"
  PR_DATA }o--|| AC_MAST : "supplier"
  PR_DATA ||--o{ AC_DATA : "ledger: Cr supplier / Dr purchase+input-tax"
  PR_DATA ||--o{ TAX_DATA : "input tax"
  PR_DETL }o--o{ TAG_STOCK : "creates tags (stock-in)"
  PR_DETL ||--o{ ITM_LOT_DETL : "lots"
```
`ITM_FINE = ITM_NWT × ITM_TOUCH / 100`. Stock-in creates tags/lots (`TAG_SET`, `BAR_*`, `ITM_LOT_DETL`)
and may add `TOUCH_MAST` rows.

### 3.3 Inventory / Tags (`inventory` cluster — 23 tables)
```mermaid
erDiagram
  ITEM_MAST  ||--o{ TAG_STOCK : "item"
  TAG_STOCK  ||--o{ MAIN_STOCK : "rolls up to item balances"
  ITM_LOT    ||--o{ ITM_LOT_DETL : "lot lines"
  TAG_STOCK  ||--o{ BAR_DATA : "barcode/print"
  BAR_DATA   ||--o{ BAR_DETL : "lines"
  BAR_DETL   ||--o{ BAR_IDTL : "sub"
  APR_DATA   ||--o{ APR_DETL : "approval/consignment items"
```
`TAG_STOCK` = the per-physical-item ledger (presence = available). `MAIN_STOCK` = aggregate item
balances (qty/gwt/nwt/fine) updated on every stock-in/out.

### 3.4 Accounting / Ledger (`accounting` cluster — 7 tables)
```mermaid
erDiagram
  AC_GROUP ||--o{ AC_MAST : "group"
  AC_MAST  ||--o{ AC_DATA : "postings (money + metal)"
  AC_MAST  ||--o{ ROJ_MEL_DATA : "day-book"
  AC_DATA  ||--o{ LEDR_AC_DATA : "final-accounts rollup"
```
`AC_DATA` carries both **money** (`CR_AMT`/`DR_AMT`) and **metal** (`FINE_WT`/`FINE_RATE`) on each
line; `IT_TYPE` distinguishes money (`A`) from gold/silver legs. Trial balance = Σ per account.

### 3.5 Manufacturing / Karigar (`manufacturing` cluster — 13 tables)
```mermaid
erDiagram
  MFG_DATA ||--o{ MFG_DETL : "job-work lines"
  KR_DATA  ||--o{ KR_DETL : "karigar issue/receive lines"
  KR_DATA  }o--|| AC_MAST : "karigar account"
  MFG_DATA ||--o{ AC_DATA : "metal/labour postings"
  MFG_DETL }o--o{ TAG_STOCK : "issue raw / receive finished"
```
Karigar metal balance = Σ issued fine − Σ received fine; wastage folded into received fine
(`NWT × (TOUCH+WEST)/100`).

### 3.6 Loans / Dhrn (`dhrn` cluster — 5 tables)
```mermaid
erDiagram
  DHRN_ISU_DATA ||--o{ DHRN_ISU_DETL : "pledged items"
  DHRN_ISU_DATA }o--|| AC_MAST : "borrower"
  DHRN_ISU_DATA ||--o{ AC_DATA : "loan principal posting"
  DHRN_REC_DATA }o--|| DHRN_ISU_DATA : "repayments"
```
Outstanding = issue − Σ receipts; interest accrues by **day-count** from issue date.

### 3.7 Finance / Cash-Bank (`finance` cluster — 10 tables)
```mermaid
erDiagram
  CASH_DATA   ||--o{ AC_DATA : "receipt/payment postings"
  CONTRA_DATA ||--o{ AC_DATA : "account-to-account transfer"
  CARD_DATA   }o--|| AC_DATA : "card settlement"
  UPI_DATA    }o--|| AC_DATA : "UPI settlement"
```
Every voucher posts a balanced 2-leg (or n-leg) entry. Cash over the configured limit requires PAN.

## 4. Cross-cutting tables (touched by many clusters)

| Table | Role |
|---|---|
| `AC_DATA` | The ledger hub — every posting voucher writes here (money + metal). |
| `TAX_DATA` | Tax legs (CGST/SGST/IGST) for sales/purchase. |
| `SRNO_MAST` | Voucher-number counters per scope. |
| `ROJ_MEL_DATA` | Day-book / cash register entries. |
| `BILL_OS_DATA` | Outstanding balances per bill. |
| `DELETE_DATA` | Audit log of every deleted voucher. |
| `TAG_STOCK` / `MAIN_STOCK` | Physical-item + aggregate stock. |
| `PRINT_MAST`, `USER_DATA`, `TEMP_BOOK_DATA`, `CRNT_DATA` | Print counts, user activity, scratch/temp. |

## 5. Type-confidence & unresolved tables

- Columns from DDL have authoritative types; **code-recovered** columns get types via a learned
  column→type map (`source: "code+inferred-type"`), and a few are `unknown`.
- **7 unresolved tables** (no column-list `INSERT` in code, populated via `INSERT…SELECT`):
  `AREA_MAST, IMAGE_DATA, LBR_ISU_IDTL, LOAN_ISU_DATA, LOAN_REC_DATA, OP_DETL, TAG_MAST`.
  Recover authoritative columns via the optional Docker SQL-Server golden-master pass before
  finalizing Prisma `NUMERIC` precision (tracked in `06_Parity/` open items).
- **Float vs Numeric:** the desktop stored money/weight as `FLOAT`. The web uses `NUMERIC` with the
  precision policy in `conventions.md` — this is an intentional, parity-safe upgrade (rounding is
  pinned to match desktop output).

## 6. Regenerating the table reference

```bash
cd web-implementation-spec/_generators && python3 gen_table_reference.py
```
Writes `02_Data_Model/tables/<TABLE>.md` for all 162 tables + `INDEX.md` (by-cluster + alphabetical).
