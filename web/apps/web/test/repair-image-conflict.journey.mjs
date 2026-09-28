import assert from 'node:assert/strict';
import { readFileSync } from 'node:fs';
import { request as requestFactory } from 'playwright';

const png = readFileSync(
  new URL('../../api/test/fixtures/order-design-portrait.png', import.meta.url),
);
const jpeg = readFileSync(
  new URL('../../api/test/fixtures/order-tag-landscape.jpg', import.meta.url),
);
export const repairImageFixtureTables = ['REP_IMAGE', 'REP_DETL', 'REP_DATA'];
export const repairImageFixture = {
  coCode: '01',
  lcCode: '01',
  coYear: '2024-2025',
  coBook: 'R51',
  voucherNo: '00021',
  source: { imageBook: 'R52', imageYear: '2023-2024', vchNo: '00011', srNo: 17 },
};

/** Only this disposable fixture's records; sql supplies tenant as $1. */
export async function cleanupRepairImageConflict(sql) {
  for (const table of repairImageFixtureTables)
    await sql(
      `DELETE FROM "${table}" WHERE tenant_id=$1 AND "CO_CODE"='01' AND "LC_CODE"='01' AND "CO_BOOK" IN ('R51','R52')`,
    );
  await sql(
    `DELETE FROM "ENTITY_IMAGE_REVISION" WHERE tenant_id=$1 AND "CO_CODE"='01' AND "LC_CODE"='01' AND "ENTITY_TYPE"='REPAIR' AND "ENTITY_KEY" IN ($2,$3,$4,$5)`,
    ...[
      ['2023-2024', 'R52', '00011', 17],
      ['2023-2024', 'R52', '00011', 23],
      ['2024-2025', 'R52', '00011', 17],
      ['2024-2025', 'R51', '00021', 42],
    ].map((key) => JSON.stringify(key)),
  );
  await sql(
    `DELETE FROM "BOOK_DATA" WHERE tenant_id=$1 AND "CO_CODE"='01' AND "LC_CODE"='01' AND "CO_BOOK" IN ('R51','R52')`,
  );
  await sql(
    `DELETE FROM "AC_MAST" WHERE tenant_id=$1 AND "CO_CODE"='01' AND "AC_CODE" IN ('R5CUS','R5KAR')`,
  );
}

