// Tier-2 live voucher-numbering concurrency (Task 16) as app_user.
// Run: DATABASE_URL=postgresql://app_user:app@127.0.0.1:5433/datacare node apps/api/integration/numbering.live.mjs
import { PrismaClient } from '@prisma/client';
import { withTenant } from '@datacare/db';
import { nextVoucherNo } from '../dist/modules/vouchers/numbering.js';

const prisma = new PrismaClient();
const T = 'e2e';
const scope = { tenantId: T, coCode: '01', lcCode: '01', coYear: '2024', coBook: 'SAL' };
let pass = 0,
  fail = 0;
const check = (n, c) => {
  c ? (pass++, console.log('  ok  ' + n)) : (fail++, console.log('  FAIL ' + n));
};

async function main() {
  await withTenant(prisma, T, (tx) =>
    tx.$executeRawUnsafe('DELETE FROM "SRNO_MAST" WHERE "CO_CODE"=$1', '01'),
  );

  // N concurrent allocations -> N distinct sequential numbers (Req 9.2/9.3)
  const N = 8;
  const results = await Promise.all(Array.from({ length: N }, () => nextVoucherNo(prisma, scope)));
  const sorted = [...results].sort((a, b) => a - b);
  const distinct = new Set(results);
  check(`concurrent: ${N} distinct numbers`, distinct.size === N);
  check(
    `concurrent: gap-free sequential 1..${N}`,
    JSON.stringify(sorted) === JSON.stringify(Array.from({ length: N }, (_, i) => i + 1)),
  );

  // next sequential call continues
  const nextOne = await nextVoucherNo(prisma, scope);
  check(`sequential continues at ${N + 1}`, nextOne === N + 1);

  await withTenant(prisma, T, (tx) =>
    tx.$executeRawUnsafe('DELETE FROM "SRNO_MAST" WHERE "CO_CODE"=$1', '01'),
  );
  await prisma.$disconnect();
  console.log(`\nNUMBERING_E2E pass=${pass} fail=${fail}`);
  if (fail > 0) process.exit(1);
  console.log('NUMBERING_E2E_PASS');
}
main().catch((e) => {
  console.error(e);
  process.exit(1);
});
