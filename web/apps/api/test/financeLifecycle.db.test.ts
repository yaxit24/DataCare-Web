import { PrismaClient } from '@prisma/client';
import { afterAll, beforeAll, beforeEach, describe, expect, it } from 'vitest';
import {
  deleteEmployeeJv,
  editEmployeeJv,
  getEmployeeJv,
  postEmployeeJv,
} from '../src/modules/finance/employeeJv.js';
import { deleteFineJv, editFineJv, getFineJv, postFineJv } from '../src/modules/finance/fineJv.js';
import {
  deleteJournal,
  editJournal,
  getJournal,
  postJournal,
} from '../src/modules/finance/journal.js';
import {
  deleteLedgerAdjust,
  editLedgerAdjust,
  getLedgerAdjust,
  postLedgerAdjust,
} from '../src/modules/finance/ledgerAdjust.js';
import { PeriodLockValidationError } from '../src/modules/posting/posting.js';
import type { VoucherScope } from '../src/modules/vouchers/numbering.js';

const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const databaseDescribe = RUN ? describe : describe.skip;
const TENANT = 'finance-lifecycle-db';
const CO = '01';
const LC = '01';
const YEAR = '2024-2025';
const DAY = '2024-04-10';
const EDIT_DAY = '2024-04-11';

type Engine = {
  name: string;
  book: string;
  table: 'EMP_DATA' | 'LDR_ADJ_DATA' | 'CONTRA_DATA';
  sourceRowsAfterEdit: number;
  deleteAudits: number;
  input: (scope: VoucherScope, mainUser: string, replacement?: boolean) => any;
  create: (prisma: PrismaClient, input: any) => Promise<{ vchNo: number }>;
  get: (prisma: PrismaClient, scope: VoucherScope, vchNo: number) => Promise<any>;
  edit: (prisma: PrismaClient, input: any, vchNo: number) => Promise<unknown>;
  remove: (prisma: PrismaClient, scope: VoucherScope, vchNo: number) => Promise<unknown>;
  initialGet: Record<string, unknown>;
  editedGet: Record<string, unknown>;
  editedRows: Array<Record<string, unknown>>;
  auditRows: Array<Record<string, unknown>>;
};

const scopeFor = (book: string): VoucherScope => ({
  tenantId: TENANT,
  coCode: CO,
  lcCode: LC,
  coYear: YEAR,
  coBook: book,
});

