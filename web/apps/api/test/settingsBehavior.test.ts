import { describe, expect, it } from 'vitest';
import { tenderThresholdDecision } from '../src/modules/finance/tender.js';
import {
  DEFAULT_CASH_LIMIT,
  DEFAULT_INT_YEAR_DAYS,
  DEFAULT_OUNCE_CONVERSION,
  DEFAULT_PAN_CARD_VAL,
  DESKTOP_OUNCE_CONVERSION,
  SettingsBehaviorValidationError,
  accountCodeHasConfiguredLength,
  cashPurchaseParty,
  desktopDhrnInterest,
  fineStockValue,
  generatedLabourRate,
  includeOpeningLedgerRow,
  interestDayCount,
  messageDeliveryEnabled,
  ounceRatePerGram,
  purchaseAmountBase,
  purchaseExpenseSplit,
  resolveSettingsBehavior,
  saleAmountBase,
  stockMovementWeights,
  tagSerialWidth,
  interestTypeForBook,
} from '../src/modules/shared/settingsBehavior.js';

const blank = () =>
  resolveSettingsBehavior({
    CASH_LIMIT: '',
    PAN_CARD_VAL: null,
    LAST_DAY_LOCK: '',
    INT_YEAR_DAYS: '0',
    INT_DAY: '',
    LOAN_INT_TYPE: '',
    DHRN_INT_TYPE: '',
    DHIRN_COMPOUND: '',
    FINE_STK_TYPE: '',
    SL_AMT_TYPE: '',
    PR_AMT_TYPE: '',
    PURC_WITH_LBR: '',
    OZ_CON_VAL: '',
    ALL_ROF_REMOVE: '',
    AC_LC_CODE_LEN: '',
    VB_IMPORT: '',
    TAG_RPT: '',
    LBR_RATE_GEN: '',
    OP_DHRN: '',
    WEIGHT_PORT: '',
    LDR_SUMM: '',
    SMS_LINK: '',
    OP_LOAN: '',
    STK_RPT_TYPE: '',
    TOUCH_AUTO_SAVE: '',
    DHRN_PRC: '',
    IP_WITH_PC: '',
    CO_STK_MERGE: '',
    CARD_COM_ADJ: '',
    CASH_PURC_AC: '',
    STOCK_RPT_TYPE: '',
    DHRN_WAPP: '',
    SCHM_WAPP: '',
    FX_RATE: '',
    FX_CODE: '',
    ADMIN_SMS: '',
    CUST_SMS: '',
  });

describe('CO_SET behavior defaults', () => {
  it('keeps today’s behavior for every blank/absent requested setting', () => {
    expect(blank()).toEqual({
      cashLimit: DEFAULT_CASH_LIMIT,
      panCardVal: DEFAULT_PAN_CARD_VAL,
      lastDayLock: false,
      intYearDays: DEFAULT_INT_YEAR_DAYS,
      intDay: '1',
      loanIntType: 'M',
      dhrnIntType: 'M',
      dhrnCompound: true,
      fineStockType: '',
      saleAmountType: '',
      purchaseAmountType: '',
      purchaseWithLabour: true,
      ounceConversion: DEFAULT_OUNCE_CONVERSION,
      // MsRatePar defaults to per-gram when CO_SET.RATE_PAR is blank (MS_OPNCOMP.cs:747).
      rateBasis: 'G',
      // CO_SET.LBR_TYPE default: blank means no company basis configured.
      labourType: '',
      allRoundingRemoved: false,
      accountCodeLength: null,
      vbImport: false,
      tagReport: false,
      labourRateGeneration: false,
      openingDhrn: false,
      weightPort: null,
      ledgerSummary: false,
      smsGateway: '',
      openingLoan: false,
      stockReportGrossWeight: false,
      touchAutoSave: false,
      dhrnDefaultRate: null,
      exportDatabaseTarget: '',
      companyStockMerge: false,
      cardCommissionAdjustment: false,
      cashPurchaseAccount: false,
      stockWeightSource: '',
      dhrnWhatsapp: null,
      schemeWhatsapp: null,
      fxRate: null,
      fxCode: null,
      adminSms: null,
      customerSms: null,
    });
  });

  it.each([
    ['CASH_LIMIT', 'abc'],
    ['PAN_CARD_VAL', '-1'],
    ['LAST_DAY_LOCK', 'maybe'],
    ['INT_YEAR_DAYS', '-360'],
    ['INT_DAY', '3'],
    ['LOAN_INT_TYPE', 'X'],
    ['DHIRN_COMPOUND', 'X'],
    ['FINE_STK_TYPE', 'F'],
    ['SL_AMT_TYPE', 'X'],
    ['PR_AMT_TYPE', 'X'],
    ['PURC_WITH_LBR', 'X'],
    ['OZ_CON_VAL', '-1'],
    ['ALL_ROF_REMOVE', 'X'],
    ['AC_LC_CODE_LEN', '9'],
    ['VB_IMPORT', 'X'],
    ['TAG_RPT', 'X'],
    ['LBR_RATE_GEN', 'X'],
    ['OP_DHRN', 'X'],
    ['WEIGHT_PORT', 'ttyUSB0'],
    ['LDR_SUMM', 'X'],
    ['SMS_LINK', '999'],
    ['OP_LOAN', 'X'],
    ['STK_RPT_TYPE', 'X'],
    ['TOUCH_AUTO_SAVE', 'X'],
    ['DHRN_PRC', '-1'],
    ['IP_WITH_PC', 'X'],
    ['CO_STK_MERGE', 'X'],
    ['CARD_COM_ADJ', 'X'],
    ['CASH_PURC_AC', 'X'],
    ['STOCK_RPT_TYPE', 'X'],
    ['DHRN_WAPP', 'X'],
    ['SCHM_WAPP', 'X'],
    ['FX_RATE', '-1'],
    ['FX_CODE', 'US'],
    ['ADMIN_SMS', 'X'],
    ['CUST_SMS', 'X'],
  ])('fails closed for invalid configured %s', (key, value) => {
    expect(() => resolveSettingsBehavior({ [key]: value })).toThrow(
      SettingsBehaviorValidationError,
    );
  });
});

