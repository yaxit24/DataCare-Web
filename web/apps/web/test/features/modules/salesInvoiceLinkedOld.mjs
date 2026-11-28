import assert from 'node:assert/strict';
import { ITEMS, PARTIES, USERS } from '../fixtures/catalogue.mjs';

/**
 * Owner decision 2B, PR3: on a tax-invoice (BOOK_TYPE 'T') sale book the Old Gold / Old Silver totals rows open the
 * purchase entry on the URD book, and the sale save carries it as `linkedOldPurchase` (TR_SALE.cs:18756-18847,
 * TR_PURC.cs:13724-13740, :13283-13312; TR_SALE.cs:16482-16497, :19125-19150). Synthetic fixtures only.
 *
 * The seeded SL book is BOOK_TYPE 'T' (seedCompany, as the desktop's 'Sales Invoice' book). The URD book 043 "Gold URD
 * Purchase" is a copy of the seeded PR book, switched on only inside these cases (CUR_USE 'N' afterwards, so the other
 * modules' book lists are unchanged).
 *
 * Expected figures (hand calculation):
 * - Sale line GLD22 net 4.000 × 6,000 (SL_AMT_TYPE N) = 24,000; GST 3% = 720.00; bill 24,720.00.
 * - Old gold line GLD22 net 2.000, touch 90 → fine 1.800; PR_AMT_TYPE F (seedCompany): 1.8 × 5,000 = 9,000.00, tax 0
 *   (a URD book has no default tax code, TR_PURC.cs:11657) → purchase amount 9,000.00, net weight 2.000.
 *   Edited rate 5,500: 1.8 × 5,500 = 9,900.00.
 * - Walk-in 00045: cash = Round(24,720 − 9,000) = 15,720 (TR_SALE.cs:19125-19150); CASH_AMT stored grossed up by the
 *   old amount: 15,720 + 9,000 = 24,720 (TR_SALE.cs:15071-15080); the purchase is on 00050.
 *
 * `h` carries the screen helpers of salesInvoice.mjs.
 */
