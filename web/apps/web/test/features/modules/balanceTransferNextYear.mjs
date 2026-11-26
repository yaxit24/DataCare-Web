import assert from 'node:assert/strict';
import { USERS } from '../fixtures/catalogue.mjs';
import { switchYear } from '../harness.mjs';
import {
  as,
  C,
  ITEM,
  PARTY,
  button,
  COMPLETE,
  dropItemStock,
  dropParty,
  openScreen,
  runDataset,
  seedItemStock,
  seedParty,
  withNextYears,
} from './balanceTransferShared.mjs';

/**
 * Balance TrFr cases that need the session in the Transfer Year. The operator opens the carried year the way the
 * desktop does (a company opened on the new year, MS_OPNCOMP) or with the header's Financial year switch
 * (Shell.tsx switchContext); the harness `switchYear` presses that header control, accepts its confirmation and waits
 * for the reload. Each case uses a login slot of its own, because the switch moves the server-side session.
 *
 * Expected figures come from the seed: P1 5000.00 Cr, 1200.50 Dr and 300.25 Dr up to the closing date
 * (BtmSchm.cs:2786 closing = Σ(CR − DR) to the closing date) = 3499.25 Cr; item E2EBI 10 in, 4 out, 6 pcs,
 * 60.300 / 58.950 (BtmSchm.cs:2933-2994).
 */
const P1 = PARTY;
const P2 = { code: 'E2EBT2', name: 'E2E BALANCE TRFR PARTY TWO' };
const PAYMENT = 3000;
const SALE_LINE = { pcs: '2', gross: '20', net: '19.6', touch: '91.6', rate: '50' };

const cellOf = (page, row, column) =>
  page.locator(`[data-grid-row="${row}"][data-grid-column="${column}"] input`).first();
const num = (text) => Number(String(text).replace(/[^0-9.-]/g, ''));

async function admin(ctx, slot) {
  return ctx.session(as(USERS.admin.user, slot));
}

/** Ledger Report (RP_LEDR) detail of one account from `from`: the opening tile and the voucher rows. */
async function ledgerDetail(page, code, from, to) {
  await page.goto('/reports/account-ledger');
  await page.getByRole('heading', { name: 'Ledger Report', exact: true }).waitFor();
  await page.locator('#al-view').selectOption('detail');
  await page.getByLabel('Account', { exact: true }).fill(code);
  await page.locator('#al-from').fill(from);
  await page.locator('#al-to').fill(to);
  await page.getByRole('button', { name: 'Run', exact: true }).click();
  const tile = (caption) => page.locator('.tile', { hasText: caption }).locator('.kpi').first();
  await tile('Opening Amt').waitFor();
  const rows = [];
  for (const row of await page.locator('table.grid tbody tr').all()) {
    const cells = (await row.locator('td').allInnerTexts()).map((t) => t.trim());
    if (cells.length >= 9) rows.push(cells);
  }
  return {
    opening: num(await tile('Opening Amt').innerText()),
    closing: num(await tile('Closing Amt').innerText()),
    rows,
  };
}

const addDays = (iso, days) => {
  const d = new Date(`${iso}T00:00:00Z`);
  d.setUTCDate(d.getUTCDate() + days);
  return d.toISOString().slice(0, 10);
};

/**
 * A payment to the party through Payment (TR_CASH, book kind P), dated inside the Transfer Year. A payment debits the
 * party: against a carried 3499.25 Cr (the shop owes the party) it leaves 499.25 Cr. A receipt would credit the party
 * (TR_CASH.cs posts the party Cr on a receipt), which is why the frozen figures are reached with a payment.
 */
async function postPayment(page, party, amount, date) {
  await page.goto('/txn/payment');
  await page.getByLabel('Party account', { exact: true }).waitFor();
  const book = page.getByRole('combobox', { name: 'Configured book', exact: true });
  for (let i = 0; i < 50 && !(await book.inputValue()); i++) await page.waitForTimeout(100);
  const input = page.getByLabel('Party account', { exact: true });
  await input.fill(party);
  await input.locator('xpath=..').getByText(party, { exact: true }).first().waitFor();
  await input.press('Enter');
  await page.getByLabel('Voucher date', { exact: true }).fill(date);
  await page.getByLabel('Amount', { exact: true }).fill(String(amount));
  const [response] = await Promise.all([
    page.waitForResponse(
      (r) =>
        /\/api\/payments(\/|$)/.test(new URL(r.url()).pathname) && r.request().method() === 'POST',
    ),
    page.getByRole('button', { name: /^Save/ }).first().click(),
  ]);
  assert.equal(response.status(), 201, await response.text());
  return String((await response.json()).vchNo).padStart(5, '0');
}

