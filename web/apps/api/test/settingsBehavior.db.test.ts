import { PrismaClient } from '@prisma/client';
import { applyLastDayLock } from '../src/modules/shared/lastDayLock.js';
import { withTenant } from '@datacare/db';
import { afterAll, beforeAll, beforeEach, describe, expect, it } from 'vitest';
import { issueDhrn } from '../src/modules/dhrn/dhrn.js';
import { postReceipt } from '../src/modules/finance/finance.js';
import { tenderThresholdDecision } from '../src/modules/finance/tender.js';
import { PeriodLockValidationError } from '../src/modules/posting/posting.js';
import {
  fineStockValue,
  ounceRatePerGram,
  purchaseAmountBase,
  purchaseExpenseSplit,
  resolveSettingsBehaviorTx,
  saleAmountBase,
  type SettingsBehavior,
} from '../src/modules/shared/settingsBehavior.js';
import { resolveRoundingPolicyTx } from '../src/modules/shared/roundingPolicyLoader.js';
import type { VoucherScope } from '../src/modules/vouchers/numbering.js';

const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const databaseDescribe = RUN ? describe : describe.skip;
const TENANT = 'settings-behavior-db';
const CO = '01';
const LC = '01';
const YEAR = '2026-2027';
const RCT = 'RCT';
const DHR = 'DHR';

const scope = (book: string): VoucherScope => ({
  tenantId: TENANT,
  coCode: CO,
  lcCode: LC,
  coYear: YEAR,
  coBook: book,
});

