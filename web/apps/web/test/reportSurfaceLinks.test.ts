import { describe, expect, it } from 'vitest';
import { readFileSync } from 'node:fs';
import { join } from 'node:path';

const nav = readFileSync(join(__dirname, '..', 'lib', 'nav.ts'), 'utf8');
const page = readFileSync(
  join(__dirname, '..', 'app', '(app)', 'reports', '[report]', 'page.tsx'),
  'utf8',
);

describe('report surface links', () => {
  it('exposes registered desktop report builders through navigation and report titles', () => {
    for (const [label, slug] of [
      ['Item Stock Level', 'item-weight-levels'],
      ['Stock Movement', 'size-movement'],
      ['Branch InOut', 'branch-inout'],
      ['Other Item Report', 'other-item-report'],
      ['Design Move', 'design-move'],
      ['Consi Report', 'consi-report'],
      ['Old Stock', 'old-stock'],
      ['Trading Report', 'trading-report'],
      ['Tour Report', 'tour-report'],
      ['Tour Tag', 'tour-tag'],
      ['Order Track', 'order-track'],
      ['Graph Report', 'graph-report'],
      ['Mfg InOut', 'mfg-inout'],
      ['Mfg Lot IsuRec', 'mfg-lot-isurec'],
      ['Mfg Ledger', 'mfg-ledger'],
      ['Physical Stock Verify', 'physical-stock-verify'],
      ['Bill Wise Profit', 'bill-profit'],
      ['HUID Report', 'huid'],
      ['Last Visit', 'last-visit'],
      ['Address Print', 'address-print'],
      ['Entry Check', 'entry-check'],
      ['User Report', 'user-report'],
      ['Dhiran Report', 'dhiran-report'],
      ['Loan Report', 'loan-report'],
      ['Scheme Monthly Report', 'scheme-monthly'],
      ['GST Report', 'gst-report'],
      ['Delete Data', 'delete-data'],
      ['Point Report', 'point-report'],
      ['Approval Report', 'approval-report'],
      ['VP Report', 'vp-report'],
      ['Bullion Report', 'bullion-report'],
      ['Karigar Report', 'karigar-report'],
      ['Repair Report', 'repair-report'],
    ] as const) {
      expect(nav).toContain(`label: '${label}'`);
      expect(nav).toContain(`href: '/reports/${slug}'`);
      expect(page).toMatch(new RegExp(`['\"]?${slug}['\"]?:`));
    }
  });
});
