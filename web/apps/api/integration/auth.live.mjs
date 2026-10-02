// Tier-2 live integration (Task 10): authenticate against LOGIN_MAST in Postgres as app_user.
// Run: DATABASE_URL=postgresql://app_user:app@127.0.0.1:5433/datacare \
//      node apps/api/integration/auth.live.mjs   (after `pnpm --filter @datacare/api build`)
import { PrismaClient } from '@datacare/db';
import { withTenant } from '@datacare/db';
import { authenticate } from '../dist/modules/auth/auth.service.js';
import { hashPassword } from '../dist/modules/auth/password.js';

const prisma = new PrismaClient();
const TENANT = 't-auth';
const audit = async () => {};
const T = '"LOGIN_MAST"';

const loadUser = (tid, co, name) =>
  withTenant(prisma, tid, async (tx) => {
    const rows = await tx.$queryRawUnsafe(
      `SELECT "CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG" FROM ${T} WHERE "CO_CODE"=$1 AND "LOGIN_NAME"=$2 LIMIT 1`,
      co,
      name,
    );
    return rows[0] ?? null;
  });

async function main() {
  const hpw = await hashPassword('Secret#1');
  await withTenant(prisma, TENANT, async (tx) => {
    await tx.$executeRawUnsafe(
      `DELETE FROM ${T} WHERE "CO_CODE"=$1 AND "LOGIN_NAME"=$2`,
      '01',
      'admin',
    );
    await tx.$executeRawUnsafe(
      `INSERT INTO ${T}(tenant_id,"CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG") VALUES ($1,$2,$3,$4,$5)`,
      TENANT,
      '01',
      'admin',
      hpw,
      'ADMIN',
    );
  });

  const deps = { loadUser, audit };
  const ok = await authenticate(deps, {
    tenantId: TENANT,
    coCode: '01',
    loginName: 'admin',
    password: 'Secret#1',
  });
  console.log(
    `valid-login ok=${ok.userId} adminRights=${ok.rights.userDelete} forcedReset=${ok.forcedReset}`,
  );

  let badName = 'NONE';
  try {
    await authenticate(deps, {
      tenantId: TENANT,
      coCode: '01',
      loginName: 'admin',
      password: 'wrong',
    });
  } catch (e) {
    badName = e.name;
  }
  console.log(`bad-login rejected=${badName}`);

  await withTenant(prisma, TENANT, (tx) =>
    tx.$executeRawUnsafe(`DELETE FROM ${T} WHERE "CO_CODE"=$1 AND "LOGIN_NAME"=$2`, '01', 'admin'),
  );
  await prisma.$disconnect();

  if (ok.userId === 'admin' && ok.rights.userDelete === true && badName === 'AuthError') {
    console.log('AUTH_INTEGRATION_PASS');
  } else {
    console.log('AUTH_INTEGRATION_FAIL');
    process.exit(1);
  }
}
main().catch((e) => {
  console.error(e);
  process.exit(1);
});
