import { describe, expect, it } from 'vitest';
import { NAV } from '../lib/nav';
import { reportApiSlug } from '../lib/reportSlug';

describe('report API slug (D2)', () => {
  it('keeps the digits in real report slugs', () => {
    expect(reportApiSlug('gstr2')).toBe('gstr2');
    expect(reportApiSlug('gstr3b')).toBe('gstr3b');
  });

  it('still keeps path syntax out of the API request', () => {
    expect(reportApiSlug('../admin')).toBe('admin');
    expect(reportApiSlug('sales-register/../tag-estimate')).toBe('sales-registertag-estimate');
    expect(reportApiSlug('a?b=c')).toBe('abc');
  });

  it('passes every report slug the navigation links to unchanged, so no screen can lose its route', () => {
    const slugs = NAV.flatMap((group) => group.items)
      .map((item) => /^\/reports\/([^/?#]+)$/.exec(item.href)?.[1])
      .filter((slug): slug is string => Boolean(slug));
    expect(slugs).toEqual(expect.arrayContaining(['gstr2', 'gstr3b', 'huid', 'bill-profit']));
    for (const slug of slugs) expect(reportApiSlug(slug), slug).toBe(slug);
  });
});
