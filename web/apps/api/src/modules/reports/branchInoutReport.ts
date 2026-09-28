import { withTenant } from '@datacare/db';
import { applyFilters } from './reportFilters.js';
import type { ListReport, ReportScope } from './reports.js';

export type BranchInoutMode = 'out' | 'in';

const num = (v: unknown): number => {
  const n = Number(v ?? 0);
  return Number.isFinite(n) ? n : 0;
};
const round3 = (n: number): number => Math.round(n * 1000) / 1000;
const isoDate = (v: unknown): string | null => {
  if (!v) return null;
  const d = v instanceof Date ? v : new Date(String(v));
  return Number.isFinite(d.getTime()) ? d.toISOString().slice(0, 10) : null;
};
const txt = (v: unknown): string | null => {
  const s = String(v ?? '').trim();
  return s ? s : null;
};

/**
 * Branch InOut stock report — desktop `RP_LC_INOUT`.
 *
 * Desktop buttons:
 *   BtnSize   -> `RptDisplay = "Out"`, `BOOK_NAME IN ('OUTWORD')`, transfer column `TO_LC_CODE`.
 *   BtnDesign -> `RptDisplay = "In"`,  `BOOK_NAME IN ('INWORD')`, transfer column `FROM_LC_CODE`.
 *
 * The source SQL groups by transfer location, item type and voucher date. The WinForms grid then pivots
 * locations into dynamic columns. The web returns those grouped source rows directly so the same data is
 * visible on screen, CSV and Excel without generating a different set of columns for every branch list.
 */
export async function branchInoutReport(
  prisma: any,
  s: ReportScope,
  options: { mode?: unknown } = {},
): Promise<ListReport> {
  const mode: BranchInoutMode = options.mode === 'in' ? 'in' : 'out';
  const transferColumn = mode === 'in' ? 'a."FROM_LC_CODE"' : 'a."TO_LC_CODE"';
  const bookName = mode === 'in' ? 'INWORD' : 'OUTWORD';

  return withTenant(prisma, s.tenantId, async (tx: any) => {
    const params: unknown[] = [s.coCode, s.lcCode ?? ''];
    const where = [
      'a."CO_CODE"=$1',
      'a."LC_CODE"=$2',
      `a."BOOK_NAME" IN ('${bookName}')`,
    ];
    if (s.coYear) {
      params.push(s.coYear);
      where.push(`a."CO_YEAR"=$${params.length}`);
    }
    if (s.fromDate) {
      params.push(s.fromDate);
      where.push(`a."VCH_DATE">=$${params.length}::date`);
    }
    if (s.toDate) {
      params.push(s.toDate);
      where.push(`a."VCH_DATE"<=$${params.length}::date`);
    }
    const filterSql = applyFilters('branch-inout', s.filters, params);

    const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT ${transferColumn} AS "transferLocation",
              l."LC_NAME" AS "transferLocationName",
              b."IT_TYPE" AS "itemType",
              a."VCH_DATE" AS "vchDate",
              SUM(coalesce(a."ITM_PCS",0)) AS "pcs",
              SUM(coalesce(a."ITM_GWT",0)) AS "gwt"
         FROM "INOUT_DETL" a
         LEFT JOIN "ITEM_MAST" b
           ON b.tenant_id=a.tenant_id
          AND b."CO_CODE"=a."CO_CODE"
          AND b."IT_CODE"::text=a."IT_CODE"::text
         LEFT JOIN "LOCT_MAST" l
           ON l.tenant_id=a.tenant_id
          AND l."CO_CODE"=a."CO_CODE"
          AND l."LC_CODE"::text=${transferColumn}::text
        WHERE ${where.join(' AND ')}${filterSql}
        GROUP BY ${transferColumn}, l."LC_NAME", b."IT_TYPE", a."VCH_DATE"
        ORDER BY a."VCH_DATE", ${transferColumn}, b."IT_TYPE"`,
      ...params,
    );

    const mapped = rows.map((r, index) => ({
      srNo: index + 1,
      direction: mode === 'in' ? 'Inword' : 'Outword',
      vchDate: isoDate(r.vchDate),
      transferLocation: txt(r.transferLocation),
      transferLocationName: txt(r.transferLocationName),
      itemType: txt(r.itemType),
      pcs: round3(num(r.pcs)),
      gwt: round3(num(r.gwt)),
    }));

    return {
      rows: mapped,
      totals: {
        rows: mapped.length,
        locations: new Set(mapped.map((r) => r.transferLocation).filter(Boolean)).size,
        pcs: round3(mapped.reduce((sum, r) => sum + r.pcs, 0)),
        gwt: round3(mapped.reduce((sum, r) => sum + r.gwt, 0)),
      },
    };
  });
}
