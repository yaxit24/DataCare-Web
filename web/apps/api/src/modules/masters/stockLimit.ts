import { withTenant } from '@datacare/db';

const n = (v: unknown): number => {
  if (v == null || v === '') return 0;
  const out = Number(v);
  return Number.isFinite(out) ? out : 0;
};
const t = (v: unknown, len: number): string | null => {
  const out = String(v ?? '')
    .trim()
    .toUpperCase()
    .slice(0, len);
  return out || null;
};
const designKey = (v: unknown): string => t(v, 20) ?? 'N';

export class StockLimitValidationError extends Error {
  constructor(message: string) {
    super(message);
    this.name = 'StockLimitValidationError';
  }
}

export interface DiamondSizeLine {
  dmSize?: string;
  dmWt?: number;
  pcsGht?: number;
  pcsLbr?: number;
  rateType?: string;
  dmRate?: number;
}

export interface DiamondSizeRow extends Required<Omit<DiamondSizeLine, 'rateType'>> {
  srNo: number;
  itCode: string;
  itName: string;
  dmSize: string;
  rateType: string | null;
}

export interface StockLimitLine {
  fromWt?: number;
  toWt?: number;
  minPcs?: number;
  lbrCode?: string;
  ghtPct?: number;
  lbrPct?: number;
  minLbrPct?: number;
  lbrType?: string;
  lbrRate?: number;
  lbrAmt?: number;
}

export interface StockLimitRow extends Required<Omit<StockLimitLine, 'lbrCode' | 'lbrType'>> {
  srNo: number;
  itCode: string;
  itName: string;
  itDesign: string;
  lbrCode: string | null;
  lbrType: string | null;
}

export interface StockLimitScope {
  tenantId: string;
  coCode: string;
}

function requireItemCode(itCode: unknown): string {
  const item = t(itCode, 5);
  if (!item) throw new StockLimitValidationError('Error Found : Please Enter Item code First...');
  return item;
}

async function assertItemExists(tx: any, scope: StockLimitScope, itCode: string): Promise<void> {
  const rows = (await tx.$queryRawUnsafe(
    `SELECT 1 FROM "ITEM_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "IT_CODE"=$3 LIMIT 1`,
    scope.tenantId,
    scope.coCode,
    itCode,
  )) as unknown[];
  if (!rows.length) throw new StockLimitValidationError(`item ${itCode} not found`);
}

export async function listDiamondSizeSummary(
  prisma: any,
  scope: StockLimitScope,
): Promise<Array<{ itCode: string; itName: string; dmSize: string; rowCount: number }>> {
  return withTenant(prisma, scope.tenantId, async (tx: any) => {
    const rows = (await tx.$queryRawUnsafe(
      `SELECT d."IT_CODE" AS "itCode",coalesce(i."IT_NAME",'') AS "itName",d."DM_SIZE" AS "dmSize",count(*)::int AS "rowCount"
         FROM "DM_SIZE" d
         LEFT JOIN "ITEM_MAST" i
           ON i.tenant_id=d.tenant_id AND i."CO_CODE"=d."CO_CODE" AND i."IT_CODE"=d."IT_CODE"
        WHERE d.tenant_id=$1 AND d."CO_CODE"=$2
        GROUP BY d."IT_CODE",i."IT_NAME",d."DM_SIZE"
        ORDER BY d."IT_CODE",d."DM_SIZE"`,
      scope.tenantId,
      scope.coCode,
    )) as Array<Record<string, unknown>>;
    return rows.map((r) => ({
      itCode: String(r.itCode ?? ''),
      itName: String(r.itName ?? ''),
      dmSize: String(r.dmSize ?? ''),
      rowCount: Number(r.rowCount ?? 0),
    }));
  });
}

