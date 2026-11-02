import { readFileSync } from 'node:fs';
import { resolve } from 'node:path';
import { describe, expect, it } from 'vitest';

const source = (path: string) => readFileSync(resolve(process.cwd(), path), 'utf8');
const page = source('apps/web/app/(app)/utilities/data-refresh/page.tsx');
const operations = source('apps/api/src/modules/utilities/dataRefreshOps.ts');

describe('Data Refresh operator surface', () => {
  it('pins the six desktop captions in operator order', () => {
    const captions = [
      "'data-refresh-account': 'Account'",
      "'data-refresh-stock': 'Stock'",
      "'data-refresh-field-update': 'Field Update'",
      "'approval-reconcile': 'Approval Adj'",
      "'data-refresh-image-data': 'Image Data'",
      "'data-refresh-old-field': 'Old Field'",
    ];
    let cursor = -1;
    for (const caption of captions) {
      const next = page.indexOf(caption);
      expect(next, caption).toBeGreaterThan(cursor);
      cursor = next;
    }
  });

  it('does not expose Ctrl+O, manufacturing, scheme, or vendor repair controls', () => {
    for (const forbidden of [
      'Ctrl+O',
      'Mfg Refresh',
      'Scheme Data',
      'Crm Data',
      'Problem Qry',
      'TagDiff Set',
      'All Tag Stock Delete',
      'SrNo Mast Update',
      'Bar Idtl SrNo Update',
      'Sl Wt Diff Set',
      'OpBal Update',
      'A Stock Set',
    ]) {
      expect(page).not.toContain(forbidden);
    }
  });

  it('pins preview-only classifications and the exact Approval completion message', () => {
    for (const id of [
      'data-refresh-account',
      'data-refresh-stock',
      'data-refresh-field-update',
      'data-refresh-image-data',
      'data-refresh-old-field',
    ]) {
      const start = operations.indexOf(`id: '${id}'`);
      expect(start, id).toBeGreaterThan(-1);
      expect(operations.slice(start, start + 900), id).toContain('applyAvailable: false');
    }
    expect(operations).toContain("completionText: 'Approval Refersh Process Complete.'");
    expect(page).toContain('Preview only: {preview.blockedReason}');
  });

  it('uses native buttons and an accessible progress/status surface', () => {
    expect(page).toContain('type="button"');
    expect(page).toContain('aria-label="Data refresh operations"');
    expect(page).toContain('aria-label="Data Refresh progress"');
    expect(page).toContain("role={message.kind === 'err' ? 'alert' : 'status'}");
  });
});
