import assert from 'node:assert/strict';

export const mfgLotFixtureTables = [
  'MAIN_STOCK',
  'MFG_ISU_REC',
  'MFG_IDTL',
  'MFG_DETL',
  'MFG_DATA',
  'MFG_MAST',
];
/** Synthetic saved-read fixtures. The caller owns tenant cleanup, owner connection and real login. */
export async function seedMfgLot(tx, tenantId) {
  const sql = (query, ...values) => tx.$executeRawUnsafe(query, tenantId, ...values);
  for (const [book, family, direction, stage] of [
    ['LSI', 'MFG STNG ISU', 'O', '71'],
    ['LSR', 'MFG STNG REC', 'I', '72'],
    ['LS2', 'MFG STNG ISU', 'O', '73'],
    ['LR2', 'MFG STNG REC', 'I', '74'],
  ]) {
    await sql(
      `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","MAIN_BOOK","BOOK_NAME","BOOK_INOUT","CUR_USE","BOOK_TBL_NAME") VALUES($1,'01','01',$2,$3,$4,$5,'Y','MFG_DATA')`,
      book,
      family,
      `Browser ${book}`,
      direction,
    );
    await sql(
      `INSERT INTO "MFG_MAST"(tenant_id,"CO_CODE","SM_MAIN_CODE","CO_BOOK","ENTRY_TYPE","LAST_TRAN","NEXT_TRAN","IN_OUT","STK_ISU","STK_REC") VALUES($1,'01',$2,$3,'S','S','P',$4,'Y','N')`,
      stage,
      book,
      direction,
    );
  }
  for (const [book, no] of [
    ['LSI', '00001'],
    ['LSR', '00002'],
  ]) {
    await sql(
      `INSERT INTO "MFG_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DATE","VCH_TIME","AC_CODE","BILL_NO","NET_AMT","TAX_AMT","CASH_AMT","VCH_DESC") VALUES($1,'01','01','2024-2025',$2,$3,'2024-07-01','2024-07-01 12:13:14.123456','TOURAC','READ%_1',9999999999999999.99,NULL,0,'Imported lot browser fixture')`,
      book,
      no,
    );
    await sql(
      `INSERT INTO "MFG_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","OLD_SRNO","IT_CODE","ISU_IT_CODE","TAG_NO","LOT_NO","ITM_NWT","ITM_GWT","ITM_REMARK","REP_YRCD","REP_DBCD","REP_NO","REP_SRNO","REP_AC_CODE") VALUES($1,'01','01','2024-2025',$2,$3,17,42,'GOLD','GOLD','WORK-17','PARENTLOT',3.123,3.456,'','2023-2024','LSI','00077',42,'TOURAC')`,
      book,
      no,
    );
    for (const [isr, lot, weight] of [
      [3, 'CH-RUBY', '0'],
      [9, 'CH-DIAM', '0.123'],
    ])
      await sql(
        `INSERT INTO "MFG_IDTL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","ISR_NO","VCH_SRNO","IT_CODE","ITM_LOT","ITM_LOT_AC_CODE","IT_GWT","RTN_GWT","BROK_WT") VALUES($1,'01','01','2024-2025',$2,$3,17,$4,0,'STONE',$5,'TOURAC',$6::numeric,NULL,0)`,
        book,
        no,
        isr,
        lot,
        weight,
      );
  }
  await sql(
    `INSERT INTO "MAIN_STOCK"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DATE","SR_NO","ISR_NO","IT_CODE","AC_CODE","ITM_LOT","TAG_NO","ITM_SIGN","ITM_PCS","ITM_GWT","ITM_NWT") VALUES($1,'01','01','2023-2024','PUR','00077','2024-03-01',17,3,'GOLD','TOURAC','LOT-READ','N','+',10,10.5,10)`,
  );
  for (const [year, book, no, sign, pcs, gwt, nwt] of [
    ['2023-2024', 'LSI', '00077', '-', 10, 10.5, 10],
    ['2024-2025', 'LSR', '00078', '+', 6, 6.4, 6.1],
  ]) {
    await sql(
      `INSERT INTO "MFG_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","OLD_SRNO","IT_CODE","ISU_IT_CODE") VALUES($1,'01','01',$2,$3,$4,17,42,'GOLD','GOLD')`,
      year,
      book,
      no,
    );
    await sql(
      `INSERT INTO "MFG_ISU_REC"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","ISR_NO","VCH_DATE","AC_CODE","KR_AC_CODE","IT_CODE","ITM_LOT","LOT_NO","IR_TYPE","ITM_SIGN","IR_PCS","IR_WT","ITM_GWT","ITM_NWT","RTN_CHOL","ITM_LOSS","IR_LC","IR_YRCD","IR_DBCD","IR_NO","IR_SRNO","IR_AC") VALUES($1,'01','01',$2,$3,$4,17,1,'2024-03-01','TOURAC','TOURAC','GOLD','LOT-READ','WORK-LOT','S',$5,$6,$7,$7,$8,0.7,0.2,'01','2023-2024','LSI','00077',42,'TOURAC')`,
      year,
      book,
      no,
      sign,
      pcs,
      gwt,
      nwt,
    );
  }
}

