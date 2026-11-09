-- WP-06 User Create (MS_USER), decisions D34 and D35 (document 12 §4).
--
-- D35: the desktop Delete removes the LOGIN_MAST and USER_SET rows (MS_USER.cs:2067-2092). The web keeps them, so vouchers
-- and the audit keep their user code, and marks the login inactive instead: an inactive login cannot sign in, its sessions
-- are revoked in the same transaction, and every authenticated request re-reads the flag (rbac/authorization.ts).
-- D34: a per-account login back-off on top of the 10-per-minute IP throttle; the counter and the block end live on the
-- account row of the tenant, so one tenant's failures never touch another tenant's login of the same name.
ALTER TABLE "LOGIN_MAST"
  ADD COLUMN IF NOT EXISTS "LOGIN_ACTIVE" VARCHAR(1) NOT NULL DEFAULT 'Y',
  ADD COLUMN IF NOT EXISTS "DEACTIVATED_AT" TIMESTAMPTZ(6),
  ADD COLUMN IF NOT EXISTS "DEACTIVATED_BY" VARCHAR(15),
  ADD COLUMN IF NOT EXISTS "FAILED_LOGIN_COUNT" INTEGER NOT NULL DEFAULT 0,
  ADD COLUMN IF NOT EXISTS "LOGIN_BLOCKED_UNTIL" TIMESTAMPTZ(6);

DO $$
BEGIN
  IF NOT EXISTS (SELECT 1 FROM pg_constraint WHERE conname = 'LOGIN_MAST_login_active_flag') THEN
    ALTER TABLE "LOGIN_MAST"
      ADD CONSTRAINT "LOGIN_MAST_login_active_flag" CHECK ("LOGIN_ACTIVE" IN ('Y', 'N'));
  END IF;
END $$;
