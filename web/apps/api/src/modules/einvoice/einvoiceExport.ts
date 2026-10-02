import { round } from '@datacare/core';
import { withTenant } from '@datacare/db';
import type { XlsxColumn, XlsxSheet } from '../reports/xlsx.js';
import { EInvoiceValidationError } from './einvoice.js';

export interface EInvoiceExportScope {
  tenantId: string;
  coCode: string;
  lcCode?: string;
  coYear?: string;
  coBook?: string;
  fromDate?: string;
  toDate?: string;
}

export interface EInvoiceExportOptions {
  coBook?: string;
  fromDate?: string;
  toDate?: string;
}

export type EInvoiceHeaderRow = Record<
  | 'sType'
  | 'rCharg'
  | 'ecomGstn'
  | 'igstOnIntra'
  | 'dockType'
  | 'dockNo'
  | 'dockDate'
  | 'byGstn'
  | 'byLglName'
  | 'byTradName'
  | 'byPos'
  | 'byAdd1'
  | 'byAdd2'
  | 'byLoct'
  | 'byPinCode'
  | 'byState'
  | 'byPhone'
  | 'byMail'
  | 'dispName'
  | 'dispAdd1'
  | 'dispAdd2'
  | 'dispLoct'
  | 'dispPin'
  | 'dispState'
  | 'shipGstn'
  | 'shipLgName'
  | 'shipTradName'
  | 'shipAdd1'
  | 'shipAdd2'
  | 'shipLoct'
  | 'shipPin'
  | 'shipState'
  | 'totTaxableVal'
  | 'sgstAmt'
  | 'cgstAmt'
  | 'igstAmt'
  | 'totCessAmt'
  | 'totStateCess'
  | 'discAmt'
  | 'othCharge'
  | 'rofAmt'
  | 'totInvoiceVal',
  string | number | Date | null
>;

export type EInvoiceItemRow = Record<
  | 'dockType'
  | 'dockNo'
  | 'dockDate'
  | 'slNo'
  | 'product'
  | 'isService'
  | 'hsnCode'
  | 'barCode'
  | 'qty'
  | 'freeQty'
  | 'unit'
  | 'unitRate'
  | 'grossAmt'
  | 'discAmt'
  | 'preTaxVal'
  | 'taxableVal'
  | 'gstPct'
  | 'sgstAmt'
  | 'cgstAmt'
  | 'igstAmt'
  | 'cessPct'
  | 'cessAdVal'
  | 'cessNonVal'
  | 'stateCessPct'
  | 'stateCessAddVal'
  | 'stateCessNonVal'
  | 'otherCharge'
  | 'itemTotal'
  | 'batchName'
  | 'batchExpiry'
  | 'batchWarranty',
  string | number | Date | null
>;

export interface EInvoiceExportData {
  headers: EInvoiceHeaderRow[];
  items: EInvoiceItemRow[];
  filters: {
    coBook: string | null;
    fromDate: string | null;
    toDate: string | null;
  };
}

const t = (v: unknown): string => String(v ?? '').trim();
const n = (v: unknown): number => {
  const x = Number(v ?? 0);
  return Number.isFinite(x) ? x : 0;
};
// GSP export amounts/weights are re-presented from already-persisted sale rows. The desktop e-invoice builder
// passes the stored figures through unchanged (`Convert.ToDecimal(...)`, TR_SL_EBILL.cs:9443-9462), so this
// rounding only trims binary-float noise on values already stored at 2 or 3 decimals; the kernel `round` does
// that without the float helper's wrong-way negative midpoints (N48, G22).
const round2 = (v: number): number => round(v, 2);
const round3 = (v: number): number => round(v, 3);

function isoOrBlank(value: unknown, name: string): string | undefined {
  const s = t(value);
  if (!s) return undefined;
  if (!/^\d{4}-\d{2}-\d{2}$/.test(s)) {
    throw new EInvoiceValidationError(`${name} must be an ISO date (yyyy-mm-dd)`);
  }
  return s;
}

