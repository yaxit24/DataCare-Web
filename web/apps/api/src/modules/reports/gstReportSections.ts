import { decimalCellText, toIsoDate } from '@datacare/core';
import { GstReportRequestError } from './gstReportTypes.js';
import type {
  GstColumn,
  GstDisplayRow,
  GstReportResult,
  GstSection,
  GstView,
  RawGstr3bResult,
  RawHsnReportRow,
  RawTaxReportRow,
} from './gstReportTypes.js';

const MONTHS = ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'];
const money = (value: unknown): string => decimalCellText(String(value ?? '0') || '0', 2);
const whole = (value: unknown): string => decimalCellText(String(value ?? '0') || '0', 0);
const text = (value: unknown): string => String(value ?? '').trim();

interface DecimalParts {
  value: bigint;
  scale: number;
}

function decimalParts(raw: unknown): DecimalParts {
  const value = text(raw) || '0';
  const match = /^([+-]?)(\d+)(?:\.(\d+))?$/.exec(value);
  if (!match) throw new RangeError(`invalid decimal: ${value.slice(0, 40)}`);
  const fraction = match[3] ?? '';
  const sign = match[1] === '-' ? -1n : 1n;
  return { value: sign * BigInt(`${match[2]}${fraction}`), scale: fraction.length };
}

function decimalString(parts: DecimalParts): string {
  const negative = parts.value < 0n;
  const digits = (negative ? -parts.value : parts.value).toString().padStart(parts.scale + 1, '0');
  const body = parts.scale
    ? `${digits.slice(0, -parts.scale)}.${digits.slice(-parts.scale)}`
    : digits;
  return negative ? `-${body}` : body;
}

function addDecimal(...raw: unknown[]): string {
  const parts = raw.map(decimalParts);
  const scale = parts.reduce((max, part) => Math.max(max, part.scale), 0);
  const value = parts.reduce(
    (sum, part) => sum + part.value * 10n ** BigInt(scale - part.scale),
    0n,
  );
  return decimalString({ value, scale });
}

function subtractDecimal(left: unknown, right: unknown): string {
  const part = decimalParts(right);
  return addDecimal(left, decimalString({ ...part, value: -part.value }));
}

function halfDecimal(raw: unknown): string {
  const part = decimalParts(raw);
  return decimalString({ value: part.value * 5n, scale: part.scale + 1 });
}

/**
 * `Strings.Format(x, "0.00")` as the desktop runs it (.NET Framework 4.8): half away from zero at an exact midpoint,
 * and a value that rounds to zero prints `0.00`, never `-0.00` (`decimalCellText` keeps the sign of a tiny negative).
 * Measured on a windows-latest runner (CLR 4.0.30319.42000): 2.5 M positive and 2 M negative 2-decimal midpoints,
 * 3 M 3-4 decimal taxes and 8 M IGST values all agree with half away from zero (`web/scripts/dotnet-fx-probe`).
 */
const framework2dp = (value: unknown): string => {
  const shown = money(value);
  return shown === '-0.00' ? '0.00' : shown;
};

function sumDisplayed(rows: readonly GstDisplayRow[], key: string): string {
  return money(addDecimal(...rows.map((row) => row[key] || '0')));
}

export function formatGstDate(value: unknown): string {
  const iso = toIsoDate(value);
  if (!iso) return '';
  const [year, month, day] = iso.split('-');
  return `${day}-${MONTHS[Number(month) - 1]}-${year!.slice(-2)}`;
}

export function classifyB2c(gstin: unknown, invoiceValue: unknown): 'B2B' | 'B2CL' | 'B2CS' {
  if (text(gstin)) return 'B2B';
  const amount = decimalParts(invoiceValue);
  return amount.value >= 250000n * 10n ** BigInt(amount.scale) ? 'B2CL' : 'B2CS';
}

