import type { VoucherScope } from '../vouchers/numbering.js';

export const DEFAULT_CASH_LIMIT = 200000;
export const DEFAULT_PAN_CARD_VAL = 200000;
export const DEFAULT_INT_YEAR_DAYS = 360;
/** Blank OZ_CON_VAL retains the web's pre-setting troy-ounce constant byte-for-byte. */
export const DEFAULT_OUNCE_CONVERSION = 31.1034768;
export const DESKTOP_OUNCE_CONVERSION = 31.1035;

export type InterestDayMode = '1' | '2';
export type LoanInterestType = 'M' | 'D';
export type FineStockType = '' | 'A' | 'N' | 'G';
export type LineAmountType = '' | 'N' | 'G' | 'F' | 'P';
export type StockWeightSource = '' | 'OLD' | 'NEW';
export type ExportDatabaseTarget = '' | 'A' | 'B';
export type SmsGatewayCode = '' | '001' | '002' | '012' | '022' | '032' | '042';

export interface SettingsBehavior {
  cashLimit: number;
  panCardVal: number;
  lastDayLock: boolean;
  intYearDays: number;
  intDay: InterestDayMode;
  loanIntType: LoanInterestType;
  dhrnIntType: LoanInterestType;
  dhrnCompound: boolean;
  fineStockType: FineStockType;
  saleAmountType: LineAmountType;
  purchaseAmountType: LineAmountType;
  purchaseWithLabour: boolean;
  ounceConversion: number;
  /**
   * `MsRatePar` from `CO_SET.RATE_PAR` (`MS_OPNCOMP.cs:672`, default `G`): the basis a metal rate is quoted
   * on. Loaded here so the settlement engine can never take it from a request body.
   */
  rateBasis: 'G' | 'T' | 'K';
  /**
   * `CO_SET.LBR_TYPE` — the company's default labour BASIS: G gross wise, N net wise, K kg wise, P pcs wise.
   * Used when a line does not name a basis, and when the API's `percentage`/`fixed` modes have no desktop code
   * of their own.
   */
  labourType: string;
  allRoundingRemoved: boolean;
  accountCodeLength: number | null;
  vbImport: boolean;
  tagReport: boolean;
  labourRateGeneration: boolean;
  openingDhrn: boolean;
  weightPort: string | null;
  ledgerSummary: boolean;
  smsGateway: SmsGatewayCode;
  openingLoan: boolean;
  stockReportGrossWeight: boolean;
  touchAutoSave: boolean;
  dhrnDefaultRate: number | null;
  exportDatabaseTarget: ExportDatabaseTarget;
  companyStockMerge: boolean;
  cardCommissionAdjustment: boolean;
  cashPurchaseAccount: boolean;
  stockWeightSource: StockWeightSource;
  dhrnWhatsapp: boolean | null;
  schemeWhatsapp: boolean | null;
  fxRate: number | null;
  fxCode: string | null;
  adminSms: boolean | null;
  customerSms: boolean | null;
}

export class SettingsBehaviorValidationError extends Error {
  constructor(message: string) {
    super(message);
    this.name = 'SettingsBehaviorValidationError';
  }
}

const raw = (value: unknown): string => String(value ?? '').trim();

function roundEven(value: number, decimals = 0): number {
  const scale = 10 ** decimals;
  const scaled = value * scale;
  const floor = Math.floor(scaled);
  const fraction = scaled - floor;
  const rounded =
    Math.abs(fraction - 0.5) < 1e-10 ? (floor % 2 === 0 ? floor : floor + 1) : Math.round(scaled);
  return rounded / scale;
}

function finiteNumber(
  value: unknown,
  key: string,
  defaultValue: number,
  options: { zeroUsesDefault?: boolean; negativeToZero?: boolean } = {},
): number {
  const configured = raw(value);
  if (!configured) return defaultValue;
  const parsed = Number(configured);
  if (!Number.isFinite(parsed)) {
    throw new SettingsBehaviorValidationError(`CO_SET.${key} is invalid: ${configured}`);
  }
  if (options.zeroUsesDefault && parsed === 0) return defaultValue;
  if (options.negativeToZero && parsed < 0) return 0;
  if (parsed <= 0) {
    throw new SettingsBehaviorValidationError(`CO_SET.${key} must be positive`);
  }
  return parsed;
}

