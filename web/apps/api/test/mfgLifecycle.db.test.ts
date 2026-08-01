import { PrismaClient } from '@prisma/client';
import { afterAll, beforeAll, beforeEach, describe, expect, it } from 'vitest';
import {
  deleteKarigar,
  editKarigar,
  getKarigar,
  issueKarigar,
} from '../src/modules/manufacturing/karigar.js';
import { deleteMfg, editMfg, getMfg, IR_TYPE, issueMfg } from '../src/modules/manufacturing/mfg.js';
import { PeriodLockValidationError } from '../src/modules/posting/posting.js';
import type { VoucherScope } from '../src/modules/vouchers/numbering.js';

const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const databaseDescribe = RUN ? describe : describe.skip;
const TENANT = 'mfg-lifecycle-db';
const CO = '92';
const LC = '01';
const YEAR = '2024-2025';
const DAY = '2024-04-10';
const NEXT_DAY = '2024-04-11';
const LOCKED_REQUEST_DAY = '2024-04-12';
const MAIN_USER = 'mfg-user';
const KARIGAR_BOOK = 'KIS';
const MFG_BOOK = 'MIP';

const lifecycleTables = [
  'DELETE_DATA',
  'BAR_DETL',
  'MAIN_STOCK',
  'AC_DATA',
  'ROJ_MEL_DATA',
  'KR_DETL',
  'KR_DATA',
  'MFG_IDTL',
  'MFG_ISU_REC',
  'MFG_DETL',
  'MFG_DATA',
  'TEMP_BOOK_DATA',
] as const;

function scope(coBook: string): VoucherScope {
  return { tenantId: TENANT, coCode: CO, lcCode: LC, coYear: YEAR, coBook };
}

