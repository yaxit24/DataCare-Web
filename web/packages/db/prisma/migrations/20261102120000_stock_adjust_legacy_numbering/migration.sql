-- Pre-N221 Stock Adjust vouchers exist only in MAIN_STOCK. Current numbering includes those rows under the
-- complete voucher scope, so give that lookup a matching non-unique index. The index must remain non-unique:
-- one voucher has many stock lines and deployed databases may already contain old/current key collisions.
CREATE INDEX IF NOT EXISTS "idx_main_stock_voucher_identity"
  ON "MAIN_STOCK" (tenant_id, "CO_CODE", "LC_CODE", "CO_YEAR", "CO_BOOK", "VCH_NO");
