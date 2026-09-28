import assert from 'node:assert/strict';
import { readFileSync } from 'node:fs';
import { request as requestFactory } from 'playwright';

const png = readFileSync(
  new URL('../../api/test/fixtures/order-design-portrait.png', import.meta.url),
);
const jpeg = readFileSync(
  new URL('../../api/test/fixtures/order-tag-landscape.jpg', import.meta.url),
);
export const genericImageFixture = {
  coCode: '01',
  lcCode: '01',
  coYear: '2024-2025',
  bookName: 'R5 IMAGE CONFLICT',
  prCode: '01',
  first: { srNo: 17, imageKey: 'R5_DESIGN_CONFLICT_A', designNo: 'R5-PORTRAIT' },
  second: { srNo: 29, imageKey: 'R5_DESIGN_CONFLICT_B', designNo: 'R5-LANDSCAPE' },
};

/** Runner-owned sql(query,...parameters) supplies the disposable tenant as $1. */
export async function cleanupGenericImageConflict(sql) {
  for (const table of ['ENTITY_IMAGE', 'ENTITY_IMAGE_REVISION'])
    await sql(
      `DELETE FROM "${table}" WHERE tenant_id=$1 AND "CO_CODE"='01' AND "LC_CODE"='' AND "ENTITY_TYPE"='DESIGN' AND "ENTITY_KEY" IN ($2,$3)`,
      genericImageFixture.first.imageKey,
      genericImageFixture.second.imageKey,
    );
  for (const table of ['DESIGN_IDTL', 'DESIGN_DETL'])
    await sql(
      `DELETE FROM "${table}" WHERE tenant_id=$1 AND "CO_CODE"='01' AND "BOOK_NAME"=$2 AND "PR_CODE"='01'`,
      genericImageFixture.bookName,
    );
}

export async function seedGenericImageConflict(sql) {
  await cleanupGenericImageConflict(sql);
  await sql(
    `INSERT INTO "DESIGN_DETL"(tenant_id,"CO_CODE","BOOK_NAME","PR_CODE","SR_NO","OLD_SRNO","DESIGN_NO","DESIGN_IMG_ID","ITM_STYLE","ITM_PCS","ITM_GWT","ITM_NWT","ITM_FINE","ITM_AMT","NET_AMT","LBR_TYPE","LBR_RATE","LBR_AMT")
    VALUES($1,'01',$2,'01',17,42,$3,$4,'IMAGE A',1,5,4,3.7,1000,1090,'N',22.5,90),
          ($1,'01',$2,'01',29,63,$5,$6,'IMAGE B',1,2,1,0.916,200,210,'N',10,10)`,
    genericImageFixture.bookName,
    genericImageFixture.first.designNo,
    genericImageFixture.first.imageKey,
    genericImageFixture.second.designNo,
    genericImageFixture.second.imageKey,
  );
  await sql(
    `INSERT INTO "DESIGN_IDTL"(tenant_id,"CO_CODE","BOOK_NAME","PR_CODE","SR_NO","ISR_NO","DESIGN_NO","IT_CODE","IT_PCS","IT_GWT","IT_AMT","IT_NET_AMT")
    VALUES($1,'01',$2,'01',17,3,$3,'STONE',1,0.125,10,10),
          ($1,'01',$2,'01',17,9,$3,'STONE',2,0.375,20,20),
          ($1,'01',$2,'01',29,2,$4,'STONE',1,0.234,30,30)`,
    genericImageFixture.bookName,
    genericImageFixture.first.designNo,
    genericImageFixture.second.designNo,
  );
  for (const [key, bytes, mimeType] of [
    [genericImageFixture.first.imageKey, png, 'image/png'],
    [genericImageFixture.second.imageKey, jpeg, 'image/jpeg'],
  ])
    await sql(
      `INSERT INTO "ENTITY_IMAGE"(tenant_id,"CO_CODE","LC_CODE","ENTITY_TYPE","ENTITY_KEY","INSTANCE","IMAGE_TYPE","MIME_TYPE","IMAGE_SIZE","IMAGE_BYTES") VALUES($1,'01','','DESIGN',$2,0,'D',$3,$4,$5)`,
      key,
      mimeType,
      bytes.length,
      bytes,
    );
}

