import type { Register } from './reports.js';

/**
 * Report rendering: open-source replacement for the desktop's Crystal Reports (.rpt) print pipeline.
 * Pure HTML templating (dataset → HTML string, fully testable) + PDF generation behind an injected
 * PdfRenderer. FakePdfRenderer emits real %PDF bytes for tests; PlaywrightPdfRenderer is the real
 * headless-Chromium renderer (guarded dynamic import/launch) — a drop-in once Chromium is installed.
 * No Windows / Crystal / .NET runtime.
 */

/** Escape text for safe HTML interpolation. */
export function escapeHtml(v: unknown): string {
  return String(v ?? '')
    .replace(/&/g, '&amp;')
    .replace(/</g, '&lt;')
    .replace(/>/g, '&gt;')
    .replace(/"/g, '&quot;')
    .replace(/'/g, '&#39;');
}

const money = (n: number): string =>
  Number(n ?? 0).toLocaleString('en-IN', { minimumFractionDigits: 2, maximumFractionDigits: 2 });
const fmtDate = (d: Date | string | null): string => {
  if (!d) return '';
  const dt = d instanceof Date ? d : new Date(d);
  if (isNaN(dt.getTime())) return escapeHtml(d);
  return `${String(dt.getDate()).padStart(2, '0')}/${String(dt.getMonth() + 1).padStart(2, '0')}/${dt.getFullYear()}`;
};

const PAGE_CSS = `body{font-family:Arial,Helvetica,sans-serif;font-size:12px;color:#111}
table{border-collapse:collapse;width:100%}th,td{border:1px solid #999;padding:4px 6px}
th{background:#eee;text-align:left}td.r,th.r{text-align:right}tfoot td{font-weight:bold;background:#f5f5f5}
h1{font-size:16px;margin:0 0 8px}.muted{color:#666}`;

function doc(title: string, body: string): string {
  return `<!doctype html><html><head><meta charset="utf-8"><title>${escapeHtml(title)}</title><style>${PAGE_CSS}</style></head><body>${body}</body></html>`;
}

/** Render a sales/purchase register dataset to HTML (Req 19/20). */
export function renderRegisterHtml(
  title: string,
  register: Register,
  opts: { showGst?: boolean } = {},
): string {
  const showGst = opts.showGst ?? true;
  const head =
    `<tr><th>Date</th><th>Vch No</th><th>Bill No</th><th>Party</th>` +
    `<th class="r">Net</th><th class="r">Tax</th>` +
    (showGst ? `<th class="r">CGST</th><th class="r">SGST</th><th class="r">IGST</th>` : '') +
    `<th class="r">Total</th></tr>`;
  const rows = register.rows
    .map(
      (r) =>
        `<tr><td>${fmtDate(r.vchDate)}</td><td>${escapeHtml(r.vchNo)}</td><td>${escapeHtml(r.billNo)}</td><td>${escapeHtml(r.party)}</td>` +
        `<td class="r">${money(r.netAmt)}</td><td class="r">${money(r.taxAmt)}</td>` +
        (showGst
          ? `<td class="r">${money(r.cgst)}</td><td class="r">${money(r.sgst)}</td><td class="r">${money(r.igst)}</td>`
          : '') +
        `<td class="r">${money(r.totAmt)}</td></tr>`,
    )
    .join('');
  const t = register.totals;
  const span = showGst ? 4 : 4;
  const foot =
    `<tr><td colspan="${span}">Total (${register.rows.length} rows)</td>` +
    `<td class="r">${money(t.netAmt)}</td><td class="r">${money(t.taxAmt)}</td>` +
    (showGst
      ? `<td class="r">${money(t.cgst)}</td><td class="r">${money(t.sgst)}</td><td class="r">${money(t.igst)}</td>`
      : '') +
    `<td class="r">${money(t.totAmt)}</td></tr>`;
  const body =
    register.rows.length === 0
      ? `<h1>${escapeHtml(title)}</h1><p class="muted">No records for the selected period.</p>`
      : `<h1>${escapeHtml(title)}</h1><table><thead>${head}</thead><tbody>${rows}</tbody><tfoot>${foot}</tfoot></table>`;
  return doc(title, body);
}

export interface InvoiceView {
  sellerName: string;
  buyerName: string;
  billNo: string;
  vchDate: Date | string;
  items: { desc: string; qty: number; rate: number; amount: number }[];
  netAmt: number;
  taxAmt: number;
  totAmt: number;
  irn?: string;
  qr?: string;
}

/** Render a tax invoice to HTML (with IRN/QR when e-invoiced). */
export function renderInvoiceHtml(inv: InvoiceView): string {
  const items = inv.items
    .map(
      (it, i) =>
        `<tr><td>${i + 1}</td><td>${escapeHtml(it.desc)}</td><td class="r">${money(it.qty)}</td><td class="r">${money(it.rate)}</td><td class="r">${money(it.amount)}</td></tr>`,
    )
    .join('');
  const irn = inv.irn ? `<p class="muted">IRN: ${escapeHtml(inv.irn)}</p>` : '';
  const qr = inv.qr ? `<p class="muted">QR: ${escapeHtml(inv.qr)}</p>` : '';
  const body =
    `<h1>Tax Invoice ${escapeHtml(inv.billNo)}</h1>` +
    `<p><b>${escapeHtml(inv.sellerName)}</b> &rarr; ${escapeHtml(inv.buyerName)} &nbsp; <span class="muted">${fmtDate(inv.vchDate)}</span></p>` +
    `<table><thead><tr><th>#</th><th>Description</th><th class="r">Qty</th><th class="r">Rate</th><th class="r">Amount</th></tr></thead>` +
    `<tbody>${items}</tbody>` +
    `<tfoot><tr><td colspan="4">Taxable</td><td class="r">${money(inv.netAmt)}</td></tr>` +
    `<tr><td colspan="4">Tax</td><td class="r">${money(inv.taxAmt)}</td></tr>` +
    `<tr><td colspan="4">Total</td><td class="r">${money(inv.totAmt)}</td></tr></tfoot></table>${irn}${qr}`;
  return doc(`Invoice ${inv.billNo}`, body);
}

export class PdfRendererUnavailableError extends Error {
  constructor(msg: string) {
    super(msg);
    this.name = 'PdfRendererUnavailableError';
  }
}

export interface PdfRenderer {
  render(html: string): Promise<Buffer>;
}

export interface PdfRendererReadiness {
  available: boolean;
  engine: 'playwright-chromium';
  error?: 'playwright-unavailable' | 'chromium-unavailable';
}

/**
 * Rendering limits and isolation (N54 / G32).
 *
 * Every document reaching Chromium is built by the server from its own data; no route accepts HTML from a
 * client any more. The renderer still treats that HTML as untrusted, because it carries stored business text
 * (party names, remarks, descriptions):
 *  - JavaScript is disabled and the context is offline. Every network request is aborted before the
 *    content is set, so a stored `<img src="http://…">` or `<link>` cannot reach the network or the
 *    instance metadata service. Embedded `data:` images (order photographs) still render.
 *  - HTML, output size and time are bounded, and at most `maxConcurrent` renders run at once; beyond
 *    `maxQueued` waiting renders the server answers 503 instead of queueing without limit.
 *  - Chromium's OS sandbox is opt-in with PDF_RENDERER_SANDBOX=1. It needs kernel support (user namespaces,
 *    or a seccomp profile inside containers) that has not been verified for the deployment image. Without it
 *    Playwright starts Chromium with --no-sandbox, as before.
 */
export interface PdfRenderLimits {
  maxHtmlBytes: number;
  maxPdfBytes: number;
  timeoutMs: number;
  maxConcurrent: number;
  maxQueued: number;
}
export const PDF_RENDER_LIMITS: Readonly<PdfRenderLimits> = Object.freeze({
  maxHtmlBytes: 2 * 1024 * 1024,
  maxPdfBytes: 20 * 1024 * 1024,
  timeoutMs: 15_000,
  maxConcurrent: 2,
  maxQueued: 8,
});

/** The document is outside a size limit: 413 for oversized input, 422 for an oversized result. */
export class PdfRenderLimitError extends Error {
  constructor(
    readonly code: 'html-too-large' | 'pdf-too-large',
    readonly limitBytes: number,
  ) {
    super(`${code}: limit ${limitBytes} bytes`);
    this.name = 'PdfRenderLimitError';
  }
}

/** Too many renders are already running or waiting: retryable 503. */
export class PdfRendererBusyError extends Error {
  constructor() {
    super('pdf renderer busy');
    this.name = 'PdfRendererBusyError';
  }
}

/** The render did not finish within the time limit: retryable 503. */
export class PdfRenderTimeoutError extends Error {
  constructor(readonly timeoutMs: number) {
    super(`pdf render exceeded ${timeoutMs} ms`);
    this.name = 'PdfRenderTimeoutError';
  }
}

const chromiumLaunchOptions = (): Record<string, unknown> => ({
  ...(process.env.PDF_RENDERER_SANDBOX === '1' ? { chromiumSandbox: true } : {}),
  ...(process.env.CHROMIUM_EXECUTABLE_PATH
    ? { executablePath: process.env.CHROMIUM_EXECUTABLE_PATH }
    : {}),
});

const loadPlaywright = async (): Promise<any> => {
  const moduleName = 'playwright';
  try {
    return await import(moduleName);
  } catch {
    throw new PdfRendererUnavailableError('playwright module is unavailable');
  }
};

let readinessCache: { expiresAt: number; result: PdfRendererReadiness } | undefined;

/** Launches the production browser, then caches the result briefly to keep /ready inexpensive. */
export async function playwrightRendererReadiness(now = Date.now()): Promise<PdfRendererReadiness> {
  if (readinessCache && readinessCache.expiresAt > now) return readinessCache.result;

  let result: PdfRendererReadiness;
  try {
    const playwright = await loadPlaywright();
    const browser = await playwright.chromium.launch(chromiumLaunchOptions());
    await browser.close();
    result = { available: true, engine: 'playwright-chromium' };
  } catch (error) {
    result = {
      available: false,
      engine: 'playwright-chromium',
      error:
        error instanceof PdfRendererUnavailableError
          ? 'playwright-unavailable'
          : 'chromium-unavailable',
    };
  }
  readinessCache = { expiresAt: now + 60_000, result };
  return result;
}

/** Deterministic fake renderer: emits minimal valid PDF bytes (no browser). For tests only. */
export class FakePdfRenderer implements PdfRenderer {
  async render(html: string): Promise<Buffer> {
    const text = `Report (${html.length} bytes of HTML)`;
    const pdf =
      `%PDF-1.4\n1 0 obj<</Type/Catalog/Pages 2 0 R>>endobj\n` +
      `2 0 obj<</Type/Pages/Kids[3 0 R]/Count 1>>endobj\n` +
      `3 0 obj<</Type/Page/Parent 2 0 R/MediaBox[0 0 595 842]>>endobj\n` +
      `% ${text}\n%%EOF`;
    return Buffer.from(pdf, 'utf8');
  }
}

/** A counting gate: at most `max` holders at once and at most `queue` waiters; beyond that, refuse. */
class RenderGate {
  private active = 0;
  private readonly waiting: Array<() => void> = [];
  constructor(
    private readonly limits: () => Pick<PdfRenderLimits, 'maxConcurrent' | 'maxQueued'>,
  ) {}

  async acquire(): Promise<() => void> {
    const { maxConcurrent, maxQueued } = this.limits();
    if (this.active >= maxConcurrent) {
      if (this.waiting.length >= maxQueued) throw new PdfRendererBusyError();
      await new Promise<void>((resolve) => this.waiting.push(resolve));
    }
    this.active += 1;
    let released = false;
    return () => {
      if (released) return;
      released = true;
      this.active -= 1;
      this.waiting.shift()?.();
    };
  }
}

/** Observations of one render, for tests that prove the isolation. */
export interface PdfRenderInspection {
  /** Requests the page attempted; every one was aborted. */
  blockedRequests: string[];
  /** Read the rendered page before printing (JavaScript-off checks). */
  probe?: unknown;
}

/**
 * Real renderer: Playwright headless Chromium, isolated as described above. Uses a guarded dynamic import and
 * launch, so the codebase compiles and runs without the dependency; if Playwright or Chromium is unavailable
 * it throws PdfRendererUnavailableError.
 */
export class PlaywrightPdfRenderer implements PdfRenderer {
  /** The process-wide bound on concurrent renders. */
  private static readonly sharedGate = new RenderGate(() => PDF_RENDER_LIMITS);
  /** A renderer with its own limits (tests) has its own gate; every other renderer shares one. */
  private readonly gate: RenderGate;

  constructor(
    private readonly options: {
      preferCSSPageSize?: boolean;
      /** Tighter limits for one renderer (tests); defaults to PDF_RENDER_LIMITS. */
      limits?: Partial<PdfRenderLimits>;
      /** Test seam: read the page after content is set, before printing. */
      inspect?: (page: any, inspection: PdfRenderInspection) => Promise<void>;
      /** Test seam: receives what the page tried to load. */
      onInspection?: (inspection: PdfRenderInspection) => void;
    } = {},
  ) {
    this.gate = options.limits
      ? new RenderGate(() => this.limits)
      : PlaywrightPdfRenderer.sharedGate;
  }

  private get limits(): PdfRenderLimits {
    return { ...PDF_RENDER_LIMITS, ...this.options.limits };
  }

  async render(html: string): Promise<Buffer> {
    const limits = this.limits;
    if (Buffer.byteLength(html, 'utf8') > limits.maxHtmlBytes) {
      throw new PdfRenderLimitError('html-too-large', limits.maxHtmlBytes);
    }
    const release = await this.gate.acquire();
    try {
      return await this.renderIsolated(html, limits);
    } finally {
      release();
    }
  }

  private async renderIsolated(html: string, limits: PdfRenderLimits): Promise<Buffer> {
    const playwright = await loadPlaywright();
    let browser: any;
    try {
      browser = await playwright.chromium.launch(chromiumLaunchOptions());
    } catch (error: any) {
      throw new PdfRendererUnavailableError(`chromium launch failed: ${error?.message ?? error}`);
    }
    let timer: ReturnType<typeof setTimeout> | undefined;
    const timedOut = new Promise<never>((_, reject) => {
      timer = setTimeout(
        () => reject(new PdfRenderTimeoutError(limits.timeoutMs)),
        limits.timeoutMs,
      );
    });
    const inspection: PdfRenderInspection = { blockedRequests: [] };
    try {
      const work = (async () => {
        const context = await browser.newContext({
          javaScriptEnabled: false,
          offline: true,
          acceptDownloads: false,
          serviceWorkers: 'block',
        });
        const page = await context.newPage();
        await page.route('**/*', (route: any) => {
          inspection.blockedRequests.push(String(route.request().url()));
          return route.abort();
        });
        await page.setContent(html, { waitUntil: 'load', timeout: limits.timeoutMs });
        if (this.options.inspect) await this.options.inspect(page, inspection);
        const buffer = Buffer.from(
          await page.pdf({ format: 'A4', printBackground: true, ...this.optionsForPdf() }),
        );
        if (buffer.length > limits.maxPdfBytes) {
          throw new PdfRenderLimitError('pdf-too-large', limits.maxPdfBytes);
        }
        return buffer;
      })();
      return await Promise.race([work, timedOut]);
    } finally {
      if (timer) clearTimeout(timer);
      this.options.onInspection?.(inspection);
      await browser.close().catch(() => {});
    }
  }

  private optionsForPdf(): Record<string, unknown> {
    return this.options.preferCSSPageSize === undefined
      ? {}
      : { preferCSSPageSize: this.options.preferCSSPageSize };
  }
}

/**
 * The HTTP answer for a render failure: limits are client-visible (413/422), a busy or slow renderer is a
 * retryable 503, and anything else is the renderer being unavailable.
 */
export function pdfRenderFailure(error: unknown): {
  status: number;
  body: Record<string, unknown>;
  retryAfter?: number;
} {
  if (error instanceof PdfRenderLimitError) {
    return {
      status: error.code === 'html-too-large' ? 413 : 422,
      body: { error: error.code, limitBytes: error.limitBytes },
    };
  }
  if (error instanceof PdfRendererBusyError)
    return { status: 503, body: { error: 'pdf-renderer-busy', retryable: true }, retryAfter: 2 };
  if (error instanceof PdfRenderTimeoutError)
    return { status: 503, body: { error: 'pdf-render-timeout', retryable: true }, retryAfter: 2 };
  return { status: 503, body: { error: 'pdf-renderer-unavailable' } };
}

/** Render HTML through an explicitly selected renderer; production must choose Playwright. */
export async function renderToPdf(html: string, renderer: PdfRenderer): Promise<Buffer> {
  return renderer.render(html);
}
