/**
 * N199 / G209: Party Opening (TR_AC_OPBL) writes one OP_DATA row per party in book '000' with Cr/Dr signs, and its
 * AcOp_Ledr ledger legs; the party balance counts the opening once; delete audits and removes everything.
 *
 * Desktop:
 * - TR_AC_OPBL.cs:2694-2722 deletes and rewrites the party's OP_DATA row: CO_BOOK '000', VCH_NO '00000', signs from the
 *   Cr/Dr combos (:2232-2239), DATA_TYPE, DATA_TRFR ('N' when blank) and MAIN_USER.
 * - :2770-2771 deletes the party's '000' AC_DATA rows and calls AcOp_Ledr (Ac_Ledr.cs:9-28): legs 01/02 amount Cr/Dr,
 *   03/04 gold Cr '+' / Dr '-', 05/06 silver Cr '+' / Dr '-', dated the day before the year opens, keyed
 *   CO+LC+YEAR+BOOK+VCH+AC+DATA_TYPE+type. The real migrated data has 117 such legs, all in that layout.
 * - DC_Main.MsAcBal (DC_Main.cs:1463) computes a balance from AC_DATA only.
 * - :2856-2880 delete: DELETE_DATA rows SR_NO 0 (amount, gold) and 1 (silver), then OP_DATA, OP_DETL and AC_DATA.
 */
import { PrismaClient, withTenant } from '@datacare/db';
import { afterAll, beforeEach, describe, expect, it } from 'vitest';
import {
  deletePartyOpening,
  getPartyOpening,
  listPartyOpenings,
  openingLegs,
  savePartyOpening,
} from '../src/modules/finance/partyOpening.js';
import { partyBalance } from '../src/modules/finance/partyBalance.js';
import { carryForwardOpenings } from '../src/modules/masters/year.js';

const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const TENANT = 'party-opening';
const CO = '01';
const LC = '00';
const YEAR = '2026-2027';
const NEXT = '2027-2028';
const PARTY = '00101';
const OTHER = '00102';

const owner = new PrismaClient({
  datasources: { db: { url: process.env.MIGRATE_DATABASE_URL ?? process.env.DATABASE_URL ?? '' } },
});
const runtime = new PrismaClient({ datasources: { db: { url: process.env.DATABASE_URL ?? '' } } });
const scope = { tenantId: TENANT, coCode: CO, lcCode: LC, coYear: YEAR };
const exec = (sql: string, ...p: unknown[]) =>
  withTenant(owner, TENANT, (tx) => tx.$executeRawUnsafe(sql, ...p));
const rows = <T = any>(sql: string, ...p: unknown[]) =>
  withTenant(owner, TENANT, (tx) => tx.$queryRawUnsafe(sql, ...p)) as Promise<T[]>;

async function wipe() {
  const tables = (await owner.$queryRawUnsafe(
    `SELECT table_name FROM information_schema.columns WHERE column_name='tenant_id' AND table_schema='public'`,
  )) as { table_name: string }[];
  for (const t of tables)
    await owner.$executeRawUnsafe(`DELETE FROM "${t.table_name}" WHERE tenant_id=$1`, TENANT);
}

async function seed() {
  for (const [year, op] of [
    [YEAR, '2026-04-01'],
    [NEXT, '2027-04-01'],
  ])
    await exec(
      `INSERT INTO "YEAR_MAST"(tenant_id,"CO_CODE","CO_YEAR","OP_DATE") VALUES ($1,$2,$3,$4)`,
      TENANT,
      CO,
      year,
      op,
    );
  for (const [code, name, group] of [
    [PARTY, 'RAMESH JEWELLERS', '0012'],
    [OTHER, 'ANAND TRADERS', '0011'],
  ])
    await exec(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","AC_CODE","AC_NAME","AC_GR") VALUES ($1,$2,$3,$4,$5)`,
      TENANT,
      CO,
      code,
      name,
      group,
    );
}

