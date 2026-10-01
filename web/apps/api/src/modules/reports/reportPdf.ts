import { escapeHtml } from './render.js';

/**
 * Server-owned report PDF (N54 / G32).
 *
 * The report screen used to build this HTML in the browser and post it to `POST /render/pdf`, which rendered
 * whatever HTML it was given. The same layout is now built here from the report builder's own result, so no
 * client-supplied HTML reaches Chromium. The helpers below are ported unchanged from
 * `apps/web/app/(app)/reports/[report]/page.tsx` (column analysis, totals row, branded band); only the inputs
 * are now server-owned (title from the report's desktop form, company name from CO_MAST).
 */

/** Escape text for HTML, as the screen did (&, <, >); attribute values here are fixed class names only. */
const esc = (s: any): string => escapeHtml(s);

// Columns whose name reads like an identifier/label should be right-aligned-if-numeric but never summed.
const ID_COL =
  /(^|[^a-z])(code|no|number|num|id|year|yr|date|rate|hsn|sac|pan|gstin|pin|phone|mobile|sr|srno|slno|vch|inv|ref|barcode|tag)([^a-z]|$)/i;
const NUM_RE = /^-?[\d,]*\.?\d+$/;
const fmtNum = (n: number): string => n.toLocaleString('en-IN', { maximumFractionDigits: 3 });

/** Inspect rows to decide which columns are numeric (right-aligned) and which should be totalled. */
function analyzeCols(rows: Record<string, any>[]): {
  cols: string[];
  numeric: Record<string, boolean>;
  sums: Record<string, number>;
  summable: Record<string, boolean>;
} {
  const cols = Object.keys(rows[0] ?? {});
  const numeric: Record<string, boolean> = {};
  const sums: Record<string, number> = {};
  const summable: Record<string, boolean> = {};
  for (const c of cols) {
    let allNum = true,
      anyVal = false,
      sum = 0;
    for (const r of rows) {
      const v = r[c];
      if (v === null || v === undefined || v === '') continue;
      anyVal = true;
      const txt = String(v).trim();
      const ok = typeof v === 'number' ? Number.isFinite(v) : NUM_RE.test(txt);
      if (!ok) {
        allNum = false;
        break;
      }
      sum += typeof v === 'number' ? v : Number(txt.replace(/,/g, ''));
    }
    numeric[c] = anyVal && allNum;
    sums[c] = sum;
    summable[c] = numeric[c] && !ID_COL.test(c);
  }
  return { cols, numeric, sums, summable };
}

/** A bordered report table: right-aligned numeric columns + a bold TOTALS row for amount-like columns. */
function tableHtml(rows: Record<string, any>[]): string {
  if (!rows.length) return '<div class="empty">No records for the selected period.</div>';
  const { cols, numeric, sums, summable } = analyzeCols(rows);
  const head = `<thead><tr>${cols.map((c) => `<th class="${numeric[c] ? 'num' : ''}">${esc(c)}</th>`).join('')}</tr></thead>`;
  const body = `<tbody>${rows
    .map(
      (r) =>
        `<tr>${cols.map((c) => `<td class="${numeric[c] ? 'num' : ''}">${esc(r[c])}</td>`).join('')}</tr>`,
    )
    .join('')}`;
  let totals = '';
  if (cols.some((c) => summable[c])) {
    let labelIdx = cols.findIndex((c) => !summable[c]);
    if (labelIdx === -1) labelIdx = 0;
    const cells = cols.map((c, i) => {
      if (i === labelIdx)
        return `<td class="${numeric[c] ? 'num' : ''}">Total (${rows.length} rows)</td>`;
      if (summable[c]) return `<td class="num">${esc(fmtNum(sums[c] ?? 0))}</td>`;
      return `<td class="${numeric[c] ? 'num' : ''}"></td>`;
    });
    totals = `<tr class="totals">${cells.join('')}</tr>`;
  }
  return `<table class="rpt">${head}${body}${totals}</tbody></table>`;
}

