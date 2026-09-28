import { withTenant } from '@datacare/db';
import { applyFilters } from './reportFilters.js';
import type { ReportScope } from './reports.js';

const text = (v: unknown): string | null => {
  const s = String(v ?? '').trim();
  return s ? s : null;
};
const num = (v: unknown): number => {
  const n = Number(v ?? 0);
  return Number.isFinite(n) ? n : 0;
};
const date = (v: unknown): string | null => {
  if (v instanceof Date) return v.toISOString().slice(0, 10);
  const s = text(v);
  return s ? s.slice(0, 10) : null;
};
const todayIso = (): string => new Date().toISOString().slice(0, 10);

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

function scopedWhere(
  alias: string,
  s: ReportScope,
  params: unknown[],
  dateColumn = 'VCH_DATE',
): string[] {
  const { fromDate, toDate } = range(s);
  params.push(s.tenantId, s.coCode, fromDate, toDate);
  const where = [
    `${alias}.tenant_id=$1`,
    `${alias}."CO_CODE"::text=$2`,
    `${alias}."${dateColumn}" >= $3::date`,
    `${alias}."${dateColumn}" <= $4::date`,
  ];
  if (s.lcCode) {
    params.push(s.lcCode);
    where.push(`${alias}."LC_CODE"::text=$${params.length}`);
  }
  if (s.coYear) {
    params.push(s.coYear);
    where.push(`${alias}."CO_YEAR"::text=$${params.length}`);
  }
  return where;
}

export type ApprovalReportMode = 'issue' | 'inout' | 'pending';
export type KarigarReportMode = 'issue' | 'receive';
export type RepairReportMode =
  | 'customer-receipt'
  | 'karigar-issue-pending'
  | 'karigar-issue'
  | 'karigar-receipt-pending'
  | 'karigar-receipt'
  | 'customer-issue'
  | 'customer-issue-pending';
export type VpReportMode =
  | 'vp-issue'
  | 'vp-pending'
  | 'vp-adjusted'
  | 'angdiya-issue'
  | 'angdiya-pending'
  | 'angdiya-adjusted';
export type BullionReportMode =
  | 'sales-booking'
  | 'purchase-booking'
  | 'sales-adjusted'
  | 'purchase-adjusted'
  | 'sales-pending'
  | 'purchase-pending';

export interface ReportFamilyOptions<TMode extends string> {
  mode?: TMode | string;
}

interface LineReportRow {
  srNo: number;
  reportType: string;
  mode: string;
  crystalReport: string;
  coYear: string | null;
  coBook: string | null;
  bookName: string | null;
  vchNo: string | null;
  vchDate: string | null;
  acCode: string | null;
  acName: string | null;
  city: string | null;
  area: string | null;
  itemCode: string | null;
  itemName: string | null;
  tagNo: string | null;
  designNo: string | null;
  pcs: number;
  grossWt: number;
  netWt: number;
  fineWt: number;
  itemAmount: number;
  labourAmount: number;
  otherAmount: number;
  netAmount: number;
  status: string | null;
  mainUser: string | null;
}

function mapLineRow(r: Record<string, unknown>): LineReportRow {
  return {
    srNo: num(r.srNo),
    reportType: text(r.reportType) ?? '',
    mode: text(r.mode) ?? '',
    crystalReport: text(r.crystalReport) ?? '',
    coYear: text(r.coYear),
    coBook: text(r.coBook),
    bookName: text(r.bookName),
    vchNo: text(r.vchNo),
    vchDate: date(r.vchDate),
    acCode: text(r.acCode),
    acName: text(r.acName),
    city: text(r.city),
    area: text(r.area),
    itemCode: text(r.itemCode),
    itemName: text(r.itemName),
    tagNo: text(r.tagNo),
    designNo: text(r.designNo),
    pcs: num(r.pcs),
    grossWt: num(r.grossWt),
    netWt: num(r.netWt),
    fineWt: num(r.fineWt),
    itemAmount: num(r.itemAmount),
    labourAmount: num(r.labourAmount),
    otherAmount: num(r.otherAmount),
    netAmount: num(r.netAmount),
    status: text(r.status),
    mainUser: text(r.mainUser),
  };
}

