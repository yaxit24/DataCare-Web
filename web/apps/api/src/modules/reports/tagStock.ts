import { withTxBudget } from '../shared/txBudget.js';
import { barTagAvailableSql } from '../shared/stockSql.js';

/**
 * Tag-Stock report (desktop tag stock register). Tabs:
 *   in    — every tag IN-movement (MAIN_STOCK ITM_SIGN '+': opening, purchase, karigar receipt, return)
 *   out   — every tag OUT-movement (MAIN_STOCK ITM_SIGN '-': sale, cancel, transfer)
 *   stock — tags currently in stock (BAR_DETL not sold)
 *   mrp   — in-stock tags carrying an MRP
 *   apr   — tags out on approval, not yet returned/sold (APR_DETL ISU_REC <> 'Y')
 *   all   — every barcoded tag ever created (BAR_DETL)
 * Read-only; RLS-scoped. Optional counter (TBL_CODE) / item (IT_CODE) filters.
 */
export type TagStockTab = 'in' | 'out' | 'stock' | 'mrp' | 'apr' | 'all';
export interface TagStockRow {
  tagNo: string;
  itCode: string;
  designNo: string | null;
  tblCode: string | null;
  vchType: string | null;
  vchDate: string | null;
  pcs: number;
  grossWt: number;
  netWt: number;
  fine: number;
  mrp: number;
}
export interface TagStockReport {
  tab: TagStockTab;
  rows: TagStockRow[];
  totals: { count: number; pcs: number; netWt: number; fine: number; mrp: number };
}

const r3 = (n: number): number => Math.round((n + 1e-9) * 1000) / 1000;
const r2 = (n: number): number => Math.round((n + 1e-9) * 100) / 100;

