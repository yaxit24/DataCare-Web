import { withTenant } from '@datacare/db';
import { PRECISION, round } from '@datacare/core';
import type { ListReport, ReportScope } from './reports.js';

/**
 * Item weight-band labour levels (desktop `RP_STK_LEVEL`, menu caption "ItStk Level").
 *
 * WHAT THIS ACTUALLY IS — the name misleads, so it was checked before building. "Level" here is not a
 * reorder level: `ITM_WT_MAST` holds LABOUR RATES BANDED BY WEIGHT per item — FROM_WT, TO_WT, MIN_PCS,
 * LBR_TYPE, LBR_RATE, LBR_PRC, LBR_AMT, MIN_LBR_PRC, GHT_PRC and an optional IT_DESIGN. So the report
 * answers "which making charge applies to a piece of this weight", which is what an operator quoting a
 * price needs.
 *
 * The desktop's driving query is `SELECT A.*, B.IT_NAME, B.IT_TYPE FROM ITM_WT_MAST A LEFT JOIN
 * ITEM_MAST B`, and that shape is reproduced here rather than reinvented.
 *
 * The web already MAINTAINS this master (`masters/labourUpdate.ts`) but had no way to read it back as a
 * report, so the rates an operator is charging were only visible one row at a time in a master screen.
 *
 * Read-only and RLS-scoped.
 */
export interface StockLevelRow {
  itCode: string;
  itName: string | null;
  itType: string | null;
  srNo: number;
  /** The band this rate applies to: FROM_WT <= weight <= TO_WT. */
  fromWt: number;
  toWt: number;
  minPcs: number;
  /** Optional design restriction — a band can be design-specific. */
  design: string | null;
  labourType: string | null;
  labourCode: string | null;
  labourRate: number;
  labourPct: number;
  labourAmount: number;
  minLabourPct: number;
  ghatPct: number;
}

export interface StockLevelReport {
  rows: StockLevelRow[];
  totals: { count: number; items: number; bandedItems: number; designSpecific: number };
}

const txt = (v: unknown): string | null => {
  const s = String(v ?? '').trim();
  return s === '' ? null : s;
};
const num = (v: unknown): number => {
  const n = Number(v ?? 0);
  return Number.isFinite(n) ? n : 0;
};
const w3 = (n: number): number => round(n, PRECISION.weight);
const a2 = (n: number): number => round(n, PRECISION.amount);
const todayIso = (): string => new Date().toISOString().slice(0, 10);
const flagFrom = (v: unknown, defaultValue: boolean): boolean => {
  if (v == null || v === '') return defaultValue;
  const s = String(v).trim().toLowerCase();
  if (['1', 'true', 'y', 'yes', 'on'].includes(s)) return true;
  if (['0', 'false', 'n', 'no', 'off'].includes(s)) return false;
  return defaultValue;
};
const monthLabel = (year: number, month: number): string =>
  `${String(year).slice(-2)}/${String(month).padStart(2, '0')}`;