function enumValue<T extends string>(
  value: unknown,
  key: string,
  allowed: readonly T[],
  defaultValue: T,
): T {
  const configured = raw(value).toUpperCase();
  if (!configured) return defaultValue;
  if (!allowed.includes(configured as T)) {
    throw new SettingsBehaviorValidationError(`CO_SET.${key} is invalid: ${configured}`);
  }
  return configured as T;
}

function optionalPositiveNumber(
  value: unknown,
  key: string,
  options: { zeroDefault?: number; integer?: boolean; max?: number } = {},
): number | null {
  const configured = raw(value);
  if (!configured) return null;
  const parsed = Number(configured);
  if (!Number.isFinite(parsed) || parsed < 0 || (options.integer && !Number.isInteger(parsed))) {
    throw new SettingsBehaviorValidationError(`CO_SET.${key} is invalid: ${configured}`);
  }
  const normalized = parsed === 0 && options.zeroDefault != null ? options.zeroDefault : parsed;
  if (normalized <= 0 || (options.max != null && normalized > options.max)) {
    throw new SettingsBehaviorValidationError(`CO_SET.${key} is out of range: ${configured}`);
  }
  return normalized;
}

function optionalFlag(value: unknown, key: string): boolean | null {
  const configured = raw(value);
  if (!configured) return null;
  return enumValue(configured, key, ['Y', 'N'], 'N') === 'Y';
}

function optionalCode(value: unknown, key: string, pattern: RegExp): string | null {
  const configured = raw(value).toUpperCase();
  if (!configured) return null;
  if (!pattern.test(configured)) {
    throw new SettingsBehaviorValidationError(`CO_SET.${key} is invalid: ${configured}`);
  }
  return configured;
}

function ounceConversion(value: unknown): number {
  const configured = raw(value);
  if (!configured) return DEFAULT_OUNCE_CONVERSION;
  const parsed = Number(configured);
  if (!Number.isFinite(parsed) || parsed < 0) {
    throw new SettingsBehaviorValidationError(`CO_SET.OZ_CON_VAL is invalid: ${configured}`);
  }
  // MS_OPNCOMP.cs:933-935: a configured zero is normalised to the desktop 31.1035 g/oz value.
  return parsed === 0 ? DESKTOP_OUNCE_CONVERSION : parsed;
}

/**
 * Desktop defaults and normalisation:
 * MS_OPNCOMP.cs:777-779 INT_YEAR_DAYS 0 -> 360; :785-787 INT_DAY blank -> "1";
 * :809-811 LOAN_INT_TYPE blank -> "M"; :841-843 DHIRN_COMPOUND blank -> "Y";
 * :857-859 PAN_CARD_VAL 0 -> 200000; :905-911 LAST_DAY_LOCK blank -> "N" and negative
 * CASH_LIMIT -> 0. CASH_LIMIT remains 200000 when blank to preserve the pre-setting web behaviour.
 * The six batch-2 settings use explicit blank sentinels where desktop defaults differ from today's web:
 * MS_OPNCOMP.cs:765-767 maps blank FINE_STK_TYPE to F (but RP_STOCK_FINE.cs:2963-2977 accepts
 * only A/N/G); :837-839 maps PURC_WITH_LBR to Y; :881-887 maps SL_AMT_TYPE to N and
 * PR_AMT_TYPE to F; :929-935 maps ALL_ROF_REMOVE to N and zero OZ_CON_VAL to 31.1035.
 * Configured values follow those desktop branches; truly blank values retain pre-setting web output.
 */
