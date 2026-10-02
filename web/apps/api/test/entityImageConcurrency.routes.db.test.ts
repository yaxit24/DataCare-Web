import sharp from 'sharp';
import { readFileSync } from 'node:fs';
import { PrismaClient } from '@prisma/client';
import type { FastifyInstance } from 'fastify';
import { afterAll, beforeAll, beforeEach, describe, expect, it } from 'vitest';
import { buildApp } from '../src/app.js';
import { hashPassword } from '../src/modules/auth/password.js';
import { assertIsolatedTestDatabase } from './support/isolatedDatabase.js';

const enabled = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const tenantId = 'image-cas-r5';
const otherTenant = 'image-cas-other-r5';
const tenants = [tenantId, otherTenant];
const PASSWORD = 'Image-CAS-Test!2026';
const SECRET = 'image-cas-route-test-signing-secret-over-thirty-two-characters';
const PNG = readFileSync(new URL('./fixtures/order-design-portrait.png', import.meta.url));
const JPEG = readFileSync(new URL('./fixtures/order-tag-landscape.jpg', import.meta.url));
const first = { data: PNG.toString('base64'), mimeType: 'image/png' };
const second = { data: JPEG.toString('base64'), mimeType: 'image/jpeg' };
const tag = { entityType: 'TAG', entityKey: 'CAS-TAG', instance: 9, imageType: 'T' };
const designId = '01_CASBOOK_RG_RING';
const design = { entityType: 'DESIGN', entityKey: designId, instance: 0, imageType: 'D' };
const fullScope = { coCode: '01', lcCode: '01', coYear: '2024-2025' };

type Identity = typeof tag;
type Role = 'all' | 'view' | 'update' | 'delete' | 'print' | 'design' | 'tour' | 'none' | 'other';