/** Branded, Crystal-style printable report HTML (company header band, FY, totals, footer note). */
export function buildReportHtml(opts: {
  company: string;
  title: string;
  fy: string;
  scalars: [string, any][];
  arrays: [string, any[]][];
  /** When the report is printed; formatted in the business time zone. */
  printedAt: Date;
}): string {
  const { company, title, fy, scalars, arrays } = opts;
  const printedOn = printedTimestamp(opts.printedAt);
  const summary = scalars.length
    ? `<div class="summary">${scalars.map(([k, v]) => `<div class="card"><div class="k">${esc(k)}</div><div class="v">${esc(v)}</div></div>`).join('')}</div>`
    : '';
  const secs = arrays.map(([k, v]) => `<h2 class="section">${esc(k)}</h2>${tableHtml(v)}`).join('');
  const bodyInner =
    summary || secs
      ? `${summary}${secs}`
      : '<div class="empty">No data available for this report.</div>';
  return `<!doctype html><html><head><meta charset="utf-8"><title>${esc(title)}</title><style>
  *{box-sizing:border-box}html,body{margin:0;padding:0}
  body{font:12px 'Segoe UI',Roboto,Arial,sans-serif;color:#22272e;-webkit-print-color-adjust:exact;print-color-adjust:exact}
  .page{padding:24px 28px 62px}
  .band{display:flex;align-items:center;justify-content:space-between;background:linear-gradient(135deg,#5b1220,#7d1f33 55%,#9c2a44);color:#fff;padding:15px 20px;border-radius:6px;box-shadow:inset 0 -3px 0 #c9a227}
  .band .brand{display:flex;align-items:center;gap:13px}
  .band .mark{width:38px;height:38px;border:2px solid #e8c976;border-radius:50%;display:flex;align-items:center;justify-content:center;font-size:18px;color:#f2d98a;background:rgba(255,255,255,.07)}
  .band .co{font-family:Georgia,'Times New Roman',serif;font-size:23px;font-weight:700;letter-spacing:.6px;text-transform:uppercase;color:#fdf6e3;line-height:1.05}
  .band .co small{display:block;font-family:'Segoe UI',Arial,sans-serif;font-weight:400;font-size:8.5px;letter-spacing:3px;color:#e8c976;margin-top:3px}
  .band .stamp{text-align:right;line-height:1.25}
  .band .stamp span{display:block;font-size:8.5px;letter-spacing:1.5px;text-transform:uppercase;color:#e8c976}
  .band .stamp b{font-size:15px;color:#fdf6e3}
  .titlebar{display:flex;align-items:flex-end;justify-content:space-between;margin:16px 2px 4px;padding-bottom:7px;border-bottom:2px solid #c9a227}
  .titlebar h1{margin:0;font-size:18px;color:#5b1220;font-weight:700;letter-spacing:.3px}
  .titlebar .meta{text-align:right;font-size:10px;color:#555;line-height:1.6}
  .titlebar .meta b{color:#22272e}
  .summary{display:flex;flex-wrap:wrap;gap:9px;margin:12px 0 4px}
  .summary .card{min-width:128px;border:1px solid #e6dcbf;border-left:3px solid #c9a227;background:#fbf8ef;border-radius:4px;padding:6px 11px}
  .summary .card .k{font-size:8.5px;letter-spacing:.6px;text-transform:uppercase;color:#9a7d2e}
  .summary .card .v{font-size:14px;font-weight:700;color:#22272e;margin-top:2px}
  h2.section{font-size:12px;margin:16px 0 5px;color:#5b1220;text-transform:capitalize;border-left:4px solid #c9a227;padding-left:8px;font-weight:700}
  table.rpt{border-collapse:collapse;width:100%;margin:4px 0 10px;font-size:10.5px}
  table.rpt th,table.rpt td{border:1px solid #d7d2c4;padding:5px 8px;vertical-align:top}
  table.rpt thead th{background:#3a2230;color:#fff;text-align:left;font-weight:600;text-transform:uppercase;font-size:9px;letter-spacing:.4px;white-space:nowrap}
  table.rpt th.num,table.rpt td.num{text-align:right;font-variant-numeric:tabular-nums;white-space:nowrap}
  table.rpt tbody tr:nth-child(even){background:#f6f4ee}
  table.rpt tbody tr.totals td{border-top:2px solid #5b1220;background:#f3e7c6;font-weight:700;color:#22272e}
  table.rpt thead{display:table-header-group}
  table.rpt tr{page-break-inside:avoid}
  h2.section{page-break-after:avoid}
  .empty{color:#777;font-style:italic;padding:8px 2px}
  .foot{position:fixed;left:0;right:0;bottom:0;padding:6px 28px;border-top:1px solid #d9d3c4;background:#fff;display:flex;justify-content:space-between;font-size:8.5px;color:#7a7a7a;letter-spacing:.3px}
  .foot .l{color:#9a7d2e;font-weight:600}
  </style></head><body><div class="page">
  <div class="band"><div class="brand"><div class="mark">&#9670;</div><div class="co">${esc(company)}<small>Gold &middot; Silver &middot; Diamond</small></div></div><div class="stamp"><span>Financial Year</span><b>${esc(fy)}</b></div></div>
  <div class="titlebar"><h1>${esc(title)}</h1><div class="meta"><div><b>Printed on:</b> ${esc(printedOn)}</div><div><b>Financial Year:</b> ${esc(fy)}</div></div></div>
  ${bodyInner}
  </div>
  <div class="foot"><span class="l">${esc(company)}</span><span>Computer-generated report &middot; ${esc(title)} &middot; valid without signature</span><span>Printed ${esc(printedOn)}</span></div>
  </body></html>`;
}

