-- Desktop Ac_Ledr copies the voucher VCH_TIME into AC_DATA.ENTRY_TIME.
-- DATE discarded intraday ordering required by DC_Main.MsAcBal. Existing values
-- remain midnight: an original time cannot be reconstructed from a date alone.
-- Historical imports must be replayed from their timestamp-bearing source.
ALTER TABLE "AC_DATA"
  ALTER COLUMN "ENTRY_TIME" TYPE timestamp(6) without time zone
  USING "ENTRY_TIME"::timestamp(6) without time zone;
