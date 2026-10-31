import { PrismaClient } from '@datacare/db';
import { afterAll, beforeAll, beforeEach, describe, expect, it } from 'vitest';
import {
  deleteEmployeeJv,
  editEmployeeJv,
  getEmployeeJv,
  postEmployeeJv,
} from '../src/modules/finance/employeeJv.js';
import { deleteFineJv, editFineJv, getFineJv, postFineJv } from '../src/modules/finance/fineJv.js';
import { deleteContra, editContra, getContra, postContra } from '../src/modules/finance/contra.js';
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
  verifyAfterEdit?: (owner: PrismaClient, scope: VoucherScope, voucherNo: string) => Promise<void>;
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
      metal: replacement ? 'S' : 'G',
      // TR_CONTRA.cs:1530-1543: grid row 1 (the giving account) is DR and its counter row is CR.
      lines: replacement
        ? [
            { crdr: 'DR', acCode: 'GOLD2', fine: 2.75 },
            { crdr: 'CR', acCode: 'PARTY2', fine: 2.75 },
          ]
        : [
            { crdr: 'DR', acCode: 'GOLD1', fine: 1.25 },
            { crdr: 'CR', acCode: 'PARTY1', fine: 1.25 },
          ],
    }),
    create: postFineJv,
    get: getFineJv,
    edit: editFineJv,
    remove: (prisma, scope, vchNo) =>
      deleteFineJv(prisma, { scope, vchNo, deleteUser: 'delete-user' }),
    initialGet: {
      metal: 'G',
      lines: [
        { crdr: 'DR', acCode: 'GOLD1', acName: 'Gold One', itDesc: '', fine: 1.25 },
        { crdr: 'CR', acCode: 'PARTY1', acName: 'Party One', itDesc: '', fine: 1.25 },
      ],
    },
    editedGet: {
      metal: 'S',
      lines: [
        { crdr: 'DR', acCode: 'GOLD2', acName: 'Gold Two', itDesc: '', fine: 2.75 },
        { crdr: 'CR', acCode: 'PARTY2', acName: 'Party Two', itDesc: '', fine: 2.75 },
      ],
    },
    editedRows: [
      // Desktop TR_CONTRA.cs:2760-2847: the From account is the primary DR grid row. Its To
      // counter-row is persisted first (LDR_TYPE 0) with CR_FINE, then the primary From row is
      // mirrored (LDR_TYPE 1) with DR_FINE. Ac_Ledr.cs:846-848 and Ac_Rojmel.cs:342-344 use
      // those columns to preserve the receiving + and giving - effects.
      {
        AC_CODE: 'PARTY2',
        LD_CODE: 'GOLD2',
        CR_FINE: '2.75',
        DR_FINE: '0',
        CRDR_TYPE: 'CR',
        LDR_TYPE: '0',
      },
      {
        AC_CODE: 'GOLD2',
        LD_CODE: 'PARTY2',
        CR_FINE: '0',
        DR_FINE: '2.75',
        CRDR_TYPE: 'DR',
        LDR_TYPE: '1',
      },
    ],
    auditRows: [
      { AC_CODE: 'PARTY2', FINE_TYPE: 'S', VCH_FINE_DR: '0', VCH_FINE_CR: '2.75' },
      { AC_CODE: 'GOLD2', FINE_TYPE: 'S', VCH_FINE_DR: '2.75', VCH_FINE_CR: '0' },
    ],
    verifyAfterEdit: async (owner, scope, voucherNo) => {
      const params = [
        scope.tenantId,
        scope.coCode,
        scope.lcCode,
        scope.coYear,
        scope.coBook,
        voucherNo,
      ];
      const ledger = (await owner.$queryRawUnsafe(
        `SELECT "AC_CODE" ac,"LD_CODE" ld,"SIGN" sign,"IT_TYPE" metal,"FINE_WT"::float fine,
                "DR_AMT"::float dr,"CR_AMT"::float cr
           FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4
             AND "CO_BOOK"=$5 AND "VCH_NO"=$6 ORDER BY "AC_CODE"`,
        ...params,
      )) as Array<Record<string, unknown>>;
      const rojmel = (await owner.$queryRawUnsafe(
        `SELECT "AC_CODE" ac,"LD_CODE" ld,"SIGN" sign,"IT_TYPE" metal,"ITM_FINE"::float fine,
                "DR_AMT"::float dr,"CR_AMT"::float cr,"ITM_GWT"::float gwt
           FROM "ROJ_MEL_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4
             AND "CO_BOOK"=$5 AND "VCH_NO"=$6 ORDER BY "AC_CODE"`,
        ...params,
      )) as Array<Record<string, unknown>>;
      expect(ledger).toEqual([
        { ac: 'GOLD2', ld: 'PARTY2', sign: '-', metal: 'S', fine: 2.75, dr: 0, cr: 0 },
        { ac: 'PARTY2', ld: 'GOLD2', sign: '+', metal: 'S', fine: 2.75, dr: 0, cr: 0 },
      ]);
      expect(rojmel).toEqual([
        { ac: 'GOLD2', ld: 'PARTY2', sign: '-', metal: 'S', fine: 2.75, dr: 0, cr: 0, gwt: 0 },
        { ac: 'PARTY2', ld: 'GOLD2', sign: '+', metal: 'S', fine: 2.75, dr: 0, cr: 0, gwt: 0 },
      ]);
    },
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
      'REMARK_DATA',
      'BOOK_DATA',
      'AC_MAST',
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
    // TR_CONTRA.cs:2680-2685 refuses a date outside the company's current year (YEAR_MAST).
    await owner.$executeRawUnsafe(
      `INSERT INTO "YEAR_MAST"(tenant_id,"CO_CODE","CO_YEAR","OP_DATE","CL_DATE")
       VALUES ($1,$2,$3,'2024-04-01','2025-03-31')`,
      TENANT,
      CO,
      YEAR,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME")
       VALUES ($1,$2,$3,'GOLD1','Gold One'),($1,$2,$3,'PARTY1','Party One'),
              ($1,$2,$3,'GOLD2','Gold Two'),($1,$2,$3,'PARTY2','Party Two')`,
      TENANT,
      CO,
      LC,
    );
    for (const [book, name, shortName, table, mainBook] of [
      ['EJV', 'Employee JV', 'EJV', 'EMP_DATA', 'Employee JV'],
      ['LAD', 'Ledger Adjustment', 'LAD', 'LDR_ADJ_DATA', 'Ledger Adjustment'],
      ['JRN', 'Journal Book', 'JRN', 'CONTRA_DATA', 'JOURNAL'],
      ['FJV', 'Fine JV', 'FJV', 'CONTRA_DATA', 'FINE JV'],
    ]) {
      await owner.$executeRawUnsafe(
        `INSERT INTO "BOOK_DATA"(
           tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME","MAIN_BOOK",
           "CUR_USE","BOOK_TBL_NAME") VALUES ($1,$2,$3,$4,$5,$6,$8,'Y',$7)`,
        TENANT,
        CO,
        LC,
        book,
        name,
        shortName,
        table,
        mainBook,
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
    // Ac_Ledr.Contra_Ledr accepts Fine JV source rows only from an inward FINE JV book (line 846).
    await owner.$executeRawUnsafe(
      `UPDATE "BOOK_DATA" SET "BOOK_INOUT"='I'
        WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_BOOK"='FJV'`,
      TENANT,
      CO,
      LC,
    );
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
      await engine.verifyAfterEdit?.(owner, scope, '00008');
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

  it('fine JV refuses another book family before allocating any business rows', async () => {
    const scope = scopeFor('JRN');
    const before = await state({ table: 'CONTRA_DATA', book: 'JRN' } as Engine, '00008', '00041');
    await expect(
      postFineJv(runtime, {
        scope,
        lines: [
          { crdr: 'DR', acCode: 'GOLD1', fine: 1.25 },
          { crdr: 'CR', acCode: 'PARTY1', fine: 1.25 },
        ],
        metal: 'G',
        vchDate: DAY,
        mainUser: 'wrong-book-user',
      }),
    ).rejects.toThrow('FINE JV');
    expect(await state({ table: 'CONTRA_DATA', book: 'JRN' } as Engine, '00008', '00041')).toEqual(
      before,
    );
  });
  it('fine JV refuses an outward FINE JV book before allocating any business rows', async () => {
    const scope = scopeFor('JRN');
    await owner.$executeRawUnsafe(
      `UPDATE "BOOK_DATA" SET "MAIN_BOOK"='FINE JV',"BOOK_INOUT"='O'
        WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_BOOK"='JRN'`,
      TENANT,
      CO,
      LC,
    );
    const before = await state({ table: 'CONTRA_DATA', book: 'JRN' } as Engine, '00008', '00041');
    await expect(
      postFineJv(runtime, {
        scope,
        lines: [
          { crdr: 'DR', acCode: 'GOLD1', fine: 1.25 },
          { crdr: 'CR', acCode: 'PARTY1', fine: 1.25 },
        ],
        metal: 'G',
        vchDate: DAY,
        mainUser: 'wrong-dir',
      }),
    ).rejects.toThrow('inward');
    expect(await state({ table: 'CONTRA_DATA', book: 'JRN' } as Engine, '00008', '00041')).toEqual(
      before,
    );
  });
  it('contra and journal services refuse a FINE JV book before reading, rewriting or deleting it', async () => {
    // MDI_FORM.cs:8100-8111 opens Contra on CurBookHelp('CONTRA') and :8360-8365 opens Fine JV on
    // CurBookHelp('FINE JV'); both share CONTRA_DATA, so one family must not reach the other's vouchers.
    const scope = scopeFor('FJV');
    const fine = await postFineJv(runtime, {
      scope,
      vchDate: DAY,
      metal: 'G',
      mainUser: 'fine-user',
      lines: [
        { crdr: 'DR', acCode: 'GOLD1', fine: 1.25 },
        { crdr: 'CR', acCode: 'PARTY1', fine: 1.25 },
      ],
    });
    const engine = { table: 'CONTRA_DATA', book: 'FJV' } as Engine;
    const before = { rows: await sourceRows(engine), state: await state(engine) };
    const money = [
      { crdr: 'DR' as const, acCode: 'PARTY1', amount: 10 },
      { crdr: 'CR' as const, acCode: 'GOLD1', amount: 10 },
    ];
    const journalLines = [
      { acCode: 'PARTY1', drAmt: 10 },
      { acCode: 'GOLD1', crAmt: 10 },
    ];
    const contraRefusals: Array<() => Promise<unknown>> = [
      () => getContra(runtime, scope, fine.vchNo),
      () => editContra(runtime, { scope, vchDate: DAY, lines: money }, fine.vchNo),
      () => deleteContra(runtime, { scope, vchNo: fine.vchNo, deleteUser: 'contra-user' }),
      () => postContra(runtime, { scope, vchDate: DAY, lines: money }),
    ];
    for (const refusal of contraRefusals)
      await expect(refusal()).rejects.toThrow("MAIN_BOOK='CONTRA'");
    const journalRefusals: Array<() => Promise<unknown>> = [
      () => getJournal(runtime, scope, fine.vchNo),
      () => editJournal(runtime, { scope, vchDate: DAY, lines: journalLines }, fine.vchNo),
      () => deleteJournal(runtime, { scope, vchNo: fine.vchNo, deleteUser: 'journal-user' }),
      () => postJournal(runtime, { scope, vchDate: DAY, lines: journalLines }),
    ];
    for (const refusal of journalRefusals)
      await expect(refusal()).rejects.toThrow("MAIN_BOOK='JOURNAL'");
    expect({ rows: await sourceRows(engine), state: await state(engine) }).toEqual(before);
  });
});