const legsOf = (ac: string, year = YEAR) =>
  rows(
    `SELECT right("LEDR_KEY",2) code, "LEDR_KEY" key, "VCH_TYPE" vt, "VCH_NO" vch, "VCH_DATE"::date::text dt,
            "BOOK_NAME" bn, "LD_CODE" ld, coalesce("DR_AMT",0)::float dr, coalesce("CR_AMT",0)::float cr,
            "IT_TYPE" it, "SIGN" sg, coalesce("FINE_WT",0)::float fine, "IT_DESC" descr, "PARTY_AC_CODE" pac, "MAIN_USER" mu
       FROM "AC_DATA" WHERE tenant_id='${TENANT}' AND "CO_CODE"=$1 AND "CO_YEAR"=$2 AND "CO_BOOK"='000' AND "AC_CODE"=$3 ORDER BY "LEDR_KEY"`,
    CO,
    year,
    ac,
  );
const opData = (ac: string, year = YEAR) =>
  rows(
    `SELECT "CO_BOOK" bk, "VCH_NO" vch, coalesce("OP_AMT",0)::float amt, "OP_SIGN" osg, coalesce("FINE_BAL",0)::float g,
            "FINE_SIGN" gsg, coalesce("SL_FINE_BAL",0)::float s, "SL_FINE_SIGN" ssg, "DATA_TYPE" dt, "DATA_TRFR" tr, "MAIN_USER" mu
       FROM "OP_DATA" WHERE tenant_id='${TENANT}' AND "CO_CODE"=$1 AND "CO_YEAR"=$2 AND "AC_CODE"=$3`,
    CO,
    year,
    ac,
  );

