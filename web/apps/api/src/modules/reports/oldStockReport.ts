import { withTenant } from '@datacare/db';
import { applyFilters } from './reportFilters.js';
import type { ListReport, ReportScope } from './reports.js';

const num = (v: unknown): number => {
  const n = Number(v ?? 0);
  return Number.isFinite(n) ? n : 0;
};
const txt = (v: unknown): string | null => {
  const s = String(v ?? '').trim();
  return s ? s : null;
};
const round3 = (n: number): number => Math.round(n * 1000) / 1000;
const monthLabel = (year: number, month: number): string => `${String(year).slice(-2)}/${String(month).padStart(2, '0')}`;

function varcharDateExpr(alias: string, column: string): string {
  const value = `NULLIF(trim(${alias}."${column}"::text),'')`;
  return `(CASE
    WHEN ${value} ~ '^\\d{4}-\\d{2}-\\d{2}' THEN substring(${value} from 1 for 10)::date
    WHEN ${value} ~ '^\\d{1,2}/\\d{1,2}/\\d{4}$' THEN to_date(${value}, 'MM/DD/YYYY')
    ELSE NULL
  END)`;
}

/**
 * Old Stock — desktop `RP_SLPR_ZOOM` with `CurRpt == "Old Stock"`.
 *
 * The desktop hides the sale/purchase zoom buttons and runs one stock-age query from `BtnSize_Click`:
 * `MAIN_STOCK A` joined to `BAR_DETL B` and `ITEM_MAST C`, grouped by item and `BAR_DETL.STK_DATE`
 * year/month. It counts signed tag instances (`+` = 1, everything else = -1) but keeps only groups whose
 * signed `VCH_SRNO` sum is positive. The WinForms grid then pivots those months into dynamic columns.
 */
export async function oldStockReport(
  prisma: any,
  s: ReportScope,
  options: { karigarCode?: unknown } = {},
): Promise<ListReport> {
  const karigarCode = String(options.karigarCode ?? '').trim();
  const toDate = s.toDate ?? new Date().toISOString().slice(0, 10);
  const filters = { ...(s.filters ?? {}), itType: String(s.filters?.itType ?? 'G').slice(0, 1) || 'G' };
  const barStockDate = varcharDateExpr('b', 'STK_DATE');
  const mainStockDate = varcharDateExpr('a', 'STK_DATE');

  return withTenant(prisma, s.tenantId, async (tx: any) => {
    const params: unknown[] = [s.coCode];
    const where = [`a."CO_CODE"=$1`, `coalesce(a."TAG_NO",'') <> 'N'`, `${barStockDate} IS NOT NULL`, `${mainStockDate} <= $2::date`];
    params.push(toDate);
    if (s.lcCode) {
      params.push(s.lcCode);
      where.push(`a."LC_CODE"=$${params.length}`);
    }
    if (karigarCode) {
      params.push(karigarCode);
      where.push(`b."KR_NAME"=$${params.length}`);
    }
    const filterSql = applyFilters('old-stock', filters, params);
    const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT a."IT_CODE" AS "itCode", c."IT_NAME" AS "itName",
              EXTRACT(YEAR FROM ${barStockDate})::int AS "yrCode",
              EXTRACT(MONTH FROM ${barStockDate})::int AS "mnCode",
              SUM(CASE WHEN a."ITM_SIGN"='+' THEN 1 ELSE -1 END) AS "pcs"
         FROM "MAIN_STOCK" a
         LEFT JOIN "BAR_DETL" b
           ON b.tenant_id=a.tenant_id
          AND b."CO_CODE"=a."CO_CODE"
          AND b."LC_CODE"=a."LC_CODE"
          AND b."TAG_NO"=a."TAG_NO"
          AND b."VCH_SRNO"=a."VCH_SRNO"
         LEFT JOIN "ITEM_MAST" c
           ON c.tenant_id=a.tenant_id
          AND c."CO_CODE"=a."CO_CODE"
          AND c."IT_CODE"::text=a."IT_CODE"::text
        WHERE ${where.join(' AND ')}${filterSql}
        GROUP BY a."IT_CODE", c."IT_NAME", EXTRACT(YEAR FROM ${barStockDate}), EXTRACT(MONTH FROM ${barStockDate})
        HAVING SUM(CASE WHEN a."ITM_SIGN"='+' THEN coalesce(a."VCH_SRNO",0) ELSE -coalesce(a."VCH_SRNO",0) END) > 0
        ORDER BY c."IT_NAME", a."IT_CODE", EXTRACT(YEAR FROM ${barStockDate}), EXTRACT(MONTH FROM ${barStockDate})`,
      ...params,
    );

    const labels = Array.from(
      new Set(
        rows.map((row) => monthLabel(num(row.yrCode), num(row.mnCode))),
      ),
    ).sort();
    const byItem = new Map<string, Record<string, unknown> & { total: number }>();
    const monthTotals = Object.fromEntries(labels.map((label) => [label, 0])) as Record<string, number>;

    for (const row of rows) {
      const itemCode = txt(row.itCode) ?? '';
      const key = itemCode || `${txt(row.itName) ?? ''}`;
      if (!byItem.has(key)) {
        byItem.set(key, {
          srNo: 0,
          itemName: txt(row.itName),
          itemCode: txt(row.itCode),
          ...Object.fromEntries(labels.map((label) => [label, 0])),
          total: 0,
        } as Record<string, unknown> & { total: number });
      }
      const label = monthLabel(num(row.yrCode), num(row.mnCode));
      const pcs = round3(num(row.pcs));
      const item = byItem.get(key)!;
      item[label] = round3(num(item[label]) + pcs);
      item.total = round3(item.total + pcs);
      monthTotals[label] = round3((monthTotals[label] ?? 0) + pcs);
    }

    const pivotRows = Array.from(byItem.values()).map((row, index) => ({ ...row, srNo: index + 1 }));
    const totals = {
      rows: pivotRows.length,
      items: pivotRows.length,
      ...monthTotals,
      total: round3(pivotRows.reduce((sum, row) => sum + num(row.total), 0)),
    };
    return { rows: pivotRows, totals };
  });
}
