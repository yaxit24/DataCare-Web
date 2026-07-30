// Tier-2 live sales end-to-end (Task 19) as app_user.
// Run: DATABASE_URL=postgresql://app_user:app@127.0.0.1:5433/datacare node apps/api/integration/sales.live.mjs
import { PrismaClient } from '@prisma/client';
import { withTenant } from '@datacare/db';
import { createSale, deleteSale, SaleValidationError } from '../dist/modules/sales/sales.js';
import { createTag, tagAvailable } from '../dist/modules/stock/stock.js';
import { TagNotAvailableError } from '../dist/modules/stock/stock.js';

const prisma = new PrismaClient();
const T = 'e2e';
const scope = { tenantId: T, coCode: '01', lcCode: '01', coYear: '2024', coBook: 'SAL' };
const tagData = {
  CO_CODE: '01',
  LC_CODE: '01',
  TAG_NO: 'T1',
  ITM_PCS: 1,
  ITM_GWT: 10,
  ITM_NWT: 9.5,
  STK_TYPE: 'R',
};
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
    for (const t of [
      'SL_DATA',
      'SL_DETL',
      'SL_IDTL',
      'AC_DATA',
      'DELETE_DATA',
      'TAG_STOCK',
      'SRNO_MAST',
    ]) {
      await tx.$executeRawUnsafe(`DELETE FROM "${t}" WHERE "CO_CODE"=$1`, '01');
    }
  });
}

async function main() {
  await cleanup();

  // validations
  check(
    'no acCode -> SaleValidationError',
    (await named(() =>
      createSale(prisma, { scope, acCode: '', taxRatePct: 3, interState: false }, [
        { itCode: 'I1' },
      ]),
    )) === 'SaleValidationError',
  );
  check(
    'no lines -> SaleValidationError',
    (await named(() =>
      createSale(prisma, { scope, acCode: 'CUST', taxRatePct: 3, interState: false }, []),
    )) === 'SaleValidationError',
  );

  // atomicity: selling a tag not in stock rolls the whole sale back (no SL_DATA, no number consumed)
  const ghostErr = await named(() =>
    createSale(prisma, { scope, acCode: 'CUST', taxRatePct: 3, interState: false }, [
      { itCode: 'I1', tagNo: 'GHOST', metalAmount: 1000 },
    ]),
  );
  check('ghost tag -> TagNotAvailableError', ghostErr === 'TagNotAvailableError');
  const slAfterGhost = await withTenant(prisma, T, (tx) => cntAll(tx, 'SL_DATA'));
  check('rolled back -> 0 SL_DATA rows', slAfterGhost === 0);

  // happy path: tag in stock, intra-state 3% on 1000 metal
  await createTag(prisma, T, tagData);
  const res = await createSale(
    prisma,
    { scope, acCode: 'CUST', acName: 'Cust One', taxRatePct: 3, interState: false, billNo: 'B1' },
    [{ itCode: 'I1', tagNo: 'T1', metalAmount: 1000, netWt: 9.5 }],
  );
  check('sale total = 1030 (1000 + 3%)', res.totals.total === 1030);
  const [sl, dt, id, ac, avail] = await withTenant(prisma, T, async (tx) => [
    await cnt(tx, 'SL_DATA', res.vchNo),
    await cnt(tx, 'SL_DETL', res.vchNo),
    await cnt(tx, 'SL_IDTL', res.vchNo),
    await cnt(tx, 'AC_DATA', res.vchNo),
    await tagAvailable(prisma, T, { CO_CODE: '01', LC_CODE: '01', TAG_NO: 'T1' }),
  ]);
  check('posted SL_DATA(1)', sl === 1);
  check('posted SL_DETL(1)', dt === 1);
  check('posted SL_IDTL(1)', id === 1);
  check('posted AC_DATA(3 = Dr cust / Cr sales / Cr gst)', ac === 3);
  check('tag T1 issued -> unavailable', avail === false);

  // delete + restore tag
  await deleteSale(prisma, {
    scope,
    vchNo: res.vchNo,
    deleteUser: 'admin',
    tagRestores: [tagData],
  });
  const [sl2, ac2, del, avail2] = await withTenant(prisma, T, async (tx) => [
    await cnt(tx, 'SL_DATA', res.vchNo),
    await cnt(tx, 'AC_DATA', res.vchNo),
    await cntAll(tx, 'DELETE_DATA'),
    await tagAvailable(prisma, T, { CO_CODE: '01', LC_CODE: '01', TAG_NO: 'T1' }),
  ]);
  check('deleted SL_DATA(0)', sl2 === 0);
  check('deleted AC_DATA(0)', ac2 === 0);
  check('wrote DELETE_DATA(>=1)', del >= 1);
  check('tag T1 restored -> available', avail2 === true);

  await cleanup();
  await prisma.$disconnect();
  console.log(`\nSALES_E2E pass=${pass} fail=${fail}`);
  if (fail > 0) process.exit(1);
  console.log('SALES_E2E_PASS');
}
main().catch((e) => {
  console.error(e);
  process.exit(1);
});
