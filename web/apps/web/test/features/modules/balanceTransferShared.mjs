import assert from 'node:assert/strict';
import { purgeYear } from '../harness.mjs';

/**
 * Shared helpers of the Balance TrFr feature modules (balanceTransfer.mjs and the files beside it): the case builders,
 * the Transfer Year seeding that removes everything it created, the dataset button driver and the party seed.
 */
export const as = (user, slot) => ({
  user,
  slot,
  get password() {
    return process.env.FEATURE_E2E_PASSWORD;
  },
});
export const C = (id, group, kind, source, run, extra = {}) => ({
  id: `balance-transfer.${id}`,
  group,
  kind,
  source,
  applicable: true,
  requiredEvidence:
    kind === 'mutation'
      ? ['browser', 'expected', 'database', 'downstream']
      : kind === 'refusal'
        ? ['browser', 'expected', 'database']
        : kind === 'output'
          ? ['browser', 'expected', 'output']
          : ['browser', 'expected'],
  run,
  ...extra,
});
export const notApplicable = (name, group, source, reason) => ({
  ...C(`${name}.not-applicable`, group, 'read-only', source, async () => ({})),
  applicable: false,
  reason,
});

export const PATH = '/company/balance-transfer';
export const CONFIRM = 'Are You Sure To Data Transfer to Next Year ?';
export const COMPLETE = 'Process Are Complete....';
export const NO_YEAR = 'There Are Not Found New Year Please Creat New Year And Try....';
export const LITE = ['Ac Balance', 'Item Stock', 'Tag Stock', 'Sales Order', 'Approval'];
export const NON_LITE = [
  'Scheme',
  'Dhiran',
  'Loan',
  'Bill Os Trfr',
  'Time Ldr Trfr',
  'Jadtar Trfr',
  'Bill Orna Isu',
  'Vp Trfr',
  'Bullion Trfr',
  'Order Traking',
  'Reparing Trfr',
  'Item Lot Trfr',
  'Tag Idtl Trfr',
  'Mfg Trfr',
];
export const PARTY = { code: 'E2EBT1', name: 'E2E BALANCE TRFR PARTY' };
export const ITEM = { code: 'E2EBI', name: 'E2E BT ITEM' };

export const isApi = (r, method, prefix) =>
  r.request().method() === method && new URL(r.url()).pathname.startsWith(`/api${prefix}`);
export const button = (page, name) => page.getByRole('button', { name, exact: true });
export const exec = (ctx, sql, ...params) =>
  ctx.owner.$executeRawUnsafe(sql, ctx.tenantId, ...params);
export const sessionYear = async (page) =>
  (await (await page.request.get('/api/me')).json()).coYear;

/** The year after `coYear` in the same spelling ('2026-2027' → '2027-2028', '2026-27' → '2027-28'). */
export function followingYear(coYear) {
  const [a, b] = String(coYear).split('-');
  const bump = (s) =>
    String(Number(s) + 1)
      .padStart(s.length, '0')
      .slice(-s.length);
  return `${bump(a)}-${bump(b)}`;
}

/**
 * Seeds the Transfer Year (and optionally the one after) in YEAR_MAST for the case and removes it, and every row the
 * carry wrote into it, afterwards. YEAR_MAST is a master: the carry under test is always run through the screen.
 */
export async function withNextYears(ctx, page, count, body) {
  const current = await sessionYear(page);
  const [cur] = await ctx.rows(
    `SELECT "CL_DATE"::date::text cl FROM "YEAR_MAST" WHERE tenant_id=$1 AND "CO_CODE"='01' AND "CO_YEAR"=$2`,
    current,
  );
  const years = [];
  let year = current;
  let op = new Date(`${cur.cl}T00:00:00Z`);
  for (let i = 0; i < count; i += 1) {
    year = followingYear(year);
    op = new Date(op.getTime() + 86_400_000);
    const cl = new Date(op);
    cl.setUTCFullYear(cl.getUTCFullYear() + 1);
    cl.setUTCDate(cl.getUTCDate() - 1);
    const opIso = op.toISOString().slice(0, 10);
    await exec(
      ctx,
      `INSERT INTO "YEAR_MAST"(tenant_id,"CO_CODE","CO_YEAR","OP_DATE","CL_DATE") VALUES ($1,'01',$2,$3,$4::timestamp)`,
      year,
      opIso,
      cl.toISOString().slice(0, 10),
    );
    years.push({ year, opDate: opIso });
    op = cl;
  }
  try {
    return await body({ current, clDate: cur.cl, next: years });
  } finally {
    for (const y of years) {
      // The carry's own rows and anything a case posted in the Transfer Year through the screens.
      await purgeYear(ctx.owner, ctx.tenantId, y.year);
      await exec(ctx, `DELETE FROM "YEAR_MAST" WHERE tenant_id=$1 AND "CO_YEAR"=$2`, y.year);
    }
  }
}

