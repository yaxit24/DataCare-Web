import { PrismaClient } from '@datacare/db';
import { afterAll, beforeAll, beforeEach, describe, expect, it } from 'vitest';
import {
  createSaleReturn,
  editSaleReturn,
  getSaleReturn,
  saleForReturn,
} from '../src/modules/sales/salesReturn.js';
import type { VoucherScope } from '../src/modules/vouchers/numbering.js';

/**
 * WP-27 (N242, G254): the Sales Return residuals, at the writer, on the isolated database.
 * Case ids and the arithmetic are in orchestration/work/WP-27/cases.md; the desktop is TR_SALE_RTN.cs.
 *
 * Line R: net 10, gross 10.25, touch 91.6, rate 6,123.45, making 237.5 per gram, SL_AMT_TYPE N:
 *   metal round(61,234.50) = 61,234 (:4955), making round(2,375) = 2,375 (:4985), net 63,609,
 *   tax round(63,609 x 3% = 1,908.27, 2) = 1,908.27 (:16402), total round(65,517.27, 0) = 65,517 (:16405).
 * Line R' = R with net 9: metal round(55,111.05) = 55,111, making round(2,137.5) = 2,138 (half to even),
 *   net 57,249, tax 1,717.47, total round(58,966.47) = 58,966.
 */
const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const databaseDescribe = RUN ? describe : describe.skip;
const TENANT = 'wp27-srt-residuals';
const CO = '01';
const LC = '01';
const YEAR = '2024-2025';
const DAY = '2024-04-10';

const scope = (coBook: string): VoucherScope => ({
  tenantId: TENANT,
  coCode: CO,
  lcCode: LC,
  coYear: YEAR,
  coBook,
});
const input = (overrides: Record<string, unknown> = {}) => ({
  scope: scope('SRT'),
  mainUser: 'return-owner',
  acCode: 'CUST',
  acName: 'Residual Customer',
  vchDate: DAY,
  taxRatePct: 3,
  interState: false,
  ...overrides,
});
const LINE_R = {
  itCode: 'LOOSE',
  pcs: 1,
  grossWt: 10.25,
  netWt: 10,
  touch: 91.6,
  rate: 6123.45,
  labourType: 'per_gram' as const,
  labourRate: 237.5,
};
const LINE_R9 = { ...LINE_R, netWt: 9 };
const TAGGED = {
  itCode: 'GOLD',
  tagNo: 'TAGRT',
  pcs: 1,
  grossWt: 3,
  netWt: 3,
  touch: 100,
  rate: 100,
};
const LOOSE = { itCode: 'LOOSE', pcs: 1, grossWt: 1, netWt: 1, touch: 90, rate: 100 };
const WRITE_TABLES = [
  'SL_DATA',
  'SL_DETL_RTN',
  'MAIN_STOCK',
  'AC_DATA',
  'TAX_DATA',
  'ROJ_MEL_DATA',
  'BILL_OS_DATA',
  'DM_DATA',
  'REMARK_DATA',
];

