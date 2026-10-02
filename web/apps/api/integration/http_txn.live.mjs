// Tier-2 live HTTP e2e for the mobile-facing transaction/report API (Follow-up F3).
// login -> POST /sales -> GET /reports -> GET /gst -> DELETE /sales + RBAC 403. Fastify .inject().
// Run: DATABASE_URL=postgresql://app_user:app@127.0.0.1:5433/datacare node apps/api/integration/http_txn.live.mjs
import { PrismaClient } from '@datacare/db';
import { withTenant } from '@datacare/db';
import { buildApp } from '../dist/app.js';
import { hashPassword } from '../dist/modules/auth/password.js';

const prisma = new PrismaClient();
const SECRET = 'test-secret';
const TENANT = 'e2e';
const H = { 'x-tenant-id': TENANT, 'content-type': 'application/json' };
let pass = 0,
  fail = 0;
const check = (n, c) => {
  c ? (pass++, console.log('  ok  ' + n)) : (fail++, console.log('  FAIL ' + n));
};
const cookieOf = (res) => Object.fromEntries((res.cookies ?? []).map((c) => [c.name, c.value]));

async function seed() {
  const admin = await hashPassword('Secret#1');
  const clerk = await hashPassword('Clerk#1');
  await withTenant(prisma, TENANT, async (tx) => {
    for (const t of [
      'LOGIN_MAST',
      'SL_DATA',
      'SL_DETL',
      'SL_IDTL',
      'AC_DATA',
      'CASH_DATA',
      'SRNO_MAST',
    ])
      await tx.$executeRawUnsafe(`DELETE FROM "${t}" WHERE "CO_CODE"=$1`, '01');
    await tx.$executeRawUnsafe(
      'INSERT INTO "LOGIN_MAST"(tenant_id,"CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG") VALUES ($1,$2,$3,$4,$5)',
      TENANT,
      '01',
      'admin',
      admin,
      'ADMIN',
    );
    await tx.$executeRawUnsafe(
      'INSERT INTO "LOGIN_MAST"(tenant_id,"CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG") VALUES ($1,$2,$3,$4,$5)',
      TENANT,
      '01',
      'clerk',
      clerk,
      'U',
    );
  });
}
async function cleanup() {
  await withTenant(prisma, TENANT, async (tx) => {
    for (const t of [
      'LOGIN_MAST',
      'SL_DATA',
      'SL_DETL',
      'SL_IDTL',
      'AC_DATA',
      'CASH_DATA',
      'SRNO_MAST',
    ])
      await tx.$executeRawUnsafe(`DELETE FROM "${t}" WHERE "CO_CODE"=$1`, '01');
  });
}

async function main() {
  await seed();
  const app = await buildApp({ prisma, secret: SECRET });
  const login = (loginName, password) =>
    app.inject({
      method: 'POST',
      url: '/auth/login',
      headers: H,
      payload: { coCode: '01', loginName, password },
    });

  const adminC = cookieOf(await login('admin', 'Secret#1')).access;
  const clerkC = cookieOf(await login('clerk', 'Clerk#1')).access;
  check('admin + clerk logged in', !!adminC && !!clerkC);
  const scope = { coBook: 'SAL', coYear: '2024', lcCode: '01' };

  // POST /sales
  const saleRes = await app.inject({
    method: 'POST',
    url: '/sales',
    headers: H,
    cookies: { access: adminC },
    payload: {
      ...scope,
      acCode: 'CUST1',
      taxRatePct: 3,
      interState: false,
      lines: [{ itCode: 'GOLD', metalAmount: 1000 }],
    },
  });
  check('POST /sales -> 201', saleRes.statusCode === 201);
  const sale = JSON.parse(saleRes.body);
  check('sale total 1030 over HTTP', sale.totals?.total === 1030);

  // POST /receipts
  const rc = await app.inject({
    method: 'POST',
    url: '/receipts',
    headers: H,
    cookies: { access: adminC },
    payload: { ...scope, coBook: 'RCT', partyAc: 'CUST1', amount: 5000, mode: 'cash' },
  });
  check('POST /receipts -> 201', rc.statusCode === 201);

  // GET /reports/sales-register
  const reg = await app.inject({
    method: 'GET',
    url: '/reports/sales-register?coYear=2024',
    headers: H,
    cookies: { access: adminC },
  });
  check('GET /reports/sales-register -> 200', reg.statusCode === 200);
  const regBody = JSON.parse(reg.body);
  check(
    'register shows 1 row, total 1030',
    regBody.rows?.length === 1 && regBody.totals?.totAmt === 1030,
  );

  // GET /reports/trial-balance (balanced)
  const tb = await app.inject({
    method: 'GET',
    url: '/reports/trial-balance?coYear=2024',
    headers: H,
    cookies: { access: adminC },
  });
  check(
    'GET /reports/trial-balance balanced',
    tb.statusCode === 200 && JSON.parse(tb.body).balanced === true,
  );

  // GET /gst/gstr1
  const gst = await app.inject({
    method: 'GET',
    url: '/gst/gstr1?coYear=2024',
    headers: H,
    cookies: { access: adminC },
  });
  check(
    'GET /gst/gstr1 -> 200 with buckets',
    gst.statusCode === 200 && Array.isArray(JSON.parse(gst.body).b2cs),
  );

  // validation error -> 400 (no acCode)
  const bad = await app.inject({
    method: 'POST',
    url: '/sales',
    headers: H,
    cookies: { access: adminC },
    payload: { ...scope, taxRatePct: 3, interState: false, lines: [] },
  });
  check('POST /sales invalid -> 400', bad.statusCode === 400);

  // RBAC: clerk cannot delete
  const clerkDel = await app.inject({
    method: 'DELETE',
    url: `/sales/${sale.vchNo}`,
    headers: H,
    cookies: { access: clerkC },
    payload: scope,
  });
  check('clerk DELETE /sales -> 403', clerkDel.statusCode === 403);

  // unauth -> 401
  const noAuth = await app.inject({
    method: 'POST',
    url: '/sales',
    headers: H,
    payload: { ...scope, acCode: 'X', taxRatePct: 3, lines: [{ itCode: 'G', metalAmount: 1 }] },
  });
  check('POST /sales without cookie -> 401', noAuth.statusCode === 401);

  // admin DELETE /sales -> 200
  const del = await app.inject({
    method: 'DELETE',
    url: `/sales/${sale.vchNo}`,
    headers: H,
    cookies: { access: adminC },
    payload: scope,
  });
  check('admin DELETE /sales -> 200', del.statusCode === 200);

  await app.close();
  await cleanup();
  await prisma.$disconnect();
  console.log(`\nHTTP_TXN_E2E pass=${pass} fail=${fail}`);
  if (fail > 0) process.exit(1);
  console.log('HTTP_TXN_E2E_PASS');
}
main().catch((e) => {
  console.error(e);
  process.exit(1);
});