export async function getDiamondSizes(
  prisma: any,
  scope: StockLimitScope,
  itCodeInput: string,
): Promise<DiamondSizeRow[]> {
  const itCode = requireItemCode(itCodeInput);
  return withTenant(prisma, scope.tenantId, async (tx: any) => {
    const rows = (await tx.$queryRawUnsafe(
      `SELECT row_number() OVER (ORDER BY d."DM_SIZE")::int AS "srNo",
              d."IT_CODE" AS "itCode",coalesce(i."IT_NAME",'') AS "itName",d."DM_SIZE" AS "dmSize",
              coalesce(d."DM_WT",0)::float8 AS "dmWt",coalesce(d."PCS_GHT",0)::float8 AS "pcsGht",
              coalesce(d."PCS_LBR",0)::float8 AS "pcsLbr",d."RATE_TYPE" AS "rateType",
              coalesce(d."DM_RATE",0)::float8 AS "dmRate"
         FROM "DM_SIZE" d
         LEFT JOIN "ITEM_MAST" i
           ON i.tenant_id=d.tenant_id AND i."CO_CODE"=d."CO_CODE" AND i."IT_CODE"=d."IT_CODE"
        WHERE d.tenant_id=$1 AND d."CO_CODE"=$2 AND d."IT_CODE"=$3
        ORDER BY d."DM_SIZE"`,
      scope.tenantId,
      scope.coCode,
      itCode,
    )) as Array<Record<string, unknown>>;
    return rows.map((r) => ({
      srNo: Number(r.srNo ?? 0),
      itCode: String(r.itCode ?? ''),
      itName: String(r.itName ?? ''),
      dmSize: String(r.dmSize ?? ''),
      dmWt: n(r.dmWt),
      pcsGht: n(r.pcsGht),
      pcsLbr: n(r.pcsLbr),
      rateType: t(r.rateType, 1),
      dmRate: n(r.dmRate),
    }));
  });
}

export async function saveDiamondSizes(
  prisma: any,
  scope: StockLimitScope,
  itCodeInput: string,
  lines: DiamondSizeLine[],
  mainUser?: string,
): Promise<{ saved: number }> {
  const itCode = requireItemCode(itCodeInput);
  const clean = (lines ?? []).filter((line) => t(line?.dmSize, 15));
  return withTenant(prisma, scope.tenantId, async (tx: any) => {
    await assertItemExists(tx, scope, itCode);
    await tx.$executeRawUnsafe(
      `DELETE FROM "DM_SIZE" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "IT_CODE"=$3`,
      scope.tenantId,
      scope.coCode,
      itCode,
    );
    let saved = 0;
    for (const line of clean) {
      await tx.$executeRawUnsafe(
        `INSERT INTO "DM_SIZE"(tenant_id,"CO_CODE","IT_CODE","DM_SIZE","DM_WT","PCS_GHT","PCS_LBR","RATE_TYPE","DM_RATE","MAIN_USER")
         VALUES ($1,$2,$3,$4,$5,$6,$7,$8,$9,$10)`,
        scope.tenantId,
        scope.coCode,
        itCode,
        t(line.dmSize, 15),
        n(line.dmWt),
        n(line.pcsGht),
        n(line.pcsLbr),
        t(line.rateType, 1),
        n(line.dmRate),
        t(mainUser, 15),
      );
      saved += 1;
    }
    return { saved };
  });
}

export async function deleteDiamondSizes(
  prisma: any,
  scope: StockLimitScope,
  itCodeInput: string,
): Promise<{ deleted: number }> {
  const itCode = requireItemCode(itCodeInput);
  return withTenant(prisma, scope.tenantId, async (tx: any) => {
    const deleted = await tx.$executeRawUnsafe(
      `DELETE FROM "DM_SIZE" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "IT_CODE"=$3`,
      scope.tenantId,
      scope.coCode,
      itCode,
    );
    return { deleted: Number(deleted) || 0 };
  });
}

