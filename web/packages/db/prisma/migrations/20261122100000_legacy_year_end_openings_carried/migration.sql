-- WP-23 (architect, 2026-11-22, owner may override): Year-End Close used to write each account's next-year opening as
-- AC_DATA book '000', VCH_TYPE 'ACOP', BOOK_NAME 'OPENING', VCH_NO '1' (ops/yearEnd.ts before N236). Those legs are
-- carried openings: the cross-year readers (Account Ledger and the others in shared/carriedOpening.ts) must not add
-- them to the closed year's history. Relabel exactly those legs to the carried-opening marker 'BAL TRFR'. Account
-- Opening and Party Opening never write VCH_NO '1' with BOOK_NAME 'OPENING'. Idempotent; every tenant's rows alike, as
-- the row identity is the same in each.
UPDATE "AC_DATA"
   SET "BOOK_NAME" = 'BAL TRFR'
 WHERE "CO_BOOK" = '000'
   AND "VCH_TYPE" = 'ACOP'
   AND "BOOK_NAME" = 'OPENING'
   AND "VCH_NO" = '1';