/** Source-shaped saved chain for image hydration only; this does not certify repair conversion. */
export async function seedRepairImageConflict(sql) {
  await cleanupRepairImageConflict(sql);
  await sql(`INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME","MAIN_BOOK","BOOK_INOUT","CUR_USE","BOOK_TBL_NAME")
    VALUES($1,'01','01','R51','R5 Karigar Issue','RKI','KRREP ISSUE','O','Y','REP_DATA'),
          ($1,'01','01','R52','R5 Customer Receipt','RCR','CUSTREP RECEIPT','I','Y','REP_DATA')`);
  await sql(
    `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","AC_CODE","AC_NAME") VALUES($1,'01','R5CUS','Repair image customer'),($1,'01','R5KAR','Repair image karigar')`,
  );
  await sql(`INSERT INTO "REP_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","HD_VCH_NO","VCH_DATE","BOOK_NAME","AC_CODE","AC_NAME","VCH_DESC")
    VALUES($1,'01','01','2023-2024','R52','00011','00071','2023-07-01','CUSTREP RECEIPT','R5CUS','Repair image customer','Historical image source'),
          ($1,'01','01','2024-2025','R52','00011','00072','2024-07-01','CUSTREP RECEIPT','R5CUS','Repair image customer','Other year sentinel'),
          ($1,'01','01','2024-2025','R51','00021','00081','2024-07-02','KRREP ISSUE','R5KAR','Repair image karigar','Saved source-image chain')`);
  for (const [year, sr, name, gwt, nwt, issued] of [
    ['2023-2024', 17, 'Historical repair ring', 5.125, 4.125, 'Y'],
    ['2023-2024', 23, 'Historical repair chain', 8.375, 7.375, 'Y'],
    ['2024-2025', 17, 'Current year sentinel ring', 3.234, 2.234, 'N'],
  ])
    await sql(
      `INSERT INTO "REP_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","HD_VCH_NO","SR_NO","OLD_SRNO","VCH_DATE","BOOK_NAME","AC_CODE","IT_CODE","IT_NAME","IT_DESC","ITM_PCS","ITM_GWT","ITM_OTH_WT","ITM_NWT","ITM_TOUCH","ITM_FINE","ISU_ADJ")
      VALUES($1,'01','01',$2,'R52','00011',CASE WHEN $2='2023-2024' THEN '00071' ELSE '00072' END,$3,$3,($4)::date,'CUSTREP RECEIPT','R5CUS','GOLD',$5,'Preserve saved repair description',1,$6,1,$7,91.6,3.141,$8)`,
      year,
      sr,
      year === '2023-2024' ? '2023-07-01' : '2024-07-01',
      name,
      gwt,
      nwt,
      issued,
    );
  await sql(
    `UPDATE "REP_DETL" SET "ISU_NO"='00021',"ISU_SRNO"=CASE WHEN "SR_NO"=17 THEN 42 ELSE 66 END,"ISU_LC"='01',"ISU_YRCD"='2024-2025',"ISU_DBCD"='R51',"ISU_AC_CODE"='R5KAR',"ISU_AC_NAME"='Repair image karigar',"ISU_HD_VCH_NO"='00081' WHERE tenant_id=$1 AND "CO_CODE"='01' AND "LC_CODE"='01' AND "CO_YEAR"='2023-2024' AND "CO_BOOK"='R52' AND "VCH_NO"='00011' AND "SR_NO" IN (17,23)`,
  );
  for (const [issueSr, sourceSr, name, gwt, nwt] of [
    [42, 17, 'Historical repair ring', 5.125, 4.125],
    [66, 23, 'Historical repair chain', 8.375, 7.375],
  ])
    await sql(
      `INSERT INTO "REP_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","HD_VCH_NO","SR_NO","OLD_SRNO","VCH_DATE","BOOK_NAME","AC_CODE","IT_CODE","IT_NAME","IT_DESC","ITM_PCS","ITM_GWT","ITM_OTH_WT","ITM_NWT","ITM_TOUCH","ITM_FINE","REP_LC","REP_YRCD","REP_DBCD","REP_NO","REP_SRNO","REP_HD_VCH_NO","REP_AC_CODE","REP_AC_NAME")
      VALUES($1,'01','01','2024-2025','R51','00021','00081',$2,$2,'2024-07-02','KRREP ISSUE','R5KAR','GOLD',$3,'Preserve saved repair description',1,$4,1,$5,91.6,3.141,'01','2023-2024','R52','00011',$6,'00071','R5CUS','Repair image customer')`,
      issueSr,
      name,
      gwt,
      nwt,
      sourceSr,
    );
  // Source17 starts absent; sibling, same key in another year, and current stage each have distinct owners.
  for (const [year, book, vch, sr, bytes, mime] of [
    ['2023-2024', 'R52', '00011', 23, jpeg, 'image/jpeg'],
    ['2024-2025', 'R52', '00011', 17, png, 'image/png'],
    ['2024-2025', 'R51', '00021', 42, jpeg, 'image/jpeg'],
  ])
    await sql(
      `INSERT INTO "REP_IMAGE"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","IMAGE_NO","IMAGE_TYPE","MIME_TYPE","IMAGE_SIZE","REP_IMAGE")
      VALUES($1,'01','01',$2,$3,$4,$5,$6,'ReparingImage',$7,$8,$9)`,
      year,
      book,
      vch,
      sr,
      `0101${year.slice(0, 4)}${book}${vch}${sr}`,
      mime,
      bytes.length,
      bytes,
    );
}

