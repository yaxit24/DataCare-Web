import { round } from '@datacare/core';
import { withTxBudget } from '../shared/txBudget.js';
import { applyFilters } from './reportFilters.js';
import type { ListReport, ReportScope } from './reports.js';

export type OtherItemMode =
  'stud-in' | 'stud-out' | 'stud-inout' | 'loose-in' | 'loose-out' | 'loose-inout';

const MODES = new Set<OtherItemMode>([
  'stud-in',
  'stud-out',
  'stud-inout',
  'loose-in',
  'loose-out',
  'loose-inout',
]);
const num = (v: unknown): number => {
  const n = Number(v ?? 0);
  return Number.isFinite(n) ? n : 0;
};
// Report display rounding (N57 exact until output); desktop presents half-up, kernel `round` (N48, G22).
const round3 = (n: number): number => round(n, 3);
const round2 = (n: number): number => round(n, 2);
const txt = (v: unknown): string | null => {
  const s = String(v ?? '').trim();
  return s ? s : null;
};
const isoDate = (v: unknown): string | null => {
  if (!v) return null;
  const d = v instanceof Date ? v : new Date(String(v));
  return Number.isFinite(d.getTime()) ? d.toISOString().slice(0, 10) : null;
};

function modeFrom(value: unknown): OtherItemMode {
  const s = String(value ?? '').trim() as OtherItemMode;
  return MODES.has(s) ? s : 'stud-inout';
}

/**
 * Other item detail report — desktop `RP_OTH_DETL`, menu caption `Oth Itm Rpt`.
 *
 * The desktop exposes six report buttons against `DM_DATA`:
 *   Stud Itm In/Out/InOut  -> `ENTRY_TYPE='S'`, optional `DM_SIGN` +/-.
 *   Loose Itm In/Out/InOut -> `ENTRY_TYPE='L'`, optional `DM_SIGN` +/-.
 *
 * Filters are copied from the Crystal formulas: company/year/date, optional location, book, account,
 * party city/area, item type/product/group, and the form-specific item code (`ITEM_MAST.IT_CODE`). The
 * employee and state controls are present in the form but are not referenced by these formulas, so they are
 * intentionally not advertised as supported filters.
 */
export async function otherItemReport(
  prisma: any,
  s: ReportScope,
  options: { mode?: unknown; itemCode?: unknown } = {},
): Promise<ListReport> {
  const mode = modeFrom(options.mode);
  const entryType = mode.startsWith('loose') ? 'L' : 'S';
  const sign = mode.endsWith('-in') ? '+' : mode.endsWith('-out') ? '-' : '';
  const itemCode = String(options.itemCode ?? '').trim();

  return withTxBudget(prisma, s.tenantId, 'read', async (tx: any) => {
    const params: unknown[] = [s.coCode, entryType];
    const where = ['d."CO_CODE"=$1', 'd."ENTRY_TYPE"=$2'];
    if (s.coYear) {
      params.push(s.coYear);
      where.push(`d."CO_YEAR"=$${params.length}`);
    }
    if (sign) {
      params.push(sign);
      where.push(`d."DM_SIGN"=$${params.length}`);
    }
    if (s.fromDate) {
      params.push(s.fromDate);
      where.push(`d."VCH_DATE">=$${params.length}::date`);
    }
    if (s.toDate) {
      params.push(s.toDate);
      where.push(`d."VCH_DATE"<=$${params.length}::date`);
    }
    const filterSql = applyFilters('other-item-report', s.filters, params);
    if (itemCode) {
      params.push(itemCode);
      where.push(`i."IT_CODE"=$${params.length}`);
    }

    const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT d."VCH_DATE" AS "vchDate", d."CO_BOOK" AS "coBook", d."BOOK_NAME" AS "bookName",
              d."VCH_NO" AS "vchNo", d."MAIN_SRNO" AS "mainSrNo", d."SR_NO" AS "srNo",
              d."ISR_NO" AS "isrNo", d."AC_CODE" AS "acCode", a."AC_NAME" AS "party",
              d."IT_CODE" AS "itCode", i."IT_NAME" AS "itemName", i."IT_TYPE" AS "itemType",
              i."PR_CODE" AS "productCode", i."GR_CODE" AS "groupCode", d."DM_CODE" AS "dmCode",
              d."DM_ORIGIN" AS "origin", d."DM_REMARK" AS "remark", d."DM_SIZE" AS "size",
              d."DM_COLOR" AS "color", d."DM_LOT_NO" AS "lotNo", d."DM_SIGN" AS "sign",
              d."DM_PCS" AS "pcs", d."DM_WT" AS "weight", d."DM_RATE" AS "rate",
              d."DM_AMT" AS "amount", d."EMP_CODE" AS "empCode", d."TAG_NO" AS "tagNo",
              d."VCH_SRNO" AS "tagSrNo", d."MAIN_IT_CODE" AS "mainItemCode"
         FROM "DM_DATA" d
         LEFT JOIN "ITEM_MAST" i
           ON i.tenant_id=d.tenant_id
          AND i."CO_CODE"=d."CO_CODE"
          AND i."IT_CODE"::text=d."IT_CODE"::text
         LEFT JOIN "AC_MAST" a
           ON a.tenant_id=d.tenant_id
          AND a."CO_CODE"=d."CO_CODE"
          AND a."AC_CODE"::text=d."AC_CODE"::text
        WHERE ${where.join(' AND ')}${filterSql}
        ORDER BY d."VCH_DATE", d."CO_BOOK", d."VCH_NO", d."MAIN_SRNO", d."SR_NO", d."ISR_NO"`,
      ...params,
    );

    const mapped = rows.map((r, index) => ({
      srNo: index + 1,
      mode,
      entryType: entryType === 'S' ? 'Stud' : 'Loose',
      direction: r.sign === '+' ? 'In' : r.sign === '-' ? 'Out' : null,
      vchDate: isoDate(r.vchDate),
      coBook: txt(r.coBook),
      bookName: txt(r.bookName),
      vchNo: txt(r.vchNo),
      mainSrNo: num(r.mainSrNo),
      lineSrNo: num(r.srNo),
      subSrNo: num(r.isrNo),
      acCode: txt(r.acCode),
      party: txt(r.party),
      itCode: txt(r.itCode),
      itemName: txt(r.itemName),
      itemType: txt(r.itemType),
      productCode: txt(r.productCode),
      groupCode: txt(r.groupCode),
      dmCode: txt(r.dmCode),
      origin: txt(r.origin),
      remark: txt(r.remark),
      size: txt(r.size),
      color: txt(r.color),
      lotNo: txt(r.lotNo),
      pcs: round3(num(r.pcs)),
      weight: round3(num(r.weight)),
      rate: round2(num(r.rate)),
      amount: round2(num(r.amount)),
      empCode: txt(r.empCode),
      tagNo: txt(r.tagNo),
      tagSrNo: num(r.tagSrNo),
      mainItemCode: txt(r.mainItemCode),
    }));

    return {
      rows: mapped,
      totals: {
        rows: mapped.length,
        pcs: round3(mapped.reduce((sum, r) => sum + r.pcs, 0)),
        weight: round3(mapped.reduce((sum, r) => sum + r.weight, 0)),
        amount: round2(mapped.reduce((sum, r) => sum + r.amount, 0)),
      },
    };
  });
}