// Desktop audit truth, verified with grep -c 'INSERT INTO DELETE_DATA':
// unified/src/csharp/DataCareNext/TR_KR_ISU.cs = 1 (detail SELECT, hence one row per detail), and
// unified/src/csharp/DataCareNext/TR_MFG_ISU_REC.cs = 1 (one zero-valued header row). Both statements
// are in delete handlers; desktop edits therefore write exactly zero DELETE_DATA rows.
databaseDescribe('database-backed karigar/manufacturing edit lifecycle', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;

  const cleanup = async (): Promise<void> => {
    for (const table of [
      ...lifecycleTables,
      'MFG_MAST',
      'ITEM_MAST',
      'AC_MAST',
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
         "BOOK_INOUT","CUR_USE","BOOK_TBL_NAME") VALUES
       ($1,$2,$3,$4,'Karigar Issue','KRI','KARIGAR','O','Y','KR_DATA'),
       ($1,$2,$3,$5,'Mfg Process','MFGI','MANUFACTURING','O','Y','MFG_DATA')`,
      TENANT,
      CO,
      LC,
      KARIGAR_BOOK,
      MFG_BOOK,
    );
    // Hidden voucher numbering is deliberately ahead of the empty main voucher tables.
    await owner.$executeRawUnsafe(
      `INSERT INTO "TEMP_BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","VCH_NO","BOOK_NAME") VALUES
       ($1,$2,$3,$4,'00007','historic karigar hidden seed'),
       ($1,$2,$3,$5,'00007','historic mfg hidden seed')`,
      TENANT,
      CO,
      LC,
      KARIGAR_BOOK,
      MFG_BOOK,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE") VALUES
       ($1,$2,'GOLD1','Gold One','G'),
       ($1,$2,'GOLD2','Gold Two','G'),
       ($1,$2,'GOLD3','Gold Three','G')`,
      TENANT,
      CO,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","AC_CODE","AC_NAME") VALUES
       ($1,$2,'KRG1','Karigar One'),
       ($1,$2,'KRG2','Karigar Two'),
       ($1,$2,'PARTY1','Process Party One'),
       ($1,$2,'PARTY2','Process Party Two')`,
      TENANT,
      CO,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "MFG_MAST"(
         tenant_id,"CO_CODE","SM_MAIN_CODE","CO_BOOK","BOOK_SNAME","ENTRY_TYPE","STK_ISU",
         "STK_REC","IN_OUT","MAIN_BOOK")
       VALUES ($1,$2,'01',$3,'MFGI',$4,'Y','Y','O','Mfg Process')`,
      TENANT,
      CO,
      MFG_BOOK,
      IR_TYPE.FILE,
    );
  };

  const assertCreatedIdentities = async (
    table: 'KR_DATA' | 'MFG_DATA',
    book: string,
  ): Promise<Array<Record<string, unknown>>> => {
    const headers = (await owner.$queryRawUnsafe(
      `SELECT "VCH_NO","HD_VCH_NO","MAIN_USER","VCH_DATE"::text,
              to_char("VCH_TIME",'HH24:MI:SS.MS') clock
         FROM "${table}" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3
          AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 ORDER BY "VCH_NO"`,
      TENANT,
      CO,
      LC,
      YEAR,
      book,
    )) as Array<Record<string, unknown>>;
    expect(headers).toHaveLength(2);
    expect(
      headers.map(({ VCH_NO, HD_VCH_NO, MAIN_USER, VCH_DATE }) => ({
        VCH_NO,
        HD_VCH_NO,
        MAIN_USER,
        VCH_DATE,
      })),
    ).toEqual([
      { VCH_NO: '00001', HD_VCH_NO: '00008', MAIN_USER, VCH_DATE: DAY },
      { VCH_NO: '00002', HD_VCH_NO: '00009', MAIN_USER, VCH_DATE: DAY },
    ]);
    for (const header of headers) {
      expect(String(header.clock)).toMatch(/^\d{2}:\d{2}:\d{2}\.\d{3}$/);
    }
    const tempRows = (await owner.$queryRawUnsafe(
      `SELECT "VCH_NO","BOOK_NAME" FROM "TEMP_BOOK_DATA"
        WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_BOOK"=$4
        ORDER BY "VCH_NO"`,
      TENANT,
      CO,
      LC,
      book,
    )) as Array<Record<string, unknown>>;
    expect(tempRows.map((row) => row.VCH_NO)).toEqual(['00007', '00008', '00009']);
    expect(tempRows.slice(1).every((row) => String(row.BOOK_NAME).length > 0)).toBe(true);
    return headers;
  };

  const databaseSnapshot = async (): Promise<Record<string, Record<string, unknown>>> => {
    const result: Record<string, Record<string, unknown>> = {};
    for (const table of lifecycleTables) {
      const rows = (await owner.$queryRawUnsafe(
        `SELECT count(*)::int rows,
                md5(coalesce(string_agg(to_jsonb(t)::text,'|' ORDER BY to_jsonb(t)::text),'')) digest
           FROM "${table}" t WHERE tenant_id=$1`,
        TENANT,
      )) as Array<Record<string, unknown>>;
      result[table] = rows[0]!;
    }
    return result;
  };

  const unlock = async (): Promise<void> => {
    await owner.$executeRawUnsafe(
      `UPDATE "CO_SET" SET "LOCK_DATE"=NULL WHERE tenant_id=$1 AND "CO_CODE"=$2`,
      TENANT,
      CO,
    );
  };

  beforeAll(async () => {
    const ownerUrl = process.env.MIGRATE_DATABASE_URL;
    const runtimeUrl = process.env.DATABASE_URL;
    if (!ownerUrl || !runtimeUrl) {
      throw new Error('RUN_DB_INTEGRITY_TESTS requires MIGRATE_DATABASE_URL and DATABASE_URL');
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

  it('covers karigar issue create/get/edit/persisted-date lock/delete against PostgreSQL', async () => {
    const karigarScope = scope(KARIGAR_BOOK);
    const created = await issueKarigar(runtime, {
      scope: karigarScope,
      karigarAc: 'KRG1',
      karigarName: 'Karigar One',
      vchDate: DAY,
      mainUser: MAIN_USER,
      lines: [
        {
          itCode: 'GOLD1',
          tagNo: 'K-TAG-1',
          pcs: 1,
          grossWt: 13,
          netWt: 10,
          ghtWt: 2,
          touch: 90,
          westPct: 2,
          lesWt: 1,
        },
      ],
    });
    const second = await issueKarigar(runtime, {
      scope: karigarScope,
      karigarAc: 'KRG1',
      vchDate: DAY,
      mainUser: MAIN_USER,
      lines: [{ itCode: 'GOLD1', pcs: 1, grossWt: 4, netWt: 4, touch: 90 }],
    });
    expect([created.vchNo, second.vchNo]).toEqual([1, 2]);
    // karigarIssue policy: (net + ghat) × (touch + wastage) / 100 − less weight.
    expect(created.fineIssued).toBe(10.04);

    const initialHeaders = await assertCreatedIdentities('KR_DATA', KARIGAR_BOOK);
    const persistedFine = (await owner.$queryRawUnsafe(
      `SELECT
         (SELECT "ITM_FINE"::float FROM "KR_DETL" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00001') detail_fine,
         (SELECT "ITM_FINE"::float FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00001') stock_fine`,
      TENANT,
      KARIGAR_BOOK,
    )) as Array<Record<string, unknown>>;
    expect(persistedFine[0]).toEqual({ detail_fine: 10.04, stock_fine: 10.04 });

    const opened = await getKarigar(runtime, karigarScope, '00001');
    expect(opened).toMatchObject({
      voucherNo: '00001',
      hiddenVoucherNo: '00008',
      mainUser: MAIN_USER,
      vchDate: DAY,
      karigarAc: 'KRG1',
      mode: 'issue',
      lines: [{ itCode: 'GOLD1', tagNo: 'K-TAG-1', netWt: 10, ghtWt: 2 }],
    });

    await editKarigar(runtime, {
      scope: karigarScope,
      vchNo: '00001',
      mode: 'issue',
      karigarAc: 'KRG2',
      karigarName: 'Karigar Two Edited',
      vchDate: NEXT_DAY,
      mainUser: 'ignored-editor',
      lines: [
        {
          itCode: 'GOLD2',
          tagNo: 'K-TAG-2',
          pcs: 2,
          grossWt: 10,
          netWt: 8,
          ghtWt: 1,
          touch: 91,
          westPct: 1,
          lesWt: 0.5,
          lbrAmt: 4,
          othAmt: 1,
        },
        {
          itCode: 'GOLD3',
          tagNo: 'K-TAG-3',
          pcs: 1,
          grossWt: 6,
          netWt: 5,
          ghtWt: 0.5,
          touch: 89,
          westPct: 1,
          lesWt: 0.2,
          lbrAmt: 6,
          othAmt: 2,
        },
      ],
    });

    const edited = await getKarigar(runtime, karigarScope, 1);
    expect(edited).toMatchObject({
      voucherNo: '00001',
      hiddenVoucherNo: '00008',
      mainUser: MAIN_USER,
      vchDate: NEXT_DAY,
      karigarAc: 'KRG2',
      lines: [{ itCode: 'GOLD2' }, { itCode: 'GOLD3' }],
    });
    const editedRows = (await owner.$queryRawUnsafe(
      `SELECT
         (SELECT "HD_VCH_NO" FROM "KR_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00001') hidden,
         (SELECT "MAIN_USER" FROM "KR_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00001') main_user,
         (SELECT to_char("VCH_TIME",'HH24:MI:SS.MS') FROM "KR_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00001') clock,
         (SELECT count(*)::int FROM "DELETE_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00001') audits`,
      TENANT,
      KARIGAR_BOOK,
    )) as Array<Record<string, unknown>>;
    expect(editedRows[0]).toEqual({
      hidden: '00008',
      main_user: MAIN_USER,
      clock: initialHeaders[0]!.clock,
      audits: 0,
    });
    const karigarReplacement = (await owner.$queryRawUnsafe(
      `SELECT 'detail' source,"SR_NO","IT_CODE","ITM_NWT"::float,"ITM_FINE"::float
         FROM "KR_DETL" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00001'
       UNION ALL
       SELECT 'stock' source,"SR_NO","IT_CODE","ITM_NWT"::float,"ITM_FINE"::float
         FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00001'
       ORDER BY source,"SR_NO"`,
      TENANT,
      KARIGAR_BOOK,
    )) as Array<Record<string, unknown>>;
    expect(karigarReplacement).toEqual([
      { source: 'detail', SR_NO: 1, IT_CODE: 'GOLD2', ITM_NWT: 8, ITM_FINE: 7.78 },
      { source: 'detail', SR_NO: 2, IT_CODE: 'GOLD3', ITM_NWT: 5, ITM_FINE: 4.75 },
      { source: 'stock', SR_NO: 1, IT_CODE: 'GOLD2', ITM_NWT: 8, ITM_FINE: 7.78 },
      { source: 'stock', SR_NO: 2, IT_CODE: 'GOLD3', ITM_NWT: 5, ITM_FINE: 4.75 },
    ]);

    await owner.$executeRawUnsafe(
      `UPDATE "CO_SET" SET "LOCK_DATE"=$1 WHERE tenant_id=$2 AND "CO_CODE"=$3`,
      NEXT_DAY,
      TENANT,
      CO,
    );
    const beforeLockedEdit = await databaseSnapshot();
    await expect(
      editKarigar(runtime, {
        scope: karigarScope,
        vchNo: 1,
        mode: 'issue',
        karigarAc: 'KRG1',
        vchDate: LOCKED_REQUEST_DAY,
        lines: [{ itCode: 'GOLD1', netWt: 99, touch: 99 }],
      }),
    ).rejects.toBeInstanceOf(PeriodLockValidationError);
    expect(await databaseSnapshot()).toEqual(beforeLockedEdit);
    await unlock();

    await expect(
      deleteKarigar(runtime, {
        scope: karigarScope,
        vchNo: 1,
        deleteUser: 'deleter',
      }),
    ).resolves.toEqual({ reversed: true });
    const removed = (await owner.$queryRawUnsafe(
      `SELECT
         (SELECT count(*)::int FROM "KR_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00001') headers,
         (SELECT count(*)::int FROM "KR_DETL" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00001') details,
         (SELECT count(*)::int FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00001') stock,
         (SELECT count(*)::int FROM "TEMP_BOOK_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00008') temp`,
      TENANT,
      KARIGAR_BOOK,
    )) as Array<Record<string, unknown>>;
    expect(removed[0]).toEqual({ headers: 0, details: 0, stock: 0, temp: 0 });
    const audits = (await owner.$queryRawUnsafe(
      `SELECT "CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","VCH_DATE"::text,
              "VCH_TYPE","BOOK_NAME","AC_CODE","AC_NAME","VCH_VAL_DR","VCH_VAL_CR","FINE_TYPE",
              "VCH_FINE_DR"::float,"VCH_FINE_CR"::float,"HD_VCH_NO","MAIN_USER","DELETE_USER","VCH_DESC",
              to_char("VCH_TIME",'HH24:MI:SS.MS') clock,
              ("DELETE_DATE" IS NOT NULL) delete_date_set,("DELETE_TIME" IS NOT NULL) delete_time_set
         FROM "DELETE_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00001'
         ORDER BY "SR_NO"`,
      TENANT,
      KARIGAR_BOOK,
    )) as Array<Record<string, unknown>>;
    expect(audits).toEqual([
      {
        CO_CODE: CO,
        LC_CODE: LC,
        CO_YEAR: YEAR,
        CO_BOOK: KARIGAR_BOOK,
        VCH_NO: '00001',
        SR_NO: 1,
        VCH_DATE: NEXT_DAY,
        VCH_TYPE: 'KRI',
        BOOK_NAME: 'Karigar Issue',
        AC_CODE: 'KRG2',
        AC_NAME: 'Karigar Two Edited',
        VCH_VAL_DR: 5,
        VCH_VAL_CR: 0,
        FINE_TYPE: null,
        VCH_FINE_DR: 0,
        VCH_FINE_CR: 8,
        HD_VCH_NO: '00008',
        MAIN_USER,
        DELETE_USER: 'deleter',
        VCH_DESC: 'ItCode / GOLD2   TagNo / K-TAG-2',
        clock: initialHeaders[0]!.clock,
        delete_date_set: true,
        delete_time_set: true,
      },
      {
        CO_CODE: CO,
        LC_CODE: LC,
        CO_YEAR: YEAR,
        CO_BOOK: KARIGAR_BOOK,
        VCH_NO: '00001',
        SR_NO: 2,
        VCH_DATE: NEXT_DAY,
        VCH_TYPE: 'KRI',
        BOOK_NAME: 'Karigar Issue',
        AC_CODE: 'KRG2',
        AC_NAME: 'Karigar Two Edited',
        VCH_VAL_DR: 8,
        VCH_VAL_CR: 0,
        FINE_TYPE: null,
        VCH_FINE_DR: 0,
        VCH_FINE_CR: 5,
        HD_VCH_NO: '00008',
        MAIN_USER,
        DELETE_USER: 'deleter',
        VCH_DESC: 'ItCode / GOLD3   TagNo / K-TAG-3',
        clock: initialHeaders[0]!.clock,
        delete_date_set: true,
        delete_time_set: true,
      },
    ]);
  }, 30_000);

  it('covers one manufacturing process create/get/edit/persisted-date lock/delete against PostgreSQL', async () => {
    const mfgScope = scope(MFG_BOOK);
    const created = await issueMfg(runtime, {
      scope: mfgScope,
      partyAc: 'PARTY1',
      karigarAc: 'KRG1',
      vchDate: DAY,
      mainUser: MAIN_USER,
      lines: [
        {
          itCode: 'GOLD1',
          lotNo: 'LOT-1',
          pcs: 1,
          grossWt: 11,
          netWt: 10,
          touch: 90,
        },
      ],
    });
    const second = await issueMfg(runtime, {
      scope: mfgScope,
      partyAc: 'PARTY1',
      karigarAc: 'KRG1',
      vchDate: DAY,
      mainUser: MAIN_USER,
      lines: [{ itCode: 'GOLD1', lotNo: 'LOT-2', netWt: 4, touch: 90 }],
    });
    expect([created.vchNo, second.vchNo]).toEqual([1, 2]);

    const initialHeaders = await assertCreatedIdentities('MFG_DATA', MFG_BOOK);
    const opened = await getMfg(runtime, mfgScope, '00001');
    expect(opened).toMatchObject({
      voucherNo: '00001',
      hiddenVoucherNo: '00008',
      mainUser: MAIN_USER,
      vchDate: DAY,
      partyAc: 'PARTY1',
      karigarAc: 'KRG1',
      mode: 'issue',
      lines: [{ itCode: 'GOLD1', lotNo: 'LOT-1', netWt: 10 }],
    });

    await editMfg(runtime, {
      scope: mfgScope,
      vchNo: 1,
      mode: 'issue',
      partyAc: 'PARTY2',
      karigarAc: 'KRG2',
      vchDate: NEXT_DAY,
      mainUser: 'ignored-editor',
      lines: [
        {
          itCode: 'GOLD2',
          lotNo: 'LOT-EDIT-2',
          pcs: 2,
          grossWt: 10,
          netWt: 8,
          ghtWt: 1,
          touch: 91,
          westPct: 1,
        },
        {
          itCode: 'GOLD3',
          lotNo: 'LOT-EDIT-3',
          pcs: 1,
          grossWt: 6,
          netWt: 5,
          ghtWt: 0.5,
          touch: 89,
          westPct: 1,
        },
      ],
    });

    const edited = await getMfg(runtime, mfgScope, 1);
    expect(edited).toMatchObject({
      voucherNo: '00001',
      hiddenVoucherNo: '00008',
      mainUser: MAIN_USER,
      vchDate: NEXT_DAY,
      partyAc: 'PARTY2',
      karigarAc: 'KRG2',
      mode: 'issue',
      lines: [
        { itCode: 'GOLD2', lotNo: 'LOT-EDIT-2' },
        { itCode: 'GOLD3', lotNo: 'LOT-EDIT-3' },
      ],
    });
    const editedIdentity = (await owner.$queryRawUnsafe(
      `SELECT "HD_VCH_NO" hidden,"MAIN_USER" main_user,
              to_char("VCH_TIME",'HH24:MI:SS.MS') clock,
              (SELECT count(*)::int FROM "DELETE_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00001') audits
         FROM "MFG_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00001'`,
      TENANT,
      MFG_BOOK,
    )) as Array<Record<string, unknown>>;
    expect(editedIdentity[0]).toEqual({
      hidden: '00008',
      main_user: MAIN_USER,
      clock: initialHeaders[0]!.clock,
      audits: 0,
    });
    const mfgReplacement = (await owner.$queryRawUnsafe(
      `SELECT 'detail' source,"SR_NO","IT_CODE","ITM_NWT"::float
         FROM "MFG_DETL" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00001'
       UNION ALL
       SELECT 'stock' source,"SR_NO","IT_CODE","ITM_NWT"::float
         FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00001'
       ORDER BY source,"SR_NO"`,
      TENANT,
      MFG_BOOK,
    )) as Array<Record<string, unknown>>;
    expect(mfgReplacement).toEqual([
      { source: 'detail', SR_NO: 1, IT_CODE: 'GOLD2', ITM_NWT: 8 },
      { source: 'detail', SR_NO: 2, IT_CODE: 'GOLD3', ITM_NWT: 5 },
      { source: 'stock', SR_NO: 1, IT_CODE: 'GOLD2', ITM_NWT: 8 },
      { source: 'stock', SR_NO: 2, IT_CODE: 'GOLD3', ITM_NWT: 5 },
    ]);

    await owner.$executeRawUnsafe(
      `UPDATE "CO_SET" SET "LOCK_DATE"=$1 WHERE tenant_id=$2 AND "CO_CODE"=$3`,
      NEXT_DAY,
      TENANT,
      CO,
    );
    const beforeLockedEdit = await databaseSnapshot();
    await expect(
      editMfg(runtime, {
        scope: mfgScope,
        vchNo: 1,
        mode: 'issue',
        partyAc: 'PARTY1',
        vchDate: LOCKED_REQUEST_DAY,
        lines: [{ itCode: 'GOLD1', lotNo: 'LOCKED', netWt: 99, touch: 99 }],
      }),
    ).rejects.toBeInstanceOf(PeriodLockValidationError);
    expect(await databaseSnapshot()).toEqual(beforeLockedEdit);
    await unlock();

    await expect(
      deleteMfg(runtime, { scope: mfgScope, vchNo: 1, deleteUser: 'deleter' }),
    ).resolves.toEqual({ reversed: true });
    const removed = (await owner.$queryRawUnsafe(
      `SELECT
         (SELECT count(*)::int FROM "MFG_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00001') headers,
         (SELECT count(*)::int FROM "MFG_DETL" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00001') details,
         (SELECT count(*)::int FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00001') stock,
         (SELECT count(*)::int FROM "TEMP_BOOK_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00008') temp`,
      TENANT,
      MFG_BOOK,
    )) as Array<Record<string, unknown>>;
    expect(removed[0]).toEqual({ headers: 0, details: 0, stock: 0, temp: 0 });
    const audits = (await owner.$queryRawUnsafe(
      `SELECT "CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","VCH_DATE"::text,
              "VCH_TYPE","BOOK_NAME","AC_CODE","AC_NAME","VCH_VAL_DR","VCH_VAL_CR","FINE_TYPE",
              "VCH_FINE_DR"::float,"VCH_FINE_CR"::float,"HD_VCH_NO","MAIN_USER","DELETE_USER","VCH_DESC",
              to_char("VCH_TIME",'HH24:MI:SS.MS') clock,
              ("DELETE_DATE" IS NOT NULL) delete_date_set,("DELETE_TIME" IS NOT NULL) delete_time_set
         FROM "DELETE_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00001'`,
      TENANT,
      MFG_BOOK,
    )) as Array<Record<string, unknown>>;
    expect(audits).toEqual([
      {
        CO_CODE: CO,
        LC_CODE: LC,
        CO_YEAR: YEAR,
        CO_BOOK: MFG_BOOK,
        VCH_NO: '00001',
        SR_NO: 0,
        VCH_DATE: NEXT_DAY,
        VCH_TYPE: 'MFGI',
        BOOK_NAME: 'Mfg Process',
        AC_CODE: 'PARTY2',
        AC_NAME: 'Process Party Two',
        VCH_VAL_DR: 0,
        VCH_VAL_CR: 0,
        FINE_TYPE: 'A',
        VCH_FINE_DR: 0,
        VCH_FINE_CR: 0,
        HD_VCH_NO: '00008',
        MAIN_USER,
        DELETE_USER: 'deleter',
        VCH_DESC: '0',
        clock: initialHeaders[0]!.clock,
        delete_date_set: true,
        delete_time_set: true,
      },
    ]);
  }, 30_000);

  // Depth gate (Phase B): KR_IDTL is the karigar stone/diamond sub-detail. Desktop writes it via
  // TR_PURC's shared sub-detail block, which targets the KR_* family for MAIN_BOOK
  // 'KARIGAR RECEIPT' / 'OLD ITEM SALES' (TR_PURC.cs:11830-11845, row builder 13211-13243).
  // It was previously never written by the web.
  it('writes the karigar stone sub-detail and reverses it on delete', async () => {
    const karigarScope = scope(KARIGAR_BOOK);
    const created = await issueKarigar(runtime, {
      scope: karigarScope,
      karigarAc: 'KRG1',
      karigarName: 'Karigar One',
      vchDate: DAY,
      mainUser: MAIN_USER,
      lines: [
        {
          itCode: 'GOLD1',
          pcs: 1,
          grossWt: 13,
          netWt: 10,
          touch: 90,
          stones: [
            {
              itCode: 'DIA1',
              dmCode: 'DM1',
              dmName: 'Round Brilliant',
              dmColor: 'VS1',
              dmSize: '2.5MM',
              dmOrigin: 'NATURAL',
              dmRemark: 'centre',
              dmSfNo: 'SF-3',
              pcs: 4,
              grossWt: 0.6,
              conPct: 10,
              rateType: 'C',
              rate: 40_000,
              amount: 24_000,
              lbrRate: 120,
              lbrAmount: 480,
              netAmount: 24_480,
              conWt: 0.06,
              itType: 'D',
            },
            { isrNo: 5, itCode: 'DIA2', dmCode: 'DM2', pcs: 2, grossWt: 0.2, amount: 4_000 },
          ],
        },
      ],
    });
    const vchNo = String(created.vchNo).padStart(5, '0');

    const rows = (await owner.$queryRawUnsafe(
      `SELECT "SR_NO"::int sr_no,"ISR_NO"::int isr_no,"IT_CODE","DM_CODE","DM_NAME","DM_COLOR",
              "DM_SIZE","DM_ORIGIN","DM_REMARK","DM_SFNO","IT_PCS"::float it_pcs,
              "IT_GWT"::float it_gwt,"IT_CON_PRC"::float con_prc,"IT_RATE_TYPE",
              "IT_RATE"::float it_rate,"IT_AMT"::float it_amt,"IT_LBR_RATE"::float lbr_rate,
              "IT_LBR_AMT"::float lbr_amt,"IT_NET_AMT"::float net_amt,"IT_CON_WT"::float con_wt,
              "IT_TYPE","AC_CODE","ENTRY_TYPE","MAIN_USER"
         FROM "KR_IDTL" WHERE tenant_id=$1 AND "VCH_NO"=$2 ORDER BY "ISR_NO"`,
      TENANT,
      vchNo,
    )) as Array<Record<string, any>>;
    expect(rows).toHaveLength(2);

    const first = rows[0]!;
    expect(first.sr_no).toBe(1);
    expect(first.isr_no).toBe(1);
    expect(String(first.IT_CODE).trim()).toBe('DIA1');
    expect(String(first.DM_CODE).trim()).toBe('DM1');
    expect(String(first.DM_NAME).trim()).toBe('Round Brilliant');
    expect(String(first.DM_COLOR).trim()).toBe('VS1');
    expect(String(first.DM_SIZE).trim()).toBe('2.5MM');
    expect(String(first.DM_ORIGIN).trim()).toBe('NATURAL');
    expect(String(first.DM_REMARK).trim()).toBe('centre');
    expect(String(first.DM_SFNO).trim()).toBe('SF-3');
    expect(first.it_pcs).toBe(4);
    expect(first.it_gwt).toBeCloseTo(0.6, 3);
    expect(first.con_prc).toBeCloseTo(10, 2);
    expect(String(first.IT_RATE_TYPE).trim()).toBe('C');
    expect(first.it_rate).toBeCloseTo(40_000, 2);
    expect(first.it_amt).toBeCloseTo(24_000, 2);
    expect(first.lbr_rate).toBeCloseTo(120, 2);
    expect(first.lbr_amt).toBeCloseTo(480, 2);
    expect(first.net_amt).toBeCloseTo(24_480, 2);
    expect(first.con_wt).toBeCloseTo(0.06, 3);
    expect(String(first.IT_TYPE).trim()).toBe('D');
    expect(String(first.AC_CODE).trim()).toBe('KRG1');
    expect(String(first.ENTRY_TYPE).trim()).toBe('P');
    expect(String(first.MAIN_USER).trim()).toBe(MAIN_USER);
    // An explicit ISR_NO is honoured rather than renumbered.
    expect(rows[1]!.isr_no).toBe(5);

    await deleteKarigar(runtime, {
      scope: karigarScope,
      vchNo: created.vchNo,
      deleteUser: 'deleter',
      // No karigar account here: DeleteKarigarInput does not accept one, so the value passed previously was
      // silently discarded. The delete identifies the voucher by scope and number, which is what the desktop
      // does too. Surfaced by typechecking the test project.
    });
    const after = (await owner.$queryRawUnsafe(
      `SELECT count(*)::int n FROM "KR_IDTL" WHERE tenant_id=$1 AND "VCH_NO"=$2`,
      TENANT,
      vchNo,
    )) as Array<{ n: number }>;
    expect(after[0]!.n).toBe(0);
  }, 30_000);

  // Depth gate (Phase B): the karigar-receipt book is served by TR_PURC's shared header/detail
  // blocks (TR_PURC.cs:12960-13069 header, 13096-13188 detail), so KR_DATA carries the bill/party/
  // tender/tax columns and KR_DETL the purchase-grid columns.
  it('persists the desktop karigar header and line columns', async () => {
    const karigarScope = scope(KARIGAR_BOOK);
    const created = await issueKarigar(runtime, {
      scope: karigarScope,
      karigarAc: 'KRG1',
      karigarName: 'Karigar One',
      vchDate: DAY,
      mainUser: MAIN_USER,
      billNo: 'KB-9',
      itemType: 'G',
      vchDesc: 'issue against sale bill',
      empCode: 'E01',
      address1: 'Workshop 4',
      address2: 'Lane 2',
      address3: 'Rear block',
      city: 'Ahmedabad',
      mobile: '9800011122',
      bankName: 'HDFC',
      bankAc: 'BANKAC',
      chequeNo: 'CQ-1',
      chequeAmount: 500,
      cardAc: 'CARDAC',
      cardAmount: 250,
      cashAmount: 100,
      kasarAmount: 5,
      billOutstanding: 750,
      creditDays: 15,
      discountPct: 1,
      discountAmount: 20,
      otherAmount: 35,
      taxCode: 'G3',
      taxRatePct: 3,
      taxAmount: 45,
      tcsCode: 'T1',
      tcsPct: 0.1,
      tcsAmount: 2.5,
      accountGstType: 'L',
      saleBillNo: 'SB-21',
      saleBillBook: 'SAL',
      lines: [
        {
          itCode: 'GOLD1',
          pcs: 1,
          grossWt: 12,
          netWt: 10,
          touch: 90,
          lotNo: 'LOT-5',
          withStock: 'Y',
          bagWt: 0.4,
          lossWt: 0.2,
          lessTouch: 1.5,
          convRate: 6_100,
          convPct: 2.5,
          rate: 6_200,
          amount: 62_000,
          otherRate: 12,
          otherFine: 0.4,
          mrp: 70_000,
          totalAmount: 62_500,
          taxRatePct: 3,
          rateType: 'R',
          oldSrNo: 9,
        },
      ],
    });
    const vchNo = String(created.vchNo).padStart(5, '0');

    const heads = (await owner.$queryRawUnsafe(
      `SELECT "BILL_NO","IT_TYPE","VCH_DESC","EMP_CODE","ADD1","ADD2","ADD3","CITY","MOBILE",
              "BANK_NAME","BANK_AC","CHQ_NO","CARD_AC","TAX_CODE","TCS_CODE","AC_GST_TYPE",
              "SL_BILL_NO","SL_BILL_DBCD","DATA_TRFR",
              "CHQ_AMT"::float chq,"CARD_AMT"::float card,"CASH_AMT"::float cash,
              "KASAR_AMT"::float kasar,"BILL_OS"::float bill_os,"CR_DAYS"::float cr_days,
              "DISC_PRC"::float disc_prc,"DISC_AMT"::float disc_amt,"OTH_AMT"::float oth,
              "TAX_PRC"::float tax_prc,"TAX_AMT"::float tax_amt,"TCS_PRC"::float tcs_prc,
              "TCS_AMT"::float tcs_amt,"ROF_AMT"::float rof
         FROM "KR_DATA" WHERE tenant_id=$1 AND "VCH_NO"=$2`,
      TENANT,
      vchNo,
    )) as Array<Record<string, any>>;
    expect(heads).toHaveLength(1);
    const h = heads[0]!;
    expect(String(h.BILL_NO).trim()).toBe('KB-9');
    expect(String(h.IT_TYPE).trim()).toBe('G');
    expect(String(h.VCH_DESC).trim()).toBe('issue against sale bill');
    expect(String(h.EMP_CODE).trim()).toBe('E01');
    expect(String(h.ADD1).trim()).toBe('Workshop 4');
    expect(String(h.CITY).trim()).toBe('Ahmedabad');
    expect(String(h.MOBILE).trim()).toBe('9800011122');
    expect(String(h.BANK_NAME).trim()).toBe('HDFC');
    expect(String(h.BANK_AC).trim()).toBe('BANKAC');
    expect(String(h.CHQ_NO).trim()).toBe('CQ-1');
    expect(String(h.TAX_CODE).trim()).toBe('G3');
    expect(String(h.AC_GST_TYPE).trim()).toBe('L');
    expect(String(h.SL_BILL_NO).trim()).toBe('SB-21');
    expect(String(h.SL_BILL_DBCD).trim()).toBe('SAL');
    expect(String(h.DATA_TRFR).trim()).toBe('N');
    expect(h.chq).toBeCloseTo(500, 2);
    expect(h.card).toBeCloseTo(250, 2);
    expect(h.cash).toBeCloseTo(100, 2);
    expect(h.kasar).toBeCloseTo(5, 2);
    expect(h.bill_os).toBeCloseTo(750, 2);
    expect(h.cr_days).toBe(15);
    expect(h.disc_prc).toBeCloseTo(1, 2);
    expect(h.disc_amt).toBeCloseTo(20, 2);
    expect(h.tax_amt).toBeCloseTo(45, 2);
    expect(h.tcs_amt).toBeCloseTo(2.5, 2);
    expect(h.rof).toBe(0);

    const dets = (await owner.$queryRawUnsafe(
      `SELECT "BOOK_NAME","LOT_NO","WITH_STOCK","RATE_TYPE","SL_BILL_NO","SL_BILL_DBCD",
              "OLD_SRNO"::int old_srno,"BAG_WT"::float bag,"ITM_LOSS_WT"::float loss,
              "ITM_LESS_TCH"::float less_tch,"CONV_RATE"::float conv_rate,
              "CONV_PRC"::float conv_prc,"ITM_RATE"::float rate,"ITM_AMT"::float amt,
              "ITM_OTH_RATE"::float oth_rate,"ITM_OTH_FINE"::float oth_fine,"ITM_MRP"::float mrp,
              "TOT_AMT"::float tot,"TAX_PRC"::float tax_prc,"TAG_COST"::float tag_cost,
              "VCH_SRNO"::int vch_srno
         FROM "KR_DETL" WHERE tenant_id=$1 AND "VCH_NO"=$2 ORDER BY "SR_NO"`,
      TENANT,
      vchNo,
    )) as Array<Record<string, any>>;
    expect(dets).toHaveLength(1);
    const d = dets[0]!;
    expect(String(d.LOT_NO).trim()).toBe('LOT-5');
    expect(String(d.WITH_STOCK).trim()).toBe('Y');
    expect(String(d.RATE_TYPE).trim()).toBe('R');
    expect(String(d.SL_BILL_NO).trim()).toBe('SB-21');
    expect(String(d.SL_BILL_DBCD).trim()).toBe('SAL');
    expect(d.old_srno).toBe(9); // explicit OLD_SRNO honoured
    expect(d.bag).toBeCloseTo(0.4, 3);
    expect(d.loss).toBeCloseTo(0.2, 3);
    expect(d.less_tch).toBeCloseTo(1.5, 2);
    expect(d.conv_rate).toBeCloseTo(6_100, 2);
    expect(d.conv_prc).toBeCloseTo(2.5, 2);
    expect(d.rate).toBeCloseTo(6_200, 2);
    expect(d.amt).toBeCloseTo(62_000, 2);
    expect(d.oth_rate).toBeCloseTo(12, 2);
    expect(d.oth_fine).toBeCloseTo(0.4, 2);
    expect(d.mrp).toBeCloseTo(70_000, 2);
    expect(d.tot).toBeCloseTo(62_500, 2);
    expect(d.tax_prc).toBeCloseTo(3, 2);
    // Desktop literals on this block.
    expect(d.tag_cost).toBe(0);
    expect(d.vch_srno).toBe(0);
  }, 30_000);
});
