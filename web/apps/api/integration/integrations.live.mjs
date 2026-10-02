// Tier-2 live integrations (Task 29) as app_user — sale -> templated WhatsApp notify (fake sender)
// + Code39 tag barcode + UPI link, all from live data.
// Run: DATABASE_URL=postgresql://app_user:app@127.0.0.1:5433/datacare node apps/api/integration/integrations.live.mjs
import { PrismaClient } from '@datacare/db';
import { withTenant } from '@datacare/db';
import { createSale } from '../dist/modules/sales/sales.js';
import {
  renderTemplate,
  notify,
  buildUpiUri,
  FakeMessageSender,
} from '../dist/modules/integrations/messaging.js';
import { code39Svg } from '../dist/modules/integrations/barcode.js';

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

  const sale = await createSale(
    prisma,
    {
      scope,
      acCode: 'CUST1',
      acName: 'Asha Jewels',
      taxRatePct: 3,
      interState: false,
      billNo: 'INV/1',
    },
    [{ itCode: 'GOLD', metalAmount: 1000 }],
  );

  // read the saved invoice to build the customer message from live data
  const row = await withTenant(prisma, T, async (tx) => {
    const r = await tx.$queryRawUnsafe(
      `SELECT "AC_NAME" AS party, "BILL_NO" AS bill, "TOT_AMT" AS tot, "MOBILE" AS mobile FROM "SL_DATA" WHERE "VCH_NO"=$1 AND "CO_CODE"=$2`,
      String(sale.vchNo),
      '01',
    );
    return r[0];
  });

  // desktop-style template (CO_SET.CUST_SMS)
  const template = 'Dear {party}, your invoice {bill} for Rs.{total} is ready. Thank you!';
  const body = renderTemplate(template, {
    party: row.party,
    bill: row.bill,
    total: Number(row.tot).toFixed(2),
  });
  check(
    'message body rendered from live sale',
    body.includes('Asha Jewels') && body.includes('1030.00') && body.includes('INV/1'),
  );

  const sender = new FakeMessageSender();
  const res = await notify(sender, {
    to: row.mobile || '+919999999999',
    channel: 'whatsapp',
    body,
  });
  check('notify ok via fake sender', res.ok === true);
  check(
    'sender outbox recorded the message',
    sender.outbox.length === 1 && sender.outbox[0].body.includes('1030.00'),
  );

  // Code39 tag barcode
  const svg = code39Svg('TAG' + sale.vchNo, { withCheck: true });
  check('Code39 barcode SVG generated', svg.startsWith('<svg') && svg.includes('<rect'));

  // UPI collect link for the invoice
  const upi = buildUpiUri({ pa: 'jewelco@upi', pn: 'Jewel Co', am: Number(row.tot), tn: row.bill });
  check(
    'UPI link carries amount 1030.00',
    upi.includes('am=1030.00') && upi.startsWith('upi://pay?'),
  );

  // resilience: a failing sender must not throw
  const bad = {
    async send() {
      throw new Error('whatsapp api 503');
    },
  };
  const r2 = await notify(bad, { to: '+91', channel: 'whatsapp', body });
  check('failing sender -> notify ok:false, no throw', r2.ok === false);

  await cleanup();
  await prisma.$disconnect();
  console.log(`\nINTEGRATIONS_E2E pass=${pass} fail=${fail}`);
  if (fail > 0) process.exit(1);
  console.log('INTEGRATIONS_E2E_PASS');
}
main().catch((e) => {
  console.error(e);
  process.exit(1);
});
