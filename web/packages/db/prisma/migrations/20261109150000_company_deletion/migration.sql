-- WP-07 / G38 / N58 (decision D38, owner decision OD-5): Company delete. The desktop's Delete erases a company's rows
-- from about 130 tables at once with unscoped string-built statements (MS_COMPANY.cs:6254-6418). The web keeps the
-- desktop's action, rights and texts but deletes softly: one row here hides the company from every list, login and
-- context selection at once; a background job (apps/api/src/modules/ops/companyPurge.ts) erases the company's rows
-- after `purge_after` (30 days) and records `purged_at`. Until then only the platform operator can recover it, by
-- removing this row. Web-only table: the desktop has no equivalent.
CREATE TABLE "company_deletion" (
  "tenant_id"   varchar(24)    NOT NULL,
  "co_code"     varchar(2)     NOT NULL,
  -- The name the company had when it was deleted, for the operator who may recover it.
  "co_name"     varchar(50),
  "deleted_by"  varchar(255)   NOT NULL,
  "deleted_at"  timestamptz(6) NOT NULL DEFAULT now(),
  "purge_after" timestamptz(6) NOT NULL,
  "purged_at"   timestamptz(6),
  -- Rows the purge erased, summed over every company table.
  "purged_rows" integer,
  CONSTRAINT "company_deletion_pkey" PRIMARY KEY ("tenant_id", "co_code", "deleted_at")
);

-- At most one pending (not yet purged) deletion per company. Migration-owned (Prisma cannot declare a partial index).
CREATE UNIQUE INDEX "company_deletion_pending_key" ON "company_deletion" ("tenant_id", "co_code")
  WHERE "purged_at" IS NULL;
-- The purge job reads a tenant's due deletions.
CREATE INDEX "company_deletion_due_idx" ON "company_deletion" ("tenant_id", "purge_after");

ALTER TABLE "company_deletion" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "company_deletion" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "company_deletion"
  USING (tenant_id = current_setting('app.tenant_id', true))
  WITH CHECK (tenant_id = current_setting('app.tenant_id', true));