const approvalModes: Record<
  ApprovalReportMode,
  { label: string; crystal: string; pending?: boolean }
> = {
  issue: { label: 'Party Wise Approval Issue', crystal: 'AprPartyWise' },
  inout: { label: 'Approval In Out', crystal: 'AprInOut' },
  pending: { label: 'Pending Approval', crystal: 'AprPan', pending: true },
};

function approvalMode(value: unknown): ApprovalReportMode {
  return value === 'inout' || value === 'pending' ? value : 'issue';
}

/** Desktop `RP_ALL` / `Approval Rpt` subset over APR_DETL. */
export async function approvalReport(
  prisma: any,
  s: ReportScope,
  options: ReportFamilyOptions<ApprovalReportMode> = {},
): Promise<{ rows: LineReportRow[] }> {
  return withTenant(prisma, s.tenantId, async (tx: any) => {
    const mode = approvalMode(options.mode);
    const spec = approvalModes[mode];
    const params: unknown[] = [];
    const where = scopedWhere('a', s, params);
    where.push(`b."MAIN_BOOK"::text='APR ISU'`);
    if (spec.pending) where.push(`coalesce(a."ISU_REC",'N')='N'`);
    const filterSql = applyFilters('approval-report', s.filters, params);
    const rows = await tx.$queryRawUnsafe(
      `SELECT row_number() OVER (ORDER BY a."VCH_DATE",a."CO_BOOK",a."VCH_NO",a."SR_NO") AS "srNo",
              $${params.length + 1}::text AS "reportType",
              $${params.length + 2}::text AS "mode",
              $${params.length + 3}::text AS "crystalReport",
              a."CO_YEAR" AS "coYear",a."CO_BOOK" AS "coBook",coalesce(a."BOOK_NAME",b."BOOK_NAME") AS "bookName",
              a."VCH_NO" AS "vchNo",a."VCH_DATE"::text AS "vchDate",
              a."AC_CODE" AS "acCode",coalesce(a."ISU_AC_NAME",m."AC_NAME") AS "acName",
              m."AC_CITY" AS "city",m."AC_AREA" AS "area",
              a."IT_CODE" AS "itemCode",i."IT_NAME" AS "itemName",a."TAG_NO" AS "tagNo",a."DESIGN_NO" AS "designNo",
              coalesce(a."ITM_PCS",0) AS "pcs",coalesce(a."ITM_GWT",0) AS "grossWt",
              coalesce(a."ITM_NWT",0) AS "netWt",coalesce(a."ITM_FINE",0) AS "fineWt",
              coalesce(a."ITM_AMT",0) AS "itemAmount",coalesce(a."LBR_AMT",0) AS "labourAmount",
              coalesce(a."OTH_AMT",0) AS "otherAmount",coalesce(a."NET_AMT",0) AS "netAmount",
              a."ISU_REC" AS "status",a."MAIN_USER" AS "mainUser"
         FROM "APR_DETL" a
         LEFT JOIN "BOOK_DATA" b
           ON b.tenant_id=a.tenant_id AND b."CO_CODE"::text=a."CO_CODE"::text AND b."CO_BOOK"::text=a."CO_BOOK"::text
         LEFT JOIN "AC_MAST" m
           ON m.tenant_id=a.tenant_id AND m."CO_CODE"::text=a."CO_CODE"::text AND m."AC_CODE"::text=a."AC_CODE"::text
         LEFT JOIN "ITEM_MAST" i
           ON i.tenant_id=a.tenant_id AND i."CO_CODE"::text=a."CO_CODE"::text AND i."IT_CODE"::text=a."IT_CODE"::text
        WHERE ${where.join(' AND ')}${filterSql}
        ORDER BY a."VCH_DATE",a."CO_BOOK",a."VCH_NO",a."SR_NO"`,
      ...params,
      spec.label,
      mode,
      spec.crystal,
    );
    return { rows: (rows as Array<Record<string, unknown>>).map(mapLineRow) };
  });
}

const karigarModes: Record<
  KarigarReportMode,
  { label: string; crystal: string; bookName: string }
> = {
  issue: { label: 'Karigar Item Issue', crystal: 'KrIsuReport', bookName: 'KARIGAR ISSUE' },
  receive: { label: 'Karigar Item Receipt', crystal: 'KrRecReport', bookName: 'KARIGAR RECEIPT' },
};

