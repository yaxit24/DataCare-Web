import { PrismaClient, withTenant } from '@datacare/db';
import { afterAll, beforeAll, beforeEach, describe, expect, it } from 'vitest';
import { createPurchase } from '../../src/modules/purchase/purchase.js';
import {
  accountCheck,
  ACCOUNT_REFRESH_VERIFIED,
} from '../../src/modules/utilities/accountRefresh.js';
import { applyRepair, previewRepair } from '../../src/modules/utilities/dataRepair.js';
import { assertIsolatedTestDatabase } from './isolatedDatabase.js';

/** Synthetic writer -> stored-row check. No acceptance/replay claim; Apply stays disabled throughout. */
export function purchaseRefreshSuite(tenant: string) {
  const run = process.env.RUN_DB_INTEGRITY_TESTS === '1';
  (run ? describe : describe.skip)(`Purchase account preview ${tenant}`, () => {
    const owner = new PrismaClient({
      datasources: { db: { url: process.env.MIGRATE_DATABASE_URL ?? '' } },
    });
    const runtime = new PrismaClient();
    const y = new Date().getMonth() >= 3 ? new Date().getFullYear() : new Date().getFullYear() - 1;
    const scope = { tenantId: tenant, coCode: '01', lcCode: '01', coYear: `${y}-${y + 1}` };
    const exec = (sql: string, ...args: unknown[]) =>
      withTenant(owner, tenant, (tx: any) => tx.$executeRawUnsafe(sql, tenant, ...args));
    const query = (sql: string, ...args: unknown[]): Promise<any[]> =>
      withTenant(owner, tenant, (tx: any) => tx.$queryRawUnsafe(sql, tenant, ...args));
    const wipe = async () => {
      const tables: any[] = await owner.$queryRawUnsafe(
        `SELECT table_name FROM information_schema.columns WHERE table_schema='public' AND column_name='tenant_id'`,
      );
      await withTenant(owner, tenant, async (tx: any) => {
        await tx.$executeRawUnsafe(`SET LOCAL "app.allow_repair_purge"='on'`);
        for (const { table_name } of tables)
          await tx.$executeRawUnsafe(`DELETE FROM "${table_name}" WHERE tenant_id=$1`, tenant);
      });
    };
    beforeAll(() => assertIsolatedTestDatabase());
    beforeEach(async () => {
      await wipe();
      await exec(`INSERT INTO "CO_SET"(tenant_id,"CO_CODE","PURC_WITH_LBR") VALUES ($1,'01','Y')`);
      await exec(
        `INSERT INTO "CO_SET_NEW"(tenant_id,"CO_CODE","PR_TDS_TAX","PURC_WITH_HMTAX","TOT_AMT_ROF") VALUES ($1,'01','N','Y',0)`,
      );
      await exec(
        `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GST_TYPE") VALUES ($1,'01','01','SUP','Synthetic Supplier','L')`,
      );
      await exec(
        `INSERT INTO "GROUP_MAST"(tenant_id,"CO_CODE","GR_CODE","PURC_AC") VALUES ($1,'01','G01','PURAC'),($1,'01','S01','SILAC')`,
      );
      await exec(
        `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE","GR_CODE") VALUES ($1,'01','G','Gold','G','G01'),($1,'01','S','Silver','S','S01')`,
      );
      for (const [code, main] of [
        ['PUR', 'PURCHASE'],
        ['TAG', 'TAG PURCHASE'],
        ['CPR', 'CON PUR'],
      ]) {
        await exec(
          `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME","MAIN_BOOK","BOOK_INOUT","CUR_USE","BOOK_TBL_NAME","ITM_TYPE","BOOK_TYPE") VALUES ($1,'01','01',$2,$3,$4,$5,'I','Y','PR_DATA','A','T')`,
          code,
          main,
          code,
          main,
        );
        for (const [i, ac] of ['CTRL', 'CASH', 'ROUND', 'LABOUR', 'DISCOUNT'].entries())
          await exec(
            `INSERT INTO "BOOK_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","SR_NO","AC_CODE","MAIN_BOOK","BOOK_INOUT") VALUES ($1,'01','01',$2,$3,$4,$5,'I')`,
            code,
            i + 1,
            ac,
            main,
          );
      }
      await exec(
        `INSERT INTO "TAX_MAST"(tenant_id,"CO_CODE","TAX_CODE","SR_NO","TAX_GROUP","TAX_PRC","TAX_AC") VALUES ($1,'01','10',0,'N',3,'GST'),($1,'01','10',1,'SGST',1.5,'SGST'),($1,'01','10',2,'CGST',1.5,'CGST'),($1,'01','10',3,'IGST',3,'IGST'),($1,'01','T1',0,'TCS',1,'TCS')`,
      );
      await exec(
        `INSERT INTO "SRNO_MAST"(tenant_id,"CO_CODE","LC_CODE","VCH_SRNO","TAG_SRNO") VALUES ($1,'01','01',0,0)`,
      );
    });
    afterAll(async () => {
      if (run) await wipe();
      await runtime.$disconnect();
      await owner.$disconnect();
    });
    const save = async (
      overrides: Record<string, any> = {},
      lines: any[] = [{ itCode: 'G', pcs: 1, netWt: 1, touch: 100, metalAmount: 100 }],
    ) => {
      const saved = await createPurchase(
        runtime,
        {
          scope: { ...scope, coBook: 'PUR' },
          acCode: 'SUP',
          vchDate: `${y}-06-10`,
          taxRatePct: 3,
          taxCode: '10',
          interState: false,
          ...overrides,
        },
        lines,
      );
      return String(saved.vchNo).padStart(5, '0');
    };
    const check = () => accountCheck(runtime, 'purchase', scope, { limit: 100 });
    const first = async () =>
      (await check()).vouchers[0] ??
      (await accountCheck(runtime, 'purchase', scope, { status: 'match' })).vouchers[0]!;
    const snapshot = () =>
      query(
        `SELECT * FROM (SELECT 'PR_DATA' t,to_jsonb(t) r FROM "PR_DATA" t WHERE tenant_id=$1 UNION ALL SELECT 'PR_DETL',to_jsonb(t) FROM "PR_DETL" t WHERE tenant_id=$1 UNION ALL SELECT 'MAIN_STOCK',to_jsonb(t) FROM "MAIN_STOCK" t WHERE tenant_id=$1  ) q ORDER BY t,r::text`,
      );
    it.each([
      ['ordinary', {}],
      ['tag', { scope: { ...scope, coBook: 'TAG' } }],
      ['cash', { cashAmt: 10 }],
      ['cheque', { chequeAmt: 10, bankAc: 'BANK' }],
      ['card', { cardAmt: 10, bankAc: 'BANK', cardAc: 'CARD' }],
      ['kasar', { kasar: 1 }],
      ['hallmark', { hmAmount: 10, hmTaxPct: 3 }],
      ['custom hallmark', { hmAmount: 10, hmChargeAc: 'HMOTHER', hmTaxPct: 3 }],
      ['TCS', { tcsCode: 'T1', tcsPct: 1 }],
      ['positive round-off', { roundOffAmount: 0.25 }],
      ['negative round-off', { roundOffAmount: -0.25 }],
      ['discount', { discountAmount: 0.5 }],
      ['unfixed', { rateUnfix: true }],
    ])('writer %s checks clean', async (_label, overrides) => {
      await save(overrides as any);
      const before = await snapshot();
      expect((await first()).status).toBe('match');
      expect(await snapshot()).toEqual(before);
    });
    it('checks interstate and zero-GST writer rows', async () => {
      await exec(`UPDATE "AC_MAST" SET "AC_GST_TYPE"='I' WHERE tenant_id=$1`);
      await save({ interState: true });
      await save({ interState: true, taxRatePct: 0, taxCode: undefined });
      expect((await check()).summary.match).toBe(2);
    });
    it('checks a legacy single-row GST master without inventing a parent', async () => {
      await exec(`DELETE FROM "TAX_MAST" WHERE tenant_id=$1 AND "TAX_CODE"='10'`);
      await exec(
        `INSERT INTO "TAX_MAST"(tenant_id,"CO_CODE","TAX_CODE","SR_NO","TAX_PRC","TAX_AC","TAX_GROUP") VALUES ($1,'01','10',1,3,'GST','GST')`,
      );
      await save({ taxCode: undefined });
      expect((await first()).status).toBe('match');
    });
    it('checks labour split and detects changing it afterwards', async () => {
      await exec(`UPDATE "BOOK_DATA" SET "ITM_TYPE"='G' WHERE tenant_id=$1`);
      await exec(`UPDATE "CO_SET" SET "PURC_WITH_LBR"='N' WHERE tenant_id=$1`);
      await save({}, [{ itCode: 'G', pcs: 1, metalAmount: 100, labourAmount: 20, otherAmount: 5 }]);
      expect((await first()).status).toBe('match');
      await exec(`UPDATE "CO_SET" SET "PURC_WITH_LBR"='Y' WHERE tenant_id=$1`);
      expect((await first()).status).toBe('unverified');
    });
    it('keeps persisted TDS and suppresses typed round-off when PR_TDS_TAX is enabled', async () => {
      await exec(`UPDATE "CO_SET_NEW" SET "PR_TDS_TAX"='Y' WHERE tenant_id=$1`);
      await save({ tdsCode: 'T1', tdsAmount: 1, tdsPct: 1, roundOffAmount: 0.25 });
      expect((await first()).status).toBe('match');
      await exec(`UPDATE "CO_SET_NEW" SET "PR_TDS_TAX"='N' WHERE tenant_id=$1`);
      expect((await first()).status).toBe('unverified');
    });
    it('does not infer UPI from a writer outstanding residual', async () => {
      await save({ upiAmt: 10, bankAc: 'BANK' });
      expect((await first()).reason).toContain('payment ambiguity');
    });
    it('detects a missing posting set but never enables apply', async () => {
      await save();
      for (const table of ['AC_DATA', 'ROJ_MEL_DATA', 'TAX_DATA'])
        await exec(`DELETE FROM "${table}" WHERE tenant_id=$1`);
      expect((await first()).status).toBe('missing');
      expect(ACCOUNT_REFRESH_VERIFIED.has('purchase')).toBe(false);
    });
    it('distinguishes CON PUR source references from sale links', async () => {
      await exec(
        `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","MAIN_BOOK") VALUES ($1,'01','01','CRE','CON REC')`,
      );
      await exec(
        `INSERT INTO "APR_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","OLD_SRNO","CON_ISU_REC") VALUES ($1,'01','01',$2,'CRE','00001',1,'N')`,
        scope.coYear,
      );
      await save(
        {
          scope: { ...scope, coBook: 'CPR' },
          consiNo: '00001',
          consiLcCode: '01',
          consiYrcd: scope.coYear,
          consiDbcd: 'CRE',
        },
        [{ itCode: 'G', pcs: 1, netWt: 1, touch: 100, metalAmount: 100, consiSrno: 1 }],
      );
      expect((await first()).status).toBe('match');
    });
    it('preserves mixed-metal, multi-group, commission and unpriced fine rows', async () => {
      await save({}, [
        { itCode: 'G', pcs: 1, netWt: 1, touch: 100, metalAmount: 100, commissionAmount: 5 },
        { itCode: 'S', pcs: 1, netWt: 2, touch: 100, metalAmount: 0, silverFineWt: 2 },
      ]);
      expect((await first()).status).toBe('match');
    });
    it.each(['AC_DATA', 'ROJ_MEL_DATA', 'TAX_DATA'])(
      'detects damaged %s without changing source rows',
      async (table) => {
        await save();
        const before = await snapshot();
        await exec(`DELETE FROM "${table}" WHERE tenant_id=$1`);
        expect((await first()).status).toBe('differs');
        expect(await snapshot()).toEqual(before);
      },
    );
    it('detects a changed amount and refuses apply for this preview-only family', async () => {
      await save();
      await exec(`UPDATE "AC_DATA" SET "DR_AMT"="DR_AMT"+1 WHERE tenant_id=$1 AND "DR_AMT">0`);
      expect((await first()).status).toBe('differs');
      expect(ACCOUNT_REFRESH_VERIFIED.has('purchase')).toBe(false);
      const p = await previewRepair(runtime, 'data-refresh-account-purchase', scope, 'test');
      const before = await query(
        `SELECT to_jsonb(t) r FROM "AC_DATA" t WHERE tenant_id=$1 ORDER BY "LEDR_KEY"`,
      );
      await expect(
        applyRepair(runtime, 'data-refresh-account-purchase', scope, {
          previewHash: p.previewHash,
          operator: 'test',
          confirmation: 'data-refresh-account-purchase 01',
          reason: 'must refuse',
        } as any),
      ).rejects.toMatchObject({ code: 'preview-only' });
      expect(
        await query(`SELECT to_jsonb(t) r FROM "AC_DATA" t WHERE tenant_id=$1 ORDER BY "LEDR_KEY"`),
      ).toEqual(before);
    });
    const mutations: Array<[string, string, string]> = [
      [
        'tax book coverage',
        `UPDATE "BOOK_DATA" SET "BOOK_TYPE"='N' WHERE tenant_id=$1`,
        'book coverage',
      ],
      [
        'group drift',
        `UPDATE "GROUP_MAST" SET "PURC_AC"='OLD' WHERE tenant_id=$1`,
        'configuration drift',
      ],
      [
        'book drift',
        `UPDATE "BOOK_DATA" SET "BOOK_SNAME"='OLD' WHERE tenant_id=$1`,
        'configuration drift',
      ],
      [
        'tax component drift',
        `UPDATE "TAX_MAST" SET "TAX_GROUP"='OLD' WHERE tenant_id=$1 AND "SR_NO"=1`,
        'configuration drift',
      ],
      [
        'linked header',
        `UPDATE "PR_DATA" SET "SL_BILL_NO"='99999' WHERE tenant_id=$1`,
        'linked-to-sale',
      ],
      [
        'linked line',
        `UPDATE "PR_DETL" SET "SL_BILL_DBCD"='SAL' WHERE tenant_id=$1`,
        'linked-to-sale',
      ],
      [
        'UPI residual',
        `UPDATE "PR_DATA" SET "BILL_OS"="BILL_OS"-1 WHERE tenant_id=$1`,
        'payment ambiguity',
      ],
      ['gapped serial', `UPDATE "PR_DETL" SET "SR_NO"=2 WHERE tenant_id=$1`, 'serials'],
      ['missing item', `DELETE FROM "ITEM_MAST" WHERE tenant_id=$1`, 'item'],
      ['tax split', `UPDATE "PR_DATA" SET "CGST_TAX"=99 WHERE tenant_id=$1`, 'tax splits'],
      [
        'legacy 99',
        `UPDATE "AC_DATA" SET "LEDR_KEY"='0101'||"CO_YEAR"||"CO_BOOK"||"VCH_NO"||'99' WHERE tenant_id=$1 AND "DR_AMT">0 AND "AC_CODE"='PURAC'`,
        'legacy 99',
      ],
    ];
    it.each(mutations)('%s is unverified and not a repair target', async (_name, sql, reason) => {
      await save();
      await exec(sql);
      const before = await snapshot();
      const c = await check();
      expect(c.vouchers[0]?.status).toBe('unverified');
      expect(c.vouchers[0]?.reason).toContain(reason);
      expect(
        (await previewRepair(runtime, 'data-refresh-account-purchase', scope, 'test')).diffs,
      ).toEqual([]);
      expect(await snapshot()).toEqual(before);
    });
    it('TCS account drift is unverified without recomputing stored TCS', async () => {
      await save({ tcsCode: 'T1', tcsPct: 1 });
      await exec(`UPDATE "TAX_MAST" SET "TAX_AC"='OTHER' WHERE tenant_id=$1 AND "TAX_CODE"='T1'`);
      expect((await first()).status).toBe('unverified');
    });
    it('lost typed round-off evidence is unverified', async () => {
      await save({ roundOffAmount: 0.25 });
      await exec(`DELETE FROM "AC_DATA" WHERE tenant_id=$1 AND right("LEDR_KEY",2)='26'`);
      expect((await first()).reason).toContain('round-off origin ambiguous');
    });
    it('retains stored wall-clock date/time on a non-UTC server', async () => {
      await save();
      await exec(
        `UPDATE "PR_DATA" SET "VCH_TIME"=$2::timestamp WHERE tenant_id=$1`,
        `${y}-06-10 23:59:47`,
      );
      await exec(
        `UPDATE "AC_DATA" SET "ENTRY_TIME"=$2::timestamp WHERE tenant_id=$1`,
        `${y}-06-10 23:59:47`,
      );
      expect((await first()).status).toBe('match');
    });
  });
}
