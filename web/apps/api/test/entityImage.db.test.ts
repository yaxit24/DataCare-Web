import { afterAll, beforeEach, describe, expect, it } from 'vitest';
import { PrismaClient } from '@datacare/db';
import { withTenant } from '@datacare/db';
import {
  decodeEntityImage,
  deleteEntityImage,
  getEntityImage,
  listEntityImageKeys,
  saveEntityImage,
  EntityImageError,
  ENTITY_IMAGE_MAX_BYTES,
} from '../src/modules/images/entityImage.js';

const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const d = RUN ? describe : describe.skip;

/** Smallest valid JPEG and PNG headers, so magic-byte detection is exercised with real signatures. */
const JPEG = Buffer.concat([Buffer.from([0xff, 0xd8, 0xff, 0xe0]), Buffer.alloc(16, 7)]);
const PNG = Buffer.concat([
  Buffer.from([0x89, 0x50, 0x4e, 0x47, 0x0d, 0x0a, 0x1a, 0x0a]),
  Buffer.alloc(16, 3),
]);
const b64 = (b: Buffer): string => b.toString('base64');

describe('entity image decoding', () => {
  it('detects JPEG and PNG from magic bytes', () => {
    expect(decodeEntityImage({ data: b64(JPEG) }).mimeType).toBe('image/jpeg');
    expect(decodeEntityImage({ data: b64(PNG) }).mimeType).toBe('image/png');
  });

  it('accepts a data URL as well as bare base64', () => {
    const r = decodeEntityImage({ data: `data:image/jpeg;base64,${b64(JPEG)}` });
    expect(r.mimeType).toBe('image/jpeg');
    expect(r.bytes.length).toBe(JPEG.length);
  });

  it('REJECTS a declared type that disagrees with the content', () => {
    // The stored MIME is served back to browsers later, so a spoofed declaration must not be honoured.
    expect(() => decodeEntityImage({ data: b64(JPEG), mimeType: 'image/png' })).toThrow(
      EntityImageError,
    );
    expect(() => decodeEntityImage({ data: b64(PNG), mimeType: 'image/jpeg' })).toThrow(
      EntityImageError,
    );
  });

  it('rejects anything that is not a JPEG or PNG', () => {
    // A PDF header, an HTML fragment and a bare text payload must all be refused.
    expect(() => decodeEntityImage({ data: b64(Buffer.from('%PDF-1.7')) })).toThrow(
      EntityImageError,
    );
    expect(() => decodeEntityImage({ data: b64(Buffer.from('<svg onload=alert(1)>')) })).toThrow(
      EntityImageError,
    );
    expect(() => decodeEntityImage({ data: b64(Buffer.from('hello')) })).toThrow(EntityImageError);
  });

  it('rejects empty and oversized payloads', () => {
    expect(() => decodeEntityImage({ data: '' })).toThrow(EntityImageError);
    const huge = Buffer.concat([JPEG, Buffer.alloc(ENTITY_IMAGE_MAX_BYTES, 1)]);
    expect(() => decodeEntityImage({ data: b64(huge) })).toThrow(/exceeds/);
  });
});