export function resolveSettingsBehavior(values: Record<string, unknown>): SettingsBehavior {
  return {
    cashLimit: finiteNumber(values.CASH_LIMIT, 'CASH_LIMIT', DEFAULT_CASH_LIMIT, {
      negativeToZero: true,
    }),
    panCardVal: finiteNumber(values.PAN_CARD_VAL, 'PAN_CARD_VAL', DEFAULT_PAN_CARD_VAL, {
      zeroUsesDefault: true,
    }),
    lastDayLock: enumValue(values.LAST_DAY_LOCK, 'LAST_DAY_LOCK', ['Y', 'N'], 'N') === 'Y',
    intYearDays: finiteNumber(values.INT_YEAR_DAYS, 'INT_YEAR_DAYS', DEFAULT_INT_YEAR_DAYS, {
      zeroUsesDefault: true,
    }),
    intDay: enumValue(values.INT_DAY, 'INT_DAY', ['1', '2'], '1'),
    loanIntType: enumValue(values.LOAN_INT_TYPE, 'LOAN_INT_TYPE', ['M', 'D'], 'M'),
    // MS_OPNCOMP.cs:679 loads DHRN_INT_TYPE; :775 defaults a blank value to "M".
    dhrnIntType: enumValue(values.DHRN_INT_TYPE, 'DHRN_INT_TYPE', ['M', 'D'], 'M'),
    dhrnCompound: enumValue(values.DHIRN_COMPOUND, 'DHIRN_COMPOUND', ['Y', 'N'], 'Y') === 'Y',
    fineStockType: enumValue(values.FINE_STK_TYPE, 'FINE_STK_TYPE', ['A', 'N', 'G'], ''),
    saleAmountType: enumValue(values.SL_AMT_TYPE, 'SL_AMT_TYPE', ['N', 'G', 'F', 'P'], ''),
    purchaseAmountType: enumValue(values.PR_AMT_TYPE, 'PR_AMT_TYPE', ['N', 'G', 'F', 'P'], ''),
    purchaseWithLabour: enumValue(values.PURC_WITH_LBR, 'PURC_WITH_LBR', ['Y', 'N'], 'Y') === 'Y',
    ounceConversion: ounceConversion(values.OZ_CON_VAL),
    // Desktop reads only the first character (UT_SETTING.cs:4914) and defaults to per-gram.
    rateBasis: ((): 'G' | 'T' | 'K' => {
      const c = String(values.RATE_PAR ?? '')
        .trim()
        .toUpperCase()
        .slice(0, 1);
      return c === 'T' || c === 'K' ? c : 'G';
    })(),
    // CO_SET.LBR_TYPE is varchar(1) with options G/N/K/P. An unrecognised value yields '' rather than a
    // guessed basis: writing the wrong basis code changes the amount the desktop recomputes on reopen.
    labourType: ((): string => {
      const c = String(values.LBR_TYPE ?? '')
        .trim()
        .toUpperCase()
        .slice(0, 1);
      return ['G', 'N', 'K', 'P'].includes(c) ? c : '';
    })(),
    allRoundingRemoved: enumValue(values.ALL_ROF_REMOVE, 'ALL_ROF_REMOVE', ['Y', 'N'], 'N') === 'Y',
    // Desktop load/consumer citations: MS_OPNCOMP.cs:665,673-720. Blank sentinels deliberately
    // retain the pre-batch web path; configured values are closed enums/numbers and fail closed.
    accountCodeLength: optionalPositiveNumber(values.AC_LC_CODE_LEN, 'AC_LC_CODE_LEN', {
      integer: true,
      max: 8,
    }),
    vbImport: enumValue(values.VB_IMPORT, 'VB_IMPORT', ['Y', 'N'], 'N') === 'Y',
    tagReport: enumValue(values.TAG_RPT, 'TAG_RPT', ['Y', 'N'], 'N') === 'Y',
    labourRateGeneration: enumValue(values.LBR_RATE_GEN, 'LBR_RATE_GEN', ['Y', 'N'], 'N') === 'Y',
    openingDhrn: enumValue(values.OP_DHRN, 'OP_DHRN', ['Y', 'N'], 'N') === 'Y',
    weightPort: optionalCode(values.WEIGHT_PORT, 'WEIGHT_PORT', /^(?:0|COM[1-9]\d*)$/),
    ledgerSummary: enumValue(values.LDR_SUMM, 'LDR_SUMM', ['Y', 'N'], 'N') === 'Y',
    smsGateway: enumValue(
      values.SMS_LINK,
      'SMS_LINK',
      ['001', '002', '012', '022', '032', '042'],
      '',
    ),
    openingLoan: enumValue(values.OP_LOAN, 'OP_LOAN', ['Y', 'N'], 'N') === 'Y',
    stockReportGrossWeight: enumValue(values.STK_RPT_TYPE, 'STK_RPT_TYPE', ['G', 'N'], 'N') === 'G',
    touchAutoSave: enumValue(values.TOUCH_AUTO_SAVE, 'TOUCH_AUTO_SAVE', ['Y', 'N'], 'N') === 'Y',
    dhrnDefaultRate: optionalPositiveNumber(values.DHRN_PRC, 'DHRN_PRC', { zeroDefault: 2 }),
    exportDatabaseTarget: enumValue(values.IP_WITH_PC, 'IP_WITH_PC', ['A', 'B'], ''),
    companyStockMerge: enumValue(values.CO_STK_MERGE, 'CO_STK_MERGE', ['Y', 'N'], 'N') === 'Y',
    cardCommissionAdjustment:
      enumValue(values.CARD_COM_ADJ, 'CARD_COM_ADJ', ['Y', 'N'], 'N') === 'Y',
    cashPurchaseAccount: enumValue(values.CASH_PURC_AC, 'CASH_PURC_AC', ['Y', 'N'], 'N') === 'Y',
    stockWeightSource: enumValue(values.STOCK_RPT_TYPE, 'STOCK_RPT_TYPE', ['OLD', 'NEW'], ''),
    dhrnWhatsapp: optionalFlag(values.DHRN_WAPP, 'DHRN_WAPP'),
    schemeWhatsapp: optionalFlag(values.SCHM_WAPP, 'SCHM_WAPP'),
    fxRate: optionalPositiveNumber(values.FX_RATE, 'FX_RATE', { zeroDefault: 87 }),
    fxCode: optionalCode(values.FX_CODE, 'FX_CODE', /^[A-Z]{3}$/),
    adminSms: optionalFlag(values.ADMIN_SMS, 'ADMIN_SMS'),
    customerSms: optionalFlag(values.CUST_SMS, 'CUST_SMS'),
  };
}

