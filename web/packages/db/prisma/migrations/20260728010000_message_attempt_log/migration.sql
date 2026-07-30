CREATE TABLE "message_attempt_log" (
  "id" BIGSERIAL NOT NULL,
  "tenant_id" VARCHAR(24) NOT NULL,
  "co_code" VARCHAR(2) NOT NULL,
  "lc_code" VARCHAR(2),
  "channel" VARCHAR(16) NOT NULL,
  "recipient" VARCHAR(64) NOT NULL,
  "template_kind" VARCHAR(64) NOT NULL,
  "idempotency_key" VARCHAR(128) NOT NULL,
  "status" VARCHAR(16) NOT NULL,
  "provider_reference" VARCHAR(255),
  "failure_reason" TEXT,
  "created_at" TIMESTAMPTZ(6) NOT NULL DEFAULT CURRENT_TIMESTAMP,

  CONSTRAINT "message_attempt_log_pkey" PRIMARY KEY ("id"),
  CONSTRAINT "message_attempt_log_tenant_id_idempotency_key_key"
    UNIQUE ("tenant_id", "idempotency_key")
);