export async function tagStockReport(
  prisma: any,
  tenantId: string,
  scope: { CO_CODE: string; LC_CODE: string },
  tab: TagStockTab,
  filters?: { tblCode?: string; itCode?: string },
): Promise<TagStockReport> {
  return withTxBudget(prisma, tenantId, 'read', async (tx: any) => {
    const params: unknown[] = [scope.CO_CODE, scope.LC_CODE];
    const flt: string[] = [];
    if (filters?.tblCode) {
      params.push(filters.tblCode);
      flt.push(`"TBL_CODE"::text=$${params.length}`);
    }
    if (filters?.itCode) {
      params.push(filters.itCode);
      flt.push(`"IT_CODE"::text=$${params.length}`);
    }
    const fltSql = flt.length ? ' AND ' + flt.join(' AND ') : '';
    const notSold = barTagAvailableSql('b');
    const sel = (t: string, extraWhere: string, dateCol: string, typeCol: string) =>
      `SELECT "TAG_NO" tag,"IT_CODE" it,"DESIGN_NO" dn,"TBL_CODE" tc, ${typeCol} vt, ${dateCol} vd,
              coalesce(NULLIF("ITM_PCS"::text,'')::numeric,0)::float pcs, coalesce(NULLIF("ITM_GWT"::text,'')::numeric,0)::float gwt, coalesce(NULLIF("ITM_NWT"::text,'')::numeric,0)::float nwt, coalesce(NULLIF("ITM_FINE"::text,'')::numeric,0)::float fine, coalesce(NULLIF("ITM_MRP"::text,'')::numeric,0)::float mrp
         FROM "${t}" b WHERE b."CO_CODE"::text=$1 AND b."LC_CODE"::text=$2${fltSql}${extraWhere} ORDER BY b."TAG_NO" LIMIT 5000`;
    let sql: string;
    if (tab === 'in')
      sql = sel(
        'MAIN_STOCK',
        ` AND "ITM_SIGN"::text='+'`,
        `"VCH_DATE"::text`,
        `coalesce("VCH_TYPE",'')`,
      );
    else if (tab === 'out')
      sql = sel(
        'MAIN_STOCK',
        ` AND "ITM_SIGN"::text='-'`,
        `"VCH_DATE"::text`,
        `coalesce("VCH_TYPE",'')`,
      );
    else if (tab === 'apr')
      sql = `SELECT "TAG_NO" tag,"IT_CODE" it,"DESIGN_NO" dn,"TBL_CODE" tc, coalesce("VCH_TYPE",'') vt, "VCH_DATE"::text vd, coalesce(NULLIF("ITM_PCS"::text,'')::numeric,0)::float pcs, coalesce(NULLIF("ITM_GWT"::text,'')::numeric,0)::float gwt, coalesce(NULLIF("ITM_NWT"::text,'')::numeric,0)::float nwt, coalesce(NULLIF("ITM_FINE"::text,'')::numeric,0)::float fine, 0::float mrp FROM "APR_DETL" WHERE "CO_CODE"::text=$1 AND "LC_CODE"::text=$2${fltSql} AND coalesce("ISU_REC",'N')<>'Y' ORDER BY "TAG_NO" LIMIT 5000`;
    else if (tab === 'mrp')
      sql = sel(
        'BAR_DETL',
        ` AND ${notSold} AND coalesce(NULLIF("ITM_MRP"::text,'')::numeric,0)>0`,
        `"VCH_DATE"::text`,
        `coalesce("VCH_TYPE",'')`,
      );
    else if (tab === 'all')
      sql = sel('BAR_DETL', ``, `"VCH_DATE"::text`, `coalesce("VCH_TYPE",'')`);
    else sql = sel('BAR_DETL', ` AND ${notSold}`, `"VCH_DATE"::text`, `coalesce("VCH_TYPE",'')`); // stock
    const rows: any[] = await tx.$queryRawUnsafe(sql, ...params);
    const out: TagStockRow[] = rows.map((r) => ({
      tagNo: String(r.tag ?? ''),
      itCode: String(r.it ?? ''),
      designNo: r.dn ?? null,
      tblCode: r.tc ?? null,
      vchType: r.vt ?? null,
      vchDate: r.vd ? String(r.vd).slice(0, 10) : null,
      pcs: Number(r.pcs),
      grossWt: Number(r.gwt),
      netWt: Number(r.nwt),
      fine: Number(r.fine),
      mrp: Number(r.mrp),
    }));
    const totals = out.reduce(
      (a, r) => ({
        count: a.count + 1,
        pcs: a.pcs + r.pcs,
        netWt: r3(a.netWt + r.netWt),
        fine: r3(a.fine + r.fine),
        mrp: r2(a.mrp + r.mrp),
      }),
      { count: 0, pcs: 0, netWt: 0, fine: 0, mrp: 0 },
    );
    return { tab, rows: out, totals };
  });
}

/** CSV export of a tag-stock report. */
export function tagStockCsv(rep: TagStockReport): string {
  const head = [
    'Tag',
    'Item',
    'Design',
    'Counter',
    'VchType',
    'Date',
    'Pcs',
    'GrossWt',
    'NetWt',
    'Fine',
    'MRP',
  ];
  const esc = (v: unknown) => {
    const s = String(v ?? '');
    return /[",\n]/.test(s) ? '"' + s.replace(/"/g, '""') + '"' : s;
  };
  const lines = [head.join(',')];
  for (const r of rep.rows)
    lines.push(
      [
        r.tagNo,
        r.itCode,
        r.designNo,
        r.tblCode,
        r.vchType,
        r.vchDate,
        r.pcs,
        r.grossWt,
        r.netWt,
        r.fine,
        r.mrp,
      ]
        .map(esc)
        .join(','),
    );
  lines.push(
    [
      'TOTAL',
      '',
      '',
      '',
      '',
      '',
      rep.totals.pcs,
      '',
      rep.totals.netWt,
      rep.totals.fine,
      rep.totals.mrp,
    ]
      .map(esc)
      .join(','),
  );
  return lines.join('\n');
}
