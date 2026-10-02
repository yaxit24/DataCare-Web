import { round } from '@datacare/core';
import { withTxBudget } from '../shared/txBudget.js';
import { applyFilters } from './reportFilters.js';
import type { ListReport, ReportScope } from './reports.js';

export type TourStatus = 'pending' | 'sales' | 'return' | 'all';
export type TourReportMode = 'voucher' | 'item-wise';

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
const todayIso = (): string => new Date().toISOString().slice(0, 10);

function statusFrom(v: unknown): TourStatus {
  const s = String(v ?? '')
    .trim()
    .toLowerCase();
  if (s === 'sales' || s === 'sale' || s === 'sold') return 'sales';
  if (s === 'return' || s === 'returned' || s === 'received') return 'return';
  if (s === 'all') return 'all';
  return 'pending';
}

function modeFrom(v: unknown): TourReportMode {
  const s = String(v ?? '')
    .trim()
    .toLowerCase();
  return s === 'item-wise' || s === 'item' || s === 'item-stock' ? 'item-wise' : 'voucher';
}

function flagFrom(v: unknown, defaultValue: boolean): boolean {
  if (v == null || v === '') return defaultValue;
  const s = String(v).trim().toLowerCase();
  if (['0', 'false', 'n', 'no', 'off'].includes(s)) return false;
  if (['1', 'true', 'y', 'yes', 'on'].includes(s)) return true;
  return defaultValue;
}

function pushText(params: unknown[], where: string[], expr: string, value: unknown): void {
  const s = String(value ?? '').trim();
  if (!s) return;
  params.push(s);
  where.push(`${expr}=$${params.length}`);
}

function statusWhere(status: TourStatus): string {
  if (status === 'sales') return `a."EMP_SALE"='Y'`;
  if (status === 'return') return `a."ISU_REC"='Y' AND a."EMP_SALE"='N'`;
  if (status === 'pending') return `a."EMP_SALE"='N' AND a."ISU_REC"='N'`;
  return '';
}

function totals(
  rows: Array<Record<string, unknown>>,
  cols: readonly string[],
): Record<string, number> {
  return Object.fromEntries(
    cols.map((col) => [col, round3(rows.reduce((sum, row) => sum + num(row[col]), 0))]),
  );
}

/**
 * Tour Report — desktop `RP_TOUR_ZOOM`, `CurRpt != "Tour Tag"`.
 *
 * The default grid is `DGV_TOUR_FILL`: employee-issue vouchers from `APR_DETL`, joined to linked
 * `RATE_CUT_ISU` sale rows and linked `EMP REC` approval-return rows, with the desktop status combo:
 * Panding, Sales, Return, All. The alternate `chkItmStk` grid is `Item_Wise_Tour_Stk`: employee-wise
 * opening/issue/sale/return/pending stock for non-tag (`TAG_NO = 'N'`) tour rows.
 */
export async function tourReport(
  prisma: any,
  s: ReportScope,
  options: { mode?: unknown; status?: unknown; employeeCode?: unknown; onlyTagged?: unknown } = {},
): Promise<ListReport> {
  const mode = modeFrom(options.mode);
  return mode === 'item-wise'
    ? tourItemWiseReport(prisma, s, options)
    : tourVoucherReport(prisma, s, options);
}