function checkedFilters(scope: EInvoiceExportScope, options: EInvoiceExportOptions) {
  const fromDate = isoOrBlank(options.fromDate ?? scope.fromDate, 'fromDate');
  const toDate = isoOrBlank(options.toDate ?? scope.toDate, 'toDate');
  if (fromDate && toDate && fromDate > toDate) {
    throw new EInvoiceValidationError('fromDate must be on or before toDate');
  }
  const coBook = t(options.coBook ?? scope.coBook) || undefined;
  return { fromDate, toDate, coBook };
}

function scopedWhere(
  scope: EInvoiceExportScope,
  filters: { fromDate?: string; toDate?: string; coBook?: string },
  alias = 'a',
): { sql: string; params: unknown[] } {
  const a = alias ? `${alias}.` : '';
  const params: unknown[] = [scope.tenantId, scope.coCode];
  const parts = [`${a}tenant_id=$1`, `${a}"CO_CODE"::text=$2`];
  if (scope.lcCode) {
    params.push(scope.lcCode);
    parts.push(`${a}"LC_CODE"::text=$${params.length}`);
  }
  if (scope.coYear) {
    params.push(scope.coYear);
    parts.push(`${a}"CO_YEAR"::text=$${params.length}`);
  }
  if (filters.coBook) {
    params.push(filters.coBook);
    parts.push(`${a}"CO_BOOK"::text=$${params.length}`);
  }
  if (filters.fromDate) {
    params.push(filters.fromDate);
    parts.push(`${a}"VCH_DATE" >= $${params.length}::date`);
  }
  if (filters.toDate) {
    params.push(filters.toDate);
    parts.push(`${a}"VCH_DATE" <= $${params.length}::date`);
  }
  return { sql: parts.join(' AND '), params };
}

const bookTypePredicate = `coalesce(e."BOOK_TYPE"::text,'')='T'`;
const docNo = (row: Record<string, unknown>): string =>
  `${t(row.BOOK_SR_NAME) || t(row.CO_BOOK)}-${t(row.VCH_NO)}`;
const dt = (value: unknown): Date | null => {
  if (value instanceof Date) return value;
  const s = t(value);
  if (!s) return null;
  const d = new Date(s);
  return Number.isNaN(d.getTime()) ? null : d;
};

function mapHeader(row: Record<string, unknown>): EInvoiceHeaderRow {
  return {
    sType: 'B2B',
    rCharg: 'No',
    ecomGstn: '',
    igstOnIntra: 'No',
    dockType: 'Tax Invoice',
    dockNo: docNo(row),
    dockDate: dt(row.VCH_DATE),
    byGstn: t(row.AC_GSTNO),
    byLglName: t(row.AC_NAME),
    byTradName: t(row.AC_NAME),
    byPos: t(row.AC_STATE),
    byAdd1: t(row.AC_ADD1),
    byAdd2: t(row.AC_ADD2),
    byLoct: t(row.AC_CITY),
    byPinCode: t(row.AC_PIN),
    byState: t(row.AC_STATE),
    byPhone: t(row.AC_MOBILE),
    byMail: t(row.AC_EMAIL),
    dispName: '',
    dispAdd1: '',
    dispAdd2: '',
    dispLoct: '',
    dispPin: '',
    dispState: '',
    shipGstn: '',
    shipLgName: '',
    shipTradName: '',
    shipAdd1: '',
    shipAdd2: '',
    shipLoct: '',
    shipPin: '',
    shipState: '',
    totTaxableVal: round2(n(row.NET_AMT)),
    sgstAmt: round2(n(row.SGST_TAX)),
    cgstAmt: round2(n(row.CGST_TAX)),
    igstAmt: round2(n(row.IGST_TAX)),
    totCessAmt: 0,
    totStateCess: 0,
    discAmt: 0,
    othCharge: 0,
    rofAmt: 0,
    totInvoiceVal: round2(n(row.TOT_AMT)),
  };
}

