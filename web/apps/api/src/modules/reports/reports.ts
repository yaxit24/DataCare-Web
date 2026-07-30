import { withTenant } from '@datacare/db';
import { applyFilters, type ReportFilters } from './reportFilters.js';
import { closingStockValuationTx } from './closingStock.js';
import { quoteIdent } from '../security/sql.js';
import { barTagAvailableSql } from '../shared/stockSql.js';
import { fineStockValue, resolveSettingsBehaviorTx } from '../shared/settingsBehavior.js';
import { stageListReportTx } from './reportGridStaging.js';

/**
 * Report dataset builders (read-only) reproducing the desktop .rpt field sets. The register shape
 * mirrors the desktop grids (UT_E_INVOICE/sales register): VchNo, VchDate, BillNo, Party, NetAmt,
 * TaxAmt, GST split, TotAmt, OsAmt. Financial reports (trial balance, account ledger), GST returns,
 * stock on-hand, and Dhrn outstanding are re-exported from their modules so this is the single
 * reporting surface.
 */

// Re-export the read-models already built and live-verified in their own modules.
export { trialBalance, accountLedger } from '../accounting/accounting.js';
export { gstr1 } from '../gst/gst.js';
export { onHand as stockOnHand } from '../stock/stock.js';
export { outstanding as dhrnOutstanding } from '../dhrn/dhrn.js';

export interface ReportScope {
  tenantId: string;
  coCode: string;
  lcCode?: string;
  coYear?: string;
  /**
   * Optional voucher-date window applied by reports that expose a date column.
   *
   * Only 3 of 48 report routes accepted a date range and the UI never sent one, so every other report
   * returned a whole financial year with no way to narrow it. The desktop filters most reports by a
   * from/to date (`RP_ALL.cs` builds the predicate on every family), so this closes a real gap rather than
   * adding a new capability.
   */
  fromDate?: string;
  toDate?: string;
  /**
   * The eleven shared `RP_ALL` panel dimensions, carried on the scope for the same reason the date window is:
   * a builder gains filtering without changing its signature.
   *
   * A builder only honours the dimensions its registered `FilterBinding` declares. Registering a binding
   * WITHOUT applying it here would be worse than not registering at all, because `/reports/:report/filters`
   * would advertise the dimension and the screen would send a filter that is then silently ignored.
   */
  filters?: ReportFilters;
}

/**
 * Append a voucher-date predicate using the NEXT free positional parameters.
 *
 * Each report builds its own `params` array with hardcoded `$1`/`$2`, so a date filter cannot use a fixed
 * index. The helper takes the array, pushes what it needs, and returns SQL referencing the indices it
 * actually used — which is why it must be called AFTER the caller has finished pushing its own parameters.
 */
export function dateWhere(s: ReportScope, column: string, params: unknown[]): string {
  let sql = '';
  if (s.fromDate) {
    params.push(s.fromDate);
    sql += ` AND ${column} >= $${params.length}::date`;
  }
  if (s.toDate) {
    params.push(s.toDate);
    sql += ` AND ${column} <= $${params.length}::date`;
  }
  return sql;
}

export interface DateRange {
  fromDate?: Date | string;
  toDate?: Date | string;
}

export interface RegisterRow {
  vchNo: string;
  coBook?: string | null;
  vchDate: Date | null;
  billNo: string | null;
  acCode: string | null;
  party: string | null;
  netAmt: number;
  taxAmt: number;
  cgst: number;
  sgst: number;
  igst: number;
  totAmt: number;
  osAmt: number;
}

export interface Register {
  rows: RegisterRow[];
  totals: {
    netAmt: number;
    taxAmt: number;
    cgst: number;
    sgst: number;
    igst: number;
    totAmt: number;
    osAmt: number;
  };
}

const round2 = (x: number): number => Math.round((x + Number.EPSILON) * 100) / 100;
const num = (v: unknown): number => Number(v ?? 0);