const engines: Engine[] = [
  {
    name: 'employee JV',
    book: 'EJV',
    table: 'EMP_DATA',
    sourceRowsAfterEdit: 1,
    deleteAudits: 0,
    input: (scope, mainUser, replacement = false) => ({
      scope,
      mainUser,
      vchDate: replacement ? EDIT_DAY : DAY,
      empAc: replacement ? 'EMP2' : 'EMP1',
      empName: replacement ? 'Replacement Employee' : 'Employee One',
      paidAc: 'CASH',
      salaryAmt: replacement ? 1200 : 1000,
      tdsAmt: replacement ? 100 : 50,
      pfAmt: replacement ? 100 : 50,
      desc: replacement ? 'Replacement salary' : 'Salary',
    }),
    create: postEmployeeJv,
    get: getEmployeeJv,
    edit: editEmployeeJv,
    remove: (prisma, scope, vchNo) => deleteEmployeeJv(prisma, { scope, vchNo }),
    initialGet: { empAc: 'EMP1', salaryAmt: 1000, tdsAmt: 50, pfAmt: 50 },
    editedGet: {
      empAc: 'EMP2',
      salaryAmt: 1200,
      tdsAmt: 100,
      pfAmt: 100,
      desc: 'Replacement salary',
    },
    editedRows: [{ AC_CODE: 'EMP2', SALARY_AMT: '1200' }],
    auditRows: [],
  },
  {
    name: 'ledger adjustment',
    book: 'LAD',
    table: 'LDR_ADJ_DATA',
    sourceRowsAfterEdit: 1,
    deleteAudits: 0,
    input: (scope, mainUser, replacement = false) => ({
      scope,
      mainUser,
      vchDate: replacement ? EDIT_DAY : DAY,
      acCode: replacement ? 'LEDGER2' : 'LEDGER1',
      adjAc: 'KASAR',
      amount: replacement ? 275 : 125,
      direction: replacement ? 'credit' : 'debit',
      remark: replacement ? 'Replacement adjustment' : 'Adjustment',
    }),
    create: postLedgerAdjust,
    get: getLedgerAdjust,
    edit: editLedgerAdjust,
    remove: (prisma, scope, vchNo) => deleteLedgerAdjust(prisma, { scope, vchNo }),
    initialGet: { acCode: 'LEDGER1', amount: 125, direction: 'debit' },
    editedGet: {
      acCode: 'LEDGER2',
      amount: 275,
      direction: 'credit',
      remark: 'Replacement adjustment',
    },
    editedRows: [{ AC_CODE: 'LEDGER2', DIFF_AMT: '275' }],
    auditRows: [],
  },
  {
    name: 'journal book',
    book: 'JRN',
    table: 'CONTRA_DATA',
    sourceRowsAfterEdit: 3,
    deleteAudits: 3,
    input: (scope, mainUser, replacement = false) => ({
      scope,
      mainUser,
      vchDate: replacement ? EDIT_DAY : DAY,
      narration: replacement ? 'Replacement journal' : 'Journal',
      lines: replacement
        ? [
            { acCode: 'JDR1', drAmt: 120, desc: 'Debit one' },
            { acCode: 'JDR2', drAmt: 30, desc: 'Debit two' },
            { acCode: 'JCR1', crAmt: 150, desc: 'Credit one' },
          ]
        : [
            { acCode: 'JDR1', drAmt: 100 },
            { acCode: 'JCR1', crAmt: 100 },
          ],
    }),
    create: postJournal,
    get: getJournal,
    edit: editJournal,
    remove: (prisma, scope, vchNo) =>
      deleteJournal(prisma, { scope, vchNo, deleteUser: 'delete-user' }),
    initialGet: {
      narration: 'Journal',
      lines: [
        { acCode: 'JDR1', drAmt: 100, crAmt: 0, desc: 'Journal' },
        { acCode: 'JCR1', drAmt: 0, crAmt: 100, desc: 'Journal' },
      ],
    },
    editedGet: {
      lines: [
        { acCode: 'JDR1', drAmt: 120, crAmt: 0, desc: 'Debit one' },
        { acCode: 'JDR2', drAmt: 30, crAmt: 0, desc: 'Debit two' },
        { acCode: 'JCR1', drAmt: 0, crAmt: 150, desc: 'Credit one' },
      ],
    },
    editedRows: [
      { AC_CODE: 'JDR1', DR_AMT: '120', CR_AMT: '0' },
      { AC_CODE: 'JDR2', DR_AMT: '30', CR_AMT: '0' },
      { AC_CODE: 'JCR1', DR_AMT: '0', CR_AMT: '150' },
    ],
    auditRows: [
      { AC_CODE: 'JDR1', VCH_VAL_DR: 120, VCH_VAL_CR: 0, VCH_DESC: 'Debit one' },
      { AC_CODE: 'JDR2', VCH_VAL_DR: 30, VCH_VAL_CR: 0, VCH_DESC: 'Debit two' },
      { AC_CODE: 'JCR1', VCH_VAL_DR: 0, VCH_VAL_CR: 150, VCH_DESC: 'Credit one' },
    ],
  },
  {
    name: 'fine JV',
    book: 'FJV',
    table: 'CONTRA_DATA',
    sourceRowsAfterEdit: 2,
    deleteAudits: 2,
    input: (scope, mainUser, replacement = false) => ({
      scope,
      mainUser,
      vchDate: replacement ? EDIT_DAY : DAY,
      fromAc: replacement ? 'GOLD2' : 'GOLD1',
      toAc: replacement ? 'PARTY2' : 'PARTY1',
      fineWt: replacement ? 2.75 : 1.25,
      metal: replacement ? 'S' : 'G',
    }),
    create: postFineJv,
    get: getFineJv,
    edit: editFineJv,
    remove: (prisma, scope, vchNo) =>
      deleteFineJv(prisma, { scope, vchNo, deleteUser: 'delete-user' }),
    initialGet: { fromAc: 'GOLD1', toAc: 'PARTY1', fineWt: 1.25, metal: 'G' },
    editedGet: { fromAc: 'GOLD2', toAc: 'PARTY2', fineWt: 2.75, metal: 'S' },
    editedRows: [
      { AC_CODE: 'PARTY2', LD_CODE: 'GOLD2', DR_FINE: '2.75', CR_FINE: '0' },
      { AC_CODE: 'GOLD2', LD_CODE: 'PARTY2', DR_FINE: '0', CR_FINE: '2.75' },
    ],
    auditRows: [
      { AC_CODE: 'PARTY2', FINE_TYPE: 'S', VCH_FINE_DR: '2.75', VCH_FINE_CR: '0' },
      { AC_CODE: 'GOLD2', FINE_TYPE: 'S', VCH_FINE_DR: '0', VCH_FINE_CR: '2.75' },
    ],
  },
];

