# Report comparison artifacts

Written by `apps/api/integration/report-compare.mjs`. Each file records one Crystal-vs-web comparison of a
report's DATA — rows and control totals. Layout is not compared and Crystal pixel parity is not claimed.

**Nothing synthetic belongs here.** The differ's own correctness was established with 19 unit tests plus an
end-to-end run in which a Crystal-shaped export was synthesised from a real web export — complete with a BOM,
a title block, repeated page headers, thousands separators and a grand total — and then perturbed. Those probe
artifacts were deleted immediately, because a file in this directory is treated as evidence and a proof of the
instrument is not evidence about the two applications.

To produce a real one: export the report to CSV from DataCareNext, fetch `GET /reports/<slug>/export.csv` with
the SAME date range and filters, write a column map, and run the CLI.
