import { PrismaClient } from '@datacare/db';
import { afterAll, beforeAll, beforeEach, describe, expect, it } from 'vitest';
import {
  deleteEBill,
  eInvoiceTcsBasis,
  getEBillEntry,
  getEBillEntryConfig,
  saveEBill,
  type EBillEntryInput,
} from '../src/modules/einvoice/eBillWriter.js';
import { getEInvoice, listEInvoices } from '../src/modules/einvoice/creditNote.js';
import type { VoucherScope } from '../src/modules/vouchers/numbering.js';
import { E_INVOICE_BOOK, seedEInvoiceFixture } from './fixtures/eCreditNoteSeed.js';

/**
 * X15 continuation — TR_SL_EBILL in E INVOICE mode against a real PostgreSQL database.
 *
 * Expected rows come from the E INVOICE branches of Ac_Ledr.EInvoice_Ledr, Ac_Rojmel.EInvoice_Rojmel,
 * Ac_Stock.EInvoice_Stk / Dm_Sale_eInv_Detl, Ac_Tax.EInvoice_GST and Vch_Remark, and from the hand
 * vectors EI-1..EI-3 in the X15 contract. They are not read back from the implementation.
 */
const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const databaseDescribe = RUN ? describe : describe.skip;
const TENANT = 'e-invoice-lifecycle-db';
const CO = '01';
const LC = '01';
const YEAR = '2024-2025';
const BOOK = E_INVOICE_BOOK;
const DAY = '2024-06-10';
const BASE = `${CO}${LC}${YEAR}${BOOK}00001`;
const STR = (n: number) => String(n).padStart(10, ' ');

const scope = (coBook = BOOK): VoucherScope => ({
  tenantId: TENANT,
  coCode: CO,
  lcCode: LC,
  coYear: YEAR,
  coBook,
});

let owner: PrismaClient;
let runtime: PrismaClient;
const exec = (sql: string, ...params: unknown[]) => owner.$executeRawUnsafe(sql, ...params);
const query = <T = Record<string, unknown>>(sql: string, ...params: unknown[]): Promise<T[]> =>
  owner.$queryRawUnsafe(sql, ...params) as Promise<T[]>;
const where = (book = BOOK) =>
  `tenant_id='${TENANT}' AND "CO_CODE"='${CO}' AND "LC_CODE"='${LC}' AND "CO_YEAR"='${YEAR}' AND "CO_BOOK"='${book}'`;
const numbers = (rows: Record<string, unknown>[], keys: string[]) =>
  rows.map((row) =>
    Object.fromEntries(Object.entries(row).map(([k, v]) => [k, keys.includes(k) ? Number(v) : v])),
  );

async function wipe() {
  const rows = await query<{ table_name: string }>(
    `SELECT DISTINCT table_name FROM information_schema.columns WHERE table_schema='public' AND column_name='tenant_id'`,
  );
  for (const row of rows) await exec(`DELETE FROM "${row.table_name}" WHERE tenant_id=$1`, TENANT);
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
};
const lineTwo = {
  itemCode: 'CHAIN',
  pcs: 3,
  rate: 1234.5,
  labourType: 'P',
  labourRate: 100,
  taxCode: '10',
};
const input = (overrides: Partial<EBillEntryInput> = {}): EBillEntryInput => ({
  scope: scope(),
  vchDate: DAY,
  partyCode: 'CUST01',
  billNo: 'INV-9',
  employeeCode: 'E01',
  description: 'invoice narration',
  cashAmount: 10000,
  tdsCode: '25',
  lines: [lineOne, lineTwo],
  mainUser: 'operator1',
  ...overrides,
});
const ledgerOf = async (): Promise<Array<Record<string, unknown>>> =>
  numbers(
    await query(
      `SELECT "LEDR_KEY","AC_CODE","LD_CODE","CR_AMT","DR_AMT","PARTY_AC_CODE","LDR_NAME"
         FROM "AC_DATA" WHERE ${where()} ORDER BY "LEDR_KEY" COLLATE "C"`,
    ),
    ['CR_AMT', 'DR_AMT'],
  ).map((r) => ({ ...r, LEDR_KEY: String(r.LEDR_KEY).slice(BASE.length) }));
