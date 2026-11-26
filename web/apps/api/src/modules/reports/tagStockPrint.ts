import { formatDesktopDate } from '@datacare/core';
import { escapeHtml } from './render.js';
import type { TagStockColumn } from './tagStockColumns.js';

/**
 * The Print window of Report → Tag Stock (desktop RP_TAG BtnPrint_Click :8578-8754 and BtnSumm_Click :8755-8897).
 *
 * The desktop copies the grid into TAG_STOCK_PRINT and hands it to a Crystal template. The web builds the same page
 * from the report object the grid shows, so the window, the grid and the exports cannot disagree and nothing is staged
 * in a shared table (the desktop deletes and refills TAG_STOCK_PRINT for every run). It carries the title the desktop
 * passes as RptTitel (MsCrystalRptType 'N': the text, From, " To " and To, :8626-8635), the columns of the screen and
 * the footer totals. The Crystal positions and fonts are not reproduced.
 *
 * Titles and templates:
 * - Print, Tag Wise: "Tag Wise Stock As on Date " (:8696), template TagStkRpt (:8697).
 * - Print, Summary view: "Tag Wise Stock Summary As on Date " (:8603), template TagItmSumm (:8629).
 * - Summ: "Tag Wise Stock Summary As on Date " (:8757 text), after "Product Wise Group Report" Yes template
 *   TagStkSummRpt (:8847), No TagStkItemSumRpt (:8851).
 * "Branch - <location> " is put before the title when a location is chosen and the location box is shown (:8625).
 */
export type TagStockPrintKind = 'print' | 'summ-product' | 'summ-item';

export const TAG_STOCK_TITLE = 'Tag Wise Stock As on Date ';
export const TAG_STOCK_SUMMARY_TITLE = 'Tag Wise Stock Summary As on Date ';

export function tagStockPrintTitle(input: {
  kind: TagStockPrintKind;
  view: 'tag' | 'item' | 'product';
  lcCode?: string;
  fromDate?: string;
  toDate?: string;
}): { title: string; template: string } {
  const summary = input.kind !== 'print' || input.view !== 'tag';
  const template =
    input.kind === 'summ-product'
      ? 'TagStkSummRpt'
      : input.kind === 'summ-item'
        ? 'TagStkItemSumRpt'
        : summary
          ? 'TagItmSumm'
          : 'TagStkRpt';
  const dated = (iso?: string) => (iso ? formatDesktopDate(iso) : '');
  const branch = input.lcCode ? `Branch - ${input.lcCode} ` : '';
  return {
    title: `${branch}${summary ? TAG_STOCK_SUMMARY_TITLE : TAG_STOCK_TITLE}${dated(input.fromDate)} To ${dated(input.toDate)}`,
    template,
  };
}

const format = (kind: TagStockColumn['kind'], value: unknown): string => {
  if (value === null || value === undefined || value === '') return '';
  if (kind === 'wt')
    return Number(value).toLocaleString('en-IN', {
      minimumFractionDigits: 3,
      maximumFractionDigits: 3,
    });
  if (kind === 'amt')
    return Number(value).toLocaleString('en-IN', {
      minimumFractionDigits: 0,
      maximumFractionDigits: 0,
    });
  if (kind === 'date') return formatDesktopDate(value as string);
  return String(value);
};

export function tagStockPrintHtml(input: {
  company: string;
  title: string;
  template: string;
  columns: TagStockColumn[];
  rows: Array<Record<string, unknown>>;
  totals: Record<string, number>;
}): string {
  const numeric = (c: TagStockColumn) => c.kind === 'int' || c.kind === 'wt' || c.kind === 'amt';
  const head = input.columns
    .map((c) => `<th${numeric(c) ? ' class="num"' : ''}>${escapeHtml(c.header)}</th>`)
    .join('');
  const body = input.rows
    .map(
      (row) =>
        `<tr>${input.columns
          .map(
            (c) =>
              `<td${numeric(c) ? ' class="num"' : ''}>${escapeHtml(format(c.kind, row[c.key]))}</td>`,
          )
          .join('')}</tr>`,
    )
    .join('');
  const foot = input.columns
    .map(
      (c) =>
        `<td${numeric(c) ? ' class="num"' : ''} data-col="${escapeHtml(c.key)}">${c.total ? escapeHtml(format(c.kind, input.totals[c.key] ?? 0)) : ''}</td>`,
    )
    .join('');
  return `<!doctype html><html><head><meta charset="utf-8"><title>${escapeHtml(input.title)}</title><style>
body{font:12px Arial,Helvetica,sans-serif;color:#111;margin:16px}
h1{font-size:15px;margin:0}h2{font-size:17px;margin:2px 0 10px}
table{border-collapse:collapse;width:100%}th,td{border:1px solid #999;padding:3px 5px;white-space:nowrap}
th{background:#eee;text-align:left}td.num,th.num{text-align:right}tfoot td{font-weight:bold;background:#f5f5f5}
@media print{body{margin:0}}
</style></head><body data-template="${escapeHtml(input.template)}">
<h1 data-testid="print-company">${escapeHtml(input.company)}</h1>
<h2 data-testid="print-title">${escapeHtml(input.title)}</h2>
<table data-testid="print-table"><thead><tr>${head}</tr></thead><tbody>${body}</tbody><tfoot><tr data-testid="print-footer">${foot}</tr></tfoot></table>
</body></html>`;
}