/** Pure: roll register rows into totals (Req 19, report footer). */
export function shapeRegister(rows: RegisterRow[]): Register {
  const totals = rows.reduce(
    (t, r) => ({
      netAmt: round2(t.netAmt + r.netAmt),
      taxAmt: round2(t.taxAmt + r.taxAmt),
      cgst: round2(t.cgst + r.cgst),
      sgst: round2(t.sgst + r.sgst),
      igst: round2(t.igst + r.igst),
      totAmt: round2(t.totAmt + r.totAmt),
      osAmt: round2(t.osAmt + r.osAmt),
    }),
    { netAmt: 0, taxAmt: 0, cgst: 0, sgst: 0, igst: 0, totAmt: 0, osAmt: 0 },
  );
  return { rows, totals };
}

function whereScopeDate(
  s: ReportScope,
  r: DateRange,
  alias = '',
): { sql: string; params: unknown[] } {
  const a = alias ? alias + '.' : '';
  const parts = [`${a}"CO_CODE"=$1`];
  const params: unknown[] = [s.coCode];
  let i = 2;
  if (s.lcCode) {
    parts.push(`${a}"LC_CODE"=$${i++}`);
    params.push(s.lcCode);
  }
  if (s.coYear) {
    parts.push(`${a}"CO_YEAR"=$${i++}`);
    params.push(s.coYear);
  }
  if (r.fromDate) {
    parts.push(`${a}"VCH_DATE">=$${i++}`);
    params.push(new Date(r.fromDate));
  }
  if (r.toDate) {
    parts.push(`${a}"VCH_DATE"<=$${i++}`);
    params.push(new Date(r.toDate));
  }
  return { sql: parts.join(' AND '), params };
}

const NN = (c: string): string => `coalesce(NULLIF(${c}::text,'')::numeric,0)`;

async function registerFrom(
  prisma: any,
  s: ReportScope,
  table: string,
  r: DateRange,
  excludeBook?: string,
): Promise<Register> {
  return withTenant(prisma, s.tenantId, async (tx: any) => {
    const w = whereScopeDate(s, r);
    // excludeBook is an internal constant (never user input) — sanitized + inlined.
    const extra = excludeBook
      ? ` AND "CO_BOOK" <> '${excludeBook.replace(/[^A-Z0-9_]/g, '')}'`
      : '';
    const rows: any[] = await tx.$queryRawUnsafe(
      `SELECT "VCH_NO" AS "vchNo", "CO_BOOK" AS "coBook", "VCH_DATE" AS "vchDate", "BILL_NO" AS "billNo", "AC_CODE" AS "acCode", "AC_NAME" AS party,
              ${NN('"NET_AMT"')}-${NN('"DISC_AMT"')} AS net, ${NN('"TAX_AMT"')} AS tax,
              ${NN('"CGST_TAX"')} AS cgst, ${NN('"SGST_TAX"')} AS sgst, ${NN('"IGST_TAX"')} AS igst,
              ${NN('"TOT_AMT"')} AS tot, ${NN('"BILL_OS"')} AS os
       FROM ${quoteIdent(table)} WHERE ${w.sql}${extra} ORDER BY "VCH_DATE","VCH_NO"`,
      ...w.params,
    );
    return shapeRegister(
      rows.map((x) => ({
        vchNo: String(x.vchNo),
        coBook: x.coBook == null ? null : String(x.coBook),
        vchDate: x.vchDate ?? null,
        billNo: x.billNo ?? null,
        acCode: x.acCode ?? null,
        party: x.party ?? null,
        netAmt: round2(num(x.net)),
        taxAmt: round2(num(x.tax)),
        cgst: round2(num(x.cgst)),
        sgst: round2(num(x.sgst)),
        igst: round2(num(x.igst)),
        totAmt: round2(num(x.tot)),
        osAmt: round2(num(x.os)),
      })),
    );
  });
}

/** Sales register (SL_DATA) — Req 19. Excludes sales-return vouchers (CO_BOOK='SRT'). */
export function salesRegister(prisma: any, s: ReportScope, r: DateRange = {}): Promise<Register> {
  return registerFrom(prisma, s, 'SL_DATA', r, 'SRT');
}

