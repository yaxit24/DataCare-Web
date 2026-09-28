# parity/ — Tier-4 parity results

`latest.json` holds the most recent web (Postgres) vs desktop (SQL Server golden master)
diff per module: persisted rows, computed values, report datasets, GST CSVs, and any
differing fields with the inputs that produced them (Req 21). Populated from Phase 1+
(harness scaffold at Task 8, full suite at Task 30).
