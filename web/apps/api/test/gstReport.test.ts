import { describe, expect, it } from 'vitest';
import {
  classifyB2c,
  presentGstr3b,
  presentHeaderOnly,
  presentHsn,
  presentTaxSection,
} from '../src/modules/reports/gstReportSections.js';
import {
  assertGstCsvSection,
  GST_WORKBOOK_SECTIONS,
  parseGstReportQuery,
} from '../src/modules/reports/gstReport.js';
import { serializeGstCsv } from '../src/modules/reports/gstReportCsv.js';

const tax = (overrides: Record<string, unknown> = {}) => ({
  coBook: 'SL',
  bookName: 'SALES',
  bookPrefix: 'S',
  acCode: 'C1',
  acName: 'Buyer',
  gstin: '',
  stateCode: '24',
  stateName: 'Gujarat',
  voucherNo: '00001',
  voucherDate: '2024-04-05',
  invoiceValue: '1000.00',
  reverseCharge: '',
  taxRate: '3.0000',
  netAmount: '1000.00',
  discountAmount: '0.00',
  billBookPrefix: 'S',
  billNo: '00000',
  billDate: '2024-04-01',
  ...overrides,
});

describe('RP_GST source-settled pure sections', () => {
  it('classifies unregistered B2CL at and above 250000 without an interstate predicate', () => {
    expect(classifyB2c('', '249999.99')).toBe('B2CS');
    expect(classifyB2c('', '250000.00')).toBe('B2CL');
    expect(classifyB2c('', '250000.01')).toBe('B2CL');
    expect(classifyB2c('24ABCDE1234F1Z5', '900000.00')).toBe('B2B');
  });

  it('groups B2CS by place and rate and totals displayed two-decimal rows', () => {
    const out = presentTaxSection('gstr1', 'B2CS', [
      tax({ netAmount: '100.005', discountAmount: '0', taxRate: '3' }),
      tax({ netAmount: '50.005', discountAmount: '0', taxRate: '3' }),
      tax({ stateCode: '27', stateName: 'Maharashtra', netAmount: '9.994', taxRate: '5' }),
    ]);
    expect(out.rows).toEqual([
      {
        type: 'OE',
        placeOfSupply: '24 - Gujarat',
        applicableTaxRate: '',
        rate: '3.00',
        taxableValue: '150.01',
        cessAmount: '0',
        ecommerceGstin: '',
      },
      {
        type: 'OE',
        placeOfSupply: '27 - Maharashtra',
        applicableTaxRate: '',
        rate: '5.00',
        taxableValue: '9.99',
        cessAmount: '0',
        ecommerceGstin: '',
      },
    ]);
    expect(out.totals).toEqual({ taxableValue: '160.00', cessAmount: '0.00' });
  });

  it('preserves return and note labels, references, signs and threshold equality', () => {
    const c = presentTaxSection('gstr1', 'CDNR', [
      tax({
        gstin: '24ABCDE1234F1Z5',
        bookName: 'SALES RETURNE',
        voucherNo: '00009',
        invoiceValue: '125.50',
        netAmount: '120.50',
      }),
      tax({
        gstin: '24ABCDE1234F1Z5',
        bookName: 'PURC RETURN',
        voucherNo: '00010',
        billNo: 'P42',
        invoiceValue: '75',
        netAmount: '70',
      }),
    ]);
    expect(c.rows.map((row) => [row.noteType, row.originalInvoiceNo])).toEqual([
      ['C', 'S-00000'],
      ['D', 'P42'],
    ]);
    const u = presentTaxSection('gstr1', 'CDNUR', [
      tax({ bookName: 'SALES RETURNE', invoiceValue: '250000.00' }),
    ]);
    expect(u.rows[0]).toMatchObject({ urType: 'B2CL', noteType: 'C', noteReason: 'Sales Return' });
  });

  it('uses per-displayed-row rounding before report totals', () => {
    const out = presentTaxSection('gstr1', 'B2CL', [
      tax({ invoiceValue: '250000', netAmount: '1.005' }),
      tax({ voucherNo: '00002', invoiceValue: '250001', netAmount: '1.005' }),
    ]);
    expect(out.rows.map((row) => row.taxableValue)).toEqual(['1.01', '1.01']);
    expect(out.totals).toMatchObject({ taxableValue: '2.02' });
  });

  it('presents HSN quantity, returns, value and local/interstate tax splits', () => {
    const out = presentHsn([
      {
        hsn: '7113',
        rateType: 'G',
        itemType: 'G',
        gstType: 'L',
        quantity: '4.25',
        itemAmount: '1000',
        itemTax: '30',
        itemDiscount: '10',
      },
      {
        hsn: '7113',
        rateType: 'G',
        itemType: 'G',
        gstType: 'I',
        quantity: '-1.25',
        itemAmount: '-200',
        itemTax: '-6',
        itemDiscount: '0',
      },
      {
        hsn: '998892',
        rateType: 'P',
        itemType: 'O',
        gstType: 'L',
        quantity: '2',
        itemAmount: '40',
        itemTax: '1.2',
        itemDiscount: '0',
      },
    ]);
    expect(out.rows).toEqual([
      {
        hsn: '7113',
        description: 'Gold',
        uqc: 'GMS-GRAMMES',
        totalQuantity: '4.25',
        totalValue: '1020.00',
        taxableValue: '990.00',
        igstAmount: '0.00',
        cgstAmount: '15.00',
        sgstAmount: '15.00',
        cessAmount: '0.00',
      },
      {
        hsn: '7113',
        description: 'Gold',
        uqc: 'GMS-GRAMMES',
        totalQuantity: '-1.25',
        totalValue: '-206.00',
        taxableValue: '-200.00',
        igstAmount: '-6.00',
        cgstAmount: '0.00',
        sgstAmount: '0.00',
        cessAmount: '0.00',
      },
      {
        hsn: '998892',
        description: 'Other',
        uqc: 'PCS',
        totalQuantity: '2.00',
        totalValue: '41.20',
        taxableValue: '40.00',
        igstAmount: '0.00',
        cgstAmount: '0.60',
        sgstAmount: '0.60',
        cessAmount: '0.00',
      },
    ]);
    expect(out.totals).toMatchObject({
      totalValue: '855.20',
      taxableValue: '830.00',
      igstAmount: '-6.00',
      cgstAmount: '15.60',
      sgstAmount: '15.60',
    });
  });

  describe('HSN local half-tax at an exact 2-decimal midpoint (RP_GST.cs:2951-2964)', () => {
    // Expected values are NOT computed by the code under test. They were measured on windows-latest, .NET Framework
    // 4.8 (CLR 4.0.30319.42000), by calling the desktop's own functions, Strings.Format(Conversion.Val(tax) / 2.0,
    // "0.00"): workflow dotnet-fx-probe.yml, run 41448006972 and its successors (SPOT lines and RESULT/RESULT2/RESULT3).
    const hsn = (itemTax: string, gstType = 'L') =>
      presentHsn([
        {
          hsn: '7113',
          rateType: 'G',
          itemType: 'G',
          gstType,
          quantity: '1',
          itemAmount: '10',
          itemTax,
          itemDiscount: '0',
        },
      ]).rows[0]!;

    it.each([
      ['1.21', '0.61'],
      ['1908.29', '954.15'], // the 3% gold bill of the 2 Nov probe; Framework SPOT line: 1908.29 -> 954.15
      ['2043.29', '1021.65'], // the printed-invoice bill of G181
      ['0.01', '0.01'],
      ['0.03', '0.02'],
      ['0.05', '0.03'],
      ['0.07', '0.04'],
      ['0.09', '0.05'],
      ['9999999.99', '5000000.00'],
    ])('rounds the half of %s to %s, away from zero, for both CGST and SGST', (tax, half) => {
      expect(hsn(tax)).toMatchObject({ cgstAmount: half, sgstAmount: half, igstAmount: '0.00' });
    });

    it('rounds a negative (sales-return) midpoint away from zero too', () => {
      expect(hsn('-1.21')).toMatchObject({ cgstAmount: '-0.61', sgstAmount: '-0.61' });
      expect(hsn('-1908.29')).toMatchObject({ cgstAmount: '-954.15', sgstAmount: '-954.15' });
    });

    it('prints a value that rounds to zero as 0.00, never -0.00 (Framework NEGZERO line)', () => {
      expect(hsn('-0.004')).toMatchObject({ cgstAmount: '0.00', sgstAmount: '0.00' });
      expect(hsn('-0.004', 'I')).toMatchObject({ igstAmount: '0.00' });
    });

    it('does not refuse the section, so the totals add the displayed halves', () => {
      const out = presentHsn([
        {
          hsn: '7113',
          rateType: 'G',
          itemType: 'G',
          gstType: 'L',
          quantity: '1',
          itemAmount: '10',
          itemTax: '1.21',
          itemDiscount: '0',
        },
        {
          hsn: '7113',
          rateType: 'P',
          itemType: 'G',
          gstType: 'L',
          quantity: '1',
          itemAmount: '10',
          itemTax: '1.21',
          itemDiscount: '0',
        },
      ]);
      expect(out.totals).toMatchObject({ cgstAmount: '1.22', sgstAmount: '1.22' });
      expect(out.metadata.limitations).toBeUndefined();
    });
  });

  // RP_GST.cs:3479-3818 row for row. Inputs are the SQL aggregates; every expected cell below is worked by hand.
  const aggregate = (
    taxable: string,
    igst: string,
    cgst: string,
    sgst: string,
    rowCount = '2',
  ) => ({
    rowCount,
    taxable,
    igst,
    cgst,
    sgst,
  });
  const grid = presentGstr3b({
    outward: aggregate('1000.005', '30', '15.125', '15.125'),
    reverseCharge: aggregate('100', '3', '1.5', '1.5'),
    otherItc: aggregate('400', '12', '6', '7'),
    unregisteredInterState: [
      { stateCode: '27', stateName: 'Maharashtra', taxable: '250', igst: '7.5' },
      { stateCode: '33', stateName: 'Tamil Nadu', taxable: '80', igst: '2.4' },
    ],
  });
  const cells = (row: Record<string, string>) => [
    row.table,
    row.code,
    row.nature,
    row.placeOfSupply,
    row.taxableValue,
    row.igstAmount,
    row.cgstAmount,
    row.sgstAmount,
    row.cessAmount,
  ];

  it('presents every desktop GSTR-3B row in desktop order, with figures only where RP_GST computes them', () => {
    expect(grid.rows.map(cells)).toEqual([
      [
        '3.1',
        '(a)',
        'OutWord Taxable Supplies(Other then Zero rated)',
        '',
        '1000.01',
        '30.00',
        '15.13',
        '15.13',
        '',
      ],
      ['3.1', '(b)', 'OutWord Taxable Supplies (Zero rated) ', '', '', '', '', '', ''],
      ['3.1', '(c)', 'Other then OutWord Supplies(Nil rated,Exempted) ', '', '', '', '', '', ''],
      [
        '3.1',
        '(d)',
        'InWord Supplies(Lible to Reverse Charge)',
        '',
        '100.00',
        '3.00',
        '1.50',
        '1.50',
        '',
      ],
      ['3.1', '(e)', 'Non-Gst OutWord Supplies', '', '', '', '', '', ''],
      // The total adds the DISPLAYED cells (Conversion.Val of "1000.01" + "100.00"), RP_GST.cs:3555-3617.
      ['3.1', '', '', '', '1100.01', '33.00', '16.63', '16.63', ''],
      [
        '3.2',
        '',
        'Inter State Supplies made to Unregistered Persons Comp',
        'osition persons and UIN Holders    ',
        '',
        '',
        '',
        '',
        '',
      ],
      ['3.2', '', '', 'Place of Supplies (State/Ut)', 'Taxable Val', 'Igst Tax ', '', '', ''],
      [
        '3.2',
        '(1)',
        'Supplies Made ot Unregester Persons',
        '27 - Maharashtra',
        '250.00',
        '7.50',
        '',
        '',
        '',
      ],
      ['3.2', '', '', '33 - Tamil Nadu', '80.00', '2.40', '', '', ''],
      ['3.2', '(2)', 'Supplies Made ot Composition Taxable Persons', '', '', '', '', '', ''],
      ['3.2', '(3)', 'Supplies Made ot UIN Holders', '', '', '', '', '', ''],
      ['4', '4', 'Eligible ITC', '', '', '', '', '', ''],
      ['4', '(A)', 'ITC Available(Whether in full of part)', '', '', '', '', '', ''],
      ['4(A)', '(1)', 'Imprt of goods', '', '', '', '', '', ''],
      ['4(A)', '(2)', 'Imprt of Service', '', '', '', '', '', ''],
      ['4(A)', '(3)', 'Inword Supplies Liable to Reverse Charge', '', '', '', '', '', ''],
      ['4(A)', '(4)', 'Inword Supplies From ISD', '', '', '', '', '', ''],
      ['4(A)', '(5)', 'All Other ITC)', '', '400.00', '12.00', '6.00', '7.00', ''],
      ['4', '(B)', 'ITC Reversed', '', '', '', '', '', ''],
      ['4(B)', '(1)', 'As per rules 42 & 43 of CGST Rules', '', '', '', '', '', ''],
      ['4(B)', '(2)', 'Others', '', '', '', '', '', ''],
      ['4', '(C)', 'Net ITC Avaible (A)-(B)', '', '', '', '', '', ''],
      ['4', '(D)', 'Ineligible ITC', '', '', '', '', '', ''],
      ['4(D)', '(1)', 'As per Section 17(5)', '', '', '', '', '', ''],
      ['4(D)', '(2)', 'Other', '', '', '', '', '', ''],
      ['5', '5', 'Values of exempt,nil rated and non GST Inword supplies', '', '', '', '', '', ''],
      ['5', '', 'Supplier Under Composition and nil rated supplies', '', '', '', '', '', ''],
      ['5', '', 'Non GST Supplies', '', '', '', '', '', ''],
      ['6.1', '6.1', 'Payment of Tax', '', '', '', '', '', ''],
      [
        '6.1',
        'Discription',
        'Taxpayable',
        'Paid Igst',
        'Paid Cgst',
        'Paid Sgst',
        'Paid Cess',
        'TDS Paid',
        'Tax Paid In Cash',
      ],
      // Taxpayable = the 3.1 IGST total; Paid = the 4(A)(5) IGST/CGST/SGST cells.
      ['6.1', 'Integrated Tax', '33.00', '12.00', '6.00', '7.00', '', '', ''],
      ['6.1', 'Centrel Tax', '16.63', '', '', '', '', '', ''],
      // Owner decision WP-19 Q3: the SGST total (the desktop prints the CGST total here, RP_GST.cs:3800-3802).
      ['6.1', 'State/Ut Tax', '16.63', '', '', '', '', '', ''],
      ['6.1', 'Cess', '', '', '', '', '', '', ''],
      ['6.2', '6.2', 'TDS/TCS Credit', '', '', '', '', '', ''],
      ['6.2', 'TDS', '', '', '', '', '', '', ''],
      ['6.2', 'TCS', '', '', '', '', '', '', ''],
    ]);
    expect(grid.metadata.blockedRows).toBeUndefined();
  });

  it('prints State/Ut Tax from SGST, not CGST, when the two differ', () => {
    const out = presentGstr3b({
      outward: aggregate('100', '0', '1.25', '1.75'),
      reverseCharge: aggregate('0', '0', '0', '0', '0'),
      otherItc: aggregate('0', '0', '0', '0', '0'),
      unregisteredInterState: [],
    });
    const byCode = new Map(out.rows.map((row) => [row.code, row]));
    expect(byCode.get('Centrel Tax')!.nature).toBe('1.25');
    expect(byCode.get('State/Ut Tax')!.nature).toBe('1.75');
  });

  it('leaves an aggregate over no rows blank, as Format(NULL & "", "0.00") does, and counts it 0 in the totals', () => {
    const out = presentGstr3b({
      outward: aggregate('500', '0', '7.5', '7.5'),
      reverseCharge: aggregate('0', '0', '0', '0', '0'),
      otherItc: aggregate('0', '0', '0', '0', '0'),
      unregisteredInterState: [],
    });
    const d = out.rows.find((row) => row.code === '(d)')!;
    expect([d.taxableValue, d.igstAmount, d.cgstAmount, d.sgstAmount]).toEqual(['', '', '', '']);
    const total = out.rows[5]!;
    expect([total.taxableValue, total.cgstAmount]).toEqual(['500.00', '7.50']);
    const unregistered = out.rows.find((row) => row.code === '(1)' && row.table === '3.2')!;
    expect(unregistered.placeOfSupply).toBe('');
    const integrated = out.rows.find((row) => row.code === 'Integrated Tax')!;
    expect([integrated.placeOfSupply, integrated.taxableValue]).toEqual(['0.00', '0.00']);
  });
});

