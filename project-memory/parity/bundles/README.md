# Parity bundles

Captures produced by `parity-extract-mssql.mjs` (Windows, desktop side) and `parity-extract-pg.mjs` (web side).

**Nothing synthetic belongs here.** The differ's own correctness was established by round-tripping a real web
capture through a synthesised desktop bundle and perturbing it — a shifted date, one rupee, a fourth decimal,
a dropped table, a dropped row. Those probe artifacts were deleted immediately afterwards, because an artifact
in this directory is treated as evidence and a proof of the instrument is not evidence about the applications.

The `g5:parity` gate additionally requires the desktop bundle to carry a real `Microsoft SQL Server @@VERSION`
banner, so a hand-made file cannot be promoted by renaming it.
