import { describe, expect, it } from 'vitest';
import {
  EDITION_ORDER,
  FORM_EDITION,
  ROUTE_EDITION,
  formAvailability,
  isEditionCode,
  routeAvailability,
  routeTier,
  tierIncluded,
} from '../src/index.js';

/**
 * N171: editions are cumulative (MDI_FORM.cs:11249-11322 loads MENU_DATA rows with SM_TYPE in the running edition or
 * a lower one), and the web table gives every route and form the lowest edition that shows it.
 */
describe('tierIncluded', () => {
  it('a lower edition is included in every higher one; platform is always included', () => {
    expect(tierIncluded('L', 'S')).toBe(true);
    expect(tierIncluded('B', 'S')).toBe(true);
    expect(tierIncluded('S', 'S')).toBe(true);
    expect(tierIncluded('U', 'S')).toBe(false);
    expect(tierIncluded('P', 'S')).toBe(false);
    expect(tierIncluded('E', 'A')).toBe(false);
    expect(tierIncluded('E', 'E')).toBe(true);
    for (const running of EDITION_ORDER) expect(tierIncluded('platform', running)).toBe(true);
  });
  it('recognises exactly the seven desktop edition codes', () => {
    expect(EDITION_ORDER).toEqual(['L', 'B', 'S', 'U', 'P', 'A', 'E']);
    expect(['L', 'B', 'S', 'U', 'P', 'A', 'E'].every(isEditionCode)).toBe(true);
    expect([undefined, '', 's', 'X', 'Standard'].some(isEditionCode)).toBe(false);
  });
});

describe('Standard edition availability', () => {
  const standard = { code: 'S' as const, beta: false };
  const beta = { code: 'S' as const, beta: true };

  it('Standard menus are available: Sales, Purchase, receipts, Item master, Sales register, Users & Rights', () => {
    for (const form of [
      'Sales/Sales Invoice',
      'Purchase/Purchase Invoice',
      'Cash / Bank/Receipt',
      'Masters/Items',
      'Reports/Sales Register',
      'Utilities/Users & Rights',
    ])
      expect(formAvailability(form, standard), form).toBe('available');
    for (const route of ['/txn/sales', '/txn/receipt?mode=BANK', '/masters/items', '/dashboard'])
      expect(routeAvailability(route, standard), route).toBe('available');
  });

  it('Pro, Advance and Enterprise menus are refused, and only opened as Beta when Beta is on', () => {
    for (const form of ['Loans (Dhrn)/Pledge Issue', 'Transaction/Stock In', 'Masters/Diamonds']) {
      expect(formAvailability(form, standard), form).toBe('unavailable');
      expect(formAvailability(form, beta), form).toBe('beta');
    }
    for (const route of [
      '/txn/dhrn-issue',
      '/txn/tag-split',
      '/txn/stock-in',
      '/masters/locations',
    ]) {
      expect(routeAvailability(route, standard), route).toBe('unavailable');
      expect(routeAvailability(route, beta), route).toBe('beta');
    }
  });

  it('fails closed on a route or form the table does not know', () => {
    expect(routeTier('/txn/not-a-page')).toBeUndefined();
    expect(routeAvailability('/txn/not-a-page', beta)).toBe('unavailable');
    expect(formAvailability('Sales/Not A Form', beta)).toBe('unavailable');
  });

  it('a trailing slash or query string does not change a route', () => {
    expect(routeTier('/txn/sales/')).toBe(routeTier('/txn/sales'));
    expect(routeTier('/txn/payment?mode=BANK')).toBe(routeTier('/txn/payment'));
  });
});

describe('the generated table', () => {
  it('holds only known tiers and is frozen', () => {
    const tiers = new Set([...EDITION_ORDER, 'platform']);
    for (const value of [...Object.values(ROUTE_EDITION), ...Object.values(FORM_EDITION)])
      expect(tiers.has(value)).toBe(true);
    expect(Object.isFrozen(ROUTE_EDITION)).toBe(true);
    expect(Object.isFrozen(FORM_EDITION)).toBe(true);
  });
  it('gives no route the Ultra tier: no MENU_DATA row carries U, so Ultra shows the Standard menus', () => {
    expect(Object.values(ROUTE_EDITION).filter((tier) => tier === 'U')).toEqual([]);
  });
});
