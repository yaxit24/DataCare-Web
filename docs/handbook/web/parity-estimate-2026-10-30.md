# Module-wise parity estimate, 30 October 2026

**Status: an estimate, not a measurement.** These percentages are a judgement made from reading the code and the
automated test suite. They are not the result of operating every screen, and the plan does not certify any parity
percentage (the depth baseline says its counts certify no functional parity). Measured browser results are in the
last section; where they disagree with this estimate, the measurement wins.

## How the estimate was made

- Desktop universe: 204 forms in `unified/src/csharp/DataCareNext/` — 61 transaction (TR_), 45 report (RP_),
  33 master (MS_) and 22 utility (UT_) forms, plus framework and zoom forms.
- Web surface: 635 API endpoints (310 that change data), 132 pages (90 transaction screens), 266 API module files,
  196 database-backed test files.
- Behaviour evidence: about 130 database lifecycle tests across 8 transaction families run and passing at the time;
  the unreachable-field triage reported 103 unreachable fields, 0 reachable by an operator.
- Weighting: a feature whose lifecycle is proven by a passing database test scored higher than code that only exists.
  Nothing here was checked against a running Windows desktop.

## The estimate

| Module                                                               | Desktop scope                                   | Estimate | Basis at the time                                                                                                                      |
| -------------------------------------------------------------------- | ----------------------------------------------- | -------- | -------------------------------------------------------------------------------------------------------------------------------------- |
| Sales (invoice, hallmark, labour, old item, fine)                    | TR_SALE, TR_SALE_HM, TR_SALE_LBR, TR_FINE_SL_PR | ~90%     | Lifecycle tests passing; net-weight pricing, CGST/SGST and print checked on the live screen                                            |
| Purchase (incl. hallmark, consignment, returns)                      | TR_PURC, TR_PURC_HM, TR_OTH_PURC                | ~88%     | Purchase lifecycle tests passing; reopen, edit, delete, print                                                                          |
| Receipts, payments, contra, cash                                     | TR_CASH, TR_CONTRA, TR_CARD_REC, TR_UPI_REC     | ~90%     | Single and multi-party receipt lifecycles, the latter atomic after an audit fix                                                        |
| Manufacturing (karigar, MFG order, jobwork, melting)                 | TR_KR_ISU, TR_MFG_*, TR_MLT_PRO                 | ~82%     | Lifecycle tests passing; MFG order issue not clickable on the demo (no book)                                                           |
| Stock and tags (split, cancel, transfer, weight difference, opening) | TR_TAG_*, TR_PHYSTK, TR_INOUT                   | ~80%     | Tag cancel and split lifecycles passing; physical stock partial                                                                        |
| Sales and tour orders, order cancel                                  | TR_SALE_ORD, TR_TOUR_ORD, TR_SL_ORD_ADJ         | ~65%     | Orders and advances work; order cancel is a per-order void, not the desktop's multi-order adjustment voucher (N37)                     |
| Dhiran, loan, scheme, membership                                     | TR_DHRN__, TR_MEMB__                            | ~70%     | Issue, receipt and interest present and tested; continuations in progress                                                              |
| Bullion, wholesale, bill-to-bill                                     | TR_BUL__, TR_WH_SALE_, TR_BILL_TO               | ~72%     | Bullion sale lifecycle; wholesale shared form; bill-to-bill literal-account debt                                                       |
| Reports                                                              | 45 RP_ forms                                    | ~70%     | 96 report endpoints, PDF/CSV/XLSX; document waves and exact totals open (N24, N57)                                                     |
| Masters                                                              | 33 MS_ forms                                    | ~75%     | Main masters present and tested; niche ones thin                                                                                       |
| Utilities                                                            | 22 UT_ forms                                    | ~45%     | Export, repair, renumber, reminders, estimate reset present; hardware (N25), import and several admin utilities missing                |
| Cross-cutting (auth, input schemas, idempotency, dates)              | —                                               | ~55%     | Malformed input answered 400 (N160) and RLS on every tenant table; full schemas (N50), auth hardening (N55) and idempotency (N52) open |

Overall estimate: roughly 78–82%, with the daily transactional core at 85–90%.

## Measured since, in the browser

The feature suites (`docs/handbook/web/testing.md` §4a) and the surface crawl (§4b) measure what the estimate
assumed. Their percentages are scoped to each feature's own case list and are not comparable with the estimate
above.

| Feature                  | Applicable cases | Passed | Failed (known defects) | Blocked | Browser pass |
| ------------------------ | ---------------- | ------ | ---------------------- | ------- | ------------ |
| Sales Invoice            | 23               | 17     | 3                      | 3       | 73.91%       |
| Purchase Invoice         | 21               | 16     | 3                      | 2       | 76.19%       |
| Company Settings effects | 13               | 10     | 1                      | 2       | 76.92%       |

Desktop match is 0% for all three: no case has been run against the original Windows desktop.

The surface crawl visited all 241 operator routes, with real data from the suites, and pressed every distinct button
(848 presses): every route behaves at smoke level, but only 25 routes have tests that prove their full lifecycle.

Defects the browser runs found that the estimate did not account for:

- G169 and G176 (high): a sale or a purchase with items from two groups, such as gold and silver on one bill, cannot
  be saved. The ~90% and ~88% for Sales and Purchase are therefore optimistic until N162 lands.
- G170 (high): a stale second save silently overwrites the first, on sales and purchases (N51).
- G178 (high): the only administrator can remove their own admin role and lock the company out (N169).
- G171 (no Alt+S keyboard save), G172 (raw error code when two sessions open the company at once) and G177
  (amount settings limited to fixed presets).

## Next measurement

Each further feature suite replaces part of this estimate with a measured, scoped result. The estimate should not be
updated by hand; it stays as the 30 October 2026 judgement it was.
