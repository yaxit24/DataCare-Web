import assert from 'node:assert/strict';

/** Shared helpers of the Cash Bank module (RP_CASH_BANK; /reports/cash-bank). Selectors live here; seed A = cashBankSeed.ts. */
export const as = (user, slot) => ({ user, slot, get password() { return process.env.FEATURE_E2E_PASSWORD; } });
export const C = (id, group, kind, source, run, extra = {}) => ({ id: `cash-bank-report.${id}`, group, kind, source, applicable: true, requiredEvidence: ['browser', 'expected'], run, ...extra });
export const blocked = (id, group, reason) => ({ ...C(`${id}.pending`, group, 'read-only', `Playbook ${group}`, async () => ({})), blocked: reason });
export const notApplicable = (id, group, source, reason) => ({ ...C(`${id}.not-applicable`, group, 'read-only', source, async () => ({})), applicable: false, reason });

export const ROUTE = '/reports/cash-bank';
/** The data endpoint: a refill (Enter in Party Code or Book) waits for a response from it. */
export const API = '/api/reports/cash-bank';
/** Column index of each visible column (desktop order, RP_CASH_BANK.cs:3179-3205). */
export const COL = { sr: 0, book: 1, vch: 2, date: 3, party: 4, area: 5, dr: 6, cr: 7, bal: 8, side: 9 };
export const HEADERS = ['Sr', 'Book', 'VchNo', 'Date', 'Party Name', 'Area', 'Dr Amt', 'Cr Amt', 'Bal Amt', 'CrDr'];
/** Codes this module owns; cleanup deletes these codes and the AC_DATA rows whose key starts with CB-. */
const ACCOUNT_CODES = ['00001', '00010', '00101', '00102'];
const BOOK_CODES = ['001', '002', 'CON'];

export const field = (page, name) => page.getByLabel(name, { exact: true });
const grid = (page) => page.locator('table.grid');
const exec = (ctx, sql, ...params) => ctx.owner.$executeRawUnsafe(sql, ctx.tenantId, ...params);
/** Company year, the same rule as the ledger module. */
const yearOf = () => { const n = new Date(); const s = n.getMonth() + 1 >= 4 ? n.getFullYear() : n.getFullYear() - 1; return `${s}-${s + 1}`; };

export async function readHeaders(page) {
  return (await grid(page).locator('thead th').allInnerTexts()).map((t) => t.trim());
}

/** Body rows as arrays of trimmed cell texts (index with COL). The opening row is first, the totals row last. */
export async function readGrid(page) {
  await grid(page).waitFor();
  const rows = await grid(page).locator('tbody tr').all();
  return Promise.all(rows.map(async (r) => (await r.locator('td').allInnerTexts()).map((t) => t.trim())));
}

/** assertRow(row, { book: 'Op Balance', dr: '7,500.00' }) checks the named columns only. */
export function assertRow(row, spec) {
  for (const [name, value] of Object.entries(spec)) assert.equal(row[COL[name]], value, `${name} of [${row.join('|')}]`);
}

/** Enter in a field refills the grid; waits for the data response. */
export async function refillBy(page, fieldName) {
  await Promise.all([page.waitForResponse((r) => new URL(r.url()).pathname.startsWith(API)), field(page, fieldName).press('Enter')]);
}

/** Opens the report, sets the dates, account and book; Enter in the last filled field refills the grid. */
export async function openReport(page, { from = '01/11/2026', to = '30/11/2026', acCode, bookCode } = {}) {
  await page.goto(ROUTE);
  await field(page, 'Party Code').waitFor();
  await field(page, 'From').fill(from);
  await field(page, 'To').fill(to);
  if (acCode !== undefined) await field(page, 'Party Code').fill(acCode);
  if (bookCode !== undefined) await field(page, 'Book').fill(bookCode);
  await refillBy(page, bookCode !== undefined ? 'Book' : 'Party Code');
}

/** Enter on an unknown Party Code opens the account help list as a modal dialog. */
export async function openAccountHelp(page) {
  await openReport(page, { acCode: '99999' });
  return page.getByRole('dialog').waitFor().then(() => page.getByRole('dialog'));
}

