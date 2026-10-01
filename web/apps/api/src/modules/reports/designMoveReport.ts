import { round } from '@datacare/core';
import { withTenant } from '@datacare/db';
import { applyFilters } from './reportFilters.js';
import type { ListReport, ReportScope } from './reports.js';

export type DesignMoveMode = 'design' | 'item';

const num = (v: unknown): number => {
  const n = Number(v ?? 0);
  return Number.isFinite(n) ? n : 0;
};
// Report display rounding (N57 exact until output); desktop presents half-up, kernel `round` (N48, G22).
const round3 = (n: number): number => round(n, 3);
const txt = (v: unknown): string | null => {
  const s = String(v ?? '').trim();
  return s ? s : null;
};
const isoDate = (v: unknown): string | null => {
  if (!v) return null;
  const d = v instanceof Date ? v : new Date(String(v));
  return Number.isFinite(d.getTime()) ? d.toISOString().slice(0, 10) : null;
};
const modeFrom = (v: unknown): DesignMoveMode =>
  String(v ?? '').trim() === 'item' ? 'item' : 'design';

function scopeWhere(s: ReportScope, params: unknown[]): string[] {
  const where = [
    'a."CO_CODE"=$1',
    'a."LC_CODE"=$2',
    'a."CO_YEAR"=$3',
    `coalesce(a."TAG_NO",'') <> 'N'`,
  ];
  const toDate = s.toDate ?? new Date().toISOString().slice(0, 10);
  params.push(toDate);
  where.push(`a."VCH_DATE" <= $${params.length}::date`);
  return where;
}

/**
 * Design/item size movement — desktop `RP_STK_MOVE`, menu caption misspelled as `Deisgn Move`.
 *
 * Buttons:
 *   Design / Size -> group by BAR_DETL.DESIGN_NO + ITM_SIZE.
 *   Item / Size   -> group by BAR_DETL.IT_CODE + ITEM_MAST.IT_NAME + ITM_SIZE.
 *
 * Both keep only sizes with positive signed movement and use piece-count signs (`+` = 1, everything else = -1),
 * not the item piece quantity. That oddity is copied from the desktop query because it answers “how many tag
 * instances of this size/design remain”, not “sum stock pieces”.
 */
