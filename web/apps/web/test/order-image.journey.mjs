import assert from 'node:assert/strict';
import { readFileSync } from 'node:fs';

const portrait = readFileSync(
  new URL('../../api/test/fixtures/order-design-portrait.png', import.meta.url),
);
const landscape = readFileSync(
  new URL('../../api/test/fixtures/order-tag-landscape.jpg', import.meta.url),
);
const designId = '01_IMAGE-CATALOG-LONG_01_ORD-DESIGN-0001';
const voucherNo = '00021';
const scope = { coCode: '01', lcCode: '01', coYear: '2024-2025' };
const query = (coBook) => new URLSearchParams({ ...scope, coBook }).toString();

/** Called only by the isolated real-stack runner's tenant-bound SQL helper, after other journeys. */
export async function seedOrderImageJourney(sql) {
  await sql(`INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","MAIN_BOOK","BOOK_INOUT","CUR_USE","BOOK_TBL_NAME","BOOK_TBL_DETL")
    VALUES($1,'01','01','S91','Image Sales Order','SALES ORDER','O','Y','SL_ORD_DATA','SL_ORD_DETL'),
          ($1,'01','01','Z10','Second Tour Order','TOUR ORDER','I','Y','SL_ORD_DATA','SL_ORD_DETL')`);
  await sql(`INSERT INTO "CO_SET_NEW"(tenant_id,"CO_CODE","ORD_IMG_PRINT") VALUES($1,'01','Y')`);
  await sql(
    `INSERT INTO "DESIGN_DETL"(tenant_id,"CO_CODE","BOOK_NAME","PR_CODE","SR_NO","DESIGN_NO","DESIGN_IMG_ID")
    VALUES($1,'01','IMAGE-CATALOG-LONG','01',1,'ORD-DESIGN-0001',$2)`,
    designId,
  );
  const insertImage = async (type, lcCode, key, instance, bytes, mimeType) =>
    sql(
      `INSERT INTO "ENTITY_IMAGE"
    (tenant_id,"CO_CODE","LC_CODE","ENTITY_TYPE","ENTITY_KEY","INSTANCE","IMAGE_TYPE","MIME_TYPE","IMAGE_SIZE","IMAGE_BYTES")
    VALUES($1,'01',$2,$3,$4,$5,$6,$7,$8,$9)`,
      lcCode,
      type,
      key,
      instance,
      type === 'DESIGN' ? 'D' : 'T',
      mimeType,
      bytes.length,
      bytes,
    );
  await insertImage('DESIGN', '', designId, 0, portrait, 'image/png');
  await insertImage('TAG', '01', 'IMG-TAG-01', 3, landscape, 'image/jpeg');
  await sql(
    `INSERT INTO "TAG_IMAGE_DATA"(tenant_id,"CO_CODE","LC_CODE","TAG_NO","VCH_SRNO","IMAGE_TYPE") VALUES($1,'01','01','IMG-TAG-01',3,'T')`,
  );
  for (const coBook of ['S91', 'Z09', 'Z10']) {
    const hidden = coBook === 'Z10' ? 'H0022' : 'H0021';
    await sql(
      `INSERT INTO "SL_ORD_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","HD_VCH_NO","VCH_DATE","VCH_TIME","AC_CODE","AC_NAME","NET_AMT","TOT_AMT","TAX_AMT")
      VALUES($1,'01','01','2024-2025',$2,'00021',$3,'2024-07-11','2024-07-11 12:30:00','TOURAC','Saved image customer',300,300,0)`,
      coBook,
      hidden,
    );
    await sql(
      `INSERT INTO "SL_ORD_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","HD_VCH_NO","SR_NO","IT_CODE","DESIGN_NO","DESIGN_IMG_ID","TAG_NO","VCH_SRNO","ITM_PCS","ITM_GWT","ITM_NWT","NET_AMT")
      VALUES($1,'01','01','2024-2025',$2,'00021',$3,17,'GOLD','ORD-DESIGN-0001',$4,'IMG-TAG-01',3,1,1,1,100),
            ($1,'01','01','2024-2025',$2,'00021',$3,33,'GOLD','CUSTOM-ORDER','N','',0,1,2,2,200)`,
      coBook,
      hidden,
      designId,
    );
    await sql(
      `INSERT INTO "SL_ORD_IDTL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","ISR_NO","IT_CODE","IT_PCS","IT_GWT")
      VALUES($1,'01','01','2024-2025',$2,'00021',17,1,'STONE',1,0.123),
            ($1,'01','01','2024-2025',$2,'00021',17,2,'STONE',2,0.456)`,
      coBook,
    );
  }
  await sql(`INSERT INTO "SL_ORD_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","HD_VCH_NO","SR_NO","IT_CODE","DESIGN_NO","DESIGN_IMG_ID","TAG_NO","VCH_SRNO","ITM_PCS","ITM_GWT","ITM_NWT","NET_AMT")
    VALUES($1,'01','01','2024-2025','Z10','00021','H0022',50,'GOLD','LOST-PHOTO','N','IMG-MISSING',7,1,0,0,0)`);
  await sql(`INSERT INTO "TAG_IMAGE_DATA"(tenant_id,"CO_CODE","LC_CODE","TAG_NO","VCH_SRNO","IMAGE_TYPE")
    VALUES($1,'01','01','IMG-MISSING',7,'T')`);
  await sql(
    `INSERT INTO "SL_ORD_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","HD_VCH_NO","SR_NO","IT_CODE","DESIGN_NO","DESIGN_IMG_ID","TAG_NO","VCH_SRNO","ITM_PCS","ITM_GWT","ITM_NWT","NET_AMT")
    VALUES($1,'01','01','2024-2025','Z10','00021','H0022',66,'GOLD','MASTER-FALLBACK',$2,'',0,1,0,0,0)`,
    designId,
  );
}