d('entity image storage', () => {
  const prisma = new PrismaClient();
  // tenant_id is varchar(24), so DB tests use short kebab tenants.
  const tenantId = 'entimage-db';
  const other = 'entimage-other-db';
  const CO = '01';
  const LC = '01';
  const key = {
    tenantId,
    coCode: CO,
    lcCode: LC,
    entityType: 'TAG' as const,
    entityKey: 'TAG001',
    instance: 1,
  };

  const clean = (t: string) =>
    withTenant(prisma, t, async (tx: any) => {
      for (const tbl of ['ENTITY_IMAGE', 'ENTITY_IMAGE_REVISION', 'TAG_IMAGE_DATA']) {
        await tx.$executeRawUnsafe(`DELETE FROM "${tbl}" WHERE tenant_id=$1`, t);
      }
    });

  beforeEach(async () => {
    await clean(tenantId);
    await clean(other);
  });
  afterAll(async () => {
    await clean(tenantId);
    await clean(other);
    await prisma.$disconnect();
  });

  it('stores bytes and returns them unchanged', async () => {
    const r = await saveEntityImage(prisma, key, { data: b64(JPEG), user: 'admin' });
    expect(r).toMatchObject({ saved: true, mimeType: 'image/jpeg', size: JPEG.length });
    const got = await getEntityImage(prisma, key);
    expect(got?.mimeType).toBe('image/jpeg');
    expect(got?.size).toBe(JPEG.length);
    // Byte-for-byte equality: a re-encoding bug would surface here rather than as a corrupt download.
    expect(Buffer.compare(got!.bytes, JPEG)).toBe(0);
  });

  it('keeps the desktop TAG_IMAGE_DATA index in step', async () => {
    await saveEntityImage(prisma, key, { data: b64(JPEG) });
    const idx: any[] = await withTenant(prisma, tenantId, (tx: any) =>
      tx.$queryRawUnsafe(
        `SELECT "TAG_NO","VCH_SRNO","IMAGE_TYPE" FROM "TAG_IMAGE_DATA" WHERE tenant_id=$1`,
        tenantId,
      ),
    );
    // The desktop reads this table, so it must exist alongside the bytes.
    expect(idx.length).toBe(1);
    expect(idx[0].TAG_NO).toBe('TAG001');
    // Saving twice must not create a second index row.
    await saveEntityImage(prisma, key, { data: b64(PNG) });
    const again: any[] = await withTenant(prisma, tenantId, (tx: any) =>
      tx.$queryRawUnsafe(`SELECT 1 FROM "TAG_IMAGE_DATA" WHERE tenant_id=$1`, tenantId),
    );
    expect(again.length).toBe(1);
  });

  it('replaces rather than accumulates on re-upload', async () => {
    await saveEntityImage(prisma, key, { data: b64(JPEG) });
    await saveEntityImage(prisma, key, { data: b64(PNG) });
    const rows: any[] = await withTenant(prisma, tenantId, (tx: any) =>
      tx.$queryRawUnsafe(`SELECT "MIME_TYPE" FROM "ENTITY_IMAGE" WHERE tenant_id=$1`, tenantId),
    );
    expect(rows.length).toBe(1);
    expect(rows[0].MIME_TYPE).toBe('image/png');
  });

  it('separates images by voucher instance', async () => {
    // The same tag number recurs across vouchers, so VCH_SRNO is part of the identity.
    await saveEntityImage(prisma, key, { data: b64(JPEG) });
    await saveEntityImage(prisma, { ...key, instance: 2 }, { data: b64(PNG) });
    expect((await getEntityImage(prisma, key))?.mimeType).toBe('image/jpeg');
    expect((await getEntityImage(prisma, { ...key, instance: 2 }))?.mimeType).toBe('image/png');
    expect((await listEntityImageKeys(prisma, { tenantId, coCode: CO, lcCode: LC })).length).toBe(
      2,
    );
  });

  it('treats the image type as an attribute, matching the desktop identity', async () => {
    // TAG_IMAGE_DATA's primary key is (tenant, CO, LC, TAG_NO, VCH_SRNO) and EXCLUDES IMAGE_TYPE, so a tag
    // instance holds ONE image and the type says which kind it is. Saving 'D' over 'T' replaces rather than
    // adding a second row — a richer identity here could not be represented in the desktop's index table.
    await saveEntityImage(prisma, key, { data: b64(JPEG) });
    await saveEntityImage(prisma, { ...key, imageType: 'D' }, { data: b64(PNG) });
    const rows: any[] = await withTenant(prisma, tenantId, (tx: any) =>
      tx.$queryRawUnsafe(
        `SELECT "IMAGE_TYPE","MIME_TYPE" FROM "ENTITY_IMAGE" WHERE tenant_id=$1`,
        tenantId,
      ),
    );
    expect(rows.length).toBe(1);
    expect(rows[0].IMAGE_TYPE).toBe('D'); // 'D' = design image (TR_APR_ISU.cs:7050)
    expect(rows[0].MIME_TYPE).toBe('image/png');
    const idx: any[] = await withTenant(prisma, tenantId, (tx: any) =>
      tx.$queryRawUnsafe(`SELECT "IMAGE_TYPE" FROM "TAG_IMAGE_DATA" WHERE tenant_id=$1`, tenantId),
    );
    expect(idx.length).toBe(1);
    expect(idx[0].IMAGE_TYPE).toBe('D');
  });

  it('deletes both the bytes and the index row', async () => {
    await saveEntityImage(prisma, key, { data: b64(JPEG) });
    expect((await deleteEntityImage(prisma, key)).deleted).toBe(true);
    expect(await getEntityImage(prisma, key)).toBeNull();
    const idx: any[] = await withTenant(prisma, tenantId, (tx: any) =>
      tx.$queryRawUnsafe(`SELECT 1 FROM "TAG_IMAGE_DATA" WHERE tenant_id=$1`, tenantId),
    );
    expect(idx.length).toBe(0);
    // Deleting again is not an error, it simply reports nothing was removed.
    expect((await deleteEntityImage(prisma, key)).deleted).toBe(false);
  });

  it('isolates tenants', async () => {
    await saveEntityImage(prisma, key, { data: b64(JPEG) });
    await saveEntityImage(prisma, { ...key, tenantId: other }, { data: b64(PNG) });
    // Each tenant sees only its own image even though the tag key is identical.
    expect((await getEntityImage(prisma, key))?.mimeType).toBe('image/jpeg');
    expect((await getEntityImage(prisma, { ...key, tenantId: other }))?.mimeType).toBe('image/png');
    expect((await listEntityImageKeys(prisma, { tenantId, coCode: CO })).length).toBe(1);
  });

  it('filters the key list by tag', async () => {
    await saveEntityImage(prisma, key, { data: b64(JPEG) });
    await saveEntityImage(prisma, { ...key, entityKey: 'TAG002' }, { data: b64(PNG) });
    const only = await listEntityImageKeys(prisma, { tenantId, coCode: CO }, ['TAG002']);
    expect(only.map((k) => k.entityKey)).toEqual(['TAG002']);
  });

  it('requires an entity key', async () => {
    await expect(
      saveEntityImage(prisma, { ...key, entityKey: '  ' }, { data: b64(JPEG) }),
    ).rejects.toBeInstanceOf(EntityImageError);
  });

  it('keys non-tag entities on their own record, not a tag number', async () => {
    // A party photo, a member photo and scheme artwork are different records that happen to share a code
    // space. Keying them all on TAG_NO would collide; ENTITY_TYPE separates them.
    const party = { ...key, entityType: 'AC' as const, entityKey: 'CASH', instance: 0 };
    const member = { ...key, entityType: 'MEMB' as const, entityKey: 'CASH', instance: 0 };
    const scheme = { ...key, entityType: 'SCHM' as const, entityKey: 'CASH', instance: 0 };
    await saveEntityImage(prisma, party, { data: b64(JPEG) });
    await saveEntityImage(prisma, member, { data: b64(PNG) });
    await saveEntityImage(prisma, scheme, { data: b64(JPEG) });
    expect((await getEntityImage(prisma, party))?.mimeType).toBe('image/jpeg');
    expect((await getEntityImage(prisma, member))?.mimeType).toBe('image/png');
    expect((await getEntityImage(prisma, scheme))?.mimeType).toBe('image/jpeg');
    // Three distinct rows despite the identical key text.
    const all = await listEntityImageKeys(prisma, { tenantId, coCode: CO, lcCode: LC });
    expect(all.length).toBe(3);
    expect(new Set(all.map((a) => a.entityType))).toEqual(new Set(['AC', 'MEMB', 'SCHM']));
  });

  it('mirrors ONLY tag images into the desktop TAG_IMAGE_DATA index', async () => {
    // TAG_IMAGE_DATA's primary key has no room for an entity kind, so a party photo must not appear there.
    await saveEntityImage(
      prisma,
      { ...key, entityType: 'AC', entityKey: 'PARTY1', instance: 0 },
      {
        data: b64(JPEG),
      },
    );
    let idxRows: any[] = await withTenant(prisma, tenantId, (tx: any) =>
      tx.$queryRawUnsafe(`SELECT "TAG_NO" FROM "TAG_IMAGE_DATA" WHERE tenant_id=$1`, tenantId),
    );
    expect(idxRows.length).toBe(0);
    // A tag image does get indexed.
    await saveEntityImage(prisma, key, { data: b64(JPEG) });
    idxRows = await withTenant(prisma, tenantId, (tx: any) =>
      tx.$queryRawUnsafe(`SELECT "TAG_NO" FROM "TAG_IMAGE_DATA" WHERE tenant_id=$1`, tenantId),
    );
    expect(idxRows.map((r) => r.TAG_NO)).toEqual(['TAG001']);
  });

  it('rejects an unknown entity type', async () => {
    await expect(
      saveEntityImage(prisma, { ...key, entityType: 'NOPE' }, { data: b64(JPEG) }),
    ).rejects.toThrow(/unknown image entity type/);
  });

  it('filters the key list by entity type', async () => {
    await saveEntityImage(prisma, key, { data: b64(JPEG) });
    await saveEntityImage(
      prisma,
      { ...key, entityType: 'AC', entityKey: 'CASH', instance: 0 },
      {
        data: b64(PNG),
      },
    );
    const tags = await listEntityImageKeys(prisma, {
      tenantId,
      coCode: CO,
      lcCode: LC,
      entityType: 'TAG',
    });
    expect(tags.map((t) => t.entityKey)).toEqual(['TAG001']);
  });
});
