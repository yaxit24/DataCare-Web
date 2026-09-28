#!/usr/bin/env node
/**
 * FAMILY-LEVEL DAY-BOOK AUDIT — plan item F3.4.
 *
 * WHY THE MODULE-LEVEL SIGNAL WAS NOT GOOD ENOUGH
 * ==============================================
 * `functional-parity-matrix.mjs` reports DAYBOOK by grepping the MODULE that owns a family. A module usually
 * serves several families — `finance.ts` handles contra, cash receipt, cash payment, fine JV and more — so if
 * any one of them projects into the Rojmel, every family in that module is reported as covered.
 *
 * That produced a false positive that survived until a test caught it: contra was marked covered, and the web
 * in fact wrote NONE of the desktop's 74 contra day-book rows. The failure mode is bad in the worst way — it
 * reports coverage where there is none, so nobody looks.
 *
 * This tool instead asks, per POSTING FUNCTION:
 *   1. how many day-book rows does the desktop write for this family, in real data?
 *   2. does the function that posts it actually build day-book rows?
 *
 * (2) is answered by reading the function's own body — from its `export async function` line to the next
 * top-level `export` — and looking for a Rojmel builder call or a `ROJ_MEL_DATA` write inside THAT body.
 * A module-wide grep cannot distinguish siblings; a body-scoped one can.
 *
 * The desktop side is a live query, so the numbers cannot drift out of date silently.
 *
 * USAGE
 *   node apps/api/integration/daybook-family-audit.mjs
 */
import { execFile } from 'node:child_process';
import { readFile } from 'node:fs/promises';
import { dirname, resolve } from 'node:path';
import { fileURLToPath } from 'node:url';
import { promisify } from 'node:util';

const run = promisify(execFile);
const HERE = dirname(fileURLToPath(import.meta.url));
const API = resolve(HERE, '..');

const CONTAINER = process.env.CENSUS_CONTAINER ?? 'dc-mssql';
const DB = process.env.CENSUS_DB ?? 'Live24';
const SA = process.env.CENSUS_SA_PASSWORD ?? 'ParityProbe#2026x';

/**
 * Family → the posting function that must project it, and the desktop MAIN_BOOK to count against.
 * `fn` is the exported entry point; `file` is relative to apps/api/src/modules.
 */
const FAMILIES = [
  { family: 'SALES', mainBook: 'SALES', file: 'sales/sales.ts', fn: 'createSale' },
  { family: 'PURCHASE', mainBook: 'PURCHASE', file: 'purchase/purchase.ts', fn: 'createPurchase' },
  { family: 'CONTRA', mainBook: 'CONTRA', file: 'finance/finance.ts', fn: 'postContra' },
  { family: 'CASH REC', mainBook: 'CASH REC', file: 'finance/finance.ts', fn: 'postReceipt' },
  { family: 'CASH PAY', mainBook: 'CASH PAY', file: 'finance/finance.ts', fn: 'postPayment' },
  { family: 'BANK REC', mainBook: 'BANK REC', file: 'finance/finance.ts', fn: 'postReceipt' },
  { family: 'BANK PAY', mainBook: 'BANK PAY', file: 'finance/finance.ts', fn: 'postPayment' },
  { family: 'FINE JV', mainBook: 'FINE JV', file: 'finance/fineJv.ts', fn: 'postFineJv' },
  { family: 'RATE CUT', mainBook: 'RATE CUT', file: 'sales/rateCut.ts', fn: 'postRateCut' },
  { family: 'WH SALES', mainBook: 'WH SALES', file: 'sales/rateCut.ts', fn: 'postRateCut' },
  {
    family: 'SALES ORDER',
    mainBook: 'SALES ORDER',
    file: 'sales/salesOrder.ts',
    fn: 'createSalesOrder',
  },
  {
    family: 'MEMB ENTRY',
    mainBook: 'MEMB ENTRY',
    file: 'membership/scheme.ts',
    fn: 'schemeInstallment',
  },
  {
    family: 'MEMB ADJUST',
    mainBook: 'MEMB ADJUST',
    file: 'membership/scheme.ts',
    fn: 'schemeMaturity',
  },
  {
    family: 'KARIGAR RECEIPT',
    mainBook: 'KARIGAR RECEIPT',
    file: 'manufacturing/karigar.ts',
    fn: 'receiveKarigar',
  },
  {
    family: 'KARIGAR ISSUE',
    mainBook: 'KARIGAR ISSUE',
    file: 'manufacturing/karigar.ts',
    fn: 'issueKarigar',
  },
  {
    family: 'SALES RETURNE',
    mainBook: 'SALES RETURNE',
    file: 'sales/salesReturn.ts',
    fn: 'createSaleReturn',
  },
  {
    family: 'LABOUR WORK',
    mainBook: 'LABOUR WORK',
    file: 'sales/labourInvoice.ts',
    fn: 'createLabourInvoice',
  },
  {
    family: 'OTH INC',
    mainBook: 'OTH INC',
    file: 'purchase/otherCommission.ts',
    fn: 'saveOtherCommission',
  },
  {
    family: 'ORDER CANCEL',
    mainBook: 'ORDER CANCEL',
    file: 'sales/salesOrder.ts',
    fn: 'cancelSalesOrder',
  },
  { family: 'BILL REC', mainBook: 'BILL REC', file: 'finance/billToBill.ts', fn: 'settleBills' },
];