export function salesInvoiceLinkedOldCases(h) {
  const { C, BOOK } = h;
  const URD = '043';
  const exec = (ctx, sql, ...params) => ctx.owner.$executeRawUnsafe(sql, ctx.tenantId, ...params);
  const SALE_LINE = {
    item: ITEMS.gold.code,
    pcs: '1',
    gross: '4',
    net: '4',
    touch: '91.6',
    rate: '6000',
  };

  async function copyBook(ctx, from, to, set) {
    for (const table of ['BOOK_DATA', 'BOOK_DETL']) {
      const cols = (
        await ctx.owner.$queryRawUnsafe(
          `SELECT column_name c FROM information_schema.columns
            WHERE table_schema='public' AND table_name=$1 AND column_name<>'row_id' ORDER BY ordinal_position`,
          table,
        )
      ).map((r) => r.c);
      const select = cols
        .map((c) =>
          c === 'CO_BOOK'
            ? '$3::text'
            : table === 'BOOK_DATA' && c in set
              ? `'${set[c]}'`
              : `"${c}"`,
        )
        .join(',');
      await exec(
        ctx,
        `INSERT INTO "${table}"(${cols.map((c) => `"${c}"`).join(',')})
         SELECT ${select} FROM "${table}" WHERE tenant_id=$1 AND "CO_BOOK"=$2::text
            AND NOT EXISTS (SELECT 1 FROM "${table}" WHERE tenant_id=$1 AND "CO_BOOK"=$3::text)`,
        from,
        to,
      );
    }
  }
  /** Run `fn` with the Gold URD purchase book 043 in use, and the cash parties 00045 / 00050 present. */
  async function withUrdBook(ctx, fn) {
    await copyBook(ctx, 'PR', URD, {
      BOOK_NAME: 'Gold URD Purchase',
      BOOK_SNAME: 'GLURD',
      BOOK_TYPE: 'T',
      CUR_USE: 'Y',
    });
    await exec(
      ctx,
      `UPDATE "BOOK_DATA" SET "CUR_USE"='Y' WHERE tenant_id=$1 AND "CO_BOOK"=$2`,
      URD,
    );
    for (const [code, name] of [
      ['00045', 'SYNTHETIC CASH SALES'],
      ['00050', 'SYNTHETIC CASH PURCHASE'],
    ])
      await exec(
        ctx,
        `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GST_TYPE","AC_GR")
         SELECT $1::text,'01','01',$2::text,$3::text,'L','20'
          WHERE NOT EXISTS (SELECT 1 FROM "AC_MAST" WHERE tenant_id=$1::text AND "AC_CODE"=$2::text)`,
        code,
        name,
      );
    try {
      return await fn();
    } finally {
      await exec(
        ctx,
        `UPDATE "BOOK_DATA" SET "CUR_USE"='N' WHERE tenant_id=$1 AND "CO_BOOK"=$2`,
        URD,
      );
    }
  }
  const sale = async (ctx, vchNo) =>
    (
      await ctx.rows(
        `SELECT "AC_CODE","TOT_AMT"::float tot,"BILL_OS"::float os,"CASH_AMT"::float cash,
                "OLD_GL_AMT"::float old_amt,"OLD_GL"::float old_wt
           FROM "SL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}' AND "VCH_NO"=$2`,
        vchNo,
      )
    )[0];
  const linkedPurchases = (ctx, vchNo) =>
    ctx.rows(
      `SELECT "CO_BOOK","VCH_NO","AC_CODE","TOT_AMT"::float tot,"BILL_OS"::float os
         FROM "PR_DATA" WHERE tenant_id=$1 AND "SL_BILL_DBCD"='${BOOK}' AND "SL_BILL_NO"=$2
        ORDER BY "VCH_NO"`,
      vchNo,
    );
  const saleCount = async (ctx) =>
    (
      await ctx.rows(
        `SELECT count(*)::int n FROM "SL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}'`,
      )
    )[0].n;
  const dialog = (page) => page.getByRole('dialog', { name: 'Old Gold purchase' });
  const roField = (page, label) => dialog(page).getByLabel(`Old Gold ${label}`, { exact: true });
  /** The purchase grid row: 0 item, 1 tag, 2 pcs, 3 gross, 4 net, 5 touch, 6 rate, 7 making. */
  const purchaseCell = (page, column) =>
    dialog(page).locator('table.grid tbody tr').first().locator('input').nth(column);
  async function enterOldGold(page, rate = '5000') {
    await purchaseCell(page, 0).fill(ITEMS.gold.code);
    await purchaseCell(page, 0).press('Escape'); // closes the item list, not the dialog
    for (const [column, value] of [
      [2, '1'],
      [3, '2.1'],
      [4, '2'],
      [5, '90'],
      [6, rate],
    ])
      await purchaseCell(page, column).fill(value);
  }
  const rowAmount = async (page) =>
    Number((await page.getByTestId('sales-old-gold-amount').innerText()).replace(/,/g, ''));
  const rowWeight = async (page) =>
    (await page.getByTestId('sales-old-gold-wt').innerText()).trim();
  const openOldGold = async (page) => {
    await page.getByRole('button', { name: 'Old Gold purchase…', exact: true }).click();
    await dialog(page).waitFor();
  };
  const newSale = async (ctx, user, party) => {
    const { page } = await ctx.session(user);
    await h.openSales(page);
    await h.pickParty(page, party);
    await h.fillLine(page, 0, SALE_LINE);
    return page;
  };

  return [
    C(
      'linked-old.non-t-book-keeps-exchange-grid',
      'T01',
      'read-only',
      'TR_SALE.cs:18843-18847: a non-T book opens the in-bill MSG_OLD grid; a T book opens the URD purchase instead and never uses the grid',
      async (ctx) => {
        await exec(
          ctx,
          `UPDATE "BOOK_DATA" SET "BOOK_TYPE"='M' WHERE tenant_id=$1 AND "CO_BOOK"=$2`,
          BOOK,
        );
        let plain;
        try {
          const { page } = await ctx.session();
          await h.openSales(page);
          await page.getByRole('button', { name: '+ Add exchange', exact: true }).waitFor();
          plain = {
            exchange: await page
              .getByRole('button', { name: '+ Add exchange', exact: true })
              .count(),
            linked: await page.getByRole('button', { name: 'Old Gold purchase…' }).count(),
          };
        } finally {
          await exec(
            ctx,
            `UPDATE "BOOK_DATA" SET "BOOK_TYPE"='T' WHERE tenant_id=$1 AND "CO_BOOK"=$2`,
            BOOK,
          );
        }
        const { page } = await ctx.session();
        await h.openSales(page);
        await page.getByRole('button', { name: 'Old Gold purchase…', exact: true }).waitFor();
        const tax = {
          exchange: await page.getByRole('button', { name: '+ Add exchange', exact: true }).count(),
          linked: await page.getByRole('button', { name: /^Old (Gold|Silver) purchase…$/ }).count(),
        };
        assert.deepEqual(plain, { exchange: 1, linked: 0 });
        assert.deepEqual(tax, { exchange: 0, linked: 2 });
        await ctx.shot(page, 'linked-old-t-book-rows');
        return {
          observation: `book type M: ${JSON.stringify(plain)}; book type T: ${JSON.stringify(tax)}`,
          expected:
            'M shows the exchange grid only; T shows the Old Gold / Old Silver purchase rows only',
          database: { unchanged: true },
        };
      },
    ),

    C(
      'linked-old.gold-create-reopen-edit-remove',
      'T06',
      'mutation',
      'Owner 2B: T book Old Gold row opens the URD purchase (043, party = sale party, date = sale date, sale bill read-only); Done brings back amount and net weight (TR_PURC.cs:13283-13312); the sale save writes both; reopen shows it, edit changes it, removal deletes it',
      async (ctx) => {
        return withUrdBook(ctx, async () => {
          const browserDialogs = [];
          const page = await newSale(ctx, undefined, PARTIES.local.code);
          page.on('dialog', (d) => browserDialogs.push(d.message())); // the harness answers it

          // Escape closes without changes.
          await openOldGold(page);
          await enterOldGold(page);
          await page.keyboard.press('Escape'); // leaves the grid for Done
          assert.equal(await page.evaluate(() => document.activeElement?.textContent), 'Done');
          await page.keyboard.press('Escape'); // closes without changes
          await dialog(page).waitFor({ state: 'detached' });
          assert.equal(await rowAmount(page), 0, 'Escape keeps nothing');
          const focused = await page.evaluate(() => ({
            text: document.activeElement?.textContent,
            html: document.activeElement?.outerHTML.slice(0, 160),
            inert: document.querySelector('form')?.hasAttribute('inert'),
          }));
          assert.equal(
            focused.text,
            'Old Gold purchase…',
            `focus back on the row (focused ${JSON.stringify(focused)})`,
          );

          // Enter on the row opens it again; the locked header.
          await page.keyboard.press('Enter');
          await dialog(page).waitFor();
          const header = {
            book: await roField(page, 'Book').inputValue(),
            party: await roField(page, 'Party').inputValue(),
            saleBill: await roField(page, 'Sale Bill').inputValue(),
            readOnly: await roField(page, 'Book').evaluate((el) => el.readOnly),
          };
          assert.equal(header.book, `${URD} — Gold URD Purchase`);
          assert.match(header.party, new RegExp(`^${PARTIES.local.code}`));
          assert.equal(header.saleBill, `${BOOK}/new`);
          assert.equal(header.readOnly, true);
          assert.equal(
            await page
              .locator('form')
              .first()
              .evaluate((f) => f.hasAttribute('inert')),
            true,
            'the sale form is inert while the purchase is open',
          );
          await enterOldGold(page);
          assert.match(
            await dialog(page).getByTestId('linked-old-totals').innerText(),
            /Amount ₹9,000\.00 · Net Wt 2\.000 g/,
          );
          await ctx.shot(page, 'linked-old-modal');
          await dialog(page).getByRole('button', { name: 'Done', exact: true }).click();
          await dialog(page).waitFor({ state: 'detached' });
          assert.equal(await rowAmount(page), 9000);
          assert.match(await rowWeight(page), /^2\.000 g/);

          const created = await h.save(page);
          assert.equal(created.status(), 201, await created.text());
          const sent = created.request().postDataJSON();
          assert.equal(sent.linkedOldPurchase.gold.lines.length, 1);
          assert.equal(sent.oldGold, undefined, 'no in-bill rows beside the linked purchase');
          const vchNo = String((await created.json()).vchNo).padStart(5, '0');
          const afterCreate = {
            sale: await sale(ctx, vchNo),
            purchases: await linkedPurchases(ctx, vchNo),
          };
          assert.deepEqual(
            [
              afterCreate.sale.tot,
              afterCreate.sale.old_amt,
              afterCreate.sale.old_wt,
              afterCreate.sale.os,
            ],
            [24720, 9000, 2, 15720],
          );
          assert.equal(afterCreate.purchases.length, 1);
          assert.deepEqual(
            [
              afterCreate.purchases[0].CO_BOOK,
              afterCreate.purchases[0].AC_CODE,
              afterCreate.purchases[0].tot,
            ],
            [URD, PARTIES.local.code, 9000],
          );
          const purchaseNo = afterCreate.purchases[0].VCH_NO;

          // Reopen: the row from linkedOldPurchases; the modal shows the stored purchase; edit the rate.
          await page.getByRole('button', { name: 'New', exact: true }).click();
          await h.loadVoucher(page, vchNo);
          assert.equal(await rowAmount(page), 9000);
          assert.match(await rowWeight(page), new RegExp(`${URD}/${purchaseNo}`));
          await openOldGold(page);
          assert.equal(await purchaseCell(page, 4).inputValue(), '2');
          await purchaseCell(page, 6).fill('5500');
          await dialog(page).getByRole('button', { name: 'Done', exact: true }).click();
          assert.equal(await rowAmount(page), 9900);
          const edited = await h.save(page, 'Update Invoice');
          assert.equal(edited.status(), 200, await edited.text());
          const afterEdit = {
            sale: await sale(ctx, vchNo),
            purchases: await linkedPurchases(ctx, vchNo),
          };
          assert.deepEqual([afterEdit.sale.old_amt, afterEdit.sale.os], [9900, 14820]);
          assert.deepEqual(
            afterEdit.purchases.map((p) => [p.VCH_NO, p.tot]),
            [[purchaseNo, 9900]],
            'the same purchase is edited',
          );

          // A sale-only edit (description): no linkedOldPurchase, the purchase row is not touched.
          const stamp = async () =>
            (
              await ctx.rows(
                `SELECT xmin::text x,"TOT_AMT"::float tot FROM "PR_DATA"
                  WHERE tenant_id=$1 AND "CO_BOOK"='${URD}' AND "VCH_NO"=$2`,
                purchaseNo,
              )
            )[0];
          const beforeRemark = await stamp();
          await page.getByRole('button', { name: 'New', exact: true }).click();
          await h.loadVoucher(page, vchNo);
          await page.getByText('Desktop settlement and invoice fields', { exact: true }).click();
          await page
            .locator('.field')
            .filter({ has: page.locator('label', { hasText: /^Description$/ }) })
            .locator('input')
            .first()
            .fill('synthetic remark');
          const remarkOnly = await h.save(page, 'Update Invoice');
          assert.equal(remarkOnly.status(), 200, await remarkOnly.text());
          assert.equal(
            'linkedOldPurchase' in remarkOnly.request().postDataJSON(),
            false,
            'a sale-only edit sends no linkedOldPurchase',
          );
          const afterRemark = await stamp();
          assert.deepEqual(afterRemark, beforeRemark, 'the linked purchase row is unchanged');
          assert.equal((await sale(ctx, vchNo)).old_amt, 9900);

          // Remove: the row is cleared and the save deletes the purchase.
          await page.getByRole('button', { name: 'New', exact: true }).click();
          await h.loadVoucher(page, vchNo);
          await page.getByRole('button', { name: 'Remove Old Gold purchase', exact: true }).click();
          assert.equal(await rowAmount(page), 0);
          const removed = await h.save(page, 'Update Invoice');
          assert.equal(removed.status(), 200, await removed.text());
          assert.deepEqual(removed.request().postDataJSON().linkedOldPurchase, {});
          const afterRemove = {
            sale: await sale(ctx, vchNo),
            purchases: await linkedPurchases(ctx, vchNo),
          };
          assert.deepEqual([afterRemove.sale.old_amt, afterRemove.sale.os], [0, 24720]);
          assert.deepEqual(afterRemove.purchases, []);
          assert.deepEqual(browserDialogs, [], 'no browser alert/confirm');
          return {
            observation: `sale ${vchNo}: created ${JSON.stringify(afterCreate)}; edited ${JSON.stringify(afterEdit)}; removed ${JSON.stringify(afterRemove)}`,
            expected: { created: [9000, 15720], edited: [9900, 14820], removed: [0, 24720] },
            database: { afterCreate, afterEdit, afterRemove },
            downstream: { purchaseNo },
          };
        });
      },
    ),

    C(
      'linked-old.walk-in-cash-prefill',
      'T06',
      'mutation',
      'TR_PURC.cs:13724-13740 (00045 → 00050) and TR_SALE.cs:19125-19150: the walk-in cash is the desktop figure; a different cash is refused naming it; CASH_AMT stored grossed up (TR_SALE.cs:15071-15080)',
      async (ctx) =>
        withUrdBook(ctx, async () => {
          const page = await newSale(ctx, undefined, '00045');
          const cashValue = (v) =>
            page.waitForFunction(
              (want) => document.querySelector('[data-testid="sales-cash"]')?.value === want,
              v,
            );
          const addOldGold = async () => {
            await openOldGold(page);
            await enterOldGold(page);
            await dialog(page).getByRole('button', { name: 'Done', exact: true }).click();
            await dialog(page).waitFor({ state: 'detached' });
          };
          await page.getByTestId('sales-cash').fill('500'); // the operator's own figure
          await openOldGold(page);
          assert.equal(await roField(page, 'Party').inputValue(), '00050 (cash purchase)');
          assert.equal(await roField(page, 'Inter-state').inputValue(), 'No (CGST+SGST)');
          await dialog(page).getByRole('button', { name: 'Cancel', exact: true }).click();
          await dialog(page).waitFor({ state: 'detached' });
          await addOldGold();
          await cashValue('15720');
          const prefilled = await page.getByTestId('sales-cash').inputValue();
          // Removing the linked purchase gives back the cash typed before the prefill.
          await page.getByRole('button', { name: 'Remove Old Gold purchase', exact: true }).click();
          await cashValue('500');
          await addOldGold();
          await cashValue('15720');

          // A typed cash other than the desktop figure: the server's refusal names it.
          const before = await saleCount(ctx);
          await page.getByTestId('sales-cash').fill('15000');
          const refused = await h.save(page);
          assert.equal(refused.status(), 400);
          const message = await page.locator('.msg.err').first().innerText();
          assert.match(message, /the cash must be 15720\.00/);
          assert.equal(await saleCount(ctx), before, 'nothing saved');

          await page.getByTestId('sales-cash').fill(prefilled);
          const created = await h.save(page);
          assert.equal(created.status(), 201, await created.text());
          const vchNo = String((await created.json()).vchNo).padStart(5, '0');
          const head = await sale(ctx, vchNo);
          const purchases = await linkedPurchases(ctx, vchNo);
          assert.deepEqual([head.AC_CODE, head.cash, head.old_amt], ['00045', 24720, 9000]);
          assert.deepEqual(
            purchases.map((p) => [p.AC_CODE, p.tot]),
            [['00050', 9000]],
          );

          // Delete the sale: the linked purchase goes with it (TR_SALE.cs:16159-16175).
          // The Delete confirm is accepted by the harness's page dialog handler.
          await page.locator('form').getByRole('button', { name: 'Delete', exact: true }).click();
          await page.getByTestId('sales-loaded').waitFor({ state: 'detached' });
          const afterDelete = await linkedPurchases(ctx, vchNo);
          assert.deepEqual(afterDelete, []);
          return {
            observation: `prefill ${prefilled} (500 restored on removal); refusal "${message}"; saved ${vchNo} ${JSON.stringify(head)}; purchases ${JSON.stringify(purchases)}; after delete ${afterDelete.length}`,
            expected: { cash: 15720, storedCash: 24720, purchaseParty: '00050' },
            database: { head, purchases, afterDelete },
            downstream: { deleteCascade: afterDelete.length === 0 },
          };
        }),
    ),

    C(
      'linked-old.no-purchase-right',
      'T11',
      'refusal',
      'Owner 2B rights: the linked purchase needs the Purchase create right; a user without it is refused 403 naming Purchase and nothing is saved',
      async (ctx) =>
        withUrdBook(ctx, async () => {
          // Without the Settings read the purchase amount cannot be computed: Done is disabled, with the reason.
          let page = await newSale(ctx, h.as(USERS.clerk.user), PARTIES.local.code);
          await openOldGold(page);
          await enterOldGold(page);
          await dialog(page).getByTestId('linked-old-settings-error').waitFor();
          const doneWithoutSettings = await dialog(page)
            .getByRole('button', { name: 'Done', exact: true })
            .isDisabled();
          assert.equal(doneWithoutSettings, true);
          await page.keyboard.press('Escape');
          await page.keyboard.press('Escape');
          await dialog(page).waitFor({ state: 'detached' });
          // With the Settings view (synthetic USER_SET row for this case) Done works; the save needs Purchase.
          await exec(
            ctx,
            `INSERT INTO "USER_SET"(tenant_id,"CO_CODE","LC_CODE","USER_NAME","MAIN_MENU","SUB_MENU","FRM_VIEW","FRM_EDIT","FRM_DELETE","FRM_PRINT")
             VALUES ($1,'01','01',$2,'Utilities','Setting Main','Y','N','N','N')`,
            USERS.clerk.user,
          );
          try {
            page = await newSale(ctx, h.as(USERS.clerk.user), PARTIES.local.code);
            await openOldGold(page);
            await enterOldGold(page);
            await dialog(page).getByRole('button', { name: 'Done', exact: true }).click();
          } finally {
            await exec(
              ctx,
              `DELETE FROM "USER_SET" WHERE tenant_id=$1 AND "USER_NAME"=$2 AND "SUB_MENU"='Setting Main'`,
              USERS.clerk.user,
            );
          }
          const before = await saleCount(ctx);
          const refused = await h.save(page);
          assert.equal(refused.status(), 403, await refused.text());
          const message = await page.locator('.msg.err').first().innerText();
          assert.equal(
            message,
            'You need the Purchase create right to save the Old Gold purchase of this sale',
          );
          assert.equal(await saleCount(ctx), before);
          return {
            observation: `settings refused: Done disabled ${doneWithoutSettings}; 403 "${message}"`,
            expected: 'Purchase create right named',
            database: { unchanged: true },
          };
        }),
    ),

    C(
      'linked-old.inter-state-party',
      'T06',
      'mutation',
      "Owner 2B: the purchase is on the sale's party, so its GST split is the party's (AC_GST_TYPE I → IGST); the modal shows it read-only and the save is accepted",
      async (ctx) =>
        withUrdBook(ctx, async () => {
          const page = await newSale(ctx, undefined, PARTIES.interState.code);
          await openOldGold(page);
          const split = await roField(page, 'Inter-state').inputValue();
          assert.equal(split, 'Yes (IGST)');
          await dialog(page)
            .locator('.field')
            .filter({ has: page.locator('label', { hasText: /^Tax %$/ }) })
            .locator('input')
            .fill('3');
          await enterOldGold(page);
          // 1.8 × 5,000 = 9,000.00; IGST 3% = 270.00; amount 9,270.00.
          assert.match(
            await dialog(page).getByTestId('linked-old-totals').innerText(),
            /Amount ₹9,270\.00/,
          );
          await dialog(page).getByRole('button', { name: 'Done', exact: true }).click();
          await dialog(page).waitFor({ state: 'detached' });
          const created = await h.save(page);
          assert.equal(created.status(), 201, await created.text());
          assert.equal(created.request().postDataJSON().linkedOldPurchase.gold.interState, true);
          const vchNo = String((await created.json()).vchNo).padStart(5, '0');
          const purchases = await linkedPurchases(ctx, vchNo);
          const head = await sale(ctx, vchNo);
          assert.deepEqual(
            purchases.map((p) => [p.AC_CODE, p.tot, p.os]),
            [[PARTIES.interState.code, 9270, 9270]],
          );
          assert.equal(head.old_amt, 9270);
          assert.equal(await rowAmount(page), 9270, 'the row shows the stored amount');
          await page.locator('form').getByRole('button', { name: 'Delete', exact: true }).click();
          await page.getByTestId('sales-loaded').waitFor({ state: 'detached' });
          return {
            observation: `modal ${split}; saved ${vchNo}; purchases ${JSON.stringify(purchases)}; OLD_GL_AMT ${head.old_amt}`,
            expected: { interState: true, amount: 9270 },
            database: { purchases, head },
            downstream: { deleted: true },
          };
        }),
    ),

    C(
      'linked-old.no-urd-book',
      'T06',
      'refusal',
      "urdBook.ts rule (4): no 043 and no single 'Gold URD' purchase book → the row says how to create one; Done is disabled",
      async (ctx) => {
        await exec(
          ctx,
          `UPDATE "BOOK_DATA" SET "CUR_USE"='N' WHERE tenant_id=$1 AND "CO_BOOK"=$2`,
          URD,
        );
        const { page } = await ctx.session();
        await h.openSales(page);
        await openOldGold(page);
        const alert = dialog(page).getByTestId('linked-old-no-book');
        await alert.waitFor();
        const text = await alert.innerText();
        assert.match(text, /Create a Gold URD Purchase book in Books \/ Series \(code 043/);
        assert.equal(
          await dialog(page).getByRole('button', { name: 'Done', exact: true }).isDisabled(),
          true,
        );
        await page.keyboard.press('Escape');
        await dialog(page).waitFor({ state: 'detached' });
        return {
          observation: `message "${text}"`,
          expected: 'the resolver message, Done disabled',
          database: { unchanged: true },
        };
      },
    ),
  ];
}