describe('desktop cash/PAN threshold decision table', () => {
  const decide = (cashAmount: number, priorCash: number, billValue: number) =>
    tenderThresholdDecision({
      cashAmount,
      priorCash,
      billValue,
      cashLimit: 200000,
      panCardVal: 200000,
    });

  it.each([
    [200000, 0, false],
    [200000.01, 0, true],
    [100000, 100000, false],
    [100000.01, 100000, true],
  ])('CASH_LIMIT uses strict > (%s + %s)', (cash, prior, blocked) => {
    expect(decide(cash, prior, 0).cashBlocked).toBe(blocked);
  });

  it.each([
    [199999.99, false],
    [200000, true],
    [200000.01, true],
  ])('PAN_CARD_VAL uses >= for bill value %s', (bill, required) => {
    expect(decide(0, 0, bill).panRequired).toBe(required);
  });

  it('CASH_LIMIT zero disables only the cash ceiling', () => {
    expect(
      tenderThresholdDecision({
        cashAmount: 999999,
        priorCash: 999999,
        billValue: 200000,
        cashLimit: 0,
        panCardVal: 200000,
      }),
    ).toEqual({ cashBlocked: false, panRequired: true });
  });
});

describe('desktop dhiran interest settings', () => {
  const calculate = (
    override: Partial<ReturnType<typeof blank>> = {},
    from = '2024-01-01',
    to = '2024-02-01',
  ) =>
    desktopDhrnInterest({
      principal: 10000,
      annualRatePct: 12,
      from,
      to,
      settings: { ...blank(), ...override },
      loanType: 'A',
    });

  it('INT_YEAR_DAYS changes the denominator', () => {
    expect(calculate({ intYearDays: 360 })).toBe(100);
    expect(calculate({ intYearDays: 365 })).toBe(99);
  });

  it('INT_DAY=2 includes the starting day while 1 is exclusive', () => {
    expect(interestDayCount('2024-01-01', '2024-01-31', '1')).toBe(30);
    expect(interestDayCount('2024-01-01', '2024-01-31', '2')).toBe(31);
    expect(calculate({ loanIntType: 'D', intDay: '1' }, '2024-01-01', '2024-01-31')).toBe(100);
    expect(calculate({ loanIntType: 'D', intDay: '2' }, '2024-01-01', '2024-01-31')).toBe(103);
  });

  it('LOAN_INT_TYPE switches 30-day monthly periods versus actual days', () => {
    expect(calculate({ loanIntType: 'M' }, '2024-01-01', '2024-02-15')).toBe(100);
    expect(calculate({ loanIntType: 'D' }, '2024-01-01', '2024-02-15')).toBe(150);
  });

  it('DHIRN_COMPOUND compounds complete 360-day blocks; N remains simple', () => {
    expect(
      desktopDhrnInterest({
        principal: 10000,
        annualRatePct: 12,
        from: '2024-01-01',
        to: '2024-12-26',
        months: 24,
        settings: { ...blank(), dhrnCompound: false },
      }),
    ).toBe(2400);
    expect(
      desktopDhrnInterest({
        principal: 10000,
        annualRatePct: 12,
        from: '2024-01-01',
        to: '2024-12-26',
        months: 24,
        settings: { ...blank(), dhrnCompound: true },
      }),
    ).toBe(2544);
  });
});

