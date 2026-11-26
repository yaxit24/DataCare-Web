/**
 * Cash/Bank and Contra write sets as the desktop writes them (found by the desktop replay oracle, run on a real
 * desktop year; synthetic accounts and amounts here).
 *
 *   TR_CASH.cs:3005-3069  one CASH_DATA row per grid line: SR_NO, CLR_DATE, VCH_TYPE = BOOK_SNAME, ENTRY_TYPE 'C',
 *                         BOOK_NAME = MAIN_BOOK, USER_DELETE 'N', BANK_NAME / CHQ_PRINT_NAME '', no REC_AC_CODE
 *   TR_CASH.cs:2674, 2968 numbering is MAX(VCH_NO) of CASH_DATA for every cash and bank book, payments included
 *   Ac_Ledr.cs:567-609    PARTY_AC_CODE on the party legs only; the narration on the amount legs
 *   Ac_Rojmel.cs:181-217  the bank day book is a pair (party, bank) dated on the clearing date
 *   TR_CONTRA.cs:2751     TEMP_BOOK_DATA takes the form name; :2776, :2828 the data rows take MAIN_BOOK
 */
import { PrismaClient, withTenant } from '@datacare/db';
import { afterAll, beforeEach, describe, expect, it } from 'vitest';
import {
  deletePayment,
  editPayment,
  getPayment,
  postContra,
  postPayment,
  postPaymentLines,
  postReceipt,
  postReceiptLines,
} from '../src/modules/finance/finance.js';
import { financeVoucherData } from '../src/modules/finance/financeVoucher.js';
import { neighbourVoucher, recentVouchers } from '../src/modules/vouchers/list.js';

const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const TENANT = 'cash-shape';
const CO = '01';
const LC = '00';
const YEAR = '2024-2025';
const PARTY = '000926';
const PARTY_B = '000927';
const CASH = '00001';
const BANK = '000205';
const KASAR = '00057';
const CHARGES = '00048';
// A book name longer than CASH_DATA.BOOK_NAME (20): the oracle's book 007, which the web used to refuse.
const LONG_NAME = 'AXIS BANK CURRENT REC';

const owner = new PrismaClient({
  datasources: { db: { url: process.env.MIGRATE_DATABASE_URL ?? process.env.DATABASE_URL ?? '' } },
});
const runtime = new PrismaClient({ datasources: { db: { url: process.env.DATABASE_URL ?? '' } } });
const scopeOf = (coBook: string) => ({
  tenantId: TENANT,
  coCode: CO,
  lcCode: LC,
  coYear: YEAR,
  coBook,
});
const exec = (sql: string, ...p: unknown[]) =>
  withTenant(owner, TENANT, (tx) => tx.$executeRawUnsafe(sql, ...p));
const rows = async (sql: string, ...p: unknown[]) =>
  (await owner.$queryRawUnsafe(sql, TENANT, ...p)) as Array<Record<string, any>>;

async function wipe() {
  const tables = (await owner.$queryRawUnsafe(
    `SELECT table_name FROM information_schema.columns
      WHERE column_name='tenant_id' AND table_schema='public'`,
  )) as { table_name: string }[];
  for (const t of tables)
    await owner.$executeRawUnsafe(`DELETE FROM "${t.table_name}" WHERE tenant_id=$1`, TENANT);
}

async function book(
  code: string,
  name: string,
  sname: string,
  main: string,
  inout: string,
  slots: Array<[number, string]>,
  table: string | null = 'CASH_DATA',
) {
  await exec(
    `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME","MAIN_BOOK","BOOK_INOUT","CUR_USE","BOOK_TBL_NAME")
     VALUES ($1,$2,$3,$4,$5,$6,$7,$8,'Y',$9)`,
    TENANT,
    CO,
    LC,
    code,
    name,
    sname,
    main,
    inout,
    table,
  );
  for (const [sr, ac] of slots)
    await exec(
      `INSERT INTO "BOOK_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","SR_NO","AC_CODE","BOOK_NAME","MAIN_BOOK","BOOK_INOUT")
       VALUES ($1,$2,$3,$4,$5,$6,$7,$8,$9)`,
      TENANT,
      CO,
      LC,
      code,
      sr,
      ac,
      name,
      main,
      inout,
    );
}

