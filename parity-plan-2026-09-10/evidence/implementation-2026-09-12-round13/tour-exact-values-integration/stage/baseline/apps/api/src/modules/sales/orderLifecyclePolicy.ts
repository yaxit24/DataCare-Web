import type { VoucherScope } from '../vouchers/numbering.js';
import { SaleValidationError } from './sales.js';
import { Prisma } from '@prisma/client';
const Decimal = Prisma.Decimal;

export const ORDER_HEADER_FIELDS: Record<string, string> = {
  vchDate: 'VCH_DATE',
  vchTime: 'VCH_TIME',
  billNo: 'BILL_NO',
  acCode: 'AC_CODE',
  acName: 'AC_NAME',
  netAmount: 'NET_AMT',
  taxRatePct: 'TAX_PRC',
  advanceAmount: 'ADV_AMT',
  vchDesc: 'VCH_DESC',
  empCode: 'EMP_CODE',
  taxCode: 'TAX_CODE',
  upiAmount: 'UPI_AMT',
  bankAc: 'BANK_AC',
  chequeNo: 'CHQ_NO',
  bankName: 'BANK_NAME',
  cardAc: 'CARD_AC',
  cardAdj: 'CARD_ADJ',
  oldGoldFine: 'OLD_GL',
  oldGoldAmount: 'OLD_GL_AMT',
  oldSilverFine: 'OLD_SL',
  oldSilverAmount: 'OLD_SL_AMT',
  schemeAmount: 'SCHM_AMT',
  rateCutRate: 'RCUT_RATE',
  rateCutFine: 'RCUT_FINE',
  rateCutAmount: 'RCUT_AMT',
  adjustGold: 'ADJ_GOLD',
  adjustSilver: 'ADJ_SILVER',
  orderAdjustAmount: 'ORD_ADJ_AMT',
  deliveryDate: 'DEL_DATE',
  functionDate: 'FUN_DATE',
  address1: 'ADD1',
  address2: 'ADD2',
  address3: 'ADD3',
  city: 'CITY',
  mobile: 'MOBILE',
  interState: 'TAX_AMT',
  cashAc: 'ADV_AMT',
};
export const ORDER_PARENT_FIELDS: Record<string, string> = {
  itCode: 'IT_CODE',
  designNo: 'DESIGN_NO',
  pcs: 'ITM_PCS',
  grossWt: 'ITM_GWT',
  netWt: 'ITM_NWT',
  touch: 'ITM_TOUCH',
  ghtWt: 'ITM_GHT_WT',
  westPct: 'ITM_WEST_PRC',
  rate: 'ITM_RATE',
  making: 'LBR_RATE',
  labourAmount: 'LBR_AMT',
  remark: 'ITM_REMARK',
  tblCode: 'TBL_CODE',
  itmColor: 'ITM_COLOR',
  itmSize: 'ITM_SIZE',
  bagWt: 'BAG_WT',
  lessWt: 'ITM_OTH_WT',
  ghtPct: 'ITM_GHT_PRC',
  rateFix: 'RATE_FIX',
  labourPct: 'LBR_PRC',
  labourType: 'LBR_TYPE',
  labourRate: 'LBR_RATE',
  otherAmount: 'OTH_AMT',
  mrp: 'ITM_MRP',
  orderDeliveryDate: 'ORD_DEL_DATE',
  karigarNetWt: 'KR_NET_WT',
  karigarTouch: 'KR_TOUCH',
  karigarWestPct: 'KR_WEST_PRC',
  karigarFine: 'KR_FINE',
  karigarName: 'KR_NAME',
  tagCost: 'TAG_COST',
  vchSrno: 'VCH_SRNO',
  oldSrNo: 'OLD_SRNO',
  rateType: 'RATE_TYPE',
  itType: 'IT_TYPE',
  prCode: 'PR_CODE',
  oldTblCode: 'OLD_TBL_CODE',
  tagStockLess: 'TAG_STK_LESS',
  designImageId: 'DESIGN_IMG_ID',
  huid: 'HM_ID',
  hallmarkId2: 'HM_ID2',
  hallmarkId3: 'HM_ID3',
  hallmarkId4: 'HM_ID4',
  hallmarkIdWt: 'HM_ID_WT',
  hallmarkId2Wt: 'HM_ID2_WT',
  hallmarkId3Wt: 'HM_ID3_WT',
  hallmarkId4Wt: 'HM_ID4_WT',
};
export const ORDER_COMPONENT_FIELDS: Record<string, string> = {
  itCode: 'IT_CODE',
  itType: 'IT_TYPE',
  pcs: 'IT_PCS',
  grossWt: 'IT_GWT',
  amount: 'IT_AMT',
  netAmount: 'IT_NET_AMT',
  dmCode: 'DM_CODE',
  dmName: 'DM_NAME',
  dmSize: 'DM_SIZE',
  dmSfNo: 'DM_SFNO',
  dmColor: 'DM_COLOR',
  dmOrigin: 'DM_ORIGIN',
  dmRemark: 'DM_REMARK',
  dmLeb: 'DM_LEB',
  pcsWt: 'IT_PCS_WT',
  conPct: 'IT_CON_PRC',
  conWt: 'IT_CON_WT',
  rateType: 'IT_RATE_TYPE',
  rate: 'IT_RATE',
  labourRate: 'IT_LBR_RATE',
  lbrRate: 'IT_LBR_RATE',
  labourAmount: 'IT_LBR_AMT',
  lbrAmount: 'IT_LBR_AMT',
  karigarWt: 'KR_WT',
  karigarLessPct: 'KR_LESS_PRC',
  karigarConPct: 'KR_CON_PRC',
  karigarConWt: 'KR_CON_WT',
  karigarRate: 'KR_RATE',
  karigarAmount: 'KR_AMT',
  karigarLabourRate: 'KR_LBR_RATE',
  karigarLabourAmount: 'KR_LBR_AMT',
  karigarNetAmount: 'KR_NET_AMT',
};