interface SettingsRow extends Record<string, unknown> {
  co_set_count: unknown;
}

/** Load exactly one active-company CO_SET row inside the caller's transaction; never tenant-fallback. */
export async function resolveSettingsBehaviorTx(
  tx: any,
  scope: Pick<VoucherScope, 'tenantId' | 'coCode'>,
): Promise<SettingsBehavior> {
  let rows: SettingsRow[];
  try {
    rows = await tx.$queryRawUnsafe(
      `SELECT count(*) OVER ()::int AS co_set_count,
              "CASH_LIMIT", "PAN_CARD_VAL", "LAST_DAY_LOCK", "INT_YEAR_DAYS", "INT_DAY",
              "LOAN_INT_TYPE", "DHRN_INT_TYPE", "DHIRN_COMPOUND",
              "FINE_STK_TYPE", "SL_AMT_TYPE", "PR_AMT_TYPE", "PURC_WITH_LBR",
              "OZ_CON_VAL", "RATE_PAR", "LBR_TYPE", "ALL_ROF_REMOVE", "AC_LC_CODE_LEN", "VB_IMPORT", "TAG_RPT",
              "LBR_RATE_GEN", "OP_DHRN", "WEIGHT_PORT", "LDR_SUMM", "SMS_LINK", "OP_LOAN",
              "STK_RPT_TYPE", "TOUCH_AUTO_SAVE", "DHRN_PRC", "IP_WITH_PC",
              "CO_STK_MERGE", "CARD_COM_ADJ", "CASH_PURC_AC", "STOCK_RPT_TYPE",
              "DHRN_WAPP", "SCHM_WAPP", "FX_RATE", "FX_CODE", "ADMIN_SMS", "CUST_SMS"
         FROM "CO_SET"
        WHERE tenant_id=$1 AND "CO_CODE"::text=$2::text
        ORDER BY row_id`,
      scope.tenantId,
      String(scope.coCode),
    );
  } catch (error) {
    throw new SettingsBehaviorValidationError(
      `unable to read CO_SET behavior settings for company ${String(scope.coCode)}`,
    );
  }
  if (rows.length !== 1 || Number(rows[0]?.co_set_count) !== 1) {
    throw new SettingsBehaviorValidationError(
      `company ${String(scope.coCode)} must have exactly one CO_SET behavior row`,
    );
  }
  return resolveSettingsBehavior(rows[0] as SettingsRow);
}