describe.skipIf(!RUN)(
  'Party Opening writes OP_DATA and its ledger legs (TR_AC_OPBL, AcOp_Ledr)',
  () => {
    beforeEach(async () => {
      await wipe();
      await seed();
    });
    afterAll(async () => {
      await wipe();
      await owner.$disconnect();
      await runtime.$disconnect();
    });

    it('saves one OP_DATA row in book 000 and one leg per non-zero head', async () => {
      await savePartyOpening(runtime, {
        scope,
        acCode: PARTY,
        mainUser: 'ADMIN',
        amount: 25000,
        sign: 'D',
        gold: 12.345,
        goldSign: 'C',
        silver: 0,
        silverSign: 'C',
      });
      expect(await opData(PARTY)).toEqual([
        {
          bk: '000',
          vch: '00000',
          amt: 25000,
          osg: 'D',
          g: 12.345,
          gsg: 'C',
          s: 0,
          ssg: 'C',
          dt: 'A',
          tr: 'N',
          mu: 'ADMIN',
        },
      ]);
      const legs = await legsOf(PARTY);
      expect(legs.map((l) => [l.code, l.dr, l.cr, l.it, l.sg, l.fine, l.descr])).toEqual([
        ['02', 25000, 0, 'A', '', 0, 'OPENING AMOUNT'],
        ['03', 0, 0, 'G', '+', 12.345, 'OPENING GOLD'],
      ]);
      for (const l of legs) {
        expect(l.key).toBe(`${CO}${LC}${YEAR}00000000${PARTY}A${l.code}`);
        expect([l.vt, l.vch, l.dt, l.bn, l.ld, l.pac, l.mu]).toEqual([
          'ACOP',
          '00000',
          '2026-03-31',
          'TR_AC_OPBL',
          '00000',
          PARTY,
          'ADMIN',
        ]);
      }
    });

    it('a second save replaces the row and the legs, keeping the first user', async () => {
      await savePartyOpening(runtime, {
        scope,
        acCode: PARTY,
        mainUser: 'ADMIN',
        amount: 1000,
        sign: 'C',
      });
      await savePartyOpening(runtime, {
        scope,
        acCode: PARTY,
        mainUser: 'CLERK',
        amount: 400,
        sign: 'D',
        silver: 2.5,
        silverSign: 'D',
      });
      const op = await opData(PARTY);
      expect(op).toHaveLength(1);
      expect([op[0].amt, op[0].osg, op[0].s, op[0].ssg, op[0].mu]).toEqual([
        400,
        'D',
        2.5,
        'D',
        'ADMIN',
      ]);
      expect((await legsOf(PARTY)).map((l) => [l.code, l.dr, l.it, l.sg, l.fine])).toEqual([
        ['02', 400, 'A', '', 0],
        ['06', 0, 'S', '-', 2.5],
      ]);
    });

    it('the party balance counts the opening once', async () => {
      await savePartyOpening(runtime, {
        scope,
        acCode: PARTY,
        amount: 25000,
        sign: 'D',
        gold: 12.345,
        goldSign: 'C',
        silver: 3,
        silverSign: 'D',
      });
      expect(await partyBalance(runtime, scope, PARTY)).toMatchObject({
        amount: 25000,
        sign: 'Dr',
        gold: 12.345,
        silver: -3,
      });
    });

    it('reads the opening back and lists it by balance type', async () => {
      await savePartyOpening(runtime, {
        scope,
        acCode: PARTY,
        amount: 25000,
        sign: 'D',
        gold: 5,
        goldSign: 'D',
      });
      await savePartyOpening(runtime, { scope, acCode: OTHER, amount: 700, sign: 'C' });
      expect(await getPartyOpening(runtime, scope, PARTY)).toMatchObject({
        acCode: PARTY,
        acName: 'RAMESH JEWELLERS',
        exists: true,
        amount: 25000,
        sign: 'D',
        gold: 5,
        goldSign: 'D',
        silver: 0,
        silverSign: 'C',
      });
      expect(await getPartyOpening(runtime, scope, '00999')).toMatchObject({
        exists: false,
        sign: 'C',
      });
      const amounts = await listPartyOpenings(runtime, scope, 'amount');
      // Ordered by account group then name (TR_AC_OPBL.cs:2301): ANAND (0011) before RAMESH (0012).
      expect(amounts.rows.map((r) => [r.acCode, r.cr, r.dr])).toEqual([
        [OTHER, 700, 0],
        [PARTY, 0, 25000],
      ]);
      expect([amounts.totalCr, amounts.totalDr]).toEqual([700, 25000]);
      expect(
        (await listPartyOpenings(runtime, scope, 'gold')).rows.map((r) => [r.acCode, r.dr]),
      ).toEqual([[PARTY, 5]]);
    });

    it('refuses a missing party with the desktop message and an unknown party, writing nothing', async () => {
      await expect(savePartyOpening(runtime, { scope, acCode: '', amount: 10 })).rejects.toThrow(
        'Please Enter Party First...',
      );
      await expect(
        savePartyOpening(runtime, { scope, acCode: '00999', amount: 10 }),
      ).rejects.toThrow('party 00999 does not exist');
      await expect(savePartyOpening(runtime, { scope, acCode: PARTY, amount: -5 })).rejects.toThrow(
        /negative/,
      );
      await expect(deletePartyOpening(runtime, scope, '', 'ADMIN')).rejects.toThrow(
        'Please Select Account Details.',
      );
      expect(await rows(`SELECT 1 FROM "OP_DATA" WHERE tenant_id=$1`, TENANT)).toHaveLength(0);
      expect(await rows(`SELECT 1 FROM "AC_DATA" WHERE tenant_id=$1`, TENANT)).toHaveLength(0);
    });

    it('delete audits the opening and removes OP_DATA, OP_DETL and the legs', async () => {
      await savePartyOpening(runtime, {
        scope,
        acCode: PARTY,
        mainUser: 'ADMIN',
        amount: 25000,
        sign: 'D',
        gold: 5,
        goldSign: 'C',
        silver: 2,
        silverSign: 'D',
      });
      await exec(
        `INSERT INTO "OP_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","AC_CODE","VCH_NO","SR_NO") VALUES ($1,$2,$3,$4,'000',$5,'00012','1')`,
        TENANT,
        CO,
        LC,
        YEAR,
        PARTY,
      );
      expect(await deletePartyOpening(runtime, scope, PARTY, 'CLERK')).toEqual({ deleted: true });
      expect(await opData(PARTY)).toHaveLength(0);
      expect(await legsOf(PARTY)).toHaveLength(0);
      expect(await rows(`SELECT 1 FROM "OP_DETL" WHERE tenant_id=$1`, TENANT)).toHaveLength(0);
      const audit = await rows(
        `SELECT coalesce("SR_NO",0)::int sr, "VCH_TYPE" vt, "BOOK_NAME" bn, "AC_NAME" nm, coalesce("VCH_VAL_DR",0)::float dr,
              coalesce("VCH_VAL_CR",0)::float cr, "FINE_TYPE" ft, coalesce("VCH_FINE_DR",0)::float fdr,
              coalesce("VCH_FINE_CR",0)::float fcr, "MAIN_USER" mu, "DELETE_USER" du
         FROM "DELETE_DATA" WHERE tenant_id=$1 ORDER BY "SR_NO"`,
        TENANT,
      );
      expect(audit).toEqual([
        {
          sr: 0,
          vt: 'OPBAL',
          bn: 'Ac OpBal',
          nm: 'RAMESH JEWELLERS',
          dr: 25000,
          cr: 0,
          ft: 'G',
          fdr: 0,
          fcr: 5,
          mu: 'ADMIN',
          du: 'CLERK',
        },
        {
          sr: 1,
          vt: 'OPBAL',
          bn: 'Ac OpBal',
          nm: 'RAMESH JEWELLERS',
          dr: 0,
          cr: 0,
          ft: 'S',
          fdr: 2,
          fcr: 0,
          mu: 'ADMIN',
          du: 'CLERK',
        },
      ]);
      expect(await deletePartyOpening(runtime, scope, PARTY, 'CLERK')).toEqual({ deleted: false });
    });

    it('a save keeps the bill-wise OP_DETL rows', async () => {
      await exec(
        `INSERT INTO "OP_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","AC_CODE","VCH_NO","SR_NO") VALUES ($1,$2,$3,$4,'000',$5,'00012','1')`,
        TENANT,
        CO,
        LC,
        YEAR,
        PARTY,
      );
      await savePartyOpening(runtime, { scope, acCode: PARTY, amount: 50, sign: 'D' });
      expect(await rows(`SELECT 1 FROM "OP_DETL" WHERE tenant_id=$1`, TENANT)).toHaveLength(1);
    });

    it('bill rows set the heads from their signed totals and replace OP_DETL (MSG_TOT_FILL, TR_AC_OPBL.cs:2724-2760)', async () => {
      const saved = await savePartyOpening(runtime, {
        scope,
        acCode: PARTY,
        mainUser: 'ADMIN',
        amount: 999,
        sign: 'C',
        bills: [
          {
            vchNo: '00012',
            vchDate: '2026-02-10',
            billNo: 'B12',
            itType: 'A',
            amount: 30000,
            sign: 'D',
          },
          { vchNo: '00015', itType: 'A', amount: 5000, sign: 'C' },
          { vchNo: '00020', itType: 'G', netWt: 10, touch: 91.6, goldFine: 9.16, sign: 'D' },
          { vchNo: '', itType: 'A', sign: 'C' },
        ],
      });
      // Amount: -30,000 + 5,000 = 25,000 Dr; gold: 9.16 Dr. The typed 999 Cr is replaced by the grid totals.
      expect([saved.amount, saved.sign, saved.gold, saved.goldSign]).toEqual([
        25000,
        'D',
        9.16,
        'D',
      ]);
      expect((await opData(PARTY))[0]).toMatchObject({ amt: 25000, osg: 'D', g: 9.16, gsg: 'D' });
      expect((await legsOf(PARTY)).map((l) => [l.code, l.dr, l.it, l.sg, l.fine])).toEqual([
        ['02', 25000, 'A', '', 0],
        ['04', 0, 'G', '-', 9.16],
      ]);
      const detl = await rows(
        `SELECT "SR_NO" sr, "VCH_NO" vch, "VCH_DATE"::date::text dt, "BILL_NO" bill, "ITM_TYPE" it, coalesce("ITM_AMT",0)::float amt,
              coalesce("ITM_GL_FINE",0)::float gf, "ITM_SIGN" sg FROM "OP_DETL" WHERE tenant_id=$1 ORDER BY "SR_NO"`,
        TENANT,
      );
      expect(detl).toEqual([
        {
          sr: '1',
          vch: '00012',
          dt: '2026-02-10',
          bill: 'B12',
          it: 'A',
          amt: 30000,
          gf: 0,
          sg: 'D',
        },
        { sr: '2', vch: '00015', dt: null, bill: '', it: 'A', amt: 5000, gf: 0, sg: 'C' },
        { sr: '3', vch: '00020', dt: null, bill: '', it: 'G', amt: 0, gf: 9.16, sg: 'D' },
      ]);
      expect(saved.bills.map((b) => b.vchNo)).toEqual(['00012', '00015', '00020']);
      expect(saved.billDate).toBe('2026-03-31');
      // A second save with fewer rows replaces them; an empty list removes them and the typed heads apply.
      await savePartyOpening(runtime, {
        scope,
        acCode: PARTY,
        bills: [{ vchNo: '00015', itType: 'A', amount: 700, sign: 'C' }],
      });
      expect(await rows(`SELECT 1 FROM "OP_DETL" WHERE tenant_id=$1`, TENANT)).toHaveLength(1);
      expect((await opData(PARTY))[0]).toMatchObject({ amt: 700, osg: 'C', g: 0 });
      await savePartyOpening(runtime, { scope, acCode: PARTY, amount: 50, sign: 'D', bills: [] });
      expect(await rows(`SELECT 1 FROM "OP_DETL" WHERE tenant_id=$1`, TENANT)).toHaveLength(0);
      expect((await opData(PARTY))[0]).toMatchObject({ amt: 50, osg: 'D' });
    });

    it('refuses bill rows the desktop refuses, with its messages', async () => {
      const bill = { vchNo: '00012', itType: 'A', amount: 10, sign: 'C' };
      await expect(
        savePartyOpening(runtime, { scope, acCode: PARTY, bills: [{ ...bill, vchNo: '' }] }),
      ).rejects.toThrow('Please Insert Vch No and Try...');
      await expect(
        savePartyOpening(runtime, {
          scope,
          acCode: PARTY,
          bills: [{ ...bill, amount: 0, billNo: 'X' }],
        }),
      ).rejects.toThrow('Please Insert Gold fine or Silver fine or Net Amount and try...');
      await expect(
        savePartyOpening(runtime, { scope, acCode: PARTY, bills: [{ ...bill, itType: 'Q' }] }),
      ).rejects.toThrow('Please insert ItmType  G = Gold S = Silver Or A = Amount and try');
      await expect(
        savePartyOpening(runtime, { scope, acCode: PARTY, bills: [{ ...bill, sign: 'X' }] }),
      ).rejects.toThrow('Please Enter C or D and Try Again...');
      expect(await rows(`SELECT 1 FROM "OP_DATA" WHERE tenant_id=$1`, TENANT)).toHaveLength(0);
    });

    it('the year carry-forward reads the legs once and writes the next year in the same shape', async () => {
      await savePartyOpening(runtime, {
        scope,
        acCode: PARTY,
        amount: 25000,
        sign: 'D',
        gold: 5,
        goldSign: 'C',
        silver: 2,
        silverSign: 'D',
      });
      // A receipt of 10,000 from the party during the year.
      await exec(
        `INSERT INTO "AC_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","LEDR_KEY","AC_CODE","DR_AMT","CR_AMT","IT_TYPE")
       VALUES ($1,$2,$3,$4,'001','00001','rcpt-01',$5,0,10000,'A')`,
        TENANT,
        CO,
        LC,
        YEAR,
        PARTY,
      );
      expect(await carryForwardOpenings(runtime, scope, YEAR, NEXT, 'ADMIN')).toEqual({
        parties: 1,
      });
      expect(await opData(PARTY, NEXT)).toEqual([
        {
          bk: '000',
          vch: '00000',
          amt: 15000,
          osg: 'D',
          g: 5,
          gsg: 'C',
          s: 2,
          ssg: 'D',
          dt: 'A',
          tr: 'N',
          mu: 'ADMIN',
        },
      ]);
      expect((await legsOf(PARTY, NEXT)).map((l) => [l.code, l.dr, l.sg, l.fine, l.dt])).toEqual([
        ['02', 15000, '', 0, '2027-03-31'],
        ['03', 0, '+', 5, '2027-03-31'],
        ['06', 0, '-', 2, '2027-03-31'],
      ]);
      // Idempotent: a second run gives the same opening.
      await carryForwardOpenings(runtime, scope, YEAR, NEXT, 'ADMIN');
      expect(await opData(PARTY, NEXT)).toHaveLength(1);
      expect(await legsOf(PARTY, NEXT)).toHaveLength(3);
    });
  },
);

describe('AcOp_Ledr leg layout (pure)', () => {
  it('writes nothing for a zero opening and the Cr leg for a default sign', () => {
    const date = new Date('2026-03-31T00:00:00.000Z');
    const heads = {
      amount: 0,
      sign: 'C' as const,
      gold: 0,
      goldSign: 'C' as const,
      silver: 0,
      silverSign: 'C' as const,
    };
    expect(openingLegs(scope, PARTY, heads, date, 'ADMIN')).toEqual([]);
    expect(
      openingLegs(scope, PARTY, { ...heads, amount: 10 }, date, 'ADMIN').map((l) => l.LEDR_KEY),
    ).toEqual([`${CO}${LC}${YEAR}00000000${PARTY}A01`]);
  });
});
