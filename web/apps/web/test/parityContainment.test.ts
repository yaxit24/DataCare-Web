import { readFileSync } from 'node:fs';
import { resolve } from 'node:path';
import { createElement } from 'react';
import { renderToStaticMarkup } from 'react-dom/server';
import { describe, expect, it } from 'vitest';
import {
  ParityContainmentFieldset,
  ParityContainmentNotice,
} from '../components/ParityContainmentNotice';

const source = (path: string) => readFileSync(resolve(process.cwd(), path), 'utf8');

describe('WP-01 operator containment', () => {
  it('renders an accessible notice with reason, safe alternative, and exit gate', () => {
    const html = renderToStaticMarkup(
      createElement(ParityContainmentNotice, { operation: 'tag-split' }),
    );
    expect(html).toContain('role="alert"');
    expect(html).toContain('data-operation="tag-split"');
    expect(html).toContain('WP-01 parity safety gate');
    expect(html).toContain('Safe alternative:');
    expect(html).toContain('Exit gate:');
  });

  it('renders descendant controls inside a disabled fieldset only while containment is active', () => {
    const child = createElement('button', { type: 'button' }, 'Mutate');
    const active = renderToStaticMarkup(
      createElement(
        ParityContainmentFieldset,
        { operation: 'tag-split', active: true, 'aria-label': 'Opening tag details' },
        child,
      ),
    );
    const inactive = renderToStaticMarkup(
      createElement(ParityContainmentFieldset, { operation: 'tag-split', active: false }, child),
    );
    expect(active).toMatch(/<fieldset[^>]*disabled=""[^>]*>/);
    expect(active).toContain('<button type="button">Mutate</button>');
    expect(inactive).not.toContain('disabled=""');
  });

  it('wires every partial tag page to both a guarded handler and a disabled submit path', () => {
    const cases = [
      ['app/(app)/txn/tag-transfer/page.tsx', 'tag-transfer'],
      ['app/(app)/txn/tag-cancel/page.tsx', 'tag-cancel'],
      ['app/(app)/txn/tag-weight-diff/page.tsx', 'tag-weight-difference'],
      ['app/(app)/txn/tag-split/page.tsx', 'tag-split'],
    ] as const;

    for (const [path, operation] of cases) {
      const text = source(path);
      expect(text, path).toContain(`operation="${operation}"`);
      expect(text, path).toContain(`parityContainmentMessage('${operation}')`);
      expect(text, path).toContain('containment.blocked');
    }
  });

  it('lets a loaded Tag Opening be edited now that its containment is discharged', () => {
    // This test previously asserted the OPPOSITE — that a loaded voucher stayed read-only — because
    // `tag-opening-update` was blocked in the fail-closed registry. The rule is now retired: the
    // P0-06/WP-08 exit gate is satisfied by tagOpeningRoundTrip.db.test.ts, which proves the entire
    // BAR_DETL row, the BAR_IDTL sub-detail, tag identity and the MAIN_STOCK movement all survive an
    // unchanged reopen-and-save, plus the page's HUID text fix.
    //
    // Inverting the assertion rather than deleting it keeps the guarantee: if anything re-introduces a
    // containment block or a disabled save on this page, this fails.
    const text = source('app/(app)/txn/tag-opening/page.tsx');
    expect(text).not.toContain("parityContainmentRule('tag-opening-update')");
    expect(text).not.toContain('updateContainment.blocked');
    expect(text).not.toContain('disabled={updateContained}');
    expect(text).not.toContain('operation="tag-opening-update"');
    // The save button must be gated only by in-flight state.
    expect(text).toContain('disabled={busy}');
    // Inspection controls and the image panel stay exactly as they were.
    expect(text).toContain('<EntityImagePanel');
    expect(text).toContain('instance={lines[imageRow]?.vchSrno ?? imageRow + 1}');
    expect(text).toContain('onClick={loadVoucher}');
    expect(text).toContain('onClick={newVoucher}');
    // HUIDs must stay text; a Number() coercion here silently dropped every id containing a letter.
    expect(text).toContain('hallmarkId2: line.hallmarkId2?.trim() || undefined');
  });

  it('labels logical JSON backup as non-DR and restore as contained', () => {
    const text = source('app/(app)/backup/page.tsx');
    expect(text).toContain('operation="logical-restore"');
    expect(text).toContain('not a production disaster-recovery backup');
    expect(text).toContain('Download Company Backup (JSON)');
  });
});