/**
 * The business time zone for printed timestamps. The screen printed the browser's local time; the server
 * prints in `PRINT_TIME_ZONE` (an IANA zone), defaulting to India Standard Time, where the businesses
 * running this application operate.
 */
export function printTimeZone(): string {
  const zone = process.env.PRINT_TIME_ZONE?.trim() || 'Asia/Kolkata';
  try {
    new Intl.DateTimeFormat('en-IN', { timeZone: zone });
    return zone;
  } catch {
    return 'Asia/Kolkata';
  }
}

/** "01 Oct 2026, 09:15 pm"-style timestamp, as the screen printed it, in the business time zone. */
export function printedTimestamp(at: Date): string {
  return at.toLocaleString('en-IN', {
    day: '2-digit',
    month: 'short',
    year: 'numeric',
    hour: '2-digit',
    minute: '2-digit',
    timeZone: printTimeZone(),
  });
}

/** At most this many rows across all sections; beyond it the PDF is refused and Excel is the export. */
export const REPORT_PDF_MAX_ROWS = 5_000;

export class ReportTooLargeForPdfError extends Error {
  constructor(
    readonly rows: number,
    readonly limit: number,
  ) {
    super(`report has ${rows} rows; PDF export is limited to ${limit}`);
    this.name = 'ReportTooLargeForPdfError';
  }
}

/**
 * The sections the screen showed: scalar fields as summary cards and every array field as a table. A report
 * whose result is itself a row array becomes one table (the screen's own PDF showed nothing for those).
 */
export function reportPdfSections(result: unknown): {
  scalars: [string, unknown][];
  arrays: [string, Record<string, unknown>[]][];
  rows: number;
} {
  if (Array.isArray(result)) {
    const rows = result.filter((row) => row && typeof row === 'object') as Record<
      string,
      unknown
    >[];
    return { scalars: [], arrays: [['Rows', rows]], rows: rows.length };
  }
  const entries = result && typeof result === 'object' ? Object.entries(result) : [];
  const arrays = entries.filter(([, v]) => Array.isArray(v)) as [
    string,
    Record<string, unknown>[],
  ][];
  const scalars = entries.filter(
    ([, v]) => !Array.isArray(v) && (v === null || typeof v !== 'object'),
  );
  return { scalars, arrays, rows: arrays.reduce((sum, [, v]) => sum + v.length, 0) };
}

/** The report PDF document for a builder result, refusing one too large to print. */
export function reportPdfHtml(input: {
  company: string;
  title: string;
  coYear: string;
  result: unknown;
  printedAt: Date;
}): string {
  const { scalars, arrays, rows } = reportPdfSections(input.result);
  if (rows > REPORT_PDF_MAX_ROWS) throw new ReportTooLargeForPdfError(rows, REPORT_PDF_MAX_ROWS);
  return buildReportHtml({
    company: input.company,
    title: input.title,
    fy: input.coYear || '\u2014',
    scalars: scalars as [string, any][],
    arrays,
    printedAt: input.printedAt,
  });
}

/** Estimate / quotation PDF, ported from the estimate screen's former client-side builder. */
export function estimatePdfHtml(input: {
  company: string;
  customer: string;
  printedAt: Date;
  lines: Array<{ sr: number; itCode: unknown; metal: number; labour: number; net: number }>;
  totals: { taxable: number; tax: number; total: number };
}): string {
  const rows = input.lines
    .map(
      (l) =>
        `<tr><td>${l.sr}</td><td>${esc(l.itCode)}</td><td style="text-align:right">${l.metal}</td><td style="text-align:right">${l.labour}</td><td style="text-align:right">${l.net}</td></tr>`,
    )
    .join('');
  const t = input.totals;
  const day = input.printedAt.toLocaleDateString('en-IN', { timeZone: printTimeZone() });
  return `<!doctype html><html><head><meta charset="utf-8"><style>body{font:12px Arial;padding:24px}h1{color:#0b5cab}table{border-collapse:collapse;width:100%}th,td{border:1px solid #bbb;padding:5px 7px;font-size:11px}th{background:#eef3f9}</style></head><body><h1>${esc(input.company || 'Estimate')}</h1><div><b>ESTIMATE / QUOTATION</b> &middot; ${esc(input.customer || 'Customer')} &middot; ${esc(day)}</div><table><thead><tr><th>#</th><th>Item</th><th>Metal</th><th>Labour</th><th>Net</th></tr></thead><tbody>${rows}</tbody></table><p style="text-align:right">Taxable: ${t.taxable} &nbsp; Tax: ${t.tax} &nbsp; <b>Total: ${t.total}</b></p><p class="muted">This is an estimate, not a tax invoice.</p></body></html>`;
}
