import type { VoucherScope } from '../vouchers/numbering.js';

export const DEFAULT_CASH_LIMIT = 200000;
export const DEFAULT_PAN_CARD_VAL = 200000;
export const DEFAULT_INT_YEAR_DAYS = 360;
/** Blank OZ_CON_VAL retains the web's pre-setting troy-ounce constant byte-for-byte. */
export const DEFAULT_OUNCE_CONVERSION = 31.1034768;
export const DESKTOP_OUNCE_CONVERSION = 31.1035;

export type InterestDayMode = '1' | '2';
export type LoanInterestType = 'M' | 'D';
export type FineStockType = '' | 'A' | 'N' | 'G' | 'F';
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
  /**
   * `CO_SET_NEW` business switches (parity plan P4).
   *
   * WHY THESE WERE ALL INERT
   * `resolveSettingsBehaviorTx` read `CO_SET` only. Every one of these lives in `CO_SET_NEW`, which
   * the loader never touched — so 74 of the 130 persisted settings were editable in the UI, stored
   * on save, and read by nothing. That single omission, not 74 separate ones, is why the settings
   * surface looked complete and behaved as if it did not exist.
   *
   * Each is measured: the desktop reads it in the number of forms recorded in
   * `project-memory/parity/SETTINGS-EFFECT.json`, so none of these is a speculative switch.
   */
  /** `NEGATIVE_STK_SALE` — allow a sale to take stock below zero. Desktop refuses when 'N' (TR_SALE.cs:10398 "Negative Stock is Not Allow", TR_SALE_HM.cs:7381). */
  negativeStockSale: boolean;
  /** `PURC_WITH_HMTAX` — apply GST to the hallmark charge on a purchase (31 desktop forms). */
  purchaseWithHallmarkTax: boolean;
  /** `SALES_WITH_HMTAX` — the same on a sale (28 desktop forms). */
  salesWithHallmarkTax: boolean;
  /** `SL_NWT_LOCK` — lock the sale line's net weight against operator retyping (11 desktop forms). */
  saleNetWeightLocked: boolean;
  /** `ITM_FINE_LOCK` — lock the computed fine weight. */
  itemFineLocked: boolean;
  /** `LBR_WITH_GHT` — include ghat weight in the labour base (23 desktop forms). */
  labourIncludesGhat: boolean;
  /**
   * `CUR_DAY_POSTING` — the STOCK-REBUILD scope, not a posting-date restriction.
   *
   * The column name invites the wrong reading and this comment previously carried it ("restrict
   * posting to the current day"). The desktop disagrees: the flag is bound to a combo labelled
   * "Stock Refresh" (`UT_SETTING_MAIN.cs:9456`, `cboStkRefresh`) and is read in exactly two places,
   * both about rebuilding `MAIN_STOCK`:
   *
   *   `MS_UPDATE.cs:2852-2868` StockRefresh() — when 'Y', delete and rebuild `MAIN_STOCK` only from a
   *     chosen date forward, clamped to the year's opening date; when 'N'/blank, delete EVERY
   *     `MAIN_STOCK` row for the company and rebuild from scratch.
   *   `Ac_Stock.cs:13` Itm_Opbl_Stk() — when 'Y' and no stock voucher is named, skip the
   *     opening-stock inserts entirely, because the windowed rebuild will not reach them.
   *
   * It is therefore a utility setting, and it is NOT wired to a consumer here: the web has no
   * equivalent full stock-rebuild utility for it to govern. Loaded and named honestly rather than
   * attached to an invented posting guard, which is what the old comment would have produced.
   */
  stockRefreshFromDateOnly: boolean;
  /** `ESTMATE_BANK_LOCK` — lock the bank account on an estimate (23 desktop forms). */
  estimateBankLocked: boolean;
  /**
   * `ESTMATE_TAX` — whether tax is charged on a non-tax (estimate) book.
   *
   * `TR_SALE.cs:14168` loads the tax master when the book type is 'T' OR this flag is 'Y'. So a tax
   * book always taxes; an estimate book taxes only when the company switches it on. Verified rather
   * than inferred, because the name alone would equally support "tax an estimate differently".
   */
  estimateTax: boolean;
  /** `PR_TDS_TAX` — expose and post purchase TDS; desktop writes blank/zero when off (TR_PURC.cs:12160-12172). */
  purchaseTdsEnabled: boolean;
  /** `OLD_PURC_TOUCH` — generate the old-gold purchase touch rather than taking it as typed. */
  oldPurchaseTouchGenerated: boolean;
  /** `SILVER_THREE_DIGIT` — silver weights carry three decimals (11 desktop forms). */
  silverThreeDigit: boolean;
  /** `OTH_ITM_WT_REMOVE` — exclude other-item weight from the line total. */
  otherItemWeightRemoved: boolean;
  /** `ORD_TAG_STK_LESS` — an order may reduce tag stock. */
  orderReducesTagStock: boolean;
  /**
   * `SL_TAG_WT_DIFF` — writes the tag-versus-line weight difference back to stock. NOT a permission.
   *
   * The name reads like a validation switch and this comment previously claimed it was one ("permit a
   * sale when the tag's weight differs"). The desktop does something else entirely: when 'Y',
   * `Ac_Stock.cs:125-130` writes TWO extra `MAIN_STOCK` rows per sale to reconcile the difference
   * between the tag's recorded weight and the weight actually sold —
   *
   *   ISR_NO 7, `VCH_SRNO` 111, sign '-', `TAG_GWT - ITM_GWT` / `TAG_NWT - ITM_NWT`
   *     where `(ITM_GWT+ITM_NWT) - (TAG_GWT+TAG_NWT) < 0`
   *   ISR_NO 8, `VCH_SRNO` 222, sign '+', `ITM_GWT - TAG_GWT` / `ITM_NWT - TAG_NWT`
   *     where that difference is `> 0`
   *
   * both gated on `TAG_GWT <> 0`. The 111/222 serials are sentinels marking a reconciliation row
   * rather than a real tag instance. Implementing it is a stock-writer change, so it is loaded and
   * NOT yet consumed; the semantics are recorded here so it cannot be built from the name.
   */
  saleTagWeightDiffReconciled: boolean;
  /** `PURC_LOT` — lot entry on purchase. */
  purchaseLot: boolean;
  /** `ITM_WITH_LOT_STK` — track stock lot-wise (10 desktop forms). */
  itemWithLotStock: boolean;
  /** `TOT_FINE_STK_TYPE` — the basis the total fine-stock figure aggregates on. */
  totalFineStockType: string;
  /** `BRANCH_ALL_AC_SHOW` — widen account lookups company-wide (68 desktop forms; TR_SALE.cs:17296-17320). */
  branchAllAccountShow: boolean;
  /** `DUP_PRINT` — offer duplicate/triplicate print copies (23 desktop forms; MS_PRINT.cs:389-424). */
  duplicatePrint: boolean;
  /** `QR_CODE_GEN` — emit a QR code on documents. */
  qrCodeGeneration: boolean;
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
  options: { zeroUsesDefault?: boolean; negativeToZero?: boolean; zeroDisables?: boolean } = {},
): number {
  const configured = raw(value);
  if (!configured) return defaultValue;
  const parsed = Number(configured);
  if (!Number.isFinite(parsed)) {
    throw new SettingsBehaviorValidationError(`CO_SET.${key} is invalid: ${configured}`);
  }
  if (options.zeroUsesDefault && parsed === 0) return defaultValue;
  if (options.negativeToZero && parsed < 0) return 0;
  /**
   * `zeroDisables`: an explicitly configured 0 means "no ceiling", and is NOT an error.
   *
   * This exists because `CASH_LIMIT` is 0 in EVERY real installation examined — Live24, Next23, Next24 and
   * Next25, on every CO_SET row — while those same shops post cash vouchers freely (Live24 alone has 133
   * CASH PAY and 56 CASH REC vouchers). So the desktop treats 0 as "ceiling disabled", and the previous
   * `parsed <= 0` throw made `resolveSettingsBehavior` fail for every real customer database.
   *
   * The existing unit test 'CASH_LIMIT zero disables only the cash ceiling' did not catch this because it
   * passes `cashLimit: 0` straight into `tenderThresholdDecision`, bypassing this loader. It proved the
   * consumer handles 0; nothing proved the loader could ever produce it.
   */
  if (options.zeroDisables && parsed === 0) return 0;
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
      // 0 = no cash ceiling. Every real installation ships 0; see finiteNumber for the evidence.
      zeroDisables: true,
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
    /**
     * 'F' is accepted because it is what the desktop actually STORES and defaults to.
     *
     * MS_OPNCOMP.cs:765-767 maps a blank FINE_STK_TYPE to 'F'. The enum previously listed only A/N/G,
     * following RP_STOCK_FINE.cs:2963-2977 — but that is one REPORT's accepted filter values, not the set of
     * values the column can hold. The result was that `resolveSettingsBehavior` threw
     * "CO_SET.FINE_STK_TYPE is invalid: F" for every real installation examined: Live24 (F,F),
     * Next23 (F,A), Next24 (F,F) and Next25 (F,A,A).
     *
     * Accepting it is behaviour-neutral downstream: `fineStockValue` special-cases only 'A' and 'G' and
     * returns the persisted fine for everything else, so 'F' and blank already computed identically.
     */
    fineStockType: enumValue(values.FINE_STK_TYPE, 'FINE_STK_TYPE', ['A', 'N', 'G', 'F'], ''),
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
    // ---- CO_SET_NEW business switches (P4) ------------------------------------------------------
    // Defaults follow the desktop's own blank handling: a flag the installer never set behaves as
    // the desktop behaves with a blank column, which for these is the permissive/off value. Where a
    // desktop default is known to differ it is cited on the field in the interface above.
    negativeStockSale: flagOf(values.NEGATIVE_STK_SALE, 'NEGATIVE_STK_SALE'),
    purchaseWithHallmarkTax: flagOf(values.PURC_WITH_HMTAX, 'PURC_WITH_HMTAX'),
    salesWithHallmarkTax: flagOf(values.SALES_WITH_HMTAX, 'SALES_WITH_HMTAX'),
    saleNetWeightLocked: flagOf(values.SL_NWT_LOCK, 'SL_NWT_LOCK'),
    itemFineLocked: flagOf(values.ITM_FINE_LOCK, 'ITM_FINE_LOCK'),
    labourIncludesGhat: flagOf(values.LBR_WITH_GHT, 'LBR_WITH_GHT'),
    stockRefreshFromDateOnly: flagOf(values.CUR_DAY_POSTING, 'CUR_DAY_POSTING'),
    estimateBankLocked: flagOf(values.ESTMATE_BANK_LOCK, 'ESTMATE_BANK_LOCK'),
    estimateTax: flagOf(values.ESTMATE_TAX, 'ESTMATE_TAX'),
    purchaseTdsEnabled: flagOf(values.PR_TDS_TAX, 'PR_TDS_TAX'),
    oldPurchaseTouchGenerated: flagOf(values.OLD_PURC_TOUCH, 'OLD_PURC_TOUCH'),
    silverThreeDigit: flagOf(values.SILVER_THREE_DIGIT, 'SILVER_THREE_DIGIT'),
    otherItemWeightRemoved: flagOf(values.OTH_ITM_WT_REMOVE, 'OTH_ITM_WT_REMOVE'),
    orderReducesTagStock: flagOf(values.ORD_TAG_STK_LESS, 'ORD_TAG_STK_LESS'),
    saleTagWeightDiffReconciled: flagOf(values.SL_TAG_WT_DIFF, 'SL_TAG_WT_DIFF'),
    purchaseLot: flagOf(values.PURC_LOT, 'PURC_LOT'),
    itemWithLotStock: flagOf(values.ITM_WITH_LOT_STK, 'ITM_WITH_LOT_STK'),
    // MsTotFineStkType defaults a blank column to 'I' (MS_OPNCOMP.cs), not to empty.
    totalFineStockType:
      String(values.TOT_FINE_STK_TYPE ?? '')
        .trim()
        .charAt(0)
        .toUpperCase() || 'I',
    branchAllAccountShow: flagOf(values.BRANCH_ALL_AC_SHOW, 'BRANCH_ALL_AC_SHOW'),
    duplicatePrint: flagOf(values.DUP_PRINT, 'DUP_PRINT'),
    qrCodeGeneration: flagOf(values.QR_CODE_GEN, 'QR_CODE_GEN'),
  };
}