async function seed() {
  await exec(
    `INSERT INTO "CO_SET"(tenant_id,"CO_CODE","LBR_TYPE","LBR_ROF","TAX_ROF","ITM_RATE_ROF","ALL_ROF_REMOVE")
     VALUES ($1,$2,'N',2,2,2,'N')`,
    TENANT,
    CO,
  );
  await exec(
    `INSERT INTO "CO_SET_NEW"(tenant_id,"CO_CODE","TOT_AMT_ROF","PR_RATE_ROF") VALUES ($1,$2,0,2)`,
    TENANT,
    CO,
  );
  await exec(
    `INSERT INTO "YEAR_MAST"(tenant_id,"CO_CODE","CO_YEAR","OP_DATE","CL_DATE")
     VALUES ($1,$2,$3,'2024-04-01','2025-03-31')`,
    TENANT,
    CO,
    YEAR,
  );
  for (const [code, name] of [
    [PARTY, 'SAMPLE PARTY'],
    [PARTY_B, 'SECOND PARTY'],
    [CASH, 'CASH ON HAND'],
    [BANK, 'SAMPLE BANK'],
    [KASAR, 'KASAR A/C'],
    [CHARGES, 'BANK CHARGES A/C'],
  ])
    await exec(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GST_TYPE")
       VALUES ($1,$2,$3,$4,$5,'L')`,
      TENANT,
      CO,
      LC,
      code,
      name,
    );
  await book('001', 'Cash Received', 'CREC', 'CASH REC', 'I', [
    [1, CASH],
    [2, KASAR],
  ]);
  await book('002', 'Cash Payment', 'CPAY', 'CASH PAY', 'O', [
    [1, CASH],
    [2, KASAR],
  ]);
  await book('005', LONG_NAME, 'BREC', 'BANK REC', 'I', [
    [1, BANK],
    [2, KASAR],
    [3, CHARGES],
  ]);
  await book('012', 'Bank Payment', 'BBPAY', 'BANK PAY', 'O', [
    [1, BANK],
    [2, KASAR],
    [3, CHARGES],
  ]);
  await book('017', 'Contra Entry', 'JV', 'CONTRA', 'O', [], 'CONTRA_DATA');
}

const cashRows = (book: string) =>
  rows(
    `SELECT "VCH_NO", "SR_NO"::int sr, "AC_CODE" ac, "REC_AMT"::float rec, "KASAR_AMT"::float kasar,
            "BANK_CHARGES"::float charges, "VCH_TYPE" vt, "INOUT_TYPE" io, "ENTRY_TYPE" et, "BOOK_NAME" bn,
            "IT_DESC" descr, "CHQ_NO" chq, "CHQ_PRINT_NAME" cpn, "BANK_NAME" bank, "REC_AC_CODE" rec_ac,
            "VCH_DATE"::text vd, "CLR_DATE"::text cd, "USER_DELETE" ud, "USER_UPDATE" uu, "DATA_TRFR" dt
       FROM "CASH_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='${book}' ORDER BY "VCH_NO","SR_NO"`,
  );
const ledger = (book: string, vch: string) =>
  rows(
    `SELECT trim(substring("LEDR_KEY" from 22)) k, "AC_CODE" ac, "LD_CODE" ld, "DR_AMT"::float dr, "CR_AMT"::float cr,
            "PARTY_AC_CODE" party, "IT_DESC" descr, "BOOK_NAME" bn, "VCH_TYPE" vt, "VCH_DATE"::text vd,
            "CLR_DATE"::text cd, "CHQ_NO" chq
       FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='${book}' AND "VCH_NO"='${vch}' ORDER BY "LEDR_KEY"`,
  );
const dayBook = (book: string, vch: string) =>
  rows(
    `SELECT regexp_replace(substring("LEDR_KEY" from 22), '\\s+', '', 'g') k, "AC_CODE" ac, "LD_CODE" ld,
            "DR_AMT"::float dr, "CR_AMT"::float cr, "AC_NAME" name, "IT_DESC" descr, "BOOK_NAME" bn,
            "VCH_TYPE" vt, "VCH_DATE"::text vd
       FROM "ROJ_MEL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='${book}' AND "VCH_NO"='${vch}' ORDER BY "LEDR_KEY"`,
  );
const count = async (table: string, book?: string) =>
  (
    await rows(
      `SELECT count(*)::int n FROM "${table}" WHERE tenant_id=$1${book ? ` AND "CO_BOOK"='${book}'` : ''}`,
    )
  )[0]!.n as number;

describe.runIf(RUN)('cash and bank vouchers are written as TR_CASH writes them', () => {
  beforeEach(async () => {
    await wipe();
    await seed();
  });
  afterAll(async () => {
    await wipe();
  });

  it('BOOK_NAME is the MAIN_BOOK on every data row and the form name only on TEMP_BOOK_DATA; a 21-character book name saves', async () => {
    await postReceipt(runtime, {
      scope: scopeOf('005'),
      partyAc: PARTY,
      amount: 500,
      mode: 'bank',
      vchDate: '2024-05-01',
    } as never);
    await postReceipt(runtime, {
      scope: scopeOf('001'),
      partyAc: PARTY,
      amount: 100,
      mode: 'cash',
      vchDate: '2024-05-01',
    } as never);
    expect((await cashRows('005'))[0]).toMatchObject({ bn: 'BANK REC', vt: 'BREC' });
    expect((await ledger('005', '00001')).map((l) => l.bn)).toEqual(['BANK REC', 'BANK REC']);
    expect((await dayBook('005', '00001')).map((l) => l.bn)).toEqual(['BANK REC', 'BANK REC']);
    expect((await cashRows('001'))[0]).toMatchObject({ bn: 'CASH REC', vt: 'CREC' });
    // TR_CASH.cs:3001: the hidden identity row carries FormName, the book's own (long) name.
    const hidden = await rows(
      `SELECT "CO_BOOK" b, "BOOK_NAME" n FROM "TEMP_BOOK_DATA" WHERE tenant_id=$1 ORDER BY 1`,
    );
    expect(hidden).toEqual([
      { b: '001', n: 'Cash Received' },
      { b: '005', n: LONG_NAME },
    ]);
  });

  it('numbers payments from CASH_DATA: single and grid payments in one book take 00001, 00002, 00003', async () => {
    const a = await postPayment(runtime, {
      scope: scopeOf('002'),
      partyAc: PARTY,
      amount: 10,
      mode: 'cash',
      vchDate: '2024-05-01',
    } as never);
    const b = await postPaymentLines(runtime, {
      scope: scopeOf('002'),
      mode: 'cash',
      vchDate: '2024-05-02',
      lines: [
        { partyAc: PARTY, amount: 20 },
        { partyAc: PARTY_B, amount: 30 },
      ],
    } as never);
    const c = await postPayment(runtime, {
      scope: scopeOf('002'),
      partyAc: PARTY_B,
      amount: 40,
      mode: 'cash',
      vchDate: '2024-05-03',
    } as never);
    expect([a.vchNo, b.vchNo, c.vchNo]).toEqual([1, 2, 3]);
    // No PAY_DATA / PAY_DETL: those belong to Other Expenses (MS_UPDATE.cs:7933).
    expect([
      await count('PAY_DATA'),
      await count('PAY_DETL'),
      await count('CASH_DATA', '002'),
    ]).toEqual([0, 0, 4]);
    // Each voucher has its hidden identity, grid payments included (TR_CASH.cs:2995-3004).
    expect(await count('TEMP_BOOK_DATA', '002')).toBe(3);
    expect((await cashRows('002')).map((r) => [r.VCH_NO, r.sr, r.io, r.rec])).toEqual([
      ['00001', 1, 'O', 10],
      ['00002', 1, 'O', 20],
      ['00002', 2, 'O', 30],
      ['00003', 1, 'O', 40],
    ]);
  });

  it('writes the CASH_DATA columns TR_CASH writes: SR_NO, CLR_DATE, ENTRY_TYPE C on a bank book, BOOK_SNAME, USER_DELETE N, blank text, no REC_AC_CODE', async () => {
    await postPayment(runtime, {
      scope: scopeOf('012'),
      partyAc: PARTY,
      amount: 100,
      mode: 'bank',
      vchDate: '2024-05-01',
    } as never);
    expect((await cashRows('012'))[0]).toEqual({
      VCH_NO: '00001',
      sr: 1,
      ac: PARTY,
      rec: 100,
      kasar: 0,
      charges: 0,
      vt: 'BBPAY', // BOOK_SNAME, not BPAY
      io: 'O',
      et: 'C', // TR_CASH.cs:3032 for every cash and bank book
      bn: 'BANK PAY',
      descr: '',
      chq: '',
      cpn: '',
      bank: '',
      rec_ac: null, // not a TR_CASH column
      vd: '2024-05-01',
      cd: '2024-05-01', // the voucher date when the grid cell is empty (TR_CASH.cs:3022-3025)
      ud: 'N',
      uu: 'N',
      dt: 'N',
    });
  });

  it('puts PARTY_AC_CODE on the party legs only and the narration on the amount legs and the day book', async () => {
    await postReceiptLines(runtime, {
      scope: scopeOf('001'),
      mode: 'cash',
      vchDate: '2024-05-01',
      lines: [{ partyAc: PARTY, partyName: 'SAMPLE PARTY', amount: 600, kasar: 4, itDesc: 'dues' }],
    } as never);
    const legs = await ledger('001', '00001');
    expect(legs.map((l) => [l.k, l.ac, l.party, l.descr])).toEqual([
      ['101', PARTY, PARTY, 'dues'], // Ac_Ledr.cs:567
      ['102', CASH, '', 'dues'], // :569
      ['103', PARTY, PARTY, ''], // :571
      ['104', KASAR, '', ''], // :573
    ]);
    expect((await dayBook('001', '00001')).map((r) => [r.k, r.name, r.descr])).toEqual([
      ['011', 'SAMPLE PARTY', 'dues'],
      ['021', 'KSR - SAMPLE PARTY', 'dues'], // Ac_Rojmel.cs:183
      ['031', 'KSR - SAMPLE PARTY', 'dues'],
    ]);
  });

  it('writes the bank day book as a pair dated on the clearing date, with the charges leg, and the ledger CLR_DATE = voucher date', async () => {
    await postReceiptLines(runtime, {
      scope: scopeOf('005'),
      mode: 'bank',
      vchDate: '2024-05-01',
      lines: [
        {
          partyAc: PARTY,
          partyName: 'SAMPLE PARTY',
          amount: 5000,
          kasar: 10,
          bankCharges: 18,
          clrDate: '2024-05-03',
          itDesc: 'neft',
          chqPrintName: 'SAMPLE PARTY',
        },
      ],
    } as never);
    // Bank_Rojmel (Ac_Rojmel.cs:197-207): party Cr, bank Dr net of charges, kasar pair, charges Dr.
    expect(
      (await dayBook('005', '00001')).map((r) => [r.k, r.ac, r.ld, r.dr, r.cr, r.name, r.vd]),
    ).toEqual([
      ['011', PARTY, BANK, 0, 5000, '', '2024-05-03'],
      ['021', BANK, PARTY, 4982, 0, '', '2024-05-03'],
      ['031', PARTY, KASAR, 0, 10, 'KSR - SAMPLE PARTY', '2024-05-03'],
      ['041', KASAR, PARTY, 10, 0, 'KSR - SAMPLE PARTY', '2024-05-03'],
      ['051', CHARGES, PARTY, 18, 0, '', '2024-05-03'],
    ]);
    // Bank_Ledr (Ac_Ledr.cs:587-597): VCH_DATE = CLR_DATE, CLR_DATE = VCH_DATE.
    const legs = await ledger('005', '00001');
    expect(legs.map((l) => [l.k, l.ac, l.ld, l.dr, l.cr])).toEqual([
      ['101', PARTY, BANK, 0, 5000],
      ['102', BANK, PARTY, 5000, 0],
      ['103', PARTY, KASAR, 0, 10],
      ['104', KASAR, PARTY, 10, 0],
      ['105', BANK, PARTY, 0, 18],
      ['106', CHARGES, BANK, 18, 0],
    ]);
    for (const l of legs) expect([l.vd, l.cd]).toEqual(['2024-05-03', '2024-05-01']);
    expect((await cashRows('005'))[0]).toMatchObject({
      charges: 18,
      cd: '2024-05-03',
      cpn: 'SAMPLE PARTY',
      et: 'C',
    });
  });

  it('refuses bank charges on a cash book and writes nothing', async () => {
    await expect(
      postPayment(runtime, {
        scope: scopeOf('002'),
        partyAc: PARTY,
        amount: 10,
        bankCharges: 5,
        mode: 'cash',
        vchDate: '2024-05-01',
      } as never),
    ).rejects.toThrow(/bank charges belong to a bank/);
    expect(await count('CASH_DATA')).toBe(0);
    expect(await count('AC_DATA')).toBe(0);
  });

  it('prints a payment from CASH_DATA and opens it with its lines, mode and bank account', async () => {
    const saved = await postPayment(runtime, {
      scope: scopeOf('012'),
      partyAc: PARTY,
      partyName: 'SAMPLE PARTY',
      amount: 750,
      mode: 'cheque',
      chqNo: '123456',
      vchDate: '2024-05-01',
    } as never);
    const read = await getPayment(runtime, scopeOf('012'), saved.vchNo);
    expect(read).toMatchObject({
      amount: 750,
      partyAc: PARTY,
      mode: 'cheque',
      bankAc: BANK, // the book's slot 1: TR_CASH stores no REC_AC_CODE
      chqNo: '123456',
      bookName: 'BANK PAY',
    });
    const doc = await financeVoucherData(runtime, 'payment', {
      ...scopeOf('012'),
      vchNo: '00001',
    });
    expect(doc?.header).toMatchObject({ NET_AMT: 750, VCH_TYPE: 'BPAY', BANK_AC: BANK });
  });

  it('an unchanged save of a payment is a no-op: narration, charges and the clearing date survive an edit that omits them', async () => {
    await postPaymentLines(runtime, {
      scope: scopeOf('012'),
      mode: 'bank',
      vchDate: '2024-05-01',
      lines: [
        {
          partyAc: PARTY,
          amount: 100,
          bankCharges: 18,
          clrDate: '2024-05-04',
          itDesc: 'kept',
          chqPrintName: 'PAYEE',
        },
      ],
    } as never);
    const before = await cashRows('012');
    await editPayment(
      runtime,
      {
        scope: scopeOf('012'),
        partyAc: PARTY,
        amount: 100,
        mode: 'bank',
        vchDate: '2024-05-01',
      } as never,
      '00001',
    );
    expect(await cashRows('012')).toEqual(before);
    expect((await ledger('012', '00001')).map((l) => l.k)).toEqual(['107', '108', '111', '112']);
  });

  it('deletes a payment with its ledger, day book and hidden identity, and audits it', async () => {
    const saved = await postPayment(runtime, {
      scope: scopeOf('002'),
      partyAc: PARTY,
      amount: 40,
      mode: 'cash',
      vchDate: '2024-05-01',
    } as never);
    await deletePayment(runtime, {
      scope: scopeOf('002'),
      vchNo: saved.vchNo,
      deleteUser: 'tester',
    });
    expect([
      await count('CASH_DATA', '002'),
      await count('AC_DATA', '002'),
      await count('ROJ_MEL_DATA', '002'),
      await count('TEMP_BOOK_DATA', '002'),
      await count('DELETE_DATA', '002'),
    ]).toEqual([0, 0, 0, 0, 1]);
  });
});

/** A payment as the web wrote it before payments moved to CASH_DATA: PAY_DATA, AC_DATA and ROJ_MEL_DATA. */
async function legacyPayment(vch: string, amount: number, hidden: string | null) {
  await exec(
    `INSERT INTO "PAY_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DATE","VCH_TYPE",
       "NET_AMT","TOT_AMT","KASAR_AMT","AC_CODE","AC_NAME","CASH_AMT","HD_VCH_NO","MAIN_USER","VCH_TIME")
     VALUES ($1,$2,$3,$4,'002',$5,'2024-05-01','CPAY',$6,$6,0,$7,'SAMPLE PARTY',$6,$8,'old','2024-05-01 10:00:00')`,
    TENANT,
    CO,
    LC,
    YEAR,
    vch,
    amount,
    PARTY,
    hidden,
  );
  await exec(
    `INSERT INTO "AC_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DATE","VCH_TYPE","LEDR_KEY","AC_CODE","LD_CODE","DR_AMT","CR_AMT")
     VALUES ($1,$2,$3,$4,'002',$5,'2024-05-01','CPAY',$6,$7,$8,$9,0),
            ($1,$2,$3,$4,'002',$5,'2024-05-01','CPAY',$10,$8,$7,0,$9)`,
    TENANT,
    CO,
    LC,
    YEAR,
    vch,
    `01002024-2025002${vch}         105`,
    PARTY,
    CASH,
    amount,
    `01002024-2025002${vch}         106`,
  );
}

describe.runIf(RUN)('payments saved in PAY_DATA before they moved to CASH_DATA stay usable', () => {
  beforeEach(async () => {
    await wipe();
    await seed();
    await legacyPayment('00001', 330, '00001');
  });
  afterAll(async () => {
    await wipe();
  });

  it('opens, lists and walks over a legacy payment', async () => {
    expect(await getPayment(runtime, scopeOf('002'), '00001')).toMatchObject({
      amount: 330,
      partyAc: PARTY,
      mode: 'cash',
    });
    const list = await recentVouchers(
      runtime,
      { tenantId: TENANT, coCode: CO, lcCode: LC, coYear: YEAR },
      'CASH_DATA',
      '002',
    );
    expect(list.map((v) => [v.vchNo, v.total])).toEqual([['00001', 330]]);
    expect(
      await neighbourVoucher(
        runtime,
        { tenantId: TENANT, coCode: CO, lcCode: LC, coYear: YEAR },
        'CASH_DATA',
        '002',
        '',
        'previous',
      ),
    ).toEqual({ action: 'open', vchNo: '00001' });
    const doc = await financeVoucherData(runtime, 'payment', { ...scopeOf('002'), vchNo: '00001' });
    expect(Number(doc?.header.NET_AMT)).toBe(330);
  });

  it('numbers the next payment after the legacy one, with no duplicate key', async () => {
    const next = await postPayment(runtime, {
      scope: scopeOf('002'),
      partyAc: PARTY,
      amount: 5,
      mode: 'cash',
      vchDate: '2024-05-02',
    } as never);
    expect(next.vchNo).toBe(2);
  });

  it('edits a legacy payment into CASH_DATA and removes its PAY_DATA row', async () => {
    await editPayment(
      runtime,
      {
        scope: scopeOf('002'),
        partyAc: PARTY,
        amount: 360,
        mode: 'cash',
        vchDate: '2024-05-01',
      } as never,
      '00001',
    );
    expect(await count('PAY_DATA')).toBe(0);
    expect((await cashRows('002')).map((r) => [r.VCH_NO, r.rec])).toEqual([['00001', 360]]);
    expect((await ledger('002', '00001')).map((l) => [l.k, l.dr, l.cr])).toEqual([
      ['105', 360, 0],
      ['106', 0, 360],
    ]);
  });

  it('deletes a legacy payment, even one saved before the hidden number existed', async () => {
    await exec(`UPDATE "PAY_DATA" SET "HD_VCH_NO"=NULL WHERE tenant_id=$1`, TENANT);
    await deletePayment(runtime, { scope: scopeOf('002'), vchNo: '00001', deleteUser: 'tester' });
    expect([
      await count('PAY_DATA'),
      await count('AC_DATA', '002'),
      await count('DELETE_DATA', '002'),
    ]).toEqual([0, 0, 1]);
  });
});

describe.runIf(RUN)('Contra writes the MAIN_BOOK as BOOK_NAME (TR_CONTRA.cs:2776, :2828)', () => {
  beforeEach(async () => {
    await wipe();
    await seed();
  });
  afterAll(async () => {
    await wipe();
  });

  it('CONTRA_DATA, AC_DATA and ROJ_MEL_DATA carry CONTRA; only TEMP_BOOK_DATA carries the form name', async () => {
    await postContra(runtime, {
      scope: scopeOf('017'),
      lines: [
        { crdr: 'DR', acCode: BANK, amount: 900 },
        { crdr: 'CR', acCode: CASH, amount: 900 },
      ],
      vchDate: '2024-05-01',
      mainUser: 'tester',
    } as never);
    const names = await rows(
      `SELECT 'CONTRA_DATA' t, "BOOK_NAME" n FROM "CONTRA_DATA" WHERE tenant_id=$1
       UNION ALL SELECT 'AC_DATA', "BOOK_NAME" FROM "AC_DATA" WHERE tenant_id=$1
       UNION ALL SELECT 'ROJ_MEL_DATA', "BOOK_NAME" FROM "ROJ_MEL_DATA" WHERE tenant_id=$1
       UNION ALL SELECT 'TEMP_BOOK_DATA', "BOOK_NAME" FROM "TEMP_BOOK_DATA" WHERE tenant_id=$1 ORDER BY 1`,
    );
    expect([...new Set(names.filter((r) => r.t !== 'TEMP_BOOK_DATA').map((r) => r.n))]).toEqual([
      'CONTRA',
    ]);
    expect(names.filter((r) => r.t === 'TEMP_BOOK_DATA').map((r) => r.n)).toEqual(['Contra Entry']);
  });
});