function mapItem(row: Record<string, unknown>): EInvoiceItemRow {
  const net = n(row.ItmNetAmt);
  const wt = n(row.ITM_NWT);
  const amountFromNet = net !== 0 && wt !== 0;
  const taxable = round2(amountFromNet ? net : n(row.ITM_AMT));
  const tax = n(row.IT_TAX_AMT);
  const headerIgst = n(row.HDR_IGST_TAX);
  const sgst = headerIgst === 0 && tax !== 0 ? round2(tax / 2) : 0;
  const cgst = headerIgst === 0 && tax !== 0 ? round2(tax / 2) : 0;
  const igst = headerIgst !== 0 ? round2(tax) : 0;
  return {
    dockType: 'Tax Invoice',
    dockNo: docNo(row),
    dockDate: dt(row.VCH_DATE),
    slNo: n(row.SR_NO),
    product: t(row.IT_NAME),
    isService: 'No',
    hsnCode: t(row.HSN_CODE),
    barCode: '',
    qty: round3(wt),
    freeQty: 0,
    unit: 'GRAMMES',
    unitRate: round3(amountFromNet ? net / wt : n(row.ITM_RATE)),
    grossAmt: taxable,
    discAmt: 0,
    preTaxVal: 0,
    taxableVal: taxable,
    gstPct: round3(n(row.TAX_PRC)),
    sgstAmt: sgst,
    cgstAmt: cgst,
    igstAmt: igst,
    cessPct: 0,
    cessAdVal: 0,
    cessNonVal: 0,
    stateCessPct: 0,
    stateCessAddVal: 0,
    stateCessNonVal: 0,
    otherCharge: 0,
    itemTotal: round2(n(row.NET_AMT) + sgst + cgst + igst),
    batchName: '',
    batchExpiry: '',
    batchWarranty: '',
  };
}

export const EINVOICE_HEADER_COLUMNS: XlsxColumn[] = [
  { header: 'SType', key: 'sType', width: 10 },
  { header: 'RCharg', key: 'rCharg', width: 10 },
  { header: 'EcomGstn', key: 'ecomGstn', width: 14 },
  { header: 'IgstOnIntra', key: 'igstOnIntra', width: 14 },
  { header: 'DockType', key: 'dockType', width: 16 },
  { header: 'DockNo', key: 'dockNo', width: 16 },
  { header: 'DockDate', key: 'dockDate', type: 'date', format: 'dd/mm/yyyy', width: 14 },
  { header: 'ByGstn', key: 'byGstn', width: 18 },
  { header: 'ByLglName', key: 'byLglName', width: 24 },
  { header: 'ByTradName', key: 'byTradName', width: 18 },
  { header: 'ByPos', key: 'byPos', width: 10 },
  { header: 'ByAdd1', key: 'byAdd1', width: 24 },
  { header: 'ByAdd2', key: 'byAdd2', width: 18 },
  { header: 'ByLoct', key: 'byLoct', width: 14 },
  { header: 'ByPinCode', key: 'byPinCode', width: 12 },
  { header: 'ByState', key: 'byState', width: 12 },
  { header: 'ByPhone', key: 'byPhone', width: 16 },
  { header: 'ByMail', key: 'byMail', width: 22 },
  { header: 'DispName', key: 'dispName', width: 10 },
  { header: 'DispAdd1', key: 'dispAdd1', width: 10 },
  { header: 'DispAdd2', key: 'dispAdd2', width: 10 },
  { header: 'DispLoct', key: 'dispLoct', width: 10 },
  { header: 'DispPin', key: 'dispPin', width: 10 },
  { header: 'DispState', key: 'dispState', width: 10 },
  { header: 'ShipGstn', key: 'shipGstn', width: 10 },
  { header: 'ShipLgName', key: 'shipLgName', width: 10 },
  { header: 'ShipTradName', key: 'shipTradName', width: 10 },
  { header: 'ShipAdd1', key: 'shipAdd1', width: 10 },
  { header: 'ShipAdd2', key: 'shipAdd2', width: 10 },
  { header: 'ShipLoct', key: 'shipLoct', width: 10 },
  { header: 'ShipPin', key: 'shipPin', width: 10 },
  { header: 'ShipState', key: 'shipState', width: 10 },
  { header: 'TotTaxableVal', key: 'totTaxableVal', type: 'number', format: '0.00', width: 16 },
  { header: 'SgstAmt', key: 'sgstAmt', type: 'number', format: '0.00', width: 12 },
  { header: 'CgstAmt', key: 'cgstAmt', type: 'number', format: '0.00', width: 12 },
  { header: 'IgstAmt', key: 'igstAmt', type: 'number', format: '0.00', width: 12 },
  { header: 'TotCessAmt', key: 'totCessAmt', type: 'number', format: '0.00', width: 12 },
  { header: 'TotStateCess', key: 'totStateCess', type: 'number', format: '0.00', width: 14 },
  { header: 'DiscAmt', key: 'discAmt', type: 'number', format: '0.00', width: 12 },
  { header: 'OthCharge', key: 'othCharge', type: 'number', format: '0.00', width: 12 },
  { header: 'RofAmt', key: 'rofAmt', type: 'number', format: '0.00', width: 12 },
  { header: 'TotInvoiceVal', key: 'totInvoiceVal', type: 'number', format: '0.00', width: 16 },
];

