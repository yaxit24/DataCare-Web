import { readFileSync } from 'node:fs';
import { resolve } from 'node:path';
import { describe, expect, it } from 'vitest';

const source = (path: string) => readFileSync(resolve(process.cwd(), path), 'utf8');
const page = source('app/(app)/utilities/data-refresh/page.tsx');
const compatibilityPage = source('app/(app)/utilities/data-repair/page.tsx');
const operations = source('../api/src/modules/utilities/dataRefreshOps.ts');

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

  it('gates every authority input and Apply control for preview-only results', () => {
    for (const input of [
      'id="reason"',
      'id="confirmation"',
      'id="operatorPassword"',
      'id="backupReference"',
    ]) {
      expect(page).not.toContain(input);
    }
    const authorityGate = compatibilityPage.indexOf('{preview.applyAvailable && (');
    const reasonInput = compatibilityPage.indexOf('id="reason"');
    const previewOnlyStatus = compatibilityPage.indexOf('{!preview.applyAvailable && (');
    expect(authorityGate).toBeGreaterThan(-1);
    expect(reasonInput).toBeGreaterThan(authorityGate);
    expect(reasonInput).toBeLessThan(previewOnlyStatus);
    expect(compatibilityPage).toContain('{preview.applyAvailable && !preview.clean && (');
  });

  it('moves focus through preview and completion without changing native tab order', () => {
    expect(page).toContain('ref={previewHeadingRef}');
    expect(page).toContain('tabIndex={-1}');
    expect(page).toContain('aria-live="polite"');
    expect(page).toContain('if (busy === null && preview) previewHeadingRef.current?.focus()');
    expect(page).toContain('operationRefs.current[operationId]?.focus()');
    expect(page).not.toContain('tabIndex={0}');
  });

  it('uses native buttons and an accessible progress/status surface', () => {
    expect(page).toContain('type="button"');
    expect(page).toContain('aria-label="Data refresh operations"');
    expect(page).toContain('aria-label="Data Refresh progress"');
    expect(page).toContain("role={message.kind === 'err' ? 'alert' : 'status'}");
  });
});