/** Real browser, real JSON endpoints and actual saved bytes. No API responses are replaced. */
export async function exerciseOrderImages(page, options = {}) {
  const requests = [];
  const captureRequest = (request) => {
    const url = new URL(request.url());
    if (!/^\/api\/(sales-orders|tour-orders)\/\d+\/image$/.test(url.pathname)) return;
    requests.push({
      method: request.method(),
      path: url.pathname,
      scope: Object.fromEntries(url.searchParams),
      ...(request.method() === 'POST'
        ? { fields: Object.keys(request.postDataJSON()).sort() }
        : {}),
    });
  };
  page.on('request', captureRequest);
  const preview = (name) => page.getByTestId(`${name}-preview`);
  const waitImage = async (name, bytes, mimeType) => {
    await page.waitForFunction(
      ({ testId, data }) => {
        const image = document.querySelector(`[data-testid="${testId}-preview"]`);
        return image?.getAttribute('src') === data && image.complete && image.naturalWidth > 0;
      },
      { testId: name, data: `data:${mimeType};base64,${bytes.toString('base64')}` },
    );
    await page.getByTestId(name).scrollIntoViewIfNeeded();
  };
  const change = async (name, bytes, mimeType, method = 'POST') => {
    const response = page.waitForResponse(
      (response) => /\/image\?/.test(response.url()) && response.request().method() === method,
    );
    if (method === 'POST')
      await page.getByTestId(`${name}-file`).setInputFiles({
        name: 'actual-photo.' + (mimeType === 'image/png' ? 'png' : 'jpg'),
        mimeType,
        buffer: bytes,
      });
    else {
      page.once('dialog', (dialog) => {
        assert.equal(dialog.type(), 'confirm');
        assert.equal(dialog.message(), 'Are you sure you want to delete this image?');
        void dialog.accept();
      });
      await page.getByTestId(`${name}-delete`).click();
    }
    const saved = await response;
    assert.equal(saved.status(), 200, await saved.text());
  };
  try {
    await page.goto('/txn/sales-order');
    const newDesignImage = page
      .locator('details')
      .filter({ has: page.locator('summary', { hasText: 'Item 1 specifications and components' }) })
      .locator('.field')
      .filter({ has: page.getByText('Design Image', { exact: true }) })
      .locator('input');
    assert.equal(
      await newDesignImage.inputValue(),
      'N',
      'desktop new Sales row sentinel allows a custom saved image',
    );
    await page.getByLabel('Configured book', { exact: true }).selectOption('S91');
    await page.getByTestId('sales-order-image-lookup').fill(voucherNo);
    await page.getByRole('button', { name: 'Load order', exact: true }).click();
    const sales = page.getByTestId('sales-order-saved-images');
    await waitImage('sales-order-image', portrait, 'image/png');
    assert.equal(
      await page.getByTestId('sales-order-image-file').isDisabled(),
      true,
      'shared Design Book image is read-only from order',
    );
    assert.equal(await page.getByTestId('sales-order-image-delete').isDisabled(), true);
    assert.match(await page.getByTestId('sales-order-image-reason').innerText(), /Design Book/);
    await options.checkpoint?.('order-image-sales-design-readonly', page);
    await sales.getByTestId('sales-order-image-parent').selectOption('33');
    await page.getByTestId('sales-order-image-empty').waitFor();
    await change('sales-order-image', landscape, 'image/jpeg');
    await waitImage('sales-order-image', landscape, 'image/jpeg');
    const deletesBeforeCancel = requests.filter((request) => request.method === 'DELETE').length;
    let cancelPromptShown = false;
    page.once('dialog', (dialog) => {
      assert.equal(dialog.type(), 'confirm');
      assert.equal(dialog.message(), 'Are you sure you want to delete this image?');
      cancelPromptShown = true;
      void dialog.dismiss();
    });
    await page.getByTestId('sales-order-image-delete').click();
    assert.equal(cancelPromptShown, true, 'image deletion requires the desktop confirmation');
    const retained = await page.request.get(
      `/api/sales-orders/${voucherNo}/image?${query('S91')}&srNo=33`,
    );
    assert.equal(retained.status(), 200, await retained.text());
    const retainedImage = (await retained.json()).image;
    assert.equal(retainedImage.state, 'present');
    assert.equal(retainedImage.mimeType, 'image/jpeg');
    assert.equal(retainedImage.data, landscape.toString('base64'));
    await waitImage('sales-order-image', landscape, 'image/jpeg');
    assert.equal(
      requests.filter((request) => request.method === 'DELETE').length,
      deletesBeforeCancel,
      'cancelling image deletion sends no mutation and retains the saved bytes',
    );
    await change('sales-order-image', null, '', 'DELETE');
    await page.getByTestId('sales-order-image-empty').waitFor();

    await page.goto('/txn/tour-order');
    const book = page.getByLabel('Configured book', { exact: true });
    await book.locator('option[value="Z09"]').waitFor({ state: 'attached' });
    await book.selectOption('Z09');
    const loadTour = async () => {
      await page.getByLabel('Order number', { exact: true }).fill(voucherNo);
      await page.getByRole('button', { name: 'Load order', exact: true }).click();
      await page.getByText(`Editing order #${voucherNo}`, { exact: true }).waitFor();
    };
    await loadTour();
    await waitImage('tour-order-image', landscape, 'image/jpeg');
    assert.match(await page.getByTestId('tour-order-image-source').innerText(), /Tag/);
    assert(
      !/live/.test(await page.getByTestId('tour-order-image-camera-status').innerText()),
      'no camera is claimed live without permission',
    );
    // Valid MIME/magic with no image payload exercises the server's full decoder, not merely file extension checks.
    const malformed = page.waitForResponse(
      (response) => /\/image\?/.test(response.url()) && response.request().method() === 'POST',
    );
    await page.getByTestId('tour-order-image-file').setInputFiles({
      name: 'broken.png',
      mimeType: 'image/png',
      buffer: portrait.subarray(0, 8),
    });
    const rejected = await malformed;
    assert.equal(rejected.status(), 422);
    const diagnostic = await rejected.json();
    assert.equal(diagnostic.error, 'OrderImageError');
    assert.equal(diagnostic.code, 'invalid-image');
    assert.match(diagnostic.message, /complete JPEG or PNG/);
    const stillSaved = await page.request.get(
      `/api/tour-orders/${voucherNo}/image?${query('Z09')}&srNo=17`,
    );
    assert.equal(stillSaved.status(), 200, await stillSaved.text());
    const savedImage = (await stillSaved.json()).image;
    assert.equal(savedImage.state, 'present');
    assert.equal(savedImage.mimeType, 'image/jpeg');
    assert.equal(
      savedImage.data,
      landscape.toString('base64'),
      'decoder refusal must leave stored bytes unchanged',
    );
    await page.getByTestId('tour-order-image-error').waitFor();
    await waitImage('tour-order-image', landscape, 'image/jpeg');
    await change('tour-order-image', portrait, 'image/png');
    await waitImage('tour-order-image', portrait, 'image/png');

    // Keep a real File read pending, move the selected saved row, then release it. No wrong-parent POST may be sent.
    await page.evaluate(() => {
      const original = File.prototype.arrayBuffer;
      window.__orderImageReadStarted = false;
      File.prototype.arrayBuffer = async function () {
        window.__orderImageReadStarted = true;
        await new Promise((resolve) => {
          window.__releaseOrderImageRead = resolve;
        });
        const bytes = await original.call(this);
        window.__orderImageReadFinished = true;
        return bytes;
      };
      window.__restoreOrderImageFile = () => {
        File.prototype.arrayBuffer = original;
      };
    });
    const before = requests.filter((request) => request.method === 'POST').length;
    await page
      .getByTestId('tour-order-image-file')
      .setInputFiles({ name: 'delayed.jpg', mimeType: 'image/jpeg', buffer: landscape });
    await page.waitForFunction(() => window.__orderImageReadStarted);
    await page.getByLabel('Design item 2', { exact: true }).focus();
    await page.getByTestId('tour-order-image-empty').waitFor();
    await page.evaluate(() => {
      window.__releaseOrderImageRead();
      window.__restoreOrderImageFile();
    });
    await page.waitForFunction(() => window.__orderImageReadFinished);
    assert.equal(
      requests.filter((request) => request.method === 'POST').length,
      before,
      'cancelled file read must not upload against a different saved parent',
    );
    assert.match(await page.getByTestId('tour-order-image-identity').innerText(), /item 33/);
    await change('tour-order-image', landscape, 'image/jpeg');
    await waitImage('tour-order-image', landscape, 'image/jpeg');
    await options.checkpoint?.('order-image-tour-custom', page);

    const printed = await page.request.get(
      `/api/tour-orders/confirmation?${query('Z09')}&vchNo=${voucherNo}&format=html`,
    );
    assert.equal(printed.status(), 200, await printed.text());
    const html = await printed.text();
    assert(html.includes('<title>TourOrdImg</title>'));
    assert.equal((html.match(/<img /g) || []).length, 2);
    assert(html.includes(`data:image/png;base64,${portrait.toString('base64')}`));
    assert(html.includes(`data:image/jpeg;base64,${landscape.toString('base64')}`));
    assert.equal(
      (html.match(/data-kind="Detail"/g) || []).length,
      2,
      'real component rows remain distinct',
    );

    // Actual network latency checks that book switching clears the previously loaded image immediately.
    const network = await page.context().newCDPSession(page);
    try {
      await network.send('Network.enable');
      await network.send('Network.emulateNetworkConditions', {
        offline: false,
        latency: 600,
        downloadThroughput: -1,
        uploadThroughput: -1,
      });
      await book.selectOption('Z10');
      assert.equal(await preview('tour-order-image').count(), 0);
      await loadTour();
      await page.getByLabel('Design item 2', { exact: true }).focus();
      await page.getByTestId('tour-order-image-empty').waitFor();
      assert.equal(
        await preview('tour-order-image').count(),
        0,
        'same visible voucher/design in another book has its own custom image identity',
      );
    } finally {
      await network.send('Network.emulateNetworkConditions', {
        offline: false,
        latency: 0,
        downloadThroughput: -1,
        uploadThroughput: -1,
      });
      await network.detach();
    }
    await page.getByLabel('Design item 3', { exact: true }).focus();
    await page.getByTestId('tour-order-image-unavailable').waitFor();
    assert.equal(
      await page.getByTestId('tour-order-image-file').isEnabled(),
      true,
      'missing imported bytes can be replaced using saved ownership',
    );
    await change('tour-order-image', portrait, 'image/png');
    await waitImage('tour-order-image', portrait, 'image/png');
    assert.equal(await page.getByTestId('tour-order-image-unavailable').count(), 0);
    await options.checkpoint?.('order-image-missing-import-recovered', page);
    await page.getByLabel('Design item 4', { exact: true }).focus();
    await page.waitForFunction(() =>
      document
        .querySelector('[data-testid="tour-order-image-identity"]')
        ?.textContent.includes('item 66'),
    );
    await waitImage('tour-order-image', portrait, 'image/png');
    assert.match(await page.getByTestId('tour-order-image-source').innerText(), /Design Book/);
    assert.equal(
      await page.getByTestId('tour-order-image-file').isEnabled(),
      true,
      'the custom target may receive an override',
    );
    assert.equal(
      await page.getByTestId('tour-order-image-delete').isDisabled(),
      true,
      'the fallback master is not owned by the custom target',
    );
    for (const request of requests) {
      assert.equal(request.scope.coCode, scope.coCode);
      assert.equal(request.scope.lcCode, scope.lcCode);
      assert.equal(request.scope.coYear, scope.coYear);
      assert(['S91', 'Z09', 'Z10'].includes(request.scope.coBook));
      assert(['17', '33', '50', '66'].includes(request.scope.srNo));
      if (request.method === 'POST')
        assert.deepEqual(request.fields, ['data', 'mimeType', 'version']);
    }
    return {
      voucherNo,
      requests,
      checks: [
        'new Sales row carries the source no-master sentinel N',
        'long shared Design Book identity is read-only',
        'saved custom Sales upload/read/delete',
        'source image delete confirmation cancels without mutation and accepts actual deletion',
        'Tour exact tag source overrides shared design',
        'complete byte decode rejects malformed upload',
        'pending file cannot move to another saved parent',
        'actual photos print once with component rows',
        'book switch clears photo and isolates custom identity',
        'unavailable imported image can be replaced using the saved owner',
        'Tour fallback master cannot be deleted as an absent custom image',
      ],
      mockedResponses: 0,
    };
  } finally {
    page.off('request', captureRequest);
    await page.evaluate(() => window.__restoreOrderImageFile?.()).catch(() => {});
  }
}
