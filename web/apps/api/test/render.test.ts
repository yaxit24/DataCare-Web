import { describe, it, expect } from 'vitest';
import {
  escapeHtml,
  renderRegisterHtml,
  renderInvoiceHtml,
  FakePdfRenderer,
  renderToPdf,
} from '../src/modules/reports/render.js';
import { shapeRegister, type RegisterRow } from '../src/modules/reports/reports.js';

const row = (o: Partial<RegisterRow>): RegisterRow => ({
  vchNo: '1',
  vchDate: null,
  billNo: 'B1',
  acCode: 'C',
  party: 'Acme',
  netAmt: 0,
  taxAmt: 0,
  cgst: 0,
  sgst: 0,
  igst: 0,
  totAmt: 0,
  osAmt: 0,
  ...o,
});

describe('report rendering', () => {
  it('escapeHtml neutralizes markup', () => {
    expect(escapeHtml('<script>&"\'')).toBe('&lt;script&gt;&amp;&quot;&#39;');
  });
  it('register HTML has rows + totals footer', () => {
    const reg = shapeRegister([
      row({ netAmt: 1000, taxAmt: 30, cgst: 15, sgst: 15, totAmt: 1030 }),
    ]);
    const html = renderRegisterHtml('Sales Register', reg);
    expect(html).toContain('Sales Register');
    expect(html).toContain('Acme');
    expect(html).toContain('1,030.00'); // total formatted
    expect(html).toContain('Total (1 rows)');
  });
  it('register HTML empty-state', () => {
    expect(renderRegisterHtml('Sales Register', shapeRegister([]))).toContain('No records');
  });
  it('invoice HTML includes IRN when present', () => {
    const html = renderInvoiceHtml({
      sellerName: 'Jewel Co',
      buyerName: 'Buyer',
      billNo: 'INV/1',
      vchDate: '2024-04-01',
      items: [{ desc: 'Gold Ring', qty: 1, rate: 1000, amount: 1000 }],
      netAmt: 1000,
      taxAmt: 30,
      totAmt: 1030,
      irn: 'ABC123',
    });
    expect(html).toContain('Tax Invoice INV/1');
    expect(html).toContain('Gold Ring');
    expect(html).toContain('IRN: ABC123');
  });
  it('fake renderer emits valid PDF bytes', async () => {
    const pdf = await renderToPdf('<html></html>', new FakePdfRenderer());
    expect(pdf.subarray(0, 5).toString()).toBe('%PDF-');
    expect(pdf.toString().trimEnd().endsWith('%%EOF')).toBe(true);
  });
});
