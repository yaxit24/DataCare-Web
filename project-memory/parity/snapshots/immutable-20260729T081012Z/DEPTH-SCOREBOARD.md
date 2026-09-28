# Depth scoreboard (generated)

Generated 2026-07-29T08:12:14+00:00 by `project-memory/parity/build_parity_matrix.py`.
Regenerate with that script; it fails if the write-set parser self-test fails or if any
form's column coverage decreases (`depth-baseline.json` ratchet).

## Headline

| Metric | Value |
| --- | --- |
| Desktop written columns | 3669 |
| Web written columns | 3280 |
| **Column coverage** | **89.4%** |
| Desktop tables written | 122 |
| Tables the web never writes | 11 |
| Parser self-test fixtures | 13 |

Grid caveat: Desktop gridColumns includes hidden state columns; treat grid coverage as a lower bound and columnCoveragePct as authoritative.

## Gate distribution

| Unit | evidence_gap | in_progress | not_started | passed | waived |
| --- | ---: | ---: | ---: | ---: | ---: |
| Forms (204) | 25 | 104 | 1 | 1 | 73 |
| Tables (146) | 0 | 56 | 43 | 47 | 0 |

## Family gaps (remediation batches, largest first)

| Family | Tables | Desktop cols | Web cols | Gap | Coverage | Never written |
| --- | ---: | ---: | ---: | ---: | ---: | --- |
| purchase | 6 | 300 | 250 | 50 | 83.3% | - |
| tagStock | 11 | 473 | 432 | 41 | 91.3% | TAG_DATA |
| finance | 8 | 341 | 301 | 40 | 88.3% | - |
| membership | 6 | 160 | 133 | 27 | 83.1% | - |
| manufacturing | 7 | 371 | 346 | 25 | 93.3% | - |
| sales | 9 | 535 | 514 | 21 | 96.1% | - |
| dhiran | 4 | 177 | 156 | 21 | 88.1% | - |
| shared | 9 | 232 | 223 | 9 | 96.1% | MENU_DATA |

## Worst transaction forms by persisted-column depth

| Form | Severity | Column coverage | Missing columns | Grid coverage |
| --- | --- | ---: | ---: | ---: |
| TR_PURC | critical | 83.3% | 10 | 14.5% |
| TR_SALE_RTN | critical | 89.9% | 8 | 9.1% |
| TR_SL_ORD_ADJ | high | 91.1% | 13 | 87.9% |
| TR_TAG_OPBL | critical | 91.5% | 21 | 11.1% |
| TR_PURC_HM | high | 93.1% | 2 | 8.3% |
| TR_TAG_SPLIT | critical | 93.2% | 8 | 5.1% |
| TR_PHYSTK | high | 93.7% | 13 | 56.2% |
| TR_SALE_RTN_UAE | high | 94.1% | 2 | 0.0% |
| TR_WH_SALE | high | 99.0% | 1 | 6.0% |
| TR_AC_OPBL | critical | 100.0% | 0 | 31.6% |
| TR_APR_ISU | high | 100.0% | 0 | 39.4% |
| TR_BILL_TO | critical | 100.0% | 0 | 33.3% |
| TR_BUL_BOOKING | high | 100.0% | 0 | 0.0% |
| TR_BUL_SALE | high | 100.0% | 0 | 7.8% |
| TR_CARD_REC | high | 100.0% | 0 | None% |
| TR_CASH | critical | 100.0% | 0 | 100.0% |
| TR_CONTRA | critical | 100.0% | 0 | 100.0% |
| TR_DHRN_INTREC | high | 100.0% | 0 | None% |
| TR_DHRN_ISU | high | 100.0% | 0 | 37.0% |
| TR_DHRN_REC | high | 100.0% | 0 | 0.0% |
| TR_FN_INOUT | high | 100.0% | 0 | 5.8% |
| TR_GOLD_BOOK | high | 100.0% | 0 | 42.1% |
| TR_INOUT | high | 100.0% | 0 | 5.5% |
| TR_ITM_LOT | high | 100.0% | 0 | 36.1% |
| TR_JDT_REC | high | 100.0% | 0 | 35.6% |

## What `depth: passed` requires

- >=99% of the desktop write set persisted for every table the form writes
- zero desktop tables left unwritten
- >=95% grid-column coverage where the form has a grid
- an approved per-form contract in `project-memory/contracts/`