/** TR_CASH.cs:2913-2922: enabled only above zero; cumulative cash strictly > limit blocks save. */
export function cashReceiptExceedsLimit(amount: number, priorCash: number, limit: number): boolean {
  return limit > 0 && Math.round((amount + priorCash + Number.EPSILON) * 100) / 100 > limit;
}

/** TR_SALE.cs:15111-15128: taxable non-quotation bill value >= PAN_CARD_VAL requires party+PAN. */
export function panRequiredForBill(billValue: number, panCardVal: number): boolean {
  return billValue >= panCardVal;
}

function utcDay(value: Date | string): number {
  const date = value instanceof Date ? value : new Date(value);
  if (Number.isNaN(date.getTime()))
    throw new SettingsBehaviorValidationError('interest date is invalid');
  return Date.UTC(date.getUTCFullYear(), date.getUTCMonth(), date.getUTCDate());
}

/** TR_DHRN_REC.cs:6883-6891 and TR_DHRN_INTREC.cs:5347-5355: INT_DAY="2" includes both endpoints. */
export function interestDayCount(
  from: Date | string,
  to: Date | string,
  mode: InterestDayMode,
): number {
  const elapsed = Math.max(0, Math.round((utcDay(to) - utcDay(from)) / 86400000));
  return mode === '2' ? elapsed + 1 : elapsed;
}

/**
 * TR_DHRN_REC.cs:6979-6999 converts elapsed days to months as
 * Round(abs(DateDiff)/365*360/30), then stores months*30 as interest days.
 */
export function interestMonthCount(from: Date | string, to: Date | string): number {
  const elapsed = Math.max(0, Math.round((utcDay(to) - utcDay(from)) / 86400000));
  return Math.max(0, roundEven((elapsed / 365) * (360 / 30)));
}

const roundLoanInterest = (amount: number, loanType: string): number => {
  const metal = ['G', 'S'].includes(raw(loanType).toUpperCase());
  return roundEven(amount, metal ? 3 : 0);
};

export interface DesktopInterestInput {
  principal: number;
  annualRatePct: number;
  from: Date | string;
  to: Date | string;
  settings: Pick<SettingsBehavior, 'intYearDays' | 'intDay' | 'loanIntType' | 'dhrnCompound'>;
  loanType?: string;
  months?: number;
}

/**
 * Desktop TR_DHRN_REC.cs:6883-7070 / TR_DHRN_INTREC.cs:5347-5562:
 * principal * rate/100 * interest-days / INT_YEAR_DAYS. LOAN_INT_TYPE="M" uses 30 days/month;
 * otherwise INT_DAY chooses exclusive/inclusive elapsed days. When DHIRN_COMPOUND is enabled,
 * each complete 360-day block is added to principal before the remainder calculation
 * (TR_DHRN_REC.cs:6905-6927; RP_DHRN_OS.cs:2032-2047). Amount loans round to whole rupees and
 * gold/silver loans to 3 decimals (TR_DHRN_REC.cs:6920-6938).
 */
/**
 * Desktop picks the interest-type setting from the form's configured MAIN_BOOK, not globally:
 *   TR_DHRN_REC.cs:5626-5634    MAIN_BOOK "LOAN ISSUE"     -> LOAN_INT_TYPE
 *   TR_DHRN_INTREC.cs:4265-4270 MAIN_BOOK "LOAN INT ENTRY" -> LOAN_INT_TYPE
 *   TR_DHRN_REC.cs:5643, TR_DHRN_INTREC.cs:4274/4280       -> DHRN_INT_TYPE (incl. "OS LETTER")
 *   TR_DHRN_ISU.cs:6093,6438 reads DHRN_INT_TYPE unconditionally.
 * Both settings default to "M" when blank (MS_OPNCOMP.cs:775 and :811).
 */
