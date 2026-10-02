// Tier-2 live purchase end-to-end (Task 20) as app_user.
// Run: DATABASE_URL=postgresql://app_user:app@127.0.0.1:5433/datacare node apps/api/integration/purchase.live.mjs
import { PrismaClient } from '@datacare/db';
import { withTenant } from '@datacare/db';
import {
  createPurchase,
  deletePurchase,
  PurchaseValidationError,
} from '../dist/modules/purchase/purchase.js';
import { tagAvailable, createTag, TagExistsError } from '../dist/modules/stock/stock.js';

const prisma = new PrismaClient();
const T = 'e2e';
const scope = { tenantId: T, coCode: '01', lcCode: '01', coYear: '2024', coBook: 'PUR' };
const tagKey = { CO_CODE: '01', LC_CODE: '01', TAG_NO: 'P1' };
let pass = 0,
  fail = 0;
const check = (n, c) => {
  c ? (pass++, console.log('  ok  ' + n)) : (fail++, console.log('  FAIL ' + n));
};
const named = async (fn) => {
  try {
    await fn();
    return 'NONE';
  } catch (e) {
    return e.name;
  }
};
const cnt = (tx, t, vch) =>
  tx
    .$queryRawUnsafe(
      `SELECT count(*)::int AS n FROM "${t}" WHERE "VCH_NO"=$1 AND "CO_CODE"=$2`,
      String(vch),
      '01',
    )
    .then((r) => r[0].n);
const cntAll = (tx, t) =>
  tx
    .$queryRawUnsafe(`SELECT count(*)::int AS n FROM "${t}" WHERE "CO_CODE"=$1`, '01')
    .then((r) => r[0].n);

async function cleanup() {
  await withTenant(prisma, T, async (tx) => {
    for (const t of ['PR_DATA', 'PR_DETL', 'AC_DATA', 'DELETE_DATA', 'TAG_STOCK', 'SRNO_MAST']) {
      await tx.$executeRawUnsafe(`DELETE FROM "${t}" WHERE "CO_CODE"=$1`, '01');
    }
  });
}

async function main() {
  await cleanup();

  // validations
  check(
    'no acCode -> PurchaseValidationError',
    (await named(() =>
      createPurchase(prisma, { scope, acCode: '', taxRatePct: 3, interState: false }, [
        { itCode: 'I1' },
      ]),
    )) === 'PurchaseValidationError',
  );
  check(
    'no lines -> PurchaseValidationError',
    (await named(() =>
      createPurchase(prisma, { scope, acCode: 'SUPP', taxRatePct: 3, interState: false }, []),
    )) === 'PurchaseValidationError',
  );

  // atomicity: a duplicate tag (already in stock) rolls the whole purchase back
  await createTag(prisma, T, { ...tagKey, ITM_PCS: 1, ITM_GWT: 10, ITM_NWT: 9.5, STK_TYPE: 'R' });
  const dupErr = await named(() =>
    createPurchase(prisma, { scope, acCode: 'SUPP', taxRatePct: 3, interState: false }, [
      { itCode: 'I1', tagNo: 'P1', netWt: 10, touch: 100, rate: 100 },
    ]),
  );
  check('duplicate tag -> TagExistsError', dupErr === 'TagExistsError');
  const prAfterDup = await withTenant(prisma, T, (tx) => cntAll(tx, 'PR_DATA'));
  check('rolled back -> 0 PR_DATA rows', prAfterDup === 0);
  // remove the seed tag so the happy path can create it cleanly
  await withTenant(prisma, T, (tx) =>
    tx.$executeRawUnsafe(`DELETE FROM "TAG_STOCK" WHERE "CO_CODE"=$1`, '01'),
  );

  // happy path: stock-IN tag P1, intra 3% on fine(10)×rate(100)=1000
  const res = await createPurchase(
    prisma,
    {
      scope,
      acCode: 'SUPP',
      acName: 'Supplier One',
      taxRatePct: 3,
      interState: false,
      billNo: 'PB1',
    },
    [{ itCode: 'I1', tagNo: 'P1', netWt: 10, touch: 100, rate: 100 }],
  );
  check('purchase total = 1030 (1000 + 3%)', res.totals.total === 1030);
  const [pr, dt, ac, avail] = await withTenant(prisma, T, async (tx) => [
    await cnt(tx, 'PR_DATA', res.vchNo),
    await cnt(tx, 'PR_DETL', res.vchNo),
    await cnt(tx, 'AC_DATA', res.vchNo),
    await tagAvailable(prisma, T, tagKey),
  ]);
  check('posted PR_DATA(1)', pr === 1);
  check('posted PR_DETL(1)', dt === 1);
  check('posted AC_DATA(3 = Cr supplier / Dr purchase / Dr gst-input)', ac === 3);
  check('stock-IN: tag P1 now available', avail === true);

  // delete + remove the created tag
  await deletePurchase(prisma, {
    scope,
    vchNo: res.vchNo,
    deleteUser: 'admin',
    tagRemovals: [tagKey],
  });
  const [pr2, ac2, del, avail2] = await withTenant(prisma, T, async (tx) => [
    await cnt(tx, 'PR_DATA', res.vchNo),
    await cnt(tx, 'AC_DATA', res.vchNo),
    await cntAll(tx, 'DELETE_DATA'),
    await tagAvailable(prisma, T, tagKey),
  ]);
  check('deleted PR_DATA(0)', pr2 === 0);
  check('deleted AC_DATA(0)', ac2 === 0);
  check('wrote DELETE_DATA(>=1)', del >= 1);
  check('stock reversed: tag P1 removed', avail2 === false);

  await cleanup();
  await prisma.$disconnect();
  console.log(`\nPURCHASE_E2E pass=${pass} fail=${fail}`);
  if (fail > 0) process.exit(1);
  console.log('PURCHASE_E2E_PASS');
}
main().catch((e) => {
  console.error(e);
  process.exit(1);
});
