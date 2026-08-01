import { describe, it, expect } from 'vitest';
import {
  classifyInvoice,
  summarizeB2CS,
  summarizeHsn,
  buildGstr1,
  type InvoiceRow,
} from '../src/modules/gst/gst.js';

const inv = (o: Partial<InvoiceRow>): InvoiceRow => ({
  vchNo: '1',
  acCode: 'C',
  gstin: null,
  interState: false,
  invoiceValue: 0,
  taxable: 0,
  cgst: 0,
  sgst: 0,
  igst: 0,
  stateCode: '27',
  ratePct: 3,
  ...o,
});

describe('gst classification', () => {
  it('B2B when recipient has GSTIN', () => {
    expect(
      classifyInvoice(inv({ gstin: '27ABCDE1234F1Z5', interState: true, invoiceValue: 1e6 })),
    ).toBe('B2B');
  });
  it('B2CL when unregistered + inter-state + value > threshold', () => {
    expect(
      classifyInvoice(inv({ gstin: null, interState: true, invoiceValue: 300000 }), 250000),
    ).toBe('B2CL');
    expect(
      classifyInvoice(inv({ gstin: null, interState: true, invoiceValue: 100000 }), 250000),
    ).toBe('B2CS'); // below threshold
  });
  it('B2CS for intra-state B2C', () => {
    expect(classifyInvoice(inv({ gstin: null, interState: false, invoiceValue: 1e6 }))).toBe(
      'B2CS',
    );
  });
});

describe('gst aggregation', () => {
  it('B2CS summarized by state + rate', () => {
    const rows = summarizeB2CS([
      inv({ stateCode: '27', ratePct: 3, taxable: 1000, cgst: 15, sgst: 15 }),
      inv({ stateCode: '27', ratePct: 3, taxable: 500, cgst: 7.5, sgst: 7.5 }),
      inv({ stateCode: '24', ratePct: 3, taxable: 200, cgst: 3, sgst: 3 }),
    ]);
    expect(rows.length).toBe(2); // (27,3) merged + (24,3)
    const mh = rows.find((r) => r.stateCode === '27')!;
    expect(mh.taxable).toBe(1500);
    expect(mh.cgst).toBe(22.5);
  });
  it('HSN summary maps IT_CODE and sums', () => {
    const hsn = summarizeHsn(
      [
        { itCode: 'GOLD', qty: 1, taxable: 1000, cgst: 15, sgst: 15, igst: 0 },
        { itCode: 'GOLD', qty: 2, taxable: 2000, cgst: 30, sgst: 30, igst: 0 },
      ],
      { GOLD: '7113' },
    );
    expect(hsn.length).toBe(1);
    expect(hsn[0]!.hsn).toBe('7113');
    expect(hsn[0]!.qty).toBe(3);
    expect(hsn[0]!.taxable).toBe(3000);
  });
  it('buildGstr1 splits buckets', () => {
    const g = buildGstr1(
      [
        inv({ vchNo: '1', gstin: '27ABCDE1234F1Z5', taxable: 1000 }),
        inv({
          vchNo: '2',
          gstin: null,
          interState: true,
          invoiceValue: 300000,
          taxable: 300000,
          igst: 9000,
        }),
        inv({
          vchNo: '3',
          gstin: null,
          interState: false,
          invoiceValue: 500,
          taxable: 500,
          cgst: 7.5,
          sgst: 7.5,
        }),
      ],
      [],
      { threshold: 250000 },
    );
    expect(g.b2b.length).toBe(1);
    expect(g.b2cl.length).toBe(1);
    expect(g.b2cs.length).toBe(1);
  });
});
