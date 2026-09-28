import { Prisma } from '@prisma/client';
import type { RptSpec } from './reportEngine.js';
import { evalCrystal } from './crystalFormula.js';
import { UnsupportedReportBindingError, type ReportRow } from './reportBindingContract.js';

export const ORDER_REPORT_COPIES = {
  O: 'ORIGINAL FOR RECIPIENT', D: 'DUPLICATE FOR SUPPLIER', T: 'TRIPLICATE FOR TRANSPORTER',
  CUSTOMER: 'CUSTOMER COPY', ACCOUNT: 'ACCOUNT COPY',
} as const;
export type OrderReportCopy = keyof typeof ORDER_REPORT_COPIES;
export interface BoundSubreport { header: ReportRow; detailRows: ReportRow[] }

/** Database NULL displays blank; zero stays zero. Missing LEFT JOIN rows use the same rule. */
export function completeOrderFields(spec: RptSpec, row: ReportRow): ReportRow {
  return { ...Object.fromEntries(Object.keys(spec.databaseFields ?? {}).map((key) => [key, ''])), ...row };
}

export function sumReportValues(rows: ReportRow[], key: string): string {
  return rows.reduce((sum, row) => sum.add(row[key] || '0'), new Prisma.Decimal(0)).toString();
}

const small = ['zero', 'one', 'two', 'three', 'four', 'five', 'six', 'seven', 'eight', 'nine',
  'ten', 'eleven', 'twelve', 'thirteen', 'fourteen', 'fifteen', 'sixteen', 'seventeen', 'eighteen', 'nineteen'];
const tens = ['', '', 'twenty', 'thirty', 'forty', 'fifty', 'sixty', 'seventy', 'eighty', 'ninety'];
/** Order XML uses UCase(ToWords(amount,0)), not the Indian rupees/paise invoice formatter. */
export function orderWholeAmountWords(value: string): string {
  const rounded = new Prisma.Decimal(value || 0).toDecimalPlaces(0, Prisma.Decimal.ROUND_HALF_UP);
  const integer = BigInt(rounded.abs().toFixed(0));
  const words = (n: bigint): string => {
    if (n < 20n) return small[Number(n)]!;
    if (n < 100n) return tens[Number(n / 10n)]! + (n % 10n ? '-' + words(n % 10n) : '');
    for (const [unit, label] of [[1000000000000000n, 'quadrillion'], [1000000000000n, 'trillion'],
      [1000000000n, 'billion'], [1000000n, 'million'], [1000n, 'thousand'], [100n, 'hundred']] as const) {
      if (n >= unit) return words(n / unit) + ' ' + label + (n % unit ? ' ' + words(n % unit) : '');
    }
    throw new Error('unreachable amount');
  };
  if (integer >= 1000000000000000000n) throw new Error('order amount exceeds supported words range');
  return ((rounded.isNegative() ? 'minus ' : '') + words(integer)).toUpperCase();
}

/** Overrides explicitly supplied by the desktop caller plus the formulas requiring typed arithmetic. */
export function orderFormulaValues(
  spec: RptSpec, header: ReportRow, parents: ReportRow[], received: ReportRow[],
  ledger: { opening: string; closing: string }, copy?: OrderReportCopy,
): ReportRow {
  if (copy != null && !Object.hasOwn(ORDER_REPORT_COPIES, copy))
    throw new UnsupportedReportBindingError(spec.report, 'invalid-order-copy');
  const out: ReportRow = {
    ...header,
    '@InVoiceType': copy ? ORDER_REPORT_COPIES[copy] : 'ORIGINAL',
    '@OldItem': received.length ? 'Y' : 'N',
    '@OpAmt': ledger.opening, '@ClAmt': ledger.closing,
    '@OpAmtCrDr': new Prisma.Decimal(ledger.opening).gt(0) ? 'Cr' : 'Dr',
    '@ClAmtCrDr': new Prisma.Decimal(ledger.closing).gt(0) ? 'Cr' : 'Dr',
    '@Tax': `Tax : ${header['SL_ORD_DATA.TAX_PRC'] || '0'}% :`,
    '@VchGroup': ['CO_YEAR', 'CO_BOOK', 'VCH_NO'].map((key) => header[`SL_ORD_DATA.${key}`] ?? '').join(''),
    '@TotalRecAmt': ['CASH_AMT', 'CARD_AMT', 'CHQ_AMT']
      .reduce((sum, key) => sum.add(header[`SL_ORD_DATA.${key}`] || '0'), new Prisma.Decimal(0)).toString(),
    '#RTotal0': sumReportValues(parents, 'SL_ORD_DETL.ITM_GWT'),
  };
  const wordAmount = header[`SL_ORD_DATA.${spec.report === 'OrderVch' ? 'ADV_AMT' : 'TOT_AMT'}`] || '0';
  out['@WordRuppes'] = new Prisma.Decimal(wordAmount).isZero() ? '' : orderWholeAmountWords(wordAmount);
  // Page numbers are supplied by the order renderer, after pagination.
  for (const name of ['AcAdd1', 'AcAdd2', 'AcGstNo', 'AcMobile', 'CoAdd1', 'CoAdd2', 'CoCity', 'CoName', 'for', 'RptTitle']) {
    const formula = spec.formulas.find((f) => f.name === name)!;
    out[`@${name}`] = evalCrystal(formula.text, (ref) => out[ref.slice(1, -1)] ?? '');
  }
  return out;
}

export function orderParentFormulaValues(spec: RptSpec, row: ReportRow): ReportRow {
  const source = spec.formulas.find((formula) => formula.name === 'ItemName')?.text.trim();
  const designFormula = "{ITEM_MAST.IT_NAME} + ' Dsgn : ' + {SL_ORD_DETL.DESIGN_NO}";
  const tagFormula = `if {SL_ORD_DETL.TAG_NO} <> "" then\n    {SL_ORD_DETL.TAG_NO} + ' - ' + {ITEM_MAST.IT_NAME}\nelse\n${designFormula}`;
  if (source !== designFormula && source !== tagFormula)
    throw new UnsupportedReportBindingError(spec.report, 'unsupported-order-item-name-formula');
  const tag = row['SL_ORD_DETL.TAG_NO'] ?? '';
  // OrderBill always prints the design. Only TourOrdVch's source formula selects a tag prefix.
  return { ...row, '@ItemName': source === tagFormula && tag !== ''
    ? `${tag} - ${row['ITEM_MAST.IT_NAME'] ?? ''}`
    : `${row['ITEM_MAST.IT_NAME'] ?? ''} Dsgn : ${row['SL_ORD_DETL.DESIGN_NO'] ?? ''}` };
}

/** Every extracted order suppression is an equality against zero or a literal string. */
export function suppressOrderField(expression: string | undefined, row: ReportRow): boolean {
  if (!expression) return false;
  const match = expression.match(/^\{([^}]+)\}\s*=\s*(?:'([^']*)'|(0))\s*$/);
  if (!match) throw new Error(`Unsupported order suppression: ${expression}`);
  const value = row[match[1]!] ?? '';
  return match[3] ? new Prisma.Decimal(value || 0).isZero() : value === match[2];
}
