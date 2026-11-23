-- WP-23 Balance TrFr (decided 2026-11-22 by the architect, owner may override).
-- An Item Stock carry writes ITM_OPBL rows of the next year that the web's stock readers must not add a second time:
-- stock is MAIN_STOCK of every year (stock.ts onHandNet), which already holds the closing year's history. The column
-- names the year a row was carried from; NULL is a hand-keyed opening. Item Opening Save keeps the marker on a carried
-- item and posts no MAIN_STOCK leg for it.
ALTER TABLE "ITM_OPBL" ADD COLUMN IF NOT EXISTS "CARRIED_FROM" VARCHAR(10);
