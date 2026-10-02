import { withTxBudget } from '../shared/txBudget.js';
import { applyFilters } from './reportFilters.js';
import type { ReportScope } from './reports.js';

const t = (v: unknown): string | null => {
  const s = String(v ?? '').trim();
  return s ? s : null;
};
const n = (v: unknown): number => {
  const out = Number(v ?? 0);
  return Number.isFinite(out) ? out : 0;
};
const d = (v: unknown): string | null => {
  if (v instanceof Date) return v.toISOString().slice(0, 10);
  const s = t(v);
  return s ? s.slice(0, 10) : null;
};
const todayIso = (): string => new Date().toISOString().slice(0, 10);

export interface DhrnLoanReportOptions {
  /** `D` = Dhiran Report, `L` = Loan Report. */
  entryType: 'D' | 'L';
  /** Desktop buttons represented as views. */
  mode?: 'register' | 'pending';
  /** Desktop combo values: Amount/Gold/Silver -> A/G/S. */
  loanType?: string;
  packetNo?: string;
  refNo?: string;
  refAc?: string;
}

export interface DhrnLoanReportRow {
  srNo: number;
  reportType: string;
  mode: string;
  coYear: string | null;
  coBook: string | null;
  vchNo: string | null;
  vchDate: string | null;
  acCode: string | null;
  acName: string | null;
  city: string | null;
  area: string | null;
  refAccount: string | null;
  packetNo: string | null;
  refNo: string | null;
  loanType: string | null;
  principalAmount: number;
  receivedAmount: number;
  uncheckedReceived: number;
  interestAmount: number;
  interestReceived: number;
  outstandingAmount: number;
  goldWeight: number;
  silverWeight: number;
  dueDate: string | null;
  mainUser: string | null;
}

function range(s: ReportScope): { fromDate: string; toDate: string } {
  const fromDate = s.fromDate ?? '2010-04-01';
  const toDate = s.toDate ?? todayIso();
  if (fromDate > toDate) {
    const err = new Error('fromDate must be before or equal to toDate');
    err.name = 'ReportValidationError';
    throw err;
  }
  return { fromDate, toDate };
}

const loanTypeCode = (value: unknown): string => {
  const s = String(value ?? '')
    .trim()
    .slice(0, 1)
    .toUpperCase();
  return ['A', 'G', 'S'].includes(s) ? s : 'A';
};

