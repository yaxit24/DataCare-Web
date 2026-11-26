import { afterEach, beforeEach, describe, expect, it } from 'vitest';
import { planLiteImport, fmtRound, val, fnv } from '../src/modules/utilities/dataImportLite.js';
import {
  MAX_SOURCE_BYTES,
  SourceFileError,
  fixtureReader,
  isAccessFile,
  openImportSource,
  pickAllowed,
} from '../src/modules/utilities/dataImportSource.js';
import { fixtureBytes, liteFixture } from './fixtures/liteImport.js';

const CO = '07';
const YEAR = '2025-2026';
const CL = '2026-03-31';
const OP = '2025-04-01';
const ctx = { coCode: CO, lcCode: '01', coYear: YEAR, clDate: CL, opDate: OP, user: 'e2eadmin' };
const plan = () => planLiteImport(fixtureReader(fixtureBytes(CO, YEAR, CL)), ctx);

describe('Access helpers (DC_Main.Fnv / Conversion.Val / Format)', () => {
  it('reads numbers as the desktop does', () => {
    expect(val('12.5abc')).toBe(12.5);
    expect(val('abc')).toBe(0);
    expect(fnv(null)).toBe(0);
    expect(fnv('')).toBe(0);
    expect(fmtRound(2.0005, 3)).toBe(2.001);
    expect(fmtRound(-750.445, 2)).toBe(-750.45);
  });
});

describe('Lite_AcMast (UT_IMPORT.cs:8694-8780)', () => {
  it('imports the company accounts above 00100 with the desktop column rules', () => {
    const p = plan();
    expect(p.errors).toEqual([]);
    expect(p.accounts.map((a) => a.AC_CODE)).toEqual(['00101', '00102']);
    const [ramesh, suresh] = p.accounts as any[];
    expect(ramesh).toMatchObject({
      CO_CODE: CO,
      LC_CODE: '01',
      AC_NAME: 'RAMESH JEWELLERS',
      AC_MAIN_GR: '04',
      AC_GR: '20', // Mid(AC_GR,1,2)
      AC_ADD1: "SHOP 4, O'NEIL ROAD", // kept: parameterised SQL (documented deviation from :8722-8730)
      AC_ADD2: 'MAIN BAZAR',
      AC_ADD3: '',
      AC_AREA: 'SADAR BAZAR NORTH EXTENSION AREA'.slice(0, 25),
      AC_PHONE: '028123456789'.slice(0, 11),
      AC_MOBILE: '9876543210',
      AC_MOBILE2: '',
      AC_GSTNO: '24ABCDE1234F1Z5',
      AC_GST_TYPE: 'L',
      AC_PANNO: 'ABCDE1234F',
      BR_DATE: '17/05/1980',
      AN_DATE: null,
      LAST_DATE: '01/01/2010',
      DATA_TRFR: 'N',
      MAIN_USER: 'ABC',
    });
    expect(suresh).toMatchObject({ AC_AREA: '', AC_MOBILE2: '99887766554', BR_DATE: null });
    // :8770-8774 the last account becomes the counter row
    expect(p.accountSrno).toEqual({
      CO_CODE: CO,
      AC_CODE: '00102',
      LC_CODE: '01',
      AC_NAME: 'SURESH KARIGAR',
      AC_GR: '10',
    });
  });
});

