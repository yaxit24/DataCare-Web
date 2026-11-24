import type { XlsxColumn, XlsxSheet } from './xlsx.js';
import type { FinePrintResult } from './ledgerFinePrints.js';

/**
 * Layout of the Ledger Report fine prints for the PDF and Excel outputs. The PDF goes through the same
 * server-built report document as `/reports/account-ledger/export.pdf` (`reportPdfHtml` reads scalar fields as
 * summary cards and every array as a table), so this file only flattens a print result into that shape.
 */
export function finePrintPdfResult(result: FinePrintResult): Record<string, unknown> {
  return {
    report: result.report,
    title: result.title,
    account: result.account.acCode,
    name: result.account.acName,
    fromDate: result.period.fromDate,
    toDate: result.period.toDate,
    openingAmount: result.opening.amount,
    openingFine: result.opening.fine,
    closingAmount: result.closing.amount,
    closingFine: result.closing.fine,
    parameters: result.parameters.map((text) => ({ parameter: text })),
    rows: result.rows,
    totals: result.totals,
  };
}

const text = (header: string, key: string, width = 16): XlsxColumn => ({
  header,
  key,
  type: 'text',
  width,
});
const num = (header: string, key: string, format: string): XlsxColumn => ({
  header,
  key,
  type: 'number',
  format,
  width: 12,
});

/**
 * One Excel sheet: an Opening Balance row, the print rows, a Closing Balance row (the PDF's balances, as the desktop
 * passes them to the report: RP_LEDR.cs:8411-8414 Gold, :9042-9045 Silver, :4065-4066 Jama/Udhar) and a totals row.
 * Fine In and Fine Out are real columns, so the totals keys match a column and are written.
 */
export function finePrintSheet(result: FinePrintResult): XlsxSheet {
  const columns: XlsxColumn[] = [
    text('Book', 'bookName'),
    text('Vch No', 'vchNo', 10),
    text('Date', 'date', 12),
    text('Item', 'itCode', 8),
    text('Description', 'itDesc', 28),
    text('Tag', 'tagNo', 12),
    num('Pcs', 'pcs', '0'),
    num('Gross Wt', 'grossWt', '0.000'),
    num('Net Wt', 'netWt', '0.000'),
    num('Touch', 'touch', '0.000'),
    num('West', 'west', '0.000'),
    num('Fine', 'fine', '0.000'),
    num('Fine In', 'fineIn', '0.000'),
    num('Fine Out', 'fineOut', '0.000'),
    num('Rate', 'rate', '0.00'),
    num('Amount', 'amount', '0.00'),
    num('Cr Amt', 'crAmt', '0.00'),
    num('Dr Amt', 'drAmt', '0.00'),
    text('Sign', 'sign', 6),
  ];
  const withFine = result.report.startsWith('JmUdFine');
  const balanceRow = (label: string, b: { amount: number; fine: number }) => ({
    itDesc: label,
    amount: b.amount,
    ...(withFine ? { fine: b.fine } : {}),
  });
  const rows = (result.rows as unknown as Record<string, unknown>[]).map((r) => ({
    ...r,
    fineIn: r.sign === '+' ? r.fine : null,
    fineOut: r.sign === '-' ? r.fine : null,
  }));
  return {
    name: result.report,
    columns,
    rows: [
      balanceRow('Opening Balance', result.opening),
      ...rows,
      balanceRow('Closing Balance', result.closing),
    ],
    totals: { itDesc: 'Total', ...result.totals } as unknown as Record<string, unknown>,
  };
}