const LOAN_INTEREST_BOOKS = new Set(['LOAN ISSUE', 'LOAN INT ENTRY']);

export function interestTypeForBook(
  settings: Pick<SettingsBehavior, 'loanIntType' | 'dhrnIntType'>,
  mainBook: unknown,
): LoanInterestType {
  const book = String(mainBook ?? '')
    .trim()
    .toUpperCase();
  return LOAN_INTEREST_BOOKS.has(book) ? settings.loanIntType : settings.dhrnIntType;
}

export function desktopDhrnInterest(input: DesktopInterestInput): number {
  const { principal, annualRatePct, settings } = input;
  if (!(principal >= 0) || !Number.isFinite(principal)) {
    throw new SettingsBehaviorValidationError('interest principal is invalid');
  }
  if (!(annualRatePct >= 0) || !Number.isFinite(annualRatePct)) {
    throw new SettingsBehaviorValidationError('interest rate is invalid');
  }
  const days =
    settings.loanIntType === 'M'
      ? Math.max(0, input.months ?? interestMonthCount(input.from, input.to)) * 30
      : interestDayCount(input.from, input.to, settings.intDay);
  let base = principal;
  let interest = 0;
  let remainder = days;
  // TR_DHRN_REC.cs:6897-6927 formats days/365 to 2dp and compounds only when > 1.
  if (settings.dhrnCompound && Number((days / 365).toFixed(2)) > 1) {
    let completeBlocks = Math.floor(days / 360);
    while (completeBlocks > 0) {
      const annualBlock = roundEven(base * (annualRatePct / 100) * (360 / settings.intYearDays));
      interest += annualBlock;
      base += annualBlock;
      remainder -= 360;
      completeBlocks -= 1;
    }
  }
  interest += base * (annualRatePct / 100) * (remainder / settings.intYearDays);
  return roundLoanInterest(interest, input.loanType ?? 'A');
}

export interface AmountBasisInput {
  pcs?: number;
  grossWt?: number;
  netWt?: number;
  ghtWt?: number;
  fineWt?: number;
}

/**
 * TR_SALE.cs:18367-18417: F uses fine (falling back to net+ghat when fine is zero), G uses
 * gross+ghat, and every other configured value (including desktop's P fall-through) uses net+ghat.
 * Blank deliberately returns fine to preserve the pre-setting web calculation.
 */
export function saleAmountBase(input: AmountBasisInput, type: LineAmountType): number {
  const fine = Number(input.fineWt ?? 0);
  if (type === '') return fine;
  const ghat = Number(input.ghtWt ?? 0);
  if (type === 'F') return fine === 0 ? Number(input.netWt ?? 0) + ghat : fine;
  if (type === 'G') return Number(input.grossWt ?? 0) + ghat;
  return Number(input.netWt ?? 0) + ghat;
}

/**
 * TR_PURC.cs:7396: G uses gross, N uses net+ghat, and all other configured values (F/P) use fine.
 * Blank deliberately returns fine to preserve the pre-setting web calculation.
 */
export function purchaseAmountBase(input: AmountBasisInput, type: LineAmountType): number {
  if (type === 'G') return Number(input.grossWt ?? 0);
  if (type === 'N') return Number(input.netWt ?? 0) + Number(input.ghtWt ?? 0);
  return Number(input.fineWt ?? 0);
}

/**
 * Ac_Ledr.cs:520-532: Y posts the full purchase NET_AMT to the primary account; N posts
 * NET_AMT-(LBR_AMT+OTH_AMT) there and LBR_AMT+OTH_AMT to BOOK_DETL row 4.
 */
export function purchaseExpenseSplit(
  net: number,
  labour: number,
  other: number,
  purchaseWithLabour: boolean,
): { primary: number; labourOther: number } {
  const charges = labour + other;
  return purchaseWithLabour
    ? { primary: net, labourOther: 0 }
    : { primary: net - charges, labourOther: charges };
}