function karigarMode(value: unknown): KarigarReportMode {
  return value === 'receive' ? 'receive' : 'issue';
}

/** Desktop `RP_ALL` / `Kr Report` subset over KR_DETL. */
export async function karigarReport(
  prisma: any,
  s: ReportScope,
  options: ReportFamilyOptions<KarigarReportMode> = {},
): Promise<{ rows: LineReportRow[] }> {
  return withTenant(prisma, s.tenantId, async (tx: any) => {
    const mode = karigarMode(options.mode);
    const spec = karigarModes[mode];
    const params: unknown[] = [];
    const where = scopedWhere('d', s, params);
    params.push(spec.bookName);
    where.push(`d."BOOK_NAME"::text=$${params.length}`);
    const filterSql = applyFilters('karigar-report', s.filters, params);
    const rows = await tx.$queryRawUnsafe(
      `SELECT row_number() OVER (ORDER BY d."VCH_DATE",d."CO_BOOK",d."VCH_NO",d."SR_NO") AS "srNo",
              $${params.length + 1}::text AS "reportType",
              $${params.length + 2}::text AS "mode",
              $${params.length + 3}::text AS "crystalReport",
              d."CO_YEAR" AS "coYear",d."CO_BOOK" AS "coBook",d."BOOK_NAME" AS "bookName",
              d."VCH_NO" AS "vchNo",d."VCH_DATE"::text AS "vchDate",
              d."AC_CODE" AS "acCode",coalesce(k."AC_NAME",m."AC_NAME") AS "acName",
              m."AC_CITY" AS "city",m."AC_AREA" AS "area",
              d."IT_CODE" AS "itemCode",i."IT_NAME" AS "itemName",d."TAG_NO" AS "tagNo",d."DESIGN_NO" AS "designNo",
              coalesce(d."ITM_PCS",0) AS "pcs",coalesce(d."ITM_GWT",0) AS "grossWt",
              coalesce(d."ITM_NWT",0) AS "netWt",coalesce(d."ITM_FINE",0) AS "fineWt",
              coalesce(d."ITM_AMT",0) AS "itemAmount",coalesce(d."LBR_AMT",0) AS "labourAmount",
              coalesce(d."OTH_AMT",0) AS "otherAmount",coalesce(d."NET_AMT",0) AS "netAmount",
              d."BOOK_NAME" AS "status",d."MAIN_USER" AS "mainUser"
         FROM "KR_DETL" d
         LEFT JOIN "KR_DATA" k
           ON k.tenant_id=d.tenant_id AND k."CO_CODE"::text=d."CO_CODE"::text AND k."LC_CODE"::text=d."LC_CODE"::text
          AND k."CO_YEAR"::text=d."CO_YEAR"::text AND k."CO_BOOK"::text=d."CO_BOOK"::text AND k."VCH_NO"::text=d."VCH_NO"::text
         LEFT JOIN "AC_MAST" m
           ON m.tenant_id=d.tenant_id AND m."CO_CODE"::text=d."CO_CODE"::text AND m."AC_CODE"::text=d."AC_CODE"::text
         LEFT JOIN "ITEM_MAST" i
           ON i.tenant_id=d.tenant_id AND i."CO_CODE"::text=d."CO_CODE"::text AND i."IT_CODE"::text=d."IT_CODE"::text
        WHERE ${where.join(' AND ')}${filterSql}
        ORDER BY d."VCH_DATE",d."CO_BOOK",d."VCH_NO",d."SR_NO"`,
      ...params,
      spec.label,
      mode,
      spec.crystal,
    );
    return { rows: (rows as Array<Record<string, unknown>>).map(mapLineRow) };
  });
}

const repairModes: Record<
  RepairReportMode,
  { label: string; crystal: string; bookName: string; pendingColumn?: 'ISU_ADJ' }