export async function openScreen(page) {
  await Promise.all([
    page.waitForResponse((r) => isApi(r, 'GET', '/balance-transfer')),
    page.goto(PATH),
  ]);
  await page.getByRole('heading', { name: 'Balance TrFr', exact: true }).waitFor();
}

/** Click a dataset button, answer the confirmation, return the dialog text and the response. */
export async function runDataset(page, label, accept = true) {
  const dialogs = [];
  page.removeAllListeners('dialog');
  page.on('dialog', (dialog) => {
    dialogs.push(dialog.message());
    void (accept ? dialog.accept() : dialog.dismiss());
  });
  try {
    if (!accept) {
      await button(page, label).click();
      await page.waitForTimeout(750);
      return { dialogs, response: null };
    }
    const [response] = await Promise.all([
      page.waitForResponse((r) => isApi(r, 'POST', '/balance-transfer/')),
      button(page, label).click(),
    ]);
    return { dialogs, response };
  } finally {
    page.removeAllListeners('dialog');
    page.on('dialog', (dialog) => void dialog.accept());
  }
}

/** A party with two year-N vouchers before the closing date and one after it (cases.md ac.create.footprint). */
export async function seedParty(ctx, current, clDate, party = PARTY, { afterVoucher = true } = {}) {
  // AC_GR '10' and GST type 'L' make the party usable on the Sales Invoice screen; AC_MAIN_GR '1' makes it a party
  // for the carry (BtmSchm.cs:2733, AC_MAIN_GR < '3').
  await exec(
    ctx,
    `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GR","AC_MAIN_GR","AC_GST_TYPE") VALUES ($1,'01','01',$2,$3,'10','1','L')`,
    party.code,
    party.name,
  );
  const after = new Date(`${clDate}T00:00:00Z`);
  after.setUTCDate(after.getUTCDate() + 1);
  for (const [i, cr, dr, date] of [
    [1, 5000, 0, `${current.slice(0, 4)}-06-01`],
    [2, 0, 1200.5, `${current.slice(0, 4)}-07-10`],
    [3, 0, 300.25, clDate],
    ...(afterVoucher ? [[4, 999, 0, after.toISOString().slice(0, 10)]] : []),
  ])
    await exec(
      ctx,
      `INSERT INTO "AC_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DATE","AC_CODE","CR_AMT","DR_AMT","IT_TYPE","DATA_TYPE","VCH_TYPE","LEDR_KEY")
       VALUES ($1,'01','01',$2,'JV',$3,$4::date,$5,$6,$7,'A','A','JV',$8)`,
      current,
      `BT${i}`,
      date,
      party.code,
      cr,
      dr,
      `E2E-${party.code}-${i}`,
    );
}
export async function dropParty(ctx, party = PARTY) {
  await exec(ctx, `DELETE FROM "AC_DATA" WHERE tenant_id=$1 AND "AC_CODE"=$2`, party.code);
  await exec(ctx, `DELETE FROM "OP_DATA" WHERE tenant_id=$1 AND "AC_CODE"=$2`, party.code);
  await exec(ctx, `DELETE FROM "AC_MAST" WHERE tenant_id=$1 AND "AC_CODE"=$2`, party.code);
}

/** The item of item.create.footprint with its two untagged stock rows: 10 in, 4 out = 6 pcs, 60.300 / 58.950. */
export async function seedItemStock(ctx, current, clDate) {
  await exec(
    ctx,
    `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE","GR_CODE","ITEM_RATE","AVG_TOUCH")
     VALUES ($1,'01',$2,$3,'G','E1',50,91.6)`,
    ITEM.code,
    ITEM.name,
  );
  for (const [no, sign, pcs, gwt, nwt] of [
    ['BT1', '+', 10, 100.5, 98.25],
    ['BT2', '-', 4, 40.2, 39.3],
  ])
    await exec(
      ctx,
      `INSERT INTO "MAIN_STOCK"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DATE","IT_CODE","TAG_NO","ITM_SIGN","ITM_PCS","ITM_GWT","ITM_NWT")
       VALUES ($1,'01','01',$2,'PUR',$3,$4::date,$5,'N',$6,$7,$8,$9)`,
      current,
      no,
      clDate,
      ITEM.code,
      sign,
      pcs,
      gwt,
      nwt,
    );
}
export async function dropItemStock(ctx) {
  for (const table of ['MAIN_STOCK', 'ITM_OPBL', 'ITEM_MAST'])
    await exec(ctx, `DELETE FROM "${table}" WHERE tenant_id=$1 AND "IT_CODE"=$2`, ITEM.code);
}