describe('book-driven interest type selection', () => {
  // TR_DHRN_REC.cs:5626-5634 and TR_DHRN_INTREC.cs:4265-4270 use LOAN_INT_TYPE only for the LOAN
  // books; TR_DHRN_REC.cs:5643 / TR_DHRN_INTREC.cs:4274,4280 use DHRN_INT_TYPE for everything else.
  const settings = { loanIntType: 'D' as const, dhrnIntType: 'M' as const };

  it('uses LOAN_INT_TYPE for the two desktop LOAN books', () => {
    expect(interestTypeForBook(settings, 'LOAN ISSUE')).toBe('D');
    expect(interestTypeForBook(settings, 'loan int entry')).toBe('D');
  });

  it('uses DHRN_INT_TYPE for pledge books, OS LETTER and unknown books', () => {
    expect(interestTypeForBook(settings, 'DHRN ISSUE')).toBe('M');
    expect(interestTypeForBook(settings, 'OS LETTER')).toBe('M');
    expect(interestTypeForBook(settings, '')).toBe('M');
  });
});

describe('batch-2 desktop setting decision tables', () => {
  const amountInput = { pcs: 2, grossWt: 12, netWt: 10, ghtWt: 1, fineWt: 9 };

  it.each([
    ['', 9],
    ['F', 9],
    ['G', 13],
    ['N', 11],
    ['P', 11],
  ] as const)('SL_AMT_TYPE=%s selects sale amount base %s', (type, expected) => {
    expect(saleAmountBase(amountInput, type)).toBe(expected);
  });

  it.each([
    ['', 9],
    ['F', 9],
    ['G', 12],
    ['N', 11],
    ['P', 9],
  ] as const)('PR_AMT_TYPE=%s selects purchase amount base %s', (type, expected) => {
    expect(purchaseAmountBase(amountInput, type)).toBe(expected);
  });

  it.each([
    ['', 8],
    ['N', 8],
    ['A', 9],
    ['G', 8.5],
  ] as const)('FINE_STK_TYPE=%s selects closing fine %s', (type, expected) => {
    expect(fineStockValue(10, 8, type, 90, 85)).toBe(expected);
  });

  it.each([
    [true, { primary: 120, labourOther: 0 }],
    [false, { primary: 100, labourOther: 20 }],
  ])('PURC_WITH_LBR=%s controls expense allocation', (enabled, expected) => {
    expect(purchaseExpenseSplit(120, 15, 5, enabled as boolean)).toEqual(expected);
  });

  it('OZ_CON_VAL defaults blank to today, maps zero to desktop default, and changes conversion', () => {
    expect(resolveSettingsBehavior({ OZ_CON_VAL: '' }).ounceConversion).toBe(
      DEFAULT_OUNCE_CONVERSION,
    );
    expect(resolveSettingsBehavior({ OZ_CON_VAL: '0' }).ounceConversion).toBe(
      DESKTOP_OUNCE_CONVERSION,
    );
    expect(ounceRatePerGram(3000, 4, 30)).toBe(400);
    expect(ounceRatePerGram(3000, 4, 40)).toBe(300);
  });

  it('ALL_ROF_REMOVE is false when blank and true only for Y', () => {
    expect(resolveSettingsBehavior({ ALL_ROF_REMOVE: '' }).allRoundingRemoved).toBe(false);
    expect(resolveSettingsBehavior({ ALL_ROF_REMOVE: 'N' }).allRoundingRemoved).toBe(false);
    expect(resolveSettingsBehavior({ ALL_ROF_REMOVE: 'Y' }).allRoundingRemoved).toBe(true);
  });
});