/**
 * Blank-column defaults, transcribed from `MS_OPNCOMP.cs` where the desktop fills a blank setting
 * before use (the `if (MsX == "") MsX = "V"` block around `:1036`).
 *
 * These are NOT guesses and could not be: the default differs per setting and two of them are the
 * permissive value. `NEGATIVE_STK_SALE` defaults to **'Y'** (`MS_OPNCOMP.cs:1036-1038`) and
 * `LBR_WITH_GHT` to **'Y'** — so a company that never opened the setting ALLOWS negative stock and
 * DOES include ghat in the labour base. Defaulting those to 'N', as a uniform false would, inverts
 * live behaviour: it would start refusing sales that the desktop accepts.
 *
 * Found the hard way — a uniform blank-is-false default failed 20 existing sale tests, which were
 * right and the default was wrong.
 */
const BLANK_FLAG_DEFAULT: Record<string, 'Y' | 'N'> = {
  NEGATIVE_STK_SALE: 'Y', // MS_OPNCOMP.cs:1036-1038
  LBR_WITH_GHT: 'Y', // MsLbrWithGht
  PURC_WITH_HMTAX: 'N', // MsPurcWithHmTax
  SALES_WITH_HMTAX: 'N', // MsSalesWithHmTax
  PR_TDS_TAX: 'N', // MsPrTdsTax
  SL_NWT_LOCK: 'N', // MsSlNwtLock
  ITM_FINE_LOCK: 'N', // MsItmFineLock
  CUR_DAY_POSTING: 'N', // MsCurDayPosting
  ESTMATE_BANK_LOCK: 'N', // MsEstmateBankLock
  ESTMATE_TAX: 'N', // MsTaxWithEstmate
  OLD_PURC_TOUCH: 'N', // MsOldPurcTchGen
  SILVER_THREE_DIGIT: 'N', // MsSilverWt3Digit
  OTH_ITM_WT_REMOVE: 'N', // MsOthItmWtRemove
  ORD_TAG_STK_LESS: 'N',
  SL_TAG_WT_DIFF: 'N', // MsSlAndTagWtDiff
  PURC_LOT: 'N', // MsPurcLot
  ITM_WITH_LOT_STK: 'N', // MsItmWitLotStk
  BRANCH_ALL_AC_SHOW: 'N',
  DUP_PRINT: 'N', // MsSlDupPrint
  QR_CODE_GEN: 'N', // MsQrCodeGen
};

