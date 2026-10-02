// Tier-2 live e-invoice IRN (Task 26) as app_user — uses a FAKE GSP transport (no network).
// Run: DATABASE_URL=postgresql://app_user:app@127.0.0.1:5433/datacare node apps/api/integration/einvoice.live.mjs
import { PrismaClient } from '@datacare/db';
import { withTenant } from '@datacare/db';
import { createSale } from '../dist/modules/sales/sales.js';
import { buildIrnPayload, submitIrn, FakeIrnTransport } from '../dist/modules/einvoice/einvoice.js';

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
    for (const t of ['SL_DATA', 'SL_DETL', 'SL_IDTL', 'AC_DATA', 'E_DATA', 'SRNO_MAST']) {
      await tx.$executeRawUnsafe(`DELETE FROM "${t}" WHERE "CO_CODE"=$1`, '01');
    }
  });
}

async function main() {
  await cleanup();

  // a B2B inter-state sale: taxable 1000 @3% -> IGST 30, total 1030
  const sale = await createSale(
    prisma,
    { scope, acCode: 'REGBUY', taxRatePct: 3, interState: true, billNo: 'INV/1' },
    [{ itCode: 'GOLD', metalAmount: 1000 }],
  );
  check('sale total 1030', sale.totals.total === 1030);

  const payload = buildIrnPayload({
    seller: { gstin: '24AACCC1596Q002', lglNm: 'Jewel Co', stcd: '24' },
    buyer: { gstin: '27ALOPV4774H2ZF', lglNm: 'Reg Buyer', stcd: '27' },
    sale: {
      billNo: 'INV/1',
      vchDate: new Date(),
      interState: true,
      roundOff: sale.totals.roundOff,
    },
    items: [
      {
        desc: 'GOLD 916',
        hsn: '711319',
        qty: 1,
        unitPrice: 1000,
        assAmt: sale.totals.taxable,
        gstRt: 3,
        igst: sale.totals.igst,
      },
    ],
  });
  check('payload TotInvVal = 1030', payload.ValDtls.TotInvVal === 1030);
  check('payload IgstVal = 30', payload.ValDtls.IgstVal === 30);

  const res = await submitIrn(prisma, scope, {
    vchNo: sale.vchNo,
    payload,
    transport: new FakeIrnTransport(),
  });
  check('IRN returned (64 chars)', res.Irn.length === 64);

  const { sl, e } = await withTenant(prisma, T, async (tx) => ({
    sl: await tx.$queryRawUnsafe(
      `SELECT "IRN_NO" AS irn, "ACK_NO" AS ack FROM "SL_DATA" WHERE "VCH_NO"=$1 AND "CO_CODE"=$2`,
      String(sale.vchNo),
      '01',
    ),
    e: await tx.$queryRawUnsafe(
      `SELECT "IRN_NO" AS irn, "QR_DATA" AS qr FROM "E_DATA" WHERE "VCH_NO"=$1 AND "CO_CODE"=$2`,
      String(sale.vchNo),
      '01',
    ),
  }));
  check('SL_DATA.IRN_NO stored', sl[0] && sl[0].irn === res.Irn);
  check('SL_DATA.ACK_NO stored', sl[0] && !!sl[0].ack);
  check('E_DATA row written with IRN + QR', e[0] && e[0].irn === res.Irn && !!e[0].qr);

  await cleanup();
  await prisma.$disconnect();
  console.log(`\nEINVOICE_E2E pass=${pass} fail=${fail}`);
  if (fail > 0) process.exit(1);
  console.log('EINVOICE_E2E_PASS');
}
main().catch((e) => {
  console.error(e);
  process.exit(1);
});