> = {
  'customer-receipt': {
    label: 'Customer Repair Received Item',
    crystal: 'CustRepRec',
    bookName: 'CUSTREP RECEIPT',
  },
  'karigar-issue-pending': {
    label: 'Repairing Item Issue Pending',
    crystal: 'CustRepRec',
    bookName: 'CUSTREP RECEIPT',
    pendingColumn: 'ISU_ADJ',
  },
  'karigar-issue': {
    label: 'Repairing Issue To Karigar',
    crystal: 'CustRepRec',
    bookName: 'KRREP ISSUE',
  },
  'karigar-receipt-pending': {
    label: 'Karigar Repairing Receipt Pending',
    crystal: 'CustRepRec',
    bookName: 'KRREP ISSUE',
    pendingColumn: 'ISU_ADJ',
  },
  'karigar-receipt': {
    label: 'Karigar Repairing Receipt',
    crystal: 'KrRepRec',
    bookName: 'KRREP RECEIPT',
  },
  'customer-issue': {
    label: 'Customer Repairing Issue',
    crystal: 'CustRepIsu',
    bookName: 'CUSTREP ISSUE',
  },
  'customer-issue-pending': {
    label: 'Customer Repairing Issue Pending',
    crystal: 'KrRepRec',
    bookName: 'KRREP RECEIPT',
    pendingColumn: 'ISU_ADJ',
  },
};

function repairMode(value: unknown): RepairReportMode {
  return Object.prototype.hasOwnProperty.call(repairModes, String(value ?? ''))
    ? (String(value) as RepairReportMode)
    : 'customer-receipt';
}

/** Desktop `RP_ALL` / `Reparing Rpt` subset over REP_DETL. */
export async function repairReport(
  prisma: any,
  s: ReportScope,
  options: ReportFamilyOptions<RepairReportMode> = {},
): Promise<{ rows: LineReportRow[] }> {
  return withTenant(prisma, s.tenantId, async (tx: any) => {
    const mode = repairMode(options.mode);
    const spec = repairModes[mode];
    const params: unknown[] = [];
    const where = scopedWhere('d', s, params);
    params.push(spec.bookName);
    where.push(`d."BOOK_NAME"::text=$${params.length}`);
    if (spec.pendingColumn) where.push(`coalesce(d."${spec.pendingColumn}",'N')='N'`);
    const filterSql = applyFilters('repair-report', s.filters, params);
    const rows = await tx.$queryRawUnsafe(
      `SELECT row_number() OVER (ORDER BY d."VCH_DATE",d."CO_BOOK",d."VCH_NO",d."SR_NO") AS "srNo",
              $${params.length + 1}::text AS "reportType",
              $${params.length + 2}::text AS "mode",
              $${params.length + 3}::text AS "crystalReport",
              d."CO_YEAR" AS "coYear",d."CO_BOOK" AS "coBook",d."BOOK_NAME" AS "bookName",
              d."VCH_NO" AS "vchNo",d."VCH_DATE"::text AS "vchDate",
              d."AC_CODE" AS "acCode",coalesce(h."AC_NAME",m."AC_NAME") AS "acName",
              m."AC_CITY" AS "city",m."AC_AREA" AS "area",
              d."IT_CODE" AS "itemCode",coalesce(d."IT_NAME",i."IT_NAME") AS "itemName",d."TAG_NO" AS "tagNo",d."DESIGN_NO" AS "designNo",
              coalesce(d."ITM_PCS",0) AS "pcs",coalesce(d."ITM_GWT",0) AS "grossWt",
              coalesce(d."ITM_NWT",0) AS "netWt",coalesce(d."ITM_FINE",0) AS "fineWt",
              coalesce(d."ITM_AMT",0) AS "itemAmount",coalesce(d."LBR_AMT",0) AS "labourAmount",
              coalesce(d."OTH_AMT",0) AS "otherAmount",coalesce(d."NET_AMT",0) AS "netAmount",
              concat('REP_ADJ=',coalesce(d."REP_ADJ",''),' ISU_ADJ=',coalesce(d."ISU_ADJ",'')) AS "status",
              d."MAIN_USER" AS "mainUser"
         FROM "REP_DETL" d
         LEFT JOIN "REP_DATA" h
           ON h.tenant_id=d.tenant_id AND h."CO_CODE"::text=d."CO_CODE"::text AND h."LC_CODE"::text=d."LC_CODE"::text
          AND h."CO_YEAR"::text=d."CO_YEAR"::text AND h."CO_BOOK"::text=d."CO_BOOK"::text AND h."VCH_NO"::text=d."VCH_NO"::text
         LEFT JOIN "AC_MAST" m
           ON m.tenant_id=d.tenant_id AND m."CO_CODE"::text=d."CO_CODE"::text AND m."AC_CODE"::text=d."AC_CODE"::text
         LEFT JOIN "ITEM_MAST" i
           ON i.tenant_id=d.tenant_id AND i."CO_CODE"::text=d."CO_CODE"::text AND i."IT_CODE"::text=d."IT_CODE"::text
        WHERE ${where.join(' AND ')}${filterSql}
        ORDER BY d."VCH_DATE",d."CO_BOOK",d."VCH_NO",d."SR_NO"`,
      ...params,
      spec.label,
      mode,
      spec.crystal,
    );
    return { rows: (rows as Array<Record<string, unknown>>).map(mapLineRow) };
  });
}

