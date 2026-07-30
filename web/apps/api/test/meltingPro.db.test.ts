import { PrismaClient } from '@prisma/client';
import { afterAll, beforeAll, beforeEach, describe, expect, it } from 'vitest';
import { PeriodLockValidationError } from '../src/modules/posting/posting.js';
import {
  deleteMeltingPro,
  getMeltingPro,
  saveMeltingPro,
} from '../src/modules/manufacturing/meltingPro.js';
import type { VoucherScope } from '../src/modules/vouchers/numbering.js';

const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const databaseDescribe = RUN ? describe : describe.skip;
const TENANT = 'melting-pro-db';
const CO = '01';
const LC = '01';
const YEAR = '2024-2025';
const BOOK = 'MLP';
const DAY = '2024-04-10';
const scope: VoucherScope = {
  tenantId: TENANT,
  coCode: CO,
  lcCode: LC,
  coYear: YEAR,
  coBook: BOOK,
};

const fullInput = (mainUser = 'creator') => ({
  scope,
  vchDate: DAY,
  acCode: 'PARTY',
  acName: 'Melting Party',
  employeeCode: 'E1',
  description: 'Desktop parity melt',
  lotNo: 'LOT001',
  mainUser,
  deleteUser: mainUser,
  outLines: [
    {
      itCode: 'SCRAP',
      itemName: 'Scrap Gold',
      itemType: 'G',
      pieces: 1,
      grossWt: 100,
      otherWt: 0,
      touch: 80,
    },
  ],
  resultLines: [
    {
      itCode: 'MELT1',
      itemName: 'Melt Gold',
      itemType: 'G',
      pieces: 1,
      grossWt: 100,
      touch: 80,
      conPct: 90,
      conItCode: 'FINE',
      finePct: 100,
      returnWt: 10,
      returnItCode: 'RTN',
      lotNo: 'LOT001',
    },
    {
      itCode: 'MELT2',
      itemName: 'Second Melt',
      itemType: 'G',
      pieces: 1,
      grossWt: 25,
      touch: 80,
      conPct: 80,
      conWt: 5,
      conItCode: 'ALLOY',
      recoveredGrossWt: 25,
    },
  ],
});

