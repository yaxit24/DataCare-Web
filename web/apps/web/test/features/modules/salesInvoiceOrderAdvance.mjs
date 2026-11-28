import assert from 'node:assert/strict';
import { PARTIES } from '../fixtures/catalogue.mjs';

/**
 * Owner decision 3B (2026-11-27): the Sales Invoice may adjust another customer's order advance, or more than is open
 * on it, as the desktop allows (TR_SALE.cs:7206-7320 lists every party's open orders and lets a typed order take the
 * whole ADV_AMT), but only after a Yes/No confirmation that states the facts. Synthetic fixtures only.
 *
 * Planted order 09081 belongs to the inter-state fixture customer with 3,000.00 advance; the bill is the local
 * customer's and adjusts 3,500.00: another customer's order and 3,500.00 - 3,000.00 = 500.00 more than is open.
 *
 * `h` carries the screen helpers of salesInvoice.mjs.
 */
export function salesInvoiceOrderAdvanceCases(h) {
  const { C, BOOK, LINE_A } = h;
  const ORDER = '09081';
  const one = (ctx, sql, ...params) => ctx.owner.$executeRawUnsafe(sql, ctx.tenantId, ...params);
  const saleCount = async (ctx) =>
    (
      await ctx.rows(
        `SELECT count(*)::int n FROM "SL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}'`,
      )
    )[0].n;
  const confirmations = (ctx) =>
    ctx.rows(
      `SELECT "VCH_NO","NEW_USER","OLD_VAL","NEW_VAL" FROM "USER_DATA"
        WHERE tenant_id=$1 AND "COL_TYPE"='ORD_ADV_CONFIRM' AND "OLD_VAL" LIKE $2 ORDER BY row_id`,
      `%/${ORDER}|%`,
    );

  return [
    C(
      'confirm.order-advance-other-customer-over-open',
      'T06',
      'mutation',
      "Owner 3B: another customer's order adjusted beyond its open advance asks Yes/No with the facts; No saves nothing, Yes saves the desktop rows (TR_SALE.cs:15505-15530), records USER_DATA and the reopen shows the note",
      async (ctx) => {
        await one(
          ctx,
          `INSERT INTO "SL_ORD_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","HD_VCH_NO","VCH_DATE","AC_CODE","AC_NAME","ADV_AMT")
           SELECT $1::text,'01','01','2024-2025','SOR',$2::text,$2::text,CURRENT_DATE,$3::text,$4::text,3000
            WHERE NOT EXISTS (SELECT 1 FROM "SL_ORD_DATA" WHERE tenant_id=$1::text AND "VCH_NO"=$2::text)`,
          ORDER,
          PARTIES.interState.code,
          PARTIES.interState.name,
        );
        try {
          const { page } = await ctx.session();
          await h.openSales(page);
          await h.pickParty(page, PARTIES.local.code);
          await h.fillLine(page, 0, LINE_A);
          await page.getByRole('button', { name: '+ Order', exact: true }).click();
          await page.getByLabel('Order No line 1', { exact: true }).fill(ORDER);
          await page.getByLabel('Order Amt line 1', { exact: true }).fill('3500');
          const before = await saleCount(ctx);

          // 1. The refusal: 409 with the facts, shown as a Yes/No dialog (no browser dialog).
          const browserDialogs = [];
          page.on('dialog', (d) => {
            browserDialogs.push(d.message());
            void d.dismiss();
          });
          const refused = await h.save(page);
          assert.equal(refused.status(), 409, await refused.text());
          const body = await refused.json();
          assert.equal(body.error, 'order-advance-confirm');
          assert.deepEqual(
            [
              body.details.rows[0].openAmount,
              body.details.rows[0].adjustAmount,
              body.details.rows[0].overBy,
            ],
            [3000, 3500, 500],
          );
          const dialog = page.getByRole('alertdialog', { name: 'Confirm order advance' });
          await dialog.waitFor();
          const text = await dialog.innerText();
          assert.match(
            text,
            new RegExp(
              `Order ${ORDER} \\(SOR\\) belongs to ${PARTIES.interState.name} \\(${PARTIES.interState.code}\\), not to this bill's customer\\.`,
            ),
          );
          assert.match(text, /It has 3000\.00 advance open\./);
          assert.match(
            text,
            new RegExp(
              `You are adjusting 3500\\.00 on .*${PARTIES.local.code}\\)?'s bill, 500\\.00 more than is open\\.`,
            ),
          );
          assert.match(text, /Continue\?/);
          await ctx.shot(page, 'order-advance-confirm');

          // 2. No: nothing saved, back at the order amount.
          await dialog.getByRole('button', { name: 'No', exact: true }).click();
          await dialog.waitFor({ state: 'detached' });
          await page.waitForFunction(
            () => document.activeElement?.getAttribute('aria-label') === 'Order Amt line 1',
          );
          assert.equal(await saleCount(ctx), before, 'No leaves nothing saved');
          assert.deepEqual(await confirmations(ctx), []);

          // 3. Yes: the same save again with the acknowledgement.
          const again = await h.save(page);
          assert.equal(again.status(), 409);
          await dialog.waitFor();
          // While the question is open the form is inert: the order amount cannot be changed, so Yes saves what
          // the dialog states.
          const amount = page.getByLabel('Order Amt line 1', { exact: true });
          assert.equal(await amount.evaluate((el) => el.closest('[inert]') !== null), true);
          await amount.fill('9999', { timeout: 1500 }).catch(() => undefined);
          await amount.click({ timeout: 1500 }).catch(() => undefined);
          await page.keyboard.type('1');
          assert.equal(
            await amount.inputValue(),
            '3500',
            'the order amount is locked while asking',
          );
          const [savedResponse] = await Promise.all([
            page.waitForResponse(
              (r) =>
                new URL(r.url()).pathname === '/api/sales' &&
                r.request().method() === 'POST' &&
                r.status() === 201,
            ),
            dialog.getByRole('button', { name: 'Yes', exact: true }).click(),
          ]);
          const sent = savedResponse.request().postDataJSON();
          assert.deepEqual(sent.orderAdvanceAck, [
            {
              orderKey: `SOR/2024-2025/${ORDER}`,
              orderParty: PARTIES.interState.code,
              openAmount: 3000,
              adjustAmount: 3500,
            },
          ]);
          const vchNo = String((await savedResponse.json()).vchNo).padStart(5, '0');
          await page.getByText(`Saved — Voucher #${Number(vchNo)}`, { exact: false }).waitFor();
          const adj = await ctx.rows(
            `SELECT "ORD_NO","ORD_AC_CODE","ORD_SIGN","ORD_AMT"::float amt,"AC_CODE" FROM "SL_ORD_ADJ"
              WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}' AND "VCH_NO"=$2`,
            vchNo,
          );
          assert.deepEqual(adj, [
            {
              ORD_NO: ORDER,
              ORD_AC_CODE: PARTIES.interState.code,
              ORD_SIGN: '-',
              amt: 3500,
              AC_CODE: PARTIES.local.code,
            },
          ]);
          const [head] = await ctx.rows(
            `SELECT "ADV_AMT"::float adv FROM "SL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}' AND "VCH_NO"=$2`,
            vchNo,
          );
          assert.equal(head.adv, 3500);
          const trail = await confirmations(ctx);
          assert.equal(trail.length, 1);
          assert.equal(trail[0].VCH_NO, vchNo);
          assert.equal(
            trail[0].OLD_VAL,
            `SOR/2024-2025/${ORDER}|${PARTIES.interState.code}|3000.00`,
          );
          assert.equal(trail[0].NEW_VAL, '3500.00|PO|Y');
          assert.deepEqual(browserDialogs, [], 'no browser alert/confirm');

          // 4. Reopen: the note says who confirmed it and when.
          await page.getByRole('button', { name: 'New', exact: true }).click();
          await h.loadVoucher(page, vchNo);
          const note = await page
            .getByRole('note')
            .filter({ hasText: 'Order advance' })
            .innerText();
          assert.match(
            note,
            new RegExp(
              `^Order advance from another customer's order \\(${PARTIES.interState.code}\\), 500\\.00 more than the 3000\\.00 open: order ${ORDER}, 3500\\.00 adjusted — confirmed by ${trail[0].NEW_USER} on \\d{2}/\\d{2}/\\d{4}$`,
            ),
          );
          await ctx.shot(page, 'order-advance-note');
          return {
            observation: `409 with facts; dialog "${text.replace(/\s+/g, ' ').slice(0, 160)}…"; No saved nothing; Yes saved ${vchNo} (SL_ORD_ADJ ${JSON.stringify(adj)}, ADV_AMT ${head.adv}); USER_DATA ${trail[0].OLD_VAL} / ${trail[0].NEW_VAL}; reopen note "${note}"`,
            expected: {
              open: 3000,
              adjusted: 3500,
              overBy: 500,
              orderParty: PARTIES.interState.code,
            },
            database: { adj, head, trail },
            downstream: { note },
          };
        } finally {
          await one(
            ctx,
            `DELETE FROM "SL_ORD_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='SOR' AND "VCH_NO"=$2`,
            ORDER,
          );
        }
      },
    ),
  ];
}
