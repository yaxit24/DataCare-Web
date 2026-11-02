import { csvCell } from './reportCsv.js';
import type { GstReportResult } from './gstReportTypes.js';

/**
 * RP_GST writes visible grid columns in their desktop order. The web keeps that order and its ordinary
 * value strings, but deliberately applies RFC-4180 quoting and spreadsheet-formula neutralisation.
 */
export function serializeGstCsv(report: GstReportResult): string {
  const headers = report.columns.map((column) => csvCell(column.header)).join(',');
  const rows = report.rows.map((row) =>
    report.columns.map((column) => csvCell(row[column.key] ?? '')).join(','),
  );
  return `${[headers, ...rows].join('\r\n')}\r\n`;
}