/** A one-line sale through Sales Invoice, dated inside the Transfer Year. Returns its voucher number. */
async function postSale(page, party, item, line, date) {
  await page.goto('/txn/sales');
  await page.getByRole('heading', { name: 'Sales Invoice', exact: true }).waitFor();
  const book = page.getByRole('combobox', { name: 'Configured book', exact: true });
  for (let i = 0; i < 50 && !(await book.inputValue()); i++) await page.waitForTimeout(100);
  const input = page.getByPlaceholder('search accounts… (F1)').first();
  await input.fill(party);
  await input.locator('xpath=..').getByText(party, { exact: true }).first().waitFor();
  await input.press('Enter');
  await page.locator('input[type="date"]').first().fill(date);
  await cellOf(page, 0, 0).fill(item);
  await cellOf(page, 0, 0).press('Escape');
  for (const [column, value] of [
    [2, line.pcs],
    [3, line.gross],
    [4, line.net],
    [5, line.touch],
    [6, line.rate],
  ])
    await cellOf(page, 0, column).fill(value);
  const [response] = await Promise.all([
    page.waitForResponse(
      (r) => new URL(r.url()).pathname === '/api/sales' && r.request().method() === 'POST',
    ),
    button(page, 'Save Invoice').click(),
  ]);
  assert.equal(response.status(), 201, await response.text());
  return String((await response.json()).vchNo).padStart(5, '0');
}

const opData = (ctx, code) =>
  ctx.rows(
    `SELECT "CO_YEAR" yr,"OP_AMT"::float amt,"OP_SIGN" sg,"DATA_TYPE" dt,"DATA_TRFR" tr
       FROM "OP_DATA" WHERE tenant_id=$1 AND "AC_CODE"=$2 ORDER BY "CO_YEAR","DATA_TYPE"`,
    code,
  );
const itemBalance = async (ctx) =>
  (
    await ctx.rows(
      `SELECT coalesce(sum(CASE WHEN "ITM_SIGN"='+' THEN coalesce("ITM_PCS",0) ELSE -coalesce("ITM_PCS",0) END),0)::float pcs,
              round(coalesce(sum(CASE WHEN "ITM_SIGN"='+' THEN coalesce("ITM_NWT",0) ELSE -coalesce("ITM_NWT",0) END),0)::numeric,3)::float net
         FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "IT_CODE"=$2`,
      ITEM.code,
    )
  )[0];

