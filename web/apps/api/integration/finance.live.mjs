// Tier-2 live finance vouchers (Task 21) as app_user.
// Run: DATABASE_URL=postgresql://app_user:app@127.0.0.1:5433/datacare node apps/api/integration/finance.live.mjs
import { PrismaClient } from '@datacare/db';
import { withTenant } from '@datacare/db';
import {
  postReceipt,
  postPayment,
  postContra,
  deleteFinance,
} from '../dist/modules/finance/finance.js';

const prisma = new PrismaClient();
const T = 'e2e';
const scope = { tenantId: T, coCode: '01', lcCode: '01', coYear: '2024' };
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
const bal = (tx, vch) =>
  tx
    .$queryRawUnsafe(
      `SELECT coalesce(sum("DR_AMT"),0)::float AS dr, coalesce(sum("CR_AMT"),0)::float AS cr FROM "AC_DATA" WHERE "VCH_NO"=$1 AND "CO_CODE"=$2`,
      String(vch),
      '01',
    )
    .then((r) => r[0]);

async function cleanup() {
  await withTenant(prisma, T, async (tx) => {
    for (const t of [
      'CASH_DATA',
      'PAY_DATA',
      'CONTRA_DATA',
      'AC_DATA',
      'DELETE_DATA',
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
    'amount<=0 -> FinanceValidationError',
    (await named(() =>
      postReceipt(prisma, {
        scope: { ...scope, coBook: 'RCT' },
        partyAc: 'CUST',
        amount: 0,
        mode: 'cash',
      }),
    )) === 'FinanceValidationError',
  );
  check(
    'cash > limit without PAN -> FinanceValidationError',
    (await named(() =>
      postReceipt(prisma, {
        scope: { ...scope, coBook: 'RCT' },
        partyAc: 'CUST',
        amount: 250000,
        mode: 'cash',
        cashLimit: 200000,
      }),
    )) === 'FinanceValidationError',
  );

  // receipt (money in): Dr CASH / Cr CUST
  const r = await postReceipt(prisma, {
    scope: { ...scope, coBook: 'RCT' },
    partyAc: 'CUST',
    partyName: 'Cust One',
    amount: 5000,
    mode: 'cash',
  });
  const [rc, rb] = await withTenant(prisma, T, async (tx) => [
    await cnt(tx, 'CASH_DATA', r.vchNo),
    await bal(tx, r.vchNo),
  ]);
  check('receipt CASH_DATA(1)', rc === 1);
  check('receipt AC_DATA balanced (dr=cr=5000)', rb.dr === 5000 && rb.cr === 5000);

  // payment (money out): Dr SUPP / Cr BANK (cheque)
  const p = await postPayment(prisma, {
    scope: { ...scope, coBook: 'PAY' },
    partyAc: 'SUPP',
    amount: 3000,
    mode: 'cheque',
    bankAc: 'HDFC',
    chqNo: '11',
  });
  const [pc, pb] = await withTenant(prisma, T, async (tx) => [
    await cnt(tx, 'PAY_DATA', p.vchNo),
    await bal(tx, p.vchNo),
  ]);
  check('payment PAY_DATA(1)', pc === 1);
  check('payment AC_DATA balanced (dr=cr=3000)', pb.dr === 3000 && pb.cr === 3000);

  // contra: cash -> bank
  const c = await postContra(prisma, {
    scope: { ...scope, coBook: 'CON' },
    fromAc: 'CASH',
    toAc: 'HDFC',
    amount: 2000,
  });
  const [cc, cb] = await withTenant(prisma, T, async (tx) => [
    await cnt(tx, 'CONTRA_DATA', c.vchNo),
    await bal(tx, c.vchNo),
  ]);
  check('contra CONTRA_DATA(1)', cc === 1);
  check('contra AC_DATA balanced (dr=cr=2000)', cb.dr === 2000 && cb.cr === 2000);

  // delete receipt -> rows gone + DELETE_DATA
  await deleteFinance(prisma, {
    scope: { ...scope, coBook: 'RCT' },
    vchNo: r.vchNo,
    headerTable: 'CASH_DATA',
    book: 'RCT',
    vchType: 'RCT',
    deleteUser: 'admin',
  });
  const [rc2, rb2, del] = await withTenant(prisma, T, async (tx) => [
    await cnt(tx, 'CASH_DATA', r.vchNo),
    await bal(tx, r.vchNo),
    await cnt(tx, 'DELETE_DATA', r.vchNo),
  ]);
  check('deleted receipt CASH_DATA(0)', rc2 === 0);
  check('deleted receipt AC_DATA(0)', rb2.dr === 0 && rb2.cr === 0);
  check('wrote DELETE_DATA(>=1)', del >= 1);

  await cleanup();
  await prisma.$disconnect();
  console.log(`\nFINANCE_E2E pass=${pass} fail=${fail}`);
  if (fail > 0) process.exit(1);
  console.log('FINANCE_E2E_PASS');
}
main().catch((e) => {
  console.error(e);
  process.exit(1);
});
