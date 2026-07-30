import { PrismaClient } from '@prisma/client';
import { afterAll, beforeAll, beforeEach, describe, expect, it } from 'vitest';
import { createSale } from '../src/modules/sales/sales.js';
import { DESKTOP_MESSAGES } from '../src/modules/shared/desktopMessages.js';
import type { VoucherScope } from '../src/modules/vouchers/numbering.js';

/**
 * Phase E — desktop validation wording. Operators recognise the desktop's exact text (typos and all),
 * so a guard that blocks the right condition with different words is not parity. These assert the
 * verbatim strings from TR_SALE.cs together with the desktop's own condition.
 */
const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const databaseDescribe = RUN ? describe : describe.skip;

const TENANT = 'desktop-messages-db';
const CO = '01';
const LC = '01';
const YEAR = '2024-2025';
const BOOK = 'SAL';
const DAY = '2024-04-10';

const scope: VoucherScope = {
  tenantId: TENANT,
  coCode: CO,
  lcCode: LC,
  coYear: YEAR,
  coBook: BOOK,
};

const line = {
  itCode: 'GOLD',
  pcs: 1,
  grossWt: 10,
  netWt: 10,
  touch: 100,
  rate: 100,
  metal: 'G' as const,
};

databaseDescribe('desktop validation wording', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;

  const cleanup = async (): Promise<void> => {
    for (const table of [
      'SL_DETL',
      'SL_DATA',
      'BILL_OS_DATA',
      'TAX_DATA',
      'MAIN_STOCK',
      'AC_DATA',
      'TEMP_BOOK_DATA',
      'SRNO_MAST',
      'BOOK_DETL',
      'BOOK_DATA',
      'ITEM_MAST',
      'GROUP_MAST',
      'TAX_MAST',
      'AC_MAST',
      'CO_SET',
    ]) {
      await owner.$executeRawUnsafe(`DELETE FROM "${table}" WHERE tenant_id=$1`, TENANT);
    }
  };

  const seed = async (defaulter: 'Y' | 'N'): Promise<void> => {
    await owner.$executeRawUnsafe(
      `INSERT INTO "CO_SET"(tenant_id,"CO_CODE","LOCK_DATE") VALUES ($1,$2,NULL)`,
      TENANT,
      CO,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GST_TYPE","DEFAULTER_AC")
       VALUES ($1,$2,$3,'CUST','Counter Customer','L',$4)`,
      TENANT,
      CO,
      LC,
      defaulter,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "BOOK_DATA"(
         tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME","MAIN_BOOK",
         "BOOK_INOUT","CUR_USE","BOOK_TBL_NAME")
       VALUES ($1,$2,$3,'SAL','Configured Sales Book','CSB','SALES','O','Y','SL_DATA')`,
      TENANT,
      CO,
      LC,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "TAX_MAST"(tenant_id,"CO_CODE","TAX_CODE","SR_NO","TAX_GROUP","TAX_NAME","TAX_PRC","TAX_AC")
       VALUES ($1,$2,'10',1,'GST','GST 3%',3,'GSTLED')`,
      TENANT,
      CO,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "GROUP_MAST"(tenant_id,"CO_CODE","GR_CODE","GR_NAME","SALE_AC")
       VALUES ($1,$2,'G01','Gold','SALEAC')`,
      TENANT,
      CO,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE","GR_CODE")
       VALUES ($1,$2,'GOLD','Gold Ornament','G','G01')`,
      TENANT,
      CO,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "BOOK_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","SR_NO","AC_CODE","MAIN_BOOK","BOOK_INOUT")
       VALUES ($1,$2,$3,'SAL',1,'CTRL','SALES','O'),
              ($1,$2,$3,'SAL',2,'CASH','SALES','O'),
              ($1,$2,$3,'SAL',3,'ROUND','SALES','O')`,
      TENANT,
      CO,
      LC,
    );
  };

  beforeAll(async () => {
    const ownerUrl = process.env.MIGRATE_DATABASE_URL;
    const runtimeUrl = process.env.DATABASE_URL;
    if (!ownerUrl || !runtimeUrl) throw new Error('MIGRATE_DATABASE_URL and DATABASE_URL required');
    owner = new PrismaClient({ datasources: { db: { url: ownerUrl } } });
    runtime = new PrismaClient({ datasources: { db: { url: runtimeUrl } } });
  });

  afterAll(async () => {
    await cleanup();
    await owner.$disconnect();
    await runtime.$disconnect();
  });

  beforeEach(cleanup);

  it('blocks a cheque amount with no bank account, in desktop wording', async () => {
    await seed('N');
    await expect(
      createSale(
        runtime,
        {
          scope,
          acCode: 'CUST',
          vchDate: DAY,
          taxRatePct: 3,
          interState: false,
          chequeAmt: 500,
        } as never,
        [line],
      ),
    ).rejects.toThrow('Please Select Bank Account And Try Because Chq Rec Amt <> 0......');
  }, 30_000);

  it('blocks a card amount with no card bank account, in desktop wording', async () => {
    await seed('N');
    await expect(
      createSale(
        runtime,
        {
          scope,
          acCode: 'CUST',
          vchDate: DAY,
          taxRatePct: 3,
          interState: false,
          cardAmt: 500,
        } as never,
        [line],
      ),
    ).rejects.toThrow('Please Select Card Bank Account And Try Because Card Amt <> 0......');
  }, 30_000);

  it('allows a cheque amount once the bank account is supplied', async () => {
    await seed('N');
    const created = await createSale(
      runtime,
      {
        scope,
        acCode: 'CUST',
        vchDate: DAY,
        taxRatePct: 3,
        interState: false,
        chequeAmt: 100,
        bankAc: 'BANK',
      } as never,
      [line],
    );
    expect(created.vchNo).toBeGreaterThan(0);
  }, 30_000);

  it('blocks credit to a party flagged in the defaulter list, in desktop wording', async () => {
    await seed('Y');
    // No tender supplied ⇒ the whole bill is outstanding ⇒ the desktop guard fires.
    await expect(
      createSale(
        runtime,
        {
          scope,
          acCode: 'CUST',
          vchDate: DAY,
          taxRatePct: 3,
          interState: false,
        } as never,
        [line],
      ),
    ).rejects.toThrow(
      'You Cant Save Entry Because This Party Is in Defaulter List...Please Change It First In AcMast...',
    );
  }, 30_000);

  it('permits a flagged party when nothing is left outstanding', async () => {
    await seed('Y');
    const created = await createSale(
      runtime,
      {
        scope,
        acCode: 'CUST',
        vchDate: DAY,
        taxRatePct: 3,
        interState: false,
        // Settle the full bill in cash: the desktop only blocks when outstanding > 0.
        cashAmt: 1030,
      } as never,
      [line],
    );
    expect(created.vchNo).toBeGreaterThan(0);
  }, 30_000);

  it('rejects the same order line picked twice, in desktop wording', async () => {
    await seed('N');
    await expect(
      createSale(
        runtime,
        {
          scope,
          acCode: 'CUST',
          vchDate: DAY,
          taxRatePct: 3,
          interState: false,
          cashAmt: 2060,
        } as never,
        [
          { ...line, ordNo: 'ORD-1', ordDbcd: 'SOR', ordYrcd: YEAR, ordSrno: 1 },
          { ...line, ordNo: 'ORD-1', ordDbcd: 'SOR', ordYrcd: YEAR, ordSrno: 1 },
        ] as never,
      ),
    ).rejects.toThrow('Duplicate Order No');
  }, 30_000);

  it('allows two lines against different order serials', async () => {
    await seed('N');
    const created = await createSale(
      runtime,
      {
        scope,
        acCode: 'CUST',
        vchDate: DAY,
        taxRatePct: 3,
        interState: false,
        cashAmt: 2060,
      } as never,
      [
        { ...line, ordNo: 'ORD-1', ordDbcd: 'SOR', ordYrcd: YEAR, ordSrno: 1 },
        { ...line, ordNo: 'ORD-1', ordDbcd: 'SOR', ordYrcd: YEAR, ordSrno: 2 },
      ] as never,
    );
    expect(created.vchNo).toBeGreaterThan(0);
  }, 30_000);

  it('keeps the desktop strings verbatim, including their typos', () => {
    // Guarding against a well-meaning spelling "fix": operators match on this text.
    expect(DESKTOP_MESSAGES.OLD_GOLD_RATE_TYPE).toBe(
      'Please Slelect Rate type = N - Net Wise Or F - Fine Wise',
    );
    expect(DESKTOP_MESSAGES.DUPLICATE_TAG).toBe('Duplicate Tag No');
    expect(DESKTOP_MESSAGES.CHEQUE_WITHOUT_BANK.endsWith('<> 0......')).toBe(true);
  });
});
