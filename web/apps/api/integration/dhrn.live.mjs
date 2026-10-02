// Tier-2 live Dhrn pledge-loan (Task 23) as app_user.
// Run: DATABASE_URL=postgresql://app_user:app@127.0.0.1:5433/datacare node apps/api/integration/dhrn.live.mjs
import { PrismaClient } from '@datacare/db';
import { withTenant } from '@datacare/db';
import {
  issueDhrn,
  receiveDhrn,
  outstanding,
  deleteDhrn,
  accruedInterest,
} from '../dist/modules/dhrn/dhrn.js';

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
    for (const t of ['DHRN_ISU_DATA', 'DHRN_REC_DATA', 'AC_DATA', 'DELETE_DATA', 'SRNO_MAST']) {
      await tx.$executeRawUnsafe(`DELETE FROM "${t}" WHERE "CO_CODE"=$1`, '01');
    }
  });
}

async function main() {
  await cleanup();

  // validations
  check(
    'principal<=0 -> DhrnValidationError',
    (await named(() =>
      issueDhrn(prisma, {
        scope: { ...scope, coBook: 'DIS' },
        borrowerAc: 'BORR',
        principal: 0,
        intPrc: 12,
      }),
    )) === 'DhrnValidationError',
  );

  // issue: principal 10000 @ 12%/yr against gold; Dr DHRN 10000 / Cr CASH 10000
  const isu = await issueDhrn(prisma, {
    scope: { ...scope, coBook: 'DIS' },
    borrowerAc: 'BORR',
    borrowerName: 'Borrower',
    principal: 10000,
    intPrc: 12,
    goldWt: 20,
    goldAmt: 12000,
  });
  check('issue monthly interest = 100 (10000 @12%/yr, 30d/360)', isu.monthInt === 100);
  const [ic, ib, os0] = await withTenant(prisma, T, async (tx) => [
    await cnt(tx, 'DHRN_ISU_DATA', isu.vchNo),
    await bal(tx, isu.vchNo),
    await outstanding(prisma, scope, isu.vchNo),
  ]);
  check('issue DHRN_ISU_DATA(1)', ic === 1);
  check('issue AC_DATA balanced (dr=cr=10000)', ib.dr === 10000 && ib.cr === 10000);
  check('outstanding after issue = 10000', os0 === 10000);

  // 90-day interest on 10000 @ 12% = 300
  const int90 = accruedInterest(10000, 12, 90, 360);
  check('accrued interest (90d) = 300', int90 === 300);

  // receipt 1: repay 4000 principal + 300 interest; Dr CASH 4300 / Cr DHRN 4000 / Cr INTINC 300
  const r1 = await receiveDhrn(prisma, {
    scope: { ...scope, coBook: 'DRC' },
    isuNo: isu.vchNo,
    borrowerAc: 'BORR',
    principalRepaid: 4000,
    interest: int90,
    intPrc: 12,
  });
  const [rc, rb] = await withTenant(prisma, T, async (tx) => [
    await cnt(tx, 'DHRN_REC_DATA', r1.vchNo),
    await bal(tx, r1.vchNo),
  ]);
  check('receipt DHRN_REC_DATA(1)', rc === 1);
  check('receipt AC_DATA balanced (dr=cr=4300)', rb.dr === 4300 && rb.cr === 4300);
  check('outstanding after receipt1 = 6000', r1.outstanding === 6000);

  // over-repay guard
  check(
    'over-repay -> DhrnValidationError',
    (await named(() =>
      receiveDhrn(prisma, {
        scope: { ...scope, coBook: 'DRC' },
        isuNo: isu.vchNo,
        borrowerAc: 'BORR',
        principalRepaid: 99999,
        interest: 0,
      }),
    )) === 'DhrnValidationError',
  );

  // receipt 2: repay remaining 6000
  const r2 = await receiveDhrn(prisma, {
    scope: { ...scope, coBook: 'DRC' },
    isuNo: isu.vchNo,
    borrowerAc: 'BORR',
    principalRepaid: 6000,
    interest: 0,
  });
  check('outstanding after full repayment = 0', r2.outstanding === 0);

  // delete receipt 2 -> outstanding back to 6000 + DELETE_DATA
  await deleteDhrn(prisma, {
    scope: { ...scope, coBook: 'DRC' },
    vchNo: r2.vchNo,
    headerTable: 'DHRN_REC_DATA',
    book: 'DRC',
    vchType: 'DREC',
    deleteUser: 'admin',
  });
  const [osBack, del] = await withTenant(prisma, T, async (tx) => [
    await outstanding(prisma, scope, isu.vchNo),
    await cnt(tx, 'DELETE_DATA', r2.vchNo),
  ]);
  check('after delete receipt2, outstanding = 6000', osBack === 6000);
  check('wrote DELETE_DATA(>=1)', del >= 1);

  await cleanup();
  await prisma.$disconnect();
  console.log(`\nDHRN_E2E pass=${pass} fail=${fail}`);
  if (fail > 0) process.exit(1);
  console.log('DHRN_E2E_PASS');
}
main().catch((e) => {
  console.error(e);
  process.exit(1);
});