export function orderDirtyColumns(
  input: { dirtyFields?: string[] },
  fields: Record<string, string>,
  extra: readonly string[] = [],
): Set<string> {
  if (
    input.dirtyFields != null &&
    (!Array.isArray(input.dirtyFields) ||
      input.dirtyFields.length > 128 ||
      input.dirtyFields.some((field) => typeof field !== 'string' || !Object.hasOwn(fields, field)))
  )
    throw new SaleValidationError('Invalid committed order field list.');
  return new Set([...(input.dirtyFields ?? []).map((field) => fields[field]!), ...extra]);
}

/** Preserve nullable fields and decimal precision in Sales input-shaped hydration. */
export function exactOrderValues(
  dto: Record<string, any>,
  row: Record<string, any>,
  fields: Record<string, string>,
) {
  for (const [field, column] of Object.entries(fields)) {
    if (!Object.hasOwn(dto, field) || !Object.hasOwn(row, column)) continue;
    const value = row[column];
    if (value == null) dto[field] = null;
    else if (typeof dto[field] === 'number' && !(value instanceof Date)) {
      const decimal = new Decimal(String(value));
      if (!decimal.equals(dto[field])) dto[field] = decimal.toFixed();
    }
  }
  return dto;
}

export function preserveOrderInputRow(
  previous: Record<string, any> | undefined,
  next: Record<string, any>,
  input: Record<string, any>,
  fields: Record<string, string>,
  dirty: ReadonlySet<string>,
) {
  for (const [field, column] of Object.entries(fields)) {
    const requested = input[field];
    if (
      requested == null ||
      typeof next[column] !== 'number' ||
      typeof requested !== 'string' ||
      !/^[-+]?\d+(?:\.\d+)?$/.test(requested)
    )
      continue;
    const exact = new Decimal(requested);
    if (exact.equals(next[column])) continue;
    if (!dirty.has(column) && previous?.[column] != null && exact.equals(String(previous[column])))
      next[column] = previous[column];
    else
      throw new SaleValidationError(
        `${field} cannot be represented exactly by this order calculation; preserve the saved decimal or use a supported value.`,
      );
  }
  return preserveOrderRow(previous, next, dirty);
}

export class SalesOrderWorkflowUnavailableError extends Error {
  readonly code = 'prior-year-confirmation-unavailable';
  constructor() {
    super(
      'This date precedes the selected financial year. The desktop prior-year confirmation and lock-bypass workflow is not yet available on the web; select an ordinary in-year date.',
    );
    this.name = 'SalesOrderWorkflowUnavailableError';
  }
}

/** Validate before Date.toISOString/voucherTimestamp can throw or normalize an impossible date. */
export function orderDate(value: unknown, field: string, required = false): Date | undefined {
  if (value == null || value === '') {
    if (required) throw new SaleValidationError(`${field} is required`);
    return undefined;
  }
  const iso =
    value instanceof Date
      ? Number.isNaN(value.getTime())
        ? ''
        : value.toISOString().slice(0, 10)
      : String(value);
  if (!/^\d{4}-\d{2}-\d{2}$/.test(iso))
    throw new SaleValidationError(`${field} must be a valid YYYY-MM-DD date`);
  const parsed = new Date(`${iso}T00:00:00.000Z`);
  if (Number.isNaN(parsed.getTime()) || parsed.toISOString().slice(0, 10) !== iso)
    throw new SaleValidationError(`${field} must be a valid YYYY-MM-DD date`);
  return parsed;
}

