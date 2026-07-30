import { describe, it, expect } from 'vitest';
import {
  buildIrnPayload,
  validateIrnPayload,
  fmtIrnDate,
  EInvoiceValidationError,
  FakeIrnTransport,
} from '../src/modules/einvoice/einvoice.js';

const seller = { gstin: '24AACCC1596Q002', lglNm: 'Jewel Co', stcd: '24' };
const buyer = { gstin: '27ALOPV4774H2ZF', lglNm: 'Buyer Co', stcd: '27' };
const sale = { billNo: 'DF/00005', vchDate: '2023-06-09', interState: true };
const items = [
  {
    desc: 'BANGLE 916',
    hsn: '711319',
    qty: 18.3,
    unitPrice: 1180,
    assAmt: 21594,
    gstRt: 3,
    igst: 647.82,
  },
];

describe('irn payload', () => {
  it('fmtIrnDate -> dd/MM/yyyy', () => {
    expect(fmtIrnDate('2023-06-09')).toBe('09/06/2023');
  });
  it('builds NIC v1.1 payload with computed totals', () => {
    const p = buildIrnPayload({ seller, buyer, sale, items });
    expect(p.Version).toBe('1.1');
    expect(p.TranDtls.SupTyp).toBe('B2B');
    expect(p.DocDtls.No).toBe('DF/00005');
    expect(p.DocDtls.Dt).toBe('09/06/2023');
    expect(p.ItemList[0].HsnCd).toBe('711319');
    expect(p.ItemList[0].TotItemVal).toBe(22241.82); // 21594 + 647.82
    expect(p.ValDtls.AssVal).toBe(21594);
    expect(p.ValDtls.IgstVal).toBe(647.82);
    expect(p.ValDtls.TotInvVal).toBe(22241.82);
    expect(validateIrnPayload(p)).toEqual([]);
  });
  it('requires recipient GSTIN (B2B only)', () => {
    expect(() => buildIrnPayload({ seller, buyer: { ...buyer, gstin: '' }, sale, items })).toThrow(
      EInvoiceValidationError,
    );
  });
  it('requires at least one item', () => {
    expect(() => buildIrnPayload({ seller, buyer, sale, items: [] })).toThrow(
      EInvoiceValidationError,
    );
  });
  it('fake transport returns a 64-char IRN deterministically', async () => {
    const p = buildIrnPayload({ seller, buyer, sale, items });
    const t = new FakeIrnTransport();
    const a = await t.generateIRN(p);
    const b = await t.generateIRN(p);
    expect(a.Irn.length).toBe(64);
    expect(a.Irn).toBe(b.Irn); // deterministic for same invoice
    expect(a.Status).toBe('ACT');
  });
});