/** Any of these inside a function body counts as projecting the day book. */
const PROJECTS = /build[A-Za-z]*Rojmel\(|'ROJ_MEL_DATA'|"ROJ_MEL_DATA"/;

/**
 * Every function body in a file, keyed by name — including private helpers.
 *
 * Needed because the projection is almost never in the exported entry point: sale builds it in
 * `writeSaleTx`, purchase in `writePurchaseTx`, scheme in `postMemberEntry`, fine JV in a local `write`.
 * An entry-only scan reported all four as NOT projecting — a false NEGATIVE, the mirror of the module-wide
 * grep's false positive. Both were wrong for the same underlying reason: the unit of analysis was not the
 * call graph.
 */
function functionBodies(source) {
  const decl =
    /^(?:export\s+)?(?:async\s+)?function\s+([A-Za-z_$][\w$]*)|^(?:export\s+)?const\s+([A-Za-z_$][\w$]*)\s*=\s*(?:async\s*)?\(/gm;
  const marks = [];
  for (let m; (m = decl.exec(source));) marks.push({ name: m[1] ?? m[2], at: m.index });
  const out = new Map();
  marks.forEach((mk, i) => {
    const end = i + 1 < marks.length ? marks[i + 1].at : source.length;
    out.set(mk.name, source.slice(mk.at, end));
  });
  return out;
}

/**
 * Does `fn`, or anything it calls within the same file, project the day book?
 *
 * Transitive within the module only. Cross-module helpers are not followed, which is deliberate: a shared
 * helper that writes ROJ_MEL_DATA for somebody else is exactly the false positive this tool exists to avoid.
 */
function projectsDayBook(bodies, fn, seen = new Set()) {
  if (seen.has(fn)) return false;
  seen.add(fn);
  const body = bodies.get(fn);
  if (body === undefined) return false;
  if (PROJECTS.test(body)) return true;
  for (const name of bodies.keys()) {
    if (name === fn || seen.has(name)) continue;
    // A call to a sibling defined in this same file.
    if (new RegExp(`\\b${name}\\s*\\(`).test(body) && projectsDayBook(bodies, name, seen))
      return true;
  }
  return false;
}

async function desktopRowsByMainBook() {
  const q =
    "SET NOCOUNT ON; SELECT ISNULL(b.MAIN_BOOK,'')+'\u0001'+CAST(COUNT(*) AS varchar) " +
    'FROM ROJ_MEL_DATA m JOIN BOOK_DATA b ON b.CO_BOOK=m.CO_BOOK AND b.CO_CODE=m.CO_CODE ' +
    "WHERE ISNULL(b.MAIN_BOOK,'')<>'' GROUP BY b.MAIN_BOOK";
  const { stdout } = await run(
    'docker',
    [
      'exec',
      CONTAINER,
      '/opt/mssql-tools18/bin/sqlcmd',
      '-S',
      'localhost',
      '-U',
      'sa',
      '-P',
      SA,
      '-C',
      '-W',
      '-h',
      '-1',
      '-d',
      DB,
      '-Q',
      q,
    ],
    { maxBuffer: 16 * 1024 * 1024 },
  );
  const out = new Map();
  let total = 0;
  for (const l of stdout.split('\n')) {
    const [name, n] = l.replace(/\r$/, '').split('\u0001');
    if (!name || !n) continue;
    out.set(name.trim(), Number(n));
    total += Number(n);
  }
  if (!out.size)
    throw new Error('no desktop rows read — is the container up? docker ps | grep ' + CONTAINER);
  return { byBook: out, total };
}

async function main() {
  const { byBook, total } = await desktopRowsByMainBook();
  const sources = new Map();
  const rows = [];

  for (const f of FAMILIES) {
    if (!sources.has(f.file)) {
      sources.set(
        f.file,
        await readFile(resolve(API, 'src/modules', f.file), 'utf8').catch(() => ''),
      );
    }
    const src = sources.get(f.file);
    const bodies = src ? functionBodies(src) : new Map();
    const found = bodies.has(f.fn);
    rows.push({
      family: f.family,
      desktopRows: byBook.get(f.mainBook) ?? 0,
      entry: `${f.file}:${f.fn}`,
      found,
      projects: found && projectsDayBook(bodies, f.fn),
    });
  }

  rows.sort((a, b) => b.desktopRows - a.desktopRows);
  console.log('family              desktop rows   projects   posting entry point');
  console.log('------------------- ------------   --------   -------------------');
  let covered = 0;
  let uncovered = 0;
  for (const r of rows) {
    const mark = !r.found ? 'MISSING?' : r.projects ? 'yes' : 'NO';
    if (r.projects) covered += r.desktopRows;
    else uncovered += r.desktopRows;
    console.log(
      `${r.family.padEnd(19)} ${String(r.desktopRows).padStart(12)}   ${mark.padEnd(8)}   ${r.entry}`,
    );
  }

  const listed = rows.reduce((n, r) => n + r.desktopRows, 0);
  console.log(
    `\nday-book rows covered by a projecting family: ${covered} of ${listed} listed ` +
      `(${((covered / listed) * 100).toFixed(1)}%)`,
  );
  console.log(`  not projected: ${uncovered}`);
  console.log(`  desktop total across all books: ${total} (listed families cover ${listed})`);
  const gaps = rows.filter((r) => !r.projects && r.desktopRows > 0);
  if (gaps.length) {
    console.log('\nFAMILIES WITH DESKTOP DAY-BOOK ROWS AND NO PROJECTION:');
    for (const g of gaps)
      console.log(`  ${String(g.desktopRows).padStart(5)}  ${g.family}  (${g.entry})`);
  }
  console.log(gaps.length ? '\nDAYBOOK_AUDIT_GAPS' : '\nDAYBOOK_AUDIT_OK');
}

main().catch((e) => {
  console.error('DAYBOOK_AUDIT_FAIL', e?.message ?? e);
  process.exit(1);
});