const B2B_COLUMNS: readonly GstColumn[] = [
  ['gstin', 'GSTIN/UIN'],
  ['receiverName', 'Receiver Name'],
  ['invoiceNo', 'Invoice No'],
  ['invoiceDate', 'Invoice Date'],
  ['invoiceValue', 'Invoice Value'],
  ['placeOfSupply', 'Plase Of Supply'],
  ['reverseCharge', 'R Charg'],
  ['applicableTaxRate', 'App% Rate'],
  ['invoiceType', 'Invoice Type'],
  ['ecommerceGstin', 'E-Com GSTIN'],
  ['rate', 'Rate'],
  ['taxableValue', 'Taxable Value'],
  ['cessAmount', 'Cess Amt'],
].map(([key, header]) => ({ key: key!, header: header! }));
const B2CL_COLUMNS: readonly GstColumn[] = [
  ['invoiceNo', 'Invoice No'],
  ['invoiceDate', 'Invoice Date'],
  ['invoiceValue', 'Invoice Value'],
  ['placeOfSupply', 'Plase Of Supply'],
  ['applicableTaxRate', 'App% Rate'],
  ['rate', 'Rate'],
  ['taxableValue', 'Taxable Value'],
  ['cessAmount', 'Cess Amt'],
  ['ecommerceGstin', 'E-Com GSTIN'],
].map(([key, header]) => ({ key: key!, header: header! }));
const B2CS_COLUMNS: readonly GstColumn[] = [
  ['type', 'Type'],
  ['placeOfSupply', 'Plase Of Supply'],
  ['applicableTaxRate', 'App% Rate'],
  ['rate', 'Rate'],
  ['taxableValue', 'Taxable Value'],
  ['cessAmount', 'Cess Amt'],
  ['ecommerceGstin', 'E-Com GSTIN'],
].map(([key, header]) => ({ key: key!, header: header! }));
const CDNR_COLUMNS: readonly GstColumn[] = [
  ['gstin', 'GSTIN/UIN'],
  ['receiverName', 'Receiver Name'],
  ['originalInvoiceNo', 'Invoice/Advanc RecNo'],
  ['originalInvoiceDate', 'Invoice/Advanc RecDate'],
  ['refundVoucherNo', 'Refund VchNo'],
  ['refundVoucherDate', 'Refund VchDate'],
  ['noteType', 'Dc Type'],
  ['placeOfSupply', 'Plase Of Supply'],
  ['noteValue', 'Note Refund Val'],
  ['applicableTaxRate', 'App% Rate'],
  ['rate', 'Rate'],
  ['taxableValue', 'Taxable Value'],
  ['cessAmount', 'Cess Amt'],
  ['preGst', 'Pre Gst'],
].map(([key, header]) => ({ key: key!, header: header! }));
const CDNUR_COLUMNS: readonly GstColumn[] = [
  ['urType', 'UR Type'],
  ['refundVoucherNo', 'Refund VchNo'],
  ['refundVoucherDate', 'Refund VchDate'],
  ['noteType', 'Dc Type'],
  ['originalInvoiceNo', 'Invoice/Advanc RecNo'],
  ['originalInvoiceDate', 'Invoice/Advanc RecDate'],
  ['noteReason', 'Note Reason'],
  ['placeOfSupply', 'Plase Of Supply'],
  ['noteValue', 'Note Refund Val'],
  ['applicableTaxRate', 'App% Rate'],
  ['rate', 'Rate'],
  ['taxableValue', 'Taxable Value'],
  ['cessAmount', 'Cess Amt'],
  ['preGst', 'Pre Gst'],
].map(([key, header]) => ({ key: key!, header: header! }));
const ADVANCE_COLUMNS: readonly GstColumn[] = [
  ['placeOfSupply', 'Plase Of Supply'],
  ['applicableTaxRate', 'App% Rate'],
  ['rate', 'Rate'],
  ['grossAdvance', 'Gross Advance Rec'],
  ['cessAmount', 'Cess Amt'],
].map(([key, header]) => ({ key: key!, header: header! }));
const HSN_COLUMNS: readonly GstColumn[] = [
  ['hsn', 'HSN'],
  ['description', 'Descripition'],
  ['uqc', 'UQC'],
  ['totalQuantity', 'Total Qty'],
  ['totalValue', 'Total Value'],
  ['taxableValue', 'Taxable Value'],
  ['igstAmount', 'IGST Amount'],
  ['cgstAmount', 'CGST Amount'],
  ['sgstAmount', 'SGST Amount'],
  ['cessAmount', 'Total Cess'],
].map(([key, header]) => ({ key: key!, header: header! }));

