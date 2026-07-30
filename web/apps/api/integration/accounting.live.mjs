// Tier-2 live accounting datasets (Task 22) as app_user.
// Run: DATABASE_URL=postgresql://app_user:app@127.0.0.1:5433/datacare node apps/api/integration/accounting.live.mjs
import { PrismaClient } from '@prisma/client';
import { withTenant } from '@datacare/db';
import { postReceipt, postPayment } from '../dist/modules/finance/finance.js';
import { trialBalance, accountLedger } from '../dist/modules/accounting/accounting.js';

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

  // seed: receipt (Dr CASH 5000 / Cr CUST 5000), payment (Dr SUPP 3000 / Cr CASH 3000)
  await postReceipt(prisma, {
    scope: { ...scope, coBook: 'RCT' },
    partyAc: 'CUST',
    amount: 5000,
    mode: 'cash',
  });
  await postPayment(prisma, {
    scope: { ...scope, coBook: 'PAY' },
    partyAc: 'SUPP',
    amount: 3000,
    mode: 'cash',
  });

  // trial balance: grand Dr = grand Cr = 8000, balanced
  const tb = await trialBalance(prisma, scope);
  check('trial balance balanced (Dr=Cr)', tb.balanced === true);
  check('grand Dr = 8000', tb.grandDr === 8000);
  check('grand Cr = 8000', tb.grandCr === 8000);
  const cash = tb.accounts.find((a) => a.acCode === 'CASH');
  check('CASH net balance = 2000 (5000 in - 3000 out)', !!cash && cash.balance === 2000);
  const cust = tb.accounts.find((a) => a.acCode === 'CUST');
  check('CUST balance = -5000 (credited)', !!cust && cust.balance === -5000);

  // account ledger for CASH: 2 rows, closing balance 2000
  const led = await accountLedger(prisma, scope, 'CASH');
  check('CASH ledger has 2 rows', led.rows.length === 2);
  check('CASH ledger closing balance = 2000', led.closing === 2000);

  // account ledger for SUPP: closing 3000 (debit)
  const supp = await accountLedger(prisma, scope, 'SUPP');
  check('SUPP ledger closing balance = 3000', supp.closing === 3000);

  await cleanup();
  await prisma.$disconnect();
  console.log(`\nACCOUNTING_E2E pass=${pass} fail=${fail}`);
  if (fail > 0) process.exit(1);
  console.log('ACCOUNTING_E2E_PASS');
}
main().catch((e) => {
  console.error(e);
  process.exit(1);
});
