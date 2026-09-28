import { readFileSync } from 'node:fs';
import { PrismaClient } from '@prisma/client';
import type { FastifyInstance } from 'fastify';
import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import { buildApp } from '../src/app.js';
import { hashPassword } from '../src/modules/auth/password.js';

const enabled = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const tenantId = 'tour-print-route-db';
const PASSWORD = 'Tour-Print-Test!2026';
const SECRET = 'tour-print-test-signing-secret-over-thirty-two-characters';
const TOUR_URL = '/tour-orders/confirmation';

(enabled ? describe : describe.skip)('X14 Tour Order confirmation HTTP permissions', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;
  let app: FastifyInstance;
  let cookie: string;
  const cookies: Record<string, string> = {};
  const roles = [
    ['print-only', 'Karigar', 'Tour Order', 'N', 'N', 'N', 'Y'],
    ['image-view', 'Karigar', 'Tour Order', 'Y', 'N', 'N', 'N'],
    ['image-edit', 'Karigar', 'Tour Order', 'Y', 'Y', 'N', 'N'],
    ['image-delete', 'Karigar', 'Tour Order', 'Y', 'N', 'Y', 'N'],
    ['sales-images', 'Sales', 'Sales Order', 'Y', 'Y', 'Y', 'Y'],
  ];
  const clean = async () => {
    for (const table of [
      'audit_log',
      'auth_session',
      'SL_ORD_IDTL',
      'SL_ORD_DETL',
      'SL_ORD_DATA',
      'SL_PR_DETL',
      'AC_DATA',
      'ENTITY_IMAGE',
      'CO_SET_NEW',
      'ITEM_MAST',
      'USER_SET',
      'LOGIN_MAST',
      'BOOK_DATA',
      'AC_MAST',
      'YEAR_MAST',
      'LOCT_MAST',
      'CO_MAST',
    ]) {
      await owner.$executeRawUnsafe(`DELETE FROM "${table}" WHERE tenant_id=$1`, tenantId);
    }
  };
  beforeAll(async () => {
    for (const url of [process.env.DATABASE_URL, process.env.MIGRATE_DATABASE_URL])
      if (!url || new URL(url).port !== '55433') throw new Error('Tour print route fixtures require isolated database 55433');
    owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
    runtime = new PrismaClient();
    await clean();
    await owner.$executeRawUnsafe(
      `INSERT INTO "CO_MAST"(tenant_id,"CO_CODE","CO_NAME","LC_CODE") VALUES ($1,'01','Tour Print Test','01')`,
      tenantId,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "LOCT_MAST"(tenant_id,"CO_CODE","LC_CODE","LC_NAME") VALUES ($1,'01','01','Main')`,
      tenantId,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "YEAR_MAST"(tenant_id,"CO_CODE","CO_YEAR","OP_DATE","CL_DATE") VALUES ($1,'01','2024-2025','2024-04-01','2025-03-31')`,
      tenantId,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME","MAIN_BOOK","BOOK_INOUT","CUR_USE","BOOK_TBL_NAME","BOOK_TBL_DETL")
      VALUES ($1,'01','01','Z09','Configured Tour','TUROD','TOUR ORDER','I','Y','SL_ORD_DATA','SL_ORD_DETL'),
             ($1,'01','01','SOR','Sales Order','SORD','SALES ORDER','O','Y','SL_ORD_DATA','SL_ORD_DETL')`,
      tenantId,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME") VALUES ($1,'01','01','PARTY','Tour-only Customer')`,
      tenantId,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "SL_ORD_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","HD_VCH_NO","VCH_DATE","VCH_TIME","AC_CODE","AC_NAME","NET_AMT","TOT_AMT")
      VALUES ($1,'01','01','2024-2025','Z09','00001','H0001','2024-07-10','2024-07-10 12:30:00','PARTY','Tour-only Customer',1234.56,1234.56),
             ($1,'01','01','2024-2025','SOR','00001','H0001','2024-07-11','2024-07-11 12:30:00','PARTY','Sales Sentinel',9876.54,9876.54)`,
      tenantId,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME") VALUES
       ($1,'01','GOLD','Gold ring'),($1,'01','RUBY','Ruby component'),($1,'01','DMND','Diamond component')`, tenantId,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "SL_ORD_IDTL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","ISR_NO","IT_CODE","IT_PCS","IT_GWT")
       VALUES($1,'01','01','2024-2025','Z09','00001',17,1,'RUBY',1,0.123),
             ($1,'01','01','2024-2025','Z09','00001',17,2,'DMND',2,0.456)`, tenantId,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "SL_ORD_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","HD_VCH_NO","SR_NO","IT_CODE","DESIGN_NO","ITM_PCS","ITM_GWT","ITM_NWT","ITM_RATE","NET_AMT")
      VALUES ($1,'01','01','2024-2025','Z09','00001','H0001',17,'GOLD','TOUR-D17',2,12.345,11.123,111,1234.56)`,
      tenantId,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "LOGIN_MAST"(tenant_id,"CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG","USER_UPDATE","USER_DELETE","USER_PRINT","PASSWORD_RESET_REQUIRED")
      VALUES ($1,'01','tour-printer',$2,'USER','N','N','Y','N')`,
      tenantId,
      await hashPassword(PASSWORD),
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "USER_SET"(tenant_id,"CO_CODE","LC_CODE","USER_NAME","MAIN_MENU","SUB_MENU","FRM_VIEW","FRM_EDIT","FRM_DELETE","FRM_PRINT")
      VALUES ($1,'01','01','tour-printer','Karigar','Tour Order','Y','N','N','Y')`,
      tenantId,
    );
    const rolePassword = await hashPassword(PASSWORD);
    for (const [name, mainMenu, subMenu, view, edit, remove, print] of roles) {
      await owner.$executeRawUnsafe(`INSERT INTO "LOGIN_MAST"(tenant_id,"CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG","USER_UPDATE","USER_DELETE","USER_PRINT","PASSWORD_RESET_REQUIRED")
        VALUES($1,'01',$2,$3,'USER','Y','Y','Y','N')`, tenantId, name, rolePassword);
      await owner.$executeRawUnsafe(`INSERT INTO "USER_SET"(tenant_id,"CO_CODE","LC_CODE","USER_NAME","MAIN_MENU","SUB_MENU","FRM_VIEW","FRM_EDIT","FRM_DELETE","FRM_PRINT")
        VALUES($1,'01','01',$2,$3,$4,$5,$6,$7,$8)`, tenantId, name, mainMenu, subMenu, view, edit, remove, print);
    }
    app = await buildApp({ prisma: runtime, secret: SECRET, secureCookies: false });
    const login = await app.inject({
      method: 'POST',
      url: '/auth/login',
      headers: { 'x-tenant-id': tenantId },
      payload: {
        coCode: '01',
        lcCode: '01',
        coYear: '2024-2025',
        loginName: 'tour-printer',
        password: PASSWORD,
      },
    });
    expect(login.statusCode, login.body).toBe(200);
    const headers = login.headers['set-cookie'];
    cookie = (Array.isArray(headers) ? headers : [headers ?? ''])
      .map((header) => header.split(';', 1)[0])
      .join('; ');
    for (const [loginName] of roles) {
      const response = await app.inject({ method: 'POST', url: '/auth/login', headers: { 'x-tenant-id': tenantId },
        payload: { coCode: '01', lcCode: '01', coYear: '2024-2025', loginName, password: PASSWORD } });
      expect(response.statusCode, response.body).toBe(200);
      const value = response.headers['set-cookie'];
      cookies[loginName!] = (Array.isArray(value) ? value : [value ?? '']).map((part) => part.split(';', 1)[0]).join('; ');
    }
  });
  afterAll(async () => {
    if (app) await app.close();
    if (owner) await clean();
    if (runtime) await runtime.$disconnect();
    if (owner) await owner.$disconnect();
  });

  it('prints configured Tour Order HTML with only Karigar/Tour Order print rights', async () => {
    const response = await app.inject({
      method: 'GET',
      url: `${TOUR_URL}?coBook=Z09&vchNo=1&format=html`,
      headers: { cookie },
    });
    expect(response.statusCode, response.body).toBe(200);
    expect(response.headers['content-type']).toContain('text/html');
    // TourOrdVch's actual heading is {@RptTitle} = BOOK_DATA.BOOK_NAME.
    expect(response.body).toContain('<title>TourOrdVch</title>');
    expect(response.body).toContain('Configured Tour');
    expect(response.body).toContain('2024-07-10');
    expect(response.body).toContain('TOUR-D17');
    expect(response.body).toMatch(/data-field="\{SL_ORD_DATA.VCH_NO\}"[^>]*>00001</);
    expect(response.body).toContain('Gold ring Dsgn : TOUR-D17');
    expect(response.body).toContain('Ruby component');
    expect(response.body).toContain('Diamond component');
    expect(response.body.match(/data-kind="Detail"/g)).toHaveLength(2);
    expect(response.body).not.toContain('Sales Sentinel');
    expect(response.body).not.toContain('Sales Order Confirmation');
  });

  it('retains approved copy labels and prints the source-selected image template with its saved parent image', async () => {
    const copy = await app.inject({ method: 'GET', url: `${TOUR_URL}?coBook=Z09&vchNo=1&format=html&copy=D`, headers: { cookie } });
    expect(copy.statusCode, copy.body).toBe(200);
    expect(copy.body).toContain('DUPLICATE FOR SUPPLIER');
    const invalidCopy = await app.inject({ method: 'GET', url: `${TOUR_URL}?coBook=Z09&vchNo=1&format=html&copy=OTHER`, headers: { cookie } });
    expect(invalidCopy.statusCode).toBe(400);
    await owner.$executeRawUnsafe('INSERT INTO "CO_SET_NEW"(tenant_id,"CO_CODE","ORD_IMG_PRINT") VALUES($1,\'01\',\'Y\')', tenantId);
    const image = await app.inject({ method: 'GET', url: `${TOUR_URL}?coBook=Z09&vchNo=1&format=html`, headers: { cookie } });
    expect(image.statusCode, image.body).toBe(200);
    expect(image.body).toContain('<title>TourOrdImg</title>');
    expect(image.body).toContain('order-image-absent');
    const bytes = readFileSync(new URL('./fixtures/order-design-portrait.png', import.meta.url));
    const imageKey = JSON.stringify(['2024-2025', 'Z09', 'H0001', 'TOUR-D17']);
    await owner.$executeRawUnsafe(`INSERT INTO "ENTITY_IMAGE"(tenant_id,"CO_CODE","LC_CODE","ENTITY_TYPE","ENTITY_KEY","INSTANCE","IMAGE_TYPE","MIME_TYPE","IMAGE_SIZE","IMAGE_BYTES")
      VALUES($1,'01','01','ORDER',$2,0,'T','image/png',$3,$4)`, tenantId, imageKey, bytes.length, bytes);
    try {
      const withImage = await app.inject({ method: 'GET', url: `${TOUR_URL}?coBook=Z09&vchNo=1&format=html`, headers: { cookie } });
      expect(withImage.statusCode, withImage.body).toBe(200);
      expect(withImage.body.match(/<img /g)).toHaveLength(1);
      expect(withImage.body).toContain(`data:image/png;base64,${bytes.toString('base64')}`);
      expect(withImage.body).toContain('data-parent="17"');
      expect(withImage.body).toContain('Ruby component');
      expect(withImage.body).toContain('Diamond component');
    } finally {
      await owner.$executeRawUnsafe('DELETE FROM "ENTITY_IMAGE" WHERE tenant_id=$1', tenantId);
    }
    await owner.$executeRawUnsafe('DELETE FROM "CO_SET_NEW" WHERE tenant_id=$1', tenantId);
  });

  it('requires separate Tour Order view, update and delete rights for saved images', async () => {
    const imageUrl = '/tour-orders/00001/image?coCode=01&lcCode=01&coYear=2024-2025&coBook=Z09&srNo=17';
    for (const name of ['print-only', 'sales-images']) {
      for (const method of ['GET', 'POST', 'DELETE'] as const) {
        const denied = await app.inject({ method, url: imageUrl, headers: { cookie: cookies[name] },
          ...(method === 'POST' ? { payload: { version: 'unused', data: 'unused', mimeType: 'image/png' } } : {}) });
        expect(denied.statusCode, `${name} ${method}: ${denied.body}`).toBe(403);
      }
    }
    const print = await app.inject({ method: 'GET', url: `${TOUR_URL}?coBook=Z09&vchNo=1&format=html`, headers: { cookie: cookies['print-only'] } });
    // authorizeForm requires view as well as print; print alone grants no form access.
    expect(print.statusCode, print.body).toBe(403);
    const read = await app.inject({ method: 'GET', url: imageUrl, headers: { cookie: cookies['image-view'] } });
    expect(read.statusCode, read.body).toBe(200);
    expect(read.json()).toMatchObject({ editable: true, canUpdate: false, canDelete: false, image: { state: 'absent' } });
    const bytes = readFileSync(new URL('./fixtures/order-design-portrait.png', import.meta.url));
    const payload = { version: read.json().version, data: bytes.toString('base64'), mimeType: 'image/png' };
    for (const name of ['image-view', 'image-delete']) {
      const denied = await app.inject({ method: 'POST', url: imageUrl, headers: { cookie: cookies[name] }, payload });
      expect(denied.statusCode, denied.body).toBe(403);
    }
    const saved = await app.inject({ method: 'POST', url: imageUrl, headers: { cookie: cookies['image-edit'] }, payload });
    expect(saved.statusCode, saved.body).toBe(200);
    const reread = await app.inject({ method: 'GET', url: imageUrl, headers: { cookie: cookies['image-view'] } });
    expect(reread.statusCode, reread.body).toBe(200);
    expect(reread.json().image).toMatchObject({ state: 'present', data: payload.data, mimeType: 'image/png' });
    const removeUrl = `${imageUrl}&version=${encodeURIComponent(reread.json().version)}`;
    for (const name of ['image-view', 'image-edit']) {
      const denied = await app.inject({ method: 'DELETE', url: removeUrl, headers: { cookie: cookies[name] } });
      expect(denied.statusCode, denied.body).toBe(403);
    }
    const removed = await app.inject({ method: 'DELETE', url: removeUrl, headers: { cookie: cookies['image-delete'] } });
    expect(removed.statusCode, removed.body).toBe(200);
    const empty = await app.inject({ method: 'GET', url: imageUrl, headers: { cookie: cookies['image-view'] } });
    expect(empty.json().image).toEqual({ state: 'absent' });
  });

  it('does not acquire the separate Sales Order confirmation permission', async () => {
    const response = await app.inject({
      method: 'GET',
      url: '/sales/order-confirmation?coBook=SOR&vchNo=1&format=html',
      headers: { cookie },
    });
    expect(response.statusCode, response.body).toBe(403);
    expect(response.json()).toMatchObject({ error: 'forbidden' });
  });

  it('rejects a wrong order family and invalid voucher identities', async () => {
    const wrongFamily = await app.inject({
      method: 'GET',
      url: `${TOUR_URL}?coBook=SOR&vchNo=1&format=html`,
      headers: { cookie },
    });
    expect(wrongFamily.statusCode, wrongFamily.body).toBe(400);
    expect(wrongFamily.json()).toMatchObject({ error: 'BookPolicyValidationError' });
    for (const vchNo of ['', 'abc', '0', '-1', '1.5']) {
      const query = new URLSearchParams({ coBook: 'Z09', vchNo, format: 'html' });
      const invalid = await app.inject({
        method: 'GET',
        url: `${TOUR_URL}?${query}`,
        headers: { cookie },
      });
      expect(invalid.statusCode, invalid.body).toBe(400);
    }
  });
});
