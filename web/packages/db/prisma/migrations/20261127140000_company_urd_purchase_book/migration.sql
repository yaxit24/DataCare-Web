-- Linked old-gold purchase (owner decision 2B, 2026-11-27): the per-company choice of the Gold / Silver URD purchase
-- book a tax-invoice sale's Old Gold / Old Silver row opens.
--
-- The desktop hardcodes books 043 / 044 (TR_SALE.cs:18756-18842). Web-provisioned companies number their books
-- differently (PR, TPR, ...), so the web resolves the book per metal: this setting first, else 043 / 044, else the
-- single PURCHASE book named for it (purchase/urdBook.ts). Web-only table: the desktop has no equivalent. A company
-- without a row (or with a NULL book) uses the fallback rule.
--
-- "CO_CODE" is spelled like the desktop column on purpose: the company backup includes every table with tenant_id and
-- CO_CODE (backupManifest.ts), and this choice is company configuration a restore must carry. No data is written
-- here, so no RLS bypass is needed.
CREATE TABLE "company_urd_book" (
  "tenant_id"   varchar(24)    NOT NULL,
  "CO_CODE"     varchar(2)     NOT NULL,
  "gold_book"   varchar(3),
  "silver_book" varchar(3),
  "updated_by"  varchar(64),
  "updated_at"  timestamptz(6) NOT NULL DEFAULT now(),
  CONSTRAINT "company_urd_book_pkey" PRIMARY KEY ("tenant_id", "CO_CODE")
);

ALTER TABLE "company_urd_book" ENABLE ROW LEVEL SECURITY;
ALTER TABLE "company_urd_book" FORCE ROW LEVEL SECURITY;
CREATE POLICY tenant_isolation ON "company_urd_book"
  USING (tenant_id = current_setting('app.tenant_id', true))
  WITH CHECK (tenant_id = current_setting('app.tenant_id', true));