export async function listItemStockLimitSummary(
  prisma: any,
  scope: StockLimitScope,
): Promise<Array<{ itCode: string; itName: string; itDesign: string; rowCount: number }>> {
  return withTenant(prisma, scope.tenantId, async (tx: any) => {
    const rows = (await tx.$queryRawUnsafe(
      `SELECT w."IT_CODE" AS "itCode",coalesce(i."IT_NAME",'') AS "itName",coalesce(w."IT_DESIGN",'N') AS "itDesign",count(*)::int AS "rowCount"
         FROM "ITM_WT_MAST" w
         LEFT JOIN "ITEM_MAST" i
           ON i.tenant_id=w.tenant_id AND i."CO_CODE"=w."CO_CODE" AND i."IT_CODE"=w."IT_CODE"
        WHERE w.tenant_id=$1 AND w."CO_CODE"=$2
        GROUP BY w."IT_CODE",i."IT_NAME",coalesce(w."IT_DESIGN",'N')
        ORDER BY w."IT_CODE",coalesce(w."IT_DESIGN",'N')`,
      scope.tenantId,
      scope.coCode,
    )) as Array<Record<string, unknown>>;
    return rows.map((r) => ({
      itCode: String(r.itCode ?? ''),
      itName: String(r.itName ?? ''),
      itDesign: String(r.itDesign ?? 'N'),
      rowCount: Number(r.rowCount ?? 0),
    }));
  });
}

export async function getItemStockLimits(
  prisma: any,
  scope: StockLimitScope,
  itCodeInput: string,
  itDesignInput: string = 'N',
): Promise<StockLimitRow[]> {
  const itCode = requireItemCode(itCodeInput);
  const itDesign = designKey(itDesignInput);
  return withTenant(prisma, scope.tenantId, async (tx: any) => {
    const rows = (await tx.$queryRawUnsafe(
      `SELECT w."SR_NO"::float8 AS "srNo",w."IT_CODE" AS "itCode",coalesce(i."IT_NAME",'') AS "itName",
              coalesce(w."IT_DESIGN",'N') AS "itDesign",
              coalesce(w."FROM_WT",0)::float8 AS "fromWt",coalesce(w."TO_WT",0)::float8 AS "toWt",
              coalesce(w."MIN_PCS",0)::float8 AS "minPcs",w."LBR_CODE" AS "lbrCode",
              coalesce(w."GHT_PRC",0)::float8 AS "ghtPct",coalesce(w."LBR_PRC",0)::float8 AS "lbrPct",
              coalesce(w."MIN_LBR_PRC",0)::float8 AS "minLbrPct",w."LBR_TYPE" AS "lbrType",
              coalesce(w."LBR_RATE",0)::float8 AS "lbrRate",coalesce(w."LBR_AMT",0)::float8 AS "lbrAmt"
         FROM "ITM_WT_MAST" w
         LEFT JOIN "ITEM_MAST" i
           ON i.tenant_id=w.tenant_id AND i."CO_CODE"=w."CO_CODE" AND i."IT_CODE"=w."IT_CODE"
        WHERE w.tenant_id=$1 AND w."CO_CODE"=$2 AND w."IT_CODE"=$3 AND coalesce(w."IT_DESIGN",'N')=$4
        ORDER BY w."SR_NO"`,
      scope.tenantId,
      scope.coCode,
      itCode,
      itDesign,
    )) as Array<Record<string, unknown>>;
    return rows.map((r) => ({
      srNo: n(r.srNo),
      itCode: String(r.itCode ?? ''),
      itName: String(r.itName ?? ''),
      itDesign: String(r.itDesign ?? 'N'),
      fromWt: n(r.fromWt),
      toWt: n(r.toWt),
      minPcs: n(r.minPcs),
      lbrCode: t(r.lbrCode, 4),
      ghtPct: n(r.ghtPct),
      lbrPct: n(r.lbrPct),
      minLbrPct: n(r.minLbrPct),
      lbrType: t(r.lbrType, 1),
      lbrRate: n(r.lbrRate),
      lbrAmt: n(r.lbrAmt),
    }));
  });
}

