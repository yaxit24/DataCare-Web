import { PrismaClient } from '@datacare/db';
import { afterAll, beforeAll, beforeEach, describe, expect, it } from 'vitest';
import { issueDhrn } from '../src/modules/dhrn/dhrn.js';
import {
  receiveDhrnInterest,
  getDhrnInterest,
  editDhrnInterest,
  deleteDhrnInterest,
} from '../src/modules/dhrn/dhrnInterest.js';
import type { VoucherScope } from '../src/modules/vouchers/numbering.js';

/**
 * N125 / G134: the desktop-faithful DHRN interest receipt (TR_DHRN_INTREC) — collects assessed
 * interest (I), received (R), kasar (K) and optional principal (P + unchak U) against a pledged
 * loan, posting the exact amount-loan 8-leg ledger (Ac_Ledr.cs:1152-1166) and writing the full
 * DHRN_REC_DATA header + DHRN_DATA movement + ROJ_MEL_DATA + REMARK_DATA. Reopen/edit/delete.
 */
const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const databaseDescribe = RUN ? describe : describe.skip;

const TENANT = 'dhrn-interest-db';
const CO = '01';
const LC = '01';
const YEAR = '2024-2025';
const ISSUE_BOOK = 'DHI';
const INT_BOOK = 'DIR';
const DAY = '2024-04-10';
const INT_DAY = '2024-07-10';

const scope = (coBook: string): VoucherScope => ({
  tenantId: TENANT,
  coCode: CO,
  lcCode: LC,
  coYear: YEAR,
  coBook,
});

