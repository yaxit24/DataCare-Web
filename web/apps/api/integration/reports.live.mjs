// Tier-2 live report datasets (Task 27) as app_user.
// Run: DATABASE_URL=postgresql://app_user:app@127.0.0.1:5433/datacare node apps/api/integration/reports.live.mjs
import { PrismaClient } from '@prisma/client';
import { withTenant } from '@datacare/db';
import { createSale } from '../dist/modules/sales/sales.js';
import { createPurchase } from '../dist/modules/purchase/purchase.js';
import {
  salesRegister,
  purchaseRegister,
  dayBook,
  trialBalance,
} from '../dist/modules/reports/reports.js';

const prisma = new PrismaClient();
const T = 'e2e';
const scope = { tenantId: T, coCode: '01', lcCode: '01', coYear: '2024' };
let pass = 0,
  fail = 0;
const check = (n, c) => {
  c ? (pass++, console.log('  ok  ' + n)) : (fail++, console.log('  FAIL ' + n));
};

async function cleanup() {
  await withTenant(prisma, T, async (tx) => {
    for (const t of [
      'SL_DATA',
      'SL_DETL',
      'SL_IDTL',
      'PR_DATA',
      'PR_DETL',
      'AC_DATA',
      'TAG_STOCK',
      'SRNO_MAST',
    ]) {
      await tx.$executeRawUnsafe(`DELETE FROM "${t}" WHERE "CO_CODE"=$1`, '01');
    }
  });
}

async function main() {
  await cleanup();

  // seed: 2 sales (intra 1000@3%, inter 2000@3%) + 1 purchase (1000@3%)
  await createSale(
    prisma,
    { scope: { ...scope, coBook: 'SAL' }, acCode: 'CUST1', taxRatePct: 3, interState: false },
    [{ itCode: 'GOLD', metalAmount: 1000 }],
  );
  await createSale(
    prisma,
    { scope: { ...scope, coBook: 'SAL' }, acCode: 'CUST2', taxRatePct: 3, interState: true },
    [{ itCode: 'GOLD', metalAmount: 2000 }],
  );
  await createPurchase(
    prisma,
    { scope: { ...scope, coBook: 'PUR' }, acCode: 'SUPP1', taxRatePct: 3, interState: false },
    [{ itCode: 'GOLD', netWt: 10, touch: 100, rate: 100 }],
  );

  // sales register
  const sr = await salesRegister(prisma, scope);
  check('sales register: 2 rows', sr.rows.length === 2);
  check('sales register taxable total = 3000', sr.totals.netAmt === 3000);
  check('sales register total = 3090', sr.totals.totAmt === 3090);
  check('sales register cgst=15 (intra only)', sr.totals.cgst === 15);
  check('sales register igst=60 (inter only)', sr.totals.igst === 60);

  // purchase register
  const pr = await purchaseRegister(prisma, scope);
  check('purchase register: 1 row', pr.rows.length === 1);
  check('purchase register total = 1030', pr.totals.totAmt === 1030);

  // day-book (rojmel): all AC_DATA movements, Dr=Cr
  const db = await dayBook(prisma, scope);
  check('day-book has rows', db.rows.length >= 6); // 3 vouchers x ~2-3 lines
  check('day-book balanced (Dr=Cr)', db.totals.balanced === true);

  // cross-check: trial balance still balances over the seeded set
  const tb = await trialBalance(prisma, scope);
  check('trial balance balanced', tb.balanced === true);

  await cleanup();
  await prisma.$disconnect();
  console.log(`\nREPORTS_E2E pass=${pass} fail=${fail}`);
  if (fail > 0) process.exit(1);
  console.log('REPORTS_E2E_PASS');
}
main().catch((e) => {
  console.error(e);
  process.exit(1);
});
