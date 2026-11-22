import { decimalCellText, toIsoDate } from '@datacare/core';
import { GstReportRequestError } from './gstReportTypes.js';
import type {
  GstColumn,
  GstDisplayRow,
  GstReportResult,
  GstSection,
  GstView,
  HeaderOnlyGstSection,
  RawGstr3bAggregate,
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

/** EXP: one visible column (width 2000) and no caption, RP_GST.cs:2472-2477. */
const EXP_COLUMNS: readonly GstColumn[] = [{ key: 'export', header: '' }];
/** EXEMP captions, RP_GST.cs:2530-2557. */
const EXEMP_COLUMNS: readonly GstColumn[] = [
  ['description', 'Descripition'],
  ['nilRated', 'Nil Rated Supply'],
  ['exempt', 'Exmp and Non Gst Supply'],
  ['nonGst', 'Non Gst Supply'],
].map(([key, header]) => ({ key: key!, header: header! }));
/** DOCS captions, RP_GST.cs:2599-2622. */
const DOCS_COLUMNS: readonly GstColumn[] = [
  ['nature', 'Nature Of Document'],
  ['serialFrom', 'Sr. No From'],
  ['serialTo', 'Sr. No To'],
  ['totalNumber', 'Total Number'],
  ['cancelled', 'Cancelled'],
].map(([key, header]) => ({ key: key!, header: header! }));

const sectionColumns = (section: GstSection): readonly GstColumn[] =>
  ({
    B2B: B2B_COLUMNS,
    B2CL: B2CL_COLUMNS,
    B2CS: B2CS_COLUMNS,
    CDNR: CDNR_COLUMNS,
    CDNUR: CDNUR_COLUMNS,
    EXP: EXP_COLUMNS,
    AT: ADVANCE_COLUMNS,
    ATADJ: ADVANCE_COLUMNS.map((column) =>
      column.key === 'grossAdvance' ? { ...column, header: 'Gross Advance Adj' } : column,
    ),
    EXEMP: EXEMP_COLUMNS,
    HSN: HSN_COLUMNS,
    DOCS: DOCS_COLUMNS,
  })[section];

const sectionTitle = (section: GstSection): string =>
  ({
    B2B: 'Summary For B2B(4)',
    B2CL: 'Summary For B2CL(5)',
    B2CS: 'Summary For B2CS(7)',
    CDNR: 'Summary For CDNR(9B)',
    CDNUR: 'Summary For CDNUR(9B)',
    EXP: 'Summary For Exp(6)',
    AT: 'Summary For Advance(11B)',
    ATADJ: 'Summary For Adv Adjust(11B)',
    EXEMP: 'Summary For Nill Rated,Exmp and Non Gst outword(8)',
    HSN: 'Summary For HSN(12)',
    DOCS: 'Summary of Doc. issued The Tax Period',
  })[section];

export const HEADER_ONLY_SECTIONS: ReadonlySet<GstSection> = new Set<HeaderOnlyGstSection>([
  'EXP',
  'EXEMP',
  'DOCS',
]);

/**
 * EXP, EXEMP and DOCS: the desktop builds the caption grid (DGV_CLEAR) and then returns before any query - EXP at
 * `case 6: return;` (RP_GST.cs:2700-2701), EXEMP at `case 9: return;` (:2716-2717) - or, for DOCS, runs no query of
 * its own (the switch has no case 11, :2723) and has no row-writing branch. So the screen is the title and captions,
 * with no rows, no totals and no "No Record Found...." message. The web does not run DOCS' stale static query
 * (a desktop weakness, WP-19 study) and computes no nil/exempt/document figures, because the desktop computes none.
 */
export function presentHeaderOnly(view: GstView, section: HeaderOnlyGstSection): GstReportResult {
  const groupCaptions: Record<string, string> | undefined =
    section === 'EXEMP'
      ? {
          nilRated: 'Total Nil Rated Supplies',
          exempt: 'Total Exempted Supplies',
          nonGst: 'Total Non-Gst Supplies',
        }
      : section === 'DOCS'
        ? { totalNumber: 'Total Number', cancelled: 'Total Cancelled' }
        : undefined;
  return {
    view,
    section,
    title: sectionTitle(section),
    fileName: section,
    columns: sectionColumns(section),
    rows: [],
    totals: {},
    metadata: { source: 'RP_GST', headerOnly: true, ...(groupCaptions ? { groupCaptions } : {}) },
  };
}

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
  if (HEADER_ONLY_SECTIONS.has(section)) throw new RangeError('Use presentHeaderOnly');
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

/** `Strings.Format(SUM(...) & "", "0.00")`: an aggregate over no rows is NULL, so the desktop cell is blank. */
const aggregateCell = (amounts: RawGstr3bAggregate, value: string): string =>
  Number(amounts.rowCount) > 0 ? money(value) : '';

type Gstr3bCells = [
  code?: string,
  nature?: string,
  place?: string,
  taxable?: string,
  igst?: string,
  cgst?: string,
  sgst?: string,
  cess?: string,
];

/**
 * The GSTR-3B grid of `BtnGst3Zoom_Click` (RP_GST.cs:3479-3818), row for row. The desktop grid's eight columns are
 * positional: column 0 holds the code ("(a)") or the description ("Integrated Tax"), and the 6.1 block reuses
 * columns 1-4 for Taxpayable and Paid Igst/Cgst/Sgst. The web keeps those positions (desktop column k is web column
 * k + 1) and adds a leading Table No so every row says which table it belongs to. Label rows stay blank: the desktop
 * computes only 3.1(a), 3.1(d), the 3.1 total, 3.2(1), 4(A)(5) and the 6.1 figures.
 *
 * Owner decisions (WP-19, 2026-11-22): every figure sums From..To (Q1; the desktop sums only the From date), All
 * Other ITC is purchases only (Q2; the query filters TRAN_TYPE 'P'), and 6.1 State/Ut Tax is the SGST total (Q3;
 * the desktop prints the CGST total there, RP_GST.cs:3800-3802). 3.1(a) and 3.2(1) count every TAX_SIGN '+' row as the
 * desktop does, purchase returns included (architect decision Q10).
 */
export function presentGstr3b(source: RawGstr3bResult): GstReportResult {
  const rows: GstDisplayRow[] = [];
  const add = (table: string, cells: Gstr3bCells): void => {
    const [code, nature, place, taxable, igst, cgst, sgst, cess] = cells;
    rows.push({
      table,
      code: code ?? '',
      nature: nature ?? '',
      placeOfSupply: place ?? '',
      taxableValue: taxable ?? '',
      igstAmount: igst ?? '',
      cgstAmount: cgst ?? '',
      sgstAmount: sgst ?? '',
      cessAmount: cess ?? '',
    });
  };
  const figures = (amounts: RawGstr3bAggregate): [string, string, string, string] => [
    aggregateCell(amounts, amounts.taxable),
    aggregateCell(amounts, amounts.igst),
    aggregateCell(amounts, amounts.cgst),
    aggregateCell(amounts, amounts.sgst),
  ];
  // The running totals add the displayed cells through Conversion.Val, so a blank cell counts 0 (RP_GST.cs:3555-3558).
  const shown = (...cells: string[]): string => money(addDecimal(...cells.map((c) => c || '0')));

  const outward = figures(source.outward);
  const reverse = figures(source.reverseCharge);
  add('3.1', ['(a)', 'OutWord Taxable Supplies(Other then Zero rated)', '', ...outward]);
  add('3.1', ['(b)', 'OutWord Taxable Supplies (Zero rated) ']);
  add('3.1', ['(c)', 'Other then OutWord Supplies(Nil rated,Exempted) ']);
  add('3.1', ['(d)', 'InWord Supplies(Lible to Reverse Charge)', '', ...reverse]);
  add('3.1', ['(e)', 'Non-Gst OutWord Supplies']);
  const payable = outward.map((cell, index) => shown(cell, reverse[index]!)) as [
    string,
    string,
    string,
    string,
  ];
  add('3.1', ['', '', '', ...payable]);

  add('3.2', [
    '',
    'Inter State Supplies made to Unregistered Persons Comp',
    'osition persons and UIN Holders    ',
  ]);
  add('3.2', ['', '', 'Place of Supplies (State/Ut)', 'Taxable Val', 'Igst Tax ']);
  if (source.unregisteredInterState.length) {
    source.unregisteredInterState.forEach((state, index) => {
      add('3.2', [
        index === 0 ? '(1)' : '',
        index === 0 ? 'Supplies Made ot Unregester Persons' : '',
        `${text(state.stateCode)} - ${text(state.stateName)}`,
        money(state.taxable),
        money(state.igst),
      ]);
    });
  } else {
    add('3.2', ['(1)', 'Supplies Made ot Unregester Persons']);
  }
  add('3.2', ['(2)', 'Supplies Made ot Composition Taxable Persons', '']);
  add('3.2', ['(3)', 'Supplies Made ot UIN Holders', '']);

  add('4', ['4', 'Eligible ITC']);
  add('4', ['(A)', 'ITC Available(Whether in full of part)']);
  add('4(A)', ['(1)', 'Imprt of goods']);
  add('4(A)', ['(2)', 'Imprt of Service']);
  add('4(A)', ['(3)', 'Inword Supplies Liable to Reverse Charge']);
  add('4(A)', ['(4)', 'Inword Supplies From ISD']);
  const itc = figures(source.otherItc);
  add('4(A)', ['(5)', 'All Other ITC)', '', ...itc]);
  add('4', ['(B)', 'ITC Reversed']);
  add('4(B)', ['(1)', 'As per rules 42 & 43 of CGST Rules']);
  add('4(B)', ['(2)', 'Others']);
  add('4', ['(C)', 'Net ITC Avaible (A)-(B)']);
  add('4', ['(D)', 'Ineligible ITC']);
  add('4(D)', ['(1)', 'As per Section 17(5)']);
  add('4(D)', ['(2)', 'Other']);

  add('5', ['5', 'Values of exempt,nil rated and non GST Inword supplies']);
  add('5', ['', 'Supplier Under Composition and nil rated supplies']);
  add('5', ['', 'Non GST Supplies']);

  const paid = itc.map((cell) => shown(cell));
  add('6.1', ['6.1', 'Payment of Tax']);
  // Desktop columns 8 and 9 ("Interest", "Late Fee") have width 0 in this grid and are never visible.
  add('6.1', [
    'Discription',
    'Taxpayable',
    'Paid Igst',
    'Paid Cgst',
    'Paid Sgst',
    'Paid Cess',
    'TDS Paid',
    'Tax Paid In Cash',
  ]);
  add('6.1', ['Integrated Tax', payable[1], paid[1], paid[2], paid[3]]);
  add('6.1', ['Centrel Tax', payable[2]]);
  add('6.1', ['State/Ut Tax', payable[3]]);
  add('6.1', ['Cess']);
  add('6.2', ['6.2', 'TDS/TCS Credit']);
  add('6.2', ['TDS']);
  add('6.2', ['TCS']);

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
      limitations: [
        'Every desktop GSTR-3B row is shown; the desktop computes figures only for 3.1(a), 3.1(d), the 3.1 total, 3.2(1), 4(A)(5) and 6.1, so the other rows are labels.',
        'Figures sum From..To (owner decision WP-19 Q1); 4(A)(5) is purchases only (Q2); 6.1 State/Ut Tax is the SGST total (Q3); 3.1(a) and 3.2(1) count every + row, purchase returns included (Q10).',
      ],
    },
  };
}