databaseDescribe('WP-27 Sales Return residuals (writer)', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;
  const sql = (q: string, ...p: unknown[]) => owner.$executeRawUnsafe(q, ...p);
  const rows = <T = Record<string, unknown>>(q: string, ...p: unknown[]) =>
    owner.$queryRawUnsafe(q, ...p) as Promise<T[]>;

  const cleanup = async (): Promise<void> => {
    for (const table of [
      'USER_DATA',
      'DELETE_DATA',
      ...WRITE_TABLES,
      'SL_DETL',
      'BAR_DETL',
      'TEMP_BOOK_DATA',
      'BOOK_DETL',
      'BOOK_DATA',
      'ITEM_MAST',
      'GROUP_MAST',
      'TAX_MAST',
      'AC_MAST',
      'YEAR_MAST',
      'CO_MAST',
      'CO_SET_NEW',
      'CO_SET',
    ])
      await sql(`DELETE FROM "${table}" WHERE tenant_id=$1`, TENANT);
  };

  const seed = async (): Promise<void> => {
    await sql(
      `INSERT INTO "YEAR_MAST"(tenant_id,"CO_CODE","CO_YEAR","OP_DATE","CL_DATE") VALUES($1,$2,$3,'2024-04-01','2025-03-31')`,
      TENANT,
      CO,
      YEAR,
    );
    await sql(
      `INSERT INTO "CO_MAST"(tenant_id,"CO_CODE","CO_NAME","LC_CODE","CO_TYPE") VALUES($1,$2,'Residuals','01','A')`,
      TENANT,
      CO,
    );
    await sql(
      `INSERT INTO "CO_SET"(tenant_id,"CO_CODE","LOCK_DATE","SL_AMT_TYPE","TAX_ROF") VALUES ($1,$2,NULL,'N','2')`,
      TENANT,
      CO,
    );
    await sql(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GST_TYPE")
       VALUES ($1,$2,$3,'CUST','Residual Customer','L')`,
      TENANT,
      CO,
      LC,
    );
    await sql(
      `INSERT INTO "TAX_MAST"(tenant_id,"CO_CODE","TAX_CODE","SR_NO","TAX_GROUP","TAX_NAME","TAX_PRC","TAX_AC")
       VALUES ($1,$2,'10',0,'GST','GST 3%',3,'GSTLED')`,
      TENANT,
      CO,
    );
    await sql(
      `INSERT INTO "GROUP_MAST"(tenant_id,"CO_CODE","GR_CODE","GR_NAME","SALE_AC") VALUES ($1,$2,'G01','Gold','SALEAC')`,
      TENANT,
      CO,
    );
    await sql(
      `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE","GR_CODE")
       VALUES ($1,$2,'GOLD','Gold','G','G01'),($1,$2,'LOOSE','Loose Gold','G','G01')`,
      TENANT,
      CO,
    );
    await sql(
      `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME","MAIN_BOOK","BOOK_INOUT","CUR_USE","BOOK_TBL_NAME")
       VALUES ($1,$2,$3,'SAL','Sales','SALE','SALES','O','Y','SL_DATA'),
              ($1,$2,$3,'SRT','Sales Return','SRTN','SALES RETURNE','I','Y','SL_DATA')`,
      TENANT,
      CO,
      LC,
    );
    await sql(
      `INSERT INTO "BOOK_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","SR_NO","AC_CODE","MAIN_BOOK","BOOK_INOUT")
       VALUES ($1,$2,$3,'SRT',1,'CTRL','SALES RETURNE','I'),
              ($1,$2,$3,'SRT',2,'CASH','SALES RETURNE','I'),
              ($1,$2,$3,'SRT',3,'ROUND','SALES RETURNE','I')`,
      TENANT,
      CO,
      LC,
    );
    await sql(
      `INSERT INTO "TEMP_BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","VCH_NO","BOOK_NAME") VALUES ($1,$2,$3,'SRT','00040','seed')`,
      TENANT,
      CO,
      LC,
    );
    // Sale SAL/00001: a tagged line TAGRT (sold out of stock) and a loose 'N' line. Voucher 00007 makes the next
    // return 00008.
    await sql(
      `INSERT INTO "SL_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DATE","VCH_TIME","AC_CODE","AC_NAME","TAX_PRC")
       VALUES ($1,$2,$3,$4,'SAL','00001',$5::date,$5::timestamp,'CUST','Residual Customer',3),
              ($1,$2,$3,$4,'SRT','00007',$5::date,$5::timestamp,'CUST','Residual Customer',3)`,
      TENANT,
      CO,
      LC,
      YEAR,
      DAY,
    );
    await sql(
      `INSERT INTO "SL_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","VCH_DATE",
         "AC_CODE","IT_CODE","TAG_NO","VCH_SRNO","ITM_PCS","ITM_GWT","ITM_NWT","ITM_TOUCH","ITM_RATE","NET_AMT")
       VALUES ($1,$2,$3,$4,'SAL','00001',1,$5::date,'CUST','GOLD','TAGRT',1,1,3,3,100,100,300),
              ($1,$2,$3,$4,'SAL','00001',2,$5::date,'CUST','LOOSE','N',0,1,1,1,90,100,90)`,
      TENANT,
      CO,
      LC,
      YEAR,
      DAY,
    );
    await sql(
      `INSERT INTO "BAR_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","VCH_DATE",
         "IT_CODE","TAG_NO","VCH_SRNO","ITM_PCS","ITM_GWT","ITM_NWT","ITM_FINE","EMP_ISU")
       VALUES ($1,$2,$3,$4,'TOP','00001',1,$5::date,'GOLD','TAGRT',1,1,3,3,3,'N')`,
      TENANT,
      CO,
      LC,
      YEAR,
      DAY,
    );
    await sql(
      `INSERT INTO "MAIN_STOCK"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","VCH_DATE",
         "IT_CODE","TAG_NO","VCH_SRNO","ITM_SIGN","ITM_PCS","ITM_GWT","ITM_NWT")
       VALUES ($1,$2,$3,$4,'TOP','00001',1,$5::date,'GOLD','TAGRT',1,'+',1,3,3),
              ($1,$2,$3,$4,'SAL','00001',1,$5::date,'GOLD','TAGRT',1,'-',1,3,3)`,
      TENANT,
      CO,
      LC,
      YEAR,
      DAY,
    );
  };

  /** Every row of the voucher's write set and its hidden-book row, without the database row id. */
  const writeSet = async (voucherNo: string): Promise<Record<string, unknown[]>> => {
    const state: Record<string, unknown[]> = {};
    for (const table of WRITE_TABLES)
      state[table] = await rows(
        `SELECT to_jsonb(t) - 'row_id' AS r FROM "${table}" t
          WHERE tenant_id=$1 AND "CO_BOOK"='SRT' AND "VCH_NO"=$2 ORDER BY (to_jsonb(t) - 'row_id')::text`,
        TENANT,
        voucherNo,
      );
    state.TEMP_BOOK_DATA = await rows(
      `SELECT to_jsonb(t) - 'row_id' AS r FROM "TEMP_BOOK_DATA" t
        WHERE tenant_id=$1 AND "CO_BOOK"='SRT' ORDER BY (to_jsonb(t) - 'row_id')::text`,
      TENANT,
    );
    return state;
  };
  const returnCount = async (): Promise<number> =>
    Number(
      (
        await rows<{ n: number }>(
          `SELECT count(*)::int n FROM "SL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='SRT'`,
          TENANT,
        )
      )[0]?.n ?? 0,
    );
  /** A refusal writes nothing: no new return, and the next good save still takes 00008. */
  const expectRefusedWithoutWrite = async (
    attempt: () => Promise<unknown>,
    message: string | RegExp,
  ): Promise<void> => {
    const before = await returnCount();
    await expect(attempt()).rejects.toThrow(message);
    expect(await returnCount()).toBe(before);
  };

  beforeAll(async () => {
    const ownerUrl = process.env.MIGRATE_DATABASE_URL;
    const runtimeUrl = process.env.DATABASE_URL;
    if (!ownerUrl || !runtimeUrl)
      throw new Error('RUN_DB_INTEGRITY_TESTS requires MIGRATE_DATABASE_URL and DATABASE_URL');
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

  it('sales-return.refusal.zero-value: a 0 total is refused with the desktop text and writes nothing', async () => {
    await expectRefusedWithoutWrite(
      () =>
        createSaleReturn(runtime, input(), [
          { itCode: 'LOOSE', pcs: 1, grossWt: 0, netWt: 0, touch: 0, rate: 0 },
        ]),
      'Please Insert Item Value and try',
    );
    const saved = await createSaleReturn(runtime, input(), [LINE_R]);
    expect(saved.vchNo).toBe(8);
  });

  it('sales-return.refusal.no-lines: an empty grid totals 0 and gets the same text', async () => {
    await expectRefusedWithoutWrite(
      () => createSaleReturn(runtime, input(), []),
      'Please Insert Item Value and try',
    );
  });

  it('sales-return.children.duplicate-tag: one tag twice is refused with "Duplicate Tag No"', async () => {
    await expectRefusedWithoutWrite(
      () => createSaleReturn(runtime, input({ origBook: 'SAL', origVchNo: 1 }), [TAGGED, TAGGED]),
      /^Duplicate Tag No$/,
    );
  });

  it('sales-return.import.first-import-allowed / refused-after-return / remaining-excludes-returned', async () => {
    const first = await saleForReturn(runtime, {
      scope: scope('SAL'),
      origVchNo: 1,
      origBook: 'SAL',
    });
    expect(first.acCode).toBe('CUST');
    expect(first.lines.map((l: any) => String(l.TAG_NO).trim())).toEqual(['TAGRT', 'N']);

    const returned = await createSaleReturn(runtime, input({ origBook: 'SAL', origVchNo: 1 }), [
      TAGGED,
    ]);
    expect(returned.vchNo).toBe(8);

    await expect(
      saleForReturn(runtime, { scope: scope('SAL'), origVchNo: 1, origBook: 'SAL' }),
    ).rejects.toThrow(
      'This Sales Bill Is All ready Import...In...00008 You Cant Re Ipmport...Please Select Single Item In Receive Item...',
    );

    const remaining = await saleForReturn(runtime, {
      scope: scope('SAL'),
      origVchNo: 1,
      origBook: 'SAL',
      remaining: true,
    });
    expect(remaining.lines.map((l: any) => String(l.TAG_NO).trim())).toEqual(['N']);

    // TR_SALE_RTN.cs:3882 excludes by TAG_NO, and the loose marker is the shared value 'N' (decision D7).
    await createSaleReturn(runtime, input({ origBook: 'SAL', origVchNo: 1 }), [LOOSE]);
    const none = await saleForReturn(runtime, {
      scope: scope('SAL'),
      origVchNo: 1,
      origBook: 'SAL',
      remaining: true,
    });
    expect(none.lines).toEqual([]);
  });

  it('sales-return.refusal.employee-mandatory and field.employee-route', async () => {
    await sql(`UPDATE "CO_SET" SET "EMP_CODE_MANDATORY"='Y' WHERE tenant_id=$1`, TENANT);
    await expectRefusedWithoutWrite(
      () => createSaleReturn(runtime, input(), [LINE_R]),
      'Please Select Employee Code and Try......',
    );
    const saved = await createSaleReturn(runtime, input({ empCode: 'E7' }), [LINE_R]);
    const [h] = await rows<{ emp: string }>(
      `SELECT "EMP_CODE" emp FROM "SL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='SRT' AND "VCH_NO"=$2`,
      TENANT,
      String(saved.vchNo).padStart(5, '0'),
    );
    expect(h?.emp).toBe('E7');
  });

  it('sales-return.refusal.cheque-without-bank / card-without-bank and field.bank-account-route', async () => {
    await expectRefusedWithoutWrite(
      () => createSaleReturn(runtime, input({ chequeAmt: 1000 }), [LINE_R]),
      'Please Select Bank Account And Try Because Chq Rec Amt <> 0......',
    );
    await expectRefusedWithoutWrite(
      () => createSaleReturn(runtime, input({ cardAmt: 1000 }), [LINE_R]),
      'Please Select Card Bank Account And Try Because Card Amt <> 0......',
    );
    const saved = await createSaleReturn(runtime, input({ chequeAmt: 1000, bankAc: 'BANK1' }), [
      LINE_R,
    ]);
    const [h] = await rows<{ chq: number; bank: string }>(
      `SELECT "CHQ_AMT"::float chq,"BANK_AC" bank FROM "SL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='SRT' AND "VCH_NO"=$2`,
      TENANT,
      String(saved.vchNo).padStart(5, '0'),
    );
    expect(h).toEqual({ chq: 1000, bank: 'BANK1' });
  });

  it('sales-return.refusal.company-type-b: a new voucher is refused, an edit is not', async () => {
    const existing = await createSaleReturn(runtime, input(), [LINE_R]);
    await sql(`UPDATE "CO_MAST" SET "CO_TYPE"='B' WHERE tenant_id=$1`, TENANT);
    await expectRefusedWithoutWrite(
      () => createSaleReturn(runtime, input(), [LINE_R]),
      'You Cant Save This Voucher Becouse This Company Type is B......',
    );
    await expect(
      editSaleReturn(runtime, input(), [LINE_R9], existing.vchNo),
    ).resolves.toMatchObject({ vchNo: existing.vchNo });
  });

  it('sales-return.refusal.date-outside-year', async () => {
    await expectRefusedWithoutWrite(
      () => createSaleReturn(runtime, input({ vchDate: '2025-04-02' }), [LINE_R]),
      'You Cant Save Entry Because Voucher Date Not In Current Year... Please Change Date...',
    );
  });

  it('sales-return.refusal.lock-date: on the lock date is refused with the desktop text', async () => {
    await sql(`UPDATE "CO_SET" SET "LOCK_DATE"=$2 WHERE tenant_id=$1`, TENANT, DAY);
    await expectRefusedWithoutWrite(
      () => createSaleReturn(runtime, input(), [LINE_R]),
      'You Cant Save and Delete This Voucher Becouse Lock Date is = 10/04/2024 ....',
    );
  });

  it('sales-return.accept.cash-refund-over-limit and accept.defaulter-party (decision D10)', async () => {
    await sql(`UPDATE "CO_SET" SET "CASH_LIMIT"=1000 WHERE tenant_id=$1`, TENANT);
    await sql(`UPDATE "AC_MAST" SET "DEFAULTER_AC"='Y' WHERE tenant_id=$1`, TENANT);
    await expect(
      createSaleReturn(runtime, input({ cashAmt: 65517 }), [LINE_R]),
    ).resolves.toMatchObject({ vchNo: 8 });
    await expect(createSaleReturn(runtime, input(), [LINE_R])).resolves.toMatchObject({
      vchNo: 9,
    });
  });

  it('sales-return.formula.edit-recomputes and edit.audit-user-data', async () => {
    const created = await createSaleReturn(runtime, input(), [LINE_R]);
    await editSaleReturn(runtime, input({ mainUser: 'editor' }), [LINE_R9], created.vchNo);
    const [line] = await rows<Record<string, number>>(
      `SELECT "ITM_NWT"::float nwt,"ITM_AMT"::float amt,"LBR_AMT"::float lbr,"NET_AMT"::float net
         FROM "SL_DETL_RTN" WHERE tenant_id=$1 AND "CO_BOOK"='SRT' AND "VCH_NO"='00008'`,
      TENANT,
    );
    expect(line).toEqual({ nwt: 9, amt: 55111, lbr: 2138, net: 57249 });
    const [head] = await rows<Record<string, unknown>>(
      `SELECT "TAX_AMT"::float tax,"TOT_AMT"::float tot,"MAIN_USER" usr
         FROM "SL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='SRT' AND "VCH_NO"='00008'`,
      TENANT,
    );
    expect(head).toEqual({ tax: 1717.47, tot: 58966, usr: 'return-owner' });

    const audit = await rows<Record<string, string>>(
      `SELECT "COL_TYPE" col,"OLD_VAL" old,"NEW_VAL" new,"USER_NAME" usr,"NEW_USER" editor,"ENTRY_CHECK" chk
         FROM "USER_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='SRT' AND "VCH_NO"='00008' ORDER BY "COL_TYPE"`,
      TENANT,
    );
    const byColumn = Object.fromEntries(audit.map((r) => [r.col, r]));
    expect(byColumn.NET_AMT).toMatchObject({ old: '63609', new: '57249' });
    expect(byColumn.TAX_AMT).toMatchObject({ old: '1908.27', new: '1717.47' });
    expect(byColumn.TOT_AMT).toMatchObject({ old: '65517', new: '58966' });
    for (const row of audit)
      expect(row).toMatchObject({ usr: 'return-owner', editor: 'editor', chk: 'N' });
    for (const unchanged of ['AC_CODE', 'VCH_DATE', 'MAIN_USER', 'HD_VCH_NO'])
      expect(byColumn[unchanged]).toBeUndefined();
  });

  it('sales-return.reopen.lossless-no-op at the writer: reopen + save unchanged rewrites identical rows', async () => {
    const created = await createSaleReturn(
      runtime,
      input({ origBook: 'SAL', origVchNo: 1, empCode: 'E7', chequeAmt: 1000, bankAc: 'BANK1' }),
      [
        { ...TAGGED, labourType: 'per_gram', labourRate: 12.5 },
        { ...LOOSE, labourType: 'fixed', labourFixed: 25 },
      ],
    );
    const voucherNo = String(created.vchNo).padStart(5, '0');
    const before = await writeSet(voucherNo);
    const saved: any = await getSaleReturn(runtime, scope('SRT'), voucherNo);
    await editSaleReturn(
      runtime,
      { ...input(), ...saved, scope: scope('SRT'), mainUser: 'editor' },
      saved.lines,
      voucherNo,
      saved.version,
    );
    expect(await writeSet(voucherNo)).toEqual(before);
    expect(await rows(`SELECT 1 FROM "USER_DATA" WHERE tenant_id=$1`, TENANT)).toHaveLength(0);
  });

  it('sales-return.rollback.refused-edit-keeps-voucher', async () => {
    const created = await createSaleReturn(runtime, input(), [LINE_R]);
    const voucherNo = String(created.vchNo).padStart(5, '0');
    const before = await writeSet(voucherNo);
    await expect(
      editSaleReturn(
        runtime,
        input(),
        [{ itCode: 'LOOSE', pcs: 1, grossWt: 0, netWt: 0, touch: 0, rate: 0 }],
        voucherNo,
      ),
    ).rejects.toThrow('Please Insert Item Value and try');
    expect(await writeSet(voucherNo)).toEqual(before);
  });
});
