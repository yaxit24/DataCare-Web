// Tier-2 live master-data CRUD (Task 13) as app_user against Postgres.
// Run: DATABASE_URL=postgresql://app_user:app@127.0.0.1:5433/datacare \
//      node apps/api/integration/masters.live.mjs   (after build)
import { PrismaClient } from '@datacare/db';
import { withTenant } from '@datacare/db';
import {
  createMaster,
  deleteMaster,
  AC_MAST_CONFIG,
  ITEM_MAST_CONFIG,
} from '../dist/modules/masters/master.service.js';
import { MASTERS } from '../dist/modules/masters/configs.js';

const prisma = new PrismaClient();
const T = 'e2e';
let pass = 0,
  fail = 0;
const check = (n, c) => {
  c ? (pass++, console.log('  ok  ' + n)) : (fail++, console.log('  FAIL ' + n));
};
const errName = async (fn) => {
  try {
    await fn();
    return 'NONE';
  } catch (e) {
    return e.name;
  }
};

async function cleanup() {
  await withTenant(prisma, T, async (tx) => {
    await tx.$executeRawUnsafe('DELETE FROM "ITEM_MAST" WHERE "CO_CODE"=$1', '01');
    await tx.$executeRawUnsafe('DELETE FROM "AC_MAST" WHERE "CO_CODE"=$1', '01');
    await tx.$executeRawUnsafe('DELETE FROM "AC_DATA" WHERE "CO_CODE"=$1', '01');
    await tx.$executeRawUnsafe('DELETE FROM "TAX_MAST" WHERE "CO_CODE"=$1', '01');
    await tx.$executeRawUnsafe('DELETE FROM "RATE_MAST" WHERE "CO_CODE"=$1', '01');
    await tx.$executeRawUnsafe('DELETE FROM "GROUP_MAST" WHERE "CO_CODE"=$1', '01');
  });
}

async function main() {
  await cleanup();

  // create + duplicate + missing-required (ITEM_MAST)
  const c1 = await createMaster(prisma, T, ITEM_MAST_CONFIG, {
    CO_CODE: '01',
    IT_CODE: 'IT1',
    IT_NAME: 'Gold Ring',
  });
  check('create item', c1.created === true);
  check(
    'duplicate item -> DuplicateKeyError',
    (await errName(() =>
      createMaster(prisma, T, ITEM_MAST_CONFIG, { CO_CODE: '01', IT_CODE: 'IT1', IT_NAME: 'x' }),
    )) === 'DuplicateKeyError',
  );
  check(
    'missing required -> ValidationError',
    (await errName(() =>
      createMaster(prisma, T, ITEM_MAST_CONFIG, { CO_CODE: '01', IT_CODE: 'IT2' }),
    )) === 'ValidationError',
  );

  // referential delete guard (AC_MAST referenced by AC_DATA)
  await createMaster(prisma, T, AC_MAST_CONFIG, { CO_CODE: '01', AC_CODE: 'AC1', AC_NAME: 'Cash' });
  await withTenant(prisma, T, (tx) =>
    tx.$executeRawUnsafe(
      'INSERT INTO "AC_DATA"(tenant_id,"CO_CODE","AC_CODE") VALUES ($1,$2,$3)',
      T,
      '01',
      'AC1',
    ),
  );
  check(
    'delete referenced account -> ReferencedError',
    (await errName(() =>
      deleteMaster(prisma, T, AC_MAST_CONFIG, { CO_CODE: '01', AC_CODE: 'AC1' }),
    )) === 'ReferencedError',
  );

  // remove the referencing row, then delete succeeds
  await withTenant(prisma, T, (tx) =>
    tx.$executeRawUnsafe('DELETE FROM "AC_DATA" WHERE "CO_CODE"=$1', '01'),
  );
  const d1 = await deleteMaster(prisma, T, AC_MAST_CONFIG, { CO_CODE: '01', AC_CODE: 'AC1' });
  check('delete unreferenced account', d1.deleted === true);

  const d2 = await deleteMaster(prisma, T, ITEM_MAST_CONFIG, { CO_CODE: '01', IT_CODE: 'IT1' });
  check('delete item', d2.deleted === true);

  // remaining masters via registry (varchar-keyed; RATE_MAST has a date+float key — typed-key
  // handling deferred, config still registered)
  const tax = MASTERS.taxes;
  const grp = MASTERS.groups;
  check(
    'create tax',
    (await createMaster(prisma, T, tax, { CO_CODE: '01', TAX_CODE: 'T1', TAX_NAME: 'GST3' }))
      .created === true,
  );
  check(
    'duplicate tax -> DuplicateKeyError',
    (await errName(() =>
      createMaster(prisma, T, tax, { CO_CODE: '01', TAX_CODE: 'T1', TAX_NAME: 'x' }),
    )) === 'DuplicateKeyError',
  );
  check(
    'create group',
    (await createMaster(prisma, T, grp, { CO_CODE: '01', GR_CODE: 'G1', GR_NAME: 'Gold 22K' }))
      .created === true,
  );
  check(
    'delete tax',
    (await deleteMaster(prisma, T, tax, { CO_CODE: '01', TAX_CODE: 'T1' })).deleted === true,
  );
  check(
    'delete group',
    (await deleteMaster(prisma, T, grp, { CO_CODE: '01', GR_CODE: 'G1' })).deleted === true,
  );

  await cleanup();
  await prisma.$disconnect();
  console.log(`\nMASTERS_E2E pass=${pass} fail=${fail}`);
  if (fail > 0) process.exit(1);
  console.log('MASTERS_E2E_PASS');
}
main().catch((e) => {
  console.error(e);
  process.exit(1);
});