describe('Wh_Item, Lite branches (UT_IMPORT.cs:4241-4328)', () => {
  it('copies products, groups, tables and items, mapping installer ledgers to the web chart', () => {
    const p = plan();
    expect(p.products).toEqual([
      { CO_CODE: CO, PR_CODE: 'GO', PR_NAME: 'GOLD ORNAMENTS', MAIN_USER: 'e2eadmin' },
    ]);
    const [gld, slv] = p.groups as any[];
    expect(gld).toMatchObject({ GR_CODE: 'GLD', TRAD_TYPE: '', GR_TOUCH: 91.6, GR_PURC_TOUCH: 0, MELTING_PRC: 99.5, GR_RATE: 6000, SALE_AC: 'SALES', PURC_AC: 'PURCHASE' });
    expect(slv).toMatchObject({ GR_TOUCH: 0, SALE_AC: 'SLVSALE', PURC_AC: '' });
    expect(p.warnings.some((w) => w.table === 'GROUP_MAST' && /00021/.test(w.reason))).toBe(true);
    expect(p.tables).toEqual([
      { CO_CODE: CO, LC_CODE: '01', TABLE_CODE: '001', TABLE_NAME: 'MAIN COUNTER', MAIN_USER: 'e2eadmin' },
    ]);
    const rng = p.items.find((i) => i.IT_CODE === 'RNG')!;
    expect(rng).toMatchObject({ PR_CODE: 'GO', TRAD_TYPE: '', ITEM_RATE: 0, AVG_TOUCH: 0, AC_ITEM: 'RNG', STK_DISPLAY: 'Y', SAFE_NAME: 'MAIN' });
    expect(p.items.find((i) => i.IT_CODE === 'CHN')!.PR_CODE).toBe('');
  });

  it('reports a duplicated item code as a row error', () => {
    const f = liteFixture(CO, YEAR, CL);
    f.tables.ITEM_MAST.push({ ...f.tables.ITEM_MAST[0]! });
    const p = planLiteImport(fixtureReader(Buffer.from(JSON.stringify(f))), ctx);
    expect(p.errors).toEqual([
      expect.objectContaining({ table: 'ITEM_MAST', row: 4, key: 'RNG' }),
    ]);
  });
});

describe('WH_AcOpbl (UT_IMPORT.cs:4330-4363)', () => {
  it('sums each account up to the closing date, signs C for a positive head and D otherwise', () => {
    const p = plan();
    expect(p.openings).toEqual([
      // ORDER BY AC_NAME: CASH A/C (installer 00001 -> CASH), RAMESH, SURESH
      { acCode: 'CASH', sourceAcCode: '00001', amount: 2000, sign: 'C', gold: 0, goldSign: 'D', silver: 0, silverSign: 'D' },
      // 1000 - 249.55 = 750.45 Cr; gold +10.5 - 2.25 = 8.25 Cr; the row after the closing date is left out
      { acCode: '00101', sourceAcCode: '00101', amount: 750.45, sign: 'C', gold: 8.25, goldSign: 'C', silver: 0, silverSign: 'D' },
      { acCode: '00102', sourceAcCode: '00102', amount: 500, sign: 'D', gold: 0, goldSign: 'D', silver: 100, silverSign: 'C' },
    ]);
    expect(p.warnings).toContainEqual(
      expect.objectContaining({ step: 'WH_AcOpbl', key: '00021' }),
    );
  });
});

describe('Lite_BarData (UT_IMPORT.cs:8447-8692)', () => {
  it('numbers one voucher per item in IT_TYPE, IT_CODE order and copies the latest detail of each tag', () => {
    const p = plan();
    expect(p.barData.map((b) => b.VCH_NO)).toEqual(['00001', '00002']);
    expect(p.barData[0]).toMatchObject({ CO_BOOK: '000', OP_STK: 'Y', HD_VCH_NO: '00001', DATA_TRFR: 'N' });
    expect(p.barDetl.map((d) => [d.VCH_NO, d.TAG_NO, d.SR_NO, d.VCH_SRNO])).toEqual([
      ['00001', 'C1', 1, 1000011],
      ['00002', 'R1', 1, 1000021],
      ['00002', 'R2', 2, 1000022],
    ]);
    const r1 = p.barDetl[1] as any;
    expect(r1.VCH_DATE.toISOString().slice(0, 10)).toBe('2025-03-31'); // MOp_dt - 1
    expect(r1).toMatchObject({
      STK_DATE: '2025-03-31',
      VCH_TYPE: 'OPTAG',
      BOOK_NAME: 'OPSTK',
      INOUT_TYPE: 'I',
      ENTRY_TYPE: 'O',
      AC_CODE: '00102',
      DESIGN_NO: 'DESIGN-NUMBER-0123456789'.slice(0, 15),
      TBL_CODE: '001',
      ITM_GWT: 12.5,
      ITM_NWT: 12,
      ITM_OTH_WT: 0.5,
      ITM_GHT_WT: 0.2,
      ITM_WEST_PRC: 2,
      ITM_FINE: 11.232,
      LBR_RATE: 350,
      LBR_AMT: 4200,
      ITM_RATE: 6000,
      TAG_COST: 70000,
      KR_COST: 70000,
      KR_FINE: 11.232,
      KR_NET_WT: 12,
      KR_TOUCH: 92,
      TAG_TYPE: 'G',
      TAG_SRNO: 1,
      APR_ISU: 'N',
    });
    // BAR_IDTL rows of R1 with TAG_NWT = 12, by ISR_NO, renumbered 1..n
    expect(p.barIdtl.map((i) => [i.TAG_NO, i.ISR_NO, i.IT_CODE, i.VCH_SRNO])).toEqual([
      ['R1', 1, 'ST', 1000021],
      ['R1', 2, 'DM', 1000021],
    ]);
    expect(p.barIdtl[1]).toMatchObject({ IT_PCS: 3, KR_WT: 0.1, IT_GWT: 0.5, IT_RATE: 1500, IT_AMT: 4500, IT_NET_AMT: 4500, KR_RATE: 1200, KR_AMT: 3600, KR_NET_AMT: 3600 });
  });
});