/** Desktop `RP_DHRN_LOAN` report family for Dhiran Report and Loan Report. */
export async function dhrnLoanReport(
  prisma: any,
  s: ReportScope,
  options: DhrnLoanReportOptions,
): Promise<{ rows: DhrnLoanReportRow[] }> {
  return withTxBudget(prisma, s.tenantId, 'read', async (tx: any) => {
    const { fromDate, toDate } = range(s);
    const mode = options.mode === 'pending' ? 'pending' : 'register';
    const params: unknown[] = [
      s.tenantId,
      s.coCode,
      options.entryType,
      loanTypeCode(options.loanType),
      fromDate,
      toDate,
    ];
    const where = [
      'i.tenant_id=$1',
      'i."CO_CODE"::text=$2',
      'i."ENTRY_TYPE"::text=$3',
      'i."LOAN_TYPE"::text=$4',
      'i."VCH_DATE" >= $5::date',
      'i."VCH_DATE" <= $6::date',
    ];
    if (s.lcCode) {
      params.push(s.lcCode);
      where.push(`i."LC_CODE"::text=$${params.length}`);
    }
    if (s.coYear) {
      params.push(s.coYear);
      where.push(`i."CO_YEAR"::text=$${params.length}`);
    }
    const packetNo = String(options.packetNo ?? '')
      .trim()
      .slice(0, 20);
    if (packetNo) {
      params.push(packetNo);
      where.push(`i."PACKET_NO"::text=$${params.length}`);
    }
    const refNo = String(options.refNo ?? '')
      .trim()
      .slice(0, 20);
    if (refNo) {
      params.push(refNo);
      where.push(`i."DHRN_BILL"::text=$${params.length}`);
    }
    const refAc = String(options.refAc ?? '')
      .trim()
      .slice(0, 12);
    if (refAc) {
      params.push(refAc);
      where.push(`m."AC_REF_CODE"::text=$${params.length}`);
    }
    const filterSql = applyFilters(
      options.entryType === 'L' ? 'loan-report' : 'dhiran-report',
      s.filters,
      params,
    );
    const pendingSql =
      mode === 'pending'
        ? ' AND (coalesce(i."DHRN_AMT",0)-coalesce(r."receivedAmount",i."DHRN_REC_AMT",0)) > 0'
        : '';

    const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `WITH receipts AS (
         SELECT d.tenant_id,d."CO_CODE",d."ISU_LC",d."ISU_YRCD",d."ISU_DBCD",d."ISU_NO",
                sum(coalesce(d."DHRN_REC_AMT",0)) AS "receivedAmount",
                sum(coalesce(d."UNCHAK_DHRN_REC",0)) AS "uncheckedReceived",
                sum(coalesce(d."INT_AMT",0)) AS "interestAmount",
                sum(coalesce(d."INT_REC_AMT",0)) AS "interestReceived"
           FROM "DHRN_DATA" d
          WHERE d.tenant_id=$1 AND d."CO_CODE"::text=$2
          GROUP BY d.tenant_id,d."CO_CODE",d."ISU_LC",d."ISU_YRCD",d."ISU_DBCD",d."ISU_NO"
       )
       SELECT row_number() OVER (ORDER BY i."VCH_DATE",i."CO_BOOK",i."VCH_NO") AS "srNo",
              CASE WHEN $3='L' THEN 'Loan Report' ELSE 'Dhiran Report' END AS "reportType",
              $${params.length + 1}::text AS "mode",
              i."CO_YEAR" AS "coYear",i."CO_BOOK" AS "coBook",i."VCH_NO" AS "vchNo",
              i."VCH_DATE"::text AS "vchDate",i."AC_CODE" AS "acCode",coalesce(i."AC_NAME",m."AC_NAME") AS "acName",
              m."AC_CITY" AS "city",m."AC_AREA" AS "area",m."AC_REF_CODE" AS "refAccount",
              i."PACKET_NO" AS "packetNo",i."DHRN_BILL" AS "refNo",i."LOAN_TYPE" AS "loanType",
              coalesce(i."DHRN_AMT",0) AS "principalAmount",
              coalesce(r."receivedAmount",i."DHRN_REC_AMT",0) AS "receivedAmount",
              coalesce(r."uncheckedReceived",i."UNCHAK_DHRN_REC",0) AS "uncheckedReceived",
              coalesce(r."interestAmount",i."INT_AMT",0) AS "interestAmount",
              coalesce(r."interestReceived",i."INT_REC_AMT",0) AS "interestReceived",
              coalesce(i."DHRN_AMT",0)-coalesce(r."receivedAmount",i."DHRN_REC_AMT",0) AS "outstandingAmount",
              coalesce(i."GOLD_NWT",i."GOLD_WT",0) AS "goldWeight",coalesce(i."SILVER_NWT",0) AS "silverWeight",
              i."DHRN_DUE_DATE"::text AS "dueDate",i."MAIN_USER" AS "mainUser"
         FROM "DHRN_ISU_DATA" i
         LEFT JOIN "AC_MAST" m
           ON m.tenant_id=i.tenant_id AND m."CO_CODE"::text=i."CO_CODE"::text AND m."AC_CODE"::text=i."AC_CODE"::text
         LEFT JOIN receipts r
           ON r.tenant_id=i.tenant_id AND r."CO_CODE"::text=i."CO_CODE"::text AND r."ISU_LC"::text=i."LC_CODE"::text
          AND r."ISU_YRCD"::text=i."CO_YEAR"::text AND r."ISU_DBCD"::text=i."CO_BOOK"::text AND r."ISU_NO"::text=i."VCH_NO"::text
        WHERE ${where.join(' AND ')}${filterSql}${pendingSql}
        ORDER BY i."VCH_DATE",i."CO_BOOK",i."VCH_NO"`,
      ...params,
      mode,
    );
    return {
      rows: rows.map((r) => ({
        srNo: Number(r.srNo ?? 0),
        reportType:
          t(r.reportType) ?? (options.entryType === 'L' ? 'Loan Report' : 'Dhiran Report'),
        mode: t(r.mode) ?? mode,
        coYear: t(r.coYear),
        coBook: t(r.coBook),
        vchNo: t(r.vchNo),
        vchDate: d(r.vchDate),
        acCode: t(r.acCode),
        acName: t(r.acName),
        city: t(r.city),
        area: t(r.area),
        refAccount: t(r.refAccount),
        packetNo: t(r.packetNo),
        refNo: t(r.refNo),
        loanType: t(r.loanType),
        principalAmount: n(r.principalAmount),
        receivedAmount: n(r.receivedAmount),
        uncheckedReceived: n(r.uncheckedReceived),
        interestAmount: n(r.interestAmount),
        interestReceived: n(r.interestReceived),
        outstandingAmount: n(r.outstandingAmount),
        goldWeight: n(r.goldWeight),
        silverWeight: n(r.silverWeight),
        dueDate: d(r.dueDate),
        mainUser: t(r.mainUser),
      })),
    };
  });
}
