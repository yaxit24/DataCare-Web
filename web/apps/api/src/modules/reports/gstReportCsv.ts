import { csvCell } from './reportCsv.js';
import type { GstReportResult } from './gstReportTypes.js';

/**
 * A signed plain decimal such as `-206.00`. The GST report builds these strings itself from numeric columns, and
 * the desktop writes them bare (RP_GST.cs:3114-3145, SaveCSV). Anything else, including party names and GSTINs,
 * goes through csvCell so a leading `=`, `+`, `-` or `@` cannot become a spreadsheet formula.
 */
const SIGNED_DECIMAL = /^-\d+(?:\.\d+)?$/;

function gstCsvCell(value: unknown): string {
  const text = String(value ?? '');
  return SIGNED_DECIMAL.test(text) ? text : csvCell(text);
}

/**
 * RP_GST writes visible grid columns in their desktop order. The web keeps that order and its ordinary
 * value strings, but deliberately applies RFC-4180 quoting and spreadsheet-formula neutralisation to text.
 * Negative amounts (returns, credit notes) stay numeric, as in the desktop file.
 */
export function serializeGstCsv(report: GstReportResult): string {
  const headers = report.columns.map((column) => csvCell(column.header)).join(',');
  const rows = report.rows.map((row) =>
    report.columns.map((column) => gstCsvCell(row[column.key] ?? '')).join(','),
  );
  return `${[headers, ...rows].join('\r\n')}\r\n`;
}
