import { withTenant } from '@datacare/db';

const NN = (c: string): string => `coalesce(NULLIF(${c}::text,'')::numeric,0)`;

/** Latest metal rate for a group on/before a date (RATE_MAST) — drives rate auto-fill on sale/purchase
 *  lines, mirroring the desktop's rate lookup. Falls back to the most recent rate if none on/before. */
export async function fetchRate(
  prisma: any,
  tenantId: string,
  coCode: string,
  group: string,
  date?: string,
): Promise<{
  group: string;
  rate: number;
  touch: number;
  fineGold: number;
  fineSilver: number;
  date: string;
} | null> {
  const d = date && /^\d{4}-\d{2}-\d{2}/.test(date) ? date.slice(0, 10) : '9999-12-31';
  return withTenant(prisma, tenantId, async (tx: any) => {
    const rows: any[] = await tx.$queryRawUnsafe(
      `SELECT "GR_CODE", "VCH_DATE", ${NN('"GR_RATE"')} AS rate, ${NN('"GR_TOUCH"')} AS touch,
              ${NN('"FINE_GL_RATE"')} AS finegl, ${NN('"FINE_SL_RATE"')} AS finesl
       FROM "RATE_MAST" WHERE "CO_CODE"=$1 AND "GR_CODE"::text=$2 AND "VCH_DATE"::text <= $3
       ORDER BY "VCH_DATE" DESC, "SR_NO" DESC LIMIT 1`,
      coCode,
      group,
      d,
    );
    let r = rows[0];
    if (!r) {
      // fallback: a given group's latest row; if NO group (e.g. the rate ticker) the latest row of ANY group.
      const hasGroup = !!(group && String(group).trim());
      const any: any[] = await tx.$queryRawUnsafe(
        `SELECT "GR_CODE", "VCH_DATE", ${NN('"GR_RATE"')} AS rate, ${NN('"GR_TOUCH"')} AS touch, ${NN('"FINE_GL_RATE"')} AS finegl, ${NN('"FINE_SL_RATE"')} AS finesl
         FROM "RATE_MAST" WHERE "CO_CODE"=$1 ${hasGroup ? 'AND "GR_CODE"::text=$2' : ''} ORDER BY "VCH_DATE" DESC LIMIT 1`,
        ...(hasGroup ? [coCode, group] : [coCode]),
      );
      r = any[0];
    }
    if (!r) return null;
    return {
      group: r.GR_CODE,
      rate: Number(r.rate),
      touch: Number(r.touch),
      fineGold: Number(r.finegl),
      fineSilver: Number(r.finesl),
      date: String(r.VCH_DATE).slice(0, 10),
    };
  });
}

/** List rate groups (for a rate-group dropdown). */
export async function rateGroups(prisma: any, tenantId: string, coCode: string): Promise<string[]> {
  return withTenant(prisma, tenantId, async (tx: any) => {
    const rows: any[] = await tx.$queryRawUnsafe(
      `SELECT DISTINCT "GR_CODE" g FROM "RATE_MAST" WHERE "CO_CODE"=$1 AND coalesce("GR_CODE",'')<>'' ORDER BY 1`,
      coCode,
    );
    return rows.map((r) => r.g);
  });
}
