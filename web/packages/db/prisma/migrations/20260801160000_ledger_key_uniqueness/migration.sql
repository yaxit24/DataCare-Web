-- LEDR_KEY uniqueness on AC_DATA and BANK_RECONCILE, which the desktop enforces and the web did not.
--
-- The desktop declares PK_AC_DATA on LEDR_KEY ALONE. The web's AC_DATA_pkey is on the surrogate `row_id`, so
-- nothing prevented two ledger legs of the same voucher from sharing a key.
--
-- This is not theoretical. Assigning the desktop's semantic leg type codes (01 party, 03 revenue, 04 tax) left
-- a fourth web-only round-off leg falling back to the positional sequence, which produced a SECOND row keyed
-- ...0104 alongside the tax leg. It inserted silently. On the desktop the same write would have been rejected
-- by the primary key.
--
-- A duplicate LEDR_KEY is not a cosmetic problem: RP_LEDR and the Rojmel report both key on it, so two legs
-- sharing one key means a report either double-counts or drops a leg depending on how it joins.
--
-- ROJ_MEL_DATA already had this - its pkey is (tenant_id, LEDR_KEY) - which is why the same class of collision
-- was caught there by 23505 during the Rojmel work and went unnoticed here.
--
-- Tenant-scoped rather than global, matching ROJ_MEL_DATA: the desktop has one database per company, so its
-- single-column key and a per-tenant key express the same rule.
--
-- Verified before applying: zero duplicate (tenant_id, LEDR_KEY) groups in either table.

CREATE UNIQUE INDEX "AC_DATA_tenant_ledr_key_key" ON "AC_DATA" (tenant_id, "LEDR_KEY");
CREATE UNIQUE INDEX "BANK_RECONCILE_tenant_ledr_key_key" ON "BANK_RECONCILE" (tenant_id, "LEDR_KEY");
