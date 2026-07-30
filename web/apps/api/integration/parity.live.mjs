// Tier-2 live parity runner (Task 30): deterministic golden vectors + a live tie-in proving the
// posted ledger matches the billTotals golden vector. Run:
// DATABASE_URL=postgresql://app_user:app@127.0.0.1:5433/datacare node apps/api/integration/parity.live.mjs
import { PrismaClient } from '@prisma/client';
import { withTenant } from '@datacare/db';
import { runParity } from '../dist/modules/parity/golden.js';
import { createSale } from '../dist/modules/sales/sales.js';

const prisma = new PrismaClient();
const T = 'e2e';
const scope = { tenantId: T, coCode: '01', lcCode: '01', coYear: '2024', coBook: 'SAL' };
let pass = 0,
  fail = 0;
const check = (n, c) => {
  c ? (pass++, console.log('  ok  ' + n)) : (fail++, console.log('  FAIL ' + n));
};

async function cleanup() {
  await withTenant(prisma, T, async (tx) => {
    for (const t of ['SL_DATA', 'SL_DETL', 'SL_IDTL', 'AC_DATA', 'SRNO_MAST']) {
      await tx.$executeRawUnsafe(`DELETE FROM "${t}" WHERE "CO_CODE"=$1`, '01');
    }
  });
}

async function main() {
  await cleanup();

  // (a) deterministic golden-vector gate
  const r = runParity();
  for (const x of r.results)
    if (!x.ok)
      console.log(
        '  FAIL vector',
        x.name,
        'got',
        JSON.stringify(x.actual),
        'want',
        JSON.stringify(x.expected),
      );
  check(`golden vectors all pass (${r.passed}/${r.total})`, r.failed === 0);

  // (b) live tie-in: a posted sale's ledger must equal the billTotals golden vector (1030, balanced)
  const sale = await createSale(
    prisma,
    { scope, acCode: 'CUST1', taxRatePct: 3, interState: false },
    [{ itCode: 'GOLD', metalAmount: 1000 }],
  );
  const bal = await withTenant(prisma, T, async (tx) => {
    const q = await tx.$queryRawUnsafe(
      `SELECT coalesce(sum("DR_AMT"),0)::float AS dr, coalesce(sum("CR_AMT"),0)::float AS cr FROM "AC_DATA" WHERE "VCH_NO"=$1 AND "CO_CODE"=$2`,
      String(sale.vchNo),
      '01',
    );
    return q[0];
  });
  check('live sale total matches vector (1030)', sale.totals.total === 1030);
  check('live ledger balanced & equals total (Dr=Cr=1030)', bal.dr === 1030 && bal.cr === 1030);

  await cleanup();
  await prisma.$disconnect();
  console.log(`\nPARITY_E2E pass=${pass} fail=${fail} (golden ${r.passed}/${r.total})`);
  if (fail > 0) process.exit(1);
  console.log('PARITY_E2E_PASS');
}
main().catch((e) => {
  console.error(e);
  process.exit(1);
});