export const nextYearCases = [
  C(
    'reopen.party-opening-screen-shows-carry',
    'T08',
    'mutation',
    'BtmSchm.cs:2801 OP_DATA of the Transfer Year is what TR_AC_OPBL.cs:2534-2546 reloads; web: a carried opening is not editable (partyOpening.ts refuseCarriedOpeningTx, architect 2026-11-22)',
    async (ctx) => {
      const { page } = await admin(ctx, 'bt-reopen-party');
      return withNextYears(ctx, page, 1, async ({ current, clDate, next }) => {
        await seedParty(ctx, current, clDate);
        try {
          await openScreen(page);
          const { response } = await runDataset(page, 'Ac Balance');
          assert.equal(response.status(), 200, await response.text());
          await page.getByText(COMPLETE, { exact: true }).waitFor();
          const before = await opData(ctx, P1.code);
          await switchYear(page, next[0].year);
          await page.goto('/txn/ac-opbl');
          await page.getByRole('heading', { name: 'Party Opening', exact: true }).waitFor();
          const code = page.getByLabel('Party Code', { exact: true });
          await code.fill(P1.code);
          await code.locator('xpath=..').getByText(P1.code, { exact: true }).first().waitFor();
          const [opening] = await Promise.all([
            page.waitForResponse((r) => new URL(r.url()).pathname === `/api/ac-opbl/${P1.code}`),
            code.press('Enter'),
          ]);
          assert.equal(opening.status(), 200);
          await page.waitForFunction(
            () => document.getElementById('opening-amount')?.value === '3499.25',
          );
          assert.equal(
            await page.getByLabel('Opening Amount Cr or Dr', { exact: true }).inputValue(),
            'C',
          );
          // Saving the carried opening again is refused (the closing year is the balance); nothing moves.
          const [save] = await Promise.all([
            page.waitForResponse(
              (r) =>
                new URL(r.url()).pathname === '/api/ac-opbl' && r.request().method() === 'POST',
            ),
            page.getByRole('button', { name: 'Save', exact: true }).click(),
          ]);
          assert.equal(save.status(), 400, await save.text());
          await page
            .getByText(
              `This opening was carried from ${current}; correct the closing year and run Balance TrFr again`,
              {
                exact: true,
              },
            )
            .waitFor();
          const after = await opData(ctx, P1.code);
          assert.deepEqual(after, before);
          return {
            observation:
              'Party Opening of the Transfer Year shows 3499.25 Cr; a save is refused and OP_DATA is unchanged',
            expected: { amount: 3499.25, sign: 'C', saveRefused: 400 },
            database: { before, after },
            downstream: { shownAmount: '3499.25 C' },
          };
        } finally {
          await dropParty(ctx);
        }
      });
    },
  ),
  C(
    'reopen.item-opening-screen-shows-carry',
    'T08',
    'mutation',
    'BtmSchm.cs:2960-2994 ITM_OPBL of the Transfer Year; TR_ITM_OPBL.cs:1269-1370 lists it for the type',
    async (ctx) => {
      const { page } = await admin(ctx, 'bt-reopen-item');
      return withNextYears(ctx, page, 1, async ({ current, clDate, next }) => {
        await seedItemStock(ctx, current, clDate);
        try {
          await openScreen(page);
          const { response } = await runDataset(page, 'Item Stock');
          assert.equal(response.status(), 200, await response.text());
          await page.getByText(COMPLETE, { exact: true }).waitFor();
          await switchYear(page, next[0].year);
          await page.goto('/txn/item-opening');
          await page.getByRole('heading', { name: 'Item Opening', exact: true }).waitFor();
          const type = page.getByLabel('Item Type', { exact: true });
          await type.selectOption('G');
          await Promise.all([
            page.waitForResponse((r) =>
              new URL(r.url()).pathname.startsWith('/api/stock/item-opening/type/G'),
            ),
            type.press('Enter'),
          ]);
          // The type's items are listed in GR_CODE, IT_CODE order; find the carried one.
          let at = 0;
          for (let r = 1; r <= 40; r++) {
            const cell = page.getByLabel(`ItCode row ${r}`, { exact: true });
            if ((await cell.count()) && (await cell.inputValue()) === ITEM.code) {
              at = r;
              break;
            }
          }
          assert.ok(at > 0, 'the carried item is on the Item Opening grid');
          const at_ = async (header) =>
            page.getByLabel(`${header} row ${at}`, { exact: true }).inputValue();
          const shown = {
            pcs: Number(await at_('Pcs')),
            gross: Number(await at_('GrWt')),
            net: Number(await at_('NetWt')),
            amount: Number(await at_('ItmAmt')),
          };
          assert.deepEqual(shown, { pcs: 6, gross: 60.3, net: 58.95, amount: 300 });
          return {
            observation: `Item Opening of ${next[0].year} shows ${JSON.stringify(shown)} for ${ITEM.code}`,
            expected: { pcs: 6, gross: 60.3, net: 58.95, amount: 300 },
            database: await ctx.rows(
              `SELECT "CO_YEAR" yr,"ITM_PCS"::float pcs,"ITM_GWT"::float gwt,"ITM_NWT"::float nwt,"ITM_AMT"::float amt
                 FROM "ITM_OPBL" WHERE tenant_id=$1 AND "IT_CODE"=$2`,
              ITEM.code,
            ),
            downstream: { shown },
          };
        } finally {
          await dropItemStock(ctx);
        }
      });
    },
  ),
  C(
    'identity.ledger-opening-line-party',
    'T16',
    'output',
    'BtmSchm.cs:2786-2801 carried closing = the Transfer Year opening; RP_LEDR opening = every entry before the From date, counted once (carriedOpening.ts)',
    async (ctx) => {
      const { page } = await admin(ctx, 'bt-identity-ledger');
      return withNextYears(ctx, page, 1, async ({ current, clDate, next }) => {
        await seedParty(ctx, current, clDate, P1, { afterVoucher: false });
        try {
          await openScreen(page);
          const { response } = await runDataset(page, 'Ac Balance');
          assert.equal(response.status(), 200, await response.text());
          await switchYear(page, next[0].year);
          const from = next[0].opDate;
          const ledger = await ledgerDetail(page, P1.code, from, addDays(from, 30));
          // 5000.00 − 1200.50 − 300.25 = 3499.25 Cr, once: the carried leg is not added to the closed year's history.
          assert.equal(ledger.opening, 3499.25);
          assert.equal(ledger.rows.length, 0, 'no entry of its own in the Transfer Year yet');
          return {
            observation: `Ledger Report of ${P1.code} from ${from}: opening ${ledger.opening} Cr`,
            expected: { opening: 3499.25 },
            output: Buffer.from(JSON.stringify(ledger, null, 2)),
          };
        } finally {
          await dropParty(ctx);
        }
      });
    },
    { requiredEvidence: ['browser', 'expected', 'output'] },
  ),
  C(
    'identity.trial-balance-opening-column',
    'T16',
    'output',
    'BtmSchm.cs:2801 OP_DATA of the Transfer Year; the year-scoped Trial Balance counts the carried opening legs once',
    async (ctx) => {
      const { page } = await admin(ctx, 'bt-identity-trial');
      return withNextYears(ctx, page, 1, async ({ current, clDate, next }) => {
        await seedParty(ctx, current, clDate, P1, { afterVoucher: false });
        // P2: Cr 700.00 in year N, Dr 0.
        await seedParty(ctx, current, clDate, P2, { afterVoucher: false });
        await ctx.owner.$executeRawUnsafe(
          `DELETE FROM "AC_DATA" WHERE tenant_id=$1 AND "AC_CODE"=$2`,
          ctx.tenantId,
          P2.code,
        );
        await ctx.owner.$executeRawUnsafe(
          `INSERT INTO "AC_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DATE","AC_CODE","CR_AMT","DR_AMT","IT_TYPE","DATA_TYPE","VCH_TYPE","LEDR_KEY")
           VALUES ($1,'01','01',$2,'JV','BT9',$3::date,$4,700,0,'A','A','JV','E2E-BT2-9')`,
          ctx.tenantId,
          current,
          clDate,
          P2.code,
        );
        try {
          await openScreen(page);
          const { response } = await runDataset(page, 'Ac Balance');
          assert.equal(response.status(), 200, await response.text());
          await switchYear(page, next[0].year);
          const [report] = await Promise.all([
            page.waitForResponse((r) => new URL(r.url()).pathname === '/api/reports/trial-balance'),
            page.goto('/reports/trial-balance'),
          ]);
          assert.equal(report.status(), 200, await report.text());
          await page.locator('table').first().waitFor();
          const find = async (code) => {
            const row = page.locator('table tbody tr', { hasText: code }).first();
            await row.waitFor();
            return (await row.locator('td').allInnerTexts()).map((t) => t.trim());
          };
          const p1 = await find(P1.code);
          const p2 = await find(P2.code);
          const amounts = (cells) => cells.map(num).filter((n) => Number.isFinite(n));
          assert.ok(amounts(p1).includes(3499.25), `P1 row ${JSON.stringify(p1)}`);
          assert.ok(amounts(p2).includes(700), `P2 row ${JSON.stringify(p2)}`);
          const body = await report.json();
          const row = (code) => body.accounts.find((a) => a.acCode === code);
          // Opening column: Cr 3499.25 and Cr 700.00 (Dr 0), counted once.
          assert.deepEqual([row(P1.code).dr, row(P1.code).cr], [0, 3499.25]);
          assert.deepEqual([row(P2.code).dr, row(P2.code).cr], [0, 700]);
          return {
            observation: `Trial Balance ${next[0].year}: ${P1.code} Cr 3499.25, ${P2.code} Cr 700.00`,
            expected: { [P1.code]: { dr: 0, cr: 3499.25 }, [P2.code]: { dr: 0, cr: 700 } },
            output: Buffer.from(JSON.stringify({ p1, p2 }, null, 2)),
          };
        } finally {
          await dropParty(ctx, P1);
          await dropParty(ctx, P2);
        }
      });
    },
    { requiredEvidence: ['browser', 'expected', 'output'] },
  ),
  C(
    'journey.party-carry-then-year-n1-business',
    'T18',
    'mutation',
    'BtmSchm.cs:2786-2801 then TR_CASH (payment) and TR_SALE in the Transfer Year; RP_LEDR running balance from the carried opening',
    async (ctx) => {
      const { page } = await admin(ctx, 'bt-journey-party');
      return withNextYears(ctx, page, 1, async ({ current, clDate, next }) => {
        await seedParty(ctx, current, clDate, P1, { afterVoucher: false });
        try {
          await openScreen(page);
          const { response } = await runDataset(page, 'Ac Balance');
          assert.equal(response.status(), 200, await response.text());
          await switchYear(page, next[0].year);
          const day = next[0].opDate;
          const paymentNo = await postPayment(page, P1.code, PAYMENT, day);
          const saleNo = await postSale(page, P1.code, 'GLD22', SALE_LINE, day);
          const [{ tot }] = await ctx.rows(
            `SELECT "TOT_AMT"::float tot FROM "SL_DATA" WHERE tenant_id=$1 AND "VCH_NO"=$2 AND "CO_YEAR"=$3`,
            saleNo,
            next[0].year,
          );
          assert.ok(
            tot > 499.25,
            `the sale (${tot}) is larger than the balance left after the payment`,
          );
          const ledger = await ledgerDetail(page, P1.code, day, addDays(day, 30));
          // 3499.25 Cr − 3000.00 payment (Dr) = 499.25 Cr; the sale is a Dr: 499.25 − sale (negative = Dr).
          const afterPayment = 499.25;
          const closing = Math.round((afterPayment - tot) * 100) / 100;
          assert.equal(ledger.opening, 3499.25, 'the opening is counted once');
          assert.equal(ledger.closing, closing);
          assert.equal(ledger.rows.length >= 2, true);
          return {
            observation: `payment ${paymentNo} 3000.00 and sale ${saleNo} ${tot}: ledger opening 3499.25 Cr, closing ${closing}`,
            expected: { opening: 3499.25, afterPayment, closing },
            database: { paymentNo, saleNo, saleTotal: tot },
            downstream: { ledger },
          };
        } finally {
          await dropParty(ctx);
        }
      });
    },
  ),
  C(
    'journey.item-carry-then-issue',
    'T18',
    'mutation',
    'BtmSchm.cs:2933-2994 then TR_SALE in the Transfer Year; stock = MAIN_STOCK of every year (Q9), the carry changes no balance',
    async (ctx) => {
      const { page } = await admin(ctx, 'bt-journey-item');
      return withNextYears(ctx, page, 1, async ({ current, clDate, next }) => {
        await seedItemStock(ctx, current, clDate);
        await seedParty(ctx, current, clDate, P1, { afterVoucher: false });
        try {
          const start = await itemBalance(ctx);
          assert.deepEqual(start, { pcs: 6, net: 58.95 });
          await openScreen(page);
          const { response } = await runDataset(page, 'Item Stock');
          assert.equal(response.status(), 200, await response.text());
          assert.deepEqual(await itemBalance(ctx), start, 'the carry changes no balance');
          await switchYear(page, next[0].year);
          const saleNo = await postSale(page, P1.code, ITEM.code, SALE_LINE, next[0].opDate);
          // 6 − 2 = 4 pcs; 58.950 − 19.600 = 39.350.
          const end = await itemBalance(ctx);
          assert.deepEqual(end, { pcs: 4, net: 39.35 });
          return {
            observation: `sale ${saleNo} of 2 pcs / 19.600: ${ITEM.code} balance ${end.pcs} pcs / ${end.net}`,
            expected: { pcs: 4, net: 39.35 },
            database: { before: start, after: end, sale: saleNo },
            downstream: { balance: end },
          };
        } finally {
          await dropParty(ctx);
          await dropItemStock(ctx);
        }
      });
    },
  ),
];