const sectionColumns = (section: GstSection): readonly GstColumn[] =>
  ({
    B2B: B2B_COLUMNS,
    B2CL: B2CL_COLUMNS,
    B2CS: B2CS_COLUMNS,
    CDNR: CDNR_COLUMNS,
    CDNUR: CDNUR_COLUMNS,
    AT: ADVANCE_COLUMNS,
    ATADJ: ADVANCE_COLUMNS.map((column) =>
      column.key === 'grossAdvance' ? { ...column, header: 'Gross Advance Adj' } : column,
    ),
    HSN: HSN_COLUMNS,
  })[section];

const sectionTitle = (section: GstSection): string =>
  ({
    B2B: 'Summary For B2B(4)',
    B2CL: 'Summary For B2CL(5)',
    B2CS: 'Summary For B2CS(7)',
    CDNR: 'Summary For CDNR(9B)',
    CDNUR: 'Summary For CDNUR(9B)',
    AT: 'Summary For Advance(11B)',
    ATADJ: 'Summary For Adv Adjust(11B)',
    HSN: 'Summary For HSN(12)',
  })[section];

function place(row: RawTaxReportRow): string {
  return [text(row.stateCode), text(row.stateName)].filter(Boolean).join(' - ');
}
function voucher(row: RawTaxReportRow): string {
  return [text(row.bookPrefix), text(row.voucherNo)].filter(Boolean).join('-');
}
function originalVoucher(row: RawTaxReportRow): string {
  if (row.bookName === 'SALES RETURNE') {
    return [text(row.billBookPrefix), text(row.billNo)].filter(Boolean).join('-');
  }
  return text(row.billNo);
}
function note(row: RawTaxReportRow): { type: string; reason: string } {
  return row.bookName === 'SALES RETURNE'
    ? { type: 'C', reason: 'Sales Return' }
    : { type: 'D', reason: 'Debit Note' };
}
function groupOrder(left: RawTaxReportRow, right: RawTaxReportRow): number {
  return [left.stateCode, left.stateName, left.taxCode ?? '', left.taxRate]
    .map(text)
    .join('\u0000')
    .localeCompare(
      [right.stateCode, right.stateName, right.taxCode ?? '', right.taxRate]
        .map(text)
        .join('\u0000'),
    );
}

function groupedRows(source: RawTaxReportRow[]): RawTaxReportRow[] {
  const rows = new Map<string, RawTaxReportRow>();
  for (const row of source) {
    const key = [
      row.coBook,
      row.bookName,
      row.bookPrefix,
      row.acCode,
      row.acName,
      row.gstin,
      row.stateCode,
      row.stateName,
      row.voucherNo,
      row.voucherDate,
      row.invoiceValue,
      row.reverseCharge,
      row.taxCode ?? '',
      row.taxRate,
      row.netAmount,
      row.discountAmount,
      row.billBookPrefix,
      row.billNo,
      row.billDate,
    ].join('\u0000');
    if (!rows.has(key)) rows.set(key, row);
  }
  return [...rows.values()];
}

