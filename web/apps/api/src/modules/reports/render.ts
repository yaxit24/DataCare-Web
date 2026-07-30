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

const chromiumLaunchOptions = (): Record<string, unknown> => ({
  args: ['--no-sandbox'],
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

/**
 * Real renderer: Playwright headless-Chromium. Uses a guarded dynamic import + launch so the codebase
 * compiles/runs without the dependency; if Playwright or Chromium is unavailable it throws
 * PdfRendererUnavailableError (the Chromium binary download is heavy and may be blocked in CI/sandbox).
 */
export class PlaywrightPdfRenderer implements PdfRenderer {
  async render(html: string): Promise<Buffer> {
    const playwright = await loadPlaywright();
    let browser: any;
    try {
      browser = await playwright.chromium.launch(chromiumLaunchOptions());
    } catch (error: any) {
      throw new PdfRendererUnavailableError(`chromium launch failed: ${error?.message ?? error}`);
    }
    try {
      const page = await browser.newPage();
      await page.setContent(html, { waitUntil: 'load' });
      const buffer = await page.pdf({ format: 'A4', printBackground: true });
      return Buffer.from(buffer);
    } finally {
      await browser.close();
    }
  }
}

/** Render HTML through an explicitly selected renderer; production must choose Playwright. */
export async function renderToPdf(html: string, renderer: PdfRenderer): Promise<Buffer> {
  return renderer.render(html);
}
