-- WP-36: the ITEM_MAST columns the desktop writes on every item save and AutoItem insert (MS_ITEM.cs:3261-3263,
-- MS_AUTO_ITEM.cs:2904, :2912) with the desktop types and defaults: TAX_FREE_ITEM VARCHAR(1) NOT NULL DEFAULT 'N'
-- (Ac_Image.cs:8044), APP_ITEM VARCHAR(1) NOT NULL DEFAULT 'N' (MS_UPDATE.cs:6420), EMP_COM_PRC FLOAT NOT NULL DEFAULT 0
-- (MS_UPDATE.cs:6679), AC_MEMB_COM_PRC FLOAT NOT NULL DEFAULT 0 (Ac_Image.cs:8258). No Lite box shows them; a migrated
-- desktop company keeps its values instead of losing them. Existing rows take the defaults, as on the desktop ALTER.
ALTER TABLE "ITEM_MAST"
  ADD COLUMN IF NOT EXISTS "TAX_FREE_ITEM" VARCHAR(1) NOT NULL DEFAULT 'N',
  ADD COLUMN IF NOT EXISTS "APP_ITEM" VARCHAR(1) NOT NULL DEFAULT 'N',
  ADD COLUMN IF NOT EXISTS "EMP_COM_PRC" DOUBLE PRECISION NOT NULL DEFAULT 0,
  ADD COLUMN IF NOT EXISTS "AC_MEMB_COM_PRC" DOUBLE PRECISION NOT NULL DEFAULT 0;
