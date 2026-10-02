import { readFileSync } from 'node:fs';
import { PrismaClient } from '@prisma/client';
import { withTenant } from '@datacare/db';
import { afterAll, beforeEach, describe, expect, it } from 'vitest';
import {
  listSalesOrderDesigns,
  resolveSalesOrderDesignTx,
  getSalesOrderDesignImage,
} from '../src/modules/sales/orderDesignSelection.js';
import { saveEntityImage } from '../src/modules/images/entityImage.js';
import { applySalesOrderDesignSelection, type SalesOrderDesignSourceRef } from '@datacare/core';
import { assertIsolatedTestDatabase } from './support/isolatedDatabase.js';

const db = process.env.RUN_DB_INTEGRITY_TESTS === '1' ? describe : describe.skip;
function first<T>(rows: T[]): T {
  if (rows[0] === undefined) throw new Error('Missing fixture');
  return rows[0];
}
db('Sales F1 saved Design source resolution', () => {
  const prisma = new PrismaClient();
  const scope = {
    tenantId: 'sales-design-r4',
    coCode: '01',
    lcCode: '01',
    coYear: '2024-2025',
    coBook: 'SO1',
  };
  const sql = (query: string, ...args: unknown[]) =>
    withTenant(prisma, scope.tenantId, (tx) =>
      tx.$executeRawUnsafe(query, scope.tenantId, ...args),
    );
  async function clean() {
    for (const table of [
      'ENTITY_IMAGE',
      'ENTITY_IMAGE_REVISION',
      'DESIGN_DETL',
      'PRODUCT_MAST',
      'ITEM_MAST',
      'HDD_MAST',
      'BOOK_DATA',
    ])
      await sql(`DELETE FROM "${table}" WHERE tenant_id=$1`);
  }
  const list = (
    input: { itCode?: string; search?: string; offset?: number; limit?: number } = {},
  ) => listSalesOrderDesigns(prisma, scope, { itCode: 'RING', ...input });
  const resolve = (source: SalesOrderDesignSourceRef, itCode = 'RING', company = scope.coCode) =>
    withTenant(prisma, scope.tenantId, (tx) =>
      resolveSalesOrderDesignTx(tx, { ...scope, coCode: company }, { itCode, source }),
    );
  beforeEach(async () => {
    assertIsolatedTestDatabase();
    await clean();
    await sql(`INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","MAIN_BOOK","BOOK_TBL_NAME","BOOK_INOUT","CUR_USE")
      VALUES ($1,'01','01','SO1','SALES ORDER','SL_ORD_DATA','O','Y'),($1,'01','02','SO1','SALES ORDER','SL_ORD_DATA','O','Y'),($1,'01','01','TO1','TOUR ORDER','SL_ORD_DATA','I','Y')`);
    await sql(`INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","PR_CODE") VALUES
      ($1,'01','RING','RG'),($1,'01','CHAIN','CH'),($1,'01','EMPTY',NULL),($1,'02','RING','RG')`);
    await sql(
      `INSERT INTO "PRODUCT_MAST"(tenant_id,"CO_CODE","PR_CODE","PR_NAME") VALUES ($1,'01','RG','Ring'),($1,'02','RG','Foreign ring')`,
    );
    await sql(`INSERT INTO "DESIGN_DETL"(tenant_id,"CO_CODE","BOOK_NAME","PR_CODE","SR_NO","OLD_SRNO","DESIGN_NO","ITM_SIZE","DIE_NO","KR_NAME","ITM_GWT","ITM_TOUCH","ITM_WEST_PRC","LBR_PRC","LBR_RATE","DESIGN_IMG_ID") VALUES
      ($1,'01','ALBUM A','RG',17,42,'SAME','12','REMARK-A','K01',999.999,91.625,2.3456,0.0001,77.25,'IMAGE-A'),
      ($1,'01','ALBUM B','RG',23,NULL,'SAME','14','REMARK-B','K02',7.777,NULL,0,0,55.50,'IMAGE-B'),
      ($1,'01','ALBUM C','CH',81,90,'CHAIN','18','CHAIN','K03',8.888,92,2,0,50,'IMAGE-C'),
      ($1,'02','ALBUM A','RG',17,42,'FOREIGN','99','FOREIGN','K09',123.456,99,9,9,999,'IMAGE-A')`);
  });
  afterAll(async () => {
    await clean();
    await prisma.$disconnect();
  });
  it('lists only company/item-product designs, raw decimals/nulls and complete non-contiguous source identities', async () => {
    const found = await list();
    expect(found.thirdColumnLabel).toBe('Product');
    expect(
      found.rows.map((row) => [row.bookName, row.designNo, row.source.srNo, row.source.oldSrNo]),
    ).toEqual([
      ['ALBUM A', 'SAME', 17, 42],
      ['ALBUM B', 'SAME', 23, null],
    ]);
    expect(first(found.rows)).toMatchObject({
      grossWt: '999.999',
      touch: '91.625',
      westPct: '2.3456',
      labourPct: '0.0001',
      labourRate: '77.25',
    });
    expect(found.rows[1]?.touch).toBeNull();
    expect(
      first(
        (
          await listSalesOrderDesigns(
            prisma,
            { ...scope, lcCode: '02', coYear: '2025-2026' },
            { itCode: 'RING' },
          )
        ).rows,
      ).source,
    ).toEqual(first(found.rows).source);
  });
  it('paginates duplicate display names deterministically and searches literal wildcard characters', async () => {
    const a = await list({ limit: 1 });
    expect([a.hasMore, first(a.rows).source.srNo]).toEqual([true, 17]);
    const b = await list({ limit: 1, offset: 1 });
    expect([b.hasMore, first(b.rows).source.srNo]).toEqual([false, 23]);
    expect(first((await list({ search: 'ALBUM B' })).rows).source.srNo).toBe(23);
    expect((await list({ search: '%' })).rows).toHaveLength(0);
    await expect(list({ offset: -1 })).rejects.toMatchObject({ statusCode: 400 });
    await expect(list({ limit: 101 })).rejects.toMatchObject({ statusCode: 400 });
  });
  it('supports a missing product display master and refuses contradictory display masters', async () => {
    expect(first((await list({ itCode: 'CHAIN' })).rows).productName).toBe('');
    await sql(
      `INSERT INTO "PRODUCT_MAST"(tenant_id,"CO_CODE","PR_CODE","PR_NAME") VALUES ($1,'01','RG','Ring')`,
    );
    expect((await list()).rows).toHaveLength(2);
    await sql(
      `INSERT INTO "PRODUCT_MAST"(tenant_id,"CO_CODE","PR_CODE","PR_NAME") VALUES ($1,'01','RG','Conflicting')`,
    );
    await expect(list()).rejects.toThrow('Conflicting product names');
  });
  it('uses registration-specific Remark help without changing source-copy values', async () => {
    await sql(`INSERT INTO "HDD_MAST"(tenant_id,"REF_NO") VALUES ($1,'DM043NEDM')`);
    const found = await list({ search: 'REMARK-B' });
    expect(found.thirdColumnLabel).toBe('Remark');
    expect(first(found.rows)).toMatchObject({ remark: 'REMARK-B', productName: 'Ring' });
    await sql(`INSERT INTO "HDD_MAST"(tenant_id,"REF_NO") VALUES ($1,'OTHER')`);
    await expect(list()).rejects.toThrow('Conflicting installation registrations');
  });
  it('requires a real item and a complete, configured Sales book scope', async () => {
    await expect(list({ itCode: 'EMPTY' })).rejects.toMatchObject({ statusCode: 400 });
    await expect(list({ itCode: 'NOPE' })).rejects.toMatchObject({ statusCode: 400 });
    await expect(
      listSalesOrderDesigns(prisma, { ...scope, coBook: 'TO1' }, { itCode: 'RING' }),
    ).rejects.toThrow('expected SALES ORDER');
    await expect(
      listSalesOrderDesigns(prisma, { ...scope, coYear: '' }, { itCode: 'RING' }),
    ).rejects.toMatchObject({ statusCode: 400 });
  });
  it('rejects foreign company/product, forged old serial, malformed version and a deleted source', async () => {
    const ref = first((await list()).rows).source;
    await expect(resolve(ref, 'CHAIN')).rejects.toMatchObject({ statusCode: 409 });
    await expect(resolve(ref, 'RING', '02')).rejects.toMatchObject({ statusCode: 409 });
    await expect(resolve({ ...ref, oldSrNo: 43 })).rejects.toMatchObject({ statusCode: 409 });
    await expect(resolve({ ...ref, version: '' })).rejects.toMatchObject({ statusCode: 400 });
    await sql(
      `DELETE FROM "DESIGN_DETL" WHERE tenant_id=$1 AND "CO_CODE"='01' AND "BOOK_NAME"='ALBUM A'`,
    );
    await expect(resolve(ref)).rejects.toMatchObject({ statusCode: 409 });
  });
  it('rejects changed source fields and item-product changes before applying source data', async () => {
    const ref = first((await list()).rows).source;
    await sql(
      `UPDATE "DESIGN_DETL" SET "ITM_TOUCH"=91.626 WHERE tenant_id=$1 AND "CO_CODE"='01' AND "BOOK_NAME"='ALBUM A'`,
    );
    await expect(resolve(ref)).rejects.toMatchObject({ statusCode: 409 });
    const fresh = first((await list()).rows).source;
    await sql(
      `UPDATE "ITEM_MAST" SET "PR_CODE"='CH' WHERE tenant_id=$1 AND "CO_CODE"='01' AND "IT_CODE"='RING'`,
    );
    await expect(resolve(fresh)).rejects.toMatchObject({ statusCode: 409 });
  });
  it('source replay preserves hidden values, children, invalid unrelated drafts and does not copy displayed gross', async () => {
    const found = await resolve(first((await list()).rows).source);
    const row = {
      srNo: 31,
      oldSrNo: 72,
      grossWt: 'invalid',
      touch: '80',
      westPct: '1',
      labourPct: '3',
      labourRate: '19',
      fineWt: '0.333',
      amount: '22.22',
      components: [{ isrNo: 9, amount: null }],
    };
    const applied = applySalesOrderDesignSelection(row, found, { existing: false });
    expect(applied).toMatchObject({
      srNo: 31,
      oldSrNo: 72,
      grossWt: 'invalid',
      touch: '91.63',
      westPct: '2.35',
      labourPct: '0.00',
      labourRate: '19',
      fineWt: '0.333',
      amount: '22.22',
    });
    expect(applied.components).toBe(row.components);
  });
  it('holds source and item non-key writes until the selecting transaction completes', async () => {
    const ref = first((await list()).rows).source;
    await withTenant(prisma, scope.tenantId, async (tx) => {
      await resolveSalesOrderDesignTx(tx, scope, { itCode: 'RING', source: ref });
      for (const update of [
        `UPDATE "DESIGN_DETL" SET "ITM_TOUCH"=91.626 WHERE tenant_id=$1 AND "CO_CODE"='01' AND "BOOK_NAME"='ALBUM A'`,
        `UPDATE "ITEM_MAST" SET "PR_CODE"='CH' WHERE tenant_id=$1 AND "CO_CODE"='01' AND "IT_CODE"='RING'`,
      ])
        await expect(
          withTenant(prisma, scope.tenantId, async (other) => {
            await other.$executeRawUnsafe("SET LOCAL lock_timeout = '100ms'");
            await other.$executeRawUnsafe(update, scope.tenantId);
          }),
        ).rejects.toMatchObject({ meta: { code: '55P03' } });
    });
    expect((await resolve(ref)).source).toEqual(ref);
  });
  it('stale-source failure rolls back preceding work inside the writer transaction', async () => {
    const ref = first((await list()).rows).source;
    await expect(
      withTenant(prisma, scope.tenantId, async (tx) => {
        await tx.$executeRawUnsafe(
          `UPDATE "DESIGN_DETL" SET "DIE_NO"='CHANGED' WHERE tenant_id=$1 AND "CO_CODE"='01' AND "BOOK_NAME"='ALBUM B'`,
          scope.tenantId,
        );
        await resolveSalesOrderDesignTx(tx, scope, {
          itCode: 'RING',
          source: { ...ref, version: '0'.repeat(64) },
        });
      }),
    ).rejects.toMatchObject({ statusCode: 409 });
    expect(first((await list({ search: 'ALBUM B' })).rows).remark).toBe('REMARK-B');
  });
  it('previews only validated company-level Design bytes and rejects stale/foreign references', async () => {
    const image = readFileSync(new URL('./fixtures/order-design-portrait.png', import.meta.url));
    await saveEntityImage(
      prisma,
      {
        ...scope,
        lcCode: '',
        entityType: 'DESIGN',
        entityKey: 'IMAGE-A',
        imageType: 'D',
        requireDesignParent: true,
      },
      { data: image.toString('base64'), mimeType: 'image/png' },
    );
    const ref = first((await list()).rows).source;
    const found = await getSalesOrderDesignImage(prisma, scope, { itCode: 'RING', source: ref });
    expect(found.state).toBe('present');
    if (found.state === 'present') expect(found.bytes.equals(image)).toBe(true);
    await expect(
      getSalesOrderDesignImage(prisma, scope, { itCode: 'CHAIN', source: ref }),
    ).rejects.toMatchObject({ statusCode: 409 });
    await expect(
      getSalesOrderDesignImage(prisma, scope, { itCode: 'RING', source: { ...ref, srNo: 999 } }),
    ).rejects.toMatchObject({ statusCode: 409 });
    await expect(
      getSalesOrderDesignImage(
        prisma,
        { ...scope, coBook: 'TO1' },
        { itCode: 'RING', source: ref },
      ),
    ).rejects.toThrow('expected SALES ORDER');
  });
  it('treats blank and N design-image cells as absent without tag/custom fallback', async () => {
    for (const value of [null, '', 'N']) {
      await sql(
        `UPDATE "DESIGN_DETL" SET "DESIGN_IMG_ID"=$2 WHERE tenant_id=$1 AND "CO_CODE"='01' AND "BOOK_NAME"='ALBUM A'`,
        value,
      );
      const ref = first((await list()).rows).source;
      expect(
        await getSalesOrderDesignImage(prisma, scope, { itCode: 'RING', source: ref }),
      ).toEqual({ state: 'absent' });
    }
  });
});