databaseDescribe('database-backed finance voucher lifecycles', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;

  const cleanup = async (): Promise<void> => {
    for (const table of [
      'DELETE_DATA',
      'AC_DATA',
      'EMP_DATA',
      'LDR_ADJ_DATA',
      'CONTRA_DATA',
      // Its PK is LEDR_KEY alone, so a leftover row makes a reused voucher number collide (23505).
      'ROJ_MEL_DATA',
      'TEMP_BOOK_DATA',
      'BOOK_DATA',
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
    for (const [book, name, shortName, table] of [
      ['EJV', 'Employee JV', 'EJV', 'EMP_DATA'],
      ['LAD', 'Ledger Adjustment', 'LAD', 'LDR_ADJ_DATA'],
      ['JRN', 'Journal Book', 'JRN', 'CONTRA_DATA'],
      ['FJV', 'Fine JV', 'FJV', 'CONTRA_DATA'],
    ]) {
      await owner.$executeRawUnsafe(
        `INSERT INTO "BOOK_DATA"(
           tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME","MAIN_BOOK",
           "CUR_USE","BOOK_TBL_NAME") VALUES ($1,$2,$3,$4,$5,$6,$5,'Y',$7)`,
        TENANT,
        CO,
        LC,
        book,
        name,
        shortName,
        table,
      );
      await owner.$executeRawUnsafe(
        `INSERT INTO "TEMP_BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","VCH_NO","BOOK_NAME")
         VALUES ($1,$2,$3,$4,'00040',$5)`,
        TENANT,
        CO,
        LC,
        book,
        name,
      );
    }
    await owner.$executeRawUnsafe(
      `INSERT INTO "EMP_DATA"(
         tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","VCH_DATE")
       VALUES ($1,$2,$3,$4,'EJV','00007',1,$5::date)`,
      TENANT,
      CO,
      LC,
      YEAR,
      DAY,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "LDR_ADJ_DATA"(
         tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","VCH_DATE")
       VALUES ($1,$2,$3,$4,'LAD','00007',1,$5::date)`,
      TENANT,
      CO,
      LC,
      YEAR,
      DAY,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "CONTRA_DATA"(
         tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","VCH_DATE")
       VALUES ($1,$2,$3,$4,'JRN','00007',1,$5::date),
              ($1,$2,$3,$4,'FJV','00007',1,$5::date)`,
      TENANT,
      CO,
      LC,
      YEAR,
      DAY,
    );
  };

  const header = async (engine: Engine, vchNo = '00008') =>
    (
      (await owner.$queryRawUnsafe(
        `SELECT "VCH_NO","HD_VCH_NO","MAIN_USER","VCH_TIME"::date::text time_date,
                to_char("VCH_TIME",'HH24:MI:SS.MS') clock,count(*) OVER ()::int rows
           FROM "${engine.table}"
          WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4
            AND "CO_BOOK"=$5 AND "VCH_NO"=$6 ORDER BY "SR_NO" LIMIT 1`,
        TENANT,
        CO,
        LC,
        YEAR,
        engine.book,
        vchNo,
      )) as Array<Record<string, unknown>>
    )[0];

  const sourceRows = async (engine: Engine, vchNo = '00008') =>
    (await owner.$queryRawUnsafe(
      `SELECT * FROM "${engine.table}"
        WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4
          AND "CO_BOOK"=$5 AND "VCH_NO"=$6 ORDER BY "SR_NO"`,
      TENANT,
      CO,
      LC,
      YEAR,
      engine.book,
      vchNo,
    )) as Array<Record<string, unknown>>;

  const state = async (engine: Engine, vchNo = '00008', hiddenNo = '00041') =>
    (
      (await owner.$queryRawUnsafe(
        `SELECT
          (SELECT count(*)::int FROM "${engine.table}" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3) source,
          (SELECT count(*)::int FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3) ledger,
          (SELECT count(*)::int FROM "TEMP_BOOK_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$4) temp,
          (SELECT count(*)::int FROM "DELETE_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3) audits`,
        TENANT,
        engine.book,
        vchNo,
        hiddenNo,
      )) as Array<{ source: number; ledger: number; temp: number; audits: number }>
    )[0]!;

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

  for (const engine of engines) {
    it(`${engine.name}: creates, gets, edits, locks, balances and deletes with desktop audit parity`, async () => {
      const scope = scopeFor(engine.book);
      const first = await engine.create(runtime, engine.input(scope, 'original-user'));
      const second = await engine.create(runtime, engine.input(scope, 'second-user'));
      expect([first.vchNo, second.vchNo]).toEqual([8, 9]);

      const persisted = header(engine);
      const secondPersisted = header(engine, '00009');
      await expect(persisted).resolves.toMatchObject({
        VCH_NO: '00008',
        HD_VCH_NO: '00041',
        MAIN_USER: 'original-user',
        time_date: DAY,
      });
      await expect(secondPersisted).resolves.toMatchObject({
        VCH_NO: '00009',
        HD_VCH_NO: '00042',
        MAIN_USER: 'second-user',
      });
      const originalClock = String((await persisted)?.clock);
      expect(await state(engine)).toMatchObject({ temp: 1 });

      await expect(engine.get(runtime, scope, first.vchNo)).resolves.toMatchObject({
        voucherNo: '00008',
        hiddenVoucherNo: '00041',
        mainUser: 'original-user',
        vchDate: DAY,
        ...engine.initialGet,
      });

      await expect(
        engine.edit(runtime, engine.input(scope, 'different-user', true), first.vchNo),
      ).resolves.toMatchObject({ vchNo: 8 });
      expect(await header(engine)).toMatchObject({
        HD_VCH_NO: '00041',
        MAIN_USER: 'original-user',
        clock: originalClock,
        time_date: EDIT_DAY,
        rows: engine.sourceRowsAfterEdit,
      });
      expect(await engine.get(runtime, scope, first.vchNo)).toMatchObject(engine.editedGet);
      const replaced = await sourceRows(engine);
      expect(replaced).toHaveLength(engine.sourceRowsAfterEdit);
      engine.editedRows.forEach((row, index) => {
        for (const [column, expected] of Object.entries(row)) {
          expect(String(replaced[index]?.[column] ?? '')).toBe(String(expected));
        }
      });
      expect((await state(engine)).audits).toBe(0);

      const balance = (
        (await owner.$queryRawUnsafe(
          `SELECT coalesce(sum("DR_AMT"),0)::float dr,coalesce(sum("CR_AMT"),0)::float cr
             FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3
              AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"='00008'`,
          TENANT,
          CO,
          LC,
          YEAR,
          engine.book,
        )) as Array<{ dr: number; cr: number }>
      )[0]!;
      expect(balance.dr).toBe(balance.cr);

      const lockedBefore = await engine.get(runtime, scope, second.vchNo);
      const lockedStateBefore = await state(engine, '00009', '00042');
      await owner.$executeRawUnsafe(
        `UPDATE "CO_SET" SET "LOCK_DATE"=$1::date WHERE tenant_id=$2 AND "CO_CODE"=$3`,
        DAY,
        TENANT,
        CO,
      );
      await expect(
        engine.edit(runtime, engine.input(scope, 'attacker', true), second.vchNo),
      ).rejects.toBeInstanceOf(PeriodLockValidationError);
      expect(await engine.get(runtime, scope, second.vchNo)).toEqual(lockedBefore);
      expect(await state(engine, '00009', '00042')).toEqual(lockedStateBefore);

      await owner.$executeRawUnsafe(
        `UPDATE "CO_SET" SET "LOCK_DATE"=NULL WHERE tenant_id=$1 AND "CO_CODE"=$2`,
        TENANT,
        CO,
      );
      await expect(engine.remove(runtime, scope, first.vchNo)).resolves.toEqual({ reversed: true });
      expect(await state(engine)).toEqual({
        source: 0,
        ledger: 0,
        temp: 0,
        audits: engine.deleteAudits,
      });

      // Desktop grep evidence (unified/src/csharp/DataCareNext):
      // TR_EMP_JV.cs=0, TR_LEDR_ADJ.cs=0, TR_CONTRA.cs=1 INSERT INTO DELETE_DATA.
      // TR_CONTRA's one INSERT ... SELECT maps every CONTRA_DATA row to one audit row.
      const audits = (await owner.$queryRawUnsafe(
        `SELECT "AC_CODE","VCH_VAL_DR","VCH_VAL_CR","FINE_TYPE","VCH_FINE_DR","VCH_FINE_CR",
                "HD_VCH_NO","MAIN_USER","DELETE_USER","VCH_DESC"
           FROM "DELETE_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00008'
          ORDER BY "SR_NO"`,
        TENANT,
        engine.book,
      )) as Array<Record<string, unknown>>;
      expect(audits).toHaveLength(engine.deleteAudits);
      engine.auditRows.forEach((row, index) => {
        const expected = {
          ...row,
          HD_VCH_NO: '00041',
          MAIN_USER: 'original-user',
          DELETE_USER: 'delete-user',
        };
        for (const [column, value] of Object.entries(expected)) {
          expect(String(audits[index]?.[column] ?? '')).toBe(String(value));
        }
      });
    }, 30_000);
  }
});