/** Read-only production UI journey. Every response comes from the running API/database. */
export async function exerciseMfgLot(page, { checkpoint } = {}) {
  const requests = [];
  const collect = (request) => {
    if (new URL(request.url()).pathname.startsWith('/api/mfg/lot/')) requests.push(request);
  };
  page.on('request', collect);
  const responseFor = (path) =>
    page.waitForResponse((response) => new URL(response.url()).pathname === `/api${path}`);
  const fieldValue = async (region, label, expected) => {
    const values = region
      .locator('dl > div')
      .filter({
        has: page.locator('dt', {
          hasText: new RegExp(`^${label.replace(/[.*+?^${}()|[\]\\]/g, '\\$&')}$`),
        }),
      })
      .locator('dd');
    assert((await values.allTextContents()).includes(expected), `${label}: expected ${expected}`);
  };
  try {
    for (const [kind, book, number, alternate] of [
      ['issue', 'LSI', '00001', 'LS2'],
      ['receive', 'LSR', '00002', 'LR2'],
    ]) {
      await page.goto(`/txn/mfg-lot-${kind}`);
      await page
        .getByRole('heading', {
          name: kind === 'issue' ? 'Lot Setting Issue' : 'Lot Setting Receipt',
          exact: true,
        })
        .waitFor();
      const select = page.getByLabel('Configured book', { exact: true });
      await select.locator(`option[value="${book}"]`).waitFor({ state: 'attached' });
      const [configuration] = await Promise.all([
        responseFor(`/mfg/lot/${kind}/settings`),
        select.selectOption(book),
      ]);
      assert.equal(configuration.status(), 200);
      assert.equal((await configuration.json()).writes, false);
      const [browse] = await Promise.all([
        responseFor(`/mfg/lot/${kind}/list`),
        page.getByRole('button', { name: 'Browse saved entries', exact: true }).click(),
      ]);
      assert.equal(browse.status(), 200);
      const browseJson = await browse.json();
      assert(browseJson.rows.some((row) => row.VCH_NO === number));
      assert.equal(browseJson.displayLabels.accounts.TOURAC, 'Real browser tour customer');
      await page
        .getByRole('region', { name: 'Saved lot browse', exact: true })
        .getByText('Current name: Real browser tour customer', { exact: true })
        .first()
        .waitFor();
      await page.getByLabel('Lot voucher number', { exact: true }).fill(number);
      const [loaded] = await Promise.all([
        responseFor(`/mfg/lot/${kind}/${number}`),
        page.getByRole('button', { name: 'Load lot entry', exact: true }).click(),
      ]);
      assert.equal(loaded.status(), 200);
      const loadedJson = await loaded.json();
      assert.deepEqual(
        loadedJson.components.map((row) => [row.SR_NO, row.ISR_NO, row.ITM_LOT]),
        [
          ['17', '3', 'CH-RUBY'],
          ['17', '9', 'CH-DIAM'],
        ],
      );
      const saved = page.getByRole('region', { name: 'Saved lot entry', exact: true });
      await saved.waitFor();
      assert.equal(loadedJson.header.AC_CODE, 'TOURAC');
      assert.equal(loadedJson.displayLabels.accounts.TOURAC, 'Real browser tour customer');
      assert.equal(loadedJson.displayLabels.items.GOLD, 'Gold Ring');
      await saved
        .getByText('Current name: Real browser tour customer', { exact: true })
        .first()
        .waitFor();
      await saved.getByText('Current name: Gold Ring', { exact: true }).first().waitFor();
      await fieldValue(saved, 'Net amount', '9999999999999999.99');
      await fieldValue(saved, 'Voucher time', '2024-07-01T12:13:14.123456');
      await fieldValue(saved, 'Original / source row', '42');
      await fieldValue(saved, 'Material lot', 'PARENTLOT');
      await saved.getByText('Components (2)', { exact: true }).click();
      for (const summary of await saved.locator('details > summary').all())
        if ((await summary.textContent()).trim().startsWith('Row ')) await summary.click();
      await fieldValue(saved, 'Component / stock material lot', 'CH-RUBY');
      await fieldValue(saved, 'Component / stock material lot', 'CH-DIAM');
      await saved.getByText('Current name: Diamond component', { exact: true }).first().waitFor();
      if (kind === 'receive') {
        await page.getByLabel('Lot source karigar', { exact: true }).fill('TOURAC');
        await page.getByLabel('Lot issue source book', { exact: true }).selectOption('LSI');
      }
      await page.getByLabel('Find material lot', { exact: true }).fill('LOT-READ');
      const [sourceResponse] = await Promise.all([
        responseFor(`/mfg/lot/${kind}/sources`),
        page.getByRole('button', { name: 'Find source balances', exact: true }).click(),
      ]);
      assert.equal(sourceResponse.status(), 200);
      const sources = await sourceResponse.json();
      assert.equal(sources.rows.length, 1);
      assert.equal(sources.displayLabels.items.GOLD, 'Gold Ring');
      await page
        .getByRole('region', { name: 'Lot source selection', exact: true })
        .getByText('Current name: Gold Ring', { exact: true })
        .first()
        .waitFor();
      if (kind === 'receive')
        assert.deepEqual(
          [
            sources.rows[0].sourceYear,
            sources.rows[0].sourceBook,
            sources.rows[0].sourceVoucher,
            sources.rows[0].sourceOldSrNo,
            sources.rows[0].remainingPieces,
            sources.rows[0].remainingWeight,
          ],
          ['2023-2024', 'LSI', '00077', '42', '4.000', '4.100'],
        );
      else assert.equal(sources.rows[0].remainingWeight, '10.500');
      await page.getByRole('button', { name: 'Inspect source', exact: true }).click();
      const selected = page.getByLabel('Selected lot source', { exact: true });
      await selected.waitFor();
      await selected
        .getByText(`Contributing movements (${kind === 'issue' ? 1 : 2})`, { exact: true })
        .click();
      if (checkpoint) await checkpoint(`mfg-lot-${kind}-saved-source`, page);
      await select.selectOption(alternate);
      await saved.waitFor({ state: 'detached' });
      await selected.waitFor({ state: 'detached' });
      await page.getByLabel('Lot voucher number', { exact: true }).fill(number);
      const [missing] = await Promise.all([
        responseFor(`/mfg/lot/${kind}/${number}`),
        page.getByRole('button', { name: 'Load lot entry', exact: true }).click(),
      ]);
      assert.equal(missing.status(), 404);
      assert.equal(
        await page.getByRole('region', { name: 'Saved lot entry', exact: true }).count(),
        0,
      );
    }
    assert(requests.length > 0);
    assert(
      requests.every((request) => request.method() === 'GET'),
      'lot read journey must never submit a mutation',
    );
    return {
      checks: [
        'configured Setting issue and receipt books',
        'lossless saved decimal/date/null values',
        'noncontiguous parent and two distinct component lots',
        'historical source identity and pieces-based receipt availability',
        'stock contributor identities',
        'scoped current account/item names remain separate from saved codes',
        'scope change and failed lookup clear previous saved/source record',
        'GET-only real browser journey',
      ],
      boundary: 'Saved/source review only; no manufacturing write or desktop acceptance claim',
    };
  } finally {
    page.off('request', collect);
  }
}