describe('batch-3 desktop setting decision tables', () => {
  it.each([
    ['AC_LC_CODE_LEN', '5', 'accountCodeLength', 5],
    ['VB_IMPORT', 'Y', 'vbImport', true],
    ['TAG_RPT', 'Y', 'tagReport', true],
    ['LBR_RATE_GEN', 'Y', 'labourRateGeneration', true],
    ['OP_DHRN', 'Y', 'openingDhrn', true],
    ['WEIGHT_PORT', 'COM3', 'weightPort', 'COM3'],
    ['LDR_SUMM', 'Y', 'ledgerSummary', true],
    ['SMS_LINK', '022', 'smsGateway', '022'],
    ['OP_LOAN', 'Y', 'openingLoan', true],
    ['STK_RPT_TYPE', 'G', 'stockReportGrossWeight', true],
    ['TOUCH_AUTO_SAVE', 'Y', 'touchAutoSave', true],
    ['DHRN_PRC', '0', 'dhrnDefaultRate', 2],
    ['IP_WITH_PC', 'B', 'exportDatabaseTarget', 'B'],
    ['CO_STK_MERGE', 'Y', 'companyStockMerge', true],
    ['CARD_COM_ADJ', 'Y', 'cardCommissionAdjustment', true],
    ['CASH_PURC_AC', 'Y', 'cashPurchaseAccount', true],
    ['STOCK_RPT_TYPE', 'NEW', 'stockWeightSource', 'NEW'],
    ['DHRN_WAPP', 'Y', 'dhrnWhatsapp', true],
    ['SCHM_WAPP', 'Y', 'schemeWhatsapp', true],
    ['FX_RATE', '0', 'fxRate', 87],
    ['FX_CODE', 'aed', 'fxCode', 'AED'],
    ['ADMIN_SMS', 'Y', 'adminSms', true],
    ['CUST_SMS', 'Y', 'customerSms', true],
  ] as const)('%s strictly maps configured %s', (rawKey, rawValue, field, expected) => {
    expect(resolveSettingsBehavior({ [rawKey]: rawValue })[field]).toBe(expected);
  });

  it('applies behavioral forks while blank keeps the prior result', () => {
    const base = blank();
    expect(accountCodeHasConfiguredLength('12345', base.accountCodeLength)).toBe(true);
    expect(accountCodeHasConfiguredLength('12345', 4)).toBe(false);
    expect(tagSerialWidth(base)).toBe(6);
    expect(tagSerialWidth({ vbImport: false, tagReport: true })).toBe(5);
    expect(tagSerialWidth({ vbImport: true, tagReport: false })).toBe(4);
    expect(generatedLabourRate(25, 10, false)).toBeNull();
    expect(generatedLabourRate(25, 10, true)).toBe(2.5);
    expect(includeOpeningLedgerRow('dhrn', base)).toBe(false);
    expect(includeOpeningLedgerRow('dhrn', { ...base, openingDhrn: true })).toBe(true);
    expect(includeOpeningLedgerRow('loan', { ...base, openingLoan: true })).toBe(true);
    expect(cashPurchaseParty('', false)).toBe('');
    expect(cashPurchaseParty('', true)).toBe('00050');
    expect(
      stockMovementWeights({ grossWt: 10, netWt: 8 }, { ITM_GWT: 12, ITM_NWT: 9 }, ''),
    ).toEqual({ grossWt: 10, netWt: 8 });
    expect(
      stockMovementWeights({ grossWt: 10, netWt: 8 }, { ITM_GWT: 12, ITM_NWT: 9 }, 'NEW'),
    ).toEqual({ grossWt: 12, netWt: 9 });
    expect(messageDeliveryEnabled('admin-sms', base)).toBe(true);
    expect(messageDeliveryEnabled('admin-sms', { ...base, adminSms: false })).toBe(false);
    expect(messageDeliveryEnabled('admin-sms', { ...base, adminSms: true })).toBe(true);
    expect(messageDeliveryEnabled('customer-sms', { ...base, customerSms: true })).toBe(true);
    expect(messageDeliveryEnabled('dhrn-whatsapp', { ...base, dhrnWhatsapp: true })).toBe(true);
    expect(messageDeliveryEnabled('scheme-whatsapp', { ...base, schemeWhatsapp: true })).toBe(true);
  });
});