/** Purchase register (PR_DATA) — Req 19. Excludes purchase-return vouchers (CO_BOOK='PRT'). */
export function purchaseRegister(
  prisma: any,
  s: ReportScope,
  r: DateRange = {},
): Promise<Register> {
  return registerFrom(prisma, s, 'PR_DATA', r, 'PRT');
}

const round3 = (x: number): number => Math.round((x + Number.EPSILON) * 1000) / 1000;
export interface ListReport {
  rows: Record<string, any>[];
  totals?: Record<string, number>;
}
const coParams = (s: ReportScope): { yr: string; params: unknown[] } =>
  s.coYear
    ? { yr: ' AND "CO_YEAR"=$2', params: [s.coCode, s.coYear] }
    : { yr: '', params: [s.coCode] };

/** Open pledge loans = principal − Σ receipts, per issue (outstanding > 0). */
/**
 * Pledge dues list. Also stages REPORT_DATA so the desktop's `DharnDue` Crystal layout — which binds
 * REPORT_DATA.COL_n rather than a typed table — renders the same grid (RP_DHRN_OS.cs:3462).
 */
export async function dhrnOutstandingList(prisma: any, s: ReportScope): Promise<ListReport> {
  return withTenant(prisma, s.tenantId, async (tx: any) => {
    const { yr, params } = coParams(s);
    const dt = dateWhere(s, 'i."VCH_DATE"', params);
    const rows: any[] = await tx.$queryRawUnsafe(
      `SELECT i."VCH_NO" AS "vchNo", i."AC_CODE" AS "acCode", i."AC_NAME" AS party,
              ${NN('i."DHRN_AMT"')} AS principal, ${NN('i."INT_PRC"')} AS "intPct",
              ${NN('i."DHRN_AMT"')} - coalesce((SELECT sum(${NN('r."DHRN_REC_AMT"')}) FROM "DHRN_REC_DATA" r WHERE r."ISU_NO"::text=i."VCH_NO"::text AND r."CO_CODE"=i."CO_CODE"),0) AS outstanding
       FROM "DHRN_ISU_DATA" i WHERE i."CO_CODE"=$1${yr}${dt} ORDER BY i."VCH_NO"`,
      ...params,
    );
    const open = rows
      .map((r) => ({
        vchNo: String(r.vchNo),
        acCode: r.acCode,
        party: r.party,
        principal: round2(num(r.principal)),
        intPct: num(r.intPct),
        outstanding: round2(num(r.outstanding)),
      }))
      .filter((r) => r.outstanding > 0.005);
    // Stage exactly what the report returns (filtered + rounded), which is what the desktop grid
    // shows and therefore what Crystal prints.
    await stageListReportTx(tx, s.tenantId, { coCode: s.coCode, lcCode: s.lcCode ?? '' }, open, {
      vchNo: 'Vch No',
      acCode: 'A/c Code',
      party: 'Party',
      principal: 'Principal',
      intPct: 'Int %',
      outstanding: 'Outstanding',
    });

    return {
      rows: open,
      totals: {
        count: open.length,
        outstanding: round2(open.reduce((t, r) => t + r.outstanding, 0)),
      },
    };
  });
}

/** Karigar metal balances = Σ fine issued − Σ fine received, per karigar. */
export async function karigarBalances(prisma: any, s: ReportScope): Promise<ListReport> {
  return withTenant(prisma, s.tenantId, async (tx: any) => {
    const rows: any[] = await tx.$queryRawUnsafe(
      `SELECT "AC_CODE" AS "acCode",
              sum(CASE WHEN "INOUT_TYPE"='O' THEN ${NN('"ITM_FINE"')} ELSE 0 END) AS issued,
              sum(CASE WHEN "INOUT_TYPE"='I' THEN ${NN('"ITM_FINE"')} ELSE 0 END) AS received
       FROM "KR_DETL" WHERE "CO_CODE"=$1 GROUP BY "AC_CODE" ORDER BY "AC_CODE"`,
      s.coCode,
    );
    const out = rows.map((r) => ({
      acCode: r.acCode,
      issued: round3(num(r.issued)),
      received: round3(num(r.received)),
      balance: round3(num(r.issued) - num(r.received)),
    }));
    return {
      rows: out,
      totals: { karigars: out.length, balance: round3(out.reduce((t, r) => t + r.balance, 0)) },
    };
  });
}

