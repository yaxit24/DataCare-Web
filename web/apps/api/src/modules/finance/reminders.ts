import { withTxBudget } from '../shared/txBudget.js';

/**
 * Reminder dashboard (desktop "Reminder"): a read-only aggregation of things needing attention —
 *  • Overdue receivables: per party, the outstanding from BILL_OS_DATA (BILL_AMT − REC_AMT − KASAR_AMT,
 *    plus gold/silver fine), aged against the party's credit days (AC_MAST.AC_CR_DAYS). Overdue when the
 *    oldest open bill is older than the allowed credit days.
 *  • Orders due: SL_ORD_DATA rows with a delivery date (DEL_DATE), flagged due-soon / overdue.
 * (This schema has no birthday/anniversary columns, so those desktop reminders are intentionally omitted.)
 */
const r2 = (n: number): number => Math.round((n + 1e-9) * 100) / 100;

export interface ReceivableReminder {
  acCode: string;
  acName: string;
  mobile: string;
  outstanding: number;
  goldOs: number;
  silverOs: number;
  crDays: number;
  oldestAgeDays: number;
  daysOverdue: number;
  overdue: boolean;
}
export interface OrderReminder {
  vchNo: string;
  acCode: string;
  acName: string;
  delDate: string | null;
  total: number;
  daysToDelivery: number | null;
  overdue: boolean;
}
export interface Reminders {
  receivables: ReceivableReminder[];
  ordersDue: OrderReminder[];
  summary: {
    overdueParties: number;
    totalOutstanding: number;
    ordersDue: number;
    ordersOverdue: number;
  };
}

export async function reminders(
  prisma: any,
  scope: { tenantId: string; coCode: string },
  opts?: { dueWindowDays?: number },
): Promise<Reminders> {
  const win = Number(opts?.dueWindowDays ?? 7);
  return withTxBudget(prisma, scope.tenantId, 'read', async (tx: any) => {
    const recRows: any[] = await tx.$queryRawUnsafe(
      `SELECT b."AC_CODE" ac, coalesce(a."AC_NAME", b."AC_CODE") nm, coalesce(a."AC_MOBILE",'') mob, coalesce(NULLIF(a."AC_CR_DAYS"::text,'')::numeric,0)::int crdays,
              SUM(coalesce(NULLIF(b."BILL_AMT"::text,'')::numeric,0) - coalesce(NULLIF(b."REC_AMT"::text,'')::numeric,0) - coalesce(NULLIF(b."KASAR_AMT"::text,'')::numeric,0))::float os,
              SUM(coalesce(NULLIF(b."BILL_GOLD"::text,'')::numeric,0) - coalesce(NULLIF(b."REC_GOLD"::text,'')::numeric,0) - coalesce(NULLIF(b."KASAR_GOLD"::text,'')::numeric,0))::float gos,
              SUM(coalesce(NULLIF(b."BILL_SILVER"::text,'')::numeric,0) - coalesce(NULLIF(b."REC_SILVER"::text,'')::numeric,0) - coalesce(NULLIF(b."KASAR_SILVER"::text,'')::numeric,0))::float sos,
              (CURRENT_DATE - MIN(b."VCH_DATE"::date))::int oldest
       FROM "BILL_OS_DATA" b LEFT JOIN "AC_MAST" a ON a."CO_CODE"=b."CO_CODE" AND a."AC_CODE"=b."AC_CODE"
       WHERE b."CO_CODE"=$1
       GROUP BY b."AC_CODE", a."AC_NAME", a."AC_MOBILE", a."AC_CR_DAYS"
       HAVING SUM(coalesce(NULLIF(b."BILL_AMT"::text,'')::numeric,0) - coalesce(NULLIF(b."REC_AMT"::text,'')::numeric,0) - coalesce(NULLIF(b."KASAR_AMT"::text,'')::numeric,0)) > 0.01
           OR SUM(coalesce(NULLIF(b."BILL_GOLD"::text,'')::numeric,0) - coalesce(NULLIF(b."REC_GOLD"::text,'')::numeric,0) - coalesce(NULLIF(b."KASAR_GOLD"::text,'')::numeric,0)) > 0.001
           OR SUM(coalesce(NULLIF(b."BILL_SILVER"::text,'')::numeric,0) - coalesce(NULLIF(b."REC_SILVER"::text,'')::numeric,0) - coalesce(NULLIF(b."KASAR_SILVER"::text,'')::numeric,0)) > 0.001
       ORDER BY oldest DESC NULLS LAST LIMIT 300`,
      scope.coCode,
    );
    const receivables: ReceivableReminder[] = recRows.map((r) => {
      const crDays = Number(r.crdays) || 0;
      const oldest = Number(r.oldest) || 0;
      const daysOverdue = oldest - crDays;
      return {
        acCode: String(r.ac),
        acName: String(r.nm ?? r.ac),
        mobile: String(r.mob ?? ''),
        outstanding: r2(Number(r.os) || 0),
        goldOs: Math.round((Number(r.gos) || 0) * 1000) / 1000,
        silverOs: Math.round((Number(r.sos) || 0) * 1000) / 1000,
        crDays,
        oldestAgeDays: oldest,
        daysOverdue,
        overdue: daysOverdue > 0,
      };
    });

    const ordRows: any[] = await tx.$queryRawUnsafe(
      `SELECT "VCH_NO" vch, "AC_CODE" ac, coalesce("AC_NAME",'') nm, "DEL_DATE"::text dd, coalesce(NULLIF("TOT_AMT"::text,'')::numeric,0)::float tot,
              ("DEL_DATE"::date - CURRENT_DATE)::int dtd
       FROM "SL_ORD_DATA" WHERE "CO_CODE"=$1 AND "DEL_DATE" IS NOT NULL ORDER BY "DEL_DATE" ASC LIMIT 200`,
      scope.coCode,
    );
    const ordersDue: OrderReminder[] = ordRows
      .map((r) => {
        const dtd = r.dtd == null ? null : Number(r.dtd);
        return {
          vchNo: String(r.vch),
          acCode: String(r.ac ?? ''),
          acName: String(r.nm ?? ''),
          delDate: r.dd ? String(r.dd).slice(0, 10) : null,
          total: r2(Number(r.tot) || 0),
          daysToDelivery: dtd,
          overdue: dtd != null && dtd < 0,
        };
      })
      .filter((o) => o.daysToDelivery == null || o.daysToDelivery <= win || o.overdue);

    return {
      receivables,
      ordersDue,
      summary: {
        overdueParties: receivables.filter((r) => r.overdue).length,
        totalOutstanding: r2(receivables.reduce((s, r) => s + r.outstanding, 0)),
        ordersDue: ordersDue.length,
        ordersOverdue: ordersDue.filter((o) => o.overdue).length,
      },
    };
  });
}