export const EINVOICE_ITEM_COLUMNS: XlsxColumn[] = [
  { header: 'DockType', key: 'dockType', width: 16 },
  { header: 'DockNo', key: 'dockNo', width: 16 },
  { header: 'DockDate', key: 'dockDate', type: 'date', format: 'dd/mm/yyyy', width: 14 },
  { header: 'SlNo', key: 'slNo', type: 'number', width: 8 },
  { header: 'Product', key: 'product', width: 24 },
  { header: 'IsService', key: 'isService', width: 12 },
  { header: 'HsnCode', key: 'hsnCode', width: 12 },
  { header: 'BarCode', key: 'barCode', width: 14 },
  { header: 'Qty', key: 'qty', type: 'number', format: '0.000', width: 12 },
  { header: 'FreeQry', key: 'freeQty', type: 'number', format: '0.000', width: 10 },
  { header: 'Unit', key: 'unit', width: 12 },
  { header: 'UnitRate', key: 'unitRate', type: 'number', format: '0.000', width: 12 },
  { header: 'GrossAmt', key: 'grossAmt', type: 'number', format: '0.00', width: 12 },
  { header: 'DiscAmt', key: 'discAmt', type: 'number', format: '0.00', width: 12 },
  { header: 'PreTaxVal', key: 'preTaxVal', type: 'number', format: '0.00', width: 12 },
  { header: 'TaxableVal', key: 'taxableVal', type: 'number', format: '0.00', width: 12 },
  { header: 'Gst%', key: 'gstPct', type: 'number', format: '0.000', width: 10 },
  { header: 'SgstAmt', key: 'sgstAmt', type: 'number', format: '0.00', width: 12 },
  { header: 'CgstAmt', key: 'cgstAmt', type: 'number', format: '0.00', width: 12 },
  { header: 'IgstAmt', key: 'igstAmt', type: 'number', format: '0.00', width: 12 },
  { header: 'Cess%', key: 'cessPct', type: 'number', format: '0.00', width: 10 },
  { header: 'CessAdVal', key: 'cessAdVal', type: 'number', format: '0.00', width: 12 },
  { header: 'CessNonVal', key: 'cessNonVal', type: 'number', format: '0.00', width: 12 },
  { header: 'StateCess%', key: 'stateCessPct', type: 'number', format: '0.00', width: 12 },
  { header: 'StateCessAddVal', key: 'stateCessAddVal', type: 'number', format: '0.00', width: 16 },
  { header: 'StateCessNonVal', key: 'stateCessNonVal', type: 'number', format: '0.00', width: 16 },
  { header: 'OtherCharge', key: 'otherCharge', type: 'number', format: '0.00', width: 14 },
  { header: 'ItemTotal', key: 'itemTotal', type: 'number', format: '0.00', width: 12 },
  { header: 'BachName', key: 'batchName', width: 10 },
  { header: 'BachExpiry', key: 'batchExpiry', width: 10 },
  { header: 'BachWaranty', key: 'batchWarranty', width: 12 },
];