const rojmelOf = async (): Promise<Array<Record<string, unknown>>> =>
  numbers(
    await query(
      `SELECT "LEDR_KEY","AC_CODE","LD_CODE","CR_AMT","DR_AMT","AC_NAME","VCH_TYPE"
         FROM "ROJ_MEL_DATA" WHERE ${where()} ORDER BY "LEDR_KEY" COLLATE "C"`,
    ),
    ['CR_AMT', 'DR_AMT'],
  ).map((r) => ({ ...r, LEDR_KEY: String(r.LEDR_KEY).slice(BASE.length) }));

databaseDescribe('X15 E INVOICE lifecycle (TR_SL_EBILL E INVOICE mode)', () => {
  beforeAll(() => {
    owner = new PrismaClient({
      datasources: { db: { url: process.env.MIGRATE_DATABASE_URL ?? process.env.DATABASE_URL } },
    });
    runtime = new PrismaClient({ datasources: { db: { url: process.env.DATABASE_URL } } });
  });
  beforeEach(async () => {
    await wipe();
    await seedEInvoiceFixture(exec, TENANT);
  });
  afterAll(async () => {
    await wipe();
    await owner.$disconnect();
    await runtime.$disconnect();
  });

  it('posts EI-1: outward orientation, TDS pair, stock out, output GST and both rojmel round-off rows', async () => {
    const saved = await saveEBill(runtime, 'E INVOICE', input());
    expect(saved.totals).toMatchObject({
      netAmount: 65954,
      taxAmount: 1978.62,
      totalAmount: 67933,
      roundOff: 0.38,
      tdsAmount: 660,
      tcsAmount: 0,
      outstanding: 57273,
    });
    const [header] = await query(
      `SELECT "TDS_CODE","TDS_PRC"::float AS "TDS_PRC","TDS_AMT"::float AS "TDS_AMT","TCS_CODE","TCS_AMT"::float AS "TCS_AMT",
              "BILL_OS"::float AS "BILL_OS","IRN_NO" FROM "SL_DATA" WHERE ${where()}`,
    );
    expect(header).toEqual({
      TDS_CODE: '25',
      TDS_PRC: 1,
      TDS_AMT: 660,
      TCS_CODE: '',
      TCS_AMT: 0,
      BILL_OS: 57273,
      IRN_NO: 'N',
    });

    expect(await ledgerOf()).toEqual([
      {
        LEDR_KEY: `${STR(1)}02`,
        AC_CODE: 'SALE01',
        LD_CODE: 'CUST01',
        CR_AMT: 62250,
        DR_AMT: 0,
        PARTY_AC_CODE: '',
        LDR_NAME: '',
      },
      {
        LEDR_KEY: `${STR(2)}02`,
        AC_CODE: 'SALE01',
        LD_CODE: 'CUST01',
        CR_AMT: 3704,
        DR_AMT: 0,
        PARTY_AC_CODE: '',
        LDR_NAME: '',
      },
      {
        LEDR_KEY: '01',
        AC_CODE: 'CUST01',
        LD_CODE: 'INV001',
        CR_AMT: 0,
        DR_AMT: 67933,
        PARTY_AC_CODE: 'CUST01',
        LDR_NAME: 'Credit Customer',
      },
      {
        LEDR_KEY: '03',
        AC_CODE: 'GST001',
        LD_CODE: 'CUST01',
        CR_AMT: 1978.62,
        DR_AMT: 0,
        PARTY_AC_CODE: '',
        LDR_NAME: '',
      },
      {
        LEDR_KEY: '05',
        AC_CODE: 'CUST01',
        LD_CODE: 'TDS001',
        CR_AMT: 660,
        DR_AMT: 0,
        PARTY_AC_CODE: '',
        LDR_NAME: '',
      },
      {
        LEDR_KEY: '06',
        AC_CODE: 'TDS001',
        LD_CODE: 'CUST01',
        CR_AMT: 0,
        DR_AMT: 660,
        PARTY_AC_CODE: '',
        LDR_NAME: '',
      },
      {
        LEDR_KEY: '11',
        AC_CODE: 'CUST01',
        LD_CODE: 'CASH01',
        CR_AMT: 10000,
        DR_AMT: 0,
        PARTY_AC_CODE: 'CUST01',
        LDR_NAME: '',
      },
      {
        LEDR_KEY: '12',
        AC_CODE: 'CASH01',
        LD_CODE: 'CUST01',
        CR_AMT: 0,
        DR_AMT: 10000,
        PARTY_AC_CODE: '',
        LDR_NAME: 'Credit Customer',
      },
      {
        LEDR_KEY: '15',
        AC_CODE: 'ROF005',
        LD_CODE: 'CUST01',
        CR_AMT: 0.38,
        DR_AMT: 0,
        PARTY_AC_CODE: '',
        LDR_NAME: '',
      },
    ]);

    expect(await rojmelOf()).toEqual([
      {
        LEDR_KEY: `01${STR(1)}`,
        AC_CODE: 'SALE01',
        LD_CODE: 'CUST01',
        CR_AMT: 62250,
        DR_AMT: 0,
        AC_NAME: '',
        VCH_TYPE: 'EINV',
      },
      {
        LEDR_KEY: `01${STR(2)}`,
        AC_CODE: 'SALE01',
        LD_CODE: 'CUST01',
        CR_AMT: 3704,
        DR_AMT: 0,
        AC_NAME: '',
        VCH_TYPE: 'EINV',
      },
      {
        LEDR_KEY: '02',
        AC_CODE: 'CUST01',
        LD_CODE: 'INV001',
        CR_AMT: 0,
        DR_AMT: 57273,
        AC_NAME: 'Credit Customer',
        VCH_TYPE: 'EINV',
      },
      {
        LEDR_KEY: '03',
        AC_CODE: 'GST001',
        LD_CODE: 'CUST01',
        CR_AMT: 1978.62,
        DR_AMT: 0,
        AC_NAME: 'Output GST',
        VCH_TYPE: 'EINV',
      },
      {
        LEDR_KEY: '05',
        AC_CODE: 'TDS001',
        LD_CODE: 'CUST01',
        CR_AMT: 0,
        DR_AMT: 660,
        AC_NAME: 'TDS - Credit Customer',
        VCH_TYPE: 'EINV',
      },
      {
        LEDR_KEY: '09',
        AC_CODE: 'CUST01',
        LD_CODE: 'ROF005',
        CR_AMT: 0.38,
        DR_AMT: 0,
        AC_NAME: 'ROF - Credit Customer',
        VCH_TYPE: 'EINV',
      },
      {
        LEDR_KEY: '10',
        AC_CODE: 'CUST01',
        LD_CODE: 'ROF001',
        CR_AMT: 0,
        DR_AMT: 0.38,
        AC_NAME: 'ROF - Credit Customer',
        VCH_TYPE: 'EINV',
      },
    ]);

    const stock = await query(
      `SELECT "ISR_NO"::float AS "ISR_NO","TR_TYPE","ITM_SIGN" FROM "MAIN_STOCK" WHERE ${where()} ORDER BY "ISR_NO"`,
    );
    expect(stock).toEqual([
      { ISR_NO: 1, TR_TYPE: 'S', ITM_SIGN: '-' },
      { ISR_NO: 2, TR_TYPE: 'S', ITM_SIGN: '-' },
    ]);
    const tax = await query(`SELECT DISTINCT "TAX_SIGN" FROM "TAX_DATA" WHERE ${where()}`);
    expect(tax).toEqual([{ TAX_SIGN: '+' }]);
    expect(
      await query(`SELECT "MAIN_BOOK","VCH_REMARK" FROM "REMARK_DATA" WHERE ${where()}`),
    ).toEqual([{ MAIN_BOOK: 'E INVOICE', VCH_REMARK: 'invoice narration' }]);

    const entry = await getEBillEntry(runtime, 'E INVOICE', scope(), '00001');
    expect(entry).toMatchObject({
      family: 'E INVOICE',
      tdsCode: '25',
      tdsPercent: 1,
      irnLocked: false,
    });
    expect((await listEInvoices(runtime, scope())).rows.map((r) => r.VCH_NO)).toEqual(['00001']);
    expect((await getEInvoice(runtime, scope(), '1'))?.lines).toHaveLength(2);
  });

  it('applies the 50 lakh TCS threshold on a new voucher and the full base on a saved one (EI-2)', async () => {
    await exec(
      `INSERT INTO "AC_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DATE","LEDR_KEY","AC_CODE","DR_AMT","CR_AMT","DATA_TYPE")
       VALUES ($1,$2,'09','2024-2025','SAL','00077','2024-05-01','PRIOR-SALE','CUST01',4990000,0,'A'),
              ($1,$2,'01','2023-2024','SAL','00078','2024-03-01','OLD-YEAR','CUST01',999999,0,'A'),
              ($1,$2,'01','2024-2025','SAL','00079','2024-05-02','OTHER-TYPE','CUST01',888888,0,'B')`,
      TENANT,
      CO,
    );
    expect(await eInvoiceTcsBasis(runtime, scope(), 'CUST01')).toEqual({
      partyCode: 'CUST01',
      priorDebits: 4990000,
    });
    const tcsLine = { itemCode: 'GOLD', pcs: 1, mrp: 50000, taxCode: '10' };
    const created = await saveEBill(
      runtime,
      'E INVOICE',
      input({ cashAmount: 0, tdsCode: '', lines: [tcsLine] }),
    );
    expect(created.totals).toMatchObject({
      tcsAmount: 42,
      totalAmount: 51542,
      roundOff: 0,
      outstanding: 51542,
    });
    const [header] = await query(
      `SELECT "TCS_CODE","TCS_PRC"::float AS "TCS_PRC","TCS_AMT"::float AS "TCS_AMT" FROM "SL_DATA" WHERE ${where()}`,
    );
    expect(header).toEqual({ TCS_CODE: '20', TCS_PRC: 0.1, TCS_AMT: 42 });
    expect((await ledgerOf()).map((r) => [r.LEDR_KEY, r.AC_CODE, r.CR_AMT, r.DR_AMT])).toEqual([
      [`${STR(1)}02`, 'SALE01', 50000, 0],
      ['01', 'CUST01', 0, 51542],
      ['03', 'GST001', 1500, 0],
      ['04', 'TCS001', 42, 0],
    ]);
    expect((await rojmelOf()).find((r) => r.LEDR_KEY === '04')).toMatchObject({
      AC_CODE: 'TCS001',
      CR_AMT: 42,
      AC_NAME: 'TCS Payable',
    });

    const opened = await getEBillEntry(runtime, 'E INVOICE', scope(), '00001');
    const edited = await saveEBill(
      runtime,
      'E INVOICE',
      input({
        cashAmount: 0,
        tdsCode: '',
        tcsCode: opened!.tcsCode,
        expectedRevision: opened!.revision,
        lines: [{ ...tcsLine, oldSrNo: 1 }],
      }),
      '00001',
    );
    expect(edited.totals).toMatchObject({ tcsAmount: 52, totalAmount: 51552 });

    // Code 00 suppresses TCS even over the threshold (8826 help list / 9110).
    await deleteEBill(runtime, 'E INVOICE', scope(), '00001');
    const none = await saveEBill(
      runtime,
      'E INVOICE',
      input({ cashAmount: 0, tdsCode: '', tcsCode: '00', lines: [tcsLine] }),
    );
    expect(none.totals).toMatchObject({ tcsAmount: 0, totalAmount: 51500 });
  });

  it('balances a negative round-off on row 15 and keeps the signed rojmel rows 09/10 (EI-3)', async () => {
    const saved = await saveEBill(
      runtime,
      'E INVOICE',
      input({
        cashAmount: 0,
        tdsCode: '',
        lines: [{ itemCode: 'GOLD', pcs: 2, grossWt: 4, rate: 100, mrp: 1010, taxCode: '10' }],
      }),
    );
    expect(saved.totals).toMatchObject({ totalAmount: 1040, roundOff: -0.3 });
    const ledger = await ledgerOf();
    expect(ledger.find((r) => r.LEDR_KEY === '15')).toMatchObject({
      AC_CODE: 'ROF005',
      CR_AMT: 0,
      DR_AMT: 0.3,
    });
    const sum = ledger.reduce((s, r) => s + Number(r.CR_AMT) - Number(r.DR_AMT), 0);
    expect(Math.abs(sum)).toBeLessThan(1e-9);
    const rojmel = await rojmelOf();
    expect(rojmel.filter((r) => ['09', '10'].includes(String(r.LEDR_KEY)))).toEqual([
      {
        LEDR_KEY: '09',
        AC_CODE: 'CUST01',
        LD_CODE: 'ROF005',
        CR_AMT: 0,
        DR_AMT: -0.3,
        AC_NAME: 'ROF - Credit Customer',
        VCH_TYPE: 'EINV',
      },
      {
        LEDR_KEY: '10',
        AC_CODE: 'CUST01',
        LD_CODE: 'ROF001',
        CR_AMT: -0.3,
        DR_AMT: 0,
        AC_NAME: 'ROF - Credit Customer',
        VCH_TYPE: 'EINV',
      },
    ]);
  });

  it('writes DM_DATA for preserved components whose item has OTH_DETL_POSTING=Y', async () => {
    await saveEBill(runtime, 'E INVOICE', input({ tdsCode: '', cashAmount: 0 }));
    await exec(
      `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","OTH_DETL_POSTING") VALUES
         ($1,$2,'DMND','Diamond','Y'),($1,$2,'BEAD','Bead','N')`,
      TENANT,
      CO,
    );
    await exec(
      `INSERT INTO "SL_IDTL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","ISR_NO","IT_CODE","DM_CODE","DM_SIZE","IT_PCS","IT_GWT","IT_RATE","IT_AMT","IT_NET_AMT")
       VALUES ($1,$2,$3,$4,$5,'00001',1,1,'DMND','D1','0.10',2,0.2,5000,1000,1000),
              ($1,$2,$3,$4,$5,'00001',1,2,'BEAD','B1','',5,1.5,10,50,50)`,
      TENANT,
      CO,
      LC,
      YEAR,
      BOOK,
    );
    const opened = await getEBillEntry(runtime, 'E INVOICE', scope(), '00001');
    expect(opened!.componentCount).toBe(2);
    await saveEBill(
      runtime,
      'E INVOICE',
      input({
        tdsCode: '',
        cashAmount: 0,
        expectedRevision: opened!.revision,
        lines: opened!.lines.map(({ srNo: _s, tagNo: _t, itemName: _n, ...line }) => line),
      }),
      '00001',
    );
    const dm = await query(
      `SELECT "MAIN_SRNO"::float AS "MAIN_SRNO","SR_NO"::float AS "SR_NO","ISR_NO"::float AS "ISR_NO","ENTRY_TYPE","BOOK_NAME","IT_CODE",
              "DM_CODE","DM_PCS"::float AS "DM_PCS","DM_WT"::float AS "DM_WT","DM_SIGN","DM_RATE"::float AS "DM_RATE","DM_AMT"::float AS "DM_AMT",
              "TAG_NO","MAIN_IT_CODE","INOUT_TYPE","DM_LOT_NO"
         FROM "DM_DATA" WHERE ${where()}`,
    );
    expect(dm).toEqual([
      {
        MAIN_SRNO: 1,
        SR_NO: 1,
        ISR_NO: 1,
        ENTRY_TYPE: 'S',
        BOOK_NAME: 'EINV',
        IT_CODE: 'DMND',
        DM_CODE: 'D1',
        DM_PCS: 2,
        DM_WT: 0.2,
        DM_SIGN: '-',
        DM_RATE: 5000,
        DM_AMT: 1000,
        TAG_NO: 'N',
        MAIN_IT_CODE: 'GOLD',
        INOUT_TYPE: 'S',
        DM_LOT_NO: '',
      },
    ]);
    await deleteEBill(runtime, 'E INVOICE', scope(), '00001');
    expect(await query(`SELECT 1 FROM "DM_DATA" WHERE ${where()}`)).toEqual([]);
    expect(await query(`SELECT 1 FROM "REMARK_DATA" WHERE ${where()}`)).toEqual([]);
  });

  it('refuses the wrong family, direction and unknown TCS/TDS codes', async () => {
    await expect(saveEBill(runtime, 'E CRNT', input({ tdsCode: '' }))).rejects.toThrow(
      'E CRNT / I',
    );
    await expect(
      saveEBill(runtime, 'E INVOICE', { ...input(), scope: scope('146') }),
    ).rejects.toThrow('E INVOICE / O');
    await expect(saveEBill(runtime, 'E INVOICE', input({ tdsCode: 'ZZ' }))).rejects.toThrow(
      'TDS code not found',
    );
    await expect(saveEBill(runtime, 'E INVOICE', input({ tcsCode: 'ZZ' }))).rejects.toThrow(
      'TCS code not found',
    );
    expect(await query(`SELECT 1 FROM "SL_DATA" WHERE ${where()}`)).toEqual([]);
  });

  it('exposes TCS/TDS help lists and the threshold percent for the entry screen', async () => {
    const config = await getEBillEntryConfig(runtime, 'E INVOICE', scope());
    expect(config).toMatchObject({
      family: 'E INVOICE',
      tcsCodes: [
        { code: '00', percent: 0 },
        { code: '20', percent: 0.1 },
      ],
      tdsCodes: [
        { code: '00', percent: 0 },
        { code: '25', percent: 1 },
      ],
      tcsThresholdPercent: 0.1,
    });
  });
});