describe('RP_GST header-only sections (EXP, EXEMP, DOCS)', () => {
  it('shows the desktop title and captions and no rows, totals or No Record message', () => {
    expect(presentHeaderOnly('gstr1', 'EXP')).toMatchObject({
      section: 'EXP',
      title: 'Summary For Exp(6)',
      columns: [{ key: 'export', header: '' }],
      rows: [],
      totals: {},
      metadata: { headerOnly: true },
    });
    const exemp = presentHeaderOnly('gstr1', 'EXEMP');
    expect(exemp.title).toBe('Summary For Nill Rated,Exmp and Non Gst outword(8)');
    expect(exemp.columns.map((c) => c.header)).toEqual([
      'Descripition',
      'Nil Rated Supply',
      'Exmp and Non Gst Supply',
      'Non Gst Supply',
    ]);
    expect(Object.values(exemp.metadata.groupCaptions ?? {})).toEqual([
      'Total Nil Rated Supplies',
      'Total Exempted Supplies',
      'Total Non-Gst Supplies',
    ]);
    const docs = presentHeaderOnly('gstr1', 'DOCS');
    expect(docs.title).toBe('Summary of Doc. issued The Tax Period');
    expect(docs.columns.map((c) => c.header)).toEqual([
      'Nature Of Document',
      'Sr. No From',
      'Sr. No To',
      'Total Number',
      'Cancelled',
    ]);
    expect(docs.rows).toEqual([]);
  });

  it('parses EXP, EXEMP and DOCS as sections and refuses TCS, which is not an RP_GST section', () => {
    const scope = { tenantId: 't', coCode: '01', lcCode: '01', coYear: '2026-2027' };
    const base = { view: 'gstr1', fromDate: '2026-04-01', toDate: '2026-04-30' };
    for (const section of ['EXP', 'EXEMP', 'DOCS'])
      expect(parseGstReportQuery(scope, { ...base, section }).section).toBe(section);
    expect(() => parseGstReportQuery(scope, { ...base, section: 'TCS' })).toThrowError(
      expect.objectContaining({ code: 'invalid-section' }),
    );
  });

  it('writes no CSV for EXEMP or DOCS and refuses the unsettled EXP.csv', () => {
    expect(() => assertGstCsvSection(presentHeaderOnly('gstr1', 'EXEMP'))).toThrowError(
      expect.objectContaining({ code: 'csv-not-emitted', statusCode: 422 }),
    );
    expect(() => assertGstCsvSection(presentHeaderOnly('gstr1', 'DOCS'))).toThrowError(
      expect.objectContaining({ code: 'csv-not-emitted' }),
    );
    expect(() => assertGstCsvSection(presentHeaderOnly('gstr1', 'EXP'))).toThrowError(
      expect.objectContaining({ code: 'csv-not-settled' }),
    );
    expect(GST_WORKBOOK_SECTIONS).toEqual([
      'B2B',
      'B2CL',
      'B2CS',
      'CDNR',
      'CDNUR',
      'EXP',
      'AT',
      'ATADJ',
      'EXEMP',
      'HSN',
    ]);
  });
});