databaseDescribe('database-backed dhiran interest receipt', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;

  const q = <T>(sql: string, ...p: unknown[]) => owner.$queryRawUnsafe(sql, ...p) as Promise<T>;

  const cleanup = async (): Promise<void> => {
    for (const table of [
      'DELETE_DATA',
      'DHRN_REC_DETL',
      'DHRN_REC_DATA',
      'DHRN_ISU_DETL',
      'DHRN_ISU_DATA',
      'DHRN_DATA',
      'AC_DATA',
      'ROJ_MEL_DATA',
      'REMARK_DATA',
      'TEMP_BOOK_DATA',
      'SRNO_MAST',
      'BOOK_DATA',
      'BOOK_DETL',
      'AC_MAST',
      'CO_SET',
    ])
      await owner.$executeRawUnsafe(`DELETE FROM "${table}" WHERE tenant_id=$1`, TENANT);
  };

  const seed = async (): Promise<void> => {
    await owner.$executeRawUnsafe(
      `INSERT INTO "CO_SET"(tenant_id,"CO_CODE","LOCK_DATE","DHRN_PRC") VALUES ($1,$2,NULL,12)`,
      TENANT,
      CO,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME","MAIN_BOOK","BOOK_INOUT","CUR_USE","BOOK_TBL_NAME")
       VALUES ($1,$2,$3,'DHI','Dhiran Issue','DHIS','DHIRAN ISSUE','O','Y','DHRN_ISU_DATA'),
              ($1,$2,$3,'DIR','Dhiran Interest','DINT','INTREST RECIVED','I','Y','DHRN_REC_DATA')`,
      TENANT,
      CO,
      LC,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME")
       VALUES ($1,$2,$3,'BORR','Pledge Borrower'),($1,$2,$3,'CASH','Cash Account'),
              ($1,$2,$3,'INTINC','Interest Income'),($1,$2,$3,'KASAR','Write Off')`,
      TENANT,
      CO,
      LC,
    );
    // DHI slot 2 = cash funding (for the issue). DIR slot 2 = interest income; slot 1 = metal link.
    await owner.$executeRawUnsafe(
      `INSERT INTO "BOOK_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","SR_NO","AC_CODE","MAIN_BOOK","BOOK_INOUT")
       VALUES ($1,$2,$3,'DHI',2,'CASH','DHIRAN ISSUE','O'),
              ($1,$2,$3,'DIR',1,'INTINC','INTREST RECIVED','I'),
              ($1,$2,$3,'DIR',2,'INTINC','INTREST RECIVED','I')`,
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
  beforeEach(async () => {
    await cleanup();
    await seed();
  });

  it('posts the 8-leg interest ledger, full header, movement, roj; reopens, edits and deletes', async () => {
    const issued = await issueDhrn(runtime, {
      scope: scope(ISSUE_BOOK),
      borrowerAc: 'BORR',
      borrowerName: 'Pledge Borrower',
      principal: 50_000,
      intPrc: 12,
      loanType: 'A',
      vchDate: DAY,
      mainUser: 'dhrn-user',
    } as never);
    const isuNo = (issued as any).vchNo;

    // interest 900, received 900, no kasar/principal (interest-only subset)
    const rec = await receiveDhrnInterest(runtime, {
      scope: scope(INT_BOOK),
      isuNo,
      isuBook: ISSUE_BOOK,
      isuYear: YEAR,
      borrowerAc: 'BORR',
      borrowerName: 'Pledge Borrower',
      interest: 900,
      intPrc: 12,
      settlementAc: 'CASH',
      vchDate: INT_DAY,
      desc: 'Qtr interest',
    });
    const vch = String(rec.vchNo).padStart(5, '0');

    // AC_DATA legs: assessed pair (03/04) + collected pair (05/06) = 4 legs; balanced.
    const legs = await q<Array<{ ac: string; dr: number; cr: number; sfx: string }>>(
      `SELECT "AC_CODE" ac,"DR_AMT"::float8 dr,"CR_AMT"::float8 cr,right("LEDR_KEY",2) sfx
         FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='DIR' AND "VCH_NO"=$2 ORDER BY "LEDR_KEY"`,
      TENANT,
      vch,
    );
    expect(legs.map((l) => l.sfx)).toEqual(['03', '04', '05', '06']);
    const by = Object.fromEntries(legs.map((l) => [l.sfx, l]));
    expect(by['03']).toMatchObject({ ac: 'BORR', dr: 900, cr: 0 });
    expect(by['04']).toMatchObject({ ac: 'INTINC', dr: 0, cr: 900 });
    expect(by['05']).toMatchObject({ ac: 'BORR', dr: 0, cr: 900 });
    expect(by['06']).toMatchObject({ ac: 'CASH', dr: 900, cr: 0 });
    const dr = legs.reduce((s, l) => s + l.dr, 0);
    const cr = legs.reduce((s, l) => s + l.cr, 0);
    expect(dr).toBeCloseTo(cr, 2);
    expect(dr).toBeCloseTo(1800, 2);

    // DHRN_REC_DATA header + DHRN_DATA movement (INT_REC_AMT = R + K = 900) + ROJ + REMARK
    const [hdr] = await q<Array<Record<string, unknown>>>(
      `SELECT "INT_AMT"::float8 ia,"INT_REC_AMT"::float8 ir,"KASAR_AMT"::float8 k,"LEDR_ACCD" s,"BOOK_NAME" bn,"ISU_NO" isu
         FROM "DHRN_REC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='DIR' AND "VCH_NO"=$2`,
      TENANT,
      vch,
    );
    expect(hdr).toMatchObject({ ia: 900, ir: 900, k: 0, s: 'CASH', bn: 'INTREST RECIVED' });
    const [mv] = await q<Array<{ ir: number }>>(
      `SELECT "INT_REC_AMT"::float8 ir FROM "DHRN_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='DIR' AND "VCH_NO"=$2`,
      TENANT,
      vch,
    );
    expect(mv?.ir).toBe(900);
    const [roj] = await q<Array<{ n: number }>>(
      `SELECT count(*)::int n FROM "ROJ_MEL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='DIR' AND "VCH_NO"=$2`,
      TENANT,
      vch,
    );
    expect(roj?.n).toBe(1); // only the interest roj row (cash settlement, no principal)
    const [rem] = await q<Array<{ n: number }>>(
      `SELECT count(*)::int n FROM "REMARK_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='DIR' AND "VCH_NO"=$2`,
      TENANT,
      vch,
    );
    expect(rem?.n).toBe(1);

    // reopen
    const got = await getDhrnInterest(runtime, scope(INT_BOOK), rec.vchNo);
    expect(got).toMatchObject({
      borrowerAc: 'BORR',
      settlementAc: 'CASH',
      interest: 900,
      intReceived: 900,
      desc: 'Qtr interest',
    });

    // edit: add kasar 100 (received 800 + kasar 100), expect 6 legs (03/04 + 05/06 + 07/08)
    await editDhrnInterest(
      runtime,
      {
        scope: scope(INT_BOOK),
        isuNo,
        isuBook: ISSUE_BOOK,
        isuYear: YEAR,
        borrowerAc: 'BORR',
        interest: 900,
        intReceived: 800,
        intKasar: 100,
        intPrc: 12,
        settlementAc: 'CASH',
        vchDate: INT_DAY,
      },
      rec.vchNo,
    );
    const legs2 = await q<Array<{ sfx: string }>>(
      `SELECT right("LEDR_KEY",2) sfx FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='DIR' AND "VCH_NO"=$2 ORDER BY "LEDR_KEY"`,
      TENANT,
      vch,
    );
    expect(legs2.map((l) => l.sfx)).toEqual(['03', '04', '05', '06', '07', '08']);
    const [mv2] = await q<Array<{ ir: number }>>(
      `SELECT "INT_REC_AMT"::float8 ir FROM "DHRN_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='DIR' AND "VCH_NO"=$2`,
      TENANT,
      vch,
    );
    expect(mv2?.ir).toBe(900); // R + K = 800 + 100

    // delete: reverse + DELETE_DATA audit VCH_VAL_CR = INT_REC_AMT (800)
    await deleteDhrnInterest(runtime, {
      scope: scope(INT_BOOK),
      vchNo: rec.vchNo,
      deleteUser: 'u',
    });
    const [left] = await q<Array<{ n: number }>>(
      `SELECT count(*)::int n FROM "DHRN_REC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='DIR' AND "VCH_NO"=$2`,
      TENANT,
      vch,
    );
    expect(left?.n).toBe(0);
    const [ac] = await q<Array<{ n: number }>>(
      `SELECT count(*)::int n FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='DIR' AND "VCH_NO"=$2`,
      TENANT,
      vch,
    );
    expect(ac?.n).toBe(0);
    const [audit] = await q<Array<{ cr: number }>>(
      `SELECT "VCH_VAL_CR"::float8 cr FROM "DELETE_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='DIR' AND "VCH_NO"=$2`,
      TENANT,
      vch,
    );
    expect(audit?.cr).toBe(800);
  });
});
