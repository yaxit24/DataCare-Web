import { describe, expect, it } from 'vitest';
import {
  classifyB2c,
  presentGstr3b,
  presentHsn,
  presentTaxSection,
} from '../src/modules/reports/gstReportSections.js';
import { parseGstReportQuery } from '../src/modules/reports/gstReport.js';
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

  it('presents only the settled GSTR-3B outward, reverse-charge and other-ITC rows', () => {
    const out = presentGstr3b({
      outward: { taxable: '1000', igst: '30', cgst: '15', sgst: '15' },
      reverseCharge: { taxable: '100', igst: '3', cgst: '1.5', sgst: '1.5' },
      otherItc: { taxable: '400', igst: '12', cgst: '6', sgst: '6' },
    });
    expect(out.rows.map((row) => [row.table, row.code, row.taxableValue])).toEqual([
      ['3.1', '(a)', '1000.00'],
      ['3.1', '(d)', '100.00'],
      ['4(A)', '(5)', '400.00'],
    ]);
    expect(out.metadata.blockedRows).toContain('3.1(b)');
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