async function cleanCase(ctx) {
  await exec(ctx, `DELETE FROM "AC_DATA" WHERE tenant_id=$1 AND "LEDR_KEY" LIKE 'CB-%'`);
  await exec(ctx, `DELETE FROM "SL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='SL' AND "VCH_NO"='6' AND "AC_NAME"='PARTY ALPHA'`);
  await exec(ctx, `DELETE FROM "BOOK_DATA" WHERE tenant_id=$1 AND "CO_BOOK" = ANY($2::text[])`, BOOK_CODES);
  await exec(ctx, `DELETE FROM "AC_MAST" WHERE tenant_id=$1 AND "AC_CODE" = ANY($2::text[])`, ACCOUNT_CODES);
}

/** Seed A (cases.md 638 to 673). Voucher 7 is one line with both amounts: AC_DATA has a unique index on LEDR_KEY
 * (migration 20260801160000_ledger_key_uniqueness), so two lines cannot share a key. The grid result is the same. */
const SEED_A = [
  { key: 'L1', account: '00001', book: '001', vch: '1', date: '2026-10-10', dr: 10000, cp: '00101' },
  { key: 'L2', account: '00001', book: '002', vch: '2', date: '2026-10-20', cr: 2500, cp: '00102' },
  { key: 'R1', account: '00001', book: '001', vch: '3', date: '2026-11-05', dr: 4000, cp: '00101' },
  { key: 'R2', account: '00001', book: '002', vch: '4', date: '2026-11-12', cr: 1500, cp: '00102' },
  { key: 'R3', account: '00001', book: 'CON', vch: '5', date: '2026-11-20', cr: 1000, cp: '00010' },
  { key: 'R4', account: '00001', book: '001', vch: '7', date: '2026-11-22', cr: 500, dr: 500, cp: '00101' },
  { key: 'R5', account: '00001', book: 'SL', vch: '6', date: '2026-11-25', dr: 2000, cp: '00102' },
  { key: 'L8', account: '00001', book: '001', vch: '8', date: '2026-12-02', dr: 999, cp: '00101' },
  { key: 'L5b', account: '00010', book: 'CON', vch: '5', date: '2026-11-20', dr: 1000, cp: '00001' },
];
const VARIANTS = {
  'date-boundary': [{ key: 'L9', account: '00001', book: '001', vch: '9', date: '2026-11-01', dr: 100, cp: '00101' }],
  'cr-side': [{ key: 'L10', account: '00001', book: '002', vch: '10', date: '2026-10-01', cr: 20000, cp: '00102' }],
};

async function seedLegs(ctx, legs) {
  for (const [i, l] of legs.entries())
    await exec(ctx, `INSERT INTO "AC_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DATE","LEDR_KEY","AC_CODE","LD_CODE","CR_AMT","DR_AMT","DATA_TYPE")
      VALUES($1,'01','01',$2,$3,$4,$5::date,$6,$7,$8,$9,$10,'A')`,
      yearOf(), l.book, l.vch, l.date, `CB-${l.key}-${i}`, l.account, l.cp, l.cr ?? 0, l.dr ?? 0);
}

/** Seed A for the tenant. SL (SALES) already exists in a provisioned company, so it is not inserted. */
async function seedA(ctx) {
  for (const [code, name] of [['00001', 'CASH ON HAND'], ['00010', 'TEST BANK'], ['00101', 'PARTY ALPHA'], ['00102', 'PARTY BETA']])
    await exec(ctx, `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME") VALUES($1,'01','01',$2,$3)`, code, name);
  for (const [code, name] of [['001', 'CASH REC'], ['002', 'CASH PAY'], ['CON', 'CONTRA']])
    await exec(ctx, `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME","MAIN_BOOK","CUR_USE") VALUES($1,'01','01',$2,$3,$3,$3,'Y')`, code, name);
  await seedLegs(ctx, SEED_A);
  await exec(ctx, `INSERT INTO "SL_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","AC_NAME") VALUES($1,'01','01',$2,'SL','6','PARTY ALPHA')`, yearOf());
}

/** Cleans, seeds A (plus an optional variant), runs the case, cleans again. */
export async function withSeed(ctx, fn, variant) {
  await cleanCase(ctx);
  try {
    await seedA(ctx);
    if (variant) await seedLegs(ctx, VARIANTS[variant]);
    return await fn();
  } finally {
    await cleanCase(ctx);
  }
}

/** Cleans, runs the case with no seed data, cleans again. */
export async function withoutSeed(ctx, fn) {
  await cleanCase(ctx);
  try {
    return await fn();
  } finally {
    await cleanCase(ctx);
  }
}