(enabled ? describe : describe.skip)('generic entity image HTTP compare-and-swap', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;
  let app: FastifyInstance;
  const cookies: Partial<Record<Role, string>> = {};
  const roles: Array<[Exclude<Role, 'other'>, string, string, string, string, string]> = [
    ['all', 'Inventory', 'Tag Print', 'Y', 'Y', 'Y'],
    ['view', 'Inventory', 'Tag Print', 'Y', 'N', 'N'],
    ['update', 'Inventory', 'Tag Print', 'Y', 'Y', 'N'],
    ['delete', 'Inventory', 'Tag Print', 'Y', 'N', 'Y'],
    ['print', 'Inventory', 'Tag Print', 'N', 'N', 'N'],
    ['design', 'Masters', 'Design Book', 'Y', 'Y', 'Y'],
    ['tour', 'Karigar', 'Tour Order', 'Y', 'Y', 'Y'],
    ['none', 'Masters', 'Account', 'Y', 'Y', 'Y'],
  ];
  const sql = (query: string, ...args: unknown[]) => owner.$executeRawUnsafe(query, ...args);
  const request = (
    method: 'GET' | 'POST' | 'DELETE',
    url: string,
    payload?: any,
    role: Role = 'all',
  ) =>
    app.inject({
      method,
      url,
      headers: { cookie: cookies[role] ?? '' },
      ...(payload === undefined ? {} : { payload }),
    });
  const query = (values: Record<string, unknown>) =>
    new URLSearchParams(
      Object.entries(values).map(([k, v]): [string, string] => [k, String(v)]),
    ).toString();
  const genericUrl = (suffix = '', key: Identity = tag, extra: Record<string, unknown> = {}) =>
    `/stock/tag-image${suffix}?${query({ ...fullScope, ...key, ...extra })}`;
  const designUrl = (suffix = '', extra: Record<string, unknown> = {}) =>
    `/masters/design-book/image${suffix}?${query({ ...fullScope, entityKey: designId, ...extra })}`;
  const orderUrl = `/tour-orders/00001/image?${query({ ...fullScope, coBook: 'T51', srNo: 17 })}`;
  const mutationPayload = (version: string | undefined, image = first, key: Identity = tag) => ({
    ...fullScope,
    ...key,
    ...image,
    ...(version === undefined ? {} : { version }),
  });
  async function snapshot() {
    const data: Record<string, unknown> = {};
    for (const table of ['ENTITY_IMAGE', 'ENTITY_IMAGE_REVISION', 'TAG_IMAGE_DATA']) {
      data[table] = await owner.$queryRawUnsafe(
        `SELECT to_jsonb(t) AS row FROM "${table}" t WHERE tenant_id IN ($1,$2) ORDER BY to_jsonb(t)::text`,
        tenantId,
        otherTenant,
      );
    }
    return data;
  }
  async function cleanImages() {
    for (const t of tenants)
      for (const table of ['ENTITY_IMAGE', 'ENTITY_IMAGE_REVISION', 'TAG_IMAGE_DATA'])
        await sql(`DELETE FROM "${table}" WHERE tenant_id=$1`, t);
  }
  async function cleanup() {
    for (const t of tenants)
      for (const table of [
        'audit_log',
        'auth_session',
        'ENTITY_IMAGE',
        'ENTITY_IMAGE_REVISION',
        'TAG_IMAGE_DATA',
        'SL_ORD_DETL',
        'SL_ORD_DATA',
        'DESIGN_DETL',
        'BOOK_DATA',
        'USER_SET',
        'LOGIN_MAST',
        'YEAR_MAST',
        'LOCT_MAST',
        'CO_MAST',
      ])
        await sql(`DELETE FROM "${table}" WHERE tenant_id=$1`, t);
  }
  async function login(t: string, name: string) {
    const result = await app.inject({
      method: 'POST',
      url: '/auth/login',
      headers: { 'x-tenant-id': t },
      payload: { ...fullScope, loginName: name, password: PASSWORD },
    });
    expect(result.statusCode, result.body).toBe(200);
    const values = result.headers['set-cookie'];
    return (Array.isArray(values) ? values : [values ?? ''])
      .map((v) => v.split(';', 1)[0])
      .join('; ');
  }
  beforeAll(async () => {
    assertIsolatedTestDatabase();
    owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
    runtime = new PrismaClient();
    await cleanup();
    const hash = await hashPassword(PASSWORD);
    for (const t of tenants) {
      await sql(
        `INSERT INTO "CO_MAST"(tenant_id,"CO_CODE","CO_NAME","LC_CODE") VALUES ($1,'01','Image CAS Test','01'),($1,'02','Other Company','01')`,
        t,
      );
      await sql(
        `INSERT INTO "LOCT_MAST"(tenant_id,"CO_CODE","LC_CODE","LC_NAME") VALUES ($1,'01','01','Main'),($1,'01','02','Other Branch'),($1,'02','01','Other Company')`,
        t,
      );
      await sql(
        `INSERT INTO "YEAR_MAST"(tenant_id,"CO_CODE","CO_YEAR","OP_DATE","CL_DATE") VALUES ($1,'01','2024-2025','2024-04-01','2025-03-31'),($1,'02','2024-2025','2024-04-01','2025-03-31')`,
        t,
      );
      for (const [name, main, sub, view, edit, del] of t === tenantId
        ? roles
        : roles.filter(([r]) => r === 'all')) {
        await sql(
          `INSERT INTO "LOGIN_MAST"(tenant_id,"CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG","USER_UPDATE","USER_DELETE","USER_PRINT","PASSWORD_RESET_REQUIRED")
          VALUES ($1,'01',$2,$3,'USER','Y','Y','Y','N')`,
          t,
          name,
          hash,
        );
        await sql(
          `INSERT INTO "USER_SET"(tenant_id,"CO_CODE","LC_CODE","USER_NAME","MAIN_MENU","SUB_MENU","FRM_VIEW","FRM_EDIT","FRM_DELETE","FRM_PRINT")
          VALUES ($1,'01','01',$2,$3,$4,$5,$6,$7,'Y')`,
          t,
          name,
          main,
          sub,
          view,
          edit,
          del,
        );
      }
    }
    await sql(
      `INSERT INTO "DESIGN_DETL"(tenant_id,"CO_CODE","BOOK_NAME","PR_CODE","SR_NO","DESIGN_NO","DESIGN_IMG_ID")
      VALUES ($1,'01','CAS BOOK','RG',17,'RING',$2),($1,'02','CAS BOOK','RG',17,'RING','02_CASBOOK_RG_RING')`,
      tenantId,
      designId,
    );
    await sql(
      `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","MAIN_BOOK","BOOK_INOUT","CUR_USE","BOOK_TBL_NAME")
      VALUES ($1,'01','01','T51','CAS Tour','TOUR ORDER','I','Y','SL_ORD_DATA')`,
      tenantId,
    );
    await sql(
      `INSERT INTO "SL_ORD_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","HD_VCH_NO")
      VALUES ($1,'01','01','2024-2025','T51','00001','CAS-HIDDEN')`,
      tenantId,
    );
    await sql(
      `INSERT INTO "SL_ORD_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","HD_VCH_NO","SR_NO","DESIGN_NO","DESIGN_IMG_ID","TAG_NO","VCH_SRNO")
      VALUES ($1,'01','01','2024-2025','T51','00001','CAS-HIDDEN',17,'RING','N','CAS-TAG',9)`,
      tenantId,
    );
    app = await buildApp({ prisma: runtime, secret: SECRET, secureCookies: false });
    for (const [role] of roles) cookies[role] = await login(tenantId, role);
    cookies.other = await login(otherTenant, 'all');
  });
  beforeEach(cleanImages);
  afterAll(async () => {
    if (app) await app.close();
    if (owner) await cleanup();
    if (runtime) await runtime.$disconnect();
    if (owner) await owner.$disconnect();
  });

  async function state(key: Identity = tag, role: Role = 'all') {
    const response = await request('GET', genericUrl('/state', key), undefined, role);
    expect(response.statusCode, response.body).toBe(200);
    const result = response.json();
    expect(result.version).toMatch(/^[0-9a-f]{64}$/);
    expect(response.headers['cache-control']).toBe('no-store');
    expect(result.canUpdate).toEqual(expect.any(Boolean));
    expect(result.canDelete).toEqual(expect.any(Boolean));
    return result;
  }
  async function designState() {
    const response = await request('GET', designUrl('/state'), undefined, 'design');
    expect(response.statusCode, response.body).toBe(200);
    expect(response.json().version).toMatch(/^[0-9a-f]{64}$/);
    return response.json();
  }
  async function assertBytes(expected: Buffer, key: Identity = tag, role: Role = 'all') {
    const result = await request('GET', genericUrl('', key), undefined, role);
    expect(result.statusCode, result.body).toBe(200);
    expect(result.rawPayload.equals(expected)).toBe(true);
  }
  async function assertIndex(imageType = 'T') {
    const rows = await owner.$queryRawUnsafe(
      `SELECT "TAG_NO","VCH_SRNO","IMAGE_TYPE" FROM "TAG_IMAGE_DATA" WHERE tenant_id=$1 AND "CO_CODE"='01' AND "LC_CODE"='01'`,
      tenantId,
    );
    expect(rows).toEqual([
      { TAG_NO: tag.entityKey, VCH_SRNO: tag.instance, IMAGE_TYPE: imageType },
    ]);
  }

  it('provides a load token even when absent and refuses a missing mutation version without writes', async () => {
    expect((await state()).image).toEqual({ state: 'absent' });
    expect((await request('GET', genericUrl())).statusCode).toBe(404);
    const before = await snapshot();
    for (const method of ['POST', 'DELETE'] as const) {
      const response = await request(
        method,
        genericUrl(),
        method === 'POST' ? mutationPayload(undefined) : undefined,
      );
      expect(response.statusCode, response.body).toBe(400);
      expect(response.body).toMatch(/version|load/i);
      expect(await snapshot()).toEqual(before);
    }
  });

  it('refuses stale replacement and stale delete while keeping winning bytes and tag index intact', async () => {
    const original = await state();
    const created = await request('POST', genericUrl(), mutationPayload(original.version));
    expect(created.statusCode, created.body).toBe(200);
    const saved = await state();
    expect(saved.version).not.toBe(original.version);
    const before = await snapshot();
    const replace = await request('POST', genericUrl(), mutationPayload(original.version, second));
    expect(replace.statusCode, replace.body).toBe(409);
    const remove = await request('DELETE', genericUrl('', tag, { version: original.version }));
    expect(remove.statusCode, remove.body).toBe(409);
    expect(await snapshot()).toEqual(before);
    await assertBytes(PNG);
    await assertIndex();
  });

  it('allows exactly one of two actual simultaneous uploads carrying the same absent token', async () => {
    const before = await state();
    const results = await Promise.all([
      request('POST', genericUrl(), mutationPayload(before.version, first)),
      request('POST', genericUrl(), mutationPayload(before.version, second)),
    ]);
    expect(results.map((r) => r.statusCode).sort(), results.map((r) => r.body).join('\n')).toEqual([
      200, 409,
    ]);
    await assertBytes(results[0]!.statusCode === 200 ? PNG : JPEG);
    await assertIndex();
    expect((await state()).version).not.toBe(before.version);
  });

  it('retains revision through delete and recreate so identical bytes never resurrect an old token', async () => {
    const absent = await state();
    expect((await request('POST', genericUrl(), mutationPayload(absent.version))).statusCode).toBe(
      200,
    );
    const saved = await state();
    const removed = await request('DELETE', genericUrl('', tag, { version: saved.version }));
    expect(removed.statusCode, removed.body).toBe(200);
    expect((await request('GET', genericUrl())).statusCode).toBe(404);
    const empty = await state();
    expect(empty.version).not.toBe(absent.version);
    expect(empty.version).not.toBe(saved.version);
    const afterDelete = await snapshot();
    expect((await request('POST', genericUrl(), mutationPayload(absent.version))).statusCode).toBe(
      409,
    );
    expect(await snapshot()).toEqual(afterDelete);
    expect((await request('POST', genericUrl(), mutationPayload(empty.version))).statusCode).toBe(
      200,
    );
    const recreated = await state();
    expect(recreated.version).not.toBe(saved.version);
    const beforeStaleDelete = await snapshot();
    expect(
      (await request('DELETE', genericUrl('', tag, { version: saved.version }))).statusCode,
    ).toBe(409);
    expect(await snapshot()).toEqual(beforeStaleDelete);
    await assertBytes(PNG);
    await assertIndex();
  });

  it('treats image type as one shared-image attribute and binds tokens to entity and instance identities', async () => {
    const initial = await state();
    for (const key of [
      { ...tag, instance: 10 },
      { ...tag, entityType: 'AC', instance: 0 },
    ]) {
      const other = await state(key);
      expect(other.version).not.toBe(initial.version);
      const before = await snapshot();
      expect(
        (await request('POST', genericUrl('', key), mutationPayload(initial.version, first, key)))
          .statusCode,
      ).toBe(409);
      expect(await snapshot()).toEqual(before);
    }
    const changedType = { ...tag, imageType: 'D' };
    const saved = await request(
      'POST',
      genericUrl('', changedType),
      mutationPayload(initial.version, second, changedType),
    );
    expect(saved.statusCode, saved.body).toBe(200);
    await assertBytes(JPEG);
    await assertIndex('D');
  });

  it('requires current owning form view, update and delete rights for generic state and writes', async () => {
    const initial = await state();
    expect(await state(tag, 'view')).toMatchObject({
      version: initial.version,
      canUpdate: false,
      canDelete: false,
    });
    for (const role of ['print', 'design', 'tour', 'none'] as const) {
      expect((await request('GET', genericUrl('/state'), undefined, role)).statusCode).toBe(403);
      expect((await request('GET', genericUrl(), undefined, role)).statusCode).toBe(403);
    }
    const before = await snapshot();
    for (const role of ['view', 'delete', 'print', 'design', 'tour', 'none'] as const) {
      const response = await request('POST', genericUrl(), mutationPayload(initial.version), role);
      expect(response.statusCode, `${role}: ${response.body}`).toBe(403);
      expect(await snapshot()).toEqual(before);
    }
    expect(
      (await request('POST', genericUrl(), mutationPayload(initial.version), 'update')).statusCode,
    ).toBe(200);
    const saved = await state();
    const withBytes = await snapshot();
    for (const role of ['view', 'update', 'print', 'design', 'tour', 'none'] as const) {
      expect(
        (await request('DELETE', genericUrl('', tag, { version: saved.version }), undefined, role))
          .statusCode,
      ).toBe(403);
      expect(await snapshot()).toEqual(withBytes);
    }
    expect(
      (
        await request(
          'DELETE',
          genericUrl('', tag, { version: saved.version }),
          undefined,
          'delete',
        )
      ).statusCode,
    ).toBe(200);
    expect((await request('GET', genericUrl())).statusCode).toBe(404);
  });

  it('rejects cross-company and cross-branch scope and foreign-tenant tokens before changing bytes', async () => {
    const local = await state();
    const foreign = await state(tag, 'other');
    expect(foreign.version).not.toBe(local.version);
    expect((await request('POST', genericUrl(), mutationPayload(foreign.version))).statusCode).toBe(
      409,
    );
    expect(
      (await request('POST', genericUrl(), mutationPayload(foreign.version, second), 'other'))
        .statusCode,
    ).toBe(200);
    expect((await request('POST', genericUrl(), mutationPayload(local.version))).statusCode).toBe(
      200,
    );
    const before = await snapshot();
    for (const extra of [{ coCode: '02' }, { lcCode: '02' }]) {
      for (const method of ['GET', 'POST', 'DELETE'] as const) {
        const response = await request(
          method,
          genericUrl(method === 'GET' ? '/state' : '', tag, extra),
          method === 'POST' ? mutationPayload((await state()).version, second) : undefined,
        );
        expect(response.statusCode, response.body).toBe(409);
        expect(response.json()).toMatchObject({ error: 'scope-mismatch' });
        expect(await snapshot()).toEqual(before);
      }
    }
    await assertBytes(PNG);
    await assertBytes(JPEG, tag, 'other');
  });

  it('invalidates generic tokens after a form-owned Tour change and Tour tokens after a generic change', async () => {
    const genericBefore = await state();
    const orderBefore = await request('GET', orderUrl, undefined, 'tour');
    expect(orderBefore.statusCode, orderBefore.body).toBe(200);
    const tourSaved = await request(
      'POST',
      orderUrl,
      { ...first, version: orderBefore.json().version },
      'tour',
    );
    expect(tourSaved.statusCode, tourSaved.body).toBe(200);
    const savedSnapshot = await snapshot();
    expect(
      (await request('POST', genericUrl(), mutationPayload(genericBefore.version, second)))
        .statusCode,
    ).toBe(409);
    expect(
      (await request('DELETE', genericUrl('', tag, { version: genericBefore.version }))).statusCode,
    ).toBe(409);
    expect(await snapshot()).toEqual(savedSnapshot);
    const tourOld = await request('GET', orderUrl, undefined, 'tour');
    const genericCurrent = await state();
    expect(
      (await request('POST', genericUrl(), mutationPayload(genericCurrent.version, second)))
        .statusCode,
    ).toBe(200);
    const afterGeneric = await snapshot();
    const staleOrder = await request(
      'POST',
      orderUrl,
      { ...first, version: tourOld.json().version },
      'tour',
    );
    expect(staleOrder.statusCode, staleOrder.body).toBe(422);
    expect(staleOrder.json()).toMatchObject({
      error: 'OrderImageError',
      code: 'invalid-order-image',
    });
    expect(await snapshot()).toEqual(afterGeneric);
    await assertBytes(JPEG);
    await assertIndex();
  });

  it('supports a saved Design image CAS under its own company-wide parent and form rights', async () => {
    const initial = await designState();
    for (const method of ['GET', 'POST', 'DELETE'] as const) {
      const response = await request(
        method,
        designUrl(method === 'GET' ? '/state' : ''),
        method === 'POST' ? mutationPayload(initial.version, first, design) : undefined,
      );
      expect(response.statusCode, response.body).toBe(403);
    }
    const missing = await request('POST', designUrl(), { entityKey: designId, ...first }, 'design');
    expect(missing.statusCode, missing.body).toBe(400);
    const saved = await request(
      'POST',
      designUrl(),
      mutationPayload(initial.version, first, design),
      'design',
    );
    expect(saved.statusCode, saved.body).toBe(200);
    const raw = await request('GET', designUrl(), undefined, 'design');
    expect(raw.statusCode, raw.body).toBe(200);
    expect(raw.rawPayload.equals(PNG)).toBe(true);
    const before = await snapshot();
    expect(
      (
        await request(
          'POST',
          designUrl(),
          mutationPayload(initial.version, second, design),
          'design',
        )
      ).statusCode,
    ).toBe(409);
    expect(
      (await request('DELETE', designUrl('', { version: initial.version }), undefined, 'design'))
        .statusCode,
    ).toBe(409);
    expect(await snapshot()).toEqual(before);
    const current = await designState();
    expect(
      (await request('DELETE', designUrl('', { version: current.version }), undefined, 'design'))
        .statusCode,
    ).toBe(200);
    expect((await request('GET', designUrl(), undefined, 'design')).statusCode).toBe(404);
    const rows: any[] = await owner.$queryRawUnsafe(
      `SELECT * FROM "TAG_IMAGE_DATA" WHERE tenant_id=$1`,
      tenantId,
    );
    expect(rows).toEqual([]);
  });

  it('loads and repairs an imported tag index with missing bytes without duplicating the index', async () => {
    await sql(
      `INSERT INTO "TAG_IMAGE_DATA"(tenant_id,"CO_CODE","LC_CODE","TAG_NO","VCH_SRNO","IMAGE_TYPE") VALUES ($1,'01','01',$2,9,'T')`,
      tenantId,
      tag.entityKey,
    );
    const initial = await state();
    expect((await request('GET', genericUrl())).statusCode).toBe(404);
    const repaired = await request('POST', genericUrl(), mutationPayload(initial.version));
    expect(repaired.statusCode, repaired.body).toBe(200);
    await assertBytes(PNG);
    await assertIndex();
    const before = await snapshot();
    expect(
      (await request('DELETE', genericUrl('', tag, { version: initial.version }))).statusCode,
    ).toBe(409);
    expect(await snapshot()).toEqual(before);
  });
  it('serializes simultaneous generic and Tour uploads to the same image identity', async () => {
    const genericBefore = await state();
    const orderBefore = await request('GET', orderUrl, undefined, 'tour');
    expect(orderBefore.statusCode, orderBefore.body).toBe(200);
    const [generic, tour] = await Promise.all([
      request('POST', genericUrl(), mutationPayload(genericBefore.version, first)),
      request('POST', orderUrl, { ...second, version: orderBefore.json().version }, 'tour'),
    ]);
    expect(
      Number(generic.statusCode === 200) + Number(tour.statusCode === 200),
      `${generic.body} / ${tour.body}`,
    ).toBe(1);
    if (generic.statusCode === 200) {
      expect(tour.statusCode, tour.body).toBe(422);
      await assertBytes(PNG);
    } else {
      expect(generic.statusCode, generic.body).toBe(409);
      await assertBytes(JPEG);
    }
    await assertIndex();
  });

  it('refuses malformed versions and incomplete decoded images without advancing the loaded version', async () => {
    const initial = await state();
    expect((await request('POST', genericUrl(), mutationPayload(initial.version))).statusCode).toBe(
      200,
    );
    const saved = await state();
    const before = await snapshot();
    for (const version of ['', 'new', null, 123]) {
      const response = await request('POST', genericUrl(), {
        ...mutationPayload(saved.version),
        version,
      });
      expect(response.statusCode, response.body).toBe(400);
      expect(await snapshot()).toEqual(before);
    }
    for (const image of [
      { data: PNG.subarray(0, 16).toString('base64'), mimeType: 'image/png' },
      { data: first.data, mimeType: 'image/jpeg' },
    ]) {
      const response = await request('POST', genericUrl(), mutationPayload(saved.version, image));
      expect(response.statusCode, response.body).toBe(400);
      expect(await snapshot()).toEqual(before);
    }
    expect((await state()).version).toBe(saved.version);
    await assertBytes(PNG);
    await assertIndex();
  });

  it('returns a recovery token for historical invalid bytes and replaces them only with the current token', async () => {
    const bytes = PNG.subarray(0, 16);
    await sql(
      `INSERT INTO "ENTITY_IMAGE"(tenant_id,"CO_CODE","LC_CODE","ENTITY_TYPE","ENTITY_KEY","INSTANCE","IMAGE_TYPE","MIME_TYPE","IMAGE_SIZE","IMAGE_BYTES")
      VALUES ($1,'01','01','TAG',$2,9,'T','image/png',$3,$4)`,
      tenantId,
      tag.entityKey,
      bytes.length,
      bytes,
    );
    await sql(
      `INSERT INTO "TAG_IMAGE_DATA"(tenant_id,"CO_CODE","LC_CODE","TAG_NO","VCH_SRNO","IMAGE_TYPE") VALUES ($1,'01','01',$2,9,'T')`,
      tenantId,
      tag.entityKey,
    );
    const broken = await state();
    expect(broken.image).toMatchObject({ state: 'unavailable', message: expect.any(String) });
    expect(broken.canUpdate).toBe(true);
    expect(
      (await request('POST', genericUrl(), mutationPayload(broken.version, second))).statusCode,
    ).toBe(200);
    const repaired = await state();
    expect(repaired.image).toMatchObject({
      state: 'present',
      mimeType: second.mimeType,
      data: second.data,
      size: JPEG.length,
    });
    expect(repaired.version).not.toBe(broken.version);
    const before = await snapshot();
    const stale = await request('DELETE', genericUrl('', tag, { version: broken.version }));
    expect(stale.statusCode, stale.body).toBe(409);
    expect(stale.json()).toMatchObject({ error: 'image-version-conflict' });
    expect(await snapshot()).toEqual(before);
    await assertBytes(JPEG);
    await assertIndex();
  });
  it('rejects malformed instance identities without silently modifying instance zero', async () => {
    const initial = await state();
    const before = await snapshot();
    for (const value of ['NaN', 'Infinity', '-1']) {
      const key = { ...tag, instance: value as any };
      expect((await request('GET', genericUrl('/state', key))).statusCode).toBe(400);
      expect(
        (await request('POST', genericUrl('', key), mutationPayload(initial.version, first, key)))
          .statusCode,
      ).toBe(400);
      expect(
        (await request('DELETE', genericUrl('', key, { version: initial.version }))).statusCode,
      ).toBe(400);
      expect(await snapshot()).toEqual(before);
    }
    const historical = { ...tag, instance: 9.5 };
    const loaded = await state(historical);
    expect(
      (
        await request(
          'POST',
          genericUrl('', historical),
          mutationPayload(loaded.version, first, historical),
        )
      ).statusCode,
    ).toBe(200);
    await assertBytes(PNG, historical);
    expect(
      await owner.$queryRawUnsafe(
        `SELECT "VCH_SRNO" FROM "TAG_IMAGE_DATA" WHERE tenant_id=$1`,
        tenantId,
      ),
    ).toEqual([{ VCH_SRNO: 9.5 }]);
  });

  it('invalidates a Design image token after its saved parent is removed and identically recreated', async () => {
    const initial = await designState();
    expect(
      (
        await request(
          'POST',
          designUrl(),
          mutationPayload(initial.version, first, design),
          'design',
        )
      ).statusCode,
    ).toBe(200);
    const loaded = await designState();
    const [parent]: any[] = await owner.$queryRawUnsafe(
      `SELECT to_jsonb(t) AS row FROM "DESIGN_DETL" t WHERE tenant_id=$1 AND "CO_CODE"='01' AND "DESIGN_IMG_ID"=$2`,
      tenantId,
      designId,
    );
    await sql(
      `DELETE FROM "DESIGN_DETL" WHERE tenant_id=$1 AND "CO_CODE"='01' AND "DESIGN_IMG_ID"=$2`,
      tenantId,
      designId,
    );
    try {
      const before = await snapshot();
      const missing = await request(
        'POST',
        designUrl(),
        mutationPayload(loaded.version, second, design),
        'design',
      );
      expect(missing.statusCode, missing.body).toBe(400);
      expect(await snapshot()).toEqual(before);
    } finally {
      await sql(
        `INSERT INTO "DESIGN_DETL" SELECT (jsonb_populate_record(NULL::"DESIGN_DETL",$1::jsonb)).*`,
        JSON.stringify(parent.row),
      );
    }
    const before = await snapshot();
    const stale = await request(
      'DELETE',
      designUrl('', { version: loaded.version }),
      undefined,
      'design',
    );
    expect(stale.statusCode, stale.body).toBe(409);
    expect(await snapshot()).toEqual(before);
    const raw = await request('GET', designUrl(), undefined, 'design');
    expect(raw.rawPayload.equals(PNG)).toBe(true);
  });
  it.each(['generic', 'design'] as const)(
    'accepts a complete large %s image within the advertised 4 MB binary limit',
    async (family) => {
      const bytes = await sharp({
        create: { width: 1024, height: 1024, channels: 3, background: { r: 25, g: 125, b: 225 } },
      })
        .png({ compressionLevel: 0 })
        .toBuffer();
      expect(bytes.length).toBeGreaterThan(1024 * 1024);
      expect(bytes.length).toBeLessThanOrEqual(4 * 1024 * 1024);
      const initial = family === 'generic' ? await state() : await designState();
      const image = { data: bytes.toString('base64'), mimeType: 'image/png' };
      const body = mutationPayload(initial.version, image, family === 'generic' ? tag : design);
      expect(Buffer.byteLength(JSON.stringify(body))).toBeGreaterThan(1024 * 1024);
      const response = await request(
        'POST',
        family === 'generic' ? genericUrl() : designUrl(),
        body,
        family === 'generic' ? 'all' : 'design',
      );
      expect(response.statusCode, response.body).toBe(200);
      const read = await request(
        'GET',
        family === 'generic' ? genericUrl() : designUrl(),
        undefined,
        family === 'generic' ? 'all' : 'design',
      );
      expect(read.statusCode).toBe(200);
      expect(read.rawPayload.equals(bytes)).toBe(true);
      const current = family === 'generic' ? await state() : await designState();
      expect(current.image.state).toBe('present');
      expect(current.image.size).toBe(bytes.length);
      expect(current.version).not.toBe(initial.version);
      if (family === 'generic') await assertIndex();
    },
  );
});
