import { PrismaClient } from '@prisma/client';
import { afterAll, beforeAll, beforeEach, describe, expect, it } from 'vitest';
import {
  deleteCreditNote,
  getCreditNoteEntry,
  getCreditNoteEntryConfig,
  saveCreditNote,
  type CreditNoteInput,
} from '../src/modules/einvoice/creditNoteWriter.js';
import { getCreditNote, listCreditNotes } from '../src/modules/einvoice/creditNote.js';
import type { VoucherScope } from '../src/modules/vouchers/numbering.js';
import { seedECreditNoteFixture } from './fixtures/eCreditNoteSeed.js';

/**
 * X15 — E CRNT create / reopen / edit / delete against a real PostgreSQL database.
 *
 * Expected rows are derived by hand from TR_SL_EBILL and the E-invoice posting helpers (see
 * parity-plan-2026-09-10/evidence/implementation-2026-09-29-x15/ecrnt-lifecycle-contract.md and the
 * core vectors B01/B02). They are NOT read back from the implementation.
 */
const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const databaseDescribe = RUN ? describe : describe.skip;
const TENANT = 'e-crnt-lifecycle-db';
const CO = '01';
const LC = '01';
const YEAR = '2024-2025';
const BOOK = '146';
const DAY = '2024-06-10';
const BASE = `${CO}${LC}${YEAR}${BOOK}00001`;
const STR = (n: number) => String(n).padStart(10, ' ');

const scope = (coBook = BOOK, coYear = YEAR): VoucherScope => ({
  tenantId: TENANT,
  coCode: CO,
  lcCode: LC,
  coYear,
  coBook,
});

let owner: PrismaClient;
let runtime: PrismaClient;
const exec = (sql: string, ...params: unknown[]) => owner.$executeRawUnsafe(sql, ...params);
const query = <T = Record<string, unknown>>(sql: string, ...params: unknown[]): Promise<T[]> =>
  owner.$queryRawUnsafe(sql, ...params) as Promise<T[]>;
const where = (book = BOOK) =>
  `tenant_id='${TENANT}' AND "CO_CODE"='${CO}' AND "LC_CODE"='${LC}' AND "CO_YEAR"='${YEAR}' AND "CO_BOOK"='${book}'`;

async function wipe() {
  const rows = await query<{ table_name: string }>(
    `SELECT DISTINCT table_name FROM information_schema.columns WHERE table_schema='public' AND column_name='tenant_id'`,
  );
  for (const row of rows) await exec(`DELETE FROM "${row.table_name}" WHERE tenant_id=$1`, TENANT);
}

async function seed(options: { companyType?: string; employeeMandatory?: boolean } = {}) {
  await seedECreditNoteFixture(exec, TENANT, options);
}

const lineOne = {
  itemCode: 'GOLD',
  pcs: 1,
  grossWt: 10,
  lessWt: 0.5,
  rate: 6000,
  rateType: 'G',
  labourType: 'G',
  labourRate: 500,
  otherAmount: 250,
  taxCode: '10',
  designNo: 'D-7',
  remark: 'returned ring',
};
const lineTwo = {
  itemCode: 'CHAIN',
  pcs: 3,
  rate: 1234.5,
  labourType: 'P',
  labourRate: 100,
  taxCode: '10',
};
const input = (overrides: Partial<CreditNoteInput> = {}): CreditNoteInput => ({
  scope: scope(),
  vchDate: DAY,
  partyCode: 'CUST01',
  billNo: 'REF-9',
  employeeCode: 'E01',
  description: 'rate difference',
  cashAmount: 10000,
  lines: [lineOne, lineTwo],
  mainUser: 'operator1',
  ...overrides,
});

const numbers = (rows: Record<string, unknown>[], keys: string[]) =>
  rows.map((row) =>
    Object.fromEntries(Object.entries(row).map(([k, v]) => [k, keys.includes(k) ? Number(v) : v])),
  );

