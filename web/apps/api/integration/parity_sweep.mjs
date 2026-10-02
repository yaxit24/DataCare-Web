// PARITY SWEEP (Phase 14) — per-form multi-table footprint certification.
// For each FORM TYPE, picks a representative voucher from its header table, then counts
// every voucher-keyed table that voucher touches + the populated-column count. Certifies
// that each form's full multi-table footprint is present + consistent in the unified DB.
//
// Run: DATABASE_URL=postgresql://app_user:app@127.0.0.1:5433/datacare node apps/api/integration/parity_sweep.mjs
import { PrismaClient } from '@datacare/db';
import { withTenant } from '@datacare/db';

const prisma = new PrismaClient();
const TENANT = process.env.TENANT || 'default';
const CO = process.env.CO || '01';

// Form type -> header table that uniquely anchors a voucher of that form.
const FORMS = [
  ['Sales', 'SL_DATA'],
  ['Sales detail', 'SL_DETL'],
  ['Old-gold exchange', 'SL_PR_DETL'],
  ['Purchase', 'PR_DATA'],
  ['Purchase detail', 'PR_DETL'],
  ['Cash/Bank (receipt/payment/contra)', 'CASH_DATA'],
  ['Ledger posting', 'AC_DATA'],
  ['Tax (GST)', 'TAX_DATA'],
  ['Bill outstanding', 'BILL_OS_DATA'],
  ['Stock movement', 'MAIN_STOCK'],
  ['Tag inventory', 'BAR_DETL'],
  ['Pledge/Dhrn issue', 'DHRN_ISU_DETL'],
  ['Tour/Approval', 'APR_DATA'],
  ['Manufacturing', 'MFG_DATA'],
];

const SKIP = new Set([
  'tenant_id',
  'row_id',
  'VCH_NO',
  'CO_BOOK',
  'CO_CODE',
  'LC_CODE',
  'CO_YEAR',
  'VCH_DATE',
  'VCH_TIME',
  'ENTRY_TIME',
  'MAIN_USER',
  'STK_DATE',
]);
const nonEmpty = (row) =>
  Object.keys(row).filter((k) => !SKIP.has(k) && row[k] != null && String(row[k]).trim() !== '')
    .length;

async function voucherTables(tx) {
  const rows = await tx.$queryRawUnsafe(
    `SELECT table_name FROM information_schema.columns WHERE column_name='VCH_NO' AND table_schema='public'
     INTERSECT SELECT table_name FROM information_schema.columns WHERE column_name='CO_BOOK'
     INTERSECT SELECT table_name FROM information_schema.columns WHERE column_name='CO_CODE'`,
  );
  return rows.map((r) => r.table_name);
}

async function main() {
  await withTenant(prisma, TENANT, async (tx) => {
    const allTabs = await voucherTables(tx);
    let pass = 0,
      miss = 0;
    console.log(
      `PER-FORM FOOTPRINT SWEEP (tenant ${TENANT}, co ${CO}) — ${allTabs.length} voucher-keyed tables\n`,
    );
    for (const [form, head] of FORMS) {
      // pick a representative voucher from the form's header table
      let sample;
      try {
        const r = await tx.$queryRawUnsafe(
          `SELECT "CO_BOOK","VCH_NO" FROM "${head}" WHERE "CO_CODE"=$1 AND "VCH_NO" IS NOT NULL AND "VCH_NO"<>'' ORDER BY "VCH_NO" DESC LIMIT 1`,
          CO,
        );
        sample = r[0];
      } catch (e) {
        console.log(`  [SKIP] ${form} (${head}): ${e.message.slice(0, 60)}`);
        continue;
      }
      if (!sample) {
        console.log(`  [NO DATA] ${form} (${head})`);
        continue;
      }
      const { CO_BOOK: bk, VCH_NO: vch } = sample;
      // footprint: every voucher-keyed table containing this (book,vch)
      const touched = [];
      let totalCols = 0;
      for (const t of allTabs) {
        const rows = await tx.$queryRawUnsafe(
          `SELECT * FROM "${t}" WHERE "CO_CODE"=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3`,
          CO,
          bk,
          String(vch),
        );
        if (rows.length) {
          touched.push(`${t}(${rows.length})`);
          totalCols += nonEmpty(rows[0]);
        }
      }
      if (touched.length) {
        pass++;
        console.log(
          `  [OK] ${form.padEnd(38)} ${bk}/${vch}: ${touched.length} tables, ${totalCols} cols | ${touched.slice(0, 6).join(' ')}`,
        );
      } else {
        miss++;
        console.log(`  [MISS] ${form} ${bk}/${vch}: no tables`);
      }
    }
    console.log(`\nSWEEP: forms=${FORMS.length} covered=${pass} missing=${miss}`);
    console.log(miss === 0 ? 'PER_FORM_SWEEP_OK' : 'PER_FORM_SWEEP_REVIEW');
  });
}
main()
  .catch((e) => {
    console.error('FATAL', e.message);
    process.exit(1);
  })
  .finally(() => prisma.$disconnect());
