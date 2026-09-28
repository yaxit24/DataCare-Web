import assert from 'node:assert/strict';
import { readFileSync } from 'node:fs';

/** Follows order-image.journey's Z10 / 00021 / parent66 fallback-master case. */
export async function exerciseImageConflict(page, options = {}) {
  const png = readFileSync(
    new URL('../../api/test/fixtures/order-design-portrait.png', import.meta.url),
  );
  const jpeg = readFileSync(
    new URL('../../api/test/fixtures/order-tag-landscape.jpg', import.meta.url),
  );
  const path =
    '/api/tour-orders/00021/image?coCode=01&lcCode=01&coYear=2024-2025&coBook=Z10&srNo=66';
  const panel = page.getByTestId('tour-order-image');
  assert.match(
    await page.getByTestId('tour-order-image-identity').innerText(),
    /Z10 \/ 00021, item 66/,
  );
  await page.waitForFunction(
    () => !document.querySelector('[data-testid="tour-order-image-file"]').disabled,
  );
  const before = await page.request.get(path);
  assert.equal(before.status(), 200);
  // A second request client commits a change while the operator still sees their old snapshot.
  const newer = await page.request.post(path, {
    data: {
      version: (await before.json()).version,
      data: jpeg.toString('base64'),
      mimeType: 'image/jpeg',
    },
  });
  assert.equal(newer.status(), 200, await newer.text());
  const upload = async () => {
    const response = page.waitForResponse(
      (r) =>
        new URL(r.url()).pathname === '/api/tour-orders/00021/image' &&
        r.request().method() === 'POST',
    );
    await page
      .getByTestId('tour-order-image-file')
      .setInputFiles({ name: 'operator-photo.png', mimeType: 'image/png', buffer: png });
    return response;
  };
  const refused = await upload();
  assert.equal(refused.status(), 422);
  assert.match((await refused.json()).message, /image or its identity changed/);
  await page.getByTestId('tour-order-image-error').waitFor();
  const retained = await page.request.get(path);
  assert.equal((await retained.json()).image.data, jpeg.toString('base64'));
  await options.checkpoint?.('order-image-concurrent-change-refused', page);
  await panel.getByRole('button', { name: 'Reload image', exact: true }).click();
  await page.waitForFunction(
    (data) =>
      document.querySelector('[data-testid="tour-order-image-preview"]')?.getAttribute('src') ===
      data,
    `data:image/jpeg;base64,${jpeg.toString('base64')}`,
  );
  await page.waitForFunction(
    () => !document.querySelector('[data-testid="tour-order-image-file"]').disabled,
  );
  const retried = await upload();
  assert.equal(retried.status(), 200, await retried.text());
  await page.waitForFunction(
    (data) =>
      document.querySelector('[data-testid="tour-order-image-preview"]')?.getAttribute('src') ===
      data,
    `data:image/png;base64,${png.toString('base64')}`,
  );
  return {
    mockedResponses: 0,
    checks: [
      'another request client changes the actual saved photo',
      'stale operator upload is refused without overwriting newer bytes',
      'operator sees the conflict and reloads the current photo',
      'explicit retry with the refreshed revision saves successfully',
    ],
  };
}