/** Account balances = Σ Dr − Σ Cr per account (AC_DATA). */
export async function accountBalances(prisma: any, s: ReportScope): Promise<ListReport> {
  return withTenant(prisma, s.tenantId, async (tx: any) => {
    const { yr, params } = coParams(s);
    const dt = dateWhere(s, '"VCH_DATE"', params);
    const rows: any[] = await tx.$queryRawUnsafe(
      `SELECT "AC_CODE" AS "acCode", sum(${NN('"DR_AMT"')}) AS dr, sum(${NN('"CR_AMT"')}) AS cr
       FROM "AC_DATA" WHERE "CO_CODE"=$1${yr}${dt} GROUP BY "AC_CODE" ORDER BY "AC_CODE"`,
      ...params,
    );
    const out = rows.map((r) => ({
      acCode: r.acCode,
      dr: round2(num(r.dr)),
      cr: round2(num(r.cr)),
      balance: round2(num(r.dr) - num(r.cr)),
    }));
    return {
      rows: out,
      totals: {
        dr: round2(out.reduce((t, r) => t + r.dr, 0)),
        cr: round2(out.reduce((t, r) => t + r.cr, 0)),
      },
    };
  });
}

/** Stock valuation from the tag inventory (BAR_DETL), grouped by item (desktop stock source). */
export async function stockValuation(prisma: any, s: ReportScope): Promise<ListReport> {
  return withTenant(prisma, s.tenantId, async (tx: any) => {
    const behavior = await resolveSettingsBehaviorTx(tx, {
      tenantId: s.tenantId,
      coCode: s.coCode,
    });
    // BAR_DETL b and ITEM_MAST i are real outer LEFT JOINs here, so the item dimensions are available.
    // BAR_DETL carries no EMP_CODE, which the binding declares.
    const params: unknown[] = [s.coCode];
    const fl = applyFilters('stock-valuation', s.filters, params);
    const rows: any[] = await tx.$queryRawUnsafe(
      `SELECT coalesce(b."IT_CODE",'(none)') AS item, count(*)::int AS tags,
              coalesce(sum(${NN('b."ITM_PCS"')}),0) AS pcs, coalesce(sum(${NN('b."ITM_GWT"')}),0) AS gwt,
              coalesce(sum(${NN('b."ITM_NWT"')}),0) AS nwt, coalesce(sum(${NN('b."ITM_FINE"')}),0) AS fine,
              coalesce(sum(${NN('b."ITM_MRP"')}),0) AS mrp,
              coalesce(max(i."AVG_TOUCH"),0) AS "averageTouch",
              coalesce(max(g."MELTING_PRC"), '0') AS "meltingPct"
       FROM "BAR_DETL" b
       LEFT JOIN "ITEM_MAST" i ON i.tenant_id=b.tenant_id AND i."CO_CODE"=b."CO_CODE"
        AND i."IT_CODE"::text=b."IT_CODE"::text
       LEFT JOIN "GROUP_MAST" g ON g.tenant_id=i.tenant_id AND g."CO_CODE"=i."CO_CODE"
        AND g."GR_CODE"=i."GR_CODE"
       WHERE b."CO_CODE"=$1 AND ${barTagAvailableSql('b')}${fl}
       GROUP BY b."IT_CODE" ORDER BY nwt DESC`,
      ...params,
    );
    const out = rows.map((r) => ({
      item: r.item,
      tags: Number(r.tags),
      pcs: round3(num(r.pcs)),
      gwt: round3(num(r.gwt)),
      nwt: round3(num(r.nwt)),
      // RP_STOCK.cs:3649,4280,4868: STK_RPT_TYPE=G selects gross instead of net report weight.
      weight: round3(behavior.stockReportGrossWeight ? num(r.gwt) : num(r.nwt)),
      // RP_STOCK_FINE.cs:2963-2973 selects A/N/G; :3004-3040 applies average/group touch to
      // closing net, while :3134-3160 uses posted fine for N. Blank remains today's posted fine.
      fine: round3(
        fineStockValue(
          num(r.nwt),
          num(r.fine),
          behavior.fineStockType,
          num(r.averageTouch),
          num(r.meltingPct),
        ),
      ),
      mrp: round2(num(r.mrp)),
    }));
    return {
      rows: out,
      totals: {
        items: out.length,
        tags: out.reduce((t, r) => t + r.tags, 0),
        nwt: round3(out.reduce((t, r) => t + r.nwt, 0)),
        weight: round3(out.reduce((t, r) => t + r.weight, 0)),
        fine: round3(out.reduce((t, r) => t + r.fine, 0)),
        mrp: round2(out.reduce((t, r) => t + r.mrp, 0)),
      },
    };
  });
}