async function tourVoucherReport(
  prisma: any,
  s: ReportScope,
  options: { status?: unknown; employeeCode?: unknown; onlyTagged?: unknown },
): Promise<ListReport> {
  const fromDate = s.fromDate ?? '2020-01-01';
  const toDate = s.toDate ?? todayIso();
  const status = statusFrom(options.status);
  const onlyTagged = flagFrom(options.onlyTagged, true);

  return withTxBudget(prisma, s.tenantId, 'read', async (tx: any) => {
    const params: unknown[] = [s.coCode, s.lcCode ?? '', fromDate, toDate];
    const where = [
      'a."CO_CODE"=$1',
      'a."LC_CODE"=$2',
      `a."BOOK_NAME"='EMP ISU'`,
      'a."VCH_DATE">=$3::date',
      'a."VCH_DATE"<=$4::date',
    ];
    pushText(params, where, 'a."AC_CODE"', options.employeeCode);
    if (onlyTagged) where.push(`coalesce(a."TAG_NO",'') <> 'N'`);
    const statusSql = statusWhere(status);
    if (statusSql) where.push(statusSql);
    const filterSql = applyFilters('tour-report', s.filters, params);

    const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT ROW_NUMBER() OVER (ORDER BY a."VCH_DATE", a."VCH_NO") AS "srNo",
              a."VCH_TYPE" AS "book",
              a."VCH_DATE" AS "vchDate",
              a."VCH_NO" AS "vchNo",
              a."AC_CODE" AS "empCode",
              f."EMP_NAME" AS "empName",
              SUM(coalesce(a."ITM_GWT",0)) AS "isuWt",
              SUM(coalesce(a."ITM_PCS",0)) AS "isuPcs",
              SUM(coalesce(b."ITM_PCS",0)) AS "salePcs",
              SUM(coalesce(e."ITM_PCS",0)) AS "recPcs",
              SUM(coalesce(a."ITM_PCS",0)) - SUM(coalesce(b."ITM_PCS",0)) - SUM(coalesce(e."ITM_PCS",0)) AS "panPcs",
              SUM(coalesce(a."ITM_GWT",0)) - SUM(coalesce(b."ITM_GWT",0)) - SUM(coalesce(e."ITM_GWT",0)) AS "panWt"
         FROM "APR_DETL" a
         LEFT JOIN "RATE_CUT_ISU" b
           ON b.tenant_id=a.tenant_id
          AND b."CO_CODE"=a."CO_CODE"
          AND b."LC_CODE"=a."LC_CODE"
          AND b."CO_YEAR"=a."ISU_YRCD"
          AND b."CO_BOOK"=a."ISU_DBCD"
          AND b."VCH_NO"=a."ISU_NO"
          AND b."OLD_SRNO"=a."ISU_SRNO"
          AND coalesce(b."TAG_NO",'') <> 'N'
         LEFT JOIN "APR_DETL" e
           ON e.tenant_id=a.tenant_id
          AND e."CO_CODE"=a."CO_CODE"
          AND e."LC_CODE"=a."LC_CODE"
          AND e."CO_YEAR"=a."ISU_YRCD"
          AND e."CO_BOOK"=a."ISU_DBCD"
          AND e."VCH_NO"=a."ISU_NO"
          AND e."OLD_SRNO"=a."ISU_SRNO"
          AND coalesce(e."TAG_NO",'') <> 'N'
          AND e."BOOK_NAME"='EMP REC'
         LEFT JOIN "EMP_MAST" f
           ON f.tenant_id=a.tenant_id
          AND f."CO_CODE"=a."CO_CODE"
          AND f."EMP_CODE"=a."AC_CODE"
         LEFT JOIN "ITEM_MAST" g
           ON g.tenant_id=a.tenant_id
          AND g."CO_CODE"=a."CO_CODE"
          AND g."IT_CODE"::text=a."IT_CODE"::text
        WHERE ${where.join(' AND ')}${filterSql}
        GROUP BY a."VCH_TYPE", a."VCH_DATE", a."VCH_NO", a."AC_CODE", f."EMP_NAME"
        ORDER BY a."VCH_DATE", a."VCH_NO"`,
      ...params,
    );

    const mapped = rows.map((r, index) => ({
      srNo: index + 1,
      book: txt(r.book),
      vchDate: isoDate(r.vchDate),
      vchNo: txt(r.vchNo),
      empCode: txt(r.empCode),
      empName: txt(r.empName),
      isuWt: round3(num(r.isuWt)),
      isuPcs: round3(num(r.isuPcs)),
      salePcs: round3(num(r.salePcs)),
      recPcs: round3(num(r.recPcs)),
      panPcs: round3(num(r.panPcs)),
      panWt: round3(num(r.panWt)),
    }));
    return {
      rows: mapped,
      totals: {
        rows: mapped.length,
        ...totals(mapped, ['isuWt', 'isuPcs', 'salePcs', 'recPcs', 'panPcs', 'panWt']),
      },
    };
  });
}

async function tourItemWiseReport(
  prisma: any,
  s: ReportScope,
  options: { employeeCode?: unknown },
): Promise<ListReport> {
  const fromDate = s.fromDate ?? '2020-01-01';
  const toDate = s.toDate ?? todayIso();

  return withTxBudget(prisma, s.tenantId, 'read', async (tx: any) => {
    const params: unknown[] = [s.coCode, s.lcCode ?? '', s.coYear ?? '', fromDate, toDate];
    const where = [
      'a."CO_CODE"=$1',
      'a."LC_CODE"=$2',
      'a."CO_YEAR"=$3',
      `a."BOOK_NAME" IN ('EMP ISU','TOUR SALES','EMP REC')`,
      `coalesce(a."TAG_NO",'') = 'N'`,
    ];
    pushText(params, where, 'a."EMP_CODE"', options.employeeCode);
    const filterSql = applyFilters('tour-report', s.filters, params);

    const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT ROW_NUMBER() OVER (ORDER BY a."EMP_CODE", b."EMP_NAME") AS "srNo",
              a."EMP_CODE" AS "code",
              b."EMP_NAME" AS "name",
              SUM(CASE WHEN a."VCH_DATE" < $4::date THEN CASE WHEN a."BOOK_NAME"='EMP ISU' THEN coalesce(a."ITM_PCS",0) ELSE -coalesce(a."ITM_PCS",0) END ELSE 0 END) AS "opPcs",
              SUM(CASE WHEN a."VCH_DATE" < $4::date THEN CASE WHEN a."BOOK_NAME"='EMP ISU' THEN coalesce(a."ITM_GWT",0) ELSE -coalesce(a."ITM_GWT",0) END ELSE 0 END) AS "opWt",
              SUM(CASE WHEN a."VCH_DATE" >= $4::date AND a."VCH_DATE" <= $5::date THEN CASE WHEN a."BOOK_NAME"='EMP ISU' THEN coalesce(a."ITM_PCS",0) ELSE 0 END ELSE 0 END) AS "isuPcs",
              SUM(CASE WHEN a."VCH_DATE" >= $4::date AND a."VCH_DATE" <= $5::date THEN CASE WHEN a."BOOK_NAME"='EMP ISU' THEN coalesce(a."ITM_GWT",0) ELSE 0 END ELSE 0 END) AS "isuWt",
              SUM(CASE WHEN a."VCH_DATE" >= $4::date AND a."VCH_DATE" <= $5::date THEN CASE WHEN a."BOOK_NAME"='TOUR SALES' THEN coalesce(a."ITM_PCS",0) ELSE 0 END ELSE 0 END) AS "salePcs",
              SUM(CASE WHEN a."VCH_DATE" >= $4::date AND a."VCH_DATE" <= $5::date THEN CASE WHEN a."BOOK_NAME"='TOUR SALES' THEN coalesce(a."ITM_GWT",0) ELSE 0 END ELSE 0 END) AS "saleWt",
              SUM(CASE WHEN a."VCH_DATE" >= $4::date AND a."VCH_DATE" <= $5::date THEN CASE WHEN a."BOOK_NAME"='EMP REC' THEN coalesce(a."ITM_PCS",0) ELSE 0 END ELSE 0 END) AS "recPcs",
              SUM(CASE WHEN a."VCH_DATE" >= $4::date AND a."VCH_DATE" <= $5::date THEN CASE WHEN a."BOOK_NAME"='EMP REC' THEN coalesce(a."ITM_GWT",0) ELSE 0 END ELSE 0 END) AS "recWt",
              SUM(CASE WHEN a."VCH_DATE" <= $5::date THEN CASE WHEN a."BOOK_NAME"='EMP ISU' THEN coalesce(a."ITM_PCS",0) ELSE -coalesce(a."ITM_PCS",0) END ELSE 0 END) AS "panPcs",
              SUM(CASE WHEN a."VCH_DATE" <= $5::date THEN CASE WHEN a."BOOK_NAME"='EMP ISU' THEN coalesce(a."ITM_GWT",0) ELSE -coalesce(a."ITM_GWT",0) END ELSE 0 END) AS "panWt"
         FROM "APR_DETL" a
         LEFT JOIN "EMP_MAST" b
           ON b.tenant_id=a.tenant_id
          AND b."CO_CODE"=a."CO_CODE"
          AND b."EMP_CODE"=a."EMP_CODE"
         LEFT JOIN "ITEM_MAST" g
           ON g.tenant_id=a.tenant_id
          AND g."CO_CODE"=a."CO_CODE"
          AND g."IT_CODE"::text=a."IT_CODE"::text
        WHERE ${where.join(' AND ')}${filterSql}
        GROUP BY a."EMP_CODE", b."EMP_NAME"
        ORDER BY a."EMP_CODE"`,
      ...params,
    );

    const mapped = rows.map((r, index) => ({
      srNo: index + 1,
      code: txt(r.code),
      name: txt(r.name),
      opPcs: round3(num(r.opPcs)),
      opWt: round3(num(r.opWt)),
      isuPcs: round3(num(r.isuPcs)),
      isuWt: round3(num(r.isuWt)),
      salePcs: round3(num(r.salePcs)),
      saleWt: round3(num(r.saleWt)),
      recPcs: round3(num(r.recPcs)),
      recWt: round3(num(r.recWt)),
      panPcs: round3(num(r.panPcs)),
      panWt: round3(num(r.panWt)),
    }));
    return {
      rows: mapped,
      totals: {
        rows: mapped.length,
        ...totals(mapped, [
          'opPcs',
          'opWt',
          'isuPcs',
          'isuWt',
          'salePcs',
          'saleWt',
          'recPcs',
          'recWt',
          'panPcs',
          'panWt',
        ]),
      },
    };
  });
}

