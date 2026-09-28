import { afterAll, beforeEach, describe, expect, it } from 'vitest';
import { PrismaClient } from '@prisma/client';
import { withTenant } from '@datacare/db';
import {
  DesignBookConflictError,
  deleteDesignBook,
  listDesignBook,
  saveDesignBook,
  type DesignBookLine,
  type DesignBookComponent,
} from '../src/modules/masters/designBook.js';

const enabled = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const scope = { tenantId: 'design-rich-db', coCode: '01' };
const other = { tenantId: 'design-rich-other', coCode: '01' };
const bookName = 'RING BOOK';
const prCode = 'RG';
function requiredAt<T>(rows: readonly T[], index = 0): T {
  const row = rows[index];
  if (row === undefined) throw new Error(`Expected fixture/result row at index ${index}`);
  return row;
}
type FixtureLine = DesignBookLine & { components: DesignBookComponent[] };
const fixture = (): [FixtureLine, FixtureLine] => [
  {
    srNo: 10,
    oldSrNo: 10,
    designNo: 'D-001',
    style: 'Engraved style beyond fifteen characters',
    pageNo: '03',
    vchDate: '2024-04-15',
    grossWt: 15.875,
    otherWt: 1.25,
    netWt: 14.625,
    touch: 91.6,
    fineWt: 13.396,
    otherAmount: 187.25,
    designImageId: '01_RING BOOK_RG_D-001',
    components: [
      {
        isrNo: 2,
        itCode: 'ST001',
        itType: 'S',
        pcs: 3,
        pcsWt: 0.251,
        karigarWt: 0.753,
        karigarLessPct: 87.65,
        grossWt: 0.66,
        conversionPct: 0.2,
        conversionWt: 0.132,
        rateType: 'P',
        rate: 123.45,
        amount: 370.35,
        labourRate: 6.75,
        labourAmount: 20.25,
        netAmount: 390.6,
      },
      {
        isrNo: 8,
        itCode: 'DM002',
        itType: 'D',
        pcs: 7,
        pcsWt: 0.05,
        karigarWt: 0.35,
        karigarLessPct: 99,
        grossWt: 0.347,
        conversionPct: 0.25,
        conversionWt: 0.087,
        rateType: 'W',
        rate: 920.75,
        amount: 319.5,
        labourRate: 1.25,
        labourAmount: 8.75,
        netAmount: 328.25,
      },
    ],
  },
  {
    srNo: 20,
    oldSrNo: 20,
    designNo: 'D-002',
    style: '',
    vchDate: '2025-05-20',
    grossWt: 18.325,
    designImageId: '01_RING BOOK_RG_D-002',
    components: [
      {
        isrNo: 3,
        itCode: 'ST003',
        pcs: 2,
        grossWt: 0.442,
        karigarWt: 0.483,
        rate: 823.77,
        netAmount: 364.106,
      },
      {
        isrNo: 9,
        itCode: 'ST004',
        pcs: 4,
        grossWt: 0.874,
        karigarWt: 0.965,
        rate: 492.3,
        netAmount: 430.3,
      },
    ],
  },
];

