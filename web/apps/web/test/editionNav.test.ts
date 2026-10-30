import { describe, expect, it } from 'vitest';
import { editionNav, navItemForm } from '../lib/editionNav';
import { NAV } from '../lib/nav';

/** N171: the Standard navigation shows only Lite, Basic and Standard menus; Beta collects the rest. */
describe('editionNav', () => {
  const hrefs = (groups: ReturnType<typeof editionNav>['groups']) =>
    groups.flatMap((group) => group.items.map((item) => item.href));
  const all = NAV.flatMap((group) => group.items.map((item) => item.href));

  it('without an edition the navigation is unchanged', () => {
    const result = editionNav(NAV, null);
    expect(result.groups).toBe(NAV);
    expect(result.beta).toEqual([]);
  });

  it('Standard keeps the Standard screens and drops Pro, Advance and Enterprise ones', () => {
    const { groups, beta } = editionNav(NAV, { code: 'S', beta: false });
    const shown = hrefs(groups);
    for (const href of [
      '/txn/sales',
      '/txn/purchase',
      '/txn/receipt',
      '/masters/items',
      '/reports/rojmel',
    ])
      expect(shown, href).toContain(href);
    for (const href of [
      '/txn/dhrn-issue',
      '/txn/scheme',
      '/txn/tag-split',
      '/txn/stock-in',
      '/txn/tour-sales',
      '/masters/design-book',
      '/masters/locations',
    ])
      expect(shown, href).not.toContain(href);
    expect(beta).toEqual([]);
    expect(shown.length).toBeLessThan(all.length);
  });

  it('with Beta on, every dropped screen is listed once in the Beta group with its own group kept', () => {
    const standard = hrefs(editionNav(NAV, { code: 'S', beta: false }).groups);
    const { groups, beta } = editionNav(NAV, { code: 'S', beta: true });
    expect(hrefs(groups)).toEqual(standard);
    expect([...standard, ...beta.map((item) => item.href)].sort()).toEqual([...all].sort());
    const pledge = beta.find((item) => item.href === '/txn/dhrn-issue');
    expect(pledge?.group).toBe('Loans (Dhrn)');
    expect(navItemForm(pledge!.group, pledge!)).toBe('Loans (Dhrn)/Pledge Issue');
  });

  it('Enterprise shows every screen', () => {
    expect(hrefs(editionNav(NAV, { code: 'E', beta: false }).groups).sort()).toEqual(
      [...all].sort(),
    );
  });

  it('drops groups left empty, such as Loans (Dhrn) and Membership in Standard', () => {
    const labels = editionNav(NAV, { code: 'S', beta: false }).groups.map((group) => group.label);
    expect(labels).not.toContain('Loans (Dhrn)');
    expect(labels).not.toContain('Membership');
    expect(labels).toContain('Sales');
  });
});
