-- G82: web-provisioned companies seeded each GST tax code as a single row at SR_NO = 1 with the TOTAL rate
-- and TAX_GROUP 'N'. The resolver (shared/taxPolicy.ts) and the desktop both pin a named code by its PARENT
-- row SR_NO = 0 (desktop: `AND D.SR_NO = 0`), so every save that named a tax code failed with
-- "tax code is not configured" on every such company. This repairs the shape in place:
--   * insert the missing parent row at SR_NO = 0 (TOTAL rate, TAX_GROUP 'N');
--   * turn the stray SR_NO = 1 row into the SGST component (half rate, TAX_GROUP 'SGST');
--   * add the CGST (SR_NO = 2, half) and IGST (SR_NO = 3, full) component rows.
-- GST codes are the five standard rates 10..14 (desktop-conventions.json). Idempotent: it acts only on a
-- (tenant, company, code) that still has no SR_NO = 0 parent, so re-running or running against an
-- already-correct company is a no-op.
--
-- TAX_AC is carried over from the stray row unchanged, NULL included. The old seed never set it, so the web
-- writers keep falling back to 'GST' (sales) and 'GSTINPUT' (purchases) exactly as before: this migration
-- changes the shape of the tax master and no posted account. Choosing tax ledger accounts is decision D15.

DO $$
DECLARE
  r RECORD;
  tax_ac TEXT;
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
    -- The total rate and account come from the stray row this seed wrote (the lowest SR_NO).
    SELECT COALESCE("TAX_PRC", 0), NULLIF(btrim(COALESCE("TAX_AC", '')), '')
      INTO total, tax_ac
      FROM "TAX_MAST"
     WHERE tenant_id = r.tenant_id AND "CO_CODE" = r."CO_CODE" AND "TAX_CODE" = r."TAX_CODE"
     ORDER BY COALESCE("SR_NO", 0)
     LIMIT 1;
    half := ROUND(total / 2.0, 4);

    -- Parent (SR_NO 0): the row a named code resolves to.
    INSERT INTO "TAX_MAST"(tenant_id, "CO_CODE", "TAX_CODE", "SR_NO", "TAX_NAME", "TAX_PRC", "TAX_GROUP", "TAX_AC")
    VALUES (r.tenant_id, r."CO_CODE", r."TAX_CODE", 0,
            'GST ' || (CASE WHEN total = TRUNC(total) THEN TRUNC(total)::text ELSE total::text END) || '%',
            total, 'N', tax_ac);

    -- SR_NO 1 becomes SGST (half rate); it previously held the total rate with TAX_GROUP 'N'.
    UPDATE "TAX_MAST"
       SET "TAX_PRC" = half, "TAX_GROUP" = 'SGST',
           "TAX_NAME" = COALESCE(NULLIF("TAX_NAME", ''), 'GST') || ' SGST'
     WHERE tenant_id = r.tenant_id AND "CO_CODE" = r."CO_CODE" AND "TAX_CODE" = r."TAX_CODE"
       AND COALESCE("SR_NO", 0) = 1;

    -- CGST (SR_NO 2, half) and IGST (SR_NO 3, full), only if absent.
    IF NOT EXISTS (SELECT 1 FROM "TAX_MAST" WHERE tenant_id = r.tenant_id AND "CO_CODE" = r."CO_CODE" AND "TAX_CODE" = r."TAX_CODE" AND COALESCE("SR_NO", 0) = 2) THEN
      INSERT INTO "TAX_MAST"(tenant_id, "CO_CODE", "TAX_CODE", "SR_NO", "TAX_NAME", "TAX_PRC", "TAX_GROUP", "TAX_AC")
      VALUES (r.tenant_id, r."CO_CODE", r."TAX_CODE", 2, 'GST CGST', half, 'CGST', tax_ac);
    END IF;
    IF NOT EXISTS (SELECT 1 FROM "TAX_MAST" WHERE tenant_id = r.tenant_id AND "CO_CODE" = r."CO_CODE" AND "TAX_CODE" = r."TAX_CODE" AND COALESCE("SR_NO", 0) = 3) THEN
      INSERT INTO "TAX_MAST"(tenant_id, "CO_CODE", "TAX_CODE", "SR_NO", "TAX_NAME", "TAX_PRC", "TAX_GROUP", "TAX_AC")
      VALUES (r.tenant_id, r."CO_CODE", r."TAX_CODE", 3, 'GST IGST', total, 'IGST', tax_ac);
    END IF;
  END LOOP;
END $$;
