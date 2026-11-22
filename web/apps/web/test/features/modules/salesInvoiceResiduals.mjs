import assert from 'node:assert/strict';
import { PARTIES } from '../fixtures/catalogue.mjs';

/**
 * WP-26 (N243, G255): Sales Invoice residual cases (orchestration/work/WP-26/cases.md). Expected values are worked by
 * hand from TR_SALE.cs (comments beside them). Line A: 10.000 g x 6,123.45 = 61,234.50 + labour 10.000 x 237.5 =
 * 2,375.00 -> net 63,609.50; GST 3% = 1,908.29; total 65,517.79.
 *
 * `h` carries the screen helpers of salesInvoice.mjs (openSales, pickParty, fillLine, save, loadVoucher, field, cell,
 * createOneLine, C, BOOK, LINE_A).
 */
export function salesInvoiceResidualCases(h) {
  const { C, BOOK, LINE_A } = h;
  const TOTAL = 65517.79;
  const one = async (ctx, sql, ...params) =>
    ctx.owner.$executeRawUnsafe(sql, ctx.tenantId, ...params);
  const sl = async (ctx, vchNo) =>
    (
      await ctx.rows(
        `SELECT * FROM "SL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}' AND "VCH_NO"=$2`,
        vchNo,
      )
    )[0];
  const child = (ctx, table, vchNo) =>
    ctx.rows(
      `SELECT * FROM "${table}" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}' AND "VCH_NO"=$2 ORDER BY "SR_NO"`,
      vchNo,
    );
  const plain = (row) =>
    JSON.parse(JSON.stringify(row, (_k, v) => (typeof v === 'bigint' ? String(v) : v)));
  const dialogs = (page) => {
    const seen = [];
    page.removeAllListeners('dialog');
    page.on('dialog', (dialog) => {
      seen.push(dialog.message());
      void dialog.accept();
    });
    return seen;
  };
  const reopen = async (page, vchNo) => {
    await page.getByRole('button', { name: 'New', exact: true }).click();
    await h.loadVoucher(page, vchNo);
  };
  const newBill = async (ctx) => {
    const { page } = await ctx.session();
    await h.openSales(page);
    await h.pickParty(page, PARTIES.local.code);
    await h.fillLine(page, 0, LINE_A);
    return page;
  };
  const saved = async (page, label) => {
    const response = await h.save(page, label);
    assert.ok([200, 201].includes(response.status()), await response.text());
    return String((await response.json()).vchNo ?? '').padStart(5, '0');
  };
  const addUpi = async (page, i, row) => {
    await page.getByRole('button', { name: '+ UPI row', exact: true }).click();
    await page.getByLabel(`UPI AcCode line ${i}`, { exact: true }).fill(row.ac);
    await page.getByLabel(`UPI Type line ${i}`, { exact: true }).fill(row.type);
    await page.getByLabel(`UPI Id line ${i}`, { exact: true }).fill(row.id);
    await page.getByLabel(`UPI Amt line ${i}`, { exact: true }).fill(row.amount);
  };
  const exchangeRow = (page, i) =>
    page
      .locator('table')
      .filter({ has: page.getByRole('columnheader', { name: 'Touch%' }) })
      .locator('tbody tr')
      .nth(i);
  const setBank = async (page) => {
    await page.getByText('Desktop settlement and invoice fields', { exact: true }).click();
    await h.field(page, 'Cheque Bank A/c').fill(PARTIES.bank.code);
  };
  const openExchangeDetails = (page, i) =>
    page.getByText(`Exchange row ${i + 1} desktop fields`, { exact: true }).click();

  return [
    {
      ...C(
        'source.approval-no-import',
        'T04',
        'mutation',
        'TR_SALE.cs:20050 "All Approval Tag In This Voucher Import?" (the "A" button)',
        async () => ({}),
      ),
      blocked:
        'D5: the master plan\'s "Sales Apr No import" (LITE-MASTER-PLAN.md line 309) needs the WP-01 approval-issue import service; question to the supervisor: has it landed, and which approval numbers belong in the Test data?',
    },
    C(
      'refusal.negative-weight',
      'T06',
      'refusal',
      'Decision D3: no desktop text refuses a negative weight (TR_SALE.cs:14879 drops only NUL and apostrophe), so the save is accepted',
      async (ctx) => {
        const { page } = await ctx.session();
        await h.openSales(page);
        await h.pickParty(page, PARTIES.local.code);
        await h.fillLine(page, 0, { ...LINE_A, gross: '-10', net: '-10' });
        const vchNo = await saved(page);
        const [line] = await ctx.rows(
          `SELECT "ITM_NWT"::float nwt FROM "SL_DETL" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}' AND "VCH_NO"=$2`,
          vchNo,
        );
        assert.equal(line.nwt, -10);
        return {
          observation: `saved ${vchNo} with net weight ${line.nwt}`,
          expected: 'saved, ITM_NWT -10.000 (D3 accept)',
          database: { line },
        };
      },
    ),

    C(
      'config.setting-change',
      'T15',
      'mutation',
      'D4: a line takes SL_AMT_TYPE when entered (TR_SALE.cs:9161), reopen shows the stored RATE_WITH (:14570), a new line takes the current setting',
      async (ctx) => {
        await one(
          ctx,
          `UPDATE "CO_SET" SET "SL_AMT_TYPE"='N' WHERE tenant_id=$1 AND "CO_CODE"='01'`,
        );
        try {
          const page = await newBill(ctx); // the screen opened under N
          await one(
            ctx,
            `UPDATE "CO_SET" SET "SL_AMT_TYPE"='F' WHERE tenant_id=$1 AND "CO_CODE"='01'`,
          );
          const vchNo = await saved(page);
          const first = await ctx.rows(
            `SELECT "RATE_WITH" rw, "NET_AMT"::float net FROM "SL_DETL" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}' AND "VCH_NO"=$2`,
            vchNo,
          );
          assert.deepEqual(first, [{ rw: 'N', net: 63609.5 }]);
          await page.reload(); // the company reopened: the screen now reads F
          await h.openSales(page);
          await h.loadVoucher(page, vchNo);
          await page.getByRole('button', { name: '+ Add line', exact: true }).click();
          await h.fillLine(page, 1, { ...LINE_A, making: undefined });
          await saved(page, 'Update Invoice');
          const after = await ctx.rows(
            `SELECT "SR_NO"::int sr, "RATE_WITH" rw FROM "SL_DETL" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}' AND "VCH_NO"=$2 ORDER BY "SR_NO"`,
            vchNo,
          );
          assert.deepEqual(
            after.map((r) => r.rw),
            ['N', 'F'],
          );
          return {
            observation: `line 1 ${after[0].rw}, new line 2 ${after[1].rw}`,
            expected: 'stored N kept on reopen; new line F',
            database: { first, after },
            downstream: { lineNet: first[0].net },
          };
        } finally {
          await one(
            ctx,
            `UPDATE "CO_SET" SET "SL_AMT_TYPE"='N' WHERE tenant_id=$1 AND "CO_CODE"='01'`,
          );
        }
      },
    ),

    C(
      'field.header-account-overrides-route',
      'T02',
      'mutation',
      'TR_SALE.cs:15264, :15267, :15347, :15203 written; :14365, :14398, :14404 shown on reopen',
      async (ctx) => {
        const page = await newBill(ctx);
        await page.getByLabel('Memb Ac', { exact: true }).fill('M1');
        await page.getByLabel('Without Comm Bill', { exact: true }).check();
        await page.getByText('Desktop posting accounts and flags', { exact: true }).click();
        await h.field(page, 'Rate Unfix').fill('Y');
        await h.field(page, 'Tax Code').fill('10');
        await h.field(page, 'Cash ₹').fill(String(TOTAL));
        const vchNo = await saved(page);
        const row = await sl(ctx, vchNo);
        assert.deepEqual(
          [row.MEMB_COM_AC_CODE, row.WHOUT_COMM_BILL, row.RATE_UNFIX, row.TAX_CODE],
          ['M1', 'Y', 'Y', '10'],
        );
        await reopen(page, vchNo);
        await page.getByText('Desktop posting accounts and flags', { exact: true }).click();
        const shown = [
          await page.getByLabel('Memb Ac', { exact: true }).inputValue(),
          await page.getByLabel('Without Comm Bill', { exact: true }).isChecked(),
          await h.field(page, 'Rate Unfix').inputValue(),
          await h.field(page, 'Tax Code').inputValue(),
        ];
        assert.deepEqual(shown, ['M1', true, 'Y', '10']);
        return {
          observation: `stored ${JSON.stringify([row.MEMB_COM_AC_CODE, row.WHOUT_COMM_BILL, row.RATE_UNFIX, row.TAX_CODE])}; reopened ${JSON.stringify(shown)}`,
          expected: ['M1', 'Y', 'Y', '10'],
          database: { row: plain(row) },
          downstream: { shown },
        };
      },
    ),

    C(
      'reopen.desktop-saved-header-columns',
      'T08',
      'mutation',
      'Lossless reopen (study gap 1, D8): an unchanged save writes every SL_DATA column back except VCH_TIME',
      async (ctx) => {
        const page = await newBill(ctx);
        const vchNo = await saved(page);
        await one(
          ctx,
          `UPDATE "SL_DATA" SET "MEMB_COM_AC_CODE"='M1',"WHOUT_COMM_BILL"='Y',"RATE_UNFIX"='Y',"DATA_TRFR"='Y',
             "USER_UPDATE"='Y',"USER_DELETE"='Y' WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}' AND "VCH_NO"=$2`,
          vchNo,
        );
        const { VCH_TIME: _a, row_id: _b, ...before } = plain(await sl(ctx, vchNo));
        await reopen(page, vchNo);
        await saved(page, 'Update Invoice');
        const { VCH_TIME: _c, row_id: _d, ...after } = plain(await sl(ctx, vchNo));
        assert.deepEqual(after, before);
        return {
          observation: `voucher ${vchNo}: SL_DATA identical after the unchanged save (RATE_UNFIX ${after.RATE_UNFIX}, DATA_TRFR ${after.DATA_TRFR})`,
          expected: 'every column identical except VCH_TIME',
          database: { before, after },
          downstream: { identical: true },
        };
      },
    ),

    C(
      'tender.upi-total-is-sum-of-rows',
      'T03',
      'read-only',
      'TR_SALE.cs:6862-6867: UPI total = rows with an account and an amount (1,000.00 + 2,500.50 = 3,500.50; a blank account row is ignored)',
      async (ctx) => {
        const page = await newBill(ctx);
        await addUpi(page, 1, { ac: 'U1', type: 'PHONEPE', id: 'a@b', amount: '1000' });
        await addUpi(page, 2, { ac: 'U2', type: 'GPAY', id: 'c@d', amount: '2500.50' });
        await addUpi(page, 3, { ac: '', type: '', id: '', amount: '99' });
        const upi = await h.field(page, 'UPI ₹').inputValue();
        assert.equal(Number(upi), 3500.5);
        return { observation: `UPI ₹ ${upi}`, expected: 3500.5 };
      },
    ),

    C(
      'field.upi-row-route',
      'T02',
      'mutation',
      'TR_SALE.cs:15869 UPI_DATA.UPI_AMT, :15253 SL_DATA.UPI_AMT, reopen :14291; register UPI',
      async (ctx) => {
        const page = await newBill(ctx);
        await addUpi(page, 1, {
          ac: PARTIES.bank.code,
          type: 'PHONEPE',
          id: 'a@b',
          amount: '1000',
        });
        await addUpi(page, 2, {
          ac: PARTIES.bank.code,
          type: 'GPAY',
          id: 'c@d',
          amount: '2500.50',
        });
        await setBank(page);
        const vchNo = await saved(page);
        await reopen(page, vchNo);
        await page.getByLabel('UPI Amt line 1', { exact: true }).fill('1200');
        await saved(page, 'Update Invoice');
        const rows = await child(ctx, 'UPI_DATA', vchNo);
        const head = await sl(ctx, vchNo);
        assert.deepEqual(
          rows.map((r) => Number(r.UPI_AMT)),
          [1200, 2500.5],
        );
        assert.equal(Number(head.UPI_AMT), 3700.5); // 1,200.00 + 2,500.50
        await reopen(page, vchNo);
        assert.equal(
          Number(await page.getByLabel('UPI Amt line 1', { exact: true }).inputValue()),
          1200,
        );
        return {
          observation: `UPI_DATA ${rows.map((r) => r.UPI_AMT).join(', ')}; UPI_AMT ${head.UPI_AMT}`,
          expected: { rows: [1200, 2500.5], header: 3700.5 },
          database: { rows: rows.map(plain), upi: head.UPI_AMT },
          downstream: { reopened: 1200 },
        };
      },
    ),

    C(
      'children.upi-row-delete-takes-effect-on-save',
      'T05',
      'mutation',
      'TR_SALE.cs:6907-6921: Ctrl+D asks, clears the row, says "Please Save This Voucher Then Effect...."; the database changes at Save',
      async (ctx) => {
        const page = await newBill(ctx);
        await addUpi(page, 1, {
          ac: PARTIES.bank.code,
          type: 'PHONEPE',
          id: 'a@b',
          amount: '1000',
        });
        await addUpi(page, 2, {
          ac: PARTIES.bank.code,
          type: 'GPAY',
          id: 'c@d',
          amount: '2500.50',
        });
        await setBank(page);
        const vchNo = await saved(page);
        await reopen(page, vchNo);
        const seen = dialogs(page);
        await page.getByLabel('UPI Amt line 2', { exact: true }).press('Control+d');
        await page.getByText('Please Save This Voucher Then Effect....', { exact: true }).waitFor();
        assert.deepEqual(seen, ['This Row Record will Removed permantley ?']);
        assert.equal(Number(await h.field(page, 'UPI ₹').inputValue()), 1000);
        assert.equal((await child(ctx, 'UPI_DATA', vchNo)).length, 2, 'not written before Save');
        await saved(page, 'Update Invoice');
        const rows = await child(ctx, 'UPI_DATA', vchNo);
        assert.deepEqual(
          rows.map((r) => [Number(r.SR_NO), Number(r.UPI_AMT)]),
          [[1, 1000]],
        );
        return {
          observation: `before save 2 rows; after save ${rows.length} row`,
          expected: '2 rows until Save, then 1 row 1,000.00',
          database: { rows: rows.map(plain) },
          downstream: { message: true },
        };
      },
    ),

    C(
      'keyboard.upi-f1-adds-type',
      'T17',
      'read-only',
      'TR_SALE.cs:6901-6903: F1 on the UPI type column starts "add type"; on column 1 nothing happens',
      async (ctx) => {
        const page = await newBill(ctx);
        await page.getByRole('button', { name: '+ UPI row', exact: true }).click();
        await page.getByLabel('UPI AcCode line 1', { exact: true }).press('F1');
        assert.equal(await page.getByText('UPI (add type)').count(), 0);
        await page.getByLabel('UPI Type line 1', { exact: true }).press('F1');
        await page.getByText('UPI (add type)').waitFor();
        return {
          observation: 'F1 on column 3 starts add type; column 1 does not',
          expected: 'add type on column 3 only',
        };
      },
    ),

    C(
      'field.credit-note-route',
      'T02',
      'mutation',
      'TR_SALE.cs:15230 CRNT_ADJ_AMT, :15906/:15911 CRNT_DATA; :19390 the note joins the bill outstanding',
      async (ctx) => {
        const page = await newBill(ctx);
        await page.getByRole('button', { name: '+ Credit note', exact: true }).click();
        await page.getByLabel('Credit Note No line 1', { exact: true }).fill('CN1');
        await page.getByLabel('Credit Note Amt line 1', { exact: true }).fill('4000');
        const vchNo = await saved(page);
        const head = await sl(ctx, vchNo);
        const rows = await child(ctx, 'CRNT_DATA', vchNo);
        // credit sale (the fixture party is near its cash limit): BILL_OS = 65,517.79 - 4,000.00 = 61,517.79 (:19390)
        assert.deepEqual([Number(head.CRNT_ADJ_AMT), Number(head.BILL_OS)], [4000, 61517.79]);
        assert.deepEqual(
          rows.map((r) => [r.CRNT_NO, Number(r.CRNT_AMT)]),
          [['CN1', 4000]],
        );
        await reopen(page, vchNo);
        assert.equal(
          await page.getByLabel('Credit Note No line 1', { exact: true }).inputValue(),
          'CN1',
        );
        return {
          observation: `CRNT_ADJ_AMT ${head.CRNT_ADJ_AMT}, BILL_OS ${head.BILL_OS}, rows ${rows.length}`,
          expected: { crnt: 4000, billOs: 61517.79 },
          database: { head: plain(head), rows: rows.map(plain) },
          downstream: { reopened: 'CN1' },
        };
      },
    ),

    C(
      'field.order-advance-route',
      'T02',
      'mutation',
      'D2: SL_ORD_ADJ ORD_SIGN "-", ORD_AMT, PAID_AMT 0, ENTRY_TYPE S (TR_SALE.cs:15715-15718); ADV_AMT :15229; reopen :14283',
      async (ctx) => {
        await one(
          ctx,
          `INSERT INTO "SL_ORD_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","HD_VCH_NO","VCH_DATE","AC_CODE","ADV_AMT")
           SELECT $1::text,'01','01','2024-2025','SOR','09071','09071',CURRENT_DATE,$2::text,5000
            WHERE NOT EXISTS (SELECT 1 FROM "SL_ORD_DATA" WHERE tenant_id=$1::text AND "VCH_NO"='09071')`,
          PARTIES.local.code,
        );
        const page = await newBill(ctx);
        await page.getByRole('button', { name: '+ Order', exact: true }).click();
        await page.getByLabel('Order No line 1', { exact: true }).fill('09071');
        await page.getByLabel('Order Amt line 1', { exact: true }).fill('5000');
        const vchNo = await saved(page);
        const head = await sl(ctx, vchNo);
        const rows = await child(ctx, 'SL_ORD_ADJ', vchNo);
        assert.deepEqual(
          rows.map((r) => [r.ORD_SIGN, Number(r.ORD_AMT), Number(r.PAID_AMT), r.ENTRY_TYPE]),
          [['-', 5000, 0, 'S']],
        );
        assert.equal(Number(head.ADV_AMT), 5000);
        await reopen(page, vchNo);
        assert.equal(
          Number(await page.getByLabel('Order Amt line 1', { exact: true }).inputValue()),
          5000,
        );
        return {
          observation: `ADV_AMT ${head.ADV_AMT}; SL_ORD_ADJ ${JSON.stringify(rows.map((r) => [r.ORD_SIGN, r.ORD_AMT]))}`,
          expected: { adv: 5000, sign: '-' },
          database: { rows: rows.map(plain) },
          downstream: { reopened: 5000 },
        };
      },
    ),

    C(
      'refusal.duplicate-order',
      'T06',
      'refusal',
      'TR_SALE.cs:7324-7326: the same book and order number on a second row gives "Duplicate Order No" and clears the cell',
      async (ctx) => {
        const page = await newBill(ctx);
        for (const i of [1, 2]) {
          await page.getByRole('button', { name: '+ Order', exact: true }).click();
          await page.getByLabel(`Order No line ${i}`, { exact: true }).fill('09071');
        }
        await page.getByText('Duplicate Order No', { exact: true }).waitFor();
        assert.equal(await page.getByLabel('Order No line 2', { exact: true }).inputValue(), '');
        return {
          observation: 'second row refused and cleared',
          expected: 'Duplicate Order No',
          database: { unchanged: true },
        };
      },
    ),

    C(
      'refusal.oldmetal-rate-type',
      'T06',
      'refusal',
      'TR_SALE.cs:7667-7669: a rate type other than N or F (case-sensitive) shows "Please Slelect Rate type = N - Net Wise Or F - Fine Wise"',
      async (ctx) => {
        const page = await newBill(ctx);
        await page.getByRole('button', { name: '+ Add exchange', exact: true }).click();
        await openExchangeDetails(page, 0);
        const seen = dialogs(page);
        const type = page.getByLabel('Exchange 1 Rate Type', { exact: true });
        for (const value of ['X', 'n']) {
          await type.fill(value);
          await type.blur();
        }
        await type.fill('F');
        await type.blur();
        assert.deepEqual(seen, [
          'Please Slelect Rate type = N - Net Wise Or F - Fine Wise',
          'Please Slelect Rate type = N - Net Wise Or F - Fine Wise',
        ]);
        return {
          observation: `messages ${seen.length}`,
          expected: 'X and n refused, F accepted',
          database: { unchanged: true },
        };
      },
    ),

    C(
      'oldmetal.amount-net-wise',
      'T03',
      'read-only',
      'TR_SALE.cs:7959: N rate type, amount = Round(12.500 x 6,000, 0) = 75,000.00; F rate type :7963 Round(11.450 x 6,000, 0) = 68,700.00',
      async (ctx) => {
        const page = await newBill(ctx);
        await page.getByRole('button', { name: '+ Add exchange', exact: true }).click();
        const row = exchangeRow(page, 0);
        await row.locator('input').nth(0).fill('OLDG');
        await row.locator('input').nth(3).fill('12.5');
        await row.locator('input').nth(4).fill('91.6');
        await row.locator('input').nth(5).fill('6000');
        await openExchangeDetails(page, 0);
        await page.getByLabel('Exchange 1 Rate Type', { exact: true }).fill('N');
        const netWise = Number((await row.locator('td').nth(7).innerText()).replace(/,/g, ''));
        await page.getByLabel('Exchange 1 Rate Type', { exact: true }).fill('F');
        const fineWise = Number((await row.locator('td').nth(7).innerText()).replace(/,/g, ''));
        assert.deepEqual([netWise, fineWise], [75000, 68700]);
        return {
          observation: `N ${netWise}, F ${fineWise}`,
          expected: { netWise: 75000, fineWise: 68700 },
        };
      },
    ),

    C(
      'oldmetal.touch-from-amount-gold',
      'T03',
      'read-only',
      "TR_SALE.cs:7970, :7981-7991: OG, N, net 10.000, amount 54,000.00, today's gold 60,000 / 10 = 6,000.00 -> rate 5,400.00, touch 90.00",
      async (ctx) => {
        await one(
          ctx,
          `INSERT INTO "RATE_MAST"(tenant_id,"CO_CODE","LC_CODE","GR_CODE","VCH_DATE","SR_NO","FINE_GL_RATE","FINE_SL_RATE")
           VALUES ($1,'01','01','',CURRENT_DATE,1,60000,80000)`,
        );
        try {
          const page = await newBill(ctx);
          await page.getByRole('button', { name: '+ Add exchange', exact: true }).click();
          const row = exchangeRow(page, 0);
          await row.locator('input').nth(0).fill('OG');
          await row.locator('input').nth(3).fill('10');
          await openExchangeDetails(page, 0);
          await page.getByLabel('Exchange 1 Rate Type', { exact: true }).fill('N');
          const amount = page.getByLabel('Exchange 1 Amount', { exact: true });
          await amount.fill('54000');
          await amount.blur();
          const rate = Number(await row.locator('input').nth(5).inputValue());
          const touch = Number(await row.locator('input').nth(4).inputValue());
          assert.deepEqual([rate, touch], [5400, 90]);
          return {
            observation: `rate ${rate}, touch ${touch}`,
            expected: { rate: 5400, touch: 90 },
          };
        } finally {
          await one(
            ctx,
            `DELETE FROM "RATE_MAST" WHERE tenant_id=$1 AND "GR_CODE"='' AND "FINE_GL_RATE"=60000`,
          );
        }
      },
    ),

    C(
      'entry.print-file-list-and-default',
      'T01',
      'read-only',
      'TR_SALE.cs:13933: PRINT_MAST files of the company for the book, ordered, blank first, PRINT_SET_A Y selected',
      async (ctx) => {
        const [book] = await ctx.rows(
          `SELECT "MAIN_BOOK" m, coalesce("BOOK_TYPE",'') t FROM "BOOK_DATA" WHERE tenant_id=$1 AND "CO_CODE"='01' AND "CO_BOOK"='${BOOK}' LIMIT 1`,
        );
        await one(ctx, `DELETE FROM "PRINT_MAST" WHERE tenant_id=$1`);
        await one(
          ctx,
          `INSERT INTO "PRINT_MAST"(tenant_id,"CO_CODE","PRINT_TYPE","BOOK_TYPE","PRINT_FILE","PRINT_SET_A")
           VALUES ($1,'01',$2,$3,'SalesBillA4','N'),($1,'01',$2,$3,'SalesBillGst','Y'),($1,'02',$2,$3,'OtherCo','Y'),
                  ($1,'01',$2,'ZZ','OtherType','N')`,
          book.m,
          book.t,
        );
        try {
          const { page } = await ctx.session();
          await h.openSales(page);
          const select = page.getByLabel('Print file', { exact: true });
          for (let i = 0; i < 40 && (await select.inputValue()) !== 'SalesBillGst'; i++)
            await page.waitForTimeout(100);
          const offered = await select.locator('option').allTextContents();
          assert.deepEqual(offered, ['', 'SalesBillA4', 'SalesBillGst']);
          assert.equal(await select.inputValue(), 'SalesBillGst');
          // "Set" makes SalesBillA4 the default (TR_SALE.cs:20618-20625).
          await select.selectOption('SalesBillA4');
          await page.getByRole('button', { name: 'Set', exact: true }).click();
          await page.getByText('Print Report Default Set', { exact: true }).waitFor();
          const flags = await ctx.rows(
            `SELECT "PRINT_FILE" f, "PRINT_SET_A" s FROM "PRINT_MAST" WHERE tenant_id=$1 AND "CO_CODE"='01' ORDER BY "PRINT_FILE"`,
          );
          assert.deepEqual(
            flags.map((r) => [r.f, r.s]),
            [
              ['OtherType', 'N'],
              ['SalesBillA4', 'Y'],
              ['SalesBillGst', 'N'],
            ],
          );
          return {
            observation: `offered ${JSON.stringify(offered)}; Set -> ${JSON.stringify(flags)}`,
            expected: 'blank, SalesBillA4, SalesBillGst',
          };
        } finally {
          await one(ctx, `DELETE FROM "PRINT_MAST" WHERE tenant_id=$1`);
        }
      },
    ),

    C(
      'print.template-chosen-file',
      'T16',
      'output',
      'TR_SALE.cs:16482-16495, D6: HUID box first, then the chosen file; a file without a web template prints the default',
      async (ctx) => {
        const page = await newBill(ctx);
        const vchNo = await saved(page);
        const template = async (query) => {
          const response = await page.request.get(
            `/api/sales/${vchNo}/print?coBook=${BOOK}&format=html&copy=O&${query}`,
          );
          assert.equal(response.status(), 200, await response.text());
          return response.headers()['x-print-template'];
        };
        const seen = {
          a4: await template('file=SalesBillA4'),
          gst: await template('file=SalesBillGst'),
          unknown: await template('file=NoSuchCrystal'),
          huid: await template('file=SalesBillA4&huid=1'),
        };
        assert.equal(seen.a4, 'tax-invoice; file=SalesBillA4');
        assert.equal(seen.gst, 'tax-invoice; file=SalesBillGst');
        assert.equal(seen.unknown, 'tax-invoice; file=NoSuchCrystal; default');
        assert.equal(seen.huid, 'huid; file=RtlHuidPrint');
        return {
          observation: JSON.stringify(seen),
          expected: 'named templates; unknown -> default; HUID wins',
          output: seen,
        };
      },
    ),
  ];
}