/** Old-gold / exchange register (SL_PR_DETL): metal received from parties against sales/orders, valued at touch. */
export async function oldGoldRegister(prisma: any, s: ReportScope): Promise<ListReport> {
  return withTenant(prisma, s.tenantId, async (tx: any) => {
    const { yr, params } = coParams(s);
    const dt = dateWhere(s, '"VCH_DATE"', params);
    const rows: any[] = await tx.$queryRawUnsafe(
      `SELECT "VCH_NO" AS voucher, "VCH_DATE" AS date, "AC_CODE" AS party, coalesce("IT_DESC","IT_CODE") AS item,
              ${NN('"ITM_PCS"')} AS pcs, ${NN('"ITM_NWT"')} AS nwt, ${NN('"ITM_TOUCH"')} AS touch,
              ${NN('"ITM_FINE"')} AS fine, ${NN('"ITM_RATE"')} AS rate, ${NN('"NET_AMT"')} AS amount
       FROM "SL_PR_DETL" WHERE "CO_CODE"=$1${yr}${dt} ORDER BY "VCH_DATE", "VCH_NO"`,
      ...params,
    );
    const out = rows.map((r) => ({
      voucher: String(r.voucher),
      date: r.date,
      party: r.party,
      item: r.item,
      pcs: round3(num(r.pcs)),
      nwt: round3(num(r.nwt)),
      touch: round2(num(r.touch)),
      fine: round3(num(r.fine)),
      rate: round2(num(r.rate)),
      amount: round2(num(r.amount)),
    }));
    return {
      rows: out,
      totals: {
        lines: out.length,
        nwt: round3(out.reduce((t, r) => t + r.nwt, 0)),
        fine: round3(out.reduce((t, r) => t + r.fine, 0)),
        amount: round2(out.reduce((t, r) => t + r.amount, 0)),
      },
    };
  });
}

/** Bill-wise outstanding (BILL_OS_DATA): per party/direction, balance = Σ BILL_AMT − Σ REC_AMT.
 *  INOUT 'I' = receivable (customer owes us), 'O' = payable (we owe supplier). */
