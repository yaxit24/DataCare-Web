-- WP-19: the per-line GST shares the desktop labour invoice stores on LBR_ISU_DETL (TR_SALE_LBR.cs:9748-9830) and
-- the Gst Report's HSN section sums (RP_GST.cs:2719). The desktop columns are FLOAT NOT NULL DEFAULT 0
-- (MS_UPDATE.cs:6378, 6435, 6706). IT_TAX_AMT and IT_LBR_TAX already exist (legacy VARCHAR) and are kept.
ALTER TABLE "LBR_ISU_DETL"
  ADD COLUMN IF NOT EXISTS "IT_NET_AMT" DOUBLE PRECISION NOT NULL DEFAULT 0,
  ADD COLUMN IF NOT EXISTS "IT_DISC_AMT" DOUBLE PRECISION NOT NULL DEFAULT 0,
  ADD COLUMN IF NOT EXISTS "IT_LBR_AMT" DOUBLE PRECISION NOT NULL DEFAULT 0,
  ADD COLUMN IF NOT EXISTS "IT_LBR_DISC" DOUBLE PRECISION NOT NULL DEFAULT 0;

-- Rows the web wrote before this migration carry no shares. Recompute them from their voucher with the desktop
-- formula, so the HSN section does not lose those labour bills: the share of NET_AMT (metal) and LBR_AMT (labour)
-- in the voucher's metal net (SL_NET_AMT) and labour net (LBR_DR_AMT), the tax rounded to 2 decimals half to even
-- (.NET Math.Round). The web labour invoice takes no labour discount, so IT_DISC_AMT and IT_LBR_DISC stay 0.
WITH voucher AS (
  SELECT d.row_id,
         d."NET_AMT"::double precision AS net,
         d."LBR_AMT"::double precision AS lbr,
         (SUM(d."NET_AMT") OVER w)::double precision AS net_total,
         (SUM(d."LBR_AMT") OVER w)::double precision AS lbr_total,
         h."SL_NET_AMT"::double precision AS metal_net,
         h."TAX_AMT"::double precision AS metal_tax,
         h."LBR_DR_AMT"::double precision AS labour_net,
         h."LBR_TAX_AMT"::double precision AS labour_tax
    FROM "LBR_ISU_DETL" d
    JOIN "LBR_DATA" h
      ON h.tenant_id=d.tenant_id AND h."CO_CODE"=d."CO_CODE" AND h."LC_CODE"=d."LC_CODE"
     AND h."CO_YEAR"=d."CO_YEAR" AND h."CO_BOOK"=d."CO_BOOK" AND h."VCH_NO"=d."VCH_NO"
   WHERE d."BOOK_NAME"='LABOUR' AND d."VCH_TYPE"='LBRI'
  WINDOW w AS (PARTITION BY d.tenant_id,d."CO_CODE",d."LC_CODE",d."CO_YEAR",d."CO_BOOK",d."VCH_NO")
), share AS (
  SELECT row_id,
         CASE WHEN COALESCE(metal_tax,0)<>0 AND COALESCE(metal_net,0)<>0 AND COALESCE(net,0)<>0
              THEN net + net / net_total * (metal_net - net_total) ELSE 0 END AS it_net,
         metal_net, metal_tax,
         CASE WHEN COALESCE(labour_tax,0)<>0 AND COALESCE(labour_net,0)<>0 AND COALESCE(lbr,0)<>0
              THEN lbr + lbr / lbr_total * (labour_net - lbr_total) ELSE 0 END AS it_lbr,
         labour_net, labour_tax
    FROM voucher
), raw AS (
  SELECT row_id, it_net, it_lbr,
         (CASE WHEN it_net<>0 THEN it_net * metal_tax / metal_net ELSE 0 END)::numeric * 100 AS tax100,
         (CASE WHEN it_lbr<>0 THEN it_lbr * labour_tax / labour_net ELSE 0 END)::numeric * 100 AS lbr_tax100
    FROM share
)
UPDATE "LBR_ISU_DETL" d
   SET "IT_NET_AMT" = r.it_net,
       "IT_TAX_AMT" = (CASE WHEN abs(r.tax100 - trunc(r.tax100)) = 0.5
                            THEN (trunc(r.tax100) + CASE WHEN mod(trunc(r.tax100), 2) = 0 THEN 0 ELSE sign(r.tax100) END) / 100
                            ELSE round(r.tax100 / 100, 2) END)::double precision::text,
       "IT_LBR_AMT" = r.it_lbr,
       "IT_LBR_TAX" = (CASE WHEN abs(r.lbr_tax100 - trunc(r.lbr_tax100)) = 0.5
                            THEN (trunc(r.lbr_tax100) + CASE WHEN mod(trunc(r.lbr_tax100), 2) = 0 THEN 0 ELSE sign(r.lbr_tax100) END) / 100
                            ELSE round(r.lbr_tax100 / 100, 2) END)::double precision::text
  FROM raw r
 WHERE d.row_id = r.row_id;