export async function designMoveReport(
  prisma: any,
  s: ReportScope,
  options: { mode?: unknown; tagNo?: unknown; designNo?: unknown } = {},
): Promise<ListReport> {
  const mode = modeFrom(options.mode);
  const tagNo = String(options.tagNo ?? '').trim();
  const designNo = String(options.designNo ?? '').trim();
  return withTenant(prisma, s.tenantId, async (tx: any) => {
    const params: unknown[] = [s.coCode, s.lcCode ?? '', s.coYear ?? ''];
    const where = scopeWhere(s, params);
    if (tagNo) {
      params.push(tagNo);
      where.push(`a."TAG_NO"=$${params.length}`);
    }
    if (designNo) {
      params.push(designNo);
      where.push(`b."DESIGN_NO"=$${params.length}`);
    }
    const filterSql = applyFilters('design-move', s.filters, params);
    const keyExpr = mode === 'item' ? 'b."IT_CODE"' : 'b."DESIGN_NO"';
    const nameExpr = mode === 'item' ? 'c."IT_NAME"' : 'b."DESIGN_NO"';
    const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT ${keyExpr} AS "key", ${nameExpr} AS "name", b."ITM_SIZE" AS "size",
              SUM(CASE WHEN a."ITM_SIGN"='+' THEN 1 ELSE -1 END) AS "pcs"
         FROM "MAIN_STOCK" a
         LEFT JOIN "BAR_DETL" b
           ON b.tenant_id=a.tenant_id
          AND b."CO_CODE"=a."CO_CODE"
          AND b."TAG_NO"=a."TAG_NO"
          AND b."VCH_SRNO"=a."VCH_SRNO"
         LEFT JOIN "ITEM_MAST" c
           ON c.tenant_id=a.tenant_id
          AND c."CO_CODE"=a."CO_CODE"
          AND c."IT_CODE"::text=a."IT_CODE"::text
        WHERE ${where.join(' AND ')}${filterSql}
        GROUP BY ${keyExpr}, ${nameExpr}, b."ITM_SIZE"
        HAVING SUM(CASE WHEN a."ITM_SIGN"='+' THEN 1 ELSE -1 END) > 0
        ORDER BY ${nameExpr}, ${keyExpr}, b."ITM_SIZE"`,
      ...params,
    );
    const mapped = rows.map((r, index) => ({
      srNo: index + 1,
      mode,
      key: txt(r.key),
      name: txt(r.name),
      size: txt(r.size),
      pcs: round3(num(r.pcs)),
    }));
    return {
      rows: mapped,
      totals: {
        rows: mapped.length,
        sizes: new Set(mapped.map((r) => r.size).filter(Boolean)).size,
        pcs: round3(mapped.reduce((sum, r) => sum + r.pcs, 0)),
      },
    };
  });
}

/** Desktop double-click detail for one summary key+size. */
export async function designMoveDetailReport(
  prisma: any,
  s: ReportScope,
  options: { mode?: unknown; key?: unknown; size?: unknown; designNo?: unknown } = {},
): Promise<ListReport> {
  const mode = modeFrom(options.mode);
  const key = String(options.key ?? '').trim();
  const size = String(options.size ?? '').trim();
  const designNo = String(options.designNo ?? '').trim();
  if (!key || !size) return { rows: [], totals: { rows: 0 } };

  return withTenant(prisma, s.tenantId, async (tx: any) => {
    const params: unknown[] = [s.coCode, s.lcCode ?? '', s.coYear ?? ''];
    const where = scopeWhere(s, params);
    params.push(key);
    where.push(
      mode === 'item' ? `c."IT_CODE"=$${params.length}` : `f."DESIGN_NO"=$${params.length}`,
    );
    params.push(size);
    where.push(`f."ITM_SIZE"=$${params.length}`);
    if (mode === 'item' && designNo) {
      params.push(designNo);
      where.push(`f."DESIGN_NO"=$${params.length}`);
    }
    const filterSql = applyFilters('design-move', s.filters, params);
    const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT b."BOOK_SNAME" AS "book", e."AC_NAME" AS "party", f."VCH_NO" AS "vchNo",
              f."VCH_DATE" AS "vchDate", f."TAG_NO" AS "tagNo", c."IT_NAME" AS "itemName",
              f."ITM_PCS" AS "pcs", f."ITM_GWT" AS "gwt", f."ITM_NWT" AS "nwt",
              f."KR_FINE" AS "itemFine", f."CO_BOOK" AS "coBook", b."MAIN_BOOK" AS "mainBook",
              f."IT_CODE" AS "itCode", f."AC_CODE" AS "acCode", f."DESIGN_NO" AS "designNo",
              f."ITM_SIZE" AS "size"
         FROM "MAIN_STOCK" a
         LEFT JOIN "BAR_DETL" f
           ON f.tenant_id=a.tenant_id
          AND f."CO_CODE"=a."CO_CODE"
          AND f."LC_CODE"=a."LC_CODE"
          AND f."TAG_NO"=a."TAG_NO"
          AND f."VCH_SRNO"=a."VCH_SRNO"
         LEFT JOIN "BOOK_DATA" b
           ON b.tenant_id=f.tenant_id
          AND b."CO_CODE"=f."CO_CODE"
          AND b."LC_CODE"=f."LC_CODE"
          AND b."CO_BOOK"=f."CO_BOOK"
         LEFT JOIN "ITEM_MAST" c
           ON c.tenant_id=a.tenant_id
          AND c."CO_CODE"=a."CO_CODE"
          AND c."IT_CODE"::text=a."IT_CODE"::text
         LEFT JOIN "AC_MAST" e
           ON e.tenant_id=f.tenant_id
          AND e."CO_CODE"=f."CO_CODE"
          AND e."AC_CODE"::text=f."AC_CODE"::text
        WHERE ${where.join(' AND ')}${filterSql}
        GROUP BY b."BOOK_SNAME", e."AC_NAME", f."VCH_NO", f."VCH_DATE", f."TAG_NO", c."IT_NAME",
                 f."ITM_PCS", f."ITM_GWT", f."ITM_NWT", f."KR_FINE", f."CO_BOOK", b."MAIN_BOOK",
                 f."IT_CODE", f."AC_CODE", f."DESIGN_NO", f."ITM_SIZE"
        HAVING SUM(CASE WHEN a."ITM_SIGN"='+' THEN coalesce(a."VCH_SRNO",0) ELSE -coalesce(a."VCH_SRNO",0) END) > 0
        ORDER BY f."VCH_DATE", f."VCH_NO", f."TAG_NO"`,
      ...params,
    );
    const mapped = rows.map((r, index) => ({
      srNo: index + 1,
      book: txt(r.book),
      party: txt(r.party),
      vchNo: txt(r.vchNo),
      vchDate: isoDate(r.vchDate),
      tagNo: txt(r.tagNo),
      itemName: txt(r.itemName),
      designNo: txt(r.designNo),
      size: txt(r.size),
      pcs: round3(num(r.pcs)),
      gwt: round3(num(r.gwt)),
      nwt: round3(num(r.nwt)),
      itemFine: round3(num(r.itemFine)),
      coBook: txt(r.coBook),
      mainBook: txt(r.mainBook),
      itCode: txt(r.itCode),
      acCode: txt(r.acCode),
    }));
    return {
      rows: mapped,
      totals: {
        rows: mapped.length,
        pcs: round3(mapped.reduce((sum, r) => sum + r.pcs, 0)),
        gwt: round3(mapped.reduce((sum, r) => sum + r.gwt, 0)),
        nwt: round3(mapped.reduce((sum, r) => sum + r.nwt, 0)),
        itemFine: round3(mapped.reduce((sum, r) => sum + r.itemFine, 0)),
      },
    };
  });
}