export async function billOutstanding(prisma: any, s: ReportScope): Promise<ListReport> {
  return withTenant(prisma, s.tenantId, async (tx: any) => {
    const { yr, params } = coParams(s);
    const dt = dateWhere(s, 'b."VCH_DATE"', params);
    const rows: any[] = await tx.$queryRawUnsafe(
      `SELECT b."AC_CODE" AS "acCode", b."INOUT_TYPE" AS "inout",
              (SELECT m."AC_NAME" FROM "AC_MAST" m WHERE m."AC_CODE"::text=b."AC_CODE"::text LIMIT 1) AS party,
              sum(${NN('b."BILL_AMT"')}) AS billed, sum(${NN('b."REC_AMT"')}) AS received,
              sum(${NN('b."BILL_AMT"')} - ${NN('b."REC_AMT"')}) AS balance, count(*)::int AS bills
       FROM "BILL_OS_DATA" b WHERE b."CO_CODE"=$1${yr}${dt} GROUP BY b."AC_CODE", b."INOUT_TYPE" ORDER BY balance DESC`,
      ...params,
    );
    const out = rows
      .map((r) => ({
        acCode: r.acCode,
        party: r.party ?? r.acCode,
        type: r.inout === 'I' ? 'Payable' : 'Receivable',
        bills: Number(r.bills),
        billed: round2(num(r.billed)),
        received: round2(num(r.received)),
        balance: round2(num(r.balance)),
      }))
      .filter((r) => Math.abs(r.balance) > 0.005);
    const receivable = round2(
      out.filter((r) => r.type === 'Receivable').reduce((t, r) => t + r.balance, 0),
    );
    const payable = round2(
      out.filter((r) => r.type === 'Payable').reduce((t, r) => t + r.balance, 0),
    );
    return {
      rows: out,
      totals: {
        parties: out.length,
        billed: round2(out.reduce((t, r) => t + r.billed, 0)),
        received: round2(out.reduce((t, r) => t + r.received, 0)),
        receivable,
        payable,
      },
    };
  });
}

/** GSTR-3B outward-supply summary (SL_DATA, excludes returns book 'SRT'). ITC/inward is a follow-up. */
export async function gstr3b(prisma: any, s: ReportScope): Promise<Record<string, number>> {
  return withTenant(prisma, s.tenantId, async (tx: any) => {
    const { yr, params } = coParams(s);
    const dt = dateWhere(s, '"VCH_DATE"', params);
    const r: any[] = await tx.$queryRawUnsafe(
      `SELECT coalesce(sum(${NN('"NET_AMT"')}-${NN('"DISC_AMT"')}),0) AS taxable, coalesce(sum(${NN('"TAX_AMT"')}),0) AS tax,
              coalesce(sum(${NN('"CGST_TAX"')}),0) AS cgst, coalesce(sum(${NN('"SGST_TAX"')}),0) AS sgst, coalesce(sum(${NN('"IGST_TAX"')}),0) AS igst
       FROM "SL_DATA" WHERE "CO_CODE"=$1${yr}${dt} AND "CO_BOOK"<>'SRT'`,
      ...params,
    );
    const x = r[0];
    return {
      outwardTaxable: round2(num(x.taxable)),
      outwardTax: round2(num(x.tax)),
      outwardCGST: round2(num(x.cgst)),
      outwardSGST: round2(num(x.sgst)),
      outwardIGST: round2(num(x.igst)),
    };
  });
}

/** Sales by party (SL_DATA grouped by customer, excl returns). */
export async function salesByParty(prisma: any, s: ReportScope): Promise<ListReport> {
  return withTenant(prisma, s.tenantId, async (tx: any) => {
    const { yr, params } = coParams(s);
    const dt = dateWhere(s, '"VCH_DATE"', params);
    const rows: any[] = await tx.$queryRawUnsafe(
      `SELECT "AC_CODE" AS "acCode", max("AC_NAME") AS party, count(*)::int AS bills, sum(${NN('"TOT_AMT"')}) AS total
       FROM "SL_DATA" WHERE "CO_CODE"=$1${yr}${dt} AND "CO_BOOK"<>'SRT' GROUP BY "AC_CODE" ORDER BY total DESC NULLS LAST`,
      ...params,
    );
    const out = rows.map((r) => ({
      acCode: r.acCode,
      party: r.party,
      bills: Number(r.bills),
      total: round2(num(r.total)),
    }));
    return {
      rows: out,
      totals: { parties: out.length, total: round2(out.reduce((t, r) => t + r.total, 0)) },
    };
  });
}

