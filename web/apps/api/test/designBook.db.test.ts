import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import { PrismaClient } from '@datacare/db';
import {
  DesignBookError,
  listDesignBook,
  saveDesignBook,
} from '../src/modules/masters/designBook.js';

const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const d = RUN ? describe : describe.skip;

/**
 * DESIGN_DETL parity — the design book master (`MS_DESIGN_BOOK.cs:5790`, 34 columns).
 *
 * Asserts the FULL desktop column set, not a sample: a partially-written master silently loses
 * costing fields (touch, wastage, labour, ghat) that the desktop relies on when a design is pulled
 * into a voucher.
 */
d('design book master', () => {
  const prisma = new PrismaClient();
  // Short kebab tenant: tenant_id is varchar(24) on all 170 tables, so a UUID does not fit.
  const tenantId = 'design-book-db';
  const scope = { tenantId, coCode: '01' };
  const BOOK = 'RING BOOK';
  const PR = 'RG';

  const clean = async () => {
    await prisma.$executeRawUnsafe(`DELETE FROM "DESIGN_DETL" WHERE tenant_id='${tenantId}'`);
  };

  beforeAll(async () => {
    await clean();
  });
  afterAll(async () => {
    await clean();
    await prisma.$disconnect();
  });

  it('writes every desktop column of DESIGN_DETL', async () => {
    const written = await saveDesignBook(prisma, {
      scope,
      bookName: BOOK,
      prCode: PR,
      vchDate: '2026-04-05',
      mainUser: 'admin',
      lines: [
        {
          pageNo: '12',
          designNo: 'RG-1001',
          grCode: 'GD',
          itmSize: '14',
          dieNo: 'D-7',
          pcs: 2,
          grossWt: 12.5,
          otherWt: 0.5,
          netWt: 12,
          touch: 91.6,
          westPct: 1.5,
          fineWt: 11.172,
          rate: 6200,
          amount: 74400,
          labourType: 'P',
          labourPct: 3,
          labourRate: 150,
          labourAmount: 1800,
          otherAmount: 25,
          tagCost: 10,
          mrp: 79000,
          ghatPct: 0.5,
          ghatWt: 0.06,
          netAmount: 76235,
          rateType: 'N',
          itType: 'S',
          karigarName: 'KR01',
        },
      ],
    });
    expect(written).toBe(1);

    const rows = await listDesignBook(prisma, scope, BOOK, PR);
    expect(rows).toHaveLength(1);
    const row = rows[0] as Record<string, unknown>;

    // Key and provenance
    expect(row.CO_CODE).toBe('01');
    expect(row.BOOK_NAME).toBe(BOOK);
    expect(row.PR_CODE).toBe(PR);
    expect(Number(row.SR_NO)).toBe(1);
    expect(Number(row.OLD_SRNO)).toBe(1);
    expect(row.PAGE_NO).toBe('12');
    expect(row.MAIN_USER).toBe('admin');
    expect(new Date(row.VCH_DATE as string).toISOString().slice(0, 10)).toBe('2026-04-05');

    // Identity
    expect(row.GR_CODE).toBe('GD');
    expect(row.DESIGN_NO).toBe('RG-1001');
    expect(row.ITM_SIZE).toBe('14');
    expect(row.DIE_NO).toBe('D-7');
    expect(row.IT_TYPE).toBe('S');
    expect(row.KR_NAME).toBe('KR01');
    expect(row.RATE_TYPE).toBe('N');
    expect(row.LBR_TYPE).toBe('P');

    // Weights and costing — the fields a partial write would drop
    expect(Number(row.ITM_PCS)).toBe(2);
    expect(Number(row.ITM_GWT)).toBeCloseTo(12.5, 3);
    expect(Number(row.ITM_OTH_WT)).toBeCloseTo(0.5, 3);
    expect(Number(row.ITM_NWT)).toBeCloseTo(12, 3);
    expect(Number(row.ITM_TOUCH)).toBeCloseTo(91.6, 2);
    expect(Number(row.ITM_WEST_PRC)).toBeCloseTo(1.5, 2);
    expect(Number(row.ITM_FINE)).toBeCloseTo(11.172, 3);
    expect(Number(row.ITM_RATE)).toBeCloseTo(6200, 2);
    expect(Number(row.ITM_AMT)).toBeCloseTo(74400, 2);
    expect(Number(row.LBR_PRC)).toBeCloseTo(3, 2);
    expect(Number(row.LBR_RATE)).toBeCloseTo(150, 2);
    expect(Number(row.LBR_AMT)).toBeCloseTo(1800, 2);
    expect(Number(row.OTH_AMT)).toBeCloseTo(25, 2);
    expect(Number(row.TAG_COST)).toBeCloseTo(10, 2);
    expect(Number(row.ITM_MRP)).toBeCloseTo(79000, 2);
    expect(Number(row.GHT_PRC)).toBeCloseTo(0.5, 2);
    expect(Number(row.ITM_GHT)).toBeCloseTo(0.06, 3);
    expect(Number(row.NET_AMT)).toBeCloseTo(76235, 2);
  }, 30_000);

  it('replaces the book on resave rather than appending, as the desktop does', async () => {
    await saveDesignBook(prisma, {
      scope,
      bookName: BOOK,
      prCode: PR,
      lines: [{ designNo: 'A' }, { designNo: 'B' }],
    });
    await saveDesignBook(prisma, {
      scope,
      bookName: BOOK,
      prCode: PR,
      lines: [{ designNo: 'C' }],
    });
    const rows = await listDesignBook(prisma, scope, BOOK, PR);
    expect(rows).toHaveLength(1);
    expect((rows[0] as Record<string, unknown>).DESIGN_NO).toBe('C');
  }, 30_000);

  it('does not disturb another product book', async () => {
    await saveDesignBook(prisma, {
      scope,
      bookName: BOOK,
      prCode: 'CH',
      lines: [{ designNo: 'X' }],
    });
    await saveDesignBook(prisma, { scope, bookName: BOOK, prCode: PR, lines: [{ designNo: 'Y' }] });
    expect(await listDesignBook(prisma, scope, BOOK, 'CH')).toHaveLength(1);
    expect(await listDesignBook(prisma, scope, BOOK, PR)).toHaveLength(1);
  }, 30_000);

  it('rejects a line with no design number using the desktop wording', async () => {
    await expect(
      saveDesignBook(prisma, { scope, bookName: BOOK, prCode: PR, lines: [{ designNo: '  ' }] }),
    ).rejects.toThrow('Please Insert Design No and Try..');
  });

  it('requires a book name, a product and at least one line', async () => {
    await expect(
      saveDesignBook(prisma, { scope, bookName: '', prCode: PR, lines: [{ designNo: 'A' }] }),
    ).rejects.toBeInstanceOf(DesignBookError);
    await expect(
      saveDesignBook(prisma, { scope, bookName: BOOK, prCode: '', lines: [{ designNo: 'A' }] }),
    ).rejects.toBeInstanceOf(DesignBookError);
    await expect(
      saveDesignBook(prisma, { scope, bookName: BOOK, prCode: PR, lines: [] }),
    ).rejects.toBeInstanceOf(DesignBookError);
  });
});
