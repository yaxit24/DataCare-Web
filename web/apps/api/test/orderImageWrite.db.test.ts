import { readFileSync } from 'node:fs';
import { PrismaClient } from '@prisma/client';
import { withTenant } from '@datacare/db';
import { saveEntityImage, deleteEntityImage } from '../src/modules/images/entityImage.js';
import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import {
  changeOrderImage,
  getOrderImage,
  customOrderImageKey,
} from '../src/modules/images/orderImage.js';

const db = process.env.RUN_DB_INTEGRITY_TESTS === '1' ? describe : describe.skip;
db('saved order image changes', () => {
  const owner = new PrismaClient({
    datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } },
  });
  const runtime = new PrismaClient();
  const tenantId = 'order-image-write-r3';
  const scope = { tenantId, coCode: '01', lcCode: '01', coYear: '2024-2025', coBook: 'SI1' };
  const image = readFileSync(new URL('./fixtures/order-design-portrait.png', import.meta.url));
  const input = { data: image.toString('base64'), mimeType: 'image/png' };
  const sql = (q: string, ...args: any[]) => owner.$executeRawUnsafe(q, tenantId, ...args);
  async function clean() {
    for (const table of [
      'ENTITY_IMAGE',
      'ENTITY_IMAGE_REVISION',
      'TAG_IMAGE_DATA',
      'SL_ORD_DETL',
      'SL_ORD_DATA',
      'BOOK_DATA',
    ])
      await sql(`DELETE FROM "${table}" WHERE tenant_id=$1`);
  }
  beforeAll(async () => {
    if (!process.env.MIGRATE_DATABASE_URL?.includes(':55433/'))
      throw new Error('Disposable database required.');
    await clean();
    await sql(`INSERT INTO "BOOK_DATA" (tenant_id,"CO_CODE","LC_CODE","CO_BOOK","MAIN_BOOK","BOOK_TBL_NAME","BOOK_INOUT","CUR_USE")
      VALUES ($1,'01','01','SI1','SALES ORDER','SL_ORD_DATA','O','Y'),($1,'01','01','SI2','SALES ORDER','SL_ORD_DATA','O','Y'),($1,'01','01','TI1','TOUR ORDER','SL_ORD_DATA','I','Y')`);
    for (const book of ['SI1', 'SI2', 'TI1']) {
      await sql(
        `INSERT INTO "SL_ORD_DATA" (tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","HD_VCH_NO")
        VALUES ($1,'01','01','2024-2025',$2,'00001','HIDDEN01')`,
        book,
      );
      await sql(
        `INSERT INTO "SL_ORD_DETL" (tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","HD_VCH_NO","SR_NO","DESIGN_NO","DESIGN_IMG_ID","TAG_NO")
        VALUES ($1,'01','01','2024-2025',$2,'00001','HIDDEN01',17,'DESIGN-LONG-IDENTITY','N','N'),($1,'01','01','2024-2025',$2,'00001','HIDDEN01',42,'DESIGN-LONG-IDENTITY','N','N')`,
        book,
      );
    }
  });
  afterAll(async () => {
    await clean();
    await owner.$disconnect();
    await runtime.$disconnect();
  });

  it('round-trips bytes under year/book/hidden/design and shares only the matching saved design within that order', async () => {
    const before = await getOrderImage(runtime, scope, 'SALES ORDER', '1', 17);
    expect(before).toMatchObject({ editable: true, image: { state: 'absent' }, source: 'ORDER' });
    const reorderedScope = {
      coBook: scope.coBook,
      coYear: scope.coYear,
      lcCode: scope.lcCode,
      coCode: scope.coCode,
      tenantId,
    };
    expect((await getOrderImage(runtime, reorderedScope, 'SALES ORDER', '1', 17)).version).toBe(
      before.version,
    );
    await changeOrderImage(runtime, scope, 'SALES ORDER', '1', 17, {
      ...input,
      version: before.version,
    });
    const reopened = await getOrderImage(runtime, scope, 'SALES ORDER', '1', 42);
    expect(reopened.image.state).toBe('present');
    if (reopened.image.state === 'present') expect(reopened.image.bytes.equals(image)).toBe(true);
    expect(
      (await getOrderImage(runtime, { ...scope, coBook: 'SI2' }, 'SALES ORDER', '1', 17)).image
        .state,
    ).toBe('absent');
    const rows: any[] = await owner.$queryRawUnsafe(
      `SELECT "ENTITY_KEY" FROM "ENTITY_IMAGE" WHERE tenant_id=$1`,
      tenantId,
    );
    expect(rows[0].ENTITY_KEY).toBe(
      customOrderImageKey(
        scope,
        { HD_VCH_NO: 'HIDDEN01' },
        { HD_VCH_NO: 'HIDDEN01', DESIGN_NO: 'DESIGN-LONG-IDENTITY' },
      ),
    );
    expect(rows[0].ENTITY_KEY.length).toBeGreaterThan(30);
    await changeOrderImage(runtime, scope, 'SALES ORDER', '1', 17, {
      version: (await getOrderImage(runtime, scope, 'SALES ORDER', '1', 17)).version,
      remove: true,
    });
    expect((await getOrderImage(runtime, scope, 'SALES ORDER', '1', 42)).image.state).toBe(
      'absent',
    );
  });
  it('rejects a stale saved identity without deleting or replacing the old image', async () => {
    const before = await getOrderImage(runtime, scope, 'SALES ORDER', '1', 17);
    await changeOrderImage(runtime, scope, 'SALES ORDER', '1', 17, {
      ...input,
      version: before.version,
    });
    await sql(
      `UPDATE "SL_ORD_DETL" SET "DESIGN_NO"='CHANGED' WHERE tenant_id=$1 AND "CO_BOOK"='SI1' AND "SR_NO"=17`,
    );
    await expect(
      changeOrderImage(runtime, scope, 'SALES ORDER', '1', 17, {
        ...input,
        version: before.version,
      }),
    ).rejects.toThrow('identity changed');
    await expect(
      changeOrderImage(runtime, scope, 'SALES ORDER', '1', 17, {
        version: before.version,
        remove: true,
      }),
    ).rejects.toThrow('identity changed');
    expect((await getOrderImage(runtime, scope, 'SALES ORDER', '1', 42)).image.state).toBe(
      'present',
    );
    await sql(
      `UPDATE "SL_ORD_DETL" SET "DESIGN_NO"='DESIGN-LONG-IDENTITY' WHERE tenant_id=$1 AND "CO_BOOK"='SI1' AND "SR_NO"=17`,
    );
  });
  it('refuses wrong family, branch, voucher and parent serial', async () => {
    await expect(getOrderImage(runtime, scope, 'TOUR ORDER', '1', 17)).rejects.toThrow();
    for (const [vch, sr] of [
      ['9', 17],
      ['1', 1],
      ['1', 0],
    ] as const)
      await expect(getOrderImage(runtime, scope, 'SALES ORDER', vch, sr)).rejects.toThrow();
    await expect(
      getOrderImage(runtime, { ...scope, lcCode: '02' }, 'SALES ORDER', '1', 17),
    ).rejects.toThrow();
  });
  it('requires a complete image decode and leaves valid saved bytes intact on failure', async () => {
    const before = await getOrderImage(runtime, scope, 'SALES ORDER', '1', 17);
    for (const bad of [
      { data: image.subarray(0, 16).toString('base64'), mimeType: 'image/png' },
      { ...input, mimeType: 'image/jpeg' },
    ])
      await expect(
        changeOrderImage(runtime, scope, 'SALES ORDER', '1', 17, {
          ...bad,
          version: before.version,
        }),
      ).rejects.toMatchObject({ code: 'invalid-image' });
    const after = await getOrderImage(runtime, scope, 'SALES ORDER', '1', 17);
    expect(after.image.state).toBe('present');
    if (after.image.state === 'present') expect(after.image.bytes.equals(image)).toBe(true);
  });
  it('exposes shared Design Book images as read-only from the order form', async () => {
    await sql(
      `UPDATE "SL_ORD_DETL" SET "DESIGN_IMG_ID"='01_BOOK_PR_DESIGN' WHERE tenant_id=$1 AND "CO_BOOK"='SI2'`,
    );
    const s = { ...scope, coBook: 'SI2' };
    const record = await getOrderImage(runtime, s, 'SALES ORDER', '1', 17);
    expect(record.editable).toBe(false);
    await expect(
      changeOrderImage(runtime, s, 'SALES ORDER', '1', 17, { ...input, version: record.version }),
    ).rejects.toThrow('Design Book');
  });
  it('stores and removes only the saved tag instance, maintaining its desktop index atomically', async () => {
    await sql(
      `UPDATE "SL_ORD_DETL" SET "TAG_NO"='TAG01',"VCH_SRNO"=9 WHERE tenant_id=$1 AND "CO_BOOK"='TI1' AND "SR_NO"=17`,
    );
    const s = { ...scope, coBook: 'TI1' };
    const before = await getOrderImage(runtime, s, 'TOUR ORDER', '1', 17);
    await changeOrderImage(runtime, s, 'TOUR ORDER', '1', 17, {
      ...input,
      version: before.version,
    });
    const index: any[] = await owner.$queryRawUnsafe(
      `SELECT "VCH_SRNO","IMAGE_TYPE" FROM "TAG_IMAGE_DATA" WHERE tenant_id=$1`,
      tenantId,
    );
    expect(index).toEqual([{ VCH_SRNO: 9, IMAGE_TYPE: 'T' }]);
    await changeOrderImage(runtime, s, 'TOUR ORDER', '1', 17, {
      version: (await getOrderImage(runtime, s, 'TOUR ORDER', '1', 17)).version,
      remove: true,
    });
    expect((await getOrderImage(runtime, s, 'TOUR ORDER', '1', 17)).image.state).toBe('absent');
    expect(
      await owner.$queryRawUnsafe(`SELECT 1 FROM "TAG_IMAGE_DATA" WHERE tenant_id=$1`, tenantId),
    ).toEqual([]);
  });
  it('lets an operator replace missing indexed bytes and malformed bytes without weakening report decoding', async () => {
    const s = { ...scope, coBook: 'TI1' };
    await sql(
      `INSERT INTO "TAG_IMAGE_DATA" (tenant_id,"CO_CODE","LC_CODE","TAG_NO","VCH_SRNO","IMAGE_TYPE") VALUES ($1,'01','01','TAG01',9,'T')`,
    );
    const missing = await getOrderImage(runtime, s, 'TOUR ORDER', '1', 17);
    expect(missing).toMatchObject({
      editable: true,
      image: { state: 'unavailable', code: 'unavailable-image' },
    });
    await changeOrderImage(runtime, s, 'TOUR ORDER', '1', 17, {
      ...input,
      version: missing.version,
    });
    await sql(
      `UPDATE "ENTITY_IMAGE" SET "IMAGE_BYTES"=$2,"IMAGE_SIZE"=16 WHERE tenant_id=$1 AND "ENTITY_TYPE"='TAG'`,
      image.subarray(0, 16),
    );
    const damaged = await getOrderImage(runtime, s, 'TOUR ORDER', '1', 17);
    expect(damaged).toMatchObject({
      editable: true,
      image: { state: 'unavailable', code: 'invalid-image' },
    });
    await changeOrderImage(runtime, s, 'TOUR ORDER', '1', 17, {
      ...input,
      version: damaged.version,
    });
    const repaired = await getOrderImage(runtime, s, 'TOUR ORDER', '1', 17);
    expect(repaired.image.state).toBe('present');
    if (repaired.image.state === 'present') expect(repaired.image.bytes.equals(image)).toBe(true);
  });
  it('rejects stale replacement and deletion, including an absent-image delete/recreate cycle', async () => {
    const s = { ...scope, coBook: 'TI1' };
    let current = await getOrderImage(runtime, s, 'TOUR ORDER', '1', 42);
    if (current.image.state !== 'absent') {
      await changeOrderImage(runtime, s, 'TOUR ORDER', '1', 42, {
        version: current.version,
        remove: true,
      });
      current = await getOrderImage(runtime, s, 'TOUR ORDER', '1', 42);
    }
    const absentVersion = current.version;
    await changeOrderImage(runtime, s, 'TOUR ORDER', '1', 42, { ...input, version: absentVersion });
    for (const mutation of [{ ...input }, { remove: true }])
      await expect(
        changeOrderImage(runtime, s, 'TOUR ORDER', '1', 42, {
          ...mutation,
          version: absentVersion,
        }),
      ).rejects.toThrow('Reload');
    const saved = await getOrderImage(runtime, s, 'TOUR ORDER', '1', 42);
    expect(saved.version).not.toBe(absentVersion);
    await changeOrderImage(runtime, s, 'TOUR ORDER', '1', 42, {
      version: saved.version,
      remove: true,
    });
    const removed = await getOrderImage(runtime, s, 'TOUR ORDER', '1', 42);
    expect(removed.image.state).toBe('absent');
    expect(removed.version).not.toBe(absentVersion);
    await expect(
      changeOrderImage(runtime, s, 'TOUR ORDER', '1', 42, { ...input, version: absentVersion }),
    ).rejects.toThrow('Reload');
    await changeOrderImage(runtime, s, 'TOUR ORDER', '1', 42, {
      ...input,
      version: removed.version,
    });
  });
  it('serializes the same tag image shared by two independently locked orders', async () => {
    const s = { ...scope, coBook: 'TI1' };
    await sql(`INSERT INTO "SL_ORD_DATA" (tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","HD_VCH_NO")
      VALUES ($1,'01','01','2024-2025','TI1','00002','HIDDEN02')`);
    await sql(`INSERT INTO "SL_ORD_DETL" (tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","HD_VCH_NO","SR_NO","DESIGN_NO","DESIGN_IMG_ID","TAG_NO","VCH_SRNO")
      VALUES ($1,'01','01','2024-2025','TI1','00002','HIDDEN02',73,'ANOTHER','N','TAG01',9)`);
    const [a, b] = await Promise.all([
      getOrderImage(runtime, s, 'TOUR ORDER', '1', 17),
      getOrderImage(runtime, s, 'TOUR ORDER', '2', 73),
    ]);
    const jpeg = readFileSync(new URL('./fixtures/order-tag-landscape.jpg', import.meta.url));
    const result = await Promise.allSettled([
      changeOrderImage(runtime, s, 'TOUR ORDER', '1', 17, { ...input, version: a.version }),
      changeOrderImage(runtime, s, 'TOUR ORDER', '2', 73, {
        data: jpeg.toString('base64'),
        mimeType: 'image/jpeg',
        version: b.version,
      }),
    ]);
    expect(result.filter((r) => r.status === 'fulfilled')).toHaveLength(1);
    const rejected = result.find((r) => r.status === 'rejected') as PromiseRejectedResult;
    expect(rejected.reason.message).toContain('Reload');
    const current = await getOrderImage(runtime, s, 'TOUR ORDER', '1', 17);
    expect(current.image.state).toBe('present');
    if (current.image.state === 'present')
      expect(current.image.bytes.equals(result[0].status === 'fulfilled' ? image : jpeg)).toBe(
        true,
      );
    expect(
      await owner.$queryRawUnsafe(
        `SELECT "IMAGE_TYPE" FROM "TAG_IMAGE_DATA" WHERE tenant_id=$1 AND "TAG_NO"='TAG01' AND "VCH_SRNO"=9`,
        tenantId,
      ),
    ).toEqual([{ IMAGE_TYPE: 'T' }]);
  });
  it('invalidates order tokens after generic tag image changes even when identical bytes are restored', async () => {
    const s = { ...scope, coBook: 'TI1' };
    const key = {
      tenantId,
      coCode: '01',
      lcCode: '01',
      entityType: 'TAG',
      entityKey: 'TAG01',
      instance: 9,
    };
    await saveEntityImage(runtime, key, input);
    const prior = await getOrderImage(runtime, s, 'TOUR ORDER', '1', 17);
    await deleteEntityImage(runtime, key);
    await saveEntityImage(runtime, key, input);
    const current = await getOrderImage(runtime, s, 'TOUR ORDER', '1', 17);
    expect(current.version).not.toBe(prior.version);
    await expect(
      changeOrderImage(runtime, s, 'TOUR ORDER', '1', 17, { version: prior.version, remove: true }),
    ).rejects.toThrow('Reload');
    if (current.image.state === 'present') expect(current.image.bytes.equals(image)).toBe(true);
  });
  it('enforces tenant isolation on persistent image revisions', async () => {
    await withTenant(runtime, 'order-image-other', async (tx: any) => {
      expect(
        await tx.$queryRawUnsafe(
          `SELECT * FROM "ENTITY_IMAGE_REVISION" WHERE tenant_id=$1`,
          tenantId,
        ),
      ).toEqual([]);
    });
    await expect(
      withTenant(runtime, 'order-image-other', async (tx: any) =>
        tx.$executeRawUnsafe(
          `INSERT INTO "ENTITY_IMAGE_REVISION" (tenant_id,"CO_CODE","LC_CODE","ENTITY_TYPE","ENTITY_KEY","INSTANCE") VALUES ($1,'01','01','TAG','CROSS',0)`,
          tenantId,
        ),
      ),
    ).rejects.toThrow();
  });
});
