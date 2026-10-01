-- Desktop Ac_Stock.Dm_PrRtn_Detl/Dm_Purc_Detl persist the originating counter on every DM_DATA row.
-- Nullable because historical imported rows may predate this column.
ALTER TABLE "DM_DATA" ADD COLUMN "TBL_CODE" VARCHAR(3);
