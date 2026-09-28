import { describe, expect, it } from 'vitest';
import { readFileSync } from 'node:fs';
import { dirname, join } from 'node:path';
import { fileURLToPath } from 'node:url';

const here = dirname(fileURLToPath(import.meta.url));
const page = readFileSync(
  join(here, '..', 'app', '(app)', 'utilities', 'e-invoice', 'page.tsx'),
  'utf8',
);
const nav = readFileSync(join(here, '..', 'lib', 'nav.ts'), 'utf8');

describe('E-Excel e-invoice surface', () => {
  it('keeps the desktop date-window fields and exports the visible invoice range', () => {
    expect(page).toContain('type="date"');
    expect(page).toContain('fromDate');
    expect(page).toContain('toDate');
    expect(page).toContain('/api/einvoice/export.xlsx');
    expect(page).toContain('E-Excel');
    expect(page).toContain('/reports/sales-register?');
  });

  it('keeps the e-invoice utility discoverable from navigation', () => {
    expect(nav).toContain('e-Invoice (IRN)');
    expect(nav).toContain('/utilities/e-invoice');
  });
});
