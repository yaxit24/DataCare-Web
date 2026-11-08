-- N52 / G29 (decision D18): idempotent voucher creates. A page sends an Idempotency-Key header with a create; the
-- API writes one receipt row per (tenant, key) inside the SAME transaction as the voucher, so the receipt exists
-- exactly when the voucher does. A replay of the same request returns the stored response instead of posting a
-- second voucher; the same key with a different request is refused. Web-only table: the desktop has no
-- equivalent (a desktop save is a local button press, not a retried HTTP request).
CREATE TABLE "api_command_receipt" (
  "tenant_id"       varchar(24)    NOT NULL,
  "idempotency_key" varchar(128)   NOT NULL,
  -- The literal route template (for example /stock/stock-adjust), not the requested URL.
  "route"           varchar(160)   NOT NULL,
  -- sha256 of the canonical request: method, route, signed-in user, session company/location/year and body.
  "request_sha256"  char(64)       NOT NULL,
  "actor"           varchar(64)    NOT NULL,
  "response_status" integer        NOT NULL,
  -- `json`, not `jsonb`: it keeps the exact bytes of the first response, so a replay is byte-identical.
  "response_body"   json,
  "created_at"      timestamptz(6) NOT NULL DEFAULT now(),
  "expires_at"      timestamptz(6) NOT NULL,
  CONSTRAINT "api_command_receipt_pkey" PRIMARY KEY ("tenant_id", "idempotency_key")
);

-- The purge deletes a tenant's expired receipts.
CREATE INDEX "api_command_receipt_expiry_idx" ON "api_command_receipt" ("tenant_id", "expires_at");

ALTER TABLE "api_command_receipt" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "api_command_receipt" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "api_command_receipt"
  USING (tenant_id = current_setting('app.tenant_id', true))
  WITH CHECK (tenant_id = current_setting('app.tenant_id', true));