databaseDescribe('database-backed TR_MLT_PRO lifecycle', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;

  const cleanup = async (): Promise<void> => {
    for (const table of [
      'DELETE_DATA',
      'REMARK_DATA',
      'MFG_ISU_REC',
      'MAIN_STOCK',
      'MFG_DETL',
      'MLT_DETL',
      'MLT_DATA',
      'TEMP_BOOK_DATA',
      'ITEM_MAST',
      'BOOK_DATA',
      'YEAR_MAST',
      'CO_SET',
    ]) {
      await owner.$executeRawUnsafe(`DELETE FROM "${table}" WHERE tenant_id=$1`, TENANT);
    }
  };

  const seed = async (): Promise<void> => {
    await owner.$executeRawUnsafe(
      `INSERT INTO "CO_SET"(tenant_id,"CO_CODE","LOCK_DATE") VALUES ($1,$2,NULL)`,
      TENANT,
      CO,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "YEAR_MAST"(tenant_id,"CO_CODE","CO_YEAR","OP_DATE","CL_DATE")
       VALUES ($1,$2,$3,'2024-04-01','2025-03-31'::timestamp)`,
      TENANT,
      CO,
      YEAR,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "BOOK_DATA"(
         tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME","MAIN_BOOK",
         "BOOK_INOUT","CUR_USE","BOOK_TBL_NAME","DATA_TYPE")
       VALUES ($1,$2,$3,$4,'Melting Process','MLT','MLT PRO','O','Y','MLT_DATA','A')`,
      TENANT,
      CO,
      LC,
      BOOK,
    );
    for (const [code, name] of [
      ['SCRAP', 'Scrap Gold'],
      ['MELT1', 'Melt Gold'],
      ['MELT2', 'Second Melt'],
      ['FINE', 'Fine Gold'],
      ['ALLOY', 'Alloy'],
      ['RTN', 'Return Gold'],
    ]) {
      await owner.$executeRawUnsafe(
        `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE")
         VALUES ($1,$2,$3,$4,'G')`,
        TENANT,
        CO,
        code,
        name,
      );
    }
  };

  beforeAll(async () => {
    const ownerUrl = process.env.MIGRATE_DATABASE_URL;
    const runtimeUrl = process.env.DATABASE_URL;
    if (!ownerUrl || !runtimeUrl) {
      throw new Error('RUN_DB_INTEGRITY_TESTS requires MIGRATE_DATABASE_URL and DATABASE_URL');
    }
    if (new URL(ownerUrl).port !== '55433' || new URL(runtimeUrl).port !== '55433') {
      throw new Error('melting DB tests may only use PostgreSQL port 55433');
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

  it('atomically creates all desktop write families, reads them, replaces from source, and audits deletion', async () => {
    const created = await saveMeltingPro(runtime, fullInput());
    expect(created).toEqual({
      voucherNo: '00001',
      hiddenVoucherNo: '00001',
      created: true,
      outLines: 1,
      resultLines: 2,
      stockRows: 8,
    });

    const evidence = (await owner.$queryRawUnsafe(
      `SELECT
        (SELECT count(*)::int FROM "MLT_DATA" WHERE tenant_id=$1) headers,
        (SELECT count(*)::int FROM "MLT_DETL" WHERE tenant_id=$1 AND "ENTRY_TYPE"='O') out_rows,
        (SELECT count(*)::int FROM "MLT_DETL" WHERE tenant_id=$1 AND "ENTRY_TYPE"='I') result_rows,
        (SELECT count(*)::int FROM "MFG_DETL" WHERE tenant_id=$1 AND "ENTRY_TYPE"='X') mfg_x,
        (SELECT count(*)::int FROM "MAIN_STOCK" WHERE tenant_id=$1) stock_rows,
        (SELECT count(DISTINCT "ISR_NO")::int FROM "MAIN_STOCK" WHERE tenant_id=$1) stock_families,
        (SELECT string_agg(DISTINCT "ISR_NO"::int::text,',' ORDER BY "ISR_NO"::int::text) FROM "MAIN_STOCK" WHERE tenant_id=$1) family_ids,
        (SELECT count(*)::int FROM "MFG_ISU_REC" WHERE tenant_id=$1) final_mfg,
        (SELECT min("CHOL_IT_CODE") FROM "MFG_DETL" WHERE tenant_id=$1) chol_item,
        (SELECT min("LAST_IR_TYPE") FROM "MFG_DETL" WHERE tenant_id=$1) mfg_last_type,
        (SELECT min("LAST_IR_TYPE") FROM "MFG_ISU_REC" WHERE tenant_id=$1) flow_last_type,
        (SELECT count(*)::int FROM "TEMP_BOOK_DATA" WHERE tenant_id=$1) temp_rows,
        (SELECT count(*)::int FROM "REMARK_DATA" WHERE tenant_id=$1) remarks,
        (SELECT min("MLT_WT")::float FROM "MLT_DETL" WHERE tenant_id=$1 AND "ENTRY_TYPE"='I') min_melt,
        (SELECT max("RTN_WT")::float FROM "MLT_DETL" WHERE tenant_id=$1 AND "ENTRY_TYPE"='I') return_wt,
        (SELECT max("RTN_IT_CODE") FROM "MLT_DETL" WHERE tenant_id=$1 AND "ENTRY_TYPE"='I') return_item`,
      TENANT,
    )) as Array<Record<string, unknown>>;
    expect(evidence[0]).toMatchObject({
      headers: 1,
      out_rows: 1,
      result_rows: 2,
      mfg_x: 1,
      stock_rows: 8,
      stock_families: 6,
      family_ids: '1,2,3,4,5,6',
      final_mfg: 1,
      chol_item: 'RTN',
      mfg_last_type: 'X',
      flow_last_type: 'X',
      temp_rows: 1,
      remarks: 1,
      min_melt: 25,
      return_wt: 10,
      return_item: 'RTN',
    });

    const before = (await getMeltingPro(runtime, scope, created.voucherNo)) as any;
    expect(before).toMatchObject({
      voucherNo: '00001',
      hiddenVoucherNo: '00001',
      mainUser: 'creator',
      outLines: [{ itCode: 'SCRAP', netWt: 100, partyFine: 80 }],
      resultLines: [
        { itCode: 'MELT1', conItCode: 'FINE', fineAdd: 100, meltWt: 200, returnWt: 10 },
        { itCode: 'MELT2', conItCode: 'ALLOY', conWt: 5 },
      ],
    });
    const originalTime = (await owner.$queryRawUnsafe(
      `SELECT "VCH_TIME"::text t FROM "MLT_DATA" WHERE tenant_id=$1`,
      TENANT,
    )) as Array<{ t: string }>;

    const editedInput = fullInput('different-user');
    editedInput.description = 'Edited melt';
    editedInput.resultLines = [editedInput.resultLines[0]!];
    const edited = await saveMeltingPro(runtime, editedInput, created.voucherNo);
    expect(edited).toMatchObject({
      voucherNo: '00001',
      hiddenVoucherNo: '00001',
      created: false,
      outLines: 1,
      resultLines: 1,
    });
    const after = (await getMeltingPro(runtime, scope, created.voucherNo)) as any;
    expect(after).toMatchObject({
      mainUser: 'creator',
      description: 'Edited melt',
      resultLines: [{ itCode: 'MELT1' }],
    });
    const editEvidence = (await owner.$queryRawUnsafe(
      `SELECT
        (SELECT "VCH_TIME"::text FROM "MLT_DATA" WHERE tenant_id=$1) t,
        (SELECT count(*)::int FROM "DELETE_DATA" WHERE tenant_id=$1) audits,
        (SELECT count(*)::int FROM "MLT_DETL" WHERE tenant_id=$1) live_details`,
      TENANT,
    )) as Array<Record<string, unknown>>;
    expect(editEvidence[0]).toMatchObject({
      t: originalTime[0]!.t,
      audits: 0,
      live_details: 2,
    });

    await expect(deleteMeltingPro(runtime, scope, created.voucherNo, 'deleter')).resolves.toEqual({
      reversed: true,
      auditedDetails: 2,
    });
    const remaining = (await owner.$queryRawUnsafe(
      `SELECT
        (SELECT count(*)::int FROM "MLT_DATA" WHERE tenant_id=$1) headers,
        (SELECT count(*)::int FROM "MLT_DETL" WHERE tenant_id=$1) details,
        (SELECT count(*)::int FROM "MAIN_STOCK" WHERE tenant_id=$1) stock_rows,
        (SELECT count(*)::int FROM "MFG_DETL" WHERE tenant_id=$1) mfg_rows,
        (SELECT count(*)::int FROM "MFG_ISU_REC" WHERE tenant_id=$1) ledger_rows,
        (SELECT count(*)::int FROM "TEMP_BOOK_DATA" WHERE tenant_id=$1) temp_rows,
        (SELECT count(*)::int FROM "REMARK_DATA" WHERE tenant_id=$1) remarks,
        (SELECT count(*)::int FROM "DELETE_DATA" WHERE tenant_id=$1) audits`,
      TENANT,
    )) as Array<Record<string, unknown>>;
    expect(remaining[0]).toEqual({
      headers: 0,
      details: 0,
      stock_rows: 0,
      mfg_rows: 0,
      ledger_rows: 0,
      temp_rows: 0,
      remarks: 0,
      audits: 2,
    });
  }, 30_000);

  it('checks both requested and persisted dates and serializes both number scopes', async () => {
    const first = await saveMeltingPro(runtime, fullInput('first'));
    await owner.$executeRawUnsafe(
      `UPDATE "CO_SET" SET "LOCK_DATE"=$1::date WHERE tenant_id=$2 AND "CO_CODE"=$3`,
      DAY,
      TENANT,
      CO,
    );
    await expect(
      saveMeltingPro(runtime, { ...fullInput('editor'), vchDate: '2024-04-11' }, first.voucherNo),
    ).rejects.toBeInstanceOf(PeriodLockValidationError);
    await expect(
      deleteMeltingPro(runtime, scope, first.voucherNo, 'deleter'),
    ).rejects.toBeInstanceOf(PeriodLockValidationError);
    expect(await getMeltingPro(runtime, scope, first.voucherNo)).toMatchObject({
      vchDate: DAY,
      mainUser: 'first',
    });

    await owner.$executeRawUnsafe(
      `UPDATE "CO_SET" SET "LOCK_DATE"=NULL WHERE tenant_id=$1 AND "CO_CODE"=$2`,
      TENANT,
      CO,
    );
    const second = await saveMeltingPro(runtime, {
      ...fullInput('second'),
      lotNo: 'LOT002',
    });
    expect([first.voucherNo, second.voucherNo]).toEqual(['00001', '00002']);
    expect([first.hiddenVoucherNo, second.hiddenVoucherNo]).toEqual(['00001', '00002']);
  }, 30_000);

  it('resolves all item metadata server-side and gates one-form manufacturing flow by company setting', async () => {
    const unknown = fullInput();
    unknown.outLines[0]!.itCode = 'NOPE';
    await expect(saveMeltingPro(runtime, unknown)).rejects.toThrow(/item not found: NOPE/);
    const unknownConversion = fullInput();
    unknownConversion.resultLines[0]!.conItCode = 'NOPE';
    await expect(saveMeltingPro(runtime, unknownConversion)).rejects.toThrow(
      /item not found: NOPE/,
    );
    const unknownReturn = fullInput();
    unknownReturn.resultLines[0]!.returnItCode = 'NOPE';
    await expect(saveMeltingPro(runtime, unknownReturn)).rejects.toThrow(/item not found: NOPE/);
    const rejectedRows = (await owner.$queryRawUnsafe(
      `SELECT
        (SELECT count(*)::int FROM "MLT_DATA" WHERE tenant_id=$1) headers,
        (SELECT count(*)::int FROM "MLT_DETL" WHERE tenant_id=$1) details,
        (SELECT count(*)::int FROM "MAIN_STOCK" WHERE tenant_id=$1) stock_rows`,
      TENANT,
    )) as Array<Record<string, unknown>>;
    expect(rejectedRows[0]).toEqual({ headers: 0, details: 0, stock_rows: 0 });

    const spoofed = fullInput();
    spoofed.outLines[0]!.itemName = 'Attacker name';
    spoofed.outLines[0]!.itemType = 'S';
    spoofed.resultLines[0]!.itemName = 'Attacker result';
    spoofed.resultLines[0]!.itemType = 'S';
    await saveMeltingPro(runtime, spoofed);
    const authoritative = (await owner.$queryRawUnsafe(
      `SELECT
        (SELECT min("IT_NAME") FROM "MLT_DETL" WHERE tenant_id=$1 AND "IT_CODE"='SCRAP') out_name,
        (SELECT min("IT_TYPE") FROM "MLT_DETL" WHERE tenant_id=$1 AND "IT_CODE"='SCRAP') out_type,
        (SELECT min("IT_NAME") FROM "MLT_DETL" WHERE tenant_id=$1 AND "IT_CODE"='MELT1') result_name,
        (SELECT min("IT_TYPE") FROM "MLT_DETL" WHERE tenant_id=$1 AND "IT_CODE"='MELT1') result_type,
        (SELECT count(*)::int FROM "MFG_ISU_REC" WHERE tenant_id=$1) final_mfg`,
      TENANT,
    )) as Array<Record<string, unknown>>;
    expect(authoritative[0]).toEqual({
      out_name: 'Scrap Gold',
      out_type: 'G',
      result_name: 'Melt Gold',
      result_type: 'G',
      final_mfg: 1,
    });

    await cleanup();
    await seed();
    await owner.$executeRawUnsafe(
      `UPDATE "CO_SET" SET "MFG_ONE_FORM"='N' WHERE tenant_id=$1 AND "CO_CODE"=$2`,
      TENANT,
      CO,
    );
    await saveMeltingPro(runtime, fullInput());
    const disabled = (await owner.$queryRawUnsafe(
      `SELECT count(*)::int n FROM "MFG_ISU_REC" WHERE tenant_id=$1`,
      TENANT,
    )) as Array<{ n: number }>;
    expect(disabled[0]?.n).toBe(0);
  }, 30_000);
});