interface VpReportRow {
  srNo: number;
  reportType: string;
  mode: string;
  crystalReport: string;
  coYear: string | null;
  coBook: string | null;
  vchNo: string | null;
  vchDate: string | null;
  acCode: string | null;
  acName: string | null;
  city: string | null;
  area: string | null;
  angdiyaCode: string | null;
  fineWt: number;
  itemAmount: number;
  netAmount: number;
  vpAmount: number;
  vpAdjustedAmount: number;
  vpPendingAmount: number;
  mainUser: string | null;
}

const vpModes: Record<
  VpReportMode,
  { label: string; crystal: string; pending?: 'open' | 'closed' }
> = {
  'vp-issue': { label: 'VP Issue', crystal: 'VpIsuRpt' },
  'vp-pending': { label: 'VP Pending', crystal: 'VpIsuRpt', pending: 'open' },
  'vp-adjusted': { label: 'VP Adjusted', crystal: 'VpIsuRpt', pending: 'closed' },
  'angdiya-issue': { label: 'Angdiya Issue', crystal: 'AngdiyaIsuRpt' },
  'angdiya-pending': { label: 'Angdiya Pending', crystal: 'AngdiyaIsuRpt', pending: 'open' },
  'angdiya-adjusted': { label: 'Angdiya Adjusted', crystal: 'AngdiyaIsuRpt', pending: 'closed' },
};

function vpMode(value: unknown): VpReportMode {
  return Object.prototype.hasOwnProperty.call(vpModes, String(value ?? ''))
    ? (String(value) as VpReportMode)
    : 'vp-issue';
}