/**
 * A `CO_SET_NEW` Y/N flag, with the desktop's own blank default.
 *
 * Deliberately tolerant of blank, which is what an installation that never opened the setting
 * stores, and deliberately NOT tolerant of an unexpected value — a column holding 'X' means the
 * migration or the desktop wrote something this code does not understand, and silently reading it
 * as false would hide that.
 */
function flagOf(value: unknown, column: string): boolean {
  const text = String(value ?? '')
    .trim()
    .toUpperCase();
  if (text === '') return (BLANK_FLAG_DEFAULT[column] ?? 'N') === 'Y';
  if (text === 'Y' || text === 'N') return text === 'Y';
  throw new SettingsBehaviorValidationError(`CO_SET_NEW.${column} is invalid: ${text}`);
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
              "DHRN_WAPP", "SCHM_WAPP", "FX_RATE", "FX_CODE", "ADMIN_SMS", "CUST_SMS",
              "DUP_PRINT"
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
  /**
   * `CO_SET_NEW` — the second configuration surface, read here for the first time (P4).
   *
   * This loader read `CO_SET` only, so every setting stored in `CO_SET_NEW` was editable in the UI,
   * persisted on save, and consumed by nothing: 74 of the 130 settings were inert for this one
   * reason. Among them are switches that change money — hallmark tax on purchase and sale, whether a
   * sale may drive stock negative, whether purchase TDS is posted at all.
   *
   * A MISSING ROW IS NOT AN ERROR, unlike `CO_SET`. `provisionCompanySettingsTx` creates
   * `CO_SET_NEW` by cloning a template, and a company provisioned before that existed legitimately
   * has no row. Treating absence as "every flag blank" keeps those companies working exactly as they
   * do today, whereas failing closed would take a live company down to honour a setting it never had.
   */
  let newRows: SettingsRow[] = [];
  try {
    newRows = await tx.$queryRawUnsafe(
      `SELECT "NEGATIVE_STK_SALE", "PURC_WITH_HMTAX", "SALES_WITH_HMTAX", "SL_NWT_LOCK",
              "ITM_FINE_LOCK", "LBR_WITH_GHT", "CUR_DAY_POSTING", "ESTMATE_BANK_LOCK",
              "ESTMATE_TAX", "PR_TDS_TAX", "OLD_PURC_TOUCH", "SILVER_THREE_DIGIT",
              "OTH_ITM_WT_REMOVE", "ORD_TAG_STK_LESS", "SL_TAG_WT_DIFF", "PURC_LOT",
              "ITM_WITH_LOT_STK", "TOT_FINE_STK_TYPE", "BRANCH_ALL_AC_SHOW", "QR_CODE_GEN"
         FROM "CO_SET_NEW"
        WHERE tenant_id=$1 AND "CO_CODE"::text=$2::text
        LIMIT 1`,
      scope.tenantId,
      String(scope.coCode),
    );
  } catch (error) {
    throw new SettingsBehaviorValidationError(
      `unable to read CO_SET_NEW behavior settings for company ${String(scope.coCode)}`,
    );
  }
  return resolveSettingsBehavior({ ...(rows[0] as SettingsRow), ...(newRows[0] ?? {}) });
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