/** Sales by item (SL_DETL grouped by item code). */
export async function salesByItem(prisma: any, s: ReportScope): Promise<ListReport> {
  return withTenant(prisma, s.tenantId, async (tx: any) => {
    const rows: any[] = await tx.$queryRawUnsafe(
      `SELECT "IT_CODE" AS item, count(*)::int AS lines, sum(${NN('"ITM_NWT"')}) AS "netWt", sum(${NN('"NET_AMT"')}) AS amount
       FROM "SL_DETL" WHERE "CO_CODE"=$1 GROUP BY "IT_CODE" ORDER BY amount DESC NULLS LAST`,
      s.coCode,
    );
    const out = rows.map((r) => ({
      item: r.item,
      lines: Number(r.lines),
      netWt: round3(num(r.netWt)),
      amount: round2(num(r.amount)),
    }));
    return {
      rows: out,
      totals: {
        items: out.length,
        netWt: round3(out.reduce((t, r) => t + r.netWt, 0)),
        amount: round2(out.reduce((t, r) => t + r.amount, 0)),
      },
    };
  });
}

/**
 * Balance sheet (final accounts) — desktop `Ac_Final.Trading_Stock` (`Ac_Final.cs:18-138`).
 *
 * Closing stock is computed INDEPENDENTLY from inventory by `closingStockValuation`, then presented as the
 * asset side. It is deliberately NOT a balancing figure: the previous implementation used
 * `closingStock = ΣCr − ΣDr`, which forced Assets = Liabilities by definition and therefore made a stock
 * shortage or valuation error impossible to see. `difference` is now a real number and `balanced` means the
 * books actually tie, not that the arithmetic was rigged.
 *
 * Read-only. The desktop writes its computed pair into `AC_DATA` book 999 while rendering; a web GET must
 * not mutate the ledger, so the pair is returned for presentation only.
 */
export async function balanceSheet(
  prisma: any,
  s: ReportScope,
  opts: {
    closingDate?: Date | string;
    goldRate?: number;
    silverRate?: number;
    ledgerFineGold?: number;
    ledgerFineSilver?: number;
  } = {},
): Promise<Record<string, unknown>> {
  return withTenant(prisma, s.tenantId, async (tx: any) => {
    const { yr, params } = coParams(s);
    const r: any[] = await tx.$queryRawUnsafe(
      `SELECT coalesce(sum(${NN('"DR_AMT"')}),0) AS dr, coalesce(sum(${NN('"CR_AMT"')}),0) AS cr FROM "AC_DATA" WHERE "CO_CODE"=$1${yr}`,
      ...params,
    );
    const dr = round2(num(r[0].dr));
    const cr = round2(num(r[0].cr));
    const stock = await closingStockValuationTx(
      tx,
      { tenantId: s.tenantId, coCode: s.coCode, coYear: s.coYear, lcCode: (s as any).lcCode },
      {
        // No closing date supplied means "as of today", matching the desktop's default final date.
        closingDate: opts.closingDate ?? new Date(),
        goldRate: opts.goldRate,
        silverRate: opts.silverRate,
        ledgerFineGold: opts.ledgerFineGold,
        ledgerFineSilver: opts.ledgerFineSilver,
      },
    );
    const totalAssets = round2(dr + stock.total);
    const totalLiabilities = cr;
    return {
      ledgerDr: dr,
      ledgerCr: cr,
      closingStock: stock.total,
      closingStockMode: stock.mode,
      balanceSheetType: stock.balanceSheetType,
      metalValued: stock.metalValued,
      closingStockRows: stock.rows,
      closingStockLegs: stock.legs,
      totalAssets,
      totalLiabilities,
      difference: round2(totalAssets - totalLiabilities),
      balanced: Math.abs(totalAssets - totalLiabilities) < 0.05,
    };
  });
}