/** Desktop `RP_ALL` / `Vp Report` subset over RATE_CUT_DATA book 215. */
export async function vpReport(
  prisma: any,
  s: ReportScope,
  options: ReportFamilyOptions<VpReportMode> = {},
): Promise<{ rows: VpReportRow[] }> {
  return withTenant(prisma, s.tenantId, async (tx: any) => {
    const mode = vpMode(options.mode);
    const spec = vpModes[mode];
    const params: unknown[] = [];
    const where = scopedWhere('r', s, params);
    where.push(`r."CO_BOOK"::text='215'`);
    if (spec.pending === 'open')
      where.push(`(coalesce(r."VP_AMT",0)-coalesce(r."VP_ADJ_AMT",0)) <> 0`);
    if (spec.pending === 'closed')
      where.push(`(coalesce(r."VP_AMT",0)-coalesce(r."VP_ADJ_AMT",0)) = 0`);
    const filterSql = applyFilters('vp-report', s.filters, params);
    const rows = (await tx.$queryRawUnsafe(
      `SELECT row_number() OVER (ORDER BY r."VCH_DATE",r."CO_BOOK",r."VCH_NO") AS "srNo",
              $${params.length + 1}::text AS "reportType",
              $${params.length + 2}::text AS "mode",
              $${params.length + 3}::text AS "crystalReport",
              r."CO_YEAR" AS "coYear",r."CO_BOOK" AS "coBook",r."VCH_NO" AS "vchNo",r."VCH_DATE"::text AS "vchDate",
              r."AC_CODE" AS "acCode",coalesce(r."AC_NAME",m."AC_NAME") AS "acName",
              m."AC_CITY" AS "city",m."AC_AREA" AS "area",r."AC_ANGDIYA" AS "angdiyaCode",
              coalesce(r."SL_FINE",0) AS "fineWt",coalesce(r."SL_ITM_AMT",0) AS "itemAmount",
              coalesce(r."SL_NET_AMT",0) AS "netAmount",coalesce(r."VP_AMT",0) AS "vpAmount",
              coalesce(r."VP_ADJ_AMT",0) AS "vpAdjustedAmount",
              coalesce(r."VP_AMT",0)-coalesce(r."VP_ADJ_AMT",0) AS "vpPendingAmount",
              r."MAIN_USER" AS "mainUser"
         FROM "RATE_CUT_DATA" r
         LEFT JOIN "AC_MAST" m
           ON m.tenant_id=r.tenant_id AND m."CO_CODE"::text=r."CO_CODE"::text AND m."AC_CODE"::text=r."AC_CODE"::text
        WHERE ${where.join(' AND ')}${filterSql}
        ORDER BY r."VCH_DATE",r."CO_BOOK",r."VCH_NO"`,
      ...params,
      spec.label,
      mode,
      spec.crystal,
    )) as Array<Record<string, unknown>>;
    return {
      rows: rows.map((r) => ({
        srNo: num(r.srNo),
        reportType: text(r.reportType) ?? '',
        mode: text(r.mode) ?? '',
        crystalReport: text(r.crystalReport) ?? '',
        coYear: text(r.coYear),
        coBook: text(r.coBook),
        vchNo: text(r.vchNo),
        vchDate: date(r.vchDate),
        acCode: text(r.acCode),
        acName: text(r.acName),
        city: text(r.city),
        area: text(r.area),
        angdiyaCode: text(r.angdiyaCode),
        fineWt: num(r.fineWt),
        itemAmount: num(r.itemAmount),
        netAmount: num(r.netAmount),
        vpAmount: num(r.vpAmount),
        vpAdjustedAmount: num(r.vpAdjustedAmount),
        vpPendingAmount: num(r.vpPendingAmount),
        mainUser: text(r.mainUser),
      })),
    };
  });
}

interface BullionReportRow {
  srNo: number;
  reportType: string;
  mode: string;
  crystalReport: string;
  coYear: string | null;
  coBook: string | null;
  bookName: string | null;
  vchNo: string | null;
  vchDate: string | null;
  inoutType: string | null;
  acCode: string | null;
  acName: string | null;
  city: string | null;
  area: string | null;
  itemCode: string | null;
  itemName: string | null;
  grossWt: number;
  netWt: number;
  adjustedWt: number;
  pendingWt: number;
  rate: number;
  itemAmount: number;
  premiumAmount: number;
  taxPercent: number;
  totalAmount: number;
  mainUser: string | null;
}

const bullionModes: Record<
  BullionReportMode,
  { label: string; crystal: string; inout: 'I' | 'O'; saleBook?: boolean; pending?: boolean }
> = {
  'sales-booking': {
    label: 'Sales Booking',
    crystal: 'BulCustBooking',
    inout: 'O',
    saleBook: true,
  },
  'purchase-booking': { label: 'Purchase Booking', crystal: 'BulCustBooking', inout: 'I' },
  'sales-adjusted': {
    label: 'Sales Booking Adjust',
    crystal: 'BulCustAdjust',
    inout: 'O',
    saleBook: true,
  },
  'purchase-adjusted': { label: 'Purchase Booking Adjust', crystal: 'BulCustAdjust', inout: 'I' },
  'sales-pending': {
    label: 'Sales Booking Pending',
    crystal: 'BulCustAdjust',
    inout: 'O',
    saleBook: true,
    pending: true,
  },
  'purchase-pending': {
    label: 'Purchase Booking Pending',
    crystal: 'BulCustAdjust',
    inout: 'I',
    pending: true,
  },
};

function bullionMode(value: unknown): BullionReportMode {
  return Object.prototype.hasOwnProperty.call(bullionModes, String(value ?? ''))
    ? (String(value) as BullionReportMode)
    : 'sales-booking';
}

