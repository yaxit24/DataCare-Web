import { describe, expect, it } from 'vitest';
import { readdirSync, readFileSync, statSync } from 'node:fs';
import { join } from 'node:path';

/**
 * Alphanumeric identifiers must never be sent through `Number()`.
 *
 * THE DEFECT THIS LOCKS OUT
 * `tag-opening/page.tsx` sent `hallmarkId2: Number(line.hallmarkId2 || 0) || undefined`. A HUID is
 * ALPHANUMERIC — the API types these fields as `string` and the writer stores
 * `text(...).slice(0, 10)` (stockVoucherLifecycle.ts:61-63, :647). So `Number('AZ4567F')` is NaN,
 * `|| undefined` then drops it, and the id was silently lost on every save. This is named in the
 * `tag-opening-update` containment rule as one reason the operation is disabled.
 *
 * The weight companions (`hallmarkIdWt`, `hallmarkId2Wt`, ...) ARE numeric, so this only forbids
 * coercing the ID fields. Being narrow matters: a rule that also flagged the weights would be wrong
 * and would train people to ignore it.
 */
const TXN = join(__dirname, '..', 'app', '(app)', 'txn');

const pages = (): Array<{ slug: string; src: string }> =>
  readdirSync(TXN)
    .filter((d) => statSync(join(TXN, d)).isDirectory())
    .map((slug) => {
      try {
        return { slug, src: readFileSync(join(TXN, slug, 'page.tsx'), 'utf8') };
      } catch {
        return { slug, src: '' };
      }
    })
    .filter((p) => p.src !== '');

/** Fields the API declares as strings even though their names look numeric. */
const TEXT_IDENTIFIERS = [
  'hallmarkId',
  'hallmarkId2',
  'hallmarkId3',
  'hallmarkId4',
  'huid',
  'designNo',
  'tagNo',
  'lotNo',
  'itmSize',
];

describe('alphanumeric identifiers are never coerced to numbers', () => {
  it('finds pages to check', () => {
    expect(pages().length).toBeGreaterThan(40);
  });

  for (const field of TEXT_IDENTIFIERS) {
    it(`never wraps ${field} in Number()`, () => {
      // Matches `field: Number(...)`, allowing for the `x.field` form the payload builders use.
      const pattern = new RegExp(`\\b${field}:\\s*Number\\(`);
      const offenders = pages()
        .filter(({ src }) => pattern.test(src))
        .map((p) => p.slug);
      expect(offenders).toEqual([]);
    });
  }
});