/** Outstanding balances per account (AC_DATA ΣDr−ΣCr) with names; classified receivable/payable. */
export async function outstandingReport(prisma: any, s: ReportScope): Promise<ListReport> {
  return withTenant(prisma, s.tenantId, async (tx: any) => {
    const yr = s.coYear ? ' AND d."CO_YEAR"=$2' : '';
    const params: unknown[] = s.coYear ? [s.coCode, s.coYear] : [s.coCode];
    const dt = dateWhere(s, 'd."VCH_DATE"', params);
    const rows: any[] = await tx.$queryRawUnsafe(
      `SELECT d."AC_CODE" AS "acCode", max(m."AC_NAME") AS party,
              round(sum(${NN('d."DR_AMT"')}) - sum(${NN('d."CR_AMT"')}), 2) AS balance
       FROM "AC_DATA" d LEFT JOIN "AC_MAST" m ON m."CO_CODE"=d."CO_CODE" AND m."AC_CODE"=d."AC_CODE"
       WHERE d."CO_CODE"=$1${yr}${dt}
       GROUP BY d."AC_CODE" HAVING abs(sum(${NN('d."DR_AMT"')}) - sum(${NN('d."CR_AMT"')})) > 0.005
       ORDER BY balance DESC`,
      ...params,
    );
    const out = rows.map((r) => ({
      acCode: r.acCode,
      party: r.party,
      balance: round2(num(r.balance)),
      type: num(r.balance) > 0 ? 'Receivable' : 'Payable',
    }));
    const receivable = round2(out.filter((r) => r.balance > 0).reduce((t, r) => t + r.balance, 0));
    const payable = round2(
      Math.abs(out.filter((r) => r.balance < 0).reduce((t, r) => t + r.balance, 0)),
    );
    return { rows: out, totals: { accounts: out.length, receivable, payable } };
  });
}

/** Monthly sales MIS (SL_DATA grouped by YYYY-MM, excl returns). */
export async function monthlySales(prisma: any, s: ReportScope): Promise<ListReport> {
  return withTenant(prisma, s.tenantId, async (tx: any) => {
    const { yr, params } = coParams(s);
    const dt = dateWhere(s, '"VCH_DATE"', params);
    const rows: any[] = await tx.$queryRawUnsafe(
      `SELECT to_char("VCH_DATE"::timestamp,'YYYY-MM') AS month, count(*)::int AS invoices,
              sum(${NN('"NET_AMT"')}) AS net, sum(${NN('"TAX_AMT"')}) AS tax, sum(${NN('"TOT_AMT"')}) AS total
       FROM "SL_DATA" WHERE "CO_CODE"=$1${yr}${dt} AND "CO_BOOK"<>'SRT' AND "VCH_DATE" IS NOT NULL
       GROUP BY 1 ORDER BY 1`,
      ...params,
    );
    const out = rows.map((r) => ({
      month: r.month,
      invoices: Number(r.invoices),
      net: round2(num(r.net)),
      tax: round2(num(r.tax)),
      total: round2(num(r.total)),
    }));
    return {
      rows: out,
      totals: { months: out.length, total: round2(out.reduce((t, r) => t + r.total, 0)) },
    };
  });
}

export interface DayBookRow {
  vchNo: string;
  vchType: string | null;
  acCode: string | null;
  dr: number;
  cr: number;
}

export interface DayBook {
  rows: DayBookRow[];
  totals: { dr: number; cr: number; balanced: boolean };
}

/** Day-book / Rojmel (AC_DATA for a date range): every ledger movement + Dr/Cr totals. */
export async function dayBook(prisma: any, s: ReportScope, r: DateRange = {}): Promise<DayBook> {
  return withTenant(prisma, s.tenantId, async (tx: any) => {
    const w = whereScopeDate(s, r);
    const rows: any[] = await tx.$queryRawUnsafe(
      `SELECT "VCH_NO" AS "vchNo", "VCH_TYPE" AS "vchType", "AC_CODE" AS "acCode",
              ${NN('"DR_AMT"')} AS dr, ${NN('"CR_AMT"')} AS cr
       FROM "AC_DATA" WHERE ${w.sql} ORDER BY "VCH_DATE","VCH_NO"`,
      ...w.params,
    );
    const out: DayBookRow[] = rows.map((x) => ({
      vchNo: String(x.vchNo),
      vchType: x.vchType ?? null,
      acCode: x.acCode ?? null,
      dr: round2(num(x.dr)),
      cr: round2(num(x.cr)),
    }));
    const dr = round2(out.reduce((s2, x) => s2 + x.dr, 0));
    const cr = round2(out.reduce((s2, x) => s2 + x.cr, 0));
    return { rows: out, totals: { dr, cr, balanced: dr === cr } };
  });
}
