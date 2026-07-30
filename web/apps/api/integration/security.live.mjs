// Tier-2 live security re-assertion (Task 31) as app_user — RLS tenant isolation must hold.
// Run: DATABASE_URL=postgresql://app_user:app@127.0.0.1:5433/datacare node apps/api/integration/security.live.mjs
import { PrismaClient } from '@prisma/client';
import { withTenant } from '@datacare/db';

const prisma = new PrismaClient();
let pass = 0,
  fail = 0;
const check = (n, c) => {
  c ? (pass++, console.log('  ok  ' + n)) : (fail++, console.log('  FAIL ' + n));
};
const cnt = (tx) =>
  tx
    .$queryRawUnsafe(
      `SELECT count(*)::int AS n FROM "AC_MAST" WHERE "AC_CODE"=$1 AND "CO_CODE"=$2`,
      'RLSCHK',
      'ZZ',
    )
    .then((r) => r[0].n);

async function clean() {
  // remove the probe row under whichever tenant owns it
  for (const t of ['secA', 'secB'])
    await withTenant(prisma, t, (tx) =>
      tx.$executeRawUnsafe(
        `DELETE FROM "AC_MAST" WHERE "AC_CODE"=$1 AND "CO_CODE"=$2`,
        'RLSCHK',
        'ZZ',
      ),
    );
}

async function main() {
  await clean();

  // tenant secA inserts a probe row
  await withTenant(prisma, 'secA', (tx) =>
    tx.$executeRawUnsafe(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","AC_CODE","AC_NAME") VALUES ($1,$2,$3,$4)`,
      'secA',
      'ZZ',
      'RLSCHK',
      'probe',
    ),
  );

  const ownerSees = await withTenant(prisma, 'secA', cnt);
  const otherSees = await withTenant(prisma, 'secB', cnt);
  check('RLS: owning tenant secA sees its row (1)', ownerSees === 1);
  check('RLS: other tenant secB sees NOTHING (0) — isolation holds', otherSees === 0);

  await clean();
  const afterClean = await withTenant(prisma, 'secA', cnt);
  check('cleanup removed probe (0)', afterClean === 0);

  await prisma.$disconnect();
  console.log(`\nSECURITY_E2E pass=${pass} fail=${fail}`);
  if (fail > 0) process.exit(1);
  console.log('SECURITY_E2E_PASS');
}
main().catch((e) => {
  console.error(e);
  process.exit(1);
});
