import sharp from 'sharp';
import { readFileSync } from 'node:fs';
import { PrismaClient } from '@prisma/client';
import type { FastifyInstance } from 'fastify';
import { afterAll, beforeAll, beforeEach, describe, expect, it } from 'vitest';
import { buildApp } from '../src/app.js';
import { hashPassword } from '../src/modules/auth/password.js';
import { repairImageNo } from '../src/modules/repair/repairImage.js';

const db = process.env.RUN_DB_INTEGRITY_TESTS === '1' ? describe : describe.skip;
const tenantId = 'repair-image-cas-r5';
const PASSWORD = 'Repair-Image-CAS!2026';
const PNG = readFileSync(new URL('./fixtures/order-design-portrait.png', import.meta.url));
const JPEG = readFileSync(new URL('./fixtures/order-tag-landscape.jpg', import.meta.url));
const first = { data: PNG.toString('base64'), mimeType: 'image/png' };
const second = { data: JPEG.toString('base64'), mimeType: 'image/jpeg' };
const scope = { coCode: '01', lcCode: '01', coYear: '2024-2025', coBook: 'R51' };
// The currently open stage differs from the saved source customer-receipt photo identity.
const source = { imageBook: 'R52', imageYear: '2023-2024', vchNo: '00001', srNo: 17 };
type Key = typeof source;
type Role = 'all' | 'view' | 'update' | 'delete' | 'outsider';

