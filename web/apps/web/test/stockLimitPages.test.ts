import { readFileSync } from 'node:fs';
import { join } from 'node:path';
import { describe, expect, it } from 'vitest';

const read = (path: string) => readFileSync(join(__dirname, '..', path), 'utf8');

describe('MS_STK_LIMIT web pages', () => {
  it('exposes Dm Size and ItStk Limit through navigation and desktop columns', () => {
    const nav = read('lib/nav.ts');
    expect(nav).toContain("label: 'Dm Size'");
    expect(nav).toContain("href: '/masters/diamond-sizes'");
    expect(nav).toContain("label: 'ItStk Limit'");
    expect(nav).toContain("href: '/masters/item-stock-limits'");

    const dmPage = read('app/(app)/masters/diamond-sizes/page.tsx');
    for (const label of ['Dm Size', 'Dm Wt', 'PcsGht', 'PcsLbr', 'Rate Type', 'Dm Rate']) {
      expect(dmPage).toContain(label);
    }
    expect(dmPage).toContain('/masters/diamond-sizes');

    const limitPage = read('app/(app)/masters/item-stock-limits/page.tsx');
    for (const label of [
      'From Wt',
      'To Wt',
      'Min Pcs',
      'Lbr Code',
      'Ght %',
      'Lbr %',
      'MinLbr %',
      'Lbr Type',
      'Lbr Rate',
      'Lbr Amt',
    ]) {
      expect(limitPage).toContain(label);
    }
    expect(limitPage).toContain('/masters/item-stock-limits');
  });
});