export async function stockLevelReport(
  prisma: any,
  tenantId: string,
  scope: { CO_CODE: string },
  options: { itCode?: string; itType?: string } = {},
): Promise<StockLevelReport> {
  return withTenant(prisma, tenantId, async (tx: any) => {
    const params: unknown[] = [scope.CO_CODE];
    const filters = ['a."CO_CODE"::text=$1'];
    if (options.itCode) {
      params.push(options.itCode);
      filters.push(`a."IT_CODE"::text=$${params.length}`);
    }
    if (options.itType) {
      params.push(options.itType);
      filters.push(`b."IT_TYPE"::text=$${params.length}`);
    }
    const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT a."IT_CODE",a."SR_NO",a."FROM_WT",a."TO_WT",a."MIN_PCS",a."IT_DESIGN",
              a."LBR_TYPE",a."LBR_CODE",a."LBR_RATE",a."LBR_PRC",a."LBR_AMT",
              a."MIN_LBR_PRC",a."GHT_PRC",b."IT_NAME",b."IT_TYPE"
         FROM "ITM_WT_MAST" a
         LEFT JOIN "ITEM_MAST" b
           ON b."CO_CODE"::text=a."CO_CODE"::text AND b."IT_CODE"::text=a."IT_CODE"::text
        WHERE ${filters.join(' AND ')}
        ORDER BY a."IT_CODE", a."FROM_WT", coalesce(a."SR_NO",0)`,
      ...params,
    );

    const mapped: StockLevelRow[] = rows.map((r) => ({
      itCode: String(r.IT_CODE ?? ''),
      itName: txt(r.IT_NAME),
      itType: txt(r.IT_TYPE),
      srNo: num(r.SR_NO),
      fromWt: w3(num(r.FROM_WT)),
      toWt: w3(num(r.TO_WT)),
      minPcs: num(r.MIN_PCS),
      design: txt(r.IT_DESIGN),
      labourType: txt(r.LBR_TYPE),
      labourCode: txt(r.LBR_CODE),
      labourRate: a2(num(r.LBR_RATE)),
      labourPct: a2(num(r.LBR_PRC)),
      labourAmount: a2(num(r.LBR_AMT)),
      minLabourPct: a2(num(r.MIN_LBR_PRC)),
      ghatPct: a2(num(r.GHT_PRC)),
    }));

    return {
      rows: mapped,
      totals: {
        count: mapped.length,
        items: new Set(mapped.map((r) => r.itCode)).size,
        // An item with more than one band charges different making at different weights, which is the
        // thing this report exists to make visible.
        bandedItems: [
          ...mapped.reduce(
            (m, r) => m.set(r.itCode, (m.get(r.itCode) ?? 0) + 1),
            new Map<string, number>(),
          ),
        ].filter(([, n]) => n > 1).length,
        designSpecific: mapped.filter((r) => r.design !== null).length,
      },
    };
  });
}

/**
 * Scheme monthly member report — desktop `RP_STK_LEVEL.DGV_DETL_SCHM_FILL`, menu caption "Monthly Report".
 *
 * The desktop creates one column per scheme collection month from `AD_DATA.SCHM_DATE`, then fills each
 * member's monthly `MEMB_AMT`, total and last month. When "With Adj Scheme" is unchecked, members whose
 * adjustment outstanding in `AD_OS` is already closed (`adjust-in - adjust-out <= 0`) are skipped.
 */
export async function schemeMonthlyReport(
  prisma: any,
  s: ReportScope,
  options: { schemeCode?: unknown; lcCode?: unknown; withAdjScheme?: unknown } = {},
): Promise<ListReport> {
  const schemeCode = txt(options.schemeCode);
  if (!schemeCode) return { rows: [], totals: { rows: 0 } };
  const lcCode = txt(options.lcCode) ?? s.lcCode ?? '';
  const toDate = s.toDate ?? todayIso();
  const withAdjScheme = flagFrom(options.withAdjScheme, false);
  return withTenant(prisma, s.tenantId, async (tx: any) => {
    const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT a."MEMB_CODE" AS "membCode",
              b."MEMB_NAME" AS "membName",
              b."AC_MOBILE" AS "mobile",
              EXTRACT(YEAR FROM a."SCHM_DATE")::int AS "yrCode",
              EXTRACT(MONTH FROM a."SCHM_DATE")::int AS "mnCode",
              SUM(coalesce(a."MEMB_AMT",0)) AS "membAmt"
         FROM "AD_DATA" a
         LEFT JOIN "AD_MEMB" b
           ON b.tenant_id=a.tenant_id
          AND b."CO_CODE"=a."CO_CODE"
          AND b."LC_CODE"=a."LC_CODE"
          AND b."SCHM_CODE"=a."SCHM_CODE"
          AND b."MEMB_CODE"=a."MEMB_CODE"
        WHERE a.tenant_id=current_setting('app.tenant_id', true)
          AND a."CO_CODE"=$1
          AND ($2::text='' OR a."LC_CODE"=$2)
          AND a."SCHM_CODE"=$3
          AND a."SCHM_DATE"<=$4::date
        GROUP BY a."MEMB_CODE", b."MEMB_NAME", b."AC_MOBILE", EXTRACT(YEAR FROM a."SCHM_DATE"), EXTRACT(MONTH FROM a."SCHM_DATE")
        ORDER BY a."MEMB_CODE", EXTRACT(YEAR FROM a."SCHM_DATE"), EXTRACT(MONTH FROM a."SCHM_DATE")`,
      s.coCode,
      lcCode,
      schemeCode,
      toDate,
    );

    const closedMembers = new Set<string>();
    if (!withAdjScheme) {
      const closedRows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
        `SELECT a."MEMB_CODE" AS "membCode"
           FROM "AD_OS" a
           LEFT JOIN "AD_MEMB" b
             ON b.tenant_id=a.tenant_id
            AND b."CO_CODE"=a."CO_CODE"
            AND b."LC_CODE"=a."LC_CODE"
            AND b."MEMB_CODE"=a."MEMB_CODE"
            AND b."SCHM_CODE"=a."SCHM_CODE"
          WHERE a.tenant_id=current_setting('app.tenant_id', true)
            AND a."CO_CODE"=$1
            AND ($2::text='' OR a."LC_CODE"=$2)
            AND a."SCHM_CODE"=$3
            AND a."VCH_DATE"<=$4::date
          GROUP BY a."MEMB_CODE"
         HAVING SUM(CASE WHEN a."OS_TYPE"='A' THEN CASE WHEN a."SIGN"='+' THEN coalesce(a."ADJ_AMT",0) ELSE 0 END ELSE 0 END)
              - SUM(CASE WHEN a."OS_TYPE"='D' THEN CASE WHEN a."SIGN"='-' THEN coalesce(a."ADJ_AMT",0) ELSE 0 END ELSE 0 END) <= 0`,
        s.coCode,
        lcCode,
        schemeCode,
        toDate,
      );
      for (const row of closedRows) {
        const code = txt(row.membCode);
        if (code) closedMembers.add(code);
      }
    }

    const months = new Map<string, { year: number; month: number }>();
    for (const row of rows) {
      const year = num(row.yrCode);
      const month = num(row.mnCode);
      months.set(monthLabel(year, month), { year, month });
    }
    const monthKeys = [...months.entries()]
      .sort((a, b) => a[1].year - b[1].year || a[1].month - b[1].month)
      .map(([key]) => key);
    const byMember = new Map<string, Record<string, unknown>>();
    const ensure = (row: Record<string, unknown>): Record<string, unknown> | null => {
      const membCode = txt(row.membCode);
      if (!membCode || closedMembers.has(membCode)) return null;
      if (!byMember.has(membCode)) {
        byMember.set(membCode, {
          srNo: 0,
          membCode,
          membName: txt(row.membName),
          mobile: txt(row.mobile),
          ...Object.fromEntries(monthKeys.map((key) => [key, 0])),
          total: 0,
          lMonth: null,
        });
      }
      return byMember.get(membCode)!;
    };
    for (const row of rows) {
      const out = ensure(row);
      if (!out) continue;
      const key = monthLabel(num(row.yrCode), num(row.mnCode));
      const amount = a2(num(row.membAmt));
      out[key] = a2(num(out[key]) + amount);
      out.total = a2(num(out.total) + amount);
      out.lMonth = key;
    }

    const mapped: Array<Record<string, unknown>> = Array.from(byMember.values()).map(
      (row, index) => ({
        ...row,
        srNo: index + 1,
      }),
    );
    return {
      rows: mapped,
      totals: {
        rows: mapped.length,
        ...Object.fromEntries(
          monthKeys.map((key) => [key, a2(mapped.reduce((sum, row) => sum + num(row[key]), 0))]),
        ),
        total: a2(mapped.reduce((sum, row) => sum + num(row['total']), 0)),
      },
    };
  });
}
