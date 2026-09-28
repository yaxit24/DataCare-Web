import { describe, expect, it } from 'vitest';
import { amountInWords, renderCheque } from '../src/modules/finance/chequePrint.js';
import { routePolicyFor } from '../src/modules/rbac/routePolicy.js';

describe('cheque print rendering', () => {
  it('prints the payee, cheque number, amount words and A/c Payee crossing', () => {
    const html = renderCheque({
      payee: 'M/S Hiral Jewellers & Sons',
      amount: 123456.78,
      date: '2026-09-10',
      chqNo: 'CQ-102',
      acPayee: true,
    });
    expect(html).toContain('M/S Hiral Jewellers &amp; Sons');
    expect(html).toContain('A/c Payee Only');
    expect(html).toContain('Chq: CQ-102');
    expect(html).toContain('One Lakh Twenty Three Thousand Four Hundred Fifty Six Rupees and Seventy Eight Paise Only');
    expect(html).toContain('10092026');
  });

  it('keeps cheque printing under Payment print rights', () => {
    expect(routePolicyFor('GET', '/finance/cheque-print')).toMatchObject({
      form: 'Cash / Bank/Payment',
      action: 'print',
    });
  });

  it('uses Indian amount words at crore/lakh boundaries', () => {
    expect(amountInWords(10000000)).toBe('One Crore Rupees Only');
    expect(amountInWords(100000.5)).toBe('One Lakh Rupees and Fifty Paise Only');
  });
});
