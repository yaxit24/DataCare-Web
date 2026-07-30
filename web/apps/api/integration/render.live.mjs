// Tier-2 live report rendering (Task 28) as app_user — HTML from live data -> PDF (fake renderer).
// Also probes the real Playwright renderer (reports available/blocked; not a failure either way).
// Run: DATABASE_URL=postgresql://app_user:app@127.0.0.1:5433/datacare node apps/api/integration/render.live.mjs
import { PrismaClient } from '@prisma/client';
import { withTenant } from '@datacare/db';
import { createSale } from '../dist/modules/sales/sales.js';
import { salesRegister } from '../dist/modules/reports/reports.js';
import {
  renderRegisterHtml,
  renderToPdf,
  FakePdfRenderer,
  PlaywrightPdfRenderer,
} from '../dist/modules/reports/render.js';

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
    for (const t of ['SL_DATA', 'SL_DETL', 'SL_IDTL', 'AC_DATA', 'SRNO_MAST']) {
      await tx.$executeRawUnsafe(`DELETE FROM "${t}" WHERE "CO_CODE"=$1`, '01');
    }
  });
}

async function main() {
  await cleanup();

  await createSale(
    prisma,
    {
      scope: { ...scope, coBook: 'SAL' },
      acCode: 'CUST1',
      taxRatePct: 3,
      interState: false,
      billNo: 'INV/1',
    },
    [{ itCode: 'GOLD', metalAmount: 1000 }],
  );
  await createSale(
    prisma,
    {
      scope: { ...scope, coBook: 'SAL' },
      acCode: 'CUST2',
      taxRatePct: 3,
      interState: true,
      billNo: 'INV/2',
    },
    [{ itCode: 'GOLD', metalAmount: 2000 }],
  );

  const reg = await salesRegister(prisma, scope);
  const html = renderRegisterHtml('Sales Register', reg);
  check(
    'HTML built from live register (2 rows)',
    reg.rows.length === 2 && html.includes('Sales Register'),
  );
  check('HTML contains the grand total 3,090.00', html.includes('3,090.00'));

  const pdf = await renderToPdf(html, new FakePdfRenderer());
  check('fake renderer -> %PDF bytes', pdf.subarray(0, 5).toString() === '%PDF-');
  check('PDF non-empty', pdf.length > 50);

  // probe the real renderer; available OR cleanly unavailable both acceptable (documents env)
  let real = 'UNAVAILABLE';
  try {
    const buf = await new PlaywrightPdfRenderer().render(html);
    real = buf.subarray(0, 5).toString() === '%PDF-' ? 'AVAILABLE_PDF_OK' : 'AVAILABLE_BAD';
  } catch (e) {
    real =
      e?.name === 'PdfRendererUnavailableError'
        ? 'UNAVAILABLE_GUARDED'
        : 'ERROR:' + (e?.name ?? 'unknown');
  }
  console.log('  ..  real Playwright renderer:', real);
  check(
    'real renderer resolves to a known state (PDF or guarded-unavailable)',
    real === 'AVAILABLE_PDF_OK' || real === 'UNAVAILABLE_GUARDED',
  );

  await cleanup();
  await prisma.$disconnect();
  console.log(`\nRENDER_E2E pass=${pass} fail=${fail}`);
  if (fail > 0) process.exit(1);
  console.log('RENDER_E2E_PASS');
}
main().catch((e) => {
  console.error(e);
  process.exit(1);
});
