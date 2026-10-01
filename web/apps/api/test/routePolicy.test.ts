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
  it('uses each owning order form and Setting form for new image and lot operations', () => {
    for (const [prefix, form] of [
      ['sales-orders', 'Sales/Sales Order'],
      ['tour-orders', 'Karigar/Tour Order'],
    ] as const) {
      for (const [method, action] of [
        ['GET', 'read'],
        ['POST', 'update'],
        ['DELETE', 'delete'],
      ] as const)
        expect(routePolicyFor(method, `/${prefix}/:vchNo/image`)).toMatchObject({
          kind: 'form',
          form,
          action,
          businessScope: true,
        });
    }
    for (const [kind, form] of [
      ['issue', 'Manufacturing/Setting Isu'],
      ['receive', 'Manufacturing/Setting Rec'],
    ] as const)
      for (const suffix of ['settings', 'list', 'sources', ':vchNo'])
        expect(routePolicyFor('GET', `/mfg/lot/${kind}/${suffix}`)).toMatchObject({
          kind: 'form',
          form,
          action: 'read',
          businessScope: true,
        });
  });
  it('classifies every declared endpoint and preserves the current exact route universe', () => {
    const routes = declaredRoutes();
    // The labour preview adds exactly three read-only Sales Return routes; X15 adds the seven E CRNT
    // entry-config/entry/create/update/delete/print/IRN-cancel routes, and the E INVOICE mode of the same
    // form adds eleven /e-invoices routes (browse, read, TCS basis, entry lifecycle, print, IRN, cancel).
    // The evaluation defects add six report screens: HUID, Item Stock Level, Bill Wise Profit, Physical
    // Stock Verify and Stock Movement (D3, previously export-only), plus /reports/gstr1 (D4).
    // X16 adds the four /wholesale-sales lifecycle routes (desktop "Wh Sales", its own right).
    // N18 adds list, tag source, read and update for each TR_TAG_CAN menu (tag cancel, tag transfer).
    // 596 on the previous baseline. The strict numeric Sale Return update (card X13 steps 8-9) adds one
    // guarded PUT; N33 replaces the web-only other-purchase create/delete pair with the full TR_OTH_PURC
    // OTH EXP lifecycle (read, update, print) and adds the Other Income print: 596 + 1 - 2 + 5 + 1 = 601.
    // N34 adds full-scope Purchase Return GET and print routes: 601 + 2 = 603.
    // N38 gives WH QUOT its own create/read/update/delete/print resource: 603 + 5 = 608.
    // N54 removes POST /render/pdf (client HTML into Chromium) and adds three server-built PDFs: the generic
    // report export, the account ledger's export and the estimate: 608 - 1 + 3 = 610.
    expect(routes).toHaveLength(610);
    expect(new Set(routes.map((route) => `${route.method} ${route.path}`)).size).toBe(610);

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
      if (policy.kind !== 'form' || policy.form === '@master' || policy.form === '@report')
        continue;
      expect(getFormEntry(policy.form!)).toBeDefined();
      expect(policy.action).toMatch(/^(read|create|update|delete|print)$/);
    }
  });

  it('binds saved Return browse/read and metadata updates to the Sales Return form', () => {
    for (const [method, path, action] of [
      ['GET', '/sales-returns/incoming-recent', 'read'],
      ['GET', '/sales-returns/source-vouchers', 'read'],
      ['GET', '/sales-returns/source-items', 'read'],
      ['GET', '/sales-returns/incoming-calculation-configuration', 'read'],
      ['GET', '/sales-returns/:vchNo/incoming', 'read'],
      ['GET', '/sales-returns/:vchNo/incoming-replay-state', 'read'],
      ['POST', '/sales-returns/:vchNo/incoming-replay', 'read'],
      ['GET', '/sales-returns/:vchNo/incoming-bill-replay-state', 'read'],
      ['POST', '/sales-returns/:vchNo/incoming-bill-replay', 'read'],
      ['GET', '/sales-returns/:vchNo/incoming-labour-replay-state', 'read'],
      ['POST', '/sales-returns/:vchNo/incoming-labour-observation', 'read'],
      ['POST', '/sales-returns/:vchNo/incoming-labour-replay', 'read'],
      ['PUT', '/sales-returns/:vchNo/incoming-metadata', 'update'],
      ['PUT', '/sales-returns/:vchNo/incoming-numeric', 'update'],
    ] as const)
      expect(routePolicyFor(method, path)).toMatchObject({
        kind: 'form',
        form: 'Sales/Sales Return',
        action,
        businessScope: true,
      });
  });

  it('binds generic, Design and repair image state and replacement to their own route rights', () => {
    for (const [path, form] of [
      ['/stock/tag-image', 'Inventory/Tag Print'],
      ['/masters/design-book/image', 'Masters/Design Book'],
      ['/repair-images', 'Manufacturing/Repair Receipt'],
    ] as const) {
      expect(routePolicyFor('GET', `${path}/state`)).toMatchObject({
        kind: 'form',
        form,
        action: 'read',
        businessScope: true,
      });
      expect(routePolicyFor('POST', path)).toMatchObject({
        kind: 'form',
        form,
        action: 'update',
        businessScope: true,
      });
      expect(routePolicyFor('DELETE', path)).toMatchObject({
        kind: 'form',
        form,
        action: 'delete',
        businessScope: true,
      });
    }
  });

  it('maps every dynamic master name to a canonical form', () => {
    expect(Object.keys(MASTER_FORM_BY_NAME).sort()).toEqual(Object.keys(MASTERS).sort());
    expect(Object.keys(MASTER_FORM_BY_NAME)).toHaveLength(34);
    for (const form of Object.values(MASTER_FORM_BY_NAME)) {
      expect(getFormEntry(form)).toBeDefined();
    }
  });

  it('maps the desktop E-Excel export to e-invoice print rights', () => {
    expect(routePolicyFor('GET', '/einvoice/export.xlsx')).toMatchObject({
      form: 'Utilities/e-Invoice (IRN)',
      action: 'print',
    });
  });

  it('maps the desktop customer/account reports to canonical report rights', () => {
    expect(routePolicyFor('GET', '/reports/last-visit')).toMatchObject({
      form: 'Reports/Last Visit',
      action: 'read',
    });
    expect(routePolicyFor('GET', '/reports/address-print')).toMatchObject({
      form: 'Reports/Address Print',
      action: 'read',
    });
  });

  it('maps the desktop Entry Check workflow to read/detail/update rights', () => {
    expect(routePolicyFor('GET', '/reports/entry-check')).toMatchObject({
      form: 'Reports/Entry Check',
      action: 'read',
    });
    expect(routePolicyFor('GET', '/reports/entry-check/detail')).toMatchObject({
      form: 'Reports/Entry Check',
      action: 'read',
    });
    expect(routePolicyFor('POST', '/reports/entry-check/mark-checked')).toMatchObject({
      form: 'Reports/Entry Check',
      action: 'update',
    });
  });

  it('maps the desktop Balance TrFr dashboard wrappers to Company rights', () => {
    expect(routePolicyFor('POST', '/balance-transfer/preview')).toMatchObject({
      form: 'Company/Balance TrFr',
      action: 'read',
    });
    expect(routePolicyFor('POST', '/balance-transfer/year-close')).toMatchObject({
      form: 'Company/Balance TrFr',
      action: 'update',
    });
    expect(routePolicyFor('POST', '/balance-transfer/openings')).toMatchObject({
      form: 'Company/Balance TrFr',
      action: 'update',
    });
  });

  it('maps the desktop UT_EXPORT utility to data-export rights', () => {
    expect(routePolicyFor('GET', '/utilities/data-export/preview')).toMatchObject({
      form: 'Utilities/Data Export',
      action: 'read',
    });
    expect(routePolicyFor('GET', '/utilities/data-export/download')).toMatchObject({
      form: 'Utilities/Data Export',
      action: 'print',
    });
    expect(routePolicyFor('POST', '/utilities/data-export/mark-exported')).toMatchObject({
      form: 'Utilities/Data Export',
      action: 'update',
    });
    expect(routePolicyFor('POST', '/utilities/data-export/reset-flags')).toMatchObject({
      form: 'Utilities/Data Export',
      action: 'update',
    });
  });

  it('maps the desktop UT_IMPORT Estimate Reset utility to delete-capable form rights', () => {
    expect(routePolicyFor('POST', '/utilities/estimate-reset/preview')).toMatchObject({
      form: 'Utilities/Estimate Reset',
      action: 'read',
    });
    expect(routePolicyFor('POST', '/utilities/estimate-reset/apply')).toMatchObject({
      form: 'Utilities/Estimate Reset',
      action: 'delete',
    });
  });

  it('maps the desktop Tag Adjust mode to its own inventory rights', () => {
    expect(routePolicyFor('POST', '/stock/tag-adjust')).toMatchObject({
      form: 'Inventory/Tag Adjust',
      action: 'create',
    });
    expect(routePolicyFor('GET', '/stock/tag-adjust/:vchNo')).toMatchObject({
      form: 'Inventory/Tag Adjust',
      action: 'read',
    });
    expect(routePolicyFor('PUT', '/stock/tag-adjust/:vchNo')).toMatchObject({
      form: 'Inventory/Tag Adjust',
      action: 'update',
    });
    expect(routePolicyFor('DELETE', '/stock/tag-adjust/:vchNo')).toMatchObject({
      form: 'Inventory/Tag Adjust',
      action: 'delete',
    });
  });

  it('maps the desktop User Report to its report rights', () => {
    expect(routePolicyFor('GET', '/reports/user-report')).toMatchObject({
      form: 'Reports/User Report',
      action: 'read',
    });
  });

  it('maps the desktop Old Item Sales workflow to ExtraTran rights', () => {
    expect(routePolicyFor('POST', '/old-item-sales')).toMatchObject({
      form: 'ExtraTran/Old Item Sales',
      action: 'create',
    });
    expect(routePolicyFor('GET', '/old-item-sales/:vchNo')).toMatchObject({
      form: 'ExtraTran/Old Item Sales',
      action: 'read',
    });
    expect(routePolicyFor('PUT', '/old-item-sales/:vchNo')).toMatchObject({
      form: 'ExtraTran/Old Item Sales',
      action: 'update',
    });
    expect(routePolicyFor('DELETE', '/old-item-sales/:vchNo')).toMatchObject({
      form: 'ExtraTran/Old Item Sales',
      action: 'delete',
    });
  });

  it('maps the desktop Stock In and Stock Out workflows to Transaction rights', () => {
    expect(routePolicyFor('POST', '/stock/out')).toMatchObject({
      form: 'Transaction/Stock Out',
      action: 'create',
    });
    expect(routePolicyFor('GET', '/stock/out/:vchNo')).toMatchObject({
      form: 'Transaction/Stock Out',
      action: 'read',
    });
    expect(routePolicyFor('PUT', '/stock/out/:vchNo')).toMatchObject({
      form: 'Transaction/Stock Out',
      action: 'update',
    });
    expect(routePolicyFor('DELETE', '/stock/out/:vchNo')).toMatchObject({
      form: 'Transaction/Stock Out',
      action: 'delete',
    });
    expect(routePolicyFor('POST', '/stock/in')).toMatchObject({
      form: 'Transaction/Stock In',
      action: 'create',
    });
    expect(routePolicyFor('GET', '/stock/in/:vchNo')).toMatchObject({
      form: 'Transaction/Stock In',
      action: 'read',
    });
    expect(routePolicyFor('PUT', '/stock/in/:vchNo')).toMatchObject({
      form: 'Transaction/Stock In',
      action: 'update',
    });
    expect(routePolicyFor('DELETE', '/stock/in/:vchNo')).toMatchObject({
      form: 'Transaction/Stock In',
      action: 'delete',
    });
  });

  it('maps the desktop Tour Order workflow to Karigar rights', () => {
    expect(routePolicyFor('GET', '/tour-orders/confirmation')).toMatchObject({
      form: 'Karigar/Tour Order',
      action: 'print',
    });
    expect(routePolicyFor('POST', '/tour-orders')).toMatchObject({
      form: 'Karigar/Tour Order',
      action: 'create',
    });
    expect(routePolicyFor('GET', '/tour-orders')).toMatchObject({
      form: 'Karigar/Tour Order',
      action: 'read',
    });
    expect(routePolicyFor('GET', '/tour-orders/:vchNo')).toMatchObject({
      form: 'Karigar/Tour Order',
      action: 'read',
    });
    expect(routePolicyFor('PUT', '/tour-orders/:vchNo')).toMatchObject({
      form: 'Karigar/Tour Order',
      action: 'update',
    });
    expect(routePolicyFor('DELETE', '/tour-orders/:vchNo')).toMatchObject({
      form: 'Karigar/Tour Order',
      action: 'delete',
    });
  });

  it('keeps calculation and credit-note readers on their own form rights', () => {
    for (const path of [
      '/masters/design-book/calculation-config',
      '/masters/design-book/component-defaults',
    ])
      expect(routePolicyFor('GET', path)).toMatchObject({
        form: 'Masters/Design Book',
        action: 'read',
      });
    for (const path of ['/e-credit-notes', '/e-credit-notes/provider', '/e-credit-notes/:vchNo'])
      expect(routePolicyFor('GET', path)).toMatchObject({
        form: 'Transaction/E CrntNote',
        action: 'read',
      });
  });

  it('maps the desktop E CrntNote workflow to Transaction print rights', () => {
    expect(routePolicyFor('POST', '/einvoice/credit-note/irn')).toMatchObject({
      form: 'Transaction/E CrntNote',
      action: 'print',
    });
  });

  it('maps the E INVOICE mode of TR_SL_EBILL to Transaction/E Invoice rights (X15)', () => {
    for (const [method, path, action] of [
      ['GET', '/e-invoices', 'read'],
      ['GET', '/e-invoices/entry-config', 'read'],
      ['GET', '/e-invoices/tcs-basis', 'read'],
      ['GET', '/e-invoices/:vchNo', 'read'],
      ['GET', '/e-invoices/:vchNo/entry', 'read'],
      ['POST', '/e-invoices', 'create'],
      ['PUT', '/e-invoices/:vchNo', 'update'],
      ['DELETE', '/e-invoices/:vchNo', 'delete'],
      ['GET', '/e-invoices/:vchNo/print', 'print'],
      ['POST', '/e-invoices/:vchNo/irn', 'print'],
      ['POST', '/e-invoices/:vchNo/irn/cancel', 'print'],
    ] as const)
      expect(routePolicyFor(method, path)).toMatchObject({
        kind: 'form',
        form: 'Transaction/E Invoice',
        action,
        businessScope: true,
      });
  });

  it('maps the E CRNT entry lifecycle to its own form rights (X15)', () => {
    for (const [method, path, action] of [
      ['GET', '/e-credit-notes/entry-config', 'read'],
      ['GET', '/e-credit-notes/:vchNo/entry', 'read'],
      ['POST', '/e-credit-notes', 'create'],
      ['PUT', '/e-credit-notes/:vchNo', 'update'],
      ['DELETE', '/e-credit-notes/:vchNo', 'delete'],
      ['GET', '/e-credit-notes/:vchNo/print', 'print'],
      ['POST', '/e-credit-notes/:vchNo/irn/cancel', 'print'],
    ] as const)
      expect(routePolicyFor(method, path)).toMatchObject({
        kind: 'form',
        form: 'Transaction/E CrntNote',
        action,
        businessScope: true,
      });
  });

  it('maps the desktop Loan Received and Loan Issue transaction modes to their own rights', () => {
    expect(routePolicyFor('POST', '/loan/received')).toMatchObject({
      form: 'Loans (Dhrn)/Loan Received',
      action: 'create',
    });
    expect(routePolicyFor('POST', '/loan/issue')).toMatchObject({
      form: 'Loans (Dhrn)/Loan Issue',
      action: 'create',
    });
    expect(routePolicyFor('GET', '/loan/:isuNo/outstanding')).toMatchObject({
      form: 'Loans (Dhrn)/Loan Issue',
      action: 'read',
    });
  });

  it('maps the desktop Dhiran/Loan report routes to their report rights', () => {
    expect(routePolicyFor('GET', '/reports/dhiran-report')).toMatchObject({
      form: 'Reports/Dhiran Report',
      action: 'read',
    });
    expect(routePolicyFor('GET', '/reports/loan-report')).toMatchObject({
      form: 'Reports/Loan Report',
      action: 'read',
    });
  });

  it('maps the desktop GST report launcher to its report rights', () => {
    expect(routePolicyFor('GET', '/reports/gst-report')).toMatchObject({
      form: 'Reports/GST Report',
      action: 'read',
    });
  });

  it('maps RP_ORDER Delete Data and Point Report routes to report rights', () => {
    expect(routePolicyFor('GET', '/reports/delete-data')).toMatchObject({
      form: 'Reports/Delete Data',
      action: 'read',
    });
    expect(routePolicyFor('GET', '/reports/point-report')).toMatchObject({
      form: 'Reports/Point Report',
      action: 'read',
    });
    expect(routePolicyFor('GET', '/reports/point-report/detail')).toMatchObject({
      form: 'Reports/Point Report',
      action: 'read',
    });
  });

  it('maps MS_STK_LIMIT desktop modes to exact master rights', () => {
    expect(routePolicyFor('GET', '/masters/diamond-sizes')).toMatchObject({
      form: 'Masters/Diamond Sizes',
      action: 'read',
    });
    expect(routePolicyFor('POST', '/masters/diamond-sizes')).toMatchObject({
      form: 'Masters/Diamond Sizes',
      action: 'update',
    });
    expect(routePolicyFor('DELETE', '/masters/diamond-sizes')).toMatchObject({
      form: 'Masters/Diamond Sizes',
      action: 'delete',
    });
    expect(routePolicyFor('GET', '/masters/item-stock-limits')).toMatchObject({
      form: 'Masters/Item Stock Limits',
      action: 'read',
    });
    expect(routePolicyFor('POST', '/masters/item-stock-limits')).toMatchObject({
      form: 'Masters/Item Stock Limits',
      action: 'update',
    });
    expect(routePolicyFor('DELETE', '/masters/item-stock-limits')).toMatchObject({
      form: 'Masters/Item Stock Limits',
      action: 'delete',
    });
  });

  it('maps RP_LC_INOUT Branch InOut to report rights', () => {
    expect(routePolicyFor('GET', '/reports/branch-inout')).toMatchObject({
      form: 'Reports/Branch InOut',
      action: 'read',
    });
  });

  it('maps RP_OTH_DETL Other Item Report to report rights', () => {
    expect(routePolicyFor('GET', '/reports/other-item-report')).toMatchObject({
      form: 'Reports/Other Item Report',
      action: 'read',
    });
  });

  it('maps RP_STK_MOVE Design Move summary and detail to report rights', () => {
    expect(routePolicyFor('GET', '/reports/design-move')).toMatchObject({
      form: 'Reports/Design Move',
      action: 'read',
    });
    expect(routePolicyFor('GET', '/reports/design-move/detail')).toMatchObject({
      form: 'Reports/Design Move',
      action: 'read',
    });
  });

  it('maps RP_CONSI_APR summary and detail routes to report rights', () => {
    expect(routePolicyFor('GET', '/reports/consi-report')).toMatchObject({
      form: 'Reports/Consi Report',
      action: 'read',
    });
    expect(routePolicyFor('GET', '/reports/consi-report/detail')).toMatchObject({
      form: 'Reports/Consi Report',
      action: 'read',
    });
  });

  it('maps RP_SLPR_ZOOM Old Stock to report rights', () => {
    expect(routePolicyFor('GET', '/reports/old-stock')).toMatchObject({
      form: 'Reports/Old Stock',
      action: 'read',
    });
  });

  it('maps RP_TRADING Trading Report to report rights', () => {
    expect(routePolicyFor('GET', '/reports/trading-report')).toMatchObject({
      form: 'Reports/Trading Report',
      action: 'read',
    });
  });

  it('maps RP_TOUR_ZOOM Tour Report and Tour Tag to report rights', () => {
    expect(routePolicyFor('GET', '/reports/tour-report')).toMatchObject({
      form: 'Reports/Tour Report',
      action: 'read',
    });
    expect(routePolicyFor('GET', '/reports/tour-tag')).toMatchObject({
      form: 'Reports/Tour Tag',
      action: 'read',
    });
  });

  it('maps RP_ORD_TRACK Order Track to report rights', () => {
    expect(routePolicyFor('GET', '/reports/order-track')).toMatchObject({
      form: 'Reports/Order Track',
      action: 'read',
    });
  });

  it('maps RP_STK_LEVEL Scheme Monthly Report to report rights', () => {
    expect(routePolicyFor('GET', '/reports/scheme-monthly')).toMatchObject({
      form: 'Reports/Scheme Monthly Report',
      action: 'read',
    });
  });

  it('maps RP_MFG_ZOOM manufacturing report routes to report rights', () => {
    expect(routePolicyFor('GET', '/reports/mfg-inout')).toMatchObject({
      form: 'Reports/Mfg InOut',
      action: 'read',
    });
    expect(routePolicyFor('GET', '/reports/mfg-lot-isurec')).toMatchObject({
      form: 'Reports/Mfg Lot IsuRec',
      action: 'read',
    });
  });

  it('maps RP_MFG_LEDR Mfg Ledger summary and detail routes to report rights', () => {
    expect(routePolicyFor('GET', '/reports/mfg-ledger')).toMatchObject({
      form: 'Reports/Mfg Ledger',
      action: 'read',
    });
    expect(routePolicyFor('GET', '/reports/mfg-ledger/detail')).toMatchObject({
      form: 'Reports/Mfg Ledger',
      action: 'read',
    });
  });

  it('maps RP_ALL report family routes to their report rights', () => {
    for (const [path, form] of [
      ['/reports/approval-report', 'Reports/Approval Report'],
      ['/reports/vp-report', 'Reports/VP Report'],
      ['/reports/bullion-report', 'Reports/Bullion Report'],
      ['/reports/karigar-report', 'Reports/Karigar Report'],
      ['/reports/repair-report', 'Reports/Repair Report'],
    ] as const) {
      expect(routePolicyFor('GET', path)).toMatchObject({ form, action: 'read' });
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

  it('maps Stone/Dm-Cf SF PRINT routes to independent inventory rights', () => {
    expect(routePolicyFor('POST', '/stock/stone-dm-cf')).toMatchObject({
      form: 'Inventory/Stone/Dm-Cf',
      action: 'create',
    });
    expect(routePolicyFor('GET', '/stock/stone-dm-cf/source-list')).toMatchObject({
      form: 'Inventory/Stone/Dm-Cf',
      action: 'read',
    });
    expect(routePolicyFor('GET', '/stock/stone-dm-cf/:vchNo')).toMatchObject({
      form: 'Inventory/Stone/Dm-Cf',
      action: 'read',
    });
    expect(routePolicyFor('PUT', '/stock/stone-dm-cf/:vchNo')).toMatchObject({
      form: 'Inventory/Stone/Dm-Cf',
      action: 'update',
    });
    expect(routePolicyFor('DELETE', '/stock/stone-dm-cf/:vchNo')).toMatchObject({
      form: 'Inventory/Stone/Dm-Cf',
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

  it('maps the consignment purchase lifecycle and source importer to independent rights', () => {
    expect(routePolicyFor('GET', '/consignment-purchases/open-receipts')).toMatchObject({
      form: 'Purchase/Consignment Purchase',
      action: 'read',
    });
    expect(routePolicyFor('POST', '/consignment-purchases')).toMatchObject({
      form: 'Purchase/Consignment Purchase',
      action: 'create',
    });
    expect(routePolicyFor('GET', '/consignment-purchases/:vchNo')).toMatchObject({
      form: 'Purchase/Consignment Purchase',
      action: 'read',
    });
    expect(routePolicyFor('PUT', '/consignment-purchases/:vchNo')).toMatchObject({
      form: 'Purchase/Consignment Purchase',
      action: 'update',
    });
    expect(routePolicyFor('DELETE', '/consignment-purchases/:vchNo')).toMatchObject({
      form: 'Purchase/Consignment Purchase',
      action: 'delete',
    });
  });

  it('maps the purchase quotation lifecycle and print route to independent rights', () => {
    expect(routePolicyFor('POST', '/purchase-quotations')).toMatchObject({
      form: 'Purchase/Purchase Quotation',
      action: 'create',
    });
    expect(routePolicyFor('GET', '/purchase-quotations/:vchNo')).toMatchObject({
      form: 'Purchase/Purchase Quotation',
      action: 'read',
    });
    expect(routePolicyFor('PUT', '/purchase-quotations/:vchNo')).toMatchObject({
      form: 'Purchase/Purchase Quotation',
      action: 'update',
    });
    expect(routePolicyFor('DELETE', '/purchase-quotations/:vchNo')).toMatchObject({
      form: 'Purchase/Purchase Quotation',
      action: 'delete',
    });
    expect(routePolicyFor('GET', '/purchase-quotations/quotation')).toMatchObject({
      form: 'Purchase/Purchase Quotation',
      action: 'print',
    });
  });

  it('maps the sales quotation lifecycle and print route to independent rights', () => {
    expect(routePolicyFor('POST', '/sales-quotations')).toMatchObject({
      form: 'Sales/Sales Quotation',
      action: 'create',
    });
    expect(routePolicyFor('GET', '/sales-quotations/:vchNo')).toMatchObject({
      form: 'Sales/Sales Quotation',
      action: 'read',
    });
    expect(routePolicyFor('PUT', '/sales-quotations/:vchNo')).toMatchObject({
      form: 'Sales/Sales Quotation',
      action: 'update',
    });
    expect(routePolicyFor('DELETE', '/sales-quotations/:vchNo')).toMatchObject({
      form: 'Sales/Sales Quotation',
      action: 'delete',
    });
    expect(routePolicyFor('GET', '/sales-quotations/quotation')).toMatchObject({
      form: 'Sales/Sales Quotation',
      action: 'print',
    });
  });

  it('maps the bullion sale and rate-cut rewrite lifecycles to their own form rights', () => {
    expect(routePolicyFor('POST', '/bullion-sales')).toMatchObject({
      form: 'Sales/Bul Sales',
      action: 'create',
    });
    expect(routePolicyFor('GET', '/bullion-sales/:vchNo')).toMatchObject({
      form: 'Sales/Bul Sales',
      action: 'read',
    });
    expect(routePolicyFor('PUT', '/bullion-sales/:vchNo')).toMatchObject({
      form: 'Sales/Bul Sales',
      action: 'update',
    });
    expect(routePolicyFor('DELETE', '/bullion-sales/:vchNo')).toMatchObject({
      form: 'Sales/Bul Sales',
      action: 'delete',
    });
    expect(routePolicyFor('PUT', '/rate-cut/:vchNo')).toMatchObject({
      form: 'Cash / Bank/Rate Cut (price fixing)',
      action: 'update',
    });
    // Desktop "Wh Sales" is its own menu and right (MDI_FORM.cs:8038-8046), not the Rate Cut right.
    for (const [method, path, action] of [
      ['POST', '/wholesale-sales', 'create'],
      ['GET', '/wholesale-sales/:vchNo', 'read'],
      ['PUT', '/wholesale-sales/:vchNo', 'update'],
      ['DELETE', '/wholesale-sales/:vchNo', 'delete'],
    ] as const)
      expect(routePolicyFor(method, path)).toMatchObject({ form: 'Sales/Wholesale Sale', action });
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

  it('maps the other-income lifecycle to independent rights', () => {
    expect(routePolicyFor('POST', '/other-income')).toMatchObject({
      form: 'Purchase/Other Income',
      action: 'create',
    });
    expect(routePolicyFor('GET', '/other-income/:vchNo')).toMatchObject({
      form: 'Purchase/Other Income',
      action: 'read',
    });
    expect(routePolicyFor('PUT', '/other-income/:vchNo')).toMatchObject({
      form: 'Purchase/Other Income',
      action: 'update',
    });
    expect(routePolicyFor('DELETE', '/other-income/:vchNo')).toMatchObject({
      form: 'Purchase/Other Income',
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
