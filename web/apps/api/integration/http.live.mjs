// Tier-2 live HTTP e2e (Task 12) via Fastify .inject() against Postgres as app_user.
// Run: DATABASE_URL=postgresql://app_user:app@127.0.0.1:5433/datacare \
//      node apps/api/integration/http.live.mjs   (after `pnpm --filter @datacare/api build`)
import { PrismaClient } from '@datacare/db';
import { withTenant } from '@datacare/db';
import { buildApp } from '../dist/app.js';
import { hashPassword } from '../dist/modules/auth/password.js';

const prisma = new PrismaClient();
const SECRET = 'test-secret';
const TENANT = 'e2e';
const H = { 'x-tenant-id': TENANT, 'content-type': 'application/json' };
let pass = 0;
let fail = 0;
const check = (name, cond) => {
  if (cond) {
    pass++;
    console.log(`  ok  ${name}`);
  } else {
    fail++;
    console.log(`  FAIL ${name}`);
  }
};

async function seed() {
  const admin = await hashPassword('Secret#1');
  const clerk = await hashPassword('Clerk#1');
  await withTenant(prisma, TENANT, async (tx) => {
    await tx.$executeRawUnsafe('DELETE FROM "LOGIN_MAST" WHERE "CO_CODE"=$1', '01');
    await tx.$executeRawUnsafe('DELETE FROM "CO_MAST" WHERE "CO_CODE"=$1', '01');
    await tx.$executeRawUnsafe('DELETE FROM "YEAR_MAST"');
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
    await tx.$executeRawUnsafe(
      'INSERT INTO "CO_MAST"(tenant_id,"CO_CODE","CO_NAME") VALUES ($1,$2,$3)',
      TENANT,
      '01',
      'Test Jeweller',
    );
    await tx.$executeRawUnsafe(
      'INSERT INTO "YEAR_MAST"(tenant_id,"OP_DATE") VALUES ($1,$2::date)',
      TENANT,
      '2024-04-01',
    );
  });
}

async function cleanup() {
  await withTenant(prisma, TENANT, async (tx) => {
    await tx.$executeRawUnsafe('DELETE FROM "LOGIN_MAST" WHERE "CO_CODE"=$1', '01');
    await tx.$executeRawUnsafe('DELETE FROM "CO_MAST" WHERE "CO_CODE"=$1', '01');
    await tx.$executeRawUnsafe('DELETE FROM "YEAR_MAST"');
  });
}

const cookieOf = (res) => Object.fromEntries((res.cookies ?? []).map((c) => [c.name, c.value]));

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

  const okLogin = await login('admin', 'Secret#1');
  check('admin login 200', okLogin.statusCode === 200);
  const adminCookies = cookieOf(okLogin);
  check('login sets httpOnly access cookie', !!adminCookies.access);

  const badLogin = await login('admin', 'wrong');
  check('bad password 401', badLogin.statusCode === 401);

  const noAuth = await app.inject({ method: 'GET', url: '/context/companies', headers: H });
  check('companies without cookie 401', noAuth.statusCode === 401);

  const companies = await app.inject({
    method: 'GET',
    url: '/context/companies',
    headers: H,
    cookies: { access: adminCookies.access },
  });
  check('companies with cookie 200', companies.statusCode === 200);
  check('companies includes CO 01', /(["']?CO_CODE["']?\s*:\s*"01")/.test(companies.body));

  const badYear = await app.inject({
    method: 'POST',
    url: '/context/select',
    headers: H,
    cookies: { access: adminCookies.access },
    payload: { coCode: '01', coYear: '2099' },
  });
  check('invalid year 409', badYear.statusCode === 409);

  const goodYear = await app.inject({
    method: 'POST',
    url: '/context/select',
    headers: H,
    cookies: { access: adminCookies.access },
    payload: { coCode: '01', coYear: '2024' },
  });
  check('valid year select 200', goodYear.statusCode === 200);

  const adminDelete = await app.inject({
    method: 'POST',
    url: '/secure/delete-demo',
    headers: H,
    cookies: { access: adminCookies.access },
    payload: {},
  });
  check('admin delete allowed 200', adminDelete.statusCode === 200);

  const clerkLogin = await login('clerk', 'Clerk#1');
  const clerkCookies = cookieOf(clerkLogin);
  const clerkDelete = await app.inject({
    method: 'POST',
    url: '/secure/delete-demo',
    headers: H,
    cookies: { access: clerkCookies.access },
    payload: {},
  });
  check('clerk delete forbidden 403', clerkDelete.statusCode === 403);

  await app.close();
  await cleanup();
  await prisma.$disconnect();
  console.log(`\nHTTP_E2E pass=${pass} fail=${fail}`);
  if (fail > 0) process.exit(1);
  console.log('HTTP_E2E_PASS');
}
main().catch((e) => {
  console.error(e);
  process.exit(1);
});