describe('WH_ItOpbl (UT_IMPORT.cs:3887-3965)', () => {
  it('writes the signed loose-stock balance per item, ordered by group, with the fine at AVG_TOUCH', () => {
    const p = plan();
    expect(p.itemOpenings).toEqual([
      expect.objectContaining({ IT_CODE: 'CHN', VCH_NO: 'G', SR_NO: 1, ITM_PCS: 2, ITM_GWT: 16, ITM_NWT: 15.5, ITM_TOUCH: 91.6, ITM_FINE: 14.198, ITM_AMT: 0, NET_AMT: 0 }),
      expect.objectContaining({ IT_CODE: 'SLB', VCH_NO: 'S', SR_NO: 2, ITM_PCS: 0, ITM_GWT: 808, ITM_NWT: 800, ITM_TOUCH: 92.5, ITM_FINE: 740 }),
    ]);
  });
});

describe('source reader', () => {
  const env = process.env.DATACARE_IMPORT_FIXTURE_READER;
  beforeEach(() => {
    delete process.env.DATACARE_IMPORT_FIXTURE_READER;
  });
  afterEach(() => {
    if (env === undefined) delete process.env.DATACARE_IMPORT_FIXTURE_READER;
    else process.env.DATACARE_IMPORT_FIXTURE_READER = env;
  });

  it('refuses an empty, oversized or non-Access file before reading it', async () => {
    await expect(openImportSource(new Uint8Array())).rejects.toBeInstanceOf(SourceFileError);
    await expect(openImportSource(new Uint8Array(MAX_SOURCE_BYTES + 1))).rejects.toThrow(/larger than/);
    await expect(openImportSource(Buffer.from('hello world, not a database'))).rejects.toThrow(
      /not a Microsoft Access/,
    );
  });

  it('accepts the JSON fixture only while the test switch is on', async () => {
    const bytes = fixtureBytes(CO, YEAR, CL);
    await expect(openImportSource(bytes)).rejects.toThrow(/not a Microsoft Access/);
    process.env.DATACARE_IMPORT_FIXTURE_READER = '1';
    expect((await openImportSource(bytes)).format).toBe('fixture');
  });

  it('a file that claims to be Access but is not readable is refused by the worker', async () => {
    const fake = Buffer.alloc(8192);
    fake.write('Standard Jet DB', 4, 'latin1');
    expect(isAccessFile(fake)).toBe(true);
    await expect(openImportSource(fake)).rejects.toThrow(/could not be read/);
  });

  it('reads only allow-listed tables and columns and reports missing ones', () => {
    const picked = pickAllowed({
      ac_mast: [{ ac_code: '00101', SECRET: 'x' }],
      UNKNOWN: [{ A: 1 }],
    });
    expect(Object.keys(picked.tables)).toEqual(['AC_MAST']);
    expect(picked.tables.AC_MAST![0]).not.toHaveProperty('SECRET');
    expect(picked.tables.AC_MAST![0]!.AC_CODE).toBe('00101');
    expect(picked.missing.AC_MAST).toContain('AC_NAME');
    expect(picked.names).toContain('UNKNOWN');
  });

  it('a file missing a table the steps read stops the plan with nothing planned', () => {
    const f = liteFixture(CO, YEAR, CL) as any;
    delete f.tables.BAR_IDTL;
    const p = planLiteImport(fixtureReader(Buffer.from(JSON.stringify(f))), ctx);
    expect(p.errors).toEqual([expect.objectContaining({ table: 'BAR_IDTL' })]);
    expect(p.accounts).toEqual([]);
  });
});