export async function exerciseRepairImageConflict(page, { checkpoint, holdRepairReads } = {}) {
  assert.equal(
    typeof holdRepairReads,
    'function',
    'Runner must provide a real isolated database read hold',
  );
  const f = repairImageFixture;
  const scope = { coCode: f.coCode, lcCode: f.lcCode, coYear: f.coYear, coBook: f.coBook };
  const source = f.source;
  const endpoint = '/api/repair-images';
  const requests = [];
  const errors = [];
  const onError = (error) => errors.push(error.message);
  const onRequest = (request) => {
    if ([endpoint, `${endpoint}/state`].includes(new URL(request.url()).pathname))
      requests.push(request);
  };
  page.on('request', onRequest);
  page.on('pageerror', onError);
  const otherClient = await requestFactory.newContext({
    baseURL: new URL(page.url()).origin,
    storageState: await page.context().storageState(),
  });
  const read = async (key = source) => {
    const response = await otherClient.get(
      `${endpoint}/state?${new URLSearchParams({ ...scope, ...key })}`,
    );
    assert.equal(response.status(), 200, await response.text());
    const state = await response.json();
    assert.match(state.version, /^[0-9a-f]{64}$/);
    return state;
  };
  const savedIssue = async () => {
    const response = await otherClient.get(
      `/api/repair-karigar-issues/${f.voucherNo}?${new URLSearchParams(scope)}`,
    );
    assert.equal(response.status(), 200, await response.text());
    return response.json();
  };
  const ready = (id = 'repair-issue-image') =>
    page.waitForFunction((id) => {
      const input = document.querySelector(`[data-testid="${id}-file"]`);
      return input && !input.disabled;
    }, id);
  const preview = async (bytes, mime, id = 'repair-issue-image') => {
    await page.waitForFunction(
      ({ src, id }) => {
        const image = document.querySelector(`[data-testid="${id}-preview"]`);
        return image?.complete && image.naturalWidth > 0 && image.src === src;
      },
      { src: `data:${mime};base64,${bytes.toString('base64')}`, id },
    );
    await ready(id);
  };
  const action = async (method, act) => {
    const [response] = await Promise.all([
      page.waitForResponse(
        (response) =>
          new URL(response.url()).pathname === endpoint && response.request().method() === method,
      ),
      act(),
    ]);
    return response;
  };
  const upload = () =>
    action('POST', () =>
      page
        .getByTestId('repair-issue-image-file')
        .setInputFiles({ name: 'operator-repair.png', mimeType: 'image/png', buffer: png }),
    );
  const remoteUpload = async () => {
    const before = await read();
    const response = await otherClient.post(endpoint, {
      data: {
        ...scope,
        ...source,
        version: before.version,
        data: jpeg.toString('base64'),
        mimeType: 'image/jpeg',
      },
    });
    assert.equal(response.status(), 200, await response.text());
    const after = await read();
    assert.notEqual(after.version, before.version);
    assert.equal(after.image.data, jpeg.toString('base64'));
    return after;
  };
  const conflict = async (response, current) => {
    assert.equal(response.status(), 409, await response.text());
    assert.equal((await response.json()).error, 'image-version-conflict');
    await page.getByTestId('repair-issue-image-conflict').waitFor();
    assert.match(
      await page.getByTestId('repair-issue-image-error').innerText(),
      /chang|reload|conflict/i,
    );
    assert.deepEqual(
      await read(),
      current,
      'Stale mutation preserves newer bytes, metadata, permissions and token',
    );
  };
  const reload = async () => {
    const before = requests.filter((request) => request.method() !== 'GET').length;
    await page.getByTestId('repair-issue-image-reload').click();
    await preview(jpeg, 'image/jpeg');
    assert.equal(
      requests.filter((request) => request.method() !== 'GET').length,
      before,
      'Reload never resends the pending change',
    );
  };
  try {
    const initial = await savedIssue();
    assert.deepEqual(
      initial.lines.map((line) => [
        line.issueSrNo,
        line.coYear,
        line.coBook,
        line.voucherNo,
        line.srNo,
      ]),
      [
        [42, '2023-2024', 'R52', '00011', 17],
        [66, '2023-2024', 'R52', '00011', 23],
      ],
    );
    const sentinels = [
      { ...source, srNo: 23 },
      { ...source, imageYear: scope.coYear },
      { imageBook: 'R51', imageYear: scope.coYear, vchNo: f.voucherNo, srNo: 42 },
    ];
    const beforeSentinels = await Promise.all(sentinels.map(read));
    await page.goto('/txn/repair-karigar-issue');
    await page
      .getByRole('heading', { name: 'Repairing Issued — Karigar Issue', exact: true })
      .waitFor();
    await page.getByLabel('Configured book').selectOption(f.coBook);
    await page.getByTestId('repair-issue-load-voucher').fill(f.voucherNo);
    const [loaded] = await Promise.all([
      page.waitForResponse(
        (response) =>
          new URL(response.url()).pathname === `/api/repair-karigar-issues/${f.voucherNo}` &&
          response.request().method() === 'GET',
      ),
      page.getByRole('button', { name: 'Load', exact: true }).click(),
    ]);
    assert.equal(loaded.status(), 200, await loaded.text());
    const firstRow = page
      .getByTestId('repair-issue-grid')
      .locator('tr')
      .nth(0)
      .locator('input')
      .first();
    await firstRow.focus();
    assert.equal(await firstRow.inputValue(), '2023-2024/R52/00011/17');
    await ready();
    await page.getByTestId('repair-issue-image-empty').waitFor();
    const firstUpload = await upload();
    assert.equal(firstUpload.status(), 200, await firstUpload.text());
    await preview(png, 'image/png');
    const changed = await remoteUpload();
    await conflict(await upload(), changed);
    await page.getByTestId('repair-issue-image').scrollIntoViewIfNeeded();
    await checkpoint?.('repair-image-source-conflict-round5', page);
    await reload();
    const retry = await action('POST', () =>
      page.getByTestId('repair-issue-image-retry-upload').click(),
    );
    assert.equal(retry.status(), 200, await retry.text());
    await preview(png, 'image/png');
    assert.equal((await read()).image.data, png.toString('base64'));
    const forDelete = await remoteUpload();
    page.once('dialog', (dialog) => dialog.accept());
    await conflict(
      await action('DELETE', () => page.getByTestId('repair-issue-image-delete').click()),
      forDelete,
    );
    await reload();
    page.once('dialog', (dialog) => dialog.accept());
    const removed = await action('DELETE', () =>
      page.getByTestId('repair-issue-image-delete').click(),
    );
    assert.equal(removed.status(), 200, await removed.text());
    await page.getByTestId('repair-issue-image-empty').waitFor();
    assert.equal((await read()).image.state, 'absent');
    await page
      .getByTestId('repair-issue-grid')
      .locator('tr')
      .nth(1)
      .locator('input')
      .first()
      .focus();
    await preview(jpeg, 'image/jpeg');
    assert.equal(await page.getByTestId('repair-issue-image-conflict').count(), 0);
    assert.equal(await page.getByTestId('repair-issue-image-retry-upload').count(), 0);
    assert.deepEqual(
      await Promise.all(sentinels.map(read)),
      beforeSentinels,
      'Sibling, same source key in current year, and current-stage photos remain unchanged',
    );
    assert.deepEqual(
      await savedIssue(),
      initial,
      'Image actions preserve the complete hydrated issue and exact original source references',
    );
    const issueRequests = requests.slice();

    // Current-year receipt uses an imported noncontiguous saved SR17, never display-row index + 1.
    await page.goto('/txn/repair-receipt');
    await page.getByLabel('Configured book').selectOption('R52');
    await page.getByTestId('repair-load-voucher').fill('00011');
    const [receipt] = await Promise.all([
      page.waitForResponse(
        (response) =>
          new URL(response.url()).pathname === '/api/repair-receipts/00011' &&
          response.request().method() === 'GET',
      ),
      page.getByRole('button', { name: 'Load', exact: true }).click(),
    ]);
    assert.equal(receipt.status(), 200, await receipt.text());
    assert.equal((await receipt.json()).lines[0].srNo, 17);
    await preview(png, 'image/png', 'repair-image');
    await page.getByTestId('repair-image').scrollIntoViewIfNeeded();
    await checkpoint?.('repair-image-receipt-saved-serial-round5', page);

    // Keep the actual database read behind a short lock while the operator cancels the draft.
    // The runner owns the transaction; this journey never intercepts or fabricates an HTTP response.
    await page.getByRole('button', { name: 'Load', exact: true }).scrollIntoViewIfNeeded();
    const releaseRead = await holdRepairReads();
    let responseArrived = false;
    const lateResponse = page.waitForResponse(
      (response) =>
        new URL(response.url()).pathname === '/api/repair-receipts/00011' &&
        response.request().method() === 'GET',
    );
    void lateResponse.then(
      () => {
        responseArrived = true;
      },
      () => {},
    );
    try {
      await Promise.all([
        page.waitForRequest(
          (request) =>
            new URL(request.url()).pathname === '/api/repair-receipts/00011' &&
            request.method() === 'GET',
          { timeout: 2500 },
        ),
        page.getByRole('button', { name: 'Load', exact: true }).click({ timeout: 1500 }),
      ]);
      assert.equal(
        responseArrived,
        false,
        'The real receipt response is still held when Cancel is clicked',
      );
      await page.getByRole('button', { name: 'Cancel', exact: true }).click({ timeout: 1500 });
      assert.equal(await page.getByTestId('repair-load-voucher').inputValue(), '');
    } finally {
      await releaseRead();
    }
    const completed = await lateResponse;
    assert.equal(completed.status(), 200, await completed.text());
    await completed.finished();
    // Allow the real fetch/JSON continuation and React commit to finish before checking its result.
    await page.evaluate(
      () => new Promise((resolve) => requestAnimationFrame(() => requestAnimationFrame(resolve))),
    );
    assert.equal(
      await page.getByTestId('repair-load-voucher').inputValue(),
      '',
      'Late read must not restore the cancelled voucher number',
    );
    assert.equal(await page.getByPlaceholder('auto', { exact: true }).inputValue(), '');
    assert.equal(
      await page.getByTestId('repair-items-grid').locator('input').first().inputValue(),
      '',
      'Cancelled draft remains a blank repair row',
    );
    assert.equal(await page.getByTestId('repair-saved').count(), 0);
    assert.equal(
      await page.getByTestId('repair-image-preview').count(),
      0,
      'Late read must not restore a cancelled saved photo',
    );
    assert.equal(
      await page.getByTestId('repair-image-file').count(),
      0,
      'Cancelled draft cannot mutate the former image identity',
    );
    await checkpoint?.('repair-image-cancel-late-load-round5', page);
    for (const request of requests) {
      const parameters =
        request.method() === 'GET'
          ? Object.fromEntries(new URL(request.url()).searchParams)
          : request.postDataJSON();
      for (const field of ['coCode', 'lcCode', 'coYear'])
        assert.equal(parameters[field], scope[field], `${request.method()} ${field}`);
      assert.equal(parameters.coBook, 'R52');
      assert.equal(parameters.imageBook, 'R52');
      assert.equal(parameters.vchNo, '00011');
      if (issueRequests.includes(request)) {
        assert.equal(parameters.imageYear, '2023-2024');
        assert([17, 23].includes(Number(parameters.srNo)));
      } else {
        assert.equal(parameters.imageYear ?? parameters.coYear, scope.coYear);
        assert.equal(Number(parameters.srNo), 17);
      }
      if (request.method() !== 'GET') assert.match(parameters.version, /^[0-9a-f]{64}$/);
    }
    assert.deepEqual(errors, []);
    return {
      mockedResponses: 0,
      imageRequests: requests.length,
      checks: [
        'actual saved Karigar Issue hydrates noncontiguous rows and original receipt year/book/serial',
        'initial source-photo state and browser upload use the original saved receipt identity',
        'independent authenticated client replacement causes stale browser upload409 without data loss',
        'readable conflict reloads only; explicit retained-file Retry upload saves current version',
        'stale confirmed Delete is refused; Reload then explicit confirmed Delete succeeds',
        'sibling, other-year and current-stage photo bytes and versions remain unchanged',
        'image operations preserve the complete saved issue DTO and all source references',
        'Customer Receipt loads image with imported savedSR17 rather than visible row index1',
        'Cancel during a real database-delayed receipt read prevents its late response restoring the voucher or photo',
        'all production image requests preserve authenticated scope and explicit original image identity',
      ],
    };
  } finally {
    page.off('request', onRequest);
    page.off('pageerror', onError);
    await otherClient.dispose();
  }
}