db('repair image HTTP compare-and-swap and source identity', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;
  let app: FastifyInstance;
  const cookies: Partial<Record<Role, string>> = {};
  const sql = (query: string, ...args: unknown[]) =>
    owner.$executeRawUnsafe(query, tenantId, ...args);
  const query = (values: Record<string, unknown>) =>
    new URLSearchParams(
      Object.entries(values).map(([k, v]): [string, string] => [k, String(v)]),
    ).toString();
  const path = (suffix = '', key: Key = source, extra: Record<string, unknown> = {}) =>
    `/repair-images${suffix}?${query({ ...scope, ...key, ...extra })}`;
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
  const payload = (version?: unknown, image = first, key: Key = source) => ({
    ...scope,
    ...key,
    ...image,
    ...(version === undefined ? {} : { version }),
  });
  async function state(key: Key = source, role: Role = 'all') {
    const response = await request('GET', path('/state', key), undefined, role);
    expect(response.statusCode, response.body).toBe(200);
    expect(response.json().version).toMatch(/^[0-9a-f]{64}$/);
    expect(response.headers['cache-control']).toBe('no-store');
    return response.json();
  }
  async function snapshot() {
    const result: Record<string, unknown> = {};
    for (const table of ['REP_IMAGE', 'ENTITY_IMAGE_REVISION', 'REP_DATA', 'REP_DETL'])
      result[table] = await owner.$queryRawUnsafe(
        `SELECT to_jsonb(t) AS row FROM "${table}" t WHERE tenant_id=$1 ORDER BY to_jsonb(t)::text`,
        tenantId,
      );
    return result;
  }
  async function assertBytes(expected: Buffer, key: Key = source) {
    const response = await request('GET', path('/line', key));
    expect(response.statusCode, response.body).toBe(200);
    expect(response.rawPayload.equals(expected)).toBe(true);
  }
  async function cleanImages() {
    for (const table of ['REP_IMAGE', 'ENTITY_IMAGE_REVISION'])
      await sql(`DELETE FROM "${table}" WHERE tenant_id=$1`);
  }
  async function cleanup() {
    for (const table of [
      'audit_log',
      'auth_session',
      'REP_IMAGE',
      'ENTITY_IMAGE_REVISION',
      'REP_DETL',
      'REP_DATA',
      'BOOK_DATA',
      'USER_SET',
      'LOGIN_MAST',
      'YEAR_MAST',
      'LOCT_MAST',
      'CO_MAST',
    ])
      await sql(`DELETE FROM "${table}" WHERE tenant_id=$1`);
  }
  beforeAll(async () => {
    for (const value of [process.env.DATABASE_URL, process.env.MIGRATE_DATABASE_URL])
      if (!value || new URL(value).port !== '55433')
        throw new Error('Isolated repair image database required.');
    owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
    runtime = new PrismaClient();
    await cleanup();
    await sql(
      `INSERT INTO "CO_MAST"(tenant_id,"CO_CODE","CO_NAME","LC_CODE") VALUES ($1,'01','Repair Image CAS','01')`,
    );
    await sql(
      `INSERT INTO "LOCT_MAST"(tenant_id,"CO_CODE","LC_CODE","LC_NAME") VALUES ($1,'01','01','Main'),($1,'01','02','Other')`,
    );
    await sql(
      `INSERT INTO "YEAR_MAST"(tenant_id,"CO_CODE","CO_YEAR","OP_DATE","CL_DATE") VALUES ($1,'01','2024-2025','2024-04-01','2025-03-31'),($1,'01','2023-2024','2023-04-01','2024-03-31')`,
    );
    await sql(`INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","MAIN_BOOK","BOOK_INOUT","CUR_USE","BOOK_TBL_NAME")
      VALUES ($1,'01','01','R51','Current Repair','KRREP ISSUE','O','Y','REP_DATA'),($1,'01','01','R52','Source Receipt','CUSTREP RECEIPT','I','Y','REP_DATA')`);
    for (const [book, year, sr] of [
      ['R51', '2024-2025', 17],
      ['R52', '2023-2024', 17],
      ['R52', '2023-2024', 23],
      ['R52', '2024-2025', 17],
    ] as const) {
      await sql(
        `INSERT INTO "REP_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","AC_CODE","AC_NAME") VALUES ($1,'01','01',$2,$3,'00001','PARTY','Repair Source') ON CONFLICT DO NOTHING`,
        year,
        book,
      );
      await sql(
        `INSERT INTO "REP_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","IT_CODE","IT_NAME") VALUES ($1,'01','01',$2,$3,'00001',$4,'RING','Saved repair parent')`,
        year,
        book,
        sr,
      );
    }
    const hash = await hashPassword(PASSWORD);
    for (const [name, edit, del] of [
      ['all', 'Y', 'Y'],
      ['view', 'N', 'N'],
      ['update', 'Y', 'N'],
      ['delete', 'N', 'Y'],
      ['outsider', 'Y', 'Y'],
    ] as const) {
      await sql(
        `INSERT INTO "LOGIN_MAST"(tenant_id,"CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG","USER_UPDATE","USER_DELETE","USER_PRINT","PASSWORD_RESET_REQUIRED") VALUES ($1,'01',$2,$3,'USER','Y','Y','Y','N')`,
        name,
        hash,
      );
      await sql(
        `INSERT INTO "USER_SET"(tenant_id,"CO_CODE","LC_CODE","USER_NAME","MAIN_MENU","SUB_MENU","FRM_VIEW","FRM_EDIT","FRM_DELETE","FRM_PRINT") VALUES ($1,'01','01',$2,$3,$4,'Y',$5,$6,'N')`,
        name,
        name === 'outsider' ? 'Inventory' : 'Manufacturing',
        name === 'outsider' ? 'Tag Print' : 'Repair Receipt',
        edit,
        del,
      );
    }
    app = await buildApp({
      prisma: runtime,
      secret: 'repair-cas-test-signing-secret-over-thirty-two-characters',
      secureCookies: false,
    });
    for (const name of ['all', 'view', 'update', 'delete', 'outsider'] as const) {
      const response = await app.inject({
        method: 'POST',
        url: '/auth/login',
        headers: { 'x-tenant-id': tenantId },
        payload: { ...scope, loginName: name, password: PASSWORD },
      });
      expect(response.statusCode, response.body).toBe(200);
      const values = response.headers['set-cookie'];
      cookies[name] = (Array.isArray(values) ? values : [values ?? ''])
        .map((v) => v.split(';', 1)[0])
        .join('; ');
    }
  });
  beforeEach(cleanImages);
  afterAll(async () => {
    if (app) await app.close();
    if (owner) await cleanup();
    if (runtime) await runtime.$disconnect();
    if (owner) await owner.$disconnect();
  });

  it('requires a valid body version for upload and delete, including an absent source image', async () => {
    expect((await state()).image).toEqual({ state: 'absent' });
    const before = await snapshot();
    for (const version of [undefined, '', null, 'new', 123]) {
      for (const method of ['POST', 'DELETE'] as const) {
        const response = await request(method, path(), payload(version));
        expect(response.statusCode, response.body).toBe(400);
        expect(await snapshot()).toEqual(before);
      }
    }
  });

  it('allows one simultaneous writer and rejects stale deletion without losing the winner', async () => {
    const before = await state();
    const replies = await Promise.all([
      request('POST', path(), payload(before.version, first)),
      request('POST', path(), payload(before.version, second)),
    ]);
    expect(replies.map((r) => r.statusCode).sort(), replies.map((r) => r.body).join('\n')).toEqual([
      200, 409,
    ]);
    const saved = await snapshot();
    const stale = await request('DELETE', path(), { ...scope, ...source, version: before.version });
    expect(stale.statusCode, stale.body).toBe(409);
    expect(stale.json()).toMatchObject({ error: 'image-version-conflict' });
    expect(await snapshot()).toEqual(saved);
    await assertBytes(replies[0]!.statusCode === 200 ? PNG : JPEG);
  });

  it('keeps deleted revisions so identical recreation cannot revive a prior token', async () => {
    const empty = await state();
    expect((await request('POST', path(), payload(empty.version))).statusCode).toBe(200);
    const saved = await state();
    expect(
      (await request('DELETE', path(), { ...scope, ...source, version: saved.version })).statusCode,
    ).toBe(200);
    const removed = await state();
    expect(removed.image).toEqual({ state: 'absent' });
    expect(removed.version).not.toBe(empty.version);
    expect((await request('POST', path(), payload(empty.version))).statusCode).toBe(409);
    expect((await request('POST', path(), payload(removed.version))).statusCode).toBe(200);
    const snapshotAfterRecreate = await snapshot();
    expect(
      (await request('DELETE', path(), { ...scope, ...source, version: saved.version })).statusCode,
    ).toBe(409);
    expect(await snapshot()).toEqual(snapshotAfterRecreate);
    await assertBytes(PNG);
  });

  it('keeps source book/year separate from the current stage and binds tokens to the exact saved row', async () => {
    const loaded = await state();
    expect((await request('POST', path(), payload(loaded.version))).statusCode).toBe(200);
    const currentStage = { ...source, imageBook: 'R51', imageYear: scope.coYear };
    const sameBookOtherYear = { ...source, imageYear: scope.coYear };
    const sibling = { ...source, srNo: 23 };
    for (const key of [currentStage, sameBookOtherYear, sibling]) {
      const isolated = await state(key);
      expect(isolated.image).toEqual({ state: 'absent' });
      const before = await snapshot();
      expect(
        (await request('POST', path('', key), payload((await state()).version, second, key)))
          .statusCode,
      ).toBe(409);
      expect(await snapshot()).toEqual(before);
    }
    const listed = await request('GET', path());
    expect(listed.statusCode, listed.body).toBe(200);
    expect(listed.json()).toEqual([
      {
        srNo: source.srNo,
        imageNo: repairImageNo({
          coCode: scope.coCode,
          lcCode: scope.lcCode,
          coYear: source.imageYear,
          coBook: source.imageBook,
          voucherNo: source.vchNo,
          srNo: source.srNo,
        }),
        mimeType: first.mimeType,
        size: PNG.length,
      },
    ]);
    const currentList = await request('GET', path('', currentStage));
    expect(currentList.statusCode, currentList.body).toBe(200);
    expect(currentList.json()).toEqual([]);
    const rows = await owner.$queryRawUnsafe(
      `SELECT "CO_YEAR","CO_BOOK","VCH_NO","SR_NO","IMAGE_NO" FROM "REP_IMAGE" WHERE tenant_id=$1`,
      tenantId,
    );
    expect(rows).toEqual([
      {
        CO_YEAR: source.imageYear,
        CO_BOOK: source.imageBook,
        VCH_NO: source.vchNo,
        SR_NO: source.srNo,
        IMAGE_NO: repairImageNo({
          coCode: scope.coCode,
          lcCode: scope.lcCode,
          coYear: source.imageYear,
          coBook: source.imageBook,
          voucherNo: source.vchNo,
          srNo: source.srNo,
        }),
      },
    ]);
  });

  it('honors Repair form rights and rejects cross-scope requests before touching the saved image', async () => {
    const initial = await state();
    expect(await state(source, 'view')).toMatchObject({ canUpdate: false, canDelete: false });
    expect((await request('GET', path('/state'), undefined, 'outsider')).statusCode).toBe(403);
    const before = await snapshot();
    for (const role of ['view', 'delete', 'outsider'] as const) {
      expect((await request('POST', path(), payload(initial.version), role)).statusCode).toBe(403);
      expect(await snapshot()).toEqual(before);
    }
    expect((await request('POST', path(), payload(initial.version), 'update')).statusCode).toBe(
      200,
    );
    const saved = await state();
    const withBytes = await snapshot();
    for (const role of ['view', 'update', 'outsider'] as const) {
      expect(
        (await request('DELETE', path(), { ...scope, ...source, version: saved.version }, role))
          .statusCode,
      ).toBe(403);
      expect(await snapshot()).toEqual(withBytes);
    }
    for (const method of ['GET', 'POST', 'DELETE'] as const) {
      const response = await request(
        method,
        path(method === 'GET' ? '/state' : '', source, { lcCode: '02' }),
        method === 'GET' ? undefined : payload(saved.version),
      );
      expect(response.statusCode, response.body).toBe(409);
      expect(response.json()).toMatchObject({ error: 'scope-mismatch' });
      expect(await snapshot()).toEqual(withBytes);
    }
    expect(
      (await request('DELETE', path(), { ...scope, ...source, version: saved.version }, 'delete'))
        .statusCode,
    ).toBe(200);
  });

  it('fully decodes modern uploads while keeping malformed historical bytes recoverable', async () => {
    const initial = await state();
    const before = await snapshot();
    for (const image of [
      { data: PNG.subarray(0, 16).toString('base64'), mimeType: 'image/png' },
      { ...first, mimeType: 'image/jpeg' },
    ]) {
      expect((await request('POST', path(), payload(initial.version, image))).statusCode).toBe(400);
      expect(await snapshot()).toEqual(before);
    }
    const imageNo = repairImageNo({
      coCode: scope.coCode,
      lcCode: scope.lcCode,
      coYear: source.imageYear,
      coBook: source.imageBook,
      voucherNo: source.vchNo,
      srNo: source.srNo,
    });
    const bytes = PNG.subarray(0, 16);
    await sql(
      `INSERT INTO "REP_IMAGE"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","IMAGE_NO","MIME_TYPE","IMAGE_SIZE","REP_IMAGE") VALUES ($1,'01','01',$2,$3,'00001',17,$4,'image/png',$5,$6)`,
      source.imageYear,
      source.imageBook,
      imageNo,
      bytes.length,
      bytes,
    );
    const broken = await state();
    expect(broken.image).toMatchObject({ state: 'unavailable', message: expect.any(String) });
    expect(broken.canUpdate).toBe(true);
    expect((await request('POST', path(), payload(broken.version, second))).statusCode).toBe(200);
    expect((await state()).image).toMatchObject({
      state: 'present',
      data: second.data,
      mimeType: second.mimeType,
    });
    await assertBytes(JPEG);
  });

  it('refuses a changed source parent even if a prior image token was valid', async () => {
    const initial = await state();
    expect((await request('POST', path(), payload(initial.version))).statusCode).toBe(200);
    const loaded = await state();
    await sql(
      `UPDATE "REP_DETL" SET "IT_NAME"='Changed source parent' WHERE tenant_id=$1 AND "CO_YEAR"=$2 AND "CO_BOOK"=$3 AND "SR_NO"=17`,
      source.imageYear,
      source.imageBook,
    );
    try {
      const before = await snapshot();
      const changed = await request('POST', path(), payload(loaded.version, second));
      expect(changed.statusCode, changed.body).toBe(409);
      expect(await snapshot()).toEqual(before);
      await assertBytes(PNG);
    } finally {
      await sql(
        `UPDATE "REP_DETL" SET "IT_NAME"='Saved repair parent' WHERE tenant_id=$1 AND "CO_YEAR"=$2 AND "CO_BOOK"=$3 AND "SR_NO"=17`,
        source.imageYear,
        source.imageBook,
      );
    }
  });
  it('does not reuse a repair token after the source row is deleted and recreated with identical values', async () => {
    const initial = await state();
    expect((await request('POST', path(), payload(initial.version))).statusCode).toBe(200);
    const loaded = await state();
    const [parent]: any[] = await owner.$queryRawUnsafe(
      `SELECT to_jsonb(t) AS row FROM "REP_DETL" t WHERE tenant_id=$1 AND "CO_YEAR"=$2 AND "CO_BOOK"=$3 AND "SR_NO"=17`,
      tenantId,
      source.imageYear,
      source.imageBook,
    );
    await sql(
      `DELETE FROM "REP_DETL" WHERE tenant_id=$1 AND "CO_YEAR"=$2 AND "CO_BOOK"=$3 AND "SR_NO"=17`,
      source.imageYear,
      source.imageBook,
    );
    try {
      const before = await snapshot();
      const missing = await request('POST', path(), payload(loaded.version, second));
      expect(missing.statusCode, missing.body).toBe(400);
      expect(await snapshot()).toEqual(before);
    } finally {
      await owner.$executeRawUnsafe(
        `INSERT INTO "REP_DETL" SELECT (jsonb_populate_record(NULL::"REP_DETL",$1::jsonb)).*`,
        JSON.stringify(parent.row),
      );
    }
    const before = await snapshot();
    const stale = await request('DELETE', path(), { ...scope, ...source, version: loaded.version });
    expect(stale.statusCode, stale.body).toBe(409);
    expect(await snapshot()).toEqual(before);
    await assertBytes(PNG);
  });
  it('accepts a complete large Repair image above the default JSON limit and preserves source bytes', async () => {
    const bytes = await sharp({
      create: { width: 1024, height: 1024, channels: 3, background: { r: 25, g: 125, b: 225 } },
    })
      .png({ compressionLevel: 0 })
      .toBuffer();
    expect(bytes.length).toBeGreaterThan(1024 * 1024);
    expect(bytes.length).toBeLessThanOrEqual(4 * 1024 * 1024);
    const initial = await state();
    const body = payload(initial.version, {
      data: bytes.toString('base64'),
      mimeType: 'image/png',
    });
    expect(Buffer.byteLength(JSON.stringify(body))).toBeGreaterThan(1024 * 1024);
    const response = await request('POST', path(), body);
    expect(response.statusCode, response.body).toBe(200);
    await assertBytes(bytes);
    const current = await state();
    expect(current.image.state).toBe('present');
    expect(current.image.size).toBe(bytes.length);
    expect(current.version).not.toBe(initial.version);
  });
});
