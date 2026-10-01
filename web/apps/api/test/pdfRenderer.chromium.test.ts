import { createServer, type Server } from 'node:http';
import type { AddressInfo } from 'node:net';
import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import {
  pdfRenderFailure,
  PdfRenderLimitError,
  PdfRendererBusyError,
  PdfRenderTimeoutError,
  PlaywrightPdfRenderer,
  type PdfRenderInspection,
} from '../src/modules/reports/render.js';

/**
 * N54 / G32 on real headless Chromium (installed in CI by the quality job). Stored business text reaches the
 * renderer inside server-built documents, so the renderer must not run scripts or make network requests even
 * when such text slips past escaping. A local HTTP server stands in for an internal service (for example the
 * cloud metadata endpoint) and counts every request it receives.
 */
describe('isolated PDF renderer (real Chromium)', () => {
  let server: Server;
  let hits: string[] = [];
  let origin = '';

  beforeAll(async () => {
    server = createServer((req, res) => {
      hits.push(String(req.url));
      res.writeHead(200, { 'content-type': 'image/png' });
      res.end();
    });
    await new Promise<void>((resolve) => server.listen(0, '127.0.0.1', resolve));
    origin = `http://127.0.0.1:${(server.address() as AddressInfo).port}`;
  });
  afterAll(async () => {
    await new Promise<void>((resolve) => server.close(() => resolve()));
  });

  it('runs no script and lets no request leave the page, while embedded data images still render', async () => {
    hits = [];
    let inspection: PdfRenderInspection | undefined;
    let ran: unknown = 'not-read';
    const renderer = new PlaywrightPdfRenderer({
      inspect: async (page) => {
        ran = await page.evaluate("document.body.getAttribute('data-ran')");
      },
      onInspection: (seen) => (inspection = seen),
    });
    const pixel =
      'data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAYAAAAfFcSJAAAADUlEQVR42mP8z8BQDwAEhQGAhKmMIQAAAABJRU5ErkJggg==';
    const pdf = await renderer.render(`<!doctype html><html><head>
      <link rel="stylesheet" href="${origin}/style.css">
      <script src="${origin}/script.js"></script>
      </head><body>
      <script>document.body.setAttribute('data-ran', 'yes')</script>
      <img src="${origin}/remote.png"><iframe src="${origin}/frame"></iframe>
      <img src="${pixel}"><p>Static content</p></body></html>`);
    expect(pdf.subarray(0, 5).toString('latin1')).toBe('%PDF-');
    expect(ran).toBeNull();
    expect(hits).toEqual([]);
    expect(inspection?.blockedRequests.length).toBeGreaterThan(0);
    for (const url of inspection?.blockedRequests ?? []) expect(url.startsWith(origin)).toBe(true);
  }, 30_000);

  it('refuses oversized HTML before starting a browser (413)', async () => {
    const renderer = new PlaywrightPdfRenderer({ limits: { maxHtmlBytes: 1024 } });
    const error = await renderer.render('x'.repeat(1025)).catch((e) => e);
    expect(error).toBeInstanceOf(PdfRenderLimitError);
    expect(pdfRenderFailure(error)).toMatchObject({
      status: 413,
      body: { error: 'html-too-large' },
    });
  });

  it('refuses an oversized PDF (422)', async () => {
    const renderer = new PlaywrightPdfRenderer({ limits: { maxPdfBytes: 100 } });
    const error = await renderer
      .render('<p>more than one hundred bytes of PDF</p>')
      .catch((e) => e);
    expect(error).toBeInstanceOf(PdfRenderLimitError);
    expect(pdfRenderFailure(error)).toMatchObject({
      status: 422,
      body: { error: 'pdf-too-large' },
    });
  }, 30_000);

  it('stops a render that exceeds its time limit (retryable 503)', async () => {
    const renderer = new PlaywrightPdfRenderer({ limits: { timeoutMs: 1 } });
    const error = await renderer.render('<p>slow</p>').catch((e) => e);
    expect(error).toBeInstanceOf(PdfRenderTimeoutError);
    expect(pdfRenderFailure(error)).toMatchObject({
      status: 503,
      body: { error: 'pdf-render-timeout', retryable: true },
      retryAfter: 2,
    });
  }, 30_000);

  it('answers busy instead of queueing without bound (retryable 503)', async () => {
    const renderer = new PlaywrightPdfRenderer({ limits: { maxConcurrent: 1, maxQueued: 0 } });
    const first = renderer.render('<p>first</p>');
    const second = await renderer.render('<p>second</p>').catch((e) => e);
    expect(second).toBeInstanceOf(PdfRendererBusyError);
    expect(pdfRenderFailure(second)).toMatchObject({
      status: 503,
      body: { error: 'pdf-renderer-busy' },
    });
    expect((await first).subarray(0, 5).toString('latin1')).toBe('%PDF-');
  }, 30_000);
});