export function eInvoiceExportSheets(data: EInvoiceExportData): XlsxSheet[] {
  return [
    { name: 'einvoice', columns: EINVOICE_HEADER_COLUMNS, rows: data.headers },
    { name: 'Items', columns: EINVOICE_ITEM_COLUMNS, rows: data.items },
  ];
}

export async function eInvoiceExportData(
  prisma: any,
  scope: EInvoiceExportScope,
  options: EInvoiceExportOptions = {},
): Promise<EInvoiceExportData> {
  const filters = checkedFilters(scope, options);
  return withTenant(prisma, scope.tenantId, async (tx: any) => {
    const where = scopedWhere(scope, filters, 'a');
    const fromJoin = `
      FROM "SL_DATA" a
      LEFT JOIN "AC_MAST" c
        ON c.tenant_id=a.tenant_id AND c."CO_CODE"::text=a."CO_CODE"::text AND c."AC_CODE"::text=a."AC_CODE"::text
      LEFT JOIN "BOOK_DATA" e
        ON e.tenant_id=a.tenant_id AND e."CO_CODE"::text=a."CO_CODE"::text AND e."LC_CODE"::text=a."LC_CODE"::text AND e."CO_BOOK"::text=a."CO_BOOK"::text
      WHERE ${where.sql} AND ${bookTypePredicate}`;

    const missingHsn: Array<{ IT_NAME: unknown }> = await tx.$queryRawUnsafe(
      `SELECT b."IT_NAME"
         FROM "SL_DETL" a
         LEFT JOIN "ITEM_MAST" b
           ON b.tenant_id=a.tenant_id AND b."CO_CODE"::text=a."CO_CODE"::text AND b."IT_CODE"::text=a."IT_CODE"::text
         LEFT JOIN "BOOK_DATA" e
           ON e.tenant_id=a.tenant_id AND e."CO_CODE"::text=a."CO_CODE"::text AND e."LC_CODE"::text=a."LC_CODE"::text AND e."CO_BOOK"::text=a."CO_BOOK"::text
        WHERE ${where.sql} AND ${bookTypePredicate} AND coalesce(b."HSN_CODE"::text,'')=''
        GROUP BY b."IT_NAME"
        ORDER BY b."IT_NAME" NULLS FIRST
        LIMIT 1`,
      ...where.params,
    );
    if (missingHsn.length) {
      throw new EInvoiceValidationError(
        `Please insert HSN CODE in Item Master for item ${t(missingHsn[0]!.IT_NAME) || '(blank)'}`,
      );
    }

    const missingParty: Array<{ AC_NAME: unknown; AC_PIN: unknown; AC_GSTNO: unknown }> =
      await tx.$queryRawUnsafe(
        `SELECT c."AC_NAME",c."AC_PIN",c."AC_GSTNO"
           FROM "SL_DETL" a
           LEFT JOIN "AC_MAST" c
             ON c.tenant_id=a.tenant_id AND c."CO_CODE"::text=a."CO_CODE"::text AND c."AC_CODE"::text=a."AC_CODE"::text
           LEFT JOIN "BOOK_DATA" e
             ON e.tenant_id=a.tenant_id AND e."CO_CODE"::text=a."CO_CODE"::text AND e."LC_CODE"::text=a."LC_CODE"::text AND e."CO_BOOK"::text=a."CO_BOOK"::text
          WHERE ${where.sql} AND ${bookTypePredicate}
            AND (coalesce(c."AC_PIN"::text,'')='' OR coalesce(c."AC_GSTNO"::text,'')='')
          GROUP BY c."AC_NAME",c."AC_PIN",c."AC_GSTNO"
          ORDER BY c."AC_NAME" NULLS FIRST
          LIMIT 1`,
        ...where.params,
      );
    if (missingParty.length) {
      const p = missingParty[0]!;
      const name = t(p.AC_NAME) || '(blank)';
      if (!t(p.AC_PIN)) {
        throw new EInvoiceValidationError(`Please insert PIN CODE in AC_MAST for account ${name}`);
      }
      throw new EInvoiceValidationError(`Please insert GST NO in AC_MAST for account ${name}`);
    }

    const headersRaw: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT a."CO_BOOK",e."MAIN_BOOK",e."BOOK_SR_NAME",a."VCH_NO",a."VCH_DATE",
              c."AC_GSTNO",coalesce(c."AC_NAME",a."AC_NAME") AS "AC_NAME",c."AC_STATE",
              c."AC_ADD1",c."AC_ADD2",c."AC_CITY",c."AC_PIN",c."AC_MOBILE",c."AC_EMAIL",
              a."NET_AMT",a."SGST_TAX",a."CGST_TAX",a."IGST_TAX",a."DISC_AMT",a."TOT_AMT"
         ${fromJoin}
        ORDER BY a."VCH_DATE",a."CO_BOOK",a."VCH_NO"`,
      ...where.params,
    );

    const itemsRaw: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT a."CO_BOOK",e."BOOK_SR_NAME",a."VCH_NO",a."VCH_DATE",a."TAX_PRC",a."IGST_TAX" AS "HDR_IGST_TAX",
              b."SR_NO",d."IT_NAME",d."HSN_CODE",b."ITM_NWT",d."UNIT_NAME",b."ITM_RATE",b."ITM_AMT",
              b."IT_DISC_AMT",b."NET_AMT",b."IT_TAX_AMT",b."LBR_AMT",b."OTH_AMT",b."NET_AMT" AS "ItmNetAmt"
         FROM "SL_DATA" a
         LEFT JOIN "SL_DETL" b
           ON b.tenant_id=a.tenant_id AND b."CO_CODE"::text=a."CO_CODE"::text AND b."LC_CODE"::text=a."LC_CODE"::text
          AND b."CO_YEAR"::text=a."CO_YEAR"::text AND b."CO_BOOK"::text=a."CO_BOOK"::text AND b."VCH_NO"::text=a."VCH_NO"::text
         LEFT JOIN "ITEM_MAST" d
           ON d.tenant_id=a.tenant_id AND d."CO_CODE"::text=a."CO_CODE"::text AND d."IT_CODE"::text=b."IT_CODE"::text
         LEFT JOIN "BOOK_DATA" e
           ON e.tenant_id=a.tenant_id AND e."CO_CODE"::text=a."CO_CODE"::text AND e."LC_CODE"::text=a."LC_CODE"::text AND e."CO_BOOK"::text=a."CO_BOOK"::text
        WHERE ${where.sql} AND ${bookTypePredicate}
        ORDER BY a."VCH_DATE",a."CO_BOOK",a."VCH_NO",b."SR_NO"`,
      ...where.params,
    );

    return {
      headers: headersRaw.map(mapHeader),
      items: itemsRaw.map(mapItem),
      filters: {
        coBook: filters.coBook ?? null,
        fromDate: filters.fromDate ?? null,
        toDate: filters.toDate ?? null,
      },
    };
  });
}