/**
 * RP_STOCK_FINE.cs:2963-2973 selects average/group treatment for A/G and movement fine for N;
 * Dgv_Group_Stock at :3004-3040 values closing net at AVG_TOUCH, while Dgv_Net_Stock at
 * :3134-3160 carries the posted fine movements. DC_Main.cs:2011-2029 derives G from MELTING_PRC.
 * Blank returns persisted fine exactly, retaining today's BAR_DETL report.
 */
export function fineStockValue(
  netWt: number,
  persistedFine: number,
  type: FineStockType,
  averageTouch = 0,
  meltingPct = 0,
): number {
  if (type === 'A') return (netWt * averageTouch) / 100;
  if (type === 'G') return (netWt * meltingPct) / 100;
  return persistedFine;
}

/** TR_PR_SL_UAE.cs:10846: metal rate = ounce rate × FX rate / ounce conversion. */
export function ounceRatePerGram(ounceRate: number, fxRate: number, conversion: number): number {
  if (![ounceRate, fxRate, conversion].every(Number.isFinite) || conversion <= 0) {
    throw new SettingsBehaviorValidationError('ounce rate conversion input is invalid');
  }
  return (ounceRate * fxRate) / conversion;
}

/** MS_ACCT.cs:6285,7741,8800 and MS_ADD_MAST.cs:3519: configured account-code length. */
export function accountCodeHasConfiguredLength(code: unknown, length: number | null): boolean {
  return length == null || String(code ?? '').length === length;
}

/** TR_TAG_OPBL.cs:13372 and TR_PURC.cs:11190: legacy imports use four digits; tag-report mode five. */
export function tagSerialWidth(settings: Pick<SettingsBehavior, 'vbImport' | 'tagReport'>): number {
  if (settings.vbImport) return 4;
  if (settings.tagReport) return 5;
  return 6;
}

/** TR_SALE.cs:11139-11692 / TR_PURC.cs:7468: derive the persisted labour rate from amount+basis. */
export function generatedLabourRate(
  amount: number,
  basis: number,
  enabled: boolean,
): number | null {
  if (!enabled || amount === 0 || basis <= 0) return null;
  return roundEven(amount / basis, 2);
}

/** Ac_Ledr.cs:1088-1182,1421-1519: pre-opening pledge/loan rows are included only when enabled. */
export function includeOpeningLedgerRow(
  kind: 'dhrn' | 'loan',
  settings: SettingsBehavior,
): boolean {
  return kind === 'dhrn' ? settings.openingDhrn : settings.openingLoan;
}

/** TR_PURC.cs:11977: Y defaults a new purchase to desktop cash-purchase account 00050. */
export function cashPurchaseParty(requested: unknown, enabled: boolean): string {
  const value = raw(requested);
  return value || (enabled ? '00050' : '');
}

/** Ac_Stock.cs:112-113: OLD posts edited line weights; NEW posts original tag weights. */
export function stockMovementWeights(
  line: { grossWt?: number; netWt?: number },
  tag: Record<string, unknown> | undefined,
  source: StockWeightSource,
): { grossWt: number; netWt: number } {
  const useTag = source === 'NEW' && tag != null;
  return {
    grossWt: Number(useTag ? (tag.ITM_GWT ?? 0) : (line.grossWt ?? 0)),
    netWt: Number(useTag ? (tag.ITM_NWT ?? 0) : (line.netWt ?? 0)),
  };
}

/** TR_SALE.cs:16032-16053 and :16458-16603: company flags gate integration delivery. */
export function messageDeliveryEnabled(
  kind: 'admin-sms' | 'customer-sms' | 'dhrn-whatsapp' | 'scheme-whatsapp',
  settings: SettingsBehavior,
): boolean {
  if (kind === 'admin-sms') return settings.adminSms !== false;
  if (kind === 'customer-sms') return settings.customerSms !== false;
  if (kind === 'dhrn-whatsapp') return settings.dhrnWhatsapp !== false;
  return settings.schemeWhatsapp !== false;
}
