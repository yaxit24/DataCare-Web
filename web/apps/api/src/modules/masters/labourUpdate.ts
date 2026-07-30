import { withTenant } from '@datacare/db';

/**
 * Labour Update bulk (desktop "Labour and Mrp Update"): pick an item group, see every item's current
 * (Old) Labour rate / Labour % / MRP / Wastage%, edit the New values and save. Maps to ITEM_MAST:
 * IT_LBR_RATE (labour rate), LBR_PRC (labour %), ITEM_RATE (MRP), IT_WEST (wastage %). Only the columns
 * supplied per row are updated (partial), so a blank New cell leaves the Old value untouched.
 */
const num = (v: unknown): number => (v == null || v === '' ? 0 : Number(v));

export interface LabourItem {
  itCode: string;
  itName: string;
  lbrRate: number;
  lbrPct: number;
  mrp: number;
  west: number;
}
export interface LabourUpdateRow {
  itCode: string;
  lbrRate?: number;
  lbrPct?: number;
  mrp?: number;
  west?: number;
}

export async function listLabourItems(
  prisma: any,
  scope: { tenantId: string; coCode: string },
  grCode: string,
): Promise<LabourItem[]> {
  return withTenant(prisma, scope.tenantId, async (tx: any) => {
    const rows: any[] = await tx.$queryRawUnsafe(
      `SELECT "IT_CODE" it, coalesce("IT_NAME",'') nm,
              coalesce(NULLIF("IT_LBR_RATE"::text,'')::numeric,0)::float lbr, coalesce(NULLIF("LBR_PRC"::text,'')::numeric,0)::float lpc,
              coalesce(NULLIF("ITEM_RATE"::text,'')::numeric,0)::float mrp, coalesce(NULLIF("IT_WEST"::text,'')::numeric,0)::float west
       FROM "ITEM_MAST" WHERE "CO_CODE"=$1 AND "GR_CODE"=$2 ORDER BY "IT_CODE"`,
      scope.coCode,
      grCode,
    );
    return rows.map((r) => ({
      itCode: String(r.it),
      itName: String(r.nm ?? ''),
      lbrRate: Number(r.lbr),
      lbrPct: Number(r.lpc),
      mrp: Number(r.mrp),
      west: Number(r.west),
    }));
  });
}

export async function applyLabourUpdate(
  prisma: any,
  scope: { tenantId: string; coCode: string },
  rows: LabourUpdateRow[],
): Promise<{ updated: number }> {
  const clean = (rows ?? []).filter((r) => r && r.itCode);
  const colMap: [keyof LabourUpdateRow, string][] = [
    ['lbrRate', 'IT_LBR_RATE'],
    ['lbrPct', 'LBR_PRC'],
    ['mrp', 'ITEM_RATE'],
    ['west', 'IT_WEST'],
  ];
  return withTenant(prisma, scope.tenantId, async (tx: any) => {
    let updated = 0;
    for (const r of clean) {
      const sets: string[] = [];
      const params: unknown[] = [scope.coCode, String(r.itCode)];
      for (const [field, col] of colMap) {
        if (r[field] != null && (r[field] as any) !== '') {
          params.push(num(r[field]));
          sets.push(`"${col}" = $${params.length}`);
        }
      }
      if (!sets.length) continue;
      const n: number = await tx.$executeRawUnsafe(
        `UPDATE "ITEM_MAST" SET ${sets.join(', ')} WHERE "CO_CODE"=$1 AND "IT_CODE"=$2`,
        ...params,
      );
      updated += Number(n) || 0;
    }
    return { updated };
  });
}

/**
 * Weight-slab labour (desktop "Item Weight Slabs" / ITM_WT_MAST): an item can carry MULTIPLE labour
 * slabs keyed by SR_NO — a labour rate/% per weight band (FROM_WT..TO_WT). getLabourSlabs reads them;
 * setLabourSlabs replaces the item's slabs (clear + re-insert, SR_NO 1..n) so multiple slabs persist.
 */
export interface LabourSlab {
  srNo?: number;
  fromWt?: number;
  toWt?: number;
  minPcs?: number;
  lbrRate?: number;
  lbrPct?: number;
  lbrType?: string;
  lbrAmt?: number;
}

export async function getLabourSlabs(
  prisma: any,
  scope: { tenantId: string; coCode: string },
  itCode: string,
): Promise<LabourSlab[]> {
  return withTenant(prisma, scope.tenantId, async (tx: any) => {
    const rows: any[] = await tx.$queryRawUnsafe(
      `SELECT "SR_NO" sr, coalesce(NULLIF("FROM_WT"::text,'')::numeric,0)::float fw, coalesce(NULLIF("TO_WT"::text,'')::numeric,0)::float tw, coalesce(NULLIF("MIN_PCS"::text,'')::numeric,0)::float mp,
              coalesce(NULLIF("LBR_RATE"::text,'')::numeric,0)::float lr, coalesce(NULLIF("LBR_PRC"::text,'')::numeric,0)::float lp, coalesce("LBR_TYPE",'') lt, coalesce(NULLIF("LBR_AMT"::text,'')::numeric,0)::float la
         FROM "ITM_WT_MAST" WHERE "CO_CODE"=$1 AND "IT_CODE"=$2 ORDER BY "SR_NO"`,
      scope.coCode,
      itCode,
    );
    return rows.map((r) => ({
      srNo: Number(r.sr),
      fromWt: Number(r.fw),
      toWt: Number(r.tw),
      minPcs: Number(r.mp),
      lbrRate: Number(r.lr),
      lbrPct: Number(r.lp),
      lbrType: String(r.lt),
      lbrAmt: Number(r.la),
    }));
  });
}

export async function setLabourSlabs(
  prisma: any,
  scope: { tenantId: string; coCode: string },
  itCode: string,
  slabs: LabourSlab[],
): Promise<{ saved: number }> {
  if (!itCode) throw new Error('itCode is required');
  const clean = (slabs ?? []).filter(
    (s) => s && (num(s.fromWt) > 0 || num(s.toWt) > 0 || num(s.lbrRate) > 0 || num(s.lbrAmt) > 0),
  );
  return withTenant(prisma, scope.tenantId, async (tx: any) => {
    await tx.$executeRawUnsafe(
      `DELETE FROM "ITM_WT_MAST" WHERE "CO_CODE"=$1 AND "IT_CODE"=$2`,
      scope.coCode,
      itCode,
    );
    let i = 0;
    for (const s of clean) {
      i += 1;
      await tx.$executeRawUnsafe(
        `INSERT INTO "ITM_WT_MAST"(tenant_id,"CO_CODE","IT_CODE","SR_NO","FROM_WT","TO_WT","MIN_PCS","LBR_RATE","LBR_PRC","LBR_TYPE","LBR_AMT") VALUES ($1,$2,$3,$4,$5,$6,$7,$8,$9,$10,$11)`,
        scope.tenantId,
        scope.coCode,
        itCode,
        i,
        num(s.fromWt),
        num(s.toWt),
        num(s.minPcs),
        num(s.lbrRate),
        num(s.lbrPct),
        s.lbrType ?? null,
        num(s.lbrAmt),
      );
    }
    return { saved: i };
  });
}