describe('RP_GST query contract', () => {
  const scope = {
    tenantId: 'gst-unit',
    coCode: '01',
    lcCode: '01',
    coYear: '2026-2027',
  };
  const valid = {
    view: 'gstr1',
    section: 'B2B',
    fromDate: '2026-04-01',
    toDate: '2027-03-31',
  };

  it('rejects unknown fields and overlong codes instead of dropping or truncating them', () => {
    expect(() => parseGstReportQuery(scope, { ...valid, surprise: 'x' })).toThrowError(
      expect.objectContaining({ code: 'invalid-query', details: { fields: ['surprise'] } }),
    );
    expect(() => parseGstReportQuery(scope, { ...valid, bookCode: 'LONG' })).toThrowError(
      expect.objectContaining({
        code: 'invalid-query',
        details: { field: 'bookCode', maxLength: 3 },
      }),
    );
    expect(() => parseGstReportQuery(scope, { ...valid, partyCode: '123456789' })).toThrowError(
      expect.objectContaining({
        code: 'invalid-query',
        details: { field: 'partyCode', maxLength: 8 },
      }),
    );
  });

  it('accepts the shared acCode party alias but refuses two different party identities', () => {
    expect(parseGstReportQuery(scope, { ...valid, acCode: 'CREG' }).partyCode).toBe('CREG');
    expect(() =>
      parseGstReportQuery(scope, { ...valid, acCode: 'CREG', partyCode: 'OTHER' }),
    ).toThrowError(expect.objectContaining({ code: 'invalid-query' }));
  });

  it('keeps both dates inside the selected April-March financial year', () => {
    expect(() => parseGstReportQuery(scope, { ...valid, fromDate: '2026-03-31' })).toThrowError(
      expect.objectContaining({ code: 'date-outside-year' }),
    );
    expect(() => parseGstReportQuery(scope, { ...valid, toDate: '2027-04-01' })).toThrowError(
      expect.objectContaining({ code: 'date-outside-year' }),
    );
  });
});

