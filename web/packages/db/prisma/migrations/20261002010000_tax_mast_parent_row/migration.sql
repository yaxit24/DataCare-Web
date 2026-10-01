-- G82: web-provisioned companies seeded each GST tax code as a single row at SR_NO = 1 with the TOTAL rate
-- and TAX_GROUP 'N'. The resolver (shared/taxPolicy.ts) and the desktop both pin a named code by its PARENT
-- row SR_NO = 0 (desktop: `AND D.SR_NO = 0`), so every save that named a tax code failed with
-- "tax code is not configured" on every such company. This repairs the shape in place:
--   * insert the missing parent row at SR_NO = 0 (TOTAL rate, TAX_GROUP 'N', TAX_AC = the GST account);
--   * turn the stray SR_NO = 1 row into the SGST component (half rate, TAX_GROUP 'SGST');
--   * add the CGST (SR_NO = 2, half) and IGST (SR_NO = 3, full) component rows.
-- GST codes are the five standard rates 10..14 (desktop-conventions.json). Idempotent: it acts only on a
-- (tenant, company, code) that still has no SR_NO = 0 parent, so re-running or running against an
-- already-correct company is a no-op. TAX_AC mirrors the single web GST output account carried by the
-- SR_NO = 1 row, falling back to 'GST'.

DO $$
DECLARE
  r RECORD;
  gst_ac TEXT;
  total NUMERIC;
  half NUMERIC;
BEGIN
  FOR r IN
    SELECT DISTINCT t.tenant_id, t."CO_CODE", t."TAX_CODE"
      FROM "TAX_MAST" t
     WHERE t."TAX_CODE" IN ('10','11','12','13','14')
       AND NOT EXISTS (
         SELECT 1 FROM "TAX_MAST" p
          WHERE p.tenant_id = t.tenant_id
            AND p."CO_CODE" = t."CO_CODE"
            AND p."TAX_CODE" = t."TAX_CODE"
            AND COALESCE(p."SR_NO", 0) = 0
       )
  LOOP
    -- The total rate and GST account come from the stray SR_NO = 1 row this seed wrote.
    SELECT COALESCE("TAX_PRC", 0), COALESCE(NULLIF("TAX_AC", ''), 'GST')
      INTO total, gst_ac
      FROM "TAX_MAST"
     WHERE tenant_id = r.tenant_id AND "CO_CODE" = r."CO_CODE" AND "TAX_CODE" = r."TAX_CODE"
     ORDER BY COALESCE("SR_NO", 0)
     LIMIT 1;
    half := ROUND(total / 2.0, 4);

    -- Parent (SR_NO 0): the row a named code resolves to.
    INSERT INTO "TAX_MAST"(tenant_id, "CO_CODE", "TAX_CODE", "SR_NO", "TAX_NAME", "TAX_PRC", "TAX_GROUP", "TAX_AC")
    VALUES (r.tenant_id, r."CO_CODE", r."TAX_CODE", 0,
            'GST ' || (CASE WHEN total = TRUNC(total) THEN TRUNC(total)::text ELSE total::text END) || '%',
            total, 'N', gst_ac);

    -- SR_NO 1 becomes SGST (half rate); it previously held the total rate with TAX_GROUP 'N'.
    UPDATE "TAX_MAST"
       SET "TAX_PRC" = half, "TAX_GROUP" = 'SGST', "TAX_AC" = gst_ac,
           "TAX_NAME" = COALESCE(NULLIF("TAX_NAME", ''), 'GST') || ' SGST'
     WHERE tenant_id = r.tenant_id AND "CO_CODE" = r."CO_CODE" AND "TAX_CODE" = r."TAX_CODE"
       AND COALESCE("SR_NO", 0) = 1;

    -- CGST (SR_NO 2, half) and IGST (SR_NO 3, full), only if absent.
    IF NOT EXISTS (SELECT 1 FROM "TAX_MAST" WHERE tenant_id = r.tenant_id AND "CO_CODE" = r."CO_CODE" AND "TAX_CODE" = r."TAX_CODE" AND COALESCE("SR_NO", 0) = 2) THEN
      INSERT INTO "TAX_MAST"(tenant_id, "CO_CODE", "TAX_CODE", "SR_NO", "TAX_NAME", "TAX_PRC", "TAX_GROUP", "TAX_AC")
      VALUES (r.tenant_id, r."CO_CODE", r."TAX_CODE", 2, 'GST CGST', half, 'CGST', gst_ac);
    END IF;
    IF NOT EXISTS (SELECT 1 FROM "TAX_MAST" WHERE tenant_id = r.tenant_id AND "CO_CODE" = r."CO_CODE" AND "TAX_CODE" = r."TAX_CODE" AND COALESCE("SR_NO", 0) = 3) THEN
      INSERT INTO "TAX_MAST"(tenant_id, "CO_CODE", "TAX_CODE", "SR_NO", "TAX_NAME", "TAX_PRC", "TAX_GROUP", "TAX_AC")
      VALUES (r.tenant_id, r."CO_CODE", r."TAX_CODE", 3, 'GST IGST', total, 'IGST', gst_ac);
    END IF;
  END LOOP;
END $$;
