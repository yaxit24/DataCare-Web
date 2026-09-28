# The desktop scheme model, verified against Live24 (real data)

Every statement below was measured, not inferred.

## Tables
- `AD_MAST` (CO_CODE, SCHM_CODE — **no LC_CODE**): SCHM_NAME, SCHM_AMT, SCHM_MONTH, BONUS_PRC, SCHM_TYPE,
  SCHM_AC (liability), GOLD_RATE. Real: 4 schemes, 1500/2000 monthly, 24 months, BONUS_PRC=0, SCHM_TYPE='A',
  accounts 000201/000210/000858.
- `AD_MEMB` (+LC_CODE, MEMB_CODE): member with KYC/address/nominee/bank. 877 rows.
- `AD_DATA` — instalment detail. 8160 rows.
- `AD_OS` — signed movement ledger. 8194 rows. **MEMB_AMT is always 0; the amount lives in `ADJ_AMT`.**
- `AD_ADJ` — adjustment/redemption. 26 rows. Has SBILL_* for bill-linked redemption (unused here).

## Books → write sets
| Book | Name | Writes |
|---|---|---|
| 074 | Member Monthly Entry | `AD_DATA` (ENT_TYPE='E') + `AD_OS` (A+) — 1311 |
| 075 | Member Opening Entry | `AD_DATA` (ENT_TYPE='O') + `AD_OS` (A+) — 6849 |
| 076 | Member Advance Adjust | `AD_ADJ` + `AD_OS` (D-) 26, plus `AD_OS` (B-) 8 when bonus>0 |

`AD_DATA.INOUT_TYPE` is always 'I'. `AD_OS.DATA_TYPE` always 'A'.

## Movement types (decisive evidence)
- `A` `+` 8160 rows, ₹15,072,050 — instalment accrual
- `D` `-` 26 rows, ₹531,500 — principal adjusted (1:1 with AD_ADJ)
- `B` `-` 8 rows, ₹222,000 — **the bonus portion**, written only when MEMB_BONUS>0.
  Confirmed voucher by voucher: 18000/18000, 42000/42000, 44000/44000, 38000/38000, 14000/14000,
  36000/36000, 12000/12000, 18000/18000. Sum matches AD_ADJ bonus sum exactly.

## Arithmetic (verified on real rows)
    AD_ADJ.ADJ_AMT = MEMB_AMT + MEMB_BONUS - MEMB_LESS
    member balance  = SUM(AD_OS A+) - SUM(AD_OS D-) - SUM(AD_OS B-)
    outstanding liability = 15072050 - 531500 - 222000 = 14318550 over 600 member+scheme pairs

## What this company does NOT use (implement the column, don't assume the behaviour)
`ITM_RATE`/`ITM_GWT` on AD_DATA and `GOLD_WT`/`GOLD_RATE` on AD_OS/AD_ADJ are **0 everywhere** —
SCHM_TYPE='A' is an amount scheme. A gold-weight scheme (SCHM_TYPE likely 'G') would populate them.
`MONTH_CODE` is blank throughout. `SBILL_*` is blank — redemption here goes to an account, not a bill.