describe('RP_GST CSV bytes', () => {
  it('uses exact desktop header order and safe RFC-4180 escaping', () => {
    const section = presentTaxSection('gstr1', 'B2B', [
      tax({
        acName: 'Buyer, "North"\nUnit',
        gstin: '=24DANGER',
        invoiceValue: '1250.5',
        netAmount: '1200.5',
        discountAmount: '0.5',
      }),
    ]);
    expect(serializeGstCsv(section)).toBe(
      'GSTIN/UIN,Receiver Name,Invoice No,Invoice Date,Invoice Value,Plase Of Supply,R Charg,App% Rate,Invoice Type,E-Com GSTIN,Rate,Taxable Value,Cess Amt\r\n' +
        '"\'=24DANGER","Buyer, ""North""\nUnit",S-00001,05-Apr-24,1250.50,24 - Gujarat,N,,Regular,,3.00,1200,0\r\n',
    );
  });

  // RP_GST.SaveCSV (RP_GST.cs:3114-3145) writes the grid cells joined by commas, so a sale return reaches the
  // file as the plain number -206.00. A leading '-' only makes a formula out of text; a signed decimal the report
  // computed itself has to stay numeric for the GST portal and for sums.
  it('keeps negative amounts numeric while still neutralising text that begins with a formula sign', () => {
    const hsn = presentHsn([
      {
        hsn: '7113',
        rateType: 'G',
        itemType: 'G',
        gstType: 'I',
        quantity: '-1.25',
        itemAmount: '-200',
        itemTax: '-6',
        itemDiscount: '0',
      },
    ]);
    const [header, line] = serializeGstCsv(hsn).split('\r\n') as [string, string];
    const names = header.split(',');
    const cells = line.split(',');
    const at = (name: string) => cells[names.indexOf(name)];
    expect(at('Total Qty')).toBe('-1.25');
    expect(at('Total Value')).toBe('-206.00');
    expect(at('Taxable Value')).toBe('-200.00');
    expect(at('IGST Amount')).toBe('-6.00');

    const b2b = presentTaxSection('gstr1', 'B2B', [
      tax({ acName: '-Dash Traders', gstin: '=24DANGER', invoiceValue: '10' }),
    ]);
    const row = serializeGstCsv(b2b).split('\r\n')[1]!;
    expect(row).toContain('"\'=24DANGER"');
    expect(row).toContain('"\'-Dash Traders"');
  });

  it('does not let a look-alike number through the numeric exemption', () => {
    // Only a bare -digits[.digits] string is exempt. Each of these starts with '-' but can be a formula or is not
    // a number, so it must still be neutralised. (The report trims names first, so '-1\t' would reach the CSV as
    // the plain number '-1' and is not a hostile case.)
    for (const hostile of ['-1+1', '-1E5', '-1,5', '- 1', '-1.', '-.5', '--1', '-cmd|calc']) {
      const section = presentTaxSection('gstr1', 'B2B', [tax({ acName: hostile })]);
      const name = serializeGstCsv(section).split('\r\n')[1]!.split(',')[1]!;
      expect(name.startsWith('"\'-'), `${JSON.stringify(hostile)} -> ${name}`).toBe(true);
    }
  });
});