(enabled ? describe : describe.skip)('X11 design parent/component lifecycle', () => {
  const prisma = new PrismaClient();
  async function clean() {
    for (const tenantId of [scope.tenantId, other.tenantId])
      await withTenant(prisma, tenantId, async (tx) => {
        await tx.$executeRawUnsafe('DELETE FROM "DESIGN_IDTL" WHERE tenant_id=$1', tenantId);
        await tx.$executeRawUnsafe('DELETE FROM "DESIGN_DETL" WHERE tenant_id=$1', tenantId);
      });
  }
  const read = () => listDesignBook(prisma, scope, bookName, prCode);
  const save = (lines: DesignBookLine[] = fixture(), extra: Record<string, unknown> = {}) =>
    saveDesignBook(prisma, { scope, bookName, prCode, lines, ...extra });
  beforeEach(clean);
  afterAll(async () => {
    await clean();
    await prisma.$disconnect();
  });

  it('persists every component business field on its full parent key', async () => {
    await save();
    const rows = await read();
    expect(rows.map((row) => row.SR_NO)).toEqual([10, 20]);
    const first = requiredAt(requiredAt(rows, 0).components as Record<string, unknown>[]);
    expect({ ...first, tenant_id: undefined }).toMatchObject({
      CO_CODE: '01',
      BOOK_NAME: bookName,
      PR_CODE: prCode,
      SR_NO: 10,
      ISR_NO: 2,
      IT_CODE: 'ST001',
      IT_TYPE: 'S',
      IT_RATE_TYPE: 'P',
    });
    const expected = {
      IT_PCS: 3,
      IT_PCS_WT: 0.251,
      KR_WT: 0.753,
      KR_LESS_PRC: 87.65,
      IT_GWT: 0.66,
      IT_CON_PRC: 0.2,
      IT_CON_WT: 0.132,
      IT_RATE: 123.45,
      IT_AMT: 370.35,
      IT_LBR_RATE: 6.75,
      IT_LBR_AMT: 20.25,
      IT_NET_AMT: 390.6,
    };
    for (const [column, value] of Object.entries(expected))
      expect(Number(first[column]), column).toBe(value);
    expect(first.DESIGN_NO).toBeNull(); // Desktop's component writer does not populate DESIGN_NO.
    expect(requiredAt(rows, 0).ITM_STYLE).toBe(fixture()[0].style);
    expect(
      (requiredAt(rows, 1).components as Record<string, unknown>[]).map((row) => row.ISR_NO),
    ).toEqual([3, 9]);
  });

  it('preserves every stored business column on unchanged save including nullable hidden values', async () => {
    await save();
    await withTenant(prisma, scope.tenantId, async (tx) => {
      await tx.$executeRawUnsafe(
        'UPDATE "DESIGN_DETL" SET "ITM_RATE"=NULL,"KR_NAME"=\'\',"OLD_SRNO"=NULL WHERE tenant_id=$1 AND "SR_NO"=10',
        scope.tenantId,
      );
      await tx.$executeRawUnsafe(
        'UPDATE "DESIGN_IDTL" SET "DESIGN_NO"=\'LEGACY\',"IT_LBR_AMT"=NULL WHERE tenant_id=$1 AND "SR_NO"=10 AND "ISR_NO"=2',
        scope.tenantId,
      );
    });
    const before = await read();
    await saveDesignBook(prisma, {
      scope,
      bookName,
      prCode,
      expectedVersion: String(requiredAt(before, 0).bookVersion),
      lines: [
        { srNo: 10, designNo: 'D-001' },
        { srNo: 20, designNo: 'D-002' },
      ],
    });
    expect(await read()).toEqual(before);
  });

  it('keeps component identities and images when parents reorder and one child is removed', async () => {
    await save();
    const [first, second] = fixture();
    first.components = first.components.filter((child) => child.isrNo !== 2);
    requiredAt(first.components).rate = 991.23;
    await save([second, first]);
    const rows = await read();
    expect(requiredAt(rows, 0).DESIGN_IMG_ID).toBe('01_RING BOOK_RG_D-001');
    expect(
      (requiredAt(rows, 0).components as Record<string, unknown>[]).map((child) => [
        child.SR_NO,
        child.ISR_NO,
        Number(child.IT_RATE),
      ]),
    ).toEqual([[10, 8, 991.23]]);
    expect(
      (requiredAt(rows, 1).components as Record<string, unknown>[]).map((child) => [
        child.SR_NO,
        child.ISR_NO,
      ]),
    ).toEqual([
      [20, 3],
      [20, 9],
    ]);
  });

  it('retains omitted children for existing API clients and removes an explicit empty child set', async () => {
    await save();
    await save([
      { srNo: 10, designNo: 'D-001' },
      { srNo: 20, designNo: 'D-002', components: [] },
    ]);
    const rows = await read();
    expect(requiredAt(rows, 0).components).toHaveLength(2);
    expect(requiredAt(rows, 1).components).toEqual([]);
    await save([
      {
        srNo: 10,
        designNo: 'D-001',
        pageNo: '',
        rate: null,
        otherAmount: 0,
        components: [{ isrNo: 2, itCode: 'ST001', itType: '', labourAmount: null, rate: 0 }],
      },
    ]);
    const cleared = requiredAt(await read());
    expect(cleared.PAGE_NO).toBe('');
    expect(cleared.ITM_RATE).toBeNull();
    expect(Number(cleared.OTH_AMT)).toBe(0);
    const child = requiredAt(cleared.components as Record<string, unknown>[]);
    expect(child.IT_TYPE).toBe('');
    expect(child.IT_LBR_AMT).toBeNull();
    expect(Number(child.IT_RATE)).toBe(0);
  });

  it('removes children of a removed parent and deletes both sets for the complete book key', async () => {
    await save();
    await save([fixture()[1]]);
    const children = await withTenant(prisma, scope.tenantId, (tx) =>
      tx.$queryRawUnsafe<Record<string, unknown>[]>(
        'SELECT "SR_NO" FROM "DESIGN_IDTL" WHERE tenant_id=$1',
        scope.tenantId,
      ),
    );
    expect(children.map((row) => row.SR_NO)).toEqual([20, 20]);
    const rows = await read();
    expect(
      await deleteDesignBook(
        prisma,
        scope,
        bookName,
        prCode,
        String(requiredAt(rows, 0).bookVersion),
      ),
    ).toBe(1);
    expect(await read()).toEqual([]);
    const remaining = await withTenant(prisma, scope.tenantId, (tx) =>
      tx.$queryRawUnsafe<Record<string, unknown>[]>(
        'SELECT "SR_NO" FROM "DESIGN_IDTL" WHERE tenant_id=$1',
        scope.tenantId,
      ),
    );
    expect(remaining).toEqual([]);
  });

  it('separates repeated design numbers by tenant, company, book and product', async () => {
    const variants = [
      { scope: other, bookName, prCode },
      { scope: { ...scope, coCode: '02' }, bookName, prCode },
      { scope, bookName: 'SECOND BOOK', prCode },
      { scope, bookName, prCode: 'CH' },
    ];
    for (const [index, variant] of variants.entries())
      await saveDesignBook(prisma, {
        ...variant,
        lines: [
          {
            srNo: 10,
            designNo: 'D-001',
            designImageId: `sentinel-image-${index}`,
            components: [{ isrNo: 2, itCode: `IT00${index}`, grossWt: index + 0.321 }],
          },
        ],
      });
    const before = await Promise.all(
      variants.map((v) => listDesignBook(prisma, v.scope, v.bookName, v.prCode)),
    );
    await save();
    await deleteDesignBook(prisma, scope, bookName, prCode);
    expect(
      await Promise.all(variants.map((v) => listDesignBook(prisma, v.scope, v.bookName, v.prCode))),
    ).toEqual(before);
  });

  it('rejects duplicate or invalid child identities and values without changing the saved book', async () => {
    await save();
    const before = await read();
    const invalids = [
      [
        { isrNo: 2, itCode: 'STONE' },
        { isrNo: 2, itCode: 'PEARL' },
      ],
      [{ isrNo: -1, itCode: 'STONE' }],
      [{ isrNo: 2, itCode: '' }],
      [{ isrNo: 2, itCode: 'STONE', grossWt: NaN }],
      [{ isrNo: 2, itCode: 'TOO-LONG' }],
    ];
    for (const components of invalids) {
      await expect(save([{ ...fixture()[0], components }])).rejects.toThrow();
      expect(await read()).toEqual(before);
    }
    await expect(save([fixture()[0], fixture()[0]])).rejects.toThrow('duplicate parent serial');
    expect(await read()).toEqual(before);
  });

  it('rolls back the whole replacement on a database child numeric overflow', async () => {
    await save();
    const before = await read();
    const changed = fixture();
    changed[0].grossWt = 29.987;
    requiredAt(changed[1].components, 1).rate = 1e30;
    await expect(save(changed)).rejects.toThrow();
    expect(await read()).toEqual(before);
  });

  it('allows one concurrent edit and refuses stale save/delete and create-over-existing', async () => {
    await save(undefined, { expectedVersion: 'new' });
    const version = String(requiredAt(await read()).bookVersion);
    const one = fixture();
    one[0].pageNo = '11';
    const two = fixture();
    two[0].pageNo = '22';
    const results = await Promise.allSettled([
      save(one, { expectedVersion: version }),
      save(two, { expectedVersion: version }),
    ]);
    expect(results.filter((result) => result.status === 'fulfilled')).toHaveLength(1);
    const failure = results.find((result) => result.status === 'rejected') as PromiseRejectedResult;
    expect(failure.reason).toBeInstanceOf(DesignBookConflictError);
    const before = await read();
    await expect(deleteDesignBook(prisma, scope, bookName, prCode, version)).rejects.toBeInstanceOf(
      DesignBookConflictError,
    );
    await expect(save(undefined, { expectedVersion: 'new' })).rejects.toBeInstanceOf(
      DesignBookConflictError,
    );
    expect(await read()).toEqual(before);
  });
});