function rowsForSection(
  view: GstView,
  section: GstSection,
  source: RawTaxReportRow[],
): GstDisplayRow[] {
  if (section === 'B2CS') {
    const grouped = new Map<string, RawTaxReportRow>();
    for (const row of source) {
      const key = `${row.stateCode}\u0000${row.stateName}\u0000${row.taxCode ?? ''}\u0000${row.taxRate}`;
      const old = grouped.get(key);
      grouped.set(
        key,
        old
          ? {
              ...old,
              netAmount: addDecimal(old.netAmount, row.netAmount),
              discountAmount: addDecimal(old.discountAmount, row.discountAmount),
            }
          : { ...row },
      );
    }
    return [...grouped.values()].sort(groupOrder).map((row) => ({
      type: 'OE',
      placeOfSupply: place(row),
      applicableTaxRate: '',
      rate: money(row.taxRate),
      taxableValue: money(
        view === 'gstr1' ? subtractDecimal(row.netAmount, row.discountAmount) : row.netAmount,
      ),
      cessAmount: '0',
      ecommerceGstin: '',
    }));
  }
  if (section === 'AT' || section === 'ATADJ') {
    const grouped = new Map<string, RawTaxReportRow>();
    for (const row of source) {
      const key = `${row.stateCode}\u0000${row.stateName}\u0000${row.taxCode ?? ''}\u0000${row.taxRate}`;
      const old = grouped.get(key);
      grouped.set(
        key,
        old ? { ...old, netAmount: addDecimal(old.netAmount, row.netAmount) } : { ...row },
      );
    }
    return [...grouped.values()].sort(groupOrder).map((row) => ({
      placeOfSupply: place(row),
      applicableTaxRate: '',
      rate: money(row.taxRate),
      grossAdvance: money(row.netAmount),
      cessAmount: '0',
    }));
  }
  if (section === 'B2B')
    return groupedRows(source).map((row) => ({
      gstin: text(row.gstin),
      receiverName: text(row.acName),
      invoiceNo: voucher(row),
      invoiceDate: formatGstDate(row.voucherDate),
      invoiceValue: money(row.invoiceValue),
      placeOfSupply: place(row),
      reverseCharge: text(row.reverseCharge) || 'N',
      applicableTaxRate: '',
      invoiceType: 'Regular',
      ecommerceGstin: '',
      rate: money(row.taxRate),
      taxableValue:
        view === 'gstr1'
          ? whole(subtractDecimal(row.netAmount, row.discountAmount))
          : money(row.netAmount),
      cessAmount: '0',
    }));
  if (section === 'B2CL')
    return groupedRows(source).map((row) => ({
      invoiceNo: voucher(row),
      invoiceDate: formatGstDate(row.voucherDate),
      invoiceValue: money(row.invoiceValue),
      placeOfSupply: place(row),
      applicableTaxRate: '',
      rate: money(row.taxRate),
      taxableValue: money(row.netAmount),
      cessAmount: '0',
      ecommerceGstin: '',
    }));
  return groupedRows(source).map((row) => {
    const labels = note(row);
    const common = {
      refundVoucherNo: voucher(row),
      refundVoucherDate: formatGstDate(row.voucherDate),
      noteType: labels.type,
      originalInvoiceNo: originalVoucher(row),
      originalInvoiceDate: formatGstDate(row.billDate),
      placeOfSupply: place(row),
      noteValue: money(row.invoiceValue),
      applicableTaxRate: '',
      rate: money(row.taxRate),
      taxableValue: money(row.netAmount),
      cessAmount: '0',
      preGst: 'N',
    };
    return section === 'CDNR'
      ? { gstin: text(row.gstin), receiverName: text(row.acName), ...common }
      : {
          urType: classifyB2c('', row.invoiceValue),
          noteReason: labels.reason,
          ...common,
        };
  });
}

export function presentTaxSection(
  view: GstView,
  section: GstSection,
  source: RawTaxReportRow[],
): GstReportResult {
  if (section === 'HSN') throw new RangeError('Use presentHsn for HSN');
  const rows = rowsForSection(view, section, source);
  const totals: GstDisplayRow = {};
  if (section === 'B2B' || section === 'B2CL') {
    totals.invoiceValue = sumDisplayed(rows, 'invoiceValue');
    totals.taxableValue = sumDisplayed(rows, 'taxableValue');
    totals.cessAmount = sumDisplayed(rows, 'cessAmount');
    totals.invoiceCount = String(new Set(rows.map((row) => row.invoiceNo)).size);
  } else if (section === 'CDNR' || section === 'CDNUR') {
    totals.noteValue = sumDisplayed(rows, 'noteValue');
    totals.taxableValue = sumDisplayed(rows, 'taxableValue');
    totals.cessAmount = sumDisplayed(rows, 'cessAmount');
    totals.noteCount = String(new Set(rows.map((row) => row.refundVoucherNo)).size);
  } else {
    totals[section === 'AT' || section === 'ATADJ' ? 'grossAdvance' : 'taxableValue'] =
      sumDisplayed(rows, section === 'AT' || section === 'ATADJ' ? 'grossAdvance' : 'taxableValue');
    totals.cessAmount = sumDisplayed(rows, 'cessAmount');
  }
  return {
    view,
    section,
    title: sectionTitle(section),
    fileName: section,
    columns: sectionColumns(section),
    rows,
    totals,
    metadata: { source: 'RP_GST' },
  };
}

