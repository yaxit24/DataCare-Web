-- Performance indexes for the hot read paths (Task 31/32 perf sanity).
-- Safe to run repeatedly (IF NOT EXISTS). Apply as the schema owner (datacare), not app_user.

-- Ledger / trial balance / day-book / account statement
CREATE INDEX IF NOT EXISTS idx_ac_data_scope ON "AC_DATA" (tenant_id, "CO_CODE", "AC_CODE", "VCH_DATE");
-- Sales register / GSTR-1 / e-invoice listing
CREATE INDEX IF NOT EXISTS idx_sl_data_scope ON "SL_DATA" (tenant_id, "CO_CODE", "VCH_DATE");
-- Purchase register
CREATE INDEX IF NOT EXISTS idx_pr_data_scope ON "PR_DATA" (tenant_id, "CO_CODE", "VCH_DATE");
-- Tag stock lookups + double-issue guard
CREATE INDEX IF NOT EXISTS idx_tag_stock_key ON "TAG_STOCK" (tenant_id, "CO_CODE", "LC_CODE", "TAG_NO");
-- Voucher numbering counter
CREATE INDEX IF NOT EXISTS idx_srno_mast_key ON "SRNO_MAST" (tenant_id, "CO_CODE", "LC_CODE");
-- Dhrn outstanding (issue ⋈ summed receipts by ISU_NO)
CREATE INDEX IF NOT EXISTS idx_dhrn_rec_isu ON "DHRN_REC_DATA" (tenant_id, "CO_CODE", "ISU_NO");