/** Desktop `RP_ALL` / `Bul Report` subset over BUL_DATA. */
export async function bullionReport(
  prisma: any,
  s: ReportScope,
  options: ReportFamilyOptions<BullionReportMode> = {},
): Promise<{ rows: BullionReportRow[] }> {
  return withTenant(prisma, s.tenantId, async (tx: any) => {
    const mode = bullionMode(options.mode);
    const spec = bullionModes[mode];
    const params: unknown[] = [];
    const where = scopedWhere('b', s, params);
    params.push(spec.inout);
    where.push(`b."INOUT_TYPE"::text=$${params.length}`);
    if (spec.saleBook) where.push(`b."BOOK_NAME"::text='BUL SALE'`);
    if (spec.pending) where.push(`(coalesce(b."ITM_GWT",0)-coalesce(b."ADJ_WT",0)) > 0`);
    const filterSql = applyFilters('bullion-report', s.filters, params);
    const rows = (await tx.$queryRawUnsafe(
      `SELECT row_number() OVER (ORDER BY b."VCH_DATE",b."CO_BOOK",b."VCH_NO",b."SR_NO") AS "srNo",
              $${params.length + 1}::text AS "reportType",
              $${params.length + 2}::text AS "mode",
              $${params.length + 3}::text AS "crystalReport",
              b."CO_YEAR" AS "coYear",b."CO_BOOK" AS "coBook",b."BOOK_NAME" AS "bookName",
              b."VCH_NO" AS "vchNo",b."VCH_DATE"::text AS "vchDate",b."INOUT_TYPE" AS "inoutType",
              b."AC_CODE" AS "acCode",m."AC_NAME" AS "acName",m."AC_CITY" AS "city",m."AC_AREA" AS "area",
              b."IT_CODE" AS "itemCode",i."IT_NAME" AS "itemName",
              coalesce(b."ITM_GWT",0) AS "grossWt",coalesce(b."ITM_NWT",0) AS "netWt",
              coalesce(b."ADJ_WT",0) AS "adjustedWt",coalesce(b."ITM_GWT",0)-coalesce(b."ADJ_WT",0) AS "pendingWt",
              coalesce(b."ITM_RATE",0) AS "rate",coalesce(b."ITM_AMT",0) AS "itemAmount",
              coalesce(b."PRM_AMT",0) AS "premiumAmount",coalesce(b."TAX_PRC",0) AS "taxPercent",
              coalesce(b."TOT_AMT",0) AS "totalAmount",b."MAIN_USER" AS "mainUser"
         FROM "BUL_DATA" b
         LEFT JOIN "AC_MAST" m
           ON m.tenant_id=b.tenant_id AND m."CO_CODE"::text=b."CO_CODE"::text AND m."AC_CODE"::text=b."AC_CODE"::text
         LEFT JOIN "ITEM_MAST" i
           ON i.tenant_id=b.tenant_id AND i."CO_CODE"::text=b."CO_CODE"::text AND i."IT_CODE"::text=b."IT_CODE"::text
        WHERE ${where.join(' AND ')}${filterSql}
        ORDER BY b."VCH_DATE",b."CO_BOOK",b."VCH_NO",b."SR_NO"`,
      ...params,
      spec.label,
      mode,
      spec.crystal,
    )) as Array<Record<string, unknown>>;
    return {
      rows: rows.map((r) => ({
        srNo: num(r.srNo),
        reportType: text(r.reportType) ?? '',
        mode: text(r.mode) ?? '',
        crystalReport: text(r.crystalReport) ?? '',
        coYear: text(r.coYear),
        coBook: text(r.coBook),
        bookName: text(r.bookName),
        vchNo: text(r.vchNo),
        vchDate: date(r.vchDate),
        inoutType: text(r.inoutType),
        acCode: text(r.acCode),
        acName: text(r.acName),
        city: text(r.city),
        area: text(r.area),
        itemCode: text(r.itemCode),
        itemName: text(r.itemName),
        grossWt: num(r.grossWt),
        netWt: num(r.netWt),
        adjustedWt: num(r.adjustedWt),
        pendingWt: num(r.pendingWt),
        rate: num(r.rate),
        itemAmount: num(r.itemAmount),
        premiumAmount: num(r.premiumAmount),
        taxPercent: num(r.taxPercent),
        totalAmount: num(r.totalAmount),
        mainUser: text(r.mainUser),
      })),
    };
  });
}
