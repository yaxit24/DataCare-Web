// Tier-2 live posting engine (Task 17) as app_user.
// Run: DATABASE_URL=postgresql://app_user:app@127.0.0.1:5433/datacare node apps/api/integration/posting.live.mjs
import { PrismaClient } from '@datacare/db';
import { withTenant } from '@datacare/db';
import {
  postVoucher,
  reverseVoucher,
  assertBalanced,
  UnbalancedError,
} from '../dist/modules/posting/posting.js';

const prisma = new PrismaClient();
const T = 'e2e';
const K = { CO_CODE: '01', LC_CODE: '01', CO_YEAR: '2024', CO_BOOK: 'SAL', VCH_NO: '1' };
let pass = 0,
  fail = 0;
const check = (n, c) => {
  c ? (pass++, console.log('  ok  ' + n)) : (fail++, console.log('  FAIL ' + n));
};
const count = (tx, t) =>
  tx
    .$queryRawUnsafe(
      `SELECT count(*)::int AS n FROM "${t}" WHERE "VCH_NO"=$1 AND "CO_CODE"=$2`,
      '1',
      '01',
    )
    .then((r) => r[0].n);

async function cleanup() {
  await withTenant(prisma, T, async (tx) => {
    for (const t of ['SL_DATA', 'AC_DATA', 'DELETE_DATA'])
      await tx.$executeRawUnsafe(`DELETE FROM "${t}" WHERE "CO_CODE"=$1`, '01');
  });
}

async function main() {
  await cleanup();

  // unbalanced rejected before any write (Req 13.1)
  let unb = 'NONE';
  try {
    assertBalanced([{ DR_AMT: 1000 }, { CR_AMT: 900 }]);
  } catch (e) {
    unb = e.name;
  }
  check('unbalanced -> UnbalancedError', unb === 'UnbalancedError');

  // post a balanced sale voucher: SL_DATA header + 2 AC_DATA lines (Dr customer / Cr sales)
  await postVoucher(prisma, T, {
    ledger: {
      table: 'AC_DATA',
      lines: [
        { ...K, VCH_TYPE: 'SALE', AC_CODE: 'CUST', DR_AMT: 1000, CR_AMT: 0, SIGN: 'D' },
        { ...K, VCH_TYPE: 'SALE', AC_CODE: 'SALES', DR_AMT: 0, CR_AMT: 1000, SIGN: 'C' },
      ],
    },
    writes: [{ table: 'SL_DATA', rows: [{ ...K, NET_AMT: 1000, TOT_AMT: 1000 }] }],
  });
  const [slN, acN] = await withTenant(prisma, T, async (tx) => [
    await count(tx, 'SL_DATA'),
    await count(tx, 'AC_DATA'),
  ]);
  check('posted SL_DATA header (1)', slN === 1);
  check('posted AC_DATA balanced lines (2)', acN === 2);

  // reverse: delete all + DELETE_DATA log
  await reverseVoucher(prisma, T, {
    tables: ['SL_DATA', 'AC_DATA'],
    key: K,
    deleteLog: {
      table: 'DELETE_DATA',
      row: { ...K, VCH_TYPE: 'SALE', VCH_VAL_DR: 1000, VCH_VAL_CR: 1000, DELETE_USER: 'admin' },
    },
  });
  const [slN2, acN2, delN] = await withTenant(prisma, T, async (tx) => [
    await count(tx, 'SL_DATA'),
    await count(tx, 'AC_DATA'),
    await count(tx, 'DELETE_DATA'),
  ]);
  check('reverse removed SL_DATA (0)', slN2 === 0);
  check('reverse removed AC_DATA (0)', acN2 === 0);
  check('reverse wrote DELETE_DATA log (1)', delN === 1);

  await cleanup();
  await prisma.$disconnect();
  console.log(`\nPOSTING_E2E pass=${pass} fail=${fail}`);
  if (fail > 0) process.exit(1);
  console.log('POSTING_E2E_PASS');
}
main().catch((e) => {
  console.error(e);
  process.exit(1);
});
