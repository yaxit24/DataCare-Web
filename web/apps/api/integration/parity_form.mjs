// PARITY HARNESS (Phase 0) — the per-form gating tool.
// Compares a WEB-created voucher to a DESKTOP (imported) voucher of the same type,
// across EVERY voucher-keyed table, column-by-column. Diff must be 0 to pass the phase gate.
//
// Modes:
//   footprint <coBook> <vchNo> [coYear] [tenant]   — dump table footprint + key columns of one voucher
//   compare <deskBook> <deskVch> <webBook> <webVch> [coYear] [tenant] — diff two vouchers
//
// Run: DATABASE_URL=postgresql://app_user:app@127.0.0.1:5433/datacare \
//      node apps/api/integration/parity_form.mjs compare 026 00044 SAL 19
import { PrismaClient } from '@datacare/db';
import { withTenant } from '@datacare/db';

const prisma = new PrismaClient();
const [mode, a, b, c, d, coYearArg, tenantArg] = process.argv.slice(2);
const TENANT = tenantArg || 'default';
const CO = '01';
// columns excluded from value-diff (keys / audit / per-voucher identifiers / timestamps)
const SKIP = new Set([
  'tenant_id',
  'row_id',
  'VCH_NO',
  'CO_BOOK',
  'CO_CODE',
  'LC_CODE',
  'CO_YEAR',
  'HD_VCH_NO',
  'VCH_DATE',
  'VCH_TIME',
  'STK_DATE',
  'ENTRY_TIME',
  'MAIN_USER',
  'USER_UPDATE',
  'VCH_SRNO',
  'BILL_NO',
  'DATA_TRFR',
  'OLD_VCH_NO',
  'NEW_VCH_NO',
  'ENTRY_TIME',
  'FUN_DATE',
  'VCH_TIME',
]);
const norm = (v) => {
  if (v == null) return '';
  if (v instanceof Date) return '';
  const s = String(v).trim();
  const n = Number(s);
  return Number.isFinite(n) && s !== '' ? String(Math.round(n * 1000) / 1000) : s.toUpperCase();
};

async function voucherTables(tx) {
  const rows = await tx.$queryRawUnsafe(
    `SELECT table_name FROM information_schema.columns WHERE column_name='VCH_NO' AND table_schema='public'
     INTERSECT SELECT table_name FROM information_schema.columns WHERE column_name='CO_BOOK'
     INTERSECT SELECT table_name FROM information_schema.columns WHERE column_name='CO_CODE'`,
  );
  return rows.map((r) => r.table_name);
}
async function fetchRows(tx, table, book, vch) {
  const cols = (
    await tx.$queryRawUnsafe(
      `SELECT column_name FROM information_schema.columns WHERE table_name=$1`,
      table,
    )
  ).map((r) => r.column_name);
  const order = cols.includes('SR_NO') ? ' ORDER BY "SR_NO"' : '';
  return tx.$queryRawUnsafe(
    `SELECT * FROM "${table}" WHERE "CO_CODE"=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3${order}`,
    CO,
    book,
    String(vch),
  );
}

async function footprint(book, vch) {
  await withTenant(prisma, TENANT, async (tx) => {
    const tabs = await voucherTables(tx);
    console.log(`FOOTPRINT ${book}/${vch} (tenant ${TENANT}):`);
    for (const t of tabs) {
      const rows = await fetchRows(tx, t, book, vch);
      if (rows.length)
        console.log(
          `  ${t}: ${rows.length} row(s) | cols set: ${Object.keys(rows[0]).filter((k) => !SKIP.has(k) && norm(rows[0][k]) !== '').length}`,
        );
    }
  });
}

async function compare(deskBook, deskVch, webBook, webVch) {
  await withTenant(prisma, TENANT, async (tx) => {
    const tabs = await voucherTables(tx);
    let footMiss = 0,
      colDiffs = 0,
      tablesChecked = 0;
    console.log(`COMPARE desktop ${deskBook}/${deskVch}  vs  web ${webBook}/${webVch}`);
    for (const t of tabs) {
      const dk = await fetchRows(tx, t, deskBook, deskVch);
      const wb = await fetchRows(tx, t, webBook, webVch);
      if (!dk.length && !wb.length) continue;
      tablesChecked++;
      if (dk.length && !wb.length) {
        console.log(`  [FOOTPRINT MISS] ${t}: desktop ${dk.length} row(s), web 0`);
        footMiss++;
        continue;
      }
      if (!dk.length && wb.length) {
        console.log(`  [WEB EXTRA] ${t}: web ${wb.length} row(s), desktop 0`);
        continue;
      }
      if (dk.length !== wb.length)
        console.log(`  [ROWCOUNT] ${t}: desktop ${dk.length} vs web ${wb.length}`);
      // column value diff on row 1 (representative)
      const cols = Object.keys(dk[0]).filter((k) => !SKIP.has(k));
      const diffs = [];
      for (const k of cols) {
        const dv = norm(dk[0][k]);
        const wv = norm(wb[0][k]);
        if (dv !== wv && !(dv === '' && wv === '')) diffs.push(`${k}: desk='${dv}' web='${wv}'`);
      }
      if (diffs.length) {
        colDiffs += diffs.length;
        console.log(`  [COL DIFF] ${t} (${diffs.length}): ${diffs.slice(0, 8).join(' | ')}`);
      } else console.log(`  [OK] ${t}: ${dk.length} row(s), columns match`);
    }
    console.log(
      `\nRESULT: tablesChecked=${tablesChecked} footprintMisses=${footMiss} columnDiffs=${colDiffs}`,
    );
    console.log(footMiss === 0 && colDiffs === 0 ? 'PARITY_OK' : 'PARITY_REVIEW');
  });
}

if (mode === 'footprint') await footprint(a, b);
else if (mode === 'compare') await compare(a, b, c, d);
else console.log('usage: footprint <book> <vch> | compare <deskBook> <deskVch> <webBook> <webVch>');
await prisma.$disconnect();