databaseDescribe('restricted-role CO_SET behavior integration', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;

  const cleanup = async () => {
    for (const table of [
      'AC_DATA',
      'ROJ_MEL_DATA',
      'DHRN_DATA',
      'DHRN_ISU_DETL',
      'DHRN_ISU_DATA',
      'DHRN_REC_DATA',
      'CASH_DATA',
      'TEMP_BOOK_DATA',
      'BOOK_DATA',
      'CO_SET',
    ]) {
      await owner.$executeRawUnsafe(`DELETE FROM "${table}" WHERE tenant_id=$1`, TENANT);
    }
  };

  const seed = async () => {
    await owner.$executeRawUnsafe(
      `INSERT INTO "CO_SET"(
         tenant_id,"CO_CODE","LOCK_DATE","CASH_LIMIT","PAN_CARD_VAL","LAST_DAY_LOCK",
         "INT_YEAR_DAYS","INT_DAY","LOAN_INT_TYPE","DHIRN_COMPOUND",
         "FINE_STK_TYPE","SL_AMT_TYPE","PR_AMT_TYPE","PURC_WITH_LBR","OZ_CON_VAL",
         "ALL_ROF_REMOVE","AC_LC_CODE_LEN","VB_IMPORT","TAG_RPT","LBR_RATE_GEN",
         "OP_DHRN","WEIGHT_PORT","LDR_SUMM","SMS_LINK","OP_LOAN","STK_RPT_TYPE","TOUCH_AUTO_SAVE",
         "DHRN_PRC","IP_WITH_PC","CO_STK_MERGE","CARD_COM_ADJ","CASH_PURC_AC",
         "STOCK_RPT_TYPE","DHRN_WAPP","SCHM_WAPP","FX_RATE","FX_CODE","ADMIN_SMS","CUST_SMS")
       VALUES ($1,$2,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL)`,
      TENANT,
      CO,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "BOOK_DATA"(
         tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME","MAIN_BOOK",
         "CUR_USE","BOOK_TBL_NAME") VALUES
       ($1,$2,$3,$4,'Cash Receipt','CREC','CASH REC','Y','CASH_DATA'),
       ($1,$2,$3,$5,'Dhiran Issue','DISU','DHRN ISSUE','Y','DHRN_ISU_DATA')`,
      TENANT,
      CO,
      LC,
      RCT,
      DHR,
    );
  };

  const set = async (patch: Partial<Record<keyof SettingsBehavior, string | null>>) => {
    const columns: Record<keyof SettingsBehavior, string> = {
      cashLimit: 'CASH_LIMIT',
      panCardVal: 'PAN_CARD_VAL',
      lastDayLock: 'LAST_DAY_LOCK',
      intYearDays: 'INT_YEAR_DAYS',
      intDay: 'INT_DAY',
      loanIntType: 'LOAN_INT_TYPE',
      dhrnIntType: 'DHRN_INT_TYPE',
      dhrnCompound: 'DHIRN_COMPOUND',
      fineStockType: 'FINE_STK_TYPE',
      // labourType was missing from this map, so the helper could not set CO_SET.LBR_TYPE at all - the
      // key exists on SettingsBehavior and every other key was present. Surfaced by typechecking the tests.
      labourType: 'LBR_TYPE',
      saleAmountType: 'SL_AMT_TYPE',
      purchaseAmountType: 'PR_AMT_TYPE',
      purchaseWithLabour: 'PURC_WITH_LBR',
      ounceConversion: 'OZ_CON_VAL',
      rateBasis: 'RATE_PAR',
      allRoundingRemoved: 'ALL_ROF_REMOVE',
      accountCodeLength: 'AC_LC_CODE_LEN',
      vbImport: 'VB_IMPORT',
      tagReport: 'TAG_RPT',
      labourRateGeneration: 'LBR_RATE_GEN',
      openingDhrn: 'OP_DHRN',
      weightPort: 'WEIGHT_PORT',
      ledgerSummary: 'LDR_SUMM',
      smsGateway: 'SMS_LINK',
      openingLoan: 'OP_LOAN',
      stockReportGrossWeight: 'STK_RPT_TYPE',
      touchAutoSave: 'TOUCH_AUTO_SAVE',
      dhrnDefaultRate: 'DHRN_PRC',
      exportDatabaseTarget: 'IP_WITH_PC',
      companyStockMerge: 'CO_STK_MERGE',
      cardCommissionAdjustment: 'CARD_COM_ADJ',
      cashPurchaseAccount: 'CASH_PURC_AC',
      stockWeightSource: 'STOCK_RPT_TYPE',
      dhrnWhatsapp: 'DHRN_WAPP',
      schemeWhatsapp: 'SCHM_WAPP',
      fxRate: 'FX_RATE',
      fxCode: 'FX_CODE',
      adminSms: 'ADMIN_SMS',
      customerSms: 'CUST_SMS',
    };
    // Ten CO_SET columns are numeric after the column-type correction, so a bare string parameter fails with
    // `42804 ... is of type double precision but expression is of type text`, and an empty string fails with
    // `22P02 invalid input syntax`. The patch API stays string-based, matching the real settings surface; the
    // conversion happens here at the write.
    const NUMERIC_COLUMNS = new Set([
      'CASH_LIMIT',
      'PAN_CARD_VAL',
      'INT_YEAR_DAYS',
      'TAX_ROF',
      'LBR_ROF',
      'ITM_RATE_ROF',
      'OZ_CON_VAL',
      'FX_RATE',
      'DHRN_PRC',
      'THEME',
    ]);
    for (const [key, value] of Object.entries(patch)) {
      const column = columns[key as keyof SettingsBehavior];
      const bound =
        NUMERIC_COLUMNS.has(column) && value != null
          ? String(value).trim() === ''
            ? null
            : Number(value)
          : value;
      await owner.$executeRawUnsafe(
        `UPDATE "CO_SET" SET "${column}"=$1 WHERE tenant_id=$2 AND "CO_CODE"=$3`,
        bound,
        TENANT,
        CO,
      );
    }
  };

  const persistOutcome = async (label: string, value: number | boolean) => {
    const encoded = `${label}:${String(value)}`;
    await withTenant(runtime, TENANT, async (tx) => {
      await tx.$executeRawUnsafe(
        `INSERT INTO "TEMP_BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","VCH_NO","BOOK_NAME")
         VALUES ($1,$2,$3,'S2',$4,$5)`,
        TENANT,
        CO,
        LC,
        label,
        encoded,
      );
    });
    const rows = (await owner.$queryRawUnsafe(
      `SELECT "BOOK_NAME" FROM "TEMP_BOOK_DATA"
       WHERE tenant_id=$1 AND "CO_BOOK"='S2' AND "VCH_NO"=$2`,
      TENANT,
      label,
    )) as Array<{ BOOK_NAME: string }>;
    expect(rows.at(-1)?.BOOK_NAME).toBe(encoded);
  };

  const receipt = (amount: number, vchDate?: string) =>
    postReceipt(runtime, {
      scope: scope(RCT),
      partyAc: 'PARTY',
      amount,
      mode: 'cash',
      vchDate,
      mainUser: 'restricted-user',
    });

  const persistedInterest = async (options: {
    from: string;
    to: string;
    months: number;
  }): Promise<number> => {
    const created = await issueDhrn(runtime, {
      scope: scope(DHR),
      borrowerAc: 'BORROWER',
      principal: 10000,
      intPrc: 12,
      intMonths: options.months,
      fromDate: options.from,
      toDate: options.to,
      loanType: 'A',
      mainUser: 'restricted-user',
    });
    const rows = (await owner.$queryRawUnsafe(
      `SELECT "INT_AMT"::float value FROM "DHRN_ISU_DATA"
        WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "CO_BOOK"=$3 AND "VCH_NO"=$4`,
      TENANT,
      CO,
      DHR,
      String(created.vchNo).padStart(5, '0'),
    )) as Array<{ value: number }>;
    expect(rows).toHaveLength(1);
    return Number(rows[0]!.value);
  };

  beforeAll(async () => {
    const ownerUrl = process.env.MIGRATE_DATABASE_URL;
    const runtimeUrl = process.env.DATABASE_URL;
    if (!ownerUrl || !runtimeUrl) {
      throw new Error('DB settings tests require MIGRATE_DATABASE_URL and DATABASE_URL');
    }
    owner = new PrismaClient({ datasources: { db: { url: ownerUrl } } });
    runtime = new PrismaClient({ datasources: { db: { url: runtimeUrl } } });
  });

  beforeEach(async () => {
    await cleanup();
    await seed();
  });

  afterAll(async () => {
    if (owner) await cleanup();
    if (runtime) await runtime.$disconnect();
    if (owner) await owner.$disconnect();
  });

  it('blank company row resolves all seven pre-setting defaults', async () => {
    const configured = await withTenant(runtime, TENANT, (tx: any) =>
      resolveSettingsBehaviorTx(tx, { tenantId: TENANT, coCode: CO }),
    );
    expect(configured).toEqual({
      cashLimit: 200000,
      panCardVal: 200000,
      lastDayLock: false,
      intYearDays: 360,
      intDay: '1',
      loanIntType: 'M',
      dhrnIntType: 'M',
      dhrnCompound: true,
      fineStockType: '',
      saleAmountType: '',
      purchaseAmountType: '',
      purchaseWithLabour: true,
      ounceConversion: 31.1034768,
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

  it('blank batch-2 settings preserve current persisted outcomes under the restricted role', async () => {
    const behavior = await withTenant(runtime, TENANT, (tx: any) =>
      resolveSettingsBehaviorTx(tx, { tenantId: TENANT, coCode: CO }),
    );
    const amount = { pcs: 2, grossWt: 12, netWt: 10, ghtWt: 1, fineWt: 9 };
    await persistOutcome('fine0', fineStockValue(10, 8, behavior.fineStockType, 90, 85));
    await persistOutcome('sale0', saleAmountBase(amount, behavior.saleAmountType));
    await persistOutcome('purc0', purchaseAmountBase(amount, behavior.purchaseAmountType));
    await persistOutcome(
      'labr0',
      purchaseExpenseSplit(120, 15, 5, behavior.purchaseWithLabour).primary,
    );
    await persistOutcome('ounce0', ounceRatePerGram(3000, 4, behavior.ounceConversion));
    await persistOutcome('round0', behavior.allRoundingRemoved);
  });

  it('each configured batch-2 setting changes a restricted-role persisted outcome', async () => {
    const amount = { pcs: 2, grossWt: 12, netWt: 10, ghtWt: 1, fineWt: 9 };
    const behavior = () =>
      withTenant(runtime, TENANT, (tx: any) =>
        resolveSettingsBehaviorTx(tx, { tenantId: TENANT, coCode: CO }),
      );

    await set({ fineStockType: 'A' });
    await persistOutcome('fineA', fineStockValue(10, 8, (await behavior()).fineStockType, 90, 85));
    await set({ fineStockType: 'G' });
    await persistOutcome('fineG', fineStockValue(10, 8, (await behavior()).fineStockType, 90, 85));

    await set({ saleAmountType: 'N' });
    await persistOutcome('saleN', saleAmountBase(amount, (await behavior()).saleAmountType));
    await set({ saleAmountType: 'G' });
    await persistOutcome('saleG', saleAmountBase(amount, (await behavior()).saleAmountType));

    await set({ purchaseAmountType: 'F' });
    await persistOutcome(
      'purcF',
      purchaseAmountBase(amount, (await behavior()).purchaseAmountType),
    );
    await set({ purchaseAmountType: 'G' });
    await persistOutcome(
      'purcG',
      purchaseAmountBase(amount, (await behavior()).purchaseAmountType),
    );

    await set({ purchaseWithLabour: 'Y' });
    await persistOutcome(
      'labrY',
      purchaseExpenseSplit(120, 15, 5, (await behavior()).purchaseWithLabour).primary,
    );
    await set({ purchaseWithLabour: 'N' });
    await persistOutcome(
      'labrN',
      purchaseExpenseSplit(120, 15, 5, (await behavior()).purchaseWithLabour).primary,
    );

    await set({ ounceConversion: '30' });
    await persistOutcome('ounce30', ounceRatePerGram(3000, 4, (await behavior()).ounceConversion));
    await set({ ounceConversion: '40' });
    await persistOutcome('ounce40', ounceRatePerGram(3000, 4, (await behavior()).ounceConversion));

    await owner.$executeRawUnsafe(
      `UPDATE "CO_SET" SET "TAX_ROF"='0' WHERE tenant_id=$1 AND "CO_CODE"=$2`,
      TENANT,
      CO,
    );
    await set({ allRoundingRemoved: 'N' });
    const normalPolicy = await withTenant(runtime, TENANT, (tx: any) =>
      resolveRoundingPolicyTx(tx, { tenantId: TENANT, coCode: CO, lcCode: LC }),
    );
    await persistOutcome('roundN', normalPolicy.roundTaxAmount(12.5));
    await set({ allRoundingRemoved: 'Y' });
    const forcedPolicy = await withTenant(runtime, TENANT, (tx: any) =>
      resolveRoundingPolicyTx(tx, { tenantId: TENANT, coCode: CO, lcCode: LC }),
    );
    await persistOutcome('roundY', forcedPolicy.roundTaxAmount(12.5));

    const stored = (await owner.$queryRawUnsafe(
      `SELECT "BOOK_NAME" FROM "TEMP_BOOK_DATA"
       WHERE tenant_id=$1 AND "CO_BOOK"='S2'`,
      TENANT,
    )) as Array<{ BOOK_NAME: string }>;
    expect(stored.map((row) => row.BOOK_NAME)).toEqual(
      expect.arrayContaining([
        'fineA:9',
        'fineG:8.5',
        'saleN:11',
        'saleG:13',
        'purcF:9',
        'purcG:12',
        'labrY:120',
        'labrN:100',
        'ounce30:400',
        'ounce40:300',
        'roundN:12',
        'roundY:12.5',
      ]),
    );
  });

  it('all batch-3 configured flips change a restricted-role persisted outcome and blank preserves defaults', async () => {
    const vectors: Array<[keyof SettingsBehavior, string, unknown]> = [
      ['accountCodeLength', '5', 5],
      ['vbImport', 'Y', true],
      ['tagReport', 'Y', true],
      ['labourRateGeneration', 'Y', true],
      ['openingDhrn', 'Y', true],
      ['weightPort', 'COM3', 'COM3'],
      ['ledgerSummary', 'Y', true],
      ['smsGateway', '022', '022'],
      ['openingLoan', 'Y', true],
      ['stockReportGrossWeight', 'G', true],
      ['touchAutoSave', 'Y', true],
      ['dhrnDefaultRate', '3', 3],
      ['exportDatabaseTarget', 'B', 'B'],
      ['companyStockMerge', 'Y', true],
      ['cardCommissionAdjustment', 'Y', true],
      ['cashPurchaseAccount', 'Y', true],
      ['stockWeightSource', 'NEW', 'NEW'],
      ['dhrnWhatsapp', 'Y', true],
      ['schemeWhatsapp', 'Y', true],
      ['fxRate', '90.5', 90.5],
      ['fxCode', 'USD', 'USD'],
      ['adminSms', 'Y', true],
      ['customerSms', 'Y', true],
    ];
    const blankBehavior = await withTenant(runtime, TENANT, (tx: any) =>
      resolveSettingsBehaviorTx(tx, { tenantId: TENANT, coCode: CO }),
    );
    for (const [field, configured, expected] of vectors) {
      const before = blankBehavior[field];
      expect(before).not.toBe(expected);
      await set({ [field]: configured });
      const behavior = await withTenant(runtime, TENANT, (tx: any) =>
        resolveSettingsBehaviorTx(tx, { tenantId: TENANT, coCode: CO }),
      );
      expect(behavior[field]).toBe(expected);
      await persistOutcome(
        `b3${vectors.indexOf(vectors.find((v) => v[0] === field)!)}`,
        behavior[field] as number | boolean,
      );
      await set({ [field]: null });
    }
  });

  it('CASH_LIMIT flip changes whether a receipt persists', async () => {
    await set({ cashLimit: '100' });
    await expect(receipt(150)).rejects.toThrow('You Can Not Receive More Then Cash Limit');
    await set({ cashLimit: '200' });
    await expect(receipt(150)).resolves.toMatchObject({ vchNo: 1 });
    const rows = (await owner.$queryRawUnsafe(
      `SELECT count(*)::int n FROM "CASH_DATA" WHERE tenant_id=$1`,
      TENANT,
    )) as Array<{ n: number }>;
    expect(rows[0]!.n).toBe(1);
  });

  it('PAN_CARD_VAL flip changes the persisted threshold-probe outcome', async () => {
    const probe = () =>
      withTenant(runtime, TENANT, async (tx: any) => {
        const behavior = await resolveSettingsBehaviorTx(tx, { tenantId: TENANT, coCode: CO });
        const decision = tenderThresholdDecision({
          cashAmount: 0,
          priorCash: 0,
          billValue: 150,
          cashLimit: behavior.cashLimit,
          panCardVal: behavior.panCardVal,
        });

        if (decision.panRequired) throw new Error('PAN required');
        await tx.$executeRawUnsafe(
          `INSERT INTO "TEMP_BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","VCH_NO","BOOK_NAME")
           VALUES ($1,$2,$3,'PAN','00001','PAN threshold probe')`,
          TENANT,
          CO,
          LC,
        );
      });
    await set({ panCardVal: '100' });
    await expect(probe()).rejects.toThrow('PAN required');
    await set({ panCardVal: '200' });
    await expect(probe()).resolves.toBeUndefined();
    const rows = (await owner.$queryRawUnsafe(
      `SELECT count(*)::int n FROM "TEMP_BOOK_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='PAN'`,
      TENANT,
    )) as Array<{ n: number }>;
    expect(rows[0]!.n).toBe(1);
  });

  it('LAST_DAY_LOCK applies the desktop previous-day lock when the company is opened', async () => {
    // MS_OPNCOMP.cs:1503-1507 / UT_SETTING_MAIN.cs:9159-9165 write LOCK_DATE = system date - 1 on
    // company open; the ordinary persisted-lock gate then blocks that date.
    const dates = (await owner.$queryRawUnsafe(
      `SELECT (current_date-1)::text yesterday, current_date::text today`,
    )) as Array<{ yesterday: string; today: string }>;
    const yesterday = dates[0]!.yesterday;

    await set({ lastDayLock: 'N' });
    await owner.$executeRawUnsafe(
      `UPDATE "CO_SET" SET "LOCK_DATE"=NULL WHERE tenant_id=$1 AND "CO_CODE"=$2`,
      TENANT,
      CO,
    );
    expect(await applyLastDayLock(runtime, TENANT, CO)).toMatchObject({ applied: false });
    await expect(receipt(10, yesterday)).resolves.toMatchObject({ vchNo: 1 });

    await set({ lastDayLock: 'Y' });
    expect(await applyLastDayLock(runtime, TENANT, CO)).toMatchObject({
      applied: true,
      lockDate: yesterday,
    });
    const persisted = (await owner.$queryRawUnsafe(
      `SELECT "LOCK_DATE"::text d FROM "CO_SET" WHERE tenant_id=$1 AND "CO_CODE"=$2`,
      TENANT,
      CO,
    )) as Array<{ d: string }>;
    expect(persisted[0]!.d).toBe(yesterday);
    await expect(receipt(10, yesterday)).rejects.toBeInstanceOf(PeriodLockValidationError);
    // Re-opening the company is idempotent and never moves the lock backwards.
    expect(await applyLastDayLock(runtime, TENANT, CO)).toMatchObject({ applied: false });
  });

  it('INT_YEAR_DAYS flip changes persisted dhiran interest', async () => {
    await set({ intYearDays: '360', dhrnCompound: 'N' });
    const d360 = await persistedInterest({ from: '2026-01-01', to: '2026-02-01', months: 1 });
    await set({ intYearDays: '365' });
    const d365 = await persistedInterest({ from: '2026-01-01', to: '2026-02-01', months: 1 });
    expect([d360, d365]).toEqual([100, 99]);
  });

  it('INT_DAY flip changes persisted inclusive day-count interest', async () => {
    await set({ dhrnIntType: 'D', intDay: '1', dhrnCompound: 'N' });
    const exclusive = await persistedInterest({ from: '2026-01-01', to: '2026-01-31', months: 1 });
    await set({ intDay: '2' });
    const inclusive = await persistedInterest({ from: '2026-01-01', to: '2026-01-31', months: 1 });
    expect([exclusive, inclusive]).toEqual([100, 103]);
  });

  it('selects the interest type from the book: DHRN_INT_TYPE governs the pledge book', async () => {
    // TR_DHRN_REC.cs:5643 / TR_DHRN_INTREC.cs:4274,4280 - a non-LOAN book reads DHRN_INT_TYPE, so
    // flipping LOAN_INT_TYPE alone must not change a DHRN ISSUE voucher.
    await set({ dhrnIntType: 'M', loanIntType: 'M', dhrnCompound: 'N' });
    const monthly = await persistedInterest({ from: '2026-01-01', to: '2026-02-15', months: 2 });
    await set({ loanIntType: 'D' });
    const loanFlipped = await persistedInterest({
      from: '2026-01-01',
      to: '2026-02-15',
      months: 2,
    });
    expect(loanFlipped).toBe(monthly);
    await set({ dhrnIntType: 'D' });
    const dhrnFlipped = await persistedInterest({
      from: '2026-01-01',
      to: '2026-02-15',
      months: 2,
    });
    expect([monthly, dhrnFlipped]).toEqual([200, 150]);
  });

  it('DHIRN_COMPOUND flip changes persisted multi-year interest', async () => {
    await set({ dhrnIntType: 'M', dhrnCompound: 'N' });
    const simple = await persistedInterest({ from: '2026-01-01', to: '2027-12-31', months: 24 });
    await set({ dhrnCompound: 'Y' });
    const compound = await persistedInterest({ from: '2026-01-01', to: '2027-12-31', months: 24 });
    expect([simple, compound]).toEqual([2400, 2544]);
  });

  it('reads the metal rate basis from CO_SET.RATE_PAR', async () => {
    // MsRatePar drives the settlement engine's factor (10 for per-10-gram, 1000 for per-kg), so it must
    // come from the database and never from a request body.
    const read = () =>
      withTenant(runtime, TENANT, (tx: any) =>
        resolveSettingsBehaviorTx(tx, { tenantId: TENANT, coCode: CO }),
      );
    // CO_SET.RATE_PAR is varchar(1): the schema itself enforces the desktop's first-character rule
    // (`Strings.Mid(cboRateType.Text, 1, 1)`, UT_SETTING.cs:4914), so only a single code can be stored.
    await set({ rateBasis: 'T' });
    expect((await read()).rateBasis).toBe('T');
    await set({ rateBasis: 'K' });
    expect((await read()).rateBasis).toBe('K');
    await set({ rateBasis: 'G' });
    expect((await read()).rateBasis).toBe('G');
    // An unrecognised code falls back to per-gram rather than throwing.
    await set({ rateBasis: 'Z' });
    expect((await read()).rateBasis).toBe('G');
    await set({ rateBasis: null });
    expect((await read()).rateBasis).toBe('G');
  });
});
