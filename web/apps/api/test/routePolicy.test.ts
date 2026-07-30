import { readFileSync } from 'node:fs';
import { fileURLToPath } from 'node:url';
import { dirname, resolve } from 'node:path';
import { describe, expect, it } from 'vitest';
import { getFormEntry } from '../src/modules/rbac/formCatalog.js';
import { MASTERS } from '../src/modules/masters/configs.js';
import {
  MASTER_FORM_BY_NAME,
  routePolicyFor,
  type RoutePolicy,
} from '../src/modules/rbac/routePolicy.js';

const here = dirname(fileURLToPath(import.meta.url));
const routePattern = /\b(?:app|server)\.(get|post|put|patch|delete)\(\s*(['"`])([^'"`]+)\2/g;

function declaredRoutes(): Array<{ method: string; path: string }> {
  const rows: Array<{ method: string; path: string }> = [];
  for (const file of [resolve(here, '../src/app.ts'), resolve(here, '../src/routes/txn.ts')]) {
    const source = readFileSync(file, 'utf8');
    for (const match of source.matchAll(routePattern)) {
      rows.push({ method: match[1]!.toUpperCase(), path: match[3]! });
    }
  }
  return rows;
}

describe('route policy registry', () => {
  it('classifies every declared endpoint and preserves the current exact route universe', () => {
    const routes = declaredRoutes();
    expect(routes).toHaveLength(382);
    expect(new Set(routes.map((route) => `${route.method} ${route.path}`)).size).toBe(382);

    const policies = routes.map((route) => ({
      ...route,
      policy: routePolicyFor(route.method, route.path),
    }));
    expect(policies.filter((row) => !row.policy)).toEqual([]);

    for (const { policy } of policies as Array<{
      method: string;
      path: string;
      policy: RoutePolicy;
    }>) {
      if (policy.kind !== 'form' || policy.form === '@master') continue;
      expect(getFormEntry(policy.form!)).toBeDefined();
      expect(policy.action).toMatch(/^(read|create|update|delete|print)$/);
    }
  });

  it('maps every dynamic master name to a canonical form', () => {
    expect(Object.keys(MASTER_FORM_BY_NAME).sort()).toEqual(Object.keys(MASTERS).sort());
    expect(Object.keys(MASTER_FORM_BY_NAME)).toHaveLength(34);
    for (const form of Object.values(MASTER_FORM_BY_NAME)) {
      expect(getFormEntry(form)).toBeDefined();
    }
  });

  it('maps KRREP ISSUE endpoints to the canonical repair form and independent actions', () => {
    expect(routePolicyFor('POST', '/repair-karigar-issues')).toMatchObject({
      form: 'Manufacturing/Repair Receipt',
      action: 'create',
    });
    expect(routePolicyFor('GET', '/repair-karigar-issues/open-lines')).toMatchObject({
      form: 'Manufacturing/Repair Receipt',
      action: 'read',
    });
    expect(routePolicyFor('GET', '/repair-karigar-issues/:vchNo/print')).toMatchObject({
      form: 'Manufacturing/Repair Receipt',
      action: 'print',
    });
    expect(routePolicyFor('PUT', '/repair-karigar-issues/:vchNo')).toMatchObject({
      form: 'Manufacturing/Repair Receipt',
      action: 'update',
    });
    expect(routePolicyFor('DELETE', '/repair-karigar-issues/:vchNo')).toMatchObject({
      form: 'Manufacturing/Repair Receipt',
      action: 'delete',
    });
  });

  it('maps KRREP RECEIPT endpoints to the canonical repair form and independent actions', () => {
    expect(routePolicyFor('POST', '/repair-karigar-receipts')).toMatchObject({
      form: 'Manufacturing/Repair Receipt',
      action: 'create',
    });
    expect(routePolicyFor('GET', '/repair-karigar-receipts')).toMatchObject({
      form: 'Manufacturing/Repair Receipt',
      action: 'read',
    });
    expect(routePolicyFor('GET', '/repair-karigar-receipts/open-lines')).toMatchObject({
      form: 'Manufacturing/Repair Receipt',
      action: 'read',
    });
    expect(routePolicyFor('GET', '/repair-karigar-receipts/:vchNo')).toMatchObject({
      form: 'Manufacturing/Repair Receipt',
      action: 'read',
    });
    expect(routePolicyFor('GET', '/repair-karigar-receipts/:vchNo/print')).toMatchObject({
      form: 'Manufacturing/Repair Receipt',
      action: 'print',
    });
    expect(routePolicyFor('PUT', '/repair-karigar-receipts/:vchNo')).toMatchObject({
      form: 'Manufacturing/Repair Receipt',
      action: 'update',
    });
    expect(routePolicyFor('DELETE', '/repair-karigar-receipts/:vchNo')).toMatchObject({
      form: 'Manufacturing/Repair Receipt',
      action: 'delete',
    });
  });

  it('maps CUSTREP ISSUE endpoints to the canonical repair form and independent actions', () => {
    expect(routePolicyFor('POST', '/repair-customer-issues')).toMatchObject({
      form: 'Manufacturing/Repair Receipt',
      action: 'create',
    });
    expect(routePolicyFor('GET', '/repair-customer-issues/open-lines')).toMatchObject({
      form: 'Manufacturing/Repair Receipt',
      action: 'read',
    });
    expect(routePolicyFor('GET', '/repair-customer-issues/:vchNo/print')).toMatchObject({
      form: 'Manufacturing/Repair Receipt',
      action: 'print',
    });
    expect(routePolicyFor('PUT', '/repair-customer-issues/:vchNo')).toMatchObject({
      form: 'Manufacturing/Repair Receipt',
      action: 'update',
    });
    expect(routePolicyFor('DELETE', '/repair-customer-issues/:vchNo')).toMatchObject({
      form: 'Manufacturing/Repair Receipt',
      action: 'delete',
    });
  });

  it('treats repair image attachments as read/update/delete on the repair form', () => {
    expect(routePolicyFor('GET', '/repair-images')).toMatchObject({
      form: 'Manufacturing/Repair Receipt',
      action: 'read',
    });
    expect(routePolicyFor('GET', '/repair-images/line')).toMatchObject({
      form: 'Manufacturing/Repair Receipt',
      action: 'read',
    });
    expect(routePolicyFor('POST', '/repair-images')).toMatchObject({
      form: 'Manufacturing/Repair Receipt',
      action: 'update',
    });
    expect(routePolicyFor('DELETE', '/repair-images')).toMatchObject({
      form: 'Manufacturing/Repair Receipt',
      action: 'delete',
    });
  });

  it('maps the configured TR_MLT_PRO lifecycle to independent melting rights', () => {
    expect(routePolicyFor('POST', '/melting')).toMatchObject({
      form: 'Manufacturing/Melting',
      action: 'create',
    });
    expect(routePolicyFor('GET', '/melting/:vchNo')).toMatchObject({
      form: 'Manufacturing/Melting',
      action: 'read',
    });
    expect(routePolicyFor('PUT', '/melting/:vchNo')).toMatchObject({
      form: 'Manufacturing/Melting',
      action: 'update',
    });
    expect(routePolicyFor('DELETE', '/melting/:vchNo')).toMatchObject({
      form: 'Manufacturing/Melting',
      action: 'delete',
    });
  });

  it('maps digital-gold and location-amount lifecycles to independent rights', () => {
    const workflows = [
      ['/finance/gold-book', 'Cash / Bank/Digital Gold Book'],
      ['/finance/vp-adjustment', 'Cash / Bank/VP Adjustment'],
      ['/finance/location-amount', 'Cash / Bank/Location Amount Transfer'],
    ] as const;
    for (const [path, form] of workflows) {
      expect(routePolicyFor('POST', path)).toMatchObject({ form, action: 'create' });
      expect(routePolicyFor('GET', `${path}/:vchNo`)).toMatchObject({ form, action: 'read' });
      expect(routePolicyFor('PUT', `${path}/:vchNo`)).toMatchObject({
        form,
        action: 'update',
      });
      expect(routePolicyFor('DELETE', `${path}/:vchNo`)).toMatchObject({
        form,
        action: 'delete',
      });
    }
  });

  it('maps VP Parcel to independent Sales lifecycle rights', () => {
    expect(routePolicyFor('POST', '/sales/vp-parcel')).toMatchObject({
      form: 'Sales/VP Parcel',
      action: 'create',
    });
    expect(routePolicyFor('GET', '/sales/vp-parcel/:vchNo')).toMatchObject({
      form: 'Sales/VP Parcel',
      action: 'read',
    });
    expect(routePolicyFor('PUT', '/sales/vp-parcel/:vchNo')).toMatchObject({
      form: 'Sales/VP Parcel',
      action: 'update',
    });
    expect(routePolicyFor('DELETE', '/sales/vp-parcel/:vchNo')).toMatchObject({
      form: 'Sales/VP Parcel',
      action: 'delete',
    });
  });

  it('maps persisted physical-stock lifecycle routes to independent rights', () => {
    expect(routePolicyFor('POST', '/stock/physical-stock')).toMatchObject({
      form: 'Inventory/Physical Stock',
      action: 'create',
    });
    expect(routePolicyFor('GET', '/stock/physical-stock/:vchNo')).toMatchObject({
      form: 'Inventory/Physical Stock',

      action: 'read',
    });
    expect(routePolicyFor('PUT', '/stock/physical-stock/:vchNo')).toMatchObject({
      form: 'Inventory/Physical Stock',
      action: 'update',
    });
    expect(routePolicyFor('DELETE', '/stock/physical-stock/:vchNo')).toMatchObject({
      form: 'Inventory/Physical Stock',
      action: 'delete',
    });
    expect(routePolicyFor('POST', '/stock/physical-reconcile')).toMatchObject({
      form: 'Inventory/Physical Stock',
      action: 'update',
    });
  });

  it('maps each stock voucher lifecycle to its existing form and independent actions', () => {
    const families = [
      ['/stock/tag-opening', 'Inventory/Tag Opening'],
      ['/stock/item-opening', 'Inventory/Item Opening (non-tag)'],
      ['/stock/item-lot', 'Inventory/Lot Management'],
    ] as const;
    for (const [path, form] of families) {
      expect(routePolicyFor('POST', path)).toMatchObject({ form, action: 'create' });
      expect(routePolicyFor('GET', `${path}/:vchNo`)).toMatchObject({ form, action: 'read' });
      expect(routePolicyFor('PUT', `${path}/:vchNo`)).toMatchObject({ form, action: 'update' });
      expect(routePolicyFor('DELETE', `${path}/:vchNo`)).toMatchObject({
        form,
        action: 'delete',
      });
    }
  });

  it('maps the sales voucher lifecycle to independent rights', () => {
    expect(routePolicyFor('POST', '/sales')).toMatchObject({
      form: 'Sales/Sales Invoice',
      action: 'create',
    });
    expect(routePolicyFor('GET', '/sales/:vchNo')).toMatchObject({
      form: 'Sales/Sales Invoice',
      action: 'read',
    });
    expect(routePolicyFor('PUT', '/sales/:vchNo')).toMatchObject({
      form: 'Sales/Sales Invoice',
      action: 'update',
    });
    expect(routePolicyFor('DELETE', '/sales/:vchNo')).toMatchObject({
      form: 'Sales/Sales Invoice',
      action: 'delete',
    });
  });

  it('maps the purchase voucher lifecycle to independent rights', () => {
    expect(routePolicyFor('POST', '/purchases')).toMatchObject({
      form: 'Purchase/Purchase Invoice',
      action: 'create',
    });
    expect(routePolicyFor('GET', '/purchases/:vchNo')).toMatchObject({
      form: 'Purchase/Purchase Invoice',
      action: 'read',
    });
    expect(routePolicyFor('PUT', '/purchases/:vchNo')).toMatchObject({
      form: 'Purchase/Purchase Invoice',
      action: 'update',
    });
    expect(routePolicyFor('DELETE', '/purchases/:vchNo')).toMatchObject({
      form: 'Purchase/Purchase Invoice',
      action: 'delete',
    });
  });

  it('maps the other-commission lifecycle to independent rights', () => {
    expect(routePolicyFor('POST', '/other-commission')).toMatchObject({
      form: 'Purchase/Other Commission / Expense Voucher',
      action: 'create',
    });
    expect(routePolicyFor('GET', '/other-commission/:vchNo')).toMatchObject({
      form: 'Purchase/Other Commission / Expense Voucher',
      action: 'read',
    });
    expect(routePolicyFor('PUT', '/other-commission/:vchNo')).toMatchObject({
      form: 'Purchase/Other Commission / Expense Voucher',
      action: 'update',
    });
    expect(routePolicyFor('DELETE', '/other-commission/:vchNo')).toMatchObject({
      form: 'Purchase/Other Commission / Expense Voucher',
      action: 'delete',
    });
  });
});

describe('device settings route policy', () => {
  it('requires Utilities/Settings read rights and active business scope', () => {
    expect(routePolicyFor('GET', '/integrations/device-settings')).toEqual({
      kind: 'form',
      form: 'Utilities/Settings',
      action: 'read',
      adminOnly: false,
      businessScope: true,
    });
  });
});