const DESCRIPTIONS: Readonly<Record<string, string>> = {
  G: 'Gold',
  S: 'Silver',
  D: 'Diamond',
  R: 'Real Stone',
  E: 'Emetation',
  O: 'Other',
  B: 'Bronze',
  H: 'H-Brass',
  M: 'Mix Metal',
};

export function presentHsn(source: RawHsnReportRow[]): GstReportResult {
  const rows = source.map((row) => {
    const local = text(row.gstType) === 'L';
    const localHalf = halfDecimal(row.itemTax);
    const taxable = subtractDecimal(row.itemAmount, row.itemDiscount);
    return {
      hsn: text(row.hsn),
      description: DESCRIPTIONS[text(row.itemType)] ?? '',
      uqc: text(row.rateType) === 'G' ? 'GMS-GRAMMES' : 'PCS',
      totalQuantity: money(row.quantity),
      totalValue: money(
        addDecimal(
          row.itemAmount,
          row.itemTax,
          decimalString({
            ...decimalParts(row.itemDiscount),
            value: -decimalParts(row.itemDiscount).value,
          }),
        ),
      ),
      taxableValue: money(taxable),
      igstAmount: framework2dp(local ? '0' : row.itemTax),
      cgstAmount: framework2dp(local ? localHalf : '0'),
      sgstAmount: framework2dp(local ? localHalf : '0'),
      cessAmount: '0.00',
    };
  });
  return {
    view: 'gstr1',
    section: 'HSN',
    title: sectionTitle('HSN'),
    fileName: 'HSNSUM',
    columns: HSN_COLUMNS,
    rows,
    totals: {
      totalValue: sumDisplayed(rows, 'totalValue'),
      taxableValue: sumDisplayed(rows, 'taxableValue'),
      igstAmount: sumDisplayed(rows, 'igstAmount'),
      cgstAmount: sumDisplayed(rows, 'cgstAmount'),
      sgstAmount: sumDisplayed(rows, 'sgstAmount'),
      cessAmount: sumDisplayed(rows, 'cessAmount'),
    },
    metadata: { source: 'RP_GST' },
  };
}

const GSTR3B_COLUMNS: readonly GstColumn[] = [
  ['table', 'Table No'],
  ['code', 'Code'],
  ['nature', 'Nature of Supplies'],
  ['placeOfSupply', 'Place of Supplies'],
  ['taxableValue', 'Total Taxable'],
  ['igstAmount', 'Igst Tax'],
  ['cgstAmount', 'Cgst Tax'],
  ['sgstAmount', 'Sgst/UT Tax'],
  ['cessAmount', 'Cess'],
].map(([key, header]) => ({ key: key!, header: header! }));

export function presentGstr3b(source: RawGstr3bResult): GstReportResult {
  const row = (
    table: string,
    code: string,
    nature: string,
    amounts: RawGstr3bResult['outward'],
  ): GstDisplayRow => ({
    table,
    code,
    nature,
    placeOfSupply: '',
    taxableValue: money(amounts.taxable),
    igstAmount: money(amounts.igst),
    cgstAmount: money(amounts.cgst),
    sgstAmount: money(amounts.sgst),
    cessAmount: '',
  });
  const rows = [
    row('3.1', '(a)', 'OutWord Taxable Supplies(Other then Zero rated)', source.outward),
    row('3.1', '(d)', 'InWord Supplies(Lible to Reverse Charge)', source.reverseCharge),
    row('4(A)', '(5)', 'All Other ITC)', source.otherItc),
  ];
  return {
    view: 'gstr3b',
    section: null,
    title: 'GSTR 3B',
    fileName: 'GSTR3B',
    columns: GSTR3B_COLUMNS,
    rows,
    totals: {},
    metadata: {
      source: 'RP_GST',
      blockedRows: [
        '3.1(b)',
        '3.1(c)',
        '3.1(e)',
        '3.2(2)',
        '3.2(3)',
        '4(A)(1)',
        '4(A)(2)',
        '4(A)(3)',
        '4(A)(4)',
        '4(B)',
        '4(C)',
        '4(D)',
        '5',
        '6.1',
        '6.2',
      ],
      limitations: [
        'Only desktop-computed outward, reverse-charge and all-other-ITC rows are emitted.',
      ],
    },
  };
}