export function orderClock(value: unknown): string {
  const clock = String(value ?? '').trim();
  if (!/^(?:[01]\d|2[0-3]):[0-5]\d(?::[0-5]\d(?:\.\d{1,6})?)?$/.test(clock))
    throw new SaleValidationError(
      'Order time must be HH:mm or HH:mm:ss with up to six fractional digits',
    );
  if (clock.length === 5) return `${clock}:00.000000`;
  return clock.includes('.') ? clock.padEnd(15, '0') : `${clock}.000000`;
}

export async function salesOrderFiscalConfigurationTx(tx: any, scope: VoucherScope) {
  const rows: Array<{ opening: string | null; closing: string | null }> = await tx.$queryRawUnsafe(
    `SELECT "OP_DATE"::date::text AS opening,"CL_DATE"::date::text AS closing
     FROM "YEAR_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2
       AND coalesce(nullif(btrim("CO_YEAR"::text),''),left("OP_DATE"::text,4))=$3
     ORDER BY row_id LIMIT 2`,
    scope.tenantId,
    scope.coCode,
    scope.coYear,
  );
  if (
    rows.length !== 1 ||
    !rows[0]?.opening ||
    !rows[0]?.closing ||
    rows[0].opening > rows[0].closing
  )
    throw new SaleValidationError(
      'The selected Sales Order financial year needs unambiguous opening and closing dates.',
    );
  return {
    fiscalOpeningDate: rows[0].opening,
    fiscalClosingDate: rows[0].closing,
    priorYearConfirmationSupported: false as const,
  };
}

export async function assertSalesOrderDateTx(tx: any, scope: VoucherScope, date: Date) {
  const policy = await salesOrderFiscalConfigurationTx(tx, scope);
  const iso = date.toISOString().slice(0, 10);
  // TR_SALE_ORD:9011–9026: later dates fail; earlier dates have a distinct confirmation/lock bypass.
  if (iso > policy.fiscalClosingDate)
    throw new SaleValidationError(
      'Voucher date is after the selected financial year closing date.',
    );
  if (iso < policy.fiscalOpeningDate) throw new SalesOrderWorkflowUnavailableError();
}

/** Retain saved columns the input DTO does not own, including imported decimal/null distinctions. */
export function preserveOrderRow(
  previous: Record<string, any> | undefined,
  next: Record<string, any>,
  dirty: ReadonlySet<string> = new Set(),
) {
  if (!previous) return next;
  const saved = Object.fromEntries(
    Object.entries(previous).filter(
      ([key]) => key !== 'tenant_id' && key !== 'row_id' && key !== 'VCH_CLOCK',
    ),
  );
  const merged = { ...saved, ...next };
  for (const [key, value] of Object.entries(next)) {
    if (!(key in saved) || dirty.has(key)) continue;
    const old = saved[key];
    const normalized = (item: unknown) => (item == null ? '' : String(item).trim());
    if (
      key.endsWith('_DATE') &&
      value instanceof Date &&
      old != null &&
      (old instanceof Date ? old.toISOString() : String(old)).slice(0, 10) ===
        value.toISOString().slice(0, 10)
    )
      merged[key] = old;
    else if (normalized(old) === normalized(value)) merged[key] = old;
    else if (
      old != null &&
      value != null &&
      !(old instanceof Date) &&
      !(value instanceof Date) &&
      (typeof old === 'number' || typeof value === 'number' || typeof old?.toFixed === 'function')
    ) {
      const a = normalized(old),
        b = normalized(value);
      if (a && b && /^[-+]?\d+(?:\.\d+)?$/.test(a) && /^[-+]?\d+(?:\.\d+)?$/.test(b)) {
        if (new Decimal(a).equals(b)) merged[key] = old;
        else if (Number(a) === Number(b))
          throw new SaleValidationError(
            `The saved ${key} needs its exact decimal string; reload before changing it.`,
          );
      }
    } else if (old == null && value === 0) merged[key] = old;
  }
  for (const field of ['TAG_NO', 'TAG_SALE', 'TAG_GEN', 'DESIGN_ISU', 'ORD_REC_AMT'])
    if (field in saved) merged[field] = saved[field];
  return merged;
}
