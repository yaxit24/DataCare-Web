import { describe, expect, it } from 'vitest';
import { readFileSync } from 'node:fs';
import { join } from 'node:path';

const read = (path: string) => readFileSync(join(__dirname, '..', path), 'utf8');

describe('cheque print page wiring', () => {
  it('exposes payee and A/c Payee inputs and calls the existing cheque endpoint', () => {
    const page = read('app/(app)/txn/cheque-print/page.tsx');
    expect(page).toContain('Cheque Print');
    expect(page).toContain('Payee / Chq Ac Name');
    expect(page).toContain('A/c Payee Only');
    expect(page).toContain("q.set('payee', payee.trim())");
    expect(page).toContain("q.set('acPayee', 'true')");
    expect(page).toContain("q.set('chqNo', chqNo.trim())");
    expect(page).toContain('/api/finance/cheque-print?');
    expect(page).toContain('window.location.search');
    expect(page).toContain('autoPrint=true');
    expect(page).toContain('<iframe');
  });

  it('is discoverable under Cash / Bank while retaining Payment print rights', () => {
    const nav = read('lib/nav.ts');
    const shell = read('components/Shell.tsx');
    const payment = read('components/PaymentForm.tsx');
    expect(nav).toContain("label: 'Cheque Print'");
    expect(nav).toContain("href: '/txn/cheque-print'");
    expect(nav).toContain("form: 'Cash / Bank/Payment'");
    expect(shell).toContain('allowed.includes(it.form ?? `${g.label}/${it.label}`)');
    expect(payment).toContain('Chq Ac Name');
    expect(payment).toContain('/txn/cheque-print?payee=');
  });
});