/** Actual authenticated HTTP clients and browser uploads only: no route interception or provider. */
export async function exerciseGenericImageConflict(page, { checkpoint } = {}) {
  const fixture = genericImageFixture;
  const endpoint = '/api/masters/design-book/image';
  const scope = { coCode: fixture.coCode, lcCode: fixture.lcCode, coYear: fixture.coYear };
  const key = (entityKey) => ({
    ...scope,
    entityType: 'DESIGN',
    entityKey,
    instance: 0,
    imageType: 'D',
  });
  const query = (entityKey) => new URLSearchParams(key(entityKey)).toString();
  const mutations = [];
  const imageRequests = [];
  const errors = [];
  const onError = (error) => errors.push(error.message);
  const onRequest = (request) => {
    if (![endpoint, `${endpoint}/state`].includes(new URL(request.url()).pathname)) return;
    imageRequests.push(request);
    if (request.method() !== 'GET') mutations.push(request);
  };
  page.on('pageerror', onError);
  page.on('request', onRequest);
  // This context holds the same authorized operator's session but has an independent request client.
  // It does not use or modify the browser's React state, and is disposed without persisting cookies.
  const otherClient = await requestFactory.newContext({
    baseURL: new URL(page.url()).origin,
    storageState: await page.context().storageState(),
  });
  const panel = page.getByTestId('entity-image');
  const ready = () =>
    page.waitForFunction(() => {
      const control = document.querySelector('[data-testid="entity-image-select"]');
      return control && !control.disabled;
    });
  const preview = async (bytes, mimeType) => {
    await page.waitForFunction(
      async ({ data, type }) => {
        const image = document.querySelector('[data-testid="entity-image-preview"]');
        if (!image?.complete || !image.naturalWidth) return false;
        try {
          const response = await fetch(image.src);
          const blob = await response.blob();
          if (blob.type !== type) return false;
          const bytes = new Uint8Array(await blob.arrayBuffer());
          let binary = '';
          for (let offset = 0; offset < bytes.length; offset += 8192)
            binary += String.fromCharCode(...bytes.subarray(offset, offset + 8192));
          return btoa(binary) === data;
        } catch {
          return false;
        }
      },
      { data: bytes.toString('base64'), type: mimeType },
    );
    await ready();
  };
  const read = async (entityKey = fixture.first.imageKey) => {
    const response = await otherClient.get(`${endpoint}/state?${query(entityKey)}`);
    assert.equal(response.status(), 200, await response.text());
    const state = await response.json();
    assert.match(state.version, /^[0-9a-f]{64}$/);
    return state;
  };
  const book = async () => {
    const response = await otherClient.get(
      `/api/masters/design-book?${new URLSearchParams({
        ...scope,
        bookName: fixture.bookName,
        prCode: fixture.prCode,
      })}`,
    );
    assert.equal(response.status(), 200, await response.text());
    return response.json();
  };
  const remoteUpload = async (bytes, mimeType) => {
    const before = await read();
    const response = await otherClient.post(endpoint, {
      data: {
        ...key(fixture.first.imageKey),
        version: before.version,
        data: bytes.toString('base64'),
        mimeType,
      },
    });
    assert.equal(response.status(), 200, await response.text());
    const after = await read();
    assert.notEqual(
      after.version,
      before.version,
      'Every committed remote image change advances the token',
    );
    assert.equal(after.image.data, bytes.toString('base64'));
    return after;
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
      page.getByTestId('entity-image-file').setInputFiles({
        name: 'operator-retained-photo.png',
        mimeType: 'image/png',
        buffer: png,
      }),
    );
  const conflict = async (response, current) => {
    assert.equal(response.status(), 409, await response.text());
    const body = await response.json();
    assert.equal(body.error, 'image-version-conflict');
    assert.match(body.message, /image|photo/i);
    await page.getByTestId('entity-image-conflict').waitFor();
    assert.match(
      await page.getByTestId('entity-image-error').innerText(),
      /chang|reload|conflict/i,
    );
    assert.equal(
      (await read()).version,
      current.version,
      'Rejected stale action changes neither bytes nor revision',
    );
    assert.equal((await read()).image.data, current.image.data);
  };
  const reload = async (bytes, mimeType) => {
    const count = mutations.length;
    await page.getByTestId('entity-image-reload').click();
    await preview(bytes, mimeType);
    assert.equal(
      mutations.length,
      count,
      'Reload only reads; it must never resend a retained upload or deletion',
    );
  };
  const selectParent = async (row, bytes, mimeType) => {
    const parent = page.locator('tr').filter({
      has: page.locator(`[data-design-parent="${row.srNo}"][data-design-field="designNo"]`),
    });
    await parent.getByRole('button', { name: /components$/ }).click();
    await preview(bytes, mimeType);
    assert.equal(await page.getByTestId('entity-image-tag').innerText(), row.imageKey);
  };
  try {
    await page.goto('/masters/design-book');
    await page.getByLabel('Book Name', { exact: true }).fill(fixture.bookName);
    await page.getByPlaceholder('search products… (F1)', { exact: true }).fill(fixture.prCode);
    await page.getByRole('button', { name: 'Load', exact: true }).click();
    await page.getByRole('status').filter({ hasText: 'Loaded 2 designs.' }).waitFor();
    await selectParent(fixture.first, png, 'image/png');
    const originalBook = await book();
    assert.deepEqual(
      originalBook.map((row) => [
        row.SR_NO,
        row.OLD_SRNO,
        row.components.map((child) => child.ISR_NO),
      ]),
      [
        [17, 42, [3, 9]],
        [29, 63, [2]],
      ],
    );
    const originalSecond = await read(fixture.second.imageKey);

    const concurrentUpload = await remoteUpload(jpeg, 'image/jpeg');
    await conflict(await upload(), concurrentUpload);
    await panel.scrollIntoViewIfNeeded();
    await checkpoint?.('generic-image-upload-conflict-round5', page);
    await reload(jpeg, 'image/jpeg');
    const retry = await action('POST', () => page.getByTestId('entity-image-retry-upload').click());
    assert.equal(retry.status(), 200, await retry.text());
    await preview(png, 'image/png');
    assert.equal((await read()).image.data, png.toString('base64'));

    const concurrentDelete = await remoteUpload(jpeg, 'image/jpeg');
    await conflict(
      await action('DELETE', () => page.getByTestId('entity-image-delete').click()),
      concurrentDelete,
    );
    await reload(jpeg, 'image/jpeg');
    const removed = await action('DELETE', () => page.getByTestId('entity-image-delete').click());
    assert.equal(removed.status(), 200, await removed.text());
    await page.getByTestId('entity-image-empty').waitFor();
    const absent = await read();
    assert.equal(absent.image.state, 'absent');
    assert.notEqual(
      absent.version,
      concurrentDelete.version,
      'Removal retains a new tombstone revision',
    );

    await remoteUpload(png, 'image/png');
    await reload(png, 'image/png');
    const beforeSwitch = await remoteUpload(jpeg, 'image/jpeg');
    await conflict(await upload(), beforeSwitch);
    const countBeforeSwitch = mutations.length;
    await selectParent(fixture.second, jpeg, 'image/jpeg');
    assert.equal(await page.getByTestId('entity-image-conflict').count(), 0);
    assert.equal(
      await page.getByTestId('entity-image-retry-upload').count(),
      0,
      'Pending bytes from parent17 cannot be retried against parent29',
    );
    assert.equal(await page.getByTestId('entity-image-error').count(), 0);
    assert.deepEqual(
      await read(fixture.second.imageKey),
      originalSecond,
      'Other saved parent photo and token remain untouched',
    );
    await checkpoint?.('generic-image-parent-identity-round5', page);
    await selectParent(fixture.first, jpeg, 'image/jpeg');
    assert.equal(
      await page.getByTestId('entity-image-retry-upload').count(),
      0,
      'Returning to the original identity does not resurrect a discarded file',
    );
    assert.equal(
      mutations.length,
      countBeforeSwitch,
      'Selecting records performs no hidden image mutation',
    );

    await page.getByLabel('Book Name', { exact: true }).fill('R5 OTHER BOOK');
    await panel.waitFor({ state: 'detached' });
    assert.equal(
      await page.getByTestId('entity-image-preview').count(),
      0,
      'Changed book immediately hides the previously loaded image',
    );
    await page.getByLabel('Book Name', { exact: true }).fill(fixture.bookName);
    await page.getByRole('button', { name: 'Load', exact: true }).click();
    await selectParent(fixture.first, jpeg, 'image/jpeg');
    assert.deepEqual(
      await book(),
      originalBook,
      'Image operations preserve every saved parent and component field, identity and business version',
    );

    // Runner supplies Chromium's explicit fake camera and grants only this local test origin.
    // Actual getUserMedia/video/canvas/File, HTTP validation and PostgreSQL storage remain in use.
    const beforeCamera = await read();
    await page.getByTestId('entity-image-capture').click();
    await page.waitForFunction(() => {
      const status = document.querySelector('[data-testid="entity-image-camera-status"]');
      const video = document.querySelector('[data-testid="entity-image-camera-preview"]');
      return (
        status?.textContent?.includes('camera: live') &&
        video?.readyState >= 2 &&
        video.videoWidth > 0 &&
        video.videoHeight > 0
      );
    });
    assert.equal(await page.getByTestId('entity-image-camera-preview').isVisible(), true);
    const cameraStream = await page
      .getByTestId('entity-image-camera-preview')
      .evaluateHandle((video) => video.srcObject);
    try {
      const capture = await action('POST', () =>
        page.getByTestId('entity-image-camera-capture').click(),
      );
      assert.equal(capture.status(), 200, await capture.text());
      const uploadData = capture.request().postDataJSON();
      assert.equal(uploadData.mimeType, 'image/jpeg');
      assert.equal(uploadData.version, beforeCamera.version);
      assert.notEqual(
        uploadData.data,
        jpeg.toString('base64'),
        'Synthetic camera creates a new frame, not the fixture attachment',
      );
      const savedCamera = await read();
      assert.notEqual(savedCamera.version, beforeCamera.version);
      assert.equal(
        savedCamera.image.state,
        'present',
        'Server fully decodes the uploaded camera JPEG',
      );
      assert.equal(savedCamera.image.mimeType, 'image/jpeg');
      assert.equal(savedCamera.image.data, uploadData.data);
      await preview(Buffer.from(uploadData.data, 'base64'), 'image/jpeg');
      await page.waitForFunction(() =>
        document
          .querySelector('[data-testid="entity-image-camera-status"]')
          ?.textContent?.includes('camera: idle'),
      );
      assert.equal(await page.getByTestId('entity-image-camera-preview').isVisible(), false);
      assert.equal(
        await cameraStream.evaluate((stream) =>
          stream.getTracks().every((track) => track.readyState === 'ended'),
        ),
        true,
        'Capture stops every synthetic media track',
      );
      assert.deepEqual(await read(fixture.second.imageKey), originalSecond);
      assert.deepEqual(
        await book(),
        originalBook,
        'Camera upload preserves all saved parent and child business values',
      );
      await checkpoint?.('generic-image-synthetic-camera-round5', page);
    } finally {
      await cameraStream.dispose();
      const stop = page.getByRole('button', { name: 'Stop camera', exact: true });
      if (await stop.isVisible().catch(() => false)) await stop.click().catch(() => {});
    }

    assert(imageRequests.length > 0);
    for (const request of imageRequests) {
      const params =
        request.method() === 'POST'
          ? request.postDataJSON()
          : Object.fromEntries(new URL(request.url()).searchParams);
      for (const [field, value] of Object.entries(scope))
        assert.equal(params[field], value, `${request.method()} explicitly preserves ${field}`);
      assert.equal(params.entityType, 'DESIGN');
      assert.equal(String(params.instance), '0');
      assert.equal(params.imageType, 'D');
      assert([fixture.first.imageKey, fixture.second.imageKey].includes(params.entityKey));
      if (request.method() !== 'GET') assert.match(params.version, /^[0-9a-f]{64}$/);
    }
    assert.deepEqual(errors, []);
    return {
      mockedResponses: 0,
      imageRequests: imageRequests.length,
      browserMutationAttempts: mutations.length,
      camera: { simulatedDevice: true, physicalDeviceAcceptance: false },
      checks: [
        'independent authenticated HTTP client changes the actual saved Design photo',
        'stale browser upload receives409 and preserves newer bytes and revision',
        'readable upload conflict offers Reload image without automatic resend',
        'explicit retained-file Retry upload saves with the refreshed token',
        'stale browser Delete receives409 without deleting newer photo',
        'Reload followed by explicit Delete removes only the current image and advances its tombstone',
        'switching saved parent discards conflicted pending bytes and preserves the other parent photo',
        'changing the selected book hides the previous saved photo and its actions',
        'all image requests preserve selected company/location/year and exact saved image identity',
        'all parent/component values, noncontiguous identities and business versions remain unchanged',
        'synthetic camera capture through actual video/canvas/HTTP/PostgreSQL; no physical-device acceptance',
      ],
    };
  } finally {
    page.off('pageerror', onError);
    page.off('request', onRequest);
    await otherClient.dispose();
  }
}
