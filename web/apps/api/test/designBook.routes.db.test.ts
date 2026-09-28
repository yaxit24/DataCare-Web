import { readFileSync } from 'node:fs';
import { PrismaClient } from '@prisma/client';
import type { FastifyInstance } from 'fastify';
import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import { buildApp } from '../src/app.js';
import { hashPassword } from '../src/modules/auth/password.js';

const enabled = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const tenantId = 'design-route-db';
const PASSWORD = 'Design-Test-Password!1';
const SECRET = 'design-route-test-signing-secret-over-thirty-two-characters';
const book = { bookName: 'ROUTE BOOK', prCode: 'RG' };
const URL = '/masters/design-book';
// Complete PNG bytes: modern HTTP uploads perform a full pixel decode.
const PNG = readFileSync(
  new globalThis.URL('./fixtures/order-design-portrait.png', import.meta.url),
).toString('base64');

(enabled ? describe : describe.skip)('X11 design book HTTP lifecycle and rights', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;
  let app: FastifyInstance;
  let creator: string;
  let editor: string;
  let outsider: string;
  let version: string;
  let imageId: string;
  const cleanup = async () => {
    for (const table of [
      'audit_log',
      'auth_session',
      'ENTITY_IMAGE',
      'ENTITY_IMAGE_REVISION',
      'DESIGN_IDTL',
      'DESIGN_DETL',
      'USER_SET',
      'LOGIN_MAST',
      'YEAR_MAST',
      'LOCT_MAST',
      'CO_MAST',
    ]) {
      await owner.$executeRawUnsafe(`DELETE FROM "${table}" WHERE tenant_id=$1`, tenantId);
    }
  };
  async function login(name: string) {
    const response = await app.inject({
      method: 'POST',
      url: '/auth/login',
      headers: { 'x-tenant-id': tenantId },
      payload: {
        coCode: '01',
        loginName: name,
        password: PASSWORD,
        lcCode: '01',
        coYear: '2024-2025',
      },
    });
    expect(response.statusCode, response.body).toBe(200);
    const cookie = response.headers['set-cookie'];
    return (Array.isArray(cookie) ? cookie : [cookie ?? ''])
      .map((value) => value.split(';', 1)[0])
      .join('; ');
  }
  beforeAll(async () => {
    owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
    runtime = new PrismaClient();
    await cleanup();
    await owner.$executeRawUnsafe(
      'INSERT INTO "CO_MAST"(tenant_id,"CO_CODE","CO_NAME","LC_CODE") VALUES ($1,\'01\',\'Design Test\',\'01\')',
      tenantId,
    );
    await owner.$executeRawUnsafe(
      'INSERT INTO "LOCT_MAST"(tenant_id,"CO_CODE","LC_CODE","LC_NAME") VALUES ($1,\'01\',\'01\',\'Main\')',
      tenantId,
    );
    await owner.$executeRawUnsafe(
      'INSERT INTO "YEAR_MAST"(tenant_id,"CO_CODE","CO_YEAR") VALUES ($1,\'01\',\'2024-2025\')',
      tenantId,
    );
    const hash = await hashPassword(PASSWORD);
    for (const name of ['design-create', 'design-edit', 'design-none']) {
      await owner.$executeRawUnsafe(
        `INSERT INTO "LOGIN_MAST"(tenant_id,"CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG","USER_UPDATE","USER_DELETE","USER_PRINT","PASSWORD_RESET_REQUIRED")
        VALUES ($1,'01',$2,$3,'USER','Y','Y','Y','N')`,
        tenantId,
        name,
        hash,
      );
      if (name !== 'design-none')
        await owner.$executeRawUnsafe(
          `INSERT INTO "USER_SET"(tenant_id,"CO_CODE","LC_CODE","USER_NAME","MAIN_MENU","SUB_MENU","FRM_VIEW","FRM_EDIT","FRM_DELETE","FRM_PRINT")
        VALUES ($1,'01','01',$2,'Masters','Design Book','Y',$3,$3,'N')`,
          tenantId,
          name,
          name === 'design-edit' ? 'Y' : 'N',
        );
    }
    app = await buildApp({ prisma: runtime, secret: SECRET, secureCookies: false });
    creator = await login('design-create');
    editor = await login('design-edit');
    outsider = await login('design-none');
  });
  afterAll(async () => {
    if (app) await app.close();
    if (owner) await cleanup();
    if (runtime) await runtime.$disconnect();
    if (owner) await owner.$disconnect();
  });

  it('requires the selected book and a saved version before destructive changes', async () => {
    const missingBook = await app.inject({
      method: 'GET',
      url: `${URL}?prCode=RG`,
      headers: { cookie: editor },
    });
    expect(missingBook.statusCode, missingBook.body).toBe(400);
    expect(missingBook.json()).toMatchObject({ error: 'DesignBookValidationError' });
    const missingVersion = await app.inject({
      method: 'DELETE',
      url: URL,
      headers: { cookie: editor },
      payload: book,
    });
    expect(missingVersion.statusCode, missingVersion.body).toBe(400);
    expect(missingVersion.json()).toMatchObject({ error: 'DesignBookValidationError' });
  });

  it('creates and reads actual children with view/create rights and protects edits from create-only users', async () => {
    const payload = {
      ...book,
      lines: [
        {
          srNo: 17,
          designNo: 'R-001',
          style: 'engraved',
          grossWt: 15.375,
          components: [
            { isrNo: 8, itCode: 'STONE', karigarWt: 0.751, grossWt: 0.633, netAmount: 234.56 },
          ],
        },
      ],
    };
    const created = await app.inject({
      method: 'POST',
      url: URL,
      headers: { cookie: creator },
      payload,
    });
    expect(created.statusCode, created.body).toBe(200);
    const read = await app.inject({
      method: 'GET',
      url: `${URL}?${new URLSearchParams(book)}`,
      headers: { cookie: creator },
    });
    expect(read.statusCode, read.body).toBe(200);
    const [saved] = read.json();
    version = saved.bookVersion;
    imageId = saved.DESIGN_IMG_ID;
    expect(saved.components).toHaveLength(1);
    expect(saved.components[0]).toMatchObject({ SR_NO: 17, ISR_NO: 8, IT_CODE: 'STONE' });
    expect(Number(saved.components[0].KR_WT)).toBe(0.751);
    const overwrite = await app.inject({
      method: 'POST',
      url: URL,
      headers: { cookie: creator },
      payload: { ...payload, expectedVersion: version },
    });
    expect(overwrite.statusCode, overwrite.body).toBe(409);
    for (const method of ['PUT', 'DELETE'] as const) {
      const denied = await app.inject({
        method,
        url: URL,
        headers: { cookie: creator },
        payload: { ...payload, expectedVersion: version },
      });
      expect(denied.statusCode, denied.body).toBe(403);
    }
  });

  it('uploads, reads and removes a saved design image with design rights and no tag rights', async () => {
    const imageUrl = `${URL}/image?${new URLSearchParams({ entityKey: imageId })}`;
    const noRights = await app.inject({
      method: 'POST',
      url: `${URL}/image`,
      headers: { cookie: outsider },
      payload: { entityKey: imageId, data: PNG },
    });
    expect(noRights.statusCode).toBe(403);
    const createOnly = await app.inject({
      method: 'POST',
      url: `${URL}/image`,
      headers: { cookie: creator },
      payload: { entityKey: imageId, data: PNG },
    });
    expect(createOnly.statusCode).toBe(403);
    const initialImage = await app.inject({
      method: 'GET',
      url: `${URL}/image/state?${new URLSearchParams({ entityKey: imageId })}`,
      headers: { cookie: editor },
    });
    expect(initialImage.statusCode, initialImage.body).toBe(200);
    const saved = await app.inject({
      method: 'POST',
      url: `${URL}/image`,
      headers: { cookie: editor },
      payload: {
        entityKey: imageId,
        data: PNG,
        mimeType: 'image/png',
        version: initialImage.json().version,
      },
    });
    expect(saved.statusCode, saved.body).toBe(200);
    const read = await app.inject({ method: 'GET', url: imageUrl, headers: { cookie: creator } });
    expect(read.statusCode, read.body).toBe(200);
    expect(read.headers['content-type']).toBe('image/png');
    expect(read.rawPayload).toEqual(Buffer.from(PNG, 'base64'));
    const stored = await owner.$queryRawUnsafe<Record<string, unknown>[]>(
      'SELECT "LC_CODE","ENTITY_TYPE","ENTITY_KEY","IMAGE_TYPE" FROM "ENTITY_IMAGE" WHERE tenant_id=$1',
      tenantId,
    );
    expect(stored).toEqual([
      { LC_CODE: '', ENTITY_TYPE: 'DESIGN', ENTITY_KEY: imageId, IMAGE_TYPE: 'D' },
    ]);
    const savedImage = await app.inject({
      method: 'GET',
      url: `${URL}/image/state?${new URLSearchParams({ entityKey: imageId })}`,
      headers: { cookie: editor },
    });
    expect(savedImage.statusCode, savedImage.body).toBe(200);
    const removed = await app.inject({
      method: 'DELETE',
      url: `${imageUrl}&version=${savedImage.json().version}`,
      headers: { cookie: editor },
    });
    expect(removed.statusCode, removed.body).toBe(200);
    expect(
      (await app.inject({ method: 'GET', url: imageUrl, headers: { cookie: creator } })).statusCode,
    ).toBe(404);
  });

  it('refuses images for an unsaved or different company design identity', async () => {
    await owner.$executeRawUnsafe(
      'INSERT INTO "DESIGN_DETL"(tenant_id,"CO_CODE","BOOK_NAME","PR_CODE","SR_NO","DESIGN_NO","DESIGN_IMG_ID") VALUES ($1,\'02\',\'OTHER BOOK\',\'RG\',17,\'R-001\',\'02_OTHER BOOK_RG_R-001\')',
      tenantId,
    );
    const current = await app.inject({
      method: 'GET',
      url: `${URL}/image/state?${new URLSearchParams({ entityKey: imageId })}`,
      headers: { cookie: editor },
    });
    expect(current.statusCode, current.body).toBe(200);
    for (const entityKey of ['unsaved-design', '02_OTHER BOOK_RG_R-001']) {
      const response = await app.inject({
        method: 'POST',
        url: `${URL}/image`,
        headers: { cookie: editor },
        payload: { entityKey, data: PNG, version: current.json().version },
      });
      expect(response.statusCode, response.body).toBe(400);
      expect(
        (
          await app.inject({
            method: 'GET',
            url: `${URL}/image?${new URLSearchParams({ entityKey })}`,
            headers: { cookie: editor },
          })
        ).statusCode,
      ).toBe(404);
    }
  });

  it('edits through PUT, rejects stale delete, then deletes parent and child with the current version', async () => {
    const changed = await app.inject({
      method: 'PUT',
      url: URL,
      headers: { cookie: editor },
      payload: {
        ...book,
        expectedVersion: version,
        lines: [
          {
            srNo: 17,
            designNo: 'R-001',
            pageNo: 'new-page',
            components: [{ isrNo: 8, itCode: 'STONE', netAmount: 345.67 }],
          },
        ],
      },
    });
    expect(changed.statusCode, changed.body).toBe(200);
    const staleDelete = await app.inject({
      method: 'DELETE',
      url: URL,
      headers: { cookie: editor },
      payload: { ...book, expectedVersion: version },
    });
    expect(staleDelete.statusCode, staleDelete.body).toBe(409);
    const read = await app.inject({
      method: 'GET',
      url: `${URL}?${new URLSearchParams(book)}`,
      headers: { cookie: editor },
    });
    const [saved] = read.json();
    expect(Number(saved.components[0].KR_WT)).toBe(0.751);
    expect(Number(saved.components[0].IT_NET_AMT)).toBe(345.67);
    const deleted = await app.inject({
      method: 'DELETE',
      url: URL,
      headers: { cookie: editor },
      payload: { ...book, expectedVersion: saved.bookVersion },
    });
    expect(deleted.statusCode, deleted.body).toBe(200);
    expect(
      (
        await app.inject({
          method: 'GET',
          url: `${URL}?${new URLSearchParams(book)}`,
          headers: { cookie: editor },
        })
      ).json(),
    ).toEqual([]);
    const children = await owner.$queryRawUnsafe<Record<string, unknown>[]>(
      'SELECT * FROM "DESIGN_IDTL" WHERE tenant_id=$1 AND "CO_CODE"=\'01\'',
      tenantId,
    );
    expect(children).toEqual([]);
  });
});