/**
 * Tour Tag — desktop `RP_TOUR_ZOOM`, `CurRpt == "Tour Tag"`, `Tour_Tag_Detl`.
 *
 * Anchors on employee issue rows and displays the linked sale adjustment or employee-return voucher beside
 * each tag. The pending columns are calculated exactly like the WinForms grid: issue minus sale minus return.
 */
export async function tourTagReport(
  prisma: any,
  s: ReportScope,
  options: {
    status?: unknown;
    employeeCode?: unknown;
    onlyTagged?: unknown;
    tagNo?: unknown;
    issueYear?: unknown;
    issueBook?: unknown;
    issueNo?: unknown;
  } = {},
): Promise<ListReport> {
  const toDate = s.toDate ?? todayIso();
  const status = statusFrom(options.status);
  const onlyTagged = flagFrom(options.onlyTagged, true);

  return withTxBudget(prisma, s.tenantId, 'read', async (tx: any) => {
    const params: unknown[] = [s.coCode, s.lcCode ?? '', toDate];
    const where = [
      'a."CO_CODE"=$1',
      'a."LC_CODE"=$2',
      `a."BOOK_NAME"='EMP ISU'`,
      'a."VCH_DATE" <= $3::date',
    ];
    pushText(params, where, 'a."AC_CODE"', options.employeeCode);
    if (onlyTagged) where.push(`coalesce(a."TAG_NO",'') <> 'N'`);
    const statusSql = statusWhere(status);
    if (statusSql) where.push(statusSql);
    const issueNo = String(options.issueNo ?? '').trim();
    if (issueNo) {
      pushText(params, where, 'a."CO_YEAR"', options.issueYear);
      pushText(params, where, 'a."CO_BOOK"', options.issueBook);
      pushText(params, where, 'a."VCH_NO"', issueNo);
    }
    pushText(params, where, 'a."TAG_NO"', options.tagNo);
    const filterSql = applyFilters('tour-tag', s.filters, params);

    const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT a."VCH_TYPE" AS "isuType",
              a."VCH_DATE" AS "isuDate",
              a."VCH_NO" AS "isuNo",
              a."TAG_NO" AS "tagNo",
              a."ITM_PCS" AS "iPcs",
              a."ITM_GWT" AS "iGrWt",
              a."ITM_NWT" AS "iNetWt",
              a."CO_BOOK" AS "isuBook",
              a."ISU_DBCD" AS "adjBookCode",
              a."AC_CODE" AS "emp",
              b."VCH_NO" AS "slVch",
              b."VCH_DATE" AS "slDate",
              b."ITM_PCS" AS "slPcs",
              b."ITM_GWT" AS "slGrWt",
              b."ITM_NWT" AS "slNetWt",
              c."AC_NAME" AS "slParty",
              d."BOOK_NAME" AS "slType",
              e."VCH_NO" AS "rcVch",
              e."VCH_DATE" AS "rcDate",
              e."ITM_PCS" AS "rcPcs",
              e."ITM_GWT" AS "rcGrWt",
              e."ITM_NWT" AS "rcNetWt",
              f."EMP_NAME" AS "empName"
         FROM "APR_DETL" a
         LEFT JOIN "RATE_CUT_ISU" b
           ON b.tenant_id=a.tenant_id
          AND b."CO_CODE"=a."CO_CODE"
          AND b."LC_CODE"=a."LC_CODE"
          AND b."CO_YEAR"=a."ISU_YRCD"
          AND b."CO_BOOK"=a."ISU_DBCD"
          AND b."VCH_NO"=a."ISU_NO"
          AND b."OLD_SRNO"=a."ISU_SRNO"
          AND coalesce(b."TAG_NO",'') <> 'N'
         LEFT JOIN "AC_MAST" c
           ON c.tenant_id=b.tenant_id
          AND c."CO_CODE"=b."CO_CODE"
          AND c."AC_CODE"=b."AC_CODE"
         LEFT JOIN "BOOK_DATA" d
           ON d.tenant_id=b.tenant_id
          AND d."CO_CODE"=b."CO_CODE"
          AND d."LC_CODE"=b."LC_CODE"
          AND d."CO_BOOK"=b."CO_BOOK"
         LEFT JOIN "APR_DETL" e
           ON e.tenant_id=a.tenant_id
          AND e."CO_CODE"=a."CO_CODE"
          AND e."LC_CODE"=a."LC_CODE"
          AND e."CO_YEAR"=a."ISU_YRCD"
          AND e."CO_BOOK"=a."ISU_DBCD"
          AND e."VCH_NO"=a."ISU_NO"
          AND e."OLD_SRNO"=a."ISU_SRNO"
          AND coalesce(e."TAG_NO",'') <> 'N'
         LEFT JOIN "EMP_MAST" f
           ON f.tenant_id=a.tenant_id
          AND f."CO_CODE"=a."CO_CODE"
          AND f."EMP_CODE"=a."AC_CODE"
         LEFT JOIN "ITEM_MAST" g
           ON g.tenant_id=a.tenant_id
          AND g."CO_CODE"=a."CO_CODE"
          AND g."IT_CODE"::text=a."IT_CODE"::text
        WHERE ${where.join(' AND ')}${filterSql}
        ORDER BY a."VCH_NO"`,
      ...params,
    );

    const mapped = rows.map((r, index) => {
      const adjBookCode = String(r.adjBookCode ?? '').trim();
      const salePcs = adjBookCode && adjBookCode !== '505' ? round3(num(r.slPcs)) : 0;
      const saleWt = adjBookCode && adjBookCode !== '505' ? round3(num(r.slGrWt)) : 0;
      const recPcs = adjBookCode === '505' ? round3(num(r.rcPcs)) : 0;
      const recWt = adjBookCode === '505' ? round3(num(r.rcGrWt)) : 0;
      const issuePcs = round3(num(r.iPcs));
      const issueWt = round3(num(r.iGrWt));
      return {
        srNo: index + 1,
        tagNo: txt(r.tagNo),
        isuDate: isoDate(r.isuDate),
        isuType: txt(r.isuType),
        isuNo: txt(r.isuNo),
        empName: txt(r.empName),
        iPcs: issuePcs,
        iGrWt: issueWt,
        sPcs: salePcs,
        slGrWt: saleWt,
        rPcs: recPcs,
        rcGrWt: recWt,
        pPcs: round3(issuePcs - salePcs - recPcs),
        pGrWt: round3(issueWt - saleWt - recWt),
        slParty: adjBookCode && adjBookCode !== '505' ? txt(r.slParty) : null,
        slType: adjBookCode && adjBookCode !== '505' ? txt(r.slType) : null,
        slDate: adjBookCode && adjBookCode !== '505' ? isoDate(r.slDate) : null,
        slVch: adjBookCode && adjBookCode !== '505' ? txt(r.slVch) : null,
        rcDate: adjBookCode === '505' ? isoDate(r.rcDate) : null,
        rcVch: adjBookCode === '505' ? txt(r.rcVch) : null,
        emp: txt(r.emp),
        isuBook: txt(r.isuBook),
        adjBook: txt(r.adjBookCode),
      };
    });

    return {
      rows: mapped,
      totals: {
        rows: mapped.length,
        ...totals(mapped, ['iPcs', 'iGrWt', 'sPcs', 'slGrWt', 'rPcs', 'rcGrWt', 'pPcs', 'pGrWt']),
      },
    };
  });
}