databaseDescribe('X15 E CRNT lifecycle (TR_SL_EBILL E CRNT mode)', () => {
  beforeAll(() => {
    owner = new PrismaClient({
      datasources: { db: { url: process.env.MIGRATE_DATABASE_URL ?? process.env.DATABASE_URL } },
    });
    runtime = new PrismaClient({ datasources: { db: { url: process.env.DATABASE_URL } } });
  });
  beforeEach(async () => {
    await wipe();
    await seed();
  });
  afterAll(async () => {
    await wipe();
    await owner.$disconnect();
    await runtime.$disconnect();
  });

  it('creates a credit note entirely through the writer with the desktop write set', async () => {
    const saved = await saveCreditNote(runtime, input());
    expect(saved).toMatchObject({
      voucherNo: '00001',
      hiddenVoucherNo: '00001',
      created: true,
      lines: 2,
    });
    expect(saved.totals).toMatchObject({
      netAmount: 65954,
      taxAmount: 1978.62,
      totalAmount: 67933,
      roundOff: 0.38,
      outstanding: 57933,
    });

    const [header] = await query(`SELECT * FROM "SL_DATA" WHERE ${where()}`);
    expect(
      numbers(
        [header!],
        [
          'NET_AMT',
          'TAX_AMT',
          'CGST_TAX',
          'SGST_TAX',
          'IGST_TAX',
          'ROF_AMT',
          'TOT_AMT',
          'CASH_AMT',
          'BILL_OS',
          'LBR_AMT',
          'OTH_AMT',
        ],
      )[0],
    ).toMatchObject({
      VCH_NO: '00001',
      HD_VCH_NO: '00001',
      AC_CODE: 'CUST01',
      AC_NAME: 'Credit Customer',
      BILL_NO: 'REF-9',
      AC_GST_TYPE: 'L',
      NET_AMT: 65954,
      TAX_AMT: 1978.62,
      CGST_TAX: 989.31,
      SGST_TAX: 989.31,
      IGST_TAX: 0,
      ROF_AMT: 0.38,
      TOT_AMT: 67933,
      CASH_AMT: 10000,
      BILL_OS: 57933,
      LBR_AMT: 5300,
      OTH_AMT: 250,
      IRN_NO: 'N',
      USER_UPDATE: 'N',
      USER_DELETE: 'N',
      MOB_ENTRY_SAVE: 'Y',
      RATE_UNFIX: 'N',
      DATA_TRFR: 'N',
      EMP_CODE: 'E01',
      MAIN_USER: 'operator1',
      VCH_DESC: 'rate difference',
    });

    const lines = await query(
      `SELECT "SR_NO","OLD_SRNO","IT_CODE","TAG_NO","ITM_NWT","ITM_FINE","ITM_AMT","LBR_AMT","TOT_AMT","NET_AMT","TAXABL_RATE",
              "ITM_CGST_AMT","ITM_SGST_AMT","IT_TAX_AMT","GRAND_TOTAL","RATE_TYPE","BOOK_NAME","VCH_TYPE","INOUT_TYPE","ENTRY_TYPE","AC_CODE","DISC_AMT"
         FROM "SL_DETL" WHERE ${where()} ORDER BY "SR_NO"`,
    );
    expect(
      numbers(lines, [
        'SR_NO',
        'OLD_SRNO',
        'ITM_NWT',
        'ITM_FINE',
        'ITM_AMT',
        'LBR_AMT',
        'TOT_AMT',
        'NET_AMT',
        'TAXABL_RATE',
        'ITM_CGST_AMT',
        'ITM_SGST_AMT',
        'IT_TAX_AMT',
        'GRAND_TOTAL',
        'DISC_AMT',
      ]),
    ).toEqual([
      {
        SR_NO: 1,
        OLD_SRNO: 1,
        IT_CODE: 'GOLD',
        TAG_NO: 'N',
        ITM_NWT: 9.5,
        ITM_FINE: 9.5,
        ITM_AMT: 57000,
        LBR_AMT: 5000,
        TOT_AMT: 62250,
        NET_AMT: 62250,
        TAXABL_RATE: 6552.632,
        ITM_CGST_AMT: 933.75,
        ITM_SGST_AMT: 933.75,
        IT_TAX_AMT: 1867.5,
        GRAND_TOTAL: 64118,
        RATE_TYPE: 'G',
        BOOK_NAME: 'E CRNT',
        VCH_TYPE: 'ECRNT',
        INOUT_TYPE: 'I',
        ENTRY_TYPE: 'O',
        AC_CODE: 'CUST01',
        DISC_AMT: 0,
      },
      {
        SR_NO: 2,
        OLD_SRNO: 2,
        IT_CODE: 'CHAIN',
        TAG_NO: 'N',
        ITM_NWT: 0,
        ITM_FINE: 0,
        ITM_AMT: 3704,
        LBR_AMT: 300,
        TOT_AMT: 3704,
        NET_AMT: 3704,
        TAXABL_RATE: 1234.667,
        ITM_CGST_AMT: 55.56,
        ITM_SGST_AMT: 55.56,
        IT_TAX_AMT: 111.12,
        GRAND_TOTAL: 3815,
        RATE_TYPE: 'P',
        BOOK_NAME: 'E CRNT',
        VCH_TYPE: 'ECRNT',
        INOUT_TYPE: 'I',
        ENTRY_TYPE: 'O',
        AC_CODE: 'CUST01',
        DISC_AMT: 0,
      },
    ]);

    const ledger = await query(
      `SELECT "LEDR_KEY","AC_CODE","LD_CODE","CR_AMT","DR_AMT","PARTY_AC_CODE","LDR_NAME","BOOK_NAME","VCH_TYPE","BILL_NO"
         FROM "AC_DATA" WHERE ${where()} ORDER BY "LEDR_KEY" COLLATE "C"`,
    );
    expect(numbers(ledger, ['CR_AMT', 'DR_AMT'])).toEqual([
      {
        LEDR_KEY: `${BASE}${STR(1)}02`,
        AC_CODE: 'SALE01',
        LD_CODE: 'CUST01',
        CR_AMT: 0,
        DR_AMT: 62250,
        PARTY_AC_CODE: '',
        LDR_NAME: '',
        BOOK_NAME: 'E CRNT',
        VCH_TYPE: 'ECRNT',
        BILL_NO: '',
      },
      {
        LEDR_KEY: `${BASE}${STR(2)}02`,
        AC_CODE: 'SALE01',
        LD_CODE: 'CUST01',
        CR_AMT: 0,
        DR_AMT: 3704,
        PARTY_AC_CODE: '',
        LDR_NAME: '',
        BOOK_NAME: 'E CRNT',
        VCH_TYPE: 'ECRNT',
        BILL_NO: '',
      },
      {
        LEDR_KEY: `${BASE}01`,
        AC_CODE: 'CUST01',
        LD_CODE: 'CRN001',
        CR_AMT: 67933,
        DR_AMT: 0,
        PARTY_AC_CODE: 'CUST01',
        LDR_NAME: 'Credit Customer',
        BOOK_NAME: 'E CRNT',
        VCH_TYPE: 'ECRNT',
        BILL_NO: 'REF-9',
      },
      {
        LEDR_KEY: `${BASE}03`,
        AC_CODE: 'GST001',
        LD_CODE: 'CUST01',
        CR_AMT: 0,
        DR_AMT: 1978.62,
        PARTY_AC_CODE: '',
        LDR_NAME: '',
        BOOK_NAME: 'E CRNT',
        VCH_TYPE: 'ECRNT',
        BILL_NO: 'REF-9',
      },
      {
        LEDR_KEY: `${BASE}11`,
        AC_CODE: 'CUST01',
        LD_CODE: 'CASH01',
        CR_AMT: 0,
        DR_AMT: 10000,
        PARTY_AC_CODE: 'CUST01',
        LDR_NAME: '',
        BOOK_NAME: 'E CRNT',
        VCH_TYPE: 'ECRNT',
        BILL_NO: 'REF-9',
      },
      {
        LEDR_KEY: `${BASE}12`,
        AC_CODE: 'CASH01',
        LD_CODE: 'CUST01',
        CR_AMT: 10000,
        DR_AMT: 0,
        PARTY_AC_CODE: '',
        LDR_NAME: 'Credit Customer',
        BOOK_NAME: 'E CRNT',
        VCH_TYPE: 'ECRNT',
        BILL_NO: 'REF-9',
      },
      {
        LEDR_KEY: `${BASE}16`,
        AC_CODE: 'ROF001',
        LD_CODE: 'CUST01',
        CR_AMT: 0,
        DR_AMT: 0.38,
        PARTY_AC_CODE: '',
        LDR_NAME: '',
        BOOK_NAME: 'E CRNT',
        VCH_TYPE: 'ECRNT',
        BILL_NO: 'REF-9',
      },
    ]);

    const rojmel = await query(
      `SELECT "LEDR_KEY","AC_CODE","LD_CODE","CR_AMT","DR_AMT","AC_NAME","IT_DESC","IT_CODE","ITM_AMT","NET_AMT"
         FROM "ROJ_MEL_DATA" WHERE ${where()} ORDER BY "LEDR_KEY" COLLATE "C"`,
    );
    expect(numbers(rojmel, ['CR_AMT', 'DR_AMT', 'ITM_AMT', 'NET_AMT'])).toEqual([
      {
        LEDR_KEY: `${BASE}01${STR(1)}`,
        AC_CODE: 'SALE01',
        LD_CODE: 'CUST01',
        CR_AMT: 0,
        DR_AMT: 62250,
        AC_NAME: '',
        IT_DESC: 'Gold Ring',
        IT_CODE: 'GOLD',
        ITM_AMT: 57000,
        NET_AMT: 62250,
      },
      {
        LEDR_KEY: `${BASE}01${STR(2)}`,
        AC_CODE: 'SALE01',
        LD_CODE: 'CUST01',
        CR_AMT: 0,
        DR_AMT: 3704,
        AC_NAME: '',
        IT_DESC: 'Gold Chain Pc',
        IT_CODE: 'CHAIN',
        ITM_AMT: 3704,
        NET_AMT: 3704,
      },
      {
        LEDR_KEY: `${BASE}02`,
        AC_CODE: 'CUST01',
        LD_CODE: 'CRN001',
        CR_AMT: 57933,
        DR_AMT: 0,
        AC_NAME: 'Credit Customer',
        IT_DESC: 'rate difference',
        IT_CODE: '',
        ITM_AMT: 0,
        NET_AMT: 0,
      },
      {
        LEDR_KEY: `${BASE}03`,
        AC_CODE: 'GST001',
        LD_CODE: 'CUST01',
        CR_AMT: 0,
        DR_AMT: 1978.62,
        AC_NAME: 'Output GST',
        IT_DESC: 'rate difference',
        IT_CODE: '',
        ITM_AMT: 0,
        NET_AMT: 0,
      },
    ]);

    const stock = await query(
      `SELECT "SR_NO","ISR_NO","TR_TYPE","ITM_SIGN","ITM_QTY","IT_CODE","ITM_GWT","ITM_NWT","NET_AMT","STK_DATE","TAG_NO"
         FROM "MAIN_STOCK" WHERE ${where()} ORDER BY "ISR_NO"`,
    );
    expect(numbers(stock, ['SR_NO', 'ISR_NO', 'ITM_QTY', 'ITM_GWT', 'ITM_NWT', 'NET_AMT'])).toEqual(
      [
        {
          SR_NO: 1,
          ISR_NO: 1,
          TR_TYPE: 'I',
          ITM_SIGN: '+',
          ITM_QTY: 1,
          IT_CODE: 'GOLD',
          ITM_GWT: 10,
          ITM_NWT: 9.5,
          NET_AMT: 62250,
          STK_DATE: DAY,
          TAG_NO: 'N',
        },
        {
          SR_NO: 1,
          ISR_NO: 2,
          TR_TYPE: 'I',
          ITM_SIGN: '+',
          ITM_QTY: 1,
          IT_CODE: 'CHAIN',
          ITM_GWT: 0,
          ITM_NWT: 0,
          NET_AMT: 3704,
          STK_DATE: DAY,
          TAG_NO: 'N',
        },
      ],
    );

    const tax = await query(
      `SELECT "SR_NO","ISR_NO","TAX_CODE","TAX_TYPE","TAX_PRC","TAX_AMT","NET_AMT","TOT_AMT","TAX_SIGN","TRAN_TYPE","PARTY_NAME"
         FROM "TAX_DATA" WHERE ${where()} ORDER BY "SR_NO"`,
    );
    expect(numbers(tax, ['SR_NO', 'ISR_NO', 'TAX_PRC', 'TAX_AMT', 'NET_AMT', 'TOT_AMT'])).toEqual([
      {
        SR_NO: 1,
        ISR_NO: 1,
        TAX_CODE: '10',
        TAX_TYPE: 'SGST',
        TAX_PRC: 1.5,
        TAX_AMT: 933.75,
        NET_AMT: 62250,
        TOT_AMT: 64118,
        TAX_SIGN: '-',
        TRAN_TYPE: 'S',
        PARTY_NAME: 'Credit Customer',
      },
      {
        SR_NO: 2,
        ISR_NO: 2,
        TAX_CODE: '10',
        TAX_TYPE: 'SGST',
        TAX_PRC: 1.5,
        TAX_AMT: 55.56,
        NET_AMT: 3704,
        TOT_AMT: 3815,
        TAX_SIGN: '-',
        TRAN_TYPE: 'S',
        PARTY_NAME: 'Credit Customer',
      },
      {
        SR_NO: 112,
        ISR_NO: 1,
        TAX_CODE: '10',
        TAX_TYPE: 'CGST',
        TAX_PRC: 1.5,
        TAX_AMT: 933.75,
        NET_AMT: 62250,
        TOT_AMT: 64118,
        TAX_SIGN: '-',
        TRAN_TYPE: 'S',
        PARTY_NAME: 'Credit Customer',
      },
      {
        SR_NO: 113,
        ISR_NO: 2,
        TAX_CODE: '10',
        TAX_TYPE: 'CGST',
        TAX_PRC: 1.5,
        TAX_AMT: 55.56,
        NET_AMT: 3704,
        TOT_AMT: 3815,
        TAX_SIGN: '-',
        TRAN_TYPE: 'S',
        PARTY_NAME: 'Credit Customer',
      },
    ]);

    expect(
      await query(
        `SELECT "VCH_NO","BOOK_NAME" FROM "TEMP_BOOK_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2`,
        TENANT,
        BOOK,
      ),
    ).toEqual([{ VCH_NO: '00001', BOOK_NAME: 'E Credit Note' }]);
    expect(await query(`SELECT 1 FROM "DM_DATA" WHERE ${where()}`)).toEqual([]);

    // Reopen through both readers.
    const entry = await getCreditNoteEntry(runtime, scope(), '1');
    expect(entry).toMatchObject({
      voucherNo: '00001',
      partyCode: 'CUST01',
      billNo: 'REF-9',
      cashAmount: 10000,
      irnLocked: false,
      totals: { totalAmount: 67933, outstanding: 57933, roundOff: 0.38 },
    });
    expect(entry!.lines).toHaveLength(2);
    expect(entry!.lines[0]).toMatchObject({
      oldSrNo: 1,
      itemCode: 'GOLD',
      grossWt: 10,
      lessWt: 0.5,
      rate: 6000,
      labourRate: 500,
      otherAmount: 250,
      designNo: 'D-7',
      remark: 'returned ring',
      tagNo: '',
    });
    const document = await getCreditNote(runtime, scope(), '00001');
    expect(document?.lines).toHaveLength(2);
    const browse = await listCreditNotes(runtime, scope());
    expect(browse.rows.map((r) => r.VCH_NO)).toEqual(['00001']);
    // Other-year sentinel untouched.
    expect(
      await query(
        `SELECT "TOT_AMT"::float AS "TOT_AMT" FROM "SL_DATA" WHERE tenant_id=$1 AND "CO_YEAR"='2025-2026'`,
        TENANT,
      ),
    ).toEqual([{ TOT_AMT: 999 }]);
  });

  it('keeps the same voucher number in two E CRNT books independent', async () => {
    await saveCreditNote(runtime, input());
    const second = await saveCreditNote(
      runtime,
      input({ scope: scope('147'), cashAmount: 0, lines: [lineTwo] }),
    );
    expect(second.voucherNo).toBe('00001');
    const totals = await query<{ CO_BOOK: string; TOT_AMT: number }>(
      `SELECT "CO_BOOK","TOT_AMT" FROM "SL_DATA" WHERE tenant_id=$1 AND "CO_YEAR"=$2 ORDER BY "CO_BOOK"`,
      TENANT,
      YEAR,
    );
    expect(totals.map((t) => [t.CO_BOOK, Number(t.TOT_AMT)])).toEqual([
      ['146', 67933],
      ['147', 3815],
    ]);
    await deleteCreditNote(runtime, scope('147'), '00001');
    expect(await query(`SELECT 1 FROM "AC_DATA" WHERE ${where()}`)).toHaveLength(7);
  });

  it('edits in place, preserving identity and component rows, and refuses a stale revision', async () => {
    await saveCreditNote(runtime, input());
    const opened = await getCreditNoteEntry(runtime, scope(), '00001');
    const [before] = await query<{ VCH_TIME: Date; row_count: number }>(
      `SELECT "VCH_TIME" FROM "SL_DATA" WHERE ${where()}`,
    );
    // An imported stone component under line 1 (OLD_SRNO 1) must survive an edit of its parent.
    await exec(
      `INSERT INTO "SL_IDTL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","ISR_NO","DM_NAME","IT_GWT","IT_NET_AMT")
       VALUES ($1,$2,$3,$4,$5,'00001',1,1,'Ruby',0.123,450)`,
      TENANT,
      CO,
      LC,
      YEAR,
      BOOK,
    );
    await expect(
      saveCreditNote(runtime, input({ expectedRevision: opened!.revision }), '00001'),
    ).rejects.toMatchObject({ name: 'CreditNoteConflictError' });

    const reopened = await getCreditNoteEntry(runtime, scope(), '00001');
    const edited = await saveCreditNote(
      runtime,
      input({
        mainUser: 'someone-else',
        cashAmount: 0,
        expectedRevision: reopened!.revision,
        lines: [{ ...lineOne, oldSrNo: 1, rate: 6100 }],
      }),
      '00001',
    );
    expect(edited).toMatchObject({
      voucherNo: '00001',
      hiddenVoucherNo: '00001',
      created: false,
      lines: 1,
    });
    // 9.5*6100=57950; taxable 63200; CGST=SGST 948; 65096 → total 65096, round-off 0.
    expect(edited.totals).toMatchObject({
      netAmount: 63200,
      taxAmount: 1896,
      totalAmount: 65096,
      roundOff: 0,
    });
    const [after] = await query<{ VCH_TIME: Date; MAIN_USER: string }>(
      `SELECT "VCH_TIME","MAIN_USER" FROM "SL_DATA" WHERE ${where()}`,
    );
    expect(after!.MAIN_USER).toBe('operator1');
    expect(new Date(after!.VCH_TIME).getTime()).toBe(new Date(before!.VCH_TIME).getTime());
    expect(await query(`SELECT "DM_NAME" FROM "SL_IDTL" WHERE ${where()}`)).toEqual([
      { DM_NAME: 'Ruby' },
    ]);
    const ledger = await query<{ LEDR_KEY: string; CR_AMT: number; DR_AMT: number }>(
      `SELECT "LEDR_KEY","CR_AMT","DR_AMT" FROM "AC_DATA" WHERE ${where()} ORDER BY "LEDR_KEY" COLLATE "C"`,
    );
    expect(
      ledger.map((r) => [r.LEDR_KEY.slice(BASE.length), Number(r.CR_AMT), Number(r.DR_AMT)]),
    ).toEqual([
      [`${STR(1)}02`, 0, 63200],
      ['01', 65096, 0],
      ['03', 0, 1896],
    ]);
    expect(await query(`SELECT 1 FROM "MAIN_STOCK" WHERE ${where()}`)).toHaveLength(1);
    expect(await query(`SELECT 1 FROM "TEMP_BOOK_DATA" WHERE tenant_id=$1`, TENANT)).toHaveLength(
      1,
    );
  });

  it('balances a negative round-off by crediting its absolute value (documented adaptation)', async () => {
    const saved = await saveCreditNote(
      runtime,
      input({
        cashAmount: 0,
        chequeAmount: 40,
        chequeAccount: 'BANK01',
        lines: [{ itemCode: 'GOLD', pcs: 2, grossWt: 4, rate: 100, mrp: 1010, taxCode: '10' }],
      }),
    );
    expect(saved.totals).toMatchObject({ totalAmount: 1040, roundOff: -0.3, outstanding: 1000 });
    const ledger = await query<{
      LEDR_KEY: string;
      AC_CODE: string;
      CR_AMT: number;
      DR_AMT: number;
    }>(
      `SELECT "LEDR_KEY","AC_CODE","CR_AMT","DR_AMT" FROM "AC_DATA" WHERE ${where()} ORDER BY "LEDR_KEY" COLLATE "C"`,
    );
    expect(
      ledger.map((r) => [
        r.LEDR_KEY.slice(BASE.length),
        r.AC_CODE,
        Number(r.CR_AMT),
        Number(r.DR_AMT),
      ]),
    ).toEqual([
      [`${STR(1)}02`, 'SALE01', 0, 1010],
      ['01', 'CUST01', 1040, 0],
      ['03', 'GST001', 0, 30.3],
      ['07', 'CUST01', 0, 40],
      ['08', 'BANK01', 40, 0],
      ['16', 'ROF001', 0.3, 0],
    ]);
    const sum = ledger.reduce((s, r) => s + Number(r.CR_AMT) - Number(r.DR_AMT), 0);
    expect(Math.abs(sum)).toBeLessThan(1e-9);
    const rojmel = await query<{ LEDR_KEY: string; CR_AMT: number }>(
      `SELECT "LEDR_KEY","CR_AMT" FROM "ROJ_MEL_DATA" WHERE ${where()} AND "CR_AMT" <> 0 ORDER BY "LEDR_KEY" COLLATE "C"`,
    );
    expect(rojmel.map((r) => [r.LEDR_KEY.slice(BASE.length), Number(r.CR_AMT)])).toEqual([
      ['02', 1000],
      ['06', 40],
    ]);
  });

  it('posts IGST for an inter-state party', async () => {
    await saveCreditNote(
      runtime,
      input({
        partyCode: 'CUST02',
        cashAmount: 0,
        lines: [
          {
            itemCode: 'GOLD',
            pcs: 1,
            grossWt: 5,
            touch: 91.6,
            westPercent: 2,
            rate: 60000,
            rateType: '1',
            labourType: 'N',
            labourRate: 450,
            taxCode: '10',
          },
        ],
      }),
    );
    const tax = await query(
      `SELECT "SR_NO","TAX_TYPE","TAX_PRC","TAX_AMT" FROM "TAX_DATA" WHERE ${where()}`,
    );
    expect(numbers(tax, ['SR_NO', 'TAX_PRC', 'TAX_AMT'])).toEqual([
      { SR_NO: 1, TAX_TYPE: 'IGST', TAX_PRC: 3, TAX_AMT: 909.9 },
    ]);
    const [header] = await query(
      `SELECT "AC_GST_TYPE","IGST_TAX","TOT_AMT","ROF_AMT" FROM "SL_DATA" WHERE ${where()}`,
    );
    expect(numbers([header!], ['IGST_TAX', 'TOT_AMT', 'ROF_AMT'])[0]).toEqual({
      AC_GST_TYPE: 'I',
      IGST_TAX: 909.9,
      TOT_AMT: 31240,
      ROF_AMT: 0.1,
    });
  });

  it('deletes with the desktop audit row and blocks edit/delete once an IRN exists', async () => {
    await saveCreditNote(runtime, input());
    await exec(
      `INSERT INTO "E_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","IRN_NO","ACK_NO")
       VALUES ($1,$2,$3,$4,$5,'00001',$6,'123456789012')`,
      TENANT,
      CO,
      LC,
      YEAR,
      BOOK,
      'x'.repeat(64),
    );
    await expect(deleteCreditNote(runtime, scope(), '00001')).rejects.toThrow('Irn No Is Genrate');
    await expect(saveCreditNote(runtime, input(), '00001')).rejects.toThrow('Irn No Is Genrate');
    expect((await getCreditNoteEntry(runtime, scope(), '00001'))!.irnLocked).toBe(true);
    await exec(`DELETE FROM "E_DATA" WHERE tenant_id=$1`, TENANT);

    await deleteCreditNote(runtime, scope(), '00001', { deleteUser: 'auditor' });
    for (const table of [
      'SL_DATA',
      'SL_DETL',
      'SL_IDTL',
      'AC_DATA',
      'ROJ_MEL_DATA',
      'MAIN_STOCK',
      'TAX_DATA',
    ]) {
      expect(await query(`SELECT 1 FROM "${table}" WHERE ${where()}`)).toEqual([]);
    }
    expect(await query(`SELECT 1 FROM "TEMP_BOOK_DATA" WHERE tenant_id=$1`, TENANT)).toEqual([]);
    const audit = await query(
      `SELECT "SR_NO","VCH_TYPE","BOOK_NAME","AC_CODE","AC_NAME","VCH_VAL_DR","VCH_VAL_CR","FINE_TYPE","HD_VCH_NO","MAIN_USER","DELETE_USER","VCH_DESC"
         FROM "DELETE_DATA" WHERE ${where()}`,
    );
    expect(numbers(audit, ['SR_NO', 'VCH_VAL_DR', 'VCH_VAL_CR'])).toEqual([
      {
        SR_NO: 0,
        VCH_TYPE: 'ECRNT',
        BOOK_NAME: 'E Credit Note',
        AC_CODE: 'CUST01',
        AC_NAME: 'Credit Customer',
        VCH_VAL_DR: 0,
        VCH_VAL_CR: 0,
        FINE_TYPE: 'A',
        HD_VCH_NO: '00001',
        MAIN_USER: 'operator1',
        DELETE_USER: 'auditor',
        VCH_DESC: '0',
      },
    ]);
    expect(
      await query(
        `SELECT "TOT_AMT"::float AS "TOT_AMT" FROM "SL_DATA" WHERE tenant_id=$1 AND "CO_YEAR"='2025-2026'`,
        TENANT,
      ),
    ).toEqual([{ TOT_AMT: 999 }]);
  });

  it('applies the desktop save validations and writes nothing on refusal', async () => {
    const refusals: Array<[Partial<CreditNoteInput>, string]> = [
      [{ partyCode: '' }, 'Please Insert Party and try'],
      [{ chequeAmount: 5 }, 'Please Select Bank Account'],
      [{ cardAmount: 5 }, 'Please Select Card Bank Account'],
      [{ tdsCode: 'TD' }, 'TDS is not supported'],
      [{ tcsCode: '20' }, 'TCS is not supported'],
      [{ lines: [{ ...lineOne, tagNo: 'T0001' }] }, 'tagged credit-note lines'],
      [{ lines: [{ pcs: 0 }] }, 'enter at least one line'],
      [{ vchDate: '2026-01-01' }, 'outside fiscal year'],
      [{ cashAmount: 999999 }, 'payments exceed'],
    ];
    for (const [overrides, message] of refusals) {
      await expect(saveCreditNote(runtime, input(overrides))).rejects.toThrow(message);
    }
    await exec(`UPDATE "GROUP_MAST" SET "SALE_AC"='' WHERE tenant_id=$1`, TENANT);
    await expect(saveCreditNote(runtime, input())).rejects.toThrow('no group sale account');
    for (const table of [
      'SL_DATA',
      'SL_DETL',
      'AC_DATA',
      'ROJ_MEL_DATA',
      'MAIN_STOCK',
      'TAX_DATA',
    ]) {
      expect(await query(`SELECT 1 FROM "${table}" WHERE ${where()}`)).toEqual([]);
    }
    expect(await query(`SELECT 1 FROM "TEMP_BOOK_DATA" WHERE tenant_id=$1`, TENANT)).toEqual([]);
  });

  it('refuses a new voucher for company type B and a missing mandatory employee', async () => {
    await wipe();
    await seed({ companyType: 'B', employeeMandatory: true });
    await expect(saveCreditNote(runtime, input({ employeeCode: '' }))).rejects.toThrow(
      'Please Select Employee Code',
    );
    await expect(saveCreditNote(runtime, input())).rejects.toThrow('Company Type is B');
  });

  it('exposes the calculation policy the entry screen needs', async () => {
    const config = await getCreditNoteEntryConfig(runtime, scope());
    expect(config).toMatchObject({
      policy: { amountDigits: 0, taxDigits: 2, labourRateDigits: 0, labourIncludesGhat: true },
      defaultLabourType: 'G',
      defaultTaxCode: '10',
      taxCodes: [{ code: '10', name: 'GST 3%', percent: 3 }],
    });
    await expect(getCreditNoteEntryConfig(runtime, scope('999'))).rejects.toThrow('E CRNT');
  });
});
