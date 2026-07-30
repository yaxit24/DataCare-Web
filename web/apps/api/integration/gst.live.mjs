// Tier-2 live GSTR-1 datasets (Task 25) as app_user.
// Run: DATABASE_URL=postgresql://app_user:app@127.0.0.1:5433/datacare node apps/api/integration/gst.live.mjs
import { PrismaClient } from '@prisma/client';
import { withTenant } from '@datacare/db';
import { createSale } from '../dist/modules/sales/sales.js';
import { gstr1 } from '../dist/modules/gst/gst.js';

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
    for (const t of ['SL_DATA', 'SL_DETL', 'SL_IDTL', 'AC_DATA', 'AC_MAST', 'SRNO_MAST']) {
      await tx.$executeRawUnsafe(`DELETE FROM "${t}" WHERE "CO_CODE"=$1`, '01');
    }
  });
}

async function seedAcMast(acCode, name, gstno, state) {
  await withTenant(prisma, T, (tx) =>
    tx.$executeRawUnsafe(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","AC_CODE","AC_NAME","AC_GSTNO","AC_STATE") VALUES ($1,$2,$3,$4,$5,$6)`,
      T,
      '01',
      acCode,
      name,
      gstno,
      state,
    ),
  );
}

async function main() {
  await cleanup();

  // registered buyer (has GSTIN) -> B2B; small B2C buyer (state, no GSTIN) -> B2CS; big inter-state buyer (no master) -> B2CL
  await seedAcMast('REGBUY', 'Registered Buyer', '27ABCDE1234F1Z5', '27');
  await seedAcMast('SMALLB2C', 'Small B2C', null, '27');

  await createSale(prisma, { scope, acCode: 'REGBUY', taxRatePct: 3, interState: false }, [
    { itCode: 'GOLD', metalAmount: 1000 },
  ]); // B2B intra
  await createSale(prisma, { scope, acCode: 'BIGBUY', taxRatePct: 3, interState: true }, [
    { itCode: 'GOLD', metalAmount: 300000 },
  ]); // B2CL inter > 2.5L
  await createSale(prisma, { scope, acCode: 'SMALLB2C', taxRatePct: 3, interState: false }, [
    { itCode: 'GOLD', metalAmount: 500 },
  ]); // B2CS

  const g = await gstr1(prisma, scope, { threshold: 250000, hsnMap: { GOLD: '7113' } });

  check('B2B: 1 invoice (registered)', g.b2b.length === 1 && g.b2b[0].acCode === 'REGBUY');
  check('B2B taxable = 1000', g.b2b[0] && g.b2b[0].taxable === 1000);
  check('B2B carries GSTIN', !!(g.b2b[0] && g.b2b[0].gstin));
  check(
    'B2CL: 1 invoice (inter-state > 2.5L)',
    g.b2cl.length === 1 && g.b2cl[0].acCode === 'BIGBUY',
  );
  check('B2CL invoice value = 309000', g.b2cl[0] && g.b2cl[0].invoiceValue === 309000);
  check('B2CL is IGST (inter-state)', g.b2cl[0] && g.b2cl[0].igst === 9000);
  check('B2CS: 1 summary row', g.b2cs.length === 1);
  check(
    'B2CS state=27 rate=3 taxable=500',
    g.b2cs[0] &&
      g.b2cs[0].stateCode === '27' &&
      g.b2cs[0].ratePct === 3 &&
      g.b2cs[0].taxable === 500,
  );
  check('HSN: 1 row mapped to 7113', g.hsn.length === 1 && g.hsn[0].hsn === '7113');
  check('HSN taxable = 301500 (1000+300000+500)', g.hsn[0] && g.hsn[0].taxable === 301500);
  check('HSN igst = 9000 (the inter-state sale)', g.hsn[0] && g.hsn[0].igst === 9000);

  await cleanup();
  await prisma.$disconnect();
  console.log(`\nGST_E2E pass=${pass} fail=${fail}`);
  if (fail > 0) process.exit(1);
  console.log('GST_E2E_PASS');
}
main().catch((e) => {
  console.error(e);
  process.exit(1);
});