function cleanStockLimitLines(lines: StockLimitLine[]): StockLimitLine[] {
  return (lines ?? []).filter((line) => {
    if (!line) return false;
    const hasDesktopKeyFields = n(line.fromWt) + n(line.toWt) !== 0 && !!t(line.lbrCode, 4);
    const hasDesktopAmountFields =
      n(line.lbrPct) + n(line.lbrRate) + n(line.minPcs) + n(line.lbrAmt) + n(line.ghtPct) !== 0;
    return hasDesktopKeyFields || hasDesktopAmountFields;
  });
}

function validateLabourType(value: unknown): string | null {
  const out = t(value, 1);
  if (!out) return null;
  if (!['G', 'N', 'P', 'F', 'K'].includes(out)) {
    throw new StockLimitValidationError(
      'Please Insert Lbr Type = G Gross OR N Net OR P Pcs Wise OR F fix OR K Kg Wise Then Try...',
    );
  }
  return out;
}

export async function saveItemStockLimits(
  prisma: any,
  scope: StockLimitScope,
  itCodeInput: string,
  itDesignInput: string,
  lines: StockLimitLine[],
): Promise<{ saved: number }> {
  const itCode = requireItemCode(itCodeInput);
  const itDesign = designKey(itDesignInput);
  const clean = cleanStockLimitLines(lines);
  return withTenant(prisma, scope.tenantId, async (tx: any) => {
    await assertItemExists(tx, scope, itCode);
    await tx.$executeRawUnsafe(
      `DELETE FROM "ITM_WT_MAST"
        WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "IT_CODE"=$3 AND coalesce("IT_DESIGN",'N')=$4`,
      scope.tenantId,
      scope.coCode,
      itCode,
      itDesign,
    );
    const [{ maxSrNo = 0 } = {}] = (await tx.$queryRawUnsafe(
      `SELECT coalesce(max("SR_NO"),0)::float8 AS "maxSrNo"
         FROM "ITM_WT_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "IT_CODE"=$3`,
      scope.tenantId,
      scope.coCode,
      itCode,
    )) as Array<{ maxSrNo?: number }>;
    let srNo = Number(maxSrNo) || 0;
    let saved = 0;
    for (const line of clean) {
      srNo += 1;
      await tx.$executeRawUnsafe(
        `INSERT INTO "ITM_WT_MAST"(tenant_id,"CO_CODE","IT_CODE","SR_NO","FROM_WT","TO_WT","MIN_PCS","LBR_CODE","GHT_PRC","LBR_PRC","MIN_LBR_PRC","LBR_TYPE","LBR_RATE","LBR_AMT","IT_DESIGN")
         VALUES ($1,$2,$3,$4,$5,$6,$7,$8,$9,$10,$11,$12,$13,$14,$15)`,
        scope.tenantId,
        scope.coCode,
        itCode,
        srNo,
        n(line.fromWt),
        n(line.toWt),
        n(line.minPcs),
        t(line.lbrCode, 4),
        n(line.ghtPct),
        n(line.lbrPct),
        n(line.minLbrPct),
        validateLabourType(line.lbrType),
        n(line.lbrRate),
        n(line.lbrAmt),
        itDesign,
      );
      saved += 1;
    }
    return { saved };
  });
}

export async function deleteItemStockLimits(
  prisma: any,
  scope: StockLimitScope,
  itCodeInput: string,
  itDesignInput: string = 'N',
): Promise<{ deleted: number }> {
  const itCode = requireItemCode(itCodeInput);
  const itDesign = designKey(itDesignInput);
  return withTenant(prisma, scope.tenantId, async (tx: any) => {
    const deleted = await tx.$executeRawUnsafe(
      `DELETE FROM "ITM_WT_MAST"
        WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "IT_CODE"=$3 AND coalesce("IT_DESIGN",'N')=$4`,
      scope.tenantId,
      scope.coCode,
      itCode,
      itDesign,
    );
    return { deleted: Number(deleted) || 0 };
  });
}
